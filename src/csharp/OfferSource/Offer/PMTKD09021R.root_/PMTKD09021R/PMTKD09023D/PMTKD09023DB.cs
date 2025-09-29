using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmSetNoteWork
    /// <summary>
    ///                      優良設定用備考ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良設定用備考ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2006/11/22</br>
    /// <br>Genarated Date   :   2008/05/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   β版→PM.NS用修正</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmSetNoteWork : IFileHeaderOffer2
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>部品メーカーコード</summary>
        private Int32 _partsMakerCd;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>重要備考区分</summary>
        /// <remarks>0:情報 1:重要 2:警告</remarks>
        private Int32 _importantNoteCd;

        /// <summary>優良設定備考</summary>
        /// <remarks>HTML形式、又はXML形式でセット</remarks>
        private string _prmSetNote = "";


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

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
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

        /// public propaty name  :  ImportantNoteCd
        /// <summary>重要備考区分プロパティ</summary>
        /// <value>0:情報 1:重要 2:警告</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重要備考区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ImportantNoteCd
        {
            get { return _importantNoteCd; }
            set { _importantNoteCd = value; }
        }

        /// public propaty name  :  PrmSetNote
        /// <summary>優良設定備考プロパティ</summary>
        /// <value>HTML形式、又はXML形式でセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetNote
        {
            get { return _prmSetNote; }
            set { _prmSetNote = value; }
        }


        /// <summary>
        /// 優良設定用備考ワークコンストラクタ
        /// </summary>
        /// <returns>PrmSetNoteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetNoteWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmSetNoteWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmSetNoteWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmSetNoteWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmSetNoteWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetNoteWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSetNoteWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSetNoteWork || graph is ArrayList || graph is PrmSetNoteWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmSetNoteWork).FullName));

            if (graph != null && graph is PrmSetNoteWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSetNoteWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSetNoteWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSetNoteWork[])graph).Length;
            }
            else if (graph is PrmSetNoteWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //重要備考区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ImportantNoteCd
            //優良設定備考
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetNote


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSetNoteWork)
            {
                PrmSetNoteWork temp = (PrmSetNoteWork)graph;

                SetPrmSetNoteWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSetNoteWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSetNoteWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSetNoteWork temp in lst)
                {
                    SetPrmSetNoteWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmSetNoteWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  PrmSetNoteWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetNoteWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmSetNoteWork(System.IO.BinaryWriter writer, PrmSetNoteWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //重要備考区分
            writer.Write(temp.ImportantNoteCd);
            //優良設定備考
            writer.Write(temp.PrmSetNote);

        }

        /// <summary>
        ///  PrmSetNoteWorkインスタンス取得
        /// </summary>
        /// <returns>PrmSetNoteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetNoteWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmSetNoteWork GetPrmSetNoteWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmSetNoteWork temp = new PrmSetNoteWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //重要備考区分
            temp.ImportantNoteCd = reader.ReadInt32();
            //優良設定備考
            temp.PrmSetNote = reader.ReadString();


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
        /// <returns>PrmSetNoteWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetNoteWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSetNoteWork temp = GetPrmSetNoteWork(reader, serInfo);
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
                    retValue = (PrmSetNoteWork[])lst.ToArray(typeof(PrmSetNoteWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

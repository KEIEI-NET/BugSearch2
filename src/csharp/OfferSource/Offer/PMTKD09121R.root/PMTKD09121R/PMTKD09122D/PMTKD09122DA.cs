using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AutoEstmPtNoChgWork
    /// <summary>
    ///                      ＢＬコード変換ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＢＬコード変換ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2012/05/25</br>
    /// <br>Genarated Date   :   2012/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AutoEstmPtNoChgWork
    {
        /// <summary>提供日付</summary>
        private DateTime _offerDate;
        /// <summary>共有在庫サブ部品コード</summary>
        private Int32 _sharedStcSubPtsCd;
        /// <summary>部位コード</summary>
        private Int32 _partsPosCode;
        /// <summary>自動見積部品コード</summary>
        private string _autoEstimatePartsCd = "";
        /// <summary>翼部品コード</summary>
        private Int32 _tbsPartsCode;
        /// <summary>翼部品コード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;
        /// <summary>新BLコード品名</summary>
        private string _newBLCodeName = "";
        /// <summary>部品略称</summary>
        private string _partsAbbreviation = "";
        /// <summary>構成メインフラグ</summary>
        private Int32 _compoMainFlag;
        /// <summary>表示順位</summary>
        private Int32 _displayOrder;
        /// <summary>部位メインフラグ</summary>
        private Int32 _partsPosMainFlag;


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

        /// public propaty name  :  SharedStcSubPtsCd
        /// <summary>共有在庫サブ部品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共有在庫サブ部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SharedStcSubPtsCd
        {
            get { return _sharedStcSubPtsCd; }
            set { _sharedStcSubPtsCd = value; }
        }

        /// public propaty name  :  PartsPosCode
        /// <summary>部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPosCode
        {
            get { return _partsPosCode; }
            set { _partsPosCode = value; }
        }

        /// public propaty name  :  AutoEstimatePartsCd
        /// <summary>自動見積部品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動見積部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AutoEstimatePartsCd
        {
            get { return _autoEstimatePartsCd; }
            set { _autoEstimatePartsCd = value; }
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

        /// public propaty name  :  NewBLCodeName
        /// <summary>新BLコード品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新BLコード品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewBLCodeName
        {
            get { return _newBLCodeName; }
            set { _newBLCodeName = value; }
        }

        /// public propaty name  :  PartsAbbreviation
        /// <summary>部品略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsAbbreviation
        {
            get { return _partsAbbreviation; }
            set { _partsAbbreviation = value; }
        }

        /// public propaty name  :  CompoMainFlag
        /// <summary>構成メインフラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   構成メインフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompoMainFlag
        {
            get { return _compoMainFlag; }
            set { _compoMainFlag = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  PartsPosMainFlag
        /// <summary>部位メインフラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位メインフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPosMainFlag
        {
            get { return _partsPosMainFlag; }
            set { _partsPosMainFlag = value; }
        }


        /// <summary>
        /// ＢＬコード変換ワークコンストラクタ
        /// </summary>
        /// <returns>AutoEstmPtNoChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AutoEstmPtNoChgWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AutoEstmPtNoChgWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AutoEstmPtNoChgWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AutoEstmPtNoChgWork_SerializationSurrogateSerialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AutoEstmPtNoChgWork || graph is ArrayList || graph is AutoEstmPtNoChgWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AutoEstmPtNoChgWork).FullName));

            if (graph != null && graph is AutoEstmPtNoChgWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AutoEstmPtNoChgWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AutoEstmPtNoChgWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AutoEstmPtNoChgWork[])graph).Length;
            }
            else if (graph is AutoEstmPtNoChgWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //共有在庫サブ部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SharedStcSubPtsCd
            //部位コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPosCode
            //自動見積部品コード
            serInfo.MemberInfo.Add(typeof(string)); //AutoEstimatePartsCd
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //新BLコード品名
            serInfo.MemberInfo.Add(typeof(string)); //NewBLCodeName
            //部品略称
            serInfo.MemberInfo.Add(typeof(string)); //PartsAbbreviation
            //構成メインフラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CompoMainFlag
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //部位メインフラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPosMainFlag

            serInfo.Serialize(writer, serInfo);
            if (graph is AutoEstmPtNoChgWork)
            {
                AutoEstmPtNoChgWork temp = (AutoEstmPtNoChgWork)graph;

                SetAutoEstmPtNoChgWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AutoEstmPtNoChgWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AutoEstmPtNoChgWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AutoEstmPtNoChgWork temp in lst)
                {
                    SetAutoEstmPtNoChgWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AutoEstmPtNoChgWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  AutoEstmPtNoChgWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAutoEstmPtNoChgWork(System.IO.BinaryWriter writer, AutoEstmPtNoChgWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //共有在庫サブ部品コード
            writer.Write(temp.SharedStcSubPtsCd);
            //部位コード
            writer.Write(temp.PartsPosCode);
            //自動見積部品コード
            writer.Write(temp.AutoEstimatePartsCd);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //新BLコード品名
            writer.Write(temp.NewBLCodeName);
            //部品略称
            writer.Write(temp.PartsAbbreviation);
            //構成メインフラグ
            writer.Write(temp.CompoMainFlag);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //部位メインフラグ
            writer.Write(temp.PartsPosMainFlag);
        }

        /// <summary>
        ///  AutoEstmPtNoChgWorkインスタンス取得
        /// </summary>
        /// <returns>AutoEstmPtNoChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AutoEstmPtNoChgWork GetAutoEstmPtNoChgWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AutoEstmPtNoChgWork temp = new AutoEstmPtNoChgWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //共有在庫サブ部品コード
            temp.SharedStcSubPtsCd = reader.ReadInt32(); //SharedStcSubPtsCd
            //部位コード
            temp.PartsPosCode = reader.ReadInt32(); //PartsPosCode
            //自動見積部品コード
            temp.AutoEstimatePartsCd = reader.ReadString(); //AutoEstimatePartsCd
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32(); //TbsPartsCode
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32(); //TbsPartsCdDerivedNo
            //新BLコード品名
            temp.NewBLCodeName = reader.ReadString(); //NewBLCodeName
            //部品略称
            temp.PartsAbbreviation = reader.ReadString(); //PartsAbbreviation
            //構成メインフラグ
            temp.CompoMainFlag = reader.ReadInt32(); //CompoMainFlag
            //表示順位
            temp.DisplayOrder = reader.ReadInt32(); //DisplayOrder
            //部位メインフラグ
            temp.PartsPosMainFlag = reader.ReadInt32(); //PartsPosMainFlag

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
        /// <returns>AutoEstmPtNoChgWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoEstmPtNoChgWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AutoEstmPtNoChgWork temp = GetAutoEstmPtNoChgWork(reader, serInfo);
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
                    retValue = (AutoEstmPtNoChgWork[])lst.ToArray(typeof(AutoEstmPtNoChgWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

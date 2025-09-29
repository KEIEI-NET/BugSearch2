using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstUSearchResultWork
    /// <summary>
    ///                      更新履歴表示抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   更新履歴表示抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsSubstUSearchResultWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>変換元メーカーコード</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>変換元商品番号</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>ハイフン無変換元商品番号</summary>
        private string _chgSrcGoodsNoNoneHp = "";

        /// <summary>倉庫コード</summary>
        private string _chgSrcWarehouseCode = "";

        /// <summary>倉庫棚番</summary>
        private string _chgSrcWarehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        private string _chgSrcDuplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        private string _chgSrcDuplicationShelfNo2 = "";

        /// <summary>出荷可能数</summary>
        private Double _chgSrcShipmentPosCnt;

        /// <summary>変換先メーカーコード</summary>
        private Int32 _chgDestMakerCd;

        /// <summary>変換先商品番号</summary>
        private string _chgDestGoodsNo = "";

        /// <summary>ハイフン無変換先商品番号</summary>
        private string _chgDestGoodsNoNoneHp = "";

        /// <summary>倉庫コード</summary>
        private string _chgDestWarehouseCode = "";

        /// <summary>倉庫棚番</summary>
        private string _chgDestWarehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        private string _chgDestDuplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        private string _chgDestDuplicationShelfNo2 = "";

        /// <summary>出荷可能数</summary>
        private Double _chgDestShipmentPosCnt;


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

        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>変換元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>変換元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNoNoneHp
        /// <summary>ハイフン無変換元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無変換元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcGoodsNoNoneHp
        {
            get { return _chgSrcGoodsNoNoneHp; }
            set { _chgSrcGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgSrcWarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcWarehouseCode
        {
            get { return _chgSrcWarehouseCode; }
            set { _chgSrcWarehouseCode = value; }
        }

        /// public propaty name  :  ChgSrcWarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcWarehouseShelfNo
        {
            get { return _chgSrcWarehouseShelfNo; }
            set { _chgSrcWarehouseShelfNo = value; }
        }

        /// public propaty name  :  ChgSrcDuplicationShelfNo1
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcDuplicationShelfNo1
        {
            get { return _chgSrcDuplicationShelfNo1; }
            set { _chgSrcDuplicationShelfNo1 = value; }
        }

        /// public propaty name  :  ChgSrcDuplicationShelfNo2
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcDuplicationShelfNo2
        {
            get { return _chgSrcDuplicationShelfNo2; }
            set { _chgSrcDuplicationShelfNo2 = value; }
        }

        /// public propaty name  :  ChgSrcShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ChgSrcShipmentPosCnt
        {
            get { return _chgSrcShipmentPosCnt; }
            set { _chgSrcShipmentPosCnt = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>変換先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>変換先商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestGoodsNoNoneHp
        /// <summary>ハイフン無変換先商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無変換先商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestGoodsNoNoneHp
        {
            get { return _chgDestGoodsNoNoneHp; }
            set { _chgDestGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgDestWarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestWarehouseCode
        {
            get { return _chgDestWarehouseCode; }
            set { _chgDestWarehouseCode = value; }
        }

        /// public propaty name  :  ChgDestWarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestWarehouseShelfNo
        {
            get { return _chgDestWarehouseShelfNo; }
            set { _chgDestWarehouseShelfNo = value; }
        }

        /// public propaty name  :  ChgDestDuplicationShelfNo1
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestDuplicationShelfNo1
        {
            get { return _chgDestDuplicationShelfNo1; }
            set { _chgDestDuplicationShelfNo1 = value; }
        }

        /// public propaty name  :  ChgDestDuplicationShelfNo2
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestDuplicationShelfNo2
        {
            get { return _chgDestDuplicationShelfNo2; }
            set { _chgDestDuplicationShelfNo2 = value; }
        }

        /// public propaty name  :  ChgDestShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ChgDestShipmentPosCnt
        {
            get { return _chgDestShipmentPosCnt; }
            set { _chgDestShipmentPosCnt = value; }
        }


        /// <summary>
        /// 代替新旧関連表示抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>PartsSubstUSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstUSearchResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsSubstUSearchResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsSubstUSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstUSearchResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsSubstUSearchResultWork || graph is ArrayList || graph is PartsSubstUSearchResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsSubstUSearchResultWork).FullName));

            if (graph != null && graph is PartsSubstUSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsSubstUSearchResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsSubstUSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsSubstUSearchResultWork[])graph).Length;
            }
            else if (graph is PartsSubstUSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //変換元メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgSrcMakerCd
            //変換元商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNo
            //ハイフン無変換元商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNoNoneHp
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcWarehouseCode
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcWarehouseShelfNo
            //重複棚番１
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcDuplicationShelfNo1
            //重複棚番２
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcDuplicationShelfNo2
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ChgSrcShipmentPosCnt
            //変換先メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgDestMakerCd
            //変換先商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNo
            //ハイフン無変換先商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNoNoneHp
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestWarehouseCode
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestWarehouseShelfNo
            //重複棚番１
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestDuplicationShelfNo1
            //重複棚番２
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestDuplicationShelfNo2
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ChgDestShipmentPosCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsSubstUSearchResultWork)
            {
                PartsSubstUSearchResultWork temp = (PartsSubstUSearchResultWork)graph;

                SetPartsSubstUSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsSubstUSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsSubstUSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsSubstUSearchResultWork temp in lst)
                {
                    SetPartsSubstUSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsSubstUSearchResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  PartsSubstUSearchResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsSubstUSearchResultWork(System.IO.BinaryWriter writer, PartsSubstUSearchResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //変換元メーカーコード
            writer.Write(temp.ChgSrcMakerCd);
            //変換元商品番号
            writer.Write(temp.ChgSrcGoodsNo);
            //ハイフン無変換元商品番号
            writer.Write(temp.ChgSrcGoodsNoNoneHp);
            //倉庫コード
            writer.Write(temp.ChgSrcWarehouseCode);
            //倉庫棚番
            writer.Write(temp.ChgSrcWarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.ChgSrcDuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.ChgSrcDuplicationShelfNo2);
            //出荷可能数
            writer.Write(temp.ChgSrcShipmentPosCnt);
            //変換先メーカーコード
            writer.Write(temp.ChgDestMakerCd);
            //変換先商品番号
            writer.Write(temp.ChgDestGoodsNo);
            //ハイフン無変換先商品番号
            writer.Write(temp.ChgDestGoodsNoNoneHp);
            //倉庫コード
            writer.Write(temp.ChgDestWarehouseCode);
            //倉庫棚番
            writer.Write(temp.ChgDestWarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.ChgDestDuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.ChgDestDuplicationShelfNo2);
            //出荷可能数
            writer.Write(temp.ChgDestShipmentPosCnt);

        }

        /// <summary>
        ///  PartsSubstUSearchResultWorkインスタンス取得
        /// </summary>
        /// <returns>PartsSubstUSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsSubstUSearchResultWork GetPartsSubstUSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsSubstUSearchResultWork temp = new PartsSubstUSearchResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //変換元メーカーコード
            temp.ChgSrcMakerCd = reader.ReadInt32();
            //変換元商品番号
            temp.ChgSrcGoodsNo = reader.ReadString();
            //ハイフン無変換元商品番号
            temp.ChgSrcGoodsNoNoneHp = reader.ReadString();
            //倉庫コード
            temp.ChgSrcWarehouseCode = reader.ReadString();
            //倉庫棚番
            temp.ChgSrcWarehouseShelfNo = reader.ReadString();
            //重複棚番１
            temp.ChgSrcDuplicationShelfNo1 = reader.ReadString();
            //重複棚番２
            temp.ChgSrcDuplicationShelfNo2 = reader.ReadString();
            //出荷可能数
            temp.ChgSrcShipmentPosCnt = reader.ReadDouble();
            //変換先メーカーコード
            temp.ChgDestMakerCd = reader.ReadInt32();
            //変換先商品番号
            temp.ChgDestGoodsNo = reader.ReadString();
            //ハイフン無変換先商品番号
            temp.ChgDestGoodsNoNoneHp = reader.ReadString();
            //倉庫コード
            temp.ChgDestWarehouseCode = reader.ReadString();
            //倉庫棚番
            temp.ChgDestWarehouseShelfNo = reader.ReadString();
            //重複棚番１
            temp.ChgDestDuplicationShelfNo1 = reader.ReadString();
            //重複棚番２
            temp.ChgDestDuplicationShelfNo2 = reader.ReadString();
            //出荷可能数
            temp.ChgDestShipmentPosCnt = reader.ReadDouble();


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
        /// <returns>PartsSubstUSearchResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsSubstUSearchResultWork temp = GetPartsSubstUSearchResultWork(reader, serInfo);
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
                    retValue = (PartsSubstUSearchResultWork[])lst.ToArray(typeof(PartsSubstUSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

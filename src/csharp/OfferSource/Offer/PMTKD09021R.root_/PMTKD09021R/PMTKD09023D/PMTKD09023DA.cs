using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmSettingWork
    /// <summary>
    ///                      優良設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/1/15</br>
    /// <br>Genarated Date   :   2009/01/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   テーブル名変更</br>
    /// <br>                 :   PrmeSettingRF</br>
    /// <br>Update Note      :   2008/9/2  杉村</br>
    /// <br>                 :   ○NULL許可に変更</br>
    /// <br>                 :   優良設定詳細名称１</br>
    /// <br>                 :   優良設定詳細名称２</br>
    /// <br>Update Note      :   2008/11/10  杉村</br>
    /// <br>                 :   ○NULL許可変更（すべて不可にする）</br>
    /// <br>Update Note      :   2008/12/23  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   優良設定グループ</br>
    /// <br>Update Note      :   2015/02/23  豊沢</br>
    /// <br>                 :   SCM高速化 C向け種別特記対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmSettingWork : IFileHeaderOffer2
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

        /// <summary>シークレット区分</summary>
        /// <remarks>0:通常　1:シークレット</remarks>
        private Int32 _secretCode;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>優良設定詳細名称１</summary>
        private string _prmSetDtlName1 = "";

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>優良設定詳細名称２</summary>
        private string _prmSetDtlName2 = "";

        /// <summary>優良設定グループ</summary>
        /// <remarks>0：設定なし １～同一設定グループ</remarks>
        private Int32 _prmSetGroup;

        // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
        /// <summary>優良設定詳細名称２(工場向け)</summary>
        private string _prmSetDtlName2ForFac = "";

        /// <summary>優良設定詳細名称２(カーオーナー向け)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<

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

        /// public propaty name  :  SecretCode
        /// <summary>シークレット区分プロパティ</summary>
        /// <value>0:通常　1:シークレット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シークレット区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecretCode
        {
            get { return _secretCode; }
            set { _secretCode = value; }
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

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlName1
        /// <summary>優良設定詳細名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName1
        {
            get { return _prmSetDtlName1; }
            set { _prmSetDtlName1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>優良設定詳細名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  PrmSetGroup
        /// <summary>優良設定グループプロパティ</summary>
        /// <value>0：設定なし １～同一設定グループ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定グループプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetGroup
        {
            get { return _prmSetGroup; }
            set { _prmSetGroup = value; }
        }

        // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>優良設定詳細名称２(工場向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(工場向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>優良設定詳細名称２(カーオーナー向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(カーオーナー向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<

        /// <summary>
        /// 優良設定ワークコンストラクタ
        /// </summary>
        /// <returns>PrmSettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmSettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmSettingWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmSettingWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmSettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSettingWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSettingWork || graph is ArrayList || graph is PrmSettingWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmSettingWork).FullName));

            if (graph != null && graph is PrmSettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSettingWork[])graph).Length;
            }
            else if (graph is PrmSettingWork)
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
            //シークレット区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SecretCode
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //優良設定詳細名称１
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //優良設定詳細名称２
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //優良設定グループ
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetGroup
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
            //優良設定詳細名称２(工場向け)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForFac
            //優良設定詳細名称２(カーオーナー向け)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForCOw
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSettingWork)
            {
                PrmSettingWork temp = (PrmSettingWork)graph;

                SetPrmSettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSettingWork temp in lst)
                {
                    SetPrmSettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmSettingWorkメンバ数(publicプロパティ数)
        /// </summary>
        // UPD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
        //private const int currentMemberCount = 12;
        private const int currentMemberCount = 14;
        // UPD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<

        /// <summary>
        ///  PrmSettingWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmSettingWork(System.IO.BinaryWriter writer, PrmSettingWork temp)
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
            //シークレット区分
            writer.Write(temp.SecretCode);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //優良設定詳細名称１
            writer.Write(temp.PrmSetDtlName1);
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //優良設定詳細名称２
            writer.Write(temp.PrmSetDtlName2);
            //優良設定グループ
            writer.Write(temp.PrmSetGroup);
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
            //優良設定詳細名称２(工場向け)
            writer.Write(temp.PrmSetDtlName2ForFac);
            //優良設定詳細名称２(カーオーナー向け)
            writer.Write(temp.PrmSetDtlName2ForCOw);
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<

        }

        /// <summary>
        ///  PrmSettingWorkインスタンス取得
        /// </summary>
        /// <returns>PrmSettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmSettingWork GetPrmSettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmSettingWork temp = new PrmSettingWork();

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
            //シークレット区分
            temp.SecretCode = reader.ReadInt32();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //優良設定詳細名称１
            temp.PrmSetDtlName1 = reader.ReadString();
            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //優良設定詳細名称２
            temp.PrmSetDtlName2 = reader.ReadString();
            //優良設定グループ
            temp.PrmSetGroup = reader.ReadInt32();
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
            //優良設定詳細名称２(工場向け)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            //優良設定詳細名称２(カーオーナー向け)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();
            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<


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
        /// <returns>PrmSettingWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingWork temp = GetPrmSettingWork(reader, serInfo);
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
                    retValue = (PrmSettingWork[])lst.ToArray(typeof(PrmSettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

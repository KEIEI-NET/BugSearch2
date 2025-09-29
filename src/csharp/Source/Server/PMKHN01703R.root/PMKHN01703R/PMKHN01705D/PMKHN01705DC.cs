//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業商品在庫マスタ変換処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MeijiGoodsStockWork
    /// <summary>
    ///                      商品在庫変換処理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品在庫変換処理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/01/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MeijiGoodsStockWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>旧品番</summary>
        private string _oldGoodsNo = "";

        /// <summary>新品番</summary>
        private string _newGoodsNo = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        private string _wareCode = "";

        /// <summary>メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>エラー内容</summary>
        private string _errorMessage = "";

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>備考</summary>
        private string _outNote = "";

        /// <summary>マスタ区分</summary>
        private Int32 _mstDiv;

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

        /// public propaty name  :  OldGoodsNo
        /// <summary>旧品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }

        /// public propaty name  :  NewGoodsNo
        /// <summary>新品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewGoodsNo
        {
            get { return _newGoodsNo; }
            set { _newGoodsNo = value; }
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

        /// public propaty name  :  WareCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WareCode
        {
            get { return _wareCode; }
            set { _wareCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MstDiv
        /// <summary>マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MstDiv
        {
            get { return _mstDiv; }
            set { _mstDiv = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>エラー内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  OutNote
        /// <summary>備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutNote
        {
            get { return _outNote; }
            set { _outNote = value; }
        }

        /// <summary>
        /// 商品在庫変換処理ワークコンストラクタ
        /// </summary>
        /// <returns>MeijiGoodsStockWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MeijiGoodsStockWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MeijiGoodsStockWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MeijiGoodsStockWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MeijiGoodsStockWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MeijiGoodsStockWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MeijiGoodsStockWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MeijiGoodsStockWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MeijiGoodsStockWork || graph is ArrayList || graph is MeijiGoodsStockWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MeijiGoodsStockWork).FullName));

            if (graph != null && graph is MeijiGoodsStockWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MeijiGoodsStockWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MeijiGoodsStockWork[])graph).Length;
            }
            else if (graph is MeijiGoodsStockWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //旧品番
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //新品番
            serInfo.MemberInfo.Add(typeof(string)); //NewGoodsNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WareCode
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //マスタ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MstDiv
            //エラー内容
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //備考
            serInfo.MemberInfo.Add(typeof(string)); //OutNote


            serInfo.Serialize(writer, serInfo);
            if (graph is MeijiGoodsStockWork)
            {
                MeijiGoodsStockWork temp = (MeijiGoodsStockWork)graph;

                SetMeijiGoodsStockWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MeijiGoodsStockWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MeijiGoodsStockWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MeijiGoodsStockWork temp in lst)
                {
                    SetMeijiGoodsStockWork(writer, temp);
                }
            }


        }


        /// <summary>
        /// MeijiGoodsStockWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  MeijiGoodsStockWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MeijiGoodsStockWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMeijiGoodsStockWork(System.IO.BinaryWriter writer, MeijiGoodsStockWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //旧品番
            writer.Write(temp.OldGoodsNo);
            //新品番
            writer.Write(temp.NewGoodsNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //倉庫コード
            writer.Write(temp.WareCode);
            //メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //マスタ区分
            writer.Write(temp.MstDiv);
            //エラー内容
            writer.Write(temp.ErrorMessage);
            //価格開始日
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //備考
            writer.Write(temp.OutNote);

        }

        /// <summary>
        ///  MeijiGoodsStockWorkインスタンス取得
        /// </summary>
        /// <returns>MeijiGoodsStockWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MeijiGoodsStockWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MeijiGoodsStockWork GetMeijiGoodsStockWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MeijiGoodsStockWork temp = new MeijiGoodsStockWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //旧品番
            temp.OldGoodsNo = reader.ReadString();
            //新品番
            temp.NewGoodsNo = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //倉庫コード
            temp.WareCode = reader.ReadString();
            //メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //マスタ区分
            temp.MstDiv = reader.ReadInt32();
            //エラー内容
            temp.ErrorMessage = reader.ReadString();
            //価格開始日
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //備考
            temp.OutNote = reader.ReadString();


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
        /// <returns>MeijiGoodsStockWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MeijiGoodsStockWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MeijiGoodsStockWork temp = GetMeijiGoodsStockWork(reader, serInfo);
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
                    retValue = (MeijiGoodsStockWork[])lst.ToArray(typeof(MeijiGoodsStockWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }





}

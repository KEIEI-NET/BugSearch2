using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnGdsSearchParaWork
    /// <summary>
    ///                      検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   検索条件</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/01/19</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGdsSearchParaWork
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>メーカー（開始）</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカー（終了）</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>適用日開始日（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyDateSt;

        /// <summary>適用日開始日（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyDateEd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>削除指定区分</summary>
        private Int32 _deleteFlag;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
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


        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカー（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  ApplyDateSt
        /// <summary>公開開始日（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開開始日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyDateSt
        {
            get { return _applyDateSt; }
            set { _applyDateSt = value; }
        }

        /// public propaty name  :  ApplyDateEd
        /// <summary>公開開始日（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開開始日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyDateEd
        {
            get { return _applyDateEd; }
            set { _applyDateEd = value; }
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

        /// public propaty name  :  DeleteFlag
        /// <summary>削除指定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <returns>RecBgnGdsSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGdsSearchParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecBgnGdsSearchParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecBgnGdsSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGdsSearchParaWork || graph is ArrayList || graph is RecBgnGdsSearchParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnGdsSearchParaWork).FullName));

            if (graph != null && graph is RecBgnGdsSearchParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsSearchParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGdsSearchParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGdsSearchParaWork[])graph).Length;
            }
            else if (graph is RecBgnGdsSearchParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //メーカー（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
            //メーカー（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
            //公開開始日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenStartDateSt
            //公開開始日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenStartDateEd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //削除指定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeleteFlag

            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGdsSearchParaWork)
            {
                RecBgnGdsSearchParaWork temp = (RecBgnGdsSearchParaWork)graph;

                SetRecBgnGdsSearchParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGdsSearchParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGdsSearchParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGdsSearchParaWork temp in lst)
                {
                    SetRecBgnGdsSearchParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGdsSearchParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  RecBgnGdsSearchParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecBgnGdsSearchParaWork(System.IO.BinaryWriter writer, RecBgnGdsSearchParaWork temp)
        {

            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //メーカー（開始）
            writer.Write(temp.GoodsMakerCdSt);
            //メーカー（終了）
            writer.Write(temp.GoodsMakerCdEd);
            //公開日（開始）
            writer.Write(temp.ApplyDateSt);
            //公開日（終了）
            writer.Write(temp.ApplyDateEd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //削除指定区分
            writer.Write(temp.DeleteFlag);

        }

        /// <summary>
        ///  RecBgnGdsSearchParaWorkインスタンス取得
        /// </summary>
        /// <returns>RecBgnGdsSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecBgnGdsSearchParaWork GetRecBgnGdsSearchParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecBgnGdsSearchParaWork temp = new RecBgnGdsSearchParaWork();


            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //メーカー（開始）
            temp.GoodsMakerCdSt = reader.ReadInt32();
            //メーカー（終了）
            temp.GoodsMakerCdEd = reader.ReadInt32();
            //公開開始日（開始）
            temp.ApplyDateSt = reader.ReadInt32();
            //公開開始日（終了）
            temp.ApplyDateEd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //削除指定区分
            temp.DeleteFlag = reader.ReadInt32();


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
        /// <returns>RecBgnGdsSearchParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGdsSearchParaWork temp = GetRecBgnGdsSearchParaWork(reader, serInfo);
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
                    retValue = (RecBgnGdsSearchParaWork[])lst.ToArray(typeof(RecBgnGdsSearchParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

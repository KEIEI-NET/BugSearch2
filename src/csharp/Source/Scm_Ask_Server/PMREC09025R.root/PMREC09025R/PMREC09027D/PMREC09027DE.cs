//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検索条件（PM側）ワーク
// プログラム概要   : 検索条件（PM側）ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnGdsPMSearchParaWork
    /// <summary>
    ///                      検索条件（PM側）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   検索条件（PM側）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGdsPMSearchParaWork 
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

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
        /// <summary>作成日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  customerCode
        /// <summary>得意先コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 customerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  goodsMakerCdSt
        /// <summary>メーカー（開始）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 goodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  goodsMakerCdEd
        /// <summary>メーカー（終了）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 goodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  applyDateSt
        /// <summary>適用日開始日（開始）</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用日開始日（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 applyDateSt
        {
            get { return _applyDateSt; }
            set { _applyDateSt = value; }
        }

        /// public propaty name  :  applyDateEd
        /// <summary>適用日開始日（終了）</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用日開始日（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 applyDateEd
        {
            get { return _applyDateEd; }
            set { _applyDateEd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  deleteFlag
        /// <summary>削除指定区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 deleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }



        /// <summary>
        /// 検索条件（PM側）ワークコンストラクタ
        /// </summary>
        /// <returns>RecBgnGdsPMSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGdsPMSearchParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecBgnGdsPMSearchParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecBgnGdsPMSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGdsPMSearchParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGdsPMSearchParaWork || graph is ArrayList || graph is RecBgnGdsPMSearchParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnGdsPMSearchParaWork).FullName));

            if (graph != null && graph is RecBgnGdsPMSearchParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMSearchParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGdsPMSearchParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGdsPMSearchParaWork[])graph).Length;
            }
            else if (graph is RecBgnGdsPMSearchParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //customerCode
            //メーカー（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //goodsMakerCdSt
            //メーカー（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //goodsMakerCdEd
            //適用日開始日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //applyDateSt
            //適用日開始日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //applyDateEd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //削除指定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //deleteFlag



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGdsPMSearchParaWork)
            {
                RecBgnGdsPMSearchParaWork temp = (RecBgnGdsPMSearchParaWork)graph;

                SetRecBgnGdsPMSearchParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGdsPMSearchParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGdsPMSearchParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGdsPMSearchParaWork temp in lst)
                {
                    SetRecBgnGdsPMSearchParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGdsPMSearchParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  RecBgnGdsPMSearchParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecBgnGdsPMSearchParaWork(System.IO.BinaryWriter writer, RecBgnGdsPMSearchParaWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //得意先コード
            writer.Write((Int32)temp.customerCode);
            //メーカー（開始）
            writer.Write((Int32)temp.goodsMakerCdSt);
            //メーカー（終了）
            writer.Write((Int32)temp.goodsMakerCdEd);
            //適用日開始日（開始）
            writer.Write((Int32)temp.applyDateSt);
            //適用日開始日（終了）
            writer.Write((Int32)temp.applyDateEd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //削除指定区分
            writer.Write((Int32)temp.deleteFlag);


        }

        /// <summary>
        ///  RecBgnGdsPMSearchParaWorkインスタンス取得
        /// </summary>
        /// <returns>RecBgnGdsPMSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecBgnGdsPMSearchParaWork GetRecBgnGdsPMSearchParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecBgnGdsPMSearchParaWork temp = new RecBgnGdsPMSearchParaWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //得意先コード
            temp.customerCode = reader.ReadInt32();
            //メーカー（開始）
            temp.goodsMakerCdSt = reader.ReadInt32();
            //メーカー（終了）
            temp.goodsMakerCdEd = reader.ReadInt32();
            //適用日開始日（開始）
            temp.applyDateSt = reader.ReadInt32();
            //適用日開始日（終了）
            temp.applyDateEd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //削除指定区分
            temp.deleteFlag = reader.ReadInt32();



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
        /// <returns>RecBgnGdsPMSearchParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMSearchParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGdsPMSearchParaWork temp = GetRecBgnGdsPMSearchParaWork(reader, serInfo);
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
                    retValue = (RecBgnGdsPMSearchParaWork[])lst.ToArray(typeof(RecBgnGdsPMSearchParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

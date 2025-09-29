using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   JoinPartsWork
    /// <summary>
    ///                      結合ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/11/22</br>
    /// <br>Genarated Date   :   2009/06/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/3/26  杉村</br>
    /// <br>                 :   ・削除</br>
    /// <br>                 :   結合旧品番</br>
    /// <br>Update Note      :   2008/10/15  杉村</br>
    /// <br>                 :   ○型変更</br>
    /// <br>                 :   結合QTY（Int 3桁　⇒ Double 5桁）</br>
    /// <br>Update Note      :   2008/11/10  杉村</br>
    /// <br>                 :   ○NULL許可変更（すべて不可にする）</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class JoinPartsWork 
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>翼部品コード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>※セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithH = "";

        /// <summary>結合元品番(－無し品番)</summary>
        private string _joinSourPartsNoNoneH = "";

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合表示順位</summary>
        /// <remarks>2,3,5,6,7,8,10が同一の結合が複数存在する場合の連番</remarks>
        private Int32 _joinDispOrder;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合QTY</summary>
        private Double _joinQty;

        /// <summary>セット品番フラグ</summary>
        /// <remarks>0:セット品無し　1:セット品有り</remarks>
        private Int32 _setPartsFlg;

        /// <summary>結合規格・特記事項</summary>
        private string _joinSpecialNote = "";


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
        /// <value>※未使用項目（レイアウトには入れておく）</value>
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

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>※セレクトコード</value>
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

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
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

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>結合元品番(－無し品番)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDispOrder
        /// <summary>結合表示順位プロパティ</summary>
        /// <value>2,3,5,6,7,8,10が同一の結合が複数存在する場合の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>結合先品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>結合QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  SetPartsFlg
        /// <summary>セット品番フラグプロパティ</summary>
        /// <value>0:セット品無し　1:セット品有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット品番フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsFlg
        {
            get { return _setPartsFlg; }
            set { _setPartsFlg = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>結合規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
        }


        /// <summary>
        /// 結合ワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>JoinPartsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   JoinPartsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class JoinPartsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  JoinPartsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is JoinPartsWork || graph is ArrayList || graph is JoinPartsWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(JoinPartsWork).FullName));

            if (graph != null && graph is JoinPartsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.JoinPartsWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is JoinPartsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((JoinPartsWork[])graph).Length;
            }
            else if (graph is JoinPartsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //結合元メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
            //結合元品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
            //結合元品番(－無し品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
            //結合先メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //結合表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
            //結合先品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //結合QTY
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //セット品番フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsFlg
            //結合規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote


            serInfo.Serialize(writer, serInfo);
            if (graph is JoinPartsWork)
            {
                JoinPartsWork temp = (JoinPartsWork)graph;

                SetJoinPartsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is JoinPartsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((JoinPartsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (JoinPartsWork temp in lst)
                {
                    SetJoinPartsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// JoinPartsWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  JoinPartsWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetJoinPartsWork(System.IO.BinaryWriter writer, JoinPartsWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //結合元メーカーコード
            writer.Write(temp.JoinSourceMakerCode);
            //結合元品番(－付き品番)
            writer.Write(temp.JoinSourPartsNoWithH);
            //結合元品番(－無し品番)
            writer.Write(temp.JoinSourPartsNoNoneH);
            //結合先メーカーコード
            writer.Write(temp.JoinDestMakerCd);
            //結合表示順位
            writer.Write(temp.JoinDispOrder);
            //結合先品番(－付き品番)
            writer.Write(temp.JoinDestPartsNo);
            //結合QTY
            writer.Write(temp.JoinQty);
            //セット品番フラグ
            writer.Write(temp.SetPartsFlg);
            //結合規格・特記事項
            writer.Write(temp.JoinSpecialNote);

        }

        /// <summary>
        ///  JoinPartsWorkインスタンス取得
        /// </summary>
        /// <returns>JoinPartsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private JoinPartsWork GetJoinPartsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            JoinPartsWork temp = new JoinPartsWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //結合元メーカーコード
            temp.JoinSourceMakerCode = reader.ReadInt32();
            //結合元品番(－付き品番)
            temp.JoinSourPartsNoWithH = reader.ReadString();
            //結合元品番(－無し品番)
            temp.JoinSourPartsNoNoneH = reader.ReadString();
            //結合先メーカーコード
            temp.JoinDestMakerCd = reader.ReadInt32();
            //結合表示順位
            temp.JoinDispOrder = reader.ReadInt32();
            //結合先品番(－付き品番)
            temp.JoinDestPartsNo = reader.ReadString();
            //結合QTY
            temp.JoinQty = reader.ReadDouble();
            //セット品番フラグ
            temp.SetPartsFlg = reader.ReadInt32();
            //結合規格・特記事項
            temp.JoinSpecialNote = reader.ReadString();


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
        /// <returns>JoinPartsWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                JoinPartsWork temp = GetJoinPartsWork(reader, serInfo);
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
                    retValue = (JoinPartsWork[])lst.ToArray(typeof(JoinPartsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

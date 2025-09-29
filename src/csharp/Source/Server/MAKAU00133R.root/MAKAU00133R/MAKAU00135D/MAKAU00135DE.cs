using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthlyAddUpStatusWork
    /// <summary>
    ///                      月次更新有無パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   月次更新有無パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthlyAddUpStatusWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>入金伝票件数（通常入金）</summary>
        private Int32 _dmdNrmlSlipCnt;

        /// <summary>入金伝票件数（預り金）</summary>
        private Int32 _dmdDepoSlipCnt;

        /// <summary>売上伝票件数</summary>
        private Int32 _salesSlipCnt;

        /// <summary>支払インセンティブ件数</summary>
        private Int32 _incDstrbtCnt;

        /// <summary>支払伝票件数（通常支払）</summary>
        private Int32 _payNrmlSlipCnt;

        /// <summary>仕入伝票件数</summary>
        private Int32 _supplierSlipCnt;

        /// <summary>返品伝票件数</summary>
        private Int32 _retGoodsSlipCnt;

        /// <summary>更新ステータス</summary>
        /// <remarks>0:更新,1:未更新</remarks>
        private Int32 _updateStatus;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 自社締を行なった日（自社締め基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>月次更新実行年月日</summary>
        /// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
        private DateTime _monthAddUpExpDate;


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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SupplierCd
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

        /// public propaty name  :  DmdNrmlSlipCnt
        /// <summary>入金伝票件数（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票件数（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmdNrmlSlipCnt
        {
            get { return _dmdNrmlSlipCnt; }
            set { _dmdNrmlSlipCnt = value; }
        }

        /// public propaty name  :  DmdDepoSlipCnt
        /// <summary>入金伝票件数（預り金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票件数（預り金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmdDepoSlipCnt
        {
            get { return _dmdDepoSlipCnt; }
            set { _dmdDepoSlipCnt = value; }
        }

        /// public propaty name  :  SalesSlipCnt
        /// <summary>売上伝票件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCnt
        {
            get { return _salesSlipCnt; }
            set { _salesSlipCnt = value; }
        }

        /// public propaty name  :  IncDstrbtCnt
        /// <summary>支払インセンティブ件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払インセンティブ件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IncDstrbtCnt
        {
            get { return _incDstrbtCnt; }
            set { _incDstrbtCnt = value; }
        }

        /// public propaty name  :  PayNrmlSlipCnt
        /// <summary>支払伝票件数（通常支払）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票件数（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayNrmlSlipCnt
        {
            get { return _payNrmlSlipCnt; }
            set { _payNrmlSlipCnt = value; }
        }

        /// public propaty name  :  SupplierSlipCnt
        /// <summary>仕入伝票件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCnt
        {
            get { return _supplierSlipCnt; }
            set { _supplierSlipCnt = value; }
        }

        /// public propaty name  :  RetGoodsSlipCnt
        /// <summary>返品伝票件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品伝票件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetGoodsSlipCnt
        {
            get { return _retGoodsSlipCnt; }
            set { _retGoodsSlipCnt = value; }
        }

        /// public propaty name  :  UpdateStatus
        /// <summary>更新ステータスプロパティ</summary>
        /// <value>0:更新,1:未更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateStatus
        {
            get { return _updateStatus; }
            set { _updateStatus = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>月次更新実行年月日プロパティ</summary>
        /// <value>YYYYMMDD　月次更新実行年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }


        /// <summary>
        /// 月次更新有無パラメータワークコンストラクタ
        /// </summary>
        /// <returns>MonthlyAddUpStatusWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MonthlyAddUpStatusWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MonthlyAddUpStatusWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MonthlyAddUpStatusWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MonthlyAddUpStatusWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MonthlyAddUpStatusWork || graph is ArrayList || graph is MonthlyAddUpStatusWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MonthlyAddUpStatusWork).FullName));

            if (graph != null && graph is MonthlyAddUpStatusWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpStatusWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MonthlyAddUpStatusWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MonthlyAddUpStatusWork[])graph).Length;
            }
            else if (graph is MonthlyAddUpStatusWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //入金伝票件数（通常入金）
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdNrmlSlipCnt
            //入金伝票件数（預り金）
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDepoSlipCnt
            //売上伝票件数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCnt
            //支払インセンティブ件数
            serInfo.MemberInfo.Add(typeof(Int32)); //IncDstrbtCnt
            //支払伝票件数（通常支払）
            serInfo.MemberInfo.Add(typeof(Int32)); //PayNrmlSlipCnt
            //仕入伝票件数
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCnt
            //返品伝票件数
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsSlipCnt
            //更新ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateStatus
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //月次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate


            serInfo.Serialize(writer, serInfo);
            if (graph is MonthlyAddUpStatusWork)
            {
                MonthlyAddUpStatusWork temp = (MonthlyAddUpStatusWork)graph;

                SetMonthlyAddUpStatusWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MonthlyAddUpStatusWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MonthlyAddUpStatusWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MonthlyAddUpStatusWork temp in lst)
                {
                    SetMonthlyAddUpStatusWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MonthlyAddUpStatusWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  MonthlyAddUpStatusWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMonthlyAddUpStatusWork(System.IO.BinaryWriter writer, MonthlyAddUpStatusWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //入金伝票件数（通常入金）
            writer.Write(temp.DmdNrmlSlipCnt);
            //入金伝票件数（預り金）
            writer.Write(temp.DmdDepoSlipCnt);
            //売上伝票件数
            writer.Write(temp.SalesSlipCnt);
            //支払インセンティブ件数
            writer.Write(temp.IncDstrbtCnt);
            //支払伝票件数（通常支払）
            writer.Write(temp.PayNrmlSlipCnt);
            //仕入伝票件数
            writer.Write(temp.SupplierSlipCnt);
            //返品伝票件数
            writer.Write(temp.RetGoodsSlipCnt);
            //更新ステータス
            writer.Write(temp.UpdateStatus);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //月次更新実行年月日
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);

        }

        /// <summary>
        ///  MonthlyAddUpStatusWorkインスタンス取得
        /// </summary>
        /// <returns>MonthlyAddUpStatusWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MonthlyAddUpStatusWork GetMonthlyAddUpStatusWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MonthlyAddUpStatusWork temp = new MonthlyAddUpStatusWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //入金伝票件数（通常入金）
            temp.DmdNrmlSlipCnt = reader.ReadInt32();
            //入金伝票件数（預り金）
            temp.DmdDepoSlipCnt = reader.ReadInt32();
            //売上伝票件数
            temp.SalesSlipCnt = reader.ReadInt32();
            //支払インセンティブ件数
            temp.IncDstrbtCnt = reader.ReadInt32();
            //支払伝票件数（通常支払）
            temp.PayNrmlSlipCnt = reader.ReadInt32();
            //仕入伝票件数
            temp.SupplierSlipCnt = reader.ReadInt32();
            //返品伝票件数
            temp.RetGoodsSlipCnt = reader.ReadInt32();
            //更新ステータス
            temp.UpdateStatus = reader.ReadInt32();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //月次更新実行年月日
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());


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
        /// <returns>MonthlyAddUpStatusWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpStatusWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MonthlyAddUpStatusWork temp = GetMonthlyAddUpStatusWork(reader, serInfo);
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
                    retValue = (MonthlyAddUpStatusWork[])lst.ToArray(typeof(MonthlyAddUpStatusWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

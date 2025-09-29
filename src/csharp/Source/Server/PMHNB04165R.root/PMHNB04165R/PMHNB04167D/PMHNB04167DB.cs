using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// public class name:   EmployeeResultsListResultWork
    /// <summary>
    ///                      担当者別実績照会データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   担当者別実績照会データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EmployeeResultsListResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

        /// <summary>黒伝の売上伝票合計（税抜き）</summary>
        /// <remarks>黒伝の売上伝票合計（税抜き）</remarks>
        private Int64 _backSalesTotalTaxExc;

        /// <summary>返品伝票の売上伝票合計（税抜き）</summary>
        /// <remarks>返品伝票の売上伝票合計（税抜き）</remarks>
        private Int64 _retGoodSalesTotalTaxExc;

        /// <summary>黒伝の売上値引金額計（税抜き）</summary>
        /// <remarks>黒伝の売上値引金額計（税抜き）</remarks>
        private Int64 _backSalesDisTtlTaxExc;

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /// <summary>伝票枚数</summary>
        private Int32 _slipNumCount;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
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

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  BackSalesTotalTaxExc
        /// <summary>黒伝の売上伝票合計（税抜き）プロパティ</summary>
        /// <value>黒伝の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   黒伝の売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BackSalesTotalTaxExc
        {
            get { return _backSalesTotalTaxExc; }
            set { _backSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  RetGoodSalesTotalTaxExc
        /// <summary>返品伝票の売上伝票合計（税抜き）プロパティ</summary>
        /// <value>返品伝票の売上伝票合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品伝票の売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RetGoodSalesTotalTaxExc
        {
            get { return _retGoodSalesTotalTaxExc; }
            set { _retGoodSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  BackSalesDisTtlTaxExc
        /// <summary>黒伝の売上値引金額計（税抜き）プロパティ</summary>
        /// <value>黒伝の売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   黒伝の売上値引金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BackSalesDisTtlTaxExc
        {
            get { return _backSalesDisTtlTaxExc; }
            set { _backSalesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  SlipNumCount
        /// <summary>伝票枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNumCount
        {
            get { return _slipNumCount; }
            set { _slipNumCount = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }


        /// <summary>
        /// 担当者別実績照会データワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeResultsListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeResultsListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EmployeeResultsListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EmployeeResultsListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeResultsListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EmployeeResultsListResultWork || graph is ArrayList || graph is EmployeeResultsListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EmployeeResultsListResultWork).FullName));

            if (graph != null && graph is EmployeeResultsListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmployeeResultsListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EmployeeResultsListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EmployeeResultsListResultWork[])graph).Length;
            }
            else if (graph is EmployeeResultsListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //黒伝の売上伝票合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //BackSalesTotalTaxExc
            //返品伝票の売上伝票合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodSalesTotalTaxExc
            //黒伝の売上値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //BackSalesDisTtlTaxExc
            //売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNumCount
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is EmployeeResultsListResultWork)
            {
                EmployeeResultsListResultWork temp = (EmployeeResultsListResultWork)graph;

                SetEmployeeResultsListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EmployeeResultsListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EmployeeResultsListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EmployeeResultsListResultWork temp in lst)
                {
                    SetEmployeeResultsListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmployeeResultsListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  EmployeeResultsListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEmployeeResultsListResultWork(System.IO.BinaryWriter writer, EmployeeResultsListResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
            //黒伝の売上伝票合計（税抜き）
            writer.Write(temp.BackSalesTotalTaxExc);
            //返品伝票の売上伝票合計（税抜き）
            writer.Write(temp.RetGoodSalesTotalTaxExc);
            //黒伝の売上値引金額計（税抜き）
            writer.Write(temp.BackSalesDisTtlTaxExc);
            //売上目標金額
            writer.Write(temp.SalesTargetMoney);
            //原価金額計
            writer.Write(temp.TotalCost);
            //伝票枚数
            writer.Write(temp.SlipNumCount);
            //粗利金額
            writer.Write(temp.GrossProfit);

        }

        /// <summary>
        ///  EmployeeResultsListResultWorkインスタンス取得
        /// </summary>
        /// <returns>EmployeeResultsListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EmployeeResultsListResultWork GetEmployeeResultsListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EmployeeResultsListResultWork temp = new EmployeeResultsListResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();
            //黒伝の売上伝票合計（税抜き）
            temp.BackSalesTotalTaxExc = reader.ReadInt64();
            //返品伝票の売上伝票合計（税抜き）
            temp.RetGoodSalesTotalTaxExc = reader.ReadInt64();
            //黒伝の売上値引金額計（税抜き）
            temp.BackSalesDisTtlTaxExc = reader.ReadInt64();
            //売上目標金額
            temp.SalesTargetMoney = reader.ReadInt64();
            //原価金額計
            temp.TotalCost = reader.ReadInt64();
            //伝票枚数
            temp.SlipNumCount = reader.ReadInt32();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();


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
        /// <returns>EmployeeResultsListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeResultsListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EmployeeResultsListResultWork temp = GetEmployeeResultsListResultWork(reader, serInfo);
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
                    retValue = (EmployeeResultsListResultWork[])lst.ToArray(typeof(EmployeeResultsListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }




}

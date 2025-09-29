using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesReportResultWork
    /// <summary>
    ///                      売上速報表示抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上速報表示抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesReportResultWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>達成率（純売上）</summary>
        private Double _achievementRateNet;

        /// <summary>粗利</summary>
        private Int64 _grossMargin;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>達成率（粗利）</summary>
        private Double _achievementRateGross;

        /// <summary>稼働日</summary>
        /// <remarks>YYYMMDD</remarks>
        private Int32 _operationDay;

        // --- ADD chenyk 2014/02/21 ------>>>>>
        /// <summary>期間を含んだ月の稼働日</summary>
        /// <remarks>YYYMMDD</remarks>
        private Int32 _operationDayInRange;
        // --- ADD chenyk 2014/02/21 ------<<<<<

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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
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

        /// public propaty name  :  AchievementRateNet 
        /// <summary>達成率（純売上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   達成率（純売上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AchievementRateNet
        {
            get { return _achievementRateNet; }
            set { _achievementRateNet = value; }
        }

        /// public propaty name  :  GrossMargin
        /// <summary>粗利プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMargin
        {
            get { return _grossMargin; }
            set { _grossMargin = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  AchievementRateGross
        /// <summary>達成率（粗利）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   達成率（粗利）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AchievementRateGross
        {
            get { return _achievementRateGross; }
            set { _achievementRateGross = value; }
        }

        /// public propaty name  :  OperationDay
        /// <summary>稼働日プロパティ</summary>
        /// <value>YYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   稼働日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OperationDay
        {
            get { return _operationDay; }
            set { _operationDay = value; }
        }

        // --- ADD chenyk 2014/02/21 ------>>>>>
        /// public propaty name  :  OperationDayInRange
        /// <summary>期間を含んだ月の稼働日プロパティ</summary>
        /// <value>YYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間を含んだ月の稼働日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OperationDayInRange
        {
            get { return _operationDayInRange; }
            set { _operationDayInRange = value; }
        }
        // --- ADD chenyk 2014/02/21 ------<<<<<

        /// <summary>
        /// 売上速報表示抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesReportResultWork || graph is ArrayList || graph is SalesReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesReportResultWork).FullName));

            if (graph != null && graph is SalesReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesReportResultWork[])graph).Length;
            }
            else if (graph is SalesReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //達成率（純売上）
            serInfo.MemberInfo.Add(typeof(double)); //AchievementRateNet 
            //粗利
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMargin
            //売上目標粗利額
            serInfo.MemberInfo.Add(typeof(double)); //SalesTargetProfit
            //達成率（粗利）
            serInfo.MemberInfo.Add(typeof(Int64)); //AchievementRateGross
            //稼働日
            serInfo.MemberInfo.Add(typeof(Int32)); //OperationDay
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //期間を含んだ月の稼働日
            serInfo.MemberInfo.Add(typeof(Int32)); //OperationDayInRange
            // --- ADD chenyk 2014/02/21 ------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesReportResultWork)
            {
                SalesReportResultWork temp = (SalesReportResultWork)graph;

                SetSalesReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesReportResultWork temp in lst)
                {
                    SetSalesReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 10; // DEL chenyk 2014/02/21
        private const int currentMemberCount = 11; // ADD chenyk 2014/02/21

        /// <summary>
        ///  SalesReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesReportResultWork(System.IO.BinaryWriter writer, SalesReportResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //売上伝票合計（税抜き）
            writer.Write(temp.SalesTotalTaxExc);
            //売上目標金額
            writer.Write(temp.SalesTargetMoney);
            //達成率（純売上）
            writer.Write(temp.AchievementRateNet);
            //粗利
            writer.Write(temp.GrossMargin);
            //売上目標粗利額
            writer.Write(temp.SalesTargetProfit);
            //達成率（粗利）
            writer.Write(temp.AchievementRateGross);
            //稼働日
            writer.Write(temp.OperationDay);
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //期間を含んだ月の稼働日
            writer.Write(temp.OperationDayInRange);
            // --- ADD chenyk 2014/02/21 ------<<<<<

        }

        /// <summary>
        ///  SalesReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesReportResultWork GetSalesReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesReportResultWork temp = new SalesReportResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //売上伝票合計（税抜き）
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //売上目標金額
            temp.SalesTargetMoney = reader.ReadInt64();
            //達成率（純売上）
            temp.AchievementRateNet = reader.ReadDouble();
            //粗利
            temp.GrossMargin = reader.ReadInt64();
            //売上目標粗利額
            temp.SalesTargetProfit = reader.ReadInt64();
            //達成率（粗利）
            temp.AchievementRateGross = reader.ReadDouble();
            //稼働日
            temp.OperationDay = reader.ReadInt32();
            // --- ADD chenyk 2014/02/21 ------>>>>>
            //期間を含んだ月の稼働日
            temp.OperationDayInRange = reader.ReadInt32();
            // --- ADD chenyk 2014/02/21 ------<<<<<


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
        /// <returns>SalesReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesReportResultWork temp = GetSalesReportResultWork(reader, serInfo);
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
                    retValue = (SalesReportResultWork[])lst.ToArray(typeof(SalesReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
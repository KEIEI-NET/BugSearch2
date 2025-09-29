using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_PastYearStatisticsWork
    /// <summary>
    ///                      過年度統計表抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   過年度統計表抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_PastYearStatisticsWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        private string _sectionGuideNm = "";

        /// <summary>得意先コード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        private string _customerSnm = "";

        /// <summary>売上額(1年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney1;

        /// <summary>粗利額(1年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney1;

        /// <summary>売上額(2年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney2;

        /// <summary>粗利額(2年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney2;

        /// <summary>売上額(3年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney3;

        /// <summary>粗利額(3年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney3;

        /// <summary>売上額(4年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney4;

        /// <summary>粗利額(4年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney4;

        /// <summary>売上額(5年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney5;

        /// <summary>粗利額(5年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney5;

        /// <summary>売上額(6年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney6;

        /// <summary>粗利額(6年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney6;

        /// <summary>売上額(7年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney7;

        /// <summary>粗利額(7年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney7;

        /// <summary>売上額(8年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _salesMoney8;

        /// <summary>粗利額(8年目)</summary>
        /// <remarks>「千円単位」時は1000で割って小数点を四捨五入した値</remarks>
        private Int64 _grossMoney8;


        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>それぞれの月次集計データから取得</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>それぞれの月次集計データから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>それぞれの月次集計データから取得</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// <value>それぞれの月次集計データから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesMoney1
        /// <summary>売上額(1年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(1年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney1
        {
            get { return _salesMoney1; }
            set { _salesMoney1 = value; }
        }

        /// public propaty name  :  GrossMoney1
        /// <summary>粗利額(1年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(1年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney1
        {
            get { return _grossMoney1; }
            set { _grossMoney1 = value; }
        }

        /// public propaty name  :  SalesMoney2
        /// <summary>売上額(2年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(2年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney2
        {
            get { return _salesMoney2; }
            set { _salesMoney2 = value; }
        }

        /// public propaty name  :  GrossMoney2
        /// <summary>粗利額(2年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(2年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney2
        {
            get { return _grossMoney2; }
            set { _grossMoney2 = value; }
        }

        /// public propaty name  :  SalesMoney3
        /// <summary>売上額(3年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(3年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney3
        {
            get { return _salesMoney3; }
            set { _salesMoney3 = value; }
        }

        /// public propaty name  :  GrossMoney3
        /// <summary>粗利額(3年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(3年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney3
        {
            get { return _grossMoney3; }
            set { _grossMoney3 = value; }
        }

        /// public propaty name  :  SalesMoney4
        /// <summary>売上額(4年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(4年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney4
        {
            get { return _salesMoney4; }
            set { _salesMoney4 = value; }
        }

        /// public propaty name  :  GrossMoney4
        /// <summary>粗利額(4年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(4年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney4
        {
            get { return _grossMoney4; }
            set { _grossMoney4 = value; }
        }

        /// public propaty name  :  SalesMoney5
        /// <summary>売上額(5年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(5年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney5
        {
            get { return _salesMoney5; }
            set { _salesMoney5 = value; }
        }

        /// public propaty name  :  GrossMoney5
        /// <summary>粗利額(5年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(5年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney5
        {
            get { return _grossMoney5; }
            set { _grossMoney5 = value; }
        }

        /// public propaty name  :  SalesMoney6
        /// <summary>売上額(6年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(6年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney6
        {
            get { return _salesMoney6; }
            set { _salesMoney6 = value; }
        }

        /// public propaty name  :  GrossMoney6
        /// <summary>粗利額(6年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(6年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney6
        {
            get { return _grossMoney6; }
            set { _grossMoney6 = value; }
        }

        /// public propaty name  :  SalesMoney7
        /// <summary>売上額(7年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(7年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney7
        {
            get { return _salesMoney7; }
            set { _salesMoney7 = value; }
        }

        /// public propaty name  :  GrossMoney7
        /// <summary>粗利額(7年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(7年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney7
        {
            get { return _grossMoney7; }
            set { _grossMoney7 = value; }
        }

        /// public propaty name  :  SalesMoney8
        /// <summary>売上額(8年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(8年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney8
        {
            get { return _salesMoney8; }
            set { _salesMoney8 = value; }
        }

        /// public propaty name  :  GrossMoney8
        /// <summary>粗利額(8年目)プロパティ</summary>
        /// <value>「千円単位」時は1000で割って小数点を四捨五入した値</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額(8年目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossMoney8
        {
            get { return _grossMoney8; }
            set { _grossMoney8 = value; }
        }


        /// <summary>
        /// 過年度統計表抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_PastYearStatisticsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_PastYearStatisticsWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_PastYearStatisticsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_PastYearStatisticsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_PastYearStatisticsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_PastYearStatisticsWork || graph is ArrayList || graph is RsltInfo_PastYearStatisticsWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_PastYearStatisticsWork).FullName));

            if (graph != null && graph is RsltInfo_PastYearStatisticsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_PastYearStatisticsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_PastYearStatisticsWork[])graph).Length;
            }
            else if (graph is RsltInfo_PastYearStatisticsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //売上額(1年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney1
            //粗利額(1年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney1
            //売上額(2年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney2
            //粗利額(2年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney2
            //売上額(3年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney3
            //粗利額(3年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney3
            //売上額(4年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney4
            //粗利額(4年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney4
            //売上額(5年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney5
            //粗利額(5年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney5
            //売上額(6年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney6
            //粗利額(6年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney6
            //売上額(7年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney7
            //粗利額(7年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney7
            //売上額(8年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney8
            //粗利額(8年目)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney8


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_PastYearStatisticsWork)
            {
                RsltInfo_PastYearStatisticsWork temp = (RsltInfo_PastYearStatisticsWork)graph;

                SetRsltInfo_PastYearStatisticsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_PastYearStatisticsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_PastYearStatisticsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_PastYearStatisticsWork temp in lst)
                {
                    SetRsltInfo_PastYearStatisticsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_PastYearStatisticsWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  RsltInfo_PastYearStatisticsWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_PastYearStatisticsWork(System.IO.BinaryWriter writer, RsltInfo_PastYearStatisticsWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //売上額(1年目)
            writer.Write(temp.SalesMoney1);
            //粗利額(1年目)
            writer.Write(temp.GrossMoney1);
            //売上額(2年目)
            writer.Write(temp.SalesMoney2);
            //粗利額(2年目)
            writer.Write(temp.GrossMoney2);
            //売上額(3年目)
            writer.Write(temp.SalesMoney3);
            //粗利額(3年目)
            writer.Write(temp.GrossMoney3);
            //売上額(4年目)
            writer.Write(temp.SalesMoney4);
            //粗利額(4年目)
            writer.Write(temp.GrossMoney4);
            //売上額(5年目)
            writer.Write(temp.SalesMoney5);
            //粗利額(5年目)
            writer.Write(temp.GrossMoney5);
            //売上額(6年目)
            writer.Write(temp.SalesMoney6);
            //粗利額(6年目)
            writer.Write(temp.GrossMoney6);
            //売上額(7年目)
            writer.Write(temp.SalesMoney7);
            //粗利額(7年目)
            writer.Write(temp.GrossMoney7);
            //売上額(8年目)
            writer.Write(temp.SalesMoney8);
            //粗利額(8年目)
            writer.Write(temp.GrossMoney8);

        }

        /// <summary>
        ///  RsltInfo_PastYearStatisticsWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_PastYearStatisticsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_PastYearStatisticsWork GetRsltInfo_PastYearStatisticsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_PastYearStatisticsWork temp = new RsltInfo_PastYearStatisticsWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //売上額(1年目)
            temp.SalesMoney1 = reader.ReadInt64();
            //粗利額(1年目)
            temp.GrossMoney1 = reader.ReadInt64();
            //売上額(2年目)
            temp.SalesMoney2 = reader.ReadInt64();
            //粗利額(2年目)
            temp.GrossMoney2 = reader.ReadInt64();
            //売上額(3年目)
            temp.SalesMoney3 = reader.ReadInt64();
            //粗利額(3年目)
            temp.GrossMoney3 = reader.ReadInt64();
            //売上額(4年目)
            temp.SalesMoney4 = reader.ReadInt64();
            //粗利額(4年目)
            temp.GrossMoney4 = reader.ReadInt64();
            //売上額(5年目)
            temp.SalesMoney5 = reader.ReadInt64();
            //粗利額(5年目)
            temp.GrossMoney5 = reader.ReadInt64();
            //売上額(6年目)
            temp.SalesMoney6 = reader.ReadInt64();
            //粗利額(6年目)
            temp.GrossMoney6 = reader.ReadInt64();
            //売上額(7年目)
            temp.SalesMoney7 = reader.ReadInt64();
            //粗利額(7年目)
            temp.GrossMoney7 = reader.ReadInt64();
            //売上額(8年目)
            temp.SalesMoney8 = reader.ReadInt64();
            //粗利額(8年目)
            temp.GrossMoney8 = reader.ReadInt64();


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
        /// <returns>RsltInfo_PastYearStatisticsWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PastYearStatisticsWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PastYearStatisticsWork temp = GetRsltInfo_PastYearStatisticsWork(reader, serInfo);
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
                    retValue = (RsltInfo_PastYearStatisticsWork[])lst.ToArray(typeof(RsltInfo_PastYearStatisticsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

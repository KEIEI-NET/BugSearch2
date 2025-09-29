using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TaxRateSetWork
    /// <summary>
    ///                      税率設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   税率設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/05/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TaxRateSetWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>税率コード</summary>
        /// <remarks>0:一般消費税,1:諸費用消費税</remarks>
        private Int32 _taxRateCode;

        /// <summary>税率固有名称</summary>
        /// <remarks>税率コード固有の名称(変更不可)</remarks>
        private string _taxRateProperNounNm = "";

        /// <summary>税率名称</summary>
        private string _taxRateName = "";

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>税率開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate;

        /// <summary>税率終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate;

        /// <summary>税率</summary>
        private Double _taxRate;

        /// <summary>税率開始日2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate2;

        /// <summary>税率終了日2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate2;

        /// <summary>税率2</summary>
        private Double _taxRate2;

        /// <summary>税率開始日3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate3;

        /// <summary>税率終了日3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate3;

        /// <summary>税率3</summary>
        private Double _taxRate3;


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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  TaxRateCode
        /// <summary>税率コードプロパティ</summary>
        /// <value>0:一般消費税,1:諸費用消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxRateCode
        {
            get { return _taxRateCode; }
            set { _taxRateCode = value; }
        }

        /// public propaty name  :  TaxRateProperNounNm
        /// <summary>税率固有名称プロパティ</summary>
        /// <value>税率コード固有の名称(変更不可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率固有名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRateProperNounNm
        {
            get { return _taxRateProperNounNm; }
            set { _taxRateProperNounNm = value; }
        }

        /// public propaty name  :  TaxRateName
        /// <summary>税率名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRateName
        {
            get { return _taxRateName; }
            set { _taxRateName = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TaxRateStartDate
        /// <summary>税率開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateStartDate
        {
            get { return _taxRateStartDate; }
            set { _taxRateStartDate = value; }
        }

        /// public propaty name  :  TaxRateEndDate
        /// <summary>税率終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateEndDate
        {
            get { return _taxRateEndDate; }
            set { _taxRateEndDate = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  TaxRateStartDate2
        /// <summary>税率開始日2プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率開始日2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateStartDate2
        {
            get { return _taxRateStartDate2; }
            set { _taxRateStartDate2 = value; }
        }

        /// public propaty name  :  TaxRateEndDate2
        /// <summary>税率終了日2プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率終了日2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateEndDate2
        {
            get { return _taxRateEndDate2; }
            set { _taxRateEndDate2 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }

        /// public propaty name  :  TaxRateStartDate3
        /// <summary>税率開始日3プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率開始日3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateStartDate3
        {
            get { return _taxRateStartDate3; }
            set { _taxRateStartDate3 = value; }
        }

        /// public propaty name  :  TaxRateEndDate3
        /// <summary>税率終了日3プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率終了日3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TaxRateEndDate3
        {
            get { return _taxRateEndDate3; }
            set { _taxRateEndDate3 = value; }
        }

        /// public propaty name  :  TaxRate3
        /// <summary>税率3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate3
        {
            get { return _taxRate3; }
            set { _taxRate3 = value; }
        }


        /// <summary>
        /// 税率設定ワークコンストラクタ
        /// </summary>
        /// <returns>TaxRateSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TaxRateSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TaxRateSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TaxRateSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TaxRateSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TaxRateSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TaxRateSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TaxRateSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TaxRateSetWork || graph is ArrayList || graph is TaxRateSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TaxRateSetWork).FullName));

            if (graph != null && graph is TaxRateSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TaxRateSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TaxRateSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TaxRateSetWork[])graph).Length;
            }
            else if (graph is TaxRateSetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //税率コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateCode
            //税率固有名称
            serInfo.MemberInfo.Add(typeof(string)); //TaxRateProperNounNm
            //税率名称
            serInfo.MemberInfo.Add(typeof(string)); //TaxRateName
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //税率開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate
            //税率終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate
            //税率
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate
            //税率開始日2
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate2
            //税率終了日2
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate2
            //税率2
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate2
            //税率開始日3
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate3
            //税率終了日3
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate3
            //税率3
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate3


            serInfo.Serialize(writer, serInfo);
            if (graph is TaxRateSetWork)
            {
                TaxRateSetWork temp = (TaxRateSetWork)graph;

                SetTaxRateSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TaxRateSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TaxRateSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TaxRateSetWork temp in lst)
                {
                    SetTaxRateSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TaxRateSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  TaxRateSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TaxRateSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTaxRateSetWork(System.IO.BinaryWriter writer, TaxRateSetWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //税率コード
            writer.Write(temp.TaxRateCode);
            //税率固有名称
            writer.Write(temp.TaxRateProperNounNm);
            //税率名称
            writer.Write(temp.TaxRateName);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //税率開始日
            writer.Write((Int64)temp.TaxRateStartDate.Ticks);
            //税率終了日
            writer.Write((Int64)temp.TaxRateEndDate.Ticks);
            //税率
            writer.Write(temp.TaxRate);
            //税率開始日2
            writer.Write((Int64)temp.TaxRateStartDate2.Ticks);
            //税率終了日2
            writer.Write((Int64)temp.TaxRateEndDate2.Ticks);
            //税率2
            writer.Write(temp.TaxRate2);
            //税率開始日3
            writer.Write((Int64)temp.TaxRateStartDate3.Ticks);
            //税率終了日3
            writer.Write((Int64)temp.TaxRateEndDate3.Ticks);
            //税率3
            writer.Write(temp.TaxRate3);

        }

        /// <summary>
        ///  TaxRateSetWorkインスタンス取得
        /// </summary>
        /// <returns>TaxRateSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TaxRateSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TaxRateSetWork GetTaxRateSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TaxRateSetWork temp = new TaxRateSetWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //税率コード
            temp.TaxRateCode = reader.ReadInt32();
            //税率固有名称
            temp.TaxRateProperNounNm = reader.ReadString();
            //税率名称
            temp.TaxRateName = reader.ReadString();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //税率開始日
            temp.TaxRateStartDate = new DateTime(reader.ReadInt64());
            //税率終了日
            temp.TaxRateEndDate = new DateTime(reader.ReadInt64());
            //税率
            temp.TaxRate = reader.ReadDouble();
            //税率開始日2
            temp.TaxRateStartDate2 = new DateTime(reader.ReadInt64());
            //税率終了日2
            temp.TaxRateEndDate2 = new DateTime(reader.ReadInt64());
            //税率2
            temp.TaxRate2 = reader.ReadDouble();
            //税率開始日3
            temp.TaxRateStartDate3 = new DateTime(reader.ReadInt64());
            //税率終了日3
            temp.TaxRateEndDate3 = new DateTime(reader.ReadInt64());
            //税率3
            temp.TaxRate3 = reader.ReadDouble();


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
        /// <returns>TaxRateSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TaxRateSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TaxRateSetWork temp = GetTaxRateSetWork(reader, serInfo);
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
                    retValue = (TaxRateSetWork[])lst.ToArray(typeof(TaxRateSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

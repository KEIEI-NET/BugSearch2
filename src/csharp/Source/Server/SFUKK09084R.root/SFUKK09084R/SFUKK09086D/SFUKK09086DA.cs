using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BillPrtStWork
    /// <summary>
    ///                      請求印刷設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求印刷設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/06/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BillPrtStWork : IFileHeader
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

        /// <summary>請求印刷設定管理コード</summary>
        /// <remarks>常にゼロ固定</remarks>
        private Int32 _billPrtStMngCd;

        /// <summary>請求一覧表出力区分</summary>
        /// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり</remarks>
        private Int32 _billTableOutCd;

        /// <summary>合計請求書出力区分</summary>
        /// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり(請求書（鑑）出力区分)</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>明細請求書出力区分</summary>
        /// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>請求書末日印字区分</summary>
        /// <remarks>0:数値印字,1:28～31日は末日と印字</remarks>
        private Int32 _billLastDayPrtDiv;

        /// <summary>請求書自社名印字区分</summary>
        /// <remarks>0:印字する,1:印字しない</remarks>
        private Int32 _billCoNmPrintOutCd;

        /// <summary>請求書銀行名印字区分</summary>
        /// <remarks>0:印字する,1:印字しない</remarks>
        private Int32 _billBankNmPrintOut;

        /// <summary>得意先電話番号印字区分</summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        private Int32 _custTelNoPrtDivCd;


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

        /// public propaty name  :  BillPrtStMngCd
        /// <summary>請求印刷設定管理コードプロパティ</summary>
        /// <value>常にゼロ固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求印刷設定管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillPrtStMngCd
        {
            get { return _billPrtStMngCd; }
            set { _billPrtStMngCd = value; }
        }

        /// public propaty name  :  BillTableOutCd
        /// <summary>請求一覧表出力区分プロパティ</summary>
        /// <value>0:全て出力,1:0とプラス金額･･･つづきあり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求一覧表出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillTableOutCd
        {
            get { return _billTableOutCd; }
            set { _billTableOutCd = value; }
        }

        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>合計請求書出力区分プロパティ</summary>
        /// <value>0:全て出力,1:0とプラス金額･･･つづきあり(請求書（鑑）出力区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>明細請求書出力区分プロパティ</summary>
        /// <value>0:全て出力,1:0とプラス金額･･･つづきあり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  BillLastDayPrtDiv
        /// <summary>請求書末日印字区分プロパティ</summary>
        /// <value>0:数値印字,1:28～31日は末日と印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書末日印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillLastDayPrtDiv
        {
            get { return _billLastDayPrtDiv; }
            set { _billLastDayPrtDiv = value; }
        }

        /// public propaty name  :  BillCoNmPrintOutCd
        /// <summary>請求書自社名印字区分プロパティ</summary>
        /// <value>0:印字する,1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書自社名印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillCoNmPrintOutCd
        {
            get { return _billCoNmPrintOutCd; }
            set { _billCoNmPrintOutCd = value; }
        }

        /// public propaty name  :  BillBankNmPrintOut
        /// <summary>請求書銀行名印字区分プロパティ</summary>
        /// <value>0:印字する,1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書銀行名印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillBankNmPrintOut
        {
            get { return _billBankNmPrintOut; }
            set { _billBankNmPrintOut = value; }
        }

        /// public propaty name  :  CustTelNoPrtDivCd
        /// <summary>得意先電話番号印字区分プロパティ</summary>
        /// <value>0:印字しない,1:印字する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先電話番号印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustTelNoPrtDivCd
        {
            get { return _custTelNoPrtDivCd; }
            set { _custTelNoPrtDivCd = value; }
        }


        /// <summary>
        /// 請求印刷設定ワークコンストラクタ
        /// </summary>
        /// <returns>BillPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillPrtStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BillPrtStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>BillPrtStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   BillPrtStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class BillPrtStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillPrtStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BillPrtStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BillPrtStWork || graph is ArrayList || graph is BillPrtStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(BillPrtStWork).FullName));

            if (graph != null && graph is BillPrtStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BillPrtStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BillPrtStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BillPrtStWork[])graph).Length;
            }
            else if (graph is BillPrtStWork)
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
            //請求印刷設定管理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPrtStMngCd
            //請求一覧表出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BillTableOutCd
            //合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalBillOutputDiv
            //明細請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailBillOutputCode
            //請求書末日印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BillLastDayPrtDiv
            //請求書自社名印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BillCoNmPrintOutCd
            //請求書銀行名印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BillBankNmPrintOut
            //得意先電話番号印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustTelNoPrtDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is BillPrtStWork)
            {
                BillPrtStWork temp = (BillPrtStWork)graph;

                SetBillPrtStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BillPrtStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BillPrtStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BillPrtStWork temp in lst)
                {
                    SetBillPrtStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BillPrtStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  BillPrtStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillPrtStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetBillPrtStWork(System.IO.BinaryWriter writer, BillPrtStWork temp)
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
            //請求印刷設定管理コード
            writer.Write(temp.BillPrtStMngCd);
            //請求一覧表出力区分
            writer.Write(temp.BillTableOutCd);
            //合計請求書出力区分
            writer.Write(temp.TotalBillOutputDiv);
            //明細請求書出力区分
            writer.Write(temp.DetailBillOutputCode);
            //請求書末日印字区分
            writer.Write(temp.BillLastDayPrtDiv);
            //請求書自社名印字区分
            writer.Write(temp.BillCoNmPrintOutCd);
            //請求書銀行名印字区分
            writer.Write(temp.BillBankNmPrintOut);
            //得意先電話番号印字区分
            writer.Write(temp.CustTelNoPrtDivCd);

        }

        /// <summary>
        ///  BillPrtStWorkインスタンス取得
        /// </summary>
        /// <returns>BillPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillPrtStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private BillPrtStWork GetBillPrtStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            BillPrtStWork temp = new BillPrtStWork();

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
            //請求印刷設定管理コード
            temp.BillPrtStMngCd = reader.ReadInt32();
            //請求一覧表出力区分
            temp.BillTableOutCd = reader.ReadInt32();
            //合計請求書出力区分
            temp.TotalBillOutputDiv = reader.ReadInt32();
            //明細請求書出力区分
            temp.DetailBillOutputCode = reader.ReadInt32();
            //請求書末日印字区分
            temp.BillLastDayPrtDiv = reader.ReadInt32();
            //請求書自社名印字区分
            temp.BillCoNmPrintOutCd = reader.ReadInt32();
            //請求書銀行名印字区分
            temp.BillBankNmPrintOut = reader.ReadInt32();
            //得意先電話番号印字区分
            temp.CustTelNoPrtDivCd = reader.ReadInt32();


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
        /// <returns>BillPrtStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillPrtStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BillPrtStWork temp = GetBillPrtStWork(reader, serInfo);
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
                    retValue = (BillPrtStWork[])lst.ToArray(typeof(BillPrtStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

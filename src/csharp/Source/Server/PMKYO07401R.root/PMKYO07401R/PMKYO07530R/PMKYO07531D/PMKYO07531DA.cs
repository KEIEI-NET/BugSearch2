//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcceptOdrWork
    /// <summary>
    ///                      受注ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2009/03/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCAcceptOdrWork : IFileHeader
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>受注ステータス</summary>
        /// <remarks>1:見積,2:発注,3:受注,4:入荷,5:出荷
        ///6:仕入,7:売上,8:入金,9:支払
        ///10:入荷返品,11:出荷返品,12:仕入返品,13:売上返品</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>伝票番号</summary>
        /// <remarks>それぞれの伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>データ入力システム</summary>
        /// <remarks>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </remarks>
        private Int32 _dataInputSystem;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>明細通番</summary>
        private Int64 _slipDtlNum;

        /// <summary>明細通番枝番</summary>
        private Int32 _slipDtlNumDerivNo;

        /// <summary>連携元データ区分</summary>
        private Int32 _srcLinkDataCode;

        /// <summary>連携元明細通番</summary>
        private Int64 _srcSlipDtlNum;


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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>1:見積,2:発注,3:受注,4:入荷,5:出荷
        ///6:仕入,7:売上,8:入金,9:支払
        ///10:入荷返品,11:出荷返品,12:仕入返品,13:売上返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>伝票番号プロパティ</summary>
        /// <value>それぞれの伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// <value>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SlipDtlNum
        /// <summary>明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SlipDtlNum
        {
            get { return _slipDtlNum; }
            set { _slipDtlNum = value; }
        }

        /// public propaty name  :  SlipDtlNumDerivNo
        /// <summary>明細通番枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細通番枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDtlNumDerivNo
        {
            get { return _slipDtlNumDerivNo; }
            set { _slipDtlNumDerivNo = value; }
        }

        /// public propaty name  :  SrcLinkDataCode
        /// <summary>連携元データ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携元データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SrcLinkDataCode
        {
            get { return _srcLinkDataCode; }
            set { _srcLinkDataCode = value; }
        }

        /// public propaty name  :  SrcSlipDtlNum
        /// <summary>連携元明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携元明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SrcSlipDtlNum
        {
            get { return _srcSlipDtlNum; }
            set { _srcSlipDtlNum = value; }
        }


        /// <summary>
        /// 受注ワークコンストラクタ
        /// </summary>
        /// <returns>AcceptOdrWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DCAcceptOdrWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AcceptOdrWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AcceptOdrWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DCAcceptOdrWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AcceptOdrWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCAcceptOdrWork || graph is ArrayList || graph is DCAcceptOdrWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCAcceptOdrWork).FullName));

            if (graph != null && graph is DCAcceptOdrWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DCAcceptOdrWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCAcceptOdrWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCAcceptOdrWork[])graph).Length;
            }
            else if (graph is DCAcceptOdrWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //データ入力システム
            serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SlipDtlNum
            //明細通番枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDtlNumDerivNo
            //連携元データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SrcLinkDataCode
            //連携元明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SrcSlipDtlNum


            serInfo.Serialize(writer, serInfo);
            if (graph is DCAcceptOdrWork)
            {
                DCAcceptOdrWork temp = (DCAcceptOdrWork)graph;

                SetAcceptOdrWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCAcceptOdrWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCAcceptOdrWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCAcceptOdrWork temp in lst)
                {
                    SetAcceptOdrWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AcceptOdrWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  AcceptOdrWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAcceptOdrWork(System.IO.BinaryWriter writer, DCAcceptOdrWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //伝票番号
            writer.Write(temp.SalesSlipNum);
            //データ入力システム
            writer.Write(temp.DataInputSystem);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //明細通番
            writer.Write(temp.SlipDtlNum);
            //明細通番枝番
            writer.Write(temp.SlipDtlNumDerivNo);
            //連携元データ区分
            writer.Write(temp.SrcLinkDataCode);
            //連携元明細通番
            writer.Write(temp.SrcSlipDtlNum);

        }

        /// <summary>
        ///  AcceptOdrWorkインスタンス取得
        /// </summary>
        /// <returns>AcceptOdrWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DCAcceptOdrWork GetAcceptOdrWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DCAcceptOdrWork temp = new DCAcceptOdrWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //データ入力システム
            temp.DataInputSystem = reader.ReadInt32();
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //明細通番
            temp.SlipDtlNum = reader.ReadInt64();
            //明細通番枝番
            temp.SlipDtlNumDerivNo = reader.ReadInt32();
            //連携元データ区分
            temp.SrcLinkDataCode = reader.ReadInt32();
            //連携元明細通番
            temp.SrcSlipDtlNum = reader.ReadInt64();


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
        /// <returns>AcceptOdrWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCAcceptOdrWork temp = GetAcceptOdrWork(reader, serInfo);
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
                    retValue = (DCAcceptOdrWork[])lst.ToArray(typeof(DCAcceptOdrWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}


//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP連携マスタ設定
// プログラム概要   : TSP連携マスタ設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TspCprtStWork
    /// <summary>
    /// TSP連携マスタ設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>Note             :   TSP連携マスタ設定ワークヘッダファイル</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date             :   2020/11/23</br>
    /// <br>依頼番号         :   11670305-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TspCprtStWork : IFileHeader
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary> 送信区分</summary>
        private Int32 _sendCode;

        /// <summary>赤伝送信区分</summary>
        /// <remarks>0:する；1:しない</remarks>
        private Int32 _debitNSendCode;

        /// <summary>送信企業コード</summary>
        /// <remarks>TSP送信先企業コード</remarks>
        private string _sendEnterpriseCode = "";

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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>得意先コード</value>
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

        /// public propaty name  :  SendCode
        /// <summary>送信区分プロパティ</summary>
        /// <value>0:自動（伝票作成時に送信）,1:一括（手動送信画面で送信）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendCode
        {
            get { return _sendCode; }
            set { _sendCode = value; }
        }

        /// public propaty name  :  DebitNSendCode
        /// <summary>赤伝送信区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNSendCode
        {
            get { return _debitNSendCode; }
            set { _debitNSendCode = value; }
        }

        /// public propaty name  :  SendEnterpriseCode
        /// <summary>送信企業コードプロパティ</summary>
        /// <value>TSP送信先企業コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendEnterpriseCode
        {
            get { return _sendEnterpriseCode; }
            set { _sendEnterpriseCode = value; }
        }

        /// public propaty name : UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note : 更新日時 和暦(略)プロパティ</br>
        /// <br>Programer : 自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// <summary>
        /// TSP連携マスタ設定ワークコンストラクタ
        /// </summary>
        /// <returns>TspCprtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TspCprtStWork()
        {
        }

        /// <summary>
        /// TSP連携マスタ設定コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sendCode">送信区分</param>
        /// <param name="debitNSendCode">赤伝送信区分</param>
        /// <param name="sendEnterpriseCode">送信企業コード</param>
        /// <returns>TspCprtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   SecOrderAutoStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TspCprtStWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int32 sendCode, Int32 debitNSendCode, string sendEnterpriseCode)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._sendCode = sendCode;
            this._debitNSendCode = debitNSendCode;
            this._sendEnterpriseCode = sendEnterpriseCode;
        }

        /// <summary>
        /// TSP連携マスタ設定複製処理
        /// </summary>
        /// <returns>TspCprtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   自身の内容と等しいTspCprtStWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TspCprtStWork Clone()
        {
            return new TspCprtStWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._sendCode, this._debitNSendCode, this._sendEnterpriseCode);
        }

        /// <summary>
        /// TSP連携マスタ設定比較処理
        /// </summary>
        /// <param name="target">比較対象のSecOrderAutoStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        : 自動生成</br>
        /// </remarks>
        public bool Equals(TspCprtStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SendCode == target.SendCode)
                 && (this.DebitNSendCode == target.DebitNSendCode)
                 && (this.SendEnterpriseCode == target.SendEnterpriseCode));
                 
        }

        /// <summary>
        /// TSP連携マスタ設定比較処理
        /// </summary>
        /// <param name="tspCprtSt1">
        /// 比較するTspCprtStWorkクラスのインスタンス
        /// </param>
        /// <param name="tspCprtSt2">比較するTspCprtStWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        : 自動生成</br>
        /// </remarks>
        public static bool Equals(TspCprtStWork tspCprtSt1, TspCprtStWork tspCprtSt2)
        {
            return ((tspCprtSt1.CreateDateTime == tspCprtSt2.CreateDateTime)
                           && (tspCprtSt1.UpdateDateTime == tspCprtSt2.UpdateDateTime)
                           && (tspCprtSt1.EnterpriseCode == tspCprtSt2.EnterpriseCode)
                           && (tspCprtSt1.FileHeaderGuid == tspCprtSt2.FileHeaderGuid)
                           && (tspCprtSt1.UpdEmployeeCode == tspCprtSt2.UpdEmployeeCode)
                           && (tspCprtSt1.UpdAssemblyId1 == tspCprtSt2.UpdAssemblyId1)
                           && (tspCprtSt1.UpdAssemblyId2 == tspCprtSt2.UpdAssemblyId2)
                           && (tspCprtSt1.LogicalDeleteCode == tspCprtSt2.LogicalDeleteCode)
                           && (tspCprtSt1.CustomerCode == tspCprtSt2.CustomerCode)
                           && (tspCprtSt1.SendCode == tspCprtSt2.SendCode)
                           && (tspCprtSt1.DebitNSendCode == tspCprtSt2.DebitNSendCode)
                           && (tspCprtSt1.SendEnterpriseCode == tspCprtSt2.SendEnterpriseCode));
        }
        /// <summary>
        /// TSP連携マスタ設定比較処理
        /// </summary>
        /// <param name="target">比較対象のTspCprtStWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        : 自動生成</br>
        /// </remarks>
        public ArrayList Compare(TspCprtStWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SendCode != target.SendCode) resList.Add("SendCode");
            if (this.DebitNSendCode != target.DebitNSendCode) resList.Add("DebitNSendCode");
            if (this.SendEnterpriseCode != target.SendEnterpriseCode) resList.Add("SendEnterpriseCode");

            return resList;
        }

        /// <summary>
        /// TSP連携マスタ設定比較処理
        /// </summary>
        /// <param name="tspCprtSt1">比較するTspCprtStクラスのインスタンス</param>
        /// <param name="tspCprtSt2">比較するTspCprtStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(TspCprtStWork tspCprtSt1, TspCprtStWork tspCprtSt2)
        {
            ArrayList resList = new ArrayList();
            if (tspCprtSt1.CreateDateTime != tspCprtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (tspCprtSt1.UpdateDateTime != tspCprtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (tspCprtSt1.EnterpriseCode != tspCprtSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (tspCprtSt1.FileHeaderGuid != tspCprtSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (tspCprtSt1.UpdEmployeeCode != tspCprtSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (tspCprtSt1.UpdAssemblyId1 != tspCprtSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (tspCprtSt1.UpdAssemblyId2 != tspCprtSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (tspCprtSt1.LogicalDeleteCode != tspCprtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (tspCprtSt1.CustomerCode != tspCprtSt2.CustomerCode) resList.Add("CustomerCode");
            if (tspCprtSt1.SendCode != tspCprtSt2.SendCode) resList.Add("SendCode");
            if (tspCprtSt1.DebitNSendCode != tspCprtSt2.DebitNSendCode) resList.Add("DebitNSendCode");
            if (tspCprtSt1.SendEnterpriseCode != tspCprtSt2.SendEnterpriseCode) resList.Add("SendEnterpriseCode");
            
            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TspCprtStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note             :   TspCprtStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TspCprtStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note             :   TspCprtStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TspCprtStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TspCprtStWork || graph is ArrayList || graph is TspCprtStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TspCprtStWork).FullName));

            if (graph != null && graph is TspCprtStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            // SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork");

            // 繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     // 一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TspCprtStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TspCprtStWork[])graph).Length;
            }
            else if (graph is TspCprtStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;         // 繰り返し数    
            // 作成日時
            serInfo.MemberInfo.Add(typeof(Int64));   // CreateDateTime
            // 更新日時
            serInfo.MemberInfo.Add(typeof(Int64));   // UpdateDateTime
            // 企業コード
            serInfo.MemberInfo.Add(typeof(string));  // EnterpriseCode
            // GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  // FileHeaderGuid
            // 更新従業員コード
            serInfo.MemberInfo.Add(typeof(string));  // UpdEmployeeCode
            // 更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string));  // UpdAssemblyId1
            // 更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string));  // UpdAssemblyId2
            // 論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32));   // LogicalDeleteCode
            // 得意先コード
            serInfo.MemberInfo.Add(typeof(Int32));   // CustomerCode
            // 送信区分
            serInfo.MemberInfo.Add(typeof(Int32));   // SendCode
            // 赤伝送信区分
            serInfo.MemberInfo.Add(typeof(Int32));   // DebitNSendCode
            // 送信企業コード
            serInfo.MemberInfo.Add(typeof(string));  // SendEnterpriseCode
            
            serInfo.Serialize(writer, serInfo);
            if (graph is TspCprtStWork)
            {
                TspCprtStWork temp = (TspCprtStWork)graph;
                SetTspCprtStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TspCprtStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TspCprtStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TspCprtStWork temp in lst)
                {
                    SetTspCprtStWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// TspCprtStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  TspCprtStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note             :   TspCprtStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTspCprtStWork(System.IO.BinaryWriter writer, TspCprtStWork temp)
        {
            // 作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            // 更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            // 企業コード
            writer.Write(temp.EnterpriseCode);
            // GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            // 更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            // 更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            // 更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            // 論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            // 得意先コード
            writer.Write(temp.CustomerCode);
            // 送信区分
            writer.Write(temp.SendCode);
            // 赤伝送信区分
            writer.Write(temp.DebitNSendCode);
            // 送信企業コード
            writer.Write(temp.SendEnterpriseCode);
            
        }

        /// <summary>
        ///  TspCprtStWorkインスタンス取得
        /// </summary>
        /// <returns>TspCprtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note       :   TspCprtStWorkのインスタンスを取得します</br>
        /// <br>Programer  :   自動生成</br>
        /// </remarks>
        private TspCprtStWork GetTspCprtStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TspCprtStWork temp = new TspCprtStWork();

            // 作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            // 更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            // 企業コード
            temp.EnterpriseCode = reader.ReadString();
            // GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            // 更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            // 更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            // 更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            // 論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            // 得意先コード
            temp.CustomerCode = reader.ReadInt32();
            // 送信区分
            temp.SendCode = reader.ReadInt32();
            // 赤伝送信区分
            temp.DebitNSendCode = reader.ReadInt32();
            // 送信企業コード
            temp.SendEnterpriseCode = reader.ReadString();

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
        /// <returns>TspCprtStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TspCprtStWork temp = GetTspCprtStWork(reader, serInfo);
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
                    retValue = (TspCprtStWork[])lst.ToArray(typeof(TspCprtStWork));
                    break;
            }
            return retValue;
        }
        #endregion
    }
}
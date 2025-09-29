using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SyncReqDataWork
    /// <summary>
    ///                      同期要求データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   同期要求データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/11</br>
    /// <br>Genarated Date   :   2014/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SyncReqDataWork : IFileHeader
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

        /// <summary>同期要求区分</summary>
        /// <remarks>0:INSERT 1:UPDATE 2:DELETE</remarks>
        private Int32 _syncReqDiv;

        /// <summary>トランザクションID</summary>
        private Int64 _transctId;

        /// <summary>シンク対象テーブルID</summary>
        private string _syncTableID = "";

        /// <summary>同期対象区分</summary>
        /// <remarks>0:行単位、1:表単位　2：表単位(初回同期)</remarks>
        private Int32 _syncTargetDiv;
        
        /// <summary>同期処理区分</summary>
        /// <remarks>0:即時、1:バッチ</remarks>
        private Int32 _syncProcDiv;

        /// <summary>同期対象レコード　キー項目ID</summary>
        /// <remarks>対象テーブルのプライマリーキーの各項目IDをタブ区切り文字列に変換した文字列</remarks>
        private string _syncObjRecKeyItmId = "";

        /// <summary>同期対象レコード　キー値</summary>
        /// <remarks>対象レコードのプライマリーキーの各項目の値をタブ区切り文字列に変換された文字列</remarks>
        private string _syncObjRecKeyVal = "";

        /// <summary>同期対象レコード　更新項目ID</summary>
        /// <remarks>更新対象の項目ID（タブ区切り文字列）</remarks>
        private string _syncObjRecUpdItmId = "";

        /// <summary>同期対象レコード　更新　値</summary>
        /// <remarks>更新対象の項目の値（タブ区切り文字列）</remarks>
        private string _syncObjRecUpdVal = "";

        /// <summary>同期実行結果</summary>
        /// <remarks>0:未同期 1:同期処理中 2:同期失敗</remarks>
        private Int32 _syncExecRslt;

        /// <summary>再試行回数</summary>
        private Int32 _retryCount;

        /// <summary>エラーステータス</summary>
        private Int32 _errorStatus;

        /// <summary>エラー内容</summary>
        private string _errorContents = "";

        /// <summary>データ件数</summary>
        private Int32 _syncDataCount;

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

        /// public propaty name  :  SyncReqDiv
        /// <summary>同期要求区分プロパティ</summary>
        /// <value>0:INSERT 1:UPDATE 2:DELETE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期要求区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncReqDiv
        {
            get { return _syncReqDiv; }
            set { _syncReqDiv = value; }
        }

        /// public propaty name  :  TransctId
        /// <summary>トランザクションIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トランザクションIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TransctId
        {
            get { return _transctId; }
            set { _transctId = value; }
        }

        /// public propaty name  :  SyncTableID
        /// <summary>シンク対象テーブルIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク対象テーブルIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncTableID
        {
            get { return _syncTableID; }
            set { _syncTableID = value; }
        }

        /// public propaty name  :  SyncTargetDiv
        /// <summary>同期対象区分プロパティ</summary>
        /// <value>0:行単位、1:表単位　2：表単位(初回同期)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncTargetDiv
        {
            get { return _syncTargetDiv; }
            set { _syncTargetDiv = value; }
        }

        /// public propaty name  :  SyncProcDiv
        /// <summary>同期処理区分プロパティ</summary>
        /// <value>0:即時、1:バッチ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncProcDiv
        {
            get { return _syncProcDiv; }
            set { _syncProcDiv = value; }
        }

        /// public propaty name  :  SyncObjRecKeyItmId
        /// <summary>同期対象レコード　キー項目IDプロパティ</summary>
        /// <value>対象テーブルのプライマリーキーの各項目IDをタブ区切り文字列に変換した文字列</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期対象レコード　キー項目IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncObjRecKeyItmId
        {
            get { return _syncObjRecKeyItmId; }
            set { _syncObjRecKeyItmId = value; }
        }

        /// public propaty name  :  SyncObjRecKeyVal
        /// <summary>同期対象レコード　キー値プロパティ</summary>
        /// <value>対象レコードのプライマリーキーの各項目の値をタブ区切り文字列に変換された文字列</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期対象レコード　キー値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncObjRecKeyVal
        {
            get { return _syncObjRecKeyVal; }
            set { _syncObjRecKeyVal = value; }
        }

        /// public propaty name  :  SyncObjRecUpdItmId
        /// <summary>同期対象レコード　更新項目IDプロパティ</summary>
        /// <value>更新対象の項目ID（タブ区切り文字列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期対象レコード　更新項目IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncObjRecUpdItmId
        {
            get { return _syncObjRecUpdItmId; }
            set { _syncObjRecUpdItmId = value; }
        }

        /// public propaty name  :  SyncObjRecUpdVal
        /// <summary>同期対象レコード　更新　値プロパティ</summary>
        /// <value>更新対象の項目の値（タブ区切り文字列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期対象レコード　更新　値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncObjRecUpdVal
        {
            get { return _syncObjRecUpdVal; }
            set { _syncObjRecUpdVal = value; }
        }

        /// public propaty name  :  SyncExecRslt
        /// <summary>同期実行結果プロパティ</summary>
        /// <value>0:未同期 1:同期処理中 2:同期失敗</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期実行結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncExecRslt
        {
            get { return _syncExecRslt; }
            set { _syncExecRslt = value; }
        }

        /// public propaty name  :  RetryCount
        /// <summary>再試行回数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   再試行回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetryCount
        {
            get { return _retryCount; }
            set { _retryCount = value; }
        }

        /// public propaty name  :  ErrorStatus
        /// <summary>エラーステータスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// public propaty name  :  ErrorContents
        /// <summary>エラー内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorContents
        {
            get { return _errorContents; }
            set { _errorContents = value; }
        }

        /// public propaty name  :  SyncDataCount
        /// <summary>データ件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncDataCount
        {
            get { return _syncDataCount; }
            set { _syncDataCount = value; }
        }

        /// <summary>
        /// 同期要求データワークコンストラクタ
        /// </summary>
        /// <returns>SyncReqDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SyncReqDataWork()
        {
        }

        /// <summary>
        /// 同期要求データワーク複製処理
        /// </summary>
        /// <returns>SyncReqDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSyncReqDataWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SyncReqDataWork Clone()
        {
            return new SyncReqDataWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._syncReqDiv, this._transctId, this._syncTableID, this._syncTargetDiv, this._syncProcDiv, this._syncObjRecKeyItmId, this._syncObjRecKeyVal, this._syncObjRecUpdItmId, this._syncObjRecUpdVal, this._syncExecRslt, this._retryCount, this._errorStatus, this._errorContents, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._syncDataCount);
        }

        /// <summary>
        /// 同期要求データワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="syncReqDiv">同期要求区分(0:INSERT 1:UPDATE 2:DELETE)</param>
        /// <param name="transctId">トランザクションID</param>
        /// <param name="syncTableID">シンク対象テーブルID</param>
        /// <param name="syncTargetDiv">同期対象区分(0:行単位、1:表単位　2：表単位(初回同期))</param>
        /// <param name="syncObjRecKeyItmId">同期対象レコード　キー項目ID(対象テーブルのプライマリーキーの各項目IDをタブ区切り文字列に変換した文字列)</param>
        /// <param name="syncObjRecKeyVal">同期対象レコード　キー値(対象レコードのプライマリーキーの各項目の値をタブ区切り文字列に変換された文字列)</param>
        /// <param name="syncObjRecUpdItmId">同期対象レコード　更新項目ID(更新対象の項目ID（タブ区切り文字列）)</param>
        /// <param name="syncObjRecUpdVal">同期対象レコード　更新　値(更新対象の項目の値（タブ区切り文字列）)</param>
        /// <param name="syncExecRslt">同期実行結果(0:未同期 1:同期処理中 2:同期失敗)</param>
        /// <param name="retryCount">再試行回数</param>
        /// <param name="errorStatus">エラーステータス</param>
        /// <param name="errorContents">エラー内容</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// /// <param name="syncDataCount">データ件数</param>
        /// <returns>SyncReqDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SyncReqDataWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, Int32 syncReqDiv, Int64 transctId, string syncTableID, Int32 syncTargetDiv, Int32 syncProcDiv, string syncObjRecKeyItmId, string syncObjRecKeyVal, string syncObjRecUpdItmId, string syncObjRecUpdVal, Int32 syncExecRslt, Int32 retryCount, Int32 errorStatus, string errorContents, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 syncDataCount)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._syncReqDiv = syncReqDiv;
            this._transctId = transctId;
            this._syncTableID = syncTableID;
            this._syncTargetDiv = syncTargetDiv;
            this._syncProcDiv = syncProcDiv;
            this._syncObjRecKeyItmId = syncObjRecKeyItmId;
            this._syncObjRecKeyVal = syncObjRecKeyVal;
            this._syncObjRecUpdItmId = syncObjRecUpdItmId;
            this._syncObjRecUpdVal = syncObjRecUpdVal;
            this._syncExecRslt = syncExecRslt;
            this._retryCount = retryCount;
            this._errorStatus = errorStatus;
            this._errorContents = errorContents;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._syncDataCount = syncDataCount;

        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SyncReqDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SyncReqDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SyncReqDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SyncReqDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SyncReqDataWork || graph is ArrayList || graph is SyncReqDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SyncReqDataWork).FullName));

            if (graph != null && graph is SyncReqDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SyncReqDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SyncReqDataWork[])graph).Length;
            }
            else if (graph is SyncReqDataWork)
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
            //同期要求区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncReqDiv
            //トランザクションID
            serInfo.MemberInfo.Add(typeof(Int64)); //TransctId
            //シンク対象テーブルID
            serInfo.MemberInfo.Add(typeof(string)); //SyncTableID
            //同期対象区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncTargetDiv
            //同期処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncProcDiv
            //同期対象レコード　キー項目ID
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecKeyItmId
            //同期対象レコード　キー値
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecKeyVal
            //同期対象レコード　更新項目ID
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecUpdItmId
            //同期対象レコード　更新　値
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecUpdVal
            //同期実行結果
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncExecRslt
            //再試行回数
            serInfo.MemberInfo.Add(typeof(Int32)); //RetryCount
            //エラーステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorStatus
            //エラー内容
            serInfo.MemberInfo.Add(typeof(string)); //ErrorContents
            //データ件数
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncDataCount


            serInfo.Serialize(writer, serInfo);
            if (graph is SyncReqDataWork)
            {
                SyncReqDataWork temp = (SyncReqDataWork)graph;

                SetSyncReqDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SyncReqDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SyncReqDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SyncReqDataWork temp in lst)
                {
                    SetSyncReqDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SyncReqDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 22;

        /// <summary>
        ///  SyncReqDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSyncReqDataWork(System.IO.BinaryWriter writer, SyncReqDataWork temp)
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
            //同期要求区分
            writer.Write(temp.SyncReqDiv);
            //トランザクションID
            writer.Write(temp.TransctId);
            //シンク対象テーブルID
            writer.Write(temp.SyncTableID);
            //同期対象区分
            writer.Write(temp.SyncTargetDiv);
            //同期処理区分
            writer.Write(temp.SyncProcDiv);
            //同期対象レコード　キー項目ID
            writer.Write(temp.SyncObjRecKeyItmId);
            //同期対象レコード　キー値
            writer.Write(temp.SyncObjRecKeyVal);
            //同期対象レコード　更新項目ID
            writer.Write(temp.SyncObjRecUpdItmId);
            //同期対象レコード　更新　値
            writer.Write(temp.SyncObjRecUpdVal);
            //同期実行結果
            writer.Write(temp.SyncExecRslt);
            //再試行回数
            writer.Write(temp.RetryCount);
            //エラーステータス
            writer.Write(temp.ErrorStatus);
            //エラー内容
            writer.Write(temp.ErrorContents);
            //データ件数
            writer.Write(temp.SyncDataCount);

        }

        /// <summary>
        ///  SyncReqDataWorkインスタンス取得
        /// </summary>
        /// <returns>SyncReqDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SyncReqDataWork GetSyncReqDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SyncReqDataWork temp = new SyncReqDataWork();

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
            //同期要求区分
            temp.SyncReqDiv = reader.ReadInt32();
            //トランザクションID
            temp.TransctId = reader.ReadInt64();
            //シンク対象テーブルID
            temp.SyncTableID = reader.ReadString();
            //同期対象区分
            temp.SyncTargetDiv = reader.ReadInt32();
            //同期処理区分
            temp.SyncProcDiv = reader.ReadInt32();
            //同期対象レコード　キー項目ID
            temp.SyncObjRecKeyItmId = reader.ReadString();
            //同期対象レコード　キー値
            temp.SyncObjRecKeyVal = reader.ReadString();
            //同期対象レコード　更新項目ID
            temp.SyncObjRecUpdItmId = reader.ReadString();
            //同期対象レコード　更新　値
            temp.SyncObjRecUpdVal = reader.ReadString();
            //同期実行結果
            temp.SyncExecRslt = reader.ReadInt32();
            //再試行回数
            temp.RetryCount = reader.ReadInt32();
            //エラーステータス
            temp.ErrorStatus = reader.ReadInt32();
            //エラー内容
            temp.ErrorContents = reader.ReadString();
            //データ件数
            temp.SyncDataCount = reader.ReadInt32();


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
        /// <returns>SyncReqDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SyncReqDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SyncReqDataWork temp = GetSyncReqDataWork(reader, serInfo);
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
                    retValue = (SyncReqDataWork[])lst.ToArray(typeof(SyncReqDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

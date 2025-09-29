//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/10  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecMngSet
    /// <summary>
    ///                      拠点管理設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点管理設定マスタヘッダファイル</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SecMngSet
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

        /// <summary>種別</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _kind;

        /// <summary>受信状況</summary>
        /// <remarks>0:送信 1:受信</remarks>
        private Int32 _receiveCondition;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>シンク実行日付</summary>
        /// <remarks>最終送信日</remarks>
        private DateTime _syncExecDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

		/// <summary>送信先拠点コード</summary>
		private string _sendDestSecCode = "";

		/// <summary>自動送信区分</summary>
		/// <remarks>0：自動送信する、1：自動送信しない</remarks>
		private Int32 _autoSendDiv;

		/// <summary>送信済データ修正区分</summary>
		/// <remarks>0：修正可、1：修正不可</remarks>//DEL 2011/11/10 xupz
        /// <remarks>0：修正可、1：修正不可（送信実行日以前）、2：修正不可（伝票日付以前</remarks>//ADD 2011/11/10 xupz
		private Int32 _sndFinDataEdDiv;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   李占川</br>
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
        /// <br>Programer        :   李占川</br>
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
        /// <br>Programer        :   李占川</br>
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
        /// <br>Programer        :   李占川</br>
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
        /// <br>Programer        :   李占川</br>
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
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>種別プロパティ</summary>
        /// <value>0:データ　1:マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   種別プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// public propaty name  :  ReceiveCondition
        /// <summary>受信状況プロパティ</summary>
        /// <value>0:送信 1:受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信状況プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public Int32 ReceiveCondition
        {
            get { return _receiveCondition; }
            set { _receiveCondition = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SyncExecDate
        /// <summary>シンク実行日付プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public DateTime SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
        }

        /// public propaty name  :  SyncExecDateJpFormal
        /// <summary>シンク実行日付 和暦プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付 和暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SyncExecDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateJpInFormal
        /// <summary>シンク実行日付 和暦(略)プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SyncExecDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateAdFormal
        /// <summary>シンク実行日付 西暦プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付 西暦プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SyncExecDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateAdInFormal
        /// <summary>シンク実行日付 西暦(略)プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SyncExecDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


		/// public propaty name  :  SendDestSecCode
		/// <summary>送信先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   送信先拠点コードプロパティ</br>
		/// </remarks>
		public string SendDestSecCode
		{
			get { return _sendDestSecCode; }
			set { _sendDestSecCode = value; }
		}

		/// public propaty name  :  AutoSendDiv
		/// <summary>自動送信区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動送信区分プロパティ</br>
		/// </remarks>
		public Int32 AutoSendDiv
		{
			get { return _autoSendDiv; }
			set { _autoSendDiv = value; }
		}

		/// public propaty name  :  SndFinDataEdDiv
		/// <summary>送信済データ修正区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   送信済データ修正区分プロパティ</br>
		/// </remarks>
		public Int32 SndFinDataEdDiv
		{
			get { return _sndFinDataEdDiv; }
			set { _sndFinDataEdDiv = value; }
		}

        /// <summary>
        /// 拠点管理設定マスタコンストラクタ
        /// </summary>
        /// <returns>SecMngSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public SecMngSet()
        {
        }

        /// <summary>
        /// 拠点管理設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="kind">種別(0:データ　1:マスタ)</param>
        /// <param name="receiveCondition">受信状況(0:送信 1:受信)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="syncExecDate">シンク実行日付(最終送信日)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="sendDestSecCode">送信先拠点コード</param>
		/// <param name="autoSendDiv">自動送信区分</param>
		/// <param name="sndFinDataEdDiv">送信済データ修正区分</param>
        /// <returns>SecMngSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
		public SecMngSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 kind, Int32 receiveCondition, string sectionCode, DateTime syncExecDate, string enterpriseName, string updEmployeeName, string sendDestSecCode, Int32 autoSendDiv, Int32 sndFinDataEdDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._kind = kind;
            this._receiveCondition = receiveCondition;
            this._sectionCode = sectionCode;
            this.SyncExecDate = syncExecDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
			this._sendDestSecCode = sendDestSecCode;
			this._autoSendDiv = autoSendDiv;
			this._sndFinDataEdDiv = sndFinDataEdDiv;
        }

        /// <summary>
        /// 拠点管理設定マスタ複製処理
        /// </summary>
        /// <returns>SecMngSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecMngSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public SecMngSet Clone()
        {
			return new SecMngSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._kind, this._receiveCondition, this._sectionCode, this._syncExecDate, this._enterpriseName, this._updEmployeeName, this._sendDestSecCode, this._autoSendDiv, this._sndFinDataEdDiv);
        }

        /// <summary>
        /// 拠点管理設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSecMngSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public bool Equals(SecMngSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.Kind == target.Kind)
                 && (this.ReceiveCondition == target.ReceiveCondition)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SyncExecDate == target.SyncExecDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
			     && (this.SendDestSecCode == target.SendDestSecCode)
			     && (this.AutoSendDiv == target.AutoSendDiv)
			     && (this.SndFinDataEdDiv == target.SndFinDataEdDiv)
				 );
        }

        /// <summary>
        /// 拠点管理設定マスタ比較処理
        /// </summary>
        /// <param name="secMngSet1">
        ///                    比較するSecMngSetクラスのインスタンス
        /// </param>
        /// <param name="secMngSet2">比較するSecMngSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public static bool Equals(SecMngSet secMngSet1, SecMngSet secMngSet2)
        {
            return ((secMngSet1.CreateDateTime == secMngSet2.CreateDateTime)
                 && (secMngSet1.UpdateDateTime == secMngSet2.UpdateDateTime)
                 && (secMngSet1.EnterpriseCode == secMngSet2.EnterpriseCode)
                 && (secMngSet1.FileHeaderGuid == secMngSet2.FileHeaderGuid)
                 && (secMngSet1.UpdEmployeeCode == secMngSet2.UpdEmployeeCode)
                 && (secMngSet1.UpdAssemblyId1 == secMngSet2.UpdAssemblyId1)
                 && (secMngSet1.UpdAssemblyId2 == secMngSet2.UpdAssemblyId2)
                 && (secMngSet1.LogicalDeleteCode == secMngSet2.LogicalDeleteCode)
                 && (secMngSet1.Kind == secMngSet2.Kind)
                 && (secMngSet1.ReceiveCondition == secMngSet2.ReceiveCondition)
                 && (secMngSet1.SectionCode == secMngSet2.SectionCode)
                 && (secMngSet1.SyncExecDate == secMngSet2.SyncExecDate)
                 && (secMngSet1.EnterpriseName == secMngSet2.EnterpriseName)
                 && (secMngSet1.UpdEmployeeName == secMngSet2.UpdEmployeeName)
				 && (secMngSet1.SendDestSecCode == secMngSet2.SendDestSecCode)
				 && (secMngSet1.AutoSendDiv == secMngSet2.AutoSendDiv)
				 && (secMngSet1.SndFinDataEdDiv == secMngSet2.SndFinDataEdDiv)
				 );
        }
        /// <summary>
        /// 拠点管理設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSecMngSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public ArrayList Compare(SecMngSet target)
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
            if (this.Kind != target.Kind) resList.Add("Kind");
            if (this.ReceiveCondition != target.ReceiveCondition) resList.Add("ReceiveCondition");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SyncExecDate != target.SyncExecDate) resList.Add("SyncExecDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (this.SendDestSecCode != target.SendDestSecCode) resList.Add("SendDestSecCode");
			if (this.AutoSendDiv != target.AutoSendDiv) resList.Add("AutoSendDiv");
			if (this.SndFinDataEdDiv != target.SndFinDataEdDiv) resList.Add("SndFinDataEdDiv");

            return resList;
        }

        /// <summary>
        /// 拠点管理設定マスタ比較処理
        /// </summary>
        /// <param name="secMngSet1">比較するSecMngSetクラスのインスタンス</param>
        /// <param name="secMngSet2">比較するSecMngSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public static ArrayList Compare(SecMngSet secMngSet1, SecMngSet secMngSet2)
        {
            ArrayList resList = new ArrayList();
            if (secMngSet1.CreateDateTime != secMngSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (secMngSet1.UpdateDateTime != secMngSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secMngSet1.EnterpriseCode != secMngSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secMngSet1.FileHeaderGuid != secMngSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secMngSet1.UpdEmployeeCode != secMngSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secMngSet1.UpdAssemblyId1 != secMngSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secMngSet1.UpdAssemblyId2 != secMngSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secMngSet1.LogicalDeleteCode != secMngSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secMngSet1.Kind != secMngSet2.Kind) resList.Add("Kind");
            if (secMngSet1.ReceiveCondition != secMngSet2.ReceiveCondition) resList.Add("ReceiveCondition");
            if (secMngSet1.SectionCode != secMngSet2.SectionCode) resList.Add("SectionCode");
            if (secMngSet1.SyncExecDate != secMngSet2.SyncExecDate) resList.Add("SyncExecDate");
            if (secMngSet1.EnterpriseName != secMngSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (secMngSet1.UpdEmployeeName != secMngSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (secMngSet1.SendDestSecCode != secMngSet2.SendDestSecCode) resList.Add("SendDestSecCode");
			if (secMngSet1.AutoSendDiv != secMngSet2.AutoSendDiv) resList.Add("AutoSendDiv");
			if (secMngSet1.SndFinDataEdDiv != secMngSet2.SndFinDataEdDiv) resList.Add("SndFinDataEdDiv");

            return resList;
        }
    }
}
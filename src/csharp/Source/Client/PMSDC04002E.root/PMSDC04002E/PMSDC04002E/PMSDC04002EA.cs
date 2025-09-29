using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalCprtSndLogListResult
    /// <summary>
    /// 売上データ送信ログテーブル
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データ送信ログテーブルヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2019/12/02</br>
    /// <br>Genarated Date   :   2019/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalCprtSndLogListResult
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

        /// <summary>自動送信区分</summary>
        /// <remarks>0:手動,1:自動</remarks>
        private Int32 _sAndEAutoSendDiv;

        /// <summary>送信日時（開始）</summary>
        /// <remarks>送信開始時間（200601011212(西暦日付＋時分）</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>送信日時（終了）</summary>
        /// <remarks>送信完了時間（200601011212(西暦日付＋時分）</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>送信対象日付（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateStart;

        /// <summary>送信対象日付（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateEnd;

        /// <summary>送信対象得意先（開始）</summary>
        private Int32 _sendObjCustStart;

        /// <summary>送信対象得意先（終了）</summary>
        private Int32 _sendObjCustEnd;

        /// <summary>送信対象区分</summary>
        /// <remarks>0:全て,1:未送信,2：送信済</remarks>
        private Int32 _sendObjDiv;

        /// <summary>送信結果</summary>
        /// <remarks>0:正常完了,1：失敗</remarks>
        private Int32 _sendResults;

        /// <summary>送信エラー内容</summary>
        private string _sendErrorContents = "";

        /// <summary>送信伝票枚数</summary>
        /// <remarks>送信した伝票枚数</remarks>
        private Int32 _sendSlipCount;

        /// <summary>送信伝票明細数</summary>
        /// <remarks>送信した伝票明細数表示</remarks>
        private Int32 _sendSlipDtlCnt;

        /// <summary>送信伝票合計金額</summary>
        /// <remarks>送信した伝票の合計金額</remarks>
        private Int64 _sendSlipTotalMny;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コード</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コード</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SAndEAutoSendDiv
        /// <summary>自動送信区分</summary>
        /// <value>0:手動,1:自動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動送信区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SAndEAutoSendDiv
        {
            get { return _sAndEAutoSendDiv; }
            set { _sAndEAutoSendDiv = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>送信日時（開始）</summary>
        /// <value>送信開始時間（200601011212(西暦日付＋時分）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日時（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>送信日時（終了）</summary>
        /// <value>送信完了時間（200601011212(西暦日付＋時分）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日時（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SendObjDateStart
        /// <summary>送信対象日付（開始）</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象日付（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendObjDateStart
        {
            get { return _sendObjDateStart; }
            set { _sendObjDateStart = value; }
        }

        /// public propaty name  :  SendObjDateEnd
        /// <summary>送信対象日付（終了）</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象日付（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendObjDateEnd
        {
            get { return _sendObjDateEnd; }
            set { _sendObjDateEnd = value; }
        }

        /// public propaty name  :  SendObjCustStart
        /// <summary>送信対象得意先（開始）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象得意先（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendObjCustStart
        {
            get { return _sendObjCustStart; }
            set { _sendObjCustStart = value; }
        }

        /// public propaty name  :  SendObjCustEnd
        /// <summary>送信対象得意先（終了）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象得意先（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendObjCustEnd
        {
            get { return _sendObjCustEnd; }
            set { _sendObjCustEnd = value; }
        }

        /// public propaty name  :  SendObjDiv
        /// <summary>送信対象区分</summary>
        /// <value>0:全て,1:未送信,2：送信済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendObjDiv
        {
            get { return _sendObjDiv; }
            set { _sendObjDiv = value; }
        }

        /// public propaty name  :  SendResults
        /// <summary>送信結果</summary>
        /// <value>0:正常完了,1：失敗</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信結果</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendResults
        {
            get { return _sendResults; }
            set { _sendResults = value; }
        }

        /// public propaty name  :  SendErrorContents
        /// <summary>送信エラー内容</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信エラー内容</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendErrorContents
        {
            get { return _sendErrorContents; }
            set { _sendErrorContents = value; }
        }

        /// public propaty name  :  SendSlipCount
        /// <summary>送信伝票枚数</summary>
        /// <value>送信した伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信伝票枚数</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendSlipCount
        {
            get { return _sendSlipCount; }
            set { _sendSlipCount = value; }
        }

        /// public propaty name  :  SendSlipDtlCnt
        /// <summary>送信伝票明細数</summary>
        /// <value>送信した伝票明細数表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信伝票明細数</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendSlipDtlCnt
        {
            get { return _sendSlipDtlCnt; }
            set { _sendSlipDtlCnt = value; }
        }

        /// public propaty name  :  SendSlipTotalMny
        /// <summary>送信伝票合計金額</summary>
        /// <value>送信した伝票の合計金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信伝票合計金額</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendSlipTotalMny
        {
            get { return _sendSlipTotalMny; }
            set { _sendSlipTotalMny = value; }
        }

        /// <summary>
        /// 売上データ送信ログテーブルコンストラクタ
        /// </summary>
        /// <returns>SalCprtSndLogListResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalCprtSndLogListResult()
        {
        }

        /// <summary>
        /// 売上データ送信ログテーブルコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID</param>
        /// <param name="updEmployeeCode">更新従業員コード</param>
        /// <param name="updAssemblyId1">更新アセンブリID1</param>
        /// <param name="updAssemblyId2">更新アセンブリID2</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sAndEAutoSendDiv">自動送信区分</param>
        /// <param name="sendDateTimeStart">送信日時（開始）</param>
        /// <param name="sendDateTimeEnd">送信日時（終了）</param>
        /// <param name="sendObjDateStart">送信対象日付（開始）</param>
        /// <param name="sendObjDateEnd">送信対象日付（終了）</param>
        /// <param name="sendObjCustStart">送信対象得意先（開始）</param>
        /// <param name="sendObjCustEnd">送信対象得意先（終了）</param>
        /// <param name="sendObjDiv">送信対象区分</param>
        /// <param name="sendResults">送信結果</param>
        /// <param name="sendErrorContents">送信エラー内容</param>
        /// <param name="sendSlipCount">送信伝票枚数</param>
        /// <param name="sendSlipDtlCnt">送信伝票明細数</param>
        /// <param name="sendSlipTotalMny">送信伝票合計金額</param>
        /// <returns>SAndESalSndLogListResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndESalSndLogListResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalCprtSndLogListResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 sAndEAutoSendDiv, Int64 sendDateTimeStart, Int64 sendDateTimeEnd, Int32 sendObjDateStart, Int32 sendObjDateEnd, Int32 sendObjCustStart, Int32 sendObjCustEnd, Int32 sendObjDiv, Int32 sendResults, string sendErrorContents, Int32 sendSlipCount, Int32 sendSlipDtlCnt, Int64 sendSlipTotalMny) 
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._sAndEAutoSendDiv = sAndEAutoSendDiv;
            this._sendDateTimeStart = sendDateTimeStart;
            this._sendDateTimeEnd = sendDateTimeEnd;
            this._sendObjDateStart = sendObjDateStart;
            this._sendObjDateEnd = sendObjDateEnd;
            this._sendObjCustStart = sendObjCustStart;
            this._sendObjCustEnd = sendObjCustEnd;
            this._sendObjDiv = sendObjDiv;
            this._sendResults = sendResults;
            this._sendErrorContents = sendErrorContents;
            this._sendSlipCount = sendSlipCount;
            this._sendSlipDtlCnt = sendSlipDtlCnt;
            this._sendSlipTotalMny = sendSlipTotalMny;
        }

        /// <summary>
        /// 売上データ送信ログテーブル複製処理
        /// </summary>
        /// <returns>SAndESalSndLogListResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSAndESalSndLogListResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalCprtSndLogListResult Clone()
        {
            return new SalCprtSndLogListResult(_createDateTime, _updateDateTime, _enterpriseCode, _fileHeaderGuid, _updEmployeeCode, _updAssemblyId1, _updAssemblyId2, _logicalDeleteCode, _sectionCode, _sAndEAutoSendDiv, _sendDateTimeStart, _sendDateTimeEnd, _sendObjDateStart, _sendObjDateEnd, _sendObjCustStart, _sendObjCustEnd, _sendObjDiv, _sendResults, _sendErrorContents, _sendSlipCount, _sendSlipDtlCnt, _sendSlipTotalMny);
        }

        /// <summary>
        /// 売上データ送信ログテーブル比較処理
        /// </summary>
        /// <param name="target">比較対象のSalCprtSndLogListResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalCprtSndLogListResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SAndEAutoSendDiv == target.SAndEAutoSendDiv)
                 && (this.SendDateTimeStart == target.SendDateTimeStart)
                 && (this.SendDateTimeEnd == target.SendDateTimeEnd)
                 && (this.SendObjDateStart == target.SendObjDateStart)
                 && (this.SendObjDateEnd == target.SendObjDateEnd)
                 && (this.SendObjCustStart == target.SendObjCustStart)
                 && (this.SendObjCustEnd == target.SendObjCustEnd)
                 && (this.SendObjDiv == target.SendObjDiv)
                 && (this.SendResults == target.SendResults)
                 && (this.SendErrorContents == target.SendErrorContents)
                 && (this.SendSlipCount == target.SendSlipCount)
                 && (this.SendSlipDtlCnt == target.SendSlipDtlCnt)
                 && (this.SendSlipTotalMny == target.SendSlipTotalMny));
        }

        /// <summary>
        /// 売上データ送信ログテーブル比較処理
        /// </summary>
        /// <param name="SalCprtSndLogListResult1">比較するSalCprtSndLogListResultクラスのインスタンス</param>
        /// <param name="SalCprtSndLogListResult2">比較するSalCprtSndLogListResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListResult2クラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalCprtSndLogListResult SalCprtSndLogListResult1, SalCprtSndLogListResult SalCprtSndLogListResult2)
        {
            return ((SalCprtSndLogListResult1.CreateDateTime == SalCprtSndLogListResult2.CreateDateTime)
                 && (SalCprtSndLogListResult1.UpdateDateTime == SalCprtSndLogListResult2.UpdateDateTime)
                 && (SalCprtSndLogListResult1.EnterpriseCode == SalCprtSndLogListResult2.EnterpriseCode)
                 && (SalCprtSndLogListResult1.FileHeaderGuid == SalCprtSndLogListResult2.FileHeaderGuid)
                 && (SalCprtSndLogListResult1.UpdEmployeeCode == SalCprtSndLogListResult2.UpdEmployeeCode)
                 && (SalCprtSndLogListResult1.UpdAssemblyId1 == SalCprtSndLogListResult2.UpdAssemblyId1)
                 && (SalCprtSndLogListResult1.UpdAssemblyId2 == SalCprtSndLogListResult2.UpdAssemblyId2)
                 && (SalCprtSndLogListResult1.LogicalDeleteCode == SalCprtSndLogListResult2.LogicalDeleteCode)
                 && (SalCprtSndLogListResult1.SectionCode == SalCprtSndLogListResult2.SectionCode)
                 && (SalCprtSndLogListResult1.SAndEAutoSendDiv == SalCprtSndLogListResult2.SAndEAutoSendDiv)
                 && (SalCprtSndLogListResult1.SendDateTimeStart == SalCprtSndLogListResult2.SendDateTimeStart)
                 && (SalCprtSndLogListResult1.SendDateTimeEnd == SalCprtSndLogListResult2.SendDateTimeEnd)
                 && (SalCprtSndLogListResult1.SendObjDateStart == SalCprtSndLogListResult2.SendObjDateStart)
                 && (SalCprtSndLogListResult1.SendObjDateEnd == SalCprtSndLogListResult2.SendObjDateEnd)
                 && (SalCprtSndLogListResult1.SendObjCustStart == SalCprtSndLogListResult2.SendObjCustStart)
                 && (SalCprtSndLogListResult1.SendObjCustEnd == SalCprtSndLogListResult2.SendObjCustEnd)
                 && (SalCprtSndLogListResult1.SendObjDiv == SalCprtSndLogListResult2.SendObjDiv)
                 && (SalCprtSndLogListResult1.SendResults == SalCprtSndLogListResult2.SendResults)
                 && (SalCprtSndLogListResult1.SendErrorContents == SalCprtSndLogListResult2.SendErrorContents)
                 && (SalCprtSndLogListResult1.SendSlipCount == SalCprtSndLogListResult2.SendSlipCount)
                 && (SalCprtSndLogListResult1.SendSlipDtlCnt == SalCprtSndLogListResult2.SendSlipDtlCnt)
                 && (SalCprtSndLogListResult1.SendSlipTotalMny == SalCprtSndLogListResult2.SendSlipTotalMny));
        }
        /// <summary>
        /// 売上データ送信ログテーブル比較処理
        /// </summary>
        /// <param name="target">比較対象のSalCprtSndLogListResult2クラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListResult2クラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalCprtSndLogListResult target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SAndEAutoSendDiv != target.SAndEAutoSendDiv) resList.Add("SAndEAutoSendDiv");
            if (this.SendDateTimeStart != target.SendDateTimeStart) resList.Add("SendDateTimeStart");
            if (this.SendDateTimeEnd != target.SendDateTimeEnd) resList.Add("SendDateTimeEnd");
            if (this.SendObjDateStart != target.SendObjDateStart) resList.Add("SendObjDateStart");
            if (this.SendObjDateEnd != target.SendObjDateEnd) resList.Add("SendObjDateEnd");
            if (this.SendObjCustStart != target.SendObjCustStart) resList.Add("SendObjCustStart");
            if (this.SendObjCustEnd != target.SendObjCustEnd) resList.Add("SendObjCustEnd");
            if (this.SendObjDiv != target.SendObjDiv) resList.Add("SendObjDiv");
            if (this.SendResults != target.SendResults) resList.Add("SendResults");
            if (this.SendErrorContents != target.SendErrorContents) resList.Add("SendErrorContents");
            if (this.SendSlipCount != target.SendSlipCount) resList.Add("SendSlipCount");
            if (this.SendSlipDtlCnt != target.SendSlipDtlCnt) resList.Add("SendSlipDtlCnt");
            if (this.SendSlipTotalMny != target.SendSlipTotalMny) resList.Add("SendSlipTotalMny");

            return resList;
        }

        /// <summary>
        /// 売上データ送信ログテーブル比較処理
        /// </summary>
        /// <param name="SalCprtSndLogListResult1">比較するSalCprtSndLogListResult1クラスのインスタンス</param>
        /// <param name="SalCprtSndLogListResult2">比較するSalCprtSndLogListResult2クラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalCprtSndLogListResult SalCprtSndLogListResult1, SalCprtSndLogListResult SalCprtSndLogListResult2)
        {
            ArrayList resList = new ArrayList();
            if (SalCprtSndLogListResult1.CreateDateTime != SalCprtSndLogListResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (SalCprtSndLogListResult1.UpdateDateTime != SalCprtSndLogListResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (SalCprtSndLogListResult1.EnterpriseCode != SalCprtSndLogListResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (SalCprtSndLogListResult1.FileHeaderGuid != SalCprtSndLogListResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (SalCprtSndLogListResult1.UpdEmployeeCode != SalCprtSndLogListResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (SalCprtSndLogListResult1.UpdAssemblyId1 != SalCprtSndLogListResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (SalCprtSndLogListResult1.UpdAssemblyId2 != SalCprtSndLogListResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (SalCprtSndLogListResult1.LogicalDeleteCode != SalCprtSndLogListResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (SalCprtSndLogListResult1.SectionCode != SalCprtSndLogListResult2.SectionCode) resList.Add("SectionCode");
            if (SalCprtSndLogListResult1.SAndEAutoSendDiv != SalCprtSndLogListResult2.SAndEAutoSendDiv) resList.Add("SAndEAutoSendDiv");
            if (SalCprtSndLogListResult1.SendDateTimeStart != SalCprtSndLogListResult2.SendDateTimeStart) resList.Add("SendDateTimeStart");
            if (SalCprtSndLogListResult1.SendDateTimeEnd != SalCprtSndLogListResult2.SendDateTimeEnd) resList.Add("SendDateTimeEnd");
            if (SalCprtSndLogListResult1.SendObjDateStart != SalCprtSndLogListResult2.SendObjDateStart) resList.Add("SendObjDateStart");
            if (SalCprtSndLogListResult1.SendObjDateEnd != SalCprtSndLogListResult2.SendObjDateEnd) resList.Add("SendObjDateEnd");
            if (SalCprtSndLogListResult1.SendObjCustStart != SalCprtSndLogListResult2.SendObjCustStart) resList.Add("SendObjCustStart");
            if (SalCprtSndLogListResult1.SendObjCustEnd != SalCprtSndLogListResult2.SendObjCustEnd) resList.Add("SendObjCustEnd");
            if (SalCprtSndLogListResult1.SendObjDiv != SalCprtSndLogListResult2.SendObjDiv) resList.Add("SendObjDiv");
            if (SalCprtSndLogListResult1.SendResults != SalCprtSndLogListResult2.SendResults) resList.Add("SendResults");
            if (SalCprtSndLogListResult1.SendErrorContents != SalCprtSndLogListResult2.SendErrorContents) resList.Add("SendErrorContents");
            if (SalCprtSndLogListResult1.SendSlipCount != SalCprtSndLogListResult2.SendSlipCount) resList.Add("SendSlipCount");
            if (SalCprtSndLogListResult1.SendSlipDtlCnt != SalCprtSndLogListResult2.SendSlipDtlCnt) resList.Add("SendSlipDtlCnt");
            if (SalCprtSndLogListResult1.SendSlipTotalMny != SalCprtSndLogListResult2.SendSlipTotalMny) resList.Add("SendSlipTotalMny");

            return resList;
        }
    }
}

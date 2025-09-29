//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信対象設定マスタメンテナンス
// プログラム概要   : 送受信対象設定の変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecMngSndRcv
    /// <summary>
    ///                      拠点管理送受信対象マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点管理送受信対象マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   PMKOBETSU-3877の対応</br>
    /// <br>                 :   2020/09/25</br>
    /// </remarks>
    public class SecMngSndRcv
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

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>マスタ名称</summary>
        private string _masterName = "";

        /// <summary>ファイルＩＤ</summary>
        private string _fileId = "";

        /// <summary>ファイル名称</summary>
        private string _fileNm = "";

        /// <summary>ユーザーガイド区分</summary>
        private Int32 _userGuideDivCd;

        /// <summary>拠点管理送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _secMngSendDiv;

        /// <summary>拠点管理受信区分</summary>
        /// <remarks>0:受信無 1:受信有（追加のみ） 2:受信有（追加・更新）</remarks>
        private Int32 _secMngRecvDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
        /// <summary>受注データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _acptAnOdrSendDiv;

        /// <summary>受注データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _acptAnOdrRecvDiv;

        /// <summary>貸出データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _shipmentSendDiv;

        /// <summary>貸出データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _shipmentRecvDiv;

        /// <summary>見積データ送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _estimateSendDiv;

        /// <summary>見積データ受信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _estimateRecvDiv;
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  MasterName
        /// <summary>マスタ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MasterName
        {
            get { return _masterName; }
            set { _masterName = value; }
        }

        /// public propaty name  :  FileId
        /// <summary>ファイルＩＤプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルＩＤプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        /// public propaty name  :  FileNm
        /// <summary>ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileNm
        {
            get { return _fileNm; }
            set { _fileNm = value; }
        }

        /// public propaty name  :  UserGuideDivCd
        /// <summary>ユーザーガイド区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイド区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGuideDivCd
        {
            get { return _userGuideDivCd; }
            set { _userGuideDivCd = value; }
        }

        /// public propaty name  :  SecMngSendDiv
        /// <summary>拠点管理送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点管理送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngSendDiv
        {
            get { return _secMngSendDiv; }
            set { _secMngSendDiv = value; }
        }

        /// public propaty name  :  SecMngRecvDiv
        /// <summary>拠点管理受信区分プロパティ</summary>
        /// <value>0:受信無 1:受信有（追加のみ） 2:受信有（追加・更新）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点管理受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngRecvDiv
        {
            get { return _secMngRecvDiv; }
            set { _secMngRecvDiv = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
        /// public propaty name  :  AcptAnOdrSendDiv
        /// <summary>受注データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrSendDiv
        {
            get { return _acptAnOdrSendDiv; }
            set { _acptAnOdrSendDiv = value; }
        }

        /// public propaty name  :  AcptAnOdrRecvDiv
        /// <summary>受注データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrRecvDiv
        {
            get { return _acptAnOdrRecvDiv; }
            set { _acptAnOdrRecvDiv = value; }
        }

        /// public propaty name  :  ShipmentSendDiv
        /// <summary>貸出データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentSendDiv
        {
            get { return _shipmentSendDiv; }
            set { _shipmentSendDiv = value; }
        }

        /// public propaty name  :  ShipmentRecvDiv
        /// <summary>貸出データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentRecvDiv
        {
            get { return _shipmentRecvDiv; }
            set { _shipmentRecvDiv = value; }
        }

        /// public propaty name  :  EstimateSendDiv
        /// <summary>見積データ送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateSendDiv
        {
            get { return _estimateSendDiv; }
            set { _estimateSendDiv = value; }
        }

        /// public propaty name  :  EstimateRecvDiv
        /// <summary>見積データ受信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateRecvDiv
        {
            get { return _estimateRecvDiv; }
            set { _estimateRecvDiv = value; }
        }
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

        /// <summary>
        /// 拠点管理送受信対象マスタコンストラクタ
        /// </summary>
        /// <returns>SecMngSndRcvクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecMngSndRcv()
        {
        }

        /// <summary>
        /// 拠点管理送受信対象マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="masterName">マスタ名称</param>
        /// <param name="fileId">ファイルＩＤ</param>
        /// <param name="fileNm">ファイル名称</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        /// <param name="secMngSendDiv">拠点管理送信区分(0:送信なし 1:送信あり)</param>
        /// <param name="secMngRecvDiv">拠点管理受信区分(0:受信無 1:受信有（追加のみ） 2:受信有（追加・更新）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="acptAnOdrSendDiv">受注データ送信区分(0:送信なし 1:送信あり)</param>
        /// <param name="acptAnOdrRecvDiv">受注データ受信区分(0:送信なし 1:送信あり)</param>
        /// <param name="shipmentSendDiv">貸出データ送信区分(0:送信なし 1:送信あり)</param>
        /// <param name="shipmentRecvDiv">貸出データ受信区分(0:送信なし 1:送信あり)</param>
        /// <param name="estimateSendDiv">見積データ送信区分(0:送信なし 1:送信あり)</param>
        /// <param name="estimateRecvDiv">見積データ受信区分(0:送信なし 1:送信あり)</param>
        /// <returns>SecMngSndRcvクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
        //public SecMngSndRcv(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 displayOrder, string masterName, string fileId, string fileNm, Int32 userGuideDivCd, Int32 secMngSendDiv, Int32 secMngRecvDiv, string enterpriseName, string updEmployeeName)
        public SecMngSndRcv(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 displayOrder, string masterName, string fileId, string fileNm, Int32 userGuideDivCd, Int32 secMngSendDiv, Int32 secMngRecvDiv, string enterpriseName, string updEmployeeName, Int32 acptAnOdrSendDiv, Int32 acptAnOdrRecvDiv,Int32 shipmentSendDiv, Int32 shipmentRecvDiv, Int32 estimateSendDiv, Int32 estimateRecvDiv)
        // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._displayOrder = displayOrder;
            this._masterName = masterName;
            this._fileId = fileId;
            this._fileNm = fileNm;
            this._userGuideDivCd = userGuideDivCd;
            this._secMngSendDiv = secMngSendDiv;
            this._secMngRecvDiv = secMngRecvDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            this._acptAnOdrSendDiv = acptAnOdrSendDiv;
            this._acptAnOdrRecvDiv = acptAnOdrRecvDiv;
            this._shipmentSendDiv = shipmentSendDiv;
            this._shipmentRecvDiv = shipmentRecvDiv;
            this._estimateSendDiv = estimateSendDiv;
            this._estimateRecvDiv = estimateRecvDiv;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        }

        /// <summary>
        /// 拠点管理送受信対象マスタ複製処理
        /// </summary>
        /// <returns>SecMngSndRcvクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecMngSndRcvクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecMngSndRcv Clone()
        {
            // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            //return new SecMngSndRcv(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._displayOrder, this._masterName, this._fileId, this._fileNm, this._userGuideDivCd, this._secMngSendDiv, this._secMngRecvDiv, this._enterpriseName, this._updEmployeeNamethis);
            return new SecMngSndRcv(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._displayOrder, this._masterName, this._fileId, this._fileNm, this._userGuideDivCd, this._secMngSendDiv, this._secMngRecvDiv, this._enterpriseName, this._updEmployeeName, this._acptAnOdrSendDiv, this._acptAnOdrRecvDiv, this._shipmentSendDiv, this._shipmentRecvDiv, this._estimateSendDiv, this._estimateRecvDiv);
            // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        }

        /// <summary>
        /// 拠点管理送受信対象マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSecMngSndRcvクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SecMngSndRcv target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.MasterName == target.MasterName)
                 && (this.FileId == target.FileId)
                 && (this.FileNm == target.FileNm)
                 && (this.UserGuideDivCd == target.UserGuideDivCd)
                 && (this.SecMngSendDiv == target.SecMngSendDiv)
                 && (this.SecMngRecvDiv == target.SecMngRecvDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                 //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AcptAnOdrSendDiv == target.AcptAnOdrSendDiv)
                 && (this.AcptAnOdrRecvDiv == target.AcptAnOdrRecvDiv)
                 && (this.ShipmentSendDiv == target.ShipmentSendDiv)
                 && (this.ShipmentRecvDiv == target.ShipmentRecvDiv)
                 && (this.EstimateSendDiv == target.EstimateSendDiv)
                 && (this.EstimateRecvDiv == target.EstimateRecvDiv));
                 // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        }

        /// <summary>
        /// 拠点管理送受信対象マスタ比較処理
        /// </summary>
        /// <param name="secMngSndRcv1">
        ///                    比較するSecMngSndRcvクラスのインスタンス
        /// </param>
        /// <param name="secMngSndRcv2">比較するSecMngSndRcvクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SecMngSndRcv secMngSndRcv1, SecMngSndRcv secMngSndRcv2)
        {
            return ((secMngSndRcv1.CreateDateTime == secMngSndRcv2.CreateDateTime)
                 && (secMngSndRcv1.UpdateDateTime == secMngSndRcv2.UpdateDateTime)
                 && (secMngSndRcv1.EnterpriseCode == secMngSndRcv2.EnterpriseCode)
                 && (secMngSndRcv1.FileHeaderGuid == secMngSndRcv2.FileHeaderGuid)
                 && (secMngSndRcv1.UpdEmployeeCode == secMngSndRcv2.UpdEmployeeCode)
                 && (secMngSndRcv1.UpdAssemblyId1 == secMngSndRcv2.UpdAssemblyId1)
                 && (secMngSndRcv1.UpdAssemblyId2 == secMngSndRcv2.UpdAssemblyId2)
                 && (secMngSndRcv1.LogicalDeleteCode == secMngSndRcv2.LogicalDeleteCode)
                 && (secMngSndRcv1.DisplayOrder == secMngSndRcv2.DisplayOrder)
                 && (secMngSndRcv1.MasterName == secMngSndRcv2.MasterName)
                 && (secMngSndRcv1.FileId == secMngSndRcv2.FileId)
                 && (secMngSndRcv1.FileNm == secMngSndRcv2.FileNm)
                 && (secMngSndRcv1.UserGuideDivCd == secMngSndRcv2.UserGuideDivCd)
                 && (secMngSndRcv1.SecMngSendDiv == secMngSndRcv2.SecMngSendDiv)
                 && (secMngSndRcv1.SecMngRecvDiv == secMngSndRcv2.SecMngRecvDiv)
                 && (secMngSndRcv1.EnterpriseName == secMngSndRcv2.EnterpriseName)
                 // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                 //&& (secMngSndRcv1.UpdEmployeeName == secMngSndRcv2.UpdEmployeeName));
                 && (secMngSndRcv1.UpdEmployeeName == secMngSndRcv2.UpdEmployeeName)
                 && (secMngSndRcv1.AcptAnOdrSendDiv == secMngSndRcv2.AcptAnOdrSendDiv)
                 && (secMngSndRcv1.AcptAnOdrRecvDiv == secMngSndRcv2.AcptAnOdrRecvDiv)
                 && (secMngSndRcv1.ShipmentSendDiv == secMngSndRcv2.ShipmentSendDiv)
                 && (secMngSndRcv1.ShipmentRecvDiv == secMngSndRcv2.ShipmentRecvDiv)
                 && (secMngSndRcv1.EstimateSendDiv == secMngSndRcv2.EstimateSendDiv)
                 && (secMngSndRcv1.EstimateRecvDiv == secMngSndRcv2.EstimateRecvDiv));
                 // UPD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        }
        /// <summary>
        /// 拠点管理送受信対象マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSecMngSndRcvクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SecMngSndRcv target)
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
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.MasterName != target.MasterName) resList.Add("MasterName");
            if (this.FileId != target.FileId) resList.Add("FileId");
            if (this.FileNm != target.FileNm) resList.Add("FileNm");
            if (this.UserGuideDivCd != target.UserGuideDivCd) resList.Add("UserGuideDivCd");
            if (this.SecMngSendDiv != target.SecMngSendDiv) resList.Add("SecMngSendDiv");
            if (this.SecMngRecvDiv != target.SecMngRecvDiv) resList.Add("SecMngRecvDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            if (this.AcptAnOdrSendDiv != target.AcptAnOdrSendDiv) resList.Add("AcptAnOdrSendDiv");
            if (this.AcptAnOdrRecvDiv != target.AcptAnOdrRecvDiv) resList.Add("AcptAnOdrRecvDiv");
            if (this.ShipmentSendDiv != target.ShipmentSendDiv) resList.Add("ShipmentSendDiv");
            if (this.ShipmentRecvDiv != target.ShipmentRecvDiv) resList.Add("ShipmentRecvDiv");
            if (this.EstimateSendDiv != target.EstimateSendDiv) resList.Add("EstimateSendDiv");
            if (this.EstimateRecvDiv != target.EstimateRecvDiv) resList.Add("EstimateRecvDiv");
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
            return resList;
        }

        /// <summary>
        /// 拠点管理送受信対象マスタ比較処理
        /// </summary>
        /// <param name="secMngSndRcv1">比較するSecMngSndRcvクラスのインスタンス</param>
        /// <param name="secMngSndRcv2">比較するSecMngSndRcvクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SecMngSndRcv secMngSndRcv1, SecMngSndRcv secMngSndRcv2)
        {
            ArrayList resList = new ArrayList();
            if (secMngSndRcv1.CreateDateTime != secMngSndRcv2.CreateDateTime) resList.Add("CreateDateTime");
            if (secMngSndRcv1.UpdateDateTime != secMngSndRcv2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secMngSndRcv1.EnterpriseCode != secMngSndRcv2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secMngSndRcv1.FileHeaderGuid != secMngSndRcv2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secMngSndRcv1.UpdEmployeeCode != secMngSndRcv2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secMngSndRcv1.UpdAssemblyId1 != secMngSndRcv2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secMngSndRcv1.UpdAssemblyId2 != secMngSndRcv2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secMngSndRcv1.LogicalDeleteCode != secMngSndRcv2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secMngSndRcv1.DisplayOrder != secMngSndRcv2.DisplayOrder) resList.Add("DisplayOrder");
            if (secMngSndRcv1.MasterName != secMngSndRcv2.MasterName) resList.Add("MasterName");
            if (secMngSndRcv1.FileId != secMngSndRcv2.FileId) resList.Add("FileId");
            if (secMngSndRcv1.FileNm != secMngSndRcv2.FileNm) resList.Add("FileNm");
            if (secMngSndRcv1.UserGuideDivCd != secMngSndRcv2.UserGuideDivCd) resList.Add("UserGuideDivCd");
            if (secMngSndRcv1.SecMngSendDiv != secMngSndRcv2.SecMngSendDiv) resList.Add("SecMngSendDiv");
            if (secMngSndRcv1.SecMngRecvDiv != secMngSndRcv2.SecMngRecvDiv) resList.Add("SecMngRecvDiv");
            if (secMngSndRcv1.EnterpriseName != secMngSndRcv2.EnterpriseName) resList.Add("EnterpriseName");
            if (secMngSndRcv1.UpdEmployeeName != secMngSndRcv2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            if (secMngSndRcv1.AcptAnOdrSendDiv != secMngSndRcv2.AcptAnOdrSendDiv) resList.Add("AcptAnOdrSendDiv");
            if (secMngSndRcv1.AcptAnOdrRecvDiv != secMngSndRcv2.AcptAnOdrRecvDiv) resList.Add("AcptAnOdrRecvDiv");
            if (secMngSndRcv1.ShipmentSendDiv != secMngSndRcv2.ShipmentSendDiv) resList.Add("ShipmentSendDiv");
            if (secMngSndRcv1.ShipmentRecvDiv != secMngSndRcv2.ShipmentRecvDiv) resList.Add("ShipmentRecvDiv");
            if (secMngSndRcv1.EstimateSendDiv != secMngSndRcv2.EstimateSendDiv) resList.Add("EstimateSendDiv");
            if (secMngSndRcv1.EstimateRecvDiv != secMngSndRcv2.EstimateRecvDiv) resList.Add("EstimateRecvDiv");
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

            return resList;
        }
    }
}

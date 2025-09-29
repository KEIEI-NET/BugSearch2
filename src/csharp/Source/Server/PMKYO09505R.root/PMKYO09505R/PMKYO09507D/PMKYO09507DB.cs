//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理DC送受信履歴メンテナンス
// プログラム概要   : 送受信履歴の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/07/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// public class name:   SndRcvHisConWork
    /// <summary>
    ///                      送受信履歴テーブルデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   送受信履歴テーブルデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2012/08/08</br>
    /// <br>Genarated Date   :   2012/08/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/08/08  金沢</br>
    /// <br>                 :   新規作成</br>
    /// <br>Update Note      :   2012/10/16 李亜博</br>
    ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvHisConWork : IFileHeader
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

        /// <summary>送受信履歴送受信番号</summary>
        private Int32 _sndRcvHisSndRcvNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>送受信履歴ログ送信番号</summary>
        private Int32 _sndRcvHisConsNo;

        /// <summary>送受信日時</summary>
        /// <remarks>西暦日付＋時分　　例）200601011212</remarks>
        private Int64 _sndRcvDateTime;

        /// <summary>送受信区分</summary>
        /// <remarks>0:送信（出力）　1:受信（取込）</remarks>
        private Int32 _sendOrReceiveDivCd;

        /// <summary>種別</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _kind;

        /// <summary>送受信ログ抽出条件区分</summary>
        /// <remarks>0:自動(差分)　1:手動(条件)</remarks>
        private Int32 _sndLogExtraCondDiv;

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        ///// <summary>処理開始日時</summary>
        ///// <remarks>DateTime:精度は100ナノ秒</remarks>
        //private Int64 _procStartDateTime;

        ///// <summary>処理終了日時</summary>
        ///// <remarks>DateTime:精度は100ナノ秒</remarks>
        //private Int64 _procEndDateTime;
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>送信先企業コード</summary>
        private string _sendDestEpCode = "";

        /// <summary>送信先拠点コード</summary>
        private string _sendDestSecCode = "";

        /// <summary>送受信状態</summary>
        /// <remarks>0:成功  1:失敗</remarks>
        private Int32 _sndRcvCondition;

        /// <summary>仮受信区分</summary>
        /// <remarks>1:受信　2:仮受信</remarks>
        private Int32 _tempReceiveDiv;

        /// <summary>送受信エラー内容</summary>
        private string _sndRcvErrContents = "";

        /// <summary>送受信ファイルＩＤ</summary>
        /// <remarks>ファイルID1,ファイルID2,ファイルID3………ファイルID4</remarks>
        private string _sndRcvFileID = "";

        /// <summary>送受信日時(開始)</summary>
        /// <remarks>西暦日付＋時分　　例）200601011212</remarks>
        private Int64 _sndRcvStartDateTime;

        /// <summary>送受信日時(終了)</summary>
        /// <remarks>西暦日付＋時分　　例）200601011212</remarks>
        private Int64 _sndRcvEndDateTime;


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

        /// public propaty name  :  SndRcvHisSndRcvNo
        /// <summary>送受信履歴送受信番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴送受信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvHisSndRcvNo
        {
            get { return _sndRcvHisSndRcvNo; }
            set { _sndRcvHisSndRcvNo = value; }
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

        /// public propaty name  :  SndRcvHisConsNo
        /// <summary>送受信履歴ログ送信番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴ログ送信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SndRcvDateTime
        /// <summary>送受信日時プロパティ</summary>
        /// <value>西暦日付＋時分　　例）200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndRcvDateTime
        {
            get { return _sndRcvDateTime; }
            set { _sndRcvDateTime = value; }
        }

        /// public propaty name  :  SendOrReceiveDivCd
        /// <summary>送受信区分プロパティ</summary>
        /// <value>0:送信（出力）　1:受信（取込）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendOrReceiveDivCd
        {
            get { return _sendOrReceiveDivCd; }
            set { _sendOrReceiveDivCd = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>種別プロパティ</summary>
        /// <value>0:データ　1:マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// public propaty name  :  SndLogExtraCondDiv
        /// <summary>送受信ログ抽出条件区分プロパティ</summary>
        /// <value>0:自動(差分)　1:手動(条件)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ログ抽出条件区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        ///// public propaty name  :  ProcStartDateTime
        ///// <summary>処理開始日時プロパティ</summary>
        ///// <value>DateTime:精度は100ナノ秒</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   処理開始日時プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ProcStartDateTime
        //{
        //    get { return _procStartDateTime; }
        //    set { _procStartDateTime = value; }
        //}

        ///// public propaty name  :  ProcEndDateTime
        ///// <summary>処理終了日時プロパティ</summary>
        ///// <value>DateTime:精度は100ナノ秒</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   処理終了日時プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ProcEndDateTime
        //{
        //    get { return _procEndDateTime; }
        //    set { _procEndDateTime = value; }
        //}
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        /// public propaty name  :  SendDestEpCode
        /// <summary>送信先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>送信先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        /// public propaty name  :  SndRcvCondition
        /// <summary>送受信状態プロパティ</summary>
        /// <value>0:成功  1:失敗</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvCondition
        {
            get { return _sndRcvCondition; }
            set { _sndRcvCondition = value; }
        }

        /// public propaty name  :  TempReceiveDiv
        /// <summary>仮受信区分プロパティ</summary>
        /// <value>1:受信　2:仮受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仮受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TempReceiveDiv
        {
            get { return _tempReceiveDiv; }
            set { _tempReceiveDiv = value; }
        }

        /// public propaty name  :  SndRcvErrContents
        /// <summary>送受信エラー内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信エラー内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvErrContents
        {
            get { return _sndRcvErrContents; }
            set { _sndRcvErrContents = value; }
        }

        /// public propaty name  :  SndRcvFileID
        /// <summary>送受信ファイルＩＤプロパティ</summary>
        /// <value>ファイルID1,ファイルID2,ファイルID3………ファイルID4</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ファイルＩＤプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvFileID
        {
            get { return _sndRcvFileID; }
            set { _sndRcvFileID = value; }
        }

        /// public propaty name  :  SndRcvStartDateTime
        /// <summary>送受信日時(開始)プロパティ</summary>
        /// <value>西暦日付＋時分　　例）200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信日時(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndRcvStartDateTime
        {
            get { return _sndRcvStartDateTime; }
            set { _sndRcvStartDateTime = value; }
        }

        /// public propaty name  :  SndRcvEndDateTime
        /// <summary>送受信日時(終了)プロパティ</summary>
        /// <value>西暦日付＋時分　　例）200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信日時(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndRcvEndDateTime
        {
            get { return _sndRcvEndDateTime; }
            set { _sndRcvEndDateTime = value; }
        }


        /// <summary>
        /// 送受信履歴テーブルデータワークコンストラクタ
        /// </summary>
        /// <returns>SndRcvHisConWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisConWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SndRcvHisConWork()
        {
        }

    }

    }

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC送受信履歴　データパラメータ
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
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvHisTableWork
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
    public class SndRcvHisTableWork: IFileHeader
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

        /// <summary>送受信ログ利用区分</summary>
        /// <remarks>ログの利用形態 0:拠点管理</remarks>
        private Int32 _sndLogUseDiv;

        /// <summary>抽出対象拠点コード</summary>
        /// <remarks>送信データ（マスタ）の所属する拠点</remarks>
        private string _extraObjSecCode = "";

        /// <summary>送信対象開始日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _sndObjStartDate;

        /// <summary>送信対象終了日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _sndObjEndDate;

        /// <summary>シンク実行日付</summary>
        /// <remarks>最終送信日</remarks>
        private Int64 _syncExecDate;

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

        /// public propaty name  :  SndLogUseDiv
        /// <summary>送受信ログ利用区分プロパティ</summary>
        /// <value>ログの利用形態 0:拠点管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ログ利用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndLogUseDiv
        {
            get { return _sndLogUseDiv; }
            set { _sndLogUseDiv = value; }
        }

        /// public propaty name  :  ExtraObjSecCode
        /// <summary>抽出対象拠点コードプロパティ</summary>
        /// <value>送信データ（マスタ）の所属する拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出対象拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExtraObjSecCode
        {
            get { return _extraObjSecCode; }
            set { _extraObjSecCode = value; }
        }

        /// public propaty name  :  SndObjStartDate
        /// <summary>送信対象開始日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndObjStartDate
        {
            get { return _sndObjStartDate; }
            set { _sndObjStartDate = value; }
        }

        /// public propaty name  :  SndObjEndDate
        /// <summary>送信対象終了日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndObjEndDate
        {
            get { return _sndObjEndDate; }
            set { _sndObjEndDate = value; }
        }

        /// public propaty name  :  SyncExecDate
        /// <summary>シンク実行日付プロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
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
        /// <returns>SndRcvHisTableWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisTableWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SndRcvHisTableWork()
        {
        }

    }



    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SndRcvHisTableWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SndRcvHisTableWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SndRcvHisTableWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisTableWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvHisTableWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvHisTableWork || graph is ArrayList || graph is SndRcvHisTableWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SndRcvHisTableWork).FullName));

            if (graph != null && graph is SndRcvHisTableWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvHisTableWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvHisTableWork[])graph).Length;
            }
            else if (graph is SndRcvHisTableWork)
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
            //送受信履歴送受信番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisSndRcvNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //送受信履歴ログ送信番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            //送受信日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvDateTime
            //送受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SendOrReceiveDivCd
            //種別
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //送受信ログ抽出条件区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogExtraCondDiv
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ////処理開始日時
            //serInfo.MemberInfo.Add(typeof(Int64)); //ProcStartDateTime
            ////処理終了日時
            //serInfo.MemberInfo.Add(typeof(Int64)); //ProcEndDateTime
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            //送信先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //SendDestEpCode
            //送信先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SendDestSecCode
            //送受信状態
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvCondition
            //仮受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TempReceiveDiv
            //送受信エラー内容
            serInfo.MemberInfo.Add(typeof(string)); //SndRcvErrContents
            //送受信ファイルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); //SndRcvFileID
            //送受信ログ利用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogUseDiv
            //抽出対象拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ExtraObjSecCode
            //送信対象開始日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjStartDate
            //送信対象終了日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjEndDate
            //シンク実行日付
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate
            //送受信日時(開始)
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvStartDateTime
            //送受信日時(終了)
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvEndDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvHisTableWork)
            {
                SndRcvHisTableWork temp = (SndRcvHisTableWork)graph;

                SetSndRcvHisTableWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvHisTableWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvHisTableWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvHisTableWork temp in lst)
                {
                    SetSndRcvHisTableWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvHisTableWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 30;//DEL 2012/10/16 李亜博 for redmine#31026
        private const int currentMemberCount = 28;//ADD 2012/10/16 李亜博 for redmine#31026

        /// <summary>
        ///  SndRcvHisTableWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisTableWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private void SetSndRcvHisTableWork(System.IO.BinaryWriter writer, SndRcvHisTableWork temp)
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
            //送受信履歴送受信番号
            writer.Write(temp.SndRcvHisSndRcvNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //送受信履歴ログ送信番号
            writer.Write(temp.SndRcvHisConsNo);
            //送受信日時
            writer.Write(temp.SndRcvDateTime);
            //送受信区分
            writer.Write(temp.SendOrReceiveDivCd);
            //種別
            writer.Write(temp.Kind);
            //送受信ログ抽出条件区分
            writer.Write(temp.SndLogExtraCondDiv);
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ////処理開始日時
            //writer.Write(temp.ProcStartDateTime);
            ////処理終了日時
            //writer.Write(temp.ProcEndDateTime);
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            //送信先企業コード
            writer.Write(temp.SendDestEpCode);
            //送信先拠点コード
            writer.Write(temp.SendDestSecCode);
            //送受信状態
            writer.Write(temp.SndRcvCondition);
            //仮受信区分
            writer.Write(temp.TempReceiveDiv);
            //送受信エラー内容
            writer.Write(temp.SndRcvErrContents);
            //送受信ファイルＩＤ
            writer.Write(temp.SndRcvFileID);
            //送受信ログ利用区分
            writer.Write(temp.SndLogUseDiv);
            //抽出対象拠点コード
            writer.Write(temp.ExtraObjSecCode);
            //送信対象開始日時
            writer.Write(temp.SndObjStartDate);
            //送信対象終了日時
            writer.Write(temp.SndObjEndDate);
            //シンク実行日付
            writer.Write(temp.SyncExecDate);
            //送受信日時(開始)
            writer.Write(temp.SndRcvStartDateTime);
            //送受信日時(終了)
            writer.Write(temp.SndRcvEndDateTime);

        }

        /// <summary>
        ///  SndRcvHisTableWorkインスタンス取得
        /// </summary>
        /// <returns>SndRcvHisTableWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisTableWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private SndRcvHisTableWork GetSndRcvHisTableWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SndRcvHisTableWork temp = new SndRcvHisTableWork();

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
            //送受信履歴送受信番号
            temp.SndRcvHisSndRcvNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //送受信履歴ログ送信番号
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //送受信日時
            temp.SndRcvDateTime = reader.ReadInt64();
            //送受信区分
            temp.SendOrReceiveDivCd = reader.ReadInt32();
            //種別
            temp.Kind = reader.ReadInt32();
            //送受信ログ抽出条件区分
            temp.SndLogExtraCondDiv = reader.ReadInt32();
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ////処理開始日時
            //temp.ProcStartDateTime = reader.ReadInt64();
            ////処理終了日時
            //temp.ProcEndDateTime = reader.ReadInt64();
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            //送信先企業コード
            temp.SendDestEpCode = reader.ReadString();
            //送信先拠点コード
            temp.SendDestSecCode = reader.ReadString();
            //送受信状態
            temp.SndRcvCondition = reader.ReadInt32();
            //仮受信区分
            temp.TempReceiveDiv = reader.ReadInt32();
            //送受信エラー内容
            temp.SndRcvErrContents = reader.ReadString();
            //送受信ファイルＩＤ
            temp.SndRcvFileID = reader.ReadString();
            //送受信ログ利用区分
            temp.SndLogUseDiv = reader.ReadInt32();
            //抽出対象拠点コード
            temp.ExtraObjSecCode = reader.ReadString();
            //送信対象開始日時
            temp.SndObjStartDate = reader.ReadInt64();
            //送信対象終了日時
            temp.SndObjEndDate = reader.ReadInt64();
            //シンク実行日付
            temp.SyncExecDate = reader.ReadInt64();
            //送受信日時(開始)
            temp.SndRcvStartDateTime = reader.ReadInt64();
            //送受信日時(終了)
            temp.SndRcvEndDateTime = reader.ReadInt64();


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
        /// <returns>SndRcvHisTableWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisTableWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvHisTableWork temp = GetSndRcvHisTableWork(reader, serInfo);
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
                    retValue = (SndRcvHisTableWork[])lst.ToArray(typeof(SndRcvHisTableWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

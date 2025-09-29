using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OprtnHisLog
    /// <summary>
    ///                      操作履歴ログデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   操作履歴ログデータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/12/15</br>
    /// <br>Genarated Date   :   2008/12/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/10/27  木村 武正</br>
    /// <br>                 :   ログデータオペレーション明細コード追加</br>
    /// <br>                 :   ログデータメッセージ内容削除</br>
    /// <br>                 :   ログオペレーションデータサイズ変更</br>
    /// <br>                 :   ログデータ作成日時　DD変更</br>
    /// <br>                 :   ログデータ対象起動プログラム名称　DD変更</br>
    /// <br>                 :   ログオペレーションデータ概要　追加</br>
    /// <br>                 :   権限レベル1　追加</br>
    /// <br>                 :   権限レベル2　追加</br>
    /// </remarks>
    public class OprtnHisLog
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

        /// <summary>ログデータ作成日時</summary>
        private DateTime _logDataCreateDtTm;

        /// <summary>ログデータGUID</summary>
        private Guid _logDataGuid;

        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCd = "";

        /// <summary>ログデータ種別区分コード</summary>
        /// <remarks>0:記録,1:エラー,9:システム</remarks>
        private Int32 _logDataKindCd;

        /// <summary>ログデータ端末名</summary>
        private string _logDataMachineName = "";

        /// <summary>ログデータ担当者コード</summary>
        private string _logDataAgentCd = "";

        /// <summary>ログデータ担当者名</summary>
        private string _logDataAgentNm = "";

        /// <summary>ログデータ対象起動プログラム名称</summary>
        /// <remarks>ログを書き込んだアセンブリの起動プログラム名称</remarks>
        private string _logDataObjBootPgName = "";

        /// <summary>ログデータ対象アセンブリID</summary>
        /// <remarks>ログを書き込んだアセンブリID</remarks>
        private string _logDataObjAssemblyID = "";

        /// <summary>ログデータ対象アセンブリ名称</summary>
        /// <remarks>ログを書き込んだアセンブリ名称</remarks>
        private string _logDataObjAssemblyNm = "";

        /// <summary>ログデータ対象クラスID</summary>
        /// <remarks>ログに書き込む原因となったクラスID</remarks>
        private string _logDataObjClassID = "";

        /// <summary>ログデータ対象処理名</summary>
        /// <remarks>ログを書き込む際の処理名(メソッド名)</remarks>
        private string _logDataObjProcNm = "";

        /// <summary>ログデータオペレーションコード</summary>
        /// <remarks>操作内容コード0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了</remarks>
        private Int32 _logDataOperationCd;

        /// <summary>ログデータオペレーターデータ処理レベル</summary>
        /// <remarks>オペレータのデータ処理時のセキュリティレベル</remarks>
        private string _logOperaterDtProcLvl = "";

        /// <summary>ログデータオペレーター機能処理レベル</summary>
        /// <remarks>オペレータのデータ処理時のセキュリティレベル</remarks>
        private string _logOperaterFuncLvl = "";

        /// <summary>ログデータシステムバージョン</summary>
        /// <remarks>プログラムのバージョン情報のバージョン</remarks>
        private string _logDataSystemVersion = "";

        /// <summary>ログデータステータス</summary>
        /// <remarks>エラーコード、結果(正常処理・取消・中断)など</remarks>
        private Int32 _logOperationStatus;

        /// <summary>ログデータオペレーション明細コード</summary>
        /// <remarks>コーディングレベルの処理コードをセット</remarks>
        private Int32 _logDataOprtnDtlCd;

        /// <summary>ログオペレーションデータ概要</summary>
        private string _logOprtnDataSummary = "";

        /// <summary>ログオペレーションデータ</summary>
        /// <remarks>エラーの原因となったデータやキー内容あるいは処理詳細など</remarks>
        private string _logOperationData = "";

        /// <summary>権限レベル1</summary>
        /// <remarks>10:事務(アルバイト),20:事務(正社員),40:バックヤード担当者,60:店頭販売員(アルバイト),70:店頭販売員(正社員),71～75:グループ1～5,80:店長</remarks>
        private Int32 _authorityLevel1;

        /// <summary>権限レベル2</summary>
        /// <remarks>10:アルバイト,50:正社員</remarks>
        private Int32 _authorityLevel2;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  LogDataCreateDtTm
        /// <summary>ログデータ作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LogDataCreateDtTm
        {
            get { return _logDataCreateDtTm; }
            set { _logDataCreateDtTm = value; }
        }

        /// public propaty name  :  LogDataCreateDtTmJpFormal
        /// <summary>ログデータ作成日時 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataCreateDtTmJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmJpInFormal
        /// <summary>ログデータ作成日時 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataCreateDtTmJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmAdFormal
        /// <summary>ログデータ作成日時 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataCreateDtTmAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmAdInFormal
        /// <summary>ログデータ作成日時 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataCreateDtTmAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataGuid
        /// <summary>ログデータGUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid LogDataGuid
        {
            get { return _logDataGuid; }
            set { _logDataGuid = value; }
        }

        /// public propaty name  :  LoginSectionCd
        /// <summary>ログイン拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginSectionCd
        {
            get { return _loginSectionCd; }
            set { _loginSectionCd = value; }
        }

        /// public propaty name  :  LogDataKindCd
        /// <summary>ログデータ種別区分コードプロパティ</summary>
        /// <value>0:記録,1:エラー,9:システム</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ種別区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogDataKindCd
        {
            get { return _logDataKindCd; }
            set { _logDataKindCd = value; }
        }

        /// public propaty name  :  LogDataMachineName
        /// <summary>ログデータ端末名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ端末名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
            set { _logDataMachineName = value; }
        }

        /// public propaty name  :  LogDataAgentCd
        /// <summary>ログデータ担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataAgentCd
        {
            get { return _logDataAgentCd; }
            set { _logDataAgentCd = value; }
        }

        /// public propaty name  :  LogDataAgentNm
        /// <summary>ログデータ担当者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ担当者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataAgentNm
        {
            get { return _logDataAgentNm; }
            set { _logDataAgentNm = value; }
        }

        /// public propaty name  :  LogDataObjBootPgName
        /// <summary>ログデータ対象起動プログラム名称プロパティ</summary>
        /// <value>ログを書き込んだアセンブリの起動プログラム名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象起動プログラム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjBootPgName
        {
            get { return _logDataObjBootPgName; }
            set { _logDataObjBootPgName = value; }
        }

        /// public propaty name  :  LogDataObjAssemblyID
        /// <summary>ログデータ対象アセンブリIDプロパティ</summary>
        /// <value>ログを書き込んだアセンブリID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjAssemblyID
        {
            get { return _logDataObjAssemblyID; }
            set { _logDataObjAssemblyID = value; }
        }

        /// public propaty name  :  LogDataObjAssemblyNm
        /// <summary>ログデータ対象アセンブリ名称プロパティ</summary>
        /// <value>ログを書き込んだアセンブリ名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象アセンブリ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjAssemblyNm
        {
            get { return _logDataObjAssemblyNm; }
            set { _logDataObjAssemblyNm = value; }
        }

        /// public propaty name  :  LogDataObjClassID
        /// <summary>ログデータ対象クラスIDプロパティ</summary>
        /// <value>ログに書き込む原因となったクラスID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象クラスIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjClassID
        {
            get { return _logDataObjClassID; }
            set { _logDataObjClassID = value; }
        }

        /// public propaty name  :  LogDataObjProcNm
        /// <summary>ログデータ対象処理名プロパティ</summary>
        /// <value>ログを書き込む際の処理名(メソッド名)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象処理名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjProcNm
        {
            get { return _logDataObjProcNm; }
            set { _logDataObjProcNm = value; }
        }

        /// public propaty name  :  LogDataOperationCd
        /// <summary>ログデータオペレーションコードプロパティ</summary>
        /// <value>操作内容コード0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータオペレーションコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogDataOperationCd
        {
            get { return _logDataOperationCd; }
            set { _logDataOperationCd = value; }
        }

        /// public propaty name  :  LogOperaterDtProcLvl
        /// <summary>ログデータオペレーターデータ処理レベルプロパティ</summary>
        /// <value>オペレータのデータ処理時のセキュリティレベル</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータオペレーターデータ処理レベルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOperaterDtProcLvl
        {
            get { return _logOperaterDtProcLvl; }
            set { _logOperaterDtProcLvl = value; }
        }

        /// public propaty name  :  LogOperaterFuncLvl
        /// <summary>ログデータオペレーター機能処理レベルプロパティ</summary>
        /// <value>オペレータのデータ処理時のセキュリティレベル</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータオペレーター機能処理レベルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOperaterFuncLvl
        {
            get { return _logOperaterFuncLvl; }
            set { _logOperaterFuncLvl = value; }
        }

        /// public propaty name  :  LogDataSystemVersion
        /// <summary>ログデータシステムバージョンプロパティ</summary>
        /// <value>プログラムのバージョン情報のバージョン</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータシステムバージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataSystemVersion
        {
            get { return _logDataSystemVersion; }
            set { _logDataSystemVersion = value; }
        }

        /// public propaty name  :  LogOperationStatus
        /// <summary>ログデータステータスプロパティ</summary>
        /// <value>エラーコード、結果(正常処理・取消・中断)など</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogOperationStatus
        {
            get { return _logOperationStatus; }
            set { _logOperationStatus = value; }
        }

        /// public propaty name  :  LogDataOprtnDtlCd
        /// <summary>ログデータオペレーション明細コードプロパティ</summary>
        /// <value>コーディングレベルの処理コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータオペレーション明細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogDataOprtnDtlCd
        {
            get { return _logDataOprtnDtlCd; }
            set { _logDataOprtnDtlCd = value; }
        }

        /// public propaty name  :  LogOprtnDataSummary
        /// <summary>ログオペレーションデータ概要プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログオペレーションデータ概要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOprtnDataSummary
        {
            get { return _logOprtnDataSummary; }
            set { _logOprtnDataSummary = value; }
        }

        /// public propaty name  :  LogOperationData
        /// <summary>ログオペレーションデータプロパティ</summary>
        /// <value>エラーの原因となったデータやキー内容あるいは処理詳細など</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログオペレーションデータプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOperationData
        {
            get { return _logOperationData; }
            set { _logOperationData = value; }
        }

        /// public propaty name  :  AuthorityLevel1
        /// <summary>権限レベル1プロパティ</summary>
        /// <value>10:事務(アルバイト),20:事務(正社員),40:バックヤード担当者,60:店頭販売員(アルバイト),70:店頭販売員(正社員),71～75:グループ1～5,80:店長</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AuthorityLevel1
        {
            get { return _authorityLevel1; }
            set { _authorityLevel1 = value; }
        }

        /// public propaty name  :  AuthorityLevel2
        /// <summary>権限レベル2プロパティ</summary>
        /// <value>10:アルバイト,50:正社員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AuthorityLevel2
        {
            get { return _authorityLevel2; }
            set { _authorityLevel2 = value; }
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


        /// <summary>
        /// 操作履歴ログデータコンストラクタ
        /// </summary>
        /// <returns>OprtnHisLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprtnHisLog()
        {
        }

        /// <summary>
        /// 操作履歴ログデータコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="logDataCreateDtTm">ログデータ作成日時</param>
        /// <param name="logDataGuid">ログデータGUID</param>
        /// <param name="loginSectionCd">ログイン拠点コード</param>
        /// <param name="logDataKindCd">ログデータ種別区分コード(0:記録,1:エラー,9:システム)</param>
        /// <param name="logDataMachineName">ログデータ端末名</param>
        /// <param name="logDataAgentCd">ログデータ担当者コード</param>
        /// <param name="logDataAgentNm">ログデータ担当者名</param>
        /// <param name="logDataObjBootPgName">ログデータ対象起動プログラム名称(ログを書き込んだアセンブリの起動プログラム名称)</param>
        /// <param name="logDataObjAssemblyID">ログデータ対象アセンブリID(ログを書き込んだアセンブリID)</param>
        /// <param name="logDataObjAssemblyNm">ログデータ対象アセンブリ名称(ログを書き込んだアセンブリ名称)</param>
        /// <param name="logDataObjClassID">ログデータ対象クラスID(ログに書き込む原因となったクラスID)</param>
        /// <param name="logDataObjProcNm">ログデータ対象処理名(ログを書き込む際の処理名(メソッド名))</param>
        /// <param name="logDataOperationCd">ログデータオペレーションコード(操作内容コード0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)</param>
        /// <param name="logOperaterDtProcLvl">ログデータオペレーターデータ処理レベル(オペレータのデータ処理時のセキュリティレベル)</param>
        /// <param name="logOperaterFuncLvl">ログデータオペレーター機能処理レベル(オペレータのデータ処理時のセキュリティレベル)</param>
        /// <param name="logDataSystemVersion">ログデータシステムバージョン(プログラムのバージョン情報のバージョン)</param>
        /// <param name="logOperationStatus">ログデータステータス(エラーコード、結果(正常処理・取消・中断)など)</param>
        /// <param name="logDataOprtnDtlCd">ログデータオペレーション明細コード(コーディングレベルの処理コードをセット)</param>
        /// <param name="logOprtnDataSummary">ログオペレーションデータ概要</param>
        /// <param name="logOperationData">ログオペレーションデータ(エラーの原因となったデータやキー内容あるいは処理詳細など)</param>
        /// <param name="authorityLevel1">権限レベル1(10:事務(アルバイト),20:事務(正社員),40:バックヤード担当者,60:店頭販売員(アルバイト),70:店頭販売員(正社員),71～75:グループ1～5,80:店長)</param>
        /// <param name="authorityLevel2">権限レベル2(10:アルバイト,50:正社員)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>OprtnHisLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprtnHisLog(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, DateTime logDataCreateDtTm, Guid logDataGuid, string loginSectionCd, Int32 logDataKindCd, string logDataMachineName, string logDataAgentCd, string logDataAgentNm, string logDataObjBootPgName, string logDataObjAssemblyID, string logDataObjAssemblyNm, string logDataObjClassID, string logDataObjProcNm, Int32 logDataOperationCd, string logOperaterDtProcLvl, string logOperaterFuncLvl, string logDataSystemVersion, Int32 logOperationStatus, Int32 logDataOprtnDtlCd, string logOprtnDataSummary, string logOperationData, Int32 authorityLevel1, Int32 authorityLevel2, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this.LogDataCreateDtTm = logDataCreateDtTm;
            this.LogDataGuid = logDataGuid;
            this._loginSectionCd = loginSectionCd;
            this._logDataKindCd = logDataKindCd;
            this._logDataMachineName = logDataMachineName;
            this._logDataAgentCd = logDataAgentCd;
            this._logDataAgentNm = logDataAgentNm;
            this._logDataObjBootPgName = logDataObjBootPgName;
            this._logDataObjAssemblyID = logDataObjAssemblyID;
            this._logDataObjAssemblyNm = logDataObjAssemblyNm;
            this._logDataObjClassID = logDataObjClassID;
            this._logDataObjProcNm = logDataObjProcNm;
            this._logDataOperationCd = logDataOperationCd;
            this._logOperaterDtProcLvl = logOperaterDtProcLvl;
            this._logOperaterFuncLvl = logOperaterFuncLvl;
            this._logDataSystemVersion = logDataSystemVersion;
            this._logOperationStatus = logOperationStatus;
            this._logDataOprtnDtlCd = logDataOprtnDtlCd;
            this._logOprtnDataSummary = logOprtnDataSummary;
            this._logOperationData = logOperationData;
            this._authorityLevel1 = authorityLevel1;
            this._authorityLevel2 = authorityLevel2;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 操作履歴ログデータ複製処理
        /// </summary>
        /// <returns>OprtnHisLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOprtnHisLogクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprtnHisLog Clone()
        {
            return new OprtnHisLog(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._logDataCreateDtTm, this._logDataGuid, this._loginSectionCd, this._logDataKindCd, this._logDataMachineName, this._logDataAgentCd, this._logDataAgentNm, this._logDataObjBootPgName, this._logDataObjAssemblyID, this._logDataObjAssemblyNm, this._logDataObjClassID, this._logDataObjProcNm, this._logDataOperationCd, this._logOperaterDtProcLvl, this._logOperaterFuncLvl, this._logDataSystemVersion, this._logOperationStatus, this._logDataOprtnDtlCd, this._logOprtnDataSummary, this._logOperationData, this._authorityLevel1, this._authorityLevel2, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 操作履歴ログデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のOprtnHisLogクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(OprtnHisLog target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.LogDataCreateDtTm == target.LogDataCreateDtTm)
                 && (this.LogDataGuid == target.LogDataGuid)
                 && (this.LoginSectionCd == target.LoginSectionCd)
                 && (this.LogDataKindCd == target.LogDataKindCd)
                 && (this.LogDataMachineName == target.LogDataMachineName)
                 && (this.LogDataAgentCd == target.LogDataAgentCd)
                 && (this.LogDataAgentNm == target.LogDataAgentNm)
                 && (this.LogDataObjBootPgName == target.LogDataObjBootPgName)
                 && (this.LogDataObjAssemblyID == target.LogDataObjAssemblyID)
                 && (this.LogDataObjAssemblyNm == target.LogDataObjAssemblyNm)
                 && (this.LogDataObjClassID == target.LogDataObjClassID)
                 && (this.LogDataObjProcNm == target.LogDataObjProcNm)
                 && (this.LogDataOperationCd == target.LogDataOperationCd)
                 && (this.LogOperaterDtProcLvl == target.LogOperaterDtProcLvl)
                 && (this.LogOperaterFuncLvl == target.LogOperaterFuncLvl)
                 && (this.LogDataSystemVersion == target.LogDataSystemVersion)
                 && (this.LogOperationStatus == target.LogOperationStatus)
                 && (this.LogDataOprtnDtlCd == target.LogDataOprtnDtlCd)
                 && (this.LogOprtnDataSummary == target.LogOprtnDataSummary)
                 && (this.LogOperationData == target.LogOperationData)
                 && (this.AuthorityLevel1 == target.AuthorityLevel1)
                 && (this.AuthorityLevel2 == target.AuthorityLevel2)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 操作履歴ログデータ比較処理
        /// </summary>
        /// <param name="oprtnHisLog1">
        ///                    比較するOprtnHisLogクラスのインスタンス
        /// </param>
        /// <param name="oprtnHisLog2">比較するOprtnHisLogクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(OprtnHisLog oprtnHisLog1, OprtnHisLog oprtnHisLog2)
        {
            return ((oprtnHisLog1.CreateDateTime == oprtnHisLog2.CreateDateTime)
                 && (oprtnHisLog1.UpdateDateTime == oprtnHisLog2.UpdateDateTime)
                 && (oprtnHisLog1.EnterpriseCode == oprtnHisLog2.EnterpriseCode)
                 && (oprtnHisLog1.FileHeaderGuid == oprtnHisLog2.FileHeaderGuid)
                 && (oprtnHisLog1.UpdEmployeeCode == oprtnHisLog2.UpdEmployeeCode)
                 && (oprtnHisLog1.UpdAssemblyId1 == oprtnHisLog2.UpdAssemblyId1)
                 && (oprtnHisLog1.UpdAssemblyId2 == oprtnHisLog2.UpdAssemblyId2)
                 && (oprtnHisLog1.LogicalDeleteCode == oprtnHisLog2.LogicalDeleteCode)
                 && (oprtnHisLog1.LogDataCreateDtTm == oprtnHisLog2.LogDataCreateDtTm)
                 && (oprtnHisLog1.LogDataGuid == oprtnHisLog2.LogDataGuid)
                 && (oprtnHisLog1.LoginSectionCd == oprtnHisLog2.LoginSectionCd)
                 && (oprtnHisLog1.LogDataKindCd == oprtnHisLog2.LogDataKindCd)
                 && (oprtnHisLog1.LogDataMachineName == oprtnHisLog2.LogDataMachineName)
                 && (oprtnHisLog1.LogDataAgentCd == oprtnHisLog2.LogDataAgentCd)
                 && (oprtnHisLog1.LogDataAgentNm == oprtnHisLog2.LogDataAgentNm)
                 && (oprtnHisLog1.LogDataObjBootPgName == oprtnHisLog2.LogDataObjBootPgName)
                 && (oprtnHisLog1.LogDataObjAssemblyID == oprtnHisLog2.LogDataObjAssemblyID)
                 && (oprtnHisLog1.LogDataObjAssemblyNm == oprtnHisLog2.LogDataObjAssemblyNm)
                 && (oprtnHisLog1.LogDataObjClassID == oprtnHisLog2.LogDataObjClassID)
                 && (oprtnHisLog1.LogDataObjProcNm == oprtnHisLog2.LogDataObjProcNm)
                 && (oprtnHisLog1.LogDataOperationCd == oprtnHisLog2.LogDataOperationCd)
                 && (oprtnHisLog1.LogOperaterDtProcLvl == oprtnHisLog2.LogOperaterDtProcLvl)
                 && (oprtnHisLog1.LogOperaterFuncLvl == oprtnHisLog2.LogOperaterFuncLvl)
                 && (oprtnHisLog1.LogDataSystemVersion == oprtnHisLog2.LogDataSystemVersion)
                 && (oprtnHisLog1.LogOperationStatus == oprtnHisLog2.LogOperationStatus)
                 && (oprtnHisLog1.LogDataOprtnDtlCd == oprtnHisLog2.LogDataOprtnDtlCd)
                 && (oprtnHisLog1.LogOprtnDataSummary == oprtnHisLog2.LogOprtnDataSummary)
                 && (oprtnHisLog1.LogOperationData == oprtnHisLog2.LogOperationData)
                 && (oprtnHisLog1.AuthorityLevel1 == oprtnHisLog2.AuthorityLevel1)
                 && (oprtnHisLog1.AuthorityLevel2 == oprtnHisLog2.AuthorityLevel2)
                 && (oprtnHisLog1.EnterpriseName == oprtnHisLog2.EnterpriseName)
                 && (oprtnHisLog1.UpdEmployeeName == oprtnHisLog2.UpdEmployeeName));
        }
        /// <summary>
        /// 操作履歴ログデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のOprtnHisLogクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(OprtnHisLog target)
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
            if (this.LogDataCreateDtTm != target.LogDataCreateDtTm) resList.Add("LogDataCreateDtTm");
            if (this.LogDataGuid != target.LogDataGuid) resList.Add("LogDataGuid");
            if (this.LoginSectionCd != target.LoginSectionCd) resList.Add("LoginSectionCd");
            if (this.LogDataKindCd != target.LogDataKindCd) resList.Add("LogDataKindCd");
            if (this.LogDataMachineName != target.LogDataMachineName) resList.Add("LogDataMachineName");
            if (this.LogDataAgentCd != target.LogDataAgentCd) resList.Add("LogDataAgentCd");
            if (this.LogDataAgentNm != target.LogDataAgentNm) resList.Add("LogDataAgentNm");
            if (this.LogDataObjBootPgName != target.LogDataObjBootPgName) resList.Add("LogDataObjBootPgName");
            if (this.LogDataObjAssemblyID != target.LogDataObjAssemblyID) resList.Add("LogDataObjAssemblyID");
            if (this.LogDataObjAssemblyNm != target.LogDataObjAssemblyNm) resList.Add("LogDataObjAssemblyNm");
            if (this.LogDataObjClassID != target.LogDataObjClassID) resList.Add("LogDataObjClassID");
            if (this.LogDataObjProcNm != target.LogDataObjProcNm) resList.Add("LogDataObjProcNm");
            if (this.LogDataOperationCd != target.LogDataOperationCd) resList.Add("LogDataOperationCd");
            if (this.LogOperaterDtProcLvl != target.LogOperaterDtProcLvl) resList.Add("LogOperaterDtProcLvl");
            if (this.LogOperaterFuncLvl != target.LogOperaterFuncLvl) resList.Add("LogOperaterFuncLvl");
            if (this.LogDataSystemVersion != target.LogDataSystemVersion) resList.Add("LogDataSystemVersion");
            if (this.LogOperationStatus != target.LogOperationStatus) resList.Add("LogOperationStatus");
            if (this.LogDataOprtnDtlCd != target.LogDataOprtnDtlCd) resList.Add("LogDataOprtnDtlCd");
            if (this.LogOprtnDataSummary != target.LogOprtnDataSummary) resList.Add("LogOprtnDataSummary");
            if (this.LogOperationData != target.LogOperationData) resList.Add("LogOperationData");
            if (this.AuthorityLevel1 != target.AuthorityLevel1) resList.Add("AuthorityLevel1");
            if (this.AuthorityLevel2 != target.AuthorityLevel2) resList.Add("AuthorityLevel2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 操作履歴ログデータ比較処理
        /// </summary>
        /// <param name="oprtnHisLog1">比較するOprtnHisLogクラスのインスタンス</param>
        /// <param name="oprtnHisLog2">比較するOprtnHisLogクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(OprtnHisLog oprtnHisLog1, OprtnHisLog oprtnHisLog2)
        {
            ArrayList resList = new ArrayList();
            if (oprtnHisLog1.CreateDateTime != oprtnHisLog2.CreateDateTime) resList.Add("CreateDateTime");
            if (oprtnHisLog1.UpdateDateTime != oprtnHisLog2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oprtnHisLog1.EnterpriseCode != oprtnHisLog2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (oprtnHisLog1.FileHeaderGuid != oprtnHisLog2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (oprtnHisLog1.UpdEmployeeCode != oprtnHisLog2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (oprtnHisLog1.UpdAssemblyId1 != oprtnHisLog2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (oprtnHisLog1.UpdAssemblyId2 != oprtnHisLog2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (oprtnHisLog1.LogicalDeleteCode != oprtnHisLog2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oprtnHisLog1.LogDataCreateDtTm != oprtnHisLog2.LogDataCreateDtTm) resList.Add("LogDataCreateDtTm");
            if (oprtnHisLog1.LogDataGuid != oprtnHisLog2.LogDataGuid) resList.Add("LogDataGuid");
            if (oprtnHisLog1.LoginSectionCd != oprtnHisLog2.LoginSectionCd) resList.Add("LoginSectionCd");
            if (oprtnHisLog1.LogDataKindCd != oprtnHisLog2.LogDataKindCd) resList.Add("LogDataKindCd");
            if (oprtnHisLog1.LogDataMachineName != oprtnHisLog2.LogDataMachineName) resList.Add("LogDataMachineName");
            if (oprtnHisLog1.LogDataAgentCd != oprtnHisLog2.LogDataAgentCd) resList.Add("LogDataAgentCd");
            if (oprtnHisLog1.LogDataAgentNm != oprtnHisLog2.LogDataAgentNm) resList.Add("LogDataAgentNm");
            if (oprtnHisLog1.LogDataObjBootPgName != oprtnHisLog2.LogDataObjBootPgName) resList.Add("LogDataObjBootPgName");
            if (oprtnHisLog1.LogDataObjAssemblyID != oprtnHisLog2.LogDataObjAssemblyID) resList.Add("LogDataObjAssemblyID");
            if (oprtnHisLog1.LogDataObjAssemblyNm != oprtnHisLog2.LogDataObjAssemblyNm) resList.Add("LogDataObjAssemblyNm");
            if (oprtnHisLog1.LogDataObjClassID != oprtnHisLog2.LogDataObjClassID) resList.Add("LogDataObjClassID");
            if (oprtnHisLog1.LogDataObjProcNm != oprtnHisLog2.LogDataObjProcNm) resList.Add("LogDataObjProcNm");
            if (oprtnHisLog1.LogDataOperationCd != oprtnHisLog2.LogDataOperationCd) resList.Add("LogDataOperationCd");
            if (oprtnHisLog1.LogOperaterDtProcLvl != oprtnHisLog2.LogOperaterDtProcLvl) resList.Add("LogOperaterDtProcLvl");
            if (oprtnHisLog1.LogOperaterFuncLvl != oprtnHisLog2.LogOperaterFuncLvl) resList.Add("LogOperaterFuncLvl");
            if (oprtnHisLog1.LogDataSystemVersion != oprtnHisLog2.LogDataSystemVersion) resList.Add("LogDataSystemVersion");
            if (oprtnHisLog1.LogOperationStatus != oprtnHisLog2.LogOperationStatus) resList.Add("LogOperationStatus");
            if (oprtnHisLog1.LogDataOprtnDtlCd != oprtnHisLog2.LogDataOprtnDtlCd) resList.Add("LogDataOprtnDtlCd");
            if (oprtnHisLog1.LogOprtnDataSummary != oprtnHisLog2.LogOprtnDataSummary) resList.Add("LogOprtnDataSummary");
            if (oprtnHisLog1.LogOperationData != oprtnHisLog2.LogOperationData) resList.Add("LogOperationData");
            if (oprtnHisLog1.AuthorityLevel1 != oprtnHisLog2.AuthorityLevel1) resList.Add("AuthorityLevel1");
            if (oprtnHisLog1.AuthorityLevel2 != oprtnHisLog2.AuthorityLevel2) resList.Add("AuthorityLevel2");
            if (oprtnHisLog1.EnterpriseName != oprtnHisLog2.EnterpriseName) resList.Add("EnterpriseName");
            if (oprtnHisLog1.UpdEmployeeName != oprtnHisLog2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// サイズ取得
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 0;

            // 作成日時
            size += sizeof(Int64);

            // 更新日時
            size += sizeof(Int64);

            // 企業コード
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._enterpriseCode);

            // GUID
            size += System.Runtime.InteropServices.Marshal.SizeOf(this._fileHeaderGuid);

            // 更新従業員コード
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updEmployeeCode);

            // 更新アセンブリID1
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updAssemblyId1);

            // 更新アセンブリID2
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updAssemblyId2);

            // 論理削除区分
            size += sizeof(Int32);

            // ログデータ作成日時
            size += sizeof(Int64);

            // ログデータGUID
            size += System.Runtime.InteropServices.Marshal.SizeOf(this._logDataGuid);

            // ログイン拠点コード
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._loginSectionCd);

            // ログデータ種別区分コード
            size += sizeof(Int32);

            // ログデータ端末名
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataMachineName);

            // ログデータ担当者コード
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataAgentCd);

            // ログデータ担当者名
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataAgentNm);

            // ログデータ対象起動プログラム名称
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjBootPgName);

            // ログデータ対象アセンブリID
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjAssemblyID);

            // ログデータ対象アセンブリ名称
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjAssemblyNm);

            // ログデータ対象クラスID
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjClassID);

            // ログデータ対象処理名
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjProcNm);

            // ログデータオペレーションコード
            size += sizeof(Int32);

            // ログデータオペレーターデータ処理レベル
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperaterDtProcLvl);

            // ログデータオペレーター機能処理レベル
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperaterFuncLvl);

            // ログデータシステムバージョン
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataSystemVersion);

            // ログオペレーションステータス
            size += sizeof(Int32);

            // ↓↓↓2008.12.16 T-Kidate ADD
            // ログデータオペレーション明細コード
            size += sizeof(Int32);

            // ログデータメッセージ内容
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOprtnDataSummary);

            // ログオペレーションデータ
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperationData);

            // ↓↓↓2008.12.16 T-Kidate ADD
            // 権限レベル１
            size += sizeof(Int32);
            // 権限レベル２
            size += sizeof(Int32);

            return size;
        }


    }
}

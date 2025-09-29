//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力操作ログ登録処理
// プログラム概要   : テキスト出力操作ログ登録処理登録用
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00  作成担当 : 田建委
// 作 成 日  2019/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TextOutPutOprtnHisLogWork
    /// <summary>
    ///                      テキスト出力操作ログ登録処理登録用ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   テキスト出力操作ログ登録処理登録用ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2019/08/12</br>
    /// <br>Genarated Date   :   2019/08/12  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TextOutPutOprtnHisLogWork : IFileHeader
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
        private DateTime _logDataCreateDateTime;

        /// <summary>テキスト出力ログNo</summary>
        private Int64 _textOutLogNo;

        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCd = "";

        /// <summary>ログデータ種別区分コード</summary>
        /// <remarks>0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)</remarks>
        private Int32 _logDataKindCd;

        /// <summary>ログデータ端末名</summary>
        private string _logDataMachineName = "";

        /// <summary>ログデータ担当者コード</summary>
        private string _logDataAgentCd = "";

        /// <summary>ログデータ担当者名</summary>
        private string _logDataAgentNm = "";

        /// <summary>ログデータ対象起動プログラム名称</summary>
        /// <remarks>ログを書き込んだアセンブリの起動プログラム名称</remarks>
        private string _logDataObjBootProgramNm = "";

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
        /// <remarks>操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)</remarks>
        private Int32 _logDataOperationCd;

        /// <summary>ログデータオペレーターデータ処理レベル</summary>
        /// <remarks>ｵﾍﾟﾚｰﾀのﾃﾞｰﾀ処理時のｾｷｭﾘﾃｨﾚﾍﾞﾙ</remarks>
        private string _logOperaterDtProcLvl = "";

        /// <summary>ログデータオペレーター機能処理レベル</summary>
        /// <remarks>ｵﾍﾟﾚｰﾀのﾃﾞｰﾀ処理時のｾｷｭﾘﾃｨﾚﾍﾞﾙ</remarks>
        private string _logOperaterFuncLvl = "";

        /// <summary>ログデータシステムバージョン</summary>
        /// <remarks>プログラムのバージョン情報のバージョン</remarks>
        private string _logDataSystemVersion = "";

        /// <summary>ログオペレーションステータス</summary>
        /// <remarks>オペレーション結果ステータス</remarks>
        private Int32 _logOperationStatus;

        /// <summary>ログオペレーションステータス</summary>
        /// <remarks>ログデータ抽出データ件数</remarks>
        private Int32 _logDataCount;

        /// <summary>ログオペレーションデータ</summary>
        /// <remarks>エラーの原因となったデータやキー内容・或るは処理詳細など</remarks>
        private string _logOperationData = "";


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

        /// public propaty name  :  LogDataCreateDateTime
        /// <summary>ログデータ作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LogDataCreateDateTime
        {
            get { return _logDataCreateDateTime; }
            set { _logDataCreateDateTime = value; }
        }

        /// public propaty name  :  TextOutLogNo
        /// <summary>テキスト出力ログNo</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テキスト出力ログNo</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TextOutLogNo
        {
            get { return _textOutLogNo; }
            set { _textOutLogNo = value; }
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
        /// <value>0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)</value>
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

        /// public propaty name  :  LogDataObjBootProgramNm
        /// <summary>ログデータ対象起動プログラム名称プロパティ</summary>
        /// <value>ログを書き込んだアセンブリの起動プログラム名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ対象起動プログラム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjBootProgramNm
        {
            get { return _logDataObjBootProgramNm; }
            set { _logDataObjBootProgramNm = value; }
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
        /// <value>操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)</value>
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
        /// <value>ｵﾍﾟﾚｰﾀのﾃﾞｰﾀ処理時のｾｷｭﾘﾃｨﾚﾍﾞﾙ</value>
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
        /// <value>ｵﾍﾟﾚｰﾀのﾃﾞｰﾀ処理時のｾｷｭﾘﾃｨﾚﾍﾞﾙ</value>
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
        /// <summary>ログオペレーションステータスプロパティ</summary>
        /// <value>オペレーション結果ステータス</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログオペレーションステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogOperationStatus
        {
            get { return _logOperationStatus; }
            set { _logOperationStatus = value; }
        }

        /// public propaty name  :  LogDataCount
        /// <summary>ログオペレーションステータスプロパティ</summary>
        /// <value>ログデータ抽出データ件数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータ抽出データ件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogDataCount
        {
            get { return _logDataCount; }
            set { _logDataCount = value; }
        }

        /// public propaty name  :  LogOperationData
        /// <summary>ログオペレーションデータプロパティ</summary>
        /// <value>エラーの原因となったデータやキー内容・或るは処理詳細など</value>
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


        /// <summary>
        /// テキスト出力操作ログ登録処理登録用クラスワークコンストラクタ
        /// </summary>
        /// <returns>TextOutPutOprtnHisLogWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TextOutPutOprtnHisLogWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TextOutPutOprtnHisLogWork()
        {
        }

    }
}

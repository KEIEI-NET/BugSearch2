using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OprtnHisLogWork
    /// <summary>
    ///                      操作履歴ログ表示クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   操作履歴ログ表示クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OprtnHisLogWork : IFileHeader
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

        /// <summary>ログデータGUID</summary>
        private Guid _logDataGuid;

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

        /// <summary>ログデータメッセージ</summary>
        /// <remarks>エラー内容・処理内容など</remarks>
        private string _logDataMassage = "";

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

        /// public propaty name  :  LogDataMassage
        /// <summary>ログデータメッセージプロパティ</summary>
        /// <value>エラー内容・処理内容など</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataMassage
        {
            get { return _logDataMassage; }
            set { _logDataMassage = value; }
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
        /// 操作履歴ログ表示クラスワークコンストラクタ
        /// </summary>
        /// <returns>OprtnHisLogWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprtnHisLogWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OprtnHisLogWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OprtnHisLogWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OprtnHisLogWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OprtnHisLogWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OprtnHisLogWork || graph is ArrayList || graph is OprtnHisLogWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OprtnHisLogWork).FullName));

            if (graph != null && graph is OprtnHisLogWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OprtnHisLogWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OprtnHisLogWork[])graph).Length;
            }
            else if (graph is OprtnHisLogWork)
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
            //ログデータ作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //LogDataCreateDateTime
            //ログデータGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //LogDataGuid
            //ログイン拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //LoginSectionCd
            //ログデータ種別区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //LogDataKindCd
            //ログデータ端末名
            serInfo.MemberInfo.Add(typeof(string)); //LogDataMachineName
            //ログデータ担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //LogDataAgentCd
            //ログデータ担当者名
            serInfo.MemberInfo.Add(typeof(string)); //LogDataAgentNm
            //ログデータ対象起動プログラム名称
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjBootProgramNm
            //ログデータ対象アセンブリID
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjAssemblyID
            //ログデータ対象アセンブリ名称
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjAssemblyNm
            //ログデータ対象クラスID
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjClassID
            //ログデータ対象処理名
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjProcNm
            //ログデータオペレーションコード
            serInfo.MemberInfo.Add(typeof(Int32)); //LogDataOperationCd
            //ログデータオペレーターデータ処理レベル
            serInfo.MemberInfo.Add(typeof(string)); //LogOperaterDtProcLvl
            //ログデータオペレーター機能処理レベル
            serInfo.MemberInfo.Add(typeof(string)); //LogOperaterFuncLvl
            //ログデータシステムバージョン
            serInfo.MemberInfo.Add(typeof(string)); //LogDataSystemVersion
            //ログオペレーションステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //LogOperationStatus
            //ログデータメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //LogDataMassage
            //ログオペレーションデータ
            serInfo.MemberInfo.Add(typeof(string)); //LogOperationData


            serInfo.Serialize(writer, serInfo);
            if (graph is OprtnHisLogWork)
            {
                OprtnHisLogWork temp = (OprtnHisLogWork)graph;

                SetOprtnHisLogWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OprtnHisLogWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OprtnHisLogWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OprtnHisLogWork temp in lst)
                {
                    SetOprtnHisLogWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OprtnHisLogWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  OprtnHisLogWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOprtnHisLogWork(System.IO.BinaryWriter writer, OprtnHisLogWork temp)
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
            //ログデータ作成日時
            writer.Write((Int64)temp.LogDataCreateDateTime.Ticks);
            //ログデータGUID
            byte[] logDataGuidArray = temp.LogDataGuid.ToByteArray();
            writer.Write(logDataGuidArray.Length);
            writer.Write(temp.LogDataGuid.ToByteArray());
            //ログイン拠点コード
            writer.Write(temp.LoginSectionCd);
            //ログデータ種別区分コード
            writer.Write(temp.LogDataKindCd);
            //ログデータ端末名
            writer.Write(temp.LogDataMachineName);
            //ログデータ担当者コード
            writer.Write(temp.LogDataAgentCd);
            //ログデータ担当者名
            writer.Write(temp.LogDataAgentNm);
            //ログデータ対象起動プログラム名称
            writer.Write(temp.LogDataObjBootProgramNm);
            //ログデータ対象アセンブリID
            writer.Write(temp.LogDataObjAssemblyID);
            //ログデータ対象アセンブリ名称
            writer.Write(temp.LogDataObjAssemblyNm);
            //ログデータ対象クラスID
            writer.Write(temp.LogDataObjClassID);
            //ログデータ対象処理名
            writer.Write(temp.LogDataObjProcNm);
            //ログデータオペレーションコード
            writer.Write(temp.LogDataOperationCd);
            //ログデータオペレーターデータ処理レベル
            writer.Write(temp.LogOperaterDtProcLvl);
            //ログデータオペレーター機能処理レベル
            writer.Write(temp.LogOperaterFuncLvl);
            //ログデータシステムバージョン
            writer.Write(temp.LogDataSystemVersion);
            //ログオペレーションステータス
            writer.Write(temp.LogOperationStatus);
            //ログデータメッセージ
            writer.Write(temp.LogDataMassage);
            //ログオペレーションデータ
            writer.Write(temp.LogOperationData);

        }

        /// <summary>
        ///  OprtnHisLogWorkインスタンス取得
        /// </summary>
        /// <returns>OprtnHisLogWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OprtnHisLogWork GetOprtnHisLogWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OprtnHisLogWork temp = new OprtnHisLogWork();

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
            //ログデータ作成日時
            temp.LogDataCreateDateTime = new DateTime(reader.ReadInt64());
            //ログデータGUID
            int lenOfLogDataGuidArray = reader.ReadInt32();
            byte[] logDataGuidArray = reader.ReadBytes(lenOfLogDataGuidArray);
            temp.LogDataGuid = new Guid(logDataGuidArray);
            //ログイン拠点コード
            temp.LoginSectionCd = reader.ReadString();
            //ログデータ種別区分コード
            temp.LogDataKindCd = reader.ReadInt32();
            //ログデータ端末名
            temp.LogDataMachineName = reader.ReadString();
            //ログデータ担当者コード
            temp.LogDataAgentCd = reader.ReadString();
            //ログデータ担当者名
            temp.LogDataAgentNm = reader.ReadString();
            //ログデータ対象起動プログラム名称
            temp.LogDataObjBootProgramNm = reader.ReadString();
            //ログデータ対象アセンブリID
            temp.LogDataObjAssemblyID = reader.ReadString();
            //ログデータ対象アセンブリ名称
            temp.LogDataObjAssemblyNm = reader.ReadString();
            //ログデータ対象クラスID
            temp.LogDataObjClassID = reader.ReadString();
            //ログデータ対象処理名
            temp.LogDataObjProcNm = reader.ReadString();
            //ログデータオペレーションコード
            temp.LogDataOperationCd = reader.ReadInt32();
            //ログデータオペレーターデータ処理レベル
            temp.LogOperaterDtProcLvl = reader.ReadString();
            //ログデータオペレーター機能処理レベル
            temp.LogOperaterFuncLvl = reader.ReadString();
            //ログデータシステムバージョン
            temp.LogDataSystemVersion = reader.ReadString();
            //ログオペレーションステータス
            temp.LogOperationStatus = reader.ReadInt32();
            //ログデータメッセージ
            temp.LogDataMassage = reader.ReadString();
            //ログオペレーションデータ
            temp.LogOperationData = reader.ReadString();


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
        /// <returns>OprtnHisLogWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprtnHisLogWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OprtnHisLogWork temp = GetOprtnHisLogWork(reader, serInfo);
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
                    retValue = (OprtnHisLogWork[])lst.ToArray(typeof(OprtnHisLogWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

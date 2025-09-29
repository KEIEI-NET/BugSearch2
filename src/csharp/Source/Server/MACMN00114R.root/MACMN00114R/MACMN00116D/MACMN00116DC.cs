using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OprationLogOrderWorkWork
    /// <summary>
    ///                      操作履歴ログ抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   操作履歴ログ抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OprationLogOrderWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string[] _sectionCodes;

        /// <summary>ログデータ端末名</summary>
        private string _logDataMachineName = "";

        /// <summary>発注先コード</summary>
        /// <remarks>ログに書き込む原因となったクラスID　(UOE発注先コード)</remarks>
        private string _logDataObjClassID = "";

        /// <summary>開始ログデータ作成日時</summary>
        private DateTime _st_LogDataCreateDateTime;

        /// <summary>終了ログデータ作成日時</summary>
        private DateTime _ed_LogDataCreateDateTime;

        /// <summary>ログデータ種別区分コード</summary>
        /// <remarks>0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)</remarks>
        private Int32 _logDataKindCd;


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
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

        /// public propaty name  :  LogDataObjClassID
        /// <summary>発注先コードプロパティ</summary>
        /// <value>ログに書き込む原因となったクラスID　(UOE発注先コード)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogDataObjClassID
        {
            get { return _logDataObjClassID; }
            set { _logDataObjClassID = value; }
        }

        /// public propaty name  :  St_LogDataCreateDateTime
        /// <summary>開始ログデータ作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ログデータ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_LogDataCreateDateTime
        {
            get { return _st_LogDataCreateDateTime; }
            set { _st_LogDataCreateDateTime = value; }
        }

        /// public propaty name  :  Ed_LogDataCreateDateTime
        /// <summary>終了ログデータ作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ログデータ作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_LogDataCreateDateTime
        {
            get { return _ed_LogDataCreateDateTime; }
            set { _ed_LogDataCreateDateTime = value; }
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


        /// <summary>
        /// 操作履歴ログ抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>OprationLogOrderWorkWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OprationLogOrderWorkWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprationLogOrderWork()
        {
        }

    }
}

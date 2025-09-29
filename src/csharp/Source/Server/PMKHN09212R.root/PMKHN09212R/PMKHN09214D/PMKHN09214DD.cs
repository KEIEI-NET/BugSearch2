using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriUpdHistCondWork
    /// <summary>
    ///                      価格改正履歴取得条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   価格改正履歴取得条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class PriUpdHistCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>シンク実行日付開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _startDate;

        /// <summary>シンク実行日付終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _endDate;


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

        /// public propaty name  :  StartDate
        /// <summary>シンク実行日付開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        /// public propaty name  :  EndDate
        /// <summary>シンク実行日付終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }


        /// <summary>
        /// 価格改正履歴取得条件ワークコンストラクタ
        /// </summary>
        /// <returns>PriUpdHistCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdHistCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriUpdHistCondWork()
        {
        }

    }
}

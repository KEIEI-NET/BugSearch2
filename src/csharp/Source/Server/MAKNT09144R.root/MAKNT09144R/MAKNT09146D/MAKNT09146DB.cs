using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HolidaySettingSearchWork
    /// <summary>
    ///                      休業日設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   休業日設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/07/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HolidaySettingSearchWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コードリスト</summary>
        private string[] _sectionCodeList = null;

        /// <summary>適用開始日(検索用)</summary>
        private DateTime _applyStaDate;

        /// <summary>適用終了日(検索用)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

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

        /// public propaty name  :  SectionCodeList
        /// <summary>拠点コードプロパティ(配列)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ(配列)</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日(検索用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日(検索用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日(検索用)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日(検索用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }


        /// <summary>
        /// 休業日設定ワークコンストラクタ
        /// </summary>
        /// <returns>HolidaySettingSearchWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HolidaySettingSearchWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HolidaySettingSearchWork()
        {
        }

    }

}

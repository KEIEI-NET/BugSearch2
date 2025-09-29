using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ShipmentPartsDspParam
    /// <summary>
    ///                      出荷部品表示条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷部品表示条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// </remarks>
    public class ShipmentPartsDspParam
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _sectionCode = "";

        /// <summary>対象年月(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stAddUpYearMonth;

        /// <summary>対象年月(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edAddUpYearMonth;

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

        /// public propaty name  :  AddUpSecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
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

        /// public propaty name  :  StAddUpYearMonth
        /// <summary>計上年月(開始)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StAddUpYearMonth
        {
            get { return _stAddUpYearMonth; }
            set { _stAddUpYearMonth = value; }
        }

        /// public propaty name  :  EdAddUpYearMonth
        /// <summary>計上年月(終了)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdAddUpYearMonth
        {
            get { return _edAddUpYearMonth; }
            set { _edAddUpYearMonth = value; }
        }

        /// <summary>
        /// 出荷部品表示条件クラスコンストラクタ
        /// </summary>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspParam()
        {
        }

        /// <summary>
        /// 出荷部品表示条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="stAddUpYearMonth">計上年月(開始)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">計上年月(終了)(YYYYMM)</param>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspParam(string enterpriseCode,string sectionCode, DateTime stAddUpYearMonth, DateTime edAddUpYearMonth)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._stAddUpYearMonth = stAddUpYearMonth;
            this._edAddUpYearMonth = edAddUpYearMonth;
        }

        /// <summary>
        /// 出荷部品表示条件クラス複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspParam Clone()
        {
            return new ShipmentPartsDspParam(this._enterpriseCode, this._sectionCode, this._stAddUpYearMonth, this._edAddUpYearMonth);
        }
    }
}

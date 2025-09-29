//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタガイド検索条件情報クラス
// プログラム概要   : 車輌管理マスタガイドを出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 車輌管理マスタガイド検索条件情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売車輌管理マスタガイド検索条件情報初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009/09/07</br>
    /// </remarks>
    public class CarMngGuideParamInfo
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先チェックかどうか</summary>
        private bool _isCheckCustomerCode;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>車輌管理コードチェックかどうか</summary>
        private bool _isCheckCarMngCode;

        /// <summary>車輌管理コードチェック方式</summary>
        /// <remarks>0:完全一致、1:前方一致、2:後方一致、3:含み</remarks>
        private Int32 _checkCarMngCodeType;

        /// <summary>車輌管理コードチェックかどうか</summary>
        private bool _isCheckCarMngDivCd;

        /// <summary>得意先情報表示フラグ</summary>
        private bool _isDispCustomerInfo;

        /// <summary>新規登録行表示フラグ</summary>
        private bool _isDispNewRow;

        /// <summary>ガイドクリックフラグ</summary>
        private bool _isGuideClick;

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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  IsCheckCustomerCode
        /// <summary>得意先コードチェックかどうかプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードチェックかどうかプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsCheckCustomerCode
        {
            get { return _isCheckCustomerCode; }
            set { _isCheckCustomerCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  IsCheckCarMngCode
        /// <summary>車輌管理コードチェックかどうかプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードチェックかどうかプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsCheckCarMngCode
        {
            get { return _isCheckCarMngCode; }
            set { _isCheckCarMngCode = value; }
        }

        /// public propaty name  :  CheckCarMngCodeType
        /// <summary>車輌管理コードチェック方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードチェック方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckCarMngCodeType
        {
            get { return _checkCarMngCodeType; }
            set { _checkCarMngCodeType = value; }
        }

        /// public propaty name  :  IsCheckCarMngCode
        /// <summary>車輌管理区分チェックかどうかプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理区分チェックかどうかプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsCheckCarMngDivCd
        {
            get { return _isCheckCarMngDivCd; }
            set { _isCheckCarMngDivCd = value; }
        }

        /// public propaty name  :  IsDispCustomerInfo
        /// <summary>得意先表示フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先表示フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsDispCustomerInfo
        {
            get { return _isDispCustomerInfo; }
            set { _isDispCustomerInfo = value; }
        }

        /// public propaty name  :  IsDispNewRow
        /// <summary>新規登録行表示フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新規登録行表示フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsDispNewRow
        {
            get { return _isDispNewRow; }
            set { _isDispNewRow = value; }
        }

        /// public propaty name  :  IsGuideClick
        /// <summary>ガイドクリックフラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイドクリックフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsGuideClick
        {
            get { return _isGuideClick; }
            set { _isGuideClick = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CarMngGuideParamInfo()
        {

        }
    }
}

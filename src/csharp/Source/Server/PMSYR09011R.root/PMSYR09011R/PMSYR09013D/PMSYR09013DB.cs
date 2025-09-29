using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CarMngGuideParamWork
    /// <summary>
    ///                      車両管理ガイド用ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車両管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/09/14  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarMngGuideParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先チェックかどうか</summary>
        private bool _isCheckCustomerCode;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>型式</summary>
        private string _kindModel = "";

        /// <summary>型式チェック方式</summary>
        private Int32 _kindModelType;

        /// <summary>車輌備考</summary>
        private string _carNote = "";

        /// <summary>車輌備考チェック方式</summary>
        private Int32 _checkCarNoteType;

        /// <summary>車輌管理コードチェックかどうか</summary>
        private bool _isCheckCarMngCode;

        /// <summary>車輌管理コードチェック方式</summary>
        private Int32 _checkCarMngCodeType;

        /// <summary>車輌管理コードチェックかどうか</summary>
        private bool _isCheckCarMngDivCd;

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

        /// public propaty name  :  KindModel
        /// <summary>型式プロパティ</summary>
        /// <value>※PM7での型式</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KindModel
        {
            get { return _kindModel; }
            set { _kindModel = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// <value>※PM7での車輌備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// public propaty name  :  CheckCarNoteType
        /// <summary>車輌備考チェック方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考チェック方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckCarNoteType
        {
            get { return _checkCarNoteType; }
            set { _checkCarNoteType = value; }
        }

        /// public propaty name  :  CheckCarNoteType
        /// <summary>型式チェック方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式チェック方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 KindModelType
        {
            get { return _kindModelType; }
            set { _kindModelType = value; }
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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CarMngGuideParamWork()
        {
        }
    }
}

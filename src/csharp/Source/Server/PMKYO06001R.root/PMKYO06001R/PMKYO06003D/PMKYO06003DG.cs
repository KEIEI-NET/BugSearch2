using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerProcParamWork
    /// <summary>
    ///                      得意先マスタ抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先マスタ抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APCustomerProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>得意先(開始)</summary>
        private Int32 _customerCodeBegin;

        /// <summary>得意先(終了)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>カナ(開始)</summary>
        private string _kanaBegin = "";

        /// <summary>カナ(終了)</summary>
        private string _kanaEnd = "";

        /// <summary>営業所(開始)</summary>
        private string _mngSectionCodeBegin = "";

        /// <summary>営業所(終了)</summary>
        private string _mngSectionCodeEnd = "";

        /// <summary>担当者(開始)</summary>
        private string _customerAgentCdBegin = "";

        /// <summary>担当者(終了)</summary>
        private string _customerAgentCdEnd = "";

        /// <summary>地区(開始)</summary>
        private Int32 _salesAreaCodeBegin;

        /// <summary>地区(終了)</summary>
        private Int32 _salesAreaCodeEnd;

        /// <summary>業種(開始)</summary>
        private Int32 _businessTypeCodeBegin;

        /// <summary>業種(終了)</summary>
        private Int32 _businessTypeCodeEnd;


        /// public propaty name  :  BeginningDate
        /// <summary>開始日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>終了日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  CustomerCodeBegin
        /// <summary>得意先(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeBeginRF
        {
            get { return _customerCodeBegin; }
            set { _customerCodeBegin = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>得意先(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEndRF
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  KanaBegin
        /// <summary>カナ(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナ(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KanaBeginRF
        {
            get { return _kanaBegin; }
            set { _kanaBegin = value; }
        }

        /// public propaty name  :  KanaEnd
        /// <summary>カナ(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナ(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KanaEndRF
        {
            get { return _kanaEnd; }
            set { _kanaEnd = value; }
        }

        /// public propaty name  :  MngSectionCodeBegin
        /// <summary>営業所(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   営業所(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeBeginRF
        {
            get { return _mngSectionCodeBegin; }
            set { _mngSectionCodeBegin = value; }
        }

        /// public propaty name  :  MngSectionCodeEnd
        /// <summary>営業所(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   営業所(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeEndRF
        {
            get { return _mngSectionCodeEnd; }
            set { _mngSectionCodeEnd = value; }
        }

        /// public propaty name  :  CustomerAgentCdBegin
        /// <summary>担当者(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdBeginRF
        {
            get { return _customerAgentCdBegin; }
            set { _customerAgentCdBegin = value; }
        }

        /// public propaty name  :  CustomerAgentCdEnd
        /// <summary>担当者(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdEndRF
        {
            get { return _customerAgentCdEnd; }
            set { _customerAgentCdEnd = value; }
        }

        /// public propaty name  :  SalesAreaCodeBegin
        /// <summary>地区(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地区(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeBeginRF
        {
            get { return _salesAreaCodeBegin; }
            set { _salesAreaCodeBegin = value; }
        }

        /// public propaty name  :  SalesAreaCodeEnd
        /// <summary>地区(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地区(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEndRF
        {
            get { return _salesAreaCodeEnd; }
            set { _salesAreaCodeEnd = value; }
        }

        /// public propaty name  :  BusinessTypeCodeBegin
        /// <summary>業種(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeBeginRF
        {
            get { return _businessTypeCodeBegin; }
            set { _businessTypeCodeBegin = value; }
        }

        /// public propaty name  :  BusinessTypeCodeEnd
        /// <summary>業種(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeEndRF
        {
            get { return _businessTypeCodeEnd; }
            set { _businessTypeCodeEnd = value; }
        }


        /// <summary>
        /// 得意先マスタ抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>CustomerProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APCustomerProcParamWork()
        {
        }

    }
}

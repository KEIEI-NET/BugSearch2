using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateProcParamWork
    /// <summary>
    ///                      従業員設定マスタ抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員設定マスタ抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/07/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EmployeeProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>所属拠点(開始)</summary>
        private string _belongSectionCdBegin = "";

        /// <summary>所属拠点(終了)</summary>
        private string _belongSectionCdEnd = "";

        /// <summary>従業員(開始)</summary>
        private string _employeeCdBegin = "";

        /// <summary>従業員(終了)</summary>
        private string _employeeCdEnd = "";


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

        /// public propaty name  :  BelongSectionCdBegin
        /// <summary>所属拠点(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属拠点(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSectionCdBeginRF
        {
            get { return _belongSectionCdBegin; }
            set { _belongSectionCdBegin = value; }
        }

        /// public propaty name  :  BelongSectionCdEnd
        /// <summary>所属拠点(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属拠点(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSectionCdEndRF
        {
            get { return _belongSectionCdEnd; }
            set { _belongSectionCdEnd = value; }
        }

        /// public propaty name  :  EmployeeCdBegin
        /// <summary>従業員(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCdBeginRF
        {
            get { return _employeeCdBegin; }
            set { _employeeCdBegin = value; }
        }

        /// public propaty name  :  EmployeeCdEnd
        /// <summary>従業員(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCdEndRF
        {
            get { return _employeeCdEnd; }
            set { _employeeCdEnd = value; }
        }


        /// <summary>
        /// 従業員設定マスタ抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeProcParamWork()
        {
        }

    }
}


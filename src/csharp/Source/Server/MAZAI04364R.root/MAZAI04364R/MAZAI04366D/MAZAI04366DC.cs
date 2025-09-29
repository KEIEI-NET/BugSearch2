using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputUpdateCndtnWork
    /// <summary>
    ///                      棚卸過不足更新条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸過不足更新条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/08/21  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputUpdateCndtnWork
    {
        /// <summary>棚卸運用区分</summary>
        private Int32 _inventoryMngDiv;
        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>拠点コード</summary>
        private string _sectionCode;
        /// <summary>従業員コード</summary>
        private string _employeeCode;
        /// <summary>従業員名称</summary>
        private string _employeeName;
        /// <summary>棚番更新区分</summary>
        private int _shelfNoDiv;

        /// public propaty name  :  InventoryMngDiv
        /// <summary>棚卸運用区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コード</summary>
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
        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }
        /// public propaty name  :  Name
        /// <summary>従業員名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  ShelfNoDiv
        /// <summary>棚番更新区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ShelfNoDiv
        {
            get { return _shelfNoDiv; }
            set { _shelfNoDiv = value; }
        }

        /// <summary>
        /// 棚卸過不足更新条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>InventInputUpdateCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputUpdateCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventInputUpdateCndtnWork()
        {
        }

    }
}

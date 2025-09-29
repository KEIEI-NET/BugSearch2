//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）_一覧検索条件ワーク
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）_一覧検索条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInspectParamWork
    /// <summary>
    ///                      ハンディターミナル在庫仕入（入庫更新）_一覧検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル在庫仕入（入庫更新）_一覧検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyUOEOrderListParamWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        /// <remarks>1:在庫一括分 2:その他</remarks>
        private Int32 _opDiv;

        /// <summary>コンピュータ名</summary>
        /// <remarks>コンピュータ名</remarks>
        private string _machineName = "";

        /// <summary>従業員コード</summary>
        /// <remarks>従業員コード</remarks>
        private string _employeeCode = "";

        /// <summary>発注先コード</summary>
        /// <remarks>発注先コード</remarks>
        private Int32 _supplierCode;

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
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

        /// public propaty name  :  OpDiv
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpDiv
        {
            get { return _opDiv; }
            set { _opDiv = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>コンピュータ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>検品従業員</value>
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

        // public propaty name  :  SupplierCode
        /// <summary>発注先コードプロパティ</summary>
        /// <value>発注先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        /// <summary>
        /// 検品照会条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyUOEOrderListParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyUOEOrderListParamWork()
        {
        }
    }
}

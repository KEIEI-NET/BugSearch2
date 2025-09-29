//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入(UOE以外)明細情報検索条件ワーク
// プログラム概要   : ハンディターミナル在庫仕入(UOE以外)明細情報検索条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyNonUOEStockParamWork
    /// <summary>
    ///                      ハンディターミナル在庫仕入(UOE以外)明細情報検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル在庫仕入(UOE以外)明細情報検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyNonUOEStockParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// <summary>処理区分</summary>
        /// <remarks>1:在庫一括分 2:その他</remarks>
        private Int32 _opDiv;

        /// <summary>伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private Int32 _slipNo;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
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

        /// public propaty name  :  OpDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>1:在庫一括分 2:その他</value>
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

        /// public propaty name  :  SlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }


        /// <summary>
        /// 在庫仕入(UOE以外)明細情報検索条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyNonUOEStockParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyNonUOEStockParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyNonUOEStockParamWork()
        {
        }

    }
}

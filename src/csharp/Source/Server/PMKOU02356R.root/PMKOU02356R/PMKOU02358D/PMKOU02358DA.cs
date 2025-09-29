//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表抽出条件ワーククラス
// プログラム概要   : 入荷差異表抽出条件ワーククラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14 修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ArrGoodsDiffCndtnWork
    /// <summary>
    ///                      入荷差異表 抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入荷差異表 抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   K2019/08/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ArrGoodsDiffCndtnWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCode = "";

        /// <summary>検品日</summary>
        private DateTime _inspectDate;

        /// <summary>発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>発注先名</summary>
        private string _uOESupplierNm;

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

        /// public propaty name  :  LoginSectionCode
        /// <summary>ログイン拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }

        /// public propaty name  :  InspectDate
        /// <summary>検品日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InspectDate
        {
            get { return _inspectDate; }
            set { _inspectDate = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierNm
        /// <summary>発注先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierNm
        {
            get { return _uOESupplierNm; }
            set { _uOESupplierNm = value; }
        }

        /// <summary>
        /// 入荷差異表 抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>ArrGoodsDiffCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ArrGoodsDiffCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrGoodsDiffCndtnWork()
        {
        }

    }
}

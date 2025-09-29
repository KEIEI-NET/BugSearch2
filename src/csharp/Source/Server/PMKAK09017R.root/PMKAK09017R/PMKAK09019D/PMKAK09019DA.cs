//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表抽出条件ワーククラス
// プログラム概要   : 仕入先総括マスタ一覧表抽出条件ワーククラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日   2012/09/07 修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SumSuppStPrintParaWork
    /// <summary>
    ///                      仕入先総括一覧表 抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先総括一覧表 抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/09/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SumSuppStPrintParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（開始）</summary>
        private string _sectionCodeSt = "";

        /// <summary>拠点コード（終了）</summary>
        private string _sectionCodeEd = "";

        /// <summary>仕入先コード（開始）</summary>
        private Int32 _supplierCodeSt;

        /// <summary>仕入先コード（終了）</summary>
        private Int32 _supplierCodeEd;


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

        /// public propaty name  :  SectionCodeSt
        /// <summary>拠点コード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>拠点コード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SupplierCodeSt
        /// <summary>仕入先コード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  SupplierCodeEd
        /// <summary>仕入先コード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }


        /// <summary>
        /// 仕入先総括一覧表 抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>SumSuppStParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumSuppStPrintParaWork()
        {
        }

    }
}

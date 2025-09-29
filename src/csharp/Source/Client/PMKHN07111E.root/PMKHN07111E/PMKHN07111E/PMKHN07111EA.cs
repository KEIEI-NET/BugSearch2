//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先マスタ（エクスポート）
// プログラム概要   : 仕入先マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierExportWork
    /// <summary>
    ///                      仕入先マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SupplierExportWork
    {
        # region ■ private field ■
        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCdSt;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCdEd;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>開始拠点コード</summary>
        private string _sectionCdSt;

        /// <summary>終了拠点コード</summary>
        private string _sectionCdEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  SupplierCdSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCdSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String SectionCdSt
        {
            get { return _sectionCdSt; }
            set { _sectionCdSt = value; }
        }

        /// public propaty name  :  SectionCdEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String SectionCdEd
        {
            get { return _sectionCdEd; }
            set { _sectionCdEd = value; }
        }


        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 仕入先マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>SupplierExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（エクスポート）
// プログラム概要   : 掛率マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 黒澤　直貴
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasShWork → RateTextShWork
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RateTextShWork
    /// <summary>
    ///                      掛率マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/06/12</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//  public class StockMasShWork
    public class RateTextShWork
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
    {
        # region ■ private field ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>拠点コード（開始）</summary>
        private string _sectionCodeSt;

        /// <summary>拠点コード（終了）</summary>
        private string _sectionCodeEd;

        /// <summary>単価種類</summary>
        private string _warehouseCodeSt;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 拠点コード（開始）
        /// </summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }
        /// <summary>
        /// 拠点コード（終了）
        /// </summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        /// <summary>
        /// 単価種類
        /// </summary>
        public string WarehouseCdSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 掛率マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>StockMasShWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMasShWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//      public StockMasShWork()
        public RateTextShWork()
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
        {
        }
        # endregion ■ Constructor ■
    }
}

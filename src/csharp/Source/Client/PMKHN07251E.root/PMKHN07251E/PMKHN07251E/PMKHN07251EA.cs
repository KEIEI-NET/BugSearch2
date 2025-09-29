//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（エクスポート）
// プログラム概要   : 在庫マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockExpWork
    /// <summary>
    ///                      在庫マスタ（エクスポート）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫マスタ（エクスポート）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockExpWork
    {
        # region ■ private field ■
        /// <summary>開始倉庫コード</summary>
        private string _warehouseCodeSt;

        /// <summary>終了倉庫コード</summary>
        private string _warehouseCodeEd;

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _goodsNoSt = "";

        /// <summary>終了品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _goodsNoEd = "";

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  JoinSourceMakerCodeSt
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEd
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHSt
        /// <summary>開始品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHEd
        /// <summary>終了品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 結合（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsExpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockExpWork()
        {
        }
        # endregion ■ Constructor ■
    }
}

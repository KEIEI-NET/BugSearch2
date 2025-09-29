//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理マスタ（エクスポート）
// プログラム概要   : 商品管理マスタ（エクスポート）条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 更 新 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/13  修正内容 : 2012/10/17配信分、Redmine#32367
//                                  商品マスタエクスポートで不具合現象の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsMngExport
    /// <summary>
    ///                      商品管理マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品管理マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/05  </br>
    /// </remarks>
    public class GoodsMngExport
    {
        # region ■ private field ■
        /// <summary>開始拠点コード</summary>
        private string _sectionCdSt;

        /// <summary>終了拠点コード</summary>
        private string _sectionCdEd;

        /// <summary>開始商品管理メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品管理メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始商品管理番号</summary>
        private string _goodsNoSt = "";

        /// <summary>終了商品管理番号</summary>
        private string _goodsNoEd = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        /// <summary>開始商品管理BLコード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了商品管理BLコード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始商品管理中分類</summary>
        private Int32 _goodsMGroupSt;

        /// <summary>終了商品管理中分類</summary>
        private Int32 _goodsMGroupEd;
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
        /// <summary>設定種別</summary>
        private Int32 _setKind;
        // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<
        # endregion  ■ private field ■

        # region ■ public propaty ■

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

        /// public propaty name  :  GoodsMakerCdSt
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

        /// public propaty name  :  GoodsMakerCdEd
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

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始商品管理BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了商品管理BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsMGroupSt
        /// <summary>開始商品管理中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>終了商品管理中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
        /// public propaty name  :  SetKind
        /// <summary>設定種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   設定種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetKind
        {
            get { return _setKind; }
            set { _setKind = value; }
        }
        // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 商品管理マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsMngExportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngExportクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsMngExport()
        {
        }
        # endregion ■ Constructor ■

    }
}

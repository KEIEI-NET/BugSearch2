//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け検索条件クラス
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsBarCodeRevnSearchPara
    /// <summary>
    ///                      商品バーコード関連付け検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品バーコード関連付け検索条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2017/06/12  (CSharp File Generated Date)</br>
    /// </remarks>
    public class GoodsBarCodeRevnSearchPara
    {
        # region ■ private field ■

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>在庫区分</summary>
        /// <remarks>0:在庫のみ　1:全て</remarks>
        private Int32 _stockDiv;

        /// <summary>登録区分</summary>
        /// <remarks>0:全て　1:バーコード有り　2:バーコード無し</remarks>
        private Int32 _haveBarCodeDiv;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        # endregion  ■ private field ■

        # region ■ public propaty ■

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

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  HaveBarCodeDiv
        /// <summary>登録区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HaveBarCodeDiv
        {
            get { return _haveBarCodeDiv; }
            set { _haveBarCodeDiv = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
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

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 商品バーコード関連付け検索条件クラスコンストラクタ
        /// </summary>
        /// <returns>GoodsBarCodeRevnSearchParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnSearchParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsBarCodeRevnSearchPara()
        {
        }
        # endregion ■ Constructor ■
    }
}

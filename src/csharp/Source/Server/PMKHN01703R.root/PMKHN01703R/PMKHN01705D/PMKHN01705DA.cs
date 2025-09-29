//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換一括処理変換条件
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsChangeAllCndWorkWork
    /// <summary>
    ///                      品番変換一括処理変換条件ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   品番変換一括処理変換条件ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/01/26</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsChangeAllCndWorkWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>ログインユーザーの拠点</summary>
        private string _loginSectionCode = "";

        /// <summary>ログインユーザーの拠点名称</summary>
        private string _loginSectionNm = "";

        /// <summary>ログイン担当者コード</summary>
        private string _loginEmpleeCode = "";

        /// <summary>ログイン担当者の名称</summary>
        private string _loginEmpleeName = "";

        /// <summary>処理区分</summary>
        private Int32 _changeDiv;

        /// <summary>品番変換マスタチェック区分</summary>
        private Int32 _goodsChangeMstDiv;

        /// <summary>商品マスタ区分</summary>
        private Int32 _goodsMstDiv;

        /// <summary>商品管理情報マスタ区分</summary>
        private Int32 _goodsMngMstDiv;

        /// <summary>在庫マスタ区分</summary>
        private Int32 _stockMstDiv;

        /// <summary>掛率マスタ区分</summary>
        private Int32 _rateMstDiv;

        /// <summary>結合マスタ区分</summary>
        private Int32 _joinMstDiv;

        /// <summary>代替マスタ区分</summary>
        private Int32 _partsMstDiv;

        /// <summary>セットマスタ区分</summary>
        private Int32 _setMstDiv;

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// <summary>優良設定マスタ区分</summary>
        private Int32 _prmMstDiv;
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        /// <summary>未計上貸出データ区分</summary>
        private Int32 _shipmentDiv;


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

        /// public propaty name  :  LoginSectionNm
        /// <summary>ログインユーザーの拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインユーザーの拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginSectionNm
        {
            get { return _loginSectionNm; }
            set { _loginSectionNm = value; }
        }

        /// public propaty name  :  LoginSectionCode
        /// <summary>ログインユーザーの拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインユーザーの拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }

        /// public propaty name  :  LoginEmpleeCode
        /// <summary>ログイン担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginEmpleeCode
        {
            get { return _loginEmpleeCode; }
            set { _loginEmpleeCode = value; }
        }

        /// public propaty name  :  LoginEmpleeName
        /// <summary>ログイン担当者の名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン担当者の名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginEmpleeName
        {
            get { return _loginEmpleeName; }
            set { _loginEmpleeName = value; }
        }

        /// public propaty name  :  ChangeDiv
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChangeDiv
        {
            get { return _changeDiv; }
            set { _changeDiv = value; }
        }

        /// public propaty name  :  GoodsChangeMstDiv
        /// <summary>品番変換マスタチェック区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番変換マスタチェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsChangeMstDiv
        {
            get { return _goodsChangeMstDiv; }
            set { _goodsChangeMstDiv = value; }
        }

        /// public propaty name  :  GoodsMstDiv
        /// <summary>商品マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMstDiv
        {
            get { return _goodsMstDiv; }
            set { _goodsMstDiv = value; }
        }

        /// public propaty name  :  GoodsMngMstDiv
        /// <summary>商品管理情報マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品管理情報マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMngMstDiv
        {
            get { return _goodsMngMstDiv; }
            set { _goodsMngMstDiv = value; }
        }

        /// public propaty name  :  StockMstDiv
        /// <summary>在庫マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMstDiv
        {
            get { return _stockMstDiv; }
            set { _stockMstDiv = value; }
        }

        /// public propaty name  :  RateMstDiv
        /// <summary>掛率マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateMstDiv
        {
            get { return _rateMstDiv; }
            set { _rateMstDiv = value; }
        }

        /// public propaty name  :  JoinMstDiv
        /// <summary>結合マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinMstDiv
        {
            get { return _joinMstDiv; }
            set { _joinMstDiv = value; }
        }

        /// public propaty name  :  PartsMstDiv
        /// <summary>代替マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMstDiv
        {
            get { return _partsMstDiv; }
            set { _partsMstDiv = value; }
        }

        /// public propaty name  :  SetMstDiv
        /// <summary>セットマスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セットマスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetMstDiv
        {
            get { return _setMstDiv; }
            set { _setMstDiv = value; }
        }

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// public propaty name  :  PrmMstDiv
        /// <summary>優良設定マスタ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定マスタ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmMstDiv
        {
            get { return _prmMstDiv; }
            set { _prmMstDiv = value; }
        }
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        /// public propaty name  :  ShipmentDiv
        /// <summary>未計上貸出データ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   未計上貸出データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDiv
        {
            get { return _shipmentDiv; }
            set { _shipmentDiv = value; }
        }


        /// <summary>
        /// 品番変換一括処理変換条件ワークワークコンストラクタ
        /// </summary>
        /// <returns>GoodsChangeAllCndWorkWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsChangeAllCndWorkWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsChangeAllCndWorkWork()
        {
        }

    }
}

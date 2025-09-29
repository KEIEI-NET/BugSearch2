//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsInfoData
    /// <summary>
    ///                      商品追加データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷指示データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsInfoData
    {
        #region ■ Public Const

        /// <summary>pdf状態　0</summary>
        public const string ct_PdfStatusForNormal = "0";

        /// <summary>pdf状態　1</summary>
        public const string ct_PdfStatusForWarn = "1";

        /// <summary>pdf状態　2</summary>
        public const string ct_PdfStatusForError = "2";


        /// <summary>pdf状態　正常</summary>
        public const string ct_PdfStatusForNormalName = "正常";

        /// <summary>pdf状態　警告</summary>
        public const string ct_PdfStatusForWarnName = "警告";

        /// <summary>pdf状態　エラー</summary>
        public const string ct_PdfStatusForErrorName = "エラー";

        /// <summary>、 </summary>
        public const string ct_Sign = "、";

        /// <summary>仕入先</summary>
        public const string ct_Supplier = "仕入先";

        /// <summary>メーカー</summary>
        public const string ct_GoodsMaker = "ﾒｰｶｰ";

        /// <summary>BLコード</summary>
        //public const string ct_BLGoodsCode = "翼CD";
        public const string ct_BLGoodsCode = "BLｺｰﾄﾞ";

        /// <summary>品番</summary>
        public const string ct_GoodsNo = "品番";

        /// <summary>品名</summary>
        public const string ct_GoodsName = "品名";

        /// <summary>定価</summary> 
        //public const string ct_Price = "定価";
        public const string ct_Price = "価格";

        /// <summary>売価率</summary>
        public const string ct_StockRate = "仕入率";

        /// <summary>売価</summary>
        public const string ct_SalesUnitCost = "原価";

        #endregion


        #region ■ Private Member
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入先ｺｰﾄﾞ</summary>
        private Int32 _supplierCd;


        /// <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
        private Int32 _goodsMakerCd;


        /// <summary>分類ｺｰﾄﾞ</summary>
        private string _kindCd = string.Empty;

        /// <summary>翼ｺｰﾄﾞ</summary>
        private Int32 _bLGoodsCode;

        /// <summary>品　番</summary>
        private string _goodsNo = string.Empty;


        /// <summary>品　名</summary>
        private string _goodsName = string.Empty;

        /// <summary>定　価	</summary>
        private double _price;


        /// <summary>部品商原価１</summary>
        private string _price1;

        /// <summary>部品商原価２</summary>
        private string _price2;

        /// <summary>部品商原価３</summary>
        private string _price3;

        /// <summary>価格実施日</summary>
        private Int64 _priceStartDate;

        /// <summary>登録区分</summary>
        private string _loginFlg = string.Empty;


        /// <summary>売価率</summary>
        private double _stockRate;

        /// <summary>売　価</summary>
        private double _salesUnitCost;

        /// <summary>部品商ｺｰﾄﾞ</summary>
        private string _goodsTraderCd;


        /// <summary>ファイル作成日付</summary>
        /// <remarks>作成日付</remarks>
        private string _fileCreateDateTime;


        /// <summary>pdf状態</summary>
        private string _pdfStatus = "";

        /// <summary>チェックメッセージ</summary>
        private string _checkMessage = "";

        #endregion

        
        #region ■ Public Propaty
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


        /// public propaty name  :  SupplierCd
        /// <summary>仕入先ｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }


        /// public propaty name  :  GoodsMakerCd
        /// <summary>ﾒｰｶｰｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  KindCd
        /// <summary>分類ｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   分類ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KindCd
        {
            get { return _kindCd; }
            set { _kindCd = value; }
        }



        /// public propaty name  :  BLGoodsCode
        /// <summary>翼ｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }


        /// public propaty name  :  GoodsNo
        /// <summary>品　番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品　番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }


        /// public propaty name  :  GoodsName
        /// <summary>品　名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品　名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Price
        /// <summary>定　価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定　価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }



        /// public propaty name  :  Price1
        /// <summary>部品商原価１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price1
        {
            get { return _price1; }
            set { _price1 = value; }
        }


        /// public propaty name  :  Price2
        /// <summary>部品商原価2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }


        /// public propaty name  :  Price3
        /// <summary>部品商原価3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }


        /// public propaty name  :  PriceStartDate
        /// <summary>価格実施日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格実施日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  LoginFlg
        /// <summary>登録区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginFlg
        {
            get { return _loginFlg; }
            set { _loginFlg = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }


        /// public propaty name  :  SalesUnitCost
        /// <summary>売　価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売　価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }



        /// public propaty name  :  GoodsTraderCd
        /// <summary>部品商ｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTraderCd
        {
            get { return _goodsTraderCd; }
            set { _goodsTraderCd = value; }
        }


        /// public propaty name  :  FileCreateDateTime
        /// <summary>ファイル作成日付プロパティ</summary>
        /// <value>作成日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル作成日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileCreateDateTime
        {
            get { return _fileCreateDateTime; }
            set { _fileCreateDateTime = value; }
        }


        /// public propaty name  :  CheckMessage
        /// <summary>pdf状態プロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   pdf状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PdfStatus
        {
            get { return _pdfStatus; }
            set { _pdfStatus = value; }
        }

        /// public propaty name  :  CheckMessage
        /// <summary>チェックメッセージプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  チェックメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CheckMessage
        {
            get { return _checkMessage; }
            set { _checkMessage = value; }
        }

        #endregion


        #region ■ Constructor
        /// <summary>
        /// 商品追加データコンストラクタ
        /// </summary>
        /// <returns>DispatchInstsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DispatchInstsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsInfoData()
        {
        }
        #endregion
    }
}

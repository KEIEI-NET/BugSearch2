//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/02/25  修正内容 : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/03/06  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上データテキスト出力 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力 テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.13</br>
    /// <br>UpdateNote : 2013/02/25 zhuhh</br>
    /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// <br>UpdateNote : 2013/03/06 zhuhh</br>
    /// <br>           : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
    /// </remarks>
    public class PMSAE02014EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SalesHistoryData = "Tbl_SalesHistoryData";

        /// <summary> AB伝票№ </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 請求区分 </summary>
        public const string ct_Col_RequestDiv = "RequestDiv";

        /// <summary> AB店舗ｺｰﾄﾞ </summary>
        public const string ct_Col_AddresseeShopCd = "AddresseeShopCd";

        /// <summary> 売上日 </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";

        /// <summary> 純正優良区分 </summary>
        public const string ct_Col_GoodDiv = "GoodDiv";

        /// <summary> 部品商ｺｰﾄﾞ </summary>
        public const string ct_Col_TradCompCd = "TradCompCd";

        /// <summary> Ｓ＆Ｅ仕入率 </summary>
        public const string ct_Col_TradCompRate = "TradCompRate";

        /// <summary> AB売上率 </summary>
        public const string ct_Col_AbSalesRate = "AbSalesRate";

        /// <summary> 行№ </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";

        /// <summary> 管理№ </summary>
        public const string ct_Col_AdministrationNo = "AdministrationNo";

        /// <summary> 管理名称（品番） </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";

        /// <summary> 商品ｺｰﾄﾞ </summary>
        public const string ct_Col_AbGoodsNo = "AbGoodsNo";

        /// <summary> 数量 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> 納入単価</summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> 納入金額 </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> 仕入金額</summary>
        public const string ct_Col_SupplierMoney = "SupplierMoney";

        /// <summary> PDF用納入金額 </summary>
        public const string ct_Col_PdfSalesMoneyTaxExc = "PdfSalesMoneyTaxExc";

        /// <summary> PDF用仕入金額</summary>
        public const string ct_Col_PdfSupplierMoney = "PdfSupplierMoney";

        /// <summary> 売上金額</summary>
        public const string ct_Col_SalesMoney = "SalesMoney";

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
        /// <summary> 店舗売価</summary>
        public const string ct_Col_ShopMoney = "ShopMoney";

        /// <summary> 売価金額</summary>
        public const string ct_Col_PriceMoney = "PriceMoney";

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

        /// <summary> 得意先ｺｰﾄﾞ </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";

        /// <summary> Txt得意先ｺｰﾄﾞ </summary>
        public const string ct_Col_TxtCustomerCode = "TxtCustomerCode";

        /// <summary> 地区ｺｰﾄﾞ </summary>
        public const string ct_Col_AreaCd = "AreaCd";

        /// <summary> ｱｯﾌﾟﾃﾞｰﾄＹＭＤ </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";

        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";

        /// <summary> 経費区分 </summary>
        public const string ct_Col_ExpenseDivCd = "ExpenseDivCd";

        /// <summary> メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
        /// <summary> 注文ナンバー</summary>
        public const string ct_Col_OrderNum = "OrderNum";
        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

        /// <summary> ＦＩＬＬＥＲ </summary>
        public const string ct_Col_Filler = "Filler";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCodeRF = "SectionCode";

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_PdfData = "Tbl_PdfData";

        /// <summary> 伝票枚数</summary>
        public const string ct_Col_SlipCountSum = "SlipCountSum";

        /// <summary> 売上合計</summary>
        public const string ct_Col_SalesMoneySum = "SalesMoneySum";

        /// <summary> 値引予定額 </summary>
        public const string ct_Col_SalesSupplierMoneySum = "SalesSupplierMoneySum";

        /// <summary> 行数（純正） </summary>
        public const string ct_Col_PureCount = "PureCount";

        /// <summary> 売上金額（純正） </summary>
        public const string ct_Col_PureSalesMoneyTaxExc = "PureSalesMoneyTaxExc";

        /// <summary> 仕切金額（純正） </summary>
        public const string ct_Col_PureSupplierMoney = "PureSupplierMoney";

        /// <summary> 行数（優良） </summary>
        public const string ct_Col_PriCount = "PriCount";

        /// <summary> 売上金額（優良） </summary>
        public const string ct_Col_PriSalesMoneyTaxExc = "PriSalesMoneyTaxExc";

        /// <summary> 仕切金額（優良） </summary>
        public const string ct_Col_PriSupplierMoney = "PriSupplierMoney";

        /// <summary> 拠点ガイド略称 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";

        /// <summary> 差額（純正） </summary>
        public const string ct_Col_PureDefferent = "PureDefferent";

        /// <summary> 差額 （優良）</summary>
        public const string ct_Col_PriDefferent = "PriDefferent";

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        /// <summary> データ区分</summary>
        public const string ct_Col_DataDiv = "DataDiv";

        /// <summary> パーツマン端末コード</summary>
        public const string ct_Col_PartsManWSCD = "PartsManWSCD";
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 売上データテキスト出力 テーブルスキーマ情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上データテキスト出力 テーブルスキーマ情報クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.08.13</br>
		/// </remarks>
        public PMSAE02014EA()
		{
		}
		#endregion

        #region ■ Static Public Method
        #region ◆ データDataSetテーブルスキーマ設定
        /// <summary>
        /// 売上データテキストDataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
        /// <br>Note       : 売上データテキストデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2013/02/25 zhuhh</br>
        /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// <br>UpdateNote : 2013/03/06 zhuhh</br>
        /// <br>           : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
		/// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在する時はクリアするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_SalesHistoryData);

                // AB伝票№
                dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = "";

                // 請求区分
                dt.Columns.Add(ct_Col_RequestDiv, typeof(string));
                dt.Columns[ct_Col_RequestDiv].DefaultValue = "";

                // AB店舗ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_AddresseeShopCd, typeof(string));
                dt.Columns[ct_Col_AddresseeShopCd].DefaultValue = "";

                // 売上日 
                dt.Columns.Add(ct_Col_AddUpADate, typeof(string));
                dt.Columns[ct_Col_AddUpADate].DefaultValue = "";

                // 純正優良区分 
                dt.Columns.Add(ct_Col_GoodDiv, typeof(string));
                dt.Columns[ct_Col_GoodDiv].DefaultValue = "";

                // 部品商ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_TradCompCd, typeof(string));
                dt.Columns[ct_Col_TradCompCd].DefaultValue = "";

                // Ｓ＆Ｅ仕入率
                dt.Columns.Add(ct_Col_TradCompRate, typeof(string));
                dt.Columns[ct_Col_TradCompRate].DefaultValue = "";

                // AB売上率
                dt.Columns.Add(ct_Col_AbSalesRate, typeof(string));
                dt.Columns[ct_Col_AbSalesRate].DefaultValue = "";

                // 行№ 
                dt.Columns.Add(ct_Col_SalesRowNo, typeof(string));
                dt.Columns[ct_Col_SalesRowNo].DefaultValue = "";

                // 管理№
                dt.Columns.Add(ct_Col_AdministrationNo, typeof(string));
                dt.Columns[ct_Col_AdministrationNo].DefaultValue = "";

                // 管理名称（品番）
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                // 品名
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = "";

                // 商品ｺｰﾄﾞ 
                dt.Columns.Add(ct_Col_AbGoodsNo, typeof(string));
                dt.Columns[ct_Col_AbGoodsNo].DefaultValue = "";

                // 数量
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(string));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = "";

                // 納入単価
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = "";

                // 納入金額
                dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = "";

                // 仕入金額
                dt.Columns.Add(ct_Col_SupplierMoney, typeof(string));
                dt.Columns[ct_Col_SupplierMoney].DefaultValue = "";

                // PDF用納入金額
                dt.Columns.Add(ct_Col_PdfSalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_PdfSalesMoneyTaxExc].DefaultValue = "";

                // PDF用仕入金額
                dt.Columns.Add(ct_Col_PdfSupplierMoney, typeof(string));
                dt.Columns[ct_Col_PdfSupplierMoney].DefaultValue = "";

                // 売上金額
                dt.Columns.Add(ct_Col_SalesMoney, typeof(string));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = "";

                // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
                // 店舗売価
                dt.Columns.Add(ct_Col_ShopMoney, typeof(string));
                dt.Columns[ct_Col_ShopMoney].DefaultValue = "";

                // 売価金額
                dt.Columns.Add(ct_Col_PriceMoney, typeof(string));
                dt.Columns[ct_Col_PriceMoney].DefaultValue = "";
                // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

                // 得意先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";

                // Txt得意先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_TxtCustomerCode, typeof(string));
                dt.Columns[ct_Col_TxtCustomerCode].DefaultValue = "";

                // 地区ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_AreaCd, typeof(string));
                dt.Columns[ct_Col_AreaCd].DefaultValue = "";

                // ｱｯﾌﾟﾃﾞｰﾄＹＭＤ
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(string));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = "";

                // 仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = "";

                // 経費区分
                dt.Columns.Add(ct_Col_ExpenseDivCd, typeof(string));
                dt.Columns[ct_Col_ExpenseDivCd].DefaultValue = "";

                // メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = "";

                // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
                dt.Columns.Add(ct_Col_OrderNum, typeof(string));
                dt.Columns[ct_Col_OrderNum].DefaultValue = "";
                // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

                // ＦＩＬＬＥＲ
                dt.Columns.Add(ct_Col_Filler, typeof(string));
                dt.Columns[ct_Col_Filler].DefaultValue = "";

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCodeRF, typeof(string));
                dt.Columns[ct_Col_SectionCodeRF].DefaultValue = "";

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
                // データ区分
                dt.Columns.Add(ct_Col_DataDiv, typeof(string));
                dt.Columns[ct_Col_DataDiv].DefaultValue = "";

                // パーツマン端末コード
                dt.Columns.Add(ct_Col_PartsManWSCD, typeof(string));
                dt.Columns[ct_Col_PartsManWSCD].DefaultValue = "";
                // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
            }
        }

        /// <summary>
        /// 売上データテキストDataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
        /// <br>Note       : 売上データテキストデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
		/// </remarks>
        static public void CreatePrintDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在する時はクリアするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_PdfData);

                // 伝票枚数
                dt.Columns.Add(ct_Col_SlipCountSum, typeof(string));
                dt.Columns[ct_Col_SlipCountSum].DefaultValue = "";

                // 売上合計
                dt.Columns.Add(ct_Col_SalesMoneySum, typeof(string));
                dt.Columns[ct_Col_SalesMoneySum].DefaultValue = "";

                // 値引予定額
                dt.Columns.Add(ct_Col_SalesSupplierMoneySum, typeof(string));
                dt.Columns[ct_Col_SalesSupplierMoneySum].DefaultValue = "";

                // 行数（純正）
                dt.Columns.Add(ct_Col_PureCount, typeof(string));
                dt.Columns[ct_Col_PureCount].DefaultValue = "";

                // 売上金額（純正）
                dt.Columns.Add(ct_Col_PureSalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_PureSalesMoneyTaxExc].DefaultValue = "";

                // 仕切金額（純正）
                dt.Columns.Add(ct_Col_PureSupplierMoney, typeof(string));
                dt.Columns[ct_Col_PureSupplierMoney].DefaultValue = "";

                // 行数（優良）
                dt.Columns.Add(ct_Col_PriCount, typeof(string));
                dt.Columns[ct_Col_PriCount].DefaultValue = "";

                // 売上金額（優良）
                dt.Columns.Add(ct_Col_PriSalesMoneyTaxExc, typeof(string));
                dt.Columns[ct_Col_PriSalesMoneyTaxExc].DefaultValue = "";

                // 仕切金額（優良）
                dt.Columns.Add(ct_Col_PriSupplierMoney, typeof(string));
                dt.Columns[ct_Col_PriSupplierMoney].DefaultValue = "";


                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCodeRF, typeof(string));
                dt.Columns[ct_Col_SectionCodeRF].DefaultValue = "";

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                // 差額（純正）
                dt.Columns.Add(ct_Col_PureDefferent, typeof(string));
                dt.Columns[ct_Col_PureDefferent].DefaultValue = "";

                // 差額 （優良）
                dt.Columns.Add(ct_Col_PriDefferent, typeof(string));
                dt.Columns[ct_Col_PriDefferent].DefaultValue = "";

                // 得意先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";
            }
        }

        #endregion ◆ データDataSetテーブルスキーマ設定

        #endregion ■ Static Public Method

    }
}

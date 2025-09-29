//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00      作成担当 : 田建委
// 作 成 日  2019/12/02       修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上連携テキスト出力 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上連携テキスト出力 テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    public class PMSDC02014EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SalesCprtData = "Tbl_SalesCprtData";

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
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";

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

        /// <summary> 得意先ｺｰﾄﾞ </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";

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

        /// <summary> 注文ナンバー</summary>
        public const string ct_Col_OrderNum = "OrderNum";

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

        /// <summary> 拠点ガイド略称 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";

        /// <summary> 伝票備考</summary>
        public const string ct_Col_SlipNote = "SlipNote";

        /// <summary> 伝票備考2</summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";

        /// <summary> 伝票備考3</summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";

        /// <summary> 更新日時</summary>
        public const string ct_Col_UpDate = "UpdateDateTime";

        /// <summary> 伝票区分</summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";

        /// <summary> メーカー名</summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 元黒伝票番号</summary>
        public const string ct_Col_DebitNLnkSalesSlNum = "DebitNLnkSalesSlNum";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 売上連携テキスト出力 テーブルスキーマ情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上連携テキスト出力 テーブルスキーマ情報クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2019/12/02</br>
		/// </remarks>
        public PMSDC02014EA()
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
		/// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
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
                dt = new DataTable(ct_Tbl_SalesCprtData);

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
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = "";

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

                // 得意先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";

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

                dt.Columns.Add(ct_Col_OrderNum, typeof(string));
                dt.Columns[ct_Col_OrderNum].DefaultValue = "";

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

                // 伝票備考
                dt.Columns.Add(ct_Col_SlipNote, typeof(string));
                dt.Columns[ct_Col_SlipNote].DefaultValue = "";

                // 伝票備考2
                dt.Columns.Add(ct_Col_SlipNote2, typeof(string));
                dt.Columns[ct_Col_SlipNote2].DefaultValue = "";

                // 伝票備考3
                dt.Columns.Add(ct_Col_SlipNote3, typeof(string));
                dt.Columns[ct_Col_SlipNote3].DefaultValue = "";

                // 更新日時
                dt.Columns.Add(ct_Col_UpDate, typeof(string));
                dt.Columns[ct_Col_UpDate].DefaultValue = "";

                // 伝票区分
                dt.Columns.Add(ct_Col_SalesSlipCd, typeof(string));
                dt.Columns[ct_Col_SalesSlipCd].DefaultValue = "";

                // メーカー名
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = "";

                // 元黒伝票番号
                dt.Columns.Add(ct_Col_DebitNLnkSalesSlNum, typeof(string));
                dt.Columns[ct_Col_DebitNLnkSalesSlNum].DefaultValue = "";
            }
        }

        /// <summary>
        /// 売上データテキストDataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
        /// <br>Note       : 売上データテキストデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
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

                // 行数
                dt.Columns.Add(ct_Col_PureCount, typeof(string));
                dt.Columns[ct_Col_PureCount].DefaultValue = "";

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCodeRF, typeof(string));
                dt.Columns[ct_Col_SectionCodeRF].DefaultValue = "";

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                // 得意先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = "";
            }
        }

        #endregion ◆ データDataSetテーブルスキーマ設定

        #endregion ■ Static Public Method

    }
}

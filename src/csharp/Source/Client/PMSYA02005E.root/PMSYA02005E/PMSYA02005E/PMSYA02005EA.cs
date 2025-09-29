//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
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
    /// 車輌別出荷実績表 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌別出荷実績表 テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.09.15</br>
    /// </remarks>
    public class PMSYA02005EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_CarShipListData = "Tbl_CarShipListData";
        /// <summary>売上伝票番号</summary>
        public const string ct_Col_SalesSlipNumRF = "SalesSlipNumRF";
        /// <summary>実績計上拠点コード</summary>
        public const string ct_Col_ResultsAddUpSecCdRF = "ResultsAddUpSecCdRF";
        /// <summary>売上日付</summary>
        public const string ct_Col_SalesDateRF = "SalesDateRF";
        /// <summary>得意先コード</summary>
        public const string ct_Col_CustomerCodeRF = "CustomerCodeRF";
        /// <summary>得意先略称</summary>
        public const string ct_Col_CustomerSnmRF = "CustomerSnmRF";
        /// <summary>売上行番号</summary>
        public const string ct_Col_SalesRowNoRF = "SalesRowNoRF";
        /// <summary>商品メーカーコード</summary>
        public const string ct_Col_GoodsMakerCdRF = "GoodsMakerCdRF";
        /// <summary>商品番号</summary>
        public const string ct_Col_GoodsNoRF = "GoodsNoRF";
        /// <summary>商品名称カナ</summary>
        public const string ct_Col_GoodsNameKanaRF = "GoodsNameKanaRF";
        /// <summary>BL商品コード</summary>
        public const string ct_Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary>BL商品コードCopy</summary>
        public const string ct_Col_BLGoodsCodeRFCopy = "BLGoodsCodeRFCopy";
        /// <summary>BL商品コード名称（半角）</summary>
        public const string ct_Col_BLGoodsHalfNameRF = "BLGoodsHalfNameRF";
        /// <summary>BLグループコード</summary>
        public const string ct_Col_BLGroupCodeRF = "BLGroupCodeRF";
        /// <summary>BLグループコードCopy</summary>
        public const string ct_Col_BLGroupCodeRFCopy = "BLGroupCodeRFCopy";
        /// <summary>BLグループコードカナ名称</summary>
        public const string ct_Col_BLGroupKanaNameRF = "BLGroupKanaNameRF";
        /// <summary>定価（税抜，浮動）</summary>
        public const string ct_Col_ListPriceTaxExcFlRF = "ListPriceTaxExcFlRF";
        /// <summary>売上単価（税抜，浮動）</summary>
        public const string ct_Col_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFlRF";
        /// <summary>原価単価</summary>
        public const string ct_Col_SalesUnitCostRF = "SalesUnitCostRF";
        /// <summary>出荷数</summary>
        public const string ct_Col_ShipmentCntRF = "ShipmentCntRF";
        /// <summary>出荷数(在庫)</summary>
        public const string ct_Col_ShipmentCntInRF = "ShipmentCntInRF";
        /// <summary>出荷数(取寄)</summary>
        public const string ct_Col_ShipmentCntNotInRF = "ShipmentCntNotInRF";
        /// <summary>売上在庫取寄せ区分</summary>
        public const string ct_Col_SalesOrderDivCdRF = "SalesOrderDivCdRF";
        /// <summary>売上金額（税抜き）</summary>
        public const string ct_Col_SalesMoneyTaxExcRF = "SalesMoneyTaxExcRF";
        /// <summary>拠点ガイド略称</summary>
        public const string ct_Col_SectionGuideSnmRF = "SectionGuideSnmRF";
        /// <summary>粗利金額</summary>
        public const string ct_Col_GrossProfitRF = "GrossProfitRF";
        /// <summary>粗利率</summary>
        public const string ct_Col_GrossPivRF = "GrossPivRF";

        /// <summary>車両管理番号</summary>
        public const string ct_Col_CarMngNoRF = "CarMngNoRF";
        /// <summary>車輌管理コード</summary>
        public const string ct_Col_CarMngCodeRF = "CarMngCodeRF";
        /// <summary>陸運事務局名称</summary>
        public const string ct_Col_NumberPlate1NameRF = "NumberPlate1NameRF";
        /// <summary>車両登録番号（種別）</summary>
        public const string ct_Col_NumberPlate2RF = "NumberPlate2RF";
        /// <summary>車両登録番号（カナ）</summary>
        public const string ct_Col_NumberPlate3RF = "NumberPlate3RF";
        /// <summary>車両登録番号（プレート番号）</summary>
        public const string ct_Col_NumberPlate4RF = "NumberPlate4RF";
        /// <summary>初年度</summary>
        public const string ct_Col_FirstEntryDateRF = "FirstEntryDateRF";
        /// <summary>メーカーコード</summary>
        public const string ct_Col_MakerCodeRF = "MakerCodeRF";
        /// <summary>車種コード</summary>
        public const string ct_Col_ModelCodeRF = "ModelCodeRF";
        /// <summary>車種サブコード</summary>
        public const string ct_Col_ModelSubCodeRF = "ModelSubCodeRF";
        /// <summary>車種半角名称</summary>
        public const string ct_Col_ModelHalfNameRF = "ModelHalfNameRF";
        /// <summary>型式（フル型）</summary>
        public const string ct_Col_FullModelRF = "FullModelRF";
        /// <summary>車両走行距離</summary>
        public const string ct_Col_MileageRF = "MileageRF";
        /// <summary> LineShow</summary> 
        public const string ct_Col_LineShow = "LineShow";
        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 車輌別出荷実績表 テーブルスキーマ情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 車輌別出荷実績表 テーブルスキーマ情報クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2009.09.15</br>
		/// </remarks>
        public PMSYA02005EA()
		{
		}
		#endregion

        #region ■ Static Public Method
        #region ◆ 仕入データDataSetテーブルスキーマ設定
        /// <summary>
        /// 仕入データDataSetテーブルスキーマ設定
		/// </summary>
        /// <param name="ds">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 仕入データデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_CarShipListData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_CarShipListData].Clear();
            }
            else
            {
                // スキーマ設定
                
                ds.Tables.Add(Tbl_CarShipListData);

                DataTable dt = ds.Tables[Tbl_CarShipListData];

                // 売上伝票番号
                dt.Columns.Add(ct_Col_SalesSlipNumRF, typeof(string));
                dt.Columns[ct_Col_SalesSlipNumRF].DefaultValue = "";
                // 実績計上拠点コード
                dt.Columns.Add(ct_Col_ResultsAddUpSecCdRF, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCdRF].DefaultValue = "";
                // 売上日付
                dt.Columns.Add(ct_Col_SalesDateRF, typeof(string));
                dt.Columns[ct_Col_SalesDateRF].DefaultValue = "";
                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCodeRF, typeof(string));
                dt.Columns[ct_Col_CustomerCodeRF].DefaultValue = "";
                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnmRF, typeof(string));
                dt.Columns[ct_Col_CustomerSnmRF].DefaultValue = "";
                // 売上行番号
                dt.Columns.Add(ct_Col_SalesRowNoRF, typeof(string));
                dt.Columns[ct_Col_SalesRowNoRF].DefaultValue = "";
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCdRF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCdRF].DefaultValue = "";
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNoRF, typeof(string));
                dt.Columns[ct_Col_GoodsNoRF].DefaultValue = "";
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKanaRF, typeof(string));
                dt.Columns[ct_Col_GoodsNameKanaRF].DefaultValue = "";
                // BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRF].DefaultValue = "";
                // BL商品コードCopy
                dt.Columns.Add(ct_Col_BLGoodsCodeRFCopy, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRFCopy].DefaultValue = "";
                // BL商品コード名称（半角）
                dt.Columns.Add(ct_Col_BLGoodsHalfNameRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfNameRF].DefaultValue = "";
                // BLグループコード
                dt.Columns.Add(ct_Col_BLGroupCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGroupCodeRF].DefaultValue = "";
                // BLグループコードCopy
                dt.Columns.Add(ct_Col_BLGroupCodeRFCopy, typeof(string));
                dt.Columns[ct_Col_BLGroupCodeRFCopy].DefaultValue = "";
                // BLグループコードカナ名称
                dt.Columns.Add(ct_Col_BLGroupKanaNameRF, typeof(string));
                dt.Columns[ct_Col_BLGroupKanaNameRF].DefaultValue = "";
                // 定価（税抜，浮動）
                dt.Columns.Add(ct_Col_ListPriceTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_ListPriceTaxExcFlRF].DefaultValue = "";
                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFlRF].DefaultValue = "";
                // 原価単価
                dt.Columns.Add(ct_Col_SalesUnitCostRF, typeof(string));
                dt.Columns[ct_Col_SalesUnitCostRF].DefaultValue = "";
                // 出荷数
                dt.Columns.Add(ct_Col_ShipmentCntRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntRF].DefaultValue = "";
                // 出荷数(在庫)
                dt.Columns.Add(ct_Col_ShipmentCntInRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntInRF].DefaultValue = "";
                // 出荷数(取寄)
                dt.Columns.Add(ct_Col_ShipmentCntNotInRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntNotInRF].DefaultValue = "";
                // 売上在庫取寄せ区分
                dt.Columns.Add(ct_Col_SalesOrderDivCdRF, typeof(string));
                dt.Columns[ct_Col_SalesOrderDivCdRF].DefaultValue = "";
                // 売上金額（税抜き）
                dt.Columns.Add(ct_Col_SalesMoneyTaxExcRF, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExcRF].DefaultValue = "";
                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnmRF, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnmRF].DefaultValue = "";
                // 粗利金額
                dt.Columns.Add(ct_Col_GrossProfitRF, typeof(string));
                dt.Columns[ct_Col_GrossProfitRF].DefaultValue = "";
                // 粗利率
                dt.Columns.Add(ct_Col_GrossPivRF, typeof(string));
                dt.Columns[ct_Col_GrossPivRF].DefaultValue = "";
                // 車両管理番号
                dt.Columns.Add(ct_Col_CarMngNoRF, typeof(string));
                dt.Columns[ct_Col_CarMngNoRF].DefaultValue = "";
                // 車輌管理コード
                dt.Columns.Add(ct_Col_CarMngCodeRF, typeof(string));
                dt.Columns[ct_Col_CarMngCodeRF].DefaultValue = "";
                // 陸運事務局名称
                dt.Columns.Add(ct_Col_NumberPlate1NameRF, typeof(string));
                dt.Columns[ct_Col_NumberPlate1NameRF].DefaultValue = "";
                // 車両登録番号（種別）
                dt.Columns.Add(ct_Col_NumberPlate2RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate2RF].DefaultValue = "";
                // 車両登録番号（カナ）
                dt.Columns.Add(ct_Col_NumberPlate3RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate3RF].DefaultValue = "";
                // 車両登録番号（プレート番号）
                dt.Columns.Add(ct_Col_NumberPlate4RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate4RF].DefaultValue = "";
                // 初年度
                dt.Columns.Add(ct_Col_FirstEntryDateRF, typeof(string));
                dt.Columns[ct_Col_FirstEntryDateRF].DefaultValue = "";
                // メーカーコード
                dt.Columns.Add(ct_Col_MakerCodeRF, typeof(string));
                dt.Columns[ct_Col_MakerCodeRF].DefaultValue = "";
                // 車種コード
                dt.Columns.Add(ct_Col_ModelCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelCodeRF].DefaultValue = "";
                // 車種サブコード
                dt.Columns.Add(ct_Col_ModelSubCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelSubCodeRF].DefaultValue = "";
                // 車種半角名称
                dt.Columns.Add(ct_Col_ModelHalfNameRF, typeof(string));
                dt.Columns[ct_Col_ModelHalfNameRF].DefaultValue = "";
                // 型式（フル型）
                dt.Columns.Add(ct_Col_FullModelRF, typeof(string));
                dt.Columns[ct_Col_FullModelRF].DefaultValue = "";
                // 車両走行距離
                dt.Columns.Add(ct_Col_MileageRF, typeof(string));
                dt.Columns[ct_Col_MileageRF].DefaultValue = "";
                 // LineShow
                dt.Columns.Add(ct_Col_LineShow, typeof(bool));
                dt.Columns[ct_Col_LineShow].DefaultValue = true;

            }
        }

        #endregion ◆ 仕入データDataSetテーブルスキーマ設定

        #endregion ■ Static Public Method

    }
}

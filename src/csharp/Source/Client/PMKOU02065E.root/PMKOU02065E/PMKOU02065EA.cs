//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009.05.13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入売上実績表テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class PMKOU02065EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_StockSalesResultInfoAccRecMain = "Tbl_StockSalesResultInfoAccRecMain";

        /// <summary> 拠点コード </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点名 </summary>
        /// <remarks>拠点情報設定マスタ 拠点ガイド名称</remarks>
        public const string Col_SectionGuideNm = "SectionGuideNm";

        /// <summary> 得意先コード </summary>
        /// <remarks>売上データ 得意先コード</remarks>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> 得意先名 </summary>
        /// <remarks>売上データ 得意先名称</remarks>
        public const string Col_CustomerName = "CustomerName";

        /// <summary> 売上日付 </summary>
        /// <remarks>売上データ 売上日付</remarks>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> 伝票番号 </summary>
        /// <remarks>売上データ 売上伝票番号</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 区分 </summary>
        /// <remarks>伝票判断</remarks>
        public const string Col_KuBec = "KuBec";

        /// <summary> 担当者 </summary>
        /// <remarks>仕入データ　仕入担当者名称</remarks>
        public const string Col_StockAgentName = "StockAgentName";

        /// <summary> 受注者 </summary>
        /// <remarks>売上データ　受付従業員名称</remarks>
        public const string Col_FrontEmployeeNm = "FrontEmployeeNm";

        /// <summary> 発行者 </summary>
        /// <remarks>売上データ　売上入力者名称</remarks>
        public const string Col_SalesInputName = "SalesInputName";

        /// <summary> リマーク１ </summary>
        /// <remarks>売上データ　ＵＯＥリマーク１</remarks>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> リマーク２ </summary>
        /// <remarks>売上データ　ＵＯＥリマーク２</remarks>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> 備考１ </summary>
        /// <remarks>売上データ　伝票備考</remarks>
        public const string Col_SlipNote = "SlipNote";

        /// <summary> 備考２ </summary>
        /// <remarks>売上データ　伝票備考２</remarks>
        public const string Col_SlipNote2 = "SlipNote2";

        /// <summary> 備考３ </summary>
        /// <remarks>売上データ　伝票備考３</remarks>
        public const string Col_SlipNote3 = "SlipNote3";

        /// <summary> 仕入備考</summary>
        /// <remarks>仕入データ　仕入伝票備考1</remarks>
        public const string Col_SupplierSlipNote1 = "SupplierSlipNote1";

        /// <summary> 品番 </summary>
        /// <remarks>仕入明細データ　商品番号</remarks>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 在取 </summary>
        /// <remarks>仕入明細データ　仕入在庫取寄せ区分</remarks>
        public const string Col_StockOrderDivCd = "StockOrderDivCd";

        /// <summary> 品名 </summary>
        /// <remarks>仕入明細データ　商品名称</remarks>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> 標準価格 </summary>
        /// <remarks>仕入明細データ　定価（税抜，浮動）</remarks>
        public const string Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";

        /// <summary> 数量 </summary>
        /// <remarks>仕入明細データ　仕入数</remarks>
        public const string Col_StockCount = "StockCount";

        /// <summary> 売単価 </summary>
        /// <remarks>売上明細データ　売上単価（税抜，浮動）</remarks>
        public const string Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> 売上金額 </summary>
        /// <remarks>売上明細データ　売上金額（税抜き）</remarks>
        public const string Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> 粗利金額 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_GrpMoney = "GrpMoney";

        /// <summary> 粗利率 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_GrpPct = "GrpPct";

        /// <summary> マーク </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_Maku = "Maku";

        /// <summary> 原単価 </summary>
        /// <remarks>仕入明細データ　仕入単価（税抜，浮動）</remarks>
        public const string Col_StockUnitPriceFl = "StockUnitPriceFl";

        /// <summary> 仕入金額 </summary>
        /// <remarks>仕入明細データ　仕入金額（税抜き）</remarks>
        public const string Col_StockPriceTaxExc = "StockPriceTaxExc";

        /// <summary> 仕入先 </summary>
        /// <remarks>仕入データ　仕入先コード</remarks>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 伝票番号 </summary>
        /// <remarks>仕入データ　相手先伝票番号</remarks>
        public const string Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> 仕入日付 </summary>
        /// <remarks>仕入データ　仕入日</remarks>
        public const string Col_StockDate = "StockDate";

        /// <summary> 仕入先 </summary>
        /// <remarks>仕入データ　仕入先コード</remarks>
        public const string Col_SupplierCdForSort = "SupplierCdForSort";

        /// <summary> 伝票番号 </summary>
        /// <remarks>仕入データ　相手先伝票番号</remarks>
        public const string Col_PartySaleSlipNumForSort = "PartySaleSlipNumForSort";

        /// <summary> 仕入日付 </summary>
        /// <remarks>仕入データ　仕入日</remarks>
        public const string Col_StockDateForSort = "StockDateForSort";

        /// <summary>仕入先計</summary>
        public const string CT_StockConf_DailyHeaderDataField = "DailyHeaderDataField";

        //仕入 
        /// <summary> 売上金額 </summary>
        /// <remarks>売上明細データ　売上金額（税抜き）</remarks>
        public const string Col_SalesSalesMoneyTaxExc = "SalesSalesMoneyTaxExc";

        /// <summary> 粗利金額 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SalesGrpMoney = "SalesGrpMoney";

        /// <summary> 粗利率 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SalesGrpPct = "SalesGrpPct";

        /// <summary> 仕入金額 </summary>
        /// <remarks>仕入明細データ　仕入金額（税抜き）</remarks>
        public const string Col_SalesStockPriceTaxExc = "SalesStockPriceTaxExc";

        //返品
        /// <summary> 売上金額 </summary>
        /// <remarks>売上明細データ　売上金額（税抜き）</remarks>
        public const string Col_RetGdsSalesMoneyTaxExc = "RetGdsSalesMoneyTaxExc";

        /// <summary> 粗利金額 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_RetGdsGrpMoney = "RetGdsGrpMoney";

        /// <summary> 粗利率 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_RetGdsGrpPct = "RetGdsGrpPct";

        /// <summary> 仕入金額 </summary>
        /// <remarks>仕入明細データ　仕入金額（税抜き）</remarks>
        public const string Col_RetGdsStockPriceTaxExc = "RetGdsStockPriceTaxExc";

        //値引
        /// <summary> 売上金額 </summary>
        /// <remarks>売上明細データ　売上金額（税抜き）</remarks>
        public const string Col_DistSalesMoneyTaxExc = "DistSalesMoneyTaxExc";

        /// <summary> 粗利金額 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_DistGrpMoney = "DistGrpMoney";

        /// <summary> 粗利率 </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_DistGrpPct = "DistGrpPct";

        /// <summary> 仕入金額 </summary>
        /// <remarks>仕入明細データ　仕入金額（税抜き）</remarks>
        public const string Col_DistStockPriceTaxExc = "DistStockPriceTaxExc";

        /// <summary> 仕入伝票番号 </summary>
        /// <remarks>仕入明細データ　仕入伝票番号</remarks>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> 仕入行番号 </summary>
        /// <remarks>仕入明細データ　仕入行番号</remarks>
        public const string Col_StockRowNo = "StockRowNo";

        /// <summary> 仕入数 </summary>
        /// <remarks> なし</remarks>
        public const string Col_SalesCountNumber = "SalesCountNumber";

        /// <summary> 返品数 </summary>
        /// <remarks> なし</remarks>
        public const string Col_ReturnCountNumber = "ReturnCountNumber";

        /// <summary> 合計数 </summary>
        /// <remarks> なし</remarks>
        public const string Col_TotleCountNumber = "TotleCountNumber";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 仕入売上実績表 帳票データ用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表 帳票データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02065EA()
        {

        }
        #endregion

        #region ■ Static Public Method
        #region ◆ CreateDataTable(ref DataSet ds)
        /// <summary>
        /// 帳票DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データセット</param>
        /// <remarks>
        /// <br>Note       : 帳票データセットのスキーマを設定する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static public void CreateDataTableStockSalesResultInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_StockSalesResultInfoAccRecMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_StockSalesResultInfoAccRecMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_StockSalesResultInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_StockSalesResultInfoAccRecMain];

                dt.Columns.Add(Col_SectionCode, typeof(string));//拠点コード 
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionGuideNm, typeof(string));//拠点名 
                dt.Columns[Col_SectionGuideNm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//得意先コード 
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerName, typeof(string));//得意先名
                dt.Columns[Col_CustomerName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesDate, typeof(string));//売上日付
                dt.Columns[Col_SalesDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//伝票番号
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_KuBec, typeof(string));//区分
                dt.Columns[Col_KuBec].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockAgentName, typeof(string));//担当者
                dt.Columns[Col_StockAgentName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_FrontEmployeeNm, typeof(string));//受注者
                dt.Columns[Col_FrontEmployeeNm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesInputName, typeof(string));//発行者
                dt.Columns[Col_SalesInputName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));//リマーク１
                dt.Columns[Col_UoeRemark1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));//リマーク２
                dt.Columns[Col_UoeRemark2].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote, typeof(string));//備考１
                dt.Columns[Col_SlipNote].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote2, typeof(string));//備考２
                dt.Columns[Col_SlipNote2].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SlipNote3, typeof(string));//備考３
                dt.Columns[Col_SlipNote3].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierSlipNote1, typeof(string));//仕入備考
                dt.Columns[Col_SupplierSlipNote1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsNo, typeof(string));//品番
                dt.Columns[Col_GoodsNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockOrderDivCd, typeof(string));//在取
                dt.Columns[Col_StockOrderDivCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsName, typeof(string));//品名
                dt.Columns[Col_GoodsName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ListPriceTaxExcFl, typeof(string));//標準価格
                dt.Columns[Col_ListPriceTaxExcFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockCount, typeof(string));//数量
                dt.Columns[Col_StockCount].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesUnPrcTaxExcFl, typeof(string));//売単価 
                dt.Columns[Col_SalesUnPrcTaxExcFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesMoneyTaxExc, typeof(string));//売上金額
                dt.Columns[Col_SalesMoneyTaxExc].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GrpMoney, typeof(string));//粗利金額
                dt.Columns[Col_GrpMoney].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GrpPct, typeof(string));//粗利率 
                dt.Columns[Col_GrpPct].DefaultValue = string.Empty;

                dt.Columns.Add(Col_Maku, typeof(string));//マーク 
                dt.Columns[Col_Maku].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockUnitPriceFl, typeof(string));//原単価 
                dt.Columns[Col_StockUnitPriceFl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockPriceTaxExc, typeof(string));//仕入金額
                dt.Columns[Col_StockPriceTaxExc].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCd, typeof(string));//仕入先 
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySaleSlipNum, typeof(string));//伝票番号 
                dt.Columns[Col_PartySaleSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDate, typeof(string));//仕入日付
                dt.Columns[Col_StockDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdForSort, typeof(string));//仕入先 
                dt.Columns[Col_SupplierCdForSort].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySaleSlipNumForSort, typeof(string));//伝票番号 
                dt.Columns[Col_PartySaleSlipNumForSort].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDateForSort, typeof(string));//仕入日付
                dt.Columns[Col_StockDateForSort].DefaultValue = string.Empty;

                // 仕入先計
                dt.Columns.Add(CT_StockConf_DailyHeaderDataField, typeof(string));
                dt.Columns[CT_StockConf_DailyHeaderDataField].DefaultValue = string.Empty;

                //売上金額(仕入)
                dt.Columns.Add(Col_SalesSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_SalesSalesMoneyTaxExc].DefaultValue = string.Empty;

                //粗利金額(仕入)
                dt.Columns.Add(Col_SalesGrpMoney, typeof(string));
                dt.Columns[Col_SalesGrpMoney].DefaultValue = string.Empty;

                // 粗利率(仕入)
                dt.Columns.Add(Col_SalesGrpPct, typeof(string));
                dt.Columns[Col_SalesGrpPct].DefaultValue = string.Empty;

                //仕入金額(仕入)
                dt.Columns.Add(Col_SalesStockPriceTaxExc, typeof(string));
                dt.Columns[Col_SalesStockPriceTaxExc].DefaultValue = string.Empty;

                //売上金額(返品)
                dt.Columns.Add(Col_RetGdsSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_RetGdsSalesMoneyTaxExc].DefaultValue = string.Empty;

                //粗利金額(返品)
                dt.Columns.Add(Col_RetGdsGrpMoney, typeof(string));
                dt.Columns[Col_RetGdsGrpMoney].DefaultValue = string.Empty;

                //粗利率(返品)
                dt.Columns.Add(Col_RetGdsGrpPct, typeof(string));
                dt.Columns[Col_RetGdsGrpPct].DefaultValue = string.Empty;

                //仕入金額(返品)
                dt.Columns.Add(Col_RetGdsStockPriceTaxExc, typeof(string));
                dt.Columns[Col_RetGdsStockPriceTaxExc].DefaultValue = string.Empty;

                //売上金額(値引) 
                dt.Columns.Add(Col_DistSalesMoneyTaxExc, typeof(string));
                dt.Columns[Col_DistSalesMoneyTaxExc].DefaultValue = string.Empty;

                //粗利金額(値引) 
                dt.Columns.Add(Col_DistGrpMoney, typeof(string));
                dt.Columns[Col_DistGrpMoney].DefaultValue = string.Empty;

                //粗利率(値引)
                dt.Columns.Add(Col_DistGrpPct, typeof(string));
                dt.Columns[Col_DistGrpPct].DefaultValue = string.Empty;

                //仕入金額(値引)
                dt.Columns.Add(Col_DistStockPriceTaxExc, typeof(string));
                dt.Columns[Col_DistStockPriceTaxExc].DefaultValue = string.Empty;

                //仕入伝票番号
                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));
                dt.Columns[Col_SupplierSlipNo].DefaultValue = string.Empty;

                //仕入行番号
                dt.Columns.Add(Col_StockRowNo, typeof(string));
                dt.Columns[Col_StockRowNo].DefaultValue = string.Empty;

                // 仕入数 
                dt.Columns.Add(Col_SalesCountNumber, typeof(string));
                dt.Columns[Col_SalesCountNumber].DefaultValue = string.Empty;

                // 返品数 
                dt.Columns.Add(Col_ReturnCountNumber, typeof(string));
                dt.Columns[Col_ReturnCountNumber].DefaultValue = string.Empty;

                // 合計数
                dt.Columns.Add(Col_TotleCountNumber, typeof(string));
                dt.Columns[Col_TotleCountNumber].DefaultValue = string.Empty;

                dt.Columns.Add(Col_LineFlag, typeof(bool));//lineflag
                dt.Columns[Col_LineFlag].DefaultValue = false;

            }
        }
        #endregion
        #endregion
    }
}

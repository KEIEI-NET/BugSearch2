using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入先元帳 支払明細 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上内容分析表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKOU02035EB
    {
        #region ■ Public定数
        /// <summary> 企業コード </summary>
        public const string ct_Tbl_EnterpriseCode = "EnterpriseCode";
        /// <summary> 計上拠点コード </summary>
        public const string ct_Tbl_AddUpSecCode = "AddUpSecCode";
        /// <summary> 支払先コード </summary>
        public const string ct_Tbl_PayeeCode = "PayeeCode";
        /// <summary> 支払先名称 </summary>
        public const string ct_Tbl_PayeeName = "PayeeName";
        /// <summary> 支払先名称2 </summary>
        public const string ct_Tbl_PayeeName2 = "PayeeName2";
        /// <summary> 支払先略称 </summary>
        public const string ct_Tbl_PayeeSnm = "PayeeSnm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Tbl_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名1 </summary>
        public const string ct_Tbl_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string ct_Tbl_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Tbl_SupplierSnm = "SupplierSnm";
        /// <summary> 計上年月日 </summary>
        public const string ct_Tbl_AddUpDate = "AddUpDate";
        /// <summary> 計上年月 </summary>
        public const string ct_Tbl_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> 前回買掛金額 </summary>
        public const string ct_Tbl_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> 仕入2回前残高（買掛計） </summary>
        public const string ct_Tbl_StckTtl2TmBfBlAccPay = "StckTtl2TmBfBlAccPay";
        /// <summary> 仕入3回前残高（買掛計） </summary>
        public const string ct_Tbl_StckTtl3TmBfBlAccPay = "StckTtl3TmBfBlAccPay";
        /// <summary> 今回支払金額（通常支払） </summary>
        public const string ct_Tbl_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> 今回繰越残高（買掛計） </summary>
        public const string ct_Tbl_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> 相殺後今回仕入金額 </summary>
        public const string ct_Tbl_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string ct_Tbl_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> 今回返品金額 </summary>
        public const string ct_Tbl_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> 今回返品消費税 </summary>
        public const string ct_Tbl_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> 今回値引金額 </summary>
        public const string ct_Tbl_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> 今回値引消費税 </summary>
        public const string ct_Tbl_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> 消費税調整額 </summary>
        public const string ct_Tbl_TaxAdjust = "TaxAdjust";
        /// <summary> 残高調整額 </summary>
        public const string ct_Tbl_BalanceAdjust = "BalanceAdjust";
        /// <summary> 仕入合計残高（買掛計） </summary>
        public const string ct_Tbl_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> 月次更新実行年月日 </summary>
        public const string ct_Tbl_MonthAddUpExpDate = "MonthAddUpExpDate";
        /// <summary> 月次更新開始年月日 </summary>
        public const string ct_Tbl_StMonCAddUpUpdDate = "StMonCAddUpUpdDate";
        /// <summary> 前回月次更新年月日 </summary>
        public const string ct_Tbl_LaMonCAddUpUpdDate = "LaMonCAddUpUpdDate";
        /// <summary> 仕入伝票枚数 </summary>
        public const string ct_Tbl_StockSlipCount = "StockSlipCount";
        /// <summary> 締済みフラグ </summary>
        public const string ct_Tbl_CloseFlg = "CloseFlg";


        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMKOU02035EB()
        {
        }

        #endregion

        #region ■ publicメソッド
        /// <summary>
        /// 売上内容分析表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 売上内容分析表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                //各カラムのデフォルトの値
                string defaultValueOfstring = string.Empty;
                int defaultValueOfInt32 = 0,
                    defaultValueOfInt64 = 0;

                // 企業コード
                dt.Columns.Add(ct_Tbl_EnterpriseCode, typeof(string));
                dt.Columns[ct_Tbl_EnterpriseCode].DefaultValue = defaultValueOfstring;
                // 計上拠点コード
                dt.Columns.Add(ct_Tbl_AddUpSecCode, typeof(string));
                dt.Columns[ct_Tbl_AddUpSecCode].DefaultValue = defaultValueOfstring;
                // 支払先コード
                dt.Columns.Add(ct_Tbl_PayeeCode, typeof(Int32));
                dt.Columns[ct_Tbl_PayeeCode].DefaultValue = defaultValueOfInt32;
                // 支払先名称
                dt.Columns.Add(ct_Tbl_PayeeName, typeof(string));
                dt.Columns[ct_Tbl_PayeeName].DefaultValue = defaultValueOfstring;
                // 支払先名称2
                dt.Columns.Add(ct_Tbl_PayeeName2, typeof(string));
                dt.Columns[ct_Tbl_PayeeName2].DefaultValue = defaultValueOfstring;
                // 支払先略称
                dt.Columns.Add(ct_Tbl_PayeeSnm, typeof(string));
                dt.Columns[ct_Tbl_PayeeSnm].DefaultValue = defaultValueOfstring;
                // 仕入先コード
                dt.Columns.Add(ct_Tbl_SupplierCd, typeof(Int32));
                dt.Columns[ct_Tbl_SupplierCd].DefaultValue = defaultValueOfInt32;
                // 仕入先名1
                dt.Columns.Add(ct_Tbl_SupplierNm1, typeof(string));
                dt.Columns[ct_Tbl_SupplierNm1].DefaultValue = defaultValueOfstring;
                // 仕入先名2
                dt.Columns.Add(ct_Tbl_SupplierNm2, typeof(string));
                dt.Columns[ct_Tbl_SupplierNm2].DefaultValue = defaultValueOfstring;
                // 仕入先略称
                dt.Columns.Add(ct_Tbl_SupplierSnm, typeof(string));
                dt.Columns[ct_Tbl_SupplierSnm].DefaultValue = defaultValueOfstring;
                // 計上年月日
                dt.Columns.Add(ct_Tbl_AddUpDate, typeof(Int32));
                dt.Columns[ct_Tbl_AddUpDate].DefaultValue = defaultValueOfInt32;
                // 計上年月
                dt.Columns.Add(ct_Tbl_AddUpYearMonth, typeof(Int32));
                dt.Columns[ct_Tbl_AddUpYearMonth].DefaultValue = defaultValueOfInt32;
                // 前回買掛金額
                dt.Columns.Add(ct_Tbl_LastTimeAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_LastTimeAccPay].DefaultValue = defaultValueOfInt64;
                // 仕入2回前残高（買掛計）
                dt.Columns.Add(ct_Tbl_StckTtl2TmBfBlAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtl2TmBfBlAccPay].DefaultValue = defaultValueOfInt64;
                // 仕入3回前残高（買掛計）
                dt.Columns.Add(ct_Tbl_StckTtl3TmBfBlAccPay, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtl3TmBfBlAccPay].DefaultValue = defaultValueOfInt64;
                // 今回支払金額（通常支払）
                dt.Columns.Add(ct_Tbl_ThisTimePayNrml, typeof(Int64));
                dt.Columns[ct_Tbl_ThisTimePayNrml].DefaultValue = defaultValueOfInt64;
                // 今回繰越残高（買掛計）
                dt.Columns.Add(ct_Tbl_ThisTimeTtlBlcAcPay, typeof(Int64));
                dt.Columns[ct_Tbl_ThisTimeTtlBlcAcPay].DefaultValue = defaultValueOfInt64;
                // 相殺後今回仕入金額
                dt.Columns.Add(ct_Tbl_OfsThisTimeStock, typeof(Int64));
                dt.Columns[ct_Tbl_OfsThisTimeStock].DefaultValue = defaultValueOfInt64;
                // 相殺後今回仕入消費税
                dt.Columns.Add(ct_Tbl_OfsThisStockTax, typeof(Int64));
                dt.Columns[ct_Tbl_OfsThisStockTax].DefaultValue = defaultValueOfInt64;
                // 今回返品金額
                dt.Columns.Add(ct_Tbl_ThisStckPricRgds, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStckPricRgds].DefaultValue = defaultValueOfInt64;
                // 今回返品消費税
                dt.Columns.Add(ct_Tbl_ThisStcPrcTaxRgds, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStcPrcTaxRgds].DefaultValue = defaultValueOfInt64;
                // 今回値引金額
                dt.Columns.Add(ct_Tbl_ThisStckPricDis, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStckPricDis].DefaultValue = defaultValueOfInt64;
                // 今回値引消費税
                dt.Columns.Add(ct_Tbl_ThisStcPrcTaxDis, typeof(Int64));
                dt.Columns[ct_Tbl_ThisStcPrcTaxDis].DefaultValue = defaultValueOfInt64;
                // 消費税調整額
                dt.Columns.Add(ct_Tbl_TaxAdjust, typeof(Int64));
                dt.Columns[ct_Tbl_TaxAdjust].DefaultValue = defaultValueOfInt64;
                // 残高調整額
                dt.Columns.Add(ct_Tbl_BalanceAdjust, typeof(Int64));
                dt.Columns[ct_Tbl_BalanceAdjust].DefaultValue = defaultValueOfInt64;
                // 仕入合計残高（買掛計）
                dt.Columns.Add(ct_Tbl_StckTtlAccPayBalance, typeof(Int64));
                dt.Columns[ct_Tbl_StckTtlAccPayBalance].DefaultValue = defaultValueOfInt64;
                // 月次更新実行年月日
                dt.Columns.Add(ct_Tbl_MonthAddUpExpDate, typeof(Int32));
                dt.Columns[ct_Tbl_MonthAddUpExpDate].DefaultValue = defaultValueOfInt32;
                // 月次更新開始年月日
                dt.Columns.Add(ct_Tbl_StMonCAddUpUpdDate, typeof(Int32));
                dt.Columns[ct_Tbl_StMonCAddUpUpdDate].DefaultValue = defaultValueOfInt32;
                // 前回月次更新年月日
                dt.Columns.Add(ct_Tbl_LaMonCAddUpUpdDate, typeof(Int32));
                dt.Columns[ct_Tbl_LaMonCAddUpUpdDate].DefaultValue = defaultValueOfInt32;
                // 仕入伝票枚数
                dt.Columns.Add(ct_Tbl_StockSlipCount, typeof(Int32));
                dt.Columns[ct_Tbl_StockSlipCount].DefaultValue = defaultValueOfInt32;
                // 締済みフラグ
                dt.Columns.Add(ct_Tbl_CloseFlg, typeof(Int32));
                dt.Columns[ct_Tbl_CloseFlg].DefaultValue = defaultValueOfInt32;

            }
        }
        #endregion
    }
}

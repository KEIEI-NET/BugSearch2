//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
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
    /// 仕入チェックリスト テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェックリスト テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.05.10</br>
    /// </remarks>
    public class PMKOU02055EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockSlipData = "Tbl_StockSlipData";
        
        /// <summary> 日付(仕入データの入荷日) </summary>
        public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";

        /// <summary> 伝票番号(仕入データの相手先伝票番号) </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> 拠点コード(仕入データの拠点コード) </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        
        /// <summary> 仕入SEQ番号(仕入データの仕入伝票番号) </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> 仕入日(仕入データの仕入日) </summary>
        public const string ct_Col_StockDate = "StockDate";
        
        /// <summary> 仕入額(仕入データの仕入額合計) </summary>
        public const string ct_Col_StockTotalPrice = "StockTotalPrice";

        /// <summary> 備考(仕入データの仕入伝票備考1) </summary>
        public const string ct_Col_SupplierSlipNote1 = "SupplierSlipNote1";

        /// <summary> UOE(仕入データのUOEリマーク1,2？) </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";

        /// <summary> 日付(テキストデータの入荷日) </summary>
        public const string ct_Col_Csv_ArrivalGoodsDay = "Csv_ArrivalGoodsDay";

        /// <summary> 伝票番号(テキストデータの伝票番号) </summary>
        public const string ct_Col_Csv_PartySaleSlipNum = "Csv_PartySaleSlipNum";

        /// <summary> 拠点コード(テキストデータの拠点コード) </summary>
        public const string ct_Col_Csv_SectionCode = "Csv_SectionCode";

        /// <summary> 仕入日(テキストデータの仕入日) </summary>
        public const string ct_Col_Csv_StockDate = "Csv_StockDate";

        /// <summary> 仕入額(テキストデータの仕入額) </summary>
        public const string ct_Col_Csv_StockTotalPrice = "Csv_StockTotalPrice";

        /// <summary> 備考(テキストデータの備考) </summary>
        public const string ct_Col_Csv_SupplierSlipNote = "Csv_SupplierSlipNote";

        /// <summary> チェック内容(ﾁｪｯｸ対象により印字(仕入先伝票無し/ＰＭ伝票無し/伝票金額不一致/日付不一致/金額・日付不一致/ＰＭ伝票№重複)) </summary>
        public const string ct_Col_CheckContent = "CheckContent";

        /// <summary> 印刷区分（不一致分/一致分） </summary>
        public const string ct_Col_printDiv = "PrintDiv";

        /// <summary> エラー区分</summary>
        public const string ct_Col_errDiv = "errDiv";

        /// <summary> 表示用日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary> データ表示判断</summary>
        public const string ct_Col_isNotShow = "IsNotShow";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 仕入チェックリスト テーブルスキーマ情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入チェックリスト テーブルスキーマ情報クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2009.05.10</br>
		/// </remarks>
        public PMKOU02055EA()
		{
		}
		#endregion

        #region ■ Static Public Method
        #region ◆ 仕入データDataSetテーブルスキーマ設定
        /// <summary>
        /// 仕入データDataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 仕入データデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
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
                dt = new DataTable(ct_Tbl_StockSlipData);

                // データ表示判断
                dt.Columns.Add(ct_Col_isNotShow, typeof(string));
                dt.Columns[ct_Col_isNotShow].DefaultValue = "";

                // エラー区分
                dt.Columns.Add(ct_Col_errDiv, typeof(Int32));
                dt.Columns[ct_Col_errDiv].DefaultValue = 0;

                // 印刷区分（不一致分/一致分）
                dt.Columns.Add(ct_Col_printDiv, typeof(string));
                dt.Columns[ct_Col_printDiv].DefaultValue = "";

                // 日付(仕入データの入荷日) 
                dt.Columns.Add(ct_Col_ArrivalGoodsDay, typeof(string));
                dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = "";

                // 伝票番号(仕入データの相手先伝票番号) 
                dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));    
                dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = "";

                // 拠点コード(仕入データの拠点コード)
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                // 仕入SEQ番号(仕入データの仕入伝票番号)
                dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(int));
                dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = 0;

                // 仕入日(仕入データの仕入日)
                dt.Columns.Add(ct_Col_StockDate, typeof(string));
                dt.Columns[ct_Col_StockDate].DefaultValue = "";

                // 仕入額(仕入データの仕入額合計) 
                dt.Columns.Add(ct_Col_StockTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_StockTotalPrice].DefaultValue = 0;

                // 備考(仕入データの仕入伝票備考1)
                dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
                dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = "";

                // UOE(仕入データのUOEリマーク1,2？)
                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = "";

                // 日付(テキストデータの入荷日)
                dt.Columns.Add(ct_Col_Csv_ArrivalGoodsDay, typeof(string));
                dt.Columns[ct_Col_Csv_ArrivalGoodsDay].DefaultValue = "";

                // 伝票番号(テキストデータの伝票番号)
                dt.Columns.Add(ct_Col_Csv_PartySaleSlipNum, typeof(int));
                dt.Columns[ct_Col_Csv_PartySaleSlipNum].DefaultValue = 0;

                // 拠点コード(テキストデータの拠点コード) 
                dt.Columns.Add(ct_Col_Csv_SectionCode, typeof(string));
                dt.Columns[ct_Col_Csv_SectionCode].DefaultValue = "";

                // 仕入日(テキストデータの仕入日)
                dt.Columns.Add(ct_Col_Csv_StockDate, typeof(string));
                dt.Columns[ct_Col_Csv_StockDate].DefaultValue = "";

                // 仕入額(テキストデータの仕入額) 
                dt.Columns.Add(ct_Col_Csv_StockTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_Csv_StockTotalPrice].DefaultValue = 0;

                // 備考(テキストデータの備考)
                dt.Columns.Add(ct_Col_Csv_SupplierSlipNote, typeof(string));
                dt.Columns[ct_Col_Csv_SupplierSlipNote].DefaultValue = "";

                // チェック内容
                dt.Columns.Add(ct_Col_CheckContent, typeof(string));
                dt.Columns[ct_Col_CheckContent].DefaultValue = "";
            }
        }

        #endregion ◆ 仕入データDataSetテーブルスキーマ設定

        #endregion ■ Static Public Method

    }
}

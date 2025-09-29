//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入不整合確認表
// プログラム概要   : 仕入不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009.04.13  修正内容 : 新規作成
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
    /// 仕入不整合確認表テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入不整合確認表テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public class PMKOU02045EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_StockSalesInfoAccRecMain = "Tbl_StockSalesInfoAccRecMain";

        /// <summary> 拠点コード </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点コード header </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SectionCodeHeader = "SectionCodeHeader";

        /// <summary> 拠点名称 </summary>
        /// <remarks>拠点情報設定マスタ　拠点名称</remarks>
        public const string Col_SectionName = "SectionName";

        /// <summary> 仕入先コード </summary>
        /// <remarks>仕入データ 仕入先コード</remarks>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先コード Header </summary>
        /// <remarks>仕入データ 仕入先コード</remarks>
        public const string Col_SupplierCdHeader = "SupplierCdHeader";

        /// <summary> 仕入先略称 </summary>
        /// <remarks>仕入データ 仕入先略称</remarks>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> 日付　仕入日 </summary>
        /// <remarks>仕入データ 仕入日</remarks>
        public const string Col_StockDate = "StockDate";

        /// <summary> 入力日付 </summary>
        /// <remarks>仕入データ 入力日</remarks>
        public const string Col_InputDay = "InputDay";

        /// <summary>　伝票番号 </summary>
        /// <remarks>売上明細データ 相手先伝票番号（明細）</remarks>
        public const string Col_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>　通番 </summary>
        /// <remarks>仕入明細データ 仕入伝票番号－仕入行番号</remarks>
        public const string Col_SeqNo = "SeqNo";

        /// <summary> 担当者 </summary>
        /// <remarks>仕入データ　仕入担当者コード</remarks>
        public const string Col_StockAgentCode = "StockAgentCode";

        /// <summary> BLコード </summary>
        /// <remarks>仕入明細データ　BL商品コード</remarks>
        public const string Col_BLGoodsCode = "BLGoodsCode";


        /// <summary> グループ </summary>
        /// <remarks>仕入明細データ　BLグループコード</remarks>
        public const string Col_BLGroupCode = "BLGroupCode";


        /// <summary> 倉庫 </summary>
        /// <remarks>仕入明細データ　倉庫コード</remarks>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> 得意先 </summary>
        /// <remarks>売上データ　得意先コード</remarks>
        public const string Col_CustomerCode = "CustomerCode";


        /// <summary> 売上伝票番号 </summary>
        /// <remarks>売上データ　売上伝票番号</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 不整合内容 </summary>
        /// <remarks>不整合内容</remarks>
        public const string Col_NayiYou = "NayiYou";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 仕入不整合確認表 帳票データ用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入不整合確認表 帳票データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMKOU02045EA()
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
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        static public void CreateDataTableStockSalesInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_StockSalesInfoAccRecMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_StockSalesInfoAccRecMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_StockSalesInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_StockSalesInfoAccRecMain];

                dt.Columns.Add(Col_SectionCode, typeof(string));//拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionCodeHeader, typeof(string));//拠点コード Header
                dt.Columns[Col_SectionCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionName, typeof(string));//拠点名称
                dt.Columns[Col_SectionName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCd, typeof(string));//仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdHeader, typeof(string));//仕入先コード Header
                dt.Columns[Col_SupplierCdHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));//仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDate, typeof(string));//日付　仕入日
                dt.Columns[Col_StockDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_InputDay, typeof(string));//入力日
                dt.Columns[Col_InputDay].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySlipNumDtl, typeof(string));//伝票番号
                dt.Columns[Col_PartySlipNumDtl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SeqNo, typeof(string));//通番
                dt.Columns[Col_SeqNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockAgentCode, typeof(string));//担当者
                dt.Columns[Col_StockAgentCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));//BLコード
                dt.Columns[Col_BLGoodsCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));//グループ
                dt.Columns[Col_BLGroupCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));//倉庫
                dt.Columns[Col_WarehouseCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//得意先
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//売上伝票番号
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_NayiYou, typeof(string));//不整合内容
                dt.Columns[Col_NayiYou].DefaultValue = string.Empty;

                dt.Columns.Add(Col_LineFlag, typeof(bool));//lineflag
                dt.Columns[Col_LineFlag].DefaultValue = false;
            }
        }
        #endregion
        #endregion
    }
}

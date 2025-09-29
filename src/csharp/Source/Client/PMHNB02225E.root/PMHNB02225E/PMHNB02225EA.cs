//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上不整合確認表
// プログラム概要   : 売上不整合確認表帳票を行う
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
    /// 売上不整合確認表テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上不整合確認表テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public class PMHNB02225EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_SalesStockInfoAccRecMain = "Tbl_SalesStockInfoAccRecMain";

        /// <summary> 拠点コード header </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SectionCodeHeader = "SectionCodeHeader";

        /// <summary> 拠点名称 </summary>
        /// <remarks>拠点情報設定マスタ　拠点名称</remarks>
        public const string Col_SectionName = "SectionName";

        /// <summary> 得意先 header </summary>
        /// <remarks>売上データ　得意先コード</remarks>
        public const string Col_CustomerCodeHeader = "CustomerCodeHeader";

        /// <summary> 得意先略称 </summary>
        /// <remarks>売上データ　得意先略称</remarks>
        public const string Col_CustomerSnm = "CustomerSnm";


        /// <summary> 日付　売上日付 </summary>
        /// <remarks>売上データ 売上日付</remarks>
        public const string Col_SalesDate = "SalesDate";


        /// <summary> 入力日付 </summary>
        /// <remarks>売上データ 伝票検索日付</remarks>
        public const string Col_SearchSlipDate = "SearchSlipDate";


        /// <summary> 売上伝票番号 </summary>
        /// <remarks>売上データ　売上伝票番号</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 拠点コード </summary>
        /// <remarks>仕入データ　拠点コード</remarks>
        public const string Col_SectionCode = "SectionCode";


        /// <summary> 入力 </summary>
        /// <remarks>売上データ 入力担当者コード</remarks>
        public const string Col_InputAgenCd = "InputAgenCd";

        /// <summary> 売上 </summary>
        /// <remarks>売上データ 売上入力者コード</remarks>
        public const string Col_SalesInputCode = "SalesInputCode";

        /// <summary> 受付 </summary>
        /// <remarks>売上データ 受付従業員コード</remarks>
        public const string Col_FrontEmployeeCd = "FrontEmployeeCd";

        /// <summary> 販売 </summary>
        /// <remarks>売上データ 販売従業員コード</remarks>
        public const string Col_SalesEmployeeCd = "SalesEmployeeCd";


        /// <summary> 得意先 </summary>
        /// <remarks>売上データ　得意先コード</remarks>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> BLコード </summary>
        /// <remarks>売上明細データ　BL商品コード</remarks>
        public const string Col_BLGoodsCode = "BLGoodsCode";


        /// <summary> グループ </summary>
        /// <remarks>売上明細データ　BLグループコード</remarks>
        public const string Col_BLGroupCode = "BLGroupCode";


        /// <summary> 倉庫 </summary>
        /// <remarks>売上明細データ　倉庫コード</remarks>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> エリア </summary>
        /// <remarks>売上データ　販売エリアコード</remarks>
        public const string Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> 業種 </summary>
        /// <remarks>売上データ　業種コード</remarks>
        public const string Col_BusinessTypeCode = "BusinessTypeCode";

        /// <summary> 仕入先コード </summary>
        /// <remarks>仕入データ 仕入先コード</remarks>
        public const string Col_SupplierCd = "SupplierCd";


        /// <summary>　伝票番号 </summary>
        /// <remarks>売上明細データ 相手先伝票番号（明細）</remarks>
        public const string Col_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>　仕入SEQ番号 </summary>
        /// <remarks>仕入明細データ 仕入伝票番号 SupplierSlipNo</remarks>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";


        /// <summary>　通番 </summary>
        /// <remarks>仕入明細データ 仕入伝票番号－仕入行番号</remarks>
        public const string Col_SeqNo = "SeqNo";

        /// <summary> 不整合内容 </summary>
        /// <remarks>不整合内容</remarks>
        public const string Col_NayiYou = "NayiYou";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 売上不整合確認表 帳票データ用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上不整合確認表 帳票データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMHNB02225EA()
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
        static public void CreateDataTableSalesStockInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_SalesStockInfoAccRecMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_SalesStockInfoAccRecMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_SalesStockInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_SalesStockInfoAccRecMain];



                dt.Columns.Add(Col_SectionCodeHeader, typeof(string));//拠点コード Header
                dt.Columns[Col_SectionCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionName, typeof(string));//拠点名称
                dt.Columns[Col_SectionName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCodeHeader, typeof(string));//得意先Header
                dt.Columns[Col_CustomerCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerSnm, typeof(string));//得意先略称
                dt.Columns[Col_CustomerSnm].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesDate, typeof(string));//日付　売上日付
                dt.Columns[Col_SalesDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SearchSlipDate, typeof(string));//入力日　伝票検索日付
                dt.Columns[Col_SearchSlipDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//売上伝票番号
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionCode, typeof(string));//拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_InputAgenCd, typeof(string));//入力
                dt.Columns[Col_InputAgenCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesInputCode, typeof(string));//売上
                dt.Columns[Col_SalesInputCode].DefaultValue = string.Empty;


                dt.Columns.Add(Col_FrontEmployeeCd, typeof(string));//受付
                dt.Columns[Col_FrontEmployeeCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesEmployeeCd, typeof(string));//販売
                dt.Columns[Col_SalesEmployeeCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//得意先
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));//BLコード
                dt.Columns[Col_BLGoodsCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));//グループ
                dt.Columns[Col_BLGroupCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));//倉庫
                dt.Columns[Col_WarehouseCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesAreaCode, typeof(string));//エリア
                dt.Columns[Col_SalesAreaCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BusinessTypeCode, typeof(string));//業種
                dt.Columns[Col_BusinessTypeCode].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SupplierCd, typeof(string));//仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_PartySlipNumDtl, typeof(string));//伝票番号
                dt.Columns[Col_PartySlipNumDtl].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));//仕入SEQ番号
                dt.Columns[Col_SupplierSlipNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SeqNo, typeof(string));//通番
                dt.Columns[Col_SeqNo].DefaultValue = string.Empty;


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

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
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 卸商商品価格改正用テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商商品価格改正用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public class PMKHN02306EA
    {
        # region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_GoodsWarnErrorCheck = "Tbl_GoodsWarnErrorCheck";
        /// <summary>仕入先ｺｰﾄﾞ</summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary>メーカー</summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>ＢＬコード</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>品番</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>品名</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary>定価</summary>
        public const string ct_Col_Price = "Price";
        /// <summary>仕入率</summary>
        public const string ct_Col_SaleRate = "SaleRate";
        /// <summary>原価</summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary>状態</summary>
        public const string ct_Col_PdfStatus = "PdfStatus";
        /// <summary>チェック</summary>
        public const string ct_Col_CheckMessage = "CheckMessage";
        /// <summary>印字順</summary>
        public const string ct_Col_Orderby = "Orderby";
        # endregion Public Const


        # region ■ Constructor
        /// <summary>
        /// 卸商商品価格改正用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02306EA()
        {
        }
        # endregion Constructor


        # region ■ Public Method
        /// <summary>
        /// 卸商商品価格改正DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データセット</param>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正データセットのスキーマを設定する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        static public void CreateDataTableGoodsWarnErrorCheck(ref DataTable dt)
        {
            if (dt == null)
                dt = new DataTable();

            if (dt.TableName == ct_Tbl_GoodsWarnErrorCheck)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定

                //仕入先ｺｰﾄﾞ
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = "";

                //メーカー
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = "";

                //ＢＬコード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = "";

                //品番
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                //品名
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";

                //定価
                dt.Columns.Add(ct_Col_Price, typeof(string));
                dt.Columns[ct_Col_Price].DefaultValue = "";

                //仕入率
                dt.Columns.Add(ct_Col_SaleRate, typeof(string));
                dt.Columns[ct_Col_SaleRate].DefaultValue = "";

                //原価
                dt.Columns.Add(ct_Col_SalesUnitCost, typeof(string));
                dt.Columns[ct_Col_SalesUnitCost].DefaultValue = "";

                //状態
                dt.Columns.Add(ct_Col_PdfStatus, typeof(string));
                dt.Columns[ct_Col_PdfStatus].DefaultValue = "";

                //チェック
                dt.Columns.Add(ct_Col_CheckMessage, typeof(string));
                dt.Columns[ct_Col_CheckMessage].DefaultValue = "";

                //印字順
                dt.Columns.Add(ct_Col_Orderby, typeof(int));
                dt.Columns[ct_Col_Orderby].DefaultValue = 0;
            }
        }
        # endregion Public Method
    }
}

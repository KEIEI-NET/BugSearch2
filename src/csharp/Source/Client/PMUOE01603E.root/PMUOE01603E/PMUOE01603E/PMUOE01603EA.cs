//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ホンダUOE WEBチェックリスト
// プログラム概要   : ホンダUOE WEBチェックリストテーブルスキーマ定義クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ホンダUOE WEBチェックリストテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ホンダUOE WEBチェックリストテーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.06.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SlipNoAlwcResult
    {
        /// <summary> テーブル名称 </summary>
        public const string Tbl_Result_SlipNoAlwc = "Tbl_Result_SlipNoAlwc";

        /// <summary> 仕入日 </summary>
        public const string Col_SupplierDate = "SupplierDate";

        /// <summary> 注文日 </summary>
        public const string Col_OrderDate = "OrderDate";

        /// <summary> 元仕入伝票番号 </summary>
        public const string Col_OldSupplierSlipNo = "OldSupplierSlipNo";

        /// <summary> 仕入伝票番号 </summary>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> 品番 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 品名 </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> 更新前単価 </summary>
        public const string Col_UpdatePrice = "UpdatePrice";

        /// <summary> 単価 </summary>
        public const string Col_Price = "Price";

        /// <summary> お買上一覧ファイル名称 </summary>
        public const string Col_FilesName = "FilesName";

        /// <summary> 更新結果 </summary>
        public const string Col_UpdateResult = "UpdateResult";

        /// <summary>
        /// ホンダUOE WEBチェックリストテーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ホンダUOE WEBチェックリストテーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.03</br>
		/// </remarks>
        public SlipNoAlwcResult()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        static public void CreateDataTableResultSlipNoAlwc(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_Result_SlipNoAlwc))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_Result_SlipNoAlwc].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_Result_SlipNoAlwc);

                DataTable dt = ds.Tables[Tbl_Result_SlipNoAlwc];

                string defValuestring = "";
                // Int32 defValueInt32 = 0;
                // DateTime defValueDateTime = new DateTime();
                // double defValueDouble = 0.0;

                dt.Columns.Add(Col_SupplierDate, typeof(string));
                dt.Columns[Col_SupplierDate].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OrderDate, typeof(string));
                dt.Columns[Col_OrderDate].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OldSupplierSlipNo, typeof(string));
                dt.Columns[Col_OldSupplierSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));
                dt.Columns[Col_SupplierSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdatePrice, typeof(string));
                dt.Columns[Col_UpdatePrice].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Price, typeof(string));
                dt.Columns[Col_Price].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FilesName, typeof(string));
                dt.Columns[Col_FilesName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdateResult, typeof(string));
                dt.Columns[Col_UpdateResult].DefaultValue = defValuestring;
            }
        }
    }
}

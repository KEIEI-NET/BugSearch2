//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付けテーブルスキーマ定義クラス
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 商品バーコード関連付けテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けテーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    public class GoodsBarCodeRevnTbl
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_GoodsBarCodeRevn = "Tbl_GoodsBarCodeRevn";

        /// <summary> 行番号 </summary>
        public const string ct_Col_RowNo = "RowNo";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> 商品バーコード種別 </summary>
        public const string ct_Col_GoodsBarCodeKind = "GoodsBarCodeKind";

        /// <summary> バーコード </summary>
        public const string ct_Col_GoodsBarCode = "GoodsBarCode";

        /// <summary> 削除区分 </summary>
        public const string ct_Col_DeleteDiv = "DeleteDiv";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 商品バーコード関連付けテーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けテーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnTbl()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ テーブルスキーマ設定
        /// <summary>
        /// DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
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
                // スキーマ設定
                dt = new DataTable(ct_Tbl_GoodsBarCodeRevn);

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;

                # region <Column追加>

                // 行番号
                dt.Columns.Add(ct_Col_RowNo, typeof(Int32));
                dt.Columns[ct_Col_RowNo].DefaultValue = defaultValueOfInt32;
                dt.Columns[ct_Col_RowNo].Caption = "No.";

                // 品番
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsNo].Caption = "品番";

                // メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsMakerCd].Caption = "メーカーコード";

                // メーカー名称
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_MakerName].Caption = "メーカー名称";

                // 品名
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsName].Caption = "品名";

                // バーコード種別
                dt.Columns.Add(ct_Col_GoodsBarCodeKind, typeof(Int32));
                dt.Columns[ct_Col_GoodsBarCodeKind].DefaultValue = defaultValueOfInt32;
                dt.Columns[ct_Col_GoodsBarCodeKind].Caption = "バーコード種別";

                // バーコード
                dt.Columns.Add(ct_Col_GoodsBarCode, typeof(string));
                dt.Columns[ct_Col_GoodsBarCode].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsBarCode].Caption = "バーコード";

                // 削除区分
                dt.Columns.Add(ct_Col_DeleteDiv, typeof(string));
                dt.Columns[ct_Col_DeleteDiv].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_DeleteDiv].Caption = "削除区分";
                # endregion
            }
        }
        #endregion
        #endregion
    }
}

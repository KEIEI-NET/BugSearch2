//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表　テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日  2012/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入先総括マスタ一覧表　テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先総括マスタ一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    public class PMKAK09015EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SumSuppStReportData = "Tbl_SumSuppStReportData";

        /// <summary> 総括拠点コード </summary>
        public const string ct_Col_SumSectionCd = "SumSectionCd";
        /// <summary> 総括拠点名 </summary>
        public const string ct_Col_SumSectionGuideSnm = "SumSectionGuideSnm";
        /// <summary> 総括仕入先コード </summary>
        public const string ct_Col_SumSupplierCd = "SumSupplierCd";
        /// <summary> 総括仕入先名１ </summary>
        public const string ct_Col_SumSupplierNm1 = "SumSupplierNm1";
        /// <summary> 総括仕入先名２ </summary>
        public const string ct_Col_SumSupplierNm2 = "SumSupplierNm2";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCd = "SectionCd";
        /// <summary> 拠点名 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名１ </summary>
        public const string ct_Col_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名２ </summary>
        public const string ct_Col_SupplierNm2 = "SupplierNm2";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 仕入総括マスタ一覧表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入総括マスタ一覧テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public PMKAK09015EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 仕入先総括マスタ一覧表DataSetテーブルスキーマ設定
        /// <summary>
        /// 仕入先総括マスタ一覧表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 仕入先総括マスタ一覧表データセットのスキーマを設定する。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_SumSuppStReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_SumSuppStReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_SumSuppStReportData);

                DataTable dt = ds.Tables[ct_Tbl_SumSuppStReportData];


                // 総括拠点コード
                dt.Columns.Add(ct_Col_SumSectionCd, typeof(string));
                dt.Columns[ct_Col_SumSectionCd].DefaultValue = string.Empty;

                // 総括拠点名
                dt.Columns.Add(ct_Col_SumSectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SumSectionGuideSnm].DefaultValue = string.Empty;

                // 総括仕入先コード
                dt.Columns.Add(ct_Col_SumSupplierCd, typeof(int));
                dt.Columns[ct_Col_SumSupplierCd].DefaultValue = 0;

                // 総括仕入先名１
                dt.Columns.Add(ct_Col_SumSupplierNm1, typeof(string));
                dt.Columns[ct_Col_SumSupplierNm1].DefaultValue = string.Empty;

                // 総括仕入先名２
                dt.Columns.Add(ct_Col_SumSupplierNm2, typeof(string));
                dt.Columns[ct_Col_SumSupplierNm2].DefaultValue = string.Empty;

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCd, typeof(string));
                dt.Columns[ct_Col_SectionCd].DefaultValue = string.Empty;

                // 拠点名
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // 仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(int));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                // 仕入先名１
                dt.Columns.Add(ct_Col_SupplierNm1, typeof(string));
                dt.Columns[ct_Col_SupplierNm1].DefaultValue = string.Empty;

                // 仕入先名２
                dt.Columns.Add(ct_Col_SupplierNm2, typeof(string));
                dt.Columns[ct_Col_SupplierNm2].DefaultValue = string.Empty;

            }
        }
        #endregion ◆ 仕入総括マスタ一覧DataSetテーブルスキーマ設定
        #endregion ■ Static Public Method
    }
}
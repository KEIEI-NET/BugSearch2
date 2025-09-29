using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 優良設定マスタ印刷テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 優良設定マスタ印刷テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.11.13</br>
	/// </remarks>
	public class PMKEN02015EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_PrmSetting = "Tbl_PrmSetting";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド略称 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        /// <summary> 商品中分類コード </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BLコード </summary>
        public const string ct_Col_TbsPartsCode = "TbsPartsCode";
        /// <summary> BL商品コード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> 部品メーカーコード </summary>
        public const string ct_Col_PartsMakerCd = "PartsMakerCd";
        /// <summary> メーカー略称 </summary>
        public const string ct_Col_MakerShortName = "MakerShortName";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 優良設定詳細名称１ </summary>
        public const string ct_Col_PrmSetDtlName1 = "PrmSetDtlName1";
        /// <summary> 優良設定詳細名称２ </summary>
        public const string ct_Col_PrmSetDtlName2 = "PrmSetDtlName2";
        /// <summary> メーカー表示順位 </summary>
        public const string ct_Col_MakerDispOrder = "MakerDispOrder";
        /// <summary> 優良表示区分 </summary>
        public const string ct_Col_PrimeDisplayCode = "PrimeDisplayCode";

        /// <summary> ソート用拠点コード </summary>
        public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用商品中分類コード </summary>
        public const string ct_Col_Sort_GoodsMGroup = "Sort_GoodsMGroup";
        /// <summary> ソート用BLコード </summary>
        public const string ct_Col_Sort_TbsPartsCode = "Sort_TbsPartsCode";
        /// <summary> ソート用部品メーカーコード </summary>
        public const string ct_Col_Sort_PartsMakerCd = "Sort_PartsMakerCd";
        /// <summary> ソート用メーカー表示順位 </summary>
        public const string ct_Col_Sort_MakerDispOrder = "Sort_MakerDispOrder";

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 優良設定マスタ印刷テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 優良設定マスタ印刷テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.13</br>
		/// </remarks>
		public PMKEN02015EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ DataSetテーブルスキーマ設定
		/// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.13</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
                // スキーマ設定
                dt = new DataTable(ct_Tbl_PrmSetting);

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));                     // 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));                 // 拠点ガイド略称
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));                      // 商品中分類コード
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));                 // 商品中分類名称
                dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = "";

                dt.Columns.Add(ct_Col_TbsPartsCode, typeof(Int32));                     // BLコード
                dt.Columns[ct_Col_TbsPartsCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));                 // BL商品コード名称（半角）
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = "";

                dt.Columns.Add(ct_Col_PartsMakerCd, typeof(Int32));                     // 部品メーカーコード
                dt.Columns[ct_Col_PartsMakerCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));                  // メーカー略称
                dt.Columns[ct_Col_MakerShortName].DefaultValue = "";

                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));                       // 仕入先コード
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));                     // 仕入先略称
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_PrmSetDtlName1, typeof(string));                  // 優良設定詳細名称１
                dt.Columns[ct_Col_PrmSetDtlName1].DefaultValue = "";

                dt.Columns.Add(ct_Col_PrmSetDtlName2, typeof(string));                  // 優良設定詳細名称２
                dt.Columns[ct_Col_PrmSetDtlName2].DefaultValue = "";

                dt.Columns.Add(ct_Col_MakerDispOrder, typeof(Int32));                   // メーカー表示順位
                dt.Columns[ct_Col_MakerDispOrder].DefaultValue = 0;

                dt.Columns.Add(ct_Col_PrimeDisplayCode, typeof(Int32));                 // 優良表示区分
                dt.Columns[ct_Col_PrimeDisplayCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));                // ソート用拠点コード
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_GoodsMGroup, typeof(Int32));                 // ソート用商品中分類コード
                dt.Columns[ct_Col_Sort_GoodsMGroup].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_TbsPartsCode, typeof(Int32));                // ソート用BLコード
                dt.Columns[ct_Col_Sort_TbsPartsCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_PartsMakerCd, typeof(Int32));                // ソート用部品メーカーコード
                dt.Columns[ct_Col_Sort_PartsMakerCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_MakerDispOrder, typeof(Int32));              // ソート用メーカー表示順位
                dt.Columns[ct_Col_Sort_MakerDispOrder].DefaultValue = 0;

            }
		}
		#endregion
		#endregion
	}
}

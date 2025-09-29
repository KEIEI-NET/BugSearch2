using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 掛率マスタ印刷テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 掛率マスタ印刷テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.15</br>
    /// ---------------------------------------------------------------
    /// <br>UpdateNote   : 2008/10/29 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>UpdateNote   : 2011/07/22 李占川 価格の追加(NSユーザー改良要望一覧の連番898の対応)</br>
	/// </remarks>
	public class PMKHN02019EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_Rate = "Tbl_Rate";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド略称 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        /// <summary> 掛率設定区分 </summary>
        public const string ct_Col_RateSettingDivide = "RateSettingDivide";
        /// <summary> 論理削除区分 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 得意先掛率グループコード </summary>
        public const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー略称 </summary>
        public const string ct_Col_MakerShortName = "MakerShortName";
        /// <summary> 商品掛率ランク </summary>
        public const string ct_Col_GoodsRateRank = "GoodsRateRank";
        /// <summary> 商品掛率グループコード </summary>
        public const string ct_Col_GoodsRateGrpCode = "GoodsRateGrpCode";
        /// <summary> BLグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BLグループコードカナ名称 </summary>
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称カナ </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        /// <summary> 上限 </summary>
        public const string ct_Col_LotCount = "LotCount";
        /// <summary> 売価率 </summary>
        public const string ct_Col_SalRateVal = "SalRateVal";
        /// <summary> 売価額 </summary>
        public const string ct_Col_SalPriceFl = "SalPriceFl";
        /// <summary> 原価UP率 </summary>
        public const string ct_Col_SalUpRate = "SalUpRate";
        /// <summary> 粗利確保率 </summary>
        public const string ct_Col_GrsProfitSecureRate = "GrsProfitSecureRate";
        /// <summary> 仕入率 </summary>
        public const string ct_Col_CstRateVal = "CstRateVal";
        /// <summary> 仕入原価 </summary>
        public const string ct_Col_CstPriceFl = "CstPriceFl";
        /// <summary> ユーザー価格 </summary>
        public const string ct_Col_PrcPriceFl = "PrcPriceFl";
        // --- ADD 2011/07/22 ---------->>>>>
        /// <summary> 価格 </summary>
        public const string ct_Col_Price = "Price";
        // --- ADD 2011/07/22  ----------<<<<<
        /// <summary> 価格UP率 </summary>
        public const string ct_Col_PrcUpRate = "PrcUpRate";
        /// <summary> 単価端数処理単位 </summary>
        public const string ct_Col_UnPrcFracProcUnit = "UnPrcFracProcUnit";
        /// <summary> 単価端数処理区分 </summary>
        public const string ct_Col_UnPrcFracProcDiv = "UnPrcFracProcDiv";
        /// <summary> 単価種類 </summary>
        public const string ct_Col_UnitPriceKind = "UnitPriceKind";

        /// <summary> ソート用拠点コード </summary>
        public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用論理削除区分 </summary>
        public const string ct_Col_Sort_LogicalDeleteCode = "Sort_LogicalDeleteCode";
        /// <summary> ソート用掛率設定区分 </summary>
        public const string ct_Col_Sort_ct_Col_RateSettingDivide = "Sort_RateSettingDivide";
        /// <summary> ソート用得意先コード </summary>
        public const string ct_Col_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> ソート用得意先掛率グループコード </summary>
        public const string ct_Col_Sort_CustRateGrpCode = "Sort_CustRateGrpCode";
        /// <summary> ソート用仕入先コード </summary>
        public const string ct_Col_Sort_SupplierCd = "Sort_SupplierCd";
        /// <summary> ソート用商品メーカーコード </summary>
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        /// <summary> ソート用商品掛率ランク </summary>
        public const string ct_Col_Sort_GoodsRateRank = "Sort_GoodsRateRank";
        /// <summary> ソート用商品掛率グループコード </summary>
        public const string ct_Col_Sort_GoodsRateGrpCode = "Sort_GoodsRateGrpCode";
        /// <summary> ソート用BLグループコード </summary>
        public const string ct_Col_Sort_BLGroupCode = "Sort_BLGroupCode";
        /// <summary> ソート用BL商品コード </summary>
        public const string ct_Col_Sort_BLGoodsCode = "Sort_BLGoodsCode";
        /// <summary> ソート用上限 </summary>
        public const string ct_Col_Sort_LotCount = "Sort_LotCount";


		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 掛率マスタ印刷テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 掛率マスタ印刷テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.15</br>
		/// </remarks>
		public PMKHN02019EA()
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
		/// <br>Date       : 2008.10.15</br>
        /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
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
                dt = new DataTable(ct_Tbl_Rate);

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));                     // 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));                 // 拠点ガイド略称
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_RateSettingDivide, typeof(string));               // 掛率設定区分
                dt.Columns[ct_Col_RateSettingDivide].DefaultValue = "";

                dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));                // 論理削除区分
                dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));                     // 得意先コード
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));                     // 得意先略称
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_CustRateGrpCode, typeof(Int32));                  // 得意先掛率グループコード
                dt.Columns[ct_Col_CustRateGrpCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));                       // 仕入先コード
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));                     // 仕入先略称
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));                     // 商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));                  // メーカー略称
                dt.Columns[ct_Col_MakerShortName].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsRateRank, typeof(string));                   // 商品掛率ランク
                dt.Columns[ct_Col_GoodsRateRank].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsRateGrpCode, typeof(Int32));                 // 商品掛率グループコード
                dt.Columns[ct_Col_GoodsRateGrpCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));                      // BLグループコード
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string));                 // BLグループコードカナ名称
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = "";

                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));                      // BL商品コード
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));                 // BL商品コード名称（半角）
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));                         // 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));                   // 商品名称カナ
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = "";

                dt.Columns.Add(ct_Col_LotCount, typeof(Double));                        // 上限
                dt.Columns[ct_Col_LotCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalRateVal, typeof(Double));                      // 売価率
                dt.Columns[ct_Col_SalRateVal].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalPriceFl, typeof(Double));                      // 売価額
                dt.Columns[ct_Col_SalPriceFl].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalUpRate, typeof(Double));                       // 原価UP率
                dt.Columns[ct_Col_SalUpRate].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GrsProfitSecureRate, typeof(Double));             // 粗利確保率
                dt.Columns[ct_Col_GrsProfitSecureRate].DefaultValue = 0;

                dt.Columns.Add(ct_Col_CstRateVal, typeof(Double));                      // 仕入率
                dt.Columns[ct_Col_CstRateVal].DefaultValue = 0;

                dt.Columns.Add(ct_Col_CstPriceFl, typeof(Double));                      // 仕入原価
                dt.Columns[ct_Col_CstPriceFl].DefaultValue = 0;

                dt.Columns.Add(ct_Col_PrcPriceFl, typeof(Double));                      // ユーザー価格
                dt.Columns[ct_Col_PrcPriceFl].DefaultValue = 0;

                // --- ADD 2011/07/22 ---------->>>>>
                dt.Columns.Add(ct_Col_Price, typeof(Double));                           // 価格
                dt.Columns[ct_Col_Price].DefaultValue = 0;
                // --- ADD 2011/07/22  ----------<<<<<

                dt.Columns.Add(ct_Col_PrcUpRate, typeof(Double));                       // 価格UP率
                dt.Columns[ct_Col_PrcUpRate].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UnPrcFracProcUnit, typeof(Double));               // 単価端数処理単位
                dt.Columns[ct_Col_UnPrcFracProcUnit].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UnPrcFracProcDiv, typeof(Int32));                 // 単価端数処理区分
                dt.Columns[ct_Col_UnPrcFracProcDiv].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UnitPriceKind, typeof(string));                   // 単価種類
                dt.Columns[ct_Col_UnitPriceKind].DefaultValue = "";


                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));                // ソート用拠点コード
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_LogicalDeleteCode, typeof(string));          // ソート用論理削除区分
                //dt.Columns[ct_Col_Sort_LogicalDeleteCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_LogicalDeleteCode, typeof(Int32));          // ソート用論理削除区分
                dt.Columns[ct_Col_Sort_LogicalDeleteCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                dt.Columns.Add(ct_Col_Sort_ct_Col_RateSettingDivide, typeof(string));   // ソート用掛率設定区分
                dt.Columns[ct_Col_Sort_ct_Col_RateSettingDivide].DefaultValue = "";

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(string));               // ソート用得意先コード
                //dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(Int32));               // ソート用得意先コード
                dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_CustRateGrpCode, typeof(string));            // ソート用得意先掛率グループコード
                //dt.Columns[ct_Col_Sort_CustRateGrpCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_CustRateGrpCode, typeof(Int32));            // ソート用得意先掛率グループコード
                dt.Columns[ct_Col_Sort_CustRateGrpCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_SupplierCd, typeof(string));                 // ソート用仕入先コード
                //dt.Columns[ct_Col_Sort_SupplierCd].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_SupplierCd, typeof(Int32));                 // ソート用仕入先コード
                dt.Columns[ct_Col_Sort_SupplierCd].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(string));               // ソート用商品メーカーコード
                //dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));               // ソート用商品メーカーコード
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                dt.Columns.Add(ct_Col_Sort_GoodsRateRank, typeof(string));              // ソート用商品掛率ランク
                dt.Columns[ct_Col_Sort_GoodsRateRank].DefaultValue = "";

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_GoodsRateGrpCode, typeof(string));           // ソート用商品掛率グループコード
                //dt.Columns[ct_Col_Sort_GoodsRateGrpCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_GoodsRateGrpCode, typeof(Int32));           // ソート用商品掛率グループコード
                dt.Columns[ct_Col_Sort_GoodsRateGrpCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_BLGroupCode, typeof(string));                // ソート用BLグループコード
                //dt.Columns[ct_Col_Sort_BLGroupCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_BLGroupCode, typeof(Int32));                // ソート用BLグループコード
                dt.Columns[ct_Col_Sort_BLGroupCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // --- UPD 2010/06/08 ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_BLGoodsCode, typeof(string));                // ソート用BL商品コード
                //dt.Columns[ct_Col_Sort_BLGoodsCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_BLGoodsCode, typeof(Int32));                // ソート用BL商品コード
                dt.Columns[ct_Col_Sort_BLGoodsCode].DefaultValue = 0;
                // --- UPD 2010/06/08 ----------<<<<<

                // DEL 2008/10/29 不具合対応[7164] ---------->>>>>
                //dt.Columns.Add(ct_Col_Sort_LotCount, typeof(string));                   // ソート用上限
                //dt.Columns[ct_Col_Sort_LotCount].DefaultValue = "";
                // DEL 2008/10/29 不具合対応[7164] ----------<<<<<

                // ADD 2008/10/29 不具合対応[7164] ---------->>>>>
                dt.Columns.Add(ct_Col_Sort_LotCount, typeof(Double));                   // ソート用上限
                dt.Columns[ct_Col_Sort_LotCount].DefaultValue = 0;
                // ADD 2008/10/29 不具合対応[7164] ----------<<<<<


            }
		}
		#endregion
		#endregion
	}
}

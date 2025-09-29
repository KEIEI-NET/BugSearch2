//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 前年対比表
// プログラム概要   : 前年対比表 抽出結果データテーブルスキーマクラス
//----------------------------------------------------------------------------//
// 履歴
// ---------------------------------------------------------------------------//
// 管理番号  11170129-00 改修担当 : cheq
// 作 成 日  2015/08/17  修正内容 : RedMine#47029 前年対比表比率算出不正の対応　
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 前年対比表抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 前年対比表の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.11.25</br>
    /// </remarks>
	public class DCTOK02094EA
	{
		#region Public Members
        /// <summary>前年対比表データテーブル名</summary>
		public const string CT_PrevYearCpDataTable = "PrevYearCpDataTable";
        /// <summary>前年対比表バッファデータテーブル名</summary>
		public const string CT_PrevYearCpBuffDataTable = "PrevYearCpBuffDataTable";

		#region 前年対比表カラム情報

		/// <summary>計上拠点コード</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_AddUpSecCode = "AddUpSecCode";

		/// <summary>拠点ガイド名称</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_SectionGuidNm = "SectionGuidNm";
		
		/// <summary>従業員コード</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_EmployeeCode = "EmployeeCode";

		/// <summary>従業員名称</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_EmployeeName = "EmployeeName";

		/// <summary>得意先コード</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_CustomerCode = "CustomerCode";

		/// <summary>得意先略称</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_CustomerSnm = "CustomerSnm";

		/// <summary>業種コード</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_BusinessTypeCode = "BusinessTypeCode";
		
		/// <summary>業種名称</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_BusinessTypeName = "BusinessTypeName";
		
		/// <summary>販売エリアコード</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
		public const string CT_PrevYear_SalesAreaCode = "SalesAreaCode";

		/// <summary>販売エリア名称</summary>
		/// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_SalesAreaName = "SalesAreaName";

        /// <summary>BLコード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_BLGoodsCode = "BLGoodsCode";

        /// <summary>BL名称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_BLGoodsHalfName = "BLGoodsHalfName";

        /// <summary>商品大分類コード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_GoodsLGroup = "GoodsLGroup";

        /// <summary>商品大分類名称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_GoodsLGroupName = "GoodsLGroupName";

        /// <summary>商品中分類コード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_GoodsMGroup = "GoodsMGroup";

        /// <summary>商品中分類名称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_GoodsMGroupName = "GoodsMGroupName";
        
        /// <summary>グループコード</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_BLGroupCode = "BLGroupCode";

        /// <summary>グループ名称</summary>
        /// <remarks>それぞれの月次集計データから取得</remarks>
        public const string CT_PrevYear_BLGroupKanaName = "BLGroupKanaName";

		/// <summary>売上額(当期1ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales1 = "ThisTermSales1";

		/// <summary>売上額(前期1ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales1 = "FirstTermSales1";

		/// <summary>売上比(1ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio1 = "SalesRatio1";

		/// <summary>粗利額(当期1ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross1 = "ThisTermGross1";

		/// <summary>粗利額(前期1ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross1 = "FirstTermGross1";

		/// <summary>粗利比(1ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio1 = "GrossRatio1";

		/// <summary>売上額(当期2ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales2 = "ThisTermSales2";

		/// <summary>売上額(前期2ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales2 = "FirstTermSales2";

		/// <summary>売上比(2ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio2 = "SalesRatio2";

		/// <summary>粗利額(当期2ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross2 = "ThisTermGross2";

		/// <summary>粗利額(前期2ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross2 = "FirstTermGross2";

		/// <summary>粗利比(2ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio2 = "GrossRatio2";

		/// <summary>売上額(当期3ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales3 = "ThisTermSales3";

		/// <summary>売上額(前期3ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales3 = "FirstTermSales3";

		/// <summary>売上比(3ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio3 = "SalesRatio3";

		/// <summary>粗利額(当期3ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross3 = "ThisTermGross3";

		/// <summary>粗利額(前期3ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross3 = "FirstTermGross3";

		/// <summary>粗利比(3ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio3 = "GrossRatio3";

		/// <summary>売上額(当期4ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales4 = "ThisTermSales4";

		/// <summary>売上額(前期4ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales4 = "FirstTermSales4";

		/// <summary>売上比(4ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio4 = "SalesRatio4";

		/// <summary>粗利額(当期4ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross4 = "ThisTermGross4";

		/// <summary>粗利額(前期4ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross4 = "FirstTermGross4";

		/// <summary>粗利比(4ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio4 = "GrossRatio4";

		/// <summary>売上額(当期5ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales5 = "ThisTermSales5";

		/// <summary>売上額(前期5ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales5 = "FirstTermSales5";

		/// <summary>売上比(5ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio5 = "SalesRatio5";

		/// <summary>粗利額(当期5ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross5 = "ThisTermGross5";

		/// <summary>粗利額(前期5ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross5 = "FirstTermGross5";

		/// <summary>粗利比(5ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio5 = "GrossRatio5";

		/// <summary>売上額(当期6ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales6 = "ThisTermSales6";

		/// <summary>売上額(前期6ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales6 = "FirstTermSales6";

		/// <summary>売上比(6ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio6 = "SalesRatio6";

		/// <summary>粗利額(当期6ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross6 = "ThisTermGross6";

		/// <summary>粗利額(前期6ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross6 = "FirstTermGross6";

		/// <summary>粗利比(6ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio6 = "GrossRatio6";

		/// <summary>売上額(当期7ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales7 = "ThisTermSales7";

		/// <summary>売上額(前期7ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales7 = "FirstTermSales7";

		/// <summary>売上比(7ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio7 = "SalesRatio7";

		/// <summary>粗利額(当期7ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross7 = "ThisTermGross7";

		/// <summary>粗利額(前期7ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>		
		public const string CT_PrevYear_FirstTermGross7 = "FirstTermGross7";

		/// <summary>粗利比(7ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio7 = "GrossRatio7";
		
		/// <summary>売上額(当期8ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales8 = "ThisTermSales8";

		/// <summary>売上額(前期8ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales8 = "FirstTermSales8";
		
		/// <summary>売上比(8ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio8 = "SalesRatio8";

		/// <summary>粗利額(当期8ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross8 = "ThisTermGross8";
		
		/// <summary>粗利額(前期8ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross8 = "FirstTermGross8";

		/// <summary>粗利比(8ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio8 = "GrossRatio8";
		
		/// <summary>売上額(当期9ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales9 = "ThisTermSales9";

		/// <summary>売上額(前期9ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales9 = "FirstTermSales9";
		
		/// <summary>売上比(9ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio9 = "SalesRatio9";

		/// <summary>粗利額(当期9ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross9 = "ThisTermGross9";
		
		/// <summary>粗利額(前期9ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross9 = "FirstTermGross9";

		/// <summary>粗利比(9ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio9 = "GrossRatio9";
		
		/// <summary>売上額(当期10ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales10 = "ThisTermSales10";

		/// <summary>売上額(前期10ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales10 = "FirstTermSales10";
		
		/// <summary>売上比(10ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio10 = "SalesRatio10";

		/// <summary>粗利額(当期10ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross10 = "ThisTermGross10";

		/// <summary>粗利額(前期10ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross10 = "FirstTermGross10";

		/// <summary>粗利比(10ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio10 = "GrossRatio10";

		/// <summary>売上額(当期11ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales11 = "ThisTermSales11";

		/// <summary>売上額(前期11ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales11 = "FirstTermSales11";

		/// <summary>売上比(11ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio11 = "SalesRatio11";

		/// <summary>粗利額(当期11ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross11 = "ThisTermGross11";

		/// <summary>粗利額(前期11ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string  CT_PrevYear_FirstTermGross11 = "FirstTermGross11";

		/// <summary>粗利比(11ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio11 = "GrossRatio11";

		/// <summary>売上額(当期12ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermSales12 = "ThisTermSales12";

		/// <summary>売上額(前期12ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermSales12 = "FirstTermSales12";

		/// <summary>売上比(12ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_SalesRatio12 = "SalesRatio12";

		/// <summary>粗利額(当期12ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_ThisTermGross12 = "ThisTermGross12";

		/// <summary>粗利額(前期12ヶ月目)</summary>
		/// <remarks>金額単位に関わらず、円単位でセット</remarks>
		public const string CT_PrevYear_FirstTermGross12 = "FirstTermGross12";

		/// <summary>粗利比(12ヶ月目)</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_GrossRatio12 = "GrossRatio12";

		#region 以下自分で計算する項目
		
		/// <summary>当期合計売上額</summary>
		/// <remarks>自分で計算</remarks>
		public const string CT_PrevYear_thisTermTotalSales = "ThisTermTotalSales";

		/// <summary>前期合計売上額</summary>
		/// <remarks>自分で計算</remarks>
		public const string CT_PrevYear_firstTermTotalSales = "FirstTermTotalSales";

		/// <summary>Detial:年計売上比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalSalesRatio = "TotalSalesRatio";

		/// <summary>当期合計粗利額</summary>
		/// <remarks>自分で計算</remarks>
		public const string CT_PrevYear_thisTermTotalGross = "ThisTermTotalGross";

		/// <summary>前期合計粗利額</summary>
		/// <remarks>自分で計算</remarks>
		public const string CT_PrevYear_firstTermTotalGross = "FirstTermTotalGross";

		/// <summary>Detial:年計粗利比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalGrossRatio = "TotalGrossRatio";

		/// <summary>部門計:年計売上比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalSlRaiotSubSec = "TotalSlRaiotSubSec";

		/// <summary>部門計:年計粗利比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalGrsRatioSubSec = "TotalGrsRatioSubSec";

		/// <summary>拠点計:年計売上比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalSlRatioSec = "TotalSlRatioSec";

		/// <summary>拠点計:年計粗利比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalGrsRatioSec = "TotalGrsRatioSec";

		/// <summary>総合計:年計売上比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalSlRatioTtl = "otalSlRatioTtl";

		/// <summary>総合計:年計粗利比</summary>
		/// <remarks>999.99形式で小数点第三位を四捨五入</remarks>
		public const string CT_PrevYear_totalGrsRatioTtl = "TotalGrsRatioTtl";

		#endregion

        /// <summary>
        /// 
        /// </summary>
		public const string COL_KEYBREAK_AR	= "KEYBREAK_AR";				// キーブレイク

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// 前年対比表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 前年対比表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
		public DCTOK02094EA()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ( (ds.Tables.Contains(CT_PrevYearCpDataTable)) )
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_PrevYearCpDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 0);

			}
			
			// 売上チェックリストバッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_PrevYearCpBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_PrevYearCpBuffDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// 前年対比表抽出結果作成処理
		/// </summary>
		private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// スキーマ設定
				ds.Tables.Add(CT_PrevYearCpDataTable);
				dt = ds.Tables[CT_PrevYearCpDataTable];
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(CT_PrevYearCpBuffDataTable);
				dt = ds.Tables[CT_PrevYearCpBuffDataTable];
			}

				// 計上拠点コード
                dt.Columns.Add(CT_PrevYear_AddUpSecCode, typeof(string));
                dt.Columns[CT_PrevYear_AddUpSecCode].DefaultValue = "";
				// 拠点ガイド名称
                dt.Columns.Add(CT_PrevYear_SectionGuidNm, typeof(string));
                dt.Columns[CT_PrevYear_SectionGuidNm].DefaultValue = "";				
				// 従業員コード
                dt.Columns.Add(CT_PrevYear_EmployeeCode, typeof(string));
                dt.Columns[CT_PrevYear_EmployeeCode].DefaultValue = "";
				// 従業員名称
                dt.Columns.Add(CT_PrevYear_EmployeeName, typeof(string));
                dt.Columns[CT_PrevYear_EmployeeName].DefaultValue = "";
				// 得意先コード
                dt.Columns.Add(CT_PrevYear_CustomerCode, typeof(Int32));
                dt.Columns[CT_PrevYear_CustomerCode].DefaultValue = 0;
				// 得意先略称
                dt.Columns.Add(CT_PrevYear_CustomerSnm, typeof(string));
                dt.Columns[CT_PrevYear_CustomerSnm].DefaultValue = "";
				// 業種コード
                dt.Columns.Add(CT_PrevYear_BusinessTypeCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BusinessTypeCode].DefaultValue = 0;
				// 業種名称
                dt.Columns.Add(CT_PrevYear_BusinessTypeName, typeof(string));
                dt.Columns[CT_PrevYear_BusinessTypeName].DefaultValue = "";
				// 販売エリアコード
                dt.Columns.Add(CT_PrevYear_SalesAreaCode, typeof(Int32));
                dt.Columns[CT_PrevYear_SalesAreaCode].DefaultValue = 0;
				// 販売エリア名称
                dt.Columns.Add(CT_PrevYear_SalesAreaName, typeof(string));
                dt.Columns[CT_PrevYear_SalesAreaName].DefaultValue = "";
                // BLコード
                dt.Columns.Add(CT_PrevYear_BLGoodsCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BLGoodsCode].DefaultValue = 0;
                // BL名称
                dt.Columns.Add(CT_PrevYear_BLGoodsHalfName, typeof(string));
                dt.Columns[CT_PrevYear_BLGoodsHalfName].DefaultValue = "";
                // 商品大分類コード
                dt.Columns.Add(CT_PrevYear_GoodsLGroup, typeof(Int32));
                dt.Columns[CT_PrevYear_GoodsLGroup].DefaultValue = 0;
                // 商品大分類名称
                dt.Columns.Add(CT_PrevYear_GoodsLGroupName, typeof(string));
                dt.Columns[CT_PrevYear_GoodsLGroupName].DefaultValue = "";
                // 商品中分類コード
                dt.Columns.Add(CT_PrevYear_GoodsMGroup, typeof(Int32));
                dt.Columns[CT_PrevYear_GoodsMGroup].DefaultValue = 0;
                // 商品中分類名称
                dt.Columns.Add(CT_PrevYear_GoodsMGroupName, typeof(string));
                dt.Columns[CT_PrevYear_GoodsMGroupName].DefaultValue = "";
                // グループコード
                dt.Columns.Add(CT_PrevYear_BLGroupCode, typeof(Int32));
                dt.Columns[CT_PrevYear_BLGroupCode].DefaultValue = 0;
                // グループ名称
                dt.Columns.Add(CT_PrevYear_BLGroupKanaName, typeof(string));
                dt.Columns[CT_PrevYear_BLGroupKanaName].DefaultValue = "";
				// 売上額(当期1ヶ月目)
                dt.Columns.Add(CT_PrevYear_ThisTermSales1, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales1].DefaultValue = 0;
				// 売上額(前期1ヶ月目)
                dt.Columns.Add(CT_PrevYear_FirstTermSales1, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales1].DefaultValue = 0;
				// 売上比(1ヶ月目)
                dt.Columns.Add(CT_PrevYear_SalesRatio1, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio1].DefaultValue = 0;
				// 粗利額(当期1ヶ月目)
                dt.Columns.Add(CT_PrevYear_ThisTermGross1, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross1].DefaultValue = 0;
				// 粗利額(前期1ヶ月目)
                dt.Columns.Add(CT_PrevYear_FirstTermGross1, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross1].DefaultValue = 0;
				// 粗利比(1ヶ月目)
                dt.Columns.Add(CT_PrevYear_GrossRatio1, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio1].DefaultValue = 0;
				// 売上額(当期2ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales2, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales2].DefaultValue = 0;
				// 売上額(前期2ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales2, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales2].DefaultValue = 0;
				// 売上比(2ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio2, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio2].DefaultValue = 0;
				// 粗利額(当期2ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross2, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross2].DefaultValue = 0;
				// 粗利額(前期2ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross2, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross2].DefaultValue = 0;
				// 粗利比(2ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio2, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio2].DefaultValue = 0;
				// 売上額(当期3ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales3, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales3].DefaultValue = 0;
				// 売上額(前期3ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales3, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales3].DefaultValue = 0;
				// 売上比(3ヶ月目)
                // dt.Columns.Add(CT_PrevYear_SalesRatio3, typeof(Int64)); // DEL cheq 2015/08/17 for RedMine#47029 比率算出不正の対応　
                dt.Columns.Add(CT_PrevYear_SalesRatio3, typeof(Double)); // ADD  cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
                dt.Columns[CT_PrevYear_SalesRatio3].DefaultValue = 0;
				// 粗利額(当期3ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross3, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross3].DefaultValue = 0;
				// 粗利額(前期3ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross3, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross3].DefaultValue = 0;
				// 粗利比(3ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio3, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio3].DefaultValue = 0;
				// 売上額(当期4ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales4, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales4].DefaultValue = 0;
				// 売上額(前期4ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales4, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales4].DefaultValue = 0;
				// 売上比(4ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio4, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio4].DefaultValue = 0;
				// 粗利額(当期4ヶ月目)
                dt.Columns.Add(CT_PrevYear_ThisTermGross4, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross4].DefaultValue = 0;
				// 粗利額(前期4ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross4, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross4].DefaultValue = 0;
				// 粗利比(4ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio4, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio4].DefaultValue = 0;
				// 売上額(当期5ヶ月目)
                dt.Columns.Add(CT_PrevYear_ThisTermSales5, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales5].DefaultValue = 0;
				// 売上額(前期5ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales5, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales5].DefaultValue = 0;
				// 売上比(5ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio5, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio5].DefaultValue = 0;
				// 粗利額(当期5ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross5, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross5].DefaultValue = 0;
				// 粗利額(前期5ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross5, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross5].DefaultValue = 0;
				// 粗利比(5ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio5, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio5].DefaultValue = 0;
				// 売上額(当期6ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales6, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales6].DefaultValue = 0;
				// 売上額(前期6ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales6, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales6].DefaultValue = 0;
				// 売上比(6ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio6, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio6].DefaultValue = 0;
				// 粗利額(当期6ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross6, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermGross6].DefaultValue = 0;
				// 粗利額(前期6ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross6, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermGross6].DefaultValue = 0;
				// 粗利比(6ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio6, typeof(Double));
                dt.Columns[CT_PrevYear_GrossRatio6].DefaultValue = 0;
				// 売上額(当期7ヶ月目)
                dt.Columns.Add(CT_PrevYear_ThisTermSales7, typeof(Int64));
                dt.Columns[CT_PrevYear_ThisTermSales7].DefaultValue = 0;
				// 売上額(前期7ヶ月目)
                dt.Columns.Add(CT_PrevYear_FirstTermSales7, typeof(Int64));
                dt.Columns[CT_PrevYear_FirstTermSales7].DefaultValue = 0;
				// 売上比(7ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio7, typeof(Double));
                dt.Columns[CT_PrevYear_SalesRatio7].DefaultValue = 0;
				// 粗利額(当期7ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross7, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross7].DefaultValue = 0;
				// 粗利額(前期7ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross7, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross7].DefaultValue = 0;
				// 粗利比(7ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio7, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio7].DefaultValue = 0;
				// 売上額(当期8ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales8, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales8].DefaultValue = 0;
				// 売上額(前期8ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales8, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales8].DefaultValue = 0;
				// 売上比(8ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio8, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio8].DefaultValue = 0;
				// 粗利額(当期8ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross8, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross8].DefaultValue = 0;
				// 粗利額(前期8ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross8, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross8].DefaultValue = 0;
				// 粗利比(8ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio8, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio8].DefaultValue = 0;
				// 売上額(当期9ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales9, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales9].DefaultValue = 0;
				// 売上額(前期9ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales9, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales9].DefaultValue = 0;
				// 売上比(9ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio9, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio9].DefaultValue = 0;
				// 粗利額(当期9ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross9, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross9].DefaultValue = 0;
				// 粗利額(前期9ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross9, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross9].DefaultValue = 0;
				// 粗利比(9ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio9, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio9].DefaultValue = 0;
				// 売上額(当期10ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales10, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales10].DefaultValue = 0;
				// 売上額(前期10ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales10, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales10].DefaultValue = 0;
				// 売上比(10ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio10, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio10].DefaultValue = 0;
				// 粗利額(当期10ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross10, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross10].DefaultValue = 0;
				// 粗利額(前期10ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross10, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross10].DefaultValue = 0;
				// 粗利比(10ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio10, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio10].DefaultValue = 0;
				// 売上額(当期11ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales11, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales11].DefaultValue = 0;
				// 売上額(前期11ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales11, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales11].DefaultValue = 0;
				// 売上比(11ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio11, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio11].DefaultValue = 0;
				// 粗利額(当期11ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross11, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross11].DefaultValue = 0;
				// 粗利額(前期11ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross11, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross11].DefaultValue = 0;
				// 粗利比(11ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio11, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio11].DefaultValue = 0;
				// 売上額(当期12ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermSales12, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermSales12].DefaultValue = 0;
				// 売上額(前期12ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermSales12, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermSales12].DefaultValue = 0;
				// 売上比(12ヶ月目)
				dt.Columns.Add(CT_PrevYear_SalesRatio12, typeof(Double));
				dt.Columns[CT_PrevYear_SalesRatio12].DefaultValue = 0;
				// 粗利額(当期12ヶ月目)
				dt.Columns.Add(CT_PrevYear_ThisTermGross12, typeof(Int64));
				dt.Columns[CT_PrevYear_ThisTermGross12].DefaultValue = 0;
				// 粗利額(前期12ヶ月目)
				dt.Columns.Add(CT_PrevYear_FirstTermGross12, typeof(Int64));
				dt.Columns[CT_PrevYear_FirstTermGross12].DefaultValue = 0;
				// 粗利比(12ヶ月目)
				dt.Columns.Add(CT_PrevYear_GrossRatio12, typeof(Double));
				dt.Columns[CT_PrevYear_GrossRatio12].DefaultValue = 0;

				// TODO 以下自分で設定する項目
				// 当期合計売上額
				dt.Columns.Add(CT_PrevYear_thisTermTotalSales, typeof(Int64));
				dt.Columns[CT_PrevYear_thisTermTotalSales].DefaultValue = 0;
				// 前期合計売上額
				dt.Columns.Add(CT_PrevYear_firstTermTotalSales, typeof(Int64));
				dt.Columns[CT_PrevYear_firstTermTotalSales].DefaultValue = 0;
				// 年計（横計）売上比
				dt.Columns.Add(CT_PrevYear_totalSalesRatio, typeof(Double));
				dt.Columns[CT_PrevYear_totalSalesRatio].DefaultValue = 0;
				// 当期合計粗利額
				dt.Columns.Add(CT_PrevYear_thisTermTotalGross, typeof(Int64));
				dt.Columns[CT_PrevYear_thisTermTotalGross].DefaultValue = 0;
				// 前期合計粗利額
				dt.Columns.Add(CT_PrevYear_firstTermTotalGross, typeof(Int64));
				dt.Columns[CT_PrevYear_firstTermTotalGross].DefaultValue = 0;
				// 年計粗利比
				dt.Columns.Add(CT_PrevYear_totalGrossRatio, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrossRatio].DefaultValue = 0;
				// 部門計:年計売上比
				dt.Columns.Add(CT_PrevYear_totalSlRaiotSubSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRaiotSubSec].DefaultValue = 0;
				// 部門計:年計粗利比
				dt.Columns.Add(CT_PrevYear_totalGrsRatioSubSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioSubSec].DefaultValue = 0;
				// 拠点計:年計売上比
				dt.Columns.Add(CT_PrevYear_totalSlRatioSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRatioSec].DefaultValue = 0;
				// 拠点計:年計粗利比
				dt.Columns.Add(CT_PrevYear_totalGrsRatioSec, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioSec].DefaultValue = 0;
				// 総合計:年計売上比
				dt.Columns.Add(CT_PrevYear_totalSlRatioTtl, typeof(Double));
				dt.Columns[CT_PrevYear_totalSlRatioTtl].DefaultValue = 0;
				// 総合計:年計粗利比
				dt.Columns.Add(CT_PrevYear_totalGrsRatioTtl, typeof(Double));
				dt.Columns[CT_PrevYear_totalGrsRatioTtl].DefaultValue = 0;
				//// サブタイトル
				//dt.Columns.Add(CT_PrevYear_subTitle, typeof(String));
				//dt.Columns[CT_PrevYear_subTitle].DefaultValue = "";


                // キーブレイク
				dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
				dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
		}

		#endregion
	}
}
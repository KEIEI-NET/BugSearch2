using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上推移表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上推移表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note: 2008.10.16 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>Update Note: 2009/04/15 張莉莉</br>
    /// <br>            ・売上推移表（仕入先別）の追加</br>
    /// <br>           : </br>
    /// </remarks>
    public class DCTOK02134EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SalesTransList = "Tbl_SalesTransList";

        /// <summary> 計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 自社名称1 </summary>
        public const string ct_Col_CompanyName1 = "CompanyName1";
        ///// <summary> 自社名称2 </summary>
        //public const string ct_Col_CompanyName2 = "CompanyName2"; // DEL 2008/10/16
        ///// <summary> 拠点ガイド名称 </summary>
        //public const string ct_Col_SectionGuideNm = "SectionGuideNm"; // DEL 2008/10/16
        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary> 部門コード </summary>
        //public const string ct_Col_SubSectionCode = "SubSectionCode";
        ///// <summary> 部門名称 </summary>
        //public const string ct_Col_SubSectionName = "SubSectionName";
        ///// <summary> 課コード </summary>
        //public const string ct_Col_MinSectionCode = "MinSectionCode";
        ///// <summary> 課名称 </summary>
        //public const string ct_Col_MinSectionName = "MinSectionName";
        // --- DEL 2008/10/16 --------------------------------<<<<<
        /// <summary> 従業員コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        ///// <summary> 従業員名称 </summary>
        //public const string ct_Col_EmployeeName = "EmployeeName"; // DEL 2008/10/16
        /// <summary> 従業員名称 </summary>
        public const string ct_Col_EmployeeName = "Name"; // ADD 2008/10/16
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCode = "SupplierCode";　// ADD 2009/04/15
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm"; // ADD 2009/04/15
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary> メーカー名称 </summary>
        //public const string ct_Col_MakerName = "MakerName"; // DEL 2008/10/16
        /// <summary> メーカー略称 </summary>
        public const string ct_Col_MakerShortName = "MakerShortName"; // ADD 2008/10/16
        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary> 商品区分グループコード </summary>
        //public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary> 商品区分グループ名称 </summary>
        //public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary> 商品区分コード </summary>
        //public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary> 商品区分名称 </summary>
        //public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        ///// <summary> 商品区分詳細コード </summary>
        //public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary> 商品区分詳細名称 </summary>
        //public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary> 自社分類コード </summary>
        //public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        ///// <summary> 自社分類名称 </summary>
        //public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        // --- DEL 2008/10/16 --------------------------------<<<<<
        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary> 商品大分類コード </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        /// <summary> 商品大分類名称 </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> 商品中分類コード </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> ＢＬグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> ＢＬグループコードカナ名称 </summary>
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName";
        // --- ADD 2008/10/16 --------------------------------<<<<<
        /// <summary> BLコード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        ///// <summary> BLコード名称（全角） </summary>
        //public const string ct_Col_BLGoodsFullName = "BLGoodsFullName"; // DEL 2008/10/16
        /// <summary> BLコード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName"; // ADD 2008/10/16
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        ///// <summary> 品名略称 </summary>
        //public const string ct_Col_GoodsShortName = "GoodsShortName";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";


        /// <summary> 月売上数計1 </summary>
        public const string ct_Col_TotalSalesCount1 = "TotalSalesCount1";
        /// <summary> 月売上数計2 </summary>
        public const string ct_Col_TotalSalesCount2 = "TotalSalesCount2";
        /// <summary> 月売上数計3 </summary>
        public const string ct_Col_TotalSalesCount3 = "TotalSalesCount3";
        /// <summary> 月売上数計4 </summary>
        public const string ct_Col_TotalSalesCount4 = "TotalSalesCount4";
        /// <summary> 月売上数計5 </summary>
        public const string ct_Col_TotalSalesCount5 = "TotalSalesCount5";
        /// <summary> 月売上数計6 </summary>
        public const string ct_Col_TotalSalesCount6 = "TotalSalesCount6";
        /// <summary> 月売上数計7 </summary>
        public const string ct_Col_TotalSalesCount7 = "TotalSalesCount7";
        /// <summary> 月売上数計8 </summary>
        public const string ct_Col_TotalSalesCount8 = "TotalSalesCount8";
        /// <summary> 月売上数計9 </summary>
        public const string ct_Col_TotalSalesCount9 = "TotalSalesCount9";
        /// <summary> 月売上数計10 </summary>
        public const string ct_Col_TotalSalesCount10 = "TotalSalesCount10";
        /// <summary> 月売上数計11 </summary>
        public const string ct_Col_TotalSalesCount11 = "TotalSalesCount11";
        /// <summary> 月売上数計12 </summary>
        public const string ct_Col_TotalSalesCount12 = "TotalSalesCount12";
        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary> 月売上伝票合計1（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc1 = "SalesTotalTaxExc1";
        ///// <summary> 月売上伝票合計2（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc2 = "SalesTotalTaxExc2";
        ///// <summary> 月売上伝票合計3（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc3 = "SalesTotalTaxExc3";
        ///// <summary> 月売上伝票合計4（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc4 = "SalesTotalTaxExc4";
        ///// <summary> 月売上伝票合計5（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc5 = "SalesTotalTaxExc5";
        ///// <summary> 月売上伝票合計6（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc6 = "SalesTotalTaxExc6";
        ///// <summary> 月売上伝票合計7（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc7 = "SalesTotalTaxExc7";
        ///// <summary> 月売上伝票合計8（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc8 = "SalesTotalTaxExc8";
        ///// <summary> 月売上伝票合計9（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc9 = "SalesTotalTaxExc9";
        ///// <summary> 月売上伝票合計10（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc10 = "SalesTotalTaxExc10";
        ///// <summary> 月売上伝票合計11（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc11 = "SalesTotalTaxExc11";
        ///// <summary> 月売上伝票合計12（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc12 = "SalesTotalTaxExc12";
        ///// <summary> 月返品額1 </summary>
        //public const string ct_Col_SalesRetGoodsPrice1 = "SalesRetGoodsPrice1";
        ///// <summary> 月返品額2 </summary>
        //public const string ct_Col_SalesRetGoodsPrice2 = "SalesRetGoodsPrice2";
        ///// <summary> 月返品額3 </summary>
        //public const string ct_Col_SalesRetGoodsPrice3 = "SalesRetGoodsPrice3";
        ///// <summary> 月返品額4 </summary>
        //public const string ct_Col_SalesRetGoodsPrice4 = "SalesRetGoodsPrice4";
        ///// <summary> 月返品額5 </summary>
        //public const string ct_Col_SalesRetGoodsPrice5 = "SalesRetGoodsPrice5";
        ///// <summary> 月返品額6 </summary>
        //public const string ct_Col_SalesRetGoodsPrice6 = "SalesRetGoodsPrice6";
        ///// <summary> 月返品額7 </summary>
        //public const string ct_Col_SalesRetGoodsPrice7 = "SalesRetGoodsPrice7";
        ///// <summary> 月返品額8 </summary>
        //public const string ct_Col_SalesRetGoodsPrice8 = "SalesRetGoodsPrice8";
        ///// <summary> 月返品額9 </summary>
        //public const string ct_Col_SalesRetGoodsPrice9 = "SalesRetGoodsPrice9";
        ///// <summary> 月返品額10 </summary>
        //public const string ct_Col_SalesRetGoodsPrice10 = "SalesRetGoodsPrice10";
        ///// <summary> 月返品額11 </summary>
        //public const string ct_Col_SalesRetGoodsPrice11 = "SalesRetGoodsPrice11";
        ///// <summary> 月返品額12 </summary>
        //public const string ct_Col_SalesRetGoodsPrice12 = "SalesRetGoodsPrice12";
        ///// <summary> 月純売上金額1 </summary>
        //public const string ct_Col_SalesPrice1 = "SalesPrice1";
        ///// <summary> 月純売上金額2 </summary>
        //public const string ct_Col_SalesPrice2 = "SalesPrice2";
        ///// <summary> 月純売上金額3 </summary>
        //public const string ct_Col_SalesPrice3 = "SalesPrice3";
        ///// <summary> 月純売上金額4 </summary>
        //public const string ct_Col_SalesPrice4 = "SalesPrice4";
        ///// <summary> 月純売上金額5 </summary>
        //public const string ct_Col_SalesPrice5 = "SalesPrice5";
        ///// <summary> 月純売上金額6 </summary>
        //public const string ct_Col_SalesPrice6 = "SalesPrice6";
        ///// <summary> 月純売上金額7 </summary>
        //public const string ct_Col_SalesPrice7 = "SalesPrice7";
        ///// <summary> 月純売上金額8 </summary>
        //public const string ct_Col_SalesPrice8 = "SalesPrice8";
        ///// <summary> 月純売上金額9 </summary>
        //public const string ct_Col_SalesPrice9 = "SalesPrice9";
        ///// <summary> 月純売上金額10 </summary>
        //public const string ct_Col_SalesPrice10 = "SalesPrice10";
        ///// <summary> 月純売上金額11 </summary>
        //public const string ct_Col_SalesPrice11 = "SalesPrice11";
        ///// <summary> 月純売上金額12 </summary>
        //public const string ct_Col_SalesPrice12 = "SalesPrice12";
        // --- DEL 2008/10/16 --------------------------------<<<<<
        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary> 売上金額1 </summary>
        public const string ct_Col_SalesMoney1 = "SalesMoney1";
        /// <summary> 売上金額2 </summary>
        public const string ct_Col_SalesMoney2 = "SalesMoney2";
        /// <summary> 売上金額3 </summary>
        public const string ct_Col_SalesMoney3 = "SalesMoney3";
        /// <summary> 売上金額4 </summary>
        public const string ct_Col_SalesMoney4 = "SalesMoney4";
        /// <summary> 売上金額5 </summary>
        public const string ct_Col_SalesMoney5 = "SalesMoney5";
        /// <summary> 売上金額6 </summary>
        public const string ct_Col_SalesMoney6 = "SalesMoney6";
        /// <summary> 売上金額7 </summary>
        public const string ct_Col_SalesMoney7 = "SalesMoney7";
        /// <summary> 売上金額8 </summary>
        public const string ct_Col_SalesMoney8 = "SalesMoney8";
        /// <summary> 売上金額9 </summary>
        public const string ct_Col_SalesMoney9 = "SalesMoney9";
        /// <summary> 売上金額10 </summary>
        public const string ct_Col_SalesMoney10 = "SalesMoney10";
        /// <summary> 売上金額11 </summary>
        public const string ct_Col_SalesMoney11 = "SalesMoney11";
        /// <summary> 売上金額12 </summary>
        public const string ct_Col_SalesMoney12 = "SalesMoney12";
        // --- ADD 2008/10/16 --------------------------------<<<<<
        /// <summary> 売上数合計 </summary>
        public const string ct_Col_TtlTotalSalesCount = "TtlTotalSalesCount";
        ///// <summary> 純売上金額合計 </summary>
        //public const string ct_Col_TtlSalesPrice = "TtlSalesPrice"; // DEL 2008/10/16
        /// <summary> 売上金額合計 </summary>
        public const string ct_Col_TtlSalesMoney = "TtlSalesMoney"; // ADD 2008/10/16
        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 売上推移表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上推移表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCTOK02134EA ()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ テーブルスキーマ設定
        /// <summary>
        /// 在庫・倉庫移動DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        static public void CreateDataTable ( ref DataTable dt )
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
                dt = new DataTable( ct_Tbl_SalesTransList );

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column追加>

                // 計上拠点コード
                dt.Columns.Add( ct_Col_AddUpSecCode, typeof( string ) );
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = defaultValueOfstring;

                // 自社名称1
                dt.Columns.Add( ct_Col_CompanyName1, typeof( string ) );
                dt.Columns[ct_Col_CompanyName1].DefaultValue = defaultValueOfstring;

                //// 自社名称2
                //dt.Columns.Add( ct_Col_CompanyName2, typeof( string ) );
                //dt.Columns[ct_Col_CompanyName2].DefaultValue = defaultValueOfstring; // DEL 2008/10/16

                //// 拠点ガイド名称
                //dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                //dt.Columns[ct_Col_SectionGuideNm].DefaultValue = defaultValueOfstring; // DEL 2008/10/16

                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 部門コード
                //dt.Columns.Add( ct_Col_SubSectionCode, typeof( Int32 ) );
                //dt.Columns[ct_Col_SubSectionCode].DefaultValue = defaultValueOfInt32;

                //// 部門名称
                //dt.Columns.Add( ct_Col_SubSectionName, typeof( string ) );
                //dt.Columns[ct_Col_SubSectionName].DefaultValue = defaultValueOfstring;

                //// 課コード
                //dt.Columns.Add( ct_Col_MinSectionCode, typeof( Int32 ) );
                //dt.Columns[ct_Col_MinSectionCode].DefaultValue = defaultValueOfInt32;

                //// 課名称
                //dt.Columns.Add( ct_Col_MinSectionName, typeof( string ) );
                //dt.Columns[ct_Col_MinSectionName].DefaultValue = defaultValueOfstring;
                // --- DEL 2008/10/16 --------------------------------<<<<<

                // 従業員コード
                dt.Columns.Add( ct_Col_EmployeeCode, typeof( string ) );
                dt.Columns[ct_Col_EmployeeCode].DefaultValue = defaultValueOfstring;

                // 従業員名称
                dt.Columns.Add( ct_Col_EmployeeName, typeof( string ) );
                dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;

                // 得意先コード
                dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
                dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;

                // 得意先略称
                dt.Columns.Add( ct_Col_CustomerSnm, typeof( string ) );
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;

                // 仕入先コード 
                dt.Columns.Add(ct_Col_SupplierCode, typeof(Int32)); // ADD 2009/04/15
                dt.Columns[ct_Col_SupplierCode].DefaultValue = defaultValueOfInt32; // ADD 2009/04/15

                // 仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string)); // ADD 2009/04/15
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = defaultValueOfstring; // ADD 2009/04/15
                // 商品メーカーコード
                dt.Columns.Add( ct_Col_GoodsMakerCd, typeof( Int32 ) );
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfInt32;

                // メーカー名称
                //dt.Columns.Add( ct_Col_MakerName, typeof( string ) );
                //dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));
                dt.Columns[ct_Col_MakerShortName].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                // 商品大分類コード
                //dt.Columns.Add(ct_Col_LargeGoodsGanreCode, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32)); // ADD 2008/10/16
                dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defaultValueOfInt32; // ADD 2008/10/16

                // 商品大分類名称
                //dt.Columns.Add(ct_Col_LargeGoodsGanreName, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string)); // ADD 2008/10/16
                dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                // 商品中分類コード
                //dt.Columns.Add(ct_Col_MediumGoodsGanreCode, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32)); // ADD 2008/10/16
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defaultValueOfInt32; // ADD 2008/10/16

                // 商品中分類名称
                //dt.Columns.Add(ct_Col_MediumGoodsGanreName, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string)); // ADD 2008/10/16
                dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                // ＢＬグループコード
                //dt.Columns.Add(ct_Col_DetailGoodsGanreCode, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32)); // ADD 2008/10/16
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = defaultValueOfInt32; // ADD 2008/10/16

                // ＢＬグループコード名称
                //dt.Columns.Add(ct_Col_DetailGoodsGanreName, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string)); // ADD 2008/10/16
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                //// 自社分類コード
                //dt.Columns.Add(ct_Col_EnterpriseGanreCode, typeof(Int32)); // DEL 2008/10/16
                //dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = defaultValueOfInt32; // DEL 2008/10/16

                //// 自社分類名称
                //dt.Columns.Add(ct_Col_EnterpriseGanreName, typeof(string)); // DEL 2008/10/16
                //dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16

                // BL商品コード
                dt.Columns.Add( ct_Col_BLGoodsCode, typeof( Int32 ) );
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfInt32;

                // BL商品コード名称（半角）
                //dt.Columns.Add( ct_Col_BLGoodsFullName, typeof( string ) ); // DEL 2008/10/16
                //dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string)); // ADD 2008/10/16
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                // 商品番号
                dt.Columns.Add( ct_Col_GoodsNo, typeof( string ) );
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // 商品名略称
                //dt.Columns.Add( ct_Col_GoodsShortName, typeof( string ) ); // DEL 2008/10/16
                //dt.Columns[ct_Col_GoodsShortName].DefaultValue = defaultValueOfstring; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string)); // ADD 2008/10/16
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defaultValueOfstring; // ADD 2008/10/16

                // 月売上数計1
                dt.Columns.Add( ct_Col_TotalSalesCount1, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount1].DefaultValue = defaultValueOfDouble;

                // 月売上数計2
                dt.Columns.Add( ct_Col_TotalSalesCount2, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount2].DefaultValue = defaultValueOfDouble;

                // 月売上数計3
                dt.Columns.Add( ct_Col_TotalSalesCount3, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount3].DefaultValue = defaultValueOfDouble;

                // 月売上数計4
                dt.Columns.Add( ct_Col_TotalSalesCount4, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount4].DefaultValue = defaultValueOfDouble;

                // 月売上数計5
                dt.Columns.Add( ct_Col_TotalSalesCount5, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount5].DefaultValue = defaultValueOfDouble;

                // 月売上数計6
                dt.Columns.Add( ct_Col_TotalSalesCount6, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount6].DefaultValue = defaultValueOfDouble;

                // 月売上数計7
                dt.Columns.Add( ct_Col_TotalSalesCount7, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount7].DefaultValue = defaultValueOfDouble;

                // 月売上数計8
                dt.Columns.Add( ct_Col_TotalSalesCount8, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount8].DefaultValue = defaultValueOfDouble;

                // 月売上数計9
                dt.Columns.Add( ct_Col_TotalSalesCount9, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount9].DefaultValue = defaultValueOfDouble;

                // 月売上数計10
                dt.Columns.Add( ct_Col_TotalSalesCount10, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount10].DefaultValue = defaultValueOfDouble;

                // 月売上数計11
                dt.Columns.Add( ct_Col_TotalSalesCount11, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount11].DefaultValue = defaultValueOfDouble;

                // 月売上数計12
                dt.Columns.Add( ct_Col_TotalSalesCount12, typeof( Double ) );
                dt.Columns[ct_Col_TotalSalesCount12].DefaultValue = defaultValueOfDouble;

                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 月売上伝票合計1（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc1, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc1].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計2（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc2, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc2].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計3（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc3, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc3].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計4（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc4, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc4].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計5（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc5, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc5].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計6（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc6, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc6].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計7（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc7, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc7].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計8（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc8, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc8].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計9（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc9, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc9].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計10（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc10, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc10].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計11（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc11, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc11].DefaultValue = defaultValueOfInt64;

                //// 月売上伝票合計12（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc12, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc12].DefaultValue = defaultValueOfInt64;

                //// 月返品額1
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice1, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice1].DefaultValue = defaultValueOfInt64;

                //// 月返品額2
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice2, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice2].DefaultValue = defaultValueOfInt64;

                //// 月返品額3
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice3, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice3].DefaultValue = defaultValueOfInt64;

                //// 月返品額4
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice4, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice4].DefaultValue = defaultValueOfInt64;

                //// 月返品額5
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice5, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice5].DefaultValue = defaultValueOfInt64;

                //// 月返品額6
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice6, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice6].DefaultValue = defaultValueOfInt64;

                //// 月返品額7
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice7, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice7].DefaultValue = defaultValueOfInt64;

                //// 月返品額8
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice8, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice8].DefaultValue = defaultValueOfInt64;

                //// 月返品額9
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice9, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice9].DefaultValue = defaultValueOfInt64;

                //// 月返品額10
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice10, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice10].DefaultValue = defaultValueOfInt64;

                //// 月返品額11
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice11, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice11].DefaultValue = defaultValueOfInt64;

                //// 月返品額12
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice12, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice12].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額1
                //dt.Columns.Add( ct_Col_SalesPrice1, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice1].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額2
                //dt.Columns.Add( ct_Col_SalesPrice2, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice2].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額3
                //dt.Columns.Add( ct_Col_SalesPrice3, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice3].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額4
                //dt.Columns.Add( ct_Col_SalesPrice4, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice4].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額5
                //dt.Columns.Add( ct_Col_SalesPrice5, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice5].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額6
                //dt.Columns.Add( ct_Col_SalesPrice6, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice6].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額7
                //dt.Columns.Add( ct_Col_SalesPrice7, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice7].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額8
                //dt.Columns.Add( ct_Col_SalesPrice8, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice8].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額9
                //dt.Columns.Add( ct_Col_SalesPrice9, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice9].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額10
                //dt.Columns.Add( ct_Col_SalesPrice10, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice10].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額11
                //dt.Columns.Add( ct_Col_SalesPrice11, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice11].DefaultValue = defaultValueOfInt64;

                //// 月純売上金額12
                //dt.Columns.Add( ct_Col_SalesPrice12, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice12].DefaultValue = defaultValueOfInt64;
                // --- DEL 2008/10/16 --------------------------------<<<<<

                // --- ADD 2008/10/16 -------------------------------->>>>>
                // 売上金額1
                dt.Columns.Add(ct_Col_SalesMoney1, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney1].DefaultValue = defaultValueOfInt64;

                // 売上金額2
                dt.Columns.Add(ct_Col_SalesMoney2, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney2].DefaultValue = defaultValueOfInt64;

                // 売上金額3
                dt.Columns.Add(ct_Col_SalesMoney3, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney3].DefaultValue = defaultValueOfInt64;

                // 売上金額4
                dt.Columns.Add(ct_Col_SalesMoney4, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney4].DefaultValue = defaultValueOfInt64;

                // 売上金額5
                dt.Columns.Add(ct_Col_SalesMoney5, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney5].DefaultValue = defaultValueOfInt64;

                // 売上金額6
                dt.Columns.Add(ct_Col_SalesMoney6, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney6].DefaultValue = defaultValueOfInt64;

                // 売上金額7
                dt.Columns.Add(ct_Col_SalesMoney7, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney7].DefaultValue = defaultValueOfInt64;

                // 売上金額8
                dt.Columns.Add(ct_Col_SalesMoney8, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney8].DefaultValue = defaultValueOfInt64;

                // 売上金額9
                dt.Columns.Add(ct_Col_SalesMoney9, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney9].DefaultValue = defaultValueOfInt64;

                // 売上金額10
                dt.Columns.Add(ct_Col_SalesMoney10, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney10].DefaultValue = defaultValueOfInt64;

                // 売上金額11
                dt.Columns.Add(ct_Col_SalesMoney11, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney11].DefaultValue = defaultValueOfInt64;

                // 売上金額12
                dt.Columns.Add(ct_Col_SalesMoney12, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney12].DefaultValue = defaultValueOfInt64;
                // --- ADD 2008/10/16 --------------------------------<<<<<

                // 売上数合計
                dt.Columns.Add( ct_Col_TtlTotalSalesCount, typeof( Int64 ) );
                dt.Columns[ct_Col_TtlTotalSalesCount].DefaultValue = defaultValueOfInt64;

                // 売上金額合計
                //dt.Columns.Add( ct_Col_TtlSalesPrice, typeof( Int64 ) ); // DEL 2008/10/16
                //dt.Columns[ct_Col_TtlSalesPrice].DefaultValue = defaultValueOfInt64; // DEL 2008/10/16
                dt.Columns.Add(ct_Col_TtlSalesMoney, typeof(Int64)); // ADD 2008/10/16
                dt.Columns[ct_Col_TtlSalesMoney].DefaultValue = defaultValueOfInt64; // ADD 2008/10/16

                # endregion
            }
        }
        #endregion
        #endregion
    }
}

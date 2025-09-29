using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫受払確認表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫受払確認表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2008/12/15 照田 貴志　入庫金額、出庫金額追加</br>
    /// <br>             2009/01/08 照田 貴志　単価を入庫単価、出庫単価に分割</br>
    /// <br>             2009/01/28 照田 貴志　不具合対応[10622]</br>
    /// <br>           : </br>
    /// <br>Update Note: 2010/11/15 liyp</br>
    /// <br>           : PM.NS 機能改良Ｑ４</br>
	/// </remarks>
	public class DCZAI02204EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockAcPayList = "Tbl_StockAcPayList";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 入出荷日 </summary>
        public const string ct_Col_IoGoodsDay = "IoGoodsDay";
        /// <summary> 受払元伝票番号 </summary>
        public const string ct_Col_AcPaySlipNum = "AcPaySlipNum";
        /// <summary> 受払元行番号 </summary>
        public const string ct_Col_AcPaySlipRowNo = "AcPaySlipRowNo";
        /// <summary> 受払元伝票区分 </summary>
        public const string ct_Col_AcPaySlipCd = "AcPaySlipCd";
        /// <summary> 受払元取引区分 </summary>
        public const string ct_Col_AcPayTransCd = "AcPayTransCd";
        /// <summary> 受払先コード（印刷用） </summary>
        public const string ct_Col_AcPayOtherPartyCd = "AcPayOtherPartyCd";
        /// <summary> 受払先名称（印刷用） </summary>
        public const string ct_Col_AcPayOtherPartyNm = "AcPayOtherPartyNm";
        /// <summary> 入荷数 </summary>
        public const string ct_Col_ArrivalCnt = "ArrivalCnt";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 定価（税抜，浮動） </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> 仕入単価（税抜，浮動） </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 受払元伝票区分 </summary>
        public const string ct_Col_AcPaySlipNm = "AcPaySlipNm";
        /// <summary> 受払元取引区分 </summary>
        public const string ct_Col_AcPayTransNm = "AcPayTransNm";

        //--- ADD 2008/12/15 ------------------------------------------>>>>>
        /// <summary> 入庫金額 </summary>
        public const string ct_Col_StockPrice = "StockPrice";
        /// <summary> 出庫金額 </summary>
        public const string ct_Col_SalesMoney = "SalesMoney";
        //--- ADD 2008/12/15 ------------------------------------------<<<<<
        //--- ADD 2009/01/08 ------------------------------------------>>>>>
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        //--- ADD 2009/01/08 ------------------------------------------<<<<<
        //--- ADD 2009/01/28 不具合対応[10622] ------------------------>>>>>
        /// <summary> 受払履歴作成日時 </summary>
        public const string ct_Col_AcPayHistDateTime = "AcPayHistDateTime";
        //--- ADD 2009/01/08 不具合対応[10622] ------------------------<<<<<

        //--- ADD 2010/11/15 ------------------------------------------>>>>>
        /// <summary> 前月末残 </summary>
        public const string ct_Col_StockTotal = "StockTotal";

        /// <summary> メーカーと商品番号 </summary>
        public const string ct_Col_GoodsNoMaker = "GoodsNoMaker";

        /// <summary> 棚番 </summary>
        public const string ct_Col_ShelfNo = "ShelfNo";

        /// <summary> 受払履歴作成日時 </summary>
        public const string ct_Col_AcPayHistDateTimeView = "AcPayHistDateTimeView";

        /// <summary> ) </summary>
        public const string ct_Col_Bracker = "Bracker";
        /// <summary> ) </summary>
        public const string ct_Col_BrackerPrice = "BrackerPrice";
        //--- ADD 2010/11/15 ------------------------------------------<<<<<
        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫受払確認表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫受払確認表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02204EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// <summary>
		/// 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br>Update Note: 2010/11/15 liyp</br>
        /// <br>           : PM.NS 機能改良Ｑ４</br>
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
                dt = new DataTable( ct_Tbl_StockAcPayList );

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column追加>

                // 拠点コード
                dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
                dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;

                // 拠点ガイド名称
                dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = defaultValueOfstring;

                // 倉庫コード
                dt.Columns.Add( ct_Col_WarehouseCode, typeof( string ) );
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // 倉庫名称
                dt.Columns.Add( ct_Col_WarehouseName, typeof( string ) );
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;

                // 商品メーカーコード
                dt.Columns.Add( ct_Col_GoodsMakerCd, typeof( Int32 ) );
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfInt32;

                // メーカー名称
                dt.Columns.Add( ct_Col_MakerName, typeof( string ) );
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;

                // 商品番号
                dt.Columns.Add( ct_Col_GoodsNo, typeof( string ) );
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // 商品名称
                dt.Columns.Add( ct_Col_GoodsName, typeof( string ) );
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;

                // 入出荷日
                dt.Columns.Add( ct_Col_IoGoodsDay, typeof( string ) );
                dt.Columns[ct_Col_IoGoodsDay].DefaultValue = defaultValueOfstring;

                // 受払元伝票番号
                dt.Columns.Add( ct_Col_AcPaySlipNum, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNum].DefaultValue = defaultValueOfstring;

                // 受払元行番号
                dt.Columns.Add( ct_Col_AcPaySlipRowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipRowNo].DefaultValue = defaultValueOfInt32;

                // 受払元伝票区分
                dt.Columns.Add( ct_Col_AcPaySlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipCd].DefaultValue = defaultValueOfInt32;

                // 受払元取引区分
                dt.Columns.Add( ct_Col_AcPayTransCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPayTransCd].DefaultValue = defaultValueOfInt32;

                // 受払先コード（印刷用）
                dt.Columns.Add( ct_Col_AcPayOtherPartyCd, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyCd].DefaultValue = defaultValueOfstring;

                // 受払先名称（印刷用）
                dt.Columns.Add( ct_Col_AcPayOtherPartyNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyNm].DefaultValue = defaultValueOfstring;

                // 入荷数
                //dt.Columns.Add( ct_Col_ArrivalCnt, typeof( Double ) );//DEL 2010/11/15
                dt.Columns.Add( ct_Col_ArrivalCnt, typeof( string ) );//ADD 2010/11/15
                //dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfDouble;//DEL 2010/11/15
				dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfstring;//ADD 2010/11/15
                // 出荷数
                //dt.Columns.Add( ct_Col_ShipmentCnt, typeof( Double ) );//DEL 2010/11/15
                dt.Columns.Add( ct_Col_ShipmentCnt, typeof( string ) );//ADD 2010/11/15
                //dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;//DEL 2010/11/15
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfstring;//ADD 2010/11/15

                // 定価（税抜，浮動）
                dt.Columns.Add( ct_Col_ListPriceTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defaultValueOfDouble;

                // 仕入単価（税抜，浮動）
                dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // 受払元伝票区分
                dt.Columns.Add( ct_Col_AcPaySlipNm, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNm].DefaultValue = defaultValueOfstring;

                // 受払元取引区分
                dt.Columns.Add( ct_Col_AcPayTransNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayTransNm].DefaultValue = defaultValueOfstring;

                //--- ADD 2008/12/15 ------------------------------------------>>>>>
                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                // 入庫金額
                //dt.Columns.Add( ct_Col_StockPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfInt64;
                dt.Columns.Add(ct_Col_StockPrice, typeof(string));
                dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfstring;
                // 出庫金額
                //dt.Columns.Add( ct_Col_SalesMoney, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesMoney].DefaultValue = defaultValueOfInt64;
                dt.Columns.Add(ct_Col_SalesMoney, typeof(string));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = defaultValueOfstring;
                //--- ADD 2010/11/15 ------------------------------------------<<<<<
                //--- ADD 2008/12/15 ------------------------------------------<<<<<

                //--- ADD 2009/01/08 ------------------------------------------>>>>>
                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof( Double ));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;
                //--- ADD 2009/01/08 ------------------------------------------<<<<<

                //--- ADD 2009/01/28 不具合対応[10622] ------------------------>>>>>
                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_AcPayHistDateTime, typeof(DateTime));
                dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfDateTime;
                //--- ADD 2009/01/28 不具合対応[10622] ------------------------<<<<<

                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                /// <summary> 前月末残 </summary>
                dt.Columns.Add(ct_Col_StockTotal, typeof(Int64));
                dt.Columns[ct_Col_StockTotal].DefaultValue = defaultValueOfInt64;

                /// <summary> メーカーと商品番号 </summary>
                dt.Columns.Add(ct_Col_GoodsNoMaker, typeof(string));
                dt.Columns[ct_Col_GoodsNoMaker].DefaultValue = defaultValueOfstring;

                /// <summary> 棚番 </summary>
                dt.Columns.Add(ct_Col_ShelfNo, typeof(string));
                dt.Columns[ct_Col_ShelfNo].DefaultValue = defaultValueOfstring;

                /// <summary> 受払履歴作成日時 </summary>
                dt.Columns.Add(ct_Col_AcPayHistDateTimeView, typeof(string));
                dt.Columns[ct_Col_AcPayHistDateTimeView].DefaultValue = defaultValueOfstring;
                
                /// <summary> ) </summary>
                dt.Columns.Add(ct_Col_Bracker, typeof(string));
                dt.Columns[ct_Col_Bracker].DefaultValue = defaultValueOfstring;

                /// <summary> ) </summary>
                dt.Columns.Add(ct_Col_BrackerPrice, typeof(string));
                dt.Columns[ct_Col_BrackerPrice].DefaultValue = defaultValueOfstring;
                //--- ADD 2010/11/15 ------------------------------------------<<<<<
                # endregion
            }
		}
		#endregion
		#endregion
	}
}

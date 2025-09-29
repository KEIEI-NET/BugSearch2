using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫入出荷一覧表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫入出荷一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2009/03/18 照田 貴志　不具合対応[12542]</br>
    /// <br>           : </br>
	/// </remarks>
	public class DCZAI02125EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockShipArrival = "Tbl_StockShipArrival";

        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>拠点ガイド名称</summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";

        /// <summary> 仕入先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 仕入先名称１ </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 仕入先名称２ </summary>
        public const string ct_Col_CustomerName2 = "CustomerName2";
        ///// <summary> 仕入先略称 </summary>
        //public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 在庫登録日 </summary>
        public const string ct_Col_StockCreateDate = "StockCreateDate";

        /// <summary> 出荷数１ </summary>
        public const string ct_Col_ShipmentCnt1 = "ShipmentCnt1";
        /// <summary> 出荷数２ </summary>
        public const string ct_Col_ShipmentCnt2 = "ShipmentCnt2";
        /// <summary> 出荷数３ </summary>
        public const string ct_Col_ShipmentCnt3 = "ShipmentCnt3";
        /// <summary> 出荷数４ </summary>
        public const string ct_Col_ShipmentCnt4 = "ShipmentCnt4";
        /// <summary> 出荷数５ </summary>
        public const string ct_Col_ShipmentCnt5 = "ShipmentCnt5";
        /// <summary> 出荷数６ </summary>
        public const string ct_Col_ShipmentCnt6 = "ShipmentCnt6";
        /// <summary> 出荷数７ </summary>
        public const string ct_Col_ShipmentCnt7 = "ShipmentCnt7";
        /// <summary> 出荷数８ </summary>
        public const string ct_Col_ShipmentCnt8 = "ShipmentCnt8";
        /// <summary> 出荷数９ </summary>
        public const string ct_Col_ShipmentCnt9 = "ShipmentCnt9";
        /// <summary> 出荷数１０ </summary>
        public const string ct_Col_ShipmentCnt10 = "ShipmentCnt10";
        /// <summary> 出荷数１１ </summary>
        public const string ct_Col_ShipmentCnt11 = "ShipmentCnt11";
        /// <summary> 出荷数１２ </summary>
        public const string ct_Col_ShipmentCnt12 = "ShipmentCnt12";
        /// <summary> 出荷数平均 </summary>
        public const string ct_Col_Avg_ShipmentCnt = "Avg_ShipmentCnt";
        /// <summary> 出荷数合計 </summary>
        public const string ct_Col_Sum_ShipmentCnt = "Sum_ShipmentCnt";

        /// <summary> 入荷数１ </summary>
        public const string ct_Col_ArrivalCnt1 = "ArrivalCnt1";
        /// <summary> 入荷数２ </summary>
        public const string ct_Col_ArrivalCnt2 = "ArrivalCnt2";
        /// <summary> 入荷数３ </summary>
        public const string ct_Col_ArrivalCnt3 = "ArrivalCnt3";
        /// <summary> 入荷数４ </summary>
        public const string ct_Col_ArrivalCnt4 = "ArrivalCnt4";
        /// <summary> 入荷数５ </summary>
        public const string ct_Col_ArrivalCnt5 = "ArrivalCnt5";
        /// <summary> 入荷数６ </summary>
        public const string ct_Col_ArrivalCnt6 = "ArrivalCnt6";
        /// <summary> 入荷数７ </summary>
        public const string ct_Col_ArrivalCnt7 = "ArrivalCnt7";
        /// <summary> 入荷数８ </summary>
        public const string ct_Col_ArrivalCnt8 = "ArrivalCnt8";
        /// <summary> 入荷数９ </summary>
        public const string ct_Col_ArrivalCnt9 = "ArrivalCnt9";
        /// <summary> 入荷数１０ </summary>
        public const string ct_Col_ArrivalCnt10 = "ArrivalCnt10";
        /// <summary> 入荷数１１ </summary>
        public const string ct_Col_ArrivalCnt11 = "ArrivalCnt11";
        /// <summary> 入荷数１２ </summary>
        public const string ct_Col_ArrivalCnt12 = "ArrivalCnt12";
        /// <summary> 入荷数平均 </summary>
        public const string ct_Col_Avg_ArrivalCnt = "Avg_ArrivalCnt";
        /// <summary> 入荷数合計 </summary>
        public const string ct_Col_Sum_ArrivalCnt = "Sum_ArrivalCnt";

        /// <summary> ソート用（拠点コード） </summary>
        public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用（倉庫コード） </summary>
        public const string ct_Col_Sort_WarehouseCode = "Sort_WarehouseCode";
        /// <summary> ソート用（仕入先コード） </summary>
        public const string ct_Col_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> ソート用（商品メーカーコード） </summary>
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        /// <summary> ソート用（商品番号） </summary>
        public const string ct_Col_Sort_GoodsNo = "Sort_GoodsNo";
        /// <summary> ソート用（商品大分類） </summary>
        public const string ct_Col_Sort_LargeGoodsGanre = "Sort_LargeGoodsGanre";
        /// <summary> ソート用（商品中分類） </summary>
        public const string ct_Col_Sort_MediumGoodsGanre = "Sort_MediumGoodsGanre";
        /// <summary> ソート用（BLグループ） </summary>
        public const string ct_Col_Sort_DetailGoodsGanre = "Sort_DetailGoodsGanre";

        // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------->>>>>
        /// <summary> 商品大分類名称 </summary>
        public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        /// <summary> BLグループ名称 </summary>
        public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
        // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------<<<<<

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫入出荷一覧表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02125EA()
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
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
                dt = new DataTable(ct_Tbl_StockShipArrival);

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));     //拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));  //拠点ガイド名称
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));     //仕入先コード
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_CustomerName, typeof(string));    //仕入先名称１
                dt.Columns[ct_Col_CustomerName].DefaultValue = "";

                dt.Columns.Add(ct_Col_CustomerName2, typeof(string));   //仕入先名称２
                dt.Columns[ct_Col_CustomerName2].DefaultValue = "";

                //dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));   //仕入先略称
                //dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));     //商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MakerName, typeof(string));       //メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
               
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));   //倉庫コード
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));   //倉庫名称
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));         //商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));       //商品名称
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));//倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
           
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(string)); //在庫登録日
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = "";
              
                dt.Columns.Add(ct_Col_ShipmentCnt1, typeof(double));    //出荷数1
                dt.Columns[ct_Col_ShipmentCnt1].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt2, typeof(double));    //出荷数2
                dt.Columns[ct_Col_ShipmentCnt2].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt3, typeof(double));    //出荷数3
                dt.Columns[ct_Col_ShipmentCnt3].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt4, typeof(double));    //出荷数4
                dt.Columns[ct_Col_ShipmentCnt4].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt5, typeof(double));    //出荷数5
                dt.Columns[ct_Col_ShipmentCnt5].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt6, typeof(double));    //出荷数6
                dt.Columns[ct_Col_ShipmentCnt6].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt7, typeof(double));    //出荷数7
                dt.Columns[ct_Col_ShipmentCnt7].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt8, typeof(double));    //出荷数8
                dt.Columns[ct_Col_ShipmentCnt8].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt9, typeof(double));    //出荷数9
                dt.Columns[ct_Col_ShipmentCnt9].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt10, typeof(double));   //出荷数10
                dt.Columns[ct_Col_ShipmentCnt10].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt11, typeof(double));   //出荷数11
                dt.Columns[ct_Col_ShipmentCnt11].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ShipmentCnt12, typeof(double));   //出荷数12
                dt.Columns[ct_Col_ShipmentCnt12].DefaultValue = 0;
                dt.Columns.Add(ct_Col_Avg_ShipmentCnt, typeof(double)); //出荷数平均
                dt.Columns[ct_Col_Avg_ShipmentCnt].DefaultValue = 0;
                dt.Columns.Add(ct_Col_Sum_ShipmentCnt, typeof(double)); //出荷数合計
                dt.Columns[ct_Col_Sum_ShipmentCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_ArrivalCnt1, typeof(double));     //入荷数1
                dt.Columns[ct_Col_ArrivalCnt1].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt2, typeof(double));     //入荷数2
                dt.Columns[ct_Col_ArrivalCnt2].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt3, typeof(double));     //入荷数3
                dt.Columns[ct_Col_ArrivalCnt3].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt4, typeof(double));     //入荷数4
                dt.Columns[ct_Col_ArrivalCnt4].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt5, typeof(double));     //入荷数5
                dt.Columns[ct_Col_ArrivalCnt5].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt6, typeof(double));     //入荷数6
                dt.Columns[ct_Col_ArrivalCnt6].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt7, typeof(double));     //入荷数7
                dt.Columns[ct_Col_ArrivalCnt7].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt8, typeof(double));     //入荷数8
                dt.Columns[ct_Col_ArrivalCnt8].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt9, typeof(double));     //入荷数9
                dt.Columns[ct_Col_ArrivalCnt9].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt10, typeof(double));    //入荷数10
                dt.Columns[ct_Col_ArrivalCnt10].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt11, typeof(double));    //入荷数11
                dt.Columns[ct_Col_ArrivalCnt11].DefaultValue = 0;
                dt.Columns.Add(ct_Col_ArrivalCnt12, typeof(double));    //入荷数12
                dt.Columns[ct_Col_ArrivalCnt12].DefaultValue = 0;
                dt.Columns.Add(ct_Col_Avg_ArrivalCnt, typeof(double));  //入荷数平均
                dt.Columns[ct_Col_Avg_ArrivalCnt].DefaultValue = 0;
                dt.Columns.Add(ct_Col_Sum_ArrivalCnt, typeof(double));  //入荷数合計
                dt.Columns[ct_Col_Sum_ArrivalCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));//ソート用（拠点コード）
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_WarehouseCode, typeof(string));//ソート用（倉庫コード）
                dt.Columns[ct_Col_Sort_WarehouseCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(Int32));//ソート用（仕入先コード）
                dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));//ソート用（商品メーカーコード）
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string));    //ソート用（商品番号）
                dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_LargeGoodsGanre, typeof(string));     //ソート用（商品大分類）
                dt.Columns[ct_Col_Sort_LargeGoodsGanre].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_MediumGoodsGanre, typeof(string));    //ソート用（商品中分類）
                dt.Columns[ct_Col_Sort_MediumGoodsGanre].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_DetailGoodsGanre, typeof(string));    //ソート用（BLグループ）
                dt.Columns[ct_Col_Sort_DetailGoodsGanre].DefaultValue = "";

                // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------->>>>>
                dt.Columns.Add(ct_Col_DetailGoodsGanreName, typeof(string));    //BLグループ名称
                dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = "";

                dt.Columns.Add(ct_Col_LargeGoodsGanreName, typeof(string));     //商品大分類名称
                dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = "";

                dt.Columns.Add(ct_Col_MediumGoodsGanreName, typeof(string));    //商品中分類名称
                dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = "";
                // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------<<<<<
            }
		}
		#endregion
		#endregion
	}
}

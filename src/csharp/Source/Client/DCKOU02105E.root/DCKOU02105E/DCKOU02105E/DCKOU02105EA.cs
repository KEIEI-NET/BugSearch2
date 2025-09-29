using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫・倉庫移動確認表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22013 久保　将太</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
    /// <br>UpdateNote : 2008/08/08 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br> 
	/// </remarks>
	public class DCKOU02105EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_StockDayMonthReportData = "Tbl_StockDayMonthReportData";

		/// <summary> 拠点コード </summary>
		public const string ct_Col_SectionCode = "SectionCode";
		/// <summary> 拠点ガイド名称 </summary>
		public const string ct_Col_SectionGuideNm = "SectionGuideNm";

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary> 得意先コード </summary>
        //public const string ct_Col_CustomerCode = "CustomerCode";
        ///// <summary> 得意先名称 </summary>
        //public const string ct_Col_CustomerName = "CustomerName";
        ///// <summary> 得意先名称2 </summary>
        //public const string ct_Col_CustomerName2 = "CustomerName2";
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCode = "SupplierCode";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/08/08 --------------------------------<<<<< 

        // --- DEL 2008/08/08 -------------------------------->>>>>
        ///// <summary> 仕入担当者コード </summary>
        //public const string ct_Col_StockAgentCode = "StockAgentCode";
        ///// <summary> 仕入担当者名称 </summary>
        //public const string ct_Col_StockAgentName = "StockAgentName";

        ///// <summary> 仕入金額日計 </summary>
        //public const string ct_Col_StckPriceDayTotal = "StckPriceDayTotal";
        ///// <summary> 返品金額日計 </summary>
        //public const string ct_Col_RetGdsDayTotal = "RetGdsDayTotal";
        ///// <summary> 値引金額日計 </summary>
        //public const string ct_Col_DisDayTotal = "DisDayTotal";
        ///// <summary> 純仕入額日計 </summary>
        //public const string ct_Col_NetStcPrcDayTotal = "NetStcPrcDayTotal";

        ///// <summary> 返品率日計 </summary>
        //public const string ct_Col_RetGdsDayRate = "RetGdsDayRate";
        ///// <summary> 値引率日計 </summary>
        //public const string ct_Col_DisDayRate = "DisDayRate";

        ///// <summary> 仕入金額月計 </summary>
        //public const string ct_Col_StckPriceMonthTotal = "StckPriceMonthTotal";
        ///// <summary> 返品金額月計 </summary>
        //public const string ct_Col_RetGdsMonthTotal = "RetGdsMonthTotal";
        ///// <summary> 値引金額月計 </summary>
        //public const string ct_Col_DisDayMonthTotal = "DisDayMonthTotal";
        ///// <summary> 純仕入額月計 </summary>
        //public const string ct_Col_NetStcPrcMonthTotal = "NetStcPrcMonthTotal";

        ///// <summary> 返品率月計 </summary>
        //public const string ct_Col_RetGdsMonthRate = "RetGdsMonthRate";
        ///// <summary> 値引率月計 </summary>
        //public const string ct_Col_DisDayMonthRate = "DisDayMonthRate";
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        // --- ADD 2008/08/08 -------------------------------->>>>>
        /// <summary> 仕入金額日計(在庫) </summary>
        public const string ct_Col_StckPriceDayTotalZai = "StckPriceDayTotalZai";
        /// <summary> 返品金額日計(在庫) </summary>
        public const string ct_Col_RetGdsDayTotalZai = "RetGdsDayTotalZai";
        /// <summary> 値引金額日計(在庫) </summary>
        public const string ct_Col_DisDayTotalZai = "DisDayTotalZai";
        /// <summary> 純仕入額日計(在庫) </summary>
        public const string ct_Col_NetStcPrcDayTotalZai = "NetStcPrcDayTotalZai";

        /// <summary> 仕入金額月計(在庫) </summary>
        public const string ct_Col_StckPriceMonthTotalZai = "StckPriceMonthTotalZai";
        /// <summary> 返品金額月計(在庫) </summary>
        public const string ct_Col_RetGdsMonthTotalZai = "RetGdsMonthTotalZai";
        /// <summary> 値引金額月計(在庫) </summary>
        public const string ct_Col_DisDayMonthTotalZai = "DisDayMonthTotalZai";
        /// <summary> 純仕入額月計(在庫) </summary>
        public const string ct_Col_NetStcPrcMonthTotalZai = "NetStcPrcMonthTotalZai";

        /// <summary> 仕入金額日計(取寄) </summary>
        public const string ct_Col_StckPriceDayTotalTori = "StckPriceDayTotalTori";
        /// <summary> 返品金額日計(取寄) </summary>
        public const string ct_Col_RetGdsDayTotalTori = "RetGdsDayTotalTori";
        /// <summary> 値引金額日計(取寄) </summary>
        public const string ct_Col_DisDayTotalTori = "DisDayTotalTori";
        /// <summary> 純仕入額日計(取寄) </summary>
        public const string ct_Col_NetStcPrcDayTotalTori = "NetStcPrcDayTotalTori";

        /// <summary> 仕入金額月計(取寄) </summary>
        public const string ct_Col_StckPriceMonthTotalTori = "StckPriceMonthTotalTori";
        /// <summary> 返品金額月計(取寄) </summary>
        public const string ct_Col_RetGdsMonthTotalTori = "RetGdsMonthTotalTori";
        /// <summary> 値引金額月計(取寄) </summary>
        public const string ct_Col_DisDayMonthTotalTori = "DisDayMonthTotalTori";
        /// <summary> 純仕入額月計(取寄) </summary>
        public const string ct_Col_NetStcPrcMonthTotalTori = "NetStcPrcMonthTotalTori";

        /// <summary> 在庫比率日計(合計) </summary>
        public const string ct_Col_StckZaiRatioDayTotalGou = "StckZaiRatioDayTotalGou";
        /// <summary> 取寄比率日計(合計) </summary>
        public const string ct_Col_StckToriRatioDayTotalGou = "StckToriRatioDayTotalGou";
        /// <summary> 仕入金額日計(合計) </summary>
        public const string ct_Col_StckPriceDayTotalGou = "StckPriceDayTotalGou";
        /// <summary> 返品金額日計(合計) </summary>
        public const string ct_Col_RetGdsDayTotalGou = "RetGdsDayTotalGou";
        /// <summary> 値引金額日計(合計) </summary>
        public const string ct_Col_DisDayTotalGou = "DisDayTotalGou";
        /// <summary> 純仕入額日計(合計) </summary>
        public const string ct_Col_NetStcPrcDayTotalGou = "NetStcPrcDayTotalGou";

        /// <summary> 在庫比率月計(合計) </summary>
        public const string ct_Col_StckZaiRatioMonthTotalGou = "StckZaiRatioMonthTotalGou";
        /// <summary> 取寄比率月計(合計) </summary>
        public const string ct_Col_StckToriRatioMonthTotalGou = "StckToriRatioMonthTotalGou";
        /// <summary> 仕入金額月計(合計) </summary>
        public const string ct_Col_StckPriceMonthTotalGou = "StckPriceMonthTotalGou";
        /// <summary> 返品金額月計(合計) </summary>
        public const string ct_Col_RetGdsMonthTotalGou = "RetGdsMonthTotalGou";
        /// <summary> 値引金額月計(合計) </summary>
        public const string ct_Col_DisDayMonthTotalGou = "DisDayMonthTotalGou";
        /// <summary> 純仕入額月計(合計) </summary>
        public const string ct_Col_NetStcPrcMonthTotalGou = "NetStcPrcMonthTotalGou";
        // --- ADD 2008/08/08 --------------------------------<<<<< 

		/// <summary> 明細コード </summary>
		public const string ct_Col_DetailLine = "DetailLine";
		/// <summary> 明細名 </summary>
		public const string ct_Col_DetailLineName = "DetailLineName";

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫・倉庫移動確認表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public DCKOU02105EA()
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
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.14</br>
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
				dt = new DataTable(ct_Tbl_StockDayMonthReportData);

				dt.Columns.Add(ct_Col_SectionCode, typeof(string));	    // 拠点コード
				dt.Columns[ct_Col_SectionCode].DefaultValue = "";
				dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));	// 拠点ガイド名称
				dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));	 // 得意先コード
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_CustomerName, typeof(string));	 // 得意先名称
                //dt.Columns[ct_Col_CustomerName].DefaultValue = "";
                //dt.Columns.Add(ct_Col_CustomerName2, typeof(string));  // 得意先名称2
                //dt.Columns[ct_Col_CustomerName2].DefaultValue = "";
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_SupplierCode, typeof(Int32));	    // 仕入先コード
                dt.Columns[ct_Col_SupplierCode].DefaultValue = 0;
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));	    // 仕入先名称
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
                // --- ADD 2008/08/08 --------------------------------<<<<< 

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));    // 仕入担当者コード
                //dt.Columns[ct_Col_StockAgentCode].DefaultValue = "";
                //dt.Columns.Add(ct_Col_StockAgentName, typeof(string));    // 仕入担当者名称
                //dt.Columns[ct_Col_StockAgentName].DefaultValue = "";

                //dt.Columns.Add(ct_Col_StckPriceDayTotal, typeof(Int64));  // 仕入金額日計
                //dt.Columns[ct_Col_StckPriceDayTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_RetGdsDayTotal, typeof(Int64));	  // 返品金額日計
                //dt.Columns[ct_Col_RetGdsDayTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_DisDayTotal, typeof(Int64));        // 値引金額日計
                //dt.Columns[ct_Col_DisDayTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_NetStcPrcDayTotal, typeof(Int64));  // 純仕入額日計
                //dt.Columns[ct_Col_NetStcPrcDayTotal].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_RetGdsDayRate, typeof(double));  // 返品率日計
                //dt.Columns[ct_Col_RetGdsDayRate].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_DisDayRate, typeof(double));     // 値引率日計
                //dt.Columns[ct_Col_DisDayRate].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_StckPriceMonthTotal, typeof(Int64));	// 仕入金額月計
                //dt.Columns[ct_Col_StckPriceMonthTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_RetGdsMonthTotal, typeof(Int64));     // 返品金額月計
                //dt.Columns[ct_Col_RetGdsMonthTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_DisDayMonthTotal, typeof(Int64));     // 値引金額月計
                //dt.Columns[ct_Col_DisDayMonthTotal].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_NetStcPrcMonthTotal, typeof(Int64));  // 純仕入額月計
                //dt.Columns[ct_Col_NetStcPrcMonthTotal].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_RetGdsMonthRate, typeof(double));  // 返品率月計
                //dt.Columns[ct_Col_RetGdsMonthRate].DefaultValue = 0;
                //dt.Columns.Add(ct_Col_DisDayMonthRate, typeof(double));  // 値引率月計
                //dt.Columns[ct_Col_DisDayMonthRate].DefaultValue = 0;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_StckPriceDayTotalZai, typeof(Int64));     // 仕入金額日計(在庫)
                dt.Columns[ct_Col_StckPriceDayTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsDayTotalZai, typeof(Int64));	    // 返品金額日計(在庫)
                dt.Columns[ct_Col_RetGdsDayTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayTotalZai, typeof(Int64));           // 値引金額日計(在庫)
                dt.Columns[ct_Col_DisDayTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcDayTotalZai, typeof(Int64));     // 純仕入額日計(在庫)
                dt.Columns[ct_Col_NetStcPrcDayTotalZai].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StckPriceMonthTotalZai, typeof(Int64));	// 仕入金額月計(在庫)
                dt.Columns[ct_Col_StckPriceMonthTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsMonthTotalZai, typeof(Int64));      // 返品金額月計(在庫)
                dt.Columns[ct_Col_RetGdsMonthTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayMonthTotalZai, typeof(Int64));      // 値引金額月計(在庫)
                dt.Columns[ct_Col_DisDayMonthTotalZai].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcMonthTotalZai, typeof(Int64));   // 純仕入額月計(在庫)
                dt.Columns[ct_Col_NetStcPrcMonthTotalZai].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StckPriceDayTotalTori, typeof(Int64));     // 仕入金額日計(取寄)
                dt.Columns[ct_Col_StckPriceDayTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsDayTotalTori, typeof(Int64));	     // 返品金額日計(取寄)
                dt.Columns[ct_Col_RetGdsDayTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayTotalTori, typeof(Int64));           // 値引金額日計(取寄)
                dt.Columns[ct_Col_DisDayTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcDayTotalTori, typeof(Int64));     // 純仕入額日計(取寄)
                dt.Columns[ct_Col_NetStcPrcDayTotalTori].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StckPriceMonthTotalTori, typeof(Int64));	 // 仕入金額月計(取寄)
                dt.Columns[ct_Col_StckPriceMonthTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsMonthTotalTori, typeof(Int64));      // 返品金額月計(取寄)
                dt.Columns[ct_Col_RetGdsMonthTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayMonthTotalTori, typeof(Int64));      // 値引金額月計(取寄)
                dt.Columns[ct_Col_DisDayMonthTotalTori].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcMonthTotalTori, typeof(Int64));   // 純仕入額月計(取寄)
                dt.Columns[ct_Col_NetStcPrcMonthTotalTori].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StckZaiRatioDayTotalGou, typeof(double));     // 在庫比率日計(合計)
                dt.Columns[ct_Col_StckZaiRatioDayTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_StckToriRatioDayTotalGou, typeof(double));    // 取寄比率日計(合計)
                dt.Columns[ct_Col_StckToriRatioDayTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_StckPriceDayTotalGou, typeof(Int64));        // 仕入金額日計(合計)
                dt.Columns[ct_Col_StckPriceDayTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsDayTotalGou, typeof(Int64));	       // 返品金額日計(合計)
                dt.Columns[ct_Col_RetGdsDayTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayTotalGou, typeof(Int64));              // 値引金額日計(合計)
                dt.Columns[ct_Col_DisDayTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcDayTotalGou, typeof(Int64));        // 純仕入額日計(合計)
                dt.Columns[ct_Col_NetStcPrcDayTotalGou].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StckZaiRatioMonthTotalGou, typeof(double));   // 在庫比率月計(合計)
                dt.Columns[ct_Col_StckZaiRatioMonthTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_StckToriRatioMonthTotalGou, typeof(double));  // 取寄比率月計(合計)
                dt.Columns[ct_Col_StckToriRatioMonthTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_StckPriceMonthTotalGou, typeof(Int64));	   // 仕入金額月計(合計)
                dt.Columns[ct_Col_StckPriceMonthTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_RetGdsMonthTotalGou, typeof(Int64));         // 返品金額月計(合計)
                dt.Columns[ct_Col_RetGdsMonthTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DisDayMonthTotalGou, typeof(Int64));         // 値引金額月計(合計)
                dt.Columns[ct_Col_DisDayMonthTotalGou].DefaultValue = 0;
                dt.Columns.Add(ct_Col_NetStcPrcMonthTotalGou, typeof(Int64));      // 純仕入額月計(合計)
                dt.Columns[ct_Col_NetStcPrcMonthTotalGou].DefaultValue = 0;
                // --- ADD 2008/08/08 --------------------------------<<<<< 

				dt.Columns.Add(ct_Col_DetailLine, typeof(string));
				dt.Columns[ct_Col_DetailLine].DefaultValue = "";
				dt.Columns.Add(ct_Col_DetailLineName, typeof(string));
				dt.Columns[ct_Col_DetailLineName].DefaultValue = "";
			}
		}
		#endregion
		#endregion
	}
}

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 回線エラーリスト テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 回線エラーリスト テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/11/04</br>
    /// <br>           : </br>
	/// </remarks>
	public class PMUOE02013EA
	{
		#region ■ Public Const
        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_CircuitErrorList = "Tbl_CircuitErrorList";

        /// <summary> システム区分名称 </summary>
        public const string ct_Col_SystemDivName = "SystemDivName";
        /// <summary> UOE発注先コード </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> 発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> オンライン番号 </summary>
        public const string ct_Col_OnlineNo = "OnlineNo";
        /// <summary> オンライン行番号 </summary>
        public const string ct_Col_OnlineRowNo = "OnlineRowNo";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> BO区分 </summary>
        public const string ct_Col_BOCode = "BOCode";
        /// <summary> UOEリマーク1 </summary>
        public const string ct_Col_UOERemark1 = "UOERemark1";
        /// <summary> エラー内容 </summary>
        public const string ct_Col_ErrorContents = "ErrorContents";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/04</br>
		/// </remarks>
		public PMUOE02013EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 帳票用DataSetテーブルスキーマ設定
		/// <summary>
		/// 帳票用DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 帳票用データセットのスキーマを設定する。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/04</br>
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
                dt = new DataTable(ct_Tbl_CircuitErrorList);

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                double defaultValueOfDouble = 0;

                // システム区分名称
                dt.Columns.Add(ct_Col_SystemDivName, typeof(string));
                dt.Columns[ct_Col_SystemDivName].DefaultValue = defaultValueOfstring;

                // UOE発注先コード
                dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
                dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defaultValueOfInt32;

                // UOE発注先名称
                dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
                dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;

                // オンライン番号
                dt.Columns.Add(ct_Col_OnlineNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineNo].DefaultValue = defaultValueOfInt32;

                // オンライン行番号
                dt.Columns.Add(ct_Col_OnlineRowNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineRowNo].DefaultValue = defaultValueOfInt32;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfInt32;

                // 受注数量
                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(double));
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;

                // BO区分
                dt.Columns.Add(ct_Col_BOCode, typeof(string));
                dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfstring;

                // UOEリマーク1
                dt.Columns.Add(ct_Col_UOERemark1, typeof(string));
                dt.Columns[ct_Col_UOERemark1].DefaultValue = defaultValueOfstring;

                // エラー内容
                dt.Columns.Add(ct_Col_ErrorContents, typeof(string));
                dt.Columns[ct_Col_ErrorContents].DefaultValue = defaultValueOfstring;
            }
		}
		#endregion
		#endregion
	}
}

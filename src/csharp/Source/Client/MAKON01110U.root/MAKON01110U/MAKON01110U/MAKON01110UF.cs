using System;
using System.Collections;
using System.IO;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 列表示状態クラスコレクションクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスのコレクションクラスです。</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2008.05.21</br>
    /// </remarks>
    internal class ColDisplayStatusList
	{
		//-----------------------------------------------------------
		// コンストラクタ
		//-----------------------------------------------------------
		#region ■Constructor
		/// <summary>
		/// 列表示状態クラスコレクションクラスコンストラクタ
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatusクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public ColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList, StockInputDataSet.StockDetailDataTable stockDetailDataTable)
		{
			// 各種インスタンス化
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
			this._colDisplayStatusKeyList = new List<string>();
			this._stockDetailDataTable = stockDetailDataTable;
			this._colDisplayStatusTable = new DataTable();

			// 表示固定列リスト生成
			this._visibleFixedColList = new List<string>();
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);		// 行番号
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);					// 商品コード
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);				// 商品名称
			this._visibleFixedColList.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName);			// メーカー
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName);		// 数量(表示)
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName);	// 単価(表示)
			this._visibleFixedColList.Add(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName);		// 仕入金額(表示)

			// 入力固定列リスト生成
			this._enterStopFixedColList = new List<string>();
			this._enterStopFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);     // 行番号
			this._enterStopFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);               // 商品コード
			this._enterStopFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);             // 商品名称
			this._enterStopFixedColList.Add(this._stockDetailDataTable.OpenPriceColumn.ColumnName);             // OP
            this._enterStopFixedColList.Add(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName);     // 数量(表示)
            this._enterStopFixedColList.Add(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName);      // 棚番
			this._enterStopFixedColList.Add(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName); // 現在庫数
			this._enterStopFixedColList.Add(this._stockDetailDataTable.MemoExistColumn.ColumnName);             // メモ
            //this._enterStopFixedColList.Add(this._stockDetailDataTable.OrderNumberColumn.ColumnName);           // 発注番号
            //this._enterStopFixedColList.Add(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName);		// 売上

			// ヘッダ固定リスト
			//int headervisiblePosition = 0;
			//this._headerFixedColList = new Dictionary<string, int>();
			this._headerFixedColList = new List<string>();
			this._headerFixedColList.Add(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName);	// 行番号
			this._headerFixedColList.Add(this._stockDetailDataTable.GoodsNoColumn.ColumnName);				// 商品コード
            //this._headerFixedColList.Add(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName);				// メーカーコード
            //this._headerFixedColList.Add(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName);				// BLコード
            this._headerFixedColList.Add(this._stockDetailDataTable.GoodsNameColumn.ColumnName);			// 商品名称

			// 初期列表示状態リスト生成
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;

			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockRowNoDisplayColumn.ColumnName, visiblePosition++, true, 44, true, true, false));		// №
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 130, false, true, true));				// 商品    
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 45, false, true, false));		// メーカーコード
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 53, false, true, false));			// BLコード
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, 140, false, true, true));			// 商品名
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 45, false, true, false));        // メーカーコード
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 53, false, true, false));         // BLコード
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, 90, false, true, false));	// 定価
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.OpenPriceColumn.ColumnName, visiblePosition++, false, 38, false, true, false));			// OP
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockCountDisplayColumn.ColumnName, visiblePosition++, false, 65, false, true, true));	// 数量
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockRateColumn.ColumnName, visiblePosition++, false, 60, false, true, false));			// 仕入率
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName, visiblePosition++, false, 90, false, true, true));// 単価（表示用）
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName, visiblePosition++, false, 105, false, true, true));	// 仕入金額（表示用）
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 45, false, true, true));		// 倉庫
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 65, false, true, false));	// 棚番
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.ShipmentPosCntDisplayColumn.ColumnName, visiblePosition++, false, 65, false, true, false));// 現在庫数
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.StockDtiSlipNote1Column.ColumnName, visiblePosition++, false, 366, false, true, true));	// 仕入伝票明細備考1
			initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.SalesCustomerCodeColumn.ColumnName, visiblePosition++, false, 76, false, true, true));	// 得意先
            //initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.OrderNumberColumn.ColumnName, visiblePosition++, false, 70, false, false, false));		// 発注番号
            initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.MemoExistColumn.ColumnName, visiblePosition++, false, 38, false, true, false));			// メモ
			//initStatusList.Add(new ColDisplayStatusExp(this._stockDetailDataTable.SalesInfoExistColumn.ColumnName, visiblePosition++, false, 40, false, true, false));		// 売上

			// 初期列表示状態リスト格納処理
			foreach (ColDisplayStatusExp initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
			if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
			{
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					ColDisplayStatusExp colDisplayStatus = null;

					try
					{
						colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
					}
					catch (KeyNotFoundException)
					{
						//
					}

					if (colDisplayStatus != null)
					{
						this._colDisplayStatusList.Add(colDisplayStatus);
					}
				}

				// 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
				this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
			}
			else
			{
				// 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
				this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

				// 初期列表示状態リストと列表示状態クラス格納Dictionaryの値を比較し、不足分を補充する
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					if (!this.ContainsKey(colKey))
					{
						ColDisplayStatusExp colDisplayStatus = null;

						try
						{
							colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
						}
						catch (KeyNotFoundException)
						{
							//
						}

						if (colDisplayStatus != null)
						{
							colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
							this.Add(colDisplayStatus);
						}
					}
					else
					{
						ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colKey);
						if (this._headerFixedColList.Contains(colKey))
						{
							colDisplayStatusExp.HeaderFixed = true;
							colDisplayStatusExp.VisiblePosition = _headerFixedColList.IndexOf(colKey);
						}
						else
						{
							colDisplayStatusExp.HeaderFixed = false;
						}
					}

					// テーブルに含まれない項目はリストから削除（明細を減らしてもエラーにさせない）
					if (!stockDetailDataTable.Columns.Contains(colKey))
					{
						if (this.ContainsKey(colKey))
						{
							ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colKey);
							if (colDisplayStatusExp != null)
							{
								this.Remove(colDisplayStatusExp);
							}
						}
					}
				}
			}

			// 表示位置によるソート処理
			this.Sort();
		}
		#endregion

		//-----------------------------------------------------------
		// プライベート変数
		//-----------------------------------------------------------
		#region ■Private Members
		/// <summary>列表示状態クラスリスト</summary>
		private List<ColDisplayStatusExp> _colDisplayStatusList = null;

		/// <summary>列表示状態クラス格納Dictionary</summary>
		private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

		/// <summary>初期列表示状態クラス格納Dictionary</summary>
		private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

		/// <summary>列表示状態キーリスト</summary>
		private List<string> _colDisplayStatusKeyList = null;

		/// <summary>仕入明細データテーブル</summary>
		StockInputDataSet.StockDetailDataTable _stockDetailDataTable;

		/// <summary>列表示状態クラステーブル</summary>
		private DataTable _colDisplayStatusTable;

		/// <summary>表示固定列リスト</summary>
		private List<string> _visibleFixedColList;

		/// <summary>Enter入力固定列リスト</summary>
		private List<string> _enterStopFixedColList;

		/// <summary>表示固定列リスト</summary>
		private List<string> _headerFixedColList;
		//private Dictionary<string,int> _headerFixedColList;
		
		#endregion

		//-----------------------------------------------------------
		// パブリックメソッド
		//-----------------------------------------------------------
		#region ■Public Methods
		/// <summary>
        /// 列表示状態キー格納判断処理
        /// </summary>
        /// <param name="key">対象列表示状態キー</param>
        /// <returns>列表示状態の有無(true:有,false:無)</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public bool ContainsKey( string key )
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

		/// <summary>
		/// 列表示状態キー格納判断処理
		/// </summary>
		/// <param name="key">対象列表示状態キー</param>
		/// <returns>列表示状態の有無(true:有,false:無)</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public ColDisplayStatusExp GetColDisplayStatus( string key )
		{
			if (this.ContainsKey(key))
			{
				foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusList)
				{
					if (colDisplayStatusExp.Key == key)
					{
						//return this._colDisplayStatusDictionary[key];
						return colDisplayStatusExp;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// 列表示テーブル取得
		/// </summary>
		/// <returns></returns>
		public List<ColDisplayInfo> GetColDisplayInfoList()
		{
			List<ColDisplayInfo> colDisplayInfoList = new List<ColDisplayInfo>();
			foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusList)
			{
				if (colDisplayStatusExp.ReadOnly == false)
				{
					colDisplayInfoList.Add(ColDisplayInfoFromColDisplayStatus(colDisplayStatusExp));
				}
			}
			return colDisplayInfoList;
		}

		/// <summary>
		/// 列表示テーブル取得
		/// </summary>
		/// <returns></returns>
		public List<ColDisplayInfo> GetColDisplayInfoInitList()
		{
			List<ColDisplayInfo> colDisplayInfoList = new List<ColDisplayInfo>();
			foreach (ColDisplayStatusExp colDisplayStatusExp in this._colDisplayStatusInitDictionary.Values)
			{
				if (colDisplayStatusExp.ReadOnly == false)
				{
					colDisplayInfoList.Add(ColDisplayInfoFromColDisplayStatus(colDisplayStatusExp));
				}
			}
			return colDisplayInfoList;
		}
		/// <summary>
		/// 列表示テーブルより列表示状態クラスリストにセットします。
		/// </summary>
		/// <param name="colDisplayInfoList"></param>
		public void SetColDisplayStatusListFromColDisplayInfoList( List<ColDisplayInfo> colDisplayInfoList )
		{
			foreach (ColDisplayInfo colDisplayInfo in colDisplayInfoList)
			{
				if (this.ContainsKey(colDisplayInfo.Key))
				{
					ColDisplayStatusExp colDisplayStatusExp = this.GetColDisplayStatus(colDisplayInfo.Key);
					colDisplayStatusExp.VisiblePosition = colDisplayInfo.VisiblePosition;
					colDisplayStatusExp.EnterStop = colDisplayInfo.EnterStop;
					colDisplayStatusExp.Visible = colDisplayInfo.Visible;
				}
			}
			this.Sort();
		}

        /// <summary>
        /// 並べ替え処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト取得処理
        /// </summary>
		/// <returns>ColDisplayStatusExpクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // 表示位置によるソート処理
            this.Sort();

            return this._colDisplayStatusList;
        }

		/// <summary>
		/// 列表示状態クラスリスト設定処理
		/// </summary>
		/// <param name="colDisplayStatusList">設定するColDisplayStatusExpクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを設定します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void SetColDisplayStatusList( List<ColDisplayStatusExp> colDisplayStatusList,bool saveHidden )
		{
			foreach (ColDisplayStatusExp colDisplayStatusExp in colDisplayStatusList)
			{
				if (this.ContainsKey(colDisplayStatusExp.Key))
				{
					colDisplayStatusExp.ReadOnly = this.GetColDisplayStatus(colDisplayStatusExp.Key).ReadOnly;
					colDisplayStatusExp.EnterStop = this.GetColDisplayStatus(colDisplayStatusExp.Key).EnterStop;
					if (!saveHidden)
					{
						colDisplayStatusExp.Visible = this.GetColDisplayStatus(colDisplayStatusExp.Key).Visible;
					}
				}
			}

			this._colDisplayStatusList = colDisplayStatusList;

			// 表示位置によるソート処理
			this.Sort();
		}
		
		/// <summary>
		/// 列表示状態クラスのReadOnlyプロパティを設定します。
		/// </summary>
		/// <param name="key">列表示状態クラスキー</param>
		/// <param name="readOnly">ReadOnlyプロパティ</param>
		public void SetColDisplayStatusReadOnly( string key, bool readOnly )
		{
		}

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
		/// <param name="displayStatusList">シリアライズ対象ColDisplayStatusExpクラスリストのインスタンス</param>
        /// <param name="fileName">シリアライズ先ファイル名称</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public static void Serialize( List<ColDisplayStatusExp> colDisplayStatusList, string fileName )
        {
			ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ元ファイル名称</param>
		/// <returns>デシリアライズされたColDisplayStatusExpクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		public static List<ColDisplayStatusExp> Deserialize( string fileName )
        {
			List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

					foreach (ColDisplayStatusExp colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

		//-----------------------------------------------------------
		// プライベートメソッド
		//-----------------------------------------------------------
		#region ■Private Methods
        /// <summary>
        /// 列表示状態クラス追加処理
        /// </summary>
		/// <param name="colDisplayStatus">追加するColDisplayStatusExpクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private void Add( ColDisplayStatusExp colDisplayStatus )
        {
            // 既に同一キーが存在する場合は処理しない
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラス削除処理
        /// </summary>
		/// <param name="colDisplayStatus">削除するColDisplayStatusExpクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private void Remove( ColDisplayStatusExp colDisplayStatus )
        {
            // 同一キーが存在しない場合は処理しない
            if (!( this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) ))
            {
                return;
            }

			ColDisplayStatusExp status = null;

            try
            {
                status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
            }
            catch (KeyNotFoundException)
            {
                //
            }

            if (status == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(status);
            this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト⇒Dictionary格納処理
        /// </summary>
		/// <param name="colDisplayStatusList">格納するColDisplayStatusExpクラスのリストのインスタンス</param>
        /// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
		private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList( List<ColDisplayStatusExp> colDisplayStatusList )
        {
			Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

			foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }

		/// <summary>
		/// 列表示状態クラス→列情報クラス格納処理
		/// </summary>
		/// <param name="colDisplayStatus"></param>
		/// <returns></returns>
		private ColDisplayInfo ColDisplayInfoFromColDisplayStatus( ColDisplayStatusExp colDisplayStatus )
		{
			ColDisplayInfo colDisplayInfo = new ColDisplayInfo();

			colDisplayInfo.Key = colDisplayStatus.Key;
			colDisplayInfo.FixedCol = colDisplayStatus.HeaderFixed;
			colDisplayInfo.Visible = colDisplayStatus.Visible;
			colDisplayInfo.VisiblePosition = colDisplayStatus.VisiblePosition;
			colDisplayInfo.EnterStop = colDisplayStatus.EnterStop;
			colDisplayInfo.VisibleControl = !( _visibleFixedColList.Contains(colDisplayStatus.Key) );
			colDisplayInfo.EnterStopControl = !( _enterStopFixedColList.Contains(colDisplayStatus.Key) );

			if (this._stockDetailDataTable.Columns.Contains(colDisplayStatus.Key))
			{
				colDisplayInfo.Caption = this._stockDetailDataTable.Columns[colDisplayStatus.Key].Caption;
			}

			return colDisplayInfo;
		}

        #endregion
	}
}
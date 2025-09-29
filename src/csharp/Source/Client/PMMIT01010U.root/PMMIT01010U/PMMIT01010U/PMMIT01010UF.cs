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
		#region Constructor
		/// <summary>
		/// 列表示状態クラスコレクションクラスコンストラクタ
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatusクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024　佐々木　健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public ColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList, EstimateInputDataSet.EstimateDetailDataTable stockDetailDataTable )
		{
			// 各種インスタンス化
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusKeyList = new List<string>();
			this._estimateDetailDataTable = stockDetailDataTable;

			// 初期列表示状態リスト生成
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.SalesRowNoDisplayColumn.ColumnName, visiblePosition++, true, 35));			// №
			// 純正情報
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 54));                 // BLコード
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, false, 140));                  // 商品名
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, false, 140));                    // 品番
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 48));                // メーカーコード
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, false, 100));                  // メーカー名称
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, false, 54));                 // QTY
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, 90));			// 定価
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, false, 30));			// OP
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 45));               // 倉庫
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 72));            // 棚番
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, false, 55));              // 現在庫数
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, visiblePosition++, false, 42));         // セット
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, false, 58));                  // 仕入先
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, false, 42));                 // 印刷
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, false, 42));                 // 発注
			// 優良情報
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, visiblePosition++, false, 54));           // BLコード（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, visiblePosition++, false, 140));            // 商品名（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, false, 140));              // 品番（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, false, 48));          // メーカーコード（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, false, 100));			// メーカー名称（優良）
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, false, 54));           // QTY（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, false, 90));      // 定価（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, false, 30));   // OP（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, visiblePosition++, false, 45));         // 倉庫（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, false, 72));      // 棚番（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, false, 55));        // 現在庫数（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, visiblePosition++, false, 42));   // セット（優良）
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, visiblePosition++, false, 58));            // 仕入先（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, false, 42));           // 印刷（優良）
			initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, visiblePosition++, false, 42));           // 発注（優良）
			// その他
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName, visiblePosition++, false, 140));       // 結合元品番
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName, visiblePosition++, false, 140));                // カタログ品番
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.StandardNameColumn.ColumnName, visiblePosition++, false, 200));               // 規格
            initStatusList.Add(new ColDisplayStatus(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName, visiblePosition++, false, 200));                // 特記事項

			// 初期列表示状態リスト格納処理
			foreach (ColDisplayStatus initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
			if (( this._colDisplayStatusList == null ) || ( this._colDisplayStatusList.Count == 0 ))
			{
				foreach (string colKey in this._colDisplayStatusKeyList)
				{
					ColDisplayStatus colDisplayStatus = null;

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
						ColDisplayStatus colDisplayStatus = null;

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
				}
			}

			// 表示位置によるソート処理
			this.Sort();
		}
		#endregion

		#region Private Members
		/// <summary>列表示状態クラスリスト</summary>
		private List<ColDisplayStatus> _colDisplayStatusList = null;

		/// <summary>列表示状態クラス格納Dictionary</summary>
		private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;

		/// <summary>初期列表示状態クラス格納Dictionary</summary>
		private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;

		/// <summary>列表示状態キーリスト</summary>
		private List<string> _colDisplayStatusKeyList = null;

		/// <summary>仕入明細データテーブル</summary>
		EstimateInputDataSet.EstimateDetailDataTable _estimateDetailDataTable;
		#endregion

		#region Public Methods
		/// <summary>
		/// 列表示状態キー格納判断処理
		/// </summary>
		/// <param name="key">対象列表示状態キー</param>
		/// <returns>列表示状態の有無(true:有,false:無)</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public bool ContainsKey( string key )
		{
			return this._colDisplayStatusDictionary.ContainsKey(key);
		}

		/// <summary>
		/// 並べ替え処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public void Sort()
		{
			this._colDisplayStatusList.Sort();
		}

		/// <summary>
		/// 列表示状態クラスリスト取得処理
		/// </summary>
		/// <returns>ColDisplayStatusクラスリストのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを取得します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public List<ColDisplayStatus> GetColDisplayStatusList()
		{
			// 表示位置によるソート処理
			this.Sort();

			return this._colDisplayStatusList;
		}

		/// <summary>
		/// 列表示状態クラスリスト設定処理
		/// </summary>
		/// <param name="colDisplayStatusList">設定するColDisplayStatusクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを設定します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public void SetColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList )
		{
			this._colDisplayStatusList = colDisplayStatusList;

			// 表示位置によるソート処理
			this.Sort();
		}

		/// <summary>
		/// 列表示状態クラスリストシリアライズ処理
		/// </summary>
		/// <param name="displayStatusList">シリアライズ対象ColDisplayStatusクラスリストのインスタンス</param>
		/// <param name="fileName">シリアライズ先ファイル名称</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public static void Serialize( List<ColDisplayStatus> colDisplayStatusList, string fileName )
		{
			ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
			colDisplayStatusList.CopyTo(colDisplayStatusArray);

			UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
		}

		/// <summary>
		/// 列表示状態クラスリストデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ元ファイル名称</param>
		/// <returns>デシリアライズされたColDisplayStatusクラスリストのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public static List<ColDisplayStatus> Deserialize( string fileName )
		{
			List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
			{
				try
				{
					ColDisplayStatus[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

					foreach (ColDisplayStatus colDisplayStatus in retArray)
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

		#region Private Methods
		/// <summary>
		/// 列表示状態クラス追加処理
		/// </summary>
		/// <param name="colDisplayStatus">追加するColDisplayStatusクラスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private void Add( ColDisplayStatus colDisplayStatus )
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
		/// <param name="colDisplayStatus">削除するColDisplayStatusクラスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private void Remove( ColDisplayStatus colDisplayStatus )
		{
			// 同一キーが存在しない場合は処理しない
			if (!( this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) ))
			{
				return;
			}

			ColDisplayStatus status = null;

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
		/// <param name="colDisplayStatusList">格納するColDisplayStatusクラスのリストのインスタンス</param>
		/// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList( List<ColDisplayStatus> colDisplayStatusList )
		{
			Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

			foreach (ColDisplayStatus status in colDisplayStatusList)
			{
				retDictionary.Add(status.Key, status);
			}

			return retDictionary;
		}
		#endregion
	}
}

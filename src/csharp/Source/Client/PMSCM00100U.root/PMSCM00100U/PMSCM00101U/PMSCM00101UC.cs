using System;
using System.Collections;
using System.IO;
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
	/// <br>Programmer : 980076 妻鳥 謙一郎</br>
	/// <br>Date       : 2006.06.21</br>
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
		/// <br>Programmer : 980076 妻鳥 謙一郎</br>
		/// <br>Date       : 2006.06.21</br>
		/// </remarks>
		public ColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList, SimpleInqCTIDataSet.SalesSlipDataTable salesSlipDataTable)
		{
			// 各種インスタンス化
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusKeyList = new List<string>();
			this._salesSlipDataTable = salesSlipDataTable;

			// 初期列表示状態リスト生成
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SearchSlipNumColumn.ColumnName, visiblePosition++, true, 80));

			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DetailRowCountColumn.ColumnName, visiblePosition++, false, 80));
			
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSlipKindNameColumn.ColumnName, visiblePosition++, false, 60));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSlipCdNameColumn.ColumnName, visiblePosition++, false, 85));
#if False
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcptAnOdrStatusNameColumn.ColumnName, visiblePosition++, false, 80));
#endif
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesFormalNameColumn.ColumnName, visiblePosition++, false, 85));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SlipDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AddUpADateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesTotalTaxIncColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.FrontEmployeeNmColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesEmployeeNmColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CustomerCodeColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CustomerNameColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.EstimateDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcceptAnOrderDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DeliGdsCmpltDueDateStringColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ShipmentDayStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesDateStringColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DebitNoteDivNameColumn.ColumnName, visiblePosition++, false, 60));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.WayToOrderNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AccRecDivNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TotalAmountDispWayNameColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesTotalTaxExcColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxIncColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxExcColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalSubttlSubToTaxFreColumn.ColumnName, visiblePosition++, false, 150));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesSubtotalTaxColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TotalCostColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ServiceDepositsColumn.ColumnName, visiblePosition++, false, 130));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.TaxAdjustColumn.ColumnName, visiblePosition++, false, 110));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.BalanceAdjustColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DemandableTtlColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ClaimCodeColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ClaimNameColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SlipNoteColumn.ColumnName, visiblePosition++, false, 200));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CorporateDivCodeNameColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesGoodsCdNameColumn.ColumnName, visiblePosition++, false, 115));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.AcceptAnOrderNoColumn.ColumnName, visiblePosition++, false, 80));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.RegiProcDateStringColumn.ColumnName, visiblePosition++, false, 100));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.CashRegisterNoColumn.ColumnName, visiblePosition++, false, 90));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.PosReceiptNoColumn.ColumnName, visiblePosition++, false, 110));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.DemandAddUpSecNameColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.SalesInpSecNameColumn.ColumnName, visiblePosition++, false, 120));
			initStatusList.Add(new ColDisplayStatus(this._salesSlipDataTable.ResultsAddUpSecNameColumn.ColumnName, visiblePosition++, false, 120));

			// 初期列表示状態リスト格納処理
			foreach (ColDisplayStatus initStatus in initStatusList)
			{
				this._colDisplayStatusKeyList.Add(initStatus.Key);
				this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
			}

			// 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
			if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
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

		/// <summary>売上データテーブル</summary>
		private SimpleInqCTIDataSet.SalesSlipDataTable _salesSlipDataTable;
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
		public bool ContainsKey(string key)
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
		public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
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
		public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
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
		public static List<ColDisplayStatus> Deserialize(string fileName)
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
		private void Add(ColDisplayStatus colDisplayStatus)
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
		private void Remove(ColDisplayStatus colDisplayStatus)
		{
			// 同一キーが存在しない場合は処理しない
			if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
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
		private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
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
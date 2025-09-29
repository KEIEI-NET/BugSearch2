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
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/11/10</br>
	/// </remarks>
	internal class ColDisplayStatusList
	{
        #region ■定数、変数、構造体
        private List<ColDisplayStatus> _colDisplayStatusList = null;                            // 列表示状態クラスリスト
        private List<string> _colDisplayStatusKeyList = null;                                   // 列表示状態キーリスト
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;        // 列表示状態クラス格納Dictionary
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;    // 初期列表示状態クラス格納Dictionary
        #endregion

		#region ■Constructor
		/// <summary>
		/// 列表示状態クラスコレクションクラスコンストラクタ
		/// </summary>
		/// <param name="colDisplayStatusList">ColDisplayStatusクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public ColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList)
		{
			// 各種インスタンス化
			this._colDisplayStatusList = colDisplayStatusList;
			this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
			this._colDisplayStatusKeyList = new List<string>();

			// 初期列表示状態リスト生成
			List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

			int visiblePosition = 0;
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_No, visiblePosition++, false, 10));                     // No
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SelectFlg, visiblePosition++, true, 48));               // 選択
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ReceiveDate, visiblePosition++, false, 92));            // 受信日付
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ReceiveTime, visiblePosition++, false, 92));            // 受信時刻
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESalesOrderNo, visiblePosition++, false, 92));        // 発注番号
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESalesOrderRowNo, visiblePosition++, false, 108));    // 発注行番号
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESupplierCd, visiblePosition++, false, 108));         // 発注先コード
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESupplierName, visiblePosition++, false, 166));       // 発注先名称
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOEDeliGoodsDiv, visiblePosition++, false, 92));        // UOE納品区分
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_FollowDeliGoodsDiv, visiblePosition++, false, 124));    // フォロー納品区分
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOCode, visiblePosition++, false, 76));                 // BO区分
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EmployeeCode, visiblePosition++, false, 108));          // 依頼者コード
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EmployeeName, visiblePosition++, false, 166));          // 依頼者名称
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_CustomerCode, visiblePosition++, false, 108));          // 得意先コード
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_CustomerSnm, visiblePosition++, false, 166));           // 得意先名称
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsNo, visiblePosition++, false, 196));               // 品番
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsMakerCd, visiblePosition++, false, 60));           // メーカー
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_GoodsName, visiblePosition++, false, 166));             // 品名
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOERemark1, visiblePosition++, false, 166));            // リマーク1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOERemark2, visiblePosition++, false, 88));             // リマーク2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_AcceptAnOrderCnt, visiblePosition++, false, 92));       // 発注数量
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESectOutGoodsCnt, visiblePosition++, false, 108));    // 拠点出庫数
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESectionSlipNo, visiblePosition++, false, 124));      // 拠点伝票番号
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt1, visiblePosition++, false, 70));         // フォロー1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo1, visiblePosition++, false, 132));             // フォロー伝票番号1
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt2, visiblePosition++, false, 70));         // フォロー2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo2, visiblePosition++, false, 132));             // フォロー伝票番号2
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOShipmentCnt3, visiblePosition++, false, 70));         // フォロー3
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOSlipNo3, visiblePosition++, false, 132));             // フォロー伝票番号3
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MakerFollowCnt, visiblePosition++, false, 108));        // メーカーフォロー数
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_ListPrice, visiblePosition++, false, 96));              // 定価
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SalesUnitCost, visiblePosition++, false, 92));          // 仕切単価
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_UOESubstMark, visiblePosition++, false, 92));           // 代替区分
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_PartsLayerCd, visiblePosition++, false, 108));          // 層別(日産)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_BOManagementNo, visiblePosition++, false, 156));        // EO管理番号(日産)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_EOAlwcCount, visiblePosition++, false, 140));           // EO発注数(日産)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1, visiblePosition++, false, 140));   // 拠点コード(マツダ)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2, visiblePosition++, false, 146));   // フォローコード1(マツダ)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3, visiblePosition++, false, 146));   // フォローコード2(マツダ)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_LineErrorMessage, visiblePosition++, false, 320));      // エラーメッセージ
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SourceShipment, visiblePosition++, false, 156));        // 出荷元コード(ホンダ)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SectionCode, visiblePosition++, false, 10));            // 拠点コード(※帳票用項目)
            initStatusList.Add(new ColDisplayStatus(PMUOE04202EA.ct_Col_SectionName, visiblePosition++, false, 10));            // 拠点名称(※帳票用項目)

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
                    if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                    {
                        this._colDisplayStatusList.Add(this._colDisplayStatusInitDictionary[colKey]);
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
                        if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                        {
                            ColDisplayStatus colDisplayStatus = null;
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];

                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
					}
				}
			}

			// 表示位置によるソート処理
			this.Sort();
        }
        #endregion ■Constructor - end

        #region ■Public
        #region ▼GetColDisplayStatusList(列表示状態クラスリスト-取得)
        /// <summary>
		/// 列表示状態クラスリスト取得処理
		/// </summary>
		/// <returns>ColDisplayStatusクラスリストのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを取得します。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public List<ColDisplayStatus> GetColDisplayStatusList()
		{
			// 表示位置によるソート処理
			this.Sort();

			return this._colDisplayStatusList;
		}
        #endregion

        #region ▼SetColDisplayStatusList(列表示状態クラスリスト-設定)
        /// <summary>
		/// 列表示状態クラスリスト設定処理
		/// </summary>
		/// <param name="colDisplayStatusList">設定するColDisplayStatusクラスリストのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストを設定します。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public void SetColDisplayStatusList( List<ColDisplayStatus> colDisplayStatusList )
		{
			this._colDisplayStatusList = colDisplayStatusList;

			// 表示位置によるソート処理
			this.Sort();
        }
        #endregion

        #region ▼Serialize(列表示状態クラスリスト-シリアライズ)
        /// <summary>
		/// 列表示状態クラスリストシリアライズ処理
		/// </summary>
		/// <param name="displayStatusList">シリアライズ対象ColDisplayStatusクラスリストのインスタンス</param>
		/// <param name="fileName">シリアライズ先ファイル名称</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public static void Serialize( List<ColDisplayStatus> colDisplayStatusList, string fileName )
		{
			ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
			colDisplayStatusList.CopyTo(colDisplayStatusArray);

			UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }
        #endregion

        #region ▼Deserialize(列表示状態クラスリスト-デシリアライズ)
        /// <summary>
		/// 列表示状態クラスリストデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ元ファイル名称</param>
		/// <returns>デシリアライズされたColDisplayStatusクラスリストのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
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
        #endregion ■Public - end

        #region ■Private
        #region ▼Add(列表示状態クラス→列表示状態クラス格納Dicrionary追加)
        /// <summary>
		/// 列表示状態クラス追加処理
		/// </summary>
		/// <param name="colDisplayStatus">追加するColDisplayStatusクラスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
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
        #endregion

        #region ▼ContainsKey(列表示状態クラス格納Dictionary-対象キー有無判定)
        /// <summary>
        /// 列表示状態キー格納判断処理
        /// </summary>
        /// <param name="key">対象列表示状態キー</param>
        /// <returns>列表示状態の有無(true:有,false:無)</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }
        #endregion

        #region ▼Sort(列表示状態クラスリスト-並べ替え)
        /// <summary>
        /// 並べ替え処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Sort()
        {
            this._colDisplayStatusList.Sort();
        }
        #endregion

        #region ▼ToColStatusDictionaryFromColStatusList(列表示状態クラスリスト→Dictionaryデータコピー)
        /// <summary>
		/// 列表示状態クラスリスト→Dictionaryコピー処理
		/// </summary>
		/// <param name="colDisplayStatusList">格納するColDisplayStatusクラスのリストのインスタンス</param>
		/// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
		/// <remarks>
		/// <br>Note       : 列表示状態クラスリストのデータをDictionaryにコピーします。</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/10</br>
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
        #endregion ■Private - end
    }
}
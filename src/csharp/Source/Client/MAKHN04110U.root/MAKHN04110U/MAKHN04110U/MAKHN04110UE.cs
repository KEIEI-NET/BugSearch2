using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 商品入力抽出条件設定コレクションクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品入力の抽出条件設定クラスのコレクションクラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.9</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 對馬 大輔</br>
    /// <br>           : PM.NS対応(コメント無し)</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/13 30517 夏野 駿希</br>
    /// <br>           : 抽出条件・抽出結果データグリッドから品名カナを削除</br>
    /// </remarks>
	internal class GoodsExtractConditionItems : ExtractConditionItemsBase
	{
		#region Constructor

		/// <summary>
		/// 商品入力抽出条件設定コレクションクラスコンストラクタ
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件アイテムクラスリスト</param>
		/// <remarks>
		/// <br>Note       : 商品入力抽出条件設定コレクションクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public GoodsExtractConditionItems(List<ExtractConditionItem> extractConditionItemList)
			: base(extractConditionItemList)
		{
		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// 初期抽出条件設定クラスリスト設定追加処理
		/// </summary>
		/// <param name="initItemList">抽出条件設定クラスリスト</param>
		/// <remarks>
		/// <br>Note       : 初期抽出条件設定クラスリストに設定を追加します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		protected override void SetInitExtractConditionItemList( List<ExtractConditionItem> initItemList )
		{
			int itemNo = 0;

            initItemList.Add(new ExtractConditionItem(CT_ITEM_MAKER, ++itemNo, "メーカー", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSCODE, ++itemNo, "品番", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSNAME, ++itemNo, "品名", true));
            //initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSNAMEKANA, ++itemNo, "品名ｶﾅ", true));    // 2010/07/13 Del
			initItemList.Add(new ExtractConditionItem(CT_ITEM_LARGEGOODSGANRE, ++itemNo, "商品大分類", true));
			initItemList.Add(new ExtractConditionItem(CT_ITEM_MEDIUMGOODSGANRE, ++itemNo, "商品中分類", true));
			initItemList.Add(new ExtractConditionItem(CT_ITEM_DETAILGOODSGANRE, ++itemNo, "グループコード", true));
            initItemList.Add(new ExtractConditionItem(CT_ITEM_GOODSKINDCODE, ++itemNo, "商品属性", true));
		}

		#endregion
	}


	/// <summary>
	/// 抽出条件設定コレクション基底クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 抽出条件設定クラスのコレクションの基底クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.1.9</br>
	/// </remarks>
	internal class ExtractConditionItemsBase
	{
		#region Constructor

		/// <summary>
		/// 抽出条件設定コレクション基底クラスコンストラクタ
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件アイテムクラスリスト</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定コレクション基底クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public ExtractConditionItemsBase( List< ExtractConditionItem> extractConditionItemList )
		{
			// インスタンス初期化
			this._extractConditionItemList           = extractConditionItemList;
			this._extractConditionItemDictionary     = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionItemInitDictionary = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionKeyList            = new List<string>();

			// 初期抽出条件アイテムリスト作成
			List<ExtractConditionItem> initItemList = new List<ExtractConditionItem>();

			this.SetInitExtractConditionItemList( initItemList );

			foreach( ExtractConditionItem item in initItemList ) {
				this._extractConditionKeyList.Add( item.Key );
				this._extractConditionItemInitDictionary.Add( item.Key, item );
			}

			// 抽出条件設定クラスリストが無効の場合は、初期値を設定
			if( ( this._extractConditionItemList == null ) || ( this._extractConditionItemList.Count == 0 ) ) {
				foreach( string key in this._extractConditionKeyList ) {
					ExtractConditionItem item = null;

					try {
						item = this._extractConditionItemInitDictionary[ key ];
					}
					catch( KeyNotFoundException ) {
						// 
					}

					if( item != null ) {
						this._extractConditionItemList.Add( item );
					}
				}

				// 抽出条件設定クラス格納Dictionaryを最新の情報にて再生性
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList( this._extractConditionItemList );
			}
			else {
				// 抽出条件設定クラス格納Dictionaryを最新の情報にて再生性
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList( this._extractConditionItemList );

				// デフォルト値と引数の値を比較し、不足分を補充する
				foreach( string key in this._extractConditionKeyList ) {
					if( this.ContainsKey( key ) == false ) {
						ExtractConditionItem item = null;

						try {
							item = this._extractConditionItemInitDictionary[ key ];
						}
						catch( KeyNotFoundException ) {
							// 
						}

						if( item != null ) {
							item.No = this._extractConditionItemList.Count + 1;
							this.Add( item );
						}
					}
				}
			}

			this.Sort();
		}

		#endregion

		#region Constant

        /// <summary>メーカー</summary>
        public const string CT_ITEM_MAKER = "MakerCode";
        /// <summary>商品大分類</summary>
		public const string CT_ITEM_LARGEGOODSGANRE = "GoodsLGroup";
        /// <summary>商品中分類</summary>
        public const string CT_ITEM_MEDIUMGOODSGANRE = "GoodsMGroup";
        /// <summary>BLグループコード</summary>
        public const string CT_ITEM_DETAILGOODSGANRE = "BLGroupCode";
        /// <summary>品番</summary>
		public const string CT_ITEM_GOODSCODE = "GoodsNo";
        /// <summary>品名</summary>
        public const string CT_ITEM_GOODSNAME = "GoodsName";
        /// <summary>品名カナ</summary>
		public const string CT_ITEM_GOODSNAMEKANA = "GoodsNameKana";
		/// <summary>商品種別</summary>
		public const string CT_ITEM_GOODSKINDCODE = "GoodsKindCode";

		#endregion

		#region Private Members

		/// <summary>抽出条件設定クラスリスト</summary>
		private List<ExtractConditionItem>              _extractConditionItemList           = null;
		private Dictionary<string,ExtractConditionItem> _extractConditionItemDictionary     = null;
		private Dictionary<string,ExtractConditionItem> _extractConditionItemInitDictionary = null;
		private List<string>                            _extractConditionKeyList            = null;

		#endregion

		#region Protected Methods

		/// <summary>
		/// 初期抽出条件設定クラスリスト設定追加処理
		/// </summary>
		/// <param name="initItemList">抽出条件設定クラスリスト</param>
		/// <remarks>
		/// <br>Note       : 仮想メソッド。初期抽出条件設定クラスリストに設定を追加します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		protected virtual void SetInitExtractConditionItemList( List<ExtractConditionItem> initItemList )
		{
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// 抽出条件設定クラスリスト抽出条件設定クラス格納Dictionaryコピー処理
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
		/// <returns>抽出条件設定クラス格納Dictionary</returns>
		private Dictionary<string, ExtractConditionItem> ToItemDictionaryFromItemList( List<ExtractConditionItem> extractConditionItemList )
		{
			// インスタンスを作成
			Dictionary<string,ExtractConditionItem> retDictionary = new Dictionary<string,ExtractConditionItem>();

			// リストの内容を登録
			foreach( ExtractConditionItem item in extractConditionItemList ) {
				retDictionary.Add( item.Key, item );
			}

			return retDictionary;
		}

		/// <summary>
		/// 抽出条件設定クラス追加処理
		/// </summary>
		/// <param name="extractConditionItem">追加対象抽出条件設定クラス</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスをコレクションに追加します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		private void Add( ExtractConditionItem extractConditionItem )
		{
			// 既に同一キーが存在する場合は処理しない
			if( this._extractConditionItemDictionary.ContainsKey( extractConditionItem.Key ) == true ) {
				return;
			}

			this._extractConditionItemList.Add( extractConditionItem );
			this._extractConditionItemDictionary.Add( extractConditionItem.Key, extractConditionItem );

			this.Sort();
		}

		/// <summary>
		/// 抽出条件設定クラス削除処理
		/// </summary>
		/// <param name="extractConditionItem">削除対象抽出条件設定クラス</param>
		/// <remarks>
		/// <br>Note       : 指定されたオブジェクトと一致するオブジェクトをコレクションから削除します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		private void Remove( ExtractConditionItem extractConditionItem )
		{
			// 同一キーが存在しない場合は処理しない
			if( this._extractConditionItemDictionary.ContainsKey( extractConditionItem.Key ) == false ) {
				return;
			}

			ExtractConditionItem item = this._extractConditionItemDictionary[ extractConditionItem.Key ];

			if( item == null ) {
				return;
			}

			this._extractConditionItemList.Remove( item );
			this._extractConditionItemDictionary.Remove( item.Key );

			this.Sort();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// 抽出条件設定クラスコレクションソート処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスコレクションのソートを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public void Sort()
		{
			this._extractConditionItemList.Sort();
		}

		/// <summary>
		/// 抽出条件設定クラスリスト取得処理
		/// </summary>
		/// <returns>抽出条件設定クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストの取得を行います 。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public List<ExtractConditionItem> GetExtractConditionItemList()
		{
			return this._extractConditionItemList;
		}

		/// <summary>
		/// 抽出条件設定クラスリスト設定処理
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストの設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public void SetExtractConditionItemList( List<ExtractConditionItem> extractConditionItemList )
		{
			this._extractConditionItemList = extractConditionItemList;
			this._extractConditionItemList.Sort();
		}

		/// <summary>
		/// キー存在チェック処理
		/// </summary>
		/// <param name="key">コレクション内で検索されるキー</param>
		/// <returns>チェック結果(true:存在する, false:存在しない)</returns>
		/// <remarks>
		/// <br>Note       : 指定されたキーがコレクション内に存在するかどうかを判断します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public bool ContainsKey( string key )
		{
			return this._extractConditionItemDictionary.ContainsKey( key );
		}

		#endregion

		#region Public Static Methods

		/// <summary>
		/// 抽出条件設定クラスリストシリアライズ処理
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
		/// <param name="fileName">ファイル名</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストのシリアライズ処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public static void Serialize( List<ExtractConditionItem> extractConditionItemList, string fileName )
		{
			ExtractConditionItem[] extractConditionItemArray = new ExtractConditionItem[ extractConditionItemList.Count ];
			extractConditionItemList.CopyTo( extractConditionItemArray );

			UserSettingController.SerializeUserSetting(extractConditionItemArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
		}

		/// <summary>
		/// 抽出条件設定クラスリストデシリアライズ処理
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns>抽出条件設定クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストのデシリアライズ処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.9</br>
		/// </remarks>
		public static List<ExtractConditionItem> Deserialize( string fileName )
		{
			List<ExtractConditionItem> retList = new List<ExtractConditionItem>();

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)) == true)
			{
				try {
					ExtractConditionItem[] retArray = UserSettingController.DeserializeUserSetting<ExtractConditionItem[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

					foreach( ExtractConditionItem extractConditionItem in retArray ) {
						retList.Add( extractConditionItem );
					}
				}
				catch( System.InvalidOperationException ) {
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}

			return retList;
		}

		#endregion
	}
}

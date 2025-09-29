using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先検索抽出条件アイテムクラス
	/// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14720 得意先名検索追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 朱 猛</br>
    /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 徐錦山</br>
    /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    internal class ExtractConditionItems
	{
		/// <summary>得意先種別名称KEY</summary>
		public static readonly string CT_ITEM_CustomerKind = "CustomerKind";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="extractConditionItemList">得意先検索抽出条件アイテムクラスリスト</param>
        /// <remarks>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public ExtractConditionItems(List<ExtractConditionItem> extractConditionItemList)
		{
			// 変数初期化
			this._extractConditionItemList = this.OptionCheck(extractConditionItemList);

			// 抽出条件設定クラス格納Dictionary＆抽出条件設定クラスキーリスト初期値構築
			this._extractConditionItemInitDictionary = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionItemDictionary = new Dictionary<string,ExtractConditionItem>();
			this._extractConditionKeyList = new List<string>();

			List<ExtractConditionItem> list = new List<ExtractConditionItem>();
            // 2009/12/02 Del >>>
            //list.Add(new ExtractConditionItem("Kana",                1, "得意先名(ｶﾅ)",           true));
            //list.Add(new ExtractConditionItem("CustomerCode",        2, "得意先コード",         true));
            //list.Add(new ExtractConditionItem("CustomerSubCode",     3, "得意先サブコード",　   true));
            //list.Add(new ExtractConditionItem("SearchTelNo",         4, "電話番号（検索番号）", true));
            //list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind,  5, "得意先種別",           true));
            //list.Add(new ExtractConditionItem("CustAnalysCode",      6, "分析コード",           true));
            //list.Add(new ExtractConditionItem("CustomerAgentCd",     7, "得意先担当",           true));
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //list.Add( new ExtractConditionItem( "MngSectionCode", 8, "管理拠点", true ) );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 2009/12/02 Del <<<

            // 2009/12/02 Add >>>
            list.Add(new ExtractConditionItem("Kana", 1, "得意先名(ｶﾅ)", true));
            list.Add(new ExtractConditionItem("Name", 2, "得意先名", true));
        
            // 2011/7/22 XUJS EDIT STA>>>>>>
            list.Add(new ExtractConditionItem("CustomerSnm", 3, "得意先略称", true));
            /***
            list.Add(new ExtractConditionItem("CustomerCode", 3, "得意先コード", true));
            list.Add(new ExtractConditionItem("CustomerSubCode", 4, "得意先サブコード", true));
            list.Add(new ExtractConditionItem("SearchTelNo", 5, "電話番号（検索番号）", true));
            // ---ADD 2010/08/06-------------------->>>
            list.Add(new ExtractConditionItem("TelNum", 6, "電話番号", true));
            // ---ADD 2010/08/06--------------------<<<
            // ---UPD 2010/08/06-------------------->>>
            //list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 6, "得意先種別", true));
            //list.Add(new ExtractConditionItem("CustAnalysCode", 7, "分析コード", true));
            //list.Add(new ExtractConditionItem("CustomerAgentCd", 8, "得意先担当", true));
            //list.Add(new ExtractConditionItem("MngSectionCode", 9, "管理拠点", true));
            list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 7, "得意先種別", true));
            list.Add(new ExtractConditionItem("CustAnalysCode", 8, "分析コード", true));
            list.Add(new ExtractConditionItem("CustomerAgentCd", 9, "得意先担当", true));
            list.Add(new ExtractConditionItem("MngSectionCode", 10, "管理拠点", true));
            // ---UPD 2010/08/06--------------------<<<
            ***/
            // 2009/12/02 Add <<<
            list.Add(new ExtractConditionItem("CustomerCode", 4, "得意先コード", true));
            list.Add(new ExtractConditionItem("CustomerSubCode", 5, "得意先サブコード", true));
            list.Add(new ExtractConditionItem("SearchTelNo", 6, "電話番号（検索番号）", true));
            list.Add(new ExtractConditionItem("TelNum", 7, "電話番号", true));
            list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 8, "得意先種別", true));
            list.Add(new ExtractConditionItem("CustAnalysCode", 9, "分析コード", true));
            list.Add(new ExtractConditionItem("CustomerAgentCd", 10, "得意先担当", true));
            list.Add(new ExtractConditionItem("MngSectionCode", 11, "管理拠点", true));
            // 2011/7/22 XUJS EDIT END<<<<<<

			foreach(ExtractConditionItem item in list)
			{
				this._extractConditionKeyList.Add(item.Key);
				this._extractConditionItemInitDictionary.Add(item.Key, item);
			}

			// 抽出条件設定クラスリストが無効の場合は、初期値を設定
			if ((this._extractConditionItemList == null) || (this._extractConditionItemList.Count == 0))
			{
				foreach (string key in this._extractConditionKeyList)
				{
					ExtractConditionItem item = null;

					try
					{
						item = this._extractConditionItemInitDictionary[key];
					}
					catch (KeyNotFoundException)
					{
						//
					}

					if (item != null)
					{
						this._extractConditionItemList.Add(item);
					}
				}

				// 抽出条件設定クラス格納Dictionaryの値を最新情報にて再生成
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList(this._extractConditionItemList);
			}
			else
			{
				// 抽出条件設定クラス格納Dictionaryの値を最新情報にて再生成
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList(this._extractConditionItemList);

				// デフォルト値と引数の値を比較し、不足分を補充する
				foreach (string key in this._extractConditionKeyList)
				{
					if (!(this.ContainsKey(key)))
					{
						ExtractConditionItem item = null;

						try
						{
							item = this._extractConditionItemInitDictionary[key];
						}
						catch (KeyNotFoundException)
						{
							//
						}

						if (item != null)
						{
							item.No = this._extractConditionItemList.Count + 1;
							this.Add(item);
						}
					}
				}
			}

			this.Sort();
		}

		private List<ExtractConditionItem> _extractConditionItemList = null;		// 抽出条件設定クラスリスト
		private Dictionary<string, ExtractConditionItem> _extractConditionItemDictionary = null;
		private Dictionary<string, ExtractConditionItem> _extractConditionItemInitDictionary = null;
		private List<string> _extractConditionKeyList = null;

		public void Sort()
		{
			this._extractConditionItemList.Sort();
		}

		public List<ExtractConditionItem> GetExtractConditionItemList()
		{
			return this._extractConditionItemList;
		}

		public void SetExtractConditionItemList(List<ExtractConditionItem> extractConditionItemList)
		{
			this._extractConditionItemList = extractConditionItemList;
			this.Sort();
		}

		private void Add(ExtractConditionItem extractConditionItem)
		{
			// 既に同一Ｋｅｙが存在する場合は処理しない
			if (this._extractConditionItemDictionary.ContainsKey(extractConditionItem.Key)) return;

			this._extractConditionItemList.Add(extractConditionItem);
			this._extractConditionItemDictionary.Add(extractConditionItem.Key, extractConditionItem);

			this.Sort();
		}

		private void Remove(ExtractConditionItem extractConditionItem)
		{
			// 同一Ｋｅｙが存在しない場合は処理しない
			if (!(this._extractConditionItemDictionary.ContainsKey(extractConditionItem.Key))) return;

			ExtractConditionItem item = this._extractConditionItemDictionary[extractConditionItem.Key];

			if (item == null) return;

			this._extractConditionItemList.Remove(item);
			this._extractConditionItemDictionary.Remove(extractConditionItem.Key);

			this.Sort();
		}

		public bool ContainsKey(string key)
		{
			return this._extractConditionItemDictionary.ContainsKey(key);
		}

		public static void Serialize(List<ExtractConditionItem> extractConditionItemList, string fileName)
		{
			ExtractConditionItem[] extractConditionItemArray = new ExtractConditionItem[extractConditionItemList.Count];
			extractConditionItemList.CopyTo(extractConditionItemArray);

			UserSettingController.SerializeUserSetting(extractConditionItemArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
		}

		public static List<ExtractConditionItem> Deserialize(string fileName)
		{
			List<ExtractConditionItem> retList = new List<ExtractConditionItem>();

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
			{
				try
				{
					ExtractConditionItem[] retArray = UserSettingController.DeserializeUserSetting<ExtractConditionItem[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

					foreach (ExtractConditionItem extractConditionItem in retArray)
					{
						retList.Add(extractConditionItem);
					}
				}
				catch (System.InvalidOperationException)
				{
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}

			return retList;
		}

		private Dictionary<string, ExtractConditionItem> ToItemDictionaryFromItemList(List<ExtractConditionItem> extractConditionItemList)
		{
			Dictionary<string, ExtractConditionItem> retDictionary = new Dictionary<string,ExtractConditionItem>();

			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				retDictionary.Add(item.Key, item);
			}

			return retDictionary;
		}

		private List<ExtractConditionItem> OptionCheck(List<ExtractConditionItem> extractConditionItemList)
		{
			List<ExtractConditionItem> retList = new List<ExtractConditionItem>();

			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				retList.Add(item);
			}

			return retList;
		}
	}
}

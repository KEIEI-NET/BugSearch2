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
	/// ���Ӑ挟�����o�����A�C�e���N���X
	/// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 �� ��</br>
    /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 ���юR</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    internal class ExtractConditionItems
	{
		/// <summary>���Ӑ��ʖ���KEY</summary>
		public static readonly string CT_ITEM_CustomerKind = "CustomerKind";

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="extractConditionItemList">���Ӑ挟�����o�����A�C�e���N���X���X�g</param>
        /// <remarks>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 �� ��</br>
        /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public ExtractConditionItems(List<ExtractConditionItem> extractConditionItemList)
		{
			// �ϐ�������
			this._extractConditionItemList = this.OptionCheck(extractConditionItemList);

			// ���o�����ݒ�N���X�i�[Dictionary�����o�����ݒ�N���X�L�[���X�g�����l�\�z
			this._extractConditionItemInitDictionary = new Dictionary<string, ExtractConditionItem>();
			this._extractConditionItemDictionary = new Dictionary<string,ExtractConditionItem>();
			this._extractConditionKeyList = new List<string>();

			List<ExtractConditionItem> list = new List<ExtractConditionItem>();
            // 2009/12/02 Del >>>
            //list.Add(new ExtractConditionItem("Kana",                1, "���Ӑ於(��)",           true));
            //list.Add(new ExtractConditionItem("CustomerCode",        2, "���Ӑ�R�[�h",         true));
            //list.Add(new ExtractConditionItem("CustomerSubCode",     3, "���Ӑ�T�u�R�[�h",�@   true));
            //list.Add(new ExtractConditionItem("SearchTelNo",         4, "�d�b�ԍ��i�����ԍ��j", true));
            //list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind,  5, "���Ӑ���",           true));
            //list.Add(new ExtractConditionItem("CustAnalysCode",      6, "���̓R�[�h",           true));
            //list.Add(new ExtractConditionItem("CustomerAgentCd",     7, "���Ӑ�S��",           true));
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //list.Add( new ExtractConditionItem( "MngSectionCode", 8, "�Ǘ����_", true ) );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 2009/12/02 Del <<<

            // 2009/12/02 Add >>>
            list.Add(new ExtractConditionItem("Kana", 1, "���Ӑ於(��)", true));
            list.Add(new ExtractConditionItem("Name", 2, "���Ӑ於", true));
        
            // 2011/7/22 XUJS EDIT STA>>>>>>
            list.Add(new ExtractConditionItem("CustomerSnm", 3, "���Ӑ旪��", true));
            /***
            list.Add(new ExtractConditionItem("CustomerCode", 3, "���Ӑ�R�[�h", true));
            list.Add(new ExtractConditionItem("CustomerSubCode", 4, "���Ӑ�T�u�R�[�h", true));
            list.Add(new ExtractConditionItem("SearchTelNo", 5, "�d�b�ԍ��i�����ԍ��j", true));
            // ---ADD 2010/08/06-------------------->>>
            list.Add(new ExtractConditionItem("TelNum", 6, "�d�b�ԍ�", true));
            // ---ADD 2010/08/06--------------------<<<
            // ---UPD 2010/08/06-------------------->>>
            //list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 6, "���Ӑ���", true));
            //list.Add(new ExtractConditionItem("CustAnalysCode", 7, "���̓R�[�h", true));
            //list.Add(new ExtractConditionItem("CustomerAgentCd", 8, "���Ӑ�S��", true));
            //list.Add(new ExtractConditionItem("MngSectionCode", 9, "�Ǘ����_", true));
            list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 7, "���Ӑ���", true));
            list.Add(new ExtractConditionItem("CustAnalysCode", 8, "���̓R�[�h", true));
            list.Add(new ExtractConditionItem("CustomerAgentCd", 9, "���Ӑ�S��", true));
            list.Add(new ExtractConditionItem("MngSectionCode", 10, "�Ǘ����_", true));
            // ---UPD 2010/08/06--------------------<<<
            ***/
            // 2009/12/02 Add <<<
            list.Add(new ExtractConditionItem("CustomerCode", 4, "���Ӑ�R�[�h", true));
            list.Add(new ExtractConditionItem("CustomerSubCode", 5, "���Ӑ�T�u�R�[�h", true));
            list.Add(new ExtractConditionItem("SearchTelNo", 6, "�d�b�ԍ��i�����ԍ��j", true));
            list.Add(new ExtractConditionItem("TelNum", 7, "�d�b�ԍ�", true));
            list.Add(new ExtractConditionItem(CT_ITEM_CustomerKind, 8, "���Ӑ���", true));
            list.Add(new ExtractConditionItem("CustAnalysCode", 9, "���̓R�[�h", true));
            list.Add(new ExtractConditionItem("CustomerAgentCd", 10, "���Ӑ�S��", true));
            list.Add(new ExtractConditionItem("MngSectionCode", 11, "�Ǘ����_", true));
            // 2011/7/22 XUJS EDIT END<<<<<<

			foreach(ExtractConditionItem item in list)
			{
				this._extractConditionKeyList.Add(item.Key);
				this._extractConditionItemInitDictionary.Add(item.Key, item);
			}

			// ���o�����ݒ�N���X���X�g�������̏ꍇ�́A�����l��ݒ�
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

				// ���o�����ݒ�N���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList(this._extractConditionItemList);
			}
			else
			{
				// ���o�����ݒ�N���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
				this._extractConditionItemDictionary = this.ToItemDictionaryFromItemList(this._extractConditionItemList);

				// �f�t�H���g�l�ƈ����̒l���r���A�s�������[����
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

		private List<ExtractConditionItem> _extractConditionItemList = null;		// ���o�����ݒ�N���X���X�g
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
			// ���ɓ���j���������݂���ꍇ�͏������Ȃ�
			if (this._extractConditionItemDictionary.ContainsKey(extractConditionItem.Key)) return;

			this._extractConditionItemList.Add(extractConditionItem);
			this._extractConditionItemDictionary.Add(extractConditionItem.Key, extractConditionItem);

			this.Sort();
		}

		private void Remove(ExtractConditionItem extractConditionItem)
		{
			// ����j���������݂��Ȃ��ꍇ�͏������Ȃ�
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

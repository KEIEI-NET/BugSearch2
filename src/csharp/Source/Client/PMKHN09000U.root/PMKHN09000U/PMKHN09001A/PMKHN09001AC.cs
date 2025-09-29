using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using Broadleaf.Application.Remoting.ParamData; // 2010/07/06 Add
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先画面用拠点情報コントロールクラス
	/// </summary>
	/// <br>Note       : 得意先画面用に拠点情報をコントロールするクラスです。</br>
	/// <br>Programer  : 980076  妻鳥  謙一郎</br>
	/// <br>Date       : 2006.06.12</br>
	/// <br>Update Note: </br>
	/// <br>2006.06.12 men 新規作成</br>
    /// <br>UpdateNote  : 2010/07/06 30517 夏野 駿希 QRコード携帯メール対応</br>
    public class CustomerSectionInfoControl
	{
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
		private static SecInfoAcs _secInfoAcs;													// 拠点アクセスクラス
		private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string SECTIONCODE_ALL = "000000";
		private const string SECTIONNAME_ALL = "全社";

		/// <summary>
		/// 拠点オプション導入チェックプロパティ
		/// </summary>
		/// <returns>true:導入 false:未導入</returns>
		public static bool IsSectionOptionIntroduce
		{
			get
			{
				// 拠点オプションチェック
				if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 本社機能／拠点機能チェック処理
		/// </summary>
		/// <returns>true:本社機能 false:拠点機能</returns>
		public bool IsMainOfficeFunc()
		{
			bool isMainOfficeFunc = false;

			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ログイン担当拠点情報の取得
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet != null)
			{
				// 本社機能か？
				if (secInfoSet.MainOfficeFuncFlag == 1)
				{
					isMainOfficeFunc = true;
				}
			}
			else
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}

			return isMainOfficeFunc;
		}

		/// <summary>
		/// 拠点情報チェック処理
		/// </summary>
		public void CheckSectionInfo()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ログイン担当拠点情報の取得
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

		/// <summary>
		/// 拠点コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <param name="isAllSection">全社設定フラグ</param>
		public void SetSectionComboEditor(ref TComboEditor sender, bool isAllSection)
		{
			Infragistics.Win.ValueList valueList;
			this.SetSectionComboEditor(out valueList, isAllSection);

			if (valueList != null)
			{
				for (int i = 0; i < valueList.ValueListItems.Count; i++)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //sender.Items.Add(valueList.ValueListItems[i]);

                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				}

				sender.MaxDropDownItems = valueList.ValueListItems.Count;

				if (this.IsMainOfficeFunc())
				{
					sender.ReadOnly = false;
				}
				else
				{
					sender.ReadOnly = true;
				}
			}
		}

		/// <summary>
		/// 拠点コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスツール</param>
		/// <param name="isAllSection">全社設定フラグ</param>
		public void SetSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool isAllSection)
		{
			Infragistics.Win.ValueList valueList;
			this.SetSectionComboEditor(out valueList, isAllSection);

			if (valueList != null)
			{
				sender.ValueList = valueList;
				sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

				if (this.IsMainOfficeFunc())
				{
					sender.SharedProps.Enabled = true;
				}
				else
				{
					sender.SharedProps.Enabled = false;
				}
			}
		}

		/// <summary>
		/// 拠点コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスバリューリスト</param>
		/// <param name="isAllSection">全社設定フラグ</param>
		public void SetSectionComboEditor(out Infragistics.Win.ValueList sender, bool isAllSection)
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			sender = new Infragistics.Win.ValueList();

			// ログイン担当拠点情報の取得
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet != null)
			{
				if (isAllSection)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = SECTIONCODE_ALL;
					secInfoItem.DisplayText = SECTIONNAME_ALL;
					sender.ValueListItems.Add(secInfoItem);
				}

				// 拠点情報リストの取得
				if ((_secInfoAcs.SecInfoSetList != null) && (_secInfoAcs.SecInfoSetList.Length > 0))
				{
					foreach (SecInfoSet setSecInfoSet in _secInfoAcs.SecInfoSetList)
					{
						Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
						secInfoItem.DataValue = setSecInfoSet.SectionCode;
						secInfoItem.DisplayText = setSecInfoSet.SectionGuideNm;
						sender.ValueListItems.Add(secInfoItem);
					}
				}
			}
		}

		/// <summary>
		/// 拠点コンボエディタ選択値設定処理
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>true:設定成功 false:設定失敗</returns>
		public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode)
		{
			bool isSetting = false;

			if (sender.Items.Count > 0)
			{
				// 1つの拠点しかない場合は先頭を選択
				if (sender.Items.Count == 1)
				{
					sender.SelectedIndex = 0;
					isSetting = true;
				}
				else
				{
					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (sender.Items[i].DataValue.ToString().Trim() == sectionCode.Trim())
						{
							sender.SelectedIndex = i;
							isSetting = true;
							break;
						}
					}
				}

				if (!isSetting)
				{
					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (sender.Items[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
						{
							sender.SelectedIndex = i;
							isSetting = true;
							break;
						}
					}
				}
			}

			return isSetting;
		}

		/// <summary>
		/// 拠点コンボエディタ選択値設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックス</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>true:設定成功 false:設定失敗</returns>
		public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode)
		{
			bool isSetting = false;

			if (sender.ValueList.ValueListItems.Count > 0)
			{
				sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

				// 1つの拠点しかない場合は先頭を選択
				if (sender.ValueList.ValueListItems.Count == 1)
				{
					sender.SelectedIndex = 0;
					isSetting = true;
				}
				else
				{
					for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
					{
						if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == sectionCode.Trim())
						{
							sender.Value = sectionCode;
							isSetting = true;
							break;
						}
					}
				}

				if (!isSetting)
				{
					for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
					{
						if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
						{
							sender.Value = this._loginSectionCode;
							isSetting = true;
							break;
						}
					}
				}
			}

			return isSetting;
		}

        // 2010/07/06 Add >>>
        /// <summary>
        /// 携帯メールオプション導入チェックプロパティ
        /// </summary>
        /// <returns>true:導入 false:未導入</returns>
        public static bool IsQRMailOptionIntroduce
        {
			get
			{
				// 携帯メールオプションチェック
                if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_QRMail) == PurchaseStatus.Contract)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
        }
        // 2010/07/06 Add <<<
	}
}

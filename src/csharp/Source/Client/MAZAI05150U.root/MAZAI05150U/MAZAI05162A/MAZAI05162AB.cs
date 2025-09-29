using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	public partial class InventoryUpdateAcs
	{
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
		private string _ownSectionCode = "";
        
        private static SecInfoAcs _secInfoAcs;													// 拠点アクセスクラス
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		internal const string SECTIONCODE_ALL = "000000";
		private const string SECTIONNAME_ALL = "全社";
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/


        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
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
		/// 拠点制御アクセスクラスインスタンス化処理
		/// </summary>
		internal void CreateSecInfoAcs(ArrayList secInfoSetWorkArrayList, ArrayList secCtrlSetWorkArrayList, ArrayList companyNmWorkArrayList)
		{
			if ((secInfoSetWorkArrayList == null) || (secCtrlSetWorkArrayList == null) || (companyNmWorkArrayList == null))
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}

			SecInfoAcs.SetSecInfo(secInfoSetWorkArrayList, secCtrlSetWorkArrayList, companyNmWorkArrayList);

			this.CreateSecInfoAcs();
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 拠点制御アクセスクラスインスタンス化処理
		/// </summary>
		internal void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ログイン担当拠点情報の取得
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 拠点設定マスタ配列プロパティ
		/// </summary>
		internal SecInfoSet[] SecInfoSetArray
		{
			get
			{
				// 拠点制御アクセスクラスインスタンス化処理
				this.CreateSecInfoAcs();

				return _secInfoAcs.SecInfoSetList;
			}
        }
        
		/// <summary>
		/// 自拠点コードプロパティ
		/// </summary>
		public string OwnSectionCode
		{
			get
			{
				if (this._ownSectionCode == "")
				{
					return this.GetOwnSectionCode();
				}
				else
				{
					return this._ownSectionCode;
				}
			}
		}
        
        /// <summary>
		/// 自拠点コード取得処理
		/// </summary>
		/// <returns>自拠点コード</returns>
		private string GetOwnSectionCode()
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			// 自拠点の取得
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
			if (secInfoSet != null)
			{
				// 自拠点コードの保存
				this._ownSectionCode = secInfoSet.SectionCode;
			}

			return this._ownSectionCode;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        #region DEL 2008.12.25 [9572]
        ///// <summary>
        ///// 本社機能／拠点機能チェック処理
        ///// </summary>
        ///// <returns>true:本社機能 false:拠点機能</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // 拠点制御アクセスクラスインスタンス化処理
        //    this.CreateSecInfoAcs();

        //    // ログイン担当拠点情報の取得
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // 本社機能か？
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        #endregion // DEL 2008.12.25 [9572]

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
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
                    // 2008.03.26 修正 >>>>>>>>>>>>>>>>>>>>
                    //sender.Items.Add(valueList.ValueListItems[i]);
                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag         = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue   = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlItem);
                    // 2008.03.26 修正 <<<<<<<<<<<<<<<<<<<<
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

				this.EnabledSettingSectionComboEditor(ref sender);
			}
		}

		/// <summary>
		/// 拠点コンボエディタEnabled設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスツール</param>
		public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender)
		{
			if (this.IsMainOfficeFunc())
			{
				sender.SharedProps.Enabled = true;
			}
			else
			{
				sender.SharedProps.Enabled = false;
			}
		}


		/// <summary>
		/// 拠点コンボエディタEnabled設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスツール</param>
		/// <param name="enabled">設定Enabled値</param>
		public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool enabled)
		{
			if (this.IsMainOfficeFunc())
			{
				sender.SharedProps.Enabled = enabled;
			}
			else
			{
				sender.SharedProps.Enabled = false;
			}
		}

		/// <summary>
		/// 拠点コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスバリューリスト</param>
		/// <param name="isAllSection">全社設定フラグ</param>
		public void SetSectionComboEditor(out Infragistics.Win.ValueList sender, bool isAllSection)
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

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
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
		/// <br>・OwnSecSetting = 自拠点設定</br>
		/// <br>・DemandAddUpSecCd = 請求計上拠点</br>
		/// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
		/// <br>・BillSettingSecCd = 請求設定拠点</br>
		/// <br>・BalanceDispSecCd = 残高表示拠点</br>
		/// <br>・PayAddUpSecCd = 支払計上拠点</br>
		/// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
		/// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
		/// <br>・StockUpdateSecCd = 在庫更新拠点</br>
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="ctrlFuncCode">取得する制御機能コード</param>
		/// <returns>true:設定成功 false:設定失敗</returns>
		public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
		{
			if (sectionCode.Trim() == SECTIONCODE_ALL)
			{
				return this.SetSectionComboEditorValue(sender, sectionCode);
			}
			else
			{
				string ctrlSectionCode;
				string ctrlSectionName;
				int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

				if (status == 0)
				{
					return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
				}
				else
				{
					return false;
				}
			}
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

		/// <summary>
		/// 拠点コンボエディタ選択値設定処理
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
		/// <br>・OwnSecSetting = 自拠点設定</br>
		/// <br>・DemandAddUpSecCd = 請求計上拠点</br>
		/// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
		/// <br>・BillSettingSecCd = 請求設定拠点</br>
		/// <br>・BalanceDispSecCd = 残高表示拠点</br>
		/// <br>・PayAddUpSecCd = 支払計上拠点</br>
		/// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
		/// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
		/// <br>・StockUpdateSecCd = 在庫更新拠点</br>
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="ctrlFuncCode">取得する制御機能コード</param>
		/// <returns>true:設定成功 false:設定失敗</returns>
		public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
		{
			if (sectionCode.Trim() == SECTIONCODE_ALL)
			{
				return this.SetSectionComboEditorValue(sender, sectionCode);
			}
			else
			{
				string ctrlSectionCode;
				string ctrlSectionName;
				int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

				if (status == 0)
				{
					return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
				}
				else
				{
					return false;
				}
			}
		}

        /// <summary>
		/// 制御機能拠点取得処理
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
		/// <br>・OwnSecSetting = 自拠点設定</br>
		/// <br>・DemandAddUpSecCd = 請求計上拠点</br>
		/// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
		/// <br>・BillSettingSecCd = 請求設定拠点</br>
		/// <br>・BalanceDispSecCd = 残高表示拠点</br>
		/// <br>・PayAddUpSecCd = 支払計上拠点</br>
		/// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
		/// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
		/// <br>・StockUpdateSecCd = 在庫更新拠点</br>
		/// </summary>
		/// <param name="sectionCode">対象拠点コード</param>
		/// <param name="ctrlFuncCode">取得する制御機能コード</param>
		/// <param name="ctrlSectionCode">対象制御拠点コード</param>
		/// <param name="ctrlSectionName">対象制御拠点名称</param>
		public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName)
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			// 対象制御拠点の初期値はログイン担当拠点
			ctrlSectionCode = sectionCode.TrimEnd();
			ctrlSectionName = "";

			SecInfoSet secInfoSet;
			int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if (secInfoSet != null)
					{
						ctrlSectionCode = secInfoSet.SectionCode.Trim();
						ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
					}
					else
					{
						// 拠点制御設定がされていない
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				default:
				{
					break;
				}
			}

			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト
    }
}

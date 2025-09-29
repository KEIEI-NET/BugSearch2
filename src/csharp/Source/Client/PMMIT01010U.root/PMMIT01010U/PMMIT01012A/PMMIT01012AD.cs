using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	public partial class EstimateInputInitDataAcs
	{
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
		private string _ownSectionCode = "";
		private string _ownSectionName = "";
		private List<string> _sectWarehouseCdList = new List<string>();
		private List<string> _sectWarehouseNmList = new List<string>();
		private static SecInfoAcs _secInfoAcs;													// 拠点アクセスクラス
		private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		internal const string SECTIONCODE_ALL = "000000";
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

		/// <summary>
		/// 拠点制御アクセスクラスインスタンス化処理
		/// </summary>
		internal void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
			}

            // ログイン担当拠点情報の取得
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

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
		/// 自拠点名称プロパティ
		/// </summary>
		public string OwnSectionName
		{
			get
			{
				if (this._ownSectionName == "")
				{
					return this.GetOwnSectionName();
				}
				else
				{
					return this._ownSectionName;
				}
			}
		}

		/// <summary>
		/// 自拠点倉庫コードプロパティ
		/// </summary>
		public List<string> SectWarehouseCd
		{
			get
			{
				if (this._sectWarehouseCdList.Count == 0)
				{
					return this.GetSectWarehouseCd();
				}
				else
				{
					return this._sectWarehouseCdList;
				}
			}
		}

		/// <summary>
		/// 自拠点倉庫名称プロパティ
		/// </summary>
		public List<string> SectWarehouseNm
		{
			get
			{
				if (this._sectWarehouseNmList.Count == 0)
				{
					return this.GetSectWarehouseNm();
				}
				else
				{
					return this._sectWarehouseNmList;
				}
			}
		}

		/// <summary>
		/// 拠点情報取得処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns></returns>
		public SecInfoSet GetSecInfo( string sectionCode )
		{
			SecInfoSet retSecInfoSet = null;

			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			if (_secInfoAcs.SecInfoSetList != null)
			{
				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
					{
						retSecInfoSet = secInfoSet;
						break;
					}
				}
			}
			return retSecInfoSet;
		}

		/// <summary>
		/// 自拠点コード取得処理
		/// </summary>
		/// <returns>自拠点コード</returns>
		private string GetOwnSectionCode()
		{
			this.GetOwnSectionInfo();

			return this._ownSectionCode;
		}

		/// <summary>
		/// 自拠点名称取得処理
		/// </summary>
		/// <returns>自拠点コード</returns>
        //private string GetOwnSectionName() // 2009.05.26
   		public string GetOwnSectionName() // 2009.05.26
        {
			this.GetOwnSectionInfo();

			return this._ownSectionName;
		}

		/// <summary>
		/// 自拠点情報取得処理
		/// </summary>
		/// <returns></returns>
		private void GetOwnSectionInfo()
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			// 自拠点の取得
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

			if (secInfoSet != null)
			{
				this._ownSectionCode = secInfoSet.SectionCode;
				this._ownSectionName = secInfoSet.SectionGuideNm;
			}
		}

		/// <summary>
		/// 自拠点優先倉庫コード取得処理
		/// </summary>
		/// <returns>自拠点優先倉庫コード</returns>
		private List<string> GetSectWarehouseCd()
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				_sectWarehouseCdList = new List<string>();
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd1);
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd2);
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd3);
			}
			return this._sectWarehouseCdList;
		}

		/// <summary>
		/// 自拠点優先倉庫名称取得処理
		/// </summary>
		/// <returns>自拠点優先倉庫名称</returns>
		private List<string> GetSectWarehouseNm()
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				_sectWarehouseNmList = new List<string>();
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm1);
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm2);
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm3);
			}
			return this._sectWarehouseNmList;
		}


		/// <summary>
		/// 本社機能／拠点機能チェック処理
		/// </summary>
		/// <returns>true:本社機能 false:拠点機能</returns>
		public bool IsMainOfficeFunc()
		{
			bool isMainOfficeFunc = false;

			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

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
		/// 制御機能拠点取得処理
		/// </summary>
		/// <param name="sectionCode">対象拠点コード</param>
		/// <param name="ctrlSectionCode">対象制御拠点コード</param>
		/// <param name="ctrlSectionName">対象制御拠点名称</param>
		public int GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode, out string ctrlSectionName)
		{
			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			// 対象制御拠点の初期値はログイン担当拠点
			ctrlSectionCode = sectionCode.TrimEnd();
			ctrlSectionName = "";

			SecInfoSet secInfoSet;
			int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

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

        /// <summary>
        /// ＵＯＥガイド名称マスタコンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="uOEGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uOESupplierCd">ＵＯＥ発注先コード</param>
        public void SetUOEGuideNameComboEditor(ref TComboEditor sender, int uOEGuideDivCd, int uOESupplierCd)
        {
            sender.Items.Clear();
            Infragistics.Win.ValueList valueList;
            this.SetUOEGuideNameComboEditor(out valueList, uOEGuideDivCd, uOESupplierCd);

            if (valueList != null)
            {
                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlItem);
                }

                if (valueList.ValueListItems.Count > 0)
                {
                    sender.MaxDropDownItems = valueList.ValueListItems.Count;
                }
            }
        }

        /// <summary>
        /// ＵＯＥガイド名称マスタコンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uoeGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uoeSupplierCd">ＵＯＥ発注先コード</param>
        public void SetUOEGuideNameComboEditor(out Infragistics.Win.ValueList sender, int uoeGuideDivCd, int uoeSupplierCd)
        {
            sender = new Infragistics.Win.ValueList();

            List<UOEGuideName> uoeGuideNameList = this.GetUOEGuideNameListFromCache(uoeGuideDivCd, uoeSupplierCd);

            foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
            {
                Infragistics.Win.ValueListItem infoItem = new Infragistics.Win.ValueListItem();
                infoItem.Tag = uoeGuideName.UOEGuideCode;
                infoItem.DataValue = uoeGuideName.UOEGuideCode;
                infoItem.DisplayText = uoeGuideName.UOEGuideNm;
                sender.ValueListItems.Add(infoItem);
            }
        }
	}
}

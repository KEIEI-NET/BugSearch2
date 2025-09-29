using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 對馬 大輔  新規作成</br>
    /// <br></br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバ個別 本社倉庫優先順位対応</br>
    /// <br></br>
    /// <br>Update Note: K2013/10/04 脇田 靖之</br>
    /// <br>             ㈱フタバ個別 本社倉庫優先順位対応</br>
    /// <br>             優先倉庫取得方法を”Search”から”ReadWithWarehouse”に変更</br>
    /// </remarks>
    public partial class SalesSlipInputInitDataAcs
    {
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
        private string _ownSectionCode = string.Empty;
        private string _ownSectionName = string.Empty;
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
        public void CreateSecInfoAcs()
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
                if (string.IsNullOrEmpty(this._ownSectionCode))
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
        /// 自拠点名称dプロパティ
        /// </summary>
        public string OwnSectionName
        {
            get
            {
                if (string.IsNullOrEmpty(this._ownSectionName))
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
        /// 自拠点コード取得処理
        /// </summary>
        /// <returns>自拠点コード</returns>
        private string GetOwnSectionCode()
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 自拠点の取得
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // 自拠点コードの保存
                this._ownSectionCode = secInfoSet.SectionCode;
            }

            return this._ownSectionCode;
        }

        /// <summary>
        /// 自拠点名称取得得処理
        /// </summary>
        /// <returns>自拠点名称</returns>
        public string GetOwnSectionName()
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 自拠点の取得
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // 自拠点コードの保存
                this._ownSectionName = secInfoSet.SectionGuideNm;
            }

            return this._ownSectionName;
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
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd1.Trim());
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd2.Trim());
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }
            return this._sectWarehouseCdList;
        }

        // 2009/09/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 自拠点優先倉庫コード取得処理
        /// </summary>
        /// <returns>自拠点優先倉庫コード</returns>
        public List<string> GetSectWarehouseCd(string sectionCode)
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();
            List<string> retList = new List<string>();

            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(sectionCode.PadRight(6, ' '), out secInfoSet);

            if (secInfoSet != null)
            {
                retList.Add(secInfoSet.SectWarehouseCd1.Trim());
                retList.Add(secInfoSet.SectWarehouseCd2.Trim());
                retList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }
            return retList;
        }
        // 2009/09/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<        

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
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm1.TrimEnd());
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm2.TrimEnd());
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm3.TrimEnd());
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
                    sender.Items.Add(valueList.ValueListItems[i]);
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
            ctrlSectionName = string.Empty;

            SecInfoSet secInfoSet;
            int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (secInfoSet != null)
                        {
                            //ctrlSectionCode = secInfoSet.SectionCode.Trim();
                            ctrlSectionCode = secInfoSet.SectionCode;
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
        /// 拠点情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        public SecInfoSet GetSecInfo(string sectionCode)
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

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 本社拠点チェック処理 ㈱フタバ個別対応
        /// </summary>
        public bool CheckMainSection(string enterpriseCode, string sectionCode)
        {
            bool retMainSection = false;

            //指定拠点コードで本社管理倉庫マスタを読み込み、存在する場合は本社
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ProtyWarehouseAcs protyWarehouseAcs = new ProtyWarehouseAcs();
            ArrayList warehouseList = new ArrayList();
            status = protyWarehouseAcs.ReadWithWarehouse(out warehouseList, enterpriseCode, sectionCode, "", ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMainSection = true;
            }
            return retMainSection;
        }

        /// <summary>
        /// 優先倉庫取得処理 ㈱フタバ個別対応
        /// </summary>
        //public int GetPriorWarehouseInfo(string enterpriseCode, string sectionCode, out List<string> WarehouseCdList)
        public List<string> GetPriorWarehouseInfo(string enterpriseCode, string sectionCode)
        {
            List<string> WarehouseCdList = new List<string>();

            //指定拠点コードで本社管理倉庫マスタを読み込み、優先順に倉庫コードを格納
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ProtyWarehouseAcs protyWarehouseAcs = new ProtyWarehouseAcs();
            ArrayList warehouseList = new ArrayList();
            // --- UPD 2013/10/04 Y.Wakita ---------->>>>>
            //status = protyWarehouseAcs.Search(out warehouseList, enterpriseCode);
            status = protyWarehouseAcs.ReadWithWarehouse(out warehouseList, enterpriseCode, "", "", ConstantManagement.LogicalMode.GetData0);
            // --- UPD 2013/10/04 Y.Wakita ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ProtyWarehouse warehouse in warehouseList)
                {
                    WarehouseCdList.Add(warehouse.WarehouseCode.Trim());
                }
            }
            return WarehouseCdList;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
    }
}

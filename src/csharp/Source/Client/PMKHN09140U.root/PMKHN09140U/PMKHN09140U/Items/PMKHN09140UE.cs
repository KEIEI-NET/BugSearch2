//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : カテゴリ、機能、操作UIの制御
// プログラム概要   : カテゴリ、機能、操作UIの制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms.Items
{
    using UIType        = ComboBox;
    using UIItemType    = CodeNamePair<int>;
    using PgItemType    = CodeNamePair<string>;
    using DataSetType   = OperationMasterDataSet;
    using DataTableType = OperationMasterDataSet.OperationMasterDataTable;
    using DataRowType   = OperationMasterDataSet.OperationMasterRow;

    /// <summary>
    /// カテゴリ、機能、操作を制御するクラス
    /// </summary>
    internal sealed class OperationItemController
    {
        #region <カテゴリ/>

        /// <summary>カテゴリUI</summary>
        private readonly UIType _categoryUI;
        /// <summary>
        /// カテゴリUIを取得します。
        /// </summary>
        /// <value>カテゴリUI</value>
        public UIType CategoryUI
        {
            get { return _categoryUI; }
        }

        #endregion  // <カテゴリ/>

        #region <機能/>

        /// <summary>機能UI</summary>
        private readonly UIType _pgUI;
        /// <summary>
        /// 機能UIを取得します。
        /// </summary>
        /// <value>機能UI</value>
        public UIType PgUI
        {
            get { return _pgUI; }
        }

        /// <summary>
        /// 機能のUIを初期化します。
        /// </summary>
        /// <param name="pgTable">機能を集めたテーブル</param>
        private void InitializePgUI(DataTableType pgTable)
        {
            PgUI.Items.Clear();

            PgUI.Items.Add(new PgItemType(LogCondition.ALL_PG_ID, LogCondition.ALL_PG_NAME));
            foreach (DataRowType opeRow in pgTable)
            {
                if (string.IsNullOrEmpty(opeRow.PgId)) continue;    // DB上の"全体"は無視

                PgUI.Items.Add(new PgItemType(opeRow.PgId, opeRow.PgName));
            }
            PgUI.SelectedIndex = 0;
        }

        #endregion  // <機能/>

        #region <操作/>

        /// <summary>操作UI</summary>
        private readonly UIType _operationUI;
        /// <summary>
        /// 操作UIを取得します。
        /// </summary>
        /// <value>操作UI</value>
        public UIType OperationUI
        {
            get { return _operationUI; }
        }

        /// <summary>
        /// 操作のUIを初期化します。
        /// </summary>
        /// <param name="operationTable">操作を集めたテーブル</param>
        private void InitializeOperationUI(DataTableType operationTable)
        {
            OperationUI.Items.Clear();

            OperationUI.Items.Add(new UIItemType(LogCondition.ALL_OPERATION_CODE, LogCondition.ALL_OPERATION_NAME));
            foreach (DataRowType opeRow in operationTable)
            {
                OperationUI.Items.Add(new UIItemType(opeRow.OperationCode, opeRow.OperationName));
            }
            OperationUI.SelectedIndex = 0;
        }

        #endregion  // <操作/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="categoryUI">カテゴリUI</param>
        /// <param name="pgUI">機能UI</param>
        /// <param name="operationUI">操作UI</param>
        public OperationItemController(
            UIType categoryUI,
            UIType pgUI,
            UIType operationUI
        )
        {
            _categoryUI = categoryUI;
            _pgUI = pgUI;
            _operationUI = operationUI;

            InitializeUI();

            CategoryUI.SelectedValueChanged += new EventHandler(categoryUI_SelectedValueChanged);
            PgUI.SelectedValueChanged += new EventHandler(pgUI_SelectedValueChanged);
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// UIを初期化します。
        /// </summary>
        private void InitializeUI()
        {
            // カテゴリ
            CategoryUI.Items.Add(new UIItemType(LogCondition.ALL_CATEGORY_CODE, LogCondition.ALL_CATEGORY_NAME));
            foreach (DataRowType opeRow in OperationHistoryAcs.Instance.OperationMasterDB.CategoryTbl)
            {
                CategoryUI.Items.Add(new UIItemType(opeRow.CategoryCode, opeRow.CategoryName));
            }
            CategoryUI.SelectedIndex = 0;

            // 機能
            InitializePgUI(OperationHistoryAcs.Instance.OperationMasterDB.PgTbl);

            // 操作
            if (OperationUI == null) return;
            InitializeOperationUI(OperationHistoryAcs.Instance.OperationMasterDB.OperationTbl);
            OperationUI.Enabled = false;
        }

        /// <summary>
        /// カテゴリの選択値が変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void categoryUI_SelectedValueChanged(
            object sender,
            EventArgs e
        )
        {
            // 値を保持
            int selectedCategoryCode = ((UIItemType)CategoryUI.SelectedItem).Code;

            string selectedPgId     = LogCondition.ALL_PG_ID;
            string selectedPgName   = LogCondition.ALL_PG_NAME;
            if (PgUI.SelectedItem != null)
            {
                selectedPgId    = ((PgItemType)PgUI.SelectedItem).Code;
                selectedPgName  = ((PgItemType)PgUI.SelectedItem).Name;
            }

            if (OperationUI != null)
            {
                _selectedOperationCode = LogCondition.ALL_OPERATION_CODE;
                _selectedOperationName = LogCondition.ALL_OPERATION_NAME;
                if (OperationUI.SelectedItem != null)
                {
                    _selectedOperationCode = ((UIItemType)OperationUI.SelectedItem).Code;
                    _selectedOperationName = ((UIItemType)OperationUI.SelectedItem).Name;
                }
            }

            // UIを初期化
            if (selectedCategoryCode.Equals(LogCondition.ALL_CATEGORY_CODE))
            {
                InitializePgUI(OperationHistoryAcs.Instance.OperationMasterDB.PgTbl);
            }
            else
            {
                InitializePgUI(OperationAuthoritySettingAcs.Instance.OperationMasterDB.GetPgTblWhere(selectedCategoryCode));
            }

            // 再選択
            for (int i = 0; i < PgUI.Items.Count; i++)
            {
                string id   = ((PgItemType)PgUI.Items[i]).Code;
                string name = ((PgItemType)PgUI.Items[i]).Name;
                if (id.Equals(selectedPgId) && name.Equals(selectedPgName))
                {
                    PgUI.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>選択された操作コード（制御用）</summary>
        private int _selectedOperationCode;
        /// <summary>選択された操作名称（制御用）</summary>
        private string _selectedOperationName;

        /// <summary>
        /// 機能の選択値が変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void pgUI_SelectedValueChanged(
            object sender,
            EventArgs e
        )
        {
            #region <Guard Phease/>

            if (OperationUI == null) return;

            #endregion  // <Guard Phrase/>

            // 値を保持
            int selectedCategoryCode = LogCondition.ALL_CATEGORY_CODE;
            if (CategoryUI.SelectedItem != null) selectedCategoryCode = ((UIItemType)CategoryUI.SelectedItem).Code;

            string selectedPgId = LogCondition.ALL_PG_ID;
            if (PgUI.SelectedItem != null) selectedPgId = ((PgItemType)PgUI.SelectedItem).Code;

            // UIを初期化
            InitializeOperationUI(OperationAuthoritySettingAcs.Instance.OperationMasterDB.GetOperationTblWhere(
                 selectedCategoryCode,
                 selectedPgId
             ));
            // HACK:ゴミ掃除
            //if (selectedPgId.Equals(LogCondition.ALL_PG_ID))
            //{
            //    InitializeOperationUI(OperationHistoryAcs.Instance.OperationMasterDB.PgTbl);
            //    OperationUI.Enabled = false;
            //    return;
            //}
            //else
            //{
            //    InitializeOperationUI(OperationAuthoritySettingAcs.Instance.OperationMasterDB.GetOperationTblWhere(selectedPgId));
            //    OperationUI.Enabled = true;
            //}

            // 再選択
            if (selectedCategoryCode.Equals(LogCondition.ALL_CATEGORY_CODE)
                    &&
                selectedPgId.Equals(LogCondition.ALL_PG_ID))
            {
                OperationUI.SelectedIndex = 0;
                OperationUI.Enabled = false;
            }
            else
            {
                OperationUI.Enabled = true;
            }
            for (int i = 0; i < OperationUI.Items.Count; i++)
            {
                int code    = ((UIItemType)OperationUI.Items[i]).Code;
                string name = ((UIItemType)OperationUI.Items[i]).Name;
                if (code.Equals(_selectedOperationCode) && name.Equals(_selectedOperationName))
                {
                    OperationUI.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}

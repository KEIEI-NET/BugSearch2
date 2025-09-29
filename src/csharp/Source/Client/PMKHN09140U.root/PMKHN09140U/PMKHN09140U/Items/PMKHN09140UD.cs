//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 拠点UIの制御
// プログラム概要   : 拠点UIの制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms.Items
{
    using UIType        = CheckedListBox;
    using UIItemType    = CodeNamePair<string>;
    using DataSetType   = SectionInfoDataSet;
    using DataTableType = SectionInfoDataSet.SectionInfoDataTable;
    using DataRowType   = SectionInfoDataSet.SectionInfoRow;

    /// <summary>
    /// 拠点アイテムを制御するクラス
    /// </summary>
    internal sealed class SectionItemController
    {
        /// <summary>全社のインデックス</summary>
        private const int ALL_SECTION_INDEX = 0; // LITERAL:

        /// <summary>全社が存在するか判定するフラグ</summary>
        private bool _existsAllSection;
        /// <summary>
        /// 全社が存在するか判定するフラグを取得します。
        /// </summary>
        /// <value>全社が存在するか判定するフラグ</value>
        private bool ExistsAllSection
        {
            get { return _existsAllSection; }
            set { _existsAllSection = value; }
        }

        /// <summary>UI</summary>
        private readonly UIType _ui;
        /// <summary>
        /// UIを取得します。
        /// </summary>
        /// <value>UI</value>
        public UIType UI { get { return _ui; } }

        /// <summary>処理中フラグ</summary>
        private bool _nowDoing;
        /// <summary>
        /// 処理中フラグを取得します。
        /// </summary>
        /// <value>処理中フラグ</value>
        private bool NowDoing
        {
            get { return _nowDoing; }
            set { _nowDoing = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SectionItemController(UIType ui)
        {
            _ui = ui;
            InitializeUI(_ui);

            _ui.ItemCheck += new ItemCheckEventHandler(this.sectionCheckedListBox_ItemCheck);
        }

        /// <summary>
        /// UIを初期化します。
        /// </summary>
        private void InitializeUI(UIType ui)
        {
            // 拠点マスタDBに1件より多いレコードがあれば、先頭に全社を表示する
            if (OperationHistoryAcs.Instance.SectionInfoDB.Tbl.Count > 1)
            {
                ui.Items.Add(new UIItemType(LogCondition.ALL_SECTION_CODE, LogCondition.ALL_SECTION_NAME), true);
                ExistsAllSection = true;
            }
            // 拠点マスタDBのレコードを全て表示する
            foreach (DataRowType row in OperationHistoryAcs.Instance.SectionInfoDB.Tbl)
            {
                ui.Items.Add(new UIItemType(row.SectionCode, row.SectionGuideNm));
            }
            // 1件のみの場合は操作不可とする
            if (ui.Items.Count.Equals(1)) ui.Enabled = false;
        }

        /// <summary>
        /// ItemCheckイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sectionCheckedListBox_ItemCheck(
            object sender,
            ItemCheckEventArgs e
        )
        {
            if (NowDoing) return;
            if (!ExistsAllSection) return;

            // 全社を選択した場合、その他のアイテムは未選択にする
            if (e.Index.Equals(ALL_SECTION_INDEX) && e.NewValue.Equals(CheckState.Checked))
            {
                NowDoing = true;

                for (int i = 1; i < UI.Items.Count; i++)
                {
                    UI.SetItemChecked(i, false);
                }

                NowDoing = false;
                return;
            }

            // 全社以外を選択した場合、全社を未選択にする
            if (!e.Index.Equals(ALL_SECTION_INDEX) && e.NewValue.Equals(CheckState.Checked))
            {
                NowDoing = true;

                UI.SetItemChecked(ALL_SECTION_INDEX, false);

                NowDoing = false;
                return;
            }

            // 何も選択されてない状態の場合、全社を選択する
            if (!e.NewValue.Equals(CheckState.Checked))
            {
                if (UI.CheckedItems.Count.Equals(1))
                {
                    NowDoing = true;

                    UI.SetItemChecked(ALL_SECTION_INDEX, true);

                    NowDoing = false;
                    return;
                }
            }
        }

        /// <summary>
        /// 選択された項目のリストを生成します。
        /// </summary>
        /// <returns>選択された項目のリスト</returns>
        public List<UIItemType> CreateCheckedItemList()
        {
            List<UIItemType> ret = new List<UIItemType>();

            foreach (object item in UI.CheckedItems)
            {
                ret.Add((UIItemType)item);
            }

            return ret;
        }
    }
}

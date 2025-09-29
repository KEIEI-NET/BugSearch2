//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���_UI�̐���
// �v���O�����T�v   : ���_UI�̐�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/08  �C�����e : �V�K�쐬
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
    /// ���_�A�C�e���𐧌䂷��N���X
    /// </summary>
    internal sealed class SectionItemController
    {
        /// <summary>�S�Ђ̃C���f�b�N�X</summary>
        private const int ALL_SECTION_INDEX = 0; // LITERAL:

        /// <summary>�S�Ђ����݂��邩���肷��t���O</summary>
        private bool _existsAllSection;
        /// <summary>
        /// �S�Ђ����݂��邩���肷��t���O���擾���܂��B
        /// </summary>
        /// <value>�S�Ђ����݂��邩���肷��t���O</value>
        private bool ExistsAllSection
        {
            get { return _existsAllSection; }
            set { _existsAllSection = value; }
        }

        /// <summary>UI</summary>
        private readonly UIType _ui;
        /// <summary>
        /// UI���擾���܂��B
        /// </summary>
        /// <value>UI</value>
        public UIType UI { get { return _ui; } }

        /// <summary>�������t���O</summary>
        private bool _nowDoing;
        /// <summary>
        /// �������t���O���擾���܂��B
        /// </summary>
        /// <value>�������t���O</value>
        private bool NowDoing
        {
            get { return _nowDoing; }
            set { _nowDoing = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SectionItemController(UIType ui)
        {
            _ui = ui;
            InitializeUI(_ui);

            _ui.ItemCheck += new ItemCheckEventHandler(this.sectionCheckedListBox_ItemCheck);
        }

        /// <summary>
        /// UI�����������܂��B
        /// </summary>
        private void InitializeUI(UIType ui)
        {
            // ���_�}�X�^DB��1����葽�����R�[�h������΁A�擪�ɑS�Ђ�\������
            if (OperationHistoryAcs.Instance.SectionInfoDB.Tbl.Count > 1)
            {
                ui.Items.Add(new UIItemType(LogCondition.ALL_SECTION_CODE, LogCondition.ALL_SECTION_NAME), true);
                ExistsAllSection = true;
            }
            // ���_�}�X�^DB�̃��R�[�h��S�ĕ\������
            foreach (DataRowType row in OperationHistoryAcs.Instance.SectionInfoDB.Tbl)
            {
                ui.Items.Add(new UIItemType(row.SectionCode, row.SectionGuideNm));
            }
            // 1���݂̂̏ꍇ�͑���s�Ƃ���
            if (ui.Items.Count.Equals(1)) ui.Enabled = false;
        }

        /// <summary>
        /// ItemCheck�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sectionCheckedListBox_ItemCheck(
            object sender,
            ItemCheckEventArgs e
        )
        {
            if (NowDoing) return;
            if (!ExistsAllSection) return;

            // �S�Ђ�I�������ꍇ�A���̑��̃A�C�e���͖��I���ɂ���
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

            // �S�ЈȊO��I�������ꍇ�A�S�Ђ𖢑I���ɂ���
            if (!e.Index.Equals(ALL_SECTION_INDEX) && e.NewValue.Equals(CheckState.Checked))
            {
                NowDoing = true;

                UI.SetItemChecked(ALL_SECTION_INDEX, false);

                NowDoing = false;
                return;
            }

            // �����I������ĂȂ���Ԃ̏ꍇ�A�S�Ђ�I������
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
        /// �I�����ꂽ���ڂ̃��X�g�𐶐����܂��B
        /// </summary>
        /// <returns>�I�����ꂽ���ڂ̃��X�g</returns>
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

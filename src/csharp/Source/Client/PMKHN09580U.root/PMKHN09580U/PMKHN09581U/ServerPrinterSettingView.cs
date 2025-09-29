//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j�r���[
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Windows.Forms.Other;

namespace Broadleaf.Windows.Forms
{
    using ControllerType= ServerPrinterSettingController;
    using DataSetType   = ServerPrinterSettingDataSet;
    using DataTableType = ServerPrinterSettingDataSet.SrvPrtStDataTable;
    using DataRowType   = ServerPrinterSettingDataSet.SrvPrtStRow;
    using RecordType    = PrtManage;

    /// <summary>
    /// �v�����^�ݒ�}�X�^�i�T�[�o�p�j�r���[�N���X
    /// </summary>
    public sealed class ServerPrinterSettingView : ServerConfigurationView
    {
        /// <summary>����</summary>
        private const string MY_NAME = "�v�����^�ݒ�}�X�^(�T�[�o�p)";  // LITERAL:

        #region <��ۃ����o>

        /// <summary>��̓I�ȃR���g���[��</summary>
        private ControllerType _myController;
        /// <summary>��̓I�ȃR���g���[�����擾���܂��B</summary>
        private ControllerType MyController
        {
            get
            {
                if (_myController == null)
                {
                    _myController = new ControllerType();
                }
                return _myController;
            }
        }

        /// <summary>
        /// ��̓I�ȕ\���e�[�u�����擾���܂��B
        /// </summary>
        private DataTableType MyViewTable
        {
            get { return MyController.DBEntity.SrvPrtSt; }
        }

        #endregion // </��ۃ����o>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ServerPrinterSettingView() : base()
        {
            Caption += MY_NAME;
        }

        #endregion // </Constructor>

        #region <Override>

        /// <summary>
        /// �T�[�o�\���ݒ�R���g���[���𐶐����܂��B
        /// </summary>
        /// <returns>�v�����^�ݒ�}�X�^�i�T�[�o�p�j�̃R���g���[��</returns>
        protected override IServerConfigurationController CreateController()
        {
            return MyController;
        }

        #region <�\���ݒ�>

        /// <summary>
        /// �B���J�������̃��X�g�𐶐����܂��B
        /// </summary>
        /// <returns>�B���J�������̃��X�g</returns>
        protected override List<string> CreateHideColumnNameList()
        {
            List<string> hideColumnNameList = new List<string>();
            {
                hideColumnNameList.Add(MyViewTable.CreateDateTimeColumn.ColumnName);    // �쐬����
                hideColumnNameList.Add(MyViewTable.UpdateDateTimeColumn.ColumnName);    // �X�V����
                hideColumnNameList.Add(MyViewTable.EnterpriseCodeColumn.ColumnName);    // ��ƃR�[�h
                hideColumnNameList.Add(MyViewTable.GUIDColumn.ColumnName);              // GUID
                hideColumnNameList.Add(MyViewTable.UpdEmployeeCpdeColumn.ColumnName);   // �X�V�]�ƈ��R�[�h
                hideColumnNameList.Add(MyViewTable.UpdAssemblyId1Column.ColumnName);    // �X�V�A�Z���u��ID1
                hideColumnNameList.Add(MyViewTable.UpdAssemblyId2Column.ColumnName);    // �X�V�A�Z���u��ID2
                hideColumnNameList.Add(MyViewTable.LogicalDeleteCodeColumn.ColumnName); // �_���폜�敪
                hideColumnNameList.Add(MyViewTable.PrinterKindColumn.ColumnName);       // �v�����^���

                if (!VisiblesDeletedData)
                {
                    hideColumnNameList.Add(MyViewTable.DeletedDateColumn.ColumnName);   // �폜��
                }
            }
            return hideColumnNameList;
        }

        /// <summary>
        /// �폜���J�����ł��邩���f���܂��B
        /// </summary>
        /// <param name="columnName">�J������</param>
        /// <returns>
        /// <c>true</c> :�폜���J�����ł��B<br/>
        /// <c>false</c>:�폜���J�����ł͂���܂���B
        /// </returns>
        protected override bool IsDeletedDateColumn(string columnName)
        {
            return columnName.Equals(MyViewTable.DeletedDateColumn.ColumnName);
        }

        #endregion // </�\���ݒ�>

        /// <summary>
        /// �V�K�o�^���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void OnNew(object sender, NewEventArgs e)
        {
            ShowDataInputDialog(PrtManageForm.EditMode.New);
        }

        /// <summary>
        /// �폜���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void OnDelete(object sender, DeleteEventArgs e)
        {
            RecordType foundRecord = MyController.Find(SelectedPrinterMngNo);
            if (foundRecord == null) return;

            if (EntityUtil.Deleted(foundRecord))
            {
                MessageBox.Show(
                    "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂��B",   // LITERAL:
                    Caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "�I�����Ă���s���폜���܂����H",   // LITERAL:
                Caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );
            if (result.Equals(DialogResult.Yes))
            {
                MyController.DoingRecord = foundRecord;
                MyController.DeleteRecord();
            }
        }

        /// <summary>
        /// �C�����܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void OnEdit(object sender, EditEventArgs e)
        {
            ShowDataInputDialog(PrtManageForm.EditMode.Update);
        }

        #endregion // </Override>

        /// <summary>
        /// �I������Ă���̃v�����^�Ǘ�No���擾���܂��B
        /// </summary>
        private int SelectedPrinterMngNo
        {
            get
            {
                try
                {
                    if (GridDB.Rows.Count > 0 && GridDB.SelectedRows.Count > 0)
                    {
                        return (int)GridDB.SelectedRows[0].Cells[MyViewTable.PrinterMngNoColumn.ColumnName].Value;
                    }
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
                catch (InvalidCastException)
                {
                    // �󔒂̍s���_�u���N���b�N�����ꍇ
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
                catch (NullReferenceException)
                {
                    // �󔒂̍s��I�����Ă����ꍇ
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
            }
        }

        /// <summary>
        /// �f�[�^�̓��̓_�C�A���O��\�����܂��B
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        private void ShowDataInputDialog(PrtManageForm.EditMode editMode)
        {
            // �v�����^�Ǘ�No���s��̏ꍇ�A�����I�ɐV�K���[�h�ɐݒ�
            if (SelectedPrinterMngNo.Equals(ServerPrinterSettingController.NULL_PRINTER_MNG_NO))
            {
                editMode = PrtManageForm.EditMode.New;
            }

            MyController.SetDoingRecord(SelectedPrinterMngNo);

            PrtManageForm dataInputForm = new PrtManageForm(MyController, editMode);
            {
                dataInputForm.ShowDialog(this);
            }
        }
    }
}

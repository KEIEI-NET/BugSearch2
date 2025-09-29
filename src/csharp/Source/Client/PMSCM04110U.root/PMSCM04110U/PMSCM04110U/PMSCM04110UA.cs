//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����󋵊m�F���C���t���[���N���X
// �v���O�����T�v   : �����󋵊m�F���C���t���[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/08/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/12   �C�����e : Redmine#43532
//                                   �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����󋵊m�F���C���t���[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����󋵊m�F���C���t���[���ł��B</br>
    /// <br>Programer  : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br>Update Note: 2014/09/12 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
    /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
    /// </remarks>
    public partial class PMSCM04110UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����󋵊m�F�R���X�g���N�^</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public PMSCM04110UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            //�����󋵊m�F�A�N�Z�X
            _synchConfirmAcs = new SynchConfirmAcs();
            //�������s�A�N�Z�X
            _synchExecuteAcs = new SynchExecuteAcs();

            grid_SynchConfirm.DataSource = _synchConfirmAcs.SynchConfirmDataTable;

        }
        # endregion

        # region �v���C�x�C�g�����o
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�����󋵊m�F�A�N�Z�X</summary>
        private SynchConfirmAcs _synchConfirmAcs;
        /// <summary>�������s�A�N�Z�X</summary>
        private SynchExecuteAcs _synchExecuteAcs;
        /// <summary>�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j</summary>
        private int _syncMode;
        /// <summary>�����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j</summary>
        private bool _isError;
        /// <summary>�G���[���������ԌÂ����ԁi��ʂŕ\���p�j</summary>
        private DateTime _errStTime;
        /// <summary>�G���[�X�e�[�^�X�i��ʂŕ\���p�j</summary>
        private int _errStatus;
        /// <summary>�G���[���e�i��ʂŕ\���p�j</summary>
        private string _errMessage;
        /// <summary>XML����̊֘A����}�X�^���</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOn;
        /// <summary>XML����̊֘A����}�X�^���</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOff;
        /// <summary>�ď�����</summary>
        public event EventHandler RetetEvent;

        /// <summary>�蓮����M</summary>
        private const int SYNC_MANUAL = 0;
        /// <summary>����M�ĊJ</summary>
        private const int SYNC_RESTART = 1;
        # endregion

        /// <summary>
        /// �t�H�[����Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �����󋵊m�F�R���X�g���N�^</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void PMSCM04110UA_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        /// <summary>
        /// timer1_Tick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            //�����Ǘ��}�X�^�����擾
            GetSyncMngData();
        }

        /// <summary>
        /// �����Ǘ��}�X�^���̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�����擾����</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/12 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43532</br>
        /// <br>           : �N���C�A���g���O�̏o�́A�A�C�R���̎w�E��Ή�����</br>
        /// </remarks>
        private int GetSyncMngData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            string errMessage = string.Empty;

            try
            {
                //�����Ǘ��}�X�^���̎擾
                status = _synchConfirmAcs.Search(this._enterpriseCode, out errMessage);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    //�֘A����}�X�^���
                    _tableIDDicForCheckOn = _synchConfirmAcs.TableIDDicForCheckOn;
                    _tableIDDicForCheckOff = _synchConfirmAcs.TableIDDicForCheckOff;
                    //�������[�h�i0�F�蓮���[�h�@1�F�ē������[�h�j
                    _syncMode = _synchConfirmAcs.SyncMode;
                    //�����G���[�L���itrue�F�G���[����@false�F�G���[�Ȃ��j
                    _isError = _synchConfirmAcs.IsError;
                    //�G���[���������ԌÂ����ԁi��ʂŕ\���p�j
                    _errStTime = _synchConfirmAcs.ErrStTime;
                    //�G���[�X�e�[�^�X�i��ʂŕ\���p�j
                    _errStatus = _synchConfirmAcs.ErrStatus;
                    //�G���[���e�i��ʂŕ\���p�j
                    _errMessage = _synchConfirmAcs.ErrMessage;

                    grid_SynchConfirm.Focus();
                    grid_SynchConfirm.Rows[0].Activate();
                    grid_SynchConfirm.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                WriteErrorLog(ex, "PMSCM04110UA.GetSyncMngData", status); // ADD 2014/09/12 �c���� Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (string.IsNullOrEmpty(errMessage))
                    {
                        errMessage = "�Y������f�[�^������܂���B";
                    }

                    WriteErrorLog(null, errMessage, status); // ADD 2014/09/12 �c���� Redmine#43532

                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                    errMessage, 0, MessageBoxButtons.OK);
                }
            }

            //�e�{�^���̐ݒ�
            setContorlEnable();

            return status;
        }

        /// <summary>
        /// �e�{�^���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�{�^���̐ݒ���s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void setContorlEnable()
        {
            if (_syncMode == SYNC_RESTART)
            {
                this.btn_SelectAll.Enabled = false; //�S�đI��
                this.btn_CancelAll.Enabled = false; //�S�ĉ���
                this.btn_ReRead.Enabled = false; //�ēǂݍ���

                SetGridEnable(false);

                btn_SelectAll_Click(this, null);

                string errorMessage = _errStTime.ToString("yyyy�NMM��dd�� HH:mm") + "�ȍ~ " + _errMessage + " ST=" + _errStatus + "\n�G���[����������Ɂu�đ��M�v�{�^���������Ă��������B";
                this.lable_ErrorMessage.Text = errorMessage;
                this.lable_ErrorMessage.Visible = true; //�G���[���e
            }
            else
            {
                this.btn_SelectAll.Enabled = true; //�S�đI��
                this.btn_CancelAll.Enabled = true; //�S�ĉ���
                this.btn_ReRead.Enabled = true; //�ēǂݍ���

                SetGridEnable(true);

                btn_CancelAll_Click(this, null);

                this.lable_ErrorMessage.Text = string.Empty;
                this.lable_ErrorMessage.Visible = false; //�G���[���e
            }
        }

        /// <summary>
        /// �O���b�h�I���\�̐ݒ�
        /// </summary>
        /// <param name="enable">�O���b�h����\�t���O</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�I���\�̐ݒ���s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetGridEnable(bool enable)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.grid_SynchConfirm.DisplayLayout.Bands[0].Columns;
            if (!enable)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
                {
                    column.CellActivation = Activation.Disabled;
                }
            }
            else
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
                {
                    column.CellActivation = Activation.ActivateOnly;
                }
            }
        }

        /// <summary>
        /// �f�[�^�O���b�h�̏�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �f�[�^�O���b�h�̏��������s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ColumnsCollection column = e.Layout.Bands[0].Columns;

            column[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.ErrorStatusColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.ErrorContentsColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.SyncCndtinStaColumn.ColumnName].Hidden = true;
            column[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Hidden = true;


            column[_synchConfirmAcs.SynchConfirmDataTable.TableNameColumn.ColumnName].Width = 350;
            column[_synchConfirmAcs.SynchConfirmDataTable.LastSyncUpdDtTmColumn.ColumnName].Width = 200;
            column[_synchConfirmAcs.SynchConfirmDataTable.SyncCndtinDivColumn.ColumnName].Width = 300;
            column[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Width = 100;

            column[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].CellAppearance.ImageHAlign = HAlign.Center;
        }

        /// <summary>
        /// �ēǂݍ��ݏ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ēǂݍ��ݏ������s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_ReRead_Click(object sender, EventArgs e)
        {
            int status = GetSyncMngData();

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                "�ēǂݍ��݂��������܂����B", 0, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ����M����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ����M�������s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_Synch_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (_synchConfirmAcs.SynchConfirmDataTable.Rows.Count == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                "���񓯊��������������Ă��܂���B\n���񓯊�������������A�m�F���s����悤�ɂȂ�܂��B", 0, MessageBoxButtons.OK);
                return;
            }

            if (_syncMode == SYNC_RESTART)
            {
                //�ē������[�h
                status = _synchExecuteAcs.SyncReqReExecute();
            }
            else
            {
                //�蓮�������[�h
                ArrayList tableIDList = new ArrayList();
                foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                {
                    if ((bool)row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] == true)
                    {
                        string tableID = row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString();

                        if (!tableIDList.Contains(tableID))
                        {
                            tableIDList.Add(tableID);
                        }
                    }
                }

                if (tableIDList.Count == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                    "�đ��M�e�[�u����I�����ĉ������B", 0, MessageBoxButtons.OK);
                    return;
                }

                //����M����
                status = _synchExecuteAcs.SyncReqExecuteForTable(this._enterpriseCode, tableIDList);
            }

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (RetetEvent != null)
                {
                    RetetEvent(this,null);
                }
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                "�đ��M�����ɐ������܂����B", 0, MessageBoxButtons.OK);

                GetSyncMngData();
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Text,
                "�đ��M�����Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��ʂ����</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �O���b�h�̑S�đI��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̑S�đI���������s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
            {
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = true;
            }
        }

        /// <summary>
        /// �O���b�h�̑S�ĉ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̑S�ĉ����������s��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void btn_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
            {
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = DBNull.Value;
                row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = false;
            }
        }

        /// <summary>
        /// �O���b�h�Ƀ_�u���N���b�N�ɂ��I����ON�AOFF���؂�ւ��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀ_�u���N���b�N�ɂ��I����ON�AOFF���؂�ւ��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow activeRow = grid_SynchConfirm.ActiveRow;
            SetSelectValue(activeRow);

            grid_SynchConfirm.UpdateData();
        }

        /// <summary>
        /// �O���b�h�ɑI����ON�AOFF���؂�ւ��
        /// </summary>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɑI����ON�AOFF���؂�ւ��</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetSelectValue(UltraGridRow row)
        {
            //�蓮���[�h�̂݁A�O���b�h��I������
            if (_syncMode == SYNC_MANUAL && row != null)
            {
                CellsCollection cells = row.Cells;

                string tableID = cells[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].Value.ToString();

                // �I��/��I���̐؂�ւ�
                if (cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value != DBNull.Value)
                {
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value = DBNull.Value;
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Value = false;

                    //�֘A����}�X�^�̔�I��
                    SetRelatedTblCheckOff(tableID);
                }
                else
                {
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    cells[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName].Value = true;

                    //�֘A����}�X�^�̑I��
                    SetRelatedTblCheckOn(tableID);
                }
            }
        }

        /// <summary>
        /// �֘A����}�X�^�̑I��ON
        /// </summary>
        /// <param name="mainTable">�e�[�u��ID</param>
        /// <param name="checkFlag"></param>
        /// <remarks>
        /// <br>Note       : �֘A����}�X�^�̑I��ON</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetRelatedTblCheckOn(string mainTable)
        {
            if (_tableIDDicForCheckOn.ContainsKey(mainTable))
            {
                foreach (ReferenceTable subTableID in _tableIDDicForCheckOn[mainTable])
                {
                    foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                    {
                        if (row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString().Equals(subTableID.ReferenceTableID))
                        {
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �֘A����}�X�^�̑I���̉���
        /// </summary>
        /// <param name="subTableID">�e�[�u��ID</param>
        /// <remarks>
        /// <br>Note       : �֘A����}�X�^�̑I���̉���</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void SetRelatedTblCheckOff(string subTableID)
        {
            if (_tableIDDicForCheckOff.ContainsKey(subTableID))
            {
                foreach (ReferenceTable mainTableID in _tableIDDicForCheckOff[subTableID])
                {
                    foreach (DataRow row in _synchConfirmAcs.SynchConfirmDataTable.Rows)
                    {
                        if (row[_synchConfirmAcs.SynchConfirmDataTable.TableIDColumn.ColumnName].ToString().Equals(mainTableID.ReferenceTableID))
                        {
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectDivColumn.ColumnName] = DBNull.Value;
                            row[_synchConfirmAcs.SynchConfirmDataTable.SelectionColumn.ColumnName] = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�Ɋe�L�[���������铮��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ɋe�L�[���������铮��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void grid_SynchConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (grid_SynchConfirm.ActiveRow != null)
            {
                int activeRowIndex = grid_SynchConfirm.ActiveRow.Index;

                switch (e.KeyCode)
                {
                    case Keys.Space://�X�y�[�X�L�[
                        {
                            UltraGridRow activeRow = grid_SynchConfirm.ActiveRow;
                            SetSelectValue(activeRow);

                            grid_SynchConfirm.UpdateData();
                            break;
                        }
                    case Keys.Left: //���L�[
                    case Keys.Right: //���L�[
                        {
                            e.Handled = true;
                            break;
                        }
                    case Keys.Up: //���L�[
                        {
                            if (activeRowIndex == 0)
                            {
                                this.btn_SelectAll.Focus();
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.grid_SynchConfirm.Rows[activeRowIndex - 1].Activate();
                                this.grid_SynchConfirm.Rows[activeRowIndex - 1].Selected = true;
                            }
                            break;
                        }
                    case Keys.Down: //���L�[
                        {
                            if (activeRowIndex == grid_SynchConfirm.Rows.Count - 1)
                            {
                                this.btn_ReRead.Focus();
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.grid_SynchConfirm.Rows[activeRowIndex + 1].Activate();
                                this.grid_SynchConfirm.Rows[activeRowIndex + 1].Selected = true;
                            }
                            break;
                        }

                }
            }
        }

        /// <summary>
        /// grid_SynchConfirm_Leave�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        private void grid_SynchConfirm_Leave(object sender, EventArgs e)
        {
            if (grid_SynchConfirm.ActiveRow != null)
            {
                grid_SynchConfirm.ActiveRow.Selected = false;
                grid_SynchConfirm.ActiveRow = null;
                grid_SynchConfirm.Invalidate();
            }
        }

        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note	   : ChangeFocus���ɔ������܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �O���b�h
            if (e.NextCtrl == this.grid_SynchConfirm)
            {
                switch (e.Key)
                {
                    case Keys.Up:
                        {
                            if (this.grid_SynchConfirm.Rows.Count != 0)
                            {
                                this.grid_SynchConfirm.Rows[this.grid_SynchConfirm.Rows.Count - 1].Activate();
                                this.grid_SynchConfirm.Rows[this.grid_SynchConfirm.Rows.Count - 1].Selected = true;
                            }
                            break;
                        }
                    case Keys.Down:
                    case Keys.Enter:
                    case Keys.Tab:
                        {
                            if (this.grid_SynchConfirm.Rows.Count != 0)
                            {
                                this.grid_SynchConfirm.Rows[0].Activate();
                                this.grid_SynchConfirm.Rows[0].Selected = true;
                            }
                            break;
                        }

                }
            }
        }

        //----- ADD 2014/09/12 �c���� Redmine#43532 ---------->>>>>
        #region [�G���[���O�o�͏���]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">errorText</param>
        /// <param name="status">status</param>
        /// <remarks>
        /// <br>Note       : �G���[���O�o�͏������s���B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date       : 2014/09/12</br>
        /// </remarks>
        public static void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output("PMSCM04110U", errorText, status);
            }
        }
        #endregion
        //----- ADD 2014/09/12 �c���� Redmine#43532 ----------<<<<<
    }
}
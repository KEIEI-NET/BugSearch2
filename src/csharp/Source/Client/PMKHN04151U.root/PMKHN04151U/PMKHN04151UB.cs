//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\���ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���[�����M����\��
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2010/06/02  �쐬�S�� : ������
// �C �� ��              �C�����e : Redmine#8992�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�����M����\���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����M����\�����s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br>Update Note: 2010/06/02 ������ Redmine#8992�Ή�</br>
    /// </remarks>
    public partial class PMKHN04151UB : UserControl
    {

        #region �� Private Members

        /// <summary>���[�����M����\���f�[�^�Z�b�g</summary>
        /// <remarks></remarks>
        private MailHisResultDataSet _dataSet;

        /// <summary>���[�����M����\���A�N�Z�X</summary>
        /// <remarks></remarks>
        private MailHistAcs _mailHistAcs;

        /// <summary>���[�����e�\���f�[�^�Z�b�g</summary>
        /// <remarks></remarks>
        private PMKHN04151UC _detailContentDis;

        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        #endregion

        #region �� Constroctors
        /// <summary>
        /// ���[�����M����\���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����M����\���N���X�R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UB()
        {
            InitializeComponent();
            this._mailHistAcs = MailHistAcs.GetInstance();
            this._dataSet = this._mailHistAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.MailHistResult;

        }
        #endregion

        #region �� Event
        /// <summary>
        /// �R���g���[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void PMKHN04151UB_Load(object sender, EventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            // �O���b�h�s�����ݒ菈��
            this.GridRowInitialSetting();

        }

        /// <summary>
        /// �O���b�h�̏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏������C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �O���b�h�L�[�_�E���C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            // �ŏ�s�ł́��L�[
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (this.GridKeyDownTopRow != null)
                    {
                        this.GridKeyDownTopRow(this, new EventArgs());
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;
                    }
                    
                }
            }
            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Home�L�[
            if (e.KeyCode == Keys.Home)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �擪�s�Ɉړ�
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // End�L�[
            if (e.KeyCode == Keys.End)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �ŏI�s�Ɉړ�
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }
        
        /// <summary>
        /// PMKHN04151UB_DoubleClick�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : PMKHN04151UB_DoubleClick�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        private void uGrid_Details_DoubleClick(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            //���[�����e�\����ʂ̕\��
            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            ShowMailContent(rowIndex);
        }
        #endregion

        #region �� Private Methods

        /// <summary>
        /// ���[�����e�\��
        /// </summary>
        /// <remarks>
        /// <param name="rowIndex">���׍s</param>
        /// <br>Note       : ���[�����e�\����ʂ��s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void ShowMailContent(int rowIndex)
        {
            string errMess = string.Empty;
            string textContent = string.Empty;
            int status = 0;

            string fileName = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.FileNameColumn.ColumnName].Value.ToString();
            
            status = this._mailHistAcs.GetMailHistDetail(fileName, out errMess, out textContent);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                QrMailHist _qrMailHist = new QrMailHist();
                //��M�Җ���
                _qrMailHist.EmployeeName = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Value.ToString();
                //CC���
                _qrMailHist.CCInfo = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.CCInfoColumn.ColumnName].Value.ToString();
                //����
                _qrMailHist.Title = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.TitleColumn.ColumnName].Value.ToString();
                //���M���t
                _qrMailHist.TransmitDate = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Value.ToString();
                //QR�R�[�h
                _qrMailHist.QRCode = this.uGrid_Details.Rows[rowIndex].Cells[this._dataSet.MailHistResult.QRCodeColumn.ColumnName].Value.ToString();
               
                _qrMailHist.MailText = textContent;

                _detailContentDis = new PMKHN04151UC(_qrMailHist);
                _detailContentDis.ShowDialog();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               this.Name,
                               "���[�����ݒ肪���݂��܂���B",
                               0,
                               MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               this.Name,
                               "���[����񂪑��݂��܂���B\r\n\r\n�ۑ���t�H���_�̐ݒ���m�F���ĉ������B",
                               0,
                               MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_STOP,
                               this.Name,
                               errMess,
                               0,
                               MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <param name="Columns">Columns</param>
        /// <br>Note       : �O���b�h�񏉊��ݒ菈�����s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// <br>Update Note: 2010/06/02 ������ Redmine#8992�Ή�</br>
        /// </remarks>
        private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            int visiblePosition = 1;
            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                //���͋��ݒ�
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            # region [�J�����ݒ�]
            //���M��
            // --------UPD 2010/06/02--------->>>>>
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Header.Caption = "���M��";
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Width = 200;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.MailHistResult.TransmitDateColumn.ColumnName].MaxLength = 10;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Header.Caption = "���M��";
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Width = 200;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.TransmitDateTimeColumn.ColumnName].MaxLength = 10;
            // --------UPD 2010/06/02---------<<<<<

            //��M��
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Header.Caption = "��M��";
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Width = 200;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.EmployeeNameColumn.ColumnName].MaxLength = 10;

            //QR
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Header.Caption = "QR";
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Width = 100;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.QRCodeDisplayColumn.ColumnName].MaxLength = 1;

            //����
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Header.Caption = "����";
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Width = 494;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MailHistResult.TitleColumn.ColumnName].MaxLength = 256;
            
            # endregion

        }

        /// <summary>
        /// �O���b�h�s�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�s�����ݒ���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataSet.MailHistResult.Rows.Clear();
        }

        /// <summary>
        /// �O���b�h�s�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�s�����ݒ���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public void ShowMailContent()
        {
            //���[�����e�\����ʂ̕\��
            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            ShowMailContent(rowIndex);
        }

        #endregion

    }
}
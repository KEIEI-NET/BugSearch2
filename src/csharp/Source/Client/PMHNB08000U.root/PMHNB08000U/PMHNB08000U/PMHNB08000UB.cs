//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����i�ԑI�����
// �v���O�����T�v   : ���i�������ʃf�[�^�Z�b�g�����ʕ\�����s���A�I�����ꂽ�艿�𔽉f������B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/10/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/11/13  �C�����e : redmine#1265 ����i�ԗL���敪�ݒ�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : ����
// �C �� ��  2010/02/04  �C�����e : PM1003�E�l������ ESC�{�^���ŉ�ʂ��I������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 21024�@���X�� ��
// �C �� ��  2010/11/01  �C�����e : �@�E�[�ɕ\������Ă���{�^����Tab�������A�t�H�[�J�X��������s����C��(MANTIS[0016549])
//                                  �AWindows�^�X�N�o�[�ɉ�ʂ��\�������s��̏C��(MANTIS[0016550])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �e�c ���V 						
// �C �� ��  2012/12/27  �C�����e : ���Еi�Ԉ󎚑Ή�				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �� �B 						
// �C �� ��  2013/01/09  �C�����e : ���Еi�Ԉ󎚑Ή��f�t�H���g�l�̕ύX
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �e�c ���V 						
// �C �� ��  2013/01/15  �C�����e : ���Еi�Ԉ󎚑Ή��t�H�[�J�X�ړ��s��Ή�				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �e�c ���V 						
// �C �� ��  2013/01/15  �C�����e : ���Еi�Ԉ󎚑Ή��d�l�ύX�Ή�				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  11070100-00 �쐬�S�� : �{�{ ����
// �C �� ��  2014/06/16  �C�����e : LDNS #37904 �Ή���(2014/06/05)���}�[�W
//----------------------------------------------------------------------------// 						
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����i�ԑI����ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ����i�ԑI����ʃt�H�[���N���X�ł��B</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2009/10/23</br>
    /// <br>Update Note : ����� 2009/11/13</br>
    /// <br>            : redmine#1265 ����i�ԗL���敪�ݒ�̒ǉ�</br>
    /// <br>Update Note : 2010/02/04 ����</br>
    /// <br>            : PM1003�E�l������ ESC�{�^���ŉ�ʂ��I������</br>
    /// </remarks>
    public partial class SelectionPrtGoodsNo : Form
    {
        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// ����i�ԑI�����UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����i�ԑI�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        public SelectionPrtGoodsNo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����i�ԑI�����UI�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsMakerName">���[�J�[����</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="partsInfoDataSet">���i�������ʃf�[�^�Z�b�g</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h�i���Ёj</param>
        /// <param name="goodsMakerName">���[�J�[���́i���Ёj</param>
        /// <param name="goodsNo">�i�ԁi���Ёj</param>
        /// <param name="goodsNo">���Еi�Ԉ󎚋敪</param>
        /// <param name="goodsNo">�󎚕i�ԏ����l</param>
        /// <remarks>
        /// <br>Note        : ����i�ԑI�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
        //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
        ////public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet)
        //public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet, int goodsMakerCode2, string goodsMakerName2, string goodsNo2, int epPartsNoPrtCd)
        //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
        public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet, int goodsMakerCode2, string goodsMakerName2, string goodsNo2, int epPartsNoPrtCd, int printGoodsNoDef)
        // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
        {
            InitializeComponent();

            this._goodsMakerCd = goodsMakerCode;
            this._goodsMakeNm = goodsMakerName;
            this._gooosNo = goodsNo;
            this._partsInfo = partsInfoDataSet;

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // ����
            this._goodsMakerCd2 = goodsMakerCode2;
            this._goodsMakeNm2 = goodsMakerName2;
            this._gooosNo2 = goodsNo2;

            this._epPartsNoPrtCd = epPartsNoPrtCd;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this._printGoodsNoDef = printGoodsNoDef;
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<

            // ������ʃf�[�^�ݒ�
            this.InitializeData();
        }

        #endregion

        #region �� private�萔 ��

        #endregion

        #region �� private�ϐ� ��
        // ���[�J�[�R�[�h
        int _goodsMakerCd = 0;
        // ���[�J�[����
        string _goodsMakeNm = string.Empty;
        // �i��
        string _gooosNo = string.Empty;
        // ���i�������ʃf�[�^�Z�b�g
        PartsInfoDataSet _partsInfo;

        private PartsDataSet _priceParts = null;
        PartsDataSet.PrintInfoDataTable _printInfoTable = null;
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        // ���[�J�[�R�[�h�i���Ёj
        int _goodsMakerCd2 = 0;
        // ���[�J�[���́i���Ёj
        string _goodsMakeNm2 = string.Empty;
        // �i�ԁi���Ёj
        string _gooosNo2 = string.Empty;
        // ���Еi�Ԉ󎚋敪
        int _epPartsNoPrtCd = 0; // 0:���Ȃ��@1:����
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        // ���Еi�Ԉ󎚋敪
        int _printGoodsNoDef = 0; // 0:�D��@1:���Ё@2:����
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        #endregion

        #region �� �R���g���[���C�x���g ��
        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;
            e.Layout.Override.RowSelectors = DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_PrintInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // �s�t�B���^�[�ݒ�
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // �����s�I����
            editBand.Layout.Override.SelectTypeRow = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.PrintInfoDataTable table = this._printInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // �O���b�h��\����\���ݒ菈��
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }
            columns[table.SelectButtonColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Header.Caption = "�I��";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "���[�J�[";


            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.Disabled;

            columns[table.GoodsNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Width = 70;
            columns[table.GoodsNoColumn.ColumnName].Width = 150;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 150;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // �{�^���ݒ�
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.SelectButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.SelectButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            switch (e.Cell.Column.Key)
            {
                // �I��
                case "SelectButton":
                    {
                        // 0:����
                        if (rowIndex == 0)
                        {
                            this.SetPrintInfo(0);
                        }
                        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        // 2:����
                        else if (rowIndex == 2)
                        {
                            this.SetPrintInfo(2);
                        }
                        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        // 1:�D��
                        else
                        {
                            this.SetPrintInfo(1);
                        }
                        break;
                    }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �I��ԍ�
                case "tEdit_SelectNo":
                    {
                        // ---DEL zhujw�@2014/06/05 ------------------------------------>>>>>
                        //// �I���Ƀt�H�[�J�X�������Ԃ�[Enter]�L�[����͂����ꍇ
                        //if (e.Key == Keys.Enter)
                        //{
                        //    int selectNo = Int32.Parse(this.tEdit_SelectNo.Text);
                        //    if (selectNo == 0)
                        //    {
                        //        // �m�菈�����s��
                        //        this.SetPrintInfo(0);
                        //    }
                        //    else if (selectNo == 1)
                        //    {
                        //        // �m�菈�����s��
                        //        this.SetPrintInfo(1);
                        //    }
                        //    // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        //    else if (selectNo == 2)
                        //    {
                        //        if (_epPartsNoPrtCd == 1)
                        //        {
                        //            // �m�菈�����s��
                        //            this.SetPrintInfo(2);
                        //        }
                        //        else
                        //        {
                        //            // �\���l���u1�v�Ƃ��A�S�I����ԂƂ���
                        //            this.tEdit_SelectNo.Text = "1";
                        //            e.NextCtrl = this.tEdit_SelectNo;
                        //        }
                        //    }
                        //    // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        //    else
                        //    {
                        //        // �\���l���u1�v�Ƃ��A�S�I����ԂƂ���
                        //        this.tEdit_SelectNo.Text = "1";
                        //        e.NextCtrl = this.tEdit_SelectNo;
                        //    }
                        //}
                        //else if (e.Key == Keys.Tab)
                        // ---DEL zhujw�@2014/06/05 ------------------------------------<<<<<
                        // ---ADD zhujw�@2014/06/05 ------------------------------------>>>>>
                        if (e.Key == Keys.Tab)
                        // ---ADD zhujw�@2014/06/05 ------------------------------------<<<<<
                        {
                            e.NextCtrl = this.uGrid_PrintInfo;
                        }
                        else if (e.Key == Keys.Up || e.Key == Keys.Down)
                        {
                            e.NextCtrl = this.tEdit_SelectNo;
                        }
                        // --- ADD 2014/06/16 T.Miyamoto ------------------------------>>>>>
                        else if (e.Key == Keys.Enter)
                        {
                            e.NextCtrl = this.tEdit_SelectNo;
                            //void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
                        }
                        // --- ADD 2014/06/16 T.Miyamoto ------------------------------<<<<<

                        break;
                    }
                // �O���b�h
                case "uGrid_PrintInfo":
                    {
                        if (this.uGrid_PrintInfo.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �O���b�h�^�u�ړ�����
                                this.SetGridTabFocus(ref e);
                            }

                            if (e.Key == Keys.Enter)
                            {
                                uGrid_PrintInfo_ClickCellButton(this.uGrid_PrintInfo, new CellEventArgs(uGrid_PrintInfo.ActiveCell));
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �O���b�h�V�t�g�^�u�ړ�����
                                this.SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "uGrid_PrintInfo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �O���b�h�^�u�ړ�����
                                this.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �O���b�h�^�u�ړ�����
                                this.SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                return;
            }

            int rowIndex = uGrid.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    {
                        uGrid_PrintInfo_ClickCellButton(this.uGrid_PrintInfo, new CellEventArgs(uGrid_PrintInfo.ActiveCell));
                        break;
                    }

                // --- UPD 2013/01/15 Y.Wakita ---------->>>>>
                //case Keys.Up:
                //case Keys.Down:
                //    {
                //        if (rowIndex == 0)
                //        {
                //            uGrid.Rows[1].Cells[0].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Rows[0].Cells[0].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                case Keys.Up:
                    {
                        // ���Еi�Ԉ󎚋敪���u����v�ꍇ
                        if (_epPartsNoPrtCd == 1)
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[2].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 1)
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 2)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    }

                case Keys.Down:
                    {
                        // ���Еi�Ԉ󎚋敪������ꍇ
                        if (_epPartsNoPrtCd == 1)
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 1)
                            {
                                uGrid.Rows[2].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 2)
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    
                    }
                // --- UPD 2013/01/15 Y.Wakita ----------<<<<<
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : Leave���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_Leave(object sender, EventArgs e)
        {
            this.uGrid_PrintInfo.ActiveCell = null;
            this.uGrid_PrintInfo.ActiveRow = null;
            this.uGrid_PrintInfo.Selected.Rows.Clear();
        }

        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : ���Closed���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        private void SelectionPrtGoodsNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
        }
        #endregion

        #region �� private���\�b�h ��
        /// <summary>
        /// ������ʃf�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        private void InitializeData()
        {
            this._priceParts = new PartsDataSet();
            this._printInfoTable = this._priceParts.PrintInfo;

            // [0:����]�s
            PartsDataSet.PrintInfoRow row = this._printInfoTable.NewPrintInfoRow();
            row[this._printInfoTable.SelectButtonColumn.ColumnName] = "0:����";
            row.GoodsNo = string.Empty;
            row.GoodsMakerCode = 0;
            row.GoodsMakerNm = string.Empty;
            this._printInfoTable.AddPrintInfoRow(row);

            // [1:�D��]�s
            row = this._printInfoTable.NewPrintInfoRow();
            row[this._printInfoTable.SelectButtonColumn.ColumnName] = "1:�D��";
            row.GoodsNo = this._gooosNo;
            row.GoodsMakerNm = this._goodsMakeNm;
            row.GoodsMakerCode = this._goodsMakerCd;
            this._printInfoTable.AddPrintInfoRow(row);

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // ���Еi�Ԉ󎚋敪������ꍇ
            if (_epPartsNoPrtCd == 1)
            {
                // [2:����]�s
                row = this._printInfoTable.NewPrintInfoRow();
                row[this._printInfoTable.SelectButtonColumn.ColumnName] = "2:����";
                row.GoodsNo = this._gooosNo2;
                // ���[�J�[�͔�\��
                //row.GoodsMakerNm = this._goodsMakeNm2;
                //row.GoodsMakerCode = this._goodsMakerCd2;
                row.GoodsMakerNm = string.Empty;
                row.GoodsMakerCode = 0;
                this._printInfoTable.AddPrintInfoRow(row);

                // �t�H�[���T�C�Y�ύX
                this.Size = new System.Drawing.Size(574, 160);
                // �ꗗ�T�C�Y�ύX
                this.uGrid_PrintInfo.Size = new System.Drawing.Size(558, 88);
                // �I�����ڈʒu�ύX
                this.ultraLabel1.Location = new System.Drawing.Point(455, 92);
                this.tEdit_SelectNo.Location = new System.Drawing.Point(500, 92);
            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // --- UPD 2013/01/09 T.Nishi ---------->>>>>
            //this.tEdit_SelectNo.Text = "1";
            //�󎚕i�ԏ����l�̒l�Ńf�t�H���g�l�ύX
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //if (_epPartsNoPrtCd == 1)//���Ђ̏ꍇ
            if (_printGoodsNoDef == 1)//���Ђ̏ꍇ
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            {
                this.tEdit_SelectNo.Text = "2";
            }
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //else if (_epPartsNoPrtCd == 2)//�����̏ꍇ
            else if (_printGoodsNoDef == 2)//�����̏ꍇ
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            {
                this.tEdit_SelectNo.Text = "0";
            }
            else//����ȊO�i�D�Ǖi�j�̏ꍇ
            {
                this.tEdit_SelectNo.Text = "1";
            }
            // --- UPD 2013/01/09 T.Nishi ----------<<<<<

            this._priceParts.AcceptChanges();
            this.uGrid_PrintInfo.DataSource = this._printInfoTable.DefaultView;
        }

        /// <summary>
        /// ����i�ԁA����p���[�J�[�R�[�h�A����p���[�J�[���̂̐ݒ�B
        /// </summary>
        /// <param name="mode">0:����;1:�D��</param>
        /// <remarks>
        /// <br>Note        : �I����e�ɏ]���A���i�������ʃf�[�^�Z�b�g�̈���i�ԁA����p���[�J�[�R�[�h�A����p���[�J�[���̂�ݒ肷��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// <br>Update Note : ����� 2009/11/13</br>
        /// <br>            : redmine#1265 ����i�ԗL���敪�ݒ�̒ǉ�</br>
        /// </remarks> 
        private void SetPrintInfo(int mode)
        {
            // 0:����
            if (mode == 0)
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    row.PrtGoodsNo = string.Empty;
                    row.PrtMakerCode = 0;
                    row.PrtMakerName = string.Empty;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 2:����
            else if (mode == 2)
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    // ����i�ԑI���̕i��(���i)�ɕ\�����Ă���i�Ԃ�ݒ�
                    row.PrtGoodsNo = (string)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsNoColumn.ColumnName].Value;
                    // ����i�ԑI���̃��[�J�[(���i)�ɑΉ����郁�[�J�[�R�[�h��ݒ�
                    row.PrtMakerCode = (int)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsMakerCodeColumn.ColumnName].Value;
                    // ����i�ԑI���̃��[�J�[(���i)�ɕ\�����Ă��郁�[�J�[���̂�ݒ�
                    row.PrtMakerName = (string)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsMakerNmColumn.ColumnName].Value;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // 1:�D��
            else
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    // ����i�ԑI���̕i��(���i)�ɕ\�����Ă���i�Ԃ�ݒ�
                    row.PrtGoodsNo = (string)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsNoColumn.ColumnName].Value;
                    // ����i�ԑI���̃��[�J�[(���i)�ɑΉ����郁�[�J�[�R�[�h��ݒ�
                    row.PrtMakerCode = (int)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsMakerCodeColumn.ColumnName].Value;
                    // ����i�ԑI���̃��[�J�[(���i)�ɕ\�����Ă��郁�[�J�[���̂�ݒ�
                    row.PrtMakerName = (string)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsMakerNmColumn.ColumnName].Value;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// �O���b�h�^�u�ړ�����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�^�u�ړ�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex = 0;
            int activationRowIndex = 0;

            if (this.uGrid_PrintInfo.ActiveCell == null)
            {
                // �A�N�e�B�u�Ȃ� �܂��� �s�A�N�e�B�u
                e.NextCtrl = null;
                this.uGrid_PrintInfo.Focus();

                int rowIndex = 0;

                if (this.uGrid_PrintInfo.ActiveRow != null)
                {
                    rowIndex = this.uGrid_PrintInfo.ActiveRow.Index;
                }

                nextFocusColumn = "SelectButton";
                activationRowIndex = rowIndex;

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_PrintInfo.ActiveCell.Row.Index;
                int colIndex = this.uGrid_PrintInfo.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                e.NextCtrl = null;
                this.uGrid_PrintInfo.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_PrintInfo.Focus();

                // 1�s�ڂ̍ŏ��̓��͉\�s�Ƀt�H�[�J�X
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }
            }
        }

        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�V�t�g�^�u������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/10/23</br>
        /// </remarks>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_PrintInfo.ActiveCell == null)
            {
                // �A�N�e�B�u�Ȃ� �܂��� �s�A�N�e�B�u
                e.NextCtrl = null;
                this.uGrid_PrintInfo.Focus();

                int colIndex = this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_PrintInfo.Rows.Count - 1;

                if (this.uGrid_PrintInfo.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_PrintInfo.ActiveRow.Index;
                }

                // 1�s�ڂ̍Ō�̓��͉\�s�Ƀt�H�[�J�X
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_PrintInfo.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_PrintInfo.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                e.NextCtrl = null;
                this.uGrid_PrintInfo.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_PrintInfo.Focus();

                // ���Z���擾
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }
            }
        }

        /// <summary>
        /// ���̓��͉\���Key���擾����
        /// </summary>
        /// <param name="colIndex">�`�F�b�N�J�n��index�AActivation�\���Ԃ�</param>
        /// <param name="rowIndex">�`�F�b�N�J�n�sindex�AActivation�\�s��Ԃ�</param>
        /// <param name="isShift">true:�V�t�g���� false:�V�t�g�Ȃ�</param>
        /// <param name="ActivationColIndex">Activation�\��Index</param>
        /// <param name="ActivationRowIndex">Activation�\�sIndex</param>
        /// <returns>Activation�\��̃L�[�B�Ȃ��ꍇ��string.Empty</returns>
        /// <remarks>
        /// <br>Note       : ���̓��͉\���Key���擾���s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/10/23</br>
        /// </remarks>
        private string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // �w���̎��̓��͉\�������
            if (!isShift)
            {
                // �V�t�g��
                for (int j = rowIndex; j < this.uGrid_PrintInfo.Rows.Count; j++)
                {
                    if (!this.uGrid_PrintInfo.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            // �w��s�͎w��J�����������`�F�b�N
                            for (int i = colIndex + 1; i < this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // ���s�ȍ~�̓J���������Ƀ`�F�b�N
                            for (int i = 0; i < this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // �V�t�g����
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_PrintInfo.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// �I���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/02/04</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^���͉B��Ă܂�
            // ESC�{�^���ŉ�ʂ��I������
            this.Close();
        }
        #endregion

        #region �� public���\�b�h ��
        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��ʕ\�����ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            // ��ʕ\��
            return base.ShowDialog(owner);
        }
        #endregion

        // ---ADD zhujw�@2014/06/05 ------------------------------------>>>>>
        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>fdsa
        /// <br>Note		: �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: zhujw</br>
        /// <br>Date		: 2014/06/04</br>
        /// </remarks>
        private void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13:

                    int selectNo = 0;
                    //�󔒂╶���񂪊܂܂��ꍇ��1:�D�ǂ������l�Ƃ��ăZ�b�g
                    if (Int32.TryParse(this.tEdit_SelectNo.Text, out selectNo) == false)
                    {
                        this.tEdit_SelectNo.Text = "1";
                        break;
                    }
                    if (selectNo == 0)
                    {
                        // �m�菈�����s��
                        this.SetPrintInfo(0);
                    }
                    else if (selectNo == 1)
                    {
                        // �m�菈�����s��
                        this.SetPrintInfo(1);
                    }
                    else if (selectNo == 2)
                    {
                        if (_epPartsNoPrtCd == 1)
                        {
                            // �m�菈�����s��
                            this.SetPrintInfo(2);
                        }
                        else
                        {
                            // �\���l���u1�v�Ƃ��A�S�I����ԂƂ���
                            this.tEdit_SelectNo.Text = "1";
                            this.tEdit_SelectNo.Focus();
                        }
                    }
                    else
                    {
                        // �\���l���u1�v�Ƃ��A�S�I����ԂƂ���
                        this.tEdit_SelectNo.Text = "1";
                        this.tEdit_SelectNo.Focus();
                    }
                    
                    break;
                default:
                    break;
            }
        }
        // ---ADD zhujw�@2014/06/05 ------------------------------------<<<<<
   }
}
//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PCC�i�ڐݒ�
// �v���O�����T�v   : PCC�i�ڐݒ� �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2013/05/30  �C�����e : 2013/99/99�z�M SCM��Q��10541�Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470103-00  �쐬�S�� : 杍^
// �� �� ��  2018/07/26   �C�����e : BL�p�[�c�I�[�_�[�����񓚕s��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;
using System.Collections;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �i�ڃO���b�h�ݒ�^�u�̃t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Node        : �i�ڃO���b�h�ݒ�^�u�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���C��</br>
    /// <br>Date        : 2011.07.20</br>
    /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2018/07/26</br>
    /// </remarks>
    public partial class PMPCC09040UB : UserControl
    {

        #region Constructor
        /// <summary>
        /// �i�ڃO���b�h�ݒ�^�u�t�H�[���R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�ڃO���b�h�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public PMPCC09040UB(string enterpriseCode, int startMode)
        {
            InitializeComponent();
            this._dsArry = new DataSet[GRIDCOUNT];
            this._dsAll = new DataSet();
            this.InitAllDateSet(PCCITEMST_TABLE);
            for (int gridNo = 0; gridNo < TablePanel_Grids.Controls.Count ; gridNo ++)
            {
                DataSet dataSet = this._dsArry[gridNo];
                UltraGrid ultraGridEach = TablePanel_Grids.Controls[gridNo] as UltraGrid;
                string name = ultraGridEach.Name;
                this.InitGrid(ref dataSet, ref ultraGridEach, gridNo);
            }
           
            _bLGoodsCdAcs = new BLGoodsCdAcs();
            _enterpriseCode = enterpriseCode;
            _startMode = startMode;
            //BL�R�[�h��񃊃X�g�擾
            GetBLGoodsCdUMntList();
        }
        #endregion

        #region Const Members
        /// <summary>PCC�i�ڐݒ�e�[�u��</summary>
        private const string PCCITEMST_TABLE = "PCCITEMST_TABLE";
        private const string PCCITEMST_TABLE2 = "PCCITEMST_TABLE2";
        private const string BLSELECT_TITLE = "SELECT";
        private const string BLGOODSCODE_TITLE = "BLCD";
        /// <summary>�K�C�h�{�^����</summary>
        private const string BLGUID_TITLE = "GUID";
        private const string BLGOODSNAME_TITLE = "���i��";
        private const string BLGOODSQTY_TITLE = "QTY";
        private const string BLGRIDNO_TITLE = "GRIDNO";

        private const string BLSELECT_NAME = "";
        private const string BLGOODSCODE_NAME = "BLCD";
        /// <summary>�K�C�h�{�^����</summary>
        private const string BLGUID_NAME = "";
        private const string BLGOODSNAME_NAME = "���i��";
        private const string BLGOODSQTY_NAME = "QTY";
        private const int MAXROW = 8;
        private const int MAXALLROW = 64;
        private const int GRIDCOUNT = 8;
        #endregion

        #region Private Members
        /// <summary>�O���b�h1�\���p�f�[�^�Z�b�g</summary>
        private DataSet [] _dsArry = null;
        private DataSet _dsAll = null;
        private string _enterpriseCode;
        private int _startMode;
        private UltraGrid _seletedUtraGrid = null;
        private int _gridNo = 0;

        private BLGoodsCdAcs _bLGoodsCdAcs;
        /// <summary>
        /// ��BL�R�[�h
        /// </summary>
        private int _beforeBLGoodsCode = 0;
        //�i�ڑI���敪Hashtable
        private Hashtable _blCheckedInfoTb = null;
        //�i��BL�R�[�h���Hashtable
        private Hashtable _bLGoodsCdUMntTb = null;
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
        /// <summary>
        /// �i�ڑI���敪Hashtable
        /// </summary>
        public Hashtable BlCheckedInfoTb
        {
            get
            {
                return this._blCheckedInfoTb;
            }
            set
            {
                this._blCheckedInfoTb = value;
            }
        }
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<

        #endregion

        #region Private Methods
         /// <summary>
        /// �O���b�h�̏�����
        /// </summary>
        /// <param name="tableName">�O���b�h����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitAllDateSet(string tableName)
        {
            if (this._dsAll.Tables[tableName] == null)
            {
                if (this._dsAll.Tables[tableName] == null)
                {
                    // �e�[�u���̒�`
                    DataTable dt1 = new DataTable(tableName);
                    dt1.Columns.Add(BLSELECT_TITLE, typeof(bool));
                    dt1.Columns.Add(BLGOODSCODE_TITLE, typeof(int));
                    dt1.Columns.Add(BLGUID_TITLE, typeof(string));
                    dt1.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
                    dt1.Columns.Add(BLGOODSQTY_TITLE, typeof(int));
                    dt1.Columns.Add(BLGRIDNO_TITLE, typeof(int));
                    this._dsAll.Tables.Add(dt1);
                }
            }

            if (this._dsAll.Tables[tableName] != null)
            {
                this._dsAll.Tables[tableName].Clear();
                for (int index = 0; index < MAXALLROW; index++)
                {

                    // �V�K�Ɣ��f���āA�s��ǉ�����
                    DataRow dataRow = this._dsAll.Tables[tableName].NewRow();
                    this._dsAll.Tables[tableName].Rows.Add(dataRow);
                    this._dsAll.Tables[tableName].Rows[index][BLSELECT_TITLE] = false;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSCODE_TITLE] = DBNull.Value;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSNAME_TITLE] = string.Empty;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSQTY_TITLE] = DBNull.Value;
                    this._dsAll.Tables[tableName].Rows[index][BLGRIDNO_TITLE] = index / GRIDCOUNT;
                }
            }
        }

        /// <summary>
        /// �O���b�h�̏�����
        /// </summary>
        /// <param name="dataSet">�O���b�h��DataSet</param>
        /// <param name="ultraGrid">�O���b�h</param>
        /// <param name="gridNo">�O���b�hNO</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2018/07/26</br>
        /// </remarks>
        private void InitGrid(ref DataSet dataSet, ref UltraGrid ultraGrid, int gridNo)
        {
            // �O���b�h�̏����ݒ菈��
            // �O���b�h�փo�C���h
            if (_dsAll.Tables[PCCITEMST_TABLE] != null)
            {
                dataSet = _dsAll.Copy();

                DataView dataView = dataSet.Tables[PCCITEMST_TABLE].DefaultView;
                dataView.RowFilter = BLGRIDNO_TITLE + " = " + gridNo;
                ultraGrid.DataSource = dataView;

                UltraGridBand editBand = ultraGrid.DisplayLayout.Bands[PCCITEMST_TABLE];
                ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //��̕\��Style�ݒ�
                editBand.Columns[BLSELECT_TITLE].Header.Caption = BLSELECT_NAME;
                editBand.Columns[BLGOODSCODE_TITLE].Header.Caption = BLGOODSCODE_NAME;
                editBand.Columns[BLGUID_TITLE].Header.Caption = BLGUID_TITLE;
                editBand.Columns[BLGOODSNAME_TITLE].Header.Caption = BLGOODSNAME_NAME;
                editBand.Columns[BLGOODSQTY_TITLE].Header.Caption = BLGOODSQTY_NAME;
                editBand.Columns[BLGRIDNO_TITLE].Header.Caption = BLGRIDNO_TITLE;
                //�O���b�h�^�C�v
                editBand.Columns[BLSELECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                editBand.Columns[BLGUID_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                
                //
                editBand.Columns[BLSELECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                editBand.Columns[BLGOODSCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                editBand.Columns[BLGUID_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                editBand.Columns[BLGOODSNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[BLGOODSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                editBand.Columns[BLGRIDNO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[BLGOODSNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                
               //�������l�̐ݒ�
                editBand.Columns[BLSELECT_TITLE].DefaultCellValue = false;
                editBand.Columns[BLGOODSCODE_TITLE].DefaultCellValue = DBNull.Value;
                editBand.Columns[BLGOODSNAME_TITLE].DefaultCellValue = string.Empty;
                editBand.Columns[BLGOODSQTY_TITLE].DefaultCellValue = DBNull.Value;
                editBand.Columns[BLGRIDNO_TITLE].DefaultCellValue = gridNo;
               this._beforeBLGoodsCode = 0;
               //�ҏW�O���b�h�O���[�v�ݒ�
               if (editBand == null)
               {
                   return;
               }
                
               editBand.Groups.Clear();
               // �O���[�v�w�b�_�̂ݕ\������悤�ɂ���
               editBand.ColHeadersVisible = false;
               if (gridNo >= (GRIDCOUNT / 2))
               {
                   editBand.GroupHeadersVisible = false;
               }
               else
               {
                   editBand.GroupHeadersVisible = true;
               }
               // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
               ////BL�I��
               //UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLSELECT_TITLE, editBand.Columns[BLSELECT_TITLE].Header.Caption);
               //ultraGridGroup.Columns.Add(editBand.Columns[BLSELECT_TITLE]);
               // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
               //BL�R�[�h�O���[�v
               // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
               //ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
               UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
               // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSCODE_TITLE]);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGUID_TITLE]);
               //BL����
               ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[BLGOODSNAME_TITLE].Header.Caption);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSNAME_TITLE]);
               //BL����
               ultraGridGroup = editBand.Groups.Add(BLGOODSQTY_TITLE, editBand.Columns[BLGOODSQTY_TITLE].Header.Caption);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSQTY_TITLE]);

               editBand.Columns[BLGRIDNO_TITLE].Hidden = true;
                
               // �{�^���̃X�^�C����ݒ肷��
               ImageList imageList16 = IconResourceManagement.ImageList16;
               editBand.Columns[BLGUID_TITLE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

               //editBand.Columns[BLSELECT_TITLE].Width = 10; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
               editBand.Columns[BLGOODSCODE_TITLE].Width = 50;
               editBand.Columns[BLGUID_TITLE].Width = 20;
               // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
               //editBand.Columns[BLGOODSNAME_TITLE].Width = 95;
               editBand.Columns[BLGOODSNAME_TITLE].Width = 113;
               // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
               editBand.Columns[BLGOODSQTY_TITLE].Width = 40;
               ultraGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

               //BL���i�R�[�h��NU�����ꍇ�A�i�ڑI���敪�A�i��QTY�͓��͕s��
               for (int rowIndex = 0; rowIndex < ultraGrid.Rows.Count; rowIndex++)
               {
                   UltraGridRow ultraGridRow = ultraGrid.Rows[rowIndex];
                   if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                   {
                       ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                       ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                   }
                   else
                   {
                       ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                       ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                   }
               }
            }
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pccItemSt">PCC�i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڐݒ���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemStToDataSet(PccItemSt pccItemSt)
        {
            if (pccItemSt == null)
            {
                return;
            }
            //�i�ڑI���敪 0:OFF 1:�I����޳�\��
            int rowIndex = pccItemSt.ItemDspPos1;
            int colIndex = pccItemSt.ItemDspPos2;
            int nowIndex = 0;
            if (colIndex >= MAXROW)
            {
                nowIndex = (rowIndex + GRIDCOUNT / 2 -1) * MAXROW + colIndex;
            }
            else
            {
                nowIndex = rowIndex * MAXROW + colIndex;
            }
            DataRow dataRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[nowIndex];
            bool itemSelectFlag = false;
            if (pccItemSt.ItemSelectDiv == 0)
            {
                itemSelectFlag = false;
            }
            else
            {
                itemSelectFlag = true;
            }
            dataRow[BLSELECT_TITLE] = itemSelectFlag;
            if (pccItemSt.BLGoodsCode == 0)
            {
                dataRow[BLGOODSCODE_TITLE] = DBNull.Value;
            }
            else
            {
                dataRow[BLGOODSCODE_TITLE] = pccItemSt.BLGoodsCode;
               
            }
            dataRow[BLGOODSNAME_TITLE] = pccItemSt.BLGoodsName;
            dataRow[BLGOODSQTY_TITLE] = pccItemSt.ItemQty;
        }

        /// <summary>
        /// PCC�i�ڂ̂W�O���b�h�W�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       :  PCC�i�ڂ̂W�O���b�h��W�J�������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GridGroupBy()
        {
            DataView[] dataViewArrys = new DataView[GRIDCOUNT];
            for (int daIndex = 0; daIndex < this._dsArry.Length; daIndex++)
            {
                int daIndexAdd = daIndex;
                UltraGrid ultraGrid = (UltraGrid)this.TablePanel_Grids.Controls[daIndex];
                dataViewArrys[daIndex] = this._dsAll.Copy().Tables[PCCITEMST_TABLE].DefaultView;
                dataViewArrys[daIndex].RowFilter = BLGRIDNO_TITLE + " = " + daIndexAdd;
                ultraGrid.DataSource = dataViewArrys[daIndex];
               //BL���i�R�[�h��NU�����ꍇ�A�i�ڑI���敪�A�i��QTY�͓��͕s��
                for (int rowIndex = 0; rowIndex < ultraGrid.Rows.Count; rowIndex++)
                {
                    UltraGridRow ultraGridRow = ultraGrid.Rows[rowIndex];
                    if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                    }
                    else
                    {
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                    }
                }
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MoveDownAllowEditCell(bool activeCellCheck, ref  UltraGrid ultraGrid, ref int gridNo, KeyEventArgs e)
        {
            bool performActionResult = false;
            string key = ultraGrid.ActiveCell.Column.Key;
            int rowIndex = ultraGrid.ActiveCell.Row.Index;
            int columnIndex = ultraGrid.ActiveCell.Column.Index;
            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                ultraGrid.BeginUpdate();
                if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                    (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                }
                switch (e.KeyCode)
                {
                    case Keys.Up :
                        {
                            if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                            && gridNo > 0)
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // �X�V�I���i�`��ĊJ�j
                                ultraGrid.EndUpdate(false);
                                gridNo = gridNo - 1;

                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[MAXROW - 1].Cells[key].Activate();
                                if ((ultraGrid.Rows[MAXROW - 1].Cells[key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                       (ultraGrid.Rows[MAXROW - 1].Cells[key].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                rowIndex = MAXROW - 1;
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == (MAXROW - 1) && gridNo < 7)
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // �X�V�I���i�`��ĊJ�j
                                ultraGrid.EndUpdate(false);
                                gridNo = gridNo + 1;
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;

                                ultraGrid.Focus();
                                ultraGrid.Rows[0].Cells[key].Activate();
                                if ((ultraGrid.Rows[0].Cells[key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                      (ultraGrid.Rows[0].Cells[key].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                rowIndex = 0;
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            if (ultraGrid.ActiveCell != null && gridNo == 0 && key.Equals(BLSELECT_TITLE) && rowIndex == 0)
                            {
                                return performActionResult;
                            }
                            if (ultraGrid.ActiveCell != null && key.Equals(BLSELECT_TITLE))
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // �X�V�I���i�`��ĊJ�j
                                ultraGrid.EndUpdate(false);
                                if (gridNo % (GRIDCOUNT / 2) == 0)
                                {
                                    rowIndex--;
                                    if (gridNo < (GRIDCOUNT / 2))
                                    {
                                        gridNo = (GRIDCOUNT / 2) -1;
                                    }
                                    else
                                    {
                                        gridNo = GRIDCOUNT -1;
                                    }
                                    if (rowIndex == -1)
                                    {
                                        rowIndex = MAXROW - 1;
                                        gridNo = (GRIDCOUNT / 2) - 1;
                                    }
                                }
                                else
                                {
                                    gridNo = gridNo - 1;
                                }
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activate();
                                 if ((ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                       (ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                 }
                                e.Handled = true;
                            }
                            break;
                        }
                    case Keys.Right:
                        {
                            if (ultraGrid.ActiveCell != null && gridNo == (GRIDCOUNT - 1) && key.Equals(BLGOODSQTY_TITLE) && rowIndex == MAXROW -1)
                            {
                                return performActionResult;
                            }
                            if (ultraGrid.ActiveCell != null && key.Equals(BLGOODSQTY_TITLE))
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // �X�V�I���i�`��ĊJ�j
                                ultraGrid.EndUpdate(false);
                                if (gridNo % (GRIDCOUNT / 2) == 3)
                                {
                                    rowIndex++;
                                    if (gridNo < (GRIDCOUNT / 2))
                                    {
                                        gridNo = 0;
                                    }
                                    else
                                    {
                                        gridNo = GRIDCOUNT / 2;
                                    }
                                    if (rowIndex == MAXROW)
                                    {
                                        rowIndex = 0;
                                        gridNo = GRIDCOUNT / 2;
                                    }
                                }
                                else
                                {
                                    gridNo++;
                                }
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activate();
                                e.Handled = true;
                            }
                            break;
                        }
                }
               

            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        /// <summary>
        /// ���������f
        /// </summary>
        /// <param name="str">������</param>
        /// <param name="charCount">������ʐ�</param>
        /// <returns>True:����; False:�񐔎�</returns>
        /// <remarks>
        /// <br>Note       : ���������f�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool IsDigitAdd(String str, int charCount)
        {

            string regex1 = "^[0-9]{0," + charCount + "}$";
            Regex objRegex = new Regex(regex1);
            return objRegex.IsMatch(str);
        }

        /// <summary>
        /// BL�R�[�h��񃊃X�g�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       :  BL�R�[�h��񃊃X�g�擾���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GetBLGoodsCdUMntList()
        {
            ArrayList bLGoodsCdUMntList = null;
            int status = _bLGoodsCdAcs.SearchAll(out bLGoodsCdUMntList, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                _bLGoodsCdUMntTb = new Hashtable();
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        _bLGoodsCdUMntTb.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt.BLGoodsHalfName);
                    }
                }
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// �O���b�h�̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���A�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>>
        public void ClearTable()
        {
            if (this._dsAll != null)
            {
                for (int index = 0; index < MAXALLROW; index++)
                {

                    // �V�K�Ɣ��f���āA�s��ǉ�����
                    DataRow dataRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[index];
                    dataRow[BLSELECT_TITLE] = false;
                    dataRow[BLGOODSCODE_TITLE] = DBNull.Value;
                    dataRow[BLGOODSNAME_TITLE] = string.Empty;
                    dataRow[BLGOODSQTY_TITLE] = DBNull.Value;
                    dataRow[BLGRIDNO_TITLE] = index / GRIDCOUNT;
                }
            }
            //PCC�i�ڂ̂W�O���b�h�W�J����
            GridGroupBy();
            SetInitFocus((int)PMPCC09040UA.StartMode.MODE_NEW);
        }

        /// <summary>
        /// PCC�i�ډ�ʓW�J����
        /// </summary>
        /// <param name="pccItemStList">PCC�i�ڐݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʓW�J�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void PccItemToGrid(List<PccItemSt> pccItemStList)
        {
            if (this._dsAll.Tables[PCCITEMST_TABLE] != null)
            {
                int index = 0;
                foreach (PccItemSt pccItemSt in pccItemStList)
                {
                    index = pccItemSt.ItemDspPos1;
                    PccItemStToDataSet(pccItemSt.Clone());
                   
                }
                //PCC�i�ڂ̂W�O���b�h�W�J����
                GridGroupBy();
            }
       

        }

        /// <summary>
        /// PCC�i�ډ�ʓW�J����
        /// </summary>
        /// <param name="pccItemStDic">PCC�i�ڐݒ胊�X�g</param>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="tabOrder">Tabb�ԍ�</param>
        /// <remarks>
        /// <br>Note       : ��ʓW�J�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2018/07/26</br>
        /// </remarks>
        public void GridToPccItem(out Dictionary<int, PccItemSt> pccItemStDic, PccItemGrid pccItemGrid, int tabOrder)
        {
            //PCC�i�ڐݒ�f�B�N�V���i���[�̏�����
            pccItemStDic = new Dictionary<int, PccItemSt>();
            //
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                int gridCount = ultraGridEach.Rows.Count;
                for (int i = 0; i < gridCount; i++)
                {
                    UltraGridRow dataRow = ultraGridEach.Rows[i];
                    PccItemSt pccItemSt = new PccItemSt();
                    if (dataRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        pccItemSt.BLGoodsCode = 0;
                        continue;
                    }
                    else
                    {
                        pccItemSt.BLGoodsCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                    }
                    pccItemSt.BLGoodsName = (string)dataRow.Cells[BLGOODSNAME_TITLE].Value;
                    //�i�ڕ\���ʒu1 ��(X)�����̈ʒu
                    int itemDspPos1 = 0;
                    int listDiv = 0;
                    if (gridNo >= (GRIDCOUNT / 2))
                    {
                        itemDspPos1 = gridNo - (GRIDCOUNT / 2);
                        //�i�ڕ\���ʒu2 �c(Y)�����̈ʒu
                        pccItemSt.ItemDspPos2 = i + MAXROW;
                        listDiv = (itemDspPos1 + ((GRIDCOUNT / 2))) * MAXROW + i;
                    }
                    else
                    {
                        itemDspPos1 = gridNo;
                        pccItemSt.ItemDspPos2 = i;
                        listDiv = itemDspPos1 * MAXROW + i;
                    }
                    pccItemSt.ItemDspPos1 = itemDspPos1;

                    // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
                    //int itemSelectDiv = 0;
                    //if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    //{
                    //    itemSelectDiv = 0;
                    //}
                    //else
                    //{
                    //    if (!(bool)dataRow.Cells[BLSELECT_TITLE].Value)
                    //    {
                    //        itemSelectDiv = 0;
                    //    }
                    //    else
                    //    {
                    //        itemSelectDiv = 1;
                    //    }
                    //}
                    //pccItemSt.ItemSelectDiv = itemSelectDiv;
                    pccItemSt.ItemSelectDiv = 1;
                    // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<

                    int itemQty = 0;
                    if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    {
                        itemQty = 0;

                    }
                    else
                    {
                        itemQty = (int)dataRow.Cells[BLGOODSQTY_TITLE].Value;
                    }
                    pccItemSt.ItemQty = itemQty;
                    pccItemSt.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemSt.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                    pccItemSt.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                    pccItemSt.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                    pccItemSt.PccCompanyCode = pccItemGrid.PccCompanyCode;
                    pccItemSt.ItemGroupCode = tabOrder;

                    
                  
                    pccItemStDic.Add(listDiv, pccItemSt);
                }
            }
        }

        /// <summary>
        /// BL�R�[�h�`�F�b�N�e�v�b���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�`�F�b�N�e�v�b���擾����</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void InitBlCheckedTb()
        {
            //_blCheckedInfoTb = new Hashtable(); // DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
            if (_blCheckedInfoTb == null)
            {
                _blCheckedInfoTb = new Hashtable();
            }
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                int gridCount = ultraGridEach.Rows.Count;
                for (int i = 0; i < gridCount; i++)
                {
                    UltraGridRow dataRow = ultraGridEach.Rows[i];
                    int blCode = 0;
                    if (dataRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        blCode = 0;
                        continue;
                    }
                    else
                    {
                        blCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                    }


                    bool itemSelectDiv = false;
                    if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    {
                        itemSelectDiv = false;
                    }
                    else
                    {
                        itemSelectDiv = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                    }
                    if (!_blCheckedInfoTb.ContainsKey(blCode))
                    {
                        _blCheckedInfoTb.Add(blCode, itemSelectDiv);
                    }
                }
            }
        }

        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
        /// <summary>
        /// BL�R�[�h�`�F�b�N�X�V����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�`�F�b�N�X�V����</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void SetBlChecked()
        {
            if (_blCheckedInfoTb != null)
            {
                //����BL�R�[�h�̑I���X�V
                for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                    {
                        continue;
                    }
                    int gridCount = ultraGridEach.Rows.Count;
                    for (int i = 0; i < gridCount; i++)
                    {
                        UltraGridRow dataRow = ultraGridEach.Rows[i];
                        int blGroupCode = 0;
                        if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
                        {
                            blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            if (_blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
                            {
                                bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                                bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
                                if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
                                {
                                    dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
                                }
                            }
                        }
                        
                    }
                }

            }
        }
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<

        /// <summary>
        /// ��ʃO���b�h�ҏW�����䏈��
        /// </summary>
        /// <param name="enabled">���͋��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̃O���b�h�ҏW�𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void PermissionControl(bool enabled)
        {
             //
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                ultraGridEach.Enabled = enabled;
            }
        }

        /// <summary>�^�u�\���̏����t�H�[�J�X�̐ݒ�</summary>
        /// <param name="startMode">��W�^��旷�s�@�}�l�[�W�����g�N���X</param>
        /// <remarks>
        /// Note       : �^�u�\���̏����t�H�[�J�X��ݒ肵�܂�<br />
        /// Programmer : ���C��<br />
        /// Date       : 2011.07.20<br />
        /// </remarks>
        public void SetInitFocus(int startMode)
        {
            this._startMode = startMode;
            // �_���폜�f�[�^�ȊO�̏ꍇ
            if (this._startMode != (int)PMPCC09040UA.StartMode.MODE_EDITLOGICDELETE)
            {
                for (int gridNo = 0; gridNo < TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach.Rows.Count > 0)
                    {
                        ultraGridEach.ActiveCell = null;
                        // �X�V�I���i�`��ĊJ�j
                        ultraGridEach.EndUpdate(false);
                    }
                }
            }
            UltraGrid ultraGrid = TablePanel_Grids.Controls[0] as UltraGrid;
            ultraGrid.Focus();
        }

        #region ReturnKeyDown
        /// <summary>
        /// ReturnKey��������(�O���b�h��)
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <remarks>
        /// <br>Note       : ReturnKey�����������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e, int mode, ref  UltraGrid ultraGrid, int gridNo)
        {

            if (ultraGrid.Rows.Count > 0)
            {
                if ((ultraGrid.ActiveCell == null) && (ultraGrid.ActiveRow == null))
                {
                    ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                }

                string columnKey;
                int rowIndex;

                if (ultraGrid.ActiveCell != null)
                {
                    columnKey = ultraGrid.ActiveCell.Column.Key;
                    rowIndex = ultraGrid.ActiveCell.Row.Index;
                }
                else
                {
                    columnKey = BLGOODSCODE_TITLE;
                    rowIndex = ultraGrid.ActiveRow.Index;
                }

                e.NextCtrl = null;

                ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                if (ultraGrid.ActiveCell != null)
                {
                    MoveNextAllowEditCell(false, ref ultraGrid, gridNo);
                }
                else if(ultraGrid.ActiveRow != null)
                {
                    ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck, ref  UltraGrid ultraGrid, int gridNo)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                ultraGrid.BeginUpdate();

                if ((activeCellCheck) && (ultraGrid.ActiveCell != null))
                {
                    if ((!ultraGrid.ActiveCell.Column.Hidden) &&
                        (ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == ultraGrid.Rows.Count - 1
                        && ultraGrid.ActiveCell.Column.Key == BLGOODSQTY_TITLE && gridNo < (GRIDCOUNT - 1))
                    {
                        ultraGrid.ActiveCell = null;
                        // �X�V�I���i�`��ĊJ�j
                        ultraGrid.EndUpdate(false);
                        ultraGrid = this.TablePanel_Grids.Controls[gridNo + 1] as UltraGrid;
                        //BLCD
                        int blCd = 0;
                        if (ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        if (blCd == 0)
                        {
                            ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                        }
                        else
                        {
                            ultraGrid.Rows[0].Cells[BLSELECT_TITLE].Activate();
                        }
                        this._gridNo = gridNo + 1;
                        moved = true;
                    }

                    else
                    {
                        //BLCD
                        int blCd = 0;
                        if (ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        //��O���b�h�̑��s
                        if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == MAXROW - 1
                            && ultraGrid.ActiveCell.Column.Key == BLGOODSCODE_TITLE && blCd == 0 && this._gridNo == (GRIDCOUNT - 1))
                        {
                            moved = false;
                            break;
                        }
                        performActionResult = ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                        if (performActionResult)
                        {
                            if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                            {
                                moved = true;
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (moved)
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        #endregion ReturnKeyDown

        #region ShiftKeyDown
        /// <summary>
        /// ShiftKey��������(�O���b�h��)
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <param name="mode">���[�h</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <remarks>
        /// <br>Note       : ShiftKey�����������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e, int mode, ref  UltraGrid ultraGrid, int gridNo)
        {

            if ((ultraGrid.ActiveCell == null) && (ultraGrid.ActiveRow == null))
            {
                ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
            }

            string columnKey;
            int rowIndex;

            if (ultraGrid.ActiveCell != null)
            {
                columnKey = ultraGrid.ActiveCell.Column.Key;
                rowIndex = ultraGrid.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = BLGOODSCODE_TITLE;
                rowIndex = ultraGrid.ActiveRow.Index;
            }

            e.NextCtrl = null;

            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            if (ultraGrid.ActiveCell != null)
            {
                MovePreAllowEditCell(false, ref ultraGrid, gridNo);
            }
            else if (ultraGrid.ActiveRow != null)
            {
                ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                this._gridNo = gridNo;
            }
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �O���͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool activeCellCheck, ref UltraGrid ultraGrid, int gridNo)
        {
            bool moved = false;
            bool performActionResult = false;
            //BLCD
            int blCd = 0;
            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                ultraGrid.BeginUpdate();

                if ((activeCellCheck) && (ultraGrid.ActiveCell != null))
                {
                    if ((!ultraGrid.ActiveCell.Column.Hidden) &&
                        (ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                                    && ultraGrid.ActiveCell.Column.Key == BLSELECT_TITLE && gridNo > 0)
                    {
                        ultraGrid.ActiveCell = null;
                        // �X�V�I���i�`��ĊJ�j
                        ultraGrid.EndUpdate(false);
                        ultraGrid = this.TablePanel_Grids.Controls[gridNo - 1] as UltraGrid;
                        ultraGrid.Focus();

                        if (ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        if (blCd == 0)
                        {
                            ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Activate();
                        }
                        else
                        {
                            ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSQTY_TITLE].Activate();
                        }
                        this._gridNo = gridNo - 1;

                        moved = true;
                    }
                    else
                    {
                        //BLCD
                        blCd = 0;
                        if (ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        //��O���b�h�̑��s
                        if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                            && ultraGrid.ActiveCell.Column.Key == BLGOODSCODE_TITLE && blCd == 0 && this._gridNo == 0)
                        {
                            moved = false;
                            break;
                        }
                        performActionResult = ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                        if (performActionResult)
                        {

                            if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                            {
                                moved = true;
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (moved)
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        #endregion ShiftKeyDown

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �摜�ԍ��R���{�ݒ�
        /// </summary>
        /// <param name="itemGrpImgCode">�i�ڃO���[�v�摜�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �摜�ԍ��R���{�ɒl��ݒ肷��</br>
        /// <br>Programmer : �O�� �L��</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public void ImageComboSet(short itemGrpImgCode)
        {
            try
            {
                this.tComboEditor_ImageIDX.Value = itemGrpImgCode;
            }
            catch
            {
                this.tComboEditor_ImageIDX.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// �摜�ԍ��R���{�̒l�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �摜�ԍ��R���{�ɒl��ݒ肷��</br>
        /// <br>Programmer : �O�� �L��</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public short GetItemGrpImgCode()
        {
            if (this.tComboEditor_ImageIDX.Value == null) return 0;
            return short.Parse(this.tComboEditor_ImageIDX.Value.ToString());
        }
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion
      
        #region �C�x���g

        #region �K�C�h�{�^���N���b�N�C�x���g

        /// <summary>
        /// �K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �{�^�����N���b�N���ꂽ�ۂ̃C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            UltraGridRow activeRow = ug.ActiveRow;

            //BL�R�[�h�K�C�h
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BL�R�[�h�K�C�h�N��
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }
            else
            {
                activeRow.Cells[BLGOODSCODE_TITLE].Value = bLGoodsCdUMnt.BLGoodsCode;
                activeRow.Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                activeRow.Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                activeRow.Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
            }
            ug.PerformAction(UltraGridAction.ExitEditMode);
            ug.PerformAction(UltraGridAction.CommitRow);
        }

        #endregion

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g��̃C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            UltraGridCell cell = e.Cell;
            int rowIndex = e.Cell.Row.Index;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                int blCode = 0;
                if (cell.Value != null && cell.Value != DBNull.Value)
                {
                    blCode = (int)cell.Value; ;
                }
                if (blCode != 0)
                {
                    //BL�R�[�h�K�C�h�N��
                    if (_beforeBLGoodsCode != blCode)
                    {
                        if (this._bLGoodsCdUMntTb != null && this._bLGoodsCdUMntTb.ContainsKey(blCode))
                        {
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = (string)this._bLGoodsCdUMntTb[blCode];
                            this._beforeBLGoodsCode = blCode;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                            bool blChecked = false;
                            if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blCode))
                            {
                                blChecked = (bool)_blCheckedInfoTb[blCode];
                            }
                            ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Value = blChecked;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "BL�R�[�h [" + blCode.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                            // BL�R�[�h�����ɖ߂�
                           cell.Value = this._beforeBLGoodsCode;
                           
                        }
                    }
                }
                else
                {
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                    ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Value = false;
                    this._beforeBLGoodsCode = 0;
                }
            }
            //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
            ////�I������
            //else if (cell.Column.Key == BLSELECT_TITLE)
            //{
            //    //Bl�R�[�h
            //    int blCode = 0;
            //    bool blChecked = (bool)cell.Value;
            //    if (ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != null)
            //    {
            //        blCode = (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value;
            //    }
            //    if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blCode))
            //    {
            //        _blCheckedInfoTb.Remove(blCode);
            //        _blCheckedInfoTb.Add(blCode, blChecked);
            //        //����BL�R�[�h�̑I���X�V
            //        for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            //        {
            //            UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
            //            if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
            //            {
            //                continue;
            //            }
            //            int gridCount = ultraGridEach.Rows.Count;
            //            for (int i = 0; i < gridCount; i++)
            //            {
            //                UltraGridRow dataRow = ultraGridEach.Rows[i];
            //                int blGroupCode = 0;
            //                if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
            //                {
            //                    blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
            //                    if (blGroupCode != blCode)
            //                    {
            //                        continue;
            //                    }
            //                }
            //                if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
            //                {
            //                    bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
            //                    bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
            //                    if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
            //                    {
            //                        dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
            //                    }
            //                }
            //            }
            //        }

            //    }
            //    else
            //    {
            //        if (this._blCheckedInfoTb == null)
            //        {
            //            _blCheckedInfoTb = new Hashtable();
            //        }
            //        _blCheckedInfoTb.Add(blCode, blChecked);
            //    }
            //}
            //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
        }

        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g��̃C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            UltraGridCell cell = e.Cell;
            int rowIndex = e.Cell.Row.Index;
            //�I������
            if (cell.Column.Key == BLSELECT_TITLE)
            {
              
                //Bl�R�[�h
                int blCode = 0;
                ultraGrid.UpdateData();
                bool blChecked = (bool)cell.Value;
                if (ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != null)
                {
                    blCode = (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value;
                }
                if (this._blCheckedInfoTb == null)
                {
                    _blCheckedInfoTb = new Hashtable();
                }
                if(!_blCheckedInfoTb.ContainsKey(blCode))
                {
                    _blCheckedInfoTb.Add(blCode, blChecked);
                }
                else
                {
                    _blCheckedInfoTb.Remove(blCode);
                    _blCheckedInfoTb.Add(blCode, blChecked);
                }
                    //����BL�R�[�h�̑I���X�V
                for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                    {
                        continue;
                    }
                    int gridCount = ultraGridEach.Rows.Count;
                    for (int i = 0; i < gridCount; i++)
                    {
                        UltraGridRow dataRow = ultraGridEach.Rows[i];
                        int blGroupCode = 0;
                        if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
                        {
                            blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            if (blGroupCode != blCode)
                            {
                                continue;
                            }
                        }
                        if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
                        {
                            bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                            bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
                            if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
                            {
                                dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
                            }
                        }
                    }
                }
            }
        }
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
        
        /// <summary>
        ///  �O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       :  �O���b�h�Z���A�b�v�f�[�g�O�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            //BL�R�[�h
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                this._beforeBLGoodsCode = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
        }

        #region Grid��MouseUp �C�x���g

        /// <summary>
        ///  Grid��MouseUp �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       :  Grid��MouseUp �C�x���g�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_MouseUp(object sender, MouseEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            if (ug != null && e.Button == MouseButtons.Right)
            {
                Infragistics.Win.UIElement aUIElement = ug.DisplayLayout.UIElement.ElementFromPoint(
                                 new Point(e.X, e.Y));

                if (aUIElement == null) return;

                // ���O�s
                UltraGridRow aRow = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));
                // ���Ocell
                UltraGridCell aCell = (UltraGridCell)aUIElement.GetContext(typeof(UltraGridCell));

                if (aCell != null && aCell.Column.Index > 2 && ug.ActiveCell != null)
                {
                    // �I�����ꂽ�s���N���A����
                    if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                    {
                        ug.Selected.Rows.Clear();
                    }
                    // ���OCell��I������
                    aCell.Activated = true;
                    aCell.Selected = true;
                }
                else
                {
                    if (aCell != null && ug.ActiveCell != null
                        && ((ug.ActiveCell.Column.Index > 2 && aCell.Column.Index <= 2)
                            || (ug.ActiveCell.Column.Index <= 2 && aCell.Column.Index > 2)))
                    {
                        return;
                    }
                    
                    if (aRow != null)
                    {
                        // ���O�s�͑I�����ꂽ�s���ǂ����t���b�O
                        bool inSel = false;
                        if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                        {
                            foreach (UltraGridRow row in ug.Selected.Rows)
                            {
                                if (row.Index == aRow.Index)
                                {
                                    inSel = true;
                                }
                            }
                        }

                        // ���O�s�͑I�����ꂽ�s�ł͂Ȃ�
                        if (!inSel)
                        {
                            // �I�����ꂽ�s���N���A����
                            if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                            {
                                ug.Selected.Rows.Clear();
                            }

                            // ���O�s��I������
                            aRow.Activated = true;
                            aRow.Selected = true;
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// �O���b�h�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�V���������㎞�ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    UltraGridCell ugCell = ultraGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (ultraGrid.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (ultraGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((ultraGrid.ActiveCell.Value is System.DBNull) ||
                                            (ultraGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (ultraGrid.ActiveCell.IsInEditMode)
                                            {
                                                // �S�I��
                                                ultraGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Button:
                                {
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    ultraGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        #region KeyUp�C�x���g
        /// <summary>
        /// KeyUp�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[��b�����ۂ̃C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            // Space�L�[����
            if (e.KeyCode == Keys.Space)
            {
                UltraGrid ultraGrid = (UltraGrid)sender;
                if (ultraGrid == null)
                {
                    return;
                }
                // �����O���[�v�ꗗ�O���b�h
                else
                {
                    if (ultraGrid.ActiveCell == null)
                    {
                        return;
                    }

                    CellEventArgs cellE = null;
                    // �����ꏊ���K�C�h�{�^���������ꍇ�̓K�C�h�N��
                    if ((ultraGrid != null) && (ultraGrid.ActiveCell.Column.ToString().Trim() == BLGUID_TITLE.Trim()))
                    {
                        // �J���[�K�C�h�R�[���C�x���g
                        PccItemSt_UltraGrid_ClickCellButton(sender, cellE);
                    }
                }
            }
        }
        #endregion

        #region �c�[���o�[���A�C�e���I���C�x���g
        /// <summary>
        /// �c�[���o�[���A�C�e���I���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[���̃A�C�e����I��(�N���b�N)�����ۂɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void Grid_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �_���폜�f�[�^�̏ꍇ
           
            if (this._startMode == (int)PMPCC09040UA.StartMode.MODE_EDITLOGICDELETE)
            {
                return;
            }
            if (this._seletedUtraGrid == null)
            {
                return;
            }

            // �J�[�\���ύX
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                //���8�x�O���b�h�̒l���擾
                int gridEachNo = 0;
                int gridAllRowIndex = 0;
                foreach (Control ctr in TablePanel_Grids.Controls)
                {
                    UltraGrid uGrid = ctr as UltraGrid;
                    if (uGrid != null)
                    {
                        for (int i = 0; i < uGrid.Rows.Count; i++)
                        {
                            UltraGridRow dataRow = uGrid.Rows[i];
                            gridAllRowIndex = i + gridEachNo * MAXROW;
                            DataRow drAll = this._dsAll.Tables[PCCITEMST_TABLE].Rows[gridAllRowIndex];
                            //�i�ڑI���敪
                            drAll[BLSELECT_TITLE] = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                            //BL���i�R�[�h
                            if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                            {
                                drAll[BLGOODSCODE_TITLE] = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            }
                            //BL���i��
                            drAll[BLGOODSNAME_TITLE] = (string)dataRow.Cells[BLGOODSNAME_TITLE].Value;
                            //�i��QTY
                            if (dataRow.Cells[BLGOODSQTY_TITLE].Value != DBNull.Value)
                            {
                                drAll[BLGOODSQTY_TITLE] = (int)dataRow.Cells[BLGOODSQTY_TITLE].Value;
                            }

                        }
                        gridEachNo++;
                    }
                }
                //�I�������O���b�h
                UltraGrid uGridSelected = this._seletedUtraGrid;
                //���8�x�O���b�h�̒l���擾
                int gridNo = _gridNo;
                if (uGridSelected.ActiveCell != null)
                {
                    int rowIndex = uGridSelected.ActiveCell.Row.Index;
                    uGridSelected.Rows[rowIndex].Selected = true;
                }
                // �s�ǉ�
                if (e.Tool.Key == "Add_BtnTool")
                {
                    
                    // �s�ǉ��C�x���g
                    if (uGridSelected.Selected != null
                        && uGridSelected.Selected.Rows.Count > 0)
                    {
                        int insertIndex = StartInsertIndex(uGridSelected);
                        int insertIndexOld = insertIndex;
                        for (int i = 0; i < uGridSelected.Selected.Rows.Count; i++)
                        {
                            UltraGridRow row = uGridSelected.Rows.TemplateAddRow;
                            insertIndex = insertIndex  + gridNo * MAXROW;
                        }
                        DataRow dr = this._dsAll.Tables[PCCITEMST_TABLE].NewRow();
                        dr[BLSELECT_TITLE] = false;
                        dr[BLGOODSCODE_TITLE] = DBNull.Value;
                        dr[BLGOODSNAME_TITLE] = string.Empty;
                        dr[BLGOODSQTY_TITLE] = DBNull.Value;
                        dr[BLGRIDNO_TITLE] = DBNull.Value;
                        this._dsAll.Tables[PCCITEMST_TABLE].Rows.InsertAt(dr, insertIndex);


                        for (int i = 0; i < this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; i++)
                        {
                            DataRow dRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[i];
                            if (i >= MAXALLROW)
                            {
                                this._dsAll.Tables[PCCITEMST_TABLE].Rows.Remove(dRow);
                            }
                            dRow[BLGRIDNO_TITLE] = i / GRIDCOUNT;

                        }
                        //PCC�i�ڂ̂W�O���b�h�W�J����
                        this.GridGroupBy();
                        uGridSelected.Rows[insertIndexOld].Cells[BLGOODSCODE_TITLE].Activate();
                        uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode); 
                    }
                }
                // �s�폜
                else if (e.Tool.Key == "Del_BtnTool")
                {

                    if (uGridSelected.Selected != null
                        && uGridSelected.Selected.Rows.Count > 0)
                    {
                        int minIndex = uGridSelected.Selected.Rows[0].Index;

                        UltraGridRow[] rows = new UltraGridRow[uGridSelected.Selected.Rows.Count];
                        for (int i = 0; i < uGridSelected.Selected.Rows.Count; i++)
                        {
                            rows[i] = uGridSelected.Selected.Rows[i];

                            if (minIndex > rows[i].Index)
                            {
                                minIndex = rows[i].Index;
                            }
                        }

                        bool delRet = true;
                        foreach (UltraGridRow row in rows)
                        {
                            // �s�폜
                            DataRow delDr = null;
                            int deleteIndex = row.Index + gridNo * MAXROW;
                            delDr = this._dsAll.Tables[PCCITEMST_TABLE].Rows[deleteIndex];
                           
                            if (delDr != null)
                            {
                                this._dsAll.Tables[PCCITEMST_TABLE].Rows.Remove(delDr);
                            }
                        }


                        for (int insertIndex = this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; insertIndex < MAXALLROW; insertIndex++)
                        {
                            DataRow dr = this._dsAll.Tables[PCCITEMST_TABLE].NewRow();
                            dr[BLSELECT_TITLE] = false;
                            dr[BLGOODSCODE_TITLE] = DBNull.Value;
                            dr[BLGOODSNAME_TITLE] = string.Empty;
                            dr[BLGOODSQTY_TITLE] = DBNull.Value;
                            dr[BLGRIDNO_TITLE] = DBNull.Value;
                            this._dsAll.Tables[PCCITEMST_TABLE].Rows.InsertAt(dr, insertIndex);


                        }
                        for (int i = 0; i < this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; i++)
                        {
                            DataRow dRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[i];

                            dRow[BLGRIDNO_TITLE] = i / GRIDCOUNT;

                        }
                        //PCC�i�ڂ̂W�O���b�h�W�J����
                        this.GridGroupBy();

                        if (delRet)
                        {
                            if (uGridSelected.Rows.Count > 0)
                            {
                                if (minIndex > 0)
                                {
                                    uGridSelected.Rows[minIndex - 1].Cells[BLGOODSCODE_TITLE].Activate();
                                    uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGridSelected.Rows[minIndex].Cells[BLGOODSCODE_TITLE].Activate();
                                    uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                    }
                    return;
                }
            }
            finally
            {
                // �J�[�\���ύX
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region �ŏ��s�ڂ̎擾����

        /// <summary>
        /// �ŏ��s�ڂ̎擾����
        /// </summary>
        /// <returns>�ŏ��s��</returns>
        /// <remarks>
        /// <br>Note	   : �I�����ꂽ�s�̍ŏ��s�ڂ��擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int StartInsertIndex(UltraGrid uGrid)
        {
            int insertIndex = 0;

            if (uGrid.Selected != null
              && uGrid.Selected.Rows.Count > 0)
            {
                insertIndex = uGrid.Selected.Rows[0].Index;
                foreach (UltraGridRow row in uGrid.Selected.Rows)
                {
                    if (row.Index < insertIndex) insertIndex = row.Index;
                }
            }

            return insertIndex;
        }

        #endregion

        /// <summary>
        /// KeyPress �C�x���g(grdPaymentKind)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �O���b�h���Key�������ꂽ�Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;
            if (!uGrid.ActiveCell.IsInEditMode)
            {
                return;
            }
            bool digitFiag = true;
            switch (columnIndex)
            {
                case 1:
                case 4:
                    {
                        int length = 0;
                        if (columnIndex == 1)
                        {
                            length = 5;
                        }
                        else
                        {
                            length = 3;
                        }
                        // Backspace�̃`�F�b�N
                        if ((byte)e.KeyChar == (byte)'\b' || e.KeyChar == (char)3 || e.KeyChar == (char)22) //ADD �BCTRL+�uC�v�ACTRL+�uV�v�ŃR�s�[��\��t�����o���Ȃ��ɂ��� #18182
                        {
                            return;
                        }

                        // ���l�ȊO�́A�m�f
                        string regex = "^[0-9]*$";
                        Regex objRegex = new Regex(regex);
                        // �ΏۃZ���̃e�L�X�g�擾
                        string targetText = uGrid.ActiveCell.Text;

                        digitFiag = objRegex.IsMatch(targetText);
                        if (!digitFiag)
                        {
                            e.Handled = true;
                            return;
                        }
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);

                        // �Z���̃e�L�X�g���I������Ă���ꍇ
                        if (uGrid.ActiveCell.SelText == targetText)
                        {
                            // ���l�̂ݓ��͉�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                e.KeyChar = '\0';
                            } 
                        }
                        else
                        {

                            if (targetText.Length == length)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {

                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    e.KeyChar = '\0';
                                }
                                
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g(PccItemSt_UltraGrid_InitializeRow)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �Z���̕ҏW���[�h���I�������Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            string  columnKey = uGrid.ActiveCell.Column.Key;
            switch (columnKey)
            {
                case BLGOODSCODE_TITLE:
                    {
                        if (uGrid.ActiveCell.Value == DBNull.Value || uGrid.ActiveCell.Value == null)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                            return;
                        }
                        if ((int)uGrid.ActiveCell.Value == 0)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        }
                        else
                        {
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                           
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        }
                        break;
                    }
                case BLGOODSQTY_TITLE:
                    {
                        if (uGrid.ActiveCell.Value == DBNull.Value || uGrid.ActiveCell.Value == null)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            return;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///  �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void UGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }
            string columnKey = ultraGrid.ActiveCell.Column.Key;
            int numLen = 0;
            //
            if (BLGOODSCODE_TITLE.Equals(columnKey))
            {
                //BL�R�[�h
                numLen = 8;
            }
            else if (BLGOODSQTY_TITLE.Equals(columnKey))
            {
                //BL����
                numLen = 3;
            }
           
            if (ultraGrid.ActiveCell.Column.DataType == typeof(Int32))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = ultraGrid.ActiveCell.EditorResolved;
                string currentEditText = editorBase.CurrentEditText;
                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                if (!checkNumber)
                {
                    ultraGrid.ActiveCell.Value = DBNull.Value;
                }

            }
            e.RaiseErrorEvent = false;   // �G���[�C�x���g�͔��������Ȃ�
            e.RestoreOriginalValue = false;  // �Z���̒l�����ɖ߂��Ȃ� 
            e.StayInEditMode = false;   // �ҏW���[�h�͔�����
        }

        /// <summary>
        /// �t�H�[�J�X�ϊ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ϊ��������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            UltraGrid ultraGrid = null;

           

            // ���O�ɂ�蕪��
            switch (e.NextCtrl.Name)
            {
                // PCC�i�ڐݒ�O���b�h1
                case "PccItemSt_UltraGrid1":
                    {
                        _gridNo = 0;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                       break;
                    }
                // PCC�i�ڐݒ�O���b�h2
                case "PccItemSt_UltraGrid2":
                    {
                        _gridNo = 1;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                         break;
                    }
                // PCC�i�ڐݒ�O���b�h3
                case "PccItemSt_UltraGrid3":
                    {
                        _gridNo = 2;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                          break;
                    }
                // PCC�i�ڐݒ�O���b�h4
                case "PccItemSt_UltraGrid4":
                    {
                        _gridNo = 3;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                         break;
                    }
                // PCC�i�ڐݒ�O���b�h5
                case "PccItemSt_UltraGrid5":
                    {
                        _gridNo = 4;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC�i�ڐݒ�O���b�h6
                case "PccItemSt_UltraGrid6":
                    {
                        _gridNo =5;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC�i�ڐݒ�O���b�h7
                case "PccItemSt_UltraGrid7":
                    {
                        _gridNo = 6;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC�i�ڐݒ�O���b�h8
                case "PccItemSt_UltraGrid8":
                    {
                        _gridNo = 7;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
            }
            _seletedUtraGrid = ultraGrid;

        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�L�[�_�E�����ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if(ultraGrid == null)
            {
                return;
            }
            
            
            //�A�N�e�B�u�Z�������݂���Ƃ�
            if (ultraGrid.ActiveCell != null)
            {
                //�Ώۂ̃Z�����擾
                UltraGridCell cell = ultraGrid.ActiveCell;
                int columnIndex = ultraGrid.ActiveCell.Column.Index;
                int rowIndex = ultraGrid.ActiveCell.Row.Index;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            
                            break;
                        }
                    case Keys.Down:
                        {
                           MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                          
                            break;
                        }
                    case Keys.Left:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            break;
                        }
                    case Keys.Right:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            break;
                        }
                    case Keys.Space:
                        {
                            if (ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = ultraGrid.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                this.PccItemSt_UltraGrid_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }
               
            }
            else if (ultraGrid.ActiveRow != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Down:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Left:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Right:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                }
            }
        }

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �摜�ԍ��R���{�`�F���W
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���{�̉摜�ɑΉ�����摜��\������</br>
        /// <br>Programmer : �O�� �L��</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private void tComboEditor_ImageIDX_ValueChanged(object sender, EventArgs e)
        {
            short cmbImageNo = short.Parse(this.tComboEditor_ImageIDX.Value.ToString());
            switch (cmbImageNo)
            {
                case 1:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg01;
                        break;
                    }
                case 2:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg02;
                        break;
                    }
                case 3:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg03;
                        break;
                    }
                case 4:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg04;
                        break;
                    }
                //case 5:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg05;
                //        break;
                //    }
                //case 6:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg06;
                //        break;
                //    }
                //case 7:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg07;
                //        break;
                //    }
                //case 8:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg08;
                //        break;
                //    }
                //case 9:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg09;
                //        break;
                //    }
                //case 10:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg10;
                //        break;
                //    }
                case 11:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg11;
                        break;
                    }
                case 12:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg12;
                        break;
                    }
                case 13:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg13;
                        break;
                    }
                case 14:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg14;
                        break;
                    }
                case 15:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg15;
                        break;
                    }
                //case 16:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg16;
                //        break;
                //    }
                //case 17:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg17;
                //        break;
                //    }
                //case 18:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg18;
                //        break;
                //    }
                //case 19:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg19;
                //        break;
                //    }
                //case 20:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg20;
                //        break;
                //    }
                case 21:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg21;
                        break;
                    }
                case 22:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg22;
                        break;
                    }
                case 23:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg23;
                        break;
                    }
                case 24:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg24;
                        break;
                    }
                case 25:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg25;
                        break;
                    }
                //case 26:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg26;
                //        break;
                //    }
                //case 27:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg27;
                //        break;
                //    }
                //case 28:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg28;
                //        break;
                //    }
                //case 29:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg29;
                //        break;
                //    }
                //case 30:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg30;
                //        break;
                //    }
                case 31:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg31;
                        break;
                    }
                case 32:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg32;
                        break;
                    }
                case 33:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg33;
                        break;
                    }
                case 34:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg34;
                        break;
                    }
                case 35:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg35;
                        break;
                    }
                //case 36:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg36;
                //        break;
                //    }
                //case 37:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg37;
                //        break;
                //    }
                //case 38:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg38;
                //        break;
                //    }
                //case 39:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg39;
                //        break;
                //    }
                //case 40:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg40;
                //        break;
                //    }
                case 41:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg41;
                        break;
                    }
                case 42:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg42;
                        break;
                    }
                case 43:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg43;
                        break;
                    }
                case 44:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg44;
                        break;
                    }
                case 45:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg45;
                        break;
                    }
                //case 46:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg46;
                //        break;
                //    }
                //case 47:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg47;
                //        break;
                //    }
                //case 48:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg48;
                //        break;
                //    }
                //case 49:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg49;
                //        break;
                //    }
                //case 50:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg50;
                //        break;
                //    }
                case 51:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg51;
                        break;
                    }
                case 52:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg52;
                        break;
                    }
                case 53:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg53;
                        break;
                    }
                case 54:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg54;
                        break;
                    }
                case 55:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg55;
                        break;
                    }
                //case 56:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg56;
                //        break;
                //    }
                //case 57:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg57;
                //        break;
                //    }
                //case 58:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg58;
                //        break;
                //    }
                //case 59:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg59;
                //        break;
                //    }
                //case 60:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg60;
                //        break;
                //    }
                //case 61:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg61;
                //        break;
                //    }
                //case 62:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg62;
                //        break;
                //    }
                //case 63:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg63;
                //        break;
                //    }
                //case 64:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg64;
                //        break;
                //    }
                //case 65:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg65;
                //        break;
                //    }
                //case 66:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg66;
                //        break;
                //    }
                //case 67:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg67;
                //        break;
                //    }
                //case 68:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg68;
                //        break;
                //    }
                //case 69:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg69;
                //        break;
                //    }
                //case 70:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg70;
                //        break;
                //    }
                //case 71:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg71;
                //        break;
                //    }
                //case 72:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg72;
                //        break;
                //    }
                //case 73:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg73;
                //        break;
                //    }
                //case 74:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg74;
                //        break;
                //    }
                //case 75:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg75;
                //        break;
                //    }
                //case 76:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg76;
                //        break;
                //    }
                //case 77:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg77;
                //        break;
                //    }
                //case 78:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg78;
                //        break;
                //    }
                //case 79:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg79;
                //        break;
                //    }
                //case 80:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg80;
                //        break;
                //    }
                case 81:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg81;
                        break;
                    }
                case 82:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg82;
                        break;
                    }
                case 83:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg83;
                        break;
                    }
                case 84:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg84;
                        break;
                    }
                case 85:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg85;
                        break;
                    }
                case 86:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg86;
                        break;
                    }
                case 87:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg87;
                        break;
                    }
                case 88:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg88;
                        break;
                    }
                case 89:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg89;
                        break;
                    }
                //case 90:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg90;
                //        break;
                //    }
                //case 91:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg91;
                //        break;
                //    }
                //case 92:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg92;
                //        break;
                //    }
                //case 93:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg93;
                //        break;
                //    }
                //case 94:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg94;
                //        break;
                //    }
                //case 95:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg95;
                //        break;
                //    }
                //case 96:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg96;
                //        break;
                //    }
                //case 97:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg97;
                //        break;
                //    }
                //case 98:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg98;
                //        break;
                //    }
                //case 99:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg99;
                //        break;
                //    }
                default:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = null;
                        break;
                    }
            }
        }
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
    }
}

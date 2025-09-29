

//#define _MANUAL_MERGE_PRIME_SETTING_

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 �@�\�ǉ�

namespace Broadleaf.Windows.Forms
{
    using ProcessConfigAcs = SingletonPolicy<ProcessConfig>;   // ADD 2009/01/30 �@�\�ǉ�
    using LatestPair = Pair<DateTime, int>;
    using Broadleaf.Application.Remoting.ParamData;              // ADD 2009/02/03 �@�\�ǉ�

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/24 ��r��</br>
    /// <br>             PM.NS1009</br>
    /// <br>             �ŐV�����폜�̒ǉ�</br>
    /// </remarks>
    public partial class PMKHN09200UA : Form
    {
        // ADD 2009/01/22 �@�\�ǉ� ---------->>>>>
        #region [ Const ]

        /// <summary>�X�V����Ă��Ȃ��ꍇ�̃��b�Z�[�W</summary>
        private const string MSG_PLEASE_UPDATE = "���i�������s���Ă��܂���B�X�V���s���ĉ������B";

        /// <summary>�I�����̈�</summary>
        private const string SELECTED_MARK = "��";

        /// <summary>�O�񏈗����̃t�H�[�}�b�g</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd";

        #endregion  // [ Const ]
        // ADD 2008/01/22 �@�\�ǉ� ----------<<<<<

        #region [ Private Member ]

        private OfferMergeAcs _offerMergeAcs;
        private string _enterpriseCode;
        private dtHist _dtHist;
        private readonly string[] ct_UpdateDiv;

        // --- ADD 2010/05/24 ---------->>>>>
        private ArrayList _historyList;
        // --- ADD 2010/05/24 -----------<<<<<

        // DEL 2009/01/22 �@�\�ǉ� ---------->>>>>
        /// <summary>
        /// �X�V�f�[�^�敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="updateDataDiv">�X�V�f�[�^�敪</param>
        /// <returns><c>0</c>:�t�h<br/><c>1</c>:����</returns>
        private string GetUpdateDataDivName(int updateDataDiv)
        {
            return ct_UpdateDiv[updateDataDiv];
        }
        // DEL 2009/01/22 �@�\�ǉ� ----------<<<<<
        private const int UPDATING_ITEM_COUNT = 11; // MOD 2009/01/30 �@�\�ǉ��F6��11
        private readonly string[] ct_TblIDList;
        private readonly string[] ct_TblNameList;
        private readonly List<string> ct_TblNoUpdList;

        #endregion  // [ Private Member ]

        #region [ �R���X�g���N�^ ]

        /// <summary>
        /// 
        /// </summary>
        public PMKHN09200UA()
        {
            _offerMergeAcs = new OfferMergeAcs();
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _offerMergeAcs.Initialize(_enterpriseCode);

            // DEL 2009/01/22 �@�\�ǉ��F����������p�~ ---------->>>>>
            #region �폜�R�[�h
            //if (Program._parameter.Length > 0) // �����N���̏ꍇ
            //{
            //    int offerDate;
            //    if (int.TryParse(Program._parameter[0], out offerDate))
            //    {
            //        _OfferMergeAcs.MergeOfferToUser(_enterpriseCode, offerDate);
            //    }
            //    Close();
            //}
            //else // �蓮�N���̏ꍇ
            //{
            #endregion
            // DEL 2009/01/22 �@�\�ǉ��F����������p�~ ----------<<<<<

            ct_UpdateDiv = new string[2] { "�t�h", "����" };
            ct_TblIDList = new string[UPDATING_ITEM_COUNT] {
                ProcessConfig.BL_CODE_MASTER_ID,        // MOD 2009/01/30 �@�\�ǉ��F"BLGOODSCDURF"��ProcessConfig.BL_CODE_MASTER_ID
                ProcessConfig.BL_GROUP_MASTER_ID,       // MOD 2009/01/30 �@�\�ǉ��F"BLGROUPURF"��ProcessConfig.BL_GROUP_MASTER_ID
                ProcessConfig.MIDDLE_GENRE_MASTER_ID,   // MOD 2009/01/30 �@�\�ǉ��F"GOODSGROUPURF"��ProcessConfig.MIDDLE_GENRE_MASTER_ID
                ProcessConfig.MODEL_NAME_MASTER_ID,     // MOD 2009/01/30 �@�\�ǉ��F"MODELNAMEURF"��ProcessConfig.MODEL_NAME_MASTER_ID
                ProcessConfig.MAKER_MASTER_ID,          // MOD 2009/01/30 �@�\�ǉ��F"MAKERURF"��ProcessConfig.MAKER_MASTER_ID
                ProcessConfig.PARTS_POS_CODE_MASTER_ID, // MOD 2009/01/30 �@�\�ǉ��F"PARTSPOSCODEURF"��ProcessConfig.PARTS_POS_CODE_MASTER_ID
                ProcessConfig.PRIME_SETTING_MASTER_ID,          // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID,   // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.GOODS_MASTER_ID,                  // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.GOODS_PRICE_MASTER_ID,            // ADD 2009/01/30 �@�\�ǉ�  
                ProcessConfig.PRICE_REVISION_ID                 // ADD 2009/01/30 �@�\�ǉ�
            };
            ct_TblNameList = new string[UPDATING_ITEM_COUNT] {
                ProcessConfig.BL_CODE_MASTER_NAME,          // MOD 2009/01/30 �@�\�ǉ��F"BL�R�[�h�}�X�^"��ProcessConfig.BL_CODE_MASTER_NAME
                ProcessConfig.BL_GROUP_MASTER_NAME,         // MOD 2009/01/30 �@�\�ǉ��F"BL�O���[�v�}�X�^"��ProcessConfig.BL_GROUP_MASTER_NAME
                ProcessConfig.MIDDLE_GENRE_MASTER_NAME,     // MOD 2009/01/30 �@�\�ǉ��F"�����ރ}�X�^"��ProcessConfig.MIDDLE_GENRE_MASTER_NAME
                ProcessConfig.MODEL_NAME_MASTER_NAME,       // MOD 2009/01/30 �@�\�ǉ��F"�Ԏ�}�X�^"��ProcessConfig.MODEL_NAME_MASTER_NAME
                ProcessConfig.MAKER_MASTER_NAME,            // MOD 2009/01/30 �@�\�ǉ��F"���[�J�[�}�X�^"��ProcessConfig.MAKER_MASTER_NAME
                ProcessConfig.PARTS_POS_CODE_MASTER_NAME,   // MOD 2009/01/30 �@�\�ǉ��F"���ʃ}�X�^"��ProcessConfig.PARTS_POS_CODE_MASTER_NAME
                ProcessConfig.PRIME_SETTING_MASTER_NAME,        // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.PRIME_SETTING_CHANGE_MASTER_NAME, // Add 2009/01/30 �@�\�ǉ�
                ProcessConfig.GOODS_MASTER_NAME,                // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.GOODS_PRICE_MASTER_NAME,          // ADD 2009/01/30 �@�\�ǉ�
                ProcessConfig.PRICE_REVISION_NAME               // ADD 2009/01/30 �@�\�ǉ�
            };
            // DEL 2009/01/22 �@�\�ǉ����F���i������ǉ�
            //ct_TblNoUpdList = new List<string>(new string[2] { "MODELNAMEURF", "MAKERURF" });
            // ADD 2009/01/30 �@�\�ǉ��F���i���� ---------->>>>>
            ct_TblNoUpdList = new List<string>(new string[4] {
                ProcessConfig.MODEL_NAME_MASTER_ID,
                ProcessConfig.MAKER_MASTER_ID,
                ProcessConfig.PRIME_SETTING_MASTER_ID,
                ProcessConfig.PRICE_REVISION_ID
            });
            // ADD 2008/01/30 �@�\�ǉ��F���i���� ----------<<<<<

            InitializeComponent();

            _dtHist = new dtHist();

            ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

            // ADD 2009/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ---------->>>>>
            // [���o]�c�[���{�^��
            //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = false;
            // ADD 2008/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ----------<<<<<

            tabStrip.Tabs[0].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INPUTCHECK];
            tabStrip.Tabs[1].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INPUTCHECK];

            // DEL 2009/01/22 �@�\�ǉ����F����������p�~
            //}
        }

        #endregion  // [ �R���X�g���N�^ ]

        #region [ �������� ]

        // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
        /// <summary>
        /// �t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKHN09200UA_Load(object sender, EventArgs e)
        {
            _offerMergeAcs.MyLogger.Write("�N��", "", "�N��");  // ADD 2009/02/10 �@�\�ǉ��F���O�o��

            // �}�[�W�ς݂��`�F�b�N
            string msg = string.Empty;
            bool isMerged = _offerMergeAcs.Checker.IsMerged(out msg);
            if (!isMerged)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Text,
                    MSG_PLEASE_UPDATE,
                    (int)Result.Code.Normal,
                    MessageBoxButtons.OK
                );
            }

            _offerMergeAcs.MyLogger.Write("�}�[�W�`�F�b�N", "", msg);   // ADD 2009/02/10 �@�\�ǉ��F���O�o��
        }
        // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN09200UA_Shown(object sender, EventArgs e)
        {
            //SFCMN00299CA _progressForm = new SFCMN00299CA();
            //_progressForm.Title = "���i���������擾��";
            //_progressForm.Show();
            try
            {
                GetHistory();
                DisplayUpdateList();
                // --- ADD 2010/05/24 ---------->>>>>
                if (null == _historyList)
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                }
                // --- ADD 2010/05/24 -----------<<<<<
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
            }
            finally
            {
                //_progressForm.Close();
                //_progressForm.Dispose();
            }
        }

        #endregion  // [ �������� ]

        #region [ �O���b�h�C�x���g���� ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.HeaderAppearance = appearance1;

            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.UseRowLayout = true;
            band0.Indentation = 0;

            for (int Index = 0; Index < band0.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((band0.Columns[Index].DataType == typeof(int)) ||
                   (band0.Columns[Index].DataType == typeof(Int64)))
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band0.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band0.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                //System.Drawing.Size sizeCell = new Size();
                //sizeCell.Width = 55;
                //sizeCell.Height = 30;
                //band0.Columns[Index].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            }
            band0.Override.CellClickAction = CellClickAction.RowSelect;
            if (tabStrip.ActiveTab.Index == 0) // �����^�u
            {
                band0.Columns[_dtHist.Hist.SyncTableIDColumn.ColumnName].Hidden = true;

                band0.Columns[_dtHist.Hist.SyncExecuteDateColumn.ColumnName].Width = 150;
            }
            else // �X�V�����^�u
            {
                //band0.Override.CellClickAction = CellClickAction.Default;
                for (int i = 0; i < gridHist.Rows.Count; i++)
                {
                    if (ct_TblNoUpdList.Contains(gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString()))
                    {
                        gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                    }
                }
                band0.Columns[_dtHist.Update.TableIDColumn.ColumnName].Hidden = true;
                //band0.Columns[_dtHist.Update.PrevUpdDateColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.RowCntColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.TableNmColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.SelectionColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                band0.Columns[_dtHist.Update.UpdateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                band0.Columns[_dtHist.Update.SelectionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                band0.Columns[_dtHist.Update.RowCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                ColInfo.SetColInfo(band0, _dtHist.Update.SelectionColumn.ColumnName, 2, 0, 2, 2, 40);
                // DEL 2009/01/22 �@�\�ǉ� ---------->>>>>
                #region �폜�R�[�h
                //ColInfo.SetColInfo(band0, _dtHist.Update.TableNmColumn.ColumnName, 4, 0, 20, 2, 400);
                //ColInfo.SetColInfo(band0, _dtHist.Update.UpdateFlgColumn.ColumnName, 24, 0, 2, 2, 40);
                //ColInfo.SetColInfo(band0, _dtHist.Update.PrevUpdDateColumn.ColumnName, 26, 0, 5, 2, 100);
                //ColInfo.SetColInfo(band0, _dtHist.Update.RowCntColumn.ColumnName, 31, 0, 3, 2, 60);
                #endregion
                // DEL 2008/01/22 �@�\�ǉ� ----------<<<<<
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (tabStrip.ActiveTab.Index == 1) // �X�V�����^�u
            {
                bool val = !((bool)e.Cell.Value);
                e.Cell.Value = val;

                if (gridHist.Selected.Rows.Count == 0 || e.Cell.Row != gridHist.Selected.Rows[0])
                    e.Cell.Row.Selected = true;
                gridHist.UpdateData();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (tabStrip.ActiveTab.Index == 1)
            {
                // DEL 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
                #region �폜�R�[�h
                //if (e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals("��"))
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //}
                //else
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = "��";

                //}
                #endregion
                // DEL 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<
                // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
                string tableId = e.Row.Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString();

                //if (tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                //{
                //    if (e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString() == SELECTED_MARK)
                //    {
                      

                //        e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //    }
                //    else
                //    {
                //        e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = SELECTED_MARK;
                //    }
                //}
                //else
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //}

                e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = GetSelectedMark(tableId);
                // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<

                gridHist.UpdateData();
            }
        }

        // ADD 2009/04/02 �s��Ή�[12899]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
        /// <summary>
        /// �����O���b�h��KeyPress�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �A�N�e�B�u�^�u��[�X�V]�^�u�̏ꍇ�A�`�F�b�N�{�b�N�X�̃X�y�[�X�L�[������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void gridHist_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region <Guard Phrase/>

            if (!this.tabStrip.ActiveTab.Index.Equals(1)) return;
            if (!e.KeyChar.Equals(' ')) return;
            if (this.gridHist.ActiveRow == null) return;

            #endregion  // <Guard Phrase/>

            // [���̍X�V]�J�������`�F�b�N�{�b�N�X�ݒ�̏ꍇ
            if (!this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style.Equals(
                Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            ))
            {
                bool updateFlag = (bool)this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value;
                this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value = !updateFlag;
            }
        }
        // ADD 2009/04/02 �s��Ή�[12899]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<

        #endregion  // [ �O���b�h�C�x���g���� ]

        #region [ �c�[���o�[���� ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2010/05/24 ��r��</br>
        /// <br>             PM1009B</br>
        /// <br>             �ŐV�����폜�̒ǉ�</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Btn_Close":    // ButtonTool
                    _offerMergeAcs.MyLogger.Write("�I��", "", "�I��");  // ADD 2009/02/10 �@�\�ǉ��F���O�o��
                    Close();
                    break;

                case "Btn_Update":    // �����}�[�W����
                    ManualMerge();
                    break;

                // --- ADD 2010/05/24 ---------->>>>>
                case "Btn_Delete":    // �����}�[�W����
                    DeleteHistory();
                    break;
                // --- ADD 2010/05/24 -----------<<<<<

                // ADD 2009/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ---------->>>>>
                //case "Btn_Extraction":  // [���o]�c�[���{�^��
                //    ShowTargetCount();
                //    break;
                // ADD 2008/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ----------<<<<<
            }
        }

        /// <summary>
        /// �����}�[�W����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: �폜������ǉ�����</br>
        /// <br>Programmer : ��r��</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int ManualMerge()
        {
            int status = 0;
            DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "���s���܂����H", 0, MessageBoxButtons.OKCancel);
            if (ret == DialogResult.Cancel)
            {
                return status;
            }

            int selectedFlag = 0;
            int selectedCount = 0;
            bool nameOverwriteFlg = false; ;
            MergeCond mergeCondition = new MergeCond();
            {
                mergeCondition.EnterpriseCode = _enterpriseCode;
                mergeCondition.TargetDate = _dtHist.GetTargetDate();
            }

            // DEL 2009/02/02 �@�\�ǉ���
            //for (int i = 0; i < UPDATING_ITEM_COUNT; i++)
            for (int i = 0; i < gridHist.Rows.Count; i++)   // ADD 2009/02/02 �@�\�ǉ�
            {
                if (gridHist.Rows[i].Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals(SELECTED_MARK))
                //if ((string)(_dtHist.Update.Rows[i] as DataRow)[_dtHist.Update.SelectionColumn.ColumnName] == SELECTED_MARK)
                {
                    selectedFlag = 1;
                    selectedCount++;
                }
                else
                {
                    selectedFlag = 0;
                }
                nameOverwriteFlg = (bool)gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value;
                switch (i)
                {
                    case 0: // BL�R�[�h�}�X�^
                        mergeCondition.BLFlg = selectedFlag;
                        mergeCondition.BLNmOwFlg = nameOverwriteFlg;
                        break;
                    case 1: // BL�O���[�v�}�X�^
                        mergeCondition.BLGroupFlg = selectedFlag;
                        mergeCondition.BLGroupNmOwFlg = nameOverwriteFlg;
                        break;
                    case 2: // �����ރ}�X�^
                        mergeCondition.GoodsMGroupFlg = selectedFlag;
                        mergeCondition.GoodsMGroupNmOwFlg = nameOverwriteFlg;
                        break;
                    case 3: // �Ԏ�}�X�^
                        mergeCondition.ModelNameFlg = selectedFlag;
                        mergeCondition.ModelNameNmOwFlg = nameOverwriteFlg;
                        break;
                    case 4: // ���[�J�[�}�X�^
                        mergeCondition.PMakerFlg = selectedFlag;
                        mergeCondition.PMakerNmOwFlg = nameOverwriteFlg;
                        break;
                    case 5: // ���ʃ}�X�^
                        mergeCondition.PartsPosFlg = selectedFlag;
                        mergeCondition.PartsPosNmOwFlg = nameOverwriteFlg;
                        break;
                    // ADD 2009/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ---------->>>>>
                    case 7: // ���i����
                        mergeCondition.PriceRevisionFlg = selectedFlag;
                        mergeCondition.PriceRevisionNmOwFlg = nameOverwriteFlg;
                        break;
                    default:// �D�ǐݒ�}�X�^
#if _MANUAL_MERGE_PRIME_SETTING_
                        mergeCondition.PrmSetChgFlg     = MergeCond.DOING_FLG_AS_INT;
                        mergeCondition.PrmSetChgNmOwFlg = MergeCond.DOING_FLG_AS_BOOL;
                        mergeCondition.PrmSetFlg        = MergeCond.DOING_FLG_AS_INT;
                        mergeCondition.PrmSetNmOwFlg    = MergeCond.DOING_FLG_AS_BOOL;
#else
                        mergeCondition.PrmSetChgFlg = selectedFlag;
                        mergeCondition.PrmSetChgNmOwFlg = nameOverwriteFlg;
                        mergeCondition.PrmSetFlg = selectedFlag;
                        mergeCondition.PrmSetNmOwFlg = nameOverwriteFlg;
#endif
                        break;
                    // ADD 2008/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ----------<<<<<
                }
            }   // for (int i = 0; i < UPDATING_ITEM_COUNT; i++)

            if (selectedCount == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    "�I�����ꂽ�X�V�Ώۃe�[�u��������܂���B    \r\n�X�V�Ώۃe�[�u����I��ŉ������B",
                    0, MessageBoxButtons.OK);
            }
            else
            {
                SFCMN00299CA _progressForm = new SFCMN00299CA();
                _progressForm.Title = "�X�V������";
                _progressForm.Message = "�X�V�������ł�";
                _progressForm.Show();
                try
                {
                    status = _offerMergeAcs.InitialMerge(mergeCondition);
                    _progressForm.Close();
                    _progressForm = null;
                    if (status == 0)
                    {
                        GetHistory(); // �}�[�W�����������X�V
                        DisplayUpdateList();

                        // --- ADD 2010/05/24 ---------->>>>>
                        if(null == _historyList)
                        {
                            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                        }
                        else
                        {
                            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                        }
                        // --- ADD 2010/05/24 -----------<<<<<

                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "�X�V�����ɐ������܂����B",
                            0, MessageBoxButtons.OK);
                        // ������͍X�V������\�����A�G���[����"�G���[(�G���[�R�[�h)"��\������
                        ShowUpdateResult(status);   // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^�Ɖ��i����
                    }
                    else if (status == 800)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "���ɍX�V�������s���Ă��܂��B",
                            0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "�X�V�����Ɏ��s���܂����B",
                            0, MessageBoxButtons.OK);
                        // ������͍X�V������\�����A�G���[����"�G���[(�G���[�R�[�h)"��\������
                        ShowUpdateResult(status);   // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^�Ɖ��i����
                    }

                }
                // �����[�g�ڑ��ُ�ɂ���O�Ή�
#if DEBUG
                // �f�o�b�O���͗�O��ߑ����Ȃ�
#else
                catch (Exception ex)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text,
                    ex.Message,
                    0, MessageBoxButtons.OK);
                    status = -1;
                }
#endif
                finally
                {
                    if (_progressForm != null) _progressForm.Close();
                    //_progressForm.Dispose();
                }
            }

            return status;
        }

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// ���i���������폜
        /// </summary>
        /// <returns></returns>
      �@/// <remarks>
        /// <br>Note       : �폜������ǉ�����</br>
        /// <br>Programmer : ��r��</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int DeleteHistory()
        {
            int status = 0;
            // �ŐV�o�[�W�����̎擾
            int maxVersion = 0;
            string maxVersionStr = null;
            for (int i = 0; i < _historyList.Count; i++)
            {
                PriUpdTblUpdHist hist = _historyList[i] as PriUpdTblUpdHist;
                if (null != hist)
                {
                    int version = System.Int32.Parse(hist.OfferVersion.Replace(".", "").ToString());
                    if (version > maxVersion)
                    {
                        maxVersion = version;
                        maxVersionStr = hist.OfferVersion;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            // �ŐV�o�[�W�����̖��ׂ̎擾
            ArrayList retList = new ArrayList(); ;
            for (int i = 0; i < _historyList.Count; i++)
            {
                PriUpdTblUpdHist hist = _historyList[i] as PriUpdTblUpdHist;
                if (null != hist && !string.IsNullOrEmpty(hist.OfferVersion.ToString()) && maxVersionStr.Equals(hist.OfferVersion.ToString()))
                {
                    retList.Add(hist);
                }
            }

            // �m�F���b�Z�[�W�̕\��
            DialogResult dialogResult = TMsgDisp.Show(
            this, 
            emErrorLevel.ERR_LEVEL_INFO, Text,
            "�X�V�������폜���Ă���낵���ł����H" + "\r\n" + "\r\n" + "�Ώۃo�[�W�����F" + maxVersionStr,
            0,
            MessageBoxButtons.OKCancel,
            MessageBoxDefaultButton.Button2);

            // �u�������v��I������ꍇ�A��ʂ����̂܂�
            if (dialogResult == DialogResult.Cancel)
            {
                return status;
            }

            // �u�͂��v��I������ꍇ�A�폜�������s��
            status = _offerMergeAcs.DeleteHistory(retList);

            if (0 == status)
            {
                // ���O�o��
                _offerMergeAcs.MyLogger.Write("�����폜", "", maxVersionStr + "���폜");

                // �����̍Ď擾
                if (0 != GetHistory())
                {
                    _dtHist.Hist.Clear();

                    _historyList = null;
                }

                // ��ʂ̍ĕ`��
                DisplayUpdateList();

                // --- ADD 2010/05/24 ---------->>>>>
                if (null == _historyList)
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                }
                // --- ADD 2010/05/24 -----------<<<<<

                // �}�[�W�ς݂��`�F�b�N
                string msg = string.Empty;
                bool isMerged = _offerMergeAcs.Checker.IsMerged(out msg);
                if (!isMerged)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Text,
                        MSG_PLEASE_UPDATE,
                        (int)Result.Code.Normal,
                        MessageBoxButtons.OK
                    );
                }

            }
            else if(status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                TMsgDisp.Show(
                this, 
                emErrorLevel.ERR_LEVEL_INFO, 
                Text,
                "���ɍX�V�������s���Ă��܂��B",
                0, 
                MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                Text,
                "���ɍ폜�������s���Ă��܂��B",
                0,
                MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                this, 
                emErrorLevel.ERR_LEVEL_INFO, 
                Text,
                "�폜�����Ɏ��s���܂����B",
                0, 
                MessageBoxButtons.OK);
            }
            
            return status;
        }
        // --- ADD 2010/05/24 -----------<<<<<

        /// <summary>
        /// �X�V�����擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: �폜������ǉ�����</br>
        /// <br>Programmer : ��r��</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int GetHistory()
        {
            int status;
            ArrayList retList = null;
            try
            {
                // ���i�����X�V����������
                DateTime dtSt = DateTime.Now.AddMonths(-6); // 6�����������擾
                int histStDate = dtSt.Year * 10000 + dtSt.Month * 100 + dtSt.Day;
                status = _offerMergeAcs.GetUpdateHistory(_enterpriseCode, histStDate, 0, out retList);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    ex.Message,
                    0, MessageBoxButtons.OK);
                Debug.Assert(false, ex.Message + "\n" + ex.ToString());
                status = -1;
            }
            if (status == 0)
            {
                _dtHist.Hist.Clear();

                // --- ADD 2010/05/24 ---------->>>>>
                _historyList = retList;
                // --- ADD 2010/05/24 -----------<<<<<

                for (int i = 0; i < retList.Count; i++)
                {
                    PriUpdTblUpdHist hist = retList[i] as PriUpdTblUpdHist;
                    if (!ContainsDefaultSpan(hist.CreateDateTime)) continue;    // ADD 2009/01/22 �@�\�ǉ��F�ߋ�6���������O���b�h�\��

                    dtHist.HistRow historyRow = _dtHist.Hist.NewHistRow();
                    {
                        // �񋟓��t
                        if (hist.OfferDate != 0)
                        {
                            historyRow.OfferDate = hist.OfferDate.ToString("####/##/##");
                        }
                        else
                        {
                            historyRow.OfferDate = "0001/01/01";
                        }
                        // ���s��
                        // DEL 2009/01/22 �@�\�ǉ����F���s���͎����܂ŕ\��
                        //historyRow.SyncExecuteDate = hist.SyncExecuteDate.ToString("####/##/##");
                        //historyRow.SyncExecuteDate = hist.CreateDateTime.ToString("yyyy/MM/dd hh:mm"); // ADD 2009/01/22 �@�\�ǉ��F���s���͎����܂ŕ\��
                        historyRow.SyncExecuteDate = hist.CreateDateTime.ToString("yyyy/MM/dd HH:mm"); // ADD 2009/01/22 �@�\�ǉ��F���s���͎����܂ŕ\��
                        // �Ώۃf�[�^
                        historyRow.SyncTableName = hist.SyncTableName;
                        historyRow.SyncTableID = hist.SyncTableID;

                        // �X�V�s��
                        historyRow.AddUpdateRowsNo = hist.AddUpdateRowsNo;

                        // �X�V�敪
                        if (hist.UpdateDataDiv == 0 || hist.UpdateDataDiv == 1)
                        {
                            historyRow.UpdateDataDiv = ct_UpdateDiv[hist.UpdateDataDiv];
                        }

                        // ADD 2009/01/22 �@�\�ǉ��F�J�����i�񋟃o�[�W�����j�̒ǉ� ---------->>>>>
                        // �񋟃o�[�W����
                        historyRow.OfferVersion = hist.OfferVersion;
                        // ADD 2009/01/22 �@�\�ǉ��F�J�����i�񋟃o�[�W�����j�̒ǉ� ----------<<<<<
                    }

                    _dtHist.Hist.AddHistRow(historyRow);
                }   // for (int i = 0; i < retList.Count; i++)

                // �O���b�h�̕\������
                //_dtHist.Hist.DefaultView.RowFilter = GetDefaultHistoryRowFilter();  // ADD 2009/01/22 �@�\�ǉ��F�X�V�f�[�^�敪=1�̂��̂��O���b�h�\��
                _dtHist.Hist.DefaultView.Sort = _dtHist.Hist.SyncExecuteDateColumn.ColumnName + " DESC";
            }

            return status;
            //gridHist.BeginUpdate();
            //gridHist.DataSource = _dtHist.Hist.DefaultView;
            //gridHist.EndUpdate();
        }

        /// <summary>
        /// �X�V����\������
        /// </summary>
        private void DisplayUpdateList()
        {
            // ADD 2009/01/22 �@�\�ǉ� ---------->>>>>
            // �O�񏈗����^�X�V�����̐ݒ�p�ɉ��i�����X�V�������t�B���^
            string beforeRowFilter = _dtHist.Hist.DefaultView.RowFilter;
            string beforeSort = _dtHist.Hist.DefaultView.Sort;
            StringBuilder rowFilter = new StringBuilder();
            {
                // �ŏI�X�V���́A�����f�[�^���擾����i�X�V�f�[�^�敪=0�FUI�j
                rowFilter.Append(_dtHist.Hist.UpdateDataDivColumn.ColumnName);
                rowFilter.Append(ADOUtil.EQ);
                rowFilter.Append(ADOUtil.GetString(GetUpdateDataDivName((int)PriUpdTblUpdHist.UpdateDataDivValue.UI)));
            }
            try
            {
                _dtHist.Hist.DefaultView.RowFilter = rowFilter.ToString();

                IDictionary<string, LatestPair> latestTableMap = _offerMergeAcs.GetLatestHistoryMap(_enterpriseCode);
                if (latestTableMap != null)
                {
                    if (latestTableMap.Count != 0)
                    {

                        // ADD 2008/01/22 �@�\�ǉ� ----------<<<<<

                        _dtHist.Update.Clear();

                        IList<ProcessConfigItem> processConfigItemList = new List<ProcessConfigItem>(); // ADD 2009/01/30 �@�\�ǉ�
                        for (int i = 0; i < UPDATING_ITEM_COUNT; i++)  // �X�V����
                        {
                            dtHist.UpdateRow updateRow = _dtHist.Update.NewUpdateRow();

                            // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
                            // �I���F�}�[�W�ς݂ł͂Ȃ��ꍇ�A�S�đI��
                            if (!_offerMergeAcs.Checker.IsMerged())
                            {
                                updateRow.Selection = SELECTED_MARK;
                            }
                            // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<

                            // �Ώۃf�[�^
                            updateRow.TableID = ct_TblIDList[i];
                            updateRow.TableNm = ct_TblNameList[i];


                            // ���̍X�V
                            updateRow.UpdateFlg = _offerMergeAcs.NameOverwrite;

                            // DEL 2009/01/22 �@�\�ǉ��F�Ώی����̒ǉ� ---------->>>>>
                            #region �폜�R�[�h

                            //// �O�񏈗����^�X�V����
                            //for (int j = 0; j < _dtHist.Hist.DefaultView.Count; j++)
                            //{
                            //    dtHist.HistRow historyRow = _dtHist.Hist.DefaultView[j].Row as dtHist.HistRow;

                            //    if (historyRow.AddUpdateRowsNo.Equals("�G���[")) continue;  // ADD 2009/01/22 �@�\�ǉ��F���i�����̒ǉ�

                            //    // DEL 2009/01/22 �@�\�ǉ����F���i�����̒ǉ�
                            //    //if (historyRow.SyncTableID == updateRow.TableID && historyRow.AddUpdateRowsNo != "�G���[")
                            //    if (historyRow.SyncTableID.Equals(updateRow.TableID))
                            //    {
                            //        updateRow.PrevUpdDate = historyRow.SyncExecuteDate; // �O�񏈗���
                            //        updateRow.RowCnt = historyRow.AddUpdateRowsNo;      // �X�V����
                            //        break;
                            //    }
                            //}   // for (int j = 0; j < _dtHist.Hist.DefaultView.Count; j++)

                            #endregion
                            // DEL 2009/01/22 �@�\�ǉ��F�Ώی����̒ǉ� ----------<<<<<

                            // ADD 2009/01/22 �@�\�ǉ��F�Ώی����̒ǉ� ---------->>>>>
                            // �O�񏈗����^�X�V����
                            if (latestTableMap.ContainsKey(updateRow.TableID))
                            {
                                if (updateRow.TableID == "PRMSETTINGCHGRF") continue;

                                // �O�񏈗���
                                DateTime prevUpdDate = latestTableMap[updateRow.TableID].First;
                                string strPrevUpdDate = prevUpdDate.ToString(DATE_FORMAT);
                                if (prevUpdDate.Equals(DateTime.MinValue))
                                {
                                    strPrevUpdDate = string.Empty;
                                }

                                // �X�V����
                                int rowCnt = latestTableMap[updateRow.TableID].Second;
                                string strRowCnt = rowCnt.ToString();
                                if (rowCnt.Equals(0) || string.IsNullOrEmpty(strPrevUpdDate))
                                {
                                    strRowCnt = string.Empty;
                                }

                                updateRow.PrevUpdDate = strPrevUpdDate;   // �O�񏈗���
                                updateRow.RowCnt = strRowCnt;        // �X�V����
                            }

                            // �Ώی���
                            updateRow.TargetCnt = 0;
                            // ADD 2009/01/22 �@�\�ǉ��F�Ώی����̒ǉ� ----------<<<<<

                            // DEL 2009/01/30 �@�\�ǉ���
                            //_dtHist.Update.AddUpdateRow(updateRow);
                            // ADD 2009/01/30 �@�\�ǉ��F���i���� ---------->>>>>
                            // ��\���s�̓O���b�h�ɕ\�����Ȃ�
                            if (IsVisibledRow(updateRow.TableID))
                            {
                                _dtHist.Update.AddUpdateRow(updateRow);
                            }

                            processConfigItemList.Add(new ProcessConfigItem(
                                updateRow.Selection.Equals(SELECTED_MARK),
                                updateRow.TableID,
                                updateRow.TableNm,
                                updateRow.UpdateFlg,
                                ProcessConfigItem.ConvertPreviousDate(updateRow.PrevUpdDate),
                                ProcessConfigItem.ConvertPreviousCount(updateRow.RowCnt),
                                updateRow.TargetCnt
                            ));
                            // ADD 2008/01/30 �@�\�ǉ��F���i���� ----------<<<<<
                        } // for (int i = 0; i < UPDATING_ITEM_COUNT; i++)



                        // ADD 2009/01/30 �@�\�ǉ��F���i���� ---------->>>>>
                        // ���i�����̑O�񏈗����ƍX�V������ݒ�
                        ProcessConfigAcs.Instance.Policy.Initialize(processConfigItemList);

                        #region �폜�R�[�h

                        //StringBuilder where = new StringBuilder();
                        //{
                        //    where.Append(_dtHist.Update.TableIDColumn.ColumnName);
                        //    where.Append(ADOUtil.EQ);
                        //    where.Append(ADOUtil.GetString(ProcessConfig.PRICE_REVISION_ID));
                        //}
                        //DataRow[] priceRevisionRows = _dtHist.Update.Select(where.ToString());
                        //dtHist.UpdateRow priceRevisionRow = (dtHist.UpdateRow)priceRevisionRows[0];
                        //{
                        //    priceRevisionRow.PrevUpdDate= dtHist.GetPrevUpdDate(ProcessConfigAcs.Instance.Policy.PriceRevision.PreviousDate);
                        //    priceRevisionRow.RowCnt = dtHist.GetRowCnt(ProcessConfigAcs.Instance.Policy.PriceRevision.PreviousCount);
                        //}

                        #endregion
                        // ADD 2008/01/30 �@�\�ǉ��F���i���� ----------<<<<<

                        // �O���b�h�̐ݒ�
                        if (tabStrip.SelectedTab.Index == 1) // �X�V�����^�u
                        {
                            for (int i = 0; i < gridHist.Rows.Count; i++)
                            {
                                // ADD 2009/02/23 �s��Ή�[11497] ---------->>>>>
                                // �D�ǐݒ�}�X�^�͎蓮�X�V���s���Ȃ�
                                if (gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString().Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                                {
                                    gridHist.Rows[i].Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                                }
                                // ADD 2009/02/23 �s��Ή�[11497] ----------<<<<<

                                // ���̍X�V�`�F�b�N�{�b�N�X�̕\���ݒ�
                                if (ct_TblNoUpdList.Contains(gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString()))
                                {
                                    gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                                }
                            }
                        }
                        // �O���b�h�̐擪�s��I��
                        if (gridHist.Rows.Count > 0)
                        {
                            gridHist.Select();
                            gridHist.Rows[0].Selected = true;
                        }

                        ShowTargetCount();  // �ŐV�����Ď擾
                        // ADD 2009/01/22 �@�\�ǉ� ---------->>>>>
                    }
                    else
                    {
                        DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "�������0���ł��B", 0, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "�������̎擾�Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                }
            }
            catch
            {
                DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "�X�V���̍쐬�Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
            }
            finally
            {
                _dtHist.Hist.DefaultView.RowFilter = beforeRowFilter;
                _dtHist.Hist.DefaultView.Sort = beforeSort;
            }
            // ADD 2008/01/22 �@�\�ǉ� ----------<<<<<
        

        }

        #endregion  // [ �c�[���o�[���� ]

        #region [ ���̑��C�x���g���� ]

        /// <summary>
        /// �^�u�I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2010/05/24 ��r��</br>
        /// <br>             PM1009B</br>
        /// <br>             �ŐV�����폜�̒ǉ�</br>
        /// </remarks>
        private void tabStrip_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Index == 0) // �����^�u
            {
                ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.Visible = false;

                // --- ADD 2010/05/24 ---------->>>>>
                ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Visible = true;
                // --- ADD 2010/05/24 -----------<<<<<

                // [���o]�c�[���{�^�����\��
                //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = false;  // ADD 2009/01/22 �@�\�ǉ��F[���o]�c�[���{�^��

                gridHist.BeginUpdate();
                gridHist.DataSource = _dtHist.Hist.DefaultView;
                gridHist.EndUpdate();
            }
            else // �X�V�����^�u
            {
                ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.Visible = true;

                // --- ADD 2010/05/24 ---------->>>>>
                ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Visible = false;
                // --- ADD 2010/05/24 -----------<<<<<

                // [���o]�c�[���{�^����\��
                //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = true;   // ADD 2009/01/22 �@�\�ǉ��F[���o]�c�[���{�^��

                gridHist.BeginUpdate();
                gridHist.DataSource = _dtHist.Update;
                gridHist.EndUpdate();
            }
            if (gridHist.Rows.Count > 0)
            {
                gridHist.Select();
                gridHist.Rows[0].Selected = true;

            }
        }

        /// <summary>
        /// �O���b�h�G���^�[�L�[����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == gridHist)
            {
                if (gridHist.ActiveRow != null)
                {
                    if (tabStrip.ActiveTab.Index == 1)
                    {
                        // DEL 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
                        #region �폜�R�[�h
                        //if (gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals("��"))
                        //{
                        //    gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                        //}
                        //else
                        //{
                        //    gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = "��";   
                        //}
                        #endregion
                        // DEL 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<
                        // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
                        string tableId = gridHist.ActiveRow.Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString();
                        gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = GetSelectedMark(tableId);
                        // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<
                    }
                    gridHist.UpdateData();

                    UltraGridRow ugr = gridHist.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                        e.NextCtrl = gridHist;
                    }
                }
            }
        }

        #endregion  // [ ���̑��C�x���g���� ]

        #region internal[2007]

        /// <summary>
        /// 
        /// </summary>
        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }

        #endregion  // internal[2007]

        // ADD 2009/01/22 �@�\�ǉ��F�X�V�f�[�^�敪=1 && �ߋ�6�����̂��̂��O���b�h�\�� ---------->>>>>
        #region [ �O���b�h�\�� ]

        /// <summary>
        /// �f�t�H���g���ԓ������肵�܂��B
        /// </summary>
        /// <param name="dateTime">����</param>
        /// <returns><c>true</c> :���ԓ�<br/><c>false</c>:���ԊO</returns>
        [Obsolete("DB�A�N�Z�X�̏�����6�����Ԃ��w�肵�Ă��邪�A�ꉞ�A��`���Ă���")]
        private bool ContainsDefaultSpan(DateTime dateTime)
        {
            // DB�A�N�Z�X�̏�����6�����Ԃ��w�肵�Ă��邪�A�ꉞ�A��`���Ă���
            return true;
        }

        /// <summary>
        /// ����\���̃f�t�H���g�t�B���^���擾���܂��B
        /// </summary>
        /// <returns>�X�V�f�[�^�敪=1</returns>
        private string GetDefaultHistoryRowFilter()
        {
            StringBuilder rowFilter = new StringBuilder();
            {
                rowFilter.Append(_dtHist.Hist.UpdateDataDivColumn.ColumnName);
                rowFilter.Append(ADOUtil.EQ);
                rowFilter.Append(ADOUtil.GetString(GetUpdateDataDivName((int)PriUpdTblUpdHist.UpdateDataDivValue.Auto)));
            }
            return rowFilter.ToString();
        }

        /// <summary>
        /// �O���b�h�\������s�����肵�܂��B
        /// </summary>
        /// <param name="tableId">�Ώۃf�[�^ID</param>
        /// <returns>
        /// <c>true</c> :�\������<br/>
        /// <c>false</c>:�\�����Ȃ�
        /// </returns>
        private bool IsVisibledRow(string tableId)
        {
            // DEL 2009/02/23 �s��Ή�[11497]��
            // if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))          return false;   // �D�ǐݒ�}�X�^
            if (tableId.Equals(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID)) return false;   // �D�ǐݒ�ύX�}�X�^
            if (tableId.Equals(ProcessConfig.GOODS_MASTER_ID)) return false;   // ���i�}�X�^
            if (tableId.Equals(ProcessConfig.GOODS_PRICE_MASTER_ID)) return false;   // ���i�}�X�^
            return true;
        }

        // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
        /// <summary>
        /// �I�����̈���擾���܂��B
        /// </summary>
        /// <param name="tableIdOnGrid">�O���b�h�̃e�[�u��ID</param>
        /// <returns>�}�[�W�ς݂ł͂Ȃ��̏ꍇ�A<c>SELECTED_MARK</c>��Ԃ��܂��B</returns>
        private string GetSelectedMark(string tableIdOnGrid)
        {
            #region <Guard Phrase/>

            // �D�ǐݒ�}�X�^�͎蓮�X�V���s���Ȃ�
            if (tableIdOnGrid.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
            {
                if (this.gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                    return string.Empty;
                else
                    return SELECTED_MARK;
            }

            #endregion  // <Guard Phrase/>

            if (!_offerMergeAcs.Checker.IsMerged())
            {
                return SELECTED_MARK;
            }
            else

            {
                 //�}�[�W�ς݂̏ꍇ�A���ʂ̂�
                if (tableIdOnGrid.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                {
                    string activeCellValue = this.gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString().Trim();
                    return string.IsNullOrEmpty(activeCellValue) ? SELECTED_MARK : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<

        #endregion  // [ �O���b�h�\�� ]
        // ADD 2008/01/22 �@�\�ǉ��F�X�V�f�[�^�敪=1 && �ߋ�6�����̂��̂��O���b�h�\�� ----------<<<<<

        // ADD 2009/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ---------->>>>>
        #region [ �������ʂ��O���b�h�ɕ\�� ]

        /// <summary>
        /// �Ώی�����\�����܂��B
        /// </summary>
        private void ShowTargetCount()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ProcessConfig target = _offerMergeAcs.GetTargetAndSetProcessSequence(ProcessConfigAcs.Instance.Policy);
                for (int i = 0; i < _dtHist.Update.Count; i++)
                {
                    string processId = _dtHist.Update[i].TableID;
                    if (_dtHist.Update[i].TableID.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                    {
                        _dtHist.Update[i].PrevUpdDate = target.LatestPreviousDateOfPrimeSetting.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target.TotalPreviousCountOfPrimeSetting.ToString();
                        _dtHist.Update[i].TargetCnt = target.TotalPresentCountOfPrimeSetting;
                    }
                    else if (_dtHist.Update[i].TableID.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                    {
                        _dtHist.Update[i].PrevUpdDate = target[processId].PreviousDate.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target[processId].PreviousCount.ToString();
                        _dtHist.Update[i].TargetCnt += target[processId].PresentCount;
                    }
                    else
                    {
                        _dtHist.Update[i].PrevUpdDate = target[processId].PreviousDate.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target[processId].PreviousCount.ToString();
                        _dtHist.Update[i].TargetCnt = target[processId].PresentCount;
                    }
                }
            }
            catch(Exception ex)
            {
                DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "�񋟏��擾�Ɏ��s���܂����B", 0, MessageBoxButtons.OKCancel);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �X�V���ʂ�\�����܂��B
        /// </summary>
        /// <param name="status">�������ʃR�[�h</param>
        private void ShowUpdateResult(int status)
        {
            for (int i = 0; i < _dtHist.Update.Count; i++)
            {
                string strRowCnt = string.Empty;

                if (status.Equals((int)Result.Code.Normal))
                {
                    string tableId = _dtHist.Update[i].TableID;
                    strRowCnt = _offerMergeAcs.ProcessResult[tableId].ToString();
                }
                else
                {
                    strRowCnt = "�G���[(" + status.ToString() + ")";
                }

                if (_dtHist.Update[i].Selection.Equals(SELECTED_MARK))
                {
                    _dtHist.Update[i].RowCnt = strRowCnt;
                }
            }
        }

        #endregion  // [ �������ʂ��O���b�h�ɕ\�� ]
        // ADD 2008/01/22 �@�\�ǉ��F[���o]�c�[���{�^�� ----------<<<<<
    }
}

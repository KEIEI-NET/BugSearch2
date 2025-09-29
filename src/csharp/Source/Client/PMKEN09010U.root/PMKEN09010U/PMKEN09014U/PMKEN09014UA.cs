//****************************************************************************//
// System           : .NS Series
// Program name     : �D�ǐݒ�}�X�^                 
// Note             : �D�ǐݒ�̓o�^�E�ύX�E�폜���s��    
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                       
//============================================================================//
// ����                                                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/02/15  �C�����e : �V�K�쐬                                   
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �X �V ��  2008/07/01  �C�����e : ���p/�@�\�ǉ��̈׏C��                                   
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �X �V ��  2011/11/22  �C�����e : Redmine#8033�̑Ή�                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����H
// �X �V ��  2011/11/30  �C�����e : Redmine#8188 �D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ���                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �X �V ��  2011/12/15  �C�����e : Redmine#26800 �D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ���                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : 杍^
// �X �V ��  2011/12/19  �C�����e : 2012/01/25�z�M���ARedmine#27453 
//                                  �D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���|��
// �X �V ��  2012/09/25�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή�                             
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X   
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����E���Ӑ�E�ԗ����e�L�X�g�o�͂̒��o��������͂���t�H�[���N���X�ł��B</br>
    /// <br>UpdateNote  : 2008/07/01 30415 �ēc �ύK</br>
    /// <br>        	 �E���p/�@�\�ǉ��ׁ̈A�C��</br> 
    /// <br>Update Note: 2011/12/19 杍^</br>
    /// <br>�Ǘ��ԍ�   �F10707327-00 2012/01/25�z�M��</br>
    /// <br>             Redmine#27453�@�D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��</br>
    /// <br>Update Note: 2012/09/25 杍^</br>
    /// <br>�Ǘ��ԍ�   �F10801804-00 2012/10/17�z�M��</br>
    /// <br>             Redmine#32367 ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή�</br>
    /// </remarks>
    public partial class PMKEN09014UA : Form, IPrimeSettingController,
        IPrimeSettingCheckable,             // ADD 2008/10/29 �s��Ή�[6962] �d�l�ύX
        IPrimeSettingNoteChangedEventHandler// ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX
    {
        # region Constructor
        /// <summary>
        /// �����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X �R���X�g���N�^
        /// </summary>
        /// <remarks>�����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X�̃R���X�g���N�^�ł��B</remarks>
        public PMKEN09014UA()
        {
            InitializeComponent();

            // �C���^�[�t�F�[�X�v���p�e�B�ݒ菈��
            //this.SetProperties();
        }
        # endregion

        private DataView _MgBlMkView;

        // �D�ǐݒ�}�X�^�R���g���[��(�C���^�[�t�F�[�X�̎����j
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

        SupplierAcs _supplierAcs;  // ADD 2008/07/01

        //--------------------------------------------------------------------------
        //	ToolBar
        //--------------------------------------------------------------------------
        # region ��Const-�W��ToolBar
        /// <summary>�S�̐ݒ�</summary>
        private const string TOOL_GROBAL = "Grobal";
        /// <summary>�ڍאݒ�</summary>
        private const string TOOL_DETAIL = "Detail";

        /// <summary>���</summary>
        private const string TOOL_PRIOR = "Prior";
        /// <summary>����</summary>
        private const string TOOL_NEXT = "Next";

        /// <summary>��ֈړ�</summary>
        private const string TOOL_UP = "Up";
        /// <summary>���ֈړ�</summary>
        private const string TOOL_DOWN = "Down";
        /// <summary>�ŏ�ʂֈړ�</summary>
        private const string TOOL_TOP = "Top";
        /// <summary>�ŉ��ʂֈړ�</summary>
        private const string TOOL_BOTTOM = "Bottom";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>�d����N���A</summary>
        private const string TOOL_SUPPLIER = "SupplierClear";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        # endregion

        // HACK:�����A1�Œ�ł����c�H
        /// <summary>��{�ݒ�̃^�uID</summary>
        private int _navigeteIndex = 1;//0:������ 1:BL�R�[�h

        /// <summary>
        /// �v���p�e�B(�D�ǐݒ�}�X�^�R���g���[���C���^�[�t�F�[�X�̎����j
        /// </summary>
        public object objPrimeSettingController
        {
            get
            {
                return (object)_primeSettingController;
            }
            set
            {
                //if (value is PrimeSettingController)  // DEL 2008/07/01
                if (value is PrimeSettingAcs)           // ADD 2008/07/01
                {
                    //_primeSettingController = (PrimeSettingController)value;  // DEL 2008/07/01
                    _primeSettingController = (PrimeSettingAcs)value;           // ADD 2008/07/01 
                }
                else
                {
                    _primeSettingController = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        /// <remarks>
        /// 
        /// </remarks>
        public void MainTabIndexChange(object sender, int TabIndex)
        {
            // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
            // �\�����e�����Z�b�g
            ultraDockManager1.ResetControlPanes();
            // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<

            if (TabIndex == 1)
            {
                _MgBlMkView.Sort =
                    (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," +
                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                     PrimeSettingInfo.COL_MAKERDISPORDER);
                _MgBlMkView.RowFilter = "";

                SetMG_BLTreeView(1);    // TODO:�x�����\�b�h�i������/�i�ڐݒ�c���[�̏������j
                SetMK_BLTreeView();     // ���[�J�[/�i�ڐݒ�c���[�̏�����

                if (this.makerMiddleTab.ActiveTab.Index.Equals(1))
                {
                    if ((SettingNavigatorTree.TopNode != null) && (SettingNavigatorTree.Nodes.Count > 0))
                    {
                        SettingNavigatorTree.TopNode.Selected = true;
                        // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
                        SettingNavigatorTree_AfterSelect(SettingNavigatorTree, new Infragistics.Win.UltraWinTree.SelectEventArgs(SettingNavigatorTree.SelectedNodes));
                        // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<
                    }
                }
                else
                {
                    // ADD 2009/01/14 �d�l�ύX �����ރR�[�h�̂�������\�� ---------->>>>>
                    if ((MK_BLSettingNavigatorTree.TopNode != null) && (MK_BLSettingNavigatorTree.Nodes.Count > 0))
                    {
                        this.MK_BLSettingNavigatorTree.TopNode.Selected = true;
                        // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
                        MK_BLSettingNavigatorTree.Nodes[0].Selected = true;
                        MK_BLSettingNavigatorTree_AfterSelect(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.SelectEventArgs(MK_BLSettingNavigatorTree.SelectedNodes));
                        // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<
                    }
                    // ADD 2009/01/14 �d�l�ύX �����ރR�[�h�̂�������\�� ----------<<<<<
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        /// <param name="key"></param>
        public void FrameNotifyEvent(object sender, int TabIndex, string key)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09014UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------>>>>>
            // �^�u�X�^�C���ݒ�
            makerMiddleTab.UseOsThemes = DefaultableBoolean.False;
            makerMiddleTab.Appearance.BackColor = Color.WhiteSmoke;
            makerMiddleTab.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            makerMiddleTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            makerMiddleTab.ActiveTabAppearance.BackColor = Color.White;
            makerMiddleTab.ActiveTabAppearance.BackColor2 = Color.Pink;
            makerMiddleTab.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
            makerMiddleTab.Style = UltraTabControlStyle.VisualStudio2005;
            makerMiddleTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------<<<<<

            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable); // MEMO:
            PrimeSettingGrid.DataSource = _MgBlMkView;
        }

        /// <summary>
        /// ������/�i�ڃr���[�̕\��
        /// </summary>
        private void SetMG_BLTreeView(int mode)
        {
            Debug.WriteLine("�����ށ^�i�ڃc���[�̍X�V�J�n�F" + DateTime.Now);

            SettingNavigatorTree.BeginUpdate();

            // DEL 2009/02/16 �s��Ή�[10406]�����x�A�b�v�Ή� �������͂��̍s
            //SettingNavigatorTree.Nodes.Clear();

            //int order = 0;
            if (mode == 0)
            {
                SettingNavigatorTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            }
            else
            {
                SettingNavigatorTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Default;
            }

            Hashtable Mght = new Hashtable();
            Hashtable MgBlht = new Hashtable();
            Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
            Infragistics.Win.UltraWinTree.UltraTreeNode childNode = null;
            //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);  // DEL 2008/07/01
            
            _MgBlMkView.RowFilter = ""; // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή�
            // DEL 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
            //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);           // ADD 2008/07/01
            //_MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            // DEL 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<
            // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
            string orderBy = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            _MgBlMkView.Sort = orderBy + "," + PrimeSettingAcs.COL_CHECKSTATE;
            // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<
            foreach (DataRowView dr in _MgBlMkView)
            {
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

                #region �폜�R�[�h
                //  //View�̃`�F�b�N�X�e�[�^�X��CHECKED�̃f�[�^�̂ݕ\��
                //  if ((CheckState)dr[PrimeSettingController.COL_CHECKSTATE] == CheckState.Checked)
                //  {
                #endregion

                string nodeKey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4");

                if (Mght[((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")] == null)
                {
                    Mght.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), dr);
                    // DEL 2008/10/28 �s��Ή�[6966]��
                    //node = SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME]);
                    // ADD 2008/10/28 �s��Ή�[6966]---------->>>>>
                    string middleGrNodeText = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];

                    if (!SettingNavigatorTree.Nodes.Exists(nodeKey))
                    {
                        node = SettingNavigatorTree.Nodes.Add(nodeKey, middleGrNodeText);
                    }
                    else
                    {
                        node = SettingNavigatorTree.Nodes[nodeKey];
                    }
                    // ADD 2008/10/28 �s��Ή�[6966]----------<<<<<
                }
                // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
                else
                {
                    node = SettingNavigatorTree.Nodes[nodeKey];
                }
                node.Visible = true;
                // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<

                string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                if (MgBlht[skey] == null)
                {
                    MgBlht.Add(skey, dr);
                    //    order = 1;
                    //                    if (node != null)
                    //                    {
                    if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                    {
                        if (!node.Nodes.Exists(skey))
                        {
                            string tbsPartsFullName = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                            childNode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + tbsPartsFullName);
                        }
                        else
                        {
                            childNode = node.Nodes[skey];
                        }
                    }
                    else
                    {
                        if (!node.Nodes.Exists(skey))
                        {
                            childNode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                        }
                        else
                        {
                            childNode = node.Nodes[skey];
                        }
                    }

                    // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
                    childNode.Visible = ((int)dr[PrimeSettingAcs.COL_CHECKSTATE]).Equals(1);
                    if (((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                    {
                        childNode.Visible = false;
                    }
                    // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<

                    if (mode == 0) childNode.Visible = false;
                    //                    }
                }
                // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
                else
                {
                    childNode = node.Nodes[skey];
                    childNode.Visible = ((int)dr[PrimeSettingAcs.COL_CHECKSTATE]).Equals(1);
                    if (((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                    {
                        childNode.Visible = false;
                    }
                    
                    if (mode == 0) childNode.Visible = false;
                }
                // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<
                #region �폜�R�[�h
                // else
                // {
                //     order++;
                // }
                // dr[PrimeSettingController.COL_MAKERDISPORDER] = order;
                //   }
                #endregion
            }   // foreach (DataRowView dr in _MgBlMkView)

            // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ---------->>>>>
            // �\������q�m�[�h�������ꍇ�A�e�m�[�h����\���ɂ���
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode parentTreeNode in SettingNavigatorTree.Nodes)
            {
                if (!parentTreeNode.HasExpansionIndicator)
                {
                    parentTreeNode.Visible = false;
                }
            }
            // ADD 2009/02/16 �s��Ή�[10406] ���x�A�b�v�Ή� ----------<<<<<

            _MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
            _MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);

            SettingNavigatorTree.EndUpdate();

            if (SettingNavigatorTree.Nodes.Count == 0)
            {
                StringBuilder allFilter = new StringBuilder();
                allFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1).Append(ADOUtil.AND).Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(9999999999);
                _MgBlMkView.RowFilter = allFilter.ToString();
            }

            Debug.WriteLine("�����ށ^�i�ڃc���[�̍X�V�I���F" + DateTime.Now);
        }

        private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.PrimeSettingGrid.BeginUpdate();

                // �O���b�h�̃J�����\��
                ChangeGridColumnHiddenForMiddleTree();

                for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                {
                    PrimeSettingGrid.Rows[rowIndex].Hidden = false;
                }

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
                {
                    // ADD 2009/01/14 �d�l�ύX���F�����ނ̂�������\������
                    SetGridLayoutAccordingToNodeLevel(node.Level);

                    if (node.Level == 0)    // MEMO:�����ރm�[�h
                    {
                        this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

                        // ���[�J�[���X�g�ŃO���b�h�\�����X�V
                        int selectedMiddleGenreCode = int.Parse(node.Key);
                        if (!UpdateGridByMakerList(selectedMiddleGenreCode)) continue;
                    }
                    // �ڍאݒ�̏ꍇ
                    else // MEMO:�i�ڃm�[�h
                    {
                        this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;

                        // �D�ǐݒ�O���[�v�ŃO���b�h�\�����X�V
                        int selectedMiddleGenreCode = int.Parse(node.Key.Substring(0, 4));
                        int selectedBLCode = int.Parse(node.Key.Substring(4, 8));
                        if (!UpdateGridByPrimeSettingGroup(selectedMiddleGenreCode, selectedBLCode)) continue;

                        int makerCode = 0;
                        foreach (UltraGridRow gridRow in this.PrimeSettingGrid.Rows)
                        {
                            if ((selectedMiddleGenreCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value) &&
                                (selectedBLCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                            {
                                makerCode = (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                                break;
                            }
                        }

                        NoteChangedEventArgs note = new NoteChangedEventArgs(selectedMiddleGenreCode, selectedBLCode, makerCode, string.Empty);

                        // ���l���X�V
                        this.noteLabel.Text = note.ToString();
                    }
                }

                // FIXME:�\�[�g���e���O���b�h�ɔ��f����Ȃ��H
                if (this.PrimeSettingGrid.Rows.Count > 0)
                {
                    for (int i = this.PrimeSettingGrid.Rows.Count - 1; i >= 0; i--)
                    {
                        this.PrimeSettingGrid.Rows[i].Selected = true;
                        this.PrimeSettingGrid.Rows[i].Activate();
                        this.PrimeSettingGrid.Rows[i].Selected = false;
                    }

                    if ((SettingNavigatorTree.SelectedNodes == null) || (SettingNavigatorTree.SelectedNodes.Count == 0))
                    {
                        return;
                    }
                    if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                    {
                        int makerCd = -1;
                        for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                            {
                                continue;
                            }

                            if (makerCd == (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value)
                            {
                                PrimeSettingGrid.Rows[rowIndex].Hidden = true;
                            }
                            makerCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                        }
                    }
                    else
                    {
                        Dictionary<string, string> mk_blDic = new Dictionary<string, string>();
                        for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                            {
                                continue;
                            }

                            int makerCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                            int blCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            //---------------ADD BY �����H ON 2011/11/30 FOR Redmain#8188--------->>>>>>>>>>>>
                            int order = (int)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value;
                            if (order == 0) { PrimeSettingGrid.Rows[rowIndex].Hidden = true; continue; };
                            //---------------ADD BY �����H ON 2011/11/30 FOR Redmain#8188---------<<<<<<<<<<<<
                            string key = makerCd.ToString("0000") + blCd.ToString("00000");

                            if (!mk_blDic.ContainsKey(key))
                            {
                                mk_blDic.Add(key, key);
                            }
                            else
                            {
                                PrimeSettingGrid.Rows[rowIndex].Hidden = true;
                            }
                        }
                    }
                }

                int makerDispOrder = 0;
                if ((SettingNavigatorTree.SelectedNodes == null) || (SettingNavigatorTree.SelectedNodes.Count == 0))
                {
                    return;
                }

                // �uNo�v�u�\�����v���Z�b�g���܂�
                if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                {
                    this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

                    foreach (DataRowView row in this._MgBlMkView)
                    {
                        row[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
                    }
                }
                else
                {
                    this._MgBlMkView.Sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

                    Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                    foreach (DataRowView row in this._MgBlMkView)
                    {
                        string key = ((int)row[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("0000") + ((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("0000") + ((int)row[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("00000");
                        //---------------ADD BY �����H ON 2011/11/30 FOR Redmain#8188--------->>>>>>>>>>>>
                        int order = (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                        if (order == 0) continue;
                        //---------------ADD BY �����H ON 2011/11/30 FOR Redmain#8188---------<<<<<<<<<<<<

                        if (!makerDispOrderDic.ContainsKey(key))
                        {
                            row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = ++makerDispOrder;
                            makerDispOrderDic.Add(key, (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER]);
                        }
                        else
                        {
                            row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = (int)makerDispOrderDic[key];
                        }
                    }
                }

                for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                {
                    this.PrimeSettingGrid.Rows[rowIndex].Selected = true;
                    this.PrimeSettingGrid.Rows[rowIndex].Activate();
                    this.PrimeSettingGrid.Rows[rowIndex].Selected = false;
                }

                this.PrimeSettingGrid.ActiveRow = null;
                this.PrimeSettingGrid.Update();
                this.PrimeSettingGrid.EndUpdate();

                // ���l���X�V
                if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                {
                    this.noteLabel.Text = string.Empty;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region �d�l���啝�ɕύX�������ߍ폜
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        this.PrimeSettingGrid.BeginUpdate();

        //        // �O���b�h�̃J�����\��
        //        ChangeGridColumnHiddenForMiddleTree();  // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

        //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
        //        {
        //            #region �폜�R�[�h
        //            //�S�̐ݒ�̏ꍇ
        //            /*
        //            if ((node.Level == 0) && (_navigeteIndex == 0))
        //            {
        //                s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, node.Key);
        //                s += String.Format(" and {0}={1}", PrimeSettingController.COL_TBSPARTSCODE, node.Nodes[0].Key.Substring(4, 8));
        //                _MgBlMkView.RowFilter = s;
        //            }
                
        //            //�ڍאݒ�̏ꍇ
        //            if (_navigeteIndex == 1)
        //            {
        //                //�e�w��͕\�����Ȃ�
        //                if (node.Level == 0)
        //                {
        //                //    s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, (Int32)0);
        //                //    _MgBlMkView.RowFilter = s;
        //                }
        //                else
        //                {
        //                    s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, node.Key.Substring(0, 4));
        //                    s += String.Format(" and {0}={1}", PrimeSettingController.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
        //                    _MgBlMkView.RowFilter = s;
        //                }
        //            }
        //            if (s == "") return;
        //            _MgBlMkView.RowFilter =
        //               String.Format("{0}=1 and ", PrimeSettingController.COL_CHECKSTATE) + s;
        //              */
        //            #endregion  // �폜�R�[�h

        //            // ADD 2009/01/14 �d�l�ύX���F�����ނ̂�������\������
        //            SetGridLayoutAccordingToNodeLevel(node.Level);

        //            if (node.Level == 0)    // MEMO:�����ރm�[�h
        //            {
        //                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

        //                // DEL 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ---------->>>>>
        //                //_MgBlMkView.RowFilter = String.Format("{0}={1} and {2}=1", PrimeSettingInfo.COL_MIDDLEGENRECODE, node.Key, PrimeSettingAcs.COL_CHECKSTATE);
        //                //_MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;
        //                // DEL 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ----------<<<<<
        //                // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ---------->>>>>
        //                // ���[�J�[���X�g�ŃO���b�h�\�����X�V
        //                int selectedMiddleGenreCode = int.Parse(node.Key);
        //                if (!UpdateGridByMakerList(selectedMiddleGenreCode)) continue;
        //                // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ----------<<<<<
        //            }
        //            // �ڍאݒ�̏ꍇ
        //            else // MEMO:�i�ڃm�[�h
        //            {
        //                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;

        //                // DEL 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        //                //string filter = String.Format("{0}={1}", PrimeSettingInfo.COL_MIDDLEGENRECODE, node.Key.Substring(0, 4));
        //                //filter += String.Format(" and {0}={1}", PrimeSettingInfo.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
        //                //_MgBlMkView.RowFilter = filter;
        //                //_MgBlMkView.RowFilter =
        //                //    //String.Format("{0}=1 and ", PrimeSettingController.COL_CHECKSTATE) + filter;  // DEL 2008/07/01
        //                //   String.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + filter;            // ADD 2008/07/01
        //                // DEL 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
        //                // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        //                // �D�ǐݒ�O���[�v�ŃO���b�h�\�����X�V
        //                int selectedMiddleGenreCode = int.Parse(node.Key.Substring(0, 4));
        //                int selectedBLCode = int.Parse(node.Key.Substring(4, 8));
        //                if (!UpdateGridByPrimeSettingGroup(selectedMiddleGenreCode, selectedBLCode)) continue;
        //                // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        //            }   // else
        //        }   // foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)

        //        // FIXME:�\�[�g���e���O���b�h�ɔ��f����Ȃ��H
        //        if (this.PrimeSettingGrid.Rows.Count > 0)
        //        {
        //            for (int i = this.PrimeSettingGrid.Rows.Count - 1; i >= 0; i--)
        //            {
        //                this.PrimeSettingGrid.Rows[i].Selected = true;
        //                this.PrimeSettingGrid.Rows[i].Activate();
        //                this.PrimeSettingGrid.Rows[i].Selected = false;
        //            }
        //        }

        //        int makerDispOrder = 0;
        //        foreach (DataRowView row in this._MgBlMkView)
        //        {
        //            row[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
        //        }
                
        //        this.PrimeSettingGrid.Update();
        //        this.PrimeSettingGrid.EndUpdate();
                
        //        // ���l���X�V
        //        this.noteLabel.Text = string.Empty; // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\��
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        #endregion �d�l���啝�ɕύX�������ߍ폜

        // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ---------->>>>>
        #region <�����ނ̂�������\��/>

        /// <summary>
        /// ���[�J�[���X�g�ŃO���b�h�\�����X�V���܂��B
        /// </summary>
        /// <param name="selectedMiddleGenreCode">�I�����ꂽ�����ރR�[�h</param>
        /// <returns><c>false</c>:�r���ŏ����𒆒f</returns>
        private bool UpdateGridByMakerList(int selectedMiddleGenreCode)
        {
            //this.PrimeSettingGrid.DataSource = null;

            string firstRowFilter = this._MgBlMkView.RowFilter;
            string firstSort = this._MgBlMkView.Sort;

            // �O���b�h�ւ̕\�����������Z�b�g
            StringBuilder allFilter = new StringBuilder();
            {
                allFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
            }
            this._MgBlMkView.RowFilter = allFilter.ToString();
            foreach (DataRowView row in this._MgBlMkView)
            {
                row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.None;
            }

            // A.�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�ɓo�^����Ă��郌�R�[�h
            StringBuilder userFilter = new StringBuilder();
            {
                userFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                userFilter.Append(ADOUtil.AND);
                userFilter.Append(PrimeSettingAcs.COL_USER_MAKERDISPORDER).Append(ADOUtil.LARGE).Append(0); // �񋟕��̒l��0
                userFilter.Append(ADOUtil.AND);
                userFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = userFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

            // B.�I�����������ރR�[�h�ɂЂ��Â��ABL�R�[�h�������[�J�[�����X�g�ɂ���
            // �N�����ɃA�N�Z�X�N���X�ɂĒ����ރR�[�h�ʂɍ\�z
#if DEBUG
            IList<int> makerCodeList = this._primeSettingController.FindMakerCode(selectedMiddleGenreCode);
            Debug.WriteLine("�����ރR�[�h�F" + selectedMiddleGenreCode.ToString());
            foreach (int makerCode in makerCodeList)
            {
                Debug.WriteLine("\t���[�J�[�R�[�h�F" + makerCode.ToString());
            }
#endif
            int gridDispOrderCount = 0; // �O���b�h�̃\�[�g�������߂�J�E���^

            // C.A��B�̍��������AA�̉���B�̎c���R�[�h��\������
            foreach (DataRowView row in this._MgBlMkView)
            {
                // �O���b�h�̃\�[�g����ݒ�
                row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridDispOrderCount;

                int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                if (this._primeSettingController.ContainsMakerCode(selectedMiddleGenreCode, makerCode))
                {
                    // A�̂����A�폜�Ώۂł͂Ȃ����R�[�h
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.ViewingRecord;
                }
                else
                {
                    // A�̂����A�폜�ΏۂƂȂ郌�R�[�h
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = gridDispOrderCount * (-1);  // �폜�Ώۂ̓O���b�h�̉��ɕ\��
                }
            }
            // �����ރR�[�h�Ńt�B���^�i�񋟕��݂̂ƂȂ�j
            StringBuilder makerFilter = new StringBuilder();
            {
                makerFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                makerFilter.Append(ADOUtil.AND);
                makerFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = makerFilter.ToString();

            // �c���R�[�h�ƍ폜�Ώۃ��R�[�h�̃O���b�h�̃\�[�g����ݒ�
            int deleteingRecordDispOrderCount = this._MgBlMkView.Count;

            foreach (DataRowView row in this._MgBlMkView)
            {
                // �c���R�[�h
                int userMakerDispOrder = (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                if (userMakerDispOrder.Equals(0))
                {
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridDispOrderCount;
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.ViewingRecord;
                }

                // �폜���R�[�h
                int gridDispOrder = (int)row[PrimeSettingAcs.COL_GRIDSORTORDER];
                if (gridDispOrder < 0)  // �O�i��C.�̏����Ń}�[�L���O�ς�
                {
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++deleteingRecordDispOrderCount;
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
                }
            }

            // C.��{�ݒ�ɂāA��\���ƂȂ��Ă��郌�R�[�h�i�폜�Ώہj�F���[�U�[�\���� > 0 && �`�F�b�N==�Ȃ� && BL�R�[�h<>0
            StringBuilder uncheckedFilter = new StringBuilder();
            {
                uncheckedFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                uncheckedFilter.Append(ADOUtil.AND);
                uncheckedFilter.Append(PrimeSettingAcs.COL_USER_MAKERDISPORDER).Append(ADOUtil.LARGE).Append(0);    // �񋟕��̒l��0
                uncheckedFilter.Append(ADOUtil.AND);
                uncheckedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(0);
                uncheckedFilter.Append(ADOUtil.AND);                                                        // FIXME:BL�R�[�h=0�͖���
                uncheckedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0); // FIXME:BL�R�[�h=0�͖���
            }
            this._MgBlMkView.RowFilter = uncheckedFilter.ToString();
            
            foreach (DataRowView row in this._MgBlMkView)
            {
                row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++deleteingRecordDispOrderCount;
                row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
            }

            // �\�������ēx�U�蒼��
            StringBuilder gridFilter = new StringBuilder();
            {
                gridFilter.Append(ADOUtil.BEGIN_BLOCK);
                gridFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                gridFilter.Append(ADOUtil.AND);
                gridFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                gridFilter.Append(ADOUtil.END_BLOCK);

                gridFilter.Append(ADOUtil.OR);

                gridFilter.Append(ADOUtil.BEGIN_BLOCK);
                gridFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                gridFilter.Append(ADOUtil.AND);
                gridFilter.Append(PrimeSettingAcs.COL_USER_STATUS).Append(ADOUtil.NOT_EQ).Append((int)PrimeSettingAcs.UserStatus.None);
                gridFilter.Append(ADOUtil.END_BLOCK);
            }
            this._MgBlMkView.RowFilter = gridFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingAcs.COL_GRIDSORTORDER;

            int makerDispOrder = 1;
            foreach (DataRowView record in this._MgBlMkView)
            {
                record[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
                record[PrimeSettingInfo.COL_MAKERDISPORDER] = record[PrimeSettingAcs.COL_GRIDSORTORDER];
            }

            //this.PrimeSettingGrid.DataSource = this._MgBlMkView;

            // �폜�Ώۂ��O���b�h�F��ύX
            for (int i = 0; i < this.PrimeSettingGrid.Rows.Count; i++)
            {
                int userStatus = (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingAcs.COL_USER_STATUS].Value;
                if (userStatus.Equals((int)PrimeSettingAcs.UserStatus.DeletingRecord))
                {
                    this.PrimeSettingGrid.Rows[i].Appearance.BackColor = Color.Pink;
                }
                else
                {
                    this.PrimeSettingGrid.Rows[i].Appearance.Reset();
                }
            }

            // BL�R�[�h=0 �̃f�[�^���\�Ƃ��ĕ\��
            Dictionary<int, int> makerCodeDic = new Dictionary<int, int>();
            foreach (DataRowView row in this._MgBlMkView)
            {
                int makerCode = (Int32)row[PrimeSettingInfo.COL_PARTSMAKERCD];

                if (!makerCodeDic.ContainsKey(makerCode))
                {
                    makerCodeDic.Add(makerCode, makerCode);
                }
            }

            allFilter = new StringBuilder();
            {
                int index = 0;
                foreach (int makerCode in makerCodeDic.Values)
                {
                    if (index != 0)
                    {
                        allFilter.Append(ADOUtil.OR);
                    }

                    allFilter.Append(ADOUtil.BEGIN_BLOCK);
                    allFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                    allFilter.Append(ADOUtil.AND);
                    allFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(0);
                    allFilter.Append(ADOUtil.AND);
                    allFilter.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(makerCode);
                    allFilter.Append(ADOUtil.END_BLOCK);
                    index++;
                }
            }

            this._MgBlMkView.RowFilter = allFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

            // ----- DEL 2012/09/25 xupz for redmine#32367----->>>>>
            //ArrayList targetList = new ArrayList();
            //foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
            //{
            //    if (((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE] == selectedMiddleGenreCode) &&
            //        ((int)row[PrimeSettingInfo.COL_TBSPARTSCODE] != 0))
            //    {
            //        targetList.Add(row);
            //    }
            //}

            //foreach (DataRowView row in this._MgBlMkView)
            //{
            //    int makerCode = (Int32)row[PrimeSettingInfo.COL_PARTSMAKERCD];
            //    int supplierCode = 0;
            //    if (row[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
            //    {
            //        supplierCode = (Int32)row[PrimeSettingInfo.COL_SUPPLIERCD];
            //    }

            //    Dictionary<int, int> supplierCodeDic = new Dictionary<int, int>();
            //    foreach (DataRowView rowView in targetList)
            //    {
            //        if (makerCode == (Int32)rowView[PrimeSettingInfo.COL_PARTSMAKERCD])
            //        {
            //            int supplierCd = 0;
            //            if (rowView[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
            //            {
            //                supplierCd = (Int32)rowView[PrimeSettingInfo.COL_SUPPLIERCD];
            //            }

            //            if (supplierCd != 0)
            //            {
            //                if (!supplierCodeDic.ContainsKey(supplierCd))
            //                {
            //                    supplierCodeDic.Add(supplierCd, supplierCd);
            //                }
            //            }
            //        }
            //    }

            //    if (supplierCodeDic.Values.Count == 1)
            //    {
            //        foreach (int code in supplierCodeDic.Values)
            //        {
            //            row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        row[PrimeSettingInfo.COL_SUPPLIERCD] = DBNull.Value;
            //    }
            //}
            // ----- DEL 2012/09/25 xupz for redmine#32367-----<<<<<

            return true;
        }

        #endregion  // <�����ނ̂�������\��/>
        // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ----------<<<<<

        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        #region <�֘ABL�R�[�h�̕\��/>

        /// <summary>
        /// �D�ǐݒ�O���[�v�ŃO���b�h�\�����X�V���܂��B
        /// </summary>
        /// <param name="selectedMiddleGenreCode">�I�����ꂽ�����ރR�[�h</param>
        /// <param name="selectedBLCode">�I�����ꂽBL�R�[�h</param>
        /// <returns><c>false</c>:�r���ŏ����𒆒f</returns>
        private bool UpdateGridByPrimeSettingGroup(
            int selectedMiddleGenreCode,
            int selectedBLCode
        )
        {
            // 1.�����ރR�[�h + BL�R�[�h�Ńt�B���^
            StringBuilder selectedFilter = new StringBuilder();
            {
                selectedFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                selectedFilter.Append(ADOUtil.AND);
                selectedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(selectedBLCode);
                selectedFilter.Append(ADOUtil.AND);
                selectedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = selectedFilter.ToString();

            string firstFilter = this._MgBlMkView.RowFilter;
            string firstSort = this._MgBlMkView.Sort;

            // 2.�\����, ���[�J�[�R�[�h�Ń\�[�g
            string sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + ADOUtil.COMMA + PrimeSettingInfo.COL_PARTSMAKERCD;
            this._MgBlMkView.Sort = sort;

            // 3.���\�[�g����ݒ肵�Ȃ���D�ǐݒ�O���[�v���擾
            //int gridSortOrder = 0;
            IDictionary<int, int> primeSettingGroupMap = new Dictionary<int, int>();
            foreach (DataRowView row in this._MgBlMkView)
            {
                // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridSortOrder;
                // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                row[PrimeSettingAcs.COL_RELATEDBLCODE] = string.Empty;  // �֘A���̃Z���͋�ɂ���

                int primeSettingGroup = (int)row[PrimeSettingInfo.COL_PRMSETGROUP];

                if (!PrimeSettingAcs.ExistsGroup0)
                {
                    if (primeSettingGroup.Equals(0)) continue;
                }

                if (!primeSettingGroupMap.ContainsKey(primeSettingGroup))
                {
                    primeSettingGroupMap.Add(primeSettingGroup, primeSettingGroup);
                }
            }

            // 4.�D�ǐݒ�O���[�v�Ńt�B���^���Đݒ�
            StringBuilder where = new StringBuilder();
            {
                foreach (int primeSettingGroup in primeSettingGroupMap.Values)
                {
                    if (string.IsNullOrEmpty(where.ToString()))
                    {
                        where.Append("(");
                    }
                    else
                    {
                        where.Append(ADOUtil.OR);
                    }
                    where.Append(PrimeSettingInfo.COL_PRMSETGROUP).Append(ADOUtil.EQ).Append(primeSettingGroup);
                }
                if (!string.IsNullOrEmpty(where.ToString()))
                {
                    where.Append(")");
                }
            }
            if (!string.IsNullOrEmpty(where.ToString()))
            {
                where.Append(ADOUtil.AND).Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                this._MgBlMkView.RowFilter = where.ToString();
            }
            else
            {
                this._MgBlMkView.RowFilter = firstFilter;
                this._MgBlMkView.Sort = firstSort;
                //return false;
                return true;
            }

            // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
            //// 5.�\�[�g����ݒ�
            //foreach (DataRowView row in this._MgBlMkView)
            //{
            //    int currentGridSortOrder = (int)row[PrimeSettingAcs.COL_GRIDSORTORDER];
            //    int currentMiddleGenreCode = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
            //    int currentBLCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];
            //    if (!(currentMiddleGenreCode.Equals(selectedMiddleGenreCode) && currentBLCode.Equals(selectedBLCode)))
            //    {
            //        row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridSortOrder;
            //    }
            //    // �\�������ݒ�
            //    row[PrimeSettingInfo.COL_MAKERDISPORDER] = row[PrimeSettingAcs.COL_GRIDSORTORDER];
            //}

            //// 6.�\�[�g���Ń\�[�g
            //this._MgBlMkView.Sort = PrimeSettingAcs.COL_GRIDSORTORDER;
            // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

            // 7.�֘ABL�R�[�h��ݒ�
            foreach (DataRowView row in this._MgBlMkView)
            {
                string relatedBLCode = (string)row[PrimeSettingAcs.COL_RELATEDBLCODE];
                if (string.IsNullOrEmpty(relatedBLCode))
                {
                    int middleGenreCode = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];
                    if (!(middleGenreCode.Equals(selectedMiddleGenreCode) && blCode.Equals(selectedBLCode)))
                    {
                        relatedBLCode = this._primeSettingController.GetRelatedBLCodeName(blCode);
                        row[PrimeSettingAcs.COL_RELATEDBLCODE] = relatedBLCode;
                    }
                }
            }

            // 8.�\�����Ń\�[�g
            //this._MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD;
            //this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;
            this._MgBlMkView.Sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

            return true;
        }

        #endregion  // <�֘ABL�R�[�h�̕\��/>
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        /// <summary>
        /// ������-�i�ڃc���[�̃m�[�h�ɉ������O���b�h�\����ݒ肵�܂��B
        /// </summary>
        /// <param name="nodeLevel">�m�[�h���x��</param>
        private void SetGridLayoutAccordingToNodeLevel(int nodeLevel)
        {
            //�񕝎�������
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            // �����ރm�[�h
            if (nodeLevel.Equals(0))
            {
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Caption = "No.";
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Hidden = false;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Hidden = true;
                band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Hidden = true;

                if (!band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = true;
                }

                // FIXME:�f�o�b�O�p��
                //band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden = false;
                //band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = false;
            }
            // �i�ڃm�[�h
            else
            {
                //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Caption = "�\����";
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Hidden = true;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Hidden = false;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.Caption = "�\����";
                band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Hidden = false;
                
                if (PrimeSettingAcs.ExistsGroup0)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = false;
                }
                // FIXME:�f�o�b�O�p��

                if (!band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden = true;
                }
                if (!band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = true;
                }
            }

            // �񕝎�������
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            //// TODO:�����ɕ��������̂Ŕ�����
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = MAKER_CODE_COLUMN_WIDTH;
        }
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = PrimeSettingGrid;

            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // ��̕\���^��\���i�f�t�H���g�j
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_MAKERDISPORDER:
                    case PrimeSettingInfo.COL_PARTSMAKERCD:
                    case PrimeSettingInfo.COL_PARTSMAKERFULLNAME:

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Width = 60;
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].MaxWidth = 60;
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].MinWidth = 60;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 90;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Width = 150;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MaxWidth = 150;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MinWidth = 150;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Width = 120;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].MaxWidth = 120;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].MinWidth = 120;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Width = 200;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].MaxWidth = 200;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].MinWidth = 200;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Width = 120;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].MaxWidth = 120;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].MinWidth = 120;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Width = 60;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].MaxWidth = 60;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].MinWidth = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Width = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].MaxWidth = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].MinWidth = 60;

            // �\����
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.VisiblePosition = 0;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.VisiblePosition = 1;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.VisiblePosition = 2;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 3;
            // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 4;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 5;
            // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Header.VisiblePosition = 6;       // MOD 2008/10/29 �s��Ή�[6969] �d�l�ύX 3��5
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Header.VisiblePosition = 7;    // MOD 2008/10/29 �s��Ή�[6969] �d�l�ύX 4��6
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Header.VisiblePosition = 8;     // MOD 2008/10/29 �s��Ή�[6969] �d�l�ύX 5��7
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].Header.VisiblePosition = 9;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Header.VisiblePosition = 10;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Header.VisiblePosition = 11;
            //band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.VisiblePosition = 11;
            band.Columns[PrimeSettingAcs.COL_USER_STATUS].Header.VisiblePosition = 12;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ---------->>>>>
            // �^�C�g���\���ʒu
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ----------<<<<<
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // �\���ʒu
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;// MOD 2008/10/28 �s��Ή�[6968] .Center��.Right
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // MOD 2008/10/28 �s��Ή�[6968] .Center��.Right
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ADD 2008/10/28 �s��Ή�[6969]---------->>>>>
            // �\���t�H�[�}�b�g
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Format = "0000";
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Format = "0000";
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Format = "000000";
            // ADD 2008/10/28 �s��Ή�[6969]----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
            // �ҏW�s�ݒ�
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellActivation = Activation.AllowEdit;// MOD 2008/10/28 �s��Ή�[6963] .Disabled��.AllowEdit
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellActivation = Activation.Disabled; // MOD 2009/01/13 �d�l�ύX�F�\�����̎���͂�p�~ .AllowEdit��.Disabled
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].TabStop = true;   // HACK:�ҏW�\�Z����TabStop
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellActivation = Activation.Disabled;       // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellActivation = Activation.Disabled;   // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].CellActivation = Activation.AllowEdit;    // ���͉�
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].TabStop = true;   // HACK:�ҏW�\�Z����TabStop
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellActivation = Activation.Disabled;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellActivation = Activation.Disabled;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellActivation = Activation.Disabled;

            // �Z���N���b�N����
            // ADD 2009/01/13 �d�l�ύX�F�\�����̎���͂�p�~�i�s��Ή�[6963]�ɂ��폜�𕜊��j
            // DEL 2008/10/28 �s��Ή�[6963]��
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellClickAction = CellClickAction.RowSelect;    // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellClickAction = CellClickAction.RowSelect;// ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellClickAction = CellClickAction.RowSelect;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellClickAction = CellClickAction.RowSelect;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellClickAction = CellClickAction.RowSelect;

            // �O�i�F�̐ݒ�
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.ForeColorDisabled = Color.Black;     // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.ForeColorDisabled = Color.Black; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellAppearance.ForeColorDisabled = Color.Black;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellAppearance.ForeColorDisabled = Color.Black;
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellAppearance.ForeColorDisabled = Color.Black;

            // �\���ʒu����
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �ύX����
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

            // --- ADD 2008/07/01 -------------------------------->>>>>
            // �K�C�h�{�^���̐ݒ�
            // --- CHG 2009/02/19 ��QID:10404�Ή�------------------------------------------------------>>>>>
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Width = 19;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Width = 20;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].MinWidth = 20;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].MaxWidth = 20;
            // --- CHG 2009/02/19 ��QID:10404�Ή�------------------------------------------------------<<<<<
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].CellActivation = Activation.NoEdit;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            #region �폜�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �L�[����}�b�s���O��ǉ�
            //grid.KeyActionMappings.Add(
            //    new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //        Keys.Enter,	//Enter�L�[
            //        Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
            //        0,
            //        Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //        Infragistics.Win.SpecialKeys.All,
            //        0 )
            //    );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            #endregion  // �폜�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �L�[�}�b�s���O����
            MakeKeyMappingForGrid(grid);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2008/10/28 �s��Ή�[6966]---------->>>>>
            // TODO:�����ɕ��������̂Ŕ�����
            // DEL 2009/01/30 �s��Ή�[10404]��
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width += DELTA_WHITH;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 120;    // ADD 2009/01/30 �s��Ή�[10404]
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].MaxWidth = 120;    // ADD 2009/01/30 �s��Ή�[10404]
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].MinWidth = 120;    // ADD 2009/01/30 �s��Ή�[10404]
            // ADD 2008/10/28 �s��Ή�[6966]----------<<<<<
        }


        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �S�̐ݒ�{�^��
                case TOOL_GROBAL:
                    {
                        //setMG_BLTreeView(0);
                        //_navigeteIndex = 0;
                        break;
                    }
                // �ڍאݒ�{�^��
                case TOOL_DETAIL:
                    {
                        if (_navigeteIndex == 1) break;
                        SetMG_BLTreeView(1);
                        // TODO:�ڍאݒ�{�^���������̃c���[�\���H
                        _navigeteIndex = 1;
                        break;
                    }

                // ���(�m�[�h)
                case TOOL_PRIOR:
                    {
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        if (SettingNavigatorTree.Nodes.Count == 0)
                        {
                            return;
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        // DEL 2008/10/29 �s��Ή�[6969] �d�l�ύX�i���\�b�h�Ƃ��Ē��o�j ---------->>>>>
                        #region �폜�R�[�h
                        //if (SettingNavigatorTree.SelectedNodes[0] != null)
                        //{
                        //    Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                        //    if (node.PrevVisibleNode != null)
                        //    {
                        //        if (node.PrevVisibleNode.Level == 1)
                        //        {
                        //            node.PrevVisibleNode.Parent.Selected = true;
                        //        }
                        //        else
                        //        {
                        //            node.PrevVisibleNode.Selected = true;
                        //        }
                        //    }
                        //}
                        #endregion  // �폜�R�[�h
                        // DEL 2008/10/29 �s��Ή�[6969] �d�l�ύX�i���\�b�h�Ƃ��Ē��o�j----------<<<<<
                        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ---------->>>>>
                        if (!IsMakerTab(this.makerMiddleTab.ActiveTab))
                        {
                            SelectUp(this.SettingNavigatorTree);
                        }
                        else
                        {
                            SelectUp(this.MK_BLSettingNavigatorTree);
                        }
                        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ----------<<<<<
                        break;
                    }

                // ����(�m�[�h)
                case TOOL_NEXT:
                    {
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        if (SettingNavigatorTree.Nodes.Count == 0)
                        {
                            return;
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        // DEL 2008/10/29 �s��Ή�[6969] �d�l�ύX�i���\�b�h�Ƃ��Ē��o�j ---------->>>>>
                        #region �폜�R�[�h
                        //if (SettingNavigatorTree.SelectedNodes[0] != null)
                        //{
                        //    Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                        //    if (node.NextVisibleNode != null)
                        //    {
                        //        if (node.NextVisibleNode.Level == 1)
                        //        {
                        //            while (true)
                        //            {
                        //                node = node.NextVisibleNode;
                        //                if (node == null) return;
                        //                if (node.Level == 0) break;
                        //            }
                        //            node.Selected = true;
                        //        }
                        //        else
                        //        {
                        //            node.NextVisibleNode.Selected = true;
                        //        }
                        //    }
                        //}
                        #endregion  // �폜�R�[�h
                        // DEL 2008/10/29 �s��Ή�[6969] �d�l�ύX�i���\�b�h�Ƃ��Ē��o�j----------<<<<<
                        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ---------->>>>>
                        if (!IsMakerTab(this.makerMiddleTab.ActiveTab))
                        {
                            SelectDown(this.SettingNavigatorTree);
                        }
                        else
                        {
                            SelectDown(this.MK_BLSettingNavigatorTree);
                        }
                        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ----------<<<<<
                        break;
                    }

                // ���
                case TOOL_UP:
                    {
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        #region �폜�R�[�h
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    int order = PrimeSettingGrid.ActiveRow.Index + 1;

                        //    if (idx == 0) return;
                        //    //��ɃA�C�e�����擾���Ă���
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row1 = PrimeSettingGrid.Rows[idx - 1];
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];

                        //    //��̃A�C�e���̏��ʂ�������
                        //    row1.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order;
                        //    row1.Update();

                        //    //�I������Ă���Row�̏��ʂ��グ��
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order - 1;
                        //    selectrow.Update();
                        //    selectrow.Selected = true;
                        //    PrimeSettingGrid.ActiveRow = selectrow;
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        MoveUpGridRow(1);   // 1��ֈړ�
                        break;
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                    }

                // ����
                case TOOL_DOWN:
                    {
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        #region �폜�R�[�h
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    int order = PrimeSettingGrid.ActiveRow.Index + 1;
                        //    if (PrimeSettingGrid.Rows.Count <= order) return;
                        //    //��ɃA�C�e�����擾���Ă���
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[idx + 1];
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];

                        //    //���̃A�C�e���̏��ʂ��グ��
                        //    row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order;
                        //    row.Update();
                        //    //�I������Ă���Row�̏��ʂ�������
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order + 1;
                        //    selectrow.Update();
                        //    selectrow.Selected = true;
                        //    PrimeSettingGrid.ActiveRow = selectrow;
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        MoveDownGridRow(1); // 1���ֈړ�
                        break;
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                    }

                // TODO:[�g�b�v��]
                case TOOL_TOP:
                    {
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        #region �폜�R�[�h
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    if (idx == 0) return;

                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 0;
                        //    selectrow.Update();
                        //    for (int i = idx; 1 <= i; i--)
                        //    {
                        //        //��̃A�C�e���̏��ʂ�������
                        //        Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[i];
                        //        row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = i + 1;
                        //        row.Update();
                        //    }

                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 1;
                        //    selectrow.Update();
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        MoveUpGridRow(0);   // 0:�擪�ֈړ�
                        break;
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                    }
                // TODO:[�{�g����]
                case TOOL_BOTTOM:
                    {
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        #region �폜�R�[�h
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    if (idx == PrimeSettingGrid.Rows.Count-1) return;

                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 0;
                        //    selectrow.Update();
                        //    for (int i = idx; i < PrimeSettingGrid.Rows.Count; i++)
                        //    {
                        //        //���̃A�C�e���̏��ʂ��グ��
                        //        Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[i];
                        //        row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = i;
                        //        row.Update();
                        //    }

                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = PrimeSettingGrid.Rows.Count;
                        //    selectrow.Update();
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
                        MoveDownGridRow(0); // 0:�����ֈړ�
                        break;
                        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
                    }
                // --- ADD 2008/07/01 -------------------------------->>>>>
                // �d����N���A
                case TOOL_SUPPLIER:
                    {
                        if (PrimeSettingGrid.ActiveRow != null)
                        {
                            int idx = PrimeSettingGrid.ActiveRow.Index;

                            Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                            selectrow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;
                            selectrow.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;

                            // �ύX�t���O�X�V
                            _primeSettingController.ChangeSupplierCd((int)selectrow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                                     (int)selectrow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                                     (int)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                                     0);

                            // --- ADD 2009/03/11 ��QID:12368�Ή�------------------------------------------------------>>>>>
                            PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);
                            PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            selectrow.Update();
                            // --- ADD 2009/03/11 ��QID:12368�Ή�------------------------------------------------------<<<<<
                        }

                        break;
                    }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
        }

        private void PrimeSettingGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (PrimeSettingGrid.Selected.Rows.Count == 0) return;
            if (PrimeSettingGrid.Selected.Rows[0] != PrimeSettingGrid.ActiveRow)
            {
                PrimeSettingGrid.ActiveRow.Selected = true;
            }
        }

        private void PMKEN09014UA_Leave(object sender, EventArgs e)
        {
            // DEL 2008/11/21 �s��Ή�[8175] ���\�������^�u�𑼂̃^�u��I������Ə��������
            //_primeSettingController.setMakerDispOrderView();
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// �d����R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void PrimeSettingGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            int status;

            if (_supplierAcs == null)
            {
                // �C���X�^���X����
                _supplierAcs = new SupplierAcs();
            }

            // �K�C�h�N��
            Supplier supplier;
            status = _supplierAcs.ExecuteGuid(out supplier, _primeSettingController.EnterPriseCode, "0");

            if (status != 0) return;

            // �I����������Cell�ɐݒ�
            e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = supplier.SupplierCd;       // �d����R�[�h
            e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = supplier.SupplierNm1;    // �d���於��

            // �ύX�t���O�X�V
            _primeSettingController.ChangeSupplierCd((int)e.Cell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                     (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                     (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                     supplier.SupplierCd);
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
        # region [�O���b�h �L�[�}�b�s���O]
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }
        # endregion

        # region [�Z���X�V���C�x���g����]

        /// <summary>
        /// �Z���X�V�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            //int stockRowNo = this._stockDataTable[cell.Row.Index].StockRowNo;            
            //int rowIndex = e.Cell.Row.Index;
            //this._cannotGoodsReaded = false;
            //this._cannotWarehouseReaded = false;
            //this._errstockCount = false;
            //this._errstockUnitPrice = false;
            //this._errsalesOrderUnit = false;
            //this._errmaximumStockCnt = false;

            // �d������̓`�F�b�N
            //StockExpansion stockExpansion = this._stockInputAcs.StockExpansion;
            //if (stockExpansion == null) return;

            // NULL�ɑ΂���␳
            if (e.Cell.Value is DBNull)
            {
                // --- CHG 2009/03/10 ��QID:12261,12265�Ή�------------------------------------------------------>>>>>
                //if ((e.Cell.Column.DataType == typeof(Int32)) ||
                //    (e.Cell.Column.DataType == typeof(Int64)))
                //{
                //    e.Cell.Value = 0;
                //}
                //else if (e.Cell.Column.DataType == typeof(double))
                //{
                //    e.Cell.Value = 0.0;
                //}
                this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;       // �d����R�[�h
                e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;    // �d���於��
                this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                return;
                // --- CHG 2009/03/10 ��QID:12261,12265�Ή�------------------------------------------------------<<<<<
            }

            // ActiveCell���d����R�[�h�̏ꍇ
            if (cell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
            {
                int supplierCd = ToInt(cell.Value.ToString());
                int code;
                string name;
                ReadSupplier(supplierCd, out code, out name);

                if (code != 0)
                {
                    // �I����������Cell�ɐݒ�
                    //e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = code;       // �d����R�[�h
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = name;    // �d���於��
                }
                else
                {
                    // --- ADD 2009/02/19 ��QID:7043�Ή�------------------------------------------------------>>>>>
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                    "PMKEN09014U",
                                    "�}�X�^�ɓo�^����Ă��܂���B",
                                    0,
                                    MessageBoxButtons.OK);
                    // --- ADD 2009/02/19 ��QID:7043�Ή�------------------------------------------------------<<<<<

                    // �I����������Cell�ɐݒ�
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;       // �d����R�[�h
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;    // �d���於��
                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                    // --- ADD 2009/02/19 ��QID:7043�Ή�------------------------------------------------------>>>>>
                    return;
                    // --- ADD 2009/02/19 ��QID:7043�Ή�------------------------------------------------------<<<<<
                }

                // �ύX�t���O�X�V
                _primeSettingController.ChangeSupplierCd((int)e.Cell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                         (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                         (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                         code);

                // ADD 2008/10/29 �s��Ή�[6972]---------->>>>>
                // TODO:�ꊇ�Ŏd�����ݒ�
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value)
                )
                {
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;

                    //int makerCode = int.Parse(MK_BLSettingNavigatorTree.SelectedNodes[0].Key.Substring(0, 4));//DEL BY ������ on 2011/11/22 for Redmine#8033
                    //--------------ADD BY ������ on 2011/11/22 for Redmine#8033 ----------->>>>>>>>>>>>
                    string tempCode = Convert.ToInt32(MK_BLSettingNavigatorTree.SelectedNodes[0].Key.Split(':')[0]).ToString("0000");
                    int makerCode = int.Parse(tempCode.Substring(0, 4));
                    //--------------ADD BY ������ on 2011/11/22 for Redmine#8033 -----------<<<<<<<<<<<<
                    foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
                    {
                        if (makerCode == (int)row[PrimeSettingInfo.COL_PARTSMAKERCD])
                        {
                            row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
                            row[PrimeSettingInfo.COL_SUPPLIERNAME] = name;

                            // �ύX�t���O�X�V
                            _primeSettingController.ChangeSupplierCd((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE],
                                                                     (int)row[PrimeSettingInfo.COL_PARTSMAKERCD],
                                                                     (int)row[PrimeSettingInfo.COL_TBSPARTSCODE],
                                                                     code);
                        }
                    }

                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }
                else
                {
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    int makerCode = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                    int goodsMGroup = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                    int blGoodsCode = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                    if (blGoodsCode != 0)
                    {
                        for (int i = 1; i < this.PrimeSettingGrid.Rows.Count; i++)
                        {
                            if ((makerCode == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                (goodsMGroup == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value) &&
                                (blGoodsCode == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                            {
                                this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = code; // �d����R�[�h
                                this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = name; // �d���於��
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
                        {
                            if ((makerCode == (int)row[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                (goodsMGroup == (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                            {
                                row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
                                row[PrimeSettingInfo.COL_SUPPLIERNAME] = name;

                                // �ύX�t���O�X�V
                                _primeSettingController.ChangeSupplierCd((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE],
                                                                         (int)row[PrimeSettingInfo.COL_PARTSMAKERCD],
                                                                         (int)row[PrimeSettingInfo.COL_TBSPARTSCODE],
                                                                         code);
                            }
                        }
                    }
                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }
                // ADD 2008/10/29 �s��Ή�[6972]----------<<<<<
            }

            // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
            // �\�����̕ύX ��2009/01/15 �d�l�ύX�F�\�����̕ҏW�@�\�͔p�~
            if (e.Cell.Column.Key.Equals(PrimeSettingInfo.COL_MAKERDISPORDER))
            {
                Debug.WriteLine("�ύX���ꂽ�\�����F" + e.Cell.Value.ToString());
                CurrentDataViewRowFilter = _MgBlMkView.RowFilter;
                DefaultDataViewSort = _MgBlMkView.Sort;

                SwapGridRowByMakerDispOrder(e.Cell);

                // �ҏW�\��Ԃɂ�����
                this.PrimeSettingGrid.Focus();
                if (this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                {
                    if (!(this.PrimeSettingGrid.ActiveCell.Value is System.DBNull))
                    {
                        // �S�I����Ԃɂ���B
                        //this.PrimeSettingGrid.ActiveCell.SelectAll();
                        this.PrimeSettingGrid.ActiveCell.SelStart = 0;
                        this.PrimeSettingGrid.ActiveCell.SelLength = this.PrimeSettingGrid.ActiveCell.Text.Length;

                        this.PrimeSettingGrid.ActiveRow.Selected = true;    // HACK:�S�I����ԂɂȂ�Ȃ��̂ŁA��
                    }
                }

            }
            // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<
        }

        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ---------->>>>>
        // TODO:�\�����̐���
        #region <�\�����̐���/>

        /// <summary>
        /// �D�ǐݒ�O���b�h��BeforeCellUpdate�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PrimeSettingGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key.Equals(PrimeSettingInfo.COL_MAKERDISPORDER))
            {
                // �ύX�O�̒l��ێ�
                UpdatingMakerDispOrder = (int)e.Cell.Value;
            }
        }

        #region <�f�[�^�r���[/>

        /// <summary>���݂̃f�[�^�r���[�̃t�B���^</summary>
        private string _currentDataViewRowFilter;
        /// <summary>
        /// ���݂̃f�[�^�r���[�̃t�B���^�̃A�N�Z�T
        /// </summary>
        private string CurrentDataViewRowFilter
        {
            get { return _currentDataViewRowFilter; }
            set { _currentDataViewRowFilter = value; }
        }

        /// <summary>�f�[�^�r���[�̃f�t�H���g�\�[�g</summary>
        private string _defaultDataViewSort;
        /// <summary>
        /// �f�[�^�r���[�̃f�t�H���g�\�[�g�̃A�N�Z�T
        /// </summary>
        /// <value>�f�[�^�r���[�̃f�t�H���g�\�[�g</value>
        private string DefaultDataViewSort
        {
            get
            {
                return PrimeSettingInfo.COL_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;
            }
            set { _defaultDataViewSort = value; }   // HACK:��
        }

        /// <summary>�f�[�^�r���[���\�[�g���t���O</summary>
        private bool _sortingDataView;
        /// <summary>
        /// �f�[�^�r���[���\�[�g���t���O�̃A�N�Z�T
        /// </summary>
        /// <value>�f�[�^�r���[���\�[�g���t���O</value>
        private bool SortingDataView
        {
            get { return _sortingDataView; }
            set { _sortingDataView = value; }
        }

        #endregion  // <�f�[�^�r���[/>

        /// <summary>�ύX�O�̕\����</summary>
        private int _updatingMakerDispOrder;
        /// <summary>
        /// �ύX�O�̕\�����̃A�N�Z�T
        /// </summary>
        /// <value>�ύX�O�̕\����</value>
        public int UpdatingMakerDispOrder
        {
            get { return _updatingMakerDispOrder; }
            set { _updatingMakerDispOrder = value; }
        }

        /// <summary>
        /// �I�����Ă���D�ǐݒ�O���b�h�s��1�s��Ɉړ������܂��B
        /// </summary>
        /// <param name="step">
        /// �ړ����鑊�Έʒu<br/>
        /// ��<c>0</c>���w�肷��Ɛ擪�ֈړ����܂��B
        /// </param>
        /// <remarks>
        /// <br>Update Note: 2011/11/19 杍^</br>
        /// <br>�Ǘ��ԍ�   �F10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27453�@�D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��</br>
        /// </remarks>
        private void MoveUpGridRow(int step)
        {
            if (this.PrimeSettingGrid.ActiveRow != null)
            {
                if (this.PrimeSettingGrid.ActiveRow.Index.Equals(0)) return;

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //int previousIndex = this.PrimeSettingGrid.ActiveRow.Index - step;
                //if (step.Equals(0))
                //{
                //    previousIndex = 0;
                //}

                //GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[previousIndex]);
                //int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                //GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                //activeGridRow.MakerDispOrder = swapMakerDispOrder;

                //previousGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Selected = true;
                //this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;

                if (step != 0)
                {
                    int previousIndex = this.PrimeSettingGrid.ActiveRow.Index - step;

                    if (previousIndex >= 0)
                    {
                        for (int index = this.PrimeSettingGrid.ActiveRow.Index - 1; index >= 0; index--)
                        {
                            if (this.PrimeSettingGrid.Rows[index].Hidden == false)
                            {
                                previousIndex = index;
                                break;
                            }
                            // ADD 2011/12/15 --- >>>>
                            else
                            {
                                if (index == 0)
                                {
                                    return;
                                }
                            }
                            // ADD 2011/12/15 --- <<<<
                        }

                        GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[previousIndex]);
                        int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                        GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                        previousGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;

                        previousGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Selected = true;
                        this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                    }
                }
                else
                {
                    GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);

                    for (int rowIndex = PrimeSettingGrid.ActiveRow.Index - 1; rowIndex >= 0; rowIndex--)
                    {
                        if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                        {
                            continue;
                        }

                        GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[rowIndex]);
                        int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                        previousGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;
                        
                        previousGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                    }

                    activeGridRow.MyGridRow.Selected = true;
                    this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                }

                // DEL 杍^ 2011/12/19  Redmine#27453 -------- >>>>>>>>>
                //Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                //for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
                //{
                //    if (PrimeSettingGrid.Rows[index].Hidden == false)
                //    {
                //        int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                //        int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                //        int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                //        string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //        if (!makerDispOrderDic.ContainsKey(key))
                //        {
                //            makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                //        }
                //    }
                //}

                //foreach (DataRowView row in this._MgBlMkView)
                //{
                //    int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                //    int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                //    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                //    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //    if (makerDispOrderDic.ContainsKey(key))
                //    {
                //        row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                //    }
                //}
                // DEL 杍^ 2011/12/19  Redmine#27453 -------- <<<<<<<

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// �I�����Ă���D�ǐݒ�O���b�h�s��1�s���Ɉړ������܂��B
        /// </summary>
        /// <param name="step">
        /// �ړ����鑊�Έʒu<br/>
        /// ��<c>0</c>���w�肷��Ɩ����ֈړ����܂��B
        /// </param>
        /// <remarks>
        /// <br>Update Note: 2011/11/19 杍^</br>
        /// <br>�Ǘ��ԍ�   �F10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27453�@�D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��</br>
        /// </remarks>
        private void MoveDownGridRow(int step)
        {
            if (this.PrimeSettingGrid.ActiveRow != null)
            {
                if (this.PrimeSettingGrid.ActiveRow.Index.Equals(this.PrimeSettingGrid.Rows.Count - 1)) return;

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //int nextIndex = this.PrimeSettingGrid.ActiveRow.Index + step;
                //if (step.Equals(0))
                //{
                //    nextIndex = this.PrimeSettingGrid.Rows.Count - 1;
                //}

                //GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[nextIndex]);
                //int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                //GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                //activeGridRow.MakerDispOrder = swapMakerDispOrder;

                //nextGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Selected = true;
                //this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;

                if (step != 0)
                {
                    int nextIndex = this.PrimeSettingGrid.ActiveRow.Index + step;

                    if (this.PrimeSettingGrid.Rows.Count > nextIndex)
                    {
                        for (int index = this.PrimeSettingGrid.ActiveRow.Index + 1; index < this.PrimeSettingGrid.Rows.Count; index++)
                        {
                            if (this.PrimeSettingGrid.Rows[index].Hidden == false)
                            {
                                nextIndex = index;
                                break;
                            }
                        }

                        if (this.PrimeSettingGrid.Rows[nextIndex].Hidden == false)
                        {
                            GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[nextIndex]);
                            int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                            GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                            nextGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                            activeGridRow.MakerDispOrder = swapMakerDispOrder;

                            nextGridRow.MyGridRow.Update();
                            activeGridRow.MyGridRow.Update();
                            activeGridRow.MyGridRow.Selected = true;
                            this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                        }
                    }
                }
                else
                {
                    GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);

                    for (int rowIndex = PrimeSettingGrid.ActiveRow.Index + 1; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                    {
                        if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                        {
                            continue;
                        }

                        GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[rowIndex]);
                        int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                        nextGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;

                        nextGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                    }

                    activeGridRow.MyGridRow.Selected = true;
                    this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                }

                // DEL 杍^ 2011/12/19 Redmine#27453 -------- >>>>>>>>>
                //Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                //for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
                //{
                //    if (PrimeSettingGrid.Rows[index].Hidden == false)
                //    {
                //        int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                //        int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                //        int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                //        string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //        if (!makerDispOrderDic.ContainsKey(key))
                //        {
                //            makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                //        }
                //    }
                //}

                //foreach (DataRowView row in this._MgBlMkView)
                //{
                //    int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                //    int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                //    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                //    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //    if (makerDispOrderDic.ContainsKey(key))
                //    {
                //        row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                //    }
                //}
                // DEL 杍^ 2011/12/19 Redmine#27453 -------- <<<<<<<<<<

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// �\�����ŃO���b�h�s�����ւ��܂��B
        /// </summary>
        /// <param name="changedCell">�ύX���ꂽ�\�����Z��</param>
        private void SwapGridRowByMakerDispOrder(UltraGridCell changedCell)
        {
            if (SortingDataView) return;

            int changedMiddle   = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
            int changedBL       = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
            int changedMaker    = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
            int changedOrder    = (int)changedCell.Value;

            _MgBlMkView.RowFilter = CurrentDataViewRowFilter;
            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;

            IList<int> previousOrderList = new List<int>();
            int targetIndex = 0;
            for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
            {
                GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                Debug.WriteLine("�\�����Ń\�[�g�F" + gridRow.MakerDispOrder.ToString());

                previousOrderList.Add(gridRow.MakerDispOrder);
                if (
                    gridRow.MiddleCode.Equals(changedMiddle)
                        &&
                    gridRow.BLCode.Equals(changedBL)
                        &&
                    gridRow.MakerCode.Equals(changedMaker)
                )
                {
                    targetIndex = idx;
                }
            }

            SortingDataView = true;
            try
            {
                int targetOrder = changedOrder;
                for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
                {
                    if (idx.Equals(targetIndex)) continue;

                    GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                    if (gridRow.MakerDispOrder.Equals(targetOrder))
                    {
                        gridRow.MakerDispOrder = UpdatingMakerDispOrder;
                        gridRow.MyGridRow.Update();
                        break;
                    }
                }
            }
            finally
            {
                SortingDataView = false;
            }

            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;
        }

        /// <summary>
        /// �f�[�^�r���[��\�����Ƀ\�[�g���܂��B
        /// </summary>
        /// <param name="changedCell">�ύX���ꂽ�\�����Z��</param>
        [Obsolete("SwapGridRowByMakerDispOrder()���g�p���ĉ������B")]
        private void SortDataViewWithInserting(UltraGridCell changedCell)
        {
            if (SortingDataView) return;

            int changedMiddle = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
            int changedBL = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
            int changedMaker = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
            int changedOrder = (int)changedCell.Value;

            _MgBlMkView.RowFilter = CurrentDataViewRowFilter;
            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;

            IList<int> previousOrderList = new List<int>();
            int targetIndex = 0;
            for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
            {
                GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                Debug.WriteLine("�\�����Ń\�[�g�F" + gridRow.MakerDispOrder.ToString());

                previousOrderList.Add(gridRow.MakerDispOrder);
                if (
                    gridRow.MiddleCode.Equals(changedMiddle)
                        &&
                    gridRow.BLCode.Equals(changedBL)
                        &&
                    gridRow.MakerCode.Equals(changedMaker)
                )
                {
                    targetIndex = idx;
                }
            }

            SortingDataView = true;
            try
            {
                int targetOrder = changedOrder;
                for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
                {
                    if (idx.Equals(targetIndex)) continue;

                    GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                    if (gridRow.MakerDispOrder.Equals(targetOrder))
                    {
                        gridRow.MakerDispOrder = targetOrder + 1;
                        targetOrder = gridRow.MakerDispOrder;
                        gridRow.MyGridRow.Update();
                    }
                }
            }
            finally
            {
                SortingDataView = false;
            }

            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;
        }

        #endregion  // <�\�����̐���/>
        // ADD 2008/11/19 �s��Ή�[7010] �d�l�ύX�u�\�����v�̒l�͔C�� ----------<<<<<

        /// <summary>
        /// �d����ǂݍ��ݏ���
        /// </summary>
        /// <param name="suppliserCd"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void ReadSupplier(int supplierCd, out int code, out string name)
        {
            if (supplierCd != 0)
            {
                if (_supplierAcs == null)
                {
                    _supplierAcs = new SupplierAcs();
                }
                Supplier supplier;
                int status = _supplierAcs.Read(out supplier, _primeSettingController.EnterPriseCode, supplierCd);
                if (status == 0)
                {
                    if (supplier.LogicalDeleteCode == 0)
                    {
                        code = supplier.SupplierCd;
                        name = supplier.SupplierNm1;
                    }
                    else
                    {
                        code = 0;
                        name = string.Empty;
                    }
                }
                else
                {
                    code = 0;
                    name = string.Empty;
                }
            }
            else
            {
                code = 0;
                name = string.Empty;
            }
        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        private int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.PrimeSettingGrid.BeginUpdate();

                if ((activeCellCheck) && (this.PrimeSettingGrid.ActiveCell != null))
                {
                    if ((!this.PrimeSettingGrid.ActiveCell.Column.Hidden) &&
                        (this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    performActionResult = this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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

                if (moved)
                {
                    this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.PrimeSettingGrid.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        /// <summary>
        /// �p�t�H�[���A�N�V������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.PrimeSettingGrid.ActiveCell != null) && (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.PrimeSettingGrid.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.PrimeSettingGrid.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.PrimeSettingGrid.ActiveCell.SelStart = 0;
                                            this.PrimeSettingGrid.ActiveCell.SelLength = this.PrimeSettingGrid.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ---------->>>>>
        /// <summary>
        /// �O���b�h��AfterSelectChange�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PrimeSettingGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            UpdateCurrentNote();
        }

        /// <summary>
        /// �O���b�h��AfterCellActivate�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PrimeSettingGrid_AfterCellActivate(object sender, EventArgs e)
        {
            UpdateCurrentNote();
        }
        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ----------<<<<<

        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX---------->>>>>
        /// <summary>�J�������̔������p���l</summary>
        private const int DELTA_WHITH = 20;

        ///// <summary>���[�J�[�R�[�h�̗񕝁i�����ŕ��������Ă������ɋ������߁A�Œ�Ƃ��Ă����j</summary>
        //private int MAKER_CODE_COLUMN_WIDTH = 150;

        /// <summary>
        /// ������/�i�ڐݒ�c���[�p�̃O���b�h�̃J�����\���ɕω������܂��B
        /// </summary>
        private void ChangeGridColumnHiddenForMiddleTree()
        {
            //�񕝎�������
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_MAKERDISPORDER:
                    case PrimeSettingInfo.COL_PARTSMAKERCD:
                    case PrimeSettingInfo.COL_PARTSMAKERFULLNAME:
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            //// TODO:�����ɕ��������̂Ŕ�����
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = MAKER_CODE_COLUMN_WIDTH;
        }

        #region <IPrimeSettingNoteChangedEventHandler�̎���/>

        /// <summary>
        /// �D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        public void PrimeSettingNoteChanged(
            object sender,
            NoteChangedEventArgs e
        )
        {
            // DEL 2008/11/21 �s��Ή�[8176] ���d�l�ύX �I���O���b�h��̔��l�\��
            //this.noteLabel.Text = e.ToString();
        }

        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ---------->>>>>
        /// <summary>
        /// ���݂̔��l�̒l���X�V���܂��B
        /// </summary>
        private void UpdateCurrentNote()
        {
            try
            {
                if (!this.PrimeSettingGrid.ActiveRow.Activated)
                {
                    this.noteLabel.Text = string.Empty;
                    return;
                }

                NoteChangedEventArgs note = new NoteChangedEventArgs(
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                    string.Empty
                );

                this.noteLabel.Text = note.ToString();
            }
            catch (NullReferenceException)
            {
                // �A�N�e�B�u�s��null�̉\������
                this.noteLabel.Text = string.Empty;
            }
        }
        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ----------<<<<<

        #endregion  // <IPrimeSettingNoteChangedEventHandler�̎���/>

        #region <���[�J�[/�i�ڐݒ�/>

        /// <summary>
        /// ���[�J�[/�i�ڐݒ�c���[�̕\��
        /// </summary>
        /// <remarks>
        /// �R�s�[���FPMKEN09012UA
        /// </remarks>
        private void SetMK_BLTreeView()
        {
            this.MK_BLSettingNavigatorTree.BeginUpdate();
            this.MK_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // ���̃c���[�r���[��\��
                // ��ʍ\�z����
                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                _MgBlMkView.RowFilter = string.Empty;
                // ----- DEL 2011/12/14 -------------------------->>>>>
                //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                //_MgBlMkView.RowFilter = this._primeSettingController.SecretCode;//ADD BY ������ on 2011/11/22 for Redmine#8033
                // ----- DEL 2011/12/14 --------------------------<<<<<
                _MgBlMkView.RowFilter = string.Format("({0} and {1}=1) or ({2}=1 and {3})", "SecretCode=0", PrimeSettingAcs.COL_CHECKSTATE, PrimeSettingAcs.COL_CHECKSTATE, "SecretCode=1"); // ADD 2011/12/14

                _MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE);

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue;

                    // View�̃`�F�b�N�X�e�[�^�X��CHECKED�̃f�[�^�̂ݕ\��
                    if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)
                    {
                        if (Mkht[((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")] == null)
                        {
                            Mkht.Add(((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), dr);

                            string makerNodeText = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                            node = this.MK_BLSettingNavigatorTree.Nodes.Add(((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), makerNodeText);
                        }
                        if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                        string skey = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                        if (MkBlht[skey] == null)
                        {
                            MkBlht.Add(skey, dr);
                            if (node != null)
                            {
                                if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                                {
                                    string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                    childnode = node.Nodes.Add(skey, ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                }
                                else
                                {
                                    childnode = node.Nodes.Add(skey, ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                this.MK_BLSettingNavigatorTree.EndUpdate();
            }

            if (MK_BLSettingNavigatorTree.Nodes.Count == 0)
            {
                StringBuilder allFilter = new StringBuilder();
                allFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1).Append(ADOUtil.AND).Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(9999999999);
                _MgBlMkView.RowFilter = allFilter.ToString();
            }

            // ADD 2008/11/19 �s��Ή�[7010]�� �d�l�ύX�u�\�����v�̒l�͔C��
            _MgBlMkView.Sort = DefaultDataViewSort;
        }

        /// <summary>
        /// ���[�J�[/�i�ڐݒ�c���[�p�̃O���b�h�̃J�����\���ɕω������܂��B
        /// </summary>
        private void ChangeGridColumnHiddenForMakerTree()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_TBSPARTSCODE:
                    case PrimeSettingInfo.COL_TBSPARTSFULLNAME:
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }
        }

        /// <summary>
        /// ���[�J�[/�i�ڐݒ�c���[��AfterSelect�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void MK_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

            // �O���b�h�̗�\��
            ChangeGridColumnHiddenForMakerTree();

            // �O���b�h�̍s�\��
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.MK_BLSettingNavigatorTree.SelectedNodes)
            {
                if (node.Level.Equals(0))    // MEMO:���[�J�[�m�[�h
                {
                    //string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key.Substring(0, 4));//DEL BY ������ on 2011/11/22 for Redmine#8033
                     //--------------ADD BY ������ on 2011/11/22 for Redmine#8033 ----------->>>>>>>>>>>>
                    string nodeTemp = Convert.ToInt32(node.Key.Split(':')[0]).ToString("0000");
                    string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, nodeTemp);
                    //--------------ADD BY ������ on 2011/11/22 for Redmine#8033 -----------<<<<<<<<<<<<
                    rowFilter += string.Format(" OR {0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, PrimeSettingAcs.COMMON_MAKER_CODE.ToString());

                    _MgBlMkView.RowFilter = rowFilter;
                    _MgBlMkView.RowFilter = string.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + rowFilter;
                    _MgBlMkView.Sort = PrimeSettingInfo.COL_TBSPARTSCODE;
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                    // ���l���X�V
                    this.noteLabel.Text = string.Empty;
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                }
                else // MEMO:�i�ڃm�[�h
                {
                    string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key.Substring(0, 4));
                    rowFilter += string.Format(" and {0}={1}", PrimeSettingInfo.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
                    _MgBlMkView.RowFilter = rowFilter;
                    _MgBlMkView.RowFilter = string.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + rowFilter;

                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                    int makerCode = int.Parse(node.Key.Substring(0, 4));
                    int blGoodsCode = int.Parse(node.Key.Substring(4, 8));
                    int goodsMGroup = 0;

                    foreach (UltraGridRow gridRow in this.PrimeSettingGrid.Rows)
                    {
                        if ((makerCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                            (blGoodsCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                        {
                            goodsMGroup = (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                            break;
                        }
                    }

                    NoteChangedEventArgs note = new NoteChangedEventArgs(goodsMGroup, blGoodsCode, makerCode, string.Empty);

                    // ���l���X�V
                    this.noteLabel.Text = note.ToString();
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                }
            }

            // ���ʃ��R�[�h�ȊO�́uBL�R�[�h�F0000�v�̃f�[�^���\������Ă���ꍇ�͔�\��
            Dictionary<string, int> tempDic = new Dictionary<string, int>();
            for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
            {
                if ((PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Text.Trim() == "0000") &&
                    (PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Text.Trim() == ""))
                {
                    PrimeSettingGrid.Rows[index].Hidden = true;
                }

                int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                int blGoodsCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // ���ʃ��R�[�h�͑I���m�[�h���ύX�����x�ɃN���A����
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(makerCode))
                {
                    PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;
                    PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;
                    PrimeSettingGrid.Rows[index].Update();
                    PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }

                string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blGoodsCode.ToString("00000");

                if (!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, index);
                }
                else
                {
                    PrimeSettingGrid.Rows[index].Hidden = true;
                }
            }

            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
            //// ���l���X�V
            //this.noteLabel.Text = string.Empty; // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\��
            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ���[�J�[/�i�ڐݒ�^�u�����肵�܂��B
        /// </summary>
        /// <param name="tab">�^�u</param>
        /// <returns>
        /// <c>true</c> :���[�J�[/�i�ڐݒ�^�u�ł���B<br/>
        /// <c>false</c>:���[�J�[/�i�ڐݒ�^�u�ł͂Ȃ��B
        /// </returns>
        private static bool IsMakerTab(Infragistics.Win.UltraWinTabControl.UltraTab tab)
        {
            return tab.Key.Equals("TabMK_BL");    // TODO:�^�u�̃L�[��ύX�����炱�����ύX���邱��
        }

        /// <summary>
        /// ������̑I�����s���܂��B
        /// </summary>
        /// <param name="tree">�ΏۂƂ���c���[</param>
        private static void SelectUp(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.SelectedNodes[0] != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode node = tree.SelectedNodes[0];
                if (node.PrevVisibleNode != null)
                {
                    if (node.PrevVisibleNode.Level.Equals(1))
                    {
                        node.PrevVisibleNode.Parent.Selected = true;
                    }
                    else
                    {
                        node.PrevVisibleNode.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// �������̑I�����s���܂��B
        /// </summary>
        /// <param name="tree">�ΏۂƂ���c���[</param>
        private static void SelectDown(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.SelectedNodes[0] != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode node = tree.SelectedNodes[0];
                if (node.NextVisibleNode != null)
                {
                    if (node.NextVisibleNode.Level.Equals(1))
                    {
                        while (true)
                        {
                            node = node.NextVisibleNode;
                            if (node == null) return;
                            if (node.Level == 0) break;
                        }
                        node.Selected = true;
                    }
                    else
                    {
                        node.NextVisibleNode.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// ���[�J�[�^�i�ڐݒ�A�����ށ^�i�ڐݒ�^�u��ActiveTabChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void makerMiddleTab_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
            // �\�����e�����Z�b�g
            ultraDockManager1.ResetControlPanes();
            // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<

            //�񕝎�������
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            if (IsMakerTab(e.Tab))
            {
                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
                if ((MK_BLSettingNavigatorTree.TopNode != null) && (MK_BLSettingNavigatorTree.Nodes.Count > 0))
                {
                    MK_BLSettingNavigatorTree.TopNode.Selected = true;
                    MK_BLSettingNavigatorTree.Nodes[0].Selected = true;
                    MK_BLSettingNavigatorTree_AfterSelect(sender, null);
                }
                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<

            }
            else
            {
                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
                if ((SettingNavigatorTree.TopNode != null) && (SettingNavigatorTree.Nodes.Count > 0))
                {
                    SettingNavigatorTree.TopNode.Selected = true;
                    SettingNavigatorTree_AfterSelect(sender, null);
                }
                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<

            }
        }

        #endregion  // <���[�J�[/�i�ڐݒ�/>

        #region <�������͂̃`�F�b�N/>

        /// <summary>
        /// ������/BL/���[�J�[ �O���b�h��KeyPress�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// ���l���͂̃`�F�b�N���s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void PrimeSettingGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.PrimeSettingGrid.ActiveCell == null) return;       // ADD 2009/01/30 �s��Ή�[10403]
            if (!this.PrimeSettingGrid.ActiveCell.IsInEditMode) return; // ADD 2008/11/20 �s��Ή�[6969]

            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.PrimeSettingGrid.ActiveCell;
            switch (activeCell.Column.Key)
            {
                // TODO:�\�����i1�`99�j
                case PrimeSettingInfo.COL_MAKERDISPORDER:
                    if (!CheckKeyPressNumber(
                        2,                      // ��
                        0,                      // �����_�ȉ�����
                        activeCell.Text,        // ���݂̕�����
                        e.KeyChar,              // ���͂��ꂽ�L�[�l
                        activeCell.SelStart,    // �J�[�\���ʒu
                        activeCell.SelLength,   // �I�𕶎���
                        false                   // �}�C�i�X���͉�
                    ))// || e.KeyChar.Equals('0'))
                    {
                        e.Handled = true;   // �C�x���g�L�����Z������
                    }
                    else
                    {
                        // 1�����ڂ�'0'��NG
                        if (activeCell.SelStart.Equals(0) && e.KeyChar.Equals('0'))
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                // �d����R�[�h�i000001�`999999�j
                case PrimeSettingInfo.COL_SUPPLIERCD:
                    if (!CheckKeyPressNumber(
                        6,                      // ��
                        0,                      // �����_�ȉ�����
                        activeCell.Text,        // ���݂̕�����
                        e.KeyChar,              // ���͂��ꂽ�L�[�l
                        activeCell.SelStart,    // �J�[�\���ʒu
                        activeCell.SelLength,   // �I�𕶎���
                        false                   // �}�C�i�X���͉�
                    ))
                    {
                        e.Handled = true;   // �C�x���g�L�����Z������
                    }
                    break;
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <remarks>�R�s�[���FMAKHN09280UC.cs��KeyPressNumCheck()</remarks>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        public static bool CheckKeyPressNumber(
            int keta,
            int priod,
            string prevVal,
            char key,
            int selstart,
            int sellength,
            Boolean minusFlg
        )
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // 1�����ڂ�'.'��NG
            if (string.IsNullOrEmpty(prevVal) && key.Equals('.'))
            {
                return false;
            }

            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion  // <�������͂̃`�F�b�N/>
        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ----------<<<<<

        // ADD 2008/10/29 �s��Ή�[6962]---------->>>>>
        #region <IPrimeSettingCheckable�̎���/>

        /// <summary>
        /// �ۑ��\�����肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns><c>true</c> :�ۑ��\<br/><c>false</c>:�ۑ��s�\</returns>
        public bool CanSave(out string errorMessage)
        {
            errorMessage = string.Empty;

            UserMakerDispOrderSetting();  // ADD 2011/12/19

            // ���ʃ��R�[�h�݂͕̂s��
            if (
                this.PrimeSettingGrid.Rows.Count.Equals(1)
                    &&
                PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)this.PrimeSettingGrid.Rows[0].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                )
            )
            {
                return false;
            }


            for (int i = 0; i < this.PrimeSettingGrid.Rows.Count; i++)
            {
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                ))
                {
                    continue;   // ���ʃ��R�[�h�͖���
                }

                if ((int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value == 0)
                {
                    continue;
                }

                try
                {
                    int supplierCode = (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value;
                    if (supplierCode <= 0 || supplierCode > 999999) // LITERAL:
                    {
                        this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Selected = true;
                        errorMessage = "�d����R�[�h�̒l���͈͊O�ł��B";    // LITERAL:
                        return false;
                    }
                }
                catch (InvalidCastException e)
                {
                    Debug.WriteLine(e.ToString());

                    this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Selected = true;
                    errorMessage = "�d����R�[�h�������͂ł��B";    // LITERAL:
                    return false;
                }
            }

            return true;
        }

        #endregion  // <IPrimeSettingCheckable�̎���/>
        // ADD 2008/10/29 �s��Ή�[6962]----------<<<<<

        // --- ADD 2009/02/19 ��QID:7042�Ή�------------------------------------------------------>>>>>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.PrimeSettingGrid)
            {
                if ((this.PrimeSettingGrid.ActiveCell == null) && (this.PrimeSettingGrid.ActiveRow == null))
                {
                    return;
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        int activeRowIndex;
                        int columnIndex;

                        if (this.PrimeSettingGrid.ActiveCell != null)
                        {
                            activeRowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
                            columnIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;
                        }
                        else
                        {
                            e.NextCtrl = null;
                            this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Activate();
                            this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        this.PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
                        {
                            if (this.PrimeSettingGrid.ActiveCell.Value == DBNull.Value)
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }
                            else
                            {
                                if (activeRowIndex == this.PrimeSettingGrid.Rows.Count - 1)
                                {
                                    e.NextCtrl = null;
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.PrimeSettingGrid.Rows[activeRowIndex + 1].Cells[columnIndex].Activate();
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (activeRowIndex == this.PrimeSettingGrid.Rows.Count - 1)
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }

                        }
                    }
                }
                else
                {
                    int activeRowIndex;
                    int columnIndex;

                    if (this.PrimeSettingGrid.ActiveCell != null)
                    {
                        activeRowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
                        columnIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;
                    }
                    else
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Activate();
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    this.PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);

                    if ((activeRowIndex == 0) &&
                        (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD))
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.PrevCellByTab);
                    }
                }

                
            }
        }

        private void PrimeSettingGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.PrimeSettingGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
            int colIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        if (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
                        {
                            if (this.PrimeSettingGrid.ActiveCell.IsInEditMode)
                            {
                                if (this.PrimeSettingGrid.ActiveCell.SelStart >= this.PrimeSettingGrid.ActiveCell.Text.Length)
                                {
                                    e.Handled = true;
                                    this.PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SUPPLIERGUIDE].Activate();
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (this.PrimeSettingGrid.ActiveCell.Column.Key != PrimeSettingInfo.COL_SUPPLIERGUIDE)
                        {
                            return;
                        }

                        PrimeSettingGrid_ClickCellButton(this.PrimeSettingGrid, new CellEventArgs(this.PrimeSettingGrid.ActiveCell));
                        break;
                    }
            }
        }

        // --- ADD 杍^ 2011/12/19 Redmine#27453 -------- >>>>>>>>
        /// <summary>
        /// SettingNavigatorTree �� BeforeSelect �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : SettingNavigatorTree �� BeforeSelect �C�x���g</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2011/12/19</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M���@Redmine#27453�@�D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��</br>
        /// </remarks>
        private void SettingNavigatorTree_BeforeSelect(object sender, Infragistics.Win.UltraWinTree.BeforeSelectEventArgs e)
        {
            UserMakerDispOrderSetting();
        }

        /// <summary>
        /// _MgBlMkView �\�����̕ۑ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : _MgBlMkView �\�����̕ۑ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2011/12/19</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M���@Redmine#27453�@�D�ǐݒ�}�X�^/�\�����̕ۑ��ɂ��Ă̏C��</br>
        /// </remarks>
        private void UserMakerDispOrderSetting()
        {
            Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
            for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
            {
                if (PrimeSettingGrid.Rows[index].Hidden == false)
                {
                    int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                    int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                    int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                    if (PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value == DBNull.Value)
                    {
                        return;
                    }

                    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                    if (!makerDispOrderDic.ContainsKey(key))
                    {
                        makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                    }
                }
            }

            string strTemp = _MgBlMkView.Sort;
            _MgBlMkView.Sort = string.Empty; 

            foreach (DataRowView row in this._MgBlMkView)
            {
                int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                if (makerDispOrderDic.ContainsKey(key))
                {
                    row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                }
            }

            _MgBlMkView.Sort = strTemp;
        }
        // --- ADD 杍^ 2011/12/19 Redmine#27453 -------- <<<<<<<<
        // --- ADD 2009/02/19 ��QID:7042�Ή�------------------------------------------------------<<<<<
    }
}
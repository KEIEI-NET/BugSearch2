//****************************************************************************//
// System           : .NS Series
// Program name     : �D�ǐݒ�}�X�^                 
// Note             : �D�ǐݒ�̓o�^�E�ύX�E�폜���s��    
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.                       
//============================================================================//
// ����                                                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/02/15  �C�����e : �V�K�쐬                                   
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/01/13  �C�����e : Mantis�F14714�@�\�������̔Ԃ����悤�ɏC��                                   
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �X �V ��  2011/11/22  �C�����e : Redmine#8033�̑Ή�                               
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11275163-00 �쐬�S�� : �c����
// �X �V ��  2016/06/29  �C�����e : Redmine#48793�̑Ή�
//                                  ���i�����ނ̉���BL�R�[�h�������߂���ꍇ�A�ڍאݒ�^�u�Ƀ��[�J�[�m�[�h���N���b�N����ƃG���[�̉���
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

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ڍאݒ��ʃN���X   
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 �ēc �ύK</br>
    /// <br>        	 �E���p/�@�\�ǉ��ׁ̈A�C��</br>    
    /// <br>UpdateNote : 2016/06/29 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11275163-00</br>
    /// <br>           : Redmine#48793 ���i�����ނ̉���BL�R�[�h�������߂���ꍇ�A�ڍאݒ�^�u�Ƀ��[�J�[�m�[�h���N���b�N����ƃG���[�̉���</br>
    /// </remarks>
    public partial class PMKEN09012UA : Form, IPrimeSettingController,
        IPrimeSettingNoteChanger // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX
	{
		# region Constructor
		/// <summary>
		/// �����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X �R���X�g���N�^
		/// </summary>
		/// <remarks>�����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X�̃R���X�g���N�^�ł��B</remarks>
		public PMKEN09012UA()
		{
			InitializeComponent();

			// �C���^�[�t�F�[�X�v���p�e�B�ݒ菈��
			//this.SetProperties();

            this.NoteChanged += this.CurrentNoteForPrimeSettingChanged; // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX
		}

        private DataView _PriSetView = null;
        private DataView _MgBlMkView = null;

		# endregion

        // �D�ǐݒ�}�X�^�R���g���[��(�C���^�[�t�F�[�X�̎����j
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

        //--------------------------------------------------------------------------
        //	ToolBar
        //--------------------------------------------------------------------------
        # region ��Const-�W��ToolBar
        /// <summary>�S�ĕ��i�ƌ���</summary>
        private const string ALL_JOIN = "AllJoin";
        /// <summary>�S�ĕ��i�̂�</summary>
        private const string ALL_PARTS = "AllParts";
        /// <summary>�S�ĂȂ�</summary>
        private const string ALL_NONE = "AllNone";
        /// <summary>�S�ĕ��i�ƌ���</summary>
        private const string JOIN = "Join";
        /// <summary>�S�ĕ��i�̂�</summary>
        private const string PARTS = "Parts";
        /// <summary>�S�ĂȂ�</summary>
        private const string NONE = "None";
        /// <summary>����</summary>
        private const string NEXT = "Next";
        /// <summary>�O��</summary>
        private const string PRIOR = "Prior";
        /// <summary>��ֈړ�</summary>
        private const string TOOL_UP = "Up";
        /// <summary>���ֈړ�</summary>
        private const string TOOL_DOWN = "Down";
        /// <summary>�ŏ�ʂֈړ�</summary>
        private const string TOOL_TOP = "Top";
        /// <summary>�ŉ��ʂֈړ�</summary>
        private const string TOOL_BOTTOM = "Bottom";
        # endregion

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
            if (TabIndex == 2)
            {
                _PriSetView.Sort =
                    (PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                     PrimeSettingInfo.COL_MAKERDISPORDER + "," +
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                     PrimeSettingInfo.COL_SELECTCODE + "," +
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                     PrimeSettingInfo.COL_DISPLAYORDER);
                
                //�D�ǐݒ胊�X�g���X�V����
                _primeSettingController.updateCheckPrimeSettingList();

                switch (_primeSettingController.NavigeteIndex)
                {
                    case 0:
                        {
                            setMK_BLTreeView();
                            break;
                        }
                    case 1:
                        {
                            setMK_BLTreeView();
                            //setMG_BLTreeView();
                            break;
                        }

                }
                if (SettingNavigatorTree.TopNode != null)
                {
                    SettingNavigatorTree.TopNode.Selected = true;
                }

                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------>>>>>
                if (SettingNavigatorTree.Nodes.Count > 0)
                {
                    SettingNavigatorTree.Nodes[0].Selected = true;
                }
                // --- ADD 2009/03/10 ��QID:12273�Ή�------------------------------------------------------<<<<<
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

        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
        #region <IPrimeSettingNoteManagementView �����o/>

        /// <summary>�D�ǐݒ�p���l���ω������Ƃ��̃C�x���g</summary>
        public event NoteChangedEventHandler NoteChanged;

        #endregion  // <IPrimeSettingNoteManagementView �����o/>
        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NSKEN90102UA_Load(object sender, EventArgs e)
        {

            if (_PriSetView == null) _PriSetView = new DataView(_primeSettingController.PrimeSettingTable);
            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable);
            _PriSetView.RowFilter = String.Format("{0}=1 and {1}", PrimeSettingAcs.COL_CHECKSTATE, string.IsNullOrEmpty(this._primeSettingController.SecretCode) ? "1=1" : this._primeSettingController.SecretCode);//ADD BY ������  on 2011/11/22 for Redmine#8033

            Mk_BlPrimeSettingGrid.DataSource = _PriSetView; // TODO:�ڍאݒ�^�u�̕\���e�[�u��
            //PrimeSettingGrid_InitializeLayout();
            // �P�i�ڂɔz�u
            tToolbarsManager1.Toolbars["TreeToolBar"].DockedRow = 0;
            tToolbarsManager1.Toolbars["TreeToolBar"].DockedColumn = 0;
            tToolbarsManager1.Toolbars["GridToolBar"].DockedRow = 0;
            tToolbarsManager1.Toolbars["GridToolBar"].DockedColumn = 1;
        }

        /// <summary>
        /// �c���[�r���[�\��
        /// </summary>
        private void setMK_BLTreeView()
        {
            SettingNavigatorTree.BeginUpdate();
            SettingNavigatorTree.Nodes.Clear();
            try
            {
                // ���̃c���[�r���[��\��
                // ��ʍ\�z����
                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                _MgBlMkView.RowFilter = "";

                // --- ADD 2008/07/01 -------------------------------->>>>>
                _MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                _PriSetView.RowFilter = "";
                //_PriSetView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);//DEL BY ������ on 2011/11/22 for Redmine#8033
                _PriSetView.RowFilter = String.Format("{0}=1 and {1}", PrimeSettingAcs.COL_CHECKSTATE, string.IsNullOrEmpty(this._primeSettingController.SecretCode) ? "1=1" : this._primeSettingController.SecretCode);//ADD BY ������ on 2011/11/22 for Redmine#8033
                // --- ADD 2008/07/01 --------------------------------<<<<< 
                _MgBlMkView.RowFilter = this._primeSettingController.SecretCode;//ADD BY ������ on 2011/11/22 for Redmine#8033
                _MgBlMkView.RowFilter = string.Format("({0} and {1}=1) or ({2}=1 and {3})", "SecretCode=0", PrimeSettingAcs.COL_CHECKSTATE, PrimeSettingAcs.COL_CHECKSTATE, "SecretCode=1"); // ADD 2011/12/14

                _MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE);

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

                    //View�̃`�F�b�N�X�e�[�^�X��CHECKED�̃f�[�^�̂ݕ\��
                    //if ((CheckState)dr[PrimeSettingController.COL_CHECKSTATE] == CheckState.Checked)  // DEL 2008/07/01
                    if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)           // ADD 2008/07/01
                    {

                        if (Mkht[((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d")] == null)
                        {
                            Mkht.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), dr);
                            // DEL 2008/10/30 �s��Ή�[6961]�� �d�l�ύX
                            //node = this.SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                            // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
                            string makerNodeText = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                            node = this.SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), makerNodeText);
                            // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<
                        }
                        if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                        string skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                        if (MkBlht[skey] == null)
                        {
                            MkBlht.Add(skey, dr);
                            if (node != null)
                            {

                                if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                                {

                                    string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                    childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                }
                                else
                                {
                                    childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));

                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                SettingNavigatorTree.EndUpdate();
            }
        }

        /// <summary>
        /// �m�[�h��I������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>UpdateNote : 2016/06/29 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11275163-00</br>
        /// <br>           : Redmine#48793 ���i�����ނ̉���BL�R�[�h�������߂���ꍇ�A�ڍאݒ�^�u�Ƀ��[�J�[�m�[�h���N���b�N����ƃG���[�̉���</br>
        /// </remarks>
        private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                           PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                           PrimeSettingInfo.COL_MAKERDISPORDER + "," +
                                           PrimeSettingInfo.COL_SELECTCODE + "," +
                                           PrimeSettingInfo.COL_DISPLAYORDER;

            foreach( Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
            {
                if ( node.Level == 0 )
                {
                    //----- UPD 2016/06/29 �c���� Redmine#48793 RowFilter�������OR��IN�ɕύX ----->>>>>
                    //string s = String.Format("{0}={1} and", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key);
                    //string or = "(";
                    //foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Nodes)
                    //{
                    //    s += or + String.Format(" ({0}={1})", PrimeSettingInfo.COL_TBSPARTSCODE, utn.Key.Substring(4, 8));
                    //    or = "or";
                    //}
                    //s += ")";
                    string s = String.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key);
                    List<string> blCodeList = new List<string>();
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Nodes)
                    {
                        blCodeList.Add(utn.Key.Substring(4, 8));
                    }
                    if (blCodeList.Count > 0)
                    {
                        s += String.Format(" and {0} in ({1})", PrimeSettingInfo.COL_TBSPARTSCODE, String.Join(",", blCodeList.ToArray()));
                        blCodeList.Clear();
                    }
                    //----- UPD 2016/06/29 �c���� Redmine#48793 RowFilter�������OR��IN�ɕύX -----<<<<<
                    _PriSetView.RowFilter =
                        //String.Format(s, PrimeSettingController.COL_CHECKSTATE, CheckState.Checked.ToString());  // DEL 2008/07/01
                        String.Format(s, PrimeSettingAcs.COL_CHECKSTATE, CheckState.Checked.ToString());           // ADD 2008/07/01

                    // --- CHG 2009/03/11 ��QID:12281�Ή�------------------------------------------------------>>>>>
                    //_PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_SELECTCODE;
                    _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                    // --- CHG 2009/03/11 ��QID:12281�Ή�------------------------------------------------------<<<<<
                    
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                    // ���l���X�V
                    this.noteLabel.Text = string.Empty;
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                }
                // --- ADD 2008/07/01 -------------------------------->>>>>
                else if (node.Level == 1)
                {
                    StringBuilder selectedFilter = new StringBuilder();
                    selectedFilter.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(node.Parent.Key);
                    selectedFilter.Append(ADOUtil.AND);
                    selectedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(node.Key.Substring(4, 8));
                    selectedFilter.Append(ADOUtil.AND);
                    selectedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                    _PriSetView.RowFilter = selectedFilter.ToString();

                    // --- ADD 2009/03/11 ��QID:12281�Ή�------------------------------------------------------>>>>>
                    _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                    // --- ADD 2009/03/11 ��QID:12281�Ή�------------------------------------------------------<<<<<

                    //string or = "(";
                    //foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Parent.Nodes)
                    //{
                    //    s += or + String.Format(" ({0}={1})", PrimeSettingInfo.COL_TBSPARTSCODE, utn.Key.Substring(4, 8));
                    //    or = "or";
                    //}
                    //s += ")";
                    //_PriSetView.RowFilter =
                    //    String.Format(s, PrimeSettingAcs.COL_CHECKSTATE, CheckState.Checked.ToString());

                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                    // �q�m�[�h��I�������ꍇ�����l��\��
                    int makerCode = int.Parse(node.Parent.Key);
                    int blGoodsCode = int.Parse(node.Key.Substring(4, 8));
                    int goodsMGroup = 0;
                    foreach (UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
                    {
                        if ((makerCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                            (blGoodsCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                        {
                            goodsMGroup = (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                            break;
                        }
                    }

                    StringBuilder noteText = new StringBuilder();
                    string key = PrimeSettingAcs.GetKeyOfOfferPrimeSettingNote(goodsMGroup, blGoodsCode, makerCode);
                    if (_primeSettingController.OfferPrimeSettingNote.Contains(key))
                    {
                        PrmSetNoteWork primeNote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[key];
                        noteText.Append(primeNote.PrmSetNote.Replace("<br>", Environment.NewLine)).Append(Environment.NewLine);
                    }

                    Debug.WriteLine("���l�F" + noteText.ToString());

                    SetCurrentNoteForPrimeSetting(goodsMGroup, blGoodsCode, makerCode, noteText.ToString());
                    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }

            // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
            //// ���l���X�V
            //this.noteLabel.Text = string.Empty; // ADD 2008/11/21 �s��Ή�[8178] �d�l�ύX �I���O���b�h��̔��l�\��
            // --- DEL 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

            // 2010/01/13 Add >>>
            SetDisplayOrder();
            // 2010/01/13 Add <<<

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = Mk_BlPrimeSettingGrid;

            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns ;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // ��̕\���^��\���i�f�t�H���g�j
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_DISPLAYORDER:
                    case PrimeSettingInfo.COL_PRIMEDISPLAYCODE:
                    case PrimeSettingInfo.COL_TBSPARTSCODE:
                    case PrimeSettingInfo.COL_TBSPARTSFULLNAME:
                    case PrimeSettingInfo.COL_SELECTNAME:
                    case PrimeSettingInfo.COL_PRIMEKINDNAME:

                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Width = 40;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Width = 90;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Width = 60;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Width = 200;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Width = 200;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Width = 200;

            // �\����
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.VisiblePosition = 0;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 1;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 2;
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Header.VisiblePosition = 3;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.VisiblePosition = 4;	
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.VisiblePosition = 5;

            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ---------->>>>>
            // �^�C�g���\���ʒu
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ----------<<<<<

            // ����
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Format = "0000;";	

            // �\���ʒu
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellAppearance.BackColor = Color.Lavender;
            // --- ADD 2008/07/01 -------------------------------->>>>>
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluator = new MergedCell();
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluator = new MergedCell();

            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluator = new MergedCell();

            // --- ADD 2008/07/01 -------------------------------->>>>>
            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluator = new MergedCell();
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            // �l���X�g�����������A�O���b�h�֒ǉ����܂��B
            grid.DisplayLayout.ValueLists.Clear();
            Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            vl1.ValueListItems.Add(0, "�\����");    // MEMO:�D�Ǖ\���敪�FPrimeDisplayCodeRF
            vl1.ValueListItems.Add(1, "���i&����"); // MEMO:�D�Ǖ\���敪�FPrimeDisplayCodeRF
            vl1.ValueListItems.Add(2, "���i");      // MEMO:�D�Ǖ\���敪�FPrimeDisplayCodeRF
            vl1.ValueListItems[1].Appearance.BackColor= Color.SkyBlue;
            vl1.ValueListItems[1].Appearance.BackColor2 = Color.White;
            vl1.ValueListItems[1].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            vl1.ValueListItems[2].Appearance.BackColor = Color.MediumAquamarine;
            vl1.ValueListItems[2].Appearance.BackColor2 = Color.White;
            vl1.ValueListItems[2].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].ValueList = vl1;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            // �L�[����}�b�s���O��ǉ�
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enter�L�[
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );
        }

        // TODO:�c�[���o�[�̃A�N�V����
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �\�������{�^��
                case NONE:
                    {
                        setPrimeDisplayCode(0, false);  // TODO:[�\������]�c�[���{�^���̓���J�n
                        break;
                    }
                // ���i�ƌ����{�^��
                case JOIN:
                    {
                        setPrimeDisplayCode(1, false);
                        break;
                    }
                // ���i�̂݃{�^��
                case PARTS:
                    {
                        setPrimeDisplayCode(2, false);
                        break;
                    }

                // �S�ĕ\������
                case ALL_NONE:
                    {
                        setPrimeDisplayCode(0, true);
                        break;
                    }
                // �S�ĕ��i�ƌ����{�^��
                case ALL_JOIN:
                    {
                        setPrimeDisplayCode(1, true);
                        break;
                    }
                // �S�ĕ��i�̂݃{�^��
                case ALL_PARTS:
                    {
                        setPrimeDisplayCode(2, true);
                        break;
                    }
                // ����
                case NEXT:
                    {
                        if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;
                        if (SettingNavigatorTree.SelectedNodes[0] != null)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                            if (node.NextVisibleNode != null)
                            {
                                if (node.NextVisibleNode.Level == 1)
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
                        break;
                    }
                // �O��
                case PRIOR:
                    {
                        if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;
                        if (SettingNavigatorTree.SelectedNodes[0] != null)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                            if (node.PrevVisibleNode != null)
                            {
                                if (node.PrevVisibleNode.Level == 1)
                                {
                                    node.PrevVisibleNode.Parent.Selected = true;
                                }
                                else
                                {
                                    node.PrevVisibleNode.Selected = true;
                                }
                            }
                        }

                        break;
                    }

                // ���
                case TOOL_UP:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == 0) return;

                        //��ɃA�C�e�����擾���Ă���
                        Infragistics.Win.UltraWinGrid.UltraGridRow priorrow = Mk_BlPrimeSettingGrid.Rows[idx - 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];
                        //Infragistics.Win.UltraWinGrid.UltraGridRow firstrow = Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.FirstRow;

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        // �I���A�C�e���Ǝ��̍s�̃Z���N�g���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        //�I���A�C�e�����擪�Ȃ�I��
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 1) return;
                        if ((Int32)selectrow.Index == 0) return;
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //�o���h���擾
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // �Z���������Ȃ��ɐݒ�(���̏������Ȃ��ƃZ������������Ȃ��ꍇ������)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //int order = (Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        int selectIndex = (Int32)selectrow.Index;
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        order = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        
                        //��̃A�C�e���̏��ʂ�������
                        priorrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order;
                        priorrow.Update();

                        //�I������Ă���Row�̏��ʂ��グ��
                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order - 1;
                        selectrow.Update();

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;

                        // �Z����������ɐݒ�
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        // Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp);

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 �s��Ή�[6961]

                        break;
                    }

                // ����
                case TOOL_DOWN:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == Mk_BlPrimeSettingGrid.Rows.Count - 1) return;

                        //��ɃA�C�e�����擾���Ă���
                        Infragistics.Win.UltraWinGrid.UltraGridRow nextrow = Mk_BlPrimeSettingGrid.Rows[idx + 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        // �I���A�C�e���Ǝ��̍s�̃Z���N�g���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //�o���h���擾
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // �Z���������Ȃ��ɐݒ�(���̏������Ȃ��ƃZ������������Ȃ��ꍇ������)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //int order = (Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        int selectIndex = (Int32)selectrow.Index;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        order = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        //���̃A�C�e���̏��ʂ��グ��
                        nextrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order;
                        nextrow.Update();

                        //�I������Ă���Row�̏��ʂ�������
                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order + 1;
                        selectrow.Update();

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;

                        // �Z����������ɐݒ�
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 �s��Ή�[6961]

                        break;
                    }

                // �g�b�v��
                case TOOL_TOP:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == 0) return;

                        //��ɃA�C�e�����擾���Ă���
                        Infragistics.Win.UltraWinGrid.UltraGridRow priorrow = Mk_BlPrimeSettingGrid.Rows[idx - 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //�I���A�C�e���ƑO��BL�R�[�h���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;
                        //Infragistics.Win.UltraWinGrid.UltraGridRow firstrow = Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.FirstRow;
                       // Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //�I���A�C�e���ƑO�̃Z���N�g�R�[�h���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 1) return;
                        if ((Int32)selectrow.Index == 0) return;
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //�o���h���擾
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // �Z���������Ȃ��ɐݒ�(���̏������Ȃ��ƃZ������������Ȃ��ꍇ������)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //int topNo = 1;  // ADD 2008/07/01

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        //for (int i = idx; 1 <= i; i--)
                        //{
                        //    priorrow = Mk_BlPrimeSettingGrid.Rows[i - 1];

                        //    //��̃A�C�e���̏��ʂ�������
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[i];
                        //    row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value =
                        //             (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value + 1;
                        //    row.Update();

                        //    topNo = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;  // ADD 2008/07/01

                        //    //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��
                        //    if ((Int32)priorrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0) break;

                        //    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //    //�I���A�C�e���Ǝ��̍s�̃Z���N�g�R�[�h���قȂ�ꍇ�I��
                        //    if ((Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == 0) break;
                        //    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        //}

                        ////selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 1;        // DEL 2008/07/01
                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = topNo - 1;  // ADD 2008/07/01

                        //selectrow.Update();

                        //// Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.ScrollPosition = firstrow;

                        int selectIndex = selectrow.Index;

                        int topIndex = 0;

                        int blGoodsCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        int selectCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;

                        for (int index = 0; index < Mk_BlPrimeSettingGrid.Rows.Count; index++)
                        {
                            if (Mk_BlPrimeSettingGrid.Rows[index].Hidden == true)
                            {
                                continue;
                            }

                            if ((blGoodsCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                (selectCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SELECTCODE].Value))
                            {
                                topIndex = index;
                                break;
                            }
                        }

                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        int topOrder = (Int32)Mk_BlPrimeSettingGrid.Rows[topIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        for (int index = topIndex; index < selectIndex; index++)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            order = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order + 1;
                        }

                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = topOrder;

                        Mk_BlPrimeSettingGrid.BeginUpdate();

                        for (int index = topIndex; index < selectIndex; index++)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            row.Update();

                            row.Selected = true;
                            Mk_BlPrimeSettingGrid.ActiveRow = row;
                        }

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;
                        Mk_BlPrimeSettingGrid.EndUpdate();
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // �Z����������ɐݒ�
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 �s��Ή�[6961]

                        break;

                    }
                //�{�g����
                case TOOL_BOTTOM:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == Mk_BlPrimeSettingGrid.Rows.Count - 1) return;

                        //��ɃA�C�e�����擾���Ă���
                        Infragistics.Win.UltraWinGrid.UltraGridRow nextrow = Mk_BlPrimeSettingGrid.Rows[idx + 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��(�ŉ��ʂ̏ꍇ�j
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;

                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //�I���A�C�e���ƑO�̃Z���N�g�R�[�h���قȂ�ꍇ�I��
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //�o���h���擾
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // �Z���������Ȃ��ɐݒ�(���̏������Ȃ��ƃZ������������Ȃ��ꍇ������)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //int bottom = 1;

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        ////for (int i = idx+1; i < Mk_BlPrimeSettingGrid.Rows.Count-1; i++)  // DEL 2008/07/01
                        //for (int i = idx + 1; i < Mk_BlPrimeSettingGrid.Rows.Count; i++)    // ADD 2008/07/01
                        //{
                        //    //nextrow = Mk_BlPrimeSettingGrid.Rows[i+1];  // DEL 2008/07/01
                        //    nextrow = Mk_BlPrimeSettingGrid.Rows[i];      // ADD 2008/07/01

                        //    //���̃A�C�e���̏��ʂ��グ��
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[i];

                        //    // --- ADD 2008/07/01 -------------------------------->>>>>
                        //    //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��
                        //    if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                        //         (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) break;
                        //    // --- ADD 2008/07/01 --------------------------------<<<<< 

                        //    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //    //�I���A�C�e���ƑO�̃Z���N�g�R�[�h���قȂ�ꍇ�I��
                        //    if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                        //         (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        //    // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                        //    //row.Cells[PrimeSettingController.COL_DISPLAYORDER].Value = i;
                        //    row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value =
                        //             (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value - 1;
                        //    row.Update();
                        //    bottom = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        //    // --- DEL 2008/07/01 -------------------------------->>>>>
                        //    //�I���A�C�e���Ǝ��̍s��BL�R�[�h���قȂ�ꍇ�I��
                        //    //if ((Int32)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                        //    //     (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) break;
                        //    // --- DEL 2008/07/01 --------------------------------<<<<< 
                        //}

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = bottom + 1;
                        //selectrow.Update();

                        int selectIndex = selectrow.Index;

                        int bottomIndex = 0;

                        int blGoodsCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        int selectCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;

                        for (int index = Mk_BlPrimeSettingGrid.Rows.Count - 1; index >= 0; index--)
                        {
                            if (Mk_BlPrimeSettingGrid.Rows[index].Hidden == true)
                            {
                                continue;
                            }

                            if ((blGoodsCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                (selectCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SELECTCODE].Value))
                            {
                                bottomIndex = index;
                                break;
                            }
                        }

                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        int bottomOrder = (Int32)Mk_BlPrimeSettingGrid.Rows[bottomIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        for (int index = bottomIndex; index >= selectIndex; index--)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            order = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order - 1;
                        }

                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = bottomOrder;

                        Mk_BlPrimeSettingGrid.BeginUpdate();

                        for (int index = bottomIndex; index >= selectIndex; index--)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            row.Update();

                            row.Selected = true;
                            Mk_BlPrimeSettingGrid.ActiveRow = row;
                        }

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;
                        Mk_BlPrimeSettingGrid.EndUpdate();
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        
                        // �Z����������ɐݒ�
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 �s��Ή�[6961]

                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// �\�������Fvalue := 0, all := false
        /// </remarks>
        /// <param name="value"></param>
        /// <param name="all"></param>
        private void setPrimeDisplayCode(int value, bool all)
        {
            int blGoodsCode = -1;
            string selectName = null;
            int prevVal = -1;

            int selectBLGoodsCode = -1;
            int displayOrder = 1;

            int selectCode = -1;    // 2010/01/13 Add

            // �Z���������Ȃ��ɐݒ�(���̏������Ȃ��ƃZ������������Ȃ��ꍇ������)
            Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0].Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;

            // UNDONE:�����I��
            //Infragistics.Win.UltraWinGrid.UltraGridRow row = this.Mk_BlPrimeSettingGrid.ActiveRow;

            int count = 0;// 2010/01/13 Add
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in Mk_BlPrimeSettingGrid.Rows)
            {
                // [�S�ā���]�c�[���{�^���̏���
                if (all == true)
                {
                    // 2010/01/13 Add >>>
                    if (selectBLGoodsCode != (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value || selectCode != (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                    {
                        selectBLGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        selectCode = (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                        count = 0;
                    }
                    // 2010/01/13 Add <<<
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// �܂����g���N���A
                    //row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = 0;
                    //row.Update();

                    //// ADD 2008/11/18 �s��Ή�[7010] �d�l�ύX�u�Z���N�g�^��ʁv�ʂ̕����I��Ή� ---------->>>>>
                    //// �u�Z���N�g�v���ݒ肳��Ă���s�̏ꍇ
                    //// --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                    ////if (HasSelectValue(row))
                    //string selectName;
                    //if (HasSelectValue(row, out selectName))
                    //// --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                    //// ADD 2008/11/18 �s��Ή�[7010] �d�l�ύX�u�Z���N�g�^��ʁv�ʂ̕����I��Ή� ----------<<<<<
                    //{
                    //    // ����BL�R�[�h�ŕ��i,���i&�������ݒ肳��Ă��閾�ׂ�����ΉI��
                    //    if (value != 0 && CheckSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                    //    {
                    //        continue;
                    //    }
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    //row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                    //row.Update();

                    // �\�������ɕύX
                    if (value == 0)
                    {
                        row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                        row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                    }
                    // ���i�������A���i�ɕύX
                    else
                    {
                        // BL�R�[�h���O��l�ƈႤ�ꍇ�́A�ύX�Ώۂ̗D�Ǖ\���敪�ɕύX
                        if (blGoodsCode != (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 1;
                            blGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            prevVal = value;
                            displayOrder = 2;

                            int makerCode = (int)row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                            int blCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            int goodsMGroup = (int)row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;

                            ArrayList makerOrderList = new ArrayList();
                            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                            {
                                if ((makerCode == (int)row2.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                    (blCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                    (goodsMGroup == (int)row2.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value))
                                {
                                    makerOrderList.Add((int)row2.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value);
                                }
                            }

                            foreach (int order in makerOrderList)
                            {
                                if (order != 0)
                                {
                                    foreach (DataRowView row2 in _MgBlMkView)
                                    {
                                        if ((makerCode == (int)row2[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                            (blCode == (int)row2[PrimeSettingInfo.COL_TBSPARTSCODE]) &&
                                            (goodsMGroup == (int)row2[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                                        {
                                            row2[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                                        }
                                    }

                                    break;
                                }
                            }
                            continue;
                        }

                        if (selectName == (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value)
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = prevVal;
                            if (prevVal != 0)
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = displayOrder;
                                displayOrder++;
                            }
                            else
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                            }
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            continue;
                        }
                        else
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = 0;
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            prevVal = 0;
                        }
                    }
                }
                // �ʂ̐ݒ�c�[���{�^���̏���
                else
                {
                    if (row.Selected == true)
                    {
                        //// --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //string selectName;
                        //// --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        selectBLGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        selectCode = (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;// 2010/01/13 Add
                        // �����I��
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                        //if (HasSelectValue(row))  // MOD 2008/11/18 �s��Ή�[7010] �d�l�ύX�u�Z���N�g�^��ʁv�ʂ̕����I��Ή� value != 0 �� IsSelectType(row)
                        if (HasSelectValue(row, out selectName))
                        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        {
                            // ����BL�R�[�h�̖��ׂ��N���A����
                            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                            //ClearSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value);
                            ClearSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value, selectName);
                            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value; 
                        if (value == 0)
                        {
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        }
                        else
                        {
                            if ((int)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = displayOrder;

                                int makerCode = (int)row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                                int blCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                                int goodsMGroup = (int)row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;

                                ArrayList makerOrderList = new ArrayList();
                                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                                {
                                    if ((makerCode == (int)row2.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                        (blCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                        (goodsMGroup == (int)row2.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value))
                                    {
                                        makerOrderList.Add((int)row2.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value);
                                    }
                                }

                                foreach (int order in makerOrderList)
                                {
                                    if (order != 0)
                                    {
                                        foreach (DataRowView row2 in _MgBlMkView)
                                        {
                                            if ((makerCode == (int)row2[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                                (blCode == (int)row2[PrimeSettingInfo.COL_TBSPARTSCODE]) &&
                                                (goodsMGroup == (int)row2[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                                            {
                                                row2[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        row.Update();
                    }
                }
            }

            if (all == false)
            {
                // 2010/01/13 >>>
                //int displayOrder2 = -1;
                int displayOrder2 = 0;
                _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                               PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                               PrimeSettingInfo.COL_SELECTCODE;

                // 2010/01/13 <<<
                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                {
                    if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                    {
                        // 2010/01/13 Del >>>
                        //if (displayOrder2 == -1)
                        //{
                        //    displayOrder2 = (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        //}
                        //else
                        //{
                        // 2010/01/13 Del <<<
                        if ((int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value != 0)
                        {
                            row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++displayOrder2;
                            row2.Update();
                        }
                        // 2010/01/13 Add >>>
                        else
                        {
                            // �\������SELECTCODE���ꏏ�̏ꍇ�͂P�x�\������0�ɂ���
                            if ((int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == selectCode)
                            {
                                row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                                row2.Update();
                            }
                        }
                        // 2010/01/13 Add <<<
                        //}// 2010/01/13 Del
                    }
                }
                // 2010/01/13 Add �\����0�̂��̂ɑ΂��ĕ\�������̔Ԃ��� >>>
                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                {
                    if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value && (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == selectCode)
                    {
                        if ((int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value == 0 && (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                        {
                            row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++displayOrder2;
                            row2.Update();
                        }
                    }
                }
                // DISPLAYORDER�Ń\�[�g������
                _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                // 2010/01/13 Add <<<
            }
            // 2010/01/13 Add >>>
            else
            {
                SetDisplayOrder();
            }
            // 2010/01/13 Add <<<

            Mk_BlPrimeSettingGrid.BeginUpdate();
            Mk_BlPrimeSettingGrid.Update();

            // �Z����������ɐݒ�
            Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0].Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;

            UltraGridRow selectedRow = null;
            if ((Mk_BlPrimeSettingGrid.Selected.Rows != null) && (Mk_BlPrimeSettingGrid.Selected.Rows.Count > 0))
            {
                selectedRow = Mk_BlPrimeSettingGrid.Selected.Rows[0];
            }
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                row2.Selected = true;
                row2.Activate();
                row2.Selected = false;
            }
            if (selectedRow != null)
            {
                Mk_BlPrimeSettingGrid.Rows[selectedRow.Index].Selected = true;
                Mk_BlPrimeSettingGrid.Rows[selectedRow.Index].Activated = true;
            }
            else
            {
                Mk_BlPrimeSettingGrid.Rows[0].Activated = true;
            }
            Mk_BlPrimeSettingGrid.EndUpdate();
        }

        // ADD 2008/11/18 �s��Ή�[7010] �d�l�ύX�u�Z���N�g�^��ʁv�ʂ̕����I��Ή� ---------->>>>>
        /// <summary>
        /// �Z���N�g���ݒ肳��Ă���s�����肵�܂��B
        /// </summary>
        /// <param name="gridRow">�O���b�h�s</param>
        /// <returns>
        /// <c>true</c> :�Z���N�g���ݒ肳��Ă���B<br/>
        /// <c>false</c>:�Z���N�g���ݒ肳��Ă��Ȃ��B
        /// </returns>
        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
        //private bool HasSelectValue(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        private bool HasSelectValue(UltraGridRow gridRow, out string selectName)
        // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
        {
            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
            selectName = "";
            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

            if (gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME] == null)
            {
                return false;
            }

            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
            //string selectName = gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value.ToString();
            selectName = gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value.ToString();
            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            if (string.IsNullOrEmpty(selectName))
            {
                return false;
            }

            return true;
        }
        // ADD 2008/11/18 �s��Ή�[7010] �d�l�ύX�u�Z���N�g�^��ʁv�ʂ̕����I��Ή� ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
        //private void ClearSettedDispCodeRow( int blGoodsCode )
        private void ClearSettedDispCodeRow( int blGoodsCode , string selectName)
        // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
        {
            // �r���[�̐���
            DataView view = CreateViewForCheckSettedDispCodeRow( blGoodsCode );

            // �Y������S�ăN���A
            foreach ( DataRowView rowView in view )
            {
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //rowView[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0; // 0:�\���Ȃ�
                if ((rowView[PrimeSettingInfo.COL_SELECTNAME] != null) &&
                    (rowView[PrimeSettingInfo.COL_SELECTNAME].ToString() != "") &&
                    (rowView[PrimeSettingInfo.COL_SELECTNAME].ToString() != selectName))
                {
                    rowView[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0; // 0:�\���Ȃ�
                    //rowView[PrimeSettingInfo.COL_DISPLAYORDER] = 0; // 2010/01/13 Del �\�����͎c��
                }
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        private bool CheckSettedDispCodeRow( int blGoodsCode )
        {
            // �r���[�̐���
            DataView view = CreateViewForCheckSettedDispCodeRow( blGoodsCode );

            // �Y������Ȃ�true
            return (view.Count > 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        private DataView CreateViewForCheckSettedDispCodeRow( int blGoodsCode )
        {
            // �r���[�̐���
            DataView view = new DataView( _primeSettingController.PrimeSettingTable );

            // �t�B���^�����񐶐�
            // ����a�k�R�[�hand�i���i����or���i�j
            string wkFilter = string.Format("{0}='{1}' AND {2}>'0'",
                                            PrimeSettingInfo.COL_TBSPARTSCODE, blGoodsCode,
                                            PrimeSettingInfo.COL_PRIMEDISPLAYCODE);
            if (_PriSetView.RowFilter != string.Empty)
            {
                view.RowFilter = _PriSetView.RowFilter + " AND " + wkFilter;
            }
            else
            {
                view.RowFilter = wkFilter;
            }
            return view;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

        private void PrimeSettingGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (Mk_BlPrimeSettingGrid.Selected.Rows.Count == 0) return;
            if (Mk_BlPrimeSettingGrid.Selected.Rows[0] != Mk_BlPrimeSettingGrid.ActiveRow)
            {
                Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SettingNavigatorTree.ActiveNode != null)
            {
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem1")
                {
                    // �S�ĕ\������
                    setPrimeDisplayCode(0, true);
                }
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem2")
                {
                    // �S�ĕ��i�ƌ����{�^��
                    setPrimeDisplayCode(1, true);
                }
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem3")
                {
                    // �S�ĕ��i�̂݃{�^��
                    setPrimeDisplayCode(2, true);
                }
            }
        }

        // ADD 2008/10/29 �s��Ή�[6961] �d�l�ύX ---------->>>>>
        /// <summary>���݂̗D�ǐݒ�p���l</summary>
        private string _currentNoteForPrimeSetting;
        /// <summary>
        /// ���݂̗D�ǐݒ�p���l���擾���܂��B
        /// </summary>
        /// <value>���݂̗D�ǐݒ�p���l</value>
        private string CurrentNoteForPrimeSetting
        {
            get { return _currentNoteForPrimeSetting; }
        }
        /// <summary>
        /// ���݂̗D�ǐݒ�p���l��ݒ肵�܂��B
        /// </summary>
        /// <param name="middleCode">�����ރR�[�h</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="value">���݂̗D�ǐݒ�p���l</param>
        private void SetCurrentNoteForPrimeSetting(
            int middleCode,
            int blCode,
            int makerCode,
            string value
        )
        {
            _currentNoteForPrimeSetting = value;

            // �D�ǐݒ�p���l�̒l�ɕω������������Ƃ�ʒm
            NoteChanged(
                this,
                new NoteChangedEventArgs(middleCode, blCode, makerCode, value)
            );
        }

        /// <summary>
        /// ���݂̗D�ǐݒ�p���l�̒l���ω������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void CurrentNoteForPrimeSettingChanged(
            object sender,
            NoteChangedEventArgs e
        )
        {
            StringBuilder noteText = new StringBuilder(e.ToString());

            int currentMiddleCode   = e.MiddleCode;
            int currentBLCode       = e.BLCode;
            int currentMakerCode    = e.MakerCode;

            StringBuilder selectText= new StringBuilder();
            StringBuilder typeText  = new StringBuilder();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                int middleCode  = (int)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                int blCode      = (int)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int makerCode   = (int)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;

                if (middleCode.Equals(currentMiddleCode) && blCode.Equals(currentBLCode) && makerCode.Equals(currentMakerCode))
                {
                    string selectTextItem = (string)gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                    if (!string.IsNullOrEmpty(selectTextItem))
                    {
                        selectText.Append(" "); // TODO:�s�K�v�Ȃ�폜
                        selectText.Append(selectTextItem).Append(Environment.NewLine);
                    }

                    string typeTextItem = (string)gridRow.Cells[PrimeSettingInfo.COL_PRIMEKINDNAME].Value;
                    if (!string.IsNullOrEmpty(typeTextItem))
                    {
                        typeText.Append(" ");   // TODO:�s�K�v�Ȃ�폜
                        typeText.Append(typeTextItem).Append(Environment.NewLine);
                    }
                }
            }

            if (selectText.Length > 0)
            {
                noteText.Append(Environment.NewLine).Append("[�Z���N�g]").Append(Environment.NewLine);  // LITERAL:
                noteText.Append(selectText.ToString());
            }

            if (typeText.Length > 0)
            {
                noteText.Append(Environment.NewLine).Append("[���]").Append(Environment.NewLine);  // LITERAL:
                noteText.Append(typeText.ToString());
            }

            this.noteLabel.Text = noteText.ToString();
        }

        /// <summary>
        /// ���݂̗D�ǐݒ�p���l�̒l���X�V���܂��B
        /// </summary>
        private void UpdateCurrentNoteForPrimeSetting()
        {
            StringBuilder noteText = new StringBuilder();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                if (!gridRow.Selected) continue;

                string noteKey = PrimeSettingAcs.GetKeyOfOfferPrimeSettingNote(
                    (int)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                    (int)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                    (int)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                );
                if (_primeSettingController.OfferPrimeSettingNote.Contains(noteKey))
                {
                    PrmSetNoteWork primeNote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[noteKey];
                    noteText.Append(primeNote.PrmSetNote.Replace("<br>", Environment.NewLine)).Append(Environment.NewLine);
                }
            }
            Debug.WriteLine("���l�F" + noteText.ToString());

            SetCurrentNoteForPrimeSetting(
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                noteText.ToString()
            );
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�O���b�h��AfterSelectChange�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// ���݂̗D�ǐݒ�p���l�̒l���X�V���܂��B<br/>
        /// [��ֈړ�],[�ŏ�ʂֈړ�]�c�[���{�^��,[���ֈړ�],[�ŉ��ʂֈړ�]�c�[���{�^���̗L���t���O�𐧌䂵�܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Mk_BlPrimeSettingGrid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            // ���݂̗D�ǐݒ�p���l�̒l���X�V
            UpdateCurrentNoteForPrimeSetting();

            // [��ֈړ�],[�ŏ�ʂֈړ�]�c�[���{�^��,[���ֈړ�],[�ŉ��ʂֈړ�]�c�[���{�^���̗L���t���O�𐧌�
            EnabledToolButtonForSelectingGrodRow();
        }

        /// <summary>
        /// [��ֈړ�],[�ŏ�ʂֈړ�]�c�[���{�^��,[���ֈړ�],[�ŉ��ʂֈړ�]�c�[���{�^���̗L���t���O�𐧌䂵�܂��B
        /// </summary>
        private void EnabledToolButtonForSelectingGrodRow()
        {
            int beginIndex  = -1;
            int endIndex    = this.Mk_BlPrimeSettingGrid.Rows.Count;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                if (!gridRow.Selected) continue;

                if (beginIndex < 0)
                {
                    beginIndex = gridRow.Index;
                }
                else
                {
                    endIndex = gridRow.Index;
                }
            }
            // 1�s�݂̂̑I���̏ꍇ
            if (endIndex.Equals(this.Mk_BlPrimeSettingGrid.Rows.Count) && beginIndex >= 0) endIndex = beginIndex;

            // [��ֈړ�],[�ŏ�ʂֈړ�]�c�[���{�^��
            if (beginIndex > 0)
            {
                int currentBLCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int previousBLCode= (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex - 1].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                int selectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                int previousSelectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex - 1].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = previousBLCode.Equals(currentBLCode);
                //this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled= previousBLCode.Equals(currentBLCode);

                if ((currentBLCode == previousBLCode) && (selectCode == previousSelectCode))
                {
                    this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
                    this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                    this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
                }
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled= false;
            }

            // [���ֈړ�],[�ŉ��ʂֈړ�]�c�[���{�^��
            if (endIndex < (this.Mk_BlPrimeSettingGrid.Rows.Count - 1))
            {
                int currentBLCode   = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int nextBLCode      = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex + 1].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                int selectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                int nextSelectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex + 1].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled     = nextBLCode.Equals(currentBLCode);
                //this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled   = nextBLCode.Equals(currentBLCode);

                if ((currentBLCode == nextBLCode) && (selectCode == nextSelectCode))
                {
                    this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
                    this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
                    this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;
                }
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled     = false;
                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled   = false;
            }
        }
        // ADD 2008/10/29 �s��Ή�[6961] �d�l�ύX ----------<<<<<

        // --- ADD 2009/02/19 ��QID:10402�Ή�------------------------------------------------------>>>>>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.Mk_BlPrimeSettingGrid)
            {
                if (this.Mk_BlPrimeSettingGrid.ActiveRow == null)
                {
                    return;
                }

                int rowIndex = this.Mk_BlPrimeSettingGrid.ActiveRow.Index;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = null;
                        this.Mk_BlPrimeSettingGrid.PerformAction(UltraGridAction.NextRow);
                        this.Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        this.Mk_BlPrimeSettingGrid.PerformAction(UltraGridAction.PrevRow);
                        this.Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }
        // --- ADD 2009/02/19 ��QID:10402�Ή�------------------------------------------------------<<<<<
        // 2010/01/13 Add >>>
        /// <summary>
        /// BL�R�[�h�ʁE�Z���N�g�ʂŕ\�����聨�\���Ȃ��̏��Ń\�[�g��������悤�ɕ\�������̔Ԃ������܂�
        /// </summary>
        private void SetDisplayOrder()
        {
            // DISPLAYORDER���L�[����O��
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                 PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                 PrimeSettingInfo.COL_SELECTCODE;
            int count = 0;  // �\���������̐��𐔂���
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                if ((int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                {
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = Mk_BlPrimeSettingGrid.Rows.Count + 1;
                    row2.Update();
                    count++;
                }
            }
            // DISPLAYORDER���L�[�ɖ߂�
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                         PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                         PrimeSettingInfo.COL_SELECTCODE + "," +
                         PrimeSettingInfo.COL_DISPLAYORDER;
            // �\�[�g���ꂽ���ʂɕ\������1����̔Ԃ�����
            int selectBLGoodsCode = -1;
            int selectCode = -1;
            count = 0;
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value && selectCode == (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                {
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++count;
                    row2.Update();
                    int tempdisp = (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                    int tempprime = (int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value;
                }
                else
                {
                    selectCode = (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                    selectBLGoodsCode = (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                    count = 0;
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++count;
                    row2.Update();
                }
            }
        }
        // 2010/01/13 Add <<<
    }

    internal class MergedCell : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            string text1;
            string text2;

            //if ((column.Key == PrimeSettingInfo.COL_SELECTNAME) ||
            //    (column.Key == PrimeSettingInfo.COL_PARTSMAKERFULLNAME) ||
            //    (column.Key == PrimeSettingInfo.COL_TBSPARTSFULLNAME))

            if ((column.Key == PrimeSettingInfo.COL_TBSPARTSCODE) ||
                (column.Key == PrimeSettingInfo.COL_TBSPARTSFULLNAME) ||
                (column.Key == PrimeSettingInfo.COL_SELECTNAME) ||
                (column.Key == PrimeSettingInfo.COL_PRIMEKINDNAME))
            {
                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((Int32)row1.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value ==
                    (Int32)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                {
                    text1 = (string)row1.Cells[column.Key].Text;
                    text2 = (string)row2.Cells[column.Key].Text;

                    //�ǂ��炩���󔒂Ȃ猋�����Ȃ�
                    if (text1 == "") return false;
                    if (text2 == "") return false;

                    //���������l�Ȃ猋������
                    if (text1 == text2) return true;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            return false;
        }
    }
}
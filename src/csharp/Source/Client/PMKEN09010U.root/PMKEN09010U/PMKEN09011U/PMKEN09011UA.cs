using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTree;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ��{�ݒ��ʃN���X
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 �ēc �ύK</br>
    /// <br>        	 �E���p/�@�\�ǉ��ׁ̈A�C��</br>    
    /// <br>UpdateNote : 2009.05.25 20056 ���n ��� ��12060 �ݒ���e���o�^����Ȃ�</br>
    /// <br>                                        ��13148 �s���f�[�^���o�^�����</br>
    /// <br>                                        ��13374 �ݒ���e���폜����Ȃ�</br>
    /// <br>                                        ��13375 �ݒ���e���\������Ȃ�</br>
    /// <br>                                        ��13380 ST=5�ŕۑ��ł��Ȃ�</br>
    /// <br>UpdateNote : 2011/06/02 22018 ��� ���b</br>
    /// <br>               ��Q���ǑΉ�</br>
    /// <br>               �@�@��ʈႢ��[�\����]��ݒ肵�Ă��A��{�ݒ�̒�����/�i�ڃ^�u��I�������[���i&����]�ɂȂ��Ă��܂��s��̏C���B</br>
    /// <br>               �@�A��{�ݒ�̒�����/�i�ڃ^�u�Ń`�F�b�N��t�������A�ΏۂƂȂ閾�ׂ��s���ƂȂ�s��̏C���B</br>
    /// <br>-----------------------------------------------------------------------</br>
    /// <br>�Ǘ��ԍ�              �쐬�S�� : lxl</br>
    /// <br>�X �V ��  2011/12/16  �C�����e : Redmine#26847 �D�ǐݒ�}�X�^�^�V�[�N���b�g���[�h�ŎO�H�ӂ�����o�^���G���[���o��</br>
    /// <br>-----------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2016/06/29 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11275163-00</br>
    /// <br>           : Redmine#48793 ���i�����ށi2�K�w�j���`�F�b�NON/OFF�̏ꍇ�ABL�R�[�h���t�B���^�[�����ɒǉ�����</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKEN09011UA : Form, IPrimeSettingController
    {
        /// <summary>
        /// ��{�ݒ��ʃN���X �R���X�g���N�^
        /// </summary>
        public PMKEN09011UA()
        {
            InitializeComponent();

        }
        private DataView _MgBlMkView = null;

        # region InterFace
        /// <summary>
        /// �D�ǐݒ�}�X�^�R���g���[��(�C���^�[�t�F�[�X�̎����j
        /// </summary>
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

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
        /// �f���Q�[�g�C�x���g�i���C������ʒm�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        public void MainTabIndexChange(object sender, int TabIndex)
        {
            if (TabIndex == 0)
            {
                secret = _primeSettingController.SecretCode;
                _MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                if (viewmode == CHECKED_DISP)
                {
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // ADD 2008/07/01
                }
                else
                {
                    setRowFiter(_MgBlMkView, "");
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
            if (TabIndex == 0)
            {
                if (_MgBlMkView == null) return;
                //�V�[�N���b�g�������ꂽ�C�x���g
                if (key == SECRET)
                {
                    switch (ultraTabControl1.TabIndex)
                    {
                        case 0:
                            {
                                //setMK_BLTreeView();  // DEL 2008/07/01

                                // --- ADD 2008/07/01 -------------------------------->>>>>
                                if (sortMode == SORT_CODE)
                                {
                                    setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  
                                }
                                else
                                {
                                    setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                }
                                // --- ADD 2008/07/01 --------------------------------<<<<< 

                                break;
                            }
                        case 1:
                            {
                                //setMG_BLTreeView();  // DEL 2008/07/01

                                // --- ADD 2008/07/01 -------------------------------->>>>>
                                if (sortMode == SORT_CODE)
                                {
                                    setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                                }
                                else
                                {
                                    setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                }
                                // --- ADD 2008/07/01 --------------------------------<<<<< 

                                break;
                            }
                    }

                }
            }
        }

        # endregion

        # region Const
        /// <summary>�S�ă`�F�b�NON</summary>
        private const string ALL_DISP = "AllDisp";
        /// <summary>�S�ă`�F�b�NOFF</summary>
        private const string CHECKED_DISP = "CheckedDisp";
        /// <summary>�`�F�b�NON</summary>
        private const string CHECK_ON = "CheckOn";
        /// <summary>�`�F�b�NOFF</summary>
        private const string CHECK_OFF = "CheckOff";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>�R�[�h��</summary>
        private const string SORT_CODE = "SortCode";
        /// <summary>���̏�</summary>
        private const string SORT_NAME = "SortName";
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>���[�J�[�i�ڃ^�u</summary>
        private const string TABMK_BL = "TabMK_BL";
        /// <summary>�V�[�N���b�g�L�[</summary>
        private const string SECRET = "Secret";
        
        # endregion

        # region Private Menber
        //�\�����[�h
        string viewmode = ALL_DISP;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        // �\�[�g��
        string sortMode = SORT_CODE;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        string secret = "";
        bool checkeventflg = false;

        bool _firstFlg = true;
        # endregion

        private void setRowFiter(DataView dv, string s)
        {
            if (s == "")
                dv.RowFilter = _primeSettingController.SecretCode;
            else
            {
                if (_primeSettingController.SecretMode == true)
                    dv.RowFilter = _primeSettingController.SecretCode + " AND " + s;
                else
                    dv.RowFilter = s;
            }
        }

        # region Private Method
        private void setMG_BL_MKNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            // --- DEL 2008/07/01 -------------------------------->>>>>
            //string notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //                + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
            //                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            string notekey = "";

            if (node.Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];
                        break;
                    case 1:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];
                        break;
                    case 2:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];
                        break;
                }
            }

        }
        private void setMKNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            string notekey = "";

            if (node.Level == 0)
            {
                notekey = ((Int32)0).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                node.RightImages.Clear();  // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];  // DEL 2008/07/01
                        break;
                    case 1:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];  // DEL 2008/07/01
                        break;
                    case 2:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];  // DEL 2008/07/01
                        break;
                }
            }
        }

        List<object> _partsMakerCode = new List<object>();  //ADD 2011/12/16 lxl Redmine#26874
        /// <summary>
        /// ���[�J�[/�i�ڐݒ�c���[�̕\��
        /// </summary> 
        //private void setMK_BLTreeView()              // DEL 2008/07/01
        private void setMK_BLTreeView(string strSort)  // ADD 2008/07/01
        { 
            // ��ʍ\�z����
            MK_BLSettingNavigatorTree.BeginUpdate();
            MK_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // �C�x���g�n���h�����ꎞ�I�ɊO���B
                MK_BLSettingNavigatorTree.AfterCheck -= MK_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                // --- ADD 2008/07/01 -------------------------------->>>>>
                Hashtable MgBlMkht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode grandchildnode = null;
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                //���̎w�߂Ńm�[�h�̃t�H�[�J�X�g��������i�`�F�b�N�{�b�N�X�̑���ƃm�[�h�̑I���̓���������Ȃ����߁j
                this.MK_BLSettingNavigatorTree.DrawFilter = new RemoveFocusRectangleDrawFilter();

                if (viewmode == CHECKED_DISP)
                    //                dataview.RowFilter =_primeSettingController.SecretCode +  string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // DEL 2011/12/16 lxl Redmine#26874
                    //ADD 2011/12/16 lxl Redmine#26874----------->>>>>>>>>>>>
                    if (this._primeSettingController.SecretMode)
                        _MgBlMkView.RowFilter = string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                    else
                    {
                        setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                    }
                    //ADD 2011/12/16 lxl Redmine#26874-----------<<<<<<<<<<<<
                else
                //setRowFiter(_MgBlMkView, ""); // DEL 2011/12/16 lxl Redmine#26874
                // ADD 2011/12/16 lxl Redmine#26874-------------------------------->>>>>
                {
                    if (this._primeSettingController.SecretMode)
                    {
                        if (_partsMakerCode.Count == 0)
                        {
                            _MgBlMkView.RowFilter = "SecretCode=1 and CheckState=1";    //TbsPartsCode=0
                            foreach (DataRowView row in _MgBlMkView)
                            {
                                if (!_partsMakerCode.Contains(row[PrimeSettingInfo.COL_PARTSMAKERCD]))
                                    _partsMakerCode.Add(row[PrimeSettingInfo.COL_PARTSMAKERCD]);
                            }
                        }
                        _MgBlMkView.RowFilter = "";
                    }
                    else
                    {
                        setRowFiter(_MgBlMkView, "");
                    }
                }
                // ADD 2011/12/16 lxl Redmine#26874--------------------------------<<<<<
                    
                //                dataview.RowFilter = setRowFiter(ref dataview, "");

                //_MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  // DEL 2008/07/01
                _MgBlMkView.Sort = (strSort);  // ADD 2008/07/01

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX
                    //ADD 2011/12/16 lxl Redmine#26874----------->>>>>>>>>>>>
                    if (this._primeSettingController.SecretMode && (int)dr[PrimeSettingInfo.COL_SECRETCODE] == 1)
                    {
                        if ((int)dr[PrimeSettingAcs.COL_CHECKSTATE] == 0 && !_partsMakerCode.Contains(dr[PrimeSettingInfo.COL_PARTSMAKERCD]))
                            continue;
                    }
                    //ADD 2011/12/16 lxl Redmine#26874-----------<<<<<<<<<<<<
                    if (Mkht[((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")] == null)
                    {
                        Mkht.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), dr);

                        // DEL 2008/10/28 �s��Ή�[6966]��
                        //node = this.MK_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                        // ADD 2008/10/28 �s��Ή�[6966] ���[�J�[�̃m�[�h�e�L�X�g�ɂ̓R�[�h���\�� ---------->>>>>
                        string makerNodeText = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                        node = this.MK_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), makerNodeText);
                        // ADD 2008/10/28 �s��Ή�[6966] ���[�J�[�̃m�[�h�e�L�X�g�ɂ̓R�[�h���\�� ----------<<<<<

                        node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        node.CheckedState = CheckState.Unchecked;
                        setMKNodeIcon(ref node, dr);
                        node.Tag = (object)dr.Row;
                    }

                    // --- ADD 2008/07/01 �����ޖ��ǉ� -------------------------------->>>>>
                    string skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4");

                    if (MkBlht[skey] == null)
                    {
                        MkBlht.Add(skey, dr);

                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_MIDDLEGENRENAME] != System.DBNull.Value)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + s);
                                childnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"));
                                childnode.Tag = (object)dr.Row;
                            }
                            childnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            setMKNodeIcon(ref childnode, dr);

                            childnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];

                            if (childnode.CheckedState == CheckState.Checked)
                            {
                                childnode.Parent.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                    skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");

                    if (MgBlMkht[skey] == null)
                    {
                        MgBlMkht.Add(skey, dr);

                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != System.DBNull.Value)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                grandchildnode = childnode.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                grandchildnode = childnode.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            grandchildnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            setMKNodeIcon(ref grandchildnode, dr);

                            //childnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01

                            if (grandchildnode.CheckedState == CheckState.Checked)
                            {
                                grandchildnode.Parent.CheckedState = CheckState.Checked;
                            }

                            //dr[PrimeSettingController.COL_TREENODE] = (object)childnode;
                        }
                    }
                    // --- ADD 2009/03/02 ��QID:12060�Ή�------------------------------------------------------>>>>>
                    else
                    {
                        if (node != null)
                        {
                            if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)
                            {
                                grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];

                                if (grandchildnode.CheckedState == CheckState.Checked)
                                {
                                    grandchildnode.Parent.CheckedState = CheckState.Checked;
                                }
                            }
                        }
                    }
                    // --- ADD 2009/03/02 ��QID:12060�Ή�------------------------------------------------------<<<<<
                }

                // --- ADD 2009/03/12 ��QID:12252�Ή�------------------------------------------------------>>>>>
                // �`�F�b�N�����������䂳��Ă��邩�Ċm�F
                foreach (UltraTreeNode nodelevel0 in MK_BLSettingNavigatorTree.Nodes)
                {
                    CheckState state = CheckState.Unchecked;

                    foreach (UltraTreeNode nodelevel1 in nodelevel0.Nodes)
                    {
                        foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                        {
                            if (nodelevel2.CheckedState == CheckState.Checked)
                            {
                                state = CheckState.Checked;
                                break;
                            }
                        }

                        nodelevel1.CheckedState = state;

                        if (state == CheckState.Checked)
                        {
                            break;
                        }
                    }

                    nodelevel0.CheckedState = state;
                }
                // --- ADD 2009/03/12 ��QID:12252�Ή�------------------------------------------------------<<<<<
            }
            finally
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // �C�x���g�n���h�����ēo�^
                MK_BLSettingNavigatorTree.AfterCheck += MK_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                MK_BLSettingNavigatorTree.EndUpdate();
            }
        }


        private void setMGNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            string notekey = "";
            if (node.Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                node.RightImages.Clear();  // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];  // DEL 2008/07/01
                        break;
                    case 1:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];  // DEL 2008/07/01
                        break;
                    case 2:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];  // DEL 2008/07/01
                        break;
                }
            }
        }

        /// <summary>
        /// ������/�i�ڐݒ�c���[�̕\��
        /// </summary> 
        //private void setMG_BLTreeView()              // DEL 2008/07/01
        private void setMG_BLTreeView(string strSort)  // ADD 2008/07/01
        {
            // --- UPD m.suzuki 2011/06/02 ---------->>>>>
            //MK_BLSettingNavigatorTree.BeginUpdate();
            MG_BLSettingNavigatorTree.BeginUpdate();
            // --- UPD m.suzuki 2011/06/02 ----------<<<<<
            MG_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // �C�x���g�n���h�����ꎞ�I�ɊO���B
                MG_BLSettingNavigatorTree.AfterCheck -= MG_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                Hashtable Mght = new Hashtable();
                Hashtable MgBlht = new Hashtable();
                Hashtable MgBlMkht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode grandchildnode = null;
                //���̎w�߂Ńm�[�h�̃t�H�[�J�X�g��������i�`�F�b�N�{�b�N�X�̑���ƃm�[�h�̑I���̓���������Ȃ����߁j
                this.MG_BLSettingNavigatorTree.DrawFilter = new RemoveFocusRectangleDrawFilter();
                if (viewmode == CHECKED_DISP)
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // ADD 2008/07/01 
                //dataview.RowFilter = string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);
                else
                    //                dataview.RowFilter = "";
                    setRowFiter(_MgBlMkView, "");

                //_MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);  // DEL 2008/07/01
                _MgBlMkView.Sort = (strSort);  // ADD 2008/07/01

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

                    if (Mght[((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")] == null)
                    {
                        Mght.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), dr);
                        // DEL 2008/10/28 �s��Ή�[6966]��
                        //node = this.MG_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME]);
                        // ADD 2008/10/28 �s��Ή�[6966] �����ނ̃m�[�h�e�L�X�g�ɂ̓R�[�h���\�� ---------->>>>>
                        string middleGrNodeText = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
                        node = this.MG_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), middleGrNodeText);
                        // ADD 2008/10/28 �s��Ή�[6966] �����ނ̃m�[�h�e�L�X�g�ɂ̓R�[�h���\�� ----------<<<<<

                        node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        node.CheckedState = CheckState.Unchecked;
                        setMGNodeIcon(ref node, dr);
                        node.Tag = (object)dr.Row;

                        // dr[PrimeSettingController.COL_TREENODE] = (object)node;
                    }
                    // if ((Int32)dr[PrimeSettingController.COL_TBSPARTSCODE] == 0) continue;

                    string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                    
                    if (MgBlht[skey] == null)
                    {
                        MgBlht.Add(skey, dr);
                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                childnode.Tag = null;// (object)dr;
                            }
                            else
                            {
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                childnode.Tag = null;// (object)dr;

                            }
                            childnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            //childnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            childnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01 
                            setMGNodeIcon(ref childnode, dr);
                            childnode.Tag = (object)dr.Row;

                            if (childnode.CheckedState == CheckState.Checked)
                            {
                                childnode.Parent.CheckedState = CheckState.Checked;
                            }
                            // dr[PrimeSettingController.COL_TREENODE] = (object)childnode;

                            // ADD 2009/01/27 �d�l�ύX�F�����ނ̂�����ōX�V ---------->>>>>
                            // FIXME:BL�R�[�h��0�̂��̂�����΁A�B��
                            if (((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                            {
                                childnode.Visible = false;
                            }
                            // ADD 2008/01/27 �d�l�ύX�F�����ނ̂�����ōX�V ----------<<<<<
                        }
                    }

                    string skey2 = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                 + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                 + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");

                    if (MgBlMkht[skey2] == null)
                    {
                        MgBlMkht.Add(skey2, dr);
                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] != null)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                                grandchildnode = childnode.Nodes.Add(skey2, ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + s);
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                grandchildnode = childnode.Nodes.Add(skey2, ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"));
                                grandchildnode.Tag = (object)dr.Row;
                            }

                            grandchildnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            //grandchildnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01
                            
                            if (grandchildnode.CheckedState == CheckState.Checked)
                            {
                                grandchildnode.Parent.CheckedState = CheckState.Checked;
                                grandchildnode.Parent.Parent.CheckedState = CheckState.Checked;
                            }
                            setMGNodeIcon(ref grandchildnode, dr);

                            //  dr[PrimeSettingController.COL_TREENODE] = (object)grandchildnode;
                        }
                    }
                }

                // --- ADD 2009/03/12 ��QID:12252�Ή�------------------------------------------------------>>>>>
                // �`�F�b�N�����������䂳��Ă��邩�Ċm�F
                foreach (UltraTreeNode nodelevel0 in MK_BLSettingNavigatorTree.Nodes)
                {
                    CheckState state = CheckState.Unchecked;

                    foreach (UltraTreeNode nodelevel1 in nodelevel0.Nodes)
                    {
                        foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                        {
                            if (nodelevel2.CheckedState == CheckState.Checked)
                            {
                                state = CheckState.Checked;
                                break;
                            }
                        }

                        nodelevel1.CheckedState = state;

                        if (state == CheckState.Checked)
                        {
                            break;
                        }
                    }

                    nodelevel0.CheckedState = state;
                }
                // --- ADD 2009/03/12 ��QID:12252�Ή�------------------------------------------------------<<<<<
            }
            finally
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // �C�x���g�n���h�����ēo�^
                MG_BLSettingNavigatorTree.AfterCheck += MG_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                // --- UPD m.suzuki 2011/06/02 ---------->>>>>
                //MK_BLSettingNavigatorTree.EndUpdate();
                MG_BLSettingNavigatorTree.EndUpdate();
                // --- UPD m.suzuki 2011/06/02 ----------<<<<<
            }
        }

        /// <summary>
        /// �c�[���o�[�{�^���F�ύX����
        /// </summary>
        /// <param name="key">�Ώۃ{�^��Key</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̃{�^���F���X�V����</br>
        /// </remarks>
        private void changeToolColor(string key)
        {
            // --- DEL 2008/07/01 -------------------------------->>>>>
            //if (key != ALL_DISP)
            //{
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            //}
            //if (key != CHECKED_DISP)
            //{
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            //}
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            if ((key == ALL_DISP) || (key == CHECKED_DISP))
            {
                // �u�S�ĕ\���v�̐F���f�t�H���g�ɖ߂�
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // �u�`�F�b�N�t�̂ݕ\���v�̐F���f�t�H���g�ɖ߂�
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // �I�����ꂽ�{�^���̐F���I�����W�ɂ���
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }

            if ((key == SORT_CODE) || (key == SORT_NAME))
            {
                // �u�R�[�h���v�̐F���f�t�H���g�ɖ߂�
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // �u���̏��v�̐F���f�t�H���g�ɖ߂�
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // �I�����ꂽ�{�^���̐F���I�����W�ɂ���
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 
        }
        # endregion

        # region Event
        /// <summary>
        /// Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����Ǎ��ގ��ɔ������܂��B</br>
        /// </remarks>
        private void PMKEN09011U_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------>>>>>
            // �^�u�X�^�C���ݒ�
            ultraTabControl1.UseOsThemes = DefaultableBoolean.False;
            ultraTabControl1.Appearance.BackColor = Color.WhiteSmoke;
            ultraTabControl1.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            ultraTabControl1.Appearance.BackGradientStyle = GradientStyle.Vertical;
            ultraTabControl1.ActiveTabAppearance.BackColor = Color.White;
            ultraTabControl1.ActiveTabAppearance.BackColor2 = Color.Pink;
            ultraTabControl1.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
            ultraTabControl1.Style = UltraTabControlStyle.VisualStudio2005;
            ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------<<<<<

            this._firstFlg = true;

            changeToolColor(ALL_DISP);
            changeToolColor(SORT_CODE);  // ADD 2008/07/01
            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable);
            secret = _primeSettingController.SecretCode;
            setRowFiter(_MgBlMkView, "");
            //setMK_BLTreeView();        // DEL 2008/07/01
            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  // ADD 2008/07/01
            _primeSettingController.Copy();
            this._firstFlg = false;
        }

        private void SetDefaultPrimeDisplayCode(int goodsMGroup, int makerCode, int blGoodsCode)
        {
            // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Dictionary<int, int> selectDic = new Dictionary<int, int>();

            //foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            //{
            //    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
            //    {
            //        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
            //        {
            //            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
            //                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
            //        }
            //        else
            //        {
            //            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
            //            {
            //                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
            //            }
            //        }
            //    }
            //}

            //bool allZeroFlg = true;
            //int notZeroCode = 0;
            //foreach (int selectCode in selectDic.Keys)
            //{
            //    if (selectDic[selectCode] != 0)
            //    {
            //        allZeroFlg = false;
            //        notZeroCode = selectCode;
            //        break;
            //    }
            //}
            //if (allZeroFlg)
            //{
            //    foreach (int selectCode in selectDic.Keys)
            //    {
            //        notZeroCode = selectCode;
            //        break;
            //    }
            //}

            //int displayOrder = 1;
            //foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            //{
            //    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
            //    {
            //        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
            //        {
            //            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
            //            {
            //                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
            //                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
            //                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

            //                displayOrder++;
            //            }
            //        }
            //    }
            //}

            Dictionary<string, int> selectKindDic = new Dictionary<string, int>();
            Dictionary<int, int> selectDic = new Dictionary<int, int>();

            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
                {
                    string key = string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) +
                                 string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]);
                    if (!selectKindDic.ContainsKey(key))
                    {
                        selectKindDic.Add(key, (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                    }
                    else
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                        {
                            selectKindDic[key] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        }
                    }

                    if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                    {
                        selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                      (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                    }
                    else
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                        {
                            selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        }
                    }

                }
            }

            bool allZeroFlg = true;
            int notZeroCode = 0;
            foreach (int selectCode in selectDic.Keys)
            {
                if (selectDic[selectCode] != 0)
                {
                    allZeroFlg = false;
                    notZeroCode = selectCode;
                    break;
                }
            }
            if (allZeroFlg)
            {
                foreach (int selectCode in selectDic.Keys)
                {
                    notZeroCode = selectCode;
                    break;
                }
            }

            int displayOrder = 1;
            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
                {
                    string targetKey = string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) +
                                       string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]);
                    if ((notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) &&
                        (selectKindDic.ContainsKey(targetKey)))
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                            primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                            primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                            displayOrder++;
                        }
                    }
                }
            }
            // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        private void SetDefaultPrimeDisplayCode(int goodsMGroup, int targetCode, bool makerFlg)
        {
            Dictionary<int, int> selectDic = new Dictionary<int, int>();

            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (makerFlg)
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == targetCode))
                    {
                        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                        {
                            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                        }
                        else
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                            }
                        }
                    }
                }
                else
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == targetCode))
                    {
                        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                        {
                            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                        }
                        else
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                            }
                        }
                    }
                }
            }

            bool allZeroFlg = true;
            int notZeroCode = 0;
            foreach (int selectCode in selectDic.Keys)
            {
                if (selectDic[selectCode] != 0)
                {
                    allZeroFlg = false;
                    notZeroCode = selectCode;
                    break;
                }
            }
            if (allZeroFlg)
            {
                foreach (int selectCode in selectDic.Keys)
                {
                    notZeroCode = selectCode;
                    break;
                }
            }

            int displayOrder = 1;
            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (makerFlg)
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == targetCode))
                    {
                        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                            {
                                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                                displayOrder++;
                            }
                        }
                    }
                }
                else
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == targetCode))
                    {
                        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                            {
                                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                                displayOrder++;
                            }
                        }
                    }
                }
            }
        }

        private void MG_BLSettingNavigatorTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;

            //�e�̃`�F�b�N�{�b�N�X����͑S�Ďq�ɔ��f����
            if (e.TreeNode.Level == 0)
            {
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Nodes)
                {
                    nodelevel1.CheckedState = e.TreeNode.CheckedState;

                    //3�K�w�܂łȂ̂ŁA�ċA�͎g�p���Ȃ�
                    foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                    {
                        nodelevel2.CheckedState = e.TreeNode.CheckedState;
                        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                        DataRow dr = (DataRow)nodelevel2.Tag;
                        int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                        foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                        //foreach (DataRowView drv in _MgBlMkView)
                        {
                            if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                                ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                                ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                            {
                                drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                                if (e.TreeNode.CheckedState == CheckState.Unchecked)
                                {
                                    if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                    {
                                        drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                    }
                                }

                                // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheck��2009.05.25�̕ύX�ɑ���
                                StringBuilder where = new StringBuilder();
                                where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                                DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                                if ( (rows != null) && (rows.Length != 0) )
                                {
                                    foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                                }
                                // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                            }
                        }

                        // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                        if (!this._firstFlg)
                        {
                            if (e.TreeNode.CheckedState == CheckState.Checked)
                            {
                                // �D�Ǖ\���敪�����l�Z�b�g
                                SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                                // ���[�J�[�\�����ʏ����l�Z�b�g
                                SetMakerDispOrder(blCode, goodsMGroup);
                            }
                        }
                    }
                }
            }
            //�q�̃`�F�b�N�{�b�N�X����͎q�̃`�F�b�N���S�ĊO��Ă�����e��OFF�B�ЂƂł��`�F�b�N������ΐe��ON
            else if (e.TreeNode.Level == 1)
            {
                //3�K�w�܂łȂ̂ŁA�ċA�͎g�p���Ȃ�
                //�q�ɑ΂��Ă͎����̃`�F�b�N�X�e�[�^�X���Z�b�g
                foreach (UltraTreeNode nodelevel2 in e.TreeNode.Nodes)
                {
                    nodelevel2.CheckedState = e.TreeNode.CheckedState;
                    //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                    ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                    DataRow dr = (DataRow)nodelevel2.Tag;
                    int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                    foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                    //foreach (DataRowView drv in _MgBlMkView)
                    {
                        if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                            ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                        {
                            drv[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)e.TreeNode.CheckedState;

                            if (e.TreeNode.CheckedState == CheckState.Unchecked)
                            {
                                if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                {
                                    drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                }
                            }

                            // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheck��2009.05.25�̕ύX�ɑ���
                            StringBuilder where = new StringBuilder();
                            where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                            DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                            if ( (rows != null) && (rows.Length != 0) )
                            {
                                foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                            }
                            // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                        }
                    }

                    // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                    if (!this._firstFlg)
                    {
                        if (e.TreeNode.CheckedState == CheckState.Checked)
                        {
                            // �D�Ǖ\���敪�����l�Z�b�g
                            SetDefaultPrimeDisplayCode(goodsMGroup, blCode, false);

                            // ���[�J�[�\�����ʏ����l�Z�b�g
                            SetMakerDispOrder(blCode, goodsMGroup);
                        }
                    }
                }
                //����K�w�̃m�[�h���S�ă`�F�b�NOFF�̏ꍇ���̐e�iLevel0�j��OFF�ƂȂ�
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                e.TreeNode.Parent.CheckedState = cs;

            }
            //�q�̃`�F�b�N�{�b�N�X����͎q�̃`�F�b�N���S�ĊO��Ă�����e��OFF�B�ЂƂł��`�F�b�N������ΐe��ON
            else if (e.TreeNode.Level == 2)
            {
                //((DataRow)e.TreeNode.Tag)[PrimeSettingController.COL_CHECKSTATE] = e.TreeNode.CheckedState;  // DEL 2008/07/01
                ((DataRow)e.TreeNode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;           // ADD 2008/07/01

                DataRow dr = (DataRow)e.TreeNode.Tag;
                int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                //foreach (DataRowView drv in _MgBlMkView)
                {
                    if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                        ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                    {
                        drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                        if (e.TreeNode.CheckedState == CheckState.Unchecked)
                        {
                            if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                            {
                                drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                            }
                        }

                        // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheck��2009.05.25�̕ύX�ɑ���
                        StringBuilder where = new StringBuilder();
                        where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                        DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                        if ( (rows != null) && (rows.Length != 0) )
                        {
                            foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                        }
                        // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                    }
                }

                // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                if (!this._firstFlg)
                {
                    if (e.TreeNode.CheckedState == CheckState.Checked)
                    {
                        // �D�Ǖ\���敪�����l�Z�b�g
                        SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                        // ���[�J�[�\�����ʏ����l�Z�b�g
                        SetMakerDispOrder(blCode, goodsMGroup);
                    }
                }

                //Level1�̊K�w���`�F�b�N
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                //�ЂƂł��`�F�b�N������΃`�F�b�NON
                e.TreeNode.Parent.CheckedState = cs;

                if (cs == CheckState.Unchecked)
                {
                    foreach (UltraTreeNode nodelevel0 in e.TreeNode.Parent.Parent.Nodes)
                    {
                        if (nodelevel0.CheckedState == CheckState.Checked)
                        {
                            cs = CheckState.Checked;
                        }
                    }
                    e.TreeNode.Parent.Parent.CheckedState = cs;
                }
                else
                {
                    e.TreeNode.Parent.Parent.CheckedState = CheckState.Checked;
                }
            }
            checkeventflg = false;
        }

        /// <summary>
        /// ���[�J�[/�i�ڐݒ�^�u�ō��ڃ`�F�b�N�̃C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>UpdateNote : 2016/06/29 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11275163-00</br>
        /// <br>           : Redmine#48793 ���i�����ށi2�K�w�j���`�F�b�NON/OFF�̏ꍇ�ABL�R�[�h���t�B���^�[�����ɒǉ�����</br>
        /// </remarks>
        private void MK_BLSettingNavigatorTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;

            //�e�̃`�F�b�N�{�b�N�X����͑S�Ďq�ɔ��f����
            if (e.TreeNode.Level == 0)
            {
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Nodes)
                {
                    nodelevel1.CheckedState = e.TreeNode.CheckedState;
                    //3�K�w�܂łȂ̂ŁA�ċA�͎g�p���Ȃ�
                    foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                    {
                        nodelevel2.CheckedState = e.TreeNode.CheckedState;
                        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                        DataRow dr = (DataRow)nodelevel2.Tag;
                        int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                        foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                        //foreach (DataRowView drv in _MgBlMkView)
                        {
                            if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                                ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                                ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                            {
                                drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                                if (e.TreeNode.CheckedState == CheckState.Unchecked)
                                {
                                    if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                    {
                                        drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                    }
                                }

                                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                StringBuilder where = new StringBuilder();
                                where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);

                                DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                                }
                                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            }
                        }

                        // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                        if (!this._firstFlg)
                        {
                            if (e.TreeNode.CheckedState == CheckState.Checked)
                            {
                                // �D�Ǖ\���敪�����l�Z�b�g
                                SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                                // ���[�J�[�\�����ʏ����l�Z�b�g
                                SetMakerDispOrder(blCode, goodsMGroup);
                            }
                        }
                    }
                }
            }
            //�q�̃`�F�b�N�{�b�N�X����͎q�̃`�F�b�N���S�ĊO��Ă�����e��OFF�B�ЂƂł��`�F�b�N������ΐe��ON
            else if (e.TreeNode.Level == 1)
            {
                //3�K�w�܂łȂ̂ŁA�ċA�͎g�p���Ȃ�
                //�q�ɑ΂��Ă͎����̃`�F�b�N�X�e�[�^�X���Z�b�g
                foreach (UltraTreeNode nodelevel2 in e.TreeNode.Nodes)
                {
                    nodelevel2.CheckedState = e.TreeNode.CheckedState;
                    //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                    ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                    DataRow dr = (DataRow)nodelevel2.Tag;
                    int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                    int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                    foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                    //foreach (DataRowView drv in _MgBlMkView)
                    {
                        if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                            ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode) && // ADD 2016/06/29 �c���� Redmine#48793 BL�R�[�h���t�B���^�[�����ɒǉ�����
                            ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode))
                        {
                            drv[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)e.TreeNode.CheckedState;

                            if (e.TreeNode.CheckedState == CheckState.Unchecked)
                            {
                                if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                {
                                    drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                }
                            }

                            // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            StringBuilder where = new StringBuilder();
                            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);
                            DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                            if ((rows != null) && (rows.Length != 0))
                            {
                                foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                            }
                            // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }

                    // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                    if (!this._firstFlg)
                    {
                        if (e.TreeNode.CheckedState == CheckState.Checked)
                        {
                            // �D�Ǖ\���敪�����l�Z�b�g
                            SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, true);

                            // ���[�J�[�\�����ʏ����l�Z�b�g
                            SetMakerDispOrder(blCode, goodsMGroup);
                        }
                    }
                }
                //����K�w�̃m�[�h���S�ă`�F�b�NOFF�̏ꍇ���̐e�iLevel0�j��OFF�ƂȂ�
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                e.TreeNode.Parent.CheckedState = cs;
            }
            //�q�̃`�F�b�N�{�b�N�X����͎q�̃`�F�b�N���S�ĊO��Ă�����e��OFF�B�ЂƂł��`�F�b�N������ΐe��ON
            else if (e.TreeNode.Level == 2)
            {
                //((DataRow)e.TreeNode.Tag)[PrimeSettingController.COL_CHECKSTATE] = e.TreeNode.CheckedState;  // DEL 2008/07/01
                ((DataRow)e.TreeNode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;           // ADD 2008/07/01

                DataRow dr = (DataRow)e.TreeNode.Tag;
                int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                //foreach (DataRowView drv in _MgBlMkView)
                {
                    if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                        ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                    {
                        drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                        if (e.TreeNode.CheckedState == CheckState.Unchecked)
                        {
                            if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                            {
                                drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                            }
                        }

                        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        StringBuilder where = new StringBuilder();
                        where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);

                        DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                        if ((rows != null) && (rows.Length != 0))
                        {
                            foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                        }
                        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }

                // ���[�U�[�f�[�^�ɑ��݂��Ȃ����̂͏����\���u���i�������v�Z�b�g
                if (!this._firstFlg)
                {
                    if (e.TreeNode.CheckedState == CheckState.Checked)
                    {
                        // �D�Ǖ\���敪�����l�Z�b�g
                        SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                        // ���[�J�[�\�����ʏ����l�Z�b�g
                        SetMakerDispOrder(blCode, goodsMGroup);
                    }
                }

                //Level1�̊K�w���`�F�b�N
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                //�ЂƂł��`�F�b�N������΃`�F�b�NON
                e.TreeNode.Parent.CheckedState = cs;

                if (cs == CheckState.Unchecked)
                {
                    foreach (UltraTreeNode nodelevel0 in e.TreeNode.Parent.Parent.Nodes)
                    {
                        if (nodelevel0.CheckedState == CheckState.Checked)
                        {
                            cs = CheckState.Checked;
                        }
                    }
                    e.TreeNode.Parent.Parent.CheckedState = cs;

                }
                else
                {
                    e.TreeNode.Parent.Parent.CheckedState = CheckState.Checked;
                }
            }
            checkeventflg = false;
        }

        private void SetMakerDispOrder(int blGoodsCode, int goodsMGroup)
        {
            StringBuilder filter = new StringBuilder();
            {
                filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(blGoodsCode).Append(ADOUtil.AND);
                filter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(goodsMGroup).Append(ADOUtil.AND);
                filter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }

            _MgBlMkView.RowFilter = filter.ToString();
            _MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

            Dictionary<int, int> indexDic = new Dictionary<int, int>();
            foreach (DataRowView primeSettingRow in _MgBlMkView)
            {
                if (!indexDic.ContainsKey((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER]))
                {
                    indexDic.Add((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER], (int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER]);
                }
            }

            int order = 0;
            int makerCode = -1;
            foreach (DataRowView primeSettingRow in _MgBlMkView)
            {
                if (makerCode != (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD])
                {
                    if ((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] != 0)
                    {
                        continue;
                    }

                    for (int index = order + 1; index > 0; index++)
                    {
                        if (indexDic.ContainsKey(index))
                        {
                            continue;
                        }
                        order = index;
                        break;
                    }
                    primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                    makerCode = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                }
                else
                {
                    primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                }
            }

            _MgBlMkView.RowFilter = "";
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �I�����ꂽ�{�^���ɂ��c���[��Ԃ��X�V����</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;
            try
            {
                Infragistics.Win.UltraWinTree.UltraTree ut = null;
                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                {
                    ut = MK_BLSettingNavigatorTree;
                }
                else
                {
                    ut = MG_BLSettingNavigatorTree;
                }

                switch (e.Tool.Key)
                {
                    //--------------------------------------------------------------
                    // �`�F�b�NON�{�^��
                    //--------------------------------------------------------------
                    case CHECK_ON:
                        {
                            //�`�F�b�NON
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode selectnode in ut.SelectedNodes)
                            {
                                selectnode.CheckedState = CheckState.Checked;

                                // --- CHG 2009/03/11 ��QID:12340�Ή�------------------------------------------------------>>>>>
                                ////�e�̃`�F�b�N�{�b�N�X����͑S�Ďq�ɔ��f����
                                //if (selectnode.Level == 0)
                                //{
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Nodes)
                                //    {
                                //        nodelevel1.CheckedState = CheckState.Checked;
                                //        if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //        {
                                //            //((DataRow)nodelevel1.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel1.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //        }
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                                //        {
                                //            nodelevel2.CheckedState = CheckState.Checked;
                                //            //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01 
                                //        }
                                //    }
                                //}
                                //else if (selectnode.Level == 1)
                                //{
                                //    if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //    {
                                //        //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //        ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //    }
                                //    selectnode.Parent.CheckedState = CheckState.Checked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Nodes)
                                //    {
                                //        nodelevel2.CheckedState = CheckState.Checked;
                                //        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //    }
                                //}
                                //else if (selectnode.Level == 2)
                                //{
                                //    //((DataRow)selectnode.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;
                                //    selectnode.Parent.CheckedState = CheckState.Checked;
                                //    selectnode.Parent.Parent.CheckedState = CheckState.Checked;
                                //    //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //    ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01 
                                //}

                                checkeventflg = false;
                                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                {
                                    MK_BLSettingNavigatorTree_AfterCheck(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                else
                                {
                                    MG_BLSettingNavigatorTree_AfterCheck(MG_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                // --- CHG 2009/03/11 ��QID:12340�Ή�------------------------------------------------------<<<<<
                            }
                            break;
                        }
                    //--------------------------------------------------------------
                    // �`�F�b�NOFF�{�^��
                    //--------------------------------------------------------------
                    case CHECK_OFF:
                        {
                            // �`�F�b�NOFF
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode selectnode in ut.SelectedNodes)
                            {
                                selectnode.CheckedState = CheckState.Unchecked;
                                
                                // --- CHG 2009/03/11 ��QID:12340�Ή�------------------------------------------------------>>>>>
                                ////�e�̃`�F�b�N�{�b�N�X����͑S�Ďq�ɔ��f����
                                //if (selectnode.Level == 0)
                                //{
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Nodes)
                                //    {
                                //        nodelevel1.CheckedState = CheckState.Unchecked;
                                //        if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //        {
                                //            //((DataRow)nodelevel1.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel1.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01 

                                //        }
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                                //        {
                                //            nodelevel2.CheckedState = CheckState.Unchecked;
                                //            //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //        }
                                //    }
                                //}

                                //else if (selectnode.Level == 1)
                                //{
                                //    if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //    {
                                //        //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //        ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //    }
                                //    //�q�ɑ΂��Ă͎����̃`�F�b�N�X�e�[�^�X���Z�b�g
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Nodes)
                                //    {
                                //        nodelevel2.CheckedState = CheckState.Unchecked;
                                //        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //    }

                                //    CheckState cs = CheckState.Unchecked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Parent.Nodes)
                                //    {
                                //        if (nodelevel1.CheckedState == CheckState.Checked)
                                //        {
                                //            cs = CheckState.Checked;
                                //        }
                                //    }
                                //    selectnode.Parent.CheckedState = cs;
                                //}
                                //else if (selectnode.Level == 2)
                                //{
                                //    //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //    ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01

                                //    //                                ((DataRow)utn.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;
                                //    //Level1�̊K�w���`�F�b�N
                                //    CheckState cs = CheckState.Unchecked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Parent.Nodes)
                                //    {
                                //        if (nodelevel2.CheckedState == CheckState.Checked)
                                //        {
                                //            cs = CheckState.Checked;
                                //        }
                                //    }
                                //    //�ЂƂł��`�F�b�N������΃`�F�b�NON
                                //    // ((DataRow)selectnode.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = cs;
                                //    selectnode.Parent.CheckedState = cs;

                                //    //�S�ă`�F�b�N��OFF�̏ꍇ����ɐe���`�F�b�N
                                //    if (cs == CheckState.Unchecked)
                                //    {
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Parent.Parent.Nodes)
                                //        {
                                //            if (nodelevel1.CheckedState == CheckState.Checked)
                                //            {
                                //                cs = CheckState.Checked;
                                //            }
                                //        }
                                //        // ((DataRow)e.TreeNode.Parent.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = cs;
                                //        selectnode.Parent.Parent.CheckedState = cs;
                                //    }
                                //    else
                                //    {
                                //        selectnode.Parent.Parent.CheckedState = CheckState.Checked;
                                //    }
                                //}
                                
                                checkeventflg = false;
                                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                {
                                    MK_BLSettingNavigatorTree_AfterCheck(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                else
                                {
                                    MG_BLSettingNavigatorTree_AfterCheck(MG_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                // --- CHG 2009/03/11 ��QID:12340�Ή�------------------------------------------------------<<<<<
                            }
                            break;
                        }
                    //--------------------------------------------------------------
                    // �S�ĕ\���{�^��
                    //--------------------------------------------------------------
                    case ALL_DISP:
                        {
                            if (viewmode == ALL_DISP) return;
                            //                        setRowFiter(ref dataview,"");
                            //                        dataview.RowFilter = "";
                            changeToolColor(e.Tool.Key);
                            viewmode = ALL_DISP;
                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // ���[�J�[/�i�ڐݒ�
                                    {
                                        //setMK_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // ���[�J�[/�i�ڐݒ�c���[�X�V(�R�[�h��)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        else
                                        {
                                            // ���[�J�[/�i�ڐݒ�c���[�X�V(���̏�)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                                case 1:  // ������/�i�ڐݒ�
                                    {
                                        //setMG_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // ������/�i�ڐݒ�c���[�X�V(�R�[�h��)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                                        }
                                        else
                                        {
                                            // ������/�i�ڐݒ�c���[�X�V(���̏�)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                            }

                            break;
                        }
                    //--------------------------------------------------------------
                    // �`�F�b�N�̂ݕ\���{�^��
                    //--------------------------------------------------------------
                    case CHECKED_DISP:
                        {
                            if (viewmode == CHECKED_DISP) return;
                            changeToolColor(e.Tool.Key);
                            viewmode = CHECKED_DISP;
                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // ���[�J�[/�i�ڐݒ�
                                    {
                                        //setMK_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // ���[�J�[/�i�ڐݒ�c���[�X�V(�R�[�h��)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                                        }
                                        else
                                        {
                                            // ���[�J�[/�i�ڐݒ�c���[�X�V(���̏�)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                                case 1:  // ������/�i�ڐݒ�
                                    {
                                        //setMG_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // ������/�i�ڐݒ�c���[�X�V(�R�[�h��)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                                        }
                                        else
                                        {
                                            // ������/�i�ڐݒ�c���[�X�V(���̏�)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                                            
                                        break;
                                    }
                            }

                            break;
                        }
                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    //--------------------------------------------------------------
                    // �R�[�h��
                    //--------------------------------------------------------------
                    case SORT_CODE:
                        {
                            if (sortMode == SORT_CODE) return;

                            changeToolColor(e.Tool.Key);
                            sortMode = SORT_CODE;

                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // ���[�J�[/�i�ڐݒ�
                                    {
                                        // ���[�J�[/�i�ڐݒ�c���[�X�V
                                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                                        
                                        break;
                                    }
                                case 1:  // ������/�i�ڐݒ�
                                    {
                                        // ������/�i�ڐݒ�c���[�X�V
                                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);  // ADD 2008/07/01
                                        
                                        break;
                                    }
                            }

                            break;
                        }
                    //--------------------------------------------------------------
                    // ���̏�
                    //--------------------------------------------------------------
                    case SORT_NAME:
                        {
                            if (sortMode == SORT_NAME) return;

                            changeToolColor(e.Tool.Key);
                            sortMode = SORT_NAME;

                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // ���[�J�[/�i�ڐݒ�
                                    {
                                        // ���[�J�[/�i�ڐݒ�c���[�X�V
                                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        
                                        break;
                                    }
                                case 1:  // ������/�i�ڐݒ�
                                    {
                                        // ������/�i�ڐݒ�c���[�X�V
                                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        
                                        break;
                                    }
                            }

                            break;
                        }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 
                }
            }
            finally
            {
                checkeventflg = false;
            }
        }

        /// <summary>
        /// �^�u�ύX������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �I�����ꂽ�^�u�ɂ��c���[��Ԃ��X�V����</br>
        /// </remarks>
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (_MgBlMkView == null) return;

            _primeSettingController.NavigeteIndex = e.Tab.Index;
            switch (e.Tab.Index)
            {
                case 0:  // ���[�J�[/�i�ڐݒ�
                {
                    //setMK_BLTreeView();  // DEL 2008/07/01

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    if (sortMode == SORT_CODE)
                    {
                        // �R�[�h��
                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                    }
                    else
                    {
                        // ���̏�
                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    break;
                }
                case 1:  // ������/�i�ڐݒ�
                {
                    //setMG_BLTreeView();  // DEL 2008/07/01

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    if (sortMode == SORT_CODE)
                    {
                        // �R�[�h��
                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                    }
                    else
                    {
                        // ���̏�
                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    break;
                }
            }
        }

        private void PMKEN09011UA_Leave(object sender, EventArgs e)
        {
            // DEL 2008/11/21 �s��Ή�[8175] ���\�������^�u�𑼂̃^�u��I������Ə��������
            //_primeSettingController.setMakerDispOrderView();
        }
        # endregion

        private void MK_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (e.NewSelections.Count != 1) return;
            string notekey = "";
            DataRow dr = (DataRow)e.NewSelections[0].Tag;

            // --- DEL 2008/07/01 -------------------------------->>>>>
            //if (e.NewSelections[0].Level == 0)
            //{
            //    notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //    + ((Int32)0).ToString("d8")
            //    + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            //}
            //else
            //{
            //    notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //    + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
            //    + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            //}
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            if (e.NewSelections[0].Level == 0)
            {
                notekey = ((Int32)0).ToString("d4")
                + ((Int32)0).ToString("d8")
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if(e.NewSelections[0].Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                + ((Int32)0).ToString("d8")
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (e.NewSelections[0].Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")  // MEMO:�����ރR�[�h
                + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")             // MEMO:BL�R�[�h
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");            // MEMO:���[�J�[�R�[�h
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            // TODO:�D�ǐݒ���l��ݒ�
            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                // --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey]; 
                //string s = primenote.OfferPrimeNote;  
                //this.MK_BLBrowser.DocumentText = s;         
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                        
                string s = primenote.PrmSetNote;        
                MK_BLLabel.Text = s.Replace("<br>", "\r\n");
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else
            {
                //this.MK_BLBrowser.DocumentText = "";  // DEL 2008/07/01
                MK_BLLabel.Text = "";                   // ADD 2008/07/01
            }
        }

        private void MG_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (e.NewSelections.Count != 1) return;
            string notekey = "";

            DataRow dr = (DataRow)e.NewSelections[0].Tag;
            if (e.NewSelections[0].Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (e.NewSelections[0].Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }

            else if (e.NewSelections[0].Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                // --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];
                //string s = primenote.OfferPrimeNote;  
                //this.MG_BLBrowser.DocumentText = s;         
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                
                string s = primenote.PrmSetNote;        
                MG_BLLabel.Text = s.Replace("<br>", "\r\n");
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else
            {
                //this.MG_BLBrowser.DocumentText. = "";
                MG_BLLabel.Text = "";  // ADD 2008/07/01
            }
        }
    }
}
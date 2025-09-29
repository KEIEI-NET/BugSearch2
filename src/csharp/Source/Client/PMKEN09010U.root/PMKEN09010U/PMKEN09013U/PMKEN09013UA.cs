using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Util;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ݒ���e�ꗗ��ʃN���X   
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 �ēc �ύK</br>
    /// <br>        	 �E���p/�@�\�ǉ��ׁ̈A�C��</br>    
    /// </remarks>
    public partial class PMKEN09013UA : Form, IPrimeSettingController
	{
  		# region Constructor
		/// <summary>
		/// �����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X �R���X�g���N�^
		/// </summary>
		/// <remarks>�����E���Ӑ�E�ԗ����e�L�X�g�o�͉�ʃN���X�̃R���X�g���N�^�ł��B</remarks>
		public PMKEN09013UA()
		{
			InitializeComponent();

		}
        private DataView _MkBlView = null;
        private DataView _MgBlView = null;

		 # endregion

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
        # endregion

        # region Event

        public void MainTabIndexChange(object sender, int TabIndex)
        {
            StringBuilder filter = new StringBuilder();

            if (TabIndex == 3)
            {
                //�D�ǐݒ胊�X�g���X�V����
                _primeSettingController.updateCheckPrimeSettingList();

                /*
                //���[�J�[/�i�ڕ\��
                if (ultraTabControl1.TabIndex == 0)
                {

                    _primeSettingController.PrimeSettingView.Sort =
                        (
                        PrimeSettingController.COL_MAKERDISPORDER + "," +
                        PrimeSettingController.COL_TBSPARTSCODE + "," +
                        PrimeSettingController.COL_DISPLAYORDER);

                }
                //������/�i�ڕ\��
                else
                {
                    _primeSettingController.PrimeSettingView.Sort =
                        (PrimeSettingController.COL_MIDDLEGENRECODE + "," +
                        PrimeSettingController.COL_TBSPARTSCODE + "," +
                        PrimeSettingController.COL_MAKERDISPORDER + "," +
                        PrimeSettingController.COL_DISPLAYORDER);

                }
                */

                // --- ADD 2009/03/11 ��QID:12329�Ή�------------------------------------------------------>>>>>
                //���[�J�[/�i�ڕ\��
                _MkBlView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                     PrimeSettingInfo.COL_SELECTCODE + "," +
                                     PrimeSettingInfo.COL_PRIMEKINDCODE;

                //������/�i�ڕ\��
                _MgBlView.Sort = PrimeSettingInfo.COL_MIDDLEGENRECODE + "," +
                                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                     PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                     PrimeSettingInfo.COL_SELECTCODE + "," +
                                     PrimeSettingInfo.COL_PRIMEKINDCODE;
                // --- ADD 2009/03/11 ��QID:12329�Ή�------------------------------------------------------<<<<<

                switch (viewmode)
                {
                    case ALL_DISP:
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        //setRowFiter(_MkBlView, "");
                        //setRowFiter(_MgBlView, "");
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        break;
                    case CHANGE_DISP:
                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                        setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        filter.Append(ADOUtil.AND);
                        filter.Append(PrimeSettingAcs.COL_CHANGEFLAG).Append(ADOUtil.EQ).Append(1);
                        //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                        //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        break;
                    case SETTING_DISP:
                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                        setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        filter.Append(ADOUtil.AND);
                        filter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                        //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                        //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        break;
                    case JOIN_DISP:
                        setRowFiter(_MkBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));
                        setRowFiter(_MgBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));
                        break;
                }
            }
        }

        private void setRowFiter(DataView dv, string s)
        {
            if (s == "")
                dv.RowFilter = _primeSettingController.SecretCode;
            else
            {
                // ----- DEL 2011/12/14 ------------------->>>>>
                //if (_primeSettingController.SecretMode == true)
                //    dv.RowFilter = _primeSettingController.SecretCode + " AND " + s;
                //else
                //    dv.RowFilter = s;
                // ----- DEL 2011/12/14 -------------------<<<<<
                dv.RowFilter = s; // ADD 2011/12/14
            }
        }

        public void FrameNotifyEvent(object sender, int TabIndex, string key)
        {
            StringBuilder filter = new StringBuilder();

            if (TabIndex == 3)
            {
                //�V�[�N���b�g�������ꂽ�C�x���g
                if (key == SECRET)
                {
                    switch (viewmode)
                    {
                        case ALL_DISP:
                            filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                            //setRowFiter(_MkBlView, "");
                            //setRowFiter(_MgBlView, "");
                            setRowFiter(_MkBlView, filter.ToString());
                            setRowFiter(_MgBlView, filter.ToString());
                            break;
                        case CHANGE_DISP:
                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                            setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                               --- DEL 2008/07/01 --------------------------------<<<<< */
                            // --- ADD 2008/07/01 -------------------------------->>>>>
                            filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                            filter.Append(ADOUtil.AND);
                            filter.Append(PrimeSettingAcs.COL_CHANGEFLAG).Append(ADOUtil.EQ).Append(1);
                            //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                            //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                            setRowFiter(_MkBlView, filter.ToString());
                            setRowFiter(_MgBlView, filter.ToString());
                            // --- ADD 2008/07/01 --------------------------------<<<<< 
                            break;
                        case SETTING_DISP:
                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                            setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                               --- DEL 2008/07/01 --------------------------------<<<<< */
                            // --- ADD 2008/07/01 -------------------------------->>>>>
                            filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                            filter.Append(ADOUtil.AND);
                            filter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                            //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                            //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                            setRowFiter(_MkBlView, filter.ToString());
                            setRowFiter(_MgBlView, filter.ToString());
                            // --- ADD 2008/07/01 --------------------------------<<<<< 
                            break;
                        case JOIN_DISP:
                            setRowFiter(_MkBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));
                            setRowFiter(_MgBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));
                            break;
                    }

                }
            }

        }
        # endregion

        # region Private Members

        //�\�����[�h
        string viewmode = SETTING_DISP;

        # endregion

        # region Consts

        //--------------------------------------------------------------------------
        //	ToolBar
        //--------------------------------------------------------------------------
        /// <summary>�S�ĕ\��</summary>
        private const string ALL_DISP = "AllDisp";
        /// <summary>����ݒ蕪</summary>
        private const string CHANGE_DISP = "ChangeDisp";
        /// <summary>�ݒ�ϕ\��</summary>
        private const string SETTING_DISP = "SettingDisp";
        /// <summary>���i�������\��</summary>
        private const string JOIN_DISP = "JoinDisp";
        /// <summary>�ݒ�ϕ\��</summary>
        private const string dummy = "dummy";
        /// <summary>�V�[�N���b�g�L�[</summary>
        private const string SECRET = "Secret";

        # endregion

        # region Event

		private void PMKEN09013U_Load(object sender, EventArgs e)
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

            if (_MgBlView == null) _MgBlView = new DataView(_primeSettingController.PrimeSettingTable);
            if (_MkBlView == null) _MkBlView = new DataView(_primeSettingController.PrimeSettingTable);

            Mk_BlPrimeSettingGrid.DataSource = _MkBlView;
            Mg_BlPrimeSettingGrid.DataSource = _MgBlView;
            changeToolColor(SETTING_DISP);
		}

		# endregion

        # region GridConfig

        private void PrimeSettingGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // ��̕\���^��\���i�f�t�H���g�j
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_PRIMEDISPLAYCODE:
                    case PrimeSettingInfo.COL_PARTSMAKERFULLNAME:
                    case PrimeSettingInfo.COL_TBSPARTSCODE:
                    case PrimeSettingInfo.COL_TBSPARTSFULLNAME:
                    case PrimeSettingInfo.COL_SELECTNAME:
                    case PrimeSettingInfo.COL_PRIMEKINDNAME:
                        {
                            band.Columns[ix].Hidden = false;
                            break;
                        }
                    case PrimeSettingInfo.COL_MIDDLEGENRENAME:
                        {
                            band.Columns[ix].Hidden = (grid.Name == "Mk_BlPrimeSettingGrid");
                            break;
                        }
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }

            }
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Width = 70;
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].Width = 70;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Width = 70;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Width = 150;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Width = 120;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Width = 200;	
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Width = 200;

            if (grid.Name == "Mg_BlPrimeSettingGrid")
            {
                // �\����
                band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.VisiblePosition = 0;
                band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].Header.VisiblePosition = 1;
                band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 2;
                band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 3;
                band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 4;
                band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.VisiblePosition = 5;
                band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.VisiblePosition = 6;
            }
            else
            {
                // �\����
                band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.VisiblePosition = 0;
                band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 1;
                band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 2;
                band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 3;
                band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.VisiblePosition = 4;
                band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.VisiblePosition = 5;
            }

            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ---------->>>>>
            // �^�C�g���\���ʒu
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2008/10/28 �s��Ή�[6964] �^�C�g���\���̓Z���^�����O ----------<<<<<

            // ����
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Format = "0000;";	

            // �\���ʒu(�����j
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // �\���ʒu(�����j
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


            //  �����ރR�[�h
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_MIDDLEGENRENAME].MergedCellAppearance.BackColor = Color.Lavender;
            //  BL�R�[�h
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellAppearance.BackColor = Color.Lavender;

            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;

            //  �����ݒ�
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;

            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;

            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluator = new MergedCell();


            // �l���X�g�����������A�O���b�h�֒ǉ����܂��B
            grid.DisplayLayout.ValueLists.Clear();
            Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            vl1.ValueListItems.Add(0, "�\����");
            vl1.ValueListItems.Add(1, "���i&����");
            vl1.ValueListItems.Add(2, "���i");
            vl1.ValueListItems[1].Appearance.BackColor = Color.SkyBlue;
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

        # endregion

        private void changeToolColor(string key)
        {
            if (key != CHANGE_DISP)
            {
                tToolbarsManager1.Tools[CHANGE_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[CHANGE_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[CHANGE_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            }
            if (key != SETTING_DISP)
            {
                tToolbarsManager1.Tools[SETTING_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[SETTING_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[SETTING_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            }
            if (key != ALL_DISP)
            {

                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            }
            if (key != JOIN_DISP)
            {

                tToolbarsManager1.Tools[JOIN_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[JOIN_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[JOIN_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[dummy].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            }
            tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
            tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
            tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

        }

        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            StringBuilder filter = new StringBuilder();

            switch (e.Tool.Key)
            {
                case ALL_DISP:
                    { //�\�����[�h
                        if (viewmode == ALL_DISP) return;
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        //setRowFiter(_MkBlView, "");
                        //setRowFiter(_MgBlView, "");
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        viewmode = ALL_DISP;
                        break;
                    }
                case CHANGE_DISP:
                    {
                        if (viewmode == CHANGE_DISP) return;

                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                        setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHANGEFLAG));
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        filter.Append(ADOUtil.AND);
                        filter.Append(PrimeSettingAcs.COL_CHANGEFLAG).Append(ADOUtil.EQ).Append(1);
                        //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                        //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHANGEFLAG));
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        viewmode = CHANGE_DISP;
                        break;
                    }
                case SETTING_DISP:
                    {
                        if (viewmode == SETTING_DISP) return;
                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                        setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
                        filter.Append(ADOUtil.AND);
                        filter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                        //setRowFiter(_MkBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                        //setRowFiter(_MgBlView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                        setRowFiter(_MkBlView, filter.ToString());
                        setRowFiter(_MgBlView, filter.ToString());
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        viewmode = SETTING_DISP;
                        break;
                    }
                case JOIN_DISP:
                    {
                        if (viewmode == JOIN_DISP) return;
                        setRowFiter(_MkBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));
                        setRowFiter(_MgBlView, string.Format("{0} in (1,2)", PrimeSettingInfo.COL_PRIMEDISPLAYCODE));

                        viewmode = JOIN_DISP;
                        break;
                    }

            }
            changeToolColor(e.Tool.Key);

        }

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
            else if (e.PrevCtrl == this.Mg_BlPrimeSettingGrid)
            {
                if (this.Mg_BlPrimeSettingGrid.ActiveRow == null)
                {
                    return;
                }

                int rowIndex = this.Mg_BlPrimeSettingGrid.ActiveRow.Index;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = null;
                        this.Mg_BlPrimeSettingGrid.PerformAction(UltraGridAction.NextRow);
                        this.Mg_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        this.Mg_BlPrimeSettingGrid.PerformAction(UltraGridAction.PrevRow);
                        this.Mg_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }
        // --- ADD 2009/02/19 ��QID:10402�Ή�------------------------------------------------------<<<<<
    }

    #region Internal
    internal class MergedCell : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            string text1;
            string text2;
            if ((column.Key == PrimeSettingInfo.COL_SELECTNAME) ||
                (column.Key == PrimeSettingInfo.COL_PARTSMAKERFULLNAME) ||
                (column.Key == PrimeSettingInfo.COL_TBSPARTSFULLNAME))
            {
                text1 = (string)row1.Cells[column.Key].Text;
                text2 = (string)row2.Cells[column.Key].Text;
                //�ǂ��炩���󔒂Ȃ猋�����Ȃ�
                if (text1 == "") return false;
                if (text2 == "") return false;
                //���������l�Ȃ猋������
                if (text1 == text2) return true;

            }
            return false;
        }
    }
    #endregion
}
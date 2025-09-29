using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Collections.Generic;

using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// �������σt���[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �������ς̃t���[���N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�؁@��</br>
	/// <br>Date       : 2008.06.18</br>
    /// <br>Update Note:</br>
    /// <br>2009.03.26 20056 ���n ��� ��12625 �ŐV���{�^���ǉ�</br>
    /// </remarks>
	public class PMMIT01000UA : System.Windows.Forms.Form
	{
		# region Private Members (Components)
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private TMemPos tMemPos1;
		private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private TArrowKeyControl tArrowKeyControl;
        private TRetKeyControl tRetKeyControl;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
		private System.ComponentModel.IContainer components;
		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
        /// �������σt���[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �R���X�g���N�^�������̊T�v���L�q</br>
		/// <br>Programmer : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		public PMMIT01000UA()
		{
			InitializeComponent();		

			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CLOSE_KEY];
			this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_RETURN_KEY];
			this._forwardButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_FORWARD_KEY];
			this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_PRINT_KEY];
			this._newtButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_NEW_KEY];
			this._deleteSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_UNDO_KEY];
			this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_GUIDE_KEY];
			this._readSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_READSLIP_KEY];
			this._slipCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY];
			this._changePartsSearchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY];
			this._entryJoinPartsButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY];
			this._orderSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY];
			this._showSetButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY];
			this._settingButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SETTING_KEY];
			this._changeDisplayButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY];

			this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY];
			this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINNAME_KEY];
			this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY];
			this._loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY];

            this._secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);

            this.CacheOptionInfo();

            //���[�h�ʏ���
            MovingModeSetting();
		}
		#endregion

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		#region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		// ===================================================================================== //
		// Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
		// ===================================================================================== //
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_File");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionName");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangePartsSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SlipCopy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EntryJoinParts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderSelect");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ShowSet");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReNewal");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_File");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Window");
            Infragistics.Win.UltraWinToolbars.ListTool listTool1 = new Infragistics.Win.UltraWinToolbars.ListTool("ListTool_TabForm");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool_InputForm");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ListTool listTool2 = new Infragistics.Win.UltraWinToolbars.ListTool("ListTool_TabForm");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionTitle");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangePartsSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SlipCopy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Save");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderSelect");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EntryJoinParts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ShowSet");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseOtherTab_Mouse");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Show");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseOtherTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Mouse");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionName");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Hidden");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EstimateReference");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReNewal");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMIT01000UA));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU00160UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraButton1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1014, 622);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(389, 198);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 0;
            this.ultraButton1.Text = "ultraButton1";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            appearance3.TextHAlignAsString = "Center";
            this.ultraStatusBar1.PanelAppearance = appearance3;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel2.Key = "Date";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel2.Width = 90;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel3.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.ultraStatusBar1.WrapText = false;
            // 
            // Main_UTabControl
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance2;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 125);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.uButton_Close});
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 586);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 23;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_UTabControl_MouseClick);
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.uButton_Close);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 565);
            // 
            // uButton_Close
            // 
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Center";
            this.uButton_Close.Appearance = appearance59;
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Close.Location = new System.Drawing.Point(197, -78);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(90, 25);
            this.uButton_Close.TabIndex = 34;
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.TabEnable = false;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Left";
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 586);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Width = 25;
            labelTool3.InstanceProps.Width = 121;
            labelTool4.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3,
            labelTool4,
            labelTool5});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            buttonTool12.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool16.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool4.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool4.SharedProps.MergeOrder = 10;
            buttonTool18.InstanceProps.IsFirstInGroup = true;
            buttonTool20.InstanceProps.IsFirstInGroup = true;
            buttonTool24.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24});
            popupMenuTool5.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool5.SharedProps.MergeOrder = 20;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool25});
            popupMenuTool6.SharedProps.Caption = "�E�B���h�E(&W)";
            popupMenuTool6.SharedProps.MergeOrder = 30;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            listTool1});
            labelTool6.SharedProps.MergeOrder = 40;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "���O�C���S����";
            labelTool7.SharedProps.CustomizerCaption = "���O�C���S���҃^�C�g��";
            labelTool7.SharedProps.MergeOrder = 50;
            labelTool7.SharedProps.ShowInCustomizer = false;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance4;
            labelTool8.SharedProps.CustomizerCaption = "���O�C���S���҃��x��";
            labelTool8.SharedProps.CustomizerDescription = "���O�C���S���҃��x��";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool8.SharedProps.MergeOrder = 60;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            mdiWindowListTool1.DisplayArrangeIconsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCascadeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCloseWindowsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayMinimizeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileHorizontalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileVerticalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.SharedProps.Caption = "MDIWindowListTool_InputForm";
            buttonTool26.SharedProps.Caption = "���(F10)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            listTool2.SharedProps.Caption = "ListTool_TabForm";
            listTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool9.SharedProps.Caption = "���O�C�����_";
            labelTool9.SharedProps.CustomizerCaption = "���O�C�����_�^�C�g��";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Caption = "�i��(F3)";
            buttonTool27.SharedProps.CustomizerCaption = "�i�ރ{�^��";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            buttonTool28.SharedProps.Caption = "�߂�(F2)";
            buttonTool28.SharedProps.CustomizerCaption = "�߂�{�^��";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool29.SharedProps.Caption = "�����ؑ�(F4)";
            buttonTool29.SharedProps.CustomizerCaption = "�����ؑփ{�^��";
            buttonTool29.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool29.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F4;
            buttonTool30.SharedProps.Caption = "�K�C�h(F5)";
            buttonTool30.SharedProps.CustomizerCaption = "�K�C�h�{�^��";
            buttonTool30.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool30.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            buttonTool31.SharedProps.Caption = "�`�[�ďo�iF11)";
            buttonTool31.SharedProps.CustomizerCaption = "�`�[�ďo�{�^��";
            buttonTool31.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool31.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool32.SharedProps.Caption = "�`�[����(&P)";
            buttonTool32.SharedProps.CustomizerCaption = "�`�[���ʃ{�^��";
            buttonTool32.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool33.SharedProps.Caption = "�V�K(F9)";
            buttonTool33.SharedProps.CustomizerCaption = "�V�K�{�^��";
            buttonTool33.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool33.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool34.SharedProps.Caption = "�ۑ�(F10)";
            buttonTool34.SharedProps.CustomizerCaption = "�ۑ��{�^��";
            buttonTool34.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool34.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool35.SharedProps.Caption = "�ݒ�(&O)";
            buttonTool35.SharedProps.CustomizerCaption = "�ݒ�{�^��";
            buttonTool35.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool36.SharedProps.Caption = "���ɖ߂�(&U)";
            buttonTool36.SharedProps.CustomizerCaption = "���ɖ߂��{�^��";
            buttonTool36.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool37.SharedProps.Caption = "�I���iF1)";
            buttonTool37.SharedProps.CustomizerCaption = "�I���{�^��";
            buttonTool37.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool37.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool38.SharedProps.Caption = "�`�[�폜(F12)";
            buttonTool38.SharedProps.CustomizerCaption = "�`�[�폜�{�^��";
            buttonTool38.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool38.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool39.SharedProps.Caption = "�����I��(F8)";
            buttonTool39.SharedProps.CustomizerCaption = "�����I���{�^��";
            buttonTool39.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool39.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            buttonTool40.SharedProps.Caption = "�����o�^(F7)";
            buttonTool40.SharedProps.CustomizerCaption = "�����o�^�{�^��";
            buttonTool40.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool40.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            buttonTool41.SharedProps.Caption = "�Z�b�g(&L)";
            buttonTool41.SharedProps.CustomizerCaption = "�Z�b�g�{�^��";
            buttonTool41.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool42.SharedProps.Caption = "�V�����^�u(&T)";
            buttonTool42.SharedProps.CustomizerCaption = "�V�����^�u�{�^��";
            buttonTool42.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            buttonTool43.SharedProps.Caption = "�^�u�����(&C)";
            buttonTool43.SharedProps.CustomizerCaption = "�^�u�����{�^��";
            buttonTool43.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            buttonTool44.SharedProps.Caption = "���̃^�u�����i&O)";
            buttonTool44.SharedProps.CustomizerCaption = "���̃^�u�����{�^���}�E�X�p";
            popupMenuTool7.SharedProps.Caption = "�ҏW(&E)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.MergeOrder = 10;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool45,
            buttonTool46});
            popupMenuTool8.SharedProps.Caption = "�\��(&V)";
            popupMenuTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool8.SharedProps.MergeOrder = 10;
            popupMenuTool8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool47,
            buttonTool48});
            popupMenuTool9.SharedProps.Caption = "�}�E�X�p���j���[";
            popupMenuTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool9.SharedProps.MergeOrder = 10;
            buttonTool51.InstanceProps.IsFirstInGroup = true;
            popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool49,
            buttonTool50,
            buttonTool51});
            buttonTool52.SharedProps.Caption = "�V�����^�u(&N)";
            buttonTool52.SharedProps.CustomizerCaption = "�V�����^�u�{�^���}�E�X�p";
            buttonTool53.SharedProps.Caption = "����(&C)";
            buttonTool53.SharedProps.CustomizerCaption = "�^�u�����{�^���}�E�X�p";
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Left";
            labelTool10.SharedProps.AppearancesSmall.Appearance = appearance1;
            labelTool10.SharedProps.CustomizerCaption = "���O�C�����_��";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool10.SharedProps.MergeOrder = 60;
            labelTool10.SharedProps.ShowInCustomizer = false;
            labelTool10.SharedProps.Width = 150;
            buttonTool54.SharedProps.Caption = "�^�u�����(�V���[�g�J�b�g�p)";
            buttonTool54.SharedProps.CustomizerCaption = "�^�u�����(�V���[�g�J�b�g�p)";
            buttonTool54.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            buttonTool55.SharedProps.Caption = "��ʐؑ�(F6)";
            buttonTool55.SharedProps.CustomizerCaption = "��ʐؑփ{�^��";
            buttonTool55.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool55.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            buttonTool56.SharedProps.Caption = "���ϗ���(&Q)";
            buttonTool56.SharedProps.CustomizerCaption = "���ϗ����{�^��";
            buttonTool56.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool57.SharedProps.Caption = "�ŐV���(&A)";
            buttonTool57.SharedProps.CustomizerCaption = "�ŐV���{�^��";
            buttonTool57.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool6,
            labelTool7,
            labelTool8,
            mdiWindowListTool1,
            buttonTool26,
            listTool2,
            labelTool9,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool30,
            buttonTool31,
            buttonTool32,
            buttonTool33,
            buttonTool34,
            buttonTool35,
            buttonTool36,
            buttonTool37,
            buttonTool38,
            buttonTool39,
            buttonTool40,
            buttonTool41,
            buttonTool42,
            buttonTool43,
            buttonTool44,
            popupMenuTool7,
            popupMenuTool8,
            popupMenuTool9,
            buttonTool52,
            buttonTool53,
            labelTool10,
            buttonTool54,
            buttonTool55,
            buttonTool56,
            buttonTool57});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Right";
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 586);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Top";
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMMIT01000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMMIT01000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��������";
            this.Load += new System.EventHandler(this.PMMIT01000UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DCKAU00160UA_FormClosed);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// ===============================================================================
		// �v���C�x�[�g�񋓌^
		// ===============================================================================
        #region private enum
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        #endregion

		// ===================================================================================== //
		// �萔��`
		// ===================================================================================== //
		#region Private Constant
        // ���Ӑ挳��
		private const string TAB_PARTSSEARCH = "PARTSSEARCH_TAB";
			
		private const string NO_TAB = "";

		private const string ctTOOLBAR_BUTTONTOOL_CLOSE_KEY = "ButtonTool_Close";
		private const string ctTOOLBAR_BUTTONTOOL_RETURN_KEY = "ButtonTool_Return";
		private const string ctTOOLBAR_BUTTONTOOL_FORWARD_KEY = "ButtonTool_Forward";
		private const string ctTOOLBAR_BUTTONTOOL_PRINT_KEY = "ButtonTool_Print";
		private const string ctTOOLBAR_BUTTONTOOL_NEW_KEY = "ButtonTool_New";
		private const string ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY = "ButtonTool_DeleteSlip";
		private const string ctTOOLBAR_BUTTONTOOL_UNDO_KEY = "ButtonTool_Undo";
		private const string ctTOOLBAR_BUTTONTOOL_GUIDE_KEY = "ButtonTool_Guide";
		private const string ctTOOLBAR_BUTTONTOOL_READSLIP_KEY = "ButtonTool_ReadSlip";
		private const string ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY = "ButtonTool_SlipCopy";
		private const string ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY = "ButtonTool_ChangePartsSearch";
		private const string ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY = "ButtonTool_EntryJoinParts";
		private const string ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY = "ButtonTool_OrderSelect";
		private const string ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY = "ButtonTool_ShowSet";
		private const string ctTOOLBAR_BUTTONTOOL_SETTING_KEY = "ButtonTool_Setting";
		private const string ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY = "ButtonTool_ChangeDisplay";
        private const string ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY = "ButtonTool_ReNewal"; // 2009.03.26
		
		// �^�u�֘A
		private const string ctTOOLBAR_BUTTONTOOL_NEWTAB_KEY = "ButtonTool_NewTab";
		private const string ctTOOLBAR_BUTTONTOOL_NEWTAB_MOUSE_KEY = "ButtonTool_NewTab_Mouse";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_KEY = "ButtonTool_CloseTab";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_MOUSE_KEY = "ButtonTool_CloseTab_Mouse";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_HIDDEN_KEY = "ButtonTool_CloseTab_Hidden";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSEOTHERTAB_MOUSE_KEY = "ButtonTool_CloseOtherTab_Mouse";

		private const string ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY = "LabelTool_LoginTitle";
		private const string ctTOOLBAR_LABELTOOL_LOGINNAME_KEY = "LabelTool_LoginName";
		private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY = "LabelTool_LoginSectionTitle";
		private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY = "LabelTool_LoginSectionName";
		private const string ctTOOLBAR_LISTTOOL_TABFORM_KEY = "ListTool_TabForm";

        private const int ctTAB_MAXCNT = 10;

        //MDI�q���PGID
		private const string MDIPARTSSEARCH = "PMMIT01010U";   // �������MDI�q���PGID

		private const string ctAssemblyName = "PMMIT01000U";
     
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region Private Member

		// �e��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;              // ����{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;             // �߂�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _forwardButton;            // ���փ{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;              // �ۑ��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _newtButton;               // �V�K�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteSlipButton;         // �`�[�폜�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;               // ���ɖ߂��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;              // �K�C�h�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _readSlipButton;           // �`�[�ďo�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _slipCopyButton;           // �`�[���ʃ{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _changePartsSearchButton;  // ���i�����ؑփ{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _entryJoinPartsButton;     // �����o�^�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _orderSelectButton;        // �����I���{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _showSetButton;            // �Z�b�g�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _settingButton;            // �ݒ�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool _changeDisplayButton;      // ��ʐؑփ{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;		   	// �ŐV���{�^�� // 2009.03.26

		private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;           // ���O�C���S���҃^�C�g��
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ���O�C���S���Җ�
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;    // ���O�C�����_�^�C�g��
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;     // ���O�C�����_��

		// �t�H�[�����䃊�X�g
		private Hashtable _formControlInfoTable = new Hashtable();
		private ArrayList _formControlInfoList = new ArrayList();

		// �N���p�����[�^
		private string _enterpriseCode = "";
        private int _customerCode = 0;

		// ���_�I���f�t�H���g�\���ݒ�
		private bool _isEvent = false;															 // �C�x���g����t���O

        private SecInfoAcs _secInfoAcs;
        private SecInfoSet _ownSecInfoSet;

		private List<int> _tabIndexList = new List<int>();

        /// <summary>�I�v�V�������</summary>
        private bool _opt_CarMng = true;
        private bool _opt_FreeSearch = true;
        private bool _opt_UOE = true;

        #endregion
		
		// ===================================================================================== //
		// �f���Q�[�g�C�x���g
		// ===================================================================================== //
		#region DelegateEvent
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}
		#endregion

		// ===================================================================================== //
		// �������\�b�h
		// ===================================================================================== //
		# region Private Methods


        #region ���I�v�V������񐧌䏈��
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���ԗ��Ǘ��I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            this._opt_CarMng = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region �����R�����I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            this._opt_FreeSearch = (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract);
            #endregion

            #region ���t�n�d�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            this._opt_UOE = (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract);
            #endregion
        }
        #endregion


        #region ���[�h�ʋN������

        /// <summary>
        /// ���[�h�ʋN������
        /// <remarks>
        /// <br>Note      :  �N���������Ƀp�����[�^��U�蕪���܂�</br>
        /// <br>Programer :  21024 ���X�؁@��</br>
        /// <br>Date      :  2008.06.18</br>        
        /// </remarks>
        /// </summary>
        private void MovingModeSetting()
        {          
            string[] args = Program._parameter;

			// �N���p�����[�^�ݒ�
			if ((args != null) && (args.Length > (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE))
			{
                //���Ӑ�w��^
				this._enterpriseCode = args[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ENTERPRISECODE];
				this._customerCode = TStrConv.StrToIntDef(args[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE].ToString(), 0);				
			}
        }

        #endregion

        #region ���_���擾����

        /// <summary>
        ///  �����_���̎擾
        /// </summary>
        private void GetOwnSecInfo()
        {
            // �����_�̎擾
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode, out secInfoSet);

            if (secInfoSet != null)
            {
                this._ownSecInfoSet = secInfoSet;
            }
        }

        #endregion

        #region �c�[���o�[�����ݒ菈��
        /// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�������ݒ肵�܂�</br>
		/// <br>Programer  : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void SetToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

			// ���O�C���S���҂ւ̃A�C�R���ݒ�
			this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// �u�I���v�̃A�C�R���ݒ�
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// �u�߂�v�̃A�C�R���ݒ�
			this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			// �u�i�ށv�̃A�C�R���ݒ�
			this._forwardButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;

			// �u����v�̃A�C�R���ݒ�
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

			// �u�V�K�v�̃A�C�R���ݒ�
			this._newtButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

			// �u�`�[�폜�v�̃A�C�R���ݒ�
			this._deleteSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

			// �u���ɖ߂��v�̃A�C�R���ݒ�
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

			// �u�K�C�h�v�̃A�C�R���ݒ�
			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

			// �u�`�[�ďo�v�̃A�C�R���ݒ�
			this._readSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;

			// �u�`�[���ʁv�̃A�C�R���ݒ�
			this._slipCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;

			// �u���i�����ؑցv�̃A�C�R���ݒ�
			this._changePartsSearchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;

			// �u�����o�^�v�̃A�C�R���ݒ�
			this._entryJoinPartsButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RECYCLE;

			// �u�����I���v�̃A�C�R���ݒ�
			this._orderSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SELECT;

			// �u�Z�b�g�v�̃A�C�R���ݒ�
			this._showSetButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.WORK;

			// �u�ݒ�v�̃A�C�R���ݒ�
			this._settingButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// �u��ʐؑցv�̃A�C�R���ݒ�
			this._changeDisplayButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;

            // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �u�ŐV���v�̃A�C�R���ݒ�
            this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// ���_���x���̃A�C�R���ݒ�
			this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

            if (this._ownSecInfoSet != null)
            {
                // ���_��
                this._loginSectionNameLabel.SharedProps.Caption = this._ownSecInfoSet.SectionGuideNm;
            }

			// ���O�C����
			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}

        #endregion

		#region �t�H�[���R���g���[��������N���A����
		/// <summary>
		/// �t�H�[���R���g���[��������N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[���R���g���[���N���X���N���G�C�g���A�f�[�^���i�[���܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void FormControlInfoClear()
		{
			this._formControlInfoTable.Clear();
			this._formControlInfoList.Clear();
			this._tabIndexList.Clear();
		}

		#endregion

		#region �������σt�H�[���R���g���[���N���X��������

		/// <summary>
		/// �������σ^�u�t�H�[����������
		/// </summary>
		/// <param name="index">�쐬�p�C���f�b�N�X</param>
		/// <returns></returns>
		private void CreateEstimateControlInfo( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			FormControlInfo info = new FormControlInfo(key, MDIPARTSSEARCH, "Broadleaf.Windows.Forms.PMMIT01010UA", string.Format("��������[{0}]", index), IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH], NO_TAB, NO_TAB);

			this._formControlInfoTable.Add(key, info);

			this._tabIndexList.Add(index);
		}

		#endregion

		#region �������σt�H�[���R���g���[���N���X�폜����

		/// <summary>
		/// �������σ^�u�t�H�[����������
		/// </summary>
		/// <param name="index">�쐬�p�C���f�b�N�X</param>
		/// <returns></returns>
		private void DeleteEstimateControlInfo( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			if (this._formControlInfoTable.ContainsKey(key))
			{
				this._formControlInfoTable.Remove(key);
			}

			if (this._tabIndexList.Contains(index))
			{
				this._tabIndexList.Remove(index);
			}
		}

		#endregion

        #region ��������Tab�t�H�[���L�[���C���f�b�N�X�擾

        /// <summary>
        /// �������ς���^�u�t�H�[���C���f�b�N�X�擾����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetEstimateTabIndex(string key)
        {
            string work = key.Replace(TAB_PARTSSEARCH, string.Empty);
            work = work.Replace("[", string.Empty);
            work = work.Replace("]", string.Empty);

            return TStrConv.StrToIntDef(work, -1);
        }
        #endregion

        #region ��������Tab�t�H�[����������

        /// <summary>
		/// ��������Tab�t�H�[����������
		/// </summary>
		/// <param name="index">�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : Tab�t�H�[���𐶐����܂��B</br>
		/// <br>Programer  : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool EstimateTabCreate( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			return this.TabCreate(key);
		}

		#endregion

		#region Tab�t�H�[����������

		/// <summary>
		/// Tab�t�H�[����������
		/// </summary>
		/// <param name="key">�L�[</param>
		/// <remarks>
		/// <br>Note       : Tab�t�H�[���𐶐����܂��B</br>
		/// <br>Programer  : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabCreate(string key)
		{
			// �t�H�[������e�[�u���ɃL�[�����݂��Ȃ��ꍇ�͏������Ȃ�
			if (!this._formControlInfoTable.Contains(key)) return false;

			FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

			if (info == null) return false;

			Form form = info.Form;

			if (form == null)
			{
				form = this.CreateTabForm(info.AssemblyID, info.ClassID, info.Key, info.Name, info.Icon, info);

				if (form == null) return false;

				info.Form = form;
			}
			else
			{
				this.Main_UTabControl.Tabs[key].Visible = true;
			}

			return true;
        }

        #endregion

		#region Tab�t�H�[���폜����

		/// <summary>
		/// Tab�t�H�[���폜����
		/// </summary>
		/// <param name="key">�L�[</param>
		/// <remarks>
		/// <br>Note       : Tab�t�H�[���𐶐����܂��B</br>
		/// <br>Programer  : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabDelete( string key )
		{
			this.Main_UTabControl.BeginUpdate();
			try
			{
				// �w��L�[�̃^�u�����݂��Ȃ��ꍇ�͏������Ȃ�
				if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

                int index = GetEstimateTabIndex(key);

                if (index > 0)
                {
                    this.DeleteEstimateControlInfo(index);
                }

                this.Main_UTabControl.Tabs.Remove(this.Main_UTabControl.Tabs[key]);

				return true;
			}
			finally
			{
				this.Main_UTabControl.EndUpdate();
			}
		}

		#endregion

		#region ��������Tab�t�H�[���ǉ�����
		/// <summary>
		/// ��������Tab�t�H�[���ǉ�����
		/// </summary>
		/// <returns></returns>
		private void EstimateTabAdd()
		{
			int index = ( this._tabIndexList.Count > 0 ) ? this._tabIndexList[this._tabIndexList.Count - 1] + 1 : 1;
			this.CreateEstimateControlInfo(index);
			this.EstimateTabCreate(index);
		}
		#endregion

        #region �^�u�A�N�e�B�u������
        /// <summary>
		/// �^�u�A�N�e�B�u������
		/// </summary>
		/// <param name="key">�A�N�e�B�u�ɂ���t�H�[���̃L�[���</param>
		/// <returns>����[TRUE:���� FALSE:���s]</returns>
		/// <remarks>
		/// <br>Note       : Tab�t�H�[�����A�N�e�B�u�ɂ��܂��B</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabActive(string key)
		{			
			// �w��L�[�̃^�u�����݂��Ȃ��ꍇ�͏������Ȃ�
			if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

			bool result = false;

			switch (key)
			{
				default:
				{
					break;
				}
			}
			return result;
        }
        
        /// <summary>
		/// �^�u�A�N�e�B�u������
		/// </summary>
		/// <param name="key">�A�N�e�B�u�ɂ���t�H�[���̃L�[���</param>
		/// <param name="form">�A�N�e�B�u�t�H�[��</param>
		/// <returns>����[TRUE:���� FALSE:���s]</returns>
		/// <remarks>
		/// <br>Note       : Tab�t�H�[�����A�N�e�B�u�ɂ��܂��B</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabActive(string key, ref Form form)
		{
			// �^�u�R���g���[����A�L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
			if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

			bool result = this.TabActive(key);

			// �Y���L�[�̃^�u���A�N�e�B�u�ɂ���
			if (result)
			{
				// �t�H�[�����擾����
				if (this.Main_UTabControl.Tabs[key].Tag is Form)
				{
					form = (Form)this.Main_UTabControl.Tabs[key].Tag;
				}
			}
			return result;
		}

        #endregion

        #region �^�u�q��ʂ𐶐�����
        /// <summary>
		/// �^�u�q��ʂ𐶐�����
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI�q��ʂ𐶐�����</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private Form CreateTabForm( string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info )
		{
			Form form = null;

			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

			if (form == null)
			{
				form = new Form();
			}

			if (form != null)
			{
				// �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
				Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
					new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

				// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
				Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

				dataviewTab.TabPage = dataviewTabPageControl;
				dataviewTab.Text = info.Name;
				dataviewTab.Key = info.Key;
				dataviewTab.Tag = form;
				dataviewTab.Appearance.Image = info.Icon;
				dataviewTab.Appearance.BackColor = Color.White;
				dataviewTab.Appearance.BackColor2 = Color.Lavender;
				dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				dataviewTab.ActiveAppearance.BackColor = Color.White;
				dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
				dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				dataviewTab.ActiveAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                
				this.Main_UTabControl.Controls.Add(dataviewTabPageControl);
				this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
				this.Main_UTabControl.SelectedTab = dataviewTab;

				// �t�H�[���v���p�e�B�ύX
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				dataviewTabPageControl.Controls.Add(form);

				// ILedgerMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
				if (( form is IEstimateMDIChild ))
				{
					( (IEstimateMDIChild)form ).ParentToolbarLedgerSettingEvent += new ParentToolbarLedgerSettingEventHandler(this.ToolBarButtonEnabledSetting);

					( (IEstimateMDIChild)form ).Show(null);

				}
				else
					form.Show();

				form.Dock = System.Windows.Forms.DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

        #endregion

        #region �A�Z���u���C���X�^���X������
        /// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (System.IO.FileNotFoundException er)
			{
				// �ΏۃA�Z���u���Ȃ��I
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "��ʂ̃��[�h�Ɏ��s���܂���" + "\n\r" + er.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch (System.Exception er)
			{
				// �ΏۃA�Z���u���Ȃ�
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "��ʂ̃��[�h�Ɏ��s���܂���" + "\n\r" + er.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			return obj;
        }

        #endregion

        #region �c�[���o�[�{�^���L�������ݒ菈��
        /// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <param name="activeForm">�A�N�e�B�u�ȃt�H�[��</param>
		/// <remarks>
		/// <br>Note       : �c�[���[�o�[�{�^���̗L���E�����ݒ���s���܂��B</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (activeForm is IEstimateMDIChild)
			{
                this.Main_ToolbarsManager.BeginUpdate();

                this._returnButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanReturnButton;
				this._forwardButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanForwardButton;
				this._printButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanPrintButton;
				this._newtButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanNewButton;
				this._deleteSlipButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanDeleteSlipButton;
				this._undoButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanUndoButton;
				this._guideButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanGuideButton;
				this._readSlipButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanReadSlipButton;
				this._slipCopyButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanCopySlipButton;
				this._changePartsSearchButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanChangePartsSearchButton;
				this._entryJoinPartsButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanEntryJoinPartsButton;
				this._orderSelectButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanOrderSelectButton;
				this._showSetButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanShowSetButton;
				this._changeDisplayButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanChangeDisplayButton;

                this.Main_ToolbarsManager.EndUpdate();
			}
        }

        #endregion

        #region �c�[���o�[�̃^�u���X�g�쐬����
        /// <summary>
		/// �c�[���o�[�̃^�u���X�g�𐶐�����
		/// </summary>
		/// <param name="sender">�ďo���̃I�u�W�F�N�g</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void SetToolBarTabFormList(object sender)
		{
			Infragistics.Win.UltraWinToolbars.ListTool tabList = (Infragistics.Win.UltraWinToolbars.ListTool)Main_ToolbarsManager.Tools[ctTOOLBAR_LISTTOOL_TABFORM_KEY];
			tabList.ListToolItems.Clear();

			// �E�B���h�E�E�c�[���o�[���ĕҐ��y�ѕ\������
			for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
			{
				Infragistics.Win.UltraWinToolbars.ListToolItem itm = new Infragistics.Win.UltraWinToolbars.ListToolItem();
				if (this.Main_UTabControl.Tabs[i].Visible)
				{
					itm.Key = this.Main_UTabControl.Tabs[i].Key;
					itm.Text = string.Format("&{0:d} {1}", i + 1, this.Main_UTabControl.Tabs[i].Text);
					tabList.ListToolItems.Add(itm);
					if (this.Main_UTabControl.Tabs[i].Selected == true)
					{
						tabList.SelectedItemIndex = tabList.ListToolItems.Count - 1;
					}
				}
			}
        }
        #endregion

        #region �G���[���b�Z�[�W�\������
        /// <summary>
		/// �G���[���b�Z�[�W�\��
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="iMsg">�G���[���b�Z�[�W</param>
		/// <param name="iSt">�G���[�X�e�[�^�X</param>
		/// <param name="iButton">�\���{�^��</param>
		/// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
		/// <br>Programmer : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        # endregion

        // ===================================================================================== //
		// �R���g���[���C�x���g
		// ===================================================================================== //
		#region Control Event

        #region FormLoad�C�x���g
        /// <summary>
		/// ���C���t���[����LOAD�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���C���t���[����LOAD�C�x���g</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
        private void PMMIT01000UA_Load(object sender, EventArgs e)
        {
            this.SettingOptionInfo();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �I�v�V�������ݒ�
        /// </summary>
        private void SettingOptionInfo()
        {
            this._orderSelectButton.SharedProps.Visible = this._opt_UOE;
        }
        #endregion

        #region TimerTick�C�x���g
        /// <summary>
		/// �N���^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
			this._isEvent = false;

			try
			{
				this._isEvent = false;

                this.GetOwnSecInfo();

				// �c�[���o�[��ݒ肷��
				this.SetToolbar();

				this.Main_UTabControl.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

				// �t�H�[��������N���A
				this.FormControlInfoClear();

				// �������ς̃t�H�[������e�[�u���쐬
				this.CreateEstimateControlInfo(1);

				// ���i�����^�u����
				if (this.EstimateTabCreate(1))
				{
					//// ���Ӑ挳�����A�N�e�B�u�ɂ���
					//if (this.Main_UTabControl.Tabs.Exists(TAB_PARTSSEARCH))
					//{
					//    //Form form = (Form)this.Main_UTabControl.Tabs[TAB_PARTSSEARCH].Tag;
					//    //this.TabActive(NO0_CUSTOMERLEDGER_TAB, ref form);
					//}
				}

				ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.Main_ToolbarsManager);
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				this._isEvent = true;
			}
        }

        #endregion

        #region ToolClick�C�x���g
        /// <summary>
		/// ToolBar��click�E�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : ToolBar��click�E�C�x���g</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			switch (e.Tool.Key)
			{
				//---------------------------------------------------------------------
				// �I���{�^��
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSE_KEY:
					{
                        bool isClose = false;
                        if (this.Main_UTabControl.Tabs.Count > 1)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "�S�Ẵ^�u����܂��B��낵���ł����H",
                                0,
                                MessageBoxButtons.OKCancel);

                            isClose = ( dialogResult == DialogResult.OK ) ? true : false;
                        }
                        else
                        {
                            isClose = true;
                        }
                        if (isClose)
                        {
                            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                            {
                                if (tab.Tag is System.Windows.Forms.Form)
                                {
                                    ( (System.Windows.Forms.Form)tab.Tag ).Close();
                                }
                            }
                           
                            // ���C����ʂ̃N���[�Y
                            this.Close();
                        }
						break;
					}

				//---------------------------------------------------------------------
				// �V�����^�u
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_NEWTAB_KEY:
				case ctTOOLBAR_BUTTONTOOL_NEWTAB_MOUSE_KEY:
					{
                        if (this.Main_UTabControl.Tabs.Count == ctTAB_MAXCNT)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "����ȏ�ǉ��ł��܂���B",
                                0,
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            this.EstimateTabAdd();
                        }
						break;
					}

				//---------------------------------------------------------------------
				// �^�u�����
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_KEY:
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_HIDDEN_KEY:
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_MOUSE_KEY:
					{
						if (this.Main_UTabControl.ActiveTab != null)
						{
							this.TabDelete(this.Main_UTabControl.ActiveTab.Key);
						}
						break;
					}

				//---------------------------------------------------------------------
				// ���̃^�u�����
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSEOTHERTAB_MOUSE_KEY:
					{
						string key = this.Main_UTabControl.ActiveTab.Key;
						List<string> deleteKeyList = new List<string>();
						foreach(Infragistics.Win.UltraWinTabControl.UltraTab ultraTab in this.Main_UTabControl.Tabs)
						{
							if (ultraTab.Key != key)
							{
								deleteKeyList.Add(ultraTab.Key);
							}
						}

						foreach (string deleteKey in deleteKeyList)
						{
							this.TabDelete(deleteKey);
						}

						break;
					}

				//---------------------------------------------------------------------
				// �߂�
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_RETURN_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).FocusSet_Return();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �i��
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_FORWARD_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).FocusSet_Forward();
						}
						break;
					}

				//---------------------------------------------------------------------
				// ��ʐؑ�
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ChangeDisplay();
						}
						break;
					}

				//---------------------------------------------------------------------
				// ���
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_PRINT_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
                            if (( (IEstimateMDIChild)activeForm ).PrintBeforeCheack())
                            {
                                ( (IEstimateMDIChild)activeForm ).Print();
                            }
						}
						break;
					}

				//---------------------------------------------------------------------
				// �V�K
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_NEW_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).CreateNewSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �`�[�폜
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).DeleteSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// ���ɖ߂�
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_UNDO_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).Undo();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �K�C�h
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_GUIDE_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ExecuteGuide();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �`�[�ďo
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_READSLIP_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ReadSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �`�[����
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).CopySlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// ���i�����ؑ�
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ChangePartsSearch();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �����o�^
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).EntryJoinParts();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �����I��
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).OrderSelect();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �Z�b�g
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ShowSet();
						}
						break;
					}

				//---------------------------------------------------------------------
				// �ݒ�
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SETTING_KEY:
					{
						EstimateInputSetup _estimateInputSetup = new EstimateInputSetup();

						_estimateInputSetup.ShowDialog(this);
						break;
					}

                // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //---------------------------------------------------------------------
                // �ŐV���
                //---------------------------------------------------------------------
                case ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY:
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�S�Ẵ^�u�̉�ʏ��̓N���A����܂��B" + "\r\n" + "\r\n" +
                            "��낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.No) break;

                        foreach (Infragistics.Win.UltraWinTabControl.UltraTab ultraTab in this.Main_UTabControl.Tabs)
                        {
                            Form activeForm = (Form)ultraTab.Tag;
                            if ((activeForm is IEstimateMDIChild))
                            {
                                ((IEstimateMDIChild)activeForm).CreateNewSlip();
                            }
                        }

                        Form activeFormm = (Form)this.Main_UTabControl.SelectedTab.Tag;
                        if ((activeFormm is IEstimateMDIChild))
                        {
                            ((IEstimateMDIChild)activeFormm).ReNewal();
                        }

                        break;
                    }
                // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			}
		}

        #endregion

        #region Form_Activated�C�x���g
		/// <summary>
		/// MDI�q��ʂ�Active�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : MDI�q��ʂ�Active�C�x���g</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Form_Activated(object sender, System.EventArgs e)
		{
        }

        #endregion

        #region Form_Deactivated�C�x���g
        /// <summary>
		/// MDI�q��ʂ�Deactived�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : MDI�q��ʂ�Deactived�C�x���g</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Form_Deactivated(object sender, System.EventArgs e)
		{
        }

        #endregion

        #region SelectedTabChanged�C�x���g
        /// <summary>
		/// �^�u�q��ʃ^�u�I���㏈��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : �^�u�q��ʃ^�u�I����ɔ�������C�x���g�ł��B</br>
		/// <br>Programer  : 21024�@���X�؁@��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (!this._isEvent)
				return;

			this._isEvent = false;
			try
			{
				if (e.Tab == null)
					return;

				// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
				object target = this.Main_UTabControl.SelectedTab.Tag;

				this.ToolBarButtonEnabledSetting(target);				
			}
			finally
			{
				this._isEvent = true;
			}
        }
        #endregion

        #region FormClosed�C�x���g
        /// <summary>
		///	�t�H�[������悤�Ƃ������̃C�x���g�ł��B
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : �t�H�[��������ꂽ��ɔ������܂��B</br>
		/// <br>Programmer  : 21024�@���X�؁@��</br>
		/// <br>Date        : 2008.06.18</br>
		/// </remarks>
        private void DCKAU00160UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �C�x���g�𔭐������Ȃ��ׁA�t���OON
            this._isEvent = false;

			//// �q��ʂ�j������
			//if (this._partsSearchForm != null)
			//{
			//    this._partsSearchForm.Close();
			//    this._partsSearchForm.Dispose();
			//}

            // �e���[�̃u���E�U�ɋ�A�h���X��\�������܂��B�\�����Ă���PDF�t�@�C�������ׂł��B
            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
            {
                this.Main_UTabControl.Tabs.Remove(tab);
            }
			ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.Main_ToolbarsManager);
        }
        #endregion

		#region MouseClick�C�x���g
		/// <summary>
		/// �^�u���MouseClick�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : Tab�̈悪�N���b�N���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer  : 21024�@���X�؁@��</br>
		/// <br>Date        : 2008.06.18</br>
		/// </remarks>
		private void Main_UTabControl_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				// ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
				( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools["PopupMenuTool_Mouse"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this);
			}
		}
		#endregion

        // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region �I��ButtonClic�C�x���g
        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            bool isClose = false;

            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "�I�����Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                if (this.Main_UTabControl.Tabs.Count > 1)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "�S�Ẵ^�u����܂��B��낵���ł����H",
                        0,
                        MessageBoxButtons.OKCancel);

                    isClose = (dialogResult == DialogResult.OK) ? true : false;
                }
                else
                {
                    isClose = true;
                }
                if (isClose)
                {
                    foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                    {
                        if (tab.Tag is System.Windows.Forms.Form)
                        {
                            ((System.Windows.Forms.Form)tab.Tag).Close();
                        }
                    }

                    // ���C����ʂ̃N���[�Y
                    this.Close();
                }
            }
        }
        #endregion
        // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

    }
}
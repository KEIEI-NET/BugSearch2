using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.CodeDom.Compiler;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Drawing.Printing;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ�UI
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�̈󎚈ʒu��ݒ肷���ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: 2008.03.19 22024 ����_�u</br>
	/// <br>             : �P�D���[�̒��o�����ɓ��t�n���ڂ��܂܂�Ȃ���Ԃł̓o�^��s�Ƃ���B</br>
	/// <br>             : �Q�DSummaryGroup�ɑ��݂��Ȃ�GroupHeader���w�肳��Ă����</br>
	/// <br>             : �@�@������ɃG���[����������s��C���B</br>
	/// <br>             : �R�D���o�����̕K�{�����̓��̓`�F�b�N���s�Ȃ���悤�ɏC���B</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008.05.21 22018 ��ؐ��b</br>
    /// <br>             : �P�DPM.NS�����ύX�B</br>
    /// <br>             : �Q�DActiveReport�̃o�[�W�����A�b�v�Ή�</br>
	/// </remarks>
	public partial class SFANL08105UA : Form, IFreeSheetMainFrame
	{
		#region Enum
		/// <summary>�c�[���o�[���[�h</summary>
		private enum LayoutToolbarModes
		{
			/// <summary>�P��I��</summary>
			SingleControl,
			/// <summary>��R���g���[���I��</summary>
			TwoControls,
			/// <summary>�����I��</summary>
			MultiControls,
			/// <summary>���I��</summary>
			NoControls,
		}

		/// <summary>�I�����[�h</summary>
		private enum ExitMode
		{
			/// <summary>�V�K�쐬</summary>
			CreateNew,
			/// <summary>��ʏI��</summary>
			Close,
		}

		/// <summary>���[�g�p�敪���</summary>
		internal enum PrintPaperUseDivcdKind
		{
			/// <summary>���[</summary>
			Report = 1,
			/// <summary>�`�[</summary>
			Slip = 2,
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            ///// <summary>DM���[</summary>
            //DMReport = 3,
            ///// <summary>DM�͂���</summary>
            //DMPostCard = 4,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            /// <summary>������</summary>
            DmdBill = 5,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
        /// <summary>
        /// ���R���[����p�r�敪
        /// </summary>
        internal enum FreePrtPprSpPrpseCd
        {
            EstimateForm = 1, // ���Ϗ�
            StockReturnSlip = 4, // �d���ԕi
            StockMoveSlip = 15, // �݌Ɉړ�
            UoeSlip = 16, // UOE�`�[
            DmdSum = 50, // ���v������
            DmdDetail = 60, // ���א�����
            DmdSlipSum = 70, // �`�[���v������
            DmdRect = 80, // �̎���
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD

		/// <summary>���R���[���ڃR�[�h���</summary>
		internal enum FreePrtPaperItemCdKind
		{
			/// <summary>�W�v����</summary>
			SummaryTextBox = 1,
			/// <summary>���s���t�i�a��j</summary>
			DateJpFormal = 2,
			/// <summary>���s���t�i�a��E���j</summary>
			DateJpAbbr = 3,
			/// <summary>���s���t�i����j</summary>
			DateAdFormal = 4,
			/// <summary>���s���ԁiHH:MM�j</summary>
			TimeAdFormal = 5,
			/// <summary>���s���ԁiHH��MM���j</summary>
			TimeJpFormal = 6,
			/// <summary>���o����</summary>
			ExtrCondition = 7,
			/// <summary>���ʃt�b�^�[1</summary>
			CommonFooter1 = 8,
			/// <summary>���ʃt�b�^�[2</summary>
			CommonFooter2 = 9,
			/// <summary>�Œ蕶��</summary>
			LiteralLabel = 10,
			/// <summary>�摜</summary>
			Picture = 11,
			/// <summary>�g��</summary>
			Shap = 12,
			/// <summary>����</summary>
			Line = 13,
			/// <summary>�\�[�g��1</summary>
			SortOder1 = 14,
			/// <summary>�\�[�g��2</summary>
			SortOder2 = 15,
			/// <summary>�\�[�g��3</summary>
			SortOder3 = 16,
			/// <summary>�\�[�g��4</summary>
			SortOder4 = 17,
			/// <summary>�\�[�g��5</summary>
			SortOder5 = 18,
			/// <summary>�Œ蕶���iTextBox�j</summary>
			/// <remarks>�g�p�֎~</remarks>
			TextBox = 19,
			/// <summary>�y�[�W�ԍ�</summary>
			PageNumber = 20,
			/// <summary>���y�[�W�ԍ�</summary>
			TotalPageNumber = 21,
			/// <summary>�s�ԍ��i5�s���݁j</summary>
			RowNumber5 = 22,
			/// <summary>�s�ԍ��i10�s���݁j</summary>
			RowNumber10 = 23,
		}
		#endregion

		#region Const
		// ������ �f�t�H���g�t�H���g����p ������
		private const string	ctStyleSheet_Normal	= "Normal";
		private const string	ctDefault_FontName	= "�l�r ����";
		private const float		ctDefault_FontSize	= 10;

		// ������ �c�[���o�[����p ������
		private const string ctToolBar_Layout		= "Layout";
		private const string ctToolBar_SheetSetting	= "SheetSetting";
		private const string ctToolButton_SaveNewName			= "SaveNewName_ButtonTool";		// ���O��t���ĕۑ�
		private const string ctToolButton_FitPaper				= "FitPaper_ButtonTool";		// �p�����ɍ��킹��
		private const string ctToolButton_ExtrSetting			= "ExtrSetting_ButtonTool";		// ���o�����ݒ�
		private const string ctToolButton_SortSetting			= "SortSetting_ButtonTool";		// �\�[�g���ʐݒ�

		private const string ctToolButton_AlignToGrid			= "AlignToGrid";				// �O���b�h�ɍ��킹�Đ���
		private const string ctToolButton_AlignLefts			= "AlignLefts";					// ������
		private const string ctToolButton_AlignCenters			= "AlignCenters";				// �㉺��������
		private const string ctToolButton_AlignRights			= "AlignRights";				// �E����
		private const string ctToolButton_AlignTops				= "AlignTops";					// �㑵��
		private const string ctToolButton_AlignMiddles			= "AlignMiddles";				// ���E��������
		private const string ctToolButton_AlignBottoms			= "AlignBottoms";				// ������
		private const string ctToolButton_MakeSameWidth			= "MakeSameWidth";				// ���𑵂���
		private const string ctToolButton_SizeToGrid			= "SizeToGrid";					// �O���b�h�̃T�C�Y�ɑ�����
		private const string ctToolButton_MakeSameHeight		= "MakeSameHeight";				// �����𑵂���
		private const string ctToolButton_MakeSameSize			= "MakeSameSize";				// �����T�C�Y�ɑ�����
		private const string ctToolButton_MakeHorizSpaceEqual	= "MakeHorizSpaceEqual";		// ���E�̊Ԋu���ϓ��ɂ���
		private const string ctToolButton_IncreaseHorizSpace	= "IncreaseHorizSpace";			// ���E�̊Ԋu���L������
		private const string ctToolButton_DecreaseHorizSpace	= "DecreaseHorizSpace";			// ���E�̊Ԋu����������
		private const string ctToolButton_RemoveHorizSpace		= "RemoveHorizSpace";			// ���E�̊Ԋu���폜����
		private const string ctToolButton_MakeVertSpaceEqual	= "MakeVertSpaceEqual";			// �㉺�̊Ԋu���ϓ��ɂ���
		private const string ctToolButton_IncreaseVertSpace		= "IncreaseVertSpace";			// �㉺�̊Ԋu���L����
		private const string ctToolButton_DecreaseVertSpace		= "DecreaseVertSpace";			// �㉺�̊Ԋu����������
		private const string ctToolButton_RemoveVertSpace		= "RemoveVertSpace";			// �㉺�̊Ԋu���폜����
		private const string ctToolButton_CenterHoriz			= "CenterHoriz";				// ���E��������
		private const string ctToolButton_CenterVert			= "CenterVert";					// �㉺��������
		private const string ctToolButton_BringToFront			= "BringToFront";				// �őO�ʂֈړ�
		private const string ctToolButton_SendToBack			= "SendToBack";					// �Ŕw�ʂֈړ�
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        private const string ctToolButton_ChangeUnit = "ChangeUnit"; // �P�ʐؑ�
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

		// ������ ARControl�^����ICON�p ������
		internal const string AR_ICON_TEXTBOX	= "AR_Textbox";
		internal const string AR_ICON_LABEL		= "AR_Label";
		internal const string AR_ICON_LINE		= "AR_Line";
		internal const string AR_ICON_PICTURE	= "AR_Picture";
		internal const string AR_ICON_SHAPE		= "AR_Shape";
		internal const string AR_ICON_BARCODE	= "AR_Barcode";

		// ������ ActiveReport�e��v���p�e�B�\���p ������
		internal const string ctPropName_Top			= "Top";
		internal const string ctPropName_Left			= "Left";
		internal const string ctPropName_Height			= "Height";
		internal const string ctPropName_Width			= "Width";
		internal const string ctPropName_X1				= "X1";
		internal const string ctPropName_X2				= "X2";
		internal const string ctPropName_Y1				= "Y1";
		internal const string ctPropName_Y2				= "Y2";
		internal const string ctPropName_LineWeight		= "LineWeight";
		internal const string ctPropName_Font			= "Font";
		internal const string ctPropName_Alignment		= "Alignment";
		internal const string ctPropName_PictureAlign	= "PictureAlignment";
		internal const string ctPropName_VAlignment		= "VerticalAlignment";
		internal const string ctPropName_BackColor		= "BackColor";
		internal const string ctPropName_ForeColor		= "ForeColor";
		internal const string ctPropName_LineColor		= "LineColor";
		internal const string ctPropName_WordWrap		= "WordWrap";
		internal const string ctPropName_MultiLine		= "MultiLine";
		internal const string ctPropName_Visible		= "Visible";
		internal const string ctPropName_OutputFormat	= "OutputFormat";
		internal const string ctPropName_LineStyle		= "LineStyle";
		internal const string ctPropName_Style			= "Style";
		internal const string ctPropName_SizeMode		= "SizeMode";
		internal const string ctPropName_FontSize		= "FontSize";
		internal const string ctPropName_FontFamily		= "FontFamily";
		internal const string ctPropName_Tag			= "Tag";
		internal const string ctPropName_Name			= "Name";
		internal const string ctPropName_Bold			= "Bold";
		internal const string ctPropName_Italic			= "Italic";
		internal const string ctPropName_UnderLine		= "UnderLine";
		internal const string ctPropName_Text			= "Text";
		internal const string ctPropName_Caption		= "Caption";
		internal const string ctPropName_PrintPage		= "PrintPageCtrlDivCd";
		internal const string ctPropName_Image			= "Image";
		internal const string ctPropName_DelImage		= "DelImage";
		internal const string ctPropName_CanShrink		= "CanShrink";
		internal const string ctPropName_CanGrow		= "CanGrow";
		internal const string ctPropName_PrintAtBottom	= "PrintAtBottom";
		internal const string ctPropName_KeepTogether	= "KeepTogether";
		internal const string ctPropName_NewPage		= "NewPage";
		internal const string ctPropName_RepeatStyle	= "RepeatStyle";
		internal const string ctPropName_SummaryRunning = "SummaryRunning";
		internal const string ctPropName_SummaryFunc	= "SummaryFunc";
		internal const string ctPropName_SummaryType	= "SummaryType";
		internal const string ctPropName_SummaryGroup	= "SummaryGroup";
		internal const string ctPropName_DataField		= "DataField";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        internal const string ctPropName_CharacterSpacing = "CharacterSpacing";
        internal const string ctPropName_PrintableByteCount = "PrintableByteCount";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ������ ���d�N���h�~�p ������
		// --------------------------------------------------------
		private static Mutex		_mutex;

		// --------------------------------------------------------
		// ������ �c�[���{�^�� ������
		// --------------------------------------------------------
		private ButtonTool			_buttonTool_AlignToGrid;
		private ButtonTool			_buttonTool_AlignLefts;
		private ButtonTool			_buttonTool_AlignCenters;
		private ButtonTool			_buttonTool_AlignRights;
		private ButtonTool			_buttonTool_AlignTops;
		private ButtonTool			_buttonTool_AlignMiddles;
		private ButtonTool			_buttonTool_AlignBottoms;
		private ButtonTool			_buttonTool_MakeSameWidth;
		private ButtonTool			_buttonTool_SizeToGrid;
		private ButtonTool			_buttonTool_MakeSameHeight;
		private ButtonTool			_buttonTool_MakeSameSize;
		private ButtonTool			_buttonTool_MakeHorizSpaceEqual;
		private ButtonTool			_buttonTool_IncreaseHorizSpace;
		private ButtonTool			_buttonTool_DecreaseHorizSpace;
		private ButtonTool			_buttonTool_RemoveHorizSpace;
		private ButtonTool			_buttonTool_MakeVertSpaceEqual;
		private ButtonTool			_buttonTool_IncreaseVertSpace;
		private ButtonTool			_buttonTool_DecreaseVertSpace;
		private ButtonTool			_buttonTool_RemoveVertSpace;
		private ButtonTool			_buttonTool_CenterHoriz;
		private ButtonTool			_buttonTool_CenterVert;
		private ButtonTool			_buttonTool_BringToFront;
		private ButtonTool			_buttonTool_SendToBack;

		// --------------------------------------------------------
		// ������ �e��h�b�N��� ������
		// --------------------------------------------------------
		// �ǉ�����
		private SFANL08105UB		_addItemControl;
		// �S�̐ݒ�
		private SFANL08105UC		_allSettingControl;
		// ���ڐݒ�
		private SFANL08105UD		_itemSettingControl;

		// --------------------------------------------------------
		// ������ �e��A�N�Z�X�N���X ������
		// --------------------------------------------------------
		// ���R���[�󎚈ʒu�ݒ�UI�A�N�Z�X�N���X
		private FrePrtPosAcs		_frePrtPosAcs;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        // �`�[����ݒ�A�N�Z�X�N���X
        private SlipPrtSetAcs _slipPrtSetAcs;
        // ����������p�^�[���A�N�Z�X�N���X
        private DmdPrtPtnAcs _dmdPrtPtnAcs;
        // �Z���`�E�C���`����
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		// --------------------------------------------------------
		// ������ �K�C�h ������
		// --------------------------------------------------------
		// ���R���[�I���K�C�h
		private FPprSearchGuide		_frePprSelectGuide;

		// --------------------------------------------------------
		// ������ ���̑����[�N�ϐ� ������
		// --------------------------------------------------------
		// ��ƃR�[�h
		private string				_enterpriseCode;
		// �N���[�Y���v���p�e�B�p
		private bool				_canClose;
		// �ǉ��R���g���[������LIST
		private List<string>		_addControlNames;
		//
		private float				_prevReportSize;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UA()
		{
			InitializeComponent();

			_frePrtPosAcs = new FrePrtPosAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            _slipPrtSetAcs = new SlipPrtSetAcs();
            _dmdPrtPtnAcs = new DmdPrtPtnAcs();
            _cmInchControl = new CmInchControl();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			_addControlNames = new List<string>();

			_canClose = true;
		}
		#endregion

		#region SFANL08101IA �����o
		/// <summary>�N���[�Y���v���p�e�B</summary>
		/// <value>��ʂ��I�����Ă悢�ꍇ��True�A��肪����ꍇ��False��Ԃ��܂�</value>
		public bool CanClose
		{
			get {
				ExitDataEditProc(ExitMode.Close);
				return _canClose;
			}
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g�i���C���t���[���j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t���[���̃c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_New:		// �V�K
				{
					DialogResult dlgRet = ExitDataEditProc(ExitMode.CreateNew);
					if (dlgRet == DialogResult.Yes || dlgRet == DialogResult.No)
						CreateNewDataProc();
					break;
				}
				case FreeSheetConst.ctToolBase_Open:	// �J��
				{
					DialogResult dlgRet = ExitDataEditProc(ExitMode.CreateNew);
					if (dlgRet == DialogResult.Yes || dlgRet == DialogResult.No)
						OpenExistingDataProc();
					break;
				}
				case FreeSheetConst.ctToolBase_Save:	// �㏑���ۑ�
				{
					SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.OverWrite, true);
					break;
				}
				case FreeSheetConst.ctToolBase_Print:	// ���
				{
					PrintProc();
					break;
				}
				case ctToolButton_SaveNewName:			// ���O��t���ĕۑ�
				{
					SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.NewWrite, true);
					break;
				}
				case ctToolButton_FitPaper:				// �p�����ɍ��킹��
				{
					_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);

					FitPageWidthProc();
					break;
				}
				case ctToolButton_ExtrSetting:			// ���o�����ݒ�
				{
					ShowExecuteExtractionConditionGuide();
					break;
				}
				case ctToolButton_SortSetting:			// �\�[�g���ʐݒ�
				{
					ShowSortSetting();
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                case ctToolButton_ChangeUnit: // �P�ʐؑ�
                {
                    ChangeDesignUnit();
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				default:
				{
					ExecuteLayoutAction(e.Tool.Key);
					break;
				}
			}
		}

		/// <summary>
		/// �h�b�N���擾����
		/// </summary>
		/// <param name="dockAreaPaneArray">�h�b�N���R���N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: Dock�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray)
		{
			// �ǉ�����
			_addItemControl = new SFANL08105UB();
			DockableControlPane dcpAddItem
				= new DockableControlPane(_addItemControl.Name, "�ǉ�����", _addItemControl);
			dcpAddItem.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINTOUT];
			dcpAddItem.Pinned		= false;
			dcpAddItem.Size			= new Size(260, this.Height);
			dcpAddItem.MinimumSize	= dcpAddItem.Size;
			dcpAddItem.Settings.AllowClose	=  DefaultableBoolean.False;
			// ���R���[�Ǘ��I�v�V������������Ă��Ȃ��ꍇ�͔�\��
			if (!_frePrtPosAcs.FreeSheetMngOpt) dcpAddItem.Closed = true;

			// �S�̐ݒ�
			_allSettingControl = new SFANL08105UC();
			DockableControlPane dcpAllSetting
				= new DockableControlPane(_allSettingControl.Name, "�S�̐ݒ�", _allSettingControl);
			dcpAllSetting.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];
			dcpAllSetting.Pinned		= false;
			dcpAllSetting.Size			= new Size(260, this.Height);
			dcpAllSetting.MinimumSize	= dcpAllSetting.Size;
			dcpAllSetting.Settings.AllowClose		=  DefaultableBoolean.False;
			dcpAllSetting.Settings.AllowFloating	=  DefaultableBoolean.False;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            _allSettingControl.CmInchControl = _cmInchControl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			// ���ڐݒ�
			_itemSettingControl = new SFANL08105UD();
			DockableControlPane dcpItemSetting
				= new DockableControlPane(_itemSettingControl.Name, "���ڐݒ�", _itemSettingControl);
			dcpItemSetting.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			dcpItemSetting.Pinned		= true;
			dcpItemSetting.Size			= new Size(260, this.Height);
			dcpItemSetting.MinimumSize	= dcpItemSetting.Size;
			dcpItemSetting.Settings.AllowClose		= DefaultableBoolean.False;
			dcpItemSetting.Settings.AllowFloating	= DefaultableBoolean.False;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            _itemSettingControl.CmInchControl = _cmInchControl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			// �h�b�N���ځi���j
			DockAreaPane dapLeft = new DockAreaPane(DockedLocation.DockedLeft);
			dapLeft.Panes.Add(dcpAddItem);
			dapLeft.Size = new Size(260, this.Height);

			// �h�b�N���ځi�E�j
			DockableGroupPane dgpRight1 = new DockableGroupPane();
			dgpRight1.Panes.Add(dcpAllSetting);
			dgpRight1.TextTab	= dcpAllSetting.Text;
			DockableGroupPane dgpRight2 = new DockableGroupPane();
			dgpRight2.Panes.Add(dcpItemSetting);
			dgpRight2.TextTab	= dcpItemSetting.Text;
			DockAreaPane dapRight = new DockAreaPane(DockedLocation.DockedRight);
			dapRight.Panes.Add(dgpRight1);
			dapRight.Panes.Add(dgpRight2);
			dapRight.ChildPaneStyle	= ChildPaneStyle.TabGroup;
			dapRight.Size			= new Size(260, this.Height);

			dockAreaPaneArray = new DockAreaPane[] { dapRight, dapLeft };

			return 0;
		}

		/// <summary>
		/// �c�[���o�[���擾����
		/// </summary>
		/// <param name="rootToolsCollection">�c�[���R���N�V����</param>
		/// <param name="toolbarsCollection">�c�[���o�[�R���N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̏����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection)
		{
			// --------------------------------------------------------
			// ������ ���C�����j���[�̐ݒ� ������
			// --------------------------------------------------------
			UltraToolbar mainMenuToolbar = toolbarsCollection[FreeSheetConst.ctToolBar_MainMenu];
			mainMenuToolbar.Settings.AllowFloating		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;

			// --------------------------------------------------------
			// ������ �t�@�C���̐ݒ� ������
			// --------------------------------------------------------
			UltraToolbar mainToolbar = toolbarsCollection[FreeSheetConst.ctToolBar_Main];
			mainToolbar.Text						= "�{�^�����j���[�i�t�@�C���j";
			mainToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;
			mainToolbar.Settings.CaptionPlacement	= TextPlacement.RightOfImage;

			// �J���̃A�C�R����ύX
			rootToolsCollection[FreeSheetConst.ctToolBase_Open].SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];

			// �ۑ���Caption��ύX
			rootToolsCollection[FreeSheetConst.ctToolBase_Save].SharedProps.Caption = "�㏑���ۑ�(&S)";
			// �ۑ��{�^���̈ʒu�̕ύX
			mainToolbar.Tools.RemoveAt(1);
			mainToolbar.Tools.InsertTool(3, FreeSheetConst.ctToolBase_Save);

			mainToolbar.Tools[FreeSheetConst.ctToolBase_Print].InstanceProps.IsFirstInGroup = true;

			// ���O��t���ĕۑ��{�^���̒ǉ�
			ButtonTool saveButtonTool = new ButtonTool(ctToolButton_SaveNewName);
			saveButtonTool.SharedProps.Caption = "���O��t���ĕۑ�(&A)";
			rootToolsCollection.Add(saveButtonTool);
			PopupMenuTool fileMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_File];
			fileMenuTool.Tools.InsertTool(3, ctToolButton_SaveNewName);

			// �Z�p���[�^�̐ݒ�
			fileMenuTool.Tools[FreeSheetConst.ctToolBase_Print].InstanceProps.IsFirstInGroup = true;
			fileMenuTool.Tools[FreeSheetConst.ctToolBase_Save].InstanceProps.IsFirstInGroup = true;

			// --------------------------------------------------------
			// ������ �ҏW�̐ݒ� ������
			// --------------------------------------------------------
			// ���[�ݒ�p�c�[���o�[�̐ݒ�
			UltraToolbar sheetSettingToolbar = toolbarsCollection.AddToolbar(ctToolBar_SheetSetting);
			sheetSettingToolbar.Text						= "�{�^�����j���[�i�ҏW�j";
			sheetSettingToolbar.DockedPosition				= DockedPosition.Top;
			sheetSettingToolbar.DockedRow					= 1;
			sheetSettingToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.ToolDisplayStyle	= ToolDisplayStyle.ImageAndText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //// ���o�����ݒ�̒ǉ�
            //ButtonTool extrSettingButtonTool = new ButtonTool(ctToolButton_ExtrSetting);
            //extrSettingButtonTool.SharedProps.Caption		= "���o�����ݒ�";
            //extrSettingButtonTool.SharedProps.AppearancesSmall.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.SETUP1];
            //rootToolsCollection.Add(extrSettingButtonTool);
            //sheetSettingToolbar.Tools.AddTool(ctToolButton_ExtrSetting);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

			// �\�[�g���ʐݒ�̒ǉ�
			ButtonTool sortSettingButtonTool = new ButtonTool(ctToolButton_SortSetting);
			sortSettingButtonTool.SharedProps.Caption		= "�\�[�g���ʐݒ�";
			sortSettingButtonTool.SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SETUP1];
			rootToolsCollection.Add(sortSettingButtonTool);
			sheetSettingToolbar.Tools.AddTool(ctToolButton_SortSetting);

			// --------------------------------------------------------
			// ������ �ҏW���j���[�̐ݒ� ������
			// --------------------------------------------------------
			PopupMenuTool editMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_Edit];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //editMenuTool.Tools.AddTool(ctToolButton_ExtrSetting);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
			editMenuTool.Tools.AddTool(ctToolButton_SortSetting);

			// --------------------------------------------------------
			// ������ ���C�A�E�g�֌W�̃{�^���ǉ� ������
			// --------------------------------------------------------
			// ���C�A�E�g�p�c�[���o�[�̐ݒ�
			UltraToolbar layoutToolbar = toolbarsCollection.AddToolbar(ctToolBar_Layout);
			layoutToolbar.Text								= "���C�A�E�g";
			layoutToolbar.DockedPosition					= DockedPosition.Top;
			layoutToolbar.DockedRow							= 2;
			layoutToolbar.Settings.AllowHiding				= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockBottom			= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockLeft			= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockRight			= DefaultableBoolean.False;

			// ���C�A�E�g�p�{�^���̒ǉ�
			CreateLayoutToolButton(rootToolsCollection, layoutToolbar);

			// �p�����ɍ��킹��̒ǉ�
			ButtonTool fitPaperButtonTool = new ButtonTool(ctToolButton_FitPaper);
			fitPaperButtonTool.SharedProps.Caption			= "�p�������ő�ɂ���";
			fitPaperButtonTool.SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INDICATIONCHANGE];
			fitPaperButtonTool.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
			rootToolsCollection.Add(fitPaperButtonTool);
			layoutToolbar.Tools.AddTool(ctToolButton_FitPaper);
			layoutToolbar.Tools[ctToolButton_FitPaper].InstanceProps.IsFirstInGroup = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �P�ʐؑւ̒ǉ�
            ButtonTool changeUnitButtonTool = new ButtonTool( ctToolButton_ChangeUnit );
            changeUnitButtonTool.SharedProps.Caption = "�P�ʐؑ�";
            changeUnitButtonTool.SharedProps.DisplayStyle = ToolDisplayStyle.TextOnlyAlways;
            rootToolsCollection.Add( changeUnitButtonTool );
            layoutToolbar.Tools.AddTool( ctToolButton_ChangeUnit );
            layoutToolbar.Tools[ctToolButton_ChangeUnit].InstanceProps.IsFirstInGroup = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			return 0;
		}

		/// <summary>�c�[���{�^�����͐���ʒm�C�x���g</summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>�c�[���{�^���\������ʒm�C�x���g</summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
		#endregion

		#region PrivateMethod
		// ---------------------------------------------
		// ���C�A�E�g�c�[���o�[�֘A����
		// ---------------------------------------------
		#region LayoutToolbar
		/// <summary>
		/// ���C�A�E�g�p�c�[���{�^���쐬����
		/// </summary>
		/// <param name="rootToolsCollection">�c�[���R���N�V����</param>
		/// <param name="layoutToolbar">���C�A�E�g�p�c�[���o�[</param>
		/// <remarks>
		/// <br>Note		: ���C�A�E�g�p�̃c�[���o�[�Ƀc�[���{�^����ݒ肵�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void CreateLayoutToolButton(RootToolsCollection rootToolsCollection, UltraToolbar layoutToolbar)
		{
			// �c�[���{�^���̃C���X�^���X��
			_buttonTool_AlignToGrid			= new ButtonTool(ctToolButton_AlignToGrid);
			_buttonTool_AlignLefts			= new ButtonTool(ctToolButton_AlignLefts);
			_buttonTool_AlignCenters		= new ButtonTool(ctToolButton_AlignCenters);
			_buttonTool_AlignRights			= new ButtonTool(ctToolButton_AlignRights);
			_buttonTool_AlignTops			= new ButtonTool(ctToolButton_AlignTops);
			_buttonTool_AlignMiddles		= new ButtonTool(ctToolButton_AlignMiddles);
			_buttonTool_AlignBottoms		= new ButtonTool(ctToolButton_AlignBottoms);
			_buttonTool_MakeSameWidth		= new ButtonTool(ctToolButton_MakeSameWidth);
			_buttonTool_SizeToGrid			= new ButtonTool(ctToolButton_SizeToGrid);
			_buttonTool_MakeSameHeight		= new ButtonTool(ctToolButton_MakeSameHeight);
			_buttonTool_MakeSameSize		= new ButtonTool(ctToolButton_MakeSameSize);
			_buttonTool_MakeHorizSpaceEqual	= new ButtonTool(ctToolButton_MakeHorizSpaceEqual);
			_buttonTool_IncreaseHorizSpace	= new ButtonTool(ctToolButton_IncreaseHorizSpace);
			_buttonTool_DecreaseHorizSpace	= new ButtonTool(ctToolButton_DecreaseHorizSpace);
			_buttonTool_RemoveHorizSpace	= new ButtonTool(ctToolButton_RemoveHorizSpace);
			_buttonTool_MakeVertSpaceEqual	= new ButtonTool(ctToolButton_MakeVertSpaceEqual);
			_buttonTool_IncreaseVertSpace	= new ButtonTool(ctToolButton_IncreaseVertSpace);
			_buttonTool_DecreaseVertSpace	= new ButtonTool(ctToolButton_DecreaseVertSpace);
			_buttonTool_RemoveVertSpace		= new ButtonTool(ctToolButton_RemoveVertSpace);
			_buttonTool_CenterHoriz			= new ButtonTool(ctToolButton_CenterHoriz);
			_buttonTool_CenterVert			= new ButtonTool(ctToolButton_CenterVert);
			_buttonTool_BringToFront		= new ButtonTool(ctToolButton_BringToFront);
			_buttonTool_SendToBack			= new ButtonTool(ctToolButton_SendToBack);

			// �c�[���`�b�v�̐ݒ�
			_buttonTool_AlignToGrid.SharedProps.ToolTipText			= "�O���b�h�ɍ��킹�Đ���";
			_buttonTool_AlignLefts.SharedProps.ToolTipText			= "������";
			_buttonTool_AlignCenters.SharedProps.ToolTipText		= "�㉺��������";
			_buttonTool_AlignRights.SharedProps.ToolTipText			= "�E����";
			_buttonTool_AlignTops.SharedProps.ToolTipText			= "�㑵��";
			_buttonTool_AlignMiddles.SharedProps.ToolTipText		= "���E��������";
			_buttonTool_AlignBottoms.SharedProps.ToolTipText		= "������";
			_buttonTool_MakeSameWidth.SharedProps.ToolTipText		= "���𑵂���";
			_buttonTool_SizeToGrid.SharedProps.ToolTipText			= "�O���b�h�̃T�C�Y�ɑ�����";
			_buttonTool_MakeSameHeight.SharedProps.ToolTipText		= "�����𑵂���";
			_buttonTool_MakeSameSize.SharedProps.ToolTipText		= "�����T�C�Y�ɑ�����";
			_buttonTool_MakeHorizSpaceEqual.SharedProps.ToolTipText	= "���E�̊Ԋu���ϓ��ɂ���";
			_buttonTool_IncreaseHorizSpace.SharedProps.ToolTipText	= "���E�̊Ԋu���L������";
			_buttonTool_DecreaseHorizSpace.SharedProps.ToolTipText	= "���E�̊Ԋu����������";
			_buttonTool_RemoveHorizSpace.SharedProps.ToolTipText	= "���E�̊Ԋu���폜����";
			_buttonTool_MakeVertSpaceEqual.SharedProps.ToolTipText	= "�㉺�̊Ԋu���ϓ��ɂ���";
			_buttonTool_IncreaseVertSpace.SharedProps.ToolTipText	= "�㉺�̊Ԋu���L����";
			_buttonTool_DecreaseVertSpace.SharedProps.ToolTipText	= "�㉺�̊Ԋu����������";
			_buttonTool_RemoveVertSpace.SharedProps.ToolTipText		= "�㉺�̊Ԋu���폜����";
			_buttonTool_CenterHoriz.SharedProps.ToolTipText			= "���E��������";
			_buttonTool_CenterVert.SharedProps.ToolTipText			= "�㉺��������";
			_buttonTool_BringToFront.SharedProps.ToolTipText		= "�őO�ʂֈړ�";
			_buttonTool_SendToBack.SharedProps.ToolTipText			= "�Ŕw�ʂֈړ�";

			// �c�[���R���N�V�����ɒǉ�
			rootToolsCollection.Add(_buttonTool_AlignToGrid);
			rootToolsCollection.Add(_buttonTool_AlignLefts);
			rootToolsCollection.Add(_buttonTool_AlignCenters);
			rootToolsCollection.Add(_buttonTool_AlignRights);
			rootToolsCollection.Add(_buttonTool_AlignTops);
			rootToolsCollection.Add(_buttonTool_AlignMiddles);
			rootToolsCollection.Add(_buttonTool_AlignBottoms);
			rootToolsCollection.Add(_buttonTool_MakeSameWidth);
			rootToolsCollection.Add(_buttonTool_SizeToGrid);
			rootToolsCollection.Add(_buttonTool_MakeSameHeight);
			rootToolsCollection.Add(_buttonTool_MakeSameSize);
			rootToolsCollection.Add(_buttonTool_MakeHorizSpaceEqual);
			rootToolsCollection.Add(_buttonTool_IncreaseHorizSpace);
			rootToolsCollection.Add(_buttonTool_DecreaseHorizSpace);
			rootToolsCollection.Add(_buttonTool_RemoveHorizSpace);
			rootToolsCollection.Add(_buttonTool_MakeVertSpaceEqual);
			rootToolsCollection.Add(_buttonTool_IncreaseVertSpace);
			rootToolsCollection.Add(_buttonTool_DecreaseVertSpace);
			rootToolsCollection.Add(_buttonTool_RemoveVertSpace);
			rootToolsCollection.Add(_buttonTool_CenterHoriz);
			rootToolsCollection.Add(_buttonTool_CenterVert);
			rootToolsCollection.Add(_buttonTool_BringToFront);
			rootToolsCollection.Add(_buttonTool_SendToBack);

			// ���C�A�E�g�p�c�[���o�[�Ƀ{�^����ݒ�
			layoutToolbar.Tools.AddTool(ctToolButton_AlignToGrid);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignLefts);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignCenters);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignRights);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignTops);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignMiddles);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignBottoms);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameWidth);
			layoutToolbar.Tools.AddTool(ctToolButton_SizeToGrid);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameHeight);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameSize);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeHorizSpaceEqual);
			layoutToolbar.Tools.AddTool(ctToolButton_IncreaseHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_DecreaseHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_RemoveHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeVertSpaceEqual);
			layoutToolbar.Tools.AddTool(ctToolButton_IncreaseVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_DecreaseVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_RemoveVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_CenterHoriz);
			layoutToolbar.Tools.AddTool(ctToolButton_CenterVert);
			layoutToolbar.Tools.AddTool(ctToolButton_BringToFront);
			layoutToolbar.Tools.AddTool(ctToolButton_SendToBack);

			// �{�^���ɃA�C�R����ݒ�
			_buttonTool_AlignToGrid.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[0];
			_buttonTool_AlignLefts.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[1];
			_buttonTool_AlignCenters.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[2];
			_buttonTool_AlignRights.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[3];
			_buttonTool_AlignTops.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[4];
			_buttonTool_AlignMiddles.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[5];
			_buttonTool_AlignBottoms.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[6];
			_buttonTool_MakeSameWidth.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[7];
			_buttonTool_SizeToGrid.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[8];
			_buttonTool_MakeSameHeight.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[9];
			_buttonTool_MakeSameSize.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[10];
			_buttonTool_MakeHorizSpaceEqual.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[11];
			_buttonTool_IncreaseHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[12];
			_buttonTool_DecreaseHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[13];
			_buttonTool_RemoveHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[14];
			_buttonTool_MakeVertSpaceEqual.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[15];
			_buttonTool_IncreaseVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[16];
			_buttonTool_DecreaseVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[17];
			_buttonTool_RemoveVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[18];
			_buttonTool_CenterHoriz.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[19];
			_buttonTool_CenterVert.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[20];
			_buttonTool_BringToFront.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[21];
			_buttonTool_SendToBack.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[22];

			// �Z�p���[�^�̐ݒ�
			layoutToolbar.Tools[ctToolButton_AlignLefts].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_AlignTops].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_MakeSameWidth].InstanceProps.IsFirstInGroup		= true;
			layoutToolbar.Tools[ctToolButton_MakeHorizSpaceEqual].InstanceProps.IsFirstInGroup	= true;
			layoutToolbar.Tools[ctToolButton_MakeVertSpaceEqual].InstanceProps.IsFirstInGroup	= true;
			layoutToolbar.Tools[ctToolButton_CenterHoriz].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_BringToFront].InstanceProps.IsFirstInGroup			= true;
		}

		/// <summary>
		/// ���C�A�E�g����
		/// </summary>
		/// <param name="actionTool">�������ꂽ���C�A�E�g�{�^��</param>
		/// <remarks>
		/// <br>Note		: �������ꂽ�{�^���ɉ����ă��C�A�E�g���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ExecuteLayoutAction(string actionTool)
		{
			switch (actionTool)
			{
				case ctToolButton_AlignToGrid:
					this.designer.ExecuteAction(DesignerAction.FormatAlignToGrid); break;
				case ctToolButton_BringToFront:
					this.designer.ExecuteAction(DesignerAction.FormatOrderBringToFront); break;
				case ctToolButton_SendToBack:
					this.designer.ExecuteAction(DesignerAction.FormatOrderSendToBack); break;
				case ctToolButton_MakeSameHeight:
					this.designer.ExecuteAction(DesignerAction.FormatSizeSameHeight); break;
				case ctToolButton_MakeSameWidth:
					this.designer.ExecuteAction(DesignerAction.FormatSizeSameWidth); break;
				case ctToolButton_MakeSameSize:
					this.designer.ExecuteAction(DesignerAction.FormatSizeBoth); break;
				case ctToolButton_AlignTops:
					this.designer.ExecuteAction(DesignerAction.FormatAlignTop); break;
				case ctToolButton_AlignBottoms:
					this.designer.ExecuteAction(DesignerAction.FormatAlignBottom); break;
				case ctToolButton_AlignLefts:
					this.designer.ExecuteAction(DesignerAction.FormatAlignLeft); break;
				case ctToolButton_AlignRights:
					this.designer.ExecuteAction(DesignerAction.FormatAlignRight); break;
				case ctToolButton_AlignMiddles:
					this.designer.ExecuteAction(DesignerAction.FormatAlignMiddle); break;
				case ctToolButton_AlignCenters:
					this.designer.ExecuteAction(DesignerAction.FormatAlignCenter); break;
				case ctToolButton_SizeToGrid:
					this.designer.ExecuteAction(DesignerAction.SnapToGrid); break;
				case ctToolButton_MakeHorizSpaceEqual:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceEquallyHorizontal); break;
				case ctToolButton_IncreaseHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceIncreaseHorizontal); break;
				case ctToolButton_DecreaseHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceDecreaseHorizontal); break;
				case ctToolButton_MakeVertSpaceEqual:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceEquallyVertical); break;
				case ctToolButton_IncreaseVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceIncreaseVertical); break;
				case ctToolButton_DecreaseVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceDecreaseVertical); break;
				case ctToolButton_CenterHoriz:
					this.designer.ExecuteAction(DesignerAction.FormatCenterHorizontally); break;
				case ctToolButton_CenterVert:
					this.designer.ExecuteAction(DesignerAction.FormatCenterVertically); break;
				case ctToolButton_RemoveHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceRemoveHorizontal); break;
				case ctToolButton_RemoveVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceRemoveVertical); break;
			}
		}

		/// <summary>
		/// ���C�A�E�g�{�^�����͉ېݒ菈��
		/// </summary>
		/// <param name="toolbarModes">�c�[���o�[���[�h</param>
		/// <remarks>
		/// <br>Note		: ���C�A�E�g�{�^���̓��͐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetEnabledLayoutToolbar(LayoutToolbarModes toolbarModes)
		{
			switch (toolbarModes)
			{
				case LayoutToolbarModes.MultiControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= true;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= true;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= true;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= true;
					this._buttonTool_AlignRights.SharedProps.Enabled			= true;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= true;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= true;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= true;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= true;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.TwoControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= true;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= true;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= true;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= true;
					this._buttonTool_AlignRights.SharedProps.Enabled			= true;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= true;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= true;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.SingleControl:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= false;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= false;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= false;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= false;
					this._buttonTool_AlignRights.SharedProps.Enabled			= false;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= false;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= false;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.NoControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= false;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= false;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= false;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= false;
					this._buttonTool_AlignRights.SharedProps.Enabled			= false;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= false;
					this._buttonTool_AlignTops.SharedProps.Enabled				= false;
					this._buttonTool_BringToFront.SharedProps.Enabled			= false;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= false;
					this._buttonTool_CenterVert.SharedProps.Enabled				= false;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= false;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_SendToBack.SharedProps.Enabled				= false;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= false;
					break;
				}
			}
		}

		/// <summary>
		/// ���C�A�E�g�c�[���o�[�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���C�A�E�g�c�[���o�[�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetLayoutToolbar()
		{
			int count = this.designer.Selection.Count;
			if (count == 0)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);
			}
			else if (count == 1)
			{
				if (this.designer.Selection[0] is ar.ARControl)
					SetEnabledLayoutToolbar(LayoutToolbarModes.SingleControl);
				else
					SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);
			}
			else if (count == 2)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.TwoControls);
			}
			else if (count > 2)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.MultiControls);
			}
		}
		#endregion

		// ---------------------------------------------
		// �c�[���o�[�N���b�N�֘A����
		// ---------------------------------------------
		#region ToolbarClickProcedure
		/// <summary>
		/// �V�K�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���R���[�̐V�K�f�[�^���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void CreateNewDataProc()
		{
			// �V�K�쐬�_�C�A���O���N��
			SFANL08105UF newSheetDialog = new SFANL08105UF();
			DialogResult dlgRet = newSheetDialog.ShowNewReportInfoDialog(_frePrtPosAcs.PrtItemGrpList);
			if (dlgRet == DialogResult.OK)
			{
				// �A�N�Z�X�N���X�̐V�K�f�[�^�쐬������Call
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //int status = _frePrtPosAcs.CreateNewData(_enterpriseCode, newSheetDialog.DisplayName, newSheetDialog.SelectedPrtItemGrp);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                int status = _frePrtPosAcs.CreateNewData( _enterpriseCode, newSheetDialog.PrtFormId, newSheetDialog.DisplayName, newSheetDialog.SelectedPrtItemGrp );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.designer.Visible = false;
						try
						{
							// �V�K���|�[�g����
							_prevReportSize = 0;
							this.designer.NewReport();
							this.designer.Report.PageSettings.PaperKind	= newSheetDialog.PaperKind;
							// �e�핝���Z�b�g
							this.designer.Report.PageSettings.Orientation		= newSheetDialog.Landscape;
                            this.designer.Report.PageSettings.Margins.Top = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Right = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Left = ar.ActiveReport3.CmToInch( 1 );
							FitPageWidthProc();
							// �W���t�H���g��MS���� 10pt�ɐݒ�
							this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontName = ctDefault_FontName;
							this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontSize = ctDefault_FontSize;
							// �P�ʕϊ��ɂ�鐔�l�덷����������ׂ̏���
                            this.designer.Report.PrintWidth
                                = ar.ActiveReport3.CmToInch( (float)FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( this.designer.Report.PrintWidth ), 1 ) );
							// �^�C�v���Ƀf�t�H���g��Section���쐬
							CreateDefaultSection(newSheetDialog.SelectedPrtItemGrp.PrintPaperUseDivcd, newSheetDialog.SelectedPrtItemGrp.DataInputSystem);
						}
						finally
						{
							this.designer.Visible = true;
						}

						// ������ �ǉ����� ������
						_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.PrtItemGroupingDispTitle, this.ilARControlIcon);

						// ������ �S�̐ݒ� ������
						_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

						// ������ ���ڐݒ� ������
						_itemSettingControl.PrtItemSetList = _frePrtPosAcs.PrtItemSetList;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        _itemSettingControl.FrePrtPSet = _frePrtPosAcs.FrePrtPSet;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
						_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

						// �A�N�Z�X�N���X�Ƀf�[�^���Z�b�g
						SetDataToAccessClass();
						// �󎚈ʒu���o�b�t�@�ޔ�����
						_frePrtPosAcs.CopyPrtPosDataToBuffer();

						ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);
						
						break;
					}
					default:
					{
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u���h�c�܂��̓N���X�h�c
							_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);				// �\������{�^��
						return;
					}
				}

				_prevReportSize = this.designer.Report.PrintWidth;
				// �R�s�[�A�؂���A�A���h�D�����N���A
				this.designer.UndoManager.Clear();
			}
		}

		/// <summary>
		/// �����f�[�^�ďo������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �o�^�ς݂̎��R���[�f�[�^�����͊������C�A�E�g�̌Ăяo�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private int OpenExistingDataProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			// ���ʏ��������
			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton = false;
			try
			{
				// ���R���[�I���K�C�h
                if ( _frePprSelectGuide == null )
                {
                    _frePprSelectGuide = new FPprSearchGuide();
                    _frePprSelectGuide.PrtItemGrpList = _frePrtPosAcs.PrtItemGrpList;
                }

				// �����V�[�g�I���K�C�h���N��
				_frePprSelectGuide.ShowInTaskbar	= false;
				_frePprSelectGuide.TopLevel			= true;
				FrePrtGuideSearchRet frePrtGuideSearchRet;
				FPprSearchGuide.DialogRetCode retCode = _frePprSelectGuide.ShowFrePrtGuide(out frePrtGuideSearchRet);
				switch (retCode)
				{
					case FPprSearchGuide.DialogRetCode.FreePrt:
					case FPprSearchGuide.DialogRetCode.FreeSlip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case FPprSearchGuide.DialogRetCode.FreeDMList:
                    //case FPprSearchGuide.DialogRetCode.FreeDMPostCard:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case FPprSearchGuide.DialogRetCode.FreeDmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						// ���ʏ�������ʁi�J�n�j
						waitForm.Title      = "���R���[�󎚈ʒu�f�[�^�Ǎ���";
						waitForm.Message    = "���R���[�󎚈ʒu�f�[�^�̓Ǎ����ł��D�D�D";
						waitForm.Show();

						// �����p�����[�^���Z�b�g
						FrePrtPSet frePrtPSet = new FrePrtPSet();
						frePrtPSet.EnterpriseCode		= _enterpriseCode;
						frePrtPSet.UpdateDateTime		= frePrtGuideSearchRet.UpdateDateTime;
						frePrtPSet.OutputFormFileName	= frePrtGuideSearchRet.OutputFormFileName;
						frePrtPSet.UserPrtPprIdDerivNo	= frePrtGuideSearchRet.UserPrtPprIdDerivNo;
						frePrtPSet.FreePrtPprItemGrpCd	= frePrtGuideSearchRet.FreePrtPprItemGrpCd;

						status = _frePrtPosAcs.ReadReportInfo(frePrtPSet);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								_prevReportSize = 0;
								this.designer.NewReport();
								using (MemoryStream stream = new MemoryStream(_frePrtPosAcs.FrePrtPSet.PrintPosClassData))
								{
									this.designer.LoadReport(stream);
									stream.Close();
								}
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								// ���ʏ�������ʁi�I���j
								waitForm.Close();

								TMsgDisp.Show(
									this,								// �e�E�B���h�E�t�H�[��
									emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
									SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
									this.Text,							// �v���O��������
									"OpenExistingDataProc",				// ��������
									TMsgDisp.OPE_READ,					// �I�y���[�V����
									"���ɑ��[�����폜����Ă��܂��B",	// �\�����郁�b�Z�[�W 
									status,								// �X�e�[�^�X�l
									_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
									MessageBoxButtons.OK,				// �\������{�^��
									MessageBoxDefaultButton.Button1);	// �����\���{�^��
								break;
							}
							default:
							{
								// ���ʏ�������ʁi�I���j
								waitForm.Close();

								TMsgDisp.Show(
									this,								// �e�E�B���h�E�t�H�[��
									emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
									SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
									this.Text,							// �v���O��������
									"OpenExistingDataProc",				// ��������
									TMsgDisp.OPE_READ,					// �I�y���[�V����
									_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
									status,								// �X�e�[�^�X�l
									_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
									MessageBoxButtons.OK,				// �\������{�^��
									MessageBoxDefaultButton.Button1);	// �����\���{�^��
								break;
							}
						}
						break;
					}
					case FPprSearchGuide.DialogRetCode.PrintPaper:
					case FPprSearchGuide.DialogRetCode.Slip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case FPprSearchGuide.DialogRetCode.DMList:
                    //case FPprSearchGuide.DialogRetCode.DMPostCard:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case FPprSearchGuide.DialogRetCode.DmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						// ���ʏ�������ʃv���p�e�B�ݒ�
						waitForm.Title      = "�񋟁i�p�b�P�[�W�j�f�[�^�Ǎ���";
                        waitForm.Message    = "�񋟁i�p�b�P�[�W�j�f�[�^�̓Ǎ����ł��D�D�D";
						waitForm.Show();

						FPprSchmGrWork fPprSchmGrWork = (FPprSchmGrWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePrtGuideSearchRet, typeof(FPprSchmGrWork));
						status = _frePrtPosAcs.CreateNewData(_enterpriseCode, frePrtGuideSearchRet);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							this.designer.Visible = false;
							try
							{
								_prevReportSize = 0;
								this.designer.NewReport();
								using (MemoryStream stream = new MemoryStream(_frePrtPosAcs.FrePrtPSet.PrintPosClassData))
								{
									this.designer.LoadReport(stream);
									stream.Close();
								}
								// �W���t�H���g��MS�����ɐݒ�
								this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontName = ctDefault_FontName;
								this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontSize = ctDefault_FontSize;
								// �^�C�v���Ƀf�t�H���g��Section���쐬
								CreateDefaultSection(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd, _frePrtPosAcs.FrePrtPSet.DataInputSystem);
								switch (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd)
								{
									case (int)PrintPaperUseDivcdKind.Report:
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                                    //case (int)PrintPaperUseDivcdKind.DMReport:
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
									{
										this.designer.Report.PageSettings.Orientation = PageOrientation.Landscape;
										break;
									}
									case (int)PrintPaperUseDivcdKind.Slip:
                                    case (int)PrintPaperUseDivcdKind.DmdBill:
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
									//case (int)PrintPaperUseDivcdKind.DMPostCard:
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
									{
										this.designer.Report.PageSettings.Orientation = PageOrientation.Portrait;
										break;
									}
								}
							}
							finally
							{
								this.designer.Visible = true;
							}
						}
						else
						{
							// ���ʏ�������ʁi�I���j
							waitForm.Close();

							TMsgDisp.Show(
								this,								// �e�E�B���h�E�t�H�[��
								emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
								SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
								this.Text,							// �v���O��������
								"OpenExistingDataProc",				// ��������
								TMsgDisp.OPE_READ,					// �I�y���[�V����
								_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
								status,								// �X�e�[�^�X�l
								_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
								MessageBoxButtons.OK,				// �\������{�^��
								MessageBoxDefaultButton.Button1);	// �����\���{�^��
						}
						break;
					}
					case FPprSearchGuide.DialogRetCode.Return:
					{
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					}
					default:
					{
						// ���ʏ�������ʁi�I���j
						waitForm.Close();

						string message = "���R���[�f�[�^�̌Ăяo���Ɏ��s���܂����B";
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
							this.Text,							// �v���O��������
							"OpenExistingDataProc",				// ��������
							TMsgDisp.OPE_READ,					// �I�y���[�V����
							message,							// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
						break;
					}
				}

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// ������ �ǉ����� ������
					_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.PrtItemGroupingDispTitle, this.ilARControlIcon);

					// ������ �S�̐ݒ� ������
					_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
					_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

					// ������ ���ڐݒ� ������
					_itemSettingControl.PrtItemSetList = _frePrtPosAcs.PrtItemSetList;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    _itemSettingControl.FrePrtPSet = _frePrtPosAcs.FrePrtPSet;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
					_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

					// �A�N�Z�X�N���X�Ƀf�[�^���Z�b�g
					SetDataToAccessClass();
					// �󎚈ʒu���o�b�t�@�ޔ�����
					_frePrtPosAcs.CopyPrtPosDataToBuffer();

					ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);

					_prevReportSize = this.designer.Report.PrintWidth;
					// �R�s�[�A�؂���A�A���h�D�����N���A
					this.designer.UndoManager.Clear();

					// ���ʏ�������ʁi�I���j
					waitForm.Close();
				}
			}
			catch (Exception ex)
			{
				// ���ʏ�������ʁi�I���j
				waitForm.Close();

				string message = "���R���[�f�[�^�̌Ăяo���ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					this.Text,							// �v���O��������
					"OpenExistingDataProc",				// ��������
					TMsgDisp.OPE_READ,					// �I�y���[�V����
					message,							// �\�����郁�b�Z�[�W 
					status,								// �X�e�[�^�X�l
					_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,				// �\������{�^��
					MessageBoxDefaultButton.Button1);	// �����\���{�^��

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <param name="saveMode">�ۑ����[�h</param>
		/// <param name="isShowCompletionDlg">�ۑ�������ʕ\���t���O</param>
		/// <remarks>
		/// <br>Note		: �ۑ��������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private int SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode saveMode, bool isShowCompletionDlg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			this.designer.Focus();

			// ���ʏ��������
			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton = false;
			try
			{
				SetDataToAccessClass();

////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//				if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Report)
//				{
//					if (_frePrtPosAcs.FrePprECndList == null || _frePrtPosAcs.FrePprECndList.Count == 0)
//					{
//						TMsgDisp.Show(
//							this,								// �e�E�B���h�E�t�H�[��
//							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
//							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
//							"���o������ݒ肵�Ă��������B",		// �\�����郁�b�Z�[�W 
//							0,									// �X�e�[�^�X�l
//							MessageBoxButtons.OK);				// �\������{�^��
//
//						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
//						return status;
//					}
//				}
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
				// ���̓`�F�b�N
				string message;
				if (!InputCheck(out message))
				{
					TMsgDisp.Show(
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
						message,							// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
					return status;
				}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////

				// �쐬���������Ă��Ȃ��ꍇ�͐V�K�o�^
				if (_frePrtPosAcs.FrePrtPSet.CreateDateTime == DateTime.MinValue)
					saveMode = FrePrtPosAcs.FreeSheet_SaveMode.NewWrite;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
				// �V�K�o�^���͐V�K�o�^�����͉�ʂ��N������
                //if ( saveMode == FrePrtPosAcs.FreeSheet_SaveMode.NewWrite )
                //{
                //    SFANL08105UG saveDlg = new SFANL08105UG();
                //    DialogResult dlgRet = saveDlg.ShowNewWriteInfoDialog( _frePrtPosAcs.FrePrtPSet );
                //    if ( dlgRet != DialogResult.OK )
                //    {
                //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //        return status;
                //    }
                //    if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Slip )
                //        _frePrtPosAcs.SlipPrtKindList = saveDlg.SlipPrtKindList;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                // �o�^�ςݓ`�[����ݒ�擾����
                List<int> prevSlipPrtKindList;
                if ( saveMode != FrePrtPosAcs.FreeSheet_SaveMode.NewWrite )
                {
                    // �X�V�̏ꍇ�͓o�^�ςݓ`�[����ݒ�̃��X�g���擾����
                    prevSlipPrtKindList = this.GetPrevSlipPrtKindList( _frePrtPosAcs.FrePrtPSet.EnterpriseCode, _frePrtPosAcs.FrePrtPSet.OutputFormFileName );
                }
                else
                {
                    // �V�K�E���O�����ĕۑ��̏ꍇ�͓o�^�ςݖ����Ŕ��f
                    prevSlipPrtKindList = new List<int>();
                }

                // �ۑ��m�F�_�C�A���O�\��
                SFANL08105UG saveDlg = new SFANL08105UG();
                saveDlg.IsNewWrite = (saveMode == FrePrtPosAcs.FreeSheet_SaveMode.NewWrite);
                saveDlg.SlipPrtKindList.AddRange( prevSlipPrtKindList );
                DialogResult dlgRet = saveDlg.ShowNewWriteInfoDialog( _frePrtPosAcs.FrePrtPSet );
                if ( dlgRet != DialogResult.OK )
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return status;
                }

                // �����o�^����`�[��ʃ��X�g
                if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Slip )
                {
                    // (�`�[)
                    List<int> slipKindList = new List<int>();

                    foreach ( int slipKind in saveDlg.SlipPrtKindList )
                    {
                        // ����ǉ�����镪���������X�g�ɒǉ�����
                        if ( !prevSlipPrtKindList.Contains( slipKind ) )
                        {
                            slipKindList.Add( slipKind );
                        }
                    }
                    _frePrtPosAcs.SlipPrtKindList = slipKindList;
                }
                else if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.DmdBill )
                {
                    // (������)
                    List<int> prevDmdPrtPtnList = GetPrevDmdPrtPtnList( _frePrtPosAcs.FrePrtPSet.EnterpriseCode, _frePrtPosAcs.FrePrtPSet.OutputFormFileName );

                    List<int> slipKindList = new List<int>();
                    if ( !prevDmdPrtPtnList.Contains( _frePrtPosAcs.FrePrtPSet.FreePrtPprSpPrpseCd ) )
                    {
                        slipKindList.Add( _frePrtPosAcs.FrePrtPSet.FreePrtPprSpPrpseCd );
                    }
                    _frePrtPosAcs.SlipPrtKindList = slipKindList;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                ////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
                //				else
                //				{
                //					// �S�̐ݒ�̓��̓`�F�b�N
                //					Control control;
                //					string message;
                //					if (!_allSettingControl.InputCheck(out message, out control))
                //					{
                //						DialogResult dlgRet = TMsgDisp.Show(
                //							this,								// �e�E�B���h�E�t�H�[��
                //							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                //							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u���h�c�܂��̓N���X�h�c
                //							message,							// �\�����郁�b�Z�[�W 
                //							0,									// �X�e�[�^�X�l
                //							MessageBoxButtons.OK);				// �\������{�^��
                //						control.Focus();
                //						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //						return status;
                //					}
                //				}
                // 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////

				// ���ʏ�������ʁi�N���j
				waitForm.Title = "���R���[�󎚈ʒu�f�[�^�ۑ���";
				waitForm.Message = "���R���[�󎚈ʒu�f�[�^�̕ۑ����ł��D�D�D";
				waitForm.Show();

				// �����[�e�B���O
				status = _frePrtPosAcs.WriteDBFrePrtPSet(saveMode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// ������ �S�̐ݒ� ������
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

						ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);

						// �A�N�Z�X�N���X�Ƀf�[�^���Z�b�g
						SetDataToAccessClass();
						// �󎚈ʒu���o�b�t�@�ޔ�����
						_frePrtPosAcs.CopyPrtPosDataToBuffer();

						// ���ʏ�������ʁi�I���j
						waitForm.Close();
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						// ���ʏ�������ʁi�I���j
						waitForm.Close();

						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
							_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);				// �\������{�^��
						break;
					}
					default:
					{
						// ���ʏ�������ʁi�I���j
						waitForm.Close();

						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
							this.Text,							// �v���O��������
							"SaveDataProc",						// ��������
							TMsgDisp.OPE_INSERT,				// �I�y���[�V����
							_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��
						break;
					}
				}
			}
			catch (Exception ex)
			{
				// ���ʏ�������ʁi�I���j
				waitForm.Close();

				string message = "���R���[�󎚈ʒu�f�[�^�ۑ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					this.Text,							// �v���O��������
					"SaveDataProc",						// ��������
					TMsgDisp.OPE_INSERT,				// �I�y���[�V����
					message,							// �\�����郁�b�Z�[�W 
					status,								// �X�e�[�^�X�l
					_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,				// �\������{�^��
					MessageBoxDefaultButton.Button1);	// �����\���{�^��

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isShowCompletionDlg)
				{
					SaveCompletionDialog compDialog = new SaveCompletionDialog();
					compDialog.ShowDialog(2);
				}
			}
			return status;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// �o�^�ςݓ`�[��ʃ��X�g�擾�����i�`�[�j
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="outputFormFileName"></param>
        /// <returns></returns>
        private List<int> GetPrevSlipPrtKindList( string enterpriseCode, string outputFormFileName )
        {
            List<int> slipKindList = new List<int>();
            ArrayList retList;
            
            int status = _slipPrtSetAcs.SearchAllSlipPrtSet( out retList, enterpriseCode );
            if ( status == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is SlipPrtSet )
                    {
                        if ( (obj as SlipPrtSet).OutputFormFileName.Trim() == outputFormFileName.Trim() )
                        {
                            slipKindList.Add( (obj as SlipPrtSet).SlipPrtKind );
                        }
                    }
                }
            }

            return slipKindList;
        }
        /// <summary>
        /// �o�^�ςݓ`�[��ʃ��X�g�擾�����i�������j
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="ouputFormFileName"></param>
        /// <returns></returns>
        private List<int> GetPrevDmdPrtPtnList( string enterpriseCode, string ouputFormFileName )
        {
            List<int> slipKindList = new List<int>();
            ArrayList retList;

            int status = _dmdPrtPtnAcs.SearchAll( out retList, enterpriseCode );
            if ( status == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is DmdPrtPtn )
                    {
                        if ( (obj as DmdPrtPtn).OutputFormFileName.Trim() == ouputFormFileName.Trim() )
                        {
                            slipKindList.Add( (obj as DmdPrtPtn).SlipPrtKind );
                        }
                    }
                }
            }

            return slipKindList;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		/// <summary>
		/// �����������
		/// </summary>
		/// <remarks>30
		/// <br>Note		: �݌v���̃��C�A�E�g�̎���������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void PrintProc()
		{
			try
			{
				SetDataToAccessClass();

				using (MemoryStream stream = new MemoryStream((_frePrtPosAcs.FrePrtPSet.PrintPosClassData)))
				{
					ar.ActiveReport3 rpt = new ar.ActiveReport3();
					rpt.LoadLayout(stream);
					stream.Close();
				}

				SFANL08205C printInfo = new SFANL08205C();
				printInfo.InportFrePrtPSet(_frePrtPosAcs.FrePrtPSet, _enterpriseCode, SFANL08105UH.ctASSEMBLY_ID, null, null, true);

				using (MemoryStream stream = new MemoryStream((_frePrtPosAcs.FrePrtPSet.PrintPosClassData)))
				{
					ar.ActiveReport3 rpt = new ar.ActiveReport3();
					rpt.LoadLayout(stream);
					stream.Close();
				}
				SFANL08203U dmyPrintDlg = new SFANL08203U();
				dmyPrintDlg.PrintInfo = printInfo;
				Bitmap bitmap = null;
				if (_frePrtPosAcs.WaterMark != null)
					bitmap = new Bitmap(_frePrtPosAcs.WaterMark);

				switch (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd)
				{
					case (int)PrintPaperUseDivcdKind.Report:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case (int)PrintPaperUseDivcdKind.DMReport:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
					{
						dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 30, bitmap);
						break;
					}
					case (int)PrintPaperUseDivcdKind.Slip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case (int)PrintPaperUseDivcdKind.DmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						if (_frePrtPosAcs.FrePrtPSet.FormFeedLineCount > 0)
							dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, _frePrtPosAcs.FrePrtPSet.FormFeedLineCount, bitmap);
						else
							dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 30, bitmap);
						break;
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case (int)PrintPaperUseDivcdKind.DMPostCard:
                    //{
                    //    dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 1, bitmap);
                    //    break;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				}
			}
			catch (ar.ReportException rptEx)
			{
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					this.Text,							// �v���O��������
					"PrintProc",						// ��������
					TMsgDisp.OPE_PRINT,					// �I�y���[�V����
					rptEx.Message,						// �\�����郁�b�Z�[�W 
					-1,									// �X�e�[�^�X�l
					null,								// �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,				// �\������{�^��
					MessageBoxDefaultButton.Button1);	// �����\���{�^��
			}
			catch (Exception ex)
			{
				string message = "���R���[�f�[�^�̎�����������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					this.Text,							// �v���O��������
					"PrintProc",						// ��������
					TMsgDisp.OPE_PRINT,					// �I�y���[�V����
					message,							// �\�����郁�b�Z�[�W 
					-1,									// �X�e�[�^�X�l
					null,								// �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,				// �\������{�^��
					MessageBoxDefaultButton.Button1);	// �����\���{�^��
			}
		}

		/// <summary>
		/// ���o�����ݒ�K�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���o�����ݒ�K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowExecuteExtractionConditionGuide()
		{
			SFANL08130UA extrSetting = new SFANL08130UA();

			// ���o�����ݒ��ʂ��N��
			DialogResult dlgRet = extrSetting.ShowFrePprECndSetting(_frePrtPosAcs.FrePprECndList, _frePrtPosAcs.FrePExCndDList, _frePrtPosAcs.PrtItemSetList);
			if (dlgRet == DialogResult.OK)
			{
				_frePrtPosAcs.FrePprECndList = extrSetting.UseFrePprECndList;
			}
		}

		/// <summary>
		/// �\�[�g���ʃK�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �\�[�g���ʐݒ�K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowSortSetting()
		{
			SFANL08131UB sortSetting = new SFANL08131UB();

			DialogResult dlgRet = sortSetting.ShowSortOderSetting(_frePrtPosAcs.FrePprSrtOList);
		}

		/// <summary>
		/// �p�����œK������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �p������K���T�C�Y�ɒ������܂��B</br>
		/// <br>			: ��ActiveReport�͍����̗\��������ׁA���̂ݐݒ肵�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void FitPageWidthProc()
		{
			// �J�X�^���p���T�C�Y�̏ꍇ�͏������Ȃ�
			if (this.designer.Report.PageSettings.PaperKind == System.Drawing.Printing.PaperKind.Custom) return;

			if (this.designer.Report.PageSettings.Orientation == PageOrientation.Landscape)
			{
				this.designer.Report.PrintWidth
					= this.designer.Report.PageSettings.PaperHeight
					- this.designer.Report.PageSettings.Margins.Left
					- this.designer.Report.PageSettings.Margins.Right;
			}
			else
			{
				this.designer.Report.PrintWidth
					= this.designer.Report.PageSettings.PaperWidth
					- this.designer.Report.PageSettings.Margins.Left
					- this.designer.Report.PageSettings.Margins.Right;
			}

			// �P�ʕϊ��ɂ�鐔�l�덷����������ׂ̏���
            this.designer.Report.PrintWidth
                = ar.ActiveReport3.CmToInch( (float)FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( this.designer.Report.PrintWidth ), 1 ) );
		}

		/// <summary>
		/// �I������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �f�U�C���̏I�����̏������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private DialogResult ExitDataEditProc(ExitMode exitMode)
		{
			DialogResult dlgRet = DialogResult.Yes;

			if (exitMode == ExitMode.Close)
				_canClose = true;

			// ��ʂ̓��e���A�N�Z�X�N���X�ɃZ�b�g
			if (this.designer.Enabled)
				SetDataToAccessClass();

			// �ύX�`�F�b�N
			if (_frePrtPosAcs.CheckDataChange())
			{
				dlgRet = DialogResult.Cancel;

				dlgRet = TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					"",									// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);		// �\������{�^��
				switch (dlgRet)
				{
					case DialogResult.Yes:
					{
						if (SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.OverWrite, false) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							dlgRet = DialogResult.Cancel;
							_canClose = false;
						}
						break;
					}
					case DialogResult.Cancel:
					{
						if (exitMode == ExitMode.Close)
							_canClose = false;
						break;
					}
				}
			}

			// �I�����̃��O���o��
			if (exitMode == ExitMode.Close && _canClose) _frePrtPosAcs.WriteLog(_enterpriseCode, "FrePrtPos Edit End");

			return dlgRet;
		}
		#endregion

		// ---------------------------------------------
		// Script�֘A����
		// ---------------------------------------------
		#region Script
		/// <summary>
		/// Script�쐬����
		/// </summary>
		/// <returns>C# Script�R�[�h</returns>
		/// <remarks>
		/// <br>Note		: �f�U�C����ʂ̓��e���Script���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string CreateScript()
		{
			StringBuilder script = new StringBuilder();
			
			// --------------------------------------
			// PrivateMember�̒�`
			// --------------------------------------
			#region PrivateMember�̒�`
			script.AppendLine("private int _beforePrtRowNumInPage = 1;");
			script.AppendLine("private int _prevPageNumber = 1;");
			script.AppendLine("private int _detailFormatCount = 0;");
			script.AppendLine("private int _pageStartDataIndex = 0;");
			script.AppendLine("private bool _isGroupKeyBreak = false;");
			script.AppendLine("private object _groupKeyObj = null;");
			script.AppendLine("private System.Data.DataSet _ds;");
			// ���y�[�W�̔�������GroupHeader���ڂ̃L�[���X�g
			script.AppendLine("private System.Collections.Generic.List<string> _groupKeyList;");
			// �t�H���g�k�����̃f�t�H���g�t�H���g���
			if (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd == 2)
				script.AppendLine("private System.Collections.Generic.Dictionary<string, System.Drawing.Font> _defFontList;");
			// �������f�[�^��DataField�i�y�[�W�w�b�_�[�p�j
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _pageHeaderDataFieldList;");
			// �������f�[�^��DataField�i�y�[�W�t�b�^�[�p�j
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _pageFooterDataFieldList;");
			// �������f�[�^��DataField�i���|�[�g�t�b�^�[�p�j
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _reportFooterDataFieldList;");
			// WordWrap=false,CanGrow=true,MultiLine=true ���ڂ̕��ێ��p
			script.AppendLine("private System.Collections.Generic.Dictionary<string, float> _wordWrapCtrlWidthList;");
			// �Ԋ|�����ڂ̓��e�o�b�t�@�p
			script.AppendLine("private bool _isAlternate;");
			script.AppendLine("private System.Collections.Generic.Dictionary<string, System.Drawing.Color> _dtlColorBuf;");
			script.AppendLine("private System.Drawing.Color _dtlColorAlt = System.Drawing.Color.FromArgb("
				+ _frePrtPosAcs.FrePrtPSet.RDetailBackColor + ","
				+ _frePrtPosAcs.FrePrtPSet.GDetailBackColor + ","
				+ _frePrtPosAcs.FrePrtPSet.BDetailBackColor + ");");
			// �O���[�v�T�v���X�p
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _suppressBuf;");
			// ���׍��������p
			script.AppendLine("private System.Collections.Generic.List<ARControl> _heightAdjustList;");
			// ���t�󎚗p
			script.AppendLine("private System.DateTime _nowDateTime;");
			#endregion

			// --------------------------------------
			// ReportStart�C�x���g
			// --------------------------------------
			#region ReportStart�C�x���g
			script.AppendLine(string.Empty);	// �e�C�x���g�̑O�ɂ͉��s������i���O�Q�Ǝ��̉ǐ�����ׁ̈j
			script.AppendLine("public void ActiveReport_ReportStart(){");
			script.AppendLine("try{");
			script.AppendLine("_ds = (System.Data.DataSet)rpt.DataSource;");
			script.AppendLine(string.Empty);
			// �ȉ�DataDynamics���u�d�l�ł��v�œ˂��Ԃ��Ă����s��𒲐�����ׂ̃��W�b�N
			//  ��_��      �ڂ��ڂ��ɂ��Ă���
			// ( ��֥)���߂�
			// (�� �߂���
			// /    ) ��������
			// (/�P��
			script.AppendLine("_pageHeaderDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine("_pageFooterDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine("_reportFooterDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine(string.Empty);
			script.AppendLine("foreach (Section wkSection in rpt.Sections){");
			script.AppendLine("System.Collections.Generic.Dictionary<string, string> wkDictionary = null;");
			script.AppendLine("if (wkSection is PageHeader){");
			script.AppendLine("wkDictionary = _pageHeaderDataFieldList;");
			script.AppendLine("}");
			script.AppendLine("else if (wkSection is PageFooter){");
			script.AppendLine("wkDictionary = _pageFooterDataFieldList;");
			script.AppendLine("}");
			script.AppendLine("else if (wkSection is ReportFooter){");
			script.AppendLine("wkDictionary = _reportFooterDataFieldList;");
			script.AppendLine("}");
			script.AppendLine(string.Empty);
			script.AppendLine("if (wkDictionary != null){");
			script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
			script.AppendLine("if (wkCtrl is TextBox && !string.IsNullOrEmpty(((TextBox)wkCtrl).DataField)){");
			script.AppendLine("if (((TextBox)wkCtrl).SummaryType == SummaryType.None){");
			script.AppendLine("wkDictionary[((TextBox)wkCtrl).Name] = ((TextBox)wkCtrl).DataField;");
			script.AppendLine("((TextBox)wkCtrl).DataField = string.Empty;");
			script.AppendLine("((TextBox)wkCtrl).Text = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Label && !string.IsNullOrEmpty(((Label)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Label)wkCtrl).Name] = ((Label)wkCtrl).DataField;");
			script.AppendLine("((Label)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Picture && !string.IsNullOrEmpty(((Picture)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Picture)wkCtrl).Name] = ((Picture)wkCtrl).DataField;");
			script.AppendLine("((Picture)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Barcode && !string.IsNullOrEmpty(((Barcode)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Barcode)wkCtrl).Name] = ((Barcode)wkCtrl).DataField;");
			script.AppendLine("((Barcode)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");
			// �����܂�DataDynamics���u�d�l�ł��v�œ˂��Ԃ��Ă����s��𒲐�����ׂ̃��W�b�N
			script.AppendLine(string.Empty);

			// �t�H���g�k�����̃f�t�H���g�t�H���g�����擾
			if (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd == 2)
			{
				script.AppendLine("_defFontList = new System.Collections.Generic.Dictionary<string, System.Drawing.Font>();");
				script.AppendLine("foreach (Section wkSection in rpt.Sections){");
				script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
				script.AppendLine("if (wkCtrl is TextBox)");
				script.AppendLine("_defFontList[((TextBox)wkCtrl).Name] = ((TextBox)wkCtrl).Font;");
				script.AppendLine("else if (wkCtrl is Label)");
				script.AppendLine("_defFontList[((Label)wkCtrl).Name] = ((Label)wkCtrl).Font;");
				script.AppendLine("}");
				script.AppendLine("}");
			}
			// WordWrap=false,CanGrow=true,MultiLine=true�̃o�O�C���p
			script.AppendLine("_wordWrapCtrlWidthList = new System.Collections.Generic.Dictionary<string, float>();");
			script.AppendLine("foreach (Section wkSection in rpt.Sections){");
			script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
			script.AppendLine("if (wkCtrl is TextBox){");
			script.AppendLine("TextBox wrapBugTextBox = (TextBox)wkCtrl;");
			script.AppendLine("if (!wrapBugTextBox.WordWrap && wrapBugTextBox.CanGrow && wrapBugTextBox.MultiLine)");
			script.AppendLine("_wordWrapCtrlWidthList[wrapBugTextBox.Name] = wrapBugTextBox.Width;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");

			script.AppendLine("if (_groupKeyList == null) _groupKeyList = new System.Collections.Generic.List<string>();");
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (section is ar.Detail)
				{
					// �Ԋ|��
					script.AppendLine("_dtlColorBuf = new System.Collections.Generic.Dictionary<string, System.Drawing.Color>();");
					// �O���[�v�T�v���X
					script.AppendLine("_suppressBuf = new System.Collections.Generic.Dictionary<string, string>();");
					// ���׍�������
					script.AppendLine("_heightAdjustList = new System.Collections.Generic.List<ARControl>();");
					foreach (ar.ARControl aRControl in section.Controls)
					{
						// ���ׂɂČ��݂ɐF��ς���R���g���[���̖��O�ƃf�t�H���g�F���擾
						PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
						if (prtItemSetWork != null)
						{
							if (prtItemSetWork.DtlColorChangeCd == 1)
							{
								if (aRControl is ar.TextBox)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Label)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Shape)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Shape)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Picture)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Picture)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Barcode)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Barcode)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
							}

							// �O���[�v�T�v���X�̃R���g���[�����擾
							if (prtItemSetWork.GroupSuppressCd == 1)
							{
								if (aRControl is ar.TextBox)
									script.AppendLine("_suppressBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = string.Empty;");
							}

							// ���׍��������̃R���g���[�����擾
							if (prtItemSetWork.HeightAdjustDivCd == 1)
								script.AppendLine("_heightAdjustList.Add(rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]);");
						}
					}
				}
				else if (section is ar.GroupHeader)
				{
					ar.GroupHeader wkGroupHeader = (ar.GroupHeader)section;
					if (!string.IsNullOrEmpty(wkGroupHeader.DataField) && wkGroupHeader.NewPage != ar.NewPage.None && wkGroupHeader.Visible)
						script.AppendLine("_groupKeyList.Add(\"" + wkGroupHeader.DataField + "\");");
				}
			}
			script.AppendLine("}catch(System.Exception ex){");
			script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
			script.AppendLine("}");
			script.AppendLine("}");
			#endregion

			// --------------------------------------
			// PageStart�C�x���g
			// --------------------------------------
			#region PageStart�C�x���g
			script.AppendLine(string.Empty);	// �e�C�x���g�̑O�ɂ͉��s������i���O�Q�Ǝ��̉ǐ�����ׁ̈j
			script.AppendLine("public void ActiveReport_PageStart(){");
			script.AppendLine("try{");
			// �O���[�v�T�v���X�p�o�b�t�@���N���A
			script.AppendLine("foreach (string key in _suppressBuf.Keys)");
			script.AppendLine("_suppressBuf[key] = string.Empty;");
			// ���݂̓������擾
			script.AppendLine("_nowDateTime = System.DateTime.Now;");
			// GroupHeader��KeyBreak���������Ă��邩�H
			script.AppendLine("if (_isGroupKeyBreak){");
			// Format�񐔂�BeforePrint�̉񐔂��������Ă��邩�`�F�b�N
			script.AppendLine("if (_detailBeforePrintCount == _detailFormatCount){");
			script.AppendLine("_pageStartDataIndex = _detailFormatCount;");
			script.AppendLine("_isGroupKeyBreak = false;");
			script.AppendLine("}else{");
			// �������Ă��Ȃ��ꍇ�͗p�����I�[�o�[�ɂ����ł��������Ă���
			script.AppendLine("_pageStartDataIndex = _detailFormatCount - 1;");
			script.AppendLine("}");
			script.AppendLine("}else{");
			script.AppendLine("if (_detailFormatCount > 0)");
			script.AppendLine("_pageStartDataIndex = _detailFormatCount - 1;");
			script.AppendLine("else");
			script.AppendLine("_pageStartDataIndex = 0;");
			script.AppendLine("}");
			script.AppendLine("}catch(System.Exception ex){");
			script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
			script.AppendLine("}");
			script.AppendLine("}");
			#endregion

			script.AppendLine("private int _detailBeforePrintCount = 0;");
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				// �󎚃y�[�W����p
				List<string> firstPageOnly = new List<string>();
				List<string> lastPageOnly = new List<string>();

				foreach (ar.ARControl aRControl in section.Controls)
				{
					PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
					if (prtItemSetWork != null)
					{
						// �󎚃y�[�W����敪(0:�S�y�[�W,1:1�y�[�W�ڂ̂�,2:�ŏI�y�[�W�̂�)
						switch (prtItemSetWork.PrintPageCtrlDivCd)
						{
							case 1: firstPageOnly.Add(aRControl.Name); break;
							case 2: if (section is ar.GroupFooter) lastPageOnly.Add(aRControl.Name); break;
						}
					}
				}

				// --------------------------------------
				// Format�C�x���g
				// --------------------------------------
				#region Format�C�x���g
				script.AppendLine(string.Empty);	// �e�C�x���g�̑O�ɂ͉��s������i���O�Q�Ǝ��̉ǐ�����ׁ̈j
				script.AppendLine("public void " + section.Name + "_Format(){");
				script.AppendLine("try{");
				if (section is ar.Detail)
				{
					// �O���[�v�T�v���X
					script.AppendLine("System.Collections.Generic.List<string> keyList = new System.Collections.Generic.List<string>();");
					script.AppendLine("foreach (string ctrlName in _suppressBuf.Keys) keyList.Add(ctrlName);");
					script.AppendLine("foreach (string ctrlName in keyList){");
					script.AppendLine("ARControl wkControl = rpt.Sections[\"" + section.Name + "\"].Controls[ctrlName];");
					script.AppendLine("if (wkControl is TextBox){");
					script.AppendLine("if (((TextBox)wkControl).Text == _suppressBuf[ctrlName]){");
					script.AppendLine("((TextBox)wkControl).Text = string.Empty;");
					script.AppendLine("}else{");
					script.AppendLine("_suppressBuf[ctrlName] = ((TextBox)wkControl).Text;");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("_detailFormatCount++;");
					// ���̃f�[�^���ǂ݂���GroupHeader��KeyBreak�����ɍ��v���邩���f
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Rows.Count > _detailFormatCount){");
					script.AppendLine("foreach (string groupKey in _groupKeyList){");
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Columns.Contains(groupKey)){");
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Rows[_detailFormatCount-1][groupKey] != _ds.Tables[rpt.DataMember].Rows[_detailFormatCount][groupKey])");
					script.AppendLine("_isGroupKeyBreak = true;");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("}");
				}

				// �ȉ�DataDynamics���u�d�l�ł��v�œ˂��Ԃ��Ă����s��𒲐�����ׂ̃��W�b�N
				//  ��_��      ���R���R�ɂ��Ă���
				// ( ��֥)���߂�
				// (�� �߂���
				// /    ) ��������
				// (/�P��
				//
				//   /�R /�R
				//  ':'''"`':,�@�@
				// �~  �E�ցE ;,
				// :;.��     ,��
				// `:;     ,;'  ���R�b
				//   `(/'"`��
				// PageHeader��PageFooter�ɕϓ�����f�[�^���󎚂���ꍇ
				// ���œ��ň󎚂��ׂ�Index������A����Ɉ󎚂���Ȃ���
				// ���ڃf�[�^���Z�b�g����
				if (section is ar.PageHeader || section is ar.PageFooter || section is ar.ReportFooter)
				{
					StringBuilder templete = new StringBuilder();
					templete.AppendLine("foreach (ARControl control in rpt.Sections[\"" + section.Name + "\"].Controls){");
					// TextBox�̏ꍇ
					templete.AppendLine("if (control is TextBox){");
					templete.AppendLine("TextBox textBox = (TextBox)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(textBox.Name)) continue;");
					templete.AppendLine("if (textBox.SummaryType == SummaryType.None){");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[textBox.Name])){");
					templete.AppendLine("textBox.Value = dr[<DictionaryName>[textBox.Name]];");
					templete.AppendLine("}");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// Label�̏ꍇ
					templete.AppendLine("else if (control is Label){");
					templete.AppendLine("Label label = (Label)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(label.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[label.Name])){");
					templete.AppendLine("label.Text = dr[<DictionaryName>[label.Name]].ToString();");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// Picture�̏ꍇ
					templete.AppendLine("else if (control is Picture){");
					templete.AppendLine("Picture picture = (Picture)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(picture.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[picture.Name])){");
					templete.AppendLine("if (dr[<DictionaryName>[picture.Name]] is System.Drawing.Image)");
					templete.AppendLine("picture.Image = (System.Drawing.Image)dr[<DictionaryName>[picture.Name]];");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// BarCode�̏ꍇ
					templete.AppendLine("else if (control is Barcode){");
					templete.AppendLine("Barcode barcode = (Barcode)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(barcode.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[barcode.Name])){");
					templete.AppendLine("barcode.Text = dr[<DictionaryName>[barcode.Name]].ToString();");
					templete.AppendLine("}");
					templete.AppendLine("}");
					templete.AppendLine("}");

					script.AppendLine("System.Data.DataTable dt = _ds.Tables[rpt.DataMember];");
					if (section is ar.ReportFooter)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[dt.Rows.Count-1];");
						templete.Replace("<DictionaryName>", "_reportFooterDataFieldList");
					}
					else if (section is ar.PageHeader)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[_pageStartDataIndex];");
						templete.Replace("<DictionaryName>", "_pageHeaderDataFieldList");
					}
					else if (section is ar.PageFooter)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[_pageStartDataIndex];");
						templete.Replace("<DictionaryName>", "_pageFooterDataFieldList");
					}
					script.AppendLine(templete.ToString());
				}
				// �����܂�DataDynamics���u�d�l�ł��v�œ˂��Ԃ��Ă����s��𒲐�����ׂ̃��W�b�N

				// �[���������敪(1:�[�����؎̂�,2:�t�H���g�k��)
				switch (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd)
				{
					case 1:
					{
						script.AppendLine("foreach (ARControl edgeCharCtrl in rpt.Sections[\"" + section.Name + "\"].Controls){");
						script.AppendLine("if (edgeCharCtrl is TextBox){");
						script.AppendLine("if (!((TextBox)edgeCharCtrl).WordWrap)");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.ConvertReportString(edgeCharCtrl);");
						script.AppendLine("}");
						script.AppendLine("if (edgeCharCtrl is Label){");
						script.AppendLine("if (!((Label)edgeCharCtrl).WordWrap)");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.ConvertReportString(edgeCharCtrl);");
						script.AppendLine("}");
						script.AppendLine("}");
						break;
					}
					case 2:
					{
						script.AppendLine("for (int ix = 0 ; ix != rpt.Sections[\"" + section.Name + "\"].Controls.Count ; ix++){");
						script.AppendLine("ARControl edgeCharCtrl = rpt.Sections[\"" + section.Name + "\"].Controls[ix];");
						script.AppendLine("if (edgeCharCtrl is TextBox){");
						script.AppendLine("if (!((TextBox)edgeCharCtrl).WordWrap){");
						script.AppendLine("((TextBox)edgeCharCtrl).Font = _defFontList[((TextBox)edgeCharCtrl).Name];");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.AdjustControlFontSize(ref edgeCharCtrl, ((TextBox)edgeCharCtrl).Font);");
						script.AppendLine("}");
						script.AppendLine("}");
						script.AppendLine("else if (edgeCharCtrl is Label){");
						script.AppendLine("if (!((Label)edgeCharCtrl).WordWrap){");
						script.AppendLine("((Label)edgeCharCtrl).Font = _defFontList[((Label)edgeCharCtrl).Name];");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.AdjustControlFontSize(ref edgeCharCtrl, ((Label)edgeCharCtrl).Font);");
						script.AppendLine("}");
						script.AppendLine("}");
						script.AppendLine("}");
						break;
					}
				}

				// WordWrap=false,CanGrow=true,MultiLine=true�̃o�O�C���p
				script.AppendLine("foreach (ARControl wrapBugCtrl in rpt.Sections[\"" + section.Name + "\"].Controls){");
				script.AppendLine("if (wrapBugCtrl is TextBox){");
				script.AppendLine("TextBox wrapBugTextBox = (TextBox)wrapBugCtrl;");
				script.AppendLine("if (!wrapBugTextBox.WordWrap && wrapBugTextBox.CanGrow && wrapBugTextBox.MultiLine)");
				script.AppendLine("wrapBugTextBox.Width = float.MaxValue;");
				script.AppendLine("}");
				script.AppendLine("}");

				bool isAppendextrTextBox = false;
				bool isAppendtxtFooter1 = false;
				bool isAppendtxtFooter2 = false;
				bool isAppendtxtSort1 = false;
				bool isAppendtxtSort2 = false;
				bool isAppendtxtSort3 = false;
				bool isAppendtxtSort4 = false;
				bool isAppendtxtSort5 = false;
				foreach (ar.ARControl aRControl in section.Controls)
				{
					// �`�[���C�A�E�g�Őԓ`�敪�̔�\������
					if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 2)
					{
						if (aRControl.DataField == "AcceptOdrRF.DebitNoteDivRF")
						{
							script.AppendLine("if (rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"] is TextBox){");
							script.AppendLine("if (string.IsNullOrEmpty(((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text))");
							script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Visible = false;");
							script.AppendLine("}");
							script.AppendLine("else if (rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"] is Label){");
							script.AppendLine("if (string.IsNullOrEmpty(((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text))");
							script.AppendLine("((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Visible = false;");
							script.AppendLine("}");
						}
					}

					PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
					if (prtItemSetWork != null)
					{
						switch (prtItemSetWork.FreePrtPaperItemCd)
						{
							case (int)FreePrtPaperItemCdKind.ExtrCondition:
							{
								// ���o�����p���i��ʂ�
								if (!isAppendextrTextBox)
								{
									script.AppendLine("TextBox extrTextBox = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendextrTextBox = true;
								}
								else
								{
									script.AppendLine("extrTextBox = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("Broadleaf.Application.Common.SFANL08235CE.SetExrCndTextBox(ref extrTextBox, _ds);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.CommonFooter1:	// ���ʃt�b�^�[1
							{
								if (!isAppendtxtFooter1)
								{
									script.AppendLine("TextBox txtFooter1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtFooter1 = true;
								}
								else
								{
									script.AppendLine("txtFooter1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtFooter1.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_PFTR_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_PRINTFOOTER1 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.CommonFooter2:	// ���ʃt�b�^�[2
							{
								if (!isAppendtxtFooter2)
								{
									script.AppendLine("TextBox txtFooter2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtFooter2 = true;
								}
								else
								{
									script.AppendLine("txtFooter2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtFooter2.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_PFTR_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_PRINTFOOTER2 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateAdFormal:	// ���t�̈���i����j
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"YYYY/mm/dd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateJpFormal:	// ���t�̈���i�a��j
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"GGyymmdd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateJpAbbr:	// ���t�̈���i�a��E���j
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"ggyy.mm.dd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.TimeAdFormal:	// ���Ԃ̈��
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"HH:MM\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.TimeJpFormal:	// ���Ԃ̈��
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"HHMM\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder1:	// �\�[�g����1
							{
								if (!isAppendtxtSort1)
								{
									script.AppendLine("TextBox txtSort1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort1 = true;
								}
								else
								{
									script.AppendLine("txtSort1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort1.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER1 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder2:	// �\�[�g����2
							{
								if (!isAppendtxtSort2)
								{
									script.AppendLine("TextBox txtSort2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort2 = true;
								}
								else
								{
									script.AppendLine("txtSort2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort2.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER2 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder3:	// �\�[�g����3
							{
								if (!isAppendtxtSort3)
								{
									script.AppendLine("TextBox txtSort3 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort3 = true;
								}
								else
								{
									script.AppendLine("txtSort3 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort3.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER3 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder4:	// �\�[�g����4
							{
								if (!isAppendtxtSort4)
								{
									script.AppendLine("TextBox txtSort4 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort4 = true;
								}
								else
								{
									script.AppendLine("txtSort4 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort4.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER4 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder5:	// �\�[�g����5
							{
								if (!isAppendtxtSort5)
								{
									script.AppendLine("TextBox txtSort5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort5 = true;
								}
								else
								{
									script.AppendLine("txtSort5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort5.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER5 + "\"].ToString();");
								break;
							}
						}
					}
				}

				script.AppendLine("}catch(System.Exception ex){");
				script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
				script.AppendLine("}");
				script.AppendLine("}");
				#endregion

				// --------------------------------------
				// BeforePrint�C�x���g
				// --------------------------------------
				#region BeforePrint�C�x���g
				script.AppendLine(string.Empty);	// �e�C�x���g�̑O�ɂ͉��s������i���O�Q�Ǝ��̉ǐ�����ׁ̈j
				script.AppendLine("public void " + section.Name + "_BeforePrint(){");
				script.AppendLine("try{");
				if (firstPageOnly.Count > 0)
				{
					script.AppendLine("if (rpt.PageNumber != 1){");
					foreach (string aRControlName in firstPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = false;");
					script.AppendLine("}");
				}

				if (lastPageOnly.Count > 0)
				{
					script.AppendLine("if (_detailFormatCount == _ds.Tables[rpt.DataMember].Rows.Count){");
					foreach (string aRControlName in lastPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = true;");
					script.AppendLine("}");
					script.AppendLine("else{");
					foreach (string aRControlName in lastPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = false;");
					script.AppendLine("}");
				}
				
				if (section is ar.Detail)
				{
					script.AppendLine("if (_prevPageNumber != rpt.PageNumber){");
					script.AppendLine("_beforePrtRowNumInPage = 1;");
					script.AppendLine("_isAlternate = false;");
					script.AppendLine("}");

					// ���ׂ݂̌��Ⴂ�ɐF��ύX����
					script.AppendLine("foreach (string ctrlName in _dtlColorBuf.Keys){");
					script.AppendLine("ARControl wkControl = rpt.Sections[\"" + section.Name + "\"].Controls[ctrlName];");
					script.AppendLine("if (_isAlternate){");
					script.AppendLine("if (wkControl is TextBox) ((TextBox)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Label) ((Label)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Shape) ((Shape)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Picture) ((Picture)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Barcode) ((Barcode)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("}else{");
					script.AppendLine("if (wkControl is TextBox) ((TextBox)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Label) ((Label)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Shape) ((Shape)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Picture) ((Picture)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Barcode) ((Barcode)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("if (_isAlternate) _isAlternate = false;");
					script.AppendLine("else _isAlternate = true;");

					bool isAppendrowNumber5 = false;
					bool isAppendrowNumber10 = false;
					foreach (ar.ARControl aRControl in section.Controls)
					{
						PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
						if (prtItemSetWork != null)
						{
							switch (prtItemSetWork.FreePrtPaperItemCd)
							{
								case (int)FreePrtPaperItemCdKind.RowNumber5:	// �s�ԍ��i5�s���݁j
								{
									if (!isAppendrowNumber5)
									{
										script.AppendLine("TextBox rowNumber5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
										isAppendrowNumber5 = true;
									}
									else
									{
										script.AppendLine("rowNumber5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									}
									script.AppendLine("if (_beforePrtRowNumInPage % 5 == 0 && _beforePrtRowNumInPage > 0)");
									script.AppendLine("rowNumber5.Text = _beforePrtRowNumInPage.ToString();");
									script.AppendLine("else");
									script.AppendLine("rowNumber5.Text = string.Empty;");
									break;
								}
								case (int)FreePrtPaperItemCdKind.RowNumber10:	// �s�ԍ��i10�s���݁j
								{
									if (!isAppendrowNumber10)
									{
										script.AppendLine("TextBox rowNumber10 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
										isAppendrowNumber10 = true;
									}
									else
									{
										script.AppendLine("rowNumber10 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									}
									script.AppendLine("if (_beforePrtRowNumInPage % 10 == 0)");
									script.AppendLine("rowNumber10.Text = _beforePrtRowNumInPage.ToString();");
									script.AppendLine("else");
									script.AppendLine("rowNumber10.Text = string.Empty;");
									break;
								}
							}
						}
					}
					script.AppendLine("_prevPageNumber = rpt.PageNumber;");
					script.AppendLine("_beforePrtRowNumInPage++;");

					// �`�[���ׂ̍����𓝈ꂷ��
					script.AppendLine("float maxHeight = 0;");
					script.AppendLine("foreach (ARControl targetCtrl in _heightAdjustList){");
					script.AppendLine("if (targetCtrl is TextBox) maxHeight = System.Math.Max(((TextBox)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Label) maxHeight = System.Math.Max(((Label)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Picture) maxHeight = System.Math.Max(((Picture)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Shape) maxHeight = System.Math.Max(((Shape)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Barcode) maxHeight = System.Math.Max(((Barcode)targetCtrl).Height, maxHeight);");
					script.AppendLine("}");
					script.AppendLine("foreach (ARControl targetCtrl in _heightAdjustList){");
					script.AppendLine("if (targetCtrl is TextBox) ((TextBox)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Label) ((Label)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Picture) ((Picture)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Shape) ((Shape)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Barcode) ((Barcode)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Line){");
					script.AppendLine("if (((Line)targetCtrl).Y1 > ((Line)targetCtrl).Y2)");
					script.AppendLine("((Line)targetCtrl).Y1 = ((Line)targetCtrl).Y2 + maxHeight;");
					script.AppendLine("else");
					script.AppendLine("((Line)targetCtrl).Y2 = ((Line)targetCtrl).Y1 + maxHeight;");
					script.AppendLine("}");
					script.AppendLine("}");

					// ���ׂ�Format��BeforePrint�̉񐔂��`�F�b�N
					// GroupHeader��KeyBreak����������ꍇ�͏�L�񐔂����������
					script.AppendLine("_detailBeforePrintCount++;");
				}

				script.AppendLine("foreach (ARControl wkARControl in rpt.Sections[\"" + section.Name + "\"].Controls){");
				script.AppendLine("if (wkARControl is TextBox){");
				script.AppendLine("TextBox wkTextBox = (TextBox)wkARControl;");

				// WordWrap=false,CanGrow=true,MultiLine=true�̃o�O�C���p
				script.AppendLine("if (!wkTextBox.WordWrap && wkTextBox.CanGrow && wkTextBox.MultiLine)");
				script.AppendLine("wkTextBox.Width = _wordWrapCtrlWidthList[wkTextBox.Name];");
				
				// OutputFormat "\#,##0","\#,##0-"
				// ��L�o�͂̓}�C�i�X�l�ɐ���ɔ��f����Ȃ�.NET�d�l�̏C��
				// ���A�ُ�Ɂu\�v�������̂́E�E�E
				// OutputFormat == \\#,##0 �� �����߼��ݽ�\�L \\\\#,##0 �� Script�͕�����ׂ̈���ɴ����߼��ݽ�\�L \\\\\\\\#,##0
				script.AppendLine("if (!string.IsNullOrEmpty(wkTextBox.OutputFormat)){");
				script.AppendLine("if (wkTextBox.OutputFormat == \"\\\\\\\\#,##0\" && wkTextBox.Value != null){");
				script.AppendLine("double result = 0;");
				script.AppendLine("double.TryParse(wkTextBox.Value.ToString(), out result);");
				script.AppendLine("if (result < 0)");
				script.AppendLine("wkTextBox.Text = (result * -1).ToString(\"\\\\\\\\-#,##0\");");
				script.AppendLine("}");
				script.AppendLine("if (wkTextBox.OutputFormat == \"\\\\\\\\#,##0-\" && wkTextBox.Value != null){");
				script.AppendLine("double result = 0;");
				script.AppendLine("double.TryParse(wkTextBox.Value.ToString(), out result);");
				script.AppendLine("if (result < 0)");
				script.AppendLine("wkTextBox.Text = (result * -1).ToString(\"\\\\\\\\-#,##0-\");");
				script.AppendLine("}");
				script.AppendLine("}");
				script.AppendLine("}");
				script.AppendLine("}");

				script.AppendLine("}catch(System.Exception ex){");
				script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
				script.AppendLine("}");
				script.AppendLine("}");
				#endregion

				// �i�P���P;�j��ꂽ
			}
			return ApplyCSharpIndent(script.ToString());
		}

		/// <summary>
		/// C#�p�R�[�h�p�C���f���g�K�p����
		/// </summary>
		/// <param name="baseStr">�K�p���镶����</param>
		/// <returns>�K�p���ʕ�����</returns>
		/// <remarks>
		/// <br>Note		: C#�R�[�h������ɃC���f���g��ǉ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string ApplyCSharpIndent(string baseStr)
		{
			// ���O�Q�Ǝ��̉ǐ�����ׁ̈A�C���f���g��ǉ�
			StringWriter baseWriter = new StringWriter();
			IndentedTextWriter writer = new IndentedTextWriter(baseWriter);
			writer.Indent = 0;

			StringReader reader = new StringReader(baseStr);
			string wkStr = string.Empty;
			int onceIndent = 0;
			while ((wkStr = reader.ReadLine()) != null)
			{
				if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"^ ?\}.+\{ ?$"))
				{
					--writer.Indent;
					writer.WriteLine(wkStr);
					++writer.Indent;
				}
				else if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"\{ ?$"))
				{
					writer.WriteLine(wkStr);
					++writer.Indent;
				}
				else if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"^ ?\}"))
				{
					if (writer.Indent > 0)
						--writer.Indent;
					writer.WriteLine(wkStr);
				}
				else
				{
					if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @" ?(foreach|if|else if) ?(.+)[^{;] ?$") ||
						System.Text.RegularExpressions.Regex.IsMatch(wkStr, @" ?else ?$"))
					{
						writer.WriteLine(wkStr);
						++writer.Indent;
						++onceIndent;
					}
					else
					{
						if (onceIndent > 0)
						{
							writer.WriteLine(wkStr);
							while (onceIndent > 0)
							{
								--writer.Indent;
								--onceIndent;
							}
						}
						else
						{
							writer.WriteLine(wkStr);
						}
					}
				}
			}

			return baseWriter.ToString();
		}
		#endregion

		/// <summary>
		/// ��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ̏����������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void InitializeSetting()
		{
			// �A�N�Z�X�N���X��������
			int status = _frePrtPosAcs.Initialize(_enterpriseCode);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u��ID�܂��̓N���XID
					this.Text,							// �v���O��������
					"InitializeSetting",					// ��������
					TMsgDisp.OPE_INIT,					// �I�y���[�V����
					_frePrtPosAcs.ErrorMessage,			// �\�����郁�b�Z�[�W 
					status,								// �X�e�[�^�X�l
					_frePrtPosAcs,						// �G���[�����������I�u�W�F�N�g
					MessageBoxButtons.OK,				// �\������{�^��
					MessageBoxDefaultButton.Button1);	// �����\���{�^��
			}

			_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, new List<PrtItemGroupingDispTitle>(), this.ilARControlIcon);

			// ������ �S�̐ݒ� ������
			_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
			_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, null, _frePrtPosAcs.FreeSheetMngOpt);
			_allSettingControl.WholeSettingChanged += new EventHandler(AllSettingControl_WholeSettingChanged);

			// ������ ���ڐݒ� ������
			_itemSettingControl.SelectedARControlNameChanged += new SFANL08105UD.SelectedARControlNameChangedEventHandler(ItemSettingControl_SelectedARControlNameChanged);
			_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);

			SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);

			List<string> keys = new List<string>(new string[] {FreeSheetConst.ctPopupMenu_Display, FreeSheetConst.ctPopupMenu_Window, FreeSheetConst.ctPopupMenu_Help});
			ToolButtonVisibleChanged(keys, false);

			ChangeInputMode(-1);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            ReflectDesignUnit();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// �A�N�Z�X�N���X�f�[�^�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �A�N�Z�X�N���X�Ƀf�[�^�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetDataToAccessClass()
		{
			// ������ �S�̐ݒ� ������
			_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);

            // Script���Z�b�g
            this.designer.Report.Script = CreateScript();

			// SELECT�����Z�b�g
			if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 1)
			{
				SFANL08132CG cnv = new SFANL08132CG();
				if (_frePrtPosAcs.PrtItemSetList != null)
				{
					byte[] frePrtItmSetPrmByte = XmlByteSerializer.Serialize(cnv.CreateFrePrtItmSetPrm(this.designer.Report, _frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePprSrtOList));
					StringBuilder wkStr = new StringBuilder();
					foreach (byte wkByte in frePrtItmSetPrmByte)
					{
						if (wkStr.Length > 0)
							wkStr.Append(",");
						wkStr.Append(wkByte);
					}
					this.designer.Report.UserData = wkStr.ToString();
				}
			}
			
			// ���|�[�g�f�[�^���Z�b�g
			using (MemoryStream stream = new MemoryStream())
			{
				this.designer.SaveReport(stream);
				stream.Position = 0;
				_frePrtPosAcs.FrePrtPSet.PrintPosClassData = stream.ToArray();
				stream.Close();
			}
		}

		/// <summary>
		/// ActiveReportControl�쐬����
		/// </summary>
		/// <param name="prtItemSet">�󎚍��ڐݒ�}�X�^</param>
		/// <returns>ARControl</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�}�X�^������ARControl���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private ar.ARControl CreateARControlFromPrtItemSet(PrtItemSetWork prtItemSet)
		{
			ar.ARControl arControl = null;
			// ���|�[�g�R���g���[���敪(1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode)
			switch (prtItemSet.ReportControlCode)
			{
				case 1:
				{
					ar.TextBox textBox	= new ar.TextBox();
					textBox.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
                    textBox.Text = prtItemSet.FreePrtPaperItemNm;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 DEL
                    //textBox.WordWrap = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 ADD
                    textBox.WordWrap = true;
                    textBox.MultiLine = false;
                    textBox.CanGrow = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 ADD

					switch (prtItemSet.CommaEditExistCd)
					{
						case 1: textBox.OutputFormat = "#,###";		break;
						case 2: textBox.OutputFormat = "#,##0";		break;
						case 3: textBox.OutputFormat = "0.0";		break;
						case 4: textBox.OutputFormat = "0.00";		break;
						case 5: textBox.OutputFormat = @"\\#,##0";	break;
						case 6: textBox.OutputFormat = @"\\#,##0-";	break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 ADD
                        case 7: textBox.OutputFormat = @"\\#,###"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 ADD
					}
					switch (prtItemSet.FreePrtPaperItemCd)
					{
						case (int)FreePrtPaperItemCdKind.PageNumber:
						{
							textBox.SummaryType		= ar.SummaryType.PageCount;
							textBox.SummaryRunning	= ar.SummaryRunning.All;
							break;
						}
						case (int)FreePrtPaperItemCdKind.TotalPageNumber:
						{
							textBox.SummaryType		= ar.SummaryType.PageCount;
							break;
						}
					}
					arControl = textBox;
					break;
				}
				case 2:
				{
					ar.Label label	= new ar.Label();
					label.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					label.Text		= prtItemSet.FreePrtPaperItemNm;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 DEL
                    //label.WordWrap	= false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 ADD
                    label.WordWrap = true;
                    label.MultiLine = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 ADD
					arControl = label;
					break;
				}
				case 3:
				{
					ar.Picture picture	= new ar.Picture();
					picture.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					arControl = picture;
					break;
				}
				case 4:
				{
					arControl = new ar.Shape();
					break;
				}
				case 5:
				{
					arControl = new ar.Line();
					break;
				}
				case 6:
				{
					ar.Barcode barcode	= new ar.Barcode();
					barcode.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					switch (prtItemSet.BarCodeStyle)
					{
						case 2: barcode.Style = ar.BarCodeStyle.JapanesePostal; break;
						case 3: barcode.Style = ar.BarCodeStyle.QRCode; break;
						default: barcode.Style = ar.BarCodeStyle.Code_128_A; break;
					}
					barcode.BackColor	= Color.White;
					arControl = barcode;
					break;
				}
				case 7:
				{
					arControl = new ar.SubReport();
					break;
				}
			}

			arControl.Name = prtItemSet.DDName;

			arControl.Tag = FrePrtSettingController.GetARControlTagInfo(prtItemSet);

			return arControl;
		}

		/// <summary>
		/// ���̓��[�h�ύX����
		/// </summary>
		/// <param name="printPaperUseDivcd">���[�g�p�敪</param>
		/// <remarks>
		/// <br>Note		: ���̓��[�h�ɉ����āA��ʂ̓��͐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ChangeInputMode(int printPaperUseDivcd)
		{
			List<string> enabledKeyList = new List<string>();
			List<string> disableKeyList = new List<string>();

			switch (printPaperUseDivcd)
			{
				case (int)PrintPaperUseDivcdKind.Report:
				{
					// �c�[���o�[�i���͉j
					enabledKeyList.Add(ctToolButton_SaveNewName);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //enabledKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
					enabledKeyList.Add(ctToolButton_SortSetting);
					enabledKeyList.Add(ctToolButton_FitPaper);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    enabledKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Print);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Save);
					// �ҏW���
					this.designer.Enabled		= true;
					// �ǉ�����
					_addItemControl.Enabled		= true;
					// �S�̐ݒ�
					_allSettingControl.Enabled	= true;
					// ���ڐݒ�
					_itemSettingControl.Enabled = true;
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMReport:
                //case (int)PrintPaperUseDivcdKind.DMPostCard:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				case (int)PrintPaperUseDivcdKind.Slip:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                case (int)PrintPaperUseDivcdKind.DmdBill:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
				{
					// �c�[���o�[�i���͉j
					enabledKeyList.Add(ctToolButton_SaveNewName);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Save);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Print);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    enabledKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					// �c�[���o�[�i���͕s�j
					disableKeyList.Add(ctToolButton_SortSetting);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //disableKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

					// �`�[�̍X�V���[�h���́u�p�����ɍ��킹��v�͖���
                    if ( !_frePrtPosAcs.FreeSheetMngOpt &&
                        _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 2 &&
                        _frePrtPosAcs.FrePrtPSet.UpdateDateTime > DateTime.MinValue )
                    {
                        disableKeyList.Add( ctToolButton_FitPaper );
                    }
                    else
                    {
                        enabledKeyList.Add( ctToolButton_FitPaper );
                    }

					// �ҏW���
					this.designer.Enabled		= true;
					// �ǉ�����
					_addItemControl.Enabled		= true;
					// �S�̐ݒ�
					_allSettingControl.Enabled	= true;
					// ���ڐݒ�
					_itemSettingControl.Enabled = true;
					break;
				}
				default:
				{
					// �c�[���o�[�i���͕s�j
					disableKeyList.Add(ctToolButton_SaveNewName);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //disableKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
					disableKeyList.Add(ctToolButton_SortSetting);
					disableKeyList.Add(ctToolButton_FitPaper);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    disableKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					disableKeyList.Add(FreeSheetConst.ctToolBase_Print);
					disableKeyList.Add(FreeSheetConst.ctToolBase_Save);
					// �ҏW���
					this.designer.Enabled		= false;
					// �ǉ�����
					_addItemControl.Enabled		= false;
					// �S�̐ݒ�
					_allSettingControl.Enabled	= false;
					// ���ڐݒ�
					_itemSettingControl.Enabled	= false;
					break;
				}
			}

			// ���R���[�Ǘ��I�v�V���������������́u���O��t���ĕۑ��v�u�V�K�v�u�p�����ɍ��킹��v���\��
			if (!_frePrtPosAcs.FreeSheetMngOpt)
				ToolButtonVisibleChanged(new List<string>(new string[] { ctToolButton_SaveNewName, FreeSheetConst.ctToolBase_New, ctToolButton_FitPaper }), false);

			ToolButtonEnableChanged(enabledKeyList, true);
			ToolButtonEnableChanged(disableKeyList, false);
		}

		/// <summary>
		/// �f�U�C�i�[�ǉ��\�`�F�b�N
		/// </summary>
		/// <param name="section">�ǉ��ΏۂƂȂ�Section</param>
		/// <param name="prtItemSet">�󎚍��ڐݒ�}�X�^</param>
		/// <returns>�ǉ��\�t���O</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�}�X�^�̓��e�����ɑΏۂ�Section��ARControl��</br>
		/// <br>			: ���ǉ��\���`�F�b�N���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private bool CanAddDesigner(ar.Section section, PrtItemSetWork prtItemSet)
		{
			if (section is ar.ReportHeader || section is ar.PageHeader || section is ar.GroupHeader)
			{
				if (prtItemSet.HeaderUseDivCd == 1)
					return true;
			}
			else if (section is ar.Detail)
			{
				if (prtItemSet.DetailUseDivCd == 1)
					return true;
			}
			else if (section is ar.ReportFooter || section is ar.PageFooter || section is ar.GroupFooter)
			{
				if (prtItemSet.FooterUseDivCd == 1)
					return true;
			}

			return false;
		}

		/// <summary>
		/// �R���g���[�����̐ݒ菈��
		/// </summary>
		/// <param name="targetCtrl">�ΏۃR���g���[��</param>
		/// <returns>�ݒ茋��</returns>
		private bool SetNewControlName(ar.ARControl targetCtrl)
		{
			try
			{
				List<string> nameList = new List<string>();
				foreach (ar.Section section in this.designer.Report.Sections)
				{
                    foreach ( ar.ARControl control in section.Controls )
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 DEL
                        //nameList.Add(control.Name);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 ADD
                        nameList.Add( control.Name.ToUpper() );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 ADD
				}

				int branchNumber = 1;
				string wkName = targetCtrl.Name;
				// ���ɓ����R���g���[�������݂���ꍇ�͎}�Ԃ�t�^
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 DEL
                //while (nameList.Contains(wkName))
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 ADD
                while ( nameList.Contains( wkName.ToUpper() ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 ADD
				{
					wkName = targetCtrl.Name + branchNumber++;
				}
				targetCtrl.Name = wkName;
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// �����Z�N�V�����쐬����
		/// </summary>
		/// <param name="printPaperUseDivcd">���[�g�p�敪</param>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
		/// <returns>�쐬����</returns>
		private int CreateDefaultSection(int printPaperUseDivcd, int dataInputSystem)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			this.designer.SuspendLayout();

			int nowReportHFCnt	= 0;
			int nowPageHFCnt	= 0;
			int nowGroupHFCnt	= 0;
			List<string> sectionNameList = new List<string>();
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (section is ar.ReportHeader) nowReportHFCnt++;
				else if (section is ar.PageHeader) nowPageHFCnt++;
				else if (section is ar.GroupHeader) nowGroupHFCnt++;
				sectionNameList.Add(section.Name);
			}

			int reportHFCnt = 0;
			int pageHFCnt	= 0;
			int groupHFCnt	= 0;
			switch (printPaperUseDivcd)
			{
				case (int)PrintPaperUseDivcdKind.Report:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMReport:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				{
					reportHFCnt	= 1;
					pageHFCnt	= 1;
					groupHFCnt	= 4;
					break;
				}
				case (int)PrintPaperUseDivcdKind.Slip:
				{
					reportHFCnt	= 1;
					pageHFCnt	= 1;
					groupHFCnt	= 1;
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMPostCard:
                //{
                //    reportHFCnt	= 0;
                //    pageHFCnt	= 1;
                //    groupHFCnt	= 0;
                //    break;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                case (int)PrintPaperUseDivcdKind.DmdBill:
                {
                    reportHFCnt = 1;
                    pageHFCnt = 1;
                    groupHFCnt = 2;
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
			}

			// ReportHeader,ReportFooter��ǉ�
			while (reportHFCnt > nowReportHFCnt)
			{
				this.designer.Report.Sections.InsertReportHF();
				nowReportHFCnt++;
			}
			// PageHeader,PageFooter��ǉ�
			while (pageHFCnt > nowPageHFCnt)
			{
				this.designer.Report.Sections.InsertPageHF();
				nowPageHFCnt++;
			}
			// GroupHeader,GroupFooter��ǉ�
			while (groupHFCnt > nowGroupHFCnt)
			{
				this.designer.Report.Sections.InsertGroupHF();
				nowGroupHFCnt++;
			}

			// ����`�[�̏ꍇ�͓���p�r�i�ی����󎚗p�j�pGroupHeader,GroupFooter��ǉ�����
			if (printPaperUseDivcd == 2 && dataInputSystem == 2 && !sectionNameList.Contains(SFANL08235CD.CT_INSURINFO_GROUPHEADERNAME))
			{
				int pageHeaderIndex = 0;
				int pageFooterIndex = 0;
				for (int ix = 0; ix != this.designer.Report.Sections.Count; ix++)
				{
					if (this.designer.Report.Sections[ix] is ar.PageHeader)
						pageHeaderIndex = ix;
					if (this.designer.Report.Sections[ix] is ar.PageFooter)
						pageFooterIndex = ix;
				}
				// Insert���Ԃ͕K��Footer��Header
				this.designer.Report.Sections.Insert(pageFooterIndex, ar.SectionType.GroupFooter, SFANL08235CD.CT_INSURINFO_GROUPFOOTERNAME);
				this.designer.Report.Sections.Insert(pageHeaderIndex + 1, ar.SectionType.GroupHeader, SFANL08235CD.CT_INSURINFO_GROUPHEADERNAME);
			}

			// PageHeader,PageFooter,Detail�ȊO�̍�����0
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (!(section is ar.Detail))
				{
					if (!sectionNameList.Contains(section.Name) || section.Controls.Count == 0)
						section.Height = 0;
				}
			}

			this.designer.ResumeLayout(true);

			return status;
		}

////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2008.03.19</br>
		/// </remarks>
		public bool InputCheck(out string message)
		{
			message = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Report)
            //{
            //    // ���o�����̐ݒ�`�F�b�N
            //    if (_frePrtPosAcs.FrePprECndList == null || _frePrtPosAcs.FrePprECndList.Count == 0)
            //    {
            //        message = "���o������ݒ肵�Ă��������B";
            //        return false;
            //    }

            //    // ���o�����̓��̓`�F�b�N
            //    SFANL08130UA extrSetting = new SFANL08130UA();
            //    int errIndex = 0;
            //    if (!extrSetting.InputCheck(_frePrtPosAcs.FrePprECndList, out message, out errIndex))
            //    {
            //        message = "[���o�����ݒ�] - " + message;
            //        return false;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

			return true;
		}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        /// <summary>
        /// �P�ʕύX
        /// </summary>
        private void ChangeDesignUnit()
        {
            // �؂�ւ��i���]�j
            _cmInchControl.IsInchMode = (!_cmInchControl.IsInchMode);

            // �\�����f
            ReflectDesignUnit();
        }
        /// <summary>
        /// �P�ʕύX���̐���
        /// </summary>
        private void ReflectDesignUnit()
        {
            // �f�U�C�i�̒P�ʕύX
            if ( _cmInchControl.IsInchMode )
            {
                // �C���`�P��
                designer.DesignUnits = MeasurementUnits.US;
            }
            else
            {
                // cm�P��
                designer.DesignUnits = MeasurementUnits.Metric;
            }

            try
            {
                // �q�t�H�[���̒P�ʕύX

                // �S�̐ݒ�
                if ( _allSettingControl != null && _frePrtPosAcs != null && _frePrtPosAcs.FrePrtPSet != null &&
                     this.designer != null && this.designer.Report != null )
                {
                    _allSettingControl.ShowWholeSetting( _frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt );
                }

                // ���ڃv���p�e�B
                if ( _itemSettingControl != null && this.designer != null && this.designer.Report != null &&
                     _frePrtPosAcs != null && _frePrtPosAcs.ARCtrlPropertyDispInfo != null )
                {
                    _itemSettingControl.ShowPropertyInfo( this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UA_Load(object sender, EventArgs e)
		{
			this.designer.Report.Sections.Clear();
			this.designer.Enabled = false;

			// ---------------------------------------
			// ���d�N���̖h�~
			// ---------------------------------------
			_mutex = new Mutex(false, SFANL08105UH.ctASSEMBLY_ID);
			if (!_mutex.WaitOne(0, false))
			{
				_frePrtPosAcs.WriteLog(_enterpriseCode, "FrePrtPos StartCancelException:Duplicate");
				throw new FreeSheetStartCancelException(this.Text + "�̑��d�N���͂ł��܂���B");
			}
			else
			{
				InitializeSetting();
			}
		}

		/// <summary>
		/// DragOver�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g���R���g���[���̋��E���Ƀh���b�O���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_DragOver(object sender, DragEventArgs e)
		{
			PrtItemSetWork prtItemSet = e.Data.GetData(typeof(PrtItemSetWork)) as PrtItemSetWork;
			if (prtItemSet != null)
			{
                ar.Section section = this.designer.SectionAt( new Point( e.X, e.Y ) );
				Point nowPoint = this.designer.PointToSection(section, new Point(e.X, e.Y));
				if (nowPoint.X >= 0 && nowPoint.Y >= 0)
				{
					if (CanAddDesigner(section, prtItemSet))
						e.Effect = DragDropEffects.Copy;
				}
			}
		}

		/// <summary>
		/// DragDrop�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �h���b�O�A���h�h���b�v���삪���������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(PrtItemSetWork)))
			{
				PrtItemSetWork prtItemSet	= (PrtItemSetWork)e.Data.GetData(typeof(PrtItemSetWork));
				ar.ARControl aRControl		= CreateARControlFromPrtItemSet(prtItemSet);
				if (aRControl != null)
				{
					// �ǉ��Ώ�Section���擾
                    ar.Section section = this.designer.SectionAt( new Point( e.X, e.Y ) );
					if (section != null)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10
                        //Point dropPoint = this.designer.PointToSection( section, new Point( e.X, e.Y ) );
                        // ��Ver.Up�ɂ��A�N�e�B�u���|�[�g�̎d�l���ς���Ă���\��������܂��B�ʒu�𒲐��B
                        Control parent = this.Parent;
                        Point dropPoint = this.designer.PointToSection( section, new Point( e.X - this.Left - parent.Left, e.Y - this.Top - parent.Top ) );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10

						// ActiveReport�͑S��Inch��ׁ̈AGraphics�N���X���𑜓x���擾�A�ϊ�
						Graphics graphics = this.designer.CreateGraphics();
						try
						{
                            aRControl.Location = new PointF( dropPoint.X / graphics.DpiX, dropPoint.Y / graphics.DpiY );
                        }
						finally
						{
							graphics.Dispose();
						}

						if (SetNewControlName(aRControl))
						{
							// �ǉ�����R���g���[�����̂�ޔ�
							_addControlNames.Add(aRControl.Name);

                            try
                            {
                                // �R���g���[����ǉ�
                                section.Controls.Add( aRControl );
                            }
                            catch( Exception ex)
                            {
                                string msg = ex.Message;
                            }

							this.designer.Selection.Select(aRControl);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // �� ��è����߰�Ver.Up�ɂ��Add�Ɋւ��郌�C�A�E�g�ύX�C�x���g������Ȃ��悤�Ȃ����̂ł����Œǉ��B
                            _itemSettingControl.UpdateSelectItemCombo( this.designer.Report, this.ilARControlIcon );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
						}
					}
				}
			}
		}

		/// <summary>
		/// SelectionChanged�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ�Ƃ��ɔ������܂��BSelection�v���p�e�B���g�p����ƁA</br>
		/// <br>			: ���݂̑I����e���m�F�ł��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_SelectionChanged()
		{
			// ���C�A�E�g�c�[���o�[�̓��͐���
			SetLayoutToolbar();

			_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
		}

		/// <summary>
		/// LayoutChanging�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���|�[�g���C�A�E�g���ύX�����O�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_LayoutChanging(object sender, LayoutChangingArgs e)
		{
			if (_itemSettingControl.IsNowWorking) return;

			switch (e.Type)
			{
				case LayoutChangeType.SectionSize:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "�Z�N�V�����̍����A���̕ύX�͏o���܂���B";
						TMsgDisp.Show(
							this,							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,		// �A�Z���u��ID�܂��̓N���XID
							message,						// �\�����郁�b�Z�[�W 
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
						e.AllowChange = false;
					}
					break;
				}
				case LayoutChangeType.SectionMove:
				case LayoutChangeType.SectionAdd:
				case LayoutChangeType.SectionDelete:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "�Z�N�V�����̈ړ��A�ǉ��A�폜�͏o���܂���B";
						TMsgDisp.Show(
							this,							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,		// �A�Z���u��ID�܂��̓N���XID
							message,						// �\�����郁�b�Z�[�W 
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
						e.AllowChange = false;
					}
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					else if (e.Type == LayoutChangeType.SectionDelete)
					{
						// SummaryGroup�ɑ��݂��Ȃ�GroupHeader���w�肳��Ă����
						// ��������ɃG���[���o��׃N���A���s���B
						foreach (ar.Section section in this.designer.Report.Sections)
						{
							foreach (ar.ARControl control in section.Controls)
							{
								if (control is ar.TextBox)
								{
									ar.TextBox textBox = (ar.TextBox)control;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                                    //if (e.Names != null && e.Names.Length > 0 && textBox.SummaryGroup == e.Names[0])
                                    //    textBox.SummaryGroup = string.Empty;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                                    if ( e.Name != null && textBox.SummaryGroup == e.Name )
                                    {
                                        textBox.SummaryGroup = string.Empty;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
								}
							}
						}
					}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
				case LayoutChangeType.ControlAdd:
				case LayoutChangeType.ControlDelete:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "�R���g���[���̒ǉ��A�폜�͏o���܂���B";
						TMsgDisp.Show(
							this,							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,		// �A�Z���u��ID�܂��̓N���XID
							message,						// �\�����郁�b�Z�[�W 
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
						e.AllowChange = false;
					}
					else if (e.Type == LayoutChangeType.ControlAdd)
					{
						// ����ǉ�����ARControl��Name��ޔ�����
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                        //_addControlNames.AddRange(e.Names);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                        //_addControlNames.Add( e.Name );
                        _itemSettingControl.UpdateSelectItemCombo( this.designer.Report, this.ilARControlIcon );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
					}
					break;
				}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				case LayoutChangeType.ControlMove:
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
					//PointF newPointF = (PointF)e.NewValues[0];
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD

                    if ( !(e.NewValue is PointF) )
                    {
                        break;
                    }
                    PointF newPointF = (PointF)e.NewValue;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/12 DEL ڲ��Ă̎��R�x�����߂�ׁAϲŽ��������
                    //if (newPointF.X < 0 || newPointF.Y < 0)
                    //{
                    //    // �}�C�i�X�ɂȂ�ꍇ�̓C�x���g���L�����Z��
                    //    e.AllowChange = false;

                    //    // �}�C�i�X�l��0�ɕύX���čēxControl�ړ��C�x���g�𔭐�������
                    //    if (newPointF.X < 0)
                    //        newPointF.X = 0;
                    //    if (newPointF.Y < 0)
                    //        newPointF.Y = 0;
                    //    for (int ix = 0 ; ix != this.designer.Selection.Count ; ix++)
                    //    {
                    //        ar.ARControl aRControl = this.designer.Selection[ix] as ar.ARControl;
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                    //        //if (aRControl != null && aRControl.Name == e.Names[0])
                    //        //{
                    //        //    aRControl.Location = newPointF;
                    //        //    break;
                    //        //}
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                    //        if ( aRControl != null && aRControl.Name == e.Name )
                    //        {
                    //            aRControl.Location = newPointF;
                    //            break;
                    //        }
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
                    //    }
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/12 DEL
					break;
				}
			}
		}

		/// <summary>
		/// LayoutChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���|�[�g���C�A�E�g���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_LayoutChanged(object sender, LayoutChangedArgs e)
		{
			if (_itemSettingControl.IsNowWorking) return;

			switch (e.Type)
			{
				case LayoutChangeType.ReportSize:
				{
					// ReportSize����LayoutChanging�C�x���g���������Ȃ� orz
					// �o�O���炯�ł܂Ƃ��ɃT�|�[�g�����Ȃ����i�Ȃ񂩔̔�����Ȃ�
					if (!_frePrtPosAcs.FreeSheetMngOpt && _prevReportSize != 0 && this.designer.Report.PrintWidth != _prevReportSize)
					{
						string message = "�Z�N�V�����̍����A���̕ύX�͏o���܂���B";
						TMsgDisp.Show(
							this,							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
							SFANL08105UH.ctASSEMBLY_ID,		// �A�Z���u��ID�܂��̓N���XID
							message,						// �\�����郁�b�Z�[�W 
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
						this.designer.Report.PrintWidth = _prevReportSize;
					}
					else
					{
						if (!_itemSettingControl.IsNowWorking)
							_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
						if (e.Type == LayoutChangeType.ReportSize && !_allSettingControl.IsNowWorking)
							_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);
						this.designer.Focus();
					}
					break;
				}
				case LayoutChangeType.ControlAdd:
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // �� ��è����߰�Ver.Up�ł̎d�l�ύX�Ȃ̂��Aadd��LayoutChanged������Ȃ��̂ō폜�B

                    //_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

                    //while (_addControlNames.Count > 0)
                    //{
                    //    bool isExistName = false;
                    //    foreach (ar.Section section in this.designer.Report.Sections)
                    //    {
                    //        for (int iy = 0 ; iy != section.Controls.Count ; iy++)
                    //        {
                    //            ar.ARControl aRControl = section.Controls[iy];
                    //            if (aRControl.Name.Equals(_addControlNames[0]))
                    //            {
                    //                PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
                    //                if (prtItemSet != null)
                    //                {
                    //                    if (!CanAddDesigner(section, prtItemSet))
                    //                        section.Controls.Remove(aRControl);
                    //                }
                    //                isExistName = true;
                    //                break;
                    //            }
                    //        }
                    //        if (isExistName) break;
                    //    }
                    //    _addControlNames.RemoveAt(0);
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					break;
				}
				case LayoutChangeType.ControlDelete:
				{
					List<ar.ARControl> aRControlList = new List<ar.ARControl>();
					for (int ix = 0 ; ix != this.designer.Selection.Count ; ix++)
					{
						if (this.designer.Selection[ix] is ar.Section)
						{
							ar.Section section = (ar.Section)this.designer.Selection[ix];
							foreach (ar.ARControl aRControl in section.Controls)
								aRControlList.Add(aRControl);
						}
						else if (this.designer.Selection[ix] is ar.ARControl)
						{
							aRControlList.Add(this.designer.Selection[ix] as ar.ARControl);
						}
					}
					_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);
					break;
				}
				case LayoutChangeType.ControlMove:
				case LayoutChangeType.ControlSize:
				case LayoutChangeType.SectionSize:
				{
					if (!_itemSettingControl.IsNowWorking)
						_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
					if (e.Type == LayoutChangeType.ReportSize && !_allSettingControl.IsNowWorking)
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);
					this.designer.Focus();
					break;
				}
			}
		}

		/// <summary>
		/// �I��ARControl�ύX�C�x���g
		/// </summary>
		/// <param name="name">�R���g���[������</param>
		/// <remarks>
		/// <br>Note		: �I��ARControl���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ItemSettingControl_SelectedARControlNameChanged(string name)
		{
			this.designer.Selection.Clear();

			foreach (ar.Section section in this.designer.Report.Sections)
			{
				foreach (ar.ARControl control in section.Controls)
				{
					if (control.Name.Equals(name))
					{
						this.designer.Selection.Select(section.Controls[name]);
						break;
					}
				}
			}
		}

		/// <summary>
		/// �S�̐ݒ�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �S�̐ݒ肪�ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void AllSettingControl_WholeSettingChanged(object sender, EventArgs e)
		{
			if (sender is SFANL08105UC.ChangedType)
			{
				switch ((SFANL08105UC.ChangedType)sender)
				{
					case SFANL08105UC.ChangedType.Comment:
					case SFANL08105UC.ChangedType.PrintPos:
					{
						_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);
						break;
					}
					case SFANL08105UC.ChangedType.Watermark:
					{
						_frePrtPosAcs.SetNewImageData(_enterpriseCode, _allSettingControl.Watermark);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
                        this.designer.Report.Watermark = _allSettingControl.Watermark;
                        this.designer.Report.WatermarkAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

						break;
					}
				}
			}
		}

		/// <summary>
		/// FormClosed�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[����������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UA_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Mutex�����s����Ă���ꍇ�͔j��
			if (_mutex != null)
			{
				_mutex.ReleaseMutex();	// ���
				_mutex.Close();			// �j��
			}
		}
		#endregion
	}
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
    # region [�Z���`���[�g���E�C���`����N���X]
    /// <summary>
    /// �Z���`���[�g���E�C���`����N���X
    /// </summary>
    /// <remarks>���f�[�^���Inch�Œ�ł��B�\�����@��cm�܂���inch�ŕ\������א��䂵�܂��B</remarks>
    internal class CmInchControl
    {
        // �C���`���[�h(true = �\����Inch�ň���)
        private bool _isInchMode;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CmInchControl()
        {
            _isInchMode = true;
        }

        /// <summary>
        /// �C���`���[�h(true = �\����Inch�ň���)
        /// </summary>
        public bool IsInchMode
        {
            get { return _isInchMode; }
            set { _isInchMode = value; }
        }
        /// <summary>
        /// �\��(cm or inch)���f�[�^(inch)
        /// </summary>
        /// <param name="cmOrInch"></param>
        /// <returns></returns>
        public float ToData( float cmOrInch )
        {
            // Cm or Inch �� Inch
            if ( _isInchMode )
            {
                // Inch �� Inch
                return cmOrInch;
            }
            else
            {
                // Cm �� Inch
                return ar.ActiveReport3.CmToInch( cmOrInch );
            }
        }
        /// <summary>
        /// �f�[�^(inch)���\��(cm or inch)
        /// </summary>
        /// <param name="cmOrInch"></param>
        /// <returns></returns>
        public float ToDisp( float cmOrInch )
        {
            // Inch �� Cm or Inch
            if ( _isInchMode )
            {
                // Inch �� Inch
                return cmOrInch;
            }
            else
            {
                // Inch �� Cm
                return ar.ActiveReport3.InchToCm( cmOrInch );
            }
        }
        /// <summary>
        /// �P�ʃ^�C�g��(cm or inch)
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            if ( _isInchMode )
            {
                return "���";
            }
            else
            {
                return "cm";
            }
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
}
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinEditors;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �v���p�e�B�ݒ���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ActiveReport�̃v���p�e�B��ݒ肷���ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UD : UserControl
	{
		#region PrivateMember
		// �󎚍��ڃO���[�v�A�N�Z�X�N���X
		private PrtItemGrpAcs			_prtItemGrpAcs;
		// �������t���O
		private bool					_isNowWorking;
		// �v���p�e�B�\�����t���O
		private bool					_isShowPropertyData;
		// �I�𒆂̃R���g���[��
		private Selection				_selection;
		// ���͕ύX�`�F�b�N�p
		private double					_buffCode;
		private string					_buffText;
		// �󎚍��ڐݒ�LIST
		private List<PrtItemSetWork>	_prtItemSetList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        // �󎚈ʒu�ݒ�
        private FrePrtPSet _frePrtPSet;
        // ���|�[�g�C���X�^���X
        private ar.ActiveReport3 _report;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        // �Z���`�E�C���`����
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		// �t�H���g�T�C�Y
		private int[] _fontSizeArray	= new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
		#endregion

		#region Delegate
		// �I���R���g���[���ύX�C�x���g�n���h��
		public delegate void SelectedARControlNameChangedEventHandler(string name);
		#endregion

		#region PublicEventHandler
		// �I���R���g���[���ύX�C�x���g
		public event SelectedARControlNameChangedEventHandler SelectedARControlNameChanged;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UD()
		{
			InitializeComponent();

			// Regular���T�|�[�g���Ă��Ȃ��t�H���g�͍폜����
			for (int ix = 0 ; ix != this.ufnFontName.Items.Count ; ix++)
			{
				FontFamily fontFamily = new FontFamily(this.ufnFontName.Items[ix].ToString());
				if (!fontFamily.IsStyleAvailable(FontStyle.Regular))
					this.ufnFontName.Items.RemoveAt(ix);
			}

			this.cmbOutputFormat.Items.Clear();
			this.cmbOutputFormat.Items.Add(string.Empty,	" ");
			this.cmbOutputFormat.Items.Add("#,###",			"#,###");
			this.cmbOutputFormat.Items.Add("#,##0",			"#,##0");
			this.cmbOutputFormat.Items.Add(@"\\#,##0",		"\\#,##0");
			this.cmbOutputFormat.Items.Add(@"\\#,##0-",		"\\#,##0-");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 ADD
            this.cmbOutputFormat.Items.Add( @"\\#,###;-\\#,###;''", "\\#,###" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
            this.cmbOutputFormat.Items.Add( "###0", "###0" );
            this.cmbOutputFormat.Items.Add( "####", "####" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
			this.cmbOutputFormat.Items.Add("0.0",			"0.0");
			this.cmbOutputFormat.Items.Add("0.00",			"0.00");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.cmbOutputFormat.Items.Add( "#,##0.00", "#,##0.00" );
            this.cmbOutputFormat.Items.Add( @"\\#,##0.00", "\\#,##0.00" );
            this.cmbOutputFormat.Items.Add( @"\\#,##0.00-", "\\#,##0.00-" );
            this.cmbOutputFormat.Items.Add( "0", "0" );
            this.cmbOutputFormat.Items.Add( "00", "00" );
            this.cmbOutputFormat.Items.Add( "000", "000" );
            this.cmbOutputFormat.Items.Add( "0000", "0000" );
            this.cmbOutputFormat.Items.Add( "00000", "00000" );
            this.cmbOutputFormat.Items.Add( "000000", "000000" );
            this.cmbOutputFormat.Items.Add( "0000000", "0000000" );
            this.cmbOutputFormat.Items.Add( "00000000", "00000000" );
            this.cmbOutputFormat.Items.Add( "000000000", "000000000" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.cmbAlignment.Items.Clear();
			this.cmbAlignment.Items.Add(ar.TextAlignment.Left,		"����");
			this.cmbAlignment.Items.Add(ar.TextAlignment.Center,	"�������킹");
			this.cmbAlignment.Items.Add(ar.TextAlignment.Right,		"�E��");

			this.cmbVerticalAlignment.Items.Clear();
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Top,		"���");
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Middle,	"�������킹");
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Bottom,	"����");

			this.cmbLineStyle.Items.Clear();
			this.cmbLineStyle.Items.Add(ar.LineStyle.Transparent,	"�Ȃ�");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Solid,			"����");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Dash,			"�j��");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Dot,			"�_��");
			this.cmbLineStyle.Items.Add(ar.LineStyle.DashDot,		"��_����");
			this.cmbLineStyle.Items.Add(ar.LineStyle.DashDotDot,	"��_����");

			this.cmbStyle.Items.Clear();
			this.cmbStyle.Items.Add(ar.ShapeType.Rectangle,	"�����`");
			this.cmbStyle.Items.Add(ar.ShapeType.Ellipse,	"�ȉ~");
			this.cmbStyle.Items.Add(ar.ShapeType.RoundRect,	"�p�ے����`");

			this.cmbPictureAlignment.Items.Clear();
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.TopLeft,		"����");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.TopRight,	"�E��");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.Center,		"����");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.BottomLeft,	"����");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.BottomRight,	"�E��");

			this.cmbSizeMode.Items.Clear();
			this.cmbSizeMode.Items.Add(ar.SizeModes.Clip,		"������");
			this.cmbSizeMode.Items.Add(ar.SizeModes.Stretch,	"���ɍ��킹��");
			this.cmbSizeMode.Items.Add(ar.SizeModes.Zoom,		"�c����Œ�");

			this.cmbPrintPageCtrlDivCd.Items.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 DEL
            //this.cmbPrintPageCtrlDivCd.Items.Add(0, "�S�y�[�W");
            //this.cmbPrintPageCtrlDivCd.Items.Add(1, "1�y�[�W�ڂ̂�");
            //this.cmbPrintPageCtrlDivCd.Items.Add(2, "�ŏI�y�[�W�̂�");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 DEL

			this.cmbNewPage.Items.Clear();
			this.cmbNewPage.Items.Add(ar.NewPage.None,			"�@");
			this.cmbNewPage.Items.Add(ar.NewPage.Before,		"�󎚑O");
			this.cmbNewPage.Items.Add(ar.NewPage.After,			"�󎚌�");
			this.cmbNewPage.Items.Add(ar.NewPage.BeforeAfter,	"�󎚑O��");

			this.cmbRepeatStyle.Items.Clear();
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.None,					"�@");
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.OnPage,				"�y�[�W��");
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.OnPageIncludeNoDetail,	"�֘A�f�[�^�L�莞");

			this.cmbSummaryFunc.Items.Clear();
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Sum,	"���v");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Avg,	"����");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Count,	"����");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Min,	"�ŏ��l");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Max,	"�ő�l");

			this.cmbSummaryRunning.Items.Clear();
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.None,	"�@");
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.Group,	"�O���[�v");
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.All,		"�S��");

			this.cmbSummaryType.Items.Clear();
			this.cmbSummaryType.Items.Add(ar.SummaryType.None,			"�@");
			this.cmbSummaryType.Items.Add(ar.SummaryType.SubTotal,		"�O���[�v");
			this.cmbSummaryType.Items.Add(ar.SummaryType.PageTotal,		"�y�[�W");
			this.cmbSummaryType.Items.Add(ar.SummaryType.GrandTotal,	"�S��");

			this.cmbGroupSuppressCd.Items.Clear();
			this.cmbGroupSuppressCd.Items.Add(0, "�Ȃ�");
			this.cmbGroupSuppressCd.Items.Add(1, "����");

			this.cmbDtlColorChangeCd.Items.Clear();
			this.cmbDtlColorChangeCd.Items.Add(0, "�Ȃ�");
			this.cmbDtlColorChangeCd.Items.Add(1, "����");

			this.cmbHeightAdjustDivCd.Items.Clear();
			this.cmbHeightAdjustDivCd.Items.Add(0, "�Ȃ�");
			this.cmbHeightAdjustDivCd.Items.Add(1, "����");

			this.cmbFontSize.DataSource = _fontSizeArray;

			this.ubImage.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			this.ubDataField.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			_prtItemSetList = new List<PrtItemSetWork>();
		}
		#endregion

		#region Property
		/// <summary>�󎚍��ڐݒ�LIST</summary>
		public List<PrtItemSetWork> PrtItemSetList
		{
			set {
				if (value == null)
					_prtItemSetList = new List<PrtItemSetWork>();
				else
					_prtItemSetList = value;
			}
		}

		/// <summary>�������t���O</summary>
		public bool IsNowWorking
		{
			get { return _isNowWorking; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// �󎚈ʒu�ݒ�
        /// </summary>
        public FrePrtPSet FrePrtPSet
        {
            set
            {
                if ( value == null )
                {
                    _frePrtPSet = new FrePrtPSet();
                }
                else
                {
                    _frePrtPSet = value;
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        /// <summary>�Z���`�E�C���`����</summary>
        public CmInchControl CmInchControl
        {
            get { return _cmInchControl; }
            set { _cmInchControl = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// �v���p�e�B���\������
		/// </summary>
		/// <param name="rpt">ActiveReport�I�u�W�F�N�g</param>
		/// <param name="selection">�I������</param>
		/// <param name="aRCtrlDispList">���R���[�v���p�e�B�\�����LIST</param>
		/// <remarks>
		/// <br>Note		: �I�����ꂽ���ڂ̃v���p�e�B����\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void ShowPropertyInfo(ar.ActiveReport3 rpt, Selection selection, List<ARCtrlPropertyDispInfo> aRCtrlDispList)
		{
			this.SuspendLayout();

			_selection = selection;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
            _report = rpt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

			this.cmbSummaryGroup.Items.Clear();
			this.cmbSummaryGroup.Items.Add(string.Empty);
			foreach (ar.Section section in rpt.Sections)
			{
				if (section is ar.GroupHeader)
					this.cmbSummaryGroup.Items.Add(section.Name);
			}

			VisibleSetting(aRCtrlDispList);

			ShowPropertyData();

			this.ResumeLayout(true);
		}

		/// <summary>
		/// �I�����ڃR���{�{�b�N�X�X�V����
		/// </summary>
		/// <param name="rpt">ActiveReport�I�u�W�F�N�g</param>
		/// <param name="imageList">�摜LIST</param>
		/// <remarks>
		/// <br>Note		: �I�����ڃR���{�{�b�N�X�̓��e���X�V���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void UpdateSelectItemCombo(ar.ActiveReport3 rpt, ImageList imageList)
		{
			this.cmbSelectItem.Items.Clear();
			foreach (ar.Section section in rpt.Sections)
			{
				foreach (ar.ARControl aRControl in section.Controls)
				{
					ValueListItem valueListItem;
					valueListItem = this.cmbSelectItem.Items.Add(aRControl.Name, GetItemDispName(aRControl, _prtItemSetList));

					// ICON�̐ݒ�
					switch (aRControl.GetType().Name)
					{
						case "TextBox":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_TEXTBOX];	break;
						case "Label":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LABEL];		break;
						case "Picture":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_PICTURE];	break;
						case "Shape":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_SHAPE];		break;
						case "Line":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LINE];		break;
						case "Barcode":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_BARCODE];	break;
					}
				}
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ���ݒ菈��
		/// </summary>
		/// <param name="aRCtrlDispList">���R���[�v���p�e�B�\�����LIST</param>
		/// <remarks>
		/// <br>Note		: ���R���[�v���p�e�B�\���������Ɋe�p�l����Visible�ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void VisibleSetting(List<ARCtrlPropertyDispInfo> aRCtrlDispList)
		{
			foreach (Control control in this.Controls)
				control.Visible = true;

			foreach (Control control in this.Controls)
			{
				if (control.Tag != null && !control.Tag.ToString().Equals(string.Empty))
				{
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[control.Tag.ToString()];
						if (propertyInfo == null)
						{
							control.Visible = false;
							break;
						}
						else
						{
							// ����Ȑݒ��ʏ���
							if (_selection[ix] is ar.ARControl)
							{
								// Picture�̃o�C���h���ڂ͉摜�ݒ���s�킹�Ȃ�
								if (propertyInfo.Name == SFANL08105UA.ctPropName_Image)
								{
									ar.ARControl aRControl = (ar.ARControl)_selection[ix];
									PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
									if (prtItemSetWork != null)
									{
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                                        //if (prtItemSetWork.FreePrtPaperItemCd != (int)SFANL08105UA.FreePrtPaperItemCdKind.Picture)
                                        //    control.Visible = false;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                                        if ( prtItemSetWork.DDName != null && prtItemSetWork.DDName.Trim() != string.Empty )
                                        {
                                            // �o�C���h����f�[�^�t�B�[���h�����ݒ肳��Ă���ꍇ�͉摜�ݒ�s�v
                                            control.Visible = false;
                                        }
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
									}
								}
							}

							ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo
								= GetARCtrlPropertyDispInfo(aRCtrlDispList, _selection[ix].GetType().Name,propertyInfo.Name);
							if (aRCtrlPropertyDispInfo != null)
							{
								if (aRCtrlPropertyDispInfo.CanDisplay == 0)
								{
									control.Visible = false;
									break;
								}
							}
							else
							{
								control.Visible = false;
								break;
							}
						}
					}
				}
			}

			// ����Ȑݒ��ʏ���
			this.pnlPrintPageCtrlDivCd.Visible	= false;
			this.pnlGroupSuppressCd.Visible		= false;
			this.pnlDtlColorChangeCd.Visible	= false;
			this.pnlSummaryFunc.Visible			= false;
			this.pnlSummaryGroup.Visible		= false;
			this.pnlSummaryRunning.Visible		= false;
			this.pnlSummaryType.Visible			= false;
			this.pnlDataField.Visible			= false;

			// �P��I�����݂̂ɍs���鏈��
			if (_selection.Count == 1)
			{
				// �I�����ږ�
				PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[0])["Name"];
				if (propertyInfo != null)
					this.cmbSelectItem.Value = propertyInfo.GetValue(_selection[0]);

				if (_selection[0] is ar.ARControl)
				{
					ar.ARControl aRControl = (ar.ARControl)_selection[0];
					if (aRControl.Tag != null)
					{
						_isShowPropertyData = true;
						try
						{
							PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
							if (prtItemSetWork != null)
							{
								ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo = null;
								// Detail�ɔz�u����Ă�ꍇ�̂ݕҏW�\�ȍ��ڂ̏���
								if (aRControl.Parent is ar.Detail)
								{
									// �u�T�v���X�v�iTextBox�̎��̂ݗL���j
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "GroupSuppressCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlGroupSuppressCd.Visible = true;
									this.cmbGroupSuppressCd.Value = prtItemSetWork.GroupSuppressCd;

									// �u�Ԋ|���v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "DtlColorChangeCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlDtlColorChangeCd.Visible = true;
									this.cmbDtlColorChangeCd.Value = prtItemSetWork.DtlColorChangeCd;

									// �u�����̓����v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "HeightAdjustDivCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlHeightAdjustDivCd.Visible = true;
									this.cmbHeightAdjustDivCd.Value = prtItemSetWork.HeightAdjustDivCd;
								}

								// �u�󎚃y�[�W�v
								aRCtrlPropertyDispInfo
									= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "PrintPageCtrlDivCd");
								if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
									this.pnlPrintPageCtrlDivCd.Visible = true;
								this.cmbPrintPageCtrlDivCd.Items.Clear();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 DEL
                                //this.cmbPrintPageCtrlDivCd.Items.Add(0, "�S�y�[�W");
                                //this.cmbPrintPageCtrlDivCd.Items.Add(1, "1�y�[�W�ڂ̂�");
                                //if (aRControl.Parent is ar.GroupFooter)
                                //    this.cmbPrintPageCtrlDivCd.Items.Add(2, "�ŏI�y�[�W�̂�");
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                                if ( _frePrtPSet.PrintPaperUseDivcd == 2 )
                                {
                                    ulPrintPageCtrlDivCd.Text = "�󎚐���";
                                    ulPrintPageCtrlDivCd.Font = new Font( ulPrintPageCtrlDivCd.Font.OriginalFontName, 11 );

                                    if ( aRControl is ar.TextBox )
                                    {
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 0, "�S��" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 1, "�^�C�g���P�̂�" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 2, "�^�C�g���Q�̂�" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 3, "�^�C�g���R�̂�" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 4, "�^�C�g���S�̂�" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 5, "�^�C�g���T�̂�" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 6, "�^�C�g���P����" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 7, "�^�C�g���Q����" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 8, "�^�C�g���R����" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 9, "�^�C�g���S����" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 10, "�^�C�g���T����" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 11, "�^�C�g���P,�Q" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 12, "�^�C�g���P,�Q,�R" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 13, "�^�C�g���R,�S,�T" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 14, "�^�C�g���S,�T" );
                                    }
                                    else
                                    {
                                        // ��\���ɂ���
                                        this.pnlPrintPageCtrlDivCd.Visible = false;
                                    }
                                }
                                else
                                {
                                    ulPrintPageCtrlDivCd.Text = "�󎚃y�[�W";
                                    ulPrintPageCtrlDivCd.Font = new Font( ulPrintPageCtrlDivCd.Font.OriginalFontName, 9 );

                                    this.cmbPrintPageCtrlDivCd.Items.Add( 0, "�S�y�[�W" );
                                    this.cmbPrintPageCtrlDivCd.Items.Add( 1, "1�y�[�W�ڂ̂�" );
                                    if ( aRControl.Parent is ar.GroupFooter )
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 2, "�ŏI�y�[�W�̂�" );
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
								this.cmbPrintPageCtrlDivCd.Value = prtItemSetWork.PrintPageCtrlDivCd;

								// �W�v�֘A���ڂ́uFreePrtPaperItemCd=1�v�̂ݕҏW�\(��DataField�Ɋւ�镔��)
								if (prtItemSetWork.FreePrtPaperItemCd == 1)
								{
									// �u�W�v�֐��v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryFunc");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryFunc.Visible		= true;
									// �u�W�v�O���[�v�v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryGroup");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryGroup.Visible	= true;
									// �u�ݐϔ͈́v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryRunning");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryRunning.Visible	= true;
									// �u�W�v�^�C�v�v
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryType");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryType.Visible		= true;

									// �u�W�v���ځv
									this.cmbDataField.Items.Clear();
									if (_prtItemSetList != null)
									{
										List<PrtItemSetWork> wkPrtItemSetList
											= _prtItemSetList.FindAll(
												delegate(PrtItemSetWork wkPrtItemSetWork)
												{
													if (wkPrtItemSetWork.TotalItemDivCd == 1)
														return true;
													else
														return false;
												}
											);
										foreach (PrtItemSetWork wkPrtItemSet in wkPrtItemSetList)
											this.cmbDataField.Items.Add(FrePrtSettingController.CreateDataField(wkPrtItemSet), wkPrtItemSet.FreePrtPaperItemNm);
									}
									if (this.cmbDataField.Items.Count > 0)
									{
										this.cmbDataField.Items.Insert(0, string.Empty, "�@");
										aRCtrlPropertyDispInfo
											= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "DataField");
										if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
											this.pnlDataField.Visible = true;
									}
								}
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                                // �󎚉\�o�C�g��
                                aRCtrlPropertyDispInfo
                                    = GetARCtrlPropertyDispInfo( aRCtrlDispList, aRControl.GetType().Name, "PrintableByteCount" );
                                if ( aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1 )
                                {
                                    this.pnlPrintableByteCount.Visible = true;
                                }
                                else
                                {
                                    this.pnlPrintableByteCount.Visible = false;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
							}
						}
						finally
						{
							_isShowPropertyData = false;
						}
					}
				}
				else if (_selection[0] is ar.GroupHeader)
				{
					// DataField�\���Ɋւ��鐧��
					this.cmbDataField.Items.Clear();
					if (_prtItemSetList != null)
					{
						List<PrtItemSetWork> wkPrtItemSetList
							= _prtItemSetList.FindAll(
								delegate(PrtItemSetWork prtItemSetWork)
								{
									if (prtItemSetWork.FormFeedItemDivCd != 0)
										return true;
									else
										return false;
								}
							);
						foreach (PrtItemSetWork wkPrtItemSet in wkPrtItemSetList)
							this.cmbDataField.Items.Add(FrePrtSettingController.CreateDataField(wkPrtItemSet), wkPrtItemSet.FreePrtPaperItemNm);
					}
					if (this.cmbDataField.Items.Count > 0)
					{
						this.cmbDataField.Items.Insert(0, string.Empty, "�@");
						ARCtrlPropertyDispInfo�@aRCtrlPropertyDispInfo
							= GetARCtrlPropertyDispInfo(aRCtrlDispList, _selection[0].GetType().Name, "DataField");
						if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
							this.pnlDataField.Visible = true;
					}
				}
				else if (_selection[0] is ar.ActiveReport3)
				{
					// �I�����ږ����󔒂ɂ���
					this.cmbSelectItem.SelectedIndex = -1;
				}
			}
			else
			{
				// �I�����ږ����󔒂ɂ���
				this.cmbSelectItem.SelectedIndex = -1;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �P�ʃe�L�X�g�ݒ�
            string unitText = _cmInchControl.GetTitle();

            List<UltraLabel> labelList = new List<UltraLabel>( new UltraLabel[] { ulUnitTop, ulUnitLeft, ulUnitWidth, ulUnitHeight, ulLineWeightUnit } );

            foreach ( UltraLabel label in labelList )
            {
                label.Text = unitText;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// �R���g���[���\�����N���X�擾����
		/// </summary>
		/// <param name="aRCtrlDispList">�擾���R���g���[���\�����LIST</param>
		/// <param name="typeName">�R���g���[���^�C�v����</param>
		/// <param name="propertyName">�v���p�e�B����</param>
		/// <returns>�R���g���[���\�����N���X</returns>
		/// <remarks>
		/// <br>Note		: �R���g���[���\�������擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private ARCtrlPropertyDispInfo GetARCtrlPropertyDispInfo(List<ARCtrlPropertyDispInfo> aRCtrlDispList, string typeName, string propertyName)
		{
			ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo
				= aRCtrlDispList.Find(
					delegate(ARCtrlPropertyDispInfo dispInfo)
					{
						if (dispInfo.ARControlTypeName.Equals(typeName) &&
							dispInfo.PropertyName.Equals(propertyName))
							return true;
						else
							return false;
					}
				 );

			return aRCtrlPropertyDispInfo;
		}

		/// <summary>
		/// �v���p�e�B���\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �v���p�e�B����\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowPropertyData()
		{
			_isShowPropertyData = true;
			try
			{
				// �e�v���p�e�B�ݒ��ʂ̍\�z
				foreach (Control control in this.Controls)
				{
					Panel panel = control as Panel;
                    if ( panel != null && panel.Visible )
					{
						foreach (Control targetCtrl in panel.Controls)
						{
							if (targetCtrl.Tag != null && !targetCtrl.Tag.ToString().Equals(string.Empty))
							{
								// �o�����[�������푶�݂��邩�̔��f�p
								object buffObj		= null;
								bool isMultiValue	= false;

								// �f�[�^���擾�y�щ�ʂւ̃Z�b�g
								for (int ix = 0 ; ix < _selection.Count ; ix++)
								{
									PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[panel.Tag.ToString()];
									if (propertyInfo != null)
									{
										if (buffObj != null)
										{
											if (!object.Equals(buffObj, propertyInfo.GetValue(_selection[ix])))
												isMultiValue = true;
										}
										else
										{
											buffObj = propertyInfo.GetValue(_selection[ix]);
                                        }

                                        # region [propertyInfo.Name]
                                        switch (propertyInfo.Name)
										{
											case SFANL08105UA.ctPropName_Text:
											case SFANL08105UA.ctPropName_Caption:
											{
												TEdit tEdit = (TEdit)targetCtrl;
												if (isMultiValue)
													tEdit.Clear();
												else
													tEdit.Text = propertyInfo.GetValue(_selection[ix]) as string;
												break;
											}
											case SFANL08105UA.ctPropName_Top:
											case SFANL08105UA.ctPropName_Left:
											case SFANL08105UA.ctPropName_Width:
											case SFANL08105UA.ctPropName_Height:
											case SFANL08105UA.ctPropName_X1:
											case SFANL08105UA.ctPropName_X2:
											case SFANL08105UA.ctPropName_Y1:
											case SFANL08105UA.ctPropName_Y2:
											{
												TNedit tNedit = (TNedit)targetCtrl;
												if (isMultiValue)
												{
													tNedit.Clear();
												}
												else
												{
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                                    //float centi = ar.ActiveReport3.InchToCm((float)propertyInfo.GetValue(_selection[ix]));
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                                    float centi = _cmInchControl.ToDisp( (float)propertyInfo.GetValue( _selection[ix] ) );
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
													tNedit.SetValue(centi);
												}
												break;
											}
											case SFANL08105UA.ctPropName_LineWeight:
											{
												TNedit tNedit = (TNedit)targetCtrl;
												if (isMultiValue)
												{
													tNedit.Clear();
												}
												else
												{
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                                    //float centi = ar.ActiveReport3.InchToCm(((float)propertyInfo.GetValue(_selection[ix]) / 144));
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                                    float centi = _cmInchControl.ToDisp( ((float)propertyInfo.GetValue( _selection[ix] ) / 144) );
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
													tNedit.SetValue((float)FrePrtSettingController.ToHalfAdjust(centi, 2));
												}
												break;
											}
											case SFANL08105UA.ctPropName_Font:
											{
												Font font = (Font)propertyInfo.GetValue(_selection[ix]);
												if (isMultiValue)
												{
													this.ufnFontName.SelectedIndex = -1;
													this.uceBold.Checked		= false;
													this.uceItalic.Checked		= false;
													this.uceUnderLine.Checked	= false;
													this.cmbFontSize.Value		= 11;
												}
												else
												{
													this.ufnFontName.Value		= font.Name;
													this.uceBold.Checked		= font.Bold;
													this.uceItalic.Checked		= font.Italic;
													this.uceUnderLine.Checked	= font.Underline;
													this.cmbFontSize.Value		= font.Size;
												}
												break;
											}
											case SFANL08105UA.ctPropName_BackColor:
											case SFANL08105UA.ctPropName_ForeColor:
											case SFANL08105UA.ctPropName_LineColor:
											{
												UltraColorPicker ultraColorPicker = (UltraColorPicker)targetCtrl;
												if (isMultiValue)
													ultraColorPicker.Clear();
												else
													ultraColorPicker.Color = (Color)propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_WordWrap:
											case SFANL08105UA.ctPropName_MultiLine:
											case SFANL08105UA.ctPropName_Visible:
											case SFANL08105UA.ctPropName_CanShrink:
											case SFANL08105UA.ctPropName_CanGrow:
											case SFANL08105UA.ctPropName_PrintAtBottom:
											case SFANL08105UA.ctPropName_KeepTogether:
											{
												UltraCheckEditor ultraCheckEditor = (UltraCheckEditor)targetCtrl;
												if (isMultiValue)
													ultraCheckEditor.CheckState	= CheckState.Indeterminate;
												else
													ultraCheckEditor.Checked	= (bool)propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_Alignment:
											case SFANL08105UA.ctPropName_VAlignment:
											case SFANL08105UA.ctPropName_LineStyle:
											case SFANL08105UA.ctPropName_Style:
											case SFANL08105UA.ctPropName_PictureAlign:
											case SFANL08105UA.ctPropName_SizeMode:
											case SFANL08105UA.ctPropName_OutputFormat:
											case SFANL08105UA.ctPropName_NewPage:
											case SFANL08105UA.ctPropName_RepeatStyle:
											case SFANL08105UA.ctPropName_SummaryRunning:
											case SFANL08105UA.ctPropName_SummaryFunc:
											case SFANL08105UA.ctPropName_SummaryType:
											case SFANL08105UA.ctPropName_SummaryGroup:
											{
												TComboEditor tComboEditor = (TComboEditor)targetCtrl;
												if (isMultiValue)
													tComboEditor.SelectedIndex = -1;
												else
													tComboEditor.Value = propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_DataField:
											{
												TComboEditor tComboEditor = (TComboEditor)targetCtrl;
												tComboEditor.Value = propertyInfo.GetValue(_selection[ix]);
												break;
											}
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                            case SFANL08105UA.ctPropName_CharacterSpacing:
                                            {
                                                TNedit tNedit = (TNedit)targetCtrl;
                                                tNedit.Value = propertyInfo.GetValue( _selection[ix] );
                                                break;
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                        }
                                        # endregion

                                        if (isMultiValue) break;
                                    }

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                                    if ( panel.Tag.ToString() == SFANL08105UA.ctPropName_PrintableByteCount )
                                    {
                                        TEdit tEdit = (TEdit)targetCtrl;

                                        if ( _selection[ix] is ar.TextBox )
                                        {
                                            
                                            int minCount;
                                            int maxCount;
                                            Broadleaf.Drawing.Printing.PMCMN02000CA.GetPrintableByteCount( (_selection[ix] as ar.TextBox), out minCount, out maxCount );
                                            if ( minCount == maxCount )
                                            {
                                                tEdit.Text = string.Format( "{0}", minCount );
                                            }
                                            else
                                            {
                                                tEdit.Text = string.Format( "{0}�`{1}", minCount, maxCount );
                                            }
                                        }
                                        else
                                        {
                                            tEdit.Text = string.Empty;
                                        }
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
                                }
							}
						}
					}
				}

				TextCaptionSetting();
			}
			finally
			{
				_isShowPropertyData = false;
			}
		}

		/// <summary>
		/// Text�v���p�e�B�p�p�l��Caption�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: Text�v���p�e�B�p�̃p�l�����ɂ���Caption��ݒ肵�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TextCaptionSetting()
		{
			if (pnlText.Visible && _selection != null)
			{
				bool existTextBox = false;
				bool existLabel = false;
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					if (existTextBox && existLabel) break;

					if (!existTextBox && _selection[ix] is ar.TextBox)
					{
						existTextBox = true;
						continue;
					}
					else if (!existLabel && _selection[ix] is ar.Label)
					{
						existLabel = true;
						continue;
					}
				}

				if (existTextBox && existLabel)
					this.ulText.Text = string.Empty;
				else if (existTextBox)
					this.ulText.Text = "�e�X�g����";
				else if (existLabel)
					this.ulText.Text = "�󎚕���";
			}
		}

		/// <summary>
		/// �t�H���g���X�V����
		/// </summary>
		/// <param name="upDateItemCode">�X�V����(0:FontFamily,1:Size,2:Style)</param>
		/// <remarks>
		/// <br>Note		: �t�H���g�����X�V���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void UpdateFontInfo(int upDateItemCode)
		{
			for (int ix = 0 ; ix < _selection.Count ; ix++)
			{
				Font oldFont;
				PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])["Font"];
				if (propertyInfo != null)
				{
					oldFont = (Font)propertyInfo.GetValue(_selection[ix]);

					FontFamily fontFamily	= oldFont.FontFamily;
					float fontSize			= oldFont.Size;
					FontStyle fontStyle		= oldFont.Style;
					switch (upDateItemCode)
					{
						case 0:
						{
							fontFamily = new FontFamily(this.ufnFontName.Value.ToString());
							break;
						}
						case 1:
						{
							float newFontSize = (float)TStrConv.StrToDoubleDef(this.cmbFontSize.Text, 1);
							if (newFontSize >= 1)
							{
								fontSize = newFontSize;
							}
							else
							{
								this.cmbFontSize.Value = 1;
								fontSize = 1;
							}
							break;
						}
						case 2:
						{
							if (this.uceBold.Checked && this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;
							else if (!this.uceBold.Checked && this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Italic | FontStyle.Underline;
							else if (this.uceBold.Checked && !this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Underline;
							else if (this.uceBold.Checked && this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Italic;
							else if (this.uceBold.Checked && !this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold;
							else if (!this.uceBold.Checked && this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Italic;
							else if (!this.uceBold.Checked && !this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Underline;
							else
								fontStyle = FontStyle.Regular;
							break;
						}
					}

					Font newFont = new Font(fontFamily, fontSize, fontStyle);

					propertyInfo.SetValue(_selection[ix], newFont);
				}
			}
		}

		/// <summary>
		/// ���ڕ\�����̎擾����
		/// </summary>
		/// <param name="aRControl">�R���g���[��</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <returns>�\������</returns>
		/// <remarks>
		/// <br>Note		: ���ڂ̕\�����̂��擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string GetItemDispName(ar.ARControl aRControl, List<PrtItemSetWork> prtItemSetList)
		{
			string dispName = string.Empty;
			
			PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, prtItemSetList);
			if (prtItemSet != null)
			{
				if (prtItemSet.FreePrtPaperItemCd == 1 && aRControl is ar.TextBox)
				{
					ar.TextBox textBox = (ar.TextBox)aRControl;
					if (!string.IsNullOrEmpty(textBox.DataField))
					{
						PrtItemSetWork dataFieldPrtItemSet = prtItemSetList.Find(
								delegate(PrtItemSetWork wkPrtItemSetWork)
								{
									if (FrePrtSettingController.CreateDataField(wkPrtItemSetWork) == textBox.DataField)
										return true;
									else
										return false;
								}
							);
						if (dataFieldPrtItemSet != null)
							dispName = prtItemSet.FreePrtPaperItemNm + " - " + dataFieldPrtItemSet.FreePrtPaperItemNm;
						else
							dispName = prtItemSet.FreePrtPaperItemNm;
					}
					else
					{
						dispName = prtItemSet.FreePrtPaperItemNm;
					}
				}
				else
				{
					dispName = prtItemSet.FreePrtPaperItemNm;
				}
			}
			else
			{
				if (aRControl is ar.TextBox)
					dispName = ((ar.TextBox)aRControl).Text;
				else if (aRControl is ar.Label)
					dispName = ((ar.Label)aRControl).Text;
				else
					dispName = aRControl.Name;
			}

			return dispName;
		}
		#endregion

		#region Event
		/// <summary>
		/// �R���g���[��Leave�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ��Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_Leave(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				switch (sender.GetType().Name)
				{
					case "TEdit":
					{
						TEdit tEdit = (TEdit)sender;
						if (!_buffText.Equals(tEdit.Text) && tEdit.Tag != null && !tEdit.Tag.Equals(string.Empty))
						{
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tEdit.Tag.ToString()];
								if (propertyInfo != null)
									propertyInfo.SetValue(_selection[ix], tEdit.Text);
							}
						}
						break;
					}
					case "TNedit":
					{
						TNedit tNedit = (TNedit)sender;
						double nowValue = TStrConv.StrToDoubleDef(tNedit.Text, -1);
						if (!_buffCode.Equals(nowValue) && tNedit.Tag != null && !tNedit.Tag.Equals(string.Empty))
						{
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								switch (tNedit.Tag.ToString())
								{
									case SFANL08105UA.ctPropName_Top:
									case SFANL08105UA.ctPropName_Left:
									case SFANL08105UA.ctPropName_Width:
									case SFANL08105UA.ctPropName_Height:
									case SFANL08105UA.ctPropName_X1:
									case SFANL08105UA.ctPropName_X2:
									case SFANL08105UA.ctPropName_Y1:
									case SFANL08105UA.ctPropName_Y2:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
										{
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                            //float inch = ar.ActiveReport3.CmToInch((float)tNedit.GetValue());
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                            float inch = _cmInchControl.ToData( (float)tNedit.GetValue() );
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
											propertyInfo.SetValue(_selection[ix], (float)inch);
										}
										break;
									}
									case SFANL08105UA.ctPropName_LineWeight:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
										{
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                            //float inch = ar.ActiveReport3.CmToInch((float)tNedit.GetValue());
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                            float inch = _cmInchControl.ToData( (float)tNedit.GetValue() );
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
											propertyInfo.SetValue(_selection[ix], Convert.ToInt32(inch * 144));
										}
										break;
									}
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                    case SFANL08105UA.ctPropName_CharacterSpacing:
                                    {
                                        PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties( _selection[ix] )[tNedit.Tag.ToString()];
                                        if ( propertyInfo != null )
                                            propertyInfo.SetValue( _selection[ix], (Single)tNedit.GetValue() );
                                        break;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
									default:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
											propertyInfo.SetValue(_selection[ix], tNedit.GetInt());
										break;
									}
								}
							}
						}
						break;
					}
					case "TComboEditor":
					{
						TComboEditor tComboEditor = (TComboEditor)sender;
						double code = TStrConv.StrToDoubleDef(tComboEditor.Text, 0);
						if (!_buffCode.Equals(code) && tComboEditor.Tag != null && !tComboEditor.Tag.Equals(string.Empty))
						{
							UpdateFontInfo(1);
						}
						break;
					}
					case "UltraFontNameEditor":
					{
						UltraFontNameEditor ultraFontNameEditor = (UltraFontNameEditor)sender;
						ultraFontNameEditor.Appearance.BackColor = Color.White;
						break;
					}
					case "UltraColorPicker":
					{
						UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
						ultraColorPicker.Appearance.BackColor = Color.White;
						break;
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �R���g���[��Enter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_Enter(object sender, EventArgs e)
		{
			switch (sender.GetType().Name)
			{
				case "TEdit":
				{
					TEdit tEdit = (TEdit)sender;
					_buffText = tEdit.Text;
					break;
				}
				case "TNedit":
				{
					TNedit tNedit = (TNedit)sender;
					_buffCode = TStrConv.StrToDoubleDef(tNedit.Text, -1);
					break;
				}
				case "TComboEditor":
				{
					TComboEditor tComboEditor = (TComboEditor)sender;
					_buffCode = TStrConv.StrToDoubleDef(tComboEditor.Text, 0);
					break;
				}
				case "UltraColorPicker":
				{
					UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
					ultraColorPicker.Appearance.BackColor = this.cmbSelectItem.ActiveAppearance.BackColor;
					break;
				}
				case "UltraFontNameEditor":
				{
					UltraFontNameEditor ultraFontNameEditor = (UltraFontNameEditor)sender;
					ultraFontNameEditor.Appearance.BackColor = this.cmbSelectItem.ActiveAppearance.BackColor;
					break;
				}
			}
		}

		/// <summary>
		/// ColorChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �F���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Color_Changed(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
				if (ultraColorPicker.Tag != null && !ultraColorPicker.Tag.Equals(string.Empty))
				{
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[ultraColorPicker.Tag.ToString()];
						if (propertyInfo != null)
							propertyInfo.SetValue(_selection[ix], ultraColorPicker.Color);
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �R���g���[��CheckedChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: Checked�v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_CheckedChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				UltraCheckEditor ultraCheckEditor = (UltraCheckEditor)sender;
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					switch (ultraCheckEditor.Tag.ToString())
					{
						case SFANL08105UA.ctPropName_Bold:
						case SFANL08105UA.ctPropName_Italic:
						case SFANL08105UA.ctPropName_UnderLine:
						{
							UpdateFontInfo(2);
							break;
						}
						default:
						{
							PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[ultraCheckEditor.Tag.ToString()];
							if (propertyInfo != null)
								propertyInfo.SetValue(_selection[ix], ultraCheckEditor.Checked);
							break;
						}
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �R���g���[��SelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_ValueChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				switch (sender.GetType().Name)
				{
					case "TComboEditor":
					{
						if (sender == this.cmbFontSize)
						{
							UpdateFontInfo(1);
						}
						else if (sender == this.cmbPrintPageCtrlDivCd ||
							sender == this.cmbGroupSuppressCd ||
							sender == this.cmbDtlColorChangeCd || 
							sender == this.cmbHeightAdjustDivCd)
						{
							ar.ARControl aRControl = _selection[0] as ar.ARControl;
							if (aRControl != null)
							{
								int printPageCtrlDivCd	= 0;
								int groupSuppressCd		= 0;
								int dtlColorChangeCd	= 0;
								int heightAdjustDivCd	= 0;
								if (this.cmbPrintPageCtrlDivCd.Value != null)
									int.TryParse(this.cmbPrintPageCtrlDivCd.Value.ToString(), out printPageCtrlDivCd);
								if (this.cmbGroupSuppressCd.Value != null)
									int.TryParse(this.cmbGroupSuppressCd.Value.ToString(), out groupSuppressCd);
								if (this.cmbDtlColorChangeCd.Value != null)
									int.TryParse(this.cmbDtlColorChangeCd.Value.ToString(), out dtlColorChangeCd);
								if (this.cmbHeightAdjustDivCd.Value != null)
									int.TryParse(this.cmbHeightAdjustDivCd.Value.ToString(), out heightAdjustDivCd);

								PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
								if (prtItemSet != null)
								{
									prtItemSet.PrintPageCtrlDivCd	= printPageCtrlDivCd;
									prtItemSet.GroupSuppressCd		= groupSuppressCd;
									prtItemSet.DtlColorChangeCd		= dtlColorChangeCd;
									prtItemSet.HeightAdjustDivCd	= heightAdjustDivCd;
									aRControl.Tag = FrePrtSettingController.GetARControlTagInfo(prtItemSet);

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                                    // �`�[�ň󎚃y�[�W�敪��ύX�������̂݁A
                                    // �����DataField�̍��ڂ̈󎚃y�[�W�敪���X�V����B
                                    if ( _frePrtPSet.PrintPaperUseDivcd == 2 && sender == this.cmbPrintPageCtrlDivCd )
                                    {
                                        foreach ( ar.Section section in _report.Sections )
                                        {
                                            foreach ( ar.ARControl control in section.Controls )
                                            {
                                                if ( control.DataField == aRControl.DataField && control != aRControl )
                                                {
                                                    PrtItemSetWork wkPrtItemSet = FrePrtSettingController.GetPrtItemSet( control, _prtItemSetList );
                                                    if ( wkPrtItemSet != null )
                                                    {
                                                        // �󎚃y�[�W�敪���X�V
                                                        wkPrtItemSet.PrintPageCtrlDivCd = printPageCtrlDivCd;
                                                        control.Tag = FrePrtSettingController.GetARControlTagInfo( wkPrtItemSet );
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
								}
							}
						}
						else
						{
							TComboEditor tComboEditor = (TComboEditor)sender;
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tComboEditor.Tag.ToString()];
								if (propertyInfo != null)
									propertyInfo.SetValue(_selection[ix], tComboEditor.Value);
							}
						}
						break;
					}
					case "UltraFontNameEditor":
					{
						UpdateFontInfo(0);
						break;
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �摜�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �摜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubImage_Click(object sender, EventArgs e)
		{
			_isNowWorking = true;
			try
			{
				DialogResult dlgRet = this.openFileDialog.ShowDialog();
				if (dlgRet == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(this.openFileDialog.FileName);
					if (fileInfo != null && fileInfo.Length > 1000000)
					{
						string message = "�t�@�C���T�C�Y�̑傫���摜���I������܂����B"
							+ Environment.NewLine + Environment.NewLine
							+ "�ۑ��E�ďo�Ɏ��Ԃ�������悤�ɂȂ�܂����K�p���܂����H";
						dlgRet = TMsgDisp.Show(
							emErrorLevel.ERR_LEVEL_QUESTION,
							SFANL08105UH.ctASSEMBLY_ID,
							message,
							0,
							MessageBoxButtons.OKCancel);
					}
				}

				if (dlgRet == DialogResult.OK)
				{
					// Image.FromFile��Dispose�ŉ摜�t�@�C���̃��b�N�����
					Image image = Image.FromFile(this.openFileDialog.FileName);
					Bitmap bitmap = new Bitmap(image);
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						if (_selection[ix] is ar.Picture)
						{
							ar.Picture picture = (ar.Picture)_selection[ix];
							picture.Image = bitmap;
						}
					}
					image.Dispose();
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �摜�N���A�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �摜�N���A�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubImageClear_Click(object sender, EventArgs e)
		{
			_isNowWorking = true;
			try
			{
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					if (_selection[ix] is ar.Picture)
					{
						ar.Picture picture = (ar.Picture)_selection[ix];
						picture.ResetImage();
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// �I�����ڃR���{�{�b�N�XSelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbSelectItem_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.cmbSelectItem.Value != null && !_isShowPropertyData)
				SelectedARControlNameChanged(this.cmbSelectItem.Value.ToString());
		}

		/// <summary>
		/// KeyPress�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[�J�X�������Ă��āA</br>
		/// <br>			: ���[�U�[���L�[�������ė������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbFontSize_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!SFANL08105UH.KeyPressCheck(this.cmbFontSize.MaxLength, 2, this.cmbFontSize.Text, e.KeyChar, this.cmbFontSize.SelectionStart, this.cmbFontSize.SelectionLength, false))
				e.Handled = true;
		}

		/// <summary>
		/// ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̒l���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TEdit_ValueChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			TEdit tEdit = (TEdit)sender;
			if (tEdit.Tag != null && !tEdit.Tag.Equals(string.Empty))
			{
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tEdit.Tag.ToString()];
					if (propertyInfo != null)
						propertyInfo.SetValue(_selection[ix], tEdit.Text);
				}
			}
		}

		/// <summary>
		/// tArrowKeyControl1_ChangeFocus�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �J�[�\�����ړ����鎞�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			switch (e.Key)
			{
				case Keys.Enter:
				{
					if (!this.Contains(e.NextCtrl))
						e.NextCtrl = this.cmbSelectItem;
					break;
				}
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
				{
					if (!this.Contains(e.NextCtrl))
						e.NextCtrl = null;
					break;
				}
			}

			if (e.PrevCtrl == this.tedText && this.tedText.IsInEditMode)
			{
				// �I�𕶎�������ꍇ�͓��̓L�[�ɉ����ăJ�[�\���ʒu��ω�������
				if (this.tedText.SelectionLength > 0)
				{
                    if (e.Key == Keys.Up)
                    {
                        this.tedText.Select(this.tedText.SelectionStart, 0);
                        e.NextCtrl = null;
                        this.tedText.ScrollToCaret();
                    }
                    else if (e.Key == Keys.Down)
                    {
                        this.tedText.Select(this.tedText.SelectionStart + this.tedText.SelectionLength, 0);
                        e.NextCtrl = null;
                        this.tedText.ScrollToCaret();
                    }
				}
			}
		}

		/// <summary>
		/// DataField�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: DataField�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDataField_Click(object sender, EventArgs e)
		{
			if (_prtItemSetList != null && _prtItemSetList.Count > 0)
			{
				if (_prtItemGrpAcs == null)
					_prtItemGrpAcs = new PrtItemGrpAcs();

				int freePrtPprItemGrpCd	= _prtItemSetList[0].FreePrtPprItemGrpCd;
				int totalItemDivCd		= 0;
				int formFeedItemDivCd	= 0;

				if (_selection[0] is ar.ARControl)
					totalItemDivCd		= 1;
				if (_selection[0] is ar.Section)
					formFeedItemDivCd	= 1;

				PrtItemSetWork prtItemSetWork;
				DialogResult dlgRet = _prtItemGrpAcs.ExecuteGuide(freePrtPprItemGrpCd, totalItemDivCd, formFeedItemDivCd, _prtItemSetList, out prtItemSetWork);
				if (dlgRet == DialogResult.OK)
				{
					this.cmbDataField.Value = FrePrtSettingController.CreateDataField(prtItemSetWork);
					if (this.cmbSelectItem.SelectedIndex >= 0 && _selection[0] is ar.ARControl)
					{
						ar.ARControl aRControl = (ar.ARControl)_selection[0];
						this.cmbSelectItem.SelectedItem.DisplayText = GetItemDispName(aRControl, _prtItemSetList);
						this.cmbSelectItem.Refresh();
					}
				}
			}
		}

		/// <summary>
		/// DataField�N���A�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: DataField�N���A�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDataFieldClear_Click(object sender, EventArgs e)
		{
			this.cmbDataField.Value = 0;
			if (this.cmbSelectItem.SelectedIndex >= 0 && _selection[0] is ar.ARControl)
			{
				ar.ARControl aRControl = (ar.ARControl)_selection[0];
				this.cmbSelectItem.SelectedItem.DisplayText = GetItemDispName(aRControl, _prtItemSetList);
				this.cmbSelectItem.Refresh();
			}
		}

		/// <summary>
		/// MouseEnterElement�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X���v�f�̎l�p�`�ɓ��������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TComboEditor_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow = e.Element.GetContext(typeof(TComboEditor));
			if (objContextRow != null)
			{
				TComboEditor tComboEditor = objContextRow as TComboEditor;

				int strWidth = FrePrtSettingController.GetStringWidth(tComboEditor);
				if (tComboEditor.ReadOnly && !tComboEditor.Text.Trim().Equals(string.Empty) && strWidth > tComboEditor.Width)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipText	= tComboEditor.Text;

					this.ultraToolTipManager.SetUltraToolTip(tComboEditor, ultraToolTipInfo);
					this.ultraToolTipManager.Enabled = true;
				}
			}
		}

		/// <summary>
		/// MouseLeaveElement�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X���v�f�̎l�p�`���痣�ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TComboEditor_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// �c�[���`�b�v���\���ɂ���
			this.ultraToolTipManager.HideToolTip();
			this.ultraToolTipManager.Enabled = false;
		}

		/// <summary>
		/// �W�v�^�C�v�R���{�{�b�N�XSelectionChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbSummaryType_SelectionChanged(object sender, EventArgs e)
		{
			switch ((ar.SummaryType)this.cmbSummaryType.Value)
			{
				case ar.SummaryType.SubTotal:
				{
					this.cmbSummaryGroup.Enabled = true;
					break;
				}
				default:
				{
					this.cmbSummaryGroup.Enabled = false;
					break;
				}
			}
		}
		#endregion
	}
}
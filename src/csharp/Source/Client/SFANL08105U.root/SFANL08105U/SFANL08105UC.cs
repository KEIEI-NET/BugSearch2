using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�S�̏��ݒ���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒu�f�[�^�̑S�̂Ɋւ�����ݒ肷���ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UC : UserControl
	{
		#region Enum
		/// <summary>�ݒ�ύX�^�C�v</summary>
		public enum ChangedType
		{
			/// <summary>�󎚈ʒu</summary>
			PrintPos,
			/// <summary>�^�C�g���E�R�����g</summary>
			Comment,
			/// <summary>�������摜</summary>
			Watermark,
		}
		#endregion

		#region PrivateMember
		private bool _isNowWorking;
		// �������摜�p
		private Image _watermark;
		// �ύX�`�F�b�N�p�e�L�X�g
		private string _bufText = string.Empty;
		// �ύX�`�F�b�N�p�R�[�h
		private double _bufCode;
		// �S�̐ݒ�ύX�C�x���g�n���h��
		internal event EventHandler WholeSettingChanged;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        // �Z���`�E�C���`����
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UC()
		{
			InitializeComponent();

			this.ubReference.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.ubClear.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];

			this.cmbPaperName.Items.Clear();
			this.cmbPaperName.Items.Add(PaperKind.A3, "�`�R");
			this.cmbPaperName.Items.Add(PaperKind.A4, "�`�S");
			this.cmbPaperName.Items.Add(PaperKind.A5, "�`�T");
			this.cmbPaperName.Items.Add(PaperKind.B4, "�a�S");
			this.cmbPaperName.Items.Add(PaperKind.B5, "�a�T");
			this.cmbPaperName.Items.Add(PaperKind.JapanesePostcard, "�͂���");
			//this.cmbPaperName.Items.Add(PaperKind.Custom, "�J�X�^��");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            this.cmbPaperName.Items.Add( PaperKind.Custom, "�J�X�^��" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

			this.uosOrientation.Items.Clear();
			this.uosOrientation.Items.Add(PageOrientation.Landscape,	"��");
			this.uosOrientation.Items.Add(PageOrientation.Portrait,		"�c");
			this.uosOrientation.CheckedIndex = 0;

			this.cmbEdgeCharProcDivCd.Items.Clear();
			this.cmbEdgeCharProcDivCd.Items.Add(0,	"�@");
			this.cmbEdgeCharProcDivCd.Items.Add(1,	"�[�����؎̂�");
			this.cmbEdgeCharProcDivCd.Items.Add(2,	"�t�H���g�k��");
		}
		#endregion

		#region Property
		/// <summary>�������t���O</summary>
		public bool IsNowWorking
		{
			get { return _isNowWorking; }
		}

		/// <summary>�������摜</summary>
		public Image Watermark
		{
			get { return _watermark; }
			set { _watermark = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>�������摜�@�J�n�ʒu��</summary>
        public double WatermarkPosLeft
        {
            get { return this.ndtWatermarkLeft.GetValue(); }
        }
        /// <summary>�������摜�@�J�n�ʒu��</summary>
        public double WatermarkPosTop
        {
            get { return this.ndtWatermarkTop.GetValue(); }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
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
		/// �S�̐ݒ�\������
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="rpt">ActiveReport�I�u�W�F�N�g</param>
		/// <param name="isContractFreeSheetgMng">���R���[�Ǘ��I�v�V�����t���O</param>
		/// <remarks>
		/// <br>Note		: ���������ɑS�̐ݒ��\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void ShowWholeSetting(FrePrtPSet frePrtPSet, ar.ActiveReport3 rpt, bool isContractFreeSheetgMng)
		{
			if (frePrtPSet != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                // ���[�h�c
                this.tedPrtFormId.Text = frePrtPSet.OutputFormFileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				// �\������
				this.tedDisplayName.Text			= frePrtPSet.DisplayName;
				// �o�͊m�F���b�Z�[�W
				this.tedOutConfimationMsg.Text		= frePrtPSet.OutConfimationMsg;
				// �R�����g�i���[�U�[�j
				this.tedPrtPprUserDerivNoCmt.Text	= frePrtPSet.PrtPprUserDerivNoCmt;
				// ���ōs��
				this.ndtFormFeedLineCount.SetInt(frePrtPSet.FormFeedLineCount);
				// ���s������
				this.ndtCrCharCnt.SetInt(frePrtPSet.CrCharCnt);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// ���[�w�i�摜�c�ʒu
                //this.ndtWatermarkTop.SetValue(frePrtPSet.PrtPprBgImageRowPos);
                //// ���[�w�i�摜���ʒu
                //this.ndtWatermarkLeft.SetValue(frePrtPSet.PrtPprBgImageColPos);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // ���[�w�i�摜�c�ʒu
                this.ndtWatermarkTop.SetValue( _cmInchControl.ToDisp( ar.ActiveReport3.CmToInch( (float)frePrtPSet.PrtPprBgImageRowPos ) ) );
                // ���[�w�i�摜���ʒu
                this.ndtWatermarkLeft.SetValue( _cmInchControl.ToDisp( ar.ActiveReport3.CmToInch( (float)frePrtPSet.PrtPprBgImageColPos ) ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// �������摜
				this.pnlWatermark.BackgroundImage	= _watermark;
				// �[���������敪
				this.cmbEdgeCharProcDivCd.Value		= frePrtPSet.EdgeCharProcDivCd;
				// ���הw�i�F
				this.ucpDetailBackColor.Color		= frePrtPSet.GetDetailBackColor();

				// ��ʂ̓��͐���
				if (frePrtPSet.UpdateDateTime != DateTime.MinValue)
					ChangeControlEnabled(frePrtPSet.PrintPaperUseDivcd, isContractFreeSheetgMng, true);
				else
					ChangeControlEnabled(frePrtPSet.PrintPaperUseDivcd, isContractFreeSheetgMng, false);
			}

			if (rpt != null)
			{
				// �p�����
				this.cmbPaperName.Value = rpt.PageSettings.PaperKind;
				// �T�|�[�g���Ă��Ȃ��p����ʂ̏ꍇ��Custom�ɂ���
				if (this.cmbPaperName.Value == null) this.cmbPaperName.Value = PaperKind.A4;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// �]���ݒ�
                //this.ndtMarginTop.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Top), 2));
                //this.ndtMarginBottom.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Bottom), 2));
                //this.ndtMarginRight.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Right), 2));
                //this.ndtMarginLeft.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Left), 2));
                //// �p����
                //this.ndtPrintWidth.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PrintWidth), 2));
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                //// �p������
                //this.ndtPrintHeight.SetValue( FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( rpt.PageSettings.PaperHeight ), 2 ) );
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // �]���ݒ�
                this.ndtMarginTop.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp( rpt.PageSettings.Margins.Top ), 2 ) );
                this.ndtMarginBottom.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Bottom ), 2 ) );
                this.ndtMarginRight.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Right ), 2 ) );
                this.ndtMarginLeft.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Left ), 2 ) );
                // �p����
                this.ndtPrintWidth.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PrintWidth ), 2 ) );
                // �p������
                this.ndtPrintHeight.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.PaperHeight ), 2 ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// �󎚕���
				this.uosOrientation.Value = (PageOrientation)rpt.PageSettings.Orientation;

				// UltraOptionSet�ɂ�ReadOnly�������ׁAEnabled=false�̎���
				// �I������Ă鍀�ڂ̃L���v�V���������ɐݒ肷�邱�Ƃŋ[���I��ReadOnly��ԂƂ���
				if (!this.uosOrientation.Enabled)
				{
					foreach (ValueListItem item in this.uosOrientation.Items)
					{
						if (item.DataValue == this.uosOrientation.Value)
							item.Appearance.ForeColorDisabled = Color.Black;
						else
							item.Appearance.ResetForeColorDisabled();
					}
				}
			}

			ShowPaperSizeComment();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // �P�ʃe�L�X�g�ݒ�
            string unitText = _cmInchControl.GetTitle();

            List<UltraLabel> labelList = new List<UltraLabel>( new UltraLabel[] { ulPrintWidthUnit, ultraLabel1, ulMarginTopUnit, ulMarginLeftUnit, ulMarginRightUnit, ulMarginBottomUnit } );

            foreach ( UltraLabel label in labelList )
            {
                label.Text = unitText;
            }
            ulWatermarkTop.Text = "��@�@�@�@" + unitText;
            ulWatermarkLeft.Text = "���@�@�@�@" + unitText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// �S�̐ݒ�擾����
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <param name="rpt">ActiveReport�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note		: ��ʂ��S�̐ݒ���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void GetWholeSetting(FrePrtPSet frePrtPSet, ar.ActiveReport3 rpt)
		{
			_isNowWorking = true;

			if (frePrtPSet != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                // ���[ID
                frePrtPSet.OutputFormFileName = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				// �\������
				frePrtPSet.DisplayName			= this.tedDisplayName.Text;
				// �o�͊m�F���b�Z�[�W
				frePrtPSet.OutConfimationMsg	= this.tedOutConfimationMsg.Text;
				// �R�����g�i���[�U�[�j
				frePrtPSet.PrtPprUserDerivNoCmt = this.tedPrtPprUserDerivNoCmt.Text;
				// ���ōs��
				frePrtPSet.FormFeedLineCount	= this.ndtFormFeedLineCount.GetInt();
				// ���s������
				frePrtPSet.CrCharCnt			= this.ndtCrCharCnt.GetInt();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// ���[�w�i�摜�c�ʒu
                //frePrtPSet.PrtPprBgImageRowPos	= this.ndtWatermarkTop.GetValue();
                //// ���[�w�i�摜���ʒu
                //frePrtPSet.PrtPprBgImageColPos	= this.ndtWatermarkLeft.GetValue();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // ���[�w�i�摜�c�ʒu
                frePrtPSet.PrtPprBgImageRowPos = ar.ActiveReport3.InchToCm( _cmInchControl.ToData( (float)this.ndtWatermarkTop.GetValue() ) );
                // ���[�w�i�摜���ʒu
                frePrtPSet.PrtPprBgImageColPos = ar.ActiveReport3.InchToCm( _cmInchControl.ToData( (float)this.ndtWatermarkLeft.GetValue() ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// �[���������敪
				frePrtPSet.EdgeCharProcDivCd	= (int)this.cmbEdgeCharProcDivCd.Value;
				// ���הw�i�F
				frePrtPSet.SetDetailBackColor(this.ucpDetailBackColor.Color);
			}

			if (rpt != null)
			{
				// �p�����
				rpt.PageSettings.PaperKind = (PaperKind)this.cmbPaperName.Value;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// �]���ݒ�
                //rpt.PageSettings.Margins.Top	= ar.ActiveReport3.CmToInch((float)this.ndtMarginTop.GetValue());
                //rpt.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch((float)this.ndtMarginBottom.GetValue());
                //rpt.PageSettings.Margins.Right	= ar.ActiveReport3.CmToInch((float)this.ndtMarginRight.GetValue());
                //rpt.PageSettings.Margins.Left	= ar.ActiveReport3.CmToInch((float)this.ndtMarginLeft.GetValue());
                //// �p����
                //rpt.PrintWidth = ar.ActiveReport3.CmToInch((float)this.ndtPrintWidth.GetValue());
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // �]���ݒ�
                rpt.PageSettings.Margins.Top = _cmInchControl.ToData( (float)this.ndtMarginTop.GetValue() );
                rpt.PageSettings.Margins.Bottom = _cmInchControl.ToData( (float)this.ndtMarginBottom.GetValue() );
                rpt.PageSettings.Margins.Right = _cmInchControl.ToData( (float)this.ndtMarginRight.GetValue() );
                rpt.PageSettings.Margins.Left = _cmInchControl.ToData( (float)this.ndtMarginLeft.GetValue() );
                // �p����
                rpt.PrintWidth = _cmInchControl.ToData( (float)this.ndtPrintWidth.GetValue() );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
                // �󎚕���
				rpt.PageSettings.Orientation = (PageOrientation)this.uosOrientation.Value;

				// �p����ʂ��J�X�^���̎��͗p���T�C�Y=���C�A�E�g�̃T�C�Y�Ƃ���
				if (rpt.PageSettings.PaperKind == PaperKind.Custom)
				{
					// ���{�]���i���E�j
					rpt.PageSettings.PaperWidth = rpt.PrintWidth + rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right;
					
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                    //// �SSection�̍���+�]���i�㉺�j
                    //float printHeight = 0;
                    //foreach (ar.Section section in rpt.Sections)
                    //    printHeight += section.Height;
                    //rpt.PageSettings.PaperHeight = printHeight + rpt.PageSettings.Margins.Bottom + rpt.PageSettings.Margins.Bottom;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                    //float printHeight = ar.ActiveReport3.CmToInch( (float)this.ndtPrintHeight.GetValue());
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    float printHeight = _cmInchControl.ToData( (float)this.ndtPrintHeight.GetValue() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
                    
                    if ( printHeight == 0 )
                    {
                        foreach ( ar.Section section in rpt.Sections )
                        {
                            if ( section.Type == DataDynamics.ActiveReports.SectionType.Detail )
                            {
                                printHeight += (section.Height * (float)frePrtPSet.FormFeedLineCount);
                            }
                            else
                            {
                                printHeight += section.Height;
                            }
                        }
                    }
                    rpt.PageSettings.PaperHeight = printHeight + rpt.PageSettings.Margins.Top + rpt.PageSettings.Margins.Bottom;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
				}
			}

			_isNowWorking = false;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="control">�R���g���[��</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public bool InputCheck(out string message, out Control control)
		{
			message = string.Empty;
			control = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // ���[�h�c
            if ( this.tedPrtFormId.Text.Equals( string.Empty ) )
            {
                message = this.ulPrtFormId.Text + "�����͂���Ă��܂���B";
                control = this.tedPrtFormId;
                return false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// ���[����
			if (this.tedDisplayName.Text.Equals(string.Empty))
			{
				message = this.ulDisplayName.Text + "�����͂���Ă��܂���B";
				control = this.tedDisplayName;
				return false;
			}

			// �R�����g�i���[�U�[�j
			if (this.tedPrtPprUserDerivNoCmt.Text.Equals(string.Empty))
			{
				message = this.ulPrtPprUserDerivNoCmt.Text + "�����͂���Ă��܂���B";
				control = this.tedPrtPprUserDerivNoCmt;
				return false;
			}

			// �o�͊m�F���b�Z�[�W
			if (this.tedOutConfimationMsg.Text.Equals(string.Empty))
			{
				message = this.ulOutConfimationMsg.Text + "�����͂���Ă��܂���B";
				control = this.tedOutConfimationMsg;
				return false;
			}

			return true;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �R���g���[�����͏�ԕύX����
		/// </summary>
		/// <param name="printPaperUseDivcd">���[�g�p�敪</param>
		/// <param name="isContractFreeSheetgMng">���R���[�Ǘ��I�v�V�����t���O</param>
		/// <param name="isUpdateMode">�X�V���[�h�t���O</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̓��͏�Ԃ�ύX���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ChangeControlEnabled(int printPaperUseDivcd, bool isContractFreeSheetgMng, bool isUpdateMode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //// ���[�g�p�敪���`�[�����R���[�Ǘ��I�v�V�����������̂݁u���ŕ������v�u�[���������v�̕ҏW��������
            //if (printPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            //{
            //    this.ndtFormFeedLineCount.Enabled	= true;
            //    this.ndtCrCharCnt.Enabled			= true;
            //    this.ulCrCharCntComment.Visible		= true;
            //    if (isContractFreeSheetgMng)
            //    {
            //        this.ndtFormFeedLineCount.ReadOnly	= false;
            //        this.ndtCrCharCnt.ReadOnly			= false;
            //        this.ndtFormFeedLineCount.Appearance.ResetCursor();
            //        this.ndtCrCharCnt.Appearance.ResetCursor();
            //    }
            //    else
            //    {
            //        this.ndtFormFeedLineCount.ReadOnly	= true;
            //        this.ndtCrCharCnt.ReadOnly			= true;
            //        this.ndtFormFeedLineCount.Appearance.Cursor	= Cursors.Arrow;
            //        this.ndtCrCharCnt.Appearance.Cursor			= Cursors.Arrow;
            //    }
            //}
            //else
            //{
            //    this.ndtFormFeedLineCount.Enabled	= false;
            //    this.ndtCrCharCnt.Enabled			= false;
            //    this.ulCrCharCntComment.Visible		= false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            this.ndtFormFeedLineCount.Enabled = true;
            this.ndtCrCharCnt.Enabled = true;
            this.ulCrCharCntComment.Visible = true;
            this.ndtFormFeedLineCount.ReadOnly = false;
            this.ndtCrCharCnt.ReadOnly = false;
            this.ndtFormFeedLineCount.Appearance.ResetCursor();
            this.ndtCrCharCnt.Appearance.ResetCursor();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

			// �X�V���[�h���́u�\�����́v�u���[�U�[�R�����g�v�u�o�̓��b�Z�[�W�v�̕ҏW��s�Ƃ���
			if (isUpdateMode)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                this.tedPrtFormId.ReadOnly = true;
                this.tedPrtFormId.Appearance.ResetBackColor();
                this.tedPrtFormId.Appearance.Cursor = Cursors.Arrow;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //this.tedDisplayName.ReadOnly			= true;
                //this.tedPrtPprUserDerivNoCmt.ReadOnly	= true;
                //this.tedOutConfimationMsg.ReadOnly		= true;
                //this.tedDisplayName.Appearance.ResetBackColor();
                //this.tedPrtPprUserDerivNoCmt.Appearance.ResetBackColor();
                //this.tedOutConfimationMsg.Appearance.ResetBackColor();
                //this.tedDisplayName.Appearance.Cursor			= Cursors.Arrow;
                //this.tedPrtPprUserDerivNoCmt.Appearance.Cursor	= Cursors.Arrow;
                //this.tedOutConfimationMsg.Appearance.Cursor		= Cursors.Arrow;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            }
			else
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                this.tedPrtFormId.ReadOnly = false;
                this.tedPrtFormId.Appearance.BackColor = Color.FromArgb( 179, 219, 231 );
                this.tedPrtFormId.Appearance.ResetCursor();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //this.tedDisplayName.ReadOnly			= false;
                //this.tedPrtPprUserDerivNoCmt.ReadOnly	= false;
                //this.tedOutConfimationMsg.ReadOnly		= false;
                //this.tedDisplayName.Appearance.BackColor			= Color.FromArgb(179, 219, 231);
                //this.tedPrtPprUserDerivNoCmt.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
                //this.tedOutConfimationMsg.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
                //this.tedDisplayName.Appearance.ResetCursor();
                //this.tedPrtPprUserDerivNoCmt.Appearance.ResetCursor();
                //this.tedOutConfimationMsg.Appearance.ResetCursor();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// ���R���[�Ǘ��I�v�V���������������͗]���ݒ�Ɣw�i�֌W�ȊO�̍��ڂ�ҏW�s�Ƃ���
            //if (!isContractFreeSheetgMng)
            //{
            //    this.cmbPaperName.ReadOnly			= true;
            //    this.ndtPrintWidth.ReadOnly			= true;
            //    this.cmbEdgeCharProcDivCd.ReadOnly	= true;
            //    this.ucpDetailBackColor.ReadOnly	= true;
            //    this.cmbPaperName.Appearance.Cursor			= Cursors.Arrow;
            //    this.ndtPrintWidth.Appearance.Cursor		= Cursors.Arrow;
            //    this.cmbEdgeCharProcDivCd.Appearance.Cursor	= Cursors.Arrow;
            //    this.ucpDetailBackColor.Appearance.Cursor	= Cursors.Arrow;
				
            //    this.uosOrientation.Enabled = false;

            //    // �X�V���[�h�̓`�[�͗]���ݒ���ҏW�s�Ƃ���
            //    if (printPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip && isUpdateMode)
            //    {
            //        this.ndtMarginTop.Enabled		= false;
            //        this.ndtMarginBottom.Enabled	= false;
            //        this.ndtMarginRight.Enabled		= false;
            //        this.ndtMarginLeft.Enabled		= false;
            //    }
            //    else
            //    {
            //        this.ndtMarginTop.Enabled		= true;
            //        this.ndtMarginBottom.Enabled	= true;
            //        this.ndtMarginRight.Enabled		= true;
            //        this.ndtMarginLeft.Enabled		= true;
            //    }
            //}
            //else
            //{
            //    this.cmbPaperName.ReadOnly			= false;
            //    this.ndtPrintWidth.ReadOnly			= false;
            //    this.cmbEdgeCharProcDivCd.ReadOnly	= false;
            //    this.ucpDetailBackColor.ReadOnly	= false;
            //    this.cmbPaperName.Appearance.ResetCursor();
            //    this.ndtPrintWidth.Appearance.ResetCursor();
            //    this.cmbEdgeCharProcDivCd.Appearance.ResetCursor();
            //    this.ucpDetailBackColor.Appearance.ResetCursor();

            //    this.uosOrientation.Enabled			= true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
		}

		/// <summary>
		/// �p���T�C�Y�R�����g�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �p���T�C�Y�̕⑫������\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowPaperSizeComment()
		{
			if (this.cmbPaperName.Value != null)
			{
				// �p�����
				PaperKind paperKind	= (PaperKind)this.cmbPaperName.Value;
				if (paperKind == PaperKind.Custom)
				{
					this.ulPaperSize.Text = string.Empty;
				}
				else
				{
					// �v�����^�[�N���X���p���T�C�Y���擾
					Printer printer = new Printer();
					// ���z�v�����^���w��
					printer.PrinterName = string.Empty;
					printer.PaperKind = paperKind;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                    //float paperWidth = ar.ActiveReport3.InchToCm(printer.PaperWidth);
                    //float paperHeight = ar.ActiveReport3.InchToCm(printer.PaperHeight);
                    //if ( (PageOrientation)this.uosOrientation.Value == PageOrientation.Landscape )
                    //    this.ulPaperSize.Text = string.Format( "�p���T�C�Y( {0:f1}�p x {1:f1}�p )", paperHeight, paperWidth );
                    //else
                    //    this.ulPaperSize.Text = string.Format( "�p���T�C�Y( {0:f1}�p x {1:f1}�p )", paperWidth, paperHeight );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    float paperWidth = _cmInchControl.ToDisp( printer.PaperWidth );
                    float paperHeight = _cmInchControl.ToDisp( printer.PaperHeight );
                    if ( (PageOrientation)this.uosOrientation.Value == PageOrientation.Landscape )
                        this.ulPaperSize.Text = string.Format( "�p���T�C�Y( {0:f1}{2} x {1:f1}{2} )", paperHeight, paperWidth, _cmInchControl.GetTitle() );
                    else
                        this.ulPaperSize.Text = string.Format( "�p���T�C�Y( {0:f1}{2} x {1:f1}{2} )", paperWidth, paperHeight, _cmInchControl.GetTitle() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				}
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �N���A�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �N���A�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubClear_Click(object sender, EventArgs e)
		{
			this.pnlWatermark.BackgroundImage = null;
			_watermark = null;

			WholeSettingChanged(ChangedType.Watermark, e);
		}

		/// <summary>
		/// �Q�ƃ{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Q�ƃ{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubReference_Click(object sender, EventArgs e)
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
				this.pnlWatermark.BackgroundImage = bitmap;
				_watermark = this.pnlWatermark.BackgroundImage;
				image.Dispose();

				WholeSettingChanged(ChangedType.Watermark, e);
			}
		}

		/// <summary>
		/// �󎚕���ValueChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̒l���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void uosOrientation_ValueChanged(object sender, EventArgs e)
		{
			if (this.uosOrientation.Value == null)
				this.uosOrientation.CheckedIndex = 0;

			ShowPaperSizeComment();
		}

		/// <summary>
		/// �p�����SelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbPaperName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ShowPaperSizeComment();
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
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            if ( e.NextCtrl == this.tedPrtFormId && this.tedPrtFormId.ReadOnly )
            {
                e.NextCtrl = null;
                return;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (e.NextCtrl == this.tedDisplayName && this.tedDisplayName.ReadOnly)
            //{
            //    e.NextCtrl = null;
            //    return;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			if (e.PrevCtrl is TNedit)
			{
				if (!_bufCode.Equals(((TNedit)e.PrevCtrl).GetValue()))
					WholeSettingChanged(ChangedType.PrintPos, e);
			}
			else if (e.PrevCtrl is TEdit)
			{
				if (!_bufText.Equals(((TEdit)e.PrevCtrl).Text))
					WholeSettingChanged(ChangedType.Comment, e);
			}

			if (e.NextCtrl is TNedit)
				_bufCode = ((TNedit)e.NextCtrl).GetValue();
			else if (e.NextCtrl is TEdit)
				_bufText = ((TEdit)e.NextCtrl).Text;

			switch (e.Key)
			{
				case Keys.Enter:
				{
					if (!this.Contains(e.NextCtrl))
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //if ( this.tedDisplayName.ReadOnly )
                        //{
                        //    if (this.cmbPaperName.ReadOnly)
                        //        e.NextCtrl = this.ndtMarginTop;
                        //    else
                        //        e.NextCtrl = this.cmbPaperName;
                        //}
                        //else
                        //    e.NextCtrl = this.tedDisplayName;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        if ( !this.tedPrtFormId.ReadOnly )
                        {
                            e.NextCtrl = this.tedPrtFormId;
                        }
                        else
                        {
                            e.NextCtrl = this.tedDisplayName;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
					}
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
		private void TEdit_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow	= e.Element.GetContext(typeof(TEdit));
			if (objContextRow != null)
			{
				TEdit tEdit = objContextRow as TEdit;

				int strWidth = FrePrtSettingController.GetStringWidth(tEdit);
				if (tEdit.ReadOnly && !tEdit.Text.Trim().Equals(string.Empty) && strWidth > tEdit.Width)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipText = tEdit.Text;

					this.ultraToolTipManager.SetUltraToolTip(tEdit, ultraToolTipInfo);
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
		private void TEdit_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// �c�[���`�b�v���\���ɂ���
			this.ultraToolTipManager.HideToolTip();
			this.ultraToolTipManager.Enabled = false;
		}

		/// <summary>
		/// Enter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UC_Enter(object sender, EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (tedDisplayName.ReadOnly)
            //{
            //    if (!this.cmbPaperName.ReadOnly)
            //        this.cmbPaperName.Focus();
            //    else if (this.ndtMarginTop.Enabled)
            //        this.ndtMarginTop.Focus();
            //    else
            //        this.ubReference.Focus();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            if ( !this.tedPrtFormId.ReadOnly )
            {
                this.tedPrtFormId.Focus();
            }
            else
            {
                this.tedDisplayName.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		}
		#endregion
	}
}
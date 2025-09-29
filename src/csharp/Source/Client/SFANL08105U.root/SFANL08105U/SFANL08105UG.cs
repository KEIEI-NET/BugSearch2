using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �V�K�o�^�����͉��
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�̐V�K�o�^�ɕK�v�ȏ�����͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UG : Form
	{
		#region PrivateMember
		// ���R���[�󎚈ʒu�ݒ�
		private FrePrtPSet	_frePrtPSet;
		// �`�[��ʃR�[�h
		private List<int>	_slipPrtKindList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        // �V�K�����t���O
        private bool isNewWrite;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UG()
		{
			InitializeComponent();

			this.ubSave.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SAVE];
			this.ubCancel.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];

			_slipPrtKindList = new List<int>();
		}
		#endregion

		#region Property
		/// <summary>
		/// �`�[���
		/// </summary>
		public List<int> SlipPrtKindList
		{
			get { return _slipPrtKindList; }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            set { _slipPrtKindList = value; }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// �V�K�����t���O
        /// </summary>
        public bool IsNewWrite
        {
            get { return isNewWrite; }
            set { isNewWrite = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// �V�K�o�^���_�C�A���O�\������
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�̐V�K�o�^�ɕK�v�ȏ�����͂����ʂ�\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public DialogResult ShowNewWriteInfoDialog(FrePrtPSet frePrtPSet)
		{
			_frePrtPSet = frePrtPSet;

			DialogResult dlgRet = this.ShowDialog();

			return dlgRet;
		}
		#endregion

		#region PrivateMthod
		/// <summary>
		/// ���̓`�F�b�N
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="control">�R���g���[��</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̓��̓`�F�b�N���s�Ȃ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private bool InputCheck(out string message, out Control control)
		{
			message = string.Empty;
			control = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            // ���[ID
            if ( this.tedPrtFormId.Text.Equals( string.Empty ) )
            {
                message = this.ulPrtFormId.Text + "�����͂���Ă��܂���B";
                control = this.tedPrtFormId;
                return false;
            }
            if ( this.tedPrtFormId.Text.IndexOf( '\\' ) != -1 || this.tedPrtFormId.Text.IndexOf( '/' ) != -1 )
            {
                message = this.ulPrtFormId.Text + "�ɉ��L�����͎g�p�o���܂���B" + Environment.NewLine + Environment.NewLine + "\\ /";
                control = this.tedPrtFormId;
                return false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			// ���[����
			if (this.tedDisplayName.Text.Equals(string.Empty))
			{
				message = this.ulDisplayName.Text + "�����͂���Ă��܂���B";
				control = this.tedDisplayName;
				return false;
			}
			if (this.tedDisplayName.Text.IndexOf('\\') != -1 || this.tedDisplayName.Text.IndexOf('/') != -1)
			{
				message = this.ulDisplayName.Text + "�ɉ��L�����͎g�p�o���܂���B" + Environment.NewLine + Environment.NewLine + "\\ /";
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

			// �`�[���
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
            if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
			{
				if (!this.uceEstimate.Checked &&
					!this.uceShipment.Checked &&
					!this.uceAcpOdr.Checked &&
					!this.uceDelivery.Checked)
				{
					message = this.ulSlipPrtKind.Text + "���I������Ă��܂���B";
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
                    //control = this.uceEstimate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
                    control = this.uceDelivery;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
					return false;
				}
			}
			
			return true;
		}
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
		private void SFANL08105UI_Load(object sender, EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            // ���[ID
            this.tedPrtFormId.Text = _frePrtPSet.OutputFormFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
			// �o�͖���
			this.tedDisplayName.Text			= _frePrtPSet.DisplayName;
			// �o�͊m�F���b�Z�[�W
			this.tedOutConfimationMsg.Text		= _frePrtPSet.OutConfimationMsg;
			// ���[���[�U�[�}�ԃR�����g
			this.tedPrtPprUserDerivNoCmt.Text	= _frePrtPSet.PrtPprUserDerivNoCmt;

			// �p���g�p�敪���̐���
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
            // �`�[�ȊO�Ɓu���Ϗ��v�u�݌Ɉړ��`�[�v�u�d���ԕi�`�[�v�u�t�n�d�v�`�[�͏���
            if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
			{
                this.pnlSlipPrtKind.Visible = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                //this.uceEstimate.Checked = true;
                //this.uceShipment.Checked = true;
                //this.uceAcpOdr.Checked = true;
                //this.uceDelivery.Checked = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                if ( this.isNewWrite )
                {
                    // ����
                    this.uceDelivery.Checked = true;
                    this.uceDelivery.Enabled = true;
                    // ��
                    this.uceAcpOdr.Checked = true;
                    this.uceAcpOdr.Enabled = true;
                    // �ݏo
                    this.uceShipment.Checked = true;
                    this.uceShipment.Enabled = true;
                    // ����
                    this.uceEstimate.Checked = true;
                    this.uceEstimate.Enabled = true;
                }
                else
                {
                    // ����
                    this.SetCheckEditState( uceDelivery, _slipPrtKindList.Contains( 30 ) );
                    // ��
                    this.SetCheckEditState( uceAcpOdr, _slipPrtKindList.Contains( 120 ) );
                    // �ݏo
                    this.SetCheckEditState( uceShipment, _slipPrtKindList.Contains( 130 ) );
                    // ����
                    this.SetCheckEditState( uceEstimate, _slipPrtKindList.Contains( 140 ) );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
            }
			else
			{
                this.pnlSlipPrtKind.Visible = false;
                this.Height -= this.pnlSlipPrtKind.Height;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            if ( this.IsNewWrite )
            {
                // �V�K���[�h(���O��t���ĕۑ�)
                this.tedPrtFormId.ReadOnly = false;
                this.tedPrtFormId.Appearance.BackColor = Color.FromArgb( 179, 219, 231 );
                this.tedPrtFormId.Appearance.ResetCursor();

                // �t�H�[���^�C�g��
                this.Text = string.Format( "{0} - {1}", "���R���[", "���O��t���ĕۑ�" );

                // �t�H�[�J�X
                this.tedPrtFormId.Focus();
            }
            else
            {
                // �X�V���[�h
                this.tedPrtFormId.ReadOnly = true;
                this.tedPrtFormId.Appearance.ResetBackColor();
                this.tedPrtFormId.Appearance.Cursor = Cursors.Arrow;

                // �t�H�[���^�C�g��
                this.Text = string.Format( "{0} - {1}", "���R���[", "�㏑���ۑ�" );
                // �t�H�[�J�X
                this.tedDisplayName.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// �`�F�b�N�{�b�N�X��Ԑݒ菈��
        /// </summary>
        /// <param name="targetCheckEditor"></param>
        /// <param name="prevExists"></param>
        private void SetCheckEditState( Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor, bool prevExists )
        {
            if ( prevExists )
            {
                targetCheckEditor.Checked = true;
                targetCheckEditor.Enabled = false;
            }
            else
            {
                targetCheckEditor.Checked = false;
                targetCheckEditor.Enabled = true;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		/// <summary>
		/// �ۑ��{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubSave_Click(object sender, EventArgs e)
		{
			string message;
			Control control;
			if (InputCheck(out message, out control))
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                // ���[ID
                _frePrtPSet.OutputFormFileName = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				// �o�͖���
				_frePrtPSet.DisplayName				= this.tedDisplayName.Text;
				// �o�͊m�F���b�Z�[�W
				_frePrtPSet.OutConfimationMsg		= this.tedOutConfimationMsg.Text;
				// ���[���[�U�[�}�ԃR�����g
				_frePrtPSet.PrtPprUserDerivNoCmt	= this.tedPrtPprUserDerivNoCmt.Text;
				// �p���g�p�敪���̐���
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
                //if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip )
                //{
                //    if ( this.uceEstimate.Checked ) _slipPrtKindList.Add( 10 );
                //    if ( this.uceShipment.Checked ) _slipPrtKindList.Add( 20 );
                //    if ( this.uceAcpOdr.Checked ) _slipPrtKindList.Add( 21 );
                //    if ( this.uceDelivery.Checked ) _slipPrtKindList.Add( 30 );
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
                _slipPrtKindList.Clear();
				if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
				{
                    switch ( _frePrtPSet.FreePrtPprSpPrpseCd )
                    {
                        // ���Ϗ�
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm:
                            {
                                _slipPrtKindList.Add( 10 );
                            }
                            break;
                        // �d���ԕi
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip:
                            {
                                _slipPrtKindList.Add( 40 );
                            }
                            break;
                        // �݌Ɉړ�
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip:
                            {
                                _slipPrtKindList.Add( 150 );
                            }
                            break;
                        // �t�n�d
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip:
                            {
                                _slipPrtKindList.Add( 160 );
                            }
                            break;
                        default:
                            {
                                // ����E�󒍁E�o�ׁE���ϓ`�[
                                if ( this.uceDelivery.Checked ) _slipPrtKindList.Add( 30 );
                                if ( this.uceAcpOdr.Checked ) _slipPrtKindList.Add( 120 );
                                if ( this.uceShipment.Checked ) _slipPrtKindList.Add( 130 );
                                if ( this.uceEstimate.Checked ) _slipPrtKindList.Add( 140 );
                            }
                            break;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��
				control.Focus();
			}
		}

		/// <summary>
		/// �L�����Z���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �L�����Z���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// �t�H�[���L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[����ŃL�[�������ꂽ���ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UG_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				ubCancel_Click(sender, e);
		}
		#endregion
	}
}
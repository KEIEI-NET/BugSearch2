using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.IO;
using Broadleaf.Application.Resources;

using DataDynamics.ActiveReports.Toolbar;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �`�[����v���r���[�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �`�[������ʂ̃v���r���[UI�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.01.12</br> 
	/// <br></br>
    /// <br>Update Note : 2007.12.11 22018 ��� ���b</br>
    /// <br>            :   �@DC.NS�Ή� (ActiveReports 3.0 �Ή��̂�)</br>
    /// <br></br>
    /// <br>Update Note : 2010/06/23 22018 ��� ���b</br>
    /// <br>            :   ����������y�[�W�w��Ή�</br>
    /// <br>Update Note : K2024/08/15 ���O</br>
    /// <br>�Ǘ��ԍ�    : 12000031-00</br>
    /// <br>            : PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j</br> 
    /// <br>Update Note	: 2024/11/26 �c������</br>
    /// <br>�Ǘ��ԍ�    : 12000031-00</br>
    /// <br>Update Note	: �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή�</br>
    /// </remarks>
	public class SFMIT01290UA : System.Windows.Forms.Form
	{
		#region PrivateMember
		// ����p�p�����[�^
		SFMIT01290UB _prtParam;
		// �y�[�W���ޔ�p
		private string _bufText;
		// �Y�[���ޔ�p
		private string _bufZoomText;
		#endregion

		#region Component
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
        // --- ADD K2024/09/13 ���O PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j ----->>>>>
        /// <summary>
        /// �v���r���[����t���O�u0:�v���r���[�����A1:�v���r���[�L��A2:�v���r���[��ʂŁu����v�{�^�������v
        /// </summary>
        public static int isPrtFlg = 0;
        // --- ADD K2024/09/13 ���O PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j -----<<<<<
		#endregion
        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� ----->>>>>
        private Timer timer1;
        private const string xmlFileName = "SFMIT01290U_PreviewTimeoutSetting.xml";
        private PreviewTimeoutSet previewTimeoutInfo = null;
        private const int timeoutSec = 300000;
        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� -----<<<<<

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
        /// <remarks>
        /// <br>Update Note : K2024/09/13 ���O</br>
        /// <br>�Ǘ��ԍ�    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j</br> 
        /// </remarks>
		public SFMIT01290UA()
		{
            isPrtFlg = 0; //ADD K2024/09/13 ���O PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j
			InitializeComponent();

			// �r���[���̃y�[�W���R���g���[�����擾
			PlaceHolder	placeHolder = this.viewer1.Toolbar.Tools.ToolById(17) as PlaceHolder;
			if (placeHolder != null)
			{
				// �C�x���g�ɒǉ�
				placeHolder.Control.TextChanged += new System.EventHandler(this.ViewerPageNumber_TextChanged);
			}

			// �r���[���̃Y�[���R���g���[�����擾
			PlaceHolder	placeHolder2 = this.viewer1.Toolbar.Tools.ToolById(13) as PlaceHolder;
			if (placeHolder2 != null)
			{
				// �C�x���g�ɒǉ�
				placeHolder2.Control.TextChanged	+= new System.EventHandler(this.ViewerZoom_TextChanged);
				placeHolder2.Control.KeyPress		+= new KeyPressEventHandler(this.ViewerZoom_KeyPress);
			}
		}
		#endregion

		#region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFMIT01290UA));
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Document = new DataDynamics.ActiveReports.Document.Document( "ARNet Document" );
            this.viewer1.Location = new System.Drawing.Point( 0, 0 );
            this.viewer1.Name = "viewer1";
            this.viewer1.ReportViewer.CurrentPage = 0;
            this.viewer1.ReportViewer.MultiplePageCols = 3;
            this.viewer1.ReportViewer.MultiplePageRows = 2;
            this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.viewer1.Size = new System.Drawing.Size( 892, 648 );
            this.viewer1.TabIndex = 0;
            this.viewer1.TableOfContents.Text = "Contents";
            this.viewer1.TableOfContents.Width = 200;
            this.viewer1.TabTitleLength = 35;
            this.viewer1.Toolbar.Font = new System.Drawing.Font( "MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.viewer1.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler( this.viewer1_ToolClick );
            // 
            // pdfExport1
            // 
            this.pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // SFMIT01290UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 12 );
            this.ClientSize = new System.Drawing.Size( 892, 648 );
            this.Controls.Add( this.viewer1 );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "SFMIT01290UA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����v���r���[";
            this.ResumeLayout( false );

		}
		#endregion

		#region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
            System.Windows.Forms.Application.Run(new SFMIT01290UA());
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ����J�n�����i�v���r���[�L��j
		/// </summary>
		/// <param name="prtParam">����v���r���[�p�����[�^�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �v���r���[�L��ň�����s���܂��B</br>
		/// <br>			: ����{�^���������ɂ�Windows�W���̈���_�C�A���O���\������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int PrintPreviewDefaultSetting(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			//�g�嗦�̐ݒ�
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = 1.0F;
			}

			// ��ʂ�Windows�̍�Ɨ̈敪�ɂ���
			this.Width	= Screen.GetWorkingArea(this).Width;
			this.Height	= Screen.GetWorkingArea(this).Height;

			this.viewer1.Document = prtParam.PreviewDocument;
            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            // ����I�����̏�����o�^
            this.viewer1.Document.Printer.EndPrint += new System.Drawing.Printing.PrintEventHandler( Printer_EndPrint );
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<

			this.ShowDialog();

			return 0;
		}
        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
        /// <summary>
        /// �h�L�������g����I�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Printer_EndPrint( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            // ���̃t�H�[�����I������
            // �i���_�C�A���O�ŃL�����Z�������ꍇ�́A���̏����ɓ���Ȃ��j
            this.Close();
        }
        // --- ADD m.suzuki 2010/06/23 ----------<<<<<

		/// <summary>
		/// ����J�n�����i�v���r���[�L��j
		/// </summary>
		/// <param name="prtParam">����v���r���[�p�����[�^�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �v���r���[�L��ň�����s���܂��B</br>
		/// <br>			: ����{�^���������Ƀ_�C�A���O�͕\������܂���B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
        /// <br>Update Note : K2024/09/13 ���O</br>
        /// <br>�Ǘ��ԍ�    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j</br> 
		/// </remarks>
		public int PrintPreview(SFMIT01290UB prtParam)
		{
            isPrtFlg = 1; //ADD K2024/09/13 ���O PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j
			this._prtParam	= prtParam;

			//�g�嗦�̐ݒ�
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = 1.0F;
			}

			// ��ʂ�Windows�̍�Ɨ̈敪�ɂ���
			this.Width = Screen.GetWorkingArea(this).Width;
			this.Height = Screen.GetWorkingArea(this).Height;

			// �A�N�e�B�u���|�[�gViewer�̐ݒ�
			// �f�t�H���g�̈���{�^�����폜
			this.viewer1.Toolbar.Tools.RemoveAt(2);
			// ����{�^���̑}��
			// �����ToolClick�C�x���g�̑g�ݍ��킹�ɂ��APrintDialog���o�����Ɉ�����\�ɂ���
			DataDynamics.ActiveReports.Toolbar.Button printBtn = new DataDynamics.ActiveReports.Toolbar.Button();
			printBtn.Caption = "���";
			printBtn.ToolTip = "��������s���܂�";
			printBtn.ImageIndex = 1;
			printBtn.ButtonStyle = ButtonStyle.TextAndIcon;
			printBtn.Id = 5001;
			this.viewer1.Toolbar.Tools.Insert(2,printBtn);

			this.viewer1.Document = prtParam.PreviewDocument;
			
			this.ShowDialog();

			return 0;
		}

        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� ----->>>>>
        /// <summary>
        /// ����J�n�����i�v���r���[�L��j
        /// </summary>
        /// <param name="prtParam">����v���r���[�p�����[�^�N���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �v���r���[�L��ň�����s���܂��B</br>
        /// <br>			: �v���r���[��ʂ���莞�ԂŏI�����A������J�n����Ή�</br>
        /// <br>Programmer	: 32427 �c������</br>
        /// <br>Date		: 2024/11/26</br>
        /// </remarks>
        public int PrintPreview2(SFMIT01290UB prtParam)
        {
            this._prtParam = prtParam;
            GetXmlInfo();//�v���r���[�����ݒ�t�@�C���̓ǂݍ��݁iXML���Ȃ��ꍇ�̓f�t�H���g5���j

            //�g�嗦�̐ݒ�
            if (this._prtParam.ExpansionRate != 0.0)
            {
                this.viewer1.ReportViewer.Zoom = 1.0F;
            }

            // ��ʂ�Windows�̍�Ɨ̈敪�ɂ���
            this.Width = Screen.GetWorkingArea(this).Width;
            this.Height = Screen.GetWorkingArea(this).Height;

            // �A�N�e�B�u���|�[�gViewer�̐ݒ�
            // �f�t�H���g�̈���{�^�����폜
            this.viewer1.Toolbar.Tools.RemoveAt(2);
            // ����{�^���̑}��
            // �����ToolClick�C�x���g�̑g�ݍ��킹�ɂ��APrintDialog���o�����Ɉ�����\�ɂ���
            DataDynamics.ActiveReports.Toolbar.Button printBtn = new DataDynamics.ActiveReports.Toolbar.Button();
            printBtn.Caption = "���";
            printBtn.ToolTip = "��������s���܂�";
            printBtn.ImageIndex = 1;
            printBtn.ButtonStyle = ButtonStyle.TextAndIcon;
            printBtn.Id = 5001;
            this.viewer1.Toolbar.Tools.Insert(2, printBtn);

            timer1.Interval = previewTimeoutInfo.PreviewTimeoutSec;
            timer1.Enabled = true;
            try
            {
                this.viewer1.Document = prtParam.PreviewDocument;
                this.ShowDialog();
            }
            catch
            {
                //����������O�����̂܂܍ăX���[����
                throw;
            }
            finally
            {
                timer1.Enabled = false;
            }

            return 0;
        }

        private void GetXmlInfo()
        {
            try
            {
                previewTimeoutInfo = new PreviewTimeoutSet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName)))
                {
                    // XML����^�C���A�E�g���Ԃ��擾����
                    previewTimeoutInfo = UserSettingController.DeserializeUserSetting<PreviewTimeoutSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName));
                }
                else
                {
                    // �^�C���A�E�g-�f�t�H���g�F300�b
                    previewTimeoutInfo.PreviewTimeoutSec = timeoutSec;
                }
            }
            catch
            {
                if (previewTimeoutInfo == null) previewTimeoutInfo = new PreviewTimeoutSet();
                // �^�C���A�E�g-�f�t�H���g�F300�b
                previewTimeoutInfo.PreviewTimeoutSec = timeoutSec;
            }
        }

        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� -----<<<<<

		/// <summary>
		/// ����J�n�����i�v���r���[�L��j
		/// </summary>
		/// <param name="prtParam">����v���r���[�p�����[�^�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �v���r���[�݂̂��s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int PrintPreviewWithoutPrtBtn(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			//�g�嗦�̐ݒ�
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = (float)this._prtParam.ExpansionRate / 100F;
			}

			// �����{�^����荶�̃{�^���͔�\��
			for (int ix = 0 ; ix != 8 ; ix++)
			{
				this.viewer1.Toolbar.Tools[ix].Visible = false;
			}
			this.viewer1.Toolbar.Wrappable = false;

			this.viewer1.Document = prtParam.PreviewDocument;
			
			return 0;
		}

		/// <summary>
		/// ����J�n�����iPDF�j
		/// </summary>
		/// <param name="prtParam">����v���r���[�p�����[�^�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: PDF���o�͂��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int OutputPDF(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			pdfExport1.Export(prtParam.PrintDocument, prtParam.PdfPath);
			
			return 0;
		}
		#endregion

		#region Event
		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���r���[���̃c�[���o�[���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
        /// <br>Update Note : K2024/09/13 ���O</br>
        /// <br>�Ǘ��ԍ�    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j</br> 
		/// </remarks>
		private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			if (e.Tool.Id == 5001)
			{
                timer1.Enabled = false;// ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή�
                isPrtFlg = 2;//ADD K2024/09/13 ���O PMKOBETSU-4367 �`�[���o�Ȃ��i���API�t�b�N�ǉ��Ή��j
				this._prtParam.PrintDocument.Print(false, true, false);

				this.Close();
			}
		}

		/// <summary>
		/// �e�L�X�g�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���e�L�X�g��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		private void ViewerPageNumber_TextChanged(object sender, System.EventArgs e)
		{
			Control control = (Control)sender;
			if (control.Text.Length > int.MaxValue.ToString().Length - 1)
			{
				control.Text = this._bufText;
			}
			else
			{
				this._bufText = control.Text;
			}
		}

		/// <summary>
		/// �e�L�X�g�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���e�L�X�g��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		private void ViewerZoom_TextChanged(object sender, System.EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			// �p�[�Z���g�w��̎��̂ݏ������s��
			if (comboBox.SelectedIndex < 8)
			{
				// float�^�ȏ�̐��l����͂����Ȃ�
				if (comboBox.Text.Length > 6)
				{
					comboBox.Text = this._bufZoomText;
				}
				else
				{
					this._bufZoomText = comboBox.Text;
				}
			}
		}

		/// <summary>
		/// �L�[�v���X�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[�������L�[����͂������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		private void ViewerZoom_KeyPress(object sender, KeyPressEventArgs e)
		{
			// �����L�[�ABackSpace�ȊO�̓��͂��󂯕t���Ȃ�
			if ((e.KeyChar != (Char)Keys.Back) &&
				((e.KeyChar < '0') || (e.KeyChar > '9'))
				)
			{
				e.Handled = true;
			}
		}

        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� ----->>>>>
        /// <summary>
        /// �v���r���[���ԊĎ��^�C�}
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �v���r���[�^�C���A�E�g���Ƀv���r���[��ʂ���Ĉ�����J�n���܂�</br>
        /// <br>Programmer	: 32427 �c������</br>
        /// <br>Date		: 2024/11/26</br>
        /// </remarks>

        private void TimerTick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this._prtParam.PrintDocument.Print(false, true, false);
            this.Close();
        }
        // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� -----<<<<<
		#endregion
    }

    // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� ----->>>>>
    /// <summary>
    /// �v���r���[���ԊĎ��^�C�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �v���r���[�^�C���A�E�g����</br>
    /// <br>Programmer	: 32427 �c������</br>
    /// <br>Date		: 2024/11/26</br>
    /// </remarks>

	[Serializable]
    public class PreviewTimeoutSet
    {
        // �v���r���[�^�C���A�E�g
        private int _previewTimeoutSec;

        /// <summary>
        /// ���g���C�ݒ�N���X
        /// </summary>
        public PreviewTimeoutSet()
        {

        }

        /// <summary>�^�C���A�E�g����</summary>
        public Int32 PreviewTimeoutSec
        {
            get { return this._previewTimeoutSec; }
            set { this._previewTimeoutSec = value; }
        }
    }
    // ADD 2024/11/26 �c������ �v���r���[�_�C�A���O�\���^�C���A�E�g�Ή� -----<<<<<
}

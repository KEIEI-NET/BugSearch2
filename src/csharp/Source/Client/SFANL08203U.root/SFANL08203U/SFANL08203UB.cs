using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Toolbar;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport���ʃv���r���[��ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr������̋��ʃv���r���[��ʃN���X�ł��B</br>
	/// <br>Programmer : 22011 �����@���l</br>
	/// <br>Date       : </br>
	/// <br>Update Note: </br>
    /// </remarks>
	public class SFANL08203UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		#endregion

		private System.ComponentModel.IContainer components = null;

		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport���ʃv���r���[��ʃN���X�R���X�g���N�^
		/// </summary>
		public SFANL08203UB()
		{
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
            }
			
			// ���ʊ֐����i�C���X�^���X�쐬
			this._commonLib = new SFANL08203UC();
		
        }
		#endregion

		// ===============================================================================
		// �j��
		// ===============================================================================
		# region Dispose
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

		// ===============================================================================
		// Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
		// ===============================================================================
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08203UB));
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.viewer1.Location = new System.Drawing.Point(0, 0);
            this.viewer1.Name = "viewer1";
            this.viewer1.ReportViewer.CurrentPage = 0;
            this.viewer1.ReportViewer.DisplayUnits = DataDynamics.ActiveReports.Viewer.DisplayUnits.Metric;
            this.viewer1.ReportViewer.MultiplePageCols = 3;
            this.viewer1.ReportViewer.MultiplePageRows = 2;
            this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.viewer1.Size = new System.Drawing.Size(1016, 734);
            this.viewer1.TabIndex = 0;
            this.viewer1.TableOfContents.Text = "Contents";
            this.viewer1.TableOfContents.Width = 200;
            this.viewer1.Toolbar.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.viewer1.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.viewer1_ToolClick);
            // 
            // SFANL08203UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.viewer1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "SFANL08203UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "����v���r���[";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SFANL08203UB_KeyPress);
            this.TextChanged += new System.EventHandler(this.SFANL08203UB_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFANL08203UB_KeyDown);
            this.Load += new System.EventHandler(this.SFANL08203UB_Load);
            this.ResumeLayout(false);

		}
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		// ����p���|�[�g�C���X�^���X�i�[�p
		private DataDynamics.ActiveReports.ActiveReport3 _prtRpt  = null;
		// �v���r���[�p���|�[�g�C���X�^���X�i�[�p
		private DataDynamics.ActiveReports.ActiveReport3 _viewRpt = null;
        // PDF�o�̓N���X
        private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
		
		private SFANL08203UD _commonInfo = null;										// ���ʐݒ���N���X
		private SFANL08203UC _commonLib  = null;										// ���ʕ��i�N���X
		private string _bufText;														// �y�[�W���ޔ�p
		private string _bufZoomText;													// �Y�[���ޔ�p
		private bool _isShowPrintDialog   = true;										// ����_�C�A���O�\���L��
        private IWin32Window _owner = null;											// �g�b�v���x���E�B���h�E	
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		// �c�[���o�[�{�^���h�c
		private const int CT_TOOLBUTTON_PRINT = 5000;								// �u����v�{�^��ID
		private const int CT_TOOLBUTTON_CLOSE = 5020;								// �u����v�{�^��ID
		#endregion
		
		delegate void CreateReportDelegate();
		
		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region public property
		/// <summary>���ʉ�ʏ����v���p�e�B</summary>
		public SFANL08203UD CommonInfo
		{
			get{return this._commonInfo;}
			set{this._commonInfo = value;}
		}
		
		/// <summary>����_�C�A���O�\���v���p�e�B</summary>
		/// <value>[T:����,F:���Ȃ�]</value>
		public bool IsShowPrintDialog
		{
			get{return _isShowPrintDialog;}
			set{_isShowPrintDialog = value;}
		}
		#endregion

		// ===============================================================================
		// ���C��
		// ===============================================================================
		#region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFANL08203UB());
		}
		#endregion

		// ===============================================================================
		// �O���񋟊֐�
		// ===============================================================================
		#region public methods
		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this.DialogResult = DialogResult.Cancel;
			try
			{
				// ���|�[�g�C���X�^���X�ݒ�
				this._prtRpt   = rpt;
				this._viewRpt  = rpt;

				// �v���r���[��ʋN��
				DialogResult dr = this.ShowDialog(this._owner);
				switch (dr)
				{
					case DialogResult.OK     :
					case DialogResult.None   :
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel :
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
			}
			
			return status;
		}
			
		/// <summary>
		/// �v���r���[�\������(�����ς�Document�v���r���[)
		/// </summary>
		/// <param name="prtRpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>DialogResult</returns>
		public int ShowPreview(DataDynamics.ActiveReports.ActiveReport3 prtRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this.DialogResult = DialogResult.Cancel;

			this._prtRpt = prtRpt;
			this.viewer1.Document = this._prtRpt.Document;
            this.viewer1.Show();

			DialogResult dret = this.ShowDialog(this._owner);
			switch (dret)
			{
				case DialogResult.OK     :
				case DialogResult.None   :
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
					break;
				case DialogResult.Cancel :
					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
					break;
				default:
					break;
			}

			return status;
		}
		
		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		/// <param name="owner">�g�b�v���x���E�B���h�E</param>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		public int Run(IWin32Window owner, DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			this._owner = owner;
			return this.Run(rpt);
		}
		#endregion
		
		// ===============================================================================
		// �����֐�
		// ===============================================================================
		#region private methods	
		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		private void CreateReport()
		{
			try
			{
				string message;
                ActiveReport3 prtRpt;

                // �v�����^���ݒ�
				if (this._commonLib.SetPrinterInfo(ref this._viewRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

                try
                {
                    //��а�ް�����ޭ��ȊO
                    if (_commonInfo.PrintMode != 4)
                    {
                        if (_commonInfo.PrintPprBgImageData != null)
                        {
                            //�w�i�摜������
                            SFANL08235CE.SetValidPaperKind(this._viewRpt);
                            prtRpt = SFANL08235CE.OverlayImage(this._viewRpt, (Bitmap)_commonInfo.PrintPprBgImageData, _commonInfo.PrtPprBgImageRowPos, _commonInfo.PrtPprBgImageColPos);
                            SFANL08235CE.SetValidPaperKind(this._viewRpt);
                            this.viewer1.Document = prtRpt.Document;
                        }
                        else
                        {
                            this._viewRpt.Run();
                            this.viewer1.Document = this._viewRpt.Document;
                        }
                    }
                    else
                    {
                        this.viewer1.Document = this._viewRpt.Document;
                    }
                    this.viewer1.Show();
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08203UB", "���|�[�g�̍쐬�Ɏ��s���܂���\r\n" +
                                                                                  "�ڍׁF"+ex.Message, 0, MessageBoxButtons.OK);
                    this.viewer1.Document.Dispose();
                    this.viewer1.Dispose();
                    GC.Collect();
                    this.Close();
                    return;
                }
			}
            catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message + "\n\r" + ex.StackTrace + ex.Source, -1);
			}
		}
		
		/// <summary>
		/// �v���r���[�\���f���Q�[�g�ďo����
		/// </summary>
		private void ShowPreview()
		{
			try
			{
				Invoke(new CreateReportDelegate(CreateReport));
			}
			catch (ActiveReportPrintException ex)
			{
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				
				this.DialogResult     = DialogResult.Abort;
			}
		}

		/// <summary>
		/// �v���r���[��ʏ����ݒ�
		/// </summary>
		private void InitialScreen()
		{
			// �g�嗦�̐ݒ�
			if (this._commonInfo.ExpansionRate != 0)
			{
				float fx = (float)this._commonInfo.ExpansionRate / 100.0F;
				this.viewer1.ReportViewer.Zoom = fx;
			}
			// �u����v�{�^�����J�X�^�}�C�Y
			// �f�t�H���g�u����v�{�^�����폜
			this.viewer1.Toolbar.Tools.RemoveAt(2);

			// �J�X�^���u����v�{�^���̍쐬
			DataDynamics.ActiveReports.Toolbar.Button printBtn =
				new DataDynamics.ActiveReports.Toolbar.Button();
			printBtn.Caption     = "���";
			printBtn.ToolTip     = "��������s���܂�";
			printBtn.ImageIndex  = 1;
			printBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
			printBtn.Id          = 5000;

			this.viewer1.Toolbar.Tools.Insert(2, printBtn);

            //�t�H�[���̃T�C�Y�A�ʒu�𒲐�
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = 0;
            this.Left = 0;
		}
		
		#endregion
		
		// ===============================================================================
		// �R���g���[���C�x���g
		// ===============================================================================
		#region control event
		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void SFANL08203UB_Load(object sender, System.EventArgs e)
		{
			// ��ʏ����ݒ�
			this.InitialScreen();
			
			// ��������C�x���g���C�x���g�n���h���Ɋ֘A�Â��܂�
			this._prtRpt.Document.Printer.EndPrint
				+= new System.Drawing.Printing.PrintEventHandler(onEndPrint);

			// �v���r���[�p�h�L�������g�쐬�X���b�h
            Thread prevThread =
                new Thread(new ThreadStart(ShowPreview));

            prevThread.IsBackground = true;
            prevThread.SetApartmentState(ApartmentState.STA);
            prevThread.Start();			
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			// ���|�[�g�C���X�^���X�ύX��ԃt���O
			bool isRpxCange         = false;
			
			switch (e.Tool.Id)
			{
				case CT_TOOLBUTTON_PRINT:	// ���
				{
					Cursor nowCursor = this.Cursor;

					try
					{
						this.Cursor = Cursors.WaitCursor;
					
						if (this._commonInfo != null)
						{
							isRpxCange = ((this._commonInfo.HideControlList != null) && (this._commonInfo.HideControlList.Count > 0));
							
							// ��\���R���g���[���L��
							if (isRpxCange)
							{
								// �R���g���[���ύX
								this.ChangeARCtrlView(ref this._prtRpt, false, this._commonInfo.HideControlList);  

								// �v���r���[��ʂ��B��
								this.Hide();

								// �e��ʂ��A�N�e�B�u��
								if (this.Owner != null)
								{
									this.Owner.Activate();
								}

								// ����h�L�������g�č쐬
                                try{
								    this._prtRpt.Run();
                                }
                                catch (Exception ex)
                                {
                                    string msg = ex.Message;
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFANL08203UB", "����Ɏ��s���܂����B\r\n�ڍׁF" + ex.Message, 0, MessageBoxButtons.OK);
                                    this._prtRpt.Document.Dispose();
                                    this._prtRpt.Dispose();
                                    GC.Collect();
                                    this.Close();
                                    return;
                                }
							}
						}
						 //������[�h = �������
                        if (this._commonInfo.PrintMode == 0)
                        {
                            // PDF�o��
                            this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
                        }

						// ������s
						this._prtRpt.Document.Print(this._isShowPrintDialog,false,false);

						// ��\���R���g���[���ɕύX�L��H
						if (isRpxCange)
						{
							// �R���g���[���ύX
							this.ChangeARCtrlView(ref this._prtRpt, true, this._commonInfo.HideControlList);  
						}
					}
					finally
					{
						this.Cursor = nowCursor; 
					}
					break;
				}
				case CT_TOOLBUTTON_CLOSE:		// ����
				{
					this.Close();
					break;
				}
			}
		}

		/// <summary>
		/// �A�N�e�B�u���|�[�gARControl�\����Ԑ���
		/// </summary>
		/// <param name="rpt">�Y�����|�[�g</param>
		/// <param name="isVisibled">�\���E��\��</param>
		/// <param name="ctrlList">�ύX����R���g���[�����X�g</param>
		private void ChangeARCtrlView(ref ActiveReport3 rpt, bool isVisibled, StringCollection ctrlList)
		{
			foreach (string name in ctrlList)
			{
				foreach (Section wkSection in rpt.Sections)
				{
					try
					{
						ARControl wkControl = wkSection.Controls[name];
						if (wkControl != null)
						{
							wkControl.Visible = isVisibled;
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
		
		/// <summary>
		/// �e�L�X�g�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
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
		/// ��������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void onEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
        
        /// <summary>
        /// �e�L�X�g�`�F���W�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void SFANL08203UB_TextChanged(object sender, EventArgs e)
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203UB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // �����L�[�ABackSpace�ȊO�̓��͂��󂯕t���Ȃ�
            if ((e.KeyChar != (Char)Keys.Back) &&
                ((e.KeyChar < '0') || (e.KeyChar > '9'))
                )
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// �L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203UB_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        #endregion


        


	}
}

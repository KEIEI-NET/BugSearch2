#define CLR2
#define CLR2_CHG20060420
using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport���ʃ��|�[�g��������ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr������̋��ʃ��|�[�g��������ʃN���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.17</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki CLR2</br>
	/// <br>           : �P.VS2005(.NET Framework version 2.0) �Ή� </br>
	/// <br>           :    ApartmentState�̐ݒ���@���A2.0�Œǉ����ꂽ���\�b�h�g�p</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki CLR2_CHG20060420</br>
	/// <br>           : �P.�X���b�h����������BackgroudWorker�R���|�[�l���g���g�p����悤�ɕύX�B </br>
	/// <br>Update Note: 2006.09.14 Y.Sasaki</br>
	/// <br>           : �P.�i�ǑΉ� No.02204357-88-1-000149-01</br>
	/// <br>           :    �����}�[�W�����̃p�^���̍ہA�}�[�W���̃��|�[�g�Ɉ�����ݒ肪����ĂȂ������̂ŏC���B</br>
	/// </remarks>
	public class SFCMN00293UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel Process_Label;
		private Infragistics.Win.Misc.UltraLabel Printname_Label;
		private Infragistics.Win.Misc.UltraLabel Printer_Label;
		private Infragistics.Win.UltraWinProgressBar.UltraProgressBar Main_ProgressBar;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
		private System.ComponentModel.BackgroundWorker bgWorkerPrint;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport���ʃ��|�[�g��������ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public SFCMN00293UB()
		{
			InitializeComponent();
		
			// ���ʊ֐����i�C���X�^���X�쐬
			this._commonLib = new SFCMN00293UZ();

			// �󎚈ʒu�������i�C���X�^���X�쐬
			this._positionAdjPrtLib = new SFCMN00294CA();
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.Process_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Printname_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Printer_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Main_ProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
			this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
			this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			this.bgWorkerPrint = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// Process_Label
			// 
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Process_Label.Appearance = appearance1;
			this.Process_Label.Location = new System.Drawing.Point(0, 0);
			this.Process_Label.Name = "Process_Label";
			this.Process_Label.Size = new System.Drawing.Size(434, 14);
			this.Process_Label.TabIndex = 0;
			// 
			// Printname_Label
			// 
			appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Printname_Label.Appearance = appearance2;
			this.Printname_Label.Location = new System.Drawing.Point(0, 14);
			this.Printname_Label.Name = "Printname_Label";
			this.Printname_Label.Size = new System.Drawing.Size(434, 14);
			this.Printname_Label.TabIndex = 1;
			// 
			// Printer_Label
			// 
			appearance3.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Printer_Label.Appearance = appearance3;
			this.Printer_Label.Location = new System.Drawing.Point(0, 28);
			this.Printer_Label.Name = "Printer_Label";
			this.Printer_Label.Size = new System.Drawing.Size(434, 14);
			this.Printer_Label.TabIndex = 2;
			// 
			// Main_ProgressBar
			// 
			appearance4.ForeColor = System.Drawing.Color.Black;
			this.Main_ProgressBar.FillAppearance = appearance4;
			this.Main_ProgressBar.Location = new System.Drawing.Point(36, 51);
			this.Main_ProgressBar.Name = "Main_ProgressBar";
			this.Main_ProgressBar.Size = new System.Drawing.Size(360, 18);
			this.Main_ProgressBar.TabIndex = 3;
			this.Main_ProgressBar.Text = "[Formatted]";
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Location = new System.Drawing.Point(168, 83);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(92, 23);
			this.Cancel_Button.TabIndex = 4;
			this.Cancel_Button.Text = "�L�����Z��";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
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
			// bgWorkerPrint
			// 
			this.bgWorkerPrint.WorkerSupportsCancellation = true;
			this.bgWorkerPrint.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerPrint_DoWork);
			this.bgWorkerPrint.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerPrint_RunWorkerCompleted);
			// 
			// SFCMN00293UB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 12);
			this.ClientSize = new System.Drawing.Size(434, 108);
			this.ControlBox = false;
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.Main_ProgressBar);
			this.Controls.Add(this.Printer_Label);
			this.Controls.Add(this.Printname_Label);
			this.Controls.Add(this.Process_Label);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFCMN00293UB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�����";
			this.Load += new System.EventHandler(this.SFCMN00293UB_Load);
			this.ResumeLayout(false);

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
			System.Windows.Forms.Application.Run(new SFCMN00293UB());
		}
		#endregion
	
		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
#if !CLR2_CHG20060420		
		private Thread printThread                                 = null;
#endif
		private SFCMN00293UZ _commonLib                            = null;
		private SFCMN00293UC _commonInfo                           = null;
		private System.Type _type                                  = null;
		private PropertyInfo _isDiscontinuePi                      = null;
		
		private DataDynamics.ActiveReports.ActiveReport3 _rpt       = null;

		private DataDynamics.ActiveReports.ActiveReport3 _cancelRpt = null;				// ���f�Ώۃ��|�[�g�C���X�^���X
		private ArrayList _rptList                                 = null;				// �}�[�W���|�[�g�C���X�^���X�i�[�p		
		private ArrayList _discontinuePiList                       = null;				// �}�[�W���|�[�gPropertyInfo�i�[�p
		private int _margeCount                                    = 0;						// �}�[�W�p��������ۑ��o�b�t�@
		private bool _showProgressDialog                           = true;				// ��ʕ\�����
		private bool _isDiscontinue                                = false;				// ���f�t���O
		private SFCMN00294CA _positionAdjPrtLib                    = null;				// �󎚈ʒu�������i(����p)
		
		// ���f��ʐݒ�񓯊��f���Q�[�g
		private delegate void initialSettingHandler(string printnm, string printernm, int printMax);
		private delegate void maxSettingHandler(int max);
		private delegate void processSettingHandler(int cnt);
		#endregion
	
		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region public property
		/// <summary>���ʉ�ʏ����v���p�e�B</summary>
		public SFCMN00293UC CommonInfo
		{
			get{return this._commonInfo;}
			set{this._commonInfo = value;}
		}
		#endregion
		
		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region public methods
		/// <summary>
		/// ������_�C�A���O�\���������
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ������_�C�A���O��\�����A����������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// ��ʕ\��
			this._showProgressDialog = true;
			
			// ���f�{�^����\��
			this.Cancel_Button.Visible = false;
			
			// �����ϐ�������
			this._type            = null;
			this._isDiscontinuePi = null;
			
			this._type = rpt.GetType();
			
			// ���f�t���O���擾���܂�
			if (this._type != null)
			{
				// ���I�ɒ��f�t���O�v���p�e�B���擾����
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");
				
				// ���f�t���O�v���p�e�B���錾����Ă���΁A���f�{�^���g�p�\
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}
			
			this._rpt = rpt;
			
			DialogResult dr = this.ShowDialog();
			switch(dr)
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
		/// ������_�C�A���O�\���������
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <param name="showProgressDialog">�_�C�A���O��ʕ\���L��</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ������_�C�A���O��\���E��\����ؑւ��āA����������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// ��ʕ\�����
			this._showProgressDialog = showProgressDialog;
			
			// ���f�{�^����\��
			this.Cancel_Button.Visible = false;
			
			// �����ϐ�������
			this._type            = null;
			this._isDiscontinuePi = null;
			
			this._type = rpt.GetType();
			
			// ���f�t���O���擾���܂�
			if (this._type != null)
			{
				// ���I�ɒ��f�t���O�v���p�e�B���擾����
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");
				
				// ���f�t���O�v���p�e�B���錾����Ă���΁A���f�{�^���g�p�\
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}
			
			this._rpt = rpt;
			
			// ��ʕ\���L��
			if (this._showProgressDialog)
			{
				DialogResult dr = this.ShowDialog();
				switch(dr)
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
				// ��ʕ\������
			else 
			{
				// ����������s
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}

		/// <summary>
		/// ����h�L�������g�쐬����
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <param name="showProgressDialog">�_�C�A���O��ʕ\���L��</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ������_�C�A���O��\���E��\����ؑւ��āA����h�L�������g�쐬�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		public int MakeDocument(DataDynamics.ActiveReports.ActiveReport3 rpt, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ��ʕ\�����
			this._showProgressDialog = showProgressDialog;

			// ���f�{�^����\��
			this.Cancel_Button.Visible = false;

			// �����ϐ�������
			this._type = null;
			this._isDiscontinuePi = null;

			this._type = rpt.GetType();

			// ���f�t���O���擾���܂�
			if (this._type != null)
			{
				// ���I�ɒ��f�t���O�v���p�e�B���擾����
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");

				// ���f�t���O�v���p�e�B���錾����Ă���΁A���f�{�^���g�p�\
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}

			this._rpt = rpt;

			// ��ʕ\���L��
			if (this._showProgressDialog)
			{
				DialogResult dr = this.ShowDialog();
				switch (dr)
				{
					case DialogResult.OK:
					case DialogResult.None:
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel:
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			// ��ʕ\������
			else
			{
				// ����������s
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}
		
		/// <summary>
		/// ������_�C�A���O�\���������(�������|�[�g�}�[�W)
		/// </summary>
		/// <param name="rptList">�Ώۃ��|�[�g�C���X�^���X���X�g</param>
		/// <param name="showProgressDialog">�_�C�A���O��ʕ\���L��</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ������_�C�A���O��\���E��\����ؑւ��āA�}�[�W���Ȃ������������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		public int Run(ArrayList rptList, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// ��ʕ\��
			this._showProgressDialog = showProgressDialog;
			
			// ���f�{�^����\��
			this.Cancel_Button.Visible = false;
			
			// �����ϐ�������
			this._type            = null;
			this._isDiscontinuePi = null;
			
			// ����|�[�g�擾
			this._rpt = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
			
			// ���f�t���O�擾
			this._isDiscontinuePi = this.GetCustomProperty(this._rpt, "IsDiscontinue");
			
			// ���f�t���O�v���p�e�B���錾����Ă���΁A���f�{�^���g�p�\
			if (this._isDiscontinuePi != null)
			{
				this.Cancel_Button.Visible = true;
				this._isDiscontinuePi.SetValue(this._rpt, false, null);
			}
			
			// �}�[�W���|�[�g�擾
			if (rptList.Count - 1 > 0)
			{
				this._rptList = new ArrayList();
				this._discontinuePiList = new ArrayList();
				
				for (int i = 1; i <= rptList.Count - 1; i++)
				{
					if (rptList[i] is DataDynamics.ActiveReports.ActiveReport3)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt = 
							(DataDynamics.ActiveReports.ActiveReport3)rptList[i];
						
						// ���|�[�g�C���X�^���X�ǉ�
						this._rptList.Add(wkRpt);

						// ���I�ɒ��f�t���O�v���p�e�B���擾����
						PropertyInfo pi = this.GetCustomProperty(wkRpt, "IsDiscontinue");
						this._discontinuePiList.Add(pi);
					}
				}
			} 
			else 
			{
				this._rptList = null;
			}
			// ��ʕ\���L��
			if (this._showProgressDialog)
			{

				DialogResult dr = this.ShowDialog();
				switch(dr)
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
			else 
			{
				// ����������s
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}
		
		/// <summary>
		/// �v���O���X�o�[�i���󋵐ݒ菈��
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="printCount">����쐬����</param>
		/// <remarks>
		/// <br>Note       : �v���O���X�o�[�̐i���󋵂�ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public void ProgressBarUpEvent(object sender, int printCount)
		{
			// ��ʕ\���L�胂�[�h�̂�
			if (this._showProgressDialog)
			{
				this.ProcessSetting(printCount);
			}
		}
		#endregion

		//================================================================================
		//  ��������
		//================================================================================
		#region private method        
		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void BackGroudPrintProc(BackgroundWorker worker, DoWorkEventArgs e)
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this._isDiscontinue = false;

			string message;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
            // 2:�o�c�e�o�͂Ȃ��
            if ( this._commonInfo.PrintMode == 2 )
            {
                // �h�b�g�v�����^��I������
                _commonLib.SelectDotPrinter( ref _commonInfo );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

			// �󎚈ʒu����
			this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);

			// ������ݒ�
			if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0)
			{
				this.DialogResult = DialogResult.Abort;
				return;
			}

			// �}�[�W�p�J�E���g������
			this._margeCount = 0;

			// ����J�n
			this._cancelRpt = this._rpt;
			this._rpt.Run();

			// ���f�m�F
			if (this._isDiscontinue) return;

			// �}�[�W���|�[�g�͂��邩�H
			if (this._rptList != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                // 2:�o�c�e�o�͂Ȃ��
                if ( this._commonInfo.PrintMode == 2 )
                {
                    // �h�b�g�v�����^��I������
                    _commonLib.SelectDotPrinter( ref _commonInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

				for (int i = 0; i < this._rptList.Count; i++)
				{
					// �L�����Z�����ꂽ
					if (worker.CancellationPending)
					{
						e.Cancel = true;
					}

					DataDynamics.ActiveReports.ActiveReport3 wkRpt
						= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

					// �v���O���X�o�[���ݒl�擾
					this._margeCount += this.Main_ProgressBar.Value;

					this._cancelRpt = wkRpt;

					// �󎚈ʒu����
					this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

					// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
					// ������ݒ�
					if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
					{
						this.DialogResult = DialogResult.Abort;
						return;
					}
					// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
					
					wkRpt.Run();

					this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
				}
			}

			if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
			{
				switch (this._commonInfo.PrintMode)
				{
					case 1:		// �v�����^�o��
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                            //this._rpt.Document.Print(false, false, false);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                            this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                            break;
						}
					case 2:   // PDF�o��
						{
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
					case 3:		// ����
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                            //this._rpt.Document.Print(false, false, false);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                            this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                            this.pdfExport1.Export( this._rpt.Document, this._commonInfo.PdfFullPath );
							break;
						}
					default:
						break;
				}

				// �߂�STATUS�ݒ�
				this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
		}

		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void PrintProc()
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR; 
			
			this.Cancel_Button.Enabled = true;
			this._isDiscontinue        = false;
			
			try
			{
				// ��ʐݒ�
				this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
				string message;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                // 2:�o�c�e�o�͂Ȃ��
                if ( this._commonInfo.PrintMode == 2 )
                {
                    // �h�b�g�v�����^��I������
                    _commonLib.SelectDotPrinter( ref _commonInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

				// �󎚈ʒu����
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);
				
				// ������ݒ�
				if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				// �}�[�W�p�J�E���g������
				this._margeCount = 0;
				
				// ����J�n
				this._cancelRpt = this._rpt;
				this._rpt.Run();

				// ���f�m�F
				if (this._isDiscontinue) return;

				// �}�[�W���|�[�g�͂��邩�H
				if (this._rptList != null)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                    // 2:�o�c�e�o�͂Ȃ��
                    if ( this._commonInfo.PrintMode == 2 )
                    {
                        // �h�b�g�v�����^��I������
                        _commonLib.SelectDotPrinter( ref _commonInfo );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt 
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						this._isDiscontinuePi = (PropertyInfo)this._discontinuePiList[i];
						
						// �v���O���X�o�[���ݒl�擾
						this._margeCount += this.Main_ProgressBar.Value;
						
						this._cancelRpt = wkRpt;
						
						// �󎚈ʒu����
						this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

						// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
						// ������ݒ�
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
						{
							this.DialogResult = DialogResult.Abort;
							return;
						}
						// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
						
						wkRpt.Run();

						// ���f�m�F
						if (this._isDiscontinue) return;

						this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}
				
				// ���f�{�^������
				this.Cancel_Button.Enabled = false;
				
				if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
				{
					switch (this._commonInfo.PrintMode)
					{
						case 1:		// �v�����^�o��
						{
							this._rpt.Document.Print(false,false,false);
							break;
						}
						case 2:   // PDF�o��
						{
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
						case 3:		// ����
						{
							this._rpt.Document.Print(false,false,false);
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
						default:
							break;
					}
			
					// �߂�STATUS�ݒ�
					this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; 
					this.DialogResult      = DialogResult.OK;
				} 
					// ������L�����Z�����ꂽ�H
				else 
				{
					this.DialogResult = DialogResult.Cancel;
				}
			}
			
			catch (ActiveReportPrintException ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
  		}
			
			catch (Exception ex)
			{
				this.DialogResult      = DialogResult.Abort;

				string message = "������������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message;
				
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// �󎚈ʒu�������i�j��
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}
				
				// ��ʕ\���L��̎��̂�
				if (this._showProgressDialog)
				{
					this.Close();
				}
			}
		}

		/// <summary>
		/// ������C������
		/// </summary>
		/// <param name="IsPrint">����L��[T:�������,F:�h�L�������g�쐬�̂�]</param>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		private void PrintProc(bool IsPrint)
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.Cancel_Button.Enabled = true;
			this._isDiscontinue = false;

			try
			{
				// ��ʐݒ�
				this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
				string message;

				// �󎚈ʒu����
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);

				// ������ݒ�
				if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0)
				{
					this.DialogResult = DialogResult.Abort;
					return;
				}

				// �}�[�W�p�J�E���g������
				this._margeCount = 0;

				// ����J�n
				this._cancelRpt = this._rpt;
				this._rpt.Run();

				// ���f�m�F
				if (this._isDiscontinue) return;

				// �}�[�W���|�[�g�͂��邩�H
				if (this._rptList != null)
				{
					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						this._isDiscontinuePi = (PropertyInfo)this._discontinuePiList[i];

						// �v���O���X�o�[���ݒl�擾
						this._margeCount += this.Main_ProgressBar.Value;

						this._cancelRpt = wkRpt;

						// �󎚈ʒu����
						this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

						// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
						// ������ݒ�
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
						{
							this.DialogResult = DialogResult.Abort;
							return;
						}
						// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

						wkRpt.Run();

						// ���f�m�F
						if (this._isDiscontinue) return;

						this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}

				// ���f�{�^������
				this.Cancel_Button.Enabled = false;

				if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
				{
					switch (this._commonInfo.PrintMode)
					{
						case 1:		// �v�����^�o��
							{
                                if ( IsPrint )
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                                    //this._rpt.Document.Print(false, false, false);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                                    this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
								break;
							}
						case 2:   // PDF�o��
							{
								if (IsPrint)
									this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
								break;
							}
						case 3:		// ����
							{
								if (IsPrint)
								{
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                                    //this._rpt.Document.Print(false, false, false);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                                    this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                                    this.pdfExport1.Export( this._rpt.Document, this._commonInfo.PdfFullPath );
								}
								break;
							}
						default:
							break;
					}

					// �߂�STATUS�ݒ�
					this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
					this.DialogResult = DialogResult.OK;
				}
				// ������L�����Z�����ꂽ�H
				else
				{
					this.DialogResult = DialogResult.Cancel;
				}
			}

			catch (ActiveReportPrintException ex)
			{

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}

			catch (Exception ex)
			{
				this.DialogResult = DialogResult.Abort;

				string message = "������������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message;

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// �󎚈ʒu�������i�j��
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}

				// ��ʕ\���L��̎��̂�
				if (this._showProgressDialog)
				{
					this.Close();
				}
			}
		}

		
		/// <summary>
		/// �v���p�e�B���I�擾
		/// </summary>
		/// <param name="targetObj"></param>
		/// <param name="targetName"></param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		private PropertyInfo GetCustomProperty(object targetObj, string targetName)
		{
			PropertyInfo pi = null;
			System.Type type = targetObj.GetType();

			if (type != null)
			{
				// ���I�ɒ��f�t���O�v���p�e�B���擾����
				pi = type.GetProperty(targetName);
			} 
			return pi;
		}
		
		
		/// <summary>
		/// ������ʐݒ菈��
		/// </summary>
		/// <param name="printnm">������[��</param>
		/// <param name="printernm">�v�����^�[��</param>
		/// <param name="printMax">�������</param>
		/// <remarks>
		/// <br>Note       : �ďo���X���b�h�𔻒肵�A��ʏ����ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void ScreenSetting(string printnm, string printernm, int printMax)
		{
			// �ďo���̃X���b�h�𔻒�
			if (this.InvokeRequired == false)
			{
				this.InitialSetting(printnm,printernm,printMax);
			} 
			// �ʃX���b�h�̏ꍇ
			else 
			{
				initialSettingHandler _initsetting = new initialSettingHandler(InitialSetting);
                        
				Object[] parmList1 = {printnm,printernm,printMax};
                        
				this.BeginInvoke(_initsetting, parmList1);
			}
		}
		
		
		/// <summary>
		/// ��ʏ����ݒ�
		/// </summary>
		/// <param name="printnm">�o�͖�</param>
		/// <param name="printernm">�o�̓v�����^�[��</param>
		/// <param name="max">�������</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void InitialSetting(string printnm, string printernm, int max)
		{
			string message     = "������ł��B";
			string printerName = printernm; 
			
			switch (this._commonInfo.PrintMode)
			{
				case 1:		// �v�����^
					break;
				case 2:		// �o�c�e
					printerName = "PDF";
					message     = "�o�͒��ł��B";
					break;
				case 3:
					break;
				default:
					break;
			}
			
			this.Printname_Label.Text = String.Format("�u{0}�v��", printnm);
			this.Printer_Label.Text   = printerName + "��"+ message;

			if (max != 0)
			{
				this.Main_ProgressBar.Visible = true;
				this.Main_ProgressBar.Maximum = max; 
				this.Main_ProgressBar.Minimum = 0; 
			} 
			else 
			{
				this.Main_ProgressBar.Visible = false;
			}
		}

		/// <summary>
		/// �o�͌����ݒ菈��
		/// </summary>
		/// <param name="cnt">�o�͌���</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̏o�͍ς݌������X�V���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void ProcessSetting (int cnt)
		{
			string message = "������ł��B";
			switch (this._commonInfo.PrintMode)
			{
				case 1:		// �v�����^
					break;
				case 2:		// �o�c�e
					message = "�o�͒��ł��B";
					break;
				case 3:
					break;
				default:
					break;
			}

			if (this._commonInfo.PrintMax != 0)
			{
				this.Main_ProgressBar.Value = this._margeCount + cnt;
				this.Main_ProgressBar.Refresh();
				this.Process_Label.Text = String.Format("���݁A{0}�^{1}�� ��{2}", this._margeCount + cnt, this._commonInfo.PrintMax, message);
				this.Process_Label.Refresh();
			} 
			else 
			{
				this.Process_Label.Text = String.Format("���݁A{0}���@��{1}",this._margeCount + cnt, message);
				this.Process_Label.Refresh();
			}
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
		/// <remarks>
		/// <br>Note        : ��ʂ����[�h���ꂽ�ہA��������C�x���g�ł��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.15</br>
		/// </remarks>
		private void SFCMN00293UB_Load(object sender, System.EventArgs e)
		{
#if CLR2_CHG20060420
			this.Cancel_Button.Enabled = true;
			
			// ��ʐݒ�
			this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
			
			this.bgWorkerPrint.RunWorkerAsync();
#else
			// ����p�X���b�h�̍쐬
			this.printThread = new Thread(new ThreadStart(this.PrintProc));
			
			printThread.IsBackground   = true;
#if CLR2
			printThread.SetApartmentState(ApartmentState.STA);
#else
			printThread.ApartmentState = ApartmentState.STA;
#endif
			
			this.printThread.Start();
#endif
		}

		private void bgWorkerPrint_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			this.BackGroudPrintProc(this.bgWorkerPrint, e);
		}

		/// <summary>
		/// RunWorkerCompleted�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note        : ���[�J�[�������������ɔ������܂��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2006.04.20</br>
		/// </remarks>
		private void bgWorkerPrint_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.DialogResult = DialogResult.Abort;
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					e.Error.Message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			} else if (e.Cancelled) {
				this.DialogResult = DialogResult.Cancel;
			} else {
				this.DialogResult = DialogResult.OK;
			}

			// �󎚈ʒu�������i�j��
			if (this._positionAdjPrtLib != null)
			{
				this._positionAdjPrtLib.Dispose();
			}

			// ��ʕ\���L��̎��̂�
			if (this._showProgressDialog)
			{
				this.Close();
			}
		}
		
		
		/// <summary>
		/// �L�����Z���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note        : �L�����Z���{�^�����N���b�N���ꂽ�ہA��������C�x���g�ł��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.15</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
#if CLR2_CHG20060420
			// ���f�t���O�𗧂Ă�
			this._isDiscontinuePi.SetValue(this._cancelRpt, true, null);
			this._isDiscontinue = true;
#else
			// ����X���b�h���f
			this.printThread.Suspend();
            
			DialogResult dr = 
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "������ł��B"+ "\n" + "�����𒆒f���Ă���낵���ł����H",
				0, MessageBoxButtons.YesNo,MessageBoxDefaultButton.Button2);

			switch (dr)
			{
				case DialogResult.Yes:

					// ���f�t���O�𗧂Ă�
					this._isDiscontinuePi.SetValue(this._cancelRpt, true, null);
					this._isDiscontinue = true;
					
					this.printThread.Resume();
					this.printThread.Join();
					
					this.DialogResult = DialogResult.Cancel;
					break;
				case DialogResult.No:
					this.printThread.Resume();
					break;
			}
#endif
		}
		#endregion
	}
}

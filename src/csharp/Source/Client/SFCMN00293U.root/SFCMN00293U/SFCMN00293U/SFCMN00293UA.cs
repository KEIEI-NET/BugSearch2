#define ADD20060407
#define CHG20060417
#define CLR2
#define CHG20060509
using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.17</br>
	/// <br>Update Note: 2006.04.07 Y.Sasaki</br>
	/// <br>           : �P.�i�ǑΉ� 02204357-2-1-000058-01</br>
	/// <br>           :    ���L�[�AEnter�L�[�͖��������Ȃ�</br>
	/// <br>Update Note: 2006.04.17 Y.Sasaki</br>
	/// <br>           : �P.�o�c�e�o�̓^�C�~���O�̕ύX�B</br>
	/// <br>           :    ������ɍ쐬����B</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki</br>
	/// <br>           : �P.VS2005(.NET Framework version 2.0) �Ή� </br>
	/// <br>           :    ApartmentState�̐ݒ���@���A2.0�Œǉ����ꂽ���\�b�h�g�p</br>
	/// <br>Update Note: 2006.04.21 Y.Sasaki</br>
	/// <br>           : �P.Thread.Suspend, Thread.Resume ���g��Ȃ��悤�ɕύX�B</br>
	/// <br>Update Note: 2006.05.09 Y.Sasaki</br>
	/// <br>           : �P.�v���r���[�p�E����p�ƕʁX�̃X���b�h�ō쐬���Ă��邪�A</br>
	/// <br>           :    �o�C���h���Ă���f�[�^������f�[�^�\�[�X�������ꍇ�A</br>
	/// <br>           :    �^�C�~���O�ɂ���肪��������ׁA���ǁB</br>
	/// <br>Update Note: 2006.07.25 Y.Sasaki</br>
	/// <br>           : �P.Visual�󎚈ʒu��������v���r���[��������ꂽ�ꍇ�A</br>
	/// <br>           :    �g�b�v���x���E�B���h�E���ς�錻�ۂ������B</br>
	/// <br>Update Note: 2007.02.28 Y.Sasaki</br>
	/// <br>           : �P.�g��.NS�p�ɉ���</br>
    /// <br>Update Note: 2012/05/17 yangmj</br>
    /// <br>           : �w��y�[�W����̒ǉ�</br>
	/// </remarks>
	public class SFCMN00293UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;

		#endregion

		private System.ComponentModel.IContainer components = null;

		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport���ʃv���r���[��ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ʃv���r���[��ʃN���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public SFCMN00293UA()
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
//				// �C�x���g�ɒǉ�
//				placeHolder2.Control.TextChanged += new System.EventHandler(this.ViewerZoom_TextChanged);
//				placeHolder2.Control.KeyPress += new KeyPressEventHandler(this.ViewerZoom_KeyPress);
//#if ADD20060407				
//				placeHolder2.Control.KeyDown += new KeyEventHandler(this.ViewerZoom_KeyDown);
//#endif
			}
			
			// ���ʊ֐����i�C���X�^���X�쐬
			this._commonLib = new SFCMN00293UZ();
		
			// �ݒ�t�@�C���Ǎ�
			if (this._commonLib.ReadSettingFile(CT_PrintCommonWindow))
			{
				string wkStr = (string)this._commonLib.ReadSection(CT_PrintPreviewWindow,CT_BackgroundPicture);
				
				// �w�i�摜�R���g���[���̗L��
				this._isBackGroundPicture = (TStrConv.StrToIntDef(wkStr,0) == 1);
			}
		
			// �󎚈ʒu�������i�C���X�^���X�쐬
			this._positionAdjViewLib  = new SFCMN00294CA();						// �󎚈ʒu�������i(View�p)
			this._positionAdjPrtLib   = new SFCMN00294CA();						// �󎚈ʒu�������i(����p)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN00293UA));
			this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
			this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
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
			// pdfExport1
			// 
			this.pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));
			// 
			// SFCMN00293UA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.viewer1);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Name = "SFCMN00293UA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "����v���r���[";
			this.Closed += new System.EventHandler(this.SFCMN00293UA_Closed);
			this.Load += new System.EventHandler(this.SFCMN00293UA_Load);
			this.ResumeLayout(false);

            //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�----->>>>>
            DataDynamics.ActiveReports.Toolbar.Separator separator =new DataDynamics.ActiveReports.Toolbar.Separator();
            separator.Id = 110;
            this.viewer1.Toolbar.Tools.Add(separator);

            DataDynamics.ActiveReports.Toolbar.Button printPageBtn = new DataDynamics.ActiveReports.Toolbar.Button();
            printPageBtn.Caption = "����y�[�W�w��";
            printPageBtn.ToolTip = "����y�[�W���w�肵�܂�";
            printPageBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.Text;
            printPageBtn.Id = 5030;
            this.viewer1.Toolbar.Tools.Add(printPageBtn);
            //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�-----<<<<<
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
		
		private ArrayList _rptList = null;													// �}�[�W���|�[�g�C���X�^���X�i�[�p		
		private SFCMN00293UC _commonInfo = null;										// ���ʐݒ���N���X
		private SFCMN00293UZ _commonLib  = null;										// ���ʕ��i�N���X
		private int _screenLoadMode;																// ��ʋN�����[�h
		private int _watermarkMode = 0;															// �w�i�摜�\�����[�h
		private string _bufText;																		// �y�[�W���ޔ�p
		private string _bufZoomText;																// �Y�[���ޔ�p
		private bool _isShowPrintDialog   = true;										// ����_�C�A���O�\���L��
		private bool _isBackGroundPicture = false;									// �w�i�摜�R���g���[���L��
		
		SFCMN00294CA _positionAdjViewLib  = null;										// �󎚈ʒu�������i(View�p)
		SFCMN00294CA _positionAdjPrtLib   = null;										// �󎚈ʒu�������i(����p)

		// >>>>> 2006.07.25 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		private IWin32Window _owner = null;													// �g�b�v���x���E�B���h�E	
		// <<<<< 2006.07.25 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

		private bool _isShowing = false;														// ��ʕ\�����t���O
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		// �c�[���o�[�{�^���h�c
		private const int CT_TOOLBUTTON_PRINT = 5000;								// �u����v�{�^��ID
		private const int CT_TOOLBUTTON_CLOSE = 5020;								// �u����v�{�^��ID
        private const int CT_TOOLBUTTON_PAGE = 5030;								// �u����y�[�W�w��v�{�^��ID //ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�
		
		//--- �ݒ�t�@�C���n�̒萔��` ---------------------------------------------------
		// �ݒ�t�@�C����
		private const string CT_PrintCommonWindow  = "PrintCommonWindow.XML";
		// �v���r���[��ʂ̃Z�N�V������
		private const string CT_PrintPreviewWindow = "PrintPreviewWindow";
		// �w�i�摜�̐ݒ�L��KEY
		private const string CT_BackgroundPicture  = "BackgroundPicture";
		#endregion
		
		delegate void CreateReportDelegate();
		
		//================================================================================
		//  �񋓌^
		//================================================================================
		#region enum
		/// <summary>��ʋN�����[�h</summary>
		private enum ScreenLoadMode : int
		{
			/// <summary>���|�[�g���s�E�r���[</summary>
			RunAndViewMode = 0,
			/// <summary>�r���[</summary>
			ViewOnlyMode   = 1
		}
		
		/// <summary>
		/// �w�i�������v���r���[
		/// </summary>
		private enum emWaterMarkMode : int
		{
			/// <summary>�ʏ�v���r���[</summary>
			NormalPreview = 0,
			/// <summary>�w�i�������v���r���[</summary>
			WaterMarkPreview = 1
		}
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
			System.Windows.Forms.Application.Run(new SFCMN00293UA());
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
		/// <remarks>
		/// <br>Note       : ���|�[�g�𐶐����Ȃ���A�������ꂽ�y�[�W���珇���v���r���[���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			this.DialogResult = DialogResult.Cancel;
			
			try
			{
				// �ʏ�v���r���[���[�h
				this._watermarkMode  = (int)emWaterMarkMode.NormalPreview;
			
				// �N�����[�h�ݒ�
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				// ���|�[�g�C���X�^���X�ݒ�
				this._prtRpt   = rpt;
				this._viewRpt  = rpt;

				// �v���r���[��ʋN��
				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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
		/// �v���r���[�\������(�w�i�������v���r���[)
		/// </summary>
		/// <param name="prtRpt">�Ώ�ActiveReport�N���X(����p)</param>
		/// <param name="viewRpt">�Ώ�ActiveReport�N���X(�v���r���[�p)</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ���|�[�g�𐶐����Ȃ���A�������ꂽ�y�[�W���珇���v���r���[���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataDynamics.ActiveReports.ActiveReport3 viewRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;
			try
			{
				// �w�i���������[�h
				this._watermarkMode  = (int)emWaterMarkMode.WaterMarkPreview;

				// �N�����[�h�ݒ�
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				this._viewRpt = viewRpt;
				this._prtRpt  = prtRpt;

				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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
		/// �v���r���[�\������(�������|�[�g�}�[�W)
		/// </summary>
		/// <param name="rptList">�Ώ�ActiveReport���X�g�N���X(����p)</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : �������|�[�g�𐶐����Ȃ���}�[�W���A�������ꂽ�y�[�W���珇���v���r���[���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(ArrayList rptList)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;
			try
			{
				// �w�i���������[�h
				this._watermarkMode  = (int)emWaterMarkMode.NormalPreview;

				// �N�����[�h�ݒ�
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				// ��{���|�[�g�̎擾
				this._viewRpt = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
				this._prtRpt  = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
				
				if (rptList.Count - 1 > 0)
				{
					this._rptList = new ArrayList();
					for (int i = 1; i <= rptList.Count - 1; i++)
					{
						if (rptList[i] is DataDynamics.ActiveReports.ActiveReport3)
						{
							this._rptList.Add(rptList[i]);
						}
					}
				} 
				else 
				{
					this._rptList = null;
				}


				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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
		/// <remarks>
		/// <br>Note       : �v���r���[��ʂ�\�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int ShowPreview(DataDynamics.ActiveReports.ActiveReport3 prtRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;

			// �N�����[�h�ݒ�
			this._screenLoadMode = (int)ScreenLoadMode.ViewOnlyMode; 
		
			this._prtRpt = prtRpt; 
			
			this.viewer1.Document = this._prtRpt.Document;
			this.viewer1.Show();

			// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			//				DialogResult dr = this.ShowDialog();
			DialogResult dr = this.ShowDialog(this._owner);
			// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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

			return status;
		}
		
		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		/// <param name="owner">�g�b�v���x���E�B���h�E</param>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ���|�[�g�𐶐����Ȃ���A�������ꂽ�y�[�W���珇���v���r���[���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.07.25</br>
		/// </remarks>
		public int Run(IWin32Window owner, DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			this._owner = owner;
			return this.Run(rpt);
		}

		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : ���|�[�g�𐶐����Ȃ���A�������ꂽ�y�[�W���珇���v���r���[���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.02.17</br>
		/// </remarks>
		public void Show(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			try
			{
				this.viewer1.Document = null;
				
				// �ʏ�v���r���[���[�h
				this._watermarkMode = (int)emWaterMarkMode.NormalPreview;

				// �N�����[�h�ݒ�
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode;

				// ���|�[�g�C���X�^���X�ݒ�
				this._prtRpt = rpt;
				this._viewRpt = rpt;

				// �v���r���[��ʋN��
				if (!this._isShowing)
				{
					this._isShowing = true;
					this.Show();
				}
				else
				{
					// �v���r���[�p�h�L�������g�쐬�X���b�h
					Thread prevThread =
						new Thread(new ThreadStart(ShowPreview));

					prevThread.IsBackground = true;
					prevThread.SetApartmentState(ApartmentState.STA);

					prevThread.Start();
				}
			}
			catch (Exception ex)
			{

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}




		#endregion
		
		// ===============================================================================
		// �����֐�
		// ===============================================================================
		#region private methods
		/// <summary>
		/// ����p���|�[�g�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void CreatePrintReport()
		{
			try
			{
				// �󎚈ʒu����
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._prtRpt, this._commonInfo, false);
				
				// �v�����^���ݒ�
				string message;
				if (this._commonLib.SetPrinterInfo(ref this._prtRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				this._prtRpt.Run();
		
#if !CHG20060417				
				// ------------------------------------------------------//
				// ���͒��[�n�p�̑Ή�                                    //
				// ����(PDF�E�v�����^)������[�h���Ƀv���r���[�̒i�K��   //
				// PDF���쐬���Ă����K�v������B                         //
				// �t���[����PDF��\������ׁB                           //                    
				// ------------------------------------------------------//
				// ������[�h = �������
				if (this._commonInfo.PrintMode == 3)
				{
					// PDF�o��
					this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
				}
#endif
			
			}
			catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message, -1);
			}
		}
		
		/// <summary>
		/// �v���r���[�\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �h�L�������g���v���r���[��ʂɊ��蓖�ă��|�[�g�쐬�������J�n���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void CreateReport()
		{
			try
			{
				string message;

				// �󎚈ʒu����
				if (this._watermarkMode == (int)emWaterMarkMode.WaterMarkPreview)
				{
					// �w�i�摜�L��
					this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref this._viewRpt, this._commonInfo, this._isBackGroundPicture);
				} 
				else 
				{
					this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref this._viewRpt, this._commonInfo, false);
				}
				
				// �v�����^���ݒ�
				if (this._commonLib.SetPrinterInfo(ref this._viewRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				this.viewer1.Document = this._viewRpt.Document;
				this.viewer1.Show();
				this._viewRpt.Run(true);

				// �}�[�W���|�[�g�͂��邩�H
				if (this._rptList != null)
				{
					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt 
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						// �󎚈ʒu����
						if (this._watermarkMode == (int)emWaterMarkMode.WaterMarkPreview)
						{
							// �w�i�摜�L��
							this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref wkRpt, this._commonInfo, this._isBackGroundPicture);
						} 
						else 
						{
							this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref wkRpt, this._commonInfo, false);
						}
						
						// �v�����^���ݒ�
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0) 
						{
							this.DialogResult      = DialogResult.Abort;
							return;
						}
						
						wkRpt.Run(true);

						this._viewRpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}
			
				// ------------------------------------------------------//
				// ���͒��[�n�p�̑Ή�                                    //
				// ����(PDF�E�v�����^)������[�h���Ƀv���r���[�̒i�K��   //
				// PDF���쐬���Ă����K�v������B                         //
				// �t���[����PDF��\������ׁB                           //                    
				// ------------------------------------------------------//
				
#if !CHG20060417
				// �ʏ�v���r���[���[�h�̏ꍇ
				if (this._watermarkMode == (int)emWaterMarkMode.NormalPreview)
				{
					// ������[�h = �������
					if (this._commonInfo.PrintMode == 3)
					{
						// PDF�o��
						this.pdfExport1.Export(this._viewRpt.Document, this._commonInfo.PdfFullPath);
					}
				}
#endif
#if CHG20060509
				if (this._screenLoadMode == (int)ScreenLoadMode.RunAndViewMode)
				{
					// ����p�h�L�������g�쐬
					if (this._watermarkMode != (int)emWaterMarkMode.NormalPreview)
					{
						this.CreatePrintReport();
					}
				}
#endif
			}
			catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message + "\n\r" + ex.StackTrace + ex.Source, -1);
			}
		}
		
		/// <summary>
		/// �v���r���[�\���f���Q�[�g�ďo����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �R���g���[���̊�ɂȂ�E�B���h�E �n���h�������L����X���b�h��ŁA
		///                : �v���r���[�\�������f���Q�[�g�����s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
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
		/// <remarks>
		/// <br>Note       : �v���r���[��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void InitialScreen()
		{
			// �g�嗦�̐ݒ�
			if (this._commonInfo.ExpansionRate != 0)
			{
				float fx = (float)this._commonInfo.ExpansionRate / 100.0F;
				this.viewer1.ReportViewer.Zoom = fx;
			}
			
//			// �u����v�A�C�R���ǉ�
//			this.viewer1.Toolbar.Images.Images.Add(
//				IconResourceManagement.ImageList16.Images[(int)Size16_Index.CLOSE]);

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
		
//			// �Z�p���[�^�쐬
//			DataDynamics.ActiveReports.Toolbar.Separator separator1 =
//				new DataDynamics.ActiveReports.Toolbar.Separator();
//			separator1.Id         = 5010;
//
//			this.viewer1.Toolbar.Tools.Add(separator1); 
//		
//
//			// �u����v�{�^���쐬
//			DataDynamics.ActiveReports.Toolbar.Button closeBtn =
//				new DataDynamics.ActiveReports.Toolbar.Button();
//			closeBtn.Caption     = " ����";
//			closeBtn.ToolTip     = "�v���r���[���I�����܂�";
//			closeBtn.ImageIndex  = 12;
//			closeBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
//			closeBtn.Id          = 5020;
//
//			this.viewer1.Toolbar.Tools.Add(closeBtn); 
//		
//			// �Z�p���[�^�쐬
//			DataDynamics.ActiveReports.Toolbar.Separator separator2 =
//				new DataDynamics.ActiveReports.Toolbar.Separator();
//			separator2.Id         = 5030;
//
//			this.viewer1.Toolbar.Tools.Add(separator2); 
		
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
		/// <br>Date        : 2005.11.17</br>
		/// </remarks>
		private void SFCMN00293UA_Load(object sender, System.EventArgs e)
		{
			// ��ʏ����ݒ�
			this.InitialScreen();
			
			// ��������C�x���g���C�x���g�n���h���Ɋ֘A�Â��܂�
			this._prtRpt.Document.Printer.EndPrint
				+= new System.Drawing.Printing.PrintEventHandler(onEndPrint);

			if (this._screenLoadMode == (int)ScreenLoadMode.RunAndViewMode)
			{
#if !CHG20060509		// ���̕����𓯊��ő��点��悤�ɕύX
				// ����p�h�L�������g�쐬�X���b�h
				if (this._watermarkMode != (int)emWaterMarkMode.NormalPreview)
				{
					Thread printThread =
						new Thread(new ThreadStart(CreatePrintReport));
			
					printThread.IsBackground   = true;
#if CLR2
					printThread.SetApartmentState(ApartmentState.STA);
#else
					printThread.ApartmentState = ApartmentState.STA;
#endif
					

					printThread.Start();
				}
#endif
				// �v���r���[�p�h�L�������g�쐬�X���b�h
				Thread prevThread =
					new Thread(new ThreadStart(ShowPreview));

				prevThread.IsBackground   = true;
#if CLR2
				prevThread.SetApartmentState(ApartmentState.STA);
#else
				prevThread.ApartmentState = ApartmentState.STA;
#endif

				prevThread.Start();
			}
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note        : �c�[���o�[���N���b�N�ہA��������C�x���g�ł��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.17</br>
        /// <br>Update Note: 2012/05/17 yangmj</br>
        /// <br>           : �w��y�[�W����̒ǉ�</br>
		/// </remarks>
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

								// >>>>> 2006.07.25 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
								// �e��ʂ��A�N�e�B�u��
								if (this.Owner != null)
								{
									this.Owner.Activate();
								}
								// <<<<< 2006.07.25 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

								// ����h�L�������g�č쐬
								this._prtRpt.Run();
							}
						}
						
#if CHG20060417
						// ������[�h = �������
						if (this._commonInfo.PrintMode == 3)
						{
							// PDF�o��
							this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
						}
#endif

						// ������s
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                        //this._prtRpt.Document.Print(this._isShowPrintDialog,false,false);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                        if ( this._commonLib.PrintDocument( this._isShowPrintDialog, _prtRpt, _commonInfo.PrinterName ) )
                        {
                            // �g���������������ꍇ��onEndPrint�̏������o���Ȃ��̂Œ��ڏI������
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

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
                //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�----->>>>>
                case CT_TOOLBUTTON_PAGE:	// ����y�[�W�w��
                {
                    SFCMN00293UE pageSet = new SFCMN00293UE();
                    DialogResult dialogRes = pageSet.Show(new Form(), this._viewRpt.Document.Pages.Count);
                    if (dialogRes == DialogResult.OK)
                    {
                        this._commonLib.setPageRange(pageSet.SelectPageList);

                        // ������s
                        if (this._commonLib.PrintDocument(this._isShowPrintDialog, _prtRpt, _commonInfo.PrinterName))
                    {
                            // �g���������������ꍇ��onEndPrint�̏������o���Ȃ��̂Œ��ڏI������
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    break;
			}
                //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�-----<<<<<
		}
		}

		/// <summary>
		/// �A�N�e�B�u���|�[�gARControl�\����Ԑ���
		/// </summary>
		/// <param name="rpt">�Y�����|�[�g</param>
		/// <param name="isVisibled">�\���E��\��</param>
		/// <param name="ctrlList">�ύX����R���g���[�����X�g</param>
		/// <remarks>
		/// <br>Note        : �A�N�e�B�u���|�[�gARControl�\����Ԃ𐧌䂵�܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		    : 2005.12.05</br>
		/// </remarks>
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
		/// <remarks>
		/// <br>Note		: ���[�U�[���e�L�X�g��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.26</br>
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
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.1.13</br>
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
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.1.13</br>
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
		
#if ADD20060407	
		/// <summary>
		/// �L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���L�[�������������ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.04.07</br>
		/// </remarks>
		private void ViewerZoom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			e.Handled = true;
		}
#endif
		
		/// <summary>
		/// ��������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ����������������ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.12.02</br>
		/// </remarks>
		private void onEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}		
		
		/// <summary>
		/// ��ʏI���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ��ʏI�����ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.12.02</br>
		/// </remarks>
		private void SFCMN00293UA_Closed(object sender, System.EventArgs e)
		{
			if (this._positionAdjViewLib != null)
			{
				this._positionAdjViewLib.Dispose();
			}

			if (this._positionAdjPrtLib != null)
			{
				this._positionAdjPrtLib.Dispose();
			}
		}
		#endregion


	}
}

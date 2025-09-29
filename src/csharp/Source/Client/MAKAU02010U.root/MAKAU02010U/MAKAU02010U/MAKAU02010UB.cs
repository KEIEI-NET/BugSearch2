#define REP20060427
//#define USING_PDF_VIEWER    // PDF�\�������̕ύX�p ��WebBrowser�R���g���[���𒼐ڎg�p��������ƕς��Ȃ��̂ŁA����`
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
// --- ADD m.suzuki 2010/10/29 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/10/29 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �������[�v���r���[�t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������[�̃v���r���[�t�H�[����\������N���X�ł��B</br>
	/// <br>Programer  : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.11</br>
	/// <br>Update Date: xxxx.xx.xx</br>
	/// <br>Update Note: 2006.04.17 Y.Sasaki</br>
	/// <br>           : �P.�o�c�e����ۑ��@�\�ǉ��ɔ����C��</br>
	/// <br>Update Note: 2006.04.27 Y.Sasaki</br>
	/// <br>           : �P.WebBrowse�R���|�[�l���g�Ή�</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/10/29  22018 ��� ���b</br>
    /// <br>           : PDF�o�͂������PG�I������ƃG���[�������錏�̑Ή��B(AdobeReader9�ȍ~)</br>
    /// </remarks>
	public class MAKAU02010UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/10/29 ---------->>>>>
        [DllImport( "ole32.dll" )] extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/10/29 ----------<<<<<

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

        // --- DEL m.suzuki 2010/10/29 ---------->>>>>
        //// ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
        //// ��WebBrowser�R���g���[���𒼐ڎg�p��������ƕς��Ȃ��̂ŁA����i�������Ă��邾���j
        //#region <PDF�\�������̕ʃp�^�[��/>

        ///// <summary>PDF�r���[��</summary>
        //private DCCMN04000UB _pdfViewer;
        ///// <summary>
        ///// PDF�r���[���̃A�N�Z�T
        ///// </summary>
        //private DCCMN04000UB PDFViewer
        //{
        //    get { return _pdfViewer; }
        //    set { _pdfViewer = value; }
        //}

        //#endregion  // <PDF�\�������̕ʃp�^�[��/>
        //// ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<
        // --- DEL m.suzuki 2010/10/29 ----------<<<<<

		public MAKAU02010UB()
		{
			InitializeComponent();

            // --- DEL m.suzuki 2010/10/29 ---------->>>>>
            //// ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
            //// ��WebBrowser�R���g���[���𒼐ڎg�p��������ƕς��Ȃ��̂ŁA����i�������Ă��邾���j
            //// PDF�\�������̕ύX�p
            //PDFViewer = new DCCMN04000UB();
            //this.Controls.Add(PDFViewer);
            //this.PDFViewer.Dock = DockStyle.Fill;
            //// ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<
            // --- DEL m.suzuki 2010/10/29 ----------<<<<<
		}

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MAKAU02010UB ) );
            this.PreviewBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PreviewBrowser
            // 
            this.PreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBrowser.Location = new System.Drawing.Point( 0, 0 );
            this.PreviewBrowser.MinimumSize = new System.Drawing.Size( 20, 20 );
            this.PreviewBrowser.Name = "PreviewBrowser";
            this.PreviewBrowser.Size = new System.Drawing.Size( 1000, 658 );
            this.PreviewBrowser.TabIndex = 0;
            this.PreviewBrowser.Visible = false;
            this.PreviewBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler( this.PreviewBrowser_PreviewKeyDown );
            // 
            // MAKAU02010UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "MAKAU02010UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.MAKAU02010UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		// ===================================================================================== //
		// �����ϐ�
		// ===================================================================================== //
		#region Private member
		private bool _isSave       �@   = false;
		private string _printKey        = "";			// ���[KEY
		private string _printName       = "";			// ���[��
		private string _printDetailName = "";
		private WebBrowser PreviewBrowser;			    // ���[�ڍז�
		private string _printPDFPath    = "";			// ���[�p�X
		#endregion
		
		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region Public Property 
		/// <summary>����ۑ��\�v���p�e�B</summary>
		public bool IsSave
		{
			get {return _isSave;}
			set {_isSave = value;}
		}
		
		/// <summary>���[KEY�v���p�e�B</summary>
		public string PrintKey
		{
			get {return _printKey;}
			set {_printKey = value;}
		}
		
		/// <summary>���[���v���p�e�B</summary>
		public string PrintName
		{
			get {return _printName;}
			set {_printName = value;}
		}
		
		/// <summary>���[���v���p�e�B</summary>
		public string PrintDetailName
		{
			get {return _printDetailName;}
			set {_printDetailName = value;}
		}
		
		/// <summary>PDF�p�X�v���p�e�B</summary>
		public string PrintPDFPath
		{
			get {return _printPDFPath;}
			set {_printPDFPath = value;}
		}
		#endregion
		
		// ===================================================================================== //
		// Internal ���\�b�h
		// ===================================================================================== //
		#region Internal Methods
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�^�C�g��</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.09</br>
		/// </remarks>
		internal void Show(object parameter)
		{
            
			this.Text = parameter.ToString();
			this.Show();
		}

#if REP20060427 
		/// <summary>
		/// �v���r���[�t�H�[���\������
		/// </summary>
		/// <param name="paramater">URL</param>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽURL����ʂɕ\�����܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.27</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
            // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
            // ��WebBrowser�R���g���[���𒼐ڎg�p��������ƕς��Ȃ��̂ŁA����i�������Ă��邾���j
        #if USING_PDF_VIEWER
            // --- DEL m.suzuki 2010/10/29 ---------->>>>>
            // PDF�\�������̕ύX�p
            PDFViewer.PDFShow(paramater.ToString());
            // --- DEL m.suzuki 2010/10/29 ----------<<<<<
        #else
            this.PreviewBrowser.Visible = true;
        #endif
            // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

			try
			{
				if (String.IsNullOrEmpty(paramater.ToString())) return;

				if (paramater.Equals("about:blank"))
				{
					this.PreviewBrowser.Navigate(new Uri("about:blank"));
				}
				else
				{
					this.PreviewBrowser.Navigate(new Uri("about:blank"));
					this.PreviewBrowser.Navigate(new Uri(paramater.ToString()));
				}
			}
			catch (System.UriFormatException)
			{
				return;
			}
		}
#else
		/// <summary>
		/// �v���r���[�t�H�[���\������
		/// </summary>
		/// <param name="parameter">URL</param>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽURL����ʂɕ\�����܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.09</br>
		/// </remarks>
		internal void ShowPDFPreview(object parameter)
		{
			try
			{
				// ���ݕ\�����e���N���A
				object obj = null;
				PreviewBrowser.Navigate("about:blank", ref obj, ref obj, ref obj, ref obj);

				if (parameter != null && parameter.ToString() != "")
				{
					// �������`���܂��B
					object obj1 = 8;
					object obj2 = "_self";
					// �u���E�U�ŕ\�����s���܂��B
				
					PreviewBrowser.Navigate2(ref parameter, ref obj1, ref obj2, ref obj, ref obj);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"�G���[");
			}
		}
#endif
		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":" + e.KeyCode.ToString());
        }

        // --- ADD m.suzuki 2010/10/29 ---------->>>>>
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKAU02010UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                // �u���E�U��������
                PreviewBrowser.Navigate( "about:blank" );
                // �u���E�U�R���g���[���𖾊m�ɔj������
                PreviewBrowser.Dispose();
                // �j���ׂ̈̎��Ԃ��V�X�e���ɗ^����
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                // �g�pDLL�����S���
                CoFreeUnusedLibraries();
            }
        }
        // --- ADD m.suzuki 2010/10/29 ----------<<<<<
	}
}

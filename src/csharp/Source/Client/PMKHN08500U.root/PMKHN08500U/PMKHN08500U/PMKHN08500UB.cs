#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �}�X�^�G�N�X�|�[�g�E�C���|�[�g�v���r���[�t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �}�X�^�G�N�X�|�[�g�E�C���|�[�g�̃v���r���[�t�H�[����\������N���X�ł��B</br>
	/// <br>Programer  : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
	public class PMKHN08500UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PMKHN08500UB()
		{
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMKHN08500UB ) );
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
            // 
            // PMKHN08500UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMKHN08500UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMKHN08500UB_FormClosed );
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
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
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
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

        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN08500UB_FormClosed( object sender, FormClosedEventArgs e )
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
                //  �g�pDLL�����S���
                CoFreeUnusedLibraries();
            }
        }
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
#else
		/// <summary>
		/// �v���r���[�t�H�[���\������
		/// </summary>
		/// <param name="parameter">URL</param>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽURL����ʂɕ\�����܂��B</br>
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
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
	}
}

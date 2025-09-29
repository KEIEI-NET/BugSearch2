//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������[�v���r���[�t�h�N���X
// �v���O�����T�v   : �������[�v���r���[�t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/01    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �������[�v���r���[�t�h�N���X
	/// </summary>
    /// <remarks>
    /// <br>Note        : �������[�v���r���[�t�h�N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
	public class MAKAU03000UB : System.Windows.Forms.Form
	{
        [DllImport( "ole32.dll" )] extern static void CoFreeUnusedLibraries();

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;        

		public MAKAU03000UB()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MAKAU03000UB ) );
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
            // MAKAU03000UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 7, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1000, 658 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "MAKAU03000UB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.MAKAU03000UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		// ===================================================================================== //
		// �����ϐ�
		// ===================================================================================== //
		#region Private member
		private bool _isSave       �@   = false;
		private string _printKey        = string.Empty;			// ���[KEY
		private string _printName       = string.Empty;			// ���[��
		private string _printDetailName = string.Empty;
		private WebBrowser PreviewBrowser;			    // ���[�ڍז�
        private string _printPDFPath = string.Empty;			// ���[�p�X
        private const string BLANK = "about:blank";
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
        /// <br>Note        : </br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		internal void Show(object parameter)
		{
            
			this.Text = parameter.ToString();
			this.Show();
		}

		/// <summary>
		/// �v���r���[�t�H�[���\������
		/// </summary>
		/// <param name="paramater">URL</param>
		/// <remarks>
        /// <br>Note        : �����œn���ꂽURL����ʂɕ\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		internal void Navigate(object paramater)
		{
            // ��WebBrowser�R���g���[���𒼐ڎg�p��������ƕς��Ȃ��̂ŁA����i�������Ă��邾���j
            this.PreviewBrowser.Visible = true;

			try
			{
				if (String.IsNullOrEmpty(paramater.ToString())) return;

                if (paramater.Equals(BLANK))
				{
                    this.PreviewBrowser.Navigate(new Uri(BLANK));
				}
				else
				{
                    this.PreviewBrowser.Navigate(new Uri(BLANK));
					this.PreviewBrowser.Navigate(new Uri(paramater.ToString()));
				}
			}
			catch (System.UriFormatException)
			{
				return;
			}
		}
		#endregion

        /// <summary>
        /// PreviewBrowser_PreviewKeyDown
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void PreviewBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":" + e.KeyCode.ToString());
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���N���[�Y����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                // �u���E�U��������
                PreviewBrowser.Navigate(BLANK);
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
	}
}

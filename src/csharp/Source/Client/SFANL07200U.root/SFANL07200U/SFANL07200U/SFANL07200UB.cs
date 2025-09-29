#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[���ʃr���[�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���ʂ̃r���[�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2005.01.19</br>
    /// <br>Update Note: 2006.04.27 Y.Sasaki</br>
    /// <br>           : �P.WebBrowse�R���|�[�l���g�Ή�</br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
    public class SFANL07200UB : System.Windows.Forms.Form
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<


    # region Private Members (Component)

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
    #endregion

    // ===================================================================================== //
    // �R���X�g���N�^
    // ===================================================================================== //
    # region Constructor
    public SFANL07200UB()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}
    #endregion

    // ===================================================================================== //
    // �j��
    // ===================================================================================== //
    #region Dispose
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
            this.PreviewBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PreviewBrowser
            // 
            this.PreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBrowser.Location = new System.Drawing.Point( 0, 0 );
            this.PreviewBrowser.MinimumSize = new System.Drawing.Size( 20, 20 );
            this.PreviewBrowser.Name = "PreviewBrowser";
            this.PreviewBrowser.Size = new System.Drawing.Size( 1016, 734 );
            this.PreviewBrowser.TabIndex = 0;
            // 
            // SFANL07200UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 8, 15 );
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this.PreviewBrowser );
            this.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SFANL07200UB";
            this.Text = "SFANL07200UB";
            this.Activated += new System.EventHandler( this.SFANL07200UB_Activated );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.SFANL07200UB_FormClosed );
            this.ResumeLayout( false );

		}
		#endregion
	
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member
		private bool _isSave       �@   = false;
		private string _printKey        = "";			// ���[KEY
		private string _printName       = "";			// ���[��
		private string _printDetailName = "";
		private WebBrowser PreviewBrowser;			// ���[�ڍז�
		private string _printPDFPath    = "";			// ���[�p�X
		private string _formControlInfoKey = "";
		#endregion
		
		//================================================================================
		//  �v���p�e�B
		//================================================================================
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
			get { return _printPDFPath; }
			set { _printPDFPath = value; }
		}

		/// <summary>���[���ʗp�t�H�[���R���g���[���p�L�[�v���p�e�B</summary>
		public string FormControlInfoKey
		{
			get { return _formControlInfoKey; }
			set { _formControlInfoKey = value; }
		}
		#endregion
		
		// ===================================================================================== //
    // �������\�b�h
    // ===================================================================================== //
    #region private methods
    /// <summary>
    /// �G���[���b�Z�[�W�\��
    /// </summary>
    /// <param name="iLevel">�G���[���x��</param>
    /// <param name="iMsg">�G���[���b�Z�[�W</param>
    /// <param name="iSt">�G���[�X�e�[�^�X</param>
    /// <param name="iButton">�\���{�^��</param>
    /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
    /// <returns>DialogResult</returns>
    /// <remarks>
    /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.01.19</br>
    /// </remarks>
    private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
    {
      return TMsgDisp.Show(iLevel, "SFUKK06180U", iMsg, iSt, iButton, iDefButton);
    }
    #endregion
  
    // ===================================================================================== //
    // Internal�C�x���g
    // ===================================================================================== //
    #region internal event
    /// <summary>
    /// �c�[���o�[�\������C�x���g
    /// </summary>
    internal event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;        
    #endregion

    // ===================================================================================== //
    // Internal���\�b�h
    // ===================================================================================== //
    #region internal methods
    
#if REP20060427
		/// <summary>
		/// �v���r���[�t�H�[���\������
		/// </summary>
		/// <param name="parameter">URL</param>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽURL����ʂɕ\�����܂��B</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.27</br>
		/// </remarks>
		public void ShowPDFPreview(object paramater)
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
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
    /// <br>Date       : 2006.01.19</br>
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
        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
          ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
      }
    }
#endif
    #endregion

    // ===================================================================================== //
    // �R���g���[���C�x���g
    // ===================================================================================== //
    #region control event        
    /// <summary>
    /// Control.Activated�C�x���g
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�f�[�^</param>
    /// <remarks>
    /// <br>Note        : �t�H�[�����A�N�e�B�u�ɂ��ꂽ���ɔ������܂��B</br>
    /// <br>Programmer  : 18012 Y.Sasaki</br>
    /// <br>Date        : 2006.01.19</br>
    /// </remarks>
		private void SFANL07200UB_Activated(object sender, System.EventArgs e)
		{
			ParentToolbarSettingEvent(this);
		}
    #endregion


        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL07200UB_FormClosed( object sender, FormClosedEventArgs e )
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


  }
}

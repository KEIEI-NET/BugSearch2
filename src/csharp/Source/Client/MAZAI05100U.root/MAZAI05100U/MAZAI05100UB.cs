using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I���\PDF�\�����
	/// </summary>
	/// <remarks>
	/// <br>Note		: </br>
	/// <br>Programmer	: 23010 �����@�m</br>
	/// <br>Date		: 2007.04.02</br>
	/// <br></br>
	/// </remarks>
	public partial class MAZAI05100UB : Form
	{
		#region �R���X�g���N�^
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAZAI05100UB()
		{
			InitializeComponent();
		}
		#endregion
			
		/// <summary>
		/// PDF�\���J�n
		/// </summary>
		/// <param name="pdfTempPath">PDF�t�@�C���p�X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2007.04.03</br>
		/// <br>Update Note	: </br>
		/// </remarks>
		public int ShowPDFPreview(string pdfTempPath)
		{
			int st = -1;

			try
			{
				if (String.IsNullOrEmpty( pdfTempPath ) == false) 
				{
					if (pdfTempPath.Equals("about:blank"))
					{
						this.webBrowser1.Navigate(new Uri( "about:blank" ));		// ���ݕ\�����e���N���A
					}
					else
					{
						this.webBrowser1.Navigate(new Uri( "about:blank" ));		// ���ݕ\�����e���N���A
						this.webBrowser1.Navigate(new Uri( pdfTempPath ));			// �u���E�U�ŕ\�����s���܂��B
						st = 0;
					}
					st = 0;
				}
			}
			catch (UriFormatException)
			{
			}
			catch (Exception ex)
			{
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
					"�v���r���[�\���Ɏ��s���܂����B\r\n" + ex.Message, 
					-1, MessageBoxButtons.OK );
			}
			
			return st;
		}
		
	}
}
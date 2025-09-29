using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���ʏ�������ʎ��̃N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		:</br>
	/// <br>Programmer	: 18023 ����@����</br>
	/// <br>Date		: 2006.07.28</br>
	/// <br></br>
	/// </remarks>
	//internal partial class CommonProcessingFormEntity : Form
	public partial class CommonProcessingFormEntity : Form
	{
        private Rectangle RectScreen;   

        #region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public CommonProcessingFormEntity()
		{
			InitializeComponent();

        
        }
		#endregion

		#region Control Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CommonProcessingFormEntity_Load(object sender, EventArgs e)
		{
			if (this.cancel_ultraButton.Visible)
				this.Height = 140;
			else
				this.Height = 140 - this.cancel_ultraButton.Height;

            RectScreen = Screen.PrimaryScreen.Bounds;

            Point xy = new Point();
            xy.X = (RectScreen.Width / 2) - 173;
            xy.Y = (RectScreen.Height / 2) - 57;
            this.Location = xy;

            this.Refresh();

            //this.Location.X = (RectScreen.Width / 2) - 173;
            //this.Location.Y = (RectScreen.Height / 2) - 57;

		}
		#endregion
    }

}
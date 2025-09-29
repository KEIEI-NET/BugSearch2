using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// �\�����ރV�X�e���p�A�C�R�����\�[�X�Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �\�����ރV�X�e���p�A�C�R�����\�[�X�̊Ǘ����s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// <br>Update Note : </br>
	/// <br>2006.12.13 men �]�v�ȃC���X�^���X���������Ȃ��č�����</br>
	/// </remarks>
	public class ApplyDocIconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)

		private System.Windows.Forms.ImageList ApplyDoc1_ImageList_16;
		private System.Windows.Forms.ImageList ApplyDoc2_ImageList_16;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �\�����ރV�X�e���p�A�C�R�����\�[�X�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �A�C�R�����\�[�X�Ǘ��N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public ApplyDocIconResourceManagement()
		{
			InitializeComponent();
		}
		# endregion

		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		# endregion

		#region �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e�� 
		/// �R�[�h�n�G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyDocIconResourceManagement));
			this.ApplyDoc1_ImageList_16 = new System.Windows.Forms.ImageList(this.components);
			this.ApplyDoc2_ImageList_16 = new System.Windows.Forms.ImageList(this.components);
			// 
			// ApplyDoc1_ImageList_16
			// 
			this.ApplyDoc1_ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ApplyDoc1_ImageList_16.ImageStream")));
			this.ApplyDoc1_ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(0, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(1, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(2, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(3, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(4, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(5, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(6, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(7, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(8, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(9, "");
			// 
			// ApplyDoc2_ImageList_16
			// 
			this.ApplyDoc2_ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ApplyDoc2_ImageList_16.ImageStream")));
			this.ApplyDoc2_ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(0, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(1, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(2, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(3, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(4, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(5, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(6, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(7, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(8, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(9, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(10, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(11, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(12, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(13, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(14, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(15, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(16, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(17, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(18, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(19, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(20, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(21, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(22, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(23, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(24, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(25, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(26, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(27, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(28, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(29, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(30, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(31, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(32, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(33, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(34, "");

		}
		#endregion

		private static ApplyDocIconResourceManagement _icon = null;									// 2006.12.13 men DEL

		# region Properties
		/// <summary>�\�����ޗp16�~16�A�C�R���i�[ImageList�v���p�e�B�@</summary>
		/// <value>�\�����ޗp16�~16�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList ApplyDoc1_ImageList16
		{
			get
			{
				//ApplyDocIconResourceManagement icon = new ApplyDocIconResourceManagement();		// 2006.12.13 men DEL
				//return icon.ApplyDoc1_ImageList_16;												// 2006.12.13 men DEL
				if (_icon == null) _icon = new ApplyDocIconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ApplyDoc1_ImageList_16;												// 2006.12.13 men ADD
			}
		}

		/// <summary>�\�����ޗp16�~16�A�C�R���i�[ImageList�v���p�e�B�A</summary>
		/// <value>�\�����ޗp16�~16�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList ApplyDoc2_ImageList16
		{
			get
			{
				//ApplyDocIconResourceManagement icon = new ApplyDocIconResourceManagement();		// 2006.12.13 men DEL
				//return icon.ApplyDoc2_ImageList_16;												// 2006.12.13 men DEL
				if (_icon == null) _icon = new ApplyDocIconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ApplyDoc2_ImageList_16;												// 2006.12.13 men ADD
			}
		}
		# endregion
	}
}

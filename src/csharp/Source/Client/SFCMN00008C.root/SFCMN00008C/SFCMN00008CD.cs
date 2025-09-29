using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// �����A�C�R�����\�[�X�Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����A�C�R�����\�[�X�̊Ǘ����s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.05.19</br>
	/// <br></br>
	/// </remarks>
	public class EquipmentIconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)
		private System.Windows.Forms.ImageList Equipment_ImageList_24;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �����A�C�R�����\�[�X�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����A�C�R�����\�[�X�Ǘ��N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public EquipmentIconResourceManagement(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// �����A�C�R�����\�[�X�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����A�C�R�����\�[�X�Ǘ��N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public EquipmentIconResourceManagement()
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EquipmentIconResourceManagement));
			this.Equipment_ImageList_24 = new System.Windows.Forms.ImageList(this.components);
			// 
			// Equipment_ImageList_24
			// 
			this.Equipment_ImageList_24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.Equipment_ImageList_24.ImageSize = new System.Drawing.Size(24, 24);
			this.Equipment_ImageList_24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Equipment_ImageList_24.ImageStream")));
			this.Equipment_ImageList_24.TransparentColor = System.Drawing.Color.Cyan;

		}
		#endregion

		private static EquipmentIconResourceManagement icon = null;

		# region Properties
		/// <summary>�����p24�~24�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>�����p24�~24�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList Equipment_ImageList16
		{
			get
			{
				if (icon == null) icon = new EquipmentIconResourceManagement();
				//EquipmentIconResourceManagement icon = new EquipmentIconResourceManagement();
				return icon.Equipment_ImageList_24;
			}
		}
		# endregion
	}
}

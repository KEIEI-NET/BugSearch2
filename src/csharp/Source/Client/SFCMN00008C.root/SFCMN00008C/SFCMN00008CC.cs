using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// ���j���[�p�A�C�R�����\�[�X�Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���j���[�p�A�C�R�����\�[�X�̊Ǘ����s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.05.19</br>
	/// <br></br>
	/// </remarks>
	public class MenuIconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)
		private System.Windows.Forms.ImageList Menu_ImageList_16;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// ���j���[�p�A�C�R�����\�[�X�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���j���[�p�A�C�R�����\�[�X�Ǘ��N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public MenuIconResourceManagement()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuIconResourceManagement));
			this.Menu_ImageList_16 = new System.Windows.Forms.ImageList(this.components);
			// 
			// Menu_ImageList_16
			// 
			this.Menu_ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Menu_ImageList_16.ImageStream")));
			this.Menu_ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
			this.Menu_ImageList_16.Images.SetKeyName(0, "");
			this.Menu_ImageList_16.Images.SetKeyName(1, "");
			this.Menu_ImageList_16.Images.SetKeyName(2, "");
			this.Menu_ImageList_16.Images.SetKeyName(3, "");
			this.Menu_ImageList_16.Images.SetKeyName(4, "");
			this.Menu_ImageList_16.Images.SetKeyName(5, "");
			this.Menu_ImageList_16.Images.SetKeyName(6, "");
			this.Menu_ImageList_16.Images.SetKeyName(7, "");
			this.Menu_ImageList_16.Images.SetKeyName(8, "");
			this.Menu_ImageList_16.Images.SetKeyName(9, "");
			this.Menu_ImageList_16.Images.SetKeyName(10, "");
			this.Menu_ImageList_16.Images.SetKeyName(11, "");
			this.Menu_ImageList_16.Images.SetKeyName(12, "");
			this.Menu_ImageList_16.Images.SetKeyName(13, "");
			this.Menu_ImageList_16.Images.SetKeyName(14, "");
			this.Menu_ImageList_16.Images.SetKeyName(15, "");
			this.Menu_ImageList_16.Images.SetKeyName(16, "");
			this.Menu_ImageList_16.Images.SetKeyName(17, "");
			this.Menu_ImageList_16.Images.SetKeyName(18, "");
			this.Menu_ImageList_16.Images.SetKeyName(19, "");
			this.Menu_ImageList_16.Images.SetKeyName(20, "");
			this.Menu_ImageList_16.Images.SetKeyName(21, "");
			this.Menu_ImageList_16.Images.SetKeyName(22, "");
			this.Menu_ImageList_16.Images.SetKeyName(23, "");
			this.Menu_ImageList_16.Images.SetKeyName(24, "");
			this.Menu_ImageList_16.Images.SetKeyName(25, "");
			this.Menu_ImageList_16.Images.SetKeyName(26, "");
			this.Menu_ImageList_16.Images.SetKeyName(27, "");
			this.Menu_ImageList_16.Images.SetKeyName(28, "");
			this.Menu_ImageList_16.Images.SetKeyName(29, "");
			this.Menu_ImageList_16.Images.SetKeyName(30, "");
			this.Menu_ImageList_16.Images.SetKeyName(31, "");
			this.Menu_ImageList_16.Images.SetKeyName(32, "");
			this.Menu_ImageList_16.Images.SetKeyName(33, "");
			this.Menu_ImageList_16.Images.SetKeyName(34, "");
			this.Menu_ImageList_16.Images.SetKeyName(35, "");
			this.Menu_ImageList_16.Images.SetKeyName(36, "");
			this.Menu_ImageList_16.Images.SetKeyName(37, "");
			this.Menu_ImageList_16.Images.SetKeyName(38, "");
			this.Menu_ImageList_16.Images.SetKeyName(39, "");
			this.Menu_ImageList_16.Images.SetKeyName(40, "");
			this.Menu_ImageList_16.Images.SetKeyName(41, "");
			this.Menu_ImageList_16.Images.SetKeyName(42, "");
			this.Menu_ImageList_16.Images.SetKeyName(43, "");
			this.Menu_ImageList_16.Images.SetKeyName(44, "");
			this.Menu_ImageList_16.Images.SetKeyName(45, "");
			this.Menu_ImageList_16.Images.SetKeyName(46, "");
			this.Menu_ImageList_16.Images.SetKeyName(47, "");
			this.Menu_ImageList_16.Images.SetKeyName(48, "");
			this.Menu_ImageList_16.Images.SetKeyName(49, "");
			this.Menu_ImageList_16.Images.SetKeyName(50, "");
			this.Menu_ImageList_16.Images.SetKeyName(51, "");
			this.Menu_ImageList_16.Images.SetKeyName(52, "");
			this.Menu_ImageList_16.Images.SetKeyName(53, "");
			this.Menu_ImageList_16.Images.SetKeyName(54, "");
			this.Menu_ImageList_16.Images.SetKeyName(55, "");
			this.Menu_ImageList_16.Images.SetKeyName(56, "");
			this.Menu_ImageList_16.Images.SetKeyName(57, "");
			this.Menu_ImageList_16.Images.SetKeyName(58, "");
			this.Menu_ImageList_16.Images.SetKeyName(59, "");
			this.Menu_ImageList_16.Images.SetKeyName(60, "");
			this.Menu_ImageList_16.Images.SetKeyName(61, "");

		}
		#endregion

		# region Properties
		/// <summary>���j���[�p16�~16�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>���j���[�p16�~16�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList Menu_ImageList16
		{
			get
			{
				MenuIconResourceManagement icon = new MenuIconResourceManagement();
				return icon.Menu_ImageList_16;
			}
		}
		# endregion
	}

	# region enum MenuIconSize16_Index
	/// <summary>���j���[�p16�~16�T�C�Y�A�C�R���̃C���f�b�N�X�̗񋓌^�ł��B</summary>
	public enum MenuIconSize16_Index : int
	{
		/// <summary>���O�C��</summary>
		LOGIN = 0,

		/// <summary>���O�I�t</summary>
		LOGOFF = 1,

		/// <summary>�I��</summary>
		END = 2,

		/// <summary>�u���E�U�߂�</summary>
		BEFORE = 3,

		/// <summary>�u���E�U�i��</summary>
		NEXT = 4,

		/// <summary>�u���E�U���~</summary>
		STOP = 5,

		/// <summary>�u���E�UHOME</summary>
		HOME = 6,

		/// <summary>�u���E�U�X�V</summary>
		UPDATE = 7,

		/// <summary>�u���E�U���C�����j���[</summary>
		MAINMENU = 8,

		/// <summary>���j���[����</summary>
		SEARCH = 9,

		/// <summary>���j���[���]�Œ�</summary>
		TURN = 10,

		/// <summary>�P��^�u�폜</summary>
		TABDELETE1 = 11,

		/// <summary>�����^�u�폜</summary>
		TABDELETE2 = 12,

		/// <summary>USB�v���e�N�^</summary>
		USBPROTECTOR = 13,

		/// <summary>USB������</summary>
		USBMEMORY = 14,

		/// <summary>�o�[�W����</summary>
		VERSION = 15,

		/// <summary>FD����</summary>
		FD = 16,

		/// <summary>�����\��</summary>
		INITIALINDICATION = 17,

		/// <summary>���O�C���S����</summary>
		LOGINEMPLOYEE = 18,

		/// <summary>���O�C�����</summary>
		LOGININFO = 19,

		/// <summary>�w���v</summary>
		HELP = 20,

		/// <summary>����</summary>
		DAILY = 21,

		/// <summary>����</summary>
		MONTHLY = 22,

		/// <summary>�N��</summary>
		YEARLY = 23,

		/// <summary>����</summary>
		TIMELY = 24,

		/// <summary>�J�X�^�����j���[</summary>
		CUSTOMMENU = 25,

		/// <summary>�񋟃f�[�^</summary>
		OFFERDATA = 26,

		/// <summary>�V�X�e���Ǘ�</summary>
		SYSTEMCONTROL = 27,

		/// <summary>���q�l���</summary>
		CUSTOMERINFO = 28,

		/// <summary>�\��Ɩ�</summary>
		RESERVATION = 29,

		/// <summary>�����Ɩ�</summary>
		REPAIR = 30,

		/// <summary>����Ɩ�</summary>
		BODYREPAIR = 31,

		/// <summary>�ԗ��̔��Ɩ�</summary>
		CARSALES = 32,

		/// <summary>�ԗ�����Ɩ�</summary>
		CARASSESSMENT = 33,

		/// <summary>�\������</summary>
		APPLYDOC = 34,

		/// <summary>�����E�d���Ɩ�</summary>
		ORDER = 35,

		/// <summary>�����Ɩ�</summary>
		DEPOSIT = 36,
	
		/// <summary>�x���E�o���Ɩ�</summary>
		PAYMENT = 37,
	
		/// <summary>�݌ɊǗ��Ɩ�</summary>
		STOCK = 38,
	
		/// <summary>���ъǗ��Ɩ�</summary>
		RESULTS = 39,

		/// <summary>���͋Ɩ�</summary>
		ANALYSIS = 40,

		/// <summary>�}�X�^�����e</summary>
		MASTERMAINTENANCE = 41,

		/// <summary>�����Ɩ�</summary>
		DEMAND = 42,

		/// <summary>���ɊǗ��Ɩ�</summary>
		CARENTER = 43,

		/// <summary>�����Ǘ��Ɩ�</summary>
		HISTORY = 44,

		/// <summary>���ɑ��i�Ɩ�</summary>
		ENTERQUICKEN = 45,

		/// <summary>���^�f�[�^</summary>
		RECORDINGDATA = 46,

		/// <summary>���ǂ̂��m�点</summary>
		UNREADNEWS = 47,

		/// <summary>���ǂ̂��m�点</summary>
		READNEWS = 48,

		/// <summary>���q�l�_����</summary>
		CUSTOMERCONTACT = 49,

		/// <summary>���Ӑ楎ԗ�</summary>
		CUSTOMERCAR = 50,

		/// <summary>�T�[�r�X</summary>
		SERVICE = 51,

		/// <summary>�o��</summary>
		ACCOUNTING = 52,

		/// <summary>���[</summary>
		SLIT = 53,

		/// <summary>�Ԍ�</summary>
		CARINSPECTION = 54,

		/// <summary>�c�l���s</summary>
		DMISSUE = 55,

		/// <summary>�ԗ��̔�</summary>
		VEHICLESALES = 56,

		/// <summary>�������[</summary>
		DAYSSLIT = 57,

		/// <summary>�����E�N�����[</summary>
		MONTHYEARSLIT = 58,

		/// <summary>�H���Ǘ�</summary>
		PROCESSMANAGEMENT = 59,

		/// <summary>�������[</summary>
		SLITATANYTIME = 60,

		/// <summary>�N�����[</summary>
		YEARSLIT = 61
	}
	# endregion
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// �A�C�R�����\�[�X�Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �A�C�R�����\�[�X�̊Ǘ����s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// <br>Update Note : </br>
	/// <br>2006.04.18 men Visual Studio 2005 �Ή�</br>
	/// <br>2006.11.29 men 192.SENDIMAGE_�摜�`����ǉ�</br>
	/// <br>2006.12.13 men �]�v�ȃC���X�^���X���������Ȃ��č�����</br>
	/// </remarks>
	public class IconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)
		private System.Windows.Forms.ImageList ImageList_16;
		private System.Windows.Forms.ImageList ImageList_24;
		private ImageList ImageList_32;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �A�C�R�����\�[�X�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �A�C�R�����\�[�X�Ǘ��N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public IconResourceManagement()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconResourceManagement));
            this.ImageList_16 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList_24 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList_32 = new System.Windows.Forms.ImageList(this.components);
            // 
            // ImageList_16
            // 
            this.ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_16.ImageStream")));
            this.ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
            this.ImageList_16.Images.SetKeyName(0, "");
            this.ImageList_16.Images.SetKeyName(1, "");
            this.ImageList_16.Images.SetKeyName(2, "");
            this.ImageList_16.Images.SetKeyName(3, "");
            this.ImageList_16.Images.SetKeyName(4, "");
            this.ImageList_16.Images.SetKeyName(5, "");
            this.ImageList_16.Images.SetKeyName(6, "");
            this.ImageList_16.Images.SetKeyName(7, "");
            this.ImageList_16.Images.SetKeyName(8, "");
            this.ImageList_16.Images.SetKeyName(9, "");
            this.ImageList_16.Images.SetKeyName(10, "");
            this.ImageList_16.Images.SetKeyName(11, "");
            this.ImageList_16.Images.SetKeyName(12, "");
            this.ImageList_16.Images.SetKeyName(13, "");
            this.ImageList_16.Images.SetKeyName(14, "");
            this.ImageList_16.Images.SetKeyName(15, "");
            this.ImageList_16.Images.SetKeyName(16, "");
            this.ImageList_16.Images.SetKeyName(17, "");
            this.ImageList_16.Images.SetKeyName(18, "");
            this.ImageList_16.Images.SetKeyName(19, "");
            this.ImageList_16.Images.SetKeyName(20, "");
            this.ImageList_16.Images.SetKeyName(21, "");
            this.ImageList_16.Images.SetKeyName(22, "");
            this.ImageList_16.Images.SetKeyName(23, "");
            this.ImageList_16.Images.SetKeyName(24, "");
            this.ImageList_16.Images.SetKeyName(25, "");
            this.ImageList_16.Images.SetKeyName(26, "");
            this.ImageList_16.Images.SetKeyName(27, "");
            this.ImageList_16.Images.SetKeyName(28, "");
            this.ImageList_16.Images.SetKeyName(29, "");
            this.ImageList_16.Images.SetKeyName(30, "");
            this.ImageList_16.Images.SetKeyName(31, "");
            this.ImageList_16.Images.SetKeyName(32, "");
            this.ImageList_16.Images.SetKeyName(33, "");
            this.ImageList_16.Images.SetKeyName(34, "");
            this.ImageList_16.Images.SetKeyName(35, "");
            this.ImageList_16.Images.SetKeyName(36, "");
            this.ImageList_16.Images.SetKeyName(37, "");
            this.ImageList_16.Images.SetKeyName(38, "");
            this.ImageList_16.Images.SetKeyName(39, "");
            this.ImageList_16.Images.SetKeyName(40, "");
            this.ImageList_16.Images.SetKeyName(41, "");
            this.ImageList_16.Images.SetKeyName(42, "");
            this.ImageList_16.Images.SetKeyName(43, "");
            this.ImageList_16.Images.SetKeyName(44, "");
            this.ImageList_16.Images.SetKeyName(45, "");
            this.ImageList_16.Images.SetKeyName(46, "");
            this.ImageList_16.Images.SetKeyName(47, "");
            this.ImageList_16.Images.SetKeyName(48, "");
            this.ImageList_16.Images.SetKeyName(49, "");
            this.ImageList_16.Images.SetKeyName(50, "");
            this.ImageList_16.Images.SetKeyName(51, "");
            this.ImageList_16.Images.SetKeyName(52, "");
            this.ImageList_16.Images.SetKeyName(53, "");
            this.ImageList_16.Images.SetKeyName(54, "");
            this.ImageList_16.Images.SetKeyName(55, "");
            this.ImageList_16.Images.SetKeyName(56, "");
            this.ImageList_16.Images.SetKeyName(57, "");
            this.ImageList_16.Images.SetKeyName(58, "");
            this.ImageList_16.Images.SetKeyName(59, "");
            this.ImageList_16.Images.SetKeyName(60, "");
            this.ImageList_16.Images.SetKeyName(61, "");
            this.ImageList_16.Images.SetKeyName(62, "");
            this.ImageList_16.Images.SetKeyName(63, "");
            this.ImageList_16.Images.SetKeyName(64, "");
            this.ImageList_16.Images.SetKeyName(65, "");
            this.ImageList_16.Images.SetKeyName(66, "");
            this.ImageList_16.Images.SetKeyName(67, "");
            this.ImageList_16.Images.SetKeyName(68, "");
            this.ImageList_16.Images.SetKeyName(69, "");
            this.ImageList_16.Images.SetKeyName(70, "");
            this.ImageList_16.Images.SetKeyName(71, "");
            this.ImageList_16.Images.SetKeyName(72, "");
            this.ImageList_16.Images.SetKeyName(73, "");
            this.ImageList_16.Images.SetKeyName(74, "");
            this.ImageList_16.Images.SetKeyName(75, "");
            this.ImageList_16.Images.SetKeyName(76, "");
            this.ImageList_16.Images.SetKeyName(77, "");
            this.ImageList_16.Images.SetKeyName(78, "");
            this.ImageList_16.Images.SetKeyName(79, "");
            this.ImageList_16.Images.SetKeyName(80, "");
            this.ImageList_16.Images.SetKeyName(81, "");
            this.ImageList_16.Images.SetKeyName(82, "");
            this.ImageList_16.Images.SetKeyName(83, "");
            this.ImageList_16.Images.SetKeyName(84, "");
            this.ImageList_16.Images.SetKeyName(85, "");
            this.ImageList_16.Images.SetKeyName(86, "");
            this.ImageList_16.Images.SetKeyName(87, "");
            this.ImageList_16.Images.SetKeyName(88, "");
            this.ImageList_16.Images.SetKeyName(89, "");
            this.ImageList_16.Images.SetKeyName(90, "");
            this.ImageList_16.Images.SetKeyName(91, "");
            this.ImageList_16.Images.SetKeyName(92, "");
            this.ImageList_16.Images.SetKeyName(93, "");
            this.ImageList_16.Images.SetKeyName(94, "");
            this.ImageList_16.Images.SetKeyName(95, "");
            this.ImageList_16.Images.SetKeyName(96, "");
            this.ImageList_16.Images.SetKeyName(97, "");
            this.ImageList_16.Images.SetKeyName(98, "");
            this.ImageList_16.Images.SetKeyName(99, "");
            this.ImageList_16.Images.SetKeyName(100, "");
            this.ImageList_16.Images.SetKeyName(101, "");
            this.ImageList_16.Images.SetKeyName(102, "");
            this.ImageList_16.Images.SetKeyName(103, "");
            this.ImageList_16.Images.SetKeyName(104, "");
            this.ImageList_16.Images.SetKeyName(105, "");
            this.ImageList_16.Images.SetKeyName(106, "");
            this.ImageList_16.Images.SetKeyName(107, "");
            this.ImageList_16.Images.SetKeyName(108, "");
            this.ImageList_16.Images.SetKeyName(109, "");
            this.ImageList_16.Images.SetKeyName(110, "");
            this.ImageList_16.Images.SetKeyName(111, "");
            this.ImageList_16.Images.SetKeyName(112, "");
            this.ImageList_16.Images.SetKeyName(113, "");
            this.ImageList_16.Images.SetKeyName(114, "");
            this.ImageList_16.Images.SetKeyName(115, "");
            this.ImageList_16.Images.SetKeyName(116, "");
            this.ImageList_16.Images.SetKeyName(117, "");
            this.ImageList_16.Images.SetKeyName(118, "");
            this.ImageList_16.Images.SetKeyName(119, "");
            this.ImageList_16.Images.SetKeyName(120, "");
            this.ImageList_16.Images.SetKeyName(121, "");
            this.ImageList_16.Images.SetKeyName(122, "");
            this.ImageList_16.Images.SetKeyName(123, "");
            this.ImageList_16.Images.SetKeyName(124, "");
            this.ImageList_16.Images.SetKeyName(125, "");
            this.ImageList_16.Images.SetKeyName(126, "");
            this.ImageList_16.Images.SetKeyName(127, "");
            this.ImageList_16.Images.SetKeyName(128, "");
            this.ImageList_16.Images.SetKeyName(129, "");
            this.ImageList_16.Images.SetKeyName(130, "");
            this.ImageList_16.Images.SetKeyName(131, "");
            this.ImageList_16.Images.SetKeyName(132, "");
            this.ImageList_16.Images.SetKeyName(133, "");
            this.ImageList_16.Images.SetKeyName(134, "");
            this.ImageList_16.Images.SetKeyName(135, "");
            this.ImageList_16.Images.SetKeyName(136, "");
            this.ImageList_16.Images.SetKeyName(137, "");
            this.ImageList_16.Images.SetKeyName(138, "");
            this.ImageList_16.Images.SetKeyName(139, "");
            this.ImageList_16.Images.SetKeyName(140, "");
            this.ImageList_16.Images.SetKeyName(141, "");
            this.ImageList_16.Images.SetKeyName(142, "");
            this.ImageList_16.Images.SetKeyName(143, "");
            this.ImageList_16.Images.SetKeyName(144, "");
            this.ImageList_16.Images.SetKeyName(145, "");
            this.ImageList_16.Images.SetKeyName(146, "");
            this.ImageList_16.Images.SetKeyName(147, "");
            this.ImageList_16.Images.SetKeyName(148, "");
            this.ImageList_16.Images.SetKeyName(149, "");
            this.ImageList_16.Images.SetKeyName(150, "");
            this.ImageList_16.Images.SetKeyName(151, "");
            this.ImageList_16.Images.SetKeyName(152, "");
            this.ImageList_16.Images.SetKeyName(153, "");
            this.ImageList_16.Images.SetKeyName(154, "");
            this.ImageList_16.Images.SetKeyName(155, "");
            this.ImageList_16.Images.SetKeyName(156, "");
            this.ImageList_16.Images.SetKeyName(157, "");
            this.ImageList_16.Images.SetKeyName(158, "");
            this.ImageList_16.Images.SetKeyName(159, "");
            this.ImageList_16.Images.SetKeyName(160, "");
            this.ImageList_16.Images.SetKeyName(161, "");
            this.ImageList_16.Images.SetKeyName(162, "");
            this.ImageList_16.Images.SetKeyName(163, "");
            this.ImageList_16.Images.SetKeyName(164, "");
            this.ImageList_16.Images.SetKeyName(165, "");
            this.ImageList_16.Images.SetKeyName(166, "");
            this.ImageList_16.Images.SetKeyName(167, "");
            this.ImageList_16.Images.SetKeyName(168, "");
            this.ImageList_16.Images.SetKeyName(169, "");
            this.ImageList_16.Images.SetKeyName(170, "");
            this.ImageList_16.Images.SetKeyName(171, "");
            this.ImageList_16.Images.SetKeyName(172, "");
            this.ImageList_16.Images.SetKeyName(173, "");
            this.ImageList_16.Images.SetKeyName(174, "");
            this.ImageList_16.Images.SetKeyName(175, "");
            this.ImageList_16.Images.SetKeyName(176, "");
            this.ImageList_16.Images.SetKeyName(177, "");
            this.ImageList_16.Images.SetKeyName(178, "");
            this.ImageList_16.Images.SetKeyName(179, "");
            this.ImageList_16.Images.SetKeyName(180, "");
            this.ImageList_16.Images.SetKeyName(181, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(182, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(183, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(184, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(185, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(186, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(187, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(188, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(189, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(190, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(191, "181.DUMMY181�`191.bmp");
            this.ImageList_16.Images.SetKeyName(192, "");
            // 
            // ImageList_24
            // 
            this.ImageList_24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_24.ImageStream")));
            this.ImageList_24.TransparentColor = System.Drawing.Color.White;
            this.ImageList_24.Images.SetKeyName(0, "");
            this.ImageList_24.Images.SetKeyName(1, "");
            this.ImageList_24.Images.SetKeyName(2, "");
            this.ImageList_24.Images.SetKeyName(3, "");
            this.ImageList_24.Images.SetKeyName(4, "");
            this.ImageList_24.Images.SetKeyName(5, "");
            this.ImageList_24.Images.SetKeyName(6, "");
            this.ImageList_24.Images.SetKeyName(7, "");
            this.ImageList_24.Images.SetKeyName(8, "");
            this.ImageList_24.Images.SetKeyName(9, "");
            this.ImageList_24.Images.SetKeyName(10, "");
            this.ImageList_24.Images.SetKeyName(11, "");
            this.ImageList_24.Images.SetKeyName(12, "");
            this.ImageList_24.Images.SetKeyName(13, "");
            this.ImageList_24.Images.SetKeyName(14, "");
            this.ImageList_24.Images.SetKeyName(15, "");
            this.ImageList_24.Images.SetKeyName(16, "");
            this.ImageList_24.Images.SetKeyName(17, "");
            this.ImageList_24.Images.SetKeyName(18, "");
            this.ImageList_24.Images.SetKeyName(19, "");
            this.ImageList_24.Images.SetKeyName(20, "");
            this.ImageList_24.Images.SetKeyName(21, "");
            this.ImageList_24.Images.SetKeyName(22, "");
            this.ImageList_24.Images.SetKeyName(23, "");
            this.ImageList_24.Images.SetKeyName(24, "");
            this.ImageList_24.Images.SetKeyName(25, "");
            this.ImageList_24.Images.SetKeyName(26, "");
            this.ImageList_24.Images.SetKeyName(27, "");
            this.ImageList_24.Images.SetKeyName(28, "");
            this.ImageList_24.Images.SetKeyName(29, "");
            this.ImageList_24.Images.SetKeyName(30, "");
            this.ImageList_24.Images.SetKeyName(31, "");
            this.ImageList_24.Images.SetKeyName(32, "");
            this.ImageList_24.Images.SetKeyName(33, "");
            this.ImageList_24.Images.SetKeyName(34, "");
            this.ImageList_24.Images.SetKeyName(35, "");
            this.ImageList_24.Images.SetKeyName(36, "");
            this.ImageList_24.Images.SetKeyName(37, "");
            this.ImageList_24.Images.SetKeyName(38, "");
            this.ImageList_24.Images.SetKeyName(39, "");
            this.ImageList_24.Images.SetKeyName(40, "");
            this.ImageList_24.Images.SetKeyName(41, "");
            this.ImageList_24.Images.SetKeyName(42, "");
            this.ImageList_24.Images.SetKeyName(43, "");
            this.ImageList_24.Images.SetKeyName(44, "");
            this.ImageList_24.Images.SetKeyName(45, "");
            this.ImageList_24.Images.SetKeyName(46, "");
            this.ImageList_24.Images.SetKeyName(47, "");
            this.ImageList_24.Images.SetKeyName(48, "");
            this.ImageList_24.Images.SetKeyName(49, "");
            this.ImageList_24.Images.SetKeyName(50, "");
            this.ImageList_24.Images.SetKeyName(51, "");
            this.ImageList_24.Images.SetKeyName(52, "");
            this.ImageList_24.Images.SetKeyName(53, "");
            this.ImageList_24.Images.SetKeyName(54, "");
            this.ImageList_24.Images.SetKeyName(55, "");
            this.ImageList_24.Images.SetKeyName(56, "");
            this.ImageList_24.Images.SetKeyName(57, "");
            this.ImageList_24.Images.SetKeyName(58, "");
            this.ImageList_24.Images.SetKeyName(59, "");
            this.ImageList_24.Images.SetKeyName(60, "");
            this.ImageList_24.Images.SetKeyName(61, "");
            this.ImageList_24.Images.SetKeyName(62, "");
            this.ImageList_24.Images.SetKeyName(63, "");
            this.ImageList_24.Images.SetKeyName(64, "");
            this.ImageList_24.Images.SetKeyName(65, "");
            this.ImageList_24.Images.SetKeyName(66, "");
            this.ImageList_24.Images.SetKeyName(67, "");
            this.ImageList_24.Images.SetKeyName(68, "");
            this.ImageList_24.Images.SetKeyName(69, "");
            this.ImageList_24.Images.SetKeyName(70, "");
            this.ImageList_24.Images.SetKeyName(71, "");
            // 
            // ImageList_32
            // 
            this.ImageList_32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_32.ImageStream")));
            this.ImageList_32.TransparentColor = System.Drawing.Color.Cyan;
            this.ImageList_32.Images.SetKeyName(0, "0.CLOSE.bmp");
            this.ImageList_32.Images.SetKeyName(1, "1.EMPLOYEE.bmp");
            this.ImageList_32.Images.SetKeyName(2, "2.SEARCH.bmp");
            this.ImageList_32.Images.SetKeyName(3, "3.TREE.bmp");
            this.ImageList_32.Images.SetKeyName(4, "4.VIEW.bmp");
            this.ImageList_32.Images.SetKeyName(5, "5.PRINT.bmp");
            this.ImageList_32.Images.SetKeyName(6, "6.DELETE.bmp");
            this.ImageList_32.Images.SetKeyName(7, "7.NEW.bmp");
            this.ImageList_32.Images.SetKeyName(8, "8.MODIFY.bmp");
            this.ImageList_32.Images.SetKeyName(9, "9.DETAILS.bmp");
            this.ImageList_32.Images.SetKeyName(10, "10.INTERRUPTION.bmp");
            this.ImageList_32.Images.SetKeyName(11, "11.RETRY.bmp");
            this.ImageList_32.Images.SetKeyName(12, "12.DECISION.bmp");
            this.ImageList_32.Images.SetKeyName(13, "13.SECURITY.bmp");
            this.ImageList_32.Images.SetKeyName(14, "14.GENERAL.bmp");
            this.ImageList_32.Images.SetKeyName(15, "15.FOLDER.bmp");
            this.ImageList_32.Images.SetKeyName(16, "16.PREVIEW.bmp");
            this.ImageList_32.Images.SetKeyName(17, "17.BEFORE.bmp");
            this.ImageList_32.Images.SetKeyName(18, "18.NEXT.bmp");
            this.ImageList_32.Images.SetKeyName(19, "19.PACKAGEPRINT.bmp");
            this.ImageList_32.Images.SetKeyName(20, "20.BASE.bmp");
            this.ImageList_32.Images.SetKeyName(21, "21.LIST1.bmp");
            this.ImageList_32.Images.SetKeyName(22, "22.LIST2.bmp");
            this.ImageList_32.Images.SetKeyName(23, "23.LIST3.bmp");
            this.ImageList_32.Images.SetKeyName(24, "24.LIST4.bmp");
            this.ImageList_32.Images.SetKeyName(25, "25.MAIN.bmp");
            this.ImageList_32.Images.SetKeyName(26, "26.SETUP1.bmp");
            this.ImageList_32.Images.SetKeyName(27, "27.TODAY.bmp");
            this.ImageList_32.Images.SetKeyName(28, "28.STAR1.bmp");
            this.ImageList_32.Images.SetKeyName(29, "29.SAVE.bmp");
            this.ImageList_32.Images.SetKeyName(30, "30.UNDO.bmp");
            this.ImageList_32.Images.SetKeyName(31, "31_MAKER_���[�J�[.bmp");
            this.ImageList_32.Images.SetKeyName(32, "32.MODEL.bmp");
            this.ImageList_32.Images.SetKeyName(33, "33_PACKAGEINPUT_�ꊇ����.bmp");
            this.ImageList_32.Images.SetKeyName(34, "34.INPUTCHECK.bmp");
            this.ImageList_32.Images.SetKeyName(35, "35.ALLSELECT.bmp");
            this.ImageList_32.Images.SetKeyName(36, "36.ALLCANCEL.bmp");
            this.ImageList_32.Images.SetKeyName(37, "37.SUBMENU.bmp");
            this.ImageList_32.Images.SetKeyName(38, "38.NUMBERPLATE.bmp");
            this.ImageList_32.Images.SetKeyName(39, "39.CUSTOMER.bmp");
            this.ImageList_32.Images.SetKeyName(40, "40.DATEAPPOINTMENT.bmp");
            this.ImageList_32.Images.SetKeyName(41, "41.EDITING.bmp");
            this.ImageList_32.Images.SetKeyName(42, "42.CUSTOMERINPUT1.bmp");
            this.ImageList_32.Images.SetKeyName(43, "43.CUSTOMERINPUT2.bmp");
            this.ImageList_32.Images.SetKeyName(44, "44.CUSTOMERDELETE.bmp");
            this.ImageList_32.Images.SetKeyName(45, "45.CAR.bmp");
            this.ImageList_32.Images.SetKeyName(46, "46.CARINPUT1.bmp");
            this.ImageList_32.Images.SetKeyName(47, "47.CARINPUT2.bmp");
            this.ImageList_32.Images.SetKeyName(48, "48.CARINPUT3.bmp");
            this.ImageList_32.Images.SetKeyName(49, "49.CARDELETE.bmp");
            this.ImageList_32.Images.SetKeyName(50, "50.CARADD.bmp");
            this.ImageList_32.Images.SetKeyName(51, "51_CUSTOMERNEW_�ڋq�V�K.bmp");
            this.ImageList_32.Images.SetKeyName(52, "52.COMMONCAR.bmp");
            this.ImageList_32.Images.SetKeyName(53, "53.LIGHTCAR.bmp");
            this.ImageList_32.Images.SetKeyName(54, "54_RESERVATION_�\��Ɩ�.bmp");
            this.ImageList_32.Images.SetKeyName(55, "55_CARCHECK_�_������_16.bmp");
            this.ImageList_32.Images.SetKeyName(56, "56_CARCHECK2_�_�����͂Q_16.bmp");
            this.ImageList_32.Images.SetKeyName(57, "57_DETAILS2_���ד���.bmp");
            this.ImageList_32.Images.SetKeyName(58, "58_COST_����p����.bmp");
            this.ImageList_32.Images.SetKeyName(59, "59_DISCOUNT_�l������.bmp");
            this.ImageList_32.Images.SetKeyName(60, "60_TOTALING_�W�v.bmp");
            this.ImageList_32.Images.SetKeyName(61, "61_IMAGESELECT_�摜�I��.bmp");
            this.ImageList_32.Images.SetKeyName(62, "62_PAINTING_�h��.bmp");
            this.ImageList_32.Images.SetKeyName(63, "63_FRAME_�����i.bmp");
            this.ImageList_32.Images.SetKeyName(64, "64_WORK_���.bmp");
            this.ImageList_32.Images.SetKeyName(65, "65_WORK2_��ƂQ.bmp");
            this.ImageList_32.Images.SetKeyName(66, "66_WORK3_��ƂR.bmp");
            this.ImageList_32.Images.SetKeyName(67, "67_CREDITPLAN_�x���v����.bmp");
            this.ImageList_32.Images.SetKeyName(68, "68_PARTSSELECT_���ʑI��.bmp");
            this.ImageList_32.Images.SetKeyName(69, "69_ROWINSERT_�s�}��.bmp");
            this.ImageList_32.Images.SetKeyName(70, "70_ROWDELETE_�s�폜.bmp");
            this.ImageList_32.Images.SetKeyName(71, "71_ROWCOPY_�s�R�s�[.bmp");
            this.ImageList_32.Images.SetKeyName(72, "72_ROWCUT_�s�؂���.bmp");
            this.ImageList_32.Images.SetKeyName(73, "73_ROWPASTE_�s�\�t.bmp");
            this.ImageList_32.Images.SetKeyName(74, "74_ROWUNION_�s�W��.bmp");
            this.ImageList_32.Images.SetKeyName(75, "75_GUIDE_�K�C�h.bmp");
            this.ImageList_32.Images.SetKeyName(76, "76_NEXT2_���ւQ.bmp");
            this.ImageList_32.Images.SetKeyName(77, "77_BEFORE2_�O�ւQ.bmp");
            this.ImageList_32.Images.SetKeyName(78, "78_CUSTOMERSEARCH_�ڋq����.bmp");
            this.ImageList_32.Images.SetKeyName(79, "79_CARSEARCH_�ԗ�����.bmp");
            this.ImageList_32.Images.SetKeyName(80, "80_SLIPSEARCH_�`�[����.bmp");
            this.ImageList_32.Images.SetKeyName(81, "81_ZOOMUP_�g��.bmp");
            this.ImageList_32.Images.SetKeyName(82, "82_ZOOMDOWN_�k��.bmp");
            this.ImageList_32.Images.SetKeyName(83, "83_LIST5.bmp");
            this.ImageList_32.Images.SetKeyName(84, "84_LIST6.bmp");
            this.ImageList_32.Images.SetKeyName(85, "85_LIST7.bmp");
            this.ImageList_32.Images.SetKeyName(86, "86_LIST8.bmp");
            this.ImageList_32.Images.SetKeyName(87, "87_INDICATIONCHANGE_�\���ؑ�.bmp");
            this.ImageList_32.Images.SetKeyName(88, "88_FOLDER2_�t�H���_�Q.bmp");
            this.ImageList_32.Images.SetKeyName(89, "89_GRAPH1_�O���t�P.bmp");
            this.ImageList_32.Images.SetKeyName(90, "90_GRAPH2_�O���t�Q.bmp");
            this.ImageList_32.Images.SetKeyName(91, "91_GRAPH3_�O���t�R.bmp");
            this.ImageList_32.Images.SetKeyName(92, "92_GRAPH4_�O���t�S.bmp");
            this.ImageList_32.Images.SetKeyName(93, "93_GRAPH5_�O���t�T.bmp");
            this.ImageList_32.Images.SetKeyName(94, "94_GRAPH6_�O���t�U.bmp");
            this.ImageList_32.Images.SetKeyName(95, "95_GRAPH7_�O���t�V.bmp");
            this.ImageList_32.Images.SetKeyName(96, "96_GRAPH8_�O���t8.bmp");
            this.ImageList_32.Images.SetKeyName(97, "97_INDICATIONCHANGE2_�\���ؑւQ.bmp");
            this.ImageList_32.Images.SetKeyName(98, "98_NEXT3_���ւR.bmp");
            this.ImageList_32.Images.SetKeyName(99, "99_BEFORE3_�O�ւR.bmp");
            this.ImageList_32.Images.SetKeyName(100, "100_EQUIPMENT_����.bmp");
            this.ImageList_32.Images.SetKeyName(101, "101_TOOL_�c�[��.bmp");
            this.ImageList_32.Images.SetKeyName(102, "102_CALENDAR_�J�����_�[.bmp");
            this.ImageList_32.Images.SetKeyName(103, "103_CALENDAR2_�J�����_�[�Q.bmp");
            this.ImageList_32.Images.SetKeyName(104, "104_CALENDAR3_�J�����_�[�R.bmp");
            this.ImageList_32.Images.SetKeyName(105, "105_CALENDAR4_�J�����_�[�S.bmp");
            this.ImageList_32.Images.SetKeyName(106, "106_CALENDAR5_�J�����_�[�T.bmp");
            this.ImageList_32.Images.SetKeyName(107, "107_CARNOTE_�ԗ����l.bmp");
            this.ImageList_32.Images.SetKeyName(108, "108_CARRECORD_�ԗ�����.bmp");
            this.ImageList_32.Images.SetKeyName(109, "109_CARCHANGE_�ԗ��ύX.bmp");
            this.ImageList_32.Images.SetKeyName(110, "110_DAMAGESPACEINPUT_��������.bmp");
            this.ImageList_32.Images.SetKeyName(111, "111_BLOCKSELECT_�u���b�N�I��.bmp");
            this.ImageList_32.Images.SetKeyName(112, "112_MAX_�ō�.bmp");
            this.ImageList_32.Images.SetKeyName(113, "113_SLIP_�`�[.bmp");
            this.ImageList_32.Images.SetKeyName(114, "114_MAIL_���[��.bmp");
            this.ImageList_32.Images.SetKeyName(115, "115_CLAIM_����.bmp");
            this.ImageList_32.Images.SetKeyName(116, "116_CUSTOMERNOTE_�ڋq���l.bmp");
            this.ImageList_32.Images.SetKeyName(117, "117_FAMILY_�Ƒ�.bmp");
            this.ImageList_32.Images.SetKeyName(118, "118.FREEMEMO_�t���[����.bmp");
            this.ImageList_32.Images.SetKeyName(119, "119.CARNEW_���q�V�K.bmp");
            this.ImageList_32.Images.SetKeyName(120, "120.MOVE_�ړ�.bmp");
            this.ImageList_32.Images.SetKeyName(121, "121.PEN_�y��.bmp");
            this.ImageList_32.Images.SetKeyName(122, "122.TEXT_�e�L�X�g.bmp");
            this.ImageList_32.Images.SetKeyName(123, "123.QUADRATURE_��`.bmp");
            this.ImageList_32.Images.SetKeyName(124, "124.QUADRATURE2_��`�Q.bmp");
            this.ImageList_32.Images.SetKeyName(125, "125.ELLIPSE_�ȉ~.bmp");
            this.ImageList_32.Images.SetKeyName(126, "126.COLOR_�J���[.bmp");
            this.ImageList_32.Images.SetKeyName(127, "127.IMAGE_�摜.bmp");
            this.ImageList_32.Images.SetKeyName(128, "128.IMAGEVIEW_�摜�Q��.bmp");
            this.ImageList_32.Images.SetKeyName(129, "129.HEADER_�w�b�_�[.bmp");
            this.ImageList_32.Images.SetKeyName(130, "130.FOOTER_�t�b�^�[.bmp");
            this.ImageList_32.Images.SetKeyName(131, "131.ROW_���׍s.bmp");
            this.ImageList_32.Images.SetKeyName(132, "132.COL_���ח�.bmp");
            this.ImageList_32.Images.SetKeyName(133, "133.MARGIN_�]��.bmp");
            this.ImageList_32.Images.SetKeyName(134, "134.FONT_�t�H���g.bmp");
            this.ImageList_32.Images.SetKeyName(135, "135.BODYSIZE_�{�f�B���@.bmp");
            this.ImageList_32.Images.SetKeyName(136, "136.MANUAL_�}�j���A��.bmp");
            this.ImageList_32.Images.SetKeyName(137, "137.CARPURCHASES_�ԗ��d��.bmp");
            this.ImageList_32.Images.SetKeyName(138, "138_CUSTOMERRECORD_���Ӑ旚��.bmp");
            this.ImageList_32.Images.SetKeyName(139, "139_MAKER2_���[�J�[2.bmp");
            this.ImageList_32.Images.SetKeyName(140, "140_MAKER3_���[�J�[3.bmp");
            this.ImageList_32.Images.SetKeyName(141, "141_MAKER4_���[�J�[4.bmp");
            this.ImageList_32.Images.SetKeyName(142, "142_MAKER5_���[�J�[5.bmp");
            this.ImageList_32.Images.SetKeyName(143, "143_MAKER6_���[�J�[6.bmp");
            this.ImageList_32.Images.SetKeyName(144, "144_MAKER7_���[�J�[7.bmp");
            this.ImageList_32.Images.SetKeyName(145, "145_MAKER8_���[�J�[8.bmp");
            this.ImageList_32.Images.SetKeyName(146, "146_ROWADD_�s�ǉ�.bmp");
            this.ImageList_32.Images.SetKeyName(147, "147_PRINTOUT_��.bmp");
            this.ImageList_32.Images.SetKeyName(148, "148_NOTPRINTOUT_���.bmp");
            this.ImageList_32.Images.SetKeyName(149, "149_DEBITNOTE_�ԓ`.bmp");
            this.ImageList_32.Images.SetKeyName(150, "150_DEMANDPROP_������.bmp");
            this.ImageList_32.Images.SetKeyName(151, "151_POSTCARD_�͂���.bmp");
            this.ImageList_32.Images.SetKeyName(152, "152_LABEL_���x��.bmp");
            this.ImageList_32.Images.SetKeyName(153, "153_DOWNLOAD_�_�E�����[�h.bmp");
            this.ImageList_32.Images.SetKeyName(154, "154_STOPPRINTOUT_�����~.bmp");
            this.ImageList_32.Images.SetKeyName(155, "155_DM_DM���s.bmp");
            this.ImageList_32.Images.SetKeyName(156, "156_INSURANCE_�ی�.bmp");
            this.ImageList_32.Images.SetKeyName(157, "157_RECYCLE_���T�C�N��.bmp");
            this.ImageList_32.Images.SetKeyName(158, "158_CSVTAKING_�b�r�u�捞.bmp");
            this.ImageList_32.Images.SetKeyName(159, "159_CSVOUTPUT_�b�r�u�o��.bmp");
            this.ImageList_32.Images.SetKeyName(160, "160_BLOUZER_�u���E�U�N��.bmp");
            this.ImageList_32.Images.SetKeyName(161, "161.COURCESELECT_�R�[�X�I��.bmp");
            this.ImageList_32.Images.SetKeyName(162, "162_REGISTRATIONNOMINEE_�o�^���`�l.bmp");
            this.ImageList_32.Images.SetKeyName(163, "163_GANTCHART_�K���g�`���[�g.bmp");
            this.ImageList_32.Images.SetKeyName(164, "164_REDSLIP_�ԓ`.bmp");
            this.ImageList_32.Images.SetKeyName(165, "165_REDBLACKSLIP_�ԍ��`�[.bmp");
            this.ImageList_32.Images.SetKeyName(166, "166_SLIPCOPY_�`�[�R�s�[.bmp");
            this.ImageList_32.Images.SetKeyName(167, "167_SAMPLE_�T���v��.bmp");
            this.ImageList_32.Images.SetKeyName(168, "168.SAVE2_�ۑ��Q.bmp");
            this.ImageList_32.Images.SetKeyName(169, "169_CANDIDATE_���.bmp");
            this.ImageList_32.Images.SetKeyName(170, "170_BUSINESSTALKSITUATION_���k��.bmp");
            this.ImageList_32.Images.SetKeyName(171, "171_SELECT_�I��.bmp");
            this.ImageList_32.Images.SetKeyName(172, "172_CUSTOMERCORP1_�������1.bmp");
            this.ImageList_32.Images.SetKeyName(173, "173_CUSTOMERCORP2_�������2.bmp");
            this.ImageList_32.Images.SetKeyName(174, "174_GRIDDISPLAY_�O���b�h�\��.bmp");
            this.ImageList_32.Images.SetKeyName(175, "175_DMRECORD_DM���s����.bmp");
            this.ImageList_32.Images.SetKeyName(176, "176_RECORDLIST_�����ꗗ�\��.bmp");
            this.ImageList_32.Images.SetKeyName(177, "177_GRIDDATACAPTURE_�O���b�h�f�[�^��荞��.bmp");
            this.ImageList_32.Images.SetKeyName(178, "178_RENEWAL_�ŐV�ɍX�V.bmp");
            this.ImageList_32.Images.SetKeyName(179, "179_RECALCULATION_�Čv�Z.bmp");
            this.ImageList_32.Images.SetKeyName(180, "180_SLIPREFLECT_�`�[�ɔ��f.bmp");
            this.ImageList_32.Images.SetKeyName(181, "181_AMBIGUOUSSEARCH_�B������.bmp");
            this.ImageList_32.Images.SetKeyName(182, "182_BARCODEINPUT_�o�[�R�[�h����.bmp");
            this.ImageList_32.Images.SetKeyName(183, "183_COURSESELECT_�R�[�X�I��.bmp");
            this.ImageList_32.Images.SetKeyName(184, "184_LATERMAINTENANCETAKING_���������荞��.bmp");
            this.ImageList_32.Images.SetKeyName(185, "185_LINEDATACAPTURE_���C���f�[�^��荞��.bmp");
            this.ImageList_32.Images.SetKeyName(186, "186_RECYCLEPARTS_���T�C�N���p�[�c.bmp");
            this.ImageList_32.Images.SetKeyName(187, "187_REPETITIONCHECK_�d�����i�`�F�b�N.bmp");
            this.ImageList_32.Images.SetKeyName(188, "188_SYMPTOMDIAGNOSIS_�Ǐ�f�f.bmp");
            this.ImageList_32.Images.SetKeyName(189, "189_TALLYSHEETCAPTURE_�L�^��f�[�^��荞��.bmp");
            this.ImageList_32.Images.SetKeyName(190, "190_TSPCAPTURE_TSP�f�[�^��荞��.bmp");
            this.ImageList_32.Images.SetKeyName(191, "191_VIDEO_����.bmp");
            this.ImageList_32.Images.SetKeyName(192, "192_DUMMY.bmp");

		}
		#endregion

		private static IconResourceManagement _icon = null;									// 2006.12.13 men DEL

		# region Properties
		/// <summary>16�~16�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>16�~16�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList ImageList16
		{
			get
			{
				if (_icon == null) _icon = new IconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ImageList_16;													// 2006.12.13 men ADD
				//IconResourceManagement icon = new IconResourceManagement();				// 2006.12.13 men DEL
				//return icon.ImageList_16;													// 2006.12.13 men DEL
			}
		}

		/// <summary>24�~24�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>24�~24�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList ImageList24
		{
			get
			{
				if (_icon == null) _icon = new IconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ImageList_24;													// 2006.12.13 men ADD
				//IconResourceManagement icon = new IconResourceManagement();				// 2006.12.13 men DEL
				//return icon.ImageList_24;													// 2006.12.13 men DEL
			}
		}

		/// <summary>32�~32�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>32�~32�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public static ImageList ImageList32
		{
			get
			{
				if (_icon == null) _icon = new IconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ImageList_32;													// 2006.12.13 men ADD
				//IconResourceManagement icon = new IconResourceManagement();				// 2006.12.13 men DEL
				//return icon.ImageList_32;													// 2006.12.13 men DEL
			}
		}

		/// <summary>16�~16�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>16�~16�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public ImageList IconImageList16
		{
			get
			{
				return this.ImageList_16;
			}
		}

		/// <summary>24�~24�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>24�~24�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public ImageList IconImageList24
		{
			get
			{
				return this.ImageList_24;
			}
		}

		/// <summary>32�~32�A�C�R���i�[ImageList�v���p�e�B</summary>
		/// <value>32�~32�̃A�C�R�����R���N�V����������ImageList�̎擾���s���܂��B</value>
		public ImageList IconImageList32
		{
			get
			{
				return this.ImageList_32;
			}
		}
		# endregion
	}

	# region enum Size32_Index
	/// <summary>32�~32�T�C�Y�A�C�R���̃C���f�b�N�X�̗񋓌^�ł��B</summary>
	public enum Size32_Index : int
	{
		/// <summary>����</summary>
		CLOSE = 0,

		/// <summary>�]�ƈ��i�S���ҁj</summary>
		EMPLOYEE = 1,

		/// <summary>����</summary>
		SEARCH = 2,

		/// <summary>�c���[</summary>
		TREE = 3,

		/// <summary>�r���[</summary>
		VIEW = 4,

		/// <summary>���</summary>
		PRINT = 5,

		/// <summary>�폜</summary>
		DELETE = 6,

		/// <summary>�V�K</summary>
		NEW = 7,

		/// <summary>�C��</summary>
		MODIFY = 8,

		/// <summary>�ڍ�</summary>
		DETAILS = 9,

		/// <summary>���f</summary>
		INTERRUPTION = 10,

		/// <summary>�Ď��s</summary>
		RETRY = 11,

		/// <summary>�m��</summary>
		DECISION = 12,

		/// <summary>�Z�L�����e�B</summary>
		SECURITY = 13,

		/// <summary>�S��</summary>
		GENERAL = 14,

		/// <summary>�t�H���_</summary>
		FOLDER = 15,

		/// <summary>�v���r���[</summary>
		PREVIEW = 16,

		/// <summary>�O��</summary>
		BEFORE = 17,

		/// <summary>����</summary>
		NEXT = 18,

		/// <summary>�ꊇ���</summary>
		PACKAGEPRINT = 19,

		/// <summary>���_</summary>
		BASE = 20,

		/// <summary>���[�P</summary>
		LIST1 = 21,

		/// <summary>���[�Q</summary>
		LIST2 = 22,

		/// <summary>���[�R</summary>
		LIST3 = 23,

		/// <summary>���[�S</summary>
		LIST4 = 24,

		/// <summary>���C��</summary>
		MAIN = 25,

		/// <summary>�ݒ�P</summary>
		SETUP1 = 26,

		/// <summary>�{��</summary>
		TODAY = 27,

		/// <summary>���P</summary>
		STAR1 = 28,

		/// <summary>�ۑ�</summary>
		SAVE = 29,

		/// <summary>������</summary>
		UNDO = 30,

		/// <summary>���[�J�[</summary>
		MAKER = 31,

		/// <summary>�Ԏ�</summary>
		MODEL = 32,

		/// <summary>�ꊇ����</summary>
		PACKAGEINPUT = 33,

		/// <summary>���̓`�F�b�N</summary>
		INPUTCHECK = 34,

		/// <summary>�S�đI��</summary>
		ALLSELECT = 35,

		/// <summary>�S�ĉ���</summary>
		ALLCANCEL = 36,

		/// <summary>�T�u���j���[</summary>
		SUBMENU = 37,

		/// <summary>�v���[�g�ԍ�</summary>
		NUMBERPLATE = 38,

		/// <summary>�ڋq</summary>
		CUSTOMER = 39,

		/// <summary>���t�w��</summary>
		DATEAPPOINTMENT = 40,

		/// <summary>�ҏW</summary>
		EDITING = 41,

		/// <summary>�ڋq���͂P</summary>
		CUSTOMERINPUT1 = 42,

		/// <summary>�ڋq���͂Q</summary>
		CUSTOMERINPUT2 = 43,

		/// <summary>�ڋq�폜</summary>
		CUSTOMERDELETE = 44,

		/// <summary>�ԗ�</summary>
		CAR = 45,

		/// <summary>�ԗ����͂P</summary>
		CARINPUT1 = 46,

		/// <summary>�ԗ����͂Q</summary>
		CARINPUT2 = 47,

		/// <summary>�ԗ����͂R</summary>
		CARINPUT3 = 48,

		/// <summary>�ԗ��폜</summary>
		CARDELETE = 49,

		/// <summary>�ǉ��ԗ�</summary>
		CARADD = 50,

		/// <summary>�ڋq�V�K</summary>
		CUSTOMERNEW = 51,

		/// <summary>���ʎ�����</summary>
		COMMONCAR = 52,

		/// <summary>�y������</summary>
		LIGHTCAR = 53,

		/// <summary>�\��Ɩ�</summary>
		RESERVATION = 54,

		/// <summary>�_������</summary>
		CARCHECK = 55,

		/// <summary>�_�����͂Q</summary>
		CARCHECK2 = 56,

		/// <summary>���ד���</summary>
		DETAILS2 = 57,

		/// <summary>����p����</summary>
		COST = 58,

		/// <summary>�l������</summary>
		DISCOUNT = 59,

		/// <summary>�W�v</summary>
		TOTALING = 60,

		/// <summary>�摜�I��</summary>
		IMAGESELECT = 61,

		/// <summary>�h��</summary>
		PAINTING = 62,

		/// <summary>�����i</summary>
		FRAME = 63,

		/// <summary>���</summary>
		WORK = 64,

		/// <summary>��ƂQ</summary>
		WORK2 = 65,

		/// <summary>��ƂR</summary>
		WORK3 = 66,

		/// <summary>�x���v����</summary>
		CREDITPLAN = 67,

		/// <summary>���ʑI��</summary>
		PARTSSELECT = 68,

		/// <summary>�s�}��</summary>
		ROWINSERT = 69,

		/// <summary>�s�폜</summary>
		ROWDELETE = 70,

		/// <summary>�s�R�s�[</summary>
		ROWCOPY = 71,

		/// <summary>�s�؂���</summary>
		ROWCUT = 72,

		/// <summary>�s�\�t</summary>
		ROWPASTE = 73,

		/// <summary>�s�W��</summary>
		ROWUNION = 74,

		/// <summary>�K�C�h</summary>
		GUIDE = 75,

		/// <summary>���ւQ</summary>
		NEXT2 = 76,

		/// <summary>�O�ւQ</summary>
		BEFORE2 = 77,

		/// <summary>�ڋq����</summary>
		CUSTOMERSEARCH = 78,

		/// <summary>�ԗ�����</summary>
		CARSEARCH = 79,

		/// <summary>�`�[����</summary>
		SLIPSEARCH = 80,

		/// <summary>�g��</summary>
		ZOOMUP = 81,

		/// <summary>�k��</summary>
		ZOOMDOWN = 82,

		/// <summary>���[�T</summary>
		LIST5 = 83,

		/// <summary>���[�U</summary>
		LIST6 = 84,

		/// <summary>���[�V</summary>
		LIST7 = 85,

		/// <summary>���[�W</summary>
		LIST8 = 86,

		/// <summary>�\���ؑ�</summary>
		INDICATIONCHANGE = 87,

		/// <summary>�t�H���_�Q</summary>
		FOLDER2 = 88,

		/// <summary>�_�O���t�P</summary>
		BARGRAPH1 = 89,

		/// <summary>�܂���O���t�P</summary>
		LINEGRAPH1 = 90,

		/// <summary>�~�O���t�P</summary>
		PIECHART1 = 91,

		/// <summary>�U�z�}�P</summary>
		POINTCHART1 = 92,

		/// <summary>�_�O���t�Q</summary>
		BARGRAPH2 = 93,

		/// <summary>�܂���O���t�Q</summary>
		LINEGRAPH2 = 94,

		/// <summary>�~�O���t�Q</summary>
		PIECHART2 = 95,

		/// <summary>�U�z�}�Q</summary>
		POINTCHART2 = 96,

		/// <summary>�\���ؑւQ</summary>
		INDICATIONCHANGE2 = 97,

		/// <summary>���ւR</summary>
		NEXT3 = 98,

		/// <summary>�O�R</summary>
		BEFORE3 = 99,

		/// <summary>����</summary>
		EQUIPMENT = 100,

		/// <summary>�c�[��</summary>
		TOOL = 101,

		/// <summary>�J�����_�[</summary>
		CALENDAR = 102,

		/// <summary>�J�����_�[�Q</summary>
		CALENDAR2 = 103,

		/// <summary>�J�����_�[�R</summary>
		CALENDAR3 = 104,

		/// <summary>�J�����_�[�S</summary>
		CALENDAR4 = 105,

		/// <summary>�J�����_�[�T</summary>
		CALENDAR5 = 106,

		/// <summary>�ԗ����l</summary>
		CARNOTE = 107,

		/// <summary>�ԗ�����</summary>
		CARRECORD = 108,

		/// <summary>�ԗ��ύX</summary>
		CARCHANGE = 109,

		/// <summary>��������</summary>
		DAMAGESPACEINPUT = 110,

		/// <summary>�u���b�N�I��</summary>
		BLOCKSELECT = 111,

		/// <summary>�ō�</summary>
		MAX = 112,

		/// <summary>�`�[</summary>
		SLIP = 113,

		/// <summary>���[��</summary>
		MAIL = 114,

		/// <summary>����</summary>
		CLAIM = 115,

		/// <summary>�ڋq���l</summary>
		CUSTOMERNOTE = 116,

		/// <summary>�Ƒ�</summary>
		FAMILY = 117,

		/// <summary>�t���[����</summary>
		FREEMEMO = 118,

		/// <summary>���q�V�K</summary>
		CARNEW = 119,

		/// <summary>�ړ�</summary>
		MOVE = 120,

		/// <summary>�y��</summary>
		PEN = 121,

		/// <summary>�e�L�X�g</summary>
		TEXT = 122,

		/// <summary>��`</summary>
		QUADRATURE = 123,

		/// <summary>��`�Q</summary>
		QUADRATURE2 = 124,

		/// <summary>�ȉ~</summary>
		ELLIPSE = 125,

		/// <summary>�J���[</summary>
		COLOR = 126,

		/// <summary>�摜</summary>
		IMAGE = 127,

		/// <summary>�摜�Q��</summary>
		IMAGEVIEW = 128,

		/// <summary>�w�b�_�[</summary>
		HEADER = 129,

		/// <summary>�t�b�^�[</summary>
		FOOTER = 130,

		/// <summary>���׍s</summary>
		ROW = 131,

		/// <summary>���ח�</summary>
		COL = 132,

		/// <summary>�]��</summary>
		MARGIN = 133,

		/// <summary>�t�H���g</summary>
		FONT = 134,

		/// <summary>�{�f�B���@</summary>
		BODYSIZE = 135,

		/// <summary>�}�j���A��</summary>
		MANUAL = 136,

		/// <summary>�ԗ��d��</summary>
		CARPURCHASES = 137,

		/// <summary>���Ӑ旚��</summary>
		CUSTOMERRECORD = 138,

		/// <summary>���[�J�[�Q</summary>
		MAKER2 = 139,

		/// <summary>���[�J�[�R</summary>
		MAKER3 = 140,

		/// <summary>���[�J�[�S</summary>
		MAKER4 = 141,

		/// <summary>���[�J�[�T</summary>
		MAKER5 = 142,

		/// <summary>���[�J�[�U</summary>
		MAKER6 = 143,

		/// <summary>���[�J�[�V</summary>
		MAKER7 = 144,

		/// <summary>���[�J�[�W</summary>
		MAKER8 = 145,

		/// <summary>�s�ǉ�</summary>
		ROWADD = 146,

		/// <summary>��</summary>
		PRINTOUT = 147,

		/// <summary>���</summary>
		NOTPRINTOUT = 148,

		/// <summary>�ԓ`</summary>
		DEBITNOTE = 149,

		/// <summary>������</summary>
		DEMANDPROP = 150,

		/// <summary>�͂���</summary>
		POSTCARD = 151,

		/// <summary>���x��</summary>
		LABEL = 152,

		/// <summary>�_�E�����[�h</summary>
		DOWNLOAD = 153,

		/// <summary>�����~</summary>
		STOPPRINTOUT = 154,

		/// <summary>DM���s</summary>
		DM = 155,

		/// <summary>�ی�</summary>
		INSURANCE = 156,

		/// <summary>���T�C�N��</summary>
		RECYCLE = 157,

		/// <summary>�b�r�u�捞</summary>
		CSVTAKING = 158,

		/// <summary>�b�r�u�o��</summary>
		CSVOUTPUT = 159,

		/// <summary>�u���E�U�N��</summary>
		BLOUZER = 160,

		/// <summary>�R�[�X�I��</summary>
		COURCESELECT = 161,

		/// <summary>�o�^���`�l</summary>
		REGISTRATIONNOMINEE = 162,

		/// <summary>�K���g�`���[�g</summary>
		GANTCHART = 163,

		/// <summary>�ԓ`</summary>
		REDSLIP = 164,

		/// <summary>�ԍ��`�[</summary>
		REDBLACKSLIP = 165,

		/// <summary>�`�[�R�s�[</summary>
		SLIPCOPY = 166,

		/// <summary>�T���v��</summary>
		SAMPLE = 167,

		/// <summary>�ۑ��Q</summary>
		SAVE2 = 168,

		/// <summary>���</summary>
		CANDIDATE = 169,

		/// <summary>���k��</summary>
		BUSINESSTALKSITUATION = 170,

		/// <summary>�I��</summary>
		SELECT = 171,

		/// <summary>������ƂP</summary>
		CUSTOMERCORP1 = 172,

		/// <summary>������ƂQ</summary>
		CUSTOMERCORP2 = 173,

		/// <summary>�O���b�h�\��</summary>
		GRIDDISPLAY = 174,

		/// <summary>�c�l���s����</summary>
		DMRECORD = 175,

		/// <summary>�����ꗗ�\��</summary>
		RECORDLIST = 176,

		/// <summary>�O���b�h�f�[�^��荞��</summary>
		GRIDDATACAPTURE = 177,

		/// <summary>�ŐV�ɍX�V</summary>
		RENEWAL = 178,

		/// <summary>�Čv�Z</summary>
		RECALCULATION = 179,

		/// <summary>�`�[�ɔ��f</summary>
		SLIPREFLECT = 180,

		/// <summary>�B������</summary>
		AMBIGUOUSSEARCH = 181,

		/// <summary>�o�[�R�[�h����</summary>
		BARCODEINPUT = 182,

		/// <summary>�R�[�X�I��</summary>
		COURSESELECT = 183,

		/// <summary>���������荞��</summary>
		LATERMAINTENANCETAKING = 184,

		/// <summary>���C���f�[�^��荞��</summary>
		LINEDATACAPTURE = 185,

		/// <summary>���T�C�N���p�[�c</summary>
		RECYCLEPARTS = 186,

		/// <summary>���i�d���`�F�b�N</summary>
		REPETITIONCHECK = 187,

		/// <summary>�Ǐ�f�f</summary>
		SYMPTOMDIAGNOSIS = 188,

		/// <summary>�L�^��f�[�^��荞��</summary>
		TALLYSHEETCAPTURE = 189,

		/// <summary>�s�r�o�f�[�^��荞��</summary>
		TSPCAPTURE = 190,

		/// <summary>����</summary>
		VIDEO = 191
	}
	# endregion

	# region enum Size24_Index
	/// <summary>24�~24�T�C�Y�A�C�R���̃C���f�b�N�X�̗񋓌^�ł��B</summary>
	public enum Size24_Index : int
	{
		/// <summary>�ۑ�</summary>
		SAVE = 0,

		/// <summary>����</summary>
		CLOSE = 1,

		/// <summary>�폜</summary>
		DELETE = 2,

		/// <summary>����</summary>
		REVIVAL = 3,

		/// <summary>�ݒ�P</summary>
		SETUP1 = 4,

		/// <summary>�s�}��</summary>
		ROWINSERT = 5,

		/// <summary>�s�폜</summary>
		ROWDELETE = 6,

		/// <summary>�s�R�s�[</summary>
		ROWCOPY = 7,

		/// <summary>�s�؂���</summary>
		ROWCUT = 8,

		/// <summary>�s�\�t</summary>
		ROWPASTE = 9,

		/// <summary>�s�W��</summary>
		ROWUNION = 10,

		/// <summary>�m��</summary>
		DECISION = 11,

		/// <summary>�g��</summary>
		ZOOMUP = 12,

		/// <summary>�k��</summary>
		ZOOMDOWN = 13,

		/// <summary>���</summary>
		WORK = 14,

		/// <summary>��ƂQ</summary>
		WORK2 = 15,

		/// <summary>��ƂR</summary>
		WORK3 = 16,

		/// <summary>�ԗ��E����</summary>
		CARRIGHT = 17,

		/// <summary>�ԗ�������</summary>
		CARBOTTOM = 18,

		/// <summary>�ԗ�������</summary>
		CARFOLLOWING = 19,

		/// <summary>�ԗ�������</summary>
		CARLEFT = 20,

		/// <summary>�ԗ������</summary>
		CARLATER = 21,

		/// <summary>�ԗ��O����</summary>
		CARFRONT = 22,

		/// <summary>�E���</summary>
		RIGHTARROW = 23,

		/// <summary>�����</summary>
		BUTTOMARROW = 24,

		/// <summary>�����</summary>
		LEFTARROW = 25,

		/// <summary>����</summary>
		LATERARROW = 26,

		/// <summary>����</summary>
		NEXT = 27,

		/// <summary>�O��</summary>
		BEFORE = 28,

		/// <summary>�E��</summary>
		TOFP = 29,

		/// <summary>���</summary>
		BODYREPAIR = 30,

		/// <summary>���</summary>
		EXCHANGE = 31,

		/// <summary>�R�[�X�I��</summary>
		COURSESELECT = 32,

		/// <summary>�摜�I��</summary>
		IMAGESELECT = 33,

		/// <summary>�B������</summary>
		AMBIGUOUSSEARCH = 34,

		/// <summary>���ʑI��</summary>
		PARTSSELECT = 35,

		/// <summary>������</summary>
		DEMANDPROP = 36,

		/// <summary>�S���҈�</summary>
		EMPLOYEEPROP = 37,

		/// <summary>�t�H���g</summary>
		FONT = 38,

		/// <summary>�t�э�ƓW�J</summary>
		ACCOMPANYINGWORKDEVELOPMENT = 39,

		/// <summary>�C���f���g</summary>
		INDENT = 40,

		/// <summary>�C���f���g����</summary>
		INDENTRELEASE = 41,

		/// <summary>�C���i�[�p�[�c�ꊇ�폜</summary>
		INNERPARTSBATCHDELETE = 42,

		/// <summary>�i�Ԉꊇ�폜</summary>
		NUMBERBATCHDELETE = 43,

		/// <summary>�i�ԕ\��</summary>
		NUMBERDISPLAY = 44,

		/// <summary>���i�C���f���g</summary>
		PARTSINDENT = 45,

		/// <summary>���i�E��ƓW�J</summary>
		PARTSWORKDEVELOPMENT = 46,

		/// <summary>���T�C�N���p�[�c</summary>
		RECYCLEPARTS = 47,

		/// <summary>���i�d���`�F�b�N</summary>
		REPETITIONCHECK = 48,

		/// <summary>���i���z�ꊇ�폜</summary>
		SUMBATCHDELETE = 49,

		/// <summary>�Čv�Z</summary>
		RECALCULATION = 50,

		/// <summary>�o�[�R�[�h����</summary>
		BARCODEINPUT = 51,

		/// <summary>��������捞</summary>
		LATERMAINTENANCETAKING = 52,

		/// <summary>�Ǐ�f�f</summary>
		SYMPTOMDIAGNOSIS = 53,

		/// <summary>�V�K</summary>
		NEW = 54,

		/// <summary>�C��</summary>
		MODIFY = 55,

		/// <summary>���C���f�[�^��荞��</summary>
		LINEDATACAPTURE = 56,

		/// <summary>�_��</summary>
		CHECK = 57,

		/// <summary>����</summary>
		ADJUST = 58,
		
		/// <summary>���|</summary>
		CLEAN = 59,
		
		/// <summary>��[</summary>
		REPLENISHMENT = 60,
		
		/// <summary>����</summary>
		RESOLUTION = 61,
		
		/// <summary>OH</summary>
		OH = 62,
		
		/// <summary>�C��</summary>
		REPAIR = 63,
		
		/// <summary>����</summary>
		MEASUREMENT = 64,
		
		/// <summary>�g��</summary>
		STRUCTURE = 65,
		
		/// <summary>�ؒf</summary>
		CUT = 66,
		
		/// <summary>�l��</summary>
		DISCOUNT = 67,
		
		/// <summary>�n��</summary>
		WELD = 68,
		
		/// <summary>�h��</summary>
		LACQUERING = 69,
		
		/// <summary>�N���[��</summary>
		COMPLAINT = 70,

        /// <summary>�`�F�b�N</summary>
		ITEMCHECK = 71

	}
	# endregion

	# region enum Size16_Index
	/// <summary>16�~16�T�C�Y�A�C�R���̃C���f�b�N�X�̗񋓌^�ł��B</summary>
	public enum Size16_Index : int
	{
		/// <summary>����</summary>
		CLOSE = 0,

		/// <summary>�]�ƈ��i�S���ҁj</summary>
		EMPLOYEE = 1,

		/// <summary>����</summary>
		SEARCH = 2,

		/// <summary>�c���[</summary>
		TREE = 3,

		/// <summary>�r���[</summary>
		VIEW = 4,

		/// <summary>���</summary>
		PRINT = 5,

		/// <summary>�폜</summary>
		DELETE = 6,

		/// <summary>�V�K</summary>
		NEW = 7,

		/// <summary>�C��</summary>
		MODIFY = 8,

		/// <summary>�ڍ�</summary>
		DETAILS = 9,

		/// <summary>���f</summary>
		INTERRUPTION = 10,

		/// <summary>�Ď��s</summary>
		RETRY = 11,

		/// <summary>�m��</summary>
		DECISION = 12,

		/// <summary>�Z�L�����e�B</summary>
		SECURITY = 13,

		/// <summary>�S��</summary>
		GENERAL = 14,

		/// <summary>�t�H���_</summary>
		FOLDER = 15,

		/// <summary>�v���r���[</summary>
		PREVIEW = 16,

		/// <summary>�O��</summary>
		BEFORE = 17,

		/// <summary>����</summary>
		NEXT = 18,

		/// <summary>�ꊇ���</summary>
		PACKAGEPRINT = 19,

		/// <summary>���_</summary>
		BASE = 20,

		/// <summary>���[�P</summary>
		LIST1 = 21,

		/// <summary>���[�Q</summary>
		LIST2 = 22,

		/// <summary>���[�R</summary>
		LIST3 = 23,

		/// <summary>���[�S</summary>
		LIST4 = 24,

		/// <summary>���C��</summary>
		MAIN = 25,

		/// <summary>�ݒ�P</summary>
		SETUP1 = 26,

		/// <summary>�{��</summary>
		TODAY = 27,

		/// <summary>���P</summary>
		STAR1 = 28,

		/// <summary>�ۑ�</summary>
		SAVE = 29,

		/// <summary>������</summary>
		UNDO = 30,

		/// <summary>���[�J�[</summary>
		MAKER = 31,

		/// <summary>�Ԏ�</summary>
		MODEL = 32,

		/// <summary>�ꊇ����</summary>
		PACKAGEINPUT = 33,

		/// <summary>���̓`�F�b�N</summary>
		INPUTCHECK = 34,
	
		/// <summary>�S�đI��</summary>
		ALLSELECT = 35,
	
		/// <summary>�S�ĉ���</summary>
		ALLCANCEL = 36,
	
		/// <summary>�T�u���j���[</summary>
		SUBMENU = 37,

		/// <summary>�v���[�g�ԍ�</summary>
		NUMBERPLATE = 38,

		/// <summary>�ڋq</summary>
		CUSTOMER = 39,

		/// <summary>���t�w��</summary>
		DATEAPPOINTMENT = 40,

		/// <summary>�ҏW</summary>
		EDITING = 41,

		/// <summary>�ڋq���͂P</summary>
		CUSTOMERINPUT1 = 42,

		/// <summary>�ڋq���͂Q</summary>
		CUSTOMERINPUT2 = 43,

		/// <summary>�ڋq�폜</summary>
		CUSTOMERDELETE = 44,

		/// <summary>�ԗ�</summary>
		CAR = 45,

		/// <summary>�ԗ����͂P</summary>
		CARINPUT1 = 46,

		/// <summary>�ԗ����͂Q</summary>
		CARINPUT2 = 47,

		/// <summary>�ԗ����͂R</summary>
		CARINPUT3 = 48,

		/// <summary>�ԗ��폜</summary>
		CARDELETE = 49,

		/// <summary>�ǉ��ԗ�</summary>
		CARADD = 50,

		/// <summary>�ڋq�V�K</summary>
		CUSTOMERNEW = 51,

		/// <summary>���ʎ�����</summary>
		COMMONCAR = 52,

		/// <summary>�y������</summary>
		LIGHTCAR = 53,

		/// <summary>�\��Ɩ�</summary>
		RESERVATION = 54,

		/// <summary>�_������</summary>
		CARCHECK = 55,

		/// <summary>�_�����͂Q</summary>
		CARCHECK2 = 56,

		/// <summary>���ד���</summary>
		DETAILS2 = 57,

		/// <summary>����p����</summary>
		COST = 58,

		/// <summary>�l������</summary>
		DISCOUNT = 59,

		/// <summary>�W�v</summary>
		TOTALING = 60,

		/// <summary>�摜�I��</summary>
		IMAGESELECT = 61,

		/// <summary>�h��</summary>
		PAINTING = 62,

		/// <summary>�����i</summary>
		FRAME = 63,

		/// <summary>���</summary>
		WORK = 64,

		/// <summary>��ƂQ</summary>
		WORK2 = 65,

		/// <summary>��ƂR</summary>
		WORK3 = 66,

		/// <summary>�x���v����</summary>
		CREDITPLAN = 67,

		/// <summary>���ʑI��</summary>
		PARTSSELECT = 68,

		/// <summary>�s�}��</summary>
		ROWINSERT = 69,

		/// <summary>�s�폜</summary>
		ROWDELETE = 70,

		/// <summary>�s�R�s�[</summary>
		ROWCOPY = 71,

		/// <summary>�s�؂���</summary>
		ROWCUT = 72,

		/// <summary>�s�\�t</summary>
		ROWPASTE = 73,

		/// <summary>�s�W��</summary>
		ROWUNION = 74,

		/// <summary>�K�C�h</summary>
		GUIDE = 75,

		/// <summary>���ւQ</summary>
		NEXT2 = 76,

		/// <summary>�O�ւQ</summary>
		BEFORE2 = 77,

		/// <summary>�ڋq����</summary>
		CUSTOMERSEARCH = 78,

		/// <summary>�ԗ�����</summary>
		CARSEARCH = 79,

		/// <summary>�`�[����</summary>
		SLIPSEARCH = 80,

		/// <summary>�g��</summary>
		ZOOMUP = 81,

		/// <summary>�k��</summary>
		ZOOMDOWN = 82,

		/// <summary>���[�T</summary>
		LIST5 = 83,

		/// <summary>���[�U</summary>
		LIST6 = 84,

		/// <summary>���[�V</summary>
		LIST7 = 85,

		/// <summary>���[�W</summary>
		LIST8 = 86,

		/// <summary>�\���ؑ�</summary>
		INDICATIONCHANGE = 87,

		/// <summary>�t�H���_�Q</summary>
		FOLDER2 = 88,

		/// <summary>�_�O���t�P</summary>
		BARGRAPH1 = 89,

		/// <summary>�܂���O���t�P</summary>
		LINEGRAPH1 = 90,

		/// <summary>�~�O���t�P</summary>
		PIECHART1 = 91,

		/// <summary>�U�z�}�P</summary>
		POINTCHART1 = 92,

		/// <summary>�_�O���t�Q</summary>
		BARGRAPH2 = 93,

		/// <summary>�܂���O���t�Q</summary>
		LINEGRAPH2 = 94,

		/// <summary>�~�O���t�Q</summary>
		PIECHART2 = 95,

		/// <summary>�U�z�}�Q</summary>
		POINTCHART2 = 96,

		/// <summary>�\���ؑւQ</summary>
		INDICATIONCHANGE2 = 97,

		/// <summary>���ւR</summary>
		NEXT3 = 98,

		/// <summary>�O�R</summary>
		BEFORE3 = 99,

		/// <summary>����</summary>
		EQUIPMENT = 100,

		/// <summary>�c�[��</summary>
		TOOL = 101,

		/// <summary>�J�����_�[</summary>
		CALENDAR = 102,

		/// <summary>�J�����_�[�Q</summary>
		CALENDAR2 = 103,

		/// <summary>�J�����_�[�R</summary>
		CALENDAR3 = 104,

		/// <summary>�J�����_�[�S</summary>
		CALENDAR4 = 105,

		/// <summary>�J�����_�[�T</summary>
		CALENDAR5 = 106,

		/// <summary>�ԗ����l</summary>
		CARNOTE = 107,

		/// <summary>�ԗ�����</summary>
		CARRECORD = 108,

		/// <summary>�ԗ��ύX</summary>
		CARCHANGE = 109,

		/// <summary>��������</summary>
		DAMAGESPACEINPUT = 110,

		/// <summary>�u���b�N�I��</summary>
		BLOCKSELECT = 111,
	
		/// <summary>�ō�</summary>
		MAX = 112,
	
		/// <summary>�`�[</summary>
		SLIP = 113,
	
		/// <summary>���[��</summary>
		MAIL = 114,

		/// <summary>����</summary>
		CLAIM = 115,
	
		/// <summary>�ڋq���l</summary>
		CUSTOMERNOTE = 116,
	
		/// <summary>�Ƒ�</summary>
		FAMILY = 117,

		/// <summary>�t���[����</summary>
		FREEMEMO = 118,

		/// <summary>���q�V�K</summary>
		CARNEW = 119,

		/// <summary>�ړ�</summary>
		MOVE = 120,

		/// <summary>�y��</summary>
		PEN = 121,

		/// <summary>�e�L�X�g</summary>
		TEXT = 122,

		/// <summary>��`</summary>
		QUADRATURE = 123,

		/// <summary>��`�Q</summary>
		QUADRATURE2 = 124,

		/// <summary>�ȉ~</summary>
		ELLIPSE = 125,

		/// <summary>�J���[</summary>
		COLOR = 126,

		/// <summary>�摜</summary>
		IMAGE = 127,

		/// <summary>�摜�Q��</summary>
		IMAGEVIEW = 128,

		/// <summary>�w�b�_�[</summary>
		HEADER = 129,

		/// <summary>�t�b�^�[</summary>
		FOOTER = 130,

		/// <summary>���׍s</summary>
		ROW = 131,

		/// <summary>���ח�</summary>
		COL = 132,

		/// <summary>�]��</summary>
		MARGIN = 133,

		/// <summary>�t�H���g</summary>
		FONT = 134,

		/// <summary>�{�f�B���@</summary>
		BODYSIZE = 135,

		/// <summary>�}�j���A��</summary>
		MANUAL = 136,

		/// <summary>�ԗ��d��</summary>
		CARPURCHASES = 137,

		/// <summary>���Ӑ旚��</summary>
		CUSTOMERRECORD = 138,

		/// <summary>���[�J�[�Q</summary>
		MAKER2 = 139,

		/// <summary>���[�J�[�R</summary>
		MAKER3 = 140,

		/// <summary>���[�J�[�S</summary>
		MAKER4 = 141,

		/// <summary>���[�J�[�T</summary>
		MAKER5 = 142,

		/// <summary>���[�J�[�U</summary>
		MAKER6 = 143,

		/// <summary>���[�J�[�V</summary>
		MAKER7 = 144,

		/// <summary>���[�J�[�W</summary>
		MAKER8 = 145,

		/// <summary>�s�ǉ�</summary>
		ROWADD = 146,

		/// <summary>��</summary>
		PRINTOUT = 147,

		/// <summary>���</summary>
		NOTPRINTOUT = 148,

		/// <summary>�ԓ`</summary>
		DEBITNOTE = 149,

		/// <summary>������</summary>
		DEMANDPROP = 150,

		/// <summary>�͂���</summary>
		POSTCARD = 151,

		/// <summary>���x��</summary>
		LABEL = 152,

		/// <summary>�_�E�����[�h</summary>
		DOWNLOAD = 153,

		/// <summary>�����~</summary>
		STOPPRINTOUT = 154,

		/// <summary>DM���s</summary>
		DM = 155,

		/// <summary>�ی�</summary>
		INSURANCE = 156,

		/// <summary>���T�C�N��</summary>
		RECYCLE = 157,

		/// <summary>�b�r�u�捞</summary>
		CSVTAKING = 158,

		/// <summary>�b�r�u�o��</summary>
		CSVOUTPUT = 159,

		/// <summary>�u���E�U�N��</summary>
		BLOUZER = 160,

		/// <summary>�R�[�X�I��</summary>
		COURCESELECT = 161,

		/// <summary>�o�^���`�l</summary>
		REGISTRATIONNOMINEE = 162,

		/// <summary>�K���g�`���[�g</summary>
		GANTCHART = 163,

		/// <summary>�ԓ`</summary>
		REDSLIP = 164,

		/// <summary>�ԍ��`�[</summary>
		REDBLACKSLIP = 165,

		/// <summary>�`�[�R�s�[</summary>
		SLIPCOPY = 166,

		/// <summary>�T���v��</summary>
		SAMPLE = 167,

		/// <summary>�ۑ��Q</summary>
		SAVE2 = 168,

		/// <summary>���</summary>
		CANDIDATE = 169,

		/// <summary>���k��</summary>
		BUSINESSTALKSITUATION = 170,

		/// <summary>�I��</summary>
		SELECT = 171,

		/// <summary>������ƂP</summary>
		CUSTOMERCORP1 = 172,

		/// <summary>������ƂQ</summary>
		CUSTOMERCORP2 = 173,

		/// <summary>�O���b�h�\��</summary>
		GRIDDISPLAY = 174,

		/// <summary>�c�l���s����</summary>
		DMRECORD = 175,

		/// <summary>�����ꗗ�\��</summary>
		RECORDLIST = 176,

		/// <summary>�O���b�h�f�[�^��荞��</summary>
		GRIDDATACAPTURE = 177,

		/// <summary>�ŐV�ɍX�V</summary>
		RENEWAL = 178,

		/// <summary>�Čv�Z</summary>
		RECALCULATION = 179,

		/// <summary>�`�[�ɔ��f</summary>
		SLIPREFLECT = 180,

		/// <summary>�摜�`��</summary>
		SENDIMAGE = 192
	}
	# endregion
}

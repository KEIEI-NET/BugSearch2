using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// アイコンリソース管理クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : アイコンリソースの管理を行います。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// <br>Update Note : </br>
	/// <br>2006.04.18 men Visual Studio 2005 対応</br>
	/// <br>2006.11.29 men 192.SENDIMAGE_画像伝送を追加</br>
	/// <br>2006.12.13 men 余計なインスタンス化処理を省いて高速化</br>
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
		/// アイコンリソース管理クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : アイコンリソース管理クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public IconResourceManagement()
		{
			InitializeComponent();
		}
		# endregion

		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
		/// コード］エディタで変更しないでください。
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
            this.ImageList_16.Images.SetKeyName(181, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(182, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(183, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(184, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(185, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(186, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(187, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(188, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(189, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(190, "181.DUMMY181～191.bmp");
            this.ImageList_16.Images.SetKeyName(191, "181.DUMMY181～191.bmp");
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
            this.ImageList_32.Images.SetKeyName(31, "31_MAKER_メーカー.bmp");
            this.ImageList_32.Images.SetKeyName(32, "32.MODEL.bmp");
            this.ImageList_32.Images.SetKeyName(33, "33_PACKAGEINPUT_一括入力.bmp");
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
            this.ImageList_32.Images.SetKeyName(51, "51_CUSTOMERNEW_顧客新規.bmp");
            this.ImageList_32.Images.SetKeyName(52, "52.COMMONCAR.bmp");
            this.ImageList_32.Images.SetKeyName(53, "53.LIGHTCAR.bmp");
            this.ImageList_32.Images.SetKeyName(54, "54_RESERVATION_予約業務.bmp");
            this.ImageList_32.Images.SetKeyName(55, "55_CARCHECK_点検入力_16.bmp");
            this.ImageList_32.Images.SetKeyName(56, "56_CARCHECK2_点検入力２_16.bmp");
            this.ImageList_32.Images.SetKeyName(57, "57_DETAILS2_明細入力.bmp");
            this.ImageList_32.Images.SetKeyName(58, "58_COST_諸費用入力.bmp");
            this.ImageList_32.Images.SetKeyName(59, "59_DISCOUNT_値引入力.bmp");
            this.ImageList_32.Images.SetKeyName(60, "60_TOTALING_集計.bmp");
            this.ImageList_32.Images.SetKeyName(61, "61_IMAGESELECT_画像選択.bmp");
            this.ImageList_32.Images.SetKeyName(62, "62_PAINTING_塗装.bmp");
            this.ImageList_32.Images.SetKeyName(63, "63_FRAME_内板骨格.bmp");
            this.ImageList_32.Images.SetKeyName(64, "64_WORK_作業.bmp");
            this.ImageList_32.Images.SetKeyName(65, "65_WORK2_作業２.bmp");
            this.ImageList_32.Images.SetKeyName(66, "66_WORK3_作業３.bmp");
            this.ImageList_32.Images.SetKeyName(67, "67_CREDITPLAN_支払プラン.bmp");
            this.ImageList_32.Images.SetKeyName(68, "68_PARTSSELECT_部位選択.bmp");
            this.ImageList_32.Images.SetKeyName(69, "69_ROWINSERT_行挿入.bmp");
            this.ImageList_32.Images.SetKeyName(70, "70_ROWDELETE_行削除.bmp");
            this.ImageList_32.Images.SetKeyName(71, "71_ROWCOPY_行コピー.bmp");
            this.ImageList_32.Images.SetKeyName(72, "72_ROWCUT_行切り取り.bmp");
            this.ImageList_32.Images.SetKeyName(73, "73_ROWPASTE_行貼付.bmp");
            this.ImageList_32.Images.SetKeyName(74, "74_ROWUNION_行集約.bmp");
            this.ImageList_32.Images.SetKeyName(75, "75_GUIDE_ガイド.bmp");
            this.ImageList_32.Images.SetKeyName(76, "76_NEXT2_次へ２.bmp");
            this.ImageList_32.Images.SetKeyName(77, "77_BEFORE2_前へ２.bmp");
            this.ImageList_32.Images.SetKeyName(78, "78_CUSTOMERSEARCH_顧客検索.bmp");
            this.ImageList_32.Images.SetKeyName(79, "79_CARSEARCH_車両検索.bmp");
            this.ImageList_32.Images.SetKeyName(80, "80_SLIPSEARCH_伝票検索.bmp");
            this.ImageList_32.Images.SetKeyName(81, "81_ZOOMUP_拡大.bmp");
            this.ImageList_32.Images.SetKeyName(82, "82_ZOOMDOWN_縮小.bmp");
            this.ImageList_32.Images.SetKeyName(83, "83_LIST5.bmp");
            this.ImageList_32.Images.SetKeyName(84, "84_LIST6.bmp");
            this.ImageList_32.Images.SetKeyName(85, "85_LIST7.bmp");
            this.ImageList_32.Images.SetKeyName(86, "86_LIST8.bmp");
            this.ImageList_32.Images.SetKeyName(87, "87_INDICATIONCHANGE_表示切替.bmp");
            this.ImageList_32.Images.SetKeyName(88, "88_FOLDER2_フォルダ２.bmp");
            this.ImageList_32.Images.SetKeyName(89, "89_GRAPH1_グラフ１.bmp");
            this.ImageList_32.Images.SetKeyName(90, "90_GRAPH2_グラフ２.bmp");
            this.ImageList_32.Images.SetKeyName(91, "91_GRAPH3_グラフ３.bmp");
            this.ImageList_32.Images.SetKeyName(92, "92_GRAPH4_グラフ４.bmp");
            this.ImageList_32.Images.SetKeyName(93, "93_GRAPH5_グラフ５.bmp");
            this.ImageList_32.Images.SetKeyName(94, "94_GRAPH6_グラフ６.bmp");
            this.ImageList_32.Images.SetKeyName(95, "95_GRAPH7_グラフ７.bmp");
            this.ImageList_32.Images.SetKeyName(96, "96_GRAPH8_グラフ8.bmp");
            this.ImageList_32.Images.SetKeyName(97, "97_INDICATIONCHANGE2_表示切替２.bmp");
            this.ImageList_32.Images.SetKeyName(98, "98_NEXT3_次へ３.bmp");
            this.ImageList_32.Images.SetKeyName(99, "99_BEFORE3_前へ３.bmp");
            this.ImageList_32.Images.SetKeyName(100, "100_EQUIPMENT_装備.bmp");
            this.ImageList_32.Images.SetKeyName(101, "101_TOOL_ツール.bmp");
            this.ImageList_32.Images.SetKeyName(102, "102_CALENDAR_カレンダー.bmp");
            this.ImageList_32.Images.SetKeyName(103, "103_CALENDAR2_カレンダー２.bmp");
            this.ImageList_32.Images.SetKeyName(104, "104_CALENDAR3_カレンダー３.bmp");
            this.ImageList_32.Images.SetKeyName(105, "105_CALENDAR4_カレンダー４.bmp");
            this.ImageList_32.Images.SetKeyName(106, "106_CALENDAR5_カレンダー５.bmp");
            this.ImageList_32.Images.SetKeyName(107, "107_CARNOTE_車両備考.bmp");
            this.ImageList_32.Images.SetKeyName(108, "108_CARRECORD_車両履歴.bmp");
            this.ImageList_32.Images.SetKeyName(109, "109_CARCHANGE_車両変更.bmp");
            this.ImageList_32.Images.SetKeyName(110, "110_DAMAGESPACEINPUT_損傷入力.bmp");
            this.ImageList_32.Images.SetKeyName(111, "111_BLOCKSELECT_ブロック選択.bmp");
            this.ImageList_32.Images.SetKeyName(112, "112_MAX_最高.bmp");
            this.ImageList_32.Images.SetKeyName(113, "113_SLIP_伝票.bmp");
            this.ImageList_32.Images.SetKeyName(114, "114_MAIL_メール.bmp");
            this.ImageList_32.Images.SetKeyName(115, "115_CLAIM_請求.bmp");
            this.ImageList_32.Images.SetKeyName(116, "116_CUSTOMERNOTE_顧客備考.bmp");
            this.ImageList_32.Images.SetKeyName(117, "117_FAMILY_家族.bmp");
            this.ImageList_32.Images.SetKeyName(118, "118.FREEMEMO_フリーメモ.bmp");
            this.ImageList_32.Images.SetKeyName(119, "119.CARNEW_車輌新規.bmp");
            this.ImageList_32.Images.SetKeyName(120, "120.MOVE_移動.bmp");
            this.ImageList_32.Images.SetKeyName(121, "121.PEN_ペン.bmp");
            this.ImageList_32.Images.SetKeyName(122, "122.TEXT_テキスト.bmp");
            this.ImageList_32.Images.SetKeyName(123, "123.QUADRATURE_矩形.bmp");
            this.ImageList_32.Images.SetKeyName(124, "124.QUADRATURE2_矩形２.bmp");
            this.ImageList_32.Images.SetKeyName(125, "125.ELLIPSE_楕円.bmp");
            this.ImageList_32.Images.SetKeyName(126, "126.COLOR_カラー.bmp");
            this.ImageList_32.Images.SetKeyName(127, "127.IMAGE_画像.bmp");
            this.ImageList_32.Images.SetKeyName(128, "128.IMAGEVIEW_画像参照.bmp");
            this.ImageList_32.Images.SetKeyName(129, "129.HEADER_ヘッダー.bmp");
            this.ImageList_32.Images.SetKeyName(130, "130.FOOTER_フッター.bmp");
            this.ImageList_32.Images.SetKeyName(131, "131.ROW_明細行.bmp");
            this.ImageList_32.Images.SetKeyName(132, "132.COL_明細列.bmp");
            this.ImageList_32.Images.SetKeyName(133, "133.MARGIN_余白.bmp");
            this.ImageList_32.Images.SetKeyName(134, "134.FONT_フォント.bmp");
            this.ImageList_32.Images.SetKeyName(135, "135.BODYSIZE_ボディ寸法.bmp");
            this.ImageList_32.Images.SetKeyName(136, "136.MANUAL_マニュアル.bmp");
            this.ImageList_32.Images.SetKeyName(137, "137.CARPURCHASES_車両仕入.bmp");
            this.ImageList_32.Images.SetKeyName(138, "138_CUSTOMERRECORD_得意先履歴.bmp");
            this.ImageList_32.Images.SetKeyName(139, "139_MAKER2_メーカー2.bmp");
            this.ImageList_32.Images.SetKeyName(140, "140_MAKER3_メーカー3.bmp");
            this.ImageList_32.Images.SetKeyName(141, "141_MAKER4_メーカー4.bmp");
            this.ImageList_32.Images.SetKeyName(142, "142_MAKER5_メーカー5.bmp");
            this.ImageList_32.Images.SetKeyName(143, "143_MAKER6_メーカー6.bmp");
            this.ImageList_32.Images.SetKeyName(144, "144_MAKER7_メーカー7.bmp");
            this.ImageList_32.Images.SetKeyName(145, "145_MAKER8_メーカー8.bmp");
            this.ImageList_32.Images.SetKeyName(146, "146_ROWADD_行追加.bmp");
            this.ImageList_32.Images.SetKeyName(147, "147_PRINTOUT_印字.bmp");
            this.ImageList_32.Images.SetKeyName(148, "148_NOTPRINTOUT_非印字.bmp");
            this.ImageList_32.Images.SetKeyName(149, "149_DEBITNOTE_赤伝.bmp");
            this.ImageList_32.Images.SetKeyName(150, "150_DEMANDPROP_請求按分.bmp");
            this.ImageList_32.Images.SetKeyName(151, "151_POSTCARD_はがき.bmp");
            this.ImageList_32.Images.SetKeyName(152, "152_LABEL_ラベル.bmp");
            this.ImageList_32.Images.SetKeyName(153, "153_DOWNLOAD_ダウンロード.bmp");
            this.ImageList_32.Images.SetKeyName(154, "154_STOPPRINTOUT_印刷停止.bmp");
            this.ImageList_32.Images.SetKeyName(155, "155_DM_DM発行.bmp");
            this.ImageList_32.Images.SetKeyName(156, "156_INSURANCE_保険.bmp");
            this.ImageList_32.Images.SetKeyName(157, "157_RECYCLE_リサイクル.bmp");
            this.ImageList_32.Images.SetKeyName(158, "158_CSVTAKING_ＣＳＶ取込.bmp");
            this.ImageList_32.Images.SetKeyName(159, "159_CSVOUTPUT_ＣＳＶ出力.bmp");
            this.ImageList_32.Images.SetKeyName(160, "160_BLOUZER_ブラウザ起動.bmp");
            this.ImageList_32.Images.SetKeyName(161, "161.COURCESELECT_コース選択.bmp");
            this.ImageList_32.Images.SetKeyName(162, "162_REGISTRATIONNOMINEE_登録名義人.bmp");
            this.ImageList_32.Images.SetKeyName(163, "163_GANTCHART_ガントチャート.bmp");
            this.ImageList_32.Images.SetKeyName(164, "164_REDSLIP_赤伝.bmp");
            this.ImageList_32.Images.SetKeyName(165, "165_REDBLACKSLIP_赤黒伝票.bmp");
            this.ImageList_32.Images.SetKeyName(166, "166_SLIPCOPY_伝票コピー.bmp");
            this.ImageList_32.Images.SetKeyName(167, "167_SAMPLE_サンプル.bmp");
            this.ImageList_32.Images.SetKeyName(168, "168.SAVE2_保存２.bmp");
            this.ImageList_32.Images.SetKeyName(169, "169_CANDIDATE_候補.bmp");
            this.ImageList_32.Images.SetKeyName(170, "170_BUSINESSTALKSITUATION_商談状況.bmp");
            this.ImageList_32.Images.SetKeyName(171, "171_SELECT_選択.bmp");
            this.ImageList_32.Images.SetKeyName(172, "172_CUSTOMERCORP1_取引先企業1.bmp");
            this.ImageList_32.Images.SetKeyName(173, "173_CUSTOMERCORP2_取引先企業2.bmp");
            this.ImageList_32.Images.SetKeyName(174, "174_GRIDDISPLAY_グリッド表示.bmp");
            this.ImageList_32.Images.SetKeyName(175, "175_DMRECORD_DM発行履歴.bmp");
            this.ImageList_32.Images.SetKeyName(176, "176_RECORDLIST_履歴一覧表示.bmp");
            this.ImageList_32.Images.SetKeyName(177, "177_GRIDDATACAPTURE_グリッドデータ取り込み.bmp");
            this.ImageList_32.Images.SetKeyName(178, "178_RENEWAL_最新に更新.bmp");
            this.ImageList_32.Images.SetKeyName(179, "179_RECALCULATION_再計算.bmp");
            this.ImageList_32.Images.SetKeyName(180, "180_SLIPREFLECT_伝票に反映.bmp");
            this.ImageList_32.Images.SetKeyName(181, "181_AMBIGUOUSSEARCH_曖昧検索.bmp");
            this.ImageList_32.Images.SetKeyName(182, "182_BARCODEINPUT_バーコード入力.bmp");
            this.ImageList_32.Images.SetKeyName(183, "183_COURSESELECT_コース選択.bmp");
            this.ImageList_32.Images.SetKeyName(184, "184_LATERMAINTENANCETAKING_後日整備取り込み.bmp");
            this.ImageList_32.Images.SetKeyName(185, "185_LINEDATACAPTURE_ラインデータ取り込み.bmp");
            this.ImageList_32.Images.SetKeyName(186, "186_RECYCLEPARTS_リサイクルパーツ.bmp");
            this.ImageList_32.Images.SetKeyName(187, "187_REPETITIONCHECK_重複部品チェック.bmp");
            this.ImageList_32.Images.SetKeyName(188, "188_SYMPTOMDIAGNOSIS_症状診断.bmp");
            this.ImageList_32.Images.SetKeyName(189, "189_TALLYSHEETCAPTURE_記録簿データ取り込み.bmp");
            this.ImageList_32.Images.SetKeyName(190, "190_TSPCAPTURE_TSPデータ取り込み.bmp");
            this.ImageList_32.Images.SetKeyName(191, "191_VIDEO_動画.bmp");
            this.ImageList_32.Images.SetKeyName(192, "192_DUMMY.bmp");

		}
		#endregion

		private static IconResourceManagement _icon = null;									// 2006.12.13 men DEL

		# region Properties
		/// <summary>16×16アイコン格納ImageListプロパティ</summary>
		/// <value>16×16のアイコンをコレクション化したImageListの取得を行います。</value>
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

		/// <summary>24×24アイコン格納ImageListプロパティ</summary>
		/// <value>24×24のアイコンをコレクション化したImageListの取得を行います。</value>
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

		/// <summary>32×32アイコン格納ImageListプロパティ</summary>
		/// <value>32×32のアイコンをコレクション化したImageListの取得を行います。</value>
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

		/// <summary>16×16アイコン格納ImageListプロパティ</summary>
		/// <value>16×16のアイコンをコレクション化したImageListの取得を行います。</value>
		public ImageList IconImageList16
		{
			get
			{
				return this.ImageList_16;
			}
		}

		/// <summary>24×24アイコン格納ImageListプロパティ</summary>
		/// <value>24×24のアイコンをコレクション化したImageListの取得を行います。</value>
		public ImageList IconImageList24
		{
			get
			{
				return this.ImageList_24;
			}
		}

		/// <summary>32×32アイコン格納ImageListプロパティ</summary>
		/// <value>32×32のアイコンをコレクション化したImageListの取得を行います。</value>
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
	/// <summary>32×32サイズアイコンのインデックスの列挙型です。</summary>
	public enum Size32_Index : int
	{
		/// <summary>閉じる</summary>
		CLOSE = 0,

		/// <summary>従業員（担当者）</summary>
		EMPLOYEE = 1,

		/// <summary>検索</summary>
		SEARCH = 2,

		/// <summary>ツリー</summary>
		TREE = 3,

		/// <summary>ビュー</summary>
		VIEW = 4,

		/// <summary>印刷</summary>
		PRINT = 5,

		/// <summary>削除</summary>
		DELETE = 6,

		/// <summary>新規</summary>
		NEW = 7,

		/// <summary>修正</summary>
		MODIFY = 8,

		/// <summary>詳細</summary>
		DETAILS = 9,

		/// <summary>中断</summary>
		INTERRUPTION = 10,

		/// <summary>再実行</summary>
		RETRY = 11,

		/// <summary>確定</summary>
		DECISION = 12,

		/// <summary>セキュリティ</summary>
		SECURITY = 13,

		/// <summary>全般</summary>
		GENERAL = 14,

		/// <summary>フォルダ</summary>
		FOLDER = 15,

		/// <summary>プレビュー</summary>
		PREVIEW = 16,

		/// <summary>前へ</summary>
		BEFORE = 17,

		/// <summary>次へ</summary>
		NEXT = 18,

		/// <summary>一括印刷</summary>
		PACKAGEPRINT = 19,

		/// <summary>拠点</summary>
		BASE = 20,

		/// <summary>帳票１</summary>
		LIST1 = 21,

		/// <summary>帳票２</summary>
		LIST2 = 22,

		/// <summary>帳票３</summary>
		LIST3 = 23,

		/// <summary>帳票４</summary>
		LIST4 = 24,

		/// <summary>メイン</summary>
		MAIN = 25,

		/// <summary>設定１</summary>
		SETUP1 = 26,

		/// <summary>本日</summary>
		TODAY = 27,

		/// <summary>星１</summary>
		STAR1 = 28,

		/// <summary>保存</summary>
		SAVE = 29,

		/// <summary>取り消し</summary>
		UNDO = 30,

		/// <summary>メーカー</summary>
		MAKER = 31,

		/// <summary>車種</summary>
		MODEL = 32,

		/// <summary>一括入力</summary>
		PACKAGEINPUT = 33,

		/// <summary>入力チェック</summary>
		INPUTCHECK = 34,

		/// <summary>全て選択</summary>
		ALLSELECT = 35,

		/// <summary>全て解除</summary>
		ALLCANCEL = 36,

		/// <summary>サブメニュー</summary>
		SUBMENU = 37,

		/// <summary>プレート番号</summary>
		NUMBERPLATE = 38,

		/// <summary>顧客</summary>
		CUSTOMER = 39,

		/// <summary>日付指定</summary>
		DATEAPPOINTMENT = 40,

		/// <summary>編集</summary>
		EDITING = 41,

		/// <summary>顧客入力１</summary>
		CUSTOMERINPUT1 = 42,

		/// <summary>顧客入力２</summary>
		CUSTOMERINPUT2 = 43,

		/// <summary>顧客削除</summary>
		CUSTOMERDELETE = 44,

		/// <summary>車両</summary>
		CAR = 45,

		/// <summary>車両入力１</summary>
		CARINPUT1 = 46,

		/// <summary>車両入力２</summary>
		CARINPUT2 = 47,

		/// <summary>車両入力３</summary>
		CARINPUT3 = 48,

		/// <summary>車両削除</summary>
		CARDELETE = 49,

		/// <summary>追加車両</summary>
		CARADD = 50,

		/// <summary>顧客新規</summary>
		CUSTOMERNEW = 51,

		/// <summary>普通自動車</summary>
		COMMONCAR = 52,

		/// <summary>軽自動車</summary>
		LIGHTCAR = 53,

		/// <summary>予約業務</summary>
		RESERVATION = 54,

		/// <summary>点検入力</summary>
		CARCHECK = 55,

		/// <summary>点検入力２</summary>
		CARCHECK2 = 56,

		/// <summary>明細入力</summary>
		DETAILS2 = 57,

		/// <summary>諸費用入力</summary>
		COST = 58,

		/// <summary>値引入力</summary>
		DISCOUNT = 59,

		/// <summary>集計</summary>
		TOTALING = 60,

		/// <summary>画像選択</summary>
		IMAGESELECT = 61,

		/// <summary>塗装</summary>
		PAINTING = 62,

		/// <summary>内板骨格</summary>
		FRAME = 63,

		/// <summary>作業</summary>
		WORK = 64,

		/// <summary>作業２</summary>
		WORK2 = 65,

		/// <summary>作業３</summary>
		WORK3 = 66,

		/// <summary>支払プラン</summary>
		CREDITPLAN = 67,

		/// <summary>部位選択</summary>
		PARTSSELECT = 68,

		/// <summary>行挿入</summary>
		ROWINSERT = 69,

		/// <summary>行削除</summary>
		ROWDELETE = 70,

		/// <summary>行コピー</summary>
		ROWCOPY = 71,

		/// <summary>行切り取り</summary>
		ROWCUT = 72,

		/// <summary>行貼付</summary>
		ROWPASTE = 73,

		/// <summary>行集約</summary>
		ROWUNION = 74,

		/// <summary>ガイド</summary>
		GUIDE = 75,

		/// <summary>次へ２</summary>
		NEXT2 = 76,

		/// <summary>前へ２</summary>
		BEFORE2 = 77,

		/// <summary>顧客検索</summary>
		CUSTOMERSEARCH = 78,

		/// <summary>車両検索</summary>
		CARSEARCH = 79,

		/// <summary>伝票検索</summary>
		SLIPSEARCH = 80,

		/// <summary>拡大</summary>
		ZOOMUP = 81,

		/// <summary>縮小</summary>
		ZOOMDOWN = 82,

		/// <summary>帳票５</summary>
		LIST5 = 83,

		/// <summary>帳票６</summary>
		LIST6 = 84,

		/// <summary>帳票７</summary>
		LIST7 = 85,

		/// <summary>帳票８</summary>
		LIST8 = 86,

		/// <summary>表示切替</summary>
		INDICATIONCHANGE = 87,

		/// <summary>フォルダ２</summary>
		FOLDER2 = 88,

		/// <summary>棒グラフ１</summary>
		BARGRAPH1 = 89,

		/// <summary>折れ線グラフ１</summary>
		LINEGRAPH1 = 90,

		/// <summary>円グラフ１</summary>
		PIECHART1 = 91,

		/// <summary>散布図１</summary>
		POINTCHART1 = 92,

		/// <summary>棒グラフ２</summary>
		BARGRAPH2 = 93,

		/// <summary>折れ線グラフ２</summary>
		LINEGRAPH2 = 94,

		/// <summary>円グラフ２</summary>
		PIECHART2 = 95,

		/// <summary>散布図２</summary>
		POINTCHART2 = 96,

		/// <summary>表示切替２</summary>
		INDICATIONCHANGE2 = 97,

		/// <summary>次へ３</summary>
		NEXT3 = 98,

		/// <summary>前３</summary>
		BEFORE3 = 99,

		/// <summary>装備</summary>
		EQUIPMENT = 100,

		/// <summary>ツール</summary>
		TOOL = 101,

		/// <summary>カレンダー</summary>
		CALENDAR = 102,

		/// <summary>カレンダー２</summary>
		CALENDAR2 = 103,

		/// <summary>カレンダー３</summary>
		CALENDAR3 = 104,

		/// <summary>カレンダー４</summary>
		CALENDAR4 = 105,

		/// <summary>カレンダー５</summary>
		CALENDAR5 = 106,

		/// <summary>車両備考</summary>
		CARNOTE = 107,

		/// <summary>車両履歴</summary>
		CARRECORD = 108,

		/// <summary>車両変更</summary>
		CARCHANGE = 109,

		/// <summary>損傷入力</summary>
		DAMAGESPACEINPUT = 110,

		/// <summary>ブロック選択</summary>
		BLOCKSELECT = 111,

		/// <summary>最高</summary>
		MAX = 112,

		/// <summary>伝票</summary>
		SLIP = 113,

		/// <summary>メール</summary>
		MAIL = 114,

		/// <summary>請求</summary>
		CLAIM = 115,

		/// <summary>顧客備考</summary>
		CUSTOMERNOTE = 116,

		/// <summary>家族</summary>
		FAMILY = 117,

		/// <summary>フリーメモ</summary>
		FREEMEMO = 118,

		/// <summary>車輌新規</summary>
		CARNEW = 119,

		/// <summary>移動</summary>
		MOVE = 120,

		/// <summary>ペン</summary>
		PEN = 121,

		/// <summary>テキスト</summary>
		TEXT = 122,

		/// <summary>矩形</summary>
		QUADRATURE = 123,

		/// <summary>矩形２</summary>
		QUADRATURE2 = 124,

		/// <summary>楕円</summary>
		ELLIPSE = 125,

		/// <summary>カラー</summary>
		COLOR = 126,

		/// <summary>画像</summary>
		IMAGE = 127,

		/// <summary>画像参照</summary>
		IMAGEVIEW = 128,

		/// <summary>ヘッダー</summary>
		HEADER = 129,

		/// <summary>フッター</summary>
		FOOTER = 130,

		/// <summary>明細行</summary>
		ROW = 131,

		/// <summary>明細列</summary>
		COL = 132,

		/// <summary>余白</summary>
		MARGIN = 133,

		/// <summary>フォント</summary>
		FONT = 134,

		/// <summary>ボディ寸法</summary>
		BODYSIZE = 135,

		/// <summary>マニュアル</summary>
		MANUAL = 136,

		/// <summary>車両仕入</summary>
		CARPURCHASES = 137,

		/// <summary>得意先履歴</summary>
		CUSTOMERRECORD = 138,

		/// <summary>メーカー２</summary>
		MAKER2 = 139,

		/// <summary>メーカー３</summary>
		MAKER3 = 140,

		/// <summary>メーカー４</summary>
		MAKER4 = 141,

		/// <summary>メーカー５</summary>
		MAKER5 = 142,

		/// <summary>メーカー６</summary>
		MAKER6 = 143,

		/// <summary>メーカー７</summary>
		MAKER7 = 144,

		/// <summary>メーカー８</summary>
		MAKER8 = 145,

		/// <summary>行追加</summary>
		ROWADD = 146,

		/// <summary>印字</summary>
		PRINTOUT = 147,

		/// <summary>非印字</summary>
		NOTPRINTOUT = 148,

		/// <summary>赤伝</summary>
		DEBITNOTE = 149,

		/// <summary>請求按分</summary>
		DEMANDPROP = 150,

		/// <summary>はがき</summary>
		POSTCARD = 151,

		/// <summary>ラベル</summary>
		LABEL = 152,

		/// <summary>ダウンロード</summary>
		DOWNLOAD = 153,

		/// <summary>印刷停止</summary>
		STOPPRINTOUT = 154,

		/// <summary>DM発行</summary>
		DM = 155,

		/// <summary>保険</summary>
		INSURANCE = 156,

		/// <summary>リサイクル</summary>
		RECYCLE = 157,

		/// <summary>ＣＳＶ取込</summary>
		CSVTAKING = 158,

		/// <summary>ＣＳＶ出力</summary>
		CSVOUTPUT = 159,

		/// <summary>ブラウザ起動</summary>
		BLOUZER = 160,

		/// <summary>コース選択</summary>
		COURCESELECT = 161,

		/// <summary>登録名義人</summary>
		REGISTRATIONNOMINEE = 162,

		/// <summary>ガントチャート</summary>
		GANTCHART = 163,

		/// <summary>赤伝</summary>
		REDSLIP = 164,

		/// <summary>赤黒伝票</summary>
		REDBLACKSLIP = 165,

		/// <summary>伝票コピー</summary>
		SLIPCOPY = 166,

		/// <summary>サンプル</summary>
		SAMPLE = 167,

		/// <summary>保存２</summary>
		SAVE2 = 168,

		/// <summary>候補</summary>
		CANDIDATE = 169,

		/// <summary>商談状況</summary>
		BUSINESSTALKSITUATION = 170,

		/// <summary>選択</summary>
		SELECT = 171,

		/// <summary>取引先企業１</summary>
		CUSTOMERCORP1 = 172,

		/// <summary>取引先企業２</summary>
		CUSTOMERCORP2 = 173,

		/// <summary>グリッド表示</summary>
		GRIDDISPLAY = 174,

		/// <summary>ＤＭ発行履歴</summary>
		DMRECORD = 175,

		/// <summary>履歴一覧表示</summary>
		RECORDLIST = 176,

		/// <summary>グリッドデータ取り込み</summary>
		GRIDDATACAPTURE = 177,

		/// <summary>最新に更新</summary>
		RENEWAL = 178,

		/// <summary>再計算</summary>
		RECALCULATION = 179,

		/// <summary>伝票に反映</summary>
		SLIPREFLECT = 180,

		/// <summary>曖昧検索</summary>
		AMBIGUOUSSEARCH = 181,

		/// <summary>バーコード入力</summary>
		BARCODEINPUT = 182,

		/// <summary>コース選択</summary>
		COURSESELECT = 183,

		/// <summary>後日整備取り込み</summary>
		LATERMAINTENANCETAKING = 184,

		/// <summary>ラインデータ取り込み</summary>
		LINEDATACAPTURE = 185,

		/// <summary>リサイクルパーツ</summary>
		RECYCLEPARTS = 186,

		/// <summary>部品重複チェック</summary>
		REPETITIONCHECK = 187,

		/// <summary>症状診断</summary>
		SYMPTOMDIAGNOSIS = 188,

		/// <summary>記録簿データ取り込み</summary>
		TALLYSHEETCAPTURE = 189,

		/// <summary>ＴＳＰデータ取り込み</summary>
		TSPCAPTURE = 190,

		/// <summary>動画</summary>
		VIDEO = 191
	}
	# endregion

	# region enum Size24_Index
	/// <summary>24×24サイズアイコンのインデックスの列挙型です。</summary>
	public enum Size24_Index : int
	{
		/// <summary>保存</summary>
		SAVE = 0,

		/// <summary>閉じる</summary>
		CLOSE = 1,

		/// <summary>削除</summary>
		DELETE = 2,

		/// <summary>復活</summary>
		REVIVAL = 3,

		/// <summary>設定１</summary>
		SETUP1 = 4,

		/// <summary>行挿入</summary>
		ROWINSERT = 5,

		/// <summary>行削除</summary>
		ROWDELETE = 6,

		/// <summary>行コピー</summary>
		ROWCOPY = 7,

		/// <summary>行切り取り</summary>
		ROWCUT = 8,

		/// <summary>行貼付</summary>
		ROWPASTE = 9,

		/// <summary>行集約</summary>
		ROWUNION = 10,

		/// <summary>確定</summary>
		DECISION = 11,

		/// <summary>拡大</summary>
		ZOOMUP = 12,

		/// <summary>縮小</summary>
		ZOOMDOWN = 13,

		/// <summary>作業</summary>
		WORK = 14,

		/// <summary>作業２</summary>
		WORK2 = 15,

		/// <summary>作業３</summary>
		WORK3 = 16,

		/// <summary>車両右向き</summary>
		CARRIGHT = 17,

		/// <summary>車両下向き</summary>
		CARBOTTOM = 18,

		/// <summary>車両後ろ向き</summary>
		CARFOLLOWING = 19,

		/// <summary>車両左向き</summary>
		CARLEFT = 20,

		/// <summary>車両上向き</summary>
		CARLATER = 21,

		/// <summary>車両前向き</summary>
		CARFRONT = 22,

		/// <summary>右矢印</summary>
		RIGHTARROW = 23,

		/// <summary>下矢印</summary>
		BUTTOMARROW = 24,

		/// <summary>左矢印</summary>
		LEFTARROW = 25,

		/// <summary>上矢印</summary>
		LATERARROW = 26,

		/// <summary>次へ</summary>
		NEXT = 27,

		/// <summary>前へ</summary>
		BEFORE = 28,

		/// <summary>脱着</summary>
		TOFP = 29,

		/// <summary>鈑金</summary>
		BODYREPAIR = 30,

		/// <summary>取替</summary>
		EXCHANGE = 31,

		/// <summary>コース選択</summary>
		COURSESELECT = 32,

		/// <summary>画像選択</summary>
		IMAGESELECT = 33,

		/// <summary>曖昧検索</summary>
		AMBIGUOUSSEARCH = 34,

		/// <summary>部位選択</summary>
		PARTSSELECT = 35,

		/// <summary>請求按分</summary>
		DEMANDPROP = 36,

		/// <summary>担当者按分</summary>
		EMPLOYEEPROP = 37,

		/// <summary>フォント</summary>
		FONT = 38,

		/// <summary>付帯作業展開</summary>
		ACCOMPANYINGWORKDEVELOPMENT = 39,

		/// <summary>インデント</summary>
		INDENT = 40,

		/// <summary>インデント解除</summary>
		INDENTRELEASE = 41,

		/// <summary>インナーパーツ一括削除</summary>
		INNERPARTSBATCHDELETE = 42,

		/// <summary>品番一括削除</summary>
		NUMBERBATCHDELETE = 43,

		/// <summary>品番表示</summary>
		NUMBERDISPLAY = 44,

		/// <summary>部品インデント</summary>
		PARTSINDENT = 45,

		/// <summary>部品・作業展開</summary>
		PARTSWORKDEVELOPMENT = 46,

		/// <summary>リサイクルパーツ</summary>
		RECYCLEPARTS = 47,

		/// <summary>部品重複チェック</summary>
		REPETITIONCHECK = 48,

		/// <summary>部品金額一括削除</summary>
		SUMBATCHDELETE = 49,

		/// <summary>再計算</summary>
		RECALCULATION = 50,

		/// <summary>バーコード入力</summary>
		BARCODEINPUT = 51,

		/// <summary>後日整備取込</summary>
		LATERMAINTENANCETAKING = 52,

		/// <summary>症状診断</summary>
		SYMPTOMDIAGNOSIS = 53,

		/// <summary>新規</summary>
		NEW = 54,

		/// <summary>修正</summary>
		MODIFY = 55,

		/// <summary>ラインデータ取り込み</summary>
		LINEDATACAPTURE = 56,

		/// <summary>点検</summary>
		CHECK = 57,

		/// <summary>調整</summary>
		ADJUST = 58,
		
		/// <summary>清掃</summary>
		CLEAN = 59,
		
		/// <summary>補充</summary>
		REPLENISHMENT = 60,
		
		/// <summary>分解</summary>
		RESOLUTION = 61,
		
		/// <summary>OH</summary>
		OH = 62,
		
		/// <summary>修理</summary>
		REPAIR = 63,
		
		/// <summary>測定</summary>
		MEASUREMENT = 64,
		
		/// <summary>組立</summary>
		STRUCTURE = 65,
		
		/// <summary>切断</summary>
		CUT = 66,
		
		/// <summary>値引</summary>
		DISCOUNT = 67,
		
		/// <summary>溶接</summary>
		WELD = 68,
		
		/// <summary>塗装</summary>
		LACQUERING = 69,
		
		/// <summary>クレーム</summary>
		COMPLAINT = 70,

        /// <summary>チェック</summary>
		ITEMCHECK = 71

	}
	# endregion

	# region enum Size16_Index
	/// <summary>16×16サイズアイコンのインデックスの列挙型です。</summary>
	public enum Size16_Index : int
	{
		/// <summary>閉じる</summary>
		CLOSE = 0,

		/// <summary>従業員（担当者）</summary>
		EMPLOYEE = 1,

		/// <summary>検索</summary>
		SEARCH = 2,

		/// <summary>ツリー</summary>
		TREE = 3,

		/// <summary>ビュー</summary>
		VIEW = 4,

		/// <summary>印刷</summary>
		PRINT = 5,

		/// <summary>削除</summary>
		DELETE = 6,

		/// <summary>新規</summary>
		NEW = 7,

		/// <summary>修正</summary>
		MODIFY = 8,

		/// <summary>詳細</summary>
		DETAILS = 9,

		/// <summary>中断</summary>
		INTERRUPTION = 10,

		/// <summary>再実行</summary>
		RETRY = 11,

		/// <summary>確定</summary>
		DECISION = 12,

		/// <summary>セキュリティ</summary>
		SECURITY = 13,

		/// <summary>全般</summary>
		GENERAL = 14,

		/// <summary>フォルダ</summary>
		FOLDER = 15,

		/// <summary>プレビュー</summary>
		PREVIEW = 16,

		/// <summary>前へ</summary>
		BEFORE = 17,

		/// <summary>次へ</summary>
		NEXT = 18,

		/// <summary>一括印刷</summary>
		PACKAGEPRINT = 19,

		/// <summary>拠点</summary>
		BASE = 20,

		/// <summary>帳票１</summary>
		LIST1 = 21,

		/// <summary>帳票２</summary>
		LIST2 = 22,

		/// <summary>帳票３</summary>
		LIST3 = 23,

		/// <summary>帳票４</summary>
		LIST4 = 24,

		/// <summary>メイン</summary>
		MAIN = 25,

		/// <summary>設定１</summary>
		SETUP1 = 26,

		/// <summary>本日</summary>
		TODAY = 27,

		/// <summary>星１</summary>
		STAR1 = 28,

		/// <summary>保存</summary>
		SAVE = 29,

		/// <summary>取り消し</summary>
		UNDO = 30,

		/// <summary>メーカー</summary>
		MAKER = 31,

		/// <summary>車種</summary>
		MODEL = 32,

		/// <summary>一括入力</summary>
		PACKAGEINPUT = 33,

		/// <summary>入力チェック</summary>
		INPUTCHECK = 34,
	
		/// <summary>全て選択</summary>
		ALLSELECT = 35,
	
		/// <summary>全て解除</summary>
		ALLCANCEL = 36,
	
		/// <summary>サブメニュー</summary>
		SUBMENU = 37,

		/// <summary>プレート番号</summary>
		NUMBERPLATE = 38,

		/// <summary>顧客</summary>
		CUSTOMER = 39,

		/// <summary>日付指定</summary>
		DATEAPPOINTMENT = 40,

		/// <summary>編集</summary>
		EDITING = 41,

		/// <summary>顧客入力１</summary>
		CUSTOMERINPUT1 = 42,

		/// <summary>顧客入力２</summary>
		CUSTOMERINPUT2 = 43,

		/// <summary>顧客削除</summary>
		CUSTOMERDELETE = 44,

		/// <summary>車両</summary>
		CAR = 45,

		/// <summary>車両入力１</summary>
		CARINPUT1 = 46,

		/// <summary>車両入力２</summary>
		CARINPUT2 = 47,

		/// <summary>車両入力３</summary>
		CARINPUT3 = 48,

		/// <summary>車両削除</summary>
		CARDELETE = 49,

		/// <summary>追加車両</summary>
		CARADD = 50,

		/// <summary>顧客新規</summary>
		CUSTOMERNEW = 51,

		/// <summary>普通自動車</summary>
		COMMONCAR = 52,

		/// <summary>軽自動車</summary>
		LIGHTCAR = 53,

		/// <summary>予約業務</summary>
		RESERVATION = 54,

		/// <summary>点検入力</summary>
		CARCHECK = 55,

		/// <summary>点検入力２</summary>
		CARCHECK2 = 56,

		/// <summary>明細入力</summary>
		DETAILS2 = 57,

		/// <summary>諸費用入力</summary>
		COST = 58,

		/// <summary>値引入力</summary>
		DISCOUNT = 59,

		/// <summary>集計</summary>
		TOTALING = 60,

		/// <summary>画像選択</summary>
		IMAGESELECT = 61,

		/// <summary>塗装</summary>
		PAINTING = 62,

		/// <summary>内板骨格</summary>
		FRAME = 63,

		/// <summary>作業</summary>
		WORK = 64,

		/// <summary>作業２</summary>
		WORK2 = 65,

		/// <summary>作業３</summary>
		WORK3 = 66,

		/// <summary>支払プラン</summary>
		CREDITPLAN = 67,

		/// <summary>部位選択</summary>
		PARTSSELECT = 68,

		/// <summary>行挿入</summary>
		ROWINSERT = 69,

		/// <summary>行削除</summary>
		ROWDELETE = 70,

		/// <summary>行コピー</summary>
		ROWCOPY = 71,

		/// <summary>行切り取り</summary>
		ROWCUT = 72,

		/// <summary>行貼付</summary>
		ROWPASTE = 73,

		/// <summary>行集約</summary>
		ROWUNION = 74,

		/// <summary>ガイド</summary>
		GUIDE = 75,

		/// <summary>次へ２</summary>
		NEXT2 = 76,

		/// <summary>前へ２</summary>
		BEFORE2 = 77,

		/// <summary>顧客検索</summary>
		CUSTOMERSEARCH = 78,

		/// <summary>車両検索</summary>
		CARSEARCH = 79,

		/// <summary>伝票検索</summary>
		SLIPSEARCH = 80,

		/// <summary>拡大</summary>
		ZOOMUP = 81,

		/// <summary>縮小</summary>
		ZOOMDOWN = 82,

		/// <summary>帳票５</summary>
		LIST5 = 83,

		/// <summary>帳票６</summary>
		LIST6 = 84,

		/// <summary>帳票７</summary>
		LIST7 = 85,

		/// <summary>帳票８</summary>
		LIST8 = 86,

		/// <summary>表示切替</summary>
		INDICATIONCHANGE = 87,

		/// <summary>フォルダ２</summary>
		FOLDER2 = 88,

		/// <summary>棒グラフ１</summary>
		BARGRAPH1 = 89,

		/// <summary>折れ線グラフ１</summary>
		LINEGRAPH1 = 90,

		/// <summary>円グラフ１</summary>
		PIECHART1 = 91,

		/// <summary>散布図１</summary>
		POINTCHART1 = 92,

		/// <summary>棒グラフ２</summary>
		BARGRAPH2 = 93,

		/// <summary>折れ線グラフ２</summary>
		LINEGRAPH2 = 94,

		/// <summary>円グラフ２</summary>
		PIECHART2 = 95,

		/// <summary>散布図２</summary>
		POINTCHART2 = 96,

		/// <summary>表示切替２</summary>
		INDICATIONCHANGE2 = 97,

		/// <summary>次へ３</summary>
		NEXT3 = 98,

		/// <summary>前３</summary>
		BEFORE3 = 99,

		/// <summary>装備</summary>
		EQUIPMENT = 100,

		/// <summary>ツール</summary>
		TOOL = 101,

		/// <summary>カレンダー</summary>
		CALENDAR = 102,

		/// <summary>カレンダー２</summary>
		CALENDAR2 = 103,

		/// <summary>カレンダー３</summary>
		CALENDAR3 = 104,

		/// <summary>カレンダー４</summary>
		CALENDAR4 = 105,

		/// <summary>カレンダー５</summary>
		CALENDAR5 = 106,

		/// <summary>車両備考</summary>
		CARNOTE = 107,

		/// <summary>車両履歴</summary>
		CARRECORD = 108,

		/// <summary>車両変更</summary>
		CARCHANGE = 109,

		/// <summary>損傷入力</summary>
		DAMAGESPACEINPUT = 110,

		/// <summary>ブロック選択</summary>
		BLOCKSELECT = 111,
	
		/// <summary>最高</summary>
		MAX = 112,
	
		/// <summary>伝票</summary>
		SLIP = 113,
	
		/// <summary>メール</summary>
		MAIL = 114,

		/// <summary>請求</summary>
		CLAIM = 115,
	
		/// <summary>顧客備考</summary>
		CUSTOMERNOTE = 116,
	
		/// <summary>家族</summary>
		FAMILY = 117,

		/// <summary>フリーメモ</summary>
		FREEMEMO = 118,

		/// <summary>車輌新規</summary>
		CARNEW = 119,

		/// <summary>移動</summary>
		MOVE = 120,

		/// <summary>ペン</summary>
		PEN = 121,

		/// <summary>テキスト</summary>
		TEXT = 122,

		/// <summary>矩形</summary>
		QUADRATURE = 123,

		/// <summary>矩形２</summary>
		QUADRATURE2 = 124,

		/// <summary>楕円</summary>
		ELLIPSE = 125,

		/// <summary>カラー</summary>
		COLOR = 126,

		/// <summary>画像</summary>
		IMAGE = 127,

		/// <summary>画像参照</summary>
		IMAGEVIEW = 128,

		/// <summary>ヘッダー</summary>
		HEADER = 129,

		/// <summary>フッター</summary>
		FOOTER = 130,

		/// <summary>明細行</summary>
		ROW = 131,

		/// <summary>明細列</summary>
		COL = 132,

		/// <summary>余白</summary>
		MARGIN = 133,

		/// <summary>フォント</summary>
		FONT = 134,

		/// <summary>ボディ寸法</summary>
		BODYSIZE = 135,

		/// <summary>マニュアル</summary>
		MANUAL = 136,

		/// <summary>車両仕入</summary>
		CARPURCHASES = 137,

		/// <summary>得意先履歴</summary>
		CUSTOMERRECORD = 138,

		/// <summary>メーカー２</summary>
		MAKER2 = 139,

		/// <summary>メーカー３</summary>
		MAKER3 = 140,

		/// <summary>メーカー４</summary>
		MAKER4 = 141,

		/// <summary>メーカー５</summary>
		MAKER5 = 142,

		/// <summary>メーカー６</summary>
		MAKER6 = 143,

		/// <summary>メーカー７</summary>
		MAKER7 = 144,

		/// <summary>メーカー８</summary>
		MAKER8 = 145,

		/// <summary>行追加</summary>
		ROWADD = 146,

		/// <summary>印字</summary>
		PRINTOUT = 147,

		/// <summary>非印字</summary>
		NOTPRINTOUT = 148,

		/// <summary>赤伝</summary>
		DEBITNOTE = 149,

		/// <summary>請求按分</summary>
		DEMANDPROP = 150,

		/// <summary>はがき</summary>
		POSTCARD = 151,

		/// <summary>ラベル</summary>
		LABEL = 152,

		/// <summary>ダウンロード</summary>
		DOWNLOAD = 153,

		/// <summary>印刷停止</summary>
		STOPPRINTOUT = 154,

		/// <summary>DM発行</summary>
		DM = 155,

		/// <summary>保険</summary>
		INSURANCE = 156,

		/// <summary>リサイクル</summary>
		RECYCLE = 157,

		/// <summary>ＣＳＶ取込</summary>
		CSVTAKING = 158,

		/// <summary>ＣＳＶ出力</summary>
		CSVOUTPUT = 159,

		/// <summary>ブラウザ起動</summary>
		BLOUZER = 160,

		/// <summary>コース選択</summary>
		COURCESELECT = 161,

		/// <summary>登録名義人</summary>
		REGISTRATIONNOMINEE = 162,

		/// <summary>ガントチャート</summary>
		GANTCHART = 163,

		/// <summary>赤伝</summary>
		REDSLIP = 164,

		/// <summary>赤黒伝票</summary>
		REDBLACKSLIP = 165,

		/// <summary>伝票コピー</summary>
		SLIPCOPY = 166,

		/// <summary>サンプル</summary>
		SAMPLE = 167,

		/// <summary>保存２</summary>
		SAVE2 = 168,

		/// <summary>候補</summary>
		CANDIDATE = 169,

		/// <summary>商談状況</summary>
		BUSINESSTALKSITUATION = 170,

		/// <summary>選択</summary>
		SELECT = 171,

		/// <summary>取引先企業１</summary>
		CUSTOMERCORP1 = 172,

		/// <summary>取引先企業２</summary>
		CUSTOMERCORP2 = 173,

		/// <summary>グリッド表示</summary>
		GRIDDISPLAY = 174,

		/// <summary>ＤＭ発行履歴</summary>
		DMRECORD = 175,

		/// <summary>履歴一覧表示</summary>
		RECORDLIST = 176,

		/// <summary>グリッドデータ取り込み</summary>
		GRIDDATACAPTURE = 177,

		/// <summary>最新に更新</summary>
		RENEWAL = 178,

		/// <summary>再計算</summary>
		RECALCULATION = 179,

		/// <summary>伝票に反映</summary>
		SLIPREFLECT = 180,

		/// <summary>画像伝送</summary>
		SENDIMAGE = 192
	}
	# endregion
}

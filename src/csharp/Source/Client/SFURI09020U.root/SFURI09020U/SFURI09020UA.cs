using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �`�[����ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �`�[����ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
	/// <br>Programmer	: 23006  ���� ���q</br>
	/// <br>Date		: 2005.08.31</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>			    �E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>				�E��ƃR�[�h�擾����</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.16  23006 ���� ���q</br>
	/// <br>				 �E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.24  23006 ���� ���q</br>
	/// <br>				 �EColorDialog�@�\�̒ǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.24  23006 ���� ���q</br>
	/// <br>				 �ETMsgDisp���i�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.29  23006 ���� ���q</br>
	/// <br>				 �EtEdit_Leave�C�x���g�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.14  23006 ���� ���q</br>
	/// <br>				 �E��ʐ���Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>				 �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br>                 �EUltraFontNameEditor����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.11.11  23006 ���� ���q</br>
	/// <br>                 �E�Q�ƌ^�R���{�{�b�N�X�u�폜�ρv�\���Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.05  23006 ���� ���q</br>
	/// <br>                 �E�e�}�X�^���f�����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.24  22024 ���� �_�u</br>
	/// <br>				�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.25  22024 ���� �_�u</br>
	/// <br>				�E�`�[�R�����g��\���ɕύX</br>
	/// <br>				�E�o�͊m�F���b�Z�[�W��\���ɕύX</br>
	/// <br>				�E�`�[������[ID���\���ɕύX</br>2006.01.30 UENO
    /// <br></br>
	/// <br>Update Note : 2006.01.30 23002 ���@�k��</br>
	/// <br>				�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�</br>
    /// <br></br>
	/// <br>Update Note : 2006.02.08 23002 ���@�k��</br>
	/// <br>				�E���ږ��̕ύX�F�t�H���g�T�C�Y�˕����̃T�C�Y</br>
	/// <br>				�E���ږ��̕ύX�F�X�^�C���@�@�@�˕����̑���</br>
	/// <br>				�E�R���{���e���̕ύX�F�����ˑ���</br>
	/// <br></br>
	/// <br>Update Note : 2006.05.09  22024 ���� �_�u</br>
	/// <br>				�E���ږ��̕ύX�F�t�H���g���́˃t�H���g</br>
	/// <br></br>
	/// <br>Update Note : 2006.06.21  22024 ���� �_�u</br>
	/// <br>				�E��ʂ��I�u�V�����R�[�h�����폜</br>
    /// <br></br>
    /// <br>Update Note : 2006.09.11  23006 ���� ���q</br>
    /// <br>                 �E�o�[�R�[�h�I�v�V�����Ή�</br>
    /// <br>Update Note : 2007.04.02  20031 �É�@���S��</br>
    /// <br>              �]�����ڂ����������𒴂��ēo�^�ł��Ă��܂���Q���C��</br>
	/// <br>Update Note : 2007.12.17  30167 ���@�O�M</br>
	/// <br>              DC.NS�Ή�</br>
	/// <br>Update Note : 2008.01.25  30167 ���@�O�M</br>
	/// <br>              �^�u����C��</br>
	/// <br>Update Note : 2008.03.17  30167 ���@�O�M</br>
	/// <br>              �E�f�[�^���̓V�X�e�����\��</br>
    /// <br>Update Note : 2008.06.05  30413 ����</br>
    /// <br>              �EPM.NS�Ή�</br>
    /// <br>Update Note : 2008.11.14  30365 �{��</br>
    /// <br>              �EQR�R�[�h����敪�ύX</br>
    /// <br>Update Note : 2009.01.30  30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�10570(���׍s����K�{���ڂɕύX)</br>
    /// <br></br>
    /// <br>Update Note : 2009/10/02  21024 ���X�� ��</br>
    /// <br>              �E�]����1/10�~���ݒ�ł���悤�ɏC��(MANTIS[0014203])</br>
    /// <br>Update Note : 2009/12/31  ���M</br>
    /// <br>              �E PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>              �E �`�[���l�����A�`�[���l�Q�����A�`�[���l�R������ǉ��Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2010/07/06 30517 �Ė� �x��</br>
    /// <br>              �E QR�R�[�h�g�у��[���Ή�</br>
    /// <br>Update Note : 2010/08/06  caowj</br>
    /// <br>              �E PM.NS1012</br>
    /// <br>              �E �`�[�������ݐݒ�Ή�</br>
    /// <br>Update Note : 2010/08/17 �k���r #12932�Ή�</br>
    /// <br>Update Note : 2011/02/16  ���N�n��</br>
    /// <br>              �E ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
    /// <br>Update Note : 2011/07/19  chenyd</br>
    /// <br>              �E �񓚋敪�ǉ��̑Ή�</br>
    /// <br>Update Note  :2011/08/08  �����g</br>
    /// <br>               ��Q�� #23459: SCM�I�v�V�����R�[�h�𗘗p</br>
    /// <br>Update Note : 2011/08/11  zhubj</br>
    /// <br>              �E �u�ʏ�}�[�N�v�u�蓮�񓚁v�u�����񓚃}�[�N�v�G�f�b�g�������Ή�</br>
    /// <br>              �E �u����v�{�^���ŏI�������A�ۑ��m�F�_�C�A���O���\���Ή�</br>
    /// <br>Update Note : 2011/08/09  ���юR</br>
    /// <br>              �E �A��922 �`�[����p�^�[���ݒ�ŁA���l�������o�C�g���Z�ɕύX�̑Ή�</br>
    /// <br>Update Note : 2011/08/31 �����</br>
    /// <br>              Redmine#24110 �݌Ɉړ��`�[�̔��l�̌���������ǉ�����</br>
    /// <br>Update Note : 2011/09/06 wangf</br>
    /// <br>              Redmine#24449 �ۑ��������s���i�N���b�N���AAlt+S���j�A�������`���b�N��񍐂���</br>
    /// <br>Update Note  :2011/09/27  22018 ��� ���b</br>
    /// <br>              �ESCM�I�v�V����=ON�̏ꍇ�A�N�����ɃG���[����������̂ŏC���B</br>
    /// </remarks>
	public class SFURI09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl MainTabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel CopyCount_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel RightMargin_uLabel;
		private Infragistics.Win.Misc.UltraLabel BottomMargin_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabe11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel TopMarging_uLabel;
		private Infragistics.Win.Misc.UltraLabel LeftMarging_uLabel;
        private Infragistics.Win.Misc.UltraLabel SlipPrtKind_uLabel;
		private Infragistics.Win.Misc.UltraLabel SlipFontSize_uLabel;
        private Infragistics.Win.Misc.UltraLabel PrtCirculation_uLabel;
		private Infragistics.Win.Misc.UltraLabel EnterpriseNamePrtCd_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel OutConMsg_uLabel;
        private Infragistics.Win.Misc.UltraLabel DataInputSystem_uLabel;
		private Infragistics.Win.Misc.UltraLabel PrtPreviewExistCode_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Broadleaf.Library.Windows.Forms.TNedit PrtCirculation_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit SlipPrtSetPaperId_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit OutputPgClassId_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit OutputPgId_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit OutputFormFileName_tEdit;
		private Infragistics.Win.Misc.UltraLabel OutputPgClassId_uLabel;
		private Infragistics.Win.Misc.UltraLabel OutputPgId_uLabel;
		private Infragistics.Win.Misc.UltraLabel OutputFormFileName_ulabel;
		private Infragistics.Win.Misc.UltraButton ImageColorGuide5_uButton;
		private Infragistics.Win.Misc.UltraLabel SlipBaseColor5_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName4_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName1_tEdit;
		private Infragistics.Win.Misc.UltraLabel TitleName_uLabel;
		private Infragistics.Win.Misc.UltraButton ImageColorGuide4_uButton;
		private Infragistics.Win.Misc.UltraLabel SlipBaseColor4_uLabel;
		private Infragistics.Win.Misc.UltraButton ImageColorGuide3_uButton;
		private Infragistics.Win.Misc.UltraLabel SlipBaseColor3_uLabel;
		private Infragistics.Win.Misc.UltraButton ImageColorGuide2_uButton;
		private Infragistics.Win.Misc.UltraLabel SlipBaseColor2_uLabel;
		private Infragistics.Win.Misc.UltraButton ImageColorGuide1_uButton;
		private Infragistics.Win.Misc.UltraLabel SlipBaseColor1_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
		private System.Windows.Forms.Timer timer;
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.FontDialog FontDialog;
		private System.Windows.Forms.ColorDialog ColorDialogForm;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName102_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName103_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName104_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName105_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName202_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName203_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName204_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName205_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName302_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName303_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName304_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName305_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName402_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName403_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName404_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TitleName405_tEdit;
		private Broadleaf.Library.Windows.Forms.TComboEditor EnterpriseNamePrtCd_tComEditor;
        private Broadleaf.Library.Windows.Forms.TComboEditor PrtPreviewExistCode_tComEditor;
		private Broadleaf.Library.Windows.Forms.TEdit SlipComment_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit OutConMsg_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit TopMarging_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit LeftMarging_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit RightMargin_tNedit;
        private Broadleaf.Library.Windows.Forms.TNedit BottomMargin_tNedit;
        private Broadleaf.Library.Windows.Forms.TComboEditor SlipFontSize_tComEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor CopyCount_tComboEditor;
		private Infragistics.Win.UltraWinGrid.UltraGrid eachSlipTypeCol_ultraGrid;
		private Infragistics.Win.Misc.UltraLabel ultraLabel22;
		private Infragistics.Win.Misc.UltraLabel ultraLabel23;
		private Infragistics.Win.Misc.UltraLabel ultraLabel24;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.Misc.UltraLabel ultraLabel27;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
		private Infragistics.Win.Misc.UltraLabel ultraLabel28;
		private Infragistics.Win.Misc.UltraLabel ultraLabel29;
		private Infragistics.Win.Misc.UltraLabel ultraLabel30;
		private Infragistics.Win.Misc.UltraLabel ultraLabel31;
		private Infragistics.Win.Misc.UltraLabel ultraLabel32;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private Infragistics.Win.Misc.UltraLabel ultraLabel33;
		private Infragistics.Win.Misc.UltraLabel ultraLabel34;
		private Infragistics.Win.Misc.UltraLabel ultraLabel35;
		private Infragistics.Win.Misc.UltraLabel ultraLabel36;
		private Infragistics.Win.Misc.UltraLabel ultraLabel37;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel38;
		private Infragistics.Win.Misc.UltraLabel ultraLabel39;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Infragistics.Win.Misc.UltraLabel ultraLabel41;
		private Infragistics.Win.Misc.UltraLabel ultraLabel42;
		private Infragistics.Win.Misc.UltraButton UpButton;
		private Infragistics.Win.Misc.UltraButton DownButton;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private UltraLabel SlipPrtSetPaperId_uLabel;
		private UltraLabel Rank_uLabel;
		private UltraButton Delete_Button;
		private UltraButton Revive_Button;
		private TEdit SlipPrtKindNm_tEdit;
		private TEdit DataInputSystemNm_tEdit;
		private UltraLabel ultraLabel15;
		private UltraLabel ultraLabel14;
		private UltraLabel ultraLabel1222;
		private UltraLabel SpecialPurpose1_uLabel;
		private TEdit SpecialPurpose1_tEdit;
		private TEdit SpecialPurpose4_tEdit;
		private TEdit SpecialPurpose3_tEdit;
		private TEdit SpecialPurpose2_tEdit;
		private TNedit DataInputSystem_tNedit;
		private TNedit SlipPrtKind_tNedit;
        private UltraLabel Note2_uLabel;
        private UltraLabel Note1_uLabel;
        private UltraLabel RefConsTaxPrtNm_uLabel;
        private UltraLabel RefConsTaxDivCd_uLabel;
        private UltraLabel ReissueMark_uLabel;
        private TEdit Note1_tEdit;
        private TEdit RefConsTaxPrtNm_tEdit;
        private TEdit ReissueMark_tEdit;
        private TComboEditor RefConsTaxDivCd_tComboEditor;
        private TEdit Note3_tEdit;
        private TEdit Note2_tEdit;
        private UltraLabel Note3_uLabel;
        private TComboEditor TimePrintDivCd_tComboEditor;
        private TComboEditor QRCodePrintDivCd_tComboEditor;
        private UltraLabel TimePrintDivCd_uLabel;
        private UltraLabel QRCodePrintDivCd_uLabel;
        private TNedit DetailRowCount_tNedit;
        private UltraLabel HonorificTitle_uLabel;
        private UltraLabel DetailRowCount_uLabel;
        private UltraLabel ultraLabel21;
        private TEdit HonorificTitle_tEdit;
        private TComboEditor ConsTaxPrtCd_tComboEditor;
        private UltraLabel ConsTaxPrtCd_uLabel;
        private TNedit SlipNoteCharCnt_tNedit;
        private UltraLabel SlipNoteCharCnt_uLabel;
        private TNedit SlipNote3CharCnt_tNedit;
        private UltraLabel SlipNote3CharCnt_uLabel;
        private TNedit SlipNote2CharCnt_tNedit;
        private UltraLabel SlipNote2CharCnt_uLabel;
        private UltraLabel ultraLabel45;
        private UltraLabel ultraLabel44;
        private UltraLabel ultraLabel43;
        private UiSetControl uiSetControl1;
        private UltraLabel CustomerCode_uLabel;
        private TNedit CustomerCode_tNedit;
        private UltraLabel CustomerName_uLabel;
        private UltraButton CustomerGuide_uButton;
        private TComboEditor EntNmPrtExpDiv_tComEditor;
        private UltraLabel EntNmPrtExpDiv_uLabel;
        private TEdit SCMAutoAnsMark_tEdit;
        private UltraLabel ultraLabel47;
        private TEdit SCMManualAnsMark_tEdit;
        private UltraLabel ultraLabel20;
        private UltraLabel ultraLabel46;
        private TEdit NormalPrtMark_tEdit;
        private TComboEditor SCMAnsMarkPrtDiv_tComboEditor;
        private UltraLabel ultraLabel19;
		private System.ComponentModel.IContainer components;
		#endregion

		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �`�[����ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.08.31</br>
		/// </remarks>
		public SFURI09020UA()
		{
			InitializeComponent();

			_bindTable = new DataTable(MY_SCREEN_TABLE);
			// DataSet����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = true;
			//----- h.ueno upd---------- start 2007.12.17
			this._canNew = true;
			this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
			//----- h.ueno upd---------- end   2007.12.17
			this._defaultAutoFillToColumn = false;
			this._canSpecificationSearch = false;

            // --- ADD 2010/08/06 ----------------------------------------------->>>>>
            this.CustomerGuide_uButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2010/08/06 -----------------------------------------------<<<<<

			// ��ƃR�[�h���擾
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// �ϐ�������
			this._dataIndex      = -1;
			this._slipPrtSetAcs  = new SlipPrtSetAcs();

			//----- h.ueno del---------- start 2007.12.17
			//this._prevSlipPrtSet = null;
			//this._nextData       = false;
			//----- h.ueno del---------- end   2007.12.17

			this._totalCount     = 0;
			// ViewGrid�pHashTable
			this._slipPrtSetTable = new Hashtable();

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			this.colorRed1 = 0;
			this.colorRed2 = 0;
			this.colorRed3 = 0;
			this.colorRed4 = 0;
			this.colorRed5 = 0;

			this.colorGreen1 = 0;
			this.colorGreen2 = 0;
			this.colorGreen3 = 0;
			this.colorGreen4 = 0;
			this.colorGreen5 = 0;
            
			this.colorBlue1 = 0;
			this.colorBlue2 = 0;
			this.colorBlue3 = 0;
			this.colorBlue4 = 0;
			this.colorBlue5 = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

			// _dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.19 TAKAHASHI ADD START
			// SlipFontName_uFontNameEditor����p
			this._ultraFontNameEditorFlg = false;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.19 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI ADD START
			// �v�����^�Ǘ�No.�擾�p
			this._prtManageAcs = new PrtManageAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI ADD END

			//----- h.ueno del---------- start 2007.12.17
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.11 TAKAHASHI ADD START
			//// �o�[�R�[�h�I�v�V����Flg
			//if ((LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeInput)
			//    == PurchaseStatus.Contract) || 
			//    (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeInput)
			//    == PurchaseStatus.Trial_Contract))
			//{
			//    this._barCodeOPFlg = true;
			//}
			//else
			//{
			//    this._barCodeOPFlg = false;
			//}
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.11 TAKAHASHI ADD END
			//----- h.ueno del---------- end   2007.12.17

            // 2010/07/06 Add >>>
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_QRMail) == PurchaseStatus.Contract)
            {
                this._QRMailOPFlg = true;
            }
            else
            {
                this._QRMailOPFlg = false;
            }
            // 2010/07/06 Add <<<

            // 2011/07/19 Add >>>
            // �o�b�b�I�v�V����
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC) == PurchaseStatus.Contract)//DEL 2011/08/08
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) == PurchaseStatus.Contract)// ADD 2011/08/08
            {
                this._PCCOPFlg = true;
            }
            else
            {
                this._PCCOPFlg = false;

            }
            // 2011/07/19 Add <<<

			
		}
		#endregion

		/*----------------------------------------------------------------------------------*/
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

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance204 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance213 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance214 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�̐ݒ�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�̐ݒ�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�̐ݒ�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�̐ݒ�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�F�̐ݒ�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFURI09020UA));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.EntNmPrtExpDiv_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EntNmPrtExpDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerGuide_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel45 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel43 = new Infragistics.Win.Misc.UltraLabel();
            this.SlipNote3CharCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SlipNote3CharCnt_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipNote2CharCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SlipNote2CharCnt_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipNoteCharCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SlipNoteCharCnt_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.HonorificTitle_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RefConsTaxPrtNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ReissueMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SlipPrtKind_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DataInputSystem_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SpecialPurpose4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SpecialPurpose3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SpecialPurpose2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SpecialPurpose1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1222 = new Infragistics.Win.Misc.UltraLabel();
            this.SpecialPurpose1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipPrtKindNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DataInputSystemNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Rank_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipPrtSetPaperId_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DownButton = new Infragistics.Win.Misc.UltraButton();
            this.UpButton = new Infragistics.Win.Misc.UltraButton();
            this.eachSlipTypeCol_ultraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.CopyCount_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SlipFontSize_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BottomMargin_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.RightMargin_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.LeftMarging_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TopMarging_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.OutConMsg_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SlipComment_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrtPreviewExistCode_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.TimePrintDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.QRCodePrintDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ConsTaxPrtCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RefConsTaxDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EnterpriseNamePrtCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SlipPrtSetPaperId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OutputPgClassId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OutputPgId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OutputFormFileName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OutputPgClassId_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OutputPgId_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OutputFormFileName_ulabel = new Infragistics.Win.Misc.UltraLabel();
            this.ImageColorGuide5_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SlipBaseColor5_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.DetailRowCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrtCirculation_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.HonorificTitle_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CopyCount_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.RightMargin_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BottomMargin_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabe11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.TopMarging_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.LeftMarging_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipPrtKind_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SlipFontSize_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DetailRowCount_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrtCirculation_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RefConsTaxPrtNm_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.TimePrintDivCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.QRCodePrintDivCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxPrtCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RefConsTaxDivCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ReissueMark_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.EnterpriseNamePrtCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.OutConMsg_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DataInputSystem_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrtPreviewExistCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.TitleName405_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName404_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName403_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName402_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName305_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName304_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName303_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName302_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.TitleName205_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName204_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName203_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName202_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName105_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName104_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName103_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName102_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.TitleName4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TitleName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ImageColorGuide4_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SlipBaseColor4_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ImageColorGuide3_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SlipBaseColor3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ImageColorGuide2_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SlipBaseColor2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ImageColorGuide1_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SlipBaseColor1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.MainTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.ColorDialogForm = new System.Windows.Forms.ColorDialog();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SCMAnsMarkPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.SCMAutoAnsMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.SCMManualAnsMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.NormalPrtMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntNmPrtExpDiv_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3CharCnt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2CharCnt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNoteCharCnt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HonorificTitle_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefConsTaxPrtNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReissueMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtKind_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataInputSystem_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtKindNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataInputSystemNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eachSlipTypeCol_ultraGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopyCount_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipFontSize_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomMargin_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMargin_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMarging_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopMarging_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutConMsg_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipComment_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePrintDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePrintDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrtCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefConsTaxDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseNamePrtCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtSetPaperId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPgClassId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPgId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputFormFileName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailRowCount_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtCirculation_tNedit)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName405_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName404_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName403_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName402_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName305_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName304_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName303_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName302_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName205_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName204_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName203_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName202_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName105_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName104_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName103_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName102_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).BeginInit();
            this.MainTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMAnsMarkPrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMAutoAnsMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMManualAnsMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPrtMark_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.SCMAutoAnsMark_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel47);
            this.ultraTabPageControl1.Controls.Add(this.SCMManualAnsMark_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel20);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel46);
            this.ultraTabPageControl1.Controls.Add(this.NormalPrtMark_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SCMAnsMarkPrtDiv_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel19);
            this.ultraTabPageControl1.Controls.Add(this.EntNmPrtExpDiv_tComEditor);
            this.ultraTabPageControl1.Controls.Add(this.EntNmPrtExpDiv_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.CustomerCode_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.CustomerName_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.CustomerGuide_uButton);
            this.ultraTabPageControl1.Controls.Add(this.CustomerCode_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel45);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel44);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel43);
            this.ultraTabPageControl1.Controls.Add(this.SlipNote3CharCnt_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.SlipNote3CharCnt_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipNote2CharCnt_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.SlipNote2CharCnt_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipNoteCharCnt_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.SlipNoteCharCnt_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.Note3_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.Note2_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.Note1_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.HonorificTitle_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.RefConsTaxPrtNm_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.ReissueMark_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SlipPrtKind_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.DataInputSystem_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.SpecialPurpose4_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SpecialPurpose3_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SpecialPurpose2_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SpecialPurpose1_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel15);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel14);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1222);
            this.ultraTabPageControl1.Controls.Add(this.SpecialPurpose1_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipPrtKindNm_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.DataInputSystemNm_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.Rank_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipPrtSetPaperId_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.DownButton);
            this.ultraTabPageControl1.Controls.Add(this.UpButton);
            this.ultraTabPageControl1.Controls.Add(this.eachSlipTypeCol_ultraGrid);
            this.ultraTabPageControl1.Controls.Add(this.CopyCount_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.SlipFontSize_tComEditor);
            this.ultraTabPageControl1.Controls.Add(this.BottomMargin_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.RightMargin_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.LeftMarging_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.TopMarging_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.OutConMsg_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.SlipComment_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.PrtPreviewExistCode_tComEditor);
            this.ultraTabPageControl1.Controls.Add(this.TimePrintDivCd_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.QRCodePrintDivCd_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.ConsTaxPrtCd_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.RefConsTaxDivCd_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.EnterpriseNamePrtCd_tComEditor);
            this.ultraTabPageControl1.Controls.Add(this.SlipPrtSetPaperId_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.OutputPgClassId_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.OutputPgId_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.OutputFormFileName_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.OutputPgClassId_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.OutputPgId_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.OutputFormFileName_ulabel);
            this.ultraTabPageControl1.Controls.Add(this.ImageColorGuide5_uButton);
            this.ultraTabPageControl1.Controls.Add(this.SlipBaseColor5_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel11);
            this.ultraTabPageControl1.Controls.Add(this.DetailRowCount_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.PrtCirculation_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel4);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel13);
            this.ultraTabPageControl1.Controls.Add(this.HonorificTitle_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.CopyCount_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel6);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel5);
            this.ultraTabPageControl1.Controls.Add(this.RightMargin_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.BottomMargin_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel12);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabe11);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel3);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl1.Controls.Add(this.TopMarging_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.LeftMarging_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipPrtKind_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.SlipFontSize_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.DetailRowCount_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.PrtCirculation_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.Note3_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.Note2_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.Note1_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.RefConsTaxPrtNm_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.TimePrintDivCd_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.QRCodePrintDivCd_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ConsTaxPrtCd_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.RefConsTaxDivCd_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ReissueMark_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.EnterpriseNamePrtCd_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel21);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl1.Controls.Add(this.OutConMsg_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.DataInputSystem_uLabel);
            this.ultraTabPageControl1.Controls.Add(this.PrtPreviewExistCode_uLabel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 21);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(949, 664);
            // 
            // EntNmPrtExpDiv_tComEditor
            // 
            appearance183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance183.ForeColor = System.Drawing.Color.Black;
            this.EntNmPrtExpDiv_tComEditor.ActiveAppearance = appearance183;
            appearance184.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance184.ForeColor = System.Drawing.Color.Black;
            appearance184.ForeColorDisabled = System.Drawing.Color.Black;
            appearance184.TextVAlignAsString = "Middle";
            this.EntNmPrtExpDiv_tComEditor.Appearance = appearance184;
            this.EntNmPrtExpDiv_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EntNmPrtExpDiv_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance185.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EntNmPrtExpDiv_tComEditor.ItemAppearance = appearance185;
            this.EntNmPrtExpDiv_tComEditor.Location = new System.Drawing.Point(176, 172);
            this.EntNmPrtExpDiv_tComEditor.Name = "EntNmPrtExpDiv_tComEditor";
            this.EntNmPrtExpDiv_tComEditor.Size = new System.Drawing.Size(68, 24);
            this.EntNmPrtExpDiv_tComEditor.TabIndex = 10;
            // 
            // EntNmPrtExpDiv_uLabel
            // 
            appearance78.TextVAlignAsString = "Middle";
            this.EntNmPrtExpDiv_uLabel.Appearance = appearance78;
            this.EntNmPrtExpDiv_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EntNmPrtExpDiv_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EntNmPrtExpDiv_uLabel.Location = new System.Drawing.Point(20, 172);
            this.EntNmPrtExpDiv_uLabel.Name = "EntNmPrtExpDiv_uLabel";
            this.EntNmPrtExpDiv_uLabel.Size = new System.Drawing.Size(100, 23);
            this.EntNmPrtExpDiv_uLabel.TabIndex = 12;
            this.EntNmPrtExpDiv_uLabel.Text = "���Ж���";
            // 
            // CustomerCode_tNedit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance30.TextHAlignAsString = "Right";
            this.CustomerCode_tNedit.ActiveAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            this.CustomerCode_tNedit.Appearance = appearance31;
            this.CustomerCode_tNedit.AutoSelect = true;
            this.CustomerCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CustomerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode_tNedit.DataText = "";
            this.CustomerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CustomerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CustomerCode_tNedit.Location = new System.Drawing.Point(176, 73);
            this.CustomerCode_tNedit.MaxLength = 8;
            this.CustomerCode_tNedit.Name = "CustomerCode_tNedit";
            this.CustomerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CustomerCode_tNedit.Size = new System.Drawing.Size(76, 24);
            this.CustomerCode_tNedit.TabIndex = 6;
            this.CustomerCode_tNedit.Leave += new System.EventHandler(this.CustomerCode_tNedit_Leave);
            this.CustomerCode_tNedit.Enter += new System.EventHandler(this.CustomerCode_tNedit_Enter);
            // 
            // CustomerName_uLabel
            // 
            appearance32.BackColor = System.Drawing.SystemColors.Control;
            appearance32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.CustomerName_uLabel.Appearance = appearance32;
            this.CustomerName_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.CustomerName_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName_uLabel.Location = new System.Drawing.Point(284, 74);
            this.CustomerName_uLabel.Name = "CustomerName_uLabel";
            this.CustomerName_uLabel.Size = new System.Drawing.Size(224, 23);
            this.CustomerName_uLabel.TabIndex = 6;
            this.CustomerName_uLabel.WrapText = false;
            // 
            // CustomerGuide_uButton
            // 
            appearance33.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance33.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.CustomerGuide_uButton.Appearance = appearance33;
            this.CustomerGuide_uButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerGuide_uButton.Location = new System.Drawing.Point(258, 73);
            this.CustomerGuide_uButton.Name = "CustomerGuide_uButton";
            this.CustomerGuide_uButton.Size = new System.Drawing.Size(24, 24);
            this.CustomerGuide_uButton.TabIndex = 7;
            this.CustomerGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_uButton.Click += new System.EventHandler(this.CustomerGuide_uButton_Click);
            // 
            // CustomerCode_uLabel
            // 
            appearance94.TextVAlignAsString = "Middle";
            this.CustomerCode_uLabel.Appearance = appearance94;
            this.CustomerCode_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCode_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerCode_uLabel.Location = new System.Drawing.Point(20, 73);
            this.CustomerCode_uLabel.Name = "CustomerCode_uLabel";
            this.CustomerCode_uLabel.Size = new System.Drawing.Size(150, 23);
            this.CustomerCode_uLabel.TabIndex = 98;
            this.CustomerCode_uLabel.Text = "���Ӑ�R�[�h";
            // 
            // ultraLabel45
            // 
            appearance93.TextVAlignAsString = "Middle";
            this.ultraLabel45.Appearance = appearance93;
            this.ultraLabel45.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel45.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel45.Location = new System.Drawing.Point(710, 376);
            this.ultraLabel45.Name = "ultraLabel45";
            this.ultraLabel45.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel45.TabIndex = 97;
            this.ultraLabel45.Text = "�S�p������";
            // 
            // ultraLabel44
            // 
            appearance200.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance200;
            this.ultraLabel44.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel44.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel44.Location = new System.Drawing.Point(710, 347);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel44.TabIndex = 96;
            this.ultraLabel44.Text = "�S�p������";
            // 
            // ultraLabel43
            // 
            appearance201.TextVAlignAsString = "Middle";
            this.ultraLabel43.Appearance = appearance201;
            this.ultraLabel43.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel43.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel43.Location = new System.Drawing.Point(710, 318);
            this.ultraLabel43.Name = "ultraLabel43";
            this.ultraLabel43.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel43.TabIndex = 95;
            this.ultraLabel43.Text = "�S�p������";
            // 
            // SlipNote3CharCnt_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            this.SlipNote3CharCnt_tNedit.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextHAlignAsString = "Right";
            appearance41.TextVAlignAsString = "Middle";
            this.SlipNote3CharCnt_tNedit.Appearance = appearance41;
            this.SlipNote3CharCnt_tNedit.AutoSelect = true;
            this.SlipNote3CharCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SlipNote3CharCnt_tNedit.DataText = "";
            this.SlipNote3CharCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipNote3CharCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SlipNote3CharCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipNote3CharCnt_tNedit.Location = new System.Drawing.Point(668, 375);
            this.SlipNote3CharCnt_tNedit.MaxLength = 2;
            this.SlipNote3CharCnt_tNedit.Name = "SlipNote3CharCnt_tNedit";
            this.SlipNote3CharCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SlipNote3CharCnt_tNedit.Size = new System.Drawing.Size(28, 24);
            this.SlipNote3CharCnt_tNedit.TabIndex = 31;
            // 
            // SlipNote3CharCnt_uLabel
            // 
            appearance82.TextVAlignAsString = "Middle";
            this.SlipNote3CharCnt_uLabel.Appearance = appearance82;
            this.SlipNote3CharCnt_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipNote3CharCnt_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipNote3CharCnt_uLabel.Location = new System.Drawing.Point(542, 375);
            this.SlipNote3CharCnt_uLabel.Name = "SlipNote3CharCnt_uLabel";
            this.SlipNote3CharCnt_uLabel.Size = new System.Drawing.Size(123, 23);
            this.SlipNote3CharCnt_uLabel.TabIndex = 94;
            this.SlipNote3CharCnt_uLabel.Text = "�`�[���l�R����";
            // 
            // SlipNote2CharCnt_tNedit
            // 
            appearance204.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance204.ForeColor = System.Drawing.Color.Black;
            appearance204.TextHAlignAsString = "Right";
            this.SlipNote2CharCnt_tNedit.ActiveAppearance = appearance204;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            appearance35.TextVAlignAsString = "Middle";
            this.SlipNote2CharCnt_tNedit.Appearance = appearance35;
            this.SlipNote2CharCnt_tNedit.AutoSelect = true;
            this.SlipNote2CharCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SlipNote2CharCnt_tNedit.DataText = "";
            this.SlipNote2CharCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipNote2CharCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SlipNote2CharCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipNote2CharCnt_tNedit.Location = new System.Drawing.Point(668, 346);
            this.SlipNote2CharCnt_tNedit.MaxLength = 2;
            this.SlipNote2CharCnt_tNedit.Name = "SlipNote2CharCnt_tNedit";
            this.SlipNote2CharCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SlipNote2CharCnt_tNedit.Size = new System.Drawing.Size(28, 24);
            this.SlipNote2CharCnt_tNedit.TabIndex = 30;
            // 
            // SlipNote2CharCnt_uLabel
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.SlipNote2CharCnt_uLabel.Appearance = appearance36;
            this.SlipNote2CharCnt_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipNote2CharCnt_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipNote2CharCnt_uLabel.Location = new System.Drawing.Point(542, 346);
            this.SlipNote2CharCnt_uLabel.Name = "SlipNote2CharCnt_uLabel";
            this.SlipNote2CharCnt_uLabel.Size = new System.Drawing.Size(123, 23);
            this.SlipNote2CharCnt_uLabel.TabIndex = 92;
            this.SlipNote2CharCnt_uLabel.Text = "�`�[���l�Q����";
            // 
            // SlipNoteCharCnt_tNedit
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.ForeColor = System.Drawing.Color.Black;
            appearance96.TextHAlignAsString = "Right";
            this.SlipNoteCharCnt_tNedit.ActiveAppearance = appearance96;
            appearance97.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance97.ForeColor = System.Drawing.Color.Black;
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextHAlignAsString = "Right";
            appearance97.TextVAlignAsString = "Middle";
            this.SlipNoteCharCnt_tNedit.Appearance = appearance97;
            this.SlipNoteCharCnt_tNedit.AutoSelect = true;
            this.SlipNoteCharCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SlipNoteCharCnt_tNedit.DataText = "";
            this.SlipNoteCharCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipNoteCharCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SlipNoteCharCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipNoteCharCnt_tNedit.Location = new System.Drawing.Point(668, 317);
            this.SlipNoteCharCnt_tNedit.MaxLength = 2;
            this.SlipNoteCharCnt_tNedit.Name = "SlipNoteCharCnt_tNedit";
            this.SlipNoteCharCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SlipNoteCharCnt_tNedit.Size = new System.Drawing.Size(28, 24);
            this.SlipNoteCharCnt_tNedit.TabIndex = 29;
            // 
            // SlipNoteCharCnt_uLabel
            // 
            appearance199.TextVAlignAsString = "Middle";
            this.SlipNoteCharCnt_uLabel.Appearance = appearance199;
            this.SlipNoteCharCnt_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipNoteCharCnt_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipNoteCharCnt_uLabel.Location = new System.Drawing.Point(542, 317);
            this.SlipNoteCharCnt_uLabel.Name = "SlipNoteCharCnt_uLabel";
            this.SlipNoteCharCnt_uLabel.Size = new System.Drawing.Size(120, 23);
            this.SlipNoteCharCnt_uLabel.TabIndex = 90;
            this.SlipNoteCharCnt_uLabel.Text = "�`�[���l����";
            // 
            // Note3_tEdit
            // 
            appearance179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Note3_tEdit.ActiveAppearance = appearance179;
            this.Note3_tEdit.AutoSelect = true;
            this.Note3_tEdit.DataText = "";
            this.Note3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Note3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Note3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Note3_tEdit.Location = new System.Drawing.Point(176, 375);
            this.Note3_tEdit.MaxLength = 20;
            this.Note3_tEdit.Name = "Note3_tEdit";
            this.Note3_tEdit.Size = new System.Drawing.Size(330, 24);
            this.Note3_tEdit.TabIndex = 16;
            // 
            // Note2_tEdit
            // 
            appearance188.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Note2_tEdit.ActiveAppearance = appearance188;
            this.Note2_tEdit.AutoSelect = true;
            this.Note2_tEdit.DataText = "";
            this.Note2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Note2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Note2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Note2_tEdit.Location = new System.Drawing.Point(176, 346);
            this.Note2_tEdit.MaxLength = 20;
            this.Note2_tEdit.Name = "Note2_tEdit";
            this.Note2_tEdit.Size = new System.Drawing.Size(330, 24);
            this.Note2_tEdit.TabIndex = 15;
            // 
            // Note1_tEdit
            // 
            appearance187.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Note1_tEdit.ActiveAppearance = appearance187;
            this.Note1_tEdit.AutoSelect = true;
            this.Note1_tEdit.DataText = "";
            this.Note1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Note1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Note1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Note1_tEdit.Location = new System.Drawing.Point(176, 317);
            this.Note1_tEdit.MaxLength = 20;
            this.Note1_tEdit.Name = "Note1_tEdit";
            this.Note1_tEdit.Size = new System.Drawing.Size(330, 24);
            this.Note1_tEdit.TabIndex = 14;
            // 
            // HonorificTitle_tEdit
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.HonorificTitle_tEdit.ActiveAppearance = appearance92;
            this.HonorificTitle_tEdit.AutoSelect = true;
            this.HonorificTitle_tEdit.DataText = "";
            this.HonorificTitle_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.HonorificTitle_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.HonorificTitle_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.HonorificTitle_tEdit.Location = new System.Drawing.Point(854, 288);
            this.HonorificTitle_tEdit.MaxLength = 4;
            this.HonorificTitle_tEdit.Name = "HonorificTitle_tEdit";
            this.HonorificTitle_tEdit.Size = new System.Drawing.Size(82, 24);
            this.HonorificTitle_tEdit.TabIndex = 28;
            // 
            // RefConsTaxPrtNm_tEdit
            // 
            appearance212.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RefConsTaxPrtNm_tEdit.ActiveAppearance = appearance212;
            this.RefConsTaxPrtNm_tEdit.AutoSelect = true;
            this.RefConsTaxPrtNm_tEdit.DataText = "";
            this.RefConsTaxPrtNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RefConsTaxPrtNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.RefConsTaxPrtNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.RefConsTaxPrtNm_tEdit.Location = new System.Drawing.Point(176, 288);
            this.RefConsTaxPrtNm_tEdit.MaxLength = 5;
            this.RefConsTaxPrtNm_tEdit.Name = "RefConsTaxPrtNm_tEdit";
            this.RefConsTaxPrtNm_tEdit.Size = new System.Drawing.Size(97, 24);
            this.RefConsTaxPrtNm_tEdit.TabIndex = 13;
            // 
            // ReissueMark_tEdit
            // 
            appearance180.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ReissueMark_tEdit.ActiveAppearance = appearance180;
            this.ReissueMark_tEdit.AutoSelect = true;
            this.ReissueMark_tEdit.DataText = "";
            this.ReissueMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ReissueMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.ReissueMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ReissueMark_tEdit.Location = new System.Drawing.Point(176, 201);
            this.ReissueMark_tEdit.MaxLength = 3;
            this.ReissueMark_tEdit.Name = "ReissueMark_tEdit";
            this.ReissueMark_tEdit.Size = new System.Drawing.Size(66, 24);
            this.ReissueMark_tEdit.TabIndex = 10;
            // 
            // SlipPrtKind_tNedit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            this.SlipPrtKind_tNedit.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.SlipPrtKind_tNedit.Appearance = appearance2;
            this.SlipPrtKind_tNedit.AutoSelect = true;
            this.SlipPrtKind_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SlipPrtKind_tNedit.DataText = "";
            this.SlipPrtKind_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipPrtKind_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SlipPrtKind_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipPrtKind_tNedit.Location = new System.Drawing.Point(176, 6);
            this.SlipPrtKind_tNedit.MaxLength = 2;
            this.SlipPrtKind_tNedit.Name = "SlipPrtKind_tNedit";
            this.SlipPrtKind_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SlipPrtKind_tNedit.ReadOnly = true;
            this.SlipPrtKind_tNedit.Size = new System.Drawing.Size(28, 24);
            this.SlipPrtKind_tNedit.TabIndex = 2;
            // 
            // DataInputSystem_tNedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.DataInputSystem_tNedit.ActiveAppearance = appearance3;
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.DataInputSystem_tNedit.Appearance = appearance4;
            this.DataInputSystem_tNedit.AutoSelect = true;
            this.DataInputSystem_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DataInputSystem_tNedit.DataText = "";
            this.DataInputSystem_tNedit.Enabled = false;
            this.DataInputSystem_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DataInputSystem_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DataInputSystem_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DataInputSystem_tNedit.Location = new System.Drawing.Point(612, 5);
            this.DataInputSystem_tNedit.MaxLength = 2;
            this.DataInputSystem_tNedit.Name = "DataInputSystem_tNedit";
            this.DataInputSystem_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DataInputSystem_tNedit.ReadOnly = true;
            this.DataInputSystem_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DataInputSystem_tNedit.TabIndex = 0;
            this.DataInputSystem_tNedit.TabStop = false;
            this.DataInputSystem_tNedit.Visible = false;
            // 
            // SpecialPurpose4_tEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.SpecialPurpose4_tEdit.ActiveAppearance = appearance5;
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.SpecialPurpose4_tEdit.Appearance = appearance6;
            this.SpecialPurpose4_tEdit.AutoSelect = true;
            this.SpecialPurpose4_tEdit.DataText = "";
            this.SpecialPurpose4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SpecialPurpose4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SpecialPurpose4_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.SpecialPurpose4_tEdit.Location = new System.Drawing.Point(531, 493);
            this.SpecialPurpose4_tEdit.MaxLength = 10;
            this.SpecialPurpose4_tEdit.Name = "SpecialPurpose4_tEdit";
            this.SpecialPurpose4_tEdit.Size = new System.Drawing.Size(20, 24);
            this.SpecialPurpose4_tEdit.TabIndex = 88;
            this.SpecialPurpose4_tEdit.TabStop = false;
            this.SpecialPurpose4_tEdit.Visible = false;
            // 
            // SpecialPurpose3_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.SpecialPurpose3_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.SpecialPurpose3_tEdit.Appearance = appearance8;
            this.SpecialPurpose3_tEdit.AutoSelect = true;
            this.SpecialPurpose3_tEdit.DataText = "";
            this.SpecialPurpose3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SpecialPurpose3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SpecialPurpose3_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.SpecialPurpose3_tEdit.Location = new System.Drawing.Point(531, 466);
            this.SpecialPurpose3_tEdit.MaxLength = 10;
            this.SpecialPurpose3_tEdit.Name = "SpecialPurpose3_tEdit";
            this.SpecialPurpose3_tEdit.Size = new System.Drawing.Size(20, 24);
            this.SpecialPurpose3_tEdit.TabIndex = 87;
            this.SpecialPurpose3_tEdit.TabStop = false;
            this.SpecialPurpose3_tEdit.Visible = false;
            // 
            // SpecialPurpose2_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.SpecialPurpose2_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.SpecialPurpose2_tEdit.Appearance = appearance10;
            this.SpecialPurpose2_tEdit.AutoSelect = true;
            this.SpecialPurpose2_tEdit.DataText = "";
            this.SpecialPurpose2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SpecialPurpose2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SpecialPurpose2_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.SpecialPurpose2_tEdit.Location = new System.Drawing.Point(531, 440);
            this.SpecialPurpose2_tEdit.MaxLength = 10;
            this.SpecialPurpose2_tEdit.Name = "SpecialPurpose2_tEdit";
            this.SpecialPurpose2_tEdit.Size = new System.Drawing.Size(20, 24);
            this.SpecialPurpose2_tEdit.TabIndex = 86;
            this.SpecialPurpose2_tEdit.TabStop = false;
            this.SpecialPurpose2_tEdit.Visible = false;
            // 
            // SpecialPurpose1_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.SpecialPurpose1_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.SpecialPurpose1_tEdit.Appearance = appearance12;
            this.SpecialPurpose1_tEdit.AutoSelect = true;
            this.SpecialPurpose1_tEdit.DataText = "";
            this.SpecialPurpose1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SpecialPurpose1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SpecialPurpose1_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.SpecialPurpose1_tEdit.Location = new System.Drawing.Point(531, 414);
            this.SpecialPurpose1_tEdit.MaxLength = 10;
            this.SpecialPurpose1_tEdit.Name = "SpecialPurpose1_tEdit";
            this.SpecialPurpose1_tEdit.Size = new System.Drawing.Size(20, 24);
            this.SpecialPurpose1_tEdit.TabIndex = 85;
            this.SpecialPurpose1_tEdit.TabStop = false;
            this.SpecialPurpose1_tEdit.Visible = false;
            // 
            // ultraLabel15
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance13;
            this.ultraLabel15.Location = new System.Drawing.Point(439, 494);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel15.TabIndex = 84;
            this.ultraLabel15.Text = "����p�r4";
            this.ultraLabel15.Visible = false;
            // 
            // ultraLabel14
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance14;
            this.ultraLabel14.Location = new System.Drawing.Point(439, 466);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel14.TabIndex = 83;
            this.ultraLabel14.Text = "����p�r3";
            this.ultraLabel14.Visible = false;
            // 
            // ultraLabel1222
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel1222.Appearance = appearance15;
            this.ultraLabel1222.Location = new System.Drawing.Point(439, 440);
            this.ultraLabel1222.Name = "ultraLabel1222";
            this.ultraLabel1222.Size = new System.Drawing.Size(90, 23);
            this.ultraLabel1222.TabIndex = 82;
            this.ultraLabel1222.Text = "����p�r2";
            this.ultraLabel1222.Visible = false;
            // 
            // SpecialPurpose1_uLabel
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.SpecialPurpose1_uLabel.Appearance = appearance16;
            this.SpecialPurpose1_uLabel.Location = new System.Drawing.Point(439, 416);
            this.SpecialPurpose1_uLabel.Name = "SpecialPurpose1_uLabel";
            this.SpecialPurpose1_uLabel.Size = new System.Drawing.Size(90, 23);
            this.SpecialPurpose1_uLabel.TabIndex = 81;
            this.SpecialPurpose1_uLabel.Text = "����p�r1";
            this.SpecialPurpose1_uLabel.Visible = false;
            // 
            // SlipPrtKindNm_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.SlipPrtKindNm_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.SlipPrtKindNm_tEdit.Appearance = appearance18;
            this.SlipPrtKindNm_tEdit.AutoSelect = true;
            this.SlipPrtKindNm_tEdit.DataText = "";
            this.SlipPrtKindNm_tEdit.Enabled = false;
            this.SlipPrtKindNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipPrtKindNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SlipPrtKindNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipPrtKindNm_tEdit.Location = new System.Drawing.Point(233, 6);
            this.SlipPrtKindNm_tEdit.MaxLength = 10;
            this.SlipPrtKindNm_tEdit.Name = "SlipPrtKindNm_tEdit";
            this.SlipPrtKindNm_tEdit.ReadOnly = true;
            this.SlipPrtKindNm_tEdit.Size = new System.Drawing.Size(83, 24);
            this.SlipPrtKindNm_tEdit.TabIndex = 3;
            // 
            // DataInputSystemNm_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.DataInputSystemNm_tEdit.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.DataInputSystemNm_tEdit.Appearance = appearance20;
            this.DataInputSystemNm_tEdit.AutoSelect = true;
            this.DataInputSystemNm_tEdit.DataText = "";
            this.DataInputSystemNm_tEdit.Enabled = false;
            this.DataInputSystemNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DataInputSystemNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.DataInputSystemNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DataInputSystemNm_tEdit.Location = new System.Drawing.Point(653, 5);
            this.DataInputSystemNm_tEdit.MaxLength = 10;
            this.DataInputSystemNm_tEdit.Name = "DataInputSystemNm_tEdit";
            this.DataInputSystemNm_tEdit.ReadOnly = true;
            this.DataInputSystemNm_tEdit.Size = new System.Drawing.Size(122, 24);
            this.DataInputSystemNm_tEdit.TabIndex = 1;
            this.DataInputSystemNm_tEdit.TabStop = false;
            this.DataInputSystemNm_tEdit.Visible = false;
            // 
            // Rank_uLabel
            // 
            appearance21.TextHAlignAsString = "Left";
            appearance21.TextVAlignAsString = "Middle";
            this.Rank_uLabel.Appearance = appearance21;
            this.Rank_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Rank_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Rank_uLabel.Location = new System.Drawing.Point(670, 423);
            this.Rank_uLabel.Name = "Rank_uLabel";
            this.Rank_uLabel.Size = new System.Drawing.Size(104, 23);
            this.Rank_uLabel.TabIndex = 78;
            this.Rank_uLabel.Text = "�񖼏̏���";
            this.Rank_uLabel.Visible = false;
            // 
            // SlipPrtSetPaperId_uLabel
            // 
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.SlipPrtSetPaperId_uLabel.Appearance = appearance22;
            this.SlipPrtSetPaperId_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipPrtSetPaperId_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipPrtSetPaperId_uLabel.Location = new System.Drawing.Point(20, 35);
            this.SlipPrtSetPaperId_uLabel.Name = "SlipPrtSetPaperId_uLabel";
            this.SlipPrtSetPaperId_uLabel.Size = new System.Drawing.Size(137, 23);
            this.SlipPrtSetPaperId_uLabel.TabIndex = 77;
            this.SlipPrtSetPaperId_uLabel.Text = "�`�[������[ID";
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(670, 504);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(88, 32);
            this.DownButton.TabIndex = 32;
            this.DownButton.Text = "����(&L)";
            this.DownButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DownButton.Visible = false;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(670, 456);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(88, 32);
            this.UpButton.TabIndex = 31;
            this.UpButton.Text = "���(&U)";
            this.UpButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UpButton.Visible = false;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // eachSlipTypeCol_ultraGrid
            // 
            this.eachSlipTypeCol_ultraGrid.Location = new System.Drawing.Point(378, 411);
            this.eachSlipTypeCol_ultraGrid.Name = "eachSlipTypeCol_ultraGrid";
            this.eachSlipTypeCol_ultraGrid.Size = new System.Drawing.Size(563, 245);
            this.eachSlipTypeCol_ultraGrid.TabIndex = 36;
            this.eachSlipTypeCol_ultraGrid.VisibleChanged += new System.EventHandler(this.eachSlipTypeCol_ultraGrid_VisibleChanged);
            this.eachSlipTypeCol_ultraGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eachSlipTypeCol_ultraGrid_KeyDown);
            this.eachSlipTypeCol_ultraGrid.AfterCellActivate += new System.EventHandler(this.eachSlipTypeCol_ultraGrid_AfterCellActivate);
            // 
            // CopyCount_tComboEditor
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.CopyCount_tComboEditor.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.CopyCount_tComboEditor.Appearance = appearance27;
            this.CopyCount_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CopyCount_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CopyCount_tComboEditor.ItemAppearance = appearance28;
            this.CopyCount_tComboEditor.Location = new System.Drawing.Point(854, 259);
            this.CopyCount_tComboEditor.Name = "CopyCount_tComboEditor";
            this.CopyCount_tComboEditor.Size = new System.Drawing.Size(42, 24);
            this.CopyCount_tComboEditor.TabIndex = 26;
            // 
            // SlipFontSize_tComEditor
            // 
            appearance205.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance205.ForeColor = System.Drawing.Color.Black;
            this.SlipFontSize_tComEditor.ActiveAppearance = appearance205;
            appearance206.BackColor2 = System.Drawing.Color.White;
            appearance206.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance206.ForeColor = System.Drawing.Color.Black;
            appearance206.ForeColorDisabled = System.Drawing.Color.Black;
            appearance206.TextVAlignAsString = "Middle";
            this.SlipFontSize_tComEditor.Appearance = appearance206;
            this.SlipFontSize_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SlipFontSize_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipFontSize_tComEditor.ItemAppearance = appearance34;
            this.SlipFontSize_tComEditor.Location = new System.Drawing.Point(668, 172);
            this.SlipFontSize_tComEditor.Name = "SlipFontSize_tComEditor";
            this.SlipFontSize_tComEditor.Size = new System.Drawing.Size(78, 24);
            this.SlipFontSize_tComEditor.TabIndex = 22;
            // 
            // BottomMargin_tNedit
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            this.BottomMargin_tNedit.ActiveAppearance = appearance23;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Right";
            appearance24.TextVAlignAsString = "Middle";
            this.BottomMargin_tNedit.Appearance = appearance24;
            this.BottomMargin_tNedit.AutoSelect = true;
            this.BottomMargin_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BottomMargin_tNedit.DataText = "999.99";
            this.BottomMargin_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BottomMargin_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.BottomMargin_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BottomMargin_tNedit.Location = new System.Drawing.Point(440, 230);
            this.BottomMargin_tNedit.MaxLength = 6;
            this.BottomMargin_tNedit.Name = "BottomMargin_tNedit";
            this.BottomMargin_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.BottomMargin_tNedit.Size = new System.Drawing.Size(60, 24);
            this.BottomMargin_tNedit.TabIndex = 20;
            this.BottomMargin_tNedit.Text = "999.99";
            // 
            // RightMargin_tNedit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Right";
            this.RightMargin_tNedit.ActiveAppearance = appearance42;
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Right";
            appearance43.TextVAlignAsString = "Middle";
            this.RightMargin_tNedit.Appearance = appearance43;
            this.RightMargin_tNedit.AutoSelect = true;
            this.RightMargin_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.RightMargin_tNedit.DataText = "999.99";
            this.RightMargin_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RightMargin_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.RightMargin_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RightMargin_tNedit.Location = new System.Drawing.Point(440, 201);
            this.RightMargin_tNedit.MaxLength = 6;
            this.RightMargin_tNedit.Name = "RightMargin_tNedit";
            this.RightMargin_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.RightMargin_tNedit.Size = new System.Drawing.Size(60, 24);
            this.RightMargin_tNedit.TabIndex = 19;
            this.RightMargin_tNedit.Text = "999.99";
            // 
            // LeftMarging_tNedit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextHAlignAsString = "Right";
            this.LeftMarging_tNedit.ActiveAppearance = appearance44;
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Right";
            appearance45.TextVAlignAsString = "Middle";
            this.LeftMarging_tNedit.Appearance = appearance45;
            this.LeftMarging_tNedit.AutoSelect = true;
            this.LeftMarging_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.LeftMarging_tNedit.DataText = "999.99";
            this.LeftMarging_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.LeftMarging_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.LeftMarging_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LeftMarging_tNedit.Location = new System.Drawing.Point(440, 172);
            this.LeftMarging_tNedit.MaxLength = 6;
            this.LeftMarging_tNedit.Name = "LeftMarging_tNedit";
            this.LeftMarging_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.LeftMarging_tNedit.Size = new System.Drawing.Size(60, 24);
            this.LeftMarging_tNedit.TabIndex = 18;
            this.LeftMarging_tNedit.Text = "999.99";
            // 
            // TopMarging_tNedit
            // 
            appearance181.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance181.ForeColor = System.Drawing.Color.Black;
            appearance181.TextHAlignAsString = "Right";
            this.TopMarging_tNedit.ActiveAppearance = appearance181;
            appearance182.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance182.ForeColor = System.Drawing.Color.Black;
            appearance182.ForeColorDisabled = System.Drawing.Color.Black;
            appearance182.TextHAlignAsString = "Right";
            appearance182.TextVAlignAsString = "Middle";
            this.TopMarging_tNedit.Appearance = appearance182;
            this.TopMarging_tNedit.AutoSelect = true;
            this.TopMarging_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TopMarging_tNedit.DataText = "999.99";
            this.TopMarging_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TopMarging_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TopMarging_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TopMarging_tNedit.Location = new System.Drawing.Point(440, 143);
            this.TopMarging_tNedit.MaxLength = 6;
            this.TopMarging_tNedit.Name = "TopMarging_tNedit";
            this.TopMarging_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TopMarging_tNedit.Size = new System.Drawing.Size(60, 24);
            this.TopMarging_tNedit.TabIndex = 17;
            this.TopMarging_tNedit.Text = "999.99";
            // 
            // OutConMsg_tEdit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance48.ForeColor = System.Drawing.Color.Black;
            this.OutConMsg_tEdit.ActiveAppearance = appearance48;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.OutConMsg_tEdit.Appearance = appearance49;
            this.OutConMsg_tEdit.AutoSelect = true;
            this.OutConMsg_tEdit.DataText = "";
            this.OutConMsg_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutConMsg_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, false, true, true, true));
            this.OutConMsg_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.OutConMsg_tEdit.Location = new System.Drawing.Point(176, 103);
            this.OutConMsg_tEdit.MaxLength = 25;
            this.OutConMsg_tEdit.Name = "OutConMsg_tEdit";
            this.OutConMsg_tEdit.Size = new System.Drawing.Size(417, 24);
            this.OutConMsg_tEdit.TabIndex = 8;
            // 
            // SlipComment_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.ForeColor = System.Drawing.Color.Black;
            this.SlipComment_tEdit.ActiveAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextVAlignAsString = "Middle";
            this.SlipComment_tEdit.Appearance = appearance51;
            this.SlipComment_tEdit.AutoSelect = true;
            this.SlipComment_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SlipComment_tEdit.DataText = "";
            this.SlipComment_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipComment_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, false, true, true, true));
            this.SlipComment_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SlipComment_tEdit.Location = new System.Drawing.Point(385, 36);
            this.SlipComment_tEdit.MaxLength = 30;
            this.SlipComment_tEdit.Name = "SlipComment_tEdit";
            this.SlipComment_tEdit.Size = new System.Drawing.Size(496, 24);
            this.SlipComment_tEdit.TabIndex = 5;
            // 
            // PrtPreviewExistCode_tComEditor
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.ForeColor = System.Drawing.Color.Black;
            this.PrtPreviewExistCode_tComEditor.ActiveAppearance = appearance55;
            appearance56.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            appearance56.TextVAlignAsString = "Middle";
            this.PrtPreviewExistCode_tComEditor.Appearance = appearance56;
            this.PrtPreviewExistCode_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrtPreviewExistCode_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrtPreviewExistCode_tComEditor.ItemAppearance = appearance57;
            this.PrtPreviewExistCode_tComEditor.Location = new System.Drawing.Point(668, 143);
            this.PrtPreviewExistCode_tComEditor.Name = "PrtPreviewExistCode_tComEditor";
            this.PrtPreviewExistCode_tComEditor.Size = new System.Drawing.Size(189, 24);
            this.PrtPreviewExistCode_tComEditor.TabIndex = 21;
            // 
            // TimePrintDivCd_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            this.TimePrintDivCd_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextVAlignAsString = "Middle";
            this.TimePrintDivCd_tComboEditor.Appearance = appearance59;
            this.TimePrintDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.TimePrintDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TimePrintDivCd_tComboEditor.ItemAppearance = appearance60;
            this.TimePrintDivCd_tComboEditor.Location = new System.Drawing.Point(668, 201);
            this.TimePrintDivCd_tComboEditor.Name = "TimePrintDivCd_tComboEditor";
            this.TimePrintDivCd_tComboEditor.Size = new System.Drawing.Size(179, 24);
            this.TimePrintDivCd_tComboEditor.TabIndex = 23;
            // 
            // QRCodePrintDivCd_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            this.QRCodePrintDivCd_tComboEditor.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.QRCodePrintDivCd_tComboEditor.Appearance = appearance47;
            this.QRCodePrintDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.QRCodePrintDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance190.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.QRCodePrintDivCd_tComboEditor.ItemAppearance = appearance190;
            this.QRCodePrintDivCd_tComboEditor.Location = new System.Drawing.Point(668, 230);
            this.QRCodePrintDivCd_tComboEditor.Name = "QRCodePrintDivCd_tComboEditor";
            this.QRCodePrintDivCd_tComboEditor.Size = new System.Drawing.Size(179, 24);
            this.QRCodePrintDivCd_tComboEditor.TabIndex = 24;
            // 
            // ConsTaxPrtCd_tComboEditor
            // 
            appearance213.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance213.ForeColor = System.Drawing.Color.Black;
            this.ConsTaxPrtCd_tComboEditor.ActiveAppearance = appearance213;
            appearance214.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance214.ForeColor = System.Drawing.Color.Black;
            appearance214.ForeColorDisabled = System.Drawing.Color.Black;
            appearance214.TextVAlignAsString = "Middle";
            this.ConsTaxPrtCd_tComboEditor.Appearance = appearance214;
            this.ConsTaxPrtCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConsTaxPrtCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance215.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxPrtCd_tComboEditor.ItemAppearance = appearance215;
            this.ConsTaxPrtCd_tComboEditor.Location = new System.Drawing.Point(176, 230);
            this.ConsTaxPrtCd_tComboEditor.Name = "ConsTaxPrtCd_tComboEditor";
            this.ConsTaxPrtCd_tComboEditor.Size = new System.Drawing.Size(179, 24);
            this.ConsTaxPrtCd_tComboEditor.TabIndex = 11;
            // 
            // RefConsTaxDivCd_tComboEditor
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.ForeColor = System.Drawing.Color.Black;
            this.RefConsTaxDivCd_tComboEditor.ActiveAppearance = appearance25;
            appearance207.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance207.ForeColor = System.Drawing.Color.Black;
            appearance207.ForeColorDisabled = System.Drawing.Color.Black;
            appearance207.TextVAlignAsString = "Middle";
            this.RefConsTaxDivCd_tComboEditor.Appearance = appearance207;
            this.RefConsTaxDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RefConsTaxDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RefConsTaxDivCd_tComboEditor.ItemAppearance = appearance88;
            this.RefConsTaxDivCd_tComboEditor.Location = new System.Drawing.Point(176, 259);
            this.RefConsTaxDivCd_tComboEditor.Name = "RefConsTaxDivCd_tComboEditor";
            this.RefConsTaxDivCd_tComboEditor.Size = new System.Drawing.Size(179, 24);
            this.RefConsTaxDivCd_tComboEditor.TabIndex = 12;
            // 
            // EnterpriseNamePrtCd_tComEditor
            // 
            appearance208.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance208.ForeColor = System.Drawing.Color.Black;
            this.EnterpriseNamePrtCd_tComEditor.ActiveAppearance = appearance208;
            appearance209.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance209.ForeColor = System.Drawing.Color.Black;
            appearance209.ForeColorDisabled = System.Drawing.Color.Black;
            appearance209.TextVAlignAsString = "Middle";
            this.EnterpriseNamePrtCd_tComEditor.Appearance = appearance209;
            this.EnterpriseNamePrtCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EnterpriseNamePrtCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EnterpriseNamePrtCd_tComEditor.ItemAppearance = appearance210;
            this.EnterpriseNamePrtCd_tComEditor.Location = new System.Drawing.Point(176, 143);
            this.EnterpriseNamePrtCd_tComEditor.Name = "EnterpriseNamePrtCd_tComEditor";
            this.EnterpriseNamePrtCd_tComEditor.Size = new System.Drawing.Size(179, 24);
            this.EnterpriseNamePrtCd_tComEditor.TabIndex = 9;
            // 
            // SlipPrtSetPaperId_tEdit
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance61.ForeColor = System.Drawing.Color.Black;
            this.SlipPrtSetPaperId_tEdit.ActiveAppearance = appearance61;
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance62.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance62.ForeColor = System.Drawing.Color.Black;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            appearance62.TextVAlignAsString = "Middle";
            this.SlipPrtSetPaperId_tEdit.Appearance = appearance62;
            this.SlipPrtSetPaperId_tEdit.AutoSelect = true;
            this.SlipPrtSetPaperId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SlipPrtSetPaperId_tEdit.DataText = "";
            this.SlipPrtSetPaperId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipPrtSetPaperId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SlipPrtSetPaperId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SlipPrtSetPaperId_tEdit.Location = new System.Drawing.Point(176, 36);
            this.SlipPrtSetPaperId_tEdit.MaxLength = 24;
            this.SlipPrtSetPaperId_tEdit.Name = "SlipPrtSetPaperId_tEdit";
            this.SlipPrtSetPaperId_tEdit.Size = new System.Drawing.Size(203, 24);
            this.SlipPrtSetPaperId_tEdit.TabIndex = 4;
            // 
            // OutputPgClassId_tEdit
            // 
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance63.ForeColor = System.Drawing.Color.Black;
            this.OutputPgClassId_tEdit.ActiveAppearance = appearance63;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance64.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance64.ForeColor = System.Drawing.Color.Black;
            appearance64.ForeColorDisabled = System.Drawing.Color.Black;
            appearance64.TextVAlignAsString = "Middle";
            this.OutputPgClassId_tEdit.Appearance = appearance64;
            this.OutputPgClassId_tEdit.AutoSelect = true;
            this.OutputPgClassId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutputPgClassId_tEdit.DataText = "";
            this.OutputPgClassId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutputPgClassId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.OutputPgClassId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OutputPgClassId_tEdit.Location = new System.Drawing.Point(542, 558);
            this.OutputPgClassId_tEdit.MaxLength = 80;
            this.OutputPgClassId_tEdit.Name = "OutputPgClassId_tEdit";
            this.OutputPgClassId_tEdit.Size = new System.Drawing.Size(28, 24);
            this.OutputPgClassId_tEdit.TabIndex = 62;
            this.OutputPgClassId_tEdit.Visible = false;
            // 
            // OutputPgId_tEdit
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            this.OutputPgId_tEdit.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextVAlignAsString = "Middle";
            this.OutputPgId_tEdit.Appearance = appearance66;
            this.OutputPgId_tEdit.AutoSelect = true;
            this.OutputPgId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutputPgId_tEdit.DataText = "";
            this.OutputPgId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutputPgId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.OutputPgId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OutputPgId_tEdit.Location = new System.Drawing.Point(574, 533);
            this.OutputPgId_tEdit.MaxLength = 5;
            this.OutputPgId_tEdit.Name = "OutputPgId_tEdit";
            this.OutputPgId_tEdit.Size = new System.Drawing.Size(52, 24);
            this.OutputPgId_tEdit.TabIndex = 58;
            this.OutputPgId_tEdit.Visible = false;
            // 
            // OutputFormFileName_tEdit
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            this.OutputFormFileName_tEdit.ActiveAppearance = appearance67;
            appearance68.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance68.ForeColor = System.Drawing.Color.Black;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextVAlignAsString = "Middle";
            this.OutputFormFileName_tEdit.Appearance = appearance68;
            this.OutputFormFileName_tEdit.AutoSelect = true;
            this.OutputFormFileName_tEdit.DataText = "";
            this.OutputFormFileName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutputFormFileName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.OutputFormFileName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OutputFormFileName_tEdit.Location = new System.Drawing.Point(635, 590);
            this.OutputFormFileName_tEdit.MaxLength = 30;
            this.OutputFormFileName_tEdit.Name = "OutputFormFileName_tEdit";
            this.OutputFormFileName_tEdit.Size = new System.Drawing.Size(28, 24);
            this.OutputFormFileName_tEdit.TabIndex = 69;
            this.OutputFormFileName_tEdit.Visible = false;
            // 
            // OutputPgClassId_uLabel
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.OutputPgClassId_uLabel.Appearance = appearance69;
            this.OutputPgClassId_uLabel.Location = new System.Drawing.Point(441, 558);
            this.OutputPgClassId_uLabel.Name = "OutputPgClassId_uLabel";
            this.OutputPgClassId_uLabel.Size = new System.Drawing.Size(100, 28);
            this.OutputPgClassId_uLabel.TabIndex = 61;
            this.OutputPgClassId_uLabel.Text = "�o�̓v���O�����N���XID";
            this.OutputPgClassId_uLabel.Visible = false;
            // 
            // OutputPgId_uLabel
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.OutputPgId_uLabel.Appearance = appearance70;
            this.OutputPgId_uLabel.Location = new System.Drawing.Point(439, 533);
            this.OutputPgId_uLabel.Name = "OutputPgId_uLabel";
            this.OutputPgId_uLabel.Size = new System.Drawing.Size(129, 23);
            this.OutputPgId_uLabel.TabIndex = 57;
            this.OutputPgId_uLabel.Text = "�o�̓v���O����ID";
            this.OutputPgId_uLabel.Visible = false;
            // 
            // OutputFormFileName_ulabel
            // 
            appearance71.TextVAlignAsString = "Middle";
            this.OutputFormFileName_ulabel.Appearance = appearance71;
            this.OutputFormFileName_ulabel.Location = new System.Drawing.Point(567, 590);
            this.OutputFormFileName_ulabel.Name = "OutputFormFileName_ulabel";
            this.OutputFormFileName_ulabel.Size = new System.Drawing.Size(72, 28);
            this.OutputFormFileName_ulabel.TabIndex = 68;
            this.OutputFormFileName_ulabel.Text = "�o�̓t�@�C����";
            this.OutputFormFileName_ulabel.Visible = false;
            // 
            // ImageColorGuide5_uButton
            // 
            this.ImageColorGuide5_uButton.Location = new System.Drawing.Point(537, 589);
            this.ImageColorGuide5_uButton.Name = "ImageColorGuide5_uButton";
            this.ImageColorGuide5_uButton.Size = new System.Drawing.Size(25, 25);
            this.ImageColorGuide5_uButton.TabIndex = 67;
            ultraToolTipInfo5.ToolTipText = "�F�̐ݒ�";
            this.ultraToolTipManager1.SetUltraToolTip(this.ImageColorGuide5_uButton, ultraToolTipInfo5);
            this.ImageColorGuide5_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ImageColorGuide5_uButton.Visible = false;
            this.ImageColorGuide5_uButton.Click += new System.EventHandler(this.ImageColorGuide_Click);
            // 
            // SlipBaseColor5_uLabel
            // 
            appearance72.BorderColor = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            appearance72.TextVAlignAsString = "Middle";
            this.SlipBaseColor5_uLabel.Appearance = appearance72;
            this.SlipBaseColor5_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.SlipBaseColor5_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SlipBaseColor5_uLabel.Enabled = false;
            this.SlipBaseColor5_uLabel.Location = new System.Drawing.Point(491, 590);
            this.SlipBaseColor5_uLabel.Name = "SlipBaseColor5_uLabel";
            this.SlipBaseColor5_uLabel.Size = new System.Drawing.Size(40, 23);
            this.SlipBaseColor5_uLabel.TabIndex = 66;
            this.SlipBaseColor5_uLabel.Visible = false;
            // 
            // ultraLabel11
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance73;
            this.ultraLabel11.Location = new System.Drawing.Point(441, 589);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(54, 23);
            this.ultraLabel11.TabIndex = 65;
            this.ultraLabel11.Text = "�T����";
            this.ultraLabel11.Visible = false;
            // 
            // DetailRowCount_tNedit
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.ForeColor = System.Drawing.Color.Black;
            appearance74.TextHAlignAsString = "Right";
            this.DetailRowCount_tNedit.ActiveAppearance = appearance74;
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            appearance75.TextVAlignAsString = "Middle";
            this.DetailRowCount_tNedit.Appearance = appearance75;
            this.DetailRowCount_tNedit.AutoSelect = true;
            this.DetailRowCount_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DetailRowCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DetailRowCount_tNedit.DataText = "";
            this.DetailRowCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DetailRowCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DetailRowCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DetailRowCount_tNedit.Location = new System.Drawing.Point(668, 288);
            this.DetailRowCount_tNedit.MaxLength = 3;
            this.DetailRowCount_tNedit.Name = "DetailRowCount_tNedit";
            this.DetailRowCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DetailRowCount_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DetailRowCount_tNedit.TabIndex = 27;
            // 
            // PrtCirculation_tNedit
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextHAlignAsString = "Right";
            this.PrtCirculation_tNedit.ActiveAppearance = appearance52;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Right";
            appearance53.TextVAlignAsString = "Middle";
            this.PrtCirculation_tNedit.Appearance = appearance53;
            this.PrtCirculation_tNedit.AutoSelect = true;
            this.PrtCirculation_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrtCirculation_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrtCirculation_tNedit.DataText = "";
            this.PrtCirculation_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrtCirculation_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrtCirculation_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrtCirculation_tNedit.Location = new System.Drawing.Point(668, 259);
            this.PrtCirculation_tNedit.MaxLength = 2;
            this.PrtCirculation_tNedit.Name = "PrtCirculation_tNedit";
            this.PrtCirculation_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrtCirculation_tNedit.Size = new System.Drawing.Size(28, 24);
            this.PrtCirculation_tNedit.TabIndex = 25;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(8, 403);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(933, 3);
            this.ultraLabel4.TabIndex = 46;
            // 
            // ultraLabel13
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance76;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel13.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(909, 259);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(21, 23);
            this.ultraLabel13.TabIndex = 45;
            this.ultraLabel13.Text = "��";
            // 
            // HonorificTitle_uLabel
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.HonorificTitle_uLabel.Appearance = appearance77;
            this.HonorificTitle_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.HonorificTitle_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HonorificTitle_uLabel.Location = new System.Drawing.Point(764, 288);
            this.HonorificTitle_uLabel.Name = "HonorificTitle_uLabel";
            this.HonorificTitle_uLabel.Size = new System.Drawing.Size(75, 23);
            this.HonorificTitle_uLabel.TabIndex = 43;
            this.HonorificTitle_uLabel.Text = "�h��";
            // 
            // CopyCount_uLabel
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.CopyCount_uLabel.Appearance = appearance54;
            this.CopyCount_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CopyCount_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CopyCount_uLabel.Location = new System.Drawing.Point(764, 259);
            this.CopyCount_uLabel.Name = "CopyCount_uLabel";
            this.CopyCount_uLabel.Size = new System.Drawing.Size(75, 23);
            this.CopyCount_uLabel.TabIndex = 43;
            this.CopyCount_uLabel.Text = "���ʖ���";
            // 
            // ultraLabel6
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance79;
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(504, 226);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "cm";
            // 
            // ultraLabel5
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance80;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(504, 199);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel5.TabIndex = 30;
            this.ultraLabel5.Text = "cm";
            // 
            // RightMargin_uLabel
            // 
            appearance81.TextVAlignAsString = "Middle";
            this.RightMargin_uLabel.Appearance = appearance81;
            this.RightMargin_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.RightMargin_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RightMargin_uLabel.Location = new System.Drawing.Point(381, 201);
            this.RightMargin_uLabel.Name = "RightMargin_uLabel";
            this.RightMargin_uLabel.Size = new System.Drawing.Size(65, 23);
            this.RightMargin_uLabel.TabIndex = 24;
            this.RightMargin_uLabel.Text = "�E�]��";
            // 
            // BottomMargin_uLabel
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.BottomMargin_uLabel.Appearance = appearance29;
            this.BottomMargin_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BottomMargin_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BottomMargin_uLabel.Location = new System.Drawing.Point(381, 230);
            this.BottomMargin_uLabel.Name = "BottomMargin_uLabel";
            this.BottomMargin_uLabel.Size = new System.Drawing.Size(65, 23);
            this.BottomMargin_uLabel.TabIndex = 26;
            this.BottomMargin_uLabel.Text = "���]��";
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel12.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(8, 134);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(933, 3);
            this.ultraLabel12.TabIndex = 11;
            // 
            // ultraLabe11
            // 
            this.ultraLabe11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabe11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabe11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabe11.Location = new System.Drawing.Point(8, 64);
            this.ultraLabe11.Name = "ultraLabe11";
            this.ultraLabe11.Size = new System.Drawing.Size(933, 3);
            this.ultraLabe11.TabIndex = 4;
            // 
            // ultraLabel3
            // 
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance83;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(504, 172);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel3.TabIndex = 29;
            this.ultraLabel3.Text = "cm";
            // 
            // ultraLabel2
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance84;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(504, 143);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel2.TabIndex = 28;
            this.ultraLabel2.Text = "cm";
            // 
            // TopMarging_uLabel
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.TopMarging_uLabel.Appearance = appearance85;
            this.TopMarging_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.TopMarging_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TopMarging_uLabel.Location = new System.Drawing.Point(381, 143);
            this.TopMarging_uLabel.Name = "TopMarging_uLabel";
            this.TopMarging_uLabel.Size = new System.Drawing.Size(65, 23);
            this.TopMarging_uLabel.TabIndex = 20;
            this.TopMarging_uLabel.Text = "��]��";
            // 
            // LeftMarging_uLabel
            // 
            appearance86.TextVAlignAsString = "Middle";
            this.LeftMarging_uLabel.Appearance = appearance86;
            this.LeftMarging_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.LeftMarging_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LeftMarging_uLabel.Location = new System.Drawing.Point(381, 172);
            this.LeftMarging_uLabel.Name = "LeftMarging_uLabel";
            this.LeftMarging_uLabel.Size = new System.Drawing.Size(65, 23);
            this.LeftMarging_uLabel.TabIndex = 22;
            this.LeftMarging_uLabel.Text = "���]��";
            // 
            // SlipPrtKind_uLabel
            // 
            appearance87.TextHAlignAsString = "Left";
            appearance87.TextVAlignAsString = "Middle";
            this.SlipPrtKind_uLabel.Appearance = appearance87;
            this.SlipPrtKind_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipPrtKind_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipPrtKind_uLabel.Location = new System.Drawing.Point(20, 6);
            this.SlipPrtKind_uLabel.Name = "SlipPrtKind_uLabel";
            this.SlipPrtKind_uLabel.Size = new System.Drawing.Size(100, 23);
            this.SlipPrtKind_uLabel.TabIndex = 2;
            this.SlipPrtKind_uLabel.Text = "�`�[������";
            // 
            // SlipFontSize_uLabel
            // 
            appearance89.TextVAlignAsString = "Middle";
            this.SlipFontSize_uLabel.Appearance = appearance89;
            this.SlipFontSize_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SlipFontSize_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipFontSize_uLabel.Location = new System.Drawing.Point(542, 172);
            this.SlipFontSize_uLabel.Name = "SlipFontSize_uLabel";
            this.SlipFontSize_uLabel.Size = new System.Drawing.Size(120, 23);
            this.SlipFontSize_uLabel.TabIndex = 36;
            this.SlipFontSize_uLabel.Text = "���Ӑ��";
            // 
            // DetailRowCount_uLabel
            // 
            appearance90.TextVAlignAsString = "Middle";
            this.DetailRowCount_uLabel.Appearance = appearance90;
            this.DetailRowCount_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.DetailRowCount_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DetailRowCount_uLabel.Location = new System.Drawing.Point(542, 288);
            this.DetailRowCount_uLabel.Name = "DetailRowCount_uLabel";
            this.DetailRowCount_uLabel.Size = new System.Drawing.Size(84, 23);
            this.DetailRowCount_uLabel.TabIndex = 40;
            this.DetailRowCount_uLabel.Text = "���׍s��";
            // 
            // PrtCirculation_uLabel
            // 
            appearance196.TextVAlignAsString = "Middle";
            this.PrtCirculation_uLabel.Appearance = appearance196;
            this.PrtCirculation_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrtCirculation_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrtCirculation_uLabel.Location = new System.Drawing.Point(542, 259);
            this.PrtCirculation_uLabel.Name = "PrtCirculation_uLabel";
            this.PrtCirculation_uLabel.Size = new System.Drawing.Size(84, 23);
            this.PrtCirculation_uLabel.TabIndex = 40;
            this.PrtCirculation_uLabel.Text = "�������";
            // 
            // Note3_uLabel
            // 
            appearance186.TextVAlignAsString = "Middle";
            this.Note3_uLabel.Appearance = appearance186;
            this.Note3_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Note3_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note3_uLabel.Location = new System.Drawing.Point(20, 375);
            this.Note3_uLabel.Name = "Note3_uLabel";
            this.Note3_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Note3_uLabel.TabIndex = 12;
            this.Note3_uLabel.Text = "���l�R";
            // 
            // Note2_uLabel
            // 
            appearance189.TextVAlignAsString = "Middle";
            this.Note2_uLabel.Appearance = appearance189;
            this.Note2_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Note2_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note2_uLabel.Location = new System.Drawing.Point(20, 346);
            this.Note2_uLabel.Name = "Note2_uLabel";
            this.Note2_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Note2_uLabel.TabIndex = 12;
            this.Note2_uLabel.Text = "���l�Q";
            // 
            // Note1_uLabel
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.Note1_uLabel.Appearance = appearance37;
            this.Note1_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Note1_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note1_uLabel.Location = new System.Drawing.Point(20, 317);
            this.Note1_uLabel.Name = "Note1_uLabel";
            this.Note1_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Note1_uLabel.TabIndex = 12;
            this.Note1_uLabel.Text = "���l�P";
            // 
            // RefConsTaxPrtNm_uLabel
            // 
            appearance218.TextVAlignAsString = "Middle";
            this.RefConsTaxPrtNm_uLabel.Appearance = appearance218;
            this.RefConsTaxPrtNm_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.RefConsTaxPrtNm_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RefConsTaxPrtNm_uLabel.Location = new System.Drawing.Point(20, 288);
            this.RefConsTaxPrtNm_uLabel.Name = "RefConsTaxPrtNm_uLabel";
            this.RefConsTaxPrtNm_uLabel.Size = new System.Drawing.Size(150, 23);
            this.RefConsTaxPrtNm_uLabel.TabIndex = 12;
            this.RefConsTaxPrtNm_uLabel.Text = "�Q�l����ň󎚖���";
            // 
            // TimePrintDivCd_uLabel
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.TimePrintDivCd_uLabel.Appearance = appearance39;
            this.TimePrintDivCd_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.TimePrintDivCd_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TimePrintDivCd_uLabel.Location = new System.Drawing.Point(542, 201);
            this.TimePrintDivCd_uLabel.Name = "TimePrintDivCd_uLabel";
            this.TimePrintDivCd_uLabel.Size = new System.Drawing.Size(123, 23);
            this.TimePrintDivCd_uLabel.TabIndex = 12;
            this.TimePrintDivCd_uLabel.Text = "������";
            // 
            // QRCodePrintDivCd_uLabel
            // 
            appearance194.TextVAlignAsString = "Middle";
            this.QRCodePrintDivCd_uLabel.Appearance = appearance194;
            this.QRCodePrintDivCd_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.QRCodePrintDivCd_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.QRCodePrintDivCd_uLabel.Location = new System.Drawing.Point(542, 230);
            this.QRCodePrintDivCd_uLabel.Name = "QRCodePrintDivCd_uLabel";
            this.QRCodePrintDivCd_uLabel.Size = new System.Drawing.Size(131, 23);
            this.QRCodePrintDivCd_uLabel.TabIndex = 12;
            this.QRCodePrintDivCd_uLabel.Text = "QR�R�[�h��";
            // 
            // ConsTaxPrtCd_uLabel
            // 
            appearance219.TextVAlignAsString = "Middle";
            this.ConsTaxPrtCd_uLabel.Appearance = appearance219;
            this.ConsTaxPrtCd_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ConsTaxPrtCd_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConsTaxPrtCd_uLabel.Location = new System.Drawing.Point(20, 230);
            this.ConsTaxPrtCd_uLabel.Name = "ConsTaxPrtCd_uLabel";
            this.ConsTaxPrtCd_uLabel.Size = new System.Drawing.Size(123, 23);
            this.ConsTaxPrtCd_uLabel.TabIndex = 12;
            this.ConsTaxPrtCd_uLabel.Text = "����ň�";
            // 
            // RefConsTaxDivCd_uLabel
            // 
            appearance91.TextVAlignAsString = "Middle";
            this.RefConsTaxDivCd_uLabel.Appearance = appearance91;
            this.RefConsTaxDivCd_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.RefConsTaxDivCd_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RefConsTaxDivCd_uLabel.Location = new System.Drawing.Point(20, 259);
            this.RefConsTaxDivCd_uLabel.Name = "RefConsTaxDivCd_uLabel";
            this.RefConsTaxDivCd_uLabel.Size = new System.Drawing.Size(123, 23);
            this.RefConsTaxDivCd_uLabel.TabIndex = 12;
            this.RefConsTaxDivCd_uLabel.Text = "�Q�l�����";
            // 
            // ReissueMark_uLabel
            // 
            appearance211.TextVAlignAsString = "Middle";
            this.ReissueMark_uLabel.Appearance = appearance211;
            this.ReissueMark_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ReissueMark_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReissueMark_uLabel.Location = new System.Drawing.Point(20, 201);
            this.ReissueMark_uLabel.Name = "ReissueMark_uLabel";
            this.ReissueMark_uLabel.Size = new System.Drawing.Size(100, 23);
            this.ReissueMark_uLabel.TabIndex = 12;
            this.ReissueMark_uLabel.Text = "�Ĕ��s�}�[�N";
            // 
            // EnterpriseNamePrtCd_uLabel
            // 
            appearance178.TextVAlignAsString = "Middle";
            this.EnterpriseNamePrtCd_uLabel.Appearance = appearance178;
            this.EnterpriseNamePrtCd_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EnterpriseNamePrtCd_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EnterpriseNamePrtCd_uLabel.Location = new System.Drawing.Point(20, 143);
            this.EnterpriseNamePrtCd_uLabel.Name = "EnterpriseNamePrtCd_uLabel";
            this.EnterpriseNamePrtCd_uLabel.Size = new System.Drawing.Size(100, 23);
            this.EnterpriseNamePrtCd_uLabel.TabIndex = 12;
            this.EnterpriseNamePrtCd_uLabel.Text = "���Ж����";
            // 
            // ultraLabel21
            // 
            appearance202.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance202;
            this.ultraLabel21.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel21.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(710, 288);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel21.TabIndex = 42;
            this.ultraLabel21.Text = "�s";
            // 
            // ultraLabel1
            // 
            appearance197.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance197;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(710, 259);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel1.TabIndex = 42;
            this.ultraLabel1.Text = "��";
            // 
            // OutConMsg_uLabel
            // 
            appearance203.TextVAlignAsString = "Middle";
            this.OutConMsg_uLabel.Appearance = appearance203;
            this.OutConMsg_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.OutConMsg_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OutConMsg_uLabel.Location = new System.Drawing.Point(20, 103);
            this.OutConMsg_uLabel.Name = "OutConMsg_uLabel";
            this.OutConMsg_uLabel.Size = new System.Drawing.Size(150, 23);
            this.OutConMsg_uLabel.TabIndex = 9;
            this.OutConMsg_uLabel.Text = "�o�͊m�F���b�Z�[�W";
            // 
            // DataInputSystem_uLabel
            // 
            appearance95.TextVAlignAsString = "Middle";
            this.DataInputSystem_uLabel.Appearance = appearance95;
            this.DataInputSystem_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.DataInputSystem_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataInputSystem_uLabel.Location = new System.Drawing.Point(385, 7);
            this.DataInputSystem_uLabel.Name = "DataInputSystem_uLabel";
            this.DataInputSystem_uLabel.Size = new System.Drawing.Size(220, 23);
            this.DataInputSystem_uLabel.TabIndex = 0;
            this.DataInputSystem_uLabel.Text = "�f�[�^���̓V�X�e��(��\��)";
            this.DataInputSystem_uLabel.Visible = false;
            // 
            // PrtPreviewExistCode_uLabel
            // 
            appearance98.TextVAlignAsString = "Middle";
            this.PrtPreviewExistCode_uLabel.Appearance = appearance98;
            this.PrtPreviewExistCode_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrtPreviewExistCode_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrtPreviewExistCode_uLabel.Location = new System.Drawing.Point(542, 143);
            this.PrtPreviewExistCode_uLabel.Name = "PrtPreviewExistCode_uLabel";
            this.PrtPreviewExistCode_uLabel.Size = new System.Drawing.Size(120, 23);
            this.PrtPreviewExistCode_uLabel.TabIndex = 14;
            this.PrtPreviewExistCode_uLabel.Text = "����v���r���[";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel10);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel38);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel39);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel40);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel41);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel42);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel37);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel9);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel18);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel33);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel34);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel35);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel36);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel26);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel28);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel29);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel30);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel31);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel32);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel8);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel27);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel25);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel24);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel23);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel22);
            this.ultraTabPageControl2.Controls.Add(this.TitleName405_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName404_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName403_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName402_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName305_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName304_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName303_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName302_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel17);
            this.ultraTabPageControl2.Controls.Add(this.TitleName205_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName204_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName203_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName202_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName105_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName104_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName103_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName102_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel7);
            this.ultraTabPageControl2.Controls.Add(this.TitleName4_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName3_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName2_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName1_tEdit);
            this.ultraTabPageControl2.Controls.Add(this.TitleName_uLabel);
            this.ultraTabPageControl2.Controls.Add(this.ImageColorGuide4_uButton);
            this.ultraTabPageControl2.Controls.Add(this.SlipBaseColor4_uLabel);
            this.ultraTabPageControl2.Controls.Add(this.ImageColorGuide3_uButton);
            this.ultraTabPageControl2.Controls.Add(this.SlipBaseColor3_uLabel);
            this.ultraTabPageControl2.Controls.Add(this.ImageColorGuide2_uButton);
            this.ultraTabPageControl2.Controls.Add(this.SlipBaseColor2_uLabel);
            this.ultraTabPageControl2.Controls.Add(this.ImageColorGuide1_uButton);
            this.ultraTabPageControl2.Controls.Add(this.SlipBaseColor1_uLabel);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(949, 664);
            // 
            // ultraLabel10
            // 
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance99;
            this.ultraLabel10.Location = new System.Drawing.Point(508, 406);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel10.TabIndex = 63;
            this.ultraLabel10.Text = "�`�[�W���F";
            // 
            // ultraLabel38
            // 
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance100;
            this.ultraLabel38.Location = new System.Drawing.Point(508, 376);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel38.TabIndex = 62;
            this.ultraLabel38.Text = "�^�C�g���T";
            // 
            // ultraLabel39
            // 
            appearance101.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance101;
            this.ultraLabel39.Location = new System.Drawing.Point(508, 349);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel39.TabIndex = 61;
            this.ultraLabel39.Text = "�^�C�g���S";
            // 
            // ultraLabel40
            // 
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance102;
            this.ultraLabel40.Location = new System.Drawing.Point(508, 322);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel40.TabIndex = 58;
            this.ultraLabel40.Text = "�^�C�g���R";
            // 
            // ultraLabel41
            // 
            appearance103.TextVAlignAsString = "Middle";
            this.ultraLabel41.Appearance = appearance103;
            this.ultraLabel41.Location = new System.Drawing.Point(508, 295);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel41.TabIndex = 57;
            this.ultraLabel41.Text = "�^�C�g���Q";
            // 
            // ultraLabel42
            // 
            appearance104.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance104;
            this.ultraLabel42.Location = new System.Drawing.Point(508, 268);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel42.TabIndex = 56;
            this.ultraLabel42.Text = "�^�C�g���P";
            // 
            // ultraLabel37
            // 
            appearance105.BackColor = System.Drawing.SystemColors.Highlight;
            appearance105.ForeColor = System.Drawing.Color.White;
            appearance105.TextHAlignAsString = "Center";
            appearance105.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance105;
            this.ultraLabel37.Location = new System.Drawing.Point(600, 240);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(322, 23);
            this.ultraLabel37.TabIndex = 55;
            this.ultraLabel37.Text = "�`�[�^�C�g��(�S����)";
            // 
            // ultraLabel9
            // 
            appearance106.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance106;
            this.ultraLabel9.Location = new System.Drawing.Point(508, 186);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel9.TabIndex = 54;
            this.ultraLabel9.Text = "�`�[�W���F";
            // 
            // ultraLabel18
            // 
            appearance107.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance107;
            this.ultraLabel18.Location = new System.Drawing.Point(508, 156);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel18.TabIndex = 53;
            this.ultraLabel18.Text = "�^�C�g���T";
            // 
            // ultraLabel33
            // 
            appearance108.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance108;
            this.ultraLabel33.Location = new System.Drawing.Point(508, 129);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel33.TabIndex = 52;
            this.ultraLabel33.Text = "�^�C�g���S";
            // 
            // ultraLabel34
            // 
            appearance109.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance109;
            this.ultraLabel34.Location = new System.Drawing.Point(508, 102);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel34.TabIndex = 51;
            this.ultraLabel34.Text = "�^�C�g���R";
            // 
            // ultraLabel35
            // 
            appearance110.TextVAlignAsString = "Middle";
            this.ultraLabel35.Appearance = appearance110;
            this.ultraLabel35.Location = new System.Drawing.Point(508, 75);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel35.TabIndex = 50;
            this.ultraLabel35.Text = "�^�C�g���Q";
            // 
            // ultraLabel36
            // 
            appearance111.TextVAlignAsString = "Middle";
            this.ultraLabel36.Appearance = appearance111;
            this.ultraLabel36.Location = new System.Drawing.Point(508, 48);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel36.TabIndex = 49;
            this.ultraLabel36.Text = "�^�C�g���P";
            // 
            // ultraLabel26
            // 
            appearance112.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance112;
            this.ultraLabel26.Location = new System.Drawing.Point(32, 406);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel26.TabIndex = 48;
            this.ultraLabel26.Text = "�`�[�W���F";
            // 
            // ultraLabel28
            // 
            appearance113.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance113;
            this.ultraLabel28.Location = new System.Drawing.Point(32, 376);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel28.TabIndex = 47;
            this.ultraLabel28.Text = "�^�C�g���T";
            // 
            // ultraLabel29
            // 
            appearance114.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance114;
            this.ultraLabel29.Location = new System.Drawing.Point(32, 349);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel29.TabIndex = 46;
            this.ultraLabel29.Text = "�^�C�g���S";
            // 
            // ultraLabel30
            // 
            appearance115.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance115;
            this.ultraLabel30.Location = new System.Drawing.Point(32, 322);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel30.TabIndex = 45;
            this.ultraLabel30.Text = "�^�C�g���R";
            // 
            // ultraLabel31
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance116;
            this.ultraLabel31.Location = new System.Drawing.Point(32, 295);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel31.TabIndex = 44;
            this.ultraLabel31.Text = "�^�C�g���Q";
            // 
            // ultraLabel32
            // 
            appearance117.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance117;
            this.ultraLabel32.Location = new System.Drawing.Point(32, 268);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel32.TabIndex = 43;
            this.ultraLabel32.Text = "�^�C�g���P";
            // 
            // ultraLabel8
            // 
            appearance118.BackColor = System.Drawing.SystemColors.Highlight;
            appearance118.ForeColor = System.Drawing.Color.White;
            appearance118.TextHAlignAsString = "Center";
            appearance118.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance118;
            this.ultraLabel8.Location = new System.Drawing.Point(124, 240);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(322, 23);
            this.ultraLabel8.TabIndex = 42;
            this.ultraLabel8.Text = "�`�[�^�C�g��(�Q����)";
            // 
            // ultraLabel27
            // 
            appearance119.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance119;
            this.ultraLabel27.Location = new System.Drawing.Point(32, 186);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel27.TabIndex = 41;
            this.ultraLabel27.Text = "�`�[�W���F";
            // 
            // ultraLabel25
            // 
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance120;
            this.ultraLabel25.Location = new System.Drawing.Point(32, 156);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel25.TabIndex = 39;
            this.ultraLabel25.Text = "�^�C�g���T";
            // 
            // ultraLabel24
            // 
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance121;
            this.ultraLabel24.Location = new System.Drawing.Point(32, 129);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel24.TabIndex = 38;
            this.ultraLabel24.Text = "�^�C�g���S";
            // 
            // ultraLabel23
            // 
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance122;
            this.ultraLabel23.Location = new System.Drawing.Point(32, 102);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel23.TabIndex = 37;
            this.ultraLabel23.Text = "�^�C�g���R";
            // 
            // ultraLabel22
            // 
            appearance123.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance123;
            this.ultraLabel22.Location = new System.Drawing.Point(32, 75);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel22.TabIndex = 36;
            this.ultraLabel22.Text = "�^�C�g���Q";
            // 
            // TitleName405_tEdit
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance124.ForeColor = System.Drawing.Color.Black;
            this.TitleName405_tEdit.ActiveAppearance = appearance124;
            appearance125.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance125.ForeColor = System.Drawing.Color.Black;
            appearance125.ForeColorDisabled = System.Drawing.Color.Black;
            appearance125.TextVAlignAsString = "Middle";
            this.TitleName405_tEdit.Appearance = appearance125;
            this.TitleName405_tEdit.AutoSelect = true;
            this.TitleName405_tEdit.DataText = "";
            this.TitleName405_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName405_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName405_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName405_tEdit.Location = new System.Drawing.Point(600, 376);
            this.TitleName405_tEdit.MaxLength = 20;
            this.TitleName405_tEdit.Name = "TitleName405_tEdit";
            this.TitleName405_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName405_tEdit.TabIndex = 35;
            // 
            // TitleName404_tEdit
            // 
            appearance126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance126.ForeColor = System.Drawing.Color.Black;
            this.TitleName404_tEdit.ActiveAppearance = appearance126;
            appearance127.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance127.ForeColor = System.Drawing.Color.Black;
            appearance127.ForeColorDisabled = System.Drawing.Color.Black;
            appearance127.TextVAlignAsString = "Middle";
            this.TitleName404_tEdit.Appearance = appearance127;
            this.TitleName404_tEdit.AutoSelect = true;
            this.TitleName404_tEdit.DataText = "";
            this.TitleName404_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName404_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName404_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName404_tEdit.Location = new System.Drawing.Point(600, 349);
            this.TitleName404_tEdit.MaxLength = 20;
            this.TitleName404_tEdit.Name = "TitleName404_tEdit";
            this.TitleName404_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName404_tEdit.TabIndex = 34;
            // 
            // TitleName403_tEdit
            // 
            appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance128.ForeColor = System.Drawing.Color.Black;
            this.TitleName403_tEdit.ActiveAppearance = appearance128;
            appearance129.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance129.ForeColor = System.Drawing.Color.Black;
            appearance129.ForeColorDisabled = System.Drawing.Color.Black;
            appearance129.TextVAlignAsString = "Middle";
            this.TitleName403_tEdit.Appearance = appearance129;
            this.TitleName403_tEdit.AutoSelect = true;
            this.TitleName403_tEdit.DataText = "";
            this.TitleName403_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName403_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName403_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName403_tEdit.Location = new System.Drawing.Point(600, 322);
            this.TitleName403_tEdit.MaxLength = 20;
            this.TitleName403_tEdit.Name = "TitleName403_tEdit";
            this.TitleName403_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName403_tEdit.TabIndex = 33;
            // 
            // TitleName402_tEdit
            // 
            appearance130.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance130.ForeColor = System.Drawing.Color.Black;
            this.TitleName402_tEdit.ActiveAppearance = appearance130;
            appearance131.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance131.ForeColor = System.Drawing.Color.Black;
            appearance131.ForeColorDisabled = System.Drawing.Color.Black;
            appearance131.TextVAlignAsString = "Middle";
            this.TitleName402_tEdit.Appearance = appearance131;
            this.TitleName402_tEdit.AutoSelect = true;
            this.TitleName402_tEdit.DataText = "";
            this.TitleName402_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName402_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName402_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName402_tEdit.Location = new System.Drawing.Point(600, 295);
            this.TitleName402_tEdit.MaxLength = 20;
            this.TitleName402_tEdit.Name = "TitleName402_tEdit";
            this.TitleName402_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName402_tEdit.TabIndex = 32;
            // 
            // TitleName305_tEdit
            // 
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance132.ForeColor = System.Drawing.Color.Black;
            this.TitleName305_tEdit.ActiveAppearance = appearance132;
            appearance133.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance133.ForeColor = System.Drawing.Color.Black;
            appearance133.ForeColorDisabled = System.Drawing.Color.Black;
            appearance133.TextVAlignAsString = "Middle";
            this.TitleName305_tEdit.Appearance = appearance133;
            this.TitleName305_tEdit.AutoSelect = true;
            this.TitleName305_tEdit.DataText = "";
            this.TitleName305_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName305_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName305_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName305_tEdit.Location = new System.Drawing.Point(600, 156);
            this.TitleName305_tEdit.MaxLength = 20;
            this.TitleName305_tEdit.Name = "TitleName305_tEdit";
            this.TitleName305_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName305_tEdit.TabIndex = 27;
            // 
            // TitleName304_tEdit
            // 
            appearance134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance134.ForeColor = System.Drawing.Color.Black;
            this.TitleName304_tEdit.ActiveAppearance = appearance134;
            appearance135.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance135.ForeColor = System.Drawing.Color.Black;
            appearance135.ForeColorDisabled = System.Drawing.Color.Black;
            appearance135.TextVAlignAsString = "Middle";
            this.TitleName304_tEdit.Appearance = appearance135;
            this.TitleName304_tEdit.AutoSelect = true;
            this.TitleName304_tEdit.DataText = "";
            this.TitleName304_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName304_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName304_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName304_tEdit.Location = new System.Drawing.Point(600, 129);
            this.TitleName304_tEdit.MaxLength = 20;
            this.TitleName304_tEdit.Name = "TitleName304_tEdit";
            this.TitleName304_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName304_tEdit.TabIndex = 26;
            // 
            // TitleName303_tEdit
            // 
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance136.ForeColor = System.Drawing.Color.Black;
            this.TitleName303_tEdit.ActiveAppearance = appearance136;
            appearance137.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance137.ForeColor = System.Drawing.Color.Black;
            appearance137.ForeColorDisabled = System.Drawing.Color.Black;
            appearance137.TextVAlignAsString = "Middle";
            this.TitleName303_tEdit.Appearance = appearance137;
            this.TitleName303_tEdit.AutoSelect = true;
            this.TitleName303_tEdit.DataText = "";
            this.TitleName303_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName303_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName303_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName303_tEdit.Location = new System.Drawing.Point(600, 102);
            this.TitleName303_tEdit.MaxLength = 20;
            this.TitleName303_tEdit.Name = "TitleName303_tEdit";
            this.TitleName303_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName303_tEdit.TabIndex = 25;
            // 
            // TitleName302_tEdit
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance138.ForeColor = System.Drawing.Color.Black;
            this.TitleName302_tEdit.ActiveAppearance = appearance138;
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColor = System.Drawing.Color.Black;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            appearance139.TextVAlignAsString = "Middle";
            this.TitleName302_tEdit.Appearance = appearance139;
            this.TitleName302_tEdit.AutoSelect = true;
            this.TitleName302_tEdit.DataText = "";
            this.TitleName302_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName302_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName302_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName302_tEdit.Location = new System.Drawing.Point(600, 75);
            this.TitleName302_tEdit.MaxLength = 20;
            this.TitleName302_tEdit.Name = "TitleName302_tEdit";
            this.TitleName302_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName302_tEdit.TabIndex = 24;
            // 
            // ultraLabel17
            // 
            appearance140.BackColor = System.Drawing.SystemColors.Highlight;
            appearance140.ForeColor = System.Drawing.Color.White;
            appearance140.TextHAlignAsString = "Center";
            appearance140.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance140;
            this.ultraLabel17.Location = new System.Drawing.Point(600, 21);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(322, 23);
            this.ultraLabel17.TabIndex = 18;
            this.ultraLabel17.Text = "�`�[�^�C�g��(�R����)";
            // 
            // TitleName205_tEdit
            // 
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance141.ForeColor = System.Drawing.Color.Black;
            this.TitleName205_tEdit.ActiveAppearance = appearance141;
            appearance142.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance142.ForeColor = System.Drawing.Color.Black;
            appearance142.ForeColorDisabled = System.Drawing.Color.Black;
            appearance142.TextVAlignAsString = "Middle";
            this.TitleName205_tEdit.Appearance = appearance142;
            this.TitleName205_tEdit.AutoSelect = true;
            this.TitleName205_tEdit.DataText = "";
            this.TitleName205_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName205_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName205_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName205_tEdit.Location = new System.Drawing.Point(124, 376);
            this.TitleName205_tEdit.MaxLength = 20;
            this.TitleName205_tEdit.Name = "TitleName205_tEdit";
            this.TitleName205_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName205_tEdit.TabIndex = 17;
            // 
            // TitleName204_tEdit
            // 
            appearance143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance143.ForeColor = System.Drawing.Color.Black;
            this.TitleName204_tEdit.ActiveAppearance = appearance143;
            appearance144.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance144.ForeColor = System.Drawing.Color.Black;
            appearance144.ForeColorDisabled = System.Drawing.Color.Black;
            appearance144.TextVAlignAsString = "Middle";
            this.TitleName204_tEdit.Appearance = appearance144;
            this.TitleName204_tEdit.AutoSelect = true;
            this.TitleName204_tEdit.DataText = "";
            this.TitleName204_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName204_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName204_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName204_tEdit.Location = new System.Drawing.Point(124, 349);
            this.TitleName204_tEdit.MaxLength = 20;
            this.TitleName204_tEdit.Name = "TitleName204_tEdit";
            this.TitleName204_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName204_tEdit.TabIndex = 16;
            // 
            // TitleName203_tEdit
            // 
            appearance145.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance145.ForeColor = System.Drawing.Color.Black;
            this.TitleName203_tEdit.ActiveAppearance = appearance145;
            appearance146.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance146.ForeColor = System.Drawing.Color.Black;
            appearance146.ForeColorDisabled = System.Drawing.Color.Black;
            appearance146.TextVAlignAsString = "Middle";
            this.TitleName203_tEdit.Appearance = appearance146;
            this.TitleName203_tEdit.AutoSelect = true;
            this.TitleName203_tEdit.DataText = "";
            this.TitleName203_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName203_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName203_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName203_tEdit.Location = new System.Drawing.Point(124, 322);
            this.TitleName203_tEdit.MaxLength = 20;
            this.TitleName203_tEdit.Name = "TitleName203_tEdit";
            this.TitleName203_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName203_tEdit.TabIndex = 15;
            // 
            // TitleName202_tEdit
            // 
            appearance147.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance147.ForeColor = System.Drawing.Color.Black;
            this.TitleName202_tEdit.ActiveAppearance = appearance147;
            appearance148.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance148.ForeColor = System.Drawing.Color.Black;
            appearance148.ForeColorDisabled = System.Drawing.Color.Black;
            appearance148.TextVAlignAsString = "Middle";
            this.TitleName202_tEdit.Appearance = appearance148;
            this.TitleName202_tEdit.AutoSelect = true;
            this.TitleName202_tEdit.DataText = "";
            this.TitleName202_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName202_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName202_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName202_tEdit.Location = new System.Drawing.Point(124, 295);
            this.TitleName202_tEdit.MaxLength = 20;
            this.TitleName202_tEdit.Name = "TitleName202_tEdit";
            this.TitleName202_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName202_tEdit.TabIndex = 14;
            // 
            // TitleName105_tEdit
            // 
            appearance149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance149.ForeColor = System.Drawing.Color.Black;
            this.TitleName105_tEdit.ActiveAppearance = appearance149;
            appearance150.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance150.ForeColor = System.Drawing.Color.Black;
            appearance150.ForeColorDisabled = System.Drawing.Color.Black;
            appearance150.TextVAlignAsString = "Middle";
            this.TitleName105_tEdit.Appearance = appearance150;
            this.TitleName105_tEdit.AutoSelect = true;
            this.TitleName105_tEdit.DataText = "";
            this.TitleName105_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName105_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName105_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName105_tEdit.Location = new System.Drawing.Point(124, 156);
            this.TitleName105_tEdit.MaxLength = 20;
            this.TitleName105_tEdit.Name = "TitleName105_tEdit";
            this.TitleName105_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName105_tEdit.TabIndex = 9;
            // 
            // TitleName104_tEdit
            // 
            appearance151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance151.ForeColor = System.Drawing.Color.Black;
            this.TitleName104_tEdit.ActiveAppearance = appearance151;
            appearance152.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance152.ForeColor = System.Drawing.Color.Black;
            appearance152.ForeColorDisabled = System.Drawing.Color.Black;
            appearance152.TextVAlignAsString = "Middle";
            this.TitleName104_tEdit.Appearance = appearance152;
            this.TitleName104_tEdit.AutoSelect = true;
            this.TitleName104_tEdit.DataText = "";
            this.TitleName104_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName104_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName104_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName104_tEdit.Location = new System.Drawing.Point(124, 129);
            this.TitleName104_tEdit.MaxLength = 20;
            this.TitleName104_tEdit.Name = "TitleName104_tEdit";
            this.TitleName104_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName104_tEdit.TabIndex = 8;
            // 
            // TitleName103_tEdit
            // 
            appearance153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance153.ForeColor = System.Drawing.Color.Black;
            this.TitleName103_tEdit.ActiveAppearance = appearance153;
            appearance154.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance154.ForeColor = System.Drawing.Color.Black;
            appearance154.ForeColorDisabled = System.Drawing.Color.Black;
            appearance154.TextVAlignAsString = "Middle";
            this.TitleName103_tEdit.Appearance = appearance154;
            this.TitleName103_tEdit.AutoSelect = true;
            this.TitleName103_tEdit.DataText = "";
            this.TitleName103_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName103_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName103_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName103_tEdit.Location = new System.Drawing.Point(124, 102);
            this.TitleName103_tEdit.MaxLength = 20;
            this.TitleName103_tEdit.Name = "TitleName103_tEdit";
            this.TitleName103_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName103_tEdit.TabIndex = 5;
            // 
            // TitleName102_tEdit
            // 
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance155.ForeColor = System.Drawing.Color.Black;
            this.TitleName102_tEdit.ActiveAppearance = appearance155;
            appearance156.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance156.ForeColor = System.Drawing.Color.Black;
            appearance156.ForeColorDisabled = System.Drawing.Color.Black;
            appearance156.TextVAlignAsString = "Middle";
            this.TitleName102_tEdit.Appearance = appearance156;
            this.TitleName102_tEdit.AutoSelect = true;
            this.TitleName102_tEdit.DataText = "";
            this.TitleName102_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName102_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName102_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName102_tEdit.Location = new System.Drawing.Point(124, 75);
            this.TitleName102_tEdit.MaxLength = 20;
            this.TitleName102_tEdit.Name = "TitleName102_tEdit";
            this.TitleName102_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName102_tEdit.TabIndex = 4;
            // 
            // ultraLabel7
            // 
            appearance157.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance157;
            this.ultraLabel7.Location = new System.Drawing.Point(32, 48);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel7.TabIndex = 2;
            this.ultraLabel7.Text = "�^�C�g���P";
            // 
            // TitleName4_tEdit
            // 
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance158.ForeColor = System.Drawing.Color.Black;
            this.TitleName4_tEdit.ActiveAppearance = appearance158;
            appearance159.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            appearance159.TextVAlignAsString = "Middle";
            this.TitleName4_tEdit.Appearance = appearance159;
            this.TitleName4_tEdit.AutoSelect = true;
            this.TitleName4_tEdit.DataText = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            this.TitleName4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName4_tEdit.Location = new System.Drawing.Point(600, 268);
            this.TitleName4_tEdit.MaxLength = 20;
            this.TitleName4_tEdit.Name = "TitleName4_tEdit";
            this.TitleName4_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName4_tEdit.TabIndex = 31;
            this.TitleName4_tEdit.Text = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            // 
            // TitleName3_tEdit
            // 
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance160.ForeColor = System.Drawing.Color.Black;
            this.TitleName3_tEdit.ActiveAppearance = appearance160;
            appearance161.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance161.ForeColor = System.Drawing.Color.Black;
            appearance161.ForeColorDisabled = System.Drawing.Color.Black;
            appearance161.TextVAlignAsString = "Middle";
            this.TitleName3_tEdit.Appearance = appearance161;
            this.TitleName3_tEdit.AutoSelect = true;
            this.TitleName3_tEdit.DataText = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            this.TitleName3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName3_tEdit.Location = new System.Drawing.Point(600, 48);
            this.TitleName3_tEdit.MaxLength = 20;
            this.TitleName3_tEdit.Name = "TitleName3_tEdit";
            this.TitleName3_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName3_tEdit.TabIndex = 23;
            this.TitleName3_tEdit.Text = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            // 
            // TitleName2_tEdit
            // 
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance162.ForeColor = System.Drawing.Color.Black;
            this.TitleName2_tEdit.ActiveAppearance = appearance162;
            appearance163.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance163.ForeColor = System.Drawing.Color.Black;
            appearance163.ForeColorDisabled = System.Drawing.Color.Black;
            appearance163.TextVAlignAsString = "Middle";
            this.TitleName2_tEdit.Appearance = appearance163;
            this.TitleName2_tEdit.AutoSelect = true;
            this.TitleName2_tEdit.DataText = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            this.TitleName2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName2_tEdit.Location = new System.Drawing.Point(124, 268);
            this.TitleName2_tEdit.MaxLength = 20;
            this.TitleName2_tEdit.Name = "TitleName2_tEdit";
            this.TitleName2_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName2_tEdit.TabIndex = 13;
            this.TitleName2_tEdit.Text = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            // 
            // TitleName1_tEdit
            // 
            appearance164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance164.ForeColor = System.Drawing.Color.Black;
            this.TitleName1_tEdit.ActiveAppearance = appearance164;
            appearance165.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance165.ForeColor = System.Drawing.Color.Black;
            appearance165.ForeColorDisabled = System.Drawing.Color.Black;
            appearance165.TextVAlignAsString = "Middle";
            this.TitleName1_tEdit.Appearance = appearance165;
            this.TitleName1_tEdit.AutoSelect = true;
            this.TitleName1_tEdit.DataText = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            this.TitleName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TitleName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TitleName1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TitleName1_tEdit.Location = new System.Drawing.Point(124, 48);
            this.TitleName1_tEdit.MaxLength = 20;
            this.TitleName1_tEdit.Name = "TitleName1_tEdit";
            this.TitleName1_tEdit.Size = new System.Drawing.Size(314, 24);
            this.TitleName1_tEdit.TabIndex = 3;
            this.TitleName1_tEdit.Text = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            // 
            // TitleName_uLabel
            // 
            appearance166.BackColor = System.Drawing.SystemColors.Highlight;
            appearance166.ForeColor = System.Drawing.Color.White;
            appearance166.TextHAlignAsString = "Center";
            appearance166.TextVAlignAsString = "Middle";
            this.TitleName_uLabel.Appearance = appearance166;
            this.TitleName_uLabel.Location = new System.Drawing.Point(124, 21);
            this.TitleName_uLabel.Name = "TitleName_uLabel";
            this.TitleName_uLabel.Size = new System.Drawing.Size(322, 23);
            this.TitleName_uLabel.TabIndex = 0;
            this.TitleName_uLabel.Text = "�`�[�^�C�g��(�P����)";
            // 
            // ImageColorGuide4_uButton
            // 
            this.ImageColorGuide4_uButton.Location = new System.Drawing.Point(660, 406);
            this.ImageColorGuide4_uButton.Name = "ImageColorGuide4_uButton";
            this.ImageColorGuide4_uButton.Size = new System.Drawing.Size(25, 24);
            this.ImageColorGuide4_uButton.TabIndex = 36;
            ultraToolTipInfo1.ToolTipText = "�F�̐ݒ�";
            this.ultraToolTipManager1.SetUltraToolTip(this.ImageColorGuide4_uButton, ultraToolTipInfo1);
            this.ImageColorGuide4_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ImageColorGuide4_uButton.Click += new System.EventHandler(this.ImageColorGuide_Click);
            // 
            // SlipBaseColor4_uLabel
            // 
            appearance167.BorderColor = System.Drawing.Color.Black;
            appearance167.TextHAlignAsString = "Right";
            appearance167.TextVAlignAsString = "Middle";
            this.SlipBaseColor4_uLabel.Appearance = appearance167;
            this.SlipBaseColor4_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.SlipBaseColor4_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SlipBaseColor4_uLabel.Enabled = false;
            this.SlipBaseColor4_uLabel.Location = new System.Drawing.Point(600, 406);
            this.SlipBaseColor4_uLabel.Name = "SlipBaseColor4_uLabel";
            this.SlipBaseColor4_uLabel.Size = new System.Drawing.Size(58, 24);
            this.SlipBaseColor4_uLabel.TabIndex = 37;
            // 
            // ImageColorGuide3_uButton
            // 
            this.ImageColorGuide3_uButton.Location = new System.Drawing.Point(660, 187);
            this.ImageColorGuide3_uButton.Name = "ImageColorGuide3_uButton";
            this.ImageColorGuide3_uButton.Size = new System.Drawing.Size(25, 24);
            this.ImageColorGuide3_uButton.TabIndex = 28;
            ultraToolTipInfo2.ToolTipText = "�F�̐ݒ�";
            this.ultraToolTipManager1.SetUltraToolTip(this.ImageColorGuide3_uButton, ultraToolTipInfo2);
            this.ImageColorGuide3_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ImageColorGuide3_uButton.Click += new System.EventHandler(this.ImageColorGuide_Click);
            // 
            // SlipBaseColor3_uLabel
            // 
            appearance168.BorderColor = System.Drawing.Color.Black;
            appearance168.TextHAlignAsString = "Right";
            appearance168.TextVAlignAsString = "Middle";
            this.SlipBaseColor3_uLabel.Appearance = appearance168;
            this.SlipBaseColor3_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.SlipBaseColor3_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SlipBaseColor3_uLabel.Enabled = false;
            this.SlipBaseColor3_uLabel.Location = new System.Drawing.Point(600, 186);
            this.SlipBaseColor3_uLabel.Name = "SlipBaseColor3_uLabel";
            this.SlipBaseColor3_uLabel.Size = new System.Drawing.Size(58, 24);
            this.SlipBaseColor3_uLabel.TabIndex = 29;
            // 
            // ImageColorGuide2_uButton
            // 
            this.ImageColorGuide2_uButton.Location = new System.Drawing.Point(184, 406);
            this.ImageColorGuide2_uButton.Name = "ImageColorGuide2_uButton";
            this.ImageColorGuide2_uButton.Size = new System.Drawing.Size(25, 24);
            this.ImageColorGuide2_uButton.TabIndex = 18;
            ultraToolTipInfo3.ToolTipText = "�F�̐ݒ�";
            this.ultraToolTipManager1.SetUltraToolTip(this.ImageColorGuide2_uButton, ultraToolTipInfo3);
            this.ImageColorGuide2_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ImageColorGuide2_uButton.Click += new System.EventHandler(this.ImageColorGuide_Click);
            // 
            // SlipBaseColor2_uLabel
            // 
            appearance169.BorderColor = System.Drawing.Color.Black;
            appearance169.TextHAlignAsString = "Right";
            appearance169.TextVAlignAsString = "Middle";
            this.SlipBaseColor2_uLabel.Appearance = appearance169;
            this.SlipBaseColor2_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.SlipBaseColor2_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SlipBaseColor2_uLabel.Enabled = false;
            this.SlipBaseColor2_uLabel.Location = new System.Drawing.Point(124, 406);
            this.SlipBaseColor2_uLabel.Name = "SlipBaseColor2_uLabel";
            this.SlipBaseColor2_uLabel.Size = new System.Drawing.Size(58, 24);
            this.SlipBaseColor2_uLabel.TabIndex = 19;
            // 
            // ImageColorGuide1_uButton
            // 
            this.ImageColorGuide1_uButton.Location = new System.Drawing.Point(184, 186);
            this.ImageColorGuide1_uButton.Name = "ImageColorGuide1_uButton";
            this.ImageColorGuide1_uButton.Size = new System.Drawing.Size(25, 24);
            this.ImageColorGuide1_uButton.TabIndex = 10;
            ultraToolTipInfo4.ToolTipText = "�F�̐ݒ�";
            this.ultraToolTipManager1.SetUltraToolTip(this.ImageColorGuide1_uButton, ultraToolTipInfo4);
            this.ImageColorGuide1_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ImageColorGuide1_uButton.Click += new System.EventHandler(this.ImageColorGuide_Click);
            // 
            // SlipBaseColor1_uLabel
            // 
            appearance170.BorderColor = System.Drawing.Color.Black;
            appearance170.TextHAlignAsString = "Right";
            appearance170.TextVAlignAsString = "Middle";
            this.SlipBaseColor1_uLabel.Appearance = appearance170;
            this.SlipBaseColor1_uLabel.BackColorInternal = System.Drawing.Color.White;
            this.SlipBaseColor1_uLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SlipBaseColor1_uLabel.Enabled = false;
            this.SlipBaseColor1_uLabel.Location = new System.Drawing.Point(124, 186);
            this.SlipBaseColor1_uLabel.Name = "SlipBaseColor1_uLabel";
            this.SlipBaseColor1_uLabel.Size = new System.Drawing.Size(58, 24);
            this.SlipBaseColor1_uLabel.TabIndex = 11;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ultraStatusBar1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 736);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(961, 23);
            this.ultraStatusBar1.TabIndex = 3;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(832, 698);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 40;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.Ok_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(703, 698);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 38;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // MainTabControl
            // 
            appearance171.BackColor2 = System.Drawing.Color.LightPink;
            appearance171.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.MainTabControl.ActiveTabAppearance = appearance171;
            appearance172.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance172.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance172.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.MainTabControl.Appearance = appearance172;
            this.MainTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.MainTabControl.Controls.Add(this.ultraTabPageControl1);
            this.MainTabControl.Controls.Add(this.ultraTabPageControl2);
            this.MainTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.MainTabControl.Location = new System.Drawing.Point(6, 6);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.MainTabControl.Size = new System.Drawing.Size(951, 686);
            this.MainTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowFixed;
            appearance173.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance173.BackColor2 = System.Drawing.Color.LightPink;
            ultraTab1.ActiveAppearance = appearance173;
            appearance174.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance174.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance174.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.ClientAreaAppearance = appearance174;
            ultraTab1.Key = "SlipPrtSet";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "�`�[����e��ݒ�";
            appearance175.BackColor = System.Drawing.Color.White;
            appearance175.BackColor2 = System.Drawing.Color.LightPink;
            ultraTab2.ActiveAppearance = appearance175;
            appearance176.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance176.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance176.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.ClientAreaAppearance = appearance176;
            ultraTab2.Key = "SlipPrtSetTitle";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "�`�[�^�C�g���ݒ�";
            this.MainTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.MainTabControl.TabStop = false;
            this.MainTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.MainTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.MainTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.MainTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.MainTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(949, 664);
            // 
            // Mode_Label
            // 
            appearance177.ForeColor = System.Drawing.Color.White;
            appearance177.TextHAlignAsString = "Center";
            appearance177.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance177;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(852, 3);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 4;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.AlwaysEvent = true;
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // FontDialog
            // 
            this.FontDialog.AllowScriptChange = false;
            this.FontDialog.AllowVerticalFonts = false;
            this.FontDialog.FontMustExist = true;
            this.FontDialog.ScriptsOnly = true;
            this.FontDialog.ShowEffects = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(574, 698);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 37;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(703, 698);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 39;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // SCMAnsMarkPrtDiv_tComboEditor
            // 
            appearance191.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance191.ForeColor = System.Drawing.Color.Black;
            this.SCMAnsMarkPrtDiv_tComboEditor.ActiveAppearance = appearance191;
            appearance192.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance192.ForeColor = System.Drawing.Color.Black;
            appearance192.ForeColorDisabled = System.Drawing.Color.Black;
            appearance192.TextVAlignAsString = "Middle";
            this.SCMAnsMarkPrtDiv_tComboEditor.Appearance = appearance192;
            this.SCMAnsMarkPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SCMAnsMarkPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance193.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SCMAnsMarkPrtDiv_tComboEditor.ItemAppearance = appearance193;
            this.SCMAnsMarkPrtDiv_tComboEditor.Location = new System.Drawing.Point(176, 411);
            this.SCMAnsMarkPrtDiv_tComboEditor.Name = "SCMAnsMarkPrtDiv_tComboEditor";
            this.SCMAnsMarkPrtDiv_tComboEditor.Size = new System.Drawing.Size(150, 24);
            this.SCMAnsMarkPrtDiv_tComboEditor.TabIndex = 32;
            // 
            // ultraLabel19
            // 
            appearance195.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance195;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel19.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(20, 414);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(150, 23);
            this.ultraLabel19.TabIndex = 103;
            this.ultraLabel19.Text = "�񓚃}�[�N�󎚋敪";
            // 
            // SCMAutoAnsMark_tEdit
            // 
            appearance198.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SCMAutoAnsMark_tEdit.ActiveAppearance = appearance198;
            this.SCMAutoAnsMark_tEdit.AutoSelect = true;
            this.SCMAutoAnsMark_tEdit.DataText = "";
            this.SCMAutoAnsMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SCMAutoAnsMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SCMAutoAnsMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SCMAutoAnsMark_tEdit.Location = new System.Drawing.Point(176, 492);
            this.SCMAutoAnsMark_tEdit.MaxLength = 3;
            this.SCMAutoAnsMark_tEdit.Name = "SCMAutoAnsMark_tEdit";
            this.SCMAutoAnsMark_tEdit.Size = new System.Drawing.Size(68, 24);
            this.SCMAutoAnsMark_tEdit.TabIndex = 35;
            // 
            // ultraLabel47
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel47.Appearance = appearance38;
            this.ultraLabel47.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel47.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel47.Location = new System.Drawing.Point(20, 492);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.Size = new System.Drawing.Size(120, 23);
            this.ultraLabel47.TabIndex = 112;
            this.ultraLabel47.Text = "�����񓚃}�[�N";
            // 
            // SCMManualAnsMark_tEdit
            // 
            appearance220.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SCMManualAnsMark_tEdit.ActiveAppearance = appearance220;
            this.SCMManualAnsMark_tEdit.AutoSelect = true;
            this.SCMManualAnsMark_tEdit.DataText = "";
            this.SCMManualAnsMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SCMManualAnsMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SCMManualAnsMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SCMManualAnsMark_tEdit.Location = new System.Drawing.Point(176, 467);
            this.SCMManualAnsMark_tEdit.MaxLength = 3;
            this.SCMManualAnsMark_tEdit.Name = "SCMManualAnsMark_tEdit";
            this.SCMManualAnsMark_tEdit.Size = new System.Drawing.Size(68, 24);
            this.SCMManualAnsMark_tEdit.TabIndex = 34;
            // 
            // ultraLabel20
            // 
            appearance217.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance217;
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel20.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(20, 442);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(106, 23);
            this.ultraLabel20.TabIndex = 110;
            this.ultraLabel20.Text = "�ʏ�}�[�N";
            // 
            // ultraLabel46
            // 
            appearance221.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance221;
            this.ultraLabel46.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraLabel46.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel46.Location = new System.Drawing.Point(20, 467);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(120, 23);
            this.ultraLabel46.TabIndex = 111;
            this.ultraLabel46.Text = "�蓮�񓚃}�[�N";
            // 
            // NormalPrtMark_tEdit
            // 
            appearance216.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NormalPrtMark_tEdit.ActiveAppearance = appearance216;
            this.NormalPrtMark_tEdit.AutoSelect = true;
            this.NormalPrtMark_tEdit.DataText = "";
            this.NormalPrtMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NormalPrtMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.NormalPrtMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.NormalPrtMark_tEdit.Location = new System.Drawing.Point(176, 442);
            this.NormalPrtMark_tEdit.MaxLength = 3;
            this.NormalPrtMark_tEdit.Name = "NormalPrtMark_tEdit";
            this.NormalPrtMark_tEdit.Size = new System.Drawing.Size(68, 24);
            this.NormalPrtMark_tEdit.TabIndex = 33;
            // 
            // SFURI09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(961, 759);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFURI09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�`�[����p�^�[���ݒ�";
            this.Load += new System.EventHandler(this.SFURI09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09120UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09120UA_Closing);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntNmPrtExpDiv_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3CharCnt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2CharCnt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNoteCharCnt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Note1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HonorificTitle_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefConsTaxPrtNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReissueMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtKind_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataInputSystem_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialPurpose1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtKindNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataInputSystemNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eachSlipTypeCol_ultraGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopyCount_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipFontSize_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomMargin_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMargin_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMarging_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopMarging_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutConMsg_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipComment_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePrintDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodePrintDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrtCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefConsTaxDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseNamePrtCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipPrtSetPaperId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPgClassId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPgId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputFormFileName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailRowCount_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtCirculation_tNedit)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName405_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName404_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName403_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName402_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName305_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName304_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName303_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName302_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName205_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName204_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName203_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName202_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName105_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName104_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName103_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName102_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMAnsMarkPrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMAutoAnsMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SCMManualAnsMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPrtMark_tEdit)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region -- Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
		private SlipPrtSetAcs _slipPrtSetAcs;

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        private CustomerInfoAcs _customerInfoAcs = null;
        private int updateFlag;
        private int customerCode = 0;
        private string customerName = string.Empty;
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
		
		//----- h.ueno del---------- start 2007.12.17
		//private SlipPrtSet _prevSlipPrtSet;
		//----- h.ueno del---------- end   2007.12.17
				
		// ���Code
		private string _enterpriseCode;
		// HashTable
		private Hashtable _slipPrtSetTable;
		// �ҏWCheck�pClone
		private SlipPrtSet _slipPrtSetClone;
		// Work�pGridIndexBuffer
		private int	_indexBuf;

		//----- h.ueno del---------- start 2007.12.17
		//private bool _nextData;
		//----- h.ueno del---------- end   2007.12.17
		
		private int _totalCount;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;

		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;


		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
		//----- h.ueno add---------- start 2007.12.17
		private const string VIEW_DELETE_DATE			 = "�폜��";
		//----- h.ueno add---------- end   2007.12.17
		private const string VIEW_DATA_INPUT_SYSTEM_CODE = "�f�[�^���̓V�X�e���R�[�h";
		private const string VIEW_DATA_INPUT_SYSTEM_NAME = "�f�[�^���̓V�X�e��";
		private const string VIEW_SLIP_PRT_KIND_CODE     = "�`�[�����ʃR�[�h";
		private const string VIEW_SLIP_PRT_KIND_NAME	 = "�`�[������";

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
		private const string VIEW_SLIP_PRT_SET_PAPER_ID  = "�`�[������[ID";
        // 2008.09.24 30413 ���� �`�[������[���̂ɕύX >>>>>>START
        //private const string VIEW_SLIP_COMMENT = "�`�[�R�����g";
        private const string VIEW_SLIP_COMMENT = "�`�[������[����";
        // 2008.09.24 30413 ���� �`�[������[���̂ɕύX <<<<<<END
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

		private const string VIEW_OUTPUT_PG_ID			 = "�o�̓v���O����ID";
		private const string VIEW_OUTPUT_PG_CLASS_ID	 = "�o�̓v���O�����N���XID";
		private const string VIEW_OUTPUT_FORM_FILE_NAME  = "�o�̓t�@�C����";
		private const string VIEW_ENTERPRISE_NAME_PRT_CD = "���Ж�����敪";
		private const string VIEW_ENTERPRISE_NAME_PRT_NM = "���Ж����";
		private const string VIEW_PRT_CIRCULATION		 = "�������";
        // 2008.12.11 30413 ���� �`�[�p�����폜 >>>>>>START
        //private const string VIEW_SLIP_FORM_CD	         = "�`�[�p���敪";
        //private const string VIEW_SLIP_FORM_NM	         = "�`�[�p��";
        // 2008.12.11 30413 ���� �`�[�p�����폜 <<<<<<END
        private const string VIEW_OUT_CONFIMATION_MSG = "�o�͊m�F���b�Z�[�W";
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//		private const string VIEW_OPTION_CD		         = "�I�v�V�����R�[�h";
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
        
        // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
		//private const string VIEW_PRINTER_MNG_NO		 = "�v�����^�Ǘ�No.";
		//private const string VIEW_PRINTER_MNG_NM         = "�v�����^��";
        // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END

        // 2008.06.06 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� >>>>>>START
        private const string VIEW_REISSUE_MARK = "�Ĕ��s�}�[�N";
        private const string VIEW_REF_CONS_TAX_DIV_CD = "�Q�l����ŋ敪";
        private const string VIEW_REF_CONS_TAX_DIV_NM = "�Q�l�����";
        private const string VIEW_REF_CONS_TAX_PRT_NM = "�Q�l����ň󎚖���";
        private const string VIEW_NOTE1 = "���l�P";
        private const string VIEW_NOTE2 = "���l�Q";
        private const string VIEW_NOTE3 = "���l�R";
        private const string VIEW_QR_CODE_PRINT_DIV_CD = "QR�R�[�h�󎚋敪";
        private const string VIEW_QR_CODE_PRINT_DIV_NM = "QR�R�[�h��";
        private const string VIEW_TIME_PRINT_DIV_CD = "�����󎚋敪";
        private const string VIEW_TIME_PRINT_DIV_NM = "������";
        // 2008.06.06 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� <<<<<<END

        // 2008.08.28 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� >>>>>>START
        private const string VIEW_DETAIL_ROW_COUNT = "���׍s��";
        private const string VIEW_HONORIFIC_TITLE = "�h��";
        // 2008.08.28 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� <<<<<<END

        // --- ADD 2009/12/31 ---------->>>>>
        private const string VIEW_SLIPNOTECHARCNT_TITLE = "�`�[���l����";
        private const string VIEW_SLIPNOTE2CHARCNT_TITLE = "�`�[���l�Q����";
        private const string VIEW_SLIPNOTE3CHARCNT_TITLE = "�`�[���l�R����";
        // --- ADD 2009/12/31 ----------<<<<<

        // 2008.12.11 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� >>>>>>START
        private const string VIEW_CONS_TAX_PRT_CD = "����ň�";
        // 2008.12.11 30413 ���� �ǉ����ڂ̃K�C�h���`��ǉ� <<<<<<END

        private const string VIEW_Ent_Nm_Prt_Exp_Div = "���Ж���"; // ADD 2011/02/16

        // --- ADD 2011/07/19 ---------->>>>>
        private const string VIEW_SCMANSMARKPRTDIV_TITLE = "�񓚃}�[�N�󎚋敪";
        private const string VIEW_NORMALPRTMARK_TITLE = "�ʏ�}�[�N";
        private const string VIEW_SCMMANUALANSMARK_TITLE = "�蓮�񓚃}�[�N";
        private const string VIEW_SCMAUTOANSMARK_TITLE = "�����񓚃}�[�N";
        // --- ADD 2011/07/19 ----------<<<<<
        
        private const string VIEW_TOP_MARGIN	         = "��]��";
		private const string VIEW_LEFT_MARGIN	         = "���]��";

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
		private const string VIEW_RIGHT_MARGIN           = "�E�]��";
		private const string VIEW_BOTTOM_MARGIN          = "���]��";
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

		private const string VIEW_PRT_PREVIEW_EXIST_CODE = "����v���r���[�敪";
		private const string VIEW_PRT_PREVIEW_EXIST_NAME = "����v���r���[";
		private const string VIEW_OUTPUT_PURPOSE         = "�o�͗p�r";

		private const string VIEW_EACH_SLIP_TYPE_COL_ID_1  = "�`�[�^�C�v�ʗ�ID�P";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_2  = "�`�[�^�C�v�ʗ�ID�Q";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_3  = "�`�[�^�C�v�ʗ�ID�R";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_4  = "�`�[�^�C�v�ʗ�ID�S";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_5  = "�`�[�^�C�v�ʗ�ID�T";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_6  = "�`�[�^�C�v�ʗ�ID�U";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_7  = "�`�[�^�C�v�ʗ�ID�V";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_8  = "�`�[�^�C�v�ʗ�ID�W";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_9  = "�`�[�^�C�v�ʗ�ID�X";
		private const string VIEW_EACH_SLIP_TYPE_COL_ID_10 = "�`�[�^�C�v�ʗ�ID�P�O";

        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ񖼏�" �� "�`�[�^�C�v�ʍ���" >>>>>>START
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_1  = "�`�[�^�C�v�ʗ񖼏̂P";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_2  = "�`�[�^�C�v�ʗ񖼏̂Q";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_3  = "�`�[�^�C�v�ʗ񖼏̂R";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_4  = "�`�[�^�C�v�ʗ񖼏̂S";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_5  = "�`�[�^�C�v�ʗ񖼏̂T";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_6  = "�`�[�^�C�v�ʗ񖼏̂U";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_7  = "�`�[�^�C�v�ʗ񖼏̂V";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_8  = "�`�[�^�C�v�ʗ񖼏̂W";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_9  = "�`�[�^�C�v�ʗ񖼏̂X";
        //private const string VIEW_EACH_SLIP_TYPE_COL_NM_10 = "�`�[�^�C�v�ʗ񖼏̂P�O";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_1 = "�`�[�^�C�v�ʍ��ڂP";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_2 = "�`�[�^�C�v�ʍ��ڂQ";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_3 = "�`�[�^�C�v�ʍ��ڂR";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_4 = "�`�[�^�C�v�ʍ��ڂS";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_5 = "�`�[�^�C�v�ʍ��ڂT";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_6 = "�`�[�^�C�v�ʍ��ڂU";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_7 = "�`�[�^�C�v�ʍ��ڂV";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_8 = "�`�[�^�C�v�ʍ��ڂW";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_9 = "�`�[�^�C�v�ʍ��ڂX";
        private const string VIEW_EACH_SLIP_TYPE_COL_NM_10 = "�`�[�^�C�v�ʍ��ڂP�O";
        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ񖼏�" �� "�`�[�^�C�v�ʍ���" <<<<<<END
		
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_1  = "�`�[�^�C�v�ʗ�󎚋敪�P";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_2  = "�`�[�^�C�v�ʗ�󎚋敪�Q";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_3  = "�`�[�^�C�v�ʗ�󎚋敪�R";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_4  = "�`�[�^�C�v�ʗ�󎚋敪�S";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_5  = "�`�[�^�C�v�ʗ�󎚋敪�T";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_6  = "�`�[�^�C�v�ʗ�󎚋敪�U";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_7  = "�`�[�^�C�v�ʗ�󎚋敪�V";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_8  = "�`�[�^�C�v�ʗ�󎚋敪�W";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_9  = "�`�[�^�C�v�ʗ�󎚋敪�X";
		private const string VIEW_EACH_SLIP_TYPE_COL_PRT_CD_10 = "�`�[�^�C�v�ʗ�󎚋敪�P�O";

        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ��" �� "�`�[�^�C�v�ʍ��ڈ�" >>>>>>START
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1 = "�`�[�^�C�v�ʗ�󎚂P";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2  = "�`�[�^�C�v�ʗ�󎚂Q";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3  = "�`�[�^�C�v�ʗ�󎚂R";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4  = "�`�[�^�C�v�ʗ�󎚂S";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5  = "�`�[�^�C�v�ʗ�󎚂T";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6  = "�`�[�^�C�v�ʗ�󎚂U";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7  = "�`�[�^�C�v�ʗ�󎚂V";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8  = "�`�[�^�C�v�ʗ�󎚂W";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9  = "�`�[�^�C�v�ʗ�󎚂X";
        //private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10 = "�`�[�^�C�v�ʗ�󎚂P�O";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1 = "�`�[�^�C�v�ʍ��ڈ󎚂P";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2 = "�`�[�^�C�v�ʍ��ڈ󎚂Q";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3 = "�`�[�^�C�v�ʍ��ڈ󎚂R";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4 = "�`�[�^�C�v�ʍ��ڈ󎚂S";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5 = "�`�[�^�C�v�ʍ��ڈ󎚂T";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6 = "�`�[�^�C�v�ʍ��ڈ󎚂U";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7 = "�`�[�^�C�v�ʍ��ڈ󎚂V";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8 = "�`�[�^�C�v�ʍ��ڈ󎚂W";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9 = "�`�[�^�C�v�ʍ��ڈ󎚂X";
        private const string VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10 = "�`�[�^�C�v�ʍ��ڈ󎚂P�O";
        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ��" �� "�`�[�^�C�v�ʍ��ڈ�" <<<<<<END
        
        // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 >>>>>>START
        //private const string VIEW_SLIP_FONT_NAME	 = "�`�[�t�H���g����";
        //// 2006.02.08 ADD STA UENO ////////////////////////////////////////////
        //private const string VIEW_SLIP_FONT_SIZE_CD	 = "�`�[�����̃T�C�Y�敪";
        //private const string VIEW_SLIP_FONT_SIZE_NM	 = "�`�[�����̃T�C�Y";
        private const string VIEW_SLIP_FONT_SIZE_NM = "���Ӑ��";
        //private const string VIEW_SLIP_FONT_STYLE_CD = "�`�[�����̑����敪";
        //private const string VIEW_SLIP_FONT_STYLE_NM = "�`�[�����̑���";
        //// 2006.02.08 ADD END UENO ////////////////////////////////////////////
        // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 <<<<<<END

        // 2008.12.11 30413 ���� �W�����i�p�̃��X�g >>>>>>START
        private const string MY_SCREEN_LIST_PRICE = "ListPrice";        // �W�����i
        // 2008.12.11 30413 ���� �W�����i�p�̃��X�g <<<<<<END
        
		private const string VIEW_GUID_KEY = "Guid";

		// View�pGrid�ɕ\��������e�[�u����
		private const string VIEW_TABLE = "VIEW_TABLE";

		//----- h.ueno add---------- start 2007.12.17
		// �A�Z���u��ID
		private const string ASSEMBLY_ID = "SFURI09020U";
		//----- h.ueno add---------- end   2007.12.17

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
		//----- h.ueno del---------- start 2007.12.17
		//private const string VIEW_CUST_TEL_NO_PRT_DIV_CD = "�d�b�ԍ��󎚋敪";
		//private const string VIEW_CUST_TEL_NO_PRT_DIV_NM = "�d�b�ԍ���";
		//----- h.ueno del---------- end   2007.12.17

		private int colorRed1;
		private int colorRed2;
		private int colorRed3;
		private int colorRed4;
		private int colorRed5;

		private int colorGreen1;
		private int colorGreen2;
		private int colorGreen3;
		private int colorGreen4;
		private int colorGreen5;

		private int colorBlue1;
		private int colorBlue2;
		private int colorBlue3;
		private int colorBlue4;
		private int colorBlue5;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.19 TAKAHASHI ADD START
		// SlipFontName_uFontNameEditor����p
		private bool _ultraFontNameEditorFlg;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.19 TAKAHASHI ADD END

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI ADD START
		// �v�����^�Ǘ�No.�擾�p
		private PrtManageAcs _prtManageAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI ADD END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
		private const string VIEW_COPY_COUNT		= "���ʖ���";
	    //TODO : 2006/03/15 H.NAKAMURA ADD STA
		//�^�C�g�����ڂ̒ǉ�
		private const string VIEW_TITLE_NAME_1		= "�`�[�^�C�g���P�|�P";
		private const string VIEW_TITLE_NAME_102    = "�`�[�^�C�g���P�|�Q";
		private const string VIEW_TITLE_NAME_103    = "�`�[�^�C�g���P�|�R";
		private const string VIEW_TITLE_NAME_104    = "�`�[�^�C�g���P�|�S";
		private const string VIEW_TITLE_NAME_105    = "�`�[�^�C�g���P�|�T";
		private const string VIEW_TITLE_NAME_2		= "�`�[�^�C�g���Q�|�P";
		private const string VIEW_TITLE_NAME_202    = "�`�[�^�C�g���Q�|�Q";
		private const string VIEW_TITLE_NAME_203    = "�`�[�^�C�g���Q�|�R";
		private const string VIEW_TITLE_NAME_204    = "�`�[�^�C�g���Q�|�S";
		private const string VIEW_TITLE_NAME_205    = "�`�[�^�C�g���Q�|�T";
		private const string VIEW_TITLE_NAME_3		= "�`�[�^�C�g���R�|�P";
		private const string VIEW_TITLE_NAME_302    = "�`�[�^�C�g���R�|�Q";
		private const string VIEW_TITLE_NAME_303    = "�`�[�^�C�g���R�|�R";
		private const string VIEW_TITLE_NAME_304    = "�`�[�^�C�g���R�|�S";
		private const string VIEW_TITLE_NAME_305    = "�`�[�^�C�g���R�|�T";
		private const string VIEW_TITLE_NAME_4		= "�`�[�^�C�g���S�|�P";
		private const string VIEW_TITLE_NAME_402    = "�`�[�^�C�g���S�|�Q";
		private const string VIEW_TITLE_NAME_403    = "�`�[�^�C�g���S�|�R";
		private const string VIEW_TITLE_NAME_404    = "�`�[�^�C�g���S�|�S";
		private const string VIEW_TITLE_NAME_405    = "�`�[�^�C�g���S�|�T";

		// Grid�\���p
		//3/22 H.NAKAMURA ADD
        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ񖼏�" �� "�`�[�^�C�v�ʍ���" >>>>>>START
        //private const string MY_SCREEN_EACH_SLIPTYPECOL_TITLE = "�`�[�^�C�v�ʗ񖼏�";
        private const string MY_SCREEN_EACH_SLIPTYPECOL_TITLE = "�`�[�^�C�v�ʍ���";
        // 2008.10.28 30413 ���� "�`�[�^�C�v�ʗ񖼏�" �� "�`�[�^�C�v�ʍ���" <<<<<<END
        private const string MY_SCREEN_PRINTDIV_TITLE = "�󎚋敪";
		private const string MY_SCREEN_ODER = "�\������";//�J�������͕\�����܂��� 
		private const string MY_SCREEN_GUID		                   = "MY_SCREEN_GUID";
		private const string MY_SCREEN_TABLE		               = "MY_SCREEN_TABLE";	
		private const string MY_SCREEN_ID                          = "ID"; // ��ƁE���i���̂Ȃ�(�ҏW�s�A��\��)
	
		// Grid�ҏW�p
		private const int MAX_ROW_COUNT = 10;

		//���ƈ󎚋敪
		//2006.12.07 deleted by T-Kidate
        //private const string VIEW_MAINWORKDIV_TITLE = "���ƍs�󎚋敪";

		//----- h.ueno del---------- start 2007.12.17
		//�_��g�ѓd�b�ԍ��󎚋敪
		////2006.12.07 added by T-Kidate
		//private const string VIEW_CUSTRACT_NO_PRT_DIV_CD = "�_��ԍ��󎚋敪";
		//private const string VIEW_CUSTRACT_NO_PRT_DIV_NM = "�_��ԍ���";
		//private const string VIEW_CUST_CP_NO_PRT_DIV_CD�@= "�_��g�ѓd�b�ԍ��󎚋敪";
		//private const string VIEW_CUST_CP_NO_PRT_DIV_NM  = "�_��g�ѓd�b�ԍ���";
		//----- h.ueno del---------- end   2007.12.17
            
        // H.NAKAMURA ADD END
		private const string VIEW_SPECIAL_PURPOSE_1 = "����p�r�P";
		private const string VIEW_SPECIAL_PURPOSE_2 = "����p�r�Q";
		private const string VIEW_SPECIAL_PURPOSE_3 = "����p�r�R";
		private const string VIEW_SPECIAL_PURPOSE_4 = "����p�r�S";
		
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

		////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
		//----- h.ueno del---------- start 2007.12.17
		//private const string VIEW_BARCODEACPODRNOPRTNAME = "�o�[�R�[�h�󎚋敪�i�󒍔ԍ��j";
		//private const string VIEW_BARCODECUSTCODEPRTNAME = "�o�[�R�[�h�󎚋敪�i���Ӑ�R�[�h�j";
		//----- h.ueno del---------- end   2007.12.17
		
        //2006.12.07 deleted by T-Kidate
        //private const string VIEW_BARCODECARMNGNOPRTNAME = "�o�[�R�[�h�󎚋敪�i�ԗ��Ǘ��ԍ��j";
		////////////////////////////////////////////// 2006.01.24 TERASAKA ADD END //
			
		//UI�O���b�h�p�f�[�^�e�[�u��
		private DataTable _bindTable;

		//----- h.ueno del---------- start 2007.12.17
		//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.11 TAKAHASHI ADD START
		//// �o�[�R�[�h�I�v�V����Flg
		//private bool _barCodeOPFlg = false;
		//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.11 TAKAHASHI ADD END
		//----- h.ueno del---------- end   2007.12.17

        // 2010/07/06 Add >>>
        private bool _QRMailOPFlg = false;
        // 2010/07/06 Add <<<
        private bool _PCCOPFlg = false; // ADD 2011/07/19
		#endregion

		#region -- Main --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFURI09020UA());
		}
		# endregion

		#region -- Properties --
		/*----------------------------------------------------------------------------------*/
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose; 
			}
			set
			{
				this._canClose = value; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get
			{
				return this._dataIndex; 
			}
			set
			{
				this._dataIndex = value; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch; 
			}
		}
		#endregion

		#region -- Public Methods --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.08.31</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName   = VIEW_TABLE;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList slipPrtSetList = null;

			//----- h.ueno del---------- start 2007.12.17
			// readCount�͖��g�p�̂��ߕ���폜
			//if (readCount == 0)
			//{
			//----- h.ueno del---------- end   2007.12.17
			
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._slipPrtSetAcs.SearchAllSlipPrtSet(out slipPrtSetList, this._enterpriseCode);
				this._totalCount = slipPrtSetList.Count;

			//----- h.ueno del---------- start 2007.12.17
			//}
			//else
			//{
			//    status = this._slipPrtSetAcs.SearchSpecificationAllSlipPrtSet(
			//        out slipPrtSetList,
			//        out this._totalCount,
			//        out this._nextData,
			//        this._enterpriseCode,
			//        readCount,
			//        this._prevSlipPrtSet);
			//}
			//----- h.ueno del---------- end   2007.12.17
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					//----- h.ueno del---------- start 2007.12.17
					//if (slipPrtSetList.Count > 0)
					//{
					//    // �ŏI�̏o�͐ݒ�I�u�W�F�N�g��ޔ�����
					//    this._prevSlipPrtSet = ((SlipPrtSet)slipPrtSetList[slipPrtSetList.Count - 1]).Clone();
					//}
					//----- h.ueno del---------- end   2007.12.17

					int index = 0;
					foreach(SlipPrtSet slipPrtSet in slipPrtSetList)
					{
						SlipPrtSetToDataSet(slipPrtSet.Clone(), index);
						++index;
					}
					this._totalCount = index;

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					//----- h.ueno add---------- start 2007.12.17
					// �f�[�^�Ȃ��̏ꍇ�̓O���b�h���N���A
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
					this._slipPrtSetTable.Clear();
					//----- h.ueno add---------- end   2007.12.17

					break;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						this.Text,		                        // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._slipPrtSetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
			totalCount = this._totalCount;
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			//----- h.ueno del---------- start 2007.12.17
			//--- ���g�p�̂��ߍ폜
			//int dummy = 0;
			//ArrayList slipPrtSetList = null;

			//// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			//if (readCount == 0)
			//{
			//    readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			//}

			//int status = this._slipPrtSetAcs.SearchSpecificationAllSlipPrtSet(
			//    out slipPrtSetList,
			//    out dummy,
			//    out this._nextData, 
			//    this._enterpriseCode,
			//    readCount,
			//    this._prevSlipPrtSet);

			//switch (status)
			//{
			//    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
			//    {
			//        if( slipPrtSetList.Count > 0 ) {
			//            // �ŏI�̏o�͐ݒ�N���X��ޔ�����
			//            this._prevSlipPrtSet = ((SlipPrtSet)slipPrtSetList[slipPrtSetList.Count - 1]).Clone();
			//        }

			//        int index = 0;
			//        foreach (SlipPrtSet slipPrtSet in slipPrtSetList)
			//        {
			//            index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count;
			//            SlipPrtSetToDataSet(slipPrtSet.Clone(), index);
			//        }

			//        break;
			//    }
			//    case (int)ConstantManagement.DB_Status.ctDB_EOF:
			//    {
			//        break;
			//    }
			//    default:
			//    {
			//        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
			//        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
			//            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
			//            ASSEMBLY_ID,							// �A�Z���u��ID
			//            this.Text,		                        // �v���O��������
			//            "Search",                               // ��������
			//            TMsgDisp.OPE_GET,                       // �I�y���[�V����
			//            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
			//            status,									// �X�e�[�^�X�l
			//            this._slipPrtSetAcs,					// �G���[�����������I�u�W�F�N�g
			//            MessageBoxButtons.OK,					// �\������{�^��
			//            MessageBoxDefaultButton.Button1);		// �����\���{�^��
			//        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

			//        break;
			//    }
			//}
			//return status;
			//----- h.ueno del---------- start 2007.12.17
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B�i�������j</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		public int Delete()
		{
			//----- h.ueno add---------- start 2007.12.17
			int status = 0;
			
			// �_���폜
			status = LogicalDeleteSlipPrtSet();
			//----- h.ueno add---------- end   2007.12.17
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B�i�������j</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �f�[�^���̓V�X�e���A�`�[������
			//----- h.ueno add---------- start 2007.12.17
			appearanceTable.Add(VIEW_DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			//----- h.ueno add---------- end   2007.12.17
					
			appearanceTable.Add(VIEW_DATA_INPUT_SYSTEM_CODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

			//----- h.ueno upd ---------- start 2008.03.17 ��\���ɂ���
			appearanceTable.Add(VIEW_DATA_INPUT_SYSTEM_NAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno upd ---------- end 2008.03.17

			appearanceTable.Add(VIEW_SLIP_PRT_KIND_CODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));	
			appearanceTable.Add(VIEW_SLIP_PRT_KIND_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));	
	
			// �o�͊֌W
////////////////////////////////////////////// 2006.01.25 TERASAKA DEL STA //
//			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			//----- h.ueno upd---------- start 2007.12.17
			appearanceTable.Add(VIEW_SLIP_PRT_SET_PAPER_ID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno upd---------- end   2007.12.17

//			appearanceTable.Add(VIEW_SLIP_COMMENT, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));		
//			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END
// 2006.01.25 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.01.25 TERASAKA ADD STA //
			//----- h.ueno del---------- start 2007.12.17
			//appearanceTable.Add(VIEW_SLIP_PRT_SET_PAPER_ID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno del---------- end   2007.12.17

			appearanceTable.Add(VIEW_SLIP_COMMENT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
// 2006.01.25 TERASAKA ADD END //////////////////////////////////////////////

			appearanceTable.Add(VIEW_OUTPUT_FORM_FILE_NAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_OUTPUT_PG_ID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));	
			appearanceTable.Add(VIEW_OUTPUT_PG_CLASS_ID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));	
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			appearanceTable.Add(VIEW_OPTION_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.01.25 TERASAKA DEL STA //
//			appearanceTable.Add(VIEW_OUT_CONFIMATION_MSG, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));	
// 2006.01.25 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.01.25 TERASAKA ADD STA //
			appearanceTable.Add(VIEW_OUT_CONFIMATION_MSG, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));	
// 2006.01.25 TERASAKA ADD END //////////////////////////////////////////////

			// ����敪�֌W
			appearanceTable.Add(VIEW_ENTERPRISE_NAME_PRT_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(VIEW_ENTERPRISE_NAME_PRT_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_PRT_PREVIEW_EXIST_CODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(VIEW_PRT_PREVIEW_EXIST_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.12.11 30413 ���� �`�[�p�����폜 >>>>>>START
            //appearanceTable.Add(VIEW_SLIP_FORM_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));	        
            //appearanceTable.Add(VIEW_SLIP_FORM_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.12.11 30413 ���� �`�[�p�����폜 <<<<<<END
        
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
            //appearanceTable.Add(VIEW_PRINTER_MNG_NO, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));		
			//appearanceTable.Add(VIEW_PRINTER_MNG_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END

            // 2008.06.06 30413 ���� �ǉ����ڂ̃K�C�h���ǉ� >>>>>>START
            appearanceTable.Add(VIEW_REISSUE_MARK, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� >>>>>>START
            appearanceTable.Add(VIEW_CONS_TAX_PRT_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� <<<<<<END

            appearanceTable.Add(VIEW_Ent_Nm_Prt_Exp_Div, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); // ADD 2011/02/16
            
            appearanceTable.Add(VIEW_REF_CONS_TAX_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_REF_CONS_TAX_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_REF_CONS_TAX_PRT_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_NOTE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_NOTE2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_NOTE3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_QR_CODE_PRINT_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_QR_CODE_PRINT_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_TIME_PRINT_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_TIME_PRINT_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.06 30413 ���� �ǉ����ڂ̃K�C�h���ǉ� <<<<<<END

            // 2008.08.28 30413 ���� �ǉ����ڂ̃K�C�h���ǉ� >>>>>>START
            appearanceTable.Add(VIEW_DETAIL_ROW_COUNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_HONORIFIC_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.08.28 30413 ���� �ǉ����ڂ̃K�C�h���ǉ� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            appearanceTable.Add(VIEW_SLIPNOTECHARCNT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_SLIPNOTE2CHARCNT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_SLIPNOTE3CHARCNT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // --- ADD 2009/12/31 ----------<<<<<

            // 2009/10/02 >>>
            //appearanceTable.Add(VIEW_TOP_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.0\\cm", Color.Black));	        
            //appearanceTable.Add(VIEW_LEFT_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.0\\cm", Color.Black));

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START 
            //appearanceTable.Add(VIEW_RIGHT_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.0\\cm", Color.Black));	        
            //appearanceTable.Add(VIEW_BOTTOM_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.0\\cm", Color.Black));	
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

            appearanceTable.Add(VIEW_TOP_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.00\\cm", Color.Black));
            appearanceTable.Add(VIEW_LEFT_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.00\\cm", Color.Black));
            appearanceTable.Add(VIEW_RIGHT_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.00\\cm", Color.Black));
            appearanceTable.Add(VIEW_BOTTOM_MARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0.00\\cm", Color.Black));
            // 2009/10/02 <<<

			//----- h.ueno del---------- start 2007.12.17
			//appearanceTable.Add(VIEW_CUST_TEL_NO_PRT_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			//appearanceTable.Add(VIEW_CUST_TEL_NO_PRT_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno del---------- end   2007.12.17

            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 >>>>>>START
            //appearanceTable.Add(VIEW_SLIP_FONT_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));	 
            //appearanceTable.Add(VIEW_SLIP_FONT_SIZE_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));	 
            appearanceTable.Add(VIEW_SLIP_FONT_SIZE_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));	 
            //appearanceTable.Add(VIEW_SLIP_FONT_STYLE_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
            //appearanceTable.Add(VIEW_SLIP_FONT_STYLE_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 <<<<<<END
            appearanceTable.Add(VIEW_PRT_CIRCULATION, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0\\��", Color.Black));
			appearanceTable.Add(VIEW_OUTPUT_PURPOSE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			appearanceTable.Add(VIEW_COPY_COUNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#0��", Color.Black));
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////
       
			// �`�[�^�C�v�ʗ�֌W
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
         
			//TODO : 2006/03/15 H.NAKAMURA ADD STA 
			appearanceTable.Add(VIEW_TITLE_NAME_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_102,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_103,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_104,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_105,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_202,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_203,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_204,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_205,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_302,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_303,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_304,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_305,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_402,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_403,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_404,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_TITLE_NAME_405,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));
			//2006.12.07 deleted by T-Kidate
            //appearanceTable.Add(VIEW_MAINWORKDIV_TITLE,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft, "", Color.Black));

			//TODO : 2006/03/15 H.NAKAMURA ADD END
			appearanceTable.Add(VIEW_SPECIAL_PURPOSE_1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SPECIAL_PURPOSE_2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SPECIAL_PURPOSE_3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SPECIAL_PURPOSE_4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.11 TAKAHASHI DELETE START
            //////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
            //appearanceTable.Add(VIEW_BARCODEACPODRNOPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(VIEW_BARCODECUSTCODEPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(VIEW_BARCODECARMNGNOPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //////////////////////////////////////////////// 2006.01.30 UENO ADD END //
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.11 TAKAHASHI DELETE END

			//----- h.ueno del---------- start 2007.12.17
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.11 TAKAHASHI ADD START
			//if (this._barCodeOPFlg == true)
			//{
			//    appearanceTable.Add(VIEW_BARCODEACPODRNOPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//    appearanceTable.Add(VIEW_BARCODECUSTCODEPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//    //2006.12.07 deleted by T-Kidate
			//    //appearanceTable.Add(VIEW_BARCODECARMNGNOPRTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//}
			//else
			//{
			//    appearanceTable.Add(VIEW_BARCODEACPODRNOPRTNAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//    appearanceTable.Add(VIEW_BARCODECUSTCODEPRTNAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//    //2006.12.07 deleted by T-Kidate
			//    //appearanceTable.Add(VIEW_BARCODECARMNGNOPRTNAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//}
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.11 TAKAHASHI ADD END
			//----- h.ueno del---------- end   2007.12.17

			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_5, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_6, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_7, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_8, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_9, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_ID_10, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_NM_10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_5, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_6, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_7, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_8, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_9, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_10, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
			appearanceTable.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(VIEW_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2011/07/19 ---------->>>>>
            if (this._PCCOPFlg)
            {
                appearanceTable.Add(VIEW_SCMANSMARKPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_NORMALPRTMARK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_SCMMANUALANSMARK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_SCMAUTOANSMARK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            else
            {
                appearanceTable.Add(VIEW_SCMANSMARKPRTDIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_NORMALPRTMARK_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_SCMMANUALANSMARK_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_SCMAUTOANSMARK_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            // --- ADD 2011/07/19 ----------<<<<<

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//appearanceTable.Add(VIEW_CUSTRACT_NO_PRT_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//appearanceTable.Add(VIEW_CUSTRACT_NO_PRT_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			////�_��g�ѓd�b�ԍ��󎚋敪
			//appearanceTable.Add(VIEW_CUST_CP_NO_PRT_DIV_CD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//appearanceTable.Add(VIEW_CUST_CP_NO_PRT_DIV_NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno del---------- end   2007.12.17

            return appearanceTable;
		}
		#endregion

		#region -- Private Method --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2011/02/16  ���N�n��</br>
        /// <br>              ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void SlipPrtSetToDataSet(SlipPrtSet slipPrtSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

			//----- h.ueno add---------- start 2007.12.17
			// �_���폜�敪
			if (slipPrtSet.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELETE_DATE] = slipPrtSet.UpdateDateTimeJpInFormal;
			}
			//----- h.ueno add---------- end   2007.12.17
			
			// �f�[�^���̓V�X�e���y�ѓ`�[���
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DATA_INPUT_SYSTEM_CODE] = slipPrtSet.DataInputSystem;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DATA_INPUT_SYSTEM_NAME] = slipPrtSet.DataInputSystemName;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_CODE]     = slipPrtSet.SlipPrtKind;

			//----- h.ueno upd---------- start 2007.12.17
			// �Œ薼�̂�E�N���X�ɂ�SortedList�Œ�`���A�擾����悤�C��
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̎擾��ύX >>>>>>START
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME]
			//	= SlipPrtSet.GetSortedListNm(slipPrtSet.SlipPrtKind, SlipPrtSet._slipPrtKindList);

			//if (slipPrtSet.DataInputSystem != 3)
			//{
			switch (slipPrtSet.SlipPrtKind)
			{
			    case 10:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "���Ϗ�";
			        break;
			    case 20:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�w����";
			        break;
			    case 21:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "���菑";
			        break;
			    case 30:
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX >>>>>>START
                    //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�[�i��";
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "����`�[";
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX <<<<<<END
                    break;
                case 40:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�ԕi�`�[";
                    break;
			    case 100:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "���[�N�V�[�g";
			        break;
			    case 110:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�{�f�B���@�}";
			        break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                case 120:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�󒍓`�[";
                    break;
                case 130:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�ݏo�`�[";
                    break;
                case 140:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "���ϓ`�[";
                    break;
                case 150:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�݌Ɉړ��`�[";
                    break;
                case 160:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "�t�n�d�`�[";
                    break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
			}
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̎擾��ύX <<<<<<END
			//}
			//else
			//{
			//    switch(slipPrtSet.SlipPrtKind)
			//    {
			//        case 10:
			//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "���Ϗ�";
			//            break;

			//        case 20:
			//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_KIND_NAME] = "������";
			//            break;
			//    }
			//}
			//----- h.ueno upd---------- end   2007.12.17

			// �`�[�A�o��PGID�A������ڊ֌W
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_PRT_SET_PAPER_ID]  = slipPrtSet.SlipPrtSetPaperId;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_COMMENT]           = slipPrtSet.SlipComment;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OUTPUT_PG_ID]           = slipPrtSet.OutputPgId;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OUTPUT_PG_CLASS_ID]     = slipPrtSet.OutputPgClassId;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OUTPUT_FORM_FILE_NAME]  = slipPrtSet.OutputFormFileName;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_CD] = slipPrtSet.EnterpriseNamePrtCd;

			//----- h.ueno upd---------- start 2007.12.17
			// �Œ薼�̂�E�N���X�ɂ�SortedList�Œ�`���A�擾����悤�C��
            // 2008.06.06 30413 ���� �r���h�G���[�̂��߁A���Ж�����̐ݒ��ύX >>>>>>START
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_NM]
			//	= SlipPrtSet.GetSortedListNm(slipPrtSet.EnterpriseNamePrtCd, SlipPrtSet._enterpriseNamePrtCdList);
			
			switch(slipPrtSet.EnterpriseNamePrtCd)
			{
			    case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_NM] = "���Ж���";
			        break;
			    case 1:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_NM] = "���_����";
			        break;
			    case 2:
			        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_NM] = "�r�b�g�}�b�v����";
			        break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISE_NAME_PRT_NM] = "�󎚂��Ȃ�";
                    break;
			}
            // 2008.06.06 30413 ���� �r���h�G���[�̂��߁A���Ж�����̐ݒ��ύX <<<<<<END
			//----- h.ueno upd---------- end   2007.12.17

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRT_CIRCULATION] = slipPrtSet.PrtCirculation;

            // 2008.12.11 30413 ���� �`�[�p�����폜 >>>>>>START
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FORM_CD]�@�@= slipPrtSet.SlipFormCd;

            ////----- h.ueno upd---------- start 2007.12.17
            //// �Œ薼�̂�E�N���X�ɂ�SortedList�Œ�`���A�擾����悤�C��
            //// 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�p���̐ݒ��ύX >>>>>>START
            ////this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FORM_NM]
            ////	= SlipPrtSet.GetSortedListNm(slipPrtSet.SlipFormCd, SlipPrtSet._slipFormCdList);
            			
            //switch(slipPrtSet.SlipFormCd)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FORM_NM] = "����";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FORM_NM] = "��p�`�[";
            //        break;
            //    case 2:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FORM_NM] = "�A��";
            //        break;
            //}
            //// 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�p���̐ݒ��ύX <<<<<<END
            ////----- h.ueno upd---------- end   2007.12.17
            // 2008.12.11 30413 ���� �`�[�p�����폜 <<<<<<END
        
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OUT_CONFIMATION_MSG]    = slipPrtSet.OutConfimationMsg;
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OPTION_CD]              = slipPrtSet.OptionCode;
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRINTER_MNG_NO]         = slipPrtSet.PrinterMngNo;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRINTER_MNG_NM]         = slipPrtSet.PrinterMngName;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END

            // 2008.06.06 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g��ǉ� >>>>>>START
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REISSUE_MARK] = slipPrtSet.ReissueMark;

            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� >>>>>>START
            switch (slipPrtSet.ConsTaxPrtCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONS_TAX_PRT_CD] = "�󎚂��Ȃ�";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONS_TAX_PRT_CD] = "�󎚂���";
                    break;
            }
            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� <<<<<<END

            // ADD 2011/02/16---------------------------------------->>>>>
            switch (slipPrtSet.EntNmPrtExpDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_Ent_Nm_Prt_Exp_Div] = "�W��";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_Ent_Nm_Prt_Exp_Div] = "��";
                    break;
            }
            // ADD 2011/02/16----------------------------------------<<<<<
            
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REF_CONS_TAX_DIV_CD] = slipPrtSet.RefConsTaxDivCd;
            switch (slipPrtSet.RefConsTaxDivCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REF_CONS_TAX_DIV_NM] = "�󎚂��Ȃ�";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REF_CONS_TAX_DIV_NM] = "�󎚂���";
                    break;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REF_CONS_TAX_PRT_NM] = slipPrtSet.RefConsTaxPrtNm;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1] = slipPrtSet.Note1;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2] = slipPrtSet.Note2;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3] = slipPrtSet.Note3;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_QR_CODE_PRINT_DIV_CD] = slipPrtSet.QRCodePrintDivCd;
            switch (slipPrtSet.QRCodePrintDivCd)
            {
                case 0:
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_QR_CODE_PRINT_DIV_NM] = "�󎚂��Ȃ�";
                    break;

                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_QR_CODE_PRINT_DIV_NM] = "�󎚂���";
                    break;

                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_QR_CODE_PRINT_DIV_NM] = "�ԕi�܂�";
                    break;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIME_PRINT_DIV_CD] = slipPrtSet.TimePrintDivCd;
            switch (slipPrtSet.TimePrintDivCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIME_PRINT_DIV_NM] = "�󎚂��Ȃ�";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIME_PRINT_DIV_NM] = "�󎚂���";
                    break;
            }
            // 2008.06.06 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g��ǉ� <<<<<<END

            // 2008.08.28 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g��ǉ� >>>>>>START
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DETAIL_ROW_COUNT] = slipPrtSet.DetailRowCount;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_HONORIFIC_TITLE] = slipPrtSet.HonorificTitle;
            // 2008.08.28 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g��ǉ� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIPNOTECHARCNT_TITLE] = slipPrtSet.SlipNoteCharCnt;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIPNOTE2CHARCNT_TITLE] = slipPrtSet.SlipNote2CharCnt;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIPNOTE3CHARCNT_TITLE] = slipPrtSet.SlipNote3CharCnt;
            // --- ADD 2009/12/31 ----------<<<<<

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOP_MARGIN]             = slipPrtSet.TopMargin;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LEFT_MARGIN]            = slipPrtSet.LeftMargin;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RIGHT_MARGIN]           = slipPrtSet.RightMargin;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BOTTOM_MARGIN]          = slipPrtSet.BottomMargin;

			//----- h.ueno del---------- start 2007.12.17
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_TEL_NO_PRT_DIV_CD] = slipPrtSet.CustTelNoPrtDivCd;
			//switch(slipPrtSet.CustTelNoPrtDivCd)
			//{
			//    case 0:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_TEL_NO_PRT_DIV_NM] = "�󎚂��Ȃ�";
			//        break;

			//    case 1:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_TEL_NO_PRT_DIV_NM] = "�󎚂���";
			//        break;
			//}
			//----- h.ueno del---------- end   2007.12.17

			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRT_PREVIEW_EXIST_CODE] = slipPrtSet.PrtPreviewExistCode;
			switch(slipPrtSet.PrtPreviewExistCode)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRT_PREVIEW_EXIST_NAME] = "����";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRT_PREVIEW_EXIST_NAME] = "�L��";
					break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OUTPUT_PURPOSE] = slipPrtSet.OutputPurpose;
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COPY_COUNT] = slipPrtSet.CopyCount;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

            // --- ADD 2011/07/19 ---------->>>>>
            if (slipPrtSet.SlipPrtKind == 140 || slipPrtSet.SlipPrtKind == 30 || slipPrtSet.SlipPrtKind == 160)
            {
                switch (slipPrtSet.SCMAnsMarkPrtDiv)
                {
                    case 0:
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SCMANSMARKPRTDIV_TITLE] = "�󎚂��Ȃ�";
                        break;

                    case 1:
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SCMANSMARKPRTDIV_TITLE] = "�󎚂���";
                        break;
                }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NORMALPRTMARK_TITLE] = slipPrtSet.NormalPrtMark;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SCMMANUALANSMARK_TITLE] = slipPrtSet.SCMManualAnsMark;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SCMAUTOANSMARK_TITLE] = slipPrtSet.SCMAutoAnsMark;
            }
            // --- ADD 2011/07/19 ----------<<<<<

			// �`�[�^�C�v�ʗ�֌W
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
            //TODO : 2006/03/15 H.NAKAMURA ADD STA
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_1]             = slipPrtSet.TitleName1;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_102] 			= slipPrtSet.TitleName102;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_103] 			= slipPrtSet.TitleName103;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_104] 			= slipPrtSet.TitleName104;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_105]           = slipPrtSet.TitleName105; 
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_2] 			= slipPrtSet.TitleName2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_202] 			= slipPrtSet.TitleName202;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_203] 			= slipPrtSet.TitleName203;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_204] 			= slipPrtSet.TitleName204;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_205]           = slipPrtSet.TitleName205; 
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_3] 			= slipPrtSet.TitleName3;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_302] 			= slipPrtSet.TitleName302;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_303] 			= slipPrtSet.TitleName303;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_304] 			= slipPrtSet.TitleName304;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_305]           = slipPrtSet.TitleName305; 
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_4] 			= slipPrtSet.TitleName4;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_402] 			= slipPrtSet.TitleName402;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_403] 			= slipPrtSet.TitleName403;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_404] 			= slipPrtSet.TitleName404;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TITLE_NAME_405]			= slipPrtSet.TitleName405; 
			//2006.12.07 deleted by T-Kidate
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAINWORKDIV_TITLE]		= slipPrtSet.GetMainWorkPrintName(slipPrtSet.MainWorkLinePrtDivCd);
            

			//TODO : 2006/03/15 H.NAKAMURA ADD END

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SPECIAL_PURPOSE_1]		= slipPrtSet.SpecialPurpose1;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SPECIAL_PURPOSE_2]		= slipPrtSet.SpecialPurpose2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SPECIAL_PURPOSE_3]		= slipPrtSet.SpecialPurpose3;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SPECIAL_PURPOSE_4]		= slipPrtSet.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_1]  = slipPrtSet.EachSlipTypeColId1;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_2]  = slipPrtSet.EachSlipTypeColId2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_3]  = slipPrtSet.EachSlipTypeColId3;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_4]  = slipPrtSet.EachSlipTypeColId4;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_5]  = slipPrtSet.EachSlipTypeColId5;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_6]  = slipPrtSet.EachSlipTypeColId6;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_7]  = slipPrtSet.EachSlipTypeColId7;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_8]  = slipPrtSet.EachSlipTypeColId8;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_9]  = slipPrtSet.EachSlipTypeColId9;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_ID_10] = slipPrtSet.EachSlipTypeColId10;

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_1]  = slipPrtSet.EachSlipTypeColNm1;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_2]  = slipPrtSet.EachSlipTypeColNm2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_3]  = slipPrtSet.EachSlipTypeColNm3;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_4]  = slipPrtSet.EachSlipTypeColNm4;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_5]  = slipPrtSet.EachSlipTypeColNm5;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_6]  = slipPrtSet.EachSlipTypeColNm6;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_7]  = slipPrtSet.EachSlipTypeColNm7;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_8]  = slipPrtSet.EachSlipTypeColNm8;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_9]  = slipPrtSet.EachSlipTypeColNm9;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_NM_10] = slipPrtSet.EachSlipTypeColNm10;

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_1]  = slipPrtSet.EachSlipTypeColPrt1;

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.07 added by T-Kidate
			////�_��ԍ��󎚋敪
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRACT_NO_PRT_DIV_CD] = slipPrtSet.ContractNoPrtDivCd;
			//switch (slipPrtSet.ContractNoPrtDivCd)
			//{
			//    case 0:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRACT_NO_PRT_DIV_NM] = "�󎚂��Ȃ�";
			//        break;

			//    case 1:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRACT_NO_PRT_DIV_NM] = "�󎚂���";
			//        break;
			//}
			////2006.12.08 added by T-Kidate
			////�_��g�ѓd�b�ԍ��󎚋敪
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CP_NO_PRT_DIV_CD] = slipPrtSet.ContCpNoPrtDivCd;
			//switch (slipPrtSet.ContCpNoPrtDivCd)
			//{
			//    case 0:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CP_NO_PRT_DIV_NM] = "�󎚂��Ȃ�";
			//        break;

			//    case 1:
			//        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CP_NO_PRT_DIV_NM] = "�󎚂���";
			//        break;
			//}
			//----- h.ueno del---------- end   2007.12.17

            // 2008.12.11 30413 ���� �W�����i��"�|�����P"��ǉ� >>>>>>START
			switch(slipPrtSet.EachSlipTypeColPrt1)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_2]  = slipPrtSet.EachSlipTypeColPrt2;
			switch(slipPrtSet.EachSlipTypeColPrt2)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_3]  = slipPrtSet.EachSlipTypeColPrt3;
			switch(slipPrtSet.EachSlipTypeColPrt3)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_4]  = slipPrtSet.EachSlipTypeColPrt4;
			switch(slipPrtSet.EachSlipTypeColPrt4)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_5]  = slipPrtSet.EachSlipTypeColPrt5;
			switch(slipPrtSet.EachSlipTypeColPrt5)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_6]  = slipPrtSet.EachSlipTypeColPrt6;
			switch(slipPrtSet.EachSlipTypeColPrt6)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_7]  = slipPrtSet.EachSlipTypeColPrt7;
			switch(slipPrtSet.EachSlipTypeColPrt7)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_8]  = slipPrtSet.EachSlipTypeColPrt8;
			switch(slipPrtSet.EachSlipTypeColPrt8)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_9]  = slipPrtSet.EachSlipTypeColPrt9;
			switch(slipPrtSet.EachSlipTypeColPrt9)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9] = "�|�����P";
                    break;
			}
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_CD_10] = slipPrtSet.EachSlipTypeColPrt10;
			switch(slipPrtSet.EachSlipTypeColPrt10)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10] = "�󎚂��Ȃ�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10] = "�󎚂���";
					break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10] = "�|�����P";
                    break;
			}
            // 2008.12.11 30413 ���� �W�����i��"�|�����P"��ǉ� <<<<<<END
			
            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 >>>>>>START
//            // �`�[�t�H���g�֌W
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_NAME]    = slipPrtSet.SlipFontName;
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_SIZE_CD] = slipPrtSet.SlipFontSize;
            switch (slipPrtSet.SlipFontSize)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_SIZE_NM] = "�W��";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_SIZE_NM] = "��";
                    break;
            }
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_STYLE_CD] = slipPrtSet.SlipFontStyle;
//            switch(slipPrtSet.SlipFontStyle)
//            {
//                case 0:
//                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_STYLE_NM] = "�W��";
//                    break;

//                case 1:
//                    // 2006.02.08 DEL STA UENO ///////////////////////////////////////////////////////// 
////					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_STYLE_NM] = "����";
//                    // 2006.02.08 DEL STA UENO /////////////////////////////////////////////////////////

//                    // 2006.02.08 ADD STA UENO ///////////////////////////////////////////////////////// 
//                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SLIP_FONT_STYLE_NM] = "����";
//                    // 2006.02.08 ADD STA UENO /////////////////////////////////////////////////////////
//                    break;
//            }
            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 <<<<<<END
        

			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
			//----- h.ueno del---------- start 2007.12.17
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BARCODEACPODRNOPRTNAME] = slipPrtSet.GetBarCodePrintName(slipPrtSet.BarCodeAcpOdrNoPrtCd);
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BARCODECUSTCODEPRTNAME] = slipPrtSet.GetBarCodePrintName( slipPrtSet.BarCodeCustCodePrtCd );
			//----- h.ueno del---------- end   2007.12.17

            //2006.12.07 deleted by T-Kidate
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BARCODECARMNGNOPRTNAME] = slipPrtSet.GetBarCodePrintName( slipPrtSet.BarCodeCarMngNoPrtCd );
			////////////////////////////////////////////// 2006.01.30 UENO ADD END //

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY] = slipPrtSet.FileHeaderGuid;
		
			if (this._slipPrtSetTable.ContainsKey(slipPrtSet.FileHeaderGuid) == true)
			{
				this._slipPrtSetTable.Remove(slipPrtSet.FileHeaderGuid);
			}
			this._slipPrtSetTable.Add(slipPrtSet.FileHeaderGuid, slipPrtSet);
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2011/02/16  ���N�n��</br>
        /// <br>              ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable slipPrtSetTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			//----- h.ueno add---------- start 2007.12.17
			slipPrtSetTable.Columns.Add(VIEW_DELETE_DATE, typeof(string));
			//----- h.ueno add---------- end   2007.12.17

			// �f�[�^���̓V�X�e���y�ѓ`�[���
			slipPrtSetTable.Columns.Add(VIEW_DATA_INPUT_SYSTEM_CODE, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_DATA_INPUT_SYSTEM_NAME, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_SLIP_PRT_KIND_CODE, typeof(int));	
			slipPrtSetTable.Columns.Add(VIEW_SLIP_PRT_KIND_NAME, typeof(string));

			// �`�[�A�o��PGID�A������ځA�`�[�t�H���g�֌W
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSetTable.Columns.Add(VIEW_SLIP_PRT_SET_PAPER_ID, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_SLIP_COMMENT, typeof(string));
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			slipPrtSetTable.Columns.Add(VIEW_OUTPUT_FORM_FILE_NAME, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_OUTPUT_PG_ID, typeof(string));			
			slipPrtSetTable.Columns.Add(VIEW_OUTPUT_PG_CLASS_ID, typeof(string));
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			slipPrtSetTable.Columns.Add(VIEW_OPTION_CD, typeof(int));
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
			slipPrtSetTable.Columns.Add(VIEW_OUT_CONFIMATION_MSG, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_OUTPUT_PURPOSE, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_ENTERPRISE_NAME_PRT_CD, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_ENTERPRISE_NAME_PRT_NM, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_Ent_Nm_Prt_Exp_Div, typeof(string));// ADD 2011/02/16
            slipPrtSetTable.Columns.Add(VIEW_PRT_PREVIEW_EXIST_CODE, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_PRT_PREVIEW_EXIST_NAME, typeof(string));
            // 2008.12.11 30413 ���� �`�[�p�����폜 >>>>>>START
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FORM_CD, typeof(int));
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FORM_NM, typeof(string));
            // 2008.12.11 30413 ���� �`�[�p�����폜 <<<<<<END
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
			//slipPrtSetTable.Columns.Add(VIEW_PRINTER_MNG_NO, typeof(int));
			//slipPrtSetTable.Columns.Add(VIEW_PRINTER_MNG_NM, typeof(string));
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END

            // 2008.06.09 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g�����ǉ� >>>>>>START
            slipPrtSetTable.Columns.Add(VIEW_REISSUE_MARK, typeof(string));

            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� >>>>>>START
            slipPrtSetTable.Columns.Add(VIEW_CONS_TAX_PRT_CD, typeof(string));
            // 2008.12.11 30413 ���� ����ň󎚂̒ǉ� <<<<<<END
            
            slipPrtSetTable.Columns.Add(VIEW_REF_CONS_TAX_DIV_CD, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_REF_CONS_TAX_DIV_NM, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_REF_CONS_TAX_PRT_NM, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_NOTE1, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_NOTE2, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_NOTE3, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_QR_CODE_PRINT_DIV_CD, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_QR_CODE_PRINT_DIV_NM, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_TIME_PRINT_DIV_CD, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_TIME_PRINT_DIV_NM, typeof(string));
            // 2008.06.09 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g�����ǉ� <<<<<<END

            // 2008.08.28 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g�����ǉ� >>>>>>START
            slipPrtSetTable.Columns.Add(VIEW_DETAIL_ROW_COUNT, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_HONORIFIC_TITLE, typeof(string));
            // 2008.08.28 30413 ���� �ǉ����ڂ̃f�[�^�Z�b�g�����ǉ� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSetTable.Columns.Add(VIEW_SLIPNOTECHARCNT_TITLE, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_SLIPNOTE2CHARCNT_TITLE, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_SLIPNOTE3CHARCNT_TITLE, typeof(int));
            // --- ADD 2009/12/31 ----------<<<<<
            
			slipPrtSetTable.Columns.Add(VIEW_TOP_MARGIN, typeof(double));
			slipPrtSetTable.Columns.Add(VIEW_LEFT_MARGIN, typeof(double));

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			slipPrtSetTable.Columns.Add(VIEW_RIGHT_MARGIN, typeof(double));
			slipPrtSetTable.Columns.Add(VIEW_BOTTOM_MARGIN, typeof(double));
			//----- h.ueno del---------- start 2007.12.17
			//slipPrtSetTable.Columns.Add(VIEW_CUST_TEL_NO_PRT_DIV_CD, typeof(int));
			//slipPrtSetTable.Columns.Add(VIEW_CUST_TEL_NO_PRT_DIV_NM, typeof(string));
			//----- h.ueno del---------- end   2007.12.17
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END


            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 >>>>>>START
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FONT_NAME, typeof(string));        
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FONT_SIZE_CD, typeof(int));
            slipPrtSetTable.Columns.Add(VIEW_SLIP_FONT_SIZE_NM, typeof(string));
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FONT_STYLE_CD, typeof(int));
            //slipPrtSetTable.Columns.Add(VIEW_SLIP_FONT_STYLE_NM, typeof(string));
            // 2008.12.11 30413 ���� �t�H���g���̂Ƒ������폜 <<<<<<END
        
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			slipPrtSetTable.Columns.Add(VIEW_PRT_CIRCULATION, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_COPY_COUNT, typeof(int));
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////


			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
			//----- h.ueno del---------- start 2007.12.17
			//slipPrtSetTable.Columns.Add(VIEW_BARCODEACPODRNOPRTNAME, typeof(string));
			//slipPrtSetTable.Columns.Add(VIEW_BARCODECUSTCODEPRTNAME, typeof(string));
			//----- h.ueno del---------- end   2007.12.17

            //2006.12.07 deleted by T-Kidate
            //slipPrtSetTable.Columns.Add(VIEW_BARCODECARMNGNOPRTNAME, typeof(string));
			// 2006.01.30 UENO ADD END //////////////////////////////////////////////
			// �`�[�^�C�v�ʗ�֌W
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
            //2006.12.07 deleted by T-Kidate
			//slipPrtSetTable.Columns.Add(VIEW_MAINWORKDIV_TITLE, typeof(string));
			
			slipPrtSetTable.Columns.Add(VIEW_SPECIAL_PURPOSE_1, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_SPECIAL_PURPOSE_2, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_SPECIAL_PURPOSE_3, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_SPECIAL_PURPOSE_4, typeof(string));
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_1, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_1, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_1, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_1, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_2, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_2, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_2, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_2, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_3, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_3, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_3, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_3, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_4, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_4, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_4, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_4, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_5, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_5, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_5, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_5, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_6, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_6, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_6, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_6, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_7, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_7, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_7, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_7, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_8, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_8, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_8, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_8, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_9, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_9, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_9, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_9, typeof(string));

			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_ID_10, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_NM_10, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_CD_10, typeof(int));
			slipPrtSetTable.Columns.Add(VIEW_EACH_SLIP_TYPE_COL_PRT_NM_10, typeof(string));

			//TODO : 2006/03/15 H.NAKAMURA ADD STA
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_1,   typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_102, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_103, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_104, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_105, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_2, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_202, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_203, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_204, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_205, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_3, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_302, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_303, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_304, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_305, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_4, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_402, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_403, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_404, typeof(string));
			slipPrtSetTable.Columns.Add(VIEW_TITLE_NAME_405, typeof(string));

			//TODO : 2006/03/15 H.NAKAMURA ADD END

			slipPrtSetTable.Columns.Add(VIEW_GUID_KEY,typeof(Guid));

            // --- ADD 2011/07/19 ---------->>>>>
            slipPrtSetTable.Columns.Add(VIEW_SCMANSMARKPRTDIV_TITLE, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_NORMALPRTMARK_TITLE, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_SCMMANUALANSMARK_TITLE, typeof(string));
            slipPrtSetTable.Columns.Add(VIEW_SCMAUTOANSMARK_TITLE, typeof(string));
            // --- ADD 2011/07/19 ----------<<<<<

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//slipPrtSetTable.Columns.Add(VIEW_CUSTRACT_NO_PRT_DIV_CD, typeof(int));
			//slipPrtSetTable.Columns.Add(VIEW_CUSTRACT_NO_PRT_DIV_NM, typeof(string));
			////�_��g�ѓd�b�ԍ��󎚋敪
			//slipPrtSetTable.Columns.Add(VIEW_CUST_CP_NO_PRT_DIV_CD, typeof(int));
			//slipPrtSetTable.Columns.Add(VIEW_CUST_CP_NO_PRT_DIV_NM, typeof(string));
			//----- h.ueno del---------- end   2007.12.17

            this.Bind_DataSet.Tables.Add(slipPrtSetTable);


		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2011/02/16  ���N�n��</br>
        /// <br>              ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{		
			// �R���{�{�b�N�X�̏�����

			//----- h.ueno upd---------- start 2007.12.17
			// ���Ж����
			EnterpriseNamePrtCd_tComEditor.Items.Clear();
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//if (SlipPrtSet._enterpriseNamePrtCdList.Count > 0)
			//{
			//	foreach (DictionaryEntry de in SlipPrtSet._enterpriseNamePrtCdList)
			//	{
			//		EnterpriseNamePrtCd_tComEditor.Items.Add(de.Key, de.Value.ToString());
			//	}
			//}
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
            // 2008.06.05 30413 ���� ���Ж�����敪�R���{�{�b�N�X�ݒ� >>>>>>START
            EnterpriseNamePrtCd_tComEditor.Items.Add(0, "���Ж���");
            EnterpriseNamePrtCd_tComEditor.Items.Add(1, "���_����");
            EnterpriseNamePrtCd_tComEditor.Items.Add(2, "�r�b�g�}�b�v����");
            EnterpriseNamePrtCd_tComEditor.Items.Add(3, "�󎚂��Ȃ�");
            // 2008.06.05 30413 ���� ���Ж�����敪�R���{�{�b�N�X�ݒ� <<<<<<END
			EnterpriseNamePrtCd_tComEditor.MaxDropDownItems = EnterpriseNamePrtCd_tComEditor.Items.Count;
			//----- h.ueno upd---------- end   2007.12.17

			// ����v���r���[
			PrtPreviewExistCode_tComEditor.Items.Clear();
			PrtPreviewExistCode_tComEditor.Items.Add(0, "����");
			PrtPreviewExistCode_tComEditor.Items.Add(1, "�L��");
			PrtPreviewExistCode_tComEditor.MaxDropDownItems = PrtPreviewExistCode_tComEditor.Items.Count;

            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            ////----- h.ueno upd---------- start 2007.12.17
            //// �`�[�p��
            //SlipFormCd_tComEditor.Items.Clear();
            //// 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
            ////if (SlipPrtSet._slipFormCdList.Count > 0)
            ////{
            ////	foreach (DictionaryEntry de in SlipPrtSet._slipFormCdList)
            ////	{
            ////		SlipFormCd_tComEditor.Items.Add(de.Key, de.Value.ToString());
            ////	}
            ////}
            //// 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
            //SlipFormCd_tComEditor.Items.Add(0, "����");
            //SlipFormCd_tComEditor.Items.Add(1, "��p�`�[");
            //SlipFormCd_tComEditor.Items.Add(2, "�A��");
            //SlipFormCd_tComEditor.MaxDropDownItems = SlipFormCd_tComEditor.Items.Count;
            ////----- h.ueno upd---------- end   2007.12.17
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
			
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
			// ���Ӑ�d�b�ԍ���
			//CustTelNoPrtDivCd_tComEditor.Items.Clear();
			//CustTelNoPrtDivCd_tComEditor.Items.Add(0, "�󎚂��Ȃ�");
			//CustTelNoPrtDivCd_tComEditor.Items.Add(1, "�󎚂���");
			//CustTelNoPrtDivCd_tComEditor.MaxDropDownItems = CustTelNoPrtDivCd_tComEditor.Items.Count;
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

            // 2008.12.11 30413 ���� ����ň󎚃R���{�{�b�N�X�ݒ� >>>>>>START
            ConsTaxPrtCd_tComboEditor.Items.Clear();
            ConsTaxPrtCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
            ConsTaxPrtCd_tComboEditor.Items.Add(1, "�󎚂���");
            ConsTaxPrtCd_tComboEditor.MaxDropDownItems = ConsTaxPrtCd_tComboEditor.Items.Count;
            // 2008.12.11 30413 ���� ����ň󎚃R���{�{�b�N�X�ݒ� <<<<<<END

            // ADD 2011/02/16----------------------------------->>>>>
            EntNmPrtExpDiv_tComEditor.Items.Clear();
            EntNmPrtExpDiv_tComEditor.Items.Add(0, "�W��");
            EntNmPrtExpDiv_tComEditor.Items.Add(1, "��");
            EntNmPrtExpDiv_tComEditor.MaxDropDownItems = EntNmPrtExpDiv_tComEditor.Items.Count;
            // ADD 2011/02/16-----------------------------------<<<<<
            
            // 2008.06.05 30413 ���� �Q�l����ŋ敪�R���{�{�b�N�X�ݒ� >>>>>>START
            RefConsTaxDivCd_tComboEditor.Items.Clear();
            RefConsTaxDivCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
            RefConsTaxDivCd_tComboEditor.Items.Add(1, "�󎚂���");
            RefConsTaxDivCd_tComboEditor.MaxDropDownItems = RefConsTaxDivCd_tComboEditor.Items.Count;
            // 2008.06.05 30413 ���� �Q�l����ŋ敪�R���{�{�b�N�X�ݒ� <<<<<<END

            // 2008.06.06 30413 ���� QR�R�[�h�󎚋敪�R���{�{�b�N�X�ݒ� >>>>>>START
            QRCodePrintDivCd_tComboEditor.Items.Clear();
            QRCodePrintDivCd_tComboEditor.Items.Add(1, "�󎚂��Ȃ�");
            QRCodePrintDivCd_tComboEditor.Items.Add(2, "�󎚂���");
            QRCodePrintDivCd_tComboEditor.Items.Add(3, "�ԕi�܂�");
            // 2010/07/06 Add �g�у��[���I�v�V�������L���̏ꍇ�ǉ� >>>
            if (this._QRMailOPFlg)
            {
                QRCodePrintDivCd_tComboEditor.Items.Add(4, "�󎚂���i�g�у��[���j");
                QRCodePrintDivCd_tComboEditor.Items.Add(5, "�ԕi�܂ށi�g�у��[���j");
            }
            // 2010/07/06 Add <<<
            QRCodePrintDivCd_tComboEditor.MaxDropDownItems = QRCodePrintDivCd_tComboEditor.Items.Count;
            // 2008.06.06 30413 ���� QR�R�[�h�󎚋敪�R���{�{�b�N�X�ݒ� <<<<<<END

            // 2008.06.06 30413 ���� �����󎚋敪�R���{�{�b�N�X�ݒ� >>>>>>START
            TimePrintDivCd_tComboEditor.Items.Clear();
            TimePrintDivCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
            TimePrintDivCd_tComboEditor.Items.Add(1, "�󎚂���");
            TimePrintDivCd_tComboEditor.MaxDropDownItems = TimePrintDivCd_tComboEditor.Items.Count;
            // 2008.06.06 30413 ���� �����󎚋敪�R���{�{�b�N�X�ݒ� <<<<<<END

			// �`�[�t�H���g�T�C�Y
			SlipFontSize_tComEditor.Items.Clear();
			SlipFontSize_tComEditor.Items.Add(0, "�W��");
			SlipFontSize_tComEditor.Items.Add(1, "��");
			SlipFontSize_tComEditor.MaxDropDownItems = SlipFontSize_tComEditor.Items.Count;

            // 2008.12.11 30413 ���� �폜���� >>>>>>START
//            // �`�[�t�H���g�X�^�C��
//            SlipFontStyle_tComEditor.Items.Clear();
//            SlipFontStyle_tComEditor.Items.Add(0, "�W��");
//            // 2006.02.08 DEL STA UENO ///////////////////////////////////////////////////////// 
////			SlipFontStyle_tComEditor.Items.Add(1, "����");
//            // 2006.02.08 DEL STA UENO /////////////////////////////////////////////////////////

//            // 2006.02.08 ADD STA UENO ///////////////////////////////////////////////////////// 
//            SlipFontStyle_tComEditor.Items.Add(1, "����");
//            // 2006.02.08 ADD STA UENO /////////////////////////////////////////////////////////
			
//            SlipFontStyle_tComEditor.MaxDropDownItems = SlipFontStyle_tComEditor.Items.Count;
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			// ���ʖ���
			CopyCount_tComboEditor.Items.Clear();
			CopyCount_tComboEditor.Items.Add(1, "1");
			CopyCount_tComboEditor.Items.Add(2, "2");
			CopyCount_tComboEditor.Items.Add(3, "3");
			CopyCount_tComboEditor.Items.Add(4, "4");
			CopyCount_tComboEditor.MaxDropDownItems = CopyCount_tComboEditor.Items.Count;

            // ADD 2011/07/19----------------------------------->>>>>
            // �񓚃}�[�N�󎚋敪
            SCMAnsMarkPrtDiv_tComboEditor.Items.Clear();
            SCMAnsMarkPrtDiv_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
            SCMAnsMarkPrtDiv_tComboEditor.Items.Add(1, "�󎚂���");
            SCMAnsMarkPrtDiv_tComboEditor.MaxDropDownItems = SCMAnsMarkPrtDiv_tComboEditor.Items.Count;
            // ADD 2011/07/19-----------------------------------<<<<<

			//----- h.ueno del---------- start 2007.12.17
			//BarCodeAcpOdrNoPrtCd_tComboEditor.Clear();
			//BarCodeAcpOdrNoPrtCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
			//BarCodeAcpOdrNoPrtCd_tComboEditor.Items.Add(1, "�󎚂���");
			//BarCodeAcpOdrNoPrtCd_tComboEditor.MaxDropDownItems = BarCodeAcpOdrNoPrtCd_tComboEditor.Items.Count;

			//BarCodeCustCodePrtCd_tComboEditor.Clear();
			//BarCodeCustCodePrtCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
			//BarCodeCustCodePrtCd_tComboEditor.Items.Add(1, "�󎚂���");
			//BarCodeCustCodePrtCd_tComboEditor.MaxDropDownItems = BarCodeCustCodePrtCd_tComboEditor.Items.Count;

			////2006.12.018 added by T-Kidate
			//ContractNoPrtDivCd_tComboEditor.Clear();
			//ContractNoPrtDivCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
			//ContractNoPrtDivCd_tComboEditor.Items.Add(1, "�󎚂���");
			//ContractNoPrtDivCd_tComboEditor.MaxDropDownItems = ContractNoPrtDivCd_tComboEditor.Items.Count;
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD END
			
			//// TODO : 2006/03/15 H.NAKAMURA ADD STA

			////2006.12.08 added by T-Kidate
			//ContCpNoPrtDivCd_tComboEditor.Clear();
			//ContCpNoPrtDivCd_tComboEditor.Items.Add(0, "�󎚂��Ȃ�");
			//ContCpNoPrtDivCd_tComboEditor.Items.Add(1, "�󎚂���");
			//ContCpNoPrtDivCd_tComboEditor.MaxDropDownItems = ContCpNoPrtDivCd_tComboEditor.Items.Count;
			//----- h.ueno del---------- end   2007.12.17

			// �X�L�[�}�̐ݒ�
			DataTableSchemaSetting();

			// �l���X�g�����������A�O���b�h�֒ǉ����܂��B
			Infragistics.Win.ValueListsCollection lists = this.eachSlipTypeCol_ultraGrid.DisplayLayout.ValueLists;
			Infragistics.Win.ValueList gridValueList = lists.Add(MY_SCREEN_PRINTDIV_TITLE);
			//�A�C�e����ǉ�
            gridValueList.ValueListItems.Add(0, "�󎚂��Ȃ�");
            gridValueList.ValueListItems.Add(1, "�󎚂���");
			
			gridValueList.MaxDropDownItems = gridValueList.ValueListItems.Count;

            // 2008.12.11 30413 ���� �W�����i�p�̃��X�g���쐬 >>>>>>START
            Infragistics.Win.ValueList gridValueList2 = lists.Add(MY_SCREEN_LIST_PRICE);
            gridValueList2.ValueListItems.Add(0, "�󎚂��Ȃ�");
            gridValueList2.ValueListItems.Add(1, "�󎚂���");
            gridValueList2.ValueListItems.Add(2, "�|�����P");
            gridValueList2.MaxDropDownItems = gridValueList2.ValueListItems.Count;
            // 2008.12.11 30413 ���� �W�����i�p�̃��X�g���쐬 <<<<<<END
            
			// 2006.03.24 H.NAKAMURA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// UI�O���b�h�̏o�͋敪�R���{�̃��X�g�̊O�ς�ݒ�
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor		= System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			appearance.ForeColor		= System.Drawing.Color.Black;
			appearance.TextVAlign		= Infragistics.Win.VAlign.Middle;
			gridValueList.Appearance	= appearance;
			// 2006.03.24 H.NAKAMURA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			// GRID�̏����ݒ�
			GridInitialSetting();

			// TODO : 2006/03/15 H.NAKAMURA ADD END
		}

		/// <summary>
		/// �O���b�h�o�C���h����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2005.04.14</br>
		/// </remarks>
		private void DataTableSchemaSetting()
		{
			// �X�L�[�}�̐ݒ�
			//3/22 h.NAKAMURA ADD
			_bindTable.Columns.Add(MY_SCREEN_ID, typeof(string));
			_bindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
			_bindTable.Columns[MY_SCREEN_ODER].Caption = "";
			_bindTable.Columns.Add(MY_SCREEN_EACH_SLIPTYPECOL_TITLE, typeof(string));
			_bindTable.Columns.Add(MY_SCREEN_PRINTDIV_TITLE, typeof(int));
		}

		/// <summary>
		///	�f�q�h�c�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �f�q�h�c�̏����ݒ���s���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2006.03.15</br>
		/// </remarks>
		private void GridInitialSetting()
		{	

			// �e�[�u���Ɋi�[������ۂ̒l��ݒ�
			DataRow bindRow;
			for (int ix = 0 ; ix < MAX_ROW_COUNT ; ix++)
			{
				int term = ix + 1;
				bindRow = _bindTable.NewRow();
				//3/22 H.NAKAMURA ADD
				bindRow[MY_SCREEN_ID]	= "";
				bindRow[MY_SCREEN_ODER]	= term;
				bindRow[MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= "";
				//				bindRow[MY_SCREEN_PRINTDIV_TITLE]		= 0;
				
				_bindTable.Rows.Add(bindRow);
			}
			// �f�[�^�\�[�X�֒ǉ�
			this.eachSlipTypeCol_ultraGrid.DataSource = _bindTable;

			// �O���b�h�̔w�i�F
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Appearance.BackColor = Color.White;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198,219,255);
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			
			// �s�̒ǉ��s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			// �s�̃T�C�Y�ύX�s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowSizing   = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			// �s�̍폜�s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			// ��̈ړ��s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			// ��̃T�C�Y�ύX�s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
			// ��̌����s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			// �t�B���^�̎g�p�s��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			// ���[�U�[�̃f�[�^������������
			//	this.CheckName_ultraGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

			//	this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.CardAreaAppearance.BackColor = System.Drawing.Color.Transparent;

			// �^�C�g���̊O�ϐݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			
			// �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
			//			this.CheckName_ultraGrid.DisplayLayout.Override.SelectTypeCell	= Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectTypeCol	= Infragistics.Win.UltraWinGrid.SelectType.None;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectTypeRow	= Infragistics.Win.UltraWinGrid.SelectType.None;
			// �݂��Ⴂ�̍s�̐F��ύX
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
			// �s�Z���N�^�\������
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			// �X�N���[���o�[��\��
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
			// �A�N�e�B�u�Z���̔w�i�F
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.White;
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = Color.Black;

			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68 ,208);

			// �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
//			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

			// ��̃A�N�e�B�u�^�C�v�̐ݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].CellActivation = Activation.NoEdit;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Activation.NoEdit;
			//�������\����
			//3/22 H.NAKAMURA ADD
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ID].Hidden = true;  

			// �Z���̕��̐ݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width	= 50;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].Width	= 390;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[MY_SCREEN_PRINTDIV_TITLE].Width	= 120;
			
			// ValueList��ݒ肷��
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Bands[0].Columns[ MY_SCREEN_PRINTDIV_TITLE ].ValueList		= this.eachSlipTypeCol_ultraGrid.DisplayLayout.ValueLists[ MY_SCREEN_PRINTDIV_TITLE ];

			// �I���s�̊O�ϐݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor			= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2			= System.Drawing.Color.FromArgb( 238, 149, 21 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle	= Infragistics.Win.GradientStyle.Vertical;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor			= System.Drawing.Color.Black;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled	= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2	= System.Drawing.Color.FromArgb( 238, 149, 21 );
			// �A�N�e�B�u�s�̊O�ϐݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor				= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2				= System.Drawing.Color.FromArgb( 238, 149, 21 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle		= Infragistics.Win.GradientStyle.Vertical;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor				= System.Drawing.Color.Black;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled		= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2		= System.Drawing.Color.FromArgb( 238, 149, 21 );

			// �s�Z���N�^�̊O�ϐݒ�
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// �r���̐F��ύX
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1,68,208);
//			this.eachSlipTypeCol_ultraGrid.Rows[0].Activate();
		}


		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2010/08/06 caowj PM.NS1012�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void ScreenClear()
		{
			//----- h.ueno add---------- start 2007.12.17
			// ���[�h���x��
			Mode_Label.Text = INSERT_MODE;
			
			//------------
			// �{�^������
			//------------
			Delete_Button.Visible = true;	// ���S�폜�{�^��
			Revive_Button.Visible = true;	// �����{�^��
			Ok_Button.Visible = true;		// �ۑ��{�^��
			Cancel_Button.Visible = true;	// ����{�^��
			
			//----------
			// ���͐���
			//----------
			//----- �`�[����e��ݒ�^�u -----//
			DataInputSystem_tNedit.Enabled			= false;	// �f�[�^���̓V�X�e��
			DataInputSystemNm_tEdit.Enabled			= false;	// �f�[�^���̓V�X�e����
			SlipPrtKind_tNedit.Enabled				= false;	// �`�[������
			SlipPrtKindNm_tEdit.Enabled				= false;	//�`�[�����ʖ�
			
			SlipPrtSetPaperId_tEdit.Enabled			= true;	// �`�[����ݒ�p���[ID
			SlipComment_tEdit.Enabled				= true;	// �`�[�R�����g
			OutConMsg_tEdit.Enabled					= true;	// �o�͊m�F���b�Z�[�W
			EnterpriseNamePrtCd_tComEditor.Enabled	= true;	// ���Ж�����敪
			PrtPreviewExistCode_tComEditor.Enabled	= true;	// ����v���r���[�L���敪

            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFormCd_tComEditor.Enabled			= true;	// �`�[�p���敪
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
			//PrinterMngNo_tComEditor.Enabled			= true;	// �v�����^�Ǘ�No
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END
			TopMarging_tNedit.Enabled				= true;	// ��]��
			BottomMargin_tNedit.Enabled				= true;	// ���]��
			LeftMarging_tNedit.Enabled				= true;	// ���]��
			RightMargin_tNedit.Enabled				= true;	// �E�]��
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
			//CustTelNoPrtDivCd_tComEditor.Enabled	= true;	// ���Ӑ�d�b�ԍ���
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontName_uFontNameEditor.Enabled = true;	// �`�[�t�H���g����
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            SlipFontSize_tComEditor.Enabled = true;	// �`�[�t�H���g�T�C�Y
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontStyle_tComEditor.Enabled = true;	// �`�[�t�H���g�X�^�C��
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            PrtCirculation_tNedit.Enabled = true;	// �������
			CopyCount_tComboEditor.Enabled			= true;	// ���ʖ���
			UpButton.Enabled						= true;	// ��փ{�^��
			DownButton.Enabled						= true;	// ���փ{�^��
			eachSlipTypeCol_ultraGrid.Enabled		= true;	// �`�[�^�C�v�O���b�h
            // 2008.06.05 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            ReissueMark_tEdit.Enabled = true;               // �Ĕ��s�}�[�N

            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            ConsTaxPrtCd_tComboEditor.Enabled = true;       // ����ň�
            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            EntNmPrtExpDiv_tComEditor.Enabled = true; // ADD 2011/02/16

            // --- ADD 2011/07/19 ---------->>>>>
            SCMAnsMarkPrtDiv_tComboEditor.Enabled = true;   // �񓚃}�[�N�󎚋敪
            NormalPrtMark_tEdit.Enabled = true;             // �ʏ�}�[�N
            SCMManualAnsMark_tEdit.Enabled = true;          // �蓮�񓚃}�[�N
            SCMAutoAnsMark_tEdit.Enabled = true;            // �����񓚃}�[�N
            // --- ADD 2011/07/19 ----------<<<<<

            RefConsTaxDivCd_tComboEditor.Enabled = true;    // �Q�l����ŋ敪
            RefConsTaxPrtNm_tEdit.Enabled = true;           // �Q�l����ň󎚖���
            Note1_tEdit.Enabled = true;                     // ���l�P
            Note2_tEdit.Enabled = true;                     // ���l�Q
            Note3_tEdit.Enabled = true;                     // ���l�R
            QRCodePrintDivCd_tComboEditor.Enabled = true;   // QR�R�[�h�󎚋敪
            TimePrintDivCd_tComboEditor.Enabled = true;     // �����󎚋敪
            // 2008.06.05 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            // 2008.09.29 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            DetailRowCount_tNedit.Enabled = true;           // ���׍s��
            HonorificTitle_tEdit.Enabled = true;            // �h��
            // 2008.09.29 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            SlipNoteCharCnt_tNedit.Enabled = true;          // �`�[���l����
            SlipNote2CharCnt_tNedit.Enabled = true;         // �`�[���l�Q����
            SlipNote3CharCnt_tNedit.Enabled = true;         // �`�[���l�R����
            // --- ADD 2009/12/31 ----------<<<<<

            //----- �`�[�^�C�g���^�u -----//
			TitleName1_tEdit.Enabled			= true;		// �`�[�^�C�g���P���ځ\�P
			TitleName102_tEdit.Enabled			= true;		// �`�[�^�C�g���P���ځ\�Q
			TitleName103_tEdit.Enabled			= true;		// �`�[�^�C�g���P���ځ\�R
			TitleName104_tEdit.Enabled			= true;		// �`�[�^�C�g���P���ځ\�S
			TitleName105_tEdit.Enabled			= true;		// �`�[�^�C�g���P���ځ\�T
			ImageColorGuide1_uButton.Enabled	= true;		// �`�[��F�{�^���P
			
			TitleName2_tEdit.Enabled			= true;		// �`�[�^�C�g���Q���ځ\�P
			TitleName202_tEdit.Enabled			= true;		// �`�[�^�C�g���Q���ځ\�Q
			TitleName203_tEdit.Enabled			= true;		// �`�[�^�C�g���Q���ځ\�R
			TitleName204_tEdit.Enabled			= true;		// �`�[�^�C�g���Q���ځ\�S
			TitleName205_tEdit.Enabled			= true;		// �`�[�^�C�g���Q���ځ\�T
			ImageColorGuide2_uButton.Enabled	= true;		// �`�[��F�{�^���Q
			
			TitleName3_tEdit.Enabled			= true;		// �`�[�^�C�g���R���ځ\�P
			TitleName302_tEdit.Enabled			= true;		// �`�[�^�C�g���R���ځ\�Q
			TitleName303_tEdit.Enabled			= true;		// �`�[�^�C�g���R���ځ\�R
			TitleName304_tEdit.Enabled			= true;		// �`�[�^�C�g���R���ځ\�S
			TitleName305_tEdit.Enabled			= true;		// �`�[�^�C�g���R���ځ\�T
			ImageColorGuide3_uButton.Enabled	= true;		// �`�[��F�{�^���R
			
			TitleName4_tEdit.Enabled			= true;		// �`�[�^�C�g���S���ځ\�P
			TitleName402_tEdit.Enabled			= true;		// �`�[�^�C�g���S���ځ\�Q
			TitleName403_tEdit.Enabled			= true;		// �`�[�^�C�g���S���ځ\�R
			TitleName404_tEdit.Enabled			= true;		// �`�[�^�C�g���S���ځ\�S
			TitleName405_tEdit.Enabled			= true;		// �`�[�^�C�g���S���ځ\�T
			ImageColorGuide4_uButton.Enabled = true;		// �`�[��F�{�^���S
			//----- h.ueno add---------- end   2007.12.17


            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            CustomerCode_tNedit.Enabled = true;                // ���Ӑ�R�[�h
            CustomerGuide_uButton.Enabled = true;              // ���Ӑ�K�C�h
            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
			
			//------------
			// �����l�ݒ�
			//------------
			// �f�[�^���̓V�X�e���A�`�[���
			//----- h.ueno add---------- start 2007.12.17
			DataInputSystem_tNedit.Clear();
			SlipPrtKind_tNedit.Clear();
			//----- h.ueno add---------- end   2007.12.17

			//----- h.ueno upd---------- start 2007.12.17
			DataInputSystemNm_tEdit.Clear();
			SlipPrtKindNm_tEdit.Clear();
			//----- h.ueno upd---------- end   2007.12.17
			
			// �`�[�A�o��PGID�A������ڊ֌W
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			SlipPrtSetPaperId_tEdit.Text = "";					// �`�[����ݒ�p���[ID
			SlipComment_tEdit.Text       = "";					// �`�[�R�����g
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END
			
			OutputFormFileName_tEdit.Text        = "";			// �o�̓t�@�C�����i��ʔ�\���j
			OutputPgId_tEdit.Text                = "";			// ���Ж����
			OutputPgClassId_tEdit.Text           = "";			// �o��PG�N���XID�i��ʔ�\���j
			OutConMsg_tEdit.Text                 = "";			// �o�͊m�F���b�Z�[�W
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			OptionCode_tNedit.Text               = "";
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
			EnterpriseNamePrtCd_tComEditor.Value = 0;			// ���Ж����
			PrtPreviewExistCode_tComEditor.Value = 0;			// ����v���r���[
			//----- h.ueno upd---------- start 2007.12.17
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFormCd_tComEditor.Value = 0;					// �`�[�p���敪�i0:�����j
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
			//PrinterMngNo_tComEditor.Value        = 0;			// �v�����^�Ǘ�No�i�擪�f�[�^�\���j
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END
			PrtCirculation_tNedit.SetInt(1);					// ��������i1���j
			TopMarging_tNedit.SetValue(0);						// ��]���i0�j
			LeftMarging_tNedit.SetValue(0);						// ���]���i0�j

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			RightMargin_tNedit.SetValue(0);						// �E�]���i0�j
			BottomMargin_tNedit.SetValue(0);					// ���]���i0�j
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
			//CustTelNoPrtDivCd_tComEditor.Value = 0;				// ���Ӑ�d�b�ԍ��󎚁i0:�󎚂���j
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

            // 2008.06.05 30413 ���� �ǉ����ڂ̏����� >>>>>>START
            ReissueMark_tEdit.Text = "";                        // �Ĕ��s�}�[�N

            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            ConsTaxPrtCd_tComboEditor.Value = 0;                // ����ň�
            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            EntNmPrtExpDiv_tComEditor.Value = 0; //2011/02/16
            
            RefConsTaxDivCd_tComboEditor.Value = 0;             // �Q�l����ŋ敪�i0:�󎚂��Ȃ��j
            RefConsTaxPrtNm_tEdit.Text = "";                    // �Q�l����ň󎚖���
            Note1_tEdit.Text = "";                              // ���l�P
            Note2_tEdit.Text = "";                              // ���l�Q
            Note3_tEdit.Text = "";                              // ���l�R
            QRCodePrintDivCd_tComboEditor.Value = 1;            // QR�R�[�h�󎚋敪
            TimePrintDivCd_tComboEditor.Value = 0;              // �����󎚋敪
            // 2008.06.05 30413 ���� �ǉ����ڂ̏����� <<<<<<END

            // 2008.08.28 30413 ���� �ǉ����ڂ̏����� >>>>>>START
            DetailRowCount_tNedit.SetValue(1);                  // ���׍s��
            HonorificTitle_tEdit.Text = "";                     // �h��
            // 2008.08.28 30413 ���� �ǉ����ڂ̏����� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            SlipNoteCharCnt_tNedit.Text = "";                      // �`�[���l����
            SlipNote2CharCnt_tNedit.Text = "";                     // �`�[���l�Q����
            SlipNote3CharCnt_tNedit.Text = "";                     // �`�[���l�R����
            // --- ADD 2009/12/31 ----------<<<<<

            // --- ADD 2011/07/19 ---------->>>>>
            SCMAnsMarkPrtDiv_tComboEditor.Value = 0;               // �񓚃}�[�N�󎚋敪
            NormalPrtMark_tEdit.Text = "";                         // �ʏ�}�[�N
            SCMManualAnsMark_tEdit.Text = "";                      // �蓮�񓚃}�[�N
            SCMAutoAnsMark_tEdit.Text = "";                        // �����񓚃}�[�N
            // --- ADD 2011/07/19 ----------<<<<<

			// �`�[�t�H���g�֌W
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontName_uFontNameEditor.Text = "�l�r ����";	// �t�H���g�i�l�r �����j
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            SlipFontSize_tComEditor.Value = 0;				// �t�H���g�T�C�Y�i0:�W���j
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontStyle_tComEditor.Value = 0;				// �t�H���g�X�^�C���i0:�W���j
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            //----- h.ueno upd---------- end   2007.12.17
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			// ���ʖ���
			CopyCount_tComboEditor.Value = 1;

			// �`�[�^�C�g���֌W
			// TODO :2006/03/15 H.NAKAMURA ADD STA
			TitleName1_tEdit.Text = "";
			TitleName102_tEdit.Text = "";
			TitleName103_tEdit.Text = "";
			TitleName104_tEdit.Text = "";
			TitleName105_tEdit.Text = "";
			TitleName2_tEdit.Text = "";
			TitleName202_tEdit.Text = "";
			TitleName203_tEdit.Text = "";
			TitleName204_tEdit.Text = "";
			TitleName205_tEdit.Text = "";
			TitleName3_tEdit.Text = "";
			TitleName302_tEdit.Text = "";
			TitleName303_tEdit.Text = "";
			TitleName304_tEdit.Text = "";
			TitleName305_tEdit.Text = "";
			TitleName4_tEdit.Text = "";
			TitleName402_tEdit.Text = "";
			TitleName403_tEdit.Text = "";
			TitleName404_tEdit.Text = "";
			TitleName405_tEdit.Text = "";
			// TODO :2006/03/15 H.NAKAMURA ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			// �`�[�W���F
			DispToColor(1, 0, 0, 0);
			DispToColor(2, 0, 0, 0);
			DispToColor(3, 0, 0, 0);
			DispToColor(4, 0, 0, 0);
			DispToColor(5, 0, 0, 0);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

//----- h.ueno add---------- start 2007.12.17
			//--------------
			// �B�����ڃN���A
			//--------------
			SpecialPurpose1_tEdit.Clear();	// ����p�r1
			SpecialPurpose2_tEdit.Clear();	// ����p�r2
			SpecialPurpose3_tEdit.Clear();	// ����p�r3
			SpecialPurpose4_tEdit.Clear();	// ����p�r4
//----- h.ueno add---------- end   2007.12.17

			//----- h.ueno del---------- start 2007.12.17
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD START
			//BarCodeAcpOdrNoPrtCd_tComboEditor.Value = 0;
			//BarCodeCustCodePrtCd_tComboEditor.Value = 0;

			//ContractNoPrtDivCd_tComboEditor.Value = 0;
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD END

			////TODO : 2006/03/15 H.NAKAMURA ADD STA
			//ContCpNoPrtDivCd_tComboEditor.Value = 0;
			////TODO : 2006/03/15 H.NAKAMURA ADD END
			//----- h.ueno del---------- end   2007.12.17

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            this.CustomerCode_tNedit.Clear();
            this.CustomerName_uLabel.Text = string.Empty;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2010/08/06 caowj PM.NS1012�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI ADD START
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
			// �v�����^�Ǘ�No.
			//PrinterMngNo_tComEditor.Items.Clear();

			//ArrayList prtManageList;

			//if (this._prtManageAcs.GetBuff(out prtManageList, this._enterpriseCode, 0) == 0)
			//{
			//	foreach (PrtManage ptrmanage in prtManageList)
			//	{
			//		PrinterMngNo_tComEditor.Items.Add(ptrmanage.PrinterMngNo, ptrmanage.PrinterName);
			//	}
			//}
            
			//if (PrinterMngNo_tComEditor.Items.Count > 0)
			//{
			//	PrinterMngNo_tComEditor.MaxDropDownItems = PrinterMngNo_tComEditor.Items.Count;
			//} 
			//else if (PrinterMngNo_tComEditor.Items.Count == 0)
			//{
			//	PrinterMngNo_tComEditor.Items.Add(0," ");
			//}

			//PrinterMngNo_tComEditor.MaxDropDownItems = 8;
            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI ADD END

			//----- h.ueno del---------- start 2007.12.17
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.11 TAKAHASHI ADD START
			//if (this._barCodeOPFlg == true)
			//{
			//    this.ultraLabel19.Visible = true;
			//    this.ultraLabel14.Visible = true;
			//    this.ultraLabel15.Visible = true;
			//    //2006.12.08 deleted by T-Kidate
			//    //this.ultraLabel16.Visible = true;
			//    this.BarCodeAcpOdrNoPrtCd_tComboEditor.Visible = true;
			//    this.BarCodeCustCodePrtCd_tComboEditor.Visible = true;
			//    //2006.12.08 deleted by T-Kidate
			//    //this.ContractNoPrtDivCd_tComboEditor.Visible = true;
			//}
			//else
			//{
			//    this.ultraLabel19.Visible = false;
			//    this.ultraLabel14.Visible = false;
			//    this.ultraLabel15.Visible = false;
			//    //2006.12.08 deleted by T-Kidate
			//    //this.ultraLabel16.Visible = false;
			//    this.BarCodeAcpOdrNoPrtCd_tComboEditor.Visible = false;
			//    this.BarCodeCustCodePrtCd_tComboEditor.Visible = false;
			//    //2006.12.08 deleted by T-Kidate
			//    //this.ContractNoPrtDivCd_tComboEditor.Visible = false;
			//}
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.11 TAKAHASHI ADD END
			//----- h.ueno del---------- end   2007.12.17

			// �V�K�̏ꍇ
			if (this._dataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;

				// �{�^������
				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
                
//----- h.ueno add---------- start 2007.12.17
				//------------
				// �K�C�h�N��
				//------------
				// �I���f�[�^�̃L�[���擾
				SlipPrtSet slipPrtSetNew = null;
				int status = this._slipPrtSetAcs.ExecuteGuid(out slipPrtSetNew, this._enterpriseCode);
				
				// �L�[���ڂ��ݒ肳��Ă��Ȃ��ꍇ��ʂ����
				if ((slipPrtSetNew.SlipPrtSetPaperId == null)||(slipPrtSetNew.SlipPrtSetPaperId == ""))
				{
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return;
				}
				
				//----------------------------
				// �L�[����Ɍ����f�[�^���擾
				//----------------------------
				string searchStr = string.Format("{0}='{1}' and {2}='{3}' and {4}='{5}'"
					, VIEW_DATA_INPUT_SYSTEM_CODE, slipPrtSetNew.DataInputSystem
					, VIEW_SLIP_PRT_KIND_CODE, slipPrtSetNew.SlipPrtKind
					, VIEW_SLIP_PRT_SET_PAPER_ID, slipPrtSetNew.SlipPrtSetPaperId);

				DataRow[] foundRateRow = this.Bind_DataSet.Tables[VIEW_TABLE].Select(searchStr);
				
				if(foundRateRow.Length == 0)
				{
					// �Y���f�[�^����
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return;
				}
				
				// �f�[�^�e�[�u����GUID����ɓ`�[����ݒ�I�u�W�F�N�g�擾
				Guid guid = (Guid)foundRateRow[0][VIEW_GUID_KEY];	// �擾�f�[�^�͕K��1���Ȃ̂�0�Œ�
				
				slipPrtSetNew = (SlipPrtSet)this._slipPrtSetTable[guid];
				
				// �N���[�����쐬
				this._slipPrtSetClone = slipPrtSetNew.Clone();
				
				// ��ʓW�J����
				SlipPrtSetToScreen(slipPrtSetNew);
                PCCAnsMark(slipPrtSetNew); // ADD 2011/07/19
				
//----- h.ueno add---------- end   2007.12.17
				
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
				this.ImageColorGuide1_uButton.Visible = true;
				this.ImageColorGuide2_uButton.Visible = true;
				this.ImageColorGuide3_uButton.Visible = true;
				this.ImageColorGuide4_uButton.Visible = true;
////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//				this.ImageColorGuide5_uButton.Visible = true;
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
			}
			else
			{
				// �\�����擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY];
				SlipPrtSet slipPrtSet = new SlipPrtSet();
				slipPrtSet = (SlipPrtSet)this._slipPrtSetTable[guid];
				
				// �N���[�����쐬
				this._slipPrtSetClone = slipPrtSet.Clone();
				
				// ��ʓW�J����
				SlipPrtSetToScreen(slipPrtSet);
                PCCAnsMark(slipPrtSet); // ADD 2011/07/19

				if(slipPrtSet.LogicalDeleteCode == 0)
				{
					//----- h.ueno del---------- start 2007.12.17
					// �K�v�Ȃ��Ǝv����
					//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.11 TAKAHASHI ADD START
					//string prtName = this._slipPrtSetAcs.GetPrinterMngName(this._enterpriseCode, slipPrtSet.PrinterMngNo);
					//if (prtName == "")
					//{
					//    PrinterMngNo_tComEditor.NullText = "";
					//}
					//else if (prtName == "���o�^")
					//{
					//    PrinterMngNo_tComEditor.NullText = "���o�^";
					//}
					//else
					//{
					//    PrinterMngNo_tComEditor.NullText = "�폜��";
					//}
					//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.11 TAKAHASHI ADD END
					//----- h.ueno del---------- end   2007.12.17

					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					// �{�^������
					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					
					//----- h.ueno add---------- start 2007.12.17
					// ���͐���
					SlipPrtSetPaperId_tEdit.Enabled = false;		// �`�[����ݒ�p���[ID���͕s��
					//----- h.ueno add---------- end   2007.12.17

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
					this.ImageColorGuide1_uButton.Visible = true;
					this.ImageColorGuide2_uButton.Visible = true;
					this.ImageColorGuide3_uButton.Visible = true;
					this.ImageColorGuide4_uButton.Visible = true;
				}
				else
				{
					//----- h.ueno add---------- start 2007.12.17
					// �폜���[�h
					Mode_Label.Text = DELETE_MODE;

					// �{�^������
					this.Ok_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Revive_Button.Visible = true;					
					this.Delete_Button.Visible = true;

					//----- �`�[����e��ݒ�^�u -----//
					DataInputSystemNm_tEdit.Enabled			= false;	// �f�[�^���̓V�X�e��
					SlipPrtKindNm_tEdit.Enabled				= false;	// �`�[������
					SlipPrtSetPaperId_tEdit.Enabled			= false;	// �`�[����ݒ�p���[ID
					SlipComment_tEdit.Enabled				= false;	// �`�[�R�����g
					OutConMsg_tEdit.Enabled					= false;	// �o�͊m�F���b�Z�[�W
					EnterpriseNamePrtCd_tComEditor.Enabled	= false;	// ���Ж�����敪
					PrtPreviewExistCode_tComEditor.Enabled	= false;	// ����v���r���[�L���敪
                    // 2008.12.11 30413 ���� �폜���� >>>>>>START
                    //SlipFormCd_tComEditor.Enabled = false;	// �`�[�p���敪
                    // 2008.12.11 30413 ���� �폜���� <<<<<<END
                    // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� >>>>>>START
					//PrinterMngNo_tComEditor.Enabled			= false;	// �v�����^�Ǘ�No
                    // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�̂��߁A�R�����g�� <<<<<<END
					TopMarging_tNedit.Enabled				= false;	// ��]��
					BottomMargin_tNedit.Enabled				= false;	// ���]��
					LeftMarging_tNedit.Enabled				= false;	// ���]��
					RightMargin_tNedit.Enabled				= false;	// �E�]��
                    // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
					//CustTelNoPrtDivCd_tComEditor.Enabled	= false;	// ���Ӑ�d�b�ԍ���
                    // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
                    // 2008.12.11 30413 ���� �폜���� >>>>>>START
                    //SlipFontName_uFontNameEditor.Enabled = false;	// �`�[�t�H���g����
                    // 2008.12.11 30413 ���� �폜���� <<<<<<END
                    SlipFontSize_tComEditor.Enabled = false;	// �`�[�t�H���g�T�C�Y
                    // 2008.12.11 30413 ���� �폜���� >>>>>>START
                    //SlipFontStyle_tComEditor.Enabled = false;	// �`�[�t�H���g�X�^�C��
                    // 2008.12.11 30413 ���� �폜���� <<<<<<END
                    PrtCirculation_tNedit.Enabled = false;	// �������
					CopyCount_tComboEditor.Enabled			= false;	// ���ʖ���
					UpButton.Enabled						= false;	// ��փ{�^��
					DownButton.Enabled						= false;	// ���փ{�^��
					eachSlipTypeCol_ultraGrid.Enabled		= false;	// �`�[�^�C�v�O���b�h
                    // 2008.06.05 30413 ���� �ǉ����ڂ̐��� >>>>>>START
                    ReissueMark_tEdit.Enabled = false;                  // �Ĕ��s�}�[�N

                    // 2008.12.11 30413 ���� �ǉ����ڂ̐��� >>>>>>START
                    ConsTaxPrtCd_tComboEditor.Enabled = false;          // ����ň�
                    // 2008.12.11 30413 ���� �ǉ����ڂ̐��� <<<<<<END

                    EntNmPrtExpDiv_tComEditor.Enabled = false;  //2011/02/16
                    
                    RefConsTaxDivCd_tComboEditor.Enabled = false;       // �Q�l����ŋ敪
                    RefConsTaxPrtNm_tEdit.Enabled = false;              // �Q�l����ň󎚖���
                    Note1_tEdit.Enabled = false;                        // ���l�P
                    Note2_tEdit.Enabled = false;                        // ���l�Q
                    Note3_tEdit.Enabled = false;                        // ���l�R
                    QRCodePrintDivCd_tComboEditor.Enabled = false;      // QR�R�[�h�󎚋敪
                    TimePrintDivCd_tComboEditor.Enabled = false;        // �����󎚋敪
                    // 2008.06.05 30413 ���� �ǉ����ڂ̐��� <<<<<<END

                    // 2008.08.28 30413 ���� �ǉ����ڂ̐��� >>>>>>START
                    DetailRowCount_tNedit.Enabled = false;              // ���׍s��
                    HonorificTitle_tEdit.Enabled = false;               // �h��
                    // 2008.08.28 30413 ���� �ǉ����ڂ̐��� <<<<<<END

                    // --- ADD 2009/12/31 ---------->>>>>
                    SlipNoteCharCnt_tNedit.Enabled = false;                // �`�[���l����
                    SlipNote2CharCnt_tNedit.Enabled = false;               // �`�[���l�Q����
                    SlipNote3CharCnt_tNedit.Enabled = false;               // �`�[���l�R����
                    // --- ADD 2009/12/31 ----------<<<<<

                    // --- ADD 2011/07/19 ---------->>>>>
                    SCMAnsMarkPrtDiv_tComboEditor.Enabled = false;   // �񓚃}�[�N�󎚋敪
                    NormalPrtMark_tEdit.Enabled = false;             // �ʏ�}�[�N
                    SCMManualAnsMark_tEdit.Enabled = false;          // �蓮�񓚃}�[�N
                    SCMAutoAnsMark_tEdit.Enabled = false;            // �����񓚃}�[�N
                    // --- ADD 2011/07/19 ----------<<<<<

					//----- �`�[�^�C�g���^�u -----//
					TitleName1_tEdit.Enabled				= false;	// �`�[�^�C�g���P���ځ\�P
					TitleName102_tEdit.Enabled				= false;	// �`�[�^�C�g���P���ځ\�Q
					TitleName103_tEdit.Enabled				= false;	// �`�[�^�C�g���P���ځ\�R
					TitleName104_tEdit.Enabled				= false;	// �`�[�^�C�g���P���ځ\�S
					TitleName105_tEdit.Enabled				= false;	// �`�[�^�C�g���P���ځ\�T
					ImageColorGuide1_uButton.Enabled		= false;	// �`�[��F�{�^���P

					TitleName2_tEdit.Enabled				= false;	// �`�[�^�C�g���Q���ځ\�P
					TitleName202_tEdit.Enabled				= false;	// �`�[�^�C�g���Q���ځ\�Q
					TitleName203_tEdit.Enabled				= false;	// �`�[�^�C�g���Q���ځ\�R
					TitleName204_tEdit.Enabled				= false;	// �`�[�^�C�g���Q���ځ\�S
					TitleName205_tEdit.Enabled				= false;	// �`�[�^�C�g���Q���ځ\�T
					ImageColorGuide2_uButton.Enabled		= false;	// �`�[��F�{�^���Q

					TitleName3_tEdit.Enabled				= false;	// �`�[�^�C�g���R���ځ\�P
					TitleName302_tEdit.Enabled				= false;	// �`�[�^�C�g���R���ځ\�Q
					TitleName303_tEdit.Enabled				= false;	// �`�[�^�C�g���R���ځ\�R
					TitleName304_tEdit.Enabled				= false;	// �`�[�^�C�g���R���ځ\�S
					TitleName305_tEdit.Enabled				= false;	// �`�[�^�C�g���R���ځ\�T
					ImageColorGuide3_uButton.Enabled		= false;	// �`�[��F�{�^���R

					TitleName4_tEdit.Enabled				= false;	// �`�[�^�C�g���S���ځ\�P
					TitleName402_tEdit.Enabled				= false;	// �`�[�^�C�g���S���ځ\�Q
					TitleName403_tEdit.Enabled				= false;	// �`�[�^�C�g���S���ځ\�R
					TitleName404_tEdit.Enabled				= false;	// �`�[�^�C�g���S���ځ\�S
					TitleName405_tEdit.Enabled				= false;	// �`�[�^�C�g���S���ځ\�T
					ImageColorGuide4_uButton.Enabled		= false;	// �`�[��F�{�^���S
					//----- h.ueno add---------- end   2007.12.17

                    // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                    CustomerCode_tNedit.Enabled = false;                // ���Ӑ�R�[�h
                    CustomerGuide_uButton.Enabled = false;              // ���Ӑ�K�C�h
                    // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
				}
					
////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//				this.ImageColorGuide5_uButton.Visible = true;
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

////////////////////////////////////////////// 2006.01.25 TERASAKA DEL STA //
//				this.EnterpriseNamePrtCd_tComEditor.Focus();
// 2006.01.25 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.01.25 TERASAKA ADD STA //
	
				this.eachSlipTypeCol_ultraGrid.Rows[0].Activate();
//				this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance = null;
				this.MainTabControl.SelectedTab = this.MainTabControl.Tabs["SlipPrtSet"];
				this.OutConMsg_tEdit.Focus();
				this.OutConMsg_tEdit.SelectAll();

// 2006.01.25 TERASAKA ADD END //////////////////////////////////////////////

                // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                if (Mode_Label.Text.Equals(UPDATE_MODE))
                {
                    this.CustomerCode_tNedit.Focus();
                }
                // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
			}
            // ADD 2011/08/11----->>>
            if ((int)QRCodePrintDivCd_tComboEditor.Value == 1)
            {
                _slipPrtSetClone.QRCodePrintDivCd = 1;
            }
            // ADD 2011/08/11-----<<<
		}

        /// <summary>
        /// �񓚋敪�̈���ݒ��ǉ����f
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       �@: �񓚋敪�̈���ݒ��ǉ����f�������܂��B</br>
		/// <br>Programmer	: chenyd</br>
		/// <br>Date		: 2011.07.19</br>
        /// </remarks>
        private void PCCAnsMark(SlipPrtSet slipPrtSet)
        {
            if (!this._PCCOPFlg || (slipPrtSet.SlipPrtKind != 140 && slipPrtSet.SlipPrtKind != 30 && slipPrtSet.SlipPrtKind != 160))
            {
                ultraLabel19.Visible = false;                    // �񓚃}�[�N�󎚋敪
                SCMAnsMarkPrtDiv_tComboEditor.Visible = false;   // �񓚃}�[�N�󎚋敪
                ultraLabel20.Visible = false;                    // �ʏ�}�[�N
                NormalPrtMark_tEdit.Visible = false;             // �ʏ�}�[�N
                ultraLabel46.Visible = false;                    // �蓮�񓚃}�[�N
                SCMManualAnsMark_tEdit.Visible = false;          // �蓮�񓚃}�[�N
                ultraLabel47.Visible = false;                    // �����񓚃}�[�N
                SCMAutoAnsMark_tEdit.Visible = false;            // �����񓚃}�[�N
                
            }
            else
            {
                ultraLabel19.Visible = true;                    // �񓚃}�[�N�󎚋敪
                SCMAnsMarkPrtDiv_tComboEditor.Visible = true;    // �񓚃}�[�N�󎚋敪
                ultraLabel20.Visible = true;                    // �ʏ�}�[�N
                NormalPrtMark_tEdit.Visible = true;              // �ʏ�}�[�N
                ultraLabel46.Visible = true;                    // �蓮�񓚃}�[�N
                SCMManualAnsMark_tEdit.Visible = true;           // �蓮�񓚃}�[�N
                ultraLabel47.Visible = true;                    // �����񓚃}�[�N
                SCMAutoAnsMark_tEdit.Visible = true;             // �����񓚃}�[�N
            }

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void SlipPrtSetToScreen(SlipPrtSet slipPrtSet)
		{
			// �f�[�^���̓V�X�e���y�ѓ`�[���
			//----- h.ueno add---------- start 2007.12.17
			DataInputSystem_tNedit.SetInt(slipPrtSet.DataInputSystem);
			SlipPrtKind_tNedit.SetInt(slipPrtSet.SlipPrtKind);
			//----- h.ueno add---------- start 2007.12.17

			DataInputSystemNm_tEdit.Text = slipPrtSet.DataInputSystemName;
			//----- h.ueno upd---------- start 2007.12.17
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̐ݒ��ύX >>>>>>START
			// �Œ薼�̂�E�N���X�ɂ�SortedList�Œ�`���A�擾����悤�C��
			//SlipPrtKindNm_tEdit.Text = SlipPrtSet.GetSortedListNm(slipPrtSet.SlipPrtKind, SlipPrtSet._slipPrtKindList);
            			
			//if (slipPrtSet.DataInputSystem != 3)
			//{
            switch (slipPrtSet.SlipPrtKind)
            {
                case 10:
                    SlipPrtKindNm_tEdit.Text = "���Ϗ�";
                    break;
                case 20:
                    SlipPrtKindNm_tEdit.Text = "�w����";
                    break;
                case 21:
                    SlipPrtKindNm_tEdit.Text = "���菑";
                    break;
                case 30:
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX >>>>>>START
                    //SlipPrtKindNm_tEdit.Text = "�[�i��";
                    SlipPrtKindNm_tEdit.Text = "����`�[";
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX <<<<<<END
                    break;
                case 40:
                    SlipPrtKindNm_tEdit.Text = "�ԕi�`�[";
                    break;
                case 100:
                    SlipPrtKindNm_tEdit.Text = "���[�N�V�[�g";
                    break;
                case 110:
                    SlipPrtKindNm_tEdit.Text = "�{�f�B���@�}";
                    break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                case 120:
                    SlipPrtKindNm_tEdit.Text = "�󒍓`�[";
                    break;
                case 130:
                    SlipPrtKindNm_tEdit.Text = "�ݏo�`�[";
                    break;
                case 140:
                    SlipPrtKindNm_tEdit.Text = "���ϓ`�[";
                    break;
                case 150:
                    SlipPrtKindNm_tEdit.Text = "�݌Ɉړ��`�[";
                    break;
                case 160:
                    SlipPrtKindNm_tEdit.Text = "�t�n�d�`�[";
                    break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
            }
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̐ݒ��ύX <<<<<<END
			//}
			//else
			//{
			//    switch (slipPrtSet.SlipPrtKind)
			//    {
			//        case 10:
			//            SlipPrtKind_tEdit.Text = "���Ϗ�";
			//            break;

			//        case 20:
			//            SlipPrtKind_tEdit.Text = "������";
			//            break;
			//    }
			//}
			//----- h.ueno upd---------- end   2007.12.17

			// �`�[�A�o��PGID�A������ڊ֌W
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			SlipPrtSetPaperId_tEdit.Text         = slipPrtSet.SlipPrtSetPaperId;
			SlipComment_tEdit.Text               = slipPrtSet.SlipComment;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			OutputFormFileName_tEdit.Text        = slipPrtSet.OutputFormFileName;
			OutputPgId_tEdit.Text                = slipPrtSet.OutputPgId;
			OutputPgClassId_tEdit.Text           = slipPrtSet.OutputPgClassId;
			OutConMsg_tEdit.Text                 = slipPrtSet.OutConfimationMsg;
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			OptionCode_tNedit.DataText           = slipPrtSet.OptionCode.ToString();
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
			EnterpriseNamePrtCd_tComEditor.Value = slipPrtSet.EnterpriseNamePrtCd;
			PrtPreviewExistCode_tComEditor.Value = slipPrtSet.PrtPreviewExistCode;
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //----- h.ueno upd---------- start 2007.12.17
            //SlipFormCd_tComEditor.Value          = slipPrtSet.SlipFormCd;
			//----- h.ueno upd---------- end   2007.12.17
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//PrinterMngNo_tComEditor.Value = slipPrtSet.PrinterMngNo;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
			PrtCirculation_tNedit.DataText       = slipPrtSet.PrtCirculation.ToString();
			TopMarging_tNedit.DataText           = slipPrtSet.TopMargin.ToString();
			LeftMarging_tNedit.DataText          = slipPrtSet.LeftMargin.ToString();

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			RightMargin_tNedit.DataText          = slipPrtSet.RightMargin.ToString();
			BottomMargin_tNedit.DataText         = slipPrtSet.BottomMargin.ToString();
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
			//CustTelNoPrtDivCd_tComEditor.Value   = slipPrtSet.CustTelNoPrtDivCd;
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

            // 2008.06.05 30413 ���� �ǉ����ڂ֒l��W�J >>>>>>START
            ReissueMark_tEdit.Text = slipPrtSet.ReissueMark;                            // �Ĕ��s�}�[�N

            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            ConsTaxPrtCd_tComboEditor.Value = slipPrtSet.ConsTaxPrtCd;                  // ����ň�
            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            EntNmPrtExpDiv_tComEditor.Value = slipPrtSet.EntNmPrtExpDiv;                // ���Ж��� // ADD 2011/02/16
            RefConsTaxDivCd_tComboEditor.Value = slipPrtSet.RefConsTaxDivCd;            // �Q�l����ŋ敪
            RefConsTaxPrtNm_tEdit.Text = slipPrtSet.RefConsTaxPrtNm;                    // �Q�l����ň󎚖���
            Note1_tEdit.Text = slipPrtSet.Note1;                                        // ���l�P
            Note2_tEdit.Text = slipPrtSet.Note2;                                        // ���l�Q
            Note3_tEdit.Text = slipPrtSet.Note3;                                        // ���l�R
            QRCodePrintDivCd_tComboEditor.Value = slipPrtSet.QRCodePrintDivCd;          // QR�R�[�h�󎚋敪
            if (QRCodePrintDivCd_tComboEditor.Value == null) QRCodePrintDivCd_tComboEditor.Value = 1;
            TimePrintDivCd_tComboEditor.Value = slipPrtSet.TimePrintDivCd;              // �����󎚋敪
            // 2008.06.05 30413 ���� �ǉ����ڂ֒l��W�J <<<<<<END

            // 2008.08.28 30413 ���� �ǉ����ڂ֒l��W�J >>>>>>START
            DetailRowCount_tNedit.DataText = slipPrtSet.DetailRowCount.ToString();      // ���׍s��
            HonorificTitle_tEdit.Text = slipPrtSet.HonorificTitle;                      // �h��
            // 2008.08.28 30413 ���� �ǉ����ڂ֒l��W�J <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            if (slipPrtSet.SlipNoteCharCnt != 0)
            {
                SlipNoteCharCnt_tNedit.SetInt(slipPrtSet.SlipNoteCharCnt);              // �`�[���l����
            }
            if (slipPrtSet.SlipNote2CharCnt != 0)
            {
                SlipNote2CharCnt_tNedit.SetInt(slipPrtSet.SlipNote2CharCnt);            // �`�[���l�Q����
            }
            if (slipPrtSet.SlipNote3CharCnt != 0)
            {
                SlipNote3CharCnt_tNedit.SetInt(slipPrtSet.SlipNote3CharCnt);            // �`�[���l�R����
            }
            // --- ADD 2009/12/31 ----------<<<<<

			// �`�[�t�H���g�֌W
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontName_uFontNameEditor.Text = slipPrtSet.SlipFontName;
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            SlipFontSize_tComEditor.Value = slipPrtSet.SlipFontSize;
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //SlipFontStyle_tComEditor.Value = slipPrtSet.SlipFontStyle;
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			// ���ʖ���
			CopyCount_tComboEditor.Value         = slipPrtSet.CopyCount;

            // --- ADD 2011/07/19 ---------->>>>>
            SCMAnsMarkPrtDiv_tComboEditor.Value = slipPrtSet.SCMAnsMarkPrtDiv;          // �񓚃}�[�N�󎚋敪
            NormalPrtMark_tEdit.Text = slipPrtSet.NormalPrtMark;                        // �ʏ�}�[�N
            SCMManualAnsMark_tEdit.Text = slipPrtSet.SCMManualAnsMark;                  // �蓮�񓚃}�[�N
            SCMAutoAnsMark_tEdit.Text = slipPrtSet.SCMAutoAnsMark; 
            // --- ADD 2011/07/19 ----------<<<<<

			// �`�[�^�C�g���֌W
			// TODO : 2006/03/15 H.NAKAMURA ADD 
			TitleName1_tEdit.Text   = slipPrtSet.TitleName1;
			TitleName102_tEdit.Text = slipPrtSet.TitleName102;
			TitleName103_tEdit.Text = slipPrtSet.TitleName103;
			TitleName104_tEdit.Text = slipPrtSet.TitleName104;
			TitleName105_tEdit.Text = slipPrtSet.TitleName105;
			TitleName2_tEdit.Text = slipPrtSet.TitleName2;
			TitleName202_tEdit.Text = slipPrtSet.TitleName202;
			TitleName203_tEdit.Text = slipPrtSet.TitleName203;
			TitleName204_tEdit.Text = slipPrtSet.TitleName204;
			TitleName205_tEdit.Text = slipPrtSet.TitleName205;
			TitleName3_tEdit.Text = slipPrtSet.TitleName3;
			TitleName302_tEdit.Text = slipPrtSet.TitleName302;
			TitleName303_tEdit.Text = slipPrtSet.TitleName303;
			TitleName304_tEdit.Text = slipPrtSet.TitleName304;
			TitleName305_tEdit.Text = slipPrtSet.TitleName305;
			TitleName4_tEdit.Text = slipPrtSet.TitleName4;
			TitleName402_tEdit.Text = slipPrtSet.TitleName402;
			TitleName403_tEdit.Text = slipPrtSet.TitleName403;
			TitleName404_tEdit.Text = slipPrtSet.TitleName404;
			TitleName405_tEdit.Text = slipPrtSet.TitleName405;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			// �`�[�^�C�v�ʗ�֌W
			//3/22 H.NAKAMURA ADD
			this._bindTable.Rows[0][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId1;
			this._bindTable.Rows[1][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId2;
			this._bindTable.Rows[2][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId3;
			this._bindTable.Rows[3][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId4;
			this._bindTable.Rows[4][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId5;
			this._bindTable.Rows[5][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId6;
			this._bindTable.Rows[6][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId7;
			this._bindTable.Rows[7][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId8;
			this._bindTable.Rows[8][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId9;
			this._bindTable.Rows[9][MY_SCREEN_ID]  = slipPrtSet.EachSlipTypeColId10;

			//�`�[�^�C�v�ʗ񖼏�
			this._bindTable.Rows[0][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm1;
			this._bindTable.Rows[1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm2;
			this._bindTable.Rows[2][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm3;
			this._bindTable.Rows[3][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm4;
			this._bindTable.Rows[4][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm5;
			this._bindTable.Rows[5][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm6;
			this._bindTable.Rows[6][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm7;
			this._bindTable.Rows[7][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm8;
			this._bindTable.Rows[8][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm9;
			this._bindTable.Rows[9][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]	= slipPrtSet.EachSlipTypeColNm10;

			this._bindTable.Rows[0][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt1;
			this._bindTable.Rows[1][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt2;
			this._bindTable.Rows[2][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt3;
			this._bindTable.Rows[3][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt4;
			this._bindTable.Rows[4][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt5;
			this._bindTable.Rows[5][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt6;
			this._bindTable.Rows[6][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt7;
			this._bindTable.Rows[7][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt8;
			this._bindTable.Rows[8][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt9;
			this._bindTable.Rows[9][MY_SCREEN_PRINTDIV_TITLE]           = slipPrtSet.EachSlipTypeColPrt10;

            // 2008.12.11 30413 ���� �W�����i�p�̃��X�g >>>>>>START
            for (int i = 0; i < MAX_ROW_COUNT; i++)
            {
                if ((string)this._bindTable.Rows[i][MY_SCREEN_ID] == MY_SCREEN_LIST_PRICE)
                {
                    this.eachSlipTypeCol_ultraGrid.DisplayLayout.Rows[i].Cells[MY_SCREEN_PRINTDIV_TITLE].ValueList = this.eachSlipTypeCol_ultraGrid.DisplayLayout.ValueLists[MY_SCREEN_LIST_PRICE];
                }
                // 2009.01.23 30413 ���� �ʏ�̃��X�g��ݒ肷�鏈����ǉ� >>>>>>START
                else
                {
                    // �W�����i�ȊO�͒ʏ�̃��X�g��ݒ�
                    this.eachSlipTypeCol_ultraGrid.DisplayLayout.Rows[i].Cells[MY_SCREEN_PRINTDIV_TITLE].ValueList = this.eachSlipTypeCol_ultraGrid.DisplayLayout.ValueLists[MY_SCREEN_PRINTDIV_TITLE];
                }
                // 2009.01.23 30413 ���� �ʏ�̃��X�g��ݒ肷�鏈����ǉ� <<<<<<END
            }
            // 2008.12.11 30413 ���� �W�����i�p�̃��X�g <<<<<<END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			// �`�[��F
			colorRed1 = slipPrtSet.SlipBaseColorRed1;
			colorRed2 = slipPrtSet.SlipBaseColorRed2;
			colorRed3 = slipPrtSet.SlipBaseColorRed3;
			colorRed4 = slipPrtSet.SlipBaseColorRed4;
			colorRed5 = slipPrtSet.SlipBaseColorRed5;

			colorGreen1 = slipPrtSet.SlipBaseColorGrn1;
			colorGreen2 = slipPrtSet.SlipBaseColorGrn2;
			colorGreen3 = slipPrtSet.SlipBaseColorGrn3;
			colorGreen4 = slipPrtSet.SlipBaseColorGrn4;
			colorGreen5 = slipPrtSet.SlipBaseColorGrn5;

			colorBlue1 = slipPrtSet.SlipBaseColorBlu1;
			colorBlue2 = slipPrtSet.SlipBaseColorBlu2;
			colorBlue3 = slipPrtSet.SlipBaseColorBlu3;
			colorBlue4 = slipPrtSet.SlipBaseColorBlu4;
			colorBlue5 = slipPrtSet.SlipBaseColorBlu5;

			DispToColor(1, colorRed1, colorGreen1, colorBlue1);
			DispToColor(2, colorRed2, colorGreen2, colorBlue2);
			DispToColor(3, colorRed3, colorGreen3, colorBlue3);
			DispToColor(4, colorRed4, colorGreen4, colorBlue4);
			DispToColor(5, colorRed5, colorGreen5, colorBlue5);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

//----- h.ueno add---------- start 2007.12.17
			//--------------
			// �B�����ڐݒ�
			//--------------
			SpecialPurpose1_tEdit.Text = slipPrtSet.SpecialPurpose1;		// ����p�r1
			SpecialPurpose2_tEdit.Text = slipPrtSet.SpecialPurpose2;		// ����p�r2
			SpecialPurpose3_tEdit.Text = slipPrtSet.SpecialPurpose3;		// ����p�r3
			SpecialPurpose4_tEdit.Text = slipPrtSet.SpecialPurpose4;		// ����p�r4
//----- h.ueno add---------- end   2007.12.17

			//----- h.ueno del---------- start 2007.12.17
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD START
			//BarCodeAcpOdrNoPrtCd_tComboEditor.Value = slipPrtSet.BarCodeAcpOdrNoPrtCd;
			//BarCodeCustCodePrtCd_tComboEditor.Value = slipPrtSet.BarCodeCustCodePrtCd;
			////2006.12.08 deleted by T-Kidate
			////BarCodeCarMngNoPrtCd_tComboEditor.Value = slipPrtSet.BarCodeCarMngNoPrtCd;
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD END
			//----- h.ueno del---------- end   2007.12.17

			//TODO : 2006/03/15 H.NAKAMURA ADD STA

            //2006.12.08 deleted by T-Kidate
            //MainWorkLinePrtDiv_tComboEditor.Value = slipPrtSet.MainWorkLinePrtDivCd;
			
            //TODO : 2006/03/15 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//ContractNoPrtDivCd_tComboEditor.Value = slipPrtSet.ContractNoPrtDivCd;
			////�_��g�ѓd�b�ԍ��󎚋敪
			//ContCpNoPrtDivCd_tComboEditor.Value = slipPrtSet.ContCpNoPrtDivCd;
			//----- h.ueno del---------- end   2007.12.17

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            this.CustomerCode_tNedit.Clear();
            this.CustomerName_uLabel.Text = string.Empty;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ��`�[����ݒ�N���X�i�[����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�`�[����ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2010/08/06 caowj PM.NS1012�Ή�</br>
        /// <br>Update Note : 2011/02/16  ���N�n��</br>
        /// <br>              ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private void ScreenToSlipPrtSet(ref SlipPrtSet slipPrtSet)
		{
			if (slipPrtSet == null)
			{
				// �V�K�̏ꍇ
				slipPrtSet = new SlipPrtSet();
			}

//----- h.ueno add---------- start 2007.12.17
			//--- �V�K���[�h�Ή� ---//
			// �f�[�^���̓V�X�e��
			slipPrtSet.DataInputSystem = DataInputSystem_tNedit.GetInt();
			
			// �`�[������
			slipPrtSet.SlipPrtKind = SlipPrtKind_tNedit.GetInt();

			// ��ƃR�[�h
			slipPrtSet.EnterpriseCode = this._enterpriseCode;
//----- h.ueno add---------- end   2007.12.17
			
			// �`�[�A�o��PGID�A������ڊ֌W
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSet.SlipPrtSetPaperId   = SlipPrtSetPaperId_tEdit.Text;
			slipPrtSet.SlipComment         = SlipComment_tEdit.Text;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			slipPrtSet.OutputFormFileName  = OutputFormFileName_tEdit.Text;
			slipPrtSet.OutputPgId          = OutputPgId_tEdit.Text;              
			slipPrtSet.OutputPgClassId     = OutputPgClassId_tEdit.Text;          
			slipPrtSet.OutConfimationMsg   = OutConMsg_tEdit.Text;
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//			slipPrtSet.OptionCode          = OptionCode_tNedit.GetInt();                        
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
			slipPrtSet.EnterpriseNamePrtCd = (int)EnterpriseNamePrtCd_tComEditor.Value;
			slipPrtSet.PrtPreviewExistCode = (int)PrtPreviewExistCode_tComEditor.Value;
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            ////----- h.ueno upd---------- start 2007.12.17
            //slipPrtSet.SlipFormCd = (int)SlipFormCd_tComEditor.Value;
            ////----- h.ueno upd---------- end   2007.12.17
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//if (PrinterMngNo_tComEditor.SelectedItem != null)
			//{
			//	slipPrtSet.PrinterMngNo      = (int)PrinterMngNo_tComEditor.SelectedItem.DataValue;
			//}
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END            
      
			slipPrtSet.PrtCirculation = PrtCirculation_tNedit.GetInt();          
			slipPrtSet.TopMargin      = TStrConv.StrToDoubleDef(TopMarging_tNedit.DataText, 0.0);           
			slipPrtSet.LeftMargin     = TStrConv.StrToDoubleDef(LeftMarging_tNedit.DataText, 0.0); 

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			slipPrtSet.RightMargin       = TStrConv.StrToDoubleDef(RightMargin_tNedit.DataText, 0.0);           
			slipPrtSet.BottomMargin      = TStrConv.StrToDoubleDef(BottomMargin_tNedit.DataText, 0.0);
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� >>>>>>START
            //slipPrtSet.CustTelNoPrtDivCd = (int)CustTelNoPrtDivCd_tComEditor.Value;
            // 2008.06.05 30413 ���� ���Ӑ�d�b�ԍ��󎚍폜�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

            // 2008.06.05 30413 ���� �ǉ����ڂ̒l���i�[ >>>>>>START
            slipPrtSet.ReissueMark = ReissueMark_tEdit.Text.TrimEnd();                  // �Ĕ��s�}�[�N

            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� >>>>>>START
            slipPrtSet.ConsTaxPrtCd = (int)ConsTaxPrtCd_tComboEditor.Value;             // ����ň�
            // 2008.12.11 30413 ���� �ǉ����ڂ̐��� <<<<<<END

            slipPrtSet.RefConsTaxDivCd = (int)RefConsTaxDivCd_tComboEditor.Value;       // �Q�l����ŋ敪
            slipPrtSet.RefConsTaxPrtNm = RefConsTaxPrtNm_tEdit.Text;                    // �Q�l����ň󎚖���
            slipPrtSet.Note1 = Note1_tEdit.Text.TrimEnd();                              // ���l�P
            slipPrtSet.Note2 = Note2_tEdit.Text.TrimEnd();                              // ���l�Q
            slipPrtSet.Note3 = Note3_tEdit.Text.TrimEnd();                              // ���l�R
            slipPrtSet.QRCodePrintDivCd = (int)QRCodePrintDivCd_tComboEditor.Value;     // QR�R�[�h�󎚋敪
            slipPrtSet.TimePrintDivCd = (int)TimePrintDivCd_tComboEditor.Value;         // �����󎚋敪
            // 2008.06.05 30413 ���� �ǉ����ڂ̒l���i�[ <<<<<<END

            slipPrtSet.EntNmPrtExpDiv = (int)this.EntNmPrtExpDiv_tComEditor.Value; // ADD 2011/02/16

            // --- ADD 2011/07/19 ---------->>>>>
            slipPrtSet.SCMAnsMarkPrtDiv = (int)SCMAnsMarkPrtDiv_tComboEditor.Value;     // �񓚃}�[�N�󎚋敪
            slipPrtSet.NormalPrtMark = NormalPrtMark_tEdit.Text.TrimEnd();              // �ʏ�}�[�N
            slipPrtSet.SCMManualAnsMark = SCMManualAnsMark_tEdit.Text.TrimEnd();        // �蓮�񓚃}�[�N
            slipPrtSet.SCMAutoAnsMark = SCMAutoAnsMark_tEdit.Text.TrimEnd();            // �����񓚃}�[�N
            // --- ADD 2011/07/19 ----------<<<<<

            // 2008.08.28 30413 ���� �ǉ����ڂ̒l���i�[ >>>>>>START
            slipPrtSet.DetailRowCount = DetailRowCount_tNedit.GetInt();                 // ���׍s��
            slipPrtSet.HonorificTitle = HonorificTitle_tEdit.Text.TrimEnd();            // �h��
            // 2008.08.28 30413 ���� �ǉ����ڂ̒l���i�[ <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSet.SlipNoteCharCnt = SlipNoteCharCnt_tNedit.GetInt();               // �`�[���l����
            slipPrtSet.SlipNote2CharCnt = SlipNote2CharCnt_tNedit.GetInt();             // �`�[���l�Q����
            slipPrtSet.SlipNote3CharCnt = SlipNote3CharCnt_tNedit.GetInt();             // �`�[���l�R����
            // --- ADD 2009/12/31 ----------<<<<<

			// �`�[�t�H���g�֌W
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //slipPrtSet.SlipFontName = SlipFontName_uFontNameEditor.Text;
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            slipPrtSet.SlipFontSize = (int)SlipFontSize_tComEditor.Value;
            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            //slipPrtSet.SlipFontStyle = (int)SlipFontStyle_tComEditor.Value;
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			// ���ʖ���
			slipPrtSet.CopyCount     = (int)CopyCount_tComboEditor.Value;
			//TODO : 2006/03/15 H.NAKAMURA ADD STA 

			//----- h.ueno upd---------- start 2007.12.17
			//--- NULL�����Ή��iNULL��""�ɂ���j
			// �`�[�^�C�g���֌W
			slipPrtSet.TitleName1    = SlipPrtSetAcs.NullChgStr(TitleName1_tEdit.Text);
			slipPrtSet.TitleName102  = SlipPrtSetAcs.NullChgStr(TitleName102_tEdit.Text);
			slipPrtSet.TitleName103  = SlipPrtSetAcs.NullChgStr(TitleName103_tEdit.Text);
			slipPrtSet.TitleName104  = SlipPrtSetAcs.NullChgStr(TitleName104_tEdit.Text);
			slipPrtSet.TitleName105  = SlipPrtSetAcs.NullChgStr(TitleName105_tEdit.Text);
			slipPrtSet.TitleName2    = SlipPrtSetAcs.NullChgStr(TitleName2_tEdit.Text);
			slipPrtSet.TitleName202  = SlipPrtSetAcs.NullChgStr(TitleName202_tEdit.Text);
			slipPrtSet.TitleName203  = SlipPrtSetAcs.NullChgStr(TitleName203_tEdit.Text);
			slipPrtSet.TitleName204  = SlipPrtSetAcs.NullChgStr(TitleName204_tEdit.Text);
			slipPrtSet.TitleName205  = SlipPrtSetAcs.NullChgStr(TitleName205_tEdit.Text);
			slipPrtSet.TitleName3    = SlipPrtSetAcs.NullChgStr(TitleName3_tEdit.Text);
			slipPrtSet.TitleName302  = SlipPrtSetAcs.NullChgStr(TitleName302_tEdit.Text);
			slipPrtSet.TitleName303  = SlipPrtSetAcs.NullChgStr(TitleName303_tEdit.Text);
			slipPrtSet.TitleName304  = SlipPrtSetAcs.NullChgStr(TitleName304_tEdit.Text);
			slipPrtSet.TitleName305  = SlipPrtSetAcs.NullChgStr(TitleName305_tEdit.Text);
			slipPrtSet.TitleName4    = SlipPrtSetAcs.NullChgStr(TitleName4_tEdit.Text);
			slipPrtSet.TitleName402  = SlipPrtSetAcs.NullChgStr(TitleName402_tEdit.Text);
			slipPrtSet.TitleName403  = SlipPrtSetAcs.NullChgStr(TitleName403_tEdit.Text);
			slipPrtSet.TitleName404  = SlipPrtSetAcs.NullChgStr(TitleName404_tEdit.Text);
			slipPrtSet.TitleName405	 = SlipPrtSetAcs.NullChgStr(TitleName405_tEdit.Text);
			//----- h.ueno upd---------- end   2007.12.17
			//TODO : 2006/03/15 H.NAKAMURA ADD STA 

			//----- h.ueno upd---------- start 2007.12.17
			//--- ��ʂ̉B�����ڂ���擾����悤�ύX
			// ����p�r
			slipPrtSet.SpecialPurpose1 = SlipPrtSetAcs.NullChgStr(SpecialPurpose1_tEdit.Text);
			slipPrtSet.SpecialPurpose2 = SlipPrtSetAcs.NullChgStr(SpecialPurpose2_tEdit.Text);
			slipPrtSet.SpecialPurpose3 = SlipPrtSetAcs.NullChgStr(SpecialPurpose3_tEdit.Text);
			slipPrtSet.SpecialPurpose4 = SlipPrtSetAcs.NullChgStr(SpecialPurpose4_tEdit.Text);
			//----- h.ueno upd---------- end   2007.12.17

// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			//----- h.ueno upd---------- start 2007.12.17
			//--- NULL�����Ή��iNULL��""�ɂ���j
			// �`�[�^�C�v�ʗ�֌W
			slipPrtSet.EachSlipTypeColId1  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[0][MY_SCREEN_ID]).TrimEnd();
			slipPrtSet.EachSlipTypeColId2  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[1][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId3  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[2][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId4  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[3][MY_SCREEN_ID]).TrimEnd();
			slipPrtSet.EachSlipTypeColId5  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[4][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId6  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[5][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId7  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[6][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId8  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[7][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId9  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[8][MY_SCREEN_ID]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColId10 = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[9][MY_SCREEN_ID]).TrimEnd();

			slipPrtSet.EachSlipTypeColNm1  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[0][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm2  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm3  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[2][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd();
			slipPrtSet.EachSlipTypeColNm4  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[3][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd();
			slipPrtSet.EachSlipTypeColNm5  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[4][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd();
			slipPrtSet.EachSlipTypeColNm6  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[5][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm7  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[6][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm8  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[7][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm9  = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[8][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd(); 
			slipPrtSet.EachSlipTypeColNm10 = SlipPrtSetAcs.NullChgStr(this._bindTable.Rows[9][MY_SCREEN_EACH_SLIPTYPECOL_TITLE]).TrimEnd();

			slipPrtSet.EachSlipTypeColPrt1  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[0][MY_SCREEN_PRINTDIV_TITLE]); 
			slipPrtSet.EachSlipTypeColPrt2  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[1][MY_SCREEN_PRINTDIV_TITLE]); 
			slipPrtSet.EachSlipTypeColPrt3  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[2][MY_SCREEN_PRINTDIV_TITLE]);
			slipPrtSet.EachSlipTypeColPrt4  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[3][MY_SCREEN_PRINTDIV_TITLE]);
			slipPrtSet.EachSlipTypeColPrt5  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[4][MY_SCREEN_PRINTDIV_TITLE]);
			slipPrtSet.EachSlipTypeColPrt6  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[5][MY_SCREEN_PRINTDIV_TITLE]); 
			slipPrtSet.EachSlipTypeColPrt7  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[6][MY_SCREEN_PRINTDIV_TITLE]); 
			slipPrtSet.EachSlipTypeColPrt8  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[7][MY_SCREEN_PRINTDIV_TITLE]);
			slipPrtSet.EachSlipTypeColPrt9  = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[8][MY_SCREEN_PRINTDIV_TITLE]); 
			slipPrtSet.EachSlipTypeColPrt10 = SlipPrtSetAcs.NullChgInt(this._bindTable.Rows[9][MY_SCREEN_PRINTDIV_TITLE]);
			//----- h.ueno upd---------- end   2007.12.17
		
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			// �`�[��F
			slipPrtSet.SlipBaseColorRed1 = colorRed1; 
			slipPrtSet.SlipBaseColorRed2 = colorRed2; 
			slipPrtSet.SlipBaseColorRed3 = colorRed3; 
			slipPrtSet.SlipBaseColorRed4 = colorRed4; 
			slipPrtSet.SlipBaseColorRed5 = colorRed5; 

			slipPrtSet.SlipBaseColorGrn1 = colorGreen1; 
			slipPrtSet.SlipBaseColorGrn2 = colorGreen2; 
			slipPrtSet.SlipBaseColorGrn3 = colorGreen3; 
			slipPrtSet.SlipBaseColorGrn4 = colorGreen4; 
			slipPrtSet.SlipBaseColorGrn5 = colorGreen5; 

			slipPrtSet.SlipBaseColorBlu1 = colorBlue1; 
			slipPrtSet.SlipBaseColorBlu2 = colorBlue2; 
			slipPrtSet.SlipBaseColorBlu3 = colorBlue3; 
			slipPrtSet.SlipBaseColorBlu4 = colorBlue4; 
			slipPrtSet.SlipBaseColorBlu5 = colorBlue5;

			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

			//----- h.ueno del---------- start 2007.12.17
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD START
			//slipPrtSet.BarCodeAcpOdrNoPrtCd = (int)BarCodeAcpOdrNoPrtCd_tComboEditor.Value;
			//slipPrtSet.BarCodeCustCodePrtCd = (int)BarCodeCustCodePrtCd_tComboEditor.Value;
			////2006.12.08 deleted by T-Kidate
			////slipPrtSet.BarCodeCarMngNoPrtCd = (int)BarCodeCarMngNoPrtCd_tComboEditor.Value;
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.30 UENO ADD END
			//----- h.ueno del---------- end   2007.12.17

			//TODO : 2006/03/15 H.NAKAMURA ADD STA
            //2006.12.08 deleted by T-Kidate
            //slipPrtSet.MainWorkLinePrtDivCd = (int)MainWorkLinePrtDiv_tComboEditor.Value;
			//TODO : 2006/03/15 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//slipPrtSet.ContractNoPrtDivCd = (int)ContractNoPrtDivCd_tComboEditor.Value;
			////�_��g�ѓd�b�ԍ��󎚋敪
			//slipPrtSet.ContCpNoPrtDivCd = (int)ContCpNoPrtDivCd_tComboEditor.Value;
			//----- h.ueno del---------- end   2007.12.17


            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            slipPrtSet.CustomerCode = this.CustomerCode_tNedit.GetInt();
            slipPrtSet.UpdateFlag = this.updateFlag;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	�`�[����ݒ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note			: �`�[����ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
		/// <br>Programmer		: 23006  ���� ���q</br>
		/// <br>Date			: 2005.08.23</br>
        /// <br>Update Note     : 2011/09/06 wangf</br>
        /// <br>                : Redmine#24449 �ۑ��������s���i�N���b�N���AAlt+S���j�A�������`���b�N��񍐂���</br>
		/// </remarks>
		private int CheckDisplay(ref string checkMessage)
		{
			int returnStatus = 0;

			try
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.14 TAKAHASHI DELETE START
//				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START

				//----- h.ueno upd---------- start 2007.12.17
				// �`�[������[ID
				if (this.SlipPrtSetPaperId_tEdit.Text == "")
				{
					checkMessage = "�`�[������[ID����͂��ĉ������B";
					returnStatus = 10;
					return returnStatus;
				}
				// �`�[����R�����g
				if (this.SlipComment_tEdit.Text == "")
				{
                    // 2008.09.24 30413 ���� �`�[������[���̂ɕύX >>>>>>START
                    //checkMessage = "�`�[����R�����g����͂��ĉ������B";
                    checkMessage = "�`�[������[���̂���͂��ĉ������B";
                    // 2008.09.24 30413 ���� �`�[������[���̂ɕύX <<<<<<END
                    returnStatus = 11;
					return returnStatus;
				}
				//----- h.ueno upd---------- end   2007.12.17

				#region �����R�����g
//				// �`�[�R�����g
//				if (this.SlipComment_tEdit.Text == "")
//				{
//					checkMessage = "�`�[�R�����g����͂��ĉ������B";
//					returnStatus = 20;
//					return returnStatus;
//				}
//				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END
//
//				// �o�̓v���O����ID
//				if (this.OutputPgId_tEdit.Text == "")
//				{
//					checkMessage = "�o�̓v���O����ID����͂��ĉ������B";
//					returnStatus = 30;
//					return returnStatus;
//				}
//				// �o�̓v���O�����N���XID
//				if (this.OutputPgClassId_tEdit.Text == "")
//				{
//					checkMessage = "�o�̓v���O�����N���XID����͂��ĉ������B";
//					returnStatus = 40;
//					return returnStatus;
//				}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.14 TAKAHASHI DELETE END

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.11 TAKAHASHI DELETE START
                //// �v�����^��
                //if (this.PrinterMngNo_tComEditor.Value == null)
                //{
                //    checkMessage = "�v�����^����I�����ĉ������B";
                //    returnStatus = 50;
                //    return returnStatus;
                //}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.11 TAKAHASHI DELETE END
				#endregion �����R�����g

				// �������
				if ((this.PrtCirculation_tNedit.GetInt() == 0) ||
					(this.PrtCirculation_tNedit.Text == ""))
				{
					checkMessage = "�����������͂��ĉ������B";
					returnStatus = 60;
					return returnStatus;
				}

                // --- ADD 2009/01/30 -------------------------------->>>>>
                // ���׍s��
                if ((this.DetailRowCount_tNedit.GetInt() == 0) ||
                    (this.DetailRowCount_tNedit.Text == ""))
                {
                    checkMessage = "���׍s������͂��ĉ������B";
                    returnStatus = 70;
                    return returnStatus;
                }
                // --- ADD 2009/01/30 --------------------------------<<<<<

                // 2007.04.02  S.Koga  add ------------------------------------
                double rate1 = 0;
                if (!TopMarging_tNedit.Text.Equals(""))
                {
                    rate1 = double.Parse(this.TopMarging_tNedit.Text);
                    if (rate1 > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "��]���̒l���s���ł��B",
                            -1,
                            MessageBoxButtons.OK);
                        TopMarging_tNedit.Focus();
                        TopMarging_tNedit.SelectAll();
                        return -1;
                    }
                }

                double rate2 = 0;
                if (!LeftMarging_tNedit.Text.Equals(""))
                {
                    rate2 = double.Parse(this.LeftMarging_tNedit.Text);
                    if (rate2 > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���]���̒l���s���ł��B",
                            -1,
                            MessageBoxButtons.OK);
                        LeftMarging_tNedit.Focus();
                        LeftMarging_tNedit.SelectAll();
                        return -1;
                    }
                }

                double rate3 = 0;
                if (!RightMargin_tNedit.Text.Equals(""))
                {
                    rate3 = double.Parse(this.RightMargin_tNedit.Text);
                    if (rate3 > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�E�]���̒l���s���ł��B",
                            -1,
                            MessageBoxButtons.OK);
                        RightMargin_tNedit.Focus();
                        RightMargin_tNedit.SelectAll();
                        return -1;
                    }
                }

                double rate4 = 0;
                if (!BottomMargin_tNedit.Text.Equals(""))
                {
                    rate4 = double.Parse(this.BottomMargin_tNedit.Text);
                    if (rate4 > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���]���̒l���s���ł��B",
                            -1,
                            MessageBoxButtons.OK);
                        BottomMargin_tNedit.Focus();
                        BottomMargin_tNedit.SelectAll();
                        return -1;
                    }
                }
                // ------------------------------------------------------------
                // -- add wangf 2011/09/06 ---------->>>>>
                // �`�[���l����
                int slipNoteMax = 0;
                if (SlipPrtKind_tNedit.GetInt() == 150)
                {
                    slipNoteMax = 40;
                }
                else
                {
                    slipNoteMax = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote");
                }
                if (this.SlipNoteCharCnt_tNedit.GetInt() > slipNoteMax)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���͔͈͊O�ł��B",
                        -1,
                        MessageBoxButtons.OK);
                    this.SlipNoteCharCnt_tNedit.Focus();
                    return -1;
                }
                // �`�[���l�Q����
                int slipNote2Max = 0;
                if (SlipPrtKind_tNedit.GetInt() == 150)
                {
                    slipNote2Max = 40;
                }
                else
                {
                    slipNote2Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote2");
                }
                if (this.SlipNote2CharCnt_tNedit.GetInt() > slipNote2Max)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���͔͈͊O�ł��B",
                        -1,
                        MessageBoxButtons.OK);
                    this.SlipNote2CharCnt_tNedit.Focus();
                    return -1;
                }
                // �`�[���l�R����
                int slipNote3Max = 0;
                if (SlipPrtKind_tNedit.GetInt() == 150)
                {
                    slipNote3Max = 40;
                }
                else
                {
                    slipNote3Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote3");
                }
                if (this.SlipNote3CharCnt_tNedit.GetInt() > slipNote3Max)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���͔͈͊O�ł��B",
                        -1,
                        MessageBoxButtons.OK);
                    this.SlipNote3CharCnt_tNedit.Focus();
                    return -1;
                }
                // -- add wangf 2011/09/06 ----------<<<<<

			}
			finally
			{
				if( returnStatus != 0 )
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						checkMessage,	                        // �\�����郁�b�Z�[�W
						0,   									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
					
					switch(returnStatus)
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.14 TAKAHASHI DELETE START
//						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START

						//----- h.ueno upd---------- start 2007.12.17
						case 10:
							this.SlipPrtSetPaperId_tEdit.Focus();
							break;
						case 11:
							this.SlipComment_tEdit.Focus();
							break;
						//----- h.ueno upd---------- end   2007.12.17

//						case 20:
//							this.SlipComment_tEdit.Focus();
//							break;
//						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END
//
//						case 30:
//							this.OutputPgId_tEdit.Focus();
//							break;
//
//						case 40:
//							this.OutputPgClassId_tEdit.Focus();
//							break;
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.14 TAKAHASHI DELETE END

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.11 TAKAHASHI DELETE START
//						case 50:
//							this.PrinterMngNo_tComEditor.Focus();
//							break;
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.11 TAKAHASHI DELETE END

						case 60:
							this.PrtCirculation_tNedit.Focus();
							break;

                        // --- ADD 2009/01/30 -------------------------------->>>>>
                        case 70:
                            this.DetailRowCount_tNedit.Focus();
                            break;
                        // --- ADD 2009/01/30 --------------------------------<<<<<
					}
				}
			}			
			return returnStatus;
		}

		//----- h.ueno del---------- start 2007.12.17
		// �Œ薼�̂�E�N���X�ɂ�SortedList�Œ�`���A�擾����̂ŕs�v
		///// <summary>
		///// ����p�����̎擾����
		///// </summary>
		///// <returns>����p������</returns>
		///// <remarks>
		///// <br>Note       :  ����p�����̂̎擾���s���܂��B</br>
		///// <br>Programmer	: 23010 �@�����@�m</br>
		///// <br>Date		: 2006.03.16</br>
		///// </remarks>
		//private string GetSlipFormNm(int SlipFormCd)
		//{
		//    string slipFormNm = "";
		//    switch(SlipFormCd)
		//    {
		//        case 0:
		//        slipFormNm = "����";
		//        break;

		//        case 1:
		//        slipFormNm = "��p�`�[";
		//        break;

		//        case 2:
		//        slipFormNm = "�A��";
		//        break;

		//        default:
		//        break;
		//    }
		//    return slipFormNm;
		//}
		//----- h.ueno del---------- end   2007.12.17

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �r������
		/// </summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
					ASSEMBLY_ID,							// �A�Z���u��ID
					"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
					status,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///�@�ۑ�����(SaveCSlipPrtSet())
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2010/08/06 caowj PM.NS1012�Ή�</br>
        /// </remarks>
		private bool SaveCSlipPrtSet()
		{
			bool result = false;

			//��ʃf�[�^���̓`�F�b�N����
			string checkMessage = "";
			int chkSt = CheckDisplay(ref checkMessage);
			if( chkSt != 0 )
			{
				return result;
			}
			
			SlipPrtSet slipPrtSet = null;
			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY];
				slipPrtSet = ((SlipPrtSet)this._slipPrtSetTable[guid]).Clone();
			}

			ScreenToSlipPrtSet(ref slipPrtSet);

			//----- h.ueno add---------- start 2007.12.17
			//--------------
			// �V�K���[�h��
			//--------------
			if (Mode_Label.Text == INSERT_MODE)
			{
				// ���L���ڏ�����
				// �쐬���t
				slipPrtSet.CreateDateTime = DateTime.MinValue;
				
				// �X�V���t
				slipPrtSet.UpdateDateTime = DateTime.MinValue;
				
				// GUID
				slipPrtSet.FileHeaderGuid = Guid.Empty;

                // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
                slipPrtSetWork.EnterpriseCode = this._enterpriseCode;
                slipPrtSetWork.DataInputSystem = this.DataInputSystem_tNedit.GetInt();
                slipPrtSetWork.SlipPrtKind = this.SlipPrtKind_tNedit.GetInt();
                slipPrtSetWork.SlipPrtSetPaperId = this.SlipPrtSetPaperId_tEdit.Text;

                int flag = this._slipPrtSetAcs.SearchSlipPrtSet(slipPrtSetWork);
                if (flag == 0)
                {
                    // �R�[�h�d��
                    TMsgDisp.Show(
                        this,                                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,             // �G���[���x��
                        ASSEMBLY_ID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",    // �\�����郁�b�Z�[�W
                        0,                                       // �X�e�[�^�X�l
                        MessageBoxButtons.OK);                  // �\������{�^��
                    return result;
                }
                // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
			}
			//----- h.ueno add---------- end   2007.12.17

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            if (this.CustomerCode_tNedit.GetInt() != 0)
            {
                DialogResult res = TMsgDisp.Show(
                        this, 								                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,                        // �G���[���x��
                        ASSEMBLY_ID,						                    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�`�[�ݒ�}�X�^�֕ύX���e���X�V���܂����H", 		    // �\�����郁�b�Z�[�W
                        0, 									                    // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2);	                    // �\������{�^��

                if (res != DialogResult.Yes)
                {
                    this.updateFlag = 0;
                }
                else
                {
                    this.updateFlag = 1;
                }

                if (this.updateFlag == 1)
                {
                    CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
                    custSlipMngWork.DataInputSystem = this.DataInputSystem_tNedit.GetInt();
                    custSlipMngWork.EnterpriseCode = this._enterpriseCode;
                    custSlipMngWork.SectionCode = "0";
                    custSlipMngWork.CustomerCode = this.CustomerCode_tNedit.GetInt();
                    custSlipMngWork.SlipPrtKind = this.SlipPrtKind_tNedit.GetInt();

                    int flagCustSlipMngWork = this._slipPrtSetAcs.SearchCustSlipMng(ref custSlipMngWork);
                    if (flagCustSlipMngWork == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (custSlipMngWork.LogicalDeleteCode == 1)
                        {
                            this._slipPrtSetAcs.DeleteCustSlipMng(custSlipMngWork);
                        }
                    }
                }

                if (null != slipPrtSet)
                {
                    slipPrtSet.UpdateFlag = this.updateFlag;
                }

            }
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
			int status = this._slipPrtSetAcs.WriteSlipPrtSet(ref slipPrtSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				//----- h.ueno add---------- start 2007.12.17
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// �R�[�h�d��
					TMsgDisp.Show(
						this,                                    // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,             // �G���[���x��
						ASSEMBLY_ID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
						"���̃R�[�h�͊��Ɏg�p����Ă��܂��B",    // �\�����郁�b�Z�[�W
						0,                                       // �X�e�[�^�X�l
						MessageBoxButtons.OK);                  // �\������{�^��
					return result;
				}
				//----- h.ueno add---------- end   2007.12.17
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
                case -1:
                    // �R�[�h�d��
                    TMsgDisp.Show(
                        this,                                        // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,                 // �G���[���x��
                        ASSEMBLY_ID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���Ӑ���X�V���邱�Ƃ��o���܂���B" + "\r\n" +
                        "���̓��Ӑ�͊��ɑ��[���ɂč폜����Ă��܂��B",    // �\�����郁�b�Z�[�W
                        0,                                             // �X�e�[�^�X�l
                        MessageBoxButtons.OK);                          // �\������{�^��
                    this.CustomerCode_tNedit.Focus();
                    return false;

				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						this.Text,		                        // �v���O��������
						"SaveCSlipPrtSet",                       // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._slipPrtSetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
			}
			
			// DataSet�X�V����
			SlipPrtSetToDataSet(slipPrtSet, this.DataIndex);
            
            // �t���[���X�V
			int dummy = 0;
			Search(ref dummy, 0);
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            this.customerCode = 0;
            this.customerName = string.Empty;
            this.updateFlag = 0;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

			result = true;
			return result;
		}

//----- h.ueno add---------- start 2007.12.17

		/// <summary>
		/// �_���폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private int LogicalDeleteSlipPrtSet()
		{
			int status = 0;
			int dummy = 0;

			// �폜�Ώێ擾
			SlipPrtSet slipPrtSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY];
				slipPrtSet = ((SlipPrtSet)this._slipPrtSetTable[guid]).Clone();

                // 2008.09.24 30413 ���� �e�`�[�����ʂ�1���̏ꍇ�A�폜�s�� >>>>>>START
                // �f�[�^�Z�b�g���R�s�[���邱�ƂŃt�H�[�J�X�s�������
                DataSet cpDataSet = this.Bind_DataSet.Copy();
                cpDataSet.Tables[VIEW_TABLE].DefaultView.RowFilter = VIEW_SLIP_PRT_KIND_CODE + " = '" + slipPrtSet.SlipPrtKind + "'"
                                                                           + " AND " + VIEW_DELETE_DATE + " = ''";
                int rowCnt = cpDataSet.Tables[VIEW_TABLE].DefaultView.Count;
                if (rowCnt <= 1)
                {
                    status = -2;
                    TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ASSEMBLY_ID,
                        "���̃��R�[�h�͍폜�ł��܂���B",
                        status,
                        MessageBoxButtons.OK);
                    return status;
                }
                // 2008.09.24 30413 ���� �e�`�[�����ʂ�1���̏ꍇ�A�폜�s�� <<<<<<END
            }

			// �_���폜
			status = this._slipPrtSetAcs.LogicalDelete(ref slipPrtSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);
						break;
					}
				default:
					{
						TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u��ID
							this.Text,							// �v���O��������
							"LogicalDeleteSlipPrtSet",			// ��������
							TMsgDisp.OPE_HIDE,					// �I�y���[�V����
							"�폜�Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W
							status,								// �X�e�[�^�X�l
							this._slipPrtSetAcs,				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						break;
					}
			}
			// �t���[���X�V
			Search(ref dummy, 0);

			return status;
		}

		/// <summary>
		/// �����폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private int PhysicalDeleteSlipPrtSet()
		{
			int status = 0;
			int dummy = 0;

			// �폜�Ώێ擾
			SlipPrtSet slipPrtSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY];
				slipPrtSet = ((SlipPrtSet)this._slipPrtSetTable[guid]).Clone();
			}

			// �����폜
			status = this._slipPrtSetAcs.Delete(slipPrtSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �f�[�^�Z�b�g����s�폜���܂�
						this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex].Delete();
						Search(ref dummy, 0);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);

						// UI�q��ʋ����I������
						EnforcedEndTransaction();

						return status;
					}
				default:
					{
						TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u��ID
							this.Text,							// �v���O��������
							"Delete_Button_Click",				// ��������
							TMsgDisp.OPE_DELETE,				// �I�y���[�V����
							"�폜�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
							status,								// �X�e�[�^�X�l
							this._slipPrtSetAcs,				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						// UI�q��ʋ����I������
						EnforcedEndTransaction();

						return status;
					}
			}
			return status;
		}	
		
		/// <summary>
		/// ��������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�Ώۃ��R�[�h�𕜊����܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private int ReviveSlipPrtSet()
		{
			int status = 0;

			// �폜�Ώێ擾
			SlipPrtSet slipPrtSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY];
				slipPrtSet = ((SlipPrtSet)this._slipPrtSetTable[guid]).Clone();
			}

			// ����
			status = this._slipPrtSetAcs.Revival(ref slipPrtSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet�W�J����
						SlipPrtSetToDataSet(slipPrtSet, this._dataIndex);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);
						return status;
					}
				default:
					{
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							// �v���O��������
							"ReviveStockProcMoney",			    // ��������
							TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
							"�����Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							this._slipPrtSetAcs,				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��
						return status;
					}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			return status;
		}
		
//----- h.ueno add---------- end   2007.12.17

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///�@�F�\��
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �F��uLabel�ɕ\�������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.09.16</br>
		/// </remarks>
		private void DispToColor(int colorNo,int red, int green, int blue)
		{
			Color backColor = new Color();

			backColor = Color.FromArgb(red, green, blue);

			switch (colorNo)
			{
				case 1:
					SlipBaseColor1_uLabel.BackColor = backColor;
					break;

				case 2:
					SlipBaseColor2_uLabel.BackColor = backColor;
					break;

				case 3:
					SlipBaseColor3_uLabel.BackColor = backColor;
					break;

				case 4:
					SlipBaseColor4_uLabel.BackColor = backColor;
					break;

				case 5:
					SlipBaseColor5_uLabel.BackColor = backColor;
					break;

				case 6:
                    // 2008.12.11 30413 ���� �폜���� >>>>>>START
                    //SlipFontName_uFontNameEditor.BackColor = backColor;
                    // 2008.12.11 30413 ���� �폜���� <<<<<<END
                    break;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///�@�f�t�H���g�F�\��
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �f�t�H���g�F��ColorDialog�ɃZ�b�g���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.09.16</br>
		/// </remarks>
		private void SetToColor(int red, int green, int blue)
		{
			Color setColor = new Color();

			setColor = Color.FromArgb(red, green, blue);

			ColorDialogForm.Color = setColor;
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
		#endregion

		# region -- Control Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form.Load �C�x���g(SFURI09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void SFURI09020UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;    // �����{�^��
            this.Delete_Button.ImageList = imageList24;    // ���S�폜�{�^��

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;    // �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;     // ���S�폜�{�^��

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.ImageColorGuide1_uButton.ImageList = imageList16;
			this.ImageColorGuide2_uButton.ImageList = imageList16;
			this.ImageColorGuide3_uButton.ImageList = imageList16;
			this.ImageColorGuide4_uButton.ImageList = imageList16;
			this.ImageColorGuide5_uButton.ImageList = imageList16;

			this.ImageColorGuide1_uButton.Appearance.Image = Size16_Index.STAR1;
			this.ImageColorGuide2_uButton.Appearance.Image = Size16_Index.STAR1;
			this.ImageColorGuide3_uButton.Appearance.Image = Size16_Index.STAR1;
			this.ImageColorGuide4_uButton.Appearance.Image = Size16_Index.STAR1;
			this.ImageColorGuide5_uButton.Appearance.Image = Size16_Index.STAR1;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
			
			this.UpButton.Appearance.Image = IconResourceManagement.ImageList24.Images[ (int)Size24_Index.LATERARROW ];
			this.DownButton.Appearance.Image = IconResourceManagement.ImageList24.Images[ (int)Size24_Index.BUTTOMARROW ];
//		    this.ultraButton3.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.EDITING ];
			// ��ʏ����ݒ菈��
			ScreenInitialSetting();

            // --- DEL m.suzuki 2011/09/27 ---------->>>>>
            //// --- ADD 2009/12/23 ---------->>>>>
            //MAHNB01010UA mahnb01010UA = new MAHNB01010UA();
            //this.uiSetControl1.OwnerForm = mahnb01010UA;
            //// --- ADD 2009/12/23 ----------<<<<<
            // --- DEL m.suzuki 2011/09/27 ----------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form.Closing �C�x���g(SFURI09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
        /// <br>Update Note : 2010/08/06 caowj PM.NS1012�Ή�</br>
		/// </remarks>
		private void SFCMN09120UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// �ŏ�������t���O�̏�����
			this._indexBuf = -2;

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            this.customerCode = 0;
            this.customerName = string.Empty;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFURI09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void SFCMN09120UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// �A�N�e�B�u�������s�̃Z���̊O�ς�����

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}
			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}											  
			timer.Enabled = true;
			ScreenClear();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control����A�N�e�B�u�ɂȂ����ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.09.02</br>
		/// </remarks>
		private void tNedit_Leave(object sender, System.EventArgs e)
		{
			// ��]��
			if (((TNedit)sender).Name == "TopMarging_tNedit")
			{
				if (TopMarging_tNedit.DataText == "")
				{
					TopMarging_tNedit.DataText = "0.0";
				}
			}

			// ���]��
			if (((TNedit)sender).Name == "LeftMarging_tNedit")
			{
				if (LeftMarging_tNedit.DataText == "")
				{
					LeftMarging_tNedit.DataText = "0.0";
				}
			}

			// �E�]��
			if (((TNedit)sender).Name == "RightMargin_tNedit")
			{
				if (RightMargin_tNedit.DataText == "")
				{
					RightMargin_tNedit.DataText = "0.0";
				}
			}

			// ���]��
			if (((TNedit)sender).Name == "BottomMargin_tNedit")
			{
				if (BottomMargin_tNedit.DataText == "")
				{
					BottomMargin_tNedit.DataText = "0.0";
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (!SaveCSlipPrtSet())
			{
				return;
			}
		}

//----- h.ueno add---------- start 2007.12.17

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 30167  ���@�O�M</br>
		/// <br>Date		: 2007.12.17</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, EventArgs e)
		{
			DialogResult result = TMsgDisp.Show(this,		// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION,			// �G���[���x��
				ASSEMBLY_ID,								// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B\r\n��낵���ł����H",	// �\�����郁�b�Z�[�W
				0,											// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,					// �\������{�^��
				MessageBoxDefaultButton.Button2);			// �����\���{�^��

			if (result == DialogResult.OK)
			{
				// �����폜
				PhysicalDeleteSlipPrtSet();
			}
			else
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, EventArgs e)
		{
			// ����
			ReviveSlipPrtSet();
		}

		/// <summary>
		/// UI�q��ʋ����I������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void EnforcedEndTransaction()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

//----- h.ueno add---------- end   2007.12.17

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// ��ʂ̃f�[�^���擾����
			SlipPrtSet compareSlipPrtSet = new SlipPrtSet();

			compareSlipPrtSet = this._slipPrtSetClone.Clone();

			ScreenToSlipPrtSet( ref compareSlipPrtSet );

			//----- h.ueno upd---------- start 2007.12.17
			bool compareFlag = true;	// true:�ύX����, false:�ύX�L��
			
			// �V�K�̏ꍇ
			if(Mode_Label.Text == INSERT_MODE)
			{
				// �K���m�F���b�Z�[�W��\������
				compareFlag = false;
			}
			else
			{
				compareFlag = this._slipPrtSetClone.Equals(compareSlipPrtSet);
			}
			//----- h.ueno upd---------- end   2007.12.17
			
			// ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
			//if ( (!(this._slipPrtSetClone.Equals(compareSlipPrtSet))))
			if(compareFlag == false)
			{
				// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
					"SFURI09020U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
					null, 					                              // �\�����郁�b�Z�[�W
					0, 					                                  // �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				switch(res)
				{
					case DialogResult.Yes:
					{
						if (!SaveCSlipPrtSet())
						{
							return;
						}
						return;
					}

					case DialogResult.No:
					{
                        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                        this.customerCode = 0;
                        this.customerName = string.Empty;
                        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

						break;
					}

					default:
					{
						this.Cancel_Button.Focus();
						return;
					}
				}
			}
			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(ImageColorGuide�{�^���~5)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  :�J���[�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.16</br>
		/// </remarks>
		private void ImageColorGuide_Click(object sender, System.EventArgs e)
		{
			switch(((UltraButton)sender).Name)
			{
				// �`�[��F�P
				case "ImageColorGuide1_uButton":
					// �F���Z�b�g
					SetToColor(colorRed1, colorGreen1, colorBlue1);
					// �F��I������p�l����\��
					DialogResult result1 = this.ColorDialogForm.ShowDialog();
					// �F�I���p�l����OK�{�^���������ꂽ�ꍇ
					if(result1 == DialogResult.OK)
					{
						colorRed1   = Convert.ToInt32(ColorDialogForm.Color.R);
						colorGreen1 = Convert.ToInt32(ColorDialogForm.Color.G);
						colorBlue1  = Convert.ToInt32(ColorDialogForm.Color.B);
						DispToColor(1, colorRed1, colorGreen1, colorBlue1);
						this.TitleName2_tEdit.Focus();
					}
					else
					{
						this.ImageColorGuide1_uButton.Focus();
					}
					break;

				// �`�[��F�Q
				case "ImageColorGuide2_uButton":
					// �F���Z�b�g
					SetToColor(colorRed2, colorGreen2, colorBlue2);
					// �F��I������p�l����\��
					DialogResult result2 = this.ColorDialogForm.ShowDialog();
					// �F�I���p�l����OK�{�^���������ꂽ�ꍇ
					if(result2 == DialogResult.OK)
					{
						colorRed2   = Convert.ToInt32(ColorDialogForm.Color.R);
						colorGreen2 = Convert.ToInt32(ColorDialogForm.Color.G);
						colorBlue2  = Convert.ToInt32(ColorDialogForm.Color.B);
						DispToColor(2, colorRed2, colorGreen2, colorBlue2);
						this.TitleName3_tEdit.Focus();
					}
					else
					{
						this.ImageColorGuide2_uButton.Focus();
					}
					break;

				// �`�[��F�R
				case "ImageColorGuide3_uButton":
					// �F���Z�b�g
					SetToColor(colorRed3, colorGreen3, colorBlue3);
					// �F��I������p�l����\��
					DialogResult result3 = this.ColorDialogForm.ShowDialog();
					// �F�I���p�l����OK�{�^���������ꂽ�ꍇ
					if(result3 == DialogResult.OK)
					{
						colorRed3   = Convert.ToInt32(ColorDialogForm.Color.R);
						colorGreen3 = Convert.ToInt32(ColorDialogForm.Color.G);
						colorBlue3  = Convert.ToInt32(ColorDialogForm.Color.B);
						DispToColor(3, colorRed3, colorGreen3, colorBlue3);
						this.TitleName4_tEdit.Focus();
					}
					else
					{
						this.ImageColorGuide3_uButton.Focus();
					}
					break;

				// �`�[��F�S
				case "ImageColorGuide4_uButton":
					// �F���Z�b�g
					SetToColor(colorRed4, colorGreen4, colorBlue4);
					// �F��I������p�l����\��
					DialogResult result4 = this.ColorDialogForm.ShowDialog();
					// �F�I���p�l����OK�{�^���������ꂽ�ꍇ
					if(result4 == DialogResult.OK)
					{
						colorRed4   = Convert.ToInt32(ColorDialogForm.Color.R);
						colorGreen4 = Convert.ToInt32(ColorDialogForm.Color.G);
						colorBlue4  = Convert.ToInt32(ColorDialogForm.Color.B);
						DispToColor(4, colorRed4, colorGreen4, colorBlue4);
////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//						this.ImageColorGuide5_uButton.Focus();
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
						this.Ok_Button.Focus();
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////
					}
					else
					{
						this.ImageColorGuide4_uButton.Focus();
					}
					break;

////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//				// �`�[��F�T
//				case "ImageColorGuide5_uButton":
//					// �F���Z�b�g
//					SetToColor(colorRed5, colorGreen5, colorBlue5);
//					// �F��I������p�l����\��
//					DialogResult result5 = this.ColorDialogForm.ShowDialog();
//					// �F�I���p�l����OK�{�^���������ꂽ�ꍇ
//					if(result5 == DialogResult.OK)
//					{
//						colorRed5   = Convert.ToInt32(ColorDialogForm.Color.R);
//						colorGreen5 = Convert.ToInt32(ColorDialogForm.Color.G);
//						colorBlue5  = Convert.ToInt32(ColorDialogForm.Color.B);
//						DispToColor(5, colorRed5, colorGreen5, colorBlue5);
//						this.Ok_Button.Focus();
//					}
//					else
//					{
//						this.ImageColorGuide5_uButton.Focus();
//					}
//					break;
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Timer.Tick �C�x���g(timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.01</br>
		/// </remarks>
		private void timer_Tick(object sender, System.EventArgs e)
		{
			timer.Enabled = false;
			ScreenReconstruction();
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.29 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control���tEdit�𔲂����ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.09.29</br>
		/// </remarks>
		private void tEdit_Leave(object sender, System.EventArgs e)
		{
			// �`�[������[ID
			if (((TEdit)sender).Name == "SlipPrtSetPaperId_tEdit")
			{
				SlipPrtSetPaperId_tEdit.Text = SlipPrtSetPaperId_tEdit.Text.TrimEnd();
			}

			// �`�[�R�����g
			if (((TEdit)sender).Name == "SlipComment_tEdit")
			{
				SlipComment_tEdit.Text = SlipComment_tEdit.Text.TrimEnd();
			}

			// �o�̓v���O����ID
			if (((TEdit)sender).Name == "OutputPgId_tEdit")
			{
				OutputPgId_tEdit.Text = OutputPgId_tEdit.Text.TrimEnd();
			}

			// �o�̓v���O�����N���XID
			if (((TEdit)sender).Name == "OutputPgClassId_tEdit")
			{
				OutputPgClassId_tEdit.Text = OutputPgClassId_tEdit.Text.TrimEnd();
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.29 TAKAHASHI ADD END

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.19 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.BeforeDropDown �C�x���g(SlipFontName_uFontNameEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �h���b�v�_�E�����X�g���\�������O�ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.19</br>
		/// </remarks>
		private void SlipFontName_uFontNameEditor_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._ultraFontNameEditorFlg = true;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.BeforeDropDown �C�x���g(SlipFontName_uFontNameEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �h���b�v�_�E�����X�g��������ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.19</br>
		/// </remarks>
		private void SlipFontName_uFontNameEditor_AfterCloseUp(object sender, System.EventArgs e)
		{
			this._ultraFontNameEditorFlg = false;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.ChangeFocus �C�x���g(tArrowKeyControl)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���L�[�������̐�����s���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.19</br>
        /// <br>Update Note : 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note : 2011/08/31 �����</br>
        /// <br>              Redmine#24110 �݌Ɉړ��`�[�̔��l�̌���������ǉ�����</br>
		/// </remarks>
		private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if( e.PrevCtrl == null ) 
			{
				return;
			}

            // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� >>>>>>START
            // �t�H�[�J�X��������
            if (e.PrevCtrl == this.OutConMsg_tEdit)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.EnterpriseNamePrtCd_tComEditor;
                }
            }
            if (e.PrevCtrl == this.Note1_tEdit)
            {
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = this.RefConsTaxPrtNm_tEdit;
                }
            }
            // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� <<<<<<END
            
			// �O���b�h�̎� 
			if (e.PrevCtrl == eachSlipTypeCol_ultraGrid)
			{
                // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� >>>>>>START
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    if (this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == 0)
                    {
                        // �����󎚋敪�Ƀt�H�[�J�X�J��
                        e.NextCtrl = this.TimePrintDivCd_tComboEditor;
                    }
                    else
                    {
                        // ��̃Z���ֈړ�
                        e.NextCtrl = MoveAboveCell();
                    }
                }
				// ���^�[���L�[�̎�
                //if (e.Key == Keys.Return || e.Key == Keys.Tab)
                else if (e.Key == Keys.Return || e.Key == Keys.Tab)
                // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� <<<<<<END
                {
					e.NextCtrl = null;

					if( this.eachSlipTypeCol_ultraGrid.ActiveCell != null ) 
					{
						
						// �ŏI�Z���̎�
						if (this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == this.eachSlipTypeCol_ultraGrid.Rows.Count - 1)	
						{
							//----- h.ueno upd---------- start 2008.01.25
							
							// �ۑ��{�^���Ƀt�H�[�J�X�J��
							//e.NextCtrl = this.UpButton;
							e.NextCtrl = this.Ok_Button;
							//----- h.ueno upd---------- end   2008.01.25
						}
						else
						{
							// ���̃Z���Ƀt�H�[�J�X�J��
							e.NextCtrl = null;
							this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
							////////////////////////////////////// 2005 6.24 HNAKAMURA DEL STA ///////////////////////////////							
							// �J�ڐ��ҏW���[�h��
							//							this.grdVarCostFee.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
							//////// 2005 6.24 H.NAKAMURA DEL END //////////////////////////////////////////////////////////// 
						}
						
					}
				}

			}

			//// �ۑ��{�^��,����{�^���̎�
			if((e.PrevCtrl == this.Ok_Button) || (e.PrevCtrl == this.Cancel_Button))
			{
				if (e.Key == Keys.Up)
				{
					if(this.MainTabControl.ActiveTab.Key == "SlipPrtSetTitle")
					{
						e.NextCtrl = null;
						e.NextCtrl= this.ImageColorGuide4_uButton;
					}
					else
					{
						e.NextCtrl = null;
						e.NextCtrl= this.eachSlipTypeCol_ultraGrid;
						this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
					}
				}

			}

			//----- h.ueno del---------- start 2007.12.17
			////���ƈ󎚋敪�R���{�{�b�N�X�̎�
			//if(e.PrevCtrl == ContCpNoPrtDivCd_tComboEditor)
			//{
			//    if(e.Key == Keys.Enter || e.Key == Keys.Tab)
			//    {
			//        e.NextCtrl = null;
			//        e.NextCtrl= this.eachSlipTypeCol_ultraGrid;
			//        this.eachSlipTypeCol_ultraGrid.Rows[0].Cells[MY_SCREEN_PRINTDIV_TITLE].Activate();
			//    }
			//}
			//----- h.ueno del---------- end   2007.12.17

            // 2008.12.11 30413 ���� �폜���� >>>>>>START
            // SlipFontName_uFontNameEditor�̃h���b�v�_�E�����X�g���J���Ă���ꍇ
            //if (this._ultraFontNameEditorFlg == true)
            //{
            //    switch (e.Key)
            //    {
            //        // ���E��
            //        case Keys.Up:
            //        case Keys.Left:
            //            if (this.SlipFontName_uFontNameEditor.SelectedIndex != 0)
            //            {
            //                this.SlipFontName_uFontNameEditor.SelectedIndex -= 1;
            //            }
            //            break;

            //        // ���E��
            //        case Keys.Right:
            //        case Keys.Down:
            //            this.SlipFontName_uFontNameEditor.SelectedIndex += 1;
            //            break;

            //        default:
            //            break;
            //    }
            //    e.NextCtrl = null;
            //}
            // 2008.12.11 30413 ���� �폜���� <<<<<<END
            
			if(e.NextCtrl == this.eachSlipTypeCol_ultraGrid)
			{
				if(e.Key == Keys.Down)
				{
					e.NextCtrl = null;
					e.NextCtrl= this.eachSlipTypeCol_ultraGrid;
					this.eachSlipTypeCol_ultraGrid.Rows[0].Cells[MY_SCREEN_PRINTDIV_TITLE].Activate();
				}
				
				if(e.Key == Keys.Right)
				{
					e.NextCtrl = null;
					e.NextCtrl= this.eachSlipTypeCol_ultraGrid;
					this.eachSlipTypeCol_ultraGrid.Rows[0].Cells[MY_SCREEN_PRINTDIV_TITLE].Activate();
				}
				
				//----- h.ueno add---------- start 2008.01.25
				if((e.Key == Keys.Return)||(e.Key == Keys.Tab))
				{
					e.NextCtrl = null;
					e.NextCtrl = this.eachSlipTypeCol_ultraGrid;
					this.eachSlipTypeCol_ultraGrid.Rows[0].Cells[MY_SCREEN_PRINTDIV_TITLE].Activate();
				}
				//----- h.ueno add---------- end   2008.01.25
			}

            // 2007.04.02  S.Koga  add -------------------------------------------------------
            if ((e.NextCtrl == null) || (e.PrevCtrl == null)) return;
            switch (e.PrevCtrl.Name)
            {
                case "TopMarging_tNedit":
                    {
                        double rate = 0;
                        if (!TopMarging_tNedit.Text.Equals(""))
                            rate = double.Parse(this.TopMarging_tNedit.Text);
                        if (rate > 999.9)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "��]���̒l���s���ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                            TopMarging_tNedit.SelectAll();
                        }
                        break;
                    }
                case "LeftMarging_tNedit":
                    {
                        double rate = 0;
                        if (!LeftMarging_tNedit.Text.Equals(""))
                            rate = double.Parse(this.LeftMarging_tNedit.Text);
                        if (rate > 999.9)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���]���̒l���s���ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                            LeftMarging_tNedit.SelectAll();
                        }
                        break;
                    }
                case "RightMargin_tNedit":
                    {
                        double rate = 0;
                        if (!RightMargin_tNedit.Text.Equals(""))
                            rate = double.Parse(this.RightMargin_tNedit.Text);
                        if (rate > 999.9)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�E�]���̒l���s���ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                            RightMargin_tNedit.SelectAll();
                        }
                        break;
                    }
                case "BottomMargin_tNedit":
                    {
                        double rate = 0;
                        if (!BottomMargin_tNedit.Text.Equals(""))
                            rate = double.Parse(this.BottomMargin_tNedit.Text);
                        if (rate > 999.9)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���]���̒l���s���ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                            BottomMargin_tNedit.SelectAll();
                        }
                        break;
                    }
                // --- ADD 2009/12/31 ---------->>>>>
                case "SlipNoteCharCnt_tNedit":
                    {
                        int slipNoteCharCnt = this.SlipNoteCharCnt_tNedit.GetInt();
                        // --- UPD 2011/08/31---------->>>>>
                        //int slipNoteMax = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote");
                        int slipNoteMax = 0;
                        if (SlipPrtKind_tNedit.GetInt() == 150)
                        {
                            slipNoteMax = 40;
                        }
                        else
                        {
                            slipNoteMax = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote");
                        }
                        // --- UPD 2011/08/31----------<<<<<
                        if (slipNoteCharCnt > slipNoteMax)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���͔͈͊O�ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "SlipNote2CharCnt_tNedit":
                    {
                        int slipNote2CharCnt = this.SlipNote2CharCnt_tNedit.GetInt();
                        // --- UPD 2011/08/31---------->>>>>
                        //int slipNote2Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote2");
                        int slipNote2Max = 0;
                        if (SlipPrtKind_tNedit.GetInt() == 150)
                        {
                            slipNote2Max = 40;
                        }
                        else
                        {
                            slipNote2Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote2");
                        }
                        // --- UPD 2011/08/31----------<<<<<
                        if (slipNote2CharCnt > slipNote2Max)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���͔͈͊O�ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "SlipNote3CharCnt_tNedit":
                    {
                        int slipNote3CharCnt = this.SlipNote3CharCnt_tNedit.GetInt();
                        // --- UPD 2011/08/31---------->>>>>
                        //int slipNote3Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote3");
                        int slipNote3Max = 0;
                        if (SlipPrtKind_tNedit.GetInt() == 150)
                        {
                            slipNote3Max = 40;
                        }
                        else
                        {
                            slipNote3Max = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote3");
                        }
                        // --- UPD 2011/08/31----------<<<<<
                        if (slipNote3CharCnt > slipNote3Max)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���͔͈͊O�ł��B",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // --- ADD 2009/12/31 ----------<<<<<
            }
            // -------------------------------------------------------------------------------

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Enter �C�x���g(SlipFontName_uFontNameEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control���uFontNameEditor�ɓ������ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.10.21</br>
		/// </remarks>
		private void SlipFontName_uFontNameEditor_Enter(object sender, System.EventArgs e)
		{
			DispToColor(6, 247, 227, 156);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g(SlipFontName_uFontNameEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control���uFontNameEditor�𔲂����ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.10.21</br>
		/// </remarks>
		private void SlipFontName_uFontNameEditor_Leave(object sender, System.EventArgs e)
		{
			DispToColor(6, 255, 255, 255);
		}

		/// <summary>
		/// Control.VisibleChange �C�x���g(UI_UltraGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.02.15</br>
		/// </remarks>
		private void eachSlipTypeCol_ultraGrid_VisibleChanged(object sender, System.EventArgs e)
		{
			// �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
			this.eachSlipTypeCol_ultraGrid.ActiveCell	= null;
		}
		
		/// <summary>
		/// UltraTab.SelectedTabChanged�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���^�u��ύX�����ۂ̐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2005.04.14</br>
		/// </remarks>
		private void MainTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (e.Tab.Key == "SlipPrtSet")
			{
				OutConMsg_tEdit.Focus();
			}
			if (e.Tab.Key == "SlipPrtSetTitle")
			{
				TitleName1_tEdit.Focus();
			}
		}
		
		/// <summary>
		/// UltraGrid.AfterCellActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2005.05.13</br>
		/// </remarks>
		private void eachSlipTypeCol_ultraGrid_AfterCellActivate(object sender, System.EventArgs e)
		{
			if (this.eachSlipTypeCol_ultraGrid.ActiveCell != null)
			{
				if (!(this.eachSlipTypeCol_ultraGrid.ActiveCell == this.eachSlipTypeCol_ultraGrid.ActiveRow.Cells[MY_SCREEN_PRINTDIV_TITLE]))
				{
					// ActiveCell��`�[�^�C�v�ʗ񖼏̂փZ�b�g����
					this.eachSlipTypeCol_ultraGrid.ActiveCell = this.eachSlipTypeCol_ultraGrid.ActiveRow.Cells[MY_SCREEN_PRINTDIV_TITLE];
					this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
				this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
			}

			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor				= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2			= System.Drawing.Color.FromArgb( 238, 149, 21 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle		= Infragistics.Win.GradientStyle.Vertical;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor				= System.Drawing.Color.Black;
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled		= System.Drawing.Color.FromArgb( 251, 230, 148 );
			this.eachSlipTypeCol_ultraGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2	= System.Drawing.Color.FromArgb( 238, 149, 21 );
		}

		/// <summary>
		/// �u��Ɂv�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �u��Ɂv�{�^�����N���b�N���ꂽ���ɔ������܂�</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2006.03.16</br>
		/// </remarks>
		private void UpButton_Click(object sender, System.EventArgs e)
		{
			//Row��Null�̏ꍇ�������Ȃ�
			if( this.eachSlipTypeCol_ultraGrid.ActiveRow == null)
			{
				return;
			}
			UltraGridRow currentRow = null;
			
			UltraGridRow swapRow = null;

			currentRow = this.eachSlipTypeCol_ultraGrid.ActiveRow;
			
			//�ŏ�ʂ̍s�̏ꍇ�Ɠ`�[�^�C�v�ʗ񖼏̂���̏ꍇ�͏������Ȃ�
			if( currentRow.Index - 1 < 0 || currentRow.Cells[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].Value.ToString() == "")
			{
				return;
			}
			else
			{
				//�オ�������Ȃ��ɂ��������̂�����
				swapRow = this.eachSlipTypeCol_ultraGrid.Rows[ currentRow.Index - 1 ];
				int tmpOrderNo = (int)swapRow.Cells[MY_SCREEN_ODER].Value;			
				swapRow.Cells[MY_SCREEN_ODER].Value = currentRow.Cells[MY_SCREEN_ODER].Value;	
				currentRow.Cells[MY_SCREEN_ODER].Value = tmpOrderNo;

				//�f�[�^�e�[�u���̒��g������������
				//�\����
				int currentOder = (int)this._bindTable.Rows[currentRow.Index][MY_SCREEN_ODER];
				this._bindTable.Rows[currentRow.Index][MY_SCREEN_ODER] = this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_ODER];
				this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_ODER] = currentOder;
		
				//�`�[�^�C�g���񖼏�
				string currentTitle = this._bindTable.Rows[currentRow.Index][MY_SCREEN_EACH_SLIPTYPECOL_TITLE].ToString();
				this._bindTable.Rows[currentRow.Index][MY_SCREEN_EACH_SLIPTYPECOL_TITLE] = this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE];
				this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE] = currentTitle;

				//�󎚋敪
				int currentDiv = (int)this._bindTable.Rows[currentRow.Index][MY_SCREEN_PRINTDIV_TITLE];
				this._bindTable.Rows[currentRow.Index][MY_SCREEN_PRINTDIV_TITLE] = this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_PRINTDIV_TITLE];
				this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_PRINTDIV_TITLE] = currentDiv;
				
				//ID
				string currentId = this._bindTable.Rows[currentRow.Index][MY_SCREEN_ID].ToString(); 
				this._bindTable.Rows[currentRow.Index][MY_SCREEN_ID] = this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_ID];
				this._bindTable.Rows[currentRow.Index - 1][MY_SCREEN_ID] = currentId;
			}
			//�\�[�g
			this._bindTable.DefaultView.Sort = "�\������";
				
			//�O���b�h�̕ύX�𔽉f�����܂�
			this.eachSlipTypeCol_ultraGrid.UpdateData();

			//��ɏオ�����s���A�N�e�B�u�ɂ���
			swapRow.Activate();
		
		}

		/// <summary>
		/// �u���Ɂv�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �u���Ɂv�{�^�����N���b�N���ꂽ���ɔ������܂�</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2006.03.16</br>
		/// </remarks>
		private void DownButton_Click(object sender, System.EventArgs e)
		{
			//Row��Null�̏ꍇ�������Ȃ�
			if( this.eachSlipTypeCol_ultraGrid.ActiveRow == null)
			{
				return;
			}
			UltraGridRow currentRow = null;

			UltraGridRow swapRow = null;
			
			currentRow = this.eachSlipTypeCol_ultraGrid.ActiveRow;

			//�ŉ��ʂ̍s�̏ꍇ�Ɠ`�[�^�C�v�ʗ񖼏̂���̏ꍇ�͏������Ȃ�
			if( currentRow.Index == MAX_ROW_COUNT - 1 || currentRow.Cells[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].Value.ToString() == "")
			{
				return;
			}
			else
			{
				//�����������Ȃ牺�ɂ��������̂����
				swapRow = this.eachSlipTypeCol_ultraGrid.Rows[ currentRow.Index + 1 ];
				if(!(swapRow.Cells[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].Value.ToString() == ""))
				{
					int tmpOrderNo = (int)swapRow.Cells[MY_SCREEN_ODER].Value;
					swapRow.Cells[MY_SCREEN_ODER].Value = currentRow.Cells[MY_SCREEN_ODER].Value;
					currentRow.Cells[MY_SCREEN_ODER].Value = tmpOrderNo;

					//�f�[�^�e�[�u���̒��g������������
					//�\����
					int currentOrder = (int)this._bindTable.Rows[currentRow.Index][MY_SCREEN_ODER];
					this._bindTable.Rows[currentRow.Index][MY_SCREEN_ODER] = this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_ODER];
					this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_ODER] = currentOrder;

					//�`�[�^�C�v�ʗ񖼏�
					string currentTitle = this._bindTable.Rows[currentRow.Index][MY_SCREEN_EACH_SLIPTYPECOL_TITLE].ToString();
					this._bindTable.Rows[currentRow.Index][MY_SCREEN_EACH_SLIPTYPECOL_TITLE] = this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE];
					this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_EACH_SLIPTYPECOL_TITLE] = currentTitle;

					//�󎚋敪
					int currentDiv = (int)this._bindTable.Rows[currentRow.Index][MY_SCREEN_PRINTDIV_TITLE];
					this._bindTable.Rows[currentRow.Index][MY_SCREEN_PRINTDIV_TITLE] = this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_PRINTDIV_TITLE];
					this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_PRINTDIV_TITLE] = currentDiv;

					//ID
					string currentId = this._bindTable.Rows[currentRow.Index][MY_SCREEN_ID].ToString();
					this._bindTable.Rows[currentRow.Index][MY_SCREEN_ID] = this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_ID];
					this._bindTable.Rows[currentRow.Index + 1][MY_SCREEN_ID] = currentId;
				}
			}
			//�\�[�g
			this._bindTable.DefaultView.Sort = "�\������";
	
			//�O���b�h�̕ύX�𔽉f�����܂�
			this.eachSlipTypeCol_ultraGrid.UpdateData();
			
			if(!(swapRow.Cells[MY_SCREEN_EACH_SLIPTYPECOL_TITLE].Value.ToString() == ""))
			{
				this.eachSlipTypeCol_ultraGrid.Rows[currentRow.Index + 1].Activate();
			}

			this.eachSlipTypeCol_ultraGrid.UpdateData();
		}

		/// <summary>
		/// Control.KeyDown �C�x���g (UI_UltraGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.02.15</br>
		/// </remarks>
		private void eachSlipTypeCol_ultraGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{

			// �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
			if( this.eachSlipTypeCol_ultraGrid.ActiveCell == null ) 
			{
				return;
			}

			// �O���b�h��Ԏ擾()
			Infragistics.Win.UltraWinGrid.UltraGridState status = this.eachSlipTypeCol_ultraGrid.CurrentState;

			if( ( status & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit ) == Infragistics.Win.UltraWinGrid.UltraGridState.InEdit ) 
			{

				//�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
				Control nextControl = null;
				if( ( e.Control == false ) && ( e.Shift == false ) && ( e.Alt == false ) && 
					( ( status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown ) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown ) ) 
				{

					switch( e.KeyCode ) 
					{
							// ���L�[
						case Keys.Up:
						{
							// ��̃Z���ֈړ�
                            // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� >>>>>>START
                            //nextControl = MoveAboveCell();
                            if (this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == 0)
                            {
                                nextControl = this.TimePrintDivCd_tComboEditor;
                            }
                            else
                            {
                                nextControl = MoveAboveCell();
                            }
                            // 2008.10.03 30413 ���� �A���[�L�[�̃t�H�[�J�X�������I�ɐ��� <<<<<<END
                            e.Handled = true;
							break;
						}
							// ���L�[
						case Keys.Down:
                        {
							// ���̃Z���ֈړ�
							nextControl = MoveBelowCell();
							e.Handled = true;
							break;
						}
							// ���L�[
						case Keys.Left:
						{
							// ��̃Z���ֈړ�
							nextControl = MoveAboveCell();
							e.Handled = true;
							
							break;
						}
							// ���L�[
						case Keys.Right:
						{	
							// ���̃Z���ֈړ�
							nextControl = MoveBelowCell();
							e.Handled = true;
							
							break;
						}
					
					}
                }
                
				if( nextControl != null ) 
				{
					nextControl.Focus();
				}
		}
			#region �����R�����g
			// �O���b�h��Ԏ擾
//			Infragistics.Win.UltraWinGrid.UltraGridState status = this.eachSlipTypeCol_ultraGrid.CurrentState;
//			
//
////			Control nextControl = null;
//			if(this. eachSlipTypeCol_ultraGrid.ActiveCell != null)
//			{
//				switch (e.KeyCode)
//				{
//					case Keys.Up:
//					{	  
//						if(this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == 0 && this.eachSlipTypeCol_ultraGrid.ActiveCell.IsInEditMode == true)
//						{
//							e.Handled = true;
//							break;
//						}
//						else
//						{
//							if(!(e.Alt))
//							{
//							
//								if((status != (Infragistics.Win.UltraWinGrid.UltraGridState)221) && (status !=(Infragistics.Win.UltraWinGrid.UltraGridState)65757))
//								{
//									this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
//									e.Handled = true;
//								}
//							}
//						
//						}	
//						break;
//					}
//					case Keys.Down:
//					{
//						//�ŏI�s�Ł��L�[�͕ۑ��{�^���Ƀt�H�[�J�X�J��
//						if((this. eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == this. eachSlipTypeCol_ultraGrid.Rows.Count - 1))
//						{
//							if(!(e.Alt))
//							{
//								if(( status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown )
//								{
//									// �ۑ��{�^���Ƀt�H�[�J�X�J��
//									this.Ok_Button.Focus();
//									e.Handled = true;
//
//								}
////								if((status != (Infragistics.Win.UltraWinGrid.UltraGridState)221) && (status !=(Infragistics.Win.UltraWinGrid.UltraGridState)65757))
////								{
////									// �ۑ��{�^���Ƀt�H�[�J�X�J��
////									this.Ok_Button.Focus();
////									e.Handled = true;
////								}
//								
//							}
//							
//						}
////						else
////						{
//						if(!(e.Alt))
//						{
//							if((status != (Infragistics.Win.UltraWinGrid.UltraGridState)221) && (status !=(Infragistics.Win.UltraWinGrid.UltraGridState)65757))
//							{
//								this.eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
//								e.Handled = true;
//							}
//								
//						}
////						}
////
//						break;
//						// ���̃Z���ֈړ�
////						nextControl = MoveBelowCell();
////						e.Handled = true;
////						break;
//					}
//						////////////////////////////////////////////// 2005.07.01 H.NAKAMURA ADD STA //
//					case Keys.Right:
//					{
//						this. eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
//						e.Handled = true;
//						break;
//					}
//
//					case Keys.Left:
//					{
//						if(this. eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index == 0)
//						{
//							break;
//						}
//						else
//						{
//							this. eachSlipTypeCol_ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
//							e.Handled = true;
//						}	
//						break;
//					}
//
//						// 2005.07.01 H.NAKAMURA ADD END //////////////////////////////////////////////
//					
//				}
//			}
			#endregion �����R�����g
	
		}

		/// <summary>
		/// ���̃Z���ֈړ�����
		/// </summary>
		/// <returns>���̃R���g���[��</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ�O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.01.13</br>
		/// </remarks>
		private Control MoveBelowCell()
		{
			// �A�N�e�B�u�Z����null
			if( this.eachSlipTypeCol_ultraGrid.ActiveCell == null ) 
			{
				return null;
			}

			// �O���b�h��Ԏ擾
			Infragistics.Win.UltraWinGrid.UltraGridState status = this.eachSlipTypeCol_ultraGrid.CurrentState;

			// �ŉ��i�Z���̎�
			if( ( status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast ) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast ) 
			{
				// �ۑ��{�^���ֈړ�
				return this.Ok_Button;
			}
				// �őO�Z���łȂ���
			else 
			{
				// �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
				int prevCol = this.eachSlipTypeCol_ultraGrid.ActiveCell.Column.Index;
				int prevRow = this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index;

				// ���̃Z���Ɉړ�
				this.eachSlipTypeCol_ultraGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );

				// �Z�����ړ����Ă��Ȃ���
				if( ( prevCol == this.eachSlipTypeCol_ultraGrid.ActiveCell.Column.Index ) && 
					( prevRow == this.eachSlipTypeCol_ultraGrid.ActiveCell.Row.Index ) ) 
				{
					// �ۑ��{�^���ֈړ�
					return this.Ok_Button;
				}
					// �Z�����ړ����Ă�
				else 
				{
					// �e�L�X�g�S�I��
//					CellTextSelectAll();

					return null;
				}
			}
		}

		/// <summary>
		/// ��̃Z���ֈړ�����
		/// </summary>
		/// <returns>���̃R���g���[��</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ�O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.01.13</br>
		/// </remarks>
		private Control MoveAboveCell()
		{
			// �A�N�e�B�u�Z����null
			if( this.eachSlipTypeCol_ultraGrid.ActiveCell == null ) 
			{
				return null;
			}

			// �O���b�h��Ԏ擾
			Infragistics.Win.UltraWinGrid.UltraGridState status = this.eachSlipTypeCol_ultraGrid.CurrentState;

			// �ŏ�i�Z���̎�
			if( ( status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst ) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst ) 
			{
				// �ړ����Ȃ�
				return null;
			}
				// �őO�Z���łȂ���
			else 
			{
				// ��̃Z���Ɉړ�
				this.eachSlipTypeCol_ultraGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
				return null;
				
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.19 TAKAHASHI ADD END


        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// <summary>
        /// ���Ӑ�R�[�h�œ��Ӑ於�̂��擾
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂�</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/08/06</br>
        /// </remarks>
        private void CustomerGuide_uButton_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (string.IsNullOrEmpty(this.CustomerCode_tNedit.Text))
            {
                return;
            }
            this.OutConMsg_tEdit.Focus();
            this.OutConMsg_tEdit.SelectAll();
        }

        /// <summary>���Ӑ�I���������C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�I�����������܂�</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/08/06</br>
        /// <br>Update Note : 2010/08/17 �k���r #12932�Ή�</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.CustomerCode_tNedit.SetInt(customerInfo.CustomerCode);
                this.CustomerName_uLabel.Text = customerInfo.CustomerSnm;
                this.customerCode = this.CustomerCode_tNedit.GetInt();
                this.customerName = this.CustomerName_uLabel.Text;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //-----UPD 2010/08/17---------->>>>>
                    //"�����̓��Ӑ�R�[�h��ݒ肵�ĉ������B",
                    "���Ӑ�R�[�h�����݂��܂���B",
                    //-----UPD 2010/08/17----------<<<<<
                    status,
                    MessageBoxButtons.OK);

                if (this.customerCode != 0)
                {
                    this.CustomerCode_tNedit.Text = this.customerCode.ToString();
                }
                else
                {
                    this.CustomerCode_tNedit.Clear();
                }
                this.CustomerName_uLabel.Text = this.customerName;

                return;
            }
            else
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              "���Ӑ���̎擾�Ɏ��s���܂����B",
                              status,
                              MessageBoxButtons.OK);

                if (this.customerCode != 0)
                {
                    this.CustomerCode_tNedit.Text = this.customerCode.ToString();
                }
                else
                {
                    this.CustomerCode_tNedit.Clear();
                }
                this.CustomerName_uLabel.Text = this.customerName;

                return;
            }
            this.CustomerCode_tNedit.Text = this.CustomerCode_tNedit.Text.PadLeft(8, '0');
        }

        /// <summary>
        /// ���Ӑ�R�[�h�œ��Ӑ於�̂��擾
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�R�[�htNedit�����ꂽ���ɔ������܂�</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/08/06</br>
        /// <br>Update Note : 2010/08/17 �k���r #12932�Ή�</br>
        /// </remarks>
        private void CustomerCode_tNedit_Leave(object sender, EventArgs e)
        {
            if (this.CustomerCode_tNedit.Text.Trim().Length == 0)
            {
                this.customerCode = 0;
                this.customerName = string.Empty;
                this.CustomerName_uLabel.Text = string.Empty;
                this.CustomerCode_tNedit.Clear();
                return;
            }

            //�@���Ӑ於�̂̎擾
            CustomerInfo customerInfo;
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            int status = this._customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, this.CustomerCode_tNedit.GetInt(), out customerInfo);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.CustomerName_uLabel.Text = customerInfo.CustomerSnm;
                this.customerCode = this.CustomerCode_tNedit.GetInt();
                this.customerName = this.CustomerName_uLabel.Text;

                this.OutConMsg_tEdit.Focus();
                this.OutConMsg_tEdit.SelectAll();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //-----UPD 2010/08/17---------->>>>>
                    //"�����̓��Ӑ�R�[�h��ݒ肵�ĉ������B",
                    "���Ӑ�R�[�h�����݂��܂���B",
                    //-----UPD 2010/08/17----------<<<<<
                    status,
                    MessageBoxButtons.OK);

                if (this.customerCode != 0)
                {
                    this.CustomerCode_tNedit.Text = this.customerCode.ToString();
                }
                else
                {
                    this.CustomerCode_tNedit.Clear();
                }
                this.CustomerName_uLabel.Text = this.customerName;
                this.CustomerCode_tNedit.Focus();

                return;
            }
            else
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              "���Ӑ���̎擾�Ɏ��s���܂����B",
                              status,
                              MessageBoxButtons.OK);

                if (this.customerCode != 0)
                {
                    this.CustomerCode_tNedit.Text = this.customerCode.ToString();
                }
                else
                {
                    this.CustomerCode_tNedit.Clear();
                }
                this.CustomerName_uLabel.Text = this.customerName;

                return;
            }
            this.CustomerCode_tNedit.Text = this.CustomerCode_tNedit.Text.PadLeft(8, '0');
        }

        /// <summary>
        /// ���Ӑ�R�[�htNedit�����鎞�ɔ������܂�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�R�[�htNedit�����鎞�ɔ������܂�</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/08/06</br>
        /// </remarks>
        private void CustomerCode_tNedit_Enter(object sender, EventArgs e)
        {
            if (this.CustomerCode_tNedit.GetInt() != 0)
            {
                this.CustomerCode_tNedit.Text = this.customerCode.ToString();
            }
        }
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
		#endregion
	}
}

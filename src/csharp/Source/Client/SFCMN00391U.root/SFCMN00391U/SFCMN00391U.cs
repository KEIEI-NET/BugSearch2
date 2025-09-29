//**********************************************************************//
// System			:	PM.NS       				    				//
// Sub System		:							   						//
// Program name		:	�e�L�X�g�o�͋��ʃ_�C�A���O�N���X				//
//					:	SFCMN00391U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms			                //
// Programmer		:	���X�� ���@�@�@�@�@							�@�@//
// Date				:	2009.04.07										//
//----------------------------------------------------------------------//
// Update Note		:	2009.04.07 SF���痬�p���č쐬					//
//----------------------------------------------------------------------//
//				  (c)Copyright  2009 Broadleaf Co.,Ltd.		            //
//**********************************************************************//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �e�L�X�g�o�͋��ʃ_�C�A���O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �e�L�X�g�o�͋��ʃ_�C�A���O�̏ڍאݒ���s���܂��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2006.03.31</br>
    /// <br>=============================================================</br>
    /// <br>Update Note: 2009.04.07�@���X�� ��</br>
    /// <br>             SF����Q�ƍ쐬</br>
    /// <br>-------------------------------------------------------------</br>
    /// <br>Update Note: 2009.05.20�@���X�� ��</br>
    /// <br>             ���o���s��Ȃ��ꍇ�ɁA�㏑���L�����Z�b�g����Ȃ��s��̏C��</br>
    /// </remarks>
	public class SFCMN00391U : System.Windows.Forms.Form
	{
		#region Component
		private System.Windows.Forms.GroupBox groupBox3;
		private Infragistics.Win.Misc.UltraButton OKButton;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TComboEditor DispName_tComboEditor;
		private Infragistics.Win.Misc.UltraButton CanButton;
        private Broadleaf.Library.Windows.Forms.TEdit OutPutFilePath_tEdit;
		private Infragistics.Win.Misc.UltraButton OutPutChang_Button;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Broadleaf.Library.Windows.Forms.TEdit fullPath_tEdit;
        private Infragistics.Win.Misc.UltraLabel MessageLabel;

		#endregion
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private IContainer components;

		#region �R���X�g���N�^�[
        /// <summary>
        /// �e�L�X�g�o�͋��ʃ_�C�A���O�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͋��ʃ_�C�A���O�N���X�̕ϐ������������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		public SFCMN00391U()
		{			
			InitializeComponent();
            //�o�͐ݒ�}�X�^�A�N�Z�X�N���X
			_outPutSetAcs = new OutputSetAcs();
                   
		}
		#endregion

		#region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN00391U));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MessageLabel = new Infragistics.Win.Misc.UltraLabel();
            this.fullPath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.DispName_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.OutPutChang_Button = new Infragistics.Win.Misc.UltraButton();
            this.OutPutFilePath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OKButton = new Infragistics.Win.Misc.UltraButton();
            this.CanButton = new Infragistics.Win.Misc.UltraButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullPath_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispName_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutFilePath_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MessageLabel);
            this.groupBox3.Controls.Add(this.fullPath_tEdit);
            this.groupBox3.Controls.Add(this.ultraLabel3);
            this.groupBox3.Controls.Add(this.ultraLabel1);
            this.groupBox3.Controls.Add(this.DispName_tComboEditor);
            this.groupBox3.Controls.Add(this.OutPutChang_Button);
            this.groupBox3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(7, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 128);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // MessageLabel
            // 
            appearance1.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MessageLabel.Appearance = appearance1;
            this.MessageLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MessageLabel.HotTrackAppearance = appearance2;
            this.MessageLabel.Location = new System.Drawing.Point(8, 94);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(408, 23);
            this.MessageLabel.TabIndex = 21;
            this.MessageLabel.Text = "�e�L�X�g�o�͂��s���܂��B";
            // 
            // fullPath_tEdit
            // 
            this.fullPath_tEdit.ActiveAppearance = appearance3;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.fullPath_tEdit.Appearance = appearance4;
            this.fullPath_tEdit.AutoSelect = false;
            this.fullPath_tEdit.DataText = "";
            this.fullPath_tEdit.Enabled = false;
            this.fullPath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fullPath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.fullPath_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.fullPath_tEdit.Location = new System.Drawing.Point(112, 58);
            this.fullPath_tEdit.MaxLength = 48;
            this.fullPath_tEdit.Name = "fullPath_tEdit";
            this.fullPath_tEdit.Size = new System.Drawing.Size(431, 24);
            this.fullPath_tEdit.TabIndex = 19;
            // 
            // ultraLabel3
            // 
            appearance5.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            appearance6.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.HotTrackAppearance = appearance6;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 58);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(104, 24);
            this.ultraLabel3.TabIndex = 20;
            this.ultraLabel3.Text = "�o�͐�";
            // 
            // ultraLabel1
            // 
            appearance7.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            appearance8.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance8.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.HotTrackAppearance = appearance8;
            this.ultraLabel1.Location = new System.Drawing.Point(8, 23);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(104, 24);
            this.ultraLabel1.TabIndex = 19;
            this.ultraLabel1.Text = "�o�̓p�^�[��";
            // 
            // DispName_tComboEditor
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DispName_tComboEditor.ActiveAppearance = appearance9;
            this.DispName_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DispName_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DispName_tComboEditor.ItemAppearance = appearance10;
            this.DispName_tComboEditor.Location = new System.Drawing.Point(112, 24);
            this.DispName_tComboEditor.Name = "DispName_tComboEditor";
            this.DispName_tComboEditor.Size = new System.Drawing.Size(431, 24);
            this.DispName_tComboEditor.TabIndex = 13;
            // 
            // OutPutChang_Button
            // 
            this.OutPutChang_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.OutPutChang_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OutPutChang_Button.Location = new System.Drawing.Point(424, 91);
            this.OutPutChang_Button.Name = "OutPutChang_Button";
            this.OutPutChang_Button.Size = new System.Drawing.Size(120, 27);
            this.OutPutChang_Button.TabIndex = 16;
            this.OutPutChang_Button.Text = "�o�͐�ύX(&P)";
            this.OutPutChang_Button.Click += new System.EventHandler(this.OutPutChang_Button_Click);
            // 
            // OutPutFilePath_tEdit
            // 
            this.OutPutFilePath_tEdit.ActiveAppearance = appearance11;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.OutPutFilePath_tEdit.Appearance = appearance12;
            this.OutPutFilePath_tEdit.AutoSelect = false;
            this.OutPutFilePath_tEdit.DataText = "";
            this.OutPutFilePath_tEdit.Enabled = false;
            this.OutPutFilePath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutPutFilePath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 48, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.OutPutFilePath_tEdit.Location = new System.Drawing.Point(248, 152);
            this.OutPutFilePath_tEdit.MaxLength = 48;
            this.OutPutFilePath_tEdit.Name = "OutPutFilePath_tEdit";
            this.OutPutFilePath_tEdit.Size = new System.Drawing.Size(20, 24);
            this.OutPutFilePath_tEdit.TabIndex = 0;
            this.OutPutFilePath_tEdit.Visible = false;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.OKButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OKButton.Location = new System.Drawing.Point(269, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(140, 27);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "�o��(&S)";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CanButton
            // 
            this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.CanButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CanButton.Location = new System.Drawing.Point(411, 159);
            this.CanButton.Name = "CanButton";
            this.CanButton.Size = new System.Drawing.Size(140, 27);
            this.CanButton.TabIndex = 15;
            this.CanButton.Text = "�L�����Z��(&C)";
            this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.radioButton1.Location = new System.Drawing.Point(15, 164);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 24);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Text = "�㏑������";
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.radioButton2.Location = new System.Drawing.Point(127, 164);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 24);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.Text = "�ǉ�����";
            this.radioButton2.Visible = false;
            // 
            // ultraLabel2
            // 
            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance13.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.Appearance = appearance13;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            appearance14.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance14.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.HotTrackAppearance = appearance14;
            this.ultraLabel2.Location = new System.Drawing.Point(15, 139);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(224, 24);
            this.ultraLabel2.TabIndex = 18;
            this.ultraLabel2.Text = "�t�@�C�������ɑ��݂��܂��B";
            this.ultraLabel2.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "�o�͐�ݒ�";
            // 
            // SFCMN00391U
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.CancelButton = this.CanButton;
            this.ClientSize = new System.Drawing.Size(568, 195);
            this.ControlBox = false;
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.CanButton);
            this.Controls.Add(this.OutPutFilePath_tEdit);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFCMN00391U";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�o�͐ݒ�";
            this.Load += new System.EventHandler(this.SFCMN00391U_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullPath_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispName_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutFilePath_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN00391U());
		}
		#endregion

		#region Private�����o

        private SFCMN06002C _printInfo;

		private OutputSet _outPutSet; //�o�͐ݒ�}�X�^�f�[�^�N���X(SFCMN09121E)
		private ArrayList _outPutList; 
		private OutputSetAcs _outPutSetAcs;//�o�͐ݒ�}�X�^�A�N�Z�X�N���X(SFCMN09121A)
		private ArrayList wkOutPutList = null;
        private string localFilePahtName = "";
        private string localFileName     = "";
        private int _PrintMode = 0; //������[�h 0:ok�{�^�����������ɒ��o������s���B 1:ok�{�^���������ɒ��[�v�����^�ݒ�݂̂��Z�b�g���I��
        private int _ltimeSelectIndex = -1;

        //�萔
        private const string DEFAULT = "DEFAULT.CSV";�@�@�@�@�@�@�@�@�@�@�@�@�@
        private const string DEFAULTFILENAME = "PRTOUT\\CSV";
        private const string OUTPUTSET_DEFAULT_FILEPAHTNAME = @"\PRTOUT\CSV\";

		#endregion

		#region �v���p�e�B

		/// ��������v���p�e�B
        public SFCMN06002C PrintInfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        ///	������[�h 0:ok�{�^�����������ɒ��o������s���B 1:ok�{�^���������ɒ��[�v�����^�ݒ�݂̂��Z�b�g���I�� 
        /// </summary>
        public int PrintMode
        {
            get { return this._PrintMode; }
            set { this._PrintMode = value; }
        }

		#endregion

        #region Method

        /// <summary>
        /// �o�͐ݒ�}�X�^���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�͐ݒ�}�X�^���擾�������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		private int GetPaperInfo()
		{
			int status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// �R���{�{�b�N�X�ɒǉ�
			this._outPutSet       = new OutputSet();                              
			this.wkOutPutList     = new ArrayList();
            this._outPutList      = new ArrayList();				
			OutputSet outPutSet_r = new OutputSet();
           
            outPutSet_r.EnterpriseCode      = this._printInfo.enterpriseCode;   //��ƃR�[�h
            outPutSet_r.PgId                = this._printInfo.kidopgid;         //�v���O����ID
            outPutSet_r.PrintPaperSetCd     = this._printInfo.PrintPaperSetCd;  //�ݒ�R�[�h(���R�ɐݒ�\)
            outPutSet_r.SelectInfoCode      = this._printInfo.selectInfoCode;	//0:���[�@1:�e�L�X�g						
            outPutSet_r.OutputFormFileName  = "";	                            //�o�̓t�@�C����
            outPutSet_r.DisplayName         = "";	                            //�o�͖���
            outPutSet_r.ExtractionPgId      = "";	                            //���o�v���O����ID
            outPutSet_r.ExtractionPgClassId = "";	                            //���o�v���O�����N���XID
            outPutSet_r.OutputPgId          = "";	                            //�e�L�X�g�o�̓v���O����ID
            outPutSet_r.OutputPgClassId     = "";	                            //�e�L�X�g�o�̓v���O�����N���XID
            outPutSet_r.OutConfimationMsg   = "";	                            //�o�͊m�F���b�Z�[�W
            outPutSet_r.OutputFilePathName  = "";                               //�e�L�X�g�o�͐�t�@�C���p�X��
            outPutSet_r.OutputFileName      = "";                               //�e�L�X�g�o�̓t�@�C����

                 
            //�o�͐ݒ�}�X�^�Ǎ��ݏ���
            status = _outPutSetAcs.SearchOutputSet(out _outPutList, outPutSet_r);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (OutputSet outPutSet in _outPutList)
                {
                    if (outPutSet != null)
                    {
                        if ((outPutSet.PgId == this._printInfo.kidopgid) && (outPutSet.LogicalDeleteCode == 0) && (outPutSet.SelectInfoCode == 1))
                        {
                            wkOutPutList.Add(outPutSet);
                            DispName_tComboEditor.Items.Add(outPutSet.DisplayName.ToString());
                        }
                    }
                }

                //�e�L�X�g�o�͂��o�^����Ă��Ȃ�
                if (wkOutPutList.Count == 0)
                {
                    DialogResult res = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,            �@// �G���[���x��
                    "SFCMN00391U", 						      // �A�Z���u���h�c�܂��̓N���X�h�c
                    "�o�͉\�ȃe�L�X�g���_�񂳂�Ă��܂���", // �\�����郁�b�Z�[�W
                    -1, 									  // �X�e�[�^�X�l
                    MessageBoxButtons.OK);				    �@// �\������{�^��

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    this.Close();
                    return status;
                 
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                DialogResult res = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_INFO,            �@// �G���[���x��
                "SFCMN00391U", 						      // �A�Z���u���h�c�܂��̓N���X�h�c
                "�o�͉\�ȃe�L�X�g���_�񂳂�Ă��܂���", // �\�����郁�b�Z�[�W
                -1, 									  // �X�e�[�^�X�l
                MessageBoxButtons.OK);				    �@// �\������{�^��

                if (res == DialogResult.OK)
                {
                    this.Close();
                    return status;
                }
            }
            else
            {
                DialogResult res = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,            �@ // �G���[���x��
                "SFCMN00391U", 						       // �A�Z���u���h�c�܂��̓N���X�h�c
                "�o�͐ݒ�Ǎ��ݏ����ŃG���[���������܂���",// �\�����郁�b�Z�[�W 
                -1, 									   // �X�e�[�^�X�l
                 MessageBoxButtons.OK);				    �@ // �\������{�^��

                if (res == DialogResult.OK)
                {
                    this.Close();
                    return status;
                }
            }
                     
			// �f�t�H���g�ݒ�}�X�^���[�h
            ReadDefaultSettings();
                          				
            //�ǉ��E�㏑���I�����x���\���E��\������
            //�o�͐�̃t�@�C�������݂��Ă���ꍇ�ɕ\�����܂�
            if ((System.IO.File.Exists(this._printInfo.outPutFilePathName)))
            {
                ultraLabel2.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton1.Checked = true;
            }

            //�t�@�C�����ƃt���p�X���擾���Ă���         
            this.OutPutFilePath_tEdit.Text = this._printInfo.outPutFileName;
            this.fullPath_tEdit.Text = this._printInfo.outPutFilePathName;
            //���肦�Ȃ����A�t�@�C�����A�o�͐�p�X���o�^����Ă��Ȃ������ꍇ
            if (this._printInfo.outPutFileName == "" || this._printInfo.outPutFilePathName == "")
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
           
            return status;
		}

        /// <summary>
        /// ���o���W�b�N
        /// </summary>
        public int ExtraProc() 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string AssemblyID = "";
            string ClassID = "";
            object ob = null;
            //���o����
            if (this._printInfo.extrapgid != null)
            {

                if (this._printInfo.extrapgid.ToString().Trim() != "")
                {
                    //���o�c�k�k�����t���N�V����
                    //����c�k�k�����t���N�V����
                    AssemblyID = this._printInfo.extrapgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._printInfo.extraclassid.ToString();

                    // �A�Z���u���̃��[�h
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);
                        // �A�Z���u�����̃N���X���擾���܂��B
                        // �l�[���X�y�[�X���܂߂����S�ȃN���X���Ŏw�肷��K�v������܂��B
                        System.Type type = assm.GetType(ClassID);

                        if (type != null)
                        {
                            // �N���X�𓮓I�ɍ쐬���܂��B
                            object instance = Activator.CreateInstance(type, new object[] { this._printInfo });
                            // �N���X���̃��\�b�h���擾���ČĂяo���܂��B
                            MethodInfo method = type.GetMethod("ExtrPrintData", new Type[0]);
                            ob = method.Invoke(instance, null);

                            status = (int)ob;                          
                            this._printInfo.status = (int)ob;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception)
                    {                     
                        this.DialogResult = DialogResult.Abort;
                        status = -1;
                        this._printInfo.status = -1;
                    }
                }
            }
            return status;
        }


        /// <summary>
        /// �e�L�X�g�o�̓��C������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓��C���������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		public int PrtProc() 
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;		
			string AssemblyID = "";
			string ClassID    = "";

            // 2009.05.20 Del >>>
			//�㏑���p�t���O
            //2006/10/02 H.NAKAMURA EDIT
            ////��������Visible�v���p�e�B�������܂��B
            //if (this.radioButton1.Checked)
            //{
            //    this._printInfo.overWriteFlag = false; //�㏑������
            //}
            //else if (this.radioButton2.Checked)
            //{              
            //    this._printInfo.overWriteFlag = true; //�ǉ�����
            //}
            //else
            //{
            //    this._printInfo.overWriteFlag = false; //�㏑������
            //}
            // 2009.05.20 Del <<<

            //�������
            if (this._printInfo.printpgid != null)
            {
                if (this._printInfo.printpgid.ToString().Trim() != "")
                {
                    //����c�k�k�����t���N�V����
                    AssemblyID = _printInfo.printpgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._printInfo.printclassid.ToString();
                    // �A�Z���u���̃��[�h
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);
                        // �A�Z���u�����̃N���X���擾���܂��B
                        // �l�[���X�y�[�X���܂߂����S�ȃN���X���Ŏw�肷��K�v������܂��B
                        System.Type type = assm.GetType(ClassID);
                        if (type != null)
                        {
                            // �N���X�𓮓I�ɍ쐬���܂��B
                            object instance = Activator.CreateInstance(type, new object[] { this._printInfo });
                            int ret = 0;
                            if (instance is IOutPutText)
                            {
                                ret = ((IOutPutText)instance).StartOutPutText();
                                //������System.IO.IOException���o���ꍇ
                                //Abord��Ԃ�
                                if (ret == -2)
                                {
                                    status = ret;
                                    this._printInfo.status = ret;
                                    this.DialogResult = DialogResult.Abort;
                                }
                                else
                                {
                                    status = ret;
                                    this._printInfo.status = ret;
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else if (instance is ICustomTextWriter)
                            {
                                //�e�L�X�g�o�̓X�L�[�}�t�@�C���p�X�ۑ�����
                                //string current = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema + "\\";
                                string _textSchema = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, this._printInfo.prpid);                               
                                                           
                                CustomTextProviderInfo customTextProviderInfo = new CustomTextProviderInfo();
                                ret = ((ICustomTextWriter)instance).MakeCustomText(this._printInfo.rdData, _textSchema,
                                    this._printInfo.outPutFilePathName, ref customTextProviderInfo);
                                status = ret;
                                this._printInfo.status = ret;
                                this.DialogResult = DialogResult.OK;   
                            }
                  
                            //status = ret;
                            //this._printInfo.status = ret;
                            //this.DialogResult = DialogResult.OK;                             
                        }
                    }
                    catch (System.IO.IOException)
                    {                      
                        status = -1;
                        this._printInfo.status = -2;
                        this.DialogResult = DialogResult.Abort;
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        status = -1;
                        this._printInfo.status = -1;
                        this.DialogResult = DialogResult.Abort; 
                    }
                }
            }
            return status;

		}

        /// <summary>
        ///	�f�t�H���g�ݒ�}�X�^���[�h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.30</br>
        /// </remarks>
        private void ReadDefaultSettings()
        {          
            int defcnt = 0;
            this.localFilePahtName  = "";
            this.localFileName      = "";
            OutputSet _defOutPutSet = new OutputSet();

            //���[�J���ݒ肠��
            if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//�Ō�̈�����"1"�͑I�����敪1�̓e�L�X�g�o�͑I��
            {
                //���[�J���ݒ肪null�̎�
                if (_defOutPutSet == null)
                {
                    defcnt = -99;
                }
                else
                {
                    defcnt = _defOutPutSet.SelectPgSequenceNo;//�v���O�����ʂ�No
                    // 2009.04.07 >>>
                    //this.localFilePahtName = _defOutPutSet.OutputFilePathName; //�o�͐�p�X
                    //this.localFileName = _defOutPutSet.OutputFileName;     //�o�̓t�@�C����
                    // �o�͐�p�X�̃f�B���N�g�������݂���ꍇ�́A���̂܂܃Z�b�g
                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_defOutPutSet.OutputFilePathName)))
                    {
                        this.localFilePahtName = _defOutPutSet.OutputFilePathName; //�o�͐�p�X
                        this.localFileName = _defOutPutSet.OutputFileName;     //�o�̓t�@�C����
                    }
                    // 2009.04.07 <<<
                }
            }
            //���[�J���ݒ�Ȃ�
            else
            {
                defcnt = -99;
            }

            int cnt = 1;
            for (int lpcnt = 0; lpcnt < wkOutPutList.Count; lpcnt++)
            {
                OutputSet myOutputSet = (OutputSet)wkOutPutList[lpcnt];

                if (((myOutputSet != null) && (myOutputSet.SelectPgSequenceNo == defcnt)) || (defcnt == -99))
                {
                    this._printInfo.frycd = myOutputSet.OutputPurpose;			    //�o�͗p�r(���R��)
                    this._printInfo.prpid = myOutputSet.OutputFormFileName;         //�t�H�[���t�@�C��ID(�X�L�[�}�t�@�C���̖��̂Ȃ�)
                    this._printInfo.prpnm = myOutputSet.DisplayName;				//�o�͖���(�������p�b�N�Ȃ�)
                    this._printInfo.printpgid = myOutputSet.OutputPgId;			    //�e�L�X�g�o�̓v���O����ID
                    this._printInfo.printclassid = myOutputSet.OutputPgClassId;	    //�e�L�X�g�o�̓N���X��
                    //2006 05/16 H.NAKAMURA ADD 
                    this._printInfo.extrapgid = myOutputSet.ExtractionPgId;           //���oPGID
                    this._printInfo.extraclassid = myOutputSet.ExtractionPgClassId;   //���o�N���X��
                    //2006/09/05 H.NAKAMURA ADD
                    //�o�͊m�F���b�Z�[�W���擾
                    this.MessageLabel.Text = myOutputSet.OutConfimationMsg;
                   

                    //���[�J���ݒ薳���A����null�̏ꍇ
                    if ((this.localFilePahtName == "") || (this.localFileName == ""))
                    {
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //Combaine�ł��Ȃ��̂Ńp�X�𑫂�                            
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //�t���p�X���쐬
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //�t���p�X�A�t�@�C�������Z�b�g
                        this._printInfo.outPutFilePathName = fullPath;                          //�o�͐�t���p�X
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);�@//�o�͐�t�@�C����
                    }
                    //���[�J���ݒ肪����ꍇ
                    else
                    {                           
                        this._printInfo.outPutFilePathName = this.localFilePahtName;            //�o�͐�t���p�X
                        this._printInfo.outPutFileName = this.localFileName;�@                  //�o�͐�t�@�C����                    
                    }

                    DispName_tComboEditor.Text = this._printInfo.prpnm;
                    break;
                }
                cnt++;
            }                               
            DispName_tComboEditor.SelectionChanged -= new EventHandler(DispName_tComboEditor_SelectionChanged);                      
            DispName_tComboEditor.SelectedIndex = cnt - 1;
            DispName_tComboEditor.SelectionChanged += new EventHandler(DispName_tComboEditor_SelectionChanged);
            //���[�J���f�[�^�������Ă���e�L�X�g��SelectIndex��ێ����Ă���
            this._ltimeSelectIndex = this.DispName_tComboEditor.SelectedIndex;
             
        }

        /// <summary>
        ///	���[�J���f�[�^�Z�b�g����
        /// </summary>
        /// <param name="mode">0:�����\���Ɠ����e�L�X�g���I�����ꂽ�ꍇ1:�����\���ȊO�̃e�L�X�g���I�����ꂽ�ꍇ</param>
        /// <param name="myOutputSet">�o�͐ݒ�}�X�^�f�[�^�N���X</param>
        /// <remarks>
        /// <br>Note	   : �o�͑Ώۃe�L�X�g���ύX���ꂽ���ɁA�e�X�ɉ��������[�J���f�[�^���Z�b�g���܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.09.02</br>
        /// </remarks>
        private void RocalDataSetting(int mode, OutputSet myOutputSet)
        {
            if (mode == 0)
            {
                //���[�J���ݒ肪����ꍇ�͕K���ǂ�    
                OutputSet _defOutPutSet = new OutputSet();
                if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//�Ō�̈�����"1"�͑I�����敪1�̓e�L�X�g�o�͑I��
                {
                    //���[�J���ݒ肪null�̎�
                    if (_defOutPutSet == null)
                    {
                        //�J�����g�f�B���N�g�����擾
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //���[�g�f�B���N�g�����擾                                              
                        //Combine�ł��Ȃ��̂Ńp�X�𑫂��܂�
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //�t���p�X���쐬
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //�t���p�X�A�t�@�C�������Z�b�g
                        this._printInfo.outPutFilePathName = fullPath;                          //�o�͐�t���p�X
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);�@//�o�͐�t�@�C����
                    }
                    else
                    {
                        this._printInfo.outPutFilePathName = _defOutPutSet.OutputFilePathName;  //�o�͐�p�X
                        this._printInfo.outPutFileName = _defOutPutSet.OutputFileName;                      //�o�̓t�@�C����
                    }
                }
                //���[�J���ݒ肪���݂��Ȃ���
                else
                {
                    //�J�����g�f�B���N�g�����擾
                    string current = System.IO.Directory.GetCurrentDirectory();
                    //���[�g�f�B���N�g�����擾                                              
                    //Combine�ł��Ȃ��̂Ńp�X�𑫂��܂�
                    string defaultPaht = current + myOutputSet.OutputFilePathName;
                    //�t���p�X���쐬
                    string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                    //�t���p�X�A�t�@�C�������Z�b�g
                    this._printInfo.outPutFilePathName = fullPath;                          //�o�͐�t���p�X
                    this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);�@//�o�͐�t�@�C����
                }

            }
            else if(mode == 1)
            {
                OutputSet _defOutPutSet = new OutputSet();
                if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//�Ō�̈�����"1"�͑I�����敪1�̓e�L�X�g�o�͑I��
                {
                    //���[�J���ݒ肪null�̎�
                    if (_defOutPutSet == null)
                    {
                        //�J�����g�f�B���N�g�����擾
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //���[�g�f�B���N�g�����擾                                              
                        //Combine�ł��Ȃ��̂Ńp�X�𑫂��܂�
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //�t���p�X���쐬
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //�t���p�X�A�t�@�C�������Z�b�g
                        this._printInfo.outPutFilePathName = fullPath;                          //�o�͐�t���p�X
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);�@//�o�͐�t�@�C����
                    }
                    else
                    {
                        //���[�J���ݒ�̃t���p�X����f�B���N�g�����擾
                        string outputDirectory = System.IO.Path.GetDirectoryName(_defOutPutSet.OutputFilePathName);
                        string fullPath = System.IO.Path.Combine(outputDirectory, myOutputSet.OutputFileName);

                        this._printInfo.outPutFilePathName = fullPath;  //�o�͐�p�X
                        //�o�̓t�@�C�����̓}�X�^�ɓo�^����Ă�����̂��g�p(�O��o�͕��̃t�@�C�����������[�J���ɂ����Ă��Ȃ���)
                        this._printInfo.outPutFileName = myOutputSet.OutputFileName;            //�o�̓t�@�C����
                    }
                }
                //���[�J���ݒ肪���݂��Ȃ���
                else
                {
                    //�J�����g�f�B���N�g�����擾
                    string current = System.IO.Directory.GetCurrentDirectory();
                    //���[�g�f�B���N�g�����擾                                              
                    //Combine�ł��Ȃ��̂Ńp�X�𑫂��܂�
                    string defaultPaht = current + myOutputSet.OutputFilePathName;
                    //�t���p�X���쐬
                    string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                    //�t���p�X�A�t�@�C�������Z�b�g
                    this._printInfo.outPutFilePathName = fullPath;                          //�o�͐�t���p�X
                    this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);�@//�o�͐�t�@�C����
                }
                
            }

        }

		#endregion

		#region �C�x���g
		/// <summary>
		///	Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2006.03.30</br>
		/// </remarks>
		private void SFCMN00391U_Load(object sender, System.EventArgs e)
		{
			ImageList imglist = IconResourceManagement.ImageList16;
			
			OKButton.ImageList			= imglist;
			OKButton.Appearance.Image	= Size16_Index.CSVOUTPUT;
			CanButton.ImageList			= imglist;
			CanButton.Appearance.Image	= Size16_Index.BEFORE;
		         
			this.DispName_tComboEditor.Items.Clear();
			this.OutPutFilePath_tEdit.Clear();

            //�㏑���pLabel�Aradio�{�^���̏�����
            //2006/09/02 H.NAKLAMURA ADD
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            ultraLabel2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;

			int status = GetPaperInfo();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //2006/09/12 H.NAKAMURA ADD
                //�s�����x��100���ɖ߂�
                this.Opacity = 100D;

                // 2009.04.07 Del >>>
                //string path = System.IO.Path.GetDirectoryName(this._printInfo.outPutFilePathName);
                ////�������[�I��ݒ�Ŏw�肳�ꂽ�t�@�C�������݂��Ȃ��ꍇ�t�@�C�����쐬����
                //if (!(System.IO.Directory.Exists(path)))
                //{                
                //    System.IO.Directory.CreateDirectory(path);
                //}
                // 2009.04.07 Del <<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._printInfo.status = -1;
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            else
            {
                this._printInfo.status = -1;
                this.DialogResult = DialogResult.Abort;
                return;
            }
           			
		}

		/// <summary>
		/// �L�����Z���{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CanButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();				
		}

		/// <summary>
		/// �o�̓{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, System.EventArgs e)
		{
            //�o�̓p�X���ύX���ꂽ���̏���
            if (this.OutPutFilePath_tEdit.Text == "")
            {
                DialogResult res = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "SFCMN00391U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�o�͐����͂��ĉ�����", 			// �\�����郁�b�Z�[�W
                    -1, 								// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                if (res == DialogResult.OK)
                {
                    return;
                }
            }

            // 2009.04.07 Add >>>
            string path = System.IO.Path.GetDirectoryName(this._printInfo.outPutFilePathName);
            //�������[�I��ݒ�Ŏw�肳�ꂽ�t�@�C�������݂��Ȃ��ꍇ�t�@�C�����쐬����
            if (!( System.IO.Directory.Exists(path) ))
            {
                try
                {
                    //�f�B���N�g���쐬����
                    //�O��o�͂����f�B���N�g�������݂��Ȃ����f�t�H���g�̏o�͐���w�肵�ċN��
                    //�f�t�H���g�̏o�͐�f�B���N�g�������݂��Ȃ����f�B���N�g���̍쐬
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,                            // �G���[���x��
                    "SFCMN00391U", 						                    // �A�Z���u���h�c�܂��̓N���X�h�c
                    ex.Message,                                             // �\�����郁�b�Z�[�W
                    0, 									                // �X�e�[�^�X�l
                    MessageBoxButtons.OK);				                    // �\������{�^��
                    this.DialogResult = DialogResult.Abort;
                    this._printInfo.status = -1;
                    this.Close();
                    return;
                }

            }
            // 2009.04.07 Add <<<

            // 2009.05.20 Add >>>
            if (this.radioButton1.Checked)
            {
                this._printInfo.overWriteFlag = false;  // �㏑������
            }
            else if (this.radioButton2.Checked)
            {
                this._printInfo.overWriteFlag = true;   // �ǉ�����
            }
            else
            {
                this._printInfo.overWriteFlag = false;  // �㏑������
            }
            // 2009.05.20 Add <<<

            //PrintMode == "0"�̎��͒��o�������s��
            if (this._PrintMode == 0)
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ���o���� 
                status = ExtraProc();

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }
                // ������� 
                int st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                st = PrtProc();

                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }
            }
           
            //�f�t�H���g�ݒ�}�X�^(PrtDefault)���X�V
            OutputSet wkOutPutset = new OutputSet();
            int selcnt = 1;
            int ret = 0;
            foreach (OutputSet mfOutputSet in wkOutPutList)
            {
                if ((mfOutputSet != null) && (selcnt == DispName_tComboEditor.SelectedIndex + 1))
                {
                    wkOutPutset = mfOutputSet.Clone();
                    //�p�X���X�V
                    wkOutPutset.OutputFilePathName = this._printInfo.outPutFilePathName;
                    wkOutPutset.OutputFileName = this._printInfo.outPutFileName;

                    ret = this._outPutSetAcs.WriteDefault(ref wkOutPutset);
                    if (ret != 0)
                    {
                        TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,                            // �G���[���x��
                        "SFCMN00391U", 						                    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�f�t�H���g�ݒ�}�X�^�X�V�����ŃG���[���������܂���",   // �\�����郁�b�Z�[�W
                        ret, 									                // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				                    // �\������{�^��
                        this.DialogResult = DialogResult.Abort;
                        this._printInfo.status = -1;
                        this.Close();
                        return;
                    }  
                    
                    // PrintInfo�̑I���v���O�����ʂ��ԍ����X�V
                    this._printInfo.SelectPgSequenceNo = wkOutPutset.SelectPgSequenceNo;                   
                }
                selcnt++;
            }

            this.DialogResult = DialogResult.OK;
            this._ltimeSelectIndex = this.DispName_tComboEditor.SelectedIndex;
			this.Close();				
		}
		

		/// <summary>
		/// �o�͐�ύX�{�^���N���b�N�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �o�͐�ύX�{�^���������ꂽ���ɏ������s���܂�</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2006.03.31</br>
		/// </remarks>
		private void OutPutChang_Button_Click(object sender, System.EventArgs e)
		{
			//SaveDialog�g�p�p�^�[��
			DialogResult ret;

			//�_�C�A���O�{�b�N�X�̏����ݒ���s��
			this.saveFileDialog1.RestoreDirectory = true;
			this.saveFileDialog1.OverwritePrompt  = false;
			//��荇�����b�r�u�̂�
            this.saveFileDialog1.Filter = "CSV�t�@�C��(*.csv)|*.csv";
                                        //+ "�e�L�X�g�t�@�C��(*.txt)|*.txt";

			//�t�@�C�������o�̓t�@�C����
            this.saveFileDialog1.FileName = System.IO.Path.GetFileName(this.fullPath_tEdit.Text);

			//�N���f�B���N�g�����t���p�X����f�B���N�g�����擾
            this.saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(this.fullPath_tEdit.Text);

			ret = saveFileDialog1.ShowDialog();

			switch(ret)
			{
				case DialogResult.OK:
				{
					string rdire = System.IO.Directory.GetDirectoryRoot(this.saveFileDialog1.FileName);
					string fullpaht = System.IO.Path.GetFullPath(this.saveFileDialog1.FileName);
					string FileName = System.IO.Path.GetFileName(this.saveFileDialog1.FileName);
					string dire     = System.IO.Path.GetDirectoryName(this.saveFileDialog1.FileName);
					//�w�肳�ꂽ�f�B���N�g�������݂��邩�H
					if(System.IO.Directory.Exists(rdire))
					{	
						//�w�肳�ꂽ�t�H���_�����݂��邩�H
						if(System.IO.Directory.Exists(dire))
						{
							//�w�肳�ꂽ�t�@�C�������݂��邩�H
							if(System.IO.File.Exists(fullpaht))
							{
								//�㏑���m�F�̃��x����\��
								ultraLabel2.Visible = true;
								radioButton1.Visible = true;
								radioButton2.Visible = true;
								radioButton1.Checked = true;
								this.OutPutFilePath_tEdit.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
								this.fullPath_tEdit.Text = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
								break;
							}
							//�t�@�C�������݂��Ȃ�
							else
							{
								//�㏑���m�F�̃��x�����\��
								ultraLabel2.Visible = false;
								radioButton1.Visible = false;
								radioButton2.Visible = false;
								this.OutPutFilePath_tEdit.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
								this.fullPath_tEdit.Text = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
								break;
							}
						}
						//�t�H���_�����݂��Ȃ�
						else
						{
							DialogResult res = TMsgDisp.Show( 
								emErrorLevel.ERR_LEVEL_INFO,                        // �G���[���x��
								"SFCMN00391U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
								"�w�肳�ꂽ�t�@�C�������݂��܂���B�쐬���܂����H", // �\�����郁�b�Z�[�W
								0, 									                // �X�e�[�^�X�l
								MessageBoxButtons.YesNo );				            // �\������{�^��
					
							//�t�H���_���쐬���܂�
							if(res == DialogResult.Yes)
							{
								System.IO.Directory.CreateDirectory(dire);
								ultraLabel2.Visible = false;
								radioButton1.Visible = false;
								radioButton2.Visible = false;
								goto case DialogResult.OK;
												
							}
							else
							{
								break;
							}
					
						}
					}
						//�f�B���N�g�������݂��Ȃ�
					else
					{
						DialogResult ress = TMsgDisp.Show( 
							emErrorLevel.ERR_LEVEL_INFO,                // �G���[���x��
							"SFCMN00391U", 						        // �A�Z���u���h�c�܂��̓N���X�h�c
							"�w�肳�ꂽ�f�B���N�g�������݂��܂���B",   // �\�����郁�b�Z�[�W
							0, 									        // �X�e�[�^�X�l
							MessageBoxButtons.OK );				        // �\������{�^��
							break;
					}
				}
				case DialogResult.Cancel:
				{
					break;
				}
			}					
            this._printInfo.outPutFileName = System.IO.Path.GetFileName(this.fullPath_tEdit.Text);
            this._printInfo.outPutFilePathName = this.fullPath_tEdit.Text;

		}

        /// <summary>
        /// �o�̓p�^�[���ύX�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�̓p�^�[�����ύX���ꂽ���ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.05.19</br>
        /// </remarks>
        private void DispName_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {         
            int selcnt = 0;
            selcnt = DispName_tComboEditor.SelectedIndex;
            selcnt++;

            int cnt = 1;
            foreach (OutputSet mfOutputSet in wkOutPutList)
            {
                if ((mfOutputSet != null) && (cnt == selcnt))
                {
                    this._printInfo.frycd = mfOutputSet.OutputPurpose;
                    this._printInfo.prpid = mfOutputSet.OutputFormFileName;
                    this._printInfo.prpnm = mfOutputSet.DisplayName;
                    this._printInfo.extrapgid = mfOutputSet.ExtractionPgId;
                    this._printInfo.extraclassid = mfOutputSet.ExtractionPgClassId;
                    this._printInfo.printpgid = mfOutputSet.OutputPgId;
                    this._printInfo.printclassid = mfOutputSet.OutputPgClassId;

                    //TODO                   
                    this._printInfo.SelectPgSequenceNo = mfOutputSet.SelectPgSequenceNo;
                    this._printInfo.PrintPaperSetCd = mfOutputSet.PrintPaperSetCd;
                
                    DispName_tComboEditor.Text = this._printInfo.prpnm;
                       
         
                    //�o�͂��s��������selectIndex�ƌ��ݑI������Ă���selectIndex�������ł���ꍇ                               
                    if (DispName_tComboEditor.SelectedIndex == this._ltimeSelectIndex)
                    {
                        RocalDataSetting(0, mfOutputSet);                    
                    }
                    else
                    {
                        RocalDataSetting(1, mfOutputSet);                                                     
                    }
                    //�e�L�X�g�ɕ\��
                    this.fullPath_tEdit.Text = this._printInfo.outPutFilePathName;
                    this.OutPutFilePath_tEdit.Text = this._printInfo.outPutFileName;       
                
                   
                    //�㏑���\��LabelVisible�ύX
                    if ((System.IO.File.Exists(this._printInfo.outPutFilePathName)))
                    {
                        ultraLabel2.Visible = true;
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        ultraLabel2.Visible = false;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton1.Checked = false;
                    }

                }
                cnt++;
            }
        }
		#endregion      
	}
}

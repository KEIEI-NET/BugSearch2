//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�ʐM���ʕ\���_�C�A���O�N���X
// �v���O�����T�v   : �t�n�d�ʐM���ʕ\���_�C�A���O�N���X������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/12/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : ���N�n��
// �� �� ��  K2013/11/27 �C�����e : Redmine41421�A�t�^�o�ʕ��@�폜�\�[�X�̃R�����g�ǉ��̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
//using Broadleaf.Application.Controller;// DEL  K2013/10/27 ���N�n�� Redmine41421
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// UOE�ʐM���ʕ\���_�C�A���O�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : UOE�ʐM���ʕ\���_�C�A���O��\�����܂��B</br>
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2008/12/13</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
	/// </remarks>
	public class UoeSndRcvResultDialog : System.Windows.Forms.Form
    {
        #region Windows�Ő������ꂽ�R�[�h(�����ǉ�)
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GUIDE01;
        private RichTextBox richText_ErrorMessage;
        private Infragistics.Win.Misc.UltraButton uButton_Print;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
		private System.ComponentModel.IContainer components = null;

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UoeSndRcvResultDialog));
            this.ultraLabel_GUIDE01 = new Infragistics.Win.Misc.UltraLabel();
            this.richText_ErrorMessage = new System.Windows.Forms.RichTextBox();
            this.uButton_Print = new Infragistics.Win.Misc.UltraButton();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraLabel_GUIDE01
            // 
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextVAlignAsString = "Middle";
            this.ultraLabel_GUIDE01.Appearance = appearance97;
            this.ultraLabel_GUIDE01.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GUIDE01.Location = new System.Drawing.Point(6, 87);
            this.ultraLabel_GUIDE01.Name = "ultraLabel_GUIDE01";
            this.ultraLabel_GUIDE01.Size = new System.Drawing.Size(313, 24);
            this.ultraLabel_GUIDE01.TabIndex = 1404;
            // 
            // richText_ErrorMessage
            // 
            this.richText_ErrorMessage.BackColor = System.Drawing.Color.White;
            this.richText_ErrorMessage.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richText_ErrorMessage.Location = new System.Drawing.Point(19, 30);
            this.richText_ErrorMessage.Name = "richText_ErrorMessage";
            this.richText_ErrorMessage.ReadOnly = true;
            this.richText_ErrorMessage.Size = new System.Drawing.Size(488, 298);
            this.richText_ErrorMessage.TabIndex = 1405;
            this.richText_ErrorMessage.Text = "������M����\n  ����G���[���������܂����B\n  �����������s���ĉ������B\n\n  �y�ʐM���ʁz\n  �g���^���i�̔�\n  ���Y���i�̔�\n\n���d���f�[�^�쐬����\n  " +
                " �d���f�[�^�쐬�G���[���������Ă��܂��B\n   �d���A���}�b�`���X�g���o�͂��ĉ������B";
            // 
            // uButton_Print
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Center";
            this.uButton_Print.Appearance = appearance3;
            this.uButton_Print.Font = new System.Drawing.Font("�l�r �S�V�b�N", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Print.Location = new System.Drawing.Point(19, 344);
            this.uButton_Print.Name = "uButton_Print";
            this.uButton_Print.Size = new System.Drawing.Size(149, 34);
            this.uButton_Print.TabIndex = 1406;
            this.uButton_Print.Text = "����G���[���X�g���";
            this.uButton_Print.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Print.Click += new System.EventHandler(this.uButton_Print_Click);
            // 
            // uButton_OK
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            this.uButton_OK.Appearance = appearance2;
            this.uButton_OK.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OK.Location = new System.Drawing.Point(408, 344);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(99, 34);
            this.uButton_OK.TabIndex = 1408;
            this.uButton_OK.Text = "�n�j";
            this.uButton_OK.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // UoeSndRcvResultDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(528, 400);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.uButton_Print);
            this.Controls.Add(this.richText_ErrorMessage);
            this.Controls.Add(this.ultraLabel_GUIDE01);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UoeSndRcvResultDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�ʐM���ʕ\��";
            this.Shown += new System.EventHandler(this.UoeSndRcvDialog_Shown);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        private List<OrderSndRcvJnl> _orderSndRcvJnlErrorList = null;   // ����MJNL�G���[���X�g(���[�󎚗p)
        private List<string> _changeColorStringList = null;             // �F�ύX���镶���񃊃X�g

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="orderSndRcvJnlErrorList">����MJNL�G���[���X�g(���[�p)</param>
        /// <param name="errorMessageList">�G���[���b�Z�[�W(��ʕ\���p)</param>
        /// <param name="changeColorStringList">�F�ύX���镶���񃊃X�g</param>
        public UoeSndRcvResultDialog(List<OrderSndRcvJnl> orderSndRcvJnlErrorList, List<string> errorMessageList, List<string> changeColorStringList)
        {
            // �e�R���|�[�l���g�����ݒ�
            InitializeComponent();

            this._orderSndRcvJnlErrorList = orderSndRcvJnlErrorList;
            this._changeColorStringList = changeColorStringList;

            // �G���[���b�Z�[�W�ݒ�
            this.SetDisplayMessage(errorMessageList);

            // �{�^���\��
            if (orderSndRcvJnlErrorList.Count == 0)
            {
                this.uButton_Print.Visible = false;
            }
            else
            {
                this.uButton_Print.Visible = true;
            }
        }
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��UoeSndRcvDialog_Shown(�t�H�[���\��)
        /// <summary>
        /// �t�H�[���\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UoeSndRcvDialog_Shown(object sender, EventArgs e)
        {
            if (this.uButton_Print.Visible == true)
            {
                this.uButton_Print.Focus();         // ����G���[���X�g���
            }
            else
            {
                this.uButton_OK.Focus();            // OK
            }
        }
        #endregion

        #region ��uButton_Print_Click(����{�^������)
        /// <summary>
        /// ����{�^������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uButton_Print_Click(object sender, EventArgs e)
        {
            PMUOE02010UA printForm = new PMUOE02010UA(this._orderSndRcvJnlErrorList);
            SFCMN06002C printInfo = new SFCMN06002C();

            Object printInfoObject = (object)printInfo;

            printForm.Print(ref printInfoObject);
        }
        #endregion

        #region ��uButton_OK_Click(OK�{�^������)
        /// <summary>
        /// OK�{�^������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this.CloseDialog();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��SetDisplayMessage(���b�Z�[�W�\��)
        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="displayMessageList">�\���p���b�Z�[�W���X�g</param>
        /// <remarks>
        /// <br>Note       : ���b�`�e�L�X�g�ɕ\���p���b�Z�[�W���X�g�̓��e��ǉ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void SetDisplayMessage(List<string> displayMessageList)
        {
            // ������
            richText_ErrorMessage.Clear();

            int length = 0;
            for (int i = 0; i <= displayMessageList.Count - 1; i++)
            {
                string text = displayMessageList[i] + Environment.NewLine;      //���s��t��

                // �F�̕ύX
                richText_ErrorMessage.SelectionColor = this.SelectionTextColor(displayMessageList[i]);

                // �������ǉ�
                richText_ErrorMessage.AppendText(text);
                length = length + text.Length + 1;
            }
        }
        #endregion

        #region ��SelectionTextColor(���b�Z�[�W�F�ݒ�)
        /// <summary>
        /// ���b�Z�[�W�̐F�ݒ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : _changeColorStringList���ɂ��郁�b�Z�[�W�̐F��ԂɕύX���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private Color SelectionTextColor(string text)
        {
            if (this._changeColorStringList.Contains(text))
            {
                return Color.Red;
            }
            else
            {
                return Color.Black;
            }
        }
        # endregion

        # region ����ʃN���[�Y������
        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        public void CloseDialog()
        {
            this.Close();
        }

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
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
        # endregion
    }
}

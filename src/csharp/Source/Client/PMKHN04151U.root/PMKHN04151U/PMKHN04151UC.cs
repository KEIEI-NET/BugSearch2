//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\���ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���[�����M����\��
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/06/01  �C�����e : Redmine#8919�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�����e�\���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����e�\�����s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br>Update Note :2010/06/01 ������ Redmine#8919�Ή�</br>
    /// </remarks>
    public partial class PMKHN04151UC : Form
    { 

        /// <summary>�C���[�W���X�g</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>���[�����M����\�� �f�[�^�N���X</summary>
        /// <remarks></remarks> 
        private QrMailHist _qrMailHist = null;

        #region �� Constroctors
        /// <summary>
        /// ���[�����e�\���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <param name="qrMailHist">���[�����e�\��</param>
        /// <br>Note       : ���[�����e�\���N���X�R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UC(QrMailHist qrMailHist)
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            _qrMailHist = qrMailHist;
        }
        #endregion

        #region �� event
        /// <summary>
        /// �R���g���[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// <br>Update Note :2010/06/01 ������ Redmine#8919�Ή�</br>
        /// </remarks>
        private void PMKHN04151UC_Load(object sender, EventArgs e)
        {
            // ����{�^��
            this.UltraButton_Close.ImageList = this._imageList16;
            this.UltraButton_Close.Appearance.Image =(int)Size16_Index.CLOSE;
            
            #region txt
            this.UltraLabel_Address.Text = _qrMailHist.EmployeeName;
            this.toolTip1.SetToolTip(this.UltraLabel_Address, _qrMailHist.EmployeeName);
            this.UltraLabel_CC.Text = _qrMailHist.CCInfo;
            this.toolTip1.SetToolTip(this.UltraLabel_CC, _qrMailHist.CCInfo);
            this.UltraLabel_SendingDate.Text = _qrMailHist.TransmitDate;
            this.toolTip1.SetToolTip(this.UltraLabel_SendingDate, _qrMailHist.TransmitDate);
            this.UltraLabel_FileName.Text = _qrMailHist.Title;
            this.toolTip1.SetToolTip(this.UltraLabel_FileName, _qrMailHist.Title);
            this.textBox1.Text = _qrMailHist.MailText;

            // ��������QR�R�[�h�t�@�C�������󔒂̏ꍇ�́AQR�R�[�h���ڂ��̂��̂��\���Ƃ���
            if (string.IsNullOrEmpty(_qrMailHist.QRCode))
            {
                this.Panel_QrCd.Visible = false;
                //this.Panel_Mail_Header.Size = new System.Drawing.Size(760, 97);// DEL 2010/06/01
                this.Panel_Mail_Header.Size = new System.Drawing.Size(592, 97);// ADD 2010/06/01
            }
            else
            {
                this.Panel_QrCd.Visible = true;
                //this.Panel_Mail_Header.Size = new System.Drawing.Size(760, 113);// DEL 2010/06/01
                this.Panel_Mail_Header.Size = new System.Drawing.Size(592, 113);// ADD 2010/06/01
                this.UltraLabel_QrCd.Text = _qrMailHist.QRCode;
                this.toolTip1.SetToolTip(this.UltraLabel_QrCd, _qrMailHist.QRCode);
            }
            #endregion
        }

        /// <summary>
        /// UltraButton_Close_Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : UltraButton_Close_Click�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void UltraButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
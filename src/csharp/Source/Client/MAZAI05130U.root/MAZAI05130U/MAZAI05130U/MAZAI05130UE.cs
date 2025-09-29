//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �I������
// �v���O�����T�v   : �I�����͕i�Ԍ�����ʃN���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00  �쐬�S�� : ��
// �� �� ��  2015/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00  �쐬�S�� : �͌��с@�ꐶ
// �C �� ��  2015/05/25  �C�����e : Redmine#45746 
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�E�i�Ԍ�����ʂ̊m��{�^�����폜
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�E�i�Ԍ�����ʂ̏I���{�^��(ALT+X)��߂�{�^��(F11)�ɕύX
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinToolbars;
using System.Collections;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �I�����͕i�Ԍ�����ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Programer  : ��</br>
    /// <br>Note       : �i�Ԍ������s���N���X�ł�</br>
    /// <br>Date       : 2015/04/28</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/28 �i�Ԍ�����ǉ�</br>
    /// </remarks>
    public partial class MAZAI05130UE : Form
    {
        #region Constructor
        /// <summary>
        /// �I�����͕i�Ԍ�����ʃN���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Programer	: ��</br>
        /// <br>Note		: �I�����͕i�Ԍ�����ʃN���X�̃C���X�^���X�����������܂�</br>
        /// <br>Date        : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�    : 11070149-00 2015/04/28 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        public MAZAI05130UE()
        {
            InitializeComponent(); // �I�����͕i�Ԍ�����ʏ�����
            this.tEdit_GoodsNo.Focus(); // �t�H�[�J�X���Z�b�g
        }
        #endregion

        #region PrivateMember
        #endregion

        #region PublicMethod
        private UltraGrid _tempUltraGrid;�@// ����ʂ�Grid�f�[�^

        /// <summary>
        /// ����ʂ�Grid�f�[�^
        /// </summary>
        public UltraGrid UltraGrid
        {
            get { return _tempUltraGrid; }
            set { _tempUltraGrid = value; }
        }

        /// <summary>
        /// ��ʋN������
        /// </summary>
        /// <remarks>
        /// <br>Programer  : ��</br>
        /// <br>Note       : ���������ɉ�ʂ̋N�����s���܂�</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/28 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        public void ShowEditor()
        {
            this.timer1.Enabled = true;
            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ菈�����s���܂�</br>
        /// <br>Programer  : ��</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/27 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            this.tEdit_GoodsNo.Clear(); // �i�Ԍ������̓N���A
        }
        #endregion

        #region Event

        #region FormLoad

        /// <summary>
        /// Active�s����
        /// </summary>
        /// <param name="startNo">�J�n�ԍ�</param>
        /// <param name="endNo">�I���ԍ�</param>
        private bool FindActiveRowByGoodsNo(int startNo, int endNo)
        {
            bool dataFind = false;�@// �i�Ԍ����t���O�iTRUE: �����i�Ԃ�����@FALSE:�����i�Ԃ��Ȃ��j
            UltraGridRow[] rows = this.UltraGrid.Rows.GetFilteredInNonGroupByRows();
            for (int i = startNo; i < endNo; i++)
            {
                if (rows[i].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().StartsWith(tEdit_GoodsNo.Text))
                {
                    // Active�s�ݒ菈�����s��
                    rows[i].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                    // �����i�Ԃ�����
                    dataFind = true;
                    break;
                }
            }
            return dataFind;
        }

        /// <summary>
        /// Form.Load �C�x���g (MAZAI05130UDA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������߂ĕ\������钼�O�ɔ������܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/27 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        private void MAZAI05130UDA_Load(object sender, EventArgs e)
        {
            this.tEdit_GoodsNo.Focus(); // �t�H�[�J�X�ݒ�
        }

        /// <summary>
        /// �i�Ԍ����m�F
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�Ԍ����m�F�̃N���b�N�C�x���g</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/28 �i�Ԍ����m�F��ǉ�����</br>
        /// </remarks>
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // �i�Ԍ����m�F
            this.tEdit_GoodsNo.Focus(); //�t�H�[�J�X�ݒ�
            bool dataFind = false; // �i�Ԍ����Ȃ�
            int activerow = -1; // Active�s������

            // �i�ԓ��͂̓k���̏ꍇ�A������x����
            if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText.TrimEnd()))
            {
                return;
            }
            UltraGridRow[] rows = this.UltraGrid.Rows.GetFilteredInNonGroupByRows();

            if (UltraGrid.ActiveCell == null)
            {
                // ���s���猟��
                dataFind = FindActiveRowByGoodsNo(0, rows.Length);
            }
            else
            {
                // Active�s�ԍ�
                for (int i = 0; i < rows.Length; i++)
                {
                    if (UltraGrid.ActiveRow.Index == rows[i].Index)
                    {
                        activerow = i;�@// Active�s�ԍ�
                        break;
                    }
                }

                // �f�[�^���Ȃ�
                if (activerow == -1)
                {
                    // ���s���猟��
                    dataFind = FindActiveRowByGoodsNo(0, rows.Length);
                }
                else
                {

                    // Active�s�ȉ��i�Ԍ���
                    dataFind = FindActiveRowByGoodsNo(activerow + 1, rows.Length);

                    // Active�s�ȏ�i�Ԍ���
                    if (dataFind == false)
                    {
                        dataFind = FindActiveRowByGoodsNo(0, activerow + 1);
                    }
                }
            }

            // �i�Ԍ����Ȃ��ꍇ�A�G���[���b�Z�[�W��\������
            if (dataFind == false)
            {
                this.MsgDispProc("�Y������f�[�^������܂���B", emErrorLevel.ERR_LEVEL_INFO);
            }
        }

        /// <summary>
        /// �i�Ԍ����ւ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�Ԍ����ւ���̃N���b�N�C�x���g</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/28 �i�Ԍ����ւ����ǉ�����</br>
        /// </remarks>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // �i�Ԍ����ւ���
            this.DialogResult = DialogResult.Cancel;   // �i�Ԍ����L�����Z��
            this.Close();              // �i�Ԍ�����ʕ���
        }
        #endregion

        /// <summary>
        /// �i�ԃt�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Note       : �i�ԃt�H�[�J�X���Z�b�g����</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2015/04/28</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tEdit_GoodsNo.Focus();     // �i�ԃt�H�[�J�X�ݒ�
            this.timer1.Enabled = false;
        }
        #endregion

        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                switch (e.Key)
                {
                    // Enter �L�[�̏���
                    case Keys.Enter:
                        switch (e.PrevCtrl.Name)
                        {
                            case "tEdit_GoodsNo":
                                // ��ʕ���
                                this.ConfirmButton_Click(null, null);

                                // Enter�L�[���������ꍇ�A�t�H�[�J�X�ړ��ł��Ȃ��B
                                e.NextCtrl = this.tEdit_GoodsNo;
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        ///  �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MAZAI05130UE_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)                         // --- DEL �͌��с@�ꐶ 2015/05/25 Redmine#45746
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F11)  // --- ADD �͌��с@�ꐶ 2015/05/25 Redmine#45746 
            {
                // �i�Ԍ�����ʕ���
                this.Close();
            }
        }

        #region �� ���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string message, emErrorLevel iLevel)
        {
            // ���b�Z�[�W�\��
            return TMsgDisp.Show(
                this,                            // �e�E�B���h�E�t�H�[��
                iLevel,                             // �G���[���x��
                this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
                message,                            // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);             // �\������{�^��
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="msg">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="proc">���������\�b�hID</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <remarks>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, emErrorLevel iLevel)
        {
            return TMsgDisp.Show(
                iLevel,						        //�G���[���x��
                "MAZAI05130UE",                      //UNIT�@ID
                "�I������",                            //�v���O��������
                proc,                               //�v���Z�XID
                "",                                 //�I�y���[�V����
                msg,                                //���b�Z�[�W
                status,                             //�X�e�[�^�X
                null,                               //�I�u�W�F�N�g
                MessageBoxButtons.OK,               //�_�C�A���O�{�^���w��
                MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
                );
        }

        /// <summary>
        /// �G���[MSG�\������(Exception)
        /// </summary>
        /// <param name="msg">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="proc">���������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <remarks>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, Exception ex, emErrorLevel iLevel)
        {
            return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���㑬��\�� �ݒ�UI
    /// </summary>
    ///<remarks>
    /// <br>Note        : ���㑬��\�� �ݒ�UI�t�H�[���N���X</br>
    /// <br>Programmer  : 30418 ���i</br>
    /// <br>Date        : 2008/11/21</br>
    /// </remarks>
    public partial class PMHNB04151UB : Form
    {
        #region �R���X�g���N�^

        public PMHNB04151UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �����t�H�[�J�X�p
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04151UB_Shown(object sender, System.EventArgs e)
        {
            // 2008.12.01 add start [8494]
            this.uComboEditor_StartupSearch.Focus();
            // 2008.12.01 add end [8494]
        }

        /// <summary>
        /// ���[�h���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04151UB_Load(object sender, System.EventArgs e)
        {
            //if (this._alreadySetup)
            //{
            // �N��������
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_StartupSearch.Items)
            {
                if ((int)item.DataValue == this._startupSearch)
                {
                    this.uComboEditor_StartupSearch.SelectedItem = item;
                    this.uComboEditor_StartupSearch.Text = item.DisplayText;
                }
            }

            // �����X�V
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_AutoUpdate.Items)
            {
                if ((int)item.DataValue == this._autoUpdate)
                {
                    this.uComboEditor_AutoUpdate.SelectedItem = item;
                    this.uComboEditor_AutoUpdate.Text = item.DisplayText;
                }
            }

            // �������_
            foreach (Infragistics.Win.ValueListItem item in this.uComboEditor_DefaultSecCode.Items)
            {
                if ((int)item.DataValue == this._initialSectionCode)
                {
                    this.uComboEditor_DefaultSecCode.SelectedItem = item;
                    this.uComboEditor_DefaultSecCode.Text = item.DisplayText;
                }
            }
            //}
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�ϐ�

        /// <summary>�ݒ肪�s���Ă��邩�ǂ���</summary>
        private bool _alreadySetup = false;

        /// <summary>�N�����̒��o</summary>
        private int _startupSearch = 0;

        /// <summary>�����X�V</summary>
        private int _autoUpdate = 0;

        /// <summary>���_�̏����l</summary>
        private int _initialSectionCode = 0;

        /// <summary>�ݒ�ۑ��t�@�C����</summary>
        private string _xmlFileName = string.Empty;

        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        /// <summary>�ݒ肪�s���Ă��邩�ǂ���</summary>
        public bool AlreadySetup
        {
            get { return this._alreadySetup; }
            set { this._alreadySetup = value; }
        }

        /// <summary>�N�����̒��o</summary>
        public int StartupSearch
        {
            get { return this._startupSearch; }
            set { this._startupSearch = value; }
        }

        /// <summary>�����X�V</summary>
        public int AutoUpdate
        {
            get { return this._autoUpdate; }
            set { this._autoUpdate = value; }
        }

        /// <summary>���_�̏����l</summary>
        public int InitialSectionCode
        {
            get { return this._initialSectionCode; }
            set { this._initialSectionCode = value; }
        }

        /// <summary>�ݒ�ۑ��t�@�C����</summary>
        public string XmlFileName
        {
            get { return this._xmlFileName; }
            set { this._xmlFileName = value; }
        }

        #endregion // �v���p�e�B

        #region �R���g���[�����\�b�h

        /// <summary>
        /// OK�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this.AlreadySetup = true;
            this.AutoUpdate = (int)this.uComboEditor_AutoUpdate.SelectedItem.DataValue;
            this.StartupSearch = (int)this.uComboEditor_StartupSearch.SelectedItem.DataValue;
            this.InitialSectionCode = (int)this.uComboEditor_DefaultSecCode.SelectedItem.DataValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 2008.12.01 add start [8494]
        /// <summary>
        /// �L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------

                #region �N�����̒��o
                case "uComboEditor_StartupSearch":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uComboEditor_AutoUpdate;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �N�����̒��o

                #region �����X�V
                case "uComboEditor_AutoUpdate":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_StartupSearch;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �����X�V

                #region ���_�̏����l
                case "uComboEditor_DefaultSecCode":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.uButton_OK;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_AutoUpdate;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�̏����l

                #region OK�{�^��
                case "uButton_OK":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uButton_Cancel;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // OK�{�^��

                #region �L�����Z���{�^��
                case "uButton_Cancel":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.uComboEditor_DefaultSecCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // �L�����Z���{�^��

                default: break;

            }
        }

        /// <summary>
        /// ���ڕҏW�𖳌���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_StartupSearch_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_StartupSearch.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_StartupSearch.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // �ҏW����Ă�����߂�
            if (!found)
            {
                this.uComboEditor_StartupSearch.SelectedItem = this.uComboEditor_StartupSearch.Items[0];
            }
        }

        /// <summary>
        /// ���ڕҏW�𖳌���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_AutoUpdate_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_AutoUpdate.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_AutoUpdate.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // �ҏW����Ă�����߂�
            if (!found)
            {
                this.uComboEditor_AutoUpdate.SelectedItem = this.uComboEditor_AutoUpdate.Items[1];
            }
        }

        /// <summary>
        /// ���ڕҏW�𖳌���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_DefaultSecCode_Leave(object sender, EventArgs e)
        {
            bool found = false;
            string uitext = this.uComboEditor_DefaultSecCode.Text.Trim();
            foreach (Infragistics.Win.ValueListItem v in this.uComboEditor_DefaultSecCode.Items)
            {
                if (v.DisplayText.Equals(uitext))
                {
                    found = true;
                }
            }

            // �ҏW����Ă�����߂�
            if (!found)
            {
                this.uComboEditor_DefaultSecCode.SelectedItem = this.uComboEditor_DefaultSecCode.Items[0];
            }
        }


        // 2008.12.01 add end [8494]

        #endregion // �R���g���[�����\�b�h

    }
}
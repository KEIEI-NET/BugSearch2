using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����ݒ��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ����ݒ��ʂ��s���܂��B</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/05/17</br>
    /// </remarks>
    public partial class SFCMN00293UE : Form
    {
        #region Constructor
        /// <summary>
        /// ����ݒ��ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public SFCMN00293UE()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Members
        private int _maxPageCount;  //����ݒ��ʂ̍ő�y�[�W��
        private int _curPageCount;  //����ݒ��ʂ̓��O�y�[�W��
        private int _pageCount;     //����y�[�W��
        private ArrayList _selectPageList;//�I�������y�[�W���X�g
      
        private DialogResult _dialogRes = DialogResult.No;   �@// �_�C�A���O���U���g

        private int _fromPageBe = 0; //�y�[�W�O��lfrom
        private int _toPageBe = 0;   //�y�[�W�O��lto
        #endregion

        # region Properties
        /// <summary>
        /// �I�����ꂽ�y�[�W�̎擾
        /// </summary>
        /// <returns>�I�����ꂽ�y�[�W</returns>
        /// <remarks>
        /// <br>Note       : �I�����ꂽ�y�[�W���擾���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public ArrayList SelectPageList
        {
            get { return _selectPageList; }
            set { this._selectPageList = value; }
        }
        # endregion

        #region Public Methods
        /// <summary>
        /// ����ݒ��ʋN��
        /// </summary>
        /// <param name="owner">owner</param>
        /// <param name="pageCount">�y�[�W��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public DialogResult Show(IWin32Window owner, int pageCount)
        {
            _pageCount = pageCount;

            this._fromPageBe = 1;
            this._toPageBe = pageCount;

            this._selectPageList = new ArrayList();

            DialogResult dr = base.ShowDialog(owner);
            return _dialogRes;
        }
        #endregion

        #region Private Members
        /// <summary>
        /// checkbox����
        /// </summary>
        /// <remarks>
        /// <br>Note       : checkbox������s���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void pageChkEnable()
        {
            int maxCount = 0;
            int tempCount = 0;
            if (this._curPageCount != this._maxPageCount)
            {
                maxCount = 100;
            }
            else
            {
                tempCount = _pageCount % 100;
                if (tempCount != 0)
                {
                maxCount = _pageCount % 100;
            }
                else
                {
                    maxCount = 100;
                }
            }

            string name = string.Empty;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_" + i;
                //�y�[�W�\������
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                if (i > maxCount)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }
        }

        /// <summary>
        /// �I�������y�[�W���X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�������y�[�W���X��ݒ肷��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setSelectPageList()
        {
            for (int i = 0; i < _pageCount; i++)
            {
                // �S�ăy�[�W ��I�������y�[�W���X�g�ɐݒ肷��
                if (!this._selectPageList.Contains(i))
                {
                    this._selectPageList.Add(i);
                }
            }
        }

        /// <summary>
        /// checkbox�I�𐧌�
        /// </summary>
        /// <remarks>
        /// <br>Note       : checkbox�I�𐧌���s���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void pageChkChecked(bool checkFlag)
        {
            string name = string.Empty;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_" + i;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                if( control.Visible)
                {
                    control.Checked = checkFlag;
                }
            }
        }

        /// <summary>
        /// ��ʑI����ԏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʑI����ԏ��������s���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageChecked()
        {
            string name = string.Empty;
            int pageFrom = (this._curPageCount - 1) * 100;//���O�y�[�W���͈�from
            int pageTo = this._curPageCount * 100;        //���O�y�[�W���͈�to

            for (int i = pageFrom; i < pageTo; i++)
            {
                int index = i - (this._curPageCount - 1) * 100 + 1;
                name = "ultraCheckEditor_" + index;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                if (this._selectPageList.Contains(i))
                {
                    control.Checked = true;
                }
                else
                {
                    control.Checked = false;
                }
            }
        }

        /// <summary>
        /// ��ʕ\�����̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʕ\�����̂�ݒ肵�܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageCheckNm()
        {
            string name = string.Empty;
            int index = (this._curPageCount - 1) * 100;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_"+ i;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                int temp = index + i;
                control.Text = temp.ToString();
            }
        }

        /// <summary>
        /// ��ʕ\�����̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʕ\�����̂�ݒ肵�܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageBtnEnable()
        {
            //�O�y�[�W�{�^������̐ݒ�
            if (this._curPageCount == 1)
            {
                this.uButton_prePage.Enabled = false;
            }
            else
            {
                this.uButton_prePage.Enabled = true;
            }
            //��y�[�W�{�^������̐ݒ�
            if (this._curPageCount != _maxPageCount)
            {
                this.uButton_nextPage.Enabled = true;
            }
            else
            {
                this.uButton_nextPage.Enabled = false;
            }
        }

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        internal DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "SFCMN00293U", iMsg, iSt, iButton, iDefButton);
        }

        #endregion

        #region Control Event
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00293UE_Load(object sender, EventArgs e)
        {
            int tempCount = 0;
            tempCount = _pageCount % 100;

            if (tempCount != 0)
            {
            // ����ݒ��ʂ̍ő�y�[�W���̐ݒ�
            this._maxPageCount = _pageCount / 100 + 1;
            }
            else
            {
                // ����ݒ��ʂ̍ő�y�[�W���̐ݒ�
                this._maxPageCount = _pageCount / 100;
            }

            // ����ݒ��ʂ̓��O�y�[�W���̐ݒ�
            this._curPageCount = 1;
            // �O�y�[�W�{�^�������
            this.uButton_prePage.Enabled = false;
            // ��y�[�W�{�^������
            if (this._maxPageCount > 1)
            {
                this.uButton_nextPage.Enabled = true;
            }
            else
            {
                this.uButton_nextPage.Enabled = false;
            }
            // �y�[�W����
            this.pageChkEnable();

            // �S���y�[�W��I������
            this.setSelectPageList();

            // ��ʑI����Ԑ���
            this.setPageChecked();

                //�w��y�[�WFROM
            this.tNedit_pageFrom.SetInt(1);
                //�w��y�[�WTO
            this.tNedit_pageTo.SetInt(this._pageCount);
        }

        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // checkbox�Ή������y�[�W�����擾����
            string name = ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Name;
            string[] nameTemp = name.Split('_');
            int value = Int32.Parse(nameTemp[1]);
            if (value == 00)
            {
                value = _curPageCount * 100 - 1;
            }
            else
            {
                value += (_curPageCount - 1) * 100 - 1;
            }

            //�I�����ꂽ�y�[�W���u�I�������y�[�W���X�g�v�ɐݒ肷��
            if (((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Checked)
            {
                if (!this._selectPageList.Contains(value))
                {
                    this._selectPageList.Add(value);
                }
            }
            else
            {
                //�I�����Ȃ��y�[�W���u�I�������y�[�W���X�g�v����폜����
                if (this._selectPageList.Contains(value))
                {
                    this._selectPageList.Remove(value);
                }
            }
        }

        /// <summary>
        /// �L�����Z���{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_cancle_Click(object sender, EventArgs e)
        {
            //��ʂ����
            this.Close();
        }

        /// <summary>
        /// �ݒ�{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_set_Click(object sender, EventArgs e)
        {
            //��ʏ��ݒ�A��ʂ����
            if (this._selectPageList != null && this._selectPageList.Count != 0)
            {
                this._dialogRes = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "����y�[�W���I������Ă��܂���B",
                                           0,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// �S�I���{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SelectAll_Click(object sender, EventArgs e)
        {
            // ��ʂɑS�č��ڂ��I�������̏�Ԃ�ݒ肷��
            this.pageChkChecked(true);

            this.tNedit_pageTo.SetInt(this._pageCount);
            this.tNedit_pageFrom.SetInt(1);
            this._fromPageBe = 1;
            this._toPageBe = this._pageCount;

            //�u�I�������y�[�W���X�g�v��ݒ肷��
            this.setSelectPageList();
        }

        /// <summary>
        /// �S�����{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_UnSelect_Click(object sender, EventArgs e)
        {
            // ��ʂɑS�č��ڂ��I�����Ȃ��̏�Ԃ�ݒ肷��
            this.pageChkChecked(false);

            this.tNedit_pageTo.SetInt(0);
            this.tNedit_pageFrom.SetInt(0);

            this._fromPageBe = 0;
            this._toPageBe = 0;
            //�u�I�������y�[�W���X�g�v���N���A����
            this._selectPageList.Clear();
        }

        /// <summary>
        /// �O�y�[�W�{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_prePage_Click(object sender, EventArgs e)
        {
            // ���O�y�[�W���̐ݒ�
            if (this._curPageCount > 1)
            {
                this._curPageCount -= 1;
            }

            // ��ʕ\���Đݒ�
            this.setPageCheckNm();
            this.setPageChecked();
            this.pageChkEnable();

            // �y�[�W�J�ڃ{�^������
            this.setPageBtnEnable();
        }
        
        /// <summary>
        /// ��y�[�W�{�^���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_nextPage_Click(object sender, EventArgs e)
        {
            // ���O�y�[�W���̐ݒ�
            if (this._curPageCount < _maxPageCount)
            {
                this._curPageCount += 1;
            }

            // ��ʕ\���Đݒ�
            this.setPageCheckNm();
            this.setPageChecked();
            this.pageChkEnable();
            // �y�[�W�J�ڃ{�^������
            this.setPageBtnEnable();
        }

        /// <summary>
        /// closing�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00293UE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._dialogRes != DialogResult.OK)
            {
                this._dialogRes = DialogResult.Cancel;

                //�S���y�[�W��ݒ肷��
                this._selectPageList.Clear();
                this.setSelectPageList();
            }
        }

        /// <summary>
        /// MouseUp�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraCheckEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            //�w��y�[�W�ɋ󔒂�ݒ肷��
            this.tNedit_pageFrom.SetInt(0);
            this.tNedit_pageTo.SetInt(0);

            this._toPageBe = 0;
            this._fromPageBe = 0;
        }

        /// <summary>
        /// KeyUp�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraCheckEditor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        //�w��y�[�W�ɋ󔒂�ݒ肷��
                        this.tNedit_pageFrom.SetInt(0);
                        this.tNedit_pageTo.SetInt(0);

                        this._toPageBe = 0;
                        this._fromPageBe = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                #region �w��y�[�WFrom
                case "tNedit_pageFrom":
                    {
                        //�w��y�[�W�͈͂̎擾
                        int pageFrom = this.tNedit_pageFrom.GetInt();
                        int pageTo = this.tNedit_pageTo.GetInt();
                        if (!(pageTo == 0 && pageFrom == 0))
                        {
                            // ���̓`�F�b�N
                            if (pageFrom > this._pageCount
                                || (pageFrom > pageTo
                                && (pageTo != 0)))
                            {
                                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "����������͈͂�ݒ肵�Ă��������B",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                e.NextCtrl = this.tNedit_pageFrom;
                                return;
                            }
                            //�w��y�[�Wfrom�ݒ肵�Ȃ��̏ꍇ�F�P��ݒ肷��
                            if (pageFrom == 0)
                            {
                                pageFrom = 1;
                            }
                            //�w��y�[�WTo�ݒ肵�Ȃ��̏ꍇ�F�ő�y�[�W��ݒ肷��
                            if (pageTo == 0 && pageFrom != 0)
                            {
                                pageTo = this._pageCount;
                            }

                            if (this._fromPageBe != pageFrom)
                            {
                                //�I�����ꂽ�y�[�W��ݒ肷��
                                this._selectPageList.Clear();
                                for (int i = pageFrom; i <= pageTo; i++)
                                {
                                    this._selectPageList.Add(i - 1);
                                }
                                //��ʑI����ԕύX
                                this.setPageChecked();

                                this._fromPageBe = pageFrom;
                            }
                        }
                        else
                        {
                            this._fromPageBe = 0;
                        }
                        break;
                    }
                #endregion

                #region �w��y�[�WTo
                case "tNedit_pageTo":
                    {
                        //�w��y�[�W�͈͂̎擾
                        int pageFrom = this.tNedit_pageFrom.GetInt();
                        int pageTo = this.tNedit_pageTo.GetInt();

                        if (!(pageTo == 0 && pageFrom == 0))
                        {
                            // ���̓`�F�b�N
                            if (pageTo > this._pageCount
                                || (pageFrom > pageTo
                                && (pageTo != 0)))
                            {
                                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "����������͈͂�ݒ肵�Ă��������B",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                e.NextCtrl = this.tNedit_pageTo;
                                return;
                            }
                            //�w��y�[�Wfrom�ݒ肵�Ȃ��̏ꍇ�F�P��ݒ肷��
                            if (pageFrom == 0)
                            {
                                pageFrom = 1;
                            }
                            //�w��y�[�WTo�ݒ肵�Ȃ��̏ꍇ�F�ő�y�[�W��ݒ肷��
                            if (pageTo == 0 && pageFrom != 0)
                            {
                                pageTo = this._pageCount;
                            }

                            if (this._toPageBe != pageTo)
                            {
                                //�I�����ꂽ�y�[�W��ݒ肷��
                                this._selectPageList.Clear();
                                for (int i = pageFrom; i <= pageTo; i++)
                                {
                                    this._selectPageList.Add(i - 1);
                                }
                                //��ʑI����ԕύX
                                this.setPageChecked();

                                this._toPageBe = pageTo;
                            }
                        }
                        else
                        {
                            this._toPageBe = 0;
                        }
                        break;
                    }
                    #endregion
            }
        }
        #endregion
    }
}
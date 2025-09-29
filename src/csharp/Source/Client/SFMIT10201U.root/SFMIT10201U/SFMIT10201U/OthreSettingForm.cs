using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinToolTip;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���̑��ݒ���
    /// </summary>
    public partial class OthreSettingForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public OthreSettingForm()
        {
            InitializeComponent();
            this._enterpirseCode = "";
            this._sectionList = new List<Propose_Para_Section>();
            this._saveFlag = false;
            this._TBOServiceACS = new TBOServiceACS();
            this._settingsDic = new Dictionary<string, Settings>();
        }
        #endregion

        #region const
        private const string CT_ASSEMBLYID = "SFMIT1201U";

        private readonly string CT_INFOMATION = "�u�ʒm����v�ɐݒ肵���ꍇ�A��ď��i�o�^��ʂɁu�݌ɏ�ԁv�񂪒ǉ�����" + Environment.NewLine +
                                             " �ݒ肵���u�݌ɏ�ԁv�������H�ꑤ�֒ʒm����܂��B" + Environment.NewLine +
                                             " ���ʒm�������e�͂����܂Œ�ď��i�o�^���̍݌ɏ�ԂƂȂ�܂��̂�" + Environment.NewLine +
                                             "�@ �u�ʒm����v�ɂĉ^�p���s����ꍇ�͒���I�ɍ݌ɏ�Ԃ̃����e�i���X���s���ĉ������B";

        #endregion

        #region �����o

        /// <summary>
        /// ����ݒ�f�B�N�V���i��
        /// </summary>
        public Dictionary<string, Settings> _settingsDic;

        /// <summary>���_�I��l</summary>
        private string _selectValue;

        #region �N���p�����[�^

        // ��ƃR�[�h
        public string _enterpirseCode;

        // ���_�R�[�h
        public string _sectionCode;

        // ���_���X�g
        public List<Propose_Para_Section> _sectionList;

        // TBO�A�N�Z�X�N���X
        private TBOServiceACS _TBOServiceACS;

        #endregion

        #region ���ʃp�����[�^

        // �f�[�^�X�V�t���O
        public bool _saveFlag;

        #endregion

        #endregion

        #region Public

        /// <summary>
        /// �N������
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowOtherSettinfForm()
        {
            //int st = 0;
            //string errMsg = "";

            // �c�[���`�b�v
            UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
            ultraToolTipInfo.ToolTipText = CT_INFOMATION;
            this.ultraToolTipManager1.SetUltraToolTip(this.info_pictureBox, ultraToolTipInfo);

            //this.Size = new Size(540, 186);

            // ���_
            // ����������̂����̂܂܃Z�b�g
            foreach (Propose_Para_Section section in _sectionList)
            {
        		this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
            }

            // �݌ɒʒm
            this.StockInfo_tComboEditor.Items.Add(0,"�ʒm���Ȃ�");
            this.StockInfo_tComboEditor.Items.Add(1,"�ʒm����");

            // �ݒ�f�[�^�擾
            //List<Settings> retList = new List<Settings>();
            //st = this._TBOServiceACS.GetSettings(this._enterpirseCode, out retList, out errMsg);
            //if (st == 0)
            //{
            //    foreach (Settings setting in retList)
            //    {
            //        if (!this._settingsDic.ContainsKey(setting.sectionCode))
            //        {
            //            this._settingsDic.Add(setting.sectionCode, setting);
            //        }
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //    this,							    // �e�E�B���h�E�t�H�[��
            //    emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
            //    CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
            //    "����ݒ�̎擾�Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W 
            //    st,								    // �X�e�[�^�X�l
            //    MessageBoxButtons.OK);			    // �\������{�^��
            //    return DialogResult.Cancel;
            //}

            // 
            this.Section_ComboEditor.Value = this._selectValue = this._sectionCode;

            // ��ʍ\�z
            this.DispSetting();

            // �C�x���g�Z�b�g
            this.Section_ComboEditor.ValueChanged += new EventHandler(Section_ComboEditor_ValueChanged);

            return this.ShowDialog();
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        private void DispSetting()
        {
            // ������
            this.StockInfo_tComboEditor.SelectedIndex = 0;

            // �f�[�^�����݂��邩�m�F
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                // �f�[�^�L
                this.StockInfo_tComboEditor.Value = this._settingsDic[this.Section_ComboEditor.Value.ToString()].stockDisplayFlag ? 1 : 0;
            }
            else
            {
                // �f�[�^��
                this.StockInfo_tComboEditor.Value = 0;
            }
        }

        #endregion

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.SaveProc();
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // �ۑ��Ώۃf�[�^�쐬
            Settings settings = new Settings();
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                // �X�V
                settings = (this._settingsDic[this.Section_ComboEditor.Value.ToString()].Clone());
            }
            else
            {
                // �V�K
                settings.enterpriseCode = this._enterpirseCode;
                settings.inquiryUseFlag = false;
                settings.releaseDateDisplayFlag = false;
                settings.sectionCode = this.Section_ComboEditor.Value.ToString();
            }

            if ((int)this.StockInfo_tComboEditor.Value == 0)
            {
                settings.stockDisplayFlag = false;
            }
            else
            {
                settings.stockDisplayFlag = true;
            }

            List<Settings> saveList = new List<Settings>();
            saveList.Add(settings);
            st = this._TBOServiceACS.SaveSettings(ref saveList, out errMsg);

            if (st == 0)
            {
                // 1���X�V�������Ȃ�
                if (saveList != null && saveList.Count > 0)
                {
                    // �f�[�^�X�V
                    if (this._settingsDic.ContainsKey(saveList[0].sectionCode))
                    {
                        this._settingsDic.Remove(saveList[0].sectionCode);
                        this._settingsDic.Add(saveList[0].sectionCode, saveList[0]);
                    }
                    else
                    {
                        this._settingsDic.Add(saveList[0].sectionCode, saveList[0]);
                    }
                }

                this._saveFlag = true;

                TMsgDisp.Show(
                this,							    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
                "�ۑ����܂����B",	                // �\�����郁�b�Z�[�W 
                st,								    // �X�e�[�^�X�l
                MessageBoxButtons.OK);
               
            }
            else
            {
                TMsgDisp.Show(
                this,							    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
                errMsg,	                            // �\�����郁�b�Z�[�W 
                st,								    // �X�e�[�^�X�l
                MessageBoxButtons.OK);
                return st;
            }
            return st;
        }

       

        /// <summary>
        /// ���_�R���{�ύX����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �ύX�`�F�b�N
            if (this._selectValue != this.Section_ComboEditor.Value.ToString())
            {
                // ���_���ύX���ꂽ
                bool dataSearhFlag = false;
                // �X�V�m�F
                if (CheckUpDate())
                {
                    // ���b�Z�[�W��\��
                    DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "���ݕҏW���̃f�[�^�����݂��܂��B"                       // �\�����郁�b�Z�[�W 
                       + Environment.NewLine + "�o�^���Ă���낵���ł����H",
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.YesNoCancel);


                    if (ret == DialogResult.Yes)
                    {
                        // �ۑ�����

                        int st = this.SaveProc();
                        if (st == 0)
                        {
                            this._selectValue = this.Section_ComboEditor.Value.ToString();
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // �ۑ��Ɏ��s
                            this.Section_ComboEditor.ValueChanged -= new EventHandler(this.Section_ComboEditor_ValueChanged);
                            this.Section_ComboEditor.Value = this._selectValue;
                            this.Section_ComboEditor.ValueChanged += new EventHandler(this.Section_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // �ҏW���e��j�� �C���f�b�N���X�V
                        this._selectValue = this.Section_ComboEditor.Value.ToString();
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // �L�����Z�� ���@�߂�
                        this.Section_ComboEditor.Validated -= new EventHandler(this.Section_ComboEditor_ValueChanged);
                        this.Section_ComboEditor.Value = this._selectValue;
                        this.Section_ComboEditor.Validated += new EventHandler(this.Section_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // �f�[�^�ύX�Ȃ�
                    // �C���f�b�N�X���X�V
                    this._selectValue = this.Section_ComboEditor.Value.ToString();
                    dataSearhFlag = true;
                }
                if (dataSearhFlag)
                {
                    // ��ʍč\�z
                    this.DispSetting();
                }
            }
        }

        /// <summary>
        /// �ύX�`�F�b�N
        /// </summary>
        private bool CheckUpDate()
        {
            bool ret = false;
            // �X�V�O�f�[�^�擾
            if (this._settingsDic.ContainsKey(this._selectValue))
            {
                int befSet = 0;
                if (this._settingsDic[this._selectValue].stockDisplayFlag)
                {
                    befSet = 1;
                }

                if (((int)this.StockInfo_tComboEditor.Value).Equals(befSet) == false)
                {
                    return true;
                }
            }
            return ret;
        }

        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// OthreSettingForm_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthreSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �X�V�m�F
            if (CheckUpDate())
            {
                // ���b�Z�[�W��\��
                DialogResult ret = TMsgDisp.Show(
                   this,							                        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                   CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                   "���ݕҏW���̃f�[�^�����݂��܂��B"                       // �\�����郁�b�Z�[�W 
                   + Environment.NewLine + "�o�^���Ă���낵���ł����H",
                   0,								                        // �X�e�[�^�X�l
                   MessageBoxButtons.YesNoCancel);

                if (ret == DialogResult.Yes)
                {
                    int st = this.SaveProc();
                    if (st != 0)
                    {
                        e.Cancel = true;
                        return;
                    } 
                }
                else if (ret == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }
    }
}
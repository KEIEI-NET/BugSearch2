using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Control;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;

namespace WindowsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ChangePgGuideDBAcs aaa = new ChangePgGuideDBAcs();
        ChangGidncParaWork _ChangGidncParaWork = null;

        private void button4_Click(object sender, EventArgs e)
        {
            _ChangGidncParaWork = new ChangGidncParaWork();


            #region �l�Z�b�g
            //�p�b�P�[�W�敪
            _ChangGidncParaWork.ProductCode = ProdustCodeText.Text;


            if (McastofferDivCdcombo.Text == "�}�[�W")
            {
                //�z�M�񋟋敪
                _ChangGidncParaWork.McastOfferDivCd = -1;

                //�X�V�O���[�v�R�[�h
                if (UpdateGroup1Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[0] = UpdateGroup1Text.Text;
                if (UpdateGroup2Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[1] = UpdateGroup2Text.Text;
                //if (UpdateGroup3Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[2] = UpdateGroup3Text.Text;

                //��ƃR�[�h
                if (EnterpriseCodeText.Text != "") _ChangGidncParaWork.EnterpriseCode = EnterpriseCodeText.Text;
            }
            else
            if (McastofferDivCdcombo.Text == "�W��")
            {
               //�z�M�񋟋敪
                _ChangGidncParaWork.McastOfferDivCd = 0;
            }
            else
            if (McastofferDivCdcombo.Text == "��")
            {
                //�z�M�񋟋敪
                _ChangGidncParaWork.McastOfferDivCd = 1;

                //�X�V�O���[�v�R�[�h
                if (UpdateGroup1Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[0] = UpdateGroup1Text.Text;
                if (UpdateGroup2Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[1] = UpdateGroup2Text.Text;
                //if (UpdateGroup3Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[2] = UpdateGroup3Text.Text;

                //��ƃR�[�h
                if (EnterpriseCodeText.Text != "") _ChangGidncParaWork.EnterpriseCode = EnterpriseCodeText.Text;
            }


            //���
            if (StandardDateText.Text != "")                _ChangGidncParaWork.StdDate = Convert.ToInt64(StandardDateText.Text);

            //���J���敪
            if (checkBox3.Checked == false)
            {
                if (OpenDtTmDivCombo.Text == "�T�|�[�g���J����") _ChangGidncParaWork.OpenDtTmDiv = 1;
                if (OpenDtTmDivCombo.Text == "���[�U�[���J����") _ChangGidncParaWork.OpenDtTmDiv = 2;
            }
            //�z�M�o�[�W����
            if (MulticastVerText.Text != "")                _ChangGidncParaWork.MulticastVersion = MulticastVerText.Text;

            //�z�M�A��
            if (MulticastConsNoText.Text != "")             _ChangGidncParaWork.MulticastConsNo = Convert.ToInt32(MulticastConsNoText.Text);

            //�z�M�T�u�R�[�h
            if (MulticastSubCodeText.Text != "")            _ChangGidncParaWork.MulticastSubCode = Convert.ToInt32(MulticastSubCodeText.Text);

            //�z�M���@�J�n
            if (checkBox3.Checked == false)
            {
                if (checkBox1.Checked) _ChangGidncParaWork.StMulticastDate = monthCalendar1.SelectionRange.Start;
            }

            //�z�M���@�I��
            if (checkBox3.Checked == false)
            {
                if (checkBox2.Checked) _ChangGidncParaWork.EdMulticastDate = monthCalendar2.SelectionRange.Start;
            }

            //�z�M�o�[�W�����@�J�n
            if (StMulticastVerText.Text != "")              _ChangGidncParaWork.StMulticastVersion = StMulticastVerText.Text;

            //�z�M�o�[�W�����@�I��
            if (EdMulticastVerText.Text != "")              _ChangGidncParaWork.EdMulticastVersion = EdMulticastVerText.Text;

            if (MulticastSystemDivCdcombo.Text != "")
            {
                //�z�M�V�X�e���敪
                if (MulticastSystemDivCdcombo.Text      == "�S��") _ChangGidncParaWork.MulticastSystemDivCd = -1;
                else if (MulticastSystemDivCdcombo.Text == "����") _ChangGidncParaWork.MulticastSystemDivCd = 0;
                else if (MulticastSystemDivCdcombo.Text == "����") _ChangGidncParaWork.MulticastSystemDivCd = 1;
                else if (MulticastSystemDivCdcombo.Text == "���") _ChangGidncParaWork.MulticastSystemDivCd = 2;
                else if (MulticastSystemDivCdcombo.Text == "�Ԕ�") _ChangGidncParaWork.MulticastSystemDivCd = 3;
            }

            if (ChangeContents1Text.Text != "")
            {
                //�ύX���e
                _ChangGidncParaWork.ChangeContents    = new string[1];
                _ChangGidncParaWork.ChangeContents[0] = ChangeContents1Text.Text;
                if (ChangeContents2Text.Text != "")
                {
                    _ChangGidncParaWork.ChangeContents[1] = ChangeContents2Text.Text;
                    if (ChangeContents3Text.Text != "")�@�@ _ChangGidncParaWork.ChangeContents[2] = ChangeContents3Text.Text;
                }
            }

            //�z�M�v���O��������
            if (MulticastProgramNameText.Text != "") _ChangGidncParaWork.MulticastProgramName = MulticastProgramNameText.Text;

            //�ē��敪
            if (checkBox3.Checked == false)
            {
                if (comboBox1.Text == "����") _ChangGidncParaWork.McastGidncCntntsCd = 0;
                if (comboBox1.Text == "�v���O�����z�M") _ChangGidncParaWork.McastGidncCntntsCd = 1;
                if (comboBox1.Text == "�T�[�o�[�����e�i���X") _ChangGidncParaWork.McastGidncCntntsCd = 2;
                if (comboBox1.Text == "�󎚈ʒu�����[�X") _ChangGidncParaWork.McastGidncCntntsCd = 3;
            }

            //�n��
            if (textBox1.Text != "")  _ChangGidncParaWork.Area = textBox1.Text;
            #endregion


            //List<PgMulcasGdWork> PgMulcasGdWorkList = new List<PgMulcasGdWork>();  //Del 2007.12.10 Kouguchi
            //List<PgMulcsGdDWork> PgMulcsGdDWorkList = new List<PgMulcsGdDWork>();  //Del 2007.12.10 Kouguchi
            List<ChangGidncWork> ChangGidncWorkList = new List<ChangGidncWork>();    //Add 2007.12.10 Kouguchi
            List<ChgGidncDtWork> ChgGidncDtWorkList = new List<ChgGidncDtWork>();    //Add 2007.12.10 Kouguchi

            
            
            int stNumber = 0;
            int count = 10;
            int maxCount = 0;
            string errMessage = "";

            int status = aaa.ChangGidnc(_ChangGidncParaWork, out ChangGidncWorkList, out ChgGidncDtWorkList, stNumber, count, out maxCount, out errMessage);

            dataGridView2.DataSource = ChangGidncWorkList;
            dataGridView3.DataSource = ChgGidncDtWorkList;
            maxCountText.Text = Convert.ToString(maxCount);

            if (status != 0)  Text = "�Y���f�[�^������܂���" + "  st=" + status;
            if (status == 0)  Text = "�Y���f�[�^������܂�" + "  st=" + status;

        }

    }

}


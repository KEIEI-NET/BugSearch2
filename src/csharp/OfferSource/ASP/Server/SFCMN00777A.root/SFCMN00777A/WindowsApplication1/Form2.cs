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


            #region 値セット
            //パッケージ区分
            _ChangGidncParaWork.ProductCode = ProdustCodeText.Text;


            if (McastofferDivCdcombo.Text == "マージ")
            {
                //配信提供区分
                _ChangGidncParaWork.McastOfferDivCd = -1;

                //更新グループコード
                if (UpdateGroup1Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[0] = UpdateGroup1Text.Text;
                if (UpdateGroup2Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[1] = UpdateGroup2Text.Text;
                //if (UpdateGroup3Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[2] = UpdateGroup3Text.Text;

                //企業コード
                if (EnterpriseCodeText.Text != "") _ChangGidncParaWork.EnterpriseCode = EnterpriseCodeText.Text;
            }
            else
            if (McastofferDivCdcombo.Text == "標準")
            {
               //配信提供区分
                _ChangGidncParaWork.McastOfferDivCd = 0;
            }
            else
            if (McastofferDivCdcombo.Text == "個別")
            {
                //配信提供区分
                _ChangGidncParaWork.McastOfferDivCd = 1;

                //更新グループコード
                if (UpdateGroup1Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[0] = UpdateGroup1Text.Text;
                if (UpdateGroup2Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[1] = UpdateGroup2Text.Text;
                //if (UpdateGroup3Text.Text != "") _ChangGidncParaWork.UpdateGroupCode[2] = UpdateGroup3Text.Text;

                //企業コード
                if (EnterpriseCodeText.Text != "") _ChangGidncParaWork.EnterpriseCode = EnterpriseCodeText.Text;
            }


            //基準日
            if (StandardDateText.Text != "")                _ChangGidncParaWork.StdDate = Convert.ToInt64(StandardDateText.Text);

            //公開時区分
            if (checkBox3.Checked == false)
            {
                if (OpenDtTmDivCombo.Text == "サポート公開日時") _ChangGidncParaWork.OpenDtTmDiv = 1;
                if (OpenDtTmDivCombo.Text == "ユーザー公開日時") _ChangGidncParaWork.OpenDtTmDiv = 2;
            }
            //配信バージョン
            if (MulticastVerText.Text != "")                _ChangGidncParaWork.MulticastVersion = MulticastVerText.Text;

            //配信連番
            if (MulticastConsNoText.Text != "")             _ChangGidncParaWork.MulticastConsNo = Convert.ToInt32(MulticastConsNoText.Text);

            //配信サブコード
            if (MulticastSubCodeText.Text != "")            _ChangGidncParaWork.MulticastSubCode = Convert.ToInt32(MulticastSubCodeText.Text);

            //配信日　開始
            if (checkBox3.Checked == false)
            {
                if (checkBox1.Checked) _ChangGidncParaWork.StMulticastDate = monthCalendar1.SelectionRange.Start;
            }

            //配信日　終了
            if (checkBox3.Checked == false)
            {
                if (checkBox2.Checked) _ChangGidncParaWork.EdMulticastDate = monthCalendar2.SelectionRange.Start;
            }

            //配信バージョン　開始
            if (StMulticastVerText.Text != "")              _ChangGidncParaWork.StMulticastVersion = StMulticastVerText.Text;

            //配信バージョン　終了
            if (EdMulticastVerText.Text != "")              _ChangGidncParaWork.EdMulticastVersion = EdMulticastVerText.Text;

            if (MulticastSystemDivCdcombo.Text != "")
            {
                //配信システム区分
                if (MulticastSystemDivCdcombo.Text      == "全て") _ChangGidncParaWork.MulticastSystemDivCd = -1;
                else if (MulticastSystemDivCdcombo.Text == "共通") _ChangGidncParaWork.MulticastSystemDivCd = 0;
                else if (MulticastSystemDivCdcombo.Text == "整備") _ChangGidncParaWork.MulticastSystemDivCd = 1;
                else if (MulticastSystemDivCdcombo.Text == "鈑金") _ChangGidncParaWork.MulticastSystemDivCd = 2;
                else if (MulticastSystemDivCdcombo.Text == "車販") _ChangGidncParaWork.MulticastSystemDivCd = 3;
            }

            if (ChangeContents1Text.Text != "")
            {
                //変更内容
                _ChangGidncParaWork.ChangeContents    = new string[1];
                _ChangGidncParaWork.ChangeContents[0] = ChangeContents1Text.Text;
                if (ChangeContents2Text.Text != "")
                {
                    _ChangGidncParaWork.ChangeContents[1] = ChangeContents2Text.Text;
                    if (ChangeContents3Text.Text != "")　　 _ChangGidncParaWork.ChangeContents[2] = ChangeContents3Text.Text;
                }
            }

            //配信プログラム名称
            if (MulticastProgramNameText.Text != "") _ChangGidncParaWork.MulticastProgramName = MulticastProgramNameText.Text;

            //案内区分
            if (checkBox3.Checked == false)
            {
                if (comboBox1.Text == "共通") _ChangGidncParaWork.McastGidncCntntsCd = 0;
                if (comboBox1.Text == "プログラム配信") _ChangGidncParaWork.McastGidncCntntsCd = 1;
                if (comboBox1.Text == "サーバーメンテナンス") _ChangGidncParaWork.McastGidncCntntsCd = 2;
                if (comboBox1.Text == "印字位置リリース") _ChangGidncParaWork.McastGidncCntntsCd = 3;
            }

            //地域
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

            if (status != 0)  Text = "該当データがありません" + "  st=" + status;
            if (status == 0)  Text = "該当データがあります" + "  st=" + status;

        }

    }

}


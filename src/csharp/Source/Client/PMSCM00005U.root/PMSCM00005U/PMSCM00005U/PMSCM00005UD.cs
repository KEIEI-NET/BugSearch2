using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�|�b�v�A�b�v �ԕi�m�F�_�C�A���O�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �V�K�쐬</br>
    /// <br>Programmer	: 21024 ���X�� ��</br>
    /// <br>Date		: 2010/12/22</br>
    /// </remarks>
    public partial class PMSCM00005UD : Form
    {
        /// <summary>SCM�[��</summary>
        private ISCMTerminal _terminal;
        private ISCMOrderHeaderRecord _scmOrderData;
        private CustomerInfo _customerInfo;
        private UserSCMOrderHeaderRecord _scmOrderHeader;
        private UserSCMOrderCarRecord _scmOrderCar;
        private List<UserSCMOrderDetailRecord> _scmOrderDetailList;
        private List<UserSCMOrderAnswerRecord> _scmOrderAnswerList;


        /// <summary>SCM�[���p�A�N�Z�X�N���X</summary>
        private ISCMTerminal Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }

        public UserSCMOrderHeaderRecord SCMOrderHeader
        {
            get { return _scmOrderHeader; }
        }


        public UserSCMOrderCarRecord SCMOrderCar
        {
            get { return _scmOrderCar; }
        }


        public List<UserSCMOrderDetailRecord> SCMOrderDetailList
        {
            get { return _scmOrderDetailList; }
        }


        public List<UserSCMOrderAnswerRecord> SCMOrderAnswerList
        {
            get { return _scmOrderAnswerList; }
        }

        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM00005UD()
        {
            InitializeComponent();
        }

        #endregion

        #region �� Public Method

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="scmorderData"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, ISCMTerminal terminal, ISCMOrderHeaderRecord scmorderData, CustomerInfo customerInfo)
        {

            this.Terminal = terminal;
            _scmOrderData = scmorderData;
            _customerInfo = customerInfo;
            object scmHeader;
            object scmCar;
            object scmDtlList;
            object scmAnsList;

            int status = Terminal.GetSCMData(scmorderData, out scmHeader, out scmCar, out scmDtlList, out scmAnsList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return DialogResult.None;
            }
            else
            {
				#region 2012.04.10 TERASAKA DEL STA
//                UserSCMOrderHeaderRecord header = null;
				#endregion
				if (scmHeader != null && scmHeader is UserSCMOrderHeaderRecord) _scmOrderHeader = (UserSCMOrderHeaderRecord)scmHeader;
                if (scmCar != null && scmCar is UserSCMOrderCarRecord) _scmOrderCar = (UserSCMOrderCarRecord)scmCar;
                if (scmDtlList != null && scmDtlList is List<UserSCMOrderDetailRecord>) _scmOrderDetailList = (List<UserSCMOrderDetailRecord>)scmDtlList;
                if (scmAnsList != null && scmAnsList is List<UserSCMOrderAnswerRecord>) _scmOrderAnswerList = (List<UserSCMOrderAnswerRecord>)scmAnsList;

                if (_scmOrderData != null)
                {
                    // �|�b�v�A�b�v�ŕ\�����Ă���f�[�^�ƍŐV�̃f�[�^�̍X�V���E�X�V���Ԃ��قȂ�ꍇ�́A
                    // ���ׂ��ǉ����ꂽ�������ς̉\��������̂ŏ������Ȃ�
                    if (( scmorderData.UpdateDate != _scmOrderHeader.UpdateDate ) ||
                        ( scmorderData.UpdateTime != _scmOrderHeader.UpdateTime ))
                    {
                        this.DispMessage(owner);

                        return DialogResult.None;
                    }
                }
            }
            
            this.lbl_CustomerSnm.Text = _customerInfo.CustomerSnm;
            this.lbl_InquiryNumber.Text = _scmOrderHeader.InquiryNumber.ToString();

            return base.ShowDialog(owner);
        }

        #endregion

        #region ��Control Event
        /// <summary>
        /// ��� Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00005UB_Load(object sender, EventArgs e)
        {
            Bitmap iconBitmap = new Bitmap(288, 32);
            Graphics graphics = Graphics.FromImage(iconBitmap);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
            pictureBox_Icon.Image = iconBitmap;
        }

        /// <summary>
        /// ��� Shown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00005UB_Shown(object sender, EventArgs e)
        {
            this.btn_Cancel.Focus();
        }

        /// <summary>
        /// �ڍ׊m�F�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Detailed_Click(object sender, EventArgs e)
        {
            PMSCM00005UE frm = new PMSCM00005UE();
            frm.SCMOrderHeader = _scmOrderHeader;
            frm.SCMOrderCar = _scmOrderCar;
            frm.SCMOrderDetailList = _scmOrderDetailList;
            frm.SCMOrderAnswerList = _scmOrderAnswerList;
            frm.Terminal = this.Terminal;
            frm.CustomerInfo = this._customerInfo;
            frm.ShowDialog(this);
        }

        /// <summary>
        /// �u�͂��v�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Yes_Click(object sender, EventArgs e)
        {
            // 2011/02/18 >>>
            //string errMsg;
            //int status = Terminal.ReturnedGoodsApproval((object)this._scmOrderData, (int)SCMTerminal.CancelCndtinDiv.Cancelled, out errMsg);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    DialogResult = DialogResult.Yes;
            //    this.Close();
            //}
            //else if (status == -1)
            //{
            //    this.DispMessage(this);
            //    DialogResult = DialogResult.None;
            //    this.Close();
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        errMsg,
            //        status,
            //        MessageBoxButtons.OK);
            //}
            DialogResult = DialogResult.Yes;
            this.Close();
            // 2011/02/18 <<<
        }

        /// <summary>
        /// �u�������v�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_No_Click(object sender, EventArgs e)
        {
            string errMsg;
            int status = Terminal.ReturnedGoodsApproval((object)this._scmOrderData, (int)SCMTerminal.CancelCndtinDiv.Rejected, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
            else if (status == -1)
            {
                this.DispMessage(this);
                DialogResult = DialogResult.None;
                this.Close();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
            }
        }

        #endregion

        #region �� Private Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        private void DispMessage(IWin32Window owner)
        {
            TMsgDisp.Show(
                    owner,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�����ς݂��A�ǉ��ŃL�����Z���v��������ׁA�����ł��܂���B" + Environment.NewLine +
                    "SCM�⍇���ꗗ�Ńf�[�^���m�F���ĉ������B",
                    0,
                    MessageBoxButtons.OK);
        }
        #endregion
    }
}
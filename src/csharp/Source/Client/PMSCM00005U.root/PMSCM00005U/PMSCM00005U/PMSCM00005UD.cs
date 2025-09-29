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
    /// SCMポップアップ 返品確認ダイアログクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 新規作成</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/12/22</br>
    /// </remarks>
    public partial class PMSCM00005UD : Form
    {
        /// <summary>SCM端末</summary>
        private ISCMTerminal _terminal;
        private ISCMOrderHeaderRecord _scmOrderData;
        private CustomerInfo _customerInfo;
        private UserSCMOrderHeaderRecord _scmOrderHeader;
        private UserSCMOrderCarRecord _scmOrderCar;
        private List<UserSCMOrderDetailRecord> _scmOrderDetailList;
        private List<UserSCMOrderAnswerRecord> _scmOrderAnswerList;


        /// <summary>SCM端末用アクセスクラス</summary>
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

        #region □ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM00005UD()
        {
            InitializeComponent();
        }

        #endregion

        #region □ Public Method

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
                    // ポップアップで表示しているデータと最新のデータの更新日・更新時間が異なる場合は、
                    // 明細が追加されたか処理済の可能性があるので処理しない
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

        #region □Control Event
        /// <summary>
        /// 画面 Loadイベント
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
        /// 画面 Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00005UB_Shown(object sender, EventArgs e)
        {
            this.btn_Cancel.Focus();
        }

        /// <summary>
        /// 詳細確認ボタン クリックイベント
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
        /// 「はい」ボタン クリックイベント
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
        /// 「いいえ」ボタン クリックイベント
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

        #region □ Private Method

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
                    "処理済みか、追加でキャンセル要求がある為、処理できません。" + Environment.NewLine +
                    "SCM問合せ一覧でデータを確認して下さい。",
                    0,
                    MessageBoxButtons.OK);
        }
        #endregion
    }
}
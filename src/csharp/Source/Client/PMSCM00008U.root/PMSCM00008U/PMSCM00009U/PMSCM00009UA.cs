//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇���f�[�^��M�m�F��� �t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/20  �C�����e : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
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
    /// �ȒP�⍇���f�[�^��M�m�F��� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬(IAAE����ύX)</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00009UA : Form
    {
        // ===================================================================================== //
        // �񋓌^
        // ===================================================================================== //
        #region �� �񋓌^
        /// <summary>
        /// �⍇���E�������
        /// </summary>
        public enum InqOrdDivCd : int
        {
            Inquiry = 1,
            Order = 2
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g
        private int _customerCode = 0;
        private string _customerSnm = string.Empty;
        private InqOrdDivCd _inqOrdDiv = InqOrdDivCd.Inquiry;
        private long _inquiryNumber;

        // 2011/03/03 Add >>>
        private int _cancelRowNumber = 0;
        private string _cancelGoodsName = string.Empty;
        private int _cancelDiv = 0;

        private const int ctDefaultHeight = 260;
        private const int ctCancelHeight = 290;
        // 2011/03/03 Add <<<

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property

        /// <summary>���Ӑ旪��</summary>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// <summary>���Ӑ�R�[�h</summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>�⍇���E�������</summary>
        public InqOrdDivCd InqOrdDiv
        {
            get { return _inqOrdDiv; }
            set { _inqOrdDiv = value; }
        }

        /// <summary>�⍇���ԍ�</summary>
        public long InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        // 2011/03/03 Add >>>
        /// <summary>
        /// ���������s�ԍ�
        /// </summary>
        public int CancelRowNumber
        {
            get { return _cancelRowNumber; }
            set { _cancelRowNumber = value; }
        }

        /// <summary>
        /// ����������i����
        /// </summary>
        public string CancelGoodsName
        {
            get { return _cancelGoodsName; }
            set { _cancelGoodsName = value; }
        }

        /// <summary>
        /// �L�����Z���敪
        /// </summary>
        public int CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        // 2011/03/03 Add <<<
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region �� Event

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Constructor

        public PMSCM00009UA()
        {
            InitializeComponent();
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method
        /// <summary>
        /// ��ʃZ�b�g
        /// </summary>
        private void SetDisplay()
        {
            this.ulabel_customerSNM.Text = _customerSnm.Trim();
            if (this.ulabel_customerSNM.Text.Length > 15) this.ulabel_customerSNM.Text = this.ulabel_customerSNM.Text.Substring(0, 15);
            // 2011/03/03 >>>
            //this.uLabel_Msg1.Text = string.Format("{0}������M���܂����B", GetInfoMsg(_inqOrdDiv));
            //this.ulabel_InquiryNumber.Text = string.Format("{0:0000000000}", this._inquiryNumber);
            this.ulabel_InquiryNumber.Text = this._inquiryNumber.ToString();
            // 2011/03/03 <<<
            this.ulabel_inqOrdDiv.Text = GetInfoMsg(_inqOrdDiv);

            // 2011/03/03 Add >>>
            if (this._cancelRowNumber > 0)
            {
                this.Height = ctCancelHeight;
                this.uLabel_Msg1.Text = string.Format("{0}��񂪎������܂����B", GetInfoMsg(_inqOrdDiv));
                this.uLabel_GoodsName.Text = this._cancelGoodsName;
                this.uLabel_GoodsName.Visible = true;
                this.uLabel_GoodsNameTitle.Visible = true;
                this.button_ExecuteEntry.Visible = false;
            }
            else
            {
                this.Height = ctDefaultHeight;
                this.uLabel_Msg1.Text = string.Format("{0}������M���܂����B", ( this._cancelDiv == 1 ) ? "�ԕi" : GetInfoMsg(_inqOrdDiv));
                if (this._cancelDiv == 1)
                {
                    this.ulabel_inqOrdDiv.Text = "�ԕi";
                }
                this.uLabel_GoodsName.Visible = false;
                this.uLabel_GoodsNameTitle.Visible = false;
                this.button_ExecuteEntry.Visible = true;
            }
            // 2011/03/03 Add <<<
        }

        #endregion

        // ===================================================================================== //
        // �e��R���g���[���C�x���g
        // ===================================================================================== //
        #region �� Control Event
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.Cancel);
            this.Close();
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerClaimConfirmation_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.OK);
            this.Close();
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UM_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;

        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UM_Load(object sender, EventArgs e)
        {
            this.SetDisplay();
        }

        #endregion


        #region �� Private Static Method
        /// <summary>
        /// ���̃��b�Z�[�W�擾
        /// </summary>
        /// <param name="inq"></param>
        /// <returns></returns>
        private static string GetInfoMsg(InqOrdDivCd inq)
        {
            string ret = string.Empty;

            switch (inq)
            {
                case InqOrdDivCd.Inquiry:
                    ret = "�⍇��";
                    break;
                case InqOrdDivCd.Order:
                    ret = "����";
                    break;
                default:
                    ret = "�V��";
                    break;
            }
            return ret;
        }
        #endregion
    }
}
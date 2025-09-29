using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// **********************************************************************
    /// <summary>
    /// ���i�ؑ� ���[�U�[�R�[�h���o�^�@UI�N���X
    /// </summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>Note		: ���[�U�[�R�[�h���o�^���s���܂��B</br>
    /// <br>Programmer	: 18022  Ryo.</br>
    /// <br>Date		: 2014.09.11</br>
    /// <br></br>
    /// </remarks>
    /// **********************************************************************
    public partial class SFCMN02561UB : Form
    {
        // ============== //
        // �R���X�g���N�^ //
        // ============== //
        # region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SFCMN02561UB()
        {
            InitializeComponent();
        }
        #endregion

        // ================== //
        // �p�u���b�N���\�b�h //
        // ================== //
        #region Public Method

        /// <summary>
        /// ShowDialog
        /// </summary>
        public DialogResult ShowDialog(IWin32Window owner, string cnectOtherEpCd, string cnectOtherEpNm, string cnectOriginalEpCd, ref Dictionary<string, OScmBPCnt> oScmBPCntTable, ref string userCode, ref string userName)
        {
            this.DialogResult = DialogResult.Cancel;

            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherEpNm = cnectOtherEpNm;
            this._cnectOriginalEpCd = cnectOriginalEpCd;

            this._oScmBPCntTable = oScmBPCntTable;

            this.ShowDialog(owner);

            if (this.DialogResult == DialogResult.OK)
            {
                oScmBPCntTable = this._oScmBPCntTable;
            }
            userCode = this._userCode;
            userName = this._userName;

            return this.DialogResult;
        }
        #endregion

        // ==================== //
        // �v���C�x�[�g�����o�[ //
        // ==================== //
        #region Private Menbers
        private string _cnectOtherEpCd;
        private string _cnectOtherEpNm;
        private string _cnectOriginalEpCd;
        private string _userCode = string.Empty;
        private string _userName = string.Empty;

        private Dictionary<string, OScmBPCnt> _oScmBPCntTable;
        #endregion

        // ============ //
        // ��ʃC�x���g //
        // ============ //
        #region Form Event
        /// **********************************************************************
        /// <summary>
        /// Form_Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       �F ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer �F Ryo.</br>
        /// <br>Date       �F 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void SFCMN02561UB_Load(object sender, EventArgs e)
        {
            this.Close_Button.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
            this.Save_Button.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

            this.OtherEpCd_tEdit.Text = this._cnectOtherEpCd;
            this.OtherEpNm_tEdit.Text = this._cnectOtherEpNm;

            this.BLUserCode1_tEdit.Text = this._cnectOtherEpCd.Substring(7, 7);

        }

        private void SFCMN02561UB_Shown(object sender, EventArgs e)
        {
            this.BLUserCode2_tEdit.Focus();
        }

        /// **********************************************************************
        /// <summary>
        /// Save_Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       �F ���[�U�[��[�ۑ�(S)]�{�^�������������ۂɔ������܂��B</br>
        /// <br>Programmer �F Ryo.</br>
        /// <br>Date       �F 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void Save_Button_Click(object sender, EventArgs e)
        {
            Control control = null;
            string message = string.Empty;

            // ���̓`�F�b�N
            if (!InputCheck(ref control, ref message))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFCMN02561U", message, 0, MessageBoxButtons.OK);
                control.Focus();
                return;
            }

            // ���[�U�[�R�[�h�ǉ�
            UpdateOScmBPCntTable();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        /// **********************************************************************
        /// <summary>
        /// Save_Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       �F ���[�U�[��[����(X)]�{�^�������������ۂɔ������܂��B</br>
        /// <br>Programmer �F Ryo.</br>
        /// <br>Date       �F 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void Close_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        // ===================== //
        // �v���C�x�[�g ���\�b�h //
        // ===================== //
        # region Private Methods
        /// **********************************************************************
        /// Module Name    �F InputCheck
        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns>bool</returns>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       �F ���̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer �F Ryo.</br>
        /// <br>Date       �F 2044.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private bool InputCheck(ref Control control, ref string message)
        {
            // ---------------- //
            // ���͗L���`�F�b�N //
            // ---------------- //
            // ���[�U�[�R�[�h1
            if (this.BLUserCode1_tEdit.Text == string.Empty)
            {
                control = this.BLUserCode1_tEdit;
                message = "���[�U�[�R�[�h�̓��͂��s���Ă��������B";
                return false;
            }
            // ���[�U�[�R�[�h2
            if (this.BLUserCode2_tEdit.Text == string.Empty)
            {
                control = this.BLUserCode2_tEdit;
                message = "���[�U�[�R�[�h�̓��͂��s���Ă��������B";
                return false;
            }
            // ���[�U�[����
            if (this.FTCCustomerNm_tEdit.Text.Trim() == string.Empty)
            {
                control = this.FTCCustomerNm_tEdit;
                message = "���[�U�[���̂̓��͂��s���Ă��������B";
                return false;
            }

            // ---------------------------- //
            // ���[�U�[�R�[�h�̏d���`�F�b�N //
            // ---------------------------- //
            foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
            {
                if ((oScmBPCnt.BLUserCode1.Trim() == this.BLUserCode1_tEdit.Text.Trim()) &&
                    (oScmBPCnt.BLUserCode2.Trim() == this.BLUserCode2_tEdit.Text.Trim()))
                {
                    control = this.BLUserCode2_tEdit;
                    message = "���[�U�[�R�[�h���d�����Ă��܂��B";
                    return false;
                }
            }

            return true;
        }

        /// **********************************************************************
        /// Module Name    �F UpdateOScmBPCntTable
        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       �F �񋟑�SCM���Ə�A���}�X�^Table�̍X�V���s���܂��B</br>
        /// <br>Programmer �F Ryo.</br>
        /// <br>Date       �F 2044.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void UpdateOScmBPCntTable()
        {
            // ��Dictionary��Copy���쐬
            Dictionary<string, OScmBPCnt> wkScmBPCntTable = new Dictionary<string,OScmBPCnt>(this._oScmBPCntTable);

            foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
            {
                if (oScmBPCnt.CnectOriginalEpCd == this._cnectOriginalEpCd)
                {
                    OScmBPCnt addOScmBPCnt = new OScmBPCnt();

                    addOScmBPCnt.CreateDateTime      = oScmBPCnt.CreateDateTime; 
                    addOScmBPCnt.UpdateDateTime      = oScmBPCnt.UpdateDateTime; 
                    addOScmBPCnt.LogicalDeleteCode   = oScmBPCnt.LogicalDeleteCode; 

                    addOScmBPCnt.ContractantCode     = oScmBPCnt.ContractantCode; 
                    addOScmBPCnt.FTCCustomerCode     = 0;
                    addOScmBPCnt.BLUserCode1         = this.BLUserCode1_tEdit.Text.Trim();
                    addOScmBPCnt.BLUserCode2         = this.BLUserCode2_tEdit.Text.Trim();
                    addOScmBPCnt.CnectOtherEpCd      = oScmBPCnt.CnectOtherEpCd;
                    addOScmBPCnt.ContractantName     = oScmBPCnt.ContractantName;
                    addOScmBPCnt.FTCCustomerName     = this.FTCCustomerNm_tEdit.Text.TrimEnd();

                    addOScmBPCnt.TransContractantCd  = oScmBPCnt.TransContractantCd;
                    addOScmBPCnt.TransCustomerCd     = oScmBPCnt.TransCustomerCd;
                    addOScmBPCnt.TransBLUserCode1    = oScmBPCnt.TransBLUserCode1;
                    addOScmBPCnt.TransBLUserCode2    = oScmBPCnt.TransBLUserCode2;
                    addOScmBPCnt.CnectOriginalEpCd   = oScmBPCnt.CnectOriginalEpCd;
                    addOScmBPCnt.TransContractantNm  = oScmBPCnt.TransContractantNm;
                    addOScmBPCnt.TransCustomerNm     = oScmBPCnt.TransCustomerNm;
                    addOScmBPCnt.CooprtDataUpdateDiv = 1;

                    if (wkScmBPCntTable.ContainsKey(SFCMN02561UA.MakeOScmBPCntTableContainsKey(addOScmBPCnt)) == false)
                    {
                        wkScmBPCntTable.Add(SFCMN02561UA.MakeOScmBPCntTableContainsKey(addOScmBPCnt), addOScmBPCnt);
                    }

                    this._userCode = addOScmBPCnt.BLUserCode1 + "-" + addOScmBPCnt.BLUserCode2;
                    this._userName = addOScmBPCnt.ContractantName + " " + addOScmBPCnt.FTCCustomerName;
                }
            }

            this._oScmBPCntTable = wkScmBPCntTable;
        
        }
        #endregion


    }
}
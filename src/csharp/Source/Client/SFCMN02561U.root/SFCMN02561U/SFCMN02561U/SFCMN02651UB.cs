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
    /// 部品証側 ユーザーコード仮登録　UIクラス
    /// </summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>Note		: ユーザーコード仮登録を行います。</br>
    /// <br>Programmer	: 18022  Ryo.</br>
    /// <br>Date		: 2014.09.11</br>
    /// <br></br>
    /// </remarks>
    /// **********************************************************************
    public partial class SFCMN02561UB : Form
    {
        // ============== //
        // コンストラクタ //
        // ============== //
        # region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SFCMN02561UB()
        {
            InitializeComponent();
        }
        #endregion

        // ================== //
        // パブリックメソッド //
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
        // プライベートメンバー //
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
        // 画面イベント //
        // ============ //
        #region Form Event
        /// **********************************************************************
        /// <summary>
        /// Form_Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       ： ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer ： Ryo.</br>
        /// <br>Date       ： 2014.09.11</br>
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
        /// Save_Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       ： ユーザーが[保存(S)]ボタンを押下した際に発生します。</br>
        /// <br>Programmer ： Ryo.</br>
        /// <br>Date       ： 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void Save_Button_Click(object sender, EventArgs e)
        {
            Control control = null;
            string message = string.Empty;

            // 入力チェック
            if (!InputCheck(ref control, ref message))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFCMN02561U", message, 0, MessageBoxButtons.OK);
                control.Focus();
                return;
            }

            // ユーザーコード追加
            UpdateOScmBPCntTable();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        /// **********************************************************************
        /// <summary>
        /// Save_Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       ： ユーザーが[閉じる(X)]ボタンを押下した際に発生します。</br>
        /// <br>Programmer ： Ryo.</br>
        /// <br>Date       ： 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void Close_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        // ===================== //
        // プライベート メソッド //
        // ===================== //
        # region Private Methods
        /// **********************************************************************
        /// Module Name    ： InputCheck
        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns>bool</returns>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       ： 入力チェックを行います。</br>
        /// <br>Programmer ： Ryo.</br>
        /// <br>Date       ： 2044.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private bool InputCheck(ref Control control, ref string message)
        {
            // ---------------- //
            // 入力有無チェック //
            // ---------------- //
            // ユーザーコード1
            if (this.BLUserCode1_tEdit.Text == string.Empty)
            {
                control = this.BLUserCode1_tEdit;
                message = "ユーザーコードの入力を行ってください。";
                return false;
            }
            // ユーザーコード2
            if (this.BLUserCode2_tEdit.Text == string.Empty)
            {
                control = this.BLUserCode2_tEdit;
                message = "ユーザーコードの入力を行ってください。";
                return false;
            }
            // ユーザー名称
            if (this.FTCCustomerNm_tEdit.Text.Trim() == string.Empty)
            {
                control = this.FTCCustomerNm_tEdit;
                message = "ユーザー名称の入力を行ってください。";
                return false;
            }

            // ---------------------------- //
            // ユーザーコードの重複チェック //
            // ---------------------------- //
            foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
            {
                if ((oScmBPCnt.BLUserCode1.Trim() == this.BLUserCode1_tEdit.Text.Trim()) &&
                    (oScmBPCnt.BLUserCode2.Trim() == this.BLUserCode2_tEdit.Text.Trim()))
                {
                    control = this.BLUserCode2_tEdit;
                    message = "ユーザーコードが重複しています。";
                    return false;
                }
            }

            return true;
        }

        /// **********************************************************************
        /// Module Name    ： UpdateOScmBPCntTable
        /// <summary>
        /// 入力チェック
        /// </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       ： 提供側SCM事業場連結マスタTableの更新を行います。</br>
        /// <br>Programmer ： Ryo.</br>
        /// <br>Date       ： 2044.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void UpdateOScmBPCntTable()
        {
            // 元DictionaryのCopyを作成
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
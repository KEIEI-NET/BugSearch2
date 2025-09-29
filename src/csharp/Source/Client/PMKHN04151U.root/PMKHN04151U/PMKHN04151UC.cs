//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : メール送信履歴表示
// 作 成 日  2010/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/06/01  修正内容 : Redmine#8919対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メール内容表示コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メール内容表示を行うコントロールクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br>Update Note :2010/06/01 呉元嘯 Redmine#8919対応</br>
    /// </remarks>
    public partial class PMKHN04151UC : Form
    { 

        /// <summary>イメージリスト</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>メール送信履歴表示 データクラス</summary>
        /// <remarks></remarks> 
        private QrMailHist _qrMailHist = null;

        #region ■ Constroctors
        /// <summary>
        /// メール内容表示クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <param name="qrMailHist">メール内容表示</param>
        /// <br>Note       : メール内容表示クラスコンストラクタです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UC(QrMailHist qrMailHist)
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            _qrMailHist = qrMailHist;
        }
        #endregion

        #region ■ event
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// <br>Update Note :2010/06/01 呉元嘯 Redmine#8919対応</br>
        /// </remarks>
        private void PMKHN04151UC_Load(object sender, EventArgs e)
        {
            // 閉じるボタン
            this.UltraButton_Close.ImageList = this._imageList16;
            this.UltraButton_Close.Appearance.Image =(int)Size16_Index.CLOSE;
            
            #region txt
            this.UltraLabel_Address.Text = _qrMailHist.EmployeeName;
            this.toolTip1.SetToolTip(this.UltraLabel_Address, _qrMailHist.EmployeeName);
            this.UltraLabel_CC.Text = _qrMailHist.CCInfo;
            this.toolTip1.SetToolTip(this.UltraLabel_CC, _qrMailHist.CCInfo);
            this.UltraLabel_SendingDate.Text = _qrMailHist.TransmitDate;
            this.toolTip1.SetToolTip(this.UltraLabel_SendingDate, _qrMailHist.TransmitDate);
            this.UltraLabel_FileName.Text = _qrMailHist.Title;
            this.toolTip1.SetToolTip(this.UltraLabel_FileName, _qrMailHist.Title);
            this.textBox1.Text = _qrMailHist.MailText;

            // 履歴情報のQRコードファイル名が空白の場合は、QRコード項目そのものを非表示とする
            if (string.IsNullOrEmpty(_qrMailHist.QRCode))
            {
                this.Panel_QrCd.Visible = false;
                //this.Panel_Mail_Header.Size = new System.Drawing.Size(760, 97);// DEL 2010/06/01
                this.Panel_Mail_Header.Size = new System.Drawing.Size(592, 97);// ADD 2010/06/01
            }
            else
            {
                this.Panel_QrCd.Visible = true;
                //this.Panel_Mail_Header.Size = new System.Drawing.Size(760, 113);// DEL 2010/06/01
                this.Panel_Mail_Header.Size = new System.Drawing.Size(592, 113);// ADD 2010/06/01
                this.UltraLabel_QrCd.Text = _qrMailHist.QRCode;
                this.toolTip1.SetToolTip(this.UltraLabel_QrCd, _qrMailHist.QRCode);
            }
            #endregion
        }

        /// <summary>
        /// UltraButton_Close_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : UltraButton_Close_Clickイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void UltraButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
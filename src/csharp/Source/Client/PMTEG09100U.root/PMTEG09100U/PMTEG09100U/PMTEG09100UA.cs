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
    /// 手形データマスタクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形データマスタのフォームクラスです。</br>      
    /// <br>Programmer : 葛軍</br>                                  
    /// <br>Date       : 2010.04.22</br> 
    /// </remarks>
    public partial class PMTEG09100UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 手形データマスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形データマスタのコンストラクタです。</br>      
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        public PMTEG09100UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>手形データマスタのフォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMTEG09101UA _mPMTEG09101UAForm;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        private void PMTEG09100UA_Load(object sender, EventArgs e)
        {
            this._mPMTEG09101UAForm = new PMTEG09101UA();
            this._mPMTEG09101UAForm.TopLevel = false;
            this._mPMTEG09101UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMTEG09101UAForm.Show();
            this._mPMTEG09101UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMTEG09101UAForm.Text;
            this.Controls.Add(this._mPMTEG09101UAForm);

            this._mPMTEG09101UAForm.FormClosed += new FormClosedEventHandler(this.PPMTEG09101U_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        private void PPMTEG09101U_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        # endregion
    }
}
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
    /// 発注点設定マスタクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタのフォームクラスです。</br>      
    /// <br>Programmer : 李占川</br>                                  
    /// <br>Date       : 2009.03.31</br> 
    /// </remarks>
    public partial class PMHAT09000UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 発注点設定マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタのコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        public PMHAT09000UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>発注点設定マスタのフォームクラス</summary>             
        /// <remarks>なし</remarks>　
        PMHAT09001UA _mPMHAT09001UAForm;
        # endregion

        # region イベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        private void PMHAT09000UA_Load(object sender, EventArgs e)
        {
            this._mPMHAT09001UAForm = new PMHAT09001UA();
            this._mPMHAT09001UAForm.TopLevel = false;
            this._mPMHAT09001UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMHAT09001UAForm.Show();
            this._mPMHAT09001UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMHAT09001UAForm.Text;
            this.Controls.Add(this._mPMHAT09001UAForm);

            this._mPMHAT09001UAForm.FormClosed += new FormClosedEventHandler(this.PMHAT09001U_FormClosed);
        }

        /// <summary>
        /// 閉じるイベント                                        
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じる時に発生します。</br>      
        /// <br>Programmer : 李占川</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        private void PMHAT09001U_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        # endregion
    }
}
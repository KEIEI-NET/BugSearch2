using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.NSNetworkChk.UI
{
    /// <summary>
    /// NSネットワーク通信テストエラー表示UIクラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public partial class Error_Form :Form
    {
        public Error_Form(string text)
        {
            InitializeComponent();
            this.textBox1.Text = text;
            this.textBox1.Select(0, 0);
        }
    }
}
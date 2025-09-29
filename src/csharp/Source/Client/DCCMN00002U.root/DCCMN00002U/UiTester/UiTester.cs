using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// ＵＩの確認をする為のテストフォームです。
    /// </summary>
    public partial class UiTester : Form
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UiTester()
        {
            InitializeComponent();

            // 入力保存するコントロールを設定
            uiMemInput1.TargetControls = new List<Control>( 
                new Control[] 
                { 
                    tEdit_SectionCode, tne_CustomerCode, te_EmployeeCode,
                    lb_SectionName, lb_CustomerName, lb_EmployeeName,
                    tDateEdit1,tComboEditor1,
                    checkedListBox1, ultraOptionSet1,
                    checkBox1,
                    radioButton1,radioButton2
                } 
            );
        }

        /// <summary>
        /// ChangeFocusイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            int status = 0;

            //if ( e.PrevCtrl == this.tEdit_SectionCodeAllowZero )
            //{
            //    // 拠点
            //    status = ub_sectionGuide.Read();
            //}
            //else if ( e.PrevCtrl == this.tne_CustomerCode )
            //{
            //    // 得意先
            //    status = ub_customerGuide.Read();
            //}
            //else if ( e.PrevCtrl == this.te_EmployeeCode )
            //{
            //    // 担当者
            //    status = ub_employeeGuide.Read();
            //}
            //else if ( e.PrevCtrl == this.te_MngSectionCd )
            //{
            //    // 管理拠点
            //    status = ub_mngSectionGuide.Read();
            //}

            if ( status != 0 )
            {
                e.NextCtrl = e.PrevCtrl;
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
        }

        private void UiTester_Load( object sender, EventArgs e )
        {
            tEdit_SectionCode.Text = "000003";
        }

        private void button1_Click_1( object sender, EventArgs e )
        {
            if ( uiSetControl1.CheckMatchingSet( CustomerCode1_tNedit ) )
            {
                MessageBox.Show( "ＯＫ" );
            }
            else
            {
                MessageBox.Show( "ＮＧ" );
            }
        }
    }
}
//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸準備処理
// プログラム概要   : 棚卸準備処理の注意事項を表示する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 作 成 日  2009/09/15  修正内容 : MANTIS対応(14285)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/11/30  修正内容 : 保守依頼③対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using System.Xml;
using System.IO;
using Microsoft.Win32;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸準備処理注意事項UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理注意事項UIクラスの機能を実装します</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2009/05/11</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             棚卸運用区分に合わせて内容を変更する</br>
	/// </remarks>
	public partial class AttentionDialog : Form
	{
		#region Constructor
		/// <summary>
		/// 棚卸準備処理注意事項UIクラス
		/// </summary>
        /// <param name="inventoryMngDiv">棚卸運用区分</param>
		/// <remarks>
		/// <br>Note       : 棚卸準備注意事項UIクラスのインスタンスを初期化します</br>
		/// <br>Programmer : 照田 貴志</br>
	    /// <br>Date       : 2009/05/11</br>
        /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
        /// <br>             棚卸運用区分に合わせて内容を変更する</br>
		/// </remarks>
        public AttentionDialog(int inventoryMngDiv)
		{
            InitializeComponent();

            // --- ADD 2009/11/30 ---------->>>>>
            # region xml
            List<Control> controlList = new List<Control>();

            XmlNodeReader reader = null;

            try
            {
                string s = "";
                string sFile ="";
                string sFilename ="";
                string workDir = string.Empty;
                workDir = ConstantManagement_ClientDirectory.NSCurrentDirectory;

                //運用区分「ＰＭ．ＮＳ」用
                if (inventoryMngDiv == 0)
                {
                    sFilename = "MAZAI05110U_Info0.xml";
                    sFile = workDir + @"\MAZAI05110U_Info0.xml";
                }
                //運用区分「ＰＭ７」用
                else if (inventoryMngDiv == 1)
                {
                    sFilename = "MAZAI05110U_Info1.xml";
                    sFile = workDir + @"\MAZAI05110U_Info1.xml";
                }
                //ファイル存在
                string fileNm = Path.Combine(workDir, sFilename);
                bool isExist = File.Exists(fileNm);
                if (!isExist) return;

                XmlDocument doc = new XmlDocument();
                doc.Load(sFile);
                reader = new XmlNodeReader(doc);

                int count = 0;

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (count != controlList.Count)
                        {
                            Control controlEmpty = new Control();
                            controlEmpty.Text = string.Empty;
                            controlList.Add(controlEmpty);
                        }

                        if ("string".Equals(reader.Name))
                        {
                            count++;
                        }
                    }
                    
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                s = reader.Name;
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                Control control = new Control();
                                control.Text = reader.Value;
                                controlList.Add(control);
                                count = controlList.Count;
                                break;
                            }
                    }
                }

                //最後に行きます
                if (count != controlList.Count)
                {
                    Control controlEmpty = new Control();
                    controlEmpty.Text = string.Empty;
                    controlList.Add(controlEmpty);
                }
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            //ultraLabel追加
            AddultraLabel(controlList);

            # endregion
            // --- ADD 2009/11/30 ----------<<<<<
		}
		#endregion

		#region Control Event
        #region ubOk_Click Event
        /// <summary>
        /// ubOk_Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ubOk_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}
		#endregion

        /// <summary>
        /// 追加処理
        /// </summary>
        /// <param name="controlList">ｘｍｌからで、棚卸注意事項データ</param>
        /// <remarks>
        /// <br>Note       : 追加処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        /// </remarks>
        private void AddultraLabel(List<Control> controlList)
        {
            // 
            // ultraLabel
            // 
            for (int i = 0; i < controlList.Count; i++ )
            {
                string name = "ultraLabel" + i.ToString();
                Infragistics.Win.Misc.UltraLabel label = new Infragistics.Win.Misc.UltraLabel();
                label.Location = new System.Drawing.Point(11, 3 + i * 17);
                label.Name = "ultraLabel" + i.ToString();
                label.Size = new System.Drawing.Size(750, 14);
                label.Text = controlList[i].Text;
                this.panel1.Controls.Add(label);
            }
        }

		#endregion
	}
}
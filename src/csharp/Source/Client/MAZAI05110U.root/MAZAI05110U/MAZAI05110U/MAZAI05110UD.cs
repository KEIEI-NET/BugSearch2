//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I����������
// �v���O�����T�v   : �I�����������̒��ӎ�����\������B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �� �� ��  2009/09/15  �C�����e : MANTIS�Ή�(14285)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/11/30  �C�����e : �ێ�˗��B�Ή�
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
	/// �I�������������ӎ���UI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I�������������ӎ���UI�N���X�̋@�\���������܂�</br>
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2009/05/11</br>
    /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>             �I���^�p�敪�ɍ��킹�ē��e��ύX����</br>
	/// </remarks>
	public partial class AttentionDialog : Form
	{
		#region Constructor
		/// <summary>
		/// �I�������������ӎ���UI�N���X
		/// </summary>
        /// <param name="inventoryMngDiv">�I���^�p�敪</param>
		/// <remarks>
		/// <br>Note       : �I���������ӎ���UI�N���X�̃C���X�^���X�����������܂�</br>
		/// <br>Programmer : �Ɠc �M�u</br>
	    /// <br>Date       : 2009/05/11</br>
        /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
        /// <br>             �I���^�p�敪�ɍ��킹�ē��e��ύX����</br>
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

                //�^�p�敪�u�o�l�D�m�r�v�p
                if (inventoryMngDiv == 0)
                {
                    sFilename = "MAZAI05110U_Info0.xml";
                    sFile = workDir + @"\MAZAI05110U_Info0.xml";
                }
                //�^�p�敪�u�o�l�V�v�p
                else if (inventoryMngDiv == 1)
                {
                    sFilename = "MAZAI05110U_Info1.xml";
                    sFile = workDir + @"\MAZAI05110U_Info1.xml";
                }
                //�t�@�C������
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

                //�Ō�ɍs���܂�
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

            //ultraLabel�ǉ�
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
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ubOk_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}
		#endregion

        /// <summary>
        /// �ǉ�����
        /// </summary>
        /// <param name="controlList">����������ŁA�I�����ӎ����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �ǉ��������܂��B</br>
        /// <br>Programmer : ���M</br>
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
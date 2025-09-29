//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I����������
// �v���O�����T�v   : �I�������������s���̒��ӎ�����\������B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I�������������s�����ӎ���UI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I�������������s�����ӎ���UI�N���X�̋@�\���������܂�</br>
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2009/05/11</br>
    /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>             �I���^�p�敪�ɍ��킹�ē��e��ύX����</br>
	/// </remarks>
	public partial class BeforeSaveAttentionDialog : Form
	{
		#region Constructor

        private int _inventoryMngDiv; // ADD 2009/11/30
		/// <summary>
		/// �I�������������s�����ӎ���UI�N���X
		/// </summary>
        /// <param name="inventoryMngDiv">�I���^�p�敪</param>
		/// <remarks>
		/// <br>Note       : �I�������������s�����ӎ���UI�N���X�̃C���X�^���X�����������܂�</br>
		/// <br>Programmer : �Ɠc �M�u</br>
	    /// <br>Date       : 2009/05/11</br>
        /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
        /// <br>             �I���^�p�敪�ɍ��킹�ē��e��ύX����</br>
		/// </remarks>
		public BeforeSaveAttentionDialog (int inventoryMngDiv)
		{
            InitializeComponent();

            this._inventoryMngDiv = inventoryMngDiv;// ADD 2009/11/30
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

        #region ubCancel_Click Event
        /// <summary>
        /// ubCancel_Click Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ubCancel_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion

        #region ubAttention_Click Event
        /// <summary>
        /// ubAttention_Click Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubAttention_Click(object sender, EventArgs e)
        {
            // --- UPD 2009/11/30 ---------->>>>>
            //AttentionDialog dlg = new AttentionDialog();
            AttentionDialog dlg = new AttentionDialog(_inventoryMngDiv);
            // --- UPD 2009/11/30 ----------<<<<<
            dlg.ShowDialog();
        }
        #endregion
        #endregion
    }
}
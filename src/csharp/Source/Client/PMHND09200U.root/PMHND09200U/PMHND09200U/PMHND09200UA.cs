//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�o�[�R�[�h�ꊇ�o�^                                  //
// �v���O�����T�v   : ���i�o�[�R�[�h�ꊇ�o�^ UI�t���[���N���X                 //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������                                 //
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^ UI�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�o�[�R�[�h�ꊇ�o�^ UI�t���[���N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
	public partial class PMHND09200UA : Form
	{
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
		public PMHND09200UA()
		{
			InitializeComponent();
		}

        // ���i�o�[�R�[�h�ꊇ�o�^ UI�N���X
        private PMHND09210UA _goodsBarCodeRevnForm;

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��ʋN���������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09200UA_Load(object sender, EventArgs e)
		{
            this._goodsBarCodeRevnForm = new PMHND09210UA();
            this._goodsBarCodeRevnForm.TopLevel = false;
            this._goodsBarCodeRevnForm.FormBorderStyle = FormBorderStyle.None;
            this._goodsBarCodeRevnForm.Show();
            this.Controls.Add(this._goodsBarCodeRevnForm);
            this._goodsBarCodeRevnForm.Dock = DockStyle.Fill;
            // ��ʏI������
            this._goodsBarCodeRevnForm.FormClosed += new FormClosedEventHandler(this.GoodsBarCodeRevnForm_FormClosed);
		}

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��ʏI�������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevnForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}
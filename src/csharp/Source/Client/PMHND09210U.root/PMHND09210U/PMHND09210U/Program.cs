//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���i�o�[�R�[�h�ꊇ�o�^�p�N���N���X              //
//                  :   PMHND09210U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms�@�@�@                   //
// Programmer       :   3H ������                                       //
// Date             :   2017/06/12                                      //
//----------------------------------------------------------------------//
//                 Copyright(c)2017 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^ �N���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�o�[�R�[�h�ꊇ�o�^ �N���N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
	static class Program
	{
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new PMHND09210UA());
		}
	}
}
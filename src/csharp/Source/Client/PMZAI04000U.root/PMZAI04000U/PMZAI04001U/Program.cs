using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
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
            System.Windows.Forms.Application.Run(new PMZAI04001UA());
		}
	}
}
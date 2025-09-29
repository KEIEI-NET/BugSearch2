using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
	/// �ޕʌ^���I���K�C�h����N���X
    /// </summary>
    public class SelectionCtgyMdlLnk
    {
        /// <summary>
        /// �ޕʌ^���I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dt">�ޕʌ^����񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(CategoryDataDataTable dt)
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                SelectionForm _Form = new SelectionForm(dt);
                try
                {
                    dlgResult = _Form.ShowDialog();
                }
                finally
                {
                    _Form.Dispose();
                    _Form = null;
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

            return dlgResult;
        }
    }
}

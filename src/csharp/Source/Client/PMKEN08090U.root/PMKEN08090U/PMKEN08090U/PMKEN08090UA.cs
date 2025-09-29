using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �Z�b�g���i�I���K�C�h����N���X
    /// </summary>
    public class SelectionSetParts
    {
        /// <summary>
        /// �Z�b�g���i�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dsParts">���i��񂪓o�^����Ă��� DataSet ���w�肵�܂��B</param>
        /// <returns></returns>
        public static DialogResult ShowDialog(IWin32Window owner,PartsInfoDataSet dsParts)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                SelectionFormSet _Form = new SelectionFormSet(dsParts);
                try
                {
                    // 2009.02.19 >>>
                    //dlgResult = _Form.ShowDialog();
                    dlgResult = _Form.ShowDialog(owner);
                    // 2009.02.19 <<<
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

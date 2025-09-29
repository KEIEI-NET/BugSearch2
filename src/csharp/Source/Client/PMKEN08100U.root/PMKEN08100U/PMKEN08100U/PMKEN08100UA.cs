using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// ��֕��i�I���K�C�h����N���X
    /// </summary>
    /// <remarks>
    /// <br></br>
    /// <br>Update Note	: �I�[�i�[�t�H�[���Ή�</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.19</br>
    /// </remarks>    
    public class SelectionSubstParts
    {
        /// <summary>
        /// ��֕��i�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dsParts">���i��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PartsInfoDataSet dsParts)
        public static DialogResult ShowDialog(IWin32Window owner, PartsInfoDataSet dsParts)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                SelectionFormSb _Form = new SelectionFormSb(dsParts);
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

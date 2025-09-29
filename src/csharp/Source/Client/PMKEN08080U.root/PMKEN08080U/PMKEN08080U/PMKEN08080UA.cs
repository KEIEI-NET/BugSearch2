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
    /// �������i�I���K�C�h����N���X
    /// </summary>
    public class SelectionJoinParts
    {
        /// <summary>
        /// �������i�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dsParts">���i�������ʂ̃f�[�^�Z�b�g</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PartsInfoDataSet dsParts)
        public static DialogResult ShowDialog(IWin32Window owner,PartsInfoDataSet dsParts)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                SelectionFormJ _Form = new SelectionFormJ(dsParts);
                // 2009.02.19 >>>
                //dlgResult = _Form.ShowDialog();
                dlgResult = _Form.ShowDialog(owner);
                // 2009.02.19 <<<
                
                //switch (dsParts.Tables[OfrJoinPartsInfo.TABLENAME_JOIN].Rows.Count)
                //{
                //    case 0:
                //        // �f�[�^���O���̏ꍇ�͖߂�l�� Cancel �̂܂܂ɂ��ďI������
                //        dlgResult = DialogResult.None;
                //        break;
                //    default:
                //        // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                //        SelectionForm _Form = new SelectionForm(dsParts);
                //        try
                //        {
                //            dlgResult = _Form.ShowDialog();
                //        }
                //        finally
                //        {
                //            _Form.Dispose();
                //            _Form = null;
                //        }
                //        break;
                //}
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
            return dlgResult;
        }
    }
}

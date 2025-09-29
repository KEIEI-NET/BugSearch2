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
    /// �Ԏ�I���K�C�h����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ�I���K�C�h�N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2013/05/08 30747 �O�� �L��</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             SCM��Q��10328�Ή� �蓮�񓚎��i�Ԍ����őO��</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SelectionCarKind
    {
        /// <summary>
        /// �Ԏ�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dtCarKind">�Ԏ��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="condition">�^�������̏ꍇ�����������X�V�����ꍇ������܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(PMKEN01010E.CarKindInfoDataTable dtCarKind, CarSearchCondition condition)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            SelectionForm _Form = new SelectionForm(dtCarKind);
            try
            {
                dlgResult = _Form.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    PMKEN01010E.CarKindInfoRow[] row = (PMKEN01010E.CarKindInfoRow[])dtCarKind.Select("SelectionState = True");
                    if (row.Length > 0)
                    {
                        condition.MakerCode = row[0].MakerCode;
                        condition.ModelCode = row[0].ModelCode;
                        condition.ModelSubCode = row[0].ModelSubCode;
                    }
                }
            }
            finally
            {
                _Form.Dispose();
                _Form = null;
            }

            return dlgResult;
        }

        // --- ADD 2013/05/08 �O�� 2013/06/18�z�M�� SCM��Q��10328 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �Ԏ�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="owner">�e���</param>
        /// <param name="dtCarKind">�Ԏ��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="condition">�^�������̏ꍇ�����������X�V�����ꍇ������܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(IWin32Window owner, PMKEN01010E.CarKindInfoDataTable dtCarKind, CarSearchCondition condition)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            SelectionForm _Form = new SelectionForm(dtCarKind);
            try
            {
                dlgResult = _Form.ShowDialog(owner);
                if (dlgResult == DialogResult.OK)
                {
                    PMKEN01010E.CarKindInfoRow[] row = (PMKEN01010E.CarKindInfoRow[])dtCarKind.Select("SelectionState = True");
                    if (row.Length > 0)
                    {
                        condition.MakerCode = row[0].MakerCode;
                        condition.ModelCode = row[0].ModelCode;
                        condition.ModelSubCode = row[0].ModelSubCode;
                    }
                }
            }
            finally
            {
                _Form.Dispose();
                _Form = null;
            }

            return dlgResult;
        }
        // --- ADD 2013/05/08 �O�� 2013/06/18�z�M�� SCM��Q��10328 ---------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}

using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// TBO�I���K�C�h����N���X
    /// </summary>
    public class SelectionCarInfoJoinParts
    {
        /// <summary>
        /// TBO�I���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="dsParts">���i��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        /// <br>Update Note : 2009/11/13 ����� �ێ�˗��B�Ή�</br>
        /// <br>            �@ ��ʕ\���̕ύX</br>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PMKEN01010E carInfo, PartsInfoDataSet dsParts)
        public static DialogResult ShowDialog(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet dsParts)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                SelectionForm _Form = new SelectionForm(carInfo, dsParts);
                try
                {
                    // --- UPD 2009/11/13 ---------->>>>> 
                    if (_Form.EquipmentGenreCdHaveFlag)
                    {
                        dlgResult = _Form.ShowDialog(owner);
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    "SelectionCarInfoJoinParts",						// �A�Z���u��ID
                                    "�^�C����o�b�e���[��I�C���̏�񂪑��݂��܂���B",   // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��
                        return dlgResult;
                    }
                    // --- UPD 2009/11/13 ----------<<<<<
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

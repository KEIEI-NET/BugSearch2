using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// ����i�ԑI���K�C�h����N���X
    /// </summary>
    public class SelectionSamePartsNo
    {

        /// <summary>
        /// ����i�ԑI���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dsParts">���i��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="Mode"> 0:�i�Ԍ���[�}�X�����p] 1:�i�Ԍ������� 2:�i�Ԍ���[�G���g���p] 3:�݌ɑg��</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PartsInfoDataSet dsParts, int Mode)
        public static DialogResult ShowDialog(IWin32Window owner, PartsInfoDataSet dsParts, int Mode)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;

            //int iCnt=
            //dsParts.Tables[OfrPartsInfo.TABLENAME_PARTS].Rows.Count + dsParts.Tables[OfrJoinPartsInfo.TABLENAME_JOIN].Rows.Count;

            //try
            //{
            // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
            SelectionSamePartsNoParts _Form = new SelectionSamePartsNoParts(dsParts, Mode, null);
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

            return dlgResult;
        }

        /// <summary>
        /// ����i�ԑI���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="dsParts">���i��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="Mode"> 0:�i�Ԍ��� 1:�i�Ԍ������� 2:�i�Ԍ���[�G���g���p] 3:�݌ɑg��</param>
        /// <param name="makerList">�\�����郁�[�J�R�[�h��List�Ŏw�肵�܂��B</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PartsInfoDataSet dsParts, int Mode, List<int> makerList)
        public static DialogResult ShowDialog(IWin32Window owner,PartsInfoDataSet dsParts, int Mode, List<int> makerList)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;

            //int iCnt=
            //dsParts.Tables[OfrPartsInfo.TABLENAME_PARTS].Rows.Count + dsParts.Tables[OfrJoinPartsInfo.TABLENAME_JOIN].Rows.Count;

            //try
            //{
            // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
            SelectionSamePartsNoParts _Form = new SelectionSamePartsNoParts(dsParts, Mode, makerList);
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

            return dlgResult;
        }


    }
}

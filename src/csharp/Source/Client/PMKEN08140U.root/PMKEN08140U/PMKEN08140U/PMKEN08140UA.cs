using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �a�k�R�[�h�I���K�C�h����N���X
    /// </summary>
    public class SelectionOfrBL
    {
        // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �a�k�R�[�h�I���K�C�h�̋N�����[�h
        /// </summary>
        public enum GuideMode
        {
            /// <summary>BL�R�[�h</summary>
            BLCode = 0,
            /// <summary>���ʃK�C�h</summary>
            PartsPos = 1,
            /// <summary>BL�R�[�h�K�C�h�K�C�h</summary>
            BLGuide = 2
        }
        // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// �a�k�R�[�h�I���K�C�h��\�����܂��B[���Ӑ�w��Ȃ��F���ʐݒ�̂�]
        /// </summary>
        /// <param name="lstBlCd">�I�����ꂽBL�R�[�h�̃��X�g</param>
        /// <param name="blTable">�a�k�R�[�h��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="blList">BL�R�[�h���X�g</param>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(out List<int> lstBlCd, BLInfoDataTable blTable,
                Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SelectionForm _Form = new SelectionForm(blTable, blList, sectionCd, 0);
            SelectionForm _Form = new SelectionForm(blTable, blList, sectionCd, 0, GuideMode.BLCode);
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            try
            {
                dlgResult = _Form.ShowDialog(out lstBlCd);
            }
            finally
            {
                _Form.Dispose();
                _Form = null;
            }

            return dlgResult;
        }

        /// <summary>
        /// �a�k�R�[�h�I���K�C�h��\�����܂��B[���Ӑ�w�肠��F���ʐݒ�y�юw��̓��Ӑ�̕��ʃ}�X�^]
        /// </summary>
        /// <param name="lstBlCd">�I�����ꂽBL�R�[�h�̃��X�g</param>
        /// <param name="blTable">�a�k�R�[�h��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="blList">BL�R�[�h���X�g</param>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�Ȃ��ꍇ�͂O)</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(out List<int> lstBlCd, BLInfoDataTable blTable, 
                Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SelectionForm _Form = new SelectionForm(blTable, blList, sectionCd, customerCode);
            SelectionForm _Form = new SelectionForm(blTable, blList, sectionCd, customerCode, GuideMode.BLCode);
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                dlgResult = _Form.ShowDialog(out lstBlCd);
            }
            finally
            {
                _Form.Dispose();
                _Form = null;
            }

            return dlgResult;
        }

        // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �a�k�R�[�h�I���K�C�h��\�����܂��B[���Ӑ�w�肠��F���ʐݒ�y�юw��̓��Ӑ�̕��ʃ}�X�^]
        /// </summary>
        /// <param name="lstBlCd">�I�����ꂽBL�R�[�h�̃��X�g</param>
        /// <param name="blTable">�a�k�R�[�h��񂪓o�^����Ă��� DataTable ���w�肵�܂��B</param>
        /// <param name="blList">BL�R�[�h���X�g</param>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�Ȃ��ꍇ�͂O)</param>
        /// <param name="guideMode">�K�C�h�@�����[�h</param>
        /// <returns>DialogResult �̂P�̒l��Ԃ��܂��B(OK or Cancel)</returns>
        public static DialogResult ShowDialog(out List<int> lstBlCd, BLInfoDataTable blTable,
                Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode, GuideMode guideMode)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            SelectionForm _Form = new SelectionForm(blTable, blList, sectionCd, customerCode, guideMode);
            try
            {
                dlgResult = _Form.ShowDialog(out lstBlCd);
            }
            finally
            {
                _Form.Dispose();
                _Form = null;
            }

            return dlgResult;
        }
        // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}

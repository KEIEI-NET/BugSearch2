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
    /// 車種選択ガイド操作クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種選択ガイドクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2013/05/08 30747 三戸 伸悟</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             SCM障害№10328対応 手動回答時品番検索最前面</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SelectionCarKind
    {
        /// <summary>
        /// 車種選択ガイドを表示します。
        /// </summary>
        /// <param name="dtCarKind">車種情報が登録されている DataTable を指定します。</param>
        /// <param name="condition">型式検索の場合検索条件が更新される場合があります。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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

        // --- ADD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 車種選択ガイドを表示します。
        /// </summary>
        /// <param name="owner">親画面</param>
        /// <param name="dtCarKind">車種情報が登録されている DataTable を指定します。</param>
        /// <param name="condition">型式検索の場合検索条件が更新される場合があります。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
        // --- ADD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 ---------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}

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
    /// 優良検索部品選択ガイド操作クラス
    /// </summary>
    public class SelectionPrimeSearchParts
    {
        /// <summary>
        /// 優良検索部品選択ガイドを表示します。
        /// </summary>
        /// <param name="dsParts">型式情報が登録されている DataTable を指定します。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PartsInfoDataSet dsParts)
        public static DialogResult ShowDialog(IWin32Window owner,PartsInfoDataSet dsParts)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // データが複数件存在する場合は選択画面を表示する
                SelectionPrimeBLParts _Form = new SelectionPrimeBLParts(dsParts);
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
                throw new SystemException( ex.Message );
            }
            return dlgResult;
        }
    }
}

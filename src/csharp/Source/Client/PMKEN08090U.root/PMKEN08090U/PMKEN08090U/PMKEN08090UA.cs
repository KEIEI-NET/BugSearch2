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
    /// セット部品選択ガイド操作クラス
    /// </summary>
    public class SelectionSetParts
    {
        /// <summary>
        /// セット部品選択ガイドを表示します。
        /// </summary>
        /// <param name="dsParts">部品情報が登録されている DataSet を指定します。</param>
        /// <returns></returns>
        public static DialogResult ShowDialog(IWin32Window owner,PartsInfoDataSet dsParts)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                // データが複数件存在する場合は選択画面を表示する
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

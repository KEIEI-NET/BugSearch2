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
	/// 類別型式選択ガイド操作クラス
    /// </summary>
    public class SelectionCtgyMdlLnk
    {
        /// <summary>
        /// 類別型式選択ガイドを表示します。
        /// </summary>
        /// <param name="dt">類別型式情報が登録されている DataTable を指定します。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        public static DialogResult ShowDialog(CategoryDataDataTable dt)
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // データが複数件存在する場合は選択画面を表示する
                SelectionForm _Form = new SelectionForm(dt);
                try
                {
                    dlgResult = _Form.ShowDialog();
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

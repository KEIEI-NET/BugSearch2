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
    /// 結合部品選択ガイド操作クラス
    /// </summary>
    public class SelectionJoinParts
    {
        /// <summary>
        /// 結合部品選択ガイドを表示します。
        /// </summary>
        /// <param name="dsParts">部品検索結果のデータセット</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
                //        // データが０件の場合は戻り値を Cancel のままにして終了する
                //        dlgResult = DialogResult.None;
                //        break;
                //    default:
                //        // データが複数件存在する場合は選択画面を表示する
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

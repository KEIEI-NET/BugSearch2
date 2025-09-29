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
    /// TBO選択ガイド操作クラス
    /// </summary>
    public class SelectionCarInfoJoinParts
    {
        /// <summary>
        /// TBO選択ガイドを表示します。
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="dsParts">部品情報が登録されている DataTable を指定します。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        /// <br>Update Note : 2009/11/13 李占川 保守依頼③対応</br>
        /// <br>            　 画面表示の変更</br>
        // 2009.02.19 >>>
        //public static DialogResult ShowDialog(PMKEN01010E carInfo, PartsInfoDataSet dsParts)
        public static DialogResult ShowDialog(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet dsParts)
        // 2009.02.19 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;
            try
            {
                // データが複数件存在する場合は選択画面を表示する
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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    "SelectionCarInfoJoinParts",						// アセンブリID
                                    "タイヤ･バッテリー･オイルの情報が存在しません。",   // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);								// 表示するボタン
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

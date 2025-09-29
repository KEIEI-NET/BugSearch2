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
    /// 同一品番選択ガイド操作クラス
    /// </summary>
    public class SelectionSamePartsNo
    {

        /// <summary>
        /// 同一品番選択ガイドを表示します。
        /// </summary>
        /// <param name="dsParts">部品情報が登録されている DataTable を指定します。</param>
        /// <param name="Mode"> 0:品番検索[マスメン用] 1:品番結合検索 2:品番検索[エントリ用] 3:在庫組立</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
            // データが複数件存在する場合は選択画面を表示する
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
        /// 同一品番選択ガイドを表示します。
        /// </summary>
        /// <param name="dsParts">部品情報が登録されている DataTable を指定します。</param>
        /// <param name="Mode"> 0:品番検索 1:品番結合検索 2:品番検索[エントリ用] 3:在庫組立</param>
        /// <param name="makerList">表示するメーカコードをListで指定します。</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
            // データが複数件存在する場合は選択画面を表示する
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

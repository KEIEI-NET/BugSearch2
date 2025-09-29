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
    /// ＢＬコード選択ガイド操作クラス
    /// </summary>
    public class SelectionOfrBL
    {
        // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ＢＬコード選択ガイドの起動モード
        /// </summary>
        public enum GuideMode
        {
            /// <summary>BLコード</summary>
            BLCode = 0,
            /// <summary>部位ガイド</summary>
            PartsPos = 1,
            /// <summary>BLコードガイドガイド</summary>
            BLGuide = 2
        }
        // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// ＢＬコード選択ガイドを表示します。[得意先指定なし：共通設定のみ]
        /// </summary>
        /// <param name="lstBlCd">選択されたBLコードのリスト</param>
        /// <param name="blTable">ＢＬコード情報が登録されている DataTable を指定します。</param>
        /// <param name="blList">BLコードリスト</param>
        /// <param name="sectionCd">拠点コード</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
        /// ＢＬコード選択ガイドを表示します。[得意先指定あり：共通設定及び指定の得意先の部位マスタ]
        /// </summary>
        /// <param name="lstBlCd">選択されたBLコードのリスト</param>
        /// <param name="blTable">ＢＬコード情報が登録されている DataTable を指定します。</param>
        /// <param name="blList">BLコードリスト</param>
        /// <param name="sectionCd">拠点コード</param>
        /// <param name="customerCode">得意先コード(ない場合は０)</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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
        /// ＢＬコード選択ガイドを表示します。[得意先指定あり：共通設定及び指定の得意先の部位マスタ]
        /// </summary>
        /// <param name="lstBlCd">選択されたBLコードのリスト</param>
        /// <param name="blTable">ＢＬコード情報が登録されている DataTable を指定します。</param>
        /// <param name="blList">BLコードリスト</param>
        /// <param name="sectionCd">拠点コード</param>
        /// <param name="customerCode">得意先コード(ない場合は０)</param>
        /// <param name="guideMode">ガイド機動モード</param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
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

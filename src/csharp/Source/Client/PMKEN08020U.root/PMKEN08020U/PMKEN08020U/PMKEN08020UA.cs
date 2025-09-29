using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 型式選択ガイド操作クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式選択ガイド操作クラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.26</br>
    /// <br></br>
    /// <br>Update Note: 2013/05/08 30747 三戸 伸悟</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             SCM障害№10328対応 手動回答時品番検索最前面</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SelectionCarModel
    {
        /// <summary>
        /// 型式選択ガイドを表示します。
        /// </summary>
        /// <param name="dsCar"></param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        // 2011/03/08 >>>
        //public static DialogResult ShowDialog(PMKEN01010E dsCar)
        public static DialogResult ShowDialog(PMKEN01010E dsCar, int produceTypeOfYear, int searchFrameNo)
        // 2011/03/08 <<<
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                SelectionForm _Form = new SelectionForm(dsCar);
                // 2011/03/08 Add >>>
                _Form.InputProduceTypeOfYear = produceTypeOfYear;
                _Form.InputSearchFrameNo = searchFrameNo;
                // 2011/03/08 Add <<<
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

        // 2011/03/08 Add >>>
        /// <summary>
        /// 型式選択ガイドを表示します。
        /// </summary>
        /// <param name="dsCar"></param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        public static DialogResult ShowDialog(PMKEN01010E dsCar)
        {
            return ShowDialog(dsCar, 0, 0);
        }
        // 2011/03/08 Add <<<

        // --- ADD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 型式選択ガイドを表示します。
        /// </summary>
        /// <param name="owner">親画面</param>
        /// <param name="dsCar"></param>
        /// <param name="produceTypeOfYear"></param>
        /// <param name="searchFrameNo"></param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        public static DialogResult ShowDialog(IWin32Window owner, PMKEN01010E dsCar, int produceTypeOfYear, int searchFrameNo)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                SelectionForm _Form = new SelectionForm(dsCar);
                _Form.InputProduceTypeOfYear = produceTypeOfYear;
                _Form.InputSearchFrameNo = searchFrameNo;
                try
                {
                    dlgResult = _Form.ShowDialog(owner);
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

        /// <summary>
        /// 型式選択ガイドを表示します。
        /// </summary>
        /// <param name="owner">親画面</param>
        /// <param name="dsCar"></param>
        /// <returns>DialogResult の１つの値を返します。(OK or Cancel)</returns>
        public static DialogResult ShowDialog(IWin32Window owner, PMKEN01010E dsCar)
        {
            return ShowDialog(owner, dsCar, 0, 0);
        }
        // --- ADD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 ---------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using DataDynamics.ActiveReports;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票レポートユーティリティクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票のアクティブレポート関連のユーティリティクラスです</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.08.08</br>
    /// <br>UpdateNote	: 2007.11.29 22024 寺坂 誉志</br>
	/// <br>			:  1.PaperKind設定メソッドを追加</br>
    /// </remarks>
    public class SFANL08235CE : SFANL08235CD
    {
        //================================================================================
        //  public methods
        //================================================================================
        #region public methods
        
        #region 条件出力用のテキストボックスのプロパティを整えます
        /// <summary>
        /// 条件出力用のテキストボックスのプロパティを整えます
        /// </summary>
        /// <param name="trgtTextBox">対象コントロールボックス</param>
        /// <param name="printDataSet">印刷用データセット</param>
        /// <returns>正常：0　異常：-1</returns>
        static public int SetExrCndTextBox(ref TextBox trgtTextBox, DataSet printDataSet)
        {
            StringCollection extrCondsStr = new StringCollection();
            StringBuilder sb = new StringBuilder();
            int status = 0;
            int maxLength = 0;

            //プロパティ設定
            trgtTextBox.MultiLine = true;
            trgtTextBox.CanGrow = false;
            try
            {
                maxLength = GetARControlByteLength(trgtTextBox);
                // 抽出条件を取得
                foreach (DataRow dr in printDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows)
                {
                    EditCondition(ref extrCondsStr, (string)dr[CT_EXTRACTCONDS], maxLength);
                }
                foreach (string area in extrCondsStr)
                {
                    sb.Append(area + "\n");
                }
                trgtTextBox.Text = sb.ToString();
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion

        #region スクリプトで使用するDLLを読み込みます
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rpt"></param>
        static public void AddScriptReference(ref ActiveReport3 rpt)
        {
            rpt.AddScriptReference("SFCMN00001U.dll");
            rpt.AddScriptReference("SFCMN00002C.dll");
            rpt.AddScriptReference("SFANL08235C.dll");
            rpt.AddScriptReference("SFCMN00297C.dll");
        }
        #endregion

        #region 背景画像を合成(Overlay)したレポートを返します
        /// <summary>
        /// 背景画像を合成(Overlay)したレポートを返します
        /// </summary>
        /// <param name="prtRpt">印刷用レポート</param>
        /// <param name="bgImage">背景画像</param>
        /// <param name="prtPprBgImageRowPos">背景画像縦位置</param>
        /// <param name="prtPprBgImageColPos">背景画像横位置</param>
        /// <returns></returns>
        static public ActiveReport3 OverlayImage(ActiveReport3 prtRpt, Bitmap bgImage, double prtPprBgImageRowPos, double prtPprBgImageColPos)
        {
            prtRpt.Run();
            // 背景画像用のレポート作成
            if (bgImage != null)
            {
                BackImgReport overlayForm = new BackImgReport();
                int pagecnt = prtRpt.Document.Pages.Count;
                DataTable dt = new DataTable("Table1");
                dt.Columns.Add("pict", typeof(System.Drawing.Image));

                //背景用レポートのサイズ調整
                //overlayForm.SetRprSize(prtRpt.PageSettings, prtPprBgImageRowPos, prtPprBgImageColPos);
                overlayForm.SetRprSize(prtRpt, prtPprBgImageRowPos, prtPprBgImageColPos);


                //背景セット
                for (int j = 0; j < pagecnt; j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["pict"] = bgImage;
                    dt.Rows.Add(dr);
                }
                overlayForm.DataSource = dt;
                overlayForm.Run(false);

                if ((prtRpt.Document.Pages.Count > 0) && (overlayForm.Document.Pages.Count > 0))
                {
                    for (int j = 0; j < pagecnt; j++)
                    {
                        //オーバーレイで背景画像をセット
                        overlayForm.Document.Pages[j].Overlay(prtRpt.Document.Pages[j]);
                    }
                }
                return (ActiveReport3)overlayForm;
            }
            else
            {
                return prtRpt;
            }
        }
        #endregion

////////////////////////////////////////////// 2007.11.29 TERASAKA ADD STA //
		#region プリンタに設定されているPaperKindを設定します
		/// <summary>
		/// 有効用紙設定処理
		/// </summary>
		/// <param name="rpt">アクティブレポートオブジェクト</param>
		/// <remarks>
		/// <br>Note		: プリンタの用紙設定が適切か判断し、不適切な場合は設定をカスタム用紙にします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.29</br>
		/// </remarks>
		static public void SetValidPaperKind(ActiveReport3 rpt)
		{
			bool isValidPaperKind = false;

			foreach (System.Drawing.Printing.PaperSize paperSize in rpt.Document.Printer.PaperSizes)
			{
				if (paperSize.Kind == rpt.PageSettings.PaperKind)
				{
					isValidPaperKind = true;
					break;
				}
			}

			if (!isValidPaperKind)
				rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
		}
		#endregion
// 2007.11.29 TERASAKA ADD END //////////////////////////////////////////////
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [DataViewに設定するソート順文字列を生成します]
        /// <summary>
        /// ソート文字列取得処理
        /// </summary>
        /// <param name="frePprSrtOWorkList"></param>
        /// <returns></returns>
        public static string GetSortString( List<FrePprSrtOWork> frePprSrtOWorkList )
        {
            return GetSortStringProc( frePprSrtOWorkList );
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        #endregion


        //================================================================================
        //  private methods
        //================================================================================
        #region private methods

        #region 抽出条件文字列編集
        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <param name="maxStringLength">コントロールに表示するシフトジスの文字列長</param>
        static private void EditCondition(ref StringCollection editArea, string target, int maxStringLength)
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);
            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // 格納エリアのバイト数算出
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= maxStringLength)
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;

                    editArea[i] += target;
                    break;
                }
            }
            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion

        #region GetARControlByteLength レポートコントロールバイトレングス取得処理
        /// <summary>
        /// レポートコントロールバイトレングス取得処理
        /// </summary>
        /// <param name="control">取得対象レポートコントロール（テキストボックス・ラベルのみ対象）</param>
        /// <returns>取得対象レポートコントロールのバイトレングス</returns>
        /// <remarks>
        /// <br>Note       : 取得対象レポートコントロールに入る最大文字数(バイトレングス)を取得します。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.08.08</br>
        /// </remarks>
        static private int GetARControlByteLength(DataDynamics.ActiveReports.ARControl control)
        {
            int result = 0;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            Graphics graphics = label.CreateGraphics();

            // レポートコントロールフォント取得
            Font controlFont;

            if (control is DataDynamics.ActiveReports.TextBox)
            {
                controlFont = ((DataDynamics.ActiveReports.TextBox)control).Font;
            }
            else if (control is DataDynamics.ActiveReports.Label)
            {
                controlFont = ((DataDynamics.ActiveReports.Label)control).Font;
            }
            else
            {
                return result;
            }

            // レポートコントロールピクセル幅算出（96ppiで換算）
            int controlWidth = Convert.ToInt32(control.Width * 96.0f);
            int stringWidth = Convert.ToInt32(graphics.MeasureString(string.Empty.PadRight(result++, 'X'), controlFont).Width);

            // 文字列の幅が超えるまで繰り返す
            while (stringWidth < controlWidth)
            {
                stringWidth = Convert.ToInt32(graphics.MeasureString(string.Empty.PadRight(result++, 'X'), controlFont).Width);
            }

            return TStrConv.SizeCountSJIS(string.Empty.PadRight(--result, 'X'));
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [ソート文字列生成処理]
        /// <summary>
        /// ソート文字列生成処理
        /// </summary>
        /// <param name="frePprSrtOWorkList"></param>
        /// <returns></returns>
        private static string GetSortStringProc( List<FrePprSrtOWork> frePprSrtOWorkList )
        {
            string sortString = string.Empty;
            frePprSrtOWorkList.Sort( new FrePprSrtOWorkComparer() );

            foreach ( FrePprSrtOWork srtO in frePprSrtOWorkList )
            {
                if ( srtO.LogicalDeleteCode != 0 ) continue;

                string sortWay;
                switch ( srtO.SortingOrderDivCd )
                {
                    // 0:ソート無
                    default:
                    case 0:
                        // 次項目へ
                        continue;
                    // 1:昇順
                    case 1: sortWay = "ASC"; break;
                    // 2:降順
                    case 2: sortWay = "DESC"; break;
                }

                // 2項目以上
                if ( sortString != string.Empty )
                {
                    sortString += ", ";
                }

                // ソート文字列追加
                sortString += string.Format( "{0}.{1} {2}",
                                                srtO.FileNm.ToUpper(),
                                                srtO.DDName.ToUpper(),
                                                sortWay );
            }

            return sortString;
        }
        # region [ソート順位設定比較クラス(ソート用)]
        /// <summary>
        /// ソート順位設定比較クラス(ソート用)
        /// </summary>
        private class FrePprSrtOWorkComparer : IComparer<FrePprSrtOWork>
        {
            public int Compare( FrePprSrtOWork x, FrePprSrtOWork y )
            {
                return x.SortingOrder.CompareTo( y.SortingOrder );
            }
        }
        # endregion
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        #endregion
        
    }
}
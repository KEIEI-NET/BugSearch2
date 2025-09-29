using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
// 2010/04/30 Add >>>
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
// 2010/04/30 Add <<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 条件設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 条件設定のフォームクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/02/18</br>
    /// <br>Update Note: 2010/04/09 980035 金沢 貞義</br>
    /// <br>            ・返品（合計）、値引（合計）、純仕入（合計）が単体で選択できないのを修正
    /// </remarks>
    public partial class PMKOU04110UD : Form
    {
        public PMKOU04110UD()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;
        }

        private ImageList _imageList16 = null;

        public List<string> _titleList;
        public List<int> _graphPara;
        // 2010/04/30 Add >>>
        public List<int> _graphPara2;
        public int _graphId;
        // 2010/04/30 Add <<<

        // グラフ種別区分
        private const string GRAPH_LINE = "折れ線グラフ";
        private const string GRAPH_BAR = "棒グラフ";
        private const string GRAPH_PIE = "円グラフ";
        // 2010/04/30 Add >>>
        private const string GRAPH_RADAR = "レーダー";
        private const string GRAPH_LINEBAR = "折れ線＋棒グラフ";

        private const string GRAPH_LINE_L = "折れ線グラフ(大)";
        private const string GRAPH_LINE_S = "折れ線グラフ(小)";
        private const string GRAPH_BAR_L = "棒グラフ(大)";
        private const string GRAPH_BAR_S = "棒グラフ(小)";
        // 2010/04/30 Add <<<

        /// <summary>
        /// 呼出制御処理
        /// </summary>
        /// <param name="owner">呼出元オブジェクト</param>
        public DialogResult ShowWindows(IWin32Window owner)
        {
            // 画面の設定
            this.ShowInTaskbar = false;

            return this.ShowDialog(owner);
        }

        // 2010/04/30 Add >>>
        /// <summary>
        /// 項目リスト列挙体
        /// </summary>
        public enum ItemList
        {
            /// <summary>値引（在庫）</summary>
            ST_DISCOUNT = 1,
            /// <summary>返品（在庫）</summary>
            ST_RETGOODS,
            /// <summary>純仕入（在庫）</summary>
            ST_GSTOCK,
            /// <summary>仕入（在庫）</summary>
            ST_STOCK,
            /// <summary>値引（取寄）</summary>
            OR_DISCOUNT,
            /// <summary>返品（取寄）</summary>
            OR_RETGOODS,
            /// <summary>純仕入（取寄）</summary>
            OR_GSTOCK,
            /// <summary>仕入（取寄）</summary>
            OR_STOCK,
            /// <summary>値引（合計）</summary>
            TO_DISCOUNT,
            /// <summary>返品（合計）</summary>
            TO_RETGOODS,
            /// <summary>純仕入（合計）</summary>
            TO_GSTOCK,
            /// <summary>仕入（合計）</summary>
            TO_STOCK
        }
        // 2010/04/30 Add <<<

        # region ※Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKOU04110UD());
        }
        # endregion

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br> 
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void Ok_ultraButton_Click(object sender, EventArgs e)
        {
            int chkflg = 0;
            //for (int ix = 0; ix < 9; ix++)// DEL 2010/04/09
            for (int ix = 0; ix < 12; ix++) // ADD 2010/04/09
            {
                switch (ix)
                {
                    case 0: { if (this.uCheckEditor_Para01.Checked == true) chkflg++; break; }
                    case 1: { if (this.uCheckEditor_Para02.Checked == true) chkflg++; break; }
                    case 2: { if (this.uCheckEditor_Para03.Checked == true) chkflg++; break; }
                    case 3: { if (this.uCheckEditor_Para04.Checked == true) chkflg++; break; }
                    case 4: { if (this.uCheckEditor_Para05.Checked == true) chkflg++; break; }
                    case 5: { if (this.uCheckEditor_Para06.Checked == true) chkflg++; break; }
                    case 6: { if (this.uCheckEditor_Para07.Checked == true) chkflg++; break; }
                    case 7: { if (this.uCheckEditor_Para08.Checked == true) chkflg++; break; }
                    case 8: { if (this.uCheckEditor_Para09.Checked == true) chkflg++; break; }
                    case 9: { if (this.uCheckEditor_Para10.Checked == true) chkflg++; break; }
                    case 10: { if (this.uCheckEditor_Para11.Checked == true) chkflg++; break; }
                    case 11: { if (this.uCheckEditor_Para12.Checked == true) chkflg++; break; }
                }
            }
            if (chkflg == 0)
            {
                return;
            }

            this.DialogResult = DialogResult.Cancel;

            int flg;
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                _graphPara[0] = this.tComboEditor_GraphStyle.SelectedIndex;

                for (int ix = 1; ix < _graphPara.Count; ix++) _graphPara[ix] = 1;
                // 2010/04/30 Del >>>
                //if (this.uCheckEditor_Para01.Checked == true) _graphPara[1] = 0;
                //if (this.uCheckEditor_Para02.Checked == true) _graphPara[2] = 0;
                //if (this.uCheckEditor_Para03.Checked == true) _graphPara[3] = 0;
                //if (this.uCheckEditor_Para04.Checked == true) _graphPara[4] = 0;
                //if (this.uCheckEditor_Para05.Checked == true) _graphPara[5] = 0;
                //if (this.uCheckEditor_Para06.Checked == true) _graphPara[6] = 0;
                //if (this.uCheckEditor_Para07.Checked == true) _graphPara[7] = 0;
                //if (this.uCheckEditor_Para08.Checked == true) _graphPara[8] = 0;
                //if (this.uCheckEditor_Para09.Checked == true) _graphPara[9] = 0;
                //if (this.uCheckEditor_Para10.Checked == true) _graphPara[10] = 0;
                //if (this.uCheckEditor_Para11.Checked == true) _graphPara[11] = 0;
                //if (this.uCheckEditor_Para12.Checked == true) _graphPara[12] = 0;
                // 2010/04/30 Del <<<
                // 2010/04/30 Add >>>
                if (this.uCheckEditor_Para01.Checked == true) _graphPara[(int)ItemList.ST_STOCK] = 0;
                if (this.uCheckEditor_Para02.Checked == true) _graphPara[(int)ItemList.ST_RETGOODS] = 0;
                if (this.uCheckEditor_Para03.Checked == true) _graphPara[(int)ItemList.ST_DISCOUNT] = 0;
                if (this.uCheckEditor_Para04.Checked == true) _graphPara[(int)ItemList.ST_GSTOCK] = 0;
                if (this.uCheckEditor_Para05.Checked == true) _graphPara[(int)ItemList.OR_STOCK] = 0;
                if (this.uCheckEditor_Para06.Checked == true) _graphPara[(int)ItemList.OR_RETGOODS] = 0;
                if (this.uCheckEditor_Para07.Checked == true) _graphPara[(int)ItemList.OR_DISCOUNT] = 0;
                if (this.uCheckEditor_Para08.Checked == true) _graphPara[(int)ItemList.OR_GSTOCK] = 0;
                if (this.uCheckEditor_Para09.Checked == true) _graphPara[(int)ItemList.TO_STOCK] = 0;
                if (this.uCheckEditor_Para10.Checked == true) _graphPara[(int)ItemList.TO_RETGOODS] = 0;
                if (this.uCheckEditor_Para11.Checked == true) _graphPara[(int)ItemList.TO_DISCOUNT] = 0;
                if (this.uCheckEditor_Para12.Checked == true) _graphPara[(int)ItemList.TO_GSTOCK] = 0;

                if (this.tComboEditor1.SelectedIndex != -1) _graphPara2[(int)ItemList.ST_STOCK] = this.tComboEditor1.SelectedIndex;
                if (this.tComboEditor2.SelectedIndex != -1) _graphPara2[(int)ItemList.ST_RETGOODS] = this.tComboEditor2.SelectedIndex;
                if (this.tComboEditor3.SelectedIndex != -1) _graphPara2[(int)ItemList.ST_DISCOUNT] = this.tComboEditor3.SelectedIndex;
                if (this.tComboEditor4.SelectedIndex != -1) _graphPara2[(int)ItemList.ST_GSTOCK] = this.tComboEditor4.SelectedIndex;
                if (this.tComboEditor5.SelectedIndex != -1) _graphPara2[(int)ItemList.OR_STOCK] = this.tComboEditor5.SelectedIndex;
                if (this.tComboEditor6.SelectedIndex != -1) _graphPara2[(int)ItemList.OR_RETGOODS] = this.tComboEditor6.SelectedIndex;
                if (this.tComboEditor7.SelectedIndex != -1) _graphPara2[(int)ItemList.OR_DISCOUNT] = this.tComboEditor7.SelectedIndex;
                if (this.tComboEditor8.SelectedIndex != -1) _graphPara2[(int)ItemList.OR_GSTOCK] = this.tComboEditor8.SelectedIndex;
                if (this.tComboEditor9.SelectedIndex != -1) _graphPara2[(int)ItemList.TO_STOCK] = this.tComboEditor9.SelectedIndex;
                if (this.tComboEditor10.SelectedIndex != -1) _graphPara2[(int)ItemList.TO_RETGOODS] = this.tComboEditor10.SelectedIndex;
                if (this.tComboEditor11.SelectedIndex != -1) _graphPara2[(int)ItemList.TO_DISCOUNT] = this.tComboEditor11.SelectedIndex;
                if (this.tComboEditor12.SelectedIndex != -1) _graphPara2[(int)ItemList.TO_GSTOCK] = this.tComboEditor12.SelectedIndex;
                // 2010/04/30 Add <<<
            }
            else
            {
                _graphPara.Add(this.tComboEditor_GraphStyle.SelectedIndex);
                // 2010/04/30 Del >>>
                //if (this.uCheckEditor_Para01.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para02.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para03.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para04.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para05.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para06.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para07.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para08.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para09.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para10.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para11.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                //if (this.uCheckEditor_Para12.Checked == true) flg = 0;
                //else flg = 1;
                //_graphPara.Add(flg);
                // 2010/04/30 Del <<<
                // 2010/04/30 Add >>>
                if (this.uCheckEditor_Para03.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para02.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para04.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para01.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para07.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para06.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para08.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para05.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para11.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para10.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para12.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para09.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);

                _graphPara2.Add(_graphId);
                _graphPara2.Add(this.tComboEditor3.SelectedIndex);
                _graphPara2.Add(this.tComboEditor2.SelectedIndex);
                _graphPara2.Add(this.tComboEditor4.SelectedIndex);
                _graphPara2.Add(this.tComboEditor1.SelectedIndex);
                _graphPara2.Add(this.tComboEditor7.SelectedIndex);
                _graphPara2.Add(this.tComboEditor6.SelectedIndex);
                _graphPara2.Add(this.tComboEditor8.SelectedIndex);
                _graphPara2.Add(this.tComboEditor5.SelectedIndex);
                _graphPara2.Add(this.tComboEditor11.SelectedIndex);
                _graphPara2.Add(this.tComboEditor10.SelectedIndex);
                _graphPara2.Add(this.tComboEditor12.SelectedIndex);
                _graphPara2.Add(this.tComboEditor9.SelectedIndex);
                // 2010/04/30 Add <<<
            }

            // 2010/04/30 Add >>>
            List<List<int>> saveList = new List<List<int>>();
            saveList.Add(_graphPara);
            saveList.Add(_graphPara2);
            // 設定内容保存
            SaveToFiles(saveList);
            // 2010/04/30 Add <<<

            this.Close();
            //this.Hide();
        }

        internal static void ShowWindows(AnalysisChartViewForm PMKOU04110UB)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Ok_ultraButton.ImageList = this._imageList16;
            this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;

            this.uCheckEditor_Para01.Text = _titleList[0].ToString();
            this.uCheckEditor_Para02.Text = _titleList[1].ToString();
            this.uCheckEditor_Para03.Text = _titleList[2].ToString();
            this.uCheckEditor_Para04.Text = _titleList[3].ToString();
            this.uCheckEditor_Para05.Text = _titleList[4].ToString();
            this.uCheckEditor_Para06.Text = _titleList[5].ToString();
            this.uCheckEditor_Para07.Text = _titleList[6].ToString();
            this.uCheckEditor_Para08.Text = _titleList[7].ToString();
            this.uCheckEditor_Para09.Text = _titleList[8].ToString();
            this.uCheckEditor_Para10.Text = _titleList[9].ToString();
            this.uCheckEditor_Para11.Text = _titleList[10].ToString();
            this.uCheckEditor_Para12.Text = _titleList[11].ToString();

            // グラフ種別のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.tComboEditor_GraphStyle.Items.Clear();
            this.tComboEditor_GraphStyle.Items.Add(0, GRAPH_BAR);
            this.tComboEditor_GraphStyle.Items.Add(1, GRAPH_LINE);
            this.tComboEditor_GraphStyle.Items.Add(2, GRAPH_PIE);
            // 2010/04/30 Add >>>
            this.tComboEditor_GraphStyle.Items.Add(3, GRAPH_RADAR);
            this.tComboEditor_GraphStyle.Items.Add(4, GRAPH_LINEBAR);
            // 2010/04/30 Add <<<
            this.tComboEditor_GraphStyle.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                this.tComboEditor_GraphStyle.SelectedIndex = _graphPara[0];
                // 2010/04/30 Del >>>
                //if (_graphPara[1] == 0) this.uCheckEditor_Para01.Checked = false;
                //if (_graphPara[2] == 0) this.uCheckEditor_Para02.Checked = false;
                //if (_graphPara[3] == 0) this.uCheckEditor_Para03.Checked = false;
                //if (_graphPara[4] == 0) this.uCheckEditor_Para04.Checked = false;
                //if (_graphPara[5] == 0) this.uCheckEditor_Para05.Checked = false;
                //if (_graphPara[6] == 0) this.uCheckEditor_Para06.Checked = false;
                //if (_graphPara[7] == 0) this.uCheckEditor_Para07.Checked = false;
                //if (_graphPara[8] == 0) this.uCheckEditor_Para08.Checked = false;
                //if (_graphPara[9] == 0) this.uCheckEditor_Para09.Checked = false;
                //if (_graphPara[10] == 0) this.uCheckEditor_Para10.Checked = false;
                //if (_graphPara[11] == 0) this.uCheckEditor_Para11.Checked = false;
                //if (_graphPara[12] == 0) this.uCheckEditor_Para12.Checked = false;
                // 2010/04/30 Del <<<
                // 2010/04/30 Add >>>
                if (_graphPara[(int)ItemList.ST_STOCK] == 0) this.uCheckEditor_Para01.Checked = false;
                if (_graphPara[(int)ItemList.ST_RETGOODS] == 0) this.uCheckEditor_Para02.Checked = false;
                if (_graphPara[(int)ItemList.ST_DISCOUNT] == 0) this.uCheckEditor_Para03.Checked = false;
                if (_graphPara[(int)ItemList.ST_GSTOCK] == 0) this.uCheckEditor_Para04.Checked = false;
                if (_graphPara[(int)ItemList.OR_STOCK] == 0) this.uCheckEditor_Para05.Checked = false;
                if (_graphPara[(int)ItemList.OR_RETGOODS] == 0) this.uCheckEditor_Para06.Checked = false;
                if (_graphPara[(int)ItemList.OR_DISCOUNT] == 0) this.uCheckEditor_Para07.Checked = false;
                if (_graphPara[(int)ItemList.OR_GSTOCK] == 0) this.uCheckEditor_Para08.Checked = false;
                if (_graphPara[(int)ItemList.TO_STOCK] == 0) this.uCheckEditor_Para09.Checked = false;
                if (_graphPara[(int)ItemList.TO_RETGOODS] == 0) this.uCheckEditor_Para10.Checked = false;
                if (_graphPara[(int)ItemList.TO_DISCOUNT] == 0) this.uCheckEditor_Para11.Checked = false;
                if (_graphPara[(int)ItemList.TO_GSTOCK] == 0) this.uCheckEditor_Para12.Checked = false;
                // 2010/04/30 Add <<<
            }
            else
            {
                this.tComboEditor_GraphStyle.SelectedIndex = 0;
            }

            // 2010/04/30 Add >>>
            this.tComboEditor1.Items.Clear();
            this.tComboEditor1.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor1.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor1.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor1.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor1.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor1.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor1.SelectedIndex = _graphPara2[(int)ItemList.ST_STOCK];
                else
                    this.tComboEditor1.SelectedIndex = 2;
            }

            this.tComboEditor2.Items.Clear();
            this.tComboEditor2.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor2.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor2.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor2.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor2.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor2.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor2.SelectedIndex = _graphPara2[(int)ItemList.ST_RETGOODS];
                else
                    this.tComboEditor2.SelectedIndex = 2;
            }

            this.tComboEditor3.Items.Clear();
            this.tComboEditor3.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor3.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor3.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor3.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor3.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor3.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor3.SelectedIndex = _graphPara2[(int)ItemList.ST_DISCOUNT];
                else
                    this.tComboEditor3.SelectedIndex = 2;
            }

            this.tComboEditor4.Items.Clear();
            this.tComboEditor4.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor4.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor4.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor4.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor4.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor4.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor4.SelectedIndex = _graphPara2[(int)ItemList.ST_GSTOCK];
                else
                    this.tComboEditor4.SelectedIndex = 2;
            }

            this.tComboEditor5.Items.Clear();
            this.tComboEditor5.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor5.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor5.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor5.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor5.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor5.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor5.SelectedIndex = _graphPara2[(int)ItemList.OR_STOCK];
                else
                    this.tComboEditor5.SelectedIndex = 2;
            }

            this.tComboEditor6.Items.Clear();
            this.tComboEditor6.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor6.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor6.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor6.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor6.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor6.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor6.SelectedIndex = _graphPara2[(int)ItemList.OR_RETGOODS];
                else
                    this.tComboEditor6.SelectedIndex = 2;
            }

            this.tComboEditor7.Items.Clear();
            this.tComboEditor7.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor7.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor7.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor7.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor7.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor7.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor7.SelectedIndex = _graphPara2[(int)ItemList.OR_DISCOUNT];
                else
                    this.tComboEditor7.SelectedIndex = 2;
            }

            this.tComboEditor8.Items.Clear();
            this.tComboEditor8.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor8.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor8.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor8.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor8.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor8.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor8.SelectedIndex = _graphPara2[(int)ItemList.OR_GSTOCK];
                else
                    this.tComboEditor8.SelectedIndex = 2;
            }

            this.tComboEditor9.Items.Clear();
            this.tComboEditor9.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor9.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor9.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor9.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor9.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor9.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor9.SelectedIndex = _graphPara2[(int)ItemList.TO_STOCK];
                else
                    this.tComboEditor9.SelectedIndex = 2;
            }

            this.tComboEditor10.Items.Clear();
            this.tComboEditor10.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor10.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor10.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor10.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor10.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor10.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor10.SelectedIndex = _graphPara2[(int)ItemList.TO_RETGOODS];
                else
                    this.tComboEditor10.SelectedIndex = 2;
            }

            this.tComboEditor11.Items.Clear();
            this.tComboEditor11.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor11.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor11.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor11.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor11.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor11.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor11.SelectedIndex = _graphPara2[(int)ItemList.TO_DISCOUNT];
                else
                    this.tComboEditor11.SelectedIndex = 2;
            }

            this.tComboEditor12.Items.Clear();
            this.tComboEditor12.Items.Add(0, GRAPH_BAR_L);
            this.tComboEditor12.Items.Add(1, GRAPH_BAR_S);
            this.tComboEditor12.Items.Add(2, GRAPH_LINE_L);
            this.tComboEditor12.Items.Add(3, GRAPH_LINE_S);
            this.tComboEditor12.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if (tComboEditor12.SelectedIndex == -1)
            {
                if ((_graphPara2 != null) && (_graphPara2.Count != 0))
                    this.tComboEditor12.SelectedIndex = _graphPara2[(int)ItemList.TO_GSTOCK];
                else
                    this.tComboEditor12.SelectedIndex = 2;
            }
            // 2010/04/30 Add <<<

            _graphPara[0] = -1;
        }

        // 2010/04/30 Add >>>
        /// <summary>
        /// グラフ選択コンボボックスの設定が変更される度に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GraphStyle_ValueChanged(object sender, EventArgs e)
        {
            // 折れ線＋棒グラフ以外ならコンボボックス選択不可
            if (tComboEditor_GraphStyle.SelectedIndex != 4)
            {
                this.tComboEditor1.Visible = false;
                this.tComboEditor2.Visible = false;
                this.tComboEditor3.Visible = false;
                this.tComboEditor4.Visible = false;
                this.tComboEditor5.Visible = false;
                this.tComboEditor6.Visible = false;
                this.tComboEditor7.Visible = false;
                this.tComboEditor8.Visible = false;
                this.tComboEditor9.Visible = false;
                this.tComboEditor10.Visible = false;
                this.tComboEditor11.Visible = false;
                this.tComboEditor12.Visible = false;
                this.tComboEditor1.Enabled = false;
                this.tComboEditor2.Enabled = false;
                this.tComboEditor3.Enabled = false;
                this.tComboEditor4.Enabled = false;
                this.tComboEditor5.Enabled = false;
                this.tComboEditor6.Enabled = false;
                this.tComboEditor7.Enabled = false;
                this.tComboEditor8.Enabled = false;
                this.tComboEditor9.Enabled = false;
                this.tComboEditor10.Enabled = false;
                this.tComboEditor11.Enabled = false;
                this.tComboEditor12.Enabled = false;
            }
            else
            {
                this.tComboEditor1.Visible = true;
                this.tComboEditor2.Visible = true;
                this.tComboEditor3.Visible = true;
                this.tComboEditor4.Visible = true;
                this.tComboEditor5.Visible = true;
                this.tComboEditor6.Visible = true;
                this.tComboEditor7.Visible = true;
                this.tComboEditor8.Visible = true;
                this.tComboEditor9.Visible = true;
                this.tComboEditor10.Visible = true;
                this.tComboEditor11.Visible = true;
                this.tComboEditor12.Visible = true;
                this.tComboEditor1.Enabled = true;
                this.tComboEditor2.Enabled = true;
                this.tComboEditor3.Enabled = true;
                this.tComboEditor4.Enabled = true;
                this.tComboEditor5.Enabled = true;
                this.tComboEditor6.Enabled = true;
                this.tComboEditor7.Enabled = true;
                this.tComboEditor8.Enabled = true;
                this.tComboEditor9.Enabled = true;
                this.tComboEditor10.Enabled = true;
                this.tComboEditor11.Enabled = true;
                this.tComboEditor12.Enabled = true;
            }
        }

        /// <summary>
        /// グラフ設定を保存します。
        /// </summary>
        /// <param name="list">graphpara</param>
        /// <returns>status</returns>
        private int SaveToFiles(List<List<int>> list)
        {
            int status = 0;
            // --- ADD 2010/06/28 ---------->>>>>
            //UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML"));
            UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML")));
            // --- ADD 2010/06/28 ----------<<<<<
            return status;
        }

        /// <summary>
        /// グラフ設定を読み込みます。
        /// </summary>
        /// <param name="list">graphpara</param>
        /// <returns>status</returns>
        public int LoadToFiles(out List<List<int>> list)
        {
            // 読込処理
            int status = 0;
            list = new List<List<int>>();
            // --- ADD 2010/06/28 ---------->>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML")))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML"))))
            // --- ADD 2010/06/28 ----------<<<<<
            {
                try
                {
                    // --- ADD 2010/06/28 ---------->>>>>
                    //list = UserSettingController.DeserializeUserSetting<List<List<int>>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML"));
                    list = UserSettingController.DeserializeUserSetting<List<List<int>>>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKOU04110U" + _graphId + "_Construction.XML")));
                    // --- ADD 2010/06/28 ----------<<<<<
                }
                catch
                {
                    status = 1;
                }
            }
            else
            {
                status = 1;
            }
            return status;
        }

        // 2010/04/30 Add <<<
    }
}
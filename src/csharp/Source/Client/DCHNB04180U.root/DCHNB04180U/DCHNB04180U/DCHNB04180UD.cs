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

    public partial class DCHNB04180UD : Form
    {
        public DCHNB04180UD()
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
            /// <summary>値引</summary>
            DISCOUNT = 1,
            /// <summary>返品</summary>
            RETGOODS,
            /// <summary>粗利金額</summary>
            GRPROFIT,
            /// <summary>前期粗利</summary>
            BEFGRPRO,
            /// <summary>粗利目標</summary>
            GRTARGET,
            /// <summary>純売上</summary>
            GSALES,
            /// <summary>前期純売上</summary>
            BEFSALES,
            /// <summary>売上</summary>
            SALES,
            /// <summary>目標</summary>
            TARGET
        }
        // 2010/04/30 Add <<<

        # region ※Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCHNB04180UD());
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
            for (int ix = 0; ix < 9; ix++)
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
                // 2010/04/30 Del <<<

                // 2010/04/30 Add >>>
                if (this.uCheckEditor_Para01.Checked == true) _graphPara[(int)ItemList.SALES] = 0;
                if (this.uCheckEditor_Para02.Checked == true) _graphPara[(int)ItemList.RETGOODS] = 0;
                if (this.uCheckEditor_Para03.Checked == true) _graphPara[(int)ItemList.DISCOUNT] = 0;
                if (this.uCheckEditor_Para04.Checked == true) _graphPara[(int)ItemList.GSALES] = 0;
                if (this.uCheckEditor_Para05.Checked == true) _graphPara[(int)ItemList.TARGET] = 0;
                if (this.uCheckEditor_Para06.Checked == true) _graphPara[(int)ItemList.GRPROFIT] = 0;
                if (this.uCheckEditor_Para07.Checked == true) _graphPara[(int)ItemList.GRTARGET] = 0;
                if (this.uCheckEditor_Para08.Checked == true) _graphPara[(int)ItemList.BEFSALES] = 0;
                if (this.uCheckEditor_Para09.Checked == true) _graphPara[(int)ItemList.BEFGRPRO] = 0;

                if (this.tComboEditor1.SelectedIndex != -1) _graphPara2[(int)ItemList.SALES] = this.tComboEditor1.SelectedIndex;
                if (this.tComboEditor2.SelectedIndex != -1) _graphPara2[(int)ItemList.RETGOODS] = this.tComboEditor2.SelectedIndex;
                if (this.tComboEditor3.SelectedIndex != -1) _graphPara2[(int)ItemList.DISCOUNT] = this.tComboEditor3.SelectedIndex;
                if (this.tComboEditor4.SelectedIndex != -1) _graphPara2[(int)ItemList.GSALES] = this.tComboEditor4.SelectedIndex;
                if (this.tComboEditor5.SelectedIndex != -1) _graphPara2[(int)ItemList.TARGET] = this.tComboEditor5.SelectedIndex;
                if (this.tComboEditor6.SelectedIndex != -1) _graphPara2[(int)ItemList.GRPROFIT] = this.tComboEditor6.SelectedIndex;
                if (this.tComboEditor7.SelectedIndex != -1) _graphPara2[(int)ItemList.GRTARGET] = this.tComboEditor7.SelectedIndex;
                if (this.tComboEditor8.SelectedIndex != -1) _graphPara2[(int)ItemList.BEFSALES] = this.tComboEditor8.SelectedIndex;
                if (this.tComboEditor9.SelectedIndex != -1) _graphPara2[(int)ItemList.BEFGRPRO] = this.tComboEditor9.SelectedIndex;
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
                // 2010/04/30 Del <<<

                // 2010/04/30 Add >>>
                if (this.uCheckEditor_Para03.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para02.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para06.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para09.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para07.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para04.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para08.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para01.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para05.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);

                _graphPara2.Add(_graphId);
                _graphPara2.Add(this.tComboEditor3.SelectedIndex);
                _graphPara2.Add(this.tComboEditor2.SelectedIndex);
                _graphPara2.Add(this.tComboEditor6.SelectedIndex);
                _graphPara2.Add(this.tComboEditor9.SelectedIndex);
                _graphPara2.Add(this.tComboEditor7.SelectedIndex);
                _graphPara2.Add(this.tComboEditor4.SelectedIndex);
                _graphPara2.Add(this.tComboEditor8.SelectedIndex);
                _graphPara2.Add(this.tComboEditor1.SelectedIndex);
                _graphPara2.Add(this.tComboEditor5.SelectedIndex);
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

        internal static void ShowWindows(AnalysisChartViewForm dCHNB04180UB)
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
                // 2010/04/30 Del <<<
                // 2010/04/30 Add >>>
                if (_graphPara[(int)ItemList.SALES] == 0) this.uCheckEditor_Para01.Checked = false;
                if (_graphPara[(int)ItemList.RETGOODS] == 0) this.uCheckEditor_Para02.Checked = false;
                if (_graphPara[(int)ItemList.DISCOUNT] == 0) this.uCheckEditor_Para03.Checked = false;
                if (_graphPara[(int)ItemList.GSALES] == 0) this.uCheckEditor_Para04.Checked = false;
                if (_graphPara[(int)ItemList.TARGET] == 0) this.uCheckEditor_Para05.Checked = false;
                if (_graphPara[(int)ItemList.GRPROFIT] == 0) this.uCheckEditor_Para06.Checked = false;
                if (_graphPara[(int)ItemList.GRTARGET] == 0) this.uCheckEditor_Para07.Checked = false;
                if (_graphPara[(int)ItemList.BEFSALES] == 0) this.uCheckEditor_Para08.Checked = false;
                if (_graphPara[(int)ItemList.BEFGRPRO] == 0) this.uCheckEditor_Para09.Checked = false;
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
                    this.tComboEditor1.SelectedIndex = _graphPara2[(int)ItemList.SALES];
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
                    this.tComboEditor2.SelectedIndex = _graphPara2[(int)ItemList.RETGOODS];
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
                    this.tComboEditor3.SelectedIndex = _graphPara2[(int)ItemList.DISCOUNT];
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
                    this.tComboEditor4.SelectedIndex = _graphPara2[(int)ItemList.GSALES];
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
                    this.tComboEditor5.SelectedIndex = _graphPara2[(int)ItemList.TARGET];
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
                    this.tComboEditor6.SelectedIndex = _graphPara2[(int)ItemList.GRPROFIT];
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
                    this.tComboEditor7.SelectedIndex = _graphPara2[(int)ItemList.GRTARGET];
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
                    this.tComboEditor8.SelectedIndex = _graphPara2[(int)ItemList.BEFSALES];
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
                    this.tComboEditor9.SelectedIndex = _graphPara2[(int)ItemList.BEFGRPRO];
                else
                    this.tComboEditor9.SelectedIndex = 2;
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
            // 折れ線＋棒グラフ以外なら折れ線・棒表示の選択不可
            if (tComboEditor_GraphStyle.SelectedIndex != 4)
            {
                tComboEditor1.Visible = false;
                tComboEditor2.Visible = false;
                tComboEditor3.Visible = false;
                tComboEditor4.Visible = false;
                tComboEditor5.Visible = false;
                tComboEditor6.Visible = false;
                tComboEditor7.Visible = false;
                tComboEditor8.Visible = false;
                tComboEditor9.Visible = false;
                tComboEditor1.Enabled = false;
                tComboEditor2.Enabled = false;
                tComboEditor3.Enabled = false;
                tComboEditor4.Enabled = false;
                tComboEditor5.Enabled = false;
                tComboEditor6.Enabled = false;
                tComboEditor7.Enabled = false;
                tComboEditor8.Enabled = false;
                tComboEditor9.Enabled = false;
            }
            else
            {
                tComboEditor1.Visible = true;
                tComboEditor2.Visible = true;
                tComboEditor3.Visible = true;
                tComboEditor4.Visible = true;
                tComboEditor5.Visible = true;
                tComboEditor6.Visible = true;
                tComboEditor7.Visible = true;
                tComboEditor8.Visible = true;
                tComboEditor9.Visible = true;
                tComboEditor1.Enabled = true;
                tComboEditor2.Enabled = true;
                tComboEditor3.Enabled = true;
                tComboEditor4.Enabled = true;
                tComboEditor5.Enabled = true;
                tComboEditor6.Enabled = true;
                tComboEditor7.Enabled = true;
                tComboEditor8.Enabled = true;
                tComboEditor9.Enabled = true;
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
            UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "DCHNB04180U" + _graphId + "_Construction.XML"));
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
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "DCHNB04180U" + _graphId + "_Construction.XML")))
            {
                try
                {
                    list = UserSettingController.DeserializeUserSetting<List<List<int>>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "DCHNB04180U" + _graphId + "_Construction.XML"));
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
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 前年対比表チャート『条件設定』ダイアログ作成クラス
	/// </summary>
	public partial class DCTOK02096EB : Form
    {
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DCTOK02096EB()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;

        }

		// 抽出条件クラス
		private ExtrInfo_DCTOK02093E _extraInfo = new ExtrInfo_DCTOK02093E();

        private ImageList _imageList16 = null;

		private List<int> _graphPara;
		private List<int> _graphShow;

		private int _modePara;
		//Form2（『条件設定』ダイアログ）がCancelで閉じられたかどうかを保持
		//private bool _ok;
		private bool b_ok;


		private List<string> _titleList;
		private List<string> _code;
		private List<string> _name;

		private static List<string> _cashe0;
		private static List<string> _cashe1;
		private static List<string> _cashe2;
		private static List<string> _cashe3;
		private static List<string> _cashe4;
        private static List<string> _cashe5;
        private static List<string> _cashe6;

		private List<string> Cashe;

		private List<string> _codeCashe_r;
		private List<string> _codeCashe_s;
		private static List<bool> _checkedItem_r;
		private static List<bool> _checkedItem_s;
		
		// グラフ種別区分
        private const string GRAPH_LINE = "折れ線グラフ";
        private const string GRAPH_BAR = "棒グラフ";

		// 対象項目選択最大件数
		private int CHKMAXCOUNT = 4;


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

        # region ※Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCTOK02096EB());
        }
        # endregion

		#region Control.Click イベント
		/// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
			//↓で×ボタンがDialogResult.Cancelになる;
			DialogResult = DialogResult.OK;

			#region チェック

			//何もチェックされていなかったらエラーメッセージ
			int _chkflg = 0;

			switch(_titleList.Count)
			{
				case 2:	// 比率
					if (this.uCheckEditor_Para01.Checked == false && this.uCheckEditor_Para02.Checked == false)
					{
						MessageBox.Show("対象項目を選択して下さい");
						return;
					}
					break;

				case 4:	// 金額
					if(this.uCheckEditor_Para01.Checked == false && this.uCheckEditor_Para02.Checked == false && 
						this.uCheckEditor_Para03.Checked == false && this.uCheckEditor_Para04.Checked == false)
					{
						MessageBox.Show("対象項目を選択して下さい");
						return;
					}
					break;
			}
			
			for (int jx = 0; jx < this.clbChange.Items.Count; jx++)
			{
				if (this.clbChange.GetItemChecked(jx) == true)
				{
					_chkflg++;
				}
			}

			if (_chkflg == 0)
			{
				MessageBox.Show("対象項目2を選択して下さい");
				return;
			}

			#endregion チェック

			_graphPara[0] = this.tComboEditor_GraphStyle.SelectedIndex;

            if ((_graphShow != null) && (_graphShow.Count != 0))
            {
                for (int ix = 0; ix < _graphShow.Count; ix++) _graphShow[ix] = 0;

				// 対象項目チェックボックスに連動して系の表示・非表示切替
				for (int ix = 0; ix < _graphShow.Count; ix++)
                {
					if (_titleList.Count == 2)	//比率
					{
						// 選択された項目のみ出力する
						switch (ix % 2)
						{
							// 売上表示
							case 0:
								if (this.uCheckEditor_Para01.Checked == true)
								{
									_graphShow[ix] = 1;
								}

								break;

							// 粗利表示
							case 1:
								if (this.uCheckEditor_Para02.Checked == true)
								{
									_graphShow[ix] = 1;
								}

								break;
						}
					}
					else
					{
						switch (ix % 4)
						{
							case 0: { if (this.uCheckEditor_Para01.Checked == true) _graphShow[ix] = 1; break; }
							case 1: { if (this.uCheckEditor_Para02.Checked == true) _graphShow[ix] = 1; break; }
							case 2: { if (this.uCheckEditor_Para03.Checked == true) _graphShow[ix] = 1; break; }
							case 3: { if (this.uCheckEditor_Para04.Checked == true) _graphShow[ix] = 1; break; }
						}
					}
				}

				// 対象項目2チェックボックスに連動して系の表示・非表示切替
				switch (this._titleList.Count)
				{
					case 2:	//比率
						int cnt = 0;
						for (int jx = 0; jx < _graphShow.Count; jx++)
						{
							if (this.clbChange.GetItemChecked(cnt) == false)
							{
								_graphShow[jx] = 0;
							}
							//（拠点・得意先等）一つにつき二つの系（比率：売上・粗利）があるので、二つの系とも非表示にした後次の分の（拠点・得意先等の）系へ。
							if (jx % 2 == 1)
							{
								cnt++;
							}
						}
						break;

					case 4: //金額
						int _cnt = 0;
						for (int kx = 0; kx < _graphShow.Count; kx++)
						{
							if (this.clbChange.GetItemChecked(_cnt) == false)
							{
								_graphShow[kx] = 0;
							}
							//Countは0から始まる。0～3で四つ（売上：前年・当年/粗利：前年・当年）非表示にしてから次へ。
							if (kx % 4 == 3)
							{
								_cnt++;
							}
						}
						break;
				}
			}
            else
            {
                for (int ix = 0; ix < CHKMAXCOUNT; ix++) _graphShow.Add(0);
				if (this.uCheckEditor_Para01.Checked == true) _graphShow[0] = 1;
				if (this.uCheckEditor_Para02.Checked == true) _graphShow[1] = 1;
				if (this.uCheckEditor_Para03.Checked == true) _graphShow[2] = 1;
				if (this.uCheckEditor_Para04.Checked == true) _graphShow[3] = 1;

				for (int i = 0; i < _graphShow.Count; i++)
				{
					_graphShow.Add(0); 
					if (this.clbChange.GetItemChecked(i) == true)
					{
						_graphShow[i] = 1;
					}
				}
			}

			CasheCode();

            this.Close();
            //this.Hide();
		}
		#endregion	Control.Click イベント：終

		// 表示されている系のコードを保持
		private void CasheCode()
		{
			bool _para01 = false;
			bool _para02 = false;
			bool _para03 = false;
			bool _para04 = false;

			// ○○別にキャッシュ作成
			switch (this._modePara)
			{
				case 0:	//得意先別
					_cashe0 = new List<string>();
					Cashe = _cashe0;

					break;

                case 1:	//担当者別
					_cashe1 = new List<string>();
					Cashe = _cashe1;

					break;

				case 2:	//受注者別
					_cashe2 = new List<string>();
					Cashe = _cashe2;

					break;

				case 3:	//地区別
					_cashe3 = new List<string>();
					Cashe = _cashe3;

					break;

				case 4:	//業種別
					_cashe4 = new List<string>();
					Cashe = _cashe4;

					break;

				case 5:	//グループコード別
					_cashe5 = new List<string>();
					Cashe = _cashe5;

					break;
                case 6: //ＢＬコード別
                    _cashe6 = new List<string>();
                    Cashe = _cashe6;

                    break;
			}

			switch (_titleList.Count)
			{
				case 2:	//比率

					//表示されている系のコードを保持
					//this._CodeCashe_r = new List<string>();
					this._CodeCashe_r = Cashe;

					for (int ix = 0; ix < this.clbChange.Items.Count; ix++)
					{
						if (this.clbChange.GetItemChecked(ix) == true)
						{	
							this._CodeCashe_r.Add(this._code[ix]);
						}
					}

					//『対象項目』チェックボックスのチェック状態保持
					if (this.uCheckEditor_Para01.Checked == true) {	_para01 = true;	}
					else { _para01 = false; }

					if (this.uCheckEditor_Para02.Checked == true) { _para02 = true; }
					else { _para02 = false; }

					_checkedItem_r = new List<bool>();
					_checkedItem_r.AddRange(new bool[] { _para01, _para02, _para03, _para04 });

					break;

				case 4:

					//表示されている系のコードを保持
					//this._CodeCashe_s = new List<string>();
					this._CodeCashe_s = Cashe;

					for (int ix = 0; ix < this.clbChange.Items.Count; ix++)
					{
						if (this.clbChange.GetItemChecked(ix) == true)
						{
							this._CodeCashe_s.Add(this._code[ix]);
						}
					}
					//『対象項目』チェックボックスのチェック状態保持
					if (this.uCheckEditor_Para01.Checked == true) { _para01 = true; }
					else { _para01 = false; }

					if (this.uCheckEditor_Para02.Checked == true) { _para02 = true; }
					else { _para02 = false; }
					
					if (this.uCheckEditor_Para03.Checked == true) { _para03 = true; }
					else { _para03 = false; }

					if (this.uCheckEditor_Para04.Checked == true) { _para04 = true; }
					else { _para04 = false; }

					_checkedItem_s = new List<bool>();
					_checkedItem_s.AddRange(new bool[] { _para01, _para02, _para03, _para04 });

					break;
			}

		}

		#region Form2_Load
		/// <summary>
		/// Form2_Load イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : “条件設定”フォーム（Form2）がロードされたときに発生します。</br>
		/// <br>Programmer  : 30462 行澤 仁美</br>
		/// <br>Date        : 2008.11.25</br>
		/// </remarks>
		private void Form2_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList = this._imageList16;
			this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;

			// グラフ種別のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
			this.tComboEditor_GraphStyle.Items.Clear();
			this.tComboEditor_GraphStyle.Items.Add(0, GRAPH_BAR);
			this.tComboEditor_GraphStyle.Items.Add(1, GRAPH_LINE);

			this.tComboEditor_GraphStyle.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
			if ((_graphPara != null) && (_graphPara.Count != 0))
			{
				this.tComboEditor_GraphStyle.SelectedIndex = _graphPara[0];
				this._graphPara[0] = -1;
			}
			else
			{
				this.tComboEditor_GraphStyle.SelectedIndex = 0;
				this._graphPara.Add(-1);
			}

			//対象項目2チェックボックス作成
			this.clbChange.Items.Clear();

			for (int i = 0; i < _code.Count; i++)
			{
				this.clbChange.Items.Add(_name[i], CheckState.Checked);
				//this.clbChange.SetItemChecked(0, false);
			}

			// 対象項目タイトル情報セット
			for (int ix = 0; ix < _titleList.Count; ix++)
			{
				switch (ix)
				{
					case 0: { this.uCheckEditor_Para01.Text = _titleList[ix].ToString(); break; }
					case 1: { this.uCheckEditor_Para02.Text = _titleList[ix].ToString(); break; }
					case 2: { this.uCheckEditor_Para03.Text = _titleList[ix].ToString(); break; }
					case 3: { this.uCheckEditor_Para04.Text = _titleList[ix].ToString(); break; }
				}
			}

			for (int ix = _titleList.Count; ix < CHKMAXCOUNT; ix++)
			{
				switch (ix)
				{
					case 0: { this.uCheckEditor_Para01.Visible = false; break; }
					case 1: { this.uCheckEditor_Para02.Visible = false; break; }
					case 2: { this.uCheckEditor_Para03.Visible = false; break; }
					case 3: { this.uCheckEditor_Para04.Visible = false; break; }
				}
			}

			#region 対象項目選択情報セット
			// 対象項目選択情報セット：チェックボックスの状態を保持。
			if ((_graphShow != null) && (_graphShow.Count != 0))
			{
				switch (this._titleList.Count)
				{
					case 2:	//比率
						int cnt_a = 0;		//奇数カウント
						int cnt_b = 0;		//偶数カウント

						//対象項目のチェックがOFFのとき⇒売上全て　または　粗利全て　非表示
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 2 == 1)	//奇数のとき＝粗利
							{
								if (_graphShow[ix] == 0)
								{
									cnt_b++; 
								}
							}
							else　				//偶数のとき＝売上
							{
								if (_graphShow[ix] == 0)
								{
									cnt_a++; 
								}
							}
						}
						if (cnt_a == _graphShow.Count / 2)
						{
							//売上チェックOFF
							this.uCheckEditor_Para01.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para01.Checked = true;
						}

						if (cnt_b == _graphShow.Count / 2)
						{
							//売上チェックOFF
							this.uCheckEditor_Para02.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para02.Checked = true;
						} 
						break;

					case 4:	//金額
						int cnt00 = 0;	// 売上：当年カウント
						int cnt01 = 0;	// 売上：前年カウント	
						int cnt02 = 0;	// 粗利：当年カウント
						int cnt03 = 0;	// 粗利：前年カウント

						//対象項目のチェックがOFFのとき⇒売上全て　または　粗利全て　非表示
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 4 == 0)		// 売上：当年
							{
								if (_graphShow[ix] == 0)
								{
									cnt00++;
								}
							}
							else if (ix % 4 == 1)	// 売上：前年
							{
								if (_graphShow[ix] == 0)
								{
									cnt01++;
								}
							}
							else if (ix % 4 == 2)	// 粗利：当年
							{
								if (_graphShow[ix] == 0)
								{
									cnt02++;
								}
							}
							else					// 粗利：前年
							{
								if (_graphShow[ix] == 0)
								{
									cnt03++;
								}
							}
						}
						if (cnt00 == _graphShow.Count / 4)
						{
							//売上：当年チェックOFF
							this.uCheckEditor_Para01.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para01.Checked = true;
						}

						if (cnt01 == _graphShow.Count / 4)
						{
							//売上：前年チェックOFF
							this.uCheckEditor_Para02.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para02.Checked = true;
						}
						
						if (cnt02 == _graphShow.Count / 4)
						{
							//粗利：当年チェックOFF
							this.uCheckEditor_Para03.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para03.Checked = true;
						}

						if (cnt03 == _graphShow.Count / 4)
						{
							//粗利：前年チェックOFF
							this.uCheckEditor_Para04.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para04.Checked = true;
						}
						
						break;
				}

			}
			#endregion	対象項目選択情報セット：終

			#region 対象項目2選択情報セット
			// 対象項目2選択情報セット：チェックボックスの状態を保持。
			if ((_graphShow != null) && (_graphShow.Count != 0))
			{
				switch (this._titleList.Count)
				{
					case 2:	//比率
						bool chkflg = false;
						int cnt = 0;

						//対象項目2のチェックがOFFのとき⇒売上と粗利両方非表示
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 2 == 1)	//奇数のとき
							{
								if (chkflg == false)
								{
									if (_graphShow[ix] == 0)
									{
										this.clbChange.SetItemChecked(cnt, false);
									}
								}

								if (cnt < this.clbChange.Items.Count) cnt++;
							}

							else　				//偶数のとき
							{
								if (_graphShow[ix] == 0)
								{
									chkflg = false;
								}
								else
								{
									chkflg = true;
								}
							}
						}
						break;

					case 4:	//金額
						int _cnt = 0;
						bool chkflg00 = false;
						bool chkflg01 = false;
						bool chkflg02 = false;
						bool chkflg03 = false;

						//対象項目2のチェックがOFFのとき⇒売上（当年・前年）と粗利（当年・前年）4つ非表示
						for (int jx = 0; jx < _graphShow.Count; jx++)
						{
							if (jx % 4 == 0)		// 売上：当年
							{
								if (_graphShow[jx] == 0)
								{
									chkflg00 = true;
								}
							}
							else if (jx % 4 == 1)	// 売上：前年
							{
								if (_graphShow[jx] == 0)
								{
									chkflg01 = true;
								}
							}
							else if (jx % 4 == 2)	// 粗利：当年
							{
								if (_graphShow[jx] == 0)
								{
									chkflg02 = true;
								}
							}
							else　　				// 粗利：前年
							{
								if (_graphShow[jx] == 0)
								{
									chkflg03 = true;
								}
							}

							if (jx % 4 == 3)		//4つ目に必ず行う処理
							{
								if (chkflg00 == true && chkflg01 == true && chkflg02 == true && chkflg03 == true)
								{
									this.clbChange.SetItemChecked(_cnt, false);
								}

								chkflg00 = false;
								chkflg01 = false;
								chkflg02 = false;
								chkflg03 = false;
								
								_cnt++;
							}
						}

						break;
				}
			}
			#endregion	対象項目2選択情報セット：終


		}
		#endregion	Form2_Load

		#region プロパティ

			/// public propaty name  :  _ModePara
			/// <summary>起動モードパラメータプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   対象項目タイトルリストプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public int _ModePara
			{
				get { return _modePara; }
				set { _modePara = value; }
			}

			///// public propaty name  :  _Ok
			///// <summary>Form2が閉じられた状況を判定するプロパティ</summary>
			///// ----------------------------------------------------------------------
			///// <remarks>
			///// <br>note             :  Form2が閉じられた状況を判定する</br>
			///// <br>Programer        :   Ai Mabuchi</br>
			///// </remarks>
			//public bool _Ok
			//{
			//    get { return _ok; }
			//    set { _ok = value; }
			//}

			/// public propaty name  :  b_Ok
			/// <summary>Form2が閉じられた状況を保持するプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :  Form2（『条件設定』ダイアログ）がOKで閉じられたかどうか</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public bool b_Ok
			{
				get { return b_ok; }
				set { b_ok = value; }
			}

			/// public propaty name  :  _TitleList
			/// <summary>対象項目タイトルリストプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   対象項目タイトルリストプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _TitleList
			{
				get { return _titleList; }
				set { _titleList = value; }
			}


			/// public propaty name  :  _GraphPara
			/// <summary>グラフパラメータリストプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   グラフパラメータリストプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<int> _GraphPara
			{
				get { return _graphPara; }
				set { _graphPara = value; }
			}

			/// public propaty name  :  _GraphShow
			/// <summary>グラフ表示・非表示パラメータプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   グラフ表示・非表示パラメータプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<int> _GraphShow
			{
				get { return _graphShow; }
				set { _graphShow = value; }
			}

			/// public propaty name  :  _Code
			/// <summary>対象項目2コードリストプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   対象項目2コードリストプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _Code
			{
				get { return _code; }
				set { _code = value; }
			}

			/// public propaty name  :  _Name
			/// <summary>対象項目2名前リストプロパティ</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   対象項目2名前リストプロパティ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _Name
			{
				get { return _name; }
				set { _name = value; }
			}

			/// public propaty name  :  _checkedItem_r
			/// <summary>チェックされた項目を保持：対象項目・比率用</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   比率用チェックキャッシュ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<bool> _CheckedIteme_r
			{
				get { return _checkedItem_r; }
				set { _checkedItem_r = value; }
			}

			/// public propaty name  :  _checkedItem_r
			/// <summary>チェックされた項目を保持：対象項目・金額用</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   金額用チェックキャッシュ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<bool> _CheckedIteme_s
			{
				get { return _checkedItem_s; }
				set { _checkedItem_s = value; }
			}

			
		/// public propaty name  :  _codeCashe_r
			/// <summary>チェックされた系のコードを保持：対象項目2</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   比率用コードキャッシュ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _CodeCashe_r
			{
				get { return _codeCashe_r; }
				set { _codeCashe_r = value; }
			}

			/// public propaty name  :  _codeCashe_s
			/// <summary>チェックされた系のコードを保持：対象項目2</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   金額用コードキャッシュ</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _CodeCashe_s
			{
				get { return _codeCashe_s; }
				set { _codeCashe_s = value; }
			}
		#endregion	プロパティ

		}
}

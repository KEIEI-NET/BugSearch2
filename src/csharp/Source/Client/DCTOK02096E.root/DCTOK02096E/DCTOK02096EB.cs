using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �O�N�Δ�\�`���[�g�w�����ݒ�x�_�C�A���O�쐬�N���X
	/// </summary>
	public partial class DCTOK02096EB : Form
    {
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public DCTOK02096EB()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;

        }

		// ���o�����N���X
		private ExtrInfo_DCTOK02093E _extraInfo = new ExtrInfo_DCTOK02093E();

        private ImageList _imageList16 = null;

		private List<int> _graphPara;
		private List<int> _graphShow;

		private int _modePara;
		//Form2�i�w�����ݒ�x�_�C�A���O�j��Cancel�ŕ���ꂽ���ǂ�����ێ�
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
		
		// �O���t��ʋ敪
        private const string GRAPH_LINE = "�܂���O���t";
        private const string GRAPH_BAR = "�_�O���t";

		// �Ώۍ��ڑI���ő匏��
		private int CHKMAXCOUNT = 4;


		/// <summary>
        /// �ďo���䏈��
        /// </summary>
        /// <param name="owner">�ďo���I�u�W�F�N�g</param>
        public DialogResult ShowWindows(IWin32Window owner)
        {
            // ��ʂ̐ݒ�
            this.ShowInTaskbar = false;

            return this.ShowDialog(owner);
        }

        # region ��Main
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCTOK02096EB());
        }
        # endregion

		#region Control.Click �C�x���g
		/// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
			//���Ł~�{�^����DialogResult.Cancel�ɂȂ�;
			DialogResult = DialogResult.OK;

			#region �`�F�b�N

			//�����`�F�b�N����Ă��Ȃ�������G���[���b�Z�[�W
			int _chkflg = 0;

			switch(_titleList.Count)
			{
				case 2:	// �䗦
					if (this.uCheckEditor_Para01.Checked == false && this.uCheckEditor_Para02.Checked == false)
					{
						MessageBox.Show("�Ώۍ��ڂ�I�����ĉ�����");
						return;
					}
					break;

				case 4:	// ���z
					if(this.uCheckEditor_Para01.Checked == false && this.uCheckEditor_Para02.Checked == false && 
						this.uCheckEditor_Para03.Checked == false && this.uCheckEditor_Para04.Checked == false)
					{
						MessageBox.Show("�Ώۍ��ڂ�I�����ĉ�����");
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
				MessageBox.Show("�Ώۍ���2��I�����ĉ�����");
				return;
			}

			#endregion �`�F�b�N

			_graphPara[0] = this.tComboEditor_GraphStyle.SelectedIndex;

            if ((_graphShow != null) && (_graphShow.Count != 0))
            {
                for (int ix = 0; ix < _graphShow.Count; ix++) _graphShow[ix] = 0;

				// �Ώۍ��ڃ`�F�b�N�{�b�N�X�ɘA�����Čn�̕\���E��\���ؑ�
				for (int ix = 0; ix < _graphShow.Count; ix++)
                {
					if (_titleList.Count == 2)	//�䗦
					{
						// �I�����ꂽ���ڂ̂ݏo�͂���
						switch (ix % 2)
						{
							// ����\��
							case 0:
								if (this.uCheckEditor_Para01.Checked == true)
								{
									_graphShow[ix] = 1;
								}

								break;

							// �e���\��
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

				// �Ώۍ���2�`�F�b�N�{�b�N�X�ɘA�����Čn�̕\���E��\���ؑ�
				switch (this._titleList.Count)
				{
					case 2:	//�䗦
						int cnt = 0;
						for (int jx = 0; jx < _graphShow.Count; jx++)
						{
							if (this.clbChange.GetItemChecked(cnt) == false)
							{
								_graphShow[jx] = 0;
							}
							//�i���_�E���Ӑ擙�j��ɂ���̌n�i�䗦�F����E�e���j������̂ŁA��̌n�Ƃ���\���ɂ����㎟�̕��́i���_�E���Ӑ擙�́j�n�ցB
							if (jx % 2 == 1)
							{
								cnt++;
							}
						}
						break;

					case 4: //���z
						int _cnt = 0;
						for (int kx = 0; kx < _graphShow.Count; kx++)
						{
							if (this.clbChange.GetItemChecked(_cnt) == false)
							{
								_graphShow[kx] = 0;
							}
							//Count��0����n�܂�B0�`3�Ŏl�i����F�O�N�E���N/�e���F�O�N�E���N�j��\���ɂ��Ă��玟�ցB
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
		#endregion	Control.Click �C�x���g�F�I

		// �\������Ă���n�̃R�[�h��ێ�
		private void CasheCode()
		{
			bool _para01 = false;
			bool _para02 = false;
			bool _para03 = false;
			bool _para04 = false;

			// �����ʂɃL���b�V���쐬
			switch (this._modePara)
			{
				case 0:	//���Ӑ��
					_cashe0 = new List<string>();
					Cashe = _cashe0;

					break;

                case 1:	//�S���ҕ�
					_cashe1 = new List<string>();
					Cashe = _cashe1;

					break;

				case 2:	//�󒍎ҕ�
					_cashe2 = new List<string>();
					Cashe = _cashe2;

					break;

				case 3:	//�n���
					_cashe3 = new List<string>();
					Cashe = _cashe3;

					break;

				case 4:	//�Ǝ��
					_cashe4 = new List<string>();
					Cashe = _cashe4;

					break;

				case 5:	//�O���[�v�R�[�h��
					_cashe5 = new List<string>();
					Cashe = _cashe5;

					break;
                case 6: //�a�k�R�[�h��
                    _cashe6 = new List<string>();
                    Cashe = _cashe6;

                    break;
			}

			switch (_titleList.Count)
			{
				case 2:	//�䗦

					//�\������Ă���n�̃R�[�h��ێ�
					//this._CodeCashe_r = new List<string>();
					this._CodeCashe_r = Cashe;

					for (int ix = 0; ix < this.clbChange.Items.Count; ix++)
					{
						if (this.clbChange.GetItemChecked(ix) == true)
						{	
							this._CodeCashe_r.Add(this._code[ix]);
						}
					}

					//�w�Ώۍ��ځx�`�F�b�N�{�b�N�X�̃`�F�b�N��ԕێ�
					if (this.uCheckEditor_Para01.Checked == true) {	_para01 = true;	}
					else { _para01 = false; }

					if (this.uCheckEditor_Para02.Checked == true) { _para02 = true; }
					else { _para02 = false; }

					_checkedItem_r = new List<bool>();
					_checkedItem_r.AddRange(new bool[] { _para01, _para02, _para03, _para04 });

					break;

				case 4:

					//�\������Ă���n�̃R�[�h��ێ�
					//this._CodeCashe_s = new List<string>();
					this._CodeCashe_s = Cashe;

					for (int ix = 0; ix < this.clbChange.Items.Count; ix++)
					{
						if (this.clbChange.GetItemChecked(ix) == true)
						{
							this._CodeCashe_s.Add(this._code[ix]);
						}
					}
					//�w�Ώۍ��ځx�`�F�b�N�{�b�N�X�̃`�F�b�N��ԕێ�
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
		/// Form2_Load �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �g�����ݒ�h�t�H�[���iForm2�j�����[�h���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 30462 �s�V �m��</br>
		/// <br>Date        : 2008.11.25</br>
		/// </remarks>
		private void Form2_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList = this._imageList16;
			this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;

			// �O���t��ʂ̺����ޯ���ɏ��Z�b�g
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

			//�Ώۍ���2�`�F�b�N�{�b�N�X�쐬
			this.clbChange.Items.Clear();

			for (int i = 0; i < _code.Count; i++)
			{
				this.clbChange.Items.Add(_name[i], CheckState.Checked);
				//this.clbChange.SetItemChecked(0, false);
			}

			// �Ώۍ��ڃ^�C�g�����Z�b�g
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

			#region �Ώۍ��ڑI�����Z�b�g
			// �Ώۍ��ڑI�����Z�b�g�F�`�F�b�N�{�b�N�X�̏�Ԃ�ێ��B
			if ((_graphShow != null) && (_graphShow.Count != 0))
			{
				switch (this._titleList.Count)
				{
					case 2:	//�䗦
						int cnt_a = 0;		//��J�E���g
						int cnt_b = 0;		//�����J�E���g

						//�Ώۍ��ڂ̃`�F�b�N��OFF�̂Ƃ��˔���S�ā@�܂��́@�e���S�ā@��\��
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 2 == 1)	//��̂Ƃ����e��
							{
								if (_graphShow[ix] == 0)
								{
									cnt_b++; 
								}
							}
							else�@				//�����̂Ƃ�������
							{
								if (_graphShow[ix] == 0)
								{
									cnt_a++; 
								}
							}
						}
						if (cnt_a == _graphShow.Count / 2)
						{
							//����`�F�b�NOFF
							this.uCheckEditor_Para01.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para01.Checked = true;
						}

						if (cnt_b == _graphShow.Count / 2)
						{
							//����`�F�b�NOFF
							this.uCheckEditor_Para02.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para02.Checked = true;
						} 
						break;

					case 4:	//���z
						int cnt00 = 0;	// ����F���N�J�E���g
						int cnt01 = 0;	// ����F�O�N�J�E���g	
						int cnt02 = 0;	// �e���F���N�J�E���g
						int cnt03 = 0;	// �e���F�O�N�J�E���g

						//�Ώۍ��ڂ̃`�F�b�N��OFF�̂Ƃ��˔���S�ā@�܂��́@�e���S�ā@��\��
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 4 == 0)		// ����F���N
							{
								if (_graphShow[ix] == 0)
								{
									cnt00++;
								}
							}
							else if (ix % 4 == 1)	// ����F�O�N
							{
								if (_graphShow[ix] == 0)
								{
									cnt01++;
								}
							}
							else if (ix % 4 == 2)	// �e���F���N
							{
								if (_graphShow[ix] == 0)
								{
									cnt02++;
								}
							}
							else					// �e���F�O�N
							{
								if (_graphShow[ix] == 0)
								{
									cnt03++;
								}
							}
						}
						if (cnt00 == _graphShow.Count / 4)
						{
							//����F���N�`�F�b�NOFF
							this.uCheckEditor_Para01.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para01.Checked = true;
						}

						if (cnt01 == _graphShow.Count / 4)
						{
							//����F�O�N�`�F�b�NOFF
							this.uCheckEditor_Para02.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para02.Checked = true;
						}
						
						if (cnt02 == _graphShow.Count / 4)
						{
							//�e���F���N�`�F�b�NOFF
							this.uCheckEditor_Para03.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para03.Checked = true;
						}

						if (cnt03 == _graphShow.Count / 4)
						{
							//�e���F�O�N�`�F�b�NOFF
							this.uCheckEditor_Para04.Checked = false;
						}
						else
						{
							this.uCheckEditor_Para04.Checked = true;
						}
						
						break;
				}

			}
			#endregion	�Ώۍ��ڑI�����Z�b�g�F�I

			#region �Ώۍ���2�I�����Z�b�g
			// �Ώۍ���2�I�����Z�b�g�F�`�F�b�N�{�b�N�X�̏�Ԃ�ێ��B
			if ((_graphShow != null) && (_graphShow.Count != 0))
			{
				switch (this._titleList.Count)
				{
					case 2:	//�䗦
						bool chkflg = false;
						int cnt = 0;

						//�Ώۍ���2�̃`�F�b�N��OFF�̂Ƃ��˔���Ƒe��������\��
						for (int ix = 0; ix < _graphShow.Count; ix++)
						{
							if (ix % 2 == 1)	//��̂Ƃ�
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

							else�@				//�����̂Ƃ�
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

					case 4:	//���z
						int _cnt = 0;
						bool chkflg00 = false;
						bool chkflg01 = false;
						bool chkflg02 = false;
						bool chkflg03 = false;

						//�Ώۍ���2�̃`�F�b�N��OFF�̂Ƃ��˔���i���N�E�O�N�j�Ƒe���i���N�E�O�N�j4��\��
						for (int jx = 0; jx < _graphShow.Count; jx++)
						{
							if (jx % 4 == 0)		// ����F���N
							{
								if (_graphShow[jx] == 0)
								{
									chkflg00 = true;
								}
							}
							else if (jx % 4 == 1)	// ����F�O�N
							{
								if (_graphShow[jx] == 0)
								{
									chkflg01 = true;
								}
							}
							else if (jx % 4 == 2)	// �e���F���N
							{
								if (_graphShow[jx] == 0)
								{
									chkflg02 = true;
								}
							}
							else�@�@				// �e���F�O�N
							{
								if (_graphShow[jx] == 0)
								{
									chkflg03 = true;
								}
							}

							if (jx % 4 == 3)		//4�ڂɕK���s������
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
			#endregion	�Ώۍ���2�I�����Z�b�g�F�I


		}
		#endregion	Form2_Load

		#region �v���p�e�B

			/// public propaty name  :  _ModePara
			/// <summary>�N�����[�h�p�����[�^�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �Ώۍ��ڃ^�C�g�����X�g�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public int _ModePara
			{
				get { return _modePara; }
				set { _modePara = value; }
			}

			///// public propaty name  :  _Ok
			///// <summary>Form2������ꂽ�󋵂𔻒肷��v���p�e�B</summary>
			///// ----------------------------------------------------------------------
			///// <remarks>
			///// <br>note             :  Form2������ꂽ�󋵂𔻒肷��</br>
			///// <br>Programer        :   Ai Mabuchi</br>
			///// </remarks>
			//public bool _Ok
			//{
			//    get { return _ok; }
			//    set { _ok = value; }
			//}

			/// public propaty name  :  b_Ok
			/// <summary>Form2������ꂽ�󋵂�ێ�����v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :  Form2�i�w�����ݒ�x�_�C�A���O�j��OK�ŕ���ꂽ���ǂ���</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public bool b_Ok
			{
				get { return b_ok; }
				set { b_ok = value; }
			}

			/// public propaty name  :  _TitleList
			/// <summary>�Ώۍ��ڃ^�C�g�����X�g�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �Ώۍ��ڃ^�C�g�����X�g�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _TitleList
			{
				get { return _titleList; }
				set { _titleList = value; }
			}


			/// public propaty name  :  _GraphPara
			/// <summary>�O���t�p�����[�^���X�g�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �O���t�p�����[�^���X�g�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<int> _GraphPara
			{
				get { return _graphPara; }
				set { _graphPara = value; }
			}

			/// public propaty name  :  _GraphShow
			/// <summary>�O���t�\���E��\���p�����[�^�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �O���t�\���E��\���p�����[�^�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<int> _GraphShow
			{
				get { return _graphShow; }
				set { _graphShow = value; }
			}

			/// public propaty name  :  _Code
			/// <summary>�Ώۍ���2�R�[�h���X�g�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �Ώۍ���2�R�[�h���X�g�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _Code
			{
				get { return _code; }
				set { _code = value; }
			}

			/// public propaty name  :  _Name
			/// <summary>�Ώۍ���2���O���X�g�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �Ώۍ���2���O���X�g�v���p�e�B</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _Name
			{
				get { return _name; }
				set { _name = value; }
			}

			/// public propaty name  :  _checkedItem_r
			/// <summary>�`�F�b�N���ꂽ���ڂ�ێ��F�Ώۍ��ځE�䗦�p</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �䗦�p�`�F�b�N�L���b�V��</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<bool> _CheckedIteme_r
			{
				get { return _checkedItem_r; }
				set { _checkedItem_r = value; }
			}

			/// public propaty name  :  _checkedItem_r
			/// <summary>�`�F�b�N���ꂽ���ڂ�ێ��F�Ώۍ��ځE���z�p</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���z�p�`�F�b�N�L���b�V��</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<bool> _CheckedIteme_s
			{
				get { return _checkedItem_s; }
				set { _checkedItem_s = value; }
			}

			
		/// public propaty name  :  _codeCashe_r
			/// <summary>�`�F�b�N���ꂽ�n�̃R�[�h��ێ��F�Ώۍ���2</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �䗦�p�R�[�h�L���b�V��</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _CodeCashe_r
			{
				get { return _codeCashe_r; }
				set { _codeCashe_r = value; }
			}

			/// public propaty name  :  _codeCashe_s
			/// <summary>�`�F�b�N���ꂽ�n�̃R�[�h��ێ��F�Ώۍ���2</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���z�p�R�[�h�L���b�V��</br>
			/// <br>Programer        :   Ai Mabuchi</br>
			/// </remarks>
			public List<string> _CodeCashe_s
			{
				get { return _codeCashe_s; }
				set { _codeCashe_s = value; }
			}
		#endregion	�v���p�e�B

		}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Library.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// CSV�捞�N���X
    /// </summary>
    public partial class CsvImportForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CsvImportForm()
        {
            InitializeComponent();
        }
        #endregion

        #region const
        // �A�Z���u��ID
        private const string CT_ASSEMBLYID = "SFMIT010201U";
        //�@�t�H�[�}�b�g�t�@�C����
        private const string CT_TIRE = "tire.csv";
        private const string CT_OIL = "oil.csv";
        private const string CT_BATTERY = "battery.csv";
        // �w�b�_�[�t�H�[�}�b�g
        //private const string CT_HEADERCOMMON = @" ""���J(���l���́�0:����OFF�A1:����ON)"", ""����(���l���́�0:����OFF�A1:����ON)"", ""�i��"", ""Ұ��CD"", ""Ұ����"",";
        //private const string CT_HEADERCOMMON = @"""���J(���l���́�0:����OFF�A1:����ON)"", ""����(���l���́�0:����OFF�A1:����ON)"", ""�i��"", ""Ұ��CD"", ""Ұ����"",";
        private const string CT_HEADERCOMMON = @"���J(���l���́�0:����OFF�A1:����ON),����(���l���́�0:����OFF�A1:����ON),�i��,Ұ��CD,Ұ����,";



        //private const string CT_HEADER_TIRE = @" ""����(��:205/65R15)"", ""�����ڽ(���l���́�0:����OFF�A1:����ON)"",";
        private const string CT_HEADER_TIRE = @"����(��:205/65R15),�����ڽ(���l���́�0:����OFF�A1:����ON),";

        //private const string CT_HEADER_BATTERY = @" ""�K�i(��:50B24)"", ""�K��(���l���́�1:�W���Ԑ�p�A2:ISS�Ԑ�p�A3:���p)"",";
        private const string CT_HEADER_BATTERY = @"�K�i(��:50B24),�K��(���l���́�1:�W���Ԑ�p�A2:ISS�Ԑ�p�A3:���p),";


        //private const string CT_HEADER_OIL = @" ""�S�x(��:0W-20)"", ""�K��(���l���́�1:�޿�ݐ�p�A2:�ި���ِ�p�A3:���p)"",";
        private const string CT_HEADER_OIL = @"�S�x(��:0W-20),�K��(���l���́�1:�޿�ݐ�p�A2:�ި���ِ�p�A3:���p),";


        //private const string CT_HEADERCOMMON2 = @" ""���i����"", ""���i����"", ""���i���o��"", ""������(��:20160601)"", ""���J�J�n��(��:20160601)"", ""���J�I����(��:20160630)"",";
        private const string CT_HEADERCOMMON2 = @"���i����,���i����,���i���o��,������(��:20160601),���J�J�n��(��:20160601),���J�I����(��:20160630),";


        //private const string CT_HEADER_PM = @" ""�݌ɏ��(���l���́�1:���A2:���A3�F�~)"", ""�W�����i"", ""�X�����i"", ""����"", ""�d������"" ";
        private const string CT_HEADER_PM = @"�݌ɏ��(���l���́�1:���A2:���A3�F�~),�W�����i,�X�����i,����,�d������";

        //private const string CT_HEADER_SF = @" ""�W�����i"", ""�X�����i"", ""�d������"" ";
        private const string CT_HEADER_SF = @"�W�����i,�X�����i,�d������";
        #endregion

        private const int RELEASE = 0;              //���J
        private const int RECOMMEND = 1;            //�I�X�X��
        private const int GOODSNO = 2;              //�i��
        private const int MAKERCD = 3;              //���[�J�[�R�[�h
        private const int MAKERNM = 4;              //���[�J�[����
        private const int TAG1 = 5;                 // ���i�^�O1
        private const int TAG2 = 6;                 // ���i�^�O2
        private const int GOODSNM = 7;              //���i����
        private const int GOODSNOTE = 8;            //���i���� 
        private const int GOODSPR = 9;              //���iPR
        private const int RELEASEDATE = 10;         //������
        private const int SHOPSALEBEGINDATE = 11;   //���J�J�n��
        private const int SHOPSALEENDDATE = 12;     //���J�I����
        private const int STOCKSTATE = 13;          //�݌ɏ��
        private const int SUGGEST_PRICE = 14;       //�W�����i
        private const int SHOPP_PRICE = 15;         //�X�����i
        private const int TRADE_PRICE_PM = 16;      //(���i��:�̔����i)
        private const int PURCHASE_COST = 17;       //�d������

        private const int SF_SUGGEST_PRICE = 13;    //�W�����i(SF)
        private const int SF_SHOPP_PRICE = 14;      //�X�����i(SF)
        private const int SF_PURCHASE_COST = 15;    //�d������(SF)

        #region memo

        // �捞�G���[��
        private const string ct_ErrSt = "-999";
        private const int ct_ErrInt = -999;
        private const short ct_Errshort = -999;
        private const double ct_ErrDouble = -999;

        // ����
        // 0:���J, 1:���� ,2:�i��, 3:Ұ��CD, 4:Ұ����
        // 7:���i����, 8:���i���� ,9:���iPR, 10:������, 11:���J�J�n��, 12:���J�I����

        // �^�C��
        // 5:����, 6:�����ڽ

        // �o�b�e��
        // 5:�K�i, 6:�K��

        // �I�C��
        // 5:�S�x, 6:�K��


        // PM
        // 13:�݌ɏ��, 14:�W�����i, 15:�X�����i, 16:����, 17:�d������

        // SF
        // 13:�W�����i, 14:�X�����i, 15:�d������

        #endregion

        #region �����o
        // �N�����[�h(1:�����H��A2�F���i��)
        public int _bootMode;
        // �J�e�S��ID
        public long _categoryId;
        // �J�e�S������
        public string _categoryName;
        // �J�������X�g
        public List<string> _colList;
        // ��ď��i�N���X
        public List<Propose_Goods> _proposeGoodsList;
        // OpenFile�_�C�A���O
        private OpenFileDialog _openFileDialog;
        // �t�H�[�}�b�g�t�@�C����
        private string _formatFileNm;

        // ���t�̏��(�J�����_�[�̏���ɍ��킹��)
        private DateTime _minValue;
        private DateTime _maxValue;
        #endregion

        #region Public
        /// <summary>
        /// �N������
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowCsvImportForm()
        {
            // �J�e�S�����̂�ݒ�
            this.Category_textBox.Text = _categoryName;
            this._openFileDialog = new OpenFileDialog();
            this._openFileDialog.Filter = "CSV�t�@�C��(*.csv)|*.csv";
            this._openFileDialog.RestoreDirectory = true;

            this._proposeGoodsList = new List<Propose_Goods>();

            this._formatFileNm = "";
            //if (this._categoryId == 1) this._formatFileNm = CT_TIRE;
            //if (this._categoryId == 2) this._formatFileNm = CT_OIL;
            //if (this._categoryId == 3) this._formatFileNm = CT_BATTERY;

            if (this._categoryId == 1) this._formatFileNm = CT_TIRE;
            if (this._categoryId == 2) this._formatFileNm = CT_BATTERY;
            if (this._categoryId == 3) this._formatFileNm = CT_OIL;

            this._minValue = new DateTime(1753, 1, 1);
            this._maxValue = new DateTime(9998, 12, 31);


            return this.ShowDialog();
        }
        #endregion

        #region Private
        /// <summary>
        /// �o�̓{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Output_button_Click(object sender, EventArgs e)
        {
            // �o�͐�w��

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //�㕔�ɕ\����������e�L�X�g���w�肷��
            fbd.Description = "�t�H�[�}�b�g�o�͐�t�H���_��I�����ĉ������B";

            //�f�t�H���g��Desktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;

            //�_�C�A���O��\������
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //�I�����ꂽ�t�H���_��\������
                string path = fbd.SelectedPath;


                if (File.Exists(Path.Combine(fbd.SelectedPath, this._formatFileNm)))
                {
                    DialogResult rlt = TMsgDisp.Show(
                       this,							            // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                // �G���[���x��
                       CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
                       this._formatFileNm + "�͊��ɑ��݂��܂��B"
                       + Environment.NewLine
                       + "�㏑�����܂����H",	                    // �\�����郁�b�Z�[�W 
                       0,								            // �X�e�[�^�X�l
                       MessageBoxButtons.YesNo);

                    if (rlt == DialogResult.No) return;
                }

                string text2 = "";

                switch (this._categoryId)
                {
                    case 1:
                        text2 += CT_HEADERCOMMON + CT_HEADER_TIRE + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                    case 2:
                        text2 += CT_HEADERCOMMON + CT_HEADER_BATTERY + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                    case 3:
                        text2 += CT_HEADERCOMMON + CT_HEADER_OIL + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                }

                try
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, this._formatFileNm), false, System.Text.Encoding.GetEncoding("shift_jis")))
                    {
                        //sw.WriteLine(text1);
                        sw.WriteLine(text2);

                        TMsgDisp.Show(
                        this,							            // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,	            // �G���[���x��
                        CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
                        "�t�H�[�}�b�g�t�@�C�����o�͂��܂����B",	    // �\�����郁�b�Z�[�W 
                        0,								            // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                       this,							        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_STOPDISP,	        // �G���[���x��
                       CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                       "�o�͂Ɏ��s���܂����B" 
                       + Environment.NewLine
                       + ex.StackTrace.ToString(),	            // �\�����郁�b�Z�[�W 
                       -1,								        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// �捞�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_button_Click(object sender, EventArgs e)
        {
            //�_�C�A���O�{�b�N�X�̏����ݒ���s��
            DialogResult ret = this._openFileDialog.ShowDialog();
            if (ret == DialogResult.OK)
            {
                long rowNo = 0;
                string errMsg = "";
                List<string> errMsgList = new List<string>();

                try
                {
                    string path = Path.GetFullPath(_openFileDialog.FileName);

                    // CSV�捞
                    Encoding Encode = Encoding.GetEncoding("Shift_JIS");    // Encode�w��
                    using (TextFieldParser Parser = new TextFieldParser(path, Encode))
                    {
                        Parser.TextFieldType = FieldType.Delimited;    // �t�B�[���h��؂�^�C�v
                        Parser.Delimiters = new string[] { "," };      // ��؂蕶��
                        //Parser.HasFieldsEnclosedInQuotes = true;       // �_�u���R�[�e�[�V������؂�
                        Parser.HasFieldsEnclosedInQuotes = false;       // �_�u���R�[�e�[�V������؂�
                        //Parser.CommentTokens = new string[] { "#" };     // ���R�[�h�擪�̃R�����g����
                        Parser.TrimWhiteSpace = true;                  // �t�B�[���h�̑O��X�y�[�X���폜

                        bool firstData = false;

                       

                        // �f�[�^�ǂݍ���
                        while (!Parser.EndOfData)
                        {
                            string[] fields = Parser.ReadFields();

                            // �s�ԍ�
                            rowNo = Parser.LineNumber == -1 ? rowNo + 1 : Parser.LineNumber - 1;

                            // 1�s�ڂ̓w�b�_�Ƃ��ēǂݔ�΂�
                            if (firstData == false)
                            {
                                firstData = true;
                                continue;
                            }

                            // �s���f�[�^�`�F�b�N�@�s���f�[�^�͓ǂݔ�΂����O�\��
                            // �u,�v�`�F�b�N
                            if (this._bootMode == 1)
                            {
                                // ���i�����[�h
                                // ����F18��

                                if (fields.Length < 18)
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "CSV�t�@�C�����̍��ڐ����s�����Ă��܂��B" + " " + "���ڐ����m�F���ĉ������B";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                                else if (fields.Length > 18)
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "CSV�t�@�C�����̍��ڐ������߂��Ă��܂��B" + "���ڂɁu,(�J���})�v���܂܂�Ă��Ȃ����m�F���ĉ������B";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                            }
                            else
                            {
                                // �����H�ꃂ�[�h
                                // ����16��
                                if (fields.Length < 16)
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "CSV�t�@�C�����̍��ڐ����s�����Ă��܂��B" + " " + "���ڐ����m�F���ĉ������B";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                                else if (fields.Length > 16)
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "CSV�t�@�C�����̍��ڐ������߂��Ă��܂��B" + "���ڂɁu,(�J���})�v���܂܂�Ă��Ȃ����m�F���ĉ������B";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                            }

                            Propose_Goods goods = new Propose_Goods();
                            goods.GoodsCategory = this._categoryId;

                            // ���J 
                            try
                            {
                                if (fields[RELEASE].Equals("0") || fields[RELEASE].Equals("1"))
                                {
                                    goods.release = Convert.ToInt32(fields[RELEASE]);
                                }
                                else
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�v�̎捞�Ɏ��s���܂����B" + " " + "0����1��ݒ肵�ĉ������B";
                                    goods.release = ct_ErrInt;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�v�̎捞�Ɏ��s���܂����B" + " " + "0����1��ݒ肵�ĉ������B";
                                goods.release = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // �I�X�X��
                            try
                            {
                                if (fields[RECOMMEND].Equals("0") || fields[RECOMMEND].Equals("1"))
                                {
                                    goods.recommend = Convert.ToInt32(fields[RECOMMEND]);
                                }
                                else
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�I�X�X���v�̎捞�Ɏ��s���܂����B" + " " + "0����1��ݒ肵�ĉ������B";
                                    goods.recommend = ct_ErrInt;
                                    errMsgList.Add(errMsg);
                                }
                               
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u�I�X�X���v�̎捞�Ɏ��s���܂����B" + " " + "0����1��ݒ肵�ĉ������B";
                                goods.recommend = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // �i�� MAX24�� �C���M�����[�l�̏ꍇ��""
                            if (fields[GOODSNO].Length <= 24)
                            {
                                goods.GoodsNo = fields[GOODSNO];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u�i�ԁv�̎捞�Ɏ��s���܂����B" + " " + "24���ȓ��œ��͂��ĉ������B";
                                goods.GoodsNo = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // ���[�J�[�R�[�h MAX4�� 
                            try
                            {
                                // ���l���ڂ̂ݖ����͂̏ꍇ��0��������
                                if (string.IsNullOrEmpty(fields[MAKERCD]))
                                {
                                    // �����͂̏ꍇ��0����
                                    goods.GoodsMakerCd = 0;
                                }
                                else
                                {
                                    int GoodsMakerCd = Convert.ToInt32(fields[MAKERCD]);
                                    if (GoodsMakerCd < 0)
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u���[�J�[CD�v�̎捞�Ɏ��s���܂����B" + " " + "�}�C�i�X�͎g�p�ł��܂���B";
                                        goods.GoodsMakerCd = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                    else if (GoodsMakerCd.ToString().Length <= 4)
                                    {
                                        goods.GoodsMakerCd = GoodsMakerCd;
                                    }
                                    else 
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u���[�J�[CD�v�̎捞�Ɏ��s���܂����B" + " " + "4���ȓ��œ��͂��ĉ������B";
                                        goods.GoodsMakerCd = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���[�J�[CD�v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                goods.GoodsMakerCd = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // ���[�J�[���� MAX30�� �C���M�����[�l�̏ꍇ��""
                            if (fields[MAKERNM].Length <= 30)
                            {
                                goods.MakerName = fields[MAKERNM];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���[�J�[���́v�̎捞�Ɏ��s���܂����B" + " " + "30���ȓ��œ��͂��ĉ������B";
                                goods.MakerName = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // ���i���� MAX60�� �C���M�����[�l�̏ꍇ��""
                            if (fields[GOODSNM].Length <= 60)
                            {
                                goods.GoodsName = fields[GOODSNM];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���i���́v�̎捞�Ɏ��s���܂����B" + " " + "60���ȓ��œ��͂��ĉ������B";
                                goods.GoodsName = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // ���i���� MAX256 �C���M�����[�l�̏ꍇ��""
                            if (fields[GOODSNOTE].Length <= 256)
                            {
                                goods.GoodsNote = fields[GOODSNOTE];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���i�����v�̎捞�Ɏ��s���܂����B" + " " + "256���ȓ��œ��͂��ĉ������B";
                                goods.GoodsNote = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // ���iPR MAX15 �C���M�����[�l�̏ꍇ��""
                            if (fields[GOODSPR].Length <= 15)
                            {
                                goods.GoodsPR = fields[GOODSPR];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���i���o���v�̎捞�Ɏ��s���܂����B" + " " + "15���ȓ��œ��͂��ĉ������B";
                                goods.GoodsPR = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // ������ YYYYMMDD �C���M�����[�l�̏ꍇ��0
                            try
                            {
                                if (string.IsNullOrEmpty(fields[RELEASEDATE]))
                                {
                                    // �����͂̏ꍇ��0����
                                    goods.ReleaseDate = 0;
                                }
                                else
                                {
                                    int ReleaseDate = Convert.ToInt32(fields[RELEASEDATE]);
                                    if (ReleaseDate == 0)
                                    {
                                        // 0��OK
                                        goods.ReleaseDate = ReleaseDate;
                                    }
                                    else if (ReleaseDate.ToString().Length == 8)
                                    {
                                        DateTime releaseDate = DateTime.MinValue;
                                        // �J���`���[�ݒ�
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        releaseDate = DateTime.ParseExact(ReleaseDate.ToString(), "yyyyMMdd", format);

                                        if ((releaseDate != DateTime.MinValue) &&
                                            (releaseDate >= this._minValue && releaseDate <= this._maxValue) // �J�����_�[�R���|�͈͓̔�
                                            )
                                        {
                                            goods.ReleaseDate = ReleaseDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�������v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                            goods.ReleaseDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u�������v�̎捞�Ɏ��s���܂����B" + " " + "8���œ��͂��ĉ������B";
                                        goods.ReleaseDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u�������v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                goods.ReleaseDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // ���i�^�O MAX32�� �C���M�����[�l�̏ꍇ��""
                            if (fields[TAG1].Length <= 32)
                            {
                                goods.SearchTag1 = fields[TAG1];
                            }
                            else
                            {
                                switch (this._categoryId)
                                {
                                    case 1:
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u�T�C�Y�v�̎捞�Ɏ��s���܂����B" + " " + "32���ȓ��œ��͂��ĉ������B";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                    case 2:
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u�K�i�v�̎捞�Ɏ��s���܂����B" + " " + "32���ȓ��œ��͂��ĉ������B";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                    case 3:
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u�S�x�v�̎捞�Ɏ��s���܂����B" + " " + "32���ȓ��œ��͂��ĉ������B";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                }
                            }

                            // ���i�^�O�Q�`�R�@�C���M�����[�l�̏ꍇ��""
                            switch (this._categoryId)
                            {
                                case 1:
                                    if (fields[TAG2].Equals("0") || fields[TAG2].Equals("1"))
                                    {
                                        goods.SearchTag2 = fields[TAG2];
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�^�b�h���X�v�̎捞�Ɏ��s���܂����B" + " " + "0����1��ݒ肵�ĉ������B";
                                        goods.SearchTag2 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                    }
                                    break;
                                case 2:
                                    switch (fields[TAG2])
                                    {
                                        case "1":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "0";
                                            break;
                                        case "2":
                                            goods.SearchTag2 = "0";
                                            goods.SearchTag3 = "1";
                                            break;
                                        case "3":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "1";
                                            break;
                                        default:
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�K���v�̎捞�Ɏ��s���܂����B" + " " + "1�A2�A3�̉��ꂩ��ݒ肵�ĉ������B";
                                            goods.SearchTag2 = ct_ErrSt;
                                            goods.SearchTag3 = ct_ErrSt;
                                            errMsgList.Add(errMsg);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (fields[TAG2])
                                    {
                                        case "1":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "0";
                                            break;
                                        case "2":
                                            goods.SearchTag2 = "0";
                                            goods.SearchTag3 = "1";
                                            break;
                                        case "3":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "1";
                                            break;
                                        default:
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�K���v�̎捞�Ɏ��s���܂����B" + " " + "1�A2�A3�̉��ꂩ��ݒ肵�ĉ������B";
                                            goods.SearchTag2 = ct_ErrSt;
                                            goods.SearchTag3 = ct_ErrSt;
                                            errMsgList.Add(errMsg);
                                            break;
                                    }
                                    break;
                            }

                            // ���J�J�n��
                            try
                            {
                                // �����́A0�̏ꍇ�͌��ʓI�ɃV�X�e�����t
                                if (string.IsNullOrEmpty(fields[SHOPSALEBEGINDATE]))
                                {
                                    // �����͂̏ꍇ��0����
                                    goods.ShopSaleBeginDate = 0;
                                }
                                else
                                {
                                    int beginDate = Convert.ToInt32(fields[SHOPSALEBEGINDATE]);
                                    if (beginDate == 0)
                                    {
                                        // 0��OK �������V�X�e�����t������
                                        goods.ShopSaleBeginDate = beginDate;
                                    }
                                    else if (beginDate.ToString().Length == 8)
                                    {
                                        DateTime beginDateTime = DateTime.MinValue;
                                        // �J���`���[�ݒ�
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        beginDateTime = DateTime.ParseExact(beginDate.ToString(), "yyyyMMdd", format);

                                        if ((beginDateTime != DateTime.MinValue) &&
                                           (beginDateTime >= this._minValue && beginDateTime <= this._maxValue) // �J�����_�[�R���|�͈͓̔�
                                            )
                                        {
                                            goods.ShopSaleBeginDate = beginDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�J�n���v�̎捞�Ɏ��s���܂����B" + " " + "�s���ȓ��t�ł��B";
                                            goods.ShopSaleBeginDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�J�n���v�̎捞�Ɏ��s���܂����B" + " " + "8���œ��͂��ĉ������B";
                                        goods.ShopSaleBeginDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�J�n���v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                goods.ShopSaleBeginDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // ���J�I�����@�[����������
                            try
                            {
                                if (string.IsNullOrEmpty(fields[SHOPSALEENDDATE]))
                                {
                                    // �����͂̏ꍇ��0����
                                    goods.ShopSaleEndDate = 0;
                                }
                                else
                                {
                                    int endDate = Convert.ToInt32(fields[SHOPSALEENDDATE]);
                                    if (endDate == 0)
                                    {
                                        // 0�͂n�j
                                        goods.ShopSaleEndDate = endDate;
                                    }
                                    else if (endDate.ToString().Length == 8)
                                    {
                                        DateTime endDateTime = DateTime.MinValue;
                                        // �J���`���[�ݒ�
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        endDateTime = DateTime.ParseExact(endDate.ToString(), "yyyyMMdd", format);

                                        if ((endDateTime != DateTime.MinValue) &&
                                            (endDateTime >= this._minValue && endDateTime <= this._maxValue) // �J�����_�[�R���|�͈͓̔�
                                           )
                                        {
                                            goods.ShopSaleEndDate = endDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�I�����v�̎捞�Ɏ��s���܂����B" + " " + "�s���ȓ��t�ł��B";
                                            goods.ShopSaleEndDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�I�����v�̎捞�Ɏ��s���܂����B" + " " + "8���œ��͂��ĉ������B";
                                        goods.ShopSaleEndDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "�s��>" + " " + "�u���J�I�����v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                goods.ShopSaleEndDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }


                            if (this._bootMode == 1)
                            {
                                // ���i�����[�h

                                // �݌ɏ�� �C���M�����[�l�̏ꍇ��-1
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[STOCKSTATE]))
                                    {
                                        // �����͂̏ꍇ��-1���� �݌ɏ�Ԃ����悤���Ȃ��ꍇ��z��
                                        goods.StockStatusDiv = -1;
                                    }
                                    else
                                    {
                                        short StockStatusDiv = Convert.ToInt16(fields[STOCKSTATE]);
                                        if (StockStatusDiv > 0 && StockStatusDiv <= 3)
                                        {
                                            goods.StockStatusDiv = StockStatusDiv;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�݌ɏ�ԁv�̎捞�Ɏ��s���܂����B" + " " + "1�A2�A3�̉��ꂩ��ݒ肵�ĉ������B";
                                            goods.StockStatusDiv = ct_Errshort;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�݌ɏ�ԁv�̎捞�Ɏ��s���܂����B" + " " + "1�A2�A3�̉��ꂩ��ݒ肵�ĉ������B";
                                    goods.StockStatusDiv = ct_Errshort;
                                    errMsgList.Add(errMsg);
                                }

                                // �W�����i MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SUGGEST_PRICE]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.SuggestPrice = 0;
                                    }
                                    else
                                    {
                                        long SuggestPrice = Convert.ToInt64(fields[SUGGEST_PRICE]);
                                        if (SuggestPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ł��B";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length <= 9 && SuggestPrice >= 0)
                                        {
                                            goods.SuggestPrice = Convert.ToDouble(SuggestPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.SuggestPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // �X�����i�@MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SHOPP_PRICE]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.ShopPrice = 0;
                                    }
                                    else
                                    {
                                        long ShopPrice = Convert.ToInt64(fields[SHOPP_PRICE]);
                                        if (ShopPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ł��B";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length <= 9 && ShopPrice >= 0)
                                        {
                                            goods.ShopPrice = Convert.ToDouble(ShopPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.ShopPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // �����@MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[TRADE_PRICE_PM]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.TradePrice = 0;
                                    }
                                    else
                                    {
                                        long TradePrice = Convert.ToInt64(fields[TRADE_PRICE_PM]);
                                        if (TradePrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�����v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ł��B";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�����v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length < 9 && TradePrice >= 0)
                                        {
                                            goods.TradePrice = Convert.ToDouble(TradePrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�����v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.TradePrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // �d�������@MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[PURCHASE_COST]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.PurchaseCost = 0;
                                    }
                                    else
                                    {
                                        long PurchaseCost = Convert.ToInt64(fields[PURCHASE_COST]);
                                        if (PurchaseCost < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ł��B";
                                            goods.PurchaseCost = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (PurchaseCost.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.PurchaseCost = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (PurchaseCost.ToString().Length < 9 && PurchaseCost >= 0)
                                        {
                                            goods.PurchaseCost = Convert.ToDouble(PurchaseCost);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.PurchaseCost = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            else
                            {
                                // �����H�ꃂ�[�h

                                // �W�����i�@MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_SUGGEST_PRICE]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.SuggestPrice = 0;
                                    }
                                    else
                                    {
                                        long SuggestPrice = Convert.ToInt64(fields[SF_SUGGEST_PRICE]);
                                        if (SuggestPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ɂȂ��Ă��܂��B";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length <= 9 && SuggestPrice >= 0)
                                        {
                                            goods.SuggestPrice = Convert.ToDouble(SuggestPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�W�����i�v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.SuggestPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // �X�����i�@MAX9�� �C���M�����[�l�̏ꍇ��0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_SHOPP_PRICE]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.ShopPrice = 0;
                                    }
                                    else
                                    {
                                        long ShopPrice = Convert.ToInt64(fields[SF_SHOPP_PRICE]);
                                        if (ShopPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ɂȂ��Ă��܂��B";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length <= 9 && ShopPrice >= 0)
                                        {
                                            goods.ShopPrice = Convert.ToDouble(ShopPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�X�����i�v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.ShopPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // �d�������@MAX9�� �����H�ꃂ�[�h�̏ꍇ��TradePrice�ɃZ�b�g
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_PURCHASE_COST]))
                                    {
                                        // �����͂̏ꍇ��0����
                                        goods.TradePrice = 0;
                                    }
                                    else
                                    {
                                        long TradePrice = Convert.ToInt64(fields[SF_PURCHASE_COST]);
                                        if (TradePrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "���z���}�C�i�X�ɂȂ��Ă��܂��B";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "9���ȓ��œ��͂��ĉ������B";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length <= 9 && TradePrice >= 0)
                                        {
                                            goods.TradePrice = Convert.ToDouble(TradePrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "�s��>" + " " + "�u�d�������v�̎捞�Ɏ��s���܂����B" + " " + "�s���Ȓl�ł��B";
                                    goods.TradePrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            this._proposeGoodsList.Add(goods);
                        }

                        if (errMsgList.Count > 0)
                        {
                            // ���O���o��

                            string logPath = System.IO.Path.GetDirectoryName(path);
                            string logfileName = "ErrLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                            try
                            {
                                using (StreamWriter sw = new StreamWriter(Path.Combine(logPath, logfileName), true, System.Text.Encoding.GetEncoding("shift_jis")))
                                {
                                    foreach (string msg in errMsgList)
                                    {
                                        sw.WriteLine(msg);
                                    }
                                }

                                 TMsgDisp.Show(
                                  this,							            // �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // �G���[���x��
                                  CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
                                  "�ꕔ�f�[�^�̎捞�Ɏ��s���܂����B" + Environment.NewLine
                                  + "�ڍׂ̓��O�t�@�C�����m�F���ĉ������B" + Environment.NewLine
                                  + "�y���O�t�@�C���z" + Environment.NewLine + Path.Combine(logPath, logfileName),
                                  -1,								        // �X�e�[�^�X�l
                                  MessageBoxButtons.OK);
                            }
                            catch
                            {
                                // ���O�o�͂Ɏ��s
                                  TMsgDisp.Show(
                                  this,							            // �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // �G���[���x��
                                  CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
                                  "�ꕔ�f�[�^�̎捞�Ɏ��s���܂����B" + Environment.NewLine +
                                  "�捞���ʂ̊m�F���s���ĉ������B",
                                  -1,								        // �X�e�[�^�X�l
                                  MessageBoxButtons.OK);
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                     this,							            // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	        // �G���[���x��
                     CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
                     "CSV�̓Ǎ��݂Ɏ��s���܂����B"
                     + Environment.NewLine
                     + ex.StackTrace.ToString(),	            // �\�����郁�b�Z�[�W 
                     -1,								        // �X�e�[�^�X�l
                     MessageBoxButtons.OK);
                }
            }
        }
        #endregion
    }
}
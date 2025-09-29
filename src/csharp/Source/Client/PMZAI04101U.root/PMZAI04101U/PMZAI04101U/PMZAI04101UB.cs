using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���̓`���[�g�r���[�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̓`���[�g��\������t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date       : 2010.02.18</br>
    /// </remarks>
    internal partial class AnalysisChartViewForm : Form
    {
        #region Constructor
        /// <summary>
        /// ���̓`���[�g�r���[�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="parentForm">�e�t�H�[���i���̓`���[�g���C���t���[���j</param>
        /// <remarks>
        /// <br>Note       : ���̓`���[�g�r���[�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        internal AnalysisChartViewForm(PMZAI04101UA parentForm)
        {
            InitializeComponent();

            // �e�t�H�[���i���̓`���[�g���C���t���[���j
            this._parentForm = parentForm;

            // �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
            this._drillDownChartList = new SortedList();

            // �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
            this._condtionClickChartList = new SortedList();

            // �`���[�g�p�����[�^���X�g������
            this._chartInfoList = new SortedList();

            // ���̓`���[�g�\���ݒ�A�N�Z�X�N���X
            this._analysisChartSettingAcs = new AnalysisChartSettingAcs();

            // �`���[�g���o�N���X�I�u�W�F�N�g���X�g������
            //this._chartExtractList = new List<IChartExtract>();

            // �`���[�g�\���p�f�[�^�Z�b�g�C���X�^���X��
            this._chartDataSet = new DataSet();

            // �`���[�g�\���p�f�[�^�Z�b�g�X�L�[�}�ݒ�
            SetTableSchema();
        }
        #endregion

        #region Private Member
        /// <summary>�e�t�H�[���i���̓`���[�g���C���t���[���j</summary>
        private PMZAI04101UA _parentForm = null;

        /// <summary>�h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
        private SortedList _drillDownChartList = null;

        /// <summary>�����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
        private SortedList _condtionClickChartList = null;

        /// <summary>�`���[�g�p�����[�^���X�g</summary>
        private SortedList _chartInfoList = null;

        /// <summary>�`���[�g�����N���X</summary>
        private ChartLibrary _chartLibrary = null;

        /// <summary>�`���[�g�\���p�f�[�^�Z�b�g</summary>
        private DataSet _chartDataSet;

        /// <summary>���̓`���[�g�\���ݒ�A�N�Z�X�N���X</summary>
        private AnalysisChartSettingAcs _analysisChartSettingAcs = null;

        /// <summary>�`���[�g���o�N���X�I�u�W�F�N�g���X�g</summary>
        //private List<IChartExtract> _chartExtractList = null;

        // 2010/04/30 Add >>>
        /// <summary>�`���[�g�X�^�C���L���b�V��</summary>
        private int[] _chartStyle = new int[3] { 0, 0, 0 };

        /// <summary>�܂���{�_�O���t�p�L���b�V��</summary>
        private List<int>[] _seriesList = new List<int>[3] { null, null, null };
        // 2010/04/30 Add <<<
        #endregion

        #region const
        // DataTable�����`���[�g�p�e�[�u����
        private const string TBL_ANNUALDATA_TITLE = "ANNUALDATA_TABLE";

        // DataTable�񖼁��`���[�g�p�e�[�u����
        private const string COL_TITLE = "COL_TITLE";
        private const string COL_SALESTIMES = "COL_PARA01";
        private const string COL_SALESCOUNT = "COL_PARA02";
        private const string COL_SALESMONEY = "COL_PARA03";
        private const string COL_STOCKTIMES = "COL_PARA04";
        private const string COL_STOCKCOUNT = "COL_PARA05";
        private const string COL_STOCKMONEY = "COL_PARA06";
        private const string COL_GRPROFIT = "COL_PARA07";
        private const string COL_MOVEACOUNT = "COL_PARA08";
        private const string COL_MOVEAPRICE = "COL_PARA09";
        private const string COL_MOVESCOUNT = "COL_PARA10";
        private const string COL_MOVESPRICE = "COL_PARA11";
        #endregion

        #region Property
        ///// <summary>�`���[�g���o�I�u�W�F�N�g���X�g�v���p�e�B</summary>
        //internal List<IChartExtract> ChartExtractList
        //{
        //    get { return this._chartExtractList; }
        //    set { this._chartExtractList = value; }
        //}

        /// <summary>���̓`���[�g���Ǘ��N���X���X�g������v���p�e�B�i�ǂݎ���p�j</summary>
        internal string AnalysisChartControlListString
        {
            get
            {
                StringBuilder analysisChartControlListString = new StringBuilder(string.Empty);
                return analysisChartControlListString.ToString();
            }
        }
        #endregion

        #region Private Method

        #region ���̓`���[�g�f�[�^��������
        /// <summary>
        /// ���̓`���[�g�f�[�^��������
        /// </summary>
        /// <param name="analysisChartControlList">������я��N���X���X�g</param>
        /// <returns>RESULT�itrue:OK,false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ���̓`���[�g���o�N���X�ɂĕ��̓`���[�g�f�[�^�̐������s���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private bool CreateChartData(List<StockHistoryDspSearchResult> resultData)
        {
            try
            {
                string errorMessage = "";
                int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                try
                {
                    if (resultData.Count == 0)
                    {
                        errorMessage = "�݌ɔN�Ԏ��я�񂪑��݂��܂���B";
                        result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        //�\���f�[�^�쐬����
                        CreatDispData(resultData);
                        result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                catch (Exception)
                {
                    errorMessage = "�݌ɔN�Ԏ��я��̎擾�Ɏ��s���܂����B";
                    result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                switch (result)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                            return false;
                        }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "���̓`���[�g�f�[�^�̐����Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        /// �`���[�g�p�����[�^�擾����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="parameter">�����p�����[�^</param>
        /// <param name="chartInfo">�擾�����`���[�g�p�����[�^</param>
        /// <param name="errorMessage">�G���[�������̃G���[���b�Z�[�W</param>
        /// <returns>RESULT</returns>
        /// <remarks>
        /// <br>Note       : �\������`���[�g�p�����[�^���擾���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        // 2010/04/30 >>>
        //public int GetChartInfo(object sender, object parameter, int number, out ChartInfo chartInfo, out string errorMessage)
        public int GetChartInfo(object sender, object parameter, object paramete2, int number, out ChartInfo chartInfo, out string errorMessage)
        // 2010/04/30 <<<
        {
            chartInfo = new ChartInfo();
            int[] seriesVisible;

            // �݌ɔN�Ԏ��у`���[�g
            chartInfo.Title = "�݌ɔN�Ԏ���";                       // �^�C�g��
            //chartInfo.YLabel = "���z�i�~�j";                        // Y�����x��
            chartInfo.Palette = PaletteStyle.DefaultWindows;        // �p���b�g(�F�̑g�ݍ��킹)
            //chartInfo.LegendBox = true;								// X���̖}��̕\����\��
            chartInfo.Legend = true;								// �}��̕\����\��
            chartInfo.DockPosition = EditorDockPosition.Top;		// �f�[�^�G�f�B�^�[�|�W�V����
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);   // �p�l���̐F
            chartInfo.Ydecimal = 0;									// Y�������_�ȉ���
            chartInfo.Ydecimal2 = 0;								// Y���Q�����_�ȉ���
            chartInfo.View3DDepth = 100;							// 3D�O���t�̉��s��

            chartInfo.AngleX = 20;									// X���̉�]
            chartInfo.AngleY = 40;								    // Y���̉�]

            // 2010/04/30 Add >>>
            chartInfo.Style = ChartStyle.Line;
            if (_chartInfoList.Count == 0)
            {
                _chartStyle[0] = 1;
            }
            else if (_chartInfoList.Count == 1)
            {
                _chartStyle[1] = 1;
            }
            else if (_chartInfoList.Count == 2)
            {
                _chartStyle[2] = 1;
            }
            // ���R��]
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }
            this._chartLibrary.FreeRationVisible = true;
            // 2010/04/30 Add <<<

            //Color[] piecolor;
            //piecolor = new Color[3];                      // �s���̐F�ݒ�
            //piecolor[0] = Color.FromArgb(0, 99, 224);     // ��
            //piecolor[1] = Color.FromArgb(226, 53, 0);     // ��
            //piecolor[2] = Color.FromArgb(255, 220, 0);    // ��
            //chartInfo.PieColor = piecolor;

            //�f�[�^�����݂��Ȃ��ꍇ�͂��̂܂܃t���[���ɕԂ�
            if (this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Count == 0)
            {
                errorMessage = "�݌ɔN�Ԏ��я�񂪑��݂��܂���B";
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            chartInfo.DataSource = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE]; // �f�[�^

            // 2010/04/30 Add >>>
            if (parameter == null)
            {
                List<List<int>> dummyPara = new List<List<int>>();
                DCHNB04180UD form1 = new DCHNB04180UD();
                form1._graphId = _chartInfoList.Count + 1;
                int status = form1.LoadToFiles(out dummyPara);
                if (status == 0)
                {
                    if (dummyPara.Count < 2)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else if (dummyPara[0] == null || dummyPara[1] == null)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else if (dummyPara[0].Count != 12 || dummyPara[1].Count != 12)
                    {
                        parameter = null;
                        paramete2 = null;
                    }
                    else
                    {
                        parameter = dummyPara[0];
                        paramete2 = dummyPara[1];
                        number = form1._graphId;
                    }
                }
            }
            // 2010/04/30 Add <<<

            if (parameter == null)
            {
                switch (this._chartInfoList.Count)
                {
                    case 0:
                        {
                            // ���z
                            chartInfo.SubTitle = "�� ���z ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "���z�i�~�j";    // Y�����x��
                            seriesVisible = new int[6];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 0;
                            //seriesVisible[1] = 1;
                            //seriesVisible[2] = 3;
                            //seriesVisible[3] = 4;
                            //seriesVisible[4] = 7;
                            //seriesVisible[5] = 9;
                            seriesVisible[0] = 0;
                            seriesVisible[1] = 1;
                            seriesVisible[2] = 2;
                            seriesVisible[3] = 3;
                            seriesVisible[4] = 4;
                            seriesVisible[5] = 5;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                    case 1:
                        {
                            // ����
                            chartInfo.SubTitle = "�� ���� ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "���ʁi�j";    // Y�����x��
                            seriesVisible = new int[7];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 0;
                            //seriesVisible[1] = 2;
                            //seriesVisible[2] = 3;
                            //seriesVisible[3] = 5;
                            //seriesVisible[4] = 6;
                            //seriesVisible[5] = 8;
                            //seriesVisible[6] = 10;
                            seriesVisible[0] = 0;
                            seriesVisible[1] = 1;
                            seriesVisible[2] = 6;
                            seriesVisible[3] = 7;
                            seriesVisible[4] = 8;
                            seriesVisible[5] = 9;
                            seriesVisible[6] = 10;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                    case 2:
                        {
                            // ��
                            chartInfo.SubTitle = "�� �� ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "�񐔁i��j";    // Y�����x��
                            seriesVisible = new int[9];
                            // 2010/04/30 >>>
                            //seriesVisible[0] = 1;
                            //seriesVisible[1] = 2;
                            //seriesVisible[2] = 4;
                            //seriesVisible[3] = 5;
                            //seriesVisible[4] = 6;
                            //seriesVisible[5] = 7;
                            //seriesVisible[6] = 8;
                            //seriesVisible[7] = 9;
                            //seriesVisible[8] = 10;
                            seriesVisible[0] = 2;
                            seriesVisible[1] = 3;
                            seriesVisible[2] = 4;
                            seriesVisible[3] = 5;
                            seriesVisible[4] = 6;
                            seriesVisible[5] = 7;
                            seriesVisible[6] = 8;
                            seriesVisible[7] = 9;
                            seriesVisible[8] = 10;
                            // 2010/04/30 <<<
                            chartInfo.SeriesVisible = seriesVisible;
                            break;
                        }
                }
            }
            else
            {
                List<int> para = (List<int>)parameter;
                List<int> para2 = (List<int>)paramete2; // 2010/04/30 Add
                if (para[0] == 0)
                {
                    chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                else if (para[0] == 1)
                {
                    chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                else if (para[0] == 2)
                {
                    chartInfo.Style = ChartStyle.Pie;						// �`���[�g�̃X�^�C��
                    chartInfo.Legend = false;								// �}��̕\����\��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 12; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Pie, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 2010/04/30 Add >>>
                else if (para[0] == 3)
                {
                    chartInfo.Style = ChartStyle.Radar;                     // �`���[�g�̃X�^�C��
                    chartInfo.View3DDepth = 0;						    	// 3D�O���t�̉��s��
                    chartInfo.AngleX = 0;									// X���̉�]
                    chartInfo.AngleY = 0;                                   // Y���̉�]
                }
                else if (para[0] == 4 || para[0] == 5)
                {
                    bool leftFlg = true;
                    List<int> seriesList = new List<int>();
                    for (int i = 1; i < 12; i++)
                    {
                        seriesList.Add(para2[i]);
                        switch (i)
                        {
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                                // ���z
                                if (number == 1)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                // ����
                                if (number == 2)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                            case 1:
                            case 2:
                                // ��
                                if (number == 3)
                                    leftFlg = true;
                                else
                                    leftFlg = false;
                                break;
                        }
                        SeriesAdd(ref chartInfo, para2[i], leftFlg);
                    }
                    _seriesList[number - 1] = seriesList;
                }
                // 2010/04/30 Add <<<
                int cnt = 0;
                for (int ix = 1; ix < para.Count; ix++)
                {
                    if (para[ix] == 1) cnt++;
                }
                seriesVisible = new int[cnt];

                if (cnt > 0)
                {
                    cnt = 0;
                    for (int ix = 1; ix < para.Count; ix++)
                    {
                        if (para[ix] == 1) seriesVisible[cnt++] = ix - 1;
                    }
                    chartInfo.SeriesVisible = seriesVisible;
                }
                else
                {
                    chartInfo.SeriesVisible = null;
                }

                switch (number)
                {
                    case 1:
                        {
                            // ���z
                            chartInfo.SubTitle = "�� ���z ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "���z�i�~�j";    // Y�����x��
                            // 2010/04/30 Add >>>
                            // ���z�{��
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "�� ���z�{�� ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "�񐔁i��j";    // Y�����x��
                            }
                            // ���z�{����
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "�� ���z�{���� ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "���ʁi�j";    // Y�����x��
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                    case 2:
                        {
                            // ����
                            chartInfo.SubTitle = "�� ���� ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "���ʁi�j";    // Y�����x��
                            // 2010/04/30 Add >>>
                            // ���ʁ{���z
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "�� ���ʁ{���z ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "���z�i�~�j";    // Y�����x��
                            }
                            // ���ʁ{��
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "�� ���ʁ{�� ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "�񐔁i��j";    // Y�����x��
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                    case 3:
                        {
                            // ��
                            chartInfo.SubTitle = "�� �� ��";  // �T�u�^�C�g��
                            chartInfo.YLabel = "�񐔁i��j";    // Y�����x��
                            // 2010/04/30 Add >>>
                            // �񐔁{����
                            if (para[0] == 4)
                            {
                                chartInfo.SubTitle = "�� �񐔁{���� ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "���ʁi�j";    // Y�����x��
                            }
                            // �񐔁{���z
                            else if (para[0] == 5)
                            {
                                chartInfo.SubTitle = "�� �񐔁{���z ��";  // �T�u�^�C�g��
                                chartInfo.YLabel2 = "���z�i�~�j";    // Y�����x��
                            }
                            // 2010/04/30 Add <<<
                            break;
                        }
                }
                _chartStyle[number - 1] = para[0];
            }

            errorMessage = "";
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        private void SeriesAdd(ref ChartInfo chartInfo, int para2, bool leftFlg)
        {
            switch (para2)
            {
                case 0: // �_�O���t�i��j
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 100));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Right, false, 100));
                    break;
                case 1: // �_�O���t�i���j
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 50));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Right, false, 50));
                    break;
                case 2: // �܂���O���t�i��j
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 100));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Right, false, 100));
                    break;
                case 3: // �܂���O���t�i���j
                    if (leftFlg)
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 50));
                    else
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Right, false, 50));
                    break;
            }
        }

        /// <summary>
        /// �`���[�g�\���f�[�^�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�\���p�f�[�^�Z�b�g���쐬���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void CreatDispData(List<StockHistoryDspSearchResult> resultData)
        {
            StockHistoryDspSearchResult data;
            DataRow dr;
            int monthCount = 0;
            int monthWork = 0;

            // �\�����`�F�b�N(���񕪂͏�������-1����)
            if (resultData.Count - 1 <= 12)
            {
                monthCount = 12 - (resultData.Count - 1);
                monthWork = resultData[1].AddUpYearMonth.Month - monthCount;
            }

            // �e�[�u���쐬
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Clear();
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].BeginLoadData();

            for (int ix = 0; ix < monthCount; ix++)
            {
                data = null;

                // �\�����Z�b�g
                int setMonth = monthWork + ix;
                if (setMonth < 1) setMonth = setMonth + 12;

                this.CreatDispDataSub(setMonth, data, out dr);

                // �`���[�g�e�[�u���ɒǉ�
                this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
            }

            for (int ix = 1; ix < resultData.Count; ix++)
            {
                data = resultData[ix];
                this.CreatDispDataSub(0, data, out dr);

                // �`���[�g�e�[�u���ɒǉ�
                this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
            }

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].EndLoadData();
        }

        /// <summary>
        /// �`���[�g�\���f�[�^�쐬�T�u����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�\���p�f�[�^�Z�b�g���쐬���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.02.18</br>
        /// </remarks>
        private void CreatDispDataSub(int month, StockHistoryDspSearchResult data, out DataRow dr)
        {
            dr = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].NewRow();

            if ((data == null) ||
                (data.AddUpYearMonth == DateTime.MinValue))
            {
                // �W�v��
                dr[COL_TITLE] = month.ToString() + "��";

                // �����
                dr[COL_SALESTIMES] = 0;
                // ���㐔
                dr[COL_SALESCOUNT] = 0;
                // ������z�i�Ŕ����j
                dr[COL_SALESMONEY] = 0;

                // �d����
                dr[COL_STOCKTIMES] = 0;
                // �d����
                dr[COL_STOCKCOUNT] = 0;
                // �d�����z�i�Ŕ����j
                dr[COL_STOCKMONEY] = 0;

                // �e�����z
                dr[COL_GRPROFIT] = 0;

                // �ړ����א�
                dr[COL_MOVEACOUNT] = 0;
                // �ړ����׊z
                dr[COL_MOVEAPRICE] = 0;

                // �ړ��o�א�
                dr[COL_MOVESCOUNT] = 0;
                // �ړ��o�׊z
                dr[COL_MOVESPRICE] = 0;
            }
            else
            {
                // �W�v��
                dr[COL_TITLE] = data.AddUpYearMonth.Month.ToString() + "��";

                // �����
                dr[COL_SALESTIMES] = data.SalesTimes;
                // ���㐔
                dr[COL_SALESCOUNT] = data.SalesCount;
                // ������z�i�Ŕ����j
                dr[COL_SALESMONEY] = data.SalesMoneyTaxExc;

                // �d����
                dr[COL_STOCKTIMES] = data.StockTimes;
                // �d����
                dr[COL_STOCKCOUNT] = data.StockCount;
                // �d�����z�i�Ŕ����j
                dr[COL_STOCKMONEY] = data.StockPriceTaxExc;

                // �e�����z
                dr[COL_GRPROFIT] = data.GrossProfit;

                // �ړ����א�
                dr[COL_MOVEACOUNT] = data.MoveArrivalCnt;
                // �ړ����׊z
                dr[COL_MOVEAPRICE] = data.MoveArrivalPrice;

                // �ړ��o�א�
                dr[COL_MOVESCOUNT] = data.MoveShipmentCnt;
                // �ړ��o�׊z
                dr[COL_MOVESPRICE] = data.MoveShipmentPrice;
            }
        }

        #region ���̓`���[�g�p�����[�^���X�g�擾����
        /// <summary>
        /// ���̓`���[�g�p�����[�^���X�g�擾����
        /// </summary>
        /// <param name="analysisChartControlList">���̓`���[�g���Ǘ��N���X���X�g</param>
        /// <returns>RESULT�itrue:OK,false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ���̓`���[�g���o�N���X���番�̓`���[�g�p�����[�^�̃��X�g���擾���܂��B
        ///                  �܂��A�h�����_�E���̗L�镪�̓`���[�g���Ǘ��N���X�̃��X�g�𐶐����܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        //private bool GetChartInfoList(List<IChartExtract> chartExtractObjList)
        private bool GetChartInfoList()
        {
            try
            {
                // �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g�N���A
                this._drillDownChartList.Clear();

                // �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g�N���A
                this._condtionClickChartList.Clear();

                // �`���[�g�p�����[�^���X�g�N���A
                this._chartInfoList.Clear();

                for (int i = 0; i < 3; i++)
                {
                    string errorMessage = "";
                    ChartInfo chartInfo;

                    // �`���[�g���
                    int result = this.GetChartInfo(this, null, null, 0, out chartInfo, out errorMessage);

                    switch (result)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // �`���[�g�ԍ����擾
                                int number = this._chartInfoList.Count + 1;

                                // �ڍו\�������l���Z�b�g
                                chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                // �|�C���g���x���\�������l���Z�b�g
                                chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                // ���x���p�x�����l���Z�b�g
                                chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                // �R�c�^�Q�c�\�������l���Z�b�g
                                chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                // �`���[�g�p�����[�^���X�g�Ɋi�[
                                this._chartInfoList.Add(number, chartInfo);

                                //// �h�����_�E���`���[�g�L��
                                //if (chartExtractObj.ChartParamater.IsDrillDown)
                                //{
                                //    // �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g�Ɋi�[
                                //    this._drillDownChartList.Add(number, chartExtractObj);
                                //}

                                //// �����i�����{�^���j�L��
                                //if (chartExtractObj.ChartParamater.IsCondtnButton)
                                //{
                                //    // �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g�Ɋi�[
                                //    this._condtionClickChartList.Add(number, chartExtractObj);
                                //
                                // �����{�^�����ݒ�
                                this.ConditionButtonVisibleFalse(number, true);
                                //}
                                //else
                                //{
                                //    // �����{�^�����ݒ�
                                //    this.ConditionButtonVisibleFalse(number, false);
                                //}
                                break;
                            }

                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return false;
                            }
                    }
                }

                if (this._chartInfoList.Count == 0)
                {
                    return false;
                }

                if (this._drillDownChartList.Count > 0)
                {
                    foreach (int number in this._drillDownChartList.Keys)
                    {
                        // �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�o�^
                        this.RegistChartSwitch(number);
                    }
                }

                //if (this._condtionClickChartList.Count > 0)
                //{
                // �����{�^���N���b�N�C�x���g�o�^
                this.RegistConditionClick();
                //}
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion

        #region ���̓`���[�g�\������
        /// <summary>
        /// ���̓`���[�g�\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�����N���X�ɂĕ��̓`���[�g�𐶐����\�����܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void ShowChartData()
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            // �p�l���Ɋ��ɃR���g���[�����L��ꍇ�̓N���A����
            if (this.AnalysisChartView_panel.Controls.Count > 0)
            {
                this.AnalysisChartView_panel.Controls.Remove(this.AnalysisChartView_panel.Controls[0]);
            }

            // �|�C���g���x���t�H���g�T�C�Y�����l���Z�b�g
            this._chartLibrary.PointLabelSizeInitialValue = this._analysisChartSettingAcs.PointLabelSizeInitialValue;

            // ���x���ő包�������l���Z�b�g
            this._chartLibrary.LabelMaxLengthInitialValue = this._analysisChartSettingAcs.LabelMaxLengthInitialValue;

            // ���x���t�H���g�T�C�Y�����l���Z�b�g
            this._chartLibrary.LabelSizeInitialValue = this._analysisChartSettingAcs.LabelSizeInitialValue;

            // �`���[�g����
            this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

            // �`���[�g�\��
            this._chartLibrary.TopLevel = false;
            this._chartLibrary.FormBorderStyle = FormBorderStyle.None;
            this._chartLibrary.Show();

            // �p�l���Ƀ`���[�g��\��
            this.AnalysisChartView_panel.Controls.Add(this._chartLibrary);
            this._chartLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        #endregion

        #region �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�o�^����
        /// <summary>
        /// �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�o�^����
        /// </summary>
        /// <param name="number">�`���[�g�ԍ�</param>
        private void RegistChartSwitch(int number)
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            switch (number)
            {
                case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
            }
        }
        #endregion

        #region �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�폜����
        /// <summary>
        /// �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�폜����
        /// </summary>
        /// <param name="number">�`���[�g�ԍ�</param>
        private void RemoveChartSwitch(int number)
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            switch (number)
            {
                case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
                case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
            }
        }
        #endregion

        #region �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�o�^����
        /// <summary>
        /// �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�o�^����
        /// </summary>
        /// <param name="number">�`���[�g�ԍ�</param>
        private void RegistBackChartSwitch(int number)
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            switch (number)
            {
                case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
            }
        }
        #endregion

        #region �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�폜����
        /// <summary>
        /// �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�폜����
        /// </summary>
        /// <param name="number">�`���[�g�ԍ�</param>
        private void RemoveBackChartSwitch(int number)
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            switch (number)
            {
                case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
                case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
            }
        }
        #endregion

        #region �`���[�g�ؑ֏����i�h�����_�E���p�j
        /// <summary>
        /// �`���[�g�ؑ֏����i�h�����_�E���p�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ChartSwitch(object sender, ChartSwitchingEventArgs e)
        {
            try
            {
                if (this._drillDownChartList.ContainsKey(e.Number))
                {
                    IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
                    if (iChartExtract != null)
                    {
                        string errorMessage;
                        ChartInfo chartInfo;

                        // �h�����_�E���`���[�g�p�����[�^�擾
                        int result = iChartExtract.GetDrillDownChartInfo(this, e.Element, out chartInfo, out errorMessage);
                        switch (result)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                {
                                    // �ڍו\�������l���Z�b�g
                                    chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                    // �|�C���g���x���\�������l���Z�b�g
                                    chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                    // ���x���p�x�����l���Z�b�g
                                    chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                    // �R�c�^�Q�c�\�������l���Z�b�g
                                    chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                    // �`���[�g�p�����[�^�̍폜
                                    if (this._chartInfoList.ContainsKey(e.Number))
                                    {
                                        this._chartInfoList.Remove(e.Number);
                                    }
                                    // �`���[�g�p�����[�^���X�g�Ɋi�[
                                    this._chartInfoList.Add(e.Number, chartInfo);

                                    // �`���[�g�Đ���
                                    this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

                                    // �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�폜
                                    this.RemoveChartSwitch(e.Number);
                                    // �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�o�^
                                    this.RegistBackChartSwitch(e.Number);

                                    break;
                                }
                            case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                {
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                    return;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "���̓`���[�g�i�h�����_�E���j�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
        }
        #endregion

        #region �`���[�g�ؑ֏����i�h�����_�E������̖߂�p�j
        /// <summary>
        /// �`���[�g�ؑ֏����i�h�����_�E������̖߂�p�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void BackChartSwitch(object sender, ChartSwitchingEventArgs e)
        {
            try
            {
                if (this._drillDownChartList.ContainsKey(e.Number))
                {
                    IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
                    if (iChartExtract != null)
                    {
                        string errorMessage;
                        ChartInfo chartInfo;

                        int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                        // �`���[�g�p�����[�^�擾
                        //result = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out errorMessage);
                        result = iChartExtract.GetChartInfo(this, null, out chartInfo, out errorMessage);

                        switch (result)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                {
                                    // �ڍו\�������l���Z�b�g
                                    chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                    // �|�C���g���x���\�������l���Z�b�g
                                    chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                    // ���x���p�x�����l���Z�b�g
                                    chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                    // �R�c�^�Q�c�\�������l���Z�b�g
                                    chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                    // �`���[�g�p�����[�^�̍폜
                                    if (this._chartInfoList.ContainsKey(e.Number))
                                    {
                                        this._chartInfoList.Remove(e.Number);
                                    }
                                    // �`���[�g�p�����[�^���X�g�Ɋi�[
                                    this._chartInfoList.Add(e.Number, chartInfo);

                                    // �`���[�g�Đ���
                                    this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

                                    // �`���[�g�ؑփC�x���g�i�h�����_�E������̖߂�p�j�폜
                                    this.RemoveBackChartSwitch(e.Number);
                                    // �`���[�g�ؑփC�x���g�i�h�����_�E���p�j�o�^
                                    this.RegistChartSwitch(e.Number);

                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                    return;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
        }
        #endregion

        #region �����{�^�����ݒ菈��
        /// <summary>
        /// �����{�^�����ݒ菈��
        /// </summary>
        /// <param name="number">�`���[�g�ԍ�</param>
        /// <param name="visible">��</param>
        private void ConditionButtonVisibleFalse(int number, bool visible)
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            switch (number)
            {
                case 1: { this._chartLibrary.Condition1ButtonVisible = visible; break; }
                case 2: { this._chartLibrary.Condition2ButtonVisible = visible; break; }
                case 3: { this._chartLibrary.Condition3ButtonVisible = visible; break; }
                case 4: { this._chartLibrary.Condition4ButtonVisible = visible; break; }
            }
        }
        #endregion

        #region �����{�^���N���b�N�C�x���g�o�^����
        /// <summary>
        /// �����{�^���N���b�N�C�x���g�o�^����
        /// </summary>
        private void RegistConditionClick()
        {
            if (this._chartLibrary == null)
            {
                this._chartLibrary = new ChartLibrary();
            }

            this._chartLibrary.ConditionClick += new ConditionClickEventHandler(this.ConditionClick);
        }
        #endregion

        #region �����{�^���N���b�N����
        /// <summary>
        /// �����{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ConditionClick(object sender, ConditionClickEventArgs e)
        {
            try
            {
                //if (this._condtionClickChartList.ContainsKey(e.Number))
                //{
                // �������͂t�h��ʕ\��
                DCHNB04180UD _singleTypeObj = new DCHNB04180UD();

                #region �p�����[�^�Z�b�g
                _singleTypeObj._titleList = new List<string>();
                switch (e.Number)
                {
                    case 1: // ���z
                        {
                            // 2010/04/30 Add >>>
                            // ���z�{��
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            // ���z�{����
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                    case 2: // ����
                        {
                            // 2010/04/30 Add >>>
                            // ���ʁ{���z
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            // ���ʁ{��
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                    case 3: // ��
                        {
                            // 2010/04/30 Add >>>
                            // �񐔁{����
                            if (_chartStyle[e.Number - 1] == 4)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption);
                            }
                            // �񐔁{���z
                            else if (_chartStyle[e.Number - 1] == 5)
                            {
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption);
                            }
                            else
                            {
                                // 2010/04/30 Add <<<
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption);
                                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption);
                            }   // 2010/04/30 Add
                            break;
                        }
                }

                int flg;
                _singleTypeObj._graphPara = new List<int>();
                _singleTypeObj._graphPara2 = new List<int>();   // 2010/04/30 Add
                ChartInfo _chartInfo = (ChartInfo)_chartInfoList[e.Number];

                // 2010/04/30 Del >>>
                //if (_chartInfo.Style == ChartStyle.Pie) flg = 2;
                //else if (_chartInfo.Style == ChartStyle.Line) flg = 1;
                //else flg = 0;
                // 2010/04/30 Del <<<
                flg = _chartStyle[e.Number - 1];    // 2010/04/30 Add
                _singleTypeObj._graphPara.Add(flg);
                _singleTypeObj._graphPara2.Add(e.Number);   // 2010/04/30 Add

                for (int ix = 1; ix < this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Count; ix++)
                {
                    flg = 1;
                    if (_chartInfo.SeriesVisible != null)
                    {
                        for (int ix2 = 0; ix2 < _chartInfo.SeriesVisible.Length; ix2++)
                        {
                            if (_chartInfo.SeriesVisible[ix2] == ix - 1)
                            {
                                flg = 0;
                                switch (e.Number)
                                {
                                    case 1: // ���z
                                        {
                                            // 2010/04/30 Add >>>
                                            // ���z�{��
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // ���z�{����
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 0:
                                                    case 1:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            else
                                            {
                                                // 2010/04/30 Add <<<
                                                switch (ix - 1)
                                                {
                                                    // 2010/04/30 >>>
                                                    //case 0:
                                                    //case 1:
                                                    //case 3:
                                                    //case 4:
                                                    //case 7:
                                                    //case 9:
                                                    case 0:
                                                    case 1:
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        // 2010/04/30 <<<
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }   // 2010/04/30 Add
                                            break;
                                        }
                                    case 2: // ����
                                        {
                                            // 2010/04/30 Add >>>
                                            // ���ʁ{���z
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 0:
                                                    case 1:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // ���ʁ{��
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            else
                                            {
                                                // 2010/04/30 Add <<<
                                                switch (ix - 1)
                                                {
                                                    // 2010/04/30 >>>
                                                    //case 0:
                                                    //case 2:
                                                    //case 3:
                                                    //case 5:
                                                    //case 6:
                                                    //case 8:
                                                    //case 10:
                                                    case 0:
                                                    case 1:
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        // 2010/04/30 <<<
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }   // 2010/04/30 Add
                                            break;
                                        }
                                    case 3: // ��
                                        {
                                            // 2010/04/30 Add >>>
                                            // �񐔁{����
                                            if (_chartStyle[e.Number - 1] == 4)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 6:
                                                    case 7:
                                                    case 8:
                                                    case 9:
                                                    case 10:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // �񐔁{���z
                                            else if (_chartStyle[e.Number - 1] == 5)
                                            {
                                                switch (ix - 1)
                                                {
                                                    case 2:
                                                    case 3:
                                                    case 4:
                                                    case 5:
                                                        {
                                                            flg = -1;
                                                            break;
                                                        }
                                                }
                                            }
                                            // 2010/04/30 Add <<<
                                            switch (ix - 1)
                                            {
                                                // 2010/04/30 >>>
                                                //case 1:
                                                //case 2:
                                                //case 4:
                                                //case 5:
                                                //case 6:
                                                //case 7:
                                                //case 8:
                                                //case 9:
                                                //case 10:
                                                case 2:
                                                case 3:
                                                case 4:
                                                case 5:
                                                case 6:
                                                case 7:
                                                case 8:
                                                case 9:
                                                case 10:
                                                    // 2010/04/30 <<<
                                                    {
                                                        flg = -1;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        }
                    }
                    _singleTypeObj._graphPara.Add(flg);
                }

                // 2010/04/30 Add >>>
                List<int> seriesList = new List<int>();
                seriesList = _seriesList[e.Number - 1];
                for (int i = 0; i < 11; i++)
                {
                    if (seriesList != null && seriesList.Count != 0)
                    {
                        _singleTypeObj._graphPara2.Add(seriesList[i]);
                    }
                    else
                    {
                        _singleTypeObj._graphPara2.Add(2);
                    }
                }
                // 2010/04/30 Add <<<
                #endregion

                Form customForm = (Form)_singleTypeObj;
                customForm.StartPosition = FormStartPosition.CenterScreen;
                _singleTypeObj._graphId = e.Number; // 2010/04/30 Add
                customForm.ShowDialog(this);
                int result = 0;
                if (_singleTypeObj._graphPara[0] < 0) result = _singleTypeObj._graphPara[0];
                if (result == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    string errorMessage;
                    ChartInfo chartInfo;

                    // �`���[�g�p�����[�^�擾
                    result = this.GetChartInfo(this, _singleTypeObj._graphPara, _singleTypeObj._graphPara2, e.Number, out chartInfo, out errorMessage);
                    switch (result)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                            {
                                // �ڍו\�������l���Z�b�g
                                chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
                                // �|�C���g���x���\�������l���Z�b�g
                                chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
                                // ���x���p�x�����l���Z�b�g
                                chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
                                // �R�c�^�Q�c�\�������l���Z�b�g
                                chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

                                // �`���[�g�p�����[�^�̍폜
                                if (this._chartInfoList.ContainsKey(e.Number))
                                {
                                    this._chartInfoList.Remove(e.Number);
                                }
                                // �`���[�g�p�����[�^���X�g�Ɋi�[
                                this._chartInfoList.Add(e.Number, chartInfo);

                                // �`���[�g�Đ���
                                this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

                                break;
                            }
                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return;
                            }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "�����ݒ�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
        }
        #endregion

        #endregion

        #region Internal Method

        #region ���̓`���[�g���Ǘ��N���X���X�g�N���A����
        ///// <summary>
        ///// ���̓`���[�g���Ǘ��N���X���X�g�N���A����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ���̓`���[�g���Ǘ��N���X���X�g���N���A���܂��B</br>
        /// <br>Programmer   : 980035 ����@��`</br>
        /// <br>Date         : 2007.10.31</br>
        ///// </remarks>
        //internal void ClearAnalysisChartControlList()
        //{
        //    if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
        //	{
        //		return;
        //	}
        //
        //	// ���̓`���[�g���Ǘ��N���X���X�g�N���A
        //    this._chartExtractList.Clear();
        //}
        #endregion

        #region ���̓`���[�g�r���[�t�H�[���\������
        /// <summary>
        /// ���̓`���[�g�r���[�t�H�[���\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���̓`���[�g�r���[�t�H�[����\�����܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        internal void ShowMe(List<StockHistoryDspSearchResult> resultData)
        {
            // ��ʕ\��
            this.Show();

            // ���̓`���[�g�f�[�^����
            if (this.CreateChartData(resultData))
            {
                // ���̓`���[�g�p�����[�^���X�g�擾
                if (this.GetChartInfoList())
                {
                    // ���̓`���[�g�\��
                    this.ShowChartData();
                }
            }
        }
        #endregion

        #endregion

        #region �`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// <summary>
        /// �`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�\���p�f�[�^�Z�b�g�̃X�L�[�}��ݒ肵�܂��B</br>
        /// </remarks>
        private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

            // �݌ɔN�Ԏ��яƉ�`���[�g
            this._chartDataSet.Tables.Add(TBL_ANNUALDATA_TITLE);
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TITLE, typeof(string));	// �W�v��
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].Caption = "�W�v��";

            // 2010/04/30 Del >>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESTIMES, typeof(int));	// �����
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption = "�����";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESCOUNT, typeof(int));	// ���㐔
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption = "���㐔";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(int));	// ������z // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(double));	// ������z // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption = "������z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKTIMES, typeof(int));	// �d����
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption = "�d����";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKCOUNT, typeof(int));	// �d����
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption = "�d����";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(int));	// �d�����z // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(double));	// �d�����z // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption = "�d�����z";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(int)); // �e�����z // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // �e�����z // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "�e�����z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEACOUNT, typeof(int)); // �ړ����א�
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption = "�ړ����א�";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(int)); // �ړ����׊z // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(double)); // �ړ����׊z // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption = "�ړ����׊z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESCOUNT, typeof(int)); // �ړ��o�א�
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption = "�ړ��o�א�";

            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(int)); // �ړ��o�׊z // DEL 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(double)); // �ړ��o�׊z // ADD 2010/03/15
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption = "�ړ��o�׊z";
            // 2010/04/30 Del <<<
            // 2010/04/30 Add >>>
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESTIMES, typeof(int));	// �����
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESTIMES].Caption = "�����";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKTIMES, typeof(int));	// �d����
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKTIMES].Caption = "�d����";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESCOUNT, typeof(int));	// ���㐔
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESCOUNT].Caption = "���㐔";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKCOUNT, typeof(int));	// �d����
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKCOUNT].Caption = "�d����";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEACOUNT, typeof(int)); // �ړ����א�
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEACOUNT].Caption = "�ړ����א�";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(int));	// ������z // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESCOUNT, typeof(int)); // �ړ��o�א�
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESCOUNT].Caption = "�ړ��o�א�";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALESMONEY, typeof(double));	// ������z // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALESMONEY].Caption = "������z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(int));	// �d�����z // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_STOCKMONEY, typeof(double));	// �d�����z // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_STOCKMONEY].Caption = "�d�����z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(int)); // �e�����z // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // �e�����z // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "�e�����z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(int)); // �ړ����׊z // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVEAPRICE, typeof(double)); // �ړ����׊z // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVEAPRICE].Caption = "�ړ����׊z";

            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(int)); // �ړ��o�׊z // DEL 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_MOVESPRICE, typeof(double)); // �ړ��o�׊z // ADD 2010/03/15
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_MOVESPRICE].Caption = "�ړ��o�׊z";
            // 2010/04/30 Add <<<

        }
        #endregion

    }
}
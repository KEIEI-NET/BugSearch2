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
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br></br>
    /// <br></br>
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
        internal AnalysisChartViewForm(DCHNB04180UA parentForm)
		{
			InitializeComponent();

			// �e�t�H�[���i���̓`���[�g���C���t���[���j
			this._parentForm				= parentForm;

			// �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
			this._drillDownChartList		= new SortedList();

			// �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
			this._condtionClickChartList	= new SortedList();

			// �`���[�g�p�����[�^���X�g������
			this._chartInfoList				= new SortedList();

			// ���̓`���[�g�\���ݒ�A�N�Z�X�N���X
			this._analysisChartSettingAcs	= new AnalysisChartSettingAcs();

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
        private DCHNB04180UA _parentForm = null;

		/// <summary>�h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
		private SortedList _drillDownChartList						= null;

		/// <summary>�����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
		private SortedList _condtionClickChartList					= null;

		/// <summary>�`���[�g�p�����[�^���X�g</summary>
		private SortedList _chartInfoList							= null;

		/// <summary>�`���[�g�����N���X</summary>
		private ChartLibrary _chartLibrary							= null;

        /// <summary>�`���[�g�\���p�f�[�^�Z�b�g</summary>
        private DataSet _chartDataSet;

        /// <summary>���̓`���[�g�\���ݒ�A�N�Z�X�N���X</summary>
		private AnalysisChartSettingAcs _analysisChartSettingAcs	= null;

        /// <summary>�N�x�擾�p</summary>
        private string _totalYear = "";

        /// <summary>�`���[�g���o�N���X�I�u�W�F�N�g���X�g</summary>
        //private List<IChartExtract> _chartExtractList = null;

        // 2010/04/30 Add >>>
        /// <summary>�`���[�g�X�^�C���L���b�V��</summary>
        private int[] _chartStyle = new int[2] { 0, 0 };

        /// <summary>�܂���{�_�O���t�p�L���b�V��</summary>
        private List<int>[] _seriesList = new List<int>[2] { null, null };
        // 2010/04/30 Add <<<
        #endregion

        #region const
        // DataTable�����`���[�g�p�e�[�u����
        private const string TBL_ANNUALDATA_TITLE  = "ANNUALDATA_TABLE";

        // DataTable�񖼁��`���[�g�p�e�[�u����
        private const string COL_TITLE      = "COL_TITLE";
        private const string COL_SALES      = "COL_PARA1";
        private const string COL_RETGOODS   = "COL_PARA2";
        private const string COL_DISCOUNT   = "COL_PARA3";
        private const string COL_GSALES     = "COL_PARA4";
        private const string COL_TARGET     = "COL_PARA5";
        private const string COL_GRPROFIT   = "COL_PARA6";
        private const string COL_GRTARGET   = "COL_PARA7";
        private const string COL_BEFSALES   = "COL_PARA8";
        private const string COL_BEFGRPRO   = "COL_PARA9";
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
        private bool CreateChartData(InventoryUpdateDataSet resultData)
        {
			try
			{
				string errorMessage = "";
				int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                try
                {
                    if (resultData.MonthResult.Count == 0)
                    {
                        errorMessage = "����N�Ԏ��я�񂪑��݂��܂���B";
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
                    errorMessage = "����N�Ԏ��я��̎擾�Ɏ��s���܂����B";
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, errorMessage, result, MessageBoxButtons.OK);
							return false;
						}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "���̓`���[�g�f�[�^�̐����Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
        //public int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string errorMessage)
        public int GetChartInfo(object sender, object parameter, object parameter2, out ChartInfo chartInfo, out string errorMessage)
        // 2010/04/30 <<<
        {
            chartInfo = new ChartInfo();
            int[] seriesVisible;

            // ����N�Ԏ��у`���[�g
            chartInfo.Title = "����N�Ԏ���";                       // �^�C�g��
            //chartInfo.SubTitle = "�i" + _totalYear + "�N�x�j";      // �T�u�^�C�g��
            chartInfo.YLabel = "���z�i�~�j";                        // Y�����x��
            chartInfo.Palette = PaletteStyle.DefaultWindows;        // �p���b�g(�F�̑g�ݍ��킹)
            //chartInfo.LegendBox = true;								// X���̖}��̕\����\��
            chartInfo.Legend = true;								// �}��̕\����\��
            chartInfo.DockPosition = EditorDockPosition.Top;		// �f�[�^�G�f�B�^�[�|�W�V����
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);   // �p�l���̐F
            chartInfo.Ydecimal = 0;									// Y�������_�ȉ���
            chartInfo.Ydecimal2 = 0;								// Y���Q�����_�ȉ���
            chartInfo.View3DDepth = 100;							// 3D�O���t�̉��s��

            chartInfo.AngleX = 20;									// X���̉�]
            //chartInfo.AngleY = 10;								// Y���̉�]
            // --- ADD 2010/02/18 -------------------------------->>>>>
            chartInfo.AngleY = 40;                                  // Y���̉�]
            // --- ADD 2010/02/18 --------------------------------<<<<<

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
                errorMessage = "����N�Ԏ��я�񂪑��݂��܂���B";
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
                        parameter2 = null;
                    }
                    else if (dummyPara[0] == null || dummyPara[1] == null)
                    {
                        parameter = null;
                        parameter2 = null;
                    }
                    else if (dummyPara[0].Count != 10 || dummyPara[1].Count != 10)
                    {
                        parameter = null;
                        parameter2 = null;
                    }
                    else
                    {
                        parameter = dummyPara[0];
                        parameter2 = dummyPara[1];
                    }
                }
            }
            // 2010/04/30 Add <<<

            if (parameter == null)
            {
                if (this._chartInfoList.Count == 0)
                {
                    // ���ы��z
                    //chartInfo.SubTitle = " ������z�i" + _totalYear + "�N�x�j"; // �T�u�^�C�g��
                    seriesVisible = new int[4];
                    // 2010/04/30 Del >>>
                    //seriesVisible[0] = 5;
                    //seriesVisible[1] = 6;
                    //seriesVisible[2] = 7;
                    //seriesVisible[3] = 8;
                    // 2010/04/30 Del <<<
                    // 2010/04/30 Add >>>
                    seriesVisible[0] = 3;
                    seriesVisible[1] = 4;
                    seriesVisible[2] = 6;
                    seriesVisible[3] = 2;
                    // 2010/04/30 Add <<<
                    chartInfo.SeriesVisible = seriesVisible;
                }
                else
                {
                    // �e�����z
                    //chartInfo.SubTitle = " �e�����z�i" + _totalYear + "�N�x�j"; // �T�u�^�C�g��
                    // 2010/04/30 Del >>>
                    //seriesVisible = new int[7];
                    //seriesVisible[0] = 0;
                    //seriesVisible[1] = 1;
                    //seriesVisible[2] = 2;
                    //seriesVisible[3] = 3;
                    //seriesVisible[4] = 4;
                    //seriesVisible[5] = 7;
                    //seriesVisible[6] = 8;
                    // 2010/04/30 Del <<<
                    // 2010/04/30 Add >>>
                    seriesVisible = new int[5];
                    seriesVisible[0] = 7;
                    seriesVisible[1] = 0;
                    seriesVisible[2] = 1;
                    seriesVisible[3] = 8;
                    seriesVisible[4] = 4;
                    // 2010/04/30 Add <<<
                    chartInfo.SeriesVisible = seriesVisible;
                }
            }
            else
            {
                //chartInfo.SubTitle = "�i" + _totalYear + "�N�x�j"; // �T�u�^�C�g��

                List<int> para = (List<int>)parameter;
                List<int> para2 = (List<int>)parameter2;    // 2010/04/30 Add
                // �_�O���t
                if (para[0] == 0)
                {
                    chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 10; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // �܂���O���t
                else if (para[0] == 1)
                {
                    chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 10; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // �~�O���t
                else if (para[0] == 2)
                {
                    chartInfo.Style = ChartStyle.Pie;						// �`���[�g�̃X�^�C��
                    chartInfo.Legend = false;								// �}��̕\����\��
                    // 2010/04/30 Add >>>
                    for (int i = 1; i < 10; i++)
                    {
                        chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Pie, YAxisSelect.Left, false, 80));
                    }
                    // 2010/04/30 Add <<<
                }
                // 2010/04/30 Add >>>
                // ���[�_�[
                else if (para[0] == 3)
                {
                    chartInfo.Style = ChartStyle.Radar;						// �`���[�g�̃X�^�C��
                    chartInfo.View3DDepth = 0;							// 3D�O���t�̉��s��
                    chartInfo.AngleX = 0;									// X���̉�]
                    chartInfo.AngleY = 0;                                  // Y���̉�]
                }
                // �܂���{�_�O���t
                else if (para[0] == 4)
                {
                    List<int> seriesList = new List<int>();
                    for (int i = 1; i < 10; i++)
                    {
                        seriesList.Add(para2[i]);
                        switch (para2[i])
                        {
                            case 0:
                                chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 100));
                                break;
                            case 1:
                                chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Bar, YAxisSelect.Left, false, 50));
                                break;
                            case 2:
                                chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 100));
                                break;
                            case 3:
                                chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 50));
                                break;
                            default:
                                chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
                                chartInfo.Series.Add(new ChartSeriesInfo(ChartStyle.Line, YAxisSelect.Left, false, 100));
                                break;
                        }
                    }
                    _seriesList[para2[0] - 1] = seriesList;
                    chartInfo.Cluster = true;
                }
                _chartStyle[para2[0] - 1] = para[0];
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
            }

            errorMessage = "";
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �`���[�g�\���f�[�^�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`���[�g�\���p�f�[�^�Z�b�g���쐬���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        private void CreatDispData(InventoryUpdateDataSet resultData)
        {
            InventoryUpdateDataSet.MonthResultRow data;
            DataRow dr;

            // �N�x�擾
            if (resultData.MonthResult[0].RowSetFlg != 0)
            {
                int totalYear = resultData.MonthResult[0].RowSetFlg / 100;
                _totalYear = totalYear.ToString();
            }

            // �e�[�u���쐬
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Clear();
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].BeginLoadData();

            for (int ix = 0; ix < resultData.MonthResult.Count; ix++)
            {
                data = resultData.MonthResult[ix];

                // ��������z
                dr = this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].NewRow();
                // �W�v��
                dr[COL_TITLE] = data.RowTitle;
                if (data.RowSetFlg != 0)
                {
                    // ������z
                    dr[COL_SALES] = data.SalesMoney;
                    // �ԕi���z
                    dr[COL_RETGOODS] = data.ReturnedGoodsPrice;
                    // �l�����z
                    dr[COL_DISCOUNT] = data.DiscountPrice;
                    // ��������z
                    dr[COL_GSALES] = data.GenuineSalesMoney;
                    // �ڕW���z
                    dr[COL_TARGET] = data.TargetMoney;

                    // �e�����z
                    dr[COL_GRPROFIT] = data.GrossProfitMoney;
                    // �e���ڕW���z
                    dr[COL_GRTARGET] = data.GrossProfitTargetMoney;

                    // �O��������
                    dr[COL_BEFSALES] = data.BeforeGenuineSalesMoney;
                    // �O���e��
                    dr[COL_BEFGRPRO] = data.BeforeGrossProfitMoney;

                    // �`���[�g�e�[�u���ɒǉ�
                    this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
                }
                else if (data.RowMonth != 0)
                {
                    // ���z
                    dr[COL_SALES] = 0;
                    // �ԕi���z
                    dr[COL_RETGOODS] = 0;
                    // �l�����z
                    dr[COL_DISCOUNT] = 0;
                    // ��������z
                    dr[COL_GSALES] = 0;
                    // �ڕW���z
                    dr[COL_TARGET] = 0;

                    // �e�����z
                    dr[COL_GRPROFIT] = 0;
                    // �e���ڕW���z
                    dr[COL_GRTARGET] = 0;

                    // --- DEL 2010/03/15 -------------------------------->>>>>
                    //// �O��������
                    //dr[COL_BEFSALES] = 0;
                    //// �O���e��
                    //dr[COL_BEFGRPRO] = 0;
                    // --- DEL 2010/03/15 --------------------------------<<<<<
                    // --- ADD 2010/03/15 -------------------------------->>>>>
                    // �O��������
                    dr[COL_BEFSALES] = data.BeforeGenuineSalesMoney;
                    // �O���e��
                    dr[COL_BEFGRPRO] = data.BeforeGrossProfitMoney;
                    // --- ADD 2010/03/15 --------------------------------<<<<<

                    // �`���[�g�e�[�u���ɒǉ�
                    this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Rows.Add(dr);
                }
            }

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].EndLoadData();
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

                for (int i = 0; i < 2; i++)
                {
                    string errorMessage = "";
                    ChartInfo chartInfo;

                    // �`���[�g���
                    // 2010/04/30 >>>
                    //int result = this.GetChartInfo(this, null, out chartInfo, out errorMessage);
                    int result = this.GetChartInfo(this, null, null, out chartInfo, out errorMessage);
                    // 2010/04/30 <<<

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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, errorMessage, result, MessageBoxButtons.OK);
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
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
				this._chartLibrary				= new ChartLibrary();
			}

			// �p�l���Ɋ��ɃR���g���[�����L��ꍇ�̓N���A����
			if (this.AnalysisChartView_panel.Controls.Count > 0)
			{
				this.AnalysisChartView_panel.Controls.Remove(this.AnalysisChartView_panel.Controls[0]);
			}

			// �|�C���g���x���t�H���g�T�C�Y�����l���Z�b�g
			this._chartLibrary.PointLabelSizeInitialValue	= this._analysisChartSettingAcs.PointLabelSizeInitialValue;

			// ���x���ő包�������l���Z�b�g
			this._chartLibrary.LabelMaxLengthInitialValue	= this._analysisChartSettingAcs.LabelMaxLengthInitialValue;

			// ���x���t�H���g�T�C�Y�����l���Z�b�g
			this._chartLibrary.LabelSizeInitialValue		= this._analysisChartSettingAcs.LabelSizeInitialValue;

			// �`���[�g����
			this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

			// �`���[�g�\��
			this._chartLibrary.TopLevel			= false;
			this._chartLibrary.FormBorderStyle	= FormBorderStyle.None;
			this._chartLibrary.Show();

			// �p�l���Ƀ`���[�g��\��
			this.AnalysisChartView_panel.Controls.Add(this._chartLibrary);
			this._chartLibrary.Dock				= System.Windows.Forms.DockStyle.Fill;
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
									chartInfo.Grid				= this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// �|�C���g���x���\�������l���Z�b�g
									chartInfo.PointLabel		= this._analysisChartSettingAcs.PointLabelInitialValue;
									// ���x���p�x�����l���Z�b�g
									chartInfo.XLabelVertical	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// �R�c�^�Q�c�\�������l���Z�b�g
									chartInfo.Chart3D			= this._analysisChartSettingAcs.View3D2DInitialValue;

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
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, errorMessage, result, MessageBoxButtons.OK);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "���̓`���[�g�i�h�����_�E���j�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
                        // 2010/04/30 >>>
                        //result = iChartExtract.GetChartInfo(this, null, out chartInfo, out errorMessage);
                        result = iChartExtract.GetChartInfo(this, null, out chartInfo, out errorMessage);
                        // 2010/04/30 <<<

						switch (result)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									// �ڍו\�������l���Z�b�g
									chartInfo.Grid				= this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// �|�C���g���x���\�������l���Z�b�g
									chartInfo.PointLabel		= this._analysisChartSettingAcs.PointLabelInitialValue;
									// ���x���p�x�����l���Z�b�g
									chartInfo.XLabelVertical	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// �R�c�^�Q�c�\�������l���Z�b�g
									chartInfo.Chart3D			= this._analysisChartSettingAcs.View3D2DInitialValue;

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
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, errorMessage, result, MessageBoxButtons.OK);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRTARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFGRPRO].Caption);

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
                _singleTypeObj._graphPara2.Add(e.Number);    // 2010/04/30 Add �_�~�[

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
                                break;
                            }
                        }
                    }
                    _singleTypeObj._graphPara.Add(flg);
                }
                // 2010/04/30 Add >>>
                List<int> seriesList = new List<int>();
                seriesList = _seriesList[e.Number - 1];
                for (int i = 0; i < 9; i++)
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
                    // 2010/04/30 >>>
                    //result = this.GetChartInfo(this, _singleTypeObj._graphPara, out chartInfo, out errorMessage);
                    result = this.GetChartInfo(this, _singleTypeObj._graphPara, _singleTypeObj._graphPara2, out chartInfo, out errorMessage);
                    // 2010/04/30 <<<
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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, errorMessage, result, MessageBoxButtons.OK);
                                return;
                            }
                    }
                //}
                }
			}
			catch (Exception ex)
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "�����ݒ�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
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
		internal void ShowMe(InventoryUpdateDataSet resultData)
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

            // ����N�Ԏ��яƉ�`���[�g
            this._chartDataSet.Tables.Add(TBL_ANNUALDATA_TITLE);
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TITLE, typeof(string));	// �W�v��
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TITLE].Caption = "�W�v��";

            // 2010/04/30 Del >>>
            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALES, typeof(int));	// ������z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALES, typeof(double));	// ������z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALES].Caption = "����";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_RETGOODS, typeof(int));	// �ԕi���z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_RETGOODS, typeof(double));	// �ԕi���z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_RETGOODS].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_RETGOODS].Caption = "�ԕi";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_DISCOUNT, typeof(int));	// �l�����z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_DISCOUNT, typeof(double));	// �l�����z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_DISCOUNT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_DISCOUNT].Caption = "�l��";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GSALES, typeof(int));	// ��������z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GSALES, typeof(double));	// ��������z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GSALES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GSALES].Caption = "������";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TARGET, typeof(int));	// �ڕW���z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TARGET, typeof(double));	// �ڕW���z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TARGET].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TARGET].Caption = "�ڕW";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(int)); // �e�����z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // �e�����z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "�e�����z";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRTARGET, typeof(int)); // �e���ڕW���z
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRTARGET, typeof(double)); // �e���ڕW���z
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRTARGET].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRTARGET].Caption = "�e���ڕW";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFSALES, typeof(int)); // �O��������
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFSALES, typeof(double)); // �O��������
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFSALES].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFSALES].Caption = "�O��������";

            //// --- DEL 2010/03/15 -------------------------------->>>>>
            ////this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFGRPRO, typeof(int)); // �O���e��
            //// --- DEL 2010/03/15 --------------------------------<<<<<
            //// --- ADD 2010/03/15 -------------------------------->>>>>
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFGRPRO, typeof(double)); // �O���e��
            //// --- ADD 2010/03/15 --------------------------------<<<<<
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFGRPRO].DefaultValue = 0;
            //this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFGRPRO].Caption = "�O���e��";
            // 2010/04/30 Del <<<

            // 2010/04/30 Add >>>
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_DISCOUNT, typeof(double));	// �l�����z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_DISCOUNT].Caption = "�l��";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_RETGOODS, typeof(double));	// �ԕi���z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_RETGOODS].Caption = "�ԕi";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRPROFIT, typeof(double)); // �e�����z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRPROFIT].Caption = "�e�����z";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFGRPRO, typeof(double)); // �O���e��
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFGRPRO].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFGRPRO].Caption = "�O���e��";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GRTARGET, typeof(double)); // �e���ڕW���z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GRTARGET].Caption = "�e���ڕW";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_GSALES, typeof(double));	// ��������z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GSALES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_GSALES].Caption = "������";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_BEFSALES, typeof(double)); // �O��������
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFSALES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_BEFSALES].Caption = "�O��������";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_SALES, typeof(double));	// ������z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALES].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_SALES].Caption = "����";

            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns.Add(COL_TARGET, typeof(double));	// �ڕW���z
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TARGET].DefaultValue = 0;
            this._chartDataSet.Tables[TBL_ANNUALDATA_TITLE].Columns[COL_TARGET].Caption = "�ڕW";
            // 2010/04/30 Add <<<
        }
        #endregion

    }
}
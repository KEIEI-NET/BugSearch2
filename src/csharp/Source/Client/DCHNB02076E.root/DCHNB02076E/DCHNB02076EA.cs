using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;


using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���㌎��N��`���[�g�f�[�^�쐬�N���X
    /// </summary>
    /// <br>Update Note: 2008.09.08 30452 ��� �r��</br>
    /// <br>			 �EPM.NS�Ή�</br>
    public class AgentOrderChart : IChartExtract
    {

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public AgentOrderChart(int index)
        {
            this._ChartScIndex = index;

            this._chartParamater = new ChartParamater();

            this._chartParamater.IsCondtnButton = true;     // �i�������{�^��(�\�����Ȃ�)
            this._chartParamater.IsDrillDown = false;       // �`���[�g�̃h�����_�E���@�\(�Ȃ�)                 

            this._salesTableAcs = new SalesTableAcs();

            // �`���[�g�\���p�f�[�^�Z�b�g�C���X�^���X��
            this._chartDataSet = new DataSet();

            // �`���[�g�\���p�f�[�^�Z�b�g�X�L�[�}�ݒ�
            SetTableSchema();
        }
        #endregion

        #region const

        //public const string CT_SecSalesOrderTrancDataTable = "SecSalesOrderTrancDataTable";
        #endregion

        #region Private Members

        private string _PGID = "DCHNB02076E";

        private int _ChartScIndex = 0;
        private bool _ExtraProcFlg = false;

        private SalesTableAcs _salesTableAcs = null;    // ���㌎��N��A�N�Z�X�N���X

        /// <summary>�`���[�g���p�����[�^</summary>
        private ChartParamater _chartParamater;
        private int _paraStyle = 0;

        /// <summary>�`���[�g�\���p�����[�^���X�g</summary>
        private List<int> _chartInfoList;

        /// <summary>�x�[�X�f�[�^�ێ��p�f�[�^�Z�b�g</summary>
        private DataSet _baseDataSet;
        /// <summary>�`���[�g�\���p�f�[�^�Z�b�g</summary>
        private DataSet _chartDataSet;

        // ���o�����N���X
        private SalesMonthYearReportCndtn _extraparam;

        /// <summary>���㌎��N��f�[�^�e�[�u����(�x�[�X�p)</summary>
        private string _MonthYearReportTable;
        /// <summary>���㌎��N��f�[�^�e�[�u����(�`���[�g�p)</summary>
        private string _MonthYearReportDataTable = "MonthYearReportDtl";

        // DataTable�񖼁��`���[�g�p�e�[�u����
        private const string COL_TITLE      = "COL_TITLE";
        private const string COL_SALES      = "COL_PARA01";
        private const string COL_RETGOODS   = "COL_PARA02";
        private const string COL_DISCOUNT   = "COL_PARA03";
        private const string COL_GSALES     = "COL_PARA04";
        private const string COL_TARGET     = "COL_PARA05";
        private const string COL_GRPROFIT   = "COL_PARA06";
        private const string COL_GRTARGET   = "COL_PARA07";
        private const string COL_ANSALES    = "COL_PARA08";
        private const string COL_ANRETGOODS = "COL_PARA09";
        private const string COL_ANDISCOUNT = "COL_PARA10";
        private const string COL_ANGSALES   = "COL_PARA11";
        private const string COL_ANTARGET   = "COL_PARA12";
        private const string COL_ANGRPROFIT = "COL_PARA13";
        private const string COL_ANGRTARGET = "COL_PARA14";

        #endregion

        #region IChartExtract �����o

        /// <summary>
        /// 
        /// </summary>
        public ChartParamater ChartParamater
        {
            get { return this._chartParamater; }
            set { this._chartParamater = value; }
        }

        #region ���`���[�g�f�[�^�쐬����
        /// <summary>
        /// �`���[�g�f�[�^�쐬����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int MakeChartData(object sender, object parameter, out string msg)
        {
            msg = "";

            try
            {
                this._extraparam = (SalesMonthYearReportCndtn)parameter;

                int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
                int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                string message = "";

                try
                {                    
                    status = this._salesTableAcs.SearchStatic(out message);
                    if (status == 0)
                    {
                        this._MonthYearReportTable = Broadleaf.Application.UIData.DCHNB02074EA.ct_Tbl_SalesMonthYearReportDtl;
                        
                        // �A�N�Z�X�N���X����擾�����e�[�u�����A�`���[�g�p�x�[�X�e�[�u���Ƃ��ĕێ�
                        this._baseDataSet = this._salesTableAcs._printDataSet.Copy();
                        //this._baseDataSet.Tables[this._MonthYearReportTable].DefaultView.Sort = CT_RankingNo_Odr;

                        this.CreateTable();

                        // �`���[�g�\���p�����[�^���X�g������
                        #region < �p�����[�^������ >
                        this._chartInfoList = new List<int>();
                        for (int ix = 1; ix < this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Count; ix++)
                        {
                            if (this._ChartScIndex == 0)
                            {
                                if (ix <= 7)
                                {
                                    this._chartInfoList.Add(1);
                                }
                                else
                                {
                                    this._chartInfoList.Add(0);
                                }
                            }
                            else
                            {
                                if (ix > 7)
                                {
                                    this._chartInfoList.Add(1);
                                }
                                else
                                {
                                    this._chartInfoList.Add(0);
                                }
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                                MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }
                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                            MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                break;
                            }
                    }
                }
                msg = message;
                return result;
            }
            catch (Exception)
            {
                msg = "���㌎��N����̎擾�Ɏ��s���܂����B";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        #region ���`���[�g�p�����[�^�擾����
        /// <summary>
        /// �`���[�g�p�����[�^�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="chartInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            try
            {
                // �`���[�g���i���̍쐬
                this.CreateChartInfo(ref chartInfo, this._extraparam);

                // �`���[�g�p�f�[�^�e�[�u���̍쐬
                this.ExtraProcMain(ref this._chartDataSet, this._baseDataSet, this._extraparam);

                if (this._chartDataSet.Tables[this._MonthYearReportDataTable].Rows.Count == 0)
                {
                    msg = "�f�[�^�����݂��܂���ł����B";
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // �f�[�^�\�[�X�̐ݒ�
                chartInfo.DataSource = this._chartDataSet.Tables[this._MonthYearReportDataTable];

            }
            catch (Exception ex)
            {
                msg = "�`���[�g���i���쐬�Ɏ��s���܂����B" + ex;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ���h�����_�E���`���[�g�p�����[�^�擾����
        /// <summary>
        /// �h�����_�E���`���[�g�p�����[�^�擾����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            // TODO �`���[�g�\���p�p�����[�^�̎擾
            // ����Ύ擾

            try
            {
                // �`���[�g���i���̍쐬
                //this.CreateChartInfo(1, ref chartInfo);

                //DataRow parentRow = this._chartDataSet.Tables[CT_TableName_GoodsKind].Rows[(int)parameter];

                //// �h�����_�E�������̎擾
                //string goodsKindName = (string)parentRow[CT_COL_GoodsKindName];
                //chartInfo.SubTitle = "�i" + goodsKindName + "�j";

                //// �`���[�g�p�f�[�^�e�[�u���̍쐬
                //this.ExtraProcMaker(parentRow, ref this._chartDataSet);
                //if (this._chartDataSet.Tables[CT_TableName_GoodsMaker].Rows.Count == 0)
                //{
                //    msg = "�f�[�^�����݂��܂���ł����B";
                //    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //}

                //// -- �f�[�^�\�[�X�̐ݒ� -// 
                //chartInfo.DataSource = this._chartDataSet.Tables[CT_TableName_GoodsMaker];

            }
            catch (Exception ex)
            {
                msg = "�`���[�g���i���̍쐬�ŗ�O���������܂���" + "\n\r" + "[" + ex.Message + "]";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ���`���[�g������ʕ\������
        /// <summary>
        /// �`���[�g�i��������ʕ\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        public int ShowCondition(object sender, object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �������͂t�h��ʕ\��
            DCHNB04180UD _singleTypeObj = new DCHNB04180UD();

            #region �p�����[�^�Z�b�g
            _singleTypeObj._titleList = new List<string>();
            if (this._ChartScIndex == 0)
            {
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_SALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_RETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_TARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_GRTARGET].Caption);
            }
            else
            {
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGSALES].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANTARGET].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption);
                _singleTypeObj._titleList.Add(this._chartDataSet.Tables[_MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption);
            }

            _singleTypeObj._graphPara = new List<int>();
            _singleTypeObj._graphPara.Add(this._paraStyle);

            _singleTypeObj._graphShow = new List<int>();
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if ((this._ChartScIndex == 0) && (ix <  7)) _singleTypeObj._graphShow.Add(this._chartInfoList[ix]);
                if ((this._ChartScIndex == 1) && (ix >= 7)) _singleTypeObj._graphShow.Add(this._chartInfoList[ix]);
            }
            #endregion

            Form customForm = (Form)_singleTypeObj;
            customForm.StartPosition = FormStartPosition.CenterScreen;
            customForm.ShowDialog();

            #region �p�����[�^�Q�b�g
            if (_singleTypeObj._graphPara[0] > -1)
            {
                int cnt = 0;
                this._paraStyle = _singleTypeObj._graphPara[0];
                for (int ix = 0; ix < this._chartInfoList.Count; ix++)
                {
                    if (((this._ChartScIndex == 0) && (ix < 7)) ||
                        ((this._ChartScIndex == 1) && (ix >= 7)))
                    {
                        this._chartInfoList[ix] = _singleTypeObj._graphShow[cnt];
                        cnt++;
                    }
                }
            }
            #endregion

            return status;
        }
        #endregion

        #endregion


        #region private Method

        #region ���`���[�g���i���쐬����
        /// <summary>
        /// �`���[�g���i���쐬����
        /// </summary>
        /// <param name="mode">[0:�S���ҕ�,1:���_��,2:�@���]</param>
        /// <param name="chartInfo">�`���[�g�p�����[�^</param>
        private void CreateChartInfo(ref ChartInfo chartInfo, SalesMonthYearReportCndtn extraparam)
        {

            chartInfo.Palette = PaletteStyle.DefaultWindows;		   	// �p���b�g(�F�̑g�ݍ��킹)
            chartInfo.DockPosition = EditorDockPosition.Top;			// �f�[�^�G�f�B�^�[�|�W�V����
            chartInfo.PanelColor = Color.FromArgb(198, 219, 255);		// �p�l���̐F
            chartInfo.Ydecimal = 0;										// Y�������_�ȉ���
            chartInfo.Ydecimal2 = 0;									// Y���Q�����_�ȉ���
            chartInfo.Stacked = StackStyle.No;                          // �f�[�^�̐ϑw(���E���ɕ��ׂ�)
            //chartInfo.Cluster = false;                                // Z���Ɍ����Čn������ׂ邩�ǂ���    // DEL 2008.08.14
            chartInfo.Cluster = true;                                   // Z���Ɍ����Čn������ׂ邩�ǂ���    // ADD 2008.08.14
            chartInfo.Legend = true;                                    // �}��(�\������)
            chartInfo.LegendBox = false;								// X���̖}��̕\����\��
            chartInfo.Grid = true;                                      // �f�[�^�O���b�h(�\������)
            //chartInfo.View3DDepth = 50; 								// 3D�O���t�̉��s��     // DEL 2008.08.14
            chartInfo.View3DDepth = 100; 								// 3D�O���t�̉��s��     // ADD 2008.08.14

            //chartInfo.PointLabel = false;                             // �`���[�g�̏�ɒl�\��(���Ȃ�)
            //chartInfo.Chart3D = true;                                 // �`���[�g3D or 2D (3D)

            //--- DEL 2008.08.14 ---------->>>>>
            //chartInfo.AngleX = 20;									// X���̉�]
            //chartInfo.AngleY = 0;										// Y���̉�]
            //--- DEL 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            chartInfo.AngleX = 30;										// X���̉�]
            chartInfo.AngleY = 30;										// Y���̉�]
            //--- ADD 2008.08.14 ----------<<<<<

            //chartInfo.DataSource = this._chartDataSet.Tables[this._MonthYearReportDataTable];

            #region < �n����\���ݒ� >
            int[] seriesVisible;
            int cnt   = 0;
            int index = 0;
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if (this._chartInfoList[ix] == 0) cnt++;
            }
            seriesVisible = new int[cnt];
            for (int ix = 0; ix < this._chartInfoList.Count; ix++)
            {
                if (this._chartInfoList[ix] == 0)
                {
                    seriesVisible[index] = ix;
                    index++;
                }
            }
            chartInfo.SeriesVisible = seriesVisible;                    // �n�̔�\���ݒ�
            #endregion

            #region < �`���[�g�X�^�C���ݒ� >
            if (this._paraStyle == 0)
            {
                chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
                //chartInfo.View3DDepth = 0; 							// 3D�O���t�̉��s��     // DEL 2008.08.14
                chartInfo.View3DDepth = 100; 							// 3D�O���t�̉��s��     // ADD 2008.08.14
                //chartInfo.AngleX = 0;									// X���̉�]            // DEL 2008.08.14
                chartInfo.AngleX = 10;									// X���̉�]            // ADD 2008.08.14
                //chartInfo.Cluster = true;                             // Z���Ɍ����Čn������ׂ邩�ǂ���
            }
            //else if (this._paraStyle == 1)
            //{
            //    chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
            //    chartInfo.AngleY = 30;									// Y���̉�]
            //}
            //else if (this._paraStyle == 2)
            else if (this._paraStyle == 1)
            {
                chartInfo.Style = ChartStyle.Pie;						// �`���[�g�̃X�^�C��
                chartInfo.Legend = false;								// �}��̕\����\��
            }
            #endregion

            #region < �^�C�g���ݒ� >
            chartInfo.Title = "���㌎��N��";                           // �^�C�g��

            string subtitle = "";
            subtitle = extraparam.TotalTypeName;
            string extraTitle = "";
            if (this._ChartScIndex == 0)
            {
                extraTitle = "�i���ԁj";
            }
            else
            {
                extraTitle = "�i�����j";
            }
            chartInfo.SubTitle = subtitle + "  " + extraTitle;          // �T�u�^�C�g��

            switch (extraparam.TotalType)
            {
                //--- DEL 2008.08.14 ---------->>>>>
                //case 0: // ���_��
                //    {
                //        chartInfo.XLabel = "���_";
                //        break;
                //    }
                //case 1: // ���Ӑ��
                //    {
                //        chartInfo.XLabel = "���Ӑ�";
                //        break;
                //    }
                //case 2: // �n��ʓ��Ӑ��
                //    {
                //        chartInfo.XLabel = "�n��E���Ӑ�";
                //        break;
                //    }
                //case 3: // �Ǝ�ʓ��Ӑ��
                //    {
                //        chartInfo.XLabel = "�Ǝ�E���Ӑ�";
                //        break;
                //    }
                //case 4: // �n���
                //    {
                //        chartInfo.XLabel = "�n��";
                //        break;
                //    }
                //case 5: // �Ǝ��
                //    {
                //        chartInfo.XLabel = "�Ǝ�";
                //        break;
                //    }
                //case 6: // �S���ҕ�
                //    {
                //        chartInfo.XLabel = "�S����";
                //        break;
                //    }
                //case 7: // ������
                //    {
                //        chartInfo.XLabel = "����";
                //        break;
                //    }
                //case 8: // ���[�J�[��
                //    {
                //        chartInfo.XLabel = "���[�J�[";
                //        break;
                //    }
                //case 9: // ���Ӑ�ʃ��[�J�[��
                //    {
                //        chartInfo.XLabel = "���Ӑ�^���[�J�[";
                //        break;
                //    }
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // ���Ӑ��
                    {
                        chartInfo.XLabel = "���Ӑ�";
                        break;
                    }
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/09/08 -------------------------------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // �S����
                    {
                        chartInfo.XLabel = "�S����";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // �󒍎�
                    {
                        chartInfo.XLabel = "�󒍎�";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // ���s�� 
                    {
                        chartInfo.XLabel = "���s��";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // �n��
                    {
                        chartInfo.XLabel = "�n��";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // �Ǝ�
                    {
                        chartInfo.XLabel = "�Ǝ�";
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // �̔��敪
                    {
                        chartInfo.XLabel = "�̔��敪";
                        break;
                    }
                // --- ADD 2008/09/08 --------------------------------<<<<< 
            }

            if (extraparam.MoneyUnit == 0)
            {
                chartInfo.YLabel = "�~";
            }
            else
            {
                chartInfo.YLabel = "��~";
            }
            #endregion
        }
        #endregion

        #region ���e�[�u���X�L�[�}�쐬
        /// <summary>
        /// �e�[�u���X�L�[�}�쐬
        /// </summary>
        private void CreateTable()
        {
            // �x�[�X�e�[�u���쐬
            if (this._baseDataSet == null)
            {
                this._baseDataSet = new DataSet();
            }

            // �`���[�g���o�p�e�[�u���쐬
            if (this._chartDataSet == null)
            {
                this._chartDataSet = new DataSet();
            }

            // �`���[�g�p�e�[�u���f�[�^�쐬�t���O�N���A
            this._ExtraProcFlg = false;
        }
        #endregion

        #region ���`���[�g�p�e�[�u���f�[�^�쐬����
        /// <summary>
        /// �`���[�g�p�e�[�u���f�[�^�쐬����
        /// </summary>
        private void ExtraProcMain(ref DataSet chartDs, DataSet baseDs, SalesMonthYearReportCndtn extraparam)
        {
            DataRow dr;
            DataRow data;

            // �쐬�ς݂̎��͏������X�L�b�v
            if (this._ExtraProcFlg == true) return;

            // �e�[�u���쐬
            chartDs.Tables[this._MonthYearReportDataTable].Clear();
            //chartDs.Tables[this._MonthYearReportDataTable].BeginLoadData(); // DEL 2008/10/08

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // baseDs���\�[�g�����ADataRow���擾����B

            string sortStr = "";

            switch(extraparam.TotalType)
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // ���Ӑ�
                    {
                        switch (extraparam.OutType) // �o�͏�
                        {
                            case 0: // ���Ӑ�
                            case 3: // �Ǘ����_
                            case 4: // ������
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // ����� ����
                                    {
                                        sortStr = "SectionCode, Order, CustomerCode asc";
                                    }
                                    else // �R�[�h
                                    {
                                        sortStr = "SectionCode, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 1: // ���_
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "SectionCode asc";
                                    }
                                    break;
                                }
                            case 2: // ���Ӑ�|���_
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "CustomerCode, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "CustomerCode, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType:
                    {
                        switch (extraparam.OutType) // �o�͏�
                        {
                            case 0: // ���������� (�S���� ��)
                            case 3: // �Ǘ����_
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // ����� ����
                                    {
                                        sortStr = "SectionCode, Order, Code asc";
                                    }
                                    else // �R�[�h
                                    {
                                        sortStr = "SectionCode, Code asc";
                                    }
                                    break;
                                }
                            case 1: // ���Ӑ�
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "SectionCode, Code, Order, CustomerCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "SectionCode, Code, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 2: // ��������-���_
                                {
                                    if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        sortStr = "Code, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        sortStr = "Code, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision:
                    {
                        if (extraparam.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                        {
                            //sortStr = "SectionCode, Order asc"; // DEL 2009/02/06
                            sortStr = "SectionCode, Order, Code asc"; // ADD 2009/02/06
                        }
                        else
                        {
                            //sortStr = "SectionCode asc"; // DEL 2009/02/06
                            sortStr = "SectionCode, Code asc"; // ADD 2009/02/06
                        }
                        break;
                    }
            }  

            DataRow[] baseDr = baseDs.Tables[this._MonthYearReportTable].Select("", sortStr);

            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //for (int ix = 0; ix < baseDs.Tables[this._MonthYearReportTable].Rows.Count; ix++)
            //{
            //    data = baseDs.Tables[this._MonthYearReportTable].Rows[ix];
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            for (int ix = 0; ix < baseDr.Length; ix++)
            {
                data = baseDr[ix];
            // --- ADD 2008/09/08 -------------------------------->>>>>
                dr = chartDs.Tables[this._MonthYearReportDataTable].NewRow();

                // ���v�^�C�g��
                switch (extraparam.TotalType)
                {
                    //--- DEL 2008.08.14 ---------->>>>>
                    //case 0: // ���_��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SectionName];
                    //        break;
                    //    }
                    //case 1: // ���Ӑ��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 2: // �n��ʓ��Ӑ��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SalesAreaName] + " " + data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 3: // �Ǝ�ʓ��Ӑ��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_BusinessTypeName] + " " + data[DCHNB02074EA.CT_CustomerName];
                    //        break;
                    //    }
                    //case 4: // �n���
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SalesAreaName];
                    //        break;
                    //    }
                    //case 5: // �Ǝ��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_BusinessTypeName];
                    //        break;
                    //    }
                    //case 6: // �S���ҕ�
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_EmployeeName];
                    //        break;
                    //    }
                    //case 7: // ������
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_SubSectionName] + " " + data[DCHNB02074EA.CT_MinSectionName];
                    //        break;
                    //    }
                    //case 8: // ���[�J�[��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_MakerName];
                    //        break;
                    //    }
                    //case 9: // ���Ӑ�ʃ��[�J�[��
                    //    {
                    //        dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName] + " " + data[DCHNB02074EA.CT_MakerName];
                    //        break;
                    //    }
                    //--- DEL 2008.08.14 ----------<<<<<
                    //--- ADD 2008.08.14 ---------->>>>>
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // ���Ӑ��
                        {
                            dr[COL_TITLE] = data[DCHNB02074EA.CT_CustomerName];
                            break;
                        }
                    //--- ADD 2008.08.14 ----------<<<<<
                    // --- ADD 2008/09/08 -------------------------------->>>>>
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // �S����
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // �󒍎�
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // ���s�� 
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // �n��
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // �Ǝ�
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // �̔��敪
                        {
                            dr[COL_TITLE] = data[DCHNB02074EA.CT_Name];
                            break;
                        }
                    // --- ADD 2008/09/08 --------------------------------<<<<<
                }

                // ������z
                dr[COL_SALES]       = data[DCHNB02074EA.CT_SalesTtlPrice];
                // �ԕi���z
                dr[COL_RETGOODS]    = data[DCHNB02074EA.CT_RetGoodsTtlPrice];
                // �l�����z
                dr[COL_DISCOUNT]    = data[DCHNB02074EA.CT_DiscountTtlPrice];
                // ��������z
                dr[COL_GSALES]      = data[DCHNB02074EA.CT_PureSalesTtlPrice];
                // ������ڕW���z
                dr[COL_TARGET]      = data[DCHNB02074EA.CT_TargetMoney];
                // �e�����z
                dr[COL_GRPROFIT]    = data[DCHNB02074EA.CT_GrossProfitPrice];
                // �e���ڕW���z
                dr[COL_GRTARGET]    = data[DCHNB02074EA.CT_TargetProfit];

                // �N�Ԕ�����z
                dr[COL_ANSALES]     = data[DCHNB02074EA.CT_AnSalesTtlPrice];
                // �N�ԕԕi���z
                dr[COL_ANRETGOODS]  = data[DCHNB02074EA.CT_AnRetGoodsTtlPrice];
                // �N�Ԓl�����z
                dr[COL_ANDISCOUNT]  = data[DCHNB02074EA.CT_AnDiscountTtlPrice];
                // �N�ԏ�������z
                dr[COL_ANGSALES]    = data[DCHNB02074EA.CT_AnPureSalesTtlPrice];
                // ������ڕW���z
                dr[COL_ANTARGET]    = data[DCHNB02074EA.CT_AnTargetMoney];
                // �e�����z
                dr[COL_ANGRPROFIT]  = data[DCHNB02074EA.CT_AnGrossProfitPrice];
                // �e���ڕW���z
                dr[COL_ANGRTARGET]  = data[DCHNB02074EA.CT_AnTargetProfit];

                // �`���[�g�e�[�u���ɒǉ�
                chartDs.Tables[this._MonthYearReportDataTable].Rows.Add(dr);
            }

            //this._chartDataSet.Tables[this._MonthYearReportDataTable].EndLoadData(); // DEL 2008/10/08

            // �`���[�g�p�e�[�u���f�[�^�쐬�t���O�Z�b�g
            this._ExtraProcFlg = true;
        }
        #endregion

        #region ���`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// <summary>
        /// �`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// </summary>
        private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

            
            // ���㌎��N��`���[�g
            this._chartDataSet.Tables.Add(this._MonthYearReportDataTable);

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TITLE, typeof(string));   // ���v�^�C�g��
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].Caption = "���v";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRPROFIT, typeof(Int64)); // �e�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption = "�e�����z";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRTARGET, typeof(Int64)); // �e���ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].Caption = "�e���ڕW";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_DISCOUNT, typeof(Int64)); // �l�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption = "�l��";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_RETGOODS, typeof(Int64)); // �ԕi���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].Caption = "�ԕi";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GSALES, typeof(Int64));   // ��������z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].Caption = "������";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_SALES, typeof(Int64));    // ������z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].Caption = "����";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TARGET, typeof(Int64));   // �ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].Caption = "�ڕW";


            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRPROFIT, typeof(Int64));   // �e�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption = "�e�����z";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRTARGET, typeof(Int64));   // �e���ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption = "�e���ڕW";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANDISCOUNT, typeof(Int64));   // �N�Ԓl��
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption = "�l��";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANRETGOODS, typeof(Int64));   // �N�ԕԕi
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption = "�ԕi";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGSALES, typeof(Int64));     // �N�ԏ�����
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].Caption = "������";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANSALES, typeof(Int64));      // �N�Ԕ���
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].Caption = "����";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANTARGET, typeof(Int64));     // ������ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].Caption = "�ڕW";
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 -------------------------------->>>>> �\�����ύX�̂�
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TITLE, typeof(string));   // ���v�^�C�g��
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].DefaultValue = "";
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TITLE].Caption = "���v";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRPROFIT, typeof(Int64)); // �e�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRPROFIT].Caption = "�e�����z";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GRTARGET, typeof(Int64)); // �e���ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GRTARGET].Caption = "�e���ڕW";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_DISCOUNT, typeof(Int64)); // �l�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_DISCOUNT].Caption = "�l��";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_RETGOODS, typeof(Int64)); // �ԕi���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_RETGOODS].Caption = "�ԕi";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_GSALES, typeof(Int64));   // ��������z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_GSALES].Caption = "������";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_SALES, typeof(Int64));    // ������z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_SALES].Caption = "����";
            
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_TARGET, typeof(Int64));   // �ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_TARGET].Caption = "����ڕW";

            // ����
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRPROFIT, typeof(Int64));   // �e�����z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRPROFIT].Caption = "�e�����z";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGRTARGET, typeof(Int64));   // �e���ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGRTARGET].Caption = "�e���ڕW";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANDISCOUNT, typeof(Int64));   // �N�Ԓl��
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANDISCOUNT].Caption = "�l��";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANRETGOODS, typeof(Int64));   // �N�ԕԕi
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANRETGOODS].Caption = "�ԕi";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANGSALES, typeof(Int64));     // �N�ԏ�����
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANGSALES].Caption = "������";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANSALES, typeof(Int64));      // �N�Ԕ���
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANSALES].Caption = "����";

            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns.Add(COL_ANTARGET, typeof(Int64));     // ������ڕW���z
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].DefaultValue = 0;
            this._chartDataSet.Tables[this._MonthYearReportDataTable].Columns[COL_ANTARGET].Caption = "����ڕW";          
            // --- ADD 2008/09/08 --------------------------------<<<<<
        }
        #endregion

        #endregion

        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "���㌎��N�񒊏o����", iMsg, iSt, iButton, iDefButton);
        }

    }

}

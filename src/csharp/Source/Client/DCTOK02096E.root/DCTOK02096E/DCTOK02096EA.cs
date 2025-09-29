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
    /// �O�N�Δ�\�`���[�g�f�[�^�쐬�N���X
    /// </summary>
    public class AgentOrderChart : IChartExtract
    {

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
		/// 
        public AgentOrderChart(int index, int para)
        {
			this._ChartScIndex = index;						//�`���[�gmode�p�����[�^

			_singleTypeObj._ModePara = para;				//�N��mode�i�����ʁj�p�����[�^��EB�ɓn��

			DCTOK02096EB _DCTOK02096EB = new DCTOK02096EB();

			this._chartParamater = new ChartParamater();

			this._chartParamater.IsCondtnButton = true;     // �i�������{�^��(�\�����Ȃ�)
			this._chartParamater.IsDrillDown = false;       // �`���[�g�̃h�����_�E���@�\(�Ȃ�)                 

			this._prevYearTableAcs = new PrevYearComparison();

			// �`���[�g�\���p�f�[�^�Z�b�g�C���X�^���X��
			this._chartDataSet = new DataSet();
		
        }

        #endregion

        #region const

        #endregion

        #region Private Members

        private string _PGID = "DCTOK02126E";

        private int _ChartScIndex = 0;
        private bool _ExtraProcFlg = false;


        private PrevYearComparison _prevYearTableAcs = null;    // �O�N�Δ�\�A�N�Z�X�N���X

        /// <summary>�`���[�g���p�����[�^</summary>
        private ChartParamater _chartParamater;
        private int _paraStyle = 1;

        /// <summary>�`���[�g�\���p�����[�^���X�g</summary>
        private List<int> _chartInfoList = new List<int>();

        /// <summary>�x�[�X�f�[�^�ێ��p�f�[�^�Z�b�g</summary>
        private DataSet _baseDataSet;
        /// <summary>�`���[�g�\���p�f�[�^�Z�b�g</summary>
        private DataSet _chartDataSet;

        // ���o�����N���X
		private ExtrInfo_DCTOK02093E _extraparam;

        /// <summary>�O�N�Δ�\�f�[�^�e�[�u����(�x�[�X�p)</summary>
        private string _PrevYearReportTable;

        /// <summary>�O�N�Δ�\�f�[�^�e�[�u����(�`���[�g�p�F�䗦)</summary>
        private string _PrevYearReportDataTableRatio = "PrevYearReportRatio";

		/// <summary>�O�N�Δ�\�f�[�^�e�[�u����(�`���[�g�p�F����)</summary>
		private string _PrevYearReportDataTableSales = "PrevYearReportSales";

        // DataTable�񖼁��`���[�g�p�e�[�u����
		private const string COL_TITLE = "COL_TITLE";
		private const string COL_THIS_SALES = "COL_PARA_TSALES";
		private const string COL_FIRST_SALES = "COL_PARA_FSALES";
		private const string COL_SALES_RATIO = "COL_PARA_RATIO";
		private const string COL_THIS_GROSS = "COL_PARA_TGROSS";
		private const string COL_FIRST_GROSS = "COL_PARA_FGROSS";
		private const string COL_GROSS_RATIO = "COL_PARA_GRSRATIO";

		// �������͂t�h��ʕ\��
		DCTOK02096EB _singleTypeObj = new DCTOK02096EB();

		List<string> _CodeList;
		List<string> _NameList;

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

			_singleTypeObj.b_Ok = true;						//�t���[���́w�O���t�\���x�{�^���������ꂽ���͏��true

            try
            {
				this._extraparam = (ExtrInfo_DCTOK02093E)parameter;

                int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
                int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                string message = "";

                try
                {
					status = this._prevYearTableAcs.SearchStatic(out message);
                    if (status == 0)
                    {
                        this._PrevYearReportTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
						
						// �A�N�Z�X�N���X����擾�����e�[�u�����A�`���[�g�p�x�[�X�e�[�u���Ƃ��ĕێ�
                        this._baseDataSet = this._prevYearTableAcs._printDataSet.Copy();

                        this.CreateTable();

						// �`���[�g�\���p�f�[�^�Z�b�g�X�L�[�}�ݒ�
						SetTableSchema();

						int tbRatioCnt = 0;
						int tbSalesCnt = 0;

						// �`���[�g�\���p�����[�^���X�g������
						#region < �p�����[�^������ >
						this._chartInfoList = new List<int>();
 
						switch(this._ChartScIndex)
						{
							 case 0:	//�䗦
								tbRatioCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Count;
								break;

							 case 1:	//���z
								tbSalesCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Count;
								break;
						}
							if (this._ChartScIndex == 0)	//�䗦
							{
								for (int ix = 1; ix < tbRatioCnt ; ix++)
								{
									this._chartInfoList.Add(1);
								}
							}
							else
							{
								for (int ix = 1; ix < tbSalesCnt; ix++)
								{
									this._chartInfoList.Add(1);
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
                msg = "�O�N�Δ�\���̎擾�Ɏ��s���܂����B";
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
		/// <param name="chartInfo">�`���[�g�p�����[�^</param>
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

					int tbRatioRowsCnt = 0;
					int tbSalesRowsCnt = 0;

					switch (this._ChartScIndex)
					{
						case 0:	//�䗦
							tbRatioRowsCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Rows.Count;
							break;

						case 1:	//���z
							tbSalesRowsCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Rows.Count;
							break;
					}

					if ((tbRatioRowsCnt + tbSalesRowsCnt) == 0)
					{
						msg = "�f�[�^�����݂��܂���ł����B";
						return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
					}

					// �f�[�^�\�[�X�̐ݒ�
					switch (this._ChartScIndex)
					{
						case 0:	//�䗦
							chartInfo.DataSource = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio];

							break;

						case 1:	//���z
							chartInfo.DataSource = this._chartDataSet.Tables[this._PrevYearReportDataTableSales];

							break;
					}
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
		/// <param name="chartInfo"></param>
		/// <param name="msg"></param>
        /// <returns></returns>
        public int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            // �`���[�g�\���p�p�����[�^�̎擾
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

            #region �p�����[�^�Z�b�g
            _singleTypeObj._TitleList = new List<string>();

			_singleTypeObj._Code = new List<string>();
			_singleTypeObj._Name = new List<string>();

			this.CreatList();

			if (this._ChartScIndex == 0)	//�䗦
			{
				_singleTypeObj._TitleList.Add("����F�䗦");
				_singleTypeObj._TitleList.Add("�e���F�䗦");

				//DCTOK02096EB�Ɉꊇ���ă��X�g��n��
				_singleTypeObj._Code = this._CodeList;
				_singleTypeObj._Name = this._NameList;

			}
			else
			{
                _singleTypeObj._TitleList.Add("����F���N");
                _singleTypeObj._TitleList.Add("����F�O�N");
                _singleTypeObj._TitleList.Add("�e���F���N");
                _singleTypeObj._TitleList.Add("�e���F�O�N");

				_singleTypeObj._Code = this._CodeList;
				_singleTypeObj._Name = this._NameList;
			}

			_singleTypeObj._GraphPara = new List<int>();
			_singleTypeObj._GraphPara.Add(this._paraStyle);

			_singleTypeObj._GraphShow = new List<int>();

			for (int ix = 0; ix < this._chartInfoList.Count; ix++)
			{
				_singleTypeObj._GraphShow.Add(this._chartInfoList[ix]);
			}

			#endregion

            Form customForm = (Form)_singleTypeObj;
            customForm.StartPosition = FormStartPosition.CenterScreen;

			DialogResult dialogResult = customForm.ShowDialog();

			if (dialogResult == DialogResult.Cancel)
			{
				_singleTypeObj.b_Ok = false;
				//_singleTypeObj._Ok = false;
			}

			
			#region �p�����[�^�Q�b�g
			if (_singleTypeObj._GraphPara[0] > -1)
			{
				int cnt = 0;
				this._paraStyle = _singleTypeObj._GraphPara[0];

				for (int ix = 0; ix < this._chartInfoList.Count; ix++)
				{
					this._chartInfoList[ix] = _singleTypeObj._GraphShow[cnt];
					cnt++;
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
		/// <param name="extraparam">���o�����N���X</param>
        /// <param name="chartInfo">�`���[�g�p�����[�^</param>
		private void CreateChartInfo(ref ChartInfo chartInfo, ExtrInfo_DCTOK02093E extraparam)
		{
				chartInfo.Palette = PaletteStyle.DefaultWindows;		   	// �p���b�g(�F�̑g�ݍ��킹)
				chartInfo.DockPosition = EditorDockPosition.Top;			// �f�[�^�G�f�B�^�[�|�W�V����
				chartInfo.PanelColor = Color.FromArgb(198, 219, 255);		// �p�l���̐F
				chartInfo.Ydecimal = 0;										// Y�������_�ȉ���
				chartInfo.Ydecimal2 = 0;									// Y���Q�����_�ȉ���
				chartInfo.Stacked = StackStyle.No;                          // �f�[�^�̐ϑw(���E���ɕ��ׂ�)
				chartInfo.Cluster = true;									// Z���Ɍ����Čn������ׂ邩�ǂ���
				chartInfo.Legend = true;                                    // �}��(�\������)
				chartInfo.LegendBox = false;								// X���̖}��̕\����\��
				chartInfo.Grid = true;                                      // �f�[�^�O���b�h(�\������)
				chartInfo.View3DDepth = 80; 								// 3D�O���t�̉��s��

				chartInfo.PointLabel = false;                               // �`���[�g�̏�ɒl�\��(���Ȃ�)
				chartInfo.Chart3D = true;                                   // �`���[�g3D or 2D (3D)

				chartInfo.AngleX = 30;										// X���̉�]
				chartInfo.AngleY = 30;										// Y���̉�]

				#region < �n����\���ݒ� >
				int[] seriesVisible;
				int cnt = 0;
				int index = 0;

				int i_cnt = 0;
				int ccnt = 0;
				//List<string> _codeCashe = new List<string>();
				List<string> _codeCashe = null;
				List<int> lstindex = new List<int>();

				// �O��̕\���ݒ�������p��
				#region �w�Ώۍ���2�x�̕\���E��\���ݒ�
				//�w�Ώۍ���2�x�̕\���E��\���ݒ�
				switch (this._ChartScIndex)
				{
					case 0:	//�䗦�̏ꍇ
						_codeCashe = _singleTypeObj._CodeCashe_r;
						break;

					case 1:
						_codeCashe = _singleTypeObj._CodeCashe_s;
						break;
				}

				//�R�[�h�L���b�V������������Ă�����
				if (_codeCashe != null && 0 < _codeCashe.Count)
				{
					//TODO�@_CodeList���X�V
					this.CreatList();

						for (int ix = 0; ix < _codeCashe.Count; ix++)
						{
							//_CodeList���̗v�f��_codeCashe���̗v�f�Ɠ������̂���������
							if (this._CodeList != null && this._CodeList.Contains(_codeCashe[ix]) == true)
							{
								//_CodeList���̗v�f�̃C���f�b�N�X���擾
								lstindex.Add(this._CodeList.IndexOf(_codeCashe[ix]));
							}
						}

						#region �w�m��x�{�^���������ꂽ�ꍇ�̏���
						if (_singleTypeObj.b_Ok == true)	//Form2���w�m��x�ŕ���ꂽ���̏����B�ielse:�~�ŕ���ꂽ���͉��������I������j
						{
							// _chartInfoList�����ׂ�0��
							for (int ix = 0; ix < this._chartInfoList.Count; ix++)
							{
								this._chartInfoList[ix] = 0;
							}

							if (lstindex.Count == 0)	//_CodeList���̗v�f��_codeCashe���̗v�f�Ɠ������̂��Ȃ��ꍇ
							{
								//�R�[�h�̎Ⴂ�f�[�^���ꌏ�����\��
								switch (this._ChartScIndex)
								{
									case 0:	//�䗦�̏ꍇ
										this._chartInfoList[0] = 1;
										this._chartInfoList[1] = 1;
										break;

									case 1:	//���z�̏ꍇ
										this._chartInfoList[0] = 1;
										this._chartInfoList[1] = 1;
										this._chartInfoList[2] = 1;
										this._chartInfoList[3] = 1;
										break;
								}
							}
							else
							{
								//_codeCashe���̗v�f������1��
								for (int jx = 0; jx < lstindex.Count; jx++)
								{
									switch (this._ChartScIndex)
									{
										case 0:	//�䗦�̏ꍇ

											i_cnt = lstindex[jx] * 2;

											this._chartInfoList[i_cnt] = 1;
											this._chartInfoList[i_cnt + 1] = 1;

											break;

										case 1:	//���z�̏ꍇ
											i_cnt = lstindex[jx] * 4;

											this._chartInfoList[i_cnt] = 1;
											this._chartInfoList[i_cnt + 1] = 1;
											this._chartInfoList[i_cnt + 2] = 1;
											this._chartInfoList[i_cnt + 3] = 1;

											break;
									}
								}

							}

						}
						#endregion �w�m��x�{�^���������ꂽ�ꍇ�̏����F�I

						#endregion	�w�Ώۍ���2�x�̕\���E��\���ݒ�F�I

						#region �w�Ώۍ��ځx�̕\���E��\���ݒ�

						#region �w�m��x�{�^���������ꂽ�ꍇ�̏���
						if (_singleTypeObj.b_Ok == true)
						{

							//�w�Ώۍ��ځx�̕\���E��\���ݒ�
							for (int kx = 0; kx < lstindex.Count; kx++)
							{
								switch (this._ChartScIndex)
								{
									case 0:	//�䗦�̏ꍇ

										ccnt = lstindex[kx] * 2;

										//_chartInfoList�́w�䗦�F����x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_r[0] == false)
										{
											this._chartInfoList[ccnt] = 0;
										}

										//_chartInfoList�́w�䗦�F����x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_r[1] == false)
										{
											this._chartInfoList[ccnt + 1] = 0;
										}

										break;

									case 1:

										ccnt = lstindex[kx] * 4;

										//_chartInfoList�́w����F���N�x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_s[0] == false)
										{
											this._chartInfoList[ccnt] = 0;
										}
										//_chartInfoList�́w����F�O�N�x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_s[1] == false)
										{
											this._chartInfoList[ccnt + 1] = 0;
										}
										//_chartInfoList�́w�e���F���N�x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_s[2] == false)
										{
											this._chartInfoList[ccnt + 2] = 0;
										}
										//_chartInfoList�́w�e���F�O�N�x�Ԃ���\��
										if (_singleTypeObj._CheckedIteme_s[3] == false)
										{
											this._chartInfoList[ccnt + 3] = 0;
										}

										break;
								}
							}

						}
						#endregion �w�m��x�{�^���������ꂽ�ꍇ�̏���

						#endregion	�w�Ώۍ��ځx�̕\���E��\���ݒ�F�I

					}
				else	//�R�[�h�L���b�V������������Ă��Ȃ�������\���̎�
				{
					//_chartInfoList�����ׂ�0��
					for (int ix = 0; ix < this._chartInfoList.Count; ix++)
					{
						this._chartInfoList[ix] = 0;
					}

					//�R�[�h�̎Ⴂ�f�[�^���ꌏ�����\��
					switch (this._ChartScIndex)
					{
						case 0:	//�䗦�̏ꍇ
							this._chartInfoList[0] = 1;
							this._chartInfoList[1] = 1;
							break;

						case 1:	//���z�̏ꍇ
							this._chartInfoList[0] = 1;
							this._chartInfoList[1] = 1;
							this._chartInfoList[2] = 1;
							this._chartInfoList[3] = 1;
							break;
					}
				}

				for (int kx = 0; kx < this._chartInfoList.Count; kx++)
				{
					if (this._chartInfoList[kx] == 0) cnt++;
				}

				seriesVisible = new int[cnt];		//seriesVisible�̗v�f�������߂�

				for (int kx = 0; kx < this._chartInfoList.Count; kx++)
				{
					if (this._chartInfoList[kx] == 0)
					{
						seriesVisible[index] = kx;
						index++;
					}
				}

				//�n�̕\���E��\���ݒ�B��\���ɂ������n�̔ԍ������ꂼ��̔z��Ɋi�[
				chartInfo.SeriesVisible = seriesVisible;                    // �n�̔�\���ݒ�

				// b_Ok�̏�����
				_singleTypeObj.b_Ok = true;

				#endregion

/*
            int[] seriesVisible;
            if (this._ChartScIndex == 0)
            {
                seriesVisible = new int[4];
                seriesVisible[0] = 4;
                seriesVisible[1] = 5;
                seriesVisible[2] = 6;
                seriesVisible[3] = 7;
            }
            else
            {
                seriesVisible = new int[4];
                seriesVisible[0] = 0;
                seriesVisible[1] = 1;
                seriesVisible[2] = 2;
                seriesVisible[3] = 3;
            }
            chartInfo.SeriesVisible = seriesVisible;                    // �n�̔�\���ݒ�
*/

				#region < �`���[�g�X�^�C���ݒ� >
				switch (this._paraStyle)
				{
					case 0:	//�_�O���t
						{
							chartInfo.Style = ChartStyle.Bar;						// �`���[�g�̃X�^�C��
							chartInfo.Cluster = true;                               // Z���Ɍ����Čn������ׂ邩�ǂ���

							break;
						}
					case 1:
						{
							chartInfo.Style = ChartStyle.Line;						// �`���[�g�̃X�^�C��
							chartInfo.Cluster = true;                               // Z���Ɍ����Čn������ׂ邩�ǂ���

							break;
						}
				}

				#endregion

				#region < �^�C�g���ݒ� >
				chartInfo.Title = "�O�N�Δ�\";           // �^�C�g��

				string extraTitle = "";
				if (this._ChartScIndex == 0)
				{
					extraTitle = "�i�䗦�j";
				}
				else
				{
					extraTitle = "�i���z�j";
				}
				chartInfo.SubTitle = extraTitle;          // �T�u�^�C�g���i�㕔�j

				switch (extraparam.ListType)
				{
                    case 0: // ���Ӑ��
                        {
                            chartInfo.XLabel = "���Ӑ�";	  // �T�u�^�C�g���i�����j
                            break;
                        }
                    case 1: // �S���ҕ�
                        {
                            chartInfo.XLabel = "�S����";
                            break;
                        }
                    case 2: // �󒍎ҕ�
                        {
                            chartInfo.XLabel = "�󒍎�";
                            break;
                        }
                    case 3: // �n��
                        {
                            chartInfo.XLabel = "�n��";
                            break;
                        }
                    case 4: // �Ǝ�
                        {
                            chartInfo.XLabel = "�Ǝ�";
                            break;
                        }
                    case 5: //��ٰ�ߺ��ޕ�
                        {
                            chartInfo.XLabel = "�O���[�v�R�[�h";
                            break;
                        }
                    case 6: //�a�k���ޕ�
                        {
                            chartInfo.XLabel = "�a�k�R�[�h";
                            break;
                        }
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
		private void ExtraProcMain(ref DataSet chartDs, DataSet baseDs, ExtrInfo_DCTOK02093E extraparam)
        {
            DataRow dr;
            DataRow data;

            // �쐬�ς݂̎��͏������X�L�b�v
            if (this._ExtraProcFlg == true) return;

			// �W�v���^�C�g��
			//�J�n�N��					
			string str_st_Month = this._extraparam.St_AddUpYearMonth.ToString() + "01";
			DateTime dt_stDate = DateTime.ParseExact(str_st_Month, "yyyyMMdd", null);
			//�I���N��
			string str_ed_Month = this._extraparam.Ed_AddUpYearMonth.ToString() + "01";
			DateTime dt_edDate = DateTime.ParseExact(str_ed_Month, "yyyyMMdd", null);

			switch (this._ChartScIndex)
			{
			    case 0:	//�䗦
					// �e�[�u���쐬
					chartDs.Tables[this._PrevYearReportDataTableRatio].Clear();
					chartDs.Tables[this._PrevYearReportDataTableRatio].BeginLoadData();

					#region �䗦�p�e�[�u���f�[�^�쐬

					// �P������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.Month.ToString() + "��";
					//�w�����ʁx�iListType�j�̐�����for�ŉ񂵂�Row�����
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio1];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio1];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �Q������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(1).Month.ToString() + "��";		
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio2];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio2];	// �e���F�䗦
					
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);
					
					// �R������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(2).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio3];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio3];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �S������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(3).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio4];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio4];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �T������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(4).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio5];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio5];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �U������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(5).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio6];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio6];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �V������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(6).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio7];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio7];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �W������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(7).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio8];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio8];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �X������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(8).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio9];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio9];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �P�O������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(9).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio10];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio10];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �P�P������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(10).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio11];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio11];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// �P�Q������
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.AddMonths(11).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio12];	// ����F�䗦
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio12];	// �e���F�䗦
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);
					
					#endregion �䗦�p�e�[�u���f�[�^�쐬

					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].EndLoadData();

					break;

				case 1:	//����
					// �e�[�u���쐬
					chartDs.Tables[this._PrevYearReportDataTableSales].Clear();
					chartDs.Tables[this._PrevYearReportDataTableSales].BeginLoadData();

					#region ����p�e�[�u���f�[�^�쐬

					// �P������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F�䗦
					dr[COL_TITLE] = dt_stDate.Month.ToString() + "��";
					//�w�����ʁx�iListType�j�̐�����for�ŉ񂵂�Row�����
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales1];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales1];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross1];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross1];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �Q������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(1).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales2];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales2];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross2];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross2];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �R������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(2).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales3];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales3];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross3];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross3];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �S������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(3).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales4];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales4];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross4];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross4];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �T������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(4).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales5];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales5];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross5];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross5];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �U������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(5).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales6];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales6];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross6];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross6];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �V������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(6).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales7];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales7];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross7];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross7];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �W������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(7).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales8];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales8];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross8];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross8];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);
					
					// �X������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(8).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales9];		// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales9];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross9];		// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross9];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �P�O������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(9).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales10];	// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales10];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross10];	// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross10];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �P�P������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(10).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales11];	// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales11];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross11];	// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross11];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// �P�Q������
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//�`���[�g�p�F����
					dr[COL_TITLE] = dt_stDate.AddMonths(11).Month.ToString() + "��";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales12];	// ����F���N
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales12];	// ����F�O�N
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross12];	// �e���F���N
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross12];	// �e���F�O�N
					}
					// �`���[�g�e�[�u���ɒǉ�
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					#endregion ����p�e�[�u���f�[�^�쐬

				this._chartDataSet.Tables[this._PrevYearReportDataTableSales].EndLoadData();
				break;
			}

            // �`���[�g�p�e�[�u���f�[�^�쐬�t���O�Z�b�g
            this._ExtraProcFlg = true;

        }
        #endregion

		#region �����ݒ�_�C�A���O�ɓn�����X�g���쐬
		/// <summary>
		/// �����ݒ�_�C�A���O�ɓn�����X�g�̍쐬
		/// </summary>
		public void CreatList()
		{
			DataSet baseDs = this._baseDataSet;
			DataRow data;

			_CodeList = new List<string>();
			_NameList = new List<string>();

			for (int i = 0; i < baseDs.Tables[this._PrevYearReportTable].Rows.Count; i++)
			{
				switch (this._extraparam.ListType)
				{
					case 0:	//���Ӑ��
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_CustomerCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_CustomerSnm].ToString());

						break;

                    case 1:	//�S���ҕ�
                    case 2: //�󒍎ҕ�
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_EmployeeCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_EmployeeName].ToString());

                        break;
					case 3:	//�n���
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_SalesAreaCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_SalesAreaName].ToString());

						break;

					case 4:	//�Ǝ��
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BusinessTypeCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_BusinessTypeName].ToString());

						break;

					case 5:	//��ٰ�ߺ��ޕ�	
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
                        _CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BLGroupCode].ToString());
                        _NameList.Add(data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName].ToString());

						break;
                    case 6: //BL���ޕ�
                        data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
                        _CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BLGoodsCode].ToString());
                        _NameList.Add(data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName].ToString());

                        break;
				}
			}

		}
		#endregion �����ݒ�_�C�A���O�ɓn�����X�g���쐬:�I

        #region ���`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// <summary>
        /// �`���[�g�p�f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// </summary>
		private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

			DataRow data;
			DataSet chartDs = this._chartDataSet;
			DataSet baseDs = this._baseDataSet;

            // �O�N�Δ�\�`���[�g
			switch (this._ChartScIndex)
			{
				case 0:

					this._chartDataSet.Tables.Add(this._PrevYearReportDataTableRatio);
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_TITLE, typeof(string));	// �W�v���^�C�g��
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_TITLE].DefaultValue = "";
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_TITLE].Caption = "�W�v��";

					for (int ix = 0; ix < this._baseDataSet.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_SALES_RATIO + i, typeof(Int64));	// ����F�䗦
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].DefaultValue = 0;
						
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_GROSS_RATIO + i, typeof(Int64));	// �e���F�䗦
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].DefaultValue = 0;


                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_GROSS_RATIO + i, typeof(Int64));	// �e���F�䗦
                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_SALES_RATIO + i, typeof(Int64));	// ����F�䗦
                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].DefaultValue = 0;


						switch (this._extraparam.ListType)
						{
							#region ListType�ʂɁw�ڍו\���x�^�C�g����ݒ�

							case 0:	//���Ӑ��
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " ����F�䗦";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " �e���F�䗦";

								break;

                            case 1:	//�S���ҕ�
                            case 2: //�󒍎ҕ�
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " ����F�䗦";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " �e���F�䗦";

                                break;
							case 3:	//�n���
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " ����F�䗦";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " �e���F�䗦";

								break;

							case 4:	//�Ǝ��
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " ����F�䗦";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " �e���F�䗦";

								break;

							case 5:	//��ٰ�߃R�[�h
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " ����F�䗦";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " �e���F�䗦";

								break;
                            case 6: //BL���ޕ�
                                data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " ����F�䗦";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " �e���F�䗦";

                                break;
							#endregion ListType�ʂɁw�ڍו\���x�^�C�g����ݒ�F�I
						}

					}
					break;

				case 1:

					this._chartDataSet.Tables.Add(this._PrevYearReportDataTableSales);
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_TITLE, typeof(string));	// �W�v���^�C�g��
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_TITLE].DefaultValue = "";
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_TITLE].Caption = "�W�v��";

					for (int ix = 0; ix < this._baseDataSet.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_SALES + i, typeof(Int64));	    // ����F���N
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_SALES + i, typeof(Int64));	// ����F���N
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_GROSS + i, typeof(Int64));	// �e���F���N
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_GROSS + i, typeof(Int64));   // �e���F�O�N
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].DefaultValue = 0;


                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_GROSS + i, typeof(Int64));	// �e���F���N
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_GROSS + i, typeof(Int64));   // �e���F�O�N
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].DefaultValue = 0;
                        
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_SALES + i, typeof(Int64));	    // ����F���N
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_SALES + i, typeof(Int64));	// ����F�O�N
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].DefaultValue = 0;

                        
                        
                        switch (this._extraparam.ListType)
						{
							#region ListType�ʂɁw�ڍו\���x�^�C�g����ݒ�
							case 0:	//���Ӑ��
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " ����F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " ����F�O�N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " �e���F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " �e���F�O�N";
								break;
                            case 1:	//�S���ҕ�
                            case 2: //�󒍎ҕ�
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " ����F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " ����F�O�N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " �e���F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " �e���F�O�N";
								break;
							case 3:	//�n���
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " ����F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " ����F�O�N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " �e���F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " �e���F�O�N";
								break;
							case 4:	//�Ǝ��
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " ����F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " ����F�O�N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " �e���F���N";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " �e���F�O�N";
								break;
							case 5:	//��ٰ�ߺ��ޕ�
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " ����F���N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " ����F�O�N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " �e���F���N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " �e���F�O�N";
								break;
                            case 6: //�a�k���ޕ�
                                data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " ����F���N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " ����F�O�N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " �e���F���N";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " �e���F�O�N";
                                break;
							#endregion ListType�ʂɁw�ڍו\���x�^�C�g����ݒ�F�I
						}
					}
					break;
					}
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
            return TMsgDisp.Show(iLevel, "�O�N�Δ�\���o����", iMsg, iSt, iButton, iDefButton);
        }




	}

}

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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���̓`���[�g�r���[�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̓`���[�g��\������t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal AnalysisChartViewForm()
		{
			InitializeComponent();

			// �`���[�g���o�N���X�I�u�W�F�N�g���X�g������
			this._chartExtractList = new List<IChartExtract>();

			// �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
			this._drillDownChartList		= new SortedList();

			// �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g������
			this._condtionClickChartList	= new SortedList();

			// �`���[�g�p�����[�^���X�g������
			this._chartInfoList				= new SortedList();

			// ���̓`���[�g�\���ݒ�A�N�Z�X�N���X
			this._analysisChartSettingAcs	= new AnalysisChartSettingAcs();
		}
		#endregion

		#region Private Member
		/// <summary>�`���[�g���o�N���X�I�u�W�F�N�g���X�g</summary>
		private List<IChartExtract> _chartExtractList = null;

		/// <summary>�h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
		private SortedList _drillDownChartList						= null;

		/// <summary>�����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g</summary>
		private SortedList _condtionClickChartList					= null;

		/// <summary>�`���[�g�p�����[�^���X�g</summary>
		private SortedList _chartInfoList							= null;

		/// <summary>�`���[�g�����N���X</summary>
		private ChartLibrary _chartLibrary							= null;

		/// <summary>���̓`���[�g�\���ݒ�A�N�Z�X�N���X</summary>
		private AnalysisChartSettingAcs _analysisChartSettingAcs	= null;

		/// <summary>���[���ʗp�t�H�[���R���g���[���L�[</summary>
		private string _formControlInfoKey = "";

		/// <summary>�`���[�gNo.</summary>
		private int _number;

		/// <summary>���o�����I�u�W�F�N�g</summary>
		private object _extractObj;

		#endregion

		#region Property
		/// <summary>�`���[�g���o�I�u�W�F�N�g���X�g�v���p�e�B</summary>
		internal List<IChartExtract> ChartExtractList
		{
			get { return this._chartExtractList; }
			set { this._chartExtractList = value; }
		}

		/// <summary>���̓`���[�g���Ǘ��N���X���X�g������v���p�e�B�i�ǂݎ���p�j</summary>
		internal string AnalysisChartControlListString
		{
			get
			{
				StringBuilder analysisChartControlListString = new StringBuilder(string.Empty);

				//if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
				//{
				//  return analysisChartControlListString.ToString();
				//}

				//foreach (IPrintConditionInpTypeGraphExtract graphExtract in this._chartExtractList)
				//{
				//  if (analysisChartControlListString.Length > 0)
				//  {
				//    // ���s
				//    analysisChartControlListString.Append("\r\n");
				//  }

				//  // ���̓`���[�g���̂�ǉ�
				//  analysisChartControlListString.Append(graphExtract.Name);
				//}

				return analysisChartControlListString.ToString();
			}
		}
		/// <summary>���[���ʗp�t�H�[���R���g���[���L�[�v���p�e�B</summary>
		internal string FormControlInfoKey
		{
			get { return this._formControlInfoKey; }
			set { this._formControlInfoKey = value; }
		}
		/// <summary>�`���[�gNo.�v���p�e�B</summary>
		internal int Number
		{
			get { return this._number; }
			set { this._number = value; }
		}
		#endregion

		#region Private Method


		#region ���̓`���[�g�f�[�^��������
		/// <summary>
		/// ���̓`���[�g�f�[�^��������
		/// </summary>
		/// <param name="graphExtractObjList">���̓`���[�g���Ǘ��N���X���X�g</param>
		/// <returns>RESULT�itrue:OK,false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ���̓`���[�g���o�N���X�ɂĕ��̓`���[�g�f�[�^�̐������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private bool CreateChartData(List<IChartExtract> chartExtractObjList)
		{
			try
			{
				if ((chartExtractObjList == null) || (chartExtractObjList.Count == 0))
				{
					return false;
				}


				foreach (IChartExtract chartExtract in chartExtractObjList)
				{
					string msg;
					
					// �`���[�g�f�[�^�쐬
					int status = chartExtract.MakeChartData(this, this._extractObj, out msg);
					switch (status)
					{
						case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
							{
								break;
							}
						default:
							{
								SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
								return false;
							}
					}
				
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "���̓`���[�g�f�[�^�̐����Ɏ��s���܂����B" + "\r\n" + ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return false;
			}

			return true;
		}
		#endregion

		#region ���̓`���[�g�p�����[�^���X�g�擾����
		/// <summary>
		/// ���̓`���[�g�p�����[�^���X�g�擾����
		/// </summary>
		/// <param name="graphExtractObjList">���̓`���[�g���Ǘ��N���X���X�g</param>
		/// <returns>RESULT�itrue:OK,false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ���̓`���[�g���o�N���X���番�̓`���[�g�p�����[�^�̃��X�g���擾���܂��B
		///                  �܂��A�h�����_�E���̗L�镪�̓`���[�g���Ǘ��N���X�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private bool GetChartInfoList(List<IChartExtract> chartExtractObjList)
		{
			try
			{
				// �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g�N���A
				this._drillDownChartList.Clear();

				// �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g�N���A
				this._condtionClickChartList.Clear();

				// �`���[�g�p�����[�^���X�g�N���A
				this._chartInfoList.Clear();

				if ((chartExtractObjList == null) || (chartExtractObjList.Count == 0))
				{
					return false;
				}

				for (int i = 0; i < chartExtractObjList.Count; i++)
				{
					IChartExtract chartExtractObj = chartExtractObjList[i];

					if (chartExtractObj != null)
					{
						string msg = "";
						ChartInfo chartInfo;

						// �`���[�g���
						int status = chartExtractObj.GetChartInfo(this, this._extractObj, out chartInfo, out msg);

						switch (status)
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

									// �h�����_�E���`���[�g�L��
									if (chartExtractObj.ChartParamater.IsDrillDown)
									{
										// �h�����_�E���L�蕪�̓`���[�g���Ǘ��N���X���X�g�Ɋi�[
										this._drillDownChartList.Add(number, chartExtractObj);
									}

									// �����i�����{�^���j�L��
									if (chartExtractObj.ChartParamater.IsCondtnButton)
									{
										// �����{�^���L�蕪�̓`���[�g���Ǘ��N���X���X�g�Ɋi�[
										this._condtionClickChartList.Add(number, chartExtractObj);

										// �����{�^�����ݒ�
										this.ConditionButtonVisibleFalse(number, true);
									}
									else
									{
										// �����{�^�����ݒ�
										this.ConditionButtonVisibleFalse(number, false);
									}
									break;
								}

							default:
								{
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return false;
								}
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

			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private void ShowChartData()
		{

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

			// �X�^�C���ύX
			SFANL07200UA.mControlScreenSkin.SettingScreenSkin(this._chartLibrary);
			
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
						string msg;
						ChartInfo chartInfo;

						// �h�����_�E���`���[�g�p�����[�^�擾
						int status = iChartExtract.GetDrillDownChartInfo(this, e.Element, out chartInfo, out msg);
						switch (status)
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
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "���̓`���[�g�i�h�����_�E���j�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
						string msg;
						ChartInfo chartInfo;

						int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

						status = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out msg);

						switch (status)
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
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "���̓`���[�g�f�[�^�̎擾�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
				if (this._condtionClickChartList.ContainsKey(e.Number))
				{
					// ���̓`���[�g���Ǘ��N���X�擾
					IChartExtract iChartExtract = this._condtionClickChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						// �������͂t�h��ʕ\��
						int status = iChartExtract.ShowCondition(this, null);

						if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							string msg;
							ChartInfo chartInfo;

							// �`���[�g�p�����[�^�擾
							status = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out msg);
							switch (status)
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
										SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
										return;
									}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "�����ݒ�Ɏ��s���܂����B" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}
		#endregion

		#endregion

		#region Internal Method
		/// <summary>
		/// ���̓`���[�g�r���[�t�H�[�����Ǘ��N���X�N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���̓`���[�g�r���[�t�H�[�����Ǘ��N���X���N���A���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.05.15</br>
		/// </remarks>
		internal void Clear()
		{
			// ���̓`���[�g���Ǘ��N���X���X�g�N���A
			this.ClearAnalysisChartControlList();

			// ��ʏI��
			this.Close();
		}

		#region ���̓`���[�g���Ǘ��N���X���X�g�N���A����
		/// <summary>
		/// ���̓`���[�g���Ǘ��N���X���X�g�N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���̓`���[�g���Ǘ��N���X���X�g���N���A���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal void ClearAnalysisChartControlList()
		{
			if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
			{
				return;
			}

			//foreach (AnalysisChartControl analysisChartControl in this._chartExtractList)
			//{
			//  // ���̓`���[�g���Ǘ��N���X�N���A
			//  analysisChartControl.Clear();
			//}

			// ���̓`���[�g���Ǘ��N���X���X�g�N���A
			this._chartExtractList.Clear();
		}
		#endregion

		#region ���̓`���[�g�r���[�t�H�[���\������
		/// <summary>
		/// ���̓`���[�g�r���[�t�H�[���\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���̓`���[�g�r���[�t�H�[����\�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal void ShowMe(object paramater)
		{
			// ���o�����ݒ�
			this._extractObj = paramater;

			// ��ʕ\��
			this.Show();

			// �`���[�g���i�쐬
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
				this._chartLibrary.ConditionClick += new ConditionClickEventHandler(this.ConditionClick);
			}
			
			// ���̓`���[�g�f�[�^����
			if (this.CreateChartData(this._chartExtractList))
			{
				// ���̓`���[�g�p�����[�^���X�g�擾
				if (this.GetChartInfoList(this._chartExtractList))
				{
					// ���̓`���[�g�\��
					this.ShowChartData();
				}
			}
		}
		
		#endregion

		#endregion

		// ===================================================================================== //
		// Internal�C�x���g
		// ===================================================================================== //
		#region Internal event
		/// <summary>
		/// �c�[���o�[�\������C�x���g
		/// </summary>
		internal event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g
		// ===================================================================================== //
		#region control event
		/// <summary>
		/// Control.Activated�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : �t�H�[�����A�N�e�B�u�ɂ��ꂽ���ɔ������܂��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2007.03.06</br>
		/// </remarks>
		private void AnalysisChartViewForm_Activated(object sender, EventArgs e)
		{
			if (this.ParentToolbarSettingEvent != null)
				this.ParentToolbarSettingEvent(this);
		}
		#endregion
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
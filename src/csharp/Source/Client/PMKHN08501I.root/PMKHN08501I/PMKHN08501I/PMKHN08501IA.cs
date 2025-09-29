using System;
using System.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	#region ���@�}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʃC���^�[�t�F�[�X
	/// <summary>
	/// �}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 2009/05/12 �����</br>
    /// <br>             �G�N�X�|�[�g.�C���|�[�g�̒ǉ�</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChild
	{
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		void Show(object parameter);
	}
	#endregion
    
	#region ���@�}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
	/// <summary>
	/// �}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChildMain
	{
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		void Show(object parameter);
		
		/// <summary>
		/// ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// �f�[�^���o����
		/// </summary>
		/// <param name="printKind">���[���[1:�����ꗗ,2:���v������,3:���א�����]</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int ExtractData(int printKind);

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
        int Print(ref object parameter);
	
		/// <summary>
		/// ������ޕύX����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ������ޕύX���̏������s���܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		void ChangePrintType(int printType);
	}
	#endregion
	
	#region ���@�}�X�^�G�N�X�|�[�g�E�C���|�[�g���ActiveReportType�C���^�[�t�F�[�X
	/// <summary>
	/// �}�X�^�G�N�X�|�[�g�E�C���|�[�g���ActiveReportType�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandPrintActiveReportType
	{
		/// <summary>
		/// ����^�C�g��
		/// </summary>
		string Title
		{
			set;
		}
		
		/// <summary>
		/// ������p�����[�^�v���p�e�B
		/// </summary>
		SFCMN06002C PrintInfo
		{
			get;
			set;
		}
		
		/// <summary>
		/// ����p�����ݒ���ݒ�
		/// </summary>
		/// <param name="conditionInfo">�ݒ���I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����ɕK�v�ȏ����ݒ����ݒ肵�܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// ����p���ݒ菈��
		/// </summary>
		/// <param name="demandRelatedData">����p���I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ���ڃo�C���h���Ȃ�������ɕK�v�ȏ���ݒ肵�܂��B
		/// <br>Programer  : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion


    public interface IPrintConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        int Extract(ref object parameter);
        int Print(ref object parameter);
        bool PrintBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid);
        bool DataCheck();

        // Properties
        bool CanExtract { get; }
        bool CanPdf { get; }
        bool CanPrint { get; }
        bool VisibledExtractButton { get; }
        bool VisibledPdfButton { get; }
        bool VisibledPrintButton { get; }
    }


    public interface IPrintConditionInpTypePdfCareer
    {
        // Properties
        string PrintKey { get; }
        string PrintName { get; }
    }

    public interface IChartExtract
    {
        // Methods
        int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);
        int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);
        int MakeChartData(object sender, object parameter, out string msg);
        int ShowCondition(object sender, object parameter);

        // Properties
        ChartParamater ChartParamater { get; set; }
    }


    public class ChartParamater
    {
        // Fields
        private bool _isCondtnButton;
        private bool _isDrillDown;
        private string _paramater;

        // Methods
        public ChartParamater()
        {
        }

        // Properties
        public bool IsCondtnButton
        {
            get
            {
                return this._isCondtnButton;
            }
            set
            {
                this._isCondtnButton = value;
            }
        }


        public bool IsDrillDown
        {
            get
            {
                return this._isDrillDown;
            }
            set
            {
                this._isDrillDown = value;
            }
        }

        public string Paramater
        {
            get
            {
                return this._paramater;
            }
            set
            {
                this._paramater = value;
            }
        }
 
    }



	#region ���@�f���Q�[�g
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);

    public delegate void ParentToolbarSettingEventHandler(object sender);

	#endregion

    // --- ADD 2009/05/12 ------------------------------->>>>>
    /// <summary>
    /// �}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʁi�G�N�X�|�[�g�j�������̓��C����ʃC���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public interface IExportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        int Extract(ref object parameter);
        int GetCSVInfo(ref object parameter);
        bool ExportBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void AfterExportSuccess();
    }

    /// <summary>
    /// �}�X�^�G�N�X�|�[�g�E�C���|�[�gMDI�q��ʁi�C���|�[�g�j�������̓��C����ʃC���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public interface IImportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        void Show(object parameter);
        bool IsUseBaseCheck();
        string ImportFileName();
        bool ImportBeforeCheck();
        void CheckErrEvent();
        int Import(object csvDataList);
    }
    // --- ADD 2009/05/12 ------------------------------<<<<<
}

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Drawing;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���R���[(���Ϗ�)����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note         : ���R���[�̈���h�L�������g���쐬���܂��B</br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
    /// <br>Update Note  : 2010.03.10 22018 ���  ���b</br>
    /// <br>             : ��������̕s����C��</br>
    /// <br></br>
    /// </remarks>
	public class PMMIT08001PA : ISlipPrintProc
	{
		#region PrivateMember
        // --------------------------------------------------------
        // ������ ����f�[�^�n ������
        // --------------------------------------------------------
        // ����f�[�^
        private DataSet _ds;
        // ���R���[�󎚈ʒu�ݒ�}�X�^
        private FrePrtPSetWork _frePrtPSet;
        //// �������摜
        //private System.Drawing.Image _watermarkImage;
        // ���Ϗ����l�ݒ�}�X�^
        private EstimateDefSet _estimateDefSet;
        // �S�̏����\���ݒ�}�X�^
        private AllDefSetWork _allDefSet;

        // ������f�[�^�N���X�ޔ�p
        private List<EstFmUnitExtraData> _estFmUnitExtraDataList;
       

        // --------------------------------------------------------
        // ������ ����ݒ�f�[�^�n ������
        // --------------------------------------------------------
        // �`�[����ݒ�}�X�^
        private SlipPrtSetWork _slipPrtSet;
        // �`�[����ݒ�`�[�^�C�v�ʐݒ�
        private EachSlipTypeSet _eachSlipTypeSet;
        // �`�[����p�����[�^
        private SlipPrintParameter _slipPrintParameter;
        // �`�[��������N���X
        private SlipPrintConditionInfo _slipPrintConditionInfo;

        // --------------------------------------------------------
        // ������ ����h�L�������g ������
        // --------------------------------------------------------
        // �v���r���[�h�L�������g�N���X
        private Document _previewDocument;
        // ����h�L�������g�N���X
        private Document _printDocument;

        // --------------------------------------------------------
        // �������
        // --------------------------------------------------------
        private PMCMN02000CA _reportCtrl;

        #endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PMMIT08001PA()
		{
            _previewDocument = new Document();
            _printDocument = new Document();

            _reportCtrl = PMCMN02000CA.GetInstance();
            _reportCtrl.DoubleHeightTargetList = PMMIT08001PB.GetDoubleHeightTargetList();
		}
		#endregion

		#region ISlipPrintProc �����o
		/// <summary>
		/// ����h�L�������g�i�v���r���[�p�j
		/// </summary>
		public Document PreviewDocument
		{
			get { return _previewDocument; }
		}

		/// <summary>
		/// ����h�L�������g�i����p�j
		/// </summary>
		public Document PrintDocument
		{
			get { return _printDocument; }
		}

		/// <summary>
		/// ����p���擾����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="slipPrintConditionInfo">����ݒ���I�u�W�F�N�g</param>
		/// <param name="slipPrintData">������e���I�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����p�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int SetPrintConditionInfoAndData(object sender, SlipPrintConditionInfo slipPrintConditionInfo, object slipPrintData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			try
			{
				_slipPrintConditionInfo = slipPrintConditionInfo;

				// ����n�f�[�^�擾
				if (slipPrintData != null)
				{
                    // �ݒ�n�f�[�^�擾
                    if ( slipPrintConditionInfo != null )
                    {
                        ArrayList extrInfoList = (ArrayList)slipPrintConditionInfo.ExtrInfo;

                        foreach ( Object wkObj in extrInfoList )
                        {
                            // �`�[����ݒ�}�X�^
                            if ( wkObj is SlipPrtSetWork )
                            {
                                _slipPrtSet = (SlipPrtSetWork)wkObj;
                                _eachSlipTypeSet = new EachSlipTypeSet( _slipPrtSet );
                            }
                            // ���R���[�󎚈ʒu�ݒ�}�X�^
                            else if ( wkObj is FrePrtPSetWork )
                            {
                                _frePrtPSet = (FrePrtPSetWork)wkObj;
                            }
                            // ���Ϗ����l�ݒ�}�X�^
                            else if ( wkObj is EstimateDefSet )
                            {
                                _estimateDefSet = (EstimateDefSet)wkObj;
                            }
                            // �S�̏����\���ݒ�}�X�^
                            else if ( wkObj is AllDefSetWork )
                            {
                                _allDefSet = (AllDefSetWork)wkObj;
                            }
                            // �`�[����p�����[�^
                            else if ( wkObj is Dictionary<string, object> )
                            {
                                _slipPrintParameter = new SlipPrintParameter( (Dictionary<string, object>)wkObj );
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    if ( CheckExistsMasters() == false )
                    {
                        return -1;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    // ������C�A�E�g���擾
                    Dictionary<string, string> columnVisibleTypeDic;
                    GetLayoutInfo( _frePrtPSet, out columnVisibleTypeDic );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

                    // ����f�[�^�W�J
                    _ds = new DataSet();
                    _estFmUnitExtraDataList = new List<EstFmUnitExtraData>();
                    List<ArrayList> slipPrintDataList = (List<ArrayList>)slipPrintData;

                    for ( int index = 0; index < slipPrintDataList.Count; index++ )
                    {
                        ArrayList wkObj = slipPrintDataList[index];

                        FrePEstFmHead slipWork = (FrePEstFmHead)(wkObj as ArrayList)[0];
                        List<FrePEstFmDetail> detailWorks = (List<FrePEstFmDetail>)(wkObj as ArrayList)[1];
                        _estFmUnitExtraDataList.Add( (EstFmUnitExtraData)(wkObj as ArrayList)[2] );

                        // �f�[�^�W�J
                        DataTable table = PMMIT08001PB.CreateFrePEstFmHeadTable( index );
                        PMMIT08001PB.CopyToDataTable( ref table, slipWork, detailWorks, _slipPrtSet, _eachSlipTypeSet, _frePrtPSet, _slipPrintParameter, _estimateDefSet, _allDefSet, columnVisibleTypeDic );

                        _ds.Tables.Add( table );
                    }
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
				string message = "����p���擾�����ɂė�O���������܂����B"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP
					, ToString()
					, "���R���[���Ϗ����"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_PRINT
					, message
					, status
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				return -1;
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// ������C�A�E�g���擾
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, out Dictionary<string, string> columnVisibleTypeDic )
        {
            // ������
            columnVisibleTypeDic = new Dictionary<string, string>();

            if ( _frePrtPSet == null || _frePrtPSet.PrintPosClassData == null ) return;

            using ( MemoryStream stream = new MemoryStream( _frePrtPSet.PrintPosClassData ) )
            {
                // ���C�A�E�g����
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );

                // ���C�A�E�g���̎擾
                foreach ( DataDynamics.ActiveReports.Section section in prtRpt.Sections )
                {
                    foreach ( DataDynamics.ActiveReports.ARControl arControl in section.Controls )
                    {
                        if ( arControl is ar.TextBox && arControl.Tag is string )
                        {
                            // �yTag���̎擾�z
                            //   0: FreePrtPaperItemCd
                            //   1: PrintPageCtrlDivCd
                            //   2: GroupSuppressCd
                            //   3: DtlColorChangeCd
                            //   4: HeightAdjustDivCd);
                            string[] data = (arControl.Tag as String).Split( ',' );

                            // �����ꍀ�ڂ���������ꍇ�͍ŏ��Ƀq�b�g���������g�p����B
                            string dataFieldName = arControl.DataField.ToUpper();
                            if ( !columnVisibleTypeDic.ContainsKey( dataFieldName ) )
                            {
                                // �`�[����p�ɕύX����PrintPageCtrlDivCd���i�[
                                columnVisibleTypeDic.Add( dataFieldName, data[1] );
                            }
                        }
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckExistsMasters()
        {
            List<string> errorList = new List<string>();

            // �`�[����ݒ�}�X�^
            if ( _slipPrtSet == null )
            {
                errorList.Add( "�`�[����ݒ�" );
            }
            // ���R���[�󎚈ʒu�ݒ�}�X�^
            else if ( _frePrtPSet == null )
            {
                errorList.Add( "���R���[�󎚈ʒu�ݒ�" );
            }
            // ���Ϗ����l�ݒ�}�X�^
            else if ( _estimateDefSet == null )
            {
                errorList.Add( "���Ϗ����l�ݒ�" );
            }
            // �S�̏����\���ݒ�}�X�^
            else if ( _allDefSet == null )
            {
                errorList.Add( "�S�̏����\���ݒ�" );
            }


            if ( errorList.Count == 0 )
            {
                return true;
            }
            else
            {
                string errMsg = "�ȉ��̃}�X�^�o�^���e���s���ȈׁA����ł��܂���ł����B" + Environment.NewLine + Environment.NewLine;
                foreach ( string err in errorList )
                {
                    errMsg += string.Format( "  {0}{1}", err, Environment.NewLine );
                }
                errMsg += Environment.NewLine;

                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP
                    , ToString()
                    , "���Ϗ����"
                    , ""
                    , TMsgDisp.OPE_PRINT
                    , errMsg
                    , -1
                    , null
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1 );

                return false;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

		/// <summary>
		/// ����J�n�����i�v���r���[�����j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����������J�n���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartDirectPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(true);

			return status;
		}

		/// <summary>
		/// ����J�n�����iPDF�o�́j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: PDF�o�͏������J�n���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPdfPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}

		/// <summary>
		/// �v���r���[����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����������J�n���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPreview(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}

		/// <summary>
		/// ����J�n�����i�v���r���[�L��j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����������J�n���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPreviewPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����������s���܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private int StartPrint(bool isDirectPrint)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if ( _frePrtPSet == null || _frePrtPSet.PrintPosClassData == null ) return status;

            // ���|�[�g�h�L�������g������
            Document wkPrintDocument = new Document();
            _printDocument = new Document();
            _previewDocument = new Document();

            using ( MemoryStream stream = new MemoryStream( _frePrtPSet.PrintPosClassData ) )
			{
                //ar.ActiveReport3 prvRpt = null;
				ar.ActiveReport3 prtRpt = null;

                for ( int tableIndex = 0; tableIndex != _ds.Tables.Count; tableIndex++ )
                {
                    // ---------------------------------
                    // �ݒ�l�̎擾
                    // ---------------------------------
                    EstFmUnitExtraData extraData = _estFmUnitExtraDataList[tableIndex];

                    # region [�������]
                    int printCount;
                    // �`�[����ݒ�̕���
                    if ( _slipPrtSet.PrtCirculation > 0 )
                    {
                        printCount = _slipPrtSet.PrtCirculation;
                    }
                    else
                    {
                        printCount = 1;
                    }
                    // �������ς̕���
                    if ( extraData.PrintCount > 0 )
                    {
                        printCount *= extraData.PrintCount;
                    }
                    # endregion

                    // ---------------------------------
                    // ����pDocument�̐���
                    // ---------------------------------

                    // --- ADD m.suzuki 2010/03/10 ---------->>>>>
                    // "�S��","�����̂�","�D�ǂ̂�","�I�𕪂̂�"�̊e�^�C�v���ɏ���������
                    wkPrintDocument = new Document();
                    // --- ADD m.suzuki 2010/03/10 ----------<<<<<

                    // ����������J��Ԃ�
                    for ( int circulateCount = 0; circulateCount < printCount; circulateCount++ )
                    {
                        if ( circulateCount == 0 )
                        {
                            // ���ʖ������J��Ԃ�
                            for ( int copyCount = 0; copyCount < _slipPrtSet.CopyCount; copyCount++ )
                            {
                                prtRpt = new ar.ActiveReport3();
                                stream.Position = 0;
                                prtRpt.LoadLayout( stream );
                                SFANL08235CE.AddScriptReference( ref prtRpt );	// Script�p�Q�ƒǉ�
                                SetMargin( prtRpt );
                                SFANL08235CE.SetValidPaperKind( prtRpt );
                                _reportCtrl.SetReportProps( ref prtRpt ); // ���[���ʐݒ�
                                prtRpt.DataSource = _ds;
                                prtRpt.DataMember = _ds.Tables[tableIndex].TableName;
                                //prtRpt.DataSource = _ds.Tables[tableIndex];

                                # region [���y�[�W����]
                                DataDynamics.ActiveReports.GroupHeader topHeader;
                                try
                                {
                                    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                }
                                catch
                                {
                                    prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                }
                                topHeader.DataField = PMMIT08001PB.ct_PageCount;
                                topHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                                # endregion

                                // ���ʂɔ����t�B�[���h�ݒ�
                                SettingFieldInfoByCopying( ref prtRpt, copyCount, _ds.Tables[tableIndex] );

                                # region [�f�U�C���K�p]
                                // ���ו��f�U�C���K�p
                                ReflectDetailDesign( ref prtRpt, _ds.Tables[tableIndex] );
                                // ���v���f�U�C���K�p
                                ReflectSumDesign( ref prtRpt, _ds.Tables[tableIndex] );
                                # endregion

                                // ������s
                                prtRpt.Run();

                                // ����pDocument�ɂ܂Ƃ߂�
                                wkPrintDocument.Pages.AddRange( prtRpt.Document.Pages );

                                // �v���r���[�͈�������ɂ�炸��ɂP���̕������\������
                                if ( copyCount == 0 && circulateCount == 0 )
                                {
                                    _previewDocument.Pages.AddRange( prtRpt.Document.Pages );
                                }
                            }
                        }
                        _printDocument.Pages.AddRange( wkPrintDocument.Pages );
                    }
                }
                if ( prtRpt != null )
                {
                    SetPrinterInfo( _printDocument );

                    // �p���̎�ނ��w��
                    _printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    _previewDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                    if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                        _printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                    // �p�������i�c�E���j�̐ݒ�
                    if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                    {
                        _printDocument.Printer.Landscape = true;
                        _previewDocument.Printer.Landscape = true;
                    }
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/28 ADD
                // ���ڈ���̏ꍇ
                if ( isDirectPrint )
                {
                    _printDocument.Print( false, false, false );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/28 ADD

                stream.Close();
			}

			return status;
		}

        /// <summary>
        /// ���ʂɔ����t�B�[���h�ݒ菈��
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="copyCount"></param>
        /// <param name="dataTable"></param>
        /// <remarks>�`�[���ʂɂ��ω�����A�`�[�w�i�F�A�`�[�^�C�g���Ɋւ��鐧����s���܂��B�󎚍���CD=51�`100�ɑ΂��鏈���B</remarks>
        /// 
        private void SettingFieldInfoByCopying( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, int copyCount, DataTable dataTable )
        {
            //--------------------------------------------------------
            // �e�[�u�����̎擾
            //--------------------------------------------------------
            if ( dataTable.Rows.Count == 0 )
            {
                return;
            }

            // ���Ϗ��敪�擾
            EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );
            // �`�[�ԍ��擾
            string salesSlipNum = PMMIT08001PB.GetRowInfoSalesSlipNum( dataTable.Rows[0] );

            # region [���ʐF]
            Color backColor = GetBackColor( copyCount );
            Color backColorLight = MixColor( backColor, Color.FromArgb( 77, 70, 87 ), 0 );

            Color foreColor;
            // �w�i���Â��ꍇ�͕����𔒔����ɂ���
            if ( IsDark( backColor ) )
            {
                foreColor = Color.White;
            }
            else
            {
                foreColor = Color.Black;
            }
            # endregion

            foreach ( DataDynamics.ActiveReports.Section section in prtRpt.Sections )
            {
                foreach ( DataDynamics.ActiveReports.ARControl arControl in section.Controls )
                {
                    if ( arControl.Tag is string )
                    {
                        string tagSub = (arControl.Tag as string).Substring( 0, 3 );

                        # region [���ꍀ��(51�`100)]
                        switch ( tagSub )
                        {
                            case "51,":
                                {
                                    //-------------------------------------------
                                    // �u51:���ʐF�w�i�Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    DataDynamics.ActiveReports.Label label = (arControl as DataDynamics.ActiveReports.Label);
                                    label.BackColor = backColorLight;
                                    label.ForeColor = foreColor;
                                    // ��`�g�̐F�ݒ�
                                    label.Border.TopColor = backColor;
                                    label.Border.BottomColor = backColor;
                                    label.Border.LeftColor = backColor;
                                    label.Border.RightColor = backColor;
                                }
                                break;
                            case "52,":
                                {
                                    //-------------------------------------------
                                    // �u52:���ʐF�����v�̏ꍇ
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.Line).LineColor = backColor;
                                }
                                break;
                            case "53,":
                                {
                                    //-------------------------------------------
                                    // �u53:���ʐF�g���v�̏ꍇ
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.Shape).LineColor = backColor;
                                }
                                break;
                            case "54,":
                                {
                                    //-------------------------------------------
                                    // �u54:���ʐF�Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.TextBox).ForeColor = backColor;
                                }
                                break;
                            case "55,":
                                {
                                    //-------------------------------------------
                                    // �u55:���ʑΉ��`�[�^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    //(arControl as DataDynamics.ActiveReports.Label).Text = GetSlipTitle( copyCount );
                                    //(arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                    switch ( copyCount )
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle1;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle2;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle3;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle4;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "56,":
                            case "58,":
                                {
                                    //-------------------------------------------
                                    // 56:�i�ԃ^�C�g���A58:�i�ԗp����
                                    //-------------------------------------------
                                    // 0:�i�Ԉ󎚂��Ȃ�
                                    if ( _estimateDefSet.PartsNoPrtCd == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "57,":
                            case "59,":
                                {
                                    //-------------------------------------------
                                    // 57:�W�����i�^�C�g���A58:�W�����i�p����
                                    //-------------------------------------------
                                    // 0:�W�����i�󎚂��Ȃ�
                                    if ( _estimateDefSet.ListPricePrintDiv == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "65,":
                                {
                                    //-------------------------------------------
                                    // �u65:�����D�ǐ������v�̏ꍇ
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.All )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "66,":
                                {
                                    //-------------------------------------------
                                    // �u66:�����������v�̏ꍇ
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.Pure )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "67,":
                                {
                                    //-------------------------------------------
                                    // �u67:�D�ǐ������v�̏ꍇ
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.Prime )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "74,":
                                {
                                    //-------------------------------------------
                                    // �u74:���Џ��Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    if ( _slipPrtSet.EnterpriseNamePrtCd == 2 || _slipPrtSet.EnterpriseNamePrtCd == 3 )
                                    {
                                        // 2:�r�b�g�}�b�v�A�܂���3:�󎚂��Ȃ��A�Ȃ�Ύ��Џ��Œ蕶�����󎚂��Ȃ�
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "75,":
                                {
                                    //-------------------------------------------
                                    // �u75:�`�[�ԍ��^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    if ( string.IsNullOrEmpty( salesSlipNum ) )
                                    {
                                        // �`�[�ԍ����ݒ�Ȃ�Γ`�[�ԍ��^�C�g�����󎚂��Ȃ�
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        # endregion
                    }
                }
            }
        }
        # region [�`�[���ʑΉ�]
        /// <summary>
        /// ���ʑΉ��`�[�^�C�g���擾����
        /// </summary>
        /// <param name="copyCount"></param>
        /// <returns></returns>
        private string GetSlipTitle( int copyCount )
        {
            switch ( copyCount )
            {
                case 0:
                    return _slipPrtSet.TitleName1;
                case 1:
                    return _slipPrtSet.TitleName2;
                case 2:
                    return _slipPrtSet.TitleName3;
                case 3:
                    return _slipPrtSet.TitleName4;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �`�[�w�i�F�擾����
        /// </summary>
        /// <param name="copyCountIndex">���ʃy�[�Windex</param>
        /// <returns></returns>
        private Color GetBackColor( int copyCountIndex )
        {
            switch ( copyCountIndex )
            {
                case 0:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed1, _slipPrtSet.SlipBaseColorGrn1, _slipPrtSet.SlipBaseColorBlu1 );
                case 1:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed2, _slipPrtSet.SlipBaseColorGrn2, _slipPrtSet.SlipBaseColorBlu2 );
                case 2:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed3, _slipPrtSet.SlipBaseColorGrn3, _slipPrtSet.SlipBaseColorBlu3 );
                case 3:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed4, _slipPrtSet.SlipBaseColorGrn4, _slipPrtSet.SlipBaseColorBlu4 );
                case 4:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed5, _slipPrtSet.SlipBaseColorGrn5, _slipPrtSet.SlipBaseColorBlu5 );
                default:
                    return Color.Transparent;
            }
        }
        /// <summary>
        /// �F��������
        /// </summary>
        /// <param name="firstColor">��������Color�\����</param>
        /// <param name="secondColor">��������Color�\����</param>
        /// <param name="mixMode">�������[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �Q��Color�\���̂���ʂ�Color�\���̂��쐬���܂��B</br>
        /// <br>               �i���̏�����DC.NS���ʓ`�[����̎d�l�ɏ������Ă��܂��B�j</br>
        /// <br>Programmer   : 22018 ��؁@���b</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        private static Color MixColor( Color firstColor, Color secondColor, int mixMode )
        {
            switch ( mixMode )
            {
                case 0:
                    {
                        int redColor = firstColor.R + secondColor.R;
                        if ( redColor > 255 )
                        {
                            redColor = 255;
                        }
                        int greenColor = firstColor.G + secondColor.G;
                        if ( greenColor > 255 )
                        {
                            greenColor = 255;
                        }
                        int blueColor = firstColor.B + secondColor.B;
                        if ( blueColor > 255 )
                        {
                            blueColor = 255;
                        }

                        return Color.FromArgb( redColor, greenColor, blueColor );
                    }
            }
            return Color.Transparent;
        }
        /// <summary>
        /// �w�i�F�@���Ô���
        /// </summary>
        /// <param name="backColor"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>�i���̏�����DC.NS���ʓ`�[����̎d�l�ɏ������Ă��܂��B�j</br>
        /// </remarks>
        private static bool IsDark( Color backColor )
        {
            // ���肵�����l
            int divColorPoint = 200;

            if ( (int)backColor.R + (int)backColor.G + (int)backColor.B < divColorPoint )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region [���׃f�U�C���K�p]
        /// <summary>
        /// ���׃f�U�C���K�p
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dataTable"></param>
        private void ReflectDetailDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataTable dataTable )
        {
            try
            {
                //--------------------------------------------------------
                // �e�[�u�����̎擾
                //--------------------------------------------------------
                if ( dataTable.Rows.Count == 0 )
                {
                    return;
                }
                
                // ���Ϗ��敪�擾
                EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );

                // �I�v�V�����󎚋敪
                int optionPrintDivCd = _estimateDefSet.OptionPringDivCd;

//# if DEBUG
//                estFmDivState = EstFmDivState.All;
//                optionPrintDivCd = 1;
//                // ���������@GetFeedCount
//# endif

               
                //--------------------------------------------------------
                // ������C�A�E�g�ɑ΂��鐧��
                //--------------------------------------------------------

                // ���׃Z�N�V�����擾
                ar.Section detail = prtRpt.Sections["Detail1"];

                // ���׃f�U�C���p���x��
                ar.Label designDetail1 = null;
                ar.Label designDetail2 = null;
                ar.Label designDetail3 = null;

                // ���׃Z�N�V�����̃R���g���[���𒲍�
                foreach ( ar.ARControl control in detail.Controls )
                {
                    string tagText = (string)control.Tag;
                    tagText = tagText.Substring( 0, 3 );

                    switch ( tagText )
                    {
                        case "68,":
                            designDetail1 = (ar.Label)control;
                            break;
                        case "69,":
                            designDetail2 = (ar.Label)control;
                            break;
                        case "70,":
                            designDetail3 = (ar.Label)control;
                            break;
                        default:
                            break;
                    }
                }

                // �Ώۃf�[�^�t�B�[���h���X�g�擾
                List<string> detail1List = PMMIT08001PB.GetDesignDetail1List();
                List<string> detail2List = PMMIT08001PB.GetDesignDetail2List();
                List<string> detail3List = PMMIT08001PB.GetDesignDetail3List();

                if ( designDetail2 == null )
                {
                    // ���ׂQ�K�C�h�������ꍇ�͖��ׂP���X�g�Ɉڂ��Ė��ׂQ���X�g���N���A
                    detail1List.AddRange( detail2List );
                    detail2List.Clear();
                }
                if ( designDetail3 == null )
                {
                    // ���ׂR�K�C�h�������ꍇ�͖��ׂP���X�g�Ɉڂ��Ė��ׂR���X�g���N���A
                    detail1List.AddRange( detail3List );
                    detail3List.Clear();
                }

                if ( optionPrintDivCd > 0 )
                {
                    // �I�v�V����������P�F����
                    if ( estFmDivState == EstFmDivState.All )
                    {
                        //--------------------------------------------------------
                        // �����{�D�ǁ{�I�v�V����
                        // ������͕s�v
                        //--------------------------------------------------------
                    }
                    else
                    {
                        //--------------------------------------------------------
                        // ����or�D�ǁ{�I�v�V����
                        // ���D�ǂ������A�I�v�V��������Ɉړ��A���׋l�߂�
                        //--------------------------------------------------------
                        # region [����or�D�ǁ{�I�v�V����]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail2List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                                else if ( detail3List.Contains( dataField ) )
                                {
                                    control.Top = designDetail2.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;
                        
                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                            shaveHeight += designDetail2.Height;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                        }

                        // ���׏k������
                        CollapseDetail( prtRpt, shaveHeight );
                        # endregion
                    }
                }
                else
                {
                    // �I�v�V����������O�F���Ȃ�
                    if ( estFmDivState == EstFmDivState.All )
                    {
                        //--------------------------------------------------------
                        // �����{�D��
                        // ���I�v�V�����������A���׋l�߂�
                        //--------------------------------------------------------
                        # region [�����{�D��]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail3List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;

                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                            shaveHeight += designDetail3.Height;
                        }

                        // ���׏k������
                        CollapseDetail( prtRpt, shaveHeight );

                        # endregion
                    }
                    else
                    {
                        //--------------------------------------------------------
                        // ����or�D��
                        // ���I�v�V�����������A�D�ǂ������A���׋l�߂�
                        //--------------------------------------------------------
                        # region [����or�D��]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail3List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                                else if ( detail2List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;

                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                            shaveHeight += designDetail2.Height;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                            shaveHeight += designDetail3.Height;
                        }

                        // ���׏k������
                        CollapseDetail( prtRpt, shaveHeight );

                        # endregion
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// ���ׂ̈��k����
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="shaveHeight"></param>
        private void CollapseDetail( DataDynamics.ActiveReports.ActiveReport3 prtRpt, float shaveHeight )
        {
            ar.Section detail = prtRpt.Sections["Detail1"];

            // ���׃Z�N�V�����̃R���g���[���𒲍�
            foreach ( ar.ARControl control in detail.Controls )
            {
                if ( control is ar.Line || control is ar.Shape )
                {
                    if ( control.Top + control.Height > detail.Height - shaveHeight )
                    {
                        control.Height = (detail.Height - shaveHeight) - control.Top;
                    }
                }
            }
        }
        /// <summary>
        /// ���v�f�U�C���K�p
        /// </summary>
        /// <param name="prtRpt"></param>
        private void ReflectSumDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataTable dataTable )
        {
            try
            {
                //--------------------------------------------------------
                // �e�[�u�����̎擾
                //--------------------------------------------------------
                if ( dataTable.Rows.Count == 0 )
                {
                    return;
                }

                // ���Ϗ��敪�擾
                EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );
                // �ېŋ敪
                int consTaxLayMethod = PMMIT08001PB.GetRowInfoConsTaxLayMethod( dataTable.Rows[0] );

                //--------------------------------------------------------
                // ������C�A�E�g�ɑ΂��鐧��
                //--------------------------------------------------------

                // ���v�Z�N�V�����擾
                ar.Section fotter = prtRpt.Sections["GroupFooter1"];

                // ���v�f�U�C���p���x��
                ar.Label designSubtotal = null;
                ar.Label designTax = null;
                ar.Label designTotal = null;
                // ���v�p�g��
                ar.Shape designTotalShape = null;
                // ���v�^�C�g��
                ar.Label designSubtotalLabel = null;
                ar.Label designTaxLabel = null;
                ar.Label designTotalLabel = null;

                // ���v�Z�N�V�����̃R���g���[���𒲍�
                foreach ( ar.ARControl control in fotter.Controls )
                {
                    string tagText = (string)control.Tag;
                    tagText = tagText.Substring( 0, 3 );

                    switch ( tagText )
                    {
                        case "61,":
                            designTotalShape = (ar.Shape)control;
                            break;
                        case "62,":
                            designSubtotal = (ar.Label)control;
                            break;
                        case "63,":
                            designTax = (ar.Label)control;
                            break;
                        case "64,":
                            designTotal = (ar.Label)control;
                            break;
                        case "71,":
                            designSubtotalLabel = (ar.Label)control;
                            break;
                        case "72,":
                            designTaxLabel = (ar.Label)control;
                            break;
                        case "73,":
                            designTotalLabel = (ar.Label)control;
                            break;
                        default:
                            break;
                    }
                }

                // �Ώۃf�[�^�t�B�[���h���X�g�擾
                List<string> subTotalList = PMMIT08001PB.GetDesignSubTotalList();
                List<string> taxList = PMMIT08001PB.GetDesignTaxList();
                List<string> totalList = PMMIT08001PB.GetDesignTotalList();
                List<string> primeList = PMMIT08001PB.GetDesignTotalPrimeList();

                if ( estFmDivState == EstFmDivState.All )
                {
                    //--------------------------------------------------------
                    // �����{�D��
                    // ������s�v
                    //--------------------------------------------------------
                }
                else
                {
                    //--------------------------------------------------------
                    // ����or�D��
                    // ���D�ǂ������A���v�g�l�߂�
                    //--------------------------------------------------------
                    # region [����or�D��]
                    foreach ( ar.ARControl control in fotter.Controls )
                    {
                        if ( control is ar.TextBox )
                        {
                            string dataField = control.DataField.ToUpper();

                            // �D�ǂ�����
                            if ( primeList.Contains( dataField ) )
                            {
                                control.Visible = false;
                            }

                            // ���v���ړ�
                            if ( designSubtotal != null && subTotalList.Contains( dataField ) )
                            {
                                control.Top = designSubtotal.Top;
                            }
                            // �ł��ړ�
                            else if ( designTax != null && taxList.Contains( dataField ) )
                            {
                                control.Top = designTax.Top;
                            }
                            // ���v���ړ�
                            else if ( designTotal != null && totalList.Contains( dataField ) )
                            {
                                control.Top = designTotal.Top;
                            }
                        }
                    }
                    // ���v���g���̍����𔼕��ɂ���
                    if ( designTotalShape != null )
                    {
                        designTotalShape.Height = designTotalShape.Height / 2;
                    }
                    // ���v�^�C�g���̈ʒu��ύX
                    if ( designSubtotalLabel != null && designSubtotalLabel != null )
                    {
                        designSubtotalLabel.Top -= designSubtotal.Top;
                    }
                    // �Ń^�C�g���̈ʒu��ύX
                    if ( designTaxLabel != null && designTax != null )
                    {
                        designTaxLabel.Top -= designTax.Top;
                    }
                    // ���v�^�C�g���̈ʒu��ύX
                    if ( designTotalLabel != null && designTotal != null )
                    {
                        designTotalLabel.Top -= designTotal.Top;
                    }
                    # endregion
                }

                // ����Ń^�C�g���E���v�^�C�g�����
                # region [����Ń^�C�g���E���v�^�C�g�����]
                bool totalPrintEnable = true;
                bool taxPrintEnable = true;
                // ����ŋ敪 0:����@1:���Ȃ�
                if ( _estimateDefSet.ConsTaxPrintDiv == 0 )
                {
                    // �]�ŕ����@0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�
                    switch ( consTaxLayMethod )
                    {
                        case 0:
                        case 1:
                            {
                            }
                            break;
                        case 2:
                        case 3:
                            {
                                totalPrintEnable = false;
                            }
                            break;
                        case 9:
                        default:
                            {
                                totalPrintEnable = false;
                                taxPrintEnable = false;
                            }
                            break;
                    }
                }
                else
                {
                    totalPrintEnable = false;
                    taxPrintEnable = false;
                }
                // ����Ń^�C�g��
                if ( taxPrintEnable == false )
                {
                    if ( designTaxLabel != null ) designTaxLabel.Visible = false;
                }
                // ���v�^�C�g��
                if ( totalPrintEnable == false )
                {
                    if ( designTotalLabel != null ) designTotalLabel.Visible = false;
                }
                # endregion
            }
            catch
            {
            }
        }
        # endregion

        /// <summary>
		/// �]���ݒ菈��
		/// </summary>
		/// <param name="rpt">�A�N�e�B�u���|�[�g�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note		: �]���ݒ�����܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private void SetMargin(ar.ActiveReport3 rpt)
		{
			// ��̗]����ݒ�
			rpt.PageSettings.Margins.Top
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.TopMargin);
			// ���̗]����ݒ�
			rpt.PageSettings.Margins.Bottom
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.BottomMargin);
			// ���̗]����ݒ�
			rpt.PageSettings.Margins.Left
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.LeftMargin);
			// �E�̗]����ݒ�
			rpt.PageSettings.Margins.Right
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.RightMargin);
		}

		/// <summary>
		/// �v�����^�[���Z�b�g����
		/// </summary>
		/// <param name="document">���|�[�gDocument</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �v�����^�[����ݒ肵�܂��B</br>
		/// <br>Programmer	: 22018 ��؁@���b</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private void SetPrinterInfo(Document document)
		{
			// �g�p�v�����^�[�̐ݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //foreach (string wkStr in PrinterSettings.InstalledPrinters)
            //{
            //    if (wkStr.Equals(_slipPrintConditionInfo.PrinterName))
            //    {
            //        document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

			// �g�p�v�����^�̗L���L���`�F�b�N�i�L���ł͖����ꍇ�͉��z�v�����^���g�p�j
			if (!document.Printer.PrinterSettings.IsValid)
				document.Printer.PrinterSettings.PrinterName = string.Empty;
		}
		#endregion
	}

    # region ���@�`�[����p�����[�^�\���́@��
    /// <summary>
    /// �`�[����p�����[�^�\����
    /// </summary>
    /// <remarks>
    /// <br>���f�[�^�N���X�̃����o�Ƃ��đ��݂��Ȃ��f�[�^��</br>
    /// <br>�@����c�k�k�Ɏ󂯓n���ׂ̍\���̂ł��B</br>
    /// <br>��object�̃f�B�N�V���i���Ƃ̑��ݕϊ��@�\�������܂��B</br>
    /// </remarks>
    internal struct SlipPrintParameter
    {
        /// <summary>���t�󎚗L��(0:���Ȃ�/1:����)</summary>
        private int _slipDatePrintDiv;
        /// <summary>���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)</summary>
        private int _totalPricePrtCd;
        /// <summary>�Ĕ��s�敪</summary>
        private bool _reissueDiv;
        /// <summary>
        /// ���t�󎚗L��(0:���Ȃ�/1:����)
        /// </summary>
        public int SlipDatePrintDiv
        {
            get { return _slipDatePrintDiv; }
            set { _slipDatePrintDiv = value; }
        }
        /// <summary>
        /// ���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)
        /// </summary>
        public int TotalPricePrtCd
        {
            get { return _totalPricePrtCd; }
            set { _totalPricePrtCd = value; }
        }
        /// <summary>
        /// �Ĕ��s�敪
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="slipDatePrintDiv">���t�󎚗L��(0:���Ȃ�/1:����)</param>
        /// <param name="totalPricePrtCd">���v���z��(0:�S��/1:�擪�̂�/2:�ŏI�̂�)</param>
        /// <param name="reissueDiv">�Ĕ��s�敪</param>
        public SlipPrintParameter( int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv )
        {
            _slipDatePrintDiv = slipDatePrintDiv;
            _totalPricePrtCd = totalPricePrtCd;
            _reissueDiv = reissueDiv;
        }
        /// <summary>
        /// �R���X�g���N�^ (object�̃f�B�N�V���i�����)
        /// </summary>
        /// <param name="objectDictionary"></param>
        public SlipPrintParameter( Dictionary<string, object> objectDictionary )
        {
            // �����l��ݒ�
            _slipDatePrintDiv = 1;
            _totalPricePrtCd = 0;
            _reissueDiv = false;

            // �n���ꂽList�̓��e���i�[
            if ( objectDictionary != null )
            {
                if ( objectDictionary.ContainsKey( "SlipDatePrintDiv" ) && objectDictionary["SlipDatePrintDiv"] is int )
                {
                    _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                }
                if ( objectDictionary.ContainsKey( "TotalPricePrtCd" ) && objectDictionary["TotalPricePrtCd"] is int )
                {
                    _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                }
                if ( objectDictionary.ContainsKey( "ReissueDiv" ) && objectDictionary["ReissueDiv"] is bool )
                {
                    _reissueDiv = (bool)objectDictionary["ReissueDiv"];
                }
            }
        }
        /// <summary>
        /// �f�B�N�V���i���֕ϊ�
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            // �����o���f�B�N�V���i���Ɋi�[
            Dictionary<string, object> objectDic = new Dictionary<string, object>();
            objectDic.Add( "SlipDatePrintDiv", _slipDatePrintDiv );
            objectDic.Add( "TotalPricePrtCd", _totalPricePrtCd );
            objectDic.Add( "ReissueDiv", _reissueDiv );

            // Dictionary��Ԃ�
            return objectDic;
        }
    }
    # endregion ���@�`�[����p�����[�^�\���́@��

    # region [�`�[�^�C�v�ʐݒ�]
    /// <summary>
    /// �`�[�^�C�v�ʐݒ�
    /// </summary>
    /// <remarks>�`�[����ݒ�́u�`�[�^�C�v�ʐݒ�v���`�E�擾���܂��B2009.01.19���g�p</remarks>
    internal struct EachSlipTypeSet
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="slipPrtSetWork"></param>
        public EachSlipTypeSet( SlipPrtSetWork slipPrtSetWork )
        {
        }
    }
    # endregion

}

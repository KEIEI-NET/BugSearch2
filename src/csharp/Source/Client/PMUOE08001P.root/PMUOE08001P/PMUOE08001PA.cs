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
    /// ���R���[(�t�n�d�`�[)����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���R���[�̈���h�L�������g���쐬���܂��B</br>
    /// <br>               (����`�[���x�[�X�ɍ쐬)</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note  : ���m�@2009.07.24 �I�[�g�o�b�N�X�Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 ��� ���b</br>
    /// <br>             : �p�q�R�[�h�̈���@�\��ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/17  22018 ��� ���b</br>
    /// <br>             : �T�u���|�[�g�@�\�̒ǉ��B�i�X�암�i�ʑΉ��ׁ̈j</br>
    /// <br></br>
    /// <br>Update Note  : 2011/05/27  30517 �Ė� �x��</br>
    /// <br>             : �����I�[�g�p�[�c�ʑΉ�</br>
    /// <br>             : ���ꍀ�ڂ̒ǉ��i�ԑ�ԍ����e����(���͎��̂�)�j</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 �����     �A��985</br>
    /// <br>             �@�yPM�v�]����9���z�M���zRedmine#23541 �A��985�̑Ή�</br> 
    /// <br></br>
    /// </remarks>
    public class PMUOE08001PA : ISlipPrintProc
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

        // --------------------------------------------------------
        // ������ ����ݒ�f�[�^�n ������
        // --------------------------------------------------------
        // �`�[����ݒ�}�X�^
        private SlipPrtSetWork _slipPrtSet;
        // �`�[����ݒ�`�[�^�C�v�ʐݒ�
        private EachSlipTypeSet _eachSlipTypeSet;
        // ����S�̐ݒ�}�X�^
        private SalesTtlStWork _salesTtlSt;
        // �S�̏����\��
        private AllDefSetWork _allDefSet;
        // �`�[����p�����[�^
        private SlipPrintParameter _slipPrintParameter;
        // �`�[��������N���X
        private SlipPrintConditionInfo _slipPrintConditionInfo;
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        // �T�u���|�[�g�f�B�N�V���i��
        private Dictionary<string, ar.ActiveReport3> _subReportDic;
        // ���R���[�󎚈ʒu�ݒ�f�B�N�V���i��
        private Dictionary<string, FrePrtPSetWork> _frePrtPSetDic;
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

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
        public PMUOE08001PA()
        {
            _previewDocument = new Document();
            _printDocument = new Document();

            _reportCtrl = PMCMN02000CA.GetInstance();
            _reportCtrl.DoubleHeightTargetList = PMUOE08001PB.GetDoubleHeightTargetList();
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
        /// <br>Date		: 2008.11.18</br>
        /// <br>Update Note : 2011/08/15 �����</br>
        /// <br>             �yPM�v�]����9���z�M���zRedmine#23541 �A��985�̑Ή�</br> 
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
                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    _frePrtPSetDic = null;
                    Dictionary<string, bool> decryptedFrePrtPSetDic = null;
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // �ݒ�n�f�[�^�擾
                    # region [�ݒ�n�f�[�^�擾]
                    if (slipPrintConditionInfo != null)
                    {
                        ArrayList extrInfoList = (ArrayList)slipPrintConditionInfo.ExtrInfo;

                        foreach (Object wkObj in extrInfoList)
                        {
                            // �`�[����ݒ�}�X�^
                            if (wkObj is SlipPrtSetWork)
                            {
                                _slipPrtSet = (SlipPrtSetWork)wkObj;
                                _eachSlipTypeSet = new EachSlipTypeSet(_slipPrtSet);
                            }
                            // ���R���[�󎚈ʒu�ݒ�}�X�^
                            else if (wkObj is FrePrtPSetWork)
                            {
                                _frePrtPSet = (FrePrtPSetWork)wkObj;
                            }
                            // ����S�̐ݒ�}�X�^
                            else if (wkObj is SalesTtlStWork)
                            {
                                _salesTtlSt = (SalesTtlStWork)wkObj;
                            }
                            // �S�̏����\���ݒ�}�X�^
                            else if (wkObj is AllDefSetWork)
                            {
                                _allDefSet = (AllDefSetWork)wkObj;
                            }
                            // �`�[����p�����[�^
                            else if (wkObj is Dictionary<string, object>)
                            {
                                _slipPrintParameter = new SlipPrintParameter((Dictionary<string, object>)wkObj);
                            }
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            // ���R���[�󎚈ʒu�ݒ�f�B�N�V���i��
                            else if ( wkObj is Dictionary<string, FrePrtPSetWork> )
                            {
                                _frePrtPSetDic = (Dictionary<string, FrePrtPSetWork>)wkObj;
                            }
                            // �������ςݎ��R���[�󎚈ʒu�ݒ�f�B�N�V���i��
                            else if ( wkObj is Dictionary<string, bool> )
                            {
                                decryptedFrePrtPSetDic = (Dictionary<string, bool>)wkObj;
                            }
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        }
                    }

                    if (CheckExistsMasters() == false)
                    {
                        return -1;
                    }
                    # endregion

                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    //// ������C�A�E�g���擾
                    //Dictionary<string, string> columnVisibleTypeDic;
                    //Dictionary<string, string> titleDic;
                    //GetLayoutInfo(_frePrtPSet, out columnVisibleTypeDic, out titleDic);
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                    // ������C�A�E�g���擾
                    Dictionary<string, string> columnVisibleTypeDic = new Dictionary<string, string>();
                    Dictionary<string, string> titleDic = new Dictionary<string, string>();
                    GetLayoutInfo( _frePrtPSet, ref columnVisibleTypeDic, ref titleDic );
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    // �T�u���|�[�g�f�B�N�V���i���X�V�ikey�ɍ��v����Report���擾���Ċi�[����j
                    ReflectSubReportDic( ref _subReportDic, _frePrtPSetDic, decryptedFrePrtPSetDic, ref columnVisibleTypeDic, ref titleDic );
                    _reportCtrl.SubReportDic = _subReportDic;
                    _reportCtrl.SubReportTargetList = new List<string>( new string[] { "FREEPRINT.SUBREPORT" } );
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // ����f�[�^�W�J
                    _ds = new DataSet();
                    List<ArrayList> slipPrintDataList = (List<ArrayList>)slipPrintData;
                    int index = 0;

                    foreach (ArrayList wkObj in slipPrintDataList)
                    {
                        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                        //// �e�[�u���X�L�[������
                        //DataTable table = PMUOE08001PB.CreateFrePSalesSlipTable(index);

                        //FrePSalesSlipWork slipWork = (FrePSalesSlipWork)( wkObj as ArrayList )[0];
                        //List<FrePSalesDetailWork> detailWorks = (List<FrePSalesDetailWork>)( wkObj as ArrayList )[1];
                        //UoeSales uoeSales = (UoeSales)( wkObj as ArrayList )[2];

                        //// �f�[�^�W�J
                        //PMUOE08001PB.CopyToDataTable(ref table, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic);

                        //_ds.Tables.Add(table);
                        //index++;

                        List<DataTable> tables = new List<DataTable>();
                        FrePSalesSlipWork slipWork = (FrePSalesSlipWork)(wkObj as ArrayList)[0];
                        List<FrePSalesDetailWork> detailWorks = (List<FrePSalesDetailWork>)(wkObj as ArrayList)[1];
                        UoeSales uoeSales = (UoeSales)(wkObj as ArrayList)[2];

                        // �f�[�^�W�J
                        // --- UPD ����� 2011/08/15---------->>>>>
                        //PMUOE08001PB.CopyToDataTable( ref tables, ref index, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic );
                        PMUOE08001PB.CopyToDataTable(ref tables, ref index, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic, this._subReportDic);
                        // --- UPD ����� 2011/08/15----------<<<<<
                        
                        _ds.Tables.AddRange( tables.ToArray() );
                        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
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
                    , "���R���[�`�[���"
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
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// �T�u���|�[�g�f�B�N�V���i���X�V����
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        /// <param name="decryptedFrePrtPSetDic"></param>
        private void ReflectSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic, Dictionary<string, bool> decryptedFrePrtPSetDic, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string, string> titleDic )
        {
            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null || decryptedFrePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, DataDynamics.ActiveReports.ActiveReport3> newDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                if ( !decryptedFrePrtPSetDic.ContainsKey( key ) )
                {
                    // �܂����������Ă��Ȃ��˕���������
                    FrePrtSettingController.DecryptPrintPosClassData( pSetWork );
                    decryptedFrePrtPSetDic.Add( key, true );
                }

                // ���C�A�E�g���擾����
                GetLayoutInfo( pSetWork, ref columnVisibleTypeDic, ref titleDic );

                // ���|�[�g��񂩂烌�C�A�E�g���𕜌�����
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // ���C�A�E�g����
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // �X�N���v�g�N���A
                    prtRpt.Script = string.Empty;

                    // �f�B�N�V���i���ɒǉ�
                    newDic.Add( key, prtRpt );
                }
            }

            // �f�B�N�V���i���������ւ���
            subReportDic = newDic;
        }
        /// <summary>
        /// �T�u���|�[�g�f�B�N�V���i���Đ�������
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        private void RenewSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic )
        {
            //--------------------------------------------
            // ���y�[�W�ؑցA���ʐؑւ̍ۂɃ��C���̃��|�[�g��
            //   �C���X�^���X�͍�蒼���Ă���̂ŁA
            //   ����Ɋ֘A�t����T�u���|�[�g��
            //   �C���X�^���X����蒼���K�v������B
            //--------------------------------------------

            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, ar.ActiveReport3> newDic = new Dictionary<string, ar.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                // ���|�[�g��񂩂烌�C�A�E�g���𕜌�����
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // ���C�A�E�g����
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // �X�N���v�g�N���A
                    prtRpt.Script = string.Empty;

                    // �f�B�N�V���i���ɒǉ�
                    newDic.Add( key, prtRpt );
                }
            }

            // �f�B�N�V���i���������ւ���
            subReportDic = newDic;
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// ������C�A�E�g���擾
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <param name="columnVisibleTypeDic"></param>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //private void GetLayoutInfo(FrePrtPSetWork frePrtPSet, out Dictionary<string, string> columnVisibleTypeDic, out Dictionary<string, string> titleDic)
        private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string, string> titleDic )
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        {
            // ������
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //columnVisibleTypeDic = new Dictionary<string, string>();
            //titleDic = new Dictionary<string, string>();
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            //Dictionary<string, string> reportItemDic = new Dictionary<string, string>();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
            if ( columnVisibleTypeDic == null )
            {
                columnVisibleTypeDic = new Dictionary<string, string>();
            }
            if ( titleDic == null )
            {
                titleDic = new Dictionary<string, string>();
            }
            Dictionary<string, string> reportItemDic = PMUOE08001PB.ReportItemDic;
            if ( reportItemDic == null )
            {
                reportItemDic = new Dictionary<string, string>();
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<

            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //if (_frePrtPSet == null || _frePrtPSet.PrintPosClassData == null) return;
            // 
            //using (MemoryStream stream = new MemoryStream(_frePrtPSet.PrintPosClassData))

            if ( frePrtPSet == null || frePrtPSet.PrintPosClassData == null ) return;

            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            {
                // ���C�A�E�g����
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout(stream);

                // ���C�A�E�g���̎擾
                foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
                {
                    foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                    {
                        if (arControl is ar.TextBox && arControl.Tag is string)
                        {
                            // �yTag���̎擾�z
                            //   0: FreePrtPaperItemCd
                            //   1: PrintPageCtrlDivCd
                            //   2: GroupSuppressCd
                            //   3: DtlColorChangeCd
                            //   4: HeightAdjustDivCd);
                            string[] data = ( arControl.Tag as String ).Split(',');

                            // �����ꍀ�ڂ���������ꍇ�͍ŏ��Ƀq�b�g���������g�p����B
                            string dataFieldName = arControl.DataField.ToUpper();
                            if (!columnVisibleTypeDic.ContainsKey(dataFieldName))
                            {
                                // �`�[����p�ɕύX����PrintPageCtrlDivCd���i�[
                                columnVisibleTypeDic.Add(dataFieldName, data[1]);
                            }

                            // ����Ń��x���e�L�X�g�ޔ�
                            if (( arControl.Tag as String ).StartsWith("67,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_TaxTitle))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_TaxTitle, ( arControl as ar.Label ).Text);
                                }
                            }
                            // ���v���x���e�L�X�g�ޔ�
                            if (( arControl.Tag as String ).StartsWith("68,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_SubTotalTitle))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_SubTotalTitle, ( arControl as ar.Label ).Text);
                                }
                            }
                            // ��M�������x���e�L�X�g�ޔ�
                            if (( arControl.Tag as String ).StartsWith("69,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ReceiveTimeLabel))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ReceiveTimeLabel, ( arControl as ar.Label ).Text);
                                }
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
                            // ���|�[�g���ڃf�B�N�V���i���ɒǉ�
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD

                            // --- ADD 2009.07.24 ���m ---------->>>>>
                            // �o�א��}�C�i�X���� ���x���e�L�X�g�ޔ�
                            //if ("DADD.SHIPMENTCNTMINUSSIGNRF".Equals(dataFieldName))
                            if (( arControl.Tag as String ).StartsWith("40,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ShipmentCntMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ShipmentCntMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // ������z�i�Ŕ����j������z�}�C�i�X���� �e�L�X�g�ޔ�
                            if (( arControl.Tag as String ).StartsWith("41,"))
                            //if ("DADD.SALESMONEYTAXEXCMINUSSIGNRF".Equals(dataFieldName))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_SalesMoneyTaxExcMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_SalesMoneyTaxExcMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // AB�{���������z�}�C�i�X���� ���x���e�L�X�g�ޔ�
                            if (( arControl.Tag as String ).StartsWith("42,"))
                            //if ("DADD.ABHQSALESUNITCOSTMINUSSIGNRF".Equals(dataFieldName))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ABHqSalesUnitCostMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ABHqSalesUnitCostMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // --- ADD 2009.07.24 ���m ----------<<<<<
                        }
                        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                        else if ( arControl is ar.Barcode )
                        {
                            string dataFieldName = (arControl as ar.Barcode).DataField.ToUpper();

                            // ���|�[�g���ڃf�B�N�V���i���ɒǉ�
                            if ( !reportItemDic.ContainsKey( dataFieldName ) )
                            {
                                reportItemDic.Add( dataFieldName, dataFieldName );
                            }
                        }
                        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        else if ( arControl is ar.Label )
                        {
                            ar.Label label = (arControl as ar.Label);
                            const string subReportDataField = "FREEPRINT.SUBREPORT";

                            // �T�u���|�[�g�@�\�̔���
                            if ( arControl.DataField == subReportDataField )
                            {
                                // Text���J���}�ŋ�؂�B
                                string formName = label.Text.Split( ',' )[0];

                                if ( _subReportDic == null )
                                {
                                    _subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                                }

                                if ( !_subReportDic.ContainsKey( formName ) )
                                {
                                    // �T�u���|�[�g�f�B�N�V���i���ɒǉ��ivalue�ƂȂ�Report�͌�œǂݍ���ŃZ�b�g����j
                                    _subReportDic.Add( formName, null );

                                    // ���|�[�g���ڃf�B�N�V���i���ɒǉ�
                                    if ( !reportItemDic.ContainsKey( subReportDataField ) )
                                    {
                                        reportItemDic.Add( subReportDataField, subReportDataField );
                                    }
                                }
                            }
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                    }
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
            PMUOE08001PB.ReportItemDic = reportItemDic;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
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
            if (_slipPrtSet == null)
            {
                errorList.Add("�`�[����ݒ�");
            }
            // ���R���[�󎚈ʒu�ݒ�}�X�^
            else if (_frePrtPSet == null)
            {
                errorList.Add("���R���[�󎚈ʒu�ݒ�");
            }
            // ����S�̐ݒ�}�X�^
            else if (_salesTtlSt == null)
            {
                errorList.Add("����S�̐ݒ�");
            }
            // �S�̏����\���ݒ�}�X�^
            else if (_allDefSet == null)
            {
                errorList.Add("�S�̏����\���ݒ�");
            }

            if (errorList.Count == 0)
            {
                return true;
            }
            else
            {
                string errMsg = "�ȉ��̃}�X�^�o�^���e���s���ȈׁA����ł��܂���ł����B" + Environment.NewLine + Environment.NewLine;
                foreach (string err in errorList)
                {
                    errMsg += string.Format("  {0}{1}", err, Environment.NewLine);
                }
                errMsg += Environment.NewLine;

                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP
                    , ToString()
                    , "���R���[�`�[���"
                    , ""
                    , TMsgDisp.OPE_PRINT
                    , errMsg
                    , -1
                    , null
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);

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
        /// <br>Date		: 2008.11.18</br>
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
        /// <br>Date		: 2008.11.18</br>
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
        /// <br>Date		: 2008.11.18</br>
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
        /// <br>Date		: 2008.11.18</br>
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
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        private int StartPrint(bool isDirectPrint)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (_frePrtPSet == null || _frePrtPSet.PrintPosClassData == null) return status;

            // ���|�[�g�h�L�������g������
            _printDocument = new Document();
            _previewDocument = new Document();

            using (MemoryStream stream = new MemoryStream(_frePrtPSet.PrintPosClassData))
            {
                //ar.ActiveReport3 prvRpt = null;
                ar.ActiveReport3 prtRpt = null;

                for (int tableIndex = 0; tableIndex < _ds.Tables.Count; tableIndex++)
                {
                    // ---------------------------------
                    // ����pDocument�̐���
                    // ---------------------------------

                    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                    // QR���ނ̈󎚃T�C�Y�ݒ�
                    _reportCtrl.QrCodeSizeDic = PMUOE08001PB.GetQRCodeSizeDictionary( _ds.Tables[tableIndex], _frePrtPSet.FormFeedLineCount );
                    // --- ADD m.suzuki 2010/03/24 ----------<<<<<

                    // ����������J��Ԃ�
                    for (int circulateCount = 0; circulateCount < _slipPrtSet.PrtCirculation; circulateCount++)
                    {
                        // ���ʖ������J��Ԃ�
                        for (int copyCount = 0; copyCount < _slipPrtSet.CopyCount; copyCount++)
                        {
                            prtRpt = new ar.ActiveReport3();
                            stream.Position = 0;
                            prtRpt.LoadLayout(stream);
                            // --- DEL m.suzuki 2010/03/24 ---------->>>>>
                            //# if false
                            //if ( circulateCount == 0 && copyCount == 0)
                            //{
                            //    prtRpt.SaveLayout( "d:\\PMUOE08001P.dat" );
                            //}
                            //# endif
                            // --- DEL m.suzuki 2010/03/24 ----------<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                            //SFANL08235CE.AddScriptReference( ref prtRpt );	// Script�p�Q�ƒǉ�
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                            // ���R���[�W���̃X�N���v�g�𖳌�������
                            prtRpt.Script = string.Empty;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD
                            SetMargin(prtRpt);
                            SetPrinterInfo(prtRpt.Document);
                            SFANL08235CE.SetValidPaperKind(prtRpt);
                            _reportCtrl.SetReportProps(ref prtRpt); // ���[���ʐݒ�
                            prtRpt.DataSource = _ds;
                            prtRpt.DataMember = _ds.Tables[tableIndex].TableName;

                            # region [����y�[�W���R�s�[����]
                            DataDynamics.ActiveReports.GroupHeader topHeader;
                            try
                            {
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            catch
                            {
                                prtRpt.Sections.Add(DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1");
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            topHeader.DataField = PMUOE08001PB.ct_InPageCopyCount;
                            topHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                            # endregion

                            // ���ʓ��ɔ����t�B�[���h�ݒ�
                            SettingFieldInfoByTag(ref prtRpt, copyCount, _ds.Tables[tableIndex]);
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            # region [�T�u���|�[�g�ɂ��K�p]
                            // �T�u���|�[�g���̍č쐬
                            if ( tableIndex != 0 || circulateCount != 0 || copyCount != 0 )
                            {
                                RenewSubReportDic( ref _subReportDic, _frePrtPSetDic );
                                _reportCtrl.SubReportDic = _subReportDic;
                            }
                            // �T�u���|�[�g�ɋ��ʏ����K�p
                            foreach ( string key in _reportCtrl.SubReportDic.Keys )
                            {
                                ar.ActiveReport3 subReport = _reportCtrl.SubReportDic[key];
                                _reportCtrl.SetReportProps( ref subReport );
                                SettingFieldInfoByTag( ref subReport, copyCount, _ds.Tables[tableIndex] );
                            }
                            # endregion
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                            // ������s
                            prtRpt.Run();

                            // ����pDocument�ɂ܂Ƃ߂�
                            _printDocument.Pages.AddRange(prtRpt.Document.Pages);

                            // �v���r���[�͈�������ɂ�炸��ɂP���̕������\������
                            if (circulateCount == 0 && copyCount == 0)
                            {
                                _previewDocument.Pages.AddRange(prtRpt.Document.Pages);
                            }
                        }
                    }
                }
                if (prtRpt != null)
                {
                    SetPrinterInfo(_printDocument);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                    _previewDocument.Printer.PrinterName = _printDocument.Printer.PrinterName;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD

                    // �p���̎�ނ��w��
                    _printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    _previewDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                    if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                    {
                        _printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                        _previewDocument.Printer.PaperSize = _printDocument.Printer.PaperSize;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
                    }
                    // �p�������i�c�E���j�̐ݒ�
                    if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                    {
                        _printDocument.Printer.Landscape = true;
                        _previewDocument.Printer.Landscape = true;
                    }
                }

                // ���ڈ���̏ꍇ
                if (isDirectPrint)
                {
                    _printDocument.Print(false, false, false);
                }

                stream.Close();
            }

            return status;
        }


        /// <summary>
        /// ���ʓ��ɔ����t�B�[���h�ݒ菈��
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="copyCount"></param>
        /// <param name="dataTable"></param>
        /// <remarks>�󎚍���CD=51�`100�ɑ΂��鏈���B</remarks>
        /// 
        private void SettingFieldInfoByTag(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, int copyCount, DataTable dataTable)
        {
            // ����œ]�ŕ����i0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ېŁj
            int consTaxLayMethod = PMUOE08001PB.GetSALESSLIPRF_CONSTAXLAYMETHODRF(dataTable);

            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //����`�[���v�i�Ŕ����j(�}�C�i�X�����Ȃ�)
            Double salestotaltaxexcnominusrf = PMUOE08001PB.GetHADD_SALESTOTALTAXEXCNOMINUSRF(dataTable);

            //AB�{���������z���v(�}�C�i�X�����Ȃ�)
            Double abhqtotalcostnominusrf = PMUOE08001PB.GetHADD_ABHQTOTALCOSTNOMINUSRF(dataTable);
            // --- ADD 2009.07.24 ���m ------ <<<<<<

            # region [���ʐF]
            Color backColor = GetBackColor(copyCount);
            Color backColorLight = MixColor(backColor, Color.FromArgb(77, 70, 87), 0);

            Color foreColor;
            // �w�i���Â��ꍇ�͕����𔒔����ɂ���
            if (IsDark(backColor))
            {
                foreColor = Color.White;
            }
            else
            {
                foreColor = Color.Black;
            }
            # endregion

            foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
            {
                foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                {
                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //if (arControl.Tag is string)
                    if ( (arControl.Tag is string) && (arControl.Tag as string).Length >= 3 )
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    {
                        string tagSub = ( arControl.Tag as string ).Substring(0, 3);

                        # region [���ꍀ��(51�`100)]
                        switch (tagSub)
                        {
                            // --- ADD ����� 2011/08/15---------->>>>>
                            case "34,":
                                {
                                    //-------------------------------------------
                                    // �u34:�^�C�g���P�v�̏ꍇ
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle11;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle21;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle31;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle41;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "35,":
                                {
                                    //-------------------------------------------
                                    // �u35:�^�C�g���Q�v�̏ꍇ
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle12;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle22;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle32;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle42;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "36,":
                                {
                                    //-------------------------------------------
                                    // �u36:�^�C�g���R�v�̏ꍇ
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle13;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle23;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle33;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle43;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "37,":
                                {
                                    //-------------------------------------------
                                    // �u37:�^�C�g���S�v�̏ꍇ
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle14;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle24;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle34;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle44;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "38,":
                                {
                                    //-------------------------------------------
                                    // �u38:�^�C�g���T�v�̏ꍇ
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle15;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle25;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle35;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle45;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            // --- ADD ����� 2011/08/15----------<<<<<

                            // --- ADD 2009.07.24 ���m ------ >>>>>>
                            case "43,":
                                {
                                    //-------------------------------------------
                                    // �u43:����`�[���v�i�Ŕ����j�}�C�i�X�����v�̏ꍇ
                                    //-------------------------------------------
                                    if (salestotaltaxexcnominusrf >= 0)
                                    {
                                        // ����`�[���v�i�Ŕ����j�}�C�i�X���� false
                                        ( arControl as ar.Label ).Visible = false;
                                    }
                                    else
                                    {
                                        // ����`�[���v�i�Ŕ����j�}�C�i�X���� true
                                    }
                                }
                                break;
                            case "44,":
                                {
                                    //-------------------------------------------
                                    // �u44:AB�{���������z���v�}�C�i�X�����v�̏ꍇ
                                    //-------------------------------------------
                                    if (abhqtotalcostnominusrf >= 0)
                                    {
                                        // AB�{���������z���v�}�C�i�X���� false
                                        ( arControl as ar.Label ).Visible = false;
                                    }
                                    else
                                    {
                                        // AB�{���������z���v�}�C�i�X���� true
                                    }
                                }
                                break;
                            // --- ADD 2009.07.24 ���m ------ <<<<<<
                            // 2011/05/27 Add >>>
                            case "49,":
                                {
                                    //-------------------------------------------
                                    // �u49:�ԑ�ԍ����e����(���͎��̂�)�v�̏ꍇ
                                    //-------------------------------------------
                                    if (string.IsNullOrEmpty(PMUOE08001PB.GetHADD_FRAMENORF(dataTable)))
                                    {
                                        (arControl as ar.Label).Visible = false;
                                    }
                                    else
                                    {
                                        (arControl as ar.Label).Visible = true;
                                    }
                                }
                                break;
                            // 2011/05/27 Add <<<
                            case "51,":
                                {
                                    //-------------------------------------------
                                    // �u51:���ʐF�w�i�Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    DataDynamics.ActiveReports.Label label = ( arControl as DataDynamics.ActiveReports.Label );
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
                                    ( arControl as DataDynamics.ActiveReports.Line ).LineColor = backColor;
                                }
                                break;
                            case "53,":
                                {
                                    //-------------------------------------------
                                    // �u53:���ʐF�g���v�̏ꍇ
                                    //-------------------------------------------
                                    ( arControl as DataDynamics.ActiveReports.Shape ).LineColor = backColor;
                                }
                                break;
                            case "54,":
                                {
                                    //-------------------------------------------
                                    // �u54:���ʐF�Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    ( arControl as DataDynamics.ActiveReports.TextBox ).ForeColor = backColor;
                                }
                                break;
                            case "55,":
                                {
                                    //-------------------------------------------
                                    // �u55:���ʑΉ��`�[�^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    //(arControl as DataDynamics.ActiveReports.Label).Text = GetSlipTitle( copyCount );
                                    //(arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                    switch (copyCount)
                                    {
                                        case 0:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle1;
                                            break;
                                        case 1:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle2;
                                            break;
                                        case 2:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle3;
                                            break;
                                        case 3:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle4;
                                            break;
                                        default:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "56,":
                                {
                                    //-------------------------------------------
                                    // �u56:���Џ��Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
                                    switch (_slipPrtSet.EnterpriseNamePrtCd)
                                    {
                                        case 2:
                                        case 3:
                                            {
                                                arControl.Visible = false;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "57,":
                                {
                                    //-------------------------------------------
                                    // �u57:�����Œ蕶���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_slipPrtSet.TimePrintDivCd == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "58,":
                                {
                                    //-------------------------------------------
                                    // �u58:�i�ԃ^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.GoodsNo == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "59,":
                                {
                                    //-------------------------------------------
                                    // �u59:BL�R�[�h�^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.BLGoodsCode == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "60,":
                                {
                                    //-------------------------------------------
                                    // �u60:�W�����i�^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.ListPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "61,":
                                {
                                    //-------------------------------------------
                                    // �u61:�����^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "62,":
                                {
                                    //-------------------------------------------
                                    // �u62:�����^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.Cost == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "63,":
                                {
                                    //-------------------------------------------
                                    // �u63:�S���҃^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.SalesEmployee == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "64,":
                                {
                                    //-------------------------------------------
                                    // �u64:�󒍎҃^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.FrontEmployee == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "65,":
                                {
                                    //-------------------------------------------
                                    // �u65:���s�҃^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.SalesInput == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "66,":
                                {
                                    //-------------------------------------------
                                    // �u66:���}�[�N�^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // 0:���,1:��
                                    if (_eachSlipTypeSet.SalesOrderDiv == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "67,":
                                {
                                    //-------------------------------------------
                                    // �u67:����Ń^�C�g���v�̏ꍇ
                                    //-------------------------------------------
                                    // ������0:���,1:��
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    else
                                    {
                                        // �]�ŕ���
                                        switch (consTaxLayMethod)
                                        {
                                            case 0:
                                            case 1:
                                                {
                                                    // ����Ł�0:�󎚂��Ȃ�
                                                    if (_slipPrtSet.ConsTaxPrtCdRF == 0)
                                                    {
                                                        // ���
                                                        arControl.Visible = false;
                                                    }
                                                }
                                                break;
                                            case 2:
                                            case 3:
                                            default:
                                                {
                                                    // ���
                                                    arControl.Visible = false;
                                                }
                                                break;
                                        }
                                    }

                                    // ���x���̈󎚓��e�𐧌䂷��
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_TaxTitle;
                                }
                                break;
                            case "68,":
                                {
                                    //-------------------------------------------
                                    // �u68:���v�^�C�g���i���ׁE�`�[�]�Łj�v�̏ꍇ
                                    //-------------------------------------------
                                    // ������0:���,1:��
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    else
                                    {
                                        // �]�ŕ���
                                        switch (consTaxLayMethod)
                                        {
                                            case 0:
                                            case 1:
                                            default:
                                                {
                                                    // ����Ł�0:�󎚂��Ȃ�
                                                    if (_slipPrtSet.ConsTaxPrtCdRF == 0)
                                                    {
                                                        // ���
                                                        arControl.Visible = false;
                                                    }
                                                }
                                                break;
                                            case 2:
                                            case 3:
                                            case 9:
                                                {
                                                    // ���
                                                    arControl.Visible = false;
                                                }
                                                break;
                                        }
                                    }

                                    // ���x���̈󎚓��e�𐧌䂷��
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_SubTotalTitle;
                                }
                                break;
                            case "69,":
                                {
                                    //-------------------------------------------
                                    // 69:��M�����Œ蕶���̏ꍇ
                                    //-------------------------------------------

                                    // 0:���,1:��
                                    if (_slipPrtSet.TimePrintDivCd == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    // ���x���̈󎚓��e�𐧌䂷��
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_ReceiveTimeLabel;
                                }
                                break;
                            default:
                                break;
                        }
                        # endregion
                    }
                }


                //// --- ADD 2009.07.24 ���m ------ >>>>>>
                //if ("Detail1".Equals(section.Name))
                //{
                //    foreach (DataRow row in dataTable.Rows)
                //    {
                //        foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                //        {
                //            if (arControl.Tag is string)
                //            {
                //                string tagSub = (arControl.Tag as string).Substring(0, 3);

                //                # region [���ꍀ��(40-42)]
                //                switch (tagSub)
                //                {
                //                    case "40,":
                //                        {
                //                            //-------------------------------------------
                //                            // �u40:�o�א��}�C�i�X�����v�̏ꍇ
                //                            //-------------------------------------------
                //                            try
                //                            {
                //                                if (!row.IsNull("DADD.SHIPMENTCNTNOMINUSRF"))
                //                                {
                //                                    if ((Double)row["DADD.SHIPMENTCNTNOMINUSRF"] >= 0)
                //                                    {
                //                                        // �o�א��}�C�i�X���� false
                //                                        (arControl as ar.Label).Visible = false;
                //                                    }
                //                                    else
                //                                    {
                //                                        // �o�א��}�C�i�X���� true
                //                                    }
                //                                }
                //                                else
                //                                {
                //                                    // �o�א��}�C�i�X���� false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                            }
                //                            catch
                //                            {

                //                            }
                //                        }
                //                        break;
                //                    case "41,":
                //                        {
                //                            //-------------------------------------------
                //                            // �u41:������z�i�Ŕ����j������z�}�C�i�X�����v�̏ꍇ
                //                            //-------------------------------------------
                //                            if (!row.IsNull("DADD.SALESMONEYTAXEXCNOMINUSRF"))
                //                            {
                //                                if ((Double)row["DADD.SALESMONEYTAXEXCNOMINUSRF"] >= 0)
                //                                {
                //                                    // ������z�i�Ŕ����j������z�}�C�i�X���� false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                                else
                //                                {
                //                                    // ������z�i�Ŕ����j������z�}�C�i�X���� true
                //                                }
                //                            }
                //                            else
                //                            {
                //                                // ������z�i�Ŕ����j������z�}�C�i�X���� false
                //                                (arControl as ar.Label).Visible = false;
                //                            }
                //                        }
                //                        break;
                //                    case "42,":
                //                        {
                //                            //-------------------------------------------
                //                            // �u42:AB�{���������z�}�C�i�X����)�v�̏ꍇ
                //                            //-------------------------------------------
                //                            if (!row.IsNull("DADD.ABHQSALESUNITCOSTNOMINUSRF"))
                //                            {
                //                                if ((Double)row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] >= 0)
                //                                {
                //                                    // AB�{���������z�}�C�i�X���� false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                                else
                //                                {
                //                                    // AB�{���������z�}�C�i�X���� true
                //                                }
                //                            }
                //                            else
                //                            {
                //                                // AB�{���������z�}�C�i�X���� false
                //                                (arControl as ar.Label).Visible = false;
                //                            }
                //                        }
                //                        break;
                //                    default:
                //                        break;
                //                }
                //                # endregion [���ꍀ��(40-42)]

                //            }
                //        }
                //    }
                //}
                //// --- ADD 2009.07.24 ���m ------ <<<<<<
            }
        }
        # region [�`�[���ʑΉ�]
        /// <summary>
        /// ���ʑΉ��`�[�^�C�g���擾����
        /// </summary>
        /// <param name="copyCount"></param>
        /// <returns></returns>
        private string GetSlipTitle(int copyCount)
        {
            switch (copyCount)
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
        private Color GetBackColor(int copyCountIndex)
        {
            switch (copyCountIndex)
            {
                case 0:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed1, _slipPrtSet.SlipBaseColorGrn1, _slipPrtSet.SlipBaseColorBlu1);
                case 1:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed2, _slipPrtSet.SlipBaseColorGrn2, _slipPrtSet.SlipBaseColorBlu2);
                case 2:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed3, _slipPrtSet.SlipBaseColorGrn3, _slipPrtSet.SlipBaseColorBlu3);
                case 3:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed4, _slipPrtSet.SlipBaseColorGrn4, _slipPrtSet.SlipBaseColorBlu4);
                case 4:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed5, _slipPrtSet.SlipBaseColorGrn5, _slipPrtSet.SlipBaseColorBlu5);
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
        private static Color MixColor(Color firstColor, Color secondColor, int mixMode)
        {
            switch (mixMode)
            {
                case 0:
                    {
                        int redColor = firstColor.R + secondColor.R;
                        if (redColor > 255)
                        {
                            redColor = 255;
                        }
                        int greenColor = firstColor.G + secondColor.G;
                        if (greenColor > 255)
                        {
                            greenColor = 255;
                        }
                        int blueColor = firstColor.B + secondColor.B;
                        if (blueColor > 255)
                        {
                            blueColor = 255;
                        }

                        return Color.FromArgb(redColor, greenColor, blueColor);
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
        private static bool IsDark(Color backColor)
        {
            // ���肵�����l
            int divColorPoint = 200;

            if ((int)backColor.R + (int)backColor.G + (int)backColor.B < divColorPoint)
            {
                return true;
            }
            else
            {
                return false;
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
        /// <br>Date		: 2008.11.18</br>
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
            // Report��PrintWidth��inch�P�ʂŒ��r���[�ȏꍇ�A�s�v�ȋ�y�[�W���������Ă��܂��̂Ŗh�~����B
            // (������R�ʈȍ~�͐؂�̂Ă�)
            int width = (int)( (float)rpt.PrintWidth * (float)100.0f );
            rpt.PrintWidth = (float)width / (float)100.0f;
            // �]����������
            rpt.PrintWidth -= ( rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
        }

        /// <summary>
        /// �v�����^�[���Z�b�g����
        /// </summary>
        /// <param name="document">���|�[�gDocument</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �v�����^�[����ݒ肵�܂��B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2008.11.18</br>
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

    # region [�`�[�^�C�v�ʐݒ�]
    /// <summary>
    /// �`�[�^�C�v�ʐݒ�
    /// </summary>
    internal struct EachSlipTypeSet
    {
        /// <summary>�i�Ԉ�</summary>
        private int _goodsNo;
        /// <summary>�a�k�R�[�h��</summary>
        private int _bLGoodsCode;
        /// <summary>�W�����i��</summary>
        private int _listPrice;
        /// <summary>������</summary>
        private int _salesPrice;
        /// <summary>������</summary>
        private int _cost;
        /// <summary>�S���҈�</summary>
        private int _salesEmployee;
        /// <summary>�󒍎҈�</summary>
        private int _frontEmployee;
        /// <summary>���s�҈�</summary>
        private int _salesInput;
        /// <summary>���}�[�N��</summary>
        private int _salesOrderDiv;
        /// <summary>
        /// �i�Ԉ�
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }
        /// <summary>
        /// �a�k�R�[�h��
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }
        /// <summary>
        /// �W�����i��
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        /// <summary>
        /// �S���҈�
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int SalesEmployee
        {
            get { return _salesEmployee; }
            set { _salesEmployee = value; }
        }
        /// <summary>
        /// �󒍎҈�
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int FrontEmployee
        {
            get { return _frontEmployee; }
            set { _frontEmployee = value; }
        }
        /// <summary>
        /// ���s�҈�
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int SalesInput
        {
            get { return _salesInput; }
            set { _salesInput = value; }
        }
        /// <summary>
        /// ���}�[�N��
        /// </summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        public int SalesOrderDiv
        {
            get { return _salesOrderDiv; }
            set { _salesOrderDiv = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="goodsNo">�i�Ԉ�</param>
        /// <param name="bLGoodsCode">�a�k�R�[�h��</param>
        /// <param name="listPrice">�W�����i��</param>
        /// <param name="salesPrice">������</param>
        /// <param name="cost">������</param>
        /// <param name="salesEmployee">�S���҈�</param>
        /// <param name="frontEmployee">�󒍎҈�</param>
        /// <param name="salesInput">���s�҈�</param>
        /// <param name="salesOrderDiv">���}�[�N��</param>
        public EachSlipTypeSet(int goodsNo, int bLGoodsCode, int listPrice, int salesPrice, int cost, int salesEmployee, int frontEmployee, int salesInput, int salesOrderDiv)
        {
            _goodsNo = goodsNo;
            _bLGoodsCode = bLGoodsCode;
            _listPrice = listPrice;
            _salesPrice = salesPrice;
            _cost = cost;
            _salesEmployee = salesEmployee;
            _frontEmployee = frontEmployee;
            _salesInput = salesInput;
            _salesOrderDiv = salesOrderDiv;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="slipPrtSet">�`�[����ݒ�</param>
        public EachSlipTypeSet(SlipPrtSetWork slipPrtSet)
        {
            _goodsNo = slipPrtSet.EachSlipTypeColPrt1;
            _bLGoodsCode = slipPrtSet.EachSlipTypeColPrt2;
            _listPrice = slipPrtSet.EachSlipTypeColPrt3;
            _salesPrice = slipPrtSet.EachSlipTypeColPrt4;
            _cost = slipPrtSet.EachSlipTypeColPrt5;
            _salesEmployee = slipPrtSet.EachSlipTypeColPrt6;
            _frontEmployee = slipPrtSet.EachSlipTypeColPrt7;
            _salesInput = slipPrtSet.EachSlipTypeColPrt8;
            _salesOrderDiv = slipPrtSet.EachSlipTypeColPrt9;
        }
    }
    # endregion

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
        public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv)
        {
            _slipDatePrintDiv = slipDatePrintDiv;
            _totalPricePrtCd = totalPricePrtCd;
            _reissueDiv = reissueDiv;
        }
        /// <summary>
        /// �R���X�g���N�^ (object�̃f�B�N�V���i�����)
        /// </summary>
        /// <param name="objectDictionary"></param>
        public SlipPrintParameter(Dictionary<string, object> objectDictionary)
        {
            // �����l��ݒ�
            _slipDatePrintDiv = 1;
            _totalPricePrtCd = 0;
            _reissueDiv = false;

            // �n���ꂽList�̓��e���i�[
            if (objectDictionary != null)
            {
                if (objectDictionary.ContainsKey("SlipDatePrintDiv") && objectDictionary["SlipDatePrintDiv"] is int)
                {
                    _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                }
                if (objectDictionary.ContainsKey("TotalPricePrtCd") && objectDictionary["TotalPricePrtCd"] is int)
                {
                    _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                }
                if (objectDictionary.ContainsKey("ReissueDiv") && objectDictionary["ReissueDiv"] is bool)
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
            objectDic.Add("SlipDatePrintDiv", _slipDatePrintDiv);
            objectDic.Add("TotalPricePrtCd", _totalPricePrtCd);
            objectDic.Add("ReissueDiv", _reissueDiv);

            // Dictionary��Ԃ�
            return objectDic;
        }
    }
    # endregion ���@�`�[����p�����[�^�\���́@��
}

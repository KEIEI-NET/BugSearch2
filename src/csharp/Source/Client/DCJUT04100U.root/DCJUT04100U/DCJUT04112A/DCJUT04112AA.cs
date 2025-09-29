# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����c�Ɖ� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �`�[�������s���܂��B</br>
	/// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2007.10.15</br>
    /// <br>Update Note : 2009/02/25 30414 �E �K�j ��QID:7882�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/25�@22008 ���� ���n</br>
    /// <br>              �I�t���C���Ή�</br>
    /// </remarks>
    public class AcptAnOdrRemainRefAcs
    {
        # region �� private const ��
        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
        private const string ct_DateFormat = "yyyy/MM/dd";
        # endregion �� private const ��

        # region �� private static member ��
        private static SecInfoAcs _secInfoAcs;                      // ���_�A�N�Z�X�N���X
        # endregion �� private static member ��

        # region �� private member ��
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IAcptAnOdrRemainRefDB _iAcptAnOdrRemainRefDB = null;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
        /// <summary>�f�[�^�e�[�u��</summary>
        private DataTable _acptAnOdrRemainRefTable;
        private string _enterpriseCode;             // ��ƃR�[�h
        /// <summary>������z�[�������N���X</summary>
        private SalesFractionCalculate _salesFractionCalculate;
        /// <summary>���Ӑ�}�X�^�A�N�Z�X</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>�\���p�f�[�^�r���[</summary>
        private DataView _displayDataView;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.20 TOKUNAGA ADD START
        // ���_�R�[�h (���i�����}�X�^�����������邽�߂ɕK�v)
        private string _sectionCode;

        // ���[�J�[�R�[�h (���[�J�[�����肳�ꂽ�ꍇ�̕i�Ԍ����Ɏg�p)
        private int _makerCode = 0;

        private int _inpAgentDispDiv;                       // �ݒ�l�ۑ��p�F����S�̐ݒ�D���s�ҕ\���敪

        // ���s�ҕ\���敪(DCKHN09211E�̋敪�ƍ��킹��K�v����)
        private const int INP_AGT_DISP = 0;         // 0:����
        private const int INP_AGT_NODISP = 1;       // 1:���Ȃ�
        private const int INP_AGT_NESSESALY = 2;    // 2:�K�{

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public int MakerCode
        {
            get { return this._makerCode; }
            set { this._makerCode = value; }
        }

        /// <summary>
        /// ���s�ҕ\���敪
        /// </summary>
        public int InpAgentDispDiv
        {
            get { return this._inpAgentDispDiv; }
            set { this._inpAgentDispDiv = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.20 TOKUNAGA ADD END
        # endregion �� private member ��

        # region �� event ��

        // �o�̓��b�Z�[�W�ݒ�C�x���g
        /// <summary>���b�Z�[�W�ݒ�C�x���g</summary>
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        /// <summary>
        /// ���b�Z�[�W�ݒ�C�x���g��`
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);
        // �s�I����ԕύX�C�x���g
        /// <summary>�s�I����ԕύX�C�x���g</summary>
        public event EventHandler SelectedDataChange;

        # endregion �� event ��

        # region ��Constracter
        /// <summary>
		/// �����c�Ɖ� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
		/// <br>Note       : �����c�Ɖ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public AcptAnOdrRemainRefAcs()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // �f�[�^�e�[�u������
            DCJUT04102AC.CreateDataTable( ref this._acptAnOdrRemainRefTable, this._inpAgentDispDiv );
            // �v���C�}���L�[�ݒ�i�s�ԍ��j
            this._acptAnOdrRemainRefTable.PrimaryKey = new DataColumn[] { this._acptAnOdrRemainRefTable.Columns[DCJUT04102AC.ct_Col_RowNoView] };
            
            // ������z�[�������N���X�C���X�^���X�擾
            this._salesFractionCalculate = SalesFractionCalculate.GetInstance();
            this._salesFractionCalculate.SearchInitial( this._enterpriseCode );

            // ���Ӑ�}�X�^�A�N�Z�X
            this._customerInfoAcs = new CustomerInfoAcs();

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            // -- UPD 2010/05/25 ----------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iAcptAnOdrRemainRefDB = (IAcptAnOdrRemainRefDB)MediationAcptAnOdrRemainRefDB.GetAcptAnOdrRemainRefDB();
            //    }
            //    catch (Exception)
            //    {
            //        //�I�t���C������null���Z�b�g
            //        this._iAcptAnOdrRemainRefDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���
            //    //this.SearchOfflineData();
            //    MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iAcptAnOdrRemainRefDB = (IAcptAnOdrRemainRefDB)MediationAcptAnOdrRemainRefDB.GetAcptAnOdrRemainRefDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAcptAnOdrRemainRefDB = null;
            }
            // -- UPD 2010/05/25 -----------------------<<<
        }
        # endregion

        # region ��public int GetOnlineMode()
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iAcptAnOdrRemainRefDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ��Private Method

        /// <summary>
        /// �e�[�u���s�ǉ��@�i�����[�g���ʃN���X���e�[�u���f�[�^�s�j
        /// </summary>
        /// <param name="index">�e�[�u���s�ԍ�(0����n�܂�index)</param>
        /// <param name="refDataWork">�����[�g���ʃN���X</param>
        private void AddDataRowFromResultWork(int index, AcptAnOdrRemainRefDataWork refDataWork)//, string exSalesSlipNum)
        {
            DataRow newRow = this._acptAnOdrRemainRefTable.NewRow();

            newRow[DCJUT04102AC.ct_Col_EnterpriseCode] = refDataWork.EnterpriseCode;            // ��ƃR�[�h
            newRow[DCJUT04102AC.ct_Col_AcptAnOdrStatus] = refDataWork.AcptAnOdrStatus;          // �󒍃X�e�[�^�X
            newRow[DCJUT04102AC.ct_Col_SalesSlipNum] = refDataWork.SalesSlipNum;                // ����`�[�ԍ�
            newRow[DCJUT04102AC.ct_Col_AcceptAnOrderNo] = refDataWork.AcceptAnOrderNo;          // �󒍔ԍ�
            newRow[DCJUT04102AC.ct_Col_CommonSeqNo] = refDataWork.CommonSeqNo;                  // ���ʒʔ�
            newRow[DCJUT04102AC.ct_Col_SalesSlipDtlNum] = refDataWork.SalesSlipDtlNum;          // ���㖾�גʔ�
            if (refDataWork.CustomerCode > 0) // 0�̎��͋�
            {
                newRow[DCJUT04102AC.ct_Col_CustomerCode] = refDataWork.CustomerCode.ToString().PadLeft(8, '0');                // ���Ӑ�R�[�h
            }
            newRow[DCJUT04102AC.ct_Col_CustomerSnm] = refDataWork.CustomerSnm;                  // ���Ӑ旪��
            newRow[DCJUT04102AC.ct_Col_SalesEmployeeNm] = refDataWork.SalesEmployeeNm;          // �̔��]�ƈ�����
            newRow[DCJUT04102AC.ct_Col_SalesInputNm] = refDataWork.SalesInputName;              // ���s�Җ��� [9094]
            newRow[DCJUT04102AC.ct_Col_AddresseeName] = refDataWork.AddresseeName;              // �[�i�於��
            newRow[DCJUT04102AC.ct_Col_AddresseeName2] = refDataWork.AddresseeName2;            // �[�i�於��2
            newRow[DCJUT04102AC.ct_Col_FrontEmployeeNm] = refDataWork.FrontEmployeeNm;          // ��t�]�ƈ�����
            newRow[DCJUT04102AC.ct_Col_SalesDate] = refDataWork.SalesDate;                      // ������t
            newRow[DCJUT04102AC.ct_Col_GoodsNo] = refDataWork.GoodsNo;                          // ���i�ԍ�
            newRow[DCJUT04102AC.ct_Col_GoodsName] = refDataWork.GoodsName;                      // ���i����
            newRow[DCJUT04102AC.ct_Col_MakerName] = refDataWork.MakerName;                      // ���[�J�[����
            newRow[DCJUT04102AC.ct_Col_AcceptAnOrderCnt] = refDataWork.AcceptAnOrderCnt;        // �󒍐���
            newRow[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt] = refDataWork.AcptAnOdrRemainCnt;    // �󒍎c��
            //newRow[DCJUT04102AC.ct_Col_UnitName] = refDataWork.UnitName;                        // �P�ʖ���
            newRow[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl] = refDataWork.SalesUnPrcTaxExcFl;    // ����P���i�Ŕ��C�����j
            //newRow[DCJUT04102AC.ct_Col_BargainNm] = refDataWork.BargainNm;                      // �����敪����
            newRow[DCJUT04102AC.ct_Col_PartySlipNumDtl] = refDataWork.PartySlipNumDtl;          // �����`�[�ԍ��i���ׁj
            newRow[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc] = refDataWork.StdUnPrcSalUnPrc;        // ��P���i����P���j
            newRow[DCJUT04102AC.ct_Col_SalesUnitCost] = refDataWork.SalesUnitCost;              // �����P��
            newRow[DCJUT04102AC.ct_Col_SupplierSnm] = refDataWork.SupplierSnm;                  // �d���旪��
            newRow[DCJUT04102AC.ct_Col_DtlNote] = refDataWork.DtlNote;                          // ���ה��l
            //newRow[DCJUT04102AC.ct_Col_CustomerDeliveryDate] = refDataWork.CustomerDeliveryDate; // �q��[��
            newRow[DCJUT04102AC.ct_Col_SlipMemo1] = refDataWork.SlipMemo1;                      // �`�[�����P
            newRow[DCJUT04102AC.ct_Col_SlipMemo2] = refDataWork.SlipMemo2;                      // �`�[�����Q
            newRow[DCJUT04102AC.ct_Col_SlipMemo3] = refDataWork.SlipMemo3;                      // �`�[�����R
            //newRow[DCJUT04102AC.ct_Col_SlipMemo4] = refDataWork.SlipMemo4;                      // �`�[�����S
            //newRow[DCJUT04102AC.ct_Col_SlipMemo5] = refDataWork.SlipMemo5;                      // �`�[�����T
            //newRow[DCJUT04102AC.ct_Col_SlipMemo6] = refDataWork.SlipMemo6;                      // �`�[�����U
            newRow[DCJUT04102AC.ct_Col_InsideMemo1] = refDataWork.InsideMemo1;                  // �Г������P
            newRow[DCJUT04102AC.ct_Col_InsideMemo2] = refDataWork.InsideMemo2;                  // �Г������Q
            newRow[DCJUT04102AC.ct_Col_InsideMemo3] = refDataWork.InsideMemo3;                  // �Г������R
            //newRow[DCJUT04102AC.ct_Col_InsideMemo4] = refDataWork.InsideMemo4;                  // �Г������S
            //newRow[DCJUT04102AC.ct_Col_InsideMemo5] = refDataWork.InsideMemo5;                  // �Г������T
            //newRow[DCJUT04102AC.ct_Col_InsideMemo6] = refDataWork.InsideMemo6;                  // �Г������U
            //newRow[DCJUT04102AC.ct_Col_SupplierFormal] = refDataWork.SupplierFormal;            // �d���`��
            //newRow[DCJUT04102AC.ct_Col_StockSlipDtlNum] = refDataWork.StockSlipDtlNum;          // �d�����גʔ�
            //newRow[DCJUT04102AC.ct_Col_OrderNumber] = refDataWork.OrderNumber;                  // �����ԍ�
            //newRow[DCJUT04102AC.ct_Col_ExpectDeliveryDate] = refDataWork.ExpectDeliveryDate;    // ��]�[��
            //newRow[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] = refDataWork.DeliGdsCmpltDueDate;  // �[�i�����\���
            //newRow[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;          // ���ד�
            //newRow[DCJUT04102AC.ct_Col_StockCount] = refDataWork.StockCount;                    // �d����
            //newRow[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;        // �d���P���i�Ŕ��C�����j

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            if (refDataWork.SupplierCd > 0) // 0�̎��͋�
            {
                newRow[DCJUT04102AC.ct_Col_SupplierCd] = refDataWork.SupplierCd.ToString().PadLeft(6, '0');                    // �d����R�[�h
            }
            newRow[DCJUT04102AC.ct_Col_WarehouseCode] = refDataWork.WarehouseCode;
            newRow[DCJUT04102AC.ct_Col_WarehouseName] = refDataWork.WarehouseName;
            string slipCdDtl;
            switch (refDataWork.SalesSlipCdDtl)
            {
                case 0: slipCdDtl = "����"; break;
                case 1: slipCdDtl = "�ԕi"; break;
                case 2: slipCdDtl = "�l��"; break;
                case 3: slipCdDtl = "����"; break;
                case 4: slipCdDtl = "���v"; break;
                case 5: slipCdDtl = "���"; break;
                default: slipCdDtl = ""; break;
            }
            newRow[DCJUT04102AC.ct_Col_SalesSlipCdDtl] = slipCdDtl;
            if (refDataWork.BLGoodsCode > 0) // 0�̎��͋�
            {
                newRow[DCJUT04102AC.ct_Col_BLGoodsCode] = refDataWork.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            newRow[DCJUT04102AC.ct_Col_SalesPriceTotal] = refDataWork.ListPriceTaxExcFl * refDataWork.AcceptAnOrderCnt;
            // ����œ]�ŋ敪�ɂ���ē��e��ς���
            // ���z�\��������̎��͖��גP�ʂ̂�
            if ((refDataWork.ConsTaxLayMethod == 0) ||// �`�[�P��
                (refDataWork.ConsTaxLayMethod == 1)) // ���גP��
            {
                newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = refDataWork.SalesPriceConsTax;
            }
            else if ((refDataWork.ConsTaxLayMethod == 2) || // �����e
                    (refDataWork.ConsTaxLayMethod == 3) || // �����q
                    (refDataWork.ConsTaxLayMethod == 9)) // ��ې�
            {
                // ���ł̂Ƃ��̂ݕ\��
                if (refDataWork.TaxationDivCd == 2)
                {
                    newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = refDataWork.SalesPriceConsTax;
                }
                else
                {
                    newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = DBNull.Value;
                }
            }
            newRow[DCJUT04102AC.ct_Col_ListPriceTaxExc] = refDataWork.ListPriceTaxExcFl;
            newRow[DCJUT04102AC.ct_Col_SalesTotalCost] = refDataWork.SalesUnitCost * refDataWork.AcceptAnOrderCnt;
            newRow[DCJUT04102AC.ct_Col_ShipmentCnt] = refDataWork.ShipmentCnt;
            newRow[DCJUT04102AC.ct_Col_CarMngCode] = refDataWork.CarMngCode;
            newRow[DCJUT04102AC.ct_Col_ModelDesignationNo] = refDataWork.ModelDesignationNo;
            newRow[DCJUT04102AC.ct_Col_CategoryNo] = refDataWork.CategoryNo;
            if (refDataWork.ModelDesignationNo > 0 || refDataWork.CategoryNo > 0)
            {
                string tmpModel = "00000" + refDataWork.ModelDesignationNo.ToString();
                tmpModel = tmpModel.Substring(tmpModel.Length - 5, 5);
                string tmpCategory = "0000" + refDataWork.CategoryNo.ToString();
                tmpCategory = tmpCategory.Substring(tmpCategory.Length - 4, 4);
                newRow[DCJUT04102AC.ct_Col_ModelCategory] = tmpModel + "-" + tmpCategory;
            }
            newRow[DCJUT04102AC.ct_Col_ModelFullName] = refDataWork.ModelFullName;
            newRow[DCJUT04102AC.ct_Col_FullModel] = refDataWork.FullModel;
            newRow[DCJUT04102AC.ct_Col_SearchSlipDate] = refDataWork.SearchSlipDate;//TDateTime.DateTimeToLongDate(refDataWork.SearchSlipDate);
            if (refDataWork.SearchSlipDate != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_SearchSlipDateString] = refDataWork.SearchSlipDate.ToString("yyyy/MM/dd");// TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.SearchSlipDate);
            }
            newRow[DCJUT04102AC.ct_Col_ShipmentDay] = refDataWork.ShipmentDay;// TDateTime.DateTimeToLongDate(refDataWork.ShipmentDay);
            if (refDataWork.ShipmentDay != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_ShipmentDayString] = refDataWork.ShipmentDay.ToString("yyyy/MM/dd");// TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.ShipmentDay);
            }
            newRow[DCJUT04102AC.ct_Col_AddUpADate] = refDataWork.AddUpADate;// TDateTime.DateTimeToLongDate(refDataWork.AddUpADate);
            if (refDataWork.AddUpADate != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_AddUpADateString] = refDataWork.AddUpADate.ToString("yyyy/MM/dd");//TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.AddUpADate);
            }
            newRow[DCJUT04102AC.ct_Col_SectionName] = refDataWork.SectionGuideNm;
            if (refDataWork.ClaimCode > 0) // 0�̎��͋�
            {
                newRow[DCJUT04102AC.ct_Col_ClaimCode] = refDataWork.ClaimCode.ToString().PadLeft(8, '0');
            }
            newRow[DCJUT04102AC.ct_Col_ClaimSnm] = refDataWork.ClaimSnm;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END
            // 2008.12.12 add start [9095]
            newRow[DCJUT04102AC.ct_Col_SalesRowNo] = refDataWork.SalesRowNo;
            // 2008.12.12 add end [9095]
            //-------------------------------------------------------------------------------------
            // �i���ȉ��A�t�h����E�\���p���ځj
            //-------------------------------------------------------------------------------------
            newRow[DCJUT04102AC.ct_Col_RowNoView] = index + 1;  // �\���s�ԍ�
            newRow[DCJUT04102AC.ct_Col_SelectRowFlag] = false;  // �I���t���O

            //newRow[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice] = GetAcptAnOdrRemainPrice( newRow ); // �󒍎c���z
            newRow[DCJUT04102AC.ct_Col_MemoExistsFlag] = GetMemoExists( newRow );   // �����L���t���O

            if ( (bool)newRow[DCJUT04102AC.ct_Col_MemoExistsFlag] == true )
            {
                newRow[DCJUT04102AC.ct_Col_MemoExistsMark] = "��"; // �����}�[�N
            }
            else
            {
                newRow[DCJUT04102AC.ct_Col_MemoExistsMark] = string.Empty; // �����}�[�N
            }

            //--- �\���p���t ---//
            SetDatesForView( ref newRow );

            //-------------------------------------------------------------------------------------
            // �s�ǉ�
            //-------------------------------------------------------------------------------------
            this._acptAnOdrRemainRefTable.Rows.Add( newRow );
        }
        /// <summary>
        /// �\���p���t�ݒ菈��
        /// </summary>
        /// <param name="row"></param>
        private void SetDatesForView ( ref DataRow row )
        {
            // ������t�i�\���p�j
            if ( (DateTime)row[DCJUT04102AC.ct_Col_SalesDate] == DateTime.MinValue )
            {
                row[DCJUT04102AC.ct_Col_SalesDateView] = string.Empty;
            }
            else
            {
                row[DCJUT04102AC.ct_Col_SalesDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_SalesDate] ).ToString( "yyyy/MM/dd" );
            }

            //// �q��[���i�\���p�j
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_CustomerDeliveryDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_CustomerDeliveryDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// ��]�[���i�\���p�j
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_ExpectDeliveryDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_ExpectDeliveryDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// �[�i�����\����i�\���p�j
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// ���ד��i�\���p�j
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_ArrivalGoodsDayView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_ArrivalGoodsDayView] = ( (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] ).ToString( "yyyy/MM/dd" );
            //}
        }
        /// <summary>
        /// �����L�����菈��
        /// </summary>
        /// <param name="row">�f�[�^�e�[�u���s</param>
        /// <returns>�����L��(true:�L��^false:����)</returns>
        private bool GetMemoExists ( DataRow row )
        {
            // �`�[����
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo1] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo2] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo3] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo4] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo5] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo6] ).TrimEnd() != string.Empty ) return true;
            // �Г�����
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo1] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo2] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo3] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo4] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo5] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo6] ).TrimEnd() != string.Empty ) return true;

            return false;
        }
        /// <summary>
        /// �󒍎c���z�Z�o����
        /// </summary>
        /// <param name="row">�f�[�^�e�[�u���s</param>
        /// <returns>�󒍎c���z�i�󒍎c���~����P���j</returns>
        /// <remarks>
        /// <br>���Ӑ�̒[�������R�[�h���擾���A����[�������}�X�^���Q�Ƃ��Ē[���������܂��B</br>
        /// </remarks>
        private Int64 GetAcptAnOdrRemainPrice ( DataRow row )
        {
            double unitPrice = (double)row[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl]; // �P��
            double remainCnt = (double)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt]; // �󒍎c��
            
            // �[�������R�[�h�擾
            int customerCd = (int)row[DCJUT04102AC.ct_Col_CustomerCode];
            CustomerInfo customerInfo = null;

            if (customerCd != 0) 
            {
                // ���Ӑ�}�X�^�ǂݍ���
                this.GetCustomerInfo( customerCd, out customerInfo );
            }

            if ( customerInfo != null )
            {
                // ���z�[�������}�X�^�ɏ]�����[���������s��
                return (Int64)this._salesFractionCalculate.GetSalesPrice( unitPrice * remainCnt, customerInfo.SalesMoneyFrcProcCd );
            }
            else
            {
                // �������Ӑ�ǂݍ��݂ł��Ȃ��Ă�
                // �b��I�Ȍv�Z���ʂ�Ԃ��B
                return (Int64)(unitPrice * remainCnt);
            }
        }
        /// <summary>
        /// ���Ӑ���擾
        /// </summary>
        /// <param name="customerCd"></param>
        /// <param name="customerInfo"></param>
        /// <remarks>
        /// <br>���Ӑ�}�X�^�A�N�Z�X�N���X�̌ďo���s���܂��B</br>
        /// <br>�L���b�V���ǂݍ��݂�D�悵�čs���A���L���b�V���̂݃����[�g�Ăяo�����܂��B</br>
        /// </remarks>
        private void GetCustomerInfo ( int customerCd, out CustomerInfo customerInfo )
        {
            int status = this._customerInfoAcs.ReadCacheMemoryData( out customerInfo, this._enterpriseCode, customerCd );
            if ( status != 0 )
            {
                this._customerInfoAcs.ReadDBData( this._enterpriseCode, customerCd, out customerInfo );
            }
        }

        /// <summary>
        /// �e�[�u���s�X�V�@�i�����[�g���ʃN���X���e�[�u���f�[�^�s�j
        /// </summary>
        /// <param name="index">�e�[�u���s��(0����n�܂�index)</param>
        /// <param name="refDataWork">�����[�g���ʃN���X</param>
        private void UpdateRowFromResultWork ( int index, AcptAnOdrRemainRefDataWork refDataWork)
        {
            //SupplierFormalState supplierFormal = (SupplierFormalState)refDataWork.SupplierFormal;
            
            // �X�V�Ώۍs�擾
            if (index >= this._acptAnOdrRemainRefTable.Rows.Count) return;
            DataRow row = this._acptAnOdrRemainRefTable.Rows[index];
            
            if (row == null) return;

            // �d���`���ɂ�菈�����قȂ�
            //switch ( supplierFormal )
            //{
            //    //---------------------------------------------------------------------------------------------------
            //    // �d��
            //    //---------------------------------------------------------------------------------------------------
            //    //case SupplierFormalState.Stock:
            //    //    {
            //    //        // ���ד����V�����Ȃ�΍X�V
            //    //        if ( refDataWork.ArrivalGoodsDay > (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] )
            //    //        {
            //    //            row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;     // ���ד�
            //    //            row[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;   // �d���P��
            //    //        }

            //    //        // ���א������Z
            //    //        row[DCJUT04102AC.ct_Col_StockCount] = (double)row[DCJUT04102AC.ct_Col_StockCount] + refDataWork.StockCount;

            //    //        break;
            //    //    }
            //    //---------------------------------------------------------------------------------------------------
            //    // ����
            //    //---------------------------------------------------------------------------------------------------
            //    //case SupplierFormalState.Arrival:
            //    //    {
            //    //        // ���ד����V�����Ȃ�΍X�V
            //    //        if ( refDataWork.ArrivalGoodsDay > (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] )
            //    //        {
            //    //            row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;     // ���ד�
            //    //            row[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;   // �d���P��
            //    //        }

            //    //        // ���א������Z
            //    //        row[DCJUT04102AC.ct_Col_StockCount] = (double)row[DCJUT04102AC.ct_Col_StockCount] + refDataWork.StockCount;

            //    //        break;
            //    //    }
            //    //---------------------------------------------------------------------------------------------------
            //    // ����
            //    //---------------------------------------------------------------------------------------------------
            //    case SupplierFormalState.Order:
            //        {
            //            // ������񂪊��ɓ����Ă��āA���񃌃R�[�h���V�����Ȃ�΍X�V
            //            if ( (string)row[DCJUT04102AC.ct_Col_OrderNumber] != string.Empty &&
            //                refDataWork.StockSlipDtlNum > (Int64)row[DCJUT04102AC.ct_Col_StockSlipDtlNum] )
            //            {
            //                row[DCJUT04102AC.ct_Col_StockSlipDtlNum] = refDataWork.StockSlipDtlNum;         // �d�����גʔ�
            //                row[DCJUT04102AC.ct_Col_OrderNumber] = refDataWork.OrderNumber;                 // �����ԍ�
            //                row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] = refDataWork.ExpectDeliveryDate;   // ��]�[��
            //                row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] = refDataWork.DeliGdsCmpltDueDate; // �[�i�����\���
            //            }
            //            break;
            //        }
            //    default:
            //        break;
            //}

            //--- �\���p���t ---//
            SetDatesForView( ref row );
   
        }

        /// <summary>
        /// �sFind�����i�v���C�}���L�[�F�s���j
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        private DataRow FindDataRowByPrimaryKey ( int rowNo )
        {
            return this._acptAnOdrRemainRefTable.Rows.Find( rowNo );
        }
        /// <summary>
        /// �f�[�^�R�s�[�����i�f�[�^�s�r���[���Ɖ�o���ʃf�[�^�j
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private AcptAnOdrRemainRefData CopyToRefDataFromRow ( DataRow row )
        {
            AcptAnOdrRemainRefData refData = new AcptAnOdrRemainRefData();

            refData.EnterpriseCode = (string)row[DCJUT04102AC.ct_Col_EnterpriseCode]; // ��ƃR�[�h
            refData.AcptAnOdrStatus = (Int32)row[DCJUT04102AC.ct_Col_AcptAnOdrStatus]; // �󒍃X�e�[�^�X
            refData.SalesSlipNum = (string)row[DCJUT04102AC.ct_Col_SalesSlipNum]; // ����`�[�ԍ�
            refData.AcceptAnOrderNo = (Int32)row[DCJUT04102AC.ct_Col_AcceptAnOrderNo]; // �󒍔ԍ�
            refData.CommonSeqNo = (Int64)row[DCJUT04102AC.ct_Col_CommonSeqNo]; // ���ʒʔ�
            refData.SalesSlipDtlNum = (Int64)row[DCJUT04102AC.ct_Col_SalesSlipDtlNum]; // ���㖾�גʔ�
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_CustomerCode].ToString()))
            {
                refData.CustomerCode = Int32.Parse(row[DCJUT04102AC.ct_Col_CustomerCode].ToString()); // ���Ӑ�R�[�h
            }
            else
            {
                refData.CustomerCode = 0;
            }
            refData.CustomerSnm = (string)row[DCJUT04102AC.ct_Col_CustomerSnm]; // ���Ӑ旪��
            refData.SalesEmployeeNm = (string)row[DCJUT04102AC.ct_Col_SalesEmployeeNm]; // �̔��]�ƈ�����
            refData.AddresseeName = (string)row[DCJUT04102AC.ct_Col_AddresseeName]; // �[�i�於��
            refData.AddresseeName2 = (string)row[DCJUT04102AC.ct_Col_AddresseeName2]; // �[�i�於��2
            refData.FrontEmployeeNm = (string)row[DCJUT04102AC.ct_Col_FrontEmployeeNm]; // ��t�]�ƈ�����
            refData.SalesDate = (DateTime)row[DCJUT04102AC.ct_Col_SalesDate]; // ������t
            refData.GoodsNo = (string)row[DCJUT04102AC.ct_Col_GoodsNo]; // ���i�ԍ�
            refData.GoodsName = (string)row[DCJUT04102AC.ct_Col_GoodsName]; // ���i����
            refData.MakerName = (string)row[DCJUT04102AC.ct_Col_MakerName]; // ���[�J�[����
            refData.AcceptAnOrderCnt = (Double)row[DCJUT04102AC.ct_Col_AcceptAnOrderCnt]; // �󒍐���
            refData.AcptAnOdrRemainCnt = (Double)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt]; // �󒍎c��
            //refData.UnitName = (string)row[DCJUT04102AC.ct_Col_UnitName]; // �P�ʖ���
            refData.SalesUnPrcTaxExcFl = (Double)row[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl]; // ����P���i�Ŕ��C�����j
            //refData.BargainNm = (string)row[DCJUT04102AC.ct_Col_BargainNm]; // �����敪����
            refData.PartySlipNumDtl = (string)row[DCJUT04102AC.ct_Col_PartySlipNumDtl]; // �����`�[�ԍ��i���ׁj
            refData.StdUnPrcSalUnPrc = (Double)row[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc]; // ��P���i����P���j
            refData.SalesUnitCost = (Double)row[DCJUT04102AC.ct_Col_SalesUnitCost]; // �����P��
            refData.SupplierSnm = (string)row[DCJUT04102AC.ct_Col_SupplierSnm]; // �d���旪��
            refData.DtlNote = (string)row[DCJUT04102AC.ct_Col_DtlNote]; // ���ה��l
            //refData.CustomerDeliveryDate = (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate]; // �q��[��
            refData.SlipMemo1 = (string)row[DCJUT04102AC.ct_Col_SlipMemo1]; // �`�[�����P
            refData.SlipMemo2 = (string)row[DCJUT04102AC.ct_Col_SlipMemo2]; // �`�[�����Q
            refData.SlipMemo3 = (string)row[DCJUT04102AC.ct_Col_SlipMemo3]; // �`�[�����R
            //refData.SlipMemo4 = (string)row[DCJUT04102AC.ct_Col_SlipMemo4]; // �`�[�����S
            //refData.SlipMemo5 = (string)row[DCJUT04102AC.ct_Col_SlipMemo5]; // �`�[�����T
            //refData.SlipMemo6 = (string)row[DCJUT04102AC.ct_Col_SlipMemo6]; // �`�[�����U
            refData.InsideMemo1 = (string)row[DCJUT04102AC.ct_Col_InsideMemo1]; // �Г������P
            refData.InsideMemo2 = (string)row[DCJUT04102AC.ct_Col_InsideMemo2]; // �Г������Q
            refData.InsideMemo3 = (string)row[DCJUT04102AC.ct_Col_InsideMemo3]; // �Г������R
            //refData.InsideMemo4 = (string)row[DCJUT04102AC.ct_Col_InsideMemo4]; // �Г������S
            //refData.InsideMemo5 = (string)row[DCJUT04102AC.ct_Col_InsideMemo5]; // �Г������T
            //refData.InsideMemo6 = (string)row[DCJUT04102AC.ct_Col_InsideMemo6]; // �Г������U
            //refData.SupplierFormal = (Int32)row[DCJUT04102AC.ct_Col_SupplierFormal]; // �d���`��
            //refData.StockSlipDtlNum = (Int64)row[DCJUT04102AC.ct_Col_StockSlipDtlNum]; // �d�����גʔ�
            //refData.OrderNumber = (string)row[DCJUT04102AC.ct_Col_OrderNumber]; // �����ԍ�
            //refData.ExpectDeliveryDate = (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate]; // ��]�[��
            //refData.DeliGdsCmpltDueDate = (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate]; // �[�i�����\���
            //refData.ArrivalGoodsDay = (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay]; // ���ד�
            //refData.StockCount = (Double)row[DCJUT04102AC.ct_Col_StockCount]; // �d����
            //refData.StockUnitPriceFl = (Double)row[DCJUT04102AC.ct_Col_StockUnitPriceFl]; // �d���P���i�Ŕ��C�����j
            refData.RowNoView = (Int32)row[DCJUT04102AC.ct_Col_RowNoView]; // �s��
            refData.SelectRowFlag = (bool)row[DCJUT04102AC.ct_Col_SelectRowFlag]; // �s�I���t���O
            //refData.AcptAnOdrRemainPrice = (Int64)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice]; // �󒍎c���z
            refData.MemoExistsMark = (string)row[DCJUT04102AC.ct_Col_MemoExistsMark]; // �����}�[�N
            refData.MemoExistsFlag = (bool)row[DCJUT04102AC.ct_Col_MemoExistsFlag]; // �����L�t���O
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_SupplierCd].ToString()))
            {
                refData.SupplierCd = Int32.Parse(row[DCJUT04102AC.ct_Col_SupplierCd].ToString());                    // �d����R�[�h
            }
            else
            {
                refData.SupplierCd = 0;
            }
            refData.WarehouseCode = (string)row[DCJUT04102AC.ct_Col_WarehouseCode];
            refData.WarehouseName = (string)row[DCJUT04102AC.ct_Col_WarehouseName];

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
            string salesSlipCdDtl = string.Empty;
            Int32 slipCd = 0;
            salesSlipCdDtl = (string)row[DCJUT04102AC.ct_Col_SalesSlipCdDtl];
            switch (salesSlipCdDtl)
            {
                case "����": slipCd = 0; break;
                case "�ԕi": slipCd = 1; break;
                case "�l��": slipCd = 2; break;
                case "����": slipCd = 3; break;
                case "���v": slipCd = 4; break;
                case "���": slipCd = 5; break;
            }
            refData.SalesSlipCdDtl = slipCd;

            if (row[DCJUT04102AC.ct_Col_SalesPriceConsTax] == DBNull.Value)
            {
                refData.SalesPriceConsTax = 0;
            }
            else
            {
                refData.SalesPriceConsTax = (Double)row[DCJUT04102AC.ct_Col_SalesPriceConsTax];//(long)row[DCJUT04102AC.ct_Col_SalesPriceConsTax];
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_BLGoodsCode].ToString()))
            {
                refData.BLGoodsCode = Int32.Parse(row[DCJUT04102AC.ct_Col_BLGoodsCode].ToString());
            }
            else
            {
                refData.BLGoodsCode = 0;
            }
            refData.ListPriceTaxExcFl = (Double)row[DCJUT04102AC.ct_Col_ListPriceTaxExc];
            refData.ShipmentCnt = (Double)row[DCJUT04102AC.ct_Col_ShipmentCnt];
            refData.CarMngCode = (string)row[DCJUT04102AC.ct_Col_CarMngCode];
            refData.ModelDesignationNo = (Int32)row[DCJUT04102AC.ct_Col_ModelDesignationNo];
            refData.CategoryNo = (Int32)row[DCJUT04102AC.ct_Col_CategoryNo];
            refData.ModelFullName = (string)row[DCJUT04102AC.ct_Col_ModelFullName];
            refData.SearchSlipDate = (DateTime)row[DCJUT04102AC.ct_Col_SearchSlipDate];
            refData.AddUpADate = (DateTime)row[DCJUT04102AC.ct_Col_AddUpADate];
            refData.SectionGuideNm = (string)row[DCJUT04102AC.ct_Col_SectionName];
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_ClaimCode].ToString()))
            {
                refData.ClaimCode = Int32.Parse(row[DCJUT04102AC.ct_Col_ClaimCode].ToString());
            }
            else
            {
                refData.ClaimCode = 0;
            }
            refData.ClaimSnm = (string)row[DCJUT04102AC.ct_Col_ClaimSnm];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

            return refData;
        }

        #endregion

        #region ��Public Method

        # region �� �f�[�^�r���[�̎擾 ��
        /// <summary>
        /// �f�[�^�r���[�擾�i�t�h�\���p�j
        /// </summary>
        /// <returns></returns>
        public DataView GetDataViewForDisplay()
        {
            if ( _displayDataView == null )
            {
                // �r���[�𐶐����ĕԂ�
                _displayDataView = new DataView( this._acptAnOdrRemainRefTable );
            }
            return _displayDataView;
        }
        # endregion �� �f�[�^�r���[�̎擾 ��

        /// <summary>
        /// �Ɖ�I���f�[�^���X�g�擾����
        /// </summary>
        /// <returns></returns>
        public List<AcptAnOdrRemainRefData> GetRefDataListOfSelected ()
        {
            // �r���[�𐶐����āA�I���ς݃t���O�Ńt�B���^��������
            DataView view = new DataView( this._acptAnOdrRemainRefTable );
            view.RowFilter = string.Format( "{0} = '{1}'", 
                                                DCJUT04102AC.ct_Col_SelectRowFlag, true );

            // �ԋp���X�g�̐���
            List<AcptAnOdrRemainRefData> refDataList = new List<AcptAnOdrRemainRefData>();
            foreach ( DataRowView rowView in view )
            {
                refDataList.Add( CopyToRefDataFromRow( rowView.Row ) );
            }

            return refDataList;
        }

        # region �� �s�I���`�F�b�N�ҏW ��
        /// <summary>
        /// �s�I���`�F�b�N�����ibool���]�j
        /// </summary>
        /// <param name="rowNo"></param>
        public void SetRowSelected ( int rowNo )
        {
            // �s���Ō���
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null ) return;

            // �`�F�b�N�lbool���]�Z�b�g
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = !(bool)row[DCJUT04102AC.ct_Col_SelectRowFlag];

            // �I���f�[�^�ύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �s�I���`�F�b�N����
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="rowSelected"></param>
        public void SetRowSelected ( int rowNo, bool rowSelected )
        {
            // �s���Ō���
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null ) return;

            // �`�F�b�N�l�Z�b�g
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = rowSelected;

            // �I���f�[�^�ύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �S�Ă̍s�̑I���`�F�b�N���Z�b�g
        /// </summary>
        public void SetRowSelectedAll ( bool rowSelected )
        {
            // �S�Ă̍s�̑I���`�F�b�N��ݒ�
            foreach ( DataRow row in this._acptAnOdrRemainRefTable.Rows )
            {
                row[DCJUT04102AC.ct_Col_SelectRowFlag] = rowSelected;
            }

            // �I���f�[�^�ύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        # endregion �� �s�I���`�F�b�N�ҏW ��

        # region �� �W�v�l�̎擾���� ��
        /// <summary>
        /// �I���ςݍs���擾����
        /// </summary>
        public int GetRowCountOfSelected ()
        {
            // �f�[�^�r���[�𐶐����āA�I���ς݃t���O�Ńt�B���^��������
            DataView view = new DataView( this._acptAnOdrRemainRefTable );
            view.RowFilter = string.Format( "{0} = '{1}'", 
                                                DCJUT04102AC.ct_Col_SelectRowFlag, true );
            // ������Ԃ�
            return view.Count;
        }
        # endregion �� �W�v�l�̎擾���� ��

        /// <summary>
		/// �����c�Ɖ� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int Search ( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn )
        {
            // ����f�[�^����
            List<AcptAnOdrRemainRefDataWork> retData;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            _displayDataView.RowFilter = CreateRowFilter( acptAnOdrRemainRefCndtn );

            // �����[�g�ɓn�����׏󋵂́u�O�F�S�āv�ŌŒ�ɂ���B�iUI�Ő��䂷��ׁj
            //acptAnOdrRemainRefCndtn.ArrivalStateDiv = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            int status = this.SearchDB( out retData, acptAnOdrRemainRefCndtn );

            // �e�[�u���N���A
            this.ClearTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�W�J����
                DevListData( acptAnOdrRemainRefCndtn, retData );

                // No.���1����Ԃ��J�����ɕ\������Ȃ���΂Ȃ�Ȃ�[9095]
                DataTable table = _displayDataView.ToTable();
                int rowCount = 1;
                foreach (DataRow row in table.Rows)
                {
                    int rowNo = (Int32)row[DCJUT04102AC.ct_Col_RowNoView];
                    DataRow[] orgRow = this._acptAnOdrRemainRefTable.Select("RowNoView = " + rowNo.ToString());
                    orgRow[0][DCJUT04102AC.ct_Col_RowNoDisplay] = rowCount;
                    rowCount++;
                }
                // [9095] end

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // �s�t�B���^�ɂ��f�[�^�Ȃ��ɂȂ����ꍇ
                    if (_displayDataView.Count <= 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }

        /// <summary>
        /// �s�t�B���^�����񐶐�
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn"></param>
        /// <returns></returns>
        private string CreateRowFilter( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn )
        {
            string filterText = string.Empty;

            //-----------------------------------------------------------
            // �󒍎c�� > 0 �݂̂�ΏۂƂ���
            //-----------------------------------------------------------

            // �󒍃X�e�[�^�X�ɂ���ăt�B���^��ω�������(�݌v�Ҏw��)
            // 2008.12.12 add start [9095]
            switch ( acptAnOdrRemainRefCndtn.AcpOdrStateDiv )
            {
                // �v��ςݕ�1
                case 1:
                    {
                        filterText = filterText = string.Format("{0} = 0", DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt);
                        break;
                    }
                // ���v�㕪
                case 2:
                    {
                        filterText = string.Format("{0} > 0", DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt);
                        break;
                    }
                // �S��
                default:
                    {
                        // �S��
                        filterText = string.Empty;
                        break;
                    }
            }
            // 2008.12.12 add end [9095]
            

            //-----------------------------------------------------------
            // ���׏�
            //-----------------------------------------------------------
            //switch ( acptAnOdrRemainRefCndtn.ArrivalStateDiv )
            //{
                // ���׍ς�
                //case 1:
                //    {
                //        if ( !string.IsNullOrEmpty( filterText ) )
                //        {
                //            filterText += " AND ";
                //        }
                //        // �����ԍ��Ȃ��@or�@���ד��Z�b�g�ς�
                //        filterText += string.Format( "{0} = '{1}' OR {2} <> '{3}'",
                //                                      DCJUT04102AC.ct_Col_OrderNumber, string.Empty,
                //                                      DCJUT04102AC.ct_Col_ArrivalGoodsDayView, string.Empty );
                //    }
                //    break;
                //// �����ׂ̂�
                //case 2:
                //    {
                //        if ( !string.IsNullOrEmpty( filterText ) )
                //        {
                //            filterText += " AND ";
                //        }
                //        // �����ԍ�����@and�@���ד����Z�b�g
                //        filterText += string.Format( "{0} <> '{1}' AND {2} = '{3}'",
                //                                      DCJUT04102AC.ct_Col_OrderNumber, string.Empty,
                //                                      DCJUT04102AC.ct_Col_ArrivalGoodsDayView, string.Empty );
                //    }
                //    break;
                // �S��
                //default:
                //    {
                //        //// �S��
                //        //filterText = string.Empty;
                //    }
                //    break;
            //}

            return filterText;
        }
        /// <summary>
        /// �f�[�^�W�J�����i�����[�gResultWork�@���@DataTable�j
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn"></param>
        /// <param name="retData"></param>
        private void DevListData ( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn, List<AcptAnOdrRemainRefDataWork> retData )
        {
            // �󒍓`�[�f�B�N�V���i���i�d���`�F�b�N�p�j<CommonSeqNo,RowIndex>
            Dictionary<Int64, int> salesSlipDic = new Dictionary<Int64, int>();

            // �e�[�u���i�[�ς�index
            int index = 0;

            // �`�[�ԍ�(�d��SEQ/�x��No)�ۑ�
            //string exSalesSlipNum = string.Empty;

            // �����[�gResultWork���璊�o
            foreach ( AcptAnOdrRemainRefDataWork refDataWork in retData )
            {
                Int64 seqNo = refDataWork.CommonSeqNo;
                //exSalesSlipNum = refDataWork.SalesSlipNum;

                if ( salesSlipDic.ContainsKey( seqNo ) )
                {
                    // �f�[�^�����݁��X�V
                    UpdateRowFromResultWork(salesSlipDic[seqNo], refDataWork);//, exSalesSlipNum);
                }
                else
                {
                    // �f�[�^���񑶍݁��ǉ�
                    AddDataRowFromResultWork(index, refDataWork);//, exSalesSlipNum);
                    salesSlipDic.Add( seqNo, index );

                    index++;
                }
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearTable()
        {
            // �e�[�u���N���A
            this._acptAnOdrRemainRefTable.Rows.Clear();

            // �I���f�[�^�ύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// ���o�����R�s�[�����i�t�h�����N���X�������[�g�����N���X�i����j�j
        /// </summary>
        /// <param name="cndtn"></param>
        /// <returns></returns>
        private AcptAnOdrRemainRefCndtnWork CopyToSalesCndtnWorkFromCndtn ( AcptAnOdrRemainRefCndtn cndtn )
        {
            AcptAnOdrRemainRefCndtnWork cndtnWork = new AcptAnOdrRemainRefCndtnWork();
            
            cndtnWork.EnterpriseCode = cndtn.EnterpriseCode; // ��ƃR�[�h
            cndtnWork.SectionCode = cndtn.SectionCode; // ���_�R�[�h
            //cndtnWork.SubSectionCode = cndtn.SubSectionCode; // ����R�[�h
            //cndtnWork.MinSectionCode = cndtn.MinSectionCode; // �ۃR�[�h
            cndtnWork.CustomerCode = cndtn.CustomerCode; // ���Ӑ�R�[�h
            cndtnWork.SalesInputCode = cndtn.SalesInputCode; // ������͎҃R�[�h
            cndtnWork.FrontEmployeeCd = cndtn.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            cndtnWork.SalesEmployeeCd = cndtn.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA MODIFY START
            cndtnWork.ClaimCode = cndtn.ClaimCode;  // ������R�[�h
            cndtnWork.GoodsNameSrchTyp = cndtn.GoodsNmVagueSrch; // �B�������t���O
            //if (cndtn.GoodsNmVagueSrch > 0)
            //{
            //    cndtnWork.GoodsNmVagueSrch = true;
            //}
            //else
            //{
            //    cndtnWork.GoodsNmVagueSrch = false;
            //}
            cndtnWork.St_SalesSlipNum = cndtn.St_SalesSlipNum; // �`�[�ԍ��i�J�n�j
            cndtnWork.Ed_SalesSlipNum = cndtn.Ed_SalesSlipNum; // �`�[�ԍ��i�I���j
            cndtnWork.AcpOdrStateDiv = cndtn.AcpOdrStateDiv; // �󒍏󋵃t���O
            cndtnWork.FullModel = cndtn.FullModel; // �i���^��
            cndtnWork.St_SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.St_SalesDate); // ������t(�J�n)
            cndtnWork.Ed_SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.Ed_SalesDate); // ������t(�I��)
            //cndtnWork.St_SearchSlipDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.St_SearchSlipDate); // �`�[����(�J�n)
            //cndtnWork.Ed_SearchSlipDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.Ed_SearchSlipDate); // �`�[����(�I��)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA MODIFY END
            cndtnWork.GoodsMakerCd = cndtn.GoodsMakerCd; // ���i���[�J�[�R�[�h
            cndtnWork.GoodsNo = cndtn.GoodsNo; // ���i�ԍ�
            // 2008.10.14 add start
            cndtnWork.GoodsNoSrchTyp = cndtn.GoodsNoSrchTyp;
            // 2008.10.14 add end
            cndtnWork.GoodsName = cndtn.GoodsName; // ���i����
            //cndtnWork.PartySlipNumDtl = cndtn.PartySlipNumDtl; // �����`�[�ԍ�(����)
            //cndtnWork.St_DeliGdsCmpltDueDate = cndtn.St_DeliGdsCmpltDueDate; // �[�i�����\���(�J�n)
            //cndtnWork.Ed_DeliGdsCmpltDueDate = cndtn.Ed_DeliGdsCmpltDueDate; // �[�i�����\���(�I��)
            //cndtnWork.ArrivalStateDiv = cndtn.ArrivalStateDiv; // ���׏󋵋敪
            //cndtnWork.St_ArrivalDate = cndtn.St_ArrivalDate; // ���ד�(�J�n)
            //cndtnWork.Ed_ArrivalDate = cndtn.Ed_ArrivalDate; // ���ד�(�I��)
            // 2008.12.12 add start [9101]
            cndtnWork.FullModelSrchTyp = cndtn.FullModelSrchTyp;
            // 2008.12.12 add end [9101]

            // --- ADD 2009/02/25 ��QID:7882�Ή�------------------------------------------------------>>>>>
            cndtnWork.St_SearchSlipDate = TDateTime.LongDateToDateTime(cndtn.St_SearchSlipDate);
            cndtnWork.Ed_SearchSlipDate = TDateTime.LongDateToDateTime(cndtn.Ed_SearchSlipDate);
            // --- ADD 2009/02/25 ��QID:7882�Ή�------------------------------------------------------<<<<<

            return cndtnWork;
        }
        
        /// <summary>
        /// ����f�[�^��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataWorkList">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="acptAnOdrRemainRefCndtn">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int SearchDB(out List<AcptAnOdrRemainRefDataWork> acptAnOdrRemainRefDataWorkList, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn)
        {
            try
            {
                int status;
                acptAnOdrRemainRefDataWorkList = new List<AcptAnOdrRemainRefDataWork>();

                // �I�����C���̏ꍇ�����[�g�擾
                // -- DEL 2010/05/25 ----------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 -----------------<<<
                    ArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)CopyToSalesCndtnWorkFromCndtn(acptAnOdrRemainRefCndtn);
                    object retObj = (object)retList;

                    //�`�[���擾
                    status = this._iAcptAnOdrRemainRefDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �ԋp���X�g�Ɋi�[
                        foreach (AcptAnOdrRemainRefDataWork acptAnOdrRemainRefDataForSalesWork in (CustomSerializeArrayList)retObj)
						{
							acptAnOdrRemainRefDataWorkList.Add(acptAnOdrRemainRefDataForSalesWork);
						}

                        // �i�[�ł��Ȃ���΃X�e�[�^�X������������
                        if ( acptAnOdrRemainRefDataWorkList.Count == 0 )
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                // -- DEL 2010/05/25 ------------------------>>>
                //}
                //else	// �I�t���C���̏ꍇ
                //{
                //    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                //    status = -1;
                //}
                // -- DEL 2010/05/25 ------------------------<<<

                // �I���f�[�^�ύX�C�x���g
                if ( this.SelectedDataChange != null )
                {
                    this.SelectedDataChange( this, new EventArgs() );
                }

                return status;
            }
            catch (Exception)
            {
                if ( this.StatusBarMessageSetting != null )
                {
                    this.StatusBarMessageSetting( this, MESSAGE_ErrResult );
                }

                acptAnOdrRemainRefDataWorkList = null;
                //�I�t���C������null���Z�b�g
                this._iAcptAnOdrRemainRefDB= null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

		/// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return employee.Name.Trim();
            }
            else
            {
                return "";
            }
        }

		/// <summary>
		/// ���[�J�[���̎擾����
		/// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
		public string GetName_FromGoodsMaker(int goodsMakerCd)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return makerUMnt.MakerName.Trim();
			}
			else
			{
				return "";
			}
		}

		/// <summary>
        /// ���i���̎擾����
        /// </summary>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsName">(�o��)���i����</param>
        /// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.20 TOKUNAGA ADD START
            string msg;
            int s = goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.20 TOKUNAGA ADD END
            
			goodsName = "";

            // ���i�R�[�h�݂̂̎w���
            GoodsCndtn cnd = new GoodsCndtn();
            cnd.EnterpriseCode = this._enterpriseCode;
            cnd.SectionCode = this._sectionCode;
            cnd.GoodsNo = goodsCode;
            if (this._makerCode != 0)
            {
                cnd.GoodsMakerCd = this._makerCode;
            }

            //int status = goodsAcs.Search(cnd, out goodsUnitDataList, out msg);
            //int status = goodsAcs.Read(this._enterpriseCode, this._sectionCode, goodsCode, out goodsUnitDataList);
            //int status = goodsAcs.SearchPartsFromGoodsNoForMst(cnd, out goodsUnitDataList, out msg);
            int status = goodsAcs.Search(cnd, out goodsUnitDataList, out msg);

            if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
            {
				goodsName = goodsUnitDataList[0].GoodsName;
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // �{�Ћ@�\���H
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }

		/// <summary>
		/// ���t��������擾���܂��B
		/// </summary>
		/// <param name="date">���t</param>
		/// <param name="format">�t�H�[�}�b�g������</param>
		/// <returns>���t������</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
        }

        # region �� �w��s�擾 ��
        /// <summary>
        /// �s�擾����
        /// </summary>
        /// <param name="rowNo"></param>
        public void GetRow( int rowNo )
        {
            // �s���Ō���
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null )
                return;

            // �`�F�b�N�lbool���]�Z�b�g
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = !(bool)row[DCJUT04102AC.ct_Col_SelectRowFlag];

            // �I���f�[�^�ύX�C�x���g
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }

        # endregion ��  ��

        # endregion

        # region �� public enum ��
        /// <summary>
        /// �d���`���@�񋓌^
        /// </summary>
        public enum SupplierFormalState
        {
            /// <summary>�d��</summary>
            Stock = 0,
            /// <summary>����</summary>
            Arrival = 1,
            /// <summary>����</summary>
            Order = 2,
        }
        # endregion �� public enum ��

    }
}

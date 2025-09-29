//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F����`�[�Ɖ�
// �v���O�����T�v   �F����`�[�̌����^�Ɖ���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009.01.29     �C�����e�F��QID:7552,10621�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/09     �C�����e�FMantis�y13052�zNo�̕t�ԕs���Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���N�n��
// �C����    2010/12/21     �C�����e�F�@����`�[���͂���N�����̐���ύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���R
// �C����    2011/07/18     �C�����e�F�񓚋敪�ǉ��Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���N�n��
// �C����    2011/11/11     �C�����e�FRedmine 26538�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���N�n��
// �C����    2011/11/16     �C�����e�FRedmine 26538�Ή�
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����`�[�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�[�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 980076 �Ȓ��@����Y</br>
    /// <br>Date       : 2007.06.13</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.06.13 men �V�K�쐬</br>
    /// <br>UpDate</br>
    /// <br>2009.01.29 30414 �E �K�j ��QID:7552,10621�Ή�</br>
    /// </remarks>
    public partial class SalesSlipSearchAcs
    {
        // --- ADD 2009/01/29 ��QID:7552�Ή�------------------------------------------------------>>>>>
        public enum ExtractSlipCdType : int
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>����</summary>
            Sales = 1,
            /// <summary>�ԕi</summary>
            Return = 2,
        }
        // --- ADD 2009/01/29 ��QID:7552�Ή�------------------------------------------------------<<<<<

        public SalesSlipSearchAcs()
        {
            this._iSearchSalesSlipDB = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
            this._dataSet = new SalesSlipDataSet();
            this._employeeAcs = new EmployeeAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            //this._carrierAcs = new CarrierAcs();
            //this._carrierEpAcs = new CarrierEpAcs();
            this._goodsAcs = new GoodsAcs();
            this._makerAcs = new MakerAcs();

            if (_employeeDictionary == null)
            {
                _employeeDictionary = new Dictionary<string, Employee>();
            }

            if (_customerDictionary == null)
            {
                _customerDictionary = new Dictionary<int, CustomerInfo>();
            }

            if (_goodsMakerDictionary == null)
            {
                _goodsMakerDictionary = new Dictionary<int, MakerUMnt>();
            }

            // 2008/04/16 Ahn �폜
            //if (_carrierDictionary == null)
            //{
            //    _carrierDictionary = new Dictionary<int, Carrier>();
            //}

            //if (_carrierEpDictionary == null)
            //{
            //    _carrierEpDictionary = new Dictionary<int, CarrierEp>();
            //}

        }

        ISearchSalesSlipDB _iSearchSalesSlipDB;
        private const string ct_DateFormat = "yyyy/MM/dd";
        private SalesSlipDataSet _dataSet;
        private EmployeeAcs _employeeAcs;
        private CustomerInfoAcs _customerInfoAcs;
        //private CarrierAcs _carrierAcs;
        //private CarrierEpAcs _carrierEpAcs;
        private GoodsAcs _goodsAcs;
        private MakerAcs _makerAcs;

        private static Dictionary<string, Employee> _employeeDictionary;
        private static Dictionary<int, CustomerInfo> _customerDictionary;
        private static Dictionary<int, MakerUMnt> _goodsMakerDictionary;
        //private static Dictionary<int, Carrier> _carrierDictionary;
        //private static Dictionary<int, CarrierEp> _carrierEpDictionary;

        // 2008.11.07 add start [7071]
        private int _rowNo = 0;
        // 2008.11.07 add end [7071]

        public SalesSlipDataSet DataSet
        {
            get { return _dataSet; }
        }

        public DataView DataView
        {
            get { return _dataSet.SalesSlip.DefaultView; }
        }

        /// <summary>
        /// ����f�[�^(�w�b�_�[)���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int Search(SalesSlipSearch para) // MEMO:��ʂ���͂��̃��\�b�h���Ă΂��
        {
            this._dataSet.SalesSlip.Rows.Clear();

            object returnSalesSlipSearchResult = null;
            SalesSlipSearchWork workPara = CreateParamDataFromUIData(para);

            int status = this._iSearchSalesSlipDB.Search(out returnSalesSlipSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipSearchResult is ArrayList)
                {
                    // 2008.11.07 add start [7071]
                    this._rowNo = 0;
                    // 2008.11.07 add end [7071]

                    foreach (SalesSlipSearchResultWork data in (ArrayList)returnSalesSlipSearchResult)
                    {
                        // 2008.11.07 add start [7071]
                        this._rowNo++;
                        // 2008.11.07 add end [7071]
                        this.CacheSalesSlipSearchResult(data);
                    }
                }
            }

            return status;
        }

        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------>>>>>
        public int Search(SalesSlipSearch para, int extractSlipCdType, bool showEstimateInput)
        {
            this._dataSet.SalesSlip.Rows.Clear();

            object returnSalesSlipSearchResult = null;
            SalesSlipSearchWork workPara = CreateParamDataFromUIData(para, extractSlipCdType, showEstimateInput);

            int status = this._iSearchSalesSlipDB.Search(out returnSalesSlipSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipSearchResult is ArrayList)
                {
                    this._rowNo = 0;

                    foreach (SalesSlipSearchResultWork data in (ArrayList)returnSalesSlipSearchResult)
                    {
                        // DEL 2009/04/09 ------>>>
                        //this._rowNo++;
                        //this.CacheSalesSlipSearchResult(data);
                        // DEL 2009/04/09 ------<<<

                        // ADD 2009/04/09 ------>>>
                        SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.FindByEnterpriseCodeSearchSlipNumAcptAnOdrStatus(data.EnterpriseCode, data.SalesSlipNum, data.AcptAnOdrStatus);
                        if (row == null)
                        {
                            // �`�[�ԍ��Ɠ`�[��ʂ̏d���Ȃ�
                            this._rowNo++;
                            this.CacheSalesSlipSearchResult(data);
                        }
                        // ADD 2009/04/09 ------<<<
                    }
                }
            }

            return status;
        }
        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------<<<<<

        /// <summary>
        /// ����f�[�^(����)���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
        //public int SearchDetail( SalesSlipDetailSearch para )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        public int SearchDetail( SalesSlipDetailSearch para, SalesSlipSearchResult slip )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
        {
            int status = 0;
            this._dataSet.SalesDetail.Rows.Clear();

            object returnSalesSlipDetailSearchResult = null;
            SalesSlipDetailSearchWork workPara = CreateDetailParamDataFromUIData(para);


            status = this._iSearchSalesSlipDB.SearchDetail(out returnSalesSlipDetailSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipDetailSearchResult is ArrayList)
                {
                    foreach (SalesSlipDetailSearchResultWork data in (ArrayList)returnSalesSlipDetailSearchResult)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                        //this.CacheSalesSlipDetailSearchResult(data);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                        this.CacheSalesSlipDetailSearchResult( data, slip );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// �����f�[�^�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        public int ReadInitData(string enterpriseCode)
        {
            // ���_�ݒ�}�X�^�擾
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            {
                this.CacheSecInfoSet(secInfoSet);
            }

            return 0;
        }

        /// <summary>
        /// ����f�[�^�e�[�u���̍s�����������܂��B
        /// </summary>
        public void Clear()
        {
            this._dataSet.SalesSlip.Rows.Clear();
        }

        /// <summary>
        /// ����f�[�^�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        private void CacheSalesSlipSearchResult(SalesSlipSearchResultWork data)
        {
            try
            {
                _dataSet.SalesSlip.AddSalesSlipRow(this.RowFromUIData(data));
            }
            catch (ConstraintException)
            {
#if False
				//SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.NewSalesSlipRow();
				SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.FindByEnterpriseCodeAcceptAnOrderNo(data.EnterpriseCode, data.AcceptAnOrderNo);
				this.SetRowFromUIData(ref row, data);
#endif
            }
        }

        /// <summary>
        /// ����f�[�^(����)�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
        //private void CacheSalesSlipDetailSearchResult(SalesSlipDetailSearchResultWork data)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        private void CacheSalesSlipDetailSearchResult( SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                //_dataSet.SalesDetail.AddSalesDetailRow(this.DetailRowFromUIData(data));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                _dataSet.SalesDetail.AddSalesDetailRow( this.DetailRowFromUIData( data, slip ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            }
            catch (ConstraintException)
            {
                //SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.NewSalesSlipRow();
                //SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.FindByEnterpriseCodeAcceptAnOrderNo(data.EnterpriseCode, data.AcceptAnOrderNo);
                //this.SetRowFromUIData(ref row, data);
            }
        }



        /// <summary>
        /// ����f�[�^�������ʃI�u�W�F�N�g���甄��f�[�^�������ʍs�N���X���擾���܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>����f�[�^�������ʍs�N���X</returns>
        private SalesSlipDataSet.SalesSlipRow RowFromUIData(SalesSlipSearchResultWork data)
        {
            SalesSlipDataSet.SalesSlipRow row = _dataSet.SalesSlip.NewSalesSlipRow();
            
            this.SetRowFromUIData(ref row, data);
            return row;
        }

        /// <summary>
        /// ����f�[�^(����)�������ʃI�u�W�F�N�g���甄��f�[�^�������ʍs�N���X���擾���܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>����f�[�^�������ʍs�N���X</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
        //private SalesSlipDataSet.SalesDetailRow DetailRowFromUIData(SalesSlipDetailSearchResultWork data)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        private SalesSlipDataSet.SalesDetailRow DetailRowFromUIData( SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
        {
            SalesSlipDataSet.SalesDetailRow row = _dataSet.SalesDetail.NewSalesDetailRow();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //this.SetDetailRowFromUIData(ref row, data);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            this.SetDetailRowFromUIData( ref row, data, slip );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            return row;
        }

        # region ���_���ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// ���_���ݒ�}�X�^�L���b�V������
        /// </summary>
        /// <param name="data">���_���ݒ�}�X�^���[�N�N���X</param>
        internal void CacheSecInfoSet(SecInfoSet data)
        {

            try
            {
                _dataSet.SecInfoSet.AddSecInfoSetRow(this.RowFromUIData(data));
            }
            catch (ConstraintException)
            {
                SalesSlipDataSet.SecInfoSetRow row = this._dataSet.SecInfoSet.FindBySectionCode(data.SectionCode);
                this.SetRowFromUIData(ref row, data);
            }
        }

        /// <summary>
        /// ���_�K�C�h���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_�K�C�h����</returns>
        public string GetName_FromSecInfoSet(string sectionCode)
        {
            SalesSlipDataSet.SecInfoSetRow row = this._dataSet.SecInfoSet.FindBySectionCode(sectionCode);

            if (row == null)
            {
                return "";
            }
            else
            {
                return row.SectionGuideNm;
            }
        }

        /// <summary>
        /// ���_���ݒ�}�X�^���[�N�����_���ݒ�}�X�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">���_���ݒ�}�X�^�s�N���X</param>
        /// <param name="data">���_���ݒ�}�X�^�I�u�W�F�N�g</param>
        internal void SetRowFromUIData(ref SalesSlipDataSet.SecInfoSetRow row, SecInfoSet data)
        {
            // ���_�R�[�h
            row.SectionCode = data.SectionCode;

            // ���_�K�C�h����
            row.SectionGuideNm = data.SectionGuideNm;
        }

        /// <summary>
        /// ���_���ݒ�}�X�^���[�N�N���X�����_���ݒ�}�X�^�s�N���X�ϊ�����
        /// </summary>
        /// <param name="secInfoSetWork">���_���ݒ�}�X�^�s�N���X</param>
        /// <returns>���_���ݒ�}�X�^���[�N�^�N���X</returns>
        internal SalesSlipDataSet.SecInfoSetRow RowFromUIData(SecInfoSet data)
        {
            SalesSlipDataSet.SecInfoSetRow row = _dataSet.SecInfoSet.NewSecInfoSetRow();

            this.SetRowFromUIData(ref row, data);
            return row;
        }
        # endregion

        /// <summary>
        /// �]�ƈ������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="data">�]�ƈ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int GetEmployee(string enterpriseCode, string employeeCode, out Employee data)
        {
            int status = 0;
            if (_employeeDictionary.ContainsKey(employeeCode.Trim()))
            {
                data = _employeeDictionary[employeeCode.Trim()];
            }
            else
            {
                status = this._employeeAcs.Read(out data, enterpriseCode, employeeCode);
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="data">���Ӑ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int GetCustomer(string enterpriseCode, int customerCode, out CustomerInfo data)
        {
            int status = 0;
            if (_customerDictionary.ContainsKey(customerCode))
            {
                data = _customerDictionary[customerCode];
            }
            else
            {
                status = this._customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out data);
            }

            return status;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        public int GetName_FromGoodsMaker(string enterpriseCode, int goodsMakerCd, out MakerUMnt data)
        {
            int status = 0;

            if (_goodsMakerDictionary.ContainsKey(goodsMakerCd))
            {
                data = _goodsMakerDictionary[goodsMakerCd];
            }
            else
            {
                status = _makerAcs.Read(out data, enterpriseCode, goodsMakerCd);
            }

            return status;
        }


        /// <summary>
        /// �L�����A���擾���܂��B
        /// </summary>
        /// <param name="carrierCode">�L�����A�R�[�h</param>
        /// <param name="data">�L�����A�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        // 2008/04/16 Ahn �폜
        //public int GetCarrier(int carrierCode, out Carrier data)
        //{
        //    int status = 0;
        //    if (_carrierDictionary.ContainsKey(carrierCode))
        //    {
        //        data = _carrierDictionary[carrierCode];
        //    }
        //    else
        //    {
        //        status = this._carrierAcs.Read(out data, carrierCode);
        //    }

        //    return status;
        //}

        /// <summary>
        /// ���Ǝ҂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="carrierEpCode">���Ǝ҃R�[�h</param>
        /// <param name="data">���Ǝ҃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        // 2008/04/16 Ahn �폜
        //public int GetCarrierEp(string enterpriseCode, int carrierEpCode, out CarrierEp data)
        //{
        //    int status = 0;
        //    if (_carrierEpDictionary.ContainsKey(carrierEpCode))
        //    {
        //        data = _carrierEpDictionary[carrierEpCode];
        //    }
        //    else
        //    {
        //        status = this._carrierEpAcs.Read(out data, enterpriseCode, carrierEpCode);
        //    }

        //    return status;
        //}

        /// <summary>
        /// ���i�����擾���܂��B
        /// </summary>
        /// <param name="owner">�Ăь��̃I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsUnitData">���i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(IWin32Window owner, string enterpriseCode, int makerCode, string goodsCode, out GoodsUnitData data)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            data = null;

            if (makerCode == 0)
            {
                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
                List<GoodsUnitData> goodsUnitDataList;
                string message;
                status = goodsSelectGuide.ReadGoods(owner, enterpriseCode, 0, goodsCode, out goodsUnitDataList, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    data = goodsUnitDataList[0];
                }
            }
            else
            {
                status = this._goodsAcs.Read(true, enterpriseCode, makerCode, goodsCode, out data);
            }

            return status;
        }

        /// <summary>
        /// ����f�[�^�������ʃ��[�N������f�[�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">����f�[�^�s�N���X</param>
        /// <param name="data">����f�[�^�������ʃ��[�N�I�u�W�F�N�g</param>
        private void SetRowFromUIData(ref SalesSlipDataSet.SalesSlipRow row, SalesSlipSearchResultWork data)    // MEMO:�������ʂ�ێ�
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //long salesTotalTaxInc = 0;
            //long salesSubtotalTax = 0;

            ////����Œ����E�c������
            //if ((data.SalesGoodsCd == 2) || (data.SalesGoodsCd == 4))
            //{
            //    salesTotalTaxInc = 0;
            //    salesSubtotalTax = data.SalesSubtotalTax;
            //}
            //else if ((data.SalesGoodsCd == 3) || (data.SalesGoodsCd == 5))
            //{
            //    salesTotalTaxInc = data.SalesTotalTaxInc;
            //    salesSubtotalTax = 0;
            //}
            //else
            //{
            //    salesTotalTaxInc = data.SalesTotalTaxExc;
            //    salesSubtotalTax = data.SalesSubtotalTax;
            //}

            //row.SalesTotalTaxExc = salesTotalTaxInc;
            //row.SalesSubtotalTax = salesSubtotalTax;
            //row.SalesTotalTaxInc = data.SalesTotalTaxInc;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // ����� �󎚑Ή�

            long salesTotalTaxExc;
            long salesSubtotalTax;
            long salesTotalTaxInc;

            // taxIsSum = true(�\������̂͊O�Ł{����), false(���ł̂�)
            bool taxIsSum;
            # region [taxIsSum]
            switch ( data.TotalAmountDispWayCd )
            {
                case 1:
                    {
                        // ���z�\������
                        taxIsSum = true;
                    }
                    break;
                case 0:
                default:
                    {
                        // ���z�\�����Ȃ�

                        switch ( data.ConsTaxLayMethod )
                        {
                            // 0:�`�[�P��
                            case 0:
                            // 1:���גP��
                            case 1:
                                {
                                    taxIsSum = true;
                                }
                                break;
                            // 2:�����e
                            case 2:
                            // 3:�����q
                            case 3:
                            // 9:��ې�
                            case 9:
                            default:
                                {
                                    taxIsSum = false;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if ( taxIsSum )
            {
                // �Ł��O�Ł{����
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalesSubtotalTax;
                salesTotalTaxInc = data.SalesTotalTaxInc;
            }
            else
            {
                // �Ł�����
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalAmntConsTaxInclu + data.SalesDisTtlTaxInclu;
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }

            # region [���㏤�i�敪]
            if ( (data.SalesGoodsCd == 2) || (data.SalesGoodsCd == 4) )
            {
                // 2:����Œ���,4:���|�p����Œ���
                salesTotalTaxExc = 0;
            }
            else if ( (data.SalesGoodsCd == 3) || (data.SalesGoodsCd == 5) )
            {
                // 3:�c������,5:���|�p�c������
                salesTotalTaxExc = salesTotalTaxInc;
                salesSubtotalTax = 0;
            }
            # endregion

            // �l���Z�b�g
            row.SalesTotalTaxExc = salesTotalTaxExc;
            row.SalesSubtotalTax = salesSubtotalTax;
            row.SalesTotalTaxInc = salesTotalTaxInc;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD


            row.RowNo = _rowNo;
            row.EnterpriseCode = data.EnterpriseCode;

            //row.AcceptAnOrderNo = data.AcceptAnOrderNo;
            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.AcptAnOdrStatusName = GetAcptAnOdrStatusName(data.AcptAnOdrStatus, data.EstimateDivide);
            row.SearchSlipNum = data.SalesSlipNum;
            //row.SalesSlipKind = data.SalesSlipKind;
            //row.SalesSlipKindName = GetSalesSlipKindName(data.SalesSlipKind);
            row.DebitNoteDiv = data.DebitNoteDiv;
            row.DebitNoteDivName = GetDebitNoteDivName(data.DebitNoteDiv);
            row.SalesSlipCd = data.SalesSlipCd;
            row.SalesSlipCdName = GetSalesSlipCdName(data.SalesSlipCd);
            //row.SalesFormal = data.SalesFormal;
            //row.SalesFormalCode = data.SalesFormalCode;
            //row.SalesFormalName = GetAcptAnOdrStatusName(data.AcptAnOdrStatus);
            //row.SalesInpSecCd = data.SalesInpSecCd;
            //row.SalesInpSecName = this.GetName_FromSecInfoSet(data.SalesInpSecCd);
            //row.DemandAddUpSecCd = data.DemandAddUpSecCd;
            //row.DemandAddUpSecName = this.GetName_FromSecInfoSet(data.DemandAddUpSecCd);
            //row.ResultsAddUpSecCd = data.ResultsAddUpSecCd;
            //row.ResultsAddUpSecName = this.GetName_FromSecInfoSet(data.ResultsAddUpSecCd);
            //row.EstimateDateString = GetDateTimeString(data.EstimateDate, ct_DateFormat);
            //row.AcceptAnOrderDateString = GetDateTimeString(data.AcceptAnOrderDate, ct_DateFormat);
            //row.DeliGdsCmpltDueDateString = GetDateTimeString(data.DeliGdsCmpltDueDate, ct_DateFormat);

            //if ((data.AcptAnOdrStatus == 10) || data.AcptAnOdrStatus == 11)
            //{
            //	row.SlipDateString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            //}
            //else
            //{
            //	row.SlipDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            //}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //row.SlipDateString = GetDateTimeString( data.SalesDate, ct_DateFormat );
            //row.ShipmentDayString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            //row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            //row.AddUpADateString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // �`�[���t (�`�[��ʂɏ]��(���ז�))
            if ( data.AcptAnOdrStatus == 40 )
            {
                // �ݏo �� �o�ד����Z�b�g����
                row.SlipDateString = GetDateTimeString( data.ShipmentDay, ct_DateFormat );
            }
            else
            {
                // �ݏo�ȊO �� ��������Z�b�g����
                row.SlipDateString = GetDateTimeString( data.SalesDate, ct_DateFormat );
            }

            // �o�ד�
            row.ShipmentDayString = GetDateTimeString( data.ShipmentDay, ct_DateFormat );
            // �����
            row.SalesDateString = GetDateTimeString( data.SalesDate, ct_DateFormat );
            // �v���
            row.AddUpADateString = GetDateTimeString( data.AddUpADate, ct_DateFormat );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            row.FrontEmployeeNm = data.FrontEmployeeNm;
            row.SalesEmployeeNm = data.SalesEmployeeNm;
            //row.WayToOrder = data.WayToOrder;
            //row.WayToOrderName = GetWayToOrderName(data.WayToOrder);
            row.AccRecDivCd = data.AccRecDivCd;
            row.AccRecDivName = GetAccRecDivName(data.AccRecDivCd);
            row.TotalAmountDispWayCd = data.TotalAmountDispWayCd;
            row.TotalAmountDispWayName = GetTotalAmountDispWayName(data.TotalAmountDispWayCd);
            //row.SalesSubtotalTaxInc = data.SalesSubtotalTaxInc;
            //row.SalesSubtotalTaxExc = data.SalesSubtotalTaxExc;
            //row.SalSubttlSubToTaxFre = data.SalSubttlSubToTaxFre;

            row.TotalCost = data.TotalCost;
            //row.ServiceDeposits = data.ServiceDeposits;
            row.SalesGoodsCd = data.SalesGoodsCd;
            row.SalesGoodsCdName = GetSalesGoodsCdName(data.SalesGoodsCd);
            //row.TaxAdjust = data.TaxAdjust;
            //row.BalanceAdjust = data.BalanceAdjust;
            //row.DemandableTtl = data.DemandableTtl;
            //row.ClaimCode = data.ClaimCode;
            //row.ClaimName = data.ClaimName1 + " " + data.ClaimName2;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            row.ClaimCode = data.ClaimCode;
            row.ClaimName = data.ClaimSnm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            row.CustomerCode = data.CustomerCode;
            row.CustomerName = data.CustomerName + " " + data.CustomerName2;
            //row.CorporateDivCode = data.CorporateDivCode;
            //row.CorporateDivCodeName = GetCorporateDivCodeName(data.CorporateDivCode);
            row.SlipNote = data.SlipNote;
            row.SlipNote2 = data.SlipNote2;
            //row.RegiProcDateString = GetDateTimeString(data.RegiProcDate, ct_DateFormat);
            //row.CashRegisterNo = data.CashRegisterNo;
            //row.PosReceiptNo = data.PosReceiptNo;

            row.SearchSlipDate = data.SearchSlipDate;
            row.EstimateDivide = data.EstimateDivide;

            row.DetailRowCount = data.DetailRowCount;
            //row.SalesSlipUpdatableName = GetSalesSlipUpdatableName(data.SalesSlipUpdatable);

            row.SectionName = data.SectionGuideNm;
            row.SubSectionName = data.SubSectionName;
            //row.MinSectionName = data.MinSectionName;

            //if (data.SalesSlipUpdatable == 1)		row.SalesSlipUpdatableName = "�X�V�\";
            //else if(data.SalesSlipUpdatable == 2)	row.SalesSlipUpdatableName = "�X�V�s��";
            //else	row.SalesSlipUpdatableName = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            // �V�K���ǉ�����
            row.InputAgenCd = data.InputAgenCd;
            row.InputAgenNm = data.InputAgenNm;
            row.SalesPrtTotalTaxInc = data.SalesPrtTotalTaxInc;
            row.SalesPrtTotalTaxExc = data.SalesPrtTotalTaxExc;
            row.SalesWorkTotalTaxInc = data.SalesWorkTotalTaxInc;
            row.SalesWorkTotalTaxExc = data.SalesWorkTotalTaxExc;
            row.SalesPrtSubttlInc = data.SalesPrtSubttlInc;
            row.SalesPrtSubttlExc = data.SalesPrtSubttlExc;
            row.SalesWorkSubttlInc = data.SalesWorkSubttlInc;
            row.SalesWorkSubttlExc = data.SalesWorkSubttlExc;
            row.SalesNetPrice = data.SalesNetPrice;
            row.SalesOutTax = data.SalesOutTax;
            row.ItdedPartsDisOutTax = data.ItdedPartsDisOutTax;
            row.ItdedPartsDisInTax = data.ItdedPartsDisInTax;
            row.ItdedWorkDisOutTax = data.ItdedWorkDisOutTax;
            row.ItdedWorkDisInTax = data.ItdedWorkDisInTax;
            row.ItdedSalesDisTaxFre = data.ItdedSalesDisTaxFre;
            row.PartsDiscountRate = data.PartsDiscountRate;
            row.RavorDiscountRate = data.RavorDiscountRate;
            row.OutputName = data.OutputName;
            row.CustSlipNo = data.CustSlipNo;
            row.SlipNote3 = data.SlipNote3;
            row.EstimateValidityDateString = GetDateTimeString(data.EstimateValidityDate, ct_DateFormat);
            row.PartsNoPrtCd = data.PartsNoPrtCd;
            row.OptionPringDivCd = data.OptionPringDivCd;
            row.RateUseCode = data.RateUseCode;

            // ���s��
            row.SalesInputCode = data.SalesInputCode;          // �R�[�h
            row.SalesInputName = data.SalesInputName;          // �\����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //// �ޕʌ^�� (�^���w��ԍ�+�ޕʔԍ�)
            //row.CategoryModel = data.ModelDesignationNo.ToString() + "-" + data.CategoryNo.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // �ޕʌ^�� (�^���w��ԍ�+�ޕʔԍ�)
            # region [�ޕʌ^�� 00000-0000]
            if ( data.ModelDesignationNo == 0 && data.CategoryNo == 0 )
            {
                row.CategoryModel = string.Empty;
            }
            else
            {
                row.CategoryModel = string.Empty;

                // �^���w��ԍ�
                if ( data.ModelDesignationNo == 0 )
                {
                    row.CategoryModel += new string( ' ', 5 );
                }
                else
                {
                    row.CategoryModel += data.ModelDesignationNo.ToString( "00000" );
                }

                // �n�C�t��
                row.CategoryModel += '-';

                // �ޕʔԍ�
                if ( data.CategoryNo == 0 )
                {
                }
                else
                {
                    row.CategoryModel += data.CategoryNo.ToString( "0000" );
                }
            }
            # endregion

            // �Ԏ햼��
            row.ModelFullName = data.ModelFullName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            // �^��
            row.FullModel = data.FullModel;
            // �v���
            row.AddUpADateString = GetDateTimeString(data.AddUpADate, ct_DateFormat);
            // ���}�[�N1
            row.UoeRemark1 = data.UoeRemark1;
            // �Ǘ��ԍ�
            row.CarMngCode = data.CarMngCode;
            // �`�[�敪
            // 2008.12.09 add start [8872]
            // ��������(data.EstimateDivide == 3)�̎��͋�
            if (data.EstimateDivide != 3)
            {
                switch (data.SalesSlipCd)
                {
                    case 0: //0:����
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            // 2008.12.09 modify start [8852]
                            row.SlipDivName = "��������";
                            //row.SlipDivName = "����";
                            // 2008.12.09 modify end [8852]
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|����";
                        }
                        break;

                    case 1: //1:�ԕi
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            // 2008.12.09 modify start [8852]
                            row.SlipDivName = "�����ԕi";
                            //row.SlipDivName = "�ԕi";
                            // 2008.12.09 modify end [8852]
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�ԕi";
                        }
                        break;

                    case 2: //2:�l��
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�l��";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�l��";
                        }
                        break;

                    case 100: //100:��������
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "��������";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|��������";
                        }
                        break;

                    case 101: //101:�����ԕi
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�����ԕi";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�����ԕi";
                        }
                        break;

                    case 102: //102:�����l��
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�����l��";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�����l��";
                        }
                        break;

                    default:
                        break;
                }
            }
            // 2008.12.09 add end [8872]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END
            row.SalesSlipSearchResultWork = data;

            // ADD 2008/11/05 �s��Ή�[7075] �Ǘ��ԍ����O���b�h�ɕ\������Ȃ� ---------->>>>>
            // UNDONE:�Ǘ��ԍ����f�[�^�Z�b�g�֓W�J
            Debug.WriteLine("�`�[�ԍ��F" + data.SalesSlipNum + " �Ǘ��ԍ��F" + data.CarMngCode);
            row.CarMngCode = data.CarMngCode;
            // ADD 2008/11/05 �s��Ή�[7075] �Ǘ��ԍ����O���b�h�ɕ\������Ȃ� ----------<<<<<
        }


        /// <summary>
        /// ����f�[�^�������ʃ��[�N������f�[�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">����f�[�^�s�N���X</param>
        /// <param name="data">����f�[�^�������ʃ��[�N�I�u�W�F�N�g</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
        //private void SetDetailRowFromUIData(ref SalesSlipDataSet.SalesDetailRow row, SalesSlipDetailSearchResultWork data)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/16</br>
        private void SetDetailRowFromUIData( ref SalesSlipDataSet.SalesDetailRow row, SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //long salesMoneyTaxInc = 0;
            //long salsePriceConsTax = 0;

            ////����Œ����E�c������
            //if ((data.SalesGoodsCd == 2) || (data.SalesGoodsCd == 4))
            //{
            //    salesMoneyTaxInc = 0;
            //    salsePriceConsTax = data.SalesMoneyTaxInc - data.SalesMoneyTaxExc;
            //}
            //else if ((data.SalesGoodsCd == 3) || (data.SalesGoodsCd == 5))
            //{
            //    salesMoneyTaxInc = data.SalesMoneyTaxInc;
            //    salsePriceConsTax = 0;
            //}
            //else
            //{
            //    salesMoneyTaxInc = data.SalesMoneyTaxExc;
            //    salsePriceConsTax = data.SalesMoneyTaxInc - data.SalesMoneyTaxExc;
            //}

            //row.SalesMoneyTaxExc = salesMoneyTaxInc;
            //row.SalesMoneyTaxInc = data.SalesMoneyTaxInc;
            //row.SalsePriceConsTax = salsePriceConsTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // ����� �󎚑Ή�

            long salesMoneyTaxExc;
            long salsePriceConsTax;
            long salesMoneyTaxInc;

            bool printTax = true;

            # region [printTax]
            switch ( GetTaxPrintType( slip ) )
            {
                case 0:
                default:
                    {
                        // �`�[�P�ʁi���ז��̏���ł͕\�����Ȃ��j
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // ���גP��/���z�\��
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // �����e�q�E��ېŁi�ېŋ敪�����ł̂ݕ\���j
                        // �ېŋ敪�i0:�ې�,1:��ې�,2:�ېŁi���Łj�j
                        switch ( data.TaxationDivCd )
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if ( printTax )
            {
                // �ŕ\��
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = data.SalesMoneyTaxInc - data.SalesMoneyTaxExc;
                salesMoneyTaxInc = data.SalesMoneyTaxInc;
            }
            else
            {
                // �Ŕ�\��
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = 0;
                salesMoneyTaxInc = salesMoneyTaxExc;
            }

            # region [���㏤�i�敪]
            if ( (slip.SalesGoodsCd == 2) || (slip.SalesGoodsCd == 4) )
            {
                // 2:����Œ���,4:���|�p����Œ���
                salesMoneyTaxExc = 0;
            }
            else if ( (slip.SalesGoodsCd == 3) || (slip.SalesGoodsCd == 5) )
            {
                // 3:�c������,5:���|�p�c������
                salesMoneyTaxExc = salesMoneyTaxInc;
                salsePriceConsTax = 0;
            }
            # endregion

            
            // �l���Z�b�g
            row.SalesMoneyTaxExc = salesMoneyTaxExc;
            row.SalsePriceConsTax = salsePriceConsTax;
            row.SalesMoneyTaxInc = salesMoneyTaxInc;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            //row.MemoExist = data.MemoExist;
            //row.MemoExistName = data.MemoExistName;
            //row.AcceptAnOrderNo = data.AcceptAnOrderNo;
            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.SalesSlipNum = data.SalesSlipNum;
            row.SalesRowNo = data.SalesRowNo;
            row.SectionCode = data.SectionCode;
            row.SubSectionCode = data.SubSectionCode;
            //row.MinSectionCode = data.MinSectionCode;

            //row.SalesDate = data.SalesDate;
            row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);

            row.CommonSeqNo = data.CommonSeqNo;
            row.SalesSlipDtlNum = data.SalesSlipDtlNum;
            row.AcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
            row.SalesSlipDtlNumSrc = data.SalesSlipDtlNumSrc;
            row.SalesSlipCdDtl = data.SalesSlipCdDtl;
            //row.ServiceSlipCd = data.ServiceSlipCd;
            //row.EstimateDtlDivide = data.EstimateDtlDivide;
            //row.SalesDepositsDiv = data.SalesDepositsDiv;
            //row.StockMngExistCd = data.StockMngExistCd;

            //row.DeliGdsCmpltDueDate = data.DeliGdsCmpltDueDate;
            row.DeliGdsCmpltDueDateString = GetDateTimeString(data.DeliGdsCmpltDueDate, ct_DateFormat);

            row.GoodsKindCode = data.GoodsKindCode;
            row.GoodsMakerCd = data.GoodsMakerCd;
            row.MakerName = data.MakerName;
            row.GoodsNo = data.GoodsNo;
            row.GoodsName = data.GoodsName;
            //row.GoodsSetDivCd = data.GoodsSetDivCd;
            //row.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
            //row.LargeGoodsGanreName = data.LargeGoodsGanreName;
            //row.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
            //row.MediumGoodsGanreName = data.MediumGoodsGanreName;
            //row.DetailGoodsGanreCode = data.DetailGoodsGanreCode;
            //row.DetailGoodsGanreName = data.DetailGoodsGanreName;
            row.BLGoodsCode = data.BLGoodsCode;
            row.BLGoodsFullName = data.BLGoodsFullName;
            row.EnterpriseGanreCode = data.EnterpriseGanreCode;
            row.EnterpriseGanreName = data.EnterpriseGanreName;
            row.WarehouseCode = data.WarehouseCode;
            row.WarehouseName = data.WarehouseName;
            row.WarehouseShelfNo = data.WarehouseShelfNo;
            row.SalesOrderDivCd = data.SalesOrderDivCd;
            //row.UnitCode = data.UnitCode;
            //row.UnitName = data.UnitName;
            row.GoodsRateRank = data.GoodsRateRank;
            row.CustRateGrpCode = data.CustRateGrpCode;
            //row.SuppRateGrpCode = data.SuppRateGrpCode;
            row.ListPriceRate = data.ListPriceRate;
            row.RateDivLPrice = data.RateDivLPrice;
            row.UnPrcCalcCdLPrice = data.UnPrcCalcCdLPrice;
            row.PriceCdLPrice = data.PriceCdLPrice;
            row.StdUnPrcLPrice = data.StdUnPrcLPrice;
            row.FracProcUnitLPrice = data.FracProcUnitLPrice;
            row.FracProcLPrice = data.FracProcLPrice;
            row.ListPriceTaxIncFl = data.ListPriceTaxIncFl;
            row.ListPriceTaxExcFl = data.ListPriceTaxExcFl;
            row.ListPriceChngCd = data.ListPriceChngCd;
            row.SalesRate = data.SalesRate;
            row.RateDivSalUnPrc = data.RateDivSalUnPrc;
            row.UnPrcCalcCdSalUnPrc = data.UnPrcCalcCdSalUnPrc;
            row.PriceCdSalUnPrc = data.PriceCdSalUnPrc;
            row.StdUnPrcSalUnPrc = data.StdUnPrcSalUnPrc;
            row.FracProcUnitSalUnPrc = data.FracProcUnitSalUnPrc;
            row.FracProcSalUnPrc = data.FracProcSalUnPrc;
            row.SalesUnPrcTaxIncFl = data.SalesUnPrcTaxIncFl;
            row.SalesUnPrcTaxExcFl = data.SalesUnPrcTaxExcFl;
            row.SalesUnPrcChngCd = data.SalesUnPrcChngCd;
            row.CostRate = data.CostRate;
            row.RateDivUnCst = data.RateDivUnCst;
            row.UnPrcCalcCdUnCst = data.UnPrcCalcCdUnCst;
            row.PriceCdUnCst = data.PriceCdUnCst;
            row.StdUnPrcUnCst = data.StdUnPrcUnCst;
            row.FracProcUnitUnCst = data.FracProcUnitUnCst;
            row.FracProcUnCst = data.FracProcUnCst;
            row.SalesUnitCost = data.SalesUnitCost;
            row.SalesUnitCostChngDiv = data.SalesUnitCostChngDiv;
            //row.BargainCd = data.BargainCd;
            //row.BargainNm = data.BargainNm;
            row.ShipmentCnt = data.ShipmentCnt;


            row.Cost = data.Cost;
            row.GrsProfitChkDiv = data.GrsProfitChkDiv;
            row.SalesGoodsCd = data.SalesGoodsCd;
            //row.TaxAdjust = data.TaxAdjust;
            //row.BalanceAdjust = data.BalanceAdjust;
            row.TaxationDivCd = data.TaxationDivCd;
            row.PartySlipNumDtl = data.PartySlipNumDtl;
            row.DtlNote = data.DtlNote;
            row.SupplierCd = data.SupplierCd;
            row.SupplierSnm = data.SupplierSnm;
            //row.ResultsAddUpSecCd = data.ResultsAddUpSecCd;
            row.OrderNumber = data.OrderNumber;
            row.AcceptAnOrderCnt = data.AcceptAnOrderCnt;
            row.AcptAnOdrAdjustCnt = data.AcptAnOdrAdjustCnt;
            row.AcptAnOdrRemainCnt = data.AcptAnOdrRemainCnt;
            row.SlipMemo1 = data.SlipMemo1;
            row.SlipMemo2 = data.SlipMemo2;
            row.SlipMemo3 = data.SlipMemo3;
            //row.SlipMemo4 = data.SlipMemo4;
            //row.SlipMemo5 = data.SlipMemo5;
            //row.SlipMemo6 = data.SlipMemo6;
            row.InsideMemo1 = data.InsideMemo1;
            row.InsideMemo2 = data.InsideMemo2;
            row.InsideMemo3 = data.InsideMemo3;
            //row.InsideMemo4 = data.InsideMemo4;
            //row.InsideMemo5 = data.InsideMemo5;
            //row.InsideMemo6 = data.InsideMemo6;
            row.BfListPrice = data.BfListPrice;
            row.BfSalesUnitPrice = data.BfSalesUnitPrice;
            row.BfUnitCost = data.BfUnitCost;
            //row.PrtGoodsNo = data.PrtGoodsNo;
            //row.PrtGoodsName = data.PrtGoodsName;
            //row.PrtGoodsMakerCd = data.PrtGoodsMakerCd;
            //row.PrtGoodsMakerNm = data.PrtGoodsMakerNm;
            //row.ContractDivCdDtl = data.ContractDivCdDtl;

            //row.CustomerCode = data.CustomerCode;
            //row.CustomerName = data.CustomerName;
            //row.CustomerName2 = data.CustomerName2;
            //row.CustomerSnm = data.CustomerSnm;
            //row.AddresseeCode = data.AddresseeCode;
            //row.AddresseeName = data.AddresseeName;
            //row.AddresseeName2 = data.AddresseeName2;
            //row.SalesInputCode = data.SalesInputCode;
            //row.SalesInputName = data.SalesInputName;
            //row.FrontEmployeeCd = data.FrontEmployeeCd;
            //row.FrontEmployeeNm = data.FrontEmployeeNm;
            //row.SalesEmployeeCd = data.SalesEmployeeCd;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            // �V�K���ǉ�
            row.SalesRowDerivNo = data.SalesRowDerivNo;
            row.GoodsSearchDivCd = data.GoodsSearchDivCd;
            row.GoodsLGroup = data.GoodsLGroup;
            row.GoodsLGroupName = data.GoodsLGroupName;
            row.GoodsMGroup = data.GoodsMGroup;
            row.GoodsMGroupName = data.GoodsMGroupName;
            row.BLGroupCode = data.BLGroupCode;
            row.BLGroupName = data.BLGroupName;
            row.PrtBLGoodsCode = data.PrtBLGoodsCode;
            row.PrtBLGoodsName = data.PrtBLGoodsName;
            row.SalesCode = data.SalesCode;
            row.SalesCdNm = data.SalesCdNm;
            row.WorkManHour = data.WorkManHour;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //row.SalsePriceConsTax = data.SalesPriceConsTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            row.WayToOrder = data.WayToOrder;

            // �������z(�����P�� * ���㐔)
            row.SalesUnitTotal = data.SalesUnitCost * data.AcceptAnOrderCnt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END
            // ---------------------- ADD START 2011/07/18 ���R ----------------->>>>>
            // 0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������
            if (data.AutoAnswerDivSCM == 0)
            {
                row.AutoAnswerDivSCM = "�ʏ�";
            }
            else if (data.AutoAnswerDivSCM == 1)
            {
                row.AutoAnswerDivSCM = "�蓮��";
            }
            else
            {
                row.AutoAnswerDivSCM = "������";
            }
            // ---------------------- ADD END   2011/07/18 ���R -----------------<<<<<

            //---ADD 2011/11/11 ------------------------------------------------------------->>>>>
            //�A�g���
            if (data.AcceptOrOrderKind == 0)
            {
                row.CooprtKind = "PCCforNS";
            }
            else if (data.AcceptOrOrderKind == 1)
            {
                row.CooprtKind = "BL�߰µ��ް";
            }
            else
            {
                row.CooprtKind = "�ʏ�";
            }
            //---ADD 2011/11/11 -------------------------------------------------------------<<<<<
            //---ADD 2011/11/16 ---------->>>>>
            if (data.AutoAnswerDivSCM == 0)
            {
                row.CooprtKind = "�ʏ�";
            }
            //---ADD 2011/11/16 ----------<<<<<

        }

        /// <summary>
        /// UI�f�[�^�I�u�W�F�N�g����p�����[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="data">UI�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�p�����[�^�I�u�W�F�N�g</returns>
        public static SalesSlipSearchWork CreateParamDataFromUIData(SalesSlipSearch data)
        {
            SalesSlipSearchWork work = new SalesSlipSearchWork();

            // 2008.11.18 modify start [7878]
            // �S��
            if (data.SalesSlipCd == -1)
            {
                // TODO �b��I�Ɂu�������ρv+�u�S�āv�̏ꍇ�͔���`�[�敪=0�ō쐬
                if (data.AcptAnOdrStatus == 16)
                {
                    work.SalesSlipCd = 0;
                }
                else
                {
                    work.SalesSlipCd = -1;
                }
                work.AccRecDivCd = -1;
            }
            // 2008.11.18 modify end [7878]
            //��������
            else if (data.SalesSlipCd == 100)
            {
                work.SalesSlipCd = 0;
                work.AccRecDivCd = 0;
            }
            //�����ԕi
            else if (data.SalesSlipCd == 101)
            {
                work.SalesSlipCd = 1;
                work.AccRecDivCd = 0;
            }
            //�|����E�|�ԕi
            else
            {
                work.SalesSlipCd = data.SalesSlipCd;
                work.AccRecDivCd = 1;
            }

            //�P������
            if (data.AcptAnOdrStatus == 15)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 2;
            }
            else if (data.AcptAnOdrStatus == 10)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 1;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // ��������
            else if ( data.AcptAnOdrStatus == 16 )
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 3;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            //���̑�
            else
            {
                work.AcptAnOdrStatus = data.AcptAnOdrStatus;
                work.EstimateDivide = 0;
            }

            work.ClaimCode = data.ClaimCode;
            work.CustomerCode = data.CustomerCode;
            work.EnterpriseCode = data.EnterpriseCode;
            work.FrontEmployeeCd = data.FrontEmployeeCd;
            work.SalesEmployeeCd = data.SalesEmployeeCd;
            work.GoodsMakerCd = data.GoodsMakerCd;
            work.GoodsNo = data.GoodsNo;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //if (data.AcptAnOdrStatus == 40)
            //{
            //    work.SalesDateSt = 0;
            //    work.SalesDateEd = 0;

            //    if (data.SalesDateSt == DateTime.MinValue) work.ShipmentDaySt = 0;
            //    else work.ShipmentDaySt  = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SalesDateSt);

            //    if (data.SalesDateEd == DateTime.MinValue) work.ShipmentDayEd = 0;
            //    else work.ShipmentDayEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SalesDateEd);
            //}
            //else
            //{
            //    if (data.SalesDateSt == DateTime.MinValue) work.SalesDateSt = 0;
            //    else work.SalesDateSt = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SalesDateSt);

            //    if (data.SalesDateEd == DateTime.MinValue) work.SalesDateEd = 0;
            //    else work.SalesDateEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SalesDateEd);

            //    work.ShipmentDaySt = 0;
            //    work.ShipmentDayEd = 0;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            work.SalesDateSt = GetLongDate( data.SalesDateSt );
            work.SalesDateEd = GetLongDate( data.SalesDateEd );
            work.ShipmentDaySt = GetLongDate( data.SalesDateSt ); // �o�ד���������ɔ�������Z�b�g
            work.ShipmentDayEd = GetLongDate( data.SalesDateEd ); // �o�ד���������ɔ�������Z�b�g
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            work.SalesInputCode = data.SalesInputCode;

            work.SalesSlipNumSt = data.SalesSlipNumSt;
            work.SalesSlipNumEd = data.SalesSlipNumEd;
            work.PartySaleSlipNum = data.PartySaleSlipNum;

            if (data.SearchSlipDateSt == DateTime.MinValue) work.SearchSlipDateSt = 0;
            else work.SearchSlipDateSt = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateSt);
            if (data.SearchSlipDateEd == DateTime.MinValue) work.SearchSlipDateEd = 0;
            else work.SearchSlipDateEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateEd);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //if ((data.SectionCode.Trim() == "000000"))
            //{
            //    work.SectionCode = "";
            //}
            //else
            //{
            //    work.SectionCode = data.SectionCode;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            try
            {
                if ( Int32.Parse( data.SectionCode.Trim() ) == 0 )
                {
                    work.SectionCode = string.Empty;
                }
                else
                {
                    work.SectionCode = data.SectionCode;
                }
            }
            catch
            {
                work.SectionCode = data.SectionCode;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            work.SubSectionCode = data.SubSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //work.FullModel = data.FullModel;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            // �^��*�Ή�
            string searchText;
            int searchType;
            GetSearchType( data.FullModel, out searchText, out searchType );
            work.FullModel = searchText;
            work.FullModelSrchTyp = searchType;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

            return work;
        }
        
        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="extractSlipCdType"></param>
        /// <param name="showEstimateInput"></param>
        /// <returns></returns>
        /// <br>Update Note      : 2010/12/21 ���N�n��</br>
        /// <br>                   �@����`�[���͂���N�����̐���ύX</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        public static SalesSlipSearchWork CreateParamDataFromUIData(SalesSlipSearch data, int extractSlipCdType, bool showEstimateInput)
        {
            SalesSlipSearchWork work = new SalesSlipSearchWork();

            // �S��
            if (data.SalesSlipCd == -1)
            {
                // TODO �b��I�Ɂu�������ρv+�u�S�āv�̏ꍇ�͔���`�[�敪=0�ō쐬
                if (data.AcptAnOdrStatus == 16)
                {
                    work.SalesSlipCd = 0;
                }
                else
                {
                    work.SalesSlipCd = -1;
                }
                work.AccRecDivCd = -1;
            }
            //��������
            else if (data.SalesSlipCd == 100)
            {
                work.SalesSlipCd = 0;
                work.AccRecDivCd = 0;
            }
            //�����ԕi
            else if (data.SalesSlipCd == 101)
            {
                work.SalesSlipCd = 1;
                work.AccRecDivCd = 0;
            }
            //�|����E�|�ԕi
            else
            {
                work.SalesSlipCd = data.SalesSlipCd;
                work.AccRecDivCd = 1;
            }

            //�P������
            if (data.AcptAnOdrStatus == 15)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 2;
            }
            else if (data.AcptAnOdrStatus == 10)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 1;
            }
            // ��������
            else if (data.AcptAnOdrStatus == 16)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 3;
            }
            //���̑�
            else
            {
                work.AcptAnOdrStatus = data.AcptAnOdrStatus;
                work.EstimateDivide = 0;
            }

            if (extractSlipCdType == 1)
            {
                work.SalesSlipCd = 0;
            }
            //---DEL 2010/12/21------------->>>>>
            //if (showEstimateInput == false)
            //{
            //    work.EstimateDivide = -1;
            //}
            //---DEL 2010/12/21-------------<<<<<
            work.ClaimCode = data.ClaimCode;
            work.CustomerCode = data.CustomerCode;
            work.EnterpriseCode = data.EnterpriseCode;
            work.FrontEmployeeCd = data.FrontEmployeeCd;
            work.SalesEmployeeCd = data.SalesEmployeeCd;
            work.GoodsMakerCd = data.GoodsMakerCd;
            work.GoodsNo = data.GoodsNo;

            work.SalesDateSt = GetLongDate(data.SalesDateSt);
            work.SalesDateEd = GetLongDate(data.SalesDateEd);
            work.ShipmentDaySt = GetLongDate(data.SalesDateSt); // �o�ד���������ɔ�������Z�b�g
            work.ShipmentDayEd = GetLongDate(data.SalesDateEd); // �o�ד���������ɔ�������Z�b�g

            work.SalesInputCode = data.SalesInputCode;

            work.SalesSlipNumSt = data.SalesSlipNumSt;
            work.SalesSlipNumEd = data.SalesSlipNumEd;
            work.PartySaleSlipNum = data.PartySaleSlipNum;

            //---ADD 2011/11/11 --------------------->>>>>
            work.AcceptOrOrderKind = data.AcceptOrOrderKind;
            work.AutoAnswerDivSCM = data.AutoAnswerDivSCM;
            //---ADD 2011/11/11 ---------------------<<<<<

            if (data.SearchSlipDateSt == DateTime.MinValue) work.SearchSlipDateSt = 0;
            else work.SearchSlipDateSt = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateSt);
            if (data.SearchSlipDateEd == DateTime.MinValue) work.SearchSlipDateEd = 0;
            else work.SearchSlipDateEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateEd);

            try
            {
                if (Int32.Parse(data.SectionCode.Trim()) == 0)
                {
                    work.SectionCode = string.Empty;
                }
                else
                {
                    work.SectionCode = data.SectionCode;
                }
            }
            catch
            {
                work.SectionCode = data.SectionCode;
            }
            work.SubSectionCode = data.SubSectionCode;
            // �^��*�Ή�
            string searchText;
            int searchType;
            GetSearchType(data.FullModel, out searchText, out searchType);
            work.FullModel = searchText;
            work.FullModelSrchTyp = searchType;

            return work;
        }
        // --- ADD 2009/01/29 ��QID:7552,10621�Ή�------------------------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <summary>
        /// ���t���l�擾����
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetLongDate( DateTime date )
        {
            if ( date == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

        /// <summary>
        /// UI�f�[�^�I�u�W�F�N�g����p�����[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="data">UI�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�p�����[�^�I�u�W�F�N�g</returns>
        public static SalesSlipDetailSearchWork CreateDetailParamDataFromUIData(SalesSlipDetailSearch data)
        {
            SalesSlipDetailSearchWork work = new SalesSlipDetailSearchWork();

            work.EnterpriseCode = data.EnterpriseCode;
            work.AcptAnOdrStatus = data.AcptAnOdrStatus;
            work.SalesSlipNum = data.SalesSlipNum;
            return work;
        }


        /// <summary>
        /// �p�����[�^�I�u�W�F�N�g����UI�f�[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="data">�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>UI�f�[�^�I�u�W�F�N�g</returns>
        public static SalesSlipSearchResult CreateUIDataFromParamData(SalesSlipSearchResultWork work)
        {
            SalesSlipSearchResult data = new SalesSlipSearchResult();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //data.EnterpriseCode = work.EnterpriseCode;
            ////data.AcceptAnOrderNo = work.AcceptAnOrderNo;
            //data.AcptAnOdrStatus = work.AcptAnOdrStatus;

            ////data.SearchSlipNum = work.SalesSlipNum;

            ////data.SalesSlipKind = work.SalesSlipKind;
            //data.DebitNoteDiv = work.DebitNoteDiv;
            //data.SalesSlipCd = work.SalesSlipCd;
            ////data.SalesFormal = work.SalesFormal;
            ////data.SalesFormalCode = work.SalesFormalCode;
            ////data.SalesFormalName = work.SalesFormalName;
            ////data.SalesInpSecCd = work.SalesInpSecCd;
            ////data.DemandAddUpSecCd = work.DemandAddUpSecCd;
            ////data.ResultsAddUpSecCd = work.ResultsAddUpSecCd;
            ////data.EstimateDate = work.EstimateDate;
            ////data.AcceptAnOrderDate = work.AcceptAnOrderDate;
            ////data.DeliGdsCmpltDueDate = work.DeliGdsCmpltDueDate;
            //data.ShipmentDay = work.ShipmentDay;
            //data.SalesDate = work.SalesDate;
            //data.AddUpADate = work.AddUpADate;
            //data.FrontEmployeeCd = work.FrontEmployeeCd;
            //data.FrontEmployeeNm = work.FrontEmployeeNm;
            //data.SalesEmployeeCd = work.SalesEmployeeCd;
            //data.SalesEmployeeNm = work.SalesEmployeeNm;
            ////data.WayToOrder = work.WayToOrder;
            //data.AccRecDivCd = work.AccRecDivCd;
            ////data.TotalAmountDispWayCd = work.TotalAmountDispWayCd;
            //data.SalesTotalTaxInc = work.SalesTotalTaxInc;
            //data.SalesTotalTaxExc = work.SalesTotalTaxExc;
            ////data.SalesSubtotalTaxInc = work.SalesSubtotalTaxInc;
            ////data.SalesSubtotalTaxExc = work.SalesSubtotalTaxExc;
            ////data.SalSubttlSubToTaxFre = work.SalSubttlSubToTaxFre;
            ////data.SalesSubtotalTax = work.SalesSubtotalTax;
            ////data.TotalCost = work.TotalCost;
            ////data.ServiceDeposits = work.ServiceDeposits;
            //data.SalesGoodsCd = work.SalesGoodsCd;
            ////data.TaxAdjust = work.TaxAdjust;
            ////data.BalanceAdjust = work.BalanceAdjust;
            ////data.DemandableTtl = work.DemandableTtl;
            ////data.ClaimCode = work.ClaimCode;
            ////data.ClaimName1 = work.ClaimName1;
            ////data.ClaimName2 = work.ClaimName2;
            //data.CustomerCode = work.CustomerCode;
            //data.CustomerName = work.CustomerName;
            //data.CustomerName2 = work.CustomerName2;
            ////data.CorporateDivCode = work.CorporateDivCode;
            //data.SlipNote = work.SlipNote;
            ////data.RegiProcDate = work.RegiProcDate;
            ////data.CashRegisterNo = work.CashRegisterNo;
            ////data.PosReceiptNo = work.PosReceiptNo;
            ////data.EnterpriseName = work.EnterpriseName;
            ////data.ResultsAddUpSecNm = work.ResultsAddUpSecNm;

            //data.SearchSlipDate = work.SearchSlipDate;
            //data.EstimateDivide = work.EstimateDivide;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //// �V�K���ǉ�����
            //data.InputAgenCd = work.InputAgenCd;
            //data.InputAgenNm = work.InputAgenNm;
            //data.SalesPrtTotalTaxInc = work.SalesPrtTotalTaxInc;
            //data.SalesPrtTotalTaxExc = work.SalesPrtTotalTaxExc;
            //data.SalesWorkTotalTaxInc = work.SalesWorkTotalTaxInc;
            //data.SalesWorkTotalTaxExc = work.SalesWorkTotalTaxExc;
            //data.SalesPrtSubttlInc = work.SalesPrtSubttlInc;
            //data.SalesPrtSubttlExc = work.SalesPrtSubttlExc;
            //data.SalesWorkSubttlInc = work.SalesWorkSubttlInc;
            //data.SalesWorkSubttlExc = work.SalesWorkSubttlExc;
            //data.SalesNetPrice = work.SalesNetPrice;
            //data.SalesOutTax = work.SalesOutTax;
            //data.ItdedPartsDisOutTax = work.ItdedPartsDisOutTax;
            //data.ItdedPartsDisInTax = work.ItdedPartsDisInTax;
            //data.ItdedWorkDisOutTax = work.ItdedWorkDisOutTax;
            //data.ItdedWorkDisInTax = work.ItdedWorkDisInTax;
            //data.ItdedSalesDisTaxFre = work.ItdedSalesDisTaxFre;
            //data.PartsDiscountRate = work.PartsDiscountRate;
            //data.RavorDiscountRate = work.RavorDiscountRate;
            //data.OutputName = work.OutputName;
            //data.CustSlipNo = work.CustSlipNo;
            //data.SlipNote3 = work.SlipNote3;
            //data.EstimateValidityDate = work.EstimateValidityDate;
            //data.PartsNoPrtCd = work.PartsNoPrtCd;
            //data.OptionPringDivCd = work.OptionPringDivCd;
            //data.RateUseCode = work.RateUseCode;


            //// �ޕʌ`���ԍ�(2���������ĕ\��)
            //data.CategoryNo         = work.CategoryNo;                  // �`���w��ԍ�
            //data.ModelDesignationNo = work.ModelDesignationNo;          // �ޕʔԍ�
            //data.FullModel          = work.FullModel;                   // �`��
            ////data.AddAddUpADateString   = GetDateTimeString(work.AddUpADate, ct_DateFormat);  // �v���
            //data.AddUpADate         = work.AddUpADate;                  // �v���
            //data.UoeRemark1         = work.UoeRemark1;                  // ���}�[�N1
            //data.CarMngCode         = work.CarMngCode;                  // �Ǘ��ԍ�

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            data.AccRecConsTax = work.AccRecConsTax;
            data.AccRecDivCd = work.AccRecDivCd;
            data.AcptAnOdrStatus = work.AcptAnOdrStatus;
            data.AddresseeAddr1 = work.AddresseeAddr1;
            data.AddresseeAddr3 = work.AddresseeAddr3;
            data.AddresseeAddr4 = work.AddresseeAddr4;
            data.AddresseeCode = work.AddresseeCode;
            data.AddresseeFaxNo = work.AddresseeFaxNo;
            data.AddresseeName = work.AddresseeName;
            data.AddresseeName2 = work.AddresseeName2;
            data.AddresseePostNo = work.AddresseePostNo;
            data.AddresseeTelNo = work.AddresseeTelNo;
            data.AddUpADate = work.AddUpADate;
            data.AutoDepositCd = work.AutoDepositCd;
            data.AutoDepositSlipNo = work.AutoDepositSlipNo;
            data.BusinessTypeCode = work.BusinessTypeCode;
            data.BusinessTypeName = work.BusinessTypeName;
            data.CarMngCode = work.CarMngCode;
            data.CashRegisterNo = work.CashRegisterNo;
            data.CategoryNo = work.CategoryNo;
            data.ClaimCode = work.ClaimCode;
            data.ClaimSnm = work.ClaimSnm;
            data.CompleteCd = work.CompleteCd;
            data.ConsTaxLayMethod = work.ConsTaxLayMethod;
            data.ConsTaxRate = work.ConsTaxRate;
            data.CustomerCode = work.CustomerCode;
            data.CustomerName = work.CustomerName;
            data.CustomerName2 = work.CustomerName2;
            data.CustomerSnm = work.CustomerSnm;
            data.CustSlipNo = work.CustSlipNo;
            data.DebitNLnkSalesSlNum = work.DebitNLnkSalesSlNum;
            data.DebitNoteDiv = work.DebitNoteDiv;
            data.DelayPaymentDiv = work.DelayPaymentDiv;
            data.DeliveredGoodsDiv = work.DeliveredGoodsDiv;
            data.DeliveredGoodsDivNm = work.DeliveredGoodsDivNm;
            data.DemandAddUpSecCd = work.DemandAddUpSecCd;
            data.DepositAllowanceTtl = work.DepositAllowanceTtl;
            data.DepositAlwcBlnce = work.DepositAlwcBlnce;
            data.DetailRowCount = work.DetailRowCount;
            data.EdiSendDate = work.EdiSendDate;
            data.EdiTakeInDate = work.EdiTakeInDate;
            data.EnterpriseCode = work.EnterpriseCode;
            data.EraNameDispCd1 = work.EraNameDispCd1;
            data.EstimaTaxDivCd = work.EstimaTaxDivCd;
            data.EstimateDivide = work.EstimateDivide;
            data.EstimateFormNo = work.EstimateFormNo;
            data.EstimateFormPrtCd = work.EstimateFormPrtCd;
            data.EstimateNote1 = work.EstimateNote1;
            data.EstimateNote2 = work.EstimateNote2;
            data.EstimateNote3 = work.EstimateNote3;
            data.EstimateNote4 = work.EstimateNote4;
            data.EstimateNote5 = work.EstimateNote5;
            data.EstimateSubject = work.EstimateSubject;
            data.EstimateTitle1 = work.EstimateTitle1;
            data.EstimateTitle2 = work.EstimateTitle2;
            data.EstimateTitle3 = work.EstimateTitle3;
            data.EstimateTitle4 = work.EstimateTitle4;
            data.EstimateTitle5 = work.EstimateTitle5;
            data.EstimateValidityDate = work.EstimateValidityDate;
            data.Footnotes1 = work.Footnotes1;
            data.Footnotes2 = work.Footnotes2;
            data.FractionProcCd = work.FractionProcCd;
            data.FrontEmployeeCd = work.FrontEmployeeCd;
            data.FrontEmployeeNm = work.FrontEmployeeNm;
            data.FullModel = work.FullModel;
            data.HonorificTitle = work.HonorificTitle;
            data.InputAgenCd = work.InputAgenCd;
            data.InputAgenNm = work.InputAgenNm;
            data.ItdedPartsDisInTax = work.ItdedPartsDisInTax;
            data.ItdedPartsDisOutTax = work.ItdedPartsDisOutTax;
            data.ItdedSalesDisInTax = work.ItdedSalesDisInTax;
            data.ItdedSalesDisOutTax = work.ItdedSalesDisOutTax;
            data.ItdedSalesDisTaxFre = work.ItdedSalesDisTaxFre;
            data.ItdedSalesInTax = work.ItdedSalesInTax;
            data.ItdedSalesOutTax = work.ItdedSalesOutTax;
            data.ItdedWorkDisInTax = work.ItdedWorkDisInTax;
            data.ItdedWorkDisOutTax = work.ItdedWorkDisOutTax;
            data.ListPricePrintDiv = work.ListPricePrintDiv;
            data.LogicalDeleteCode = work.LogicalDeleteCode;
            data.MakerFullName = work.MakerFullName;
            data.ModelDesignationNo = work.ModelDesignationNo;
            data.ModelFullName = work.ModelFullName;
            data.OptionPringDivCd = work.OptionPringDivCd;
            data.OrderNumber = work.OrderNumber;
            data.OutputName = work.OutputName;
            data.PartsDiscountRate = work.PartsDiscountRate;
            data.PartsNoPrtCd = work.PartsNoPrtCd;
            data.PartySaleSlipNum = work.PartySaleSlipNum;
            data.PosReceiptNo = work.PosReceiptNo;
            data.PureGoodsTtlTaxExc = work.PureGoodsTtlTaxExc;
            data.RateUseCode = work.RateUseCode;
            data.RavorDiscountRate = work.RavorDiscountRate;
            data.ReconcileFlag = work.ReconcileFlag;
            data.RegiProcDate = work.RegiProcDate;
            data.ResultsAddUpSecCd = work.ResultsAddUpSecCd;
            data.RetGoodsReason = work.RetGoodsReason;
            data.RetGoodsReasonDiv = work.RetGoodsReasonDiv;
            data.SalAmntConsTaxInclu = work.SalAmntConsTaxInclu;
            data.SalesAreaCode = work.SalesAreaCode;
            data.SalesAreaName = work.SalesAreaName;
            data.SalesDate = work.SalesDate;
            data.SalesDisOutTax = work.SalesDisOutTax;
            data.SalesDisTtlTaxExc = work.SalesDisTtlTaxExc;
            data.SalesDisTtlTaxInclu = work.SalesDisTtlTaxInclu;
            data.SalesEmployeeCd = work.SalesEmployeeCd;
            data.SalesEmployeeNm = work.SalesEmployeeNm;
            data.SalesGoodsCd = work.SalesGoodsCd;
            data.SalesInpSecCd = work.SalesInpSecCd;
            data.SalesInputCode = work.SalesInputCode;
            data.SalesInputName = work.SalesInputName;
            data.SalesNetPrice = work.SalesNetPrice;
            data.SalesOutTax = work.SalesOutTax;
            data.SalesPriceFracProcCd = work.SalesPriceFracProcCd;
            data.SalesPrtSubttlExc = work.SalesPrtSubttlExc;
            data.SalesPrtSubttlInc = work.SalesPrtSubttlInc;
            data.SalesPrtTotalTaxExc = work.SalesPrtTotalTaxExc;
            data.SalesPrtTotalTaxInc = work.SalesPrtTotalTaxInc;
            data.SalesSlipCd = work.SalesSlipCd;
            data.SalesSlipNum = work.SalesSlipNum;
            data.SalesSlipPrintDate = work.SalesSlipPrintDate;
            data.SalesSubtotalTax = work.SalesSubtotalTax;
            data.SalesSubtotalTaxExc = work.SalesSubtotalTaxExc;
            data.SalesSubtotalTaxInc = work.SalesSubtotalTaxInc;
            data.SalesTotalTaxExc = work.SalesTotalTaxExc;
            data.SalesTotalTaxInc = work.SalesTotalTaxInc;
            data.SalesWorkSubttlExc = work.SalesWorkSubttlExc;
            data.SalesWorkSubttlInc = work.SalesWorkSubttlInc;
            data.SalesWorkTotalTaxExc = work.SalesWorkTotalTaxExc;
            data.SalesWorkTotalTaxInc = work.SalesWorkTotalTaxInc;
            data.SalSubttlSubToTaxFre = work.SalSubttlSubToTaxFre;
            data.SearchSlipDate = work.SearchSlipDate;
            data.SectionCode = work.SectionCode;
            data.SectionGuideNm = work.SectionGuideNm;
            data.ShipmentDay = work.ShipmentDay;
            data.SlipAddressDiv = work.SlipAddressDiv;
            data.SlipNote = work.SlipNote;
            data.SlipNote2 = work.SlipNote2;
            data.SlipNote3 = work.SlipNote3;
            data.SlipPrintDivCd = work.SlipPrintDivCd;
            data.SlipPrintFinishCd = work.SlipPrintFinishCd;
            data.SlipPrtSetPaperId = work.SlipPrtSetPaperId;
            data.StockGoodsTtlTaxExc = work.StockGoodsTtlTaxExc;
            data.SubSectionCode = work.SubSectionCode;
            data.SubSectionName = work.SubSectionName;
            data.TotalAmountDispWayCd = work.TotalAmountDispWayCd;
            data.TotalCost = work.TotalCost;
            data.TtlAmntDispRateApy = work.TtlAmntDispRateApy;
            data.UoeRemark1 = work.UoeRemark1;
            data.UoeRemark2 = work.UoeRemark2;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            return data;
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

        /// <summary>
        /// ����`�[��ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="code">����`�[���</param>
        /// <returns>����`�[��ʖ���</returns>
        public static string GetSalesSlipKindName(int code)
        {
            switch (code)
            {
                case 10:
                    {
                        return "����";
                    }
                case 20:
                    {
                        return "����";
                    }
                case 21:
                    {
                        return "���،v��";
                    }
                case 30:
                    {
                        return "�ϑ�";
                    }
                case 31:
                    {
                        return "�ϑ��v��";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// �󒍃X�e�[�^�X���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�󒍃X�e�[�^�X</param>
        /// <returns>�󒍃X�e�[�^�X����</returns>
        public static string GetAcptAnOdrStatusName(int code, int estimateDivide)
        {
            switch (code)
            {
                case 10:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                        //return estimateDivide == 1 ? "����" : "�P������";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                        //return estimateDivide == 1 ? "����" : "�P������";
                        switch ( estimateDivide )
                        {
                            case 2:
                                return "�P������";
                            case 3:
                                return "��������";
                            case 1:
                            default:
                                return "����";
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                    }
                case 20:
                    {
                        return "��";
                    }
                case 30:
                    {
                        return "����";
                    }
                case 40:
                    {
                        return "�ݏo";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// �ԓ`�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�ԓ`�敪</param>
        /// <returns>�ԓ`�敪����</returns>
        public static string GetDebitNoteDivName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "���`";
                    }
                case 1:
                    {
                        return "�ԓ`";
                    }
                case 2:
                    {
                        return "����";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ����`�[�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">����`�[�敪</param>
        /// <returns>����`�[�敪����</returns>
        public static string GetSalesSlipCdName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "��������";
                    }
                case 1:
                    {
                        return "�����ԕi";
                    }
                case 2:
                    {
                        return "�l��";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// �������@���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�������@�R�[�h</param>
        /// <returns>�������@����</returns>
        public static string GetWayToOrderName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "�X��";
                    }
                case 1:
                    {
                        return "�d�b";
                    }
                case 2:
                    {
                        return "FAX";
                    }
                case 3:
                    {
                        return "�C���^�[�l�b�g";
                    }
                case 4:
                    {
                        return "�V�X�e���A��";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���|�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���|�敪</param>
        /// <returns>���|�敪����</returns>
        public static string GetAccRecDivName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "���|�Ȃ�";
                    }
                case 1:
                    {
                        return "���|����";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���z�\�����@�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���z�\�����@�敪</param>
        /// <returns>���z�\�����@�敪����</returns>
        public static string GetTotalAmountDispWayName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "���Ȃ�";
                    }
                case 1:
                    {
                        return "����";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���㏤�i�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���㏤�i�敪</param>
        /// <returns>���㏤�i�敪����</returns>
        public static string GetSalesGoodsCdName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "���i";
                    }
                case 1:
                    {
                        return "���i�O";
                    }
                case 2:
                    {
                        return "����Œ���";
                    }
                case 3:
                    {
                        return "�c������";
                    }
                case 4:
                    {
                        return "���|�p����Œ���";
                    }
                case 5:
                    {
                        return "���|�p�c������";
                    }
                case 10:
                    {
                        return "���|�p����Œ���(����)";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// �l�@�l�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�l�@�l�敪</param>
        /// <returns>�l�@�l�敪����</returns>
        public static string GetCorporateDivCodeName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "�l";
                    }
                case 1:
                    {
                        return "�@�l";
                    }
                case 2:
                    {
                        return "����@�l";
                    }
                case 3:
                    {
                        return "�Ǝ�";
                    }
                case 4:
                    {
                        return "�Ј�";
                    }
                default:
                    {
                        return "";
                    }
            }
        }


        /// <summary>
        /// ����f�[�^�X�V�s�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">����f�[�^�X�V�s�敪</param>
        /// <returns>����f�[�^�X�V�s�敪����</returns>
        public static string GetSalesSlipUpdatableName(int code)
        {
            switch (code)
            {
                case 1:
                    {
                        return "�X�V�\";
                    }
                case 2:
                    {
                        return "�X�V�s��";
                    }
                default:
                    {
                        return "";
                    }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
        /// <summary>
        /// �����񂠂��܂��������擾
        /// </summary>
        /// <param name="originText">���̓��͕�����</param>
        /// <param name="searchText">�����[�g�A�Z���u���ɓn������������</param>
        /// <param name="searchType">�����[�g�A�Z���u���ɓn�������^�C�v</param>
        /// <returns></returns>
        private static void GetSearchType( string originText, out string searchText, out int searchType )
        {
            searchText = originText;
            bool stLike = originText.StartsWith( "*" );
            bool edLike = originText.EndsWith( "*" );

            if ( stLike )
            {
                // �擪�� * ����菜��
                searchText = searchText.Substring( 1 );
            }
            if ( edLike )
            {
                // ������ * ����菜��
                searchText = searchText.Substring( 0, searchText.Length - 1 );
            }

            // �擪��������*����菜���Ă��܂�*������ꍇ��3:�����܂�
            if ( searchText.Contains( "*" ) )
            {
                searchText = searchText.Replace( "*", "" );
                searchType = 3;
                return;
            }


            // �����^�C�v�̔���
            if ( stLike )
            {
                if ( edLike )
                {
                    // 3:�����܂�
                    searchType = 3;
                }
                else
                {
                    // 2:�����v
                    searchType = 2;
                }
            }
            else
            {
                if ( edLike )
                {
                    // 1:�O����v
                    searchType = 1;
                }
                else
                {
                    // 0:���S��v
                    searchType = 0;
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <summary>
        /// ����ŕ\���^�C�v�擾
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType�i0:�`�[�P��, 1:���גP��/���z�\������, 2:�����e/�����q/��ېŁj</returns>
        private static int GetTaxPrintType( SalesSlipSearchResult slip )
        {
            // ���z�\�����@
            switch ( slip.TotalAmountDispWayCd )
            {
                case 1:
                    // ���z�\������
                    return 1;
                case 0:
                default:
                    {
                        // ���z�\�����Ȃ�

                        switch ( slip.ConsTaxLayMethod )
                        {
                            // 0:�`�[�P��
                            case 0:
                                return 0;
                            // 1:���גP��
                            case 1:
                                return 1;
                            // 2:�����e
                            case 2:
                            // 3:�����q
                            case 3:
                            // 9:��ې�
                            case 9:
                            default:
                                return 2;
                        }
                    }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
    }
}

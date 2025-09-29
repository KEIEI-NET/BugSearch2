using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 TrgtCompSalesRslt
    /// <summary>
    /// 					 �ڕW�p������уf�[�^
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 �ڕW�p������уf�[�^�t�@�C��</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007/04/27  (CSharp File Generated Date)</br>
	/// <br>Update Note		 :   2007.11.21 ��� �O�M</br>
	/// <br>                     ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
    /// <br></br>
    /// </remarks>
    public class TrgtCompSalesRslt
    {
        #region Private Member

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�ڕW�Δ�敪</summary>
        private Int32 _targetContrastCd;

        /// <summary>�����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

//----- ueno add---------- start 2007.11.21
		/// <summary>�]�ƈ��敪</summary>
		private Int32 _employeeDivCd;

		/// <summary>����R�[�h</summary>
		private Int32 _subSectionCode;

		/// <summary>�ۃR�[�h</summary>
		private Int32 _minSectionCode;

		/// <summary>�Ǝ�R�[�h</summary>
		private Int32 _businessTypeCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		private Int32 _salesAreaCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		///// <summary>����`��</summary>
		//private Int32 _salesFormal;

		///// <summary>�̔��`�ԃR�[�h</summary>
		//private Int32 _salesFormCode;

		///// <summary>�L�����A�R�[�h</summary>
		//private Int32 _carrierCode;

		///// <summary>�@��R�[�h</summary>
		//private string _cellphoneModelCode = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>������z</summary>
        private Int64 _salesmonyTaxExc;

        /// <summary>���㌴��</summary>
        private Int64 _cost;

		//----- ueno del---------- start 2007.11.21
		///// <summary>���C���Z���e�B�u</summary>
		//private Int64 _insentiveRecv;

		///// <summary>�x���C���Z���e�B�u</summary>
		//private Int64 _insentiveDtbt;
		//----- ueno del---------- end   2007.11.21

        /// <summary>���㐔��</summary>
        private Double _salesCount;

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get
            {
                return _enterpriseCode;
            }
            set
            {
                _enterpriseCode = value;
            }
        }

        /// public propaty name  :	SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SectionCode
        {
            get
            {
                return _sectionCode;
            }
            set
            {
                _sectionCode = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	SalesDate
        /// <summary>������v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ������v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get
            {
                return _salesDate;
            }
            set
            {
                _salesDate = value;
            }
        }

        /// public propaty name  :	SalesDateJpFormal
        /// <summary>����� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����� �a��v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateJpInFormal
        /// <summary>����� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����� �a��(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateAdFormal
        /// <summary>����� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����� ����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateAdInFormal
        /// <summary>����� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����� ����(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EmployeeCode
        {
            get
            {
                return _employeeCode;
            }
            set
            {
                _employeeCode = value;
            }
        }

//----- ueno add---------- start 2007.11.21
		/// public propaty name  :	EmployeeDivCd
		/// <summary>�]�ƈ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �]�ƈ��敪�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 EmployeeDivCd
		{
			get
			{
				return _employeeDivCd;
			}
			set
			{
				_employeeDivCd = value;
			}
		}

		/// public propaty name  :	SubSectionCode
		/// <summary>����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ����R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 SubSectionCode
		{
			get
			{
				return _subSectionCode;
			}
			set
			{
				_subSectionCode = value;
			}
		}

		/// public propaty name  :	MinSectionCode
		/// <summary>�ۃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ۃR�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 MinSectionCode
		{
			get
			{
				return _minSectionCode;
			}
			set
			{
				_minSectionCode = value;
			}
		}

		/// public propaty name  :	BusinessTypeCode
		/// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �Ǝ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 BusinessTypeCode
		{
			get
			{
				return _businessTypeCode;
			}
			set
			{
				_businessTypeCode = value;
			}
		}

		/// public propaty name  :	SalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get
			{
				return _salesAreaCode;
			}
			set
			{
				_salesAreaCode = value;
			}
		}

		/// public propaty name  :	CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get
			{
				return _customerCode;
			}
			set
			{
				_customerCode = value;
			}
		}
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		#region del
		///// public propaty name  :	SalesFormal
		///// <summary>����`���v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 ����`���v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormal
		//{
		//    get
		//    {
		//        return _salesFormal;
		//    }
		//    set
		//    {
		//        _salesFormal = value;
		//    }
		//}

		///// public propaty name  :	SalesFormCode
		///// <summary>�̔��`�ԃR�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �̔��`�ԃR�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormCode
		//{
		//    get
		//    {
		//        return _salesFormCode;
		//    }
		//    set
		//    {
		//        _salesFormCode = value;
		//    }

		//}

		///// public propaty name  :	CarrierCode
		///// <summary>�L�����A�R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �]�ƈ��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int32 CarrierCode
		//{
		//    get
		//    {
		//        return _carrierCode;
		//    }
		//    set
		//    {
		//        _carrierCode = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelCode
		///// <summary>�@��R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �@��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelCode
		//{
		//    get
		//    {
		//        return _cellphoneModelCode;
		//    }
		//    set
		//    {
		//        _cellphoneModelCode = value;
		//    }
		//}
        #endregion del
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public int MakerCode
        {
            get
            {
                return _makerCode;
            }
            set
            {
                _makerCode = value;
            }
        }

        /// public propaty name  :	GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsCode
        {
            get
            {
                return _goodsCode;
            }
            set
            {
                _goodsCode = value;
            }
        }

        /// public propaty name  :	SalesmonyTaxExc
        /// <summary>������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	������z�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesmonyTaxExc
        {
            get
            {
                return _salesmonyTaxExc;
            }
            set
            {
                _salesmonyTaxExc = value;
            }
        }

        /// public propaty name  :	Cost
        /// <summary>���㌴���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���㌴���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

		//----- ueno del---------- start 2007.11.21
		#region del
		///// public propaty name  :	InsentiveRecv
		///// <summary>���C���Z���e�B�u�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 ���C���Z���e�B�u�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int64 InsentiveRecv
		//{
		//    get
		//    {
		//        return _insentiveRecv;
		//    }
		//    set
		//    {
		//        _insentiveRecv = value;
		//    }
		//}

		///// public propaty name  :	InsentiveDtbt
		///// <summary>�x���C���Z���e�B�u�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �x���C���Z���e�B�u�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int64 InsentiveDtbt
		//{
		//    get
		//    {
		//        return _insentiveDtbt;
		//    }
		//    set
		//    {
		//        _insentiveDtbt = value;
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	SalesCount
        /// <summary>���㐔�ʃv���p�e�B</summary>
        /// <value>�����i���ԁA���j���i���ח\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���㐔�ʃv���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double SalesCount
        {
            get
            {
                return _salesCount;
            }
            set
            {
                _salesCount = value;
            }
        }
        #endregion Public Propaty

        #region �R���X�g���N�^
        /// <summary>
        /// �ڕW�p������уf�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>TrgtCompSalesRslt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt()
        {
        }


        /// <summary>
        /// �ڕW�p������уf�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪</param>
        /// <param name="salesDate">�����(YYYYMMDD)</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employeeDivCd">�]�ƈ��敪</param>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="minSectionCode">�ۃR�[�h</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="salesmonyTaxExc">������z</param>
        /// <param name="trgtCompSalesRsltProfit">���㌴��</param>
        /// <param name="salesCount">���㐔��</param>
        /// <returns>TrgtCompSalesRslt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt(
            string enterpriseCode,
            string sectionCode,
            Int32 targetContrastCd,
            DateTime salesDate,
            string employeeCode,
//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			Int32 subSectionCode,
			Int32 minSectionCode,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//int salesFormal,
			//int salesFormCode,
			//Int32 carrierCode,
			//string cellphoneModelCode,
			//----- ueno del---------- end   2007.11.21
            int makerCode,
            string goodsCode,
            Int64 salesmonyTaxExc,
            Int64 trgtCompSalesRsltProfit,
			//----- ueno del---------- start 2007.11.21
			//Int64 insentiveRecv,
			//Int64 insentiveDtbt,
			//----- ueno del---------- end   2007.11.21
            Double salesCount
            )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._targetContrastCd = targetContrastCd;
            this._salesDate = salesDate;
            this._employeeCode = employeeCode;
//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormal = salesFormal;
			//this._salesFormCode = salesFormCode;
			//this._carrierCode = carrierCode;
			//this._cellphoneModelCode = cellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            this._makerCode = makerCode;
            this._goodsCode = goodsCode;
            this._salesmonyTaxExc = salesmonyTaxExc;
            this._cost = trgtCompSalesRsltProfit;
			//----- ueno del---------- start 2007.11.21
			//this._insentiveRecv = insentiveRecv;
			//this._insentiveDtbt = insentiveDtbt;
			//----- ueno del---------- end   2007.11.21
            this._salesCount = salesCount;
        }

        #endregion �R���X�g���N�^

        #region Public Method
        #region ���@�ڕW�p������уf�[�^��������
        /// <summary>
        /// �ڕW�p������уf�[�^��������
        /// </summary>
        /// <returns>TrgtCompSalesRslt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����TrgtCompSalesRslt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt Clone()
        {
            return new TrgtCompSalesRslt(
                               this._enterpriseCode,
                               this._sectionCode,
                               this._targetContrastCd,
                               this._salesDate,
                               this._employeeCode,
//----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   this._subSectionCode,
							   this._minSectionCode,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
//----- ueno add---------- end   2007.11.21
							   //----- ueno del---------- start 2007.11.21
							   //this._salesFormal,
							   //this._salesFormCode,
							   //this._carrierCode,
							   //this._cellphoneModelCode,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._goodsCode,
                               this._salesmonyTaxExc,
                               this._cost,
			  				   //----- ueno del---------- start 2007.11.21
							   //this._insentiveRecv,
							   //this._insentiveDtbt,
							   //----- ueno del---------- end   2007.11.21
                               this._salesCount
                               );
        }
        #endregion ���@�ڕW�p������уf�[�^��������

        #region ���@�ڕW�p������уf�[�^��r����(TrgtCompSalesRslt)
        /// <summary>
        /// �ڕW�p������уf�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TrgtCompSalesRslt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(TrgtCompSalesRslt target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.SalesDate == target.SalesDate)
                 && (this.EmployeeCode == target.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.SalesFormal == target.SalesFormal)
				 //&& (this.SalesFormCode == target.SalesFormCode)
				 //&& (this.CarrierCode == target.CarrierCode)
				 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.SalesmonyTaxExc == target.SalesmonyTaxExc)
                 && (this.Cost == target.Cost)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.InsentiveRecv == target.InsentiveRecv)
				 //&& (this.InsentiveDtbt == target.InsentiveDtbt)
				 //----- ueno del---------- end   2007.11.21
                 && (this.SalesCount == target.SalesCount)
                 );
        }
        #endregion ���@�ڕW�p������уf�[�^��r����

        #region ���@�ڕW�p������уf�[�^��r����(TrgtCompSalesRslt,ResvdDT)
        /// <summary>
        /// �ڕW�p������уf�[�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   ��r����TrgtCompSalesRslt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesMonTarget2">��r����TrgtCompSalesRslt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(TrgtCompSalesRslt salesMonTarget1, TrgtCompSalesRslt salesMonTarget2)
        {
            return ((salesMonTarget1.EnterpriseCode == salesMonTarget2.EnterpriseCode)
                 && (salesMonTarget1.SectionCode == salesMonTarget2.SectionCode)
                 && (salesMonTarget1.TargetContrastCd == salesMonTarget2.TargetContrastCd)
                 && (salesMonTarget1.SalesDate == salesMonTarget2.SalesDate)
                 && (salesMonTarget1.EmployeeCode == salesMonTarget2.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (salesMonTarget1.EmployeeDivCd == salesMonTarget2.EmployeeDivCd)
				 && (salesMonTarget1.SubSectionCode == salesMonTarget2.SubSectionCode)
				 && (salesMonTarget1.MinSectionCode == salesMonTarget2.MinSectionCode)
				 && (salesMonTarget1.BusinessTypeCode == salesMonTarget2.BusinessTypeCode)
				 && (salesMonTarget1.SalesAreaCode == salesMonTarget2.SalesAreaCode)
				 && (salesMonTarget1.CustomerCode == salesMonTarget2.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.SalesFormal == salesMonTarget2.SalesFormal)
				 //&& (salesMonTarget1.SalesFormCode == salesMonTarget2.SalesFormCode)
				 //&& (salesMonTarget1.CarrierCode == salesMonTarget2.CarrierCode)
				 //&& (salesMonTarget1.CellphoneModelCode == salesMonTarget2.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (salesMonTarget1.MakerCode == salesMonTarget2.MakerCode)
                 && (salesMonTarget1.GoodsCode == salesMonTarget2.GoodsCode)
                 && (salesMonTarget1.SalesmonyTaxExc == salesMonTarget2.SalesmonyTaxExc)
                 && (salesMonTarget1.Cost == salesMonTarget2.Cost)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.InsentiveRecv == salesMonTarget2.InsentiveRecv)
                 //&& (salesMonTarget1.InsentiveDtbt == salesMonTarget2.InsentiveDtbt)
				 //----- ueno del---------- end   2007.11.21
                 && (salesMonTarget1.SalesCount == salesMonTarget2.SalesCount)
                 );
        }
        #endregion ���@�ڕW�p������уf�[�^��r����(TrgtCompSalesRslt,ResvdDT)

        #region ���@�ڕW�p������уf�[�^��r���ʃ��X�g�쐬����(TrgtCompSalesRslt)
        /// <summary>
        /// �ڕW�p������уf�[�^��r���ʃ��X�g�쐬����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TrgtCompSalesRslt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(TrgtCompSalesRslt target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
//----- ueno add---------- start 2007.11.21
			if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
			if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
			if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
			if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (this.SalesFormal != target.SalesFormal) resList.Add("SalesFormal");
			//if (this.SalesFormCode != target.SalesFormCode) resList.Add("SalesFormCode");
			//if (this.CarrierCode != target.CarrierCode) resList.Add("CarrierCode");
			//if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//----- ueno del---------- end   2007.11.21
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.SalesmonyTaxExc != target.SalesmonyTaxExc) resList.Add("SalesmonyTaxExc");
            if (this.Cost != target.Cost) resList.Add("Cost");
			//----- ueno del---------- start 2007.11.21
			//if (this.InsentiveRecv != target.InsentiveRecv) resList.Add("InsentiveRecv");
			//if (this.InsentiveDtbt != target.InsentiveDtbt) resList.Add("InsentiveDtbt");
			//----- ueno del---------- end   2007.11.21
            if (this.SalesCount != target.SalesCount) resList.Add("SalesCount");

            return resList;
        }
        #endregion ���@�ڕW�p������уf�[�^��r���ʃ��X�g�쐬����(TrgtCompSalesRslt)

        #region ���@�ڕW�p������уf�[�^��r���ʃ��X�g�쐬����(TrgtCompSalesRslt,TrgtCompSalesRslt)
        /// <summary>
        /// �ڕW�p������уf�[�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">��r����TrgtCompSalesRslt�N���X�̃C���X�^���X</param>
        /// <param name="salesMonTarget2">��r����TrgtCompSalesRslt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 TrgtCompSalesRslt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(TrgtCompSalesRslt salesMonTarget1, TrgtCompSalesRslt salesMonTarget2)
        {
            ArrayList resList = new ArrayList();
            if (salesMonTarget1.EnterpriseCode != salesMonTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesMonTarget1.SectionCode != salesMonTarget2.SectionCode) resList.Add("SectionCode");
            if (salesMonTarget1.TargetContrastCd != salesMonTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (salesMonTarget1.SalesDate != salesMonTarget2.SalesDate) resList.Add("SalesDate");
            if (salesMonTarget1.EmployeeCode != salesMonTarget2.EmployeeCode) resList.Add("EmployeeCode");
//----- ueno add---------- start 2007.11.21
			if (salesMonTarget1.EmployeeDivCd != salesMonTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
			if (salesMonTarget1.SubSectionCode != salesMonTarget2.SubSectionCode) resList.Add("SubSectionCode");
			if (salesMonTarget1.MinSectionCode != salesMonTarget2.MinSectionCode) resList.Add("MinSectionCode");
			if (salesMonTarget1.BusinessTypeCode != salesMonTarget2.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (salesMonTarget1.SalesAreaCode != salesMonTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
			if (salesMonTarget1.CustomerCode != salesMonTarget2.CustomerCode) resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.SalesFormal != salesMonTarget2.SalesFormal) resList.Add("SalesFormal");
			//if (salesMonTarget1.SalesFormCode != salesMonTarget2.SalesFormCode) resList.Add("SalesFormCode");
			//if (salesMonTarget1.CarrierCode != salesMonTarget2.CarrierCode) resList.Add("CarrierCode");
			//if (salesMonTarget1.CellphoneModelCode != salesMonTarget2.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//----- ueno del---------- end   2007.11.21
            if (salesMonTarget1.MakerCode != salesMonTarget2.MakerCode) resList.Add("MakerCode");
            if (salesMonTarget1.GoodsCode != salesMonTarget2.GoodsCode) resList.Add("GoodsCode");
            if (salesMonTarget1.SalesmonyTaxExc != salesMonTarget2.SalesmonyTaxExc) resList.Add("SalesmonyTaxExc");
            if (salesMonTarget1.Cost != salesMonTarget2.Cost) resList.Add("Cost");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.InsentiveRecv != salesMonTarget2.InsentiveRecv) resList.Add("InsentiveRecv");
			//if (salesMonTarget1.InsentiveDtbt != salesMonTarget2.InsentiveDtbt) resList.Add("InsentiveDtbt");
			//----- ueno del---------- end   2007.11.21
            if (salesMonTarget1.SalesCount != salesMonTarget2.SalesCount) resList.Add("SalesCount");

            return resList;
        }
        #endregion ���@�ڕW�p������уf�[�^��r���ʃ��X�g�쐬����(TrgtCompSalesRslt,TrgtCompSalesRslt)

        #endregion Public Method

    }
}

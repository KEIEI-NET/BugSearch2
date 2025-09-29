using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���o�����
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o����</br>
	/// <br>Programmer	: 19077 �n� �M�T</br>
	/// <br>Date		: 2007.01.22</br>
	/// </remarks>
	public class MAZAI04310UB
	{
		#region Private Member
		private int _searchmode;            // �������[�h
		private string	_enterprisecode;    // ��ƃR�[�h
		private int		_customercode;      // �ڋq�R�[�h
		private int		_readCnt;           // �ǂݍ��݌���
		private int		_startCnt;          // �J�n����
        private int _carrierEp;             // ���Ǝ҃R�[�h
        private int _carrier;               // �L�����A
        private int _tde_st_IoGoodsDay;            // ���o�ד�(�J�n)
        private int _tde_ed_IoGoodsDay;         // ���o�ד�(�I��)
        private string _goodsCd;            // ���i�R�[�h
        private string _wareHouseCd;        // �q�ɃR�[�h
        private string _sectioncode;        // ���_�R�[�h
        private int _acpayslipcd;        // �`�[�敪
        private int _acpaytrancecd;      // ����敪
        private int _makercd;               // ���[�J�[�R�[�h
        private string _stocktellno;        // �g�єԍ�
        private string _productno;          // �����ԍ�

                    
		//private List<StockAcPayHist> _stockAcPayHistList;                 //DEL 2008/07/17 �g�p�N���X�ύX�̈�
        private List<StockAcPayHisSearchRet> _stockAcPayHisSearchRetList;   //ADD 2008/07/17
        private List<StockCarEnterCarOutRet> _stockCarEnterCarOutRetList;   //ADD 2008/07/17
        #endregion

		#region Property
		/// <summary>
		/// ���o���[�h
		/// </summary>
		internal int SearchMode
		{
			set{ this._searchmode = value; }
		}

		/// <summary>
		/// ��ƃR�[�h
		/// </summary>
		internal string EnterpriseCode
		{
			set{ this._enterprisecode = value; }
			get{ return this._enterprisecode; }
		}

		/// <summary>
		/// �d����R�[�h
		/// </summary>
		internal int CustomerCode
		{
			set{ this._customercode = value; }
			get{ return this._customercode; }
		}
		
		/// <summary>
        /// ���Ǝ�
        /// </summary>
        internal int CarrierEP
        {
            set { this._carrierEp = value; }
            get { return this._carrierEp; }
        }

        /// <summary>
        /// �L�����A
        /// </summary>
        internal int Carrier
        {
            set { this._carrier = value; }
            get { return this._carrier; }
        }
        
        /// <sammary>
        /// ���o�ד�
        /// </sammary>
        internal int tde_st_IoGoodsDay
        {
            set { this._tde_st_IoGoodsDay = value; }
            get { return this._tde_st_IoGoodsDay; }
        }

        /// <sammary>
        /// ���o�ד�
        /// </sammary>
        internal int tde_ed_IoGoodsDay
        {
            set
            {
                if (value > 1000)
                {
                    this._tde_ed_IoGoodsDay = value;
                }
                else
                {
                    this._tde_ed_IoGoodsDay = AddDays(tde_st_IoGoodsDay, value);
                }
            }
                  
            get { return this._tde_ed_IoGoodsDay; }
        }

        /// <summary>
        /// ���i�R�[�h
        /// </summary>
		internal string GoodsCd
		{
			set{ this._goodsCd = value; }
			get{ return this._goodsCd; }
		}

        /// <summary>
        /// �q�ɃR�[�h
        /// </summary>
        internal string WareHouse
        {
            set { this._wareHouseCd = value; }
            get { return this._wareHouseCd; }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        internal string SectionCd
        {
            set { this._sectioncode = value; }
            get { return this._sectioncode; }
        }

        /// <summary>
        /// �`�[�敪
        /// </summary>
        internal int AcPaySlipCd
        {
            set { this._acpayslipcd  = value; }
            get { return this._acpayslipcd; }
        }

        /// <summary>
        /// ����敪
        /// </summary>
        internal int AcPayTranceCd
        {
            set { this._acpaytrancecd = value; }
            get { return this._acpaytrancecd; }
        }
        
        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        internal int MakerCode
        {
            set { this._makercd = value; }
            get { return this._makercd; }
        }
        
        /// <summary>
        /// �g�єԍ�
        /// </summary>
        internal string StockTellNo
        {
            set { this._stocktellno = value; }
            get { return this._stocktellno; }
        }

        /// <summary>
        /// �����ԍ�
        /// </summary>
        internal string ProductNo
        {
            set { this._productno = value; }
            get { return this._productno; }
        }

		/// <summary>
		/// ���o���ʃf�[�^
		/// </summary>
        /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� ------------>>>>>
        internal List<StockAcPayHist> StockAcPayHistList
        {
            set{ this._stockAcPayHistList = value; }
            get{ return this._stockAcPayHistList; }
        }
           -----DEL 2008/07/17 -------------------------------<<<<< */
        // -----ADD 2008/07/17 ------------------------------->>>>>
        internal List<StockAcPayHisSearchRet> StockAcPayHisSearchRetList
        {
            set { this._stockAcPayHisSearchRetList = value; }
            get { return this._stockAcPayHisSearchRetList; }
        }

        internal List<StockCarEnterCarOutRet> StockCarEnterCarOutRetList
        {
            set { this._stockCarEnterCarOutRetList = value; }
            get { return this._stockCarEnterCarOutRetList; }
        }
        // -----ADD 2008/07/17 -------------------------------<<<<<

		/// <summary>
		/// ���o�J�n�s��
		/// </summary>
		internal int StartCnt
		{
			set{ this._startCnt = value; }
			get{ return this._startCnt; }
		}
		
		/// <summary>
		/// ���o����
		/// </summary>
		internal int ReadCnt
		{
			set{ this._readCnt = value; }
			get{ return this._readCnt; }
		}

        //���t�͈�        
        private const int SEC_1 = 7;
        private const int SEC_2 = 14;
        private const int SEC_3 = 21;
        private const int SEC_4 = 100;
        private const int SEC_5 = 200;
        private const int SEC_6 = 300;

        private const int SEC_R1 = -7;
        private const int SEC_R2 = -14;
        private const int SEC_R3 = -21;
        private const int SEC_R4 = -100;
        private const int SEC_R5 = -200;
        private const int SEC_R6 = -300;

        #endregion

		#region Private Event
		/// <summary>
		/// �t�H�[�����[�h����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[�����J�n���܂�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.01.23</br>
		/// </remarks>
		public void ReadProc()
		{
            try
            {
                // �����f�[�^�Ǎ�����
                ReadHistoryData(this._searchmode);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "��������"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message + "\n" + ex.StackTrace.ToString()
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }
        #endregion

		#region Private Method
		/// <summary>
		/// ����Ǎ�����
		/// </summary>
		/// <param name="_searchmode">�����f�[�^�Ǎ����[�h</param>
		/// <remarks>
		/// <br>Note       : �����f�[�^�Ǎ��݂܂�</br>
		/// <br>Programer  : 19077 �n� �M�T</br>
		/// <br>Date       : 2007.01.23</br>
		/// </remarks>
		private void ReadHistoryData(int _searchmode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �����f�[�^������
            //ArrayList retArray = new ArrayList();

            //// �A�N�Z�X���i
            //StockAcPayHistAcs _stockAcPayHistAcs = new StockAcPayHistAcs();
                                    
            //// �p�����[�^�I�u�W�F�N�g�쐬     
            //StockAcPayHisSearchParaWork _parameter = new StockAcPayHisSearchParaWork();


            //// �����E�i�������Z�b�g
            //_parameter.EnterpriseCode	= this.EnterpriseCode;  //��ƃR�[�h
            //_parameter.ProductNumber = this.ProductNo;          //����
            //_parameter.StockTelNo1 = this.StockTellNo;          //�g�єԍ�

            //_parameter.MakerCode = this.MakerCode;            //���[�J�[�R�[�h
            //_parameter.GoodsCode = this.GoodsCd;                //���i�R�[�h

            //if (this.tde_st_IoGoodsDay.ToString().Trim() != "0")
            //{
            //    _parameter.Starttde_st_IoGoodsDay = DateTime.ParseExact((this.tde_st_IoGoodsDay.ToString() + "000000"), "yyyyMMddHHmmss", null);
            //}
            //if (this.tde_ed_IoGoodsDay.ToString().Trim() != "0")
            //{
            //    _parameter.Endtde_st_IoGoodsDay = DateTime.ParseExact((this.tde_ed_IoGoodsDay.ToString() + "000000"), "yyyyMMddHHmmss", null);
            //}
            //else
            //{
            //    _parameter.Endtde_st_IoGoodsDay = DateTime.ParseExact(("99991231" + "000000"), "yyyyMMddHHmmss", null);
            //}
            
            //if (this.AcPaySlipCd != 0)
            //{
            //    _parameter.AcPaySlipCd = this.AcPaySlipCd;          //�`�[�敪
            //}

            //if (this.AcPayTranceCd != 0)
            //{
            //    //taka _parameter.AcPaySlipCd = this.AcPaySlipCd;          //�`�[�敪

            //}
            //this.retList = new ArrayList();

            //_parameter.SectionCode = this.SectionCd;            //���_�R�[�h
            //_parameter.CarrierEpCode = this.CarrierEP;          //���Ǝ҃R�[�h
            //_parameter.CarrierCode = this.Carrier;              //�L�����A
            //// �����f�[�^�Ǎ� ���S�����o�ׁ̈A�J�n���E�I������0�w��
            //int st = _stockAcPayHistAcs.SearchAll(out retArray, _parameter);
            
            //// �Y���f�[�^�����݂���ꍇ�̂݃O���b�h�ɗ����f�[�^���Z�b�g

            //// ���o���������݂���ꍇ
            //if (retArray.Count != 0)
            //{

            //    // �����f�[�^�����݂���ꍇ�͒��o���ʂ��}�[�W����
            //    StockAcPayHist[] _getStockAcPayHistArr = null;
            //    StockAcPayHisDt[] _getStockAcPayHisDtArr = null;

            //    StockAcPayHist _getStockAcPayHist = null;
            //    StockAcPayHisDt _getStockAcPayHisDt = null; 

            //    int ii = 0;

            //    int mainStockAcPayHistLen = retArray.Count;

            //    ii = 0;

            //    bool bModeDt = false;

            //    _getStockAcPayHistArr = new StockAcPayHist[mainStockAcPayHistLen];
            //    _getStockAcPayHisDtArr = new StockAcPayHisDt[mainStockAcPayHistLen];
            //    foreach(Object wkObj in retArray)
            //    {
            //        if (wkObj is StockAcPayHist)
            //        {
            //            _getStockAcPayHist = (StockAcPayHist)wkObj;
            //            _getStockAcPayHistArr[ii] = _getStockAcPayHist;
            //            ii++;
            //        }
            //        else if (wkObj is StockAcPayHisDt)
            //        {
            //            bModeDt = true;
            //            _getStockAcPayHisDt = (StockAcPayHisDt)wkObj;
            //            _getStockAcPayHisDtArr[ii] = _getStockAcPayHisDt;
            //            ii++;
            //        }
            //    }

            //    StockAcPayHist[] _newStockAcPayHist = new StockAcPayHist[mainStockAcPayHistLen];
            //    StockAcPayHisDt[] _newStockAcPayHisDt = new StockAcPayHisDt[mainStockAcPayHistLen];

            //    int cnt = 0;

            //    if (bModeDt != true)
            //    {
            //        if (_getStockAcPayHistArr != null)
            //        {
            //            for (int ix = 0; ix < _getStockAcPayHistArr.Length; ix++)
            //            {
            //                _newStockAcPayHist[cnt] = _getStockAcPayHistArr[ix];
            //                cnt++;
            //            }

            //            for (int ix = 0; ix < _newStockAcPayHist.Length; ix++)
            //            {
            //                this.retList.Add(_newStockAcPayHist[ix]);
            //            }
            //        }

            //    }else if (_getStockAcPayHisDtArr != null)
            //    {
            //        for (int ix = 0; ix < _getStockAcPayHisDtArr.Length; ix++)
            //        {
            //            _newStockAcPayHisDt[cnt] = _getStockAcPayHisDtArr[ix];
            //            cnt++;
            //        }
            //        for (int ix = 0; ix < _newStockAcPayHisDt.Length; ix++)
            //        {
            //            this.retList.Add(_newStockAcPayHisDt[ix]);
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �����f�[�^������
            ArrayList retArray = new ArrayList();
            ArrayList retArray2 = new ArrayList();      //ADD 2008/07/17

            // �A�N�Z�X���i
            StockAcPayHistAcs stockAcPayHistAcs = new StockAcPayHistAcs();

            //--------------------------------------------------------------------
            // ���o�����̐���
            //--------------------------------------------------------------------
            // �p�����[�^�I�u�W�F�N�g�쐬     
            StockAcPayHisSearchPara cndtn = new StockAcPayHisSearchPara();

            // �����E�i�������Z�b�g
            cndtn.EnterpriseCode = this.EnterpriseCode;  //��ƃR�[�h

            cndtn.St_GoodsMakerCd = this.MakerCode;             //���[�J�[�R�[�h
            cndtn.Ed_GoodsMakerCd = this.MakerCode;             //���[�J�[�R�[�h
            cndtn.St_GoodsNo = this.GoodsCd;                    //���i�ԍ�
            cndtn.Ed_GoodsNo = this.GoodsCd;                    //���i�ԍ�
            
            // ���_�R�[�h
            //cndtn.SectionCodes = new string[] { this.SectionCd };         //DEL 2009/01/09 �s��Ή�[9799]
            // --- ADD 2009/01/09 �s��Ή�[9799] ----------------------------------------------------->>>>>
            if (this.SectionCd == null)
            {
                cndtn.SectionCodes = null;
            }
            else
            {
                cndtn.SectionCodes = new string[] { this.SectionCd };
            }
            // --- ADD 2009/01/09 �s��Ή�[9799] -----------------------------------------------------<<<<<
            // �q�ɃR�[�h
            cndtn.St_WarehouseCode = this.WareHouse;
            cndtn.Ed_WarehouseCode = this.WareHouse;

            // ���o�ד�
            if ( this.tde_st_IoGoodsDay.ToString().Trim() != "0" )
            {
                cndtn.St_IoGoodsDay = DateTime.ParseExact( ( this.tde_st_IoGoodsDay.ToString() + "000000" ), "yyyyMMddHHmmss", null );
            }
            if ( this.tde_ed_IoGoodsDay.ToString().Trim() != "0" )
            {
                cndtn.Ed_IoGoodsDay = DateTime.ParseExact( ( this.tde_ed_IoGoodsDay.ToString() + "000000" ), "yyyyMMddHHmmss", null );
            }
            else
            {
                cndtn.Ed_IoGoodsDay = DateTime.ParseExact( ( "99991231" + "000000" ), "yyyyMMddHHmmss", null );
            }

            // -----ADD 2008/07/17 --------------------------------------------------->>>>>
            // �N���x�A�����̗����擾
            DateTime yearMonth;
            Int32 year;
            DateTime startMonthDate;
            DateTime endMonthDate;
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();

            // ���t�擾
            dateGetAcs.GetYearMonth(cndtn.St_IoGoodsDay, out yearMonth, out year, out startMonthDate, out endMonthDate);

            yearMonth = yearMonth.AddMonths(-1);
            cndtn.St_HisYearMonth = yearMonth.Year * 100 + yearMonth.Month;
            cndtn.St_AcPayDate = startMonthDate.Year * 10000 + startMonthDate.Month * 100 + startMonthDate.Day;
            //cndtn.St_AddUpADate = DateTime.ParseExact("20000101000000", "yyyyMMddHHmmss", null);
            //cndtn.Ed_AddUpADate = DateTime.ParseExact("99991231000000", "yyyyMMddHHmmss", null);
            // -----ADD 2008/07/17 ---------------------------------------------------<<<<<


            // �`�[�敪
            if ( this.AcPaySlipCd != 0 )
            {
                cndtn.AcPaySlipCd = this.AcPaySlipCd;          //�`�[�敪
            }
            else
            {
                cndtn.AcPaySlipCd = -1;
            }
            // �L���敪=0:�L���̂�
            cndtn.ValidDivCd = 0;

            //--------------------------------------------------------------------
            // �ǂݍ���
            //--------------------------------------------------------------------

            // �����f�[�^�Ǎ� ���S�����o�ׁ̈A�J�n���E�I������0�w��
            //int st = stockAcPayHistAcs.SearchAll( out retArray, cndtn );      //DEL 2008/07/17 �݌ɓ��o�ɏƉ�o���ʒǉ��̈�
            int st = stockAcPayHistAcs.SearchAll(out retArray, out retArray2, cndtn);       

            //--------------------------------------------------------------------
            // ���o���ʂ̎擾
            //--------------------------------------------------------------------

            // ���o���ʂ��R�s�[
            /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� ------------------------------->>>>>
            this._stockAcPayHistList = new List<StockAcPayHist>();
            
            foreach ( object retObj in retArray )
            {
                StockAcPayHist stockAcPayHist = (StockAcPayHist)retObj;

                // ���ʃ��X�g�ɒǉ�
                this._stockAcPayHistList.Add( stockAcPayHist );
            }
               -----DEL 2008/07/17 --------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 -------------------------------------------------->>>>>
            this._stockAcPayHisSearchRetList = new List<StockAcPayHisSearchRet>();

            foreach (object retObj in retArray)
            {
                StockAcPayHisSearchRet stockAcPayHisSearchRet = (StockAcPayHisSearchRet)retObj;

                // ���ʃ��X�g�ɒǉ�
                this._stockAcPayHisSearchRetList.Add(stockAcPayHisSearchRet);
            }

            this._stockCarEnterCarOutRetList = new List<StockCarEnterCarOutRet>();

            foreach (object retObj in retArray2)
            {
                StockCarEnterCarOutRet stockCarEnterCarOutRet = (StockCarEnterCarOutRet)retObj;

                // ���ʃ��X�g�ɒǉ�
                this._stockCarEnterCarOutRetList.Add(stockCarEnterCarOutRet);
            }
            // -----ADD 2008/07/17 --------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /// <summary>
        /// ���������Z����
        /// </summary>
        /// <param name="tgtDay">���Z�Ώ�</param>
        /// <param name="addDay">���Z�敪</param>
        /// <remarks>
        /// <br>Note       : �Ώۓ��t�Ɏw����������Z���܂��B</br>
        /// <br>Programer  : 19077 �n� �M�T</br>
        /// <br>Date       : 2007.01.23</br>
        /// </remarks>
        public int AddDays(int tgtDay, int addDay)
        {
            int year = (tgtDay - (tgtDay % 10000)) / 10000;
            int month = ( tgtDay % 10000) / 100;
            int day = ( tgtDay % 10000) % 100;

            int add = 0;
            switch (addDay)
            {
                case -1:
                    {
                        add = SEC_R1;
                        break;
                    }
                case -2:
                    {
                        add = SEC_R2;
                        break;
                    }
                case -3:
                    {
                        add = SEC_R3;
                        break;
                    }
                case -4:
                    {
                        add = SEC_R4;
                        break;
                    }
                case -5:
                    {
                        add = SEC_R5;
                        break;
                    }
                case -6:
                    {
                        add = SEC_R6;
                        break;
                    }
                case 0:
                    {
                        add = 0;
                        break;
                    }
                case 1:
                    {
                        add = SEC_1;
                        break;
                    }
                case 2:
                    {
                        add = SEC_2;
                        break;
                    }
                case 3:
                    {
                        add = SEC_3;
                        break;
                    }
                case 4:
                    {
                        add = SEC_4;
                        break;
                    }
                case 5:
                    {
                        add = SEC_5;
                        break;
                    }
                case 6:
                    {
                        add = SEC_6;
                        break;
                    }
            }

            DateTime datetime = new DateTime();

            datetime = DateTime.ParseExact(tgtDay.ToString() + "000000", "yyyyMMddHHmmss", null);
            
            if (Math.Abs(add) < 100)
            {
                datetime = datetime.AddDays(add);
            }
            else
            {
                datetime = datetime.AddMonths(add / 100);
            }
                        
            return datetime.Year * 10000 + datetime.Month * 100 + datetime.Day;
            
        }
		#endregion
	}
}

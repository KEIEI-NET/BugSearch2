//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���`�[�Ɖ�
// �v���O�����T�v   : �d���`�[�Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2009/02/09  �C�����e : ��QID:9049�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : ��Q�Ή�13014
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/12  �C�����e : ��Q�Ή�13234
//----------------------------------------------------------------------------//

# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
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
    /// �`�[���� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �`�[�������s���܂��B</br>
    /// <br>Programmer	: 980023 �ђJ�@�k��</br>
    /// <br>Date		: 2007.01.29</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 ���n ���</br>
    ///	<br>		   : PM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    /// <br>Update Note: 2009.02.09 30414 �E �K�j</br>
    ///	<br>		   : ��QID:9049�Ή�</br>
    /// </remarks>
    public class SearchSlipAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISearchStockSlipDB _iSearchStockSlipDB = null;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
		// ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;													
        private StockDataSet _dataSet;
        private static StockDataSet.StockSlipDataTable _stockSlipCache;
        private static SearchParaStockSlip _paraStockSlipCache;
        private static SortedList _nameList;
        private static SearchSlipAcs _searchSlipAcs;
        private List<StockDetail> _stockDetailDBDataList;

        private StockSlipInputAcs _stockSlipInputAcs;

        private string _enterpriseCode;             // ��ƃR�[�h

        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string ct_DateFormat = "yyyy/MM/dd";

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private SubSectionAcs _subSectionAcs;
        private Dictionary<int, SubSection> _subSectionDic;

        # endregion

        // �f���Q�[�g����
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        # region ��Constracter
        /// <summary>
        /// �`�[���� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ރ}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public SearchSlipAcs()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
            this._stockDetailDBDataList = new List<StockDetail>();
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // --- ADD 2009/02/09 ��QID:9049�Ή�------------------------------------------------------>>>>>
            ReadSecInfoSet();
            // --- ADD 2009/02/09 ��QID:9049�Ή�------------------------------------------------------<<<<<

            this._subSectionAcs = new SubSectionAcs();
            ReadSubSection();

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iSearchStockSlipDB = (ISearchStockSlipDB)MediationSearchStockSlipDB.GetSearchStockSlipDB();
                }
                catch (Exception)
                {
                    //�I�t���C������null���Z�b�g
                    this._iSearchStockSlipDB = null;
                }
            }
            else
            {
                // �I�t���C�����̃f�[�^�ǂݍ���
                //this.SearchOfflineData();
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            }
        }
        # endregion

        // --- ADD 2009/02/09 ��QID:9049�Ή�------------------------------------------------------>>>>>
        public void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        private string GetSectionName(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }
        // --- ADD 2009/02/09 ��QID:9049�Ή�------------------------------------------------------<<<<<

        private void ReadSubSection()
        {
            this._subSectionDic = new Dictionary<int, SubSection>();

            ArrayList retList;

            int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (SubSection subSection in retList)
                {
                    if (subSection.LogicalDeleteCode == 0)
                    {
                        this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                    }
                }
            }
        }

        public string GetSubSectionName(int subSectionCode)
        {
            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                return this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }
            else
            {
                return "";
            }
        }

        public int ExecuteSubSectionGuide(out SubSection subSection)
        {
            int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

            return status;
        }

        /// <summary>
        /// �`�[�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�`�[�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static SearchSlipAcs GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new SearchSlipAcs();
            }

            return _searchSlipAcs;
        }

        /// <summary>
        /// �`�[�����f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        public StockDataSet DataSet
        {
            get { return this._dataSet; }
        }

        # region ��public int GetOnlineMode()
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSearchStockSlipDB == null)
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
        /// �`�[�f�[�^�e�[�u�� �L���b�V������
        /// </summary>
        private void CacheStockSlipTable()
        {
            if (_stockSlipCache == null)
            {
                _stockSlipCache = new StockDataSet.StockSlipDataTable();
            }

            this._dataSet.StockSlip.AcceptChanges();
            _stockSlipCache = (StockDataSet.StockSlipDataTable)this._dataSet.StockSlip.Copy();
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        private void CacheParaStockSlip(SearchParaStockSlip searchParaStockSlip)
        {
            // ���������l
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new SearchParaStockSlip();
            }
            _paraStockSlipCache = searchParaStockSlip;

            // ����
            if (_nameList == null)
            {
                _nameList = new SortedList();
            }

            // �f���Q�[�g�ɂĉ�ʂ̖��̍��ڒl���X�g���擾�E�i�[
            if (this.GetNameList != null)
            {
                _nameList = this.GetNameList();
            }
        }

        #endregion

        #region ��Public Method

        /// <summary>
        /// �`�[��� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int SetSearchData(SearchParaStockSlip searchParaStockSlip)
        {
			string supplierSlipCdString = "";
            List<SearchRetStockSlip> retData;
			long stockPriceConsTax = 0;
			long stockTotalPrice = 0;
            
            int status = this.Search(out retData, searchParaStockSlip);

            // �d���`��
            List<string> SupplierFormalList = new List<string>();
            SupplierFormalList.Add("�d��");
			SupplierFormalList.Add("����");
			SupplierFormalList.Add("����");

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //// �`�[�敪
            //SortedList SupplierSlipCdList = new SortedList();
            //SupplierSlipCdList.Add(10,"�d��");
            //SupplierSlipCdList.Add(20,"�ԕi");
            //SupplierSlipCdList.Add(30, "�����d��");
            //SupplierSlipCdList.Add(40, "�����ԕi");
            // --- DEL 2009/01/23 --------------------------------<<<<<

            // �ԓ`�敪
            List<string> DebitNoteDivList = new List<string>();
            DebitNoteDivList.Add("���`");
            DebitNoteDivList.Add("�ԓ`");
            DebitNoteDivList.Add("����");

            // ���i�敪    
            List<string> StockGoodsCdList = new List<string>();
            StockGoodsCdList.Add("���i");
            StockGoodsCdList.Add("���i�O");
            StockGoodsCdList.Add("����Œ���");
            StockGoodsCdList.Add("�c������");
			StockGoodsCdList.Add("����Œ����i���|�p�j");
			StockGoodsCdList.Add("�c�������i���|�p�j");
			StockGoodsCdList.Add("���v����");

            // ���|�敪    
            List<string> AccPayDivCdList = new List<string>();
            AccPayDivCdList.Add("���|�Ǘ����Ȃ�");
            AccPayDivCdList.Add("���|�Ǘ�����");

            this.ClearStockSlipDataTable();

            //SecInfoSet secInfoSet;
            //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            //int rstatus;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �`�[�ԍ�(�d��SEQ/�x��No)�ۑ��p�ϐ�
                //int exSupplierSlipNo = 0;

                for (int i = 0; i < retData.Count; i++)
                {
                    SearchRetStockSlip searchRetStockSlip = retData[i];

					//����Œ����E�c������
					if ((searchRetStockSlip.StockGoodsCd == 2) || (searchRetStockSlip.StockGoodsCd == 4))
					{
						stockTotalPrice = 0;
						stockPriceConsTax = searchRetStockSlip.StockPriceConsTax;
					}
					else if ((searchRetStockSlip.StockGoodsCd == 3) || (searchRetStockSlip.StockGoodsCd == 5))
					{
						stockTotalPrice = searchRetStockSlip.StockTotalPrice;
						stockPriceConsTax = 0;
					}
					else
					{
						stockTotalPrice = searchRetStockSlip.StockSubttlPrice;
						stockPriceConsTax = searchRetStockSlip.StockPriceConsTax;
					}

                    //// ����œ]�ŕ���
                    //if (searchRetStockSlip.SuppCTaxLayCd == 0)
                    //{
                    //    // �`�[����
                    //    if (searchRetStockSlip.SupplierSlipNo != exSupplierSlipNo)
                    //    {
                    //        // �`�[�ԍ����ς������\��

                    //    }
                    //}

                    //// �`�[�ԍ���ۑ�
                    //exSupplierSlipNo = searchRetStockSlip.SupplierSlipNo;

                    //string sectionCode = searchRetStockSlip.SectionCode;      // DEL 2009/05/12
                    string sectionCode = searchRetStockSlip.StockSectionCd;     // ADD 2009/05/12 �d�����_�R�[�h
                    //string sectionName = stockSlipWork.SectionCode;
                    string sectionName = "";
                    if (sectionCode == "00")
                    {
                        sectionName = "�S��";
                    }
                    else
                    {
                        // --- CHG 2009/02/09 ��QID:9049�Ή�------------------------------------------------------>>>>>
                        //rstatus = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);
                        //if (rstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    sectionName = secInfoSet.SectionGuideNm;
                        //}
                        sectionName = GetSectionName(sectionCode.Trim());
                        // --- CHG 2009/02/09 ��QID:9049�Ή�------------------------------------------------------<<<<<
                    }

					supplierSlipCdString = "";
					switch(searchRetStockSlip.SupplierSlipCd)
					{
						case 10:
                            // --- DEL 2009/01/23 -------------------------------->>>>>
                            //if (searchRetStockSlip.AccPayDivCd == 0) supplierSlipCdString = "�����d��";
                            //else                                     supplierSlipCdString = "�|�d��";
                            // --- DEL 2009/01/23 --------------------------------<<<<<
                            supplierSlipCdString = "�d��"; // ADD 2009/01/23
							break;
						case 20:
                            // --- DEL 2009/01/23 -------------------------------->>>>>
                            //if (searchRetStockSlip.AccPayDivCd == 0) supplierSlipCdString = "�����ԕi";
                            //else supplierSlipCdString = "�|�ԕi";
                            // --- DEL 2009/01/23 --------------------------------<<<<<
                            supplierSlipCdString = "�ԕi"; // ADD 2009/01/23
							break;
					}


                    _dataSet.StockSlip.AddStockSlipRow(i + 1, searchRetStockSlip.EnterpriseCode,
                                                       sectionCode, sectionName, searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.StockAddUpADate, GetDateTimeString(searchRetStockSlip.StockAddUpADate, ct_DateFormat),
													   searchRetStockSlip.ArrivalGoodsDay, GetDateTimeString(searchRetStockSlip.ArrivalGoodsDay, ct_DateFormat),
                                                       searchRetStockSlip.StockAgentCode, searchRetStockSlip.StockAgentName,
                                                       // UPD 2008.04.24 >>>>>>
                                                       //searchRetStockSlip.CustomerCode, searchRetStockSlip.CustomerName,
                                                       searchRetStockSlip.SupplierCd, searchRetStockSlip.SupplierSnm,//Nm1
                                                       // UPD 2008.04.24 <<<<<<
													   searchRetStockSlip.SupplierFormal,
                                                       SupplierFormalList[searchRetStockSlip.SupplierFormal],
                                                       searchRetStockSlip.SupplierSlipCd,
                                                       supplierSlipCdString, //SupplierSlipCdList[searchRetStockSlip.SupplierSlipCd].ToString(),
                                                       searchRetStockSlip.DebitNoteDiv,
                                                       DebitNoteDivList[searchRetStockSlip.DebitNoteDiv],
                                                       searchRetStockSlip.StockGoodsCd,
                                                       StockGoodsCdList[searchRetStockSlip.StockGoodsCd],
                                                       searchRetStockSlip.AccPayDivCd,
                                                       AccPayDivCdList[searchRetStockSlip.AccPayDivCd],
													   searchRetStockSlip.InputDay, GetDateTimeString(searchRetStockSlip.InputDay, ct_DateFormat),
													   searchRetStockSlip.StockDate, GetDateTimeString(searchRetStockSlip.StockDate, ct_DateFormat),
                                                       stockTotalPrice,
													   searchRetStockSlip.StockSubttlPrice,
													   stockPriceConsTax,
                                                       searchRetStockSlip.PartySaleSlipNum,
                                                       searchRetStockSlip.SupplierSlipNote1, 
                                                       searchRetStockSlip.SupplierSlipNote2,
                                                       //searchRetStockSlip.SupplierCd,
                                                       //searchRetStockSlip.SupplierNm1,
                                                       searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.UoeRemark1,
                                                       searchRetStockSlip.PayeeCode,
                                                       searchRetStockSlip.PayeeSnm,
                                                       searchRetStockSlip.SuppCTaxLayCd,
                                                       GetSubSectionName(searchRetStockSlip.SubSectionCode)
													   );
                }

                // �����f�[�^�̃L���b�V��
                this.CacheStockSlipTable();

                // ���������̃L���b�V��
                this.CacheParaStockSlip(searchParaStockSlip);
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
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearStockSlipDataTable()
        {
            this._dataSet.StockSlip.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);
        }
        
        /// <summary>
        /// �`�[��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockSlipWorks">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="searchParaStockSlip">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<SearchRetStockSlip> searchRetStockSlips, SearchParaStockSlip searchParaStockSlip)
        {
            try
            {
                int status;
                searchRetStockSlips = new List<SearchRetStockSlip>();

                // �I�����C���̏ꍇ�����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    paraList.Add(searchParaStockSlip);

                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //�`�[���擾
                    status = this._iSearchStockSlipDB.Search(ref paraObj, out retObj);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        retList = (CustomSerializeArrayList)retObj;
                        for (int i = 0; i < retList.Count; i++)
                        {
                            searchRetStockSlips.Add((SearchRetStockSlip)retList[i]);
                            setCount++;
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
                }
                else	// �I�t���C���̏ꍇ
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                searchRetStockSlips = null;
                //�I�t���C������null���Z�b�g
                this._iSearchStockSlipDB= null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �`�[�f�[�^�e�[�u���L���b�V���擾����
        /// </summary>
        /// <returns>�`�[�f�[�^�e�[�u���L���b�V��</returns>
        public StockDataSet.StockSlipDataTable GetStockSlipTableCache()
        {
            return _stockSlipCache;
        }

        /// <summary>
        /// ��ʖ��̍��ڒl���X�g �L���b�V���擾����
        /// </summary>
        /// <returns>��ʖ��̍��ڒl���X�g �L���b�V��</returns>
        public SortedList GetCacheNmaeList()
        {
            return _nameList;
        }


        /// <summary>
        /// ���������N���X�L���b�V���擾����
        /// </summary>
        /// <returns>���������N���X�L���b�V��</returns>
        public SearchParaStockSlip GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
        }

        /// <summary>
        /// �`�[��񌏐��擾�����i�_���폜�����j
        /// </summary>
        /// <param name="retTotalCnt">�f�[�^����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int GetCnt(out int retTotalCnt, string enterpriseCode)
        {
            return GetCntProc(out retTotalCnt, enterpriseCode, 0);
        }

        /// <summary>
        /// �`�[��񌏐��擾�����i�_���폜�܂ށj
        /// </summary>
        /// <param name="retTotalCnt">�f�[�^����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetAllCnt(out int retTotalCnt, string enterpriseCode)
        {
            return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// �`�[�������擾����
        /// </summary>
        /// <param name="retTotalCnt">�f�[�^����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^���̌������s���܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            StockSlipWork stockSlipWork = new StockSlipWork();
            stockSlipWork.EnterpriseCode = enterpriseCode;

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(stockSlipWork);

            //object objectStockSlipWork;
            //this._iIOWriteMASIRDB.Search(out objectLGoodsGanreWork, lgoodsganreWork, 0, ConstantManagement.LogicalMode.GetData01);
            //ArrayList al = (ArrayList)objectStockSlipWork;
            //retTotalCnt = al.Count;
            retTotalCnt = 0;
            return 0;
        }

        /// <summary>
        /// �I���s�e�[�u���f�[�^�擾����
        /// </summary>
        /// <param name="getRowNo">�O���b�h�I��RowNo</param>
        /// <returns>�d���f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public SearchRetStockSlip GetSelectedRowData(int getRowNo)
        {
            SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

            searchRetStockSlip.EnterpriseCode   = this._dataSet.StockSlip[getRowNo].EnterpriseCode;         // ��ƃR�[�h
            searchRetStockSlip.SupplierFormal   = this._dataSet.StockSlip[getRowNo].SupplierFomal;          // �d���`��
            searchRetStockSlip.SupplierSlipNo   = this._dataSet.StockSlip[getRowNo].SupplierSlipNo;         // �d���`�[�ԍ�
            searchRetStockSlip.SupplierSlipCd   = this._dataSet.StockSlip[getRowNo].SupplierSlipCd;         // �`�[�敪
            searchRetStockSlip.StockGoodsCd     = this._dataSet.StockSlip[getRowNo].StockGoodsCd;           // ���i�敪
            searchRetStockSlip.AccPayDivCd      = this._dataSet.StockSlip[getRowNo].AccPayDivCd;            // ���|�敪

            searchRetStockSlip.StockAgentCode   = this._dataSet.StockSlip[getRowNo].StockAgentCode;         // �S���҃R�[�h
            searchRetStockSlip.StockAgentName   = this._dataSet.StockSlip[getRowNo].StockAgentName;         // �S���Җ�

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //searchRetStockSlip.CustomerCode = this._dataSet.StockSlip[getRowNo].CustomerCode;           // �d����R�[�h
            //searchRetStockSlip.CustomerName = this._dataSet.StockSlip[getRowNo].CustomerName;           // �d���於
            searchRetStockSlip.SupplierCd = this._dataSet.StockSlip[getRowNo].CustomerCode;           // �d����R�[�h
            searchRetStockSlip.SupplierSnm = this._dataSet.StockSlip[getRowNo].CustomerName;           // �d���於
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			searchRetStockSlip.ArrivalGoodsDay  = this._dataSet.StockSlip[getRowNo].ArrivalGoodsDay;        // ���ד�
            searchRetStockSlip.StockAddUpADate  = this._dataSet.StockSlip[getRowNo].StockAddUpADate;        // �v���
			searchRetStockSlip.InputDay			= this._dataSet.StockSlip[getRowNo].InputDay;				// ���͓�
			searchRetStockSlip.StockDate		= this._dataSet.StockSlip[getRowNo].StockDate;				// �d����

			searchRetStockSlip.PartySaleSlipNum = this._dataSet.StockSlip[getRowNo].PartySaleSlipNum;       // �����`��
			searchRetStockSlip.SupplierSlipNo = this._dataSet.StockSlip[getRowNo].SupplierSlipNo;			// �`�[�ԍ�

            searchRetStockSlip.UoeRemark1 = this._dataSet.StockSlip[getRowNo].UoeRemark1;
            searchRetStockSlip.PayeeCode = this._dataSet.StockSlip[getRowNo].PayeeCode;
            searchRetStockSlip.PayeeSnm = this._dataSet.StockSlip[getRowNo].PayeeSnm;

            searchRetStockSlip.SectionCode = this._dataSet.StockSlip[getRowNo].SectionCode;
            

            return searchRetStockSlip;
        }

        /// <summary>
        /// �Ώۓ`�[���׏��擾����
        /// </summary>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="supplierSlipNo">�`�[�ԍ�</param>
        public void SetDetailData(int supplierFormal, int supplierSlipNo)
		{
			long stockPriceTaxExc = 0;
			long stockPriceConsTax = 0;

			//PaymentSlp paymentSlp;
			//Broadleaf.Application.UIData.PaymentSlp paymentSlp;
			//List<SalesTemp> salesTempList;

			StockSlip stockSlip = new StockSlip();
            List<StockDetail> stockDetailList = new List<StockDetail>();
			StockInputDataSet.StockDetailDataTable stockDetailTable = new StockInputDataSet.StockDetailDataTable();

            // 2008.10.06 **undefined source objection
			this._stockSlipInputAcs.ReadDBData(
				this._enterpriseCode,
				supplierFormal,
				supplierSlipNo,
				out stockSlip,
				out stockDetailList,
				out stockDetailTable);

			if (stockDetailTable == null)
            {
                return;
            }

            Supplier supplier;
            SupplierAcs supplierAcs = new SupplierAcs();
            int rstatus = 0;

			for (int i = 0; i < stockDetailTable.Count; i++)
            {
                int stockRowNo = stockDetailTable[i].StockRowNo;

				//stockDetailTable[i].StockGoodsCd
				//stockDetailTable[i].StockPriceConsTax


                string goodsName = stockDetailTable[i].GoodsName;
                string warehouseCode = stockDetailTable[i].WarehouseCode;
                string warehouseName = stockDetailTable[i].WarehouseName;
                string warehouseShelfNo = stockDetailTable[i].WarehouseShelfNo; // ADD 2009/03/16
				string goodsCode = stockDetailTable[i].GoodsNo;

				double stockUnitPriceDisplay = stockDetailTable[i].StockUnitPriceDisplay;
				//double stockUnitPrice = stockDetailTable[i].StockUnitPrice;

				double stockUnitPrice = stockDetailTable[i].StockUnitPriceFl;


				double stockCount = stockDetailTable[i].StockCount;
                long stockPriceDisplay = stockDetailTable[i].StockPriceDisplay;
                long stockPrice = stockDetailTable[i].StockPriceTaxInc;
                int taxationCode = stockDetailTable[i].TaxationCode;
                string stockDtiSlipNote1 = stockDetailTable[i].StockDtiSlipNote1;
				int goodsMakerCd = stockDetailTable[i].GoodsMakerCd;
				string makerName = stockDetailTable[i].MakerName;
                // 2009.01.05 Add [9486]
                string blGoodsCodeString = string.Empty;
                if (stockDetailTable[i].BLGoodsCode > 0)
                {
                    blGoodsCodeString = stockDetailTable[i].BLGoodsCode.ToString();
                }
                // 2009.01.05 Add [9486]

				//�Ŗ���
				string taxationCodeString = "";
				switch(taxationCode)
				{
					case 0:
						taxationCodeString = "�O��";
						break;
					case 1:
						taxationCodeString = "��ې�";
						break;
					case 2:
						taxationCodeString = "����";
						break;
					default:
						taxationCodeString = "";
						break;
				}



				//����Œ����E�c������
				if ((stockDetailTable[i].StockGoodsCd == 2) || (stockDetailTable[i].StockGoodsCd == 4))
				{
					stockPriceTaxExc = 0;
					stockPriceConsTax = stockDetailTable[i].StockPriceConsTax;
				}
				else if ((stockDetailTable[i].StockGoodsCd == 3) || (stockDetailTable[i].StockGoodsCd == 5))
				{
					stockPriceTaxExc = stockDetailTable[i].StockPriceTaxInc;
					stockPriceConsTax = 0;
				}
				else
				{
					stockPriceTaxExc = stockDetailTable[i].StockPriceTaxExc;
					stockPriceConsTax = stockDetailTable[i].StockPriceConsTax;
				}

                // ����œ]�ŕ����ɂ��\����ύX

                if (String.IsNullOrEmpty(stockDetailTable[i].SupplierSnm) && stockDetailTable[i].SupplierCd > 0)
                {
                    rstatus = supplierAcs.Read(out supplier, this._enterpriseCode, stockDetailTable[i].SupplierCd);

                    if (rstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        stockDetailTable[i].SupplierSnm = supplier.SupplierSnm;
                    }
                }


				this._dataSet.StockDetail.AddStockDetailRow(
															i+1,
															supplierFormal,
															supplierSlipNo,
                                                            stockRowNo,
															goodsCode,
															goodsName,
															warehouseCode,
															warehouseName,
                                                            stockUnitPriceDisplay,
															stockUnitPrice,
                                                            stockCount,
															stockPriceTaxExc, //stockPriceDisplay,
															stockPrice,
															stockPriceConsTax,
															taxationCodeString,
                                                            stockDtiSlipNote1,
															goodsMakerCd,
															makerName,
															stockDetailTable[i].OrderCnt + stockDetailTable[i].OrderAdjustCnt,
															stockDetailTable[i].OrderCnt + stockDetailTable[i].OrderAdjustCnt,
															stockDetailTable[i].OrderRemainCnt,
                                                            stockDetailTable[i].SupplierCd,
                                                            stockDetailTable[i].SupplierSnm,
                                                            stockDetailTable[i].BLGoodsCode,
                                                            stockDetailTable[i].ListPriceTaxExcFl,
                                                            0,
                                                            blGoodsCodeString,   // 2009.01.05 Add [9486]
                                                            warehouseShelfNo // ADD 2009/03/16
															);
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
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�]�ƈ�����</returns>
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
        /// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
        public bool CheckGoodsExist(string goodsCode)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();

            // ���i�R�[�h�݂̂̎w���
            int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// ���i���̎擾����
		/// </summary>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
		{
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";

			// ���i�R�[�h�݂̂̎w���
			int status = goodsAcs.Read(this._enterpriseCode, goodsCode, out goodsUnitDataList);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0))
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
		/// ���i���̎擾����
		/// </summary>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName, out int goodsMakerCd, out string makerName)
		{
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";
			goodsMakerCd = 0;
			makerName = "";

			// ���i�R�[�h�݂̂̎w���
			int status = goodsAcs.Read(this._enterpriseCode, goodsCode, out goodsUnitDataList);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0))
			{
				goodsName = goodsUnitDataList[0].GoodsName;

				makerName = goodsUnitDataList[0].MakerName;
				goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// ���i���̎擾����
		/// </summary>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <returns>true:���݂���Afalse:���݂��Ȃ�</returns>
		public int CheckGoodsExist(IWin32Window owner, ref string goodsCode, ref string goodsName, ref int goodsMakerCd, ref string makerName)
		{
			int status;
			string message;
			string searchCode;
			int searchType;

			GoodsCndtn goodsCndtn = new GoodsCndtn();
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();

			searchType = GetSearchType(goodsCode, out searchCode);

			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

			goodsCndtn.GoodsMakerCd = goodsMakerCd;
			goodsCndtn.GoodsNoSrchTyp = searchType;
			//goodsCndtn.GoodsNo = goodsCode;
			goodsCndtn.GoodsNo = searchCode;
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
			status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, out goodsUnitDataList, out message);


			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
			{
				goodsCode = goodsUnitDataList[0].GoodsNo;
				goodsName = goodsUnitDataList[0].GoodsName;

				makerName = goodsUnitDataList[0].MakerName;
				goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
			}
			return (status);
		}

		// ===================================================================================== //
		// ���i�֘A����
		// ===================================================================================== //
		# region Goods Control Methods

		/// <summary>
		/// �����^�C�v�擾����
		/// </summary>
		/// <param name="inputCode">���͂��ꂽ�R�[�h</param>
		/// <param name="searchCode">�����p�R�[�h�i*�������j</param>
		/// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
		public static int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *�����݂��Ȃ����ߊ��S��v����
				return 0;
			}
		}

		# endregion

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

        // 2008.12.25 [9571]
        ///// <summary>
        ///// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        ///// </summary>
        ///// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    // ���O�C���S�����_���̎擾
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // �{�Ћ@�\���H
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        // 2008.12.25 [9571]

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
		# endregion

    }
}

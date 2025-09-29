//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2010/08/27  �C�����e : �P�i�����ꊇ�o�^�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/09/16  �C�����e : Redmine#14182�̑��x�t�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/09/26  �C�����e : Redmine#14182�̑��x�t�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���i��
// �C �� ��  2010/12/03  �C�����e : ��Q���ǑΉ��i�P�Q�����j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/02  �C�����e : Redmine#26319�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/23  �C�����e : Redmine#7744�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Data;

using System.Threading;    // ADD 2010/09/26 

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�ꊇ�C���E�o�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/08/04</br>
    /// <br>Update Note: 2010/09/16 杍^</br>
    /// <br>           : Redmine#14182�̑��x�t�o�Ή�</br>
    /// </remarks>
    public class GoodsRateSetUpdateAcs
    {
        #region �� Private Members
        // �|���}�X�^�����[�g
        private ISingleGoodsRateDB _iRateDB = null;
        /// <summary>���i���̓A�N�Z�X�N���X</summary>
        GoodsAcs _goodsAcs;

        // ���o���f�t���O
        private bool _extractCancelFlag;
        private string _enterpriseCode;
        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = "";

        // ADD 2010/09/26 --- >>>>
        GoodsAcs _goodsAcs2;
        GoodsAcs _goodsAcs3;

        private Thread _readInitialThread;
        private Thread _readInitialThreadSecond;
        private Thread _readInitialThreadThird;

        private Thread _readInitialThreadForth;
        private Thread _readInitialThreadFivth;
        private Thread _readInitialThreadSixth;

        ArrayList thread1Arr = null;
        ArrayList thread2Arr = null;
        ArrayList thread3Arr = null;

        ArrayList thread1ArrResult = null;
        ArrayList thread2ArrResult = null;
        ArrayList thread3ArrResult = null;

        GoodsRateSetSearchParam rateSearchParam;

        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSet _taxRateSet;
        private StockProcMoneyAcs _stockProcMoneyAcs;   // �P���Z�o�N���X�A�N�Z�X�N���X
        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        // ADD 2010/09/26 --- <<<<

        #endregion �� Private Members


        #region �� Construcstor
        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public GoodsRateSetUpdateAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRateDB = (ISingleGoodsRateDB)MediationSingleGoodsRateDB.GetSingleGoodsRateDB();

                // UPD 2010/09/26 --- >>>>
                //this._goodsAcs = new GoodsAcs();
                //this._goodsAcs.IsLocalDBRead = false;

                rateSearchParam = new GoodsRateSetSearchParam();

                thread1Arr = new ArrayList();
                thread2Arr = new ArrayList();
                thread3Arr = new ArrayList();

                thread1ArrResult = new ArrayList();
                thread2ArrResult = new ArrayList();
                thread3ArrResult = new ArrayList();

                this._unitPriceCalculation = new UnitPriceCalculation();
                this._stockProcMoneyAcs = new StockProcMoneyAcs();
                this._taxRateSetAcs = new TaxRateSetAcs();

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                //string msg;

                //// ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
                //this._goodsAcs.IsLocalDBRead = false;

                //// �����l�f�[�^�擾
                //int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
                
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //        {
                //            break;
                //        }
                //    default:
                //        {
                //            break;
                //        }
                //}

                //status = this._goodsAcs.SearchInitialForMst(this._enterpriseCode, this._loginSectionCode, out msg); // ADD 2010/08/27

                this._readInitialThread = new Thread(this.ReadInitialThread);
                this._readInitialThread.Start();
                this._readInitialThreadSecond = new Thread(this.ReadInitialThreadSecond);
                this._readInitialThreadSecond.Start();
                this._readInitialThreadThird = new Thread(this.ReadInitialThreadThird);
                this._readInitialThreadThird.Start();

                ReadInitData();
                ReadTaxRate();
                // UPD 2010/09/26 --- <<<<

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRateDB = null;
                this._goodsAcs = null;
            }
        }
        #endregion �� Construcstor

        #region �v���p�e�B
        /// <summary>
        /// ���o���f�t���O
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        #endregion // �v���p�e�B


        #region �� Public Methods
        /// <summary>
        /// �|���}�X�^�X�V����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Write(ArrayList saveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraRateList = new ArrayList();

                for (int i = 0; i < saveList.Count; i++)
                {
                    // �N���X�����o�R�s�[����
                    paraRateList.Add(CopyToRateWorkFromRate((Rate)saveList[i]));
                }

                object paraObj = (object)paraRateList;

                status = this._iRateDB.Write(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^�폜����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Delete(ArrayList deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                byte[] paraRateWork = null;
                ArrayList rateWorkList = new ArrayList();

                for (int i = 0; i < deleteList.Count; i++)
                {
                    // �N���X�����o�R�s�[����
                    rateWorkList.Add(CopyToRateWorkFromRate((Rate)deleteList[i]));
                }

                // ArrayList����z��𐶐�
                SingleGoodsRateWork[] rateWorks = (SingleGoodsRateWork[])rateWorkList.ToArray(typeof(SingleGoodsRateWork));

                // �V���A���C�Y
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <param name="rateSearchResultList">�|���}�X�^�������ʃ��X�g</param>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// <br>Update Note: 2010/09/16 杍^ Redmine#14182�̑��x�t�o�Ή�</br>
        /// <br>Update Note: 2010/12/03 ���i���@��Q���ǑΉ��i�P�Q�����j</br>
        /// </remarks>
        public int Search(out List<GoodsRateSetSearchResult> rateSearchResultList, GoodsRateSetSearchParam rateSearch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ADD 2010/12/03 --- >>>>
            if (this._readInitialThread != null)
            {
                while (this._readInitialThread.ThreadState == ThreadState.Running
                       || this._readInitialThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }

            if (this._readInitialThreadSecond != null)
            {
                while (this._readInitialThreadSecond.ThreadState == ThreadState.Running
                       || this._readInitialThreadSecond.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }

            if (this._readInitialThreadThird != null)
            {
                while (this._readInitialThreadThird.ThreadState == ThreadState.Running
                       || this._readInitialThreadThird.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }
            // ADD 2010/12/03 --- <<<<

            // ADD 2010/09/26 --- >>>
            thread1Arr = new ArrayList();
            thread2Arr = new ArrayList();
            thread3Arr = new ArrayList();

            thread1ArrResult = new ArrayList();
            thread2ArrResult = new ArrayList();
            thread3ArrResult = new ArrayList();
            // ADD 2010/09/26 --- <<<

            rateSearchResultList = new List<GoodsRateSetSearchResult>();

            this.rateSearchParam = rateSearch;  // ADD 2010/09/26

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                if (_extractCancelFlag == true) return 0;

                status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);

                if (_extractCancelFlag == true) return 0;

                if (status == 0)
                {
                    //ArrayList retWorkList = retObj as ArrayList;   // DEL 2010/09/16
                    // ADD 2010/09/16  --- >>>>
                    ArrayList retWorkListTemp = retObj as ArrayList;
                    ArrayList retWorkList = new ArrayList();

                    // �d�����Ă���f�[�^������ꍇ�́A�ŏ����b�g���̃f�[�^���擾
                    Dictionary<string, SingleGoodsRateSearchResultWork> parentDic = new Dictionary<string, SingleGoodsRateSearchResultWork>();
                    foreach (SingleGoodsRateSearchResultWork retWork in retWorkListTemp)
                    {
                        // ------------DEL  BY ������ 2011/11/02 -------------->>>>>>>>>>>>>>>>   
                        //string key = MakeParentKey(retWork);
                        //if (!parentDic.ContainsKey(key))
                        //{
                        //    parentDic.Add(key, retWork);
                        //} 
                        //else
                        //{
                        //    if (retWork.LotCount < parentDic[key].LotCount)
                        //    {
                        //        parentDic[key] = retWork;
                        //    }
                        //}
                        // ------------DEL  BY ������ 2011/11/02 --------------<<<<<<<<<<<<<<<

                        // ------------ADD  BY ������ 2011/11/02 -------------->>>>>>>>>>>>>>>>
                        if (retWork.CustomerCode != 0)
                        {
                            string key = MakeParentKey(retWork);
                            if (!parentDic.ContainsKey(key + retWork.CustomerCode))
                            {
                                parentDic.Add(key + retWork.CustomerCode, retWork);
                            }
                            else
                            {
                                if (retWork.LotCount < parentDic[key + retWork.CustomerCode].LotCount)
                                {
                                    parentDic[key + retWork.CustomerCode] = retWork;
                                }
                            }
                        }
                        else
                        {
                            string key = MakeParentKey(retWork);
                            if (!parentDic.ContainsKey(key + retWork.CustRateGrpCode))
                            {
                                parentDic.Add(key + retWork.CustRateGrpCode, retWork);
                            }
                            else
                            {
                                if (retWork.LotCount < parentDic[key + retWork.CustRateGrpCode].LotCount)
                                {
                                    parentDic[key + retWork.CustRateGrpCode] = retWork;
                                }
                            }
                        }
                        // ------------ADD  BY ������ 2011/11/02 --------------<<<<<<<<<<<<<<<<<<<
                    }

                    foreach (SingleGoodsRateSearchResultWork result in parentDic.Values)
                    {
                        retWorkList.Add(result);
                    }
                    // ADD 2010/09/16  --- <<<<

                    // ADD 2010/09/26 --- >>>
                    // --- ADD 2010/08/27 ---------->>>>>
                    // �����l�f�[�^�擾
                    //string msgInit;
                    //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msgInit); // DEL 2010/08/27

                    //GoodsInputDataSet.GoodsPriceDataTable dt = new GoodsInputDataSet.GoodsPriceDataTable();
                    //GoodsInputDataSet.GoodsPriceRow goodsPriceRow = dt.NewGoodsPriceRow();
                    // --- ADD 2010/08/27 ----------<<<<<

                    int threadCount = 0;

                    threadCount = retWorkList.Count / 3;

                    for (int i = 0; i < retWorkList.Count; i++)
                    {
                        SingleGoodsRateSearchResultWork retWork = (SingleGoodsRateSearchResultWork)retWorkList[i];
                        if (threadCount > i)
                        {
                            thread1Arr.Add(retWork);
                        }
                        else if ((i >= threadCount) && (i < (threadCount * 2)))
                        {
                            thread2Arr.Add(retWork);
                        }
                        else
                        {
                            thread3Arr.Add(retWork);
                        }
                    }

                    if (thread1Arr.Count > 0)
                    {
                        this._readInitialThreadForth = new Thread(this.ReadInitialForth);
                        this._readInitialThreadForth.Start();
                    }

                    if (thread2Arr.Count > 0)
                    {
                        this._readInitialThreadFivth = new Thread(this.ReadInitialThreadFivth);
                        this._readInitialThreadFivth.Start();
                    }

                    if (thread3Arr.Count > 0)
                    {
                        this._readInitialThreadSixth = new Thread(this.ReadInitialThreadSixth);
                        this._readInitialThreadSixth.Start();
                    }

                    if (this._readInitialThreadForth != null) // ADD 2010/12/03
                    {// ADD 2010/12/03
                        while (this._readInitialThreadForth.ThreadState == ThreadState.Running
                          || this._readInitialThreadForth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03

                    if (this._readInitialThreadFivth != null)// ADD 2010/12/03
                    {
                        while (this._readInitialThreadFivth.ThreadState == ThreadState.Running
                               || this._readInitialThreadFivth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03

                    if (this._readInitialThreadSixth != null)// ADD 2010/12/03
                    {
                        while (this._readInitialThreadSixth.ThreadState == ThreadState.Running
                              || this._readInitialThreadSixth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03
                    

                    foreach (GoodsRateSetSearchResult thread1Work in this.thread1ArrResult)
                    {
                        rateSearchResultList.Add(thread1Work);
                    }

                    foreach (GoodsRateSetSearchResult thread2Work in this.thread2ArrResult)
                    {
                        rateSearchResultList.Add(thread2Work);
                    }

                    foreach (GoodsRateSetSearchResult thread3Work in this.thread3ArrResult)
                    {
                        rateSearchResultList.Add(thread3Work);
                    }

                    //foreach (SingleGoodsRateSearchResultWork retWork in retWorkList)
                    //{
                    //    if (_extractCancelFlag == true)
                    //    {
                    //        break;
                    //    }
                    //    // �N���X�����o�R�s�[����(D��E)
                    //    //���i�Ǘ����}�X�^�Ɖ��i�}�X�^���̎擾

                    //    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    //    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    //    string msg = string.Empty;
                    //    GoodsCndtn cndtn = new GoodsCndtn();
                    //    // --- UPD 2010/09/07 ---------->>>>>
                    //    //cndtn.EnterpriseCode = this._enterpriseCode;
                    //    //cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    //    //cndtn.GoodsNo = retWork.GoodsNo;
                    //    //if ("00".Equals(rateSearchParam.SectionCode[0]))
                    //    //    cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    //    //else
                    //    //    cndtn.SectionCode = rateSearchParam.SectionCode[0];
                    //    //cndtn.PriceApplyDate = DateTime.Today;
                    //    //cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                    //    cndtn.EnterpriseCode = this._enterpriseCode;
                    //    if ("00".Equals(rateSearchParam.SectionCode[0]))
                    //        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    //    else
                    //        cndtn.SectionCode = rateSearchParam.SectionCode[0];
                    //    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    //    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    //    cndtn.GoodsNo = retWork.GoodsNo;
                    //    cndtn.GoodsKindCode = 9;
                    //    cndtn.IsSettingSupplier = 1;
                    //    // --- UPD 2010/09/07 ----------<<<<<
                    //    //status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg); // DEL 2010/08/27
                    //    // --- UPD 2010/09/07 ---------->>>>>
                    //    //status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg); // ADD 2010/08/27
                    //    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);
                    //    // --- UPD 2010/09/07 ----------<<<<<

                    //    if (goodsUnitDataList.Count > 0)
                    //    {
                    //        goodsUnitData = goodsUnitDataList[0];
                    //        // --- ADD 2010/09/07 ---------->>>>>
                    //        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
                    //        // --- ADD 2010/09/07 ----------<<<<<
                    //        switch (goodsUnitData.OfferKubun)
                    //        {
                    //            case 0: // ���[�U�[�o�^
                    //            case 1: // �񋟏����ҏW
                    //            case 2: // �񋟗D�ǕҏW
                    //                if (goodsUnitData.LogicalDeleteCode == 0)
                    //                {
                    //                    // �d����
                    //                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                    //                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                    //                    {
                    //                        if (goodsUnitData.GoodsPriceList.Count > 0)
                    //                        {
                    //                            // --- UPD 2010/08/27 ---------->>>>>
                    //                            //GoodsPrice goodsPrice = goodsUnitData.GoodsPriceList[0];
                    //                            //GoodsPrice goodsPrice = GetGoodsPriceByPriceStartDate(DateTime.Today, goodsUnitData.GoodsPriceList);

                    //                            //// UPD 2010/08/27 ---->>>>>
                    //                            //// �W�����i
                    //                            //if (goodsPrice != null)
                    //                            //{
                    //                            //    retWork.ListPrice = goodsPrice.ListPrice;
                    //                            //}
                    //                            //else
                    //                            //{
                    //                            //    return (status);
                    //                            //}
                    //                            //// UPD 2010/08/27 ----<<<<<
                    //                            ////// ���P��
                    //                            ////retWork.SalesUnitCost = goodsPrice.SalesUnitCost;

                    //                            //// ���i�����Čv�Z����̂ŏ�����
                    //                            //goodsPriceRow.CalcStockRate = 0.0;          // �v�Z������
                    //                            //goodsPriceRow.CalcSalesUnitCost = 0.0;      // �v�Z�����z
                    //                            //goodsPriceRow.CalcMaster = string.Empty;    // �Z�o�}�X�^
                    //                            //goodsPriceRow.PriorityOrder = 0;            // �D�揇��
                    //                            //goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode;
                    //                            //goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                    //                            //goodsPriceRow.GoodsNo = goodsPrice.GoodsNo;
                    //                            //goodsPriceRow.ListPrice = goodsPrice.ListPrice;

                    //                            //goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost;
                    //                            //goodsPriceRow.StockRate = goodsPrice.StockRate;
                    //                            //goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;
                    //                            //goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate;

                    //                            //// --- ADD 2010/09/07 ---------->>>>>
                    //                            //if (goodsPrice.ListPrice != 0)
                    //                            //{
                    //                            //// --- ADD 2010/09/07 ----------<<<<<
                    //                            //    this._goodsAcs.CalclateUnitPrice(goodsPriceRow, goodsUnitData);             // �P���Z�o
                    //                            //    this._goodsAcs.SettingCalcMaster(goodsPriceRow);                            // �Z�o�}�X�^
                    //                            //    this._goodsAcs.SettingCalcStockRate(goodsPriceRow);                         // �Z�o�p������
                    //                            //    this._goodsAcs.SettingCalcSalesUnitCost(goodsPriceRow);                     // �Z�o�p�����P��
                    //                            //    if (!goodsPriceRow.PriceStartDate.Equals(DateTime.MinValue))
                    //                            //    {
                    //                            //        retWork.SalesUnitCost = goodsPriceRow.CalcSalesUnitCost;    // ���P��
                    //                            //    }
                    //                            //////// --- ADD 2010/09/07 ---------->>>>>
                    //                            //}
                    //                            // --- ADD 2010/09/07 ----------<<<<<
                    //                            // --- UPD 2010/08/27 ----------<<<<<

                    //                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                    //                            if (goodsPrice != null)
                    //                            {
                    //                                retWork.ListPrice = goodsPrice.ListPrice;
                    //                            }

                    //                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                    //                        }
                    //                    }
                    //                }
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //    rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    //}
                }
                // ADD 2010/09/26 --- <<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<GoodsRateSetSearchResult>();
            }

            return (status);
        }

        // ADD 2010/09/26 --- >>>
        /// <summary>
        /// ���P���擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���P��</returns>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // ���i�A���f�[�^����P���Z�o���ʃI�u�W�F�N�g���擾
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // �P���Z�o���ʃI�u�W�F�N�g��茴�P���擾
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// �P���Z�o���ʃI�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);         // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }
        // ADD 2010/09/26 --- <<<

        // ADD 2010/09/16 --- >>>>
        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="result">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeParentKey(SingleGoodsRateSearchResultWork result)
        {
            // �i�ԁ{���[�J�[�R�[�h�{BL�R�[�h + �O���[�v�R�[�h + �d����R�[�h
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         result.UnitRateSetDivCd + "\\" +  //ADD BY ������ on 2011/11/23 for Redmine#7744 
                         result.GoodsNo;

            return key;
        }
        // ADD 2010/09/16 --- <<<<

        // --- ADD 2010/08/27 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����ɍ������i��񃌃R�[�h���擾���܂��B
        /// </summary>
        /// <param name="dateTime">����</param>
        /// <returns>
        /// ���i�J�n�����w������̃��R�[�h�̂����A�ŋ߂̂��̂�Ԃ��܂��B
        /// �i�w�������薢���̃��R�[�h�͖�������܂��j
        /// </returns>
        private GoodsPrice GetGoodsPriceByPriceStartDate(DateTime dateTime, List<GoodsPrice> goodsPriceList)
        {
            // ���i���O���b�h�̍ő�s���@���ۑ��A�N���̃^�C�~���O�ŊJ�n���t�̏����Ƀ\�[�g�����
            int rowCount = goodsPriceList.Count;

            // ���i�J�n���ŉ��i��񃌃R�[�h���\�[�g�i�~���j
            SortedList<DateTime, GoodsPrice> sortedGoodsPriceRowList = new SortedList<DateTime, GoodsPrice>();
            for (int i = 0; i < rowCount; i++)
            {
                DateTime key = goodsPriceList[i].PriceStartDate;
                if (key.Equals(DateTime.MinValue))
                {
                    key = key.AddMilliseconds((double)(rowCount - i));
                }
                sortedGoodsPriceRowList.Add(key, goodsPriceList[i]);
            }
            // --- DEL 2010/09/07 ---------->>>>>
            //// ���i�J�n�����w������̃��R�[�h�̂����A�ŋ߂̂��̂�Ԃ�
            //for (int i = rowCount - 1; i >= 0; i--)
            //{
            //    DateTime key = sortedGoodsPriceRowList.Keys[i];
            //    if (sortedGoodsPriceRowList[key].PriceStartDate <= dateTime)
            //    {
            //        return sortedGoodsPriceRowList[key];
            //    }
            //}
            //return null;    // ���i�J�n���������̃��R�[�h�����Ȃ��ꍇ
            // --- DEL 2010/09/07 ----------<<<<<

            // --- ADD 2010/09/07 ---------->>>>>
            int count = 0;
            bool flag = false;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[i];
                if (sortedGoodsPriceRowList[key].PriceStartDate <= dateTime)
                {
                    count = i;
                    flag = true;
                    break;
                }
            }

            // ���i�J�n�����V�X�e�����t
            if (flag)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[count];
                return sortedGoodsPriceRowList[key];
            }
            else
            {
                // ���i�J�n�� > �V�X�e�����t
                if (rowCount != 0)
                {
                    DateTime key = sortedGoodsPriceRowList.Keys[0];
                    sortedGoodsPriceRowList[key].ListPrice = 0;
                    sortedGoodsPriceRowList[key].SalesUnitCost = 0;
                    sortedGoodsPriceRowList[key].StockRate = 0;
                    return sortedGoodsPriceRowList[key];
                }
                // ���i�J�n����NULL
                else
                {
                    GoodsPrice gPrice = new GoodsPrice();
                    gPrice.ListPrice = 0;
                    gPrice.SalesUnitCost = 0;
                    gPrice.StockRate = 0;
                    return gPrice;
                }
            }
            // --- ADD 2010/09/07 ----------<<<<<
        }

        /// <summary>
        /// �����l�f�[�^�擾
        /// </summary>
        public void RenewalSearchInitial()
        {
            // �����l�f�[�^�擾
            string msgInit;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msgInit);
        }
        // --- ADD 2010/08/27 ----------<<<<<

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="delRateList">�폜�f�[�^���X�g</param>
        /// <param name="updRateList">�X�V�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Save(ref ArrayList delRateList, ref ArrayList updRateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                RateWork delRateWork = null;
                RateWork updRateWork = null;
                ArrayList delRateWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList
                ArrayList updRateWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < delRateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    delRateWork = CopyToRateWorkFromRate((Rate)delRateList[i]);
                    delRateWorkList.Add(delRateWork);
                }

                for (int i = 0; i < updRateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    updRateWork = CopyToRateWorkFromRate((Rate)updRateList[i]);
                    updRateWorkList.Add(updRateWork);
                }

                object delparaObj = (object)delRateWorkList;
                object updparaObj = (object)updRateWorkList;

                // �ۑ�����
                status = this._iRateDB.Save(delparaObj, updparaObj, ref message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�ۑ��Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iRateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        #endregion �� Public Methods


        #region �� Private Methods
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <returns>�|���}�X�^�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private SingleGoodsRateSearchParamWork CopyToRateSearchParamWorkFromRateSearchParam(GoodsRateSetSearchParam rateSearchParam)
        {
            SingleGoodsRateSearchParamWork paraWork = new SingleGoodsRateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // ��ƃR�[�h
            paraWork.SectionCode = rateSearchParam.SectionCode;             // ���_�R�[�h
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // �d����R�[�h
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // ���i�|���O���[�v�R�[�h
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // ���[�J�[�R�[�h
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // ���Ӑ�R�[�h
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // ���Ӑ�|���O���[�v�R�[�h
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ���O�C�����_�R�[�h
            paraWork.GoodsNo = rateSearchParam.GoodsNo;       // �i��
            paraWork.BlGoodsCode = rateSearchParam.BlGoodsCode;       // BL�R�[�h
            paraWork.BlGroupCode = rateSearchParam.BlGroupCode;       // BL�O���[�v�R�[�h
            paraWork.ObjectDiv = rateSearchParam.ObjectDiv;       // �Ώۋ敪
            paraWork.UnSettingFlg = rateSearchParam.UnSettingFlg;       // ���ݒ�

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="rateSearchResultWork">�|���}�X�^�������ʃ��[�N</param>
        /// <returns>�|���}�X�^��������</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private GoodsRateSetSearchResult CopyToRateSearchResultFromRateSearchResultWork(SingleGoodsRateSearchResultWork rateSearchResultWork)
        {
            GoodsRateSetSearchResult result = new GoodsRateSetSearchResult();

            // �|���}�X�^���擾
            result.CreateDateTime = rateSearchResultWork.CreateDateTime;            // �쐬����
            result.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // �X�V����
            result.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // ��ƃR�[�h
            result.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
            result.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            result.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            result.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            result.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // �_���폜�敪
            result.SectionCode = rateSearchResultWork.SectionCode;                  // ���_�R�[�h
            result.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // �P���|���ݒ�敪
            result.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // �P�����
            result.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // �|���ݒ�敪
            result.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // �|���ݒ�敪�i���i�j
            result.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // �|���ݒ薼�́i���i�j
            result.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // �|���ݒ�敪�i���Ӑ�j
            result.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // �|���ݒ薼�́i���Ӑ�j
            result.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // ���i���[�J�[�R�[�h
            result.GoodsNo = rateSearchResultWork.GoodsNo;                          // ���i�ԍ�
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank;              // ���i�|�������N
            result.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // ���i�|���O���[�v�R�[�h
            result.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BL�O���[�v�R�[�h
            result.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL���i�R�[�h
            result.CustomerCode = rateSearchResultWork.CustomerCode;                // ���Ӑ�R�[�h
            result.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // ���Ӑ�|���O���[�v�R�[�h
            result.SupplierCd = rateSearchResultWork.SupplierCd;                    // �d����R�[�h
            result.LotCount = rateSearchResultWork.LotCount;                        // ���b�g��
            result.PriceFl = rateSearchResultWork.PriceFl;                          // ���i�i�����j
            result.RateVal = rateSearchResultWork.RateVal;                          // �|��
            result.UpRate = rateSearchResultWork.UpRate;                            // UP��
            result.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // �e���m�ۗ�
            result.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // �P���[�������P��
            result.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // �P���[�������敪
            // �D�ǐݒ�}�X�^�A���i�Ǘ����}�X�^���擾
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // ���i�����ރR�[�h
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BL�R�[�h
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL���i�R�[�h���́i���p�j
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // ���i���[�J�[�R�[�h
            result.MakerName = rateSearchResultWork.MakerName;                      // ���[�J�[����
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // �d����R�[�h

            result.ListPrice = rateSearchResultWork.ListPrice;          // �W�����i
            result.SalesUnitCost = rateSearchResultWork.SalesUnitCost;          // ���P��
            result.RatebLGroupCode = rateSearchResultWork.RatebLGroupCode;          // BL�O���[�v�R�[�h(�|���}�X�^)
            result.RatebLGoodsCode = rateSearchResultWork.RatebLGoodsCode;          // BL���i�R�[�h(�|���}�X�^)
            result.GoodsLogicalDeleteCode = rateSearchResultWork.GoodsLogicalDeleteCode;          // �_���폜�敪(���i�}�X�^)

            return result;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>SingleGoodsRateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            rateWork.CreateDateTime = rate.CreateDateTime;              // �쐬����
            rateWork.UpdateDateTime = rate.UpdateDateTime;              // �X�V����
            rateWork.EnterpriseCode = rate.EnterpriseCode;              // ��ƃR�[�h
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;              // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;        // �_���폜�敪
            rateWork.SectionCode = rate.SectionCode;                    // ���_�R�[�h
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;          // �P���|���ݒ�敪
            rateWork.UnitPriceKind = rate.UnitPriceKind;                // �P�����
            rateWork.RateSettingDivide = rate.RateSettingDivide;        // �|���ݒ�敪
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;              // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;              // �|���ݒ薼�́i���i�j
            rateWork.RateMngCustCd = rate.RateMngCustCd;                // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm;                // �|���ݒ薼�́i���Ӑ�j
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
            rateWork.GoodsNo = rate.GoodsNo;                            // ���i�ԍ�
            rateWork.GoodsRateRank = rate.GoodsRateRank;                // ���i�|�������N
            rateWork.BLGoodsCode = rate.BLGoodsCode;                    // BL���i�R�[�h
            rateWork.CustomerCode = rate.CustomerCode;                  // ���Ӑ�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;            // ���Ӑ�|���O���[�v�R�[�h
            rateWork.SupplierCd = rate.SupplierCd;                      // �d����R�[�h
            rateWork.LotCount = rate.LotCount;                          // ���b�g�� 
            rateWork.PriceFl = rate.PriceFl;                            // ���i
            rateWork.RateVal = rate.RateVal;                            // �|��
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;        // �P���[�������P��
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;          // �P���[�������敪
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;          // ���i�|���O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode;                    // BL�O���[�v�R�[�h
            rateWork.UpRate = rate.UpRate;                              // UP��
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;    // �e���m�ۗ�

            return rateWork;
        }

        // ADD 2010/09/26 --- >>>
        /// <summary>
        /// �P���Z�o�N���X�����f�[�^�Ǎ�����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �P���Z�o�N���X�����f�[�^�Ǎ��������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThread()
        {
            this.ReadInitData(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadSecond()
        {
            this.ReadInitDataSecond(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadThird()
        {
            this.ReadInitDataThird(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs = new GoodsAcs();
            string msg = string.Empty;

            // ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
            this._goodsAcs.IsLocalDBRead = false;

            // �����l�f�[�^�擾
            int status = this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataSecond(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs2 = new GoodsAcs();
            string msg = string.Empty;

            // ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
            this._goodsAcs2.IsLocalDBRead = false;

            // �����l�f�[�^�擾
            int status = this._goodsAcs2.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs2.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// �����f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs3 = new GoodsAcs();
            string msg = string.Empty;

            // ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
            this._goodsAcs3.IsLocalDBRead = false;

            // �����l�f�[�^�擾
            int status = this._goodsAcs3.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs3.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialForth()
        {
            this.ReadInitDataForth();
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadFivth()
        {
            this.ReadInitDataFivth();
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadSixth()
        {
            this.ReadInitDataSixth();
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataForth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread1Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // �N���X�����o�R�s�[����(D��E)
                    //���i�Ǘ����}�X�^�Ɖ��i�}�X�^���̎擾

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ���[�U�[�o�^
                            case 1: // �񋟏����ҏW
                            case 2: // �񋟗D�ǕҏW
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // �d����
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread1ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataFivth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread2Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // �N���X�����o�R�s�[����(D��E)
                    //���i�Ǘ����}�X�^�Ɖ��i�}�X�^���̎擾

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ���[�U�[�o�^
                            case 1: // �񋟏����ҏW
                            case 2: // �񋟗D�ǕҏW
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // �d����
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread2ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���i���f�[�^�擾�p�̃X���b�h
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�擾�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataSixth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread3Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // �N���X�����o�R�s�[����(D��E)
                    //���i�Ǘ����}�X�^�Ɖ��i�}�X�^���̎擾

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ���[�U�[�o�^
                            case 1: // �񋟏����ҏW
                            case 2: // �񋟗D�ǕҏW
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // �d����
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread3ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        // ADD 2010/09/26 --- <<<
        #endregion �� Private Methods
    }
}

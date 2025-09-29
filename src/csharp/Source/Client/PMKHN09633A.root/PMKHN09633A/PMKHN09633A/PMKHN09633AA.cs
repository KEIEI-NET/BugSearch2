//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/13  �C�����e : Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^ �A�N�Z�X�N���X</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
    /// </remarks>
    public class CampaignGoodsStAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static CampaignGoodsStAcs _rateQuoteInputAcs = null;
        private ICampaignLoginDB _campaignLoginDB = null;
        private GoodsAcs _goodsAcs = null;
        private CampaignLinkDataSet.CampaignLinkDataTable _campaignLinkDataTable;
        private CampaignLink _campaignLink = null;
       
        /// <summary>�L�����y�[�����Ӑ惊�X�g</summary>
        public ArrayList _precampaignLinkList = null;
        // ���o���f�t���O
        private bool _extractCancelFlag;
        private IWin32Window _owner = null;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignGoodsStAcs()
        {
            this._campaignLoginDB = MediationCampaignLoginDB.GetCampaignLoginDB();
            this._campaignLinkDataTable = new CampaignLinkDataSet.CampaignLinkDataTable();
            this._campaignLink = new CampaignLink();
            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);

        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public static CampaignGoodsStAcs GetInstance()
        {
            if (_rateQuoteInputAcs == null)
            {
                _rateQuoteInputAcs = new CampaignGoodsStAcs();
            }

            return _rateQuoteInputAcs;
        }
       

        #endregion

        // ===================================================================================== //
        // ����
        // ===================================================================================== //
        # region ��Propertity
        /// <summary>
        /// UI�f�[�^
        /// </summary>
        public CampaignLink CampaignLink
        {
            get { return this._campaignLink; }
        }

        /// <summary>
        /// �e�[�u���v���p�e�B
        /// </summary>
        public CampaignLinkDataSet.CampaignLinkDataTable CampaignLinkDataTable
        {
            get { return _campaignLinkDataTable; }
        }

        /// <summary>
        /// ���o���f�t���O
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="campaignGoodsData">�L�����y�[�����i�N���X</param>
        /// <param name="campaignLinkobjList">���Ӑ�̃��X�g</param>
        /// <param name="readCount">���i�}�X�^�̓Ǎ�����</param>
        /// <param name="addCount">�L�����y�[���Ǘ��}�X�^�̒ǉ�����(�_���폜�f�[�^���X�V�����ꍇ���ǉ������ɉ��Z����)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�����������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public int SearchData(CampaignGoodsData campaignGoodsData, ArrayList campaignLinkobjList, ref int readCount, ref int addCount)
        {
            int campaignLinkFlag = 1;

            string msg = "";

            // UI�f�[�^�N���X�����[�N
            CampaignGoodsDataWork campaignGoodsDataWork = CopyToCampaignGoodsDataWorkFromCampaignGoodsData(campaignGoodsData);
            List<GoodsUnitData> goodsUnitDataList;
            PartsInfoDataSet partsInfoDataSet;

            // ���o�����̍쐬
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode =campaignGoodsData.EnterpriseCode ;
            goodsCndtn.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            goodsCndtn.BLGoodsCode = campaignGoodsData.BLGoodsCode;  // ADD 2011/07/13 
            goodsCndtn.GoodsNo = campaignGoodsData.GoodsNoNoneHyphen;
            //goodsCndtn.GoodsNoSrchTyp = 1; // DEL 2011/07/13
            goodsCndtn.GoodsNoSrchTyp = 1;  // ADD 2011/07/13
            goodsCndtn.IsSettingSupplier = 1; 

            
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int Flag = 0;
            try
            {
                ArrayList campaignGoodsDataWorkList = new ArrayList();
                object objcampaignGoodsDataWorkList = campaignGoodsDataWorkList as object;

                //ArrayList ptMkrPricePm =new ArrayList();   // DEL 2011/07/13 
                //object ptMkrPricePmobj = ptMkrPricePm as object;  // DEL 2011/07/13 

                ArrayList precampaignLinkWorkList = new ArrayList();
                ArrayList addcampaignLinkWorkList = new ArrayList();

                # region �L�����y�[���Ώۋ敪�͂P�̏ꍇ�A���Ӑ�̃��X�g�𐶐�����B

                if (campaignGoodsDataWork.CampaignObjDiv == 1)
                {
                    if (campaignLinkobjList == null)
                    {
                        addcampaignLinkWorkList = this._precampaignLinkList;
                    }
                    else
                    {
                        foreach (CampaignLinkWork campaignLink in campaignLinkobjList)
                        {
                            campaignLinkFlag = 1;
                            foreach (CampaignLinkWork precampaignLink in this._precampaignLinkList)
                            {
                                if (campaignLink.CustomerCode == precampaignLink.CustomerCode)
                                {
                                    campaignLinkFlag = 0;
                                    break;
                                }
                            }
                            if (campaignLinkFlag == 1 && campaignLinkobjList.Count>0)
                            {
                                campaignLink.LogicalDeleteCode = 1;
                            }
                            else
                            {
                                campaignLink.LogicalDeleteCode = 0;
                            }
                            precampaignLinkWorkList.Add(campaignLink);
                            addcampaignLinkWorkList.Add(campaignLink);
                        }

                        foreach (CampaignLinkWork precampaignLink in this._precampaignLinkList)
                        {
                            campaignLinkFlag = 1;
                            foreach (CampaignLinkWork addcampaignLink in precampaignLinkWorkList)
                            {
                                if (addcampaignLink.CustomerCode == precampaignLink.CustomerCode)
                                {
                                    campaignLinkFlag = 0;
                                    break;
                                }
                            }
                            if (campaignLinkFlag == 1)
                            {
                                addcampaignLinkWorkList.Add(precampaignLink);
                            }
                        }
                    }
                   
                }

                # endregion

                object objcampaignLinkList = addcampaignLinkWorkList as object;

                ArrayList campaignMngList = new ArrayList();
                object objcampaignMngList = campaignMngList as object;

                if (this._extractCancelFlag == true)
                {
                    return 0;
                }
                this._campaignLoginDB.Search(ref objcampaignGoodsDataWorkList, campaignGoodsDataWork);
                this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                # region ���i�}�X�^(���[�U�[)�������ꂽ�f�[�^�ƕ��i���i�}�X�^(PM)(��)�������ꂽ�f�[�^�͈ꊇ�o�^�p�̃��X�g���쐬����

                ArrayList campaignGoodsDataWorkListCom = objcampaignGoodsDataWorkList as ArrayList;
                //ArrayList ptMkrPricePmCom = ptMkrPricePmobj as ArrayList;  // DEL 2011/07/13 
                ArrayList campaignGoodsDataWorkLists = new ArrayList();

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    GoodsUWork goodsUWorks = new GoodsUWork();

                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                    //if ((campaignGoodsData.BLGroupCodeSt == 0 && campaignGoodsData.BLGroupCodeEd == 0)
                    //    ||(campaignGoodsData.BLGroupCodeSt != 0 && campaignGoodsData.BLGroupCodeEd == 0 && goodsUnitData.BLGoodsCode >= campaignGoodsData.BLGroupCodeSt)
                    //    ||(campaignGoodsData.BLGroupCodeSt == 0 && campaignGoodsData.BLGroupCodeEd != 0 && goodsUnitData.BLGoodsCode <= campaignGoodsData.BLGroupCodeEd)
                    //    ||(campaignGoodsData.BLGroupCodeSt != 0 && campaignGoodsData.BLGroupCodeEd != 0 && goodsUnitData.BLGoodsCode <= campaignGoodsData.BLGroupCodeEd && goodsUnitData.BLGoodsCode >= campaignGoodsData.BLGroupCodeSt)
                    //  )
                    //{
                        goodsUWorks.GoodsNo = goodsUnitData.GoodsNo;
                        goodsUWorks.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                        campaignGoodsDataWorkLists.Add(goodsUWorks);
                    //}
                    // ----- UPD 2011/07/13 ------- <<<<<<<<<

                }

                foreach (GoodsUWork GoodsUWorks in campaignGoodsDataWorkListCom)
                {
                    Flag = -1;
                    //if (ptMkrPricePmCom.Count == 0)  // DEL 2011/07/13 
                    if (campaignGoodsDataWorkLists.Count == 0)  // ADD 2011/07/13 
                    {
                        campaignGoodsDataWorkLists = campaignGoodsDataWorkListCom;

                        break;
                    }
                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {

                        if (goodsUnitData.GoodsNo == GoodsUWorks.GoodsNo)
                        {
                            Flag = 1;
                            break;
                        }

                    }
                    if (Flag == -1)
                    {
                        campaignGoodsDataWorkLists.Add(GoodsUWorks);
                    }

                }

                # endregion

                readCount = campaignGoodsDataWorkLists.Count;

                if (readCount > 0)
                {
                    status = 0;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    
                    status = this._campaignLoginDB.Search(ref objcampaignMngList, campaignGoodsDataWork, 0);

                    ArrayList campaignMngLists = objcampaignMngList as ArrayList;
                    ArrayList addcampaignGoodsDataWorkList = new ArrayList();

                    foreach (GoodsUWork goodsUWork in campaignGoodsDataWorkLists)
                    {
                        Flag = -1;
                        if (campaignMngLists.Count == 0)
                        {
                            break;
                        }
                        foreach (CampaignObjGoodsStWork campaignMng in campaignMngLists)
                        {

                            if (goodsUWork.GoodsNo == campaignMng.GoodsNo)
                            {
                                if (campaignMng.LogicalDeleteCode == 1)
                                {
                                    goodsUWork.LogicalDeleteCode = 1;
                                    Flag = -1;
                                    break;

                                }
                                Flag = 1;
                                break;
                            }
                           
                        }
                        if (Flag == -1)
                        {
                            addcampaignGoodsDataWorkList.Add(goodsUWork);
                        }
                        
                    }

                    if (this._extractCancelFlag == true)
                    {
                        return 0;
                    }

                    if (campaignGoodsDataWorkLists.Count == 0 || campaignMngLists.Count == 0)
                    {
                        addCount = campaignGoodsDataWorkLists.Count;
                        if (addCount > 0)
                        {
                            object objcampaignGoodsDataWorkLists = campaignGoodsDataWorkLists as object;
                            status = this._campaignLoginDB.Write(objcampaignGoodsDataWorkLists, campaignGoodsDataWork, objcampaignLinkList);
                        }
                    }
                    else
                    {
                        addCount = addcampaignGoodsDataWorkList.Count;
                        if (addCount > 0)
                        {
                            object objcampaignGoodsDataWorkLists = addcampaignGoodsDataWorkList as object;
                            status = this._campaignLoginDB.Write(objcampaignGoodsDataWorkLists, campaignGoodsDataWork, objcampaignLinkList);
                        }
                    }
                    if (this._extractCancelFlag == true)
                    {
                        return 0;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���ݒ�f�[�^���ǂ�
        /// </summary>
        /// <param name="campaignSt">�L�����y�[���ݒ�̃f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�f�[�^���ǂށB</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCampaignSt(ref CampaignSt campaignSt)
        {
            // UI�f�[�^�N���X�����[�N
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromcampaignSt(campaignSt);

            ArrayList campaignStList = new ArrayList();
            object objcampaignStList = campaignStList as object;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = this._campaignLoginDB.SearchCampaignSt(ref objcampaignStList, campaignStWork);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            ArrayList campaignStLists=objcampaignStList as ArrayList;
            foreach (CampaignStWork work in campaignStLists)
            {
                campaignSt.CampaignObjDiv = work.CampaignObjDiv;
                campaignSt.CampaignName = work.CampaignName;
                campaignSt.ApplyEndDate = work.ApplyEndDate;
                campaignSt.ApplyStaDate = work.ApplyStaDate;
                campaignSt.SectionCode = work.SectionCode;
            }
             return status;
        }
      
        /// <summary>
        /// ���Ӑ挟������
        /// </summary>
        /// <param name="CampaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ挟���������s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCustomer(int CampaignCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // �����f�[�^�N���A
            this._campaignLinkDataTable.Clear();

            try
            {
                // ��������
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
                this._precampaignLinkList = new ArrayList();
                campaignLinkWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                campaignLinkWork.CampaignCode = CampaignCode;

                // ��������
                ArrayList campaignLinkList = new ArrayList();
                object objCampaignLinkList = campaignLinkList as object;

                status = this._campaignLoginDB.SearchCustomer(campaignLinkWork, ref objCampaignLinkList);

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCampaignLinkList as ArrayList;

                    foreach (CampaignLinkWork work in resultList)
                    {
                        this._precampaignLinkList.Add(work);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^���[�N�N���X�˃L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^Row�j
        /// </summary>
        /// <param name="campaignLinkWork">�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^Row</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^���[�N�N���X�˃L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^Row�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignLinkDataSet.CampaignLinkRow CopyToRowFromCampaignLinkWork(CampaignLinkWork campaignLinkWork)
        {
            CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();
            row.CustomerCode = campaignLinkWork.CustomerCode.ToString("00000000");

            return row;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[�����̐ݒ�N���X�˃L�����y�[�����̐ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="campaignSt">�L�����y�[�����i�}�X�^���[�N�N���X</param>
        /// <returns>�L�����y�[�����̐ݒ�}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o�[�R�s�[�����i�L�����y�[�����̐ݒ�N���X�˃L�����y�[�����̐ݒ�}�X�^���[�N�N���X�j</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromcampaignSt(CampaignSt campaignSt)
        {
            CampaignStWork campaignStWork = new CampaignStWork();

            campaignStWork.EnterpriseCode = campaignSt.EnterpriseCode;
            campaignStWork.CampaignCode = campaignSt.CampaignCode;

            return campaignStWork;
        }


        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[�����i�}�X�^���[�N�N���X�˃L�����y�[�����i�N���X�j
        /// </summary>
        /// <param name="campaignGoodsDataWork">�L�����y�[�����i�}�X�^���[�N�N���X</param>
        /// <returns>�L�����y�[�����i�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����i�}�X�^���[�N�N���X����L�����y�[�����i�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignGoodsData CopyToCampaignGoodsDataFromCampaignGoodsDataWork(CampaignGoodsDataWork campaignGoodsDataWork)
        {
            CampaignGoodsData campaignGoodsData = new CampaignGoodsData();
            campaignGoodsData.GoodsNoNoneHyphen = campaignGoodsDataWork.GoodsNoNoneHyphen;
            campaignGoodsData.GoodsMakerCd = campaignGoodsDataWork.GoodsMakerCd;
            campaignGoodsData.EnterpriseCode = campaignGoodsDataWork.EnterpriseCode;

            return campaignGoodsData;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[�����i�N���X�˃L�����y�[�����i���[�N�N���X�j
        /// </summary>
        /// <param name="campaignGoodsData">�L�����y�[�����i�N���X</param>
        /// <returns>�L�����y�[�����i���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����i�N���X����L�����y�[�����i���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private CampaignGoodsDataWork CopyToCampaignGoodsDataWorkFromCampaignGoodsData(CampaignGoodsData campaignGoodsData)
        {
            CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();

            campaignGoodsDataWork.GoodsNoNoneHyphen = campaignGoodsData.GoodsNoNoneHyphen;
            campaignGoodsDataWork.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            campaignGoodsDataWork.EnterpriseCode = campaignGoodsData.EnterpriseCode;
            campaignGoodsDataWork.SectionCode = campaignGoodsData.SectionCode;
            campaignGoodsDataWork.ApplyStaDate = campaignGoodsData.ApplyStaDate;
            campaignGoodsDataWork.ApplyEndDate = campaignGoodsData.ApplyEndDate;
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //campaignGoodsDataWork.BLGroupCodeSt = campaignGoodsData.BLGroupCodeSt;
            campaignGoodsDataWork.BLGroupCodeSt = campaignGoodsData.BLGoodsCode;
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            campaignGoodsDataWork.BLGroupCodeEd = campaignGoodsData.BLGroupCodeEd;
            campaignGoodsDataWork.CampaignCode = campaignGoodsData.CampaignCode;
            campaignGoodsDataWork.CampaignName = campaignGoodsData.CampaignName;
            campaignGoodsDataWork.CampaignObjDiv = campaignGoodsData.CampaignObjDiv;
           
            return campaignGoodsDataWork;
        }

        # endregion
       
    }
}
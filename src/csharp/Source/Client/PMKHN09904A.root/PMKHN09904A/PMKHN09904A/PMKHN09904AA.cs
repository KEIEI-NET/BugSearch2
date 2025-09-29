using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �|���ꊇ�C���E�o�^�U�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ꊇ�C���E�o�^�U�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class RateUpdateAcs
    {
        #region �� Private Members
        // �|���}�X�^�����[�g
        private IRate2DB _iRate2DB = null;
        // �����ݒ�}�X�^�����[�g
        private IPureSettingPmDB _iPureSettingPmDB = null;
        // �w�ʐݒ�}�X�^�����[�g
        private IPartsLayerStPmDB _iPartsLayerStPmDB = null;
        // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSet stc_PrtOutSet = null;
        // ���[�o�͐ݒ�A�N�Z�X�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs = new PrtOutSetAcs();
        private static Employee stc_Employee = new Employee();

        /// <summary>
        /// BL�R�[�h��� key: BL�R�[�h�@value: BL�R�[�h���
        /// </summary>
        private Dictionary<int, BLGoodsCdUMnt> _blCodeDic = new Dictionary<int, BLGoodsCdUMnt>();

        /// <summary>
        /// BL�O���[�v�R�[�h���
        /// </summary>
        private Dictionary<int, BLGroupU> _blGroupCodeDic = new Dictionary<int, BLGroupU>();
        #endregion �� Private Members 

        #region �� Construcstor
        /// <summary>
        /// �|���ꊇ�C���E�o�^�U�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ꊇ�C���E�o�^�U�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public RateUpdateAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRate2DB = (IRate2DB)MediationRate2DB.GetRate2DB();
                this._iPureSettingPmDB = (IPureSettingPmDB)MediationPureSettingPmDB.GetPureSettingPmDB();
                this._iPartsLayerStPmDB = (IPartsLayerStPmDB)MediationPartsLayerStPmDB.GetPartsLayerStPmDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRate2DB = null;
            }
        }
        #endregion �� Construcstor

        #region �v���p�e�B�[
        /// <summary>
        ///  BL�R�[�h���
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLCodeDic
        {
            get{return this._blCodeDic;}
            set{this._blCodeDic=value;}
        }

        /// <summary>
        ///  BL�O���[�v�R�[�h���
        /// </summary>
        public Dictionary<int, BLGroupU> BLGroupCodeDic
        {
            get { return this._blGroupCodeDic; }
            set { this._blGroupCodeDic = value; }
        }
        #endregion


        #region �� Public Methods
        /// <summary>
        /// �|���}�X�^�X�V����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="eFlag">�V�ǉ��s�t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Write(ArrayList saveList,bool eFlag)
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

                status = this._iRate2DB.Write(ref paraObj, eFlag);
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
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
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
                Rate2Work[] rateWorks = (Rate2Work[])rateWorkList.ToArray(typeof(Rate2Work));

                // �V���A���C�Y
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);

                // �����폜����
                status = this._iRate2DB.DeleteRate(paraRateWork);
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
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Search(out List<Rate2SearchResult> rateSearchResultList, Rate2SearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
             BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();
            rateSearchResultList = new List<Rate2SearchResult>();
            try
            {
                // �N���X�����o�R�s�[����(E��D)
                // ���������ݒ�
                Rate2ParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                // ��������(���[�J�[�R�[�h�́u0-999�v�̏ꍇ�A������񌟍�)
                if (rateSearchParam.GoodsMakerCd > 0 && rateSearchParam.GoodsMakerCd < 1000)
                {
                    // �����ݒ�List�쐬
                    List<Rate2SearchResult> pureDataSettingList;

                    // �����f�[�^List�ݒ�
                    PureDataSettingList(out pureDataSettingList, rateSearchParam);
                    
                    object retGoodsObj;
                    object retRateObj;
                    //���i�Ǘ����}�X�^�Ɗ|���}�X�^����
                    status = this._iRate2DB.SearchPureRate(out retGoodsObj, out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                    if (status == 0)
                    {
                        //�����ݒ�List�Ə��i�Ǘ����֘A
                        ArrayList retGoodsList = retGoodsObj as ArrayList;
                        ArrayList retRateList = retRateObj as ArrayList;
                        List<Rate2SearchResult> pureGoodsSearchResult;

                        // �ALL���0000��̃f�[�^�t�B���^
                        ArrayList filterList = new ArrayList();
                        DataFilter(retRateList, rateSearchParam, ref filterList);

                        // �������������ݒ�f�[�^�Ə��i�Ǘ����̊֘A�i�����ݒ�f�[�^ left join ���i�Ǘ����   join��A�w�ʏ��Ɗ֘A�i�w�ʂ̏ꍇ�j�j��������
                        MergePureAndGoods(out pureGoodsSearchResult, pureDataSettingList, retGoodsList, rateSearchParam, 0);

                        // ���������������i�Ɗ|���֘A�i�����ݒ�f�[�^ left join ���i�Ǘ���� left join �|�����j��������
                        MergePureGoodsAndRate(out rateSearchResultList, pureGoodsSearchResult, filterList, rateSearchParam);


                        // ������A���ʂ��Ȃ��ꍇ
                        if (rateSearchResultList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        // �e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
                        SetParentData(ref rateSearchResultList, rateSearchParam);
                        //�q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
                        if (rateSearchParam.GoodsChangeMode == 0) // ���i�|���̏ꍇ�A�q�e�f�[�^�쐬
                        {
                            SetGroupParentData(ref rateSearchResultList);
                        }
                        else                                      // �w�ʂ̏ꍇ�A�q�e�f�[�^�쐬
                        {
                            SetGroupParaentDataByRank(ref rateSearchResultList);
                        }
                        
                        // �\�[�g����
                        Rate2SchRstSort rate2SchRstSort = new Rate2SchRstSort(rateSearchParam.GoodsChangeMode);
                        rateSearchResultList.Sort(rate2SchRstSort);
                    }
                }
                else
                {
 �@                 object retPrmSettingObj;
                    object retGoodsObj;
                    object retRateObj;
                    //�D�ǐݒ�}�X�^�Ə��i�Ǘ����}�X�^�Ɗ|���}�X�^����
                    status = this._iRate2DB.SearchPrmRate(out retPrmSettingObj, out retGoodsObj, out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                    if (status == 0)
                    {
                        //�D�ǐݒ�List�Ə��i�Ǘ����֘A
                        List<Rate2SearchResult> retPrmSettingList = new List<Rate2SearchResult>();
                        ArrayList retGoodsList = retGoodsObj as ArrayList;
                        ArrayList retRateList = retRateObj as ArrayList;
                        List<Rate2SearchResult> prmGoodsSearchResult;

                        // �ALL���0000��̃f�[�^�t�B���^
                        ArrayList filterList = new ArrayList();
                        DataFilter(retRateList, rateSearchParam, ref filterList);

                        //�N���X�����o�R�s�[����(D��E)
                        foreach (Rate2SearchResultWork retWork in retPrmSettingObj as ArrayList)
                        {
                            // �N���X�����o�R�s�[����(D��E)
                            retPrmSettingList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                        }

                        // ���������D�ǐݒ�f�[�^�Ə��i�Ǘ����̊֘A�i�D�ǐݒ�f�[�^ left join ���i�Ǘ����   join��A�w�ʏ��Ɗ֘A�i�w�ʂ̏ꍇ�j�j��������
                        MergePureAndGoods(out prmGoodsSearchResult, retPrmSettingList, retGoodsList, rateSearchParam, 1);

                        // ���������D�Ǐ��i�Ɗ|���֘A�i�D�ǐݒ�f�[�^ left join ���i�Ǘ���� left join �|�����j��������
                        MergePureGoodsAndRate(out rateSearchResultList, prmGoodsSearchResult, filterList, rateSearchParam);

                        // ������A���ʂ��Ȃ��ꍇ
                        if (rateSearchResultList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        // �e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
                        SetParentData(ref rateSearchResultList, rateSearchParam);
                        //�q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
                        if (rateSearchParam.GoodsChangeMode == 0) // ���i�|���̏ꍇ�A�q�e�f�[�^�쐬
                        {
                            SetGroupParentData(ref rateSearchResultList);
                        }
                        else                                      // �w�ʂ̏ꍇ�A�q�e�f�[�^�쐬
                        {
                            SetGroupParaentDataByRank(ref rateSearchResultList);
                        }

                        // �\�[�g����
                        Rate2SchRstSort rate2SchRstSort = new Rate2SchRstSort(rateSearchParam.GoodsChangeMode);
                        rateSearchResultList.Sort(rate2SchRstSort);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<Rate2SearchResult>();
            }

            return (status);
        }

        /// <summary>
        /// �P�ꏤ�i���̊|������
        /// </summary>
        /// <param name="rate2WorkList">�|���}�X�^�������ʃ��X�g</param>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���������܂��B</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/04/03</br>
        /// </remarks>
        public int SearchByOneGoodsInfo(out List<Rate2SearchResult> rate2SearchResultList, Rate2SearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            rate2SearchResultList = new List<Rate2SearchResult>();
            try
            {
                // �N���X�����o�R�s�[����(E��D)
                // ���������ݒ�
                Rate2ParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;

                object retRateObj;
                //�|���}�X�^����
                status = this._iRate2DB.SearchRate(out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList rate2WorkList = retRateObj as ArrayList;
                    // �ALL���0000��̃f�[�^�t�B���^
                    ArrayList filterList = new ArrayList();
                    DataFilter(rate2WorkList, rateSearchParam, ref filterList);
                    // ���_�Ⴂ�f�[�^�𕪗�����
                    Dictionary<string, ArrayList> rateDic;
                    GetRateBySection(out rateDic, filterList);
                    // �ŏ����b�g�����܂ގ�KeyList���擾����
                    List<string> lotCountKeyList;
                    GetRateByLotCount(out lotCountKeyList, filterList);
                    foreach (string rateDickey in rateDic.Keys)
                    {
                        // ��ŏ����b�g���̃f�[�^���擾���Ȃ�
                        if (!lotCountKeyList.Contains(rateDickey))
                        {
                            continue;
                        }
                        Rate2SearchResult tempSearchResult = new Rate2SearchResult();
                        Rate2Work rateResultWork = new Rate2Work();

                        #region ���_�̂���āA���i�Ǘ���񕪗�����
                        ArrayList rateBySectionList = rateDic[rateDickey] as ArrayList;
                        // ���_�������ꍇ
                        if (rateBySectionList.Count == 1)
                        {
                            rateResultWork = rateBySectionList[0] as Rate2Work;
                        }
                        // �����̋��_������ꍇ
                        else
                        {
                            foreach (Rate2Work tempRate2Work in rateBySectionList)
                            {
                                // ��ʓ��͋��_�Ɠ����f�[�^��I������
                                if (tempRate2Work.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                                {
                                    rateResultWork = tempRate2Work;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        #endregion ���_�̂���āA���i�Ǘ���񕪗�����

                        // �������ʂ�Rate2WorkList����Rate2SearchResultList�ɓn���܂�
                        CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);
                        tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank;
                        rate2SearchResultList.Add(tempSearchResult);
                    }
                    
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            return status;
        }

        #region �� ���[�ݒ�f�[�^�擾
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2013/03/05</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";
            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ���[�ݒ�f�[�^�擾

        #endregion �� Public Methods

        #region �� Private Methods
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <returns>�|���}�X�^�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2ParamWork CopyToRateSearchParamWorkFromRateSearchParam(Rate2SearchParam rateSearchParam)
        {
            Rate2ParamWork paraWork = new Rate2ParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // ��ƃR�[�h
            paraWork.SectionCode = rateSearchParam.SectionCode;             // ���_�R�[�h
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // �d����R�[�h
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // ���i�|���O���[�v�R�[�h
            paraWork.GoodsRateRank = rateSearchParam.GoodsRateRank;         // �w��
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // ���[�J�[�R�[�h
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // ���Ӑ�R�[�h
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // ���Ӑ�|���O���[�v�R�[�h
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ���O�C�����_�R�[�h

            paraWork.GoodsChangeMode = rateSearchParam.GoodsChangeMode;

            paraWork.BlCd = rateSearchParam.BlCd;                          // BL�R�[�h
            paraWork.GroupCd = rateSearchParam.GroupCd;                      // BL�O���[�v�R�[�h
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;  // �O���[�v�R�[�h


            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="rateSearchResultWork">�|���}�X�^�������ʃ��[�N</param>
        /// <returns>�|���}�X�^��������</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2SearchResult CopyToRateSearchResultFromRateSearchResultWork(Rate2SearchResultWork rateSearchResultWork)
        {
            Rate2SearchResult result = new Rate2SearchResult();

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
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank.Trim();              // ���i�|�������N
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
            // BL�O���[�v�R�[�h�}�X�^
            result.BGBLGroupCode = rateSearchResultWork.BGBLGroupCode;              // �O���[�v�R�[�h
            result.BGBLGroupKanaName = rateSearchResultWork.BGBLGroupKanaName;      // �O���[�v�R�[�h�h�J�i����
            // �D�ǐݒ�}�X�^�A���i�Ǘ����}�X�^���擾
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // ���i�����ރR�[�h
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BL�R�[�h
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL���i�R�[�h���́i���p�j
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // ���i���[�J�[�R�[�h
            result.EnFlag = rateSearchResultWork.EnFlag;                      // ���[�J�[����
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // �d����R�[�h

            return result;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>Rate2Work</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2Work CopyToRateWorkFromRate(Rate rate)
        {
            Rate2Work rateWork = new Rate2Work();

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

        /// <summary>
        /// �ALL���0000��̃f�[�^�t�B���^
        /// </summary>
        /// <param name="rateSearchResultList">�������X�g</param>
        /// <param name="rateSearchParam">��������</param>
        /// <param name="filterList">���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note        : �ALL���0000��̃f�[�^�t�B���^���s���܂��B</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/03/21</br>
        /// </remarks>
        private void DataFilter(ArrayList retRateList, Rate2SearchParam rateSearchParam, ref ArrayList filterList)
        {
            if (rateSearchParam.CustomerSearchMode == 0 && rateSearchParam.CustRateGrpCode.Length == 1)
            {
                foreach (int key in rateSearchParam.CustRateGrpCode)
                {
                    // �ALL��̂ݏꍇ
                    if (key == -1)
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // �ALL��݂̂̏ꍇ�A�|���ݒ�敪(���Ӑ�)��5�F�d����
                            if (rate2Work.RateMngCustCd == "5")
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // �0000��̂ݏꍇ
                    else if (key == 0)
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // �0000��݂̂̏ꍇ�A�����f�[�^�|���ݒ�敪(���Ӑ�)��3�F���Ӑ�|��G+�d����G�����f�[�^�|���ݒ�敪(���Ӑ�)��5�F�d����
                            if ((rate2Work.RateMngCustCd == "3" && rate2Work.UnitPriceKind == "1") || (rate2Work.RateMngCustCd == "5" && rate2Work.UnitPriceKind == "2"))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    else
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            filterList.Add(rate2Work);
                        }
                    }
                }
            }
            else
            {
                if (rateSearchParam.CustomerSearchMode == 0)
                {
                    List<int> lst = new List<int>();
                    lst.AddRange(rateSearchParam.CustRateGrpCode);
                    // ���Ӑ�|���O���[�v�������[�h�ŁA��������ALL�������ꍇ
                    if (!lst.Contains(-1) && lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // �����f�[�^�Ɠ��Ӑ�|��G�ݒ�L�蔄���f�[�^��ۗ�
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && rate2Work.RateMngCustCd != "5"))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // ���Ӑ�|���O���[�v�������[�h�ŁA���������u0000�v�������ꍇ
                    else if (lst.Contains(-1) && !lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // �����f�[�^�Ɠ��Ӑ�|��G�u0000�v�ȊO�̔����f�[�^��ۗ�
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && (rate2Work.RateMngCustCd != "3" || rate2Work.CustRateGrpCode != 0)))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // ���Ӑ�|���O���[�v�������[�h�ŁA��������ALL�Ɓu0000�v�����ꍇ
                    else if (!lst.Contains(-1) && !lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // �����f�[�^�Ɠ��Ӑ�|��G�u0000�v��ALL�ȊO�̔����f�[�^��ۗ�
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && rate2Work.CustRateGrpCode != 0))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    else
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            filterList.Add(rate2Work);
                        }
                    }
                }
                else
                {
                    foreach (Rate2Work rate2Work in retRateList)
                    {
                        filterList.Add(rate2Work);
                    }
                }
            }
        }

        #region �����f�[�^�Ɗ|���f�[�^����
        /// <summary>
        /// �����f�[�^List�ݒ�
        /// </summary>
        /// <param name="pureDataSettingList">�����ݒ�f�[�^List</param>
        /// <param name="rateSearchParam">��ʂ̓��͏���</param>
        private void PureDataSettingList(out List<Rate2SearchResult> pureDataSettingList, Rate2SearchParam rateSearchParam)
        {
            pureDataSettingList = new List<Rate2SearchResult>();
            object pureSettingPmWorkPbj;
            // �����f�[�^Dic
            Dictionary<int, PureSettingPmWork> pureSettingPmWorkDic = new Dictionary<int, PureSettingPmWork>();

            #region ������񌟍�
            // ��������
            PureSettingPmWork paraPureSettingPmWork = new PureSettingPmWork();

            // ���������ݒ�F���[�J�[
            paraPureSettingPmWork.PartsMakerCode = rateSearchParam.GoodsMakerCd;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �����ݒ����������
            status = this._iPureSettingPmDB.Search(out pureSettingPmWorkPbj, paraPureSettingPmWork);
            #endregion


            // ������񌟍������̏ꍇ
            if (status == 0)
            {
                #region �������ݒ�
                ArrayList pureSettingPmWorkList = pureSettingPmWorkPbj as ArrayList;
                // �������ݒ�
                foreach (PureSettingPmWork pureSettingPmWork in pureSettingPmWorkList)
                {
                    // �����������i�|��G����͓��͂����ꍇ�B
                    if (rateSearchParam.GoodsRateGrpCode != 0
                        && rateSearchParam.GoodsRateGrpCode != pureSettingPmWork.GoodsMGroup)
                    {
                        continue;
                    }

                    // ����Dic�쐬
                    if(!pureSettingPmWorkDic.ContainsKey(pureSettingPmWork.BLGoodsCode))
                    {
                        pureSettingPmWorkDic.Add(pureSettingPmWork.BLGoodsCode, pureSettingPmWork);
                    }
                }
                #endregion �������ݒ�

                // �������List�ݒ�
                Rate2SearchResult pureSearchResult;
                foreach (int blCode in pureSettingPmWorkDic.Keys)
                {
                �@�@// ���i�|��G�̏ꍇ
                    pureSearchResult = new Rate2SearchResult();
                    // BLCode
                    pureSearchResult.PrmTbsPartsCode = blCode;
                    // ���i�|���N���[�v
                    pureSearchResult.PrmGoodsMGroup= pureSettingPmWorkDic[blCode].GoodsMGroup;
                    // ���[�J�[
                    pureSearchResult.PrmPartsMakerCd = pureSettingPmWorkDic[blCode].PartsMakerCode;
                    pureDataSettingList.Add(pureSearchResult);
                }
                //BL�}�X�^����ABLCode����āA�a�k�R�[�h���Ƃa�k�O���[�v�擾����
                foreach(Rate2SearchResult tempSearchResult in pureDataSettingList)
                {
                    if (this.BLCodeDic.Count > 0)
                    {

                        if (this.BLCodeDic.ContainsKey(tempSearchResult.PrmTbsPartsCode))
                        {
                            tempSearchResult.BLGoodsHalfName = this.BLCodeDic[tempSearchResult.PrmTbsPartsCode].BLGoodsHalfName;//�a�k�R�[�h��
                            tempSearchResult.BGBLGroupCode = this.BLCodeDic[tempSearchResult.PrmTbsPartsCode].BLGloupCode;// BL�O���[�v�R�[�h
                        }
                       
                    }
                }
            }
        }

        /// <summary>
        /// �����ݒ�f�[�^�Ə��i�Ǘ����̊֘A
        /// </summary>
        /// <param name="pureGoodsList">�֘A�擾�f�[�^</param>
        /// <param name="pureSettingList">�����ݒ�f�[�^</param>
        /// <param name="goodsList">���i�Ǘ���񂩂�擾���i�f�[�^</param>
        /// <param name="mode">0:���� 1:�D��</param>
        /// <br>Note       : �����ݒ�f�[�^�Ə��i�Ǘ����̊֘A�B</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/02</br>
        private void MergePureAndGoods(out List<Rate2SearchResult> pureGoodsList,
                                       List<Rate2SearchResult> pureSettingList, 
                                       ArrayList goodsList,
                                       Rate2SearchParam rateSearchParam,
                                       int mode)
        {
            // �߂邵�����X�g����������
            pureGoodsList = new List<Rate2SearchResult>();
            // �w�ʃf�[�^Dic�ikey: BLCode; value: �w�ʃ��X�g�j
            Dictionary<string, ArrayList> partsLayerStPmWorkDic = new Dictionary<string, ArrayList>();

            #region �D�揇�̂���āA�����擾���i�Ǘ����𕪗�����
            //�D�揇�F
            //�@�@�@�@�@�@���[�J�[�R�[�h�@�{�@�����ށ@+�@�a�k�R�[�h
            //�@�@�@�@�A�@���[�J�[�R�[�h�@�{�@�����ށ@
            //�@�@�@�@�B�@���[�J�[�R�[�h
            //���i�Ǘ����pDictionary��`
            Dictionary<string, ArrayList>[] goodsDics = new Dictionary<string, ArrayList>[3];
            for (int i = 0; i < goodsDics.Length; i++)
            {
                goodsDics[i] = new Dictionary<string, ArrayList>();
            }
            //List --> Dictionary �쐬
            ArrayList tempGoodsList;
            foreach (Rate2SearchResultWork temp in goodsList)
            {
                tempGoodsList = new ArrayList();
                string k =temp.PrmPartsMakerCd.ToString() + "-" + temp.PrmGoodsMGroup.ToString() + "-" + temp.PrmTbsPartsCode.ToString();
                //���[�J�[�R�[�h�@�{�@�����ށ@+�@�a�k�R�[�h
                if (temp.PrmTbsPartsCode != 0)
                {
                    if (!goodsDics[0].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[0].Add(k, tempGoodsList);
                    }
                    //�ʂ̋��_�̃f�[�^��ǉ�����
                    else
                    {
                        goodsDics[0][k].Add(temp);
                    }
                }
                //���[�J�[�R�[�h�@�{�@�����ށ@
                else if (temp.PrmGoodsMGroup != 0)
                {
                    if (!goodsDics[1].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[1].Add(k, tempGoodsList);
                    }
                    //�ʂ̋��_�̃f�[�^��ǉ�����
                    else
                    {
                        goodsDics[1][k].Add(temp);
                    }
                }
                //���[�J�[�R�[�h
                else
                {
                    if (!goodsDics[2].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[2].Add(k, tempGoodsList);
                    }
                    //�ʂ̋��_�̃f�[�^��ǉ�����
                    else
                    {
                        goodsDics[2][k].Add(temp);
                    }
                }
            }
            #endregion �D�揇�̂���āA�����擾���i�Ǘ����𕪗�����

            #region ����Dictionary���쐬����
            //�����ݒ�pDictionary��`
            Dictionary<string, ArrayList>[] pureSettingDics = new Dictionary<string, ArrayList>[3];
            for (int i = 0; i < pureSettingDics.Length; i++)
            {
                pureSettingDics[i] = new Dictionary<string, ArrayList>();
            }
            //List --> Dictionary �쐬
            ArrayList tempPureSettingList;
            foreach (Rate2SearchResult tempPureSetting in pureSettingList)
            {
                tempPureSettingList = new ArrayList();
                string k0 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + tempPureSetting.PrmGoodsMGroup.ToString() + "-" + tempPureSetting.PrmTbsPartsCode.ToString();
                string k1 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + tempPureSetting.PrmGoodsMGroup.ToString() + "-" + "0";
                string k2 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + "0-0";
                //�֘A�����F���[�J�[�R�[�h�@�{�@�����ށ@+�@�a�k�R�[�h
                if (!pureSettingDics[0].ContainsKey(k0))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[0].Add(k0, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[0][k0].Add(tempPureSetting);
                }
                //�֘A�����F���[�J�[�R�[�h�@�{�@������
                if (!pureSettingDics[1].ContainsKey(k1))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[1].Add(k1, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[1][k1].Add(tempPureSetting);
                }
                //�֘A�����F���[�J�[�R�[�h
                if (!pureSettingDics[2].ContainsKey(k2))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[2].Add(k2, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[2][k2].Add(tempPureSetting);
                }
            }
            #endregion ����Dictionary���쐬����

            #region �w�ʏ�񌟍�
            // ���i�ؑցF�w�ʂ̏ꍇ�A�w�ʏ���ݒ肵�܂��B
            if (rateSearchParam.GoodsChangeMode == 1)
            {
                object partsLayerStPmWorkObj;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                PartsLayerStPmWork partsLayerStPmWork = new PartsLayerStPmWork();
                // ��ʂ̌��������F���[�J�[
                partsLayerStPmWork.PartsMakerCode = rateSearchParam.GoodsMakerCd;

                // �w�ʏ�����������
                status = this._iPartsLayerStPmDB.Search(out partsLayerStPmWorkObj, partsLayerStPmWork);

                // �w�ʌ��������̏ꍇ
                if (status == 0)
                {
                    // �w�ʏ�񃊃X�g
                    ArrayList partsLayerStPmWorkList = partsLayerStPmWorkObj as ArrayList;

                    // �w�ʏ��ݒ�
                    ArrayList tempList;
                    foreach (PartsLayerStPmWork partsLayerStPmWorkPs in partsLayerStPmWorkList)
                    {
                        // �D�ǃf�[�^�̏ꍇ�A���[�J�R�[�h>=1000
                        if (mode == 1 && partsLayerStPmWorkPs.PartsMakerCode < 1000) 
                        {
                            continue;
                        }

                        // ��ʌ��������̑w�ʂ���͂����ꍇ
                        if (rateSearchParam.GoodsRateRank.Trim() != ""
                            && rateSearchParam.GoodsRateRank.Trim() != partsLayerStPmWorkPs.PartsLayerCd.Trim())
                        {
                            continue;
                        }

                        // BLCode�Ή������w�ʃ��X�g���擾����
                        bool exit = partsLayerStPmWorkDic.TryGetValue(partsLayerStPmWorkPs.BLGoodsCode + "-" + partsLayerStPmWorkPs.PartsMakerCode, out tempList);
                        if (exit)
                        {
                            tempList.Add(partsLayerStPmWorkPs);
                        }
                        else
                        {
                            tempList = new ArrayList();
                            tempList.Add(partsLayerStPmWorkPs);
                            partsLayerStPmWorkDic.Add(partsLayerStPmWorkPs.BLGoodsCode + "-" + partsLayerStPmWorkPs.PartsMakerCode, tempList);
                        }
                    }
                }
            }
            #endregion �w�ʏ�񌟍�

            #region �����f�[�^�Ə��i�Ǘ����֘A
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>();
            for (int i = 0; i < goodsDics.Length; i++)
            {
                foreach(string goodsKey in goodsDics[i].Keys)
                {
                    #region ���_����āA���i�Ǘ���񕪗�����
                    ArrayList goodsBySectionList = goodsDics[i][goodsKey] as ArrayList;
                    Rate2SearchResultWork goodsSearchResultWork = new Rate2SearchResultWork();
                    if (goodsBySectionList.Count == 1)
                    {
                        goodsSearchResultWork = goodsBySectionList[0] as Rate2SearchResultWork;
                    }
                    else
                    {
                        foreach (Rate2SearchResultWork tempGoodsSearchResultWork in goodsBySectionList)
                        {
                            if (tempGoodsSearchResultWork.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                            {
                                goodsSearchResultWork = tempGoodsSearchResultWork;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    #endregion ���_����āA���i�Ǘ���񕪗�����

                    #region �����f�[�^�Ə��i�Ǘ����֘A
                    if (pureSettingDics[i].ContainsKey(goodsKey))
                    {
                        Rate2SearchResult tempSearchResult;
                        foreach (Rate2SearchResult pureSearchResult in pureSettingDics[i][goodsKey])
                        {
                            // �D�ǂ̏ꍇ
                            if (mode == 1)
                            {
                                if (!pureSearchResult.SectionCode.Trim().Equals("00")
                                    && pureSearchResult.SectionCode.Trim() != goodsSearchResultWork.SectionCode.Trim())
                                {
                                    break;
                                }
                            }

                            string tempKey = pureSearchResult.PrmPartsMakerCd.ToString() + "-" + pureSearchResult.PrmGoodsMGroup.ToString() + "-" + pureSearchResult.PrmTbsPartsCode.ToString();
                            tempSearchResult = new Rate2SearchResult();
                            //�a�k�R�[�h
                            tempSearchResult.PrmTbsPartsCode = pureSearchResult.PrmTbsPartsCode;
                            //�a�k�R�[�h��
                            tempSearchResult.BLGoodsHalfName = pureSearchResult.BLGoodsHalfName;
                            //���[�J�[
                            tempSearchResult.PrmPartsMakerCd = pureSearchResult.PrmPartsMakerCd;
                            //���i�|���O���[�v
                            tempSearchResult.PrmGoodsMGroup = pureSearchResult.PrmGoodsMGroup;
                            //�d����
                            tempSearchResult.GoodsSupplierCd = goodsSearchResultWork.GoodsSupplierCd;
                            //�a�k�O���[�v�R�[�h
                            tempSearchResult.BGBLGroupCode = pureSearchResult.BGBLGroupCode;
                            //���_
                            tempSearchResult.SectionCode = goodsSearchResultWork.SectionCode;
                            //���͐���t���O
                            tempSearchResult.EnFlag = "0";

                            if (!tempDic.ContainsKey(tempKey))
                            {
                                tempDic.Add(tempKey, tempSearchResult);
                            }
                        }
                    }
                   
                    #endregion �����f�[�^�Ə��i�Ǘ����֘A
                }
            }

            #endregion �����f�[�^�Ə��i�Ǘ����֘A

            #region ��ʂɓ��͏����ƈ�v�̃f�[�^�擾
            List<Rate2SearchResult> tempPureGoodsList = new List<Rate2SearchResult>();
            foreach (string tempGoodsKey in tempDic.Keys)
            {
                if (tempDic[tempGoodsKey].GoodsSupplierCd == rateSearchParam.SupplierCd
                    && ((rateSearchParam.GoodsMakerCd != 0    //��ʂɃ��[�J�[�����͂����ꍇ�ɂ́A���̓��[�J�[�ƈ�v�̎��A�ǉ�����
                    && tempDic[tempGoodsKey].PrmPartsMakerCd == rateSearchParam.GoodsMakerCd)
                    || rateSearchParam.GoodsMakerCd == 0)     //��ʂɃ��[�J�[�����͂��Ȃ��ꍇ�ɂ́A���ڒǉ�����
                    && ((rateSearchParam.GoodsRateGrpCode != 0�@//��ʂɏ��|�f�����͂����ꍇ�ɂ́A���͏��|�f�ƈ�v�̎��A�ǉ�����
                    && tempDic[tempGoodsKey].PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                    || rateSearchParam.GoodsRateGrpCode == 0))//��ʂɏ��|�f�����͂��Ȃ��ꍇ�ɂ́A���ڒǉ�����
                {
                    tempPureGoodsList.Add(tempDic[tempGoodsKey]);
                }
                else
                {
                    continue;
                }
            }
            #endregion ��ʂɓ��͏����ƈ�v�̃f�[�^�擾

            if (rateSearchParam.GoodsChangeMode == 0)
            {
                pureGoodsList = tempPureGoodsList;
            }
            //�w�ʂ̏ꍇ�ɂ͑w�ʏ���ǉ�����
            else
            {
                #region ����List�ݒ�i�����{�w�ʁj
                Rate2SearchResult tempPureSearchResult;
                //�w�ʂ̏ꍇ
                if (partsLayerStPmWorkDic.Count > 0)
                {
                    foreach (Rate2SearchResult pureSetting in tempPureGoodsList)
                    {
                        if (partsLayerStPmWorkDic.ContainsKey(pureSetting.PrmTbsPartsCode + "-" + pureSetting.PrmPartsMakerCd))
                        {
                            // ���� left join �w��(����:�w�� = 1 : n)
                            foreach (PartsLayerStPmWork partsLayerStPmWork in partsLayerStPmWorkDic[pureSetting.PrmTbsPartsCode + "-" + pureSetting.PrmPartsMakerCd])
                            {
                                tempPureSearchResult = new Rate2SearchResult();
                                // BLCode
                                tempPureSearchResult.PrmTbsPartsCode = pureSetting.PrmTbsPartsCode;
                                //BL�R�[�h��
                                tempPureSearchResult.BLGoodsHalfName = pureSetting.BLGoodsHalfName;
                                // �w��
                                tempPureSearchResult.GoodsRateRank = partsLayerStPmWork.PartsLayerCd.Trim();
                                // ���[�J�[
                                tempPureSearchResult.PrmPartsMakerCd = pureSetting.PrmPartsMakerCd;
                                //���_
                                tempPureSearchResult.SectionCode = pureSetting.SectionCode;
                                //�a�k�O���[�v�R�[�h
                                tempPureSearchResult.BGBLGroupCode = pureSetting.BGBLGroupCode;
                                //�d����
                                tempPureSearchResult.GoodsSupplierCd = pureSetting.GoodsSupplierCd;
                                //���͐���t���O
                                tempPureSearchResult.EnFlag = "0";

                                if ((rateSearchParam.GoodsRateRank.Trim() != ""
                                    && rateSearchParam.GoodsRateRank.Trim() == tempPureSearchResult.GoodsRateRank.Trim())
                                    || rateSearchParam.GoodsRateRank.Trim() == "")
                                {
                                    pureGoodsList.Add(tempPureSearchResult);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
                else
                {
                    pureGoodsList = tempPureGoodsList;
                }
                #endregion ����List�ݒ�i�����{�w��)
            }
            
        }

        /// <summary>
        /// �������i�Ɗ|���֘A
        /// </summary>
        /// <param name="pureGoodsAndRateList">�}�[�W�����������i�Ɗ|���̃f�[�^���X�g</param>
        /// <param name="pureGoodsList">�������i�f�[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="rateSearchParam">��������</param>
        /// <remarks>
        /// <br>Note       : �������i�Ɗ|���֘A�B</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void MergePureGoodsAndRate(out List<Rate2SearchResult> pureGoodsAndRateList, 
                                           List<Rate2SearchResult> pureGoodsList, 
                                           ArrayList rateList, 
                                           Rate2SearchParam rateSearchParam)
        {
            pureGoodsAndRateList = new List<Rate2SearchResult>();

            // ���_�Ⴂ�f�[�^�𕪗�����
            Dictionary<string, ArrayList> rateDic;
            GetRateBySection(out rateDic, rateList);
            
            
            // �ŏ����b�g�����܂ގ�KeyList���擾����
            List<string> lotCountKeyList;
            GetRateByLotCount(out lotCountKeyList, rateList);
            
            #region �������iList�̃f�[�^�Ɗ|���}�X�^�̃f�[�^�֘A�@�֘A�̏������i���Ȃ��|���f�[�^���߂�List�ɒǉ����܂�
            foreach (string rateDickey in rateDic.Keys)
            {
                // ��ŏ����b�g���̃f�[�^���擾���Ȃ�
                if (!lotCountKeyList.Contains(rateDickey))
                {
                    continue;
                }
                Rate2SearchResult tempSearchResult = null;
                Rate2Work rateResultWork = new Rate2Work();

                #region ���_�̂���āA���i�Ǘ���񕪗�����
                ArrayList rateBySectionList = rateDic[rateDickey] as ArrayList;
                // ���_�������ꍇ
                if (rateBySectionList.Count == 1)
                {
                    rateResultWork = rateBySectionList[0] as Rate2Work;
                }
                // �����̋��_������ꍇ
                else
                {
                    foreach (Rate2Work tempRate2Work in rateBySectionList)
                    {
                        // ��ʓ��͋��_�Ɠ����f�[�^��I������
                        if (tempRate2Work.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                        {
                            rateResultWork = tempRate2Work;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                #endregion ���_�̂���āA���i�Ǘ���񕪗�����
                #region �������iList�̃f�[�^�Ɗ|���}�X�^�̃f�[�^�֘A
                foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
                {
                    // �q�i�q�̏ꍇ�ɂ͊|���}�X�^�̏��i�|���O���[�v���u0�v��ݒ肷��j
                    if (rateResultWork.BLGoodsCode != 0)
                    {
                        if ( (rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.BLGroupCode == 0)
                            && (rateResultWork.BLGoodsCode == pureGoodsSearchResult.PrmTbsPartsCode))
                        {
                            //���i�|���O���[�v�̏ꍇ
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                //���i�|���O���[�v�Ƒw�ʂ̒l���Ȃ�
                                if ((rateResultWork.GoodsRateGrpCode == 0) && (string.IsNullOrEmpty(rateResultWork.GoodsRateRank.Trim())))
                                {
                                    #region Data Set   
                                    tempSearchResult = new Rate2SearchResult();
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                    tempSearchResult.PrmTbsPartsCode = pureGoodsSearchResult.PrmTbsPartsCode;
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                    tempSearchResult.BLGoodsHalfName = pureGoodsSearchResult.BLGoodsHalfName;
                                    //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //���i�Ǘ����}�X�^�ɏ��i�|���O���[�v
                                    tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                    //���i�Ǘ����}�X�^�Ɏd����
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                    tempSearchResult.EnFlag = "0";
                                    //�|���}�X�^����擾����f�[�^���R�s�[
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateGrpCode != 0 
                                        && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                        ||(rateSearchParam.GoodsRateGrpCode == 0))
                                    {
                                            pureGoodsAndRateList.Add(tempSearchResult);
                                            break;
                                    }
                                    #endregion Data Set
                                }
                            }
                            //�w�ʂ̏ꍇ
                            else 
                            {
                                if ((rateResultWork.GoodsRateRank.Trim() != ""
                                      && pureGoodsSearchResult.GoodsRateRank.Trim() == rateResultWork.GoodsRateRank.Trim())
                                      && (rateResultWork.GoodsRateGrpCode == 0))
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                    tempSearchResult.PrmTbsPartsCode = pureGoodsSearchResult.PrmTbsPartsCode;
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                    tempSearchResult.BLGoodsHalfName = pureGoodsSearchResult.BLGoodsHalfName;
                                    //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //���i�Ǘ����}�X�^�ɏ��i�|���O���[�v
                                    tempSearchResult.PrmGoodsMGroup = 0;
                                    //�w��
                                    tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                    //���i�Ǘ����}�X�^�Ɏd����
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode; ;
                                    //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                    tempSearchResult.EnFlag = "0";
                                    //�|���}�X�^����擾����f�[�^���R�s�[
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateRank.Trim() != ""
                                        && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                        || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                                
                            }
                        }
                    }
                    // �q�e�i�q�e�̏ꍇ�ɂ͂a�k�R�[�g���u�O�v��ݒ肷��j
                    else if (rateResultWork.BLGroupCode != 0)
                    {
                        if (((rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.BLGoodsCode == 0)
                            && (rateResultWork.BLGroupCode == pureGoodsSearchResult.BGBLGroupCode)))
                        {
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                if ((rateResultWork.GoodsRateGrpCode == 0) && (string.IsNullOrEmpty(rateResultWork.GoodsRateRank.Trim()))) //wujun todo
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                    tempSearchResult.PrmTbsPartsCode = 0;
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                    tempSearchResult.BLGoodsHalfName = "";
                                    //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //���i�Ǘ����}�X�^�ɏ��i�|���O���[�v
                                    tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                    //���i�Ǘ����}�X�^�Ɏd����
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                    tempSearchResult.EnFlag = "0";
                                    //�|���}�X�^����擾����f�[�^���R�s�[
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateGrpCode != 0 
                                        && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                        || (rateSearchParam.GoodsRateGrpCode == 0))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                            }
                            else
                            {
                                if ((rateResultWork.GoodsRateRank.Trim() != ""
                                    && pureGoodsSearchResult.GoodsRateRank.Trim() == rateResultWork.GoodsRateRank.Trim()) 
                                    && (rateResultWork.GoodsRateGrpCode == 0)) 
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                    tempSearchResult.PrmTbsPartsCode = 0;
                                    //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                    tempSearchResult.BLGoodsHalfName = "";
                                    //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //�w��
                                    tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                    //���i�Ǘ����}�X�^�Ɏd����
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                    tempSearchResult.EnFlag = "0";
                                    //�|���}�X�^����擾����f�[�^���R�s�[
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                                        && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                        || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                            }
                        }
                    }
                    // �e�i�e�̏ꍇ�ɂ͂a�k�R�[�g�Ƃa�k�O���[�v�R�[�h���u�O�v��ݒ肷��j
                    else
                    {
                        if (rateSearchParam.GoodsChangeMode == 0)
                        {
                            if ( (rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.GoodsRateGrpCode == pureGoodsSearchResult.PrmGoodsMGroup)
                            && rateResultWork.GoodsRateGrpCode != 0
                            && rateResultWork.GoodsRateRank.Trim() == ""
                            && (rateResultWork.BLGoodsCode == 0) 
                            && (rateResultWork.BLGroupCode == 0) )
                            {
                                #region Data Set
                                tempSearchResult = new Rate2SearchResult();
                                //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                tempSearchResult.PrmTbsPartsCode = 0;
                                //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                tempSearchResult.BLGoodsHalfName = "";
                                //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                //���i�Ǘ����}�X�^�ɏ��i�|���O���[�v
                                tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                //���i�Ǘ����}�X�^�Ɏd����
                                tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                tempSearchResult.BGBLGroupCode = 0;
                                //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                tempSearchResult.EnFlag = "0";
                                //�|���}�X�^����擾����f�[�^���R�s�[
                                CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                if ((rateSearchParam.GoodsRateGrpCode != 0 
                                    && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                    || (rateSearchParam.GoodsRateGrpCode == 0))
                                {
                                    pureGoodsAndRateList.Add(tempSearchResult);
                                    break;
                                }
                                #endregion Data Set
                            }
                        }
                        else
                        {
                            if ((rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.GoodsRateRank.Trim() == pureGoodsSearchResult.GoodsRateRank.Trim())
                            && rateResultWork.BLGoodsCode == 0
                            && rateResultWork.BLGroupCode == 0
                            && rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                #region Data Set
                                tempSearchResult = new Rate2SearchResult();
                                //���i�Ǘ����}�X�^�ɂa�k�R�[�h
                                tempSearchResult.PrmTbsPartsCode = 0;
                                //���i�Ǘ����}�X�^�ɂa�k�R�[�h��
                                tempSearchResult.BLGoodsHalfName = "";
                                //���i�Ǘ����}�X�^�Ƀ��[�J�[
                                tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                //�w��
                                tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                //���i�Ǘ����}�X�^�Ɏd����
                                tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                //���i�Ǘ����}�X�^�ɂa�k�O���[�v
                                tempSearchResult.BGBLGroupCode = 0;
                                //��ʓ��͐���t���O�@0:���͉@1:���͕s��
                                tempSearchResult.EnFlag = "0";
                                //�|���}�X�^����擾����f�[�^���R�s�[
                                CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                                     && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                     || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                {
                                    pureGoodsAndRateList.Add(tempSearchResult);
                                    break;
                                }
                                #endregion Data Set
                            }
                        }
                    }
                }// end of foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
                #endregion�@�������iList�̃f�[�^�Ɗ|���}�X�^�̃f�[�^�֘A�@

                #region �������iList�ɂ��Ȃ��A�|���}�X�^�ɂ�����f�[�^�̒ǉ�
                if (tempSearchResult == null)
                {
                    tempSearchResult = new Rate2SearchResult();
                    tempSearchResult.PrmTbsPartsCode = rateResultWork.BLGoodsCode;
                    //�w�ʂ��Ȃ���΁A���̃f�[�^���ǉ����Ȃ�
                    if (rateSearchParam.GoodsChangeMode == 1 &&�@rateResultWork.GoodsRateRank.Trim() == "")
                    {
                        continue;
                    }
                    //�q
                    if (rateResultWork.BLGoodsCode != 0)
                    {
                        if (this.BLCodeDic.ContainsKey(rateResultWork.BLGoodsCode))
                        {
                            tempSearchResult.BLGoodsHalfName = this.BLCodeDic[rateResultWork.BLGoodsCode].BLGoodsHalfName;
                            //�|���}�X�^�Ɏq�f�[�^�̂a�k�O���[�v���Ȃ��ꍇ�A�߂��\���p�a�k�O���[�v�R�[�h���a�k�R�[�h�}�X�^�Ɏ擾����
                            if (rateResultWork.BLGroupCode == 0)
                            {
                                tempSearchResult.BGBLGroupCode = this.BLCodeDic[rateResultWork.BLGoodsCode].BLGloupCode;
                            }
                            else
                            {
                                tempSearchResult.BGBLGroupCode = rateResultWork.BLGroupCode;
                            }
                            //���i�|���O���[�v�̏ꍇ
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                if (rateResultWork.GoodsRateGrpCode == 0 && rateResultWork.GoodsRateRank.Trim() == "")
                                {
                                    //�a�k�R�[�h�}�X�^���珤�i�|���O���[�v���擾����
                                    tempSearchResult.PrmGoodsMGroup = this.BLCodeDic[rateResultWork.BLGoodsCode].GoodsRateGrpCode;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            //�w�ʂ̏ꍇ
                            else
                            {
                                if (rateResultWork.GoodsRateRank.Trim() != "")
                                {
                                    tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    //�q�e
                    else if (rateResultWork.BLGroupCode != 0)
                    {
                        tempSearchResult.BGBLGroupCode = rateResultWork.BLGroupCode;
                        if (rateSearchParam.GoodsChangeMode == 0)
                        {
                            if (rateResultWork.GoodsRateGrpCode == 0 && rateResultWork.GoodsRateRank.Trim() == "")
                            {
                                if (this.BLGroupCodeDic.ContainsKey(rateResultWork.BLGroupCode))
                                {
                                    // �a�k�O���[�v�}�X�^����A���i�|���O���[�v���擾����
                                    tempSearchResult.PrmGoodsMGroup = this.BLGroupCodeDic[rateResultWork.BLGroupCode].GoodsMGroup; 
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim(); 
                            }
                        }
                    }
                     //�e�i�e�̃f�[�^�̏��i�|���O���[�v���u�O�v��ݒ�ł��Ȃ��j
                    else
                    {
                        tempSearchResult.BGBLGroupCode = 0;
                        if(rateSearchParam.GoodsChangeMode == 0)
                        {
                            if (rateResultWork.GoodsRateGrpCode != 0 && rateResultWork.GoodsRateRank.Trim() == "")
                            {
                                tempSearchResult.PrmGoodsMGroup = rateResultWork.GoodsRateGrpCode;
                            }
                            //���i�|���O���[�v���u�O�v�̃f�[�^���g�p���Ȃ�
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim();
                            }
                            else
                            {
                                continue;
                            }

                        }
                        
                    }
                    tempSearchResult.PrmPartsMakerCd = rateResultWork.GoodsMakerCd;
                    tempSearchResult.GoodsSupplierCd = rateResultWork.SupplierCd;
                    tempSearchResult.EnFlag = "0";
                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);
                    //���i�|���O���[�v�̏ꍇ
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        //��ʂ̓��͏����ƈ�v�̃f�[�^���g�p���܂�
                        if ((rateSearchParam.GoodsRateGrpCode != 0 
                              && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                              || (rateSearchParam.GoodsRateGrpCode == 0))
                        {
                            pureGoodsAndRateList.Add(tempSearchResult);
                        }
                    }
                    //�w�ʂ̏ꍇ
                    else
                    {
                        //��ʂ̓��͏����ƈ�v�̃f�[�^���g�p���܂�
                        if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                              && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                           ||(string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                        {
                            pureGoodsAndRateList.Add(tempSearchResult);
                        }
                    }

                }
                #endregion �������iList�ɂ��Ȃ��A�|���}�X�^�ɂ�����f�[�^�̒ǉ�

            }// end of foreach (Rate2Work rateResultWork in rateList)
            #endregion�@�������iList�̃f�[�^�Ɗ|���}�X�^�̃f�[�^�֘A�@�֘A�̏������i���Ȃ��|���f�[�^���߂�List�ɒǉ����܂�

            #region �������iList�ɂ������āA�|���}�X�^�ɂ��Ȃ��f�[�^�̒ǉ�
            foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
            {
                if (pureGoodsAndRateList.Contains(pureGoodsSearchResult))
                {
                    continue;
                }
                else
                {
                    //�w�ʂ��Ȃ���΁A���̃f�[�^���ǉ����Ȃ�
                    if (rateSearchParam.GoodsChangeMode == 1 && pureGoodsSearchResult.GoodsRateRank.Trim() == "")
                    {
                        continue;
                    }
                    else
                    {
                        if (!pureGoodsAndRateList.Exists(delegate(Rate2SearchResult target)
                        {
                            return target.PrmGoodsMGroup == pureGoodsSearchResult.PrmGoodsMGroup
                                   && target.PrmPartsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd
                                   && target.BGBLGroupCode == pureGoodsSearchResult.BGBLGroupCode
                                   && target.PrmTbsPartsCode == pureGoodsSearchResult.PrmTbsPartsCode
                                   && target.GoodsRateRank == pureGoodsSearchResult.GoodsRateRank
                                   && (target.RateVal != 0 || target.UpRate != 0 || target.GrsProfitSecureRate != 0);
                        }))
                        {
                            pureGoodsAndRateList.Add(pureGoodsSearchResult);
                        }
                    }
                }
            }
            #endregion�@�������iList�ɂ������āA�|���}�X�^�ɂ��Ȃ��f�[�^�̒ǉ�
        }

        #region �|���}�X�^�擾�f�[�^���|���}�X�^�e�u�[���̎�Key�̂���āADictionary���쐬����
        /// <summary>
        /// ���_�Ⴂ�f�[�^�𕪗�����
        /// </summary>
        /// <param name="rateDic"></param>
        /// <param name="rateList">�|�����X�g</param>
        /// <remarks>
        /// <br>Note       : ���_�Ⴂ�f�[�^�𕪗�����B</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void GetRateBySection(out Dictionary<string, ArrayList> rateDic, ArrayList rateList)
        {
            rateDic = new Dictionary<string, ArrayList>();
            string key = string.Empty;
            ArrayList tempRateList = new ArrayList();
            foreach (Rate2Work rate2Work in rateList)
            {
                // �q�N���X�g�p�ȊO�̎�Key�F�P���ݒ�敪�A�w�ʁA���i�|���O���[�v�A�a�k�O���[�v�R�[�h�A�a�k�R�[�h�A
                // ���Ӑ�R�[�h�A���Ӑ�|���O���[�v�R�[�h�ƃ��b�g���i���_���܂܂Ȃ��j
                key = rate2Work.GoodsMakerCd.ToString() + "-" + rate2Work.UnitRateSetDivCd.Trim()
                      + "-"+ rate2Work.GoodsRateRank.Trim() + "-" + rate2Work.GoodsRateGrpCode.ToString()
                      + "-" + rate2Work.BLGroupCode.ToString() + "-" + rate2Work.BLGoodsCode.ToString() 
                      + rate2Work.CustomerCode.ToString() + "-" + rate2Work.CustRateGrpCode.ToString() 
                      + "-" + rate2Work.LotCount.ToString();
                if (!rateDic.ContainsKey(key))
                {
                    tempRateList.Add(rate2Work);
                    rateDic.Add(key, tempRateList);
                }
                //�ʂ̋��_�̃f�[�^��ǉ�����
                else
                {
                    rateDic[key].Add(rate2Work);
                }
                tempRateList = new ArrayList();
            }
        }
        #endregion �|���}�X�^�擾�f�[�^���|���}�X�^�e�u�[���̎�Key�̂���āADictionary���쐬����

        #region  �|���}�X�^�擾�f�[�^�̒��ɁA�ŏ��̃��b�g���f�[�^���擾
        /// <summary>
        /// �|���}�X�^�擾�f�[�^�̒��ɁA�ŏ��̃��b�g���f�[�^�̎擾
        /// </summary>
        /// <param name="lotCountKeyList"></param>
        /// <param name="rateList">�|�����X�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�擾�f�[�^�̒��ɁA�ŏ��̃��b�g���f�[�^�̎擾</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void GetRateByLotCount(out List<string> lotCountKeyList, ArrayList rateList)
        {
            lotCountKeyList = new List<string>();
            // ���v���b�g���pDictionary
            Dictionary<string, ArrayList> rateLotCountDic = new Dictionary<string, ArrayList>();

            foreach (Rate2Work rate2Work in rateList)
            {
                // ���b�g�����܂܂Ȃ�key���쐬����
                string lotCountKey = rate2Work.GoodsMakerCd.ToString() + "-" + rate2Work.UnitRateSetDivCd.Trim() 
                                     + "-" + rate2Work.GoodsRateRank.Trim() + "-" + rate2Work.GoodsRateGrpCode.ToString()
                                     + "-" + rate2Work.BLGroupCode.ToString() + "-" + rate2Work.BLGoodsCode.ToString() 
                                     + rate2Work.CustomerCode.ToString()
                                     + "-" + rate2Work.CustRateGrpCode.ToString();
                ArrayList tempLotCountList = new ArrayList();
                // ���v���b�g���pDictionary���쐬����
                if (!rateLotCountDic.ContainsKey(lotCountKey))
                {
                    tempLotCountList.Add(rate2Work.LotCount);
                    rateLotCountDic.Add(lotCountKey, tempLotCountList);
                }
                else
                {
                    rateLotCountDic[lotCountKey].Add(rate2Work.LotCount);
                }
            }
            // �ŏ����b�g�����܂ގ�KeyList���쐬����
            foreach (string rateLotCountDickey in rateLotCountDic.Keys)
            {
                rateLotCountDic[rateLotCountDickey].Sort();
                lotCountKeyList.Add(rateLotCountDickey + "-" + rateLotCountDic[rateLotCountDickey][0].ToString());
            }
        }
        #endregion�@�|���}�X�^�擾�f�[�^�̒��ɁA�ŏ��̃��b�g���f�[�^���擾

        /// <summary>
        /// �e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
        /// </summary>
        /// <param name="retWorkList">�����������X�g</param>
        /// <param name="rateSearchParam">��������</param>
        /// <returns></returns>
        /// <br>Note       : �e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ������B</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/02/26</br>
        private void SetParentData(ref List<Rate2SearchResult> retWorkList, Rate2SearchParam rateSearchParam)
        {
            List<Rate2SearchResult> parentList = new List<Rate2SearchResult>();
            Dictionary<string, Rate2SearchResult> pareDic = new Dictionary<string, Rate2SearchResult>();
            Rate2SearchResult tempParentWork = null;
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                string key = string.Empty;
                //string parentKey = string.Empty;
                string key1 = string.Empty;

                tempParentWork = new Rate2SearchResult();
                //�����擾�̐e�f�[�^
                if (tempWork.BGBLGroupCode == 0 && tempWork.PrmTbsPartsCode == 0)
                {
                    // ���i�|���f
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        key1 = tempWork.PrmGoodsMGroup.ToString();
                        tempParentWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                    }
                    // �w��
                    else
                    {
                        key1 = tempWork.GoodsRateRank.Trim();
                        tempParentWork.GoodsRateRank = key1;
                    }
                    key =tempWork.PrmPartsMakerCd.ToString() + ":" + key1 + ":" + tempWork.BGBLGroupCode.ToString() + ":" + tempWork.PrmTbsPartsCode.ToString();
                    if (!pareDic.ContainsKey(key))
                    {
                        pareDic.Add(key, tempWork);
                    }
                }
                //���f�[�^�ɐe�f�[�^�̐ݒ�
                else
                {
                    // ���i�|���f
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        if (tempWork.PrmGoodsMGroup != 0)
                        {
                            tempParentWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        }
                        else if (tempWork.PrmTbsPartsCode != 0)
                        {
                            if (this.BLCodeDic.ContainsKey(tempWork.PrmTbsPartsCode))
                            {
                                tempParentWork.PrmGoodsMGroup = this.BLCodeDic[tempWork.PrmTbsPartsCode].GoodsRateGrpCode;
                            }
                        }
                        else if (tempWork.BGBLGroupCode != 0)
                        {
                            if (this.BLGroupCodeDic.ContainsKey(tempWork.BGBLGroupCode))
                            {
                                tempParentWork.PrmGoodsMGroup = this.BLGroupCodeDic[tempWork.BGBLGroupCode].GoodsMGroup;
                            }
                        }
                    }
                    // �w��
                    else
                    {
                        tempParentWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                    }
                }
                tempParentWork.BGBLGroupCode = 0;
                tempParentWork.PrmTbsPartsCode = 0;
                tempParentWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                tempParentWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                tempParentWork.EnFlag = "0";
                parentList.Add(tempParentWork);
            }
            foreach (Rate2SearchResult tempWork in parentList)
            {
                string key = string.Empty;
                // ���i�|���f
                if (rateSearchParam.GoodsChangeMode == 0)
                {
                    key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.PrmGoodsMGroup.ToString();
                }
                // �w��
                else
                {
                    key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.GoodsRateRank.Trim();
                }
                if (!pareDic.ContainsKey(key + ":0:0"))
                {
                    pareDic.Add(key + ":0:0", tempWork);
                    retWorkList.Add(tempWork);
                }
            }
            // �w�ʌ����̏ꍇ
            if (!string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim()))
            {
                List<Rate2SearchResult> retTempWorkList = new List<Rate2SearchResult>();
                foreach (Rate2SearchResult tempResultWork in retWorkList)
                {
                    if (!String.IsNullOrEmpty(tempResultWork.GoodsRateRank.Trim()))
                    {
                        retTempWorkList.Add(tempResultWork);
                    }
                }
                retWorkList = retTempWorkList;
            }
        }

        /// <summary>
        /// �q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
        /// </summary>
        /// <param name="retWorkList">�����������X�g</param>
        /// <param name="rateSearchParam">��������</param>
        /// <br>Note       : �q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ������B</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/03/04</br>
        private void SetGroupParaentDataByRank(ref List<Rate2SearchResult> retWorkList)
        {
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                String key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.GoodsRateRank.Trim() + ":" + tempWork.BGBLGroupCode + ":" + tempWork.PrmTbsPartsCode;
                if (!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, tempWork);
                }
            }

            List<Rate2SearchResult> tempGroupParentList = new List<Rate2SearchResult>();
            foreach (string tempKey in tempDic.Keys)
            {
                Rate2SearchResult tempWork = tempDic[tempKey];

                Rate2SearchResult retWork = null;
                retWork = retWorkList.Find(
                        delegate(Rate2SearchResult work)
                        {
                            if ((work.GoodsRateRank.Trim() == tempWork.GoodsRateRank.Trim()) &&
                                (work.PrmTbsPartsCode == 0) &&
                                (work.BGBLGroupCode == tempWork.BGBLGroupCode)
                                && (work.PrmPartsMakerCd == tempWork.PrmPartsMakerCd))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                if (retWork == null)
                {
                    bool hasInsertGroupParent = false;
                    for (int i = 0; i < tempGroupParentList.Count; i++)
                    {
                        if ((tempGroupParentList[i].GoodsRateRank.Trim() == tempWork.GoodsRateRank.Trim())
                            && (tempGroupParentList[i].BGBLGroupCode == tempWork.BGBLGroupCode)
                            && (tempGroupParentList[i].PrmPartsMakerCd == tempWork.PrmPartsMakerCd)
                            && (tempGroupParentList[i].GoodsSupplierCd == tempWork.GoodsSupplierCd))
                        {
                            hasInsertGroupParent = true;
                            break;
                        }
                    }

                    if (hasInsertGroupParent == false)
                    {
                        retWork = new Rate2SearchResult();

                        retWork.BGBLGroupCode = tempWork.BGBLGroupCode;

                        retWork.EnterpriseCode = tempWork.EnterpriseCode;
                        retWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                        //retWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        retWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                        retWork.PrmTbsPartsCode = 0;
                        retWork.SectionCode = tempWork.SectionCode;
                        retWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                        retWork.EnFlag = "0";

                        tempGroupParentList.Add(retWork);
                    }
                }

            }

            if (null != tempGroupParentList && tempGroupParentList.Count > 0)
            {
                retWorkList.AddRange(tempGroupParentList.ToArray());
            }

        }

        /// <summary>
        /// �q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ�����
        /// </summary>
        /// <param name="retWorkList">�����������X�g</param>
        /// <param name="rateSearchParam">��������</param>
        /// <br>Note       : �q�e�f�[�^���Ȃ��ꍇ�ɐe�f�[�^�̒ǉ������B</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/03/04</br>
        private void SetGroupParentData(ref List<Rate2SearchResult> retWorkList)
        {
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>(); 
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                String key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.BGBLGroupCode + ":" + tempWork.PrmTbsPartsCode;
                if(!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, tempWork);
                }
            }

            List<Rate2SearchResult> tempGroupParentList = new List<Rate2SearchResult>();
            foreach (string tempKey in tempDic.Keys)
            {
                Rate2SearchResult tempWork = tempDic[tempKey];

                Rate2SearchResult retWork = null;
                retWork = retWorkList.Find(
                        delegate(Rate2SearchResult work)
                        {
                            if ((work.PrmTbsPartsCode == 0) &&
                                (work.BGBLGroupCode == tempWork.BGBLGroupCode)
                                && (work.PrmGoodsMGroup == tempWork.PrmGoodsMGroup)
                                && (work.PrmPartsMakerCd == tempWork.PrmPartsMakerCd))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                if (retWork == null)
                {
                    bool hasInsertGroupParent = false;
                    for (int i = 0; i < tempGroupParentList.Count; i++)
                    {
                        if((tempGroupParentList[i].BGBLGroupCode == tempWork.BGBLGroupCode)
                            && (tempGroupParentList[i].PrmPartsMakerCd == tempWork.PrmPartsMakerCd)
                            && (tempGroupParentList[i].PrmGoodsMGroup == tempWork.PrmGoodsMGroup)
                            && (tempGroupParentList[i].GoodsSupplierCd == tempWork.GoodsSupplierCd))
                        {
                            hasInsertGroupParent = true;
                            break;
                        }
                    }

                    if(hasInsertGroupParent == false)
                    {
                        retWork = new Rate2SearchResult();

                        retWork.BGBLGroupCode = tempWork.BGBLGroupCode;

                        retWork.EnterpriseCode = tempWork.EnterpriseCode;
                        retWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                        retWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        retWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                        retWork.PrmTbsPartsCode = 0;
                        retWork.SectionCode = tempWork.SectionCode;
                        retWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                        retWork.EnFlag = "0";
                        
                        tempGroupParentList.Add(retWork);
                    }
                }

            }

            if (null != tempGroupParentList && tempGroupParentList.Count > 0)
            {
                retWorkList.AddRange(tempGroupParentList.ToArray());
            }
        }
        #endregion

        /// <summary>
        /// Rate2Work --> Rate2SearchResult
        /// </summary>
        /// <param name="rate2SearchResult"></param>
        /// <param name="rateWork"></param>
        /// <br>Note       : Rate2Work --> Rate2SearchResult</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/04</br>
        private void CopyRateWorkToRate2SearchResult(ref Rate2SearchResult rate2SearchResult, Rate2Work rateWork )
        {
            rate2SearchResult.BLGoodsCode = rateWork.BLGoodsCode;
            rate2SearchResult.BLGroupCode = rateWork.BLGroupCode;
            rate2SearchResult.CreateDateTime = rateWork.CreateDateTime;
            rate2SearchResult.CustomerCode = rateWork.CustomerCode;
            rate2SearchResult.CustRateGrpCode = rateWork.CustRateGrpCode;
            rate2SearchResult.EnterpriseCode = rateWork.EnterpriseCode;
            rate2SearchResult.FileHeaderGuid = rateWork.FileHeaderGuid;
            rate2SearchResult.GoodsNo = rateWork.GoodsNo;
            rate2SearchResult.GrsProfitSecureRate = rateWork.GrsProfitSecureRate;
            rate2SearchResult.LogicalDeleteCode = rateWork.LogicalDeleteCode;
            rate2SearchResult.LotCount = rateWork.LotCount;
            rate2SearchResult.PriceFl = rateWork.PriceFl;
            rate2SearchResult.GoodsRateGrpCode = rateWork.GoodsRateGrpCode;
            rate2SearchResult.GoodsMakerCd = rateWork.GoodsMakerCd;
            rate2SearchResult.RateMngCustCd = rateWork.RateMngCustCd;
            rate2SearchResult.RateMngCustNm = rateWork.RateMngCustNm;
            rate2SearchResult.RateMngGoodsCd = rateWork.RateMngGoodsCd;
            rate2SearchResult.RateMngGoodsNm = rateWork.RateMngGoodsNm;
            rate2SearchResult.RateSettingDivide = rateWork.RateSettingDivide;
            rate2SearchResult.RateVal = rateWork.RateVal;
            rate2SearchResult.SectionCode = rateWork.SectionCode;
            rate2SearchResult.SupplierCd = rateWork.SupplierCd;
            rate2SearchResult.UnitPriceKind = rateWork.UnitPriceKind;
            rate2SearchResult.UnitRateSetDivCd = rateWork.UnitRateSetDivCd;
            rate2SearchResult.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv;
            rate2SearchResult.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit;
            rate2SearchResult.UpdAssemblyId1 = rateWork.UpdAssemblyId1;
            rate2SearchResult.UpdAssemblyId2 = rateWork.UpdAssemblyId2;
            rate2SearchResult.UpdateDateTime = rateWork.UpdateDateTime;
            rate2SearchResult.UpdEmployeeCode = rateWork.UpdEmployeeCode;
            rate2SearchResult.UpRate = rateWork.UpRate;
        }
        #endregion �� Private Methods

    }

    #region �� Internal Class
    /// <summary>
    /// �|���}�X�^�������ʃf�[�^�\�[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�������ʃf�[�^�\�[�g�N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class Rate2SchRstSort : IComparer<Rate2SearchResult>
    {
        // ���i�ؑփ��[�h
        private int _goodsChangeMode = 0;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="goodsChangeMode">���i�ؑփ��[�h</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public Rate2SchRstSort(int goodsChangeMode)
        {
            this._goodsChangeMode = goodsChangeMode;
        }

        /// <summary>
        /// �|���}�X�^�������ʃf�[�^�̔�r����
        /// </summary>
        /// <param name="x">�|���}�X�^�������ʃf�[�^</param>
        /// <param name="y">�|���}�X�^�������ʃf�[�^</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�������ʃf�[�^�̔�r�������s��</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Compare(Rate2SearchResult x, Rate2SearchResult y)
        {
            // ��r����
            int compareRst = 0;

            // ���|�̏ꍇ
            if (this._goodsChangeMode == 0)
                // ���i�����ރR�[�h�̔�r
                compareRst = x.PrmGoodsMGroup.CompareTo(y.PrmGoodsMGroup);
            // �w�ʂ̏ꍇ
            else
            {
                // ���i�|�������N�̔�r
                int index = 0;
                compareRst = this.CompareStr(x.GoodsRateRank.Trim(), y.GoodsRateRank.Trim(), ref index);
            }
            if (compareRst != 0) return compareRst;

            // ���[�J�[�̔�r
            compareRst = x.PrmPartsMakerCd.CompareTo(y.PrmPartsMakerCd);
            if (compareRst != 0) return compareRst;

            // �O���[�v�R�[�h�̔�r
            compareRst = x.BGBLGroupCode.CompareTo(y.BGBLGroupCode);
            if (compareRst != 0) return compareRst;

            // BL�R�[�h�̔�r
            return x.PrmTbsPartsCode.CompareTo(y.PrmTbsPartsCode);
        }

        /// <summary>
        /// ������̔�r(�\�[�g���͐������A���t�@�x�b�g������)
        /// </summary>
        /// <param name="strA">������A</param>
        /// <param name="strB">������B</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : �͐������A���t�@�x�b�g������ŕ�����̔�r�������s��</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private int CompareStr(string strA, string strB, ref int index)
        {
            if (index == strA.Length || index == strB.Length)
            {
                if (strA.Length > strB.Length)
                    return 1;
                else if (strA.Length == strB.Length)
                    return 0;
                else
                    return -1;
            }

            Int16 shortA = (Int16)strA.Substring(index, 1).ToCharArray()[0];
            Int16 shortB = (Int16)strB.Substring(index, 1).ToCharArray()[0];

            // �����̏ꍇ�A���̕������r����
            if (shortA == shortB)
            {
                index++;
                return CompareStr(strA, strB, ref index);
            }

            // �啶���̏ꍇ
            if (shortA >= 65 && shortA <= 90)
                shortA += (Int16)100;
            if (shortB >= 65 && shortB <= 90)
                shortB += (Int16)100;

            if (shortA > shortB)
                return 1;
            else
                return -1;
        }
    }
    #endregion �� Internal Class
}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i�}�X�^�X�V�����A�N�Z�X�N���X
//                  :   PMKHN09672A.DLL
// Name Space       :   Broadleaf.Application.Controller
// Programmer       :   ����g
// Date             :   2011/07/22
// Update Note      :   �A��1029  �V�K
//----------------------------------------------------------------------
// Update Note      :   �@�\�ǉ��F���O�o��
// Programmer       :   ���J
// Date             :   2011/08/22
// Update Note      :   �A��1029  �V�K
//----------------------------------------------------------------------
// Update Note      :   ��Q�� #25232�@�D ���̍X�V���C��
// Programmer       :   ����3�@
// Date             :   2011/09/16
//----------------------------------------------------------------------
// Update Note      :   ���i�X�V�敪�ǉ��̑Ή�
// Programmer       :   yangmj
// Date             :   2012/06/12
//----------------------------------------------------------------------
// Update Note      :   ���i�}�X�^�X�V�����ŃZ���N�g�R�[�h�𖳎����čX�V�����s��̑Ή�
//                  :   ���i�}�X�^�X�V�����ȊO��PG�ł���肪�������Ă��邪�A���}���A���i�}�X�^�X�V�����݂̂���
//                  :   �Ă΂�郁�\�b�h��V�K�쐬���đΉ��B�ʓr�P�v�Ή����s���B
// Programmer       :   22008 ���� ���n
// Date             :   2015/04/08
//----------------------------------------------------------------------
// Update Note      :   2015/04/08�C�����̎b��Ή����\�b�h�̌ďo�������폜
//                  :   �b��Ή��O�̃��\�b�h�ɖ߂�
// Programmer       :   22008 ���� ���n
// Date             :   2015/04/10
//----------------------------------------------------------------------
// Update Note      :   ���i�}�X�^�X�V(�T�|�[�g)�Ή�
// Programmer       :   杍^
// Date             :   2021/08/06
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;// ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�}�X�^�X�V�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�X�V���s���A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ����g</br>
    /// <br>Date       : 2011.07.22</br>
    /// <br>Update Note: �A��1029 �@�\�ǉ��F���O�o��</br>
    /// <br>Programmer : ���J</br>
    /// <br>Date       : 2011/08/22</br>
    /// <br>Update Note: ���i�X�V�敪�ǉ��̑Ή�</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br>Update Note: ���i�}�X�^�X�V(�T�|�[�g)�Ή�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2021/08/06</br>
    /// </remarks>
    public class GoodsUAcs
    {
        #region �� Private Member
        /// <summary>���i�}�X�^�i���[�U�[�o�^���jDB RemoteObject�C���^�[�t�F�[�X</summary>
        private IGoodsUpdateDB _iGoodsUDB = null;

        /// <summary>���i�}�X�^�i��DB���jDB RemoteObject�C���^�[�t�F�[�X</summary>
        private IOfferPartsInfo _iOfferPartsInfo;
        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- >>>>>
        /// <summary>���O�̏����ݎ�</summary>
        private OperationHistoryLog _operationHistoryLog;
        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- <<<<<

        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
        private ArrayList writePricesList = null; // ���i���X�g(�����p)
        private ArrayList deletePriceList = null; // ���i���X�g(�폜�p)
        private List<PrmSettingUWork> prmSettingUWorkList = null; // ���i���X�g(�폜�p)
        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
        // --- ADD 2021/08/06 杍^ ���i�}�X�^�X�V(�T�|�[�g)�Ή� ----->>>>>
        private const string PGID_PMKHN09679U = "PMKHN09679U";
        private const string PGID_PMKHN09670U = "PMKHN09670U";
        private const string PROGRAM_SUPPORT = "���i�}�X�^�X�V(�T�|�[�g)";
        // --- ADD 2021/08/06 杍^ ���i�}�X�^�X�V(�T�|�[�g)�Ή� -----<<<<<
        #endregion �� Private Member

        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- >>>>>
        #region  �� Constructor
        public GoodsUAcs()
        {
            if (_operationHistoryLog == null)
                _operationHistoryLog = new OperationHistoryLog();
        }
        #endregion
        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- <<<<<

        #region �� Public Method

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�X�V���s��
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="goodsUpdate">�X�V�p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏��i�}�X�^�i���[�U�[�o�^���j�X�V���s��</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: ���i�X�V�敪�ǉ��̑Ή�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: ���i�}�X�^�X�V(�T�|�[�g)�Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/06</br>
        public int Update(out int cnt, GoodsUpdate goodsUpdate)
        {
            cnt = 0;
            //�����p���i�f�[�^���X�g
            //object goodsUWorkList;// DEL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            object goodsUWorkList = new object();// ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            object objGoods;// ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            //�X�V�p���i�f�[�^���X�g
            List<GoodsUResultWork> goodsUList;

            //��������
            GoodsUpdateWork goodsUpdateWork = copyToGoodsUpdateWorkFromGoodsUpdate(goodsUpdate);
            
            this._iGoodsUDB = MediationIGoodsUpdateDB.GetIGoodsUpdateDB();

            //���[�UDB���珤�i�}�X�^�f�[�^���擾����
            //int status = this._iGoodsUDB.SearchAll(out goodsUWorkList, goodsUpdateWork, ConstantManagement.LogicalMode.GetData0); // DEL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            int status = this._iGoodsUDB.SearchAll(out objGoods, goodsUpdateWork, ConstantManagement.LogicalMode.GetData0); // ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�

            //��DB���珤�i�}�X�^�f�[�^���擾����
            //if ((status != 0) || (goodsUWorkList == null)) // DEL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            if ((status != 0) || (objGoods == null)) // ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            {
                return 4;
            }
            // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
            else
            {
                if (objGoods is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList customList = (CustomSerializeArrayList)objGoods;

                    if (customList[0] is List<GoodsUResultWork> && customList[0] != null)
                    {
                        goodsUWorkList = (List<GoodsUResultWork>)customList[0];
                    }
                    else
            {
                return 4;
            }
                    if (customList.Count > 1)
                    {
                        prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])((ArrayList)customList[1]).ToArray(typeof(PrmSettingUWork)));

                    }
                }
            }
            // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
            //SearchFromOfferDB(ref goodsUWorkList, out goodsUList); // DEL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            SearchFromOfferDB(goodsUpdate.PriceUpdateDivCd, ref goodsUWorkList, out goodsUList); // ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            if ((goodsUList != null) && (goodsUList.Count > 20000))
            {
                // --- UPD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� ----->>>>>
                //return 1;
                if (checkPgId())
                {
                    return 1;
                }
                // --- UPD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� -----<<<<<
            }
            else if ((goodsUList != null) && (goodsUList.Count == 0))
            {
                return 4;
            }

            //�񋟃f�[�^�����[�UDB�ɍX�V����
            //status = this._iGoodsUDB.Update(out cnt, (object)goodsUList, goodsUpdateWork);// EDL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
            object obj;
            ArrayList updList = new ArrayList();
            updList.Add(goodsUList);
            updList.Add(writePricesList);
            updList.Add(deletePriceList);
            obj = (object)updList;
            status = this._iGoodsUDB.Update(out cnt, (object)obj, goodsUpdateWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                cnt = cnt + writePricesList.Count + deletePriceList.Count;
            }
            // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
            return 0;

        }

        // --- ADD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� ----->>>>>
        /// <summary>
        /// PGID���f�p
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�X�V(�T�|�[�g)�Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/06</br>
        /// </remarks>
        private bool checkPgId()
        {
            bool checkFlg = true;
            try
            {
                string prePGID = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod().ReflectedType.Assembly.GetName().Name;
                switch (prePGID)
                {
                    case PGID_PMKHN09670U:
                        checkFlg = true;
                        break;
                    case PGID_PMKHN09679U:
                        checkFlg = false;
                        break;
                    default:
                        checkFlg = true;
                        break;
                }
            }
            catch
            {
                checkFlg = true;
            }
            return checkFlg;
        }
        // --- ADD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� -----<<<<<

        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- >>>>>
        /// <summary>
        /// ���O���������݂܂�
        /// </summary>
        /// <param name="processName">�e�����̖���</param>
        /// <param name="stepName">�����敪</param>
        /// <param name="data">�X�V���e</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���O���������݂܂�</br>
        /// <br>Programmer : ���J</br>
        /// <br>Date       : 2011/08/22</br>
        /// <br>UpdateNote : ���i�}�X�^�X�V(�T�|�[�g)�Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/08/06</br>
        public void Write(
            string processName,
            string stepName,
            string data
        )
        {
            const string PROGRAM_ID = "PMKHN09672A";
            const string PROGRAM_NAME = "���i�}�X�^�X�V����";
            const int OPERATION_CODE = 0;
            const int STATUS = 0;

            // --- ADD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� ----->>>>>
            string pgmNm = string.Empty;
            if (checkPgId())
            {
                pgmNm = PROGRAM_NAME;
            }
            else
            {
                pgmNm = PROGRAM_SUPPORT;
            }
            // --- ADD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� -----<<<<<
            this._operationHistoryLog.WriteOperationLog(
                this,
                DateTime.Now,
                LogDataKind.SystemLog,
                PROGRAM_ID,
                // --- UPD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� ----->>>>>
                //PROGRAM_NAME,
                pgmNm,
                // --- UPD 杍^ 2021/08/06 ���i�}�X�^�X�V(�T�|�[�g)�Ή� -----<<<<<
                processName,
                OPERATION_CODE,
                STATUS,
                stepName,
                data
            );
        }
        // --------------- ADD 2011/08/22 �@�\�ǉ��F���O�o�� -------------- <<<<<
        #endregion �� Public Method

        #region �� Private Method
        /// <summary>
        /// ���������̏���
        /// </summary>
        /// <param name="goodsUpdate">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������̏������s��</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: ���i�X�V�敪�ǉ��̑Ή�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        private GoodsUpdateWork copyToGoodsUpdateWorkFromGoodsUpdate(GoodsUpdate goodsUpdate)
        {
            GoodsUpdateWork goodsUpdateWork = new GoodsUpdateWork();

            goodsUpdateWork.EnterpriseCode = goodsUpdate.EnterpriseCode;
            goodsUpdateWork.GoodsMakerCd = goodsUpdate.GoodsMakerCd;
            goodsUpdateWork.GoodsMGroup = goodsUpdate.GoodsMGroup;
            goodsUpdateWork.BLGoodsCode = goodsUpdate.BLGoodsCode;
            goodsUpdateWork.BLCodeUpdateDivCd = goodsUpdate.BLCodeUpdateDivCd;
            goodsUpdateWork.RateRankUpdateDivCd = goodsUpdate.RateRankUpdateDivCd;
            goodsUpdateWork.GoodsNameUpdateDivCd = goodsUpdate.GoodsNameUpdateDivCd;
            goodsUpdateWork.PriceUpdateDivCd = goodsUpdate.PriceUpdateDivCd;//ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
            return goodsUpdateWork;
        }

        /// <summary>
        /// ��DB���珤�i�}�X�^�f�[�^���擾����
        /// </summary>
        /// <param name="objList">��������</param>
        /// <param name="goodsUList">�擾�f�[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��DB���珤�i�}�X�^�f�[�^���擾���邤</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: ���i�X�V�敪�ǉ��̑Ή�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        //private void SearchFromOfferDB(ref object objList, out List<GoodsUResultWork> goodsUList) // DEL yangmj 2012/06/12 ���i�X�V�敪�ǉ�
        private void SearchFromOfferDB(int priceUpdateDivCd, ref object objList, out List<GoodsUResultWork> goodsUList) // ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�
        {
            List<GoodsUResultWork> goodsUWorkList = (List<GoodsUResultWork>)objList;
            goodsUList = new List<GoodsUResultWork>();
            GoodsUResultWork goodsU;
 
            ArrayList lstSrchCond = new ArrayList();
            OfrPrtsSrchCndWork ofrPrtsSrchCndWork;
            foreach (GoodsUResultWork goodsUWork in goodsUWorkList)
            {
                ofrPrtsSrchCndWork = new OfrPrtsSrchCndWork();
                ofrPrtsSrchCndWork.MakerCode = goodsUWork.GoodsMakerCd; // ���[�J�[�R�[�h
                ofrPrtsSrchCndWork.PrtsNo = goodsUWork.GoodsNo;         // �i��
                lstSrchCond.Add(ofrPrtsSrchCndWork);
            }

            if (lstSrchCond.Count > 0)
            {
                ArrayList lstRst;
                ArrayList lstRstPrm;
                ArrayList lstPrmPrice;

                try
                {
                    this._iOfferPartsInfo = (IOfferPartsInfo)MediationOfferPartsInfo.GetOfferPartsInfo();
                    // -- UPD 2015/04/10 osanai ----------------------------------------------->>> 
                    //// -- UPD 2015/04/08 osanai ----------------------------------------------->>> 
                    //// �񋟂̃����[�g�������g�p���ď��i�}�X�^�����擾����
                    ////int satus = this._iOfferPartsInfo.GetOfrPartsInf(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);

                    //// �b��Ή��Ƃ��āA���i�}�X�^�X�V�����p�ɒǉ��������\�b�h���Ăяo���B
                    //// �i�������\�b�h���C�������ꍇ�ɁA�e���͈͂��L�����߁A�ʓr�P�v�Ή���Ɋ������\�b�h�ɖ߂��j
                    //int satus = this._iOfferPartsInfo.GetOfrPartsInfGoodsUpdateOnly(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                    //// -- UPD 2015/04/08 osanai -----------------------------------------------<<< 

                    // ��R���ōP�v�Ή����s�����߁A�b��Ή��O�̃��\�b�h�ɖ߂�
                    int satus = this._iOfferPartsInfo.GetOfrPartsInf(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                    // -- UPD 2015/04/10 osanai -----------------------------------------------<<< 

                    // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
                    PriceChgSet priceChkSet = new PriceChgSet();
                    int priceMngCnt = -1;
                    if (priceUpdateDivCd == 1)
                    {
                    // ���i�Ǘ������̎擾
                    PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();
                    priceChgSetAcs.Read(out priceChkSet, goodsUWorkList[0].EnterpriseCode, PriceChgSetAcs.SearchMode.Remote);
                        priceMngCnt = priceChkSet.PriceMngCnt;
                    }
                    // �����ŉ��i��������
                    List<GoodsPriceUWork> addList;//���i�V�K�ǉ��f�[�^���X�g
                    List<GoodsPriceUWork> deleteList;//���i�폜�f�[�^���X�g

                    writePricesList = new ArrayList();
                    deletePriceList = new ArrayList();
                    // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
                   
                    int goodsMakeCd;
                    string goodsNo;
                    foreach (GoodsUResultWork goodsUWork in goodsUWorkList)
                    {
                        goodsMakeCd = goodsUWork.GoodsMakerCd;
                        goodsNo = goodsUWork.GoodsNo;

                        foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                        {
                            if (offerJoinPartsRetWork.JoinDestMakerCd == goodsMakeCd
                                && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo)
                            {
                                goodsU = goodsUWork;
                                goodsUList.Add(goodsUWork);
                                //goodsU.GoodsName = offerJoinPartsRetWork.PrimePartsName;//DEL 2011/09/16
                                goodsU.GoodsName = offerJoinPartsRetWork.PrimePartsKanaName;//ADD 2011/09/16
                                goodsU.BLGoodsCode = offerJoinPartsRetWork.TbsPartsCode;
                                goodsU.GoodsRateRank = offerJoinPartsRetWork.PartsLayerCd;
                                goodsU.GoodsNameKana = offerJoinPartsRetWork.PrimePartsKanaName;//ADD 2011/09/16
                                break;
                            }
                        }
                        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
                        //���i�X�V�敪�F����ꍇ�A���i�}�X�^�ɍX�V����
                        if (priceUpdateDivCd == 1)
                        {
                            // ���[�U�[���i���X�g
                            ArrayList priceList = goodsUWork.PriceList;
                            // ���i�X�V���X�g���쐬����
                            CreatePrimePartsPriceUpdateDataList(goodsUWork.EnterpriseCode, goodsUWork.GoodsNo, goodsUWork.GoodsMakerCd, priceChkSet, priceList, lstPrmPrice, lstRstPrm, out addList, out deleteList);
                            if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                            if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
                        }
                        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
                    }
                }
                catch
                {
                    
                }
            }
        }
        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- >>>>>
        #region ���i�}�X�^�̍X�V����

        /// <summary>
        /// ���i�������X�g�̐���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="makerCd">���[�J�[�R�[�h</param>
        /// <param name="priceMergeSt">�񋟃f�[�^�X�V�ݒ�}�X�^</param>
        /// <param name="prcUpdtTrgtList">�������i�}�X�^���X�g</param>
        /// <param name="lstPrimePrice">�D�Ǖ��i���i���X�g</param>
        /// <param name="addList">�ǉ��X�V�Ώۃ��X�g</param>
        /// <param name="deleteList">�폜�Ώۃ��X�g</param>
        private void CreatePrimePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceChgSet priceChkSet, ArrayList priceList, ArrayList lstPrimePrice, ArrayList lstRstPrm, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (lstPrimePrice == null || lstPrimePrice.Count == 0) return;

            // �񋟁E���[�U�[���}�[�W�������X�g
            SortedDictionary<DateTime, object> prcList = new SortedDictionary<DateTime, object>();
            // ���[�U�[�ɓ��ꉿ�i�J�n�������镪�̒񋟃��X�g
            Dictionary<DateTime, OfferJoinPriceRetWork> duplicateList = new Dictionary<DateTime, OfferJoinPriceRetWork>();

            // ���[�U�[���i�}�X�^���烊�X�g�ǉ�
            foreach (GoodsPriceUWork data in priceList)
            {
                if (data.PriceStartDate == DateTime.MinValue) continue;

                if (!prcList.ContainsKey(data.PriceStartDate))
                {
                    prcList.Add(data.PriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // �񋟗D�ǉ��i�}�X�^���烊�X�g�ǉ�
            foreach (OfferJoinPriceRetWork prmPrtPriceWork in lstPrimePrice)
            {
                if (makerCd == prmPrtPriceWork.PartsMakerCd
                    && goodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                {
                    // �Z���N�g�R�[�h������ꍇ�͊Y�����i���`�F�b�N����
                    if (prmPrtPriceWork.PrmSetDtlNo1 != 0)
                    {
                        if (prmSettingUWorkList == null) continue;
                        int GoodsMGroup = 0;
                        int TbsPartsCode = 0;

                        foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                        { 
                            if (offerJoinPartsRetWork.JoinDestMakerCd == makerCd
                                && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo)
                            {
                                GoodsMGroup = offerJoinPartsRetWork.GoodsMGroup;
                                TbsPartsCode = offerJoinPartsRetWork.TbsPartsCode;
                                break;
                            }
                        }

                        PrmSettingUWork prmSettingWork = prmSettingUWorkList.Find(
                            delegate(PrmSettingUWork target)
                            {
                                if (target.PartsMakerCd == prmPrtPriceWork.PartsMakerCd &&
                                    target.GoodsMGroup == GoodsMGroup &&
                                    target.TbsPartsCode == TbsPartsCode &&
                                    target.PrmSetDtlNo1 == prmPrtPriceWork.PrmSetDtlNo1
                                   ) return true;

                                return false;
                            });

                        if (prmSettingWork == null) continue;
                    }
                    // ���Ƀ��[�U�[�ɓ��ꉿ�i�J�n��������ꍇ�͏d�����X�g�Ɉڍs
                    if (prcList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                    {
                        // �񋟃f�[�^���ɁA�񋟓��t���d���̃f�[�^�����鎞�A�}�[�W�������s��
                        if (ofrDtExists && !duplicateList.ContainsKey(prmPrtPriceWork.PriceStartDate)
                            && prcList[prmPrtPriceWork.PriceStartDate] is OfferJoinPriceRetWork)
                        {
                            OfferJoinPriceRetWork ofrData = (OfferJoinPriceRetWork)prcList[prmPrtPriceWork.PriceStartDate];
                            ofrData.OfferDate = prmPrtPriceWork.OfferDate;// �񋟓��t
                            ofrData.OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;// �I�[�v�����i�敪;
                            // �V�����艿���[���̏ꍇ
                            if (prmPrtPriceWork.NewPrice == 0)
                            {
                                // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                                if (priceChkSet.OpenPriceDiv == 0)
                                {
                                    // ���̃��[�U�[���i�����p��
                                }
                                else
                                {
                                    ofrData.NewPrice = 0;         // �艿�O
                                }
                            }
                            else
                            {
                                ofrData.NewPrice = prmPrtPriceWork.NewPrice;
                            }
                            prcList.Remove(prmPrtPriceWork.PriceStartDate);
                            prcList.Add(ofrData.PriceStartDate, ofrData);
                        }
                        else if (duplicateList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                        {
                            duplicateList[prmPrtPriceWork.PriceStartDate].OfferDate = prmPrtPriceWork.OfferDate;// �񋟓��t
                            duplicateList[prmPrtPriceWork.PriceStartDate].OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;// �I�[�v�����i�敪

                            // �V�����艿���[���̏ꍇ
                            if (prmPrtPriceWork.NewPrice == 0)
                            {
                                // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                                if (priceChkSet.OpenPriceDiv == 0)
                                {
                                    // ���̃��[�U�[���i�����p��
                                }
                                else
                                {
                                    duplicateList[prmPrtPriceWork.PriceStartDate].NewPrice = 0;         // �艿�O
                                }
                            }
                            else
                            {
                                duplicateList[prmPrtPriceWork.PriceStartDate].NewPrice = prmPrtPriceWork.NewPrice;
                            }
                        }
                        else
                        {
                        duplicateList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    }
                    else
                    {
                        prcList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    ofrDtExists = true;
                }
            }
            if (!ofrDtExists) return;

            // �Â������猩�Ă���
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    �@// ���[�U�[�f�[�^�̍ŐV���i���i���Łj
            GoodsPriceUWork usrGoods = new GoodsPriceUWork(); // ���[�U�[���i

            foreach (DateTime prcStDate in prcList.Keys)
            {
                // ���[�U�[���i
                if (prcList[prcStDate] is GoodsPriceUWork)
                {
                    usrGoods = (GoodsPriceUWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = usrGoods;

                    // �񋟃f�[�^���������ꍇ
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        OfferJoinPriceRetWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                              // �X�V���t
                        writeWork.OfferDate = ofrData.OfferDate; // �񋟓��t
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                    // �I�[�v�����i�敪

                        // �V�����艿���[���̏ꍇ
                        if (ofrData.NewPrice == 0)
                        {
                            // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                            if (priceChkSet.OpenPriceDiv == 0)
                            {
                                // ���̃��[�U�[���i�����p��
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // �艿�O
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.NewPrice;
                        }

                        // �񋟃f�[�^���������ꍇ�̂݉��i�������X�g�ւ̒ǉ�
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is OfferJoinPriceRetWork)
                {
                    OfferJoinPriceRetWork ofrData = (OfferJoinPriceRetWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // ��ƃR�[�h
                    writeWork.PriceStartDate = ofrData.PriceStartDate;       // ���i�J�n��
                    writeWork.GoodsMakerCd = makerCd;                       // ���[�J�[
                    writeWork.GoodsNo = goodsNo;                            // �i��
                    writeWork.UpdateDate = DateTime.Now;                    // �X�V�N����

                    // ���[�U�[���i�}�X�^�̓��e�����p��(�񋟂���ԌÂ��ꍇ�͓���Ȃ�)
                    writeWork.SalesUnitCost = usrGoods.SalesUnitCost;  // �����P��
                    writeWork.StockRate = usrGoods.StockRate;          // �d����

                    writeWork.OfferDate = ofrData.OfferDate; // �񋟓��t
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // �I�[�v�����i�敪
                    writeWork.ListPrice = ofrData.NewPrice;                // �艿

                    // �񋟂̕W�����i���[���̏ꍇ
                    if (ofrData.NewPrice == 0)
                    {
                        // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                        if (priceChkSet.OpenPriceDiv == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1�O�̒艿���Z�b�g
                            }
                    }
                }
                    // ���i�������X�g�ɒǉ�
                    allList.Add(writeWork);

                    // �S�����X�g�ɒǉ�
                    addList.Add(writeWork);
                }
            }

            // �Ǘ������𒴂��Ă���ꍇ�A�Â��f�[�^�������
            if (allList.Count > priceChkSet.PriceMngCnt)
            {
                // �폜���錏��
                int delCnt = allList.Count - priceChkSet.PriceMngCnt;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];
                    
                    // �쐬�����������Ă���ꍇ�́A���[�U�[�o�^����Ă������Ȃ̂ŁA�폜���X�g�ɒǉ�
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // �ǉ��E�X�V�f�[�^�Ɋ܂܂��ꍇ�̓��X�g����폜
                    if (addList.Contains(data)) addList.Remove(data);

                    // �擪�f�[�^������
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
        // --- ADD yangmj 2012/06/12 ���i�X�V�敪�ǉ�----------------- <<<<<
        #endregion �� Private Method

    }
}

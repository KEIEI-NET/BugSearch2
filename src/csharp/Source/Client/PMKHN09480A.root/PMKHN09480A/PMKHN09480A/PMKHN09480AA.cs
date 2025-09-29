//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j 
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�֘A�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/08/26  �C�����e : #13720�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2010/09/10  �C�����e : ��Q�E���ǑΉ�8���ذ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/26  �C�����e : Redmine#14490�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2012/12/07  �C�����e : 2013/01/16�z�M���@Redmine#33663��#7
//                                  �u�d���P���v�Ɓu�d�����v��\������A�����͂ł���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using Broadleaf.Application.UIData;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�֘A�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ݒ�}�X�^�����֘A�������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/08/10</br>
    /// <br>Update Note: 2010/08/26 �k���r #13720�̑Ή�</br>
    /// <br>Update Note: 2010/09/10 ���� ��Q�E���ǑΉ�8���ذ�</br>
    /// <br>Update Note: 2010/09/26 ������ Redmine#14490�Ή�</br>
    /// <br>Update Note: 2012/12/07 �c����</br>
    /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
    /// <br>             Redmine#33663��#7�u�d���P���v�Ɓu�d�����v��\������A�����͂ł���Ή�
    /// </remarks>
    public partial class RateProtyMngPatternAcs
    {
        # region ��Private Member
        /// <summary>�|���D��Ǘ��}�X�^�f�[�^�Z�b�g</summary>
        /// <remarks></remarks> 
        private RateProtyMngDataSet _rateProtyMngDataSet;

        /// <summary>�|���}�X�^�f�[�^�Z�b�g</summary>
        /// <remarks></remarks> 
        private RateProtyMngPatternDataSet _rateProtyMngPatternDataSet;
        private DataTable _originalRateProtyMngDataTable;//�ύX�L���`�F�b�N�p �������̃f�[�^

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private static RateProtyMngPatternAcs _rateProtyMngPatternAcs;
        private IRateProtyMngPatternDB _iRateProtyMngPatternDB = null;

        // --- ADD 2010/09/09 ---------->>>>>
        private GoodsAcs _goodsAcs = null; //���i���̓A�N�Z�X�N���X
        // --- ADD 2010/09/09 ---------->>>>>
        #endregion

        #region  �� Public Memebers
        /// <summary>
        /// �|���D��Ǘ��}�X�^�f�[�^�Z�b�g
        /// </summary>
        public RateProtyMngDataSet RateProtyMngDataSet
        {
            get { return this._rateProtyMngDataSet; }
        }

        /// <summary>
        /// �|���}�X�^�f�[�^�Z�b�g
        /// </summary>
        public RateProtyMngPatternDataSet RateProtyMngPatternDataSet
        {
            get { return this._rateProtyMngPatternDataSet; }
        }

        /// <summary>
        /// �ύX�L���`�F�b�N�p �������̃f�[�^
        /// </summary>
        public DataTable OriginalRateProtyMngDataTable
        {
            get { return this._originalRateProtyMngDataTable; }
        }

        #endregion �� Public Memebers

        # region ��Constructer
        /// <summary>
        /// �|���ݒ�}�X�^�����֘A�����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�}�X�^�����֘A�����A�N�Z�X�N���X�R���X�g���N�^�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private RateProtyMngPatternAcs()
        {
            this._rateProtyMngDataSet = new RateProtyMngDataSet();
            this._rateProtyMngPatternDataSet = new RateProtyMngPatternDataSet();
            this._originalRateProtyMngDataTable = new DataTable();
            // ----------ADD 2010/09/09----------->>>>>
            this._goodsAcs = new GoodsAcs();

            // ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
            this._goodsAcs.IsLocalDBRead = false;
            string msg = string.Empty;

            // �����l�f�[�^�擾
            int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
            // ----------ADD 2010/09/09-----------<<<<<
            // �����[�g�I�u�W�F�N�g�擾
            try
            {
                this._iRateProtyMngPatternDB = (IRateProtyMngPatternDB)MediationRateProtyMngPatternDB.GetRateProtyMngPatternDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRateProtyMngPatternDB = null;
            }
        }

        /// <summary>
        /// ����`�[���̓A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>����`�[���̓A�N�Z�X�N���X �C���X�^���X</returns>
        public static RateProtyMngPatternAcs GetInstance()
        {
            if (_rateProtyMngPatternAcs == null)
            {
                _rateProtyMngPatternAcs = new RateProtyMngPatternAcs();
            }

            return _rateProtyMngPatternAcs;
        }
        # endregion


        #region ��Public Method
        /// <summary>
        /// ���_�A�P����ނŊ|���D��Ǘ��}�X�^��ǂݍ��ݓo�^����Ă�����e�\������
        /// </summary>
        /// <param name="rateProtyMngWork"></param>
        /// <param name="errMess"></param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : ���_�A�P����ނŊ|���D��Ǘ��}�X�^��ǂݍ��ݓo�^����Ă�����e�\�����s���B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int Search(RateProtyMngWork rateProtyMngWork, out string errMess)
        {
            return SearchProc(rateProtyMngWork, out errMess);
        }

        /// <summary>
        /// ���_�A�P����ނŊ|���D��Ǘ��}�X�^��ǂݍ��ݓo�^����Ă�����e�\������
        /// </summary>
        /// <param name="rateProtyMngWork"></param>
        /// <param name="errMess"></param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : ���_�A�P����ނŊ|���D��Ǘ��}�X�^��ǂݍ��ݓo�^����Ă�����e�\�����s���B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private int SearchProc(RateProtyMngWork rateProtyMngWork, out string errMess)
        {
            ArrayList rateProtyMngList = new ArrayList();
            errMess = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object paraobj = rateProtyMngWork;
            object retobj = null;
            try
            {
                // �|���D��Ǘ��ݒ�ǂݍ���
                status = this._iRateProtyMngPatternDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    rateProtyMngList = retobj as ArrayList;
                    if (rateProtyMngList.Count > 0)
                    {
                        CopyToRateProtyMngTable(rateProtyMngList);
                    }
                }
            }
            catch (Exception ex)
            {
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��ݏ���
        /// </summary>
        /// <param name="rateProtyMngPatternWork"></param>
        /// <param name="newList">�V�K���X�g</param>
        /// <param name="updateList">�|���}�X�^(�X�V���X�g)</param>
        /// <param name="patternMode">���[�h(0:BL�R�[�h;1:�i�Ԏw��;2:�P�Ǝw��;3:�w�ʎw��;4:���i�|��G�w��;5:�O���[�v�R�[�h�w��;6:���[�J�[�w��)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��݂܂��B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int SearchRateRelationData(RateProtyMngPatternWork rateProtyMngPatternWork, out ArrayList newList, out ArrayList updateList, int patternMode, out string retMessage)
        {
            return SearchRateRelationDataProc(rateProtyMngPatternWork, out newList, out updateList, patternMode, out retMessage);
        }

        /// <summary>
        /// ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��ݏ���
        /// </summary>
        /// <param name="rateProtyMngPatternWork"></param>
        /// <param name="newList">�V�K���X�g</param>
        /// <param name="updateList">�|���}�X�^(�X�V���X�g)</param>
        /// <param name="patternMode">���[�h(0:BL�R�[�h;1:�i�Ԏw��;2:�P�Ǝw��;3:�w�ʎw��;4:���i�|��G�w��;5:�O���[�v�R�[�h�w��;6:���[�J�[�w��)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ɂ���ĂŊ|���|���}�X�^�ƃ}�X�^��ǂݍ��݂܂��B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private int SearchRateRelationDataProc(RateProtyMngPatternWork rateProtyMngPatternWork, out ArrayList newList, out ArrayList updateList, int patternMode, out string retMessage)
        {
            retMessage = string.Empty;
            newList = new ArrayList();
            updateList = new ArrayList();
            object newListObj = null;
            object updateListObj = null;
            object paraObj = rateProtyMngPatternWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                // �|���}�X�^�ǂݍ���
                status = this._iRateProtyMngPatternDB.SearchRateRelationData(out newListObj, out updateListObj, paraObj, patternMode, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    newList = newListObj as ArrayList;
                    updateList = updateListObj as ArrayList;
                }
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �|���|���}�X�^�X�V����
        /// </summary>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <param name="mode">0:�V�K���[�h�G1:�X�V���[�h</param>
        /// <param name="patternMode">patternMode(0:�ʏ�;1:�w��)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : �|���|���}�X�^�X�V���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int WriteRateRelationData(RateProtyMng rateProtyMng, int mode, int patternMode, out string retMessage)
        {
            retMessage = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();
            try
            {
                DetailGridDataToList(ref updateList, ref deleteList, rateProtyMng, mode);

                if (updateList.Count == 0 && deleteList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    // �|���}�X�^�X�V
                    status = this._iRateProtyMngPatternDB.WriteRateRelationData(updateList, deleteList, patternMode, out retMessage);
                }
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }
        #endregion ��Public Method

        #region ��Private Method

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void CopyToRateProtyMngTable(ArrayList rateProtyMngList)
        {
            this.RateProtyMngDataSet.RateProtyMng.Rows.Clear();
            foreach (RateProtyMngWork work in rateProtyMngList)
            {
                // �V�K�s�擾
                RateProtyMngDataSet.RateProtyMngRow row = this.RateProtyMngDataSet.RateProtyMng.NewRateProtyMngRow();

                # region [copy]

                //�|���D�揇��
                row.RatePriorityOrder = work.RatePriorityOrder;
                //�|���ݒ薼��(���i)
                row.RateMngGoodsNm = work.RateMngGoodsNm;
                //�|���ݒ薼��(���Ӑ�)
                row.RateMngCustNm = work.RateMngCustNm;
                //�|���ݒ�敪
                row.RateSettingDivide = work.RateSettingDivide;
                //�P�����
                row.UnitPriceKind = work.UnitPriceKind;
                //���_�R�[�h
                row.SectionCode = work.SectionCode;
                //�|���ݒ�敪�i���i�j
                row.RateMngCustCd = work.RateMngCustCd;
                //�|���ݒ�敪�i���Ӑ�j
                row.RateMngGoodsCd = work.RateMngGoodsCd;
                # endregion

                // �ǉ�
                this.RateProtyMngDataSet.RateProtyMng.AddRateProtyMngRow(row);
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="resultList">���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2010/09/09 ������</br>
        /// <br>           : Redmine#14490��14492�Ή�</br>
        /// <br>Update Note: 2010/09/26 ������</br>
        /// <br>           : Redmine#14490�Ή�</br>
        /// </remarks>
        public void CopyToRateRelationDataSet(ArrayList resultList)
        {
            if (resultList.Count <= 0) return;
            this._originalRateProtyMngDataTable.Rows.Clear();
            this.RateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();
            int rowNo= 0;
            foreach (RateRlationWork work in resultList)
            {
                // �V�K�s�擾
                RateProtyMngPatternDataSet.RateProtyMngPatternRow row = this.RateProtyMngPatternDataSet.RateProtyMngPattern.NewRateProtyMngPatternRow();
                ++rowNo;
                # region [copy]
                row.RowNo += rowNo;
                row.CreateDateTime = work.CreateDateTime;
                row.UpdateDateTime = work.UpdateDateTime;
                row.FileHeaderGuid = work.FileHeaderGuid;
                // ----------UPD 2010/09/26--------->>>>>
                //row.BLGoodsCode = work.BLGoodsCode;
                if (work.BLGoodsCode == -1)
                {
                    row.BLGoodsCode = string.Empty;
                }
                else
                {
                    row.BLGoodsCode = work.BLGoodsCode.ToString("D5");
                }
                row.MasterNm = work.MasterNm;
                //row.GoodsMakerCd = work.GoodsMakerCd;
                if (work.GoodsMakerCd == -1)
                {
                    row.GoodsMakerCd = string.Empty;
                }
                else
                {
                    row.GoodsMakerCd = work.GoodsMakerCd.ToString("D4"); 
                }
                
                // ----------ADD 2010/09/09----------->>>>>
                double listPrice = 0.0;
                double salesUnitCost = 0.0;

                if (!string.IsNullOrEmpty(work.GoodsNo))
                {
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    
                    string msg = string.Empty;
                    listPrice = 0.0;
                    salesUnitCost = 0.0;

                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(work.SectionCode))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = work.SectionCode;
                    cndtn.GoodsMakerCd = work.GoodsMakerCd;
                    cndtn.BLGoodsCode = work.BLGoodsCode;
                    cndtn.GoodsNo = work.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    this.GetPrice(goodsUnitDataList, out listPrice, out salesUnitCost);

                    if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
                    {
                        GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                        //row.GoodsNo = work.GoodsNo + " " + goodsUnitData.GoodsName; // DEL 2010/09/25
                        row.GoodsNo = work.GoodsNo; // ADD 2010/09/25
                        row.GoodsNo2 = goodsUnitData.GoodsName; // ADD 2010/09/25
                    }
                    
                    //row.GoodsNo2 = work.GoodsNo; // DEL 2010/09/25
                    row.ListPrice = listPrice;
                    row.SalesUnitCost = salesUnitCost;

                }
                else
                {
                    row.GoodsNo = string.Empty;
                    row.GoodsNo2 = string.Empty;
                    row.ListPrice = work.ListPrice;
                    row.SalesUnitCost = work.SalesUnitCost;
                }
                // ----------ADD 2010/09/09-----------<<<<<
                //row.GoodsRateGrpCode = work.GoodsRateGrpCode;
                row.GoodsRateRank = work.GoodsRateRank;
                //row.BLGroupCode = work.BLGroupCode;
                //row.CustomerCode = work.CustomerCode;
                //row.CustRateGrpCode = work.CustRateGrpCode;
                //row.SupplierCd = work.SupplierCd;
                if (work.GoodsRateGrpCode == -1)
                {
                    row.GoodsRateGrpCode = string.Empty;
                }
                else
                {
                    row.GoodsRateGrpCode = work.GoodsRateGrpCode.ToString("D4");
                }
                if (work.BLGroupCode == -1)
                {
                    row.BLGroupCode = string.Empty;
                }
                else
                {
                    row.BLGroupCode = work.BLGroupCode.ToString("D5");
                }
                if (work.CustomerCode == -1)
                {
                    row.CustomerCode = string.Empty;
                }
                else
                {
                    row.CustomerCode = work.CustomerCode.ToString("D8");
                }
                if (work.CustRateGrpCode == -1)
                {
                    row.CustRateGrpCode = string.Empty;
                }
                else
                {
                    row.CustRateGrpCode = work.CustRateGrpCode.ToString("D4");
                }
                if (work.SupplierCd == -1)
                {
                    row.SupplierCd = string.Empty;
                }
                else
                {
                    row.SupplierCd = work.SupplierCd.ToString("D6");
                }
                // ----------UPD 2010/09/26-----------<<<<<
                row.LotCount = work.LotCount;
                row.PriceFl = work.PriceFl;
                row.RateVal = work.RateVal;
                row.UnPrcFracProcUnit = work.UnPrcFracProcUnit;
                row.UnPrcFracProcDiv = work.UnPrcFracProcDiv;
                if (work.UnPrcFracProcDiv == 1)
                {
                    row.UnPrcFracProcDivNm = "1";
                }
                else if (work.UnPrcFracProcDiv == 2)
                {
                    row.UnPrcFracProcDivNm = "2";
                }
                else if (work.UnPrcFracProcDiv == 3)
                {
                    row.UnPrcFracProcDivNm = "3";
                }
                else
                {
                    row.UnPrcFracProcDivNm = string.Empty;
                }
                row.GrsProfitSecureRate = work.GrsProfitSecureRate;
                row.UpRate = work.UpRate;
                //row.ListPrice = work.ListPrice; // DEL 2010/09/09
                //row.SalesUnitCost = work.SalesUnitCost; // DEL 2010/09/09
                row.UpdateLineFlg = work.UpdateLineFlg; // ADD 2010/09/10
                # endregion

                // �ǉ�
                this.RateProtyMngPatternDataSet.RateProtyMngPattern.AddRateProtyMngPatternRow(row);
            }
            this._originalRateProtyMngDataTable = this.RateProtyMngPatternDataSet.RateProtyMngPattern.Copy();
        }

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="updateList">�|���}�X�^���X�g(�X�V�p)</param>
        /// <param name="deleteList">�|���}�X�^���X�g(�폜�p)</param>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <param name="mode">0:�V�K���[�h�G1:�X�V���[�h</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>update Note: 2010/08/26 �k���r #13720�Ή�</br>
        /// <br>Update Note: 2010/09/26 ������ �d�l�A�� #14492�Ή�</br>
        /// </remarks>
        private void DetailGridDataToList(ref ArrayList updateList, ref ArrayList deleteList, RateProtyMng rateProtyMng, int mode)
        {
            RateWork rateWork = null;

            #region data
            foreach (RateProtyMngPatternDataSet.RateProtyMngPatternRow row in this.RateProtyMngPatternDataSet.RateProtyMngPattern)
            {
                //�X�V�ΏۊO
                if (row.SaveFlg == 0)
                {
                    continue;
                }

                #region �|���}�X�^
                rateWork = new RateWork();
                // �쐬����
                rateWork.CreateDateTime = row.CreateDateTime;
                // �X�V����
                rateWork.UpdateDateTime = row.UpdateDateTime;
                // ��ƃR�[�h
                rateWork.EnterpriseCode = this._enterpriseCode;
                // �_���폜�敪
                rateWork.LogicalDeleteCode = 0;
                // ���_�R�[�h
                rateWork.SectionCode = rateProtyMng.SectionCode.Trim();
                // �P���|���ݒ�敪
                rateWork.UnitRateSetDivCd = rateProtyMng.UnitPriceKind.ToString() + rateProtyMng.RateSettingDivide.Trim();
                // �P�����
                rateWork.UnitPriceKind = rateProtyMng.UnitPriceKind.ToString();
                // �|���ݒ�敪
                rateWork.RateSettingDivide = rateProtyMng.RateSettingDivide.Trim();
                // �|���ݒ�敪�i���i�j
                rateWork.RateMngGoodsCd = rateProtyMng.RateMngGoodsCd.Trim();
                // �|���ݒ薼�́i���i�j
                rateWork.RateMngGoodsNm = rateProtyMng.RateMngGoodsNm.Trim();
                // �|���ݒ�敪�i���Ӑ�j
                rateWork.RateMngCustCd = rateProtyMng.RateMngCustCd.Trim();
                // �|���ݒ薼�́i���Ӑ�j
                rateWork.RateMngCustNm = rateProtyMng.RateMngCustNm.Trim();
                // ----------UPD 2010/09/26--------->>>>>
                // ���i���[�J�[�R�[�h
                //rateWork.GoodsMakerCd = row.GoodsMakerCd;
                rateWork.GoodsMakerCd = TStrConv.StrToIntDef(row.GoodsMakerCd, 0);
                // ���i�ԍ�
                //rateWork.GoodsNo = row.GoodsNo.Trim();
                //rateWork.GoodsNo = row.GoodsNo2.Trim(); // DEL 2010/09/25
                rateWork.GoodsNo = row.GoodsNo.Trim(); // ADD 2010/09/25
                // ���i�|�������N
                rateWork.GoodsRateRank = row.GoodsRateRank.Trim();
                // BL���i�R�[�h
                //rateWork.BLGoodsCode = row.BLGoodsCode;
                rateWork.BLGoodsCode = TStrConv.StrToIntDef(row.BLGoodsCode, 0);
                // ���Ӑ�R�[�h
                //rateWork.CustomerCode = row.CustomerCode;
                rateWork.CustomerCode = TStrConv.StrToIntDef(row.CustomerCode, 0);
                // ���Ӑ�|���O���[�v�R�[�h
                //-----UPD 2010/08/26---------->>>>>
                //rateWork.CustRateGrpCode = row.CustRateGrpCode;
                //if (work.CustRateGrpCode == -1)
                //{
                //    rateWork.CustRateGrpCode = 0;
                //}
                //else
                //{
                //    rateWork.CustRateGrpCode = row.CustRateGrpCode;
                //}
                //-----UPD 2010/08/26----------<<<<<
                // �d����R�[�h
                //rateWork.SupplierCd = row.SupplierCd;
                rateWork.CustRateGrpCode = TStrConv.StrToIntDef(row.CustRateGrpCode, 0);
                rateWork.SupplierCd = TStrConv.StrToIntDef(row.SupplierCd, 0);
                // ���b�g��
                rateWork.LotCount = row.LotCount;
                // ���i
                rateWork.PriceFl = row.PriceFl;
                // �|��
                rateWork.RateVal = row.RateVal;
                // �P���[�������P��
                rateWork.UnPrcFracProcUnit = row.UnPrcFracProcUnit;
                // �P���[�������敪
                if (!string.IsNullOrEmpty(row.UnPrcFracProcDivNm))
                {
                    if (row.UnPrcFracProcDivNm == "1")
                    {
                        rateWork.UnPrcFracProcDiv = 1;
                    }
                    else if (row.UnPrcFracProcDivNm == "2")
                    {
                        rateWork.UnPrcFracProcDiv = 2;
                    }
                    else if (row.UnPrcFracProcDivNm == "3")
                    {
                        rateWork.UnPrcFracProcDiv = 3;
                    }
                }
                // ���i�|���O���[�v�R�[�h
                //rateWork.GoodsRateGrpCode = row.GoodsRateGrpCode;
                // BL�O���[�v�R�[�h
                //rateWork.BLGroupCode = row.BLGroupCode;
                rateWork.GoodsRateGrpCode = TStrConv.StrToIntDef(row.GoodsRateGrpCode, 0);
                rateWork.BLGroupCode = TStrConv.StrToIntDef(row.BLGroupCode, 0);
                // ----------UPD 2010/09/26---------<<<<<

                // UP��
                rateWork.UpRate = row.UpRate;
                // �e���m�ۗ�
                rateWork.GrsProfitSecureRate = row.GrsProfitSecureRate;

                if (mode == 0)
                {
                    // ���b�g��
                    rateWork.LotCount = 9999999.99;
                }
                else
                {
                    // GUID
                    rateWork.FileHeaderGuid = row.FileHeaderGuid;
                }
                #endregion �|���}�X�^

                //�@�V�K���[�h(�s�폜�����f�[�^���X�V�ΏۊO)
                if (mode == 0)
                {
                    if (row.LogicalDeleteCode == 0)
                    {
                        updateList.Add(rateWork);
                    }
                }
                //�@�X�V���[�h(�s�폜�����f�[�^���X�V�Ώ�)
                else
                {
                    // �s�폜
                    if (row.LogicalDeleteCode != 0)
                    {
                        if (row.UpdateLineFlg) { // ADD 2010/09/10
                            deleteList.Add(rateWork);
                        } // ADD 2010/09/10
                    }
                    else
                    {
                        updateList.Add(rateWork);
                    }
                }

            }

            // �X�V�p�|���}�X�^Filter����
            MergeUpdateData(rateProtyMng, ref updateList);
            #endregion data
        }

        /// <summary>
        /// �X�V�p�|���}�X�^Filter����
        /// </summary>
        /// <param name="updateList">�|���}�X�^���X�g(�X�V�p)</param>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <remarks>
        /// <br>Note       : �X�V�p�|���}�X�^Filter���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2012/12/07 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>             Redmine#33663��#7�u�d���P���v�Ɓu�d�����v��\������A�����͂ł���Ή�
        /// </remarks>
        private void MergeUpdateData(RateProtyMng rateProtyMng, ref ArrayList updateList)
        {
            if (updateList.Count == 0) return;
            ArrayList updateListNew = new ArrayList();
            switch (rateProtyMng.UnitPriceKind)
            {
                // �����ꍇ
                case 1:
                    foreach (RateWork rateWork in updateList)
                    {
                        //�u�����z�E�������E����UP���E�e���m�ۗ��v�����ꂩ��0
                        if (rateWork.PriceFl != 0 || rateWork.RateVal != 0 ||
                            rateWork.UpRate != 0 || rateWork.GrsProfitSecureRate != 0)
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
                // �����ꍇ
                case 2:
                    foreach (RateWork rateWork in updateList)
                    {
                        //�u�d�����v�����ꂩ��0
                        //if (rateWork.RateVal != 0) // DEL 2012/12/07 �c���� Redmine#33663��#7
                        if (rateWork.RateVal != 0 || rateWork.PriceFl != 0) // ADD 2012/12/07 �c���� Redmine#33663��#7
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
                // ���i�ꍇ
                case 3:
                    foreach (RateWork rateWork in updateList)
                    {
                        //�uհ�ް�艿�E�艿UP���v�����ꂩ��0
                        if (rateWork.PriceFl != 0 || rateWork.UpRate != 0)
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
            }
            updateList = updateListNew;
        }

        // --- ADD 2010/09/09 ---------->>>>>
        /// <summary>
        /// �i�Ԃ���͂���ƁA���i�ƌ��������
        /// </summary>
        /// <param name="goodsUnitDataList">���i�Ǘ����}�X�^</param>
        /// <param name="listPrice">�W�����i</param>
        /// <param name="salesUnitCost">���P��</param>
        /// <remarks>
        /// <br>Note       : �i�Ԃ���͂���ƁA���i�ƌ��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        public void GetPrice(List<GoodsUnitData> goodsUnitDataList, out double listPrice, out double salesUnitCost)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            double price = 0;
            double cost = 0;
            if (goodsUnitDataList.Count > 0)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                GoodsInputDataSet.GoodsPriceDataTable dt = new GoodsInputDataSet.GoodsPriceDataTable();
                GoodsInputDataSet.GoodsPriceRow goodsPriceRow = dt.NewGoodsPriceRow();
                goodsUnitData = goodsUnitDataList[0];
                this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                switch (goodsUnitData.OfferKubun)
                {
                    case 0: // ���[�U�[�o�^
                    case 1: // �񋟏����ҏW
                    case 2: // �񋟗D�ǕҏW
                        if (goodsUnitData.LogicalDeleteCode == 0)
                        {
                            if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                            {
                                if (goodsUnitData.GoodsPriceList.Count > 0)
                                {
                                    GoodsPrice goodsPrice = GetGoodsPriceByPriceStartDate(DateTime.Today, goodsUnitData.GoodsPriceList);

                                    // �W�����i
                                    if (goodsPrice != null)
                                    {
                                        price = goodsPrice.ListPrice;
                                    }

                                    // ���i�����Čv�Z����̂ŏ�����
                                    goodsPriceRow.CalcStockRate = 0.0;          // �v�Z������
                                    goodsPriceRow.CalcSalesUnitCost = 0.0;      // �v�Z�����z
                                    goodsPriceRow.CalcMaster = string.Empty;    // �Z�o�}�X�^
                                    goodsPriceRow.PriorityOrder = 0;            // �D�揇��
                                    goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode;
                                    goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                                    goodsPriceRow.GoodsNo = goodsPrice.GoodsNo;
                                    goodsPriceRow.ListPrice = goodsPrice.ListPrice;

                                    goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost;
                                    goodsPriceRow.StockRate = goodsPrice.StockRate;
                                    goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;
                                    goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate;

                                    if (goodsPrice.ListPrice != 0)
                                    {
                                        this._goodsAcs.CalclateUnitPrice(goodsPriceRow, goodsUnitData);             // �P���Z�o
                                        this._goodsAcs.SettingCalcMaster(goodsPriceRow);                            // �Z�o�}�X�^
                                        this._goodsAcs.SettingCalcStockRate(goodsPriceRow);                         // �Z�o�p������
                                        this._goodsAcs.SettingCalcSalesUnitCost(goodsPriceRow);                     // �Z�o�p�����P��
                                        if (!goodsPriceRow.PriceStartDate.Equals(DateTime.MinValue))
                                        {
                                            cost = goodsPriceRow.CalcSalesUnitCost;    // ���P��
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            listPrice = price;
            salesUnitCost = cost;
        }
        
        /// <summary>
        /// �w�肳�ꂽ�����ɍ������i��񃌃R�[�h���擾���܂��B
        /// </summary>
        /// <param name="dateTime">����</param>
        /// <returns>
        /// ���i�J�n�����w������̃��R�[�h�̂����A�ŋ߂̂��̂�Ԃ��܂��B
        /// �i�w�������薢���̃��R�[�h�͖�������܂��j
        /// </returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����ɍ������i��񃌃R�[�h���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
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
        }
        // --- ADD 2010/09/09 ----------<<<<<
        #endregion ��Private Method
    }
}

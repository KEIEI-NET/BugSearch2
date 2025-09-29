//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���`�[�Ɖ�
// �v���O�����T�v   : �d���`�[�Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E�@�K�j
// �� �� ��  2008/11/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : ��Q�Ή�9264
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBO�����}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: TBO�����}�X�^�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/11/28</br>
    /// </remarks>
    public class TBOSearchUAcs : IGeneralGuideData
    {
        #region �� Private Members

        private string _enterpriseCode;
        private string _loginSectionCode;

        private ITBOSearchUDB _iTBOSearchUDB;

        // ���_�}�X�^�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;
        // ���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs;
        // BL�R�[�h�}�X�^�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;
        // ���i�}�X�^�A�N�Z�X�N���X
        private GoodsAcs _goodsAcs;
        // �݌Ƀ}�X�^�A�N�Z�X�N���X
        private SearchStockAcs _searchStockAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// TBO�����}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^�A�N�Z�X�N���̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public TBOSearchUAcs()
        {
            try
            {
                this._iTBOSearchUDB = (ITBOSearchUDB)MediationTBOSearchUDB.GetTBOSearchUDB();
            }
            catch
            {
                this._iTBOSearchUDB = null;
            }

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // �C���X�^���X����
            string errMsg;
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._searchStockAcs = new SearchStockAcs();
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out errMsg);

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadBLGoodsCdUMnt();
        }
        #endregion �� Constructor


        #region �� Properties
        /// <summary>
        /// ���i�A�N�Z�X�N���X
        /// </summary>
        public GoodsAcs GoodsAccess
        {
            get { return this._goodsAcs; }
        }
        #endregion �� Properties


        #region �� Public Methods

        #region �}�X�^�擾����
        /// <summary>
        /// ���_���}�X�^�擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public SecInfoSet GetSecInfoSet(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode];
            }

            return new SecInfoSet();
        }

        /// <summary>
        /// �݌Ƀ}�X�^�擾����
        /// </summary>
        /// <param name="stock">�݌Ƀ}�X�^</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int GetStock(out Stock stock, int makerCode, string goodsNo, string warehouseCode)
        {
            stock = new Stock();

            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            para.GoodsMakerCd = makerCode;
            para.GoodsNo = goodsNo;
            para.WarehouseCode = warehouseCode;

            List<Stock> stockList;
            string errMsg;
            
            int status = this._searchStockAcs.Search(para, out stockList, out errMsg);
            if (status == 0)
            {
                stock = stockList[0];
            }

            return (status);
        }
        #endregion �}�X�^�擾����

        #region ���̎擾
        /// <summary>
        /// ���[�J�[���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// BL�R�[�h���擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h��(���p)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public string GetBLGoodsCdName(int blGoodsCode)
        {
            string blGoodsCdName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsCdName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
            }

            return blGoodsCdName;
        }
        #endregion ���̎擾

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^��S�������܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchAll(out ArrayList tboSearchUList, string enterpriseCode)
        {
            tboSearchUList = new ArrayList();

            // ��������
            int status = Search(ref tboSearchUList, enterpriseCode);

            return (status);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="equipGanreCode">�������ރR�[�h</param>
        /// <param name="equipName">��������</param>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^��S�������܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int Search(out List<GoodsUnitData> goodsUnitDataList, string enterpriseCode, string sectionCode, int equipGanreCode, string equipName)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;

            string errMsg;
            PartsInfoDataSet partsInfoDataSet;

            try
            {
                status = this._goodsAcs.SearchTBO(cndtn, equipGanreCode, equipName, out partsInfoDataSet, out goodsUnitDataList, out errMsg);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �݌Ƀ}�X�^���X�g�擾����(�_���폜�܂�)
        /// </summary>
        /// <param name="stockList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���i�A���f�[�^�ɊY������݌Ƀ}�X�^���X�g���擾���܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int GetStockList(out List<Stock> stockList, GoodsUnitData goodsUnitData)
        {
            stockList = new List<Stock>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = goodsUnitData.EnterpriseCode;
                goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                goodsCndtn.GoodsKindCode = 9;

                string errMsg;
                List<GoodsUnitData> goodsUnitDataList;

                status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg);
                if ((status == 0) && (goodsUnitDataList != null))
                {
                    stockList = goodsUnitDataList[0].StockList;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �������̃��X�g��������
        /// </summary>
        /// <param name="equipNameList">�������̃��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="equipGanreCode">��������</param>
        /// <param name="searchName">������������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   �����������̂ɊY�����鑕�����̂��������܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchEquipNameList(out List<string> equipNameList, string enterpriseCode, string sectionCode, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string errMsg;

            equipNameList = new List<string>();

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;

            // �}�X�^�T�[�`
            try
            {
                status = this._goodsAcs.SearchEquipName(cndtn, equipGanreCode, searchName, out equipNameList, out errMsg);
                if (status != 0)
                {
                    return (status);
                }
            }
            catch
            {
                status = -1;
                return (status);
            }

            return (status);
        }

        /// <summary>
        /// ���i��������
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���i���������܂��B(����i�Ԍ����K�C�h�L��A���[�U�[�E�񋟋��ɕ\��)</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchGoods(out GoodsUnitData goodsUnitData, int makerCode, string goodsNo)
        {
            goodsUnitData = new GoodsUnitData();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ���i���������ݒ�
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.GoodsMakerCd = makerCode;
                goodsCndtn.GoodsNo = goodsNo;
                goodsCndtn.PriceApplyDate = DateTime.Today;
                SecInfoSet secInfoSet = GetSecInfoSet(this._loginSectionCode);
                List<string> warehouseList = new List<string>();
                warehouseList.Add(secInfoSet.SectWarehouseCd1);

                string errMsg;
                List<GoodsUnitData> goodsUnitDataList;
                
                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                if (status == 0)
                {
                    goodsUnitData = (GoodsUnitData)goodsUnitDataList[0];
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion ��������

        #region �X�V����
        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="TBOSearchUList">TBO�����}�X�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^�E���i�}�X�^���X�V���܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int WriteRelation(ArrayList TBOSearchUList, ArrayList goodsUnitDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            customSerializeArrayList.Add(TBOSearchUList);

            if (goodsUnitDataList.Count > 0)
            {
                customSerializeArrayList.Add(goodsUnitDataList);
            }

            string errMsg;
            object paraObj = customSerializeArrayList;

            status = this._goodsAcs.WriteRelation(ref paraObj, out errMsg);
            if (status == 0)
            {

            }

            return (status);
        }
        #endregion �X�V����

        #region �����폜����
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int Delete(ArrayList tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList tboSearchUWorkList = new ArrayList();

            foreach (TBOSearchU tboSearchU in tboSearchUList)
            {
                // �N���X�����o�R�s�[����
                tboSearchUWorkList.Add(CopyToTBOSearchUWorkFromTBOSearchU(tboSearchU));
            }

            object paraObj = tboSearchUWorkList;

            try
            {
                status = this._iTBOSearchUDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion �����폜����

        #region �K�C�h����
        /// <summary>
        /// �������̃K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGanreCode">�������ރR�[�h</param>
        /// <param name="searchName">������(�B�������Ή�)</param>
        /// <param name="equipName">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: �������̂̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, int equipGanreCode, string searchName, out string equipName)
        {
            int status = -1;
            equipName = "";

            TableGuideParent tableGuideParent = new TableGuideParent("EQUIPNAMEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("EquipGanreCode", equipGanreCode);
            inObj.Add("SearchName", searchName);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // ��������
                equipName = retObj["EquipName"].ToString();
                
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet dataSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string enterpriseCode = "";
            int equipGanreCode;
            string searchName = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
                equipGanreCode = (int)inParm["EquipGanreCode"];
                searchName = inParm["SearchName"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return (status);
            }

            // �}�X�^�e�[�u���Ǎ���
            status = Search(ref dataSet, enterpriseCode, equipGanreCode, searchName);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return (status);
        }
        #endregion �K�C�h����

        #endregion �� Public Methods


        #region �� Private Methods

        #region �}�X�^�Ǎ�
        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }
        #endregion �}�X�^�Ǎ�

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBO�����}�X�^���������܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private int Search(ref ArrayList tboSearchUList, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                TBOSearchUWork paraWork = new TBOSearchUWork();
                paraWork.EnterpriseCode = enterpriseCode;

                ArrayList tboSearchUWorkList = new ArrayList();
                object retObj = tboSearchUWorkList;
                object paraObj = paraWork;

                // ��������
                status = this._iTBOSearchUDB.Search(ref retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == 0)
                {
                    tboSearchUWorkList = retObj as ArrayList;

                    foreach (TBOSearchUWork tboSearchUWork in tboSearchUWorkList)
                    {
                        // �N���X�����o�R�s�[����
                        tboSearchUList.Add(CopyToTBOSearchUFromTBOSearchUWork(tboSearchUWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �}�X�^���������i�K�C�h�\���p�j
        /// </summary>
        /// <param name="dataSet">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGanreCode">�������ރR�[�h</param>
        /// <param name="searchName">������(�B�������Ή�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B
        /// �@�@�@�@�@�@�@�@: No�Ƒ������݂̂̂�DataSet�ł��B</br>
        /// <br>Programmer  : 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        private int Search(ref DataSet dataSet, string enterpriseCode, int equipGanreCode, string searchName)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            string errMsg;
            List<string> equipNameList;

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = this._enterpriseCode;
            cndtn.SectionCode = this._loginSectionCode;

            // �}�X�^�T�[�`
            try
            {
                status = this._goodsAcs.SearchEquipName(cndtn, equipGanreCode, searchName, out equipNameList, out errMsg);
                if (status != 0)
                {
                    return (status);
                }
            }
            catch
            {
                status = -1;
                return (status);
            }

            ArrayList wkList = new ArrayList();
            for (int index = 0; index < equipNameList.Count; index++)
            {
                TBOSearchU tboSearchU = new TBOSearchU();
                tboSearchU.No = index + 1;
                tboSearchU.EquipName = equipNameList[index];

                wkList.Add(tboSearchU);
            }

            TBOSearchU[] aryTBOSearchU = new TBOSearchU[wkList.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkList.Count; i++)
            {
                aryTBOSearchU[i] = (TBOSearchU)wkList[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryTBOSearchU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return (status);
        }
        #endregion ��������

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="tboSearchUWork">TBO�����}�X�^���[�N�N���X</param>
        /// <returns>TBO�����}�X�^</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private TBOSearchU CopyToTBOSearchUFromTBOSearchUWork(TBOSearchUWork tboSearchUWork)
        {
            TBOSearchU tboSearchU = new TBOSearchU();

            tboSearchU.CreateDateTime = tboSearchUWork.CreateDateTime;              // �쐬����
            tboSearchU.UpdateDateTime = tboSearchUWork.UpdateDateTime;              // �X�V����
            tboSearchU.EnterpriseCode = tboSearchUWork.EnterpriseCode;              // ��ƃR�[�h
            tboSearchU.FileHeaderGuid = tboSearchUWork.FileHeaderGuid;              // GUID
            tboSearchU.UpdEmployeeCode = tboSearchUWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            tboSearchU.UpdAssemblyId1 = tboSearchUWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            tboSearchU.UpdAssemblyId2 = tboSearchUWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            tboSearchU.LogicalDeleteCode = tboSearchUWork.LogicalDeleteCode;        // �_���폜�敪
            tboSearchU.BLGoodsCode = tboSearchUWork.BLGoodsCode;                    // BL�R�[�h
            tboSearchU.EquipGenreCode = tboSearchUWork.EquipGenreCode;              // ��������
            tboSearchU.EquipName = tboSearchUWork.EquipName;                        // ��������
            tboSearchU.CarInfoJoinDispOrder = tboSearchUWork.CarInfoJoinDispOrder;  // �ԗ������\������
            tboSearchU.JoinDestMakerCd = tboSearchUWork.JoinDestMakerCd;            // �����惁�[�J�[�R�[�h
            tboSearchU.JoinDestMakerName = tboSearchUWork.JoinDestMakerName;        // �����惁�[�J�[��
            tboSearchU.JoinDestPartsNo = tboSearchUWork.JoinDestPartsNo;            // ������i��(-�t���i��)
            tboSearchU.JoinDestGoodsName = tboSearchUWork.JoinDestGoodsName;        // ������i��
            tboSearchU.JoinQty = tboSearchUWork.JoinQty;                            // ����QTY
            tboSearchU.EquipSpecialNote = tboSearchUWork.EquipSpecialNote;          // �������E���L����

            // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� >>>>>>START
            if (tboSearchUWork.JoinDestGoodsName.TrimEnd() == string.Empty)
            {
                // ������i�����󔒂̏ꍇ�A�����惁�[�J�[�����󔒂Őݒ�
                tboSearchU.JoinDestMakerName = string.Empty;
                tboSearchU.JoinDestGoodsName = string.Empty;
                // ADD 2009/04/09 ------>>>
                // ���i���͋󔒂Őݒ�
                tboSearchU.BLGoodsCode = 0;
                tboSearchU.JoinDestMakerCd = 0;
                // ADD 2009/04/09 ------<<<
            }
            // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� <<<<<<END
            
            return tboSearchU;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="tboSearchU">TBO�����}�X�^</param>
        /// <returns>TBO�����}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private TBOSearchUWork CopyToTBOSearchUWorkFromTBOSearchU(TBOSearchU tboSearchU)
        {
            TBOSearchUWork tboSearchUWork = new TBOSearchUWork();

            tboSearchUWork.CreateDateTime = tboSearchU.CreateDateTime;              // �쐬����
            tboSearchUWork.UpdateDateTime = tboSearchU.UpdateDateTime;              // �X�V����
            tboSearchUWork.EnterpriseCode = tboSearchU.EnterpriseCode;              // ��ƃR�[�h
            tboSearchUWork.FileHeaderGuid = tboSearchU.FileHeaderGuid;              // GUID
            tboSearchUWork.UpdEmployeeCode = tboSearchU.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            tboSearchUWork.UpdAssemblyId1 = tboSearchU.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            tboSearchUWork.UpdAssemblyId2 = tboSearchU.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            tboSearchUWork.LogicalDeleteCode = tboSearchU.LogicalDeleteCode;        // �_���폜�敪
            tboSearchUWork.BLGoodsCode = tboSearchU.BLGoodsCode;                    // BL�R�[�h
            tboSearchUWork.EquipGenreCode = tboSearchU.EquipGenreCode;              // ��������
            tboSearchUWork.EquipName = tboSearchU.EquipName;                        // ��������
            tboSearchUWork.CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;  // �ԗ������\������
            tboSearchUWork.JoinDestMakerCd = tboSearchU.JoinDestMakerCd;            // �����惁�[�J�[�R�[�h
            tboSearchUWork.JoinDestMakerName = tboSearchU.JoinDestMakerName;        // �����惁�[�J�[�R�[�h
            tboSearchUWork.JoinDestPartsNo = tboSearchU.JoinDestPartsNo;            // ������i��(-�t���i��)
            tboSearchUWork.JoinDestGoodsName = tboSearchU.JoinDestGoodsName;        // ������i��(-�t���i��)
            tboSearchUWork.JoinQty = tboSearchU.JoinQty;                            // ����QTY
            tboSearchUWork.EquipSpecialNote = tboSearchU.EquipSpecialNote;          // �������E���L����
            
            return tboSearchUWork;
        }
        #endregion �N���X�����o�R�s�[����

        #endregion �� Private Methods
    }
}

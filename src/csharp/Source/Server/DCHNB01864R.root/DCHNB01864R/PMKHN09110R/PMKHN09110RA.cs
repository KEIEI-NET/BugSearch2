//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   IOWriteGoodsUser�����[�g�I�u�W�F�N�g
//                  :   PMKHN09110R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112 �v�ۓc
// Date             :   2008/06/06
//----------------------------------------------------------------------
// Update Note      :   2010/11/05  22018  ��� ���b
//                  :     �E���i�Ǘ����}�X�^�̏d���G���[�𔭐������Ȃ��悤�C���B
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    public class IOWriteGoodsUser : RemoteWithAppLockDB
    {
        private GoodsMngDB _GoodsMngDB = null;

        private GoodsMngDB GoodsMngDb
        {
            get
            {
                if (this._GoodsMngDB == null)
                {
                    this._GoodsMngDB = new GoodsMngDB();
                }

                return this._GoodsMngDB;
            }
        }

        # region [Write]

        /// <summary>
        /// ����E�d�����ׂ����ɁA���i�}�X�^(���[�U�[)�ɖ��o�^�̏��i�f�[�^���쐬���܂��B
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">���i��񃊃X�g�C���f�b�N�X</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����I�u�W�F�N�g</param>        
        /// <param name="sqlTransaction">�g�����U�N�V�������I�u�W�F�N�g</param>
        /// <param name="sqlEncryptInfo">�Í������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(ref CustomSerializeArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            ArrayList list = paraList as ArrayList;

            return Write(ref list, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// ����E�d�����ׂ����ɁA���i�}�X�^(���[�U�[)�ɖ��o�^�̏��i�f�[�^���쐬���܂��B
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">���i��񃊃X�g�C���f�b�N�X</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����I�u�W�F�N�g</param>        
        /// <param name="sqlTransaction">�g�����U�N�V�������I�u�W�F�N�g</param>
        /// <param name="sqlEncryptInfo">�Í������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(ref ArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            addListPos = -1;

            try
            {
                ArrayList goodsUnitDtList = new ArrayList();

                // ���㖾�׃f�[�^�𕪗�
                ArrayList orgSlsDtlList = ListUtils.Find(paraList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                // ArrayList.BinarySearch �ɂ����āA��r�Ώۍ��ڂ������A�C�e�������X�g���ɕ������݂����ꍇ
                // �������C���f�b�N�X�l��Ԃ��Ȃ������������ׂɃW�F�l���b�N�ɃR�s�[���Ĉȍ~�̏������s��
                List<SalesDetailWork> slsDtlList = new List<SalesDetailWork>();

                if (orgSlsDtlList != null)
                {
                    slsDtlList.AddRange((SalesDetailWork[])orgSlsDtlList.ToArray(typeof(SalesDetailWork)));
                }

                // �d�����׃f�[�^ �𕪗�
                ArrayList orgStkDtlList = ListUtils.Find(paraList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                // ArrayList.BinarySearch �ɂ����āA��r�Ώۍ��ڂ������A�C�e�������X�g���ɕ������݂����ꍇ
                // �������C���f�b�N�X�l��Ԃ��Ȃ������������ׂɃW�F�l���b�N�ɃR�s�[���Ĉȍ~�̏������s��
                List<StockDetailWork> stkDtlList = new List<StockDetailWork>();

                if (orgStkDtlList != null)
                {
                    stkDtlList.AddRange((StockDetailWork[])orgStkDtlList.ToArray(typeof(StockDetailWork)));
                }

                // �`�[���גǉ����𕪗�
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                ArrayList slpDtlAdInfList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(slpDtlAdInfList))
                {
                    slpDtlAdInfList.Sort(DtlRelationGuidComp);

                    # region [���㖾�׃f�[�^ �� ���i�}�X�^(���[�U�[)�f�[�^�쐬]

                    if (slsDtlList.Count > 0)
                    {
                        foreach (SalesDetailWork slsDtlWrk in slsDtlList)
                        {
                            // ���㖾�ׂɕR�t���`�[���גǉ������擾
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // �`�[���גǉ���񂪑��݂��A�����i�o�^�敪�� 1:�o�^ �̏ꍇ
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 1)
                            {
                                # region ���i�A���f�[�^�̍쐬
                                // ���i�A���f�[�^���쐬����
                                GoodsUnitDataWork GoodsUnitDtWrk = new GoodsUnitDataWork();
                                GoodsUnitDtWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;               // ��ƃR�[�h
                                GoodsUnitDtWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;         // �_���폜�敪
                                GoodsUnitDtWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;                   // ���i���[�J�[�R�[�h
                                GoodsUnitDtWrk.GoodsNo = slsDtlWrk.GoodsNo;                             // ���i�ԍ�
                                GoodsUnitDtWrk.GoodsName = slsDtlWrk.GoodsName;                         // ���i����
                                GoodsUnitDtWrk.GoodsNameKana = slsDtlWrk.GoodsNameKana;                 // ���i���̃J�i
                                //GoodsUnitDtWrk.Jan =                                                  // JAN�R�[�h
                                GoodsUnitDtWrk.BLGoodsCode = slsDtlWrk.BLGoodsCode;                     // BL���i�R�[�h
                                GoodsUnitDtWrk.DisplayOrder = 0;                                        // �\������
                                GoodsUnitDtWrk.GoodsRateRank = slsDtlWrk.GoodsRateRank;                 // ���i�|�������N
                                GoodsUnitDtWrk.TaxationDivCd = slsDtlWrk.TaxationDivCd;                 // �ېŋ敪
                                GoodsUnitDtWrk.GoodsNoNoneHyphen = slsDtlWrk.GoodsNo.Replace("-", "");  // �n�C�t�������i�ԍ�
                                GoodsUnitDtWrk.OfferDate = slpDtlAdInfWrk.GoodsOfferDate;               // �񋟓��t
                                GoodsUnitDtWrk.GoodsKindCode = slsDtlWrk.GoodsKindCode;                 // ���i����
                                GoodsUnitDtWrk.GoodsNote1 = "";                                         // ���i���l�P
                                GoodsUnitDtWrk.GoodsNote2 = "";                                         // ���i���l�Q
                                GoodsUnitDtWrk.GoodsSpecialNote = "";                                   // ���i�K�i�E���L����
                                GoodsUnitDtWrk.EnterpriseGanreCode = slsDtlWrk.EnterpriseGanreCode;     // ���Е��ރR�[�h
                                GoodsUnitDtWrk.UpdateDate = DateTime.Now;                               // �X�V�N����
                                GoodsUnitDtWrk.PriceList = null;                                        // ���i���X�g
                                GoodsUnitDtWrk.StockList = null;                                        // �݌Ƀ��X�g
                                # endregion

                                # region ���i���i�f�[�^�̍쐬
                                // ���i���i�f�[�^���쐬����
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();
                                godsPrcUsrWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;                // ��ƃR�[�h
                                godsPrcUsrWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;          // �_���폜�t���O
                                godsPrcUsrWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
                                godsPrcUsrWrk.GoodsNo = slsDtlWrk.GoodsNo;                              // ���i�ԍ�
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;           // ���i�J�n��
                                godsPrcUsrWrk.ListPrice = slsDtlWrk.ListPriceTaxExcFl;                  // �艿(�Ŕ�)
                                godsPrcUsrWrk.SalesUnitCost = slsDtlWrk.SalesUnitCost;                  // �����P��
                                godsPrcUsrWrk.StockRate = 0;                                            // �d����
                                godsPrcUsrWrk.OpenPriceDiv = slsDtlWrk.OpenPriceDiv;                    // �I�[�v�����i�敪
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;                // �񋟓��t
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                                // �X�V���t
                                # endregion

                                // ���i�A���f�[�^�Ə��i���i�f�[�^�̏d�����Ȃ��ă��X�g�ɒǉ�
                                this.SetGoodsUnitData(ref goodsUnitDtList, GoodsUnitDtWrk, godsPrcUsrWrk);
                            }
                        }
                    }

                    # endregion

                    # region [�d�����׃f�[�^ �� ���i�}�X�^(���[�U�[)�f�[�^�쐬]

                    if (stkDtlList.Count > 0)
                    {
                        foreach (StockDetailWork stkDtlWrk in stkDtlList)
                        {
                            // �d�����ׂɕR�t���`�[���גǉ������擾
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(stkDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // �`�[���גǉ���񂪑��݂��A�����i�o�^�敪�� 1:�o�^ �̏ꍇ
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 1)
                            {
                                // ���i���i�}�X�^�ɑ΂��ēo�^���s���̂́A���i�}�X�^�ɑ΂��ĐV�K�o�^
                                // ���ꂽ���i�݂̂Ƃ���ׁA�����ŋ����I�ɉ��i�X�V�敪�� 0:��X�V �ɂ���B
                                slpDtlAdInfWrk.PriceUpdateDiv = 0;

                                # region ���i�A���f�[�^�̍쐬
                                // ���i�A���f�[�^���쐬����
                                GoodsUnitDataWork GoodsUnitDtWrk = new GoodsUnitDataWork();
                                GoodsUnitDtWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;               // ��ƃR�[�h
                                GoodsUnitDtWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;         // �_���폜�敪
                                GoodsUnitDtWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;                   // ���i���[�J�[�R�[�h
                                GoodsUnitDtWrk.GoodsNo = stkDtlWrk.GoodsNo;                             // ���i�ԍ�
                                GoodsUnitDtWrk.GoodsName = stkDtlWrk.GoodsName;                         // ���i����
                                //GoodsUnitDtWrk.GoodsNameKana =                                        // ���i���̃J�i
                                //GoodsUnitDtWrk.Jan =                                                  // JAN�R�[�h
                                GoodsUnitDtWrk.BLGoodsCode = stkDtlWrk.BLGoodsCode;                     // BL���i�R�[�h
                                GoodsUnitDtWrk.DisplayOrder = 0;                                        // �\������
                                GoodsUnitDtWrk.GoodsRateRank = stkDtlWrk.GoodsRateRank;                 // ���i�|�������N
                                GoodsUnitDtWrk.TaxationDivCd = stkDtlWrk.TaxationCode;                  // �ېŋ敪
                                GoodsUnitDtWrk.GoodsNoNoneHyphen = stkDtlWrk.GoodsNo.Replace("-", "");  // �n�C�t�������i�ԍ�
                                GoodsUnitDtWrk.OfferDate = slpDtlAdInfWrk.GoodsOfferDate;               // �񋟓��t
                                GoodsUnitDtWrk.GoodsKindCode = stkDtlWrk.GoodsKindCode;                 // ���i����
                                GoodsUnitDtWrk.GoodsNote1 = "";                                         // ���i���l�P
                                GoodsUnitDtWrk.GoodsNote2 = "";                                         // ���i���l�Q
                                GoodsUnitDtWrk.GoodsSpecialNote = "";                                   // ���i�K�i�E���L����
                                GoodsUnitDtWrk.EnterpriseGanreCode = stkDtlWrk.EnterpriseGanreCode;     // ���Е��ރR�[�h
                                GoodsUnitDtWrk.UpdateDate = DateTime.Now;                               // �X�V�N����
                                GoodsUnitDtWrk.PriceList = null;                                        // ���i���X�g
                                GoodsUnitDtWrk.StockList = null;                                        // �݌Ƀ��X�g
                                # endregion

                                # region ���i���i�f�[�^�̍쐬
                                // ���i���i�f�[�^���쐬����
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();
                                godsPrcUsrWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;                // ��ƃR�[�h
                                godsPrcUsrWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;          // �_���폜�t���O
                                godsPrcUsrWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
                                godsPrcUsrWrk.GoodsNo = stkDtlWrk.GoodsNo;                              // ���i�ԍ�
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;           // ���i�J�n��
                                godsPrcUsrWrk.ListPrice = stkDtlWrk.ListPriceTaxExcFl;                  // �艿(�Ŕ�)

                                if (stkDtlWrk.StockRate == 0)
                                {
                                    godsPrcUsrWrk.SalesUnitCost = stkDtlWrk.StockUnitPriceFl;           // �����P��
                                    godsPrcUsrWrk.StockRate = 0;                                        // �d����
                                }
                                else
                                {
                                    godsPrcUsrWrk.SalesUnitCost = 0;                                    // �����P��
                                    godsPrcUsrWrk.StockRate = stkDtlWrk.StockRate;                      // �d����
                                }
                                
                                godsPrcUsrWrk.OpenPriceDiv = stkDtlWrk.OpenPriceDiv;                    // �I�[�v�����i�敪
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;                // �񋟓��t
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                                // �X�V���t
                                # endregion

                                // ���i�A���f�[�^�Ə��i���i�f�[�^�̏d�����Ȃ��ă��X�g�ɒǉ�
                                this.SetGoodsUnitData(ref goodsUnitDtList, GoodsUnitDtWrk, godsPrcUsrWrk);
                            }
                        }
                    }

                    # endregion
                }

                if (ListUtils.IsNotEmpty(goodsUnitDtList))
                {
                    // ���i�}�X�^(���[�U�[)�ɓo�^
                    UsrJoinPartsSearchDB usrJoinPartsSearchDB = new UsrJoinPartsSearchDB();

                    // �p�����[�^�� CustomSerializeArrayList ��z�肵�č���Ă���̂ŕϊ����ēn��
                    object paramList = new CustomSerializeArrayList();
                    (paramList as CustomSerializeArrayList).Add(goodsUnitDtList);
                    status = usrJoinPartsSearchDB.ReadNewWriteRelation(ref paramList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (ListUtils.IsNotEmpty((paramList as CustomSerializeArrayList)))
                        {
                            // �o�^�����ɐ��������ꍇ�ɂ̂݁A�p�����[�^���X�g�ɏ��i����ǉ�����
                            goodsUnitDtList.Clear();
                            goodsUnitDtList.AddRange((paramList as CustomSerializeArrayList)[0] as ArrayList);

                            //addListPos = paraList.Add(goodsUnitDtList);  // �����o�^���ꂽ���i�A������{���ɕԂ��K�v������ꍇ�̓R�����g���O��

                            SalesDetailWork slsDtlWrk = new SalesDetailWork();  // ���[�N�I�Ӗ������Ŏg�p
                            StockDetailWork stkDtlWrk = new StockDetailWork();  // �@�@�@�@�@�V

                            StockSlipWork stkSlipWrk = null;                    // ���[�N�I�ȈӖ������Ŏg�p

                            if (stkDtlList.Count > 0)
                            {
                                // �d�����׃f�[�^���o�^����Ă���ꍇ�́A�R�t���Ă���d���`�[���擾����
                                stkSlipWrk = ListUtils.Find(paraList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            }

                            List<GoodsMngWork> GoodsMngGeneric = new List<GoodsMngWork>();           // ���i�Ǘ����}�X�^ �o�^�p���X�g

                            // ���i�}�X�^(���[�U�[)�ɓo�^���ꂽ���i���������גǉ����̉��i�X�V�t���O���N���A(0)����
                            foreach (GoodsUnitDataWork goodsUnit in goodsUnitDtList)
                            {
                                # region [���i�}�X�^(���[�U�[)�f�[�^���L�[�ɔ��㖾�׃f�[�^������]
                                if (slsDtlList.Count > 0)
                                {
                                    int idx = 0;
                                    int pos = -1;

                                    do
                                    {
                                        // �����p�Ƀ_�~�[�̔��㖾�׃f�[�^(���i���)���Z�b�g
                                        slsDtlWrk = new SalesDetailWork();
                                        slsDtlWrk.EnterpriseCode = goodsUnit.EnterpriseCode;
                                        slsDtlWrk.GoodsMakerCd = goodsUnit.GoodsMakerCd;
                                        slsDtlWrk.GoodsNo = goodsUnit.GoodsNo;

                                        // �������i���������㖾�׃f�[�^���A�����͈͂��w�肵�Č�������
                                        pos = slsDtlList.FindIndex(idx, slsDtlList.Count - idx,
                                                                   delegate(SalesDetailWork item)
                                                                   {
                                                                       return (item.EnterpriseCode == slsDtlWrk.EnterpriseCode &&
                                                                               item.GoodsMakerCd == slsDtlWrk.GoodsMakerCd &&
                                                                               item.GoodsNo == slsDtlWrk.GoodsNo);
                                                                   });

                                        if (pos > -1)
                                        {
                                            // ���㖾�׃f�[�^����֘A���閾�גǉ������擾���A���i�X�V�敪�� 0:��X�V �ɂ���
                                            slsDtlWrk = slsDtlList[pos] as SalesDetailWork;

                                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                                            if (slpDtlAdInfPos > -1)
                                            {
                                                (slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork).PriceUpdateDiv = 0;
                                            }

                                            idx = pos + 1;

                                            // ���㖾�׃f�[�^���珤�i�Ǘ����f�[�^���쐬����
                                            // ���i�Ǘ����̎擾�D�揇�ʂ𓥂܂��āABL�R�[�h�͐ݒ肵�Ȃ��B(���_+���i���[�J�[�R�[�h+���i�ԍ�)
                                            GoodsMngWork GoodsMngWrk = new GoodsMngWork();
                                            GoodsMngWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;  // ��ƃR�[�h
                                            GoodsMngWrk.SectionCode = slsDtlWrk.SectionCode;        // ���_�R�[�h
                                            GoodsMngWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;      // ���i���[�J�[�R�[�h
                                            GoodsMngWrk.GoodsNo = slsDtlWrk.GoodsNo;                // ���i�ԍ�
                                            GoodsMngWrk.SupplierCd = slsDtlWrk.SupplierCd;          // �d����R�[�h
                                            
                                            if (!GoodsMngGeneric.Exists(delegate (GoodsMngWork item)
                                                                    {
                                                                        return (item.EnterpriseCode == GoodsMngWrk.EnterpriseCode &&
                                                                                item.SectionCode == GoodsMngWrk.SectionCode &&
                                                                                item.GoodsMakerCd == GoodsMngWrk.GoodsMakerCd &&
                                                                                item.GoodsNo == GoodsMngWrk.GoodsNo);
                                                                    }))
                                            {
                                                // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                                                //GoodsMngGeneric.Add(goodsMngWork);

                                                // ���i�Ǘ����}�X�^�ɖ��o�^�ł��鎖���m�F����B
                                                if ( !ExistsGoodsMng( ref GoodsMngWrk, ref sqlConnection, ref sqlTransaction ) )
                                                {
                                                    GoodsMngGeneric.Add( GoodsMngWrk );
                                                }
                                                // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                                            }
                                        }

                                    } while (pos > -1);
                                }
                                # endregion

                                # region [���i�}�X�^(���[�U�[)�f�[�^���L�[�Ɏd�����׃f�[�^������]
                                if (stkDtlList.Count > 0)
                                {
                                    int idx = 0;
                                    int pos = -1;

                                    do
                                    {
                                        // �����p�Ƀ_�~�[�̎d�����׃f�[�^(���i���)���Z�b�g
                                        stkDtlWrk = new StockDetailWork();
                                        stkDtlWrk.EnterpriseCode = goodsUnit.EnterpriseCode;
                                        stkDtlWrk.GoodsMakerCd = goodsUnit.GoodsMakerCd;
                                        stkDtlWrk.GoodsNo = goodsUnit.GoodsNo;

                                        // �������i�������d�����׃f�[�^���A�����͈͂��w�肵�Č�������
                                        pos = stkDtlList.FindIndex(idx, stkDtlList.Count - idx,
                                                                   delegate(StockDetailWork item)
                                                                   {
                                                                       return (item.EnterpriseCode == stkDtlWrk.EnterpriseCode &&
                                                                               item.GoodsMakerCd == stkDtlWrk.GoodsMakerCd &&
                                                                               item.GoodsNo == stkDtlWrk.GoodsNo);
                                                                   });

                                        if (pos > -1)
                                        {
                                            // �d�����׃f�[�^����֘A���閾�גǉ������擾���A���i�X�V�敪�� 0:��X�V �ɐݒ肷��
                                            stkDtlWrk = stkDtlList[pos] as StockDetailWork;

                                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(stkDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                                            if (slpDtlAdInfPos > -1)
                                            {
                                                (slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork).PriceUpdateDiv = 0;
                                            }

                                            idx = pos + 1;

                                            // �d�����׃f�[�^���珤�i�Ǘ����f�[�^���쐬����
                                            // ���i�Ǘ����̎擾�D�揇�ʂ𓥂܂��āABL�R�[�h�͐ݒ肵�Ȃ��B(���_+���i���[�J�[�R�[�h+���i�ԍ�)
                                            GoodsMngWork GoodsMngWrk = new GoodsMngWork();
                                            GoodsMngWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;  // ��ƃR�[�h
                                            GoodsMngWrk.SectionCode = stkDtlWrk.SectionCode;        // ���_�R�[�h
                                            GoodsMngWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;      // ���i���[�J�[�R�[�h
                                            GoodsMngWrk.GoodsNo = stkDtlWrk.GoodsNo;                // ���i�ԍ�
                                            
                                            if (stkSlipWrk != null)
                                            {
                                                GoodsMngWrk.SupplierCd = stkSlipWrk.SupplierCd;     // �d����R�[�h
                                            }

                                            if (!GoodsMngGeneric.Exists(delegate(GoodsMngWork item)
                                                                    {
                                                                        return (item.EnterpriseCode == GoodsMngWrk.EnterpriseCode &&
                                                                                item.SectionCode == GoodsMngWrk.SectionCode &&
                                                                                item.GoodsMakerCd == GoodsMngWrk.GoodsMakerCd &&
                                                                                item.GoodsNo == GoodsMngWrk.GoodsNo);
                                                                    }))
                                            {
                                                // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                                                //GoodsMngGeneric.Add(goodsMngWork);

                                                // ���i�Ǘ����}�X�^�ɖ��o�^�ł��鎖���m�F����B
                                                if ( !ExistsGoodsMng( ref GoodsMngWrk, ref sqlConnection, ref sqlTransaction ) )
                                                {
                                                    GoodsMngGeneric.Add( GoodsMngWrk );
                                                }
                                                // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                                            }
                                        }

                                    } while (pos > -1);
                                }
                                # endregion
                            }

                            // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                            //// ���i�Ǘ����}�X�^�ɓo�^
                            //ArrayList goodsMngList = new ArrayList(GoodsMngGeneric);
                            //status = this.GoodsMngDb.WriteGoodsMngProc(ref goodsMngList, ref sqlConnection, ref sqlTransaction);
                            
                            if ( GoodsMngGeneric != null && GoodsMngGeneric.Count > 0 )
                            {
                                // ���i�Ǘ����}�X�^�ɓo�^
                                ArrayList goodsMngList = new ArrayList( GoodsMngGeneric );
                                status = this.GoodsMngDb.WriteGoodsMngProc( ref goodsMngList, ref sqlConnection, ref sqlTransaction );
                            }
                            // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                        }
                    }
                }
                else
                {
                    // ���i�}�X�^�ɓo�^���ׂ��f�[�^�����݂��Ȃ��ꍇ�� ctDB_NORMAL �Ƃ���B
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;            
        }

        // --- ADD m.suzuki 2010/11/05 ---------->>>>>
        /// <summary>
        /// ���i�Ǘ����}�X�^���݃`�F�b�N
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns></returns>
        private bool ExistsGoodsMng( ref GoodsMngWork goodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            bool result = false;
            try
            {
                int goodsMngStatus = this.GoodsMngDb.ReadProc( ref goodsMngWork, 0, ref sqlConnection, ref sqlTransaction );
                if ( goodsMngStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ���݂��Ȃ�
                    return false;
                }

                if ( goodsMngWork.LogicalDeleteCode != 0 )
                {
                    // �_���폜�ς݁˕�������
                    goodsMngWork.LogicalDeleteCode = 0;
                    return false;
                }

                return true;
            }
            catch ( Exception ex )
            {
            }
            finally
            {
            }

            return result;
        }
        // --- ADD m.suzuki 2010/11/05 ----------<<<<<

        private void SetGoodsUnitData(ref ArrayList goodsUnitDtList, GoodsUnitDataWork GoodsUnitDtWrk, GoodsPriceUWork godsPrcUsrWrk)
        {
            // ���i�A���f�[�^���X�g�Ɋi�[����O�ɏd�����鏤�i�A���f�[�^�̑��݂��`�F�b�N����
            GoodsUnitDataComparer GoodsUnitDtComp = new GoodsUnitDataComparer();
            
            goodsUnitDtList.Sort(GoodsUnitDtComp);

            int goodsUnitIdx = goodsUnitDtList.BinarySearch(GoodsUnitDtWrk, GoodsUnitDtComp);

            if (goodsUnitIdx < 0)
            {
                // �d�����鏤�i�A���f�[�^�����݂��Ȃ��ꍇ�́A�쐬�������i���i�f�[�^��
                // ���i���X�g�Ɋi�[���ď��i�A���f�[�^���X�g�ɒǉ�����
                GoodsUnitDtWrk.PriceList = new ArrayList();
                GoodsUnitDtWrk.PriceList.Add(godsPrcUsrWrk);
                goodsUnitDtList.Add(GoodsUnitDtWrk);
            }
            else
            {
                // �d�����鏤�i�A���f�[�^�����݂��Ă���ꍇ�͏��i�A���f�[�^�̒ǉ��͍s��Ȃ��B
                // �A�����i���X�g���ɏd�����鏤�i���i�f�[�^���������ǂ������`�F�b�N���A
                // �d�����鏤�i���i�f�[�^�����݂��Ȃ��ꍇ�͏��i���i�f�[�^�݂̂�ǉ�����
                GoodsUnitDataWork GoodsUnitDtTmp = goodsUnitDtList[goodsUnitIdx] as GoodsUnitDataWork;

                GoodsPriceUComparer GoodsPriceUComp = new GoodsPriceUComparer();
                GoodsUnitDtTmp.PriceList.Sort(GoodsPriceUComp);

                int goodsPriceIdx = GoodsUnitDtTmp.PriceList.BinarySearch(godsPrcUsrWrk, GoodsPriceUComp);

                if (goodsPriceIdx < 0)
                {
                    GoodsUnitDtWrk.PriceList.Add(godsPrcUsrWrk);
                }
            }

        }

        # endregion

        # region [�e���r�p�N���X]

        /// <summary>
        /// ���i�A���f�[�^(��ɏ��i�f�[�^)��r�N���X
        /// </summary>
        private class GoodsUnitDataComparer : IComparer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                GoodsUnitDataWork xGoods = x as GoodsUnitDataWork;
                GoodsUnitDataWork yGoods = y as GoodsUnitDataWork;

                int ret = (xGoods == null ? 0 : 1) - (yGoods == null ? 0 : 1);

                if (ret == 0 && xGoods != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    ret = xGoods.EnterpriseCode.CompareTo(yGoods.EnterpriseCode);

                    // ���i���[�J�[�R�[�h�Ŕ�r
                    if (ret == 0)
                    {
                        ret = xGoods.GoodsMakerCd - yGoods.GoodsMakerCd;
                    }

                    // ���i�ԍ��Ŕ�r
                    if (ret == 0)
                    {
                        ret = xGoods.GoodsNo.CompareTo(yGoods.GoodsNo);
                    }
                }

                return ret;
            }
        }

        /// <summary>
        /// ���i���i�f�[�^��r�N���X
        /// </summary>
        private class GoodsPriceUComparer : IComparer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                GoodsPriceUWork xPrice = x as GoodsPriceUWork;
                GoodsPriceUWork yPrice = y as GoodsPriceUWork;

                int ret = (xPrice == null ? 0 : 1) - (yPrice == null ? 0 : 1);

                if (ret == 0 && xPrice != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    ret = xPrice.EnterpriseCode.CompareTo(yPrice.EnterpriseCode);

                    // ���i���[�J�[�R�[�h�Ŕ�r
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsMakerCd - yPrice.GoodsMakerCd;
                    }

                    // ���i�ԍ��Ŕ�r
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsNo.CompareTo(yPrice.GoodsNo);
                    }

                    // ���i�X�V��
                    if (ret == 0)
                    {
                        ret = xPrice.PriceStartDate.CompareTo(yPrice.PriceStartDate);
                    }
                }

                return ret;
            }
        }

        # endregion
    }
}

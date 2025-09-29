//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   IOWriteGoodsPriceUser�����[�g�I�u�W�F�N�g
//                  :   PMKHN09111R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112 �v�ۓc
// Date             :   2008/06/06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    public class IOWriteGoodsPriceUser : RemoteWithAppLockDB
    {
        # region [Write]

        /// <summary>
        /// ����E�d�����ׂ����ɁA���i���i�}�X�^(���[�U�[)�̃f�[�^���쐬�E�X�V���܂��B
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">���i���i��񃊃X�g �C���f�b�N�X</param>
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
        /// ����E�d�����ׂ����ɁA���i���i�}�X�^(���[�U�[)�̃f�[�^���쐬�E�X�V���܂��B
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">���i���i��񃊃X�g �C���f�b�N�X</param>
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
                ArrayList godsPrcUsrList = new ArrayList();

                // �`�[���גǉ����𕪗�
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                ArrayList slpDtlAdInfList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(slpDtlAdInfList))
                {
                    slpDtlAdInfList.Sort(DtlRelationGuidComp);

                    GoodsPriceUComparer goodsPriceUComp = new GoodsPriceUComparer();

                    # region [���㖾�׃f�[�^ �� ���i���i�}�X�^(���[�U�[)�f�[�^�쐬]

                    // ���㖾�׃f�[�^�𕪗�
                    ArrayList slsDtlList = ListUtils.Find(paraList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(slsDtlList))
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

                            // �`�[���גǉ���񂪑��݂��A�����i�X�V�敪�� 1:�X�V �̏ꍇ
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 0 && slpDtlAdInfWrk.PriceUpdateDiv == 1)
                            {
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();

                                godsPrcUsrWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;        // ��ƃR�[�h
                                godsPrcUsrWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;  // �_���폜�t���O
                                godsPrcUsrWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;            // ���i���[�J�[�R�[�h
                                godsPrcUsrWrk.GoodsNo = slsDtlWrk.GoodsNo;                      // ���i�ԍ�
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;   // ���i�J�n��
                                godsPrcUsrWrk.ListPrice = slsDtlWrk.ListPriceTaxExcFl;          // �艿(�Ŕ�)
                                godsPrcUsrWrk.SalesUnitCost = slsDtlWrk.SalesUnitCost;          // �����P��
                                godsPrcUsrWrk.StockRate = 0;                                    // �d����
                                godsPrcUsrWrk.OpenPriceDiv = slsDtlWrk.OpenPriceDiv;            // �I�[�v�����i�敪
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;        // �񋟓��t
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                        // �X�V���t

                                godsPrcUsrList.Sort(goodsPriceUComp);

                                int idx = godsPrcUsrList.BinarySearch(godsPrcUsrWrk, goodsPriceUComp);

                                if (idx < 0)
                                {
                                    // �d�����Ă��Ȃ����i���i�f�[�^�݂̂�ǉ�����
                                    godsPrcUsrList.Add(godsPrcUsrWrk);
                                }
                            }
                        }
                    }

                    # endregion

                    # region [�d�����׃f�[�^ �� ���i���i�}�X�^(���[�U�[)�f�[�^�쐬]

                    // �d�����׃f�[�^ �𕪗�

                    ArrayList stkDtlList = ListUtils.Find(paraList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(stkDtlList))
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

                            // �`�[���גǉ���񂪑��݂��A�����i�X�V�敪�� 1:�X�V �̏ꍇ
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 0 && slpDtlAdInfWrk.PriceUpdateDiv == 1)
                            {
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();

                                godsPrcUsrWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;        // ��ƃR�[�h
                                godsPrcUsrWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;  // �_���폜�t���O
                                godsPrcUsrWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;            // ���i���[�J�[�R�[�h
                                godsPrcUsrWrk.GoodsNo = stkDtlWrk.GoodsNo;                      // ���i�ԍ�
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;   // ���i�J�n��
                                godsPrcUsrWrk.ListPrice = stkDtlWrk.ListPriceTaxExcFl;          // �艿(�Ŕ�)

                                if (stkDtlWrk.StockRate == 0)
                                {
                                    godsPrcUsrWrk.SalesUnitCost = stkDtlWrk.StockUnitPriceFl;   // �����P��
                                    godsPrcUsrWrk.StockRate = 0;                                // �d����
                                }
                                else
                                {
                                    godsPrcUsrWrk.SalesUnitCost = 0;                            // �����P��
                                    godsPrcUsrWrk.StockRate = stkDtlWrk.StockRate;              // �d����
                                }

                                godsPrcUsrWrk.OpenPriceDiv = stkDtlWrk.OpenPriceDiv;            // �I�[�v�����i�敪
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;        // �񋟓��t
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                        // �X�V���t

                                godsPrcUsrList.Sort(goodsPriceUComp);

                                int idx = godsPrcUsrList.BinarySearch(godsPrcUsrWrk, goodsPriceUComp);

                                if (idx < 0)
                                {
                                    // �d�����Ă��Ȃ����i���i�f�[�^�݂̂�ǉ�����
                                    godsPrcUsrList.Add(godsPrcUsrWrk);
                                }
                            }
                        }
                    }

                    # endregion

                }

                if (ListUtils.IsNotEmpty(godsPrcUsrList))
                {
                    // ���i���i�}�X�^(���[�U�[)�ɍX�V
                    ArrayList errList = null;
                    GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();

                    status = goodsPriceUDB.UpDatePrice(ref godsPrcUsrList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsEmpty(errList))
                    {
                        // �o�^�����ɐ��������ꍇ�ɂ̂݁A�p�����[�^���X�g�ɏ��i���i����ǉ�����
                        addListPos = paraList.Add(godsPrcUsrList);
                    }
                }
                else
                {
                    // �X�V�Ώۂ̏��i���i�f�[�^���P�������݂��Ȃ��ꍇ�A�G���[�Ƃ͂��Ȃ��B
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

        # endregion

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
    }
}

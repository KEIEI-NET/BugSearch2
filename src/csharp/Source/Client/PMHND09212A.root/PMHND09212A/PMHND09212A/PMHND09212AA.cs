//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t���@�A�N�Z�X�N���X
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���f�[�^�ɑ΂��Ċe���쏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770175-00 �쐬�S�� : ������
// �C �� ��  2021/11/03  �C�����e : PJMIT-1499 OUT OF MEMORY�Ή�(4GB�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00 �쐬�S�� : ������
// �C �� ��  2021/11/18  �C�����e : PJMIT-1499 OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t���e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t���e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br>Update Note: 2021/11/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770175-00</br>
    /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�)</br>
    /// <br>Update Note: 2021/11/18 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770181-00</br>
    /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�</br>
    /// </remarks>
    public class GoodsBarCodeRevnAcs
    {
        /// <summary>�����[�g�I�u�W�F�N�g</summary>
        private IGoodsBarCodeRevnDB _iGoodsBarCodeRevnDB = null;
        // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------>>>>> 
        // �������A�E�g���f�p������
        private string CT_MemoryOutStr = "OutOfMemoryException";
        // �������A�E�g�t���O
        private bool _memoryOutFlag = false;
        /// <summary>
        /// �������A�E�g�t���O���p�e�B
        /// </summary>
        public bool MemoryOutFlag
        {
            get { return this._memoryOutFlag; }
            set { this._memoryOutFlag = value; }
        }
        // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------<<<<<

        // ���i�}�X�^�A�N�Z�X
        private GoodsAcs _goodsAcs;    

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnAcs()
        {
            // ���i�}�X�^�A�N�Z�X
            this._goodsAcs = new GoodsAcs();
            string msg;
            // ���i�}�X�^�A�N�Z�X����������
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode.TrimEnd(), LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out msg);
            
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iGoodsBarCodeRevnDB = MediationGoodsBarCodeRevnDB.GetGoodsBarCodeRevnDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iGoodsBarCodeRevnDB = null;
            }
        }

        #region �� ��������
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t����������(���C��)
        /// </summary>
        /// <param name="retList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>��������(���C��)����</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int Search(out List<GoodsBarCodeRevn> retList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new List<GoodsBarCodeRevn>();
            try
            {
                // ���i�A���f�[�^
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                // ���i�o�[�R�[�h�f�[�^
                List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
                // ���i�A���f�[�^��������
                status = SearchGoodsUnitData(out goodsUnitDataList, goodsBarCodeRevnSearchPara);
                // ���������G���[��
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                // ���i�o�[�R�[�h�f�[�^��������
                status = SearchGoodsBarCodeRevnWorkData(out goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchPara);
                // ���������G���[��
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                // ���i�o�[�R�[�h�f�[�^�Ə��i�A���f�[�^�����ѕt����
                retList = UnitGoodsDataAndGoodsBarData(goodsUnitDataList, goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchPara.HaveBarCodeDiv);

                if (retList != null && retList.Count > 0)
                {
                    // �������ʂ��莞
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // �������ʂȂ���
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                // ���������G���[��
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^��������
        /// </summary>
        /// <param name="goodsUnitDataList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^�̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/18 ������</br>
        /// <br>�Ǘ��ԍ�   : 11770181-00</br>
        /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�</br>
        /// </remarks>
        private int SearchGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            try
            {
                // StockDiv 0:�݌ɂ̂�
                if (goodsBarCodeRevnSearchPara.StockDiv == 0)
                {
                    List<GoodsUnitData> userGoodsUnitDataList = new List<GoodsUnitData>();
                    // ���i�A���f�[�^(���[�U�[��)��������
                    // --- UPD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------>>>>> 
                    //status = SearchUserGoodsUnitData(out userGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    //// ���������G���[��
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                    //if (userGoodsUnitDataList != null && userGoodsUnitDataList.Count > 0)
                    //{
                    //    foreach (GoodsUnitData temp in userGoodsUnitDataList)
                    //    {
                    //        if (temp.StockList != null && temp.StockList.Count > 0)
                    //        {
                    //            for (int i = temp.StockList.Count - 1; i >= 0; i--)
                    //            {
                    //                // ���������F�u�q�ɃR�[�h�v�Ɓu�Ǘ����_�R�[�h�v���L�莞�A
                    //                if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.WarehouseCode)
                    //                    && !string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.SectionCode))
                    //                {
                    //                    // ���i���Ɂu�q�ɃR�[�h�v�Ɓu�Ǘ����_�R�[�h�v�ɍ��v���Ȃ��q�ɏ�������
                    //                    if (temp.StockList[i].WarehouseCode != goodsBarCodeRevnSearchPara.WarehouseCode
                    //                        || temp.StockList[i].SectionCode != goodsBarCodeRevnSearchPara.SectionCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //                // ���������F�u�q�ɃR�[�h�v���L�莞
                    //                else if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.WarehouseCode))
                    //                {
                    //                    // ���i���Ɂu�q�ɃR�[�h�v�ɍ��v���Ȃ��q�ɏ�������
                    //                    if (temp.StockList[i].WarehouseCode != goodsBarCodeRevnSearchPara.WarehouseCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //                // ���������F�u�Ǘ����_�R�[�h�v���L�莞
                    //                else if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.SectionCode))
                    //                {
                    //                    // ���i���Ɂu�Ǘ����_�R�[�h�v�ɍ��v���Ȃ��q�ɏ�������
                    //                    if (temp.StockList[i].SectionCode != goodsBarCodeRevnSearchPara.SectionCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //            }
                    //            // �q�ɏ�񂪂���̏��i�݂̂��擾
                    //            if (temp.StockList != null && temp.StockList.Count > 0)
                    //            {
                    //                goodsUnitDataList.Add(temp);
                    //            }
                    //        }
                    //    }
                    //}
                    status = SearchStockUserGoodsUnitData(out goodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // --- UPD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------<<<<<
                }
                else
                {
                    List<GoodsUnitData> offerGoodsUnitDataList = new List<GoodsUnitData>();
                    List<GoodsUnitData> userGoodsUnitDataList = new List<GoodsUnitData>();
                    // ���i�A���f�[�^(�񋟕�)��������
                    status = SearchOfferGoodsUnitData(out offerGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // ���������G���[��
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                    // ���i�A���f�[�^(���[�U�[��)��������
                    status = SearchUserGoodsUnitData(out userGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // ���������G���[��
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

                    // ���i�A���f�[�^�f�B�N�V���i��
                    Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
                    // ���i�A���f�[�^(�񋟕�)���f�B�N�V���i���Ɏ���
                    if (offerGoodsUnitDataList != null && offerGoodsUnitDataList.Count > 0)
                    {
                        for (int i = 0; i < offerGoodsUnitDataList.Count; i++)
                        {
                            // �L�[: ���i���[�J�[�R�[�h(4��) + "_" + ���i�ԍ�
                            string dicKey = offerGoodsUnitDataList[i].GoodsMakerCd.ToString("0000") + "_" + offerGoodsUnitDataList[i].GoodsNo;
                            if (!goodsUnitDataDic.ContainsKey(dicKey))
                            {
                                goodsUnitDataDic.Add(dicKey, offerGoodsUnitDataList[i]);
                            }
                        }
                    }
                    // ���i�A���f�[�^(���[�U�[��)���f�B�N�V���i���Ɏ���
                    if (userGoodsUnitDataList != null && userGoodsUnitDataList.Count > 0)
                    {
                        for (int i = 0; i < userGoodsUnitDataList.Count; i++)
                        {
                            // �L�[: ���i���[�J�[�R�[�h(4��) + "_" + ���i�ԍ�
                            string dicKey = userGoodsUnitDataList[i].GoodsMakerCd.ToString("0000") + "_" + userGoodsUnitDataList[i].GoodsNo;
                            if (!goodsUnitDataDic.ContainsKey(dicKey))
                            {
                                goodsUnitDataDic.Add(dicKey, userGoodsUnitDataList[i]);
                            }
                        }
                    }
                    // �f�B�N�V���i���̒��̏��i�A���f�[�^���擾
                    foreach (GoodsUnitData temp in goodsUnitDataDic.Values)
                    {
                        goodsUnitDataList.Add(temp);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^(�񋟕�)��������
        /// </summary>
        /// <param name="goodsUnitDataList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^(�񋟕�)�̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchOfferGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            try
            {
                string errMsg = string.Empty;
                PartsInfoDataSet partsInfoDataSet;

                // ���o�����̍쐬
                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // ��ƃR�[�h
                goodsCndtn.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
                // ���i���[�J�[�R�[�h
                goodsCndtn.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
                // ���i�ԍ�
                goodsCndtn.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
                // �d������擾�敪 1:�ݒ�Ȃ�
                goodsCndtn.IsSettingSupplier = 1;
                // �_���폜�敪
                goodsCndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData0;

                // ���i�}�X�^�i�񋟃f�[�^�j����
                status = this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out errMsg);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^(���[�U�[��)��������
        /// </summary>
        /// <param name="goodsUnitDataList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^(���[�U�[��)�̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 11770175-00</br>
        /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�)</br>
        /// </remarks>
        private int SearchUserGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------>>>>>
            // �������A�E�g�t���O�������ݒ�
            this._memoryOutFlag = false;
            // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------<<<<<

            try
            {
                string errMsg = string.Empty;

                // ���o�����̍쐬
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                // ��ƃR�[�h
                goodsCndtn.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
                // ���i���[�J�[�R�[�h
                goodsCndtn.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
                // ���i�ԍ�
                goodsCndtn.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
                // �O����v
                goodsCndtn.GoodsNoSrchTyp = 1;
                // ���i���� (9:�S�đΏ�)
                goodsCndtn.GoodsKindCode = 9;
                // �d������擾�敪 1:�ݒ�Ȃ�
                goodsCndtn.IsSettingSupplier = 1;

                // ���� (�_���폜�f�[�^�擾���Ȃ�)
                status = this._goodsAcs.Search(goodsCndtn, 0, goodsBarCodeRevnSearchPara.StockDiv, ConstantManagement.LogicalMode.GetData0, out goodsUnitDataList, out errMsg);
                // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------>>>>>
                //�������A�E�g����������鎞�A�������A�E�g�t���O��true�ɐݒ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR &&
                    errMsg.Contains(CT_MemoryOutStr))
                {
                    this._memoryOutFlag = true;
                }
                // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------>>>>>
        /// <summary>
        /// �݌ɕ��̏��i�A���f�[�^(���[�U�[��)��������
        /// </summary>
        /// <param name="goodsUnitDataList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɕ��̏��i�A���f�[�^(���[�U�[��)�̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        private int SearchStockUserGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            ArrayList wkList = new ArrayList();
            try
            {
                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

                if (goodsBarCodeRevnSearchPara != null)
                {
                    // ���i�o�[�R�[�h�֘A�t�����������N���X �� ���[�N�N���X
                    goodsBarCodeRevnSearchParaWork = CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(goodsBarCodeRevnSearchPara);
                }
                // ���i�o�[�R�[�h�֘A�t�������������[�N�N���X �� obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // �݌ɕ��̏��i�A���f�[�^(���[�U�[��)����
                status = this._iGoodsBarCodeRevnDB.SearchStockGoods(out retobj, paraobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �݌ɕ��̏��i�A���f�[�^(���[�U�[��)����List
                    wkList = retobj as ArrayList;
                    if (wkList != null && wkList.Count > 0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            GoodsUnitData wkGoodsUnitData = new GoodsUnitData();
                            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = (GoodsBarCodeRevnWork)wkList[i];
                            wkGoodsUnitData.GoodsMakerCd = wkGoodsBarCodeRevnWork.GoodsMakerCd;
                            wkGoodsUnitData.GoodsNo = wkGoodsBarCodeRevnWork.GoodsNo;
                            wkGoodsUnitData.GoodsName = wkGoodsBarCodeRevnWork.GoodsName;
                            wkGoodsUnitData.MakerName = wkGoodsBarCodeRevnWork.MakerName;
                            wkGoodsUnitData.OfferDataDiv = wkGoodsBarCodeRevnWork.OfferDataDiv;
                            if (wkGoodsBarCodeRevnWork.OfferDate != 0)
                            {
                                wkGoodsUnitData.OfferDate = DateTime.ParseExact(wkGoodsBarCodeRevnWork.OfferDate.ToString(), "yyyyMMdd", null);
                            }
                            goodsUnitDataList.Add(wkGoodsUnitData);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------<<<<<

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t����������
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">��������List</param>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchGoodsBarCodeRevnWorkData(out List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
            try
            {
                ArrayList wkList = new ArrayList();

                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

                if (goodsBarCodeRevnSearchPara != null)
                {
                    // ���i�o�[�R�[�h�֘A�t�����������N���X �� ���[�N�N���X
                    goodsBarCodeRevnSearchParaWork = CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(goodsBarCodeRevnSearchPara);

                    goodsBarCodeRevnSearchParaWork.GoodsNo = string.Empty;
                }
                // ���i�o�[�R�[�h�֘A�t�������������[�N�N���X �� obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // ���i�o�[�R�[�h�֘A�t���f�[�^����
                status = this._iGoodsBarCodeRevnDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�o�[�R�[�h�֘A�t�����[�NList
                    wkList = retobj as ArrayList;
                    if (wkList != null&&wkList.Count>0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            goodsBarCodeRevnWorkList.Add((GoodsBarCodeRevnWork)wkList[i]);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�f�[�^�Ə��i�A���f�[�^�����ѕt����
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^</param>
        /// <param name="goodsBarCodeRevnWorkList">���i�o�[�R�[�h�f�[�^</param>
        /// <param name="haveCodeDiv">�o�^�敪</param>
        /// <returns>�������������f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�f�[�^�Ə��i�A���f�[�^�̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private List<GoodsBarCodeRevn> UnitGoodsDataAndGoodsBarData(List<GoodsUnitData> goodsUnitDataList, List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList, int haveCodeDiv)
        {
            List<GoodsBarCodeRevn> retList = new List<GoodsBarCodeRevn>();

            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {

                // ���i�o�[�R�[�h�֘A�t���f�B�N�V���i��
                Dictionary<string, GoodsBarCodeRevnWork> _goodsBarCodeRevnWorkDic = new Dictionary<string, GoodsBarCodeRevnWork>();
                // �L�[��List
                List<string> keyList = new List<string>();

                if (goodsBarCodeRevnWorkList != null && goodsBarCodeRevnWorkList.Count > 0)
                {
                    for (int i = 0; i < goodsBarCodeRevnWorkList.Count; i++)
                    {
                        // �L�[: ���i���[�J�[�R�[�h(4��) + "_" + ���i�ԍ�
                        string dicKey = goodsBarCodeRevnWorkList[i].GoodsMakerCd.ToString("0000") + "_" + goodsBarCodeRevnWorkList[i].GoodsNo;
                        if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                        {
                            // �����̃f�[�^���f�B�N�V���i���ɃZ�b�g
                            _goodsBarCodeRevnWorkDic.Add(dicKey, goodsBarCodeRevnWorkList[i]);
                        }
                    }
                }

                for (int j = 0; j < goodsUnitDataList.Count; j++)
                {
                    GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                    // ��ƃR�[�h
                    temp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    // ���i���[�J�[�R�[�h
                    temp.GoodsMakerCd = goodsUnitDataList[j].GoodsMakerCd;
                    // ���i�ԍ�
                    temp.GoodsNo = goodsUnitDataList[j].GoodsNo;
                    // ���[�J�[����
                    temp.MakerName = goodsUnitDataList[j].MakerName;
                    // ���i����
                    temp.GoodsName = goodsUnitDataList[j].GoodsName;
                    // ���i�o�[�R�[�h��ʁF0:JAN
                    temp.GoodsBarCodeKind = 0;
                    // �񋟃f�[�^�敪
                    temp.OfferDataDiv = goodsUnitDataList[j].OfferDataDiv;
                    // �񋟓��t
                    if (goodsUnitDataList[j].OfferDate != null)
                    {
                        int intOfferDate = 0;
                        Int32.TryParse(goodsUnitDataList[j].OfferDate.ToString("yyyyMMdd"), out intOfferDate);
                        temp.OfferDate = intOfferDate;
                    }

                    // �L�[: ���i���[�J�[�R�[�h(4��)  + "_" + ���i�ԍ�
                    string dicKey = goodsUnitDataList[j].GoodsMakerCd.ToString("0000") + "_" + goodsUnitDataList[j].GoodsNo;
                    // �o�^�ς݃f�[�^
                    if (_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                    {
                        // �쐬����
                        temp.CreateDateTime = _goodsBarCodeRevnWorkDic[dicKey].CreateDateTime;
                        // �X�V����
                        temp.UpdateDateTime = _goodsBarCodeRevnWorkDic[dicKey].UpdateDateTime;
                        // GUID
                        temp.FileHeaderGuid = _goodsBarCodeRevnWorkDic[dicKey].FileHeaderGuid;
                        // �X�V�]�ƈ��R�[�h
                        temp.UpdEmployeeCode = _goodsBarCodeRevnWorkDic[dicKey].UpdEmployeeCode;
                        // �X�V�A�Z���u��ID1
                        temp.UpdAssemblyId1 = _goodsBarCodeRevnWorkDic[dicKey].UpdAssemblyId1;
                        // �X�V�A�Z���u��ID2
                        temp.UpdAssemblyId2 = _goodsBarCodeRevnWorkDic[dicKey].UpdAssemblyId2;
                        // �_���폜�敪
                        temp.LogicalDeleteCode = _goodsBarCodeRevnWorkDic[dicKey].LogicalDeleteCode;
                        // ���i�o�[�R�[�h
                        temp.GoodsBarCode = _goodsBarCodeRevnWorkDic[dicKey].GoodsBarCode;
                        // ���i�o�[�R�[�h���
                        temp.GoodsBarCodeKind = _goodsBarCodeRevnWorkDic[dicKey].GoodsBarCodeKind;
                        // �`�F�b�N�f�W�b�g�敪
                        temp.CheckdigitCode = _goodsBarCodeRevnWorkDic[dicKey].CheckdigitCode;
                        // �񋟓��t
                        temp.OfferDate = _goodsBarCodeRevnWorkDic[dicKey].OfferDate;
                        // �񋟃f�[�^�敪
                        temp.OfferDataDiv = _goodsBarCodeRevnWorkDic[dicKey].OfferDataDiv;
                    }
                    // �o�^�敪 0:�S�� 1:�o�[�R�[�h�L�� 2:�o�[�R�[�h����
                    if (haveCodeDiv == 0)
                    {
                        retList.Add(temp);
                    }
                    else
                    {
                        if (haveCodeDiv == 1 && !string.IsNullOrEmpty(temp.GoodsBarCode))
                        {
                            retList.Add(temp);
                        }
                        else if (haveCodeDiv == 2 && string.IsNullOrEmpty(temp.GoodsBarCode))
                        {
                            retList.Add(temp);
                        }
                    }
                }
            }
            
            return retList;
        }
        #endregion

        #region �� �ۑ�����
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���f�[�^�̕ۑ�����
        /// </summary>
        /// <param name="saveList">�ۑ��p���X�g</param>
        /// <param name="deleteList">�폜�p���X�g</param>
        /// <returns>�ۑ���������</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int WriteBySave(List<GoodsBarCodeRevn> saveList, List<GoodsBarCodeRevn> deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList saveWorkList = new ArrayList();
                ArrayList deleteWorkList = new ArrayList();
                if (saveList != null && saveList.Count > 0)
                {
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        // �ۑ��p���i�o�[�R�[�h�֘A�t�����[�NList
                        saveWorkList.Add(CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(saveList[i]));
                    }
                }
                if (deleteList != null && deleteList.Count > 0)
                {
                    for (int i = 0; i < deleteList.Count; i++)
                    {
                        // �폜�p���i�o�[�R�[�h�֘A�t�����[�NList
                        deleteWorkList.Add(CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(deleteList[i]));
                    }
                }
                object objSaveWorkList = (object)saveWorkList;
                object objDeleteWorkList = (object)deleteWorkList;
                // ���i�o�[�R�[�h�֘A�t���ۑ�����  
                status = this._iGoodsBarCodeRevnDB.WriteBySave(ref objSaveWorkList, ref objDeleteWorkList);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region �� �N���X �� �N���X���[�N����

        /// <summary>
        /// �N���X�����o�R�s�[�����i���i�o�[�R�[�h�֘A�t���N���X�����i�o�[�R�[�h�֘A�t���N���X���[�N�j
        /// </summary>
        /// <param name="goodsBarCodeRevn">���i�o�[�R�[�h�֘A�t���N���X</param>
        /// <returns>���i�o�[�R�[�h�֘A�t�����[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���N���X���珤�i�o�[�R�[�h�֘A�t�����[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnWork CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(GoodsBarCodeRevn goodsBarCodeRevn)
        {
            GoodsBarCodeRevnWork goodsBarCodeRevnWork = new GoodsBarCodeRevnWork();

            // �쐬����
            goodsBarCodeRevnWork.CreateDateTime = goodsBarCodeRevn.CreateDateTime;
            // �X�V����
            goodsBarCodeRevnWork.UpdateDateTime = goodsBarCodeRevn.UpdateDateTime;
            // ��ƃR�[�h
            goodsBarCodeRevnWork.EnterpriseCode = goodsBarCodeRevn.EnterpriseCode;
            // GUID
            goodsBarCodeRevnWork.FileHeaderGuid = goodsBarCodeRevn.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            goodsBarCodeRevnWork.UpdEmployeeCode = goodsBarCodeRevn.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            goodsBarCodeRevnWork.UpdAssemblyId1 = goodsBarCodeRevn.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            goodsBarCodeRevnWork.UpdAssemblyId2 = goodsBarCodeRevn.UpdAssemblyId2;
            // �_���폜�敪
            goodsBarCodeRevnWork.LogicalDeleteCode = goodsBarCodeRevn.LogicalDeleteCode;

            // ���i���[�J�[�R�[�h
            goodsBarCodeRevnWork.GoodsMakerCd = goodsBarCodeRevn.GoodsMakerCd;
            // ���i�ԍ�
            goodsBarCodeRevnWork.GoodsNo = goodsBarCodeRevn.GoodsNo;
            // ���i�o�[�R�[�h
            goodsBarCodeRevnWork.GoodsBarCode = goodsBarCodeRevn.GoodsBarCode;
            // ���i�o�[�R�[�h���
            goodsBarCodeRevnWork.GoodsBarCodeKind = goodsBarCodeRevn.GoodsBarCodeKind;
            // �`�F�b�N�f�W�b�g�敪
            goodsBarCodeRevnWork.CheckdigitCode = goodsBarCodeRevn.CheckdigitCode;
            // �񋟓��t
            goodsBarCodeRevnWork.OfferDate = goodsBarCodeRevn.OfferDate;
            // �񋟃f�[�^�敪
            goodsBarCodeRevnWork.OfferDataDiv = goodsBarCodeRevn.OfferDataDiv;
            // ���[�J�[����
            goodsBarCodeRevnWork.MakerName = goodsBarCodeRevn.MakerName;
            // ���i����
            goodsBarCodeRevnWork.GoodsName = goodsBarCodeRevn.GoodsName;

            return goodsBarCodeRevnWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����i���i�o�[�R�[�h�֘A�t�����[�N�N���X�����i�o�[�R�[�h�֘A�t���N���X�j
        /// </summary>
        /// <param name="goodsBarCodeRevnWork">���i�S�̐ݒ胏�[�N�N���X</param>
        /// <returns>���i�o�[�R�[�h�֘A�t���N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t�����[�N�N���X���珤�i�o�[�R�[�h�֘A�t���N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevn CopyToGoodsBarCodeRevnFromGoodsBarCodeRevnWork(GoodsBarCodeRevnWork goodsBarCodeRevnWork)
        {
            GoodsBarCodeRevn goodsBarCodeRevn = new GoodsBarCodeRevn();

            // �쐬����
            goodsBarCodeRevn.CreateDateTime = goodsBarCodeRevnWork.CreateDateTime;
            // �X�V����
            goodsBarCodeRevn.UpdateDateTime = goodsBarCodeRevnWork.UpdateDateTime;
            // ��ƃR�[�h
            goodsBarCodeRevn.EnterpriseCode = goodsBarCodeRevnWork.EnterpriseCode;
            // GUID
            goodsBarCodeRevn.FileHeaderGuid = goodsBarCodeRevnWork.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            goodsBarCodeRevn.UpdEmployeeCode = goodsBarCodeRevnWork.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            goodsBarCodeRevn.UpdAssemblyId1 = goodsBarCodeRevnWork.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            goodsBarCodeRevn.UpdAssemblyId2 = goodsBarCodeRevnWork.UpdAssemblyId2;
            // �_���폜�敪
            goodsBarCodeRevn.LogicalDeleteCode = goodsBarCodeRevnWork.LogicalDeleteCode;

            // ���i���[�J�[�R�[�h
            goodsBarCodeRevn.GoodsMakerCd = goodsBarCodeRevnWork.GoodsMakerCd;
            // ���i�ԍ�
            goodsBarCodeRevn.GoodsNo = goodsBarCodeRevnWork.GoodsNo;
            // ���i�o�[�R�[�h
            goodsBarCodeRevn.GoodsBarCode = goodsBarCodeRevnWork.GoodsBarCode;
            // ���i�o�[�R�[�h���
            goodsBarCodeRevn.GoodsBarCodeKind = goodsBarCodeRevnWork.GoodsBarCodeKind;
            // �`�F�b�N�f�W�b�g�敪
            goodsBarCodeRevn.CheckdigitCode = goodsBarCodeRevnWork.CheckdigitCode;
            // �񋟓��t
            goodsBarCodeRevn.OfferDate = goodsBarCodeRevnWork.OfferDate;
            // �񋟃f�[�^�敪
            goodsBarCodeRevn.OfferDataDiv = goodsBarCodeRevnWork.OfferDataDiv;
            // ���[�J�[����
            goodsBarCodeRevn.MakerName = goodsBarCodeRevnWork.MakerName;
            // ���i����
            goodsBarCodeRevn.GoodsName = goodsBarCodeRevnWork.GoodsName;

            return goodsBarCodeRevn;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����i���i�o�[�R�[�h�֘A�t�����������N���X���N���X���[�N�j
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchPara">���i�o�[�R�[�h�֘A�t�����������N���X</param>
        /// <returns>���i�o�[�R�[�h�֘A�t�������������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t�����������N���X���烏�[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnSearchParaWork CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

            // ��ƃR�[�h
            goodsBarCodeRevnSearchParaWork.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
            // �݌ɋ敪
            goodsBarCodeRevnSearchParaWork.StockDiv = goodsBarCodeRevnSearchPara.StockDiv;
            // �R�[�h(�L��)
            goodsBarCodeRevnSearchParaWork.HaveBarCodeDiv = goodsBarCodeRevnSearchPara.HaveBarCodeDiv;
            // ���i���[�J�[�R�[�h
            goodsBarCodeRevnSearchParaWork.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
            // ���i�ԍ�
            goodsBarCodeRevnSearchParaWork.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
            // �q�ɃR�[�h
            goodsBarCodeRevnSearchParaWork.WarehouseCode = goodsBarCodeRevnSearchPara.WarehouseCode;
            // ���_�R�[�h
            goodsBarCodeRevnSearchParaWork.SectionCode = goodsBarCodeRevnSearchPara.SectionCode;

            return goodsBarCodeRevnSearchParaWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����i���i�o�[�R�[�h�֘A�t�������������[�N�N���X���N���X�j
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchParaWork">���i�o�[�R�[�h�֘A�t�������������[�N�N���X</param>
        /// <returns>���i�o�[�R�[�h�֘A�t�����������N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t�������������[�N�N���X����N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnSearchPara CopyToGoodsBarCodeRevnSearchParaFromSearchParaWork(GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork)
        {
            GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();

            // ��ƃR�[�h
            goodsBarCodeRevnSearchPara.EnterpriseCode = goodsBarCodeRevnSearchParaWork.EnterpriseCode;
            // �݌ɋ敪
            goodsBarCodeRevnSearchPara.StockDiv = goodsBarCodeRevnSearchParaWork.StockDiv;
            // �R�[�h(�L��)
            goodsBarCodeRevnSearchPara.HaveBarCodeDiv = goodsBarCodeRevnSearchParaWork.HaveBarCodeDiv;
            // ���i���[�J�[�R�[�h
            goodsBarCodeRevnSearchPara.GoodsMakerCd = goodsBarCodeRevnSearchParaWork.GoodsMakerCd;
            // ���i�ԍ�
            goodsBarCodeRevnSearchPara.GoodsNo = goodsBarCodeRevnSearchParaWork.GoodsNo;
            // �q�ɃR�[�h
            goodsBarCodeRevnSearchPara.WarehouseCode = goodsBarCodeRevnSearchParaWork.WarehouseCode;
            // ���_�R�[�h
            goodsBarCodeRevnSearchPara.SectionCode = goodsBarCodeRevnSearchParaWork.SectionCode;

            return goodsBarCodeRevnSearchPara;
        }

        #endregion
    }
}

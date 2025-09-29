//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/28  �C�����e : Redmine#23278 ���i�}�X�^��o�^���Ă��Ȃ��ꍇ�A�񋟃f�[�^�̏����i�ԁA�D�Ǖi�Ԃ̖��̂��\������Ȃ��̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>Update Note: 2011/07/28 Redmine#23278 ���i�}�X�^��o�^���Ă��Ȃ��ꍇ�A�񋟃f�[�^�̏����i�ԁA�D�Ǖi�Ԃ̖��̂��\������Ȃ��̑Ή�</br>
    /// </remarks>
    public class CampaignGoodsStAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignGoodsStAcs()
        {
            _campaignGoodsData = new CampaignGoodsData();
            _campaignGoodsDataDel = _campaignGoodsData;
            _campaignGoodsDataTable = new CampaignGoodsDataSet.CampaignGoodsDataTable();

            this._campaignGoodsStDB = MediationCampaignGoodsStDB.GetCampaignGoodsStDB();

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._ownSectionCode, out retMessage);
            // ----- ADD 2011/07/12 ------- <<<<<<<<<
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public static CampaignGoodsStAcs GetInstance()
        {
            if (_campaignGoodsStAcs == null)
            {
                _campaignGoodsStAcs = new CampaignGoodsStAcs();
            }

            return _campaignGoodsStAcs;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static CampaignGoodsStAcs _campaignGoodsStAcs = null;
        private CampaignGoodsData _campaignGoodsData = null;
        private CampaignGoodsData _campaignGoodsDataDel = null;
        private CampaignGoodsDataSet.CampaignGoodsDataTable _campaignGoodsDataTable;
        private ICampaignGoodsStDB _campaignGoodsStDB = null;
        private ArrayList campaignGoodsList = null;
        // ADD 2011/07/28 --- >>>>
        private GoodsAcs _goodsAcs = null;   
        private IWin32Window _owner = null;
        // ��ƃR�[�h
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";
        // ADD 2011/07/28 --- <<<<
        #endregion

        // ===================================================================================== //
        // ����
        // ===================================================================================== //
        # region ��Propertity
        /// <summary>
        /// UI�f�[�^
        /// </summary>
        public CampaignGoodsData CampaignGoodsData
        {
            get { return this._campaignGoodsData; }
        }

        /// <summary>
        /// �e�[�u���v���p�e�B
        /// </summary>
        public CampaignGoodsDataSet.CampaignGoodsDataTable CampaignGoodsDataTable
        {
            get { return _campaignGoodsDataTable; }
        }
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods

        /// <summary>
        /// �����f�[�^�����C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void CreateCampaignGoodsInitialData()
        {
            CampaignGoodsData campaignGoodsData = new CampaignGoodsData();

            // ���_�����l
            campaignGoodsData.SectionCode = "00";
            campaignGoodsData.SectionName = "�S��";
            campaignGoodsData.GoodsMakerCd = 0;
            campaignGoodsData.HeaderGoodsNo = "";

            this.CacheCampaignGoodsData(campaignGoodsData);
        }

        /// <summary>
        /// �����f�[�^�L���b�V������
        /// </summary>
        /// <param name="source">����f�[�^�C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void CacheCampaignGoodsData(CampaignGoodsData source)
        {
            this._campaignGoodsData = source.Clone();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="errMsg">�G���[message</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchData(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // �����f�[�^�N���A
            this._campaignGoodsDataTable.Clear();

            try
            {
                // ��������
                CampaignGoodsDataWork campaignGoodsDataWork = this.CopyToCampaignGoodsDataWorkCampaignGoodsData(this._campaignGoodsData);
                campaignGoodsDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // ��������
                campaignGoodsList = new ArrayList();
                object objCampaignGoodsList = (object)campaignGoodsList;

                status = this._campaignGoodsStDB.Search(campaignGoodsDataWork, ref objCampaignGoodsList);

                campaignGoodsList = objCampaignGoodsList as ArrayList;

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCampaignGoodsList as ArrayList;

                    foreach (CampaignMngStWork work in resultList)
                    {
                        CampaignGoodsDataSet.CampaignGoodsRow row = this._campaignGoodsDataTable.NewCampaignGoodsRow();
                        row = this.CopyToRowFromCampaignMngStWork(work);

                        this._campaignGoodsDataTable.AddCampaignGoodsRow(row);
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
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int DeleteData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            this._campaignGoodsDataDel = this._campaignGoodsData.Clone();
            // �����N���A
            this._campaignGoodsDataDel.GoodsStCount = 0;
            this._campaignGoodsDataDel.NameStCount = 0;
            this._campaignGoodsDataDel.CustomStCount = 0;
            this._campaignGoodsDataDel.TargetStCount = 0;

            try
            {
                // �폜����
                CampaignGoodsDataWork campaignGoodsDataWork = this.CopyToCampaignGoodsDataWorkCampaignGoodsData(this._campaignGoodsDataDel);
               
                campaignGoodsDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                ArrayList objDeleteList = new ArrayList();
                objDeleteList.Add(campaignGoodsDataWork);
                object objDeletePara = (object)objDeleteList;

                status = this._campaignGoodsStDB.DeleteAll(this.campaignGoodsList, ref objDeletePara);

                // ����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (objDeletePara != null)
                    {
                        ArrayList deleteParaList = objDeletePara as ArrayList;
                        CampaignGoodsDataWork campaignGoodsDataWorkRes = new CampaignGoodsDataWork();
                        if (deleteParaList != null && deleteParaList.Count > 0)
                        {
                            campaignGoodsDataWorkRes = (CampaignGoodsDataWork)deleteParaList[0];
                            this._campaignGoodsDataDel.GoodsStCount = campaignGoodsDataWorkRes.GoodsStCount;
                            this._campaignGoodsDataDel.NameStCount = campaignGoodsDataWorkRes.NameStCount;
                            this._campaignGoodsDataDel.CustomStCount = campaignGoodsDataWorkRes.CustomStCount;
                            this._campaignGoodsDataDel.TargetStCount = campaignGoodsDataWorkRes.TargetStCount;

                            this._campaignGoodsData = this._campaignGoodsDataDel.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }

                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ǘ��N���X�˃L�����y�[���Ǘ����[�N�N���X�j
        /// </summary>
        /// <param name="campaignGoodsData">�L�����y�[���Ǘ��N���X</param>
        /// <returns>CampaignGoodsDataWork</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��N���X����L�����y�[���Ǘ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignGoodsDataWork CopyToCampaignGoodsDataWorkCampaignGoodsData(CampaignGoodsData campaignGoodsData)
        {
            CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();

            campaignGoodsDataWork.SectionCode = campaignGoodsData.SectionCode;
            campaignGoodsDataWork.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            campaignGoodsDataWork.HeaderGoodsNo = campaignGoodsData.HeaderGoodsNo;

            return campaignGoodsDataWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ǘ��}�X�^���[�N�N���X�˃L�����y�[���Ǘ��}�X�^Row�j
        /// </summary>
        /// <param name="campaignMngStWork">�L�����y�[���Ǘ��}�X�^���[�N�N���X</param>
        /// <returns>�L�����y�[���Ǘ��}�X�^Row</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���[�N�N���X����L�����y�[���Ǘ��}�X�^Row�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>Update Note: 2011/07/28 Redmine#23278 ���i�}�X�^��o�^���Ă��Ȃ��ꍇ�A�񋟃f�[�^�̏����i�ԁA�D�Ǖi�Ԃ̖��̂��\������Ȃ��̑Ή�</br>
        /// </remarks>
        private CampaignGoodsDataSet.CampaignGoodsRow CopyToRowFromCampaignMngStWork(CampaignMngStWork campaignMngStWork)
        {
            CampaignGoodsDataSet.CampaignGoodsRow row = this._campaignGoodsDataTable.NewCampaignGoodsRow();

            if (campaignMngStWork.CampaignCode == 0)
            {
                row.CampaignCode = string.Empty;
            }
            else
            {
                row.CampaignCode = campaignMngStWork.CampaignCode.ToString("000000");
            }
            row.CampaignName = this.SubStringLength(campaignMngStWork.CampaignName, 20);
            if (campaignMngStWork.SectionCode.Trim() == "00")
            {
                row.SectionCode = "00";
                row.SectionName = "�S��";
            }
            else
            {
                row.SectionCode = campaignMngStWork.SectionCode.Trim();
                row.SectionName = this.SubStringLength(campaignMngStWork.SectionName, 10);
            }
            string kindName = string.Empty;
            switch(campaignMngStWork.CampaignSettingKind)
            {
                case 1:
                    kindName = "Ұ��+�i��";
                    break;
                case 2:
                    kindName = "Ұ��+BL����";
                    break;
                case 3:
                    kindName = "Ұ��+��ٰ��";
                    break;
                case 4:
                    kindName = "Ұ��";
                    break;
                case 5:
                    kindName = "BL����";
                    break;
                case 6:
                    kindName = "�̔��敪";
                    break;
            }
            row.CampaignSettingKind = campaignMngStWork.CampaignSettingKind;
            row.CampaignSettingKindNm = kindName;
            row.GoodsMakerCd = campaignMngStWork.GoodsMakerCd;
            row.GoodsMakerNm = this.SubStringLength(campaignMngStWork.GoodsMakerNm, 10);
            row.GoodsNo = this.SubStringLength(campaignMngStWork.GoodsNo, 24);

            // ----- ADD 2011/07/28 ------- >>>>>>>
            if (string.IsNullOrEmpty(campaignMngStWork.GoodsName))
            {
                List<GoodsUnitData> goodsUnitDataList;
                PartsInfoDataSet partsInfoDataSet;
                string msg = string.Empty;

                // ���o�����̍쐬
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.GoodsMakerCd = campaignMngStWork.GoodsMakerCd;
                goodsCndtn.GoodsNo = campaignMngStWork.GoodsNo;
                goodsCndtn.IsSettingSupplier = 1;

                this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (goodsUnitData.LogicalDeleteCode == 0)
                    {
                        // ���i����
                        row.GoodsName = this.SubStringLength(goodsUnitData.GoodsName, 40);
                    }
                }
            }
            else
            {
                // ���i����
                row.GoodsName = this.SubStringLength(campaignMngStWork.GoodsName, 40);
            }
            // ----- ADD 2011/07/28 ------- <<<<<<<<<

            // row.GoodsName = this.SubStringLength(campaignMngStWork.GoodsName, 40);  // -DEL 2011/07/28

            if (campaignMngStWork.CustomerCode == 0)
            {
                row.CustomerCode = string.Empty;
            }
            else
            {
                row.CustomerCode = campaignMngStWork.CustomerCode.ToString("00000000");
            }
            row.CustomerName = this.SubStringLength(campaignMngStWork.CustomerName, 10);
            row.DiscountRate = campaignMngStWork.DiscountRate;
            row.RateVal = campaignMngStWork.RateVal;
            row.PriceFl = campaignMngStWork.PriceFl;
            row.PriceStartDate = this.IntToDateTimeStr(campaignMngStWork.PriceStartDate);
            row.PriceEndDate = this.IntToDateTimeStr(campaignMngStWork.PriceEndDate);
            // �����敪==0:����
            if (campaignMngStWork.SalesPriceSetDiv == 0)
            {
                row.CustomerCode = string.Empty;
                row.CustomerName = string.Empty;
                row.DiscountRate = 0;
                row.RateVal = 0;
                row.PriceFl = 0;
                row.PriceStartDate = string.Empty;
                row.PriceEndDate = string.Empty;
            }
            return row;
        }
        #endregion

        # region �� �Z���l�ϊ�
        /// <summary>
        /// �\�����ڂ̌��̏���
        /// </summary>
        /// <param name="str">����</param>
        /// <param name="length">��</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : �\�����ڂ̌��̏������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string SubStringLength(string str, int length)
        {
            string subStr = str;

            if (str.Length > length)
            {
                subStr = str.Substring(0, length);
            }

            return subStr;
        }

        /// <summary>
        /// Conver int to string(YYYY/MM/DD)
        /// </summary>
        /// <param name="intDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Conver int to string�̏������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string IntToDateTimeStr(int intDate)
        {
            if (intDate == 0)
            {
                return string.Empty;
            }
            string strDate = intDate.ToString();
            strDate = strDate.Insert(4, "-");
            strDate = strDate.Insert(7, "-");
            DateTime date = Convert.ToDateTime(strDate);

            return date.ToShortDateString();
        }
        # endregion
    }
}

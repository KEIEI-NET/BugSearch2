//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M����A�N�Z�X�N���X
// �v���O�����T�v   : �z���_�t�n�d �v�d�a e-Parts�������䏈��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e :�y�v��No.2�z																																							
//	                                ������Ƀg���^���w�莞�ɂ́A���}�[�N�Q�̓��͕͂s�Ƃ���i�A�g���A�ϰ�2�ɘA�g�ԍ��Ƃ��Ďg�p����ׁj																																							
//	                                �d�����ׁi�����f�[�^�j�̍쐬���s���ʐM�͍s��Ȃ��l�ɂ���																																							
//                       �C�����e :�y�v��No.3�z
//                                  ������̓��͐���i�g���^�͓��͕s�Ƃ���j���s��
//                                  �g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/11/08  �C�����e : �z���_�t�n�d �v�d�a e-Parts��������̑Ώ۔�����C���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �A����  2013/03/13�z�M��
// �� �� ��  2013/01/31  �C�����e : Redmine#33991  �`�[�ԍ��������� �d���f�[�^�̎d����R�[�h�̐ݒ�s���̑Ή�                               
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// �t�n�d����M����A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �z���_�t�n�d �v�d�a e-Parts�������䏈��</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// <br>Update Note  : 2009/12/29 xuxh</br>
    /// <br>              �E�y�v��No.2�z�Ɓy�v��No.3�z�̏C��</br>
    /// <br>Update Note  : 2010/11/08 22018 ��� ���b</br>
    /// <br>              �E�z���_�t�n�d �v�d�a e-Parts��������̑Ώ۔�����C���B</br>
    /// </remarks>
	public partial class UoeSndRcvCtlAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region �� �z���_�t�n�d �v�d�a e-Parts�������䏈��
        /// <summary>
        /// �z���_�t�n�d �v�d�a e-Parts�������䏈��
        /// </summary>
        /// <param name="list">����ꗗ�f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : 96186 ���� �T��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public int EpartsUoeWebBuyCtl(ref List<BuyOutLsthead> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                // ����ꗗ�f�[�^���X�g�̕ۑ�
                List<BuyOutLsthead> retBuyOutLsthead = new List<BuyOutLsthead>();

                foreach (BuyOutLsthead hed in list)
                {
                    // �t�n�d����M���䏉����
                    if ((status = UoeSndRcvCtlInit(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        break;
                    }

                    //�z���_�t�n�d �v�d�a e-Parts�񓚍X�V���䃁�C��
                    BuyOutLsthead buyOutLsthead = hed.Clone();

                    //����ꗗ����
                    if (buyOutLsthead.CsvKnd == 0)
                    {
                        if ((status = EpartsUoeWebBuyCtlProc(ref buyOutLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //�F���s���`��
                    else
                    {
                        continue;
                    }

                    retBuyOutLsthead.Add(buyOutLsthead);
                }


                //�ߒl��ݒ�
                list = retBuyOutLsthead;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion
        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �� �z���_�t�n�d �v�d�a e-Parts��������
        # region �� �z���_�t�n�d �v�d�a e-Parts�������䃁�C��
        /// <summary>
        /// �z���_�t�n�d �v�d�a e-Parts�������䃁�C��
        /// </summary>
        /// <param name="list">����ꗗ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : 96186 ���� �T��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        private int EpartsUoeWebBuyCtlProc(ref BuyOutLsthead hed, out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // ���ʃN���X�̏�����
                //-----------------------------------------------------------
                # region ���ʃN���X�̏�����
                # region ����ꗗ���׃N���X
                // ���㔃��ꗗ���׃N���X
                ArrayList lstDtl = hed.LstDtl;
                if (lstDtl == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                if (lstDtl.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # region ����ꗗ���׃f�[�^�e�[�u��Row�쐬
                //����ꗗ���׃f�[�^�e�[�u��Row�쐬
                if ((status = _uoeSndRcvJnlAcs.buyOutLstDtlFromDtlWrite(lstDtl, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # region �u��������+�������`�[�ԍ��v�E�u�����+���㎞�`�[�ԍ��v�l���Z�o
                //���㎞�`�[�ԍ�Dictionary
                Dictionary<string, BuyOutLstDtl> buyOutDictionary = new Dictionary<string, BuyOutLstDtl>();

                //�������`�[�ԍ�Dictionary
                Dictionary<string, BuyOutLstDtl> orderDictionary = new Dictionary<string, BuyOutLstDtl>();

                // �u�����`�[�ԍ��v�l���Z�o
                foreach (BuyOutLstDtl dtl in lstDtl)
                {
                    //���㎞�`�[�ԍ�(9999999999)
                    string buyOutKey = dtl.BuyOutSlipNo.Trim();
                    if (buyOutDictionary.ContainsKey(buyOutKey) != true)
                    {
                        buyOutDictionary.Add(buyOutKey, dtl);
                    }

                    //�������`�[�ԍ�(999999)
                    string orderKey = dtl.OrderSlipNo.Trim();
                    if (orderDictionary.ContainsKey(orderKey) != true)
                    {
                        orderDictionary.Add(orderKey, dtl);
                    }
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // ����R�[�h�̎擾
                //-----------------------------------------------------------
                # region ����R�[�h�̎擾
                int subSectionCode = 0;
                EmployeeDtl employeeDtl = GetEmployeeDtl(hed.EnterpriseCode, _employeeCode);
                if (employeeDtl != null)
                {
                    subSectionCode = employeeDtl.BelongSubSectionCode;
                }
                # endregion

                //-----------------------------------------------------------
                // �t�n�d������}�X�^�̎擾
                //-----------------------------------------------------------
                # region �t�n�d������}�X�^�̎擾
                UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(hed.UOESupplierCd);
                if (uOESupplier == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                // --- UPD m.suzuki 2010/11/08 ---------->>>>>
                ////if (uOESupplier.CommAssemblyId.Trim() != "0502") // DEL 2009/12/29 xuxh
                //if (!CanSendAndReceive(uOESupplier)) // ADD 2009/12/29 xuxh
                if ( uOESupplier.CommAssemblyId.Trim() != EnumUoeConst.ctCommAssemblyId_0502 )
                // --- UPD m.suzuki 2010/11/08 ----------<<<<<
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �d������̎擾
                //-----------------------------------------------------------
                #region �d������̐ݒ�
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(uOESupplier.SupplierCd);
                if (supplier == null)
                {
                    return (-1);
                }
                #endregion
                
                //-----------------------------------------------------------
                // �d���f�[�^�̓Ǎ��i�����[�g�������s�j
                //-----------------------------------------------------------
                # region �d���f�[�^�̓Ǎ��i�����[�g�������s�j
                # region �������o�N���X�̍쐬
                //�������`�[�ԍ�Dictionary
                Dictionary<string, StockSlipWork> stockSlipInfoDictionary = new Dictionary<string, StockSlipWork>();

                # region ���㎞�����`�[�ԍ�
                //���㎞�����`�[�ԍ�
                foreach (string key in buyOutDictionary.Keys)
                {
                    BuyOutLstDtl dtl = buyOutDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    stockSlipWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //�d����R�[�h
                    stockSlipWork.SupplierFormal = 0;                   //0:�d��
                    stockSlipWork.StockDate = DateTime.MinValue;        //�d����
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //���ד�
                    stockSlipWork.PartySaleSlipNum = dtl.BuyOutSlipNo.Trim(); //�����`�[�ԍ�

                    //�i�[����
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region ���㎞�����`�[�ԍ� + �u-F�v
                //���㎞�����`�[�ԍ� + �u-F�v
                foreach (string key in buyOutDictionary.Keys)
                {
                    BuyOutLstDtl dtl = buyOutDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    stockSlipWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //�d����R�[�h
                    stockSlipWork.SupplierFormal = 0;                   //0:�d��
                    stockSlipWork.StockDate = DateTime.MinValue;        //�d����
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //���ד�
                    stockSlipWork.PartySaleSlipNum = dtl.BuyOutSlipNo.Trim() + "-F"; //�����`�[�ԍ�

                    //�i�[����
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region �����������`�[�ԍ�
                //�����������`�[�ԍ�
                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    stockSlipWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //�d����R�[�h
                    stockSlipWork.SupplierFormal = 0;                   //0:�d��
                    stockSlipWork.StockDate = DateTime.MinValue;        //�d����
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //���ד�
                    stockSlipWork.PartySaleSlipNum = dtl.OrderSlipNo.Trim(); //�����`�[�ԍ�

                    //�i�[����
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region �����������`�[�ԍ� + �u-F�v
                //�����������`�[�ԍ� + �u-F�v
                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    stockSlipWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //�d����R�[�h
                    stockSlipWork.SupplierFormal = 0;                   //0:�d��
                    stockSlipWork.StockDate = DateTime.MinValue;        //�d����
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //���ד�
                    stockSlipWork.PartySaleSlipNum = dtl.OrderSlipNo.Trim() + "-F"; //�����`�[�ԍ�

                    //�i�[����
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region �������o�N���X�̍쐬
                //�������o�N���X�̍쐬
                ArrayList stockSlipWorkAry = new ArrayList();

                foreach (string key in stockSlipInfoDictionary.Keys)
                {
                    StockSlipWork stockSlipWork = stockSlipInfoDictionary[key];
                    stockSlipWorkAry.Add(stockSlipWork);
                }
                # endregion
                # endregion

                # region ���o�����[�g�����̎��s
                //���o�����[�g�����̎��s
                List<StockSlipWork> stockSlipWorkList = null;  //�d�����[�N���X�g
                List<StockDetailWork> stockDetailWorkList = null;  //�d�����׃��[�N���X�g

                status = _uoeOrderInfoAcs.StockSlipPartySaleSlipNumReadAll(
                            stockSlipWorkAry,
			                out stockSlipWorkList,
			                out stockDetailWorkList,
			                out message);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "";
                }
                else
                {
                    return (status);
                }

                # endregion

                # region �d���f�[�^Dictionary�̃L���b�V������
                //�d���f�[�^Dictionary�̃L���b�V������
                Dictionary<string, StockSlipWork> stockSlipWorkDictionary = new Dictionary<string, StockSlipWork>();

                if (stockSlipWorkList != null)
                {
                    foreach (StockSlipWork stockSlipWork in stockSlipWorkList)
                    {
                        // �d���f�[�^Dictionary�̒ǉ�
                        //�����`�[�ԍ�
                        string key = stockSlipWork.PartySaleSlipNum.Trim();
                        if (stockSlipWorkDictionary.ContainsKey(key) != true)
                        {
                            stockSlipWorkDictionary.Add(key, stockSlipWork);
                        }
                    }
                }

                # endregion
                # endregion

                //-----------------------------------------------------------
                // UOE�����f�[�^�̓Ǎ��i�����[�g�������s�j
                //-----------------------------------------------------------
                # region UOE�����f�[�^�̓Ǎ��i�����[�g�������s�j
                # region �������o�N���X�̍쐬
                //�����������`�[�ԍ�
                //�������`�[�ԍ�Dictionary
                Dictionary<string, UOEStockUpdSearchWork> uOEStockUpdSearchDictionary = new Dictionary<string, UOEStockUpdSearchWork>();

                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    UOEStockUpdSearchWork uOEStockUpdSearchWork = new UOEStockUpdSearchWork();

                    uOEStockUpdSearchWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    uOEStockUpdSearchWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    uOEStockUpdSearchWork.UOESupplierCd = hed.UOESupplierCd;
                    uOEStockUpdSearchWork.SlipNo = dtl.OrderSlipNo.Trim();      //�����`�[�ԍ�

                    //�i�[����
                    string slipNoKey = uOEStockUpdSearchWork.SlipNo;
                    if (uOEStockUpdSearchDictionary.ContainsKey(slipNoKey) != true)
                    {
                        uOEStockUpdSearchDictionary.Add(slipNoKey, uOEStockUpdSearchWork);
                    }
                }

                # region �������o�N���X�̍쐬
                //�������o�N���X�̍쐬
                ArrayList paraAry = new ArrayList();

                foreach (string key in uOEStockUpdSearchDictionary.Keys)
                {
                    UOEStockUpdSearchWork uOEStockUpdSearchWork = uOEStockUpdSearchDictionary[key];
                    paraAry.Add(uOEStockUpdSearchWork);
                }
                # endregion

                # endregion
                
                # region ���o�����[�g�����̎��s
                //���o�����[�g�����̎��s
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;

                status = _uoeOrderInfoAcs.SearchAllPartySlip(
                            paraAry,
                            out uOEOrderDtlWorkList,
                            out message);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "";
                }
                else
                {
                    return (status);
                }
                # endregion

                # region UOE�����f�[�^Dictionary�̃L���b�V������
                //UOE�����f�[�^Dictionary�̃L���b�V������
                Dictionary<string, string> uOEOrderDtlSlipDictionary = new Dictionary<string, string>();

                if (uOEOrderDtlWorkList != null)
                {
                    foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
                    {
                        for(int i=0; i<4; i++)
                        {
                            //�����`�[�ԍ�
                            string key = String.Empty;
                            switch (i)
                            {
                                case 0:
                                    key = uOEOrderDtlWork.UOESectionSlipNo.Trim();
                                    break;
                                case 1:
                                    key = uOEOrderDtlWork.BOSlipNo1.Trim();
                                    break;
                                case 2:
                                    key = uOEOrderDtlWork.BOSlipNo2.Trim();
                                    break;
                                case 3:
                                    key = uOEOrderDtlWork.BOSlipNo3.Trim();
                                    break;
                            }

                            // UOE�����f�[�^Dictionary�̒ǉ�
                            if (key.Trim() == String.Empty) continue;
                            if (uOEOrderDtlSlipDictionary.ContainsKey(key) == true) continue;
                            uOEOrderDtlSlipDictionary.Add(key, key);
                        }
                    }
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // �f�[�^�e�[�u���ւ̊i�[����
                //-----------------------------------------------------------
                # region �f�[�^�e�[�u���ւ̊i�[����
                # region �d�����ׁ��d�����׃e�[�u���̍쐬
                //�d�����ׁ��d�����׃e�[�u���̍쐬
                if (stockDetailWorkList != null)
                {
                    foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                    {
                        stockDetailWork.DtlRelationGuid = Guid.NewGuid();

                        status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(StockDetailTable, stockDetailWork, "", 0, out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion

                # region �d�����d���e�[�u���̍쐬
                //�d�����d���e�[�u���̍쐬
                if (stockSlipWorkList != null)
                {
                    foreach (StockSlipWork stockSlipWork in stockSlipWorkList)
                    {
                        status = _uoeSndRcvJnlAcs.InsertTableFromStockSlipWork(StockSlipTable, stockSlipWork, stockSlipWork.SupplierSlipNo.ToString("d9"), out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return (status);
                        }
                    }
                }

                # endregion
                # endregion

                //�d�����̒ǉ��E�X�V�p�p�����[�^��`
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

                foreach (string buyOutKey in buyOutDictionary.Keys)
                {
                    //-----------------------------------------------------------
                    // ��������
                    //-----------------------------------------------------------
                    # region ��������
                    BuyOutLstDtl dtl = buyOutDictionary[buyOutKey];
                    string orderKey = dtl.OrderSlipNo.Trim();
                    # endregion

                    //-----------------------------------------------------------
                    // �x����R�[�h�ɂĎd�������y�юd�������̒����`�F�b�N
                    //-----------------------------------------------------------
                    # region �x����R�[�h�ɂĎd�������y�юd�������̒����`�F�b�N
                    if ((supplier.PaymentSectionCode.Trim() != "") && (supplier.PayeeCode != 0))
                    {
                        //�d�������̒����`�F�b�N
                        if (_totalDayCalculator.CheckPayment(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.BuyOutDate) != false)
                        {
                            DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                            SetUpdRslFromEpartsBuy(view, 4);    //4:�����X�V������
                            continue;
                        }
                        //�d�������̒����`�F�b�N
                        else if (_totalDayCalculator.CheckMonthlyAccPay(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.BuyOutDate) != false)
                        {
                            DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                            SetUpdRslFromEpartsBuy(view, 5);    //5:�����X�V������
                            continue;
                        }
                    }
                    # endregion
                        
                    //-----------------------------------------------------------
                    // �t�n�d�������������_�o�ו��̎d�����X�V����
                    //-----------------------------------------------------------
                    # region �t�n�d�������������_�o�ו��̎d�����X�V����
                    if (stockSlipWorkDictionary.ContainsKey(orderKey) == true)
                    {
                        List<StockSlipGrp> list = EpartsUoeWebBuyUpdate(
                                    hed,
                                    dtl.OrderSlipNo,     //�����`�[�ԍ�
                                    supplier);

                        if (list == null) continue;
                        if (list.Count == 0) continue;
                        foreach (StockSlipGrp stockSlipGrp in list)
                        {
                            stockSlipGrpList.Add(stockSlipGrp);
                        }

                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �a�n�o�ו��̎d�����X�V����
                    //-----------------------------------------------------------
                    # region �a�n�o�ו��̎d�����X�V����
                    else if (stockSlipWorkDictionary.ContainsKey(orderKey + "-F") == true)
                    {
                        List<StockSlipGrp> list = EpartsUoeWebBuyUpdate(
                                    hed,
                                    dtl.OrderSlipNo + "-F",     //�����`�[�ԍ�
                                    supplier);

                        if (list == null) continue;
                        if (list.Count == 0) continue;
                        foreach (StockSlipGrp stockSlipGrp in list)
                        {
                            stockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �����ς̔���i�`�a�n�q�s�j
                    //-----------------------------------------------------------
                    # region �����ς̔���i�`�a�n�q�s�j
                    else if (stockSlipWorkDictionary.ContainsKey(buyOutKey) == true)
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                        SetUpdRslFromEpartsBuy(view, 9);    //9:������
                    }
                    else if (stockSlipWorkDictionary.ContainsKey(buyOutKey + "-F") == true)
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo + "-F");
                        SetUpdRslFromEpartsBuy(view, 9);    //9:������
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �d�����̐V�K�쐬
                    //-----------------------------------------------------------
                    # region �d�����̐V�K�쐬
                    else if (hed.StcCreDiv == 1)
                    {
                        if (uOEOrderDtlSlipDictionary.ContainsKey(orderKey) == true)    continue;

                        StockSlipGrp stockSlipGrp = EpartsUoeWebBuyInsert(
                                    hed,
                                    dtl,                    // ����ꗗ���׃I�u�W�F�N�g
                                    subSectionCode,         // ����R�[�h
                                    supplier,               // �d����I�u�W�F�N�g
                                    uOESupplier);           // UOE������I�u�W�F�N�g

                        if (stockSlipGrp == null) continue;
                        stockSlipGrpList.Add(stockSlipGrp);
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �Y���Ȃ��̔���i�`�a�n�q�s�j
                    //-----------------------------------------------------------
                    # region �Y���Ȃ��̔���i�`�a�n�q�s�j
                    else
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(1, dtl.OrderSlipNo);
                        SetUpdRslFromEpartsBuy(view, 2);    //2:�Y���Ȃ�
                    }
                    # endregion
                }

                //-----------------------------------------------------------
                // �d�����̍X�V�����i�����[�g�������s�j
                //-----------------------------------------------------------
                # region �d�����̍X�V�����i�����[�g�������s�j
                if ((stockSlipGrpList == null) || (stockSlipGrpList.Count == 0))
                {
                    hed.UpdRsl = 0;
                }
                else
                {
                    status = _uOEAnswerAcs.WriteStockInfo(stockSlipGrpList, out message);
                    status = (int)EnumUoeConst.Status.ct_NORMAL;

                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        hed.UpdRsl = -1;
                        return (status);
                    }
                }
                # endregion

                //-----------------------------------------------------------
                // �߂�l�̐ݒ�
                //-----------------------------------------------------------
                # region �߂�l�̐ݒ�
                // ����ꗗ���ו����X�V���ʁ��̐ݒ�
                DataView viewUpdRsl = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0);
                SetUpdRslFromEpartsBuy(viewUpdRsl, 2);    //2:�Y���Ȃ�

                ArrayList dtlList = GetBuyOutDtlListForDataTable();

                //�߂�l�̐ݒ�
                if (dtlList == null)
                {
                    hed.UpdRsl = -1;//-1:�G���[
                }
                else
                {
                    hed.LstDtl = dtlList;
                    hed.UpdRsl = 0;//0:����I��
                }
                # endregion
            }
            catch (Exception ex)
            {
                hed.UpdRsl = -1;
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region �� ����ꗗ���׃f�[�^(ArrayList)�擾
        /// <summary>
        /// �� ����ꗗ���׃f�[�^(ArrayList)�擾
        /// </summary>
        /// <returns>����ꗗ���׃f�[�^</returns>
        private ArrayList GetBuyOutDtlListForDataTable()
        {
            ArrayList list = new ArrayList();

            try
            {
                DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView();

                foreach (DataRowView dataRowView in view)
                {
                    BuyOutLstDtl dtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(dataRowView.Row);
                    list.Add(dtl);
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return (list);
        }
        # endregion

        # region �� ����ꗗView�̍X�V���ʂ�ݒ�
        /// <summary>
        /// �� ����ꗗView�̍X�V���ʂ�ݒ�
        /// </summary>
        /// <param name="dv">����ꗗView</param>
        /// <param name="updRsl">�X�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SetUpdRslFromEpartsBuy(DataView view, Int32 updRsl)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;

            try
            {
                if (view.Count == 0) return (status);

                foreach (DataRowView dataRowView in view)
                {
                    dataRowView[BuyOutLstDtlSchema.ct_Col_UpdRsl] = updRsl;
                }
            }
            catch (Exception)
            {
                status = -1;
            }
            return (status);
        }
        # endregion

        # region �� ���V�K�p���z���_�t�n�d �v�d�a e-Parts �����V�K�쐬
        /// <summary>
        /// �� �z���_�t�n�d �v�d�a e-Parts �����V�K�쐬
        /// </summary>
        /// <param name="hed">����ꗗ�f�[�^�I�u�W�F�N�g</param>
        /// <param name="dtl">����ꗗ���׃I�u�W�F�N�g</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private StockSlipGrp EpartsUoeWebBuyInsert(BuyOutLsthead hed, BuyOutLstDtl dtl, Int32 subSectionCode, Supplier supplier, UOESupplier uOESupplier)
        {
            //�ϐ��̏�����
            StockSlipGrp stockSlipGrp = null;

            try
            {
                //-----------------------------------------------------------
                // �X�V�Ώۂ̔���ꗗ�N���X�̒��o
                //-----------------------------------------------------------
                # region �X�V�Ώۂ̔���ꗗ�N���X�̒��o
                DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                if (view.Count == 0) return (stockSlipGrp);

                List<BuyOutLstDtl> buyDtlList = new List<BuyOutLstDtl>();
                foreach (DataRowView dataRowView in view)
                {
                    BuyOutLstDtl buyDtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(dataRowView.Row);
                    buyDtlList.Add(buyDtl);

                    // ����ꗗ���׃f�[�^�e�[�u���u�X�V���ʁE�������P���v��ݒ�
                    dataRowView[BuyOutLstDtlSchema.ct_Col_OrderCost] = buyDtl.BuyOutCost;
                    dataRowView[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 6;  //6:�d���f�[�^�쐬
                }
                # endregion

                //-----------------------------------------------------------
                // �d�����׃f�[�^�̎擾�i����ꗗ�j
                //-----------------------------------------------------------
                # region �d�����׃f�[�^�̎擾�i����ꗗ�j
                List<StockDetailWork> stockDetailWorkList = GetStockDetailFromEpartsBuyInsert(
                                                                hed,
                                                                subSectionCode, //����R�[�h
                                                                buyDtlList,     //����ꗗ�f�[�^�N���X
                                                                supplier,       //�d�����I�u�W�F�N�g
                                                                uOESupplier);   //UOE�������I�u�W�F�N�g
                if (stockDetailWorkList == null) return (stockSlipGrp);
                if (stockDetailWorkList.Count == 0) return (stockSlipGrp);
                # endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̎擾
                //-----------------------------------------------------------
                #region �d���f�[�^�̎擾
                StockSlipWork stockSlipWork = GetstockSlipFromEpartsBuyInsert(
                                                                hed.EnterpriseCode, //��ƃR�[�h
                                                                hed.SectionCode,    //���_�R�[�h
                                                                subSectionCode,     //����R�[�h
                                                                buyDtlList,         //����ꗗ�f�[�^�N���X
                                                                stockDetailWorkList,//�d�����׃I�u�W�F�N�g
                                                                supplier);          //�d�����I�u�W�F�N�g
                if(stockSlipWork == null)   return (stockSlipGrp);
                #endregion

                //-----------------------------------------------------------
                // �d�����I�u�W�F�N�g�̎擾
                //-----------------------------------------------------------
                # region �d�����I�u�W�F�N�g�̍쐬
                stockSlipGrp = new StockSlipGrp();
                stockSlipGrp.stockSlipWork = stockSlipWork;
                stockSlipGrp.stockDetailWorkList = stockDetailWorkList;
                # endregion
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                stockSlipGrp = null;
            }

            return (stockSlipGrp);
        }
        # endregion

        # region �� ���V�K�p���d���f�[�^�̎擾�i����ꗗ�j
        /// <summary>
        /// �d���f�[�^�̎擾�i����ꗗ�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="list">�����ꗗ����(�����)�f�[�^�N���X</param>
        /// <param name="list">�d�����׃I�u�W�F�N�g</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private StockSlipWork GetstockSlipFromEpartsBuyInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<BuyOutLstDtl> list, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //�ϐ��̏�����
            StockSlipWork stockSlipWork = null;
            try
            {
                //-----------------------------------------------------------
                // ����ꗗ���ׂ̎擾
                //-----------------------------------------------------------
                BuyOutLstDtl buyOutLstDtl = list[0];

                //-----------------------------------------------------------
                // �d���f�[�^�̐ݒ�
                //-----------------------------------------------------------
                stockSlipWork = GetStockSlipFromEpartsInsert(
                                    enterpriseCode,             //��ƃR�[�h
                                    sectionCode,                //���_�R�[�h
                                    subSectionCode,             //����R�[�h
                                    buyOutLstDtl.BuyOutDate,    //�d�����t
                                    buyOutLstDtl.BuyOutSlipNo,  //�����`�[�ԍ�
                                    stockDetailWorkList,        //�d�����׃I�u�W�F�N�g
                                    supplier);                  //�d�����I�u�W�F�N�g
            }
            catch (Exception)
            {
                stockSlipWork = null;
            }
            return (stockSlipWork);
        }
        # endregion

        # region �� ���V�K�p���d�����׃f�[�^�̎擾�i����ꗗ�j
        /// <summary>
        /// �d�����׃f�[�^�̎擾�i����ꗗ�j
        /// </summary>
        /// <param name="hed">����ꗗ�f�[�^�I�u�W�F�N�g</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="list">����ꗗ�f�[�^�N���X</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>�d�����׃I�u�W�F�N�g</returns>
        private List<StockDetailWork> GetStockDetailFromEpartsBuyInsert(BuyOutLsthead hed, Int32 subSectionCode, List<BuyOutLstDtl> list, Supplier supplier, UOESupplier uOESupplier)
        {
            //�ϐ��̏�����
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
            try
            {
                int stockRowNo = 1; //�d���s�ԍ�

                foreach (BuyOutLstDtl dtl in list)
                {
                    StockDetailWork stockDetailWork = GetStockDetailWorkFromEpartsInsert(
                                                            hed.EnterpriseCode,     //��ƃR�[�h
                                                            hed.SectionCode,        //���_�R�[�h
                                                            subSectionCode,         //����R�[�h
                                                            stockRowNo,             //�d���s�ԍ�
                                                            dtl.GoodsNo,            //�i��
                                                            dtl.GoodsName,          //�i��
                                                            dtl.ShipmentCnt,        //����
                                                            dtl.AnswerListPrice,    //�艿
                                                            dtl.BuyOutCost,         //�P��
                                                            hed.StockAgentCode,     //�S���҃R�[�h
                                                            hed.StockAgentName,     //�S���Җ�
                                                            supplier,               //�d�����I�u�W�F�N�g
                                                            uOESupplier);           //UOE�������I�u�W�F�N�g
                    if (stockDetailWork == null)
                    {
                        stockDetailWorkList = null;
                        break;
                    }

                    stockDetailWorkList.Add(stockDetailWork);
                    stockRowNo++;
                }
            }
            catch (Exception)
            {
                stockDetailWorkList = null;
            }
            return (stockDetailWorkList);
        }
        # endregion

        # region �� ���X�V�p���z���_�t�n�d �v�d�a e-Parts �����X�V����
        /// <summary>
        /// �� ���X�V�p���z���_�t�n�d �v�d�a e-Parts �����X�V����
        /// </summary>
        /// <param name="hed">����ꗗ�f�[�^�I�u�W�F�N�g</param>
        /// <param name="orderSlipNo">�������`�[�ԍ�</param>
        /// <param name="supplier">�d�����I�u�W�F�N�g</param>
        /// <returns></returns>
        private List<StockSlipGrp> EpartsUoeWebBuyUpdate(BuyOutLsthead hed, string orderSlipNo, Supplier supplier)
        {
            //�ϐ��̏�����
            List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //-----------------------------------------------------------
                // �d���`�[�ԍ��̎Z�o
                //-----------------------------------------------------------
                # region �d���`�[�ԍ��̎Z�o
                DataView viewStockSlip = new DataView(this.StockSlipTable);

                // �t�B���^�ݒ�
                string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                StockSlipSchema.ct_Col_SupplierFormal, 0,
                                                StockSlipSchema.ct_Col_PartySaleSlipNum, orderSlipNo
                                                );
                // �\�[�g���ݒ�
                string sortText = string.Format("{0}",
                                                StockSlipSchema.ct_Col_SupplierSlipNo
                                                );
                viewStockSlip.RowFilter = rowFilterText;
                viewStockSlip.Sort = sortText;

                if (viewStockSlip == null) return (stockSlipGrpList);
                if (viewStockSlip.Count == 0) return (stockSlipGrpList);
                # endregion

                foreach (DataRowView dataRowViewStockSlip in viewStockSlip)
                {
                    //�d���f�[�^�̎擾
                    StockSlipWork stockSlipWork = _uoeSndRcvJnlAcs.CreateStockSlipWorkFromSchema(dataRowViewStockSlip.Row);

                    //-----------------------------------------------------------
                    // �d�����׃f�[�^�̎擾
                    //-----------------------------------------------------------
                    # region �d�����׃f�[�^�̎擾
                    # region �d�����ׂ̎擾���d���`�[�ԍ��E�i�ԁE���ʁ�
                    //�d�����ׂ̎擾���d���`�[�ԍ���
                    DataView viewStockDetail = new DataView(this.StockDetailTable);

                    // �t�B���^�ݒ�
                    string viewStockDetailRowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                    StockDetailSchema.ct_Col_SupplierFormal, 0,
                                                    StockDetailSchema.ct_Col_SupplierSlipNo, stockSlipWork.SupplierSlipNo
                                                    );
                    // �\�[�g���ݒ�
                    string viewStockDetailSortText = string.Format("{0}",
                                                    StockDetailSchema.ct_Col_StockRowNo
                                                    );
                    viewStockDetail.RowFilter = viewStockDetailRowFilterText;
                    viewStockDetail.Sort = viewStockDetailSortText;

                    if (viewStockDetail.Count == 0)
                    {
                        return (stockSlipGrpList);

                    }
                    # endregion

                    // �d�����׃f�[�^���X�g�̒�`
                    List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                    
                    // ���㖾�׃N���X
                    BuyOutLstDtl buyDtl = null;

                    foreach(DataRowView dataRowViewStockDetail in viewStockDetail)
                    {
                        # region ������ꗗ�N���X�̒��o�����������t�E�������`�[�ԍ��E�i�ԁE���ʁE�X�V���ʁ�
                        // ������ꗗ�N���X�̒��o�����������t�E�������`�[�ԍ��E�i�ԁE���ʁE�X�V���ʁ�
                        string goodsNo = (string)dataRowViewStockDetail[StockDetailSchema.ct_Col_GoodsNo];
                        double shipmentCnt = (double)dataRowViewStockDetail[StockDetailSchema.ct_Col_OrderCnt];
                        double orderCost = (double)dataRowViewStockDetail[StockDetailSchema.ct_Col_StockUnitPriceFl];

                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(
                                                    orderSlipNo,
                                                    goodsNo,
                                                    shipmentCnt,
                                                    0);
                        
                        if(view.Count == 0) continue;
                        buyDtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(view[0].Row);
                        # endregion

                        # region �d�����ׂ̎Z�o
                        // (�Z�o�p)�d�����ׂ̒�`
                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowViewStockDetail.Row);

                        // �������P���̐ݒ�
                        view[0].Row[BuyOutLstDtlSchema.ct_Col_OrderCost] = orderCost;

                        // �P���X�V����
                        if ((hed.CostUpdtDiv == 1) && (buyDtl.BuyOutCost != orderCost))
                        {
                            view[0].Row[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 7;  //�P���ύX
                        }
                        // �P���X�V�Ȃ�
                        else
                        {
                            view[0].Row[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 1;  //��������
                        }
                        
                        //�d�����׃f�[�^�̍Čv�Z
                        GetStockDetailWorkFromEpartsUpdate(hed, ref stockDetailWork, buyDtl, supplier);

                        // �Z�o�����d�����׃f�[�^���i�[
                        stockDetailWorkList.Add(stockDetailWork);
                        # endregion
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �d���f�[�^�̎Z�o
                    //-----------------------------------------------------------
                    #region �d���f�[�^�̎擾
                    GetStockSlipFromEpartsUpdate(
                            ref stockSlipWork,
                            buyDtl.BuyOutDate,
                            buyDtl.BuyOutSlipNo,
                            stockDetailWorkList,
                            supplier);
                    #endregion

                    //-----------------------------------------------------------
                    // �d�����I�u�W�F�N�g�̎擾
                    //-----------------------------------------------------------
                    # region �d�����I�u�W�F�N�g�̍쐬
                    StockSlipGrp stockSlipGrp = new StockSlipGrp();
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrp.stockDetailWorkList = stockDetailWorkList;

                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                stockSlipGrpList = null;
            }
            return (stockSlipGrpList);
        }
        # endregion

        #region �� ���X�V�p���d�����׃f�[�^�̎擾�i����ꗗ�j
        /// <summary>
        /// �� ���X�V�p���d�����׃f�[�^�̎擾
        /// </summary>
        /// <param name="hed">����ꗗ�f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailWork">�d�����׃I�u�W�F�N�g</param>
        /// <param name="buyDtl">����ꗗ���׃I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetStockDetailWorkFromEpartsUpdate(BuyOutLsthead hed, ref StockDetailWork stockDetailWork, BuyOutLstDtl buyDtl, Supplier supplier)
        {   
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = "";

            try
            {
                //�d���S���҃R�[�h
                stockDetailWork.StockAgentCode = hed.StockAgentCode;

                //�d���S���Җ���
                stockDetailWork.StockAgentName = hed.StockAgentName;

                // �P���X�V����
                if (hed.CostUpdtDiv == 1)
                {
                    //-----------------------------------------------------------
                    // �ېŋ敪�̎Z�o(0:�ې�,1:��ې�,2:�ېŁi���Łj)
                    //-----------------------------------------------------------
                    #region �ېŋ敪�̎Z�o
                    int dstTaxationCode = (int)stockDetailWork.TaxationCode;

                    if ((supplier.SuppCTaxLayCd == 9)
                    || (supplier.SuppCTaxationCd == 1)
                    || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // �ύX�O�d���P���i�����j
                    //-----------------------------------------------------------
                    #region �ύX�O�d���P���i�����j
                    stockDetailWork.BfStockUnitPriceFl = stockDetailWork.StockUnitPriceFl;
                    #endregion

                    //-----------------------------------------------------------
                    // �d���P���ύX�敪
                    //-----------------------------------------------------------
                    #region �d���P���ύX�敪
                    //�d���P���ύX�敪
                    //�ύX�O�����Ɖ񓚌������قȂ�

                    double srcCost = stockDetailWork.BfStockUnitPriceFl;
                    double dstCost = buyDtl.BuyOutCost;

                    if (srcCost != dstCost)
                    {
                        stockDetailWork.StockUnitChngDiv = 1;
                    }
                    //�ύX�O�����Ɖ񓚌���������
                    else
                    {
                        stockDetailWork.StockUnitChngDiv = 0;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // �d���P��
                    //-----------------------------------------------------------
                    #region �d���P��
                    //�d���P���i�Ŕ��C�����j
                    stockDetailWork.StockUnitPriceFl = dstCost;

                    //�d���P���i�ō��C�����j
                    if (supplier != null)
                    {
                        stockDetailWork.StockUnitTaxPriceFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // �d�����z�̎Z�o
                    //-----------------------------------------------------------
                    #region �d�����z
                    if (supplier != null)
                    {
                        long stockPriceTaxInc = 0;
                        long stockPriceTaxExc = 0;
                        long stockPriceConsTax = 0;
                        double cnt = stockDetailWork.OrderCnt;

                        bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                            (double)cnt,
                            (double)stockDetailWork.StockUnitPriceFl,
                            dstTaxationCode,
                            supplier.StockMoneyFrcProcCd,
                            supplier.StockCnsTaxFrcProcCd,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax);

                        if (bStatus == true)
                        {
                            //�d�����z�i�Ŕ����j
                            stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;

                            //�d�����z�i�ō��݁j
                            stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
                        }
                        else
                        {
                            stockDetailWork.StockPriceTaxExc = 0;
                            stockDetailWork.StockPriceTaxInc = 0;
                        }
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // ����ł̎Z�o
                    //-----------------------------------------------------------
                    #region �����
                    //�d�����z����Ŋz
                    stockDetailWork.StockPriceConsTax = (Int64)stockDetailWork.StockPriceTaxInc
                                                      - (Int64)stockDetailWork.StockPriceTaxExc;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �� ���X�V�p���d���f�[�^�̎擾�i����ꗗ�j
        /// <summary>
        /// �� ���X�V�p���d���f�[�^�̎擾�i����ꗗ�j
        /// </summary>
        /// <param name="stockDate">�d����</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�</param>
        /// <param name="list">�d�����׃I�u�W�F�N�g</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        /// <br>Update Note: 2013/01/31 �A����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>           : redmine#33991 �`�[�ԍ��������� �d���f�[�^�̎d����R�[�h�̐ݒ�s���̑Ή�</br>
        private int GetStockSlipFromEpartsUpdate(ref StockSlipWork rst, DateTime stockDate, string partySaleSlipNum, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = "";

            try
            {
                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^�̎擾
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // �d�����ׂ̎擾
                //-----------------------------------------------------------
                StockDetailWork stockDetailWork = stockDetailWorkList[0];

                //-----------------------------------------------------------
                // �d���f�[�^�̐ݒ�
                //-----------------------------------------------------------
                # region �d���f�[�^�̐ݒ�
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // �d���v�㋒�_�R�[�h
                rst.StockDate = stockDate;	                                                // �d����
                rst.PayeeCode = supplier.PayeeCode;                                         // �x����R�[�h

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // �x���旪��
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                //rst.SupplierCd = stockDetailWork.SupplierCd;	                            // �d����R�[�h  DEL 2013/01/31 �A�����@Redmine#33991 
                // -----ADD �A�����@Redmine#33991 2013/01/31------ >>>>>
                if (stockDetailWork.SupplierCd == 0)
                {
                    rst.SupplierCd = supplier.SupplierCd;	                                // �d����R�[�h
                }
                else
                {
                    rst.SupplierCd = stockDetailWork.SupplierCd;	                        // �d����R�[�h
                }
                // -----ADD �A�����@Redmine#33991 2013/01/31------ <<<<<
                rst.SupplierNm1 = supplier.SupplierNm1;                                     // �d���於1
                rst.SupplierNm2 = supplier.SupplierNm2;                                     // �d���於2
                rst.SupplierSnm = supplier.SupplierSnm;                                     // �d���旪��
                rst.BusinessTypeCode = supplier.BusinessTypeCode;	                        // �Ǝ�R�[�h
                rst.BusinessTypeName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(33, supplier.BusinessTypeCode);            // �Ǝ햼��

                rst.SalesAreaCode = supplier.SalesAreaCode;	                                // �̔��G���A�R�[�h
                rst.SalesAreaName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(21, supplier.SalesAreaCode);	// �̔��G���A����

                rst.StockInputCode = stockDetailWork.StockInputCode;	                    // �d�����͎҃R�[�h
                rst.StockInputName = stockDetailWork.StockInputName;	                    // �d�����͎Җ���
                rst.StockAgentCode = stockDetailWork.StockAgentCode;	                    // �d���S���҃R�[�h
                rst.StockAgentName = stockDetailWork.StockAgentName;	                    // �d���S���Җ���

                rst.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;	                    // �d���摍�z�\�����@�敪
                rst.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;	                    // ���z�\���|���K�p�敪

                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // �d�������œ]�ŕ����R�[�h
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);	// �d�������Őŗ�

                // �d���f�[�^�̏��Z�o
                //�d���[�������敪
                //1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj
                //�[�������P��
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //�d���[�������敪

                rst.PartySaleSlipNum = partySaleSlipNum;	                                // �����`�[�ԍ�

                // �d���f�[�^�̏��Z�o
                StockSlipPriceCalculator.TotalPriceSetting(
                                            ref rst,
                                            stockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion
        # endregion

        # endregion
    }
}

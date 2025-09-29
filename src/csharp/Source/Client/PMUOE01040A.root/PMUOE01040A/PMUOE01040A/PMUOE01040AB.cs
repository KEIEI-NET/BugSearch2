//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M����A�N�Z�X�N���X
// �v���O�����T�v   : �z���_�t�n�d �v�d�a e-Parts�񓚍X�V����
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
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/08  �C�����e : Redmine#26275 UOE�d���f�[�^�쐬�����@�񓚃f�[�^�ɓ`�[�ԍ����Z�b�g����Ă��Ȃ��f�[�^�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/05/23  �C�����e : 06/27�z�M���ARedmine#29900 �݌ɓ��ɍX�V �݌ɓ��ɍX�V�Ō������ɃG���[����������̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2013/01/09  �C�����e : 2013/03/13�z�M���ARedmine#33989 �`�[�ԍ��������� �d���f�[�^�͍쐬�����ד����s���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�   �쐬�S�� : �x�c
// �C �� ��  2013/03/08  �C�����e : 10801804-00[2012/05/23]�̑Ή����e���폜�����ɖ߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2014/11/04  �C�����e : PM-SCM�d�|�ꗗ��10689
//                                  SCM�񓚑��M�����ƃ����[�g�`���@�\�̎����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11400910-00  �쐬�S�� : �c����
// �� �� ��  2018/07/26   �C�����e : Redmine#49725 UOE�����f�[�^�폜�����Ή�
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

// --- ADD 2014/11/04 Y.Wakita ---------->>>>>
using System.IO;
using System.Diagnostics;
using Broadleaf.Application.Resources;
// --- ADD 2014/11/04 Y.Wakita ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// �t�n�d����M����A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �z���_�t�n�d �v�d�a e-Parts�񓚍X�V����</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// <br>Update Note  : 2009/12/29 xuxh</br>
    /// <br>              �E�y�v��No.2�z�Ɓy�v��No.3�z�̏C��</br>
    /// <br>Update Note  : 2018/07/26 �c����</br>
    /// <br>               Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
    /// </remarks>
	public partial class UoeSndRcvCtlAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
        private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _employeeName = LoginInfoAcquisition.Employee.Name;
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
        # region ���i�}�X�^ �A�N�Z�X�N���X
        /// <summary>
        /// ���i�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        public GoodsAcs _goodsAcs
        {
            get { return _uoeSndRcvJnlAcs.goodsAcs; }
            set { _uoeSndRcvJnlAcs.goodsAcs = value; }
        }
        # endregion

        # region ���_�ݒ�}�X�^
        /// <summary>
        /// ���_�ݒ�}�X�^
        /// </summary>
        public SecInfoSet _secInfoSet
        {
            get { return _uoeSndRcvJnlAcs.secInfoSet; }
        }
        # endregion
        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region �� �z���_�t�n�d �v�d�a e-Parts�񓚍X�V����
        /// <summary>
        /// �z���_�t�n�d �v�d�a e-Parts�񓚍X�V����
        /// </summary>
        /// <param name="list">�����ꗗ�f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�񓚃f�[�^�X�V�`�����񓚕\���܂ł̏������ڂ𐧌䂷��</br>
        /// <br>Programmer : 96186 ���� �T��</br>
        /// <br>Date       : 2009/05/25</br>
        /// <br>Update Note: 2018/07/26 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11400910-00</br>
        /// <br>             Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
        /// </remarks>
        public int EpartsUoeWebOrderCtl(ref List<OrderLsthead> list, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                List<OrderLsthead> retOrderLsthead = new List<OrderLsthead>();

                foreach (OrderLsthead hed in list)
                {
                    //�t�n�d����M���䏉����
                    if ((status = UoeSndRcvCtlInit(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        break;
                    }

                    //�z���_�t�n�d �v�d�a e-Parts�񓚍X�V���䃁�C��
                    OrderLsthead orderLsthead = hed.Clone();
                    
                    //�o�l�A��������
                    if(orderLsthead.CsvKnd == 0)
                    {
                        if ((status = EpartsUoeWebOrderCtlPm(ref orderLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //����͎�
                    else if (orderLsthead.CsvKnd == 1)
                    {
                        if ((status = EpartsUoeWebOrderCtlInput(ref orderLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //�F���s���`��
                    else
                    {
                        continue;
                    }
                    
                    retOrderLsthead.Add(orderLsthead);
                }

                //�ߒl��ݒ�
                list = retOrderLsthead;

                // --- ADD 2018/07/26 �c���� Redmine#49725 UOE�����f�[�^�폜�����Ή� -------------------->>>>>
                // �ߋ���UOE�����f�[�^�̍폜���s��
                this.DeleteUoeOrderData();
                // --- ADD 2018/07/26 �c���� Redmine#49725 UOE�����f�[�^�폜�����Ή� --------------------<<<<<
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

        # region �� �z���_�t�n�d �v�d�a e-Parts�񓚍X�V
        # region �� �z���_�t�n�d �v�d�a e-Parts�񓚍X�V�i����͎��j
        # region �� �z���_�t�n�d �v�d�a e-Parts�񓚍X�V�i����͎��j
        /// <summary>
        /// �z���_�t�n�d �v�d�a e-Parts�񓚍X�V�i����͎��j
        /// </summary>
        /// <param name="hed">�����ꗗ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
		/// <remarks>
	    /// <br>Programmer : 96186 ���� �T��</br>
	    /// <br>Date       : 2009/05/25</br>
		/// </remarks>
        private int EpartsUoeWebOrderCtlInput(ref OrderLsthead hed, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �����ꗗ���ׁi����́j�N���X�̃`�F�b�N
                //-----------------------------------------------------------
                # region �����ꗗ���ׁi����́j�N���X�̃`�F�b�N
                if (hed.LstDtl == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                if (hed.LstDtl.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                ArrayList lstDtl = new ArrayList();
                foreach (OrderLstInputDtl dtl in hed.LstDtl)
                {
                    //���͗\��������ݒ�̏ꍇ�A�����������͗\����ɐݒ�
                    if (dtl.PlanDate == DateTime.MinValue)
                    {
                        dtl.PlanDate = dtl.OrderDate;
                    }

                    //�o�Ɍ����u�鎭�E���R�v�̏ꍇ�A�`�[�ԍ��Ɂu-F�v��t������
                    if ((dtl.SourceShipment.IndexOf("�鎭") != -1) || (dtl.SourceShipment.IndexOf("���R") != -1))
                    {
                        if (!string.IsNullOrEmpty(dtl.SlipNoDtl)) // ADD 2011/11/08
                        { // ADD 2011/11/08
                            dtl.SlipNoDtl = dtl.SlipNoDtl.Trim() + "-F";
                        } // ADD 2011/11/08
                    }

                    lstDtl.Add(dtl);
                }
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
                    hed.UpdRsl = -1;
                    return (-1);
                }
                #endregion

                //-----------------------------------------------------------
                // ���ʃN���X�̏�����
                //-----------------------------------------------------------
                # region ���ʃN���X�̏�����
                # region �����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
                //�����ꗗ����(�����)�f�[�^�e�[�u��Row�쐬
                if ((status = _uoeSndRcvJnlAcs.orderLstInputDtlFromDtlWrite(lstDtl, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # region �u�d����+�����`�[�ԍ��v�l���Z�o
                //�����ꗗ�w�b�_�[��Dictionary
                Dictionary<string, OrderLstInputDtl> orderLstInputDictionary = new Dictionary<string, OrderLstInputDtl>();

                // �u���͗\���+�����`�[�ԍ��v�l���Z�o
                foreach (OrderLstInputDtl dtl in lstDtl)
                {
                    //�d�������̒����`�F�b�N
                    if (_totalDayCalculator.CheckPayment(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.PlanDate) != false)
                    {
                        continue;
                    }
                    //�d�������̒����`�F�b�N
                    else if (_totalDayCalculator.CheckMonthlyAccPay(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.PlanDate) != false)
                    {
                        continue;
                    }

                    //���ʔ���
                    if ((dtl.ShipmentCnt == 0)
                    || (dtl.ShipmGoodsNo.Trim() == String.Empty)
                    || (dtl.SlipNoDtl.Trim() == String.Empty))
                    {
                        continue;
                    }

                    //���͗\���(YYYYMMDD)+�`�[�ԍ�(999999)
                    int orderDateInt = (dtl.PlanDate.Year * 10000)
                                     + (dtl.PlanDate.Month * 100)
                                     + dtl.PlanDate.Day;

                    string key = orderDateInt.ToString() + dtl.SlipNoDtl.Trim();
                    if (orderLstInputDictionary.ContainsKey(key) != true)
                    {
                        orderLstInputDictionary.Add(key, dtl);
                    }
                }

                //�d�������E�d�������̃`�F�b�N�ɂ�菈���f�[�^�����݂��Ȃ��ꍇ�A�G���[�I������
                if (orderLstInputDictionary.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̓Ǎ��i�����[�g�������s�j
                //-----------------------------------------------------------
                # region �d���f�[�^�̓Ǎ��i�����[�g�������s�j
                # region �������o�N���X�̍쐬
                //�������o�N���X�̍쐬
                ArrayList stockSlipWorkAry = new ArrayList();

                foreach (string key in orderLstInputDictionary.Keys)
                {
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //��ƃR�[�h
                    stockSlipWork.SectionCode = hed.SectionCode;        //���_�R�[�h
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //�d����R�[�h
                    stockSlipWork.SupplierFormal = 0;                   //0:�d��
                    stockSlipWork.StockDate = dtl.PlanDate;            //�d����
                    stockSlipWork.ArrivalGoodsDay = dtl.PlanDate;      //���ד�
                    stockSlipWork.PartySaleSlipNum = dtl.SlipNoDtl;    //�����`�[�ԍ�

                    stockSlipWorkAry.Add(stockSlipWork);
                }
                # endregion

                # region ���o�����[�g�����̎��s
                //���o�����[�g�����̎��s
                List<StockSlipWork> stockSlipWorkList = null;       //�d�����[�N���X�g
                List<StockDetailWork> stockDetailWorkList = null;   //�d�����׃��[�N���X�g

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

                        //������(YYYYMMDD)+�`�[�ԍ�(999999)
                        int stockDateInt = (stockSlipWork.StockDate.Year * 10000)
                                         + (stockSlipWork.StockDate.Month * 100)
                                         + stockSlipWork.StockDate.Day;

                        string key = stockDateInt.ToString() + stockSlipWork.PartySaleSlipNum.Trim();

                        if (stockSlipWorkDictionary.ContainsKey(key) != true)
                        {
                            stockSlipWorkDictionary.Add(key, stockSlipWork);
                        }
                    }
                }
                # endregion

                # region �X�V�Ώۂ̑����`�[�ԍ����Z�o
                //�X�V�Ώۂ̑����`�[�ԍ����Z�o

                //�����ꗗ�w�b�_�[��Dictionary
                Dictionary<string, OrderLstInputDtl> dtlDictionary = new Dictionary<string, OrderLstInputDtl>();

                foreach (string key in orderLstInputDictionary.Keys)
                {
                    //�����̎d���f�[�^�̑��݃`�F�b�N
                    if (stockSlipWorkDictionary.ContainsKey(key) == true) continue; 

                    //�X�V�Ώۂ̑����`�[�ԍ����擾
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];
                    dtlDictionary.Add(key, dtl);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // �d�����̍X�V�p�p�����[�^�̍쐬
                //-----------------------------------------------------------
                # region �d�����̍X�V�p�p�����[�^�̍쐬

                //�d�����̍X�V�p�p�����[�^��`
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

                
                foreach (string key in dtlDictionary.Keys)
                {
                    # region �d�����E�����`�[�ԍ��ōi�荞��
                    //�d�����E�����`�[�ԍ��ōi�荞��
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];
                    DataView view = _uoeSndRcvJnlAcs.GetOrderLstInputFormCreateView(dtl.PlanDate, dtl.SlipNoDtl);
                    if (view.Count == 0) continue;
                    # endregion

                    # region �����ΏۃN���X�̎Z�o
                    //�����ΏۃN���X�̎Z�o
                    List<OrderLstInputDtl> orderLstInputDtlList = new List<OrderLstInputDtl>();
                    foreach (DataRowView dataRowView in view)
                    {
                        OrderLstInputDtl orderLstInputDtl = _uoeSndRcvJnlAcs.CreateOrderLstInputDtlFromSchema(dataRowView.Row);
                        if(orderLstInputDtl == null)    continue;
                        orderLstInputDtlList.Add(orderLstInputDtl);
                    }
                    # endregion

                    # region �d�����̍X�V�p�p�����[�^�̐ݒ�
                    //�d�����̍X�V�p�p�����[�^�̐ݒ�
                    StockSlipGrp stockSlipGrp = GetStockSlipGrpFromEpartsOrderInput(
                                                    hed.EnterpriseCode,
                                                    hed.SectionCode,
                                                    subSectionCode,
                                                    uOESupplier,
                                                    orderLstInputDtlList);
                    if(stockSlipGrp == null)    continue;
                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // �d�����̍X�V�����i�����[�g�������s�j
                //-----------------------------------------------------------
                # region �d�����̍X�V�����i�����[�g�������s�j
                if ((stockSlipGrpList == null) || (stockSlipGrpList.Count == 0))
                {
                    hed.UpdRsl = 3;
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

                    //�߂�l�̐ݒ�
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

        # region �� �z���_�t�n�d �v�d�a e-Parts �d�����̍X�V�p�p�����[�^�̎Z�o�i����́j
        /// <summary>
        /// �d�����̍X�V�p�p�����[�^�̎Z�o�i����́j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�����ꗗ����(�����)�f�[�^�N���X</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private StockSlipGrp GetStockSlipGrpFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, UOESupplier uOESupplier, List<OrderLstInputDtl> list)
        {
   			//�ϐ��̏�����
            StockSlipGrp stockSlipGrp = null;
			try
			{
                //-----------------------------------------------------------
                // �d������̎擾
                //-----------------------------------------------------------
                #region �d������̐ݒ�
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(uOESupplier.SupplierCd);
                if (supplier == null)
                {
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // �d�����׃f�[�^�̎擾
                //-----------------------------------------------------------
                #region �d�����׃f�[�^�̎擾
                List<StockDetailWork> stockDetailWorkList = GetstockDetailFromEpartsOrderInput(enterpriseCode, sectionCode, subSectionCode, list, supplier, uOESupplier);
                if (stockDetailWorkList == null) return (stockSlipGrp);
                if (stockDetailWorkList.Count == 0) return (stockSlipGrp);
                #endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̎擾
                //-----------------------------------------------------------
                #region �d���f�[�^�̎擾
                StockSlipWork stockSlipWork = GetstockSlipFromEpartsOrderInput(enterpriseCode, sectionCode, subSectionCode, list, stockDetailWorkList, supplier);
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
            catch (Exception)
            {
                stockSlipGrp = null;
            }
            return (stockSlipGrp);
        }
        # endregion

        # region �� �d���f�[�^�̎擾�i����́j
        /// <summary>
        /// �d���f�[�^�̎擾�i����́j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="list">�����ꗗ����(�����)�f�[�^�N���X</param>
        /// <param name="list">�d�����׃I�u�W�F�N�g</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private StockSlipWork GetstockSlipFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<OrderLstInputDtl> list, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //�ϐ��̏�����
            StockSlipWork rst = null;
            try
            {
                //-----------------------------------------------------------
                // �����ꗗ���ׂ̎擾
                //-----------------------------------------------------------
                OrderLstInputDtl orderLstInputDtl = list[0];

                //-----------------------------------------------------------
                // �d�����ׂ̎擾
                //-----------------------------------------------------------
                StockDetailWork stockDetailWork = stockDetailWorkList[0];

                //-----------------------------------------------------------
                // �d���f�[�^�̐ݒ�
                //-----------------------------------------------------------
                //�d�����t�̎Z�o
                DateTime stockDate = orderLstInputDtl.PlanDate;

                rst = GetStockSlipFromEpartsInsert(
                                    enterpriseCode,             //��ƃR�[�h
                                    sectionCode,                //���_�R�[�h
                                    subSectionCode,             //����R�[�h
                                    stockDate,                  //�d�����t
                                    orderLstInputDtl.SlipNoDtl, //�����`�[�ԍ�
                                    stockDetailWorkList,        //�d�����׃I�u�W�F�N�g
                                    supplier);                  //�d�����I�u�W�F�N�g
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

        # region �� �d�����׃f�[�^�̎擾�i����́j
        /// <summary>
        /// �d�����׃f�[�^�̎擾�i����́j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="list">�����ꗗ����(�����)�f�[�^�N���X</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>�d�����׃I�u�W�F�N�g</returns>
        private List<StockDetailWork> GetstockDetailFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<OrderLstInputDtl> list, Supplier supplier, UOESupplier uOESupplier)
        {
            //�ϐ��̏�����
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
			try
			{
                int stockRowNo = 1; //�d���s�ԍ�

                foreach (OrderLstInputDtl dtl in list)
                {
                    StockDetailWork stockDetailWork = GetStockDetailWorkFromEpartsInsert(
                                        enterpriseCode,     //��ƃR�[�h
                                        sectionCode,        //���_�R�[�h
                                        subSectionCode,         //����R�[�h
                                        stockRowNo,             //�d���s�ԍ�
                                        dtl.ShipmGoodsNo,       //�i��
                                        dtl.GoodsName,          //�i��
                                        dtl.ShipmentCnt,        //����
                                        dtl.AnswerListPrice,    //�艿
                                        dtl.AnswerSalesUnitCost,//�P��
                                        _employeeCode,          //�S���҃R�[�h
                                        _employeeName,          //�S���Җ�
                                        supplier,               //�d�����I�u�W�F�N�g
                                        uOESupplier);           //UOE�������I�u�W�F�N�g

                    stockDetailWorkList.Add(stockDetailWork);
                }
            }
            catch (Exception)
            {
                stockDetailWorkList = null;
            }
            return (stockDetailWorkList);
        }
        # endregion

        # region �� �d���f�[�^�̎擾
        /// <summary>
        /// �� �d���f�[�^�̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="stockDate">�d����</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�</param>
        /// <param name="list">�d�����׃I�u�W�F�N�g</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private StockSlipWork GetStockSlipFromEpartsInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, DateTime stockDate, string partySaleSlipNum, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //�ϐ��̏�����
            StockSlipWork rst = new StockSlipWork();
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
                rst.EnterpriseCode = enterpriseCode;                                        // ��ƃR�[�h
                rst.SupplierFormal = 0;	                                                    // �d���`���@���@0:�d��
                rst.SupplierSlipNo = 0;	                                                    // �d���`�[�ԍ�
                rst.SectionCode = sectionCode;	                                            // ���_�R�[�h
                rst.SubSectionCode = subSectionCode;	                                    // ����R�[�h
                rst.DebitNoteDiv = 0;	                                                    // �ԓ`�敪 ���@0:���`
                rst.DebitNLnkSuppSlipNo = 0;	                                            // �ԍ��A���d���`�[�ԍ�
                rst.SupplierSlipCd = 10;	                                                // �d���`�[�敪�@���@10:�d��
                rst.StockGoodsCd = 0;	                                                    // �d�����i�敪�@���@0:���i
                rst.AccPayDivCd = 1;	                                                    // ���|�敪�@���@1:���|
                rst.StockSectionCd = sectionCode;	                                        // �d�����_�R�[�h
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // �d���v�㋒�_�R�[�h
                rst.StockSlipUpdateCd = 0;	                                                // �d���`�[�X�V�敪 0:���X�V
                rst.InputDay = DateTime.Now;	                                            // ���͓��@���@�V�X�e�����t
                //rst.ArrivalGoodsDay = DateTime.MinValue;	                                // ���ד�  // DEL 2013/01/09 Redmine #33989 ����
                rst.ArrivalGoodsDay = stockDate;                                            // ���ד�  // ADD 2013/01/09 Redmine #33989 ����
                rst.StockDate = stockDate;	                                                // �d����
                //rst.StockAddUpADate = DateTime.MinValue;	                                // �d���v����t
                rst.StockAddUpADate = stockDate;	                                        // �d���v����t
                rst.DelayPaymentDiv = 0;	                                                // �����敪 0:����
                rst.PayeeCode = supplier.PayeeCode;                                         // �x����R�[�h

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // �x���旪��
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                rst.SupplierCd = stockDetailWork.SupplierCd;	                            // �d����R�[�h
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


                rst.TaxAdjust = 0;	                                                        // ����Œ����z
                rst.BalanceAdjust = 0;	                                                    // �c�������z
                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // �d�������œ]�ŕ����R�[�h
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);	// �d�������Őŗ�
                rst.AccPayConsTax = 0;	                                                    // ���|�����

                // �d���f�[�^�̏��Z�o
                //�d���[�������敪
                //1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj
                //�[�������P��
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //�d���[�������敪

                rst.AutoPayment = 0;	                                                    // �����x���敪 0�F�ʏ�x��
                rst.AutoPaySlipNum = 0;	                                                    // �����x���`�[�ԍ�
                rst.RetGoodsReasonDiv = 0;	                                                // �ԕi���R�R�[�h
                rst.RetGoodsReason = string.Empty;	                                        // �ԕi���R
                rst.PartySaleSlipNum = partySaleSlipNum;	                                // �����`�[�ԍ�
                rst.SupplierSlipNote1 = string.Empty;	                                    // �d���`�[���l1
                rst.SupplierSlipNote2 = string.Empty;	                                    // �d���`�[���l2
                rst.DetailRowCount = stockDetailWorkList.Count;	                            // ���׍s���@���@�s���J�E���g�l
                rst.EdiSendDate = DateTime.MinValue;	                                    // �d�c�h���M��
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // �d�c�h�捞��
                rst.UoeRemark1 = string.Empty;                                              // �t�n�d���}�[�N�P
                rst.UoeRemark2 = string.Empty;                                              // �t�n�d���}�[�N�Q
                rst.SlipPrintDivCd = 0;	                                                    // �`�[���s�敪
                rst.SlipPrintFinishCd = 0;	                                                // �`�[���s�ϋ敪
                rst.StockSlipPrintDate = DateTime.MinValue;	                                // �d���`�[���s��
                rst.SlipPrtSetPaperId = string.Empty;	                                    // �`�[����ݒ�p���[ID
                rst.SlipAddressDiv = 2;	                                                    // �`�[�Z���敪�@���@2:�[����
                rst.AddresseeCode = 0;	                                                    // �[�i��R�[�h
                rst.AddresseeName = string.Empty;	                                        // �[�i�於��
                rst.AddresseeName2 = string.Empty;	                                        // �[�i�於��2
                rst.AddresseePostNo = string.Empty;	                                        // �[�i��X�֔ԍ�
                rst.AddresseeAddr1 = string.Empty;	                                        // �[�i��Z��1(�s���{���s��S�E�����E��)
                rst.AddresseeAddr3 = string.Empty;	                                        // �[�i��Z��3(�Ԓn)
                rst.AddresseeAddr4 = string.Empty;	                                        // �[�i��Z��4(�A�p�[�g����)
                rst.AddresseeTelNo = string.Empty;	                                        // �[�i��d�b�ԍ�
                rst.AddresseeFaxNo = string.Empty;	                                        // �[�i��FAX�ԍ�
                rst.DirectSendingCd = stockDetailWork.DirectSendingCd;	                    // �����敪

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
                string message = ex.Message;
                //rst = null;
            }
            return (rst);
        }
        # endregion

        # region �� �d�����׃f�[�^�̎擾
        /// <summary>
        /// �d�����׃N���X�̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsName">�i��</param>
        /// <param name="orderCnt">����</param>
        /// <param name="answerListPrice">�艿</param>
        /// <param name="answerSalesUnitCost">�P��</param>

        /// <param name="stockAgentCode">�d���S���҃R�[�h</param>
        /// <param name="stockAgentName">�d���S���Җ���</param>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>�d�����׃I�u�W�F�N�g</returns>
        private StockDetailWork GetStockDetailWorkFromEpartsInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, int stockRowNo, string goodsNo, string goodsName, double orderCnt, double answerListPrice, double answerSalesUnitCost, string stockAgentCode, string stockAgentName, Supplier supplier, UOESupplier uOESupplier)
        {
            //�ϐ��̏�����
            StockDetailWork stockDetailWork = new StockDetailWork();

            try
            {
                //-----------------------------------------------------------
                // ���ڒl�̐ݒ�
                //-----------------------------------------------------------
                #region ���ڒl�̐ݒ�
                //�d���`��
                stockDetailWork.SupplierFormal = 0; //0:�d��

                //�d���`�[�ԍ�
                stockDetailWork.SupplierSlipNo = 0;

                //�d���s�ԍ�
                stockDetailWork.StockRowNo = stockRowNo;

                //��ƃR�[�h
                stockDetailWork.EnterpriseCode = enterpriseCode;

                //���_�R�[�h
                stockDetailWork.SectionCode = sectionCode;

                //����R�[�h
                stockDetailWork.SubSectionCode = subSectionCode;

                //�d���`���i���j
                stockDetailWork.SupplierFormalSrc = 0;  //0:�d��

                //�d�����͎҃R�[�h
                stockDetailWork.StockInputCode = _employeeCode;

                //�d�����͎Җ���
                stockDetailWork.StockInputName = _employeeName;

                //�d���S���҃R�[�h
                stockDetailWork.StockAgentCode = stockAgentCode;

                //�d���S���Җ���
                stockDetailWork.StockAgentName = stockAgentName;

                //�d����R�[�h
                stockDetailWork.SupplierCd = supplier.SupplierCd;

                //�d���旪��
                stockDetailWork.SupplierSnm = supplier.SupplierSnm;

                //�������@
                stockDetailWork.WayToOrder = 0;

                //�����f�[�^�쐬��
                stockDetailWork.OrderDataCreateDate = DateTime.MinValue;

                //���������s�ϋ敪
                stockDetailWork.OrderFormIssuedDiv = 0;
                #endregion

                //-----------------------------------------------------------
                // �i�Ԍ������ʂ̐ݒ�
                //-----------------------------------------------------------
                # region �i�Ԍ������ʂ̐ݒ�
                //���i�ԍ�
                stockDetailWork.GoodsNo = goodsNo;

                //���i����
                stockDetailWork.GoodsName = goodsName;

                //�i�Ԍ���
                List<GoodsUnitData> GoodsUnitDataList = null;

                int status = this._uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(
                    stockDetailWork.GoodsNo,
                    uOESupplier,
                    out GoodsUnitDataList,
                    false);

                if ((status == 0) && (GoodsUnitDataList != null))
                {
                    //�N���X�ݒ�
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[0];
                    List<Stock> stockList = GoodsUnitDataList[0].StockList;
                    List<GoodsPrice> goodsPriceList = GoodsUnitDataList[0].GoodsPriceList;

                    //���_�q�ɂ̍݌ɏ��
                    Stock stock = GetStock_FromSecInfoSet(stockList, goodsUnitData.SelectedWarehouseCode);

                    //���i�}�X�^�̎擾
                    GoodsPrice goodsPrice = GetGoodsPrice_FromGoodsPriceList(goodsPriceList);

                    # region ���i���
                    //���i���
                    stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;               //���i���̃J�i
                    stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                   //���i�啪�ރR�[�h
                    stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;           //���i�啪�ޖ���
                    stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                   //���i�����ރR�[�h
                    stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;           //���i�����ޖ���
                    stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                   //BL�O���[�v�R�[�h
                    stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                   //BL�O���[�v�R�[�h����
                    stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                   //BL���i�R�[�h
                    stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;           //BL���i�R�[�h���́i�S�p�j

                    stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;   //���Е��ރR�[�h
                    stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;   //���Е��ޖ���
                    stockDetailWork.TaxationCode = goodsUnitData.TaxationDivCd;                //�ېŋ敪

                    stockDetailWork.GoodsKindCode = goodsUnitData.GoodsKindCode;               //���i����
                    stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                 //���i���[�J�[�R�[�h
                    stockDetailWork.MakerName = goodsUnitData.MakerName;                       //���[�J�[����
                    stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;               //���[�J�[�J�i����
                    stockDetailWork.RateBLGoodsCode = goodsUnitData.BLGoodsCode;               //BL���i�R�[�h�i�|���j
                    stockDetailWork.RateBLGoodsName = goodsUnitData.BLGoodsFullName;           //BL���i�R�[�h���́i�|���j
                    stockDetailWork.StockOrderDivCd = stock.WarehouseCode.Trim() == "" ? 0 : 1;//�d���݌Ɏ�񂹋敪 0:���,1:�݌�
                    #endregion

                    # region ���i���
                    //���i���
                    if (goodsPrice != null)
                    {
                        stockDetailWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;                 //�I�[�v�����i�敪
                    }
                    #endregion

                    # region �݌ɏ��
                    //�݌ɏ��
                    if (stock != null)
                    {
                        //�q�ɃR�[�h
                        stockDetailWork.WarehouseCode = stock.WarehouseCode;

                        //�q�ɖ���
                        stockDetailWork.WarehouseName = stock.WarehouseName;

                        //�q�ɒI��
                        stockDetailWork.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    #endregion
                }
                #endregion

                //-----------------------------------------------------------
                // ������
                //-----------------------------------------------------------
                #region �������̐ݒ�
                stockDetailWork.OrderCnt = orderCnt;
                stockDetailWork.StockCount = orderCnt;
                stockDetailWork.OrderRemainCnt = orderCnt;
                #endregion

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
                // �ύX�O�艿
                //-----------------------------------------------------------
                #region �ύX�O�艿
                stockDetailWork.BfListPrice = stockDetailWork.ListPriceTaxExcFl;
                #endregion

                //-----------------------------------------------------------
                // �艿
                //-----------------------------------------------------------
                #region �艿
                //�艿�i�Ŕ��C�����j
                double dstPrice = answerListPrice;
                stockDetailWork.ListPriceTaxExcFl = dstPrice;

                //�艿�i�ō��C�����j
                if (supplier != null)
                {
                    stockDetailWork.ListPriceTaxIncFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                }
                #endregion

                //-----------------------------------------------------------
                // �ύX�O�d���P���i�����j
                //-----------------------------------------------------------
                #region �ύX�O�d���P���i�����j
                stockDetailWork.BfStockUnitPriceFl = answerSalesUnitCost;
                #endregion

                //-----------------------------------------------------------
                // �d���P���ύX�敪
                //-----------------------------------------------------------
                #region �d���P���ύX�敪
                //�d���P���ύX�敪
                //�ύX�O�����Ɖ񓚌������قȂ�

                double srcCost = stockDetailWork.BfStockUnitPriceFl;
                double dstCost = answerSalesUnitCost;

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
                stockDetailWork.StockUnitPriceFl = answerSalesUnitCost;

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
                    Int32 cnt = (Int32)orderCnt;

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
            catch (Exception)
            {
                stockDetailWork = null;
            }
            return (stockDetailWork);
        }
        # endregion

        # region �� ���C���q�ɂ̍݌ɏ��擾
        /// <summary>
        /// ���C���q�ɂ̍݌ɏ��擾
        /// </summary>
        /// <param name="list">�݌ɏ�񃊃X�g</param>
        /// <param name="selectedWarehouseCode">�I��q�ɃR�[�h</param>
        /// <returns>�݌ɏ��</returns>
        private Stock GetStock_FromSecInfoSet(List<Stock> list, string selectedWarehouseCode)
        {
            string sectWarehouseCd = "";
            Stock returnStock = null;

            try
            {
                if (list == null)
                {
                    returnStock = new Stock();
                    return (returnStock);
                }

                for (int i = 0; (i < 4) && (returnStock == null); i++)
                {
                    switch (i)
                    {
                        //�I��q�ɂ̌���
                        case 0:
                            sectWarehouseCd = selectedWarehouseCode;
                            break;
                        //�D��q�ɇ@�̌���
                        case 1:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd1;
                            break;
                        //�D��q�ɇA�̌���
                        case 2:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd2;
                            break;
                        //�D��q�ɇB�̌���
                        case 3:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd3;
                            break;
                    }

                    if (sectWarehouseCd == null) continue;
                    if (sectWarehouseCd.Trim() == "") continue;

                    foreach (Stock stock in list)
                    {
                        if (stock.WarehouseCode.Trim() == sectWarehouseCd.Trim())
                        {
                            returnStock = stock;
                            break;
                        }
                    }
                }
            }
            catch (ConstraintException)
            {
                returnStock = null;
            }
            if (returnStock == null)
            {
                returnStock = new Stock();
            }
            return (returnStock);
        }
        # endregion

        # region �� ���i�}�X�^�̌���
        /// <summary>
        /// ���i�}�X�^�̌���
        /// </summary>
        /// <param name="list">���i�}�X�^���X�g</param>
        /// <returns>���i�}�X�^</returns>
        public GoodsPrice GetGoodsPrice_FromGoodsPriceList(List<GoodsPrice> list)
        {
            return (_goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, list));
        }
        # endregion

        # region �� �]�ƈ��}�X�^�N���X�̎擾
        /// <summary>
        /// �]�ƈ��}�X�^�N���X�̎擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            Employee employee = null;
            EmployeeDtl employeeDtl = null;
                
            try
            {
                EmployeeAcs employeeAcs = new EmployeeAcs(); 			// �]�ƈ���� �A�N�Z�X�N���X
                int status = employeeAcs.Read(out employee, out employeeDtl, enterpriseCode, employeeCode);
                if (status != 0)
                {
                    employeeDtl = null;
                }
            }
            catch (ConstraintException)
            {
                employeeDtl = null;
            }
            return (employeeDtl);
        }
        #endregion
        # endregion

        # region �� �z���_�t�n�d �v�d�a e-Parts�񓚍X�V�i�o�l�A�����j
        /// <summary>
        /// �z���_�t�n�d �v�d�a e-Parts�񓚍X�V�i�o�l�A�����j
        /// </summary>
        /// <param name="hed">�����ꗗ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
		/// <remarks>
	    /// <br>Programmer : 96186 ���� �T��</br>
	    /// <br>Date       : 2009/05/25</br>
        /// <br>Update Note: 2012/05/23 wangf </br>
        /// <br>           : 10801804-00�A06/27�z�M���ARedmine#29900 �݌ɓ��ɍX�V �݌ɓ��ɍX�V�Ō������ɃG���[����������̑Ή�</br>
        /// <br>Update Note: 2013/03/08 �x�c </br>
        /// <br>           : 10801804-00�A06/27�z�M���ARedmine#29900�̑Ή����폜���ύX�O�ɖ߂�</br>
        /// </remarks>
        private int EpartsUoeWebOrderCtlPm(ref OrderLsthead hed, out string message)
        {
			//�ϐ��̏�����
            string procNm = "EpartsUoeWebOrderCtlPm";
            string asseNm = "";
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // ���ʃN���X�̏�����
                //-----------------------------------------------------------
                # region ���ʃN���X�̏�����
                // �����ꗗ���ׁiPM�A���j�N���X
                // 2013/03/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////ArrayList lstDtl = hed.LstDtl;  // DEL wangf 2012/05/23 FOR Redmine#29900
                //// ------------ADD START wangf 2012/05/23 FOR Redmine#29900--------->>>>
                //ArrayList lstDtl = new ArrayList();
                //foreach (OrderLstPmDtl dtl in hed.LstDtl)
                //{
                //    //�o�Ɍ����u�鎭�E���R�v�̏ꍇ�A�`�[�ԍ��Ɂu-F�v��t������
                //    if ((dtl.SourceShipment.IndexOf("�鎭") != -1) || (dtl.SourceShipment.IndexOf("���R") != -1))
                //    {
                //        if (!string.IsNullOrEmpty(dtl.SlipNoDtl))
                //            dtl.SlipNoDtl = dtl.SlipNoDtl.Trim() + "-F";
                //    }
                //
                //    lstDtl.Add(dtl);
                //}
                //// ------------ADD END wangf 2012/05/23 FOR Redmine#29900---------<<<<<
                ArrayList lstDtl = hed.LstDtl;  
                // 2013/03/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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

                _uOEOrderDtlWorkList = null;    //UOE�������[�N���X�g
                _stockDetailWorkList = null;    //�d�����׃��[�N���X�g
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
                // �������̎擾
                //-----------------------------------------------------------
                # region �������̎擾
                //�j�d�x���̎Z�o
                Dictionary<String, OrderLstPmDtl> orderLstPmDtlDictionary = new Dictionary<String, OrderLstPmDtl>();

                //�������o�N���X�̐ݒ�
                ArrayList paraAry = new ArrayList();
                foreach (OrderLstPmDtl dtl in lstDtl)
                {
                    //�i�[�`�F�b�N
                    String dtlKey = dtl.LinkNo.ToString("d9") + dtl.OrderGoodsNo;
                    if (orderLstPmDtlDictionary.ContainsKey(dtlKey) == true) continue;
                    orderLstPmDtlDictionary.Add(dtlKey, dtl);
                    
                    //�i�[����
                    UOEOdrDtlGodsReadCndtnWork uOEOdrDtlGodsReadCndtnWork = new UOEOdrDtlGodsReadCndtnWork();

                    uOEOdrDtlGodsReadCndtnWork.EnterpriseCode = hed.EnterpriseCode;
                    uOEOdrDtlGodsReadCndtnWork.SectionCode = hed.SectionCode;
                    uOEOdrDtlGodsReadCndtnWork.UOESupplierCd = hed.UOESupplierCd;
                    uOEOdrDtlGodsReadCndtnWork.UOESalesOrderNo = dtl.LinkNo;
                    uOEOdrDtlGodsReadCndtnWork.GoodsNoNoneHyphen = dtl.OrderGoodsNo;
                    uOEOdrDtlGodsReadCndtnWork.DataSendCodes = new int[2] {1, 9};

                    paraAry.Add(uOEOdrDtlGodsReadCndtnWork);
                }

                //�������̎擾�����[�g���s
                List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = null;
                List<StockDetailWork> returnStockDetailWorkList = null;

                status = _uoeOrderInfoAcs.UoeOdrDtlGodsReadAll(
			                paraAry,
                            out returnUOEOrderDtlWorkList,
                            out returnStockDetailWorkList,
			                out message);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (returnUOEOrderDtlWorkList.Count == 0)
                        {
                            message = "�Y���f�[�^�����݂��܂���B";
                            hed.UpdRsl = -1;
                            return ((int)EnumUoeConst.Status.ct_NORMAL);
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�Y���f�[�^�����݂��܂���B";
                        hed.UpdRsl = -1;
                        return ((int)EnumUoeConst.Status.ct_NORMAL);
                    default:
                        return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // ��DtlRelationGuid���ݒ�
                //-----------------------------------------------------------
                # region ��DtlRelationGuid���ݒ�
                Dictionary<Int64, Guid> guidDictionary = new Dictionary<Int64, Guid>();

                # region �t�n�d�����f�[�^�́�DtlRelationGuid���ݒ�
                // �t�n�d�����f�[�^�́�DtlRelationGuid���ݒ�
                _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();

                foreach(UOEOrderDtlWork dtl in returnUOEOrderDtlWorkList)
                {
                    if (dtl.DataSendCode != 1) continue;

                    Guid guid = Guid.NewGuid();
                    Int64 stockSlipDtlNum = dtl.StockSlipDtlNum;

                    dtl.DtlRelationGuid = guid;
                    if(guidDictionary.ContainsKey(stockSlipDtlNum) != true)
                    {
                        guidDictionary.Add(stockSlipDtlNum, guid);
                    }
                    _uOEOrderDtlWorkList.Add(dtl);
                }

                if (_uOEOrderDtlWorkList.Count == 0)
                {
                    hed.UpdRsl = 3; //�捞��
                    return ((int)EnumUoeConst.Status.ct_NORMAL);
                }
                # endregion

                # region �d�����׃f�[�^�́�DtlRelationGuid���ݒ�
                // �d�����׃f�[�^�́�DtlRelationGuid���ݒ�
                _stockDetailWorkList = new List<StockDetailWork>();

                foreach(StockDetailWork dtl in returnStockDetailWorkList)
                {
                    Int64 stockSlipDtlNum = dtl.StockSlipDtlNum;
                    if (guidDictionary.ContainsKey(stockSlipDtlNum) != true) continue;

                    Guid guid = guidDictionary[stockSlipDtlNum];
                    dtl.DtlRelationGuid = guid;
                    _stockDetailWorkList.Add(dtl);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // ����M�i�m�k�e�[�u���E�t�n�d�����f�[�^�e�[�u���E�d�����׃e�[�u���̍쐬
                //-----------------------------------------------------------
		        # region ����M�i�m�k�e�[�u���E�t�n�d�����f�[�^�e�[�u���E�d�����׃e�[�u���̍쐬
                # region �t�n�d�����f�[�^���t�n�d�����f�[�^�e�[�u���̍쐬
                // �t�n�d�����f�[�^���t�n�d�����f�[�^�e�[�u���̍쐬
                status = _uoeSndRcvJnlAcs.ToDataTableFromUOEOrderDtlList(_uOEOrderDtlWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region �d�����ׁ��d�����׃e�[�u���̍쐬
                //�d�����ׁ��d�����׃e�[�u���̍쐬
                foreach (StockDetailWork stockDetailWork in _stockDetailWorkList)
                {
                    status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(StockDetailTable, stockDetailWork, "", 0, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion

                # region �d�����׃e�[�u���ɋ��ʓ`�[�ԍ��E���ʓ`�[�s�ԍ���ݒ�
                // �d�����׃e�[�u���ɋ��ʓ`�[�ԍ��E���ʓ`�[�s�ԍ���ݒ�
                int supplierFormal = _stockDetailWorkList[0].SupplierFormal;
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailWork(
                                                            StockDetailTable,
                                                            supplierFormal,
                                                            uOEOrderDtlWork.DtlRelationGuid,
                                                            uOEOrderDtlWork.UOESalesOrderNo.ToString("d9"),
                                                            uOEOrderDtlWork.UOESalesOrderRowNo,
                                                            out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion

                # region �t�n�d�����f�[�^������M�i�m�k�e�[�u���̍쐬
                // �t�n�d�����f�[�^������M�i�m�k�e�[�u���̍쐬
				status = _uoeSndRcvJnlAcs.orderJnlFromDtlWrite(_uOEOrderDtlWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // �z���_�t�n�d �v�d�a e-Parts�񓚃f�[�^�X�V����
                //-----------------------------------------------------------
                # region �z���_�t�n�d �v�d�a e-Parts�񓚃f�[�^�X�V����
                asseNm = "�z���_�t�n�d �v�d�a e-Parts�񓚃f�[�^�X�V����";
                logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                if (_uOEAnswerAcs == null)
                {
                    _uOEAnswerAcs = new UOEAnswerAcs();
                }

                status = _uOEAnswerAcs.UpDtAnswerEParts(uOESupplier, lstDtl, out message);

                logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);

                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                for (int index = 0; index < 3; index++)
                {
                    //-----------------------------------------------------------
                    // ����E�d���f�[�^�X�V�p�}�����[�^�̐ݒ�
                    //-----------------------------------------------------------
                    # region �V�X�e���敪�̌���
                    //�V�X�e���敪�̌���
                    _uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
                    _uoeSndRcvCtlPara.BusinessCode = (int)EnumUoeConst.TerminalDiv.ct_Order;
                    _uoeSndRcvCtlPara.EnterpriseCode = hed.EnterpriseCode;
                    _uoeSndRcvCtlPara.ProcessDiv = 0;   //0:�ʏ�
                    _uoeSndRcvCtlPara.SystemDivCd = 0;  //0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[

                    switch(index)
                    {
                        //�����
                        case 0:
                            _uoeSndRcvCtlPara.SystemDivCd = 0;  //0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[
                            break;
                        //2:����
                        case 1:
                            _uoeSndRcvCtlPara.SystemDivCd = 2;  //0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[
                            break;
                        //3:�`��
                        case 2:
                            _uoeSndRcvCtlPara.SystemDivCd = 1;  //0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[
                            break;
                    }
                    #endregion

                    # region UOE�����f�[�^�e�[�u���̍i�荞��
                    //UOE�����f�[�^�e�[�u���̍i�荞��
                    DataView view = new DataView(this.UOEOrderDtlTable);

                    string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                                UOEOrderDtlSchema.ct_Col_SystemDivCd, _uoeSndRcvCtlPara.SystemDivCd,
                                UOEOrderDtlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_OK,
                                UOEOrderDtlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO
                                );

                    // �\�[�g���ݒ�
                    string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                                    OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                                    OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                                    OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                                    OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                                    OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                                    );
                    view.RowFilter = rowFilterText;
                    view.Sort = sortText;

                    if (view.Count == 0) continue;
                    #endregion

                    # region UOE�����e�[�u��������M�i�m�k�i�����j
                    //UOE�����e�[�u��������M�i�m�k�i�����j

                    OrderTable.Clear(); //����MJNL�i�����j
                    foreach (DataRowView orderDtlRow in view)
                    {
                        DataRow jnlRow = OrderTable.NewRow();

                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CreateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_CreateDateTime];// �쐬����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdateDateTime];// �X�V����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterpriseCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterpriseCode];// ��ƃR�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FileHeaderGuid] = (Guid)orderDtlRow[UOEOrderDtlSchema.ct_Col_FileHeaderGuid];// GUID
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode];// �X�V�]�ƈ��R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1];// �X�V�A�Z���u��ID1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2];// �X�V�A�Z���u��ID2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode];// �_���폜�敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SystemDivCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SystemDivCd];// �V�X�e���敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo];// UOE�����ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo];// UOE�����s�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SendTerminalNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SendTerminalNo];// ���M�[���ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESupplierCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESupplierCd];// UOE������R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESupplierName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESupplierName];// UOE�����於��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CommAssemblyId] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_CommAssemblyId];// �ʐM�A�Z���u��ID
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_OnlineNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_OnlineNo];// �I�����C���ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_OnlineRowNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_OnlineRowNo];// �I�����C���s�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesDate] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesDate];// ������t
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_InputDay] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_InputDay];// ���͓�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime];// �f�[�^�X�V����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEKind] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEKind];// UOE���
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesSlipNum] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesSlipNum];// ����`�[�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus];// �󒍃X�e�[�^�X
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum];// ���㖾�גʔ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SectionCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SectionCode];// ���_�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SubSectionCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SubSectionCode];// ����R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CustomerCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_CustomerCode];// ���Ӑ�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CustomerSnm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_CustomerSnm];// ���Ӑ旪��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CashRegisterNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_CashRegisterNo];// ���W�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CommonSeqNo] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_CommonSeqNo];// ���ʒʔ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierFormal] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierFormal];// �d���`��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierSlipNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierSlipNo];// �d���`�[�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum];// �d�����גʔ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BoCode];// BO�敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv];// UOE�[�i�敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm];// �[�i�敪����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv];// �t�H���[�[�i�敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm];// �t�H���[�[�i�敪����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEResvdSection];// UOE�w�苒�_
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm];// UOE�w�苒�_����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EmployeeCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EmployeeCode];// �]�ƈ��R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EmployeeName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EmployeeName];// �]�ƈ�����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsMakerCd];// ���i���[�J�[�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MakerName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MakerName];// ���[�J�[����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsNo];// ���i�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen];// �n�C�t�������i�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsName];// ���i����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseCode];// �q�ɃR�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseName];// �q�ɖ���
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo];// �q�ɒI��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt];// �󒍐���
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ListPrice] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_ListPrice];// �艿�i�����j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesUnitCost] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesUnitCost];// �����P��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierCd];// �d����R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierSnm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierSnm];// �d���旪��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// �t�n�d���}�[�N�P
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// �t�n�d���}�[�N�Q
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate];// ��M���t
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime];// ��M����
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd];// �񓚃��[�J�[�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo];// �񓚕i��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName];// �񓚕i��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo];// ��֕i��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt];// UOE���_�o�ɐ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1];// BO�o�ɐ�1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2];// BO�o�ɐ�2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3];// BO�o�ɐ�3
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt];// ���[�J�[�t�H���[��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt];// ���o�ɐ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt];// UOE���_�݌ɐ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1];// BO�݌ɐ�1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2];// BO�݌ɐ�2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3];// BO�݌ɐ�3
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo];// UOE���_�`�[�ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1];// BO�`�[�ԍ��P
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2];// BO�`�[�ԍ��Q
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3];// BO�`�[�ԍ��R
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount];// EO������
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo];// BO�Ǘ��ԍ�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice];// �񓚒艿
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];// �񓚌����P��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark];// UOE��փ}�[�N
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEStockMark] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark];// UOE�݌Ƀ}�[�N
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd];// �w�ʃR�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1];// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2];// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3];// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1];// UOE���_�R�[�h�P�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2];// UOE���_�R�[�h�Q�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3];// UOE���_�R�[�h�R�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4];// UOE���_�R�[�h�S�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5];// UOE���_�R�[�h�T�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6];// UOE���_�R�[�h�U�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7];// UOE���_�R�[�h�V�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1];// UOE�݌ɐ��P�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2];// UOE�݌ɐ��Q�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3];// UOE�݌ɐ��R�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4];// UOE�݌ɐ��S�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5];// UOE�݌ɐ��T�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6];// UOE�݌ɐ��U�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7];// UOE�݌ɐ��V�i�}�c�_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd];// UOE���R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd];// UOE���R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEHMCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd];// UOE�g�l�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOCount] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount];// �a�n��
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode];// UOE�}�[�N�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment];// �o�׌�
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ItemCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode];// �A�C�e���R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOECheckCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode];// UOE�`�F�b�N�R�[�h
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage];// �w�b�h�G���[���b�Z�[�W
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage];// ���C���G���[���b�Z�[�W
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode];// �f�[�^���M�敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv];// �f�[�^�����敪
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivSec] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];// ���ɍX�V�敪�i���_�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];// ���ɍX�V�敪�iBO1�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];// ���ɍX�V�敪�iBO2�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];// ���ɍX�V�敪�iBO3�j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivMaker] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];// ���ɍX�V�敪�iҰ���j
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivEO] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];// ���ɍX�V�敪�iEO�j

                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid] = (Guid)orderDtlRow[UOEOrderDtlSchema.ct_Col_DtlRelationGuid];// ���׊֘A�t��GUID

                        OrderTable.Rows.Add(jnlRow);
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // ����E�d���f�[�^�쐬����
                    //-----------------------------------------------------------
                    # region ����E�d���f�[�^�쐬����
                    //����E�d���f�[�^�쐬����
                    _uoeSalesList = null;
                    if (( (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                      || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                      || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)))
				    {
                        if (_uOESalesStockAcs == null)
                        {
                            _uOESalesStockAcs = new UOESalesStockAcs();
                        }

                        asseNm = "����E�d���f�[�^�쐬";
                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                        status = _uOESalesStockAcs.UpDtSalesStock(_uoeSndRcvCtlPara, out _uoeSalesList, out message);

                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);
                    }
                    #endregion

                    // --- ADD 2014/11/04 Y.Wakita ---------->>>>>
                    //-----------------------------------------------------------
                    // �r�b�l�񓚑��M����
                    //-----------------------------------------------------------
                    # region �r�b�l�񓚑��M����
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        if (_uOESalesStockAcs != null)
                        {
                            if (_uOESalesStockAcs.scmFlg)
                            {
                                if (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                                {
                                    List<string> salesSlipNumList = new List<string>();
                                    foreach (DataRow salesSlipRow in _uOESalesStockAcs.SalesSlipTable.Rows)
                                    {
                                        if (salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim().Length != 0)
                                        {
                                            salesSlipNumList.Add(salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim());
                                        }
                                    }
                                    //�N�����p�X
                                    string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                                    if (directoryName.Length > 0)
                                    {
                                        if (directoryName[directoryName.Length - 1] != '\\')
                                        {
                                            directoryName = directoryName + "\\";
                                        }
                                    }
                                    string startInfoFileName = directoryName + "PMSCM01100U.EXE";

                                    //�N�����p�����[�^
                                    string param = Environment.GetCommandLineArgs()[1] + " " +
                                                   Environment.GetCommandLineArgs()[2];

                                    string salesSlipNum = string.Empty;
                                    // �񓚑��M�������ɑΏۂƂȂ锄��`�[�ԍ����X�g���p�����[�^�ɃZ�b�g����
                                    if (salesSlipNumList != null && salesSlipNumList.Count != 0)
                                    {
                                        for (int i = 0; i < salesSlipNumList.Count; i++)
                                        {
                                            if (i != 0)
                                            {
                                                salesSlipNum += ",";
                                            }
                                            salesSlipNum += salesSlipNumList[i].ToString();
                                        }
                                        Process p = Process.Start(startInfoFileName, param + " /A" + " 0:0:" + salesSlipNum);
                                        p.WaitForExit();
                                    }
                                }
                            }
                        }
                    }
                    # endregion
                    // --- ADD 2014/11/04 Y.Wakita ----------<<<<<

                    //-----------------------------------------------------------
                    // �t�n�d�`�[����Ăяo��
                    //-----------------------------------------------------------
                    # region �t�n�d�`�[����Ăяo��
                    if ((_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    && (_uoeSalesList != null))
                    {
                        if (_uoeSalesList.Count > 0)
                        {
                            // UOE�`�[��������Z�b�g
                            UOESlipPrintCndtn slipPrintCndtn = new UOESlipPrintCndtn();
                            slipPrintCndtn.EnterpriseCode = _enterpriseCode;
                            slipPrintCndtn.UOESalesList = _uoeSalesList;

                            // �`�[���
                            DCCMN02000UA printDisp = new DCCMN02000UA();
                            printDisp.ShowDialog(slipPrintCndtn, true);
                        }
                    }
                    #endregion
                }

            }
			catch (Exception ex)
			{
                hed.UpdRsl = -1;
                status = -1;
				message = ex.Message;
			}

            //����I����ݒ�
            if (status == (int)EnumUoeConst.Status.ct_NORMAL)
            {
                hed.UpdRsl = 0;
            }
            return (status);
        }
        # endregion
        # endregion


        # endregion
    }
}

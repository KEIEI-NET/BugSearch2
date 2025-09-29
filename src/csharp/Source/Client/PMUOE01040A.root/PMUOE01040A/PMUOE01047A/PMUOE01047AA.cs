//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �񓚃f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �񓚃f�[�^�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//           2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@�@  �쐬�S�� : �g�� 
// �C �� ��  2014/02/04  �C�����e : Redmine#41551 �V�X�e���e�X�g��Q��10
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@�@  �쐬�S�� : �g�� 
// �C �� ��  2014/02/12  �C�����e : Redmine#41551 �V�X�e���e�X�g��Q��10 �f�O���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ���� 
// �C �� ��  2014/09/19  �C�����e : Redmine#43265 �C�X�R�@UOE���M�����񓚉�ʂɂă��[�J�[�Ⴂ�̓���i�ԑI���E�B���h�E���\�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11575094-00 �쐬�S�� : �� 
// �C �� ��  2019/06/13  �C�����e : �单����i��Q�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �񓚃f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �񓚃f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// <br>Update Note : 2014/09/19 ����</br>
    /// <br>�Ǘ��ԍ�    : 11070149-00</br>
    /// <br>              Redmine#43265�̑Ή� �C�X�R�@UOE���M�����񓚉�ʂɂă��[�J�[�Ⴂ�̓���i�ԑI���E�B���h�E���\�������</br>
    /// </remarks>
	public partial class UOEAnswerAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UOEAnswerAcs()
		{
			//��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//���O�C�����_�R�[�h
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//�t�n�d�����f�[�^�A�N�Z�X�N���X
            this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();

            //�t�n�d����M���䏉�����N���X
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

            // 2009/05/25 START >>>>>>
            //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g�I�u�W�F�N�g
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            // 2009/05/25 END   <<<<<<
            // --- ADD 2019/06/13 ---------->>>>>
            //���엚�����O�f�[�^�A�N�Z�X�N���X
            this._uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
            // --- ADD 2019/06/13 ----------<<<<<
        }

        // 2009/05/25 START >>>>>>
        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static UOEAnswerAcs GetInstance()
        {
            if (_uOEAnswerAcs == null)
            {
                _uOEAnswerAcs = new UOEAnswerAcs();
            }
            return _uOEAnswerAcs;
        }
        // 2009/05/25 END   <<<<<<
        // --- ADD 2019/06/13 ---------->>>>>
        //���엚�����O�A�N�Z�X�N���X
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        // --- ADD 2019/06/13 ----------<<<<<

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//��ƃR�[�h
		private string _enterpriseCode = "";

		//���O�C�����_�R�[�h
		private string _loginSectionCd = "";

		//�t�n�d�����f�[�^�A�N�Z�X�N���X
		private UOEOrderDtlAcs _uOEOrderDtlAcs = null;

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //�t�n�d����M���䏉�����N���X
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        // 2009/05/25 START >>>>>>
        //�A�N�Z�X�N���X �C���X�^���X
        private static UOEAnswerAcs _uOEAnswerAcs = null;

        //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g
        private IIOWriteControlDB _iIOWriteControlDB = null;
        // 2009/05/25 END   <<<<<<
        # endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member
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
        # region ����M�i�m�k��DataSet��
        /// <summary>
        /// ����M�i�m�k��DataSet��
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region ����M�i�m�k(����)��DataTable��
        /// <summary>
        /// ����M�i�m�k(����)��DataTable��
        /// </summary>
        public DataTable OrderTable
        {
            get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region UOE������DataTable��
        /// <summary>
        /// UOE������DataTable��
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this.UoeJnlDataSet.Tables[UOEOrderDtlSchema.CT_UOEOrderDtlDataTable]; }
        }
        # endregion

        # region �d���f�[�^��DataTable��
        /// <summary>
        /// �d���f�[�^��DataTable��
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region �d�����ׁ�DataTable��
        /// <summary>
        /// �d�����ׁ�DataTable��
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods

		# region �񓚃f�[�^�̎擾(����I����)
        /// <summary>
        /// �񓚃f�[�^�̎擾(����I����)
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <param name="stockSlipGrpList">�d�����I�u�W�F�N�g</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpDtAnswerNormal(UOESupplier uOESupplier, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // �p�����[�^����������
                //-----------------------------------------------------------
                # region �p�����[�^����������
                StockSlipGrp stockSlipGrp = new StockSlipGrp();
                # endregion

                //-----------------------------------------------------------
                // ����M�i�m�k�̃t�B���^�E�\�[�g�ݒ�
                //-----------------------------------------------------------
                # region ����M�i�m�k�̃t�B���^�E�\�[�g�ݒ�
                // view���擾
                DataView view = GetOrderFormCreateView(0, 0, uOESupplier.UOESupplierCd);
                if ( view.Count == 0 ) return(status);

                Int32 uOESalesOrderNo = 0;
                Int32 savUOESalesOrderNo = 0;
                # endregion

                // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �d�����ݒ� (UOE�����f�[�^����A������t��ݒ�)
                DateTime stockDate = DateTime.Now;
                // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach (DataRowView dr in view)
                {
                    //-----------------------------------------------------------
                    // �t�n�d����DataTable��FIND����
                    //-----------------------------------------------------------
                    # region �t�n�d����DataTable��FIND����
                    // �t�n�d����DataTable��FIND����
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;

                    //�j�d�x���ڂ̎擾
                    uOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];           //UOE�����ԍ�
                    Int32 uOESalesOrderRowNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];  // UOE�����s�ԍ�
                    Int32 dataSendCode = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	        // �f�[�^���M�敪
                    Int32 dataRecoverDiv = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	    // �f�[�^�����敪

                    string substPartsNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo];         //��֕i��
                    Int32 answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd];         //�񓚃��[�J�[�R�[�h

                    # endregion

                    //-----------------------------------------------------------
                    //  �i�m�k���t�n�d�����f�[�^�̐ݒ�(����I����)
                    //-----------------------------------------------------------
                    # region  �i�m�k���t�n�d�����f�[�^�̐ݒ�(����I����)
                    # region ��֕i�Ԃ�ʲ�ݕt�i�Ԃւ̒u����������
                    //��֕i�Ԃ�ʲ�ݕt�i�Ԃւ̒u����������
                    //��֕i�Ԃ�����
                    //��֕i�ԂɃn�C�t���Ȃ�
                    if ((substPartsNo.Trim() != "") && (substPartsNo.IndexOf("-") == -1))
                    {
                        List<GoodsUnitData> list = null;
                        //status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list); // DEL 2014/09/19 ���� FOR Redmine#43265
                        // ------ ADD START 2014/09/19 ���� FOR Redmine#43265 ------>>>>>
                        List<Int32> makerCdLt = _uoeSndRcvCtlInitAcs.GetMakerCdLt(uOESupplier);
                        if (makerCdLt.Count == 0 && int.Parse(uOESupplier.CommAssemblyId) >= 1000)
                        {
                            status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list, answerMakerCd);
                        }
                        else
                        {
                            status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list);
                        }
                        // ------ ADD END 2014/09/19 ���� FOR Redmine#43265 ------<<<<<
                        //�I���Ȃ�
                        //�Y���i�ԂȂ�
                        if ((status == -1) || (status == 1) || (list == null))
                        {
                            answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];	//���������[�J�[�R�[�h
                            status = 0;
                        }
                        //�Y���i�Ԃ���
                        else if (list.Count > 0)
                        {
                            substPartsNo = list[0].GoodsNo;			//�i��
                            answerMakerCd = list[0].GoodsMakerCd;	//���[�J�[�R�[�h
                        }
                    }
                    # endregion

                    # region ���ɍX�V�t���O(1:���ɍ�)�̐ݒ�
                    //��������
                    int enterUpdDivSec = 0;		//���_
                    int enterUpdDivBO1 = 0;		//BO1
                    int enterUpdDivBO2 = 0;		//BO2
                    int enterUpdDivBO3 = 0;		//BO3
                    int enterUpdDivMaker = 0;	//Ұ��
                    int enterUpdDivEO = 0;		//EO

                    //�V�X�e���敪
                    Int32 systemDivCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SystemDivCd];

                    //���ɍX�V�t���O(1:���ɍ�)�̐ݒ�
                    int warehouseCode = 0;
                    UoeCommonFnc.ToInt32FromString((string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode], out warehouseCode);

                    //�����悪�����Y�Ƃ̏ꍇ(�d���f�[�^��M�敪��1:�L��)
                    //�V�X�e���敪���`��������
                    //�V�X�e���敪���i����́A���������j�̎��i
                    if((this._uoeSndRcvJnlAcs.ChkMeiji(uOESupplier) == true)
                    || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    || (((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                    || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search))
                        && (warehouseCode == 0)))
                    {
                        enterUpdDivSec = 1;		//���_
                        enterUpdDivBO1 = 1;		//BO1
                        enterUpdDivBO2 = 1;		//BO2
                        enterUpdDivBO3 = 1;		//BO3
                        enterUpdDivMaker = 1;	//Ұ��
                        enterUpdDivEO = 1;		//EO
                    }
                    //�V�X�e���敪���i����́A���������̍݌ɕi�j
                    //�V�X�e���敪���݌Ɉꊇ
                    else if ((((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
                            || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)) && (warehouseCode != 0))
                            || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Lump))
                    {
                        //���_
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] == 0) enterUpdDivSec = 1;
                        //BO1
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] == 0) enterUpdDivBO1 = 1;
                        //BO2
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] == 0) enterUpdDivBO2 = 1;
                        //BO3
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] == 0) enterUpdDivBO3 = 1;
                        //Ұ��
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] == 0) enterUpdDivMaker = 1;
                        //EO
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] == 0) enterUpdDivEO = 1;
                    }
                    # endregion

                    # region ����M�i�m�kDataTable�ݒ菈��
                    //����M�i�m�kDataTable�ݒ菈��
                    dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;	// �񓚃��[�J�[�R�[�h
                    dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = substPartsNo;	// ��֕i��
                    # endregion

                    # region �t�n�d����DataTable�ݒ菈��
                    //UOE�񓚃f�[�^��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate] = (DateTime)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate];	// ��M���t
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime];	// ��M����
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;	// �񓚃��[�J�[�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo];	// �񓚕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName];	// �񓚕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = substPartsNo;	// ��֕i��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE���_�o�ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];	// BO�o�ɐ�1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2];	// BO�o�ɐ�2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3];	// BO�o�ɐ�3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt];	// ���[�J�[�t�H���[��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt];	// ���o�ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt];	// UOE���_�݌ɐ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount1];	// BO�݌ɐ�1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount2];	// BO�݌ɐ�2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount3];	// BO�݌ɐ�3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];	// UOE���_�`�[�ԍ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];	// BO�`�[�ԍ��P
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2];	// BO�`�[�ԍ��Q
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3];	// BO�`�[�ԍ��R
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];	// EO������
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOManagementNo];	// BO�Ǘ��ԍ�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];	// �񓚒艿
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];	// �񓚌����P��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark];	// UOE��փ}�[�N
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEStockMark];	// UOE�݌Ƀ}�[�N
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd];	// �w�ʃR�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1];	// UOE���_�R�[�h�P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2];	// UOE���_�R�[�h�Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3];	// UOE���_�R�[�h�R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4];	// UOE���_�R�[�h�S�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5];	// UOE���_�R�[�h�T�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6];	// UOE���_�R�[�h�U�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7];	// UOE���_�R�[�h�V�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE�݌ɐ��P�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE�݌ɐ��Q�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE�݌ɐ��R�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE�݌ɐ��S�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE�݌ɐ��T�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE�݌ɐ��U�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE�݌ɐ��V�i�}�c�_�j
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd];	// UOE���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd];	// UOE���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEHMCd];	// UOE�g�l�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOCount];	// �a�n��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode];	// UOE�}�[�N�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment];	// �o�׌�
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_ItemCode];	// �A�C�e���R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode];	// UOE�`�F�b�N�R�[�h
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage];	// �w�b�h�G���[���b�Z�[�W
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage];	// ���C���G���[���b�Z�[�W

                    //�f�[�^�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = dataSendCode;	// �f�[�^���M�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = dataRecoverDiv;	// �f�[�^�����敪

                    //���ɍX�V�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = enterUpdDivSec;	// ���_
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = enterUpdDivBO1;	// BO1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = enterUpdDivBO2;	// BO2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = enterUpdDivBO3;	// BO3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = enterUpdDivMaker;	// Ұ��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = enterUpdDivEO;	// EO
                    # endregion

                    # region �t�n�d����(DataTable��UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion

                    //-----------------------------------------------------------
                    // �d���f�[�^�̍쐬
                    //-----------------------------------------------------------
                    # region �d���f�[�^�쐬
                    // UOE�����ԍ����ς�����ꍇ
                    if ((savUOESalesOrderNo != 0)
                    && (uOESalesOrderNo != 0)
                    && (uOESalesOrderNo != savUOESalesOrderNo))
                    {
                        //�d���f�[�^�v�������̍쐬
                        StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                                uOESupplier.UOESupplierCd,
                                                                savUOESalesOrderNo,
                                                                out message);
                        if (stockSlipWork == null)
                        {
                            return (-1);
                        }

                        //���X�g�ǉ�
                        stockSlipGrp.stockSlipWork = stockSlipWork;
                        stockSlipGrpList.Add(stockSlipGrp);
                        stockSlipGrp = new StockSlipGrp();
                    }
                    //���ݏ�������UOE�����ԍ���ۑ�
                    savUOESalesOrderNo = uOESalesOrderNo;
                    # endregion

                    //-----------------------------------------------------------
                    // �d�����ׂ̍쐬
                    //-----------------------------------------------------------
                    # region �d�����ׂ̍쐬
                    # region �d������(�i�m�k��DataTable)
                    //�t�n�d������̑��M�敪������ �����敪�������ΏۊO�̃��R�[�h�̂ݎd�����ׂ̍X�V�����{
                    //if ((dataSendCode != (int)EnumUoeConst.ctDataSendCode.ct_OK)
                    //|| (dataRecoverDiv != (int)EnumUoeConst.ctDataRecoverDiv.ct_NO))
                    //{
                    //    continue;
                    //}

                    // �i�m�k���d������
                    object[] findStockDetail = new object[2];
                    findStockDetail[0] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SupplierFormal];
                    findStockDetail[1] = (Guid)dr[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid];
                    DataRow stockDetailRow = StockDetailTable.Rows.Find(findStockDetail);
                    if (stockDetailRow == null) continue;

                    // �d������̎擾
                    int supplierCd = (int)stockDetailRow[StockDetailSchema.ct_Col_SupplierCd];
                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(supplierCd);

                    //���ʓ`�[�ԍ��̐ݒ�
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo] = uOESalesOrderNo;

                    //���ʓ`�[�s�ԍ��̐ݒ�
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipRowNo] = uOESalesOrderRowNo;

                    //-----------------------------------------------------------
                    // ������
                    //-----------------------------------------------------------
                    #region �������̐ݒ�
                    //�������̐ݒ�
                    Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];
                    stockDetailRow[StockDetailSchema.ct_Col_OrderCnt] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_StockCount] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_OrderRemainCnt] = (double)cnt;
                    #endregion

                    //-----------------------------------------------------------
                    // �ېŋ敪�̎Z�o(0:�ې�,1:��ې�,2:�ېŁi���Łj)
                    //-----------------------------------------------------------
                    #region �ېŋ敪�̎Z�o
                    int dstTaxationCode = (int)stockDetailRow[StockDetailSchema.ct_Col_TaxationCode];

                    if ((supplier.SuppCTaxLayCd == 9)
                    || (supplier.SuppCTaxationCd == 1)
                    || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // �艿
                    //-----------------------------------------------------------
                    #region �艿
                    // DEL 2014/02/12 �g�� #41551 �V�X�e���e�X�g��Q��10 �f�O���Ή� ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �d�����ݒ� (UOE�����f�[�^����A������t��ݒ�)
                    //if (uOEOrderDtlWork != null && uOEOrderDtlWork.SalesDate != DateTime.MinValue)
                    //{
                    //    stockDate = uOEOrderDtlWork.SalesDate;
                    //}
                    // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    # endregion
                    // DEL 2014/02/12 �g�� #41551 �V�X�e���e�X�g��Q��10 �f�O���Ή� ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2014/02/12 �g�� #41551 �V�X�e���e�X�g��Q��10 �f�O���Ή� ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �d�����ݒ� (UOE�����f�[�^����A������t��ݒ�)
                    // �`���v��� �}�V�����t�F�O�@���`���t�F�P
                    if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv.Equals(1))
                    {
                        if (uOEOrderDtlWork != null && uOEOrderDtlWork.SalesDate != DateTime.MinValue)
                        {
                            stockDate = uOEOrderDtlWork.SalesDate;
                        }
                    }
                    // ADD 2014/02/12 �g�� #41551 �V�X�e���e�X�g��Q��10 �f�O���Ή� ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    
                    //�艿�i�Ŕ��C�����j
                    double dstPrice = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];
                    
                    stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = dstPrice;
                    
                    //�艿�i�ō��C�����j
                    if(supplier != null)
                    {
                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                        stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd, stockDate);
                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }   
                    #endregion

                    //-----------------------------------------------------------
                    // �d���P���ύX�敪
                    //-----------------------------------------------------------
                    #region �d���P���ύX�敪
                    //�d���P���ύX�敪
                    //�ύX�O�����Ɖ񓚌������قȂ�

                    double srcCost = (double)stockDetailRow[StockDetailSchema.ct_Col_BfStockUnitPriceFl];
                    double dstCost = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];

                    if(srcCost != dstCost)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 1;
                    }
                    //�ύX�O�����Ɖ񓚌���������
                    else
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 0;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // �d���P��
                    //-----------------------------------------------------------
                    #region �d���P��
                    //�d���P���i�Ŕ��C�����j
                    stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl] = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];

                    //�d���P���i�ō��C�����j
                    if (supplier != null)
                    {
                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd, stockDate);
                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
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

                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        #region ���\�[�X
                        //bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                        //    (double)cnt,
                        //    (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                        //    dstTaxationCode,
                        //    supplier.StockMoneyFrcProcCd,
                        //    supplier.StockCnsTaxFrcProcCd,
                        //    out stockPriceTaxInc,
                        //    out stockPriceTaxExc,
                        //    out stockPriceConsTax);
                        #endregion
                        bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                            (double)cnt,
                            (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                            dstTaxationCode,
                            supplier.StockMoneyFrcProcCd,
                            supplier.StockCnsTaxFrcProcCd,
                            stockDate,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax);
                        // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (bStatus == true)
                        {
                            //�d�����z�i�Ŕ����j
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                            //�d�����z�i�ō��݁j
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
                        }
                        else
                        {
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
                        }
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // ����ł̎Z�o
                    //-----------------------------------------------------------
                    #region �����
                    //�d�����z����Ŋz
                    stockDetailRow[StockDetailSchema.ct_Col_StockPriceConsTax] = (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc]
                                                                               - (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc];
                    #endregion

                    # endregion

                    # region �d������(DataTable��StockDetailWork)
                    StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(stockDetailRow);
                    stockSlipGrp.stockDetailWorkList.Add(stockDetailWork);
                    # endregion
                    # endregion
                }
                //-----------------------------------------------------------
                // �d���f�[�^�̍쐬
                //-----------------------------------------------------------
                # region �d���f�[�^�쐬
                if((savUOESalesOrderNo != 0) && (uOESalesOrderNo != 0))
                {
                    //�d���f�[�^�v�������̍쐬
                    // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                    //                    uOESupplier.UOESupplierCd,
                    //                    savUOESalesOrderNo,
                    //                    out message);
                    StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                            uOESupplier.UOESupplierCd,
                                                            savUOESalesOrderNo,
                                                            out message,
                                                            stockDate);
                    // UPD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                    if (stockSlipWork == null)
                    {
                        return (-1);
                    }

                    //���X�g�ǉ�
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrpList.Add(stockSlipGrp);
                    stockSlipGrp = new StockSlipGrp();
                }
                # endregion

            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
        }
        # endregion


		# region �񓚃f�[�^�̎擾(�����Ώە�)
        /// <summary>
        /// �񓚃f�[�^�̎擾(�����Ώە�)
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpDtAnswerRecover(UOESupplier uOESupplier, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // ����M�i�m�k�̃t�B���^�E�\�[�g�ݒ�
                //-----------------------------------------------------------
                # region ����M�i�m�k�̃t�B���^�E�\�[�g�ݒ�
                // view���擾
                DataView view = GetOrderFormCreateView(1, 0, uOESupplier.UOESupplierCd);
                if ( view.Count == 0 ) return(status);
                # endregion

                foreach (DataRowView dr in view)
                {
                    //-----------------------------------------------------------
                    // �t�n�d����DataTable��FIND����
                    //-----------------------------------------------------------
                    # region �t�n�d����DataTable��FIND����
                    // �t�n�d����DataTable��FIND����
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;

                    //�j�d�x���ڂ̎擾
                    Int32 dataSendCode = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	        // �f�[�^���M�敪
                    Int32 dataRecoverDiv = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	    // �f�[�^�����敪
                    # endregion

                    //-----------------------------------------------------------
                    //  �i�m�k���t�n�d�����f�[�^�̐ݒ�(�����Ώە�)
                    //-----------------------------------------------------------
                    # region  �i�m�k���t�n�d�����f�[�^�̐ݒ�(�����Ώە�)
                    # region �t�n�d����DataTable�ݒ菈��
                    //�t�n�d����DataTable�ݒ菈��
                    //UOE�����f�[�^��
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SendTerminalNo] = 0;	// ���M�[���ԍ��̃N���A

                    //�f�[�^�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = dataSendCode;	// �f�[�^���M�敪
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = dataRecoverDiv;	// �f�[�^�����敪
                    # endregion

                    # region �t�n�d����(DataTable��UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion
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

		# region �񓚃f�[�^�̍X�V����
		/// <summary>
		/// �񓚃f�[�^�X�V����
		/// </summary>
		/// <param name="orderSndRcvJnlList">����M�i�m�k�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>0:���� 0�ȊO:�G���[</returns>
		public int UpDtAnswer(UOESupplier uOESupplier, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // �p�����[�^����������
                //-----------------------------------------------------------
                # region �p�����[�^����������
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();
                # endregion

                //-----------------------------------------------------------
                // �񓚃f�[�^�̎擾(����I����)
                //-----------------------------------------------------------
                # region �񓚃f�[�^�̎擾(����I����)
                status = UpDtAnswerNormal(uOESupplier, ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �񓚃f�[�^�̎擾(�����Ώە�)
                //-----------------------------------------------------------
                # region �񓚃f�[�^�̎擾(�����Ώە�)
                status = UpDtAnswerRecover(uOESupplier, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �񓚃f�[�^�X�V����
                //-----------------------------------------------------------
                # region �񓚃f�[�^�X�V����
                status = _uOEOrderDtlAcs.Write(ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // �X�V���ʁ�Datatable
                //-----------------------------------------------------------
                # region �X�V���ʁ�Datatable
                if((stockSlipGrpList == null) || (uOEOrderDtlWorkList == null))
                {
                    return (status);
                }
                if ((stockSlipGrpList.Count == 0) && (uOEOrderDtlWorkList.Count == 0))
                {
                    return (status);
                }

                //�t�n�d�����f�[�^���t�n�d�����f�[�^�e�[�u���̍X�V 
                status = _uoeSndRcvJnlAcs.UpdateTableFromUOEOrderDtlList(uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                foreach (StockSlipGrp grp in stockSlipGrpList)
                {
                    //�d�����ׁ��d�����׃e�[�u���̍X�V
                    // --- ADD 2019/06/13 ---------->>>>>
                    string asseNm = "���ɍX�V";
                    string procNm = "UpDtAnswer";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uOESupplier.UOESupplierCd);
                    // --- ADD 2019/06/13 ----------<<<<<
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailList(StockDetailTable, grp.stockDetailWorkList, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    // --- ADD 2019/06/13 ---------->>>>>
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "", uOESupplier.UOESupplierCd);
                    // --- ADD 2019/06/13 ----------<<<<<

                    //�d���f�[�^���d���f�[�^�e�[�u���̍X�V
                    if (grp.stockSlipWork != null)
                    {
                        //�d�����ׂ�苤�ʓ`�[�ԍ����擾
                        StockDetailWork work = null;
                        string commonSlipNo = "";

                        status = _uoeSndRcvJnlAcs.ReadStockDetailWork(
                                        StockDetailTable,
                                        grp.stockDetailWorkList[0].SupplierFormal,
                                        grp.stockDetailWorkList[0].DtlRelationGuid,
                                        out work,
                                        out commonSlipNo,
                                        out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }

                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockSlipWork(StockSlipTable, grp.stockSlipWork, commonSlipNo, out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion
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
        # region �d���f�[�^�쐬(DataTable)

        // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d���f�[�^�쐬(DataTable)
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="stockDate">�d����</param>
        /// <returns>�X�^�[�^�X</returns>
        private StockSlipWork GetStockSlipWorkFromStockDetailDataTable(int uOESupplierCd, int uOESalesOrderNo, out string message, DateTime stockDate)
        {
            //�ϐ��̏�����
            StockSlipWork rst = new StockSlipWork();
            message = "";

            try
            {
                //-----------------------------------------------------------
                // �d�����ׂ̎擾
                //-----------------------------------------------------------
                # region �d�����ׂ̎擾
                DataView view = GetStockDetailFormCreateView(uOESupplierCd, uOESalesOrderNo);
                int detailCount = view.Count;
                if (detailCount == 0) return (null);

                List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                StockDetailWork stockDetailWork = null;
                foreach (DataRowView dataRowView in view)
                {
                    stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                    uoeStockDetailWorkList.Add(stockDetailWork);
                }
                #endregion

                //-----------------------------------------------------------
                // ����M�i�m�k�̎擾
                //-----------------------------------------------------------
                # region ����M�i�m�k�̎擾
                DataView orderView = GetOrderFormCreateView(uOESupplierCd, uOESalesOrderNo);
                if (orderView == null) return (null);
                if (orderView.Count == 0) return (null);
                DataRow uOEOrderDtlRow = orderView[0].Row;
                #endregion

                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^�̎擾
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // �d������̎擾
                //-----------------------------------------------------------
                #region �d������̐ݒ�
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockDetailWork.SupplierCd);
                if (supplier == null)
                {
                    message = "�d���悪���݂��܂���B";
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̐ݒ�
                //-----------------------------------------------------------
                # region �d���f�[�^�̐ݒ�
                rst.EnterpriseCode = this._enterpriseCode;                                  // ��ƃR�[�h
                rst.SupplierFormal = 2;	                                                    // �d���`���@���@2:����
                rst.SupplierSlipNo = stockDetailWork.SupplierSlipNo;	                    // �d���`�[�ԍ�
                rst.SectionCode = this._loginSectionCd;	                                    // ���_�R�[�h
                rst.SubSectionCode = stockDetailWork.SubSectionCode;	                    // ����R�[�h
                rst.DebitNoteDiv = 0;	                                                    // �ԓ`�敪 ���@0:���`
                rst.DebitNLnkSuppSlipNo = 0;	                                            // �ԍ��A���d���`�[�ԍ�
                rst.SupplierSlipCd = 10;	                                                // �d���`�[�敪�@���@10:�d��
                rst.StockGoodsCd = 0;	                                                    // �d�����i�敪�@���@0:���i
                rst.AccPayDivCd = 1;	                                                    // ���|�敪�@���@1:���|
                rst.StockSectionCd = _loginSectionCd;	                                    // �d�����_�R�[�h
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // �d���v�㋒�_�R�[�h
                rst.StockSlipUpdateCd = 0;	                                                // �d���`�[�X�V�敪 0:���X�V
                rst.InputDay = DateTime.Now;	                                            // ���͓��@���@�V�X�e�����t
                rst.ArrivalGoodsDay = DateTime.MinValue;	                                // ���ד�
                rst.StockDate = DateTime.MinValue;	                                        // �d����
                rst.StockAddUpADate = DateTime.MinValue;	                                // �d���v����t
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
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(stockDate) ;	    // �d�������Őŗ�
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
                rst.PartySaleSlipNum = string.Empty;	                                    // �����`�[�ԍ�
                rst.SupplierSlipNote1 = string.Empty;	                                    // �d���`�[���l1
                rst.SupplierSlipNote2 = string.Empty;	                                    // �d���`�[���l2
                rst.DetailRowCount = detailCount;	                                        // ���׍s���@���@�s���J�E���g�l
                rst.EdiSendDate = DateTime.MinValue;	                                    // �d�c�h���M��
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // �d�c�h�捞��
                rst.UoeRemark1 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// �t�n�d���}�[�N�P
                rst.UoeRemark2 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// �t�n�d���}�[�N�Q
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
                                            uoeStockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
            catch (Exception ex)
            {
                message = ex.Message;
                rst = null;
            }
            return (rst);
        }
        // ADD 2014/02/04 �g�� #41551 �V�X�e���e�X�g��Q��10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �d���f�[�^�쐬(DataTable)
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�^�[�^�X</returns>
        private StockSlipWork GetStockSlipWorkFromStockDetailDataTable(int uOESupplierCd, int uOESalesOrderNo, out string message)
        {
            //�ϐ��̏�����
            StockSlipWork rst = new StockSlipWork();
  			message = "";

            try
            {
                //-----------------------------------------------------------
                // �d�����ׂ̎擾
                //-----------------------------------------------------------
                # region �d�����ׂ̎擾
                DataView view = GetStockDetailFormCreateView(uOESupplierCd, uOESalesOrderNo);
                int detailCount = view.Count;
                if (detailCount == 0) return (null);

                List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                StockDetailWork stockDetailWork = null;
                foreach (DataRowView dataRowView in view)
                {
                    stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                    uoeStockDetailWorkList.Add(stockDetailWork);
                }
                #endregion

                //-----------------------------------------------------------
                // ����M�i�m�k�̎擾
                //-----------------------------------------------------------
                # region ����M�i�m�k�̎擾
                DataView orderView = GetOrderFormCreateView(uOESupplierCd, uOESalesOrderNo);
                if (orderView == null)  return(null);
                if (orderView.Count == 0)  return(null);
                DataRow uOEOrderDtlRow = orderView[0].Row;
                #endregion

                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^�̎擾
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // �d������̎擾
                //-----------------------------------------------------------
                #region �d������̐ݒ�
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockDetailWork.SupplierCd);
                if (supplier == null)
                {
                    message = "�d���悪���݂��܂���B";
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // �d���f�[�^�̐ݒ�
                //-----------------------------------------------------------
                # region �d���f�[�^�̐ݒ�
                rst.EnterpriseCode = this._enterpriseCode;                                  // ��ƃR�[�h
                rst.SupplierFormal = 2;	                                                    // �d���`���@���@2:����
                rst.SupplierSlipNo = stockDetailWork.SupplierSlipNo;	                    // �d���`�[�ԍ�
                rst.SectionCode = this._loginSectionCd;	                                    // ���_�R�[�h
                rst.SubSectionCode = stockDetailWork.SubSectionCode;	                    // ����R�[�h
                rst.DebitNoteDiv = 0;	                                                    // �ԓ`�敪 ���@0:���`
                rst.DebitNLnkSuppSlipNo = 0;	                                            // �ԍ��A���d���`�[�ԍ�
                rst.SupplierSlipCd = 10;	                                                // �d���`�[�敪�@���@10:�d��
                rst.StockGoodsCd = 0;	                                                    // �d�����i�敪�@���@0:���i
                rst.AccPayDivCd = 1;	                                                    // ���|�敪�@���@1:���|
                rst.StockSectionCd = _loginSectionCd;	                                    // �d�����_�R�[�h
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // �d���v�㋒�_�R�[�h
                rst.StockSlipUpdateCd = 0;	                                                // �d���`�[�X�V�敪 0:���X�V
                rst.InputDay = DateTime.Now;	                                            // ���͓��@���@�V�X�e�����t
                rst.ArrivalGoodsDay = DateTime.MinValue;	                                // ���ד�
                rst.StockDate = DateTime.MinValue;	                                        // �d����
                rst.StockAddUpADate = DateTime.MinValue;	                                // �d���v����t
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
                rst.SalesAreaName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(21,supplier.SalesAreaCode);	// �̔��G���A����

                rst.StockInputCode = stockDetailWork.StockInputCode;	                    // �d�����͎҃R�[�h
                rst.StockInputName = stockDetailWork.StockInputName;	                    // �d�����͎Җ���
                rst.StockAgentCode = stockDetailWork.StockAgentCode;	                    // �d���S���҃R�[�h
                rst.StockAgentName = stockDetailWork.StockAgentName;	                    // �d���S���Җ���

                rst.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;	                    // �d���摍�z�\�����@�敪
                rst.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;	                    // ���z�\���|���K�p�敪


                rst.TaxAdjust = 0;	                                                        // ����Œ����z
                rst.BalanceAdjust = 0;	                                                    // �c�������z
                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // �d�������œ]�ŕ����R�[�h
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);;	// �d�������Őŗ�
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
                rst.PartySaleSlipNum = string.Empty;	                                    // �����`�[�ԍ�
                rst.SupplierSlipNote1 = string.Empty;	                                    // �d���`�[���l1
                rst.SupplierSlipNote2 = string.Empty;	                                    // �d���`�[���l2
                rst.DetailRowCount = detailCount;	                                        // ���׍s���@���@�s���J�E���g�l
                rst.EdiSendDate = DateTime.MinValue;	                                    // �d�c�h���M��
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // �d�c�h�捞��
                rst.UoeRemark1 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// �t�n�d���}�[�N�P
                rst.UoeRemark2 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// �t�n�d���}�[�N�Q
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
                                            uoeStockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
			catch (Exception ex)
			{
				message = ex.Message;
                rst = null;
			}
            return (rst);
        }

        # endregion

        # region �d�����ׂ̒��o
        /// <summary>
        /// �d�����ׂ̒��o
        /// </summary>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <returns>�񓚍X�V�Ώۃf�[�^</returns>
        private DataView GetStockDetailFormCreateView(int uOESupplierCd, int uOESalesOrderNo)
        {
            DataView view = new DataView(this.StockDetailTable);

            // �t�B���^�[�ݒ�
            string rowFilterText = string.Format("{0} = {1}",
                                            StockDetailSchema.ct_Col_CommonSlipNo, uOESalesOrderNo            
                                            );
            view.RowFilter = rowFilterText;

            // �\�[�g���ݒ�
            string sortText = string.Format("{0}, {1}",
                                            StockDetailSchema.ct_Col_CommonSlipNo,
                                            StockDetailSchema.ct_Col_CommonSlipRowNo
                                            );
            view.Sort = sortText;

            return view;
        }
        # endregion

        # region �񓚍X�V�Ώۃf�[�^�̒��o
        /// <summary>
        /// �񓚍X�V�Ώۃf�[�^�̒��o
        /// </summary>
        /// <param name="filterMode">0:����I�� 1:�����Ώ�</param>
        /// <param name="uOEKind">UOE���</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <returns>�񓚍X�V�Ώۃf�[�^</returns>
        private DataView GetOrderFormCreateView(int filterMode, int uOEKind, int uOESupplierCd)
        {
            DataView view = new DataView(this.OrderTable);
            string rowFilterText = "";

            // �t�B���^�[�ݒ�
            // �uUOE���+UOE������R�[�h+�f�[�^���M�敪+�f�[�^�����敪�v�Ńt�B���^��������
            //����I��
            if (filterMode == 0)
            {
                rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} <> {5} AND {6} <> {7} AND {8} = {9}",
                                                OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_NonProcess,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO
                                                );
            }
            //�����Ώ�
            else
            {
                rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} <> {5} AND {6} <> {7} AND {8} = {9}",
                                                OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_NonProcess,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_YES
                                                );
            }
            view.RowFilter = rowFilterText;

            // �\�[�g���ݒ�
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// �񓚍X�V�Ώۃf�[�^�̒��o
        /// </summary>
        /// <param name="uOEKind">UOE���</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="uOESalesOrderRowNo">UOE�����s�ԍ�</param>
        /// <returns>�񓚍X�V�Ώۃf�[�^</returns>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        private DataView GetOrderFormCreateView(int uOESupplierCd, int uOESalesOrderNo)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, uOESalesOrderNo
                                            );


            // �\�[�g���ݒ�
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.Sort = sortText;
            view.RowFilter = rowFilterText; // ADD wangyl 2013/02/06 Redmine#34578
            return view;
        }
    	# endregion
       // --- ADD 2019/06/13 ---------->>>>>
        # region �c�r�o���O��������
        /// <summary>
        /// �c�r�o���O��������
        /// </summary>
        /// <param name="logDataObjProcNm">������</param>
        /// <param name="logDataObjAssemblyNm">�A�Z���u����</param>
        /// <param name="logDataOperationCd">����R�[�h</param>
        /// <param name="logOperationStatus">�X�e�[�^�X</param>
        /// <param name="logDataMassage">���b�Z�[�W</param>
        /// <param name="uOESupplierCd">�d����R�[�h</param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, uOESupplierCd);
        }
        # endregion
        // --- ADD 2019/06/13 ----------<<<<<

        # endregion
	}
}

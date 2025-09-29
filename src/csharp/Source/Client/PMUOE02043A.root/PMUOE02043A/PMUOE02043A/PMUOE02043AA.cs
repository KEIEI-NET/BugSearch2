using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// ���s�m�F�ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note       : ���s�m�F�ꗗ�\�A�N�Z�X�N���X</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>UpdateNote : 2008.12.24  30009 �a�J ���</br>
    /// <br>           : �E�s��̏C��</br>
    /// <br>UpdateNote : 2009.01.13  30009 �a�J ���</br>
    /// <br>           : �E�s��̏C��</br>
    /// <br></br>
    /// </remarks>
    public class PublicationConfListAcs
    {
        # region Constractor
        /// <summary>
        /// ���s�m�F�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���s�m�F�ꗗ�\�A�N�Z�X�N���X</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br></br>
        /// </remarks>
        public PublicationConfListAcs()
        {
            this._iPublicationConfOrderWorkDB = (IPublicationConfOrderWorkDB)MediationPublicationConfOrderWorkDB.GetPublicationConfOrderWorkDB();
        }
        # endregion

        # region Static Constractor
        /// <summary>
		/// ���s�m�F�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���s�m�F�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		static PublicationConfListAcs()
		{
			// �]�ƈ����
			stc_Employee		= null;

			// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSet		= null;
			
			// ���[�o�͐ݒ�A�N�Z�X�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();

			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null) stc_Employee = loginEmployee.Clone();
		}
		# endregion

		# region Private Menbers
		/// <summary> ���s�m�F�ꗗ�\�����[�g�C���^�[�t�F�[�X </summary>
        IPublicationConfOrderWorkDB _iPublicationConfOrderWorkDB;
		/// <summary> �݌ɒ����m�F�f�[�^�Z�b�g </summary>
        private DataSet _PublicationConfDs;

        # endregion

		# region Static Private Member
		/// <summary> �]�ƈ���� </summary>
		private static Employee stc_Employee;
		/// <summary> ���[�o�͐ݒ�f�[�^�N���X </summary>
		private static PrtOutSet stc_PrtOutSet;
		/// <summary> ���[�o�͐ݒ�A�N�Z�X�N���X </summary>
		private static PrtOutSetAcs stc_PrtOutSetAcs;
		# endregion

		# region Public Property
		/// <summary>
		/// �݌ɒ����m�F�f�[�^�Z�b�g(get)
		/// </summary>
        public DataSet PublicationConfDs
		{
            get { return this._PublicationConfDs; }
		}
		# endregion

		# region Public Method
		/// <summary>
		/// �݌ɒ����m�F�f�[�^�擾
		/// </summary>
        /// <param name="publicationConfOrderCndtn">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������݌ɒ����m�F�f�[�^���擾����B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        public int SearchConfirmPublicationConf(PublicationConfOrderCndtn publicationConfOrderCndtn, out string errMsg)
		{
            return this.SearchConfirmPublicationConfProc(publicationConfOrderCndtn, out errMsg);
		}
		# endregion

		# region Public static Method
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";

			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone();
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
				else
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						default:
							errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		# endregion

		# region Private Method
		/// <summary>
		/// ���s�m�F�f�[�^�擾
		/// </summary>
        /// <param name="publicationConfOrderCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������݌ɒ����m�F�f�[�^���擾����B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int SearchConfirmPublicationConfProc(PublicationConfOrderCndtn publicationConfOrderCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
                PMUOE02049EA.CreateDataTablePublicationConfDtl(ref this._PublicationConfDs);
                PublicationConfOrderCndtnWork publicationConfOrderCndtnWork = new PublicationConfOrderCndtnWork();

				// ���o�����W�J����
                status = this.DevConfirmPublicationConfCndtn(publicationConfOrderCndtn, out publicationConfOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

				// �f�[�^�擾  ----------------------------------------------------------------
                object retpublicationConfList = null;
                status = this._iPublicationConfOrderWorkDB.Search(out retpublicationConfList, (object)publicationConfOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //test @@status = this.GetTestData(out retpublicationConfList);//@@test

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

						// ���s�m�F�f�[�^�W�J����
                        this.DevPublicationConfData(publicationConfOrderCndtn, this._PublicationConfDs.Tables[PMUOE02049EA.ct_Tbl_PublicationConfDtl], (ArrayList)retpublicationConfList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "���s�m�F�f�[�^�̎擾�Ɏ��s���܂����B";
						break;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		# region �e�X�g�p


        /// <summary>
        /// �e�X�g�p���s�m�F�f�[�^�擾
        /// </summary>
        /// <param name="retpublicationConfList"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �e�X�g�p�݌ɒ����m�F�f�[�^���擾����B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int GetTestData(out object retpublicationConfList)
        {
            ArrayList list = new ArrayList();

            PublicationConfResultWork work01 = new PublicationConfResultWork();
            work01.SectionCode = "01";
            work01.SectionGuideSnm = "���_01";
            work01.OnlineNo = 100;
            work01.OnlineRowNo = 0;
            work01.SystemDivCd = 0;
            work01.GoodsNo = "30009-ACB100";
            work01.WarehouseCode = "0001";
            work01.WarehouseShelfNo = "01";
            work01.ListPrice = 10000;
            work01.AcceptAnOrderCnt = 100;
            work01.UOESectOutGoodsCnt = 120;
            work01.BOShipmentCnt1 = 150;
            work01.BOShipmentCnt2 = 155;
            work01.BOShipmentCnt3 = 156;
            work01.MakerFollowCnt = 158;
            work01.EOAlwcCount = 156;
            work01.UOESupplierName = "UOE������";
            work01.ReceiveDate = DateTime.Now.Date;
            work01.UoeRemark1 = "rem01";
            work01.UoeRemark2 = "rem02";
            work01.AnswerPartsNo = "30009-ACB100";
            work01.AnswerPartsName = "�i��30009-ACB100�i��";
            work01.AnswerListPrice = 10000;
            work01.AnswerSalesUnitCost = 8000;
            work01.UOESectionSlipNo = "1234567";
            work01.BOSlipNo1 = "111111";
            work01.BOSlipNo2 = "222222";
            work01.BOSlipNo3 = "333333";
            work01.BOManagementNo = "444444";
            list.Add(work01);

            PublicationConfResultWork work02 = new PublicationConfResultWork();
            work02.SectionCode = "01";
            work02.SectionGuideSnm = "���_01";
            work02.OnlineNo = 100;
            work02.OnlineRowNo = 1;
            work02.SystemDivCd = 0;
            work02.GoodsNo = "30009-ACB100";
            work02.WarehouseCode = "0001";
            work02.WarehouseShelfNo = "01";
            work02.ListPrice = 10000;
            work02.AcceptAnOrderCnt = 100;
            work02.UOESectOutGoodsCnt = 120;
            work02.BOShipmentCnt1 = 150;
            work02.BOShipmentCnt2 = 155;
            work02.BOShipmentCnt3 = 156;
            work02.MakerFollowCnt = 158;
            work02.EOAlwcCount = 156;
            work02.UOESupplierName = "UOE������";
            work02.ReceiveDate = DateTime.Now.Date;
            work02.UoeRemark1 = "rem01";
            work02.UoeRemark2 = "rem02";
            work02.AnswerPartsNo = "30009-ACB100";
            work02.AnswerPartsName = "�i��30009-ACB100�i��";
            work02.AnswerListPrice = 10000;
            work02.AnswerSalesUnitCost = 8000;
            work02.UOESectionSlipNo = "1234567";
            work02.BOSlipNo1 = "111111";
            work02.BOSlipNo2 = "222222";
            work02.BOSlipNo3 = "333333";
            work02.BOManagementNo = "444444";
            list.Add(work02);

            PublicationConfResultWork work03 = new PublicationConfResultWork();
            work03.SectionCode = "01";
            work03.SectionGuideSnm = "���_01";
            work03.OnlineNo = 100;
            work03.OnlineRowNo = 2;
            work03.SystemDivCd = 0;
            work03.GoodsNo = "30009-ACB100";
            work03.WarehouseCode = "0001";
            work03.WarehouseShelfNo = "01";
            work03.ListPrice = 10000;
            work03.AcceptAnOrderCnt = 100;
            work03.UOESectOutGoodsCnt = 120;
            work03.BOShipmentCnt1 = 150;
            work03.BOShipmentCnt2 = 155;
            work03.BOShipmentCnt3 = 156;
            work03.MakerFollowCnt = 158;
            work03.EOAlwcCount = 156;
            work03.UOESupplierName = "UOE������";
            work03.ReceiveDate = DateTime.Now.Date;
            work03.UoeRemark1 = "rem01";
            work03.UoeRemark2 = "rem02";
            work03.AnswerPartsNo = "30009-ACB100";
            work03.AnswerPartsName = "�i��30009-ACB100�i��";
            work03.AnswerListPrice = 10000;
            work03.AnswerSalesUnitCost = 8000;
            work03.UOESectionSlipNo = "1234567";
            work03.BOSlipNo1 = "111111";
            work03.BOSlipNo2 = "222222";
            work03.BOSlipNo3 = "333333";
            work03.BOManagementNo = "444444";
            list.Add(work03);

            PublicationConfResultWork work04 = new PublicationConfResultWork();
            work04.SectionCode = "01";
            work04.SectionGuideSnm = "���_01";
            work04.OnlineNo = 100;
            work04.OnlineRowNo = 3;
            work04.SystemDivCd = 0;
            work04.GoodsNo = "30009-ACB100";
            work04.WarehouseCode = "0001";
            work04.WarehouseShelfNo = "01";
            work04.ListPrice = 10000;
            work04.AcceptAnOrderCnt = 100;
            work04.UOESectOutGoodsCnt = 120;
            work04.BOShipmentCnt1 = 150;
            work04.BOShipmentCnt2 = 155;
            work04.BOShipmentCnt3 = 156;
            work04.MakerFollowCnt = 158;
            work04.EOAlwcCount = 156;
            work04.UOESupplierName = "UOE������";
            work04.ReceiveDate = DateTime.Now.Date;
            work04.UoeRemark1 = "rem01";
            work04.UoeRemark2 = "rem02";
            work04.AnswerPartsNo = "30009-ACB100";
            work04.AnswerPartsName = "�i��30009-ACB100�i��";
            work04.AnswerListPrice = 10000;
            work04.AnswerSalesUnitCost = 8000;
            work04.UOESectionSlipNo = "1234567";
            work04.BOSlipNo1 = "111111";
            work04.BOSlipNo2 = "222222";
            work04.BOSlipNo3 = "333333";
            work04.BOManagementNo = "444444";
            list.Add(work04);

            PublicationConfResultWork work05 = new PublicationConfResultWork();
            work05.SectionCode = "01";
            work05.SectionGuideSnm = "���_01";
            work05.OnlineNo = 100;
            work05.OnlineRowNo = 4;
            work05.SystemDivCd = 0;
            work05.GoodsNo = "30009-ACB100";
            work05.WarehouseCode = "0001";
            work05.WarehouseShelfNo = "01";
            work05.ListPrice = 10000;
            work05.AcceptAnOrderCnt = 100;
            work05.UOESectOutGoodsCnt = 120;
            work05.BOShipmentCnt1 = 150;
            work05.BOShipmentCnt2 = 155;
            work05.BOShipmentCnt3 = 156;
            work05.MakerFollowCnt = 158;
            work05.EOAlwcCount = 156;
            work05.UOESupplierName = "UOE������";
            work05.ReceiveDate = DateTime.Now.Date;
            work05.UoeRemark1 = "rem01";
            work05.UoeRemark2 = "rem02";
            work05.AnswerPartsNo = "30009-ACB100";
            work05.AnswerPartsName = "�i��30009-ACB100�i��";
            work05.AnswerListPrice = 10000;
            work05.AnswerSalesUnitCost = 8000;
            work05.UOESectionSlipNo = "1234567";
            work05.BOSlipNo1 = "111111";
            work05.BOSlipNo2 = "222222";
            work05.BOSlipNo3 = "333333";
            work05.BOManagementNo = "444444";
            list.Add(work05);

            PublicationConfResultWork work06 = new PublicationConfResultWork();
            work06.SectionCode = "01";
            work06.SectionGuideSnm = "���_01";
            work06.OnlineNo = 100;
            work06.OnlineRowNo = 5;
            work06.SystemDivCd = 0;
            work06.GoodsNo = "30009-ACB100";
            work06.WarehouseCode = "0001";
            work06.WarehouseShelfNo = "01";
            work06.ListPrice = 10000;
            work06.AcceptAnOrderCnt = 100;
            work06.UOESectOutGoodsCnt = 120;
            work06.BOShipmentCnt1 = 150;
            work06.BOShipmentCnt2 = 155;
            work06.BOShipmentCnt3 = 156;
            work06.MakerFollowCnt = 158;
            work06.EOAlwcCount = 156;
            work06.UOESupplierName = "UOE������";
            work06.ReceiveDate = DateTime.Now.Date;
            work06.UoeRemark1 = "rem01";
            work06.UoeRemark2 = "rem02";
            work06.AnswerPartsNo = "30009-ACB100";
            work06.AnswerPartsName = "�i��30009-ACB100�i��";
            work06.AnswerListPrice = 10000;
            work06.AnswerSalesUnitCost = 8000;
            work06.UOESectionSlipNo = "1234567";
            work06.BOSlipNo1 = "111111";
            work06.BOSlipNo2 = "222222";
            work06.BOSlipNo3 = "333333";
            work06.BOManagementNo = "444444";
            list.Add(work06);

            PublicationConfResultWork work11 = new PublicationConfResultWork();
            work11.SectionCode = "02";
            work11.SectionGuideSnm = "���_02";
            work11.OnlineNo = 222;
            work11.OnlineRowNo = 0;
            work11.SystemDivCd = 0;
            work11.GoodsNo = "30009-ACB100";
            work11.WarehouseCode = "0001";
            work11.WarehouseShelfNo = "01";
            work11.ListPrice = 10000;
            work11.AcceptAnOrderCnt = 100;
            work11.UOESectOutGoodsCnt = 120;
            work11.BOShipmentCnt1 = 150;
            work11.BOShipmentCnt2 = 155;
            work11.BOShipmentCnt3 = 156;
            work11.MakerFollowCnt = 158;
            work11.EOAlwcCount = 156;
            work11.UOESupplierName = "UOE������";
            work11.ReceiveDate = DateTime.Now.Date;
            work11.UoeRemark1 = "rem01";
            work11.UoeRemark2 = "rem02";
            work11.AnswerPartsNo = "30009-ACB100";
            work11.AnswerPartsName = "�i��30009-ACB100�i��";
            work11.AnswerListPrice = 10000;
            work11.AnswerSalesUnitCost = 8000;
            work11.UOESectionSlipNo = "1234567";
            work11.BOSlipNo1 = "111111";
            work11.BOSlipNo2 = "222222";
            work11.BOSlipNo3 = "333333";
            work11.BOManagementNo = "444444";
            list.Add(work11);

            PublicationConfResultWork work12 = new PublicationConfResultWork();
            work12.SectionCode = "02";
            work12.SectionGuideSnm = "���_02";
            work12.OnlineNo = 222;
            work12.OnlineRowNo = 1;
            work12.SystemDivCd = 0;
            work12.GoodsNo = "30009-ACB100";
            work12.WarehouseCode = "0001";
            work12.WarehouseShelfNo = "01";
            work12.ListPrice = 10000;
            work12.AcceptAnOrderCnt = 100;
            work12.UOESectOutGoodsCnt = 120;
            work12.BOShipmentCnt1 = 150;
            work12.BOShipmentCnt2 = 155;
            work12.BOShipmentCnt3 = 156;
            work12.MakerFollowCnt = 158;
            work12.EOAlwcCount = 156;
            work12.UOESupplierName = "UOE������";
            work12.ReceiveDate = DateTime.Now.Date;
            work12.UoeRemark1 = "rem01";
            work12.UoeRemark2 = "rem02";
            work12.AnswerPartsNo = "30009-ACB100";
            work12.AnswerPartsName = "�i��30009-ACB100�i��";
            work12.AnswerListPrice = 10000;
            work12.AnswerSalesUnitCost = 8000;
            work12.UOESectionSlipNo = "1234567";
            work12.BOSlipNo1 = "111111";
            work12.BOSlipNo2 = "222222";
            work12.BOSlipNo3 = "333333";
            work12.BOManagementNo = "444444";
            list.Add(work12);

            PublicationConfResultWork work13 = new PublicationConfResultWork();
            work13.SectionCode = "02";
            work13.SectionGuideSnm = "���_02";
            work13.OnlineNo = 222;
            work13.OnlineRowNo = 2;
            work13.SystemDivCd = 0;
            work13.GoodsNo = "30009-ACB100";
            work13.WarehouseCode = "0001";
            work13.WarehouseShelfNo = "01";
            work13.ListPrice = 10000;
            work13.AcceptAnOrderCnt = 100;
            work13.UOESectOutGoodsCnt = 120;
            work13.BOShipmentCnt1 = 150;
            work13.BOShipmentCnt2 = 155;
            work13.BOShipmentCnt3 = 156;
            work13.MakerFollowCnt = 158;
            work13.EOAlwcCount = 156;
            work13.UOESupplierName = "UOE������";
            work13.ReceiveDate = DateTime.Now.Date;
            work13.UoeRemark1 = "rem01";
            work13.UoeRemark2 = "rem02";
            work13.AnswerPartsNo = "30009-ACB100";
            work13.AnswerPartsName = "�i��30009-ACB100�i��";
            work13.AnswerListPrice = 10000;
            work13.AnswerSalesUnitCost = 8000;
            work13.UOESectionSlipNo = "1234567";
            work13.BOSlipNo1 = "111111";
            work13.BOSlipNo2 = "222222";
            work13.BOSlipNo3 = "333333";
            work13.BOManagementNo = "444444";
            list.Add(work13);

            PublicationConfResultWork work14 = new PublicationConfResultWork();
            work14.SectionCode = "02";
            work14.SectionGuideSnm = "���_02";
            work14.OnlineNo = 222;
            work14.OnlineRowNo = 3;
            work14.SystemDivCd = 0;
            work14.GoodsNo = "30009-ACB100";
            work14.WarehouseCode = "0001";
            work14.WarehouseShelfNo = "01";
            work14.ListPrice = 10000;
            work14.AcceptAnOrderCnt = 100;
            work14.UOESectOutGoodsCnt = 120;
            work14.BOShipmentCnt1 = 150;
            work14.BOShipmentCnt2 = 155;
            work14.BOShipmentCnt3 = 156;
            work14.MakerFollowCnt = 158;
            work14.EOAlwcCount = 156;
            work14.UOESupplierName = "UOE������";
            work14.ReceiveDate = DateTime.Now.Date;
            work14.UoeRemark1 = "rem01";
            work14.UoeRemark2 = "rem02";
            work14.AnswerPartsNo = "30009-ACB100";
            work14.AnswerPartsName = "�i��30009-ACB100�i��";
            work14.AnswerListPrice = 10000;
            work14.AnswerSalesUnitCost = 8000;
            work14.UOESectionSlipNo = "1234567";
            work14.BOSlipNo1 = "111111";
            work14.BOSlipNo2 = "222222";
            work14.BOSlipNo3 = "333333";
            work14.BOManagementNo = "444444";
            list.Add(work14);

            PublicationConfResultWork work15 = new PublicationConfResultWork();
            work15.SectionCode = "02";
            work15.SectionGuideSnm = "���_02";
            work15.OnlineNo = 222;
            work15.OnlineRowNo = 4;
            work15.SystemDivCd = 0;
            work15.GoodsNo = "30009-ACB100";
            work15.WarehouseCode = "0001";
            work15.WarehouseShelfNo = "01";
            work15.ListPrice = 10000;
            work15.AcceptAnOrderCnt = 100;
            work15.UOESectOutGoodsCnt = 120;
            work15.BOShipmentCnt1 = 150;
            work15.BOShipmentCnt2 = 155;
            work15.BOShipmentCnt3 = 156;
            work15.MakerFollowCnt = 158;
            work15.EOAlwcCount = 156;
            work15.UOESupplierName = "UOE������";
            work15.ReceiveDate = DateTime.Now.Date;
            work15.UoeRemark1 = "rem01";
            work15.UoeRemark2 = "rem02";
            work15.AnswerPartsNo = "30009-ACB100";
            work15.AnswerPartsName = "�i��30009-ACB100�i��";
            work15.AnswerListPrice = 10000;
            work15.AnswerSalesUnitCost = 8000;
            work15.UOESectionSlipNo = "1234567";
            work15.BOSlipNo1 = "111111";
            work15.BOSlipNo2 = "222222";
            work15.BOSlipNo3 = "333333";
            work15.BOManagementNo = "444444";
            list.Add(work15);

            PublicationConfResultWork work16 = new PublicationConfResultWork();
            work16.SectionCode = "02";
            work16.SectionGuideSnm = "���_02";
            work16.OnlineNo = 222;
            work16.OnlineRowNo = 5;
            work16.SystemDivCd = 0;
            work16.GoodsNo = "30009-ACB100";
            work16.WarehouseCode = "0001";
            work16.WarehouseShelfNo = "01";
            work16.ListPrice = 10000;
            work16.AcceptAnOrderCnt = 100;
            work16.UOESectOutGoodsCnt = 120;
            work16.BOShipmentCnt1 = 150;
            work16.BOShipmentCnt2 = 155;
            work16.BOShipmentCnt3 = 156;
            work16.MakerFollowCnt = 158;
            work16.EOAlwcCount = 156;
            work16.UOESupplierName = "UOE������";
            work16.ReceiveDate = DateTime.Now.Date;
            work16.UoeRemark1 = "rem01";
            work16.UoeRemark2 = "rem02";
            work16.AnswerPartsNo = "30009-ACB100";
            work16.AnswerPartsName = "�i��30009-ACB100�i��";
            work16.AnswerListPrice = 10000;
            work16.AnswerSalesUnitCost = 8000;
            work16.UOESectionSlipNo = "1234567";
            work16.BOSlipNo1 = "111111";
            work16.BOSlipNo2 = "222222";
            work16.BOSlipNo3 = "333333";
            work16.BOManagementNo = "444444";
            list.Add(work16);

            retpublicationConfList = (object)list;
            return 0;
        }
        
		# endregion

		/// <summary>
		/// ���o�����W�J����
		/// </summary>
        /// <param name="publicationConfOrderCndtn">UI���o�����N���X</param>
        /// <param name="publicationConfOrderCndtnWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>SortOrder</returns>
		/// <remarks>
		/// <br>Note       : �����[�g�p�̒��o�����ɓW�J���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int DevConfirmPublicationConfCndtn(PublicationConfOrderCndtn publicationConfOrderCndtn, out PublicationConfOrderCndtnWork publicationConfOrderCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			errMsg = string.Empty;
            publicationConfOrderCndtnWork = new PublicationConfOrderCndtnWork();

            try
            {
                // ��ƃR�[�h
                publicationConfOrderCndtnWork.EnterpriseCode = publicationConfOrderCndtn.EnterpriseCode;

                // �V�X�e���敪
                publicationConfOrderCndtnWork.SystemDivCd = publicationConfOrderCndtn.SystemDivCd;

                // ���_�R�[�h(�����w��)
                // 2008.12.24 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //publicationConfOrderCndtnWork.SectionCodes = publicationConfOrderCndtn.SectionCodes;
                if (publicationConfOrderCndtn.SectionCodes.Length != 0)
                {
                    if (publicationConfOrderCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                    }
                    else
                    {
                        publicationConfOrderCndtnWork.SectionCodes = publicationConfOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                }
                // 2008.12.24 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // ��M���t
                publicationConfOrderCndtnWork.St_ReceiveDate = publicationConfOrderCndtn.St_ReceiveDate;
                publicationConfOrderCndtnWork.Ed_ReceiveDate = publicationConfOrderCndtn.Ed_ReceiveDate;

                // �������
                publicationConfOrderCndtnWork.PrintCndtn = publicationConfOrderCndtn.PrintCndtn;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
		}

		/// <summary>
        /// ���s�m�F�f�[�^�W�J����
		/// </summary>
        /// <param name="publicationConfOrderCndtn">UI���o�����N���X</param>
        /// <param name="publicationConfDt">�W�J�Ώ�DataTable</param>
        /// <param name="publicationConfWork">�擾�f�[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : ���s�m�F�f�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private void DevPublicationConfData(PublicationConfOrderCndtn publicationConfOrderCndtn, DataTable publicationConfDt, ArrayList publicationConfWork)
		{
            DataRow dr;

            foreach (PublicationConfResultWork publicationConfResultWork in publicationConfWork)
            {
                dr = publicationConfDt.NewRow();
                #region �݌ɒ����f�[�^�W�J
                
                // ���_�R�[�h
                dr[PMUOE02049EA.ct_Col_SectionCode] = publicationConfResultWork.SectionCode;

                // ���_�K�C�h����
                // 2009.01.13 UPD ���_�R�[�h���o�͂��� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //dr[PMUOE02049EA.ct_Col_SectionGuideNm] = publicationConfResultWork.SectionGuideSnm;
                dr[PMUOE02049EA.ct_Col_SectionGuideNm] = publicationConfResultWork.SectionCode.ToString() + " " + publicationConfResultWork.SectionGuideSnm;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      
                // �I�����C���ԍ�
                // 2009.01.13 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //dr[PMUOE02049EA.ct_Col_OnlineNo] = publicationConfResultWork.OnlineNo;
                dr[PMUOE02049EA.ct_Col_OnlineNo] = publicationConfResultWork.OnlineNo % 1000000;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �I�����C���s�ԍ�
                dr[PMUOE02049EA.ct_Col_OnlineRowNo] = publicationConfResultWork.OnlineRowNo;

                // �V�X�e���敪
                dr[PMUOE02049EA.ct_Col_SystemDivCd] = publicationConfResultWork.SystemDivCd;

                // �V�X�e���敪����
                dr[PMUOE02049EA.ct_Col_SystemDivName] = PMUOE02049EA.GetSystemDivNm(publicationConfResultWork.SystemDivCd);

                // ���i�ԍ�
                dr[PMUOE02049EA.ct_Col_GoodsNo] = publicationConfResultWork.GoodsNo;

                // �q�ɃR�[�h
                dr[PMUOE02049EA.ct_Col_WarehouseCode] = publicationConfResultWork.WarehouseCode;

                // �q�ɒI��
                dr[PMUOE02049EA.ct_Col_WarehouseShelfNo] = publicationConfResultWork.WarehouseShelfNo;

                // �艿(����)
                dr[PMUOE02049EA.ct_Col_ListPrice] = publicationConfResultWork.ListPrice;

                // �󒍐���
                dr[PMUOE02049EA.ct_Col_AcceptAnOrderCnt] = publicationConfResultWork.AcceptAnOrderCnt;

                // UOE���_�o�ɐ�
                dr[PMUOE02049EA.ct_Col_UOESectOutGoodsCnt] = publicationConfResultWork.UOESectOutGoodsCnt;

                // BO�o�ɐ�1
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt1] = publicationConfResultWork.BOShipmentCnt1;

                // BO�o�ɐ�2
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt2] = publicationConfResultWork.BOShipmentCnt2;

                // BO�o�ɐ�3
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt3] = publicationConfResultWork.BOShipmentCnt3;

                // ���[�J�[�t�H���[��
                dr[PMUOE02049EA.ct_Col_MakerFollowCnt] = publicationConfResultWork.MakerFollowCnt;

                // EO������
                dr[PMUOE02049EA.ct_Col_EOAlwcCount] = publicationConfResultWork.EOAlwcCount;

                // UOE�����於��
                dr[PMUOE02049EA.ct_Col_UOESupplierName] = publicationConfResultWork.UOESupplierName;

                // ��M���t
                dr[PMUOE02049EA.ct_Col_ReceiveDate] = publicationConfResultWork.ReceiveDate;

                // UOE���}�[�N1
                dr[PMUOE02049EA.ct_Col_UoeRemark1] = publicationConfResultWork.UoeRemark1;

                // UOE���}�[�N2
                dr[PMUOE02049EA.ct_Col_UoeRemark2] = publicationConfResultWork.UoeRemark2;

                // �񓚕i��
                dr[PMUOE02049EA.ct_Col_AnswerPartsNo] = publicationConfResultWork.AnswerPartsNo;

                // �񓚕i��
                dr[PMUOE02049EA.ct_Col_AnswerPartsName] = publicationConfResultWork.AnswerPartsName;

                // �񓚒艿
                dr[PMUOE02049EA.ct_Col_AnswerListPrice] = publicationConfResultWork.AnswerListPrice;

                // �񓚌����P��
                dr[PMUOE02049EA.ct_Col_AnswerSalesUnitCost] = publicationConfResultWork.AnswerSalesUnitCost;

                // UOE���_�`�[�ԍ�
                dr[PMUOE02049EA.ct_Col_UOESectionSlipNo] = publicationConfResultWork.UOESectionSlipNo;

                // BO�`�[�ԍ�1
                dr[PMUOE02049EA.ct_Col_BOSlipNo1] = publicationConfResultWork.BOSlipNo1;

                // BO�`�[�ԍ�2
                dr[PMUOE02049EA.ct_Col_BOSlipNo2] = publicationConfResultWork.BOSlipNo2;

                // BO�`�[�ԍ�3
                dr[PMUOE02049EA.ct_Col_BOSlipNo3] = publicationConfResultWork.BOSlipNo3;

                // BO�Ǘ��ԍ�
                dr[PMUOE02049EA.ct_Col_BOManagementNo] = publicationConfResultWork.BOManagementNo;

                // �`�F�b�N���e
                if (publicationConfResultWork.AcceptAnOrderCnt != (publicationConfResultWork.UOESectOutGoodsCnt   // UOE���_�o�ɐ�
                                                                 + publicationConfResultWork.BOShipmentCnt1       // BO�o�ɐ�1
                                                                 + publicationConfResultWork.BOShipmentCnt2       // BO�o�ɐ�2
                                                                 + publicationConfResultWork.BOShipmentCnt3       // BO�o�ɐ�3
                                                                 + publicationConfResultWork.MakerFollowCnt       // ���[�J�[�t�H���[��
                                                                 + publicationConfResultWork.EOAlwcCount          // EO������
                                                                 ))
                {
                    // ���ʕs��
                    if (publicationConfResultWork.ListPrice != publicationConfResultWork.AnswerListPrice) 
                    {
                        // �艿�s��v
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "���ʕs��/�艿�s��v";
                    }
                    else
                    {
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "���ʕs��";
                    }
                }
                else
                {
                    if (publicationConfResultWork.ListPrice != publicationConfResultWork.AnswerListPrice)
                    {
                        // �艿�s��v
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "�艿�s��v";
                    }
                    else
                    {
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "";
                    }
                }

                #endregion

                // Table��Add
                publicationConfDt.Rows.Add(dr);

            }
		}

        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������Double�l</param>
        /// <returns>�l�̌ܓ����ꂽdouble</returns>
        private static Int64 Round(double parameter)
        {
            // �������@�l�̌ܓ�
            return (Int64)Round(parameter, 0, 5);
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������Double�l</param>
        /// <param name="digits">�����_�ȉ��̗L������</param>
        /// <returns>�l�̌ܓ����ꂽdouble</returns>
        public static double Round(double parameter, int digits)
        {
            // �l�̌ܓ�
            return Round(parameter, digits, 5);
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������Double�l</param>
        /// <param name="digits">�����_�ȉ��̗L������</param>
        /// <param name="divide">�؂�グ�鋫�E�̒l 1�`9�@(ex. 5���l�̌ܓ�)</param>
        /// <returns>�l�̌ܓ����ꂽdouble</returns>
        public static double Round(double parameter, int digits, int divide)
        {
            decimal param = (decimal)parameter;
            decimal dCoef = (decimal)Math.Pow(10, digits);
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if (param > 0)
            {
                // 0.5�𑫂��āu�{�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                param = Math.Floor((param * dCoef) + dDiv) / dCoef;
            }
            else
            {
                // -0.5�𑫂��āu�|�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                param = Math.Ceiling((param * dCoef) - dDiv) / dCoef;
            }
            return (double)param;
        }
		# endregion
	}
}

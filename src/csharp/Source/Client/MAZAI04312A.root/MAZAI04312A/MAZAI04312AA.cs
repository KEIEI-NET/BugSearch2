# region ��using
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �݌Ɏ󕥗����e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �݌Ɏ󕥗����e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: �n糋M�T</br>
	/// <br>Date		: 2007.05.18</br>
    /// <br>Update Note : 2010/11/17  �{�w�C��</br>
    /// <br>            : PM1014�̑Ή��̎d�l�ύX</br>
    /// <br>Update Note : 2013/01/15  FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ�</br>
	/// </remarks>    
	public class StockAcPayHistAcs : IGeneralGuideData 
	{
		# region ��Private Member
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>        
        private IStockAcPayHisSearchDB _iStockAcPayHisSearchDB = null;
        /// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(HashTable)</summary>
		private Hashtable _stockAcPayLstGdBdTable;
		/// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(ArrayList)</summary>
		private ArrayList _stockAcPayLstGdBdList;
        /// <summary>�݌Ɏ󕥗�������</summary>
        private static Hashtable _stockAcPayListCH = null;
        
		# endregion				    
		  
		# region ��Constracter
		/// <summary>
		/// �݌Ɏ󕥗����e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥗����e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public StockAcPayHistAcs()
		{
			// ��������������
			MemoryCreate();

			// ���O�C�����i�ŒʐM��Ԃ��m�F
			if (LoginInfoAcquisition.OnlineFlag)
			{
				try
				{
					// �����[�g�I�u�W�F�N�g�擾
                    this._iStockAcPayHisSearchDB = (IStockAcPayHisSearchDB)MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();
				}
				catch (Exception)
				{				
					//�I�t���C������null���Z�b�g
					this._iStockAcPayHisSearchDB = null;
				}
			}
			else
			{
				// �I�t���C�����̃f�[�^�ǂݍ���
				this.SearchOfflineData();
			}
		}
		# endregion

		# region ��public int GetOnlineMode()
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2006.12.05</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iStockAcPayHisSearchDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}
		# endregion

		#region ��Public Method
		/// <summary>
		/// �݌Ɏ󕥗����e�[�u��Static���������I�t���C���������ݏ���
		/// </summary>
		/// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥗����e�[�u��Static�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
		/// <br>Programer  : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status;

			// KeyList�ݒ�
			string[] stockAcPayHistKeys = new string[1];
			stockAcPayHistKeys[0] = LoginInfoAcquisition.EnterpriseCode;

			SortedList sortedList = new SortedList();
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

            /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� ---------------------------------------------------->>>>>
            foreach (StockAcPayHist stockAcPayHist in _stockAcPayListCH.Values)
            {
                // �N���X �� ���[�J�[�N���X
                stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHist);

            }
               -----DEL 2008/07/17 -----------------------------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 ----------------------------------------------------------------------->>>>>
            foreach (StockAcPayHisSearchRet stockAcPayHisSearchRet in _stockAcPayListCH.Values)
            {
				// �N���X �� ���[�J�[�N���X
                stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHisSearchRet);

			}
            // -----ADD 2008/07/17 -----------------------------------------------------------------------<<<<<

			ArrayList carrierWorkList = new ArrayList();  
			carrierWorkList.AddRange(sortedList.Values);
				
			status = offlineDataSerializer.Serialize("CallierAcs", stockAcPayHistKeys, carrierWorkList);

			return status;
		}

        /// <summary>
        /// �݌Ɏ󕥗����V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ɏ󕥗������̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
        /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� ---------------------------------------------------------------->>>>>
        public void Serialize(StockAcPayHist stockAcPayHist ,string fileName)
        {
            //�݌Ɏ󕥗����N���X����݌Ɏ󕥗������[�J�[�N���X�Ƀ����o�R�s�[
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHist);
            //�݌Ɏ󕥗������[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(stockAcPayHist,fileName);
        }
           -----DEL 2008/07/17 -----------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 ----------------------------------------------------------------------------------->>>>>
        public void Serialize(StockAcPayHisSearchRet stockAcPayHisSearchRet, string fileName)
        {
            //�݌Ɏ󕥗����N���X����݌Ɏ󕥗������[�J�[�N���X�Ƀ����o�R�s�[
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHisSearchRet);
            //�݌Ɏ󕥗������[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(stockAcPayHisSearchRet, fileName);
        }
        // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

		/// <summary>
		/// �݌Ɏ󕥗���List�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ɏ󕥗���List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public void ListSerialize(ArrayList stockAcPayHists,string fileName)
		{
            StockAcPayHisSearchRetWork[] stockAcPayHisSearchRetWorks = new StockAcPayHisSearchRetWork[stockAcPayHists.Count];
			for(int i= 0; i < stockAcPayHists.Count; i++)
			{
                //stockAcPayHisSearchRetWorks[i] = CopyToStockAcWorkFromStockAc((StockAcPayHist)stockAcPayHists[i]);        //DEL 2008/07/17 �g�p�N���X�ύX�̈�
                stockAcPayHisSearchRetWorks[i] = CopyToStockAcWorkFromStockAc((StockAcPayHisSearchRet)stockAcPayHists[i]);  //ADD 2008/07/17
            }
            //�݌Ɏ󕥗������[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(stockAcPayHisSearchRetWorks,fileName);
		}
        /// <summary>
        /// �݌Ɏ󕥗������������i�_���폜�܂ށj
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �݌Ɏ󕥗����̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
        //public int SearchAll(out ArrayList retList,StockAcPayHisSearchPara stockAsPayHisSearchPara)                           //DEL 2008/07/17 �݌ɓ��o�ɏƉ�o���ʃN���X�ǉ��̈�
        public int SearchAll(out ArrayList retList, out ArrayList retList2, StockAcPayHisSearchPara stockAsPayHisSearchPara)    //ADD 2008/07/17
		{
			bool nextData;
			int	 retTotalCnt;
            //return SearchProc(out retList, out retTotalCnt, out nextData, stockAsPayHisSearchPara, ConstantManagement.LogicalMode.GetData01, 0, false);                   //DEL 2008/07/17 �݌ɓ��o�ɏƉ�o���ʃN���X�ǉ��̈�
            return SearchProc(out retList,out retList2, out retTotalCnt, out nextData, stockAsPayHisSearchPara, ConstantManagement.LogicalMode.GetData01, 0, false);        //ADD 2008/07/17
            
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�݌Ɏ󕥗������[�N�N���X�ˍ݌Ɏ󕥗����N���X�j
        ///// </summary>
        ///// <param name="stockAcPayHistWork">�݌Ɏ󕥗������[�N�N���X</param>
        ///// <returns>�݌Ɏ󕥗����N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �݌Ɏ󕥗������[�N�N���X����݌Ɏ󕥗����N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
        ///// <br>Programmer : �n糋M�T</br>
        ///// <br>Date       : 2007.05.18</br>
        ///// </remarks>
        //public static StockAcPayHist CopyToStockAcPayHistFromWork(StockAcPayHistWork stockAcPayHistWork)
        //{
        //    StockAcPayHist stockAcPayHist = new StockAcPayHist();

        //    stockAcPayHist.AcPayNote = stockAcPayHistWork.AcPayNote;
        //    stockAcPayHist.AcPaySlipCd = stockAcPayHistWork.AcPaySlipCd;
        //    stockAcPayHist.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
        //    stockAcPayHist.AcPayTransCd = stockAcPayHistWork.AcPayTransCd;
        //    stockAcPayHist.AcpOdrCount = stockAcPayHistWork.AcpOdrCount;
        //    stockAcPayHist.AfAcPayEpCode = stockAcPayHistWork.AfAcPayEpCode;
        //    stockAcPayHist.AfEnterWarehCode = stockAcPayHistWork.AfEnterWarehCode;
        //    stockAcPayHist.AfEnterWarehName = stockAcPayHistWork.AfEnterWarehName;
        //    stockAcPayHist.AfSectionCode = stockAcPayHistWork.AfSectionCode;
        //    stockAcPayHist.AfSectionGuideNm = stockAcPayHistWork.AfSectionGuideNm;
        //    stockAcPayHist.AllowStockCnt = stockAcPayHistWork.AllowStockCnt;
        //    stockAcPayHist.ArrivalCnt = stockAcPayHistWork.ArrivalCnt;
        //    stockAcPayHist.BfEnterWarehCode = stockAcPayHistWork.BfEnterWarehCode;
        //    stockAcPayHist.BfEnterWarehName = stockAcPayHistWork.BfEnterWarehName;
        //    stockAcPayHist.BfSectionCode = stockAcPayHistWork.BfSectionCode;
        //    stockAcPayHist.BfSectionGuideNm = stockAcPayHistWork.BfSectionGuideNm;
        //    stockAcPayHist.CellphoneModelCode = stockAcPayHistWork.CellphoneModelCode;
        //    stockAcPayHist.CellphoneModelName = stockAcPayHistWork.CellphoneModelName;
        //    stockAcPayHist.CustomerCode = stockAcPayHistWork.CustomerCode;
        //    stockAcPayHist.CustomerName = stockAcPayHistWork.CustomerName;
        //    stockAcPayHist.CustomerName2 = stockAcPayHistWork.CustomerName2;
        //    stockAcPayHist.EnterpriseCode = stockAcPayHistWork.EnterpriseCode;
        //    stockAcPayHist.EntrustCnt = stockAcPayHistWork.EntrustCnt;
        //    stockAcPayHist.GoodsCode = stockAcPayHistWork.GoodsCode;
        //    stockAcPayHist.GoodsName = stockAcPayHistWork.GoodsName;
        //    stockAcPayHist.InputAgenCd = stockAcPayHistWork.InputAgenCd;
        //    stockAcPayHist.InputAgenNm = stockAcPayHistWork.InputAgenNm;
        //    stockAcPayHist.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
        //    stockAcPayHist.MovingSupliStock = stockAcPayHistWork.MovingSupliStock;
        //    stockAcPayHist.MovingTrustStock = stockAcPayHistWork.MovingTrustStock;            
        //    stockAcPayHist.ReservedCount = stockAcPayHistWork.ReservedCount;
        //    stockAcPayHist.SalesFormCode = stockAcPayHistWork.SalesFormCode;
        //    stockAcPayHist.SalesFormName = stockAcPayHistWork.SalesFormName;
        //    stockAcPayHist.SalesOrderCount = stockAcPayHistWork.SalesOrderCount;
        //    stockAcPayHist.SectionCode = stockAcPayHistWork.SectionCode;
        //    stockAcPayHist.ShipmentCnt = stockAcPayHistWork.ShipmentCnt;
        //    stockAcPayHist.ShipmentPosCnt = stockAcPayHistWork.ShipmentPosCnt;
        //    stockAcPayHist.SoldCnt = stockAcPayHistWork.SoldCnt;
        //    stockAcPayHist.StockUnitPrice = stockAcPayHistWork.StockUnitPrice;
        //    stockAcPayHist.SupplierStock = stockAcPayHistWork.SupplierStock;
        //    stockAcPayHist.TrustCount = stockAcPayHistWork.TrustCount;

        //    return stockAcPayHist;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�݌Ɏ󕥗��𖾍׃��[�N�N���X�ˍ݌Ɏ󕥗��𖾍׃N���X�j
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �݌Ɏ󕥗������[�N�N���X����݌Ɏ󕥗����N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
        ///// <br>Programmer : �n糋M�T</br>
        ///// <br>Date       : 2007.05.18</br>
        ///// </remarks>
        //public static StockAcPayHisDt CopyToStockAcPayHisDtFromWork(StockAcPayHisDtWork stockAcPayHisDtWork)
        //{
        //    StockAcPayHisDt stockAcPayHisDt = new StockAcPayHisDt();

        //    stockAcPayHisDt.AcPayNote = stockAcPayHisDtWork.AcPayNote;
        //    stockAcPayHisDt.AcPaySlipCd = stockAcPayHisDtWork.AcPaySlipCd;
        //    stockAcPayHisDt.AcPaySlipExpNo = stockAcPayHisDtWork.AcPaySlipExpNo;
        //    stockAcPayHisDt.AcPaySlipNum = stockAcPayHisDtWork.AcPaySlipNum;
        //    stockAcPayHisDt.AcPaySlipRowNo = stockAcPayHisDtWork.AcPaySlipRowNo;
        //    stockAcPayHisDt.AcpOdrCount = stockAcPayHisDtWork.AcpOdrCount;
        //    stockAcPayHisDt.AfAcPayEpCode = stockAcPayHisDtWork.AfAcPayEpCode;
        //    stockAcPayHisDt.AfEnterWarehCode = stockAcPayHisDtWork.AfEnterWarehCode;
        //    stockAcPayHisDt.AfEnterWarehName = stockAcPayHisDtWork.AfEnterWarehName;
        //    stockAcPayHisDt.AfSectionCode = stockAcPayHisDtWork.AfSectionCode;
        //    stockAcPayHisDt.AfSectionGuideNm = stockAcPayHisDtWork.AfSectionGuideNm;
        //    stockAcPayHisDt.AfEnterWarehCode = stockAcPayHisDtWork.AfEnterWarehCode;
        //    stockAcPayHisDt.AfEnterWarehName = stockAcPayHisDtWork.AfEnterWarehName;
        //    stockAcPayHisDt.AllowStockCnt = stockAcPayHisDtWork.AllowStockCnt;
        //    stockAcPayHisDt.ArrivalCnt = stockAcPayHisDtWork.ArrivalCnt;
        //    stockAcPayHisDt.BfEnterWarehCode = stockAcPayHisDtWork.BfEnterWarehCode;
        //    stockAcPayHisDt.BfEnterWarehName = stockAcPayHisDtWork.BfEnterWarehName;
        //    stockAcPayHisDt.BfSectionCode = stockAcPayHisDtWork.BfSectionCode;
        //    stockAcPayHisDt.BfSectionGuideNm = stockAcPayHisDtWork.BfSectionGuideNm;
        //    stockAcPayHisDt.BfEnterWarehCode = stockAcPayHisDt.BfEnterWarehCode;
        //    stockAcPayHisDt.BfEnterWarehName = stockAcPayHisDt.BfEnterWarehName;
        //    stockAcPayHisDt.CarrierEpCode = stockAcPayHisDtWork.CarrierEpCode;
        //    stockAcPayHisDt.CarrierEpName = stockAcPayHisDtWork.CarrierEpName;
        //    stockAcPayHisDt.CellphoneModelCode = stockAcPayHisDtWork.CellphoneModelCode;
        //    stockAcPayHisDt.CellphoneModelName = stockAcPayHisDtWork.CellphoneModelName;
        //    stockAcPayHisDt.CustomerCode = stockAcPayHisDtWork.CustomerCode;
        //    stockAcPayHisDt.CustomerName = stockAcPayHisDtWork.CustomerName;
        //    stockAcPayHisDt.CustomerName2 = stockAcPayHisDtWork.CustomerName2;
        //    stockAcPayHisDt.EnterpriseCode = stockAcPayHisDtWork.EnterpriseCode;
        //    stockAcPayHisDt.EntrustCnt = stockAcPayHisDtWork.EntrustCnt;
        //    stockAcPayHisDt.GoodsCode = stockAcPayHisDtWork.GoodsCode;
        //    stockAcPayHisDt.GoodsName = stockAcPayHisDtWork.GoodsName;
        //    stockAcPayHisDt.InputAgenCd = stockAcPayHisDtWork.InputAgenCd;
        //    stockAcPayHisDt.InputAgenNm = stockAcPayHisDtWork.InputAgenNm;
        //    stockAcPayHisDt.IoGoodsDay = stockAcPayHisDtWork.IoGoodsDay;
        //    stockAcPayHisDt.MoveStatus = stockAcPayHisDtWork.MoveStatus;
        //    stockAcPayHisDt.MovingSupliStock = stockAcPayHisDtWork.MovingSupliStock;
        //    stockAcPayHisDt.MovingTrustStock = stockAcPayHisDtWork.MovingTrustStock;
        //    stockAcPayHisDt.ProductNumber = stockAcPayHisDtWork.ProductNumber;
        //    stockAcPayHisDt.ProductStockGuid = stockAcPayHisDtWork.ProductStockGuid;
        //    stockAcPayHisDt.ReservedCount = stockAcPayHisDtWork.ReservedCount;
        //    stockAcPayHisDt.RomDiv = stockAcPayHisDtWork.RomDiv;
        //    stockAcPayHisDt.SalesFormCode = stockAcPayHisDtWork.SalesFormCode;
        //    stockAcPayHisDt.SalesFormName = stockAcPayHisDtWork.SalesFormName;
        //    stockAcPayHisDt.SalesOrderCount = stockAcPayHisDtWork.SalesOrderCount;
        //    stockAcPayHisDt.SectionCode = stockAcPayHisDtWork.SectionCode;
        //    stockAcPayHisDt.ShipmentCnt = stockAcPayHisDtWork.ShipmentCnt;
        //    stockAcPayHisDt.ShipmentPosCnt = stockAcPayHisDtWork.ShipmentPosCnt;
        //    stockAcPayHisDt.SimProductNumber = stockAcPayHisDtWork.SimProductNumber;
        //    stockAcPayHisDt.SoldCnt = stockAcPayHisDtWork.SoldCnt;
        //    stockAcPayHisDt.StockState = stockAcPayHisDtWork.StockState;
        //    stockAcPayHisDt.StockTelNo1 = stockAcPayHisDtWork.StockTelNo1;
        //    stockAcPayHisDt.StockTelNo2 = stockAcPayHisDtWork.StockTelNo2;
        //    stockAcPayHisDt.StockUnitPrice = stockAcPayHisDtWork.StockUnitPrice;
        //    stockAcPayHisDt.SupplierStock = stockAcPayHisDtWork.SupplierStock;
        //    stockAcPayHisDt.TrustCount = stockAcPayHisDtWork.TrustCount;      
        //    stockAcPayHisDt.AcPayTransCd = stockAcPayHisDtWork.AcPayTransCd;            

        //    return stockAcPayHisDt;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		#region ��IGeneralGuidData Method
		/// <summary>
		/// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
		/// <remarks>
		/// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: �n糋M�T</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			string sectionCode    = "";
			

			// ��ƃR�[�h�ݒ�L��
			if (inParm.ContainsKey("EnterpriseCode"))
			{
				enterpriseCode = inParm["EnterpriseCode"].ToString();
			}
			// ��ƃR�[�h�ݒ薳��
			else
			{
				// �L�蓾�Ȃ��̂ŃG���[
				return status;
			}

			// ���_�R�[�h
			if (inParm.ContainsKey("SectionCode"))
			{
				sectionCode = inParm["SectionCode"].ToString();
			}

            // �݌Ɏ󕥗����e�[�u���Ǎ���
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

			return status;
		}

		#endregion

		#endregion

		#region ��Private Method
		/// <summary>
        /// �݌Ɏ󕥗�����������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �݌Ɏ󕥗����̌����������s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
        /// <br>UpdateNote : �݌Ɏ󕥗��������݂��Ȃ��ꍇ�ł��A�O�����c�ƌ��݌ɐ���\������悤�ɕύX�B</br>
        /// <br>           : �{�w�C��</br>
        /// <br>Date       : 2010/11/15</br>
		/// </remarks>
        //private int SearchProc(out ArrayList retList,out int retTotalCnt,out bool nextData,StockAcPayHisSearchPara stockAcPayHisSearchPara,ConstantManagement.LogicalMode logicalMode,int readCnt,bool reAct)                         //DEL 2008/07/17 �݌ɓ��o�ɏƉ�o���ʃN���X�ǉ��̈�    
		private int SearchProc(out ArrayList retList,out ArrayList retList2,out int retTotalCnt,out bool nextData,StockAcPayHisSearchPara stockAcPayHisSearchPara,ConstantManagement.LogicalMode logicalMode,int readCnt,bool reAct)    //ADD 2008/07/17
		{
            //StockAcPayHist prevStockAcPayHist = new StockAcPayHist();                 //DEL 2008/07/17 �g�p���Ă��Ȃ���
			
			int status;            

            //���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();
            ArrayList paraList = new ArrayList();
            retList2 = new ArrayList();       //ADD 2008/07/17 
            retList2.Clear();                 //ADD 2008/07/17


			if ((_stockAcPayListCH.Count != 0 ) && (reAct != true))
			{
                //�L���b�V��������Ƃ��̏���
                status = 0;
//				status = SearchStatic(out retList,enterpriseCode,carrierCode);
			}
			else
			{
				object objectStockAcPayListWork = null;
                object objectStockCarEnterCarOutRetWork = null;     //ADD 2008/07/17
                object objectStockAcPayPara = CopyToSearchParaWorkFromSearchPara( stockAcPayHisSearchPara );
                status = 0;
                // �݌Ɏ󕥗�������
				if (readCnt == 0)
				{
                    //status = this._iStockAcPayHisSearchDB.Search(out objectStockAcPayListWork, objectStockAcPayPara, 0, ConstantManagement.LogicalMode.GetData0);                                         //DEL 2008/07/17 �݌ɓ��o�ɏƉ�o���ʃN���X�ǉ��̈�
                    status = this._iStockAcPayHisSearchDB.Search(out objectStockAcPayListWork, out objectStockCarEnterCarOutRetWork, objectStockAcPayPara, 0, ConstantManagement.LogicalMode.GetData0);     //ADD 2008/07/17
                }

                if (status == 0)
				{

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// �p�����[�^���n���ė��Ă��邩�m�F  
                    //CustomSerializeArrayList customList = objectStockAcPayListWork as CustomSerializeArrayList;

                    //paraList = customList[0] as ArrayList;

                    //if ((stockAcPayHisSearchPara.ProductNumber != "") || (stockAcPayHisSearchPara.StockTelNo1 != ""))
                    //{
                    //    // ���Ԃ��� �ˍ݌Ɏ󕥐��ԗ���                        
                    //    StockAcPayHisDtWork[] wkstockAcPayHisDtWorks = new StockAcPayHisDtWork[paraList.Count];
                        
                    //    // �f�[�^�����ɖ߂�
                    //    for(int i=0; i < paraList.Count; i++)
                    //    {
                    //        wkstockAcPayHisDtWorks[i] = (StockAcPayHisDtWork)paraList[i];
                    //    }
                    //    for (int i = 0; i < wkstockAcPayHisDtWorks.Length; i++)
                    //    {
                    //        // �T�[�`���ʎ擾
                    //        retList.Add(CopyToStockAcPayHisDtFromWork(wkstockAcPayHisDtWorks[i]));
                    //    }                       
                    //}
                    //else
                    //{
                    //    // ���ԂȂ� �ˍ݌Ɏ󕥗���
                    //    StockAcPayHistWork[] wkstockAcPayHistWorks = new StockAcPayHistWork[paraList.Count];
                    //    // �f�[�^�����ɖ߂�
                    //    for(int i=0; i < paraList.Count; i++)
                    //    {
                    //        wkstockAcPayHistWorks[i] = (StockAcPayHistWork)paraList[i];
                    //    }
                    //    for (int i = 0; i < wkstockAcPayHistWorks.Length; i++)
                    //    {
                    //        // �T�[�`���ʎ擾
                    //        retList.Add(CopyToStockAcPayHistFromWork(wkstockAcPayHistWorks[i]));
                    //    }                       
                    //}

                    ArrayList retWorkList;
                    ArrayList retWorkList2;     //ADD 2008/07/17
                    // --- UPD 2010/11/15 ---------->>>>> 
                    if ((objectStockAcPayListWork as CustomSerializeArrayList).Count > 0 && (objectStockAcPayListWork as CustomSerializeArrayList)[0] is ArrayList)
                    {
                        retWorkList = (ArrayList)((objectStockAcPayListWork as CustomSerializeArrayList)[0]);
                       // retWorkList2 = (ArrayList)((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0]);     //ADD 2008/07/17
                    }
                    else
                    {
                        retWorkList = new ArrayList();
                       // retWorkList2 = new ArrayList();     //ADD 2008/07/17
                    }           
                    if ((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList).Count > 0 && (objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0] is ArrayList)
                    {                       
                        retWorkList2 = (ArrayList)((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0]);    
                    }
                    else
                    {                     
                        retWorkList2 = new ArrayList();     
                    }
                    // --- UPD 2010/11/15 ----------<<<<<
                    foreach ( object retObj in retWorkList )
                    {
                        if ( retObj is StockAcPayHisSearchRetWork )
                        {
                            retList.Add( CopyToStockAcPayHistFromWork( (StockAcPayHisSearchRetWork)retObj ) );
                        }
                    }

                    // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------------------------------>>>>>
                    // �݌ɓ��o�ɏƉ�o���ʃN���X���e�擾
                    foreach (object retObj in retWorkList2)
                    {
                        if (retObj is StockCarEnterCarOutRetWork)
                        {
                            retList2.Add(CopyToStockCarEnterCarOutFromWork((StockCarEnterCarOutRetWork)retObj));
                        }
                    }
                    // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------------------------------<<<<<

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				

					// SearchFlg ON
				}
			}
			//�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}
        /// <summary>
        /// �f�[�^�ϊ��iSearchPara��SearchParaWork�j
        /// </summary>
        /// <param name="stockAcPayHisSearchPara"></param>
        /// <returns></returns>
		/// <remarks>
		/// <br>Update Note : 2013/01/15  FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ�</br>
		/// </remarks>
        private StockAcPayHisSearchParaWork CopyToSearchParaWorkFromSearchPara ( StockAcPayHisSearchPara stockAcPayHisSearchPara )
        {
            StockAcPayHisSearchParaWork paraWork = new StockAcPayHisSearchParaWork();

            paraWork.EnterpriseCode = stockAcPayHisSearchPara.EnterpriseCode; // ��ƃR�[�h
            //paraWork.ValidDivCd = stockAcPayHisSearchPara.ValidDivCd; // �L���敪         //DEL 2008/07/17 �R���p�C���G���[�ƂȂ��
            paraWork.St_IoGoodsDay = GetLongDateFromDateTime(stockAcPayHisSearchPara.St_IoGoodsDay); // �J�n���o�ד�
            paraWork.Ed_IoGoodsDay = GetLongDateFromDateTime(stockAcPayHisSearchPara.Ed_IoGoodsDay); // �I�����o�ד�
            paraWork.St_AddUpADate = GetLongDateFromDateTime(stockAcPayHisSearchPara.St_AddUpADate); // �J�n�v����t
            paraWork.Ed_AddUpADate = GetLongDateFromDateTime(stockAcPayHisSearchPara.Ed_AddUpADate); // �I���v����t
            paraWork.AcPaySlipCd = stockAcPayHisSearchPara.AcPaySlipCd; // �󕥌��`�[�敪
            paraWork.SectionCodes = stockAcPayHisSearchPara.SectionCodes; // ���_�R�[�h�i�����w��j
            paraWork.St_WarehouseCode = stockAcPayHisSearchPara.St_WarehouseCode; // �J�n�q�ɃR�[�h
            paraWork.Ed_WarehouseCode = stockAcPayHisSearchPara.Ed_WarehouseCode; // �I���q�ɃR�[�h
            paraWork.St_GoodsMakerCd = stockAcPayHisSearchPara.St_GoodsMakerCd; // �J�n���i���[�J�[�R�[�h
            paraWork.Ed_GoodsMakerCd = stockAcPayHisSearchPara.Ed_GoodsMakerCd; // �I�����i���[�J�[�R�[�h
            paraWork.St_AcPaySlipNum = stockAcPayHisSearchPara.St_AcPaySlipNum; // �J�n�󕥌��`�[�ԍ�
            paraWork.Ed_AcPaySlipNum = stockAcPayHisSearchPara.Ed_AcPaySlipNum; // �I���󕥌��`�[�ԍ�
            paraWork.St_GoodsNo = stockAcPayHisSearchPara.St_GoodsNo; // �J�n���i�ԍ�
            paraWork.Ed_GoodsNo = stockAcPayHisSearchPara.Ed_GoodsNo; // �I�����i�ԍ�
            paraWork.St_HisYearMonth = stockAcPayHisSearchPara.St_HisYearMonth;     // �����J�n�N��     //ADD 2008/07/17
            paraWork.St_AcPayDate = stockAcPayHisSearchPara.St_AcPayDate;           // �󕥊J�n�N����   //ADD 2008/07/17
            // -----ADD 2013/01/15 ---------------------------------------------------------------------------------------->>>>>            
            paraWork.HasStkPay = HasStockingPayment(); //���|�I�v�V��������
            // -----ADD 2013/01/15 ----------------------------------------------------------------------------------------<<<<<            
            return paraWork;
        }
        /// <summary>
        /// YYYYMMDD���t�擾���� (�A��DateTime.MinValue�Ȃ��0�ɕϊ�)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateFromDateTime ( DateTime dateTime )
        {
            if ( dateTime == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ( dateTime.Year * 10000 ) + ( dateTime.Month * 100 ) + dateTime.Day;
            }
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�N���X�˃��[�N�N���X�j
		/// </summary>
		/// <returns>�݌Ɏ󕥗����N���X</returns>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥗����N���X����݌Ɏ󕥗������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
        /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� --------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAc(StockAcPayHist stockAcPayHist)
        {

            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();
		
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //stockAcPayHisSearchRetWork.EnterpriseCode = stockAcPayHist.EnterpriseCode;
            //stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHist.AcPaySlipCd;
            //stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHist.AcPaySlipNum;
            //stockAcPayHisSearchRetWork.GoodsCode = stockAcPayHist.GoodsCode;
            //stockAcPayHisSearchRetWork.GoodsName = stockAcPayHist.GoodsName;
            //stockAcPayHisSearchRetWork.SectionCode = stockAcPayHist.SectionCode;
            //stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHist.BfSectionCode;
            //stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHist.BfEnterWarehCode;
            //stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHist.BfEnterWarehName;
            //stockAcPayHisSearchRetWork.AfAcPayEpCode = stockAcPayHist.AfAcPayEpCode;
            //stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHist.AfEnterWarehCode;
            //stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHist.AfEnterWarehName;
            //stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHist.CustomerCode;
            //stockAcPayHisSearchRetWork.CustomerName = stockAcPayHist.CustomerName;
            //stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHist.CustomerName2;
            //stockAcPayHisSearchRetWork.SalesFormCode = stockAcPayHist.SalesFormCode;
            //stockAcPayHisSearchRetWork.SalesFormName = stockAcPayHist.SalesFormName;
            //stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHist.ArrivalCnt;
            //stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHist.ShipmentCnt;
            //stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHist.SupplierStock;
            //stockAcPayHisSearchRetWork.TrustCount = stockAcPayHist.TrustCount;
            //stockAcPayHisSearchRetWork.ReservedCount = stockAcPayHist.ReservedCount;
            //stockAcPayHisSearchRetWork.AllowStockCnt = stockAcPayHist.AllowStockCnt;
            //stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHist.AcpOdrCount;
            //stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHist.SalesOrderCount;
            //stockAcPayHisSearchRetWork.EntrustCnt = stockAcPayHist.EntrustCnt;
            //stockAcPayHisSearchRetWork.SoldCnt = stockAcPayHist.SoldCnt;
            //stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHist.MovingSupliStock;
            //stockAcPayHisSearchRetWork.MovingTrustStock = stockAcPayHist.MovingTrustStock;
            //stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHist.ShipmentPosCnt;
            //stockAcPayHisSearchRetWork.StockUnitPrice = stockAcPayHist.StockUnitPrice;
            //stockAcPayHisSearchRetWork.CellphoneModelName = stockAcPayHist.CellphoneModelName;
            //stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHist.InputAgenCd;
            //stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHist.InputAgenNm;
            //stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHist.AcPayNote;

            stockAcPayHisSearchRetWork.IoGoodsDay = stockAcPayHist.IoGoodsDay; // ���o�ד�
            stockAcPayHisSearchRetWork.AddUpADate = stockAcPayHist.AddUpADate; // �v����t
            stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHist.AcPaySlipCd; // �󕥌��`�[�敪
            stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHist.AcPaySlipNum; // �󕥌��`�[�ԍ�
            stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHist.AcPaySlipRowNo; // �󕥌��s�ԍ�
            stockAcPayHisSearchRetWork.AcPayHistDateTime = stockAcPayHist.AcPayHistDateTime; // �󕥗����쐬����
            stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHist.AcPayTransCd; // �󕥌�����敪
            stockAcPayHisSearchRetWork.InputSectionCd = stockAcPayHist.InputSectionCd; // ���͋��_�R�[�h
            stockAcPayHisSearchRetWork.InputSectionGuidNm = stockAcPayHist.InputSectionGuidNm; // ���͋��_�K�C�h����
            stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHist.InputAgenCd; // ���͒S���҃R�[�h
            stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHist.InputAgenNm; // ���͒S���Җ���
            stockAcPayHisSearchRetWork.MoveStatus = stockAcPayHist.MoveStatus; // �ړ����
            stockAcPayHisSearchRetWork.CustSlipNo = stockAcPayHist.CustSlipNo; // �����`�[�ԍ�
            stockAcPayHisSearchRetWork.SlipDtlNum = stockAcPayHist.SlipDtlNum; // ���גʔ�
            stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHist.AcPayNote; // �󕥔��l
            stockAcPayHisSearchRetWork.GoodsMakerCd = stockAcPayHist.GoodsMakerCd; // ���i���[�J�[�R�[�h
            stockAcPayHisSearchRetWork.MakerName = stockAcPayHist.MakerName; // ���[�J�[����
            stockAcPayHisSearchRetWork.GoodsNo = stockAcPayHist.GoodsNo; // ���i�ԍ�
            stockAcPayHisSearchRetWork.GoodsName = stockAcPayHist.GoodsName; // ���i����
            stockAcPayHisSearchRetWork.BLGoodsCode = stockAcPayHist.BLGoodsCode; // BL���i�R�[�h
            stockAcPayHisSearchRetWork.BLGoodsFullName = stockAcPayHist.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            stockAcPayHisSearchRetWork.SectionCode = stockAcPayHist.SectionCode; // ���_�R�[�h
            stockAcPayHisSearchRetWork.SectionGuideNm = stockAcPayHist.SectionGuideNm; // ���_�K�C�h����
            stockAcPayHisSearchRetWork.WarehouseCode = stockAcPayHist.WarehouseCode; // �q�ɃR�[�h
            stockAcPayHisSearchRetWork.WarehouseName = stockAcPayHist.WarehouseName; // �q�ɖ���
            stockAcPayHisSearchRetWork.ShelfNo = stockAcPayHist.ShelfNo; // �I��
            stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHist.BfSectionCode; // �ړ������_�R�[�h
            stockAcPayHisSearchRetWork.BfSectionGuideNm = stockAcPayHist.BfSectionGuideNm; // �ړ������_�K�C�h����
            stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHist.BfEnterWarehCode; // �ړ����q�ɃR�[�h
            stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHist.BfEnterWarehName; // �ړ����q�ɖ���
            stockAcPayHisSearchRetWork.BfShelfNo = stockAcPayHist.BfShelfNo; // �ړ����I��
            stockAcPayHisSearchRetWork.AfSectionCode = stockAcPayHist.AfSectionCode; // �ړ��拒�_�R�[�h
            stockAcPayHisSearchRetWork.AfSectionGuideNm = stockAcPayHist.AfSectionGuideNm; // �ړ��拒�_�K�C�h����
            stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHist.AfEnterWarehCode; // �ړ���q�ɃR�[�h
            stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHist.AfEnterWarehName; // �ړ���q�ɖ���
            stockAcPayHisSearchRetWork.AfShelfNo = stockAcPayHist.AfShelfNo; // �ړ���I��
            stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHist.CustomerCode; // ���Ӑ�R�[�h
            stockAcPayHisSearchRetWork.CustomerName = stockAcPayHist.CustomerName; // ���Ӑ於��
            stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHist.CustomerName2; // ���Ӑ於��2
            stockAcPayHisSearchRetWork.CustomerSnm = stockAcPayHist.CustomerSnm; // ���Ӑ旪��
            stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHist.ArrivalCnt; // ���א�
            stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHist.ShipmentCnt; // �o�א�
            stockAcPayHisSearchRetWork.OpenPriceDiv = stockAcPayHist.OpenPriceDiv; // �I�[�v�����i�敪
            stockAcPayHisSearchRetWork.ListPriceTaxExcFl = stockAcPayHist.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.StockUnitPriceFl = stockAcPayHist.StockUnitPriceFl; // �d���P���i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.StockPrice = stockAcPayHist.StockPrice; // �d�����z
            stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl = stockAcPayHist.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.SalesMoney = stockAcPayHist.SalesMoney; // ������z
            stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHist.SupplierStock; // �d���݌ɐ�
            stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHist.AcpOdrCount; // �󒍐�
            stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHist.SalesOrderCount; // ������
            stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHist.MovingSupliStock; // �ړ����d���݌ɐ�
            stockAcPayHisSearchRetWork.NonAddUpShipmCnt = stockAcPayHist.NonAddUpShipmCnt; // �o�א��i���v��j
            stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt = stockAcPayHist.NonAddUpArrGdsCnt; // ���א��i���v��j
            stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHist.ShipmentPosCnt; // �o�׉\��
            stockAcPayHisSearchRetWork.PresentStockCnt = stockAcPayHist.PresentStockCnt; // ���݌ɐ���
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return stockAcPayHisSearchRetWork;
        }
           -----DEL 2008/07/17 ----------------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 ---------------------------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAc(StockAcPayHisSearchRet stockAcPayHisSearchRet)
        {
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

            stockAcPayHisSearchRetWork.SectionCode = stockAcPayHisSearchRet.SectionCode;                    // ���_�R�[�h
            stockAcPayHisSearchRetWork.SectionGuideNm = stockAcPayHisSearchRet.SectionGuideNm;              // ���_�K�C�h����
            stockAcPayHisSearchRetWork.WarehouseCode = stockAcPayHisSearchRet.WarehouseCode;                // �q�ɃR�[�h
            stockAcPayHisSearchRetWork.WarehouseName = stockAcPayHisSearchRet.WarehouseName;                // �q�ɖ���
            stockAcPayHisSearchRetWork.GoodsMakerCd = stockAcPayHisSearchRet.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
            stockAcPayHisSearchRetWork.MakerName = stockAcPayHisSearchRet.MakerName;                        // ���[�J�[����
            stockAcPayHisSearchRetWork.GoodsNo = stockAcPayHisSearchRet.GoodsNo;                            // ���i�ԍ�
            stockAcPayHisSearchRetWork.GoodsName = stockAcPayHisSearchRet.GoodsName;                        // ���i����
            stockAcPayHisSearchRetWork.IoGoodsDay = stockAcPayHisSearchRet.IoGoodsDay;                      // ���o�ד�
            stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHisSearchRet.AcPaySlipNum;                  // �󕥌��`�[�ԍ�
            stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHisSearchRet.AcPaySlipCd;                    // �󕥌��`�[�敪
            stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHisSearchRet.AcPayTransCd;                  // �󕥌�����敪
            stockAcPayHisSearchRetWork.AfSectionCode = stockAcPayHisSearchRet.AfSectionCode;                // �ړ��拒�_�R�[�h
            stockAcPayHisSearchRetWork.AfSectionGuideNm = stockAcPayHisSearchRet.AfSectionGuideNm;          // �ړ��拒�_�K�C�h����
            stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHisSearchRet.AfEnterWarehCode;          // �ړ���q�ɃR�[�h
            stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHisSearchRet.AfEnterWarehName;          // �ړ���q�ɖ���
            stockAcPayHisSearchRetWork.AfShelfNo = stockAcPayHisSearchRet.AfShelfNo;                        // �ړ���I��
            stockAcPayHisSearchRetWork.NonAddUpShipmCnt = stockAcPayHisSearchRet.NonAddUpShipmCnt;          // �o�א��i���v��j
            stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt = stockAcPayHisSearchRet.NonAddUpArrGdsCnt;        // ���א��i���v��j
            stockAcPayHisSearchRetWork.ListPriceTaxExcFl = stockAcPayHisSearchRet.ListPriceTaxExcFl;        // �艿�i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.StockUnitPriceFl = stockAcPayHisSearchRet.StockUnitPriceFl;          // �d���P���i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.AddUpADate = stockAcPayHisSearchRet.AddUpADate;                      // �v����t
            stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHisSearchRet.AcPaySlipRowNo;              // �󕥌��s�ԍ�
            stockAcPayHisSearchRetWork.InputSectionCd = stockAcPayHisSearchRet.InputSectionCd;              // ���͋��_�R�[�h
            stockAcPayHisSearchRetWork.InputSectionGuidNm = stockAcPayHisSearchRet.InputSectionGuidNm;      // ���͋��_�K�C�h����
            stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHisSearchRet.InputAgenCd;                    // ���͒S���҃R�[�h
            stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHisSearchRet.InputAgenNm;                    // ���͒S���Җ���
            stockAcPayHisSearchRetWork.MoveStatus = stockAcPayHisSearchRet.MoveStatus;                      // �ړ����
            stockAcPayHisSearchRetWork.CustSlipNo = stockAcPayHisSearchRet.CustSlipNo;                      // �����`�[�ԍ�
            stockAcPayHisSearchRetWork.SlipDtlNum = stockAcPayHisSearchRet.SlipDtlNum;                      // ���גʔ�
            stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHisSearchRet.AcPayNote;                        // �󕥔��l
            stockAcPayHisSearchRetWork.BLGoodsCode = stockAcPayHisSearchRet.BLGoodsCode;                    // BL���i�R�[�h
            stockAcPayHisSearchRetWork.BLGoodsFullName = stockAcPayHisSearchRet.BLGoodsFullName;            // BL���i�R�[�h���́i�S�p�j
            stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHisSearchRet.BfSectionCode;                // �ړ������_�R�[�h
            stockAcPayHisSearchRetWork.BfSectionGuideNm = stockAcPayHisSearchRet.BfSectionGuideNm;          // �ړ������_�K�C�h����
            stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHisSearchRet.BfEnterWarehCode;          // �ړ����q�ɃR�[�h
            stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHisSearchRet.BfEnterWarehName;          // �ړ����q�ɖ���
            stockAcPayHisSearchRetWork.BfShelfNo = stockAcPayHisSearchRet.BfShelfNo;                        // �ړ����I��
            stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHisSearchRet.CustomerCode;                  // ���Ӑ�R�[�h
            stockAcPayHisSearchRetWork.CustomerSnm = stockAcPayHisSearchRet.CustomerSnm;                    // ���Ӑ旪��
            stockAcPayHisSearchRetWork.SupplierCd = stockAcPayHisSearchRet.SupplierCd;                      // �d����R�[�h
            stockAcPayHisSearchRetWork.SupplierSnm = stockAcPayHisSearchRet.SupplierSnm;                    // �d���旪��
            stockAcPayHisSearchRetWork.OpenPriceDiv = stockAcPayHisSearchRet.OpenPriceDiv;                  // �I�[�v�����i�敪
            stockAcPayHisSearchRetWork.StockPrice = stockAcPayHisSearchRet.StockPrice;                      // �d�����z
            stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl = stockAcPayHisSearchRet.SalesUnPrcTaxExcFl;      // ����P���i�Ŕ��C�����j
            stockAcPayHisSearchRetWork.SalesMoney = stockAcPayHisSearchRet.SalesMoney;                      // ������z
            stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHisSearchRet.SupplierStock;                // �d���݌ɐ�
            stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHisSearchRet.AcpOdrCount;                    // �󒍐�
            stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHisSearchRet.SalesOrderCount;            // ������
            stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHisSearchRet.MovingSupliStock;          // �ړ����d���݌ɐ�
            stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHisSearchRet.ShipmentPosCnt;              // �o�׉\��
            stockAcPayHisSearchRetWork.PresentStockCnt = stockAcPayHisSearchRet.PresentStockCnt;            // ���݌ɐ���
            stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHisSearchRet.ArrivalCnt;                      // ���א�
            stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHisSearchRet.ShipmentCnt;                    // �o�א�
            stockAcPayHisSearchRetWork.AcPayHistDateTime = stockAcPayHisSearchRet.AcPayHistDateTime;        // �󕥗����쐬����
            stockAcPayHisSearchRetWork.ShelfNo = stockAcPayHisSearchRet.ShelfNo;                            // �I��

            return stockAcPayHisSearchRetWork;
        }
        // -----ADD 2008/07/17 ----------------------------------------------------------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�N���X�˃��[�N�N���X�j
        ///// </summary>
        ///// <returns>�݌Ɏ󕥗����N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �݌Ɏ󕥗����N���X����݌Ɏ󕥗������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        ///// <br>Programmer : �n糋M�T</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAcDt(StockAcPayHisDt stockAcPayHisDt)
        //{

        //    StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

        //    stockAcPayHisSearchRetWork.EnterpriseCode = stockAcPayHisDt.EnterpriseCode;
        //    stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHisDt.AcPaySlipCd;
        //    stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHisDt.AcPaySlipNum;
        //    stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHisDt.AcPaySlipRowNo;
        //    stockAcPayHisSearchRetWork.AcPaySlipExpNo = stockAcPayHisDt.AcPaySlipExpNo;
        //    stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHisDt.AcPayTransCd;
        //    stockAcPayHisSearchRetWork.GoodsCode = stockAcPayHisDt.GoodsCode;
        //    stockAcPayHisSearchRetWork.GoodsName = stockAcPayHisDt.GoodsName;
        //    stockAcPayHisSearchRetWork.SectionCode = stockAcPayHisDt.SectionCode;
        //    stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHisDt.BfSectionCode;
        //    stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHisDt.BfEnterWarehCode;
        //    stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHisDt.BfEnterWarehName;
        //    stockAcPayHisSearchRetWork.AfAcPayEpCode = stockAcPayHisDt.AfAcPayEpCode;
        //    stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHisDt.AfEnterWarehCode;
        //    stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHisDt.AfEnterWarehName;
        //    stockAcPayHisSearchRetWork.CarrierEpCode = stockAcPayHisDt.CarrierEpCode;
        //    stockAcPayHisSearchRetWork.CarrierEpName = stockAcPayHisDt.CarrierEpName;
        //    stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHisDt.CustomerCode;
        //    stockAcPayHisSearchRetWork.CustomerName = stockAcPayHisDt.CustomerName;
        //    stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHisDt.CustomerName2;
        //    stockAcPayHisSearchRetWork.SalesFormCode = stockAcPayHisDt.SalesFormCode;
        //    stockAcPayHisSearchRetWork.SalesFormName = stockAcPayHisDt.SalesFormName;
        //    stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHisDt.ArrivalCnt;
        //    stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHisDt.ShipmentCnt;
        //    stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHisDt.SupplierStock;
        //    stockAcPayHisSearchRetWork.TrustCount = stockAcPayHisDt.TrustCount;
        //    stockAcPayHisSearchRetWork.ReservedCount = stockAcPayHisDt.ReservedCount;
        //    stockAcPayHisSearchRetWork.AllowStockCnt = stockAcPayHisDt.AllowStockCnt;
        //    stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHisDt.AcpOdrCount;
        //    stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHisDt.SalesOrderCount;
        //    stockAcPayHisSearchRetWork.EntrustCnt = stockAcPayHisDt.EntrustCnt;
        //    stockAcPayHisSearchRetWork.SoldCnt = stockAcPayHisDt.SoldCnt;
        //    stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHisDt.MovingSupliStock;
        //    stockAcPayHisSearchRetWork.MovingTrustStock = stockAcPayHisDt.MovingTrustStock;
        //    stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHisDt.ShipmentPosCnt;
        //    stockAcPayHisSearchRetWork.StockUnitPrice = stockAcPayHisDt.StockUnitPrice;
        //    stockAcPayHisSearchRetWork.CellphoneModelName = stockAcPayHisDt.CellphoneModelName;
        //    stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHisDt.InputAgenCd;
        //    stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHisDt.InputAgenNm;
        //    stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHisDt.AcPayNote;

        //    return stockAcPayHisSearchRetWork;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �f�[�^�R�s�[�����iStockAcPayHisSearchRetWork��StockAcPayHist�j
        /// </summary>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        /// <returns></returns>
        /* -----DEL 2008/07/17 �g�p�N���X�ύX�̈� ------------------------------------------------------------------------->>>>>
        private StockAcPayHist CopyToStockAcPayHistFromWork(StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork)
        {
            StockAcPayHist stockAcPayHist = new StockAcPayHist();

            stockAcPayHist.IoGoodsDay = stockAcPayHisSearchRetWork.IoGoodsDay; // ���o�ד�
            stockAcPayHist.AddUpADate = stockAcPayHisSearchRetWork.AddUpADate; // �v����t
            stockAcPayHist.AcPaySlipCd = stockAcPayHisSearchRetWork.AcPaySlipCd; // �󕥌��`�[�敪
            stockAcPayHist.AcPaySlipNum = stockAcPayHisSearchRetWork.AcPaySlipNum; // �󕥌��`�[�ԍ�
            stockAcPayHist.AcPaySlipRowNo = stockAcPayHisSearchRetWork.AcPaySlipRowNo; // �󕥌��s�ԍ�
            stockAcPayHist.AcPayHistDateTime = stockAcPayHisSearchRetWork.AcPayHistDateTime; // �󕥗����쐬����
            stockAcPayHist.AcPayTransCd = stockAcPayHisSearchRetWork.AcPayTransCd; // �󕥌�����敪
            stockAcPayHist.InputSectionCd = stockAcPayHisSearchRetWork.InputSectionCd; // ���͋��_�R�[�h
            stockAcPayHist.InputSectionGuidNm = stockAcPayHisSearchRetWork.InputSectionGuidNm; // ���͋��_�K�C�h����
            stockAcPayHist.InputAgenCd = stockAcPayHisSearchRetWork.InputAgenCd; // ���͒S���҃R�[�h
            stockAcPayHist.InputAgenNm = stockAcPayHisSearchRetWork.InputAgenNm; // ���͒S���Җ���
            stockAcPayHist.MoveStatus = stockAcPayHisSearchRetWork.MoveStatus; // �ړ����
            stockAcPayHist.CustSlipNo = stockAcPayHisSearchRetWork.CustSlipNo; // �����`�[�ԍ�
            stockAcPayHist.SlipDtlNum = stockAcPayHisSearchRetWork.SlipDtlNum; // ���גʔ�
            stockAcPayHist.AcPayNote = stockAcPayHisSearchRetWork.AcPayNote; // �󕥔��l
            stockAcPayHist.GoodsMakerCd = stockAcPayHisSearchRetWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            stockAcPayHist.MakerName = stockAcPayHisSearchRetWork.MakerName; // ���[�J�[����
            stockAcPayHist.GoodsNo = stockAcPayHisSearchRetWork.GoodsNo; // ���i�ԍ�
            stockAcPayHist.GoodsName = stockAcPayHisSearchRetWork.GoodsName; // ���i����
            stockAcPayHist.BLGoodsCode = stockAcPayHisSearchRetWork.BLGoodsCode; // BL���i�R�[�h
            stockAcPayHist.BLGoodsFullName = stockAcPayHisSearchRetWork.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            stockAcPayHist.SectionCode = stockAcPayHisSearchRetWork.SectionCode; // ���_�R�[�h
            stockAcPayHist.SectionGuideNm = stockAcPayHisSearchRetWork.SectionGuideNm; // ���_�K�C�h����
            stockAcPayHist.WarehouseCode = stockAcPayHisSearchRetWork.WarehouseCode; // �q�ɃR�[�h
            stockAcPayHist.WarehouseName = stockAcPayHisSearchRetWork.WarehouseName; // �q�ɖ���
            stockAcPayHist.ShelfNo = stockAcPayHisSearchRetWork.ShelfNo; // �I��
            stockAcPayHist.BfSectionCode = stockAcPayHisSearchRetWork.BfSectionCode; // �ړ������_�R�[�h
            stockAcPayHist.BfSectionGuideNm = stockAcPayHisSearchRetWork.BfSectionGuideNm; // �ړ������_�K�C�h����
            stockAcPayHist.BfEnterWarehCode = stockAcPayHisSearchRetWork.BfEnterWarehCode; // �ړ����q�ɃR�[�h
            stockAcPayHist.BfEnterWarehName = stockAcPayHisSearchRetWork.BfEnterWarehName; // �ړ����q�ɖ���
            stockAcPayHist.BfShelfNo = stockAcPayHisSearchRetWork.BfShelfNo; // �ړ����I��
            stockAcPayHist.AfSectionCode = stockAcPayHisSearchRetWork.AfSectionCode; // �ړ��拒�_�R�[�h
            stockAcPayHist.AfSectionGuideNm = stockAcPayHisSearchRetWork.AfSectionGuideNm; // �ړ��拒�_�K�C�h����
            stockAcPayHist.AfEnterWarehCode = stockAcPayHisSearchRetWork.AfEnterWarehCode; // �ړ���q�ɃR�[�h
            stockAcPayHist.AfEnterWarehName = stockAcPayHisSearchRetWork.AfEnterWarehName; // �ړ���q�ɖ���
            stockAcPayHist.AfShelfNo = stockAcPayHisSearchRetWork.AfShelfNo; // �ړ���I��
            stockAcPayHist.CustomerCode = stockAcPayHisSearchRetWork.CustomerCode; // ���Ӑ�R�[�h
            stockAcPayHist.CustomerName = stockAcPayHisSearchRetWork.CustomerName; // ���Ӑ於��
            stockAcPayHist.CustomerName2 = stockAcPayHisSearchRetWork.CustomerName2; // ���Ӑ於��2
            stockAcPayHist.CustomerSnm = stockAcPayHisSearchRetWork.CustomerSnm; // ���Ӑ旪��
            stockAcPayHist.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt; // ���א�
            stockAcPayHist.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt; // �o�א�
            stockAcPayHist.OpenPriceDiv = stockAcPayHisSearchRetWork.OpenPriceDiv; // �I�[�v�����i�敪
            stockAcPayHist.ListPriceTaxExcFl = stockAcPayHisSearchRetWork.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            stockAcPayHist.StockUnitPriceFl = stockAcPayHisSearchRetWork.StockUnitPriceFl; // �d���P���i�Ŕ��C�����j
            stockAcPayHist.StockPrice = stockAcPayHisSearchRetWork.StockPrice; // �d�����z
            stockAcPayHist.SalesUnPrcTaxExcFl = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            stockAcPayHist.SalesMoney = stockAcPayHisSearchRetWork.SalesMoney; // ������z
            stockAcPayHist.SupplierStock = stockAcPayHisSearchRetWork.SupplierStock; // �d���݌ɐ�
            stockAcPayHist.AcpOdrCount = stockAcPayHisSearchRetWork.AcpOdrCount; // �󒍐�
            stockAcPayHist.SalesOrderCount = stockAcPayHisSearchRetWork.SalesOrderCount; // ������
            stockAcPayHist.MovingSupliStock = stockAcPayHisSearchRetWork.MovingSupliStock; // �ړ����d���݌ɐ�
            stockAcPayHist.NonAddUpShipmCnt = stockAcPayHisSearchRetWork.NonAddUpShipmCnt; // �o�א��i���v��j
            stockAcPayHist.NonAddUpArrGdsCnt = stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt; // ���א��i���v��j
            stockAcPayHist.ShipmentPosCnt = stockAcPayHisSearchRetWork.ShipmentPosCnt; // �o�׉\��
            stockAcPayHist.PresentStockCnt = stockAcPayHisSearchRetWork.PresentStockCnt; // ���݌ɐ���        

            return stockAcPayHist;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
           -----DEL 2008/07/17 --------------------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 -------------------------------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRet CopyToStockAcPayHistFromWork(StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork)
        {
            StockAcPayHisSearchRet stockAcPayHisSearchRet = new StockAcPayHisSearchRet();

            stockAcPayHisSearchRet.SectionCode = stockAcPayHisSearchRetWork.SectionCode;                    // ���_�R�[�h
            stockAcPayHisSearchRet.SectionGuideNm = stockAcPayHisSearchRetWork.SectionGuideNm;              // ���_�K�C�h����
            stockAcPayHisSearchRet.WarehouseCode = stockAcPayHisSearchRetWork.WarehouseCode;                // �q�ɃR�[�h
            stockAcPayHisSearchRet.WarehouseName = stockAcPayHisSearchRetWork.WarehouseName;                // �q�ɖ���
            stockAcPayHisSearchRet.GoodsMakerCd = stockAcPayHisSearchRetWork.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
            stockAcPayHisSearchRet.MakerName = stockAcPayHisSearchRetWork.MakerName;                        // ���[�J�[����
            stockAcPayHisSearchRet.GoodsNo = stockAcPayHisSearchRetWork.GoodsNo;                            // ���i�ԍ�
            stockAcPayHisSearchRet.GoodsName = stockAcPayHisSearchRetWork.GoodsName;                        // ���i����
            stockAcPayHisSearchRet.IoGoodsDay = stockAcPayHisSearchRetWork.IoGoodsDay;                      // ���o�ד�
            stockAcPayHisSearchRet.AcPaySlipNum = stockAcPayHisSearchRetWork.AcPaySlipNum;                  // �󕥌��`�[�ԍ�
            stockAcPayHisSearchRet.AcPaySlipCd = stockAcPayHisSearchRetWork.AcPaySlipCd;                    // �󕥌��`�[�敪
            stockAcPayHisSearchRet.AcPayTransCd = stockAcPayHisSearchRetWork.AcPayTransCd;                  // �󕥌�����敪
            stockAcPayHisSearchRet.AfSectionCode = stockAcPayHisSearchRetWork.AfSectionCode;                // �ړ��拒�_�R�[�h
            stockAcPayHisSearchRet.AfSectionGuideNm = stockAcPayHisSearchRetWork.AfSectionGuideNm;          // �ړ��拒�_�K�C�h����
            stockAcPayHisSearchRet.AfEnterWarehCode = stockAcPayHisSearchRetWork.AfEnterWarehCode;          // �ړ���q�ɃR�[�h
            stockAcPayHisSearchRet.AfEnterWarehName = stockAcPayHisSearchRetWork.AfEnterWarehName;          // �ړ���q�ɖ���
            stockAcPayHisSearchRet.AfShelfNo = stockAcPayHisSearchRetWork.AfShelfNo;                        // �ړ���I��
            stockAcPayHisSearchRet.NonAddUpShipmCnt = stockAcPayHisSearchRetWork.NonAddUpShipmCnt;          // �o�א��i���v��j
            stockAcPayHisSearchRet.NonAddUpArrGdsCnt = stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt;        // ���א��i���v��j
            stockAcPayHisSearchRet.ListPriceTaxExcFl = stockAcPayHisSearchRetWork.ListPriceTaxExcFl;        // �艿�i�Ŕ��C�����j
            stockAcPayHisSearchRet.StockUnitPriceFl = stockAcPayHisSearchRetWork.StockUnitPriceFl;          // �d���P���i�Ŕ��C�����j
            stockAcPayHisSearchRet.AddUpADate = stockAcPayHisSearchRetWork.AddUpADate;                      // �v����t
            stockAcPayHisSearchRet.AcPaySlipRowNo = stockAcPayHisSearchRetWork.AcPaySlipRowNo;              // �󕥌��s�ԍ�
            stockAcPayHisSearchRet.InputSectionCd = stockAcPayHisSearchRetWork.InputSectionCd;              // ���͋��_�R�[�h
            stockAcPayHisSearchRet.InputSectionGuidNm = stockAcPayHisSearchRetWork.InputSectionGuidNm;      // ���͋��_�K�C�h����
            stockAcPayHisSearchRet.InputAgenCd = stockAcPayHisSearchRetWork.InputAgenCd;                    // ���͒S���҃R�[�h
            stockAcPayHisSearchRet.InputAgenNm = stockAcPayHisSearchRetWork.InputAgenNm;                    // ���͒S���Җ���
            stockAcPayHisSearchRet.MoveStatus = stockAcPayHisSearchRetWork.MoveStatus;                      // �ړ����
            stockAcPayHisSearchRet.CustSlipNo = stockAcPayHisSearchRetWork.CustSlipNo;                      // �����`�[�ԍ�
            stockAcPayHisSearchRet.SlipDtlNum = stockAcPayHisSearchRetWork.SlipDtlNum;                      // ���גʔ�
            stockAcPayHisSearchRet.AcPayNote = stockAcPayHisSearchRetWork.AcPayNote;                        // �󕥔��l
            stockAcPayHisSearchRet.BLGoodsCode = stockAcPayHisSearchRetWork.BLGoodsCode;                    // BL���i�R�[�h
            stockAcPayHisSearchRet.BLGoodsFullName = stockAcPayHisSearchRetWork.BLGoodsFullName;            // BL���i�R�[�h���́i�S�p�j
            stockAcPayHisSearchRet.BfSectionCode = stockAcPayHisSearchRetWork.BfSectionCode;                // �ړ������_�R�[�h
            stockAcPayHisSearchRet.BfSectionGuideNm = stockAcPayHisSearchRetWork.BfSectionGuideNm;          // �ړ������_�K�C�h����
            stockAcPayHisSearchRet.BfEnterWarehCode = stockAcPayHisSearchRetWork.BfEnterWarehCode;          // �ړ����q�ɃR�[�h
            stockAcPayHisSearchRet.BfEnterWarehName = stockAcPayHisSearchRetWork.BfEnterWarehName;          // �ړ����q�ɖ���
            stockAcPayHisSearchRet.BfShelfNo = stockAcPayHisSearchRetWork.BfShelfNo;                        // �ړ����I��
            stockAcPayHisSearchRet.CustomerCode = stockAcPayHisSearchRetWork.CustomerCode;                  // ���Ӑ�R�[�h
            stockAcPayHisSearchRet.CustomerSnm = stockAcPayHisSearchRetWork.CustomerSnm;                    // ���Ӑ旪��
            stockAcPayHisSearchRet.SupplierCd = stockAcPayHisSearchRetWork.SupplierCd;                      // �d����R�[�h
            stockAcPayHisSearchRet.SupplierSnm = stockAcPayHisSearchRetWork.SupplierSnm;                    // �d���旪��
            stockAcPayHisSearchRet.OpenPriceDiv = stockAcPayHisSearchRetWork.OpenPriceDiv;                  // �I�[�v�����i�敪
            stockAcPayHisSearchRet.StockPrice = stockAcPayHisSearchRetWork.StockPrice;                      // �d�����z
            stockAcPayHisSearchRet.SalesUnPrcTaxExcFl = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl;      // ����P���i�Ŕ��C�����j
            stockAcPayHisSearchRet.SalesMoney = stockAcPayHisSearchRetWork.SalesMoney;                      // ������z
            stockAcPayHisSearchRet.SupplierStock = stockAcPayHisSearchRetWork.SupplierStock;                // �d���݌ɐ�
            stockAcPayHisSearchRet.AcpOdrCount = stockAcPayHisSearchRetWork.AcpOdrCount;                    // �󒍐�
            stockAcPayHisSearchRet.SalesOrderCount = stockAcPayHisSearchRetWork.SalesOrderCount;            // ������
            stockAcPayHisSearchRet.MovingSupliStock = stockAcPayHisSearchRetWork.MovingSupliStock;          // �ړ����d���݌ɐ�
            stockAcPayHisSearchRet.ShipmentPosCnt = stockAcPayHisSearchRetWork.ShipmentPosCnt;              // �o�׉\��
            stockAcPayHisSearchRet.PresentStockCnt = stockAcPayHisSearchRetWork.PresentStockCnt;            // ���݌ɐ���
            stockAcPayHisSearchRet.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt;                      // ���א�
            stockAcPayHisSearchRet.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt;                    // �o�א�
            stockAcPayHisSearchRet.AcPayHistDateTime = stockAcPayHisSearchRetWork.AcPayHistDateTime;        // �󕥗����쐬����
            stockAcPayHisSearchRet.ShelfNo = stockAcPayHisSearchRetWork.ShelfNo;                            // �I��

            return stockAcPayHisSearchRet;
        }
        private StockCarEnterCarOutRet CopyToStockCarEnterCarOutFromWork(StockCarEnterCarOutRetWork stockAcPayHisSearchRetWork)
        {
            StockCarEnterCarOutRet stockCarEnterCarOutRet = new StockCarEnterCarOutRet();
            stockCarEnterCarOutRet.StockTotal = stockAcPayHisSearchRetWork.StockTotal;                      // �݌ɑ���
            stockCarEnterCarOutRet.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt;                      // ���א�
            stockCarEnterCarOutRet.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt;                    // �o�א�
            stockCarEnterCarOutRet.RemainCount = stockAcPayHisSearchRetWork.RemainCount;                    // �c��

            return stockCarEnterCarOutRet;
        }
        // -----ADD 2008/07/17 --------------------------------------------------------------------------------------------<<<<<


		/// <summary>
		/// ��������������
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ɏ󕥗���ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
		/// <br>Programer  : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void MemoryCreate()
		{
			// �I�����C���̏ꍇ
			if (LoginInfoAcquisition.OnlineFlag)
			{
				//---���_���擾���i�C���X�^���X��---//
                //this._carrierAcs = new CarrierAcs();
				// ���[�U�[�K�C�h�{�f�B�iHashTable�j
				if (this._stockAcPayLstGdBdTable == null)
				{
					this._stockAcPayLstGdBdTable= new Hashtable();
				}
				// ���[�U�[�K�C�h�{�f�B�iArrayList�j
				if (this._stockAcPayLstGdBdList == null)
				{
					this._stockAcPayLstGdBdList = new ArrayList();
				}
			}

            // �݌Ɏ󕥗����}�X�^�N���XStatic
			if (_stockAcPayListCH == null)
			{
				_stockAcPayListCH = new Hashtable();
			}
		}

        /// <summary>
        /// ���C���A�b�vList��r�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : IComparable �C���^�[�t�F�C�X�̎����B</br>
        /// <br>Programmer : 19077 �n糋M�T</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public class StockAcPayHistKey : IComparer
        {
            /// <summary>
            /// �݌Ɏ󕥗���List��r���\�b�h
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <remarks>
            /// <br>Note       : x��y���r���A�������Ƃ��̓}�C�i�X�A</br>
            /// <br>           : �傫���Ƃ��̓v���X�A�����Ƃ��̓[����Ԃ��܂��B</br>
            /// <br>Programmer : 19077 �n糋M�T</br>
            /// <br>Date       : 2007.05.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                //StockAcPayHist carrierX = (StockAcPayHist)x;                  //DEL 2008/07/17 �g�p�N���X�ύX�̈�
                //StockAcPayHist carrierY = (StockAcPayHist)y;                  //DEL 2008/07/17 �g�p�N���X�ύX�̈�
                StockAcPayHisSearchRet carrierX = (StockAcPayHisSearchRet)x;    //ADD 2008/07/17
                StockAcPayHisSearchRet carrierY = (StockAcPayHisSearchRet)y;    //ADD 2008/07/17

                int year;
                int month;
                int day;
                int xDays;
                int yDays;

                year = carrierX.IoGoodsDay.Year;
                month = carrierX.IoGoodsDay.Month;
                day = carrierX.IoGoodsDay.Day;

                xDays = year * 10000 + month * 10 * day;

                year = carrierY.IoGoodsDay.Year;
                month = carrierY.IoGoodsDay.Month;
                day = carrierY.IoGoodsDay.Day;

                yDays = year * 10000 + month * 10 * day;

                return (xDays - yDays);
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �݌Ɏ󕥗������[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �݌Ɏ󕥗������[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
        /////					 Search�pStatic�������ɕێ����܂��B</br>
        ///// <br>Programer  : �n糋M�T</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private void CopyToStaticFromWorker(ArrayList stockAcPayHistWorkList)
        //{
        //    string hashKey;

        //    foreach (StockAcPayHistWork wkstockAcPayHistWork in stockAcPayHistWorkList)
        //    {
        //        StockAcPayHist wkStockAcPayHist = new StockAcPayHist();

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //hashKey = wkstockAcPayHistWork.EnterpriseCode + "-"
        //        //    //+ wkstockAcPayHistWork.MakerCode + "-"
        //        //        + wkstockAcPayHistWork.GoodsCode + "-"
        //        //        + wkstockAcPayHistWork.AcPaySlipCd + "-"
        //        //        + wkstockAcPayHistWork.AcPaySlipNum + "-"
        //        //;
        //        //wkStockAcPayHist.AcPayNote = wkstockAcPayHistWork.AcPayNote;
        //        //wkStockAcPayHist.AcPaySlipCd = wkstockAcPayHistWork.AcPaySlipCd;
        //        //wkStockAcPayHist.AcPaySlipNum = wkstockAcPayHistWork.AcPaySlipNum;
        //        //wkStockAcPayHist.AcpOdrCount = wkstockAcPayHistWork.AcpOdrCount;
        //        //wkStockAcPayHist.AfAcPayEpCode = wkstockAcPayHistWork.AfAcPayEpCode;
        //        //wkStockAcPayHist.AfEnterWarehCode = wkstockAcPayHistWork.AfEnterWarehCode;
        //        //wkStockAcPayHist.AllowStockCnt = wkstockAcPayHistWork.AllowStockCnt;
        //        //wkStockAcPayHist.ArrivalCnt = wkstockAcPayHistWork.ArrivalCnt;
        //        //wkStockAcPayHist.BfEnterWarehCode = wkstockAcPayHistWork.BfEnterWarehCode;
        //        //wkStockAcPayHist.BfEnterWarehName = wkstockAcPayHistWork.BfEnterWarehName;
        //        //wkStockAcPayHist.BfSectionCode = wkstockAcPayHistWork.BfSectionCode;
        //        //wkStockAcPayHist.CellphoneModelCode = wkstockAcPayHistWork.CellphoneModelCode;
        //        //wkStockAcPayHist.CellphoneModelName = wkstockAcPayHistWork.CellphoneModelName;
        //        //wkStockAcPayHist.CellphoneModelCode = wkstockAcPayHistWork.CellphoneModelCode;
        //        //wkStockAcPayHist.CellphoneModelName = wkstockAcPayHistWork.CellphoneModelName;
        //        //wkStockAcPayHist.CustomerCode = wkstockAcPayHistWork.CustomerCode;
        //        //wkStockAcPayHist.CustomerName = wkstockAcPayHistWork.CustomerName;
        //        //wkStockAcPayHist.CustomerName2 = wkstockAcPayHistWork.CustomerName2;
        //        //wkStockAcPayHist.EnterpriseCode = wkstockAcPayHistWork.EnterpriseCode;
        //        //wkStockAcPayHist.EntrustCnt = wkstockAcPayHistWork.EntrustCnt;
        //        //wkStockAcPayHist.GoodsCode = wkstockAcPayHistWork.GoodsCode;
        //        //wkStockAcPayHist.GoodsName = wkstockAcPayHistWork.GoodsName;
        //        //wkStockAcPayHist.InputAgenCd = wkstockAcPayHistWork.InputAgenCd;
        //        //wkStockAcPayHist.InputAgenNm = wkstockAcPayHistWork.InputAgenNm;
        //        //wkStockAcPayHist.IoGoodsDay = wkstockAcPayHistWork.IoGoodsDay;
        //        //wkStockAcPayHist.MovingSupliStock = wkstockAcPayHistWork.MovingSupliStock;
        //        //wkStockAcPayHist.MovingTrustStock = wkstockAcPayHistWork.MovingTrustStock;
        //        //wkStockAcPayHist.ReservedCount = wkstockAcPayHistWork.ReservedCount;
        //        //wkStockAcPayHist.SalesFormCode = wkstockAcPayHistWork.SalesFormCode;
        //        //wkStockAcPayHist.SalesFormName = wkstockAcPayHistWork.SalesFormName;
        //        //wkStockAcPayHist.SalesOrderCount = wkstockAcPayHistWork.SalesOrderCount;
        //        //wkStockAcPayHist.SectionCode = wkstockAcPayHistWork.SectionCode;
        //        //wkStockAcPayHist.ShipmentCnt = wkstockAcPayHistWork.ShipmentCnt;
        //        //wkStockAcPayHist.ShipmentPosCnt = wkstockAcPayHistWork.ShipmentPosCnt;
        //        //wkStockAcPayHist.SoldCnt = wkstockAcPayHistWork.SoldCnt;
        //        //wkStockAcPayHist.StockUnitPrice = wkstockAcPayHistWork.StockUnitPrice;
        //        //wkStockAcPayHist.SupplierStock = wkstockAcPayHistWork.SupplierStock;
        //        //wkStockAcPayHist.TrustCount = wkstockAcPayHistWork.TrustCount;
        //        //_stockAcPayListCH[hashKey] = wkStockAcPayHist;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// �݌Ɏ󕥗������[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �݌Ɏ󕥗������[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
        /////					 Search�pStatic�������ɕێ����܂��B</br>
        ///// <br>Programer  : �n糋M�T</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private void CopyToStaticFromWorkerDt(ArrayList stockAcPayHistWorkList)
        //{
        //    string hashKey;

        //    foreach ( StockAcPayHisDtWork stockAcPayHistDtWork in stockAcPayHistWorkList)
        //    {
        //        StockAcPayHisDt wkStockAcPayHisDt = new StockAcPayHisDt();

        //        hashKey = stockAcPayHistDtWork.EnterpriseCode + "-"
        //                + stockAcPayHistDtWork.GoodsCode + "-"
        //                + stockAcPayHistDtWork.AcPaySlipCd + "-"
        //                + stockAcPayHistDtWork.AcPaySlipNum + "-"
        //        ;
        //        wkStockAcPayHisDt.AcPayNote = stockAcPayHistDtWork.AcPayNote;
        //        wkStockAcPayHisDt.AcPaySlipCd = stockAcPayHistDtWork.AcPaySlipCd;
        //        wkStockAcPayHisDt.AcPaySlipExpNo = stockAcPayHistDtWork.AcPaySlipExpNo;
        //        wkStockAcPayHisDt.AcPaySlipNum = stockAcPayHistDtWork.AcPaySlipNum;
        //        wkStockAcPayHisDt.AcPaySlipRowNo = stockAcPayHistDtWork.AcPaySlipRowNo;
        //        wkStockAcPayHisDt.AcpOdrCount = stockAcPayHistDtWork.AcpOdrCount;
        //        wkStockAcPayHisDt.AfAcPayEpCode = stockAcPayHistDtWork.AfAcPayEpCode;
        //        wkStockAcPayHisDt.AfEnterWarehCode = stockAcPayHistDtWork.AfEnterWarehCode;
        //        wkStockAcPayHisDt.AllowStockCnt = stockAcPayHistDtWork.AllowStockCnt;
        //        wkStockAcPayHisDt.ArrivalCnt = stockAcPayHistDtWork.ArrivalCnt;
        //        wkStockAcPayHisDt.BfEnterWarehCode = stockAcPayHistDtWork.BfEnterWarehCode;
        //        wkStockAcPayHisDt.BfEnterWarehName = stockAcPayHistDtWork.BfEnterWarehName;
        //        wkStockAcPayHisDt.BfSectionCode = stockAcPayHistDtWork.BfSectionCode;
        //        wkStockAcPayHisDt.CarrierEpCode = stockAcPayHistDtWork.CarrierEpCode;
        //        wkStockAcPayHisDt.CarrierEpName = stockAcPayHistDtWork.CarrierEpName;
        //        wkStockAcPayHisDt.CellphoneModelCode = stockAcPayHistDtWork.CellphoneModelCode;
        //        wkStockAcPayHisDt.CellphoneModelName = stockAcPayHistDtWork.CellphoneModelName;
        //        wkStockAcPayHisDt.CustomerCode = stockAcPayHistDtWork.CustomerCode;
        //        wkStockAcPayHisDt.CustomerName = stockAcPayHistDtWork.CustomerName;
        //        wkStockAcPayHisDt.CustomerName2 = stockAcPayHistDtWork.CustomerName2;
        //        wkStockAcPayHisDt.EnterpriseCode = stockAcPayHistDtWork.EnterpriseCode;
        //        wkStockAcPayHisDt.EntrustCnt = stockAcPayHistDtWork.EntrustCnt;
        //        wkStockAcPayHisDt.GoodsCode = stockAcPayHistDtWork.GoodsCode;
        //        wkStockAcPayHisDt.GoodsName = stockAcPayHistDtWork.GoodsName;
        //        wkStockAcPayHisDt.InputAgenCd = stockAcPayHistDtWork.InputAgenCd;
        //        wkStockAcPayHisDt.InputAgenNm = stockAcPayHistDtWork.InputAgenNm;
        //        wkStockAcPayHisDt.IoGoodsDay = stockAcPayHistDtWork.IoGoodsDay;
        //        wkStockAcPayHisDt.MoveStatus = stockAcPayHistDtWork.MoveStatus;
        //        wkStockAcPayHisDt.MovingSupliStock = stockAcPayHistDtWork.MovingSupliStock;
        //        wkStockAcPayHisDt.MovingTrustStock = stockAcPayHistDtWork.MovingTrustStock;
        //        wkStockAcPayHisDt.ProductNumber = stockAcPayHistDtWork.ProductNumber;
        //        wkStockAcPayHisDt.ProductStockGuid = stockAcPayHistDtWork.ProductStockGuid;
        //        wkStockAcPayHisDt.ReservedCount = stockAcPayHistDtWork.ReservedCount;
        //        wkStockAcPayHisDt.RomDiv = stockAcPayHistDtWork.RomDiv;
        //        wkStockAcPayHisDt.SalesFormCode = stockAcPayHistDtWork.SalesFormCode;
        //        wkStockAcPayHisDt.SalesFormName = stockAcPayHistDtWork.SalesFormName;
        //        wkStockAcPayHisDt.SalesOrderCount = stockAcPayHistDtWork.SalesOrderCount;
        //        wkStockAcPayHisDt.SectionCode = stockAcPayHistDtWork.SectionCode;
        //        wkStockAcPayHisDt.ShipmentCnt = stockAcPayHistDtWork.ShipmentCnt;
        //        wkStockAcPayHisDt.ShipmentPosCnt = stockAcPayHistDtWork.ShipmentPosCnt;
        //        wkStockAcPayHisDt.SimProductNumber = stockAcPayHistDtWork.SimProductNumber;
        //        wkStockAcPayHisDt.SoldCnt = stockAcPayHistDtWork.SoldCnt;
        //        wkStockAcPayHisDt.StockState = stockAcPayHistDtWork.StockState;
        //        wkStockAcPayHisDt.StockTelNo1 = stockAcPayHistDtWork.StockTelNo1;
        //        wkStockAcPayHisDt.StockTelNo2 = stockAcPayHistDtWork.StockTelNo2;
        //        wkStockAcPayHisDt.StockUnitPrice = stockAcPayHistDtWork.StockUnitPrice;
        //        wkStockAcPayHisDt.SupplierStock = stockAcPayHistDtWork.SupplierStock;
        //        wkStockAcPayHisDt.TrustCount = stockAcPayHistDtWork.TrustCount;

        //        _stockAcPayListCH[hashKey] = wkStockAcPayHisDt;

        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// ���[�J���t�@�C���Ǎ��ݏ���
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
		/// <br>Programer  : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void SearchOfflineData()
		{
			// �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			// --- Search�p --- //
			// KeyList�ݒ�
			string[] carrierKeys = new string[1];
			carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ���[�J���t�@�C���Ǎ��ݏ���
			object wkObj = offlineDataSerializer.DeSerialize("CarrierAcs", carrierKeys);
			// ArrayList�ɃZ�b�g
			ArrayList wkList = wkObj as ArrayList;
			
            //if ((wkList != null) &&
            //    (wkList.Count != 0))
            //{
            //    // �݌Ɏ󕥗����N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
            //    CopyToStaticFromWorker(wkList);
            //}
		}
		#endregion

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        public static int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }
		// ---ADD 2013/01/15----->>>>>
        /// <summary>
        /// ���|�Ǘ����肩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :���|�Ǘ�����<br/>
        /// <c>false</c>:���|�Ǘ��Ȃ�        
        /// </returns>
        /// <remarks>
        /// <br>Note       : USB���甃�|�I�v�V�����L����Ǎ���ŁAbool�^�ŕԂ��܂��B</br>
        /// <br>Programer  : FSI���� �G</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );            
            return purchaseStatus >= PurchaseStatus.Contract;            
        }
		// ---ADD 2013/01/15-----<<<<<

    }
}

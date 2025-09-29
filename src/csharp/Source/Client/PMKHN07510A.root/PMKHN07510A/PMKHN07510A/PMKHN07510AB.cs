using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�������l�f�[�^�p�̃f�[�^�R���o�[�g�N���X
    /// </summary>
    public static class MailDefaultDataConverter
    {
        #region �� �w�b�_�f�[�^�p

        #region �� ����f�[�^�iUI�j
        /// <summary>
        /// ���[�������l�w�b�_�f�[�^�ւ̕ϊ��i����f�[�^(UI)�p�j
        /// </summary>
        /// <param name="src">����f�[�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultHeader ConverToMailDefaultHeader(SalesSlip src)
        {
            MailDefaultHeader header = new MailDefaultHeader();

            #region ���ڃR�s�[

            header.AcptAnOdrStatus = src.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            header.SalesSlipNum = src.SalesSlipNum; // ����`�[�ԍ�
            header.SectionCode = src.SectionCode; // ���_�R�[�h
            header.SubSectionCode = src.SubSectionCode; // ����R�[�h
            header.DebitNoteDiv = src.DebitNoteDiv; // �ԓ`�敪
            header.SalesSlipCd = src.SalesSlipCd; // ����`�[�敪
            header.AccRecDivCd = src.AccRecDivCd; // ���|�敪
            header.SalesInpSecCd = src.SalesInpSecCd; // ������͋��_�R�[�h
            header.DemandAddUpSecCd = src.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            header.ResultsAddUpSecCd = src.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            header.UpdateSecCd = src.UpdateSecCd; // �X�V���_�R�[�h
            header.ShipmentDay = src.ShipmentDay; // �o�ד��t
            header.SalesDate = src.SalesDate; // ������t
            header.AddUpADate = src.AddUpADate; // �v����t
            header.EstimateDivide = src.EstimateDivide; // ���ϋ敪
            header.InputAgenCd = src.InputAgenCd; // ���͒S���҃R�[�h
            header.InputAgenNm = src.InputAgenNm; // ���͒S���Җ���
            header.SalesInputCode = src.SalesInputCode; // ������͎҃R�[�h
            header.FrontEmployeeCd = src.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            header.SalesEmployeeCd = src.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            header.TotalAmountDispWayCd = src.TotalAmountDispWayCd; // ���z�\�����@�敪
            header.TotalCost = src.TotalCost; // �������z�v
            header.ConsTaxLayMethod = src.ConsTaxLayMethod; // ����œ]�ŕ���
            header.ClaimCode = src.ClaimCode; // ������R�[�h
            header.CustomerCode = src.CustomerCode; // ���Ӑ�R�[�h
            header.CustomerName = src.CustomerName; // ���Ӑ於��
            header.CustomerName2 = src.CustomerName2; // ���Ӑ於��2
            header.CustomerSnm = src.CustomerSnm; // ���Ӑ旪��
            header.HonorificTitle = src.HonorificTitle; // �h��
            header.CustSlipNo = src.CustSlipNo; // ���Ӑ�`�[�ԍ�
            header.SlipAddressDiv = src.SlipAddressDiv; // �`�[�Z���敪
            header.AddresseeCode = src.AddresseeCode; // �[�i��R�[�h
            header.AddresseeName = src.AddresseeName; // �[�i�於��
            header.AddresseeName2 = src.AddresseeName2; // �[�i�於��2
            header.AddresseePostNo = src.AddresseePostNo; // �[�i��X�֔ԍ�
            header.AddresseeAddr1 = src.AddresseeAddr1; // �[�i��Z��1�i�s���{���s��S�E�����E���j
            header.AddresseeAddr3 = src.AddresseeAddr3; // �[�i��Z��3�i�Ԓn�j
            header.AddresseeAddr4 = src.AddresseeAddr4; // �[�i��Z��4�i�A�p�[�g���́j
            header.AddresseeTelNo = src.AddresseeTelNo; // �[�i��d�b�ԍ�
            header.AddresseeFaxNo = src.AddresseeFaxNo; // �[�i��FAX�ԍ�
            header.PartySaleSlipNum = src.PartySaleSlipNum; // �����`�[�ԍ�
            header.SlipNote = src.SlipNote; // �`�[���l
            header.SlipNote2 = src.SlipNote2; // �`�[���l�Q
            header.SlipNote3 = src.SlipNote3; // �`�[���l�R
            header.RetGoodsReasonDiv = src.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            header.RetGoodsReason = src.RetGoodsReason; // �ԕi���R
            header.BusinessTypeCode = src.BusinessTypeCode; // �Ǝ�R�[�h
            header.DeliveredGoodsDiv = src.DeliveredGoodsDiv; // �[�i�敪
            header.SalesAreaCode = src.SalesAreaCode; // �̔��G���A�R�[�h
            header.EraNameDispCd1 = src.EraNameDispCd1; // �����\���敪�P

            #endregion

            #region ���v���z

            if (src.TotalAmountDispWayCd == 0)
            {
                switch (src.ConsTaxLayMethod)
                {
                    case 0: // �`�[�]��
                    case 1: // ���ד]��
                        // ���㍇�v���z(�Ŕ���)
                        header.SalesTotalPriceTaxExc = src.SalesTotalTaxExc;

                        // �������Łi���v�j
                        header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                        // ���㍇�v���z�i�ō��݁j
                        header.SalesTotalPrice = src.SalesTotalTaxInc; 

                        break;

                    case 2: // �����e
                    case 3: // �����q
                    case 9: // ��ې�
                        // ���㍇�v���z(�Ŕ���)
                        header.SalesTotalPriceTaxExc = 
                            src.ItdedSalesInTax + 
                            src.ItdedSalesOutTax + 
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax + 
                            src.ItdedSalesDisTaxFre;

                        // �������Łi���v�j
                        header.SalesPriceConsTaxTotal = src.SalAmntConsTaxInclu + src.SalesDisTtlTaxInclu;

                        // ���㍇�v���z�i�ō��݁j
                        header.SalesTotalPrice = 
                            src.ItdedSalesInTax + 
                            src.ItdedSalesOutTax + 
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax + 
                            src.ItdedSalesDisInTax + 
                            src.ItdedSalesDisTaxFre +
                            src.SalAmntConsTaxInclu + 
                            src.SalesDisTtlTaxInclu;

                        break;
                }
            }
            else
            {
                // ���㍇�v���z(�Ŕ���)
                header.SalesTotalPriceTaxExc = src.SalesTotalTaxInc;
                
                // �������Łi���v�j
                header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;
                
                // ���㍇�v���z�i�ō��݁j
                header.SalesTotalPrice = src.SalesTotalTaxInc;
            }

            #endregion

            return header;
        }
        #endregion

        #region �� ����f�[�^�i�����[�g�j
        /// <summary>
        /// ���[�������l�w�b�_�f�[�^�ւ̕ϊ��i����f�[�^(�����[�g)�p�j
        /// </summary>
        /// <param name="src">����f�[�^ �����[�g�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultHeader ConverToMailDefaultHeader(SalesSlipWork src)
        {
            MailDefaultHeader header = new MailDefaultHeader();

            #region ���ڃR�s�[

            header.AcptAnOdrStatus = src.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            header.SalesSlipNum = src.SalesSlipNum; // ����`�[�ԍ�
            header.SectionCode = src.SectionCode; // ���_�R�[�h
            header.SubSectionCode = src.SubSectionCode; // ����R�[�h
            header.DebitNoteDiv = src.DebitNoteDiv; // �ԓ`�敪
            header.SalesSlipCd = src.SalesSlipCd; // ����`�[�敪
            header.AccRecDivCd = src.AccRecDivCd; // ���|�敪
            header.SalesInpSecCd = src.SalesInpSecCd; // ������͋��_�R�[�h
            header.DemandAddUpSecCd = src.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            header.ResultsAddUpSecCd = src.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            header.UpdateSecCd = src.UpdateSecCd; // �X�V���_�R�[�h
            header.ShipmentDay = src.ShipmentDay; // �o�ד��t
            header.SalesDate = src.SalesDate; // ������t
            header.AddUpADate = src.AddUpADate; // �v����t
            header.EstimateDivide = src.EstimateDivide; // ���ϋ敪
            header.InputAgenCd = src.InputAgenCd; // ���͒S���҃R�[�h
            header.InputAgenNm = src.InputAgenNm; // ���͒S���Җ���
            header.SalesInputCode = src.SalesInputCode; // ������͎҃R�[�h
            header.FrontEmployeeCd = src.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            header.SalesEmployeeCd = src.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            header.TotalAmountDispWayCd = src.TotalAmountDispWayCd; // ���z�\�����@�敪
            header.TotalCost = src.TotalCost; // �������z�v
            header.ConsTaxLayMethod = src.ConsTaxLayMethod; // ����œ]�ŕ���
            header.ClaimCode = src.ClaimCode; // ������R�[�h
            header.CustomerCode = src.CustomerCode; // ���Ӑ�R�[�h
            header.CustomerName = src.CustomerName; // ���Ӑ於��
            header.CustomerName2 = src.CustomerName2; // ���Ӑ於��2
            header.CustomerSnm = src.CustomerSnm; // ���Ӑ旪��
            header.HonorificTitle = src.HonorificTitle; // �h��
            header.CustSlipNo = src.CustSlipNo; // ���Ӑ�`�[�ԍ�
            header.SlipAddressDiv = src.SlipAddressDiv; // �`�[�Z���敪
            header.AddresseeCode = src.AddresseeCode; // �[�i��R�[�h
            header.AddresseeName = src.AddresseeName; // �[�i�於��
            header.AddresseeName2 = src.AddresseeName2; // �[�i�於��2
            header.AddresseePostNo = src.AddresseePostNo; // �[�i��X�֔ԍ�
            header.AddresseeAddr1 = src.AddresseeAddr1; // �[�i��Z��1�i�s���{���s��S�E�����E���j
            header.AddresseeAddr3 = src.AddresseeAddr3; // �[�i��Z��3�i�Ԓn�j
            header.AddresseeAddr4 = src.AddresseeAddr4; // �[�i��Z��4�i�A�p�[�g���́j
            header.AddresseeTelNo = src.AddresseeTelNo; // �[�i��d�b�ԍ�
            header.AddresseeFaxNo = src.AddresseeFaxNo; // �[�i��FAX�ԍ�
            header.PartySaleSlipNum = src.PartySaleSlipNum; // �����`�[�ԍ�
            header.SlipNote = src.SlipNote; // �`�[���l
            header.SlipNote2 = src.SlipNote2; // �`�[���l�Q
            header.SlipNote3 = src.SlipNote3; // �`�[���l�R
            header.RetGoodsReasonDiv = src.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            header.RetGoodsReason = src.RetGoodsReason; // �ԕi���R
            header.BusinessTypeCode = src.BusinessTypeCode; // �Ǝ�R�[�h
            header.DeliveredGoodsDiv = src.DeliveredGoodsDiv; // �[�i�敪
            header.SalesAreaCode = src.SalesAreaCode; // �̔��G���A�R�[�h
            header.EraNameDispCd1 = src.EraNameDispCd1; // �����\���敪�P

            #endregion

            #region ���v���z

            if (src.TotalAmountDispWayCd == 0)
            {
                switch (src.ConsTaxLayMethod)
                {
                    case 0: // �`�[�]��
                    case 1: // ���ד]��
                        // ���㍇�v���z(�Ŕ���)
                        header.SalesTotalPriceTaxExc = src.SalesTotalTaxExc;

                        // �������Łi���v�j
                        header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                        // ���㍇�v���z�i�ō��݁j
                        header.SalesTotalPrice = src.SalesTotalTaxInc;

                        break;

                    case 2: // �����e
                    case 3: // �����q
                    case 9: // ��ې�
                        // ���㍇�v���z(�Ŕ���)
                        header.SalesTotalPriceTaxExc =
                            src.ItdedSalesInTax +
                            src.ItdedSalesOutTax +
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax +
                            src.ItdedSalesDisTaxFre;

                        // �������Łi���v�j
                        header.SalesPriceConsTaxTotal = src.SalAmntConsTaxInclu + src.SalesDisTtlTaxInclu;

                        // ���㍇�v���z�i�ō��݁j
                        header.SalesTotalPrice =
                            src.ItdedSalesInTax +
                            src.ItdedSalesOutTax +
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax +
                            src.ItdedSalesDisTaxFre +
                            src.SalAmntConsTaxInclu +
                            src.SalesDisTtlTaxInclu;

                        break;
                }
            }
            else
            {
                // ���㍇�v���z(�Ŕ���)
                header.SalesTotalPriceTaxExc = src.SalesTotalTaxInc;

                // �������Łi���v�j
                header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                // ���㍇�v���z�i�ō��݁j
                header.SalesTotalPrice = src.SalesTotalTaxInc;
            }

            #endregion

            return header;
        }
        #endregion

        #endregion

        #region ���׃f�[�^�p

        /// <summary>
        /// ���[�������l���׃f�[�^�ւ̕ϊ��i���㖾�׃f�[�^(UI)�p�j
        /// </summary>
        /// <param name="src">���㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultDetail ConverToMailDefaultDetail(SalesDetail src)
        {
            MailDefaultDetail detail = new MailDefaultDetail();

            #region ���ڃR�s�[

            detail.SalesRowNo = src.SalesRowNo; // ����s�ԍ�
            detail.SalesRowDerivNo = src.SalesRowDerivNo; // ����s�ԍ��}��
            detail.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate; // �[�i�����\���
            detail.GoodsKindCode = src.GoodsKindCode; // ���i����
            detail.GoodsMakerCd = src.GoodsMakerCd; // ���i���[�J�[�R�[�h
            detail.MakerName = src.MakerName; // ���[�J�[����
            detail.GoodsNo = src.GoodsNo; // ���i�ԍ�
            detail.GoodsName = src.GoodsName; // ���i����
            detail.BLGoodsCode = src.BLGoodsCode; // BL���i�R�[�h
            detail.BLGoodsFullName = src.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            detail.EnterpriseGanreCode = src.EnterpriseGanreCode; // ���Е��ރR�[�h
            detail.EnterpriseGanreName = src.EnterpriseGanreName; // ���Е��ޖ���
            detail.WarehouseCode = src.WarehouseCode; // �q�ɃR�[�h
            detail.WarehouseName = src.WarehouseName; // �q�ɖ���
            detail.WarehouseShelfNo = src.WarehouseShelfNo; // �q�ɒI��
            detail.SalesOrderDivCd = src.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            detail.OpenPriceDiv = src.OpenPriceDiv; // �I�[�v�����i�敪
            detail.ListPriceRate = src.ListPriceRate; // �艿��
            detail.ListPriceTaxIncFl = src.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            detail.ListPriceTaxExcFl = src.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            detail.SalesRate = src.SalesRate; // ������
            detail.SalesUnPrcTaxIncFl = src.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            detail.SalesUnPrcTaxExcFl = src.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            detail.SalesUnitCost = src.SalesUnitCost; // �����P��
            detail.PrtBLGoodsCode = src.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            detail.PrtBLGoodsName = src.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            detail.SalesCode = src.SalesCode; // �̔��敪�R�[�h
            detail.SalesCdNm = src.SalesCdNm; // �̔��敪����
            detail.WorkManHour = src.WorkManHour; // ��ƍH��
            detail.ShipmentCnt = src.ShipmentCnt; // �o�א�
            detail.SalesMoneyTaxInc = src.SalesMoneyTaxInc; // ������z�i�ō��݁j
            detail.SalesMoneyTaxExc = src.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            detail.Cost = src.Cost; // ����
            detail.SalesGoodsCd = src.SalesGoodsCd; // ���㏤�i�敪
            detail.SalesPriceConsTax = src.SalesPriceConsTax; // ������z����Ŋz
            detail.TaxationDivCd = src.TaxationDivCd; // �ېŋ敪
            detail.PartySlipNumDtl = src.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            detail.SupplierCd = src.SupplierCd; // �d����R�[�h
            detail.SupplierSnm = src.SupplierSnm; // �d���旪��
            detail.OrderNumber = src.OrderNumber; // �����ԍ�
            detail.WayToOrder = src.WayToOrder; // �������@
            detail.PrtGoodsNo = src.PrtGoodsNo; // ����p���i�ԍ�
            detail.PrtMakerCode = src.PrtMakerCode; // ����p���[�J�[�R�[�h
            detail.PrtMakerName = src.PrtMakerName; // ����p���[�J�[����
            //detail.CampaignCode = src.CampaignCode; // �L�����y�[���R�[�h
            //detail.CampaignName = src.CampaignName; // �L�����y�[������
            //detail.GoodsDivCd = src.GoodsDivCd; // ���i���
            //detail.AnswerDelivDate = src.AnswerDelivDate; // �񓚔[��


            #endregion

            return detail;
        }

        /// <summary>
        /// ���[�������l���׃f�[�^�ւ̕ϊ��i���㖾�׃f�[�^(�����[�g)�p�j
        /// </summary>
        /// <param name="src">���㖾�׃f�[�^ �����[�g�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultDetail ConverToMailDefaultDetail(SalesDetailWork src)
        {
            MailDefaultDetail detail = new MailDefaultDetail();

            #region ���ڃR�s�[

            detail.SalesRowNo = src.SalesRowNo; // ����s�ԍ�
            detail.SalesRowDerivNo = src.SalesRowDerivNo; // ����s�ԍ��}��
            detail.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate; // �[�i�����\���
            detail.GoodsKindCode = src.GoodsKindCode; // ���i����
            detail.GoodsMakerCd = src.GoodsMakerCd; // ���i���[�J�[�R�[�h
            detail.MakerName = src.MakerName; // ���[�J�[����
            detail.GoodsNo = src.GoodsNo; // ���i�ԍ�
            detail.GoodsName = src.GoodsName; // ���i����
            detail.BLGoodsCode = src.BLGoodsCode; // BL���i�R�[�h
            detail.BLGoodsFullName = src.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            detail.EnterpriseGanreCode = src.EnterpriseGanreCode; // ���Е��ރR�[�h
            detail.EnterpriseGanreName = src.EnterpriseGanreName; // ���Е��ޖ���
            detail.WarehouseCode = src.WarehouseCode; // �q�ɃR�[�h
            detail.WarehouseName = src.WarehouseName; // �q�ɖ���
            detail.WarehouseShelfNo = src.WarehouseShelfNo; // �q�ɒI��
            detail.SalesOrderDivCd = src.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            detail.OpenPriceDiv = src.OpenPriceDiv; // �I�[�v�����i�敪
            detail.ListPriceRate = src.ListPriceRate; // �艿��
            detail.ListPriceTaxIncFl = src.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            detail.ListPriceTaxExcFl = src.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            detail.SalesRate = src.SalesRate; // ������
            detail.SalesUnPrcTaxIncFl = src.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            detail.SalesUnPrcTaxExcFl = src.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            detail.SalesUnitCost = src.SalesUnitCost; // �����P��
            detail.PrtBLGoodsCode = src.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            detail.PrtBLGoodsName = src.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            detail.SalesCode = src.SalesCode; // �̔��敪�R�[�h
            detail.SalesCdNm = src.SalesCdNm; // �̔��敪����
            detail.WorkManHour = src.WorkManHour; // ��ƍH��
            detail.ShipmentCnt = src.ShipmentCnt; // �o�א�
            detail.SalesMoneyTaxInc = src.SalesMoneyTaxInc; // ������z�i�ō��݁j
            detail.SalesMoneyTaxExc = src.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            detail.Cost = src.Cost; // ����
            detail.SalesGoodsCd = src.SalesGoodsCd; // ���㏤�i�敪
            detail.SalesPriceConsTax = src.SalesPriceConsTax; // ������z����Ŋz
            detail.TaxationDivCd = src.TaxationDivCd; // �ېŋ敪
            detail.PartySlipNumDtl = src.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            detail.SupplierCd = src.SupplierCd; // �d����R�[�h
            detail.SupplierSnm = src.SupplierSnm; // �d���旪��
            detail.OrderNumber = src.OrderNumber; // �����ԍ�
            detail.WayToOrder = src.WayToOrder; // �������@
            detail.PrtGoodsNo = src.PrtGoodsNo; // ����p���i�ԍ�
            detail.PrtMakerCode = src.PrtMakerCode; // ����p���[�J�[�R�[�h
            detail.PrtMakerName = src.PrtMakerName; // ����p���[�J�[����
            //detail.CampaignCode = src.CampaignCode; // �L�����y�[���R�[�h
            //detail.CampaignName = src.CampaignName; // �L�����y�[������
            //detail.GoodsDivCd = src.GoodsDivCd; // ���i���
            //detail.AnswerDelivDate = src.AnswerDelivDate; // �񓚔[��


            #endregion

            return detail;
        }


        #endregion

        #region �ԗ��f�[�^�p

        /// <summary>
        /// ���[�������l�ԗ��f�[�^�ւ̕ϊ��i���q�Ǘ��}�X�^ �����[�g�p�j
        /// </summary>
        /// <param name="src">���q�Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultCar ConverToMailDefaultCar(CarManagementWork src)
        {
            MailDefaultCar car = new MailDefaultCar();

            #region ���ڃR�s�[

            car.CarMngCode = src.CarMngCode; // �ԗ��Ǘ��R�[�h
            car.NumberPlate1Code = src.NumberPlate1Code; // ���^�������ԍ�
            car.NumberPlate1Name = src.NumberPlate1Name; // ���^�����ǖ���
            car.NumberPlate2 = src.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            car.NumberPlate3 = src.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            car.NumberPlate4 = src.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            car.FirstEntryDate = src.FirstEntryDate; // ���N�x
            car.MakerCode = src.MakerCode; // ���[�J�[�R�[�h
            car.MakerFullName = src.MakerFullName; // ���[�J�[�S�p����
            car.ModelCode = src.ModelCode; // �Ԏ�R�[�h
            car.ModelSubCode = src.ModelSubCode; // �Ԏ�T�u�R�[�h
            car.ModelFullName = src.ModelFullName; // �Ԏ�S�p����
            car.ExhaustGasSign = src.ExhaustGasSign; // �r�K�X�L��
            car.SeriesModel = src.SeriesModel; // �V���[�Y�^��
            car.CategorySignModel = src.CategorySignModel; // �^���i�ޕʋL���j
            car.FullModel = src.FullModel; // �^���i�t���^�j
            car.ModelDesignationNo = src.ModelDesignationNo; // �^���w��ԍ�
            car.CategoryNo = src.CategoryNo; // �ޕʔԍ�
            car.FrameModel = src.FrameModel; // �ԑ�^��
            car.FrameNo = src.FrameNo; // �ԑ�ԍ�
            car.EngineModelNm = src.EngineModelNm; // �G���W���^������
            car.Mileage = src.Mileage; // �ԗ����s����
            car.CarNote = src.CarNote; // ���q���l

            #endregion

            return car;
        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^�ւ̕ϊ��i�󒍃}�X�^(�ԗ�) �����[�g�p�j
        /// </summary>
        /// <param name="src">�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g</param>
        /// <returns></returns>
        public static MailDefaultCar ConverToMailDefaultCar(AcceptOdrCarWork src)
        {
            MailDefaultCar car = new MailDefaultCar();

            #region ���ڃR�s�[

            car.CarMngCode = src.CarMngCode; // �ԗ��Ǘ��R�[�h
            car.NumberPlate1Code = src.NumberPlate1Code; // ���^�������ԍ�
            car.NumberPlate1Name = src.NumberPlate1Name; // ���^�����ǖ���
            car.NumberPlate2 = src.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            car.NumberPlate3 = src.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            car.NumberPlate4 = src.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            car.FirstEntryDate = src.FirstEntryDate; // ���N�x
            car.MakerCode = src.MakerCode; // ���[�J�[�R�[�h
            car.MakerFullName = src.MakerFullName; // ���[�J�[�S�p����
            car.ModelCode = src.ModelCode; // �Ԏ�R�[�h
            car.ModelSubCode = src.ModelSubCode; // �Ԏ�T�u�R�[�h
            car.ModelFullName = src.ModelFullName; // �Ԏ�S�p����
            car.ExhaustGasSign = src.ExhaustGasSign; // �r�K�X�L��
            car.SeriesModel = src.SeriesModel; // �V���[�Y�^��
            car.CategorySignModel = src.CategorySignModel; // �^���i�ޕʋL���j
            car.FullModel = src.FullModel; // �^���i�t���^�j
            car.ModelDesignationNo = src.ModelDesignationNo; // �^���w��ԍ�
            car.CategoryNo = src.CategoryNo; // �ޕʔԍ�
            car.FrameModel = src.FrameModel; // �ԑ�^��
            car.FrameNo = src.FrameNo; // �ԑ�ԍ�
            car.EngineModelNm = src.EngineModelNm; // �G���W���^������
            car.Mileage = src.Mileage; // �ԗ����s����
            car.CarNote = src.CarNote; // ���q���l

            #endregion

            return car;
        }



        #endregion

    }
}

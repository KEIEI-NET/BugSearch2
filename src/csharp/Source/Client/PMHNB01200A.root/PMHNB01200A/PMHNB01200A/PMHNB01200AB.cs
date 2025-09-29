using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
//using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Library.Globarization;

using System.Data;
//using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����f�[�^�ǂݍ��݃N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�ǂݍ��݂��s���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    internal class SalesSlipReader
    {
        private IIOWriteControlDB _iIOWriteControlDB;

        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        private enum OptWorkSettingType : int
        {
            /// <summary>�o�^</summary>
            Write = 0,
            /// <summary>�Ǎ�</summary>
            Read = 1,
            /// <summary>�폜</summary>
            Delete = 2,
        }

        /// <summary>
        /// ����f�[�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<AcceptOdrCarWork> acceptOdrCarList )
        {
            List<SalesDetailWork> addUpSrcDetailList;
            SearchDepsitMain depsitMain;
            SearchDepositAlw depositAlw; 
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWorkList;
            List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList;
            List<StockWork> stockWorkList;

            return ReadSalesSlip( logicalMode, enterpriseCode, acptAnOdrStatus, salesSlipNum, 
                                  out salesSlip, out salesDetailList, 
                                  out addUpSrcDetailList, 
                                  out depsitMain, out depositAlw, 
                                  out stockSlipWorkList, out stockDetailWorkList, 
                                  out addUpSrcStockDetailWorkList, 
                                  out stockWorkList, 
                                  out acceptOdrCarList );
        }

        /// <summary>
        /// ����f�[�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="addUpSrcDetailList"></param>
        /// <param name="depsitMain"></param>
        /// <param name="depositAlw"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="addUpSrcStockDetailWorkList"></param>
        /// <param name="stockWorkList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<SalesDetailWork> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCarWork> acceptOdrCarList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            salesDetailList = null;
            addUpSrcDetailList = null;
            depsitMain = null;
            depositAlw = null;
            stockSlipWorkList = null;
            stockDetailWorkList = null;
            addUpSrcStockDetailWorkList = null;
            stockWorkList = null;
            acceptOdrCarList = null;

            // �p�����[�^
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            paraList.Add( readPara );

            //------------------------------------------------------
            // �����[�g�Q�Ɨp�p�����[�^
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // �����[�g�Q�Ɨp�p�����[�^
            this.SettingIOWriteCtrlOptWork( OptWorkSettingType.Read, out iOWriteCtrlOptWork ); // �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
            paraList.Add( iOWriteCtrlOptWork );

            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;

            if ( _iIOWriteControlDB == null )
            {
                _iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            }
            status = _iIOWriteControlDB.Read( ref paraObj, out retObj1, out retObj2 );

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                SalesSlipWork salesSlipWork;                                // ����f�[�^���[�N�I�u�W�F�N�g
                SalesDetailWork[] salesDetailWorkArray;                     // ���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��
                AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;     // �v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
                //DepsitMainWork depsitMainWork;                              // �����f�[�^���[�N�I�u�W�F�N�g
                DepsitDataWork depsitDataWork;                              // �����f�[�^���[�N�I�u�W�F�N�g
                DepositAlwWork depositAlwWork;                              // ���������f�[�^���[�N�I�u�W�F�N�g
                StockWork[] stockWorkArray;                                 // �݌Ƀ��[�N�f�[�^�I�u�W�F�N�g�z��
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // �󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��

                // CustomSerializeArrayList��������
                this.DivisionCustomSerializeArrayListForAfterRead( retList1, retList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray );

                salesSlip = salesSlipWork;
                if ( salesDetailWorkArray != null )
                {
                    salesDetailList = new List<SalesDetailWork>( salesDetailWorkArray );
                }
                if ( addUpOrgSalesDetailWorkArray != null )
                {
                    addUpSrcDetailList = new List<SalesDetailWork>( addUpOrgSalesDetailWorkArray );
                }
                //depsitMain = (depsitDataWork != null) ? (SearchDepsitMain)DBAndXMLDataMergeParts.CopyPropertyInClass(depsitMainWork, typeof(SearchDepsitMain)) : new SearchDepsitMain();
                depsitMain = ConvertSalesSlip.UIDataFromParamData( depsitDataWork );
                depositAlw = (depositAlwWork != null) ? (SearchDepositAlw)DBAndXMLDataMergeParts.CopyPropertyInClass( depositAlwWork, typeof( SearchDepositAlw ) ) : new SearchDepositAlw();
                acceptOdrCarList = new List<AcceptOdrCarWork>( acceptOdrCarWorkArray );
                if ( (stockWorkArray != null) && (stockWorkArray.Length > 0) )
                {
                    stockWorkList = new List<StockWork>();
                    stockWorkList.AddRange( stockWorkArray );
                }

                if ( stockSlipWorkList == null ) stockSlipWorkList = new List<StockSlipWork>();
                if ( stockDetailWorkList == null ) stockDetailWorkList = new List<StockDetailWork>();
                if ( addUpSrcStockDetailWorkList == null ) addUpSrcStockDetailWorkList = new List<AddUpOrgStockDetailWork>();

            }
            return status;
        }
        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        /// <param name="optWorkSettinType"> </param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork( OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork )
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // ����N�_(0:���� 1:�d�� 2:�d�����㓯���v��)
            //iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this.SalesTtlSt.AcpOdrrAddUpRemDiv;     // �󒍃f�[�^�v��c�敪
            //iOWriteCtrlOptWork.ShipmAddUpRemDiv = this.SalesTtlSt.ShipmAddUpRemDiv;         // �o�׃f�[�^�v��c�敪
            //iOWriteCtrlOptWork.EstimateAddUpRemDiv = this.SalesTtlSt.EstmateAddUpRemDiv;    // ���σf�[�^�v��c�敪
            //iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this.SalesTtlSt.RetGoodsStockEtyDiv;   // �ԕi���݌ɓo�^�敪
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // �c���Ǘ��敪(0:���� �Œ�Ƃ���)
            //iOWriteCtrlOptWork.SupplierSlipDelDiv = this.SalesTtlSt.SupplierSlipDelDiv;     // �d���`�[�폜�敪
            //iOWriteCtrlOptWork.CarMngDivCd = this.CarMngDivCd;                                                   // �ԗ��Ǘ��}�X�^�o�^�敪(0:�o�^���Ȃ� 1:�o�^����)
            switch ( optWorkSettinType )
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
                //case OptWorkSettingType.Delete:
                //    if ( this.SalesTtlSt.SupplierSlipDelDiv == 1 )
                //    {
                //        iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // �d���`�[�폜�敪
                //    }
                //    break;
            }
        }
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�iRead���p�j
        /// </summary>
        /// <param name="paraList1">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�e�f�[�^)</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�v�㌳�^�������̓f�[�^)</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgSalesDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockSlipWorkList">�������̓f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="stockDetailWrokList">�������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="addUpOrgStockDetailWorkList">�������͌v�㌳�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        private void DivisionCustomSerializeArrayListForAfterRead( CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray )
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // ParaList�\��
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                �����񃊃X�g(��P�p�����[�^ ParaList1)
            //    --SalesSlipWork                       ����f�[�^                              ���e�f�[�^
            //    --ArrayList                           ���㖾�׃��X�g
            //        --SalesDetailWork                 ���㖾�׃f�[�^                          ���e�f�[�^
            //    --ArrayList                           �v�㌳���׃��X�g
            //        --AddUppOrgSalesDetailWork        �v�㌳���׃f�[�^                        ���Q�Ƃ̂�(�c���`�F�b�N)
            //    --DepsitDataWork                      �����f�[�^                              ���e�f�[�^�����C���\
            //    --DepositAlwWork                      ���������f�[�^                          ���e�f�[�^�����C���\
            //    --ArrayList                           �݌Ƀ��[�N���X�g                        
            //        --StockWork                       �݌Ƀ��[�N�f�[�^                        ���Q�Ƃ̂�(���݌ɐ��Z�b�g)
            //    --ArrayList                           �󒍃}�X�^�i�ԗ��j���X�g
            //        --AcceptOdrCar                    �󒍃}�X�^�i�ԗ��j
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                �v�㌳�^�������̓��X�g(��Q�p�����[�^ ParaList2)
            //    --CustomSerializeArrayList            �v�㌳��񃊃X�g(�o�ׁA�󒍁A����)
            //      --SalesSlipWork                     �v�㌳�f�[�^                            ���e�f�[�^�����C����(���ς̂�)
            //      --ArrayList                         �v�㌳���׃��X�g
            //          --SalesDetailWork               �v�㌳���׃f�[�^                        ���e�f�[�^�����C����(���ς̂�)
            //      --ArrayList                         �v�㌳�����׃��X�g
            //          --AddUppOrgSalesDetailWork      �v�㌳�����׃f�[�^                      �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --DepsitMainWork                    �v�㌳�����f�[�^                        �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --DepositAlwWork                    �v�㌳���������f�[�^                    �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --ArrayList                         �v�㌳�݌Ƀ��[�N���X�g                        
            //          --StockWork                     �v�㌳�݌Ƀ��[�N�f�[�^                  �����g�p
            //------------------------------------------
            //    --CustomSerializeArrayList            �������̓��X�g(�d���A�o�ׁA����)
            //      --StockSlipWork                     �������̓f�[�^                          ���e�f�[�^�����C����(�󔭒��̂�)
            //      --ArrayList                         �������͖��׃��X�g
            //          --StockDetailWork               �������͖��׃f�[�^                      ���e�f�[�^�����C����(�󔭒��̂�)
            //      --ArrayList                         �������͌v�㌳���׃��X�g
            //          --AddUpOrgStockDetailWork       �������͌v�㌳���׃f�[�^                �����g�p(�������͖��Z�b�g�ƂȂ��)
            //      --PaymentSlpWork                    �������͎x���f�[�^                      ���e�f�[�^�����폜��
            //      --ArrayList                         �������͍݌Ƀ��[�N���X�g                        
            //          --StockWork                     �������͍݌Ƀ��[�N�f�[�^                �����g�p
            //------------------------------------------
            //    --CustomSerializeArrayList            �������͌v�㌳���X�g(�o�ׁA����)
            //      --StockSlipWork                     �������͌v�㌳�f�[�^                    �����g�p
            //      --ArrayList                         �������͌v�㌳���׃��X�g
            //          --StockDetailWork               �������͌v�㌳���׃f�[�^                �����g�p
            //      --ArrayList                         �������͌v�㌳�����׃��X�g
            //          --AddUpOrgStockDetailWork       �������͌v�㌳�����׃f�[�^              �����g�p
            //      --PaymentSlpWork                    �������͌v�㌳�x���f�[�^                �����g�p
            //      --ArrayList                         �������͌v�㌳�݌Ƀ��[�N���X�g                        
            //          --StockWork                     �������͌v�㌳�݌Ƀ��[�N�f�[�^          �����g�p
            //-----------------------------------------------------------------------------------------------------------------------

            salesSlipWork = null;                                                   // ����f�[�^���[�N�I�u�W�F�N�g
            salesDetailWorkArray = null;                                            // ���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��
            addUpOrgSalesDetailWorkArray = null;                                    // �v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            depsitDataWork = null;                                                  // �����f�[�^���[�N�I�u�W�F�N�g
            depositAlwWork = null;                                                  // ���������f�[�^���[�N�I�u�W�F�N�g
            stockWorkArray = null;                                                  // �݌Ƀ��[�N�I�u�W�F�N�g�z��
            stockSlipWorkList = new List<StockSlipWork>();                          // �������̓f�[�^���[�N�I�u�W�F�N�g���X�g
            stockDetailWrokList = new List<StockDetailWork>();                      // �������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g
            addUpOrgStockDetailWorkList = new List<AddUpOrgStockDetailWork>();     // �������͌v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g���X�g
            acceptOdrCarWorkArray = null;                                           // �󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��

            SalesSlipWork tempSalesSlipWork = null;                                 // ����f�[�^���[�N�I�u�W�F�N�g
            SalesDetailWork[] tempSalesDetailWorkArray = null;                      // ���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��
            AddUpOrgSalesDetailWork[] tempAddUpOrgSalesDetailWorkArray = null;      // �v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            DepsitDataWork tempDepsitDataWork = null;                               // �����f�[�^���[�N�I�u�W�F�N�g
            DepositAlwWork tempDepositAlwWork = null;                               // ���������f�[�^���[�N�I�u�W�F�N�g
            StockWork[] tempStockWorkArray = null;                                  // �݌Ƀ��[�N�I�u�W�F�N�g�z��
            StockSlipWork tempStockSlipWork = null;                                 // �������̓f�[�^���[�N�I�u�W�F�N�g
            StockDetailWork[] tempStockDetailWorkArray = null;                      // �������͖��׃f�[�^���[�N�I�u�W�F�N�g�z��
            AddUpOrgStockDetailWork[] tempAddUpOrgStockDetailWorkArray = null;      // �������͌v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            AcceptOdrCarWork[] tempAcceptOdrCarWorkArray = null;                    // �󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��

            //---------------------------------------------------
            // �e�f�[�^�����i�����񃊃X�g�j
            //---------------------------------------------------
            this.DivisionCustomSerializeArrayList( paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray );
            salesSlipWork = tempSalesSlipWork;
            salesDetailWorkArray = tempSalesDetailWorkArray;
            addUpOrgSalesDetailWorkArray = tempAddUpOrgSalesDetailWorkArray;
            depsitDataWork = tempDepsitDataWork;
            depositAlwWork = tempDepositAlwWork;
            stockWorkArray = tempStockWorkArray;
            acceptOdrCarWorkArray = tempAcceptOdrCarWorkArray;

            //---------------------------------------------------
            // �v�㌳�^�������̓��X�g����
            //---------------------------------------------------
            for ( int i = 0; i < paraList2.Count; i++ )
            {
                if ( paraList2[i] is CustomSerializeArrayList )
                {

                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList2[i];
                    foreach ( object tempObj in tempList )
                    {
                        //---------------------------------------------------
                        // �������̓f�[�^
                        //---------------------------------------------------
                        if ( tempObj is ArrayList )
                        {
                            ArrayList tempArrayList = (ArrayList)tempObj;
                            foreach ( object detailObj in tempArrayList )
                            {
                                if ( detailObj is StockDetailWork )
                                {
                                    StockDetailWork tempWork = (StockDetailWork)detailObj;
                                    if ( (tempWork.SalesSlipDtlNumSync != 0) && (tempWork.StockSlipDtlNumSrc == 0) )
                                    {
                                        this.DivisionCustomSerializeArrayList( tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray );
                                        if ( tempStockSlipWork != null )
                                        {
                                            stockSlipWorkList.Add( tempStockSlipWork );
                                            stockDetailWrokList.AddRange( tempStockDetailWorkArray );
                                        }
                                        if ( tempAddUpOrgStockDetailWorkArray != null )
                                        {
                                            addUpOrgStockDetailWorkList.AddRange( tempAddUpOrgStockDetailWorkArray );
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�d�����p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        private void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out StockWork[] stockWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            stockWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;

            this.DivisionCustomSerializeArrayListProc( paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray );

            if ( (objStockSlipWork != null) && (objStockSlipWork is StockSlipWork) ) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ( (objStockDetailWorkArray != null) && (objStockDetailWorkArray is StockDetailWork[]) ) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ( (objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[]) ) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        private void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;

            this.DivisionCustomSerializeArrayListProc( paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray );

            if ( (objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork) ) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ( (objSalesDetailWorkArray != null) && (objSalesDetailWorkArray is SalesDetailWork[]) ) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ( (objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray is AddUpOrgSalesDetailWork[]) ) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ( (objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork) ) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ( (objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork) ) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ( (objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[]) ) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="slipWork">�`�[�f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="detailWorkArray">���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����^�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        private void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray )
        {
            object acceptOdrCarWorkArray = null;
            this.DivisionCustomSerializeArrayListProc( paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray );
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="slipWork">�`�[�f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="detailWorkArray">���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����^�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        private void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray )
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            for ( int i = 0; i < paraList.Count; i++ )
            {
                if ( (paraList[i] is StockSlipWork) || (paraList[i] is SalesSlipWork) )
                {
                    slipWork = paraList[i];
                }
                else if ( (paraList[i] is PaymentSlpWork) || (paraList[i] is DepsitDataWork) )
                {
                    depsitDataWork = paraList[i];
                }
                else if ( paraList[i] is DepositAlwWork )
                {
                    depositAlwWork = paraList[i];
                }
                else if ( paraList[i] is ArrayList )
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if ( list.Count == 0 ) continue;

                    if ( list[0] is AddUpOrgStockDetailWork )
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray( typeof( AddUpOrgStockDetailWork ) );
                    }
                    else if ( list[0] is AddUpOrgSalesDetailWork )
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray( typeof( AddUpOrgSalesDetailWork ) );
                    }
                    else if ( list[0] is StockDetailWork )
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray( typeof( StockDetailWork ) );
                    }
                    else if ( list[0] is SalesDetailWork )
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray( typeof( SalesDetailWork ) );
                    }
                    else if ( list[0] is StockWork )
                    {
                        stockWorkArray = (StockWork[])list.ToArray( typeof( StockWork ) );
                    }
                    else if ( list[0] is AcceptOdrCarWork )
                    {
                        acceptOdrCarWorkArray = (AcceptOdrCarWork[])list.ToArray( typeof( AcceptOdrCarWork ) );
                    }
                }
            }
        }
    }
}

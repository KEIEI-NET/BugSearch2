using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
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
    /// ���o�C���󔭒��f�[�^�������݃N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���o�C���󔭒��f�[�^�������݂��s���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/01  22018 ��� ���b</br>
    /// <br>           : ���R���[(����`�[)�����[�g�̒��o�����N���X��SectionCode���s�v�Ȃ̂ō폜�B</br>
    /// <br></br>
    /// </remarks>
    internal class MblOdrDataWriter
    {
        // �`�[�����[�g(���Ж��擾�Ɏg�p)
        private IFrePSalesSlipDB iFrePSalesSlipDB;
        
        private List<SlipPrtSetWork> _slipPrtSetWorkList = null;
        private List<CustSlipMngWork> _custSlipMngWorkList = null;
        private string _loginSectionCode;

        // ���o�C���󔭒��f�[�^WEB�T�[�r�X�A�N�Z�X�N���X
        private MblOdrDataAcs2 _mblOdrDataAcs;


        // ���_�[��
        private const string ct_SectionZero = "00";
        // �q�Ƀ[��
        private const string ct_WarehouseZero = "0000";
        // ���Ӑ�[��
        private const int ct_CustomerZero = 0;
        // �`�[��� 30:����
        private const int ct_SlipKind_Sales = 30;

        /// <summary>
        /// ���o�C���󔭒��f�[�^��������
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="salesSlip"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int WriteMblOdrData( Guid qrGuid, SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCar, List<SalesDetailWork> salesDetailList, List<AcceptOdrCarWork> acceptOdrCarList )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // �p�����[�^�`�F�b�N
            if (qrGuid == Guid.Empty) return status;
            if (salesSlip == null) return status;
            if (salesDetailList == null ) return status;

            if ( _mblOdrDataAcs == null )
            {
                _mblOdrDataAcs = new MblOdrDataAcs2();
            }

            //------------------------------------------------
            // �w�b�_
            //------------------------------------------------

            // ���o�C���󔭒��f�[�^(�w�b�_)�ǂݍ���
            MblOdrData mblOdrData;
            bool mblOdrExists = ReadMblOdrData( qrGuid, salesSlip, out mblOdrData );

            // ���o�C���󔭒��f�[�^(�w�b�_)�X�V
            ReflectMblOdrDataFromSalesSlip( ref mblOdrData, qrGuid, salesSlip, acceptOdrCar, mblOdrExists );


            //------------------------------------------------
            // ����
            //------------------------------------------------

            // ���o�C���󔭒����׃f�[�^(����)
            List<MblOdrDtl> mblOdrDtlList = new List<MblOdrDtl>();
            foreach ( SalesDetailWork salesDetail in salesDetailList )
            {
                bool isRowDiscount = false;

                // �s�l��/���i�l��/���ߍs���f
                switch ( salesDetail.SalesSlipCdDtl )
                {
                    case 2:
                    case 3:
                        // 2:�s�l��/���i�l���ˎ捞�敪��"1:�s��"�Ƃ���
                        // 3:���ߍs�ˎ捞�敪��"1:�s��"�Ƃ���
                        isRowDiscount = true;
                        break;
                }

                MblOdrDtl mblOdrDtl = CopyToMblOdrDtlFromSalesDetail( salesSlip, salesDetail, isRowDiscount );
                mblOdrDtlList.Add( mblOdrDtl );
            }

            //------------------------------------------------
            // ��������
            //------------------------------------------------
            status = WriteMblOdrDataProc( ref mblOdrData, ref mblOdrDtlList );

            return status;
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="salesSlip"></param>
        /// <param name="mblOdrData"></param>
        /// <returns></returns>
        private bool ReadMblOdrData( Guid qrGuid, SalesSlipWork salesSlip, out MblOdrData mblOdrData )
        {
            bool mblOdrExists = false; // false:���݂��Ȃ�
            List<MblOdrDtl> mblOdrDtlList;

            // Guid���w�肵�ă��o�C���󔭒��f�[�^��ǂݍ���
            int status = _mblOdrDataAcs.Read( qrGuid, out mblOdrData, out mblOdrDtlList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // �O�ׁ̈AKEY���`�F�b�N
                if ( mblOdrData.InqOtherEpCd.Trim() == salesSlip.EnterpriseCode.Trim() &&
                     mblOdrData.MblOdrNo == ToInt( salesSlip.SalesSlipNum ) )
                {
                    mblOdrExists = true; // true:���݂���
                }
            }

            return mblOdrExists;
        }
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="mblOdrData"></param>
        /// <param name="mblOdrDtlList"></param>
        /// <returns></returns>
        private int WriteMblOdrDataProc( ref MblOdrData mblOdrData, ref List<MblOdrDtl> mblOdrDtlList )
        {
            int status = _mblOdrDataAcs.Write( ref mblOdrData, ref mblOdrDtlList );
            return status;
        }

        # region [�f�[�^����]
        /// <summary>
        /// �f�[�^�̃Z�b�g(���o�C���󔭒�������)
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="mblOdrData"></param>
        /// <param name="salesSlip"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="mblOdrExists"></param>
        private void ReflectMblOdrDataFromSalesSlip( ref MblOdrData mblOdrData, Guid qrGuid, SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCar, bool mblOdrExists )
        {
            if ( mblOdrData == null )
            {
                mblOdrData = new MblOdrData();
            }

            // ���Ж��̎擾
            string companyName1;
            string companyName2;
            GetCompanyName( out companyName1, out companyName2, salesSlip );

            # region [�l�Z�b�g]
            mblOdrData.InqOtherEpCd = salesSlip.EnterpriseCode; // �⍇�����ƃR�[�h �� ����f�[�^�D��ƃR�[�h
            mblOdrData.InqOtherSecCd = salesSlip.SalesInpSecCd; // �⍇���拒�_�R�[�h �� ����f�[�^�D������͋��_�R�[�h
            mblOdrData.InqOtherEpNm1 = companyName1; // �⍇�����Ɩ��̂P �� ���Ж���1
            mblOdrData.InqOtherEpNm2 = companyName2; // �⍇�����Ɩ��̂Q �� ���Ж���2
            mblOdrData.InqOriginalEpNm1 = Left( salesSlip.CustomerName, 20 ); // �⍇������Ɩ��̂P �� ����f�[�^�D���Ӑ於��
            mblOdrData.InqOriginalEpNm2 = Left( salesSlip.CustomerName2, 20 ); // �⍇������Ɩ��̂Q �� ����f�[�^�D���Ӑ於��2
            mblOdrData.AnsEmployeeCd = salesSlip.SalesEmployeeCd; // �񓚏]�ƈ��R�[�h �� ����f�[�^�D�̔��]�ƈ��R�[�h
            mblOdrData.AnsEmployeeNm = Left( salesSlip.SalesEmployeeNm, 30 ); // �񓚏]�ƈ����� �� ����f�[�^�D�̔��]�ƈ�����
            mblOdrData.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // �^���w��ԍ� �� �󒍃}�X�^�i�ԗ��j.�^���w��ԍ�
            mblOdrData.CategoryNo = acceptOdrCar.CategoryNo; // �ޕʔԍ� �� �󒍃}�X�^�i�ԗ��j.�ޕʔԍ�
            mblOdrData.MakerCode = acceptOdrCar.MakerCode; // ���[�J�[�R�[�h �� �󒍃}�X�^�i�ԗ��j.���[�J�[�R�[�h
            mblOdrData.ModelCode = acceptOdrCar.ModelCode; // �Ԏ�R�[�h �� �󒍃}�X�^�i�ԗ��j.�Ԏ�R�[�h
            mblOdrData.ModelSubCode = acceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h �� �󒍃}�X�^�i�ԗ��j.�Ԏ�T�u�R�[�h
            mblOdrData.ModelName = Left( acceptOdrCar.ModelFullName, 20 ); // �Ԏ햼 �� �󒍃}�X�^�i�ԗ��j.�Ԏ�S�p����
            mblOdrData.FullModel = Left( acceptOdrCar.FullModel, 44 ); // �^���i�t���^�j �� �󒍃}�X�^�i�ԗ��j.�^���i�t���^�j
            mblOdrData.FrameNo = Left( acceptOdrCar.FrameNo, 30 ); // �ԑ�ԍ� �� �󒍃}�X�^�i�ԗ��j.�ԑ�ԍ�
            mblOdrData.FrameModel = Left( acceptOdrCar.FrameModel, 16 ); // �ԑ�^�� �� �󒍃}�X�^�i�ԗ��j.�ԑ�^��
            mblOdrData.ProduceTypeOfYearNum = acceptOdrCar.FirstEntryDate; // ���Y�N���iNUM�^�C�v�j �� �󒍃}�X�^�i�ԗ��j.���N�x
            mblOdrData.RpColorCode = Left( acceptOdrCar.ColorCode, 20 ); // ���y�A�J���[�R�[�h �� �󒍃}�X�^�i�ԗ��j.�J���[�R�[�h
            mblOdrData.ColorName1 = Left( acceptOdrCar.ColorName1, 40 ); // �J���[����1 �� �󒍃}�X�^�i�ԗ��j.�J���[����1
            mblOdrData.TrimCode = Left( acceptOdrCar.TrimCode, 15 ); // �g�����R�[�h �� �󒍃}�X�^�i�ԗ��j.�g�����R�[�h
            mblOdrData.TrimName = Left( acceptOdrCar.TrimName, 40 ); // �g�������� �� �󒍃}�X�^�i�ԗ��j.�g��������
            mblOdrData.Mileage = acceptOdrCar.Mileage; // �ԗ����s���� �� �󒍃}�X�^�i�ԗ��j.�ԗ����s����
            mblOdrData.ScmBusinessDiv = 1; // 1�FPM�A2�FGD�A3�FRC
            mblOdrData.ScmSlipCd = (short)salesSlip.SalesSlipCd; // �`�[�敪 �� ����f�[�^�D����`�[�敪
            mblOdrData.ScmPmSlipNo = ToInt( salesSlip.SalesSlipNum ); // PM�`�[�ԍ� �� ����f�[�^�D����`�[�ԍ�
            # endregion

            // �V�K�o�^�̏ꍇ�̂�set
            if ( !mblOdrExists )
            {
                mblOdrData.QRTakeInGUID = qrGuid; // QR���ނ�GUID
                mblOdrData.MblOdrNo = ToInt( salesSlip.SalesSlipNum ); // ���o�C���󔭒��ԍ� �� ����f�[�^�D����`�[�ԍ�
                mblOdrData.QRMailTakeInDiv = 0; // 0:���捞�� �P�F�捞�ݍς�
            }
        }

        /// <summary>
        /// �f�[�^�̃Z�b�g(���o�C���󔭒����ׁ����㖾��)
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetail"></param>
        /// <param name="isRowDiscount"></param>
        /// <returns></returns>
        private MblOdrDtl CopyToMblOdrDtlFromSalesDetail( SalesSlipWork salesSlip, SalesDetailWork salesDetail, bool isRowDiscount )
        {
            MblOdrDtl mblOdrDtl = new MblOdrDtl();

            // 0:�����+1�^1:�ԕi��-1
            int countSign;
            if ( salesSlip.SalesSlipCd == 0 )
            {
                countSign = 1;
            }
            else
            {
                countSign = -1;
            }
            

            # region [�l�Z�b�g]
            mblOdrDtl.InqOtherEpCd = salesDetail.EnterpriseCode; // �⍇�����ƃR�[�h �� ���㖾�׃f�[�^.��ƃR�[�h
            mblOdrDtl.MblOdrNo = ToInt( salesDetail.SalesSlipNum ); // ���o�C���󔭒��ԍ� �� ���㖾�׃f�[�^.����`�[�ԍ�
            mblOdrDtl.MblOdrRowNo = salesDetail.SalesRowNo; // ���o�C���󔭒��ԍ��}�� �� ���㖾�׃f�[�^.����s�ԍ�
            if ( !isRowDiscount )
            {
                mblOdrDtl.GoodsDivCd = salesDetail.GoodsKindCode; // ���i��� �� ���㖾�׃f�[�^.���i���� (�s�l������99)
            }
            else
            {
                mblOdrDtl.GoodsDivCd = 99; // 99:�s�l��
            }
            mblOdrDtl.RecyclePrtKindCode = salesDetail.RecycleDiv; // ���T�C�N�����i��� �� ���㖾�׃f�[�^.���T�C�N���敪
            mblOdrDtl.RecyclePrtKindName = Left( salesDetail.RecycleDivNm, 10 ); // ���T�C�N�����i��ʖ��� �� ���㖾�׃f�[�^.���T�C�N���敪����
            if ( !isRowDiscount || salesDetail.ShipmentCnt != 0 )
            {
                mblOdrDtl.BLGoodsCode = salesDetail.PrtBLGoodsCode; // BL���i�R�[�h �� ���㖾�׃f�[�^.BL���i�R�[�h�i����j
            }
            else
            {
                mblOdrDtl.BLGoodsCode = -1; // �s�l���Ȃ��BL����=-1
            }
            mblOdrDtl.AnsGoodsName = Left( GetPrintGoodsName( salesDetail ), 60 ); // �񓚏��i�� �� ���㖾�׃f�[�^.�i���J�ior�i��
            mblOdrDtl.SalesOrderCount = Round( salesDetail.AcceptAnOrderCnt ) * countSign; // ������ �� ���㖾�׃f�[�^.�󒍐���
            mblOdrDtl.DeliveredGoodsCount = Round( salesDetail.ShipmentCnt ) * countSign; // �[�i�� �� ���㖾�׃f�[�^.�o�א�
            mblOdrDtl.GoodsNo = Left( salesDetail.PrtGoodsNo, 40 ); // ���i�ԍ� �� ���㖾�׃f�[�^.����p�i��
            mblOdrDtl.GoodsMakerCd = salesDetail.PrtMakerCode; // ���i���[�J�[�R�[�h �� ���㖾�׃f�[�^.����p���[�J�[�R�[�h
            mblOdrDtl.GoodsMakerNm = Left( salesDetail.PrtMakerName, 24 ); // ���i���[�J�[���� �� ���㖾�׃f�[�^.����p���[�J�[����
            mblOdrDtl.ListPrice = Round( salesDetail.ListPriceTaxExcFl ); // �艿 �� ���㖾�׃f�[�^.�艿�i�Ŕ��C�����j
            mblOdrDtl.UnitPrice = Round( salesDetail.SalesUnPrcTaxExcFl ); // �P�� �� ���㖾�׃f�[�^.����P���i�Ŕ��C�����j
            mblOdrDtl.CommentDtl = salesDetail.DtlNote; // ���l(����) �� ���㖾�׃f�[�^.���ה��l
            mblOdrDtl.ShelfNo = Left( salesDetail.WarehouseShelfNo, 8 ); // �I�� �� ���㖾�׃f�[�^.�q�ɒI��
            # endregion

            return mblOdrDtl;
        }
        /// <summary>
        /// ����i���擾����
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns></returns>
        private string GetPrintGoodsName( SalesDetailWork salesDetail )
        {
            // ���`�[����Ɠ��l�̎d�l�ŕi�����擾���܂��B

            // "�i���J�i"����̏ꍇ��"�i��"
            if ( !string.IsNullOrEmpty( salesDetail.GoodsNameKana ) && salesDetail.GoodsNameKana.Trim() != string.Empty )
            {
                // �i���J�i
                return salesDetail.GoodsNameKana;
            }
            else
            {
                // �i��
                return salesDetail.GoodsName;
            }
        }
        # endregion

        # region [���Ж��̎擾]
        /// <summary>
        /// ���Ж��̎擾
        /// </summary>
        /// <param name="companyName1"></param>
        /// <param name="companyName2"></param>
        /// <param name="salesSlip"></param>
        private void GetCompanyName( out string companyName1, out string companyName2, SalesSlipWork salesSlip )
        {
            companyName1 = string.Empty;
            companyName2 = string.Empty;

            // ���O�C�����_�ޔ�
            _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // �����[�g�I�u�W�F�N�g�擾
            if ( iFrePSalesSlipDB == null )
            {
                iFrePSalesSlipDB = MediationFrePSalesSlipDB.GetFrePSalesSlipDB();
            }
            // �`�[�֘A���擾
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            // --- UPD m.suzuki 2010/07/01 ---------->>>>>
            //int status = iFrePSalesSlipDB.Search( CreateRemotePara( salesSlip, _loginSectionCode ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.Search( CreateRemotePara( salesSlip ), out retObj, out mstList, out msgDiv, out errMsg );
            // --- UPD m.suzuki 2010/07/01 ----------<<<<<

            // ���X�g�W�J
            List<ArrayList> printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
            List<object> masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );

            # region [�}�X�^���X�g�W�J]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // �`�[����p�^�[���ݒ�}�X�^���X�g����
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // �`�[�ݒ�}�X�^���X�g����
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
            }
            # endregion


            int enterpriseNamePrtCd = 0;

            # region [���Ж��󎚋敪�̌���]
            // �`�[�^�C�v���m��
            CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( ct_SlipKind_Sales, salesSlip );
            if ( custSlipMngWork != null )
            {
                // ���Ж��󎚋敪���擾
                SlipPrtSetWork slipPrtSetWork = FindSlipPrtSetWork( salesSlip.EnterpriseCode, custSlipMngWork.SlipPrtSetPaperId, ct_SlipKind_Sales );
                if ( slipPrtSetWork != null )
                {
                    enterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
                }
            }
            # endregion


            // ����`�[�f�[�^
            FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[0][0]);
            if ( slip != null )
            {
                if ( enterpriseNamePrtCd != 1 )
                {
                    // 1:���_�ȊO
                    // ����or�r�b�g�}�b�vor�Ȃ��ˎ��Аݒ�
                    companyName1 = slip.COMPANYINFRF_COMPANYNAME1RF;
                    companyName2 = slip.COMPANYINFRF_COMPANYNAME2RF;
                }
                else
                {
                    // 1:���_
                    // ���_�ˋ��_�ɕR�t�����Ж���
                    companyName1 = slip.COMPANYNMRF_COMPANYNAME1RF;
                    companyName2 = slip.COMPANYNMRF_COMPANYNAME2RF;
                }
            }
        }

        /// <summary>
        /// �`�[�����[�g�Ăяo���p�����[�^����
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/07/01 ---------->>>>>
        //private FrePSalesSlipParaWork CreateRemotePara( SalesSlipWork salesSlip, string loginSectionCode )
        private FrePSalesSlipParaWork CreateRemotePara( SalesSlipWork salesSlip )
        // --- UPD m.suzuki 2010/07/01 ----------<<<<<
        {
            FrePSalesSlipParaWork paraWork = new FrePSalesSlipParaWork();
            paraWork.EnterpriseCode = salesSlip.EnterpriseCode;
            // --- DEL m.suzuki 2010/07/01 ---------->>>>>
            //paraWork.SectionCode = loginSectionCode;
            // --- DEL m.suzuki 2010/07/01 ----------<<<<<
            paraWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
            paraWork.FrePSalesSlipParaKeyList.Add( new FrePSalesSlipParaWork.FrePSalesSlipParaKey( salesSlip.AcptAnOdrStatus, salesSlip.SalesSlipNum ) );

            return paraWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="salesSlip"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, SalesSlipWork salesSlip )
        {
            CustSlipMngWork custSlipMngWork = null;
            string enterpriseCode = salesSlip.EnterpriseCode;

            if ( salesSlip.CustomerCode != 0 )
            {
                // ���Ӑ斈[���_=0]
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, ct_SectionZero, salesSlip.CustomerCode, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( enterpriseCode, "0", salesSlip.CustomerCode, slipKind );
                }
            }

            // ���_��[���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // �����_��"0"����������
                    custSlipMngWork = FindCustSlipMngWork( enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�jFind����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <returns></returns>
        private CustSlipMngWork FindCustSlipMngWork( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( _custSlipMngWorkList == null ) return null;

            return _custSlipMngWorkList.Find(
                        delegate( CustSlipMngWork custSlipMngWork )
                        {
                            return (custSlipMngWork.EnterpriseCode == enterpriseCode)
                                    && ((custSlipMngWork.SectionCode.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (custSlipMngWork.SectionCode.Trim() == string.Empty)))
                                    && (custSlipMngWork.CustomerCode == customerCode)
                                    && (custSlipMngWork.LogicalDeleteCode == 0)
                                    && (custSlipMngWork.SlipPrtKind == slipPrtKind);
                        } );
        }
        /// <summary>
        /// �`�[����ݒ�}�X�^ Find����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private SlipPrtSetWork FindSlipPrtSetWork( string enterpriseCode, string slipPrtSetPaperId, int slipPrtKind )
        {
            if ( _slipPrtSetWorkList == null ) return null;

            return _slipPrtSetWorkList.Find(
                        delegate( SlipPrtSetWork slipPrtSetWork )
                        {
                            return (slipPrtSetWork.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && (slipPrtSetWork.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId)
                                    && (slipPrtSetWork.LogicalDeleteCode == 0)
                                    && (slipPrtSetWork.SlipPrtKind == slipPrtKind);
                        } );
        }
        # endregion

        # region [���ʏ���]
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // �[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int ToInt( string orgValue )
        {
            try
            {
                return Int32.Parse( orgValue );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �w�蕶�����ŃJ�b�g����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string Left( string orgValue, int length )
        {
            if ( !string.IsNullOrEmpty(orgValue) )
            {
                // �ʏ�͎w�蕶��������Ԃ�(�s�����͖��߂Ȃ�)
                return orgValue.Substring( 0, Math.Min( orgValue.Length, length ) );
            }
            else
            {
                // NULL�܂���Empty�Ȃ��Empty��Ԃ�
                return string.Empty;
            }
        }
        # endregion
    }
}

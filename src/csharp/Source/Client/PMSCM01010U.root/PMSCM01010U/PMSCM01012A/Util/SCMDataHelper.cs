//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/17  �C�����e : �e�[�u���̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/24  �C�����e : �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/19  �C�����e : Redmine#25216�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangyi
// �C �� ��  2011/10/11  �C�����e : Redmine#25763 �蓮�񓚁^�����񓚎��̎ԑ�ԍ��Ɋւ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/05/31  �C�����e : ��Q��135 �r�e���ɕԂ��O���[�h���̂�S�p�ŕԂ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341,10364,10431�Ή� PCCforNS�ABLP�̎����񓚔��菈������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/13  �C�����e : SCM��Q�ǉ��A�Ή��@2013/03/06�z�M
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� �@�@�@�@�@�@ �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2013/04/05  �C�����e : 2013/05/22�z�M SCM��Q��50 SPK�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/12/16  �C�����e : SCM�d�|�ꗗ��10590�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/06/04  �C�����e : SCM�d�|�ꗗ��10659�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/19  �C�����e : ���R�����h�Ή� �����������i�敪�̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM�󒍃f�[�^
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM�󒍃f�[�^(�ԗ����)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM�󒍖��׃f�[�^(�⍇���E����)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM�󒍖��׃f�[�^(��)

    /// <summary>
    /// �����񓚋敪�񋓌^
    /// </summary>
    public enum AutoAnswerDiv : int
    {
        /// <summary>0:���Ȃ�</summary>
        None = 0,
        /// <summary>1:�ꕔ�ł��񓚉\�ȏꍇ����</summary>
        Part = 1,
        /// <summary>2:�S�ĉ񓚉\�ȏꍇ�݂̂���</summary>
        All = 2
    }

    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
    /// <summary>
    /// �����񓚋敪�i�⍇���j�񋓌^
    /// </summary>
    public enum AutoAnsInquiryDiv : int
    {
        /// <summary>0:���Ȃ�(�蓮)</summary>
        None = 0,
        /// <summary>1:����(�S�Ď����񓚁j</summary>
        All = 1,
        /// <summary>2:����(�i�荞�ݎ�������)</summary>
        SelectAuto = 2
    }
    /// <summary>
    /// �����񓚋敪�i�����j�񋓌^
    /// </summary>
    public enum AutoAnsOrderDiv : int
    {
        /// <summary>0:���Ȃ�(�蓮)</summary>
        None = 0,
        /// <summary>1:����(�S�Ď�����)</summary>
        All = 1,
        /// <summary>2:����(�ϑ��݌ɕ��̂ݎ�����)</summary>
        TrustAuto = 2
    }
    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<

    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
    /// <summary>
    /// �Y���������񓚋�񋓌^
    /// </summary>
    public enum FuwioutAutoAnsDiv : int
    {
        /// <summary>0:���Ȃ�(�蓮��)</summary>
        None = 0,
        /// <summary>1:����(������)</summary>
        Auto = 1
    }
    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

    /// <summary>
    /// ���i��ʗ񋓌^
    /// </summary>
    public enum GoodsDivCd : int
    {
        /// <summary>0:�������i</summary>
        Pure = 0,
        /// <summary>1:�D�Ǖ��i</summary>
        Prime = 1,
        /// <summary>2:���T�C�N�����i</summary>
        Recycle = 2,
        /// <summary>3:���ϑ���</summary>
        MarketPrice = 3
    }

    /// <summary>
    /// ���T�C�N�����i��ʗ񋓌^
    /// </summary>
    public enum RecyclePrtKindCode : int
    {
        /// <summary>�Ȃ�</summary>
        None = 0,
        /// <summary>���r���h</summary>
        Rebuild = 1,
        /// <summary>����</summary>
        Used = 2
    }

    /// <summary>
    /// �݌ɋ敪�񋓌^
    /// </summary>
    public enum StockDiv : int
    {
        /// <summary>0:��݌�</summary>
        None,
        /// <summary>1:�ϑ��݌�</summary>
        Trust,
        /// <summary>2:���Ӑ�݌�</summary>
        Customer,
        /// <summary>3:�D��q��</summary>
        PriorityWarehouse,
        /// <summary>4:���Ѝ݌�</summary>
        OwnCompany
    }

    /// <summary>
    /// �󒍃X�e�[�^�X�񋓌^
    /// </summary>
    public enum AcptAnOdrStatus : int
    {
        /// <summary>10:����</summary>
        Estimate = 10,
        /// <summary>20:��</summary>
        Order = 20,
        /// <summary>30:����</summary>
        Sales = 30
    }

    // DEL 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ---------->>>>>
    #region PMSCM01011E::SCMEntityUtil.cs �ֈڐ�

    ///// <summary>
    ///// �⍇���E������ʗ񋓌^
    ///// </summary>
    //public enum InqOrdDivCd : int
    //{
    //    /// <summary>1:�⍇��</summary>
    //    Inquiry = 1,
    //    /// <summary>2:����</summary>
    //    Ordering = 2
    //}

    #endregion // PMSCM01011E::SCMEntityUtil.cs �ֈڐ�
    // DEL 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ----------<<<<<

    // 2011/02/14 Add >>>
    /// <summary>
    /// �ŐV���ʋ敪
    /// </summary>
    public enum LatestDiscCode : int
    {
        /// <summary>�w�薳��</summary>
        All = -1,
        /// <summary>�ŐV�f�[�^</summary>
        New = 0,
        /// <summary>��</summary>
        Old = 1
    }
    // 2011/02/14 Add <<<

    /// <summary>
    /// �񓚋敪�񋓌^
    /// </summary>
    public enum AnswerDivCd : int
    {
        /// <summary>0:�A�N�V�����Ȃ�</summary>
        NoAction = 0,
        /// <summary>10:�ꕔ��</summary>
        PartAnswer = 10,
        /// <summary>20:�񓚊���</summary>
        AnswerCompletion = 20,
        /// <summary>30:���F</summary>
        Approve = 30,
        /// <summary>99:�L�����Z��</summary>
        Cancel = 99
    }

    /// <summary>
    /// �┭�E�񓚎�ʗ񋓌^
    /// </summary>
    public enum InqOrdAnsDivCd : int
    {
        /// <summary>1:�⍇���E����</summary>
        Inquiry = 1,
        /// <summary>2:��</summary>
        Answer = 2
    }

    /// <summary>
    /// �`�[���s�敪�񋓌^
    /// </summary>
    public enum SlipPrintDivCd : int
    {
        /// <summary>���Ȃ�</summary>
        None = 0,
        /// <summary>����</summary>
        Do = 1
    }

    /// <summary>
    /// ����œ]�ŕ����񋓌^
    /// </summary>
    /// <remarks>���`�̃\�[�X���ڐA</remarks>
    public enum ConsTaxLayMethod : int
    {
        /// <summary>0:�`�[�P��</summary>
        Slip = 0,
        /// <summary>1:���גP��</summary>
        SlipDetail = 1,
        /// <summary>�����e</summary>
        ClaimParent = 2,
        /// <summary>�����q</summary>
        ClaimChild = 3,
        /// <summary>��ې�</summary>
        TaxFree = 9,

        /// <summary>�`�[�]��</summary>
        SlipLay = 0,
        /// <summary>���ד]��</summary>
        DetailLay = 1,
        /// <summary>�����e</summary>
        DemandParentLay = 2,
        /// <summary>�����q</summary>
        DemandChildLay = 3,
        /// <summary>��ې�</summary>
        TaxExempt = 9
    }

    // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
    /// <summary>
    /// �L�����Z���敪�񋓌^
    /// </summary>
    public enum CancelDiv : short
    {
        /// <summary>0:�L�����Z���Ȃ�</summary>
        None = 0,
        /// <summary>1:�L�����Z������</summary>
        ExistsCancel = 1
    }
    // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

    // 2011/02/14 Add >>>
    /// <summary>
    /// �L�����Z����ԋ敪
    /// </summary>
    public enum CancelCndtinDiv : short
    {
        /// <summary>0:�L�����Z���Ȃ�</summary>
        None = 0,
        /// <summary>10:�L�����Z���v��</summary>
        Cancelling = 10,
        /// <summary>20:�L�����Z���p��</summary>
        Rejected = 20,
        /// <summary>30:�L�����Z���m��</summary>
        Cancelled = 30
    }

    /// <summary>
    /// �⍇���E�������
    /// </summary>
    public enum InqOrdDivCd : int
    {
        /// <summary>1:�⍇��</summary>
        Inquiry = 1,
        /// <summary>2:����</summary>
        Order = 2
    }
    // 2011/02/14 Add <<<

    // 2011/08/18 Add <<<
    /// <summary>
    /// ���i�I��L��
    /// </summary>
    public enum SelectMode : int
    {
        /// <summary>1:����</summary>
        On = 1,
        /// <summary>1:����</summary>
        None = 2
    }


    // 2011/08/18 Add <<<
    /// <summary>
    /// �D��ݒ�\����
    /// </summary>
    public enum SCMPriorOrder : int
    {
        /// <summary>0:�Ȃ�</summary>
        None = 0,
        /// <summary>1:�e����</summary>
        RoughRate = 1,
        /// <summary>2:�P��</summary>
        UnitPrice = 2,
        /// <summary>3:�艿(��)</summary>
        ListPriceHigh = 3,
        /// <summary>4:�艿(��)</summary>
        ListPriceLow = 4,
        /// <summary>5:�L�����y�[��</summary>
        Campaign = 5,
        // ----- UPD 2011/09/26 ----- >>>>> 
        // ----- UPD 2011/09/19 ----- >>>>>
        /// <summary>6:�݌�</summary>
        StockOn = 6,
        /// <summary>7:�ϑ�</summary>
        Trust = 7,
        /// <summary>8:�D��q��</summary>
        PriorityWarehouse = 8,

        ///// <summary>6:�ϑ�</summary>
        //Trust = 6,
        ///// <summary>7:�D��q��</summary>
        //PriorityWarehouse = 7,
        // ----- UPD 2011/09/19 ----- <<<<<
        // ----- UPD 2011/09/26 ----- <<<<<

        // ADD 2013/12/16 SCM�d�|�ꗗ��10590�Ή� -------------------------->>>>>
        /// <summary>9:�D��ݒ�</summary>
        PrioritySetting = 9,
        // ADD 2013/12/16 SCM�d�|�ꗗ��10590�Ή� --------------------------<<<<<
    }

    // ----- ADD 2011/08/10 ----- >>>>>
    /// <summary>
    /// �󔭒����
    /// </summary>
    public enum EnumAcceptOrOrderKind : int
    {
        /// <summary>0:�ʏ�</summary>
        SCM = 0,
        /// <summary>1:PCC-UOE</summary>
        PCCUOE = 1
    }

    /// <summary>
    /// �D��K�p�敪
    /// </summary>
    public enum PriorappliDiv : int
    {
        /// <summary>0:�ʏ�</summary>
        ALL = 0,
        /// <summary>1:SCM</summary>
        SCM = 1,
        /// <summary>2:PCC-UOE</summary>
        PCCUOE = 2
    }
    // ----- ADD 2011/08/10 ----- <<<<<

    // 2011/08/18 Add <<<
    /// <summary>
    /// MODE
    /// </summary>
    public enum ItemSelectDiv : int
    {
        /// <summary>0:OFF</summary>
        OFF = 0,
        /// <summary>1:ON</summary>
        ON = 1
    }
    ////////////////////////////////////////////// 2012/04/25 TERASAKA ADD STA //
    /// <summary>
    /// �ʒm���[�h
    /// </summary>
    public enum NoticeMode : int
    {
        /// <summary>���M����</summary>
        Send = 0,
        /// <summary>���M��</summary>
        Sending = 1,
        /// <summary>��M����</summary>
        Received = 10,
        /// <summary>��M��</summary>
        Receive = 11,
        /// <summary>��������</summary>
        Processed = 20,
        /// <summary>������</summary>
        Processing = 21,
    }
    // 2012/04/25 TERASAKA ADD END //////////////////////////////////////////////

    // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
    /// <summary>
    /// �݌ɏ󋵋敪
    /// </summary>
    public enum StockStatusDiv : int
    {
        /// <summary>����</summary>
        None = 0,
        /// <summary>�݌ɂ���</summary>
        StockOn = 1,
        /// <summary>�ϑ��݌�</summary>
        Trust = 2
    }
    // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

    // ADD 2015/01/19 ���R�����h�Ή� --------------------------------->>>>>
    /// <summary>
    /// ���������i�I���敪
    /// </summary>
    public enum BgnGoodsDiv : short
    {
        /// <summary>�ʏ�</summary>
        Nomal = 0,
        /// <summary>�����������i�I��</summary>
        BargainItem = 1
    }
    // ADD 2015/01/19 ���R�����h�Ή� ---------------------------------<<<<<

    /// <summary>
    /// SCM�f�[�^�̃w���p�N���X
    /// </summary>
    public static class SCMDataHelper
    {
        /// <summary>
        /// �i�Ԃ����݂��邩���f���܂��B
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :���݂��܂��B<br/>
        /// <c>false</c>:���݂��܂���B
        /// </returns>
        public static bool ExistsGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return !string.IsNullOrEmpty(scmOrderDetailRecord.GoodsNo.Trim());
        }

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// BL�R�[�h�����݂��邩���f���܂��B
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :���݂��܂��B<br/>
        /// <c>false</c>:���݂��܂���B
        /// </returns>
        public static bool ExistsBLGoodsCd(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return (scmOrderDetailRecord.BLGoodsCode != 0);
        }

        // ----- 2011/08/10 ----- <<<<<

        /// <summary>
        /// �f�t�H���g�̎󒍃X�e�[�^�X���擾���܂��B
        /// </summary>
        /// <param name="inqOrdDivCd">�⍇���E�������</param>
        /// <returns>
        /// �⍇���E������ʂ�"1:�⍇��"�̏ꍇ�A"10:����"<br/>
        /// �⍇���E������ʂ�"2:����"�̏ꍇ�A"30:����"
        /// </returns>
        public static int GetDefaultAcptAnOdrStatus(int inqOrdDivCd)
        {
            return inqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry) ? (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Sales;
        }

        /// <summary>
        /// �q�ɃR�[�h��<c>null</c>�܂��͋�ł��邩���f���܂��B(<c>0</c>�͋�Ɣ��f���܂�)
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł��B<br/>
        /// <c>false</c>:<c>null</c>�܂��͋�ł͂���܂���B
        /// </returns>
        public static bool IsNullOrEmptyWarehouseCode(string warehouseCode)
        {
            int warehouseCodeNumber = SCMEntityUtil.ConvertNumber(warehouseCode);
            return warehouseCodeNumber.Equals(0);
        }

        /// <summary>
        /// ����񓚂ł��邩���f���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :����񓚂ł��B<br/>
        /// <c>false</c>:����񓚂ł͂���܂���B
        /// </returns>
        public static bool IsMarketPrice(ISCMOrderAnswerRecord answerRecord)
        {
            return answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.MarketPrice);
        }

        /// <summary>
        /// ���T�C�N�����i��ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="recyclePrtKindCode">���T�C�N�����i���</param>
        /// <returns>�Y�����郊�T�C�N�����i��ʖ���</returns>
        public static string GetRecyclePrtKindName(int recyclePrtKindCode)
        {
            switch (recyclePrtKindCode)
            {
                case (int)RecyclePrtKindCode.Rebuild:
                    return "���r���h";  // LITERAL:
                case (int)RecyclePrtKindCode.Used:
                    return "����";      // LITERAL:
                default:
                    return string.Empty;
            }
        }

        #region <�ԗ���������>

        private const int SINGLE_ROW = 0;

        /// <summary>
        /// �o�^�N�������擾���܂��B
        /// </summary>
        /// <param name="searchedCarInfo">�ԗ���������</param>
        /// <returns>�o�^�N����</returns>
        public static DateTime GetEntryDate(PMKEN01010E searchedCarInfo)
        {
            return DateTime.MinValue;   // UNDONE:�ԗ���������.�o�^�N����
        }

        // 2010/03/17 >>>
        ///// <summary>
        ///// ���N�x���擾���܂��B
        ///// </summary>
        ///// <param name="searchedCarInfo">�ԗ���������</param>
        ///// <returns>���N�x</returns>
        //public static DateTime GetFirstEntryDate(PMKEN01010E searchedCarInfo)
        //{
        //    return DateTime.MinValue;   // UNDONE:�ԗ���������.���N�x
        //}

        /// <summary>
        /// ���N�x���擾���܂��B
        /// </summary>
        /// <param name="searchedCarInfo">�ԗ���������</param>
        /// <returns>���N�x</returns>
        public static int GetFirstEntryDate(PMKEN01010E searchedCarInfo)
        {
            if (searchedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return searchedCarInfo.CarModelUIData[SINGLE_ROW].ProduceTypeOfYearInput;   //���N�x
        }
        // 2010/03/17 <<<

        /// <summary>
        /// ���[�J�[�S�p���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���[�J�[�S�p����</returns>
        public static string GetMakerFullName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].MakerFullName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].MakerFullName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���[�J�[���p���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���[�J�[���p����</returns>
        public static string GetMakerHalfName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].MakerHalfName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].MakerHalfName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �Ԏ�R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�Ԏ�R�[�h</returns>
        public static int GetModelCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �Ԏ�T�u�R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�Ԏ�T�u�R�[�h</returns>
        public static int GetModelSubCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelSubCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelSubCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �Ԏ�S�p���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�Ԏ�S�p����</returns>
        public static string GetModelFullName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelFullName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelFullName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �Ԏ피�p���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�Ԏ피�p����</returns>
        public static string GetModelHalfName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelHalfName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelHalfName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �n���R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�n���R�[�h</returns>
        public static int GetSystematicCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SystematicCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SystematicCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �n�����̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�n������</returns>
        public static string GetSystematicName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SystematicName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SystematicName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���Y�N���R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���Y�N���R�[�h</returns>
        public static int GetProduceTypeOfYearCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ProduceTypeOfYearCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ProduceTypeOfYearCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���Y�N�����̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���Y�N������</returns>
        public static string GetProduceTypeOfYearNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ProduceTypeOfYearNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ProduceTypeOfYearNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �J�n���Y�N�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�J�n���Y�N��</returns>
        public static DateTime GetStProduceTypeOfYear(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return DateTime.MinValue;

            //string yyyyMM = seachedCarInfo.CarModelInfo[SINGLE_ROW].StProduceTypeOfYear.ToString("000000");
            //int yyyy = int.Parse(yyyyMM.Substring(0, 4));
            //int mm = int.Parse(yyyyMM.Substring(4, 2));

            //return new DateTime(yyyy, mm, 1);

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return DateTime.MinValue;

            DateTime sdt;
            int iyy = seachedCarInfo.CarModelInfoSummarized[0].StProduceTypeOfYear / 100;
            int imm = seachedCarInfo.CarModelInfoSummarized[0].StProduceTypeOfYear % 100;
            if (( iyy == 9999 ) || ( imm == 99 ))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            return sdt;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �I�����Y�N�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�I�����Y�N��</returns>
        public static DateTime GetEdProduceTypeOfYear(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return DateTime.MinValue;

            //string yyyyMM = seachedCarInfo.CarModelInfo[SINGLE_ROW].EdProduceTypeOfYear.ToString("000000");
            //int yyyy = int.Parse(yyyyMM.Substring(0, 4));
            //int mm = int.Parse(yyyyMM.Substring(4, 2));
            //if (mm > 12) return DateTime.MaxValue;

            //return new DateTime(yyyy, mm, 1);

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return DateTime.MinValue;

            DateTime edt;
            int iyy = seachedCarInfo.CarModelInfoSummarized[0].EdProduceTypeOfYear / 100;
            int imm = seachedCarInfo.CarModelInfoSummarized[0].EdProduceTypeOfYear % 100;
            if (( iyy == 9999 ) || ( imm == 99 ))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            return edt;
            // 2011/03/08 <<<
        }

        

        /// <summary>
        /// �h�A�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�h�A��</returns>
        public static int GetDoorCount(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].DoorCount;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].DoorCount;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �{�f�B�[���R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�{�f�B�[���R�[�h</returns>
        public static int GetBodyNameCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BodyNameCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BodyNameCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �{�f�B�[���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�{�f�B�[����</returns>
        public static string GetBodyName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BodyName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BodyName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �r�K�X�L�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�r�K�X�L��</returns>
        public static string GetExhaustGasSign(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ExhaustGasSign;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ExhaustGasSign;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �V���[�Y�^�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�V���[�Y�^��</returns>
        public static string GetSeriesModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SeriesModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SeriesModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �^��(�ޕʋL��)���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�^��(�ޕʋL��)</returns>
        public static string GetCategorySignModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].CategorySignModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].CategorySignModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �^��(�t���^)���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�^��(�t���^)</returns>
        public static string GetFullModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].FullModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].FullModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �^���w��ԍ����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�^���w��ԍ�</returns>
        public static int GetModelDesignationNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].ModelDesignationNo;
        }

        /// <summary>
        /// �ޕʔԍ����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ޕʔԍ�</returns>
        public static int GetCategoryNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].CategoryNo;
        }

        /// <summary>
        /// �ԑ�^�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ԑ�^��</returns>
        public static string GetFrameModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].FrameModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].FrameModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ԑ�ԍ����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ԑ�ԍ�</returns>
        public static string GetFrameNo(PMKEN01010E seachedCarInfo)
        {
            #region----- DEL 2011/10/12 --------------------------->>>>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return string.Empty;

            //// ----- DEL 2011/10/11 --------------------------->>>>>
            ////return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            //// ----- DEL 2011/10/11 ---------------------------<<<<<
            //// ----- ADD 2011/10/11 --------------------------->>>>>
            //string frameModel = "";
            //string chassisNo = "";
            //int status = GenerateChassisNoFrameFromFrameNo(seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo, out  frameModel, out  chassisNo);
            //if (status == 0)
            //{
            //    return chassisNo;
            //}
            //else
            //{
            //    return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            //}
            // ----- ADD 2011/10/11 ---------------------------<<<<<
            #endregion----- DEL 2011/10/12 ---------------------------<<<<<
            // ----- ADD 2011/10/12 --------------------------->>>>>
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return string.Empty;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            // ----- ADD 2011/10/12 ---------------------------<<<<<            
        }

        // 2011/03/08 Add >>>
        /// <summary>
        /// �ԑ�ԍ��i�����p�j���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ԑ�ԍ�</returns>
        public static int GetSearchFrameNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelUIData[SINGLE_ROW].SearchFrameNo;
        }
        // 2011/03/08 Add <<<

        /// <summary>
        /// ���Y�ԑ�ԍ��J�n���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���Y�ԑ�ԍ��J�n</returns>
        public static int GetStProduceFrameNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelUIData[SINGLE_ROW].StProduceFrameNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].StProduceFrameNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���Y�ԑ�ԍ��I�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���Y�ԑ�ԍ��I��</returns>
        public static int GetEdProduceFrameNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelUIData[SINGLE_ROW].EdProduceFrameNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EdProduceFrameNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �����@�^��(�G���W��)���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�����@�^��(�G���W��)</returns>
        public static string GetEngineModel(PMKEN01010E seachedCarInfo)
        {
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineModel;

            return string.Empty;    // UNDONE:�ԗ���������.�����@�^��(�G���W��)
        }

        /// <summary>
        /// �^���O���[�h���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�^���O���[�h����</returns>
        public static string GetModelGradeNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelGradeNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelGradeNm;
            // 2011/03/08 <<<
        }

        // --- ADD �O�� 2012/05/31 ��135 ---------->>>>>
        /// <summary>
        /// �O���[�h���́i�S�p�j���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo"></param>
        /// <returns></returns>
        public static string GetGradeFullName(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].GradeFullName;
        }
        // --- ADD �O�� 2012/05/31 ��135 ----------<<<<<

        /// <summary>
        /// �G���W���^�����̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�G���W���^������</returns>
        public static string GetEngineModelNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineModelNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EngineModelNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �r�C�ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�r�C�ʖ���</returns>
        public static string GetEngineDisplaceNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineDisplaceNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EngineDisplaceNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// E�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>E�敪����</returns>
        public static string GetEDivNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EDivNm;


            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EDivNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �~�b�V�������̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�~�b�V��������</returns>
        public static string GetTransmissionNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].TransmissionNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].TransmissionNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �V�t�g���̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�V�t�g����</returns>
        public static string GetShiftNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ShiftNm;


            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ShiftNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �쓮�������̂��擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�쓮��������</returns>
        public static string GetWheelDriveMethodNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].WheelDriveMethodNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].WheelDriveMethodNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ�����1���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����1</returns>
        public static string GetAddiCarSpec1(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 Add >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec1;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec1;
            // 2011/03/08 Add <<<
        }

        /// <summary>
        /// �ǉ�����2���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����2</returns>
        public static string GetAddiCarSpec2(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec2;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec2;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ�����3���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����3</returns>
        public static string GetAddiCarSpec3(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec3;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec3;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ�����4���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����4</returns>
        public static string GetAddiCarSpec4(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec4;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec4;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ�����5���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����5</returns>
        public static string GetAddiCarSpec5(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec5;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec5;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ�����6���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ�����6</returns>
        public static string GetAddiCarSpec6(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec6;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec6;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��1���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��1</returns>
        public static string GetAddiCarSpecTitle1(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle1;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle1;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��2���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��2</returns>
        public static string GetAddiCarSpecTitle2(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle2;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle2;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��3���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��3</returns>
        public static string GetAddiCarSpecTitle3(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle3;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle3;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��4���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��4</returns>
        public static string GetAddiCarSpecTitle4(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle4;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle4;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��5���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��5</returns>
        public static string GetAddiCarSpecTitle5(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle5;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle5;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �ǉ������^�C�g��6���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�ǉ������^�C�g��6</returns>
        public static string GetAddiCarSpecTitle6(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle6;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle6;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �֘A�^�����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�֘A�^��</returns>
        public static string GetRelevanceModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].RelevanceModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].RelevanceModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �T�u�Ԗ��R�[�h�擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�T�u�Ԗ��R�[�h</returns>
        public static int GetSubCarNmCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SubCarNmCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SubCarNmCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �^���O���[�h�������擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�^���O���[�h����</returns>
        public static string GetModelGradeSname(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelGradeSname;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelGradeSname;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// �u���b�N�C���X�g�R�[�h���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�u���b�N�C���X�g�R�[�h</returns>
        public static int GetBlockIllustrationCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BlockIllustrationCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BlockIllustrationCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 3D�C���X�gNo���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>3D�C���X�gNo</returns>
        public static int GetThreeDIllustNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ThreeDIllustNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ThreeDIllustNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���i�f�[�^�񋟃t���O���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>���i�f�[�^�񋟃t���O</returns>
        public static int GetPartsDataOfferFlag(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].PartsDataOfferFlag;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].PartsDataOfferFlag;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ���i�f�[�^�񋟃t���O���擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <param name="fullModelFixedNoAry"></param>
        /// <param name="freeSrchMdlFxdNoAry"></param>
        /// <returns>���i�f�[�^�񋟃t���O</returns>
        // 2011/03/08 >>>
        //public static int[] GetFullModelFixedNoAry(PMKEN01010E seachedCarInfo)
        public static void GetFullModelFixedNoAry(PMKEN01010E seachedCarInfo, out int[] fullModelFixedNoAry, out string[] freeSrchMdlFxdNoAry)
        // 2011/03/08 <<<
        {

            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return new int[0];
            //int[] fullModelFixedNoAry = null;
            //CarSearchController carSearcher = new CarSearchController();
            //{
            //    fullModelFixedNoAry = carSearcher.GetFullModelFixedNoArray(seachedCarInfo.CarModelInfo);
            //}

            //return fullModelFixedNoAry;

            fullModelFixedNoAry = new int[0];
            freeSrchMdlFxdNoAry = new string[0];

            if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return;
            CarSearchController carSearcher = new CarSearchController();
            {
                carSearcher.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(seachedCarInfo.CarModelInfo, out fullModelFixedNoAry, out freeSrchMdlFxdNoAry);
            }
            // 2011/03/08 <<<
        }

        // 2011/03/08 Add >>>
        /// <summary>
        /// ������z����擾���܂��B
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�������z��</returns>
        public static byte[] GetCategoryObjAry(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CEqpDefDspInfo == null) return new byte[0];

            return seachedCarInfo.CEqpDefDspInfo.GetByteArray(true);
        }
        // 2011/03/08 Add <<<

        // ADD 2013/04/05 �g�� 2013/05/22�z�M SCM��Q��50 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Y�^�O�ԋ敪
        /// </summary>
        /// <param name="searchedCarInfo">�ԗ���������</param>
        /// <returns>���Y�^�O�ԋ敪 1:���Y 2:�O��</returns>
        public static int GetDomesticForeignCode(PMKEN01010E searchedCarInfo)
        {
            if (searchedCarInfo.CarModelUIData == null) return 0;
            if (searchedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return searchedCarInfo.CarModelUIData[SINGLE_ROW].DomesticForeignCode;
        }
        // ADD 2013/04/05 �g�� 2013/05/22�z�M SCM��Q��50 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion // </�ԗ���������>

        #region <����f�[�^�̃L�[>

        /// <summary>
        /// ���㖾�׃f�[�^�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>��ƃR�[�h("0000000000000000") + �󒍃X�e�[�^�X("00") + ���㖾�גʔ�("000000000000")</returns>
        public static string GetSalesDetailKey(SalesDetail salesDetail)
        {
            return SCMEntityUtil.FormatEnterpriseCode(salesDetail.EnterpriseCode)
                + salesDetail.AcptAnOdrStatus.ToString("00")
                + salesDetail.SalesSlipDtlNum.ToString("000000000000");
        }

        #endregion // </����f�[�^�̃L�[>

        #region <Profile>

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>SCM�󒍖��׃f�[�^(�⍇���E����)�̊ȈՏ��</returns>
        public static string GetProfile(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("\t").Append("�⍇�����ƃR�[�h�F").Append(detailRecord.InqOtherEpCd).Append(Environment.NewLine);
                profile.Append("\t").Append("�⍇���拒�_�R�[�h�F").Append(detailRecord.InqOtherSecCd).Append(Environment.NewLine);
                profile.Append("\t").Append("�⍇���ԍ��F").Append(detailRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("\t").Append("�X�V�N�����F").Append(detailRecord.UpdateDate).Append(Environment.NewLine);
                profile.Append("\t").Append("�X�V�����b�~���b�F").Append(detailRecord.UpdateTime).Append(Environment.NewLine);
                profile.Append("\t").Append("�⍇���s�ԍ��F").Append(detailRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("\t").Append("�⍇���s�ԍ��}�ԁF").Append(detailRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("\t").Append("���i�ԍ��F").Append(detailRecord.GoodsNo).Append(Environment.NewLine);
                profile.Append("\t").Append("BL���i�R�[�h�F").Append(detailRecord.BLGoodsCode);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>SCM�󒍖��׃f�[�^(�⍇���E����)�̊ȈՏ��</returns>
        public static string GetLabel(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("�⍇���ԍ��F").Append(detailRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("�⍇���s�ԍ��F").Append(detailRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("�⍇���s�ԍ��}�ԁF").Append(detailRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("���i��ʁF").Append(detailRecord.GoodsDivCd);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>SCM�󒍖��׃f�[�^(��)�̊ȈՏ��</returns>
        public static string GetProfile(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("�⍇���ԍ��F").Append(answerRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("�⍇���s�ԍ��F").Append(answerRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("�⍇���s�ԍ��}�ԁF").Append(answerRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("���i��ʁF").Append(answerRecord.GoodsDivCd).Append(Environment.NewLine);
                profile.Append("����`�[�ԍ��F").Append(answerRecord.SalesSlipNum);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^(�����[�g�p���[�N)�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="scmAcOdrDataWork">SCM�󒍃f�[�^(�����[�g�p���[�N)�̃��R�[�h</param>
        /// <returns>SCM�󒍃f�[�^(�����[�g�p���[�N)�̊ȈՏ��</returns>
        public static string GetProfile(SCMAcOdrDataWork scmAcOdrDataWork)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("�⍇���ԍ��F").Append(scmAcOdrDataWork.InquiryNumber).Append(Environment.NewLine);
                profile.Append("�󒍃X�e�[�^�X�F").Append(scmAcOdrDataWork.AcptAnOdrStatus);
            }
            return profile.ToString();
        }

        /// <summary>
        /// ���i�A���f�[�^�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���i�A���f�[�^�̊ȈՏ��</returns>
        public static string GetProfile(GoodsUnitData goodsUnitData)
        {
            const char DELIM = ',';

            StringBuilder profile = new StringBuilder();
            {
                profile.Append("BL�R�[�h�F").Append(goodsUnitData.BLGoodsCode).Append(DELIM);
                profile.Append("���[�J�[�R�[�h�F").Append(goodsUnitData.GoodsMakerCd).Append(DELIM);
                profile.Append("�����ރR�[�h�F").Append(goodsUnitData.GoodsMGroup).Append(DELIM);
                profile.Append("���i�ԍ��F").Append(goodsUnitData.GoodsNo).Append(DELIM);
                profile.Append("���i���́F").Append(goodsUnitData.GoodsName).Append(DELIM);
                profile.Append("BL�O���[�v�R�[�h�F").Append(goodsUnitData.BLGroupCode).Append(DELIM);
                profile.Append("���Ӑ�R�[�h�F").Append("?").Append(DELIM);
                profile.Append("���_�R�[�h�F").Append(goodsUnitData.SectionCode).Append(DELIM);
                profile.Append("��ƃR�[�h�F").Append(goodsUnitData.EnterpriseCode);
            }
            return profile.ToString();
        }

        /// <summary>
        /// ���i�A���f�[�^�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^</param>
        /// <returns>���i�A���f�[�^�̊ȈՏ��</returns>
        public static string GetProfile(List<GoodsUnitData> goodsUnitDataList)
        {
            StringBuilder profile = new StringBuilder();
            {
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    profile.Append(GetProfile(goodsUnitData)).Append(Environment.NewLine);
                }
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM���i�A���f�[�^�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="scmGoodsUnitData">SCM���i�A���f�[�^</param>
        /// <returns>SCM���i�A���f�[�^�̊ȈՏ��</returns>
        public static string GetProfile(SCMGoodsUnitData scmGoodsUnitData)
        {
            const char DELIM = ',';

            StringBuilder profile = new StringBuilder();
            {
                profile.Append("BL�R�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode).Append(DELIM);
                profile.Append("���[�J�[�R�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd).Append(DELIM);
                profile.Append("�����ރR�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsMGroup).Append(DELIM);
                profile.Append("���i�ԍ��F").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsNo).Append(DELIM);
                profile.Append("���i���́F").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsName).Append(DELIM);
                profile.Append("BL�O���[�v�R�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.BLGroupCode).Append(DELIM);
                profile.Append("���Ӑ�R�[�h�F").Append(scmGoodsUnitData.CustomerCode).Append(DELIM);
                profile.Append("���_�R�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.SectionCode).Append(DELIM);
                profile.Append("��ƃR�[�h�F").Append(scmGoodsUnitData.RealGoodsUnitData.EnterpriseCode).Append(DELIM);
                profile.Append("�\�����ʁF").Append(scmGoodsUnitData.RealGoodsUnitData.PrimePartsDisplayOrder);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM���i�A���f�[�^�̊ȈՏ����擾���܂��B
        /// </summary>
        /// <param name="scmGoodsUnitDataList">SCM���i�A���f�[�^�̃��X�g</param>
        /// <returns>SCM���i�A���f�[�^�̊ȈՏ��</returns>
        public static string GetProfile(IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            StringBuilder profile = new StringBuilder();
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    profile.Append("\t").Append(GetProfile(scmGoodsUnitData)).Append(Environment.NewLine);
                }
            }
            return profile.ToString();
        }

        #endregion // </Profile>

        /// <summary>
        /// �X�V�����b�~���b���擾���܂��B
        /// </summary>
        /// <param name="updateDate">�X�V�N����(�V�X�e�����t���g�p����ꍇ�A<c>DateTime.Now</c>���g�p���邱��)</param>
        /// <returns>HHmmssxxx</returns>
        public static int GetUpdateTime(DateTime updateDate)
        {
            string HHmmss = updateDate.ToString("HHmmss");
            string msec = updateDate.Millisecond.ToString("000");
            return int.Parse(HHmmss + msec);
        }

        #region <�L���ȃ��R�[�h�ł��邩�̔��f>

        /// <summary>
        /// �L���ȃ��R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�}�X�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public static bool IsAvailableRecord(SCMTtlSt scmTtlSt)
        {
            #region <Guard Phrase>

            if (scmTtlSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmTtlSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmTtlSt.SectionCode.Trim())
                    &&
                scmTtlSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// �L���ȃ��R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmMrktPriSt">SCM���ꉿ�i�ݒ�}�X�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public static bool IsAvailableRecord(SCMMrktPriSt scmMrktPriSt)
        {
            #region <Guard Phrase>

            if (scmMrktPriSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmMrktPriSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmMrktPriSt.SectionCode.Trim())
                    &&
                scmMrktPriSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// �L���ȃ��R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmDeliDateSt">SCM�[���ݒ�}�X�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public static bool IsAvailableRecord(SCMDeliDateSt scmDeliDateSt)
        {
            #region <Guard Phrase>

            if (scmDeliDateSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmDeliDateSt.EnterpriseCode.Trim())
                //    &&
                //!string.IsNullOrEmpty(scmDeliDateSt.SectionCode.Trim())
                    &&
                scmDeliDateSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// �L���ȃ��R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPriorSt">SCM�D��ݒ�}�X�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        public static bool IsAvailableRecord(SCMPriorSt scmPriorSt)
        {
            #region <Guard Phrase>

            if (scmPriorSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmPriorSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmPriorSt.SectionCode.Trim())
                    &&
                scmPriorSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        #endregion // </�L���ȃ��R�[�h�ł��邩�̔��f>

        /// <summary>
        /// �l���K�p�敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="scmTotalSetting">SCM�S�̐ݒ�</param>
        /// <returns>
        /// SCM�S�̐ݒ�.�l���K�p�敪<br/>
        /// 0:���Ȃ�/1:�S��/2:�O���i�ȊO/3:�d�_�i��
        /// </returns>
        public static string GetDiscountApplyName(SCMTtlSt scmTotalSetting)
        {
            if (scmTotalSetting == null) return string.Empty;

            switch (scmTotalSetting.DiscountApplyCd)
            {
                case 0: // ���Ȃ�
                    return "���Ȃ�";
                case 1: // �S��
                    return "�S��";
                case 2: // �O���i�ȊO
                    return "�O���i�ȊO";
                case 3: // �d�_�i��
                    return "�d�_�i��";
                default:
                    return string.Empty;
            }
        }

        #region <���O�Ƀ_���v>

        /// <summary>
        /// ���O�Ƀ_���v���܂��B
        /// </summary>
        /// <param name="cachedImportantPrtStMap">�d�_�i�ڐݒ�̃L���b�V���f�[�^</param>
        public static void DumpToLog(Dictionary<ImportantPrtStAcs.DICKEY, ImportantPrtSt> cachedImportantPrtStMap)
        {
            const string TAB = "\t";
            const string COMMA = ",";

            StringBuilder dumpData = new StringBuilder();
            {
                if (cachedImportantPrtStMap != null)
                {
                    if (cachedImportantPrtStMap.Count > 0)
                    {
                        dumpData.Append("�d�_�i�ڐݒ�̃L���b�V���f�[�^�̌���=").Append(cachedImportantPrtStMap.Count).Append(Environment.NewLine);
                        dumpData.Append("���Ӑ�").Append(COMMA);
                        dumpData.Append("���_").Append(COMMA);
                        dumpData.Append("���[�J�[").Append(COMMA);
                        dumpData.Append("������").Append(COMMA);
                        dumpData.Append("BL").Append(COMMA);
                        dumpData.Append("�i��").Append(COMMA);
                        dumpData.Append("�L���敪").Append(COMMA);
                        dumpData.Append("�_���폜").Append(Environment.NewLine);
                    }
                    else
                    {
                        dumpData.Append(TAB).Append("�d�_�i�ڐݒ�̃L���b�V���f�[�^�̌���=0");
                    }
                    foreach (ImportantPrtSt importantPrtSt in cachedImportantPrtStMap.Values)
                    {
                        dumpData.Append(importantPrtSt.CustomerCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.SectionCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsMakerCd).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsMGroup).Append(COMMA);
                        dumpData.Append(importantPrtSt.BLGoodsCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsNo).Append(COMMA);
                        dumpData.Append(importantPrtSt.ValidDivCd).Append(COMMA);
                        dumpData.Append(importantPrtSt.LogicalDeleteCode).Append(Environment.NewLine);
                    }
                }
                else
                {
                    dumpData.Append(TAB).Append("�d�_�i�ڐݒ�̃L���b�V���f�[�^�� null �ł��B");
                }
            }
            string msg = "�d�_�i�ڐݒ�̃L���b�V���f�[�^" + Environment.NewLine + dumpData.ToString();
            EasyLogger.WriteDebugLog("ImportantPrtStAcs", "GetImportantPrtSt()", LogHelper.GetDebugMsg(msg));
        }

        /// <summary>
        /// ���O�Ƀ_���v���܂��B
        /// </summary>
        /// <param name="cachedCampaignMngMap">�L�����y�[���Ǘ��̃L���b�V���f�[�^</param>
        public static void DumpToLog(Dictionary<CampaignMngAcs.DICKEY, CampaignMng> cachedCampaignMngMap)
        {
            const string TAB = "\t";
            const string COMMA = ",";

            StringBuilder dumpData = new StringBuilder();
            {
                if (cachedCampaignMngMap != null)
                {
                    if (cachedCampaignMngMap.Count > 0)
                    {
                        dumpData.Append("�L�����y�[���Ǘ��̃L���b�V���f�[�^�̌���=").Append(cachedCampaignMngMap.Count).Append(Environment.NewLine);
                        //dumpData.Append("���Ӑ�").Append(COMMA);
                        dumpData.Append("���_").Append(COMMA);
                        dumpData.Append("���[�J�[").Append(COMMA);
                        dumpData.Append("������").Append(COMMA);
                        dumpData.Append("BL").Append(COMMA);
                        dumpData.Append("�i��").Append(COMMA);
                        dumpData.Append("�|��").Append(COMMA);
                        dumpData.Append("���i").Append(COMMA);
                        dumpData.Append("�_���폜").Append(Environment.NewLine);
                    }
                    else
                    {
                        dumpData.Append(TAB).Append("�L�����y�[���Ǘ��̃L���b�V���f�[�^�̌���=0");
                    }
                    foreach (CampaignMng campaignMng in cachedCampaignMngMap.Values)
                    {
                        //dumpData.Append(importantPrtSt.CustomerCode).Append(COMMA);
                        dumpData.Append(campaignMng.SectionCode).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsMakerCd).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsMGroup).Append(COMMA);
                        dumpData.Append(campaignMng.BLGoodsCode).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsNo).Append(COMMA);
                        dumpData.Append(campaignMng.RateVal).Append(COMMA);
                        dumpData.Append(campaignMng.PriceFl).Append(COMMA);
                        dumpData.Append(campaignMng.LogicalDeleteCode).Append(Environment.NewLine);
                    }
                }
                else
                {
                    dumpData.Append(TAB).Append("�L�����y�[���Ǘ��̃L���b�V���f�[�^�� null �ł��B");
                }
            }
            string msg = "�L�����y�[���Ǘ��̃L���b�V���f�[�^" + Environment.NewLine + dumpData.ToString();
            EasyLogger.WriteDebugLog("CampaignMngAcs", "GetRatePriceOfCampaignMng()", LogHelper.GetDebugMsg(msg));
        }

        #endregion // </���O�Ƀ_���v>
        #region----- DEL 2011/10/12 --------------------------->>>>>
        //// ----- ADD 2011/10/11 --------------------------->>>>>
        ///// <summary>
        ///// �ԑ�ԍ����V���V�[����������
        ///// </summary>
        ///// <param name="frameNo">�ԑ�ԍ�</param>
        ///// <param name="frameModel">�ԑ�^��</param>
        ///// <param name="chassisNo">�V���VNo</param>
        ///// <returns>STATUS [0:�������� 0�ȊO:�������s]</returns>
        //public static int GenerateChassisNoFrameFromFrameNo(string frameNo, out string frameModel, out string chassisNo)
        //{
        //    frameModel = "";
        //    chassisNo = "";

        //    if (frameNo == "")
        //    {
        //        frameModel = "";
        //        chassisNo = "";
        //        return 0;
        //    }

        //    // �S�p�����񂪊܂܂�Ă���ꍇ�͐����s�\
        //    if (!IsOneByteChar(frameNo.Trim()))
        //    {
        //        frameModel = "";
        //        chassisNo = "";
        //        return 0;
        //    }

        //    int length = frameNo.Length;
        //    string[] split = frameNo.Split(new Char[] { '-' });

        //    if (split.Length < 0)
        //    {
        //        // �����������ʂ̔z�񐔂�1�ȉ��̏ꍇ�͎Z��s�\
        //        return 1;
        //    }
        //    else if (split.Length == 1)
        //    {
        //        frameModel = split[0];					// �ԑ�^��
        //        chassisNo = "";						// �V���V�[No
        //    }
        //    else if (split.Length == 2)
        //    {
        //        frameModel = split[0];					// �ԑ�^��
        //        chassisNo = split[1];					// �V���V�[No
        //    }
        //    else
        //    {
        //        chassisNo = split[1];

        //        // �z��̂Q�ȍ~����������
        //        for (int i = 3; i < split.Length; i++)
        //        {
        //            chassisNo += "-" + split[i];
        //        }

        //        frameModel = split[0];					// �ԑ�^��
        //    }

        //    // �����`�F�b�N
        //    if (frameModel.Length > 16)
        //    {
        //        frameModel = frameModel.Remove(16, frameModel.Length - 16);
        //    }
        //    if (chassisNo.Length > 18)
        //    {
        //        chassisNo = chassisNo.Remove(18, chassisNo.Length - 18);
        //    }

        //    return 0;
        //}

        ///// <summary>
        ///// 1�o�C�g�����ō\�����ꂽ������ł��邩���� 
        ///// 1�o�C�g�����݂̂ō\�����ꂽ������ : True 
        ///// 2�o�C�g�������܂܂�Ă��镶���� : False
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns>status</returns>
        //private static bool IsOneByteChar(string str)
        //{
        //    byte[] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
        //    if (byte_data.Length == str.Length)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //// ----- ADD 2011/10/11 ---------------------------<<<<<
        #endregion----- DEL 2011/10/12 ---------------------------<<<<<
    }
}

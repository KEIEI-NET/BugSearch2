//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//zz
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/05  �C�����e : �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/17  �C�����e : �e�[�u���̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/24  �C�����e : �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/30  �C�����e : SCM������ ���Y�N���A�ԑ�ԍ��Ή��@���Y�N����DateTime�^�ɕϊ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData.Util
{
    // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ---------->>>>>
    /// <summary>
    /// �񓚍쐬�敪�񋓌^
    /// </summary>
    /// <remarks>
    /// PMSCM01012A::SCMSalesDataMaker.cs ���ڐ�
    /// (�񋓌^���� AnswerCreateDiv �� AnswerCreateDivValue �ɕύX)
    /// </remarks>
    public enum AnswerCreateDivValue : int
    {
        /// <summary>0:����</summary>
        Auto = 0,
        /// <summary>1:�蓮(Web)</summary>
        ManualWeb = 1,
        /// <summary>2:�蓮(���̑�)</summary>
        ManualEtc = 2
    }

    /// <summary>
    /// �⍇���E������ʗ񋓌^
    /// </summary>
    /// <remarks>
    /// PMSCM01012A::SCMDataHelper.cs ���ڐ�
    /// (�񋓌^���� InqOrdDivCd �� InqOrdDivCdValue �ɕύX)
    /// </remarks>
    public enum InqOrdDivCdValue : int
    {
        /// <summary>1:�⍇��</summary>
        Inquiry = 1,
        /// <summary>2:����</summary>
        Ordering = 2
    }

    /// <summary>
    /// CMT�A�g�敪�񋓌^
    /// </summary>
    public enum CMTCooprtDivValue : short
    {
        /// <summary>0:�A�g�Ȃ�</summary>
        None = 0,
        /// <summary>1:�A�g����</summary>
        Cooperates = 1,
        /// <summary>11:�⍇��(����)</summary>
        MadeInquiriesAutomatically = 11,
        /// <summary>12:����(����)</summary>
        OrderedAutomatically = 12
    }
    // ADD 2010/06/24 �u�񓚍쐬�敪�v���u0:�����v�̏ꍇ�A�uCMT�A�g�敪�v��ݒ肷�� ----------<<<<<

    /// <summary>
    /// SCM�󒍃f�[�^���[�e�B���e�B
    /// </summary>
    public static class SCMEntityUtil
    {
        #region <����>

        /// <summary>���t�t�H�[�}�b�g</summary>
        public const string YYYYMMDD = "yyyyMMdd";
        /// <summary>�����t�H�[�}�b�g</summary>
        public const string YYYYMMDDHHMMSS = "yyyyMMddhhmmss";

        /// <summary>
        /// ���t�𐔒l�ɕϊ����܂��B
        /// </summary>
        /// <param name="date">���t</param>
        /// <returns>yyyyMMdd</returns>
        public static int ConvertToYYYYMMDD(DateTime date)
        {
            string yyyyMMdd = date.ToString(YYYYMMDD);
            return int.Parse(yyyyMMdd);
        }

        /// <summary>
        /// ���t�ɕϊ����܂��B
        /// </summary>
        /// <param name="yyyyMMdd">���t��(yyyyMMdd)</param>
        /// <returns>"yyyy/MM/dd"</returns>
        public static DateTime ConvertToDate(int yyyyMMdd)
        {
            #region <Guard Phrase>

            if (yyyyMMdd <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            string yyyy = yyyyMMdd.ToString().Substring(0, 4);
            string MM   = yyyyMMdd.ToString().Substring(4, 2);
            string dd   = yyyyMMdd.ToString().Substring(6, 2);

            return new DateTime(int.Parse(yyyy), int.Parse(MM), int.Parse(dd));
        }

        /// <summary>
        /// �����ɕϊ����܂��B
        /// </summary>
        /// <param name="longNumber">������</param>
        /// <returns>"yyyy/MM/dd hh:mm:ss"</returns>
        public static DateTime ConvertToDateTime(long longNumber)
        {
            #region <Guard Phrase>

            if (longNumber <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            return new DateTime(longNumber);
        }

        /// <summary>
        /// �����𐔒l�ɕϊ����܂��B
        /// </summary>
        /// <param name="dateTime">����</param>
        /// <returns>Convert.ToInt64(dateTime)</returns>
        public static long ConvertToLong(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        #endregion // </����>

        #region <�L�[>

        /// <summary>
        /// SCM�󒍃f�[�^���R�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^���R�[�h</param>
        /// <returns>
        /// �⍇������ƃR�[�h + �⍇�������_�R�[�h + �⍇�����ƃR�[�h + �⍇���拒�_�R�[�h + �⍇���ԍ� + �X�V�N���� + �X�V�����b�~���b + �⍇���������
        /// </returns>
        public static string GetHeaderRecordKey(ISCMOrderHeaderRecord headerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(headerRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(headerRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(headerRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(headerRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(headerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(headerRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // �X�V�N����
                key.Append(headerRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // �X�V�����b�~���b
                key.Append(headerRecord.AcptAnOdrStatus.ToString(ACPT_AN_ODR_STATUS));  // �󒍃X�e�[�^�X
                key.Append(FormatSalseSlipNum(headerRecord.SalesSlipNum));              // ����`�[�ԍ�

                key.Append(headerRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // �⍇���E�������
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^(�ԗ����)���R�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="carRecord">SCM�󒍃f�[�^(�ԗ����)���R�[�h</param>
        /// <returns>
        /// �󒍃X�e�[�^�X����є���`�[�ԍ���
        /// �����񓚏�����SCM�󒍌n�f�[�^�̊Ǘ��A���S���Y����A�s�s���ł��邽�߁A
        /// �܂݂܂���B
        /// </returns>
        public static string GetCarRecordKey(ISCMOrderCarRecord carRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(carRecord.InqOriginalEpCd.Trim()));            // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(carRecord.InqOriginalSecCd));              // �⍇�������_�R�[�h
                key.Append(carRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT));    // �⍇���ԍ�

                // �������񓚏�����SCM�󒍌n�f�[�^�̊Ǘ��A���S���Y����A�s�s���ł��邽�߁A�܂߂Ȃ�
                // key.Append(carRecord.AcptAnOdrStatus.ToString(ACPT_AN_ODR_STATUS));     // �󒍃X�e�[�^�X
                // key.Append(FormatSalseSlipNum(carRecord.SalesSlipNum));                 // ����`�[�ԍ�
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^(�ԗ����)���R�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h</param>
        /// <returns></returns>
        public static string GetCarRecordKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h</param>
        /// <returns></returns>
        public static string GetDetailRecordKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(detailRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // �X�V�N����
                key.Append(detailRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // �X�V�����b�~���b
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // �⍇���s�ԍ�
                key.Append(detailRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // �⍇���s�ԍ��}��

                key.Append(detailRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // �⍇���E�������
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)���R�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)���R�[�h</param>
        /// <returns></returns>
        public static string GetAnswerRecordKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(answerRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // �X�V�N����
                key.Append(answerRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // �X�V�����b�~���b
                key.Append(answerRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // �⍇���s�ԍ�

                // �⍇���s�ԍ��}��
                key.Append(
                    System.Math.Abs(answerRecord.InqRowNumDerivedNo).ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT)
                );

                key.Append(answerRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // �⍇���E�������
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^���R�[�h�̊֘A�L�[���擾���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^���R�[�h</param>
        /// <returns>�⍇������ƃR�[�h + �⍇�������_�R�[�h + �⍇���ԍ�</returns>
        public static string GetRelationKey(ISCMOrderHeaderRecord headerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(headerRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(headerRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(headerRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(headerRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(headerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^���R�[�h�̊֘A�L�[���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h</param>
        /// <returns>�⍇������ƃR�[�h + �⍇�������_�R�[�h + �⍇���ԍ�</returns>
        public static string GetRelationKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM�󒍃f�[�^���R�[�h�̊֘A�L�[���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)���R�[�h</param>
        /// <returns>�⍇������ƃR�[�h + �⍇�������_�R�[�h + �⍇���ԍ�</returns>
        public static string GetRelationKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
            }
            return key.ToString();
        }

        /// <summary>
        /// �⍇���s�ԍ��܂ł̃L�[���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h</param>
        /// <returns></returns>
        public static string GetInqRowNumberKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(detailRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // �X�V�N����
                key.Append(detailRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // �X�V�����b�~���b
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // �⍇���s�ԍ�
            }
            return key.ToString();
        }

        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        /// <summary>
        /// �񓚍ς݊֘A�L�[���擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)���R�[�h</param>
        /// <returns></returns>
        public static string GetAnsweredRelationKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // �⍇���s�ԍ�
                key.Append(detailRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // �⍇���s�ԍ��}��
            }
            return key.ToString();
        }

        /// <summary>
        /// �񓚍ς݊֘A�L�[���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)���R�[�h</param>
        /// <returns></returns>
        public static string GetAnsweredRelationKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // �⍇������ƃR�[�h//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // �⍇�������_�R�[�h
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // �⍇�����ƃR�[�h
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // �⍇���拒�_�R�[�h
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // �⍇���ԍ�
                key.Append(answerRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // �⍇���s�ԍ�
                key.Append(answerRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // �⍇���s�ԍ��}��
            }
            return key.ToString();
        }
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

        #endregion // </�L�[>

        #region <�����t�R�[�h>

        /// <summary>��ƃR�[�h�̃t�H�[�}�b�g</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>���_�R�[�h�̃t�H�[�}�b�g</summary>
        private const string SECTION_CODE_FORMAT = "00";
        /// <summary>�⍇���ԍ��̃t�H�[�}�b�g</summary>
        private const string INQUIRY_NUMBER_FORMAT = ENTERPRISE_CODE_FORMAT;
        /// <summary>�X�V�N�����̃t�H�[�}�b�g</summary>
        private const string UPDATE_DATE_FORMAT = "yyyyMMdd";
        /// <summary>�X�V�����b�~���b�̃t�H�[�}�b�g</summary>
        private const string UPDATE_TIME_FORMAT = "000000000";
        /// <summary>�⍇���E������ʂ̃t�H�[�}�b�g</summary>
        private const string INQ_ORD_DIV_CD_FORMAT = "00";
        /// <summary>�⍇���s�ԍ��̃t�H�[�}�b�g</summary>
        private const string INQ_ROW_NUMBER_FORMAT = "00";
        /// <summary>�⍇���s�ԍ��}�Ԃ̃t�H�[�}�b�g</summary>
        private const string INQ_ROW_NUM_DERIVED_NO_FORMAT = "00";
        /// <summary>�󒍃X�e�[�^�X�̃t�H�[�}�b�g</summary>
        private const string ACPT_AN_ODR_STATUS = "00";
        /// <summary>����`�[�ԍ��̃t�H�[�}�b�g</summary>
        // 2011/02/09 >>>
        //private const string SALES_SLIP_NUM_FORMAT = "000000000";
        public const string SALES_SLIP_NUM_FORMAT = "000000000";
        // 2011/02/09 <<<
        /// <summary>�]�ƈ��R�[�h�̃t�H�[�}�b�g</summary>
        private const string EMPLOYEE_CODE_FORMAT = "000000000";

        /// <summary>
        /// ��ƃR�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ��16��</returns>
        public static string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// ���_�R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>sectionCodeNo.ToString("00") ��2��</returns>
        public static string FormatSectionCode(string sectionCode)
        {
            return FormatCode(sectionCode, SECTION_CODE_FORMAT);
        }

        /// <summary>
        /// ����`�[�ԍ��������t�ϊ����܂��B
        /// </summary>
        /// <param name="salseSlipNum">����`�[�ԍ�</param>
        /// <returns>sectionCodeNo.ToString("00") ��9��</returns>
        public static string FormatSalseSlipNum(string salseSlipNum)
        {
            return FormatCode(salseSlipNum, SALES_SLIP_NUM_FORMAT);
        }

        /// <summary>
        /// �]�ƈ��R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>employeeCode.ToString("000000000") ��9��</returns>
        public static string FormatEmployeeCode(string employeeCode)
        {
            return FormatCode(employeeCode, EMPLOYEE_CODE_FORMAT);
        }

        /// <summary>
        /// �����R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="code">�����R�[�h�l</param>
        /// <param name="format">����</param>
        /// <returns>codeNo.ToString(format)</returns>
        private static string FormatCode(
            string code,
            string format
        )
        {
            long codeNo = 0;
            if (!long.TryParse(code.Trim(), out codeNo))
            {
                codeNo = 0;
            }
            return codeNo.ToString(format);
        }

        #endregion // </�����t�R�[�h>

        /// <summary>
        /// ���l�ɕϊ����܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <returns>���l�ɕϊ��ł��Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</returns>
        public static int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary>
        /// �J�n���Y�N������t�^(DateTime�j�ɕϊ����܂��B
        /// </summary>
        /// <param name="modelPrtsAdptYm">�J�n���Y�N��(yyyyMM)</param>
        /// <returns>�J�n���Y�N��(DateTime)</returns>
        public static DateTime ConvertModelPrtsAdptYm(int modelPrtsAdptYm)
        {
            if (modelPrtsAdptYm == 0) return DateTime.MinValue;
            DateTime sdt;
            int iyy = modelPrtsAdptYm / 100;
            int imm = modelPrtsAdptYm % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            return sdt;
        }

        /// <summary>
        /// �I�����Y�N������t�^(DateTime�j�ɕϊ����܂��B
        /// </summary>
        /// <param name="modelPrtsAblsYm">�I�����Y�N��(yyyyMM)</param>
        /// <returns>�I�����Y�N��(DateTime)</returns>
        public static DateTime ConvertModelPrtsAblsYm(int modelPrtsAblsYm)
        {
            if (modelPrtsAblsYm == 0) return DateTime.MinValue;
            DateTime edt;
            int iyy = modelPrtsAblsYm / 100;
            int imm = modelPrtsAblsYm % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            return edt;
        }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

        #region <CSV�ϊ�>

        /// <summary>�J���}</summary>
        public const string COMMA = ",";

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmHeaderRecordList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<ISCMOrderHeaderRecord> scmHeaderRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (scmHeaderRecordList != null && scmHeaderRecordList.Count > 0)
                {
                    if (scmHeaderRecordList[0] is UserSCMOrderHeaderRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.���Ӑ�R�[�h").Append(COMMA);
                        csv.Append("15.�X�V�N����").Append(COMMA);
                        csv.Append("16.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("17.�񓚋敪").Append(COMMA);
                        csv.Append("18.�m���").Append(COMMA);
                        csv.Append("19.�⍇���E�������l").Append(COMMA);
                        csv.Append("20.�Y�t�t�@�C��").Append(COMMA);
                        csv.Append("21.�Y�t�t�@�C����").Append(COMMA);
                        csv.Append("22.�⍇���]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("23.�⍇���]�ƈ�����").Append(COMMA);
                        csv.Append("24.�񓚏]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("25.�񓚏]�ƈ�����").Append(COMMA);
                        csv.Append("26.�⍇����").Append(COMMA);
                        csv.Append("27.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("28.����`�[�ԍ�").Append(COMMA);
                        csv.Append("29.����`�[���v(�ō���)").Append(COMMA);
                        csv.Append("30.���㏬�v(��)").Append(COMMA);
                        csv.Append("31.�⍇���E�������").Append(COMMA);
                        csv.Append("32.�┭�E�񓚎��").Append(COMMA);
                        csv.Append("33.��M����").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("34.�񓚍쐬�敪").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("34.�񓚍쐬�敪").Append(COMMA);
                        csv.Append("35.�L�����Z���敪").Append(COMMA);
                        csv.Append("36.CMT�A�g�敪").Append(Environment.NewLine);
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("07.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("08.�⍇���ԍ�").Append(COMMA);
                        csv.Append("09.�X�V�N����").Append(COMMA);
                        csv.Append("10.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("11.�񓚋敪").Append(COMMA);
                        csv.Append("12.�m���").Append(COMMA);
                        csv.Append("13.�⍇���E�������l").Append(COMMA);
                        csv.Append("14.�⍇���]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("15.�⍇���]�ƈ�����").Append(COMMA);
                        csv.Append("16.�񓚏]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("17.�񓚏]�ƈ�����").Append(COMMA);
                        csv.Append("18.�⍇����").Append(COMMA);
                        csv.Append("19.�⍇���E�������").Append(COMMA);
                        csv.Append("20.�┭�E�񓚎��").Append(COMMA);
                        csv.Append("21.��M����").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("22.�ŐV���ʋ敪").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("22.�ŐV���ʋ敪").Append(COMMA);
                        csv.Append("23.�L�����Z���敪").Append(COMMA);
                        csv.Append("25.CMT�A�g�敪").Append(Environment.NewLine);
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderHeaderRecord scmHeaderRecord in scmHeaderRecordList)
                {
                    csv.Append(scmHeaderRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmCarRecordList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<ISCMOrderCarRecord> scmCarRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (scmCarRecordList != null && scmCarRecordList.Count > 0)
                {
                    if (scmCarRecordList[0] is UserSCMOrderCarRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇���ԍ�").Append(COMMA);
                        csv.Append("12.���^�������ԍ�").Append(COMMA);
                        csv.Append("13.���^�����ǖ���").Append(COMMA);
                        csv.Append("14.�ԗ��o�^�ԍ�(���)").Append(COMMA);
                        csv.Append("15.�ԗ��o�^�ԍ�(�J�i)").Append(COMMA);
                        csv.Append("16.�ԗ��o�^�ԍ�(�v���[�g�ԍ�)").Append(COMMA);
                        csv.Append("17.�^���w��ԍ�").Append(COMMA);
                        csv.Append("18.�ޕʔԍ�").Append(COMMA);
                        csv.Append("19.���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("20.�Ԏ�R�[�h").Append(COMMA);
                        csv.Append("21.�Ԏ�T�u�R�[�h").Append(COMMA);
                        csv.Append("22.�Ԏ햼").Append(COMMA);
                        csv.Append("23.�Ԍ��،^��").Append(COMMA);
                        csv.Append("24.�^��(�t���^)").Append(COMMA);
                        csv.Append("25.�ԑ�ԍ�").Append(COMMA);
                        csv.Append("26.�ԑ�^��").Append(COMMA);
                        csv.Append("27.�V���V�[No").Append(COMMA);
                        csv.Append("28.�ԗ��ŗL�ԍ�").Append(COMMA);
                        csv.Append("29.���Y�N��(NUM�^�C�v)").Append(COMMA);
                        csv.Append("30.�R�����g").Append(COMMA);
                        csv.Append("31.���y�A�J���[�R�[�h").Append(COMMA);
                        csv.Append("32.�J���[����1").Append(COMMA);
                        csv.Append("33.�g�����R�[�h").Append(COMMA);
                        csv.Append("34.�g��������").Append(COMMA);
                        csv.Append("35.�ԗ����s����").Append(COMMA);
                        csv.Append("36.�����I�u�W�F�N�g").Append(COMMA);
                        csv.Append("37.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("38.����`�[�ԍ�").Append(Environment.NewLine);

                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇���ԍ�").Append(COMMA);
                        csv.Append("07.���^�������ԍ�").Append(COMMA);
                        csv.Append("08.���^�����ǖ���").Append(COMMA);
                        csv.Append("09.�ԗ��o�^�ԍ�(���)").Append(COMMA);
                        csv.Append("10.�ԗ��o�^�ԍ�(�J�i)").Append(COMMA);
                        csv.Append("11.�ԗ��o�^�ԍ�(�v���[�g�ԍ�)").Append(COMMA);
                        csv.Append("12.�^���w��ԍ�").Append(COMMA);
                        csv.Append("13.�ޕʔԍ�").Append(COMMA);
                        csv.Append("14.���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("15.�Ԏ�R�[�h").Append(COMMA);
                        csv.Append("16.�Ԏ�T�u�R�[�h").Append(COMMA);
                        csv.Append("17.�Ԏ햼").Append(COMMA);
                        csv.Append("18.�Ԍ��،^��").Append(COMMA);
                        csv.Append("19.�^��(�t���^)").Append(COMMA);
                        csv.Append("20.�ԑ�ԍ�").Append(COMMA);
                        csv.Append("21.�ԑ�^��").Append(COMMA);
                        csv.Append("22.�V���V�[No").Append(COMMA);
                        csv.Append("23.�ԗ��ŗL�ԍ�").Append(COMMA);
                        csv.Append("24.���Y�N��(NUM�^�C�v)").Append(COMMA);
                        csv.Append("25.�R�����g").Append(COMMA);
                        csv.Append("26.���y�A�J���[�R�[�h").Append(COMMA);
                        csv.Append("27.�J���[����1").Append(COMMA);
                        csv.Append("28.�g�����R�[�h").Append(COMMA);
                        csv.Append("29.�g��������").Append(COMMA);
                        csv.Append("30.�ԗ����s����").Append(COMMA);
                        csv.Append("31.�����I�u�W�F�N�g").Append(Environment.NewLine);

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderCarRecord scmCarRecord in scmCarRecordList)
                {
                    csv.Append(scmCarRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmDetailRecordList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public static string ConvertCSV(IList<ISCMOrderDetailRecord> scmDetailRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (scmDetailRecordList != null && scmDetailRecordList.Count > 0)
                {
                    if (scmDetailRecordList[0] is UserSCMOrderDetailRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.�X�V�N����").Append(COMMA);
                        csv.Append("15.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("16.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("17.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("18.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("19.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("20.���i���").Append(COMMA);
                        csv.Append("21.���T�C�N�����i���").Append(COMMA);
                        csv.Append("22.���T�C�N�����i����").Append(COMMA);
                        csv.Append("23.�[�i�敪").Append(COMMA);
                        csv.Append("24.�戵�敪").Append(COMMA);
                        csv.Append("25.���i�`��").Append(COMMA);
                        csv.Append("26.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("27.�[�i�����\���").Append(COMMA);
                        csv.Append("28.�񓚔[��").Append(COMMA);
                        csv.Append("29.BL���i�R�[�h").Append(COMMA);
                        csv.Append("30.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("31.�┭���i��").Append(COMMA);
                        csv.Append("32.�񓚏��i��").Append(COMMA);
                        csv.Append("33.������").Append(COMMA);
                        csv.Append("34.�[�i��").Append(COMMA);
                        csv.Append("35.���i�ԍ�").Append(COMMA);
                        csv.Append("36.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("37.���i���[�J�[����").Append(COMMA);
                        csv.Append("38.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("39.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("40.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("41.�艿").Append(COMMA);
                        csv.Append("42.�P��").Append(COMMA);
                        csv.Append("43.���i�⑫���").Append(COMMA);
                        csv.Append("44.�e���z").Append(COMMA);
                        csv.Append("45.�e����").Append(COMMA);
                        csv.Append("46.�񓚊���").Append(COMMA);
                        csv.Append("47.���l(����)").Append(COMMA);
                        csv.Append("48.�Y�t�t�@�C��(����)").Append(COMMA);
                        csv.Append("49.�Y�t�t�@�C����(����)").Append(COMMA);
                        csv.Append("50.�I��").Append(COMMA);
                        csv.Append("51.�ǉ��敪").Append(COMMA);
                        csv.Append("52.�����敪").Append(COMMA);
                        csv.Append("53.�⍇���E�������").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("54.�\������").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("54.�\������").Append(COMMA);
                        csv.Append("55.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("56.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("57.����`�[�ԍ�").Append(COMMA);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("58.����s�ԍ�").Append(Environment.NewLine);
                        csv.Append("58.����s�ԍ�").Append(COMMA);
                        csv.Append("59.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("60.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("61.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("62.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("63.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("64.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("07.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("08.�⍇���ԍ�").Append(COMMA);
                        csv.Append("09.�X�V�N����").Append(COMMA);
                        csv.Append("10.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("11.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("12.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("13.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("14.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("15.���i���").Append(COMMA);
                        csv.Append("16.���T�C�N�����i���").Append(COMMA);
                        csv.Append("17.���T�C�N�����i����").Append(COMMA);
                        csv.Append("18.�[�i�敪").Append(COMMA);
                        csv.Append("19.�戵�敪").Append(COMMA);
                        csv.Append("20.���i�`��").Append(COMMA);
                        csv.Append("21.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("22.�[�i�����\���").Append(COMMA);
                        csv.Append("23.�񓚔[��").Append(COMMA);
                        csv.Append("24.BL���i�R�[�h").Append(COMMA);
                        csv.Append("25.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("26.�┭���i��").Append(COMMA);
                        csv.Append("27.�񓚏��i��").Append(COMMA);
                        csv.Append("28.������").Append(COMMA);
                        csv.Append("29.�[�i��").Append(COMMA);
                        csv.Append("30.���i�ԍ�").Append(COMMA);
                        csv.Append("31.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("32.���i���[�J�[����").Append(COMMA);
                        csv.Append("33.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("34.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("35.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("36.�艿").Append(COMMA);
                        csv.Append("37.�P��").Append(COMMA);
                        csv.Append("38.���i�⑫���").Append(COMMA);
                        csv.Append("39.�e���z").Append(COMMA);
                        csv.Append("40.�e����").Append(COMMA);
                        csv.Append("41.�񓚊���").Append(COMMA);
                        csv.Append("42.���l(����)").Append(COMMA);
                        csv.Append("43.�I��").Append(COMMA);
                        csv.Append("44.�ǉ��敪").Append(COMMA);
                        csv.Append("45.�����敪").Append(COMMA);
                        csv.Append("46.�⍇���E�������").Append(COMMA);
                        csv.Append("47.�\������").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("48.�ŐV���ʋ敪").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("48.�ŐV���ʋ敪").Append(COMMA);
                        csv.Append("49.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("50.PM�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("51.PM����`�[�ԍ�").Append(COMMA);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("52.PM����s�ԍ�").Append(Environment.NewLine);
                        csv.Append("52.PM����s�ԍ�").Append(COMMA);
                        csv.Append("53.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("54.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("55.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("56.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("57.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("58.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderDetailRecord scmDetailRecord in scmDetailRecordList)
                {
                    csv.Append(scmDetailRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmAnswerRecordList">SCM�󒍖��׃f�[�^(��)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public static string ConvertCSV(IList<ISCMOrderAnswerRecord> scmAnswerRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (scmAnswerRecordList != null && scmAnswerRecordList.Count > 0)
                {
                    if (scmAnswerRecordList[0] is ISCMOrderAnswerRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.�X�V�N����").Append(COMMA);
                        csv.Append("15.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("16.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("17.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("18.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("19.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("20.���i���").Append(COMMA);
                        csv.Append("21.���T�C�N�����i���").Append(COMMA);
                        csv.Append("22.���T�C�N�����i����").Append(COMMA);
                        csv.Append("23.�[�i�敪").Append(COMMA);
                        csv.Append("24.�戵�敪").Append(COMMA);
                        csv.Append("25.���i�`��").Append(COMMA);
                        csv.Append("26.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("27.�[�i�����\���").Append(COMMA);
                        csv.Append("28.�񓚔[��").Append(COMMA);
                        csv.Append("29.BL���i�R�[�h").Append(COMMA);
                        csv.Append("30.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("31.�┭���i��").Append(COMMA);
                        csv.Append("32.�񓚏��i��").Append(COMMA);
                        csv.Append("33.������").Append(COMMA);
                        csv.Append("34.�[�i��").Append(COMMA);
                        csv.Append("35.���i�ԍ�").Append(COMMA);
                        csv.Append("36.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("37.���i���[�J�[����").Append(COMMA);
                        csv.Append("38.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("39.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("40.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("41.�艿").Append(COMMA);
                        csv.Append("42.�P��").Append(COMMA);
                        csv.Append("43.���i�⑫���").Append(COMMA);
                        csv.Append("44.�e���z").Append(COMMA);
                        csv.Append("45.�e����").Append(COMMA);
                        csv.Append("46.�񓚊���").Append(COMMA);
                        csv.Append("47.���l(����)").Append(COMMA);
                        csv.Append("48.�Y�t�t�@�C��(����)").Append(COMMA);
                        csv.Append("49.�Y�t�t�@�C����(����)").Append(COMMA);
                        csv.Append("50.�I��").Append(COMMA);
                        csv.Append("51.�ǉ��敪").Append(COMMA);
                        csv.Append("52.�����敪").Append(COMMA);
                        csv.Append("53.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("54.����`�[�ԍ�").Append(COMMA);
                        csv.Append("55.����`�[�s�ԍ�").Append(COMMA);
                        csv.Append("56.�L�����y�[���R�[�h").Append(COMMA);
                        csv.Append("57.�݌ɋ敪").Append(COMMA);
                        csv.Append("58.�⍇���E�������").Append(COMMA);
                        csv.Append("59.�\������").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("60.���i�Ǘ��ԍ�").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("60.���i�Ǘ��ԍ�").Append(COMMA);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("61.�L�����Z����ԋ敪").Append(Environment.NewLine);
                        csv.Append("61.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("62.PM����s�ԍ�").Append(COMMA);
                        csv.Append("63.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("64.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("65.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("66.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("67.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("68.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("07.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("08.�⍇���ԍ�").Append(COMMA);
                        csv.Append("09.�X�V�N����").Append(COMMA);
                        csv.Append("10.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("11.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("12.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("13.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("14.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("15.���i���").Append(COMMA);
                        csv.Append("16.���T�C�N�����i���").Append(COMMA);
                        csv.Append("17.���T�C�N�����i����").Append(COMMA);
                        csv.Append("18.�[�i�敪").Append(COMMA);
                        csv.Append("19.�戵�敪").Append(COMMA);
                        csv.Append("20.���i�`��").Append(COMMA);
                        csv.Append("21.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("22.�[�i�����\���").Append(COMMA);
                        csv.Append("23.�񓚔[��").Append(COMMA);
                        csv.Append("24.BL���i�R�[�h").Append(COMMA);
                        csv.Append("25.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("26.�┭���i��").Append(COMMA);
                        csv.Append("27.�񓚏��i��").Append(COMMA);
                        csv.Append("28.������").Append(COMMA);
                        csv.Append("29.�[�i��").Append(COMMA);
                        csv.Append("30.���i�ԍ�").Append(COMMA);
                        csv.Append("31.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("32.���i���[�J�[����").Append(COMMA);
                        csv.Append("33.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("34.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("35.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("36.�艿").Append(COMMA);
                        csv.Append("37.�P��").Append(COMMA);
                        csv.Append("38.���i�⑫���").Append(COMMA);
                        csv.Append("39.�e���z").Append(COMMA);
                        csv.Append("40.�e����").Append(COMMA);
                        csv.Append("41.�񓚊���").Append(COMMA);
                        csv.Append("42.���l(����)").Append(COMMA);
                        csv.Append("43.�I��").Append(COMMA);
                        csv.Append("44.�ǉ��敪").Append(COMMA);
                        csv.Append("45.�����敪").Append(COMMA);
                        csv.Append("46.�⍇���E�������").Append(COMMA);
                        csv.Append("47.�\������").Append(COMMA);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        //csv.Append("48.�ŐV���ʋ敪").Append(Environment.NewLine);
                        // DEL 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ---------->>>>>
                        csv.Append("48.�ŐV���ʋ敪").Append(COMMA);
                        csv.Append("49.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("50.PM�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("51.PM����`�[�ԍ�").Append(COMMA);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("52.PM����s�ԍ�").Append(Environment.NewLine);
                        csv.Append("52.PM����s�ԍ�").Append(COMMA);
                        csv.Append("53.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("54.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("55.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("56.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("57.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("58.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 �e�[�u���̃��C�A�E�g�ύX ----------<<<<<

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderAnswerRecord scmAnswerRecord in scmAnswerRecordList)
                {
                    csv.Append(scmAnswerRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        #endregion // </CSV�ϊ�>
    }
}

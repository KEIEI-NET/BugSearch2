//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2009/10/05  �C�����e : MANTIS[14370] �d���擾���@�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/08/06  �C�����e : ����̃p�^�[���ŃG���[�ɂȂ�ׁA�L�[�̍쐬���@�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/08/08  �C�����e : uoeSalesOrderRowNo�����l�ł���uoeSalesOrderRowNo��������̏ꍇ
//                                  �G���[�ŗ���������s��̏C��
//----------------------------------------------------------------------------//

using System;
using System.Text;
using Broadleaf.Library.Text; // 2009/10/05 ADD

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ��M�e�L�X�g�i�d���v���d���̉����j�N���X
    /// </summary>
    public sealed class ReceivedText
    {
        /// <summary>�d�b�Ŕ��������Ƃ��̓d���⍇���ԍ�</summary>
        public const int SALES_ORDER_NO_BY_TELEPHONE = 0;

        #region <�d��/>

        /// <summary>�d���̃T�C�Y[Byte]</summary>
        public const int TELEGRAM_LENGTH = 256;

        /// <summary>�d��</summary>
        private readonly byte[] _telegram = new byte[TELEGRAM_LENGTH];
        /// <summary>
        /// �d�����擾���܂��B
        /// </summary>
        /// <value>�d��</value>
        private byte[] Telegram { get { return _telegram; } }

        #endregion  // <�d��/>

        #region <GUID/>

        /// <summary>���׃f�[�^�Ƃ̊֘A�ɗp����GUID</summary>
        private Guid _dtlRelationGuid;
        /// <summary>
        /// ���׃f�[�^�Ƃ̊֘A�ɗp����GUID�̃A�N�Z�T
        /// </summary>
        /// <value>���׃f�[�^�Ƃ̊֘A�ɗp����GUID</value>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        #endregion  // <GUID/>

        #region <��M�������ԁi�o�ד`�[����1�`�A�ԁj/>

        /// <summary>��M�������ԁi�o�ד`�[����1�`�A�ԁj</summary>
        /// <remarks>�d�b�����f�[�^�͖{���Ԃ��񓚓d���Ή��s�ƂȂ�܂��B</remarks>
        private int _innerIndex;
        /// <summary>
        /// ��M�������Ԃ̃A�N�Z�T
        /// </summary>
        public int InnerIndex
        {
            get { return _innerIndex; }
            set { _innerIndex = value; }
        }

        #endregion  // <��M�������ԁi�o�ד`�[����1�`�A�ԁj/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="telegram">�d��</param>
        /// <param name="beginIndex">�J�n�C���f�b�N�X</param>
        /// <param name="innerIndex">��M�������ԁi�o�ד`�[����1�`�A�ԁj</param>
        public ReceivedText(
            byte[] telegram,
            int beginIndex,
            int innerIndex
        )
        {
            Array.Copy(telegram, beginIndex, _telegram, 0, TELEGRAM_LENGTH);
            _innerIndex = innerIndex;
        }

        #endregion  // <Constructor/>

        #region <�d���w�b�_�[��/>

        #region <�d���敪/>

        /// <summary>
        /// �d���敪���擾���܂��B
        /// </summary>
        /// <remarks>1�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>�d���敪</value>
        public string TelegramDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 1;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�d���敪/>

        #region <�����敪/>

        /// <summary>
        /// �����敪���擾���܂��B
        /// </summary>
        /// <remarks>2�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>�����敪</value>
        public string ProcessDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 2;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�����敪/>

        #region <��������/>

        /// <summary>
        /// �������ʂ��擾���܂��B
        /// </summary>
        /// <remarks>3�o�C�g�ځi2[Byte]�j</remarks>
        /// <value>��������</value>
        public string ProcessResult
        {
            get
            {
                const int TELEGRAM_POSITION = 3;
                const int BYTE_LENGTH       = 2;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <��������/>

        #region <�d���⍇���ԍ�>

        /// <summary>
        /// �d���⍇���ԍ����擾���܂��B
        /// </summary>
        /// <remarks>5�o�C�g�ځi6[Byte]�j</remarks>
        /// <value>�d�b�⍇���ԍ�</value>
        public string UOESalesOrderNo
        {
            get
            {
                const int TELEGRAM_POSITION = 5;
                const int BYTE_LENGTH       = 6;
                const string TEL_ORDER_NO   = "000000";

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);

                string uoeSalesOrderNo = ConvertString(jisCodes);

                if (TStrConv.StrToIntDef(uoeSalesOrderNo.Trim(), 0) == 0) uoeSalesOrderNo = TEL_ORDER_NO; // 2009/10/05 ADD
                return string.IsNullOrEmpty(uoeSalesOrderNo.Trim()) ? TEL_ORDER_NO : uoeSalesOrderNo;
            }
        }

        #endregion  // <�d���⍇���ԍ�/>

        #region <�񓚓d���Ή��s/>

        /// <summary>
        /// �񓚓d���Ή��s���擾���܂��B
        /// </summary>
        /// <remarks>11�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>�񓚓d���Ή��s</value>
        public string UOESalesOrderRowNo
        {
            get
            {
                const int TELEGRAM_POSITION = 11;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);

                string uoeSalesOrderRowNo = ConvertString(jisCodes);

                if (int.Parse(UOESalesOrderNo).Equals(SALES_ORDER_NO_BY_TELEPHONE)) uoeSalesOrderRowNo = string.Empty; // 2009/10/05 ADD
                // add 2012/08/08 >>>
                try
                {
                    int tempUoeSalesOrderRowNo = Convert.ToInt32(uoeSalesOrderRowNo);
                }
                catch
                {
                    uoeSalesOrderRowNo = string.Empty;
                }
                // add 2012/08/08 <<<

                return string.IsNullOrEmpty(uoeSalesOrderRowNo.Trim()) ? InnerIndex.ToString() : uoeSalesOrderRowNo;
            }
        }

        #endregion  // <�񓚓d���Ή��s/>

        #region <���}�[�N/>

        /// <summary>
        /// ���}�[�N���擾���܂��B
        /// </summary>
        /// <remarks>12�o�C�g�ځi10[Byte]�j</remarks>
        /// <value>���}�[�N</value>
        public string UOERemark
        {
            get
            {
                const int TELEGRAM_POSITION = 12;
                const int BYTE_LENGTH       = 10;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <���}�[�N/>

        #region <�[�i�敪/>

        /// <summary>
        /// �[�i�敪���擾���܂��B
        /// </summary>
        /// <remarks>22�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>�[�i�敪</value>
        public string DeliveryGoodsDiv
        {
            get
            {
                const int TELEGRAM_POSITION = 22;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�[�i�敪/>

        #region <�w�苒�_/>

        /// <summary>
        /// �w�苒�_���擾���܂��B
        /// </summary>
        /// <remarks>23�o�C�g�ځi3[Byte]�j</remarks>
        /// <value>�w�苒�_</value>
        public string ReservedSection
        {
            get
            {
                const int TELEGRAM_POSITION = 23;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�w�苒�_/>

        #endregion  // <�d���w�b�_�[��/>

        #region <�d�����ו�/>

        #region <�󒍕��i�ԍ�/>

        /// <summary>
        /// �󒍕��i�ԍ����擾���܂��B
        /// </summary>
        /// <remarks>26�o�C�g�ځi20[Byte]�j</remarks>
        /// <value>�󒍕��i�ԍ�</value>
        public string AcceptPartsNo
        {
            get
            {
                const int TELEGRAM_POSITION = 26;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�󒍕��i�ԍ�/>

        #region <�o�ו��i�ԍ�/>

        /// <summary>
        /// �o�ו��i�ԍ����擾���܂��B
        /// </summary>
        /// <remarks>46�o�C�g�ځi20[Byte]�j</remarks>
        /// <value>�o�ו��i�ԍ�</value>
        public string AnswerPartsNo
        {
            get
            {
                const int TELEGRAM_POSITION = 46;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�o�ו��i�ԍ�/>

        #region <���[�J�[�R�[�h/>

        /// <summary>
        /// ���[�J�[�R�[�h���擾���܂��B
        /// </summary>
        /// <remarks>66�o�C�g�ځi4[Byte]�j</remarks>
        /// <value>���[�J�[�R�[�h</value>
        public string AnswerMakerCode
        {
            get
            {
                const int TELEGRAM_POSITION = 66;
                const int BYTE_LENGTH       = 4;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <���[�J�[�R�[�h/>

        #region <���ރR�[�h/>

        /// <summary>
        /// ���ރR�[�h���擾���܂��B
        /// </summary>
        /// <remarks>70�o�C�g�ځi4[Byte]�j</remarks>
        /// <value>���ރR�[�h</value>
        public string ClassifiedCode
        {
            get
            {
                const int TELEGRAM_POSITION = 70;
                const int BYTE_LENGTH       = 4;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <���ރR�[�h/>

        #region <�i��/>

        /// <summary>
        /// �i�����擾���܂��B
        /// </summary>
        /// <remarks>74�o�C�g�ځi20[Byte]�j</remarks>
        /// <value>�i��</value>
        public string AnswerPartsName
        {
            get
            {
                const int TELEGRAM_POSITION = 74;
                const int BYTE_LENGTH       = 20;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�i��/>

        #region <�艿/>

        /// <summary>
        /// �艿���擾���܂��B
        /// </summary>
        /// <remarks>94�o�C�g�ځi7[Byte]�j</remarks>
        /// <value>�艿</value>
        public string AnswerListPrice
        {
            get
            {
                const int TELEGRAM_POSITION = 94;
                const int BYTE_LENGTH       = 7;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�艿/>

        #region <�d�ؒP��/>

        /// <summary>
        /// �d�ؒP�����擾���܂��B
        /// </summary>
        /// <remarks>101�o�C�g�ځi7[Byte]�j</remarks>
        /// <value>�d�ؒP��</value>
        public string AnswerSalesUnitCost
        {
            get
            {
                const int TELEGRAM_POSITION = 101;
                const int BYTE_LENGTH       = 7;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�d�ؒP��/>

        #region <�󒍐�/>

        /// <summary>
        /// �󒍐����擾���܂��B
        /// </summary>
        /// <remarks>108�o�C�g�ځi3[Byte]�j</remarks>
        /// <value>�󒍐�</value>
        public string AcceptAnOrderCount
        {
            get
            {
                const int TELEGRAM_POSITION = 108;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�󒍐�/>

        #region <�o�א�/>

        /// <summary>
        /// �o�א����擾���܂��B
        /// </summary>
        /// <remarks>111�o�C�g�ځi3[Byte]�j</remarks>
        /// <value>�o�א�</value>
        public string UOESectOutGoodsCount
        {
            get
            {
                const int TELEGRAM_POSITION = 111;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�o�א�/>

        #region <B/O�敪/>

        /// <summary>
        /// B/O�敪���擾���܂��B
        /// </summary>
        /// <remarks>114�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>B/O�敪</value>
        public string BOCode
        {
            get
            {
                const int TELEGRAM_POSITION = 114;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O�敪/>

        #region <�\���R�[�h/>

        /// <summary>
        /// �\���R�[�h���擾���܂��B
        /// </summary>
        /// <remarks>115�o�C�g�ځi1[Byte]�j</remarks>
        /// <value>�\���R�[�h</value>
        public string UOEMarkCode
        {
            get
            {
                const int TELEGRAM_POSITION = 115;
                const int BYTE_LENGTH       = 1;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�\���R�[�h/>

        #region <B/O��/>

        /// <summary>
        /// B/O�����擾���܂��B
        /// </summary>
        /// <remarks>116�o�C�g�ځi3[Byte]�j</remarks>
        /// <value>B/O��</value>
        public string BOShipmentCount
        {
            get
            {
                const int TELEGRAM_POSITION = 116;
                const int BYTE_LENGTH       = 3;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O��/>

        #region <�o�ד`�[�ԍ�/>

        /// <summary>
        /// �o�ד`�[�ԍ����擾���܂��B
        /// </summary>
        /// <remarks>119�o�C�g�ځi6[Byte]�j</remarks>
        /// <value>�o�ד`�[�ԍ�</value>
        public string UOESectionSlipNo
        {
            get
            {
                const int TELEGRAM_POSITION = 119;
                const int BYTE_LENGTH       = 6;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�o�ד`�[�ԍ�/>

        #region <B/O�`�[�ԍ�/>

        /// <summary>
        /// B/O�`�[�ԍ����擾���܂��B
        /// </summary>
        /// <remarks>125�o�C�g�ځi6[Byte]�j</remarks>
        /// <value>B/O�`�[�ԍ�</value>
        public string BOSlipNo
        {
            get
            {
                const int TELEGRAM_POSITION = 125;
                const int BYTE_LENGTH       = 6;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <B/O�`�[�ԍ�/>

        #region <���C���G���[/>

        /// <summary>
        /// ���C���G���[���擾���܂��B
        /// </summary>
        /// <remarks>131�o�C�g�ځi15[Byte]�j</remarks>
        /// <value>���C���G���[</value>
        public string LineErrorMessage
        {
            get
            {
                const int TELEGRAM_POSITION = 131;
                const int BYTE_LENGTH       = 15;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <���C���G���[/>

        #region <�`�F�b�N�R�[�h/>

        /// <summary>
        /// ���C���G���[���擾���܂��B
        /// </summary>
        /// <remarks>146�o�C�g�ځi10[Byte]�j</remarks>
        /// <value>���C���G���[</value>
        public string UOECheckCode
        {
            get
            {
                const int TELEGRAM_POSITION = 146;
                const int BYTE_LENGTH       = 10;

                byte[] jisCodes = new byte[BYTE_LENGTH];
                Array.Copy(Telegram, TELEGRAM_POSITION - 1, jisCodes, 0, BYTE_LENGTH);
                return ConvertString(jisCodes);
            }
        }

        #endregion  // <�`�F�b�N�R�[�h/>

        #endregion  // <�d�����ו�/>

        /// <summary>�����I�ɓd�b�����Ƃ݂Ȃ��t���O</summary>
        /// <remarks>�I�����C�������̃f�[�^����������Ȃ������Ƃ���<c>true</c></remarks>
        private bool _isTelephoneOrderForced;
        /// <summary>
        /// �����I�ɓd�b�����Ƃ݂Ȃ��t���O�̃A�N�Z�T
        /// </summary>
        public bool IsTelephoneOrderForced
        {
            get { return _isTelephoneOrderForced; }
            set { _isTelephoneOrderForced = value; }
        }

        /// <summary>
        /// �d�b���������肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�d�b�����ł���<br/>
        /// <c>false</c>:�d�b�����ł͂Ȃ�
        /// </returns>
        public bool IsTelephoneOrder()
        {
            if (IsTelephoneOrderForced) return true;

            return int.Parse(UOESalesOrderNo).Equals(SALES_ORDER_NO_BY_TELEPHONE);
        }

        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�o�ד`�[�ԍ�("000000") + "-" + UOE�����`�[�ԍ��F�d���⍇���ԍ�("000000") + "-" + UOE�����s�ԍ��F�񓚓d���Ή��s("00")</returns>
        public string ToKey()
        {
            // upd 2012/08/06 >>>
            //return GetKey(this);
            return GetKey(this, InnerIndex);
            // upd 2012/08/06 <<<
        }

        /// <summary>
        /// �o�ד`�[�ԍ��ɕϊ����܂��B
        /// </summary>
        /// <returns>�o�ד`�[�ԍ�("000000")</returns>
        public string ToSlipNo()
        {
            return FormatUOESectionSlipNo(UOESectionSlipNo);
        }

        /// <summary>
        /// ���i�ԍ��ɕϊ����܂��B
        /// </summary>
        /// <returns>
        /// �o�ו��i�ԍ�
        /// �i�o�ו��i�ԍ�����܂��̓X�y�[�X�̏ꍇ�A�i����Ԃ��܂��j
        /// </returns>
        public string ToGoodsNo()
        {
            if (!string.IsNullOrEmpty(AnswerPartsNo.Trim()))
            {
                return AnswerPartsNo.Trim();
            }
            else
            {
                return this.AnswerPartsName.Trim();
            }
        }

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <param name="jisCodes">JIS�R�[�h�z��</param>
        /// <returns>������</returns>
        private static string ConvertString(byte[] jisCodes)
        {
            return Broadleaf.Library.Text.TStrConv.SJisToUnicode(jisCodes).Trim();
        }

        /// <summary>
        /// �t�H�[�}�b�g�����ꂽ�o�ד`�[�ԍ����擾���܂��B
        /// </summary>
        /// <param name="uoeSectionSlipNo">�o�ד`�[�ԍ�</param>
        /// <returns>�o�ד`�[�ԍ�("000000")</returns>
        public static string FormatUOESectionSlipNo(string uoeSectionSlipNo)
        {
            return uoeSectionSlipNo.Trim().PadLeft(6, '0');   
        }

        /// <summary>
        /// �L�[���擾���܂��B
        /// </summary>
        /// <param name="receivedText">��M�e�L�X�g</param>
        /// <param name="innnerIndex">��M�������ԁi�o�ד`�[����1�`�A�ԁj</param>
        /// <returns>�o�ד`�[�ԍ�("000000") + "-" + UOE�����`�[�ԍ��F�d���⍇���ԍ�("000000") + "-" + UOE�����s�ԍ��F�񓚓d���Ή��s("00")</returns>
        // upd 2012/08/06 >>>
        //public static string GetKey(ReceivedText receivedText)
        public static string GetKey(ReceivedText receivedText, int innnerIndex)
        // upd 2012/08/06 <<<
        {
            return GetKey(
                receivedText.UOESectionSlipNo.Trim(),
                int.Parse(receivedText.UOESalesOrderNo),
                // upd 2012/08/06 >>>
                //int.Parse(receivedText.UOESalesOrderRowNo)
                int.Parse(receivedText.UOESalesOrderRowNo),
                innnerIndex
                // upd 2012/08/06 <<<
            );
        }

        /// <summary>
        /// �L�[���擾���܂��B
        /// </summary>
        /// <param name="uoeSectionSlipNo">�o�ד`�[�ԍ�</param>
        /// <param name="uoeSalesOrderNo">UOE�����`�[�ԍ��i�d���⍇���ԍ��j</param>
        /// <param name="uoeSalesOrderRowNo">UOE�����s�ԍ��i�񓚓d���Ή��s�j</param>
        /// <returns>�o�ד`�[�ԍ�("000000") + "-" + UOE�����`�[�ԍ��F�d���⍇���ԍ�("000000") + "-" + UOE�����s�ԍ��F�񓚓d���Ή��s("00")</returns>
        public static string GetKey(
            string uoeSectionSlipNo,
            int uoeSalesOrderNo,
            // upd 2012/08/06 >>>
            //int uoeSalesOrderRowNo
            int uoeSalesOrderRowNo,
            int innerIndex
            // upd 2012/08/06 <<<
        )
        {
            const string SEPARATOR = "-";
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatUOESectionSlipNo(uoeSectionSlipNo));
                key.Append(SEPARATOR);
                key.Append(uoeSalesOrderNo.ToString("000000"));
                key.Append(SEPARATOR);
                key.Append(uoeSalesOrderRowNo.ToString("00"));
                // add 2012/08/06 >>>
                key.Append(SEPARATOR);
                key.Append(innerIndex.ToString());
                // add 2012/08/06 <<<
            }
            return  key.ToString();
        }

        #region <Override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("�d���敪�F").Append(TelegramDiv).Append(Environment.NewLine);
            str.Append("�����敪�F").Append(ProcessDiv).Append(Environment.NewLine);
            str.Append("�������ʁF").Append(ProcessResult).Append(Environment.NewLine);
            str.Append("�d���⍇���ԍ��F").Append(UOESalesOrderNo).Append(Environment.NewLine);
            str.Append("�񓚓d���Ή��s�F").Append(UOESalesOrderRowNo).Append(Environment.NewLine);
            str.Append("���}�[�N�F").Append(UOERemark).Append(Environment.NewLine);
            str.Append("�[�i�敪�F").Append(DeliveryGoodsDiv).Append(Environment.NewLine);
            str.Append("�w�苒�_�F").Append(ReservedSection).Append(Environment.NewLine);
            str.Append("�󒍕��i�ԍ��F").Append(AcceptPartsNo).Append(Environment.NewLine);
            str.Append("�o�ו��i�ԍ��F").Append(AnswerPartsNo).Append(Environment.NewLine);
            str.Append("���[�J�[�R�[�h�F").Append(AnswerMakerCode).Append(Environment.NewLine);
            str.Append("���ރR�[�h�F").Append(ClassifiedCode).Append(Environment.NewLine);
            str.Append("�i���F").Append(AnswerPartsName).Append(Environment.NewLine);
            str.Append("�艿�F").Append(AnswerListPrice).Append(Environment.NewLine);
            str.Append("�d�ؒP���F").Append(AnswerSalesUnitCost).Append(Environment.NewLine);
            str.Append("�󒍐��F").Append(AcceptAnOrderCount).Append(Environment.NewLine);
            str.Append("�o�א��F").Append(UOESectOutGoodsCount).Append(Environment.NewLine);
            str.Append("B/O�敪�F").Append(BOCode).Append(Environment.NewLine);
            str.Append("�\���R�[�h�F").Append(UOEMarkCode).Append(Environment.NewLine);
            str.Append("B/O���F").Append(BOShipmentCount).Append(Environment.NewLine);
            str.Append("�o�ד`�[�ԍ��F").Append(UOESectionSlipNo).Append(Environment.NewLine);
            str.Append("B/O�`�[�ԍ��F").Append(BOSlipNo).Append(Environment.NewLine);
            str.Append("���C���G���[�F").Append(LineErrorMessage).Append(Environment.NewLine);
            str.Append("�`�F�b�N�R�[�h�F").Append(UOECheckCode).Append(Environment.NewLine);

            return str.ToString();
        }

        #endregion  // <Override/>
    }
}

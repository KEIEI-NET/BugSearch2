//****************************************************************************//
// �V�X�e��         : ���M�O���X�g
// �v���O��������   : ���M�O���X�g�f�[�^�N���X
// �v���O�����T�v   : ���M�O���X�g�f�[�^�N���X���������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/11  �C�����e : MAHNB02013E�F�����m�F�\���Q�l�ɐV�K�쐬
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���M�O���X�g���o�����N���X
    /// </summary>
    /// <remarks>
    /// PMOUE02032E�ɔz�u���邪�A�z�Q�ƂɂȂ��Ă��܂����߁APMUOE02033A�ɈڐA
    /// </remarks>
    public sealed class SendBeforeOrderCondition : SendBeforOrderCndtnWork
    {
        #region <���[�w�b�_�[�̃^�C�g��/>

        /// <summary>�V�X�e���敪�̃^�C�g��</summary>
        public const string SYSTEM_DIV_CD_TITLE = "�V�X�e���敪";
        /// <summary>������̃^�C�g��</summary>
        public const string PRINT_ORDER_TITLE = "�����";
        /// <summary>�I�����C���ԍ��̃^�C�g��</summary>
        public const string ONLINE_NO_TITLE = "�����ԍ�";
        /// <summary>UOE������R�[�h�̃^�C�g��</summary>
        public const string UOE_SUPPLIER_CD_TITLE = "������";

        /// <summary>�쐬���̃t�H�[�}�b�g</summary>
        public const string PRINT_DATE_FORMAT = "yyyy/MM/dd";
        /// <summary>�쐬���Ԃ̃t�H�[�}�b�g</summary>
        public const string PRINT_TIME_FORMAT = "HH:mm";

        #endregion  // <���[�w�b�_�[�̃^�C�g��/>

        #region <�V�X�e���敪/>

        /// <summary>
        /// �V�X�e���敪�̗񋓑�
        /// </summary>
        public enum SystemDivCode : int
        {
            /// <summary>�����</summary>
            Manual = 0,
            /// <summary>�`��</summary>
            DenPatsu = 1,
            /// <summary>����</summary>
            Searching = 2,
            /// <summary>�ꊇ</summary>
            Lump = 3,
            /// <summary>��[</summary>
            Supplement = 4
        }

        /// <summary>
        /// �V�X�e���敪�̖��̂��擾���܂��B
        /// </summary>
        /// <value>�V�X�e���敪�̖���</value>
        public string SystemDivName
        {
            get
            {
                switch (SystemDivCd)
                {
                    case (int)SystemDivCode.Manual:
                        return "�����";    // LITERAL:
                    case (int)SystemDivCode.DenPatsu:
                        return "�`��";      // LITERAL:
                    case (int)SystemDivCode.Searching:
                        return "����";      // LITERAL:
                    case (int)SystemDivCode.Lump:
                        return "�ꊇ";      // LITERAL:
                    case (int)SystemDivCode.Supplement:
                        return "��[";      // LITERAL:
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion  // <�V�X�e���敪/>

        #region <�����/>

        /// <summary>
        /// ������̗񋓑�
        /// </summary>
        public enum PrintOrderType : int
        {
            /// <summary>�����ԍ���</summary>
            ByOnlineNo = 0,
            /// <summary>�������</summary>
            ByUOESupplierCode = 1
        }

        /// <summary>�����</summary>
        private PrintOrderType _printOrder;
        /// <summary>
        /// ������̃A�N�Z�T
        /// </summary>
        /// <value>�����</value>
        public PrintOrderType PrintOrder
        {
            get { return _printOrder; }
            set { _printOrder = value; }
        }

        /// <summary>
        /// ������̖��̂��擾���܂��B
        /// </summary>
        /// <value>������̖���</value>
        public string PrintOrderName
        {
            get
            {
                switch (PrintOrder)
                {
                    case PrintOrderType.ByOnlineNo:
                        return "�����ԍ���";
                    case PrintOrderType.ByUOESupplierCode:
                        return "�������";
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion  // <�����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SendBeforeOrderCondition() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���M�O���X�g���o�����i�����[�g�p�j�𐶐����܂��B
        /// </summary>
        /// <returns>���M�O���X�g���o�����i�����[�g�p�j</returns>
        public SendBeforOrderCndtnWork CreateSendBeforOrderCndtnWork()
        {
            SendBeforOrderCndtnWork copy = new SendBeforOrderCndtnWork();

            copy.EnterpriseCode = EnterpriseCode;
            copy.SystemDivCd = SystemDivCd;
            copy.St_OnlineNo = St_OnlineNo;
            copy.Ed_OnlineNo = Ed_OnlineNo;

            copy.SectionCodes = new string[SectionCodes.Length];
            Array.Copy(SectionCodes, copy.SectionCodes, SectionCodes.Length);
            
            copy.St_UOESupplierCd = St_UOESupplierCd;
            copy.Ed_UOESupplierCd = Ed_UOESupplierCd;

            return copy;
        }
    }
}

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

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    // �D�ǃ��[�J�[�p�̓d���ҏW�N���X
    using PrimeTelegramEditorType = UoeSndEdit1001Acs.TelegramEditOpenClose1001;

    /// <summary>
    /// �d����M�p���M�d�������N���X
    /// </summary>
    public sealed class SendingStockReceptionTelegramEssence
    {
        #region <�Ɩ��敪/>

        /// <summary>�Ɩ��敪</summary>
        private const int BUSINESS_CODE = 1;    // 1:����/2:���ς�/3:�݌Ɋm�F
        /// <summary>
        /// �Ɩ��敪���擾���܂��B�i�d����M�����ł͔���(=1)�Œ�j
        /// </summary>
        public int BusinessCode { get { return BUSINESS_CODE; } }

        /// <summary>
        /// �Ɩ����̂��擾���܂��B�i�d����M�����ł͔���(=1)�Œ�j
        /// </summary>
        /// <value>�Ɩ�����</value>
        public string BusinessName { get { return "����"; } }   // LITERAL:

        #endregion  // <�Ɩ��敪/>

        #region <�ʐM�A�Z���u��ID/>

        /// <summary>�ʐM�A�Z���u��ID</summary>
        private readonly string _commAssemblyId;
        /// <summary>
        /// �ʐM�A�Z���u��ID���擾���܂��B
        /// </summary>
        public string CommAssemblyId { get { return _commAssemblyId; } }

        #endregion  // <�ʐM�A�Z���u��ID/>

        #region <UOE������R�[�h/>

        /// <summary>UOE������R�[�h</summary>
        private readonly int _uoeSupplierCd;
        /// <summary>
        /// UOE������R�[�h���擾���܂��B
        /// </summary>
        /// <value>UOE������R�[�h</value>
        public int UOESupplierCd { get { return _uoeSupplierCd; } }

        #endregion  // <UOE������R�[�h/>

        #region <UOE�z�X�g�R�[�h/>

        /// <summary>UOE�z�X�g�R�[�h</summary>
        private readonly string _uoeHostCode;
        /// <summary>
        /// UOE�z�X�g�R�[�h���擾���܂��B
        /// </summary>
        public string UOEHostCode { get { return _uoeHostCode; } }

        #endregion  // <UOE�z�X�g�R�[�h/>

        #region <UOE�ڑ��p�X���[�h/>

        /// <summary>UOE�ڑ��p�X���[�h</summary>
        private readonly string _uoeConnectPassword;
        /// <summary>
        /// UOE�ڑ��p�X���[�h���擾���܂��B
        /// </summary>
        /// <value>UOE�ڑ��p�X���[�h</value>
        public string UOEConnectPassword { get { return _uoeConnectPassword; } }

        #endregion  // <UOE�ڑ��p�X���[�h/>

        #region <�Ǔd���̖����t���O/>

        /// <summary>�Ǔd���̖����t���O</summary>
        private readonly bool _disabledClosingTelegram;
        /// <summary>
        /// �Ǔd���̖����t���O���擾���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :�Ǔd���͐�������܂���B<br/>
        /// <c>false</c>:�Ǔd���͐�������܂��B
        /// </value>
        private bool DisabledClosingTelegram { get { return _disabledClosingTelegram; } }

        #endregion  // <�Ǔd���̖����t���O/>

        #region <UOE������C���X�^���X/>

        /// <summary>UOE������̃w���p</summary>
        private readonly UOESupplierHelper _uoeSupplierHelper;
        /// <summary>
        /// UOE������̃w���p���擾���܂��B
        /// </summary>
        /// <value>UOE������̃w���p</value>
        private UOESupplierHelper UOESupplierHelper { get { return _uoeSupplierHelper; } }

        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        public UOESupplier UOESupplier
        {
            get { return UOESupplierHelper.RealUOESupplier; }
        }

        #endregion  // <UOE������C���X�^���X/>

        /// <summary>���M�d���̃f�t�H���g�T�C�Y�i69[Byte]�j</summary>
        private const int SEND_TELEGRAM_DEFAULT_LENGTH = 69;        // TODO:�J��/�Ǔd���̃T�C�Y�i�Œ�j
        /// <summary>�d���v���d���̃T�C�Y�i256[Byte]�j</summary>
        private const int SEND_TELEGRAM_STOCK_REQUEST_LENGTH = 256; // TODO:�d���v���d���̃T�C�Y�i�Œ�j

        #region <UOE���M�ҏW���ʁi�w�b�_�[�j/>

        /// <summary>UOE���M�ҏW���ʁi�w�b�_�[�j</summary>
        private UoeSndHed _uoeSendHeader;
        /// <summary>
        /// UOE���M�ҏW���ʁi�w�b�_�[�j���擾���܂��B
        /// </summary>
        /// <remarks>
        /// ���M�����̑���M�������\�b�h�̍ė��p�Ŏg�p���܂��B
        /// </remarks>
        /// <value>UOE���M�ҏW���ʁi�w�b�_�[�j</value>
        public UoeSndHed UOESendHeader
        {
            get
            {
                if (_uoeSendHeader == null)
                {
                    _uoeSendHeader = CreateUoeSndHed();
                }
                return _uoeSendHeader;
            }
        }

        #endregion  // UOE���M�ҏW���ʁi�w�b�_�[�j

        #region <UOE���M�������/>

        /// <summary>UOE���M�������</summary>
        private UoeSndRcvCtlPara _uoeSendReceiveControlParameter;
        /// <summary>
        /// UOE���M����������擾���܂��B
        /// </summary>
        /// <remarks>
        /// ���M�����̎�M�ҏW�������\�b�h�̍ė��p�Ŏg�p���܂��B
        /// </remarks>
        /// <value>UOE���M�������</value>
        public UoeSndRcvCtlPara UOESendReceiveControlParameter
        {
            get
            {
                if (_uoeSendReceiveControlParameter == null)
                {
                    const int MANUAL_SYSTEM_DIV_CODE = 0;   // UOE�����f�[�^.�V�X�e���敪�i0:�����/1:�`��/2:����/3:�ꊇ/4:��[�j
                    const int NORMAL_PROCESS = 0;           // �����敪�i0:�ʏ�^1:�����j

                    _uoeSendReceiveControlParameter = new UoeSndRcvCtlPara(
                        UOESupplierHelper.EnterpriseProfile.Code,
                        BusinessCode,
                        MANUAL_SYSTEM_DIV_CODE,
                        NORMAL_PROCESS,
                        UOESupplierHelper.EnterpriseProfile.Name,
                        BusinessName
                    );
                }
                return _uoeSendReceiveControlParameter;
            }
        }

        #endregion  // <UOE���M�������/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeHostCode">UOE�z�X�g�R�[�h</param>
        /// <param name="uoeConnectPassword">UOE�ڑ��p�X���[�h</param>
        /// <param name="uoeSupplier">UOE������</param>
        public SendingStockReceptionTelegramEssence(
            string commAssemblyId,
            int uoeSupplierCd,
            string uoeHostCode,
            string uoeConnectPassword,
            UOESupplierHelper uoeSupplier
        ) : this(commAssemblyId, uoeSupplierCd, uoeHostCode, uoeConnectPassword, uoeSupplier, false)
        { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeHostCode">UOE�z�X�g�R�[�h</param>
        /// <param name="uoeConnectPassword">UOE�ڑ��p�X���[�h</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="disabledClosingTelegram">�Ǔd���̖����t���O</param>
        public SendingStockReceptionTelegramEssence(
            string commAssemblyId,
            int uoeSupplierCd,
            string uoeHostCode,
            string uoeConnectPassword,
            UOESupplierHelper uoeSupplier,
            bool disabledClosingTelegram
        )
        {
            _commAssemblyId         = commAssemblyId;
            _uoeSupplierCd          = uoeSupplierCd;
            _uoeHostCode            = uoeHostCode;
            _uoeConnectPassword     = uoeConnectPassword;
            _uoeSupplierHelper      = uoeSupplier;
            _disabledClosingTelegram= disabledClosingTelegram;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// UOE���M�ҏW���ʁi�w�b�_�[�j�𐶐����܂��B
        /// </summary>
        /// <returns>UOE���M�ҏW���ʁi�w�b�_�[�j</returns>
        private UoeSndHed CreateUoeSndHed()
        {
            UoeSndHed uoeSndHed = new UoeSndHed();

            uoeSndHed.BusinessCode  = BusinessCode;     // �Ɩ��敪
            uoeSndHed.CommAssemblyId= CommAssemblyId;   // �ʐM�A�Z���u��ID
            uoeSndHed.UOESupplierCd = UOESupplierCd;    // UOE������R�[�h

            // UOE���M�ҏW�i���ׁj�N���X
            uoeSndHed.UoeSndDtlList = new List<UoeSndDtl>();
            {
                // 1.�J�Ǔd��
                uoeSndHed.UoeSndDtlList.Add(CreateOpenUoeSndDtl());

                // 2.�d���v���d��
                uoeSndHed.UoeSndDtlList.Add(CreateStockRequestUoeSndDtl());

                // 3.�Ǔd��
                if (!DisabledClosingTelegram)
                {
                    uoeSndHed.UoeSndDtlList.Add(CreateCloseUoeSndDtl());
                }
            }

            return uoeSndHed;
        }

        #region <UOE���M�ҏW���ʁi���ׁj�̐���/>

        #region <�J�Ǔd��/�Ǔd��/>

        /// <summary>
        /// �J�Ǔd���i�Ǔd���j��UOE���M�ҏW���ʁi���ׁj�𐶐����܂��B
        /// </summary>
        /// <param name="openMode">
        /// �J�ǁF<c>EnumUoeConst.OpenMode.ct_OPEN</c><br/>
        /// �ǁF<c>EnumUoeConst.OpenMode.ct_CLOSE</c>
        /// </param>
        /// <returns>�J�Ǔd���i�Ǔd���j��UOE���M�ҏW���ʁi���ׁj</returns>
        private UoeSndDtl CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode openMode)
        {
            // �D�ǃ��[�J�[�p�̓d���ҏW�҂�ݒ�
            PrimeTelegramEditorType primeTelegramEditor = new PrimeTelegramEditorType();
            primeTelegramEditor.uOESupplier = UOESupplier;

            // UOE���M�ҏW���ʂ�ҏW
            UoeSndDtl uoeSndDtl = new UoeSndDtl();
            {
                // �����񓚔ԍ��c�J��/�ǂ̏ꍇ�A0
                uoeSndDtl.UOESalesOrderNo = 0;

                // �����񓚍s�ԍ��c�J��/�ǂ̏ꍇ�A�T�C�Y0
                uoeSndDtl.UOESalesOrderRowNo = new List<int>();

                // ���M�d��(JIS)�c�J��/�ǂ̏ꍇ�A�����敪�͎����(=1)
                uoeSndDtl.SndTelegram = primeTelegramEditor.Telegram(
                    (int)EnumUoeConst.ctSystemDivCd.ct_Input,
                    (int)openMode
                );

                // ���M�d���̃T�C�Y
                uoeSndDtl.SndTelegramLen = SEND_TELEGRAM_DEFAULT_LENGTH;
            }
            return uoeSndDtl;
        }

        #endregion  // <�J�Ǔd��/�Ǔd��/>

        /// <summary>
        /// �J�Ǔd����UOE���M�ҏW���ʁi���ׁj�𐶐����܂��B
        /// </summary>
        /// <returns>�J�Ǔd����UOE���M�ҏW���ʁi���ׁj</returns>
        private UoeSndDtl CreateOpenUoeSndDtl()
        {
            return CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode.ct_OPEN);
        }

        /// <summary>
        /// �d���v���d����UOE���M�ҏW���ʁi���ׁj�𐶐����܂��B
        /// </summary>
        /// <returns>�d���v���d����UOE���M�ҏW���ʁi���ׁj</returns>
        private UoeSndDtl CreateStockRequestUoeSndDtl()
        {
            // �D�ǃ��[�J�[�p�̓d���ҏW�҂�ݒ�
            PrimeTelegramEditorType primeTelegramEditor = new PrimeTelegramEditorType();
            primeTelegramEditor.uOESupplier = UOESupplier;

            // UOE���M�ҏW���ʂ�ҏW
            UoeSndDtl uoeSndDtl = new UoeSndDtl();
            {
                // �����񓚔ԍ�
                uoeSndDtl.UOESalesOrderNo = 1;

                // �����񓚍s�ԍ�
                uoeSndDtl.UOESalesOrderRowNo = new List<int>();
                uoeSndDtl.UOESalesOrderRowNo.Add(1);

                // ���M�d��(JIS)
                uoeSndDtl.SndTelegram = primeTelegramEditor.Telegram(UOESupplierHelper.ReceivingUOESupplierType);

                // ���M�d���̃T�C�Y
                uoeSndDtl.SndTelegramLen = SEND_TELEGRAM_STOCK_REQUEST_LENGTH;
            }
            return uoeSndDtl;
        }

        /// <summary>
        /// �Ǔd����UOE���M�ҏW���ʁi���ׁj�𐶐����܂��B
        /// </summary>
        /// <returns>�Ǔd����UOE���M�ҏW���ʁi���ׁj</returns>
        private UoeSndDtl CreateCloseUoeSndDtl()
        {
            UoeSndDtl uoeSndDtl = CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode.ct_CLOSE);
            {
                // TODO:�Ǔd���̔������i�摗�M�����̏ꍇ�ƒl���Ⴄ�H�j
                const int RESULT_INDEX_UPPER= 34;
                const int RESULT_INDEX_LOWER= 35;
                const int ORDER_DIV_INDEX   = 36;
                const byte JIS_CODE_OF_0 = 48;
                const byte JIS_CODE_OF_1 = 49;

                // ���ʁF"  "��"00"
                uoeSndDtl.SndTelegram[RESULT_INDEX_UPPER] = JIS_CODE_OF_0;
                uoeSndDtl.SndTelegram[RESULT_INDEX_LOWER] = JIS_CODE_OF_0;

                // �����敪�F" "��"1"
                uoeSndDtl.SndTelegram[ORDER_DIV_INDEX] = JIS_CODE_OF_1;
            }
            return uoeSndDtl;
        }

        #endregion  // <UOE���M�ҏW���ʁi���ׁj�̐���/>

        #region <�f�o�b�O�p/>

        /// <summary>
        /// UOE���M�ҏW���ʁi�w�b�_�[�j�𕶎���ɕϊ����܂��B
        /// </summary>
        /// <param name="uoeSndHed">UOE���M�ҏW���ʁi�w�b�_�[�j</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>������</returns>
        public static string ConvertString(
            UoeSndHed uoeSndHed,
            UOESupplierHelper uoeSupplier
        )
        {
            StringBuilder str = new StringBuilder();

            str.Append("�Ɩ��敪�F").Append(uoeSndHed.BusinessCode).Append(Environment.NewLine);
            str.Append("�ʐM�A�Z���u��ID�F").Append(uoeSndHed.CommAssemblyId).Append(Environment.NewLine);
            str.Append("UOE�����R�[�h�F").Append(uoeSndHed.UOESupplierCd).Append(Environment.NewLine);
            str.Append("UOE���M�ҏW(����)�F").Append(uoeSndHed.UoeSndDtlList.Count).Append(" ��" + Environment.NewLine);
            for (int i = 0; i < uoeSndHed.UoeSndDtlList.Count; i++)
            {
                str.Append("�d��[").Append(i).Append("]" + Environment.NewLine);

                UoeSndDtl uoeSndDtl = uoeSndHed.UoeSndDtlList[i];
                {
                    str.Append("�����񓚔ԍ��F").Append(uoeSndDtl.UOESalesOrderNo).Append(Environment.NewLine);
                    str.Append("�����񓚍s�ԍ��F").Append(uoeSndDtl.UOESalesOrderRowNo).Append(Environment.NewLine);

                    //for (int j = 0; j < uoeSndDtl.SndTelegram.Length; j++)
                    //{
                    //    str.Append("���M�d��(JIS)[").Append(j).Append("] = ").Append(uoeSndDtl.SndTelegram[j]).Append(";").Append(Environment.NewLine);
                    //}

                    str.Append("[���M�d��(JIS)]").Append(Environment.NewLine);
                    SendingText sendingText = new SendingText(uoeSndDtl.SndTelegram);
                    str.Append(sendingText.ToString());
                }

                str.Append(Environment.NewLine);
            }

            if (uoeSupplier == null) return str.ToString();

            // [�ǉ����]�FUOE������
            str.Append("[�ǉ����]�FUOE������").Append(Environment.NewLine);
            str.Append("�d�b�ԍ��F").Append(uoeSupplier.RealUOESupplier.TelNo).Append(Environment.NewLine);

            return str.ToString();
        }

        /// <summary>
        /// UOE���M�ҏW���ʁi�w�b�_�[�j�𕶎���ɕϊ����܂��B
        /// </summary>
        /// <param name="uoeRecHed">UOE���M�ҏW���ʁi�w�b�_�[�j</param>
        /// <returns>������</returns>
        public static string ConvertString(UoeRecHed uoeRecHed)
        {
            StringBuilder str = new StringBuilder();

            str.Append("�Ɩ��敪�F").Append(uoeRecHed.BusinessCode).Append(Environment.NewLine);
            str.Append("�ʐM�A�Z���u��ID").Append(uoeRecHed.CommAssemblyId).Append(Environment.NewLine);
            str.Append("UOE������R�[�h�F").Append(uoeRecHed.UOESupplierCd).Append(Environment.NewLine);
            str.Append("UOE��M����(����)�F").Append(uoeRecHed.UoeRecDtlList.Count).Append(" ��" + Environment.NewLine);
            for (int i = 0; i < uoeRecHed.UoeRecDtlList.Count; i++)
            {
                str.Append("�d��[").Append(i).Append("]" + Environment.NewLine);

                UoeRecDtl uoeRecDtl = uoeRecHed.UoeRecDtlList[i];
                {
                    str.Append("�����񓚔ԍ��F").Append(uoeRecDtl.UOESalesOrderNo).Append(Environment.NewLine);
                    str.Append("�����񓚍s�ԍ��F").Append(uoeRecDtl.UOESalesOrderRowNo).Append(Environment.NewLine);

                    for (int j = 0; j < uoeRecDtl.RecTelegram.Length; j++)
                    {
                        str.Append("��M�d��(JIS)[").Append(j).Append("] = ").Append(uoeRecDtl.RecTelegram[j]).Append(";").Append(Environment.NewLine);
                    }
                    if (uoeRecDtl.RecTelegram.Length <= 0) str.Append("��M�d��(JIS)�F�Ȃ�").Append(Environment.NewLine);

                    str.Append("�f�[�^���M�敪�F").Append(uoeRecDtl.DataSendCode).Append(Environment.NewLine);
                    str.Append("�f�[�^�����敪�F").Append(uoeRecDtl.DataRecoverDiv).Append(Environment.NewLine);
                }

                str.Append(Environment.NewLine);
            }

            // HACK:�ꎞ�A����
            //int index = 0;
            //ReceivedTextAgreegate agreegate = new ReceivedTextAgreegate(uoeRecHed);
            //IIterator<ReceivedText> iter = agreegate.CreateIterator();
            //while (iter.HasNext())
            //{
            //    index++;
            //    ReceivedText text = iter.GetNext();

            //    str.Append("��M�e�L�X�g[").Append(index).Append("]").Append(Environment.NewLine);
            //    str.Append(text.ToString()).Append(Environment.NewLine);
            //}

            return str.ToString();
        }

        #endregion  // <�f�o�b�O�p/>
    }
}

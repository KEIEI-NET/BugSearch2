//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�}�X�^
// �v���O�����T�v   �F���Ӑ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/04/23     �C�����e�FPartsman�p�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009/02/03     �C�����e�F��QID:9391�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y12493�z�̎����o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/03     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30531 ��� �r��
// �C����    2009/01/04     �C�����e�FMANTIS�y14873�z�������^�C�v���o�͋敪�ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H�� �b�D
// �C����    2010/06/26     �C�����e�FSCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30517 �Ė� �x��
// �C����    2010/07/06     �C�����e�FQR�R�[�h�g�у��[���Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fcaowj
// �C����    2010/08/10     �C�����e�F��Q���ǑΉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2011/06/09     �C�����e�F���̕ύX�Ή�[SCM��PCC]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10970681-00    �쐬�S���F��
// �C����    K2014/02/06    �C�����e�F�O�����a����� ���Ӑ�}�X�^���ǑΉ�
// ------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00    �쐬�S���F���J�M�m
// �C����    2021/05/10     �C�����e�F���Ӑ���K�C�h�\��PKG�Ή�
// ------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerInfo
	/// <summary>
	///                      ���Ӑ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/18</br>
	/// <br>Genarated Date   :   2008/04/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerInfo
	{
        // --- DEL 2010/08/10 ------------------------------------>>>>>
        //# region public static readonly string�i�蓮�ǉ��j
        ///// <summary>�l</summary>
        //public static readonly string CST_HonorificTitle_0 = "�l";
        ///// <summary>�a</summary>
        //public static readonly string CST_HonorificTitle_1 = "�a";
        ///// <summary>�䒆</summary>
        //public static readonly string CST_HonorificTitle_2 = "�䒆";

        ///// <summary>���Ӑ於�̂P,�Q���g�p����</summary>
        //public static readonly string CST_OutputName_0 = "���Ӑ於�̂P�E�Q";
        ///// <summary>���Ӑ於�̂P���g�p����</summary>
        //public static readonly string CST_OutputName_1 = "���Ӑ於�̂P";
        ///// <summary>���Ӑ於�̂Q���g�p����</summary>
        //public static readonly string CST_OutputName_2 = "���Ӑ於�̂Q";
        ///// <summary>�������̂��g�p����</summary>
        //public static readonly string CST_OutputName_3 = "��������";

        ///// <summary>����</summary>
        //public static readonly string CST_CollectMoneyName_0 = "����";
        ///// <summary>����</summary>
        //public static readonly string CST_CollectMoneyName_1 = "����";
        ///// <summary>���X��</summary>
        //public static readonly string CST_CollectMoneyName_2 = "���X��";
        ///// <summary>���X�X��</summary>
        //public static readonly string CST_CollectMoneyName_3 = "���X�X��";

        ///// <summary>�l</summary>
        //public static readonly string CST_CorporateDivName_0 = "�l";
        ///// <summary>�@�l</summary>
        //public static readonly string CST_CorporateDivName_1 = "�@�l";
        ///// <summary>����@�l</summary>
        //public static readonly string CST_CorporateDivName_2 = "����@�l";
        ///// <summary>�Ǝ�</summary>
        //public static readonly string CST_CorporateDivName_3 = "�Ǝ�";
        ///// <summary>�Ј�</summary>
        //public static readonly string CST_CorporateDivName_4 = "�Ј�";

        ///// <summary>����</summary>
        //public static readonly string CST_BillOutputName_0 = "����";
        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_BillOutputName_1 = "���Ȃ�";

        ///// <summary>����</summary>
        //public static readonly string CST_DmOutName_0 = "����";
        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_DmOutName_1 = "���Ȃ�";

        ///// <summary>���M���Ȃ�</summary>
        //public static readonly string CST_MailSendName_0 = "���M���Ȃ�";
        ///// <summary>���M����</summary>
        //public static readonly string CST_MailSendName_1 = "���M����";

        ///// <summary>����</summary>
        //public static readonly string CST_MailAddrKindName_0 = "����";
        ///// <summary>���</summary>
        //public static readonly string CST_MailAddrKindName_1 = "���";
        ///// <summary>�g�ђ[��</summary>
        //public static readonly string CST_MailAddrKindName_2 = "�g�ђ[��";
        ///// <summary>�{�l�ȊO</summary>
        //public static readonly string CST_MailAddrKindName_3 = "�{�l�ȊO";
        ///// <summary>���̑�</summary>
        //public static readonly string CST_MailAddrKindName_99 = "���̑�";

        ///// <summary>�`�[�P��</summary>
        //public static readonly string CST_ConsTaxLayMethod_0 = "�`�[�]��";
        ///// <summary>���גP��</summary>
        //public static readonly string CST_ConsTaxLayMethod_1 = "���ד]��";
        ///// <summary>�����e</summary>
        //public static readonly string CST_ConsTaxLayMethod_2 = "�����e";
        ///// <summary>�����q</summary>
        //public static readonly string CST_ConsTaxLayMethod_3 = "�����q";
        ///// <summary>��ې�</summary>
        //public static readonly string CST_ConsTaxLayMethod_9 = "��ې�";

        ///// <summary>���z�\�����Ȃ��i�Ŕ����j</summary>
        //public static readonly string CST_TotalAmountDispWayCd_0 = "���Ȃ�(�Ŕ�)";
        ///// <summary>���z�\������i�ō��݁j</summary>
        //public static readonly string CST_TotalAmountDispWayCd_1 = "����(�ō�)";

        ///// <summary>�S�̐ݒ���Q�Ƃ���</summary>
        //public static readonly string CST_TotalAmntDspWayRef_0 = "�S�̐ݒ�Q��";
        ///// <summary>���Ӑ�ݒ���Q�Ƃ���</summary>
        //public static readonly string CST_TotalAmntDspWayRef_1 = "���Ӑ�Q��";

        ///// <summary>0:�ŗ��ݒ�}�X�^���Q��</summary>
        //public static readonly string CST_CustCTaXLayRefCd_0 = "�ŗ��ݒ�Q��";
        ///// <summary>1:���Ӑ�}�X�^���Q��</summary>
        //public static readonly string CST_CustCTaXLayRefCd_1 = "���Ӑ�Q��";

        ///// <summary>���������</summary>
        //public static readonly string CST_CustomerAttributeDiv_0 = "���������";
        ///// <summary>�Г������</summary>
        //public static readonly string CST_CustomerAttributeDiv_8 = "�Г������";
        ///// <summary>��������</summary>
        //public static readonly string CST_CustomerAttributeDiv_9 = "��������";

        ///// <summary>���Ӑ�</summary>
        //public static readonly string CST_CustomerDivCd_0 = "���Ӑ�";
        ///// <summary>�[����</summary>
        //public static readonly string CST_CustomerDivCd_1 = "�[����";

        ///// <summary>����</summary>
        //public static readonly string CST_CollectCond_10 = "����";
        ///// <summary>�U��</summary>
        //public static readonly string CST_CollectCond_20 = "�U��";
        ///// <summary>���؎�</summary>
        //public static readonly string CST_CollectCond_30 = "���؎�";
        ///// <summary>��`</summary>
        //public static readonly string CST_CollectCond_40 = "��`";
        ///// <summary>�萔���u</summary>
        //public static readonly string CST_CollectCond_50 = "�萔��";
        ///// <summary>���E</summary>
        //public static readonly string CST_CollectCond_60 = "���E";
        ///// <summary>�l��</summary>
        //public static readonly string CST_CollectCond_70 = "�l��";
        ///// <summary>���̑�</summary>
        //public static readonly string CST_CollectCond_80 = "���̑�";

        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_CreditMngCode_0 = "���Ȃ�";
        ///// <summary>����</summary>
        //public static readonly string CST_CreditMngCode_1 = "����";

        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_DepoDelCode_0 = "���Ȃ�";
        ///// <summary>����</summary>
        //public static readonly string CST_DepoDelCode_1 = "����";

        ///// <summary>���|�Ȃ�</summary>
        //public static readonly string CST_AccRecDivCd_0 = "���|�Ȃ�";
        ///// <summary>���|</summary>
        //public static readonly string CST_AccRecDivCd_1 = "���|";

        ///// <summary>����</summary>
        //public static readonly string CST_EraNameCode_0 = "����";
        ///// <summary>�a��</summary>
        //public static readonly string CST_EraNameCode_1 = "�a��";

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
        /////// <summary>���Ȃ�</summary>
        ////public static readonly string CST_CustSlipNoMngCd_0 = "���Ȃ�";
        /////// <summary>����</summary>
        ////public static readonly string CST_CustSlipNoMngCd_1 = "����";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
        ///// <summary>�S�̐ݒ�Q��</summary>
        //public static readonly string CST_CustSlipNoMngCd_0 = "�S�̐ݒ�Q��";
        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_CustSlipNoMngCd_1 = "���Ȃ�";
        ///// <summary>����</summary>
        //public static readonly string CST_CustSlipNoMngCd_2 = "����";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        /////// <summary>����</summary>
        ////public static readonly string CST_PureCode_0 = "����";
        /////// <summary>���̑�</summary>
        ////public static readonly string CST_PureCode_1 = "���̑�";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
        /////// <summary>�g�p���Ȃ�</summary>
        ////public static readonly string CST_CustomerSlipNoDiv_0 = "�g�p���Ȃ�";
        /////// <summary>�g�p����</summary>
        ////public static readonly string CST_CustomerSlipNoDiv_1 = "�g�p����";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
        ///// <summary>�g�p���Ȃ�</summary>
        //public static readonly string CST_CustomerSlipNoDiv_0 = "�g�p���Ȃ�";
        ///// <summary>�A��</summary>
        //public static readonly string CST_CustomerSlipNoDiv_1 = "�A��";
        ///// <summary>����</summary>
        //public static readonly string CST_CustomerSlipNoDiv_2 = "����";
        ///// <summary>����</summary>
        //public static readonly string CST_CustomerSlipNoDiv_3 = "����";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/04/28 ADD
        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_CarMngDivCd_0 = "���Ȃ�";
        ///// <summary>�o�^(�m�F)</summary>
        //public static readonly string CST_CarMngDivCd_1 = "�o�^(�m�F)";
        ///// <summary>�o�^(����)</summary>
        //public static readonly string CST_CarMngDivCd_2 = "�o�^(����)";
        ///// <summary>�o�^��</summary>
        //public static readonly string CST_CarMngDivCd_3 = "�o�^��";

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 DEL
        /////// <summary>���Ȃ�</summary>
        ////public static readonly string CST_QrcodePrtCd_0 = "���Ȃ�";
        /////// <summary>����</summary>
        ////public static readonly string CST_QrcodePrtCd_1 = "����";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
        ///// <summary>�W��</summary>
        //public static readonly string CST_QrcodePrtCd_0 = "�W��";
        ///// <summary>�󎚂��Ȃ�</summary>
        //public static readonly string CST_QrcodePrtCd_1 = "�󎚂��Ȃ�";
        ///// <summary>�󎚂���</summary>
        //public static readonly string CST_QrcodePrtCd_2 = "�󎚂���";
        ///// <summary>�ԕi�܂�</summary>
        //public static readonly string CST_QrcodePrtCd_3 = "�ԕi�܂�";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/04/28 ADD
        //// 2010/07/06 Add >>>
        ///// <summary>�󎚂���i�g�у��[���j</summary>
        //public static readonly string CST_QrcodePrtCd_4 = "�󎚂���i�g�у��[���j";
        ///// <summary>�ԕi�܂ށi�g�у��[���j</summary>
        //public static readonly string CST_QrcodePrtCd_5 = "�ԕi�܂ށi�g�у��[���j";
        //// 2010/07/06 Add <<<

        //// --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------>>>>>
        ///// <summary>�W��</summary>
        //public static readonly string CST_PrtDiv_0 = "�W��";
        ///// <summary>���g�p</summary>
        //public static readonly string CST_PrtDiv_1 = "���g�p";
        ///// <summary>�g�p</summary>
        //public static readonly string CST_PrtDiv_2 = "�g�p";
        //// --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------<<<<<

        //// ADD 2009/04/07 ------>>>
        ///// <summary>����</summary>
        //public static readonly string CST_ReceiptOutputCode_0 = "����";
        ///// <summary>���Ȃ�</summary>
        //public static readonly string CST_ReceiptOutputCode_1 = "���Ȃ�";
        //// ADD 2009/04/07 ------<<<

        //// ADD 2009/06/03 ------>>>
        ///// <summary>�Ȃ�</summary>
        //public static readonly string CST_OnlineKindDiv_0 = "�Ȃ�";
        ///// <summary>SCM</summary>
        //public static readonly string CST_OnlineKindDiv_10 = "SCM";
        ///// <summary>TSP.NS</summary>
        //public static readonly string CST_OnlineKindDiv_20 = "TSP.NS";
        ///// <summary>TSP.NS�C�����C��</summary>
        //public static readonly string CST_OnlineKindDiv_30 = "TSP.NS�C�����C��";
        ///// <summary>TSP���[��</summary>
        //public static readonly string CST_OnlineKindDiv_40 = "TSP���[��";
        //// ADD 2009/06/03 ------<<<
        //// --- ADD  ���r��  2010/01/04 ---------->>>>>
        ///// <summary>�W��</summary>
        //public static readonly string CST_TotalBillOutputDiv_0 = "�W��";
        ///// <summary>�g�p</summary>
        //public static readonly string CST_TotalBillOutputDiv_1 = "�g�p";
        ///// <summary>���g�p</summary>
        //public static readonly string CST_TotalBillOutputDiv_2 = "���g�p";

        ///// <summary>�W��</summary>
        //public static readonly string CST_DetailBillOutputCode_0 = "�W��";
        ///// <summary>�g�p</summary>
        //public static readonly string CST_DetailBillOutputCode_1 = "�g�p";
        ///// <summary>���g�p</summary>
        //public static readonly string CST_DetailBillOutputCode_2 = "���g�p";

        ///// <summary>�W��</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_0 = "�W��";
        ///// <summary>�g�p</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_1 = "�g�p";
        ///// <summary>���g�p</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_2 = "���g�p";
        //// --- ADD  ���r��  2010/01/04 ----------<<<<<

        //# endregion
        // --- DEL 2010/08/10 ------------------------------------<<<<<

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        # region public static readonly string�i�蓮�ǉ��j
        /// <summary>�l</summary>
        public static readonly string CST_HonorificTitle_0 = "�l";
        /// <summary>�a</summary>
        public static readonly string CST_HonorificTitle_1 = "�a";
        /// <summary>�䒆</summary>
        public static readonly string CST_HonorificTitle_2 = "�䒆";
        /// <summary>���Ӑ於�̂P,�Q���g�p����</summary>
        public static readonly string CST_OutputName_0 = "0:���Ӑ於�̂P�E�Q";
        /// <summary>���Ӑ於�̂P���g�p����</summary>
        public static readonly string CST_OutputName_1 = "1:���Ӑ於�̂P";
        /// <summary>���Ӑ於�̂Q���g�p����</summary>
        public static readonly string CST_OutputName_2 = "2:���Ӑ於�̂Q";
        /// <summary>�������̂��g�p����</summary>
        public static readonly string CST_OutputName_3 = "3:��������";
        /// <summary>����</summary>
        public static readonly string CST_CollectMoneyName_0 = "0:����";
        /// <summary>����</summary>
        public static readonly string CST_CollectMoneyName_1 = "1:����";
        /// <summary>���X��</summary>
        public static readonly string CST_CollectMoneyName_2 = "2:���X��";
        /// <summary>���X�X��</summary>
        public static readonly string CST_CollectMoneyName_3 = "3:���X�X��";
        /// <summary>�l</summary>
        public static readonly string CST_CorporateDivName_0 = "0:�l";
        /// <summary>�@�l</summary>
        public static readonly string CST_CorporateDivName_1 = "1:�@�l";
        /// <summary>����@�l</summary>
        public static readonly string CST_CorporateDivName_2 = "2:����@�l";
        /// <summary>�Ǝ�</summary>
        public static readonly string CST_CorporateDivName_3 = "3:�Ǝ�";
        /// <summary>�Ј�</summary>
        public static readonly string CST_CorporateDivName_4 = "4:�Ј�";
        /// <summary>����</summary>
        public static readonly string CST_BillOutputName_0 = "0:����";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_BillOutputName_1 = "1:���Ȃ�";
        /// <summary>����</summary>
        public static readonly string CST_DmOutName_0 = "����";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_DmOutName_1 = "���Ȃ�";
        /// <summary>���M���Ȃ�</summary>
        public static readonly string CST_MailSendName_0 = "0:���M���Ȃ�";
        /// <summary>���M����</summary>
        public static readonly string CST_MailSendName_1 = "1:���M����";
        /// <summary>����</summary>
        public static readonly string CST_MailAddrKindName_0 = "0:����";
        /// <summary>���</summary>
        public static readonly string CST_MailAddrKindName_1 = "1:���";
        /// <summary>�g�ђ[��</summary>
        public static readonly string CST_MailAddrKindName_2 = "2:�g�ђ[��";
        /// <summary>�{�l�ȊO</summary>
        public static readonly string CST_MailAddrKindName_3 = "3:�{�l�ȊO";
        /// <summary>���̑�</summary>
        public static readonly string CST_MailAddrKindName_99 = "4:���̑�";
        /// <summary>�`�[�P��</summary>
        public static readonly string CST_ConsTaxLayMethod_0 = "0:�`�[�]��";
        /// <summary>���גP��</summary>
        public static readonly string CST_ConsTaxLayMethod_1 = "1:���ד]��";
        /// <summary>�����e</summary>
        public static readonly string CST_ConsTaxLayMethod_2 = "2:�����e";
        /// <summary>�����q</summary>
        public static readonly string CST_ConsTaxLayMethod_3 = "3:�����q";
        /// <summary>��ې�</summary>
        public static readonly string CST_ConsTaxLayMethod_9 = "9:��ې�";
        /// <summary>���z�\�����Ȃ��i�Ŕ����j</summary>
        public static readonly string CST_TotalAmountDispWayCd_0 = "���Ȃ�(�Ŕ�)";
        /// <summary>���z�\������i�ō��݁j</summary>
        public static readonly string CST_TotalAmountDispWayCd_1 = "����(�ō�)";
        /// <summary>�S�̐ݒ���Q�Ƃ���</summary>
        public static readonly string CST_TotalAmntDspWayRef_0 = "�S�̐ݒ�Q��";
        /// <summary>���Ӑ�ݒ���Q�Ƃ���</summary>
        public static readonly string CST_TotalAmntDspWayRef_1 = "���Ӑ�Q��";
        /// <summary>0:�ŗ��ݒ�}�X�^���Q��</summary>
        public static readonly string CST_CustCTaXLayRefCd_0 = "0:�ŗ��ݒ�Q��";
        /// <summary>1:���Ӑ�}�X�^���Q��</summary>
        public static readonly string CST_CustCTaXLayRefCd_1 = "1:���Ӑ�Q��";
        /// <summary>���������</summary>
        public static readonly string CST_CustomerAttributeDiv_0 = "0:���������";
        /// <summary>�Г������</summary>
        public static readonly string CST_CustomerAttributeDiv_8 = "1:�Г������";
        /// <summary>��������</summary>
        public static readonly string CST_CustomerAttributeDiv_9 = "2:��������";
        /// <summary>���Ӑ�</summary>
        public static readonly string CST_CustomerDivCd_0 = "0:���Ӑ�";
        /// <summary>�[����</summary>
        public static readonly string CST_CustomerDivCd_1 = "1:�[����";
        /// <summary>����</summary>
        public static readonly string CST_CollectCond_10 = "����";
        /// <summary>�U��</summary>
        public static readonly string CST_CollectCond_20 = "�U��";
        /// <summary>���؎�</summary>
        public static readonly string CST_CollectCond_30 = "���؎�";
        /// <summary>��`</summary>
        public static readonly string CST_CollectCond_40 = "��`";
        /// <summary>�萔���u</summary>
        public static readonly string CST_CollectCond_50 = "�萔��";
        /// <summary>���E</summary>
        public static readonly string CST_CollectCond_60 = "���E";
        /// <summary>�l��</summary>
        public static readonly string CST_CollectCond_70 = "�l��";
        /// <summary>���̑�</summary>
        public static readonly string CST_CollectCond_80 = "���̑�";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_CreditMngCode_0 = "0:���Ȃ�";
        /// <summary>����</summary>
        public static readonly string CST_CreditMngCode_1 = "1:����";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_DepoDelCode_0 = "0:���Ȃ�";
        /// <summary>����</summary>
        public static readonly string CST_DepoDelCode_1 = "1:����";
        /// <summary>���|�Ȃ�</summary>
        public static readonly string CST_AccRecDivCd_0 = "0:���|�Ȃ�";
        /// <summary>���|</summary>
        public static readonly string CST_AccRecDivCd_1 = "1:���|";
        /// <summary>����</summary>
        public static readonly string CST_EraNameCode_0 = "����";
        /// <summary>�a��</summary>
        public static readonly string CST_EraNameCode_1 = "�a��";
        /// <summary>�S�̐ݒ�Q��</summary>
        public static readonly string CST_CustSlipNoMngCd_0 = "0:�S�̐ݒ�Q��";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_CustSlipNoMngCd_1 = "1:���Ȃ�";
        /// <summary>����</summary>
        public static readonly string CST_CustSlipNoMngCd_2 = "2:����";
        /// <summary>�g�p���Ȃ�</summary>
        public static readonly string CST_CustomerSlipNoDiv_0 = "0:�g�p���Ȃ�";
        /// <summary>�A��</summary>
        public static readonly string CST_CustomerSlipNoDiv_1 = "1:�A��";
        /// <summary>����</summary>
        public static readonly string CST_CustomerSlipNoDiv_2 = "2:����";
        /// <summary>����</summary>
        public static readonly string CST_CustomerSlipNoDiv_3 = "3:����";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_CarMngDivCd_0 = "0:���Ȃ�";
        /// <summary>�o�^(�m�F)</summary>
        public static readonly string CST_CarMngDivCd_1 = "1:�o�^(�m�F)";
        /// <summary>�o�^(����)</summary>
        public static readonly string CST_CarMngDivCd_2 = "2:�o�^(����)";
        /// <summary>�o�^��</summary>
        public static readonly string CST_CarMngDivCd_3 = "3:�o�^��";
        /// <summary>�W��</summary>
        public static readonly string CST_QrcodePrtCd_0 = "0:�W��";
        /// <summary>�󎚂��Ȃ�</summary>
        public static readonly string CST_QrcodePrtCd_1 = "1:�󎚂��Ȃ�";
        /// <summary>�󎚂���</summary>
        public static readonly string CST_QrcodePrtCd_2 = "2:�󎚂���";
        /// <summary>�ԕi�܂�</summary>
        public static readonly string CST_QrcodePrtCd_3 = "3:�ԕi�܂�";
        /// <summary>�󎚂���i�g�у��[���j</summary>
        public static readonly string CST_QrcodePrtCd_4 = "4:�󎚂���i�g�у��[���j";
        /// <summary>�ԕi�܂ށi�g�у��[���j</summary>
        public static readonly string CST_QrcodePrtCd_5 = "5:�ԕi�܂ށi�g�у��[���j";
        /// <summary>�W��</summary>
        public static readonly string CST_PrtDiv_0 = "0:�W��";
        /// <summary>���g�p</summary>
        public static readonly string CST_PrtDiv_1 = "1:���g�p";
        /// <summary>�g�p</summary>
        public static readonly string CST_PrtDiv_2 = "2:�g�p";
        /// <summary>����</summary>
        public static readonly string CST_ReceiptOutputCode_0 = "0:����";
        /// <summary>���Ȃ�</summary>
        public static readonly string CST_ReceiptOutputCode_1 = "1:���Ȃ�";
        /// <summary>�Ȃ�</summary>
        public static readonly string CST_OnlineKindDiv_0 = "0:�Ȃ�";
        /// <summary>SCM</summary>
        //public static readonly string CST_OnlineKindDiv_10 = "1:SCM"; // 2011/06/09
        public static readonly string CST_OnlineKindDiv_10 = "1:PCC"; // 2011/06/09
        /// <summary>TSP.NS</summary>
        public static readonly string CST_OnlineKindDiv_20 = "20:TSP.NS";
        /// <summary>TSP.NS�C�����C��</summary>
        public static readonly string CST_OnlineKindDiv_30 = "30:TSP.NS�C�����C��";
        /// <summary>TSP���[��</summary>
        public static readonly string CST_OnlineKindDiv_40 = "40:TSP���[��";
        /// <summary>�W��</summary>
        public static readonly string CST_TotalBillOutputDiv_0 = "0:�W��";
        /// <summary>�g�p</summary>
        public static readonly string CST_TotalBillOutputDiv_1 = "1:�g�p";
        /// <summary>���g�p</summary>
        public static readonly string CST_TotalBillOutputDiv_2 = "2:���g�p";
        /// <summary>�W��</summary>
        public static readonly string CST_DetailBillOutputCode_0 = "0:�W��";
        /// <summary>�g�p</summary>
        public static readonly string CST_DetailBillOutputCode_1 = "1:�g�p";
        /// <summary>���g�p</summary>
        public static readonly string CST_DetailBillOutputCode_2 = "2:���g�p";
        /// <summary>�W��</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_0 = "0:�W��";
        /// <summary>�g�p</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_1 = "1:�g�p";
        /// <summary>���g�p</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_2 = "2:���g�p";

        # endregion
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        # region [private �t�B�[���h�i�����������j���Ӑ�}�X�^ �����o]
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = string.Empty;

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = string.Empty;

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = string.Empty;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ�T�u�R�[�h</summary>
        private string _customerSubCode = string.Empty;

        /// <summary>����</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name = string.Empty;

        /// <summary>����2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name2 = string.Empty;

        /// <summary>�h��</summary>
        private string _honorificTitle = string.Empty;

        /// <summary>�J�i</summary>
        private string _kana = string.Empty;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = string.Empty;

        /// <summary>�����R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _outputNameCode;

        /// <summary>��������</summary>
        private string _outputName = string.Empty;

        /// <summary>�l�E�@�l�敪</summary>
        /// <remarks>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</remarks>
        private Int32 _corporateDivCode;

        /// <summary>���Ӑ摮���敪</summary>
        /// <remarks>0:���������,8:�Г������,9:��������</remarks>
        private Int32 _customerAttributeDiv;

        /// <summary>�E��R�[�h</summary>
        private Int32 _jobTypeCode;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _postNo = string.Empty;

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address1 = string.Empty;

        /// <summary>�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address3 = string.Empty;

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address4 = string.Empty;

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = string.Empty;

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeTelNo = string.Empty;

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = string.Empty;

        /// <summary>FAX�ԍ��i����j</summary>
        private string _homeFaxNo = string.Empty;

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeFaxNo = string.Empty;

        /// <summary>�d�b�ԍ��i���̑��j</summary>
        private string _othersTelNo = string.Empty;

        /// <summary>��A����敪</summary>
        /// <remarks>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
        private Int32 _mainContactCode;

        /// <summary>�d�b�ԍ��i�����p��4���j</summary>
        private string _searchTelNo = string.Empty;

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = string.Empty;

        /// <summary>���͋��_�R�[�h</summary>
        private string _inpSectionCode = string.Empty;

        /// <summary>���Ӑ敪�̓R�[�h1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>���Ӑ敪�̓R�[�h2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>���Ӑ敪�̓R�[�h3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>���Ӑ敪�̓R�[�h4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>���Ӑ敪�̓R�[�h5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>���Ӑ敪�̓R�[�h6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>�������o�͋敪�R�[�h</summary>
        /// <remarks>0:���������s����,1:���Ȃ�</remarks>
        private Int32 _billOutputCode;

        /// <summary>�������o�͋敪����</summary>
        private string _billOutputName = string.Empty;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�W�����敪�R�[�h</summary>
        /// <remarks>0:����,1:����,2:���X��</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = string.Empty;

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>����T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _collectSight;

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _claimCode;

        /// <summary>������~��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _transStopDate;

        /// <summary>DM�o�͋敪</summary>
        /// <remarks>0:�o�͂���,1:�o�͂��Ȃ�</remarks>
        private Int32 _dmOutCode;

        /// <summary>DM�o�͋敪����</summary>
        /// <remarks>�S�p�ŊǗ�</remarks>
        private string _dmOutName = string.Empty;

        /// <summary>�呗�M�惁�[���A�h���X�敪</summary>
        /// <remarks>0:���[���A�h���X1,1:���[���A�h���X2</remarks>
        private Int32 _mainSendMailAddrCd;

        /// <summary>���[���A�h���X��ʃR�[�h1</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>���[���A�h���X��ʖ���1</summary>
        private string _mailAddrKindName1 = string.Empty;

        /// <summary>���[���A�h���X1</summary>
        private string _mailAddress1 = string.Empty;

        /// <summary>���[�����M�敪�R�[�h1</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode1;

        /// <summary>���[�����M�敪����1</summary>
        private string _mailSendName1 = string.Empty;

        /// <summary>���[���A�h���X��ʃR�[�h2</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>���[���A�h���X��ʖ���2</summary>
        private string _mailAddrKindName2 = string.Empty;

        /// <summary>���[���A�h���X2</summary>
        private string _mailAddress2 = string.Empty;

        /// <summary>���[�����M�敪�R�[�h2</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode2;

        /// <summary>���[�����M�敪����2</summary>
        private string _mailSendName2 = string.Empty;

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = string.Empty;

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = string.Empty;

        /// <summary>���ڋq�S���]�ƈ��R�[�h</summary>
        private string _oldCustomerAgentCd = string.Empty;

        /// <summary>�ڋq�S���ύX��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>�Ɣ̐�敪</summary>
        /// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>�^�M�Ǘ��敪</summary>
        private Int32 _creditMngCode;

        /// <summary>���������敪</summary>
        /// <remarks>PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j</remarks>
        private Int32 _depoDelCode;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>����`�[�ԍ��Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _custSlipNoMngCd;

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:���̑��iPM�͗D�ǁj�@</remarks>
        private Int32 _pureCode;

        /// <summary>���Ӑ����œ]�ŕ����Q�Ƌ敪</summary>
        /// <remarks>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\�����@�Q�Ƌ敪</summary>
        /// <remarks>0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</remarks>
        private Int32 _totalAmntDspWayRef;

        /// <summary>��s����1</summary>
        private string _accountNoInfo1 = string.Empty;

        /// <summary>��s����2</summary>
        private string _accountNoInfo2 = string.Empty;

        /// <summary>��s����3</summary>
        private string _accountNoInfo3 = string.Empty;

        /// <summary>����P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>������z�[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesMoneyFrcProcCd;

        /// <summary>�������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>���Ӑ�`�[�ԍ��敪</summary>
        /// <remarks>0:�g�p���Ȃ��@1:�g�p����</remarks>
        private Int32 _customerSlipNoDiv;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>���Ӑ�S����</summary>
        /// <remarks>���Ӑ�i�d����j�̖₢���킹��Ј���</remarks>
        private string _customerAgent = string.Empty;

        /// <summary>�������_�R�[�h</summary>
        /// <remarks>�������s�����_</remarks>
        private string _claimSectionCode = string.Empty;

        /// <summary>���q�Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</remarks>
        private Int32 _carMngDivCd;

        /// <summary>�i�Ԉ󎚋敪(������)</summary>
        /// <remarks>0:���i�}�X�^�A1:�L�A2:��</remarks>
        private Int32 _billPartsNoPrtCd;

        /// <summary>�i�Ԉ󎚋敪(�[�i���j</summary>
        /// <remarks>0:���i�}�X�^�A1:�L�A2:��</remarks>
        private Int32 _deliPartsNoPrtCd;

        /// <summary>�`�[�敪�����l</summary>
        private Int32 _defSalesSlipCd;

        /// <summary>�H�����o���[�g�����N</summary>
        private Int32 _lavorRateRank;

        /// <summary>�`�[�^�C�g���p�^�[��</summary>
        /// <remarks>0000:���ݒ�A0100:��{�^�C�g���A0200�E�E</remarks>
        private Int32 _slipTtlPrn;

        /// <summary>������s�R�[�h</summary>
        private Int32 _depoBankCode;

        /// <summary>���Ӑ�D��q�ɃR�[�h</summary>
        private String _custWarehouseCd;

        /// <summary>QR�R�[�h���</summary>
        private Int32 _qrcodePrtCd;

        /// <summary>�[�i���h��</summary>
        /// <remarks>�[�i���p�̌h��</remarks>
        private string _deliHonorificTtl = string.Empty;

        /// <summary>�������h��</summary>
        /// <remarks>�������p�̌h��</remarks>
        private string _billHonorificTtl = string.Empty;

        /// <summary>���Ϗ��h��</summary>
        /// <remarks>���Ϗ��p�̌h��</remarks>
        private string _estmHonorificTtl = string.Empty;

        /// <summary>�̎����h��</summary>
        /// <remarks>�̎����p�̌h��</remarks>
        private string _rectHonorificTtl = string.Empty;

        /// <summary>�[�i���h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _deliHonorTtlPrtDiv;

        /// <summary>�������h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _billHonorTtlPrtDiv;

        /// <summary>���Ϗ��h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _estmHonorTtlPrtDiv;

        /// <summary>�̎����h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _rectHonorTtlPrtDiv;

        /// <summary>���l1</summary>
        private string _note1 = string.Empty;

        /// <summary>���l2</summary>
        private string _note2 = string.Empty;

        /// <summary>���l3</summary>
        private string _note3 = string.Empty;

        /// <summary>���l4</summary>
        private string _note4 = string.Empty;

        /// <summary>���l5</summary>
        private string _note5 = string.Empty;

        /// <summary>���l6</summary>
        private string _note6 = string.Empty;

        /// <summary>���l7</summary>
        private string _note7 = string.Empty;

        /// <summary>���l8</summary>
        private string _note8 = string.Empty;

        /// <summary>���l9</summary>
        private string _note9 = string.Empty;

        /// <summary>���l10</summary>
        private string _note10 = string.Empty;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = string.Empty;

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = string.Empty;

        /// <summary>�E�햼��</summary>
        private string _jobTypeName = string.Empty;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = string.Empty;

        /// <summary>���͋��_����</summary>
        private string _inpSectionName = string.Empty;

        /// <summary>�������o�͋敪����</summary>
        /// <remarks>���������s����,���Ȃ�</remarks>
        private string _billOutPutCodeNm = string.Empty;

        /// <summary>�W���S���]�ƈ�����</summary>
        private string _billCollecterNm = string.Empty;

        // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------>>>>>
        /// <summary>�[�i���o�͋敪</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>�󒍓`�[�o�͋敪</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>�ݏo�`�[�o�͋敪</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private Int32 _shipmSlipPrtDiv;

        /// <summary>���ϓ`�[�o�͋敪</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private Int32 _estimatePrtDiv;

        /// <summary>UOE�`�[�o�͋敪</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private Int32 _uoeSlipPrtDiv;
        // --- ADD 2009/02/03 ��QID:9391�Ή�------------------------------------------------------<<<<<

        // ADD 2009/04/07 ------>>>
        /// <summary>�̎����o�͋敪�R�[�h</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _receiptOutputCode;
        // ADD 2009/04/07 ------<<<

        // ADD 2009/06/03 ------>>>
        /// <summary>���Ӑ��ƃR�[�h</summary>
        private string _customerEpCode = string.Empty;

        /// <summary>���Ӑ拒�_�R�[�h</summary>
        private string _customerSecCode = string.Empty;

        // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID</summary>
        private string _simplInqAcntAcntGrId = string.Empty;
        // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<

        /// <summary>�I�����C����ʋ敪</summary>
        /// <remarks>0:�Ȃ� 10:SCM 20:TSP.NS 30:TSP.NS�C�����C�� 40:TSP</remarks>
        private Int32 _onlineKindDiv;
        // ADD 2009/06/03 ------<<<
        // --- ADD  ���r��  2010/01/04 ---------->>>>>
        /// <summary>���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>���א������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>�`�[���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _slipTtlBillOutputDiv;
        // --- ADD  ���r��  2010/01/04 ----------<<<<<
        
        # endregion

        # region [private �t�B�[���h�i�蓮�ǉ��j�t�h�p�����o]
        /// <summary>�l�E�@�l�敪����</summary>
        private string _prslOrCorpDivNm = string.Empty;

        /// <summary>��A����敪����</summary>
        /// <remarks>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
        private string _mainContactName = string.Empty;

        /// <summary>����TEL�\������</summary>
        private string _homeTelNoDspName = string.Empty;

        /// <summary>�Ζ���TEL�\������</summary>
        private string _officeTelNoDspName = string.Empty;

        /// <summary>�g��TEL�\������</summary>
        private string _mobileTelNoDspName = string.Empty;

        /// <summary>���̑�TEL�\������</summary>
        private string _otherTelNoDspName = string.Empty;

        /// <summary>����FAX�\������</summary>
        private string _homeFaxNoDspName = string.Empty;

        /// <summary>�Ζ���FAX�\������</summary>
        private string _officeFaxNoDspName = string.Empty;
        # endregion

        # region [private �t�B�[���h�i�蓮�ǉ��j�R�[�h�ɑ΂��閼��]
        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = string.Empty;

        /// <summary>�����於��</summary>
        private string _claimName = string.Empty;

        /// <summary>�����於�̂Q</summary>
        private string _claimName2 = string.Empty;

        /// <summary>�����旪��</summary>
        private string _claimSnm = string.Empty;

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        private string _customerAgentNm = string.Empty;

        /// <summary>���ڋq�S���]�ƈ�����</summary>
        private string _oldCustomerAgentNm = string.Empty;

        /// <summary>�������_����</summary>
        private string _claimSectionName = string.Empty;

        /// <summary>������s����</summary>
        private string _depoBankName = string.Empty;

        /// <summary>���Ӑ�D��q�ɖ���</summary>
        private string _custWarehouseName = string.Empty;

        /// <summary>�Ǘ����_����</summary>
        private string _mngSectionName = string.Empty;
        // ADD �� K2014/02/06 ------------------------------>>>>>>
        /// <summary>����</summary>
        private string _noteInfo = string.Empty;
        // ADD �� K2014/02/06 ------------------------------<<<<<<
        // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
        /// <summary>���Ӑ���K�C�h�\��</summary>
        /// <remarks>0:�\������ 1:�\���Ȃ�</remarks>
        private Int32 _DisplayDivCode;
        // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
        # endregion

        // �p�u���b�N�v���p�e�B�Q
        // ���u���Ӑ�}�X�^ �����o�[�v�̃v���p�e�B�̂����ACollectMoneyCode, BillOutputCode, DmOutCode�ɂ��Ă�
        //   �R�[�hset���ɑΉ�����Name�ɂ��l������悤�ɕύX���Ă��܂��B
        //   �iName�̎�蓾��l���{�N���X�ɂĒ�`����Ă���̂ŁACode�̒l�����肷���Name����ӂɌ��܂�ׁj

		# region [�v���p�e�B�i�����������j���Ӑ�}�X�^ �����o]
        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSubCode
        /// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>����2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>�l�E�@�l�敪�v���p�e�B</summary>
        /// <value>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�E�@�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  CustomerAttributeDiv
        /// <summary>���Ӑ摮���敪�v���p�e�B</summary>
        /// <value>0:���������,8:�Г������,9:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ摮���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerAttributeDiv
        {
            get { return _customerAttributeDiv; }
            set { _customerAttributeDiv = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>�E��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>��A����敪�v���p�e�B</summary>
        /// <value>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��A����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>�d�b�ԍ��i�����p��4���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�����p��4���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>���Ӑ敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>���Ӑ敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>���Ӑ敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>���Ӑ敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>���Ӑ敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>���Ӑ敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>�������o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���������s����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
        }

        /// public propaty name  :  BillOutputName
        /// <summary>�������o�͋敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillOutputName
        {
            get { return _billOutputName; }
            set { _billOutputName = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����,1:����,2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectSight
        /// <summary>����T�C�g�v���p�e�B</summary>
        /// <value>��`�T�C�g�@180��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����T�C�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>������~���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  DmOutCode
        /// <summary>DM�o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���,1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmOutCode
        {
            get { return _dmOutCode; }
            set { _dmOutCode = value; }
        }

        /// public propaty name  :  DmOutName
        /// <summary>DM�o�͋敪���̃v���p�e�B</summary>
        /// <value>�S�p�ŊǗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM�o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmOutName
        {
            get { return _dmOutName; }
            set { _dmOutName = value; }
        }

        /// public propaty name  :  MainSendMailAddrCd
        /// <summary>�呗�M�惁�[���A�h���X�敪�v���p�e�B</summary>
        /// <value>0:���[���A�h���X1,1:���[���A�h���X2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �呗�M�惁�[���A�h���X�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainSendMailAddrCd
        {
            get { return _mainSendMailAddrCd; }
            set { _mainSendMailAddrCd = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>���[���A�h���X��ʃR�[�h1�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>���[���A�h���X��ʖ���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>���[���A�h���X1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>���[�����M�敪�R�[�h1�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailSendName1
        /// <summary>���[�����M�敪����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailSendName1
        {
            get { return _mailSendName1; }
            set { _mailSendName1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>���[���A�h���X��ʃR�[�h2�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>���[���A�h���X��ʖ���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>���[���A�h���X2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>���[�����M�敪�R�[�h2�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  MailSendName2
        /// <summary>���[�����M�敪����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailSendName2
        {
            get { return _mailSendName2; }
            set { _mailSendName2 = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>���ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>�ڋq�S���ύX���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>�Ɣ̐�敪�v���p�e�B</summary>
        /// <value>0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɣ̐�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>�^�M�Ǘ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  DepoDelCode
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepoDelCode
        {
            get { return _depoDelCode; }
            set { _depoDelCode = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  CustSlipNoMngCd
        /// <summary>����`�[�ԍ��Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNoMngCd
        {
            get { return _custSlipNoMngCd; }
            set { _custSlipNoMngCd = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:���̑��iPM�͗D�ǁj�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>���Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TotalAmntDspWayRef
        /// <summary>���z�\�����@�Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmntDspWayRef
        {
            get { return _totalAmntDspWayRef; }
            set { _totalAmntDspWayRef = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>����P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesMoneyFrcProcCd
        /// <summary>������z�[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesMoneyFrcProcCd
        {
            get { return _salesMoneyFrcProcCd; }
            set { _salesMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>���Ӑ�`�[�ԍ��敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ��@1:�g�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  CustomerAgent
        /// <summary>���Ӑ�S���҃v���p�e�B</summary>
        /// <value>���Ӑ�i�d����j�̖₢���킹��Ј���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgent
        {
            get { return _customerAgent; }
            set { _customerAgent = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// <value>�������s�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  CarMngDivCd
        /// <summary>���q�Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  BillPartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪(������)�v���p�e�B</summary>
        /// <value>0:���i�}�X�^�A1:�L�A2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪(������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillPartsNoPrtCd
        {
            get { return _billPartsNoPrtCd; }
            set { _billPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DeliPartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪(�[�i���j�v���p�e�B</summary>
        /// <value>0:���i�}�X�^�A1:�L�A2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪(�[�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliPartsNoPrtCd
        {
            get { return _deliPartsNoPrtCd; }
            set { _deliPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DefSalesSlipCd
        /// <summary>�`�[�敪�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefSalesSlipCd
        {
            get { return _defSalesSlipCd; }
            set { _defSalesSlipCd = value; }
        }

        /// public propaty name  :  LavorRateRank
        /// <summary>�H�����o���[�g�����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �H�����o���[�g�����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LavorRateRank
        {
            get { return _lavorRateRank; }
            set { _lavorRateRank = value; }
        }

        /// public propaty name  :  SlipTtlPrn
        /// <summary>�`�[�^�C�g���p�^�[���v���p�e�B</summary>
        /// <value>0000:���ݒ�A0100:��{�^�C�g���A0200�E�E</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�g���p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlPrn
        {
            get { return _slipTtlPrn; }
            set { _slipTtlPrn = value; }
        }

        /// public propaty name  :  DepoBankCode
        /// <summary>������s�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������s�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepoBankCode
        {
            get { return _depoBankCode; }
            set { _depoBankCode = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>���Ӑ�D��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QR�R�[�h����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QR�R�[�h����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 QrcodePrtCd
        {
            get { return _qrcodePrtCd; }
            set { _qrcodePrtCd = value; }
        }

        /// public propaty name  :  DeliHonorificTtl
        /// <summary>�[�i���h�̃v���p�e�B</summary>
        /// <value>�[�i���p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliHonorificTtl
        {
            get { return _deliHonorificTtl; }
            set { _deliHonorificTtl = value; }
        }

        /// public propaty name  :  BillHonorificTtl
        /// <summary>�������h�̃v���p�e�B</summary>
        /// <value>�������p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillHonorificTtl
        {
            get { return _billHonorificTtl; }
            set { _billHonorificTtl = value; }
        }

        /// public propaty name  :  EstmHonorificTtl
        /// <summary>���Ϗ��h�̃v���p�e�B</summary>
        /// <value>���Ϗ��p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstmHonorificTtl
        {
            get { return _estmHonorificTtl; }
            set { _estmHonorificTtl = value; }
        }

        /// public propaty name  :  RectHonorificTtl
        /// <summary>�̎����h�̃v���p�e�B</summary>
        /// <value>�̎����p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RectHonorificTtl
        {
            get { return _rectHonorificTtl; }
            set { _rectHonorificTtl = value; }
        }

        /// public propaty name  :  DeliHonorTtlPrtDiv
        /// <summary>�[�i���h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliHonorTtlPrtDiv
        {
            get { return _deliHonorTtlPrtDiv; }
            set { _deliHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorTtlPrtDiv
        /// <summary>�������h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillHonorTtlPrtDiv
        {
            get { return _billHonorTtlPrtDiv; }
            set { _billHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  EstmHonorTtlPrtDiv
        /// <summary>���Ϗ��h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstmHonorTtlPrtDiv
        {
            get { return _estmHonorTtlPrtDiv; }
            set { _estmHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  RectHonorTtlPrtDiv
        /// <summary>�̎����h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RectHonorTtlPrtDiv
        {
            get { return _rectHonorTtlPrtDiv; }
            set { _rectHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  Note1
        /// <summary>���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note1
        {
            get { return _note1; }
            set { _note1 = value; }
        }

        /// public propaty name  :  Note2
        /// <summary>���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note2
        {
            get { return _note2; }
            set { _note2 = value; }
        }

        /// public propaty name  :  Note3
        /// <summary>���l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note3
        {
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  Note4
        /// <summary>���l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note4
        {
            get { return _note4; }
            set { _note4 = value; }
        }

        /// public propaty name  :  Note5
        /// <summary>���l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note5
        {
            get { return _note5; }
            set { _note5 = value; }
        }

        /// public propaty name  :  Note6
        /// <summary>���l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note6
        {
            get { return _note6; }
            set { _note6 = value; }
        }

        /// public propaty name  :  Note7
        /// <summary>���l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note7
        {
            get { return _note7; }
            set { _note7 = value; }
        }

        /// public propaty name  :  Note8
        /// <summary>���l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note8
        {
            get { return _note8; }
            set { _note8 = value; }
        }

        /// public propaty name  :  Note9
        /// <summary>���l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note9
        {
            get { return _note9; }
            set { _note9 = value; }
        }

        /// public propaty name  :  Note10
        /// <summary>���l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note10
        {
            get { return _note10; }
            set { _note10 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  JobTypeName
        /// <summary>�E�햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E�햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>���͋��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  BillOutPutCodeNm
        /// <summary>�������o�͋敪���̃v���p�e�B</summary>
        /// <value>���������s����,���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillOutPutCodeNm
        {
            get { return _billOutPutCodeNm; }
            set { _billOutPutCodeNm = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>�[�i���o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>�󒍓`�[�o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍓`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>�ݏo�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>���ϓ`�[�o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϓ`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uoeSlipPrtDiv; }
            set { _uoeSlipPrtDiv = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>�̎����o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        // ADD 2009/06/03 ------>>>
        /// public propaty name  :  CustomerEpCode
        /// <summary>���Ӑ��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>���Ӑ拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇���A�J�E���g�O���[�vID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<

        /// public propaty name  :  OnlineKindDiv
        /// <summary>�I�����C����ʋ敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C����ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // ADD 2009/06/03 ------<<<
        // --- ADD  ���r��  2010/01/04 ---------->>>>>
        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>���א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>�`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }
        // --- ADD  ���r��  2010/01/04 ----------<<<<<


        # endregion

        # region [�v���p�e�B�i�蓮�ǉ��j�t�h�p�����o]
        /// public propaty name  :  PrslOrCorpDivNm
        /// <summary>�l�E�@�l�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�E�@�l�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrslOrCorpDivNm
        {
            get { return _prslOrCorpDivNm; }
            set { _prslOrCorpDivNm = value; }
        }

        /// public propaty name  :  PrslOrCorpDivNm
        /// <summary>��A����敪���̃v���p�e�B</summary>
        /// <value>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��A����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainContactName
        {
            get { return _mainContactName; }
            set { _mainContactName = value; }
        }

        /// public propaty name  :  HomeTelNoDspName
        /// <summary>����TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNoDspName
        {
            get { return _homeTelNoDspName; }
            set { _homeTelNoDspName = value; }
        }

        /// public propaty name  :  OfficeTelNoDspName
        /// <summary>�Ζ���TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNoDspName
        {
            get { return _officeTelNoDspName; }
            set { _officeTelNoDspName = value; }
        }

        /// public propaty name  :  MobileTelNoDspName
        /// <summary>�g��TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g��TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MobileTelNoDspName
        {
            get { return _mobileTelNoDspName; }
            set { _mobileTelNoDspName = value; }
        }

        /// public propaty name  :  OtherTelNoDspName
        /// <summary>���̑�TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̑�TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OtherTelNoDspName
        {
            get { return _otherTelNoDspName; }
            set { _otherTelNoDspName = value; }
        }

        /// public propaty name  :  HomeFaxNoDspName
        /// <summary>����FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNoDspName
        {
            get { return _homeFaxNoDspName; }
            set { _homeFaxNoDspName = value; }
        }

        /// public propaty name  :  OfficeFaxNoDspName
        /// <summary>�Ζ���FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNoDspName
        {
            get { return _officeFaxNoDspName; }
            set { _officeFaxNoDspName = value; }
        }
        # endregion

        # region [�v���p�e�B�i�蓮�ǉ��j�R�[�h�ɑ΂��閼��]
        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>���ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  ClaimSectionName
        /// <summary>�������_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionName
        {
            get { return _claimSectionName; }
            set { _claimSectionName = value; }
        }

        /// public propaty name  :  DepoBankName
        /// <summary>������s���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepoBankName
        {
            get { return _depoBankName; }
            set { _depoBankName = value; }
        }

        /// public propaty name  :  CustWarehouseName
        /// <summary>���Ӑ�D��q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustWarehouseName
        {
            get { return _custWarehouseName; }
            set { _custWarehouseName = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>�Ǘ����_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }
        # endregion

        #region [�v���p�e�B�i�蓮�ǉ��j�O�����J�p �����o]
        /// <summary>
        /// ���Ӑ�@����v���p�e�B
        /// </summary>
        public bool IsCustomer
        {
            get {
                return (this.AcceptWholeSale == 1);
            }
        }
        /// <summary>
        /// �[����@����v���p�e�B
        /// </summary>
        public bool IsReceiver
        {
            get {
                return (this.AcceptWholeSale == 2);
            }
        }

        // ADD �� K2014/02/06 ------------------------------>>>>>>
        /// <summary>
        /// ����
        /// </summary>
        public string NoteInfo
        {
            get
            {
                return this._noteInfo;
            }
            set
            {
                this._noteInfo = value;
            }
        }
        // ADD �� K2014/02/06 ------------------------------<<<<<<
        // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
        /// <summary>
        /// ���Ӑ���K�C�h�\��
        /// </summary>
        public Int32 DisplayDivCode
        {
            get { return _DisplayDivCode; }
            set { _DisplayDivCode = value; }
        }
        // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
        #endregion

        # region [�R���X�g���N�^�i�蓮�ǉ��j]
		/// <summary>
		/// ���Ӑ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>Customer�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Customer�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerInfo()
		{
			// ��ƃR�[�h�������ݒ�
			this._enterpriseCode =  LoginInfoAcquisition.EnterpriseCode;

			// �f�t�H���g�l�ݒ�
			this.OutputNameCode = 0;
			this.CollectMoneyCode = 0;
			this.BillOutputCode = 0;
			this.DmOutCode = 0;
			//this.SexCode = 0;
			this.CorporateDivCode = 0;
			this.MainContactCode = 0;
			this.MailSendCode1 = 0;
			this.MailSendCode2 = 0;
			//this.MailSendCode3 = 0;
			//this.MailSendCode4 = 0;
			//this.MailSendCode5 = 0;
			//this.MailSendCode6 = 0;
			this.MailAddrKindCode1 = 0;
			this.MailAddrKindCode2 = 0;
			//this.MailAddrKindCode3 = 0;
			//this.MailAddrKindCode4 = 0;
			//this.MailAddrKindCode5 = 0;
			//this.MailAddrKindCode6 = 0;

            this.CollectCond = 10;
        }
        # endregion

        # region [�R���X�g���N�^�i�����������@�{�@�ꕔ�蓮�ǉ��j]
        /// <summary>
        /// ���Ӑ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="customerSubCode">���Ӑ�T�u�R�[�h</param>
        /// <param name="name">����(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="name2">����2(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="kana">�J�i</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="outputNameCode">�����R�[�h(0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������)</param>
        /// <param name="outputName">��������</param>
        /// <param name="corporateDivCode">�l�E�@�l�敪(0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�)</param>
        /// <param name="customerAttributeDiv">���Ӑ摮���敪(0:���������,8:�Г������,9:��������)</param>
        /// <param name="jobTypeCode">�E��R�[�h</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
        /// <param name="postNo">�X�֔ԍ�(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address1">�Z��1�i�s���{���s��S�E�����E���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address3">�Z��3�i�Ԓn�j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address4">�Z��4�i�A�p�[�g���́j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
        /// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
        /// <param name="homeFaxNo">FAX�ԍ��i����j</param>
        /// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="othersTelNo">�d�b�ԍ��i���̑��j</param>
        /// <param name="mainContactCode">��A����敪(0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���)</param>
        /// <param name="searchTelNo">�d�b�ԍ��i�����p��4���j</param>
        /// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
        /// <param name="inpSectionCode">���͋��_�R�[�h</param>
        /// <param name="custAnalysCode1">���Ӑ敪�̓R�[�h1</param>
        /// <param name="custAnalysCode2">���Ӑ敪�̓R�[�h2</param>
        /// <param name="custAnalysCode3">���Ӑ敪�̓R�[�h3</param>
        /// <param name="custAnalysCode4">���Ӑ敪�̓R�[�h4</param>
        /// <param name="custAnalysCode5">���Ӑ敪�̓R�[�h5</param>
        /// <param name="custAnalysCode6">���Ӑ敪�̓R�[�h6</param>
        /// <param name="billOutputCode">�������o�͋敪�R�[�h(0:���������s����,1:���Ȃ�)</param>
        /// <param name="billOutputName">�������o�͋敪����</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="collectMoneyCode">�W�����敪�R�[�h(0:����,1:����,2:���X��)</param>
        /// <param name="collectMoneyName">�W�����敪����(����,����,���X��)</param>
        /// <param name="collectMoneyDay">�W����(DD)</param>
        /// <param name="collectCond">�������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
        /// <param name="collectSight">����T�C�g(��`�T�C�g�@180��)</param>
        /// <param name="claimCode">������R�[�h(�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="transStopDate">������~��(YYYYMMDD)</param>
        /// <param name="dmOutCode">DM�o�͋敪(0:�o�͂���,1:�o�͂��Ȃ�)</param>
        /// <param name="dmOutName">DM�o�͋敪����(�S�p�ŊǗ�)</param>
        /// <param name="mainSendMailAddrCd">�呗�M�惁�[���A�h���X�敪(0:���[���A�h���X1,1:���[���A�h���X2)</param>
        /// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h1(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName1">���[���A�h���X��ʖ���1</param>
        /// <param name="mailAddress1">���[���A�h���X1</param>
        /// <param name="mailSendCode1">���[�����M�敪�R�[�h1(0:�񑗐M,1:���M)</param>
        /// <param name="mailSendName1">���[�����M�敪����1</param>
        /// <param name="mailAddrKindCode2">���[���A�h���X��ʃR�[�h2(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName2">���[���A�h���X��ʖ���2</param>
        /// <param name="mailAddress2">���[���A�h���X2</param>
        /// <param name="mailSendCode2">���[�����M�敪�R�[�h2(0:�񑗐M,1:���M)</param>
        /// <param name="mailSendName2">���[�����M�敪����2</param>
        /// <param name="customerAgentCd">�ڋq�S���]�ƈ��R�[�h(�����^)</param>
        /// <param name="billCollecterCd">�W���S���]�ƈ��R�[�h</param>
        /// <param name="oldCustomerAgentCd">���ڋq�S���]�ƈ��R�[�h</param>
        /// <param name="custAgentChgDate">�ڋq�S���ύX��(YYYYMMDD)</param>
        /// <param name="acceptWholeSale">�Ɣ̐�敪(0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����)</param>
        /// <param name="creditMngCode">�^�M�Ǘ��敪</param>
        /// <param name="depoDelCode">���������敪(PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j)</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="custSlipNoMngCd">����`�[�ԍ��Ǘ��敪(0:���Ȃ��@1:����)</param>
        /// <param name="pureCode">�����敪(0:�����A1:���̑��iPM�͗D�ǁj�@)</param>
        /// <param name="custCTaXLayRefCd">���Ӑ����œ]�ŕ����Q�Ƌ敪(0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��)</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�)</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="totalAmntDspWayRef">���z�\�����@�Q�Ƌ敪(0:�S�̐ݒ�Q�� 1:���Ӑ�Q��)</param>
        /// <param name="accountNoInfo1">��s����1</param>
        /// <param name="accountNoInfo2">��s����2</param>
        /// <param name="accountNoInfo3">��s����3</param>
        /// <param name="salesUnPrcFrcProcCd">����P���[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="salesMoneyFrcProcCd">������z�[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="customerSlipNoDiv">���Ӑ�`�[�ԍ��敪(0:�g�p���Ȃ��@1:�g�p����)</param>
        /// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
        /// <param name="customerAgent">���Ӑ�S����(���Ӑ�i�d����j�̖₢���킹��Ј���)</param>
        /// <param name="claimSectionCode">�������_�R�[�h(�������s�����_)</param>
        /// <param name="carMngDivCd">���q�Ǘ��敪(0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��)</param>
        /// <param name="billPartsNoPrtCd">�i�Ԉ󎚋敪(������)(0:���i�}�X�^�A1:�L�A2:��)</param>
        /// <param name="deliPartsNoPrtCd">�i�Ԉ󎚋敪(�[�i���j(0:���i�}�X�^�A1:�L�A2:��)</param>
        /// <param name="defSalesSlipCd">�`�[�敪�����l</param>
        /// <param name="lavorRateRank">�H�����o���[�g�����N</param>
        /// <param name="slipTtlPrn">�`�[�^�C�g���p�^�[��(0000:���ݒ�A0100:��{�^�C�g���A0200�E�E)</param>
        /// <param name="depoBankCode">������s�R�[�h</param>
        /// <param name="custWarehouseCd">���Ӑ�D��q�ɃR�[�h</param>
        /// <param name="qrcodePrtCd">QR�R�[�h���</param>
        /// <param name="deliHonorificTtl">�[�i���h��(�[�i���p�̌h��)</param>
        /// <param name="billHonorificTtl">�������h��(�������p�̌h��)</param>
        /// <param name="estmHonorificTtl">���Ϗ��h��(���Ϗ��p�̌h��)</param>
        /// <param name="rectHonorificTtl">�̎����h��(�̎����p�̌h��)</param>
        /// <param name="deliHonorTtlPrtDiv">�[�i���h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="billHonorTtlPrtDiv">�������h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="estmHonorTtlPrtDiv">���Ϗ��h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="rectHonorTtlPrtDiv">�̎����h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="note1">���l1</param>
        /// <param name="note2">���l2</param>
        /// <param name="note3">���l3</param>
        /// <param name="note4">���l4</param>
        /// <param name="note5">���l5</param>
        /// <param name="note6">���l6</param>
        /// <param name="note7">���l7</param>
        /// <param name="note8">���l8</param>
        /// <param name="note9">���l9</param>
        /// <param name="note10">���l10</param>
        /// <param name="salesAreaName">�̔��G���A����</param>
        /// <param name="claimName">�����於��</param>
        /// <param name="claimName2">�����於�̂Q</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerAgentNm">�ڋq�S���]�ƈ�����</param>
        /// <param name="oldCustomerAgentNm">���ڋq�S���]�ƈ�����</param>
        /// <param name="claimSectionName">�������_����</param>
        /// <param name="depoBankName">������s����</param>
        /// <param name="custWarehouseName">���Ӑ�D��q�ɖ���</param>
        /// <param name="mngSectionName">�Ǘ����_����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="jobTypeName">�E�햼��</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <param name="inpSectionName">���͋��_����</param>
        /// <param name="billOutPutCodeNm">�������o�͋敪����(���������s����,���Ȃ�)</param>
        /// <param name="billCollecterNm">�W���S���]�ƈ�����</param>
        /// <param name="homeTelNoDspName">����s�d�k�ԍ��\������</param>
        /// <param name="officeTelNoDspName">�Ζ���s�d�k�ԍ��\������</param>
        /// <param name="mobileTelNoDspName">�g�тs�d�k�ԍ��\������</param>
        /// <param name="otherTelNoDspName">���̑��s�d�k�ԍ��\������</param>
        /// <param name="homeFaxNoDspName">����e�`�w�ԍ��\������</param>
        /// <param name="officeFaxNoDspName">�Ζ���e�`�w�ԍ��\������</param>
        /// <param name="salesSlipPrtDiv">�[�i���o�͋敪</param>
        /// <param name="acpOdrrSlipPrtDiv">�󒍓`�[�o�͋敪</param>
        /// <param name="shipmSlipPrtDiv">�ݏo�`�[�o�͋敪</param>
        /// <param name="estimatePrtDiv">���ϓ`�[�o�͋敪</param>
        /// <param name="uoeSlipPrtDiv">UOE�`�[�o�͋敪</param>
        /// <param name="receiptOutputCode">�̎����o�͋敪�R�[�h</param>
        /// <param name="customerEpCode">���Ӑ��ƃR�[�h</param>
        /// <param name="customerSecCode">���Ӑ拒�_�R�[�h</param>
        /// <param name="onlineKindDiv">�I�����C����ʋ敪</param>
        /// <param name="totalBillOutputDiv">���v�������o�͋敪</param>
        /// <param name="detailBillOutputCode">���א������o�͋敪</param>
        /// <param name="slipTtlBillOutputDiv">�`�[���v�������o�͋敪</param>
        /// <param name="simplInqAcntAcntGrId">�ȒP�⍇���A�J�E���g�O���[�vID</param>
        /// <param name="noteInfo">����</param>
        /// <param name="DisplayDivCode">���Ӑ���K�C�h�\��</param>
        /// <returns>CustomerInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode)       
        // --- UPD  ���r��  2010/01/04 ---------->>>>> 
        //public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode, string customerEpCode, string customerSecCode, Int32 onlineKindDiv)
        public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode, string customerEpCode, string customerSecCode, Int32 onlineKindDiv, Int32 totalBillOutputDiv, Int32 detailBillOutputCode, Int32 slipTtlBillOutputDiv
        , string simplInqAcntAcntGrId, string noteInfo   // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ�
        , Int32 DisplayDivCode   // ADD 2021/05/10 ���Ӑ���K�C�h�\��
        )
        // --- UPD  ���r��  2010/01/04 ---------->>>>>
        // (�蓮�ǉ�)��
        ///// <param name="homeTelNoDspName">����s�d�k�ԍ��\������</param>
        ///// <param name="officeTelNoDspName">�Ζ���s�d�k�ԍ��\������</param>
        ///// <param name="mobileTelNoDspName">�g�тs�d�k�ԍ��\������</param>
        ///// <param name="otherTelNoDspName">���̑��s�d�k�ԍ��\������</param>
        ///// <param name="homeFaxNoDspName">����e�`�w�ԍ��\������</param>
        ///// <param name="officeFaxNoDspName">�Ζ���e�`�w�ԍ��\������</param>
        /////
        // (�蓮�ǉ�)���@, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, CusCarNote cusCarNoteObj )
        // UPD �� K2014/02/06 ----------------------------->>>>>
        // (�蓮�ǉ�)��
        //// <param name="noteInfo">����</param>
        // (�蓮�ǉ�)���@, string noteInfo
        {
            # region [�i�����������j]
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._customerSnm = customerSnm;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._customerAttributeDiv = customerAttributeDiv;
            this._jobTypeCode = jobTypeCode;
            this._businessTypeCode = businessTypeCode;
            this._salesAreaCode = salesAreaCode;
            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._searchTelNo = searchTelNo;
            this._mngSectionCode = mngSectionCode;
            this._inpSectionCode = inpSectionCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._billOutputCode = billOutputCode;
            this._billOutputName = billOutputName;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._collectCond = collectCond;
            this._collectSight = collectSight;
            this._claimCode = claimCode;
            this._transStopDate = transStopDate;
            this._dmOutCode = dmOutCode;
            this._dmOutName = dmOutName;
            this._mainSendMailAddrCd = mainSendMailAddrCd;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailSendName1 = mailSendName1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._mailSendName2 = mailSendName2;
            this._customerAgentCd = customerAgentCd;
            this._billCollecterCd = billCollecterCd;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._custAgentChgDate = custAgentChgDate;
            this._acceptWholeSale = acceptWholeSale;
            this._creditMngCode = creditMngCode;
            this._depoDelCode = depoDelCode;
            this._accRecDivCd = accRecDivCd;
            this._custSlipNoMngCd = custSlipNoMngCd;
            this._pureCode = pureCode;
            this._custCTaXLayRefCd = custCTaXLayRefCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._totalAmntDspWayRef = totalAmntDspWayRef;
            this._accountNoInfo1 = accountNoInfo1;
            this._accountNoInfo2 = accountNoInfo2;
            this._accountNoInfo3 = accountNoInfo3;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._salesMoneyFrcProcCd = salesMoneyFrcProcCd;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._customerSlipNoDiv = customerSlipNoDiv;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._customerAgent = customerAgent;
            this._claimSectionCode = claimSectionCode;
            this._carMngDivCd = carMngDivCd;
            this._billPartsNoPrtCd = billPartsNoPrtCd;
            this._deliPartsNoPrtCd = deliPartsNoPrtCd;
            this._defSalesSlipCd = defSalesSlipCd;
            this._lavorRateRank = lavorRateRank;
            this._slipTtlPrn = slipTtlPrn;
            this._depoBankCode = depoBankCode;
            this._custWarehouseCd = custWarehouseCd;
            this._qrcodePrtCd = qrcodePrtCd;
            this._deliHonorificTtl = deliHonorificTtl;
            this._billHonorificTtl = billHonorificTtl;
            this._estmHonorificTtl = estmHonorificTtl;
            this._rectHonorificTtl = rectHonorificTtl;
            this._deliHonorTtlPrtDiv = deliHonorTtlPrtDiv;
            this._billHonorTtlPrtDiv = billHonorTtlPrtDiv;
            this._estmHonorTtlPrtDiv = estmHonorTtlPrtDiv;
            this._rectHonorTtlPrtDiv = rectHonorTtlPrtDiv;
            this._note1 = note1;
            this._note2 = note2;
            this._note3 = note3;
            this._note4 = note4;
            this._note5 = note5;
            this._note6 = note6;
            this._note7 = note7;
            this._note8 = note8;
            this._note9 = note9;
            this._note10 = note10;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._jobTypeName = jobTypeName;
            this._businessTypeName = businessTypeName;
            this._inpSectionName = inpSectionName;
            this._billOutPutCodeNm = billOutPutCodeNm;
            this._billCollecterNm = billCollecterNm;
            this._salesSlipPrtDiv = salesSlipPrtDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._shipmSlipPrtDiv = shipmSlipPrtDiv;
            this._estimatePrtDiv = estimatePrtDiv;
            this._uoeSlipPrtDiv = uoeSlipPrtDiv;
            this._receiptOutputCode = receiptOutputCode;
            // ADD 2009/06/03 ------>>>
            this._customerEpCode = customerEpCode;
            this._customerSecCode = customerSecCode;
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
            this._simplInqAcntAcntGrId = simplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
            this._onlineKindDiv = onlineKindDiv;
            // ADD 2009/06/03 ------<<<
            // --- ADD  ���r��  2010/01/04 ---------->>>>>
            this._totalBillOutputDiv = totalBillOutputDiv;
            this._detailBillOutputCode = detailBillOutputCode;
            this._slipTtlBillOutputDiv = slipTtlBillOutputDiv;
            // --- ADD  ���r��  2010/01/04 ----------<<<<<
            // ADD �� K2014/02/06 --------------------->>>>>
            this._noteInfo = noteInfo;
            // ADD �� K2014/02/06 ---------------------<<<<<
            // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
            this._DisplayDivCode = DisplayDivCode;
            // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
            # endregion

            # region [�i�蓮�ǉ��j]
            // ����
            this._salesAreaName = salesAreaName;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerAgentNm = customerAgentNm;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this._claimSectionName = claimSectionName;
            this._depoBankName = depoBankName;
            this._custWarehouseName = custWarehouseName;
            this._mngSectionName = mngSectionName;

            // �s�d�k�E�e�`�w�\�����́i�t�h�\���p�̍��ځj
            this._homeTelNoDspName = homeTelNoDspName;
            this._officeTelNoDspName = officeTelNoDspName;
            this._mobileTelNoDspName = mobileTelNoDspName;
            this._otherTelNoDspName = otherTelNoDspName;
            this._homeFaxNoDspName = homeFaxNoDspName;
            this._officeFaxNoDspName = officeFaxNoDspName;
            # endregion
        }

        /// <summary>
        /// ���Ӑ�}�X�^��������
        /// </summary>
        /// <returns>Customer�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Customer�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerInfo Clone()
        {
            // (�蓮�ǉ�)�@���@, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName);
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode);
            // --- UPD  ���r��  2010/01/04 ---------->>>>>
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv);
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv, this.TotalBillOutputDiv,this._detailBillOutputCode,this._slipTtlBillOutputDiv
            //, this._simplInqAcntAcntGrId    // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ�    
            //);
            // --- UPD  ���r��  2010/01/04 ----------<<<<<
            return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv, this.TotalBillOutputDiv, this._detailBillOutputCode, this._slipTtlBillOutputDiv
            , this._simplInqAcntAcntGrId, this._noteInfo // ADD �� K2014/02/06  
            , this._DisplayDivCode   // ADD 2021/05/10 ���Ӑ���K�C�h�\��
            );
        }
        # endregion

        # region [public���\�b�h�i�����������j]
        /// <summary>
        /// ���Ӑ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( CustomerInfo target )
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSubCode == target.CustomerSubCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.CustomerAttributeDiv == target.CustomerAttributeDiv)
                 && (this.JobTypeCode == target.JobTypeCode)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.SearchTelNo == target.SearchTelNo)
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.InpSectionCode == target.InpSectionCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.BillOutputCode == target.BillOutputCode)
                 && (this.BillOutputName == target.BillOutputName)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CollectCond == target.CollectCond)
                 && (this.CollectSight == target.CollectSight)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.TransStopDate == target.TransStopDate)
                 && (this.DmOutCode == target.DmOutCode)
                 && (this.DmOutName == target.DmOutName)
                 && (this.MainSendMailAddrCd == target.MainSendMailAddrCd)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailSendName1 == target.MailSendName1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.MailSendName2 == target.MailSendName2)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.AcceptWholeSale == target.AcceptWholeSale)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.DepoDelCode == target.DepoDelCode)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.CustSlipNoMngCd == target.CustSlipNoMngCd)
                 && (this.PureCode == target.PureCode)
                 && (this.CustCTaXLayRefCd == target.CustCTaXLayRefCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TotalAmntDspWayRef == target.TotalAmntDspWayRef)
                 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
                 && (this.SalesMoneyFrcProcCd == target.SalesMoneyFrcProcCd)
                 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
                 && (this.CustomerSlipNoDiv == target.CustomerSlipNoDiv)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.CustomerAgent == target.CustomerAgent)
                 && (this.ClaimSectionCode == target.ClaimSectionCode)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.BillPartsNoPrtCd == target.BillPartsNoPrtCd)
                 && (this.DeliPartsNoPrtCd == target.DeliPartsNoPrtCd)
                 && (this.DefSalesSlipCd == target.DefSalesSlipCd)
                 && (this.LavorRateRank == target.LavorRateRank)
                 && (this.SlipTtlPrn == target.SlipTtlPrn)
                 && (this.DepoBankCode == target.DepoBankCode)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.QrcodePrtCd == target.QrcodePrtCd)
                 && (this.DeliHonorificTtl == target.DeliHonorificTtl)
                 && (this.BillHonorificTtl == target.BillHonorificTtl)
                 && (this.EstmHonorificTtl == target.EstmHonorificTtl)
                 && (this.RectHonorificTtl == target.RectHonorificTtl)
                 && (this.DeliHonorTtlPrtDiv == target.DeliHonorTtlPrtDiv)
                 && (this.BillHonorTtlPrtDiv == target.BillHonorTtlPrtDiv)
                 && (this.EstmHonorTtlPrtDiv == target.EstmHonorTtlPrtDiv)
                 && (this.RectHonorTtlPrtDiv == target.RectHonorTtlPrtDiv)
                 && (this.Note1 == target.Note1)
                 && (this.Note2 == target.Note2)
                 && (this.Note3 == target.Note3)
                 && (this.Note4 == target.Note4)
                 && (this.Note5 == target.Note5)
                 && (this.Note6 == target.Note6)
                 && (this.Note7 == target.Note7)
                 && (this.Note8 == target.Note8)
                 && (this.Note9 == target.Note9)
                 && (this.Note10 == target.Note10)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.ClaimSectionName == target.ClaimSectionName)
                 && (this.DepoBankName == target.DepoBankName)
                 && (this.CustWarehouseName == target.CustWarehouseName)
                 && (this.MngSectionName == target.MngSectionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.JobTypeName == target.JobTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.InpSectionName == target.InpSectionName)
                 && (this.BillOutPutCodeNm == target.BillOutPutCodeNm)
                 && (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.ShipmSlipPrtDiv == target.ShipmSlipPrtDiv)
                 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)
                 && (this.ReceiptOutputCode == target.ReceiptOutputCode)
                 // ADD 2009/06/03 ------>>>
                 && (this.CustomerEpCode == target.CustomerEpCode)
                 && (this.CustomerSecCode == target.CustomerSecCode)
                // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
                && (this.SimplInqAcntAcntGrId == target.SimplInqAcntAcntGrId)
                // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
                 && (this.OnlineKindDiv == target.OnlineKindDiv)
                 // ADD 2009/06/03 ------<<<
                 // --- ADD  ���r��  2010/01/04 ---------->>>>>
                 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
                 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
                 && (this.SlipTtlBillOutputDiv == target.SlipTtlBillOutputDiv)
                 // --- ADD  ���r��  2010/01/04 ----------<<<<<
                 // ADD �� K2014/02/06--------------------------->>>>>
                 && (this.NoteInfo == target.NoteInfo)
                 // ADD �� K2014/02/06---------------------------<<<<<
                 // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
                 && (this.DisplayDivCode == target.DisplayDivCode)
                 // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
                 );
        }

        /// <summary>
        /// ���Ӑ�}�X�^��r����
        /// </summary>
        /// <param name="customerInfo1">
        ///                    ��r����CustomerInfo�N���X�̃C���X�^���X
        /// </param>
        /// <param name="customerInfo2">��r����CustomerInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( CustomerInfo customerInfo1, CustomerInfo customerInfo2 )
        {
            return ((customerInfo1.CreateDateTime == customerInfo2.CreateDateTime)
                 && (customerInfo1.UpdateDateTime == customerInfo2.UpdateDateTime)
                 && (customerInfo1.EnterpriseCode == customerInfo2.EnterpriseCode)
                 && (customerInfo1.FileHeaderGuid == customerInfo2.FileHeaderGuid)
                 && (customerInfo1.UpdEmployeeCode == customerInfo2.UpdEmployeeCode)
                 && (customerInfo1.UpdAssemblyId1 == customerInfo2.UpdAssemblyId1)
                 && (customerInfo1.UpdAssemblyId2 == customerInfo2.UpdAssemblyId2)
                 && (customerInfo1.LogicalDeleteCode == customerInfo2.LogicalDeleteCode)
                 && (customerInfo1.CustomerCode == customerInfo2.CustomerCode)
                 && (customerInfo1.CustomerSubCode == customerInfo2.CustomerSubCode)
                 && (customerInfo1.Name == customerInfo2.Name)
                 && (customerInfo1.Name2 == customerInfo2.Name2)
                 && (customerInfo1.HonorificTitle == customerInfo2.HonorificTitle)
                 && (customerInfo1.Kana == customerInfo2.Kana)
                 && (customerInfo1.CustomerSnm == customerInfo2.CustomerSnm)
                 && (customerInfo1.OutputNameCode == customerInfo2.OutputNameCode)
                 && (customerInfo1.OutputName == customerInfo2.OutputName)
                 && (customerInfo1.CorporateDivCode == customerInfo2.CorporateDivCode)
                 && (customerInfo1.CustomerAttributeDiv == customerInfo2.CustomerAttributeDiv)
                 && (customerInfo1.JobTypeCode == customerInfo2.JobTypeCode)
                 && (customerInfo1.BusinessTypeCode == customerInfo2.BusinessTypeCode)
                 && (customerInfo1.SalesAreaCode == customerInfo2.SalesAreaCode)
                 && (customerInfo1.PostNo == customerInfo2.PostNo)
                 && (customerInfo1.Address1 == customerInfo2.Address1)
                 && (customerInfo1.Address3 == customerInfo2.Address3)
                 && (customerInfo1.Address4 == customerInfo2.Address4)
                 && (customerInfo1.HomeTelNo == customerInfo2.HomeTelNo)
                 && (customerInfo1.OfficeTelNo == customerInfo2.OfficeTelNo)
                 && (customerInfo1.PortableTelNo == customerInfo2.PortableTelNo)
                 && (customerInfo1.HomeFaxNo == customerInfo2.HomeFaxNo)
                 && (customerInfo1.OfficeFaxNo == customerInfo2.OfficeFaxNo)
                 && (customerInfo1.OthersTelNo == customerInfo2.OthersTelNo)
                 && (customerInfo1.MainContactCode == customerInfo2.MainContactCode)
                 && (customerInfo1.SearchTelNo == customerInfo2.SearchTelNo)
                 && (customerInfo1.MngSectionCode == customerInfo2.MngSectionCode)
                 && (customerInfo1.InpSectionCode == customerInfo2.InpSectionCode)
                 && (customerInfo1.CustAnalysCode1 == customerInfo2.CustAnalysCode1)
                 && (customerInfo1.CustAnalysCode2 == customerInfo2.CustAnalysCode2)
                 && (customerInfo1.CustAnalysCode3 == customerInfo2.CustAnalysCode3)
                 && (customerInfo1.CustAnalysCode4 == customerInfo2.CustAnalysCode4)
                 && (customerInfo1.CustAnalysCode5 == customerInfo2.CustAnalysCode5)
                 && (customerInfo1.CustAnalysCode6 == customerInfo2.CustAnalysCode6)
                 && (customerInfo1.BillOutputCode == customerInfo2.BillOutputCode)
                 && (customerInfo1.BillOutputName == customerInfo2.BillOutputName)
                 && (customerInfo1.TotalDay == customerInfo2.TotalDay)
                 && (customerInfo1.CollectMoneyCode == customerInfo2.CollectMoneyCode)
                 && (customerInfo1.CollectMoneyName == customerInfo2.CollectMoneyName)
                 && (customerInfo1.CollectMoneyDay == customerInfo2.CollectMoneyDay)
                 && (customerInfo1.CollectCond == customerInfo2.CollectCond)
                 && (customerInfo1.CollectSight == customerInfo2.CollectSight)
                 && (customerInfo1.ClaimCode == customerInfo2.ClaimCode)
                 && (customerInfo1.TransStopDate == customerInfo2.TransStopDate)
                 && (customerInfo1.DmOutCode == customerInfo2.DmOutCode)
                 && (customerInfo1.DmOutName == customerInfo2.DmOutName)
                 && (customerInfo1.MainSendMailAddrCd == customerInfo2.MainSendMailAddrCd)
                 && (customerInfo1.MailAddrKindCode1 == customerInfo2.MailAddrKindCode1)
                 && (customerInfo1.MailAddrKindName1 == customerInfo2.MailAddrKindName1)
                 && (customerInfo1.MailAddress1 == customerInfo2.MailAddress1)
                 && (customerInfo1.MailSendCode1 == customerInfo2.MailSendCode1)
                 && (customerInfo1.MailSendName1 == customerInfo2.MailSendName1)
                 && (customerInfo1.MailAddrKindCode2 == customerInfo2.MailAddrKindCode2)
                 && (customerInfo1.MailAddrKindName2 == customerInfo2.MailAddrKindName2)
                 && (customerInfo1.MailAddress2 == customerInfo2.MailAddress2)
                 && (customerInfo1.MailSendCode2 == customerInfo2.MailSendCode2)
                 && (customerInfo1.MailSendName2 == customerInfo2.MailSendName2)
                 && (customerInfo1.CustomerAgentCd == customerInfo2.CustomerAgentCd)
                 && (customerInfo1.BillCollecterCd == customerInfo2.BillCollecterCd)
                 && (customerInfo1.OldCustomerAgentCd == customerInfo2.OldCustomerAgentCd)
                 && (customerInfo1.CustAgentChgDate == customerInfo2.CustAgentChgDate)
                 && (customerInfo1.AcceptWholeSale == customerInfo2.AcceptWholeSale)
                 && (customerInfo1.CreditMngCode == customerInfo2.CreditMngCode)
                 && (customerInfo1.DepoDelCode == customerInfo2.DepoDelCode)
                 && (customerInfo1.AccRecDivCd == customerInfo2.AccRecDivCd)
                 && (customerInfo1.CustSlipNoMngCd == customerInfo2.CustSlipNoMngCd)
                 && (customerInfo1.PureCode == customerInfo2.PureCode)
                 && (customerInfo1.CustCTaXLayRefCd == customerInfo2.CustCTaXLayRefCd)
                 && (customerInfo1.ConsTaxLayMethod == customerInfo2.ConsTaxLayMethod)
                 && (customerInfo1.TotalAmountDispWayCd == customerInfo2.TotalAmountDispWayCd)
                 && (customerInfo1.TotalAmntDspWayRef == customerInfo2.TotalAmntDspWayRef)
                 && (customerInfo1.AccountNoInfo1 == customerInfo2.AccountNoInfo1)
                 && (customerInfo1.AccountNoInfo2 == customerInfo2.AccountNoInfo2)
                 && (customerInfo1.AccountNoInfo3 == customerInfo2.AccountNoInfo3)
                 && (customerInfo1.SalesUnPrcFrcProcCd == customerInfo2.SalesUnPrcFrcProcCd)
                 && (customerInfo1.SalesMoneyFrcProcCd == customerInfo2.SalesMoneyFrcProcCd)
                 && (customerInfo1.SalesCnsTaxFrcProcCd == customerInfo2.SalesCnsTaxFrcProcCd)
                 && (customerInfo1.CustomerSlipNoDiv == customerInfo2.CustomerSlipNoDiv)
                 && (customerInfo1.NTimeCalcStDate == customerInfo2.NTimeCalcStDate)
                 && (customerInfo1.CustomerAgent == customerInfo2.CustomerAgent)
                 && (customerInfo1.ClaimSectionCode == customerInfo2.ClaimSectionCode)
                 && (customerInfo1.CarMngDivCd == customerInfo2.CarMngDivCd)
                 && (customerInfo1.BillPartsNoPrtCd == customerInfo2.BillPartsNoPrtCd)
                 && (customerInfo1.DeliPartsNoPrtCd == customerInfo2.DeliPartsNoPrtCd)
                 && (customerInfo1.DefSalesSlipCd == customerInfo2.DefSalesSlipCd)
                 && (customerInfo1.LavorRateRank == customerInfo2.LavorRateRank)
                 && (customerInfo1.SlipTtlPrn == customerInfo2.SlipTtlPrn)
                 && (customerInfo1.DepoBankCode == customerInfo2.DepoBankCode)
                 && (customerInfo1.CustWarehouseCd == customerInfo2.CustWarehouseCd)
                 && (customerInfo1.QrcodePrtCd == customerInfo2.QrcodePrtCd)
                 && (customerInfo1.DeliHonorificTtl == customerInfo2.DeliHonorificTtl)
                 && (customerInfo1.BillHonorificTtl == customerInfo2.BillHonorificTtl)
                 && (customerInfo1.EstmHonorificTtl == customerInfo2.EstmHonorificTtl)
                 && (customerInfo1.RectHonorificTtl == customerInfo2.RectHonorificTtl)
                 && (customerInfo1.DeliHonorTtlPrtDiv == customerInfo2.DeliHonorTtlPrtDiv)
                 && (customerInfo1.BillHonorTtlPrtDiv == customerInfo2.BillHonorTtlPrtDiv)
                 && (customerInfo1.EstmHonorTtlPrtDiv == customerInfo2.EstmHonorTtlPrtDiv)
                 && (customerInfo1.RectHonorTtlPrtDiv == customerInfo2.RectHonorTtlPrtDiv)
                 && (customerInfo1.Note1 == customerInfo2.Note1)
                 && (customerInfo1.Note2 == customerInfo2.Note2)
                 && (customerInfo1.Note3 == customerInfo2.Note3)
                 && (customerInfo1.Note4 == customerInfo2.Note4)
                 && (customerInfo1.Note5 == customerInfo2.Note5)
                 && (customerInfo1.Note6 == customerInfo2.Note6)
                 && (customerInfo1.Note7 == customerInfo2.Note7)
                 && (customerInfo1.Note8 == customerInfo2.Note8)
                 && (customerInfo1.Note9 == customerInfo2.Note9)
                 && (customerInfo1.Note10 == customerInfo2.Note10)
                 && (customerInfo1.SalesAreaName == customerInfo2.SalesAreaName)
                 && (customerInfo1.ClaimName == customerInfo2.ClaimName)
                 && (customerInfo1.ClaimName2 == customerInfo2.ClaimName2)
                 && (customerInfo1.ClaimSnm == customerInfo2.ClaimSnm)
                 && (customerInfo1.CustomerAgentNm == customerInfo2.CustomerAgentNm)
                 && (customerInfo1.OldCustomerAgentNm == customerInfo2.OldCustomerAgentNm)
                 && (customerInfo1.ClaimSectionName == customerInfo2.ClaimSectionName)
                 && (customerInfo1.DepoBankName == customerInfo2.DepoBankName)
                 && (customerInfo1.CustWarehouseName == customerInfo2.CustWarehouseName)
                 && (customerInfo1.MngSectionName == customerInfo2.MngSectionName)
                 && (customerInfo1.EnterpriseName == customerInfo2.EnterpriseName)
                 && (customerInfo1.UpdEmployeeName == customerInfo2.UpdEmployeeName)
                 && (customerInfo1.JobTypeName == customerInfo2.JobTypeName)
                 && (customerInfo1.BusinessTypeName == customerInfo2.BusinessTypeName)
                 && (customerInfo1.InpSectionName == customerInfo2.InpSectionName)
                 && (customerInfo1.BillOutPutCodeNm == customerInfo2.BillOutPutCodeNm)
                 && (customerInfo1.BillCollecterNm == customerInfo2.BillCollecterNm)
                 && (customerInfo1.SalesSlipPrtDiv == customerInfo2.SalesSlipPrtDiv)
                 && (customerInfo1.AcpOdrrSlipPrtDiv == customerInfo2.AcpOdrrSlipPrtDiv)
                 && (customerInfo1.ShipmSlipPrtDiv == customerInfo2.ShipmSlipPrtDiv)
                 && (customerInfo1.EstimatePrtDiv == customerInfo2.EstimatePrtDiv)
                 && (customerInfo1.UOESlipPrtDiv == customerInfo2.UOESlipPrtDiv)
                 && (customerInfo1.ReceiptOutputCode == customerInfo2.ReceiptOutputCode)
                 // ADD 2009/06/03 ------>>>
                 && (customerInfo1.CustomerEpCode == customerInfo2.CustomerEpCode)
                 && (customerInfo1.CustomerSecCode == customerInfo2.CustomerSecCode)
                // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
                 && (customerInfo1.SimplInqAcntAcntGrId == customerInfo2.SimplInqAcntAcntGrId)
                // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
                 && (customerInfo1.OnlineKindDiv == customerInfo2.OnlineKindDiv)
                 // ADD 2009/06/03 ------<<<
                 // --- ADD  ���r��  2010/01/04 ---------->>>>>
                 && (customerInfo1.TotalBillOutputDiv == customerInfo2.TotalBillOutputDiv)
                 && (customerInfo1.DetailBillOutputCode == customerInfo2.DetailBillOutputCode)
                 && (customerInfo1.SlipTtlBillOutputDiv == customerInfo2.SlipTtlBillOutputDiv)
                 // --- ADD  ���r��  2010/01/04 ----------<<<<<
                 // ADD �� K2014/02/06--------------------------->>>>>
                 && (customerInfo1.NoteInfo == customerInfo2.NoteInfo)
                 // ADD �� K2014/02/06---------------------------<<<<<
                 // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
                 && (customerInfo1.DisplayDivCode == customerInfo2.DisplayDivCode)
                 // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
                 );
        }
        /// <summary>
        /// ���Ӑ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( CustomerInfo target )
        {
            ArrayList resList = new ArrayList();
            if ( this.CreateDateTime != target.CreateDateTime ) resList.Add( "CreateDateTime" );
            if ( this.UpdateDateTime != target.UpdateDateTime ) resList.Add( "UpdateDateTime" );
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.FileHeaderGuid != target.FileHeaderGuid ) resList.Add( "FileHeaderGuid" );
            if ( this.UpdEmployeeCode != target.UpdEmployeeCode ) resList.Add( "UpdEmployeeCode" );
            if ( this.UpdAssemblyId1 != target.UpdAssemblyId1 ) resList.Add( "UpdAssemblyId1" );
            if ( this.UpdAssemblyId2 != target.UpdAssemblyId2 ) resList.Add( "UpdAssemblyId2" );
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( this.CustomerCode != target.CustomerCode ) resList.Add( "CustomerCode" );
            if ( this.CustomerSubCode != target.CustomerSubCode ) resList.Add( "CustomerSubCode" );
            if ( this.Name != target.Name ) resList.Add( "Name" );
            if ( this.Name2 != target.Name2 ) resList.Add( "Name2" );
            if ( this.HonorificTitle != target.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( this.Kana != target.Kana ) resList.Add( "Kana" );
            if ( this.CustomerSnm != target.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( this.OutputNameCode != target.OutputNameCode ) resList.Add( "OutputNameCode" );
            if ( this.OutputName != target.OutputName ) resList.Add( "OutputName" );
            if ( this.CorporateDivCode != target.CorporateDivCode ) resList.Add( "CorporateDivCode" );
            if ( this.CustomerAttributeDiv != target.CustomerAttributeDiv ) resList.Add( "CustomerAttributeDiv" );
            if ( this.JobTypeCode != target.JobTypeCode ) resList.Add( "JobTypeCode" );
            if ( this.BusinessTypeCode != target.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( this.SalesAreaCode != target.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( this.PostNo != target.PostNo ) resList.Add( "PostNo" );
            if ( this.Address1 != target.Address1 ) resList.Add( "Address1" );
            if ( this.Address3 != target.Address3 ) resList.Add( "Address3" );
            if ( this.Address4 != target.Address4 ) resList.Add( "Address4" );
            if ( this.HomeTelNo != target.HomeTelNo ) resList.Add( "HomeTelNo" );
            if ( this.OfficeTelNo != target.OfficeTelNo ) resList.Add( "OfficeTelNo" );
            if ( this.PortableTelNo != target.PortableTelNo ) resList.Add( "PortableTelNo" );
            if ( this.HomeFaxNo != target.HomeFaxNo ) resList.Add( "HomeFaxNo" );
            if ( this.OfficeFaxNo != target.OfficeFaxNo ) resList.Add( "OfficeFaxNo" );
            if ( this.OthersTelNo != target.OthersTelNo ) resList.Add( "OthersTelNo" );
            if ( this.MainContactCode != target.MainContactCode ) resList.Add( "MainContactCode" );
            if ( this.SearchTelNo != target.SearchTelNo ) resList.Add( "SearchTelNo" );
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( this.InpSectionCode != target.InpSectionCode ) resList.Add( "InpSectionCode" );
            if ( this.CustAnalysCode1 != target.CustAnalysCode1 ) resList.Add( "CustAnalysCode1" );
            if ( this.CustAnalysCode2 != target.CustAnalysCode2 ) resList.Add( "CustAnalysCode2" );
            if ( this.CustAnalysCode3 != target.CustAnalysCode3 ) resList.Add( "CustAnalysCode3" );
            if ( this.CustAnalysCode4 != target.CustAnalysCode4 ) resList.Add( "CustAnalysCode4" );
            if ( this.CustAnalysCode5 != target.CustAnalysCode5 ) resList.Add( "CustAnalysCode5" );
            if ( this.CustAnalysCode6 != target.CustAnalysCode6 ) resList.Add( "CustAnalysCode6" );
            if ( this.BillOutputCode != target.BillOutputCode ) resList.Add( "BillOutputCode" );
            if ( this.BillOutputName != target.BillOutputName ) resList.Add( "BillOutputName" );
            if ( this.TotalDay != target.TotalDay ) resList.Add( "TotalDay" );
            if ( this.CollectMoneyCode != target.CollectMoneyCode ) resList.Add( "CollectMoneyCode" );
            if ( this.CollectMoneyName != target.CollectMoneyName ) resList.Add( "CollectMoneyName" );
            if ( this.CollectMoneyDay != target.CollectMoneyDay ) resList.Add( "CollectMoneyDay" );
            if ( this.CollectCond != target.CollectCond ) resList.Add( "CollectCond" );
            if ( this.CollectSight != target.CollectSight ) resList.Add( "CollectSight" );
            if ( this.ClaimCode != target.ClaimCode ) resList.Add( "ClaimCode" );
            if ( this.TransStopDate != target.TransStopDate ) resList.Add( "TransStopDate" );
            if ( this.DmOutCode != target.DmOutCode ) resList.Add( "DmOutCode" );
            if ( this.DmOutName != target.DmOutName ) resList.Add( "DmOutName" );
            if ( this.MainSendMailAddrCd != target.MainSendMailAddrCd ) resList.Add( "MainSendMailAddrCd" );
            if ( this.MailAddrKindCode1 != target.MailAddrKindCode1 ) resList.Add( "MailAddrKindCode1" );
            if ( this.MailAddrKindName1 != target.MailAddrKindName1 ) resList.Add( "MailAddrKindName1" );
            if ( this.MailAddress1 != target.MailAddress1 ) resList.Add( "MailAddress1" );
            if ( this.MailSendCode1 != target.MailSendCode1 ) resList.Add( "MailSendCode1" );
            if ( this.MailSendName1 != target.MailSendName1 ) resList.Add( "MailSendName1" );
            if ( this.MailAddrKindCode2 != target.MailAddrKindCode2 ) resList.Add( "MailAddrKindCode2" );
            if ( this.MailAddrKindName2 != target.MailAddrKindName2 ) resList.Add( "MailAddrKindName2" );
            if ( this.MailAddress2 != target.MailAddress2 ) resList.Add( "MailAddress2" );
            if ( this.MailSendCode2 != target.MailSendCode2 ) resList.Add( "MailSendCode2" );
            if ( this.MailSendName2 != target.MailSendName2 ) resList.Add( "MailSendName2" );
            if ( this.CustomerAgentCd != target.CustomerAgentCd ) resList.Add( "CustomerAgentCd" );
            if ( this.BillCollecterCd != target.BillCollecterCd ) resList.Add( "BillCollecterCd" );
            if ( this.OldCustomerAgentCd != target.OldCustomerAgentCd ) resList.Add( "OldCustomerAgentCd" );
            if ( this.CustAgentChgDate != target.CustAgentChgDate ) resList.Add( "CustAgentChgDate" );
            if ( this.AcceptWholeSale != target.AcceptWholeSale ) resList.Add( "AcceptWholeSale" );
            if ( this.CreditMngCode != target.CreditMngCode ) resList.Add( "CreditMngCode" );
            if ( this.DepoDelCode != target.DepoDelCode ) resList.Add( "DepoDelCode" );
            if ( this.AccRecDivCd != target.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( this.CustSlipNoMngCd != target.CustSlipNoMngCd ) resList.Add( "CustSlipNoMngCd" );
            if ( this.PureCode != target.PureCode ) resList.Add( "PureCode" );
            if ( this.CustCTaXLayRefCd != target.CustCTaXLayRefCd ) resList.Add( "CustCTaXLayRefCd" );
            if ( this.ConsTaxLayMethod != target.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( this.TotalAmountDispWayCd != target.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( this.TotalAmntDspWayRef != target.TotalAmntDspWayRef ) resList.Add( "TotalAmntDspWayRef" );
            if ( this.AccountNoInfo1 != target.AccountNoInfo1 ) resList.Add( "AccountNoInfo1" );
            if ( this.AccountNoInfo2 != target.AccountNoInfo2 ) resList.Add( "AccountNoInfo2" );
            if ( this.AccountNoInfo3 != target.AccountNoInfo3 ) resList.Add( "AccountNoInfo3" );
            if ( this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd ) resList.Add( "SalesUnPrcFrcProcCd" );
            if ( this.SalesMoneyFrcProcCd != target.SalesMoneyFrcProcCd ) resList.Add( "SalesMoneyFrcProcCd" );
            if ( this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd ) resList.Add( "SalesCnsTaxFrcProcCd" );
            if ( this.CustomerSlipNoDiv != target.CustomerSlipNoDiv ) resList.Add( "CustomerSlipNoDiv" );
            if ( this.NTimeCalcStDate != target.NTimeCalcStDate ) resList.Add( "NTimeCalcStDate" );
            if ( this.CustomerAgent != target.CustomerAgent ) resList.Add( "CustomerAgent" );
            if ( this.ClaimSectionCode != target.ClaimSectionCode ) resList.Add( "ClaimSectionCode" );
            if ( this.CarMngDivCd != target.CarMngDivCd ) resList.Add( "CarMngDivCd" );
            if ( this.BillPartsNoPrtCd != target.BillPartsNoPrtCd ) resList.Add( "BillPartsNoPrtCd" );
            if ( this.DeliPartsNoPrtCd != target.DeliPartsNoPrtCd ) resList.Add( "DeliPartsNoPrtCd" );
            if ( this.DefSalesSlipCd != target.DefSalesSlipCd ) resList.Add( "DefSalesSlipCd" );
            if ( this.LavorRateRank != target.LavorRateRank ) resList.Add( "LavorRateRank" );
            if ( this.SlipTtlPrn != target.SlipTtlPrn ) resList.Add( "SlipTtlPrn" );
            if ( this.DepoBankCode != target.DepoBankCode ) resList.Add( "DepoBankCode" );
            if ( this.CustWarehouseCd != target.CustWarehouseCd ) resList.Add( "CustWarehouseCd" );
            if ( this.QrcodePrtCd != target.QrcodePrtCd ) resList.Add( "QrcodePrtCd" );
            if ( this.DeliHonorificTtl != target.DeliHonorificTtl ) resList.Add( "DeliHonorificTtl" );
            if ( this.BillHonorificTtl != target.BillHonorificTtl ) resList.Add( "BillHonorificTtl" );
            if ( this.EstmHonorificTtl != target.EstmHonorificTtl ) resList.Add( "EstmHonorificTtl" );
            if ( this.RectHonorificTtl != target.RectHonorificTtl ) resList.Add( "RectHonorificTtl" );
            if ( this.DeliHonorTtlPrtDiv != target.DeliHonorTtlPrtDiv ) resList.Add( "DeliHonorTtlPrtDiv" );
            if ( this.BillHonorTtlPrtDiv != target.BillHonorTtlPrtDiv ) resList.Add( "BillHonorTtlPrtDiv" );
            if ( this.EstmHonorTtlPrtDiv != target.EstmHonorTtlPrtDiv ) resList.Add( "EstmHonorTtlPrtDiv" );
            if ( this.RectHonorTtlPrtDiv != target.RectHonorTtlPrtDiv ) resList.Add( "RectHonorTtlPrtDiv" );
            if ( this.Note1 != target.Note1 ) resList.Add( "Note1" );
            if ( this.Note2 != target.Note2 ) resList.Add( "Note2" );
            if ( this.Note3 != target.Note3 ) resList.Add( "Note3" );
            if ( this.Note4 != target.Note4 ) resList.Add( "Note4" );
            if ( this.Note5 != target.Note5 ) resList.Add( "Note5" );
            if ( this.Note6 != target.Note6 ) resList.Add( "Note6" );
            if ( this.Note7 != target.Note7 ) resList.Add( "Note7" );
            if ( this.Note8 != target.Note8 ) resList.Add( "Note8" );
            if ( this.Note9 != target.Note9 ) resList.Add( "Note9" );
            if ( this.Note10 != target.Note10 ) resList.Add( "Note10" );
            if ( this.SalesAreaName != target.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( this.ClaimName != target.ClaimName ) resList.Add( "ClaimName" );
            if ( this.ClaimName2 != target.ClaimName2 ) resList.Add( "ClaimName2" );
            if ( this.ClaimSnm != target.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( this.CustomerAgentNm != target.CustomerAgentNm ) resList.Add( "CustomerAgentNm" );
            if ( this.OldCustomerAgentNm != target.OldCustomerAgentNm ) resList.Add( "OldCustomerAgentNm" );
            if ( this.ClaimSectionName != target.ClaimSectionName ) resList.Add( "ClaimSectionName" );
            if ( this.DepoBankName != target.DepoBankName ) resList.Add( "DepoBankName" );
            if ( this.CustWarehouseName != target.CustWarehouseName ) resList.Add( "CustWarehouseName" );
            if ( this.MngSectionName != target.MngSectionName ) resList.Add( "MngSectionName" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.UpdEmployeeName != target.UpdEmployeeName ) resList.Add( "UpdEmployeeName" );
            if ( this.JobTypeName != target.JobTypeName ) resList.Add( "JobTypeName" );
            if ( this.BusinessTypeName != target.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( this.InpSectionName != target.InpSectionName ) resList.Add( "InpSectionName" );
            if ( this.BillOutPutCodeNm != target.BillOutPutCodeNm ) resList.Add( "BillOutPutCodeNm" );
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.SalesSlipPrtDiv != target.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.ShipmSlipPrtDiv != target.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (this.EstimatePrtDiv != target.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (this.ReceiptOutputCode != target.ReceiptOutputCode) resList.Add("ReceiptOutputCode");
            // ADD 2009/06/03 ------>>>
            if (this.CustomerEpCode != target.CustomerEpCode) resList.Add("CustomerEpCode");
            if (this.CustomerSecCode != target.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
            if (this.SimplInqAcntAcntGrId != target.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");
            // ADD 2009/06/03 ------<<<
            // --- ADD  ���r��  2010/01/04 ---------->>>>>
            if (this.TotalBillOutputDiv != target.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (this.DetailBillOutputCode != target.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (this.SlipTtlBillOutputDiv != target.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");
            // --- ADD  ���r��  2010/01/04 ----------<<<<<
            // ADD �� K2014/02/06--------------------------->>>>>
            if (this.NoteInfo != target.NoteInfo) resList.Add("NoteInfo");
            // ADD �� K2014/02/06---------------------------<<<<<
            // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
            if (this.DisplayDivCode != target.DisplayDivCode) resList.Add("DisplayDivCode");
            // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
                 
            return resList;
        }

        /// <summary>
        /// ���Ӑ�}�X�^��r����
        /// </summary>
        /// <param name="customerInfo1">��r����CustomerInfo�N���X�̃C���X�^���X</param>
        /// <param name="customerInfo2">��r����CustomerInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( CustomerInfo customerInfo1, CustomerInfo customerInfo2 )
        {
            ArrayList resList = new ArrayList();
            if ( customerInfo1.CreateDateTime != customerInfo2.CreateDateTime ) resList.Add( "CreateDateTime" );
            if ( customerInfo1.UpdateDateTime != customerInfo2.UpdateDateTime ) resList.Add( "UpdateDateTime" );
            if ( customerInfo1.EnterpriseCode != customerInfo2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( customerInfo1.FileHeaderGuid != customerInfo2.FileHeaderGuid ) resList.Add( "FileHeaderGuid" );
            if ( customerInfo1.UpdEmployeeCode != customerInfo2.UpdEmployeeCode ) resList.Add( "UpdEmployeeCode" );
            if ( customerInfo1.UpdAssemblyId1 != customerInfo2.UpdAssemblyId1 ) resList.Add( "UpdAssemblyId1" );
            if ( customerInfo1.UpdAssemblyId2 != customerInfo2.UpdAssemblyId2 ) resList.Add( "UpdAssemblyId2" );
            if ( customerInfo1.LogicalDeleteCode != customerInfo2.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( customerInfo1.CustomerCode != customerInfo2.CustomerCode ) resList.Add( "CustomerCode" );
            if ( customerInfo1.CustomerSubCode != customerInfo2.CustomerSubCode ) resList.Add( "CustomerSubCode" );
            if ( customerInfo1.Name != customerInfo2.Name ) resList.Add( "Name" );
            if ( customerInfo1.Name2 != customerInfo2.Name2 ) resList.Add( "Name2" );
            if ( customerInfo1.HonorificTitle != customerInfo2.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( customerInfo1.Kana != customerInfo2.Kana ) resList.Add( "Kana" );
            if ( customerInfo1.CustomerSnm != customerInfo2.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( customerInfo1.OutputNameCode != customerInfo2.OutputNameCode ) resList.Add( "OutputNameCode" );
            if ( customerInfo1.OutputName != customerInfo2.OutputName ) resList.Add( "OutputName" );
            if ( customerInfo1.CorporateDivCode != customerInfo2.CorporateDivCode ) resList.Add( "CorporateDivCode" );
            if ( customerInfo1.CustomerAttributeDiv != customerInfo2.CustomerAttributeDiv ) resList.Add( "CustomerAttributeDiv" );
            if ( customerInfo1.JobTypeCode != customerInfo2.JobTypeCode ) resList.Add( "JobTypeCode" );
            if ( customerInfo1.BusinessTypeCode != customerInfo2.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( customerInfo1.SalesAreaCode != customerInfo2.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( customerInfo1.PostNo != customerInfo2.PostNo ) resList.Add( "PostNo" );
            if ( customerInfo1.Address1 != customerInfo2.Address1 ) resList.Add( "Address1" );
            if ( customerInfo1.Address3 != customerInfo2.Address3 ) resList.Add( "Address3" );
            if ( customerInfo1.Address4 != customerInfo2.Address4 ) resList.Add( "Address4" );
            if ( customerInfo1.HomeTelNo != customerInfo2.HomeTelNo ) resList.Add( "HomeTelNo" );
            if ( customerInfo1.OfficeTelNo != customerInfo2.OfficeTelNo ) resList.Add( "OfficeTelNo" );
            if ( customerInfo1.PortableTelNo != customerInfo2.PortableTelNo ) resList.Add( "PortableTelNo" );
            if ( customerInfo1.HomeFaxNo != customerInfo2.HomeFaxNo ) resList.Add( "HomeFaxNo" );
            if ( customerInfo1.OfficeFaxNo != customerInfo2.OfficeFaxNo ) resList.Add( "OfficeFaxNo" );
            if ( customerInfo1.OthersTelNo != customerInfo2.OthersTelNo ) resList.Add( "OthersTelNo" );
            if ( customerInfo1.MainContactCode != customerInfo2.MainContactCode ) resList.Add( "MainContactCode" );
            if ( customerInfo1.SearchTelNo != customerInfo2.SearchTelNo ) resList.Add( "SearchTelNo" );
            if ( customerInfo1.MngSectionCode != customerInfo2.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( customerInfo1.InpSectionCode != customerInfo2.InpSectionCode ) resList.Add( "InpSectionCode" );
            if ( customerInfo1.CustAnalysCode1 != customerInfo2.CustAnalysCode1 ) resList.Add( "CustAnalysCode1" );
            if ( customerInfo1.CustAnalysCode2 != customerInfo2.CustAnalysCode2 ) resList.Add( "CustAnalysCode2" );
            if ( customerInfo1.CustAnalysCode3 != customerInfo2.CustAnalysCode3 ) resList.Add( "CustAnalysCode3" );
            if ( customerInfo1.CustAnalysCode4 != customerInfo2.CustAnalysCode4 ) resList.Add( "CustAnalysCode4" );
            if ( customerInfo1.CustAnalysCode5 != customerInfo2.CustAnalysCode5 ) resList.Add( "CustAnalysCode5" );
            if ( customerInfo1.CustAnalysCode6 != customerInfo2.CustAnalysCode6 ) resList.Add( "CustAnalysCode6" );
            if ( customerInfo1.BillOutputCode != customerInfo2.BillOutputCode ) resList.Add( "BillOutputCode" );
            if ( customerInfo1.BillOutputName != customerInfo2.BillOutputName ) resList.Add( "BillOutputName" );
            if ( customerInfo1.TotalDay != customerInfo2.TotalDay ) resList.Add( "TotalDay" );
            if ( customerInfo1.CollectMoneyCode != customerInfo2.CollectMoneyCode ) resList.Add( "CollectMoneyCode" );
            if ( customerInfo1.CollectMoneyName != customerInfo2.CollectMoneyName ) resList.Add( "CollectMoneyName" );
            if ( customerInfo1.CollectMoneyDay != customerInfo2.CollectMoneyDay ) resList.Add( "CollectMoneyDay" );
            if ( customerInfo1.CollectCond != customerInfo2.CollectCond ) resList.Add( "CollectCond" );
            if ( customerInfo1.CollectSight != customerInfo2.CollectSight ) resList.Add( "CollectSight" );
            if ( customerInfo1.ClaimCode != customerInfo2.ClaimCode ) resList.Add( "ClaimCode" );
            if ( customerInfo1.TransStopDate != customerInfo2.TransStopDate ) resList.Add( "TransStopDate" );
            if ( customerInfo1.DmOutCode != customerInfo2.DmOutCode ) resList.Add( "DmOutCode" );
            if ( customerInfo1.DmOutName != customerInfo2.DmOutName ) resList.Add( "DmOutName" );
            if ( customerInfo1.MainSendMailAddrCd != customerInfo2.MainSendMailAddrCd ) resList.Add( "MainSendMailAddrCd" );
            if ( customerInfo1.MailAddrKindCode1 != customerInfo2.MailAddrKindCode1 ) resList.Add( "MailAddrKindCode1" );
            if ( customerInfo1.MailAddrKindName1 != customerInfo2.MailAddrKindName1 ) resList.Add( "MailAddrKindName1" );
            if ( customerInfo1.MailAddress1 != customerInfo2.MailAddress1 ) resList.Add( "MailAddress1" );
            if ( customerInfo1.MailSendCode1 != customerInfo2.MailSendCode1 ) resList.Add( "MailSendCode1" );
            if ( customerInfo1.MailSendName1 != customerInfo2.MailSendName1 ) resList.Add( "MailSendName1" );
            if ( customerInfo1.MailAddrKindCode2 != customerInfo2.MailAddrKindCode2 ) resList.Add( "MailAddrKindCode2" );
            if ( customerInfo1.MailAddrKindName2 != customerInfo2.MailAddrKindName2 ) resList.Add( "MailAddrKindName2" );
            if ( customerInfo1.MailAddress2 != customerInfo2.MailAddress2 ) resList.Add( "MailAddress2" );
            if ( customerInfo1.MailSendCode2 != customerInfo2.MailSendCode2 ) resList.Add( "MailSendCode2" );
            if ( customerInfo1.MailSendName2 != customerInfo2.MailSendName2 ) resList.Add( "MailSendName2" );
            if ( customerInfo1.CustomerAgentCd != customerInfo2.CustomerAgentCd ) resList.Add( "CustomerAgentCd" );
            if ( customerInfo1.BillCollecterCd != customerInfo2.BillCollecterCd ) resList.Add( "BillCollecterCd" );
            if ( customerInfo1.OldCustomerAgentCd != customerInfo2.OldCustomerAgentCd ) resList.Add( "OldCustomerAgentCd" );
            if ( customerInfo1.CustAgentChgDate != customerInfo2.CustAgentChgDate ) resList.Add( "CustAgentChgDate" );
            if ( customerInfo1.AcceptWholeSale != customerInfo2.AcceptWholeSale ) resList.Add( "AcceptWholeSale" );
            if ( customerInfo1.CreditMngCode != customerInfo2.CreditMngCode ) resList.Add( "CreditMngCode" );
            if ( customerInfo1.DepoDelCode != customerInfo2.DepoDelCode ) resList.Add( "DepoDelCode" );
            if ( customerInfo1.AccRecDivCd != customerInfo2.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( customerInfo1.CustSlipNoMngCd != customerInfo2.CustSlipNoMngCd ) resList.Add( "CustSlipNoMngCd" );
            if ( customerInfo1.PureCode != customerInfo2.PureCode ) resList.Add( "PureCode" );
            if ( customerInfo1.CustCTaXLayRefCd != customerInfo2.CustCTaXLayRefCd ) resList.Add( "CustCTaXLayRefCd" );
            if ( customerInfo1.ConsTaxLayMethod != customerInfo2.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( customerInfo1.TotalAmountDispWayCd != customerInfo2.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( customerInfo1.TotalAmntDspWayRef != customerInfo2.TotalAmntDspWayRef ) resList.Add( "TotalAmntDspWayRef" );
            if ( customerInfo1.AccountNoInfo1 != customerInfo2.AccountNoInfo1 ) resList.Add( "AccountNoInfo1" );
            if ( customerInfo1.AccountNoInfo2 != customerInfo2.AccountNoInfo2 ) resList.Add( "AccountNoInfo2" );
            if ( customerInfo1.AccountNoInfo3 != customerInfo2.AccountNoInfo3 ) resList.Add( "AccountNoInfo3" );
            if ( customerInfo1.SalesUnPrcFrcProcCd != customerInfo2.SalesUnPrcFrcProcCd ) resList.Add( "SalesUnPrcFrcProcCd" );
            if ( customerInfo1.SalesMoneyFrcProcCd != customerInfo2.SalesMoneyFrcProcCd ) resList.Add( "SalesMoneyFrcProcCd" );
            if ( customerInfo1.SalesCnsTaxFrcProcCd != customerInfo2.SalesCnsTaxFrcProcCd ) resList.Add( "SalesCnsTaxFrcProcCd" );
            if ( customerInfo1.CustomerSlipNoDiv != customerInfo2.CustomerSlipNoDiv ) resList.Add( "CustomerSlipNoDiv" );
            if ( customerInfo1.NTimeCalcStDate != customerInfo2.NTimeCalcStDate ) resList.Add( "NTimeCalcStDate" );
            if ( customerInfo1.CustomerAgent != customerInfo2.CustomerAgent ) resList.Add( "CustomerAgent" );
            if ( customerInfo1.ClaimSectionCode != customerInfo2.ClaimSectionCode ) resList.Add( "ClaimSectionCode" );
            if ( customerInfo1.CarMngDivCd != customerInfo2.CarMngDivCd ) resList.Add( "CarMngDivCd" );
            if ( customerInfo1.BillPartsNoPrtCd != customerInfo2.BillPartsNoPrtCd ) resList.Add( "BillPartsNoPrtCd" );
            if ( customerInfo1.DeliPartsNoPrtCd != customerInfo2.DeliPartsNoPrtCd ) resList.Add( "DeliPartsNoPrtCd" );
            if ( customerInfo1.DefSalesSlipCd != customerInfo2.DefSalesSlipCd ) resList.Add( "DefSalesSlipCd" );
            if ( customerInfo1.LavorRateRank != customerInfo2.LavorRateRank ) resList.Add( "LavorRateRank" );
            if ( customerInfo1.SlipTtlPrn != customerInfo2.SlipTtlPrn ) resList.Add( "SlipTtlPrn" );
            if ( customerInfo1.DepoBankCode != customerInfo2.DepoBankCode ) resList.Add( "DepoBankCode" );
            if ( customerInfo1.CustWarehouseCd != customerInfo2.CustWarehouseCd ) resList.Add( "CustWarehouseCd" );
            if ( customerInfo1.QrcodePrtCd != customerInfo2.QrcodePrtCd ) resList.Add( "QrcodePrtCd" );
            if ( customerInfo1.DeliHonorificTtl != customerInfo2.DeliHonorificTtl ) resList.Add( "DeliHonorificTtl" );
            if ( customerInfo1.BillHonorificTtl != customerInfo2.BillHonorificTtl ) resList.Add( "BillHonorificTtl" );
            if ( customerInfo1.EstmHonorificTtl != customerInfo2.EstmHonorificTtl ) resList.Add( "EstmHonorificTtl" );
            if ( customerInfo1.RectHonorificTtl != customerInfo2.RectHonorificTtl ) resList.Add( "RectHonorificTtl" );
            if ( customerInfo1.DeliHonorTtlPrtDiv != customerInfo2.DeliHonorTtlPrtDiv ) resList.Add( "DeliHonorTtlPrtDiv" );
            if ( customerInfo1.BillHonorTtlPrtDiv != customerInfo2.BillHonorTtlPrtDiv ) resList.Add( "BillHonorTtlPrtDiv" );
            if ( customerInfo1.EstmHonorTtlPrtDiv != customerInfo2.EstmHonorTtlPrtDiv ) resList.Add( "EstmHonorTtlPrtDiv" );
            if ( customerInfo1.RectHonorTtlPrtDiv != customerInfo2.RectHonorTtlPrtDiv ) resList.Add( "RectHonorTtlPrtDiv" );
            if ( customerInfo1.Note1 != customerInfo2.Note1 ) resList.Add( "Note1" );
            if ( customerInfo1.Note2 != customerInfo2.Note2 ) resList.Add( "Note2" );
            if ( customerInfo1.Note3 != customerInfo2.Note3 ) resList.Add( "Note3" );
            if ( customerInfo1.Note4 != customerInfo2.Note4 ) resList.Add( "Note4" );
            if ( customerInfo1.Note5 != customerInfo2.Note5 ) resList.Add( "Note5" );
            if ( customerInfo1.Note6 != customerInfo2.Note6 ) resList.Add( "Note6" );
            if ( customerInfo1.Note7 != customerInfo2.Note7 ) resList.Add( "Note7" );
            if ( customerInfo1.Note8 != customerInfo2.Note8 ) resList.Add( "Note8" );
            if ( customerInfo1.Note9 != customerInfo2.Note9 ) resList.Add( "Note9" );
            if ( customerInfo1.Note10 != customerInfo2.Note10 ) resList.Add( "Note10" );
            if ( customerInfo1.SalesAreaName != customerInfo2.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( customerInfo1.ClaimName != customerInfo2.ClaimName ) resList.Add( "ClaimName" );
            if ( customerInfo1.ClaimName2 != customerInfo2.ClaimName2 ) resList.Add( "ClaimName2" );
            if ( customerInfo1.ClaimSnm != customerInfo2.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( customerInfo1.CustomerAgentNm != customerInfo2.CustomerAgentNm ) resList.Add( "CustomerAgentNm" );
            if ( customerInfo1.OldCustomerAgentNm != customerInfo2.OldCustomerAgentNm ) resList.Add( "OldCustomerAgentNm" );
            if ( customerInfo1.ClaimSectionName != customerInfo2.ClaimSectionName ) resList.Add( "ClaimSectionName" );
            if ( customerInfo1.DepoBankName != customerInfo2.DepoBankName ) resList.Add( "DepoBankName" );
            if ( customerInfo1.CustWarehouseName != customerInfo2.CustWarehouseName ) resList.Add( "CustWarehouseName" );
            if ( customerInfo1.MngSectionName != customerInfo2.MngSectionName ) resList.Add( "MngSectionName" );
            if ( customerInfo1.EnterpriseName != customerInfo2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( customerInfo1.UpdEmployeeName != customerInfo2.UpdEmployeeName ) resList.Add( "UpdEmployeeName" );
            if ( customerInfo1.JobTypeName != customerInfo2.JobTypeName ) resList.Add( "JobTypeName" );
            if ( customerInfo1.BusinessTypeName != customerInfo2.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( customerInfo1.InpSectionName != customerInfo2.InpSectionName ) resList.Add( "InpSectionName" );
            if ( customerInfo1.BillOutPutCodeNm != customerInfo2.BillOutPutCodeNm ) resList.Add( "BillOutPutCodeNm" );
            if (customerInfo1.BillCollecterNm != customerInfo2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (customerInfo1.SalesSlipPrtDiv != customerInfo2.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (customerInfo1.AcpOdrrSlipPrtDiv != customerInfo2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (customerInfo1.ShipmSlipPrtDiv != customerInfo2.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (customerInfo1.EstimatePrtDiv != customerInfo2.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (customerInfo1.UOESlipPrtDiv != customerInfo2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (customerInfo1.ReceiptOutputCode != customerInfo2.ReceiptOutputCode) resList.Add("ReceiptOutputCode");
            // ADD 2009/06/03 ------>>>
            if (customerInfo1.CustomerEpCode != customerInfo2.CustomerEpCode) resList.Add("CustomerEpCode");
            if (customerInfo1.CustomerSecCode != customerInfo2.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ---------->>>>>
            if (customerInfo1.SimplInqAcntAcntGrId != customerInfo2.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM�F�ȒP�⍇���A�J�E���g�O���[�vID��ǉ� ----------<<<<<
            if (customerInfo1.OnlineKindDiv != customerInfo2.OnlineKindDiv) resList.Add("OnlineKindDiv");
            // ADD 2009/06/03 ------<<<
            // --- ADD  ���r��  2010/01/04 ---------->>>>>
            if (customerInfo1.TotalBillOutputDiv != customerInfo2.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (customerInfo1.DetailBillOutputCode != customerInfo2.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (customerInfo1.SlipTtlBillOutputDiv != customerInfo2.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");
            // --- ADD  ���r��  2010/01/04 ----------<<<<<
            // ADD �� K2014/02/06--------------------------->>>>>
            if (customerInfo1.NoteInfo != customerInfo2.NoteInfo) resList.Add("NoteInfo");
            // ADD �� K2014/02/06---------------------------<<<<<
            // ADD ���J �M�m 2021/05/10 ------------------------------>>>>>>
            if (customerInfo1.DisplayDivCode != customerInfo2.DisplayDivCode) resList.Add("DisplayDivCode");
            // ADD ���J �M�m 2021/05/10 ------------------------------<<<<<<
            return resList;
        }
        # endregion

        # region [public���\�b�h�i�蓮�ǉ��j]
        /// <summary>
        /// �������̎擾����
        /// </summary>
        /// <param name="outputNameCode">�����R�[�h</param>
        /// <returns>��������</returns>
        public static string GetOutputName( int outputNameCode )
        {
            switch ( outputNameCode )
            {
                case 0:
                    {
                        return CST_OutputName_0;
                    }
                case 1:
                    {
                        return CST_OutputName_1;
                    }
                case 2:
                    {
                        return CST_OutputName_2;
                    }
                case 3:
                    {
                        return CST_OutputName_3;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// �W�����敪���̎擾����
        /// </summary>
        /// <param name="collectMoneyCode">�W�����敪�R�[�h</param>
        /// <returns>�W�����敪����</returns>
        public static string GetCollectMoneyName( int collectMoneyCode )
        {
            switch ( collectMoneyCode )
            {
                case 0:
                    {
                        return CST_CollectMoneyName_0;
                    }
                case 1:
                    {
                        return CST_CollectMoneyName_1;
                    }
                case 2:
                    {
                        return CST_CollectMoneyName_2;
                    }
                case 3:
                    {
                        return CST_CollectMoneyName_3;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// �l�E�@�l�敪���̎擾����
        /// </summary>
        /// <param name="corporateDivCode">�l�E�@�l�敪</param>
        /// <returns>�l�E�@�l�敪����</returns>
        public static string GetPrslOrCorpDivNm( int corporateDivCode )
        {
            switch ( corporateDivCode )
            {
                case 0:
                    {
                        return CST_CorporateDivName_0;
                    }
                case 1:
                    {
                        return CST_CorporateDivName_1;
                    }
                case 2:
                    {
                        return CST_CorporateDivName_2;
                    }
                case 3:
                    {
                        return CST_CorporateDivName_3;
                    }
                case 4:
                    {
                        return CST_CorporateDivName_4;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// �������o�͋敪���̎擾����
        /// </summary>
        /// <param name="billOutputCode">�������o�͋敪�R�[�h</param>
        /// <returns>�������o�͋敪����</returns>
        public static string GetBillOutputName( int billOutputCode )
        {
            switch ( billOutputCode )
            {
                case 0:
                    {
                        return CST_BillOutputName_0;
                    }
                case 1:
                    {
                        return CST_BillOutputName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// DM�o�͋敪���̎擾����
        /// </summary>
        /// <param name="dmOutCode">DM�o�͋敪</param>
        /// <returns>DM�o�͋敪����</returns>
        public static string GetDmOutName( int dmOutCode )
        {
            switch ( dmOutCode )
            {
                case 0:
                    {
                        return CST_DmOutName_0;
                    }
                case 1:
                    {
                        return CST_DmOutName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// ����œ]�ŕ������̎擾����
        /// </summary>
        /// <param name="consTaxLayMethod">����œ]�ŕ����敪</param>
        /// <returns>����œ]�ŕ�������</returns>
        public static string GetConsTaxLayMethodName( int consTaxLayMethod )
        {
            switch ( consTaxLayMethod )
            {
                case 0:
                    {
                        return CST_ConsTaxLayMethod_0;
                    }
                case 1:
                    {
                        return CST_ConsTaxLayMethod_1;
                    }
                case 2:
                    {
                        return CST_ConsTaxLayMethod_2;
                    }
                case 3:
                    {
                        return CST_ConsTaxLayMethod_3;
                    }
                case 9:
                    {
                        return CST_ConsTaxLayMethod_9;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// ���z�\�����@�敪���̎擾����
        /// </summary>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <returns>���z�\�����@�敪����</returns>
        public static string GetTotalAmountDispWayCdName( int totalAmountDispWayCd )
        {
            switch ( totalAmountDispWayCd )
            {
                case 0:
                    {
                        return CST_TotalAmountDispWayCd_0;
                    }
                case 1:
                    {
                        return CST_TotalAmountDispWayCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// ���z�\�����@�Q�Ƌ敪���̎擾����
        /// </summary>
        /// <param name="totalAmntDspWayRef">���z�\�����@�Q�Ƌ敪</param>
        /// <returns>���z�\�����@�Q�Ƌ敪����</returns>
        public static string GetTotalAmntDspWayRefName( int totalAmntDspWayRef )
        {
            switch ( totalAmntDspWayRef )
            {
                case 0:
                    {
                        return CST_TotalAmntDspWayRef_0;
                    }
                case 1:
                    {
                        return CST_TotalAmntDspWayRef_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// ���Ӑ����œ]�ŕ����Q�Ƌ敪 ���̎擾����
        /// </summary>
        /// <param name="CustCTaXLayRefCd">���Ӑ����œ]�ŕ����Q�Ƌ敪</param>
        /// <returns>���Ӑ����œ]�ŕ����Q�Ƌ敪 ����</returns>
        public static string GetCustCTaXLayRefCdName( int CustCTaXLayRefCd )
        {
            switch ( CustCTaXLayRefCd )
            {
                case 0:
                    {
                        return CST_CustCTaXLayRefCd_0;
                    }
                case 1:
                    {
                        return CST_CustCTaXLayRefCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// ��A����敪���̎擾����
        /// </summary>
        /// <param name="mainContactCode">��A����敪</param>
        /// <returns>��A����敪����</returns>
        public string GetMainContactName( int mainContactCode )
        {
            return GetMainContactName( mainContactCode, 0 );
        }

        /// <summary>
        /// ��A����敪���̎擾����
        /// </summary>
        /// <param name="mainContactCode">��A����敪</param>
        /// <param name="mode">0:�ʏ� 1:����</param>
        /// <returns>��A����敪����</returns>
        public string GetMainContactName( int mainContactCode, int mode )
        {
            switch ( mainContactCode )
            {
                case 0:
                    {
                        return this.HomeTelNoDspName;
                    }
                case 1:
                    {
                        return this.OfficeTelNoDspName;
                    }
                case 2:
                    {
                        return this.MobileTelNoDspName;
                    }
                case 3:
                    {
                        return this.HomeFaxNoDspName;
                    }
                case 4:
                    {
                        return this.OfficeFaxNoDspName;
                    }
                case 5:
                    {
                        return this.OtherTelNoDspName;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// ���[�����M�敪���̎擾����
        /// </summary>
        /// <param name="mailSendCode">���[�����M�敪�R�[�h</param>
        /// <returns>���[�����M�敪����</returns>
        public static string GetMailSendName( int mailSendCode )
        {
            switch ( mailSendCode )
            {
                case 0:
                    {
                        return CST_MailSendName_0;
                    }
                case 1:
                    {
                        return CST_MailSendName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// ���[���A�h���X��ʖ��̎擾����
        /// </summary>
        /// <param name="mailAddrKindCode">���[���A�h���X��ʃR�[�h</param>
        /// <returns>���[���A�h���X��ʖ���</returns>
        public static string GetMailAddrKindName( int mailAddrKindCode )
        {
            switch ( mailAddrKindCode )
            {
                case 0:
                    {
                        return CST_MailAddrKindName_0;
                    }
                case 1:
                    {
                        return CST_MailAddrKindName_1;
                    }
                case 2:
                    {
                        return CST_MailAddrKindName_2;
                    }
                case 3:
                    {
                        return CST_MailAddrKindName_3;
                    }
                case 99:
                    {
                        return CST_MailAddrKindName_99;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>���Ӑ摮���敪���̎擾����</summary>
        /// <param name="CustomerAttributeDiv">���Ӑ摮���敪�l</param>
        /// <returns>����</returns>
        public static string GetCustomerAttributeDivName( int CustomerAttributeDiv )
        {
            switch ( CustomerAttributeDiv )
            {
                case 0:
                    {
                        return CST_CustomerAttributeDiv_0;
                    }
                case 8:
                    {
                        return CST_CustomerAttributeDiv_8;
                    }
                case 9:
                    {
                        return CST_CustomerAttributeDiv_9;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>���Ӑ��ʋ敪���̎擾����</summary>
        /// <param name="CustomerDivCd">���Ӑ��ʋ敪</param>
        /// <returns>����</returns>
        public static string GetCustomerDivCdName( int CustomerDivCd )
        {
            switch ( CustomerDivCd )
            {
                case 0:
                    {
                        return CST_CustomerDivCd_0;
                    }
                case 1:
                    {
                        return CST_CustomerDivCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>����������̎擾����</summary>
        /// <param name="CollectCond">��������l</param>
        /// <returns>����</returns>
        public static string GetCollectCondName( int CollectCond )
        {
            switch ( CollectCond )
            {
                case 10:
                    {
                        return CST_CollectCond_10;
                    }
                case 20:
                    {
                        return CST_CollectCond_20;
                    }
                case 30:
                    {
                        return CST_CollectCond_30;
                    }
                case 40:
                    {
                        return CST_CollectCond_40;
                    }
                case 50:
                    {
                        return CST_CollectCond_50;
                    }
                case 60:
                    {
                        return CST_CollectCond_60;
                    }
                case 70:
                    {
                        return CST_CollectCond_70;
                    }
                case 80:
                    {
                        return CST_CollectCond_80;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>�^�M�Ǘ��敪���̎擾����</summary>
        /// <param name="CreditMngCode">�^�M�Ǘ��敪�l</param>
        /// <returns>����</returns>
        public static string GetCreditMngCodeName( int CreditMngCode )
        {
            switch ( CreditMngCode )
            {
                case 0:
                    {
                        return CST_CreditMngCode_0;
                    }
                case 1:
                    {
                        return CST_CreditMngCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>���������敪���̎擾����</summary>
        /// <param name="DepoDelCode">���������敪�l</param>
        /// <returns>����</returns>
        public static string GetDepoDelCodeName( int DepoDelCode )
        {
            switch ( DepoDelCode )
            {
                case 0:
                    {
                        return CST_DepoDelCode_0;
                    }
                case 1:
                    {
                        return CST_DepoDelCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>���|�敪���̎擾����</summary>
        /// <param name="AccRecDivCd">���|�敪�l</param>
        /// <returns>����</returns>
        public static string GetAccRecDivCdName( int AccRecDivCd )
        {
            switch ( AccRecDivCd )
            {
                case 0:
                    {
                        return CST_AccRecDivCd_0;
                    }
                case 1:
                    {
                        return CST_AccRecDivCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>�����敪���̎擾����</summary>
        /// <param name="EraNameCode">�����敪�l</param>
        /// <returns>����</returns>
        public static string GetEraNameCodeName( int EraNameCode )
        {
            switch ( EraNameCode )
            {
                case 0:
                    {
                        return CST_EraNameCode_0;
                    }
                case 1:
                    {
                        return CST_EraNameCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>����`�[�ԍ��Ǘ��敪���̎擾����</summary>
        /// <param name="CustSlipNoMngCd">����`�[�ԍ��Ǘ��敪�l</param>
        /// <returns>����</returns>
        public static string GetCustSlipNoMngCdName( int CustSlipNoMngCd )
        {
            switch ( CustSlipNoMngCd )
            {
                case 0:
                    {
                        return CST_CustSlipNoMngCd_0;
                    }
                case 1:
                    {
                        return CST_CustSlipNoMngCd_1;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
                case 2:
                    {
                        return CST_CustSlipNoMngCd_2;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        ///// <summary>�����敪���̎擾����</summary>
        ///// <param name="PureCode">�����敪�l</param>
        ///// <returns>����</returns>
        //public static string GetPureCodeName( int PureCode )
        //{
        //    switch ( PureCode )
        //    {
        //        case 0:
        //            {
        //                return CST_PureCode_0;
        //            }
        //        case 1:
        //            {
        //                return CST_PureCode_1;
        //            }
        //        default:
        //            {
        //                return string.Empty;
        //            }
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
        /// <summary>���Ӑ�`�[�ԍ��敪���̎擾����</summary>
        /// <param name="CusotomerSlipNoDiv">���Ӑ�`�[�ԍ��敪</param>
        /// <returns>����</returns>
        public static string GetCustomerSlipNoDivName( int CusotomerSlipNoDiv )
        {
            switch ( CusotomerSlipNoDiv )
            {
                case 0:
                    {
                        return CST_CustomerSlipNoDiv_0;
                    }
                case 1:
                    {
                        return CST_CustomerSlipNoDiv_1;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
                case 2:
                    {
                        return CST_CustomerSlipNoDiv_2;
                    }
                case 3:
                    {
                        return CST_CustomerSlipNoDiv_3;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// �̎����o�͋敪���̎擾����
        /// </summary>
        /// <param name="receiptOutputCode">�̎����o�͋敪�R�[�h</param>
        /// <returns>�̎����o�͋敪����</returns>
        public static string GetReceiptOutputName(int receiptOutputCode)
        {
            switch (receiptOutputCode)
            {
                case 0:
                    {
                        return CST_ReceiptOutputCode_0;
                    }
                case 1:
                    {
                        return CST_ReceiptOutputCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// �I�����C����ʋ敪���̎擾����
        /// </summary>
        /// <param name="onlineKindDiv">�I�����C����ʋ敪</param>
        /// <returns>�I�����C����ʋ敪����</returns>
        public static string GetOnlineKindDivName(int onlineKindDiv)
        {
            switch (onlineKindDiv)
            {
                case 0:
                    {
                        return CST_OnlineKindDiv_0;
                    }
                case 10:
                    {
                        return CST_OnlineKindDiv_10;
                    }
                case 20:
                    {
                        return CST_OnlineKindDiv_20;
                    }
                case 30:
                    {
                        return CST_OnlineKindDiv_30;
                    }
                case 40:
                    {
                        return CST_OnlineKindDiv_40;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // --- ADD  ���r��  2010/01/04 ---------->>>>>
        /// <summary>
        /// ���v�������o�͋敪���̎擾����
        /// </summary>
        /// <param name="totalBillOutputDiv">���v�������o�͋敪</param>
        /// <returns>���v�������o�͋敪����</returns>
        public static string GetTotalBillOutputDiv(int totalBillOutputDiv)
        {
            switch (totalBillOutputDiv)
            {
                case 0:
                    {
                        return CST_TotalBillOutputDiv_0;
                    }
                case 1:
                    {
                        return CST_TotalBillOutputDiv_1;
                    }
                case 2:
                    {
                        return CST_TotalBillOutputDiv_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// ���א������o�͋敪�擾����
        /// </summary>
        /// <param name="detailBillOutputCode">���א������o�͋敪</param>
        /// <returns>���א������o�͋敪����</returns>  
        public static string GetDetailBillOutputCode(int detailBillOutputCode)
        {
            switch (detailBillOutputCode)
            {
                case 0:
                    {
                        return CST_DetailBillOutputCode_0;
                    }
                case 1:
                    {
                        return CST_DetailBillOutputCode_1;
                    }
                case 2:
                    {
                        return CST_DetailBillOutputCode_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// �`�[���v�������o�͋敪���̎擾����
        /// </summary>
        /// <param name="slipTtlBillOutputDiv">�`�[���v�������o�͋敪</param>
        /// <returns>�`�[���v�������o�͋敪����</returns>
        public static string GetSlipTtlBillOutputDiv(int slipTtlBillOutputDiv)
        {
            switch (slipTtlBillOutputDiv)
            {
                case 0:
                    {
                        return CST_SlipTtlBillOutputDiv_0;
                    }
                case 1:
                    {
                        return CST_SlipTtlBillOutputDiv_1;
                    }
                case 2:
                    {
                        return CST_SlipTtlBillOutputDiv_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // --- ADD  ���r��  2010/01/04 ----------<<<<<
        # endregion
    }
}

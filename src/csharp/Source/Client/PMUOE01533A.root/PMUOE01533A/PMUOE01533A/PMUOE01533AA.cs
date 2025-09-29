//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �O�H��������
// �v���O�����T�v   : �O�H�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : gaoyh
// �� �� ��  2010/04/20  �C�����e : �V�K�쐬
//                                  �O�HWeb-UOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����O�HWeb-UOE�p�V�X�e���A�g�t�@�C���̍쐬���s��
// �Ǘ��ԍ�              �쐬�S�� : gaoyh
// �� �� ��  2010/05/07  �C�����e : #7086 �����\���̃`�F�b�N
// �Ǘ��ԍ�              �쐬�S�� : gaoyh
// �� �� ��  2010/05/18  �C�����e : #7591 �O�H�������� �t�@�C���̑��݃`�F�b�N�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ������
// �C �� ��  2010/12/31  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ������
// �C �� ��  2011/01/13  �C�����e : UOE����������redmine:#18531
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;           // ADD 2010/12/31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �O�H���������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�H���������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : gaoyh</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br>UpdateNote : 2010/12/31 ������ UOE����������</br>
    /// <br>UpdateNote : 2011/01/13 ������ UOE����������redmine:#18531</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// </remarks>
    public partial class MitsubishiOrderProcAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2010/12/31

        //�A�N�Z�X�N���X
        private static MitsubishiOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //�f�[�^�[�e�[�u��
        private MitsubishiOrderProcDataSet _dataSet;
        private MitsubishiOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //�]�ƈ��}�X�^
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // �]�ƈ���� �A�N�Z�X�N���X

        //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        //private int setCount = 0; // DEL 2010/05/07

        // �t�@�C���i�X�g���[���j
        private FileStream _uoeFileStream = null;
        # endregion

        #region ASATOUOEXMLEditOrder
        /// <summary>
        /// �O�HWebUOE�p�����A�g�t�@�C��(����)�쐬
        /// </summary>
        private class ASATOUOTXMLEditOrder
        {
            #region const member
            private const string ROOT = "CAPS_INFO";            // �J�n
            private const string ELEMENT_VIN = "VIN";            // ���No.
            private const string ELEMENT_SPC_MODEL = "SPC_MODEL";            // �^���w��ԍ�(�^�^)
            private const string ELEMENT_MODEL = "MODEL";            // �^��
            private const string ELEMENT_CLAS = "CLAS";            // �ޕ�
            private const string ELEMENT_OPC = "OPC";            // �~��
            private const string ELEMENT_EXT = "EXT";            // �O��
            private const string ELEMENT_INT = "INT";            // ����
            private const string ELEMENT_PD1 = "PD1";            // ���q���Y�����͈́i����j
            private const string ELEMENT_PD2 = "PD2";            // ���q���Y�����͈́i�܂Łj
            private const string ELEMENT_TODAY = "TODAY";            // �쐬�N����
            private const string ELEMENT_TIME = "TIME";            // �쐬����
            private const string ELEMENT_PGM_VER = "PGM_VER";            // ��۸����ް�ޮ�
            private const string ELEMENT_TOTAL_PRICE = "TOTAL_PRICE";            // ���v���z
            private const string ELEMENT_NUMBER_OF_PARTS = "NUMBER_OF_PARTS";            // ���i����

            private const string ELEMENT_PARTS_INFO = "PARTS_INFO";            // ���i���
            private const string ELEMENT_LINE_NO = "LINE_NO";            // ײ�No.
            private const string ELEMENT_PNC = "PNC";            // �i������
            private const string ELEMENT_PART_QTY = "PART_QTY";            // ����
            private const string ELEMENT_PART_NO = "PART_NO";            // ���i�ԍ�
            private const string ELEMENT_PART_NAME = "PART_NAME";            // ���i����
            private const string ELEMENT_QTY = "QTY";            // ��
            private const string ELEMENT_PART_UNIT_PRICE = "PART_UNIT_PRICE";            // �P��
            private const string ELEMENT_PART_SPEC = "PART_SPEC";            // �ŗL���i�ҏW�j
            private const string ELEMENT_PART_REMARK = "PART_REMARK";            // �ŗL���i���l�j
            private const string ELEMENT_PART_COLOR = "PART_COLOR";            // �ŗL���i�F�j
            private const string ELEMENT_RPN = "RPN";            // ��֕���
            private const string ELEMENT_RPN_PRICE = "RPN_PRICE";            // ��)�P��
            private const string ELEMENT_RPN_SPEC = "RPN_SPEC";            // ��)�ŗL���i�ҏW�j
            private const string ELEMENT_RPN_REMARK = "RPN_REMARK";            // ��)�ŗL���i���l�j
            private const string ELEMENT_RPN_COLOR = "RPN_COLOR";            // ��)�ŗL���i�F�j

            // �ő喾�א�
            private const int ctDetailLen = 999;
            #endregion

            # region Private Members
            // 
            private XmlWriter xmlWriter;
            //�ϐ�
            private Int32 _ln = 0;
            private byte[] remark = new byte[10];
            # endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// <param name="fileStream">�t�@�C���i�X�g���[���j</param>
            /// </summary>
            public ASATOUOTXMLEditOrder(FileStream fileStream)
            {
                // Settings
                XmlWriterSettings xmlSetting = new XmlWriterSettings();
                xmlSetting.Encoding = Encoding.GetEncoding(932); // Shift-JS
                xmlSetting.Indent = true;
                xmlSetting.IndentChars = ("  ");
                xmlSetting.OmitXmlDeclaration = false;

                xmlWriter = XmlWriter.Create(fileStream, xmlSetting);
            }

            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            public void NodeWrite(UOEOrderDtlWork work)
            {
                // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                UoeCommonFnc.MemCopy(ref remark, work.UoeRemark2, remark.Length);
                // �w�b�_�[���쐬
                if (_ln == 0)
                {
                    xmlWriter.WriteStartDocument();
                    // ROOT
                    xmlWriter.WriteStartElement(ROOT);            // �J�n

                    # region <�w�b�_�[��>
                    xmlWriter.WriteStartElement(ELEMENT_VIN);            // ���No.
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_SPC_MODEL);            // �^���w��ԍ�(�^�^)
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_MODEL, System.Text.Encoding.Default.GetString(remark));            // �^��
                    xmlWriter.WriteStartElement(ELEMENT_CLAS);            // �ޕ�
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_OPC);            // �~��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_EXT);            // �O��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_INT);            // ����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD1);            // ���q���Y�����͈́i����j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD2);            // ���q���Y�����͈́i�܂Łj
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TODAY);            // �쐬�N����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TIME);            // �쐬����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PGM_VER);            // ��۸����ް�ޮ�
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TOTAL_PRICE);            // ���v���z
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_NUMBER_OF_PARTS);            // ���i����
                    xmlWriter.WriteFullEndElement();
                    # endregion
                }

                # region <���ו�>
                if (_ln < ctDetailLen)
                {
                    xmlWriter.WriteStartElement(ELEMENT_PARTS_INFO);            // ���i���(�J�n)
                    xmlWriter.WriteElementString(ELEMENT_LINE_NO, String.Format("{0:D3}", work.OnlineRowNo));            // ײ�No.
                    xmlWriter.WriteStartElement(ELEMENT_PNC);            // �i������
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_PART_QTY, Convert.ToString(work.AcceptAnOrderCnt));            // ����
                    xmlWriter.WriteElementString(ELEMENT_PART_NO, work.GoodsNoNoneHyphen);            // ���i�ԍ�
                    xmlWriter.WriteStartElement(ELEMENT_PART_NAME);            // ���i����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_QTY);            // ��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_UNIT_PRICE);            // �P��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_SPEC);            // �ŗL���i�ҏW�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_REMARK);            // �ŗL���i���l�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_COLOR);            // �ŗL���i�F�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN);            // ��֕���
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_PRICE);            // ��)�P��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_SPEC);            // ��)�ŗL���i�ҏW�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_REMARK);            // ��)�ŗL���i���l�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_COLOR);            // ��)�ŗL���i�F�j
                    xmlWriter.WriteFullEndElement();

                    xmlWriter.WriteFullEndElement();                                    // ���i���(�I��)

                    _ln++;
                }
                # endregion
            }

            # region <�t�@�C���I��>
            /// <summary>
            /// �t�@�C���I������
            /// </summary>
            public void FileEnd()
            {
                // Write The Close Tag for the Root element
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Flush();
                xmlWriter.Close();
            }
            # endregion
            # endregion
        }
        #endregion

        // --------ADD 2010/12/31--------->>>>>
        #region AutoASATOUOEXMLEditOrder
        /// <summary>
        /// �O�HWebUOE�p�����A�g�t�@�C��(����)�쐬(����)
        /// </summary>
        private class AutoASATOUOEXMLEditOrder
        {
            #region const member
            private const string ROOT = "CAPS_INFO";            // �J�n
            private const string ELEMENT_VIN = "VIN";            // ���No.
            private const string ELEMENT_SPC_MODEL = "SPC_MODEL";            // �^���w��ԍ�(�^�^)
            private const string ELEMENT_MODEL = "MODEL";            // �^��
            private const string ELEMENT_CLAS = "CLAS";            // �ޕ�
            private const string ELEMENT_OPC = "OPC";            // �~��
            private const string ELEMENT_EXT = "EXT";            // �O��
            private const string ELEMENT_INT = "INT";            // ����
            private const string ELEMENT_PD1 = "PD1";            // ���q���Y�����͈́i����j
            private const string ELEMENT_PD2 = "PD2";            // ���q���Y�����͈́i�܂Łj
            private const string ELEMENT_TODAY = "TODAY";            // �쐬�N����
            private const string ELEMENT_TIME = "TIME";            // �쐬����
            private const string ELEMENT_PGM_VER = "PGM_VER";            // ��۸����ް�ޮ�
            private const string ELEMENT_TOTAL_PRICE = "TOTAL_PRICE";            // ���v���z
            private const string ELEMENT_NUMBER_OF_PARTS = "NUMBER_OF_PARTS";            // ���i����

            private const string ELEMENT_PARTS_INFO = "PARTS_INFO";            // ���i���
            private const string ELEMENT_LINE_NO = "LINE_NO";            // ײ�No.
            private const string ELEMENT_PNC = "PNC";            // �i������
            private const string ELEMENT_PART_QTY = "PART_QTY";            // ����
            private const string ELEMENT_PART_NO = "PART_NO";            // ���i�ԍ�
            private const string ELEMENT_PART_NAME = "PART_NAME";            // ���i����
            private const string ELEMENT_QTY = "QTY";            // ��
            private const string ELEMENT_PART_UNIT_PRICE = "PART_UNIT_PRICE";            // �P��
            private const string ELEMENT_PART_SPEC = "PART_SPEC";            // �ŗL���i�ҏW�j
            private const string ELEMENT_PART_REMARK = "PART_REMARK";            // �ŗL���i���l�j
            private const string ELEMENT_PART_COLOR = "PART_COLOR";            // �ŗL���i�F�j
            private const string ELEMENT_RPN = "RPN";            // ��֕���
            private const string ELEMENT_RPN_PRICE = "RPN_PRICE";            // ��)�P��
            private const string ELEMENT_RPN_SPEC = "RPN_SPEC";            // ��)�ŗL���i�ҏW�j
            private const string ELEMENT_RPN_REMARK = "RPN_REMARK";            // ��)�ŗL���i���l�j
            private const string ELEMENT_RPN_COLOR = "RPN_COLOR";            // ��)�ŗL���i�F�j

            // �ő喾�א�
            private const int ctDetailLen = 999;
            #endregion

            # region Private Members
            // 
            private XmlWriter xmlWriter;
            //�ϐ�
            private Int32 _ln = 0;
            private byte[] remark;
            # endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// <param name="fileStream">�t�@�C���i�X�g���[���j</param>
            /// </summary>
            public AutoASATOUOEXMLEditOrder(FileStream fileStream)
            {
                // Settings
                XmlWriterSettings xmlSetting = new XmlWriterSettings();
                xmlSetting.Encoding = Encoding.GetEncoding(932); // Shift-JS
                xmlSetting.Indent = true;
                xmlSetting.IndentChars = ("  ");
                xmlSetting.OmitXmlDeclaration = false;

                xmlWriter = XmlWriter.Create(fileStream, xmlSetting);
            }

            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            public void NodeWrite(UOEOrderDtlWork work)
            {
                if (!work.UoeRemark1.Trim().Equals(string.Empty))
                {
                    remark = new byte[work.UoeRemark1.Length];
                    // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark1, remark.Length);
                }
                else
                {
                    //�Ȃ��B
                }
                // �w�b�_�[���쐬
                if (_ln == 0)
                {
                    xmlWriter.WriteStartDocument();
                    // ROOT
                    xmlWriter.WriteStartElement(ROOT);            // �J�n

                    # region <�w�b�_�[��>
                    xmlWriter.WriteStartElement(ELEMENT_VIN);            // ���No.
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_SPC_MODEL);            // �^���w��ԍ�(�^�^)
                    xmlWriter.WriteFullEndElement();
                    if (!work.UoeRemark1.Trim().Equals(string.Empty))
                    {
                        xmlWriter.WriteElementString(ELEMENT_MODEL, System.Text.Encoding.Default.GetString(remark));            // �^��
                    }
                    else
                    {
                        xmlWriter.WriteStartElement(ELEMENT_MODEL);            // �^��
                        xmlWriter.WriteFullEndElement();
                    }
                    xmlWriter.WriteStartElement(ELEMENT_CLAS);            // �ޕ�
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_OPC);            // �~��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_EXT);            // �O��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_INT);            // ����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD1);            // ���q���Y�����͈́i����j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD2);            // ���q���Y�����͈́i�܂Łj
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TODAY);            // �쐬�N����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TIME);            // �쐬����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PGM_VER);            // ��۸����ް�ޮ�
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TOTAL_PRICE);            // ���v���z
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_NUMBER_OF_PARTS);            // ���i����
                    xmlWriter.WriteFullEndElement();
                    # endregion
                }

                # region <���ו�>
                if (_ln < ctDetailLen)
                {
                    xmlWriter.WriteStartElement(ELEMENT_PARTS_INFO);            // ���i���(�J�n)
                    xmlWriter.WriteElementString(ELEMENT_LINE_NO, String.Format("{0:D3}", work.OnlineRowNo));            // ײ�No.
                    xmlWriter.WriteStartElement(ELEMENT_PNC);            // �i������
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_PART_QTY, Convert.ToString(work.AcceptAnOrderCnt));            // ����
                    xmlWriter.WriteElementString(ELEMENT_PART_NO, work.GoodsNoNoneHyphen);            // ���i�ԍ�
                    xmlWriter.WriteStartElement(ELEMENT_PART_NAME);            // ���i����
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_QTY);            // ��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_UNIT_PRICE);            // �P��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_SPEC);            // �ŗL���i�ҏW�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_REMARK);            // �ŗL���i���l�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_COLOR);            // �ŗL���i�F�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN);            // ��֕���
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_PRICE);            // ��)�P��
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_SPEC);            // ��)�ŗL���i�ҏW�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_REMARK);            // ��)�ŗL���i���l�j
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_COLOR);            // ��)�ŗL���i�F�j
                    xmlWriter.WriteFullEndElement();

                    xmlWriter.WriteFullEndElement();                                    // ���i���(�I��)

                    _ln++;
                }
                # endregion
            }

            # region <�t�@�C���I��>
            /// <summary>
            /// �t�@�C���I������
            /// </summary>
            public void FileEnd()
            {
                // Write The Close Tag for the Root element
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Flush();
                xmlWriter.Close();
            }
            # endregion
            # endregion
        }
        #endregion

        #region ASATOUOESubTextEditOrder
        ///// <summary>
        ///// �t�n�d���M�d���쐬���������i�g���^�o�c�S�j
        ///// </summary>
        /// <summary>
        /// ���YWeb-UOE�V�X�e���A�g�t�@�C��(����)�쐬
        /// </summary>
        private class ASATOUOESubTextEditOrder
        {
            #region Private Members
            //�T�u�����d��
            private byte[] subRemark = new byte[15];		/*      	 �T�u�R�����g         */
            private byte[] subDeliGoodsDiv = new byte[1];		/*           �T�u�[�i�敪            */
            private byte[][] subBoCode = null;		/*      	 �T�uBO�敪         */
            private int boCodeLength;

            #endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public ASATOUOESubTextEditOrder(int boCodeLen)
            {
                subBoCode = new byte[boCodeLen][];
                boCodeLength = boCodeLen;
                for (int i = 0; i < boCodeLength; i++)
                {
                    subBoCode[i] = new byte[1];	// ���i�ԍ�
                }
                Clear();
            }
            # endregion

            # region Public Methods
            # region �f�[�^����������
            /// <summary>
            /// �f�[�^����������
            /// </summary>
            public void Clear()
            {
                // ���ו�
                UoeCommonFnc.MemSet(ref subRemark, 0x20, subRemark.Length);		// �R�����g
                UoeCommonFnc.MemSet(ref subDeliGoodsDiv, 0x20, subDeliGoodsDiv.Length);		// �[�i�敪
                for (int i = 0; i < boCodeLength; i++)
                {
                    UoeCommonFnc.MemSet(ref subBoCode[i], 0x20, subBoCode[i].Length);	// ���i�ԍ�
                }
            }
            # endregion

            # region �T�u�f�[�^�ҏW����
            /// <summary>
            /// �T�u�f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <param name="page">���[�N</param>
            public void Telegram(UOEOrderDtlWork work, int subBoCodeIndex)
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (subBoCodeIndex == 0)
                {
                    //���w�b�_�[����
                    // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                    UoeCommonFnc.MemCopy(ref subRemark, work.UoeRemark2, subRemark.Length);
                    // �[�i�敪
                    UoeCommonFnc.MemCopy(ref subDeliGoodsDiv, work.UOEDeliGoodsDiv, subDeliGoodsDiv.Length);

                    //�����ו���
                    // BO�敪
                    UoeCommonFnc.MemCopy(ref subBoCode[subBoCodeIndex], work.BoCode, subBoCode[subBoCodeIndex].Length);
                }

                if (subBoCodeIndex > 0)
                {
                    //�����ו���
                    // BO�敪
                    UoeCommonFnc.MemCopy(ref subBoCode[subBoCodeIndex], work.BoCode, subBoCode[subBoCodeIndex].Length);
                }

            }
            # endregion
            # endregion

            # region private Methods
            # region �o�C�g�^�z��ɕϊ�
            /// <summary>
            /// �o�C�g�^�z��ɕϊ�
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //�w�b�_�[��
                ms.Write(subRemark, 0, subRemark.Length);			// �R�����g
                ms.Write(subDeliGoodsDiv, 0, subDeliGoodsDiv.Length);	// �[�i�敪
                //���ו�
                for (int i = 0; i < boCodeLength; i++)
                {
                    ms.Write(subBoCode[i], 0, subBoCode[i].Length);	// BO�敪
                }

                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private MitsubishiOrderProcAcs()
        {
            this.OrderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
        }

        /// <summary>
        /// �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�t�n�d���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public static MitsubishiOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new MitsubishiOrderProcAcs();
            }

            return _supplierAcs;
        }
        # endregion

        #region �f�[�^�ύX�t���O
        /// <summary>�f�[�^�ύX�t���O�v���p�e�B�itrue:�ύX���� false:�ύX�Ȃ��j</summary>
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
            }
        }
        #endregion

        #region �t�@�C���i�X�g���[���j
        /// <summary>UOEfileStream</summary>
        private FileStream UoeFileStream
        {
            get
            {
                return this._uoeFileStream;
            }
            set
            {
                this._uoeFileStream = value;
            }
        }
        #endregion

        # region �]�ƈ��}�X�^�L���b�V������
        /// <summary>
        /// �]�ƈ��}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�L���b�V���������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public void CacheEmployee()
        {
            object returnEmployee;
            _employeeWork = new Dictionary<string, EmployeeWork>();
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = this._enterpriseCode; ;

            try
            {

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            if (employeeWork.LogicalDeleteCode == 0 &&
                                _employeeWork.ContainsKey(employeeWork.EmployeeCode.Trim()) != true)
                            {
                                this._employeeWork.Add(employeeWork.EmployeeCode.Trim(), employeeWork);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                _employeeWork = new Dictionary<string, EmployeeWork>();
            }

        }

        /// <summary>
        /// �]�ƈ����݃`�F�b�N
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public bool GetEmployeeName(string employeeCode, out string employeeName)
        {
            employeeName = string.Empty;

            if (!this._employeeWork.ContainsKey(employeeCode))
            {
                return false;
            }

            employeeName = this._employeeWork[employeeCode].Name.Trim();

            return true;
        }

        # endregion

        # region ���������f�[�^�Z�b�g�擾����
        /// <summary>
        /// ���������f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�Z�b�g�擾���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private MitsubishiOrderProcDataSet DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new MitsubishiOrderProcDataSet();
                }
                return _dataSet;
            }
        }
        /// <summary>
        /// �L�����͍s���ݔ���
        /// </summary>
        /// <returns>�s���݃`�F�b�N���ʁiTrue : �s���� / False : �s�Ȃ��j</returns>
        /// <remarks>
        /// <br>Note       : �L�����͍s���ݔ�����s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this.OrderDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region ���������f�[�^�e�[�u���擾����
        /// <summary>
        /// ���������f�[�^�e�[�u���擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�e�[�u���擾���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public MitsubishiOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
        }
        # endregion

        #region �I���E��I����ԏ���(�w��^)
        /// <summary>
        /// �I���E��I����ԏ���(�w��^)
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <param name="selected">true:�I��,false:��I��</param>
        /// <remarks>
        /// <br>Note       : �I���E��I����ԏ������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        # region �� ��ʃf�[�^�N���X���������p���������o�N���X ��
        /// <summary>
        /// ��ʃf�[�^�N���X���������p���������o�N���X
        /// </summary>
        /// <param name="inpDisplay">��ʃf�[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �������o���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(MitsubishiInpDisplay inpDisplay)
        {
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            para.DataSendCodes = new int[1];
            para.DataSendCodes[0] = 0;
            return para;
        }
        # endregion

        // --- ADD 2010/12/31 --------- >>>>>
        #region �w�b�_�[�����͒l�̕ۑ�����
        /// <summary>
        /// �w�b�_�[�����͒l�̕ۑ�����
        /// </summary>
        /// <param name="inpHedDisplay"> �w�b�_�[�����̓N���X</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�����͒l�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public void UpdtHedaerItem(MitsubishiInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //�I�����C���ԍ�
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                
                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // �t�n�d���}�[�N�P

                dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // �[�i�敪
                dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // �[�i�敪����
                
            }

        }
        # endregion
        // --- ADD 2010/12/31 --------- <<<<<

        # region �� �t�n�d�����f�[�^ �������� ��
        /// <summary>
        /// �t�n�d�����f�[�^ ��������
        /// </summary>
        /// <param name="inpDisplay">���������N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^ �����������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        public int SearchDB(MitsubishiInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //�O���b�h�p�e�[�u���̃N���A
                this.OrderDataTable.Rows.Clear();

                //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return (status);
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        return (status);
                    }
                }

                int index = 1;

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�̊i�[
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    MitsubishiOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();
                    row.OrderNo = index++;
                    row.OnlineNo = uOEOrderDtlWork.OnlineNo;
                    row.InputDay = uOEOrderDtlWork.InputDay;
                    row.CustomerSnm = uOEOrderDtlWork.CustomerSnm;
                    row.CashRegisterNo = uOEOrderDtlWork.CashRegisterNo;
                    row.GoodsMakerCd = uOEOrderDtlWork.GoodsMakerCd;
                    row.GoodsNo = uOEOrderDtlWork.GoodsNo;
                    row.GoodsName = uOEOrderDtlWork.GoodsName;
                    row.AcceptAnOrderCnt = uOEOrderDtlWork.AcceptAnOrderCnt;
                    row.UoeRemark1 = uOEOrderDtlWork.UoeRemark1;
                    row.EmployeeCode = uOEOrderDtlWork.EmployeeCode;
                    row.EmployeeName = uOEOrderDtlWork.EmployeeName;
                    row.OnlineRowNo = uOEOrderDtlWork.OnlineRowNo;
                    row.UOEKind = uOEOrderDtlWork.UOEKind;
                    row.CommonSeqNo = uOEOrderDtlWork.CommonSeqNo;
                    row.SupplierFormal = uOEOrderDtlWork.SupplierFormal;
                    row.StockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                    row.UOEDeliGoodsDiv = uOEOrderDtlWork.UOEDeliGoodsDiv;
                    row.UOEResvdSection = uOEOrderDtlWork.UOEResvdSection;
                    row.FollowDeliGoodsDiv = uOEOrderDtlWork.FollowDeliGoodsDiv;
                    row.UOEDeliGoodsDivNm = uOEOrderDtlWork.DeliveredGoodsDivNm; // ADD 2010/12/31
                    row.BoCode = uOEOrderDtlWork.BoCode;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.OrderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        # endregion

        #region �t�n�d�����f�[�^�폜�����擾
        /// <summary>
        /// �t�n�d�����f�[�^�폜�����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�����擾���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// �t�n�d�����f�[�^�I�����Ȃ��̌����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�I�����Ȃ��̌����擾���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region �����u���b�N���̎Z�o
        /*------------------------- DEL 2010/05/07 -------------------------------------
        /// <summary>
        /// �t�n�d�����f�[�^�����Z�b�g���̎Z�o
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�����Z�b�g���̎Z�o���s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ���M���א�
                int detailIndex = 0;
                // �O���ײݔԍ�
                int bfOnlineNo = 0;
                // �ő�8����
                int maxDetailCount = 8;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];

                    if (ix == 0)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // ������ײݔԍ��ł͂Ȃ��ꍇ
                    else if (bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // ������ײݔԍ��ꍇ
                    else if (bfOnlineNo == onlineNo)
                    {
                        detailIndex++;
                        if (detailIndex > maxDetailCount)
                        {
                            count++;
                            detailIndex = 1;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            this.setCount = count;
            return count;
        }

        ------------------------- DEL 2010/05/07 -------------------------------------*/
        # endregion

        #region �t�n�d�����f�[�^�X�V����
        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
               out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, 
               out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //�ۑ��f�[�^�擾����
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                stockDetailWorkDelList = new List<StockDetailWork>();

                status = GetUOEOrderDtlWorkFromRowData(1, cashRegisterNo, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);

                // �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜����
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                // �X�V
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                return -1;
            }

            return status;
        }
        # endregion

        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int WriteFile(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                ASATOUOTXMLEditOrder aSATOUOTXMLEditOrder = new ASATOUOTXMLEditOrder(this.UoeFileStream);

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    aSATOUOTXMLEditOrder.NodeWrite(work);

                }

                aSATOUOTXMLEditOrder.FileEnd();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ----- ADD 2010/05/18 ---------------->>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ----- ADD 2010/05/18 ----------------<<<<<
            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int WriteAutoFile(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                AutoASATOUOEXMLEditOrder aSATOUOTXMLEditOrder = new AutoASATOUOEXMLEditOrder(this.UoeFileStream);

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    aSATOUOTXMLEditOrder.NodeWrite(work);
                }

                aSATOUOTXMLEditOrder.FileEnd();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                this.CloseFileStream();
            }
            return status;
        }

        /// <summary>
        /// �T�u�f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �T�u�f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 ������ UOE����������redmine:#18531</br>
        /// </remarks>
        public int WriteSubText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                ASATOUOESubTextEditOrder aSATOUOESubTextEditOrder = new ASATOUOESubTextEditOrder(uOEOrderDtlWorkList.Count);
                byte[] tempbyte = null;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    //���M�d��(JIS)
                    aSATOUOESubTextEditOrder.Telegram(work, i);
                }

                tempbyte = aSATOUOESubTextEditOrder.ToByteArray();
                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //�d�����׃N���X�S�ẴN���A
                aSATOUOESubTextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ----- ADD 2011/01/13 ---------------->>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ----- ADD 2011/01/13 ----------------<<<<<
            return status;
        }
        // --------ADD 2010/12/31---------<<<<<

        #region �I���f�[�^�̎擾����
        /// <summary>
        /// �I���f�[�^�̎擾����
        /// </summary>
        /// <param name="mode">0:�S�� 1:�ύX�f�[�^ 2:�I���f�[�^</param>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^�X�V�p���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׍X�V�p���X�g</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����f�[�^�폜�p���X�g</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�p���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�̎擾�������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// <br>UpdateNote : 2010/12/31 ������ UOE����������</br>
        /// </remarks>
        public int GetUOEOrderDtlWorkFromRowData(int mode, int cashRegisterNo, int systemDiv, 
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, 
                                                                out string message)
        {
            // �ߒl
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            message = "";
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
                    key = MakeKey(uOEOrderDtlWork);

                    //�f�[�^�擾����
                    uOEresultList = this._uOEOrderDtlWorkList.FindAll(delegate(UOEOrderDtlWork target)
                    {
                        if (key.Equals(MakeKey(target)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (uOEresultList.Count != 0)
                    {
                        UOEOrderDtlWork uOEOrderDtlWorktemp = uOEresultList[0];
                        if (mode == 1 && (systemDiv != 3
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // ��M���t
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // ���M�t���O
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // �����t���O
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // ���M�[���ԍ�
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // -----ADD 2010/12/31---------->>>>>
                            // UOE���}�[�N1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            // �[�i�敪
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // �[�i�敪����
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // BO�敪
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString();
                            // -----ADD 2010/12/31----------<<<<<
                            // UOE���}�[�N�Q
                            uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            // �󒍐���
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());
                            uOEOrderDtlWorkList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkList.Add(stockDetailWork);
                            }
                        }
                        else
                        {
                            uOEOrderDtlWorkDelList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkDelList.Add(stockDetailWork);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                status = -1;
            }

            return status;

        }

        #endregion

        #region �t�n�d�����f�[�^�폜����
        /// <summary>
        /// �t�n�d�����f�[�^�폜����
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int DeleteDB(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // �폜�Ώۂ̂t�n�d�����f�[�^�̎擾
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;

                status = GetUOEOrderDtlWorkFromRowData(2, 0, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);

                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }

        # endregion

        #region Key�쐬
        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="uOEOrderDtlWork">���ׁE�s</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : Key�쐬�������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private string MakeKey(UOEOrderDtlWork uOEOrderDtlWork)
        {
            // ���ׁE�sPrimary Key
            string key = uOEOrderDtlWork.OnlineNo.ToString() + uOEOrderDtlWork.OnlineRowNo.ToString() + uOEOrderDtlWork.UOEKind.ToString()
                + uOEOrderDtlWork.CommonSeqNo.ToString() + uOEOrderDtlWork.SupplierFormal.ToString() + uOEOrderDtlWork.StockSlipDtlNum.ToString();

            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : ���ׁE�sKey�쐬�������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // ���ׁE�sPrimary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key�쐬

        /// <summary>
        /// �t�@�C�����I�[�v�����`�F�b�N
        /// </summary>
        /// <param name="toyotaFlod">�t�H���_</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public bool GetCanWriteFlg(string toyotaFlod)
        {
            string mess = string.Empty;
            this.UoeFileStream = null;
            try
            {
                this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                return true;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                this.CloseFileStream();
                return false;
            }
        }

        /// <summary>
        /// �t�@�C���i�X�g���[���j���N���[�Y
        /// </summary>
        /// <remarks>
        /// <br>Note       :  �t�@�C���i�X�g���[���j���N���[�Y����B</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public void CloseFileStream()
        {
            if (UoeFileStream != null)
            {
                UoeFileStream.Close();
            }
        }

        // --------ADD 2010/12/31--------->>>>>
        #region �����X�V����
        /// <summary>
        /// �����X�V����
        /// </summary>
        /// <param name="dir">�������M�f�[�^�t�@�C������</param>
        /// <param name="subDir">�������M�f�[�^�T�u�t�@�C������</param>
        /// <param name="uoeSupplier">UOE������}�X�^</param>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^</param>
        /// <param name="errMess">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����X�V���s�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            try
            {
                count = this.GetDeleteCount();

                // �\��������ݒ�
                form.Title = "�X�V������";
                form.Message = "�X�V�������ł��B";
                // �_�C�A���O�\��
                form.Show();

                // �������v���O�����Ăяo��
                //UOE�ڑ�����}�X�^����ꍇ
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(3, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDir, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(3, dir, 0, string.Empty, 0, subDir, count, ref errMess);
                }

                // �_�C�A���O�����
                form.Close();

                switch ((Int16)status)
                {
                    case 0:
                        {
                            errMess = "����I���B";
                            #region �񓚃e�L�X�g�̎捞����
                            UOEOrderDtlMitsubishiAcs uOEOrderDtlMitsubishiAcs = new UOEOrderDtlMitsubishiAcs();

                            AnswerDateMitsubishiPara answerDateMitsubishiPara = new AnswerDateMitsubishiPara();
                            answerDateMitsubishiPara.EnterpriseCode = this._enterpriseCode;
                            answerDateMitsubishiPara.SectionCode = this._loginSectionCode;
                            answerDateMitsubishiPara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            answerDateMitsubishiPara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // �񓚏��̎擾���s���܂�
                            status = uOEOrderDtlMitsubishiAcs.DoSearch(answerDateMitsubishiPara, out errMess);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �g�����U�N�V�����f�[�^�̍쐬���s���܂�
                                status = uOEOrderDtlMitsubishiAcs.DoConfirm(answerDateMitsubishiPara, out errMess);
                            }
                            #endregion
                            break;
                        }
                    case 1:
                        {
                            subMess = "�d�q�J�^���O�N���ς݃G���[�B";
                            break;
                        }
                    case -1:
                        {
                            subMess = "�d�q�J�^���O�G���[�B";
                            break;
                        }
                    case -2:
                        {
                            subMess = "���[�J�[�s���B";
                            break;
                        }
                    case -3:
                        {
                            subMess = "���M�t�@�C�������B";
                            break;
                        }
                    case -4:
                        {
                            subMess = "�\�P�b�g�G���[�B";
                            break;
                        }
                    case -5:
                        {
                            subMess = "�p�����[�^�G���[�B";
                            break;
                        }
                    case -6:
                        {
                            subMess = "IP�A�h���X�ϊ��G���[�B";
                            break;
                        }
                    case -7:
                        {
                            subMess = "�񓚃t�@�C�������G���[�B";
                            break;
                        }
                    case -8:
                        {
                            subMess = "����M�t�@�C���폜�G���[�B";
                            break;
                        }
                    case -9:
                        {
                            subMess = "�^�C���A�E�g�B";
                            break;
                        }
                    case -10:
                        {
                            subMess = "�T�[�r�X�^�C���A�E�g�B";
                            break;
                        }
                    case -11:
                        {
                            subMess = "��M�t�@�C���^�C���A�E�g�B";
                            break;
                        }
                    case -12:
                        {
                            subMess = "�N���C�A���g�^�C���A�E�g�B";
                            break;
                        }
                    case -999:
                        {
                            subMess = "���̑��G���[�B";
                            break;
                        }
                    case 999:
                        {
                            subMess = "�ڑ��斢�ݒ�B";
                            break;
                        }
                }

                // PMPU9011.DLL�̖߂�l���u0�ȊO�v�̏ꍇ��
                if (!string.IsNullOrEmpty(subMess))
                {
                    //�uref msg�v�������Ă���ꍇ
                    if (!string.IsNullOrEmpty(errMess))
                    {
                        //��L�G���[���b�Z�[�W�Ɖ��s��Ɂuref msg�v�̒l���ǉ����āA���b�Z�[�W�{�b�N�X�̕\�����s��
                        errMess = subMess + "\r\n" + errMess;
                    }
                    else
                    {
                        errMess = subMess;
                    }
                }
            }
            catch (Exception ex)
            {
                // �_�C�A���O�����
                form.Close();
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (Int16)status;

        }

        /// <summary>
        /// �������v���O����
        /// </summary>
        [DllImport("PMPU9011.dll")]
        public extern static int xPMPU9011(int imk, string dir, int port, string pcname, int itimeout, string sdir, int imei, ref string msg);
        #endregion
        // --------ADD 2010/12/31---------<<<<<
    }
}

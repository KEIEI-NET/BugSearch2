//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y��������
// �v���O�����T�v   : ���Y�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                  ���YWeb-UOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^������YWeb-UOE�p�V�X�e���A�g�t�@�C���̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/18  �C�����e : Redmine4004-4006�A4030�A4043�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/19  �C�����e : Redmine4006�A4030�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/29  �C�����e : Redmine4311�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : 杍^
// �C �� ��  2010/12/31  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : 杍^
// �C �� ��  2011/01/13  �C�����e : Redmine18531�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/02/25  �C�����e : ���YUOE�������A�a�Ή����̑g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/15  �C�����e : Redmine #19908�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI ����
// �� �� ��  2012/09/24  �C�����e : �g���^���������f�[�^�̃\�[�g�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
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
    /// ���Y���������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Y���������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : 2010/03/18 ������ Redmine4004-4006�A4030�A4043�Ή�</br>
    /// <br>UpdateNote : 2010/03/19 ������ Redmine4006�A4030�Ή�</br>
    /// <br>UpdateNote : 2010/03/29 ������ Redmine4311�Ή�</br>
    /// <br>UpdateNote : 2010/12/31 杍^ UOE����������</br>
    /// <br>UpdateNote : 2011/01/13 杍^ Redmine18531�Ή�</br>
    /// <br>UpdateNote : 2011/02/25 ������ ���YUOE�������A�a�Ή����̑g�ݍ���</br>
    /// <br>UpdateNote : 2011/03/15 ������ Redmine #19908�̑Ή�</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// </remarks>
    public partial class NissanOrderProcAcs
    {
        // --- ADD 2012/09/24 ---------------------------->>>>>
        # region ��Inner Class
        /// <summary>
        /// �g���^���������f�[�^�\�[�g�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �g���^���������f�[�^�̃\�[�g���s���N���X�ł��B</br>
        /// <br>Note       : �ďo�ԍ��A�ďo�ԍ��}�Ԃ̏��Ƀ\�[�g���܂��B</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : IComparer<UOEOrderDtlWork>
        {
            #region IComparer �����o

            public int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // NULL�`�F�b�N����
                if (x == null || y == null)
                {
                    throw new ArgumentNullException();
                }

                // �f�[�^���r����
                if (x.OnlineNo > y.OnlineNo)
                {
                    return 1;
                }
                else if (x.OnlineNo < y.OnlineNo)
                {
                    return -1;
                }
                else
                {
                    if (x.OnlineRowNo > y.OnlineRowNo)
                    {
                        return 1;
                    }
                    else if (x.OnlineRowNo < y.OnlineRowNo)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// �d�����׃f�[�^�\�[�g�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����׃f�[�^�̃\�[�g���s���N���X�ł��B</br>
        /// <br>Note       : �V�[�P���X�ԍ����Ƀ\�[�g���܂��B</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class StockDetailWorkComparer : IComparer<StockDetailWork>
        {
            private readonly List<long> _CommonSeqNoList = new List<long>();

            public StockDetailWorkComparer(List<UOEOrderDtlWork> _uOEOrderDtlWorkList)
            {
                // �V�[�P���X�ԍ������X�g������
                foreach (UOEOrderDtlWork item in _uOEOrderDtlWorkList)
                {
                    _CommonSeqNoList.Add(item.CommonSeqNo);
                }
            }

            #region IComparer �����o

            public int Compare(StockDetailWork x, StockDetailWork y)
            {
                // NULL�`�F�b�N����
                if (x == null || y == null || _CommonSeqNoList == null)
                {
                    throw new ArgumentNullException();
                }

                // �C���f�b�N�X���擾����
                int a = _CommonSeqNoList.IndexOf(x.CommonSeqNo);
                int b = _CommonSeqNoList.IndexOf(y.CommonSeqNo);
                if (a < 0 || b < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // �f�[�^���r����
                if (a > b)
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            #endregion
        }
        #endregion
        // --- ADD 2012/09/24 ----------------------------<<<<<

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2010/12/31

        //�A�N�Z�X�N���X
        private static NissanOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //�f�[�^�[�e�[�u��
        private NissanOrderProcDataSet _dataSet;
        private NissanOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //�]�ƈ��}�X�^
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // �]�ƈ���� �A�N�Z�X�N���X

        //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private int setCount = 0;

        // �t�@�C���i�X�g���[���j
        private FileStream _uoeFileStream = null;

        private string _commAssemblyId = string.Empty;  // ADD 2011/02/25

        private UOESupplier _uOESupplier = null;  // ADD 2011/03/15
        # endregion

        // --------UPD 2010/03/18 -------->>>>>
        #region F2WUOETextEditOrder
        //#region TelegramEditOrder0203
        ///// <summary>
        ///// �t�n�d���M�d���쐬���������i�g���^�o�c�S�j
        ///// </summary>
        /// <summary>
        /// ���YWeb-UOE�V�X�e���A�g�t�@�C��(����)�쐬
        /// </summary>
        //public class F2WUOETextEditOrder
        private class F2WUOETextEditOrder
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//���׍s��
            private const Int32 ctSndTelegramLen = 270; //���M�d���T�C�Y
            # endregion

            #region Private Members
            //�����d��
            private byte[] disposalFlg = new byte[1];	/*      �����敪       */
            private byte[] relaNo = new byte[2];		/*           �A��            */
            private byte[] remark = new byte[10];		/*      	 �R�����g         */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ײ�      ���i�ԍ�        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          ����              */
            private byte[][] space = new byte[ctDetailLen -1][];	/*          Space              */
            private byte[] lastSpace = new byte[120];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (����)          */

            //�ϐ�
            private Int32 _ln = 0;

            #endregion

            # region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
            //public TelegramEditOrder0203()
            public F2WUOETextEditOrder()
			{
                for (int i = 0; i < ctDetailLen; i++)
				{
                    posNo[i] = new byte[12];	// ���i�ԍ�
                    goodsCount[i] = new byte[4];	// ����
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
				}
                for (int j = 0; j < 2; j++)
                {
                    // (����)
                    fg[j] = new byte[1];
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
                _ln = 0;
                
                // ���ו�
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// �����敪
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// �A��
                UoeCommonFnc.MemSet(ref remark, 0x20, remark.Length);		// �R�����g
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// ���i�ԍ�
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// ����
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (����)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <param name="page">���[�N</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (_ln == 0)
                {
                    # region ���w�b�_�[����
                    //���w�b�_�[����

                    // �����敪 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // �A�� = 8���Ԗ����ı���
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark2, remark.Length);
                    // (����):���s�FCR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region �����ו���
                //�����ו���
                if (_ln < ctDetailLen)
                {
                    // ���i�ԍ�
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //����
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    if (_ln != ctDetailLen -1)
                    {
                        // Space = " "(���p��߰�1��)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(���p��߰�120��)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //���א��C���N�������g
                    _ln++;
                }

                # endregion

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
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// �����敪
                ms.Write(relaNo, 0, relaNo.Length);			// �A��
                ms.Write(remark, 0, remark.Length);			// �R�����g
                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// ���i�ԍ�
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// ����
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (����)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        //�Ɩ��敪
        private const Int32 ctTerminalDiv_Order = 1;	//����
        #endregion
        // --------UPD 2010/03/18 --------<<<<<

        // --------ADD 2010/12/31--------->>>>>
        #region AUTOF2WUOETextEditOrder
        //#region TelegramEditOrder0203
        ///// <summary>
        ///// �t�n�d���M�d���쐬���������i�g���^�o�c�S�j
        ///// </summary>
        /// <summary>
        /// ���YWeb-UOE�V�X�e���A�g�t�@�C��(����)�쐬
        /// </summary>
        //public class F2WUOETextEditOrder
        private class AUTOF2WUOETextEditOrder
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//���׍s��
            private const Int32 ctSndTelegramLen = 270; //���M�d���T�C�Y
            # endregion

            #region Private Members
            //�����d��
            private byte[] disposalFlg = new byte[1];	/*      �����敪       */
            private byte[] relaNo = new byte[2];		/*           �A��            */
            private byte[] remark = new byte[10];		/*      	 �R�����g         */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ײ�      ���i�ԍ�        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          ����              */
            private byte[][] space = new byte[ctDetailLen - 1][];	/*          Space              */
            private byte[] lastSpace = new byte[120];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (����)          */

            //�ϐ�
            private Int32 _ln = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            //public TelegramEditOrder0203()
            public AUTOF2WUOETextEditOrder()
            {
                for (int i = 0; i < ctDetailLen; i++)
                {
                    posNo[i] = new byte[12];	// ���i�ԍ�
                    goodsCount[i] = new byte[4];	// ����
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    // (����)
                    fg[j] = new byte[1];
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
                _ln = 0;

                // ���ו�
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// �����敪
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// �A��
                UoeCommonFnc.MemSet(ref remark, 0x20, remark.Length);		// �R�����g
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// ���i�ԍ�
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// ����
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (����)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <param name="page">���[�N</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (_ln == 0)
                {
                    # region ���w�b�_�[����
                    //���w�b�_�[����

                    // �����敪 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // �A�� = 8���Ԗ����ı���
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark1, remark.Length);
                    // (����):���s�FCR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region �����ו���
                //�����ו���
                if (_ln < ctDetailLen)
                {
                    // ���i�ԍ�
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //����
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    if (_ln != ctDetailLen - 1)
                    {
                        // Space = " "(���p��߰�1��)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(���p��߰�120��)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //���א��C���N�������g
                    _ln++;
                }

                # endregion

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
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// �����敪
                ms.Write(relaNo, 0, relaNo.Length);			// �A��
                ms.Write(remark, 0, remark.Length);			// �R�����g
                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// ���i�ԍ�
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// ����
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (����)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // --------ADD 2010/12/31--------->>>>>
        #region F2WUOESubTextEditOrder
        ///// <summary>
        ///// �t�n�d���M�d���쐬���������i�g���^�o�c�S�j
        ///// </summary>
        /// <summary>
        /// ���YWeb-UOE�V�X�e���A�g�t�@�C��(����)�쐬
        /// </summary>
        private class F2WUOESubTextEditOrder
        {

            # region Const Members
            private const Int32 ctSubDetailLen = 8;	//�T�u���׍s��
            private const Int32 ctSndTelegramLen = 270; //���M�d���T�C�Y
            # endregion

            #region Private Members
            //�T�u�����d��
            private byte[] subDisposalFlg = new byte[1];	/*      �T�u�����敪       */
            private byte[] subRelaNo = new byte[2];		/*           �T�u�A��            */
            private byte[] subDeliGoodsDiv = new byte[1];		/*           �T�u�[�i�敪            */
            private byte[] subEmployee = new byte[2];		/*           �T�u�˗���            */
            private byte[] subSectionCode = new byte[3];		/*           �T�u�w�苒�_            */
            private byte[] subRemark = new byte[10];		/*      	 �T�u�R�����g         */
            private byte[][] subBoCode = new byte[ctSubDetailLen][];		/*      	 �T�uBO�敪         */
            private byte[][] fg = new byte[2][];	/*          (����)          */

            //�ϐ�
            private Int32 _subLn = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public F2WUOESubTextEditOrder()
            {
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    subBoCode[i] = new byte[1];	// ���i�ԍ�
                }
                for (int j = 0; j < 2; j++)
                {
                    // (����)
                    fg[j] = new byte[1];
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
                _subLn = 0;

                // ���ו�
                UoeCommonFnc.MemSet(ref subDisposalFlg, 0x20, subDisposalFlg.Length);		// �����敪
                UoeCommonFnc.MemSet(ref subRelaNo, 0x20, subRelaNo.Length);		// �A��
                UoeCommonFnc.MemSet(ref subDeliGoodsDiv, 0x20, subDeliGoodsDiv.Length);		// �[�i�敪
                UoeCommonFnc.MemSet(ref subEmployee, 0x20, subEmployee.Length);		// �˗���
                UoeCommonFnc.MemSet(ref subSectionCode, 0x20, subSectionCode.Length);		// �w�苒�_
                UoeCommonFnc.MemSet(ref subRemark, 0x20, subRemark.Length);		// �R�����g
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref subBoCode[i], 0x20, subBoCode[i].Length);	// ���i�ԍ�
                }
                // (����)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region �T�u�f�[�^�ҏW����
            /// <summary>
            /// �T�u�f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <param name="page">���[�N</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (_subLn == 0)
                {
                    # region ���w�b�_�[����
                    //���w�b�_�[����

                    // �����敪 = "H";
                    UoeCommonFnc.MemSet(ref subDisposalFlg, 0x48, subDisposalFlg.Length);
                    // �A�� = 8���Ԗ����ı���
                    UoeCommonFnc.MemCopy(ref subRelaNo, page.ToString("00"), subRelaNo.Length);
                    // �[�i�敪
                    UoeCommonFnc.MemCopy(ref subDeliGoodsDiv, work.UOEDeliGoodsDiv, subDeliGoodsDiv.Length);
                    // �˗���
                    UoeCommonFnc.MemCopy(ref subEmployee, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(), subEmployee.Length), subEmployee.Length);
                    // �w�苒�_
                    UoeCommonFnc.MemCopy(ref subSectionCode, work.UOEResvdSection, subSectionCode.Length);
                    // �R�����g = "@" + �V�X�e���敪�i1���j+�A�gNo.(�@�A�gNo.=UI�����őI������UOE�����ް��̵�ײݔԍ��iOnlineNoRF�j�̉�8��0�l��)
                    UoeCommonFnc.MemCopy(ref subRemark, work.UoeRemark2, subRemark.Length);
                    // (����):���s�FCR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region ���T�u���ו���
                //�����ו���
                if (_subLn < ctSubDetailLen)
                {
                    // BO�敪
                    UoeCommonFnc.MemCopy(ref subBoCode[_subLn], work.BoCode, subBoCode[_subLn].Length);

                    //���א��C���N�������g
                    _subLn++;
                }

                # endregion

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
                ms.Write(subDisposalFlg, 0, subDisposalFlg.Length);		// �����敪
                ms.Write(subRelaNo, 0, subRelaNo.Length);			// �A��
                ms.Write(subDeliGoodsDiv, 0, subDeliGoodsDiv.Length);	// �[�i�敪
                ms.Write(subEmployee, 0, subEmployee.Length);			// �˗���
                ms.Write(subSectionCode, 0, subSectionCode.Length);			// �w�苒�_
                ms.Write(subRemark, 0, subRemark.Length);			// �R�����g
                //���ו�
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    ms.Write(subBoCode[i], 0, subBoCode[i].Length);	// BO�敪
                }
                // (����)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25-------------->>>>>
        #region F2WUOETextEditOrder2
        /// <summary>
        /// ���YWeb-UOE�V�X�e���A�g�t�@�C��(����)�쐬(�v���O����ID���u0205�v�Ɓu0206�v�̏ꍇ)
        /// </summary>
        private class F2WUOETextEditOrder2
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//���׍s��
            private const Int32 ctSndTelegramLen = 270; //���M�d���T�C�Y
            # endregion

            #region Private Members
            //�����d��
            private byte[] disposalFlg = new byte[1];	/*      �����敪       */
            private byte[] relaNo = new byte[2];		/*           �A��            */
            private byte[] shippingCd = new byte[6];		/*    ���͂���R�[�h     */
            private byte[] deliGoodsDiv = new byte[1];		/*       �[�i�敪      */
            private byte[] employeeCd = new byte[2];		/*     �˗��҃R�[�h        */
            private byte[] resvdSection = new byte[3];		/*       �w�苒�_      */
            private byte[] remark1 = new byte[10];		/*      	 �R�����g1        */
            private byte[] remark2 = new byte[10];		/*      	 �R�����g2        */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ײ�      ���i�ԍ�        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          ����              */
            private byte[][] boCode = new byte[ctDetailLen][];	/*          BO            */
            private byte[][] space = new byte[ctDetailLen - 1][];	/*          Space              */
            private byte[] lastSpace = new byte[127];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (����)          */

            //�ϐ�
            private Int32 _ln = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public F2WUOETextEditOrder2()
            {
                for (int i = 0; i < ctDetailLen; i++)
                {
                    posNo[i] = new byte[12];	// ���i�ԍ�
                    goodsCount[i] = new byte[4];	// ����
                    boCode[i] = new byte[1];   // BO
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    // (����)
                    fg[j] = new byte[1];
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
                _ln = 0;

                // �w�b�_�[��
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// �����敪
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// �A��
                UoeCommonFnc.MemSet(ref shippingCd, 0x20, shippingCd.Length);		// ���͂���R�[�h
                UoeCommonFnc.MemSet(ref deliGoodsDiv, 0x20, deliGoodsDiv.Length);		// �[�i�敪
                UoeCommonFnc.MemSet(ref employeeCd, 0x20, employeeCd.Length);		// �˗��҃R�[�h
                UoeCommonFnc.MemSet(ref resvdSection, 0x20, resvdSection.Length);		// �w�苒�_
                UoeCommonFnc.MemSet(ref remark1, 0x20, remark1.Length);		// �R�����g1
                UoeCommonFnc.MemSet(ref remark2, 0x20, remark2.Length);		// �R�����g2

                // ���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// ���i�ԍ�
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// ����
                    UoeCommonFnc.MemSet(ref boCode[i], 0x20, boCode[i].Length);	// BO
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (����)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <param name="page">���[�N</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (_ln == 0)
                {
                    # region ���w�b�_�[����
                    //���w�b�_�[����

                    // �����敪 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // �A�� = 8���Ԗ����ı���
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // ���͂���R�[�h = ��ʂ̂��͂���R�[�h
                    UoeCommonFnc.MemCopy(ref shippingCd, work.ShippingCd, shippingCd.Length);
                    // �[�i�敪 = ��ʂ̔[�i�敪
                    UoeCommonFnc.MemCopy(ref deliGoodsDiv, work.UOEDeliGoodsDiv, deliGoodsDiv.Length);
                    // �˗��҃R�[�h = ��ʂ̈˗��҃R�[�h
                    UoeCommonFnc.MemCopy(ref employeeCd, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(),employeeCd.Length), employeeCd.Length);
                    // �w�苒�_ = ��ʂ̎w�苒�_
                    UoeCommonFnc.MemCopy(ref resvdSection, work.UOEResvdSection, resvdSection.Length);
                    // �R�����g1 = ��ʂ̃��}�[�N�P
                    UoeCommonFnc.MemCopy(ref remark1, work.UoeRemark1, remark1.Length);
                    // �R�����g2 = (ID0205:�A�g�ԍ� ID0206:��ʂ̃��}�[�N�Q)
                    UoeCommonFnc.MemCopy(ref remark2, work.UoeRemark2, remark2.Length);
                    // (����):���s�FCR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region �����ו���
                //�����ו���
                if (_ln < ctDetailLen)
                {
                    // ���i�ԍ�
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //����
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    // BO
                    UoeCommonFnc.MemCopy(ref boCode[_ln], work.BoCode, boCode[_ln].Length);

                    if (_ln != ctDetailLen - 1)
                    {
                        // Space = " "(���p��߰�1��)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(���p��߰�120��)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //���א��C���N�������g
                    _ln++;
                }

                # endregion

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
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// �����敪
                ms.Write(relaNo, 0, relaNo.Length);			// �A��
                ms.Write(shippingCd, 0, shippingCd.Length);			// ���͂���R�[�h
                ms.Write(deliGoodsDiv, 0, deliGoodsDiv.Length);			// �[�i�敪
                ms.Write(employeeCd, 0, employeeCd.Length);			// �˗��҃R�[�h
                ms.Write(resvdSection, 0, resvdSection.Length);			// �w�苒�_
                ms.Write(remark1, 0, remark1.Length);			// �R�����g1
                ms.Write(remark2, 0, remark2.Length);			// �R�����g2
                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// ���i�ԍ�
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// ����
                    ms.Write(boCode[i], 0, boCode[i].Length);	// BO
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (����)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // ---ADD 2011/02/25--------------<<<<<

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4006�A4030�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4006�A4030�Ή�</br>
        /// </remarks>
        private NissanOrderProcAcs()
        {
            // �ϐ�������
            //this._dataSet = new NissanOrderProcDataSet();// DEL 2010/03/19
            //this._orderDataTable = this._dataSet.OrderExpansion;// DEL 2010/03/18
            // -----------DEL 2010/03/19------------>>>>>
            //this._orderDataTable = this.DataSet.OrderExpansion;// ADD 2010/03/18
            // -----------DEL 2010/03/19------------<<<<<
            //this.orderDataTable.Rows.Clear();// DEL 2010/03/18
            this.OrderDataTable.Rows.Clear();// ADD 2010/03/18

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
        }

        /// <summary>
        /// �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�t�n�d���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public static NissanOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new NissanOrderProcAcs();
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
        //public FileStream UoeFileStream// DEL 2010/03/18
        private FileStream UoeFileStream// ADD 2010/03/18
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4006�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4006�Ή�</br>
        /// </remarks>
        //public NissanOrderProcDataSet DataSet// DEL 2010/03/18
        private NissanOrderProcDataSet DataSet// ADD 2010/03/18
        {
            // ---------UPD 2010/03/19--------->>>>>
            //get { return this._dataSet; }
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new NissanOrderProcDataSet();
                }
                return _dataSet;
            }
            // ---------UPD 2010/03/19---------<<<<<
        }
        /// <summary>
        /// �L�����͍s���ݔ���
        /// </summary>
        /// <returns>�s���݃`�F�b�N���ʁiTrue : �s���� / False : �s�Ȃ��j</returns>
        /// <remarks>
        /// <br>Note       : �L�����͍s���ݔ�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// </remarks>
        public bool StockRowExists()
        {
            //if (this._orderDataTable.Rows.Count > 0)// DEL 2010/03/18
            if (this.OrderDataTable.Rows.Count > 0)// ADD 2010/03/18
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4030�Ή�</br>
        /// </remarks>
        //public NissanOrderProcDataSet.OrderExpansionDataTable orderDataTable
        public NissanOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            // ------------UPD 2010/03/19------------>>>>>
            //get { return _orderDataTable; }
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
            // ------------UPD 2010/03/19------------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            //DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);// DEL 2010/03/18
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);// ADD 2010/03/18

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                //_row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;// DEL 2010/03/18
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;// ADD 2010/03/18
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(NissanInpDisplay inpDisplay)
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

        // --- ADD 2010/12/31 --------- >>>>>
        #region �w�b�_�[�����͒l�̕ۑ�����
        /// <summary>
        /// �w�b�_�[�����͒l�̕ۑ�����
        /// </summary>
        /// <param name="inpHedDisplay"> �w�b�_�[�����̓N���X</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�����͒l�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>Update Note: 2011/02/25 ������</br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        public void UpdtHedaerItem(NissanInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //�I�����C���ԍ�
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // �t�n�d���}�[�N�P
                dataRow[this.OrderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // �]�ƈ��R�[�h
                dataRow[this.OrderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // �]�ƈ�����

                dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // �[�i�敪
                dataRow[this.OrderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;                // UOE�w�苒�_
                dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // �[�i�敪����
                dataRow[this.OrderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;                // UOE�w�苒�_����
                // ---ADD 2011/02/25------------->>>>>
                dataRow[this.OrderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // �t�n�d���}�[�N�Q
                dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName] = inpHedDisplay.ShippingCd;                    // ���͂���R�[�h
                // ---ADD 2011/02/25-------------<<<<<
            }

        }
        // --- ADD 2010/12/31 --------- <<<<<

        # endregion

        # endregion

        # region �� �t�n�d�����f�[�^ �������� ��
        /// <summary>
        /// �t�n�d�����f�[�^ ��������
        /// </summary>
        /// <param name="inpDisplay">���������N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^ �����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// <br>Update Note: 2011/02/25 ������</br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        public int SearchDB(NissanInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //�O���b�h�p�e�[�u���̃N���A
                //this.orderDataTable.Rows.Clear();// DEL 2010/03/18
                this.OrderDataTable.Rows.Clear();// ADD 2010/03/18

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

                // --- ADD 2012/09/24 ---------------------------->>>>>
                // �擾���������f�[�^���\�[�g����(�ďo�ԍ��A�ďo�ԍ��}�Ԃ̏��Ń\�[�g)
                UOEOrderDtlWorkComparer UoeComp = new UOEOrderDtlWorkComparer();
                _uOEOrderDtlWorkList.Sort(UoeComp);

                // �\�[�g���������f�[�^�̃V�[�P���X�ԍ����ŁA�d�����׃f�[�^���\�[�g����
                StockDetailWorkComparer StockComp = new StockDetailWorkComparer(_uOEOrderDtlWorkList);
                _stockDetailWorkList.Sort(StockComp);
                // --- ADD 2012/09/24 ----------------------------<<<<<

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�̊i�[
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    //NissanOrderProcDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();// DEL 2010/03/18
                    NissanOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();// ADD 2010/03/18
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
                    // ---ADD 2011/02/25--------------->>>>
                    if ("0206".Equals(uOEOrderDtlWork.CommAssemblyId))
                    {
                        row.UoeRemark2 = uOEOrderDtlWork.UoeRemark2;
                    }
                    else
                    {
                        row.UoeRemark2 = string.Empty;
                    }

                    row.ShippingCd = string.Empty;
                    // ---ADD 2011/02/25---------------<<<<
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
                    row.BoCode = uOEOrderDtlWork.BoCode;


                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    //this.orderDataTable.AddOrderExpansionRow(row);// DEL 2010/03/18
                    this.OrderDataTable.AddOrderExpansionRow(row);// ADD 2010/03/18
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18-----------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
                // ----------UPD 2010/03/18-----------<<<<<
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
        /// <summary>
        /// �t�n�d�����f�[�^�����Z�b�g���̎Z�o
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�����Z�b�g���̎Z�o���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// <br>Update Note: 2011/02/25 ������</br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18-----------<<<<<
                // ���M���א�
                int detailIndex = 0;
                // �O���ײݔԍ�
                int bfOnlineNo = 0;
                // ---UPD 2011/02/25--------------->>>>>
                //// �ő�8����
                //int maxDetailCount = 8;
                int maxDetailCount = 0;
                if ("0206".Equals(this._commAssemblyId))
                {
                    // �ő�6����
                    maxDetailCount = 6;
                }
                else
                {
                    // �ő�8����
                    maxDetailCount = 8;
                }
                // ---UPD 2011/02/25---------------<<<<<
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    //Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];// DEL 2010/03/18
                    Int32 onlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];// ADD 2010/03/18

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4004�A4043�Ή�</br>
        /// <br>UpdateNote : 2011/02/25 ������ ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        public int WriteText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);// ADD 2010/03/18
            try
            {
                //TelegramEditOrder0203 telegramEditOrder0203 = new TelegramEditOrder0203();// DEL 2010/03/18
                F2WUOETextEditOrder f2WUOETextEditOrder = new F2WUOETextEditOrder();// ADD 2010/03/18
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //���M�d��(JIS)
                        //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                        f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                        onlineNo = work.OnlineNo;
                    }
                    //�����ԍ����ύX���ꂽ
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                        tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //�d�����׃N���X�S�ẴN���A
                        //telegramEditOrder0203.Clear();// DEL 2010/03/18
                        f2WUOETextEditOrder.Clear();// ADD 2010/03/18
                        //���M�d��(JIS)
                        //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                        f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                            tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            //telegramEditOrder0203.Clear();// DEL 2010/03/18
                            f2WUOETextEditOrder.Clear();// ADD 2010/03/18

                            //���M�d��(JIS)
                            //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                            f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                            detailCount = 1;
                        }
                        else
                        {
                            //���M�d��(JIS)
                            //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                            f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                        }
                    }

                }

                //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //�d�����׃N���X�S�ẴN���A
                //telegramEditOrder0203.Clear();// DEL 2010/03/18
                f2WUOETextEditOrder.Clear();// ADD 2010/03/18

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //this.CloseFileStream(this.UoeFileStream);// DEL 2010/03/18
                this.CloseFileStream();// ADD 2010/03/18
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ---ADD 2011/02/25-------------------->>>>
            finally
            {
                this.CloseFileStream();
            }
            // ---ADD 2011/02/25--------------------<<<<
            return status;
        }

        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 杍^ Redmine18531�Ή�</br>
        /// </remarks>
        public int WriteAutoText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                AUTOF2WUOETextEditOrder aUTOF2WUOETextEditOrder = new AUTOF2WUOETextEditOrder();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //���M�d��(JIS)
                        aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //�����ԍ����ύX���ꂽ
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //�d�����׃N���X�S�ẴN���A
                        aUTOF2WUOETextEditOrder.Clear();
                        //���M�d��(JIS)
                        aUTOF2WUOETextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            aUTOF2WUOETextEditOrder.Clear();

                            //���M�d��(JIS)
                            aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //���M�d��(JIS)
                            aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //�d�����׃N���X�S�ẴN���A
                aUTOF2WUOETextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ADD 2011/01/13 --- >>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ADD 2011/01/13 --- <<<<<
            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// �T�u�f�[�^�ۑ�����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �T�u�f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 杍^ Redmine18531�Ή�</br>
        /// </remarks>
        public int WriteSubText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                F2WUOESubTextEditOrder f2WUOESubTextEditOrder = new F2WUOESubTextEditOrder();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //���M�d��(JIS)
                        f2WUOESubTextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //�����ԍ����ύX���ꂽ
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //�d�����׃N���X�S�ẴN���A
                        f2WUOESubTextEditOrder.Clear();
                        //���M�d��(JIS)
                        f2WUOESubTextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;

                            tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            f2WUOESubTextEditOrder.Clear();

                            //���M�d��(JIS)
                            f2WUOESubTextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //���M�d��(JIS)
                            f2WUOESubTextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //�d�����׃N���X�S�ẴN���A
                f2WUOESubTextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ADD 2011/01/13 --- >>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ADD 2011/01/13 --- <<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4030�Ή�</br>
        /// <br>UpdateNote : 2011/03/15 ������ Redmine #19908�̑Ή�</br>
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
                // ----------UPD 2010/03/18---------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18----------<<<<<
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    // ----------UPD 2010/03/18---------->>>>>
                    //uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    //uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    //uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    //uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    //uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    //uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
                    // ----------UPD 2010/03/18----------<<<<<
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
                        // ----------UPD 2010/03/18---------->>>>>
                        //if (mode == 1 && (systemDiv != 3 
                        //    || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        if (mode == 1 && (systemDiv != 3
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))

                        // ----------UPD 2010/03/18----------<<<<<
                        {
                            // ��M���t
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // ���M�t���O
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // �����t���O
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // ���M�[���ԍ�
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;

                            // UOE���}�[�N1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            // �[�i�敪
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // �[�i�敪����
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // �w�苒�_
                            uOEOrderDtlWorktemp.UOEResvdSection = dataRow[this.OrderDataTable.UOEResvdSectionColumn.ColumnName].ToString();
                            // UOE�w�苒�_����
                            uOEOrderDtlWorktemp.UOEResvdSectionNm = dataRow[this.OrderDataTable.UOEResvdSectionNmColumn.ColumnName].ToString();
                            // �]�ƈ��R�[�h
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.OrderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            // �]�ƈ�����
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.OrderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            // BO�敪
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString().Trim();


                            // UOE���}�[�N�Q
                            // ---ADD 2011/03/15------------------>>>>>
                            //uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            if ("0206".Equals(uOEOrderDtlWorktemp.CommAssemblyId) && this._uOESupplier != null)
                            {
                                uOEOrderDtlWorktemp.UoeRemark2 = this._uOESupplier.MazdaSectionCode.Trim().PadRight(3,' ') + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            }
                            else
                            {
                            uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            }
                            // ---ADD 2011/03/15------------------<<<<<
                            // �󒍐���
                            //uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());// DEL 2010/03/18
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());// ADD 2010/03/18
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

        // ---ADD 2011/02/25-------------->>>>>
        /// <summary>
        /// �f�[�^�ۑ�����(�v���O����ID���u0205�v�̏ꍇ)
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public int WriteText2(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                #region ���}�[�N�Q�Ƃ��͂���R�[�h���ăZ�b�g����B
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    DataView orderDataView = new DataView(this.OrderDataTable);
                    orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);

                    // ������}�X�^�̃v���O�������Q�Ƃ��A���}�[�N�Q�ւ̃Z�b�g���e�ύX���s���B
                    for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                    {
                        UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                        for (int j = 0; j < orderDataView.Count; j++)
                        {
                            NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[j].Row);
                            if ((Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName] == work.OnlineNo)
                            {
                                // 0206�̏ꍇ�A��ʂ̃��}�[�N�Q���R�����g2�ɃZ�b�g�B���͂���R�[�h���Z�b�g�B
                                if ("0206".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.UoeRemark2 = dataRow[this.OrderDataTable.UoeRemark2Column.ColumnName].ToString().Trim();
                                    work.ShippingCd = dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName].ToString().Trim().PadLeft(6, ' ');
                                }
                                // 0205�̏ꍇ�A���͂���R�[�h���Z�b�g�B
                                else if ("0205".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.ShippingCd = dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName].ToString().Trim().PadLeft(6, ' ');
                                }
                                else
                                {
                                    // �Ȃ��B
                                }
                                break;
                            }
                            else
                            {
                                // �Ȃ��B
                            }
                        }
                    }
                }
                #endregion

                F2WUOETextEditOrder2 f2WUOETextEditOrder = new F2WUOETextEditOrder2();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //���M�d��(JIS)
                        f2WUOETextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //�����ԍ����ύX���ꂽ
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = f2WUOETextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //�d�����׃N���X�S�ẴN���A
                        f2WUOETextEditOrder.Clear();
                        //���M�d��(JIS)
                        f2WUOETextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            tempbyte = f2WUOETextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            f2WUOETextEditOrder.Clear();

                            //���M�d��(JIS)
                            f2WUOETextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //���M�d��(JIS)
                            f2WUOETextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = f2WUOETextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //�d�����׃N���X�S�ẴN���A
                f2WUOETextEditOrder.Clear();

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
        /// �t�n�d�����f�[�^�����Z�b�g���̎Z�o�p
        /// </summary>
        /// <param name="commAssemblyId">�v���O����ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�����Z�b�g���̎Z�o�p</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public void SetCommAssemblyId(string commAssemblyId)
        {
            this._commAssemblyId = commAssemblyId;
        }

        /// <summary>
        /// �ۑ��f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <param name="systemDivCd">�V�X�e���敪</param>
        /// <param name="itemNameList">���ږ��̃��X�g</param>
        /// <param name="itemList">���ڃ��X�g</param>
        /// <returns>true:�ۑ��� false:�ۑ��s��</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��f�[�^�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public bool SaveDataCheck(int businessCode, int systemDivCd, out List<string> itemNameList, out List<string> itemList)
        {
            itemNameList = new List<string>();
            itemList = new List<string>();

            foreach (NissanOrderProcDataSet.OrderExpansionRow row in this.OrderDataTable)
            {
                if (row.InpSelect == true)
                {
                    // �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜����
                    if (systemDivCd == 3 && row.AcceptAnOrderCnt == 0)
                    {
                        continue;
                    }
                    //�[�i�敪�̃`�F�b�N
                    // �����̏ꍇ
                    if ((businessCode == ctTerminalDiv_Order)
                        && (string.IsNullOrEmpty(row.UOEDeliGoodsDivNm)))
                    {
                        itemNameList.Add("�[�i�敪");
                        itemList.Add("OrderExpansion");
                    }

                    //�w�苒�_
                    if ((businessCode == ctTerminalDiv_Order)
                        && (string.IsNullOrEmpty(row.UOEResvdSectionNm)))
                    {
                        itemNameList.Add("�w�苒�_");
                        itemList.Add("OrderExpansion");
                    }

                    //�˗���
                    if ((businessCode == ctTerminalDiv_Order)
                    && (row.EmployeeCode.Trim() == ""))
                    {
                        itemNameList.Add("�˗���");
                        itemList.Add("OrderExpansion");
                    }
                }

                if (itemNameList.Count > 0) break;
            }
            if (itemNameList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // ---ADD 2011/02/25--------------<<<<<
        #endregion

        #region �t�n�d�����f�[�^�폜����
        /// <summary>
        /// �t�n�d�����f�[�^�폜����
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4005�Ή�</br>
        /// <br>UpdateNote : 2010/03/29 ������ Redmine4311�Ή�</br>
        /// </remarks>
        public bool GetCanWriteFlg(string toyotaFlod)
        {
            string mess = string.Empty;
            this.UoeFileStream = null;
            try
            {
                //this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);// DEL 2010/03/29
                this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);// ADD 2010/03/29
                return true;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                //this.CloseFileStream(this.UoeFileStream);// DEL 2010/03/18
                this.CloseFileStream();// ADD 2010/03/18
                return false;
            }
        }

        // ----------UPD 2010/03/18---------->>>>>
        ///// <summary>
        ///// �t�@�C���i�X�g���[���j���N���[�Y
        ///// </summary>
        ///// <param name="fs">�t�@�C����</param>
        ///// <remarks>
        ///// <br>Note       :  �t�@�C���i�X�g���[���j���N���[�Y����B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2010/03/08</br>
        ///// </remarks>
        //public void CloseFileStream(FileStream fs)
        //{
        //    if (fs != null)
        //    {
        //        fs.Close();
        //    }
        //}
        /// <summary>
        /// �t�@�C���i�X�g���[���j���N���[�Y
        /// </summary>
        /// <remarks>
        /// <br>Note       :  �t�@�C���i�X�g���[���j���N���[�Y����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void CloseFileStream()
        {
            if (UoeFileStream != null)
            {
                UoeFileStream.Close();
            }
        }
        // ----------UPD 2010/03/18----------<<<<<

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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            //string subDirStr = string.Empty;
            try
            {
                //if (!string.IsNullOrEmpty(subDir))
                //{
                //    // �T�u�t�@�C���Í����v���O�����Ăяo��
                //    status = xEncryptsFile(subDir, 1);
                //}

                count = this.GetDeleteCount();

                //�Í������s�����̓T�u�e�L�X�g�t�@�C�����쐬�ꍇ
                //if ((status != 0) || (string.IsNullOrEmpty(subDir)))
                //{
                //    subDirStr = string.Empty;
                //}
                //else
                //{
                //    subDirStr = subDir;
                //}

                // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "�X�V������";
                form.Message = "�X�V�������ł��B";
                // �_�C�A���O�\��
                form.Show();

                // �������v���O�����Ăяo��
                //UOE�ڑ�����}�X�^����ꍇ
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(2, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDir, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(2, dir, 0, string.Empty, 0, subDir, count, ref errMess);
                }

                // ----------ADD 2010/08/31----------->>>>>
                // �_�C�A���O�����
                form.Close();
                // ----------ADD 2010/08/31-----------<<<<<

                switch ((Int16)status)
                {
                    case 0:
                        {
                            errMess = "����I���B";
                            #region �񓚃e�L�X�g�̎捞����
                            UOEOrderDtlNissanAcs uOEOrderDtlNissanAcs = new UOEOrderDtlNissanAcs();

                            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
                            answerDateNissanPara.EnterpriseCode = this._enterpriseCode;
                            answerDateNissanPara.SectionCode = this._loginSectionCode;
                            answerDateNissanPara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            answerDateNissanPara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // �񓚏��̎擾���s���܂�
                            status = uOEOrderDtlNissanAcs.DoSearch(answerDateNissanPara, out errMess);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �g�����U�N�V�����f�[�^�̍쐬���s���܂�
                                status = uOEOrderDtlNissanAcs.DoConfirm(answerDateNissanPara, out errMess);
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

        // --------ADD 2011/03/15--------->>>>>
        /// <summary>
        /// UOE������}�X�^�ݒ菈���i�v���O�����F0206�̂ݗp�j
        /// </summary>
        /// <param name="uoeSupplier">UOE������}�X�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�ݒ菈������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        public void SetUOESupplier(UOESupplier uOESupplier)
        {
            this._uOESupplier = uOESupplier;
        }
        // --------ADD 2011/03/15---------<<<<<
    }
}

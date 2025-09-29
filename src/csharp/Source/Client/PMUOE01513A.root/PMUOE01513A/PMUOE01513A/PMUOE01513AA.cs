//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �g���^��������
// �v���O�����T�v   : �g���^�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �� �� ��  2009/12/31  �C�����e : �V�K�쐬
//                                  �g���^�d�q�J�^���O�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^���甭�����M�f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �C �� ��  2010/01/19  �C�����e : Redmine:2509
//                                  Redmine�w�E�����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �C �� ��  2010/01/22  �C�����e : Redmine:2586
//                                  ���א��������ƕi�Ԃ̃Z�b�g������Đݒ肳��Ă��܂��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : ������
// �C �� ��  2010/07/26  �C�����e : PM1011 �g���^���������@�����ꍇ�d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/08/31  �C�����e : Redmine#13666�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ������
// �C �� ��  2011/01/30  �C�����e : UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ������
// �C �� ��  2011/02/21  �C�����e : Redmine#19088�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/12  �C�����e : Redmine#26485�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �C �� ��  2011/12/15  �C�����e : �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI ����
// �� �� ��  2012/09/20  �C�����e : �g���^���������f�[�^�̃\�[�g�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370039-00 �쐬�S�� : 30757 ���X�؋M�p
// �C �� ��  2017/07/07  �C�����e : �g���^�VWEBUOE�Ή�
//                                  �����f�[�^�̓��͓���Byte�z���0x0d,0x0a,0x09�̕��т��܂܂��
//                                  �����WEBUOE���Ŕ����f�[�^���W�J�ł��Ȃ��s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370054-00 �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/07/12  �C�����e : �g���^�VWEBUOE���{�b�g�Ή�
//                                  �@�������M�f�[�^�T�u�t�@�C�����쐬���Ȃ��悤�ύX
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
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �g���^���������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �g���^���������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009/12/31</br>
    /// <br>Update Note : 2010/01/19 杍^</br>
    /// <br>              Redmine:2509</br>
    /// <br>              Redmine�w�E�����̑Ή�</br>
    /// <br>Update Note : 2010/01/22 杍^</br>
    /// <br>              Redmine:2586</br>
    /// <br>              ���א��������ƕi�Ԃ̃Z�b�g������Đݒ肳��Ă��܂��̑Ή�</br>
    /// <br>Update Note : 2010/07/26 ������</br>
    /// <br>              PM1011 �g���^���������@�����ꍇ�d�l�ǉ�</br>
    /// <br>Update Note : 2010/08/31 ������</br>
    /// <br>              Redmine#13666�Ή�</br>
    /// <br>Update Note : 2011/01/30 ������</br>
    /// <br>              UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
    /// <br>Update Note : 2011/02/21 ������</br>
    /// <br>              Redmine#19088�̑Ή�</br>
    /// <br>Update Note : 2011/11/29 ������</br>
    /// <br>              Redmine#7733�̑Ή�</br> 
    /// <br>Update Note: 2011/12/15 yangmj</br>
    /// <br>             �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// <br>Update Note : 2017/07/07 30757 ���X�؋M�p</br>
    /// <br>�Ǘ��ԍ�    : 11370039-00 �g���^�VWEBUOE�Ή�</br>
    /// <br>              �����f�[�^�̓��͓���Byte�z���0x0d,0x0a,0x09�̕��т��܂܂��</br>
    /// <br>              �����WEBUOE���Ŕ����f�[�^���W�J�ł��Ȃ��s��Ή�</br>
    /// <br>Update Note : 2017/07/12 30757 ���X�؋M�p</br>
    /// <br>�Ǘ��ԍ�    : 11370054-00 �g���^�VWEBUOE���{�b�g�Ή�</br>
    /// <br>              �������M�f�[�^�T�u�t�@�C�����쐬���Ȃ��悤�ύX</br>
    /// </remarks>
    public partial class OrderProcAcs
    {
        // --- ADD 2012/09/20 ---------------------------->>>>>
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
        // --- ADD 2012/09/20 ----------------------------<<<<<

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// ADD 2010/07/26

        //�A�N�Z�X�N���X
        private static OrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //�f�[�^�[�e�[�u��
        private OrderProcDataSet _dataSet;
        private OrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //�]�ƈ��}�X�^
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // �]�ƈ���� �A�N�Z�X�N���X

        //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private int setCount = 0;
        //private string remark2 = string.Empty; // �A�g�ԍ���ϐ��ɑޔ�    // ADD 2011/01/30 //DEL BY ������ on 2011/11/29 for Redmine#7733
        private List<string> remark2 = new List<string>(); // �A�g�ԍ���ϐ��ɑޔ�   //ADD BY ������ on 2011/11/29 for Redmine#7733
        private ArrayList _uOEOrderDtlWorkAL = null; //�t�n�d�����f�[�^�̃��}�[�N�Q����ʓ��͒l�֕ύX�p    // ADD 2011/02/21
        private IUOEOrderDtlDB _iUOEOrderDtlDB = null; //�t�n�d�����f�[�^�A�N�Z�X�N���X    // ADD 2011/02/21
        # endregion

        #region TelegramEditOrder0103
        /// <summary>
		/// �t�n�d���M�d���쐬���������i�g���^�o�c�S�j
		/// </summary>
        /// <remarks>
        /// <br>Update Note : 2017/07/07 30757 ���X�؋M�p</br>
        /// <br>�Ǘ��ԍ�    : 11370039-00 �g���^�VWEBUOE�Ή�</br>
        /// <br>              �����f�[�^�̓��͓���Byte�z���0x0d,0x0a,0x09�̕��т��܂܂��</br>
        /// <br>              �����WEBUOE���Ŕ����f�[�^���W�J�ł��Ȃ��s��Ή�</br>
        /// </remarks>
        public class TelegramEditOrder0103
        {

            # region Const Members
            private const Int32 ctDetailLen = 3;	//���׍s��
            private const Int32 ctSndTelegramLen = 107; //���M�d���T�C�Y
            //---ADD 2017/07/07 30757 ���X�؋M�p �g���^�VWEBUOE�Ή� ----->>>>>
            /// <summary>
            /// ���͓����v�f��
            /// </summary>
            private const byte InputDayTimeElementSize = 4;
            /// <summary>
            /// ���͓����v�f�f�t�H���g�l
            /// </summary>
            private const byte InputDayTimeElementDefault = 0x20;  
            //---ADD 2017/07/07 30757 ���X�؋M�p �g���^�VWEBUOE�Ή� -----<<<<<
            # endregion

            #region Private Members
            //�����d��
            private byte[] ttflg = new byte[1];	/*      ͯ�� �ʐM�t���O       */
            private byte[] rem3 = new byte[12];		/*           �ϰ�3            */
            private byte[] nhkb = new byte[1];		/*      	 �[�i�敪         */
            private byte[] fnhkb = new byte[1];		/*      	 ̫۰�[�i�敪     */
            private byte[] rem = new byte[8];		/*           �ϰ�1            */
            private byte[] rem2 = new byte[10];		/*           �ϰ�2            */
            private byte[] kyo = new byte[2];		/*           �w�苒�_         */
            private byte[] user = new byte[2];		/*           ���q�l�S���Һ��� */
            private byte[] skbn = new byte[1];		/*           �����敪		  */
            private byte[] nsitei = new byte[6];	/*           �[���w����@�@�@ */

            private byte[][] mkkb = new byte[ctDetailLen][];	/* ײ�      ���[�J�敪        */
            private byte[][] hb = new byte[ctDetailLen][];	/*          �i��              */
            private byte[][] hsu = new byte[ctDetailLen][];	/*          ����              */
            private byte[][] bo = new byte[ctDetailLen][];	/*          ̫۰����          */

            //�ϐ�
            private Int32 _seq = 1;
            private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            #endregion

            # region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
            public TelegramEditOrder0103()
			{
                for (int i = 0; i < ctDetailLen; i++)
				{
                    mkkb[i] = new byte[1];	//���[�J�敪
					hb[i] = new byte[14];	//�i��
					hsu[i] = new byte[5];	//����
					bo[i] = new byte[1];	//̫۰����
				}
				_seq = 1;
				Clear();
			}
            # endregion

            # region Properties
            # region SEQ�ԍ�
            /// <summary>
            /// SEQ�ԍ�
            /// </summary>
            public Int32 Seq
            {
                get
                {
                    return this._seq;
                }
                set
                {
                    this._seq = value;
                }
            }
            # endregion

            # region UOE������N���X
            /// <summary>
            /// UOE������N���X
            /// </summary>
            public UOESupplier uOESupplier
            {
                get
                {
                    return this._uOESupplier;
                }
                set
                {
                    this._uOESupplier = value;
                }
            }
            # endregion

            # region ���M�T�C�Y
            /// <summary>
            /// ���M�T�C�Y
            /// </summary>
            public Int32 SndTelegramLen
            {
                get
                {
                    return ctSndTelegramLen;
                }
            }
            # endregion
            # endregion

            # region Public Methods
            # region �f�[�^����������
            /// <summary>
            /// �f�[�^����������
            /// </summary>
            public void Clear()
            {
                _ln = 0;

                //�w�b�_�[��
                UoeCommonFnc.MemSet(ref ttflg, 0x20, ttflg.Length);		//�ʐM�t���O
                UoeCommonFnc.MemSet(ref rem3, 0x20, rem3.Length);		//���}�[�N�R
                UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		//�[�i�敪
                UoeCommonFnc.MemSet(ref fnhkb, 0x20, fnhkb.Length);		//�t�H���[�[�i�敪
                UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);			//���}�[�N�P
                UoeCommonFnc.MemSet(ref rem2, 0x20, rem2.Length);		//���}�[�N�Q
                UoeCommonFnc.MemSet(ref kyo, 0x20, kyo.Length);			//�w�苒�_
                UoeCommonFnc.MemSet(ref user, 0x20, user.Length);		//���q�l�S���҃R�[�h
                UoeCommonFnc.MemSet(ref skbn, 0x20, skbn.Length);		//�����敪
                UoeCommonFnc.MemSet(ref nsitei, 0x20, nsitei.Length);	//�[���w���

                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref mkkb[i], 0x20, mkkb[i].Length);	//���[�J�敪
                    UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//�i��
                    UoeCommonFnc.MemSet(ref hsu[i], 0x20, hsu[i].Length);	//����
                    UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);	//�t�H���[�R�[�h
                }
            }

            /// <summary>
            /// �f�[�^���׏���������
            /// </summary>
            public void ClearDetail()
            {
                _ln = 0;

                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref mkkb[i], 0x20, mkkb[i].Length);	//���[�J�敪
                    UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//�i��
                    UoeCommonFnc.MemSet(ref hsu[i], 0x20, hsu[i].Length);	//����
                    UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);	//�t�H���[�R�[�h
                }
            }

            /// <summary>
            /// �f�[�^���׏���������
            /// </summary>
            public void changeFlg()
            {
                //�ʐM�t���O
                UoeCommonFnc.MemSet(ref ttflg, 0x30, ttflg.Length);		//�ʐM�t���O
            }
            # endregion

            # region �f�[�^�ҏW����
            /// <summary>
            /// �f�[�^�ҏW����
            /// </summary>
            /// <param name="work">���[�N</param>
            /// <remarks>
            /// <br>Update Note: 2011/12/15 yangmj</br>
            /// <br>             �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
            /// <br>Update Note : 2017/07/07 30757 ���X�؋M�p</br>
            /// <br>�Ǘ��ԍ�    : 11370039-00 �g���^�VWEBUOE�Ή�</br>
            /// <br>              �����f�[�^�̓��͓���Byte�z���0x0d,0x0a,0x09�̕��т��܂܂��</br>
            /// <br>              �����WEBUOE���Ŕ����f�[�^���W�J�ł��Ȃ��s��Ή�</br>
            /// </remarks>
            public void Telegram( UOEOrderDtlWork work )
            {
                //�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
                if (_ln == 0)
                {
                    # region ���w�b�_�[����
                    //���w�b�_�[����

                    //�ʐM�t���O
                    ttflg[0] = 0x31;
                    //�ϰ�3
                    UoeCommonFnc.MemSet(ref rem3, 0x30, rem3.Length);
                    //---UPD 2017/07/07 30757 ���X�؋M�p �g���^�VWEBUOE�Ή� ----->>>>>
                    //rem3[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);		//��
                    //rem3[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	    //��
                    //rem3[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//��
                    //rem3[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//�b

                    //�g���^�VWEBUOE�ł́A0x0d,0x0a,0x09�̕��т�����Ɣ����f�[�^�Ƃ��Ď�荞�߂Ȃ���
                    //�������b�ɂ͋󔒂��Z�b�g����
                    UoeCommonFnc.MemSet( 
                          ref rem3
                        , TelegramEditOrder0103.InputDayTimeElementDefault
                        , TelegramEditOrder0103.InputDayTimeElementSize );
                    //---UPD 2017/07/07 30757 ���X�؋M�p �g���^�VWEBUOE�Ή� -----<<<<<

                    //�[�i�敪
                    UoeCommonFnc.MemCopy(ref nhkb, work.UOEDeliGoodsDiv, nhkb.Length);

                    //̫۰�[�i�敪
                    UoeCommonFnc.MemCopy(ref fnhkb, work.FollowDeliGoodsDiv, fnhkb.Length);

                    //�ϰ�1
                    UoeCommonFnc.MemCopy(ref rem, work.UoeRemark1, rem.Length);

                    //�ϰ�2
                    UoeCommonFnc.MemCopy(ref rem2, work.UoeRemark2, rem2.Length);

                    //�w�苒�_�i������}�X�^�̉��Q���j
                    UoeCommonFnc.MemCopy(ref kyo, UoeCommonFnc.GetUnderString(work.UOEResvdSection, kyo.Length), kyo.Length);

                    //���q�l�S���Һ��ށi������}�X�^�F�˗��҃R�[�h�̉��Q���j
                    UoeCommonFnc.MemCopy(ref user, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(), user.Length), user.Length);

                    //�����敪
                    skbn[0] = 0x30;

                    //�[���w���
                    UoeCommonFnc.MemSet(ref nsitei, 0x20, nsitei.Length);
                    # endregion
                }

                # region �����ו���
                //�����ו���
                if (_ln < ctDetailLen)
                {
                    //���[�J�敪
                    //Ұ������:0001�@���@��ē��e:" "(���p��߰�)
                    if (work.GoodsMakerCd == 1)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x20, mkkb[_ln].Length);
                    }
                    //Ұ������:1396�@���@��ē��e:"X"
                    else if (work.GoodsMakerCd == 1396)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x58, mkkb[_ln].Length);
                    }
                    //Ұ������:0081�@���@��ē��e:"V"
                    else if (work.GoodsMakerCd == 81)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x56, mkkb[_ln].Length);
                    }
                    else
                    {
                        //�Ȃ��B
                    }
                    //�i��
                    // ----------UPD 2010/07/26---------->>>>>
                    //UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                    //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή� ----->>>>>
                    //�n�C�t�������̏ꍇ�A�n�C�t�����폜���ăZ�b�g
                    if (this.uOESupplier != null)
                    {
                        if (this.uOESupplier.EnableOdrMakerCd1 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd1 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd1)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd2 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd2 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd2)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd3 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd3 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd3)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd4 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd4 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd4)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd5 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd5 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd5)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd6 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd6 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd6)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNo, hb[_ln].Length);
                        }
                    }
                    //----- ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή� -----<<<<<
                    //----- DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή� ----->>>>>
                    //if (work.GoodsMakerCd == 1)
                    //{
                    //    UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                    //}
                    //else
                    //{
                    //    UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNo, hb[_ln].Length);
                    //}
                    //----- DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή� -----<<<<<
                    // ----------UPD 2010/07/26----------<<<<<
                    //����
                    UoeCommonFnc.MemCopy(ref hsu[_ln], String.Format("{0:D5}", (int)work.AcceptAnOrderCnt), hsu[_ln].Length);

                    //�t�H���[�R�[�h
                    UoeCommonFnc.MemCopy(ref bo[_ln], work.BoCode, bo[_ln].Length);

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
                ms.Write(ttflg, 0, ttflg.Length);		//�ʐM�t���O
                ms.Write(rem3, 0, rem3.Length);			//���}�[�N�R
                ms.Write(nhkb, 0, nhkb.Length);			//�[�i�敪
                ms.Write(fnhkb, 0, fnhkb.Length);		//�t�H���[�[�i�敪
                ms.Write(rem, 0, rem.Length);			//���}�[�N�P
                ms.Write(rem2, 0, rem2.Length);			//���}�[�N�Q
                ms.Write(kyo, 0, kyo.Length);			//�w�苒�_
                ms.Write(user, 0, user.Length);			//���q�l�S���҃R�[�h
                ms.Write(skbn, 0, skbn.Length);			//�����敪
                ms.Write(nsitei, 0, nsitei.Length);		//�[���w���

                //���ו�
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(mkkb[i], 0, mkkb[i].Length);	//���[�J�敪
                    ms.Write(hb[i], 0, hb[i].Length);	//�i��
                    ms.Write(hsu[i], 0, hsu[i].Length);	//����
                    ms.Write(bo[i], 0, bo[i].Length);	//�t�H���[�R�[�h
                }

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

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/02/21 ������</br>
        /// <br>             Redmine#19088�̑Ή�</br>
        /// </remarks>
        private OrderProcAcs()
        {
            // �ϐ�������
            this._dataSet = new OrderProcDataSet();
            this._orderDataTable = this._dataSet.OrderExpansion;

            this.orderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB(); // ADD 2011/02/21
        }

        /// <summary>
        /// �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�t�n�d���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d���������A�N�Z�X�N���X �C���X�^���X�擾���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public static OrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new OrderProcAcs();
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

        # region �]�ƈ��}�X�^�L���b�V������
        /// <summary>
        /// �]�ƈ��}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�L���b�V���������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public OrderProcDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// �L�����͍s���ݔ���
        /// </summary>
        /// <returns>�s���݃`�F�b�N���ʁiTrue : �s���� / False : �s�Ȃ��j</returns>
        /// <remarks>
        /// <br>Note       : �L�����͍s���ݔ�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this._orderDataTable.Rows.Count > 0)
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public OrderProcDataSet.OrderExpansionDataTable orderDataTable
        {
            get { return _orderDataTable; }
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(InpDisplay inpDisplay)
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

        # region �� �t�n�d�����f�[�^ �������� ��
        /// <summary>
        /// �t�n�d�����f�[�^ ��������
        /// </summary>
        /// <param name="inpDisplay">���������N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^ �����������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 ������</br>
        /// <br>             UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        public int SearchDB(InpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {   //�O���b�h�p�e�[�u���̃N���A
                this.orderDataTable.Rows.Clear();

                //�t�n�d�����f�[�^�������A�N�Z�X�N���X�Ăяo����
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                int index = 1;

                // --- ADD 2012/09/20 ---------------------------->>>>>
                // �擾���������f�[�^���\�[�g����(�ďo�ԍ��A�ďo�ԍ��}�Ԃ̏��Ń\�[�g)
                UOEOrderDtlWorkComparer UoeComp = new UOEOrderDtlWorkComparer();
                _uOEOrderDtlWorkList.Sort(UoeComp);

                // �\�[�g���������f�[�^�̃V�[�P���X�ԍ����ŁA�d�����׃f�[�^���\�[�g����
                StockDetailWorkComparer StockComp = new StockDetailWorkComparer(_uOEOrderDtlWorkList);
                _stockDetailWorkList.Sort(StockComp);
                // --- ADD 2012/09/20 ----------------------------<<<<<

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�̊i�[
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    OrderProcDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();
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
                    // ---ADD 2011/01/30--------------->>>>
                    if ("0104".Equals(uOEOrderDtlWork.CommAssemblyId))
                    {
                        row.UoeRemark2 = uOEOrderDtlWork.UoeRemark2;
                    }
                    else
                    {
                        row.UoeRemark2 = string.Empty;
                    }
                    // ---ADD 2011/01/30---------------<<<<
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

                    this.orderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }

            return status;
        }

        #region �w�b�_�[�����͒l�̕ۑ�����
        /// <summary>
        /// �w�b�_�[�����͒l�̕ۑ�����
        /// </summary>
        /// <param name="inpHedDisplay"> �w�b�_�[�����̓N���X</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�����͒l�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 ������</br>
        /// <br>             UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
        /// </remarks>
        public void UpdtHedaerItem(InpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.orderDataTable);

            string rowFilterString = "";

            //�I�����C���ԍ�
            rowFilterString = String.Format("{0} = {1}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // �t�n�d���}�[�N�P
                dataRow[this.orderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // �t�n�d���}�[�N�Q  // ADD 2011/01/30
                dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // �]�ƈ��R�[�h
                dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // �]�ƈ�����

                dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // �[�i�敪
                dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;                // UOE�w�苒�_
                dataRow[this.orderDataTable.FollowDeliGoodsDivColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDiv;             // �g�[�i�敪
                dataRow[this.orderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // �[�i�敪����
                dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;                // UOE�w�苒�_����
                dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDivNm;             // �g�[�i�敪����
            }

        }

        # endregion

        # endregion

        #region �t�n�d�����f�[�^�폜�����擾
        /// <summary>
        /// �t�n�d�����f�[�^�폜�����擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^�폜�����擾���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>UpdateNote : 2011/02/09 �����Y</br>
        /// <br>             Redmine#18854�Ή�</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                //���M���א�
                int detailIndex = 0;
                //�O���ײݔԍ�
                int bfOnlineNo = 0;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];

                    detailIndex++;

                    if (bfOnlineNo == 0 || bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 0;
                    }
                    else
                    {
                        if (detailIndex >= 12)
                        {
                            count++;
                            bfOnlineNo = onlineNo;
                            detailIndex = 0;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            //this.setCount = count;    // DEL 2011/02/09
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
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/02/09</br>
        /// </remarks>
        public int GetCount(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int count = 0;

            //�O�񔭒��ԍ�
            int bfUOESalesOrderNo = 0;

            for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
            {
                Int32 UOESalesOrderNo = uOEOrderDtlWorkList[i].UOESalesOrderNo;

                if (bfUOESalesOrderNo == 0 || bfUOESalesOrderNo != UOESalesOrderNo)
                {
                    count++;
                    bfUOESalesOrderNo = UOESalesOrderNo;
                }
            }
            this.setCount = count;

            return count;
        }
        #endregion

        #region �t�n�d�����f�[�^�X�V����
        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="toyotaFlod">�t�H���_</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int WriteDB(int cashRegisterNo, int systemDiv, string toyotaFlod, out string message,
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
        /// <param name="toyotaFlod">�t�H���_</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2010/01/22 杍^ ���א��������ƕi�Ԃ̃Z�b�g������Đݒ肳��Ă��܂��̑Ή�</br>
        /// <br>Update Note: 2011/01/30 ������</br>
        /// <br>             UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
        /// <br>Update Note: 2011/02/09 �����Y</br>
        /// <br>             Redmine#18854�Ή�</br>
        /// <br>Update Note: 2011/02/21 ������</br>
        /// <br>             Redmine#19088�̑Ή�</br>
        /// <br>Update Note: 2011/12/15 yangmj</br>
        /// <br>             �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
        /// </remarks>
        public int WriteText(int systemDiv, string toyotaFlod, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               // List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)//DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList, UOESupplier uoeSupplier)//ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�

        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            FileStream fs = null;

            try
            {
                //  ADD 2011/02/09  >>>
                this.GetCount(uOEOrderDtlWorkList);
                //  ADD 2011/02/09  <<<

                // ---ADD 2011/02/21----------->>>>>
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                // ---ADD 2011/02/21-----------<<<<<
                    // ---ADD 2011/01/30------------------->>>>
                    DataView orderDataView = new DataView(this.orderDataTable);

                    orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                    // ������}�X�^�̃v���O�������Q�Ƃ��A���}�[�N�Q�ւ̃Z�b�g���e�ύX���s���B
                    for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                    {
                        UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                        for (int j = 0; j < orderDataView.Count; j++)
                        {
                            OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[j].Row);
                            if ((Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName] == work.OnlineNo)
                            {
                                if ("0104".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.UoeRemark2 = dataRow[this.orderDataTable.UoeRemark2Column.ColumnName].ToString().Trim();
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
                    // ---ADD 2011/01/30-------------------<<<<
                // ---ADD 2011/02/21------------------>>>>>
                    this._uOEOrderDtlWorkAL = new ArrayList(uOEOrderDtlWorkList);
                }
                // ---ADD 2011/02/21------------------<<<<<

                fs = new FileStream(toyotaFlod, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                TelegramEditOrder0103 telegramEditOrder0103 = new TelegramEditOrder0103();
                telegramEditOrder0103.uOESupplier = uoeSupplier;//ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
                byte[] tempbyte = null;
                byte[] countbyte = new byte[4];
                byte[] spacebyte = new byte[103];

                // �擪 4 Byte�F�R�R�{�X�y�[�X�{�X�y�[�X
                if (this.setCount.ToString().Length == 2)
                {
                    //UoeCommonFnc.MemCopy(ref countbyte, this.setCount.ToString(), countbyte.Length);  // DEL 2011/02/09
                    UoeCommonFnc.MemCopy(ref countbyte, this.setCount.ToString() + " " + " ", countbyte.Length);    // ADD 2011/02/09
                }
                // �擪 4 Byte�F�X�y�[�X�{�R�{�X�y�[�X�{�X�y�[�X
                else if (this.setCount.ToString().Length == 1)
                {
                    //UoeCommonFnc.MemCopy(ref countbyte, " " + this.setCount.ToString(), countbyte.Length);    // DEL 2011/02/09
                    UoeCommonFnc.MemCopy(ref countbyte, " " + this.setCount.ToString() + " " + " ", countbyte.Length);  // ADD 2011/02/09
                }

                UoeCommonFnc.MemSet(ref spacebyte, 0x20, spacebyte.Length);
                MemoryStream ms = new MemoryStream();
                ms.Write(countbyte, 0, countbyte.Length);
                ms.Write(spacebyte, 0, spacebyte.Length);
                byte[] startDatabyte = ms.ToArray();

                // �����R�[�h���i�擪 4 Byte�j�@���c��103 Byte �̓X�y�[�X�l��
                fs.Write(startDatabyte, 0, startDatabyte.Length);

                Int32 fristFlg = 0;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 1;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    //�����ԍ����ύX���ꂽ
                    if ((fristFlg != 0) && (onlineNo != work.OnlineNo))
                    {
                        tempbyte = telegramEditOrder0103.ToByteArray();

                        fs.Write(tempbyte, 0, tempbyte.Length);

                        for (int j = 0; j < 4 - dataCount; j++)
                        {
                            //�d�����׃N���X���ׂ̃N���A
                            telegramEditOrder0103.ClearDetail();
                            telegramEditOrder0103.changeFlg();

                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);
                        }

                        //�d�����׃N���X�S�ẴN���A
                        telegramEditOrder0103.Clear();
                        //���M�d��(JIS)
                        telegramEditOrder0103.Telegram(work);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                        dataCount = 1;
                    }
                    else
                    {
                        fristFlg = 1;
                        detailCount = detailCount + 1;

                        if (dataCount == 4 && detailCount == 4)
                        {
                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            telegramEditOrder0103.ClearDetail();

                            //���M�d��(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;
                            dataCount = 1;

                            onlineNo = work.OnlineNo;

                            continue;                // ADD 2010/01/22
                        }

                        if (dataCount > 4)
                        {
                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            telegramEditOrder0103.ClearDetail();

                            //���M�d��(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;
                            dataCount = 1;

                            onlineNo = work.OnlineNo;
                        }

                        if (detailCount > 3)
                        {
                            dataCount = dataCount + 1;

                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //�d�����׃N���X���ׂ̃N���A
                            telegramEditOrder0103.ClearDetail();

                            //���M�d��(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;

                            onlineNo = work.OnlineNo;
                        }
                        else
                        {
                            //���M�d��(JIS)
                            telegramEditOrder0103.Telegram(work);

                            onlineNo = work.OnlineNo;
                        }
                    }
                }

                tempbyte = telegramEditOrder0103.ToByteArray();

                fs.Write(tempbyte, 0, tempbyte.Length);

                for (int j = 0; j < 4 - dataCount; j++)
                {
                    //�d�����׃N���X���ׂ̃N���A
                    telegramEditOrder0103.ClearDetail();
                    telegramEditOrder0103.changeFlg();

                    tempbyte = telegramEditOrder0103.ToByteArray();

                    fs.Write(tempbyte, 0, tempbyte.Length);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                }
            }
            return status;
        }
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 ������</br>
        /// <br>             UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
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
            //bool firstFlg = true;//DEL BY ������ on 2011/11/12 for Redmine#26485
            string uoeRemark = string.Empty;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);

                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];

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
                            || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // ��M���t
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // ���M�t���O
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // �����t���O
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // ���M�[���ԍ�
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // UOE���}�[�N�P
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.orderDataTable.UoeRemark1Column.ColumnName].ToString().Trim();
                            //-------UPD BY ������ on 2011/11/12 for Redmine#26485 ---->>>>>>>>>
                            //if (firstFlg)
                            //{
                                // UOE���}�[�N�Q
                                uoeRemark = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                                //------UPD BY ������ on 2011/11/29 for Redmie#7733 ---->>>>>>>
                                //this.remark2 = uoeRemark; // ADD 2011/01/31
                                if (!remark2.Contains(uoeRemark))
                                {
                                    remark2.Add(uoeRemark);
                                }
                                //------UPD BY ������ on 2011/11/29 for Redmie#7733 ----<<<<<<<<
                                uOEOrderDtlWorktemp.UoeRemark2 = uoeRemark;
                            //    firstFlg = false;
                            //}
                            //else
                            //{
                            //    uOEOrderDtlWorktemp.UoeRemark2 = uoeRemark;
                            //}
                            //-------UPD BY ������ on 2011/11/12 for Redmine#26485 ----<<<<<<<<<<
                            // �[�i�敪
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // �[�i�敪����
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.orderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // �t�H���[�[�i�敪
                            uOEOrderDtlWorktemp.FollowDeliGoodsDiv = dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // �t�H���[�[�i�敪����
                            uOEOrderDtlWorktemp.FollowDeliGoodsDivNm = dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName].ToString();
                            // UOE�w�苒�_
                            uOEOrderDtlWorktemp.UOEResvdSection = dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName].ToString();
                            // UOE�w�苒�_����
                            uOEOrderDtlWorktemp.UOEResvdSectionNm = dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName].ToString();
                            // �]�ƈ��R�[�h
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            // �]�ƈ�����
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            // BO�敪
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.orderDataTable.BoCodeColumn.ColumnName].ToString().Trim();
                            // �󒍐���
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());

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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // ���ׁE�sPrimary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key�쐬

        #region �ۑ��f�[�^�`�F�b�N����
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2010/01/19 杍^ redmine#2509�Ή�</br>
        /// </remarks>
        public bool SaveDataCheck(int businessCode, int systemDivCd, out List<string> itemNameList, out List<string> itemList)
        {
            itemNameList = new List<string>();
            itemList = new List<string>();

            foreach (OrderProcDataSet.OrderExpansionRow row in this._orderDataTable)
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
                        //&& (string.IsNullOrEmpty(row.UOEDeliGoodsDiv)))               // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.UOEDeliGoodsDivNm)))              // ADD 2010/01/19
                    {
                        itemNameList.Add("�[�i�敪");
                        itemList.Add("OrderExpansion");
                    }

                    //�g�[�i�敪
                    // �����̏ꍇ
                    // �g���^�̏ꍇ
                    if ((businessCode == ctTerminalDiv_Order)
                        //&& (string.IsNullOrEmpty(row.FollowDeliGoodsDiv)))             // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.FollowDeliGoodsDivNm)))            // ADD 2010/01/19
                    {
                        itemNameList.Add("�g�[�i�敪");
                        itemList.Add("OrderExpansion");
                    }

                    //�w�苒�_
                    if ((businessCode == ctTerminalDiv_Order)
                        //&& (string.IsNullOrEmpty(row.UOEResvdSection)))              // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.UOEResvdSectionNm)))              // ADD 2010/01/19
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
        #endregion

        #region �����X�V����
        /// <summary>
        /// �����X�V����
        /// </summary>
        /// <param name="dir">�������M�f�[�^�t�@�C������</param>
        /// <param name="subDir">�������M�f�[�^�T�u�t�@�C������</param>
        /// <param name="uoeSupplier">UOE������}�X�^</param>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^</param>
        /// <param name="errMess">�G���[���b�Z�[�W</param>
        /// <param name="results">�I�����C���ԍ�results</param> //ADD BY ������ on 2011/11/29 for Redmine#7733 
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����X�V���s�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/26</br>
        /// <br>Update Note: 2010/08/31 ������</br>
        /// <br>             Redmine#13666�Ή�</br>
        /// <br>Update Note: 2011/01/30 ������</br>
        /// <br>             UOE�������Ή��A�������̃^�C�v�ǉ��ɂ��ύX</br>
        /// <br>Update Note: 2011/02/21 ������</br>
        /// <br>             Redmine#19088�̑Ή�</br>
        /// <br>Update Note : 2017/07/12 30757 ���X�؋M�p</br>
        /// <br>�Ǘ��ԍ�    : 11370054-00 �g���^�VWEBUOE���{�b�g�Ή�</br>
        /// <br>              �������M�f�[�^�T�u�t�@�C�����쐬���Ȃ��悤�ύX</br>
        /// </remarks>
        //public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)//DEL BY ������ on 2011/11/29 for Redmie#7733
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess, ref List<string> results)//ADD BY ������ on 2011/11/29 for Redmie#7733
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            string subDirStr = string.Empty;
            try
            {
                //---DEL 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� ----->>>>>
                //if (!string.IsNullOrEmpty( subDir ))
                //{
                //    // �T�u�t�@�C���Í����v���O�����Ăяo��
                //    status = xEncryptsFile(subDir, 1);
                //}
                //---DEL 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� -----<<<<<

                count = this.GetDeleteCount();

                //---DEL 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� ----->>>>>
                ////�Í������s�����̓T�u�e�L�X�g�t�@�C�����쐬�ꍇ
                //if ((status != 0) || (string.IsNullOrEmpty(subDir)))
                //{
                //    subDirStr = string.Empty;
                //}
                //else
                //{
                //    subDirStr = subDir;
                //}
                //---DEL 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� -----<<<<<

                // ----------ADD 2010/08/31----------->>>>>
                // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "�X�V������";
                form.Message = "�X�V�������ł��B";
                // �_�C�A���O�\��
                form.Show();
                // ----------ADD 2010/08/31-----------<<<<<

                // �������v���O�����Ăяo��
                //UOE�ڑ�����}�X�^����ꍇ
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(1, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDirStr, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(1, dir, 0, string.Empty, 0, subDirStr, count, ref errMess);
                }
                // ---ADD 2011/02/21-------------->>>>>
                // ������}�X�^�̃v���O�������u0104�v�̏ꍇ�APMPU9011����̖߂�l���u0�ȊO�̏ꍇ�v�A�t�n�d�����f�[�^�̃��}�[�N�Q����ʓ��͒l�֕ύX
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && "0104".Equals(uoeSupplier.CommAssemblyId))
                {
                    if (this._uOEOrderDtlWorkAL != null && this._uOEOrderDtlWorkAL.Count > 0)
                    {
                        object paraObj = this._uOEOrderDtlWorkAL as object;
                        if (this._iUOEOrderDtlDB == null)
                        {
                            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB(); // ADD 2011/02/21 
                        }
                        // �t�n�d�����f�[�^�����[�g���Ăяo���A�t�n�d�����f�[�^��ύX����B
                        this._iUOEOrderDtlDB.Write(ref paraObj);
                    }
                }
                // ---ADD 2011/02/21--------------<<<<<
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
                            UOEOrderDtlToyotaAcs uOEOrderDtlToyotaAcs = new UOEOrderDtlToyotaAcs();

                            ToyotaAnswerDatePara toyotaAnswerDatePara = new ToyotaAnswerDatePara();
                            toyotaAnswerDatePara.EnterpriseCode = this._enterpriseCode;
                            toyotaAnswerDatePara.SectionCode = this._loginSectionCode;
                            toyotaAnswerDatePara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            toyotaAnswerDatePara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // �񓚏��̎擾���s���܂�
                            // ---UPD 2011/01/30--------------->>>>
                            //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess);
                            if ("0104".Equals(uoeSupplier.CommAssemblyId))
                            {
                                // OverLoad�����ʃ��\�b�h���Ăяo���B
                                //------UPD BY ������ on 2011/11/29 for Redmie#7733 ---->>>>>>>
                                 List<string> result = new List<string>();
                                //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess, this.remark2);
                                 status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess, this.remark2, ref results);
                                //------UPD BY ������ on 2011/11/29 for Redmie#7733 ----<<<<<<<
                            }
                            else
                            {
                                // �����̃��\�b�h���Ăяo��
                                //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess);//DEL BY ������ on 2011/11/12 for Redmine#26485
                                List<string> result = new List<string>();//ADD BY ������ on 2011/11/12 for Redmine#26485
                                status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess,ref result);//ADD BY ������ on 2011/11/12 for Redmine#26485
                            }
                            // ---UPD 2011/01/30---------------<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �g�����U�N�V�����f�[�^�̍쐬���s���܂�
                                status = uOEOrderDtlToyotaAcs.DoConfirm(toyotaAnswerDatePara, out errMess);
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

        // --------ADD 2010/07/26-------->>>>>
        /// <summary>
        /// �������v���O����
        /// </summary>
        [DllImport("PMPU9011.dll")]
        public extern static int xPMPU9011(int imk, string dir, int port, string pcname, int itimeout, string sdir,int imei, ref string msg);
        
        /// <summary>
        /// �T�u�t�@�C���Í���
        /// </summary>
        [DllImport("PMPU9012.dll")]
        public extern static int xEncryptsFile(string subFileName, int flag);
        // --------ADD 2010/07/26--------<<<<<
        #endregion
    }
}

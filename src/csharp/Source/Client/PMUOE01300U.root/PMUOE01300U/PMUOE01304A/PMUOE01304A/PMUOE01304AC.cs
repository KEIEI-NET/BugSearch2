//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Controller
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/14  �C�����e : ��M�d���ŁA���l���ڂɃX�y�[�X�������Ă����ꍇ�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D
// �� �� ��  2010/06/10  �C�����e : �q�ɏ��̌����͓s�x�s��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text; // 2009/10/14 ADD


namespace Broadleaf.Application.Controller
{
    using GoodsDB = SingletonPolicy<GoodsDBAgent>;

    /// <summary>
    /// �������̍\�z�҃N���X
    /// </summary>
    public abstract class OrderInformationBuilder
    {
        #region <�ȈՃI�u�U�[�o�[/>

        /// <summary>�ȈՃI�u�U�[�o�[</summary>
        private readonly IProgressUpdatable _observer;
        /// <summary>
        /// �ȈՃI�u�U�[�o�[���擾���܂��B
        /// </summary>
        protected IProgressUpdatable Observer { get { return _observer; } }

        #endregion  // <�ȈՃI�u�U�[�o�[/>

        #region <UOE������/>

        /// <summary>UOE������</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        protected UOESupplierHelper UoeSupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE������/>

        #region <��M�d��/>

        /// <summary>��M�d���̏W����</summary>
        private readonly IAgreegate<ReceivedText> _receivedTelegramAgreegate;
        /// <summary>
        /// ��M�d���̏W���̂��擾���܂��B
        /// </summary>
        /// <value>��M�d���̏W����</value>
        protected IAgreegate<ReceivedText> ReceivedTelegramAgreegate { get { return _receivedTelegramAgreegate; } }

        #endregion  // <��M�d��/>

        #region <�d�b�����p�s�ԍ�/>

        /// <summary>�o�ד`�[�ԍ��ʂ̍s�ԍ��J�E���^�}�b�v�i�L�[�F�o�ד`�[�ԍ��j</summary>
        private readonly IDictionary<string, int> _rowNoCounterOfTelOrderMap = new Dictionary<string, int>();
        /// <summary>
        /// �o�ד`�[�ԍ��ʂ̍s�ԍ��J�E���^�}�b�v�i�L�[�F�o�ד`�[�ԍ��j���擾���܂��B
        /// </summary>
        protected IDictionary<string, int> RowNoCounterOfTelOrderMap { get { return _rowNoCounterOfTelOrderMap; } }

        /// <summary>
        /// �s�ԍ����擾���܂��B�i�d�b�����p�j
        /// </summary>
        /// <param name="uoeSectionSlipNo">�o�ד`�[�ԍ�</param>
        /// <returns>
        /// �s�ԍ�
        /// �i�{���\�b�h���ďo�����ɃC���N�������g����܂��j
        /// </returns>
        protected int GetRowNoOfTelOrder(string uoeSectionSlipNo)
        {
            if (!RowNoCounterOfTelOrderMap.ContainsKey(uoeSectionSlipNo))
            {
                RowNoCounterOfTelOrderMap.Add(uoeSectionSlipNo.Trim(), 0);
            }
            int nextRowNo = ++RowNoCounterOfTelOrderMap[uoeSectionSlipNo];
            {
                RowNoCounterOfTelOrderMap[uoeSectionSlipNo] = nextRowNo;
            }
            return nextRowNo;
        }

        #endregion  // <�d�b�����p�s�ԍ�/>

        /// <summary>
        /// �������Ɏ�M�d���̓��e���}�[�W���܂��B
        /// </summary>
        public abstract void Merge();

        #region <���O�C�����_�̑q�ɃR�[�h(�~3)�Ō������ꂽ�݌ɏ��/>

        /// <summary>���O�C�����_�̑q�ɃR�[�h(�~3)�Ō������ꂽ�݌ɏ��</summary>
        private Stock _foundStockByFindingWarehouseCode;

        /// <summary>
        /// ���O�C�����_�̑q�ɃR�[�h(�~3)�ō݌ɏ����������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>
        /// �ȉ��̏����Ō������ꂽ�݌ɏ��<br/>
        /// �E���O�C�����_�̑q�ɃR�[�h(�~3)<br/>
        /// �E��M�d���̏o�ו��i�ԍ�<br/>
        /// �E��M�d���̃��[�J�[�R�[�h<br/>
        /// �Ȃ��A�q�ɃR�[�h1�`3�̏��Ɍ������s���A�ŏ��Ɍ������ꂽ�݌ɏ���Ԃ��܂��B<br/>
        /// �܂��A�Y������݌ɏ�񂪂Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��B
        /// </returns>
        protected Stock FindStockBy3WarehouseCodes(ReceivedText receivedTelegram)
        {
            // DEL 2010/06/10 �q�ɏ��̌����͓s�x�s�� ---------->>>>>
            //if (_foundStockByFindingWarehouseCode != null) return _foundStockByFindingWarehouseCode;
            // DEL 2010/06/10 �q�ɏ��̌����͓s�x�s�� ----------<<<<<

            _foundStockByFindingWarehouseCode = GoodsDB.Instance.Policy.FindFirstStockByLoginWorkers3WarehouseCodes(
                // 2009/10/14 >>>
                //int.Parse(receivedTelegram.AnswerMakerCode),
                TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0),
                // 2009/10/14 <<<
                receivedTelegram.AnswerPartsNo
            );

            return _foundStockByFindingWarehouseCode;
        }

        #endregion  // <���O�C�����_�̑q�ɃR�[�h(�~3)�Ō������ꂽ�݌ɏ��/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        protected OrderInformationBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        )
        {
            _uoeSupplier = uoeSupplier;
            _receivedTelegramAgreegate = receivedTelegramAgreegate;
            _observer = observer;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �I�[�������폜���܂��B
        /// </summary>
        /// <param name="str">������</param>
        /// <returns>�I�[�������폜����������</returns>
        protected static string TrimEndCode(string str)
        {
            StringBuilder ret = new StringBuilder();
            {
                char[] charArray = str.ToCharArray();
                foreach (char aChar in charArray)
                {
                    if (aChar.Equals('\0')) break;
                    ret.Append(aChar);
                }
            }
            return ret.ToString();
        }
    }
}

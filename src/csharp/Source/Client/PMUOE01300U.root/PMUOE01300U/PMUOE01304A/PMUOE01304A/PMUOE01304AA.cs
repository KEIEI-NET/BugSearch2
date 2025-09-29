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
// �� �� ��  2009/10/09  �C�����e : ��M�̊Y���f�[�^�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : �����ԍ����܂�����������d���`�[�̑Ή�(MANTIS[0015563])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00  �쐬�S�� : ���O
// �� �� ��  K2021/09/22  �C�����e : PMKOBETSU-4189 ���O�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00  �쐬�S�� : 杍^
// �� �� ��  2021/12/08   �C�����e : PMKOBETSU-4202 �����d����M���� �f�[�^�Ǎ����P�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using System.Text;//ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
    using Broadleaf.Application.Common;//ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�

    /// <summary>
    /// �d���񓚃f�[�^�쐬����Controller�N���X
    /// </summary>
    public sealed class MakeStockAnswerDataAcs : OroshishoStockReceptionController
    {
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>���O���e</summary>
        private const string CtLogDataMassage = "�d���񓚃f�[�^�쐬���s:�d���⍇���ԍ�={0}";
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        #region <���̓f�[�^�̍쐬��/>

        /// <summary>���̓f�[�^�̍쐬��</summary>
        private readonly ReceiveStockAcs _inputMaker;
        /// <summary>
        /// ���̓f�[�^�̍쐬�҂��擾���܂��B
        /// </summary>
        /// <value>���̓f�[�^�̍쐬��</value>
        private ReceiveStockAcs InputMaker { get { return _inputMaker; } }

        #endregion  // <���̓f�[�^�̍쐬��/>

        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        #region <�d���⍇���ԍ�/>

        /// <summary>�d���⍇���ԍ�</summary>
        private string _uOESalesOrderNo = string.Empty;
        /// <summary>
        /// �d���⍇���ԍ����擾���܂��B
        /// </summary>
        /// <value>�d���⍇���ԍ�</value>
        public string UOESalesOrderNo { get { return _uOESalesOrderNo; } }

        /// <summary>�Ԋu</summary>
        private const string Str_Space = "/";

        /// <summary>���O�o��PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        
        /// <summary>���O�o�͋��ʕ��i</summary>
        OutLogCommon LogCommon;  

        #endregion  // <�d���⍇���ԍ�/>
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="inputMaker">���̓f�[�^�̍쐬��</param>
        public MakeStockAnswerDataAcs(
            UOESupplierHelper uoeSupplier,
            ReceiveStockAcs inputMaker
        ) : base(uoeSupplier)
        {
            _inputMaker = inputMaker;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeStockAnswerData; } }
        // 2009/10/09 Add <<<

        /// <summary>
        /// ���������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public override int Execute()
        {
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            StringBuilder str = new StringBuilder();
            string preUOESalesOrderNo = string.Empty;
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            // 1.�������̈ꊇ�擾
            IIterator<ReceivedText> receivedTextIterator = InputMaker.Product.CreateIterator();
            while (receivedTextIterator.HasNext())
            {
                ReceivedText receivedText = receivedTextIterator.GetNext();
                {
                    StockDB.Instance.Policy.AddSearchingCondition(
                        UOESupplier.RealUOESupplier.UOESupplierCd,  // UI�ł̎w�蔭����
                        int.Parse(receivedText.UOESalesOrderNo),    // �d���⍇���ԍ�
                        int.Parse(receivedText.UOESalesOrderRowNo)  // �񓚓d���Ή��s
                    );
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                    //�d���⍇�ԍ����擾
                    if (string.IsNullOrEmpty(str.ToString()))
                    {
                        str.Append(int.Parse(receivedText.UOESalesOrderNo));
                    }
                    else
                    {
                        // �d���⍇�ԍ��������̏ꍇ
                        if (preUOESalesOrderNo != receivedText.UOESalesOrderNo) str.Append(Str_Space + int.Parse(receivedText.UOESalesOrderNo));
                    }
                    preUOESalesOrderNo = receivedText.UOESalesOrderNo;
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                }
            }
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            //�d���⍇�ԍ����L���i���O�ɏo�͗p�j
            _uOESalesOrderNo = str.ToString();
            StockDB.Instance.Policy.UOESalesOrderNo = _uOESalesOrderNo;
            StockDB.Instance.Policy.UOESupplierCd = UOESupplier.RealUOESupplier.UOESupplierCd;
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            // 2010/10/19 >>>
            //int result = StockDB.Instance.Policy.Search();
            int result = StockDB.Instance.Policy.Search(InputMaker.Product);
            // 2010/10/19 <<<
            if (!result.Equals((int)Result.Code.Normal))
            {
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (StockDB.Instance.Policy.HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                    //���엚�����O��o�^
                    string logMsg = string.Format(CtLogDataMassage, _uOESalesOrderNo);
                    UoeOprtnHisLogAcs uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, result, logMsg, UOESupplier.RealUOESupplier.UOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
                return result;
            }

            IList<OrderInformationBuilder> orderInfoBuilderList = new List<OrderInformationBuilder>();
            {
                // 2.UOE�����f�[�^�̍쐬
                orderInfoBuilderList.Add(CreateUOEOrderDataBuilder());

                // 3.�d�����׃f�[�^�i�����j�̍쐬
                orderInfoBuilderList.Add(CreateStockDetailDataBuilder());

                // 4.�d���f�[�^�i�����j�̍쐬
                orderInfoBuilderList.Add(CreateStockDataBuilder());
            }
            foreach (OrderInformationBuilder orderInfoBuilder in orderInfoBuilderList)
            {
                orderInfoBuilder.Merge();
            }

            // �d���񓚃f�[�^��
            int stockAnswerDataCount = StockDB.Instance.Policy.GetUOEOrderDataCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "�d���񓚃f�[�^�쐬����",   // LITERAL:
                    stockAnswerDataCount
                ));
            }

            return (int)Result.Code.Normal;
        }

        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>
        /// CLC���O�o�͏������\�b�h
        /// </summary>
        /// <param name="pgid">�ďo�����\�b�h��</param>
        /// <param name="message">�o�̓��b�Z�[�W�{��</param>
        /// <remarks>
        /// <br>Note       : CLC���O�o�͋��ʃ��\�b�h���ďo</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public void WriteClcLogProc(string pgid, string message)
        {
            try
            {
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(pgid, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
            }
            catch
            {
                // ���O�o�͏����̂��߁A��O�͖�������
            }
        }
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        #endregion  // <Override/>

        #region <UOE�����f�[�^/>

        /// <summary>
        /// UOE�����f�[�^�̍\�z�҂𐶐����܂��B
        /// </summary>
        /// <returns>UOE�����f�[�^�̍\�z��</returns>
        private UOEOrderDataBuilder CreateUOEOrderDataBuilder()
        {
            if (UOESupplier is UOEMeijiDecorator)
            {
                return new MeijiOrderDataBuilder(UOESupplier, InputMaker.Product, this);
            }
            else
            {
                return new SPKOrderDataBuilder(UOESupplier, InputMaker.Product, this);
            }
        }

        #endregion  // <UOE�����f�[�^/>

        #region <�d�����׃f�[�^�i�����j/>

        /// <summary>
        /// �d�����׃f�[�^�i�����j�̍\�z�҂𐶐����܂��B
        /// </summary>
        /// <returns>�d�����׃f�[�^�i�����j�̍\�z��</returns>
        private OrderStockDetailDataBuilder CreateStockDetailDataBuilder()
        {
            return new OrderStockDetailDataBuilder(UOESupplier, InputMaker.Product, this);
        }

        #endregion  // <�d�����׃f�[�^�i�����j/>

        #region <�d���f�[�^�i�����j/>

        /// <summary>
        /// �d���f�[�^�i�����j�̍\�z�҂𐶐����܂��B
        /// </summary>
        /// <returns>�d���f�[�^�i�����j�̍\�z��</returns>
        private OrderStockDataBuilder CreateStockDataBuilder()
        {
            return new OrderStockDataBuilder(UOESupplier, InputMaker.Product, this);
        }

        #endregion  // <�d���f�[�^�i�����j/>
    }
}

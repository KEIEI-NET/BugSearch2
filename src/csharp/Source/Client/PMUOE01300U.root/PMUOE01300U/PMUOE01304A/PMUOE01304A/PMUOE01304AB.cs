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

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;// ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�

namespace Broadleaf.Application.Controller
{
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;

    #region <�v��f�[�^/>

    /// <summary>
    /// �v��f�[�^�쐬����Controller�N���X
    /// </summary>
    public abstract class MakeSumUpDataController : OroshishoStockReceptionController
    {
        /// <summary>DB�֏����܂Ȃ��t���O</summary>
        private bool _canNotWriting;
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>���O���e</summary>
        private const string CtLogDataMassage = "�v��f�[�^/�݌ɒ����f�[�^�쐬����:�ꊇ�X�V���s;�d���⍇���ԍ�={0}";
        /// <summary>���O�o��PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        /// <summary>���O�o�͋��ʕ��i</summary>
        OutLogCommon LogCommon;
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
        /// <summary>
        /// DB�֏����܂Ȃ��t���O�̃A�N�Z�T
        /// </summary>
        public bool CanNotWriting
        {
            get { return _canNotWriting; }
            set { _canNotWriting = value; }
        }

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        protected MakeSumUpDataController(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

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
            // DB�Ƀ}�[�W
            MergeToDB();

            // DB�֏����܂Ȃ��ꍇ�i�d���f�[�^�ƍ݌ɒ����f�[�^�𓯎��ɏ����ޏꍇ�j
            if (CanNotWriting) return (int)Result.Code.Normal;

            // DB���ꊇ�X�V
            string message = string.Empty;
            string itemInfo = string.Empty;
            int status = StockDB.Instance.Policy.Write(out message, out itemInfo);

            // ����MJNL�i�����j�̍X�V
            if (status.Equals((int)Result.RemoteStatus.Normal))
            {
                CopyUOEOrderDataToUOESendReceiveJournal();
            }
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            else
            {
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (StockDB.Instance.Policy.HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    //���엚�����O��o�^
                    UoeOprtnHisLogAcs uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    string logMsg = string.Format(CtLogDataMassage, StockDB.Instance.Policy.UOESalesOrderNo);
                    uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, StockDB.Instance.Policy.UOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
            }
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            return status;
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

        /// <summary>
        /// DB�Ƀ}�[�W���܂��B
        /// </summary>
        protected abstract void MergeToDB();

        /// <summary>
        /// UOE�����f�[�^�𑗎�MJNL�փR�s�[���܂��B
        /// </summary>
        protected void CopyUOEOrderDataToUOESendReceiveJournal()
        {
            StockDB.Instance.Policy.CopyUOEOrderDataToUOESendReceiveJournal();
        }
    }

    #endregion  // <�v��f�[�^/>

    #region <�d���f�[�^/>

    /// <summary>
    /// �d���f�[�^�쐬����Controller�N���X
    /// </summary>
    public sealed class MakeStockDataAcs : MakeSumUpDataController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public MakeStockDataAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeSumUpData; } }
        // 2009/10/09 Add <<<


        /// <summary>
        /// DB�Ƀ}�[�W���܂��B
        /// </summary>
        /// <see cref="OroshishoStockReceptionController"/>
        protected override void MergeToDB()
        {
            IList<SumUpInformationBuilder> sumUpInfoBuilderList = new List<SumUpInformationBuilder>();
            {
                // 1.�d�����׃f�[�^�i�v��j�̍쐬
                sumUpInfoBuilderList.Add(new SumUpStockDetailDataBuilder(UOESupplier));

                // 2.�d���f�[�^�i�v��j�̍쐬
                sumUpInfoBuilderList.Add(new SumUpStockDataBuilder(UOESupplier));
            }
            foreach (SumUpInformationBuilder sumUpInfoBuilder in sumUpInfoBuilderList)
            {
                sumUpInfoBuilder.Merge();
            }

            // �d���f�[�^��
            int stockDataCount = StockDB.Instance.Policy.GetSumUpStockDataCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "�d���f�[�^�쐬����",   // LITERAL:
                    stockDataCount
                ));
            }
        }

        #endregion  // <Override/>
    }

    #endregion  // <�d���f�[�^/>

    #region <�݌ɒ����f�[�^/>

    /// <summary>
    /// �݌ɒ����f�[�^�쐬����Controller�N���X
    /// </summary>
    public sealed class MakeStockAdjustAcs : MakeSumUpDataController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public MakeStockAdjustAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeStockAdjust; } }
        // 2009/10/09 Add <<<

        /// <summary>
        /// DB�Ƀ}�[�W���܂��B
        /// </summary>
        /// <see cref="OroshishoStockReceptionController"/>
        protected override void MergeToDB()
        {
            IList<SumUpInformationBuilder> sumUpInfoBuilderList = new List<SumUpInformationBuilder>();
            {
                // 1.�݌ɒ������׃f�[�^�̍쐬
                sumUpInfoBuilderList.Add(new SumUpStockAdjustDetailBuilder(UOESupplier));

                // 2.�݌ɒ����f�[�^�̍쐬
                sumUpInfoBuilderList.Add(new SumUpStockAdjustBuilder(UOESupplier));
            }
            foreach (SumUpInformationBuilder sumUpInfoBuilder in sumUpInfoBuilderList)
            {
                sumUpInfoBuilder.Merge();
            }

            // �݌ɒ����f�[�^��
            int stockAdjustCount = StockDB.Instance.Policy.GetSumUpStockAdjustCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "�݌ɒ����f�[�^�쐬����",   // LITERAL:
                    stockAdjustCount
                ));
            }
        }

        #endregion  // <Override/>
    }

    #endregion  // <�݌ɒ����f�[�^/>
}

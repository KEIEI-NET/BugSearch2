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
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : ���N�n��
// �� �� ��  2013/08/15  �C�����e : ������M����(�蓮)�����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB = SingletonPolicy<StockDBAgent>;
    using Broadleaf.Application.Resources;
    using Broadleaf.Application.Common;
    using System.Threading;

    /// <summary>
    /// �񓚕\��Controller�N���X
    /// </summary>
    /// <br>Update Note: 2013/08/15 ���N�n��</br>
    /// <br>             ������M����(�蓮)�����̒ǉ�</br>
    public sealed class ShowAnswerAcs : OroshishoStockReceptionController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public ShowAnswerAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.ShowAnswer; } }
        // 2009/10/09 Add <<<



        // ---- ADD 2013/08/15 杍^ ---- >>>>>
        //Thread���A�񓚕\���֌W
        private const string ORDERSNDRCVJNLLISTTRD = "ORDERSNDRCVJNLLIST";
        private LocalDataStoreSlot orderSndRcvJnlListTrd = null;
        //Thread���A���b�Z�[�W�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 杍^ ---- <<<<<

        /// <summary>
        /// ���������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        public override int Execute()
        {
            try
            {
                List<OrderSndRcvJnl> orderSndRcvJnlList = StockDB.Instance.Policy.OrderSndRcvJnlList;

                // ---- ADD 2013/08/15 杍^ ---- >>>>>
                //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
                fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    this._opt_FuTaBa = (int)Option.ON;
                }
                else
                {
                    this._opt_FuTaBa = (int)Option.OFF;
                }
                //�t�^�oUSB��p
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);

                    //������M����(�蓮)�ł���ꍇ
                    if (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 4)
                    {
                        Thread.FreeNamedDataSlot(ORDERSNDRCVJNLLISTTRD);
                        orderSndRcvJnlListTrd = Thread.AllocateNamedDataSlot(ORDERSNDRCVJNLLISTTRD);
                        Thread.SetData(orderSndRcvJnlListTrd, orderSndRcvJnlList);
                    }
                    else
                    {
                        Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                            orderSndRcvJnlList
                        );
                        {
                            answerView.ShowDialog();    // ���[�_���ŕ\��
                        }
                    }
                }
                else
                {
                    Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                      orderSndRcvJnlList
                    );
                    {
                        answerView.ShowDialog();    // ���[�_���ŕ\��
                    }
                }
                // ---- ADD 2013/08/15 杍^ ---- <<<<<
                // ---- DEL 2013/08/15 杍^ ---- >>>>>
                //Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                //    orderSndRcvJnlList
                //);
                //{
                //    answerView.ShowDialog();    // ���[�_���ŕ\��
                //}
                // ---- DEL 2013/08/15 杍^ ---- <<<<<

                return (int)Result.Code.Normal;
            }
            catch (Exception e)
            {
                Debug.Assert(false, e.ToString());
                return (int)Result.Code.Error;
            }
        }

        #endregion  // <Override/>
    }
}

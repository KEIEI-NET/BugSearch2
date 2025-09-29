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

using System;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using SupplierDB    = SingletonPolicy<SupplierDBAgent>;

    /// <summary>
    /// �v����̍\�z�҃N���X
    /// </summary>
    public abstract class SumUpInformationBuilder
    {
        #region <UOE����M�����̍ė��p���i/>

        /// <summary>UOE����M�����̍ė��p���i</summary>
        private readonly UOESendReceiveComponent _uoeSndRcvComponent;
        /// <summary>
        /// UOE����M�����̍ė��p���i���擾���܂��B
        /// </summary>
        /// <value>UOE����M�����̍ė��p���i</value>
        protected UOESendReceiveComponent UoeSndRcvComponent { get { return _uoeSndRcvComponent; } }

        #endregion  // <UOE����M�����̍ė��p���i/>

        #region <UOE������/>

        /// <summary>UOE������</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        protected UOESupplierHelper UoeSupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE������/>

        /// <summary>
        /// �v����ɔ������̓��e���}�[�W���܂��B
        /// </summary>
        public abstract void Merge();

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        protected SumUpInformationBuilder(UOESupplierHelper uoeSupplier)
        {
            _uoeSndRcvComponent = new UOESendReceiveComponent();
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �������_�ݒ�敪�̗񋓑�
        /// </summary>
        protected enum DistSectionSetDiv : int
        {
            /// <summary>�d����}�X�^</summary>
            Supplier = 0,
            /// <summary>�����f�[�^</summary>
            OrderData = 1,
            /// <summary>���Ѓ}�X�^</summary>
            LoginSection = 2
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^�̉������_�ݒ�ɏ]���A���_�R�[�h���擾���܂��B
        /// </summary>
        /// <returns>
        /// �d����}�X�^�F������}�X�^�̎d����R�[�h�ɑ΂���d����}�X�^��̊Ǘ����_<br/>
        /// �����f�[�^�@�F�v�㌳�@��<c>string.Empty</c>��Ԃ��܂��B<br/>
        /// ���Ѓ}�X�^�@�F���O�C���S���҂̏������_�R�[�h�i�]�ƈ��ݒ�}�X�^�j
        /// </returns>
        protected string GetSectionCodeFromUOESetting()
        {
            string sectionCode = string.Empty;

            switch (LoginWorkerAcs.Instance.Policy.UOESetting.DistSectionSetDiv)
            {
                case (int)DistSectionSetDiv.Supplier:       // �d����}�X�^
                {
                    Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
                    if (supplier != null)
                    {
                        sectionCode = supplier.MngSectionCode;
                    }
                    break;
                }
                case (int)DistSectionSetDiv.OrderData:      // �����f�[�^
                    sectionCode = string.Empty;
                    break;
                case (int)DistSectionSetDiv.LoginSection:   // ���Ѓ}�X�^
                    sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    break;
            }

            return sectionCode;
        }
    }
}

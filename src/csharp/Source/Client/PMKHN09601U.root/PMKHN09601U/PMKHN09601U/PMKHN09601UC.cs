//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���Ǘ��}�X�^
// �v���O�����T�v   : �L�����y�[���Ǘ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���Ǘ��}�X�����K�C�h�R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ǘ��}�X�����Ŏg�p����e��A�N�Z�X�N���X�𐧌䂷��N���X�ł��B</br>
    /// <br>           : �i�����t�h�ƕҏW�t�h�ŋ��L���܂��B�j</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009/05/28</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class CampaignMngGuideControl
    {
        # region [�t�B�[���h]
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���_�R�[�h
        private string _sectionCode;

        // ���_���ݒ�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;
        // ���_���A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;
        // ���_���f�B�N�V���i��
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // BL�R�[�h�A�N�Z�X�N���X
        private BLGoodsCdAcs _bLGoodsCdAcs;
        // ���[�J�[�A�N�Z�X�N���X
        private MakerAcs _makerAcs;
        //// ���Ӑ���A�N�Z�X�N���X
        //private CustomerSearchAcs _customerSearchAcs;
        //// ���Ӑ�K�C�h���ʃN���X
        //private CustomerSearchRet _customerGuideRet;
        //// ���Ӑ�K�C�h�t�h
        //private PMKHN04005UA _customerSearchForm;
        //// �d����A�N�Z�X�N���X
        //private SupplierAcs _supplierAcs;
        //// ���i�A�N�Z�X�N���X
        private GoodsAcs _goodsAcs;
        // �L�����y�[���ݒ�A�N�Z�X�N���X
        private CampaignStAcs _campaignStAcs;
        # endregion

        # region [�v���p�e�B]
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// ���_�A�N�Z�X
        /// </summary>
        public SecInfoSetAcs SecInfoSetAcs
        {
            get
            {
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                return _secInfoSetAcs;
            }
        }

        /// <summary>
        /// ���_�f�B�N�V���i��
        /// </summary>
        public Dictionary<string, SecInfoSet> SecInfoSetDic
        {
            get
            {
                if ( _secInfoSetDic == null )
                {
                    ReadSecInfoSet();
                }
                return _secInfoSetDic;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�A�N�Z�X
        /// </summary>
        public BLGoodsCdAcs BLGoodsCdAcs
        {
            get
            {
                if ( _bLGoodsCdAcs == null )
                {
                    _bLGoodsCdAcs = new BLGoodsCdAcs();
                }
                return _bLGoodsCdAcs;
            }
        }

        /// <summary>
        /// ���[�J�[�A�N�Z�X
        /// </summary>
        public MakerAcs MakerAcs
        {
            get
            {
                if ( _makerAcs == null )
                {
                    _makerAcs = new MakerAcs();
                }
                return _makerAcs;
            }
        }

        ///// <summary>
        ///// ���Ӑ挟���A�N�Z�X
        ///// </summary>
        //public CustomerSearchAcs CustomerSearchAcs
        //{
        //    get
        //    {
        //        if ( _customerSearchAcs == null )
        //        {
        //            _customerSearchAcs = new CustomerSearchAcs();
        //        }
        //        return _customerSearchAcs;
        //    }
        //}

        ///// <summary>
        ///// ���Ӑ挟���K�C�h�t�h
        ///// </summary>
        //public PMKHN04005UA CustomerSearchForm
        //{
        //    get
        //    {
        //        _customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
        //        _customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler( this.CustomerSearchForm_CustomerSelect );

        //        _customerGuideRet = null;
        //        return _customerSearchForm;
        //    }
        //}

        ///// <summary>
        ///// ���Ӑ挟���K�C�h����
        ///// </summary>
        //public CustomerSearchRet CustomerGuideRet
        //{
        //    get { return _customerGuideRet; }
        //}

        ///// <summary>
        ///// �d����A�N�Z�X
        ///// </summary>
        //public SupplierAcs SupplierAcs
        //{
        //    get
        //    {
        //        if ( _supplierAcs == null )
        //        {
        //            _supplierAcs = new SupplierAcs();
        //        }
        //        return _supplierAcs;
        //    }
        //}

        /// <summary>
        /// ���i�A�N�Z�X
        /// </summary>
        public GoodsAcs GoodsAcs
        {
            get
            {
                if ( _goodsAcs == null )
                {
                    _goodsAcs = new GoodsAcs();
                }
                return _goodsAcs;
            }
        }

        /// <summary>
        /// �L�����y�[���ݒ�A�N�Z�X�N���X
        /// </summary>
        public CampaignStAcs CampaignStAcs
        {
            get
            {
                if (_campaignStAcs == null)
                {
                    _campaignStAcs = new CampaignStAcs();
                }
                return _campaignStAcs;
            }
        }

        # endregion

        # region [�C�x���g]
        /// <summary>
        /// �ŐV���擾��C�x���g
        /// </summary>
        public event EventHandler AfterRenewal;
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CampaignMngGuideControl( string enterpriseCode, string sectionCode )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;

            // �ŐV���擾
            RenewalProc();

            // ���ŐV���擾�C�x���g�𔭍s���Ȃ�
        }
        # endregion

        # region [public���\�b�h]
        /// <summary>
        /// �ŐV���擾
        /// </summary>
        public void Renewal()
        {
            // �ŐV���擾
            RenewalProc();

            // �ŐV���擾��C�x���g���s
            if ( this.AfterRenewal != null )
            {
                AfterRenewal( this, new EventArgs() );
            }
        }
        # endregion

        # region [private���\�b�h]
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_���}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            if ( _secInfoAcs == null )
            {
                _secInfoAcs = new SecInfoAcs();
            }
            this._secInfoAcs.ResetSectionInfo();

            foreach ( SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList )
            {
                if ( secInfoSet.LogicalDeleteCode == 0 )
                {
                    this._secInfoSetDic.Add( secInfoSet.SectionCode.Trim(), secInfoSet );
                }
            }
        }
        
        ///// <summary>
        ///// ���Ӑ�I���K�C�h�{�^���N���b�N
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        //private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
        //    if ( customerSearchRet == null ) return;
        //    // �K�C�h���ʂ�private�t�B�[���h�ɑޔ�
        //    _customerGuideRet = customerSearchRet;
        //}
        /// <summary>
        /// �ŐV���擾
        /// </summary>
        private void RenewalProc()
        {
            // �����o������
            _secInfoSetAcs = null;
            _secInfoAcs = null;
            _secInfoSetDic = null;
            _bLGoodsCdAcs = null;
            _makerAcs = null;
            //_customerSearchAcs = null;
            //_customerGuideRet = null;
            //_customerSearchForm = null;
            //_supplierAcs = null;
            _goodsAcs = null;
            _campaignStAcs = null;
            
            // ���_�f�B�N�V���i������
            ReadSecInfoSet();

            // ���i�A�N�Z�X�N���X��������
            string msg;
            GoodsAcs.SearchInitial( _enterpriseCode, _sectionCode, out msg );
        }
        # endregion
    }
}

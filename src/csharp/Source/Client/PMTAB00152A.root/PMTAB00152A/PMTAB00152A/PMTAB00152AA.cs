//****************************************************************************//
// �V�X�e��         : PMTAB �����񓚏���(�f�[�^�o�^)
// �v���O��������   : PMTAB �����񓚏���(�f�[�^�o�^)�A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : qijh
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note     : �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�                     //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/06/10                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37330 �S�̐ݒ�擾�ł��Ȃ��ꍇ�I�������悤�ɕύX //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37389 ���גǉ����̍쐬��⑫                   //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/27                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37389 �󒍃}�X�^(�ԗ�)�̑���Ɏԗ��Ǘ��f�[�^���쐬//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/28                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37474 �`�[��������̒ǉ�                         //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/29                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37692 �y�����񓚏���(�f�[�^�o�^)�zSCM�A�g        //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/02                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37585 ���������f�[�^���쐬                       //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/02                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37586 �`�[���������ǉ�                           //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/03                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37980 SCM���׉񓚂̍s�ԍ������̔ԂɏC��          //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/08                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38015 ����o�^��ASCM�󒍃f�[�^�iSCMACODRDATARF�j//
//                   �̃^�u���b�g�g�p�敪�Ɂu1�v���Z�b�g����Ă��܂���        //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38014 SCM�A�g���ꂽ���Ӑ�Ŕ��㎞�A              //
//                   �Ԏ�ƌ^����SF���ŕ\������Ȃ�                           //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37586 ���גǉ����̃f�[�^�o�^�����C��           //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38128 �^�u���b�g����f�[�^�̔��f�敪���C��       //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/10                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38220 �s�K�v�ȃ��O�o�͂̍폜                     //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/11                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38246 �y�����񓚏���(�f�[�^�o�^)�z���`�F�b�N     //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38277�y�����񓚏���(�f�[�^�o�^)�z�^�M�`�F�b�N�ǉ�//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38166 ����p�i�Ԃ̐���Ɋւ��Ẳ��C             //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38166 ����p�i�Ԃ̃f�B�t�H���g�l��ݒ�           //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/17                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38541 �y�����񓚏���(�f�[�^�o�^)�z�^�M�`�F�b�N   //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/17                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38565 ����A���㖾�ׁA�����f�[�^�Z�b�g���e��ύX //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/18                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38510 BL���i�R�[�h���̊|����BL�R�[�h���̔��p�ɐݒ�//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38783 �y�����񓚏���(�f�[�^�o�^)�z�^���̃Z�b�g�d�l�ύX//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : �w�E�m�F�����ꗗ��373�Ή��@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �g��                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38198 ����œ]�ŕ�������ېł̏ꍇ�A���v���z���u0�v//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �g��                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38811 �y�����񓚏���(�f�[�^�o�^)�zSCM�֘A���ڂ̃f�[�^�Z�b�g�ύX//
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/20                                               //
//----------------------------------------------------------------------------//
// Update Note     : �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565     //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �g��                                                     //
// Date            : 2013/07/22                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38979  �s�l�����̃f�[�^�Z�b�g���������Ȃ�        //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38980 �e�����̒[��������ǉ�����                 //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39024 �s�l�����̔��㕔�i���v�i�ō��j ���㕔�i���v�i�Ŕ����j�̐ݒ�   //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : �A����					                                  //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39027 �s�l�����̏���Œ[������������������܂��� //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2					                                  //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39028 �s�l�����̒l������������������܂���       //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2					                                  //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39026 �s�l�����̔��㕔�i���v(�ō�)���C��         //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39166 �l���s�̋��z���v�Z����Ă��܂���           //
// �Ǘ��ԍ�        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/25                                               //
//----------------------------------------------------------------------------//
// Update Note     : �Г��w�E�ꗗ��431 �񓚍쐬�敪�������l�Őݒ肳��Ă��܂� //
// �Ǘ��ԍ�        :                                                          //
// Programmer      : ����                                                     //
// Date            : 2013/07/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : �Г��w�E�ꗗ��433 �󒍂̎��ɂ�SCM�󒍃f�[�^���쐬����Ă��܂� //
// �Ǘ��ԍ�        :                                                          //
// Programmer      : ����                                                     //
// Date            : 2013/07/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : ���O������
// �Ǘ��ԍ�        : 
// Programmer      : �g��
// Date            : 2013/07/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39686 
// �Ǘ��ԍ�        : 
// Programmer      : �g��
// Date            : 2013/08/07
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39780
// �Ǘ��ԍ�        : 
// Programmer      : �g��
// Date            : 2013/08/08
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39649 �f�[�^�o�^���ɑ��엚�����O���o�͂���
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : ����
// Date            : 2013/08/08
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39649 �f�[�^�o�^���ɑ��엚�����O���o�͂���
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : ����
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39780 �Ή��̖߂�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39820
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39942 ����S�̐ݒ�D�`�[�쐬���@�̔��f�Ɠ`�[����
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/14
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 �񓚏������i�ԍ��̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39972 �f�[�^�o�^�ASCM���M��A�^�u���b�g�֒ʒm��Ԃ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39992 ������z�����敪�̎擾���@�̕ύX�ɔ����C��
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/19
//----------------------------------------------------------------------------//
// Update Note     : �^�u���b�g����̔���o�^���A"���M��"�E�B���h�E���\���ɂ���
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/28
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40121 �ʒm���M�C���@�ʒm���[�h�ǉ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : ����
// Date            : 2013/08/26
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40121 30�b�^�C�}�[�͏풓�����ōs���̂ō폜
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �O��
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40183 �������i���[�J�[�R�[�h�̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : ����
// Date            : 2013/08/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 �񓚏������i�ԍ��̐ݒ�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : �`�[�����s��Ή�
// �Ǘ��ԍ�        : 10902622-01
// Programmer      : �g��
// Date            : 2013/09/11
//----------------------------------------------------------------------------//
// Update Note     : Redmine #40342 �����[�g�`�[���s���G���[�Ή�
// �Ǘ��ԍ�        : 
// Programmer      : 30744 ����
// Date            : 2013/09/19
//----------------------------------------------------------------------------//
// Update Note     : Redmine #49164 �`�[�d���o�^�Ή�
// �Ǘ��ԍ�        : 11370016-00
// Programmer      : ���O
// Date            : 2017/03/30
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
// ADD 2013/08/08 Redmine#39649 ---------------------------------->>>>>
using Broadleaf.Application.Controller.Facade;
// ADD 2013/08/08 Redmine#39649 ----------------------------------<<<<<


namespace Broadleaf.Application.Controller
{
    using SlipPrtSetServer = SingletonInstance<SlipPrtSetAgent>;   // �`�[����ݒ�}�X�^ // ADD 2013/07/03 qijh Redmine#37586

    /// <summary>
    /// PMTAB �����񓚏���(�f�[�^�o�^)�A�N�Z�X�N���X
    /// </summary>
    public partial class TabSCMSalesDataMaker
    {
        #region �� �v���C�x�[�g�����o�[
        /// <summary>
        /// �I�����C����ʋ敪(SCM)
        /// </summary>
        private const int ONLINEKINDDIV_SCM = 10;

        /// <summary>
        /// BLP���M�敪(���M)
        /// </summary>
        private const int BLPSENDDIVRF_1 = 1;

        /// <summary>
        /// �N���p�����[�^
        /// </summary>
        private string _startParam;

        /// <summary>
        /// ���Ӑ���擾�p�A�N�Z�X
        /// </summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>
        /// SCMDB��PMTAB������擾�p�����[�g
        /// </summary>
        private IPmTabSalesSlipDB _iPmTabSalesSlipDB;

        /// <summary>
        /// ���[�U�[DB��PMTAB�󒍃}�X�^(�ԗ�)�擾�p�����[�g
        /// </summary>
        private IPmTabAcpOdrCarDB _iPmTabAcpOdrCarDB;

        /// <summary>
        /// ������o�^�p�����[�g
        /// </summary>
        private IIOWriteControlDB _iIOWriteControlDB;

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�����[�g
        /// </summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;

        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------>>>>>
        /// <summary>
        /// ������t���O
        /// </summary>
        private bool _printThreadOverFlag = true;

        /// <summary>
        /// ������t���O
        /// </summary>
        public void GetPrintThreadOverFlag(out bool printThreadOverFlag)
        {
            printThreadOverFlag = this._printThreadOverFlag;
        }

        /// <summary>
        /// �`�[����t���O
        /// </summary>
        private bool _printSlipFlag = true;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>
        /// ���_�R�[�h(�S��)
        /// </summary>
        private const string ctSectionCode = "00";

        /// <summary>
        /// ����`�[�ԍ������l
        /// </summary>
        private static readonly string ctDefaultSalesSlipNum = string.Empty.PadLeft(9, '0');

        /// <summary>
        /// ����`�[����L�[���(key:�`�[�ԍ� value:�󒍃X�e�[�^�X,�ۑ��O�`�[�ԍ�)
        /// </summary>
        private Dictionary<string, SlipPrintInfoValue> _printSalesKeyInfo;
        
        /// <summary>
        /// �󒍓`�[����L�[���(key:�`�[�ԍ� value:�󒍃X�e�[�^�X,�ۑ��O�`�[�ԍ�)
        /// </summary>
        private Dictionary<string, SlipPrintInfoValue> _printAcptKeyInfo;

        /// <summary>
        /// SCM���M�t���O
        /// </summary>
        private bool _isConnScm;

        /// <summary>
        /// QR��������
        /// </summary>
        private SalesQRSendCtrlCndtn _qrMakeCndtn;

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^
        /// </summary>
        private EstimateDefSet _estimateDefSet;

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^
        /// </summary>
        private EstimateDefSet EstimateDefSet
        {
            get
            {
                if (null == this._estimateDefSet) GetEstimateDefSet();
                return this._estimateDefSet;
            }
        }

        /// <summary>
        /// ����S�̐ݒ�
        /// </summary>
        private SalesTtlSt _salesTtlSt;

        /// <summary>
        /// ����S�̐ݒ�
        /// </summary>
        private SalesTtlSt SalesTtlSt
        {
            get
            {
                if (null == this._salesTtlSt) GetSalesTtlSt();
                return _salesTtlSt;
            }
        }

        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^
        /// </summary>
        private AcptAnOdrTtlSt _acptAnOdrTtlSt;

        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^
        /// </summary>
        private AcptAnOdrTtlSt AcptAnOdrTtlSt
        {
            get
            {
                if (null == this._acptAnOdrTtlSt) GetAcptAnOdrTtlSt();
                return _acptAnOdrTtlSt;
            }
        }
        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------<<<<<

        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// PM�^�u���b�g���i����DB�����[�g
        /// </summary>
        private IPmtPartsSearchDB _iPmtPartsSearchDB;

        /// <summary>
        /// PM�^�u���b�g���i����DB�����[�g
        /// </summary>
        private IPmtPartsSearchDB IPmtPartsSearchDB
        {
            get
            {
                if (null == this._iPmtPartsSearchDB)
                    this._iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
                return this._iPmtPartsSearchDB;
            }
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�i���_�ʁj�A�N�Z�X
        /// </summary>
        private PmTabTtlStSecAcs _pmTabTtlStSecAcs;

        /// <summary>
        /// PMTAB�S�̐ݒ�i���_�ʁj�A�N�Z�X
        /// </summary>
        private PmTabTtlStSecAcs PmTabTtlStSecAcs
        {
            get
            {
                if (null == this._pmTabTtlStSecAcs)
                    this._pmTabTtlStSecAcs = new PmTabTtlStSecAcs();
                return this._pmTabTtlStSecAcs;
            }
        }

        /// <summary>
        /// PMTAB�S�̐ݒ�i���_�ʁj�}�X�^
        /// </summary>
        private PmTabTtlStSec _pmTabTtlStSec;

        /// <summary>
        /// PMTAB�S�̐ݒ�i���_�ʁj�}�X�^
        /// </summary>
        private PmTabTtlStSec PmTabTtlStSec
        {
            get
            {
                if (null == this._pmTabTtlStSec) GetPmTabTtlStSec(out this._pmTabTtlStSec);
                return this._pmTabTtlStSec;

            }
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        private const string CLASS_NAME = "TabSCMSalesDataMaker";
        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        private SalesPriceCalculate _salesPriceCalculate;//ADD  2013/07/24 wangl2 FOR Redmine#39028
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- >>>>>
        private List<SalesProcMoney> _salesProcMoneyList;

        /// <summary>
        /// // ������z�����敪�ݒ�}�X�^
        /// </summary>
        private List<SalesProcMoney> SalesProcMoneyList
        {
            get
            {
                if (null == this._salesProcMoneyList) this.ReadInitDataNinth(this._enterpriseCode, this._loginSectionCode, out this._salesProcMoneyList);
                return this._salesProcMoneyList;

            }
        }
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- <<<<<

        // ADD 2013/08/08 Redmine#39649 ----------------------------------------------->>>>>
        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g

        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("PMTAB00152A", this);
                }
                return _operationAuthority;
            }
        }

        // ADD 2013/08/08 Redmine#39649 -----------------------------------------------<<<<<

        // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
        /// <summary>
        /// �񓚑��M�����N�����ɁA�^�u���b�g����̋N����`����ׂ̈���
        /// </summary>
        private const string CMD_LINE_FOR_PMSCM01100_TABLET = "TABLET";
        // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<

        #region DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜
        // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 --------------------------------->>>>>
        //// ADD 2013/08/26 Redmine#40121 -------------------------------------------------------->>>>>
        //private string _sectionCode;    // ���_�R�[�h
        //private string _sessionId;      // �Z�b�V����ID
        //// ADD 2013/08/26 Redmine#40121 --------------------------------------------------------<<<<<
        // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 ---------------------------------<<<<<
        #endregion

        #endregion

        #region �� �R���X�g���N�^�[
        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public TabSCMSalesDataMaker(string startParam)
        {
            this._startParam = startParam;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = false; // �T�[�o�[�Q��
            _salesPriceCalculate = new SalesPriceCalculate();//ADD  2013/07/24 wangl2 FOR Redmine#39028
            this._iPmTabSalesSlipDB = MediationPmTabSalesSlipDB.GetPmTabSalesSlipDB();
            //this._iPmTabAcpOdrCarDB = MediationAcceptOdrCarDB.GetAcceptOdrCarDB();// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�
            this._iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();// ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�
            this._iIOWriteControlDB = MediationIOWriteControlDB.GetIOWriteControlDB();
            this._iPmTabTtlStCustDB = MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        #endregion

        #region �� �C���^�[�t�F�[�X
        /// <summary>
        /// �񓚂��s��
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="psSectionCode">���_�R�[�h</param>
        /// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="outErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="outCustomerInfo">���Ӑ���</param>
        /// <returns>�X�e�[�^�X</returns>
        public ConstantManagement.MethodResult Reply(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "Reply";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(�f�[�^�o�^)�����@�J�n����������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(�f�[�^�o�^)�����@�J�n��");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            EasyLogger.Write(CLASS_NAME, methodName,
                "��ƃR�[�h�F" + psEnterpriseCode
                + "�@���_�R�[�h�F" + psSectionCode
                + "�@�Ɩ��Z�b�V����ID�F" + psBusinessSessionId
                );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            #region DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜
            // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 --------------------------------->>>>>
            //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
            //// �^�C�}�[�N��
            //this._sectionCode = psSectionCode;
            //this._sessionId = psBusinessSessionId;
            //TimerCallback timerDelegate = new TimerCallback(NotifyTabletByPublish);
            //Timer timer = new Timer(timerDelegate, null, 0, 30000);
            //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
            // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 ---------------------------------<<<<<
            #endregion

            outErrorMessage = string.Empty;
            outCustomerInfo = null;
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                status = ReplyProc(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage, out outCustomerInfo);
            }
            catch(Exception ex)
            {
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
                outErrorMessage = ex.Message;
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            }

            // ADD 2013/08/16 �g�� Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �G���[�̏ꍇ�͂����Œʒm
            if((int)status != 0)
            {
                this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
            }
            // ADD 2013/08/16 �g�� Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜
            // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 --------------------------------->>>>>
            //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
            //// �^�C�}�[�X���b�h�I��
            //timer.Dispose();
            //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
            // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 ---------------------------------<<<<<
            #endregion

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(�f�[�^�o�^)�����@�I������������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(�f�[�^�o�^)�����@�I����");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return status;
        }

        #region DEL 2013/07/03 qijh Redmine#37586
        // ------------- DEL 2013/07/03 qijh Redmine#37586 ---------- >>>>>
        ///// <summary>
        ///// �񓚂��s��
        ///// </summary>
        ///// <param name="psEnterpriseCode">��ƃR�[�h</param>
        ///// <param name="psSectionCode">���_�R�[�h</param>
        ///// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        ///// <param name="outErrorMessage">�G���[���b�Z�[�W</param>
        ///// <param name="outCustomerInfo">���Ӑ���</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private ConstantManagement.MethodResult ReplyProc(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        //{
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    const string methodName = "ReplyProc";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        //    outErrorMessage = string.Empty;
        //    outCustomerInfo = null;

        //    // �p�����[�^�`�F�b�N
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
        //    //    return ConstantManagement.MethodResult.ctFNC_ERROR;
        //    if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �p�����[�^�`�F�b�N ConstantManagement.MethodResult.ctFNC_ERROR");
        //        return ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<


        //    // SCM_DB��PMTAB����f�[�^�APMTAB���㖾�׃f�[�^���擾
        //    PmTabSalesSlipWork pmTabSalesSlip;
        //    PmTabSalesDtCarWork pmTabSalesDtCar;
        //    List<PmTabSaleDetailWork> pmTabSaleDetailList;
        //    ConstantManagement.MethodResult status = GetPmTabSalesSlip(psEnterpriseCode, psSectionCode, psBusinessSessionId,
        //        out pmTabSalesSlip, out pmTabSaleDetailList, out pmTabSalesDtCar, out outErrorMessage);
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "SCM_DB��PMTAB����f�[�^�APMTAB���㖾�׃f�[�^�擾�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //        return status;
        //    }
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<


        //    // USER_DB��PMTAB�󒍃}�X�^�i�ԗ��j���擾
        //    PmTabAcpOdrCarWork pmTabAcpOdrCar;
        //    status = GetPmTabAcpOdrCar(psEnterpriseCode, psSectionCode, psBusinessSessionId, out pmTabAcpOdrCar, out outErrorMessage);
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� USER_DB��PMTAB�󒍃}�X�^�i�ԗ��j�擾�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
        //        return status;
        //    }
        //    if (pmTabAcpOdrCar != null)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "USER_DB PMTAB�󒍃}�X�^�i�ԗ��j"
        //            + "�@���[�J�[�R�[�h�F" + pmTabAcpOdrCar.MakerCode.ToString()
        //            + "�@�Ԏ�R�[�h�F" + pmTabAcpOdrCar.ModelCode.ToString()
        //            + "�@�Ԏ�T�u�R�[�h�F" + pmTabAcpOdrCar.ModelSubCode.ToString()
        //            + "�@�^���w��ԍ��F" + pmTabAcpOdrCar.ModelDesignationNo.ToString()
        //            + "�@�ޕʔԍ��F" + pmTabAcpOdrCar.CategoryNo.ToString()
        //            + "�@�^���i�t���^�j�F" + pmTabAcpOdrCar.FullModel
        //            );
        //    }
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            
        //    // ���Ӑ�����擾
        //    CustomerInfo customerInfo = null;
        //    status = GetCustomerInfo(pmTabSalesSlip.EnterpriseCode, pmTabSalesSlip.CustomerCode, out customerInfo, out outErrorMessage);
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ���Ӑ�����擾 ConstantManagement.MethodResult�F" + status.ToString());
        //        return status;
        //    }
        //    if (customerInfo != null)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "���Ӑ���"
        //            + "�@���Ӑ�R�[�h�F" + customerInfo.CustomerCode
        //            + "�@���Ӑ於�F" + customerInfo.Name
        //            );
        //    }
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        //    outCustomerInfo = customerInfo;


        //    // BLP���M�敪���擾
        //    int sendingDiv = 0;
        //    status = GetBLPSendingDiv(psEnterpriseCode, customerInfo.CustomerCode, out sendingDiv, out outErrorMessage);
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� BLP���M�敪���擾 ConstantManagement.MethodResult�F" + status.ToString());
        //        return status;
        //    }
        //    EasyLogger.Write(CLASS_NAME, methodName, "BLP���M�敪�F" + sendingDiv.ToString());
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<


        //    CustomSerializeArrayList salesScmCustArrayList = new CustomSerializeArrayList(); // �o�^�����[�g�p�̃p�����[�^
        //    // ����f�[�^���쐬
        //    SalesSlipWork updSalesSlip = GetUpdSalesSlip(pmTabSalesSlip);
        //    salesScmCustArrayList.Add(updSalesSlip);
        //    // ����f�[�^�␳
        //    ReviseSalesSlip(updSalesSlip, customerInfo);


        //    // ���㖾�׃f�[�^���쐬
        //    ArrayList updSalesDetailList = new ArrayList();
        //    foreach (PmTabSaleDetailWork pmTabSalesDetail in pmTabSaleDetailList)
        //        updSalesDetailList.Add(GetUpdSalesDetail(pmTabSalesDetail, ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv));
        //    salesScmCustArrayList.Add(updSalesDetailList);
        //    // ���㖾�׃f�[�^�␳
        //    foreach (SalesDetailWork salesDetail in updSalesDetailList)
        //        ReviseSalesDetail(updSalesSlip, salesDetail);

            
        //    // �ԗ��Ǘ��f�[�^���쐬
        //    ArrayList updAcceptOdrCarList = new ArrayList();
        //    //AcceptOdrCarWork updAcceptOdrCar = GetUpdAcceptOdrCar(pmTabAcpOdrCar); // DEL 2013/06/28 qijh Redmine#37389
        //    CarManagementWork updAcceptOdrCar = GetUpdCarManagement(pmTabAcpOdrCar, pmTabSalesSlip, customerInfo); // ADD 2013/06/28 qijh Redmine#37389
        //    updAcceptOdrCarList.Add(updAcceptOdrCar);
        //    salesScmCustArrayList.Add(updAcceptOdrCarList);


        //    // ���גǉ������쐬
        //    salesScmCustArrayList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList
        //        , updAcceptOdrCar  // ADD 2013/06/28 qijh Redmine#37389
        //        )); // ADD 2013/06/27 qijh Redmine#37389

        //    this._isConnScm = false; // ADD 2013/06/29 qijh Redmine#37474

        //    // SCM�񓚏����쐬
        //    if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv)
        //    {
        //        // �I�����C���敪��10�iSCM�j����BLP���M�敪���u�P�F���M����v�̏ꍇ
        //        this._isConnScm = true; // ADD 2013/06/29 qijh Redmine#37474

        //        // SCM�󒍃f�[�^���쐬
        //        SCMAcOdrDataWork updSCMAcOdrData = GetUpdSCMAcOdrData(updSalesSlip, customerInfo);
        //        salesScmCustArrayList.Add(updSCMAcOdrData);


        //        // SCM�󒍖��׃f�[�^�i�񓚁j���쐬
        //        ArrayList updSCMAcOdrDtlAsList = new ArrayList();
        //        foreach (SalesDetailWork salesDetail in updSalesDetailList)
        //            updSCMAcOdrDtlAsList.Add(GetUpdSCMAcOdrDtlAs(salesDetail, customerInfo));
        //        salesScmCustArrayList.Add(updSCMAcOdrDtlAsList);
        //        // SCM�󒍖��׃f�[�^�i�񓚁j�␳
        //        for (int index = 0; index < updSalesDetailList.Count; index++)
        //            ((SCMAcOdrDtlAsWork)updSCMAcOdrDtlAsList[index]).PmPrsntCount = GetPmPrsntCount(updSalesSlip, (SalesDetailWork)updSalesDetailList[index]);// PM���݌ɐ�

                
        //        // SCM�󒍃f�[�^�i�ԗ����j���쐬
        //        SCMAcOdrDtCarWork updSCMAcOdrDtCar = GetUpdSCMAcOdrDtCar(updAcceptOdrCar, updSalesSlip, pmTabSalesDtCar, customerInfo
        //            , pmTabAcpOdrCar       // ADD 2013/06/28 qijh Redmine#37389
        //            );
        //        salesScmCustArrayList.Add(updSCMAcOdrDtCar);
        //    }

        //    // --------------- ADD START 2013/07/02 wangl2 FOR Redmine#37585------>>>>
        //    SearchDepsitMain depsitMain = null;                             // �����f�[�^�I�u�W�F�N�g
        //    SearchDepositAlw depositAlw = null;                             // ���������f�[�^�I�u�W�F�N�g
        //    if ((updSalesDetailList != null) && (updSalesDetailList.Count != 0))
        //    {
        //        this.GetCurrentDepsitMain(ref updSalesSlip, out depsitMain, out depositAlw);
        //    }
        //    if (updSalesSlip.AccRecDivCd == 0)
        //    {
        //        salesScmCustArrayList.Add(ParamDataFromUIData(depsitMain)); // �����f�[�^�ǉ�
        //        salesScmCustArrayList.Add((DepositAlwWork)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlw, typeof(DepositAlwWork)));
        //    }
        //    // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<

        //    // �f�[�^�o�^
        //    status = Write(ref salesScmCustArrayList, out outErrorMessage);
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �f�[�^�o�^�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
        //        return status;
        //    }
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<


        //    // SCM�֑��M
        //    SendScmData(GetSCMAcOdrDtlAsFromApRet(salesScmCustArrayList));
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        //    // �`�[���
        //    PrintSlipMain(salesScmCustArrayList, customerInfo); // ADD 2013/06/29 qijh Redmine#37474

        //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //}
        // ------------- DEL 2013/07/03 qijh Redmine#37586 ---------- <<<<<
        #endregion DEL 2013/07/03 qijh Redmine#37586

        /// <summary>
        /// �񓚂��s��
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="psSectionCode">���_�R�[�h</param>
        /// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="outErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="outCustomerInfo">���Ӑ���</param>
        /// <returns>�X�e�[�^�X</returns>
        private ConstantManagement.MethodResult ReplyProc(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        {
            const string methodName = "ReplyProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            outErrorMessage = string.Empty;
            outCustomerInfo = null;

            // �p�����[�^�`�F�b�N
            if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �p�����[�^�`�F�b�N ConstantManagement.MethodResult.ctFNC_ERROR");
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // ADD 2013/08/01 �O�� Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // ���[�J�[���X�g�擾
            InitMaker(psEnterpriseCode);
            // ADD 2013/08/01 �O�� Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // SCM_DB��PMTAB����f�[�^�APMTAB���㖾�׃f�[�^���擾
            PmTabSalesSlipWork pmTabSalesSlip;
            PmTabSalesDtCarWork pmTabSalesDtCar;
            List<PmTabSaleDetailWork> pmTabSaleDetailList;
            ConstantManagement.MethodResult status = GetPmTabSalesSlip(psEnterpriseCode, psSectionCode, psBusinessSessionId,
                out pmTabSalesSlip, out pmTabSaleDetailList, out pmTabSalesDtCar, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "SCM_DB��PMTAB����f�[�^�APMTAB���㖾�׃f�[�^�擾�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return status;
            }


            // USER_DB��PMTAB�󒍃}�X�^�i�ԗ��j���擾
            PmTabAcpOdrCarWork pmTabAcpOdrCar;
            status = GetPmTabAcpOdrCar(psEnterpriseCode, psSectionCode, psBusinessSessionId, out pmTabAcpOdrCar, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� USER_DB��PMTAB�󒍃}�X�^�i�ԗ��j�擾�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
                return status;
            }
            if (pmTabAcpOdrCar != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "USER_DB PMTAB�󒍃}�X�^�i�ԗ��j"
                    + "�@���[�J�[�R�[�h�F" + pmTabAcpOdrCar.MakerCode.ToString()
                    + "�@�Ԏ�R�[�h�F" + pmTabAcpOdrCar.ModelCode.ToString()
                    + "�@�Ԏ�T�u�R�[�h�F" + pmTabAcpOdrCar.ModelSubCode.ToString()
                    + "�@�^���w��ԍ��F" + pmTabAcpOdrCar.ModelDesignationNo.ToString()
                    + "�@�ޕʔԍ��F" + pmTabAcpOdrCar.CategoryNo.ToString()
                    + "�@�^���i�t���^�j�F" + pmTabAcpOdrCar.FullModel
                    );
            }
           
            // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38277------>>>>
            if (pmTabSalesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
            {
                if (CheckCredit(pmTabSalesSlip))
                {
                    status = ConstantManagement.MethodResult.ctFNC_ERROR;
                    outErrorMessage = "�^�M���x�z�𒴂��Ă���ׁA�o�^�ł��܂���B";
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + outErrorMessage + status.ToString());
                    return status;

                }
            }
            // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38277--------<<<<
            // ���Ӑ�����擾
            CustomerInfo customerInfo = null;
            status = GetCustomerInfo(pmTabSalesSlip.EnterpriseCode, pmTabSalesSlip.CustomerCode, out customerInfo, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ���Ӑ�����擾 ConstantManagement.MethodResult�F" + status.ToString());
                return status;
            }
            if (customerInfo != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "���Ӑ���"
                    + "�@���Ӑ�R�[�h�F" + customerInfo.CustomerCode
                    + "�@���Ӑ於�F" + customerInfo.Name
                    );
            }
            outCustomerInfo = customerInfo;


            // BLP���M�敪���擾
            int sendingDiv = 0;
            // UPD �g�� 2013/08/09 Redmine#39820 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //status = GetBLPSendingDiv(psEnterpriseCode, customerInfo.CustomerCode, out sendingDiv, out outErrorMessage);
            //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            //{
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� BLP���M�敪���擾 ConstantManagement.MethodResult�F" + status.ToString());
            //    return status;
            //}
            //EasyLogger.Write(CLASS_NAME, methodName, "BLP���M�敪�F" + sendingDiv.ToString());
            #endregion
            if (pmTabSaleDetailList != null && pmTabSaleDetailList.Count > 0)
            {
                // �S���ׂɓ����l���ݒ肳��Ă���̂ŁA1�s�ڂ�ݒ�
                sendingDiv = pmTabSaleDetailList[0].AutoAnswerDivSCM;
            }
            // UPD �g�� 2013/08/09 Redmine#39820 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // SCM�A�g��
            this._isConnScm = false;
            // UPD 2013/07/26 yugami �Г��w�E�ꗗ��433�Ή� ---------------------------------------------->>>>>
            //if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv)
            if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv && pmTabSalesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatus.Sales)
            // UPD 2013/07/26 yugami �Г��w�E�ꗗ��433�Ή� ----------------------------------------------<<<<<
                this._isConnScm = true;


            // ����f�[�^���쐬
            SalesSlip updSalesSlip = GetUpdSalesSlip(pmTabSalesSlip);
            // ����f�[�^�␳
            ReviseSalesSlip(updSalesSlip, customerInfo);
            // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38246------>>>>
            if (!this.CheckAddUp(psSectionCode, pmTabSalesSlip.CustomerCode, updSalesSlip.AddUpADate, out outErrorMessage))
            {
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
                EasyLogger.Write(CLASS_NAME, methodName, methodName + outErrorMessage + status.ToString());
                return status;
            }
            // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38246--------<<<<

            // ���㖾�׃f�[�^���쐬
            List<SalesDetail> updSalesDetailList = new List<SalesDetail>();
            for (int i = 0; i < pmTabSaleDetailList.Count; i++)
                //updSalesDetailList.Add(GetUpdSalesDetail(pmTabSaleDetailList[i], ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv));// DEL 2013/07/20 wangl2 FOR Redmine#38811
                updSalesDetailList.Add(GetUpdSalesDetail(pmTabSaleDetailList[i], this._isConnScm));// ADD 2013/07/20 wangl2 FOR Redmine#38811
            // ���㖾�׃f�[�^�␳
            // --------------- DEL START 2013/07/23 wangl2 FOR Redmine#38979------>>>>
            //foreach (SalesDetail salesDetail in updSalesDetailList)
            //    ReviseSalesDetail(updSalesSlip, salesDetail);
            // --------------- DEL END 2013/07/23 wangl2 FOR Redmine#38979--------<<<<
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38979------>>>>
            foreach (SalesDetail salesDetail in updSalesDetailList)
            {
                // ����`�[�敪�i���ׁj�� �l���ꍇ
                if (salesDetail.SalesSlipCdDtl != 2)
                {
                    ReviseSalesDetail(updSalesSlip, salesDetail);
                }  
            }
            // --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38979--------<<<<

            // �ԗ��Ǘ��f�[�^���쐬
            CarManagementWork carManagement = GetUpdCarManagement(pmTabAcpOdrCar, pmTabSalesSlip, customerInfo);


            // --------------------- UPD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
            // ����Z�b�V����ID�����݃t���O
            bool sameSessionIdFlg = false;
            // PMTAB�Z�b�V�����Ǘ��f�[�^���쐬
            ArrayList pmtabSeesionMngList = GetSessionMngWork(pmTabSalesSlip);
            
            // �`�[�������s��
            //CustomSerializeArrayList salesScmCustArrayList = SplitSlipData(updSalesSlip, updSalesDetailList, carManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo);
            CustomSerializeArrayList salesScmCustArrayList = SplitSlipData(updSalesSlip, updSalesDetailList, carManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo, pmtabSeesionMngList);
            // �f�[�^�o�^
            //status = Write(ref salesScmCustArrayList, out outErrorMessage);
            status = Write(ref salesScmCustArrayList, out sameSessionIdFlg, out outErrorMessage);

            if (sameSessionIdFlg)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
                // �^�u���b�g�֒ʒm
                this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �f�[�^�o�^�����ŃG���[���������܂��� ConstantManagement.MethodResult�F" + status.ToString());
                return status;
            }

            // SCM�֑��M
            SendScmData(salesScmCustArrayList);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");

            // ADD 2013/08/16 �g�� Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �^�u���b�g�֒ʒm
            this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
            // ADD 2013/08/16 �g�� Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // �`�[���
            PrintSlipMain(salesScmCustArrayList, customerInfo);

            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion �� �C���^�[�t�F�[�X

        #region �� �`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N���s��
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="psSectionCode">���_�R�[�h</param>
        /// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="outErrorMessage">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK�@false:�`�F�b�NNG</returns>
        private bool IsCheckParamOK(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "IsCheckParamOK";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            outErrorMessage = "Not Found";
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //if (null == psEnterpriseCode || null == psSectionCode || null == psBusinessSessionId)
            //    return false;
            //if (string.IsNullOrEmpty(psEnterpriseCode.Trim()) || string.IsNullOrEmpty(psSectionCode.Trim()) || string.IsNullOrEmpty(psBusinessSessionId.Trim()))
            //    return false;
            if (null == psEnterpriseCode || null == psSectionCode || null == psBusinessSessionId)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "�p�����[�^�`�F�b�N�@�G���["
                    + " psEnterpriseCode�F" + psEnterpriseCode
                    + " psSectionCode�F" + psSectionCode
                    + " psBusinessSessionId�F" + psBusinessSessionId
                );
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return false;
            }
            if (string.IsNullOrEmpty(psEnterpriseCode.Trim()) || string.IsNullOrEmpty(psSectionCode.Trim()) || string.IsNullOrEmpty(psBusinessSessionId.Trim()))
            {
                EasyLogger.Write(CLASS_NAME, methodName, "�p�����[�^�`�F�b�N�@�G���["
                    + " psEnterpriseCode�F" + psEnterpriseCode
                    + " psSectionCode�F" + psSectionCode
                    + " psBusinessSessionId�F" + psBusinessSessionId
                );
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return false;
            }
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            outErrorMessage = string.Empty;
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return true;
        }

        // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38246------>>>>
        /// <summary>
        /// �����X�V�A���X�V�`�F�b�N
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="prevTotalDay">�����</param>
        /// <param name="outErrorMessage">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        private bool CheckAddUp(string sectionCode, int customerCode, DateTime prevTotalDay, out string outErrorMessage)
        {
            outErrorMessage = string.Empty;
            // �����Z�o���W���[��
            TotalDayCalculator _totalDayCalculator = TotalDayCalculator.GetInstance();
            // �����X�V�`�F�b�N(���ς݂ł����true���Ԃ��Ă���)
            if (_totalDayCalculator.CheckMonthlyAccRec(sectionCode, customerCode, prevTotalDay))
            {
                outErrorMessage = "�O�񌎎��X�V���ȑO�ׁ̈A�o�^�ł��܂���B";
                return false;
            }
            // ���X�V�`�F�b�N(���ς݂ł����true���Ԃ��Ă���)
            if (_totalDayCalculator.CheckDmdC(sectionCode, customerCode, prevTotalDay))
            {
                outErrorMessage = "�O�񐿋������ȑO�ׁ̈A�o�^�ł��܂���B";
                return false;
            }
            return true;
        }
        // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38246--------<<<<

        // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38277------>>>>
        /// <summary>
        /// �^�M�z�`�F�b�N
        /// </summary>
        /// <param name="pmTabSalesSlipWork"></param>
        /// <returns>true:�������~ false:�������s</returns>
        private bool CheckCredit(PmTabSalesSlipWork pmTabSalesSlipWork)
        {
            // �^�M�z�`�F�b�N�t���O
            bool Flag = false;
            CustomerChange customerChange;
            CustomerChangeAcs customerChangeAcs = new CustomerChangeAcs();
            int status = customerChangeAcs.Read(out customerChange, this._enterpriseCode, pmTabSalesSlipWork.ClaimCode);
            if (status != 0)
                //return true;// DEL 2013/07/17 wangl2 FOR Redmine#38541
                return Flag;// ADD 2013/07/17 wangl2 FOR Redmine#38541
            CustomerInfo claim;
            status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, pmTabSalesSlipWork.ClaimCode, true, false, out claim);
            if (status != 0)
                return true;
            if ((customerChange != null) &&
                (customerChange.CustomerCode != 0) &&
                (claim.CreditMngCode != 0))
            {
                // ���v���z + ���ݔ��|�c��
                long salesTotalTaxInc = 0;
                if (pmTabSalesSlipWork.SalesSlipNum == ctDefaultSalesSlipNum)
                {
                    salesTotalTaxInc = pmTabSalesSlipWork.SalesTotalTaxInc + customerChange.PrsntAccRecBalance;
                }
                else
                {
                    salesTotalTaxInc = customerChange.PrsntAccRecBalance;
                }

                // �^�M���x�z�`�F�b�N
                if ((salesTotalTaxInc > customerChange.CreditMoney) &&
                    (customerChange.CreditMoney != 0))
                {
                    Flag = true;
                }
            }
            return Flag;
        }
        // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38277--------<<<<
        #endregion �� �`�F�b�N����

        #region �� ����f�[�^�쐬
        /// <summary>
        /// ����f�[�^���쐬
        /// </summary>
        /// <param name="pmTabSalesSlip">PMTAB����f�[�^</param>
        /// <returns>����f�[�^</returns>
        //private SalesSlipWork GetUpdSalesSlip(PmTabSalesSlipWork pmTabSalesSlip) // DEL 2013/07/03 qijh Redmine#37586
        private SalesSlip GetUpdSalesSlip(PmTabSalesSlipWork pmTabSalesSlip) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetUpdSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // SalesSlipWork retSalesSlip = new SalesSlipWork(); // DEL 2013/07/03 qijh Redmine#37586
            SalesSlip retSalesSlip = new SalesSlip(); // ADD 2013/07/03 qijh Redmine#37586
            retSalesSlip.EnterpriseCode = pmTabSalesSlip.EnterpriseCode; // ��ƃR�[�h
            retSalesSlip.UpdEmployeeCode = pmTabSalesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            retSalesSlip.UpdAssemblyId1 = pmTabSalesSlip.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            retSalesSlip.UpdAssemblyId2 = pmTabSalesSlip.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            retSalesSlip.LogicalDeleteCode = pmTabSalesSlip.LogicalDeleteCode; // �_���폜�敪
            retSalesSlip.AcptAnOdrStatus = pmTabSalesSlip.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            retSalesSlip.SalesSlipNum = pmTabSalesSlip.SalesSlipNum; // ����`�[�ԍ�
            retSalesSlip.SectionCode = pmTabSalesSlip.SectionCode; // ���_�R�[�h
            retSalesSlip.SubSectionCode = pmTabSalesSlip.SubSectionCode; // ����R�[�h
            retSalesSlip.DebitNoteDiv = pmTabSalesSlip.DebitNoteDiv; // �ԓ`�敪
            retSalesSlip.DebitNLnkSalesSlNum = pmTabSalesSlip.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
            retSalesSlip.SalesSlipCd = pmTabSalesSlip.SalesSlipCd; // ����`�[�敪
            retSalesSlip.SalesGoodsCd = pmTabSalesSlip.SalesGoodsCd; // ���㏤�i�敪
            retSalesSlip.AccRecDivCd = pmTabSalesSlip.AccRecDivCd; // ���|�敪
            retSalesSlip.SalesInpSecCd = pmTabSalesSlip.SalesInpSecCd; // ������͋��_�R�[�h
            retSalesSlip.DemandAddUpSecCd = pmTabSalesSlip.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            retSalesSlip.ResultsAddUpSecCd = pmTabSalesSlip.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            retSalesSlip.UpdateSecCd = pmTabSalesSlip.UpdateSecCd; // �X�V���_�R�[�h
            retSalesSlip.SalesSlipUpdateCd = pmTabSalesSlip.SalesSlipUpdateCd; // ����`�[�X�V�敪
            retSalesSlip.SearchSlipDate = pmTabSalesSlip.SearchSlipDate; // �`�[�������t
            retSalesSlip.ShipmentDay = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.ShipmentDay); // �o�ד��t
            retSalesSlip.SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.SalesDate); // ������t
            retSalesSlip.AddUpADate = pmTabSalesSlip.AddUpADate; // �v����t
            retSalesSlip.DelayPaymentDiv = pmTabSalesSlip.DelayPaymentDiv; // �����敪
            retSalesSlip.EstimateFormNo = pmTabSalesSlip.EstimateFormNo; // ���Ϗ��ԍ�
            retSalesSlip.EstimateDivide = pmTabSalesSlip.EstimateDivide; // ���ϋ敪
            retSalesSlip.InputAgenCd = pmTabSalesSlip.InputAgenCd; // ���͒S���҃R�[�h
            retSalesSlip.InputAgenNm = pmTabSalesSlip.InputAgenNm; // ���͒S���Җ���
            retSalesSlip.SalesInputCode = pmTabSalesSlip.SalesInputCode; // ������͎҃R�[�h
            retSalesSlip.SalesInputName = pmTabSalesSlip.SalesInputName; // ������͎Җ���
            retSalesSlip.FrontEmployeeCd = pmTabSalesSlip.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            retSalesSlip.FrontEmployeeNm = pmTabSalesSlip.FrontEmployeeNm; // ��t�]�ƈ�����
            retSalesSlip.SalesEmployeeCd = pmTabSalesSlip.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            retSalesSlip.SalesEmployeeNm = pmTabSalesSlip.SalesEmployeeNm; // �̔��]�ƈ�����
            retSalesSlip.TotalAmountDispWayCd = pmTabSalesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
            retSalesSlip.TtlAmntDispRateApy = pmTabSalesSlip.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            retSalesSlip.SalesTotalTaxInc = pmTabSalesSlip.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            retSalesSlip.SalesTotalTaxExc = pmTabSalesSlip.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
            retSalesSlip.SalesPrtTotalTaxInc = pmTabSalesSlip.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
            retSalesSlip.SalesPrtTotalTaxExc = pmTabSalesSlip.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
            retSalesSlip.SalesWorkTotalTaxInc = pmTabSalesSlip.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
            retSalesSlip.SalesWorkTotalTaxExc = pmTabSalesSlip.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
            retSalesSlip.SalesSubtotalTaxInc = pmTabSalesSlip.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
            retSalesSlip.SalesSubtotalTaxExc = pmTabSalesSlip.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
            retSalesSlip.SalesPrtSubttlInc = pmTabSalesSlip.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
            retSalesSlip.SalesPrtSubttlExc = pmTabSalesSlip.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
            retSalesSlip.SalesWorkSubttlInc = pmTabSalesSlip.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
            retSalesSlip.SalesWorkSubttlExc = pmTabSalesSlip.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
            retSalesSlip.SalesNetPrice = pmTabSalesSlip.SalesNetPrice; // ���㐳�����z
            retSalesSlip.SalesSubtotalTax = pmTabSalesSlip.SalesSubtotalTax; // ���㏬�v�i�Łj
            retSalesSlip.ItdedSalesOutTax = pmTabSalesSlip.ItdedSalesOutTax; // ����O�őΏۊz
            retSalesSlip.ItdedSalesInTax = pmTabSalesSlip.ItdedSalesInTax; // ������őΏۊz
            retSalesSlip.SalSubttlSubToTaxFre = pmTabSalesSlip.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
            retSalesSlip.SalesOutTax = pmTabSalesSlip.SalesOutTax; // ������z����Ŋz�i�O�Łj
            retSalesSlip.SalAmntConsTaxInclu = pmTabSalesSlip.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
            retSalesSlip.SalesDisTtlTaxExc = pmTabSalesSlip.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
            retSalesSlip.ItdedSalesDisOutTax = pmTabSalesSlip.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
            retSalesSlip.ItdedSalesDisInTax = pmTabSalesSlip.ItdedSalesDisInTax; // ����l�����őΏۊz���v
            retSalesSlip.ItdedPartsDisOutTax = pmTabSalesSlip.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
            retSalesSlip.ItdedPartsDisInTax = pmTabSalesSlip.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
            retSalesSlip.ItdedWorkDisOutTax = pmTabSalesSlip.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
            retSalesSlip.ItdedWorkDisInTax = pmTabSalesSlip.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
            retSalesSlip.ItdedSalesDisTaxFre = pmTabSalesSlip.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
            retSalesSlip.SalesDisOutTax = pmTabSalesSlip.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
            retSalesSlip.SalesDisTtlTaxInclu = pmTabSalesSlip.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
            retSalesSlip.PartsDiscountRate = pmTabSalesSlip.PartsDiscountRate; // ���i�l����
            retSalesSlip.RavorDiscountRate = pmTabSalesSlip.RavorDiscountRate; // �H���l����
            retSalesSlip.TotalCost = pmTabSalesSlip.TotalCost; // �������z�v
            retSalesSlip.ConsTaxLayMethod = pmTabSalesSlip.ConsTaxLayMethod; // ����œ]�ŕ���
            retSalesSlip.ConsTaxRate = pmTabSalesSlip.ConsTaxRate; // ����Őŗ�
            retSalesSlip.FractionProcCd = pmTabSalesSlip.FractionProcCd; // �[�������敪
            retSalesSlip.AccRecConsTax = pmTabSalesSlip.AccRecConsTax; // ���|�����
            retSalesSlip.AutoDepositCd = pmTabSalesSlip.AutoDepositCd; // ���������敪
            retSalesSlip.AutoDepositSlipNo = pmTabSalesSlip.AutoDepositSlipNo; // ���������`�[�ԍ�
            retSalesSlip.DepositAllowanceTtl = pmTabSalesSlip.DepositAllowanceTtl; // �����������v�z
            retSalesSlip.DepositAlwcBlnce = pmTabSalesSlip.DepositAlwcBlnce; // ���������c��
            retSalesSlip.ClaimCode = pmTabSalesSlip.ClaimCode; // ������R�[�h
            retSalesSlip.ClaimSnm = pmTabSalesSlip.ClaimSnm; // �����旪��
            retSalesSlip.CustomerCode = pmTabSalesSlip.CustomerCode; // ���Ӑ�R�[�h
            retSalesSlip.CustomerName = pmTabSalesSlip.CustomerName; // ���Ӑ於��
            retSalesSlip.CustomerName2 = pmTabSalesSlip.CustomerName2; // ���Ӑ於��2
            retSalesSlip.CustomerSnm = pmTabSalesSlip.CustomerSnm; // ���Ӑ旪��
            retSalesSlip.HonorificTitle = pmTabSalesSlip.HonorificTitle; // �h��
            retSalesSlip.OutputNameCode = pmTabSalesSlip.OutputNameCode; // �����R�[�h
            retSalesSlip.OutputName = pmTabSalesSlip.OutputName; // ��������
            retSalesSlip.CustSlipNo = pmTabSalesSlip.CustSlipNo; // ���Ӑ�`�[�ԍ�
            retSalesSlip.SlipAddressDiv = pmTabSalesSlip.SlipAddressDiv; // �`�[�Z���敪
            retSalesSlip.AddresseeCode = pmTabSalesSlip.AddresseeCode; // �[�i��R�[�h
            retSalesSlip.AddresseeName = pmTabSalesSlip.AddresseeName; // �[�i�於��
            retSalesSlip.AddresseeName2 = pmTabSalesSlip.AddresseeName2; // �[�i�於��2
            retSalesSlip.AddresseePostNo = pmTabSalesSlip.AddresseePostNo; // �[�i��X�֔ԍ�
            retSalesSlip.AddresseeAddr1 = pmTabSalesSlip.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            retSalesSlip.AddresseeAddr3 = pmTabSalesSlip.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            retSalesSlip.AddresseeAddr4 = pmTabSalesSlip.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            retSalesSlip.AddresseeTelNo = pmTabSalesSlip.AddresseeTelNo; // �[�i��d�b�ԍ�
            retSalesSlip.AddresseeFaxNo = pmTabSalesSlip.AddresseeFaxNo; // �[�i��FAX�ԍ�
            retSalesSlip.PartySaleSlipNum = pmTabSalesSlip.PartySaleSlipNum; // �����`�[�ԍ�
            retSalesSlip.SlipNote = pmTabSalesSlip.SlipNote; // �`�[���l
            retSalesSlip.SlipNote2 = pmTabSalesSlip.SlipNote2; // �`�[���l�Q
            retSalesSlip.SlipNote3 = pmTabSalesSlip.SlipNote3; // �`�[���l�R
            retSalesSlip.RetGoodsReasonDiv = pmTabSalesSlip.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            retSalesSlip.RetGoodsReason = pmTabSalesSlip.RetGoodsReason; // �ԕi���R
            retSalesSlip.RegiProcDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.RegiProcDate); // ���W������
            retSalesSlip.CashRegisterNo = pmTabSalesSlip.CashRegisterNo; // ���W�ԍ�
            retSalesSlip.PosReceiptNo = pmTabSalesSlip.PosReceiptNo; // POS���V�[�g�ԍ�
            retSalesSlip.DetailRowCount = pmTabSalesSlip.DetailRowCount; // ���׍s��
            retSalesSlip.EdiSendDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.EdiSendDate); // �d�c�h���M��
            retSalesSlip.EdiTakeInDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.EdiTakeInDate); // �d�c�h�捞��
            retSalesSlip.UoeRemark1 = pmTabSalesSlip.UoeRemark1; // �t�n�d���}�[�N�P
            retSalesSlip.UoeRemark2 = pmTabSalesSlip.UoeRemark2; // �t�n�d���}�[�N�Q
            retSalesSlip.SlipPrintDivCd = pmTabSalesSlip.SlipPrintDivCd; // �`�[���s�敪
            retSalesSlip.SlipPrintFinishCd = pmTabSalesSlip.SlipPrintFinishCd; // �`�[���s�ϋ敪
            retSalesSlip.SalesSlipPrintDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.SalesSlipPrintDate); // ����`�[���s��
            retSalesSlip.BusinessTypeCode = pmTabSalesSlip.BusinessTypeCode; // �Ǝ�R�[�h
            retSalesSlip.BusinessTypeName = pmTabSalesSlip.BusinessTypeName; // �Ǝ햼��
            retSalesSlip.OrderNumber = pmTabSalesSlip.OrderNumber; // �����ԍ�
            retSalesSlip.DeliveredGoodsDiv = pmTabSalesSlip.DeliveredGoodsDiv; // �[�i�敪
            retSalesSlip.DeliveredGoodsDivNm = pmTabSalesSlip.DeliveredGoodsDivNm; // �[�i�敪����
            retSalesSlip.SalesAreaCode = pmTabSalesSlip.SalesAreaCode; // �̔��G���A�R�[�h
            retSalesSlip.SalesAreaName = pmTabSalesSlip.SalesAreaName; // �̔��G���A����
            retSalesSlip.ReconcileFlag = pmTabSalesSlip.ReconcileFlag; // �����t���O
            retSalesSlip.SlipPrtSetPaperId = pmTabSalesSlip.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
            //retSalesSlip.CompleteCd = pmTabSalesSlip.CompleteCd; // �ꎮ�`�[�敪  // DEL 2013/07/10 qijh Redmine#38128
            retSalesSlip.CompleteCd = 10; // �ꎮ�`�[�敪(10:�^�u���b�g)  // ADD 2013/07/10 qijh Redmine#38128
            retSalesSlip.SalesPriceFracProcCd = pmTabSalesSlip.SalesPriceFracProcCd; // ������z�[�������敪
            retSalesSlip.StockGoodsTtlTaxExc = pmTabSalesSlip.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
            retSalesSlip.PureGoodsTtlTaxExc = pmTabSalesSlip.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.ListPricePrintDiv = pmTabSalesSlip.ListPricePrintDiv; // �艿����敪
            retSalesSlip.ListPricePrintDiv = EstimateDefSet.ListPricePrintDiv; // �艿����敪
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EraNameDispCd1 = pmTabSalesSlip.EraNameDispCd1; // �����\���敪�P
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimaTaxDivCd = pmTabSalesSlip.EstimaTaxDivCd; // ���Ϗ���ŋ敪
            retSalesSlip.EstimaTaxDivCd = EstimateDefSet.ConsTaxPrintDiv; // ���Ϗ���ŋ敪
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateFormPrtCd = pmTabSalesSlip.EstimateFormPrtCd; // ���Ϗ�����敪
            retSalesSlip.EstimateSubject = pmTabSalesSlip.EstimateSubject; // ���ό���
            retSalesSlip.Footnotes1 = pmTabSalesSlip.Footnotes1; // �r���P
            retSalesSlip.Footnotes2 = pmTabSalesSlip.Footnotes2; // �r���Q
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateTitle1 = pmTabSalesSlip.EstimateTitle1; // ���σ^�C�g���P
            retSalesSlip.EstimateTitle1 = EstimateDefSet.EstimateTitle1; // ���σ^�C�g���P
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateTitle2 = pmTabSalesSlip.EstimateTitle2; // ���σ^�C�g���Q
            retSalesSlip.EstimateTitle3 = pmTabSalesSlip.EstimateTitle3; // ���σ^�C�g���R
            retSalesSlip.EstimateTitle4 = pmTabSalesSlip.EstimateTitle4; // ���σ^�C�g���S
            retSalesSlip.EstimateTitle5 = pmTabSalesSlip.EstimateTitle5; // ���σ^�C�g���T
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateNote1 = pmTabSalesSlip.EstimateNote1; // ���ϔ��l�P
            // retSalesSlip.EstimateNote2 = pmTabSalesSlip.EstimateNote2; // ���ϔ��l�Q
            // retSalesSlip.EstimateNote3 = pmTabSalesSlip.EstimateNote3; // ���ϔ��l�R
            retSalesSlip.EstimateNote1 = EstimateDefSet.EstimateNote1; // ���ϔ��l�P
            retSalesSlip.EstimateNote2 = EstimateDefSet.EstimateNote2; // ���ϔ��l�Q
            retSalesSlip.EstimateNote3 = EstimateDefSet.EstimateNote3; // ���ϔ��l�R
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateNote4 = pmTabSalesSlip.EstimateNote4; // ���ϔ��l�S
            retSalesSlip.EstimateNote5 = pmTabSalesSlip.EstimateNote5; // ���ϔ��l�T
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateValidityDate = pmTabSalesSlip.EstimateValidityDate; // ���ϗL������
            // retSalesSlip.PartsNoPrtCd = pmTabSalesSlip.PartsNoPrtCd; // �i�Ԉ󎚋敪
            retSalesSlip.EstimateValidityDate = DateTime.Today; // ���ϗL������
            retSalesSlip.PartsNoPrtCd = EstimateDefSet.PartsNoPrtCd; // �i�Ԉ󎚋敪
            // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��354�`356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.OptionPringDivCd = pmTabSalesSlip.OptionPringDivCd; // �I�v�V�����󎚋敪
            retSalesSlip.RateUseCode = pmTabSalesSlip.RateUseCode; // �|���g�p�敪

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return retSalesSlip;
        }

        /// <summary>
        /// ���㖾�׃f�[�^���쐬
        /// </summary>
        /// <param name="pmTabSalesDetail">PMTAB���㖾�׃f�[�^</param>
        /// <param name="isScmConn">SCM�A�g��(true:�A�g)</param>
        /// <returns>���㖾�׃f�[�^</returns>
        //private SalesDetailWork GetUpdSalesDetail(PmTabSaleDetailWork pmTabSalesDetail, bool isScmConn) // DEL 2013/07/03 qijh Redmine#37586
        private SalesDetail GetUpdSalesDetail(PmTabSaleDetailWork pmTabSalesDetail, bool isScmConn) // ADD 2013/07/03 qijh Redmine#37586
        {
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- >>>>>
            //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //const string methodName = "GetUpdSalesDetail";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- <<<<<

            //SalesDetailWork retSalesDetail = new SalesDetailWork(); // DEL 2013/07/03 qijh Redmine#37586
            SalesDetail retSalesDetail = new SalesDetail(); // ADD 2013/07/03 qijh Redmine#37586
            retSalesDetail.EnterpriseCode = pmTabSalesDetail.EnterpriseCode; // ��ƃR�[�h
            retSalesDetail.UpdEmployeeCode = pmTabSalesDetail.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            retSalesDetail.UpdAssemblyId1 = pmTabSalesDetail.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            retSalesDetail.UpdAssemblyId2 = pmTabSalesDetail.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            retSalesDetail.LogicalDeleteCode = pmTabSalesDetail.LogicalDeleteCode; // �_���폜�敪
            retSalesDetail.AcceptAnOrderNo = pmTabSalesDetail.AcceptAnOrderNo; // �󒍔ԍ�
            retSalesDetail.AcptAnOdrStatus = pmTabSalesDetail.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            retSalesDetail.SalesSlipNum = pmTabSalesDetail.SalesSlipNum; // ����`�[�ԍ�
            retSalesDetail.SalesRowNo = pmTabSalesDetail.SalesRowNo; // ����s�ԍ�
            retSalesDetail.SalesRowDerivNo = pmTabSalesDetail.SalesRowDerivNo; // ����s�ԍ��}��
            retSalesDetail.SectionCode = pmTabSalesDetail.SectionCode; // ���_�R�[�h
            retSalesDetail.SubSectionCode = pmTabSalesDetail.SubSectionCode; // ����R�[�h
            retSalesDetail.SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.SalesDate); // ������t
            retSalesDetail.CommonSeqNo = pmTabSalesDetail.CommonSeqNo; // ���ʒʔ�
            retSalesDetail.SalesSlipDtlNum = pmTabSalesDetail.SalesSlipDtlNum; // ���㖾�גʔ�
            retSalesDetail.AcptAnOdrStatusSrc = pmTabSalesDetail.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
            retSalesDetail.SalesSlipDtlNumSrc = pmTabSalesDetail.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
            retSalesDetail.SupplierFormalSync = pmTabSalesDetail.SupplierFormalSync; // �d���`���i�����j
            retSalesDetail.StockSlipDtlNumSync = pmTabSalesDetail.StockSlipDtlNumSync; // �d�����גʔԁi�����j
            retSalesDetail.SalesSlipCdDtl = pmTabSalesDetail.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
            retSalesDetail.DeliGdsCmpltDueDate = pmTabSalesDetail.DeliGdsCmpltDueDate; // �[�i�����\���
            retSalesDetail.GoodsKindCode = pmTabSalesDetail.GoodsKindCode; // ���i����
            retSalesDetail.GoodsSearchDivCd = pmTabSalesDetail.GoodsSearchDivCd; // ���i�����敪
            retSalesDetail.GoodsMakerCd = pmTabSalesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h
            retSalesDetail.MakerName = pmTabSalesDetail.MakerName; // ���[�J�[����
            retSalesDetail.MakerKanaName = pmTabSalesDetail.MakerKanaName; // ���[�J�[�J�i����
            retSalesDetail.GoodsNo = pmTabSalesDetail.GoodsNo; // ���i�ԍ�
            retSalesDetail.GoodsName = pmTabSalesDetail.GoodsName; // ���i����
            retSalesDetail.GoodsNameKana = pmTabSalesDetail.GoodsNameKana; // ���i���̃J�i
            retSalesDetail.GoodsLGroup = pmTabSalesDetail.GoodsLGroup; // ���i�啪�ރR�[�h
            retSalesDetail.GoodsLGroupName = pmTabSalesDetail.GoodsLGroupName; // ���i�啪�ޖ���
            retSalesDetail.GoodsMGroup = pmTabSalesDetail.GoodsMGroup; // ���i�����ރR�[�h
            retSalesDetail.GoodsMGroupName = pmTabSalesDetail.GoodsMGroupName; // ���i�����ޖ���
            retSalesDetail.BLGroupCode = pmTabSalesDetail.BLGroupCode; // BL�O���[�v�R�[�h
            retSalesDetail.BLGroupName = pmTabSalesDetail.BLGroupName; // BL�O���[�v�R�[�h����
            retSalesDetail.BLGoodsCode = pmTabSalesDetail.BLGoodsCode; // BL���i�R�[�h
            retSalesDetail.BLGoodsFullName = pmTabSalesDetail.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            retSalesDetail.EnterpriseGanreCode = pmTabSalesDetail.EnterpriseGanreCode; // ���Е��ރR�[�h
            retSalesDetail.EnterpriseGanreName = pmTabSalesDetail.EnterpriseGanreName; // ���Е��ޖ���
            retSalesDetail.WarehouseCode = pmTabSalesDetail.WarehouseCode; // �q�ɃR�[�h
            retSalesDetail.WarehouseName = pmTabSalesDetail.WarehouseName; // �q�ɖ���
            retSalesDetail.WarehouseShelfNo = pmTabSalesDetail.WarehouseShelfNo; // �q�ɒI��
            retSalesDetail.SalesOrderDivCd = pmTabSalesDetail.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            retSalesDetail.OpenPriceDiv = pmTabSalesDetail.OpenPriceDiv; // �I�[�v�����i�敪
            retSalesDetail.GoodsRateRank = pmTabSalesDetail.GoodsRateRank; // ���i�|�������N
            retSalesDetail.CustRateGrpCode = pmTabSalesDetail.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            retSalesDetail.ListPriceRate = pmTabSalesDetail.ListPriceRate; // �艿��
            retSalesDetail.RateSectPriceUnPrc = pmTabSalesDetail.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
            retSalesDetail.RateDivLPrice = pmTabSalesDetail.RateDivLPrice; // �|���ݒ�敪�i�艿�j
            retSalesDetail.UnPrcCalcCdLPrice = pmTabSalesDetail.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
            retSalesDetail.PriceCdLPrice = pmTabSalesDetail.PriceCdLPrice; // ���i�敪�i�艿�j
            retSalesDetail.StdUnPrcLPrice = pmTabSalesDetail.StdUnPrcLPrice; // ��P���i�艿�j
            retSalesDetail.FracProcUnitLPrice = pmTabSalesDetail.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
            retSalesDetail.FracProcLPrice = pmTabSalesDetail.FracProcLPrice; // �[�������i�艿�j
            retSalesDetail.ListPriceTaxIncFl = pmTabSalesDetail.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            retSalesDetail.ListPriceTaxExcFl = pmTabSalesDetail.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            retSalesDetail.ListPriceChngCd = pmTabSalesDetail.ListPriceChngCd; // �艿�ύX�敪
            retSalesDetail.SalesRate = pmTabSalesDetail.SalesRate; // ������
            retSalesDetail.RateSectSalUnPrc = pmTabSalesDetail.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
            retSalesDetail.RateDivSalUnPrc = pmTabSalesDetail.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
            retSalesDetail.UnPrcCalcCdSalUnPrc = pmTabSalesDetail.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
            retSalesDetail.PriceCdSalUnPrc = pmTabSalesDetail.PriceCdSalUnPrc; // ���i�敪�i����P���j
            retSalesDetail.StdUnPrcSalUnPrc = pmTabSalesDetail.StdUnPrcSalUnPrc; // ��P���i����P���j
            retSalesDetail.FracProcUnitSalUnPrc = pmTabSalesDetail.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
            retSalesDetail.FracProcSalUnPrc = pmTabSalesDetail.FracProcSalUnPrc; // �[�������i����P���j
            retSalesDetail.SalesUnPrcTaxIncFl = pmTabSalesDetail.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            retSalesDetail.SalesUnPrcTaxExcFl = pmTabSalesDetail.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            retSalesDetail.SalesUnPrcChngCd = pmTabSalesDetail.SalesUnPrcChngCd; // ����P���ύX�敪
            retSalesDetail.CostRate = pmTabSalesDetail.CostRate; // ������
            retSalesDetail.RateSectCstUnPrc = pmTabSalesDetail.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
            retSalesDetail.RateDivUnCst = pmTabSalesDetail.RateDivUnCst; // �|���ݒ�敪�i�����P���j
            retSalesDetail.UnPrcCalcCdUnCst = pmTabSalesDetail.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
            retSalesDetail.PriceCdUnCst = pmTabSalesDetail.PriceCdUnCst; // ���i�敪�i�����P���j
            retSalesDetail.StdUnPrcUnCst = pmTabSalesDetail.StdUnPrcUnCst; // ��P���i�����P���j
            retSalesDetail.FracProcUnitUnCst = pmTabSalesDetail.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
            retSalesDetail.FracProcUnCst = pmTabSalesDetail.FracProcUnCst; // �[�������i�����P���j
            retSalesDetail.SalesUnitCost = pmTabSalesDetail.SalesUnitCost; // �����P��
            retSalesDetail.SalesUnitCostChngDiv = pmTabSalesDetail.SalesUnitCostChngDiv; // �����P���ύX�敪
            retSalesDetail.RateBLGoodsCode = pmTabSalesDetail.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
            retSalesDetail.RateBLGoodsName = pmTabSalesDetail.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
            retSalesDetail.RateGoodsRateGrpCd = pmTabSalesDetail.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
            retSalesDetail.RateGoodsRateGrpNm = pmTabSalesDetail.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
            retSalesDetail.RateBLGroupCode = pmTabSalesDetail.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
            retSalesDetail.RateBLGroupName = pmTabSalesDetail.RateBLGroupName; // BL�O���[�v���́i�|���j
            retSalesDetail.PrtBLGoodsCode = pmTabSalesDetail.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            retSalesDetail.PrtBLGoodsName = pmTabSalesDetail.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            retSalesDetail.SalesCode = pmTabSalesDetail.SalesCode; // �̔��敪�R�[�h
            retSalesDetail.SalesCdNm = pmTabSalesDetail.SalesCdNm; // �̔��敪����
            retSalesDetail.WorkManHour = pmTabSalesDetail.WorkManHour; // ��ƍH��
            retSalesDetail.ShipmentCnt = pmTabSalesDetail.ShipmentCnt; // �o�א�
            retSalesDetail.AcceptAnOrderCnt = pmTabSalesDetail.AcceptAnOrderCnt; // �󒍐���
            retSalesDetail.AcptAnOdrAdjustCnt = pmTabSalesDetail.AcptAnOdrAdjustCnt; // �󒍒�����
            retSalesDetail.AcptAnOdrRemainCnt = pmTabSalesDetail.AcptAnOdrRemainCnt; // �󒍎c��
            retSalesDetail.RemainCntUpdDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.RemainCntUpdDate); // �c���X�V��
            retSalesDetail.SalesMoneyTaxInc = pmTabSalesDetail.SalesMoneyTaxInc; // ������z�i�ō��݁j
            retSalesDetail.SalesMoneyTaxExc = pmTabSalesDetail.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            retSalesDetail.Cost = pmTabSalesDetail.Cost; // ����
            retSalesDetail.GrsProfitChkDiv = pmTabSalesDetail.GrsProfitChkDiv; // �e���`�F�b�N�敪
            retSalesDetail.SalesGoodsCd = pmTabSalesDetail.SalesGoodsCd; // ���㏤�i�敪
            retSalesDetail.SalesPriceConsTax = pmTabSalesDetail.SalesPriceConsTax; // ������z����Ŋz
            retSalesDetail.TaxationDivCd = pmTabSalesDetail.TaxationDivCd; // �ېŋ敪
            retSalesDetail.PartySlipNumDtl = pmTabSalesDetail.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            retSalesDetail.DtlNote = pmTabSalesDetail.DtlNote; // ���ה��l
            retSalesDetail.SupplierCd = pmTabSalesDetail.SupplierCd; // �d����R�[�h
            retSalesDetail.SupplierSnm = pmTabSalesDetail.SupplierSnm; // �d���旪��
            retSalesDetail.OrderNumber = pmTabSalesDetail.OrderNumber; // �����ԍ�
            retSalesDetail.WayToOrder = pmTabSalesDetail.WayToOrder; // �������@
            retSalesDetail.SlipMemo1 = pmTabSalesDetail.SlipMemo1; // �`�[�����P
            retSalesDetail.SlipMemo2 = pmTabSalesDetail.SlipMemo2; // �`�[�����Q
            retSalesDetail.SlipMemo3 = pmTabSalesDetail.SlipMemo3; // �`�[�����R
            retSalesDetail.InsideMemo1 = pmTabSalesDetail.InsideMemo1; // �Г������P
            retSalesDetail.InsideMemo2 = pmTabSalesDetail.InsideMemo2; // �Г������Q
            retSalesDetail.InsideMemo3 = pmTabSalesDetail.InsideMemo3; // �Г������R
            retSalesDetail.BfListPrice = pmTabSalesDetail.BfListPrice; // �ύX�O�艿
            retSalesDetail.BfSalesUnitPrice = pmTabSalesDetail.BfSalesUnitPrice; // �ύX�O����
            retSalesDetail.BfUnitCost = pmTabSalesDetail.BfUnitCost; // �ύX�O����
            retSalesDetail.CmpltSalesRowNo = pmTabSalesDetail.CmpltSalesRowNo; // �ꎮ���הԍ�
            retSalesDetail.CmpltGoodsMakerCd = pmTabSalesDetail.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
            retSalesDetail.CmpltMakerName = pmTabSalesDetail.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
            retSalesDetail.CmpltMakerKanaName = pmTabSalesDetail.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
            retSalesDetail.CmpltGoodsName = pmTabSalesDetail.CmpltGoodsName; // ���i���́i�ꎮ�j
            retSalesDetail.CmpltShipmentCnt = pmTabSalesDetail.CmpltShipmentCnt; // ���ʁi�ꎮ�j
            retSalesDetail.CmpltSalesUnPrcFl = pmTabSalesDetail.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
            retSalesDetail.CmpltSalesMoney = pmTabSalesDetail.CmpltSalesMoney; // ������z�i�ꎮ�j
            retSalesDetail.CmpltSalesUnitCost = pmTabSalesDetail.CmpltSalesUnitCost; // �����P���i�ꎮ�j
            retSalesDetail.CmpltCost = pmTabSalesDetail.CmpltCost; // �������z�i�ꎮ�j
            retSalesDetail.CmpltPartySalSlNum = pmTabSalesDetail.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
            retSalesDetail.CmpltNote = pmTabSalesDetail.CmpltNote; // �ꎮ���l
            retSalesDetail.PrtGoodsNo = pmTabSalesDetail.PrtGoodsNo; // ����p�i��
            retSalesDetail.PrtMakerCode = pmTabSalesDetail.PrtMakerCode; // ����p���[�J�[�R�[�h
            retSalesDetail.PrtMakerName = pmTabSalesDetail.PrtMakerName; // ����p���[�J�[����
            retSalesDetail.CampaignCode = pmTabSalesDetail.CampaignCode; // �L�����y�[���R�[�h
            retSalesDetail.CampaignName = pmTabSalesDetail.CampaignName; // �L�����y�[������
            retSalesDetail.GoodsDivCd = pmTabSalesDetail.GoodsDivCd; // ���i���
            retSalesDetail.AnswerDelivDate = pmTabSalesDetail.AnswerDelivDate; // �񓚔[��
            retSalesDetail.RecycleDiv = pmTabSalesDetail.RecycleDiv; // ���T�C�N���敪
            retSalesDetail.RecycleDivNm = pmTabSalesDetail.RecycleDivNm; // ���T�C�N���敪����
            retSalesDetail.WayToAcptOdr = pmTabSalesDetail.WayToAcptOdr; // �󒍕��@
            retSalesDetail.AutoAnswerDivSCM = pmTabSalesDetail.AutoAnswerDivSCM; // �����񓚋敪(SCM)
            retSalesDetail.AcceptOrOrderKind = pmTabSalesDetail.AcceptOrOrderKind; // �󔭒����
            retSalesDetail.InquiryNumber = pmTabSalesDetail.InquiryNumber; // �⍇���ԍ�
            retSalesDetail.InqRowNumber = pmTabSalesDetail.InqRowNumber; // �⍇���s�ԍ�
            retSalesDetail.GoodsSpecialNote = pmTabSalesDetail.GoodsSpecialNote; // ���i�K�i�E���L����
            retSalesDetail.RentSyncSupplier = pmTabSalesDetail.RentSyncSupplier; // �ݏo�����d����
            retSalesDetail.RentSyncStockDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.RentSyncStockDate); // �ݏo�����d����
            retSalesDetail.RentSyncSupSlipNo = pmTabSalesDetail.RentSyncSupSlipNo; // �ݏo�����d���`�[�ԍ�

            retSalesDetail.DtlRelationGuid = Guid.NewGuid(); // ���׊֘A�t��GUID // ADD 2013/06/27 qijh Redmine#37389
            
            // SCM�Ɋ֘A���鍀�ڂ��Z�b�g
            retSalesDetail.WayToAcptOdr = 0; // �󒍕��@
            retSalesDetail.AutoAnswerDivSCM = 0; // �����񓚋敪(SCM)
            retSalesDetail.AcceptOrOrderKind = 0; // �󔭒����
            retSalesDetail.InquiryNumber = 0; // �⍇���ԍ�
            retSalesDetail.InqRowNumber = 0; // �⍇���s�ԍ�
            if (isScmConn)
            {
                // SCM�A�g
                retSalesDetail.WayToAcptOdr = 1; // �󒍕��@
                retSalesDetail.AutoAnswerDivSCM = 1; // �����񓚋敪(SCM)
                retSalesDetail.AcceptOrOrderKind = 1; // �󔭒����
                // retSalesDetail.InquiryNumber = -1; // �⍇���ԍ�  // DEL 2013/07/02 songg Redmine#37692
                retSalesDetail.InquiryNumber = 0; // �⍇���ԍ�     // ADD 2013/07/02 songg Redmine#37692
                retSalesDetail.InqRowNumber = -1; // �⍇���s�ԍ�
            }

            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- >>>>>
            //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- <<<<<

            // ����p�i�Ԃ�ݒ�
            retSalesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo; // �f�B�t�H���g�l��ݒ� // ADD 2013/07/17 qijh Redmine#38166
            SetPrtGoodsNo(retSalesDetail, pmTabSalesDetail); // ADD 2013/07/12 qijh Redmine#38166

            return retSalesDetail;
        }

        // --------------------- ADD 2013/06/27 qijh Redmine#37389 ---------------- >>>>>
        /// <summary>
        /// ���㖾�׃��X�g��薾�גǉ���񃊃X�g���擾
        /// </summary>
        /// <param name="updSalesDetailList">���㖾�׃f�[�^���X�g</param>
        /// <param name="carManagementWork">�ԗ��Ǘ��f�[�^</param>
        /// <param name="slipDtlRegOrder">�`�[�o�^������p�ϐ�</param>
        /// <returns>���גǉ���񃊃X�g</returns>
        private ArrayList GetSlipDetailAddInfoWorkList(ArrayList updSalesDetailList
            , CarManagementWork carManagementWork  // ADD 2013/06/28 qijh Redmine#37389
            , ref int slipDtlRegOrder     // ADD 2013/07/09 qijh Redmine#37586
            )
        {
            // ���㖾�׃��X�g��薾�גǉ���񃊃X�g���擾
            ArrayList retList = new ArrayList();

            //Guid carRelationGuid = Guid.NewGuid();
            Guid carRelationGuid = carManagementWork.CarRelationGuid;
            for (int i = 1; i <= updSalesDetailList.Count; i++)
            {
                SalesDetailWork updSalesDetailWork = (SalesDetailWork)updSalesDetailList[i - 1];
                //retList.Add(GetSlipDetailAddInfo(updSalesDetailWork, carRelationGuid, i)); // DEL 2013/07/09 qijh Redmine#37586
                retList.Add(GetSlipDetailAddInfo(updSalesDetailWork, carRelationGuid, ref slipDtlRegOrder)); // ADD 2013/07/09 qijh Redmine#37586
            }

            return retList;
        }

        /// <summary>
        /// ���㖾�ׂ�薾�גǉ������擾
        /// </summary>
        /// <param name="updSalesDetailWork">���㖾�׃f�[�^</param>
        /// <param name="carRelationGuid">�ԗ���񋤒�GUID</param>
        /// <param name="salesSort">����f�[�^��</param>
        /// <returns>���גǉ����</returns>
        //private SlipDetailAddInfoWork GetSlipDetailAddInfo(SalesDetailWork updSalesDetailWork, Guid carRelationGuid, int salesSort) // DEL 2013/07/09 qijh Redmine#37586
        private SlipDetailAddInfoWork GetSlipDetailAddInfo(SalesDetailWork updSalesDetailWork, Guid carRelationGuid, ref int salesSort) // ADD 2013/07/09 qijh Redmine#37586
        {
            SlipDetailAddInfoWork addInfo = new SlipDetailAddInfoWork();

            addInfo.GoodsEntryDiv = 0;  // ���i�o�^�敪(0:�o�^���Ȃ�/1:�o�^����)
            addInfo.PriceUpdateDiv = 0; // ���i�o�^�敪(0:�o�^���Ȃ�/1:�o�^����)
            addInfo.DtlRelationGuid = updSalesDetailWork.DtlRelationGuid;     // ���׋���GUID
            addInfo.CarRelationGuid = carRelationGuid;        // �ԗ���񋤒�GUID
            //addInfo.SlipDtlRegOrder = salesSort;         //����f�[�^��  // DEL 2013/07/09 qijh Redmine#37586
            addInfo.SlipDtlRegOrder = ++salesSort;    //�f�[�^�o�^��   // ADD 2013/07/09 qijh Redmine#37586
            addInfo.AddUpRemDiv = 0;    // �󒍃f�[�^�v��c�敪(0:�`�[�ǉ����Q��/1:�c��/2:�c���Ȃ�)

            return addInfo;
        }
        // --------------------- ADD 2013/06/27 qijh Redmine#37389 ---------------- <<<<<

        #region DEL 2013/06/28 qijh Redmine#37389
        // --------------------- DEL 2013/06/28 qijh Redmine#37389 ---------------- >>>>>
        ///// <summary>
        ///// �󒍃}�X�^(�ԗ�)���쐬
        ///// </summary>
        ///// <param name="pmTabAcceptOdrCar">PMTAB�󒍃}�X�^(�ԗ�)</param>
        ///// <returns>�󒍃}�X�^(�ԗ�)</returns>
        //private AcceptOdrCarWork GetUpdAcceptOdrCar(PmTabAcpOdrCarWork pmTabAcceptOdrCar)
        //{
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    const string methodName = "GetUpdAcceptOdrCar";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        //    AcceptOdrCarWork retAcceptOdrCar = new AcceptOdrCarWork();
        //    retAcceptOdrCar.EnterpriseCode = pmTabAcceptOdrCar.EnterpriseCode; // ��ƃR�[�h
        //    retAcceptOdrCar.UpdEmployeeCode = pmTabAcceptOdrCar.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
        //    retAcceptOdrCar.UpdAssemblyId1 = pmTabAcceptOdrCar.UpdAssemblyId1; // �X�V�A�Z���u��ID1
        //    retAcceptOdrCar.UpdAssemblyId2 = pmTabAcceptOdrCar.UpdAssemblyId2; // �X�V�A�Z���u��ID2
        //    retAcceptOdrCar.LogicalDeleteCode = pmTabAcceptOdrCar.LogicalDeleteCode; // �_���폜�敪
        //    retAcceptOdrCar.AcceptAnOrderNo = pmTabAcceptOdrCar.AcceptAnOrderNo; // �󒍔ԍ�
        //    retAcceptOdrCar.AcptAnOdrStatus = pmTabAcceptOdrCar.AcptAnOdrStatus; // �󒍃X�e�[�^�X
        //    retAcceptOdrCar.DataInputSystem = pmTabAcceptOdrCar.DataInputSystem; // �f�[�^���̓V�X�e��
        //    retAcceptOdrCar.CarMngNo = pmTabAcceptOdrCar.CarMngNo; // �ԗ��Ǘ��ԍ�
        //    retAcceptOdrCar.CarMngCode = pmTabAcceptOdrCar.CarMngCode; // ���q�Ǘ��R�[�h
        //    retAcceptOdrCar.NumberPlate1Code = pmTabAcceptOdrCar.NumberPlate1Code; // ���^�������ԍ�
        //    retAcceptOdrCar.NumberPlate1Name = pmTabAcceptOdrCar.NumberPlate1Name; // ���^�����ǖ���
        //    retAcceptOdrCar.NumberPlate2 = pmTabAcceptOdrCar.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
        //    retAcceptOdrCar.NumberPlate3 = pmTabAcceptOdrCar.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
        //    retAcceptOdrCar.NumberPlate4 = pmTabAcceptOdrCar.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        //    retAcceptOdrCar.FirstEntryDate = pmTabAcceptOdrCar.FirstEntryDate; // ���N�x
        //    retAcceptOdrCar.MakerCode = pmTabAcceptOdrCar.MakerCode; // ���[�J�[�R�[�h
        //    retAcceptOdrCar.MakerFullName = pmTabAcceptOdrCar.MakerFullName; // ���[�J�[�S�p����
        //    retAcceptOdrCar.MakerHalfName = pmTabAcceptOdrCar.MakerHalfName; // ���[�J�[���p����
        //    retAcceptOdrCar.ModelCode = pmTabAcceptOdrCar.ModelCode; // �Ԏ�R�[�h
        //    retAcceptOdrCar.ModelSubCode = pmTabAcceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h
        //    retAcceptOdrCar.ModelFullName = pmTabAcceptOdrCar.ModelFullName; // �Ԏ�S�p����
        //    retAcceptOdrCar.ModelHalfName = pmTabAcceptOdrCar.ModelHalfName; // �Ԏ피�p����
        //    retAcceptOdrCar.ExhaustGasSign = pmTabAcceptOdrCar.ExhaustGasSign; // �r�K�X�L��
        //    retAcceptOdrCar.SeriesModel = pmTabAcceptOdrCar.SeriesModel; // �V���[�Y�^��
        //    retAcceptOdrCar.CategorySignModel = pmTabAcceptOdrCar.CategorySignModel; // �^���i�ޕʋL���j
        //    retAcceptOdrCar.FullModel = pmTabAcceptOdrCar.FullModel; // �^���i�t���^�j
        //    retAcceptOdrCar.ModelDesignationNo = pmTabAcceptOdrCar.ModelDesignationNo; // �^���w��ԍ�
        //    retAcceptOdrCar.CategoryNo = pmTabAcceptOdrCar.CategoryNo; // �ޕʔԍ�
        //    retAcceptOdrCar.FrameModel = pmTabAcceptOdrCar.FrameModel; // �ԑ�^��
        //    retAcceptOdrCar.FrameNo = pmTabAcceptOdrCar.FrameNo; // �ԑ�ԍ�
        //    retAcceptOdrCar.SearchFrameNo = pmTabAcceptOdrCar.SearchFrameNo; // �ԑ�ԍ��i�����p�j
        //    retAcceptOdrCar.EngineModelNm = pmTabAcceptOdrCar.EngineModelNm; // �G���W���^������
        //    retAcceptOdrCar.RelevanceModel = pmTabAcceptOdrCar.RelevanceModel; // �֘A�^��
        //    retAcceptOdrCar.SubCarNmCd = pmTabAcceptOdrCar.SubCarNmCd; // �T�u�Ԗ��R�[�h
        //    retAcceptOdrCar.ModelGradeSname = pmTabAcceptOdrCar.ModelGradeSname; // �^���O���[�h����
        //    retAcceptOdrCar.ColorCode = pmTabAcceptOdrCar.ColorCode; // �J���[�R�[�h
        //    retAcceptOdrCar.ColorName1 = pmTabAcceptOdrCar.ColorName1; // �J���[����1
        //    retAcceptOdrCar.TrimCode = pmTabAcceptOdrCar.TrimCode; // �g�����R�[�h
        //    retAcceptOdrCar.TrimName = pmTabAcceptOdrCar.TrimName; // �g��������
        //    retAcceptOdrCar.Mileage = pmTabAcceptOdrCar.Mileage; // �ԗ����s����
        //    retAcceptOdrCar.FullModelFixedNoAry = pmTabAcceptOdrCar.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
        //    retAcceptOdrCar.CategoryObjAry = pmTabAcceptOdrCar.CategoryObjAry; // �����I�u�W�F�N�g�z��
        //    retAcceptOdrCar.CarNote = pmTabAcceptOdrCar.CarNote; // ���q���l
        //    retAcceptOdrCar.FreeSrchMdlFxdNoAry = pmTabAcceptOdrCar.FreeSrchMdlFxdNoAry; // ���R�����^���Œ�ԍ��z��
        //    retAcceptOdrCar.DomesticForeignCode = pmTabAcceptOdrCar.DomesticForeignCode; // ���Y�^�O�ԋ敪

        //    if (null == retAcceptOdrCar.FullModelFixedNoAry)
        //        retAcceptOdrCar.FullModelFixedNoAry = new int[0];
        //    if (null == retAcceptOdrCar.CategoryObjAry)
        //        retAcceptOdrCar.CategoryObjAry = new byte[0];
        //    if (null == retAcceptOdrCar.FreeSrchMdlFxdNoAry)
        //        retAcceptOdrCar.FreeSrchMdlFxdNoAry = new byte[0];

        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        //    return retAcceptOdrCar;
        //}
        // --------------------- DEL 2013/06/28 qijh Redmine#37389 ---------------- <<<<<
        #endregion DEL 2013/06/28 qijh Redmine#37389

        // --------------------- ADD 2013/06/28 qijh Redmine#37389 ---------------- >>>>>
        /// <summary>
        /// �ԗ��Ǘ��f�[�^���쐬
        /// </summary>
        /// <param name="pmTabAcceptOdrCar">PMTAB�󒍃}�X�^(�ԗ�)</param>
        /// <param name="pmTabSalesSlip">PMTAB����f�[�^</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns>�ԗ��Ǘ��f�[�^</returns>
        private CarManagementWork GetUpdCarManagement(PmTabAcpOdrCarWork pmTabAcceptOdrCar, PmTabSalesSlipWork pmTabSalesSlip, CustomerInfo customerInfo)
        {
            const string methodName = "GetUpdCarManagement";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            CarManagementWork retAcceptOdrCar = new CarManagementWork();
            retAcceptOdrCar.EnterpriseCode = pmTabAcceptOdrCar.EnterpriseCode; // ��ƃR�[�h
            retAcceptOdrCar.UpdEmployeeCode = pmTabSalesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            retAcceptOdrCar.UpdAssemblyId1 = pmTabAcceptOdrCar.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            retAcceptOdrCar.UpdAssemblyId2 = pmTabAcceptOdrCar.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            retAcceptOdrCar.LogicalDeleteCode = pmTabAcceptOdrCar.LogicalDeleteCode; // �_���폜�敪
            retAcceptOdrCar.CustomerCode = customerInfo.CustomerCode; // ���Ӑ�R�[�h
            retAcceptOdrCar.CarMngNo = pmTabAcceptOdrCar.CarMngNo; // �ԗ��Ǘ��ԍ�
            retAcceptOdrCar.CarMngCode = pmTabAcceptOdrCar.CarMngCode; // ���q�Ǘ��R�[�h
            retAcceptOdrCar.NumberPlate1Code = pmTabAcceptOdrCar.NumberPlate1Code; // ���^�������ԍ�
            retAcceptOdrCar.NumberPlate1Name = pmTabAcceptOdrCar.NumberPlate1Name; // ���^�����ǖ���
            retAcceptOdrCar.NumberPlate2 = pmTabAcceptOdrCar.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            retAcceptOdrCar.NumberPlate3 = pmTabAcceptOdrCar.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            retAcceptOdrCar.NumberPlate4 = pmTabAcceptOdrCar.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            retAcceptOdrCar.FirstEntryDate = pmTabAcceptOdrCar.FirstEntryDate; // ���N�x
            retAcceptOdrCar.MakerCode = pmTabAcceptOdrCar.MakerCode; // ���[�J�[�R�[�h
            retAcceptOdrCar.MakerFullName = pmTabAcceptOdrCar.MakerFullName; // ���[�J�[�S�p����
            retAcceptOdrCar.MakerHalfName = pmTabAcceptOdrCar.MakerHalfName; // ���[�J�[���p����
            retAcceptOdrCar.ModelCode = pmTabAcceptOdrCar.ModelCode; // �Ԏ�R�[�h
            retAcceptOdrCar.ModelSubCode = pmTabAcceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h
            retAcceptOdrCar.ModelFullName = pmTabAcceptOdrCar.ModelFullName; // �Ԏ�S�p����
            retAcceptOdrCar.ModelHalfName = pmTabAcceptOdrCar.ModelHalfName; // �Ԏ피�p����
            retAcceptOdrCar.ExhaustGasSign = pmTabAcceptOdrCar.ExhaustGasSign; // �r�K�X�L��
            retAcceptOdrCar.SeriesModel = pmTabAcceptOdrCar.SeriesModel; // �V���[�Y�^��
            retAcceptOdrCar.CategorySignModel = pmTabAcceptOdrCar.CategorySignModel; // �^���i�ޕʋL���j
            retAcceptOdrCar.FullModel = pmTabAcceptOdrCar.FullModel; // �^���i�t���^�j
            retAcceptOdrCar.ModelDesignationNo = pmTabAcceptOdrCar.ModelDesignationNo; // �^���w��ԍ�
            retAcceptOdrCar.CategoryNo = pmTabAcceptOdrCar.CategoryNo; // �ޕʔԍ�
            retAcceptOdrCar.FrameModel = pmTabAcceptOdrCar.FrameModel; // �ԑ�^��
            retAcceptOdrCar.FrameNo = pmTabAcceptOdrCar.FrameNo; // �ԑ�ԍ�
            retAcceptOdrCar.SearchFrameNo = pmTabAcceptOdrCar.SearchFrameNo; // �ԑ�ԍ��i�����p�j
            retAcceptOdrCar.EngineModelNm = pmTabAcceptOdrCar.EngineModelNm; // �G���W���^������
            retAcceptOdrCar.RelevanceModel = pmTabAcceptOdrCar.RelevanceModel; // �֘A�^��
            retAcceptOdrCar.SubCarNmCd = pmTabAcceptOdrCar.SubCarNmCd; // �T�u�Ԗ��R�[�h
            retAcceptOdrCar.ModelGradeSname = pmTabAcceptOdrCar.ModelGradeSname; // �^���O���[�h����
            retAcceptOdrCar.ColorCode = pmTabAcceptOdrCar.ColorCode; // �J���[�R�[�h
            retAcceptOdrCar.ColorName1 = pmTabAcceptOdrCar.ColorName1; // �J���[����1
            retAcceptOdrCar.TrimCode = pmTabAcceptOdrCar.TrimCode; // �g�����R�[�h
            retAcceptOdrCar.TrimName = pmTabAcceptOdrCar.TrimName; // �g��������
            retAcceptOdrCar.Mileage = pmTabAcceptOdrCar.Mileage; // �ԗ����s����
            retAcceptOdrCar.FullModelFixedNoAry = pmTabAcceptOdrCar.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            retAcceptOdrCar.CategoryObjAry = pmTabAcceptOdrCar.CategoryObjAry; // �����I�u�W�F�N�g�z��
            retAcceptOdrCar.CarNote = pmTabAcceptOdrCar.CarNote; // ���q���l
            retAcceptOdrCar.FreeSrchMdlFxdNoAry = pmTabAcceptOdrCar.FreeSrchMdlFxdNoAry; // ���R�����^���Œ�ԍ��z��
            retAcceptOdrCar.DomesticForeignCode = pmTabAcceptOdrCar.DomesticForeignCode; // ���Y�^�O�ԋ敪
            retAcceptOdrCar.CarRelationGuid = Guid.NewGuid(); // �ԗ���񋤒�GUID

            if (null == retAcceptOdrCar.FullModelFixedNoAry)
                retAcceptOdrCar.FullModelFixedNoAry = new int[0];
            if (null == retAcceptOdrCar.CategoryObjAry)
                retAcceptOdrCar.CategoryObjAry = new byte[0];
            if (null == retAcceptOdrCar.FreeSrchMdlFxdNoAry)
                retAcceptOdrCar.FreeSrchMdlFxdNoAry = new byte[0];

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");

            return retAcceptOdrCar;
        }
        // --------------------- ADD 2013/06/28 qijh Redmine#37389 ---------------- <<<<<

        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTAB�Z�b�V�����Ǘ��f�[�^���쐬
        /// </summary>
        /// <param name="pmTabSalesSlipWork">PMTAB����f�[�^</param>
        /// <returns>PMTAB�Z�b�V�����Ǘ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�Z�b�V�����Ǘ��f�[�^���쐬����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/03/30</br>
        /// </remarks>
        private ArrayList GetSessionMngWork(PmTabSalesSlipWork pmTabSalesSlipWork)
        {
            const string methodName = "GetSessionMngWork";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            ArrayList PmTabSessionMngList = new ArrayList();

            PmTabSessionMngWork pmTabSessionMngWork = new PmTabSessionMngWork();
            pmTabSessionMngWork.EnterpriseCode = pmTabSalesSlipWork.EnterpriseCode;
            pmTabSessionMngWork.UpdEmployeeCode = pmTabSalesSlipWork.UpdEmployeeCode;
            pmTabSessionMngWork.UpdAssemblyId1 = pmTabSalesSlipWork.UpdAssemblyId1;
            pmTabSessionMngWork.UpdAssemblyId2 = pmTabSalesSlipWork.UpdAssemblyId2;
            pmTabSessionMngWork.LogicalDeleteCode = pmTabSalesSlipWork.LogicalDeleteCode;
            pmTabSessionMngWork.BusinessSessionId = pmTabSalesSlipWork.BusinessSessionId;
            pmTabSessionMngWork.AcptAnOdrStatus = pmTabSalesSlipWork.AcptAnOdrStatus;
            pmTabSessionMngWork.SalesSlipNum = pmTabSalesSlipWork.SalesSlipNum;

            PmTabSessionMngList.Add(pmTabSessionMngWork);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");

            return PmTabSessionMngList;
        }
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<

        // --------------- ADD START 2013/07/02 wangl2 FOR Redmine#37585------>>>>
        /// <summary>
        /// ���݂̔���f�[�^�I�u�W�F�N�g��������f�[�^�I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlw">���������f�[�^�I�u�W�F�N�g</param>
        //private void GetCurrentDepsitMain(ref SalesSlipWork salesSlip, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw) // DEL 2013/07/03 qijh Redmine#37586
        private void GetCurrentDepsitMain(ref SalesSlip salesSlip, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw) // ADD 2013/07/03 qijh Redmine#37586
        {
            const string methodName = "GetCurrentDepsitMain";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            depsitMain = new SearchDepsitMain();
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();// ����S�̐ݒ�}�X�^
            ArrayList aList = new ArrayList();
            int status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, this._enterpriseCode);
            if (status == 0)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }
            //-----------------------------------------------------------------------------
            // �Ώۋ��z�Z�o
            //-----------------------------------------------------------------------------
            long totalPrice = salesSlip.SalesTotalTaxInc;
            if (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
            {
                // ���z�\�����Ȃ�
                switch (salesSlip.ConsTaxLayMethod)
                {
                    case 0: // �`�[�]��
                    case 1: // ���ד]��
                        break;
                    case 2: // �����e
                    case 3: // �����q
                    case 9: // ��ې�
                        // �����v
                        totalPrice = salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
                                     salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
                                     salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu;
                        break;
                }
            }

            //-----------------------------------------------------------------------------
            // ����`���u����ׁv�A�u���|�����v�A���i�敪�u���i�v�A���������敪�u����v�̏ꍇ�͎��������쐬
            //-----------------------------------------------------------------------------
            if ((salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales) &&
                (salesSlip.AccRecDivCd == (int)AccRecDivCd.NonAccRec) &&
                (salesSlip.SalesGoodsCd == (int)SalesGoodsCd.Goods) &&
                (this._salesTtlSt.AutoDepositCd == (int)AutoDepositCd.Write))
            {
                // �V�K
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();
                depsitMain.DepositRowNo[0] = 1; // �����s�ԍ�
                depsitMain.MoneyKindCode[0] = this._salesTtlSt.AutoDepoKindCode; // ��������R�[�h
                depsitMain.MoneyKindName[0] = this._salesTtlSt.AutoDepoKindName; // �������햼��
                depsitMain.MoneyKindDiv[0] = this._salesTtlSt.AutoDepoKindDivCd; // ��������敪

                // ------------- DEL 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                //CustomerInfo claim;
                //status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, salesSlip.ClaimCode, true, false, out claim);
                //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                //{
                //    depsitMain.ClaimName = claim.ClaimName; // �����於��
                //    depsitMain.ClaimName2 = claim.ClaimName2; // �����於�̂Q
                //}
                // ------------- DEL 2013/07/18 qijh Redmine#38565 ---------- <<<<<

                salesSlip.AutoDepositCd = 1; // ���������敪(1:��������)
                salesSlip.AutoDepositNoteDiv = this._salesTtlSt.AutoDepositNoteDiv; // �����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����)
                salesSlip.DepositAlwcBlnce = totalPrice; // ���������c��
                salesSlip.DepositAllowanceTtl = 0; // �����������v�z
            }
            else
            {
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();
                salesSlip.DepositAlwcBlnce = totalPrice - salesSlip.DepositAllowanceTtl; // ���������c��:����`�[���v�i�ō��݁j - �����������v�z
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="searchDepsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>�������[�N�I�u�W�F�N�g</returns>
        private DepsitDataWork ParamDataFromUIData(SearchDepsitMain searchDepsitMain)
        {
            return ParamDataFromUIDataProc(searchDepsitMain);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="searchDepsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>�������[�N�I�u�W�F�N�g</returns>
        /// <remarks>
        /// </remarks>
        private static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain)
        {
            const string methodName = "ParamDataFromUIDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // �쐬����
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // �X�V����
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // ��ƃR�[�h
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // �_���폜�敪
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // �����ԍ��敪
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // �����`�[�ԍ�
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // ����`�[�ԍ�
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // �������͋��_�R�[�h
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // �v�㋒�_�R�[�h
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // �X�V���_�R�[�h
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // ����R�[�h
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // �������t
            depsitMainWork.PreDepositDate = searchDepsitMain.DepositDate; // �O��������t
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // �v����t
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // �����v
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // �������z
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // �萔�������z
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // �l�������z
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // ���������敪
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // ��`�U�o��
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // ��`���
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // ��`��ޖ���
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // ��`�敪
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // ��`�敪����
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // ��`�ԍ�
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // ���������z
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // ���������c��
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // �ԍ������A���ԍ�
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // �ŏI�������݌v���
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // �����S���҃R�[�h
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // �����S���Җ���
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // �������͎҃R�[�h
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // �������͎Җ���
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // ���Ӑ�R�[�h
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // ���Ӑ於��
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // ���Ӑ於��2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // ���Ӑ旪��
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // ������R�[�h
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // �����於��
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // �����於��2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // �����旪��
            depsitMainWork.Outline = searchDepsitMain.Outline; // �`�[�E�v
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // ��s�R�[�h
            depsitMainWork.BankName = searchDepsitMain.BankName; // ��s����

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // �����s�ԍ�
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // ����R�[�h
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // ���햼��
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // ����敪
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // �������z
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // �L������
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return depsitDataWork;
        }
        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<        
        #endregion �� ����f�[�^�쐬

        #region �� SCM�f�[�^�쐬
        /// <summary>
        /// SCM�󒍃f�[�^���쐬
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns>SCM�󒍃f�[�^</returns>
        //private SCMAcOdrDataWork GetUpdSCMAcOdrData(SalesSlipWork salesSlip, CustomerInfo customerInfo) // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDataWork GetUpdSCMAcOdrData(SalesSlip salesSlip, CustomerInfo customerInfo) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            SCMAcOdrDataWork retSCMAcOdrData = new SCMAcOdrDataWork();

            retSCMAcOdrData.EnterpriseCode = salesSlip.EnterpriseCode; // ��ƃR�[�h : ����f�[�^��蓯����
            retSCMAcOdrData.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h : ����f�[�^��蓯����
            retSCMAcOdrData.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // �X�V�A�Z���u��ID1 : ����f�[�^��蓯����
            retSCMAcOdrData.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // �X�V�A�Z���u��ID2 : ����f�[�^��蓯����
            retSCMAcOdrData.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // �_���폜�敪 : ����f�[�^��蓯����
            retSCMAcOdrData.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // �⍇������ƃR�[�h : ���Ӑ�}�X�^��蓾�Ӑ��ƃR�[�h//@@@@20230303
            retSCMAcOdrData.InqOriginalSecCd = customerInfo.CustomerSecCode; // �⍇�������_�R�[�h : ���Ӑ�}�X�^��蓾�Ӑ拒�_�R�[�h
            retSCMAcOdrData.InqOtherEpCd = salesSlip.EnterpriseCode; // �⍇�����ƃR�[�h : ����f�[�^����ƃR�[�h
            retSCMAcOdrData.InqOtherSecCd = salesSlip.SectionCode; // �⍇���拒�_�R�[�h : ����f�[�^��苒�_�R�[�h
            //retSCMAcOdrData.InquiryNumber = -1; // �⍇���ԍ� : -1���Œ�ŃZ�b�g// DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrData.InquiryNumber = 0; // �⍇���ԍ�                      // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrData.CustomerCode = salesSlip.CustomerCode; // ���Ӑ�R�[�h : ����f�[�^��蓯����
            retSCMAcOdrData.AnswerDivCd = 20; // �񓚋敪 : 20���Œ�ŃZ�b�g
            retSCMAcOdrData.InqOrdNote = salesSlip.SlipNote; // �⍇���E�������l : ����f�[�^���`�[���l
            retSCMAcOdrData.AnsEmployeeCd = salesSlip.SalesEmployeeCd; // �񓚏]�ƈ��R�[�h : ����f�[�^���̔��]�ƈ��R�[�h
            retSCMAcOdrData.AnsEmployeeNm = salesSlip.SalesEmployeeNm; // �񓚏]�ƈ����� : ����f�[�^���̔��]�ƈ�����
            retSCMAcOdrData.InquiryDate = salesSlip.SalesDate; // �⍇���� : ����f�[�^��蔄����t
            retSCMAcOdrData.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // �󒍃X�e�[�^�X : ����f�[�^��蓯����
            retSCMAcOdrData.SalesSlipNum = salesSlip.SalesSlipNum; // ����`�[�ԍ� : ����f�[�^��蓯����
            retSCMAcOdrData.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j : ����f�[�^��蓯����
            retSCMAcOdrData.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // ���㏬�v�i�Łj : ����f�[�^��蓯����
            retSCMAcOdrData.InqOrdDivCd = 2; // �⍇���E������� : 2���Œ�ŃZ�b�g
            retSCMAcOdrData.InqOrdAnsDivCd = 2; // �┭�E�񓚎�� : 2���Œ�ŃZ�b�g
            retSCMAcOdrData.SfPmCprtInstSlipNo = salesSlip.PartySaleSlipNum; // SF-PM�A�g�w�����ԍ� : ����f�[�^��葊���`�[�ԍ�
            retSCMAcOdrData.AcceptOrOrderKind = 1; // �󔭒���� : 1���Œ�ŃZ�b�g
            retSCMAcOdrData.TabUseDiv = 1; //�^�u���b�g�g�p�敪: 0�F�g�p���Ȃ�,1�F�g�p���� // ADD 2013/07/09 songg Redmine#38015
            // ADD 2013/07/26 yugami �Г��w�E�ꗗ��431�Ή� -------------------------------------------->>>>>
            retSCMAcOdrData.AnswerCreateDiv = 2; // �񓚍쐬�敪: 2���Œ�ŃZ�b�g
            // ADD 2013/07/26 yugami �Г��w�E�ꗗ��431�Ή� --------------------------------------------<<<<<

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return retSCMAcOdrData;
        }

        /// <summary>
        /// SCM�󒍃f�[�^�i�ԗ����j���쐬
        /// </summary>
        /// <param name="acceptOdrCar">�ԗ��Ǘ��f�[�^</param>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="pmTabSalesDtCar">PMTAB�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <param name="pmTabAcpOdrCar">PMTAB�󒍃}�X�^(�ԗ�)</param>
        /// <returns>SCM�󒍃f�[�^�i�ԗ����j</returns>
        //private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(AcceptOdrCarWork acceptOdrCar, SalesSlipWork salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo) // DEL 2013/06/28 qijh Redmine#37389
        //private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(CarManagementWork acceptOdrCar, SalesSlipWork salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo, PmTabAcpOdrCarWork pmTabAcpOdrCar) // ADD 2013/06/28 qijh Redmine#37389 // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(CarManagementWork acceptOdrCar, SalesSlip salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo, PmTabAcpOdrCarWork pmTabAcpOdrCar) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrDtCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            SCMAcOdrDtCarWork retSCMAcOdrDtCar = new SCMAcOdrDtCarWork();

            retSCMAcOdrDtCar.EnterpriseCode = acceptOdrCar.EnterpriseCode; // ��ƃR�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.UpdEmployeeCode = acceptOdrCar.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.UpdAssemblyId1 = acceptOdrCar.UpdAssemblyId1; // �X�V�A�Z���u��ID1 : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.UpdAssemblyId2 = acceptOdrCar.UpdAssemblyId2; // �X�V�A�Z���u��ID2 : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.LogicalDeleteCode = acceptOdrCar.LogicalDeleteCode; // �_���폜�敪 : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // �⍇������ƃR�[�h : ���Ӑ�}�X�^��蓾�Ӑ��ƃR�[�h//@@@@20230303
            retSCMAcOdrDtCar.InqOriginalSecCd = customerInfo.CustomerSecCode; // �⍇�������_�R�[�h : ���Ӑ�}�X�^��蓾�Ӑ拒�_�R�[�h
            // retSCMAcOdrDtCar.InquiryNumber = -1; // �⍇���ԍ� : -1���Œ�ŃZ�b�g // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.InquiryNumber = 0; // �⍇���ԍ�                        // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.NumberPlate1Code = acceptOdrCar.NumberPlate1Code; // ���^�������ԍ� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.NumberPlate1Name = acceptOdrCar.NumberPlate1Name; // ���^�����ǖ��� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.NumberPlate2 = acceptOdrCar.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.NumberPlate3 = acceptOdrCar.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.NumberPlate4 = acceptOdrCar.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // �^���w��ԍ� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.CategoryNo = acceptOdrCar.CategoryNo; // �ޕʔԍ� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.MakerCode = acceptOdrCar.MakerCode; // ���[�J�[�R�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.ModelCode = acceptOdrCar.ModelCode; // �Ԏ�R�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.ModelSubCode = acceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.FullModel = acceptOdrCar.FullModel; // �^���i�t���^�j : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.FrameNo = acceptOdrCar.FrameNo; // �ԑ�ԍ� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.FrameModel = acceptOdrCar.FrameModel; // �ԑ�^�� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.RpColorCode = acceptOdrCar.ColorCode; // ���y�A�J���[�R�[�h : �󒍃}�X�^�i�ԗ��j���J���[�R�[�h
            retSCMAcOdrDtCar.ColorName1 = acceptOdrCar.ColorName1; // �J���[����1 : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.TrimCode = acceptOdrCar.TrimCode; // �g�����R�[�h : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.TrimName = acceptOdrCar.TrimName; // �g�������� : �󒍃}�X�^�i�ԗ��j��蓯����
            //retSCMAcOdrDtCar.AcptAnOdrStatus = acceptOdrCar.AcptAnOdrStatus; // �󒍃X�e�[�^�X : �󒍃}�X�^�i�ԗ��j��蓯����
            //retSCMAcOdrDtCar.AcptAnOdrStatus = pmTabAcpOdrCar.AcptAnOdrStatus; // �󒍃X�e�[�^�X : �󒍃}�X�^�i�ԗ��j��蓯����  // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.AcptAnOdrStatus = pmTabSalesDtCar.AcptAnOdrStatus;  // �󒍃X�e�[�^�X                                 // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.EngineModelNm = acceptOdrCar.EngineModelNm; // �G���W���^������ : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.FirstEntryDateNumTyp = acceptOdrCar.FirstEntryDate; // ���N�x�iNUM�^�C�v�j : �󒍃}�X�^�i�ԗ��j��蓯����
            // UPD 2013/07/19 �g�� �w�E�m�F�����ꗗ��373�Ή� -------->>>>>>>>>>>>>>>>>>>>>
            // retSCMAcOdrDtCar.EquipPrtsObj = acceptOdrCar.CategoryObjAry; // �������i�I�u�W�F�N�g : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.EquipPrtsObj = new byte[0];  // �������i�I�u�W�F�N�g : �ݒ薳���i���`���炢���Ȃ�񓚂̏ꍇ�͐ݒ薳���j
            // UPD 2013/07/19 �g�� �w�E�m�F�����ꗗ��373�Ή� --------<<<<<<<<<<<<<<<<<<<<<<
            retSCMAcOdrDtCar.SalesSlipNum = salesSlip.SalesSlipNum; // ����`�[�ԍ� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.ProduceTypeOfYearNum = pmTabSalesDtCar.ProduceTypeOfYearNum; // ���Y�N���iNUM�^�C�v�j : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.CarNo = pmTabSalesDtCar.CarNo; // ���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.MakerName = pmTabSalesDtCar.MakerName; // ���[�J�[���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.GradeName = pmTabSalesDtCar.GradeName; // �O���[�h���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.BodyName = pmTabSalesDtCar.BodyName; // �{�f�B�[���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.DoorCount = pmTabSalesDtCar.DoorCount; // �h�A�� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.CmnNmEngineDisPlace = pmTabSalesDtCar.CmnNmEngineDisPlace; // �ʏ̔r�C�� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.EngineModel = pmTabSalesDtCar.EngineModel; // �����@�^���i�G���W���j : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.NumberOfGear = pmTabSalesDtCar.NumberOfGear; // �ϑ��i�� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.GearNm = pmTabSalesDtCar.GearNm; // �ϑ��@���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.EDivNm = pmTabSalesDtCar.EDivNm; // E�敪���� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.TransmissionNm = pmTabSalesDtCar.TransmissionNm; // �~�b�V�������� : �󒍃}�X�^�i�ԗ��j��蓯����
            retSCMAcOdrDtCar.ShiftNm = pmTabSalesDtCar.ShiftNm; // �V�t�g���� : �󒍃}�X�^�i�ԗ��j��蓯����
            // --------------- ADD START 2013/07/09 wangl2 FOR Redmine#38014------>>>>
            retSCMAcOdrDtCar.ModelName = pmTabSalesDtCar.ModelName; // �Ԏ햼�FPMTAB����f�[�^�i�ԗ����j��蓯����
            //retSCMAcOdrDtCar.CarInspectCertModel = acceptOdrCar.FullModel;// �^���i�t���^�j : �󒍃}�X�^�i�ԗ��j��蓯����// DEL 2013/07/19 qijh FOR Redmine#38783
            // --------------- ADD END 2013/07/09 wangl2 FOR Redmine#38014--------<<<<
            // --------------- ADD START 2013/07/19 qijh FOR Redmine#38783------>>>>
            // �Ԍ��،^���@: �󒍃}�X�^�i�ԗ��j���ݒ�
            string carInspectCertModel = string.Empty;
            if (acceptOdrCar.ExhaustGasSign != string.Empty)
            {
                carInspectCertModel = acceptOdrCar.ExhaustGasSign;
                if (acceptOdrCar.SeriesModel != string.Empty) carInspectCertModel = carInspectCertModel + '-' + acceptOdrCar.SeriesModel;
            }
            else
            {
                if (acceptOdrCar.SeriesModel != string.Empty) carInspectCertModel = acceptOdrCar.SeriesModel;
            }
            retSCMAcOdrDtCar.CarInspectCertModel = carInspectCertModel;
            // --------------- ADD END 2013/07/19 qijh FOR Redmine#38783--------<<<<
            // UPD 2013/07/19 �g�� �w�E�m�F�����ꗗ��373�Ή� -------->>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //if (retSCMAcOdrDtCar.EquipPrtsObj == null)
            //    retSCMAcOdrDtCar.EquipPrtsObj = new byte[0];
            //if (retSCMAcOdrDtCar.CarAddInf == null)
            //    retSCMAcOdrDtCar.CarAddInf = new byte[0];
            //if (retSCMAcOdrDtCar.EquipObj == null)
            //    retSCMAcOdrDtCar.EquipObj = new byte[0];
            #endregion
            // ���`���炢���Ȃ�񓚂̏ꍇ�͂��ݒ薳��
            retSCMAcOdrDtCar.CarAddInf = new byte[0];
            retSCMAcOdrDtCar.EquipObj = new byte[0];
            // UPD 2013/07/19 �g�� �w�E�m�F�����ꗗ��373�Ή� --------<<<<<<<<<<<<<<<<<<<<<<

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return retSCMAcOdrDtCar;
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^�i�񓚁j���쐬
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns>SCM�󒍖��׃f�[�^�i�񓚁j</returns>
        //private SCMAcOdrDtlAsWork GetUpdSCMAcOdrDtlAs(SalesDetailWork salesDetail, CustomerInfo customerInfo) // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDtlAsWork GetUpdSCMAcOdrDtlAs(SalesDetail salesDetail, CustomerInfo customerInfo) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrDtlAs";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            SCMAcOdrDtlAsWork retSCMAcOdrDtlAs = new SCMAcOdrDtlAsWork();

            retSCMAcOdrDtlAs.EnterpriseCode = salesDetail.EnterpriseCode; // ��ƃR�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // �X�V�A�Z���u��ID1 : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // �X�V�A�Z���u��ID2 : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // �_���폜�敪 : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // �⍇������ƃR�[�h : ���Ӑ�}�X�^��蓾�Ӑ��ƃR�[�h//@@@@20230303
            retSCMAcOdrDtlAs.InqOriginalSecCd = customerInfo.CustomerSecCode; // �⍇�������_�R�[�h : ���Ӑ�}�X�^��蓾�Ӑ拒�_�R�[�h
            retSCMAcOdrDtlAs.InqOtherEpCd = salesDetail.EnterpriseCode; // �⍇�����ƃR�[�h : ���㖾�׃f�[�^����ƃR�[�h
            retSCMAcOdrDtlAs.InqOtherSecCd = salesDetail.SectionCode; // �⍇���拒�_�R�[�h : ���㖾�׃f�[�^��苒�_�R�[�h
            // retSCMAcOdrDtlAs.InquiryNumber = -1; // �⍇���ԍ� : -1���Œ�ŃZ�b�g // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtlAs.InquiryNumber = 0; // �⍇���ԍ�                        // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtlAs.InqRowNumber = -1; // �⍇���s�ԍ� : -1���Œ�ŃZ�b�g
            retSCMAcOdrDtlAs.InqRowNumDerivedNo = -1; // �⍇���s�ԍ��}�� : -1���Œ�ŃZ�b�g
            retSCMAcOdrDtlAs.RecyclePrtKindCode = salesDetail.RecycleDiv; // ���T�C�N�����i��� : ���㖾�׃f�[�^��胊�T�C�N���敪
            retSCMAcOdrDtlAs.RecyclePrtKindName = salesDetail.RecycleDivNm; // ���T�C�N�����i��ʖ��� : ���㖾�׃f�[�^��胊�T�C�N���敪����
            retSCMAcOdrDtlAs.AnswerDeliveryDate = salesDetail.AnswerDelivDate; // �񓚔[�� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.BLGoodsCode = salesDetail.BLGoodsCode; // BL���i�R�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.AnsGoodsName = salesDetail.GoodsName; // �񓚏��i�� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.SalesOrderCount = salesDetail.ShipmentCnt; // ������ : ���㖾�׃f�[�^���o�א�
            retSCMAcOdrDtlAs.DeliveredGoodsCount = salesDetail.ShipmentCnt; // �[�i�� : ���㖾�׃f�[�^���o�א�
            retSCMAcOdrDtlAs.GoodsNo = salesDetail.GoodsNo; // ���i�ԍ� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.GoodsMakerCd = salesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.GoodsMakerNm = salesDetail.MakerName; // ���i���[�J�[���� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.ListPrice = (long)salesDetail.ListPriceTaxExcFl; // �艿 : ���㖾�׃f�[�^���艿�i�Ŕ��C�����j
            retSCMAcOdrDtlAs.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl; // �P�� : ���㖾�׃f�[�^��蔄��P���i�Ŕ��C�����j
            retSCMAcOdrDtlAs.RoughRrofit = (long)(salesDetail.ListPriceTaxExcFl - salesDetail.SalesUnitCost); // �e���z : ���㖾�׃f�[�^���艿�i�Ŕ��C�����j�|�����P��

            // �e���� : ���㖾�׃f�[�^���i����P���i�Ŕ��C�����j�|�����P���j������P���i�Ŕ��C�����j
            retSCMAcOdrDtlAs.RoughRate = 0.0;
            #region DEL 2013/07/23 qijh Redmine#38980 - #5
            //if (salesDetail.ListPriceTaxExcFl > 0.0)
            //{
            //    retSCMAcOdrDtlAs.RoughRate = (salesDetail.ListPriceTaxExcFl - salesDetail.SalesUnitCost) / salesDetail.ListPriceTaxExcFl;
            //    retSCMAcOdrDtlAs.RoughRate = CalculatorAgent.RoundOff(retSCMAcOdrDtlAs.RoughRate, 3); // ADD 2013/07/23 qijh Redmine#38980
            //}
            #endregion  DEL 2013/07/23 qijh Redmine#38980 - #5
            // ------------- ADD 2013/07/23 qijh Redmine#38980 - #5 ---------- >>>>>
            if (salesDetail.SalesUnPrcTaxExcFl > 0.0)
            {
                retSCMAcOdrDtlAs.RoughRate = (salesDetail.SalesUnPrcTaxExcFl - salesDetail.SalesUnitCost) / salesDetail.SalesUnPrcTaxExcFl * 100;
                retSCMAcOdrDtlAs.RoughRate = CalculatorAgent.RoundOff(retSCMAcOdrDtlAs.RoughRate, 3);
            }
            // ------------- ADD 2013/07/23 qijh Redmine#38980 - #5 ---------- <<<<<

            retSCMAcOdrDtlAs.CommentDtl = salesDetail.DtlNote; // ���l(����) : ���㖾�׃f�[�^��薾�ה��l
            retSCMAcOdrDtlAs.ShelfNo = salesDetail.WarehouseShelfNo; // �I�� : ���㖾�׃f�[�^���q�ɒI��
            retSCMAcOdrDtlAs.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // �󒍃X�e�[�^�X : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.SalesSlipNum = salesDetail.SalesSlipNum; // ����`�[�ԍ� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.SalesRowNo = salesDetail.SalesRowNo; // ����s�ԍ� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.CampaignCode = salesDetail.CampaignCode; // �L�����y�[���R�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.InqOrdDivCd = 2; // �⍇���E������� : 2���Œ�ŃZ�b�g
            retSCMAcOdrDtlAs.DisplayOrder = salesDetail.InqRowNumber; // �\������ : ���㖾�׃f�[�^���⍇���s�ԍ�
            retSCMAcOdrDtlAs.WarehouseCode = salesDetail.WarehouseCode; // �q�ɃR�[�h : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.WarehouseName = salesDetail.WarehouseName; // �q�ɖ��� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // �q�ɒI�� : ���㖾�׃f�[�^��蓯����
            retSCMAcOdrDtlAs.PmPrsntCount = 0; // PM���݌ɐ� �����̕␳�����ŃZ�b�g 
            retSCMAcOdrDtlAs.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // ���i�K�i�E���L���� : ���㖾�׃f�[�^��蓯����
            // ADD �g�� 2013/08/07 Redmine#39686 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            retSCMAcOdrDtlAs.InqOrgDtlDiscGuid = Guid.NewGuid();  // �⍇�������׎���GUID
            // ADD �g�� 2013/08/07 Redmine#39686 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/08/29 Redmine#40183�Ή� ------------------------------------------->>>>>
            retSCMAcOdrDtlAs.PureGoodsMakerCd = salesDetail.CmpltGoodsMakerCd;  // �������i���[�J�[�R�[�h�F���㖾�׃f�[�^��胁�[�J�[�R�[�h�i�ꎮ�j
            // ADD 2013/08/29 Redmine#40183�Ή� -------------------------------------------<<<<<

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return retSCMAcOdrDtlAs;
        }
        #endregion �� SCM�f�[�^�쐬

        #region �� ���擾����
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�i���_�ʁj���擾
        /// </summary>
        /// <param name="pmTabTtlStSec">PMTAB�S�̐ݒ�}�X�^�i���_�ʁj���</param>
        private void GetPmTabTtlStSec(out PmTabTtlStSec pmTabTtlStSec)
        {
            pmTabTtlStSec = new PmTabTtlStSec(); // �f�B�t�H���g�l(�����ł��Ȃ��ꍇ���p)
            ArrayList searchResultList = null;
            // ���O�C�����_
            int status = this.PmTabTtlStSecAcs.Search(out searchResultList, this._enterpriseCode, this._loginSectionCode);
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status && null != searchResultList && searchResultList.Count > 0)
            {
                pmTabTtlStSec = searchResultList[0] as PmTabTtlStSec;
                return;
            }
            // �S��
            status = this.PmTabTtlStSecAcs.Search(out searchResultList, this._enterpriseCode, ctSectionCode);
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status && null != searchResultList && searchResultList.Count > 0)
            {
                pmTabTtlStSec = searchResultList[0] as PmTabTtlStSec;
                return;
            }
            // ��L�擾�ł��Ȃ��ꍇ�A�f�B�t�H���g�l��߂�
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------ >>>>>
        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^���擾
        /// </summary>
        private void GetEstimateDefSet()
        {
            ArrayList aList;
            int status = new EstimateDefSetAcs().Search(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) CacheEstimateDefSet(aList, this._enterpriseCode, this._loginSectionCode);
            }
        }

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="estimateDefSetList">���Ϗ����l�ݒ胊�X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void CacheEstimateDefSet(ArrayList estimateDefSetList, string enterpriseCode, string sectionCode)
        {
            if (estimateDefSetList != null)
            {
                List<EstimateDefSet> list = new List<EstimateDefSet>((EstimateDefSet[])estimateDefSetList.ToArray(typeof(EstimateDefSet)));

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == sectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
                if (this._estimateDefSet != null) return;

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

            }
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^���擾
        /// </summary>
        private void GetSalesTtlSt()
        {
            ArrayList aList;
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();
            salesTtlStAcs.IsLocalDBRead = false;
            int status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="salesTtlStList">����S�̐ݒ胊�X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        /// <summary>
        /// �󔭒��S�̐ݒ���擾
        /// </summary>
        private void GetAcptAnOdrTtlSt()
        {
            ArrayList aList;
            AcptAnOdrTtlStAcs acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // �󔭒��S�̐ݒ�}�X�^
            acptAnOdrTtlStAcs.IsLocalDBRead = false;
            int status = acptAnOdrTtlStAcs.Search(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheAcptAnOdrTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }

        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="acptAnOdrTtlStList">�󔭒��Ǘ��S�̐ݒ�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList, string enterpriseCode, string sectionCode)
        {
            if (acptAnOdrTtlStList != null)
            {
                List<AcptAnOdrTtlSt> list = new List<AcptAnOdrTtlSt>((AcptAnOdrTtlSt[])acptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt)));

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._acptAnOdrTtlSt != null) return;

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------ <<<<<

        // DEL �g�� 2013/08/09 Redmine#39820 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        ///// <summary>
        ///// BLP���M�敪���擾
        ///// </summary>
        ///// <param name="psEnterpriseCode">��ƃR�[�h</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="blpSendingDiv">BLP���M�敪</param>
        ///// <param name="errorMessage">�G���[���b�Z�[�W</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private ConstantManagement.MethodResult GetBLPSendingDiv(string psEnterpriseCode, int customerCode,
        //    out int blpSendingDiv, out string errorMessage)
        //{
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    const string methodName = "GetBLPSendingDiv";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        //    errorMessage = string.Empty;
        //    blpSendingDiv = 0;

        //    PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
        //    pmTabTtlStCustWork.EnterpriseCode = psEnterpriseCode;
        //    pmTabTtlStCustWork.CustomerCode = customerCode;

        //    object objSearchCond = pmTabTtlStCustWork;
        //    object objRetList;
        //    int status = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
        //    ArrayList resultList = objRetList as ArrayList;

        //    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == resultList || 0 == resultList.Count)
        //    {
        //        errorMessage = "Not Found";
        //        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR");
        //        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        //        //return ConstantManagement.MethodResult.ctFNC_ERROR; // DEL 2013/06/26 qijh Redmine#37330
        //        // -------- ADD 2013/06/26 qijh Redmine#37330 --------- >>>>>
        //        // �����͏I�������AsendingDiv = 0 �Ƃ��ď����𑱍s
        //        errorMessage = string.Empty;
        //        blpSendingDiv = 0;
        //        return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //        // -------- ADD 2013/06/26 qijh Redmine#37330 --------- <<<<<
        //    }

        //    blpSendingDiv = ((PmTabTtlStCustWork)resultList[0]).BlpSendDiv;
        //    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
        //    // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //}
        #endregion
        // DEL �g�� 2013/08/09 Redmine#39820 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ���Ӑ�����擾
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="piCustomerCode">���Ӑ�R�[�h</param>
        /// <param name="outCustomerInfo">���Ӑ���</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private ConstantManagement.MethodResult GetCustomerInfo(string psEnterpriseCode, int piCustomerCode, out CustomerInfo outCustomerInfo, out string errorMessage)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            errorMessage = string.Empty;
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, psEnterpriseCode, piCustomerCode, true, false, out outCustomerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                errorMessage = "Not Found";
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR");
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ����E�d������I�v�V�������[�N���擾
        /// </summary>
        /// <returns>����E�d������I�v�V�������[�N</returns>
        private IOWriteCtrlOptWork GetIOWriteCtrlOpt()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetIOWriteCtrlOpt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            IOWriteCtrlOptWork ioWriteCtrlOpt = new IOWriteCtrlOptWork();
            {
                // ��ƃR�[�h�c���ʃw�b�_ �����[�g�擾
                ioWriteCtrlOpt.EnterpriseCode = this._enterpriseCode; // ADD 2013/07/09 qijh Redmine#37586

                ioWriteCtrlOpt.CtrlStartingPoint = 0;   // ����N�_(0:����/1:�d��/2:�d�����㓯���v��)

                ioWriteCtrlOpt.AcpOdrrAddUpRemDiv = 0;  // �󒍃f�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)
                ioWriteCtrlOpt.ShipmAddUpRemDiv = 0;    // �o�׃f�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)
                ioWriteCtrlOpt.EstimateAddUpRemDiv = 0; // ���σf�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)

                ioWriteCtrlOpt.RetGoodsStockEtyDiv = 1; // �ԕi���݌ɓo�^�敪(0:����/1:���Ȃ�)
                ioWriteCtrlOpt.RemainCntMngDiv = 0;     // �c���Ǘ��敪(0:���� ���Œ�)

                ioWriteCtrlOpt.SupplierSlipDelDiv = 0;  // �d���`�[�폜�敪(0:�폜���Ȃ�/1:�폜����)
                ioWriteCtrlOpt.CarMngDivCd = 0;    // �ԗ��Ǘ��}�X�^�o�^�敪(0:�폜���Ȃ�/1:�폜����)
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return ioWriteCtrlOpt;
        }

        /// <summary>
        /// ���[�U�[DB��PMTAB�󒍃}�X�^(�ԗ�)���擾
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="psSectionCode">���_�R�[�h</param>
        /// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabAcpOdrCar">PMTAB�󒍃}�X�^(�ԗ�)</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private ConstantManagement.MethodResult GetPmTabAcpOdrCar(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, 
            out PmTabAcpOdrCarWork pmTabAcpOdrCar, out string errorMessage)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetPmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            pmTabAcpOdrCar = null;
            errorMessage = string.Empty;

            // �����p�̃p�����[�^
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();
            pmTabAcpOdrCarWork.EnterpriseCode = psEnterpriseCode;
            pmTabAcpOdrCarWork.SearchSectionCode = psSectionCode;
            pmTabAcpOdrCarWork.BusinessSessionId = psBusinessSessionId;

            object refObj = pmTabAcpOdrCarWork;
            int status = this._iPmTabAcpOdrCarDB.Read(ref refObj, 0);
            pmTabAcpOdrCar = refObj as PmTabAcpOdrCarWork;

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == pmTabAcpOdrCar)
            {
                errorMessage = "Not Found";
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR");
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� return ConstantManagement.MethodResult.ctFNC_NORMAL");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// SCMDB��PMTAB��������擾
        /// </summary>
        /// <param name="psEnterpriseCode">��ƃR�[�h</param>
        /// <param name="psSectionCode">���_�R�[�h</param>
        /// <param name="psBusinessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSalesSlip">PMTAB����f�[�^</param>
        /// <param name="pmTabSaleDetailList">PMTAB���㖾�׃f�[�^���X�g</param>
        /// <param name="pmTabSalesDtCar">PMTAB����f�[�^�i�ԗ����j</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private ConstantManagement.MethodResult GetPmTabSalesSlip(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId,
            out PmTabSalesSlipWork pmTabSalesSlip, out List<PmTabSaleDetailWork> pmTabSaleDetailList, out PmTabSalesDtCarWork pmTabSalesDtCar, out string errorMessage)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetPmTabSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            pmTabSalesSlip = null;
            pmTabSaleDetailList = null;
            pmTabSalesDtCar = null;
            errorMessage = string.Empty;

            // �����p�̃p�����[�^
            PmTabSalesSlipParaWork pmTabSalesSlipPara = new PmTabSalesSlipParaWork();
            pmTabSalesSlipPara.EnterpriseCode = psEnterpriseCode;
            pmTabSalesSlipPara.SearchSectionCode = psSectionCode;
            pmTabSalesSlipPara.BusinessSessionId = psBusinessSessionId;

            // SCMDB��PMTAB��������擾
            object retObj;
            bool msgDiv;
            int status = this._iPmTabSalesSlipDB.Search(pmTabSalesSlipPara, out retObj, out msgDiv, out errorMessage);
            CustomSerializeArrayList retArrayList = retObj as CustomSerializeArrayList;

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == retArrayList || 0 == retArrayList.Count)
            {
                errorMessage = "Not Found";
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR");
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            foreach (object objItem in retArrayList)
            {
                // �擾��������߂��p�����[�^�ɃZ�b�g
                if (objItem is PmTabSalesSlipWork)
                {
                    // PMTAB����f�[�^
                    pmTabSalesSlip = objItem as PmTabSalesSlipWork;
                }
                else if (objItem is PmTabSalesDtCarWork)
                {
                    // PMTAB����f�[�^(�ԗ�)
                    pmTabSalesDtCar = objItem as PmTabSalesDtCarWork;
                }
                else if (objItem is ArrayList)
                {
                    ArrayList tempList = objItem as ArrayList;
                    if (0 == tempList.Count) continue;

                    if (tempList[0] is PmTabSaleDetailWork)
                        // PMTAB���㖾�׃f�[�^���X�g
                        pmTabSaleDetailList = new List<PmTabSaleDetailWork>((PmTabSaleDetailWork[])tempList.ToArray(typeof(PmTabSaleDetailWork)));
                    else
                        continue;
                }
                else
                {
                    continue;
                }
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //if (null != pmTabSalesSlip && null != pmTabSaleDetailList && pmTabSaleDetailList.Count > 0)
            //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
            if (null != pmTabSalesSlip && null != pmTabSaleDetailList && pmTabSaleDetailList.Count > 0)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            errorMessage = "Not Found";
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_ERROR;
        }
        #endregion  �� ���擾����

        #region �� �`�[��������
        // --------------------- ADD 2013/07/03 qijh Redmine#37586 ------------------- >>>>>
        /// <summary>
        /// SCM���擾
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetailList">���㖾�׃��X�g</param>
        /// <param name="carManagement">�ԗ��Ǘ��f�[�^</param>
        /// <param name="pmTabSalesDtCar">PMTAB����f�[�^(�ԗ�)</param>
        /// <param name="pmTabAcpOdrCar">PMTAB�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <param name="scmAcOdrDataWork">SCM�󒍃f�[�^</param>
        /// <param name="scmAcOdrDtlAsList">SCM�󒍖��׃f�[�^�i�񓚁j</param>
        /// <param name="scmAcOdrDtCar">SCM�󒍃f�[�^�i�ԗ����j</param>
        /// <param name="beforeSalesRowNum">�ύX�O����s�ԍ�</param>
        // UPD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private void GetScmDataInfo(SalesSlip salesSlip, List<SalesDetail> salesDetailList, CarManagementWork carManagement, PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar,
        //    CustomerInfo customerInfo, out SCMAcOdrDataWork scmAcOdrDataWork, out List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList, out SCMAcOdrDtCarWork scmAcOdrDtCar)
        private void GetScmDataInfo(SalesSlip salesSlip, List<SalesDetail> salesDetailList, CarManagementWork carManagement, PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar,
            CustomerInfo customerInfo, out SCMAcOdrDataWork scmAcOdrDataWork, out List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList, out SCMAcOdrDtCarWork scmAcOdrDtCar
            ,List<int> beforeSalesRowNum
            )
        // UPD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string methodName = "GetScmDataInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            // SCM�󒍃f�[�^���쐬
            scmAcOdrDataWork = GetUpdSCMAcOdrData(salesSlip, customerInfo);

            // SCM�󒍖��׃f�[�^�i�񓚁j���쐬
            scmAcOdrDtlAsList = new List<SCMAcOdrDtlAsWork>();
            for (int i = 0; i < salesDetailList.Count; i++)
            {
                SCMAcOdrDtlAsWork scmAcOdrDtlAsWork = GetUpdSCMAcOdrDtlAs(salesDetailList[i], customerInfo);
                // -------------- ADD 2013/07/25 wangl2 Redmine#39166 ----------- >>>>>
                scmAcOdrDtlAsWork.GoodsDivCd = (scmAcOdrDtlAsWork.RecyclePrtKindCode != 0) ? 2 : salesDetailList[i].GoodsKindCode;
                if (salesDetailList[i].SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                {
                    scmAcOdrDtlAsWork.GoodsDivCd = 99; // �l����
                    scmAcOdrDtlAsWork.UnitPrice = (long)salesDetailList[i].SalesMoneyTaxExc;// ������z�i�Ŕ��j
                }
                // -------------- ADD 2013/07/25 wangl2 Redmine#39166 ----------- <<<<<
                scmAcOdrDtlAsWork.InqRowNumber = (i + 1) * -1; // �⍇���s�ԍ������̔�(-1 -2 -3....)  // ADD 2013/07/08 qijh Redmine#37980
                scmAcOdrDtlAsWork.PmPrsntCount = GetPmPrsntCount(salesSlip, salesDetailList[i]); // PM���݌ɐ�
                // ADD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �񓚏������i�ԍ�
                // ADD 2013/08/30 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (salesDetailList[i].GoodsSearchDivCd.Equals(1) && salesDetailList[i].GoodsMakerCd >= 1000)
                {
                    // �i�Ԍ��� ���� �D�ǃ��[�J�[(�����i�ԓ_�t�������̏ꍇ)
                    foreach (SCMAcOdrDtlAsWork wk in sCMAcOdrDtlAsWorkForAnsPureGoodsNo)
                    {
                        if (wk.SalesRowNo.Equals(beforeSalesRowNum[i]))
                        {
                            if (wk.AnsPureGoodsNo.Trim().Equals(string.Empty))
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = scmAcOdrDtlAsWork.GoodsNo;
                            }
                            else
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = wk.AnsPureGoodsNo;
                            }
                            scmAcOdrDtlAsWork.BLGoodsCode = wk.BLGoodsCode;
                            break;
                        }
                    }
                }
                else
                // ADD 2013/08/30 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (salesDetailList[i].GoodsSearchDivCd.Equals(1))
                {
                    // �i�Ԍ����̏ꍇ
                    scmAcOdrDtlAsWork.AnsPureGoodsNo = salesDetailList[i].GoodsNo;
                }
                else if (salesDetailList[i].GoodsSearchDivCd.Equals(0))
                {
                    // BL�����̏ꍇ
                    foreach (SCMAcOdrDtlAsWork wk in sCMAcOdrDtlAsWorkForAnsPureGoodsNo)
                    {
                        if (wk.SalesRowNo.Equals(beforeSalesRowNum[i]))
                        {
                            if (wk.AnsPureGoodsNo.Trim().Equals(string.Empty))
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = scmAcOdrDtlAsWork.GoodsNo;
                            }
                            else
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = wk.AnsPureGoodsNo;
                            }
                            scmAcOdrDtlAsWork.BLGoodsCode = wk.BLGoodsCode;
                            break;
                        }
                    }
                }
                // ADD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                scmAcOdrDtlAsList.Add(scmAcOdrDtlAsWork);
            }

            // SCM�󒍃f�[�^�i�ԗ����j���쐬
            scmAcOdrDtCar = GetUpdSCMAcOdrDtCar(carManagement, salesSlip, pmTabSalesDtCar, customerInfo, pmTabAcpOdrCar);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// �`�[����
        /// </summary>
        /// <param name="paramSalesSlip">����f�[�^</param>
        /// <param name="paramSalesDetailList">���㖾�׃��X�g</param>
        /// <param name="paramCarManagement">�ԗ��Ǘ��f�[�^</param>
        /// <param name="pmTabSalesDtCar">PMTAB����f�[�^(�ԗ�)</param>
        /// <param name="pmTabAcpOdrCar">PMTAB�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <param name="pmtabSessionList">PMTAB�Z�b�V�����Ǘ��f�[�^���X�g</param>
        /// <returns>�������ꂽ�o�^�p�`�[���X�g</returns>
        // ------ UPD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        //private CustomSerializeArrayList SplitSlipData(SalesSlip SplitSlipData, List<SalesDetail> paramSalesDetailList, CarManagementWork paramCarManagement, 
        //    PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar, CustomerInfo customerInfo)
        private CustomSerializeArrayList SplitSlipData(SalesSlip paramSalesSlip, List<SalesDetail> paramSalesDetailList, CarManagementWork paramCarManagement, 
            PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar, CustomerInfo customerInfo, ArrayList pmtabSessionList)
        // ----- UPD 2017/03/30 ���O Redmine#49164 ---------------- <<<<
        {
            const string methodName = "SplitSlipData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            // �o�^�p�̓`�[���X�g
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            // ���ו���
            List<List<SalesDetail>> slipDetailList = SplitDetailData(paramSalesSlip, paramSalesDetailList);
            int slipDtlRegOrder = 0; // �������ꂽ�`�[�̓o�^���𐧌� // ADD 2013/07/09 qijh Redmine#37586

            // �`�[����
            foreach (List<SalesDetail> detailList in slipDetailList)
            {
                // �`�[���X�g
                CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                retList.Add(slipList);

                // ����f�[�^
                SalesSlip updSalesSlip = paramSalesSlip.Clone();

                // ���㖾�׃f�[�^���W�v
                AddItUpSalesDetailData(updSalesSlip, detailList);

                // ���׏W�v�̕␳
                ReviseAddItUpSalesDetailData(updSalesSlip, detailList); // ADD 2013/07/24 qijh Redmine#39026

                // ���㖾�׃��X�g
                ArrayList updSalesDetailList = new ArrayList();
                // ADD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                List<int> beforeSalesRowNo = new List<int>();
                // ADD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                for (int i = 0; i < detailList.Count; i++)
                {
                    SalesDetail updSalesDetail = detailList[i];
                    // ADD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �C���O�̔���s�ԍ���ۊ�
                    beforeSalesRowNo.Add(updSalesDetail.SalesRowNo);
                    // ADD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    updSalesDetail.SalesRowNo = i + 1;
                    updSalesDetailList.Add(CreateSalesDetailWork(updSalesDetail));
                }

                // �󒍃X�e�[�^�X������ && ���|�敪�����i �̏ꍇ�ɐݒ�
                if (updSalesSlip.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && updSalesSlip.AccRecDivCd.Equals(0))
                {
                    // �����f�[�^
                    SearchDepsitMain depsitMain = null;                             // �����f�[�^�I�u�W�F�N�g
                    SearchDepositAlw depositAlw = null;                             // ���������f�[�^�I�u�W�F�N�g
                    this.GetCurrentDepsitMain(ref updSalesSlip, out depsitMain, out depositAlw);

                    if (updSalesSlip.AccRecDivCd == 0)
                    {
                        slipList.Add(ParamDataFromUIData(depsitMain)); // �����f�[�^�ǉ�
                        slipList.Add((DepositAlwWork)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlw, typeof(DepositAlwWork)));
                    }
                }

                slipList.Add(CreateSalesSlipWork(updSalesSlip)); // ����f�[�^
                slipList.Add(updSalesDetailList); // ���㖾�׃��X�g

                // �ԗ��Ǘ��f�[�^
                ArrayList updCarManagementList = new ArrayList();
                slipList.Add(updCarManagementList);
                updCarManagementList.Add(paramCarManagement);
                
                // �����[�g�Q�Ɨp���׃p�����[�^
                //slipList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList, paramCarManagement)); // DEL 2013/07/09 qijh Redmine#37586
                slipList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList, paramCarManagement, ref slipDtlRegOrder)); // ADD 2013/07/09 qijh Redmine#37586

                // SCM�f�[�^�擾
                if (this._isConnScm)
                {
                    // SCM�A�g
                    SCMAcOdrDataWork scmAcOdrDataWork;
                    List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList;
                    SCMAcOdrDtCarWork scmAcOdrDtCar;
                    // UPD 2013/08/16 �g�� Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // GetScmDataInfo(updSalesSlip, detailList, paramCarManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo,
                    //    out  scmAcOdrDataWork, out scmAcOdrDtlAsList, out scmAcOdrDtCar);
                    GetScmDataInfo(updSalesSlip, detailList, paramCarManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo,
                        out  scmAcOdrDataWork, out scmAcOdrDtlAsList, out scmAcOdrDtCar, beforeSalesRowNo);
                    // UPD 2013/08/16 �g�� Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // SCM�󒍃f�[�^
                    slipList.Add(scmAcOdrDataWork);

                    // SCM�󒍖��׃f�[�^(��)
                    ArrayList updScmAcOdrDtlAsList = new ArrayList();
                    updScmAcOdrDtlAsList.AddRange(scmAcOdrDtlAsList);
                    slipList.Add(updScmAcOdrDtlAsList);
                    
                    // SCM�󒍃f�[�^(�ԗ����)
                    slipList.Add(scmAcOdrDtCar);
                }
                // PMTAB�Z�b�V�����Ǘ����ǉ�
                slipList.Add(pmtabSessionList);// ADD 2017/03/30 ���O Redmine#49164
            }

            // ����I�v�V�������[�N
            retList.Add(GetIOWriteCtrlOpt());

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return retList;
        }

        /// <summary>
        /// ���㖾�ׂ𕪊�
        /// </summary>
        /// <param name="updSalesSlip">����f�[�^</param>
        /// <param name="updSalesDetailList">���㖾�׃��X�g</param>
        /// <returns>�������ꂽ���㖾�׃��X�g</returns>
        private List<List<SalesDetail>> SplitDetailData(SalesSlip updSalesSlip, List<SalesDetail> updSalesDetailList)
        {
            const string methodName = "SplitDetailData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int maxRowCount = GetMaxRowCount(updSalesSlip); // ���׍ő�s��

            // UPD 2013/08/14 �g�� Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // IList<SalesDetail> sortedSalesDetailList = SortedSalesDetailListFactory.CreateSortedSalesDetailList(updSalesSlip, updSalesDetailList); // �\�[�g�ςݔ��㖾�׃f�[�^���X�g
            IList<SalesDetail> sortedSalesDetailList = CreateSortedSalesDetailList(updSalesSlip, updSalesDetailList); // �\�[�g�ςݔ��㖾�׃f�[�^���X�g
            // UPD 2013/08/14 �g�� Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            List<List<SalesDetail>> retList = new List<List<SalesDetail>>();
            List<SalesDetail> detailList = null;
            // UPD 2013/08/14 �g�� Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //for (int i = 0; i < sortedSalesDetailList.Count; i++)
            //{
            //    if (i % maxRowCount == 0)
            //    {
            //        detailList = new List<SalesDetail>();
            //        retList.Add(detailList);
            //    }
            //    detailList.Add(sortedSalesDetailList[i]);
            //}
            #endregion
            SlipKey slipKey = new SlipKey();
            SlipKey saveSlipKey = new SlipKey();
            // ���[�v�J�n�O�����l�ݒ�
            if (sortedSalesDetailList != null && sortedSalesDetailList.Count > 0)
            {
                saveSlipKey = MakeSlipKey(sortedSalesDetailList[0].SalesOrderDivCd, sortedSalesDetailList[0].WarehouseCode);
            }
            int rowCount = 0;
            detailList = new List<SalesDetail>();
            retList.Add(detailList);

            foreach (SalesDetail row in sortedSalesDetailList)
            {
                rowCount++;

                // ����u���C�N�L�[�擾
                slipKey = MakeSlipKey(row.SalesOrderDivCd, row.WarehouseCode);

                // �ő�s �܂��� ����S�̐ݒ�D�`�[�쐬���@�ɉ������L�[�u���C�N
                if (rowCount > maxRowCount || !slipKey.Equals(saveSlipKey))
                {
                    // UPD 2013/09/11 �g��  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // rowCount = 0;
                    rowCount = 1;
                    // UPD 2013/09/11 �g��  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    saveSlipKey = new SlipKey();
                    detailList = new List<SalesDetail>();
                    retList.Add(detailList);
                }

                detailList.Add(row);
                saveSlipKey = slipKey;
            }
            // UPD 2013/08/14 �g�� Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return retList;
        }

        // ADD 2013/08/14 �g�� Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ����f�[�^�쐬�u���C�N�L�[�\����
        /// </summary>
        internal struct SlipKey
        {
            /// <summary> �݌ɁE���敪 </summary>
            int _salesOrderDivCd;
            /// <summary> �q�ɃR�[�h </summary>
            string _warehouseCode;
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="salesOrderDivCd">�݌ɁE���敪</param>
            /// <param name="warehouseCode">�q�ɃR�[�h</param>
            internal SlipKey(int salesOrderDivCd, string warehouseCode)
            {
                this._salesOrderDivCd = salesOrderDivCd;
                this._warehouseCode = warehouseCode;
            }
            /// <summary>
            /// �݌ɁE���敪
            /// </summary>
            internal int SalesOrderDivCd
            {
                get { return this._salesOrderDivCd; }
                set { this._salesOrderDivCd = value; }
            }
            /// <summary>
            /// �q�ɃR�[�h
            /// </summary>
            internal string WarehouseCode
            {
                get { return this._warehouseCode; }
                set { this._warehouseCode = value; }
            }
        }

        /// <summary>
        /// �f�[�^�쐬�u���C�N�L�[�쐬����
        /// </summary>
        /// <param name="salesOrderDivCd"></param>
        /// <param name="warehouseCode"></param>
        /// <returns></returns>
        private SlipKey MakeSlipKey(int salesOrderDivCd, string warehouseCode)
        {
            SlipKey slipKey = new SlipKey();
            switch (this.SalesTtlSt.SlipCreateProcess)
            {
                case 0:
                    // ���͏�(�s�ԍ���)
                    slipKey = new SlipKey();
                    break;
                case 1:
                    // �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)
                    slipKey = new SlipKey(salesOrderDivCd, string.Empty);
                    break;
                case 2:
                    // �q�ɏ�(�q�ɁE�s�ԍ���)
                    slipKey = new SlipKey(0, warehouseCode);
                    break;
                case 3:
                    // �o�͐��(�q�ɁE�s�ԍ���)
                    slipKey = new SlipKey(0, warehouseCode);
                    break;
            }
            return slipKey;
        }
        // ADD 2013/08/14 �g�� Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<



        /// <summary>
        /// ���㖾�׃f�[�^���W�v
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetailList">���㖾�׃��X�g</param>
        /// <remarks>PMSCM01012A��AddItUpSalesDetailData���ڐA</remarks>
        private void AddItUpSalesDetailData(SalesSlip salesSlip, List<SalesDetail> salesDetailList)
        {
            const string methodName = "AddItUpSalesDetailData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            SalesSlip SalesSlipData = salesSlip;
            List<SalesDetail> SalesDetailDataList = salesDetailList;

            SalesSlipData.DetailRowCount = SalesDetailDataList.Count;   // 109.���׍s��

            OtherAppComponent otherComponent = new OtherAppComponent(
                SalesSlipData.EnterpriseCode,
                SalesSlipData.SectionCode
            );
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h // ADD  2013/07/24 wangl2 FOR Redmine#39027
            #region <�߂�l�̐錾>

            // --- DEL 2013/08/09 �g�� Redmine#39780 �߂� ---------->>>>>
            #region ���\�[�X
            //// ADD �g�� 2013/08/08 Redmine#39780 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //int taxFracProcCd;          // �[�������敔 
            //// ADD �g�� 2013/08/08 Redmine#39780 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // --- DEL 2013/08/09 �g�� Redmine#39780 �߂� ----------<<<<<

            long salesTotalTaxInc;      // ����`�[���v�i�ō��j
            long salesTotalTaxExc;      // ����`�[���v�i�Ŕ��j
            long salesSubtotalTax;      // ���㏬�v�i�Łj
            long itdedSalesOutTax;      // ����O�őΏۊz
            long itdedSalesInTax;       // ������őΏۊz
            long salSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
            long salesOutTax;           // ������z����Ŋz�i�O�Łj
            long salAmntConsTaxInclu;   // ������z����Ŋz�i���Łj
            long salesDisTtlTaxExc;     // ����l�����z�v�i�Ŕ��j
            long itdedSalesDisOutTax;   // ����l���O�őΏۊz���v
            long itdedSalesDisInTax;    // ����l�����őΏۊz���v
            long itdedSalesDisTaxFre;   // ����l����ېőΏۊz���v
            long salesDisOutTax;        // ����l������Ŋz�i�O�Łj
            long salesDisTtlTaxInclu;   // ����l������Ŋz�i���Łj
            long totalCost;             // �������z�v

            long stockGoodsTtlTaxExc;   // �݌ɏ��i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
            long pureGoodsTtlTaxExc;    // �������i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
            long balanceAdjust;         // ����Œ����z             �c����f�[�^�ɖ����H
            long taxAdjust;             // �c�������z               �c����f�[�^�ɖ����H

            long salesPrtSubttlInc;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc;     // ���㕔�i���v�i�Ŕ��j
            long salesWorkSubttlInc;    // �����Ə��v�i�ō��j
            long salesWorkSubttlExc;    // �����Ə��v�i�Ŕ��j
            long itdedPartsDisInTax;    // ���i�l���Ώۊz���v�i�ō��j
            long itdedPartsDisOutTax;   // ���i�l���Ώۊz���v�i�Ŕ��j
            long itdedWorkDisInTax;     // ��ƒl���Ώۊz���v�i�ō��j
            long itdedWorkDisOutTax;    // ��ƒl���Ώۊz���v�i�Ŕ��j

            long totalMoneyForGrossProfit;  // �e���v�Z�p������z   �c����f�[�^�ɖ����H

            #endregion // </�߂�l�̐錾>

            #region <�ďo��>

            otherComponent.CalculationSalesTotalPrice(
                SalesDetailDataList, // ���㖾�׃f�[�^���X�g
                SalesSlipData.ConsTaxRate,              // ����Őŗ�
                //SalesSlipData.FractionProcCd,           // ����Œ[�������R�[�h// DEL  2013/07/24 wangl2 FOR Redmine#39027
                salesTaxFrcProcCd,                         // ����Œ[�������R�[�h// ADD  2013/07/24 wangl2 FOR Redmine#39027
                SalesSlipData.TotalAmountDispWayCd,     // ���z�\�����@�敪
                SalesSlipData.ConsTaxLayMethod,         // ����œ]�ŕ���

                // --- DEL 2013/08/09 �g�� Redmine#39780 �߂� ---------->>>>>
                #region ���\�[�X
                //// ADD �g�� 2013/08/08 Redmine#39780 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //this._enterpriseCode,
                //this._customerInfo.CustomerCode,

                //out taxFracProcCd,          // �[�������敪 �i�o�͒l�͖��g�p�j
                //// ADD �g�� 2013/08/08 Redmine#39780 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion
                // --- DEL 2013/08/09 �g�� Redmine#39780 �߂� ----------<<<<<

                out salesTotalTaxInc,       // ����`�[���v�i�ō��j
                out salesTotalTaxExc,       // ����`�[���v�i�Ŕ��j
                out salesSubtotalTax,       // ���㏬�v�i�Łj
                out itdedSalesOutTax,       // ����O�őΏۊz
                out itdedSalesInTax,        // ������őΏۊz
                out salSubttlSubToTaxFre,   // ���㏬�v��ېőΏۊz
                out salesOutTax,            // ������z����Ŋz�i�O�Łj
                out salAmntConsTaxInclu,    // ������z����Ŋz�i���Łj
                out salesDisTtlTaxExc,      // ����l�����z�v�i�Ŕ��j
                out itdedSalesDisOutTax,    // ����l���O�őΏۊz���v
                out itdedSalesDisInTax,     // ����l�����őΏۊz���v
                out itdedSalesDisTaxFre,    // ����l����ېőΏۊz���v
                out salesDisOutTax,         // ����l������Ŋz�i�O�Łj
                out salesDisTtlTaxInclu,    // ����l������Ŋz�i���Łj
                out totalCost,              // �������z�v

                out stockGoodsTtlTaxExc,    // �݌ɏ��i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
                out pureGoodsTtlTaxExc,     // �������i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
                out balanceAdjust,          // ����Œ����z             �c����f�[�^�ɖ����H
                out taxAdjust,              // �c�������z               �c����f�[�^�ɖ����H

                out salesPrtSubttlInc,      // ���㕔�i���v�i�ō��j
                out salesPrtSubttlExc,      // ���㕔�i���v�i�Ŕ��j
                out salesWorkSubttlInc,     // �����Ə��v�i�ō��j
                out salesWorkSubttlExc,     // �����Ə��v�i�Ŕ��j
                out itdedPartsDisInTax,     // ���i�l���Ώۊz���v�i�ō��j
                out itdedPartsDisOutTax,    // ���i�l���Ώۊz���v�i�Ŕ��j
                out itdedWorkDisInTax,      // ��ƒl���Ώۊz���v�i�ō��j
                out itdedWorkDisOutTax,     // ��ƒl���Ώۊz���v�i�Ŕ��j

                out totalMoneyForGrossProfit    // �e���v�Z�p������z   �c����f�[�^�ɖ����H
            );

            #endregion // </�ďo��>

            #region <�߂�l����>
            // -----DEL 2013/07/18 Redmine#38198 ����œ]�ŕ�������ېł̏ꍇ�A���v���z���u0�v�̑Ή�----->>>>>
            //SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc;          // 040.����`�[���v�i�ō��j
            //SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc;          // 041.����`�[���v�i�Ŕ��j
            // -----DEL 2013/07/18  Redmine#38198 ����œ]�ŕ�������ېł̏ꍇ�A���v���z���u0�v�̑Ή�-----<<<<<
            // -----ADD 2013/07/18  Redmine#38198 ����œ]�ŕ�������ېł̏ꍇ�A���v���z���u0�v�̑Ή�----->>>>>
            SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;          // 040.����`�[���v�i�ō��j
            SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;          // 041.����`�[���v�i�Ŕ��j
            // -----ADD 2013/07/18  Redmine#38198 ����œ]�ŕ�������ېł̏ꍇ�A���v���z���u0�v�̑Ή�-----<<<<<
            SalesSlipData.SalesSubtotalTax = salesSubtotalTax;          // 046.���㏬�v�i�Łj
            SalesSlipData.ItdedSalesOutTax = itdedSalesOutTax;          // 054.����O�őΏۊz
            SalesSlipData.ItdedSalesInTax = itdedSalesInTax;            // 055.������őΏۊz
            SalesSlipData.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 056.���㏬�v��ېőΏۊz
            SalesSlipData.SalesOutTax = salesOutTax;                    // 057.������z����Ŋz�i�O�Łj
            SalesSlipData.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 058.������z����Ŋz�i���Łj
            SalesSlipData.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 059.����l�����z�v�i�Ŕ��j
            SalesSlipData.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 060.����l���O�őΏۊz���v
            SalesSlipData.ItdedSalesDisInTax = itdedSalesDisInTax;      // 061.����l�����őΏۊz���v
            SalesSlipData.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 066.����l����ېőΏۊz���v
            SalesSlipData.SalesDisOutTax = salesDisOutTax;              // 067.����l������Ŋz�i�O�Łj
            SalesSlipData.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 068.����l������Ŋz�i���Łj
            SalesSlipData.TotalCost = totalCost;                        // 071.�������z�v
            SalesSlipData.SalesPrtSubttlInc = salesPrtSubttlInc;        // 048.���㕔�i���v�i�ō��j
            SalesSlipData.SalesPrtSubttlExc = salesPrtSubttlExc;        // 049.���㕔�i���v�i�Ŕ��j
            SalesSlipData.SalesWorkSubttlInc = salesWorkSubttlInc;      // 050.�����Ə��v�i�ō��j
            SalesSlipData.SalesWorkSubttlExc = salesWorkSubttlExc;      // 051.�����Ə��v�i�Ŕ��j
            SalesSlipData.ItdedPartsDisInTax = itdedPartsDisInTax;      // 063.���i�l���Ώۊz���v�i�ō��j
            SalesSlipData.ItdedPartsDisOutTax = itdedPartsDisOutTax;    // 062.���i�l���Ώۊz���v�i�Ŕ��j
            SalesSlipData.ItdedWorkDisInTax = itdedWorkDisInTax;        // 065.��ƒl���Ώۊz���v�i�ō��j
            SalesSlipData.ItdedWorkDisOutTax = itdedWorkDisOutTax;      // 064.��ƒl���Ώۊz���v�i�Ŕ��j

            #endregion // </�߂�l����>

            // 042.���㕔�i���v(�ō���)�c���㕔�i���v(�ō���) + ���i�l���Ώۊz���v(�ō���)
            //SalesSlipData.SalesPrtTotalTaxInc = SCMSlipDataFactory.GetSalesPrtTotalTaxInc(SalesSlipData);//DEL �A���� 2013/07/23 Redmine#39024 �s�l�����̔��㕔�i���v�i�ō��j ���㕔�i���v�i�Ŕ����j�̐ݒ�
            SalesSlipData.SalesPrtTotalTaxInc = SalesSlipData.SalesPrtTotalTaxInc; //ADD �A���� 2013/07/23 Redmine#39024 �s�l�����̔��㕔�i���v�i�ō��j ���㕔�i���v�i�Ŕ����j�̐ݒ�
            // 043.���㕔�i���v(�Ŕ���)�c���㕔�i���v(�Ŕ���) + ���i�l���Ώۊz���v(�Ŕ���)
            //SalesSlipData.SalesPrtTotalTaxExc = SCMSlipDataFactory.GetSalesPrtTotalTaxExc(SalesSlipData);//DEL �A���� 2013/07/23 Redmine#39024 �s�l�����̔��㕔�i���v�i�ō��j ���㕔�i���v�i�Ŕ����j�̐ݒ�
            SalesSlipData.SalesPrtTotalTaxExc = SalesSlipData.SalesPrtTotalTaxExc;//ADD �A���� 2013/07/23 Redmine#39024 �s�l�����̔��㕔�i���v�i�ō��j ���㕔�i���v�i�Ŕ����j�̐ݒ�
            // 044.�����ƍ��v(�ō���)�c�����Ə��v(�ō���) + ��ƒl���Ώۊz���v(�ō���)
            SalesSlipData.SalesWorkTotalTaxInc = SCMSlipDataFactory.GetSalesWorkTotalTaxInc(SalesSlipData);
            // 045.�����ƍ��v(�Ŕ���)�c�����Ə��v(�Ŕ���) + ��ƒl���Ώۊz���v(�Ŕ���)
            SalesSlipData.SalesWorkTotalTaxExc = SCMSlipDataFactory.GetSalesWorkTotalTaxExc(SalesSlipData);

            // 046.���㏬�v(�ō���)�c�l������̖��׋��z�̍��v(��ېŊ܂܂�)
            // ������`�[���v(�ō���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
            SalesSlipData.SalesSubtotalTaxInc = SCMSlipDataFactory.GetSalesSubtotalTaxInc(SalesSlipData);
            // 047.���㏬�v(�Ŕ���)�c�l������̖��׋��z�̍��v(��ېŊ܂܂�)
            // ������`�[���v(�Ŕ���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
            SalesSlipData.SalesSubtotalTaxExc = SCMSlipDataFactory.GetSalesSubtotalTaxExc(SalesSlipData);

            // 052.���㐳�����z�c����`�[���v(�Ŕ���) - ����l�����z�v(�Ŕ���)
            SalesSlipData.SalesNetPrice = SCMSlipDataFactory.GetSalesNetPrice(SalesSlipData);

            // 069.���i�l�����c���v�ɑ΂��Ă̕��i�l����
            // �����i�l���Ώۊz���v(�ō���) / ���㕔�i���v(�ō���)
            //SalesSlipData.PartsDiscountRate = SCMSlipDataFactory.GetPartsDiscountRate(SalesSlipData);//DEL  2013/07/24 wangl2 FOR Redmine#39028
            // --------------- ADD START 2013/07/24 wangl2 FOR Redmine#39028------>>>>
            double rate;
            this.GetRate(itdedPartsDisOutTax, salesPrtSubttlExc, out rate);
            salesSlip.PartsDiscountRate = rate;                                                     // ���i�l����
            // --------------- ADD END 2013/07/24 wangl2 FOR Redmine#39028--------<<<<
            // UNDONE:070.�H���l�����c���v�ɑ΂��Ă̍H���l����
            // ����ƒl���Ώۊz���v(�ō���) / �����Ə��v(�ō���)
            SalesSlipData.RavorDiscountRate = SCMSlipDataFactory.GetRavorDiscountRate(SalesSlipData);

            // UNDONE:075.���|����Łc�Z�o

            // 079.���������c���c����`�[���v(�ō�) ����œ]�ŕ������u�����]�ŁA��ېŁv�̏ꍇ�͐Ŕ����z
            SalesSlipData.DepositAlwcBlnce = SCMSlipDataFactory.GetConsTaxLayMethod(SalesSlipData);

            // 128.�݌ɏ��i���v���z(�Ŕ�)�c�Z�o
            SalesSlipData.StockGoodsTtlTaxExc = SCMSlipDataFactory.GetStockGoodsTtlTaxExc(SalesDetailDataList);
            // 129.�݌ɏ��i���v���z(�ō�)�c�Z�o
            SalesSlipData.PureGoodsTtlTaxExc = SCMSlipDataFactory.GetPureGoodsTtlTaxExc(SalesDetailDataList);

            SalesSlipData.AccRecConsTax = salesSubtotalTax;

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        // ------------- ADD 2013/07/24 qijh Redmine#39026 ---------- >>>>>
        /// <summary>
        /// ���㖾�׏W�v�̕␳����
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetailList">���㖾�׃��X�g</param>
        private void ReviseAddItUpSalesDetailData(SalesSlip salesSlip, List<SalesDetail> salesDetailList)
        {
            long salesPrtSubttlInc = 0;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc = 0;     // ���㕔�i���v�i�Ŕ��j
            // ����Œ[�������P�ʁA�[�������敪���擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h // ADD  2013/07/24 wangl2 FOR Redmine#39027
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // ���㕔�i���v�W�v
                if (salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales || salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods)
                {
                    salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc; // ���㕔�i���v�i�ō��j
                    salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc; // ���㕔�i���v�i�Ŕ��j
                }
            }

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {
                        salesSlip.SalesPrtSubttlInc = 0;  // ���㕔�i���v�i�ō��j
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesPrtSubttlInc = 0;  // ���㕔�i���v�i�ō��j
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
                        // ���ד]�ňȊO
                        if (salesSlip.ConsTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
                            // ���㕔�i���v�i�ō��j�F���㕔�i���v�i�Ŕ��j �~ �ŗ�
                            salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                        salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;   // ���㕔�i���v�i�ō��j
                        break;
                    }
            }
        }
        // ------------- ADD 2013/07/24 qijh Redmine#39026 ---------- <<<<<

        /// <summary>
        /// �`�[����ݒ�}�X�^���擾
        /// </summary>
        private static SlipPrtSetAgent SlipPrtSetDB
        {
            get { return SlipPrtSetServer.Singleton.Instance; }
        }

        /// <summary>
        /// ���׍ő�s�����擾
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>���׍ő�s��</returns>
        /// <remarks>
        /// PMSCM01012A��GetMaxRowCount���ڐA
        /// </remarks>
        private int GetMaxRowCount(SalesSlip salesSlip)
        {
            const string methodName = "GetMaxRowCount";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int maxRowCount = SCMSalesListEssence.DEFAULT_MAX_ROW_COUNT;
            {
                SlipPrtSet slipPrtSet = null;
                switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatus)
                {
                    case AcptAnOdrStatus.Estimate:  // ����
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.EstimateSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Order:     // ��
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.AcceptSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Sales:     // ����
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, salesSlip);
                        break;
                }
                if ((slipPrtSet != null) && (slipPrtSet.DetailRowCount > 0)) maxRowCount = slipPrtSet.DetailRowCount;
            }

            EasyLogger.Write(CLASS_NAME, methodName, "�`�[���� ���׍ő�s�� = " + maxRowCount);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return maxRowCount;
        }
        // --------------------- ADD 2013/07/03 qijh Redmine#37586 ------------------- <<<<<
        // --------------- ADD START 2013/07/24 wangl2 FOR Redmine#39028------>>>>
        /// <summary>
        /// ���Z�菈��
        /// </summary>
        /// <param name="numerator">���l(���q)</param>
        /// <param name="denominator">���l(����)</param>
        /// <param name="rate">��</param>
        public void GetRate(double numerator, double denominator, out double rate)
        {
            if (this._salesPriceCalculate == null)
                this._salesPriceCalculate = new SalesPriceCalculate();
            rate = this._salesPriceCalculate.CalculateMarginRate(numerator, denominator);
        }
        // --------------- ADD END 2013/07/24 wangl2 FOR Redmine#39028--------<<<<
        #endregion  �� �`�[��������

        #region �� �f�[�^�o�^
        /// <summary>
        /// �������SCM�񓚂�USERDB�ɓo�^
        /// </summary>
        /// <param name="paramSalesScmCustList">����ASCM�񓚏�񃊃X�g</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <param name="sameSessionIdFlg">����Z�b�V����ID�t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        //private ConstantManagement.MethodResult Write(ref CustomSerializeArrayList paramSalesScmCustList, out string errorMessage)
        private ConstantManagement.MethodResult Write(ref CustomSerializeArrayList paramSalesScmCustList, out bool sameSessionIdFlg, out string errorMessage)
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<<
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "Write";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // �o�^�����[�g�p�̃p�����[�^���\��
            // DEL 2013/07/03 qijh Redmine#37586 ------------------- >>>>>
            //CustomSerializeArrayList custTopArrayList = new CustomSerializeArrayList();
            //custTopArrayList.Add(paramSalesScmCustList);
            //custTopArrayList.Add(GetIOWriteCtrlOpt());

            //object paraList = custTopArrayList;
            // DEL 2013/07/03 qijh Redmine#37586 ------------------- <<<<<

            object paraList = paramSalesScmCustList; // ADD 2013/07/03 qijh Redmine#37586
            string itemInfo = string.Empty;
            sameSessionIdFlg = false;

            int status = this._iIOWriteControlDB.Write(ref paraList, out errorMessage, out itemInfo);
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    return ConstantManagement.MethodResult.ctFNC_ERROR;

            // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
            string acptAnOdrStatusName = string.Empty;

            if (errorMessage.Contains("����Z�b�V����ID�����݂��܂��B"))
            {
                sameSessionIdFlg = true;
                ArrayList pmTabletWorkList = new ArrayList(); // PMTAB�Z�b�V�����Ǘ��f�[�^���X�g

                DivisionCustomSerializeArrayListForTabWrite(paraList as CustomSerializeArrayList, out pmTabletWorkList);

                foreach (PmTabSessionMngWork pmTabSessionMngWork in pmTabletWorkList)
                {
                    EasyLogger.Write(CLASS_NAME, methodName, "����Z�b�V����ID�����݂��܂����B"
                       + "�@��ƃR�[�h�F" + pmTabSessionMngWork.EnterpriseCode
                       + "�@�Z�b�V�����h�c�F" + pmTabSessionMngWork.BusinessSessionId
                       + "�@�`�[�ԍ��F" + pmTabSessionMngWork.SalesSlipNum
                       + "�@�󒍃X�e�[�^�X�F" + pmTabSessionMngWork.AcptAnOdrStatus
                        );
                    if (pmTabSessionMngWork.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
                        acptAnOdrStatusName = "����";
                    else
                        acptAnOdrStatusName = "��";
                    MyOpeCtrl.Logger.WriteOperationLog(
                                            "",
                                            1,
                                            0,
                                            string.Format("{0}�`�[�A����`�[�ԍ�:{1}�A����Z�b�V�����̓`�[�����ɑ��݂���ׁA�o�^�������I�����܂����B", acptAnOdrStatusName, pmTabSessionMngWork.SalesSlipNum));
                }

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@ConstantManagement.MethodResult.ctFNC_NORMAL");
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_ERROR " + errorMessage);
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            paramSalesScmCustList = paraList as CustomSerializeArrayList;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            ArrayList salesDataList = new ArrayList(); // ����f�[�^(�`�[���X�g���)
            // ADD 2013/08/09 Redmine#39649 ----------------------------------------->>>>>
            //string acptAnOdrStatusName = string.Empty; // DEL 2017/03/30 ���O Redmine#49164
            acptAnOdrStatusName = string.Empty;   // ADD 2017/03/30 ���O Redmine#49164
            // ADD 2013/08/09 Redmine#39649 -----------------------------------------<<<<<
            DivisionCustomSerializeArrayListForWritingProc(paramSalesScmCustList, out salesDataList);
            foreach (SalesSlipWork salesData in salesDataList)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "�`�[��o�^���܂���" 
                   + "�@��ƃR�[�h�F" + salesData.EnterpriseCode
                   + "�@���_�R�[�h�F" + salesData.SectionCode
                   + "�@�`�[�ԍ��F" + salesData.SalesSlipNum
                   + "�@�󒍃X�e�[�^�X�F" + salesData.AcptAnOdrStatus
                    );
                // ADD 2013/08/08 Redmine#39649 ----------------------------------------->>>>>
                // UPD 2013/08/09 Redmine#39649 ----------------------------------------->>>>>
                //MyOpeCtrl.Logger.WriteOperationLog(
                //                        "",
                //                        1,
                //                        0,
                //                        string.Format("����`�[�A����`�[�ԍ�:{0}�œo�^", salesData.SalesSlipNum));
                if (salesData.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
                    acptAnOdrStatusName = "����";
                else
                    acptAnOdrStatusName = "��";
                MyOpeCtrl.Logger.WriteOperationLog(
                                        "",
                                        1,
                                        0,
                                        string.Format("{0}�`�[�A����`�[�ԍ�:{1}�œo�^", acptAnOdrStatusName, salesData.SalesSlipNum));
                // UPD 2013/08/09 Redmine#39649 -----------------------------------------<<<<<
                // ADD 2013/08/08 Redmine#39649 -----------------------------------------<<<<<
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.MethodResult.ctFNC_NORMAL");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out ArrayList salesDataList)
        {
            salesDataList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        //---------------------------------------
                        // ������
                        //---------------------------------------
                        if (tempObj is SalesSlipWork)
                        {
                            salesDataList.Add(tempObj);
                        }
                    }
                }
            }
        }
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTAB�Z�b�V�����Ǘ��f�[�^��񃊃X�g���擾����B
        /// </summary>
        /// <param name="paraList">�`�[���X�g</param>
        /// <param name="pmTabSessionMngList">PMTAB�Z�b�V�����Ǘ��f�[�^���X�g</param>
        /// <returns>�Ȃ�</returns>
        private static void DivisionCustomSerializeArrayListForTabWrite(CustomSerializeArrayList paraList, out ArrayList pmTabSessionMngList)
        {
            pmTabSessionMngList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        if (tempObj is ArrayList)
                        {
                            //---------------------------------------
                            // PMTAB�Z�b�V�����Ǘ��f�[�^���
                            //---------------------------------------
                            foreach (object subTempObj in tempObj as ArrayList)
                            {
                                if (subTempObj is PmTabSessionMngWork)
                                {
                                    pmTabSessionMngList.Add(subTempObj);
                                }
                            }
                        }
                    }
                    if (pmTabSessionMngList.Count > 0)
                    {
                        break;
                    }
                }
            }
        }
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<
        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        #endregion  �� �f�[�^�o�^

        #region �� ���M����
        /// <summary>
        /// �`�[�ԍ����X�g���擾
        /// </summary>
        /// <param name="paraList">�`�[���X�g</param>
        /// <returns>�`�[�ԍ����X�g</returns>
        private List<string> GetSalesSlipNumList(CustomSerializeArrayList paraList)
        {
            ArrayList salesDataList; // ����f�[�^���X�g
            ArrayList acptDataList;  // �󒍃f�[�^���X�g
            ArrayList stockSlipInfoList; // �d���f�[�^���X�g
            ArrayList uoeOrderDataList; // UOE�����f�[�^���X�g

            DivisionCustomSerializeArrayListForWriting(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            List<string> retList = new List<string>();
            if (null != salesDataList && salesDataList.Count > 0)
            {
                for (int i = 0; i < salesDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)salesDataList[i];
                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            retList.Add(salesSlipWork.SalesSlipNum);
                        }
                    }
                }
            }
            if (null != acptDataList && acptDataList.Count > 0)
            {
                for (int i = 0; i < acptDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)acptDataList[i];
                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            retList.Add(salesSlipWork.SalesSlipNum);
                        }
                    }
                }
            }
            return retList;
        }

        /// <summary>
        /// �`�[�ԍ����X�g���擾
        /// </summary>
        /// <param name="paraList">�`�[���X�g</param>
        /// <returns>�`�[�ԍ����X�g</returns>
        private string GetSalesSlipNumStrs(CustomSerializeArrayList paraList)
        {
            List<string> slipNumList = GetSalesSlipNumList(paraList);

            string retString = string.Empty;
            foreach (string slipNumStr in slipNumList)
            {
                if (!string.IsNullOrEmpty(retString))
                    retString += ",";
                retString += slipNumStr;
            }
            return retString;
        }

        /// <summary>
        /// �X�V���SCM�󒍖��׃f�[�^�i�񓚁j���擾
        /// </summary>
        /// <param name="paramSalesScmCustList">�X�V�㔄��SCM�񓚃��X�g</param>
        /// <returns>SCM�󒍖��׃f�[�^�i�񓚁j�f�[�^</returns>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsFromApRet(ArrayList paramSalesScmCustList)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "GetSCMAcOdrDtlAsFromApRet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            if (null == paramSalesScmCustList || paramSalesScmCustList.Count == 0)
                return null;

            foreach (object obj in paramSalesScmCustList)
            {
                if (obj is ArrayList)
                {
                    SCMAcOdrDtlAsWork tempSCMAcOdrDtlAs = GetSCMAcOdrDtlAsFromApRet(obj as ArrayList);
                    if (null != tempSCMAcOdrDtlAs) return tempSCMAcOdrDtlAs;
                }
                else if (obj is SCMAcOdrDtlAsWork)
                {
                    return obj as SCMAcOdrDtlAsWork;
                }
                else
                {
                    continue;
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// ���M���s��
        /// </summary>
        /// <param name="paraList">�X�V��`�[���X�g</param>
        //private void SendScmData(SCMAcOdrDtlAsWork updSCMAcOdrDtlAs) // DEL 2013/07/03 qijh Redmine#37586
        private void SendScmData(CustomSerializeArrayList paraList) // ADD 2013/07/03 qijh Redmine#37586
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SendScmData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            SCMAcOdrDtlAsWork updSCMAcOdrDtlAs = GetSCMAcOdrDtlAsFromApRet(paraList); // ADD 2013/07/03 qijh Redmine#37586
            if (null == updSCMAcOdrDtlAs)
                return;

            string strSalesSlipNumbers = GetSalesSlipNumStrs(paraList); // ADD 2013/07/03 qijh Redmine#37586

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "���M�����J�n"
                + "�@�⍇���ԍ��F" + updSCMAcOdrDtlAs.InquiryNumber
                + "�@�⍇���E������ʁF" + updSCMAcOdrDtlAs.InqOrdDivCd
                //+ "�@�`�[�ԍ��F" + updSCMAcOdrDtlAs.SalesSlipNum // DEL 2013/07/03 qijh Redmine#37586
                + "�@�`�[�ԍ��F" + strSalesSlipNumbers // ADD 2013/07/03 qijh Redmine#37586
                );
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            // UPD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
            #region ���\�[�X
            //Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + updSCMAcOdrDtlAs.SalesSlipNum); // DEL 2013/07/03 qijh Redmine#37586
            //Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + strSalesSlipNumbers); // ADD 2013/07/03 qijh Redmine#37586
            #endregion
            Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + strSalesSlipNumbers + " " + CMD_LINE_FOR_PMSCM01100_TABLET); 
            // UPD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<

            p.WaitForExit();
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        #endregion  �� ���M����

        #region �� �`�[�������
        // --------------------- ADD 2013/06/29 qijh Redmine#37474 ------------- >>>>>
        /// <summary>
        /// �`�[����}�C������
        /// </summary>
        /// <param name="salesScmCustArrayList">DB�ɓo�^��̓`�[���X�g</param>
        /// <param name="customer">���Ӑ���</param>
        private void PrintSlipMain(CustomSerializeArrayList salesScmCustArrayList, CustomerInfo customer)
        {
            const string methodName = "PrintSlipMain";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            ArrayList salesDataList; // ����f�[�^���X�g
            ArrayList acptDataList;  // �󒍃f�[�^���X�g
            ArrayList stockSlipInfoList; // �d���f�[�^���X�g
            ArrayList uoeOrderDataList; // UOE�����f�[�^���X�g

            // CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂�
            DivisionCustomSerializeArrayListForWriting(salesScmCustArrayList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            // ����p�̃L�[�����擾
            GetPrintKeyInfo(salesDataList, acptDataList, customer);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + "����������@�J�n");
            if (this._printSlipFlag == true)
            {
                // �`�[�������
                Thread printSlipThread = new Thread(PrintSlipThread);
                printSlipThread.Start();
            }
            else
            {
                this._printSlipFlag = true;
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + "����������@�I��");

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂�
        /// </summary>
        /// <param name="paraList">�f�[�^�������X�g</param>
        /// <param name="salesDataList">����f�[�^���X�g</param>
        /// <param name="acptDataList">�󒍃f�[�^���X�g</param>
        /// <param name="stockSlipInfoList">�d���f�[�^���X�g</param>
        /// <param name="uoeOrderDataList">UOE�����f�[�^���X�g</param>
        private void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            const string methodName = "DivisionCustomSerializeArrayListForWriting";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// ����p�̃L�[�����擾
        /// </summary>
        /// <param name="salesDataList">����`�[���X�g</param>
        /// <param name="acptDataList">�󒍓`�[���X�g</param>
        /// <param name="customer">���Ӑ���</param>
        private void GetPrintKeyInfo(ArrayList salesDataList, ArrayList acptDataList, CustomerInfo customer)
        {
            const string methodName = "GetPrintKeyInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            this._qrMakeCndtn = new SalesQRSendCtrlCndtn();
            this._qrMakeCndtn.EnterpriseCode = this._enterpriseCode;

            EasyLogger.Write(CLASS_NAME, methodName, "������p����L�[�擾�@�J�n");
            #region ����f�[�^�擾
            //------------------------------------------------------
            // ����f�[�^�擾
            //------------------------------------------------------
            this._printSalesKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (null != salesDataList && salesDataList.Count > 0)
            {
                for (int i = 0; i < salesDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)salesDataList[i];

                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(salesSlipWork.AcptAnOdrStatus, ctDefaultSalesSlipNum, 0);

                            bool printKeyAddFlag = false;
                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                    switch (customer.EstimatePrtDiv)
                                    {
                                        // 0:�W�� �� ���ϑS�̐ݒ�
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.EstimateDefSet.EstimatePrtDiv == 0);
                                            break;
                                        // 1:���g�p �� 0:���Ȃ�
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:�g�p �� 1:����
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                    this._qrMakeCndtn.SalesSlipKeyList.Add(new SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey(salesSlipWork.AcptAnOdrStatus, salesSlipWork.SalesSlipNum));

                                    switch (customer.SalesSlipPrtDiv)
                                    {
                                        // 0:�W�� �� ����S�̐ݒ�
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.SalesTtlSt.SalesSlipPrtDiv == 0);
                                            break;
                                        // 1:���g�p �� 0:���Ȃ�
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:�g�p �� 1:����
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag)
                                    {
                                        //�������
                                        slipPrintInfoValue.NomalSalesSlipPrintFlag = 0;
                                    }
                                    else
                                    {
                                        //������Ȃ�
                                        slipPrintInfoValue.NomalSalesSlipPrintFlag = 1;
                                    }
                                    this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    switch (customer.ShipmSlipPrtDiv)
                                    {
                                        // 0:�W�� �� ����S�̐ݒ�
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.SalesTtlSt.ShipmSlipPrtDiv == 0);
                                            break;
                                        // 1:���g�p �� 0:���Ȃ�
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:�g�p �� 1:����
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    switch (customer.AcpOdrrSlipPrtDiv)
                                    {
                                        // 0:�W�� �� �󒍑S�̐ݒ�
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv == 1);
                                            break;
                                        // 1:���g�p �� 0:���Ȃ�
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:�g�p �� 1:����
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, "������p����L�[�擾�@�I��");

            EasyLogger.Write(CLASS_NAME, methodName, "������p�󒍃L�[�擾�@�J�n");
            #region �󒍃f�[�^�擾
            //------------------------------------------------------
            // �󒍃f�[�^�擾
            //------------------------------------------------------
            this._printAcptKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (acptDataList.Count != 0)
            {
                for (int i = 0; i < acptDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)acptDataList[i];

                    ArrayList SalesDetailWorkList = list[1] as ArrayList;
                    SalesDetailWork salesDetailWork = null;
                    foreach (SalesDetailWork detailWork in SalesDetailWorkList)
                    {
                        salesDetailWork = detailWork;
                        if (detailWork.WayToOrder != 2)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork acptSlipWork = (SalesSlipWork)obj;
                            SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(acptSlipWork.AcptAnOdrStatus, ctDefaultSalesSlipNum, 0);

                            bool printKeyAddFlag = false;

                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)acptSlipWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    switch (customer.AcpOdrrSlipPrtDiv)
                                    {
                                        // 0:�W�� �� �󒍑S�̐ݒ�
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv == 1);
                                            break;
                                        // 1:���g�p �� 0:���Ȃ�
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:�g�p �� 1:����
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (salesDetailWork.WayToOrder != 2)
                                    {
                                        if (printKeyAddFlag) this._printAcptKeyInfo.Add(acptSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, "������p�󒍃L�[�擾�@�I��");
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        /// <summary>
        /// �`�[����X���b�h
        /// </summary>
        public void PrintSlipThread()
        {
            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // const string methodName = "PrintSlipThread";
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // �������
            this._printThreadOverFlag = false;
            this.PrintSlip(true);
            this._printThreadOverFlag = true;

            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �`�[�������
        /// </summary>
        /// <param name="printWithoutDialog">����_�C�A���[�O�t���O</param>
        public void PrintSlip(bool printWithoutDialog)
        {
            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // const string methodName = "PrintSlip";
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region ����������
            DCCMN02000UA printDisp = new DCCMN02000UA(); // �`�[������ݒ��ʃC���X�^���X����
            SalesSlipPrintCndtn.SalesSlipKey key = new SalesSlipPrintCndtn.SalesSlipKey(); // �`�[����pKey�C���X�^���X����
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>(); // �`�[����pKeyList�C���X�^���X����
            bool reissueDiv = false;
            int nomalSalesSlipPrintFlag = 0;
            #endregion

            #region ������`�[Key���Z�b�g
            foreach (string salesSlipNum in this._printSalesKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = this._printSalesKeyInfo[salesSlipNum];
                if (slipPrintInfoValue.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                {
                    key = new SalesSlipPrintCndtn.SalesSlipKey();
                    key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                    key.SalesSlipNum = salesSlipNum;
                    keyList.Add(key);
                    nomalSalesSlipPrintFlag = slipPrintInfoValue.NomalSalesSlipPrintFlag;
                }
                if (slipPrintInfoValue.SalesSlipNum != ctDefaultSalesSlipNum) reissueDiv = true;
            }
            this._printSalesKeyInfo.Clear();
            #endregion

            #region ���󒍓`�[Key���Z�b�g
            foreach (string salesSlipNum in this._printAcptKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = this._printAcptKeyInfo[salesSlipNum];
                if (slipPrintInfoValue.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                {
                    key = new SalesSlipPrintCndtn.SalesSlipKey();
                    key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                    key.SalesSlipNum = salesSlipNum;
                    keyList.Add(key);
                }
                if (slipPrintInfoValue.SalesSlipNum != ctDefaultSalesSlipNum) reissueDiv = true;
            }
            this._printAcptKeyInfo.Clear();
            #endregion

            #region ��������p�����[�^�Z�b�g
            SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
            salesSlipPrintCndtn.EnterpriseCode = this._enterpriseCode;
            salesSlipPrintCndtn.SalesSlipKeyList = keyList;
            salesSlipPrintCndtn.ReissueDiv = reissueDiv;
            salesSlipPrintCndtn.MakeQRDiv = false;

            salesSlipPrintCndtn.NomalSalesSlipPrintFlag = nomalSalesSlipPrintFlag;
            salesSlipPrintCndtn.ScmFlg = this._isConnScm;
            // ADD 2013/09/19 Redmine#40342�Ή� --------------------------------------------------->>>>>
            // �^�u���b�g�N���敪�ݒ�
            printDisp.IsTablet = true;
            // ADD 2013/09/19 Redmine#40342�Ή� ---------------------------------------------------<<<<<
            #endregion

            #region ���������
            if (salesSlipPrintCndtn.SalesSlipKeyList.Count != 0) printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);
            #endregion

            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        // --------------------- ADD 2013/06/29 qijh Redmine#37474 ------------- <<<<<
        #endregion �� �`�[�������  

        // ADD 2013/08/14 �g�� Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region �`�[�쐬���@�ɂ��\�[�g����
                /// <summary>
        /// �\�[�g�ςݔ��㖾�׃f�[�^���X�g�𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>�\�[�g�ςݔ��㖾�׃f�[�^���X�g</returns>
        private IList<SalesDetail> CreateSortedSalesDetailList(
            SalesSlip salesSlip,
            IList<SalesDetail> sourceSalesDetailList
        )
        {
            if (SalesTtlSt == null) return sourceSalesDetailList;

            switch (SalesTtlSt.SlipCreateProcess)
            {
                case 0: // ���͏�(�s�ԍ���)
                    return sourceSalesDetailList;

                case 1: // �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)
                    return OrderBySalesOrderDivCd(sourceSalesDetailList);

                case 2: // �q�ɏ�(�q�ɁE�s�ԍ���)
                case 3: // �o�͐��(�q�ɁE�s�ԍ���)
                    return OrderByWarehouseCode(sourceSalesDetailList);
            }

            return sourceSalesDetailList;
        }

        #region <�݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)>

        /// <summary>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�Ń\�[�g���܂��B
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�Ń\�[�g�������㖾�׃f�[�^�̃��X�g
        /// </returns>
        private IList<SalesDetail> OrderBySalesOrderDivCd(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderBySalesOrderDivCd(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderBySalesOrderDivCdList = ConvertSalesDetailList(sortedList);
            return orderBySalesOrderDivCdList.Count > 0 ? orderBySalesOrderDivCdList : sourceSalesDetailList;
        }

        /// <summary>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <returns></returns>
        private string GetKeyOfOrderBySalesOrderDivCd(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            return Math.Abs(salesDetail.SalesOrderDivCd - 1).ToString() + salesRowNo.ToString("0000");
        }

        #endregion // </�݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)>

        #region <�q�ɏ�(�q�ɁE�s�ԍ���)�^�o�͐��(�q�ɁE�s�ԍ���)>

        /// <summary>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�Ń\�[�g���܂��B
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�Ń\�[�g�������㖾�׃f�[�^�̃��X�g
        /// </returns>
        private IList<SalesDetail> OrderByWarehouseCode(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderByWarehouseCode(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderByWarehouseCodeList = ConvertSalesDetailList(sortedList);
            return orderByWarehouseCodeList.Count > 0 ? orderByWarehouseCodeList : sourceSalesDetailList;
        }

        /// <summary>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <returns></returns>
        private string GetKeyOfOrderByWarehouseCode(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            return ConvertNumber(salesDetail.WarehouseCode).ToString("000000") + salesRowNo.ToString("0000");
        }
        /// <summary>
        /// ���l�ɕϊ����܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <returns>���l�ɕϊ��ł��Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</returns>
        private int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }
        #endregion // </�q�ɏ�(�q�ɁE�s�ԍ���)�^�o�͐��(�q�ɁE�s�ԍ���)>

        /// <summary>
        /// ���㖾�׃f�[�^���X�g�ɕϊ����܂��B
        /// </summary>
        /// <param name="sortedList">����\�[�g�L�[�Ń\�[�g���ꂽ���㖾�׃f�[�^���X�g</param>
        /// <returns>���㖾�׃f�[�^���X�g</returns>
        private IList<SalesDetail> ConvertSalesDetailList(SortedList<string, SalesDetail> sortedList)
        {
            IList<SalesDetail> sortedSalesDetailList = new List<SalesDetail>();
            {
                foreach (KeyValuePair<string, SalesDetail> sortedSalesDetail in sortedList)
                {
                    sortedSalesDetailList.Add(sortedSalesDetail.Value);
                }
            }
            return sortedSalesDetailList;
        }

        #endregion
        // ADD 2013/08/14 �g�� Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/16 �g�� Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region WebSync�ʒm
        /// <summary>
        /// �w�舽���͊֘A��Tablet�[���ւ̕ԓ����M����
        /// </summary>
        /// <param name="destEnterpriseCode">��ƃR�[�h</param>
        /// <param name="destSectionCode">���_�R�[�h</param>
        /// <param name="inquiryNumber">�₢���킹�ԍ�</param>
        private void NotifyTabletByPublish(int status, string message, string sessionId,string sectionCode)
        {
            const string methodName = "NotifyTabletByPublish";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            ClientArgs clientArgs = new ClientArgs();
            // Push�T�[�o�[URL�̐ݒ�
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

            SFCMN01501CA _tabletPushClient = new SFCMN01501CA(clientArgs);    // Push�N���C�A���g�I�u�W�F�N�g

            ConnectArgs connectArgs = new ConnectArgs();
            connectArgs.StayConnected = true; // �ڑ����ؒf�ꍇ�A�����I�ɍĐڑ�����
            connectArgs.ReconnectInterval = 5000; // 5�b�@�ڑ����s�ꍇ�A�Đڑ��Ԋu���w�肷��
            connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                delegate(IScmPushClient client, ConnectFailureEventArgs args)
                {
                    // �V���`�F�b�J�[���N�����鎞�APush�T�[�o�[��ڑ��ł��Ȃ���΁A���̃��\�b�h���Ăт���
                    // �ڑ�������APush�T�[�o�[�ƒʐM�G���[�ꍇ�AOnStreamFailure�C�x���g�������Ăт���

                    // �ڑ������s����΁APush�T�[�o�[�֍Đڑ�
                    args.Reconnect = true;
                }
            );
            _tabletPushClient.Connect(connectArgs);

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            // ADD 2013/08/26 Redmine#40121 -------------------------------------->>>>>
            payload.NoticeMode = (int)ScmPushDataConstMode.PROCESSFINISHED;
            payload.SessionId = sessionId;
            // ADD 2013/08/26 Redmine#40121 --------------------------------------<<<<<

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // �w���Tablet�[���ւ̕ԓ����M����
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);

            EasyLogger.Write(CLASS_NAME, methodName,
                "�ʒm���e Status�F" + payload.Status.ToString()
                + "  Message�F" + payload.Message
                // ADD 2013/08/26 Redmine#40121 -------------------------------------->>>>>
                + "  NoticeMode�F" + payload.NoticeMode
                // ADD 2013/08/26 Redmine#40121 --------------------------------------<<<<<
                + "  Channel�F" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        #region DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜
        // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 --------------------------------->>>>>
        //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
        ///// <summary>
        ///// �w�舽���͊֘A��Tablet�[���ւ̕ԓ����M�����i�ʒm���[�h�j
        ///// </summary>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="sessionId">�Z�b�V����ID</param>
        //private void NotifyTabletByPublish(object o)
        //{
        //    const string methodName = "NotifyTabletByPublish(NoticeMode)";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

        //    ClientArgs clientArgs = new ClientArgs();
        //    // Push�T�[�o�[URL�̐ݒ�
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
        //    string webSyncUrl = wkStr1 + wkStr2;
        //    clientArgs.Url = webSyncUrl;

        //    SFCMN01501CA _tabletPushClient = new SFCMN01501CA(clientArgs);    // Push�N���C�A���g�I�u�W�F�N�g

        //    ConnectArgs connectArgs = new ConnectArgs();
        //    connectArgs.StayConnected = true; // �ڑ����ؒf�ꍇ�A�����I�ɍĐڑ�����
        //    connectArgs.ReconnectInterval = 5000; // 5�b�@�ڑ����s�ꍇ�A�Đڑ��Ԋu���w�肷��
        //    connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
        //        delegate(IScmPushClient client, ConnectFailureEventArgs args)
        //        {
        //            // �V���`�F�b�J�[���N�����鎞�APush�T�[�o�[��ڑ��ł��Ȃ���΁A���̃��\�b�h���Ăт���
        //            // �ڑ�������APush�T�[�o�[�ƒʐM�G���[�ꍇ�AOnStreamFailure�C�x���g�������Ăт���

        //            // �ڑ������s����΁APush�T�[�o�[�֍Đڑ�
        //            args.Reconnect = true;
        //        }
        //    );
        //    _tabletPushClient.Connect(connectArgs);

        //    TabletPullData payload = new TabletPullData();
        //    payload.SessionId = this._sessionId;
        //    payload.NoticeMode = (int)ScmPushDataConstMode.WAITETIMERESET;

        //    PublishArgs publishArgs = new PublishArgs();
        //    publishArgs.Payload = payload;
        //    // �w���Tablet�[���ւ̕ԓ����M����
        //    publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, this._sectionCode.Trim(), this._sessionId);
        //    _tabletPushClient.Publish(publishArgs);

        //    EasyLogger.Write(CLASS_NAME, methodName,
        //        "�ʒm���e Status�F" + payload.Status.ToString()
        //        + "  Message�F" + payload.Message
        //        + "  NoticeMode�F" + payload.NoticeMode
        //        + "  Channel�F" + publishArgs.Channel
        //        );
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //}
        //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
        // DEL 2013/08/30 30�b�^�C�}�[�͏풓�����ōs���̂ō폜 ---------------------------------<<<<<
        #endregion

        #endregion
        // ADD 2013/08/16 �g�� Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    }
    // ADD 2013/08/19 �g��  Redmine#39992 --------->>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// ����`�[���́A�������ϔ��s����̈ڐA�N���X
    /// </summary>
    public class OtherAppComponent
    {
        private const string CLASS_NAME = "OtherAppComponent";
        #region <��ƃR�[�h>

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode;
        /// <summary>��ƃR�[�h�擾���܂��B</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // </��ƃR�[�h>

        #region <���_�R�[�h>

        /// <summary>���_�R�[�h</summary>
        private readonly string _sectionCode;
        /// <summary>���_�R�[�h���擾���܂��B</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </���_�R�[�h>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public OtherAppComponent(
            string enterpriseCode,
            string sectionCode
        )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
        }

        #endregion // </Constructor>

        #region <����f�[�^�̎Z�o�֘A>

        /// <summary>
        /// �������ϗp�����l�擾�A�N�Z�X�N���X�̃��v���J
        /// </summary>
        private class EstimateInputInitDataAcs
        {
            private const string CLASS_NAME = "EstimateInputInitDataAcs";
            #region <��ƃR�[�h>

            /// <summary>��ƃR�[�h</summary>
            private readonly string _enterpriseCode;
            /// <summary>��ƃR�[�h���擾���܂��B</summary>
            private string EnterpriseCode { get { return _enterpriseCode; } }

            #endregion // </��ƃR�[�h>

            #region <���_�R�[�h>

            /// <summary>���_�R�[�h</summary>
            private readonly string _sectionCode;
            /// <summary>���_�R�[�h���擾���܂��B</summary>
            public string SectionCode { get { return _sectionCode; } }

            #endregion // </���_�R�[�h>

            #region <Constructor>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <param name="sectionCode">���_�R�[�h</param>
            public EstimateInputInitDataAcs(
                string enterpriseCode,
                string sectionCode
            )
            {
                _enterpriseCode = enterpriseCode;
                _sectionCode = sectionCode;
            }

            #endregion // </Constructor>

            /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
            public const int ctFracProcMoneyDiv_Tax = 1;
            /// <summary>�[�������Ώۋ��z�敪�i�P���j</summary>
            public const int ctFracProcMoneyDiv_UnitPrice = 2;

            /// <summary>������z�����敪�ݒ胊�X�g</summary>
            private List<SalesProcMoney> _salesProcMoneyList;
            /// <summary>������z�����敪�ݒ胊�X�g�̃��v���J���擾���܂��B</summary>
            private List<SalesProcMoney> SalesProcMoneyList
            {
                get
                {
                    if (_salesProcMoneyList == null)
                    {
                        ArrayList recordList = new ArrayList();
                        int status = SalesProcMoneyFind(EnterpriseCode, out recordList);
                        if (status == (int)ResultUtil.ResultCode.Normal)
                        {
                            _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])recordList.ToArray(typeof(SalesProcMoney)));
                        }
                    }
                    return _salesProcMoneyList;
                }
            }

            /// <summary>
            /// �������܂��B
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <returns>�Y�����锄����z�����敪</returns>
            public int SalesProcMoneyFind(string enterpriseCode, out ArrayList foundRecordList)
            {
                const string methodName = "SalesProcMoneyFind";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

                SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();

                foundRecordList = null;
                int status = salesProcMoneyAcs.Search(out foundRecordList, enterpriseCode);

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ������z�����敪�ݒ�}�X�^ ��������status�F" + status.ToString());
                return status;
            }

            #region ��������z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A

            /// <summary>
            /// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
            /// </summary>
            /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
            /// <param name="fractionProcCode">�[�������R�[�h</param>
            /// <param name="price">�Ώۋ��z</param>
            /// <param name="fractionProcUnit">�[�������P��</param>
            /// <param name="fractionProcCd">�[�������敪</param>
            public void GetSalesFractionProcInfo(
                int fracProcMoneyDiv,
                int fractionProcCode,
                double price,
                out double fractionProcUnit,
                out int fractionProcCd
            )
            {
                const string methodName = "GetSalesFractionProcInfo";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
                //�f�t�H���g
                switch (fracProcMoneyDiv)
                {
                    case ctFracProcMoneyDiv_UnitPrice:	// �P��
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;			// �P���ȊO��1�~�P��
                        break;
                }
                fractionProcCd = 1;     // �؎̂�

                if (SalesProcMoneyList == null || SalesProcMoneyList.Count == 0) return;

                List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                                            delegate(SalesProcMoney salesProcMoney)
                                            {
                                                if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                    (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                    (salesProcMoney.UpperLimitPrice >= price))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
                {
                    fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                    fractionProcCd = salesProcMoneyList[0].FractionProcCd;
                }

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            }

            #endregion
        }

        /// <summary>�������ϗp�����l�擾�A�N�Z�X�N���X</summary>
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        /// <summary>�������ϗp�����l�擾�A�N�Z�X�N���X�̃��v���J���擾���܂��B</summary>
        private EstimateInputInitDataAcs EstimateInputInitDataAcsReplica
        {
            get
            {
                if (_estimateInputInitDataAcs == null)
                {
                    _estimateInputInitDataAcs = new EstimateInputInitDataAcs(EnterpriseCode, SectionCode);
                }
                return _estimateInputInitDataAcs;
            }
        }

        /// <summary>
        /// ������z�̍��v���v�Z���܂��B
        /// </summary>
        /// <param name="salesDetailList">���㖾�׃f�[�^���X�g</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="fractionProcCd">����Œ[�������R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// 
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��j</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ��j</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz</param>
        /// <param name="itdedSalesInTax">������őΏۊz</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ��j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="totalCost">�������z�v</param>
        /// 
        /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z(�Ŕ�)</param>
        /// <param name="pureGoodsTtlTaxExc">�������i���v���z(�Ŕ�)</param>
        /// <param name="balanceAdjust">����Œ����z</param>
        /// <param name="taxAdjust">�c�������z</param>
        /// 
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ��j</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��j</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ��j</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ��j</param>
        /// 
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        public void CalculationSalesTotalPrice(
            List<SalesDetail> salesDetailList,
            double consTaxRate,
            int fractionProcCd,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            out long salesTotalTaxInc,
            out long salesTotalTaxExc,
            out long salesSubtotalTax,
            out long itdedSalesOutTax,
            out long itdedSalesInTax,
            out long salSubttlSubToTaxFre,
            out long salesOutTax,
            out long salAmntConsTaxInclu,
            out long salesDisTtlTaxExc,
            out long itdedSalesDisOutTax,
            out long itdedSalesDisInTax,
            out long itdedSalesDisTaxFre,
            out long salesDisOutTax,
            out long salesDisTtlTaxInclu,
            out long totalCost,

            out long stockGoodsTtlTaxExc,
            out long pureGoodsTtlTaxExc,
            out long balanceAdjust,
            out long taxAdjust,

            out long salesPrtSubttlInc,
            out long salesPrtSubttlExc,
            out long salesWorkSubttlInc,
            out long salesWorkSubttlExc,
            out long itdedPartsDisInTax,
            out long itdedPartsDisOutTax,
            out long itdedWorkDisInTax,
            out long itdedWorkDisOutTax,

            out long totalMoneyForGrossProfit
        )
        {
            const string methodName = "CalculationSalesTotalPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
                EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                fractionProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            salesTotalTaxInc = 0;       // ����`�[���v�i�ō��j
            salesTotalTaxExc = 0;       // ����`�[���v�i�Ŕ��j
            salesSubtotalTax = 0;       // ���㏬�v�i�Łj
            itdedSalesOutTax = 0;       // ����O�őΏۊz
            itdedSalesInTax = 0;        // ������őΏۊz
            salSubttlSubToTaxFre = 0;   // ���㏬�v��ېőΏۊz
            salesOutTax = 0;            // ������z����Ŋz�i�O�Łj
            salAmntConsTaxInclu = 0;    // ������z����Ŋz�i���Łj
            salesDisTtlTaxExc = 0;      // ����l�����z�v�i�Ŕ��j
            itdedSalesDisOutTax = 0;    // ����l���O�őΏۊz���v
            itdedSalesDisInTax = 0;     // ����l�����őΏۊz���v
            itdedSalesDisTaxFre = 0;    // ����l����ېőΏۊz���v
            salesDisOutTax = 0;         // ����l������Ŋz�i�O�Łj
            salesDisTtlTaxInclu = 0;    // ����l������Ŋz�i���Łj
            stockGoodsTtlTaxExc = 0;    // �݌ɏ��i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = 0;     // �������i���v���z�i�Ŕ��j
            totalCost = 0;              // �������z�v
            taxAdjust = 0;              // ����Œ����z
            balanceAdjust = 0;          // �c�������z
            salesPrtSubttlInc = 0;      // ���㕔�i���v�i�ō��j
            salesPrtSubttlExc = 0;      // ���㕔�i���v�i�Ŕ��j
            salesWorkSubttlInc = 0;     // �����Ə��v�i�ō��j
            salesWorkSubttlExc = 0;     // �����Ə��v�i�Ŕ��j
            itdedPartsDisInTax = 0;     // ���i�l���Ώۊz���v�i�ō��j
            itdedPartsDisOutTax = 0;    // ���i�l���Ώۊz���v�i�Ŕ��j
            itdedWorkDisInTax = 0;      // ��ƒl���Ώۊz���v�i�ō��j
            itdedWorkDisOutTax = 0;     // ��ƒl���Ώۊz���v�i�Ŕ��j
            totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            long itdedSalesInTax_TaxInc = 0;    // ������őΏۊz�i�ō��j
            long itdedSalesDisInTax_TaxInc = 0; // ����l�����őΏۊz���v�i�ō��j
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i���ŏ��i���j
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // �e���v�Z�p������z�v�i�O�ŏ��i���j
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // �e���v�Z�p������z�v�i��ېŏ��i���j
            long stockGoodsTtlTaxExc_TaxInc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            long stockGoodsTtlTaxExc_TaxExc = 0;                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long stockGoodsTtlTaxExc_TaxNone = 0;               // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            long pureGoodsTtlTaxExc_TaxNone = 0;                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j

            //-----------------------------------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            #region ���v�Z�ɕK�v�ȋ��z�̌v�Z

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // ����`�[�敪�i���ׁj�ɂ���ďW�v���@���ς�镪
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // ����A�ԕi
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����O�őΏۊz
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // ������z����Ŋz�i�O�Łj
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ������őΏۊz
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // ������őΏۊz�i�ō��j
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // ������z����Ŋz�i���Łj
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ���㏬�v��ېőΏۊz
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // ���㕔�i���v�i�ō��j
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // ���㕔�i���v�i�Ŕ��j
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // �l����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // �ŋ敪�F�O��
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // ����l���O�őΏۊz���v
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // ����l������Ŋz�i�O�Łj
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F����
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // ����l�����őΏۊz���v
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // ����l�����őΏۊz���v�i�ō��j
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // ����l������Ŋz�i���Łj
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // �ŋ敪�F��ې�
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // ����l����ېőΏۊz���v
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // ���i�l�����̏ꍇ
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // ���i�l���Ώۊz���v�i�ō��j
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // ���i�l���Ώۊz���v�i�Ŕ��j
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // ����
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // ���
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // �������z�v
                            totalCost += salesDetail.Cost;

                            // �e���v�Z�p������z�v�i���ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // �e���v�Z�p������z�v�i�O�ŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // �e���v�Z�p������z�v�i��ېŏ��i���j
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // ���v
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // �c�������z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // ����Œ����z
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }
            }

            // ����l�����z�v�i�Ŕ��j
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // �e���v�Z�p������z�v
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // �݌ɏ��i���v���z�i�Ŕ��j
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // �������i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ���]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;

                // ������z����Ŋz�i���Łj
                salAmntConsTaxInclu = 0;

                // ���㏬�v��ېőΏۊz
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // ����O�őΏۊz
                itdedSalesOutTax = 0;

                // ������őΏۊz
                itdedSalesInTax = 0;

                // ������őΏۊz�i�ō��j
                itdedSalesInTax_TaxInc = 0;

                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;

                // ����l������Ŋz�i���Łj
                salesDisTtlTaxInclu = 0;

                // ����l����ېőΏۊz���v
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // ����l���O�őΏۊz���v
                itdedSalesDisOutTax = 0;

                // ����l�����őΏۊz���v
                itdedSalesDisInTax = 0;

                // ����l�����őΏۊz���v�i�ō��j
                itdedSalesDisInTax_TaxInc = 0;

                // ����l�����z�v�i�Ŕ��j
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ���e����z�Z�o
            //-----------------------------------------------------------------------------
            // �e����z�Z�o
            //-----------------------------------------------------------------------------

            // ���ד]�ňȊO
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v + ����l����ېőΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l�����őΏۊz���v�i�ō��j + ����l���O�őΏۊz���v + ����l����ېőΏۊz���v + (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �B ���㏬�v�i�Łj�F�A - �@
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �E ����l������Ŋz�i�O�Łj�F�C - �D
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //-----------------------------------------------------------------------------
                // �F ���㕔�i���v�i�ō��j�F(���㕔�i���v�i�Ŕ��j+ ���i�l���Ώۊz���v�i�Ŕ��j) �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // �G ���i�l���Ώۊz���v�i�ō��j�F���i�l���Ώۊz���v�i�Ŕ��j�~ �ŗ�
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // ���ד]��
            else
            {
                //-----------------------------------------------------------------------------
                // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // �B ����`�[���v�i�ō��j�F�@ + �A
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }

        #endregion // </����f�[�^�̎Z�o�֘A>
    }
    // ADD 2013/08/19 �g��  Redmine#39992 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
}

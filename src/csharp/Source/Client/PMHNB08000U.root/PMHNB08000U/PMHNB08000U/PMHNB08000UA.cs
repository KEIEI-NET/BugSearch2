//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �W�����i�I�����
// �v���O�����T�v   : ���i�������ʃf�[�^�Z�b�g�����ʕ\�����s���A�I�����ꂽ�艿�𔽉f������B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/10/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/11/13  �C�����e : redmine#1266  �����t�H�[�J�X�ʒu�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/11/16  �C�����e : redmine#1320  �����\���̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : ����
// �C �� ��  2010/02/04    �C�����e : PM1003�E�l������ ESC�{�^���ŉ�ʂ��I������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 21024�@���X�� ��
// �C �� ��  2010/04/13  �C�����e : �J�^���O���i���ŐV���i�̏ꍇ�ɁA�ŐV���i�̒艿���̗p����(MANTIS[0015276])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 20056  ���n ���
// �C �� ��  2010/04/27  �C�����e : �J�[���[�J�[�ƕ��i���[�J�[�̔�r�����ŃJ�[���[�J�[�ϊ����s��(MANTIS[0015344])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 22018  ��� ���b
// �C �� ��  2010/07/27  �C�����e : ���q�������ŕi�ԓ��͎��Ƀ��[�J�[�ϊ������ŃG���[�������錏�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 21024�@���X�� ��
// �C �� ��  2010/11/01  �C�����e : �@�E�[�ɕ\������Ă���{�^����Tab�������A�t�H�[�J�X��������s����C��(MANTIS[0016549])
//                                 �AWindows�^�X�N�o�[�ɉ�ʂ��\�������s��̏C��(MANTIS[0016550])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 22018�@��� ���b
// �C �� ��  2011/01/19  �C�����e : �W�����i�I��UI�ɌÂ���۸ޕi�Ԃ��\������錏�̑Ή�
//                                 (PM7�Ɠ��l�̃`�F�b�N������ǉ�����B)(MANTIS[0016928])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 22018�@��� ���b
// �C �� ��  2011/02/17  �C�����e : �W�����i�[���Ń��[�U�[���i�}�X�^�ɖ����������͑ΏۊO�ɕύX�B(PM7����)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 22018�@��� ���b
// �C �� ��  2011/02/25  �C�����e : �J�[���[�J�[�ɍ��v���鏃�����[�J�[�̍s���P�������ꍇ�͗D�ǂŊm�肷��悤�ύX�B(PM7����)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �C �� ��  2011/06/08  �C�����e : ���R�������i�o�^�ɂ��A��x��BL�R�[�h�����ŕ����񓯈�̏����i���I�����ꂽ�Ƃ��̕s��C���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �C �� ��  2011/11/24  �C�����e : redmine#8034�A�O�ԃf�[�^�̕��i�����ŕW�����i�I���̕i�ԕ\���Ō��i�Ԃ��\�������̏C���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���N�n�� 						
// �C �� ��  2012/04/06  �C�����e : 2012/05/24�z�M���ARedmine#29297�@ 						
//                                  �W�����i�I����ʂ̏����i�Ԃ̕\���ɂ��Ă̏C��					
//----------------------------------------------------------------------------// 	
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���N�n�� 						
// �C �� ��  2012/04/06  �C�����e : 2012/05/24�z�M���ARedmine#29153 						
//                                  �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��					
//----------------------------------------------------------------------------// 					
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : gezh 						
// �C �� ��  2012/06/11  �C�����e : Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�					
//----------------------------------------------------------------------------// 
// �Ǘ��ԍ�              �쐬�S�� : ������ 						
// �C �� ��   2012/06/26 �C�����e : Redmine#30595 ����`�[���͕W�����i�I���K�C�h�̏C��				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �e�c ���V 						
// �C �� ��  2012/12/27  �C�����e : ���Еi�Ԉ󎚑Ή�				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  10806792-00 �쐬�S�� : �e�c ���V 						
// �C �� ��  2013/01/16  �C�����e : ���Еi�Ԉ󎚑Ή��d�l�ύX�Ή�				
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  11070100-00 �쐬�S�� : �{�{ ����
// �C �� ��  2014/06/16  �C�����e : LDNS #37904 �Ή���(2014/05/16)���}�[�W
//----------------------------------------------------------------------------// 						
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : 30757 ���X�� �M�p
// �C �� ��  2015/04/06  �C�����e : �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�
//----------------------------------------------------------------------------// 						
						

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

// --- ADD 2012/12/27 Y.Wakita ---------->>>>>
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
// --- ADD 2012/12/27 Y.Wakita ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �W�����i�I����ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �W�����i�I����ʃt�H�[���N���X�ł��B</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2009/10/19</br>
    /// <br>Update Note : ����� 2009/11/13</br>
    /// <br>            : redmine#1266  �����t�H�[�J�X�ʒu�̏C��</br>
    /// <br>Update Note : ����� 2009/11/16</br>
    /// <br>            : redmine#1320  �����\���̏C��</br>
    /// <br>Update Note : 2010/02/04 ����</br>
    /// <br>            : PM1003�E�l������ ESC�{�^���ŉ�ʂ��I������</br>
    /// <br></br>
    /// <br>Update Note : 2010/04/13�@21024 ���X�� ��</br>
    /// <br>            : �J�^���O���i���ŐV���i�̏ꍇ�ɁA�ŐV���i�̒艿���̗p����(MANTIS[0015276])</br>
    /// <br>Update Note : 2010/04/27 20056 ���n ���</br>
    /// <br>            : �J�[���[�J�[�ƕ��i���[�J�[�̔�r�����ŃJ�[���[�J�[�ϊ����s��(MANTIS[0015344])</br>
    /// <br>Update Note : 2010/07/27 22018 ��� ���b</br>
    /// <br>            : ���q�������ŕi�ԓ��͎��Ƀ��[�J�[�ϊ������ŃG���[�������錏�̏C��</br>
    /// <br>Update Note : 2011/01/19 22018 ��� ���b</br>
    /// <br>            : �W�����i�I��UI�ɌÂ���۸ޕi�Ԃ��\������錏�̑Ή�(PM7�Ɠ��l�̃`�F�b�N������ǉ�����B)(MANTIS[0016928])</br>
    /// <br>Update Note : 2011/02/17 22018 ��� ���b</br>
    /// <br>            : �W�����i�[���Ń��[�U�[���i�}�X�^�ɖ����������͑ΏۊO�ɕύX�B(PM7����)</br>
    /// <br>Update Note : 2011/02/25 22018 ��� ���b</br>
    /// <br>            : �J�[���[�J�[�ɍ��v���鏃�����[�J�[�̍s���P�������ꍇ�͗D�ǂŊm�肷��悤�ύX�B(PM7����)</br>
    /// <br>Update Note : 2011/06/08 22018 ��� ���b</br>
    /// <br>            : ���R�������i�o�^�ɂ��A��x��BL�R�[�h�����ŕ����񓯈�̏����i���I�����ꂽ�Ƃ��̕s��C���B</br>
    /// <br>Update Note : 2011/11/24 ���N�n��</br>
    /// <br>            : redmine#8034�A�O�ԃf�[�^�̕��i�����ŕW�����i�I���̕i�ԕ\���Ō��i�Ԃ��\�������̏C��</br>
    /// <br>Update Note : 2012/04/06 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2012/05/24�z�M��</br>
    /// <br>              Redmine#29297   �W�����i�I����ʂ̏����i�Ԃ̕\���ɂ��Ă̏C��</br>
    /// <br>Update Note : 2012/04/06 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2012/05/24�z�M��</br>
    /// <br>              Redmine#29153   �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��</br>
    /// <br>Update Note : 2012/06/11 gezh</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 </br>
    /// <br>              Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
    /// <br>Update Note : 2012/06/26 ������</br>
    /// <br>              Redmine#30595 ����`�[���͕W�����i�I���K�C�h�̏C��</br>
    /// <br>Update Note : 2015/04/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�    : 11070149-00</br>
    /// <br>              �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
    /// <br></br>
    /// </remarks>
    public partial class SelectionListPrice : Form
    {
        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// �W�����i�I�����UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �W�����i�I�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice()
        {
            InitializeComponent();

            //>>>2010/04/27
            this._changeMakerDic.Add(14, 4);
            this._changeMakerDic.Add(16, 6);
            this._changeMakerDic.Add(209, 9);
            this._changeMakerDic.Add(301, 1);
            //<<<2010/04/27
        }

        /// <summary>
        /// �W�����i�I�����UI�N���X�R���X�g���N�^(����`�[���͗p)
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="carInfo">�ԗ��������ʃf�[�^�N���X</param>
        /// <param name="partsInfoDataSet">���i�������ʃf�[�^�Z�b�g</param>
        /// <param name="priceSelectDiv">�\���敪</param>
        /// <remarks>
        /// <br>Note        : �W�����i�I�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice(int goodsMakerCode, string goodsNo, PMKEN01010E carInfo, PartsInfoDataSet partsInfoDataSet, int priceSelectDiv)
        {
            InitializeComponent();

            // �ϐ��̐ݒ�
            this._goodsMakerCd = goodsMakerCode;
            this._goodsNo = goodsNo;
            this._partsInfo = partsInfoDataSet;
            this._carInfo = carInfo;
            this._priceSelectDiv = priceSelectDiv;
            this._startForm = 1;

            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            this._changeMakerDic.Add( 14, 4 );
            this._changeMakerDic.Add( 16, 6 );
            this._changeMakerDic.Add( 209, 9 );
            this._changeMakerDic.Add( 301, 1 );
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            // ��ʓ��e������
            this.InitFormDate();

            // --- DEL m.suzuki 2011/02/25 ---------->>>>> // ��ʏ������́��Ɉړ�
            ////>>>2010/04/27
            //this._changeMakerDic.Add(14, 4);
            //this._changeMakerDic.Add(16, 6);
            //this._changeMakerDic.Add(209, 9);
            //this._changeMakerDic.Add(301, 1);
            ////<<<2010/04/27
            // --- UPD m.suzuki 2011/02/25 ----------<<<<<
        }

        /// <summary>
        /// �W�����i�I�����UI�N���X�R���X�g���N�^(�������ϗp)
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsMakerName">���[�J�[����</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsName">�i��</param>
        /// <param name="priceTaxExc">�W�����i(�Ŕ�)</param>
        /// <param name="partsInfoDataSet">���i�������ʃf�[�^�Z�b�g</param>
        /// <param name="priceSelectDiv">�\���敪</param>
        /// <remarks>
        /// <br>Note        : �W�����i�I�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice(int goodsMakerCode, string goodsMakerName, string goodsNo,
            string goodsName, double priceTaxExc, PartsInfoDataSet partsInfoDataSet, int priceSelectDiv)
        {
            InitializeComponent();

            // �ϐ��̐ݒ�
            this._partsInfo = partsInfoDataSet;
            this._carInfo = partsInfoDataSet.SearchCarInfo;
            this._priceSelectDiv = priceSelectDiv;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsMakerNm = goodsMakerName;
            this._goodsMakerCd = goodsMakerCode;
            this._priceTaxExc = priceTaxExc;
            this._startForm = 2;

            // ��ʓ��e������
            this.InitFormDate();

            //>>>2010/04/27
            this._changeMakerDic.Add(14, 4);
            this._changeMakerDic.Add(16, 6);
            this._changeMakerDic.Add(209, 9);
            this._changeMakerDic.Add(301, 1);
            //<<<2010/04/27
        }
        #endregion

        #region �� private�萔 ��
        // 1:�D��
        private const int PRICE_SELECT_DIV1 = 0;
        // 2:����
        private const int PRICE_SELECT_DIV2 = 1;
        // 3:������/3:������(1:N)
        private const int PRICE_SELECT_DIV3 = 2;
        // 4:������(1:1)
        private const int PRICE_SELECT_DIV4 = 3;
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>���_�R�[�h(�S��)</summary>
        private const string ctSectionCode = "00";
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        #endregion

        #region �� private�ϐ� ��
        int _goodsMakerCd = 0;
        string _goodsMakerNm = string.Empty;
        string _goodsNo = string.Empty;
        string _goodsName = string.Empty;
        double _priceTaxExc = 0;

        // ���i�������ʃf�[�^�Z�b�g
        PartsInfoDataSet _partsInfo;
        // �ԗ��������ʃf�[�^�N���X
        PMKEN01010E _carInfo;
        // �W�����i�I���敪
        int _priceSelectDiv = PRICE_SELECT_DIV1;
        int _startForm = 1;
        int _startMode = 2;
        int _getDataMode = 1;

        private PartsDataSet _priceParts = null;
        private PartsDataSet.PrmPartsInfoDataTable _prmPartsInfoTable = null;
        private PartsDataSet.ClgPartsInfoDataTable _clgPartsInfoTable = null;

        private List<UltraGridRow> selectedRows = new List<UltraGridRow>();

        bool _startPriceFlag = false;
        bool _parten9 = true;

        UltraGridRow _beforeSelectedRow;

        Dictionary<int, int> _changeMakerDic = new Dictionary<int, int>(); // 2010/04/27
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        private SalesTtlSt _salesTtlSt = null;  // ����S�̐ݒ�}�X�^

        int _goodsMakerCd2 = 0;                 // �W�����i�I���̃��[�J�[�R�[�h(���i)
        string _goodsMakerNm2 = string.Empty;   // �W�����i�I���̃��[�J�[����(���i)
        string _goodsNo2 = string.Empty;        // �W�����i�I���̕i��(���i)
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
        /// <summary>
        /// �^�C�g���ǉ�������
        /// </summary>
        string _addTitleCaption = string.Empty;

        /// <summary>
        /// �I�������i��
        /// </summary>
        string _srcGoodsNo = string.Empty;
        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
        #endregion

        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
        #region �� Public Property ��
        /// <summary>
        /// �^�C�g���ǉ�������̎擾�Ɛݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br>Programmer  : 30757 ���X�� �M�p</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public string AddTitleCaption
        {
            get
            {
                return this._addTitleCaption;
            }
            set
            {
                this._addTitleCaption = value;
            }
        }

        /// <summary>
        /// �I�������i���[�J�[�R�[�h�̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br>Programmer  : 30757 ���X�� �M�p</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public int SrcGoodsMakerCode
        {
            get
            {
                return this._goodsMakerCd2;
            }
        }

        /// <summary>
        /// �I�������i�Ԃ̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br>Programmer  : 30757 ���X�� �M�p</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public string SrcGoodsNo
        {
            get
            {
                return this._srcGoodsNo;
            }
        }
        #endregion //�� Public Property ��
        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<

        #region �� �R���g���[���C�x���g ��
        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g(��i)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_PrmPartsInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;

            this.ultraGrid_PrmPartsInfo.Enabled = false;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_PrmPartsInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // �s�t�B���^�[�ݒ�
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // �����s�I����
            editBand.Layout.Override.SelectTypeRow = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.PrmPartsInfoDataTable table = this._prmPartsInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // �O���b�h��\����\���ݒ菈��
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            columns[table.PriceTaxExcColumn.ColumnName].Hidden = false;

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "���[�J�[";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            columns[table.PriceTaxExcColumn.ColumnName].Header.Caption = "�W�����i";

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.PriceTaxExcColumn.ColumnName].CellActivation = Activation.NoEdit;

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 180;
            columns[table.GoodsNoColumn.ColumnName].Width = 130;
            columns[table.GoodsNameColumn.ColumnName].Width = 205;
            columns[table.PriceTaxExcColumn.ColumnName].Width = 120;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.PriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // �t�H�[�}�b�g�ݒ�
            //--------------------------------------
            columns[table.PriceTaxExcColumn.ColumnName].Format = "#,##0";
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g(���i)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // �s�t�B���^�[�ݒ�
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // �����s�I����
            editBand.Layout.Override.SelectTypeRow = SelectType.None;
            editBand.Layout.Override.SelectTypeCol = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.ClgPartsInfoDataTable table = this._clgPartsInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // �O���b�h��\����\���ݒ菈��
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }
            columns[table.NoColumn.ColumnName].Hidden = false;
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            columns[table.PriceTaxExcColumn.ColumnName].Hidden = false;

            // �s�ԍ���̂݃Z���\���F�ύX
            columns[table.NoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[table.NoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[table.NoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[table.NoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            columns[table.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[table.NoColumn.ColumnName].Header.Caption = "No";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "���[�J�[";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            columns[table.PriceTaxExcColumn.ColumnName].Header.Caption = "�W�����i";

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.PriceTaxExcColumn.ColumnName].CellActivation = Activation.NoEdit;

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[table.NoColumn.ColumnName].Width = 30;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 150;
            columns[table.GoodsNoColumn.ColumnName].Width = 130;
            columns[table.GoodsNameColumn.ColumnName].Width = 205;
            columns[table.PriceTaxExcColumn.ColumnName].Width = 120;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.PriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // �t�H�[�}�b�g�ݒ�
            //--------------------------------------
            columns[table.PriceTaxExcColumn.ColumnName].Format = "#,##0";

            //--------------------------------------
            // �N���b�N�����쐧��
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsMakerNmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.PriceTaxExcColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ---DEL ���N�n���@2014/05/16 ------------------------------------>>>>>
            //switch (e.PrevCtrl.Name)
            //{
            //    // �I��ԍ�
            //    case "tEdit_SelectNo":
            //        {
            //            // �I���Ƀt�H�[�J�X�������Ԃ�[Enter]�L�[����͂����ꍇ
            //            if (e.Key == Keys.Enter)
            //            {
            //                string selectNo = this.tEdit_SelectNo.Text;

            //                if (this._getDataMode == 2 || this._getDataMode == 4)
            //                {
            //                    if (Int32.Parse(selectNo) > this._clgPartsInfoTable.Count)
            //                    {
            //                        e.NextCtrl = this.tEdit_SelectNo;
            //                        this.tEdit_SelectNo.Text = "1";
            //                        return;
            //                    }

            //                    int rowNo = Int32.Parse(selectNo) - 1;

            //                    // �s�͑I��s�̃`�F�b�N
            //                    if (!this.CheckRowMaker(this.ultraGrid_ClgPartsInfo.Rows[rowNo]))
            //                    {
            //                        e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                        this._beforeSelectedRow.Selected = true;
            //                        this._beforeSelectedRow.Activate();
            //                        return;
            //                    }

            //                    this.ultraGrid_ClgPartsInfo.Rows[rowNo].Selected = true;

            //                    this.selectedRows.Clear();
            //                    this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[rowNo]);

            //                    // ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
            //                    this.SetSelectedRowColor();

            //                    e.NextCtrl = this.tEdit_SelectNo;

            //                    // 2:����
            //                    if (this._getDataMode == 2)
            //                    {
            //                        DialogResult = this.ClgOKButtonClickProc();
            //                    }
            //                    // 4:������(1:1) 
            //                    else
            //                    {
            //                        DialogResult = this.Higher1to1ButtonClickProc();
            //                    }
            //                }
            //                else
            //                {
            //                    EventArgs eventArgs = new EventArgs();

            //                    // BL�R�[�h�������[�h
            //                    if (this._startMode == 1)
            //                    {
            //                        switch (selectNo)
            //                        {
            //                            // 1:�D��
            //                            case "1":
            //                                {
            //                                    this.Prm_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 2:����
            //                            case "2":
            //                                {
            //                                    this.Clg_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 3:������
            //                            case "3":
            //                                {
            //                                    this.Higher_1toN_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            default:
            //                                {
            //                                    e.NextCtrl = this.tEdit_SelectNo;
            //                                    this.tEdit_SelectNo.Text = "1";
            //                                    break;
            //                                }
            //                        }
            //                    }
            //                    // �i�Ԍ������[�h
            //                    else
            //                    {
            //                        switch (selectNo)
            //                        {
            //                            // 1:�D��
            //                            case "1":
            //                                {
            //                                    this.Prm_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 2:����
            //                            case "2":
            //                                {
            //                                    this.Clg_OK_Button_Click(sender, eventArgs);
            //                                    e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                                    break;
            //                                }
            //                            // 3:������(1:N)
            //                            case "3":
            //                                {
            //                                    this.Higher_1toN_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 4:������(1:1) 
            //                            case "4":
            //                                {
            //                                    this.Higher_1to1_Button_Click(sender, eventArgs);
            //                                    e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                                    break;
            //                                }
            //                            default:
            //                                {
            //                                    e.NextCtrl = this.tEdit_SelectNo;
            //                                    this.tEdit_SelectNo.Text = "1";
            //                                    break;
            //                                }
            //                        }
            //                    }
            //                }
            //            }
            //            break;
            //        }
            //}
            // ---DEL ���N�n���@2014/05/16 ------------------------------------<<<<<

            // ---ADD ���N�n���@2014/05/16 ------------------------------------>>>>>
            switch (e.PrevCtrl.Name)
            {
                // �W�����i�I��(���i)
                case "ultraGrid_ClgPartsInfo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Enter)
                            {
                                // �I��ԍ�
                                e.NextCtrl = this.tEdit_SelectNo;
                            }
                        }
                        else
                        {
                           
                            if (Higher_1to1_Button.Visible == true
                                && Higher_1to1_Button.Enabled == true)
                            {
                                // 4�F������(1�F1)
                                e.NextCtrl = this.Higher_1to1_Button;
                            }
                            else if (Higher_1toN_Button.Visible == true
                                && Higher_1toN_Button.Enabled == true)
                            {
                                // 3�F������(1�FN)
                                e.NextCtrl = this.Higher_1toN_Button;
                            }
                            else if (Clg_OK_Button.Visible == true
                            && Clg_OK_Button.Enabled == true)
                            {
                                // 2�F����
                                e.NextCtrl = this.Clg_OK_Button;
                            }
                            else if (Prm_OK_Button.Visible == true
                            && Prm_OK_Button.Enabled == true)
                            {
                                // 1�F�D��
                                e.NextCtrl = this.Prm_OK_Button;
                            }
                        }
                       
                        break;
                    }
            }
            // ---ADD ���N�n���@2014/05/16 ------------------------------------<<<<<

            if (e.Key == Keys.Right || e.Key == Keys.Left)
            {
                switch (e.NextCtrl.Name)
                {
                    // 1�F�D��
                    case "Prm_OK_Button":
                        {
                            this.tEdit_SelectNo.Text = "1";
                            break;
                        }
                    // 2�F����
                    case "Clg_OK_Button":
                        {
                            if (this._getDataMode == 1)
                            {
                                this.tEdit_SelectNo.Text = "2";
                            }
                            break;
                        }
                    // 3�F������(1�FN)
                    case "Higher_1toN_Button":
                        {
                            this.tEdit_SelectNo.Text = "3";
                            break;
                        }
                    // 4�F������(1�F1)
                    case "Higher_1to1_Button":
                        {
                            if (this._getDataMode == 1)
                            {
                                this.tEdit_SelectNo.Text = "4";
                            }
                            break;
                        }
                }
            }
            else if (e.Key == Keys.Up || e.Key == Keys.Down)
            {
                e.NextCtrl = this.tEdit_SelectNo;
            }
        }

        /// <summary>
        /// [1:�D��]�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: [1:�D��]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Prm_OK_Button_Click(object sender, EventArgs e)
        {
            this.SetButtonEnable(PRICE_SELECT_DIV1);

            this.PrmOKButtonClickProc();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// [2:����]�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: [2:����]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Clg_OK_Button_Click(object sender, EventArgs e)
        {
            this._getDataMode = 2;

            if (this._clgPartsInfoTable.Rows.Count > 1)
            {
                this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0].Layout.Override.SelectTypeRow = SelectType.Single;

                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Focus();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.ultraGrid_ClgPartsInfo.Rows[0].Activate();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                // ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
                this.SetSelectedRowColor();

                this.SetButtonEnable(PRICE_SELECT_DIV2);
            }
            else
            {
                this.selectedRows.Clear();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                DialogResult = this.ClgOKButtonClickProc();
            }
        }

        /// <summary>
        /// [3:������(1:N)]�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: [3:������(1:N)]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : 2010/02/04 ����</br>
        /// <br>              PM1003�E�l������</br>
        /// <br>              ESC�{�^���ŉ�ʂ��I������</br> 
        /// </remarks>
        private void Higher_1toN_Button_Click(object sender, EventArgs e)
        {
            this.SetButtonEnable(PRICE_SELECT_DIV3);
            // --- UPD 2010/02/04 ---------->>>>>
            //ESC�{�^���ŉ�ʂ��I������
            //this.Higher1toNButtonClickProc();
            //DialogResult = DialogResult.OK;
            DialogResult = this.Higher1toNButtonClickProc();
            // --- UPD 2010/02/04 ----------<<<<<
        }

        /// <summary>
        /// [4:������(1:1)]�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: [4:������(1:1)]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Higher_1to1_Button_Click(object sender, EventArgs e)
        {
            this._getDataMode = 4;

            if (this._clgPartsInfoTable.Rows.Count > 1)
            {
                this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0].Layout.Override.SelectTypeRow = SelectType.Single;

                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Focus();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.ultraGrid_ClgPartsInfo.Rows[0].Activate();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                // ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
                this.SetSelectedRowColor();

                this.SetButtonEnable(PRICE_SELECT_DIV4);
            }
            else
            {
                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                DialogResult = this.Higher1to1ButtonClickProc();
            }
        }

        /// <summary>
        /// �I���s�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �I���s�ύX���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (this.ultraGrid_ClgPartsInfo.Selected.Rows.Count == 0)
            {
                return;
            }

            this._beforeSelectedRow = this.ultraGrid_ClgPartsInfo.Selected.Rows[0];

            this.selectedRows.Clear();
            this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Selected.Rows[0]);

            // ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
            this.SetSelectedRowColor();

            this.tEdit_SelectNo.Text = Convert.ToString(this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Index + 1);

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // �W�����i�I���̃��[�J�[�R�[�h(���i)
            _goodsMakerCd2 = Int32.Parse(this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[1].Text);
            // �W�����i�I���̃��[�J�[����(���i)
            _goodsMakerNm2 = this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[2].Text;
            // �W�����i�I���̕i��(���i)
            _goodsNo2 = this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[3].Text;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// �O���b�h�}�E�XDoule�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�}�E�XDoule�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            // �I�����Ȃ��ꍇ�A�������Ȃ�
            if (selectedRows.Count == 0)
            {
                return;
            }

            // �I���s
            UltraGridRow activeRow = this.selectedRows[0];

            // �s�͑I��s�̃`�F�b�N
            if (!this.CheckRowMaker(activeRow))
            {
                return;
            }

            if (this._getDataMode == 2)
            {
                DialogResult = this.ClgOKButtonClickProc();
            }
            else if (this._getDataMode == 4)
            {
                DialogResult = this.Higher1to1ButtonClickProc();
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : Leave���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_Leave(object sender, EventArgs e)
        {
            this.ultraGrid_ClgPartsInfo.ActiveCell = null;
            this.ultraGrid_ClgPartsInfo.ActiveRow = null;
            this.ultraGrid_ClgPartsInfo.Selected.Rows.Clear();
        }
        #endregion

        #region �� private���\�b�h ��
        /// <summary>
        /// ��ʓ��e������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�����f�[�^�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitFormDate()
        {
            // �N�����[�h���Z�b�g
            // ����`�[���͗p
            if (this._startForm == 1)
            {
                // 1�ȉ�
                if ((int)this._partsInfo.SearchCondition.SearchFlg <= 1)
                {
                    // BL�R�[�h�������[�h
                    this._startMode = 1;
                }
                // 2�ȏ�
                else
                {
                    // �i�Ԍ������[�h
                    this._startMode = 2;
                }
            }
            // �������ϗp
            else
            {
                // �i�Ԍ������[�h
                this._startMode = 2;
            }

            // ���SIZE������
            this.InitializeForm(this._startMode);
            // ���Button������
            this.InitializeFormButton(this._startMode);
            // ������ʃf�[�^�ݒ�
            this.InitializeData(this._startMode);
            // �e�{�^���̗L���^�����̐��䏈��
            this.SetButtonEnable(this._priceSelectDiv);

            // �t�H�[�J�X�̐ݒ�
            this.tEdit_SelectNo.Focus();
            this.ActiveControl = this.tEdit_SelectNo;
        }

        /// <summary>
        /// ���SIZE������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A���SIZE�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitializeForm(int startMode)
        {
            if (startMode == 1)
            {
                // �I��ԍ��̈ʒu
                //this.tEdit_SelectNo.Location = new System.Drawing.Point(480, 25);// DEL 2014/05/16 ���N�n��
                // -----ADD 2014/05/16 ���N�n��----->>>>>
                panel_Left.Width = 480;
                panel_Right.Width = 196;
                // -----ADD 2014/05/16 ���N�n��-----<<<<<
            }
            else
            {
                // �I��ԍ��̈ʒu
                //this.tEdit_SelectNo.Location = new System.Drawing.Point(598, 25);// DEL 2014/05/16 ���N�n��
                // -----ADD 2014/05/16 ���N�n��----->>>>>
                panel_Left.Width = 598;
                panel_Right.Width = 78;
                // -----ADD 2014/05/16 ���N�n��-----<<<<<
            }
        }

        /// <summary>
        /// ���Button������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A���Button�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitializeFormButton(int startMode)
        {
            if (startMode == 1)
            {
                this.Higher_1to1_Button.Visible = false;

                this.Higher_1toN_Button.Text = "3�F������";
            }
            else
            {
                this.Higher_1to1_Button.Visible = true;

                this.Higher_1toN_Button.Text = "3�F������(1�FN)";
            }
        }

        /// <summary>
        /// ������ʃf�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : ����� 2009/11/16</br>
        /// <br>            : redmine#1320,�����\���̏C��</br>
        /// <br>Update Note : ���N�n�� 2011/11/24</br>
        /// <br>            : redmine#8034,�O�ԃf�[�^�̕��i�����ŕW�����i�I���̕i�ԕ\���Ō��i�Ԃ��\�������̏C��</br>
        /// <br>Update Note: 2012/04/06 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29297   �W�����i�I����ʂ̏����i�Ԃ̕\���ɂ��Ă̏C��</br>
        /// <br>Update Note: 2012/04/06 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29153   �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
        /// </remarks> 
        private void InitializeData(int startMode)
        {
            string goodsNoForEstimate = ""; // ADD ���N�n�� 2011/11/24 Redmine#8034
            this._priceParts = new PartsDataSet();
            this._prmPartsInfoTable = this._priceParts.PrmPartsInfo;
            this._clgPartsInfoTable = this._priceParts.ClgPartsInfo;
            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            bool existsMatchMaker = false;
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            //PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = this._partsInfo.UsrGoodsInfo.RowToProcess; //DEL ���N�n�� 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = this._partsInfo.UsrGoodsInfo.RowToProcess; //ADD ������ on 2012/06/26 for Redmine#30595

            // BL�R�[�h�������[�h
            if (startMode == 1)
            {
                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // BL�R�[�h�����Ȃ�΃`�F�b�N�s�v�Ȃ̂�OK��������
                existsMatchMaker = true;
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // Grid�̂̃Z�b�g���e
                foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                {
                    //---ADD ������ on 2012/06/26 for Redmine#30595---->>>>>
                    if (rowToProcess.GoodsNo != selInfo.RowGoods.GoodsNo)
                    {
                        continue;
                    }
                    //---ADD ������ on 2012/06/26 for Redmine#30595----<<<<<
                    //---DEL ���N�n�� 2012/04/06 Redmine#29153---->>>>>
                    //------------ADD 2009/11/30--------->>>>>
                    //if (rowToProcess.GoodsNo != selInfo.RowGoods.GoodsNo)
                    //{
                    //    continue;
                    //}
                    //------------ADD 2009/11/30---------<<<<<
                    //---DEL ���N�n�� 2012/04/06 Redmine#29153----<<<<<

                    // ���i�I���őI�����ꂽ�ꗗ�̕i��
                    string goodsNo = string.Empty;
                    // NewGoodsNo��string.Empty�ꍇ
                    if (selInfo.RowGoods.NewGoodsNo.Equals(string.Empty))
                    {
                        goodsNo = selInfo.RowGoods.GoodsNo;
                    }
                    else
                    {
                        goodsNo = selInfo.RowGoods.NewGoodsNo;
                    }

                    // --- ADD 2009/11/16 ---------->>>>>
                    // ���i�I���őI������Ă��Ȃ��ꍇ(�I�𕔕i���P���ŕ��i�I����ʂ��\������Ȃ��ꍇ)
                    // this._partsInfo.ListSelectionInfo.Values �͂P���ƂȂ�ׁA
                    // ���ꍀ�ڂŃ`�F�b�N���s���A�������őΏۂƂ���B
                    // 2010/04/13 >>>
                    //string goodsNoSel = this._partsInfo.GoodsNoSel;
                    string goodsNoSel = selInfo.SelectedPartsNo;
                    // 2010/04/13 <<<
                    if (goodsNoSel.Equals(string.Empty))
                    {
                        goodsNoSel = goodsNo;
                    }
                    // --- ADD 2009/11/16 ----------<<<<<

                    // ���i�I���őI�����ꂽ�i�� == ���i�I���őI�����ꂽ�ꗗ�̕i��
                    //if (this._partsInfo.GoodsNoSel == goodsNo) // DEL 2009/11/16
                    if (goodsNoSel == goodsNo) // ADD 2009/11/16
                    {
                        // ���i
                        PartsDataSet.ClgPartsInfoRow row = this._clgPartsInfoTable.NewClgPartsInfoRow();
                        row.No = 1;
                        row.GoodsMakerCode = selInfo.RowGoods.GoodsMakerCd;
                        row.GoodsMakerNm = selInfo.RowGoods.GoodsMakerNm;
                        row.GoodsNo = goodsNo; // UPD ADD 2009/11/30 
                        row.GoodsName = selInfo.RowGoods.GoodsName;
                        row.PriceTaxExc = selInfo.RowGoods.PriceTaxExc;

                        // 2010/04/13 >>>
                        // �ŐV�i�Ԃ�\�����A���J�^���O�i�ԂƈقȂ�ꍇ�́A�ŐV���i�̒艿���̗p����
                        if (goodsNo == selInfo.RowGoods.NewGoodsNo && selInfo.RowGoods.GoodsNo != selInfo.RowGoods.NewGoodsNo)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow newPartsInfo = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(selInfo.RowGoods.GoodsMakerCd, goodsNo);
                            // ��{�I�ɂ͂��肦�Ȃ�
                            if (row != null)
                            {
                                row.PriceTaxExc = newPartsInfo.PriceTaxExc;
                            }
                        }
                        // 2010/04/13 <<<
                        // --- UPD m.suzuki 2011/06/08 ---------->>>>>
                        //// --- ADD m.suzuki 2011/01/19 ---------->>>>>
                        //// ���ꃁ�[�J�[�E����W�����i�͏��O
                        //if ( ExistsSameMakerPrice( _clgPartsInfoTable, row.GoodsMakerCode, row.PriceTaxExc ) )
                        //{
                        //    continue;
                        //}
                        //// --- ADD m.suzuki 2011/01/19 ----------<<<<<
                        //
                        //// --- UPD m.suzuki 2011/02/17 ---------->>>>>
                        ////this._clgPartsInfoTable.AddClgPartsInfoRow(row);
                        //// �W�����i�[���ȊO�܂��́A���[�U�[���i�}�X�^�ɓo�^�ς݂Ȃ�ΑΏہB
                        //// (�A���ΏۊO�̏ꍇ���A�D�ǂ̏��͕K�v�Ȃ̂ł���ȍ~�̏������s��)
                        //if ( row.PriceTaxExc != 0 ||
                        //     selInfo.RowGoods.UpdateDate != DateTime.MinValue )
                        //{
                        //    this._clgPartsInfoTable.AddClgPartsInfoRow( row );
                        //}
                        //// --- UPD m.suzuki 2011/02/17 ----------<<<<<
                        // ���ꃁ�[�J�[�E����W�����i�͏��O
                        if ( !ExistsSameMakerPrice( _clgPartsInfoTable, row.GoodsMakerCode, row.PriceTaxExc ) )
                        {
                            // �W�����i�[���ȊO�܂��́A���[�U�[���i�}�X�^�ɓo�^�ς݂Ȃ�ΑΏہB
                            // (�A���ΏۊO�̏ꍇ���A�D�ǂ̏��͕K�v�Ȃ̂ł���ȍ~�̏������s��)
                            if ( row.PriceTaxExc != 0 ||
                                 selInfo.RowGoods.UpdateDate != DateTime.MinValue )
                            {
                                this._clgPartsInfoTable.AddClgPartsInfoRow( row );
                            }
                        }
                        // --- UPD m.suzuki 2011/06/08 ----------<<<<<

                        if (selInfo.ListChildGoods2.Count == 0)
                        {
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                            {
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    if (this._prmPartsInfoTable.Rows.Count == 0)
                                    {
                                        // ��i
                                        PartsDataSet.PrmPartsInfoRow row2 = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                                        row2.GoodsMakerCode = selInfo2.RowGoods.GoodsMakerCd;
                                        row2.GoodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                        row2.GoodsNo = selInfo2.RowGoods.GoodsNo;
                                        row2.GoodsName = selInfo2.RowGoods.GoodsName;
                                        row2.PriceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                        this._prmPartsInfoTable.AddPrmPartsInfoRow(row2);
                                    }

                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods2.Values)
                            {
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    if (this._prmPartsInfoTable.Rows.Count == 0)
                                    {
                                        // ��i
                                        PartsDataSet.PrmPartsInfoRow row2 = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                                        row2.GoodsMakerCode = selInfo2.RowGoods.GoodsMakerCd;
                                        row2.GoodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                        row2.GoodsNo = selInfo2.RowGoods.GoodsNo;
                                        row2.GoodsName = selInfo2.RowGoods.GoodsName;
                                        row2.PriceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                        this._prmPartsInfoTable.AddPrmPartsInfoRow(row2);
                                    }

                                    break;
                                }
                            }
                        }

                    }
                }

                // �I��ԍ�
                this.tEdit_SelectNo.Text = "1";
            }
            // �i�Ԍ������[�h
            else
            {
                int goodsMakerCd = 0;
                string goodsMakerNm = string.Empty;
                string goodsNo = string.Empty;
                string goodsName = string.Empty;
                double priceTaxExc = 0;

                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // �J�[���[�J�[�R�[�h�擾(�ϊ���)
                int carMaker = GetCarMakerCode();
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // ����`�[���͗p
                if (this._startForm == 1)
                {
                    foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                    {
                        // �D�Ǖi�Ԍ������s�����ꍇ
                        //if (selInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                        if (selInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                        {
                            goodsMakerCd = selInfo.RowGoods.GoodsMakerCd;
                            goodsMakerNm = selInfo.RowGoods.GoodsMakerNm;
                            goodsNo = selInfo.RowGoods.GoodsNo;
                            goodsName = selInfo.RowGoods.GoodsName;
                            priceTaxExc = selInfo.RowGoods.PriceTaxExc;
                        }
                        else
                        {
                            // �����i�Ԍ������s�����ꍇ
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                            {
                                //------------UPD 2009/11/17--------->>>>>
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    goodsMakerCd = selInfo2.RowGoods.GoodsMakerCd;
                                    goodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                    goodsNo = selInfo2.RowGoods.GoodsNo;
                                    goodsName = selInfo2.RowGoods.GoodsName;
                                    priceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                    break;
                                }
                                //------------UPD 2009/11/17---------<<<<<
                            }
                        }
                        break;
                    }
                }
                // �������ϗp
                else
                {
                    //---ADD ���N�n�� 2011/11/24 Redmine#8034-------------------->>>>>
                    foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                    {
                        if (selInfo.RowGoods.NewGoodsNo.Equals(string.Empty))
                        {
                            goodsNoForEstimate = this._goodsNo;
                        }
                        else
                        {
                            goodsNoForEstimate = selInfo.RowGoods.NewGoodsNo;
                        }
                    }
                    if (this._partsInfo.ListSelectionInfo.Values.Count == 0)
                    {
                        goodsNoForEstimate = this._partsInfo.GoodsNoSel;
                    }
                    //---ADD ���N�n�� 2011/11/24 Redmine#8034--------------------<<<<<
                    goodsMakerCd = this._goodsMakerCd;
                    goodsMakerNm = this._goodsMakerNm;
                    goodsNo = this._goodsNo;
                    goodsName = this._goodsName;
                    priceTaxExc = this._priceTaxExc;
                }

                // ��i
                PartsDataSet.PrmPartsInfoRow row = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                row.GoodsMakerCode = goodsMakerCd;
                row.GoodsMakerNm = goodsMakerNm;
                row.GoodsNo = goodsNo;
                row.GoodsName = goodsName;
                row.PriceTaxExc = priceTaxExc;
                this._prmPartsInfoTable.AddPrmPartsInfoRow(row);

                //---ADD ���N�n�� 2012/04/06 Redmine#29297-------------------->>>>>
                List<PartsInfoDataSet.UsrGoodsInfoRow> usrGoodsInfoRows = new List<PartsInfoDataSet.UsrGoodsInfoRow>();

                foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in this._partsInfo.PartsInfoDataSetSrcParts.UsrGoodsInfo)
                {
                    usrGoodsInfoRows.Add(usrGoodsInfoRow);
                }

                DataToTarComparer TarData = new DataToTarComparer();
                //�擾�����������i���u���[�J�[�v�ˁu�i�ԁv�̏��Ń\�[�g����A�\�[�g�͂ǂ��������(ASC)�ōs���B
                usrGoodsInfoRows.Sort(TarData);
                //---ADD ���N�n�� 2012/04/06 Redmine#29297--------------------<<<<<
                // ���i
                foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in usrGoodsInfoRows)//ADD ���N�n�� 2012/04/06 Redmine#29297
                //foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in this._partsInfo.PartsInfoDataSetSrcParts.UsrGoodsInfo)//DEL ���N�n�� 2012/04/06 Redmine#29297
                {
                    // --- ADD m.suzuki 2011/01/19 ---------->>>>>
                    // �W�����i�[���͏��O
                    if ( usrGoodsInfoRow.PriceTaxExc == 0 )
                    {
                        continue;
                    }
                    // ���ꃁ�[�J�[�E����W�����i�͏��O
                    if ( ExistsSameMakerPrice( _clgPartsInfoTable, usrGoodsInfoRow.GoodsMakerCd, usrGoodsInfoRow.PriceTaxExc ) )
                    {
                        continue;
                    }
                    // --- ADD m.suzuki 2011/01/19 ----------<<<<<

                    PartsDataSet.ClgPartsInfoRow partsInfoRow = this._clgPartsInfoTable.NewClgPartsInfoRow();
                    partsInfoRow.GoodsMakerCode = usrGoodsInfoRow.GoodsMakerCd;
                    partsInfoRow.GoodsMakerNm = usrGoodsInfoRow.GoodsMakerNm;
                    partsInfoRow.GoodsNo = usrGoodsInfoRow.GoodsNo;
                    partsInfoRow.GoodsName = usrGoodsInfoRow.GoodsName;
                    partsInfoRow.PriceTaxExc = usrGoodsInfoRow.PriceTaxExc;

                    //---ADD ���N�n�� 2011/11/24 Redmine#8034-------------------------->>>>>
                    if (this._startForm != 1)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow newPartsInfo = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(usrGoodsInfoRow.GoodsMakerCd, goodsNoForEstimate);
                        // ��{�I�ɂ͂��肦�Ȃ�
                        if (row != null && null != newPartsInfo)
                        {
                            partsInfoRow.PriceTaxExc = newPartsInfo.PriceTaxExc;
                            partsInfoRow.GoodsNo = goodsNoForEstimate;
                        }
                    }
                    //---ADD ���N�n�� 2011/11/24 Redmine#8034-------------------------<<<<<

                    this._clgPartsInfoTable.AddClgPartsInfoRow(partsInfoRow);

                    // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                    // �J�[���[�J�[�ɍ��v����s���P�s�ł������OK
                    // (���J�[���[�J�[�̕ϊ��������L��̂ŁACheckMaker���\�b�h���g�p���Ȃ�)
                    if ( carMaker <= 0 ||
                         usrGoodsInfoRow.GoodsMakerCd == carMaker )
                    {
                        existsMatchMaker = true;
                    }
                    // --- ADD m.suzuki 2011/02/25 ----------<<<<<
                }

                // �I��ԍ�
                this.tEdit_SelectNo.Text = "1";
            }

            this._priceParts.AcceptChanges();
            this.ultraGrid_PrmPartsInfo.DataSource = this._prmPartsInfoTable.DefaultView;

            DataView dv = this._clgPartsInfoTable.DefaultView;
            // �\�[�g�����u���[�J�[�R�[�h(����)�E�W�����i(����)�v
            dv.Sort = "GoodsMakerCode, PriceTaxExc, GoodsNo";

            // No�̐ݒ�
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i][0] = i + 1;
            }
            this.ultraGrid_ClgPartsInfo.DataSource = dv;

            // --- ADD m.suzuki 2011/01/19 ---------->>>>>
            // �W�����i�[�������O�������ʁA
            // ���i�O���b�h�ɕ\�����鏃�����[�����ɂȂ����ꍇ��
            // �D�ǂŊm�肷��B
            if ( _clgPartsInfoTable.Rows.Count == 0 )
            {
                _priceSelectDiv = PRICE_SELECT_DIV1;
            }
            // --- ADD m.suzuki 2011/01/19 ----------<<<<<
            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            if ( !existsMatchMaker )
            {
                // �I���\�ȍs���P�s���Ȃ���ΗD�ǂŊm�肷��B
                // (���J�[���[�J�[�ɍ��v���Ȃ��������[�J�[�͑I��s�̎d�l)
                _priceSelectDiv = PRICE_SELECT_DIV1;
            }
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<
        }

        //---ADD ���N�n�� 2012/04/06 Redmine#29297-------------------->>>>>
        /// <summary>
        /// �f�[�^�\�[�g������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�\�[�g������</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2012/04/06</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M���@Redmine#29297�@�W�����i�I����ʂ̏����i�Ԃ̕\���ɂ��Ă̏C��</br>
        /// </remarks>
        private class DataToTarComparer : IComparer<PartsInfoDataSet.UsrGoodsInfoRow>
        {
            public int Compare(PartsInfoDataSet.UsrGoodsInfoRow x, PartsInfoDataSet.UsrGoodsInfoRow y)
            {
                int ret = ComparerHelper.CompareObject(x.GoodsMakerCd, y.GoodsMakerCd);

                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.GoodsNo, y.GoodsNo);
                }
                return ret;
            }
        }

        /// <summary>
        /// Comparer����
        /// </summary>
        /// <remarks>
        /// <br>Note       : Comparer����</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2012/04/06</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M���@Redmine#29297�@�W�����i�I����ʂ̏����i�Ԃ̕\���ɂ��Ă̏C��</br>
        /// <br></br>
        /// </remarks>
        private class ComparerHelper
        {
            public static int CompareObject(object val1, object val2)
            {
                int a = 0;
                int b = 0;
                if (val1 == null && val2 == null)
                {
                    return 0;
                }
                else if (val1 != null && val2 != null)
                {
                    if (val1 is int)
                    {
                        Convert.ToInt32(val1);
                        a = Convert.ToInt32(val1);
                        b = Convert.ToInt32(val2);
                        if (a > b)
                        {
                            return 1;
                        }
                        else if (a == b)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return val1.ToString().CompareTo(val2.ToString());
                    }

                }
                else if (val1 != null && val2 == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        //---ADD ���N�n�� 2012/04/06 Redmine#29297--------------------<<<<<

        // --- ADD m.suzuki 2011/01/19 ---------->>>>>
        /// <summary>
        /// ���ꃁ�[�J�[�E���ꉿ�i���R�[�h���݃`�F�b�N����
        /// </summary>
        /// <param name="table">�Ώۃf�[�^�e�[�u��</param>
        /// <param name="goodsMakerCd">���[�J�[</param>
        /// <param name="priceTaxExc">�W�����i</param>
        /// <returns></returns>
        private bool ExistsSameMakerPrice( PartsDataSet.ClgPartsInfoDataTable table, int goodsMakerCd, double priceTaxExc )
        {
            // View�𐶐����ăt�B���^��������
            DataView view = new DataView( table );
            view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'",
                                            table.GoodsMakerCodeColumn.ColumnName, goodsMakerCd,
                                            table.PriceTaxExcColumn.ColumnName, priceTaxExc );
            // ���R�[�h�������TRUE
            return (view.Count > 0);
        }
        // --- ADD m.suzuki 2011/01/19 ----------<<<<<

        /// <summary>
        /// �m�菈��(1:�D��)
        /// </summary>
        /// <remarks>
        /// <br>Note		: [1:�D��]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult PrmOKButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            this._startPriceFlag = false;
            // �W�����i(��i),�W�����i�̐ݒ菈��
            this.SetSelectedListPrice((double)this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.PriceTaxExcColumn]);

            return retDialogResult;
        }

        /// <summary>
        /// �m�菈��(2:����)
        /// </summary>
        /// <remarks>
        /// <br>Note		: [2:����]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult ClgOKButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            this._startPriceFlag = true;
            // BL�R�[�h�������[�h,�i�Ԍ������[�h
            if (this.selectedRows.Count == 0)
            {
                return DialogResult.Cancel;
            }

            // �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v���Ȃ����ׂ�I�������ꍇ
            if (!CheckMaker((int)this.selectedRows[0].Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value))
            {
                return retDialogResult;
            }

            this.SetSelectedListPrice((double)this.selectedRows[0].Cells[this._clgPartsInfoTable.PriceTaxExcColumn.ColumnName].Value);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // �y����i�ԑI���z��ʕ\��
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// �m�菈��(3:������(1:N))
        /// </summary>
        /// <remarks>
        /// <br>Note		: [3:������(1:N)]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult Higher1toNButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            // �W�����i
            double priceTaxExc = 0;
            // �W�����i(��i)
            double priceTaxExcTop = (double)this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.PriceTaxExcColumn];

            // �W�����i(���i)
            double PriceTaxExcDown = 0;
            foreach (PartsDataSet.ClgPartsInfoRow row in this._clgPartsInfoTable.Rows)
            {
                
                // �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v���Ȃ����ׂ�I�������ꍇ
                if (!CheckMaker(row.GoodsMakerCode))
                {
                    continue;
                }

                if (row.PriceTaxExc > PriceTaxExcDown)
                {
                    PriceTaxExcDown = row.PriceTaxExc;
                    // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                    // �W�����i�I���̃��[�J�[�R�[�h(���i)
                    _goodsMakerCd2 = row.GoodsMakerCode;
                    // �W�����i�I���̃��[�J�[����(���i)
                    _goodsMakerNm2 = row.GoodsMakerNm;
                    // �W�����i�I���̕i��(���i)
                    _goodsNo2 = row.GoodsNo;
                    // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                }
            }

            // �W�����i(��i)�ƕW�����i(���i)�̍�����
            if (priceTaxExcTop > PriceTaxExcDown)
            {
                priceTaxExc = priceTaxExcTop;
                this._startPriceFlag = false;
            }
            else
            {
                priceTaxExc = PriceTaxExcDown;
                this._startPriceFlag = true;
            }

            // �W�����i�̐ݒ菈��
            this.SetSelectedListPrice(priceTaxExc);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // �y����i�ԑI���z��ʕ\��
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// �m�菈��(4:������(1:1))
        /// </summary>
        /// <remarks>
        /// <br>Note		: [4:������(1:1)]�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult Higher1to1ButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            UltraGridRow prmRow = this.ultraGrid_PrmPartsInfo.Rows[0];
            UltraGridRow clgRow = this.selectedRows[0];

            // �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v���Ȃ����ׂ�I�������ꍇ
            if (!CheckMaker((int)clgRow.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value))
            {
                return retDialogResult;
            }

            // �W�����i
            double priceTaxExc = 0;
            // �W�����i(��i)
            double priceTaxExcTop = (double)prmRow.Cells[this._prmPartsInfoTable.PriceTaxExcColumn.ColumnName].Value;
            // �W�����i(���i)
            double priceTaxExcDown = (double)clgRow.Cells[this._clgPartsInfoTable.PriceTaxExcColumn.ColumnName].Value;


            // �W�����i(��i)�ƕW�����i(���i)�̍�����
            if (priceTaxExcTop > priceTaxExcDown)
            {
                priceTaxExc = priceTaxExcTop;
                this._startPriceFlag = false;
            }
            else
            {
                priceTaxExc = priceTaxExcDown;
                this._startPriceFlag = true;
            }

            // �W�����i�̐ݒ菈��
            this.SetSelectedListPrice(priceTaxExc);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // �y����i�ԑI���z��ʕ\��
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// �e�{�^���̗L���^�����̐��䏈��
        /// </summary>
        /// <param name="priceSelectDiv">�W�����i�I���敪</param>
        /// <remarks>
        /// <br>Note		: �e�{�^���̗L���^�����̐�����s���B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetButtonEnable(int priceSelectDiv)
        {
            switch (priceSelectDiv)
            {
                // �W�����i�I���敪(1:�D��)
                case PRICE_SELECT_DIV1:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Red;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        break;
                    }
                // �W�����i�I���敪(2:����)
                case PRICE_SELECT_DIV2:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Red;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // �p�^�[����No9
                        if (!this._parten9)
                        {
                            this.Prm_OK_Button.Enabled = false;
                            this.Clg_OK_Button.Enabled = true;
                            this.Higher_1to1_Button.Enabled = false;
                            this.Higher_1toN_Button.Enabled = false;
                        }
                        break;
                    }
                // �W�����i�I���敪(3:������(1:N))
                case PRICE_SELECT_DIV3:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Red;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        break;
                    }
                // �W�����i�I���敪(4:������(1:1))
                case PRICE_SELECT_DIV4:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Red;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // �p�^�[����No9
                        if (!this._parten9)
                        {
                            this.Prm_OK_Button.Enabled = false;
                            this.Clg_OK_Button.Enabled = false;
                            this.Higher_1to1_Button.Enabled = true;
                            this.Higher_1toN_Button.Enabled = false;
                        }
                        break;
                    }
                // �W�����i�I���敪(���̑�)
                default:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        break;
                    }
            }
        }

        /// <summary>
        /// �s�͑I��s�̃`�F�b�N
        /// </summary>
        /// <param name="usrGoodsInfo">�������[�J</param>
        /// <remarks>
        /// <br>Note		: �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v���Ă��Ȃ��ꍇ�A�s�͑I��s��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private bool CheckRowMaker(UltraGridRow usrGoodsInfo)
        {
            // �ԗ���������Ă���ꍇ
            // --- UPD m.suzuki 2011/02/25 ---------->>>>>
            //if (this._carInfo != null
            //    && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0)
            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0 )
            // --- UPD m.suzuki 2011/02/25 ----------<<<<<
            {
                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // ���[�J�[�R�[�h�ϊ�
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v
                // --- UPD m.suzuki 2011/02/25 ---------->>>>>
                //if ((int)usrGoodsInfo.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value !=
                //    this._carInfo.CarModelInfoSummarized[0].MakerCode)
                if ( (int)usrGoodsInfo.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value != makerCode )
                // --- UPD m.suzuki 2011/02/25 ----------<<<<<
                {
                    TMsgDisp.Show(this, 											// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���̃��[�J�[�͑I���ł��܂���B",                   // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �s�͑I��s�̃`�F�b�N
        /// </summary>
        /// <param name="goodsMake">�J�[���[�J�[�R�[�h</param>
        /// <remarks>
        /// <br>Note		: �������[�J�[�R�[�h�ƃJ�[���[�J�[�R�[�h����v���Ă��Ȃ��ꍇ�A�s�͑I��s��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private bool CheckMaker(int goodsMake)
        {
            // --- UPD m.suzuki 2010/07/27 ---------->>>>>
            ////>>>2010/04/27
            //// �J�[���[�J�[�R�[�h�ϊ�
            //int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
            //if (this._changeMakerDic.ContainsKey(makerCode))
            //{
            //    makerCode = this._changeMakerDic[this._carInfo.CarModelInfoSummarized[0].MakerCode];
            //}
            ////<<<2010/04/27

            //if (this._carInfo != null
            //    && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0
            //    //>>>2010/04/27
            //    //&& goodsMake != this._carInfo.CarModelInfoSummarized[0].MakerCode)
            //    && goodsMake != makerCode)
            //    //<<<2010/04/27
            //{
            //    return false;
            //}

            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null 
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0)
            {
                // ���[�J�[�R�[�h�ϊ�
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }

                // ���[�J�[�R�[�h����
                if ( goodsMake != makerCode )
                {
                    return false;
                }
            }
            // --- UPD m.suzuki 2010/07/27 ----------<<<<<

            return true;
        }
        // --- ADD m.suzuki 2011/02/25 ---------->>>>>
        /// <summary>
        /// �J�[���[�J�[�R�[�h���擾�i�ϊ���̒l�j
        /// </summary>
        /// <returns></returns>
        private int GetCarMakerCode()
        {
            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0 )
            {
                // ���[�J�[�R�[�h�ϊ�
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }
                return makerCode;
            }
            else
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2011/02/25 ----------<<<<<

        /// <summary>
        /// �W�����i�̐ݒ菈��
        /// </summary>
        /// <param name="priceTaxExc">�W�����i</param>
        /// <remarks>
        /// <br>Note		: �m�菈�����āA�s�W�����i�̐ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetSelectedListPrice(double priceTaxExc)
        {
            // ���[�J�[(��i)
            string goodsMakerCode = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerCodeColumn].ToString();
            // �i��(��i)
            string goodsNo = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsNoColumn].ToString();

            this._partsInfo.UsrGoodsInfo.BeginLoadData();
            PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(Int32.Parse(goodsMakerCode), goodsNo);

            if (row == null)
            {
                return;
            }

            // �擾�����W�����i�𕔕i�������ʃf�[�^�Z�b�g�֐ݒ肷��B
            row.SelectedListPrice = priceTaxExc;
            // ���i�������ʃf�[�^�Z�b�g�̕W�����i�I��L���敪�ցu1�v��ݒ肷��B
            row.SelectedListPriceDiv = 1;

            this._partsInfo.UsrGoodsInfo.EndLoadData();
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���׃O���b�h�E�s�P�ʂł̃Z���ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetSelectedRowColor()
        {
            if (selectedRows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this._clgPartsInfoTable.Count; i++)
            {
                UltraGridRow ultraRow = this.ultraGrid_ClgPartsInfo.Rows[i];

                if (ultraRow.Selected)
                {
                    foreach (UltraGridCell cell in ultraRow.Cells)
                    {
                        if (cell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                        {
                            // Active�Z���F�ŏ㏑��
                            cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        }
                    }
                }
                else
                {
                    // �ʏ�F�ݒ�
                    if (ultraRow.Index % 2 == 0)
                    {
                        foreach (UltraGridCell ultraCell in ultraRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                            {
                                ultraCell.Appearance.BackColor = Color.White;
                                ultraCell.Appearance.BackColor2 = Color.White;
                                ultraCell.Appearance.BackColorDisabled = Color.White;
                                ultraCell.Appearance.BackColorDisabled2 = Color.White;
                            }
                        }
                    }
                    else
                    {
                        foreach (UltraGridCell ultraCell in ultraRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                            {
                                ultraCell.Appearance.BackColor = Color.Lavender;
                                ultraCell.Appearance.BackColor2 = Color.Lavender;
                                ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                                ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �y����i�ԑI���z��ʕ\��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �y����i�ԑI���z��ʕ\�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/23</br>
        /// <br>Update Note : 2015/04/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�    : 11070149-00</br>
        /// <br>              �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// </remarks>
        private DialogResult StartPrintForm()
        {
            DialogResult retDialogRt = DialogResult.OK;
            // �W�����i�I���̃��[�J�[�R�[�h(��i)
            int goodsMakerCd = Int32.Parse(this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerCodeColumn].ToString());
            // �W�����i�I���̃��[�J�[����(��i)
            string goodsMakerNm = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerNmColumn].ToString();
            // �W�����i�I���̕i��(��i)
            string goodsNo = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsNoColumn].ToString();

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            if (_goodsMakerCd2 == 0)
            {
                int selectRowIndex = 0;
                if (this._beforeSelectedRow != null)
                {
                    selectRowIndex = this._beforeSelectedRow.Index;
                }
                // �W�����i�I���̃��[�J�[�R�[�h(���i)
                _goodsMakerCd2 = Int32.Parse(this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsMakerCodeColumn].ToString());
                // �W�����i�I���̃��[�J�[����(���i)
                _goodsMakerNm2 = this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsMakerNmColumn].ToString();
                // �W�����i�I���̕i��(���i)
                _goodsNo2 = this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsNoColumn].ToString();
            }
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
            this._srcGoodsNo = (string)_goodsNo2.Clone();
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
            #region ������S�̐ݒ�}�X�^ DCKHN09212A
            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList salesTtlStList;
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();     // ����S�̐ݒ�}�X�^
            salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesTtlStAcs.SearchOnlySalesTtlInfo(out salesTtlStList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesTtlStList != null) this.CacheSalesTtlSt(salesTtlStList, enterpriseCode, sectionCode);
                if (this._salesTtlSt.EpPartsNoPrtCd == 1)
                {
                    _goodsNo2 += this._salesTtlSt.EpPartsNoAddChar;
                }
            }
            #endregion          
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // �y����i�ԑI���z��ʕ\��
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
            ////SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo);
            //SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo, _goodsMakerCd2, _goodsMakerNm2, _goodsNo2, this._salesTtlSt.EpPartsNoPrtCd);
            //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
            SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo, _goodsMakerCd2, _goodsMakerNm2, _goodsNo2, this._salesTtlSt.EpPartsNoPrtCd, this._salesTtlSt.PrintGoodsNoDef);
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
            if (!string.IsNullOrEmpty(this._addTitleCaption))
            {
                printForm.Text += this._addTitleCaption;
            }
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
            retDialogRt = printForm.ShowDialog(Owner);

            return retDialogRt;
        }

        /// <summary>
        /// �I���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2010/02/04</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^���͉B��Ă܂�
            // ESC�{�^���ŉ�ʂ��I������
            this.Close();
        }
        #endregion

        #region �� public���\�b�h ��
        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��ʕ\�����ɔ������܂��B�W�����i�I���敪���A��ʕ\���̏���</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : ����� 2009/11/13</br>
        /// <br>            : redmine#1266  �����t�H�[�J�X�ʒu�̏C��</br>
        /// <br>Update Note : 2015/04/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�    : 11070149-00</br>
        /// <br>              �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
            if (!string.IsNullOrEmpty(this._addTitleCaption))
            {
                this.Text += this._addTitleCaption;
            }
            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<

            // �N�����[�h
            switch (this._startMode)
            {
                // BL�R�[�h�������[�h
                case 1:
                    {
                        // �W�����i�I���敪
                        switch (this._priceSelectDiv)
                        {
                            // 1:�D��
                            case PRICE_SELECT_DIV1:
                                {
                                    return this.PrmOKButtonClickProc();
                                }
                            // 2:����
                            case PRICE_SELECT_DIV2:
                                {
                                    this.selectedRows.Clear();
                                    this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);
                                    return this.ClgOKButtonClickProc();
                                }
                            // 3:������
                            case PRICE_SELECT_DIV3:
                            case PRICE_SELECT_DIV4:
                                {
                                    return this.Higher1toNButtonClickProc();
                                }
                            // --- ADD 2009/11/13 ---------->>>>> 
                            default:
                                {
                                    this.ultraGrid_ClgPartsInfo.TabStop = false;
                                    break;
                                }
                            // --- ADD 2009/11/13 ----------<<<<<
                        }
                        break;
                    }
                // �i�Ԍ������[�h
                case 2:
                    {
                        // �W�����i�I���敪
                        switch (this._priceSelectDiv)
                        {
                            // 1:�D��
                            case PRICE_SELECT_DIV1:
                                {
                                    return this.PrmOKButtonClickProc();
                                }
                            // 2:����
                            case PRICE_SELECT_DIV2:
                                {
                                    this._parten9 = false;

                                    if (this._clgPartsInfoTable.Rows.Count == 1)
                                    {
                                        this.selectedRows.Clear();
                                        this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                                        return this.ClgOKButtonClickProc();
                                    }
                                    else
                                    {
                                        this.Clg_OK_Button_Click(this, new EventArgs());
                                    }
                                    break;
                                }
                            // 3:������(1:N)
                            case PRICE_SELECT_DIV3:
                                {
                                    return this.Higher1toNButtonClickProc();
                                }
                            // 4:������(1:1)
                            case PRICE_SELECT_DIV4:
                                {
                                    this._parten9 = false;

                                    if (this._clgPartsInfoTable.Rows.Count == 1)
                                    {
                                        this.selectedRows.Clear();
                                        this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                                        return this.Higher1to1ButtonClickProc();
                                    }
                                    else
                                    {
                                        this.Higher_1to1_Button_Click(this, new EventArgs());
                                    }
                                    break;
                                }
                            default:
                                {
                                    this.ultraGrid_ClgPartsInfo.TabStop = false;
                                    break;
                                }
                        }
                        break;
                    }
            }
            return base.ShowDialog(owner);
        }
        #endregion

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        # region ������S�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// ����S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
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
        # endregion
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // ---ADD ���N�n���@2014/05/16 ------------------------------------>>>>>
        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2014/05/16</br>
        /// </remarks>
        private void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13:
                    string selectNo = this.tEdit_SelectNo.Text;

                    if (this._getDataMode == 2 || this._getDataMode == 4)
                    {
                        if (Int32.Parse(selectNo) > this._clgPartsInfoTable.Count)
                        {
                            this.tEdit_SelectNo.Focus();
                            this.tEdit_SelectNo.Text = "1";
                            return;
                        }

                        int rowNo = Int32.Parse(selectNo) - 1;

                        // �s�͑I��s�̃`�F�b�N
                        if (!this.CheckRowMaker(this.ultraGrid_ClgPartsInfo.Rows[rowNo]))
                        {
                            this.ultraGrid_ClgPartsInfo.Focus();
                            this._beforeSelectedRow.Selected = true;
                            this._beforeSelectedRow.Activate();
                            return;
                        }

                        this.ultraGrid_ClgPartsInfo.Rows[rowNo].Selected = true;

                        this.selectedRows.Clear();
                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[rowNo]);

                        // ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
                        this.SetSelectedRowColor();

                        this.tEdit_SelectNo.Focus();

                        // 2:����
                        if (this._getDataMode == 2)
                        {
                            DialogResult = this.ClgOKButtonClickProc();
                        }
                        // 4:������(1:1) 
                        else
                        {
                            DialogResult = this.Higher1to1ButtonClickProc();
                        }
                    }
                    else
                    {
                        EventArgs eventArgs = new EventArgs();

                        // BL�R�[�h�������[�h
                        if (this._startMode == 1)
                        {
                            switch (selectNo)
                            {
                                // 1:�D��
                                case "1":
                                    {
                                        this.Prm_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 2:����
                                case "2":
                                    {
                                        this.Clg_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 3:������
                                case "3":
                                    {
                                        this.Higher_1toN_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                default:
                                    {
                                        this.tEdit_SelectNo.Focus();
                                        this.tEdit_SelectNo.Text = "1";
                                        break;
                                    }
                            }
                        }
                        // �i�Ԍ������[�h
                        else
                        {
                            switch (selectNo)
                            {
                                // 1:�D��
                                case "1":
                                    {
                                        this.Prm_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 2:����
                                case "2":
                                    {
                                        this.Clg_OK_Button_Click(sender, eventArgs);
                                        this.ultraGrid_ClgPartsInfo.Focus();
                                        break;
                                    }
                                // 3:������(1:N)
                                case "3":
                                    {
                                        this.Higher_1toN_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 4:������(1:1) 
                                case "4":
                                    {
                                        this.Higher_1to1_Button_Click(sender, eventArgs);
                                        this.ultraGrid_ClgPartsInfo.Focus();
                                        break;
                                    }
                                default:
                                    {
                                        this.tEdit_SelectNo.Focus();
                                        this.tEdit_SelectNo.Text = "1";
                                        break;
                                    }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        // ---ADD ���N�n���@2014/05/16 ------------------------------------<<<<<
        
    }
}
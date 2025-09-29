//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��ɍX�V
// �v���O�����T�v   : �݌ɓ��ɍX�V�Ŏg�p����f�[�^�̎擾�A�X�V���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/14  �C�����e : ���|�I�v�V�����擾���\�b�h�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/15  �C�����e : �s��Ή�[10068][10115][10059]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/16  �C�����e : UOE�����ŋ��_�ABO1�ABO2�ABO3�̂���2�ȏ�`�[�ԍ��������Ă��Ȃ��f�[�^������ꍇ�ɃG���[�ƂȂ�ׁA�C��
//                                  �s��Ή�[10145]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/19  �C�����e : 2009/01/16�Ή����̕����ύX�A�y��Ұ��̫۰�AEO�̒ǉ�
//                                  �s��Ή�[10063]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/05  �C�����e : �s��Ή�[10974]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/17  �C�����e : �s��Ή�[11238]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/18  �C�����e : ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/02/23  �C�����e : �����擾�O�ɒ����`�F�b�N���s���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/11/15  �C�����e : 1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�
//                                : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪
//                                : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �C �� ��  2012/12/17  �C�����e : 1��16���z�M���ARedmine#32926 PM�f�[�^�ƘA�g�����Ȃ��̑Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �C �� ��  2012/12/17  �C�����e :  1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����
// �C �� ��  2013/05/16  �C�����e : 2013/06/18�z�M���ARedmine#35459 #42�̑Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ���t
// �C �� ��  2015/01/21  �C�����e : Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00 �쐬�S�� : �v��
// �C �� ��  2015/08/26  �C�����e : Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �C �� ��  2017/08/11  �C�����e : �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
//----------------------------------------------------------------------//

# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;// ADD wangf 2012/11/15 FOR Redmine#31980
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE���ɍX�V�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note		: UOE���ɍX�V�f�[�^�̌������s���܂��B</br>
    /// <br>              ��UOE�����f�[�^��UOE���ɍX�V���C���f�[�^(�I�����C���ԍ�-�`�[�ԍ��P�ʂɕ���)��UOE���ɍX�V�w�b�_�[�A���׃f�[�^�̏��ɍ쐬</br>
	/// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/09/04</br>
    /// <br>UpdateNote  : 2009/01/14 �Ɠc �M�u�@���|�I�v�V�����擾���\�b�h�ύX</br>
    /// <br>              2009/01/15 �Ɠc �M�u�@�s��Ή�[10068][10115][10059]</br>
    /// <br>              2009/01/16 �Ɠc �M�u�@UOE�����ŋ��_�ABO1�ABO2�ABO3�̂���2�ȏ�`�[�ԍ��������Ă��Ȃ��f�[�^������ꍇ�ɃG���[�ƂȂ�ׁA�C��</br>
    /// <br>                                    �s��Ή�[10145]</br>
    /// <br>              2009/01/19 �Ɠc �M�u�@2009/01/16�Ή����̕����ύX�A�y��Ұ��̫۰�AEO�̒ǉ�</br>
    /// <br>                                    �s��Ή�[10063]</br>
    /// <br>              2009/02/05 �Ɠc �M�u�@�s��Ή�[10974]</br>
    /// <br>              2009/02/17 �Ɠc �M�u�@�s��Ή�[11238]</br>
    /// <br>              2009/02/18 �Ɠc �M�u�@���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������</br>
    /// <br>              2009/02/23 �Ɠc �M�u�@�����擾�O�ɒ����`�F�b�N���s���悤�ɏC��</br>
    /// <br>Update Note : 2012/11/15 wangf </br>
    /// <br>            : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
    /// <br>            : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
    /// <br>            : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
    /// <br>Update Note : 2012/12/17 yangmj </br>
    /// <br>            : 10801804-00�A1��16���z�M���Aredmine#32926 PM�f�[�^�ƘA�g�����Ȃ��̑Ή�</br>
    /// <br>Update Note : 2012/12/17 yangmj </br>
    /// <br>            : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
    /// <br>UpdateNote  : 2013/05/16 �����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2013/06/18�z�M��</br>
    /// <br>              Redmine#35459 #42�̑Ή�</br>
    /// <br>UpdateNote  : 2015/01/21 ���t  </br>
    /// <br>�Ǘ��ԍ�    : 11070149-00 2015/01/21�z�M��</br>
    /// <br>              Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C���̑Ή�</br> 
    /// <br>UpdateNote  : 2015/08/26 �v��  </br>
    /// <br>�Ǘ��ԍ�    : 11170129-00</br>
    /// <br>              Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�</br> 
    /// <br>UpdateNote  : 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�    : 11370074-00</br>
    /// <br>              �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// </remarks>
    public class PMUOE01203AA
    {
        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        # region ���萔
        // ��敪
        public const string COLUMNDIV_SECTION = "SECTION";      // ���_
        public const string COLUMNDIV_BO1 = "BO1";              // BO1
        public const string COLUMNDIV_BO2 = "BO2";              // BO2
        public const string COLUMNDIV_BO3 = "BO3";              // BO3
        public const string COLUMNDIV_MAKER = "MAKER";          // ���[�J�[
        public const string COLUMNDIV_EO = "EO";                // EO
        #endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���萔�i�n���f�B�^�[�~�i���p�j
        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���[�N�v���O����ID�̃N���X��</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.InspectDataAddWork";

        /// <summary>�d�����גʔ�</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>���ɋ敪</summary>
        private const string WarehousingDivCd = "WarehousingDivCd";
        /// <summary>�X�V�敪</summary>
        private const string UpdateDiv = "UpdateDiv";
        /// <summary>���i��</summary>
        private const string InspectCnt = "InspectCnt";
        /// <summary>������R�[�h</summary>
        private const string UoeSupplierCd = "UoeSupplierCd";

        /// <summary>�ŗ��R�[�h</summary>
        private const int TaxRateCode = 0;

        /// <summary>���_</summary>
        private const string WarehousingSectionDiv = "1";
        /// <summary>BO1</summary>
        private const string WarehousingBo1Div = "2";
        /// <summary>BO2</summary>
        private const string WarehousingBo2Div = "3";
        /// <summary>BO3</summary>
        private const string WarehousingBo3Div = "4";
        /// <summary>���[�J�[</summary>
        private const string WarehousingMakerDiv = "5";
        /// <summary>EO</summary>
        private const string WarehousingEoDiv = "6";

        /// <summary>UOE���_�`�[�ԍ�</summary>
        private const string EnterUpdDivSecSlipNo = "��ݺ޳ż ����";
        /// <summary>BO�`�[�ԍ�1</summary>
        private const string EnterUpdDivBO1SlipNo = "��ݺ޳ż BO1";
        /// <summary>BO�`�[�ԍ�2</summary>
        private const string EnterUpdDivBO2SlipNo = "��ݺ޳ż BO2";
        /// <summary>BO�`�[�ԍ�3</summary>
        private const string EnterUpdDivBO3SlipNo = "��ݺ޳ż BO3";
        /// <summary>Ұ��</summary>
        private const string EnterUpdDivMakerSlipNo = "��ݺ޳ż Ұ��";
        /// <summary>EO</summary>
        private const string EnterUpdDivEOSlipNo = "��ݺ޳ż EO";

        /// <summary>���ɍX�V�敪�i���_�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivSecData0 = 0;
        /// <summary>���ɍX�V�敪�iBO1�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO1Data0 = 0;
        /// <summary>���ɍX�V�敪�iBO2�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO2Data0 = 0;
        /// <summary>���ɍX�V�敪�iBO3�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO3Data0 = 0;
        /// <summary>���ɍX�V�敪�iҰ���j�u0:�����Ɂv</summary>
        private const int EnterUpdDivMakerData0 = 0;
        /// <summary>���ɍX�V�敪�iEO�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivEOData0 = 0;

        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ���ϐ�
        // �e��N���X
        private GoodsAcs _goodsAcs = null;                      // ���i�}�X�^�A�N�Z�X�N���X
        private PMUOE01203AB _decisionDataAcs = null;           // ���ɍX�V�m�菈���p�N���X
        private IUOEStockUpdateDB _iUOEStockUpdateDB = null;    // ���ɍX�V�p�����[�g�I�u�W�F�N�g
        // �f�[�^�Z�b�g�֘A
        private GridMainDataSet.GridMainTableDataTable _gridMainTable = null;   // UOE���ɍX�V���C��
        private HeaderGridDataSet _headerDataSet = null;                        // UOE���ɍX�V�w�b�_�[
        private DetailGridDataSet _detailDataSet = null;                        // UOE���ɍX�V����
        // HashTable
        private Hashtable _supplierHTable = null;               // �d����}�X�^(key�F�d����R�[�h)
        private Hashtable _uoeOrderDtlWorkHTable = null;        // UOE�����f�[�^(key�F�d�����גʔ�)
        private Hashtable _stockSlipWorkHTable = null;          // �d���f�[�^(key�F�d���`�[�ԍ�)
        private Hashtable _stockDetailWorkHTable = null;        // �d�����׃f�[�^(key�F�d�����גʔ�)
        private Hashtable _uoeSupplierHTable = null;            // UOE������}�X�^(key�FUOE������R�[�h)        //ADD 2009/01/19 �s��Ή�[10063]
        // ���̑�
        private string _enterpriseCode;                         // ��ƃR�[�h
        private int _prevHeaderRowNo = -1;                      // ���ݑI������Ă���w�b�_�[�sNo.
        private bool _stockingPaymentOption = false;            // ���|�I�v�V����
        private int _stockBlnktPrtNoDiv;                        // UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪
        private bool _meiJiDiv = false;                         // �����Y�Ƌ敪�@ADD ����� 2013/05/16 Redmine#35459

        private UOEStockUpdSearchWork _searchBackup = null;     //ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\�������
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
        private string _loginSectionCode = string.Empty;// ���O�C�����_�R�[�h

        private TaxRateSet _taxRateSet;
        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        private StockProcMoneyAcs _stockProcMoneyAcs;   // �P���Z�o�N���X�A�N�Z�X�N���X
        private UnitPriceCalculation _unitPriceCalculation;
        private List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
        private List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
        private List<RateProtyMng> _rateProtyMngAllList = null;                                 // �|���D�揇�ʏ�񃊃X�g�i�S���j
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
        #endregion

        #region ��UOEOrderDtlInfo�\����
        /// <summary>
        /// UOE��������@�\����
        /// </summary>
        public struct UOEOrderDtlInfo
        {
            /// <summary> �A�Z���u��ID </summary>
            public string CommAssemblyId;
            /// <summary> �����於�� </summary>
            public string UOESupplierName;
        }
        # endregion

        #region ���f���Q�[�g
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);
		#endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
		# region ��Constracter
		/// <summary>
		/// �R���X�g���N�^
        /// </summary>
        /// <remarks>
		/// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01203AA()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���|�I�v�V�������擾����
            this._stockingPaymentOption = this.CheckOption();

            // �I�t���C���`�F�b�N
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
                return;
            }

            // �A�N�Z�X�N���X�C���X�^���X��
            string msg = string.Empty;
            this._goodsAcs = new GoodsAcs();                                // ���i�}�X�^�A�N�Z�X�N���X
            this._goodsAcs.IsGetSupplier = true;// ADD wangf 2012/11/15 FOR Redmine#31980
            this._goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            if (LoginInfoAcquisition.Employee != null)
            {
                Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._loginSectionCode = loginEmployee.BelongSectionCode.Trim();
            }
            this._taxRateSetAcs = new TaxRateSetAcs();

            int status;

            try
            {
                // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            ReadInitData();
            SearchRateProtyMng();
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            // ���ɍX�V�p�����[�g�I�u�W�F�N�g�擾
            this._iUOEStockUpdateDB = (IUOEStockUpdateDB)MediationUOEStockUpdateDB.GetUOEStockUpdateDB();

            // �\��DataSet�C���X�^���X��(�f�[�^�Ȃ��A�O���b�h���C�A�E�g�ݒ�̂�)
            this._headerDataSet = new HeaderGridDataSet();      // �w�b�_�[�O���b�h�p
            this._detailDataSet = new DetailGridDataSet();      // ���׃O���b�h�p

            // �d����f�[�^HashTable�쐬
            this.CreateSupplierHTable();

            // UOE������f�[�^HashTable�쐬
            this.CreateUOESupplierHTable();                     //ADD 2009/01/19 �s��Ή�[10063]
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N
        // ===================================================================================== //
        // �v���p�e�B
        /// <summary> UOE���ɍX�V�w�b�_�[�f�[�^ </summary>
        public HeaderGridDataSet UOEEnterUpdHeaderDataSet { get { return this._headerDataSet; } }
        /// <summary> UOE���ɍX�V���׃f�[�^ </summary>
        public DetailGridDataSet UOEEnterUpdDetailDataSet { get { return this._detailDataSet; } }
        /// <summary> UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪</summary>
        public int StockBlnktPrtNoDiv { set { this._stockBlnktPrtNoDiv = value; } }
        /// <summary> ���|�I�v�V���� </summary>
        public bool StockingPaymentOption { get { return this._stockingPaymentOption; } }

        #region ��SetSearchData(��������)
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="uoeEnterUpdCndtn">UOE�����f�[�^��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ɉ����Č������s���܂��B�擾�����f�[�^�����Ɋe��HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public int SetSearchData(UOEStockUpdSearch uoeStockUpdSearch)
        {
            // ������
            this.ClearUOEEnterUpdHeaderData();
            this.ClearUOEEnterUpdDetailData();

            // �����쐬
            UOEStockUpdSearchWork uoeStockUpdSearchWork = new UOEStockUpdSearchWork();
            uoeStockUpdSearchWork.EnterpriseCode = uoeStockUpdSearch.EnterpriseCode;
            uoeStockUpdSearchWork.SectionCode = uoeStockUpdSearch.SectionCode.Trim();
            uoeStockUpdSearchWork.ProcDiv = uoeStockUpdSearch.ProcDiv;
            uoeStockUpdSearchWork.UOESupplierCd = uoeStockUpdSearch.UOESupplierCd;
            uoeStockUpdSearchWork.SlipNo = uoeStockUpdSearch.SlipNo;

            // �f�[�^���o
            object retObject = new CustomSerializeArrayList();
            int status = this._iUOEStockUpdateDB.Search(uoeStockUpdSearchWork, ref retObject, 0, ConstantManagement.LogicalMode.GetData0);
            // --- �e�X�g�p�f�[�^(PMUOE01203AZ)�g�p�� --->>>>>
            //int status = 0;
            //DummyData.GetDummyData(ref retObject);
            // ------------------------------------------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.StatusBarMessageSetting(this, "�Y���f�[�^������܂���B");
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    this.StatusBarMessageSetting(this, "�f�[�^�̓Ǎ��Ɏ��s���܂����B");
                    return status;
            }

            CustomSerializeArrayList uoeStcUpdDataList = (CustomSerializeArrayList)retObject;
            if ((uoeStcUpdDataList == null) || (uoeStcUpdDataList.Count == 0))
            {
                this.StatusBarMessageSetting(this, "�Y���f�[�^������܂���B");
                return status;
            }

            this._searchBackup = uoeStockUpdSearchWork;         //ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\�������

            // �e��f�[�^��荞��
            for (int index = 0; index <= uoeStcUpdDataList.Count - 1; index++)
            {
                ArrayList arrayList = (ArrayList)uoeStcUpdDataList[index];
                if (arrayList.Count == 0)
                {
                    continue;
                }

                // �d���f�[�^��HashTable
                if (arrayList[0] is StockSlipWork)
                {
                    this.CreateStockSlipWorkHTable(arrayList);
                }
                // �d�����׃f�[�^��HashTable
                else if (arrayList[0] is StockDetailWork)
                {
                    this.CreateStockDetailWorkHTable(arrayList);
                }
                // UOE�����f�[�^��DataSet(�O���b�h�Ƃ̘A�g�̈�)
                else if (arrayList[0] is UOEOrderDtlWork)
                {
                    // �o�b�N�A�b�v(�X�V���Ɏg�p)
                    //this._uoeOrderDtlWorkList = arrayList;
                    this.CreateUOEOrderDtlWorkHTable(arrayList);

                    // UOE�����f�[�^���O���b�h���C���f�[�^
                    this.CreateGridMainTable(arrayList);
                    // �O���b�h���C���f�[�^��UOE���ɍX�V�w�b�_�[�p�f�[�^
                    this.CreateHeaderGridDataSet();

                    // �O���b�h���C���f�[�^��UOE���ɍX�V���חp�f�[�^
                    this.CreateDetailGridDataSet(0);
                }
            }

            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, "�f�[�^�𒊏o���܂����B");
            }
            return 0;
        }
        #endregion

        #region ��DecisionData(UOE���ɍX�V�m�菈��)
        /// <summary>
        /// UOE���ɍX�V�m�菈��(�{������PMUOE01203AB�ōs��)
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�������ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V�m�菈�����s���܂��B�f�[�^�̍쐬��PMUOE01203AB�N���X�ōs���B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        //public bool DecisionData(out string msg) // DEL 2009/02/02
        public int DecisionData(out string msg)
        {
            // �w�b�_�[�O���b�h��GridMain���f
            this.CopyToGridMainFromHeaderGrid();

            // �C���X�^���X�쐬
            this._decisionDataAcs = new PMUOE01203AB(this._enterpriseCode
                                                    , this._uoeOrderDtlWorkHTable
                                                    , this._gridMainTable
                                                    , this._stockSlipWorkHTable
                                                    , this._stockDetailWorkHTable
                                                    , this._supplierHTable);    // ���ɍX�V�m�菈����p�N���X

            // �v���p�e�B�Z�b�g
            this._decisionDataAcs.GoodsAcs = this._goodsAcs;                            // ���i�}�X�^�A�N�Z�X�N���X
            this._decisionDataAcs.StockingPaymentOption = this._stockingPaymentOption;  // ���|�I�v�V����
            this._decisionDataAcs.StockBlnktPrtNoDiv = this._stockBlnktPrtNoDiv;        // UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪       //ADD 2009/01/16 �s��Ή�[10145]
            this._decisionDataAcs.MeiJiDiv = this._meiJiDiv;                            // �����Y�Ƌ敪�@ADD ����� 2013/05/16 Redmine#35459

            // �f�[�^�쐬
            object uoeStcUpdDataList = this._decisionDataAcs.CreateUOEStcUpdDataList(out msg);
            if (uoeStcUpdDataList == null)
            {

                // �f�[�^�쐬���s
                //return false; // DEL 2009/02/02
                return -1; // ADD 2009/02/02
            }

            // �f�[�^�쐬����
            int status = this._iUOEStockUpdateDB.Write(ref uoeStcUpdDataList);

            // ---ADD 2009/02/17 -------------------------------------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                msg = "�X�V���ɃG���[���������܂����B " + "\r\n" + status.ToString();
            }
            // ---ADD 2009/02/17 --------------------------------------<<<<<

            //return true; // DEL 2009/02/02
            return status; // ADD 2009/02/02
        }
        #endregion

        // UOE���ɍX�V�f�[�^�֘A
        #region ��SaveDetailGrid(���׃O���b�h��UOE���ɍX�V���C���f�[�^���f)
        /// <summary>
        /// ���׃O���b�h��UOE���ɍX�V���C���f�[�^���f
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�̓��e��UOE���ɍX�V���C���f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void SaveDetailGrid()
        {
            // ���׃O���b�h��GridMain���f
            this.CopyToGridMainFromDetailGrid();
        }
        #endregion

        // �d����f�[�^�֘A
        #region ��GetSupplierName(�d���於�̎擾)
        /// <summary>
        /// �d���於�̎擾
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierName">�d���於��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�����Ɏd���於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool GetSupplierName(int supplierCd, out string supplierName)
        {
            return this.GetSupplierNameFromSupplierHTable(supplierCd, out supplierName);
        }
        #endregion

        // ---ADD 2009/01/19 �s��Ή�[10063] ------------------------------------------------------->>>>>
        // UOE������f�[�^�֘A
        #region ��GetUOESupplierName(UOE�����於�̎擾)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="supplierCd">UOE������R�[�h</param>
        /// <param name="supplierName">UOE�����於��</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public bool GetUOESupplierName(int uoeSupplierCd, out string uoeSupplierName)
        {
            return this.GetUOESupplierNameFromUOESupplierHTable(uoeSupplierCd, out uoeSupplierName);
        }
        #endregion
        // ---ADD 2009/01/19 �s��Ή�[10063] -------------------------------------------------------<<<<<

        // �O���b�h�p
        #region ��ClearUOEEnterUpdHeaderData(�w�b�_�[�O���b�h�f�[�^�N���A)
        /// <summary>
        /// �w�b�_�[�O���b�h�f�[�^�N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�O���b�h�̃f�[�^���N���A���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void ClearUOEEnterUpdHeaderData()
        {
            this._headerDataSet.HeaderTable.Rows.Clear();
            this._prevHeaderRowNo = -1;
        }
        #endregion

        #region ��HeaderGridTotalDisplay(�w�b�_�[�O���b�h���v�ݒ�)
        /// <summary>
        /// �w�b�_�[�O���b�h���v�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�f�[�^����w�b�_�[�O���b�h�̍��v���Z�o���A�\�����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void HeaderGridTotalDisplay()
        {
            // ���׃O���b�h�̓��e�����ɍ��v���Z�o
            Double total = 0;
            DetailGridDataSet.DetailTableRow detailRow = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                detailRow = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];
                total = total + (detailRow.InputEnterCnt * detailRow.InputAnswerSalesUnitCost);
            }

            // �Z�o�������v��\��
            HeaderGridDataSet.HeaderTableRow headerRow = (HeaderGridDataSet.HeaderTableRow)this._headerDataSet.HeaderTable.Rows[this._prevHeaderRowNo];
            headerRow.Total = total;
        }
        #endregion

        #region ��ClearUOEEnterUpdDetailData(���׃O���b�h�f�[�^�N���A)
        /// <summary>
        /// ���׃O���b�h�f�[�^�N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�̃f�[�^���N���A���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void ClearUOEEnterUpdDetailData()
        {
            this._detailDataSet.DetailTable.Rows.Clear();
        }
        #endregion

        #region ��DetailGridDivCdDisplayAll(���׃O���b�h�敪���ڐݒ�)
        /// <summary>
        /// ���׃O���b�h�敪���ڐݒ�
        /// </summary>
        /// <param name="divCd">�w�b�_�[�O���b�h�őI�����ꂽ�敪</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽ�敪(�w�b�_�[�O���b�h�̋敪)�ɉ����Ė��׃O���b�h�̋敪���ڂ�ݒ肵�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void DetailGridDivCdDisplayAll(string divCd)
        {
            DetailGridDataSet.DetailTableRow row = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                row = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];       

                // �݌ɑ��ݎ��A���̂܂܂̒l
                if ((bool)row[this._detailDataSet.DetailTable.StockExistsColumn.ColumnName])
                {
                    row.DivCd = divCd;
                }
                else
                {
                    // �݌ɖ����ݎ��A�u9�F�����݁v�u���F�������v�͂��̂܂܂̒l
                    if ((divCd == PMUOE01202EA.DIVCD_DELETE) || (divCd == PMUOE01202EA.DIVCD_NOCHANGE))
                    {
                        row.DivCd = divCd;
                    }
                    else
                    {
                        row.DivCd = PMUOE01202EA.DIVCD_NOTENTER;        // �u2�F�����ׁv
                    }
                }
            }
        }
        #endregion

        #region ��DetailGridDataDisplay(���׃f�[�^�\��)
        /// <summary>
        /// ���׃f�[�^�\��
        /// </summary>
        /// <param name="headerRowNo">�w�b�_�[�O���b�h�őI�����ꂽ�s</param>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�O���b�h�őI�����ꂽ�s�ɉ����Ė��ׂ̕\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void DetailGridDataDisplay(int headerRowNo)
        {
            this.CreateDetailGridDataSet(headerRowNo);
        }
        #endregion

        #region ��CheckSlipNoIsNullOrEmpty(�`�[�ԍ����̓`�F�b�N)
        /// <summary>
        /// �`�[�ԍ����̓`�F�b�N
        /// </summary>
        /// <param name="errorRowNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��̓��̓`�F�b�N���s���܂��B(���ɁA�C�����͕K�{)</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool CheckSlipNoIsNullOrEmpty(out int errorRowNo)
        {
            errorRowNo = -1;

            // ���|�I�v�V�����Ȃ��̏ꍇ�A�������Ń`�F�b�NOK�Ƃ���
            if (this._stockingPaymentOption == false)
            {
                return true;
            }

            DataTable dataTable = this._headerDataSet.Tables[0];

            HeaderGridDataSet.HeaderTableRow headerRow = null;
            for (int index = 0; index <= dataTable.Rows.Count - 1; index++)
            {
                headerRow = (HeaderGridDataSet.HeaderTableRow)dataTable.Rows[index];
                if ((headerRow.DivCd == PMUOE01202EA.DIVCD_ENTER) || (headerRow.DivCd == PMUOE01202EA.DIVCD_UPDATE))
                {
                    if (string.IsNullOrEmpty(headerRow.SlipNo) == true)
                    {
                        errorRowNo = index;
                        return false;
                    }
                    // ---ADD 2009/01/16 -------------------------------------------------------------------->>>>>
                    /* ---DEL 2009/01/19 �����ύX��Ұ���AEO�ǉ� ---------------------------------->>>>>
                    if ((headerRow.SlipNo == "������ݺ޳ż") ||
                        (headerRow.SlipNo == "BO1��ݺ޳ż") ||
                        (headerRow.SlipNo == "BO2��ݺ޳ż") ||
                        (headerRow.SlipNo == "BO3��ݺ޳ż"))
                       ---DEL 2009/01/19 ---------------------------------------------------------<<<<< */
                    // ---ADD 2009/01/19 --------------------------------------------------------->>>>>
                    if ((headerRow.SlipNo == "��ݺ޳ż ����") ||
                        (headerRow.SlipNo == "��ݺ޳ż BO1") ||
                        (headerRow.SlipNo == "��ݺ޳ż BO2") ||
                        (headerRow.SlipNo == "��ݺ޳ż BO3") ||
                        (headerRow.SlipNo == "��ݺ޳ż Ұ��") ||
                        (headerRow.SlipNo == "��ݺ޳ż EO"))
                    // ---ADD 2009/01/19 ---------------------------------------------------------<<<<<
                    {
                        errorRowNo = index;
                        return false;
                    }
                    // ---ADD 2009/01/16 --------------------------------------------------------------------<<<<<
                }
            }

            return true;
        }
        #endregion

        // ---ADD 2009/02/05 �s��Ή�[10974] ------------------------------------------------------------------------------------------->>>>>
        #region ��CheckDayPayment(�����`�F�b�N)
        /// <summary>
        /// �����`�F�b�N
        /// </summary>
        /// <param name="errorRowNo"></param>
        /// <returns>0�F����A-1�F���������G���[�A-2�F���������G���[</returns>
        /// <remarks>
        /// <br>Note       : �����`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/02/05</br>
        /// <br>UpdateNote : 2015/01/21 ���t</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>             �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��(Redmine#44056)</br>
        /// </remarks>
        public int CheckDayPayment(out int errorRowNo)
        {
            errorRowNo = -1;

            int status = 0;
            DateTime prevTotalDay = DateTime.MinValue;

            StockSlipWork stockSlipWork = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            // �����Z�o���W���[��
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();

            // �敪���u���Ɂv�u���׏C���v�̂��̂𒊏o
            string filter = string.Format("({0} = '{1}') OR ({0} = '{2}')"
                                        , this._gridMainTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE);

            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            // ���|�I�v�V��������
            if (this._stockingPaymentOption == true)
            {
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                    if (this._stockSlipWorkHTable.ContainsKey(gridMainRow.SupplierSlipNo.ToString()) == false)
                    {
                        continue;
                    }

                    stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[gridMainRow.SupplierSlipNo.ToString()];

                    /* ---DEL 2009/02/23 --------------------------------------------------------------------->>>>>
                    // �d�������̒����擾
                    status = totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.PayeeCode, out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }

                    // �d�������̒����擾
                    status = totalDayCalculator.GetTotalDayPayment(stockSlipWork.PayeeCode, out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -2;
                    }
                       ---DEL 2009/02/23 ---------------------------------------------------------------------<<<<< */
                    // ----------------------- DEL ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��-------------------------------------->>>>>
                    // ---ADD 2009/02/23 --------------------------------------------------------------------->>>>>
                    //// �d�������̒����`�F�b�N
                    //if (totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // �d�������̒����擾
                    //    status = totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.PayeeCode, out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -1;
                    //    }
                    //}
                    //// �d�������̒����`�F�b�N
                    //if (totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // �d�������̒����擾
                    //    status = totalDayCalculator.GetTotalDayPayment(stockSlipWork.PayeeCode, out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -2;
                    //    }
                    //}
                    // ---ADD 2009/02/23 ---------------------------------------------------------------------<<<<<
                    // ----------------------- DEL ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��--------------------------------------<<<<<
                    // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��-------------------------------------->>>>>
                    UOEOrderDtlWork uoeOrderData = this.GetUOEOrderData(gridMainRow);
                    if (uoeOrderData == null) return -1;
                    // �d�������̒����`�F�b�N
                    if (totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, uoeOrderData.ReceiveDate))
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                    // �d�������̒����`�F�b�N
                    if (totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, uoeOrderData.ReceiveDate))
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -2;
                    }
                    // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��--------------------------------------<<<<<
                }
            }
            // ���|�I�v�V�����Ȃ�
            else
            {
                totalDayCalculator.InitializeHisMonthlyAccPay();
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                    if (this._stockSlipWorkHTable.ContainsKey(gridMainRow.SupplierSlipNo.ToString()) == false)
                    {
                        continue;
                    }

                    stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[gridMainRow.SupplierSlipNo.ToString()];
                    /* ---DEL 2009/02/23 --------------------------------------------------------------------->>>>>
                    // ���㌎���̒����擾
                    status = totalDayCalculator.GetHisTotalDayMonthly(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                       ---DEL 2009/02/23 ---------------------------------------------------------------------<<<<< */
                    // ----------------------- DEL ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��-------------------------------------->>>>>
                    // ---ADD 2009/02/23 --------------------------------------------------------------------->>>>>
                    //// ���㌎���̒����`�F�b�N
                    //if (totalDayCalculator.CheckMonthlyAccRec(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // ���㌎���̒����擾
                    //    status = totalDayCalculator.GetHisTotalDayMonthly(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -1;
                    //    }
                    //}
                    // ---ADD 2009/02/23 ---------------------------------------------------------------------<<<<
                    // ----------------------- DEL ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��--------------------------------------<<<<<
                    // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��-------------------------------------->>>>>
                    UOEOrderDtlWork uoeOrderData = this.GetUOEOrderData(gridMainRow);
                    if (uoeOrderData == null) return -1;
                    // ���㌎���̒����擾
                    totalDayCalculator.ClearCache();
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    // ���㌎���̒����`�F�b�N
                    if (uoeOrderData.ReceiveDate <= prevTotalDay) 
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                    // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��--------------------------------------<<<<<
                }
            }

            return 0;
        }
        #endregion
        // ---ADD 2009/02/05 �s��Ή�[10974] -------------------------------------------------------------------------------------------<<<<<

        // ===================================================================================== //
        // �v���C�x�[�g
        // ===================================================================================== //
        // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��-------------------------------------->>>>>
        #region ��GetOrderDtlKey(UOE�����f�[�^�̃L�[�̔��f)
        /// <summary>
        /// �L�[�̔��f
        /// </summary>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="slipNo">�`�[�ԍ�</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �L�[���擾���܂��B</br>
        /// <br>Programmer : ���t</br>
        /// <br>Date       : 2015/01/21</br>
        /// </remarks>
        private string GetOrderDtlKey(string stockSlipDtlNum, string slipNo)
        {
            // �����Y�Ǝ�
            if (_meiJiDiv)
            {
                int slipNoInt = 0;
                Int32.TryParse(slipNo, out slipNoInt);
                return stockSlipDtlNum + slipNoInt.ToString().PadLeft(6, '0');
            }
            else
            {
                return stockSlipDtlNum;
            }
        }
        #endregion

        #region ��GetUOEOrderData(UOE�f�[�^�̎擾)
        /// <summary>
        /// UOE�f�[�^�̎擾
        /// </summary>
        /// <param name="mainRow">Grid�̍s</param>
        /// <returns>UOE�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE�f�[�^�̎擾</br>
        /// <br>Programmer : ���t</br>
        /// <br>Date       : 2015/01/21</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderData(GridMainDataSet.GridMainTableRow mainRow)
        {
            //UOE�����f�[�^(key�F�d�����גʔ�)
            UOEOrderDtlWork uoeOrderDtlWork = null;
            string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);
            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {  
                if (uoeOrderDtlKey == key)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                    break;
                }
            }
            return uoeOrderDtlWork;
        }
        #endregion
        // ----------------------- ADD ���t 2015/01/21 Redmine#44056 �݌ɓ��ɍX�V�Œ������`�F�b�N�̏C��--------------------------------------<<<<<

        #region ��CheckOption(�d���x���Ǘ��I�v�V�����`�F�b�N)
        /// <summary>
        /// �d���x���Ǘ��I�v�V�����`�F�b�N
        /// </summary>
        /// <returns>True�F�I�v�V����OK�AFalse�F�I�v�V����NG</returns>
        /// <remarks>
        /// <br>Note       : �d���x���Ǘ��I�v�V�����̒l�𔻒肵�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool CheckOption()
        {
            //PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);        //DEL 2009/01/14
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);      //ADD 2009/01/14
            return status >= PurchaseStatus.Contract;
        }
        #endregion

        // HashTable�쐬
        #region ��CreateUOEOrderDtlWorkHTable(UOE�����f�[�^HashTable�쐬)
        /// <summary>
        /// UOE�����f�[�^HashTable�쐬
        /// </summary>
        /// <param name="arrayList">UOE�����f�[�^</param>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�pHashTable�̍쐬���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 �����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/06/18�z�M��</br>
        /// <br>              Redmine#35459 #42�̑Ή�</br>
        /// </remarks>
        private void CreateUOEOrderDtlWorkHTable(ArrayList arrayList)
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            this._uoeOrderDtlWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
                // �����Y�Ƃ̔��f
                if (index == 0)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[0];
                    _meiJiDiv = this.IsMEIJI(uoeOrderDtlWork.SupplierCd);
                }
                // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<

                uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[index];

                // �L�[�쐬(�d�����גʔ�)
                //string key = string.Format("{0}", uoeOrderDtlWork.StockSlipDtlNum);   // DEL ����� 2013/05/16 Redmine#35459

                // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
                string key = string.Empty;
                if (_meiJiDiv)
                {
                    // �L�[�쐬(�d�����גʔ� + �o�הԍ�)
                    key = string.Format("{0}{1}", uoeOrderDtlWork.StockSlipDtlNum, uoeOrderDtlWork.UOESectionSlipNo.PadLeft(6, '0'));
                }
                else
                {
                    // �L�[�쐬(�d�����גʔ�)
                    key = string.Format("{0}", uoeOrderDtlWork.StockSlipDtlNum);
                }
                // ------------ADD ����� 2013/05/16 FOR Redmine#35459---------<<<<

                // �i�[
                if (this._uoeOrderDtlWorkHTable.ContainsKey(key) == false)
                {
                    this._uoeOrderDtlWorkHTable[key] = uoeOrderDtlWork;
                }
            }
        }
        #endregion

        #region ��CreateStockSlipWorkHTable(�d���f�[�^HashTable�쐬)
        /// <summary>
        /// �d���f�[�^HashTable�쐬
        /// </summary>
        /// <param name="arrayList">�d���f�[�^</param>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�pHashTable�̍쐬���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateStockSlipWorkHTable(ArrayList arrayList)
        {
            StockSlipWork stockSlipWork = null;

            this._stockSlipWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                stockSlipWork = (StockSlipWork)arrayList[index];

                // �L�[�쐬(�d���`�[�ԍ�)
                string key = string.Format("{0}", stockSlipWork.SupplierSlipNo);

                // �i�[
                if (this._stockSlipWorkHTable.ContainsKey(key) == false)
                {
                    this._stockSlipWorkHTable[key] = stockSlipWork;
                }
            }
        }
        #endregion

        #region ��CreateStockDetailWorkHTable(�d�����׃f�[�^HashTable�쐬)
        /// <summary>
        /// �d�����׃f�[�^HashTable�쐬
        /// </summary>
        /// <param name="arrayList">�d�����׃f�[�^</param>
        /// <remarks>
        /// <br>Note       : �d�����׃f�[�^�pHashTable�̍쐬���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/12/17 yangmj </br>
        /// <br>           : 10801804-00�A1��16���z�M���Aredmine#32926 PM�f�[�^�ƘA�g�����Ȃ��̑Ή�</br>
        /// </remarks>
        private void CreateStockDetailWorkHTable(ArrayList arrayList)
        {
            StockDetailWork stockDetailWork = null;

            this._stockDetailWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                stockDetailWork = (StockDetailWork)arrayList[index];

                // �L�[�쐬(�d�����גʔ�)
                string key = string.Format("{0}", stockDetailWork.StockSlipDtlNum);

                // �i�[
                if (this._stockDetailWorkHTable.ContainsKey(key) == false)
                {
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#32926--------->>>>
                    GridMainDataSet.GridMainTableRow mainRow = null;
                    DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
                    for (int idx = 0; idx <= dataRows.Length - 1; idx++)
                    {
                        mainRow = (GridMainDataSet.GridMainTableRow)dataRows[idx];

                        string ver = string.Empty;
                        if (GetUOESupplierVerFromUOESupplierHTable(mainRow.SupplierCd, out ver))
                        {
                            //�ڑ��o�[�W�����敪��"�V",UOERemark1�́u*D XXXX�v�̏ꍇ�A�q�ɏ��͋󔒂�ݒ肷��
                            if ((!string.IsNullOrEmpty(ver)) 
                                && (ver.Equals("1")) 
                                && (!string.IsNullOrEmpty(mainRow.UOERemark1) 
                                && mainRow.UOERemark1.Length >= 2 
                                && mainRow.UOERemark1.Substring(0, 2).Equals("*D")))
                            {
                                if (key.Equals(mainRow.StockSlipDtlNumSrc.ToString()))
                                {
                                    stockDetailWork.WarehouseCode = string.Empty;
                                    stockDetailWork.WarehouseName = string.Empty;
                                    stockDetailWork.WarehouseShelfNo = string.Empty;
                                }
                            }
                        }
                    }
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#32926---------<<<<<
                    this._stockDetailWorkHTable[key] = stockDetailWork;
                }
            }
        }
        #endregion

        // ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή� ---->>>>> 
        #region ��UpdBOSlipNo(BO�`�[�ԍ��ҏW����)
        /// <summary>
        /// �d����BO�`�[�ԍ��ҏW����
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE�����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �d����BO�`�[�ԍ��ɂ���āA�ʐMID��āA�u-F�v�̕ҏW�������s���B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2015/08/26</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00</br>
        /// <br>             Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�</br>
        /// </remarks>
        private void UpdBOSlipNo(ref UOEOrderDtlWork uoeOrderDtlWork)
        {
            // UOE�`�[�ԍ�
            string tempUOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
            // BO1�`�[�ԍ�
            string tempBOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
            // BO2�`�[�ԍ�
            string tempBOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
            // BO3�`�[�ԍ�
            string tempBOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;

            switch (uoeOrderDtlWork.CommAssemblyId.Trim())
            {
                // �z���_ e-Parts�u�ʐMID�F0502�v�̏ꍇ
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            uoeOrderDtlWork.BOSlipNo1 = tempBOSlipNo1 + "-F";
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                uoeOrderDtlWork.BOSlipNo2 = tempBOSlipNo2 + "-F2";
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                uoeOrderDtlWork.BOSlipNo3 = tempBOSlipNo3 + "-F3";
                            }
                        }

                        break;
                    }
                // �z���_ e-Parts�u�ʐMID�F0502�v�ȊO�̏ꍇ
                default:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                uoeOrderDtlWork.BOSlipNo1 = tempBOSlipNo1 + "-F";
                            }
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                uoeOrderDtlWork.BOSlipNo2 = tempBOSlipNo2 + "-F2";
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                uoeOrderDtlWork.BOSlipNo3 = tempBOSlipNo3 + "-F3";
                            }
                        }

                        break;
                    }
            }
        }
        #endregion
        // ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή� ----<<<<<

        // �O���b�h���C���f�[�^�쐬
        #region ��CreateGridMainTable(UOE���ɍX�V���C���f�[�^�쐬)
        /// <summary>
        /// UOE���ɍX�V���C���f�[�^�쐬
        /// </summary>
        /// <param name="uoeOrderDtlTable">UOE�����f�[�^</param>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^����UOE���ɍX�V���C���f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
        /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
        /// <br>Update Note: 2012/12/17 yangmj </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>Update Note: 2015/08/26 �v�� </br>
        /// <br>           : 11170129-00�ARedmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�</br>
        /// </remarks>
        private void CreateGridMainTable(ArrayList arrayList)
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            // UOE���ɍX�V���C���e�[�u���C���X�^���X�쐬
            this._gridMainTable = new GridMainDataSet.GridMainTableDataTable();

            // �`�[�ԍ��P�ʂɓW�J
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[index];

                // ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή� ---->>>>> 
                UOEOrderDtlWork tempUoeOrderDtlWork = new UOEOrderDtlWork();
                tempUoeOrderDtlWork.UOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
                tempUoeOrderDtlWork.CommAssemblyId = uoeOrderDtlWork.CommAssemblyId;
                tempUoeOrderDtlWork.BOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
                tempUoeOrderDtlWork.BOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
                tempUoeOrderDtlWork.BOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;
                // �d����BO�`�[�ԍ��ҏW����
                UpdBOSlipNo(ref tempUoeOrderDtlWork);
                // ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή� ----<<<<<

                #region UOE���_�`�[�ԍ�
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.UOESectionSlipNo) == false)          //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivSec == 0)                                        //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_SECTION;                              // ��敪
                    gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // �`�[�ԍ�
                    gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = 0;                                          // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // ���ɐ�(���͗p)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "������ݺ޳ż";      //DEL 2009/01/19 �����ύX
                        gridMainRow.SlipNo = "��ݺ޳ż ����";       //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO�`�[�ԍ�1
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo1) == false)                 //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO1 == 0)                                        //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO1;                                  // ��敪
                    // gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo1;                         // �`�[�ԍ� // DEL BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo1;                         // �`�[�ԍ�// ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // ���ɐ�(���͗p)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO1��ݺ޳ż";       //DEL 2009/01/19 �����ύX
                        gridMainRow.SlipNo = "��ݺ޳ż BO1";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO�`�[�ԍ�2
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo2) == false)                 //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO2 == 0)                                        //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO2;                                  // ��敪
                    //gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo2;                         // �`�[�ԍ�// DEL BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo2;                         // �`�[�ԍ�// ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // ���ɐ�(���͗p)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO2��ݺ޳ż";       //DEL 2009/01/19 �����ύX
                        gridMainRow.SlipNo = "��ݺ޳ż BO2";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO�`�[�ԍ�3
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo3) == false)                 //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO3 == 0)                                        //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO3;                                  // ��敪
                    //gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo3;                         // �`�[�ԍ�// DEL BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo3;                         // �`�[�ԍ�// ADD BY �v�� 2015/08/26 Redmine#47030 �y��332�z�݌ɓ��ɍX�V�̏�Q�Ή�
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // ���ɐ�(���͗p)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO3��ݺ޳ż";       //DEL 2009/01/19 �����ύX
                        gridMainRow.SlipNo = "��ݺ޳ż BO3";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region Ұ��
                //if (uoeOrderDtlWork.MakerFollowCnt != 0)                                      //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivMaker == 0)                                      //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_MAKER;                                // ��敪
                    //gridMainRow.SlipNo = "";                                                // �`�[�ԍ�(�X�y�[�X)     //DEL 2009/01/19
                    gridMainRow.SlipNo = "��ݺ޳ż Ұ��";                                   // �`�[�ԍ�(�X�y�[�X)       //ADD 2009/01/19
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // ���ɐ�(���͗p)

                    // ---ADD 2009/01/19 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                    }
                    // ---ADD 2009/01/19 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region EO
                //if (uoeOrderDtlWork.EOAlwcCount != 0)                                         //DEL 2009/01/15 �s��Ή�[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivEO == 0)                                         //ADD 2009/01/15
                {
                    // ���ʕ��R�s�[
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_EO;                                   // ��敪
                    //gridMainRow.SlipNo = "";                                                // �`�[�ԍ�(�X�y�[�X)     //DEL 2009/01/19
                    gridMainRow.SlipNo = "��ݺ޳ż EO";                                     // �`�[�ԍ�(�X�y�[�X)       //ADD 2009/01/19
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO�o�ɐ�
                    gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // ���ɐ�
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // ���ɐ�(���͗p)

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion
            }
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            Dictionary<string, Double> stockUnitPriceDic = new Dictionary<string,double>();       // �J���[���

            this._unitPriceCalculation.CacheRateProtyMngAllList(_rateProtyMngAllList);
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    string keyUnitPrice = unitPriceCalcRetWk.GoodsMakerCd.ToString() + unitPriceCalcRetWk.GoodsNo;
                    if (!stockUnitPriceDic.ContainsKey(keyUnitPrice))
                    {
                        stockUnitPriceDic.Add(keyUnitPrice, unitPriceCalcRetWk.UnitPriceTaxExcFl);
                    }
                }
            }
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

            #region �e�O���b�h�p�sNo.�t��
            int headerGridRowNo = 0;
            int detailGridRowNo = 0;
            String key = string.Empty;
            String keyPrice = string.Empty;// ADD wangf 2012/11/15 FOR Redmine#31980

            GridMainDataSet.GridMainTableRow mainRow = null;
            DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                keyPrice = mainRow.GoodsMakerCd.ToString() + mainRow.GoodsNo; // ADD wangf 2012/11/15 FOR Redmine#31980
                if (key == string.Empty)
                {
                    // 1����
                    mainRow.HeaderGridRowNo = headerGridRowNo;       // �w�b�_�[�O���b�h�p�sNo.
                    mainRow.DetailGridRowNo = detailGridRowNo;       // ���׃O���b�h�p�sNo.
                    key = mainRow.OnlineNo + mainRow.SlipNo;

                    // ------------ADD yangmj 2012/12/17 FOR Redmine#31980--------->>>>
                    if (stockUnitPriceDic.ContainsKey(keyPrice))
                    {
                        // �����P���i���i�}�X�^���j
                        mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                    }
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#31980---------<<<<
                    continue;
                }

                if (key != (mainRow.OnlineNo + mainRow.SlipNo))
                {
                    // �`�[�ԍ����ς������
                    headerGridRowNo++;
                }
                detailGridRowNo++;

                mainRow.HeaderGridRowNo = headerGridRowNo;           // �w�b�_�[�O���b�h�p�sNo.
                mainRow.DetailGridRowNo = detailGridRowNo;           // ���׃O���b�h�p�sNo.

                key = mainRow.OnlineNo + mainRow.SlipNo;
           		 // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                if (stockUnitPriceDic.ContainsKey(keyPrice))
                {
                    // �����P���i���i�}�X�^���j
                    mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                }
           		 // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            }
            #endregion
        }
        #endregion

        #region ��CopyToGridMainRowFromUOEOrderDtlRow(UOE�����f�[�^��UOE���ɍX�V���C���f�[�^���f)
        /// <summary>
        /// UOE�����f�[�^��UOE���ɍX�V���C���f�[�^���f
        /// </summary>
        /// <param name="uoeOrderDtlRow">UOE�����f�[�^</param>
        /// <returns>UOE���ɍX�V���C���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̓��e��UOE���ɍX�V���C���f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
        /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
        /// </remarks>
        private GridMainDataSet.GridMainTableRow CopyToGridMainRowFromUOEOrderDtlWorkRow(UOEOrderDtlWork uoeOrderDtlWorkRow)
        {
            GridMainDataSet.GridMainTableRow gridMainRow = this._gridMainTable.NewGridMainTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // �敪(" "�F�������A"1"�F���ׁA"2"�F�����ׁA"3"�F�C���A"9"�F������)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // ���[�J�[�R�[�h
            gridMainRow.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // �i��
            gridMainRow.GoodsName = uoeOrderDtlWorkRow.GoodsName;                       // �i��
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWorkRow.UOESalesOrderNo;           // UOE�����ԍ�
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWorkRow.UOESalesOrderRowNo;     // UOE�����s�ԍ�
            gridMainRow.OnlineNo = uoeOrderDtlWorkRow.OnlineNo;                         // �I�����C���ԍ�
            gridMainRow.OnlineRowNo = uoeOrderDtlWorkRow.OnlineRowNo;                   // �I�����C���s�ԍ�
            gridMainRow.WarehouseCode = uoeOrderDtlWorkRow.WarehouseCode;               // �q�ɃR�[�h
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWorkRow.WarehouseShelfNo;         // �I��
            gridMainRow.SalesUnitCost = uoeOrderDtlWorkRow.SalesUnitCost;               // �����P��
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerPartsNo = uoeOrderDtlWorkRow.AnswerPartsNo;               // �񓚕i��
            gridMainRow.UOERemark1 = uoeOrderDtlWorkRow.UoeRemark1;                     // ���}�[�N1
            gridMainRow.UOERemark2 = uoeOrderDtlWorkRow.UoeRemark2;                     // ���}�[�N2
            gridMainRow.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // �d����R�[�h
            gridMainRow.SubstPartsNo = uoeOrderDtlWorkRow.SubstPartsNo;                 // ��֕i��
            gridMainRow.SupplierSlipNo = uoeOrderDtlWorkRow.SupplierSlipNo;             // �d���`�[�ԍ�
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWorkRow.StockSlipDtlNum;        // �d�����גʔ�
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE���ɍX�V�w�b�_�[�O���b�h�p�s�ԍ�
            gridMainRow.DetailGridRowNo = 0;                                            // UOE���ɍX�V���׃O���b�h�p�s�ԍ�
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerMakerCd = uoeOrderDtlWorkRow.AnswerMakerCd;               // �񓚃��[�J�[�R�[�h
            gridMainRow.UOESupplierCd = uoeOrderDtlWorkRow.UOESupplierCd;               // UOE������R�[�h          //ADD 2009/01/19 �s��Ή�[10063]
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            gridMainRow.GoodspriceuSalesUnitCost = 0.0;                             

            GoodsUnitData unitData = new GoodsUnitData();
            unitData.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // ���i���[�J�[�R�[�h
            unitData.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // ���i�ԍ�
            unitData.GoodsRateRank = uoeOrderDtlWorkRow.GoodsRateRank;               // ���i�|�������N
            unitData.BLGoodsCode = uoeOrderDtlWorkRow.BLGoodsCode;                   // BL���i�R�[�h
            unitData.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // �d����R�[�h
            unitData.TaxationDivCd = uoeOrderDtlWorkRow.TaxationDivCd;               // �ېŋ敪
            unitData.SectionCode = uoeOrderDtlWorkRow.SectionCode;

            List<GoodsPrice> goodsPriceList;
            goodsPriceList = new List<GoodsPrice>();
            GoodsPrice goodsPrice = new GoodsPrice();
            goodsPrice.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;
            goodsPrice.ListPrice = uoeOrderDtlWorkRow.PriceListPrice;
            goodsPrice.PriceStartDate = TDateTime.LongDateToDateTime(uoeOrderDtlWorkRow.PriceStartDate);
            goodsPrice.StockRate = uoeOrderDtlWorkRow.StockRate;
            goodsPrice.EnterpriseCode = uoeOrderDtlWorkRow.EnterpriseCode;
            goodsPrice.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;
            goodsPrice.LogicalDeleteCode = 0; // �_���폜�敪
            goodsPrice.SalesUnitCost = uoeOrderDtlWorkRow.GoodspriceuSalesUnitCost;
            goodsPriceList.Add(goodsPrice);
            unitData.GoodsPriceList = goodsPriceList;
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = unitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = unitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = unitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = unitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = unitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = unitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = unitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = unitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = unitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = unitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            goodsUnitDataList.Add(unitData);
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

            return gridMainRow;
        }
        #endregion

        #region ��CopyToGridMainFromHeaderGrid(�w�b�_�[�O���b�h�f�[�^��UOE���ɍX�V���C���f�[�^���f)
        /// <summary>
        /// �w�b�_�[�O���b�h�f�[�^��UOE���ɍX�V���C���f�[�^���f
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_�[�O���b�h�f�[�^�̓��e��UOE���ɍX�V���C���f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CopyToGridMainFromHeaderGrid()
        {
            GridMainDataSet.GridMainTableRow mainRow = null;
            HeaderGridDataSet.HeaderTableRow headerGridRow = null;
            for (int index = 0; index <= this._gridMainTable.Rows.Count - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)this._gridMainTable.Rows[index];

                DataView dv = new DataView(this._headerDataSet.HeaderTable);
                dv.Sort = "No";

                // ���o
                int index2 = dv.Find(mainRow.HeaderGridRowNo);
                // ---ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������� ---------------->>>>>
                if (index2 == -1)
                {
                    continue;
                }
                // ---ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������� ----------------<<<<<

                headerGridRow = (HeaderGridDataSet.HeaderTableRow)this._headerDataSet.HeaderTable.Rows[index2];

                mainRow.InputSlipNo = headerGridRow.SlipNo;     // �`�[�ԍ�
            }
        }
        #endregion

        #region ��CopyToGridMainFromDetailGrid(���׃O���b�h�f�[�^��UOE���ɍX�V���C���f�[�^���f)
        /// <summary>
        /// ���׃O���b�h�f�[�^��UOE���ɍX�V���C���f�[�^���f
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�f�[�^�̓��e��UOE���ɍX�V���C���f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CopyToGridMainFromDetailGrid()
        {
            GridMainDataSet.GridMainTableRow mainRow = null;
            DetailGridDataSet.DetailTableRow detailGridRow = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                detailGridRow = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];
                // �Ή�����s�擾
                mainRow = this._gridMainTable.FindBySupplierCdSlipNoOnlineNoOnlineRowNo(detailGridRow.SupplierCd, detailGridRow.SlipNo, detailGridRow.OnlineNo, detailGridRow.OnlineRowNo);

                mainRow.DivCd = detailGridRow.DivCd;                                            // �敪
                mainRow.InputEnterCnt = detailGridRow.InputEnterCnt;                            // ���ɐ�(���͒l)
                mainRow.InputAnswerSalesUnitCost = detailGridRow.InputAnswerSalesUnitCost;      // �����P��(���͒l)
            }
        }
        #endregion

        #region ��GetGridMainTableSortCondition(UOE���ɍX�V���C���f�[�^�p�\�[�g�����擾)
        /// <summary>
        /// UOE���ɍX�V���C���f�[�^�p�\�[�g�����擾
        /// </summary>
        /// <returns>�\�[�g����</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^�p�̃\�[�g�������擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private string GetGridMainTableSortCondition()
        {
            // �d����A�`�[�ԍ��A�I�����C���ԍ��A�I�����C���s�ԍ��̏�
            string sortCondition = string.Empty;
            sortCondition = string.Format("{0},{1},{2},{3}"
                                    //, this._gridMainTable.SupplierCdColumn.ColumnName             //DEL 2009/01/19 �s��Ή�[10063]
                                    , this._gridMainTable.UOESupplierCdColumn.ColumnName            //ADD 2009/01/19
                                    , this._gridMainTable.SlipNoColumn.ColumnName
                                    , this._gridMainTable.OnlineNoColumn.ColumnName
                                    , this._gridMainTable.OnlineRowNoColumn.ColumnName);
            return sortCondition;
        }
        #endregion

        // �w�b�_�[�p�f�[�^�쐬
        #region ��CreateHeaderGridDataSet(�w�b�_�[�O���b�h�f�[�^�쐬)
        /// <summary>
        /// �w�b�_�[�O���b�h�f�[�^�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^����w�b�_�[�O���b�h�f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateHeaderGridDataSet()
        {
            // �f�[�^�N���A
            this.ClearUOEEnterUpdHeaderData();

            // �\�[�g���s���A���̏��ԂɃw�b�_�[�f�[�^��ǉ�
            int key = -1;
            HeaderGridDataSet.HeaderTableRow headerRow = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            //DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());      //DEL 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\�������
            // ---ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������� ---------------->>>>>
            string filter = string.Empty;
            if (string.IsNullOrEmpty(this._searchBackup.SlipNo.TrimEnd()) == false)
            {
                filter = string.Format("{0}='{1}'", this._gridMainTable.SlipNoColumn.ColumnName, this._searchBackup.SlipNo.TrimEnd());
            }
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            // ---ADD 2009/02/18 ���[���A�w�肳�ꂽ�`�[�ԍ��̖��ׂ̂ݕ\������� ----------------<<<<<
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                if (key != gridMainRow.HeaderGridRowNo)
                {
                    // �w�b�_�[�f�[�^�擾
                    headerRow = this.CopyToHeaderGridFromGridMain(gridMainRow);

                    // ���v�擾
                    double total = this.CaluclateTotalFromGridMainTable(gridMainRow.HeaderGridRowNo);
                    headerRow.Total = total;

                    this._headerDataSet.HeaderTable.Rows.Add(headerRow);
                }

                key = gridMainRow.HeaderGridRowNo;
            }
        }
        #endregion

        #region ��CopyToHeaderGridFromGridMain(UOE���ɍX�V���C���f�[�^���w�b�_�[�O���b�h�f�[�^���f)
        /// <summary>
        /// UOE���ɍX�V���C���f�[�^���w�b�_�[�O���b�h�f�[�^���f
        /// </summary>
        /// <param name="mainRow">UOE���ɍX�V���C���f�[�^</param>
        /// <returns>�w�b�_�[�O���b�h�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^�̓��e���w�b�_�[�O���b�h�f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private HeaderGridDataSet.HeaderTableRow CopyToHeaderGridFromGridMain(GridMainDataSet.GridMainTableRow mainRow)
        {
            HeaderGridDataSet.HeaderTableRow headerRow = this._headerDataSet.HeaderTable.NewHeaderTableRow();

            headerRow.No = mainRow.HeaderGridRowNo;     // �w�b�_�[�sNo.
            headerRow.DivCd = mainRow.DivCd;            // �敪
            headerRow.SlipNo = mainRow.SlipNo;          // �`�[�ԍ�
            headerRow.Remark = mainRow.UOERemark1;      // ���}�[�N
            headerRow.Total = 0;                        // ���v

            return headerRow;
        }
        #endregion

        // ���חp�f�[�^�쐬
        #region ��CreateDetailGridDataSet(���׃O���b�h�f�[�^�쐬)
        /// <summary>
        /// ���׃O���b�h�f�[�^�쐬
        /// </summary>
        /// <param name="headerRowNo">�w�b�_�[�O���b�h�s�ԍ�</param>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^���疾�׃O���b�h�f�[�^���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateDetailGridDataSet(int headerRowNo)
        {
            // �O��Ɠ����s�̏ꍇ�͏��������Ȃ�
            if (headerRowNo == this._prevHeaderRowNo)
            {
                return;
            }

            // ����ȊO�͓��͒l��ۑ�
            if (this._prevHeaderRowNo != -1)
            {
                this.CopyToGridMainFromDetailGrid();
            }

            // �f�[�^�N���A
            this.ClearUOEEnterUpdDetailData();

            // ���o
            DetailGridDataSet.DetailTableRow detailRow = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, headerRowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // ���׃f�[�^�ǉ�
                detailRow = this.CopyToDetailGridFromGridMain(gridMainRow);
                this._detailDataSet.DetailTable.Rows.Add(detailRow);
            }

            this._prevHeaderRowNo = headerRowNo;
        }
        #endregion

        #region ��CopyToGridDetailFromGridMain(UOE���ɍX�V���C���f�[�^��UOE���ɍX�V���חp�f�[�^���f)
        /// <summary>
        /// UOE���ɍX�V���C���f�[�^�����׃O���b�h�f�[�^���f
        /// </summary>
        /// <param name="gridMainRow">UOE���ɍX�V���C���f�[�^</param>
        /// <returns>���׃O���b�h�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^�̓��e�𖾍׃O���b�h�f�[�^�ɔ��f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
        /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
        /// </remarks>
        private DetailGridDataSet.DetailTableRow CopyToDetailGridFromGridMain(GridMainDataSet.GridMainTableRow gridMainRow)
        {
            DetailGridDataSet.DetailTableRow detailRow = this._detailDataSet.DetailTable.NewDetailTableRow();

            detailRow.No = gridMainRow.DetailGridRowNo;                                 // ���׍sNo.
            detailRow.DivCd = gridMainRow.DivCd;                                        // �敪
            detailRow.EnterCnt = gridMainRow.EnterCnt;                                  // ���ɐ�
            detailRow.GoodsName = gridMainRow.GoodsName;                                // �i��
            detailRow.GoodsNo = gridMainRow.GoodsNo;                                    // �i��
            detailRow.WarehouseCode = gridMainRow.WarehouseCode;                        // �q�ɃR�[�h
            detailRow.SectionCnt = gridMainRow.UOESectOutGoodsCnt;                      // ��
            detailRow.BOCnt = gridMainRow.BOShipmentCnt;                                // BO��
            detailRow.SalesUnitCost = gridMainRow.SalesUnitCost;                        // ���P��
            detailRow.AnswerSalesUnitCost = gridMainRow.AnswerSalesUnitCost;            // �񓚌��P��
            detailRow.SubstPartsNo = gridMainRow.SubstPartsNo;                          // ��֕i��
            detailRow.SupplierCd = gridMainRow.SupplierCd;                              // �d����R�[�h
            detailRow.SlipNo = gridMainRow.SlipNo;                                      // �[�iNo,
            detailRow.OnlineNo = gridMainRow.OnlineNo;                                  // �I�����C���ԍ�
            detailRow.OnlineRowNo = gridMainRow.OnlineRowNo;                            // �I�����C���s�ԍ�
            detailRow.AnswerPartsNo = gridMainRow.AnswerPartsNo;                        // �񓚕i��
            detailRow.InputEnterCnt = gridMainRow.InputEnterCnt;                        // ���ɐ�(���͗p)
            detailRow.InputAnswerSalesUnitCost = gridMainRow.InputAnswerSalesUnitCost;  // �񓚌����P��(���͗p)
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            // ���P���i���i�}�X�^���j
            detailRow.GoodspriceuSalesUnitCost = gridMainRow.GoodspriceuSalesUnitCost;
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            /* ---DEL 2009/01/16 �s��Ή�[10145] ----------------------------------------------------->>>>>
            // ��֕i
            if (string.IsNullOrEmpty(detailRow.SubstPartsNo.TrimEnd()) == false)
            {
                detailRow.GoodsName = detailRow.SubstPartsNo;
            }
               ---DEL 2009/01/16 �s��Ή�[10145] -----------------------------------------------------<<<<< */
            // ---ADD 2009/01/16 �s��Ή�[10145] ----------------------------------------------------->>>>>
            // ��֕i(��֕i�ԍ̗p���̂�)
            if (this._stockBlnktPrtNoDiv == 0)
            {
                if (string.IsNullOrEmpty(detailRow.SubstPartsNo.TrimEnd()) == false)
                {
                    detailRow.GoodsNo = detailRow.SubstPartsNo;
                }
            }
            // ---ADD 2009/01/16 �s��Ή�[10145] -----------------------------------------------------<<<<<

            // �I��
            //if (gridMainRow.WarehouseCode == "0")                             //DEL 2009/02/17 �s��Ή�[11238]
            if (string.IsNullOrEmpty(gridMainRow.WarehouseCode.TrimEnd()))      //ADD 2009/02/17 �s��Ή�[11238]
            {
                detailRow.WarehouseShelfNo = "���";
            }
            else
            {
                detailRow.WarehouseShelfNo = gridMainRow.WarehouseShelfNo;
            }

            // �݌ɗL��
            detailRow.StockExists = this.CheckStockIsExists(gridMainRow);

            return detailRow;
        }
        #endregion

        // �d����p
        #region ��CreateUOEOrderDtlHTable(�d����HashTable�쐬)
        /// <summary>
        /// �d����HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateSupplierHTable()
        {
            ArrayList array = null;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.Search(out array, this._enterpriseCode);
            if (status != 0)
            {
                this._supplierHTable = null;
                return;
            }
            if (array == null)
            {
                this._supplierHTable = null;
                return;
            }

            // HashTable�쐬
            this._supplierHTable = new Hashtable();
            Supplier supplier = null;
            for (int index = 0; index <= array.Count - 1; index++)
            {
                supplier = (Supplier)array[index];
                if (this._supplierHTable.ContainsKey(supplier.SupplierCd) == false)
                {
                    this._supplierHTable[supplier.SupplierCd] = supplier;
                }
            }
        }
        #endregion

        #region ��GetSupplierNameFromSupplierHTable(�d���於�̎擾)
        /// <summary>
        /// �d���於�̎擾
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierName">�d���於��</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�����Ɏd����HashTable����d���於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool GetSupplierNameFromSupplierHTable(int supplierCd, out string supplierName)
        {
            supplierName = string.Empty;     // �Ȃ�
            if (this.HashTableIsNullOrEmpty(this._supplierHTable, supplierCd))
            {
                return false;
            }

            // HashTable���擾
            Supplier supplier = (Supplier)this._supplierHTable[supplierCd];
            supplierName = supplier.SupplierSnm;

            return true;
        }
        #endregion

        // ---ADD 2009/01/19 �s��Ή�[10063] ------------------------------------------------------------------------>>>>>
        //UOE������p
        #region ��CreateUOESupplierHTable(HashTable�쐬)
        /// <summary>
        /// UOE������}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private void CreateUOESupplierHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE������}�X�^�f�[�^�擾(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            // �ُ�
            if (status != 0)
            {
                this._uoeSupplierHTable = null;
                return;
            }
            // �f�[�^�Ȃ�
            if (retDataSet == null)
            {
                this._uoeSupplierHTable = null;
                return;
            }

            // HashTable�쐬
            this._uoeSupplierHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                int key = 0;
                int.TryParse(dataRow["UoeSupplierCd"].ToString(), out key);

                this._uoeSupplierHTable[key] = dataRow;
            }
        }
        #endregion


        #region ��GetUOESupplierNameFromUOESupplierHTable(UOE�����於�̎擾)
        /// <summary>
        /// UOE�����於�̎擾
        /// </summary>
        /// <param name="supplierCd">UOE������R�[�h</param>
        /// <param name="supplierName">UOE�����於��</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h�����Ɏd����HashTable����UOE�����於�̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool GetUOESupplierNameFromUOESupplierHTable(int uoeSupplierCd, out string uoeSupplierName)
        {
            uoeSupplierName = string.Empty;     // �Ȃ�
            if (this.HashTableIsNullOrEmpty(this._uoeSupplierHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTable���擾
            DataRow dataRow = (DataRow)this._uoeSupplierHTable[uoeSupplierCd];
            uoeSupplierName = dataRow["UOESupplierName"].ToString();

            return true;
        }
        #endregion
        // ---ADD 2009/01/19 �s��Ή�[10063] ------------------------------------------------------------------------<<<<<

        // ------------ADD yangmj 2012/12/17 FOR Redmine#32926--------->>>>
        #region ��GetUOESupplierVerFromUOESupplierHTable(UOE�����於�̎擾)
        /// <summary>
        /// �ڑ��o�[�W�����敪�擾
        /// </summary>
        /// <param name="supplierCd">UOE������R�[�h</param>
        /// <param name="uoeSupplierVer">�ڑ��o�[�W�����敪</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h�����Ɏd����HashTable����ڑ��o�[�W�����敪���擾���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/12/17</br>
        /// </remarks>
        private bool GetUOESupplierVerFromUOESupplierHTable(int uoeSupplierCd, out string uoeSupplierVer)
        {
            uoeSupplierVer = string.Empty;     // �Ȃ�
            if (this.HashTableIsNullOrEmpty(this._uoeSupplierHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTable���擾
            DataRow dataRow = (DataRow)this._uoeSupplierHTable[uoeSupplierCd];

            string stockSlipDtRecvDiv = dataRow["StockSlipDtRecvDiv"].ToString();
            string receiveCondition = dataRow["ReceiveCondition"].ToString();
            if ("1".Equals(stockSlipDtRecvDiv) && "1".Equals(receiveCondition))   // �d����M�敪(=1�F����j&& ���M�̂�
            {
                uoeSupplierVer = dataRow["ConnectVersionDiv"].ToString();
                return true;
            }

            return false;
        }
        #endregion
        // ------------ADD yangmj 2012/12/17 FOR Redmine#32926---------<<<<
        // ����
        #region ��CheckStockIsExists(�݌ɑ��݃`�F�b�N)
        /// <summary>
        /// �݌ɑ��݃`�F�b�N
        /// </summary>
        /// <param name="row">���C���e�[�u���s</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool CheckStockIsExists(GridMainDataSet.GridMainTableRow row)
        {
            /* ---DEL 2009/02/17 �s��Ή�[11238] ------------------------>>>>>
            if (row.WarehouseCode == "0")
            {
                return false;
            }
               ---DEL 2009/02/17 �s��Ή�[11238] ------------------------<<<<< */
            // ---ADD 2009/02/17 �s��Ή�[11238] ------------------------>>>>>
            if (string.IsNullOrEmpty(row.WarehouseCode))
            {
                return true;
            }
            // ---ADD 2009/02/17 �s��Ή�[11238] ------------------------<<<<<

            int goodsMakerCd = 0;
            string goodsNo = string.Empty;

            // 0�F��֕i�̗p��
            if (this._stockBlnktPrtNoDiv == 0)
            {
                // ��֕i�Ԃ��X�y�[�X�ȊO�̏ꍇ
                if (string.IsNullOrEmpty(row.SubstPartsNo.TrimEnd()) == false)
                {
                    goodsNo = row.SubstPartsNo;         // ��֕i��
                    goodsMakerCd = row.AnswerMakerCd;   // �񓚃��[�J�[�R�[�h
                }
                else
                {
                    goodsNo = row.GoodsNo;              // �i��
                    goodsMakerCd = row.GoodsMakerCd;    // ���[�J�[�R�[�h
                }
            }
            // 1�F�����i�̗p��
            else
            {
                goodsNo = row.GoodsNo;              // �i��
                goodsMakerCd = row.GoodsMakerCd;    // ���[�J�[�R�[�h
            }

            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            // ���o����
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = goodsMakerCd;
            goodsCndtn.GoodsNo = goodsNo;
            
            // ����
            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out msg);
            /* ---DEL 2009/01/15 �s��Ή�[10059] ---------------------------------------->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return true;        // ����
            }
            else
            {
                return false;       // �Ȃ�
            }
               ---DEL 2009/01/15 �s��Ή�[10059] ----------------------------------------<<<<< */
            // ---ADD 2009/01/15 �s��Ή�[10059] ---------------------------------------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return false;
            }
            // �֘A����݌ɏ��擾
            List<Stock> stockList = goodsUnitDataList[0].StockList;
            if (stockList == null)
            {
                return false;
            }
            if (stockList.Count == 0)
            {
                return false;
            }
            // ���o����
            string warehouseCode = row.WarehouseCode.TrimEnd();

            // ����(�݌ɏ�����ʂ̒l�ōi�荞��)
            Stock stock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, stockList);
            if (stock == null)
            {
                return false;
            }

            return true;
            // ---ADD 2009/01/15 �s��Ή�[10059] ----------------------------------------<<<<<
        }
        #endregion

        #region ��CaluclateTotalFromGridMainTable(���v�擾)
        /// <summary>
        /// ���v�擾
        /// </summary>
        /// <param name="headerRowNo">�w�b�_�[�O���b�h�s�ԍ�</param>
        /// <returns>�v�Z����</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V���C���f�[�^����w�b�_�[�O���b�h�̍��v�����߂܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private double CaluclateTotalFromGridMainTable(int headerRowNo)
        {
            // ���o
            Double total = 0;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, headerRowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());

            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // ���v
                total = total + (gridMainRow.InputEnterCnt * gridMainRow.InputAnswerSalesUnitCost);
            }

            return total;
        }
        #endregion

        #region ��CheckSupplierCdIsExists(�d���摶�݃`�F�b�N)
        /// <summary>
        /// �d���摶�݃`�F�b�N
        /// </summary>
        /// <param name="rowNo">�`�F�b�N�Ώۂ̃w�b�_�[�O���b�h�sNo</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^��̎d��������Ɏd����}�X�^���݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool CheckSupplierCdIsExists(int rowNo)
        {
            // ���|�I�v�V�����Ȃ��̏ꍇ�A�������Ń`�F�b�NOK�Ƃ���
            if (this._stockingPaymentOption == false)
            {
                return true;
            }

            // UOE�����f�[�^��̎d������擾
            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, rowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());

            int supplierCd = ((GridMainDataSet.GridMainTableRow)dataRows[0]).SupplierCd;

            // �d����}�X�^���݃`�F�b�N
            if (this.HashTableIsNullOrEmpty(this._supplierHTable, supplierCd))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ��HashTableIsNullOrDataNothing(HashTable�f�[�^���݃`�F�b�N)
        /// <summary>
        /// HashTable�f�[�^���݃`�F�b�N
        /// </summary>
        /// <param name="hashTable">�`�F�b�N�Ώ�HashTable</param>
        /// <param name="key">�`�F�b�N�Ώ�key</param>
        /// <returns>True:�f�[�^�Ȃ��AFalse:�f�[�^����</returns>
        /// <remarks>
        /// <br>Note       : Key�Ŏw�肳�ꂽ�f�[�^��HashTable�ɑ��݂��邩�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool HashTableIsNullOrEmpty(Hashtable hashTable, int key)
        {
            // �f�[�^������
            if (hashTable == null)
            {
                return true;
            }

            // INDEX�͈͊O
            if (hashTable.ContainsKey(key) == false)
            {
                return true;
            }
            return false;
        }
        #endregion

        // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
        #region ���P���擾����
        /// <summary>
        /// �P���Z�o�N���X�����f�[�^�Ǎ�����
        /// </summary>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// �|���D��Ǘ�����
        /// </summary>
        private void SearchRateProtyMng()
        {
            _rateProtyMngAllList = new List<RateProtyMng>();
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();

            bool nextdata;
            int totalcnt;
            string msg;
            ArrayList list;
            rateProtyMngAcs.Search(out list, out totalcnt, out nextdata, this._enterpriseCode, "", out msg);

            if (list != null)
            {
                _rateProtyMngAllList = new List<RateProtyMng>();
                _rateProtyMngAllList.AddRange((RateProtyMng[])list.ToArray(typeof(RateProtyMng)));

                // ���_�A�P����ށA�D�揇�ʂŃ\�[�g
                _rateProtyMngAllList.Sort(new RateProtyMngComparer());
            }
        }

        #endregion
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

        // ------------ADD ����� 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary>
        /// �����Y�Ƃ̔��f
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>�����Y�Ƃ̔��f����</returns>
        /// <remarks>
        /// <br>Note       : �����Y�Ƃ̔��f���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private bool IsMEIJI(int uoeSupplierCd)
        {
            //��������}�X�^
            //�@��M�L���敪�F���M�̂�
            //�A�d����M�敪�F����
            string ver = string.Empty;
            if (GetUOESupplierVerFromUOESupplierHTable(uoeSupplierCd, out ver))
            {
                return true;
            }

            return false;
        }
        // ------------ADD ����� 2013/05/16 FOR Redmine#35459----------<<<<

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
        // ===================================================================================== //
        // �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        // ===================================================================================== //
        # region ��Constracter
        /// <summary>
        /// �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="status">�������X�e�[�^�X�u0�F����  0�ȊO�F���s�v</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public PMUOE01203AA(string enterpriseCode, string sectionCode, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 

            try
            {
                //�@��ƃR�[�h���擾����
                this._enterpriseCode = enterpriseCode;

                // ���|�I�v�V�������擾����
                this._stockingPaymentOption = this.CheckOption();

                // �A�N�Z�X�N���X�C���X�^���X��
                string msg = string.Empty;
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.IsGetSupplier = true;
                status = this._goodsAcs.SearchInitial(this._enterpriseCode, sectionCode, out msg);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._taxRateSetAcs = new TaxRateSetAcs();
                // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, TaxRateCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._unitPriceCalculation = new UnitPriceCalculation();
                this._stockProcMoneyAcs = new StockProcMoneyAcs();

                // �P���Z�o�N���X�����f�[�^�Ǎ�����
                ReadInitData();
                
                // �|���D��Ǘ�����
                SearchRateProtyMng();

                // ���ɍX�V�p�����[�g�I�u�W�F�N�g�擾
                this._iUOEStockUpdateDB = (IUOEStockUpdateDB)MediationUOEStockUpdateDB.GetUOEStockUpdateDB();

                // �\��DataSet�C���X�^���X��(�f�[�^�Ȃ��A�O���b�h���C�A�E�g�ݒ�̂�)
                this._headerDataSet = new HeaderGridDataSet();      // �w�b�_�[�O���b�h�p
                this._detailDataSet = new DetailGridDataSet();      // ���׃O���b�h�p

                // �d����f�[�^HashTable�쐬
                this.CreateSupplierHTable();

                // UOE������f�[�^HashTable�쐬
                this.CreateUOESupplierHTableForHandy(sectionCode);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 
            }
        }
        # endregion

        /// <summary>
        /// UOE������}�X�^HashTable�쐬�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>UOE������}�X�^HashTable�쐬���ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^������HashTable���쐬���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int CreateUOESupplierHTableForHandy(string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                DataSet retDataSet = new DataSet();

                // UOE������}�X�^�f�[�^�擾(PMUOE09022A)
                UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
                status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, sectionCode);

                // �ُ�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._uoeSupplierHTable = null;
                    return status;
                }
                // �f�[�^�Ȃ�
                if (retDataSet == null)
                {
                    this._uoeSupplierHTable = null;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                // HashTable�쐬
                this._uoeSupplierHTable = new Hashtable();
                foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
                {
                    int key = 0;
                    int.TryParse(dataRow[UoeSupplierCd].ToString(), out key);

                    this._uoeSupplierHTable[key] = dataRow;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// UOE�����f�[�^��񌟍������i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="uoeEnterUpdCndtn">UOE�����f�[�^��������</param>
        /// <returns>�������ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : �����ɉ����Č������s���܂��B�擾�����f�[�^�����Ɋe��HashTable���쐬���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetSearchDataForHandy(UOEStockUpdSearch uoeStockUpdSearch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ������
                this.ClearUOEEnterUpdHeaderData();
                this.ClearUOEEnterUpdDetailData();

                // �����쐬
                UOEStockUpdSearchWork uoeStockUpdSearchWork = new UOEStockUpdSearchWork();
                uoeStockUpdSearchWork.EnterpriseCode = uoeStockUpdSearch.EnterpriseCode;
                uoeStockUpdSearchWork.SectionCode = uoeStockUpdSearch.SectionCode.Trim();
                uoeStockUpdSearchWork.ProcDiv = uoeStockUpdSearch.ProcDiv;
                uoeStockUpdSearchWork.UOESupplierCd = uoeStockUpdSearch.UOESupplierCd;

                // �f�[�^���o
                object retObject = new CustomSerializeArrayList();
                status = this._iUOEStockUpdateDB.Search(uoeStockUpdSearchWork, ref retObject, 0, ConstantManagement.LogicalMode.GetData0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                CustomSerializeArrayList uoeStcUpdDataList = (CustomSerializeArrayList)retObject;
                if ((uoeStcUpdDataList == null) || (uoeStcUpdDataList.Count == 0))
                {
                    return status;
                }

                this._searchBackup = uoeStockUpdSearchWork;

                ArrayList arrayList = null;
                // �e��f�[�^��荞��
                for (int index = 0; index <= uoeStcUpdDataList.Count - 1; index++)
                {
                    arrayList = (ArrayList)uoeStcUpdDataList[index];
                    if (arrayList.Count == 0)
                    {
                        continue;
                    }

                    // �d���f�[�^��HashTable
                    if (arrayList[0] is StockSlipWork)
                    {
                        this.CreateStockSlipWorkHTable(arrayList);
                    }
                    // �d�����׃f�[�^��HashTable
                    else if (arrayList[0] is StockDetailWork)
                    {
                        this.CreateStockDetailWorkHTable(arrayList);
                    }
                    // UOE�����f�[�^��DataSet(�O���b�h�Ƃ̘A�g�̈�)
                    else if (arrayList[0] is UOEOrderDtlWork)
                    {
                        // �o�b�N�A�b�v(�X�V���Ɏg�p)
                        //this._uoeOrderDtlWorkList = arrayList;
                        this.CreateUOEOrderDtlWorkHTable(arrayList);

                        // UOE�����f�[�^���O���b�h���C���f�[�^
                        this.CreateGridMainTableForHandy(uoeStockUpdSearch.SectionCode.Trim(),arrayList);
                        // �O���b�h���C���f�[�^��UOE���ɍX�V�w�b�_�[�p�f�[�^
                        this.CreateHeaderGridDataSet();

                        // �O���b�h���C���f�[�^��UOE���ɍX�V���חp�f�[�^
                        this.CreateDetailGridDataSet(0);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// UOE���ɍX�V���C���f�[�^�쐬�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="uoeOrderList">UOE�������X�g</param>
        /// <returns>UOE���ɍX�V���C���f�[�^�쐬�X�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^����UOE���ɍX�V���C���f�[�^���擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int CreateGridMainTableForHandy(string sectionCode, ArrayList uoeOrderList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                UOEOrderDtlWork uoeOrderDtlWork = null;

                // UOE���ɍX�V���C���e�[�u���C���X�^���X�쐬
                this._gridMainTable = new GridMainDataSet.GridMainTableDataTable();

                // �`�[�ԍ��P�ʂɓW�J
                GridMainDataSet.GridMainTableRow gridMainRow = null;

                for (int index = 0; index <= uoeOrderList.Count - 1; index++)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)uoeOrderList[index];

                    UOEOrderDtlWork tempUoeOrderDtlWork = new UOEOrderDtlWork();
                    tempUoeOrderDtlWork.UOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
                    tempUoeOrderDtlWork.CommAssemblyId = uoeOrderDtlWork.CommAssemblyId;
                    tempUoeOrderDtlWork.BOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
                    tempUoeOrderDtlWork.BOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
                    tempUoeOrderDtlWork.BOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;
                    // �d����BO�`�[�ԍ��ҏW����
                    UpdBOSlipNo(ref tempUoeOrderDtlWork);

                    #region UOE���_�`�[�ԍ�
                    if (uoeOrderDtlWork.EnterUpdDivSec == EnterUpdDivSecData0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_SECTION;                              // ��敪
                        gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // �`�[�ԍ�
                        gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = 0;                                          // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // ���ɐ�(���͗p)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivSecSlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO�`�[�ԍ�1
                    if (uoeOrderDtlWork.EnterUpdDivBO1 == EnterUpdDivBO1Data0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO1;                                  // ��敪
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo1;                         // �`�[�ԍ�
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // ���ɐ�(���͗p)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO1SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO�`�[�ԍ�2
                    if (uoeOrderDtlWork.EnterUpdDivBO2 == EnterUpdDivBO2Data0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO2;                                  // ��敪
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo2;                         // �`�[�ԍ�
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // ���ɐ�(���͗p)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO2SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO�`�[�ԍ�3
                    if (uoeOrderDtlWork.EnterUpdDivBO3 == EnterUpdDivBO3Data0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO3;                                  // ��敪
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo3;                         // �`�[�ԍ�
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // ���ɐ�(���͗p)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO3SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region Ұ��
                    if (uoeOrderDtlWork.EnterUpdDivMaker == EnterUpdDivMakerData0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_MAKER;                                // ��敪
                        gridMainRow.SlipNo = EnterUpdDivMakerSlipNo;                            // �`�[�ԍ�(�X�y�[�X)
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // ���ɐ�(���͗p)

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region EO
                    if (uoeOrderDtlWork.EnterUpdDivEO == EnterUpdDivEOData0)
                    {
                        // ���ʕ��R�s�[
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_EO;                                   // ��敪
                        gridMainRow.SlipNo = EnterUpdDivEOSlipNo;                               // �`�[�ԍ�(�X�y�[�X)
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE���_�o�ɐ�
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO�o�ɐ�
                        gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // ���ɐ�
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // ���ɐ�(���͗p)

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion
                }

                List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                Dictionary<string, Double> stockUnitPriceDic = new Dictionary<string, double>();       // �J���[���

                this._unitPriceCalculation.CacheRateProtyMngAllList(_rateProtyMngAllList);
                this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                    {
                        string keyUnitPrice = unitPriceCalcRetWk.GoodsMakerCd.ToString() + unitPriceCalcRetWk.GoodsNo;
                        if (!stockUnitPriceDic.ContainsKey(keyUnitPrice))
                        {
                            stockUnitPriceDic.Add(keyUnitPrice, unitPriceCalcRetWk.UnitPriceTaxExcFl);
                        }
                    }
                }

                #region �e�O���b�h�p�sNo.�t��
                int headerGridRowNo = 0;
                int detailGridRowNo = 0;
                String key = string.Empty;
                String keyPrice = string.Empty;

                GridMainDataSet.GridMainTableRow mainRow = null;
                DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                    keyPrice = mainRow.GoodsMakerCd.ToString() + mainRow.GoodsNo;
                    if (key == string.Empty)
                    {
                        // 1����
                        mainRow.HeaderGridRowNo = headerGridRowNo;       // �w�b�_�[�O���b�h�p�sNo.
                        mainRow.DetailGridRowNo = detailGridRowNo;       // ���׃O���b�h�p�sNo.
                        key = mainRow.OnlineNo + mainRow.SlipNo;

                        if (stockUnitPriceDic.ContainsKey(keyPrice))
                        {
                            // �����P���i���i�}�X�^���j
                            mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                        }
                        continue;
                    }

                    if (key != (mainRow.OnlineNo + mainRow.SlipNo))
                    {
                        // �`�[�ԍ����ς������
                        headerGridRowNo++;
                    }
                    detailGridRowNo++;

                    mainRow.HeaderGridRowNo = headerGridRowNo;           // �w�b�_�[�O���b�h�p�sNo.
                    mainRow.DetailGridRowNo = detailGridRowNo;           // ���׃O���b�h�p�sNo.

                    key = mainRow.OnlineNo + mainRow.SlipNo;

                    if (stockUnitPriceDic.ContainsKey(keyPrice))
                    {
                        // �����P���i���i�}�X�^���j
                        mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                    }
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                // �����Ȃ�
            }
            return status;
        }

        /// <summary>
        /// UOE�����f�[�^��UOE���ɍX�V���C���f�[�^���f�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="uoeOrderDtlRow">UOE�����f�[�^</param>
        /// <returns>UOE���ɍX�V���C���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̓��e��UOE���ɍX�V���C���f�[�^�ɔ��f���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private GridMainDataSet.GridMainTableRow CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(string sectionCode, UOEOrderDtlWork uoeOrderDtlWorkRow)
        {
            GridMainDataSet.GridMainTableRow gridMainRow = this._gridMainTable.NewGridMainTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // �敪(" "�F�������A"1"�F���ׁA"2"�F�����ׁA"3"�F�C���A"9"�F������)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // ���[�J�[�R�[�h
            gridMainRow.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // �i��
            gridMainRow.GoodsName = uoeOrderDtlWorkRow.GoodsName;                       // �i��
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWorkRow.UOESalesOrderNo;           // UOE�����ԍ�
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWorkRow.UOESalesOrderRowNo;     // UOE�����s�ԍ�
            gridMainRow.OnlineNo = uoeOrderDtlWorkRow.OnlineNo;                         // �I�����C���ԍ�
            gridMainRow.OnlineRowNo = uoeOrderDtlWorkRow.OnlineRowNo;                   // �I�����C���s�ԍ�
            gridMainRow.WarehouseCode = uoeOrderDtlWorkRow.WarehouseCode;               // �q�ɃR�[�h
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWorkRow.WarehouseShelfNo;         // �I��
            gridMainRow.SalesUnitCost = uoeOrderDtlWorkRow.SalesUnitCost;               // �����P��
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerPartsNo = uoeOrderDtlWorkRow.AnswerPartsNo;               // �񓚕i��
            gridMainRow.UOERemark1 = uoeOrderDtlWorkRow.UoeRemark1;                     // ���}�[�N1
            gridMainRow.UOERemark2 = uoeOrderDtlWorkRow.UoeRemark2;                     // ���}�[�N2
            gridMainRow.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // �d����R�[�h
            gridMainRow.SubstPartsNo = uoeOrderDtlWorkRow.SubstPartsNo;                 // ��֕i��
            gridMainRow.SupplierSlipNo = uoeOrderDtlWorkRow.SupplierSlipNo;             // �d���`�[�ԍ�
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWorkRow.StockSlipDtlNum;        // �d�����גʔ�
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE���ɍX�V�w�b�_�[�O���b�h�p�s�ԍ�
            gridMainRow.DetailGridRowNo = 0;                                            // UOE���ɍX�V���׃O���b�h�p�s�ԍ�
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // �񓚌����P��
            gridMainRow.AnswerMakerCd = uoeOrderDtlWorkRow.AnswerMakerCd;               // �񓚃��[�J�[�R�[�h
            gridMainRow.UOESupplierCd = uoeOrderDtlWorkRow.UOESupplierCd;               // UOE������R�[�h

            gridMainRow.GoodspriceuSalesUnitCost = 0.0;                             

            GoodsUnitData unitData = new GoodsUnitData();
            unitData.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // ���i���[�J�[�R�[�h
            unitData.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // ���i�ԍ�
            unitData.GoodsRateRank = uoeOrderDtlWorkRow.GoodsRateRank;               // ���i�|�������N
            unitData.BLGoodsCode = uoeOrderDtlWorkRow.BLGoodsCode;                   // BL���i�R�[�h
            unitData.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // �d����R�[�h
            unitData.TaxationDivCd = uoeOrderDtlWorkRow.TaxationDivCd;               // �ېŋ敪
            unitData.SectionCode = uoeOrderDtlWorkRow.SectionCode;

            List<GoodsPrice> goodsPriceList;
            goodsPriceList = new List<GoodsPrice>();
            GoodsPrice goodsPrice = new GoodsPrice();
            goodsPrice.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;
            goodsPrice.ListPrice = uoeOrderDtlWorkRow.PriceListPrice;
            goodsPrice.PriceStartDate = TDateTime.LongDateToDateTime(uoeOrderDtlWorkRow.PriceStartDate);
            goodsPrice.StockRate = uoeOrderDtlWorkRow.StockRate;
            goodsPrice.EnterpriseCode = uoeOrderDtlWorkRow.EnterpriseCode;
            goodsPrice.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;
            goodsPrice.LogicalDeleteCode = 0; // �_���폜�敪
            goodsPrice.SalesUnitCost = uoeOrderDtlWorkRow.GoodspriceuSalesUnitCost;
            goodsPriceList.Add(goodsPrice);
            unitData.GoodsPriceList = goodsPriceList;
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = sectionCode.Trim();    // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = unitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = unitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = unitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = unitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = unitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = unitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = unitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = unitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = unitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = unitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            goodsUnitDataList.Add(unitData);

            return gridMainRow;
        }

        /// <summary>
        /// UOE�����f�[�^�̕␳�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="inspectDataAddList">���i�o�^�f�[�^</param>
        /// <returns>�␳�X�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�̍X�V�敪�A���i����␳���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetUpdateDivForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ���i�o�^�f�[�^���Ȃ��ꍇ
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // ���i�o�^�����I�u�W�F�N�g���Ȃ��ꍇ
                if (searchObj == null)
                {
                    return status;
                }

                // ���i�o�^���[�N�^�C�v���擾���܂��B
                Type searchType = searchObj.GetType();
                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // �d�����גʔ�
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // ���ɋ敪
                    string warehousingDivCd = searchType.GetProperty(WarehousingDivCd).GetValue(inspectDataAddList[i], null).ToString();
                    // �X�V�敪
                    int updateDiv = (int)searchType.GetProperty(UpdateDiv).GetValue(inspectDataAddList[i], null);
                    // ���i��
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);

                    if (updateDiv == 0) continue;

                    string Filter = string.Format("{0}={1} AND {2}='{3}'",
                                this._gridMainTable.StockSlipDtlNumSrcColumn, stockSlipDtlNum,
                                this._gridMainTable.ColumnDivColumn, WarehousingDivCdToString(warehousingDivCd));

                    GridMainDataSet.GridMainTableRow[] gridMainTableRow =
                        (GridMainDataSet.GridMainTableRow[])this._gridMainTable.Select(Filter);

                    if (gridMainTableRow.Length > 0)
                    {
                        // _gridMainTable.DivCd�Ɉ���.�X�V�敪���Z�b�g����B
                        gridMainTableRow[0].DivCd = updateDiv.ToString();
                        // _gridMainTable.InputEnterCnt�Ɉ���.���i�����Z�b�g����B
                        gridMainTableRow[0].InputEnterCnt = (int)inspectCnt;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���ɋ敪�p������̎擾�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="warehousingDivCd">���ɋ敪�R�[�h</param>
        /// <returns>���ɋ敪�p������</returns>
        /// <remarks>
        /// <br>Note       : ���ɋ敪�p��������擾���܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private string WarehousingDivCdToString(string warehousingDivCd)
        {
            string resultWarehousingDivCd = string.Empty;
            switch (warehousingDivCd)
            {
                // ����.���ɋ敪���u1:���_�v�̏ꍇ�A
                case WarehousingSectionDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_SECTION;
                        break;
                    }
                // ����.���ɋ敪���u2:BO1�v�̏ꍇ�A
                case WarehousingBo1Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO1;
                        break;
                    }
                // ����.���ɋ敪���u3:BO2�v�̏ꍇ�A
                case WarehousingBo2Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO2;
                        break;
                    }
                // ����.���ɋ敪���u4:BO3�v�̏ꍇ�A
                case WarehousingBo3Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO3;
                        break;
                    }
                // ����.���ɋ敪���u5:Ұ���v�̏ꍇ�A
                case WarehousingMakerDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_MAKER;
                        break;
                    }
                // ����.���ɋ敪���u6�FEO�v�̏ꍇ�A
                case WarehousingEoDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_EO;
                        break;
                    }
                default:
                    break;
            }
            return resultWarehousingDivCd;
        }

        /// <summary>
        /// UOE���ɍX�V�m�菈��(�{������PMUOE01203AB�ōs��)�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="uoeStcUpdDataListObj">UOE�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�������ʃX�e�[�^�X�u0�F����  0�ȊO�F���s�v</returns>
        /// <remarks>
        /// <br>Note       : UOE���ɍX�V�m�菈�����s���܂��B�f�[�^�̍쐬��PMUOE01203AB�N���X�ōs���B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int DecisionDataForHandy(out object uoeStcUpdDataListObj, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �w�b�_�[�O���b�h��GridMain���f
            this.CopyToGridMainFromHeaderGrid();

            // �C���X�^���X�쐬
            this._decisionDataAcs = new PMUOE01203AB(this._enterpriseCode
                                                    , this._uoeOrderDtlWorkHTable
                                                    , this._gridMainTable
                                                    , this._stockSlipWorkHTable
                                                    , this._stockDetailWorkHTable
                                                    , this._supplierHTable);    // ���ɍX�V�m�菈����p�N���X

            // �v���p�e�B�Z�b�g
            this._decisionDataAcs.GoodsAcs = this._goodsAcs;                            // ���i�}�X�^�A�N�Z�X�N���X
            this._decisionDataAcs.StockingPaymentOption = this._stockingPaymentOption;  // ���|�I�v�V����
            this._decisionDataAcs.StockBlnktPrtNoDiv = this._stockBlnktPrtNoDiv;        // UOE���Ѓ}�X�^.�݌Ɉꊇ�i�ԋ敪
            this._decisionDataAcs.MeiJiDiv = this._meiJiDiv;                            // �����Y�Ƌ敪

            // �f�[�^�쐬
            uoeStcUpdDataListObj = this._decisionDataAcs.CreateUOEStcUpdDataList(out msg);
            if (uoeStcUpdDataListObj == null)
            {
                // �f�[�^�쐬���s
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // �C���X�^���X�^�C�v������ꍇ�A�C���X�^���X�I�u�W�F�N�g�𐶐����܂��B
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
    }

    // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
    /// <summary>
    /// �|���D��Ǘ��f�[�^��r�N���X(���_�R�[�h(����)�A�P�����(����)�A�|���D�揇��(����))
    /// </summary>
    /// <remarks></remarks>
    internal class RateProtyMngComparer : Comparer<RateProtyMng>
    {

        public override int Compare(RateProtyMng x, RateProtyMng y)
        {
            int result = x.SectionCode.CompareTo(y.SectionCode);
            if (result != 0) return result;

            result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
            if (result != 0) return result;

            result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
            return result;
        }
    }
	// ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

}

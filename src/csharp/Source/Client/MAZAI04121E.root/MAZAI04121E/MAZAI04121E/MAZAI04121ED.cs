using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveSlipSearchCond
    /// <summary>
    ///                      �݌Ɉړ��`�[��������
    /// </summary>
    /// <remarks>
    /// note             :   �݌Ɉړ��`�[���������w�b�_�t�@�C��<br />
    /// Programmer       :   ��������<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/01/25  (CSharp File Generated Date)<br />
    /// Update Note      :   <br />
    /// Update Note      :   2012/05/22 wangf </br>
    ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
    /// </remarks>
    public class StockMoveSlipSearchCond
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h</summary>
        /// <remarks>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>�o�גS���]�ƈ��R�[�h</summary>
        /// <remarks>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _shipAgentCd = "";

        /// <summary>����S���]�ƈ��R�[�h</summary>
        /// <remarks>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</remarks>
        private string _receiveAgentCd = "";

        /// <summary>�o�ח\��J�n��</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlStDay;

        /// <summary>�o�ח\��I����</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlEdDay;

        /// <summary>�o�׊m��J�n��</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixStDay;

        /// <summary>�o�׊m��I����</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixEdDay;

        /// <summary>���׊J�n��</summary>
        private DateTime _arrivalGoodsStDay;

        /// <summary>���׏I����</summary>
        private DateTime _arrivalGoodsEdDay;

        /// <summary>�ړ������_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32 _moveStatus;

        /// <summary>�@��R�[�h</summary>
        private Int32 _cellphoneModelCode;

        /// <summary>�����ԍ�</summary>
        /// <remarks>���u���ԂȂ��v�̏ꍇ�Anull</remarks>
        private string _productNumber = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>����S���]�ƈ�����</summary>
        private string _receiveAgentNm = "";

        /// <summary>�@�햼��</summary>
        private string _cellphoneModelName = "";

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// <summary>�ďo���@�\�敪</summary>
        /// <remarks>1:�݌Ɉړ����͌����K�C�h�A2�F���̏ꍇ</remarks>
        private Int32 _callerFunction;
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ��ƃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>�o�גS���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�גS���]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>����S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ����S���]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ShipmentScdlStDay
        /// <summary>�o�ח\��J�n���v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�ח\��J�n���v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ShipmentScdlStDay
        {
            get { return _shipmentScdlStDay; }
            set { _shipmentScdlStDay = value; }
        }

        /// public propaty name  :  ShipmentScdlEdDay
        /// <summary>�o�ח\��I�����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�ח\��I�����v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ShipmentScdlEdDay
        {
            get { return _shipmentScdlEdDay; }
            set { _shipmentScdlEdDay = value; }
        }

        /// public propaty name  :  ShipmentFixStDay
        /// <summary>�o�׊m��J�n���v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�׊m��J�n���v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ShipmentFixStDay
        {
            get { return _shipmentFixStDay; }
            set { _shipmentFixStDay = value; }
        }

        /// public propaty name  :  ShipmentFixEdDay
        /// <summary>�o�׊m��I�����v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�׊m��I�����v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ShipmentFixEdDay
        {
            get { return _shipmentFixEdDay; }
            set { _shipmentFixEdDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsStDay
        /// <summary>���׊J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���׊J�n���v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ArrivalGoodsStDay
        {
            get { return _arrivalGoodsStDay; }
            set { _arrivalGoodsStDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsEdDay
        /// <summary>���׏I�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���׏I�����v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public DateTime ArrivalGoodsEdDay
        {
            get { return _arrivalGoodsEdDay; }
            set { _arrivalGoodsEdDay = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ������_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ����q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterpriseCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��拒�_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���ԃv���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  CellphoneModelCode
        /// <summary>�@��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �@��R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 CellphoneModelCode
        {
            get { return _cellphoneModelCode; }
            set { _cellphoneModelCode = value; }
        }

        /// public propaty name  :  ProductNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>���u���ԂȂ��v�̏ꍇ�Anull</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �����ԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ��Ɩ��̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  ReceiveAgentNm
        /// <summary>����S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ����S���]�ƈ����̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _receiveAgentNm; }
            set { _receiveAgentNm = value; }
        }

        /// public propaty name  :  CellphoneModelName
        /// <summary>�@�햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �@�햼�̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string CellphoneModelName
        {
            get { return _cellphoneModelName; }
            set { _cellphoneModelName = value; }
        }

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// public propaty name  :  CallerFunction
        /// <summary>�ďo���@�\�敪�v���p�e�B</summary>
        /// <value>1:�݌Ɉړ����͌����K�C�h�A2�F���̏ꍇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ďo���@�\�敪�v���p�e�B</br>
        /// <br>Programer        :   wangf</br>
        /// </remarks>
        public Int32 CallerFunction
        {
            get { return _callerFunction; }
            set { _callerFunction = value; }
        }
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// <summary>
        /// �݌Ɉړ��`�[���������R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveSlipSearchCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public StockMoveSlipSearchCond()
        {
        }

        /// <summary>
        /// �݌Ɉړ��`�[���������R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="stockMvEmpCode">�݌Ɉړ����͏]�ƈ��R�[�h(�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g)</param>
        /// <param name="shipAgentCd">�o�גS���]�ƈ��R�[�h(�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g)</param>
        /// <param name="receiveAgentCd">����S���]�ƈ��R�[�h(�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g)</param>
        /// <param name="shipmentScdlStDay">�o�ח\��J�n��(�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g)</param>
        /// <param name="shipmentScdlEdDay">�o�ח\��I����(�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g)</param>
        /// <param name="shipmentFixStDay">�o�׊m��J�n��(�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g)</param>
        /// <param name="shipmentFixEdDay">�o�׊m��I����(�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g)</param>
        /// <param name="arrivalGoodsStDay">���׊J�n��</param>
        /// <param name="arrivalGoodsEdDay">���׏I����</param>
        /// <param name="bfSectionCode">�ړ������_�R�[�h</param>
        /// <param name="bfEnterWarehCode">�ړ����q�ɃR�[�h</param>
        /// <param name="afEnterpriseCode">�ړ��拒�_�R�[�h</param>
        /// <param name="afEnterWarehCode">�ړ���q�ɃR�[�h</param>
        /// <param name="moveStatus">�ړ����(0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�)</param>
        /// <param name="cellphoneModelCode">�@��R�[�h</param>
        /// <param name="productNumber">�����ԍ�(���u���ԂȂ��v�̏ꍇ�Anull)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="receiveAgentNm">����S���]�ƈ�����</param>
        /// <param name="cellphoneModelName">�@�햼��</param>
        /// <param name="callerFunction">�ďo���@�\�敪</param>
        /// <returns>StockMoveSlipSearchCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        //public StockMoveSlipSearchCond(string enterpriseCode, string sectionCode, Int32 stockMoveSlipNo, string stockMvEmpCode, string shipAgentCd, string receiveAgentCd, DateTime shipmentScdlStDay, DateTime shipmentScdlEdDay, DateTime shipmentFixStDay, DateTime shipmentFixEdDay, DateTime arrivalGoodsStDay, DateTime arrivalGoodsEdDay, string bfSectionCode, string bfEnterWarehCode, string afSectionCode, string afEnterWarehCode, Int32 moveStatus, Int32 cellphoneModelCode, string productNumber, string enterpriseName, string receiveAgentNm, string cellphoneModelName) // DEL wangf 2012/05/22 FOR Redmine#29881
        public StockMoveSlipSearchCond(string enterpriseCode, string sectionCode, Int32 stockMoveSlipNo, string stockMvEmpCode, string shipAgentCd, string receiveAgentCd, DateTime shipmentScdlStDay, DateTime shipmentScdlEdDay, DateTime shipmentFixStDay, DateTime shipmentFixEdDay, DateTime arrivalGoodsStDay, DateTime arrivalGoodsEdDay, string bfSectionCode, string bfEnterWarehCode, string afSectionCode, string afEnterWarehCode, Int32 moveStatus, Int32 cellphoneModelCode, string productNumber, string enterpriseName, string receiveAgentNm, string cellphoneModelName, Int32 callerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._stockMoveSlipNo = stockMoveSlipNo;
            this._stockMvEmpCode = stockMvEmpCode;
            this._shipAgentCd = shipAgentCd;
            this._receiveAgentCd = receiveAgentCd;
            this._shipmentScdlStDay = shipmentScdlStDay;
            this._shipmentScdlEdDay = shipmentScdlEdDay;
            this._shipmentFixStDay = shipmentFixStDay;
            this._shipmentFixEdDay = shipmentFixEdDay;
            this._arrivalGoodsStDay = arrivalGoodsStDay;
            this._arrivalGoodsEdDay = arrivalGoodsEdDay;
            this._bfSectionCode = bfSectionCode;
            this._bfEnterWarehCode = bfEnterWarehCode;
            this._afSectionCode = afSectionCode;
            this._afEnterWarehCode = afEnterWarehCode;
            this._moveStatus = moveStatus;
            this._cellphoneModelCode = cellphoneModelCode;
            this._productNumber = productNumber;
            this._enterpriseName = enterpriseName;
            this._receiveAgentNm = receiveAgentNm;
            this._cellphoneModelName = cellphoneModelName;
            this._callerFunction = callerFunction; // ADD wangf 2012/05/22 FOR Redmine#29881

        }

        /// <summary>
        /// �݌Ɉړ��`�[����������������
        /// </summary>
        /// <returns>StockMoveSlipSearchCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockMoveSlipSearchCond�N���X�̃C���X�^���X��Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        public StockMoveSlipSearchCond Clone()
        {
            //return new StockMoveSlipSearchCond(this._enterpriseCode, this._sectionCode, this._stockMoveSlipNo, this._stockMvEmpCode, this._shipAgentCd, this._receiveAgentCd, this._shipmentScdlStDay, this._shipmentScdlEdDay, this._shipmentFixStDay, this._shipmentFixEdDay, this._arrivalGoodsStDay, this._arrivalGoodsEdDay, this._bfSectionCode, this._bfEnterWarehCode, this._afSectionCode, this._afEnterWarehCode, this._moveStatus, this._cellphoneModelCode, this._productNumber, this._enterpriseName, this._receiveAgentNm, this._cellphoneModelName); // DEL wangf 2012/05/22 FOR Redmine#29881
            return new StockMoveSlipSearchCond(this._enterpriseCode, this._sectionCode, this._stockMoveSlipNo, this._stockMvEmpCode, this._shipAgentCd, this._receiveAgentCd, this._shipmentScdlStDay, this._shipmentScdlEdDay, this._shipmentFixStDay, this._shipmentFixEdDay, this._arrivalGoodsStDay, this._arrivalGoodsEdDay, this._bfSectionCode, this._bfEnterWarehCode, this._afSectionCode, this._afEnterWarehCode, this._moveStatus, this._cellphoneModelCode, this._productNumber, this._enterpriseName, this._receiveAgentNm, this._cellphoneModelName, this._callerFunction); // ADD wangf 2012/05/22 FOR Redmine#29881
        }

        /// <summary>
        /// �݌Ɉړ��`�[����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveSlipSearchCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        public bool Equals(StockMoveSlipSearchCond target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.StockMvEmpCode == target.StockMvEmpCode)
                 && (this.ShipAgentCd == target.ShipAgentCd)
                 && (this.ReceiveAgentCd == target.ReceiveAgentCd)
                 && (this.ShipmentScdlStDay == target.ShipmentScdlStDay)
                 && (this.ShipmentScdlEdDay == target.ShipmentScdlEdDay)
                 && (this.ShipmentFixStDay == target.ShipmentFixStDay)
                 && (this.ShipmentFixEdDay == target.ShipmentFixEdDay)
                 && (this.ArrivalGoodsStDay == target.ArrivalGoodsStDay)
                 && (this.ArrivalGoodsEdDay == target.ArrivalGoodsEdDay)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.MoveStatus == target.MoveStatus)
                 && (this.CellphoneModelCode == target.CellphoneModelCode)
                 && (this.ProductNumber == target.ProductNumber)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.ReceiveAgentNm == target.ReceiveAgentNm)
                 && (this.CallerFunction == target.CallerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
                 && (this.CellphoneModelName == target.CellphoneModelName));
        }

        /// <summary>
        /// �݌Ɉړ��`�[����������r����
        /// </summary>
        /// <param name="stockMoveSlipSearchCond1">
        ///                    ��r����StockMoveSlipSearchCond�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockMoveSlipSearchCond2">��r����StockMoveSlipSearchCond�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        public static bool Equals(StockMoveSlipSearchCond stockMoveSlipSearchCond1, StockMoveSlipSearchCond stockMoveSlipSearchCond2)
        {
            return ((stockMoveSlipSearchCond1.EnterpriseCode == stockMoveSlipSearchCond2.EnterpriseCode)
                 && (stockMoveSlipSearchCond1.SectionCode == stockMoveSlipSearchCond2.SectionCode)
                 && (stockMoveSlipSearchCond1.StockMoveSlipNo == stockMoveSlipSearchCond2.StockMoveSlipNo)
                 && (stockMoveSlipSearchCond1.StockMvEmpCode == stockMoveSlipSearchCond2.StockMvEmpCode)
                 && (stockMoveSlipSearchCond1.ShipAgentCd == stockMoveSlipSearchCond2.ShipAgentCd)
                 && (stockMoveSlipSearchCond1.ReceiveAgentCd == stockMoveSlipSearchCond2.ReceiveAgentCd)
                 && (stockMoveSlipSearchCond1.ShipmentScdlStDay == stockMoveSlipSearchCond2.ShipmentScdlStDay)
                 && (stockMoveSlipSearchCond1.ShipmentScdlEdDay == stockMoveSlipSearchCond2.ShipmentScdlEdDay)
                 && (stockMoveSlipSearchCond1.ShipmentFixStDay == stockMoveSlipSearchCond2.ShipmentFixStDay)
                 && (stockMoveSlipSearchCond1.ShipmentFixEdDay == stockMoveSlipSearchCond2.ShipmentFixEdDay)
                 && (stockMoveSlipSearchCond1.ArrivalGoodsStDay == stockMoveSlipSearchCond2.ArrivalGoodsStDay)
                 && (stockMoveSlipSearchCond1.ArrivalGoodsEdDay == stockMoveSlipSearchCond2.ArrivalGoodsEdDay)
                 && (stockMoveSlipSearchCond1.BfSectionCode == stockMoveSlipSearchCond2.BfSectionCode)
                 && (stockMoveSlipSearchCond1.BfEnterWarehCode == stockMoveSlipSearchCond2.BfEnterWarehCode)
                 && (stockMoveSlipSearchCond1.AfSectionCode == stockMoveSlipSearchCond2.AfSectionCode)
                 && (stockMoveSlipSearchCond1.AfEnterWarehCode == stockMoveSlipSearchCond2.AfEnterWarehCode)
                 && (stockMoveSlipSearchCond1.MoveStatus == stockMoveSlipSearchCond2.MoveStatus)
                 && (stockMoveSlipSearchCond1.CellphoneModelCode == stockMoveSlipSearchCond2.CellphoneModelCode)
                 && (stockMoveSlipSearchCond1.ProductNumber == stockMoveSlipSearchCond2.ProductNumber)
                 && (stockMoveSlipSearchCond1.EnterpriseName == stockMoveSlipSearchCond2.EnterpriseName)
                 && (stockMoveSlipSearchCond1.ReceiveAgentNm == stockMoveSlipSearchCond2.ReceiveAgentNm)
                 && (stockMoveSlipSearchCond1.CallerFunction == stockMoveSlipSearchCond2.CallerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
                 && (stockMoveSlipSearchCond1.CellphoneModelName == stockMoveSlipSearchCond2.CellphoneModelName));
        }
        /// <summary>
        /// �݌Ɉړ��`�[����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveSlipSearchCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        public ArrayList Compare(StockMoveSlipSearchCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.StockMvEmpCode != target.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (this.ShipAgentCd != target.ShipAgentCd) resList.Add("ShipAgentCd");
            if (this.ReceiveAgentCd != target.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (this.ShipmentScdlStDay != target.ShipmentScdlStDay) resList.Add("ShipmentScdlStDay");
            if (this.ShipmentScdlEdDay != target.ShipmentScdlEdDay) resList.Add("ShipmentScdlEdDay");
            if (this.ShipmentFixStDay != target.ShipmentFixStDay) resList.Add("ShipmentFixStDay");
            if (this.ShipmentFixEdDay != target.ShipmentFixEdDay) resList.Add("ShipmentFixEdDay");
            if (this.ArrivalGoodsStDay != target.ArrivalGoodsStDay) resList.Add("ArrivalGoodsStDay");
            if (this.ArrivalGoodsEdDay != target.ArrivalGoodsEdDay) resList.Add("ArrivalGoodsEdDay");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.MoveStatus != target.MoveStatus) resList.Add("MoveStatus");
            if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
            if (this.ProductNumber != target.ProductNumber) resList.Add("ProductNumber");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.ReceiveAgentNm != target.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (this.CellphoneModelName != target.CellphoneModelName) resList.Add("CellphoneModelName");
            if (this.CallerFunction != target.CallerFunction) resList.Add("CallerFunction"); // ADD wangf 2012/05/22 FOR Redmine#29881

            return resList;
        }

        /// <summary>
        /// �݌Ɉړ��`�[����������r����
        /// </summary>
        /// <param name="stockMoveSlipSearchCond1">��r����StockMoveSlipSearchCond�N���X�̃C���X�^���X</param>
        /// <param name="stockMoveSlipSearchCond2">��r����StockMoveSlipSearchCond�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveSlipSearchCond�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveSlipSearchCond stockMoveSlipSearchCond1, StockMoveSlipSearchCond stockMoveSlipSearchCond2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveSlipSearchCond1.EnterpriseCode != stockMoveSlipSearchCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveSlipSearchCond1.SectionCode != stockMoveSlipSearchCond2.SectionCode) resList.Add("SectionCode");
            if (stockMoveSlipSearchCond1.StockMoveSlipNo != stockMoveSlipSearchCond2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveSlipSearchCond1.StockMvEmpCode != stockMoveSlipSearchCond2.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (stockMoveSlipSearchCond1.ShipAgentCd != stockMoveSlipSearchCond2.ShipAgentCd) resList.Add("ShipAgentCd");
            if (stockMoveSlipSearchCond1.ReceiveAgentCd != stockMoveSlipSearchCond2.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (stockMoveSlipSearchCond1.ShipmentScdlStDay != stockMoveSlipSearchCond2.ShipmentScdlStDay) resList.Add("ShipmentScdlStDay");
            if (stockMoveSlipSearchCond1.ShipmentScdlEdDay != stockMoveSlipSearchCond2.ShipmentScdlEdDay) resList.Add("ShipmentScdlEdDay");
            if (stockMoveSlipSearchCond1.ShipmentFixStDay != stockMoveSlipSearchCond2.ShipmentFixStDay) resList.Add("ShipmentFixStDay");
            if (stockMoveSlipSearchCond1.ShipmentFixEdDay != stockMoveSlipSearchCond2.ShipmentFixEdDay) resList.Add("ShipmentFixEdDay");
            if (stockMoveSlipSearchCond1.ArrivalGoodsStDay != stockMoveSlipSearchCond2.ArrivalGoodsStDay) resList.Add("ArrivalGoodsStDay");
            if (stockMoveSlipSearchCond1.ArrivalGoodsEdDay != stockMoveSlipSearchCond2.ArrivalGoodsEdDay) resList.Add("ArrivalGoodsEdDay");
            if (stockMoveSlipSearchCond1.BfSectionCode != stockMoveSlipSearchCond2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveSlipSearchCond1.BfEnterWarehCode != stockMoveSlipSearchCond2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveSlipSearchCond1.AfSectionCode != stockMoveSlipSearchCond2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveSlipSearchCond1.AfEnterWarehCode != stockMoveSlipSearchCond2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveSlipSearchCond1.MoveStatus != stockMoveSlipSearchCond2.MoveStatus) resList.Add("MoveStatus");
            if (stockMoveSlipSearchCond1.CellphoneModelCode != stockMoveSlipSearchCond2.CellphoneModelCode) resList.Add("CellphoneModelCode");
            if (stockMoveSlipSearchCond1.ProductNumber != stockMoveSlipSearchCond2.ProductNumber) resList.Add("ProductNumber");
            if (stockMoveSlipSearchCond1.EnterpriseName != stockMoveSlipSearchCond2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMoveSlipSearchCond1.ReceiveAgentNm != stockMoveSlipSearchCond2.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (stockMoveSlipSearchCond1.CellphoneModelName != stockMoveSlipSearchCond2.CellphoneModelName) resList.Add("CellphoneModelName");
            if (stockMoveSlipSearchCond1.CallerFunction != stockMoveSlipSearchCond2.CallerFunction) resList.Add("CallerFunction"); // ADD wangf 2012/05/22 FOR Redmine#29881

            return resList;
        }
    }
}

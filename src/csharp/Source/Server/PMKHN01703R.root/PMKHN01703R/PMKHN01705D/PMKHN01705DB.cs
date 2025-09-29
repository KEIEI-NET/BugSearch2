//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��ꊇ��������
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsChangeResultWork
    /// <summary>
    ///                      �ϊ��������ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϊ��������ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2015/01/26  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsChangeResultWork
    {
        /// <summary>���O�t�@�C���g�p�t���O</summary>
        private Int32 _logCSVOpen;

        /// <summary>�G���[�t�@�C���g�p�t���O</summary>
        private Int32 _errLogCSVOpen;

        /// <summary>�Ǎ�����(�i�ԕϊ��}�X�^)</summary>
        private Int32 _readCntGoodsChgMst;

        /// <summary>�X�V����(�i�ԕϊ��}�X�^)</summary>
        private Int32 _loadCntGoodsChgMst;

        /// <summary>�G���[����(�i�ԕϊ��}�X�^)</summary>
        private Int32 _errCntGoodsChgMst;

        /// <summary>�t�@�C���X�e�[�^�X(�i�ԕϊ��}�X�^)</summary>
        private Int32 _mstStatusErrCSV;

        /// <summary>�G���[���b�Z�[�W(�i�ԕϊ��}�X�^)</summary>
        private string _errMsg = "";

        /// <summary>�Ǎ�����(���i�݌Ƀ}�X�^)</summary>
        private Int32 _readCntGoodsAll;

        /// <summary>�X�V����(���i�݌Ƀ}�X�^)</summary>
        private Int32 _loadCntGoodsAll;

        /// <summary>�G���[����(���i�݌Ƀ}�X�^)</summary>
        private Int32 _errCntGoodsAll;

        /// <summary>�G���[����(���i�}�X�^)</summary>
        private Int32 _errorCntGoods;

        /// <summary>�G���[����(���i�}�X�^)</summary>
        private Int32 _errorCntPrice;

        /// <summary>�G���[����(�݌Ƀ}�X�^)</summary>
        private Int32 _errorCntStock;

        /// <summary>�t�@�C���X�e�[�^�X(���i�}�X�^)</summary>
        private Int32 _goodsStatusErrCSV;

        /// <summary>�t�@�C���X�e�[�^�X(���i�}�X�^)</summary>
        private Int32 _priceStatusErrCSV;

        /// <summary>�t�@�C���X�e�[�^�X(�݌Ƀ}�X�^)</summary>
        private Int32 _stockStatusErrCSV;

        /// <summary>�Ǎ�����(���i�Ǘ����}�X�^)</summary>
        private Int32 _readCntMng;

        /// <summary>�X�V����(���i�Ǘ����}�X�^)</summary>
        private Int32 _loadCntMng;

        /// <summary>�G���[����(���i�Ǘ����}�X�^)</summary>
        private Int32 _errorCntMng;

        /// <summary>�t�@�C���X�e�[�^�X(���i�Ǘ����}�X�^)</summary>
        private Int32 _mngStatusErrCSV;

        /// <summary>�Ǎ�����(�|���}�X�^)</summary>
        private Int32 _readCntRate;

        /// <summary>�X�V����(�|���}�X�^)</summary>
        private Int32 _loadCntRate;

        /// <summary>�G���[����(�|���}�X�^)</summary>
        private Int32 _errorCntRate;

        /// <summary>�t�@�C���X�e�[�^�X(�|���}�X�^)</summary>
        private Int32 _rateStatusErrCSV;

        /// <summary>�Ǎ�����(�����}�X�^)</summary>
        private Int32 _readCntJoin;

        /// <summary>�X�V����(�����}�X�^)</summary>
        private Int32 _loadCntJoin;

        /// <summary>�G���[����(�����}�X�^)</summary>
        private Int32 _errorCntJoin;

        /// <summary>�t�@�C���X�e�[�^�X(�����}�X�^)</summary>
        private Int32 _joinStatusErrCSV;

        /// <summary>�Ǎ�����(��փ}�X�^)</summary>
        private Int32 _readCntParts;

        /// <summary>�X�V����(��փ}�X�^)</summary>
        private Int32 _loadCntParts;

        /// <summary>�G���[����(��փ}�X�^)</summary>
        private Int32 _errCntParts;

        /// <summary>�t�@�C���X�e�[�^�X(��փ}�X�^)</summary>
        private Int32 _partsStatusErrCSV;

        /// <summary>�Ǎ�����(�Z�b�g�}�X�^)</summary>
        private Int32 _readCntSet;

        /// <summary>�X�V����(�Z�b�g�}�X�^)</summary>
        private Int32 _loadCntSet;

        /// <summary>�G���[����(�Z�b�g�}�X�^)</summary>
        private Int32 _errCntSet;

        /// <summary>�t�@�C���X�e�[�^�X(�Z�b�g�}�X�^)</summary>
        private Int32 _setStatusErrCSV;

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// <summary>�Ǎ�����(�D�ǐݒ�}�X�^)</summary>
        private Int32 _readCntPrm;

        /// <summary>�X�V����(�D�ǐݒ�}�X�^)</summary>
        private Int32 _loadCntPrm;

        /// <summary>�G���[����(�D�ǐݒ�}�X�^)</summary>
        private Int32 _errCntPrm;

        /// <summary>�t�@�C���X�e�[�^�X(�D�ǐݒ�}�X�^)</summary>
        private Int32 _prmStatusErrCSV;
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        /// <summary>�Ǎ�����(�ݏo�ϊ�����)</summary>
        private Int32 _readCntShipment;

        /// <summary>�X�V����(�ݏo�ϊ�����)</summary>
        private Int32 _loadCntShipment;

        /// <summary>�G���[����(�ݏo�ϊ�����)</summary>
        private Int32 _errCntShipment;

        /// <summary>�t�@�C���X�e�[�^�X(�ݏo�ϊ�����)</summary>
        private Int32 _shipmentStatusErrCSV;


        /// public propaty name  :  LogCSVOpen
        /// <summary>���O�t�@�C���g�p�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�t�@�C���g�p�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogCSVOpen
        {
            get { return _logCSVOpen; }
            set { _logCSVOpen = value; }
        }

        /// public propaty name  :  ErrLogCSVOpen
        /// <summary>�G���[�t�@�C���g�p�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�t�@�C���g�p�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrLogCSVOpen
        {
            get { return _errLogCSVOpen; }
            set { _errLogCSVOpen = value; }
        }

        /// public propaty name  :  ReadCntGoodsChgMst
        /// <summary>�Ǎ�����(�i�ԕϊ��}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�i�ԕϊ��}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntGoodsChgMst
        {
            get { return _readCntGoodsChgMst; }
            set { _readCntGoodsChgMst = value; }
        }

        /// public propaty name  :  LoadCntGoodsChgMst
        /// <summary>�X�V����(�i�ԕϊ��}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�i�ԕϊ��}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntGoodsChgMst
        {
            get { return _loadCntGoodsChgMst; }
            set { _loadCntGoodsChgMst = value; }
        }

        /// public propaty name  :  ErrCntGoodsChgMst
        /// <summary>�G���[����(�i�ԕϊ��}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�i�ԕϊ��}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntGoodsChgMst
        {
            get { return _errCntGoodsChgMst; }
            set { _errCntGoodsChgMst = value; }
        }

        /// public propaty name  :  MstStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�i�ԕϊ��}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�i�ԕϊ��}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MstStatusErrCSV
        {
            get { return _mstStatusErrCSV; }
            set { _mstStatusErrCSV = value; }
        }

        /// public propaty name  :  ErrMsg
        /// <summary>�G���[���b�Z�[�W(�i�ԕϊ��}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���b�Z�[�W(�i�ԕϊ��}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

        /// public propaty name  :  ReadCntGoodsAll
        /// <summary>�Ǎ�����(���i�݌Ƀ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(���i�݌Ƀ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntGoodsAll
        {
            get { return _readCntGoodsAll; }
            set { _readCntGoodsAll = value; }
        }

        /// public propaty name  :  LoadCntGoodsAll
        /// <summary>�X�V����(���i�݌Ƀ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(���i�݌Ƀ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntGoodsAll
        {
            get { return _loadCntGoodsAll; }
            set { _loadCntGoodsAll = value; }
        }

        /// public propaty name  :  ErrCntGoodsAll
        /// <summary>�G���[����(���i�݌Ƀ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(���i�݌Ƀ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntGoodsAll
        {
            get { return _errCntGoodsAll; }
            set { _errCntGoodsAll = value; }
        }

        /// public propaty name  :  ErrorCntGoods
        /// <summary>�G���[����(���i�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(���i�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntGoods
        {
            get { return _errorCntGoods; }
            set { _errorCntGoods = value; }
        }

        /// public propaty name  :  ErrorCntPrice
        /// <summary>�G���[����(���i�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(���i�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntPrice
        {
            get { return _errorCntPrice; }
            set { _errorCntPrice = value; }
        }

        /// public propaty name  :  ErrorCntStockout
        /// <summary>�G���[����(�݌Ƀ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�݌Ƀ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntStock
        {
            get { return _errorCntStock; }
            set { _errorCntStock = value; }
        }

        /// public propaty name  :  GoodsStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(���i�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(���i�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsStatusErrCSV
        {
            get { return _goodsStatusErrCSV; }
            set { _goodsStatusErrCSV = value; }
        }

        /// public propaty name  :  PriceStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(���i�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(���i�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStatusErrCSV
        {
            get { return _priceStatusErrCSV; }
            set { _priceStatusErrCSV = value; }
        }

        /// public propaty name  :  StockStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�݌Ƀ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�݌Ƀ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockStatusErrCSV
        {
            get { return _stockStatusErrCSV; }
            set { _stockStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntMng
        /// <summary>�Ǎ�����(���i�Ǘ����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(���i�Ǘ����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntMng
        {
            get { return _readCntMng; }
            set { _readCntMng = value; }
        }

        /// public propaty name  :  LoadCntMng
        /// <summary>�X�V����(���i�Ǘ����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(���i�Ǘ����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntMng
        {
            get { return _loadCntMng; }
            set { _loadCntMng = value; }
        }

        /// public propaty name  :  ErrorCntMng
        /// <summary>�G���[����(���i�Ǘ����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(���i�Ǘ����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntMng
        {
            get { return _errorCntMng; }
            set { _errorCntMng = value; }
        }

        /// public propaty name  :  MngStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(���i�Ǘ����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(���i�Ǘ����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MngStatusErrCSV
        {
            get { return _mngStatusErrCSV; }
            set { _mngStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntRate
        /// <summary>�Ǎ�����(�|���}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�|���}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntRate
        {
            get { return _readCntRate; }
            set { _readCntRate = value; }
        }

        /// public propaty name  :  LoadCntRate
        /// <summary>�X�V����(�|���}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�|���}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntRate
        {
            get { return _loadCntRate; }
            set { _loadCntRate = value; }
        }

        /// public propaty name  :  ErrorCntRate
        /// <summary>�G���[����(�|���}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�|���}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntRate
        {
            get { return _errorCntRate; }
            set { _errorCntRate = value; }
        }

        /// public propaty name  :  RateStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�|���}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�|���}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateStatusErrCSV
        {
            get { return _rateStatusErrCSV; }
            set { _rateStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntJoin
        /// <summary>�Ǎ�����(�����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntJoin
        {
            get { return _readCntJoin; }
            set { _readCntJoin = value; }
        }

        /// public propaty name  :  LoadCntJoin
        /// <summary>�X�V����(�����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntJoin
        {
            get { return _loadCntJoin; }
            set { _loadCntJoin = value; }
        }

        /// public propaty name  :  ErrorCntJoin
        /// <summary>�G���[����(�����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCntJoin
        {
            get { return _errorCntJoin; }
            set { _errorCntJoin = value; }
        }

        /// public propaty name  :  JoinStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�����}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�����}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinStatusErrCSV
        {
            get { return _joinStatusErrCSV; }
            set { _joinStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntParts
        /// <summary>�Ǎ�����(��փ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(��փ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntParts
        {
            get { return _readCntParts; }
            set { _readCntParts = value; }
        }

        /// public propaty name  :  LoadCntParts
        /// <summary>�X�V����(��փ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(��փ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntParts
        {
            get { return _loadCntParts; }
            set { _loadCntParts = value; }
        }

        /// public propaty name  :  ErrCntParts
        /// <summary>�G���[����(��փ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(��փ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntParts
        {
            get { return _errCntParts; }
            set { _errCntParts = value; }
        }

        /// public propaty name  :  PartsStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(��փ}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(��փ}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsStatusErrCSV
        {
            get { return _partsStatusErrCSV; }
            set { _partsStatusErrCSV = value; }
        }

        /// public propaty name  :  ReadCntSet
        /// <summary>�Ǎ�����(�Z�b�g�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�Z�b�g�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntSet
        {
            get { return _readCntSet; }
            set { _readCntSet = value; }
        }

        /// public propaty name  :  LoadCntSet
        /// <summary>�X�V����(�Z�b�g�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�Z�b�g�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntSet
        {
            get { return _loadCntSet; }
            set { _loadCntSet = value; }
        }

        /// public propaty name  :  ErrCntSet
        /// <summary>�G���[����(�Z�b�g�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�Z�b�g�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntSet
        {
            get { return _errCntSet; }
            set { _errCntSet = value; }
        }

        /// public propaty name  :  SetStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�Z�b�g�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�Z�b�g�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetStatusErrCSV
        {
            get { return _setStatusErrCSV; }
            set { _setStatusErrCSV = value; }
        }

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// public propaty name  :  ReadCntPrm
        /// <summary>�Ǎ�����(�D�ǐݒ�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�D�ǐݒ�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntPrm
        {
            get { return _readCntPrm; }
            set { _readCntPrm = value; }
        }

        /// public propaty name  :  LoadCntPrm
        /// <summary>�X�V����(�D�ǐݒ�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�D�ǐݒ�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntPrm
        {
            get { return _loadCntPrm; }
            set { _loadCntPrm = value; }
        }

        /// public propaty name  :  ErrCntPrm
        /// <summary>�G���[����(�D�ǐݒ�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�D�ǐݒ�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntPrm
        {
            get { return _errCntPrm; }
            set { _errCntPrm = value; }
        }

        /// public propaty name  :  PrmStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�D�ǐݒ�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�D�ǐݒ�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmStatusErrCSV
        {
            get { return _prmStatusErrCSV; }
            set { _prmStatusErrCSV = value; }
        }
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        /// public propaty name  :  ReadCntShipment
        /// <summary>�Ǎ�����(�ݏo�ϊ�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ�����(�ݏo�ϊ�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCntShipment
        {
            get { return _readCntShipment; }
            set { _readCntShipment = value; }
        }

        /// public propaty name  :  LoadCntShipment
        /// <summary>�X�V����(�ݏo�ϊ�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(�ݏo�ϊ�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoadCntShipment
        {
            get { return _loadCntShipment; }
            set { _loadCntShipment = value; }
        }

        /// public propaty name  :  ErrCntShipment
        /// <summary>�G���[����(�ݏo�ϊ�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[����(�ݏo�ϊ�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrCntShipment
        {
            get { return _errCntShipment; }
            set { _errCntShipment = value; }
        }

        /// public propaty name  :  ShipmentStatusErrCSV
        /// <summary>�t�@�C���X�e�[�^�X(�ݏo�ϊ�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���X�e�[�^�X(�ݏo�ϊ�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentStatusErrCSV
        {
            get { return _shipmentStatusErrCSV; }
            set { _shipmentStatusErrCSV = value; }
        }



        /// <summary>
        /// �ϊ��������ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsChangeResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsChangeResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsChangeResultWork()
        {
        }

    }
}

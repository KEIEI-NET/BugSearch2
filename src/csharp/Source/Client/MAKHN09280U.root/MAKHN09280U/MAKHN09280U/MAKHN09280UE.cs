//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���i�݌Ƀ}�X�^
// �v���O�����T�v   : ���i�݌ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : caohh
// �C �� ��  2011/08/02  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhangy3
// �C �� ��  2012/12/01  �C�����e : 2013/01/16�z�M����Q��#33231 ���i�݌Ƀ}�X�^
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>UpdateNote : 2012/12/01 zhangy3</br>
    /// <br>           : 2013/01/16�z�M��</br>
    /// <br>           : Redmine#33231 ���i�݌Ƀ}�X�^</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsStockInputConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private int _saveInfoDiv;
        private int _goodsNoMakerInfo;
        private int _goodsInfo;
        private int _priceInfo;
        private int _unitPriceInfo;
        private int _stockInfo;
        private int _activeMode;//Add 2012/12/01 zhangy3 for Redmine#33231

        private const int DEFAULT_SAVEINFODIV = 0;
        private const int DEFAULT_GOODSNOMAKERINFO = 0;
        private const int DEFAULT_GOODSINFO = 0;
        private const int DEFAULT_PRICEINFO = 0;
        private const int DEFAULT_UNITPRICEINFO = 0;
        private const int DEFAULT_STOCKINFO = 0;
        private const int DEFAULT_ACTIVEMODE = 0;//Add 2012/12/01 zhangy3 for Redmine#33231
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// </remarks>
        public GoodsStockInputConstruction()
        {
            this._saveInfoDiv = DEFAULT_SAVEINFODIV;
            this._goodsNoMakerInfo = DEFAULT_GOODSNOMAKERINFO;
            this._goodsInfo = DEFAULT_GOODSINFO;
            this._priceInfo = DEFAULT_PRICEINFO;
            this._unitPriceInfo = DEFAULT_UNITPRICEINFO;
            this._stockInfo = DEFAULT_STOCKINFO;
            this._activeMode = DEFAULT_ACTIVEMODE;//Add 2012/12/01 zhangy3 for Redmine#33231
        }

        /// <summary>
		/// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
		/// </remarks>
        //public GoodsStockInputConstruction(int saveInfoDiv, int goodsNoMakerInfo, int goodsInfo, int priceInfo, int unitPriceInfo, int stockInfo)//Del 2012/12/01 zhangy3 for Redmine#33231
        public GoodsStockInputConstruction(int saveInfoDiv, int goodsNoMakerInfo, int goodsInfo, int priceInfo, int unitPriceInfo, int stockInfo, int activeMode)
		{
            this._saveInfoDiv = saveInfoDiv;
            this._goodsNoMakerInfo = goodsNoMakerInfo;
            this._goodsInfo = goodsInfo;
            this._priceInfo = priceInfo;
            this._unitPriceInfo = unitPriceInfo;
            this._stockInfo = stockInfo;
            this._activeMode = activeMode;//Add 2012/12/01 zhangy3 for Redmine#33231
		}
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�ۑ��O���敪�v���p�e�B</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }

        /// <summary>�i�ԁE���[�J�[���v���p�e�B</summary>
        public int GoodsNoMakerInfo
        {
            get { return this._goodsNoMakerInfo; }
            set { this._goodsNoMakerInfo = value; }
        }

        /// <summary>���i���v���p�e�B</summary>
        public int GoodsInfo
        {
            get { return this._goodsInfo; }
            set { this._goodsInfo = value; }
        }

        /// <summary>���i���v���p�e�B</summary>
        public int PriceInfo
        {
            get { return this._priceInfo; }
            set { this._priceInfo = value; }
        }

        /// <summary>�P�i�����v���p�e�B</summary>
        public int UnitPriceInfo
        {
            get { return this._unitPriceInfo; }
            set { this._unitPriceInfo = value; }
        }

        /// <summary>�݌ɏ�񃍃p�e�B</summary>
        public int StockInfo
        {
            get { return this._stockInfo; }
            set { this._stockInfo = value; }
        }
        // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
        /// <summary>�N������</summary>
        public int ActiveMode
        {
            get { return this._activeMode; }
            set { this._activeMode = value; }
        }
        // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
        # endregion

        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X</returns>
        public GoodsStockInputConstruction Clone()
        {
            //return new GoodsStockInputConstruction(this._saveInfoDiv, this._goodsNoMakerInfo, this._goodsInfo, this._priceInfo, this._unitPriceInfo, this._stockInfo);//Del 2012/12/01 zhangy3 for Redmine#33231
            return new GoodsStockInputConstruction(this._saveInfoDiv, this._goodsNoMakerInfo, this._goodsInfo, this._priceInfo, this._unitPriceInfo, this._stockInfo, this._activeMode);//Add 2012/12/01 zhangy3 for Redmine#33231
        }
    }

    /// <summary>
    /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>Update Note: 2012/12/01 zhangy3�@</br>
    /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
    /// <br></br>
    /// </remarks>
    public class GoodsStockInputConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private static GoodsStockInputConstruction _goodsStockInputConstruction;
        private const string XML_FILE_NAME = "MAKHN09280U_Construction.XML";
        private const int DEFAULT_KEEPONINFO = 0;
        private List<int> _keepOnInfo;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// </remarks>
        public GoodsStockInputConstructionAcs()
        {
            if (_goodsStockInputConstruction == null)
            {
                _goodsStockInputConstruction = new GoodsStockInputConstruction();
            }

            _keepOnInfo = new List<int>();
            //for (int i = 0; i < 5; i++) //Del 2012/12/01 zhangy3 for Redmine#33231
            for (int i = 0; i < 6; i++) //Add 2012/12/01 zhangy3 for Redmine#33231
            {
                _keepOnInfo.Add(DEFAULT_KEEPONINFO);
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�ۑ��O���敪�v���p�e�B</summary>
        public int SaveInfoDiv
        {
            get
            {
                if (_goodsStockInputConstruction == null)
                {
                    _goodsStockInputConstruction = new GoodsStockInputConstruction();
                }
                return _goodsStockInputConstruction.SaveInfoDiv;
            }
            set
            {
                if (_goodsStockInputConstruction == null)
                {
                    _goodsStockInputConstruction = new GoodsStockInputConstruction();
                }
                _goodsStockInputConstruction.SaveInfoDiv = value;
            }
        }

        /// <summary>�ۑ��O���ێ��v���p�e�B</summary>
        public List<int> KeepOnInfo
        {
            get
            {
                return this._keepOnInfo;
            }
            set
            {
                this._keepOnInfo = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// </remarks>
        public void Serialize()
        {
            if (_keepOnInfo.Count > 0) 
            {
                _goodsStockInputConstruction.GoodsNoMakerInfo = _keepOnInfo[0];
                _goodsStockInputConstruction.GoodsInfo = _keepOnInfo[1];
                _goodsStockInputConstruction.PriceInfo = _keepOnInfo[2];
                _goodsStockInputConstruction.UnitPriceInfo = _keepOnInfo[3];
                _goodsStockInputConstruction.StockInfo = _keepOnInfo[4];
                _goodsStockInputConstruction.ActiveMode = _keepOnInfo[5];//Add 2012/12/01 zhangy3 for Redmine#33231
            }
            UserSettingController.SerializeUserSetting(_goodsStockInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }

        /// <summary>
        /// ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A��265 ���i�݌Ƀ}�X�^��ʗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3�@</br>
        /// <br>           : 2013/01/16�z�M�� Redmine#33231 ���i�݌Ƀ}�X�^</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _goodsStockInputConstruction = UserSettingController.DeserializeUserSetting<GoodsStockInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                _keepOnInfo = new List<int>();
                _keepOnInfo.Add(_goodsStockInputConstruction.GoodsNoMakerInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.GoodsInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.PriceInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.UnitPriceInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.StockInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.ActiveMode);//Add 2012/12/01 zhangy3 for Redmine#33231
            }
        }
        # endregion
    }
}

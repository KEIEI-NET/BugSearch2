using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 ExtrInfo_MAMOK09137EA
    /// <summary>
    /// 					 ���i�ʔ���ڕW���������ݒ�p�����[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 ���i�ʔ���ڕW���������ݒ�p�����[�^�t�@�C��</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note		 :   2007.11.21 ��� �O�M</br>
	/// <br>                     ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br></br>
    /// </remarks>
    [Serializable]
    public class ExtrInfo_MAMOK09137EA
    {
        #region Private Member

        /// <summary>��ƃR�[�h</summary>
        private String _enterpriseCode = "";

        /// <summary>�I�����_�R�[�h</summary>
        private String[] _selectSectCd;

        /// <summary>�S�БI��</summary>
        private Boolean _allSecSelEpUnit;

        /// <summary>�S���_���R�[�h�o��</summary>
        private Boolean _allSecSelSecUnit;

        /// <summary>�ڕW�ݒ�敪</summary>
        private Int32 _targetSetCd;

        /// <summary>�ڕW�Δ�敪</summary>
        private Int32 _targetContrastCd;

        /// <summary>�ڕW�敪�R�[�h</summary>
        private String _targetDivideCode = "";

        /// <summary>�ڕW�敪����</summary>
        private String _targetDivideName = "";

        /// <summary>�K�p�J�n��(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDateSt;

        /// <summary>�K�p�J�n��(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDateEd;

        /// <summary>�K�p�I����(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDateSt;

        /// <summary>�K�p�I����(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDateEd;

		//----- ueno del---------- start 2007.11.21
		///// <summary>�L�����A�R�[�h</summary>
		//private Int32 _carrierCode = -1;

		///// <summary>�@��R�[�h</summary>
		//private string _cellphoneModelCode = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode = -1;

        /// <summary>���i�R�[�h</summary>
        private String _goodsCode = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        // BL�O���[�v�R�[�h
        private Int32 _bLGroupCode;
        // BL�O���[�v��
        private string _bLGroupName;
        // BL�R�[�h
        private Int32 _bLGoodsCode;
        // BL�R�[�h��
        private string _bLCodeName;
        // �̔��敪
        private Int32 _salesCode;
        // �̔��敪��
        private string _salesCdNm;
        // ���i�敪
        private Int32 _enterpriseGanreCode;
        // ���i�敪��
        private string _enterpriseGanreName;

        // �Ǝ햼
        private string _businessTypeName;
        // �̔��G���A��
        private string _salesAreaName;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String EnterpriseCode
        {
            get
            {
                return _enterpriseCode;
            }
            set
            {
                _enterpriseCode = value;
            }
        }

        /// public propaty name  :	SelectSectCd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String[] SelectSectCd
        {
            get
            {
                return _selectSectCd;
            }
            set
            {
                _selectSectCd = value;
            }
        }

        /// public propaty name  :  AllSecSelEpUnit
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S�БI���v���p�e�B</br>
        /// <br>Programer        :   NEPCO</br>
        /// </remarks>
        public Boolean AllSecSelEpUnit
        {
            get
            {
                return _allSecSelEpUnit;
            }
            set
            {
                _allSecSelEpUnit = value;
            }
        }

        /// public propaty name  :  AllSecSelSecUnit
        /// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
        /// <br>Programer        :   NEPCO</br>
        /// </remarks>
        public Boolean AllSecSelSecUnit
        {
            get
            {
                return _allSecSelSecUnit;
            }
            set
            {
                _allSecSelSecUnit = value;
            }
        }

        /// public propaty name  :	TargetSetCd
        /// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�ݒ�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get
            {
                return _targetSetCd;
            }
            set
            {
                _targetSetCd = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	TargetDivideCode
        /// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String TargetDivideCode
        {
            get
            {
                return _targetDivideCode;
            }
            set
            {
                _targetDivideCode = value;
            }
        }

        /// public propaty name  :	TargetDivideName
        /// <summary>�ڕW�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�敪���̃v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String TargetDivideName
        {
            get
            {
                return _targetDivideName;
            }
            set
            {
                _targetDivideName = value;
            }
        }

        /// public propaty name  :	ApplyStaDateSt
        /// <summary>�K�p�J�n��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDateSt
        {
            get
            {
                return _applyStaDateSt;
            }
            set
            {
                _applyStaDateSt = value;
            }
        }

        /// public propaty name  :	ApplyStaDateEd
        /// <summary>�K�p�J�n��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDateEd
        {
            get
            {
                return _applyStaDateEd;
            }
            set
            {
                _applyStaDateEd = value;
            }
        }

        /// public propaty name  :	ApplyStaDateSt
        /// <summary>�K�p�I����(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDateSt
        {
            get
            {
                return _applyEndDateSt;
            }
            set
            {
                _applyEndDateSt = value;
            }
        }

        /// public propaty name  :	ApplyStaDateEd
        /// <summary>�K�p�I����(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDateEd
        {
            get
            {
                return _applyEndDateEd;
            }
            set
            {
                _applyEndDateEd = value;
            }
        }

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	CarrierCode
		///// <summary>�L�����A�R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �]�ƈ��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int32 CarrierCode
		//{
		//    get
		//    {
		//        return _carrierCode;
		//    }
		//    set
		//    {
		//        _carrierCode = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelCode
		///// <summary>�@��R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �@��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelCode
		//{
		//    get
		//    {
		//        return _cellphoneModelCode;
		//    }
		//    set
		//    {
		//        _cellphoneModelCode = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get
            {
                return _makerCode;
            }
            set
            {
                _makerCode = value;
            }
        }

        /// public propaty name  :	GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String GoodsCode
        {
            get
            {
                return _goodsCode;
            }
            set
            {
                _goodsCode = value;
            }
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { this._bLGroupCode = value; }
        }
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { this._bLGroupName = value; }
        }

        public Int32 BLCode
        {
            get { return _bLGoodsCode; }
            set { this._bLGoodsCode = value; }
        }

        public string BLCodeName
        {
            get { return _bLCodeName; }
            set { this._bLCodeName = value; }
        }

        public Int32 SalesTypeCode
        {
            get { return _salesCode; }
            set { this._salesCode = value; }
        }

        public string SalesTypeName
        {
            get { return _salesCdNm; }
            set { this._salesCdNm = value; }
        }

        public Int32 ItemTypeCode
        {
            get { return _enterpriseGanreCode; }
            set { this._enterpriseGanreCode = value; }
        }

        public string ItemTypeName
        {
            get { return _enterpriseGanreName; }
            set { this._enterpriseGanreName = value; }
        }

        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { this._businessTypeName = value; }
        }

        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { this._salesAreaName = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

        #endregion Public Propaty

        #region �R���X�g���N�^

        /// <summary>
        /// ���㌎�ԖڕW�ݒ�}�X�^���������R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_MAMOK09157EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA()
        {
        }

        /// <summary>
        /// ���㌎�ԖڕW�ݒ�}�X�^���������R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="selectSectCd">�I�����_�R�[�h</param>
        /// <param name="allSecSelEpUnit">�S�БI��</param>
        /// <param name="allSecSelSecUnit">�S���_���R�[�h�o��</param>
        /// <param name="targetSetCd">�ڕW�ݒ�敪</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪</param>
        /// <param name="targetDivideCode">�ڕW�敪�R�[�h</param>
        /// <param name="targetDivideName">�ڕW�敪����</param>
        /// <param name="applyStaDateSt">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyStaDateEd">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDateSt">�K�p�I����(YYYYMMDD)</param>
        /// <param name="applyEndDateEd">�K�p�I����(YYYYMMDD)</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <returns>ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_MAMOK09157EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA(
            String enterpriseCode,
            String[] selectSectCd,
            Boolean allSecSelEpUnit,
            Boolean allSecSelSecUnit,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            String targetDivideCode,
            String targetDivideName,
            DateTime applyStaDateSt,
            DateTime applyStaDateEd,
            DateTime applyEndDateSt,
            DateTime applyEndDateEd,
			//----- ueno del---------- start 2007.11.21
			//Int32 carrierCode,
            //String cellphoneModelCode,
			//----- ueno del---------- end 2007.11.21
            Int32 makerCode,
            String goodsCode,
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            Int32 blGroupCode,
            string blGroupName,
            Int32 blCode,
            string blCodeName,
            Int32 salesTypeCode,
            string salesTypeName,
            Int32 itemTypeCode,
            string itemTypeName,
            string businessTypeName,
            string salesAreaName
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

        )
        {
            this._enterpriseCode = enterpriseCode;
            this._selectSectCd = selectSectCd;
            this._allSecSelEpUnit = allSecSelEpUnit;
            this._allSecSelSecUnit = allSecSelSecUnit;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._applyStaDateSt = applyStaDateSt;
            this._applyStaDateEd = applyStaDateEd;
            this._applyEndDateSt = applyEndDateSt;
            this._applyEndDateEd = applyEndDateEd;
			//----- ueno del---------- start 2007.11.21
			//this._carrierCode = carrierCode;
            //this._cellphoneModelCode = cellphoneModelCode;
			//----- ueno del---------- end   2007.11.21            
            this._makerCode = makerCode;
            this._goodsCode = goodsCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._bLGroupCode = blGroupCode;
            this._bLGroupName = blGroupName;
            this._bLGoodsCode = blCode;
            this._bLCodeName = blCodeName;
            this._salesCode = salesTypeCode;
            this._salesCdNm = salesTypeName;
            this._enterpriseGanreCode = itemTypeCode;
            this._enterpriseGanreName = itemTypeName;
            this._businessTypeName = businessTypeName;
            this._salesAreaName = salesAreaName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
        }

        #endregion �R���X�g���N�^

        #region Public Method

        /// <summary>
        /// ���㌎�ԖڕW�ݒ�}�X�^����������������
        /// </summary>
        /// <returns>ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA Clone()
        {
            return new ExtrInfo_MAMOK09137EA(
                               this._enterpriseCode,
                               this._selectSectCd,
                               this._allSecSelEpUnit,
                               this._allSecSelSecUnit,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._applyStaDateSt,
                               this._applyStaDateEd,
                               this._applyEndDateSt,
                               this._applyEndDateEd,
							   //----- ueno del---------- start 2007.11.21
							   //this._carrierCode,
                               //this._cellphoneModelCode,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._goodsCode,
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                               this._bLGroupCode,
                               this._bLGroupName,
                               this._bLGoodsCode,
                               this._bLCodeName,
                               this._salesCode,
                               this._salesCdNm,
                               this._enterpriseGanreCode,
                               this._enterpriseGanreName,
                               this._businessTypeName,
                               this._salesAreaName
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
                               );
        }

        /// <summary>
        /// ���㌎�ԖڕW�ݒ�}�X�^����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_MAMOK09157EA�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(ExtrInfo_MAMOK09137EA target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SelectSectCd == target.SelectSectCd)
                 && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
                 && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
                 && (this.ApplyStaDateSt == target.ApplyStaDateSt)
                 && (this.ApplyStaDateEd == target.ApplyStaDateEd)
                 && (this.ApplyEndDateSt == target.ApplyEndDateSt)
                 && (this.ApplyEndDateEd == target.ApplyEndDateEd)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.CarrierCode == target.CarrierCode)
                 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.GoodsCode == target.GoodsCode)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLCode == target.BLCode)
                 && (this.BLCodeName == target.BLCodeName)
                 && (this.SalesTypeCode == target.SalesTypeCode)
                 && (this.SalesTypeName == target.SalesTypeName)
                 && (this.ItemTypeCode == target.ItemTypeCode)
                 && (this.ItemTypeName == target.ItemTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
                 );
        }

        #endregion Public Method

    }
}

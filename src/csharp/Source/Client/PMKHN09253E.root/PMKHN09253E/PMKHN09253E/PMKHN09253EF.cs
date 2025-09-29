using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 SearchGcdSalesTargetPara
    /// <summary>
    /// 					 ���i�ʔ���ڕW���������N���X
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 ���i�ʔ���ڕW���������t�@�C��</br>
    /// <br>Programmer		 :	 30414 �E �K�j</br>
    /// <br>Date			 :	 2008/10/08</br>
    /// <br></br>
    /// </remarks>
    public class SearchGcdSalesTargetPara
    {
        #region Private Member

        /// <summary>��ƃR�[�h</summary>
        private String _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        private Int32 _logicalDeleteCode;

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
        private DateTime _startApplyStaDate;

        /// <summary>�K�p�J�n��(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyStaDate;

        /// <summary>�K�p�I����(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _startApplyEndDate;

        /// <summary>�K�p�I����(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyEndDate;

        /// <summary>BL�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�i��</summary>
        private String _goodsNo;

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �_���폜�敪�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get
            {
                return _logicalDeleteCode;
            }
            set
            {
                _logicalDeleteCode = value;
            }
        }

        /// public propaty name  :	SelectSectCd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	AllSecSelEpUnit
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �S�БI���v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	AllSecSelSecUnit
        /// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �S���_���R�[�h�o�̓v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	StartApplyStaDate
        /// <summary>�K�p�J�n��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime StartApplyStaDate
        {
            get
            {
                return _startApplyStaDate;
            }
            set
            {
                _startApplyStaDate = value;
            }
        }

        /// public propaty name  :	EndApplyStaDate
        /// <summary>�K�p�J�n��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime EndApplyStaDate
        {
            get
            {
                return _endApplyStaDate;
            }
            set
            {
                _endApplyStaDate = value;
            }
        }

        /// public propaty name  :	StartApplyStaDate
        /// <summary>�K�p�I����(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime StartApplyEndDate
        {
            get
            {
                return _startApplyEndDate;
            }
            set
            {
                _startApplyEndDate = value;
            }
        }

        /// public propaty name  :	EndApplyStaDate
        /// <summary>�K�p�I����(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime EndApplyEndDate
        {
            get
            {
                return _endApplyEndDate;
            }
            set
            {
                _endApplyEndDate = value;
            }
        }

        /// public propaty name  :	BLGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 BL�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get
            {
                return _bLGoodsCode;
            }
            set
            {
                _bLGoodsCode = value;
            }
        }

        /// public propaty name  :	BLGroupCode
        /// <summary>�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get
            {
                return _bLGroupCode;
            }
            set
            {
                _bLGroupCode = value;
            }
        }

        /// public propaty name  :	GoodsMakerCd
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get
            {
                return _goodsMakerCd;
            }
            set
            {
                _goodsMakerCd = value;
            }
        }

        /// public propaty name  :	GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �i�ԃv���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public String GoodsNo
        {
            get
            {
                return _goodsNo;
            }
            set
            {
                _goodsNo = value;
            }
        }

        /// public propaty name  :	EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get
            {
                return _enterpriseGanreCode;
            }
            set
            {
                _enterpriseGanreCode = value;
            }
        }

        /// public propaty name  :	SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get
            {
                return _salesCode;
            }
            set
            {
                _salesCode = value;
            }
        }

        #endregion Public Propaty

        #region �R���X�g���N�^
        /// <summary>
        /// ���i�ʔ���ڕW���������R���X�g���N�^
        /// </summary>
        /// <returns>SearchGcdSalesTargetPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 SearchGcdSalesTargetPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara()
        {
        }


        /// <summary>
        /// ���i�ʔ���ڕW���������R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="selectSectCd">�I�����_�R�[�h</param>
        /// <param name="allSecSelEpUnit">�S�БI��</param>
        /// <param name="allSecSelSecUnit">�S���_���R�[�h�o��</param>
        /// <param name="targetSetCd">�ڕW�ݒ�敪</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪</param>
        /// <param name="targetDivideCode">�ڕW�敪�R�[�h</param>
        /// <param name="targetDivideName">�ڕW�敪����</param>
        /// <param name="startApplyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="endApplyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="startApplyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="endApplyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="bLGroupCode">�O���[�v�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <returns>SearchGcdSalesTargetPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 SearchGcdSalesTargetPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara(
            String enterpriseCode,
            Int32 logicalDeleteCode,
            String[] selectSectCd,
            Boolean allSecSelEpUnit,
            Boolean allSecSelSecUnit,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            String targetDivideCode,
            String targetDivideName,
            DateTime startApplyStaDate,
            DateTime endApplyStaDate,
            DateTime startApplyEndDate,
            DateTime endApplyEndDate,
            Int32 bLGoodsCode,
            Int32 bLGroupCode,
            Int32 goodsMakerCd,
            String goodsNo,
            Int32 enterpriseGanreCode,
            Int32 salesCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._selectSectCd = selectSectCd;
            this._allSecSelEpUnit = allSecSelEpUnit;
            this._allSecSelSecUnit = allSecSelSecUnit;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._startApplyStaDate = startApplyStaDate;
            this._endApplyStaDate = endApplyStaDate;
            this._startApplyEndDate = startApplyEndDate;
            this._endApplyEndDate = endApplyEndDate;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGroupCode = bLGroupCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._salesCode = salesCode;
        }

        #endregion �R���X�g���N�^

        #region Public Method

        /// <summary>
        /// ���i�ʔ���ڕW����������������
        /// </summary>
        /// <returns>SearchGcdSalesTargetPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����SearchGcdSalesTargetPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara Clone()
        {
            return new SearchGcdSalesTargetPara(
                               this._enterpriseCode,
                               this._logicalDeleteCode,
                               this._selectSectCd,
                               this._allSecSelEpUnit,
                               this._allSecSelSecUnit,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._startApplyStaDate,
                               this._endApplyStaDate,
                               this._startApplyEndDate,
                               this._endApplyEndDate,
                               this._bLGoodsCode,
                               this._bLGroupCode,
                               this._goodsMakerCd,
                               this._goodsNo,
                               this._enterpriseGanreCode,
                               this._salesCode);
        }

        /// <summary>
        /// ���i�ʔ���ڕW����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchGcdSalesTargetPara�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 SearchGcdSalesTargetPara�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 30414 �E �K�j</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public bool Equals(SearchGcdSalesTargetPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                    && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                    && (this.SelectSectCd == target.SelectSectCd)
                    && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
                    && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
                    && (this.TargetSetCd == target.TargetSetCd)
                    && (this.TargetContrastCd == target.TargetContrastCd)
                    && (this.TargetDivideCode == target.TargetDivideCode)
                    && (this.TargetDivideName == target.TargetDivideName)
                    && (this.StartApplyStaDate == target.StartApplyStaDate)
                    && (this.EndApplyStaDate == target.EndApplyStaDate)
                    && (this.StartApplyEndDate == target.StartApplyEndDate)
                    && (this.EndApplyEndDate == target.EndApplyEndDate)
                    && (this.BLGoodsCode == target.BLGoodsCode)
                    && (this.BLGroupCode == target.BLGroupCode)
                    && (this.GoodsMakerCd == target.GoodsMakerCd)
                    && (this.GoodsNo == target.GoodsNo)
                    && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                    && (this.SalesCode == target.SalesCode));
        }

        #endregion Public Method

    }
}

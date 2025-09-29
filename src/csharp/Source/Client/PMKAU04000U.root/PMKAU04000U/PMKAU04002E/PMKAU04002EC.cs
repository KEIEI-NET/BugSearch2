using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����Ɏg�p����\���̃N���X
    /// </summary>
    public class PrintCndtn
    {
        #region �v���C�x�[�g�ϐ�

        /// <summary>���[���</summary>
        private Int32 _layoutType = 0;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCd = "";

        /// <summary>���_��</summary>
        private string _sectionName = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private string _customerCd = "";

        /// <summary>���Ӑ於</summary>
        private string _customerName = "";

        /// <summary>�J�n���t</summary>
        private DateTime _startDt;

        /// <summary>�I�����t</summary>
        private DateTime _endDt;

        /// <summary>���ߓ�</summary>
        private DateTime _totalDt;
        

        /// <summary>�O�񐿋��c��</summary>
        private Int64 _lastTimeDemand = 0;

        /// <summary>�����z</summary>
        private Int64 _thisTimeDmdNrml = 0;

        /// <summary>�J�z���z</summary>
        private Int64 _forwardedAmount = 0;

        /// <summary>���񔄏�z</summary>
        private Int64 _thisSalesPriceTotal = 0;

        /// <summary>�����</summary>
        private Int64 _ofsThisSalesTax = 0;

        /// <summary>�ō����z</summary>
        private Int64 _totalAmount = 0;

        /// <summary>�����c��</summary>
        private Int64 _afCalBlc = 0;

        /// <summary>�`�[����</summary>
        private Int64 _slipCount = 0;

        //-----ADD 2011/10/27----->>>>>
        /// <summary>�����\���敪</summary>
        private Int32 _genKaDispDiv = 0;
        //-----ADD 2011/10/27-----<<<<<
        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        /// <summary>���_�R�[�h</summary>
        public Int32 LayoutType
        {
            get { return this._layoutType; }
            set { this._layoutType = value; }
        }

        /// <summary>���_�R�[�h</summary>
        public string SectionCd
        {
            get { return this._sectionCd; }
            set { this._sectionCd = value; }
        }

        /// <summary>���_��</summary>
        public string SectionName
        {
            get { return this._sectionName; }
            set { this._sectionName = value; }
        }

        /// <summary>���Ӑ�R�[�h</summary>
        public string CustomerCd
        {
            get { return this._customerCd; }
            set { this._customerCd = value; }
        }

        /// <summary>���Ӑ於</summary>
        public string CustomerName
        {
            get { return this._customerName; }
            set { this._customerName = value; }
        }

        /// <summary>�J�n���t</summary>
        public DateTime StartDt
        {
            get { return this._startDt; }
            set { this._startDt = value; }
        }

        /// <summary>�I�����t</summary>
        public DateTime EndDt
        {
            get { return this._endDt; }
            set { this._endDt = value; }
        }

        /// <summary>���ߓ�</summary>
        public DateTime TotalDt
        {
            get { return this._totalDt; }
            set { this._totalDt = value; }
        }

        /// <summary>�O�񐿋��c��</summary>
        public Int64 LastTimeDemand
        {
            get { return this._lastTimeDemand; }
            set { this._lastTimeDemand = value; }
        }

        /// <summary>�����z</summary>
        public Int64 ThisTimeDmdNrml
        {
            get { return this._thisTimeDmdNrml; }
            set { this._thisTimeDmdNrml = value; }
        }

        /// <summary>�J�z���z</summary>
        /// <remarks>�O�񐿋��c�� - �����z</remarks>
        public Int64 ForwardedAmount
        {
            get { return this._forwardedAmount; }
            set { this._forwardedAmount = value; }
        }

        /// <summary>���񔄏�z</summary>
        public Int64 ThisSalesPriceTotal
        {
            get { return this._thisSalesPriceTotal; }
            set { this._thisSalesPriceTotal = value; }
        }

        /// <summary>�����</summary>
        public Int64 OfsThisSalesTax
        {
            get { return this._ofsThisSalesTax; }
            set { this._ofsThisSalesTax = value; }
        }

        /// <summary>�ō����z</summary>
        /// <remarks>���񔄏�z + �����</remarks>
        public Int64 TotalAmount
        {
            get { return this._totalAmount; }
            set { this._totalAmount = value; }
        }

        /// <summary>�����c��</summary>
        public Int64 AfCalBlc
        {
            get { return this._afCalBlc; }
            set { this._afCalBlc = value; }
        }

        /// <summary>�`�[����</summary>
        public Int64 SlipCount
        {
            get { return this._slipCount; }
            set { this._slipCount = value; }
        }

        //-----ADD 2011/10/27----->>>>>
        /// <summary>�����\���敪</summary>
        public Int32 GenKaDispDiv
        {
            get { return this._genKaDispDiv; }
            set { this._genKaDispDiv = value; }
        }
        //-----ADD 2011/10/27-----<<<<<
        #endregion // �v���p�e�B

        #region �R���X�g���N�^

        public PrintCndtn()
        {

        }

        #endregion // �R���X�g���N�^
    }
}

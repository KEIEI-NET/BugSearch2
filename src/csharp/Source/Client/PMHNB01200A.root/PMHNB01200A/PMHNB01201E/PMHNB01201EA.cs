using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����f�[�^�p�q���M��������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�p�q���M����̏��������N���X�ł��B����`�[��KEY����n���Ɏg�p���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    public class SalesQRSendCtrlCndtn
    {
        # region [�t�B�[���h]
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�j�d�x���X�g</summary>
        private List<QRSendCtrlSalesSlipKey> _salesSlipKeyList;
        /// <summary>�v���O�����p�����[�^</summary>
        private string _programParameter;
        /// <summary>�Ĕ��s�敪</summary>
        private bool _reissueDiv;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
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
        /// ����`�[�j�d�x���X�g
        /// </summary>
        public List<QRSendCtrlSalesSlipKey> SalesSlipKeyList
        {
            get 
            {
                if ( _salesSlipKeyList == null )
                {
                    _salesSlipKeyList = new List<QRSendCtrlSalesSlipKey>();
                }
                return _salesSlipKeyList; 
            }
            set 
            { 
                _salesSlipKeyList = value; 
            }
        }
        /// <summary>
        /// �v���O�����p�����[�^
        /// </summary>
	    public string ProgramParameter
	    {
		    get { return _programParameter;}
		    set { _programParameter = value;}
	    }
        /// <summary>
        /// �Ĕ��s�敪
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get 
            {
                if ( _extrData == null )
                {
                    _extrData = new ArrayList();
                }
                return _extrData; 
            }
            set 
            { 
                _extrData = value; 
            }
        }
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesQRSendCtrlCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipKeyList">�`�[�j�d�x���X�g</param>
        /// <param name="extrData">�ǉ����</param>
        public SalesQRSendCtrlCndtn( string enterpriseCode, List<QRSendCtrlSalesSlipKey> salesSlipKeyList, string programParameter, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipKeyList = salesSlipKeyList;
            this._programParameter = programParameter;
            this._extrData = extrData;
        }
        # endregion

        # region [����`�[key]
        /// <summary>
        /// ����`�[�j�d�x���ځ@�\����
        /// </summary>
        public struct QRSendCtrlSalesSlipKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// �`�[�ԍ�
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
            /// <param name="salesSlipNum">�`�[�ԍ�</param>
            public QRSendCtrlSalesSlipKey( int acptAnOdrStatus, string salesSlipNum )
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="salesSlip">����`�[</param>
            public QRSendCtrlSalesSlipKey( SalesSlip salesSlip )
            {
                this._acptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                this._salesSlipNum = salesSlip.SalesSlipNum;
            }

        }
        # endregion
    }

}

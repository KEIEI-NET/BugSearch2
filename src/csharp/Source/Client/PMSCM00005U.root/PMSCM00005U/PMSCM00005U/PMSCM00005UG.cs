using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    #region 2012/04/24 TERASAKA DEL STA
    //    /// <summary>
    //    /// SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X�ł��B</br>
    //    /// <br>Programmer       :   ZHANGYH</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushData
    //    {
    //        /// <summary>���M���̊�ƃR�[�h</summary>
    //        private string _origEnterpriseCode;
    //
    //        /// <summary>���M���̋��_�R�[�h</summary>
    //        private string _origSectionCode;
    //
    //        /// <summary>�ԓ��t���O</summary>
    //        /// <remarks>PM.NS���ASF.NS��Publish�f�[�^����M������A���̉񓚃t���O��True��ݒ肵�āASF.NS�֒ʒm���܂�</remarks>
    //        private bool _isReply;
    //
    //        #region property method
    //        /// <summary>
    //        /// ���M���̊�ƃR�[�h
    //        /// </summary>
    //        public string OrigEnterpriseCode
    //        {
    //            get
    //            {
    //                return _origEnterpriseCode;
    //            }
    //            set
    //            {
    //                _origEnterpriseCode = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// ���M���̋��_�R�[�h
    //        /// </summary>
    //        public string OrigSectionCode
    //        {
    //            get
    //            {
    //                return _origSectionCode;
    //            }
    //            set
    //            {
    //                _origSectionCode = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// �ԓ��t���O
    //        /// </summary>
    //        public bool IsReply
    //        {
    //            get
    //            {
    //                return _isReply;
    //            }
    //            set
    //            {
    //                _isReply = value;
    //            }
    //        }
    //
    //        #endregion property method
    //    }
    //
    //    /// <summary>
    //    /// SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X(�����[�g�`�[���s�p)
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X�ł��B(�����[�g�`�[���s�p)</br>
    //    /// <br>Programmer       :   ZHOUZY</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushDataScmRtPrtDt {
    //
    //        /// <summary>�⍇������ƃR�[�h</summary>
    //        private string _inqOriginalEpCd;
    //
    //        /// <summary>�⍇�������_�R�[�h</summary>
    //        private string _inqOriginalSecCd;
    //
    //        /// <summary>�⍇�����ƃR�[�h</summary>
    //        private string _inqOtherEpCd;
    //
    //        /// <summary>�⍇���拒�_�R�[�h</summary>
    //        private string _inqOtherSecCd;
    //
    //        //zhouzy update 2011.09.13 begin
    //        ///// <summary>�⍇���ԍ�</summary>
    //        //private Int64 _inquiryNumber;
    //
    //        /// <summary>�X�V�N����</summary>
    //        private Int32 _updateDate;
    //
    //        /// <summary>�X�V�����b�~���b</summary>
    //        private Int32 _updateTime;
    //
    //        /// <summary>�`�[������</summary>
    //        private Int32 _slipPrtKind;
    //
    //        /// <summary>����`�[�ԍ�</summary>
    //        private string _salesSlipNum;
    //
    //        //zhouzy update 2011.09.13 end
    //
    //        ///// <summary>�ԓ��t���O</summary>
    //        ///// <remarks>PM.NS���ASF.NS��Publish�f�[�^����M������A���̉񓚃t���O��True��ݒ肵�āASF.NS�֒ʒm���܂�</remarks>
    //        //private bool _isReply;
    //
    //        #region property method
    //        /// <summary>
    //        /// �⍇������ƃR�[�h
    //        /// </summary>
    //        public string InqOriginalEpCd
    //        {
    //            get
    //            {
    //                return _inqOriginalEpCd;
    //            }
    //            set
    //            {
    //                _inqOriginalEpCd = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// �⍇�������_�R�[�h
    //        /// </summary>
    //        public string InqOriginalSecCd
    //        {
    //            get
    //            {
    //                return _inqOriginalSecCd;
    //            }
    //            set
    //            {
    //                _inqOriginalSecCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// �⍇�����ƃR�[�h
    //        /// </summary>
    //        public string InqOtherEpCd
    //        {
    //            get
    //            {
    //                return _inqOtherEpCd;
    //            }
    //            set
    //            {
    //                _inqOtherEpCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// �⍇���拒�_�R�[�h
    //        /// </summary>
    //        public string InqOtherSecCd
    //        {
    //            get
    //            {
    //                return _inqOtherSecCd;
    //            }
    //            set
    //            {
    //                _inqOtherSecCd = value;
    //            }
    //        }
    //
    //
    //        //zhouzy update 2011.09.13 begin
    //        ///// <summary>
    //        ///// �⍇���ԍ�
    //        ///// </summary>
    //        //public Int64 InquiryNumber
    //        //{
    //        //    get
    //        //    {
    //        //        return _inquiryNumber;
    //        //    }
    //        //    set
    //        //    {
    //        //        _inquiryNumber = value;
    //        //    }
    //        //}
    //
    //        /// <summary>
    //        /// �X�V�N����
    //        /// </summary>
    //        public Int32 UpdateDate
    //        {
    //            get
    //            {
    //                return _updateDate;
    //            }
    //            set
    //            {
    //                _updateDate = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// �X�V�����b�~���b
    //        /// </summary>
    //        public Int32 UpdateTime
    //        {
    //            get
    //            {
    //                return _updateTime;
    //            }
    //            set
    //            {
    //                _updateTime = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// �`�[������
    //        /// </summary>
    //        public Int32 SlipPrtKind
    //        {
    //            get
    //            {
    //                return _slipPrtKind;
    //            }
    //            set
    //            {
    //                _slipPrtKind = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// ����`�[�ԍ�
    //        /// </summary>
    //        public string SalesSlipNum
    //        {
    //            get
    //            {
    //                return _salesSlipNum;
    //            }
    //            set
    //            {
    //                _salesSlipNum = value;
    //            }
    //        }
    //        //zhouzy update 2011.09.13 end
    //
    //        ///// <summary>
    //        ///// �ԓ��t���O
    //        ///// </summary>
    //        //public bool IsReply
    //        //{
    //        //    get
    //        //    {
    //        //        return _isReply;
    //        //    }
    //        //    set
    //        //    {
    //        //        _isReply = value;
    //        //    }
    //        //}
    //
    //        #endregion property method
    //    }
    //
    //    /// <summary>
    //    /// SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X(���b�Z�[�W���M�p)
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCM��Push�T�[�o�[�փp�u���b�V���p�f�[�^�N���X�ł��B(���b�Z�[�W���M�p)</br>
    //    /// <br>Programmer       :   HUANGHX</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushDataScmPccMailDt
    //    {
    //
    //        /// <summary>�⍇������ƃR�[�h</summary>
    //        private string _inqOriginalEpCd;
    //
    //        /// <summary>�⍇�������_�R�[�h</summary>
    //        private string _inqOriginalSecCd;
    //
    //        /// <summary>�⍇�����ƃR�[�h</summary>
    //        private string _inqOtherEpCd;
    //
    //        /// <summary>�⍇���拒�_�R�[�h</summary>
    //        private string _inqOtherSecCd;
    //
    //        /// <summary>�X�V�N����</summary>
    //        /// <remarks>YYYYMMDD</remarks>
    //        private Int32 _updateDate;
    //
    //        /// <summary>�X�V�����b�~���b</summary>
    //        /// <remarks>HHMMSSXXX</remarks>
    //        private Int32 _updateTime;
    //
    //        /// <summary>PCC���[������</summary>
    //        /// <remarks>(���p�S�p����)</remarks>
    //        private string _pccMailTitle = "";
    //
    //        /// <summary>PCC���[���{��</summary>
    //        /// <remarks>(���p�S�p����)</remarks>
    //        private string _pccMailDocCnts = "";
    //
    //        #region property method
    //        /// <summary>
    //        /// �⍇������ƃR�[�h
    //        /// </summary>
    //        public string InqOriginalEpCd
    //        {
    //            get
    //            {
    //                return _inqOriginalEpCd;
    //            }
    //            set
    //            {
    //                _inqOriginalEpCd = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// �⍇�������_�R�[�h
    //        /// </summary>
    //        public string InqOriginalSecCd
    //        {
    //            get
    //            {
    //                return _inqOriginalSecCd;
    //            }
    //            set
    //            {
    //                _inqOriginalSecCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// �⍇�����ƃR�[�h
    //        /// </summary>
    //        public string InqOtherEpCd
    //        {
    //            get
    //            {
    //                return _inqOtherEpCd;
    //            }
    //            set
    //            {
    //                _inqOtherEpCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// �⍇���拒�_�R�[�h
    //        /// </summary>
    //        public string InqOtherSecCd
    //        {
    //            get
    //            {
    //                return _inqOtherSecCd;
    //            }
    //            set
    //            {
    //                _inqOtherSecCd = value;
    //            }
    //        }
    //
    //        /// public propaty name  :  UpdateDate
    //        /// <summary>�X�V�N�����v���p�e�B</summary>
    //        /// <value>YYYYMMDD</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   �X�V�N�����v���p�e�B</br>
    //        /// <br>Programer        :   ��������</br>
    //        /// </remarks>
    //        public Int32 UpdateDate
    //        {
    //            get { return _updateDate; }
    //            set { _updateDate = value; }
    //        }
    //
    //        /// public propaty name  :  UpdateTime
    //        /// <summary>�X�V�����b�~���b�v���p�e�B</summary>
    //        /// <value>HHMMSSXXX</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   �X�V�����b�~���b�v���p�e�B</br>
    //        /// <br>Programer        :   ��������</br>
    //        /// </remarks>
    //        public Int32 UpdateTime
    //        {
    //            get { return _updateTime; }
    //            set { _updateTime = value; }
    //        }
    //
    //        /// public propaty name  :  PccMailTitle
    //        /// <summary>PCC���[�������v���p�e�B</summary>
    //        /// <value>(���p�S�p����)</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   PCC���[�������v���p�e�B</br>
    //        /// <br>Programer        :   ��������</br>
    //        /// </remarks>
    //        public string PccMailTitle
    //        {
    //            get { return _pccMailTitle; }
    //            set { _pccMailTitle = value; }
    //        }
    //
    //        /// public propaty name  :  PccMailDocCnts
    //        /// <summary>PCC���[���{���v���p�e�B</summary>
    //        /// <value>(���p�S�p����)</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   PCC���[���{���v���p�e�B</br>
    //        /// <br>Programer        :   ��������</br>
    //        /// </remarks>
    //        public string PccMailDocCnts
    //        {
    //            get { return _pccMailDocCnts; }
    //            set { _pccMailDocCnts = value; }
    //        }
    //
    //        #endregion property method
    //    }
    #endregion
}

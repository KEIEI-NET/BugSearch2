using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Propose_Para_SCM
    /// <summary>
    ///                      ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2016/6/2  �����m</br>
    /// <br>                 :   �A������Ɩ���</br>
    /// <br>                 :   �A�����Ɩ���</br>
    /// <br>                 :   ��ǉ�</br>
    /// </remarks>
    public class Propose_Para_SCM
    {
        /// <summary>�A������ƃR�[�h</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>�A������Ɩ���</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>�A�������_�R�[�h</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>�A�������_�K�C�h����</summary>
        private string _cnectOriginalSecNm = "";

        /// <summary>�A�����ƃR�[�h</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>�A�����Ɩ���</summary>
        private string _cnectOtherEpNm = "";

        /// <summary>�A���拒�_�R�[�h</summary>
        private string _cnectOtherSecCd = "";

        /// <summary>�A���拒�_�K�C�h����</summary>
        private string _cnectOtherSecNm = "";

        /// <summary>���ʋ敪</summary>
        /// <remarks>0:�A���L�� 1:�A������</remarks>
        private Int32 _discDivCd;

        /// <summary>�ʐM����(SCM)</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int16 _scmCommMethod;

        /// <summary>�ʐM����(PCC-UOE)</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int16 _pccUoeCommMethod;

        /// <summary>�ʐM����(RC-SCM)</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int16 _rcScmCommMethod;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�D��\���V�X�e��</summary>
        /// <remarks>10�FPM��D��\���A11�FRC��D��\��</remarks>
        private Int16 _prDispSystem;

        /// <summary>�^�u���b�g�g�p�敪</summary>
        /// <remarks>0�F�g�p���Ȃ�,1�F�g�p����</remarks>
        private Int32 _tabUseDiv;

        /// <summary>�V���ؑփX�e�[�^�X</summary>
        /// <remarks>0:��,1:�V</remarks>
        private Int32 _oldNewStatus;

        /// <summary>�ʏ�/�蓮�X�e�[�^�X</summary>
        /// <remarks>0:�ʏ�,1:�蓮</remarks>
        private Int32 _usualMnalStatus;

        /// <summary>�p�[�c�}��DBID</summary>
        /// <remarks>�p�[�c�}�����_DB�T�[�o�[��ID</remarks>
        private string _pmDBId = "";

        /// <summary>�p�[�c�}���A�b�v���[�h�敪</summary>
        /// <remarks>0:�Ȃ�,1:�A�b�v���[�h�ς�</remarks>
        private Int32 _pmUploadDiv;


        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>�A������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  CnectOriginalEpNm
        /// <summary>�A������Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A������Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalEpNm
        {
            get { return _cnectOriginalEpNm; }
            set { _cnectOriginalEpNm = value; }
        }

        /// public propaty name  :  CnectOriginalSecCd
        /// <summary>�A�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalSecCd
        {
            get { return _cnectOriginalSecCd; }
            set { _cnectOriginalSecCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecNm
        /// <summary>�A�������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalSecNm
        {
            get { return _cnectOriginalSecNm; }
            set { _cnectOriginalSecNm = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>�A�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
        }

        /// public propaty name  :  CnectOtherEpNm
        /// <summary>�A�����Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�����Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherEpNm
        {
            get { return _cnectOtherEpNm; }
            set { _cnectOtherEpNm = value; }
        }

        /// public propaty name  :  CnectOtherSecCd
        /// <summary>�A���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherSecCd
        {
            get { return _cnectOtherSecCd; }
            set { _cnectOtherSecCd = value; }
        }

        /// public propaty name  :  CnectOtherSecNm
        /// <summary>�A���拒�_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A���拒�_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherSecNm
        {
            get { return _cnectOtherSecNm; }
            set { _cnectOtherSecNm = value; }
        }

        /// public propaty name  :  DiscDivCd
        /// <summary>���ʋ敪�v���p�e�B</summary>
        /// <value>0:�A���L�� 1:�A������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DiscDivCd
        {
            get { return _discDivCd; }
            set { _discDivCd = value; }
        }

        /// public propaty name  :  ScmCommMethod
        /// <summary>�ʐM����(SCM)�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM����(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ScmCommMethod
        {
            get { return _scmCommMethod; }
            set { _scmCommMethod = value; }
        }

        /// public propaty name  :  PccUoeCommMethod
        /// <summary>�ʐM����(PCC-UOE)�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM����(PCC-UOE)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PccUoeCommMethod
        {
            get { return _pccUoeCommMethod; }
            set { _pccUoeCommMethod = value; }
        }

        /// public propaty name  :  RcScmCommMethod
        /// <summary>�ʐM����(RC-SCM)�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM����(RC-SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 RcScmCommMethod
        {
            get { return _rcScmCommMethod; }
            set { _rcScmCommMethod = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  PrDispSystem
        /// <summary>�D��\���V�X�e���v���p�e�B</summary>
        /// <value>10�FPM��D��\���A11�FRC��D��\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��\���V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PrDispSystem
        {
            get { return _prDispSystem; }
            set { _prDispSystem = value; }
        }

        /// public propaty name  :  TabUseDiv
        /// <summary>�^�u���b�g�g�p�敪�v���p�e�B</summary>
        /// <value>0�F�g�p���Ȃ�,1�F�g�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�u���b�g�g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }

        /// public propaty name  :  OldNewStatus
        /// <summary>�V���ؑփX�e�[�^�X�v���p�e�B</summary>
        /// <value>0:��,1:�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���ؑփX�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OldNewStatus
        {
            get { return _oldNewStatus; }
            set { _oldNewStatus = value; }
        }

        /// public propaty name  :  UsualMnalStatus
        /// <summary>�ʏ�/�蓮�X�e�[�^�X�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:�蓮</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʏ�/�蓮�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UsualMnalStatus
        {
            get { return _usualMnalStatus; }
            set { _usualMnalStatus = value; }
        }

        /// public propaty name  :  PmDBId
        /// <summary>�p�[�c�}��DBID�v���p�e�B</summary>
        /// <value>�p�[�c�}�����_DB�T�[�o�[��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�[�c�}��DBID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmDBId
        {
            get { return _pmDBId; }
            set { _pmDBId = value; }
        }

        /// public propaty name  :  PmUploadDiv
        /// <summary>�p�[�c�}���A�b�v���[�h�敪�v���p�e�B</summary>
        /// <value>0:�Ȃ�,1:�A�b�v���[�h�ς�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�[�c�}���A�b�v���[�h�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmUploadDiv
        {
            get { return _pmUploadDiv; }
            set { _pmUploadDiv = value; }
        }


        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j�R���X�g���N�^
        /// </summary>
        /// <returns>Propose_Para_SCM�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Para_SCM()
        {
        }

        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j�R���X�g���N�^
        /// </summary>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="cnectOriginalEpNm">�A������Ɩ���</param>
        /// <param name="cnectOriginalSecCd">�A�������_�R�[�h</param>
        /// <param name="cnectOriginalSecNm">�A�������_�K�C�h����</param>
        /// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
        /// <param name="cnectOtherEpNm">�A�����Ɩ���</param>
        /// <param name="cnectOtherSecCd">�A���拒�_�R�[�h</param>
        /// <param name="cnectOtherSecNm">�A���拒�_�K�C�h����</param>
        /// <param name="discDivCd">���ʋ敪(0:�A���L�� 1:�A������)</param>
        /// <param name="scmCommMethod">�ʐM����(SCM)(0:���Ȃ�,1:����)</param>
        /// <param name="pccUoeCommMethod">�ʐM����(PCC-UOE)(0:���Ȃ�,1:����)</param>
        /// <param name="rcScmCommMethod">�ʐM����(RC-SCM)(0:���Ȃ�,1:����)</param>
        /// <param name="displayOrder">�\������</param>
        /// <param name="prDispSystem">�D��\���V�X�e��(10�FPM��D��\���A11�FRC��D��\��)</param>
        /// <param name="tabUseDiv">�^�u���b�g�g�p�敪(0�F�g�p���Ȃ�,1�F�g�p����)</param>
        /// <param name="oldNewStatus">�V���ؑփX�e�[�^�X(0:��,1:�V)</param>
        /// <param name="usualMnalStatus">�ʏ�/�蓮�X�e�[�^�X(0:�ʏ�,1:�蓮)</param>
        /// <param name="pmDBId">�p�[�c�}��DBID(�p�[�c�}�����_DB�T�[�o�[��ID)</param>
        /// <param name="pmUploadDiv">�p�[�c�}���A�b�v���[�h�敪(0:�Ȃ�,1:�A�b�v���[�h�ς�)</param>
        /// <returns>Propose_Para_SCM�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Para_SCM(string cnectOriginalEpCd, string cnectOriginalEpNm, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherEpNm, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int16 rcScmCommMethod, Int32 displayOrder, Int16 prDispSystem, Int32 tabUseDiv, Int32 oldNewStatus, Int32 usualMnalStatus, string pmDBId, Int32 pmUploadDiv)
        {
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalEpNm = cnectOriginalEpNm;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._cnectOriginalSecNm = cnectOriginalSecNm;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherEpNm = cnectOtherEpNm;
            this._cnectOtherSecCd = cnectOtherSecCd;
            this._cnectOtherSecNm = cnectOtherSecNm;
            this._discDivCd = discDivCd;
            this._scmCommMethod = scmCommMethod;
            this._pccUoeCommMethod = pccUoeCommMethod;
            this._rcScmCommMethod = rcScmCommMethod;
            this._displayOrder = displayOrder;
            this._prDispSystem = prDispSystem;
            this._tabUseDiv = tabUseDiv;
            this._oldNewStatus = oldNewStatus;
            this._usualMnalStatus = usualMnalStatus;
            this._pmDBId = pmDBId;
            this._pmUploadDiv = pmUploadDiv;

        }

        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j��������
        /// </summary>
        /// <returns>Propose_Para_SCM�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Propose_Para_SCM�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Para_SCM Clone()
        {
            return new Propose_Para_SCM(this._cnectOriginalEpCd, this._cnectOriginalEpNm, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherEpNm, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._rcScmCommMethod, this._displayOrder, this._prDispSystem, this._tabUseDiv, this._oldNewStatus, this._usualMnalStatus, this._pmDBId, this._pmUploadDiv);
        }

        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Propose_Para_SCM�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Propose_Para_SCM target)
        {
            return ((this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.CnectOriginalSecNm == target.CnectOriginalSecNm)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
                 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
                 && (this.CnectOtherSecNm == target.CnectOtherSecNm)
                 && (this.DiscDivCd == target.DiscDivCd)
                 && (this.ScmCommMethod == target.ScmCommMethod)
                 && (this.PccUoeCommMethod == target.PccUoeCommMethod)
                 && (this.RcScmCommMethod == target.RcScmCommMethod)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.PrDispSystem == target.PrDispSystem)
                 && (this.TabUseDiv == target.TabUseDiv)
                 && (this.OldNewStatus == target.OldNewStatus)
                 && (this.UsualMnalStatus == target.UsualMnalStatus)
                 && (this.PmDBId == target.PmDBId)
                 && (this.PmUploadDiv == target.PmUploadDiv));
        }

        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j��r����
        /// </summary>
        /// <param name="propose_Para_SCM1">
        ///                    ��r����Propose_Para_SCM�N���X�̃C���X�^���X
        /// </param>
        /// <param name="propose_Para_SCM2">��r����Propose_Para_SCM�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Propose_Para_SCM propose_Para_SCM1, Propose_Para_SCM propose_Para_SCM2)
        {
            return ((propose_Para_SCM1.CnectOriginalEpCd == propose_Para_SCM2.CnectOriginalEpCd)
                 && (propose_Para_SCM1.CnectOriginalEpNm == propose_Para_SCM2.CnectOriginalEpNm)
                 && (propose_Para_SCM1.CnectOriginalSecCd == propose_Para_SCM2.CnectOriginalSecCd)
                 && (propose_Para_SCM1.CnectOriginalSecNm == propose_Para_SCM2.CnectOriginalSecNm)
                 && (propose_Para_SCM1.CnectOtherEpCd == propose_Para_SCM2.CnectOtherEpCd)
                 && (propose_Para_SCM1.CnectOtherEpNm == propose_Para_SCM2.CnectOtherEpNm)
                 && (propose_Para_SCM1.CnectOtherSecCd == propose_Para_SCM2.CnectOtherSecCd)
                 && (propose_Para_SCM1.CnectOtherSecNm == propose_Para_SCM2.CnectOtherSecNm)
                 && (propose_Para_SCM1.DiscDivCd == propose_Para_SCM2.DiscDivCd)
                 && (propose_Para_SCM1.ScmCommMethod == propose_Para_SCM2.ScmCommMethod)
                 && (propose_Para_SCM1.PccUoeCommMethod == propose_Para_SCM2.PccUoeCommMethod)
                 && (propose_Para_SCM1.RcScmCommMethod == propose_Para_SCM2.RcScmCommMethod)
                 && (propose_Para_SCM1.DisplayOrder == propose_Para_SCM2.DisplayOrder)
                 && (propose_Para_SCM1.PrDispSystem == propose_Para_SCM2.PrDispSystem)
                 && (propose_Para_SCM1.TabUseDiv == propose_Para_SCM2.TabUseDiv)
                 && (propose_Para_SCM1.OldNewStatus == propose_Para_SCM2.OldNewStatus)
                 && (propose_Para_SCM1.UsualMnalStatus == propose_Para_SCM2.UsualMnalStatus)
                 && (propose_Para_SCM1.PmDBId == propose_Para_SCM2.PmDBId)
                 && (propose_Para_SCM1.PmUploadDiv == propose_Para_SCM2.PmUploadDiv));
        }
        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Propose_Para_SCM�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Propose_Para_SCM target)
        {
            ArrayList resList = new ArrayList();
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalEpNm != target.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.CnectOriginalSecNm != target.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherEpNm != target.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (this.CnectOtherSecNm != target.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
            if (this.DiscDivCd != target.DiscDivCd) resList.Add("DiscDivCd");
            if (this.ScmCommMethod != target.ScmCommMethod) resList.Add("ScmCommMethod");
            if (this.PccUoeCommMethod != target.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            if (this.RcScmCommMethod != target.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.PrDispSystem != target.PrDispSystem) resList.Add("PrDispSystem");
            if (this.TabUseDiv != target.TabUseDiv) resList.Add("TabUseDiv");
            if (this.OldNewStatus != target.OldNewStatus) resList.Add("OldNewStatus");
            if (this.UsualMnalStatus != target.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (this.PmDBId != target.PmDBId) resList.Add("PmDBId");
            if (this.PmUploadDiv != target.PmUploadDiv) resList.Add("PmUploadDiv");

            return resList;
        }

        /// <summary>
        /// ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j��r����
        /// </summary>
        /// <param name="propose_Para_SCM1">��r����Propose_Para_SCM�N���X�̃C���X�^���X</param>
        /// <param name="propose_Para_SCM2">��r����Propose_Para_SCM�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Para_SCM�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Propose_Para_SCM propose_Para_SCM1, Propose_Para_SCM propose_Para_SCM2)
        {
            ArrayList resList = new ArrayList();
            if (propose_Para_SCM1.CnectOriginalEpCd != propose_Para_SCM2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (propose_Para_SCM1.CnectOriginalEpNm != propose_Para_SCM2.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (propose_Para_SCM1.CnectOriginalSecCd != propose_Para_SCM2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (propose_Para_SCM1.CnectOriginalSecNm != propose_Para_SCM2.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
            if (propose_Para_SCM1.CnectOtherEpCd != propose_Para_SCM2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (propose_Para_SCM1.CnectOtherEpNm != propose_Para_SCM2.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (propose_Para_SCM1.CnectOtherSecCd != propose_Para_SCM2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (propose_Para_SCM1.CnectOtherSecNm != propose_Para_SCM2.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
            if (propose_Para_SCM1.DiscDivCd != propose_Para_SCM2.DiscDivCd) resList.Add("DiscDivCd");
            if (propose_Para_SCM1.ScmCommMethod != propose_Para_SCM2.ScmCommMethod) resList.Add("ScmCommMethod");
            if (propose_Para_SCM1.PccUoeCommMethod != propose_Para_SCM2.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            if (propose_Para_SCM1.RcScmCommMethod != propose_Para_SCM2.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (propose_Para_SCM1.DisplayOrder != propose_Para_SCM2.DisplayOrder) resList.Add("DisplayOrder");
            if (propose_Para_SCM1.PrDispSystem != propose_Para_SCM2.PrDispSystem) resList.Add("PrDispSystem");
            if (propose_Para_SCM1.TabUseDiv != propose_Para_SCM2.TabUseDiv) resList.Add("TabUseDiv");
            if (propose_Para_SCM1.OldNewStatus != propose_Para_SCM2.OldNewStatus) resList.Add("OldNewStatus");
            if (propose_Para_SCM1.UsualMnalStatus != propose_Para_SCM2.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (propose_Para_SCM1.PmDBId != propose_Para_SCM2.PmDBId) resList.Add("PmDBId");
            if (propose_Para_SCM1.PmUploadDiv != propose_Para_SCM2.PmUploadDiv) resList.Add("PmUploadDiv");

            return resList;
        }
    }
}

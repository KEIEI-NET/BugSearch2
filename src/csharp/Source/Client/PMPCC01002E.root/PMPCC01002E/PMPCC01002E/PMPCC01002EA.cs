using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccMailDt
    /// <summary>
    ///                      PCC���[���f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC���[���f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccMailDt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>�X�V�����b�~���b</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>PCC���[������</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccMailTitle = "";

        /// <summary>PCC���[���{��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccMailDocCnts = "";

        /// <summary>�Ώۓ��J�n</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateSt;

        /// <summary>�Ώۓ��I��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateEd;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V�����b�~���b�v���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����b�~���b�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  PccMailTitle
        /// <summary>PCC���[�������v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccMailTitle
        {
            get { return _pccMailTitle; }
            set { _pccMailTitle = value; }
        }

        /// public propaty name  :  PccMailDocCnts
        /// <summary>PCC���[���{���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���[���{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccMailDocCnts
        {
            get { return _pccMailDocCnts; }
            set { _pccMailDocCnts = value; }
        }

        /// public propaty name  :  UpdateDateSt
        /// <summary>�Ώۓ��J�n�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateSt
        {
            get { return _updateDateSt; }
            set { _updateDateSt = value; }
        }

        /// public propaty name  :  UpdateDateEd
        /// <summary>�Ώۓ��I���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateEd
        {
            get { return _updateDateEd; }
            set { _updateDateEd = value; }
        }


        /// <summary>
        /// PCC���[���f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccMailDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccMailDt()
        {
        }

        /// <summary>
        /// PCC���[���f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
        /// <param name="updateTime">�X�V�����b�~���b(HHMMSSXXX)</param>
        /// <param name="pccMailTitle">PCC���[������((���p�S�p����))</param>
        /// <param name="pccMailDocCnts">PCC���[���{��((���p�S�p����))</param>
        /// <param name="updateDateSt">�Ώۓ��J�n(YYYYMMDD)</param>
        /// <param name="updateDateEd">�Ώۓ��I��(YYYYMMDD)</param>
        /// <returns>PccMailDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccMailDt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 updateDate, Int32 updateTime, string pccMailTitle, string pccMailDocCnts, Int32 updateDateSt, Int32 updateDateEd)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._updateDate = updateDate;
            this._updateTime = updateTime;
            this._pccMailTitle = pccMailTitle;
            this._pccMailDocCnts = pccMailDocCnts;
            this._updateDateSt = updateDateSt;
            this._updateDateEd = updateDateEd;

        }

        /// <summary>
        /// PCC���[���f�[�^��������
        /// </summary>
        /// <returns>PccMailDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccMailDt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccMailDt Clone()
        {
            return new PccMailDt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._updateDate, this._updateTime, this._pccMailTitle, this._pccMailDocCnts, this._updateDateSt, this._updateDateEd);//@@@@20230303
        }

        /// <summary>
        /// PCC���[���f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccMailDt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccMailDt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.UpdateTime == target.UpdateTime)
                 && (this.PccMailTitle == target.PccMailTitle)
                 && (this.PccMailDocCnts == target.PccMailDocCnts)
                 && (this.UpdateDateSt == target.UpdateDateSt)
                 && (this.UpdateDateEd == target.UpdateDateEd));
        }

        /// <summary>
        /// PCC���[���f�[�^��r����
        /// </summary>
        /// <param name="pccMailDt1">
        ///                    ��r����PccMailDt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccMailDt2">��r����PccMailDt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccMailDt pccMailDt1, PccMailDt pccMailDt2)
        {
            return ((pccMailDt1.CreateDateTime == pccMailDt2.CreateDateTime)
                 && (pccMailDt1.UpdateDateTime == pccMailDt2.UpdateDateTime)
                 && (pccMailDt1.LogicalDeleteCode == pccMailDt2.LogicalDeleteCode)
                 && (pccMailDt1.InqOriginalEpCd.Trim() == pccMailDt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccMailDt1.InqOriginalSecCd == pccMailDt2.InqOriginalSecCd)
                 && (pccMailDt1.InqOtherEpCd == pccMailDt2.InqOtherEpCd)
                 && (pccMailDt1.InqOtherSecCd == pccMailDt2.InqOtherSecCd)
                 && (pccMailDt1.UpdateDate == pccMailDt2.UpdateDate)
                 && (pccMailDt1.UpdateTime == pccMailDt2.UpdateTime)
                 && (pccMailDt1.PccMailTitle == pccMailDt2.PccMailTitle)
                 && (pccMailDt1.PccMailDocCnts == pccMailDt2.PccMailDocCnts)
                 && (pccMailDt1.UpdateDateSt == pccMailDt2.UpdateDateSt)
                 && (pccMailDt1.UpdateDateEd == pccMailDt2.UpdateDateEd));
        }
        /// <summary>
        /// PCC���[���f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccMailDt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccMailDt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
            if (this.PccMailTitle != target.PccMailTitle) resList.Add("PccMailTitle");
            if (this.PccMailDocCnts != target.PccMailDocCnts) resList.Add("PccMailDocCnts");
            if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
            if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");

            return resList;
        }

        /// <summary>
        /// PCC���[���f�[�^��r����
        /// </summary>
        /// <param name="pccMailDt1">��r����PccMailDt�N���X�̃C���X�^���X</param>
        /// <param name="pccMailDt2">��r����PccMailDt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccMailDt pccMailDt1, PccMailDt pccMailDt2)
        {
            ArrayList resList = new ArrayList();
            if (pccMailDt1.CreateDateTime != pccMailDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccMailDt1.UpdateDateTime != pccMailDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccMailDt1.LogicalDeleteCode != pccMailDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccMailDt1.InqOriginalEpCd.Trim() != pccMailDt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccMailDt1.InqOriginalSecCd != pccMailDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccMailDt1.InqOtherEpCd != pccMailDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccMailDt1.InqOtherSecCd != pccMailDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccMailDt1.UpdateDate != pccMailDt2.UpdateDate) resList.Add("UpdateDate");
            if (pccMailDt1.UpdateTime != pccMailDt2.UpdateTime) resList.Add("UpdateTime");
            if (pccMailDt1.PccMailTitle != pccMailDt2.PccMailTitle) resList.Add("PccMailTitle");
            if (pccMailDt1.PccMailDocCnts != pccMailDt2.PccMailDocCnts) resList.Add("PccMailDocCnts");
            if (pccMailDt1.UpdateDateSt != pccMailDt2.UpdateDateSt) resList.Add("UpdateDateSt");
            if (pccMailDt1.UpdateDateEd != pccMailDt2.UpdateDateEd) resList.Add("UpdateDateEd");

            return resList;
        }
    }
}

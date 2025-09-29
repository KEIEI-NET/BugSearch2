using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqChg
    /// <summary>
    ///                      �ȒP�⍇��ID�ϊ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ȒP�⍇��ID�ϊ��}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   �����m</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqChg
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

        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ�</summary>
        /// <remarks>���[�U�[�P�ʂ̘A��</remarks>
        private Int64 _simpleInqIdInfMngNo;

        /// <summary>�ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪</summary>
        /// <remarks>100:SF,BK,CS,VX 200:PM 300:MK 400:TR �E�E�E</remarks>
        private Int32 _simpleInqIdCngSysCd;

        /// <summary>�ϊ����A�J�E���g���ʃL�[</summary>
        /// <remarks>(���p�S�p����)�V�X�e���敪���Ƀ��[�U�[�����ʂł���L�[(���CD,BL���[�U�R�[�h��)</remarks>
        private string _originalAcntDiskKey = "";

        /// <summary>�ϊ����A�J�E���gID</summary>
        /// <remarks>(���p�S�p����)�ϊ����̃A�J�E���gID(�]�ƈ�CD�Ȃ�)</remarks>
        private string _originalAcntId = "";


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

        /// public propaty name  :  SimpleInqIdInfMngNo
        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</summary>
        /// <value>���[�U�[�P�ʂ̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SimpleInqIdInfMngNo
        {
            get { return _simpleInqIdInfMngNo; }
            set { _simpleInqIdInfMngNo = value; }
        }

        /// public propaty name  :  SimpleInqIdCngSysCd
        /// <summary>�ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪�v���p�e�B</summary>
        /// <value>100:SF,BK,CS,VX 200:PM 300:MK 400:TR �E�E�E</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SimpleInqIdCngSysCd
        {
            get { return _simpleInqIdCngSysCd; }
            set { _simpleInqIdCngSysCd = value; }
        }

        /// public propaty name  :  OriginalAcntDiskKey
        /// <summary>�ϊ����A�J�E���g���ʃL�[�v���p�e�B</summary>
        /// <value>(���p�S�p����)�V�X�e���敪���Ƀ��[�U�[�����ʂł���L�[(���CD,BL���[�U�R�[�h��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ����A�J�E���g���ʃL�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OriginalAcntDiskKey
        {
            get { return _originalAcntDiskKey; }
            set { _originalAcntDiskKey = value; }
        }

        /// public propaty name  :  OriginalAcntId
        /// <summary>�ϊ����A�J�E���gID�v���p�e�B</summary>
        /// <value>(���p�S�p����)�ϊ����̃A�J�E���gID(�]�ƈ�CD�Ȃ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ����A�J�E���gID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OriginalAcntId
        {
            get { return _originalAcntId; }
            set { _originalAcntId = value; }
        }


        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SmplInqChg�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqChg()
        {
        }

        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="simpleInqIdInfMngNo">�ȒP�⍇��ID�t�����Ǘ��ԍ�(���[�U�[�P�ʂ̘A��)</param>
        /// <param name="simpleInqIdCngSysCd">�ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪(100:SF,BK,CS,VX 200:PM 300:MK 400:TR �E�E�E)</param>
        /// <param name="originalAcntDiskKey">�ϊ����A�J�E���g���ʃL�[((���p�S�p����)�V�X�e���敪���Ƀ��[�U�[�����ʂł���L�[(���CD,BL���[�U�R�[�h��))</param>
        /// <param name="originalAcntId">�ϊ����A�J�E���gID((���p�S�p����)�ϊ����̃A�J�E���gID(�]�ƈ�CD�Ȃ�))</param>
        /// <returns>SmplInqChg�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqChg(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, Int32 simpleInqIdCngSysCd, string originalAcntDiskKey, string originalAcntId)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._simpleInqIdCngSysCd = simpleInqIdCngSysCd;
            this._originalAcntDiskKey = originalAcntDiskKey;
            this._originalAcntId = originalAcntId;

        }

        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^��������
        /// </summary>
        /// <returns>SmplInqChg�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SmplInqChg�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqChg Clone()
        {
            return new SmplInqChg(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._simpleInqIdCngSysCd, this._originalAcntDiskKey, this._originalAcntId);
        }

        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqChg�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SmplInqChg target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.SimpleInqIdCngSysCd == target.SimpleInqIdCngSysCd )
                 && ( this.OriginalAcntDiskKey == target.OriginalAcntDiskKey )
                 && ( this.OriginalAcntId == target.OriginalAcntId ) );
        }

        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^��r����
        /// </summary>
        /// <param name="smplInqChg1">
        ///                    ��r����SmplInqChg�N���X�̃C���X�^���X
        /// </param>
        /// <param name="smplInqChg2">��r����SmplInqChg�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SmplInqChg smplInqChg1, SmplInqChg smplInqChg2)
        {
            return ( ( smplInqChg1.CreateDateTime == smplInqChg2.CreateDateTime )
                 && ( smplInqChg1.UpdateDateTime == smplInqChg2.UpdateDateTime )
                 && ( smplInqChg1.LogicalDeleteCode == smplInqChg2.LogicalDeleteCode )
                 && ( smplInqChg1.SimpleInqIdInfMngNo == smplInqChg2.SimpleInqIdInfMngNo )
                 && ( smplInqChg1.SimpleInqIdCngSysCd == smplInqChg2.SimpleInqIdCngSysCd )
                 && ( smplInqChg1.OriginalAcntDiskKey == smplInqChg2.OriginalAcntDiskKey )
                 && ( smplInqChg1.OriginalAcntId == smplInqChg2.OriginalAcntId ) );
        }
        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqChg�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SmplInqChg target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.SimpleInqIdCngSysCd != target.SimpleInqIdCngSysCd) resList.Add("SimpleInqIdCngSysCd");
            if (this.OriginalAcntDiskKey != target.OriginalAcntDiskKey) resList.Add("OriginalAcntDiskKey");
            if (this.OriginalAcntId != target.OriginalAcntId) resList.Add("OriginalAcntId");

            return resList;
        }

        /// <summary>
        /// �ȒP�⍇��ID�ϊ��}�X�^��r����
        /// </summary>
        /// <param name="smplInqChg1">��r����SmplInqChg�N���X�̃C���X�^���X</param>
        /// <param name="smplInqChg2">��r����SmplInqChg�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqChg�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqChg smplInqChg1, SmplInqChg smplInqChg2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqChg1.CreateDateTime != smplInqChg2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqChg1.UpdateDateTime != smplInqChg2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqChg1.LogicalDeleteCode != smplInqChg2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqChg1.SimpleInqIdInfMngNo != smplInqChg2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqChg1.SimpleInqIdCngSysCd != smplInqChg2.SimpleInqIdCngSysCd) resList.Add("SimpleInqIdCngSysCd");
            if (smplInqChg1.OriginalAcntDiskKey != smplInqChg2.OriginalAcntDiskKey) resList.Add("OriginalAcntDiskKey");
            if (smplInqChg1.OriginalAcntId != smplInqChg2.OriginalAcntId) resList.Add("OriginalAcntId");

            return resList;
        }
    }
}

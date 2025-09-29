using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmInqLogInquiry
    /// <summary>
    ///                      SCM�⍇�����O�e�[�u��
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�⍇�����O�e�[�u���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/10/14</br>
    /// <br>Genarated Date   :   2010/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ScmInqLogInquiry
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

        /// <summary>�A������ƃR�[�h</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>�A������Ɩ���</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>�A�����ƃR�[�h</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>�A�����Ɩ���</summary>
        private string _cnectOtherEpNm = "";

        /// <summary>�⍇�����f�[�^���̓V�X�e��</summary>
        /// <remarks>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</remarks>
        private Int32 _inqDataInputSystem;

        /// <summary>���O�f�[�^GUID</summary>
        private Guid _logDataGuid;

        /// <summary>SCM�⍇�����e</summary>
        /// <remarks>nvarchar(max)</remarks>
        private string _scmInqContents = "";

        /// <summary>�񓚕��i����</summary>
        /// <remarks>�񓚂������i����</remarks>
        private Int32 _answerPartsCnt;


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

        /// public propaty name  :  InqDataInputSystem
        /// <summary>�⍇�����f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqDataInputSystem
        {
            get { return _inqDataInputSystem; }
            set { _inqDataInputSystem = value; }
        }

        /// public propaty name  :  LogDataGuid
        /// <summary>���O�f�[�^GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid LogDataGuid
        {
            get { return _logDataGuid; }
            set { _logDataGuid = value; }
        }

        /// public propaty name  :  ScmInqContents
        /// <summary>SCM�⍇�����e�v���p�e�B</summary>
        /// <value>nvarchar(max)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�⍇�����e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ScmInqContents
        {
            get { return _scmInqContents; }
            set { _scmInqContents = value; }
        }

        /// public propaty name  :  AnswerPartsCnt
        /// <summary>�񓚕��i�����v���p�e�B</summary>
        /// <value>�񓚂������i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerPartsCnt
        {
            get { return _answerPartsCnt; }
            set { _answerPartsCnt = value; }
        }


        /// <summary>
        /// SCM�⍇�����O�e�[�u���R���X�g���N�^
        /// </summary>
        /// <returns>ScmInqLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmInqLogInquiry()
        {
        }

        /// <summary>
        /// SCM�⍇�����O�e�[�u���R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="cnectOriginalEpNm">�A������Ɩ���</param>
        /// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
        /// <param name="cnectOtherEpNm">�A�����Ɩ���</param>
        /// <param name="inqDataInputSystem">�⍇�����f�[�^���̓V�X�e��(1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7)</param>
        /// <param name="logDataGuid">���O�f�[�^GUID</param>
        /// <param name="scmInqContents">SCM�⍇�����e(nvarchar(max))</param>
        /// <param name="answerPartsCnt">�񓚕��i����(�񓚂������i����)</param>
        /// <returns>ScmInqLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmInqLogInquiry(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalEpNm, string cnectOtherEpCd, string cnectOtherEpNm, Int32 inqDataInputSystem, Guid logDataGuid, string scmInqContents, Int32 answerPartsCnt)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalEpNm = cnectOriginalEpNm;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherEpNm = cnectOtherEpNm;
            this._inqDataInputSystem = inqDataInputSystem;
            this._logDataGuid = logDataGuid;
            this._scmInqContents = scmInqContents;
            this._answerPartsCnt = answerPartsCnt;

        }

        /// <summary>
        /// SCM�⍇�����O�e�[�u����������
        /// </summary>
        /// <returns>ScmInqLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmInqLog�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmInqLogInquiry Clone()
        {
            return new ScmInqLogInquiry(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalEpNm, this._cnectOtherEpCd, this._cnectOtherEpNm, this._inqDataInputSystem, this._logDataGuid, this._scmInqContents, this._answerPartsCnt);
        }

        /// <summary>
        /// SCM�⍇�����O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmInqLog�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ScmInqLogInquiry target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
                 && (this.InqDataInputSystem == target.InqDataInputSystem)
                 && (this.LogDataGuid == target.LogDataGuid)
                 && (this.ScmInqContents == target.ScmInqContents)
                 && (this.AnswerPartsCnt == target.AnswerPartsCnt));
        }

        /// <summary>
        /// SCM�⍇�����O�e�[�u����r����
        /// </summary>
        /// <param name="scmInqLog1">
        ///                    ��r����ScmInqLog�N���X�̃C���X�^���X
        /// </param>
        /// <param name="scmInqLog2">��r����ScmInqLog�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(ScmInqLogInquiry scmInqLog1, ScmInqLogInquiry scmInqLog2)
        {
            return ((scmInqLog1.CreateDateTime == scmInqLog2.CreateDateTime)
                 && (scmInqLog1.UpdateDateTime == scmInqLog2.UpdateDateTime)
                 && (scmInqLog1.LogicalDeleteCode == scmInqLog2.LogicalDeleteCode)
                 && (scmInqLog1.CnectOriginalEpCd == scmInqLog2.CnectOriginalEpCd)
                 && (scmInqLog1.CnectOriginalEpNm == scmInqLog2.CnectOriginalEpNm)
                 && (scmInqLog1.CnectOtherEpCd == scmInqLog2.CnectOtherEpCd)
                 && (scmInqLog1.CnectOtherEpNm == scmInqLog2.CnectOtherEpNm)
                 && (scmInqLog1.InqDataInputSystem == scmInqLog2.InqDataInputSystem)
                 && (scmInqLog1.LogDataGuid == scmInqLog2.LogDataGuid)
                 && (scmInqLog1.ScmInqContents == scmInqLog2.ScmInqContents)
                 && (scmInqLog1.AnswerPartsCnt == scmInqLog2.AnswerPartsCnt));
        }
        /// <summary>
        /// SCM�⍇�����O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmInqLog�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(ScmInqLogInquiry target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalEpNm != target.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherEpNm != target.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (this.InqDataInputSystem != target.InqDataInputSystem) resList.Add("InqDataInputSystem");
            if (this.LogDataGuid != target.LogDataGuid) resList.Add("LogDataGuid");
            if (this.ScmInqContents != target.ScmInqContents) resList.Add("ScmInqContents");
            if (this.AnswerPartsCnt != target.AnswerPartsCnt) resList.Add("AnswerPartsCnt");

            return resList;
        }

        /// <summary>
        /// SCM�⍇�����O�e�[�u����r����
        /// </summary>
        /// <param name="scmInqLog1">��r����ScmInqLog�N���X�̃C���X�^���X</param>
        /// <param name="scmInqLog2">��r����ScmInqLog�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLog�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(ScmInqLogInquiry scmInqLog1, ScmInqLogInquiry scmInqLog2)
        {
            ArrayList resList = new ArrayList();
            if (scmInqLog1.CreateDateTime != scmInqLog2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmInqLog1.UpdateDateTime != scmInqLog2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmInqLog1.LogicalDeleteCode != scmInqLog2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmInqLog1.CnectOriginalEpCd != scmInqLog2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (scmInqLog1.CnectOriginalEpNm != scmInqLog2.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (scmInqLog1.CnectOtherEpCd != scmInqLog2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (scmInqLog1.CnectOtherEpNm != scmInqLog2.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (scmInqLog1.InqDataInputSystem != scmInqLog2.InqDataInputSystem) resList.Add("InqDataInputSystem");
            if (scmInqLog1.LogDataGuid != scmInqLog2.LogDataGuid) resList.Add("LogDataGuid");
            if (scmInqLog1.ScmInqContents != scmInqLog2.ScmInqContents) resList.Add("ScmInqContents");
            if (scmInqLog1.AnswerPartsCnt != scmInqLog2.AnswerPartsCnt) resList.Add("AnswerPartsCnt");

            return resList;
        }
    }
}

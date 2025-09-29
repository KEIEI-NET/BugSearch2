using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RmSlpPrtStWork
    /// <summary>
    ///                      �����[�g�`���ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����[�g�`���ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/09/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/9/15  ��{�@�E</br>
    /// <br>                 :   12,13��ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RmSlpPrtStWork : IFileHeader
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

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>�`�[������</summary>
        /// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,100:���[�N�V�[�g,110:�{�f�B���@�}</remarks>
        private Int32 _slipPrtKind;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�`�[����ݒ�p</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�����[�g�`���敪</summary>
        /// <remarks>0:���s���Ȃ�, 1:���s����</remarks>
        private Int32 _rmtSlpPrtDiv;

        /// <summary>��]��</summary>
        /// <remarks>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</remarks>
        private Double _topMargin;

        /// <summary>���]��</summary>
        /// <remarks>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</remarks>
        private Double _leftMargin;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";


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

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,100:���[�N�V�[�g,110:�{�f�B���@�}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�`�[����ݒ�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  RmtSlpPrtDiv
        /// <summary>�����[�g�`���敪�v���p�e�B</summary>
        /// <value>0:���s���Ȃ�, 1:���s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����[�g�`���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RmtSlpPrtDiv
        {
            get { return _rmtSlpPrtDiv; }
            set { _rmtSlpPrtDiv = value; }
        }

        /// public propaty name  :  TopMargin
        /// <summary>��]���v���p�e�B</summary>
        /// <value>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  LeftMargin
        /// <summary>���]���v���p�e�B</summary>
        /// <value>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }


        /// <summary>
        /// �����[�g�`���ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtStWork()
        {
        }

        /// <summary>
        /// �����[�g�`���ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="slipPrtKind">�`�[������(10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,100:���[�N�V�[�g,110:�{�f�B���@�})</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(�`�[����ݒ�p)</param>
        /// <param name="rmtSlpPrtDiv">�����[�g�`���敪(0:���s���Ȃ�, 1:���s����)</param>
        /// <param name="topMargin">��]��(cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8))</param>
        /// <param name="leftMargin">���]��(cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8))</param>
        /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, Int32 slipPrtKind, string slipPrtSetPaperId, Int32 rmtSlpPrtDiv, Double topMargin, Double leftMargin)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();	//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._slipPrtKind = slipPrtKind;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._rmtSlpPrtDiv = rmtSlpPrtDiv;
            this._topMargin = topMargin;
            this._leftMargin = leftMargin;

        }

        /// <summary>
        /// �����[�g�`���ݒ胏�[�N��������
        /// </summary>
        /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RmSlpPrtStWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtStWork Clone()
        {
            return new RmSlpPrtStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._slipPrtKind, this._slipPrtSetPaperId, this._rmtSlpPrtDiv, this._topMargin, this._leftMargin);//@@@@20230303
        }

        /// <summary>
        /// �����[�g�`���ݒ胏�[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RmSlpPrtStWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(RmSlpPrtStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.RmtSlpPrtDiv == target.RmtSlpPrtDiv)
                 && (this.TopMargin == target.TopMargin)
                 && (this.LeftMargin == target.LeftMargin));
        }

        /// <summary>
        /// �����[�g�`���ݒ胏�[�N��r����
        /// </summary>
        /// <param name="rmSlpPrtSt1">
        ///                    ��r����RmSlpPrtStWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rmSlpPrtSt2">��r����RmSlpPrtStWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(RmSlpPrtStWork rmSlpPrtSt1, RmSlpPrtStWork rmSlpPrtSt2)
        {
            return ((rmSlpPrtSt1.CreateDateTime == rmSlpPrtSt2.CreateDateTime)
                 && (rmSlpPrtSt1.UpdateDateTime == rmSlpPrtSt2.UpdateDateTime)
                 && (rmSlpPrtSt1.LogicalDeleteCode == rmSlpPrtSt2.LogicalDeleteCode)
                 && (rmSlpPrtSt1.InqOriginalEpCd.Trim() == rmSlpPrtSt2.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (rmSlpPrtSt1.InqOriginalSecCd == rmSlpPrtSt2.InqOriginalSecCd)
                 && (rmSlpPrtSt1.InqOtherEpCd == rmSlpPrtSt2.InqOtherEpCd)
                 && (rmSlpPrtSt1.InqOtherSecCd == rmSlpPrtSt2.InqOtherSecCd)
                 && (rmSlpPrtSt1.PccCompanyCode == rmSlpPrtSt2.PccCompanyCode)
                 && (rmSlpPrtSt1.SlipPrtKind == rmSlpPrtSt2.SlipPrtKind)
                 && (rmSlpPrtSt1.SlipPrtSetPaperId == rmSlpPrtSt2.SlipPrtSetPaperId)
                 && (rmSlpPrtSt1.RmtSlpPrtDiv == rmSlpPrtSt2.RmtSlpPrtDiv)
                 && (rmSlpPrtSt1.TopMargin == rmSlpPrtSt2.TopMargin)
                 && (rmSlpPrtSt1.LeftMargin == rmSlpPrtSt2.LeftMargin));
        }
        /// <summary>
        /// �����[�g�`���ݒ胏�[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RmSlpPrtStWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(RmSlpPrtStWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.RmtSlpPrtDiv != target.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (this.TopMargin != target.TopMargin) resList.Add("TopMargin");
            if (this.LeftMargin != target.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }

        /// <summary>
        /// �����[�g�`���ݒ胏�[�N��r����
        /// </summary>
        /// <param name="rmSlpPrtSt1">��r����RmSlpPrtStWork�N���X�̃C���X�^���X</param>
        /// <param name="rmSlpPrtSt2">��r����RmSlpPrtStWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(RmSlpPrtStWork rmSlpPrtSt1, RmSlpPrtStWork rmSlpPrtSt2)
        {
            ArrayList resList = new ArrayList();
            if (rmSlpPrtSt1.CreateDateTime != rmSlpPrtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (rmSlpPrtSt1.UpdateDateTime != rmSlpPrtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rmSlpPrtSt1.LogicalDeleteCode != rmSlpPrtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rmSlpPrtSt1.InqOriginalEpCd.Trim() != rmSlpPrtSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (rmSlpPrtSt1.InqOriginalSecCd != rmSlpPrtSt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (rmSlpPrtSt1.InqOtherEpCd != rmSlpPrtSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (rmSlpPrtSt1.InqOtherSecCd != rmSlpPrtSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (rmSlpPrtSt1.PccCompanyCode != rmSlpPrtSt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (rmSlpPrtSt1.SlipPrtKind != rmSlpPrtSt2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (rmSlpPrtSt1.SlipPrtSetPaperId != rmSlpPrtSt2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (rmSlpPrtSt1.RmtSlpPrtDiv != rmSlpPrtSt2.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (rmSlpPrtSt1.TopMargin != rmSlpPrtSt2.TopMargin) resList.Add("TopMargin");
            if (rmSlpPrtSt1.LeftMargin != rmSlpPrtSt2.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }

        #region IFileHeader �����o


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }
        #endregion

       
    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RmSlpPrtStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RmSlpPrtStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RmSlpPrtStWork || graph is ArrayList || graph is RmSlpPrtStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RmSlpPrtStWork).FullName));

            if (graph != null && graph is RmSlpPrtStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RmSlpPrtStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RmSlpPrtStWork[])graph).Length;
            }
            else if (graph is RmSlpPrtStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //PCC���ЃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PccCompanyCode
            //�`�[������
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrtKind
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //�����[�g�`���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RmtSlpPrtDiv
            //��]��
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //���]��
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin


            serInfo.Serialize(writer, serInfo);
            if (graph is RmSlpPrtStWork)
            {
                RmSlpPrtStWork temp = (RmSlpPrtStWork)graph;

                SetRmSlpPrtStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RmSlpPrtStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RmSlpPrtStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RmSlpPrtStWork temp in lst)
                {
                    SetRmSlpPrtStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RmSlpPrtStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  RmSlpPrtStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRmSlpPrtStWork(System.IO.BinaryWriter writer, RmSlpPrtStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //PCC���ЃR�[�h
            writer.Write(temp.PccCompanyCode);
            //�`�[������
            writer.Write(temp.SlipPrtKind);
            //�`�[����ݒ�p���[ID
            writer.Write(temp.SlipPrtSetPaperId);
            //�����[�g�`���敪
            writer.Write(temp.RmtSlpPrtDiv);
            //��]��
            writer.Write(temp.TopMargin);
            //���]��
            writer.Write(temp.LeftMargin);

        }

        /// <summary>
        ///  RmSlpPrtStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RmSlpPrtStWork GetRmSlpPrtStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RmSlpPrtStWork temp = new RmSlpPrtStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //PCC���ЃR�[�h
            temp.PccCompanyCode = reader.ReadInt32();
            //�`�[������
            temp.SlipPrtKind = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //�����[�g�`���敪
            temp.RmtSlpPrtDiv = reader.ReadInt32();
            //��]��
            temp.TopMargin = reader.ReadDouble();
            //���]��
            temp.LeftMargin = reader.ReadDouble();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>RmSlpPrtStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RmSlpPrtStWork temp = GetRmSlpPrtStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (RmSlpPrtStWork[])lst.ToArray(typeof(RmSlpPrtStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}

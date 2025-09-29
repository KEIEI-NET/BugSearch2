using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PrtManage
    /// <summary>
    ///                      �v�����^�Ǘ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �v�����^�Ǘ��}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/3/7</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PrtManage : System.IComparable
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

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

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�v�����^�Ǘ�No</summary>
        private Int32 _printerMngNo;

        /// <summary>�v�����^��</summary>
        private string _printerName = "";

        /// <summary>�v�����^�|�[�g�i�p�X�j</summary>
        private string _printerPort = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�����^���</summary>
        private Int32 _printerKind;

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

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  PrinterMngNo
        /// <summary>�v�����^�Ǘ�No�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^�Ǘ�No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrinterMngNo
        {
            get { return _printerMngNo; }
            set { _printerMngNo = value; }
        }

        /// public propaty name  :  PrinterName
        /// <summary>�v�����^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        /// public propaty name  :  PrinterPort
        /// <summary>�v�����^�|�[�g�i�p�X�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^�|�[�g�i�p�X�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrinterPort
        {
            get { return _printerPort; }
            set { _printerPort = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  PrinterKind
        /// <summary>�v�����^��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrinterKind
        {
            get { return _printerKind; }
            set { _printerKind = value; }
        }


        /// <summary>SVF����R�[�h�i�v�����^��ށj</summary>
        public static string[] PrinterKindCodes = 
		{
			"ESCP",		
			"ESCPI",		
			"PR201",		
			"PR201I",		
			"PRINTER",		
			"LIPS3",		
			"LIPS4",		
			"RPDL2",		
			"NPDL2",		
			"ESCPAGE",		
			"PRESCRIBE2",	
			"PCL5",		
			"XEROX",		
			"POSTSCRIPT"
		};

        /// <summary>
        /// �v�����^��ޖ��̂̎擾
        /// </summary>
        /// <param name="code">SVF����R�[�h</param>
        /// <returns>�v�����^��ޖ���</returns>
        public string GetPrinterKindName(string code)
        {
            string name = "";
            switch (code)
            {
                case "ESCP": { name = "ESC/P"; break; }
                case "ESCPI": { name = "ESC/P(�C���[�W)"; break; }
                case "PR201": { name = "PC-PR201"; break; }
                case "PR201I": { name = "PC-PR201(�C���[�W)"; break; }
                case "PRINTER": { name = "�C���[�W���"; break; }
                case "LIPS3": { name = "LIPS�V"; break; }
                case "LIPS4": { name = "LIPS�W"; break; }
                case "RPDL2": { name = "RPDL"; break; }
                case "NPDL2": { name = "NPDL(Level2)"; break; }
                case "ESCPAGE": { name = "ESC/Page"; break; }
                case "PRESCRIBE2": { name = "PRESCRIBE2"; break; }
                case "PCL5": { name = "HP LaserJet 4V"; break; }
                case "XEROX": { name = "XEROX DocuStation DP300"; break; }
                case "POSTSCRIPT": { name = "PostScript(Level2)"; break; }
            }
            return name;
        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PrtManage�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrtManage()
        {
        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="printerMngNo">�v�����^�Ǘ�No</param>
        /// <param name="printerName">�v�����^��</param>
        /// <param name="printerPort">�v�����^�|�[�g�i�p�X�j</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PrtManage�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrtManage(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 printerMngNo, string printerName, string printerPort, string enterpriseName, string updEmployeeName, Int32 printerKind)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._printerMngNo = printerMngNo;
            this._printerName = printerName;
            this._printerPort = printerPort;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._printerKind = printerKind;

        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^��������
        /// </summary>
        /// <returns>PrtManage�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PrtManage�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrtManage Clone()
        {
            return new PrtManage(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._printerMngNo, this._printerName, this._printerPort, this._enterpriseName, this._updEmployeeName, this._printerKind);
        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PrtManage�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PrtManage target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PrinterMngNo == target.PrinterMngNo)
                 && (this.PrinterName == target.PrinterName)
                 && (this.PrinterPort == target.PrinterPort)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.PrinterKind == target.PrinterKind));
        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="prtManage1">
        ///                    ��r����PrtManage�N���X�̃C���X�^���X
        /// </param>
        /// <param name="prtManage2">��r����PrtManage�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PrtManage prtManage1, PrtManage prtManage2)
        {
            return ((prtManage1.CreateDateTime == prtManage2.CreateDateTime)
                 && (prtManage1.UpdateDateTime == prtManage2.UpdateDateTime)
                 && (prtManage1.EnterpriseCode == prtManage2.EnterpriseCode)
                 && (prtManage1.FileHeaderGuid == prtManage2.FileHeaderGuid)
                 && (prtManage1.UpdEmployeeCode == prtManage2.UpdEmployeeCode)
                 && (prtManage1.UpdAssemblyId1 == prtManage2.UpdAssemblyId1)
                 && (prtManage1.UpdAssemblyId2 == prtManage2.UpdAssemblyId2)
                 && (prtManage1.LogicalDeleteCode == prtManage2.LogicalDeleteCode)
                 && (prtManage1.PrinterMngNo == prtManage2.PrinterMngNo)
                 && (prtManage1.PrinterName == prtManage2.PrinterName)
                 && (prtManage1.PrinterPort == prtManage2.PrinterPort)
                 && (prtManage1.EnterpriseName == prtManage2.EnterpriseName)
                 && (prtManage1.UpdEmployeeName == prtManage2.UpdEmployeeName)
                 && (prtManage1.PrinterKind == prtManage2.PrinterKind));
        }
        /// <summary>
        /// �v�����^�Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PrtManage�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PrtManage target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PrinterMngNo != target.PrinterMngNo) resList.Add("PrinterMngNo");
            if (this.PrinterName != target.PrinterName) resList.Add("PrinterName");
            if (this.PrinterPort != target.PrinterPort) resList.Add("PrinterPort");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.PrinterKind != target.PrinterKind) resList.Add("PrinterKind");

            return resList;
        }

        /// <summary>
        /// �v�����^�Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="prtManage1">��r����PrtManage�N���X�̃C���X�^���X</param>
        /// <param name="prtManage2">��r����PrtManage�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// 
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtManage�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PrtManage prtManage1, PrtManage prtManage2)
        {
            ArrayList resList = new ArrayList();
            if (prtManage1.CreateDateTime != prtManage2.CreateDateTime) resList.Add("CreateDateTime");
            if (prtManage1.UpdateDateTime != prtManage2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (prtManage1.EnterpriseCode != prtManage2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (prtManage1.FileHeaderGuid != prtManage2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (prtManage1.UpdEmployeeCode != prtManage2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (prtManage1.UpdAssemblyId1 != prtManage2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (prtManage1.UpdAssemblyId2 != prtManage2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (prtManage1.LogicalDeleteCode != prtManage2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (prtManage1.PrinterMngNo != prtManage2.PrinterMngNo) resList.Add("PrinterMngNo");
            if (prtManage1.PrinterName != prtManage2.PrinterName) resList.Add("PrinterName");
            if (prtManage1.PrinterPort != prtManage2.PrinterPort) resList.Add("PrinterPort");
            if (prtManage1.EnterpriseName != prtManage2.EnterpriseName) resList.Add("EnterpriseName");
            if (prtManage1.UpdEmployeeName != prtManage2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (prtManage1.PrinterKind != prtManage2.PrinterKind) resList.Add("PrinterKind");

            return resList;
        }

        /// <summary>
        /// �v�����^�Ǘ��N���X��r�����iIComparable�̎����j
        /// </summary>
        /// <param name="x">�v�����^�Ǘ��N���X</param>
        /// <returns>��v����ꍇ�͂O</returns>
        public int CompareTo(object x)
        {
            PrtManage prtManageX = (PrtManage)x;

            //			int ret = _enterpriseCode.CompareTo(prtManageX.EnterpriseCode);
            //			if (ret == 0) ret = this._printerMngNo - prtManageX.PrinterMngNo;
            int ret = this._printerMngNo - prtManageX.PrinterMngNo;
            return ret;
        }
    }
}

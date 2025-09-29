//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller
{
    using DataSetType= ServerPrinterSettingDataSet;
    using RecordType = PrtManage;

    /// <summary>
    /// �v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[���N���X
    /// </summary>
    public sealed class ServerPrinterSettingController : ServerConfiguratorController<DataSetType>
    {
        #region <�v�����^�ݒ�}�X�^�i�T�[�o�p�j>

        /// <summary>���[�h�����v�����^�ݒ�}�X�^�i�T�[�o�p�j�f�[�^�̃��X�g</summary>
        private List<RecordType> _loadedServerPrinterSettingList;
        /// <summary>���[�h�����v�����^�ݒ�}�X�^�i�T�[�o�p�j�f�[�^�̃��X�g���擾�܂��͐ݒ肵�܂��B</summary>
        private List<RecordType> LoadedServerPrinterSettingList
        {
            get
            {
                if (_loadedServerPrinterSettingList == null)
                {
                    _loadedServerPrinterSettingList = new List<PrtManage>();
                }
                return _loadedServerPrinterSettingList;
            }
            set { _loadedServerPrinterSettingList = value; }
        }

        #endregion // </�v�����^�ݒ�}�X�^�i�T�[�o�p�j>

        #region <Override>

        /// <summary>
        /// ���g��DB�����[�h���܂��B
        /// </summary>
        protected override DataSetType LoadOwnDB()
        {
            return LoadServerPrinterSettingMaster();
        }

        /// <summary>
        /// �I�����Ă��郌�R�[�h�������݂܂��B
        /// </summary>
        protected override void WriteSelectedRecord()
        {
            WriteSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// �I�����Ă��郌�R�[�h��_���폜���܂��B
        /// </summary>
        protected override void DeleteSelectedRecord()
        {
            DeleteSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// �I�����Ă��郌�R�[�h�𕜊������܂��B
        /// </summary>
        protected override void ReviveSelectedRecord()
        {
            ReviveSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// �I�����Ă��郌�R�[�h�𕨗��폜���܂��B
        /// </summary>
        protected override void DestroySelectedRecord()
        {
            DestroySelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// ����DB���C���|�[�g���܂��B
        /// </summary>
        protected override DataSetType ImportOtherDB()
        {
            return ImportPrtManageMaser();
        }

        #endregion // </Override>

        #region <��������>

        /// <summary>null�Ƃ݂Ȃ��v�����^�Ǘ�No</summary>
        public const int NULL_PRINTER_MNG_NO = -1;

        /// <summary>�������郌�R�[�h</summary>
        private RecordType _doingRecord;
        /// <summary>�������郌�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public RecordType DoingRecord
        {
            get { return _doingRecord; }
            set { _doingRecord = value; }
        }

        /// <summary>
        /// �������郌�R�[�h��ݒ肵�܂��B
        /// </summary>
        /// <param name="printerMngNo">�v�����^�Ǘ�No</param>
        public void SetDoingRecord(int printerMngNo)
        {
            DoingRecord = Find(printerMngNo);
        }

        /// <summary>�������ʃR�[�h</summary>
        private int _doneStatus;
        /// <summary>�������ʃR�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public int DoneStatus
        {
            get { return _doneStatus; }
            set { _doneStatus = value; }
        }

        /// <summary>
        /// �������������Z�b�g���܂��B
        /// </summary>
        private void ResetDoing()
        {
            DoingRecord = null;
        }

        #endregion // </��������>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ServerPrinterSettingController() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="printerMngNo">�v�����^�Ǘ�No</param>
        /// <returns>�Y������v�����^�ݒ�}�X�^�f�[�^ ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public RecordType Find(int printerMngNo)
        {
            RecordType foundRecord = LoadedServerPrinterSettingList.Find(
                delegate(RecordType item)
                {
                    return item.PrinterMngNo.Equals(printerMngNo);
                }
            );
            if (foundRecord != null)
            {
                return foundRecord;
            }
            return null;
        }

        /// <summary>
        /// ���݂��邩���f���܂��B
        /// </summary>
        /// <param name="printerName">�v�����^��</param>
        /// <param name="foundPrinterMngNo">�������ꂽ�v�����^�Ǘ�No �����݂��Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</param>
        /// <returns>
        /// <c>true</c> :���݂��܂��B<br/>
        /// <c>false</c>:���݂��܂���B
        /// </returns>
        public bool Exists(
            string printerName,
            out int foundPrinterMngNo
        )
        {
            foundPrinterMngNo = 0;

            int foundIndex = LoadedServerPrinterSettingList.FindIndex(
                delegate(RecordType item)
                {
                    return item.PrinterName.Trim().Equals(printerName.Trim());
                }
            );
            if (foundIndex >= 0)
            {
                foundPrinterMngNo = LoadedServerPrinterSettingList[foundIndex].PrinterMngNo;
                return true;
            }

            return false;
        }

        #region <�ǂ�>

        /// <summary>
        /// �v�����^�ݒ�}�X�^�i�T�[�o�p�j�����[�h���܂��B
        /// </summary>
        /// <returns>���[�h�����f�[�^�Z�b�g</returns>
        private DataSetType LoadServerPrinterSettingMaster()
        {
            // �]���̃v�����^�ݒ�}�X�^�i�N���C�A���g�p�j�Ɠ����}�X�^�iXML�t�@�C���j������
            return ImportPrtManageMaser();
        }

        /// <summary>
        /// �v�����^�ݒ�}�X�^���C���|�[�g���܂��B
        /// </summary>
        /// <returns>�C���|�[�g���������f�[�^�Z�b�g</returns>
        private DataSetType ImportPrtManageMaser()
        {
            DataSetType db = new DataSetType();
            {
                LoadedServerPrinterSettingList = PrtManageAcs.SearchFromPrtManageMaster(EnterpriseCode);
                {
                    foreach (PrtManage prtManage in LoadedServerPrinterSettingList)
                    {
                        db.AddPrtManage(prtManage);
                    }
                }
            }
            return db;
        }

        /// <summary>
        /// �����[�h���܂��B
        /// </summary>
        private void ReLoad()
        {
            Load();
        }

        #endregion // </�ǂ�>

        #region <����>

        /// <summary>
        /// �I�����Ă���v�����^�ݒ�}�X�^�i�T�[�o�p�j�̃��R�[�h�������݂܂��B
        /// </summary>
        /// <remarks>
        /// ������A<c>DoingRecord</c>�̓N���A����܂��B
        /// </remarks>
        private void WriteSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.WriteToPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // �}�X�^���ω������̂ŁA�ēǍ���
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // </����>

        #region <����>

        /// <summary>
        /// �I�����Ă���v�����^�ݒ�}�X�^�i�T�[�o�p�j�̃��R�[�h��_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// ������A<c>DoingRecord</c>�̓N���A����܂��B
        /// </remarks>
        private void DeleteSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {   
                DoneStatus = PrtManageAcs.DeleteLogicallyFromPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // �}�X�^���ω������̂ŁA�ēǍ���
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        /// <summary>
        /// �I�����Ă���v�����^�ݒ�}�X�^�i�T�[�o�p�j�̃��R�[�h�𕨗��폜���܂��B
        /// </summary>
        /// <remarks>
        /// ������A<c>DoingRecord</c>�̓N���A����܂��B
        /// </remarks>
        private void DestroySelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.DeletePhysicallyFromPrtManageMaster(_doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // �}�X�^���ω������̂ŁA�ēǍ���
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // </����>

        #region <�߂�>

        /// <summary>
        /// �I�����Ă���v�����^�ݒ�}�X�^�i�T�[�o�p�j�̃��R�[�h�𕜊������܂��B
        /// </summary>
        /// <remarks>
        /// ������A<c>DoingRecord</c>�̓N���A����܂��B
        /// </remarks>
        private void ReviveSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.ReviveIntoPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // �}�X�^���ω������̂ŁA�ēǍ���
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // <�߂�>

        #region <�\���X�V>

        /// <summary>
        /// �\���X�V�C�x���g�p�����[�^�𐶐����܂��B
        /// </summary>
        /// <returns>�\���X�V�C�x���g�p�����[�^</returns>
        private static UpdateViewEventArgs CreateUpdateViewEventArgs()
        {
            return new UpdateViewEventArgs();
        }

        #endregion // </�\���X�V>
    }
}

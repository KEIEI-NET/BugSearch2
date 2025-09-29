using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Microsoft.VisualBasic;
using System.Threading;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �Z�����\�[�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 23011�@����@���N</br>
    /// <br>Date       : 2006.09.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    internal static class AddressIndexManageAcs
    {

        /// <summary>
        /// �X�^�e�B�b�N�R���X�g���N�^
        /// </summary>
        static AddressIndexManageAcs()
        {
            _readerWriterLock = new ReaderWriterLock();

            iOfferAddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
        }
        
        /// <summary>
		/// �����[�e�B���O�A�N�Z�X�p�C���^�[�t�F�C�X
		/// </summary>
		private static IOfferAddressInfo iOfferAddressInfo = null;

        /// <summary>
        /// �Z���}�X�^�X�V�Ǘ��}�X�^�̃L���b�V��
        /// </summary>
        private static DataTable addrUpdMngTable = null;

        /// <summary>
        /// �Z���}�X�^�Z���R�[�h�C���f�b�N�X�}�X�^�̃L���b�V��
        /// </summary>
        private static DataTable addrCdIndxTable = null;

        /// <summary>
        /// �Z���}�X�^�X�֔ԍ��C���f�b�N�X�}�X�^�̃L���b�V��
        /// </summary>
        private static DataTable postNoIndxTable = null;

        /// <summary>
        /// �N���XID�̓p�u���b�N�ȃN���X�̖��O�ɂ��Ƃ�
        /// </summary>
        private readonly static string classID = "Broadleaf.Application.Common.OfferAddressInfoAcs";

        /// <summary>
        /// �Ǐ������b�N�N���X
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

        /// <summary>
        /// ���������ꂽ���ǂ���
        /// </summary>
        private static bool _initialized = false;

        /// <summary>
        /// �X�V�Ǘ��}�X�^�̃e�[�u���W�J����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandAddrUpdMngWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //�Ǘ��}�X�^�W�J
            foreach (AddrUpdMngWork mngWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = mngWork.AddrConnectCd1;
                row[COLUMN_AddrUpdateDateTime] = mngWork.AddrUpdateDateTime.Ticks;

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// �Z���R�[�h�C���f�b�N�X�}�X�^�̃e�[�u���W�J����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandAddrCdIndxWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //�Z���R�[�h�C���f�b�N�X�}�X�^�W�J
            foreach (AddrCdIndxWork indxWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = indxWork.AddrConnectCd1;
                row[COLUMN_AddressCode1Upper] = indxWork.AddressCode1Upper;

                table.Rows.Add(row);
            }

        }

        /// <summary>
        /// �X�֔ԍ��C���f�b�N�X�}�X�^�̃e�[�u���W�J����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandPostNoIndxWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //�X�֔ԍ��C���f�b�N�X�}�X�^�W�J
            foreach (PostNoIndxWork postWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = postWork.AddrConnectCd1;
                row[COLUMN_PostNoInitialChar] = postWork.PostNoInitialChar;

                table.Rows.Add(row);
            }

        }

        /// <summary>
        /// �����[�g����C���f�b�N�X���擾��f�B�X�N�ɃL���b�V�����܂�
        /// </summary>
        /// <param name="addrCdIndxList"></param>
        /// <param name="postNoIndxList"></param>
        /// <returns></returns>
        private static int SearchIndex(out ArrayList addrCdIndxList, out ArrayList postNoIndxList)
        {
            addrCdIndxList = null;
            postNoIndxList = null;

            object objAddrCdIndxList = null;
            object objPostNoIndxList = null;

            //�Ǎ����b�N�m��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                //�C���f�b�N�X�}�X�^���擾
                int status = iOfferAddressInfo.SearchAddrCdIndxAndPostNoIndx(out objAddrCdIndxList, out objPostNoIndxList);

                //���s������߂�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //�̗p���X�g�ɓ���Ƃ�
                addrCdIndxList = objAddrCdIndxList as ArrayList;
                postNoIndxList = objPostNoIndxList as ArrayList;

                OfflineDataSerializer serializer = new OfflineDataSerializer();

                //�f�B�X�N�ۑ�
                serializer.Serialize(classID, new string[] { "AddrCdIndxWork" }, objAddrCdIndxList);
                serializer.Serialize(classID, new string[] { "PostNoIndxWork" }, objPostNoIndxList);
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }


        /// <summary>
        /// �X�V�}�X�^��r�p���\�b�h
        /// </summary>
        /// <param name="oldList"></param>
        /// <param name="newList"></param>
        /// <returns></returns>
        private static bool CompareAddrUpdMngWorkList( ArrayList oldList, ArrayList newList )
        {
            if (oldList == null)
            {
                return false;
            }

            if (newList == null)
            {
                return false;
            }

            Dictionary<string, int> compareList = new Dictionary<string, int>();

            //�܂��͋����X�g�������ɓW�J
            for (int i = 0; i < oldList.Count; i++)
            {
                AddrUpdMngWork mngWork = oldList[i] as AddrUpdMngWork;

                compareList.Add(mngWork.AddrConnectCd1.ToString() + ":" + mngWork.AddrUpdateDateTime.ToString(), 0);
            }

            //�V���X�g�̒��g�������X�g����폜
            for (int i = 0; i < newList.Count; i++)
            {
                AddrUpdMngWork mngWork = newList[i] as AddrUpdMngWork;

                string key = mngWork.AddrConnectCd1.ToString() + ":" + mngWork.AddrUpdateDateTime.ToString();
                //�܂܂�ċ��Ȃ��Ȃ�ǉ�����Ă�
                if (!compareList.ContainsKey(key))
                {
                    return false;
                }

                compareList.Remove(key);
            }

            //�Ō�ɉ����c���Ă��������Ă�
            if (compareList.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �C���f�b�N�X�������[�h����
        /// </summary>
        private static int LoadIndex()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //�����݃��b�N�l��
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                //�������ς݂Ȃ�߂�
                if (_initialized)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                try
                {
                    OfflineDataSerializer serializer = new OfflineDataSerializer();

                    //�܂��͍X�V�Ǘ��}�X�^���L���b�V�������������o��
                    ArrayList addrUpdMngList = serializer.DeSerialize(classID, new string[] { "AddrUpdMngWork" }) as ArrayList;

                    ArrayList addrCdIndxList = serializer.DeSerialize(classID, new string[] { "AddrCdIndxWork" }) as ArrayList;

                    ArrayList postNoIndxList = serializer.DeSerialize(classID, new string[] { "PostNoIndxWork" }) as ArrayList;

                    //�I�����C�����̏���
                    if (LoginInfoAcquisition.OnlineFlag)
                    {
                        //���̓����[�g����擾
                        object objAddrUpdMngList = null;
                        status = iOfferAddressInfo.SearchAddrUpdMng(out objAddrUpdMngList);

                        //�����[�g������Ȃ�������߂�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        //�L���b�V�����Ȃ��Ȃ�V�������̂��̗p����
                        if (!CompareAddrUpdMngWorkList(addrUpdMngList, objAddrUpdMngList as ArrayList))
                        {
                            //�̗p���X�g�ɓ���Ƃ�
                            addrUpdMngList = objAddrUpdMngList as ArrayList;
                            //�f�B�X�N�ۑ�
                            serializer.Serialize(classID, new string[] { "AddrUpdMngWork" }, objAddrUpdMngList);

                            //�����[�g����f�[�^�擾
                            status = SearchIndex(out addrCdIndxList, out postNoIndxList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }

                        //�L���b�V�����Ȃ������ꍇ
                        if (addrCdIndxList == null || postNoIndxList == null)
                        {
                            status = SearchIndex(out addrCdIndxList, out postNoIndxList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }
                    }

                    //�J�����쐬
                    addrUpdMngTable = new DataTable();
                    CreateAddrUpdMngTableColumn(addrUpdMngTable);

                    addrCdIndxTable = new DataTable();
                    CreateAddrCdIndxTableColumn(addrCdIndxTable);

                    postNoIndxTable = new DataTable();
                    CreatePostNoIndxTableColumn(postNoIndxTable);

                    //�f�[�^�W�J
                    ExpandAddrUpdMngWorkList(addrUpdMngList, addrUpdMngTable);
                    ExpandAddrCdIndxWorkList(addrCdIndxList, addrCdIndxTable);
                    ExpandPostNoIndxWorkList(postNoIndxList, postNoIndxTable);

                }
                finally
                {
                    if (LoginInfoAcquisition.OnlineFlag)
                    {
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //���[�h�ł��ĂȂ��Ȃ����
                            addrUpdMngTable = null;
                            addrCdIndxTable = null;
                            postNoIndxTable = null;
                        }
                    }
                    else
                    {
                        //�I�t���C���̏ꍇ��NORMAL
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }

                //����������
                _initialized = true;
            }
            finally
            {
                //�����݃��b�N�J��
                _readerWriterLock.ReleaseWriterLock();
            }

            return status;
        }

        private readonly static string COLUMN_AddrConnectCd1 = "�Z���A���R�[�h�P";

        private readonly static string COLUMN_AddrUpdateDateTime = "�Z���X�V����";

        private readonly static string COLUMN_AddressCode1Upper = "�s���{���R�[�h";

        private readonly static string COLUMN_PostNoInitialChar = "�X�֔ԍ�������";

        /// <summary>
        /// �X�V�Ǘ��p�e�[�u��
        /// </summary>
        /// <param name="table"></param>
        private static void CreateAddrUpdMngTableColumn( DataTable table )
        {
            table.Columns.Add(COLUMN_AddrUpdateDateTime, typeof(long));
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
        }

        /// <summary>
        /// �Z���}�X�^�Z���R�[�h�C���f�b�N�X�}�X�^
        /// </summary>
        /// <param name="table"></param>
        private static void CreateAddrCdIndxTableColumn(DataTable table)
        {
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
            table.Columns.Add(COLUMN_AddressCode1Upper, typeof(int));
        }

        /// <summary>
        /// �Z���}�X�^�X�֔ԍ��C���f�b�N�X�}�X�^
        /// </summary>
        /// <param name="table"></param>
        private static void CreatePostNoIndxTableColumn(DataTable table)
        {
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
            table.Columns.Add(COLUMN_PostNoInitialChar, typeof(int));
        }

        /// <summary>
        /// �X�֔ԍ�����Z���A���R�[�h�P���擾����
        /// </summary>
        /// <param name="postNo"></param>
        /// <param name="addrConnectCd1"></param>
        /// <returns></returns>
        public static int GetAddrConnectCd1(string postNo, out int[] addrConnectCd1)
        {
            addrConnectCd1 = new int[0];
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (postNo == null || postNo.Length <= 0 || !Char.IsDigit(postNo[0]))
            {
                return status;
            }

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //�Ǎ����b�N�m��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}='{1}'";

                string selectString = String.Format(selectBaseString, COLUMN_PostNoInitialChar, postNo[0].ToString());

                DataRow[] rows = postNoIndxTable.Select(selectString);

                addrConnectCd1 = new int[rows.Length];

                //���ʎ擾
                for (int i = 0; i < rows.Length; i++)
                {
                    addrConnectCd1[i] = (int)rows[i][COLUMN_AddrConnectCd1];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �Z���R�[�h�P����Z���A���R�[�h�P���擾����
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addrConnectCd1"></param>
        /// <returns></returns>
        public static int GetAddrConnectCd1( int addressCode1, out int[] addrConnectCd1 )
        {
            addrConnectCd1 = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string strAddressCode1 = String.Format("{0:D5}", addressCode1);
            string strAddressCode1Upper = strAddressCode1.ToString().Substring(0, 2);
            int addressCode1Upper = int.Parse(strAddressCode1Upper);

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //�Ǎ��݃��b�N�J��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}={1}";
                string selectString = String.Format(selectBaseString, COLUMN_AddressCode1Upper, addressCode1Upper);

                DataRow[] rows = addrCdIndxTable.Select(selectString);

                addrConnectCd1 = new int[rows.Length];

                //���ʎ擾
                for (int i = 0; i < rows.Length; i++)
                {
                    addrConnectCd1[i] = (int)rows[i][COLUMN_AddrConnectCd1];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
        }

        /// <summary>
        /// �w��Z���A���R�[�h�P�̍X�V���t���擾����
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        public static int GetLastUpdateTime(int addrConnectCd1, out long lastUpdate)
        {
            lastUpdate = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (addrConnectCd1 == 0)
            {
                return status;
            }

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //�Ǎ����b�N�m��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}={1}";
                string selectString = String.Format(selectBaseString, COLUMN_AddrConnectCd1, addrConnectCd1);

                DataRow[] rows = addrUpdMngTable.Select(selectString);

                //���ʎ擾
                if (rows.Length > 0)
                {
                    lastUpdate = (long)rows[0][COLUMN_AddrUpdateDateTime];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            finally
            {
                //�����݃��b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
        }

    }

}

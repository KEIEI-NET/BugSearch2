using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R���[���[�J���f�[�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̃��[�J���f�[�^�ւ̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 22024 ����@�_�u</br>
    /// <br>Date		: 2007.04.12</br>
    /// <br></br>
    /// <br>Update Note	: 2008.03.17 22024 ����_�u</br>
    /// <br>			: �P�D���[�J���f�[�^���݃`�F�b�N���\�b�h��ǉ�</br>
    /// </remarks>
    public class FrePrtPosLocalAcs
    {
        #region Const
        private const string ctSave_Key = "66f05f0d-030a-491a-8009-782e46a1eb3e";
        private const string ctExtension = ".DAT";
        // ���[�J���t�@�C�����ʃt�@�C���w�b�_�[����
        private const string ctFileID_FrePrtPSet = "FrePrtPSet";		// ���R���[�󎚈ʒu�ݒ�}�X�^
        private const string ctFileID_PrtItemGrpWork = "PrtItemGrpWork";	// �󎚍��ڃO���[�v�}�X�^
        private const string ctFileID_FPprSchmGrWork = "FPprSchmGrWork";	// ���R���[�X�L�[�}�O���[�v�}�X�^
        #endregion

        #region PrivateMember
        // �G���[���b�Z�[�W
        private string _errorStr;
        #endregion

        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePrtPosLocalAcs()
        {
        }
        #endregion

        #region Property
        /// <summary>�G���[���b�Z�[�W</summary>
        /// <remarks>�ǂݎ���p</remarks>
        public string ErrorMessage
        {
            get { return _errorStr; }
        }
        #endregion

        #region PublicMethod
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�ۑ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J���ɕۑ����܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFrePrtPSet( FrePrtPSet frePrtPSet, List<FrePprECnd> frePprECndList, List<FrePprSrtO> frePprSrtOList )
        {
            // �t�@�C���p�X����
            string filePath = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );

            return WriteLocalFrePrtPSet( frePrtPSet, frePprECndList, frePprSrtOList, filePath );
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�ۑ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <param name="filePath">�ۑ���t�@�C���p�X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J���ɕۑ����܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFrePrtPSet( FrePrtPSet frePrtPSet, List<FrePprECnd> frePprECndList, List<FrePprSrtO> frePprSrtOList, string filePath )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( frePrtPSet );
                writeList.Add( frePprECndList );
                writeList.Add( frePprSrtOList );

                // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃V���A���C�Y�\�j
                Type[] typeArray = new Type[] { typeof( FrePrtPSet ), typeof( List<FrePprECnd> ), typeof( List<FrePprSrtO> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), filePath, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[�󎚈ʒu�ݒ�̃��[�J���f�[�^�ۑ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�Ǎ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFrePrtPSet( ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            // �t�@�C���p�X����
            string filePath = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );

            FrePrtPSet wkFrePrtPSet;
            int status = ReadLocalFrePrtPSet( out wkFrePrtPSet, out frePprECndList, out frePprSrtOList, filePath );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( frePrtPSet.EnterpriseCode == wkFrePrtPSet.EnterpriseCode )
                    frePrtPSet = wkFrePrtPSet;
                else
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�Ǎ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <param name="filePath">�Ǎ��t�@�C���p�X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFrePrtPSet( out FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList, string filePath )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            frePrtPSet = null;
            frePprECndList = null;
            frePprSrtOList = null;

            FrePrtPSet wkFrePrtPSet;
            List<FrePprECnd> wkFrePprECndList;
            List<FrePprSrtO> wkFrePprSrtOList;
            status = ReadLocalFrePrtPSetProc( filePath, out wkFrePrtPSet, out wkFrePprECndList, out wkFrePprSrtOList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                frePrtPSet = wkFrePrtPSet;
                frePprECndList = wkFrePprECndList;
                frePprSrtOList = wkFrePprSrtOList;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�폜�����i���[�J���f�[�^�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J�����폜���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int DeleteLocalFrePrtPSet( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                // �t�@�C���p�X����
                string fileName = CreateFilePathForFrePrtPSet( outputFormFileName, userPrtPprIdDerivNo );
                if ( File.Exists( fileName ) )
                {
                    FrePrtPSet frePrtPSet;
                    List<FrePprECnd> frePprECndList;
                    List<FrePprSrtO> frePprSrtOList;
                    status = ReadLocalFrePrtPSet( out frePrtPSet, out frePprECndList, out frePprSrtOList, fileName );
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        if ( frePrtPSet.EnterpriseCode == enterpriseCode )
                            File.Delete( fileName );
                    }
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[�󎚈ʒu�ݒ�̃��[�J���f�[�^�폜�����ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ茟�������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�g�p�敪</param>
        /// <param name="frePrtPSetList">���R���[�󎚈ʒu�ݒ�}�X�^���X�g</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J���ɂ��鎩�R���[�󎚈ʒu����S���擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int SearchLocalFrePrtPSet( string enterpriseCode, int printPaperUseDivcd, out List<FrePrtPSet> frePrtPSetList, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            frePrtPSetList = new List<FrePrtPSet>();
            frePprECndList = new List<FrePprECnd>();
            frePprSrtOList = new List<FrePprSrtO>();

            try
            {
                string targetDirectory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTPOS );
                if ( Directory.Exists( targetDirectory ) )
                {
                    string[] fileNames = Directory.GetFiles( targetDirectory, ctFileID_FrePrtPSet + "*" + ctExtension );
                    foreach ( string filePath in fileNames )
                    {
                        FrePrtPSet wkFrePrtPSet;
                        List<FrePprECnd> wkFrePprECndList = new List<FrePprECnd>();
                        List<FrePprSrtO> wkFrePprSrtOList = new List<FrePprSrtO>();
                        status = ReadLocalFrePrtPSetProc( filePath, out wkFrePrtPSet, out wkFrePprECndList, out wkFrePprSrtOList );
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            if ( wkFrePrtPSet.EnterpriseCode == enterpriseCode )
                            {
                                if ( printPaperUseDivcd == 0 || wkFrePrtPSet.PrintPaperUseDivcd == printPaperUseDivcd )
                                {
                                    frePrtPSetList.Add( wkFrePrtPSet );
                                    frePprECndList.AddRange( wkFrePprECndList );
                                    frePprSrtOList.AddRange( wkFrePprSrtOList );
                                }
                            }
                        }
                    }
                }

                if ( frePrtPSetList.Count == 0 )
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[�󎚈ʒu�ݒ�̃��[�J���f�[�^���������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �󎚍��ڃO���[�v�ۑ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="prtItemGrp">�󎚍��ڃO���[�v�}�X�^</param>
        /// <param name="prtItemSetList">�󎚍��ڐݒ�}�X�^���X�g</param>
        /// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�󎚍��ڃO���[�v�����[�J���ɕۑ����܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalPrtItemGrpWork( PrtItemGrpWork prtItemGrp, List<PrtItemSetWork> prtItemSetList, List<FPSortInitWork> fPSortInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( prtItemGrp );
                writeList.Add( prtItemSetList );
                if ( fPSortInitList == null ) fPSortInitList = new List<FPSortInitWork>();
                writeList.Add( fPSortInitList );

                // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃V���A���C�Y�\�j
                Type[] typeArray = new Type[] { typeof( PrtItemGrpWork ), typeof( List<PrtItemSetWork> ), typeof( List<FPSortInitWork> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                // �t�@�C���p�X����
                string fileName = CreateFilePathForPrtItemGrp( prtItemGrp.FreePrtPprItemGrpCd );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), fileName, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "�󎚍��ڐݒ�̃��[�J���f�[�^�ۑ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �󎚍��ڃO���[�v�Ǎ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">�󎚍��ڃO���[�v�R�[�h</param>
        /// <param name="prtItemGrp">�󎚍��ڃO���[�v�}�X�^</param>
        /// <param name="prtItemSetList">�󎚍��ڐݒ�}�X�^LIST</param>
        /// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�󎚍��ڃO���[�v�����[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalPrtItemGrpWork( int freePrtPprItemGrpCd, out PrtItemGrpWork prtItemGrp, out List<PrtItemSetWork> prtItemSetList, out List<FPSortInitWork> fPSortInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            prtItemGrp = null;
            prtItemSetList = new List<PrtItemSetWork>();
            fPSortInitList = new List<FPSortInitWork>();

            try
            {
                // �t�@�C���p�X����
                string fileName = CreateFilePathForPrtItemGrp( freePrtPprItemGrpCd );

                if ( File.Exists( fileName ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( fileName, new string[] { ctSave_Key } );

                    // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃f�V���A���C�Y�\�j
                    Type[] typeArray = new Type[] { typeof( PrtItemGrpWork ), typeof( List<PrtItemSetWork> ), typeof( List<FPSortInitWork> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is PrtItemGrpWork )
                                prtItemGrp = (PrtItemGrpWork)readList[ix];
                            else if ( readList[ix] is List<PrtItemSetWork> )
                                prtItemSetList = (List<PrtItemSetWork>)readList[ix];
                            else if ( readList[ix] is List<FPSortInitWork> )
                                fPSortInitList = (List<FPSortInitWork>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( prtItemGrp == null || prtItemSetList.Count == 0 )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "�󎚍��ڃO���[�v�̃��[�J���f�[�^�Ǎ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�X�L�[�}�O���[�v�ۑ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="fPprSchmGr">���R���[�X�L�[�}�O���[�v�}�X�^</param>
        /// <param name="fPprSchmCvList">���R���[�X�L�[�}�R���o�[�g�}�X�^</param>
        /// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
        /// <param name="fPECndInitList">���R���[���o���������l�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�󎚍��ڃO���[�v�����[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFPprSchmGrWork( FPprSchmGrWork fPprSchmGr, List<FPprSchmCvWork> fPprSchmCvList, List<FPSortInitWork> fPSortInitList, List<FPECndInitWork> fPECndInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( fPprSchmGr );
                writeList.Add( fPprSchmCvList );
                if ( fPSortInitList == null ) fPSortInitList = new List<FPSortInitWork>();
                writeList.Add( fPSortInitList );
                if ( fPECndInitList == null ) fPECndInitList = new List<FPECndInitWork>();
                writeList.Add( fPECndInitList );

                // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃V���A���C�Y�\�j
                Type[] typeArray = new Type[] { typeof( FPprSchmGrWork ), typeof( List<FPprSchmCvWork> ), typeof( List<FPSortInitWork> ), typeof( List<FPECndInitWork> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                // �t�@�C���p�X����
                string fileName = CreateFilePathForFPprSchmGr( fPprSchmGr.FreePrtPprSchmGrpCd );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), fileName, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[�X�L�[�}�O���[�v�̃��[�J���f�[�^�ۑ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���R���[�X�L�[�}�O���[�v�Ǎ������i���[�J���f�[�^�j
        /// </summary>
        /// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
        /// <param name="fPprSchmGr">���R���[�X�L�[�}�O���[�v�}�X�^</param>
        /// <param name="fPprSchmCvList">���R���[�X�L�[�}�R���o�[�g�}�X�^���X�g</param>
        /// <param name="fPSortInitList">���R���[�\�[�g���ʏ����l�}�X�^���X�g</param>
        /// <param name="fPECndInitList">���R���[���o���������l�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�X�L�[�}�O���[�v�����[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFPprSchmGrWork( int freePrtPprSchmGrpCd, out FPprSchmGrWork fPprSchmGr, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            fPprSchmGr = null;
            fPprSchmCvList = new List<FPprSchmCvWork>();
            fPSortInitList = new List<FPSortInitWork>();
            fPECndInitList = new List<FPECndInitWork>();

            try
            {
                // �t�@�C���p�X����
                string fileName = CreateFilePathForFPprSchmGr( freePrtPprSchmGrpCd );

                if ( File.Exists( fileName ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( fileName, new string[] { ctSave_Key } );

                    // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃f�V���A���C�Y�\�j
                    Type[] typeArray = new Type[] { typeof( FPprSchmGrWork ), typeof( List<FPprSchmCvWork> ), typeof( List<FPSortInitWork> ), typeof( List<FPECndInitWork> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is FPprSchmGrWork )
                                fPprSchmGr = (FPprSchmGrWork)readList[ix];
                            else if ( readList[ix] is List<FPprSchmCvWork> )
                                fPprSchmCvList = (List<FPprSchmCvWork>)readList[ix];
                            else if ( readList[ix] is List<FPSortInitWork> )
                                fPSortInitList = (List<FPSortInitWork>)readList[ix];
                            else if ( readList[ix] is List<FPECndInitWork> )
                                fPECndInitList = (List<FPECndInitWork>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( fPprSchmGr == null || fPprSchmCvList.Count == 0 )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "�󎚍��ڃO���[�v�̃��[�J���f�[�^�Ǎ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���[�J���f�[�^���݃`�F�b�N
        /// </summary>
        /// <param name="frePrtPSetList">���R���[�󎚈ʒu�ݒ�}�X�^���X�g</param>
        /// <returns>�t�B���^�[���ʃ��X�g</returns>
        /// <remarks>
        /// <br>Note       : �n���ꂽ�f�[�^�̂������[�J���f�[�^�����݂���f�[�^�S�Ă��擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2008.03.17</br>
        /// </remarks>
        public List<FrePrtPSet> FindAllLocalDataExists( List<FrePrtPSet> frePrtPSetList )
        {
            List<FrePrtPSet> retList = new List<FrePrtPSet>();

            if ( frePrtPSetList != null && frePrtPSetList.Count > 0 )
            {
                foreach ( FrePrtPSet frePrtPSet in frePrtPSetList )
                {
                    string fileName = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );
                    if ( File.Exists( fileName ) )
                        retList.Add( frePrtPSet.Clone() );
                }
            }

            return retList;
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// �t�@�C���p�X�쐬����
        /// </summary>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <returns>�t�@�C���p�X</returns>
        /// <remarks>
        /// <br>Note       : �L�[����t�^�����t�@�C���p�X���쐬���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForFrePrtPSet( string outputFormFileName, int userPrtPprIdDerivNo )
        {
            // �t�@�C���p�X����
            string fileName = ctFileID_FrePrtPSet + "_" + outputFormFileName + "_" + userPrtPprIdDerivNo.ToString( "000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTPOS );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�Ǎ������i���C�����j
        /// </summary>
        /// <param name="filePath">�t�@�C����</param>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="frePprECndList">���R���[���o�����ݒ�}�X�^���X�g</param>
        /// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���R���[�󎚈ʒu�������[�J�����擾���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private int ReadLocalFrePrtPSetProc( string filePath, out FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            frePrtPSet = null;
            frePprECndList = new List<FrePprECnd>();
            frePprSrtOList = new List<FrePprSrtO>();

            try
            {
                if ( File.Exists( filePath ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( filePath, new string[] { ctSave_Key } );

                    // XmlSerializer�̃R���X�g���N�^�Ō^���w��i�����ArrayList���̓Ǝ��N���X�̃f�V���A���C�Y�\�j
                    Type[] typeArray = new Type[] { typeof( FrePrtPSet ), typeof( List<FrePprECnd> ), typeof( List<FrePprSrtO> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is FrePrtPSet )
                                frePrtPSet = (FrePrtPSet)readList[ix];
                            else if ( readList[ix] is List<FrePprECnd> )
                                frePprECndList = (List<FrePprECnd>)readList[ix];
                            else if ( readList[ix] is List<FrePprSrtO> )
                                frePprSrtOList = (List<FrePprSrtO>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( frePrtPSet == null )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    _errorStr = "���R���[�󎚈ʒu�ݒ胍�[�J���f�[�^������܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[�󎚈ʒu�ݒ�̃��[�J���f�[�^�Ǎ������ɂė�O���������܂����B";
                _errorStr += "\r\n" + ex.Message;

                frePrtPSet = null;
                frePprECndList.Clear();
                frePprSrtOList.Clear();

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �t�@�C���p�X�쐬����
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">�󎚍��ڃO���[�v�R�[�h</param>
        /// <returns>�t�@�C���p�X</returns>
        /// <remarks>
        /// <br>Note       : �L�[����t�^�����t�@�C���p�X���쐬���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForPrtItemGrp( int freePrtPprItemGrpCd )
        {
            // �t�@�C���p�X����
            string fileName = ctFileID_PrtItemGrpWork + "_" + freePrtPprItemGrpCd.ToString( "0000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTITEM );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }

        /// <summary>
        /// �t�@�C���p�X�쐬����
        /// </summary>
        /// <param name="freePrtPprSchmGrpCd">���R���[�X�L�[�}�O���[�v�R�[�h</param>
        /// <returns>�t�@�C���p�X</returns>
        /// <remarks>
        /// <br>Note       : �L�[����t�^�����t�@�C���p�X���쐬���܂��B</br>
        /// <br>Programmer : 22024 ����_�u</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForFPprSchmGr( int freePrtPprSchmGrpCd )
        {
            // �t�@�C���p�X����
            string fileName = ctFileID_FPprSchmGrWork + "_" + freePrtPprSchmGrpCd.ToString( "0000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTSCHEMA );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }
        #endregion
    }
}

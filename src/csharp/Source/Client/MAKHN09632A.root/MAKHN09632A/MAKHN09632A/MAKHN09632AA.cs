using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
	/// <summary>
    ///�摜���}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �摜���}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22022 �i�� �m�q</br>
    /// <br>Date       : 2007.05.16</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// <br>UpdateNote : 2008/10/29 �@     �Ɠc �M�u</br>
    /// <br>           : �o�O�C���A�d�l�ύX�Ή�</br>
    /// </remarks>
	public class ImageInfoAcs
	{
		// --------------------------------------------------
		#region Private Members

        // ��ƃR�[�h
        private string          _enterpriseCode = "";

        /// <summary>�摜���}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IImageInfoDB    _iImageInfoDB   = null;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private ImageInfoLcDB _imageInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        // �f�[�^�Z�b�g
        private DataSet         _bindDataSet    = null;
        private DataTable       _imageInfoTable = null;

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, ImageInfoWork>  _imageInfoDic   = null;    // �摜���}�X�^�i�[�p

        // �}�X�^�擾�p���X�g
        private ArrayList       _imageInfoList  = null;                     // �摜���}�X�^�擾�p

        #endregion

        // --------------------------------------------------
        #region Public Members

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_IMAGEINFO_TITLE           = "IMAGEINFO_TABLE";
        public static readonly string COL_DELETEDATE_TITLE          = "�폜��";
        public static readonly string COL_IMAGEINFODIVCODE_TITLE    = "�摜���敪�R�[�h";
        public static readonly string COL_IMAGEINFODIVNAME_TITLE    = "�摜���敪";
        public static readonly string COL_IMAGEINFOCODE_TITLE       = "�摜���R�[�h";
        //public static readonly string COL_IMAGEINFONAME_TITLE       = "�摜���\������";             //DEL 2008/10/29 ���̕ύX
        public static readonly string COL_IMAGEINFONAME_TITLE       = "�摜���\����";                 //ADD 2008/10/29
        public static readonly string COL_IMAGEINFOFLTYPE_TITLE     = "�摜���t�@�C���^�C�v";
        public static readonly string COL_IMAGEINFODATA_TITLE       = "�摜���f�[�^";
        public static readonly string COL_GUID_TITLE                = "GUID";

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///�摜���}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public ImageInfoAcs()
		{
			try {
				// ��ƃR�[�h�擾
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// �����[�g�I�u�W�F�N�g�擾
                this._iImageInfoDB      = (IImageInfoDB)MediationImageInfoDB.GetImageInfoDB();

                // �}�X�^�N���X�i�[���X�g������
                this._imageInfoDic = new Dictionary<Guid, ImageInfoWork>();

                // �}�X�^�擾�p���X�g������
                this._imageInfoList = new ArrayList();

                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
                this._iImageInfoDB = null;
			}
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._imageInfoLcDB = new ImageInfoLcDB();
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
        }

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// �摜���e�[�u��
			this._imageInfoTable = new DataTable( TBL_IMAGEINFO_TITLE );

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			this._imageInfoTable.Columns.Add( COL_DELETEDATE_TITLE          , typeof( string ) );   // �폜��
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODIVCODE_TITLE    , typeof( int    ) );   // �摜���敪�R�[�h
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODIVNAME_TITLE    , typeof( string ) );   // �摜���敪����
            //this._imageInfoTable.Columns.Add( COL_IMAGEINFOCODE_TITLE       , typeof( int    ) );   // �摜���R�[�h     //DEL 2008/10/29 0�l�߂̈�
            this._imageInfoTable.Columns.Add(COL_IMAGEINFOCODE_TITLE        , typeof( string ) );   // �摜���R�[�h       //ADD 2008/10/29
            this._imageInfoTable.Columns.Add(COL_IMAGEINFONAME_TITLE        , typeof( string ) );   // �摜���\������
			this._imageInfoTable.Columns.Add( COL_IMAGEINFOFLTYPE_TITLE     , typeof( string ) );   // �摜���t�@�C���^�C�v
			this._imageInfoTable.Columns.Add( COL_IMAGEINFODATA_TITLE       , typeof( Byte[] ) );   // �摜���f�[�^
            this._imageInfoTable.Columns.Add( COL_GUID_TITLE                , typeof( Guid   ) );   // GUID

            // PrimaryKey�ݒ�
            this._imageInfoTable.PrimaryKey = new DataColumn[] { this._imageInfoTable.Columns[COL_IMAGEINFODIVCODE_TITLE],      // �摜���敪�R�[�h
                                                                 this._imageInfoTable.Columns[COL_IMAGEINFOCODE_TITLE]     };   // �摜���R�[�h

            this._bindDataSet.Tables.Add(this._imageInfoTable);
		}

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾
			if( this._iImageInfoDB == null ) {
				// �I�t���C��
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				// �I�����C��
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Read Methods

		/// <summary>
        ///�ǂݍ��ݏ���
		/// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="imageInfoDiv">�摜���敪</param>
        /// <param name="imageInfoCode">�摜���R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Read(out ImageInfo imageInfo, string enterpriseCode, int imageInfoDiv, int imageInfoCode)
		{
            return this.ReadProc(out imageInfo, enterpriseCode, imageInfoDiv, imageInfoCode);
		}

		/// <summary>
        ///�摜���}�X�^�ǂݍ��ݏ���
		/// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="imageInfoDiv">�摜���敪</param>
        /// <param name="imageInfoCode">�摜���R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        private int ReadProc(out ImageInfo imageInfo, string enterpriseCode, int imageInfoDiv, int imageInfoCode)
		{
            int status = 0;
            imageInfo = null;

            try
            {
                ImageInfoWork imageInfoWork = new ImageInfoWork();

                // �擾�ς݃f�[�^�����݂���ꍇ
                if (this._imageInfoDic.Count > 0)
                {
                    // �Ώۃf�[�^���擾�ς݂̏ꍇ
                    // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� >>>>>>START
                    //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoDiv + "' and " +
                    //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoCode + "'";
                    string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoDiv + "' and " +
                                            COL_IMAGEINFOCODE_TITLE + " = " + imageInfoCode;
                    // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� <<<<<<END
                    string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
                    DataRow[] dr = this._imageInfoTable.Select(selectCommand1, sortCommand1);
                    if (dr.Length > 0)
                    {
                        imageInfoWork = (this._imageInfoDic[(Guid)dr[0][COL_GUID_TITLE]] as ImageInfoWork);
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                        return status;
                    }
                }

                // �L�[�����Z�b�g
                imageInfoWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
                imageInfoWork.ImageInfoDiv = imageInfoDiv;      // �摜���敪
                imageInfoWork.ImageInfoCode = imageInfoCode;    // �摜���R�[�h

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
                //byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);
                //
                ////�摜���}�X�^�ǂݍ���
                //status = this._iImageInfoDB.Read(ref parabyte, 0);
                //
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    // �f�V���A���C�Y����
                //    imageInfoWork = (ImageInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ImageInfoWork));
                //
                //    // ���ʂ������o�R�s�[
                //    imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                //}
                if (_isLocalDBRead)
                {
                    //�摜���}�X�^�ǂݍ���
                    status = this._imageInfoLcDB.Read(ref imageInfoWork, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���ʂ������o�R�s�[
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                    }
                }
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);
                    //�摜���}�X�^�ǂݍ���
                    status = this._iImageInfoDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �f�V���A���C�Y����
                        imageInfoWork = (ImageInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ImageInfoWork));
                        // ���ʂ������o�R�s�[
                        imageInfo = this.CopyToImageInfoFromImageInfoWork(imageInfoWork);
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                imageInfo = null;
                this._iImageInfoDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Write Methods

		/// <summary>
        ///�������ݏ���
		/// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Write(ImageInfo imageInfo)
        {
            // �摜���}�X�^�X�V
            return this.WriteProc(imageInfo);
        }

		/// <summary>
        ///�摜���}�X�^�������ݏ���
		/// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int WriteProc(ImageInfo imageInfo)
		{
			int status = 0;

			try {
                ImageInfoWork imageInfoWork = new ImageInfoWork();

                // �ҏW�O���擾
                if (this._imageInfoDic.ContainsKey(imageInfo.FileHeaderGuid) == true)
                {
                    imageInfoWork = (this._imageInfoDic[imageInfo.FileHeaderGuid] as ImageInfoWork);
                }

                // �ҏW���擾
                CopyToImageInfoWorkFromImageInfo(ref imageInfoWork, imageInfo);

                object retObj = (object)imageInfoWork;

                //�摜���}�X�^��������
                status = this._iImageInfoDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    imageInfoWork = (ImageInfoWork)retArray[0];
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iImageInfoDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods

		/// <summary>
        ///�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // �摜���}�X�^�_���폜
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///�摜���}�X�^�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                object retObj = (object)imageInfoWork;

                //�摜���}�X�^�_���폜
                status = this._iImageInfoDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    imageInfoWork = (ImageInfoWork)retObj;
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iImageInfoDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
        }

		#endregion

		// --------------------------------------------------
		#region Revival Methods

		/// <summary>
        ///�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // �摜���}�X�^����
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///�摜���}�X�^�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                object retObj = (object)imageInfoWork;

                //�摜���}�X�^�_���폜����
                status = this._iImageInfoDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    imageInfoWork = (ImageInfoWork)retObj;
                    this.ImageInfoWorkToDataSet(imageInfoWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iImageInfoDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        ///�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // �摜���}�X�^�����폜
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///�摜���}�X�^�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�摜���}�X�^Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                ImageInfoWork imageInfoWork = (this._imageInfoDic[fileHeaderGuid] as ImageInfoWork);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(imageInfoWork);

                //�摜���}�X�^�����폜
                status = this._iImageInfoDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._imageInfoDic.Remove(imageInfoWork.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� >>>>>>START
                    //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                    //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoWork.ImageInfoCode + "'";
                    string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                                            COL_IMAGEINFOCODE_TITLE + " = " + imageInfoWork.ImageInfoCode;
                    // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� <<<<<<END
                    string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
                    DataRow[] dr = this._imageInfoTable.Select(selectCommand1, sortCommand1);
                    if (dr.Length > 0)
                    {
                        dr[0].Delete();
                    }
				}
			}
			catch( Exception) {
				// �I�t���C������null���Z�b�g
				this._iImageInfoDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
        ///��������(�_���폜����)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="ImageInfoDiv">��ʏ��敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        public int Search(out int totalCount, string enterpriseCode, int ImageInfoDiv)
        {
            // �摜���}�X�^����
            return this.SearchProc(out totalCount, enterpriseCode, ImageInfoDiv, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        ///��������(�_���폜�܂�)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // �摜���}�X�^����
            return this.SearchProc(out totalCount, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        ///��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="ImageInfoDiv">��ʏ��敪</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, int ImageInfoDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // �摜���}�X�^����
            status1 = this.SearchImegeInfoProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // �L���b�V������
            status2 = this.Cache(this._imageInfoList, ImageInfoDiv);
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return status1;
        }

        /// <summary>
        ///�摜���}�X�^��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �摜���}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        private int SearchImegeInfoProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._imageInfoList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._imageInfoDic.Clear();

                // �L�[�����Z�b�g
                ImageInfoWork paramImageInfoWork = new ImageInfoWork();
                paramImageInfoWork.EnterpriseCode = enterpriseCode;    // ��ƃR�[�h

                object retobj = null;

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                ////�摜���}�X�^����
                //status = this._iImageInfoDB.Search(out retobj, paramImageInfoWork, 0, logicalMode);
                //
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this._imageInfoList = retobj as ArrayList;
                //
                //    // �Y�������i�[
                //    totalCount = this._imageInfoList.Count;
                //}
                //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                //{
                //}
                if (_isLocalDBRead)
                {
                    //�摜���}�X�^����
                    List<ImageInfoWork> workList = new List<ImageInfoWork>();
                    status = this._imageInfoLcDB.Search(out workList, paramImageInfoWork, 0, logicalMode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �Y�������i�[
                        this._imageInfoList.AddRange(workList);
                        totalCount = this._imageInfoList.Count;
                    }
                }
                else
                {
                    //�摜���}�X�^����
                    status = this._iImageInfoDB.Search(out retobj, paramImageInfoWork, 0, logicalMode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._imageInfoList = retobj as ArrayList;
                        // �Y�������i�[
                        totalCount = this._imageInfoList.Count;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iImageInfoDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

		#endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        ///�}�X�^�L���b�V������
        /// </summary>
        /// <param name="imageInfoList">�摜���擾���ʃ��X�g</param>
        /// <param name="ImageInfoDiv">��ʏ��敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int Cache(ArrayList imageInfoList, int ImageInfoDiv)
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._imageInfoTable.BeginLoadData();

                    // �e�[�u�����N���A
                    this._imageInfoTable.Clear();

                    // �摜���f�[�^��DataSet�Ɋi�[
                    foreach (ImageInfoWork imageInfoWork in imageInfoList)
                    {
                        // ���o�^�̎�
                        if (this._imageInfoDic.ContainsKey(imageInfoWork.FileHeaderGuid) == false)
                        {
                            // �f�[�^�Z�b�g�ɒǉ�
                            this.ImageInfoWorkToDataSet(imageInfoWork);
                        }
                    }
                }
                finally
                {
                    // �X�V�����I��
                    this._imageInfoTable.EndLoadData();

                    // �t�B���^
                    if (ImageInfoDiv != 0)
                    {
                        this._imageInfoTable.DefaultView.RowFilter = COL_IMAGEINFODIVCODE_TITLE + " = '" + ImageInfoDiv + "'";  // �摜���敪�R�[�h
                    }

                    // �\�[�g
                    this._imageInfoTable.DefaultView.Sort = COL_IMAGEINFODIVCODE_TITLE + " ASC, " +     // �摜���敪�R�[�h
                                                            COL_IMAGEINFOCODE_TITLE    + " ASC";        // �摜���R�[�h
                    this._imageInfoTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�R�s�[���� (�摜���}�X�^�N���X�ˉ摜���}�X�^���[�N�N���X)
        /// </summary>
        /// <param name="imageInfoWork">�摜���}�X�^���[�N�N���X</param>
        /// <param name="imageInfo">�摜���}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �摜���}�X�^�N���X����
        ///                  �摜���}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void CopyToImageInfoWorkFromImageInfo(ref ImageInfoWork imageInfoWork, ImageInfo imageInfo)
        {
            imageInfoWork.EnterpriseCode    = imageInfo.EnterpriseCode;     // ��ƃR�[�h
            imageInfoWork.ImageInfoDiv      = imageInfo.ImageInfoDiv;       // �摜���敪
            imageInfoWork.ImageInfoCode     = imageInfo.ImageInfoCode;      // �摜���R�[�h
            imageInfoWork.ImageInfoName     = imageInfo.ImageInfoName;      // �摜���\������
            imageInfoWork.ImageInfoFlType   = imageInfo.ImageInfoFlType;    // �摜���t�@�C���^�C�v
            imageInfoWork.ImageInfoData     = imageInfo.ImageInfoData;      // �摜���f�[�^
        }

		/// <summary>
        /// �N���X�����o�R�s�[���� (�摜���}�X�^���[�N�N���X�ˉ摜���}�X�^�N���X)
		/// </summary>
        /// <param name="imageInfoWork">�摜���}�X�^���[�N�N���X</param>
        /// <returns>�摜���}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^���[�N�N���X����
        ///                  �摜���}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private ImageInfo CopyToImageInfoFromImageInfoWork(ImageInfoWork imageInfoWork)
        {
            ImageInfo imageInfo = new ImageInfo();

            imageInfo.CreateDateTime    = imageInfoWork.CreateDateTime;         // �쐬����
            imageInfo.UpdateDateTime    = imageInfoWork.UpdateDateTime;         // �X�V����
            imageInfo.EnterpriseCode    = imageInfoWork.EnterpriseCode;         // ��ƃR�[�h
            imageInfo.FileHeaderGuid    = imageInfoWork.FileHeaderGuid;         // GUID
            imageInfo.UpdEmployeeCode   = imageInfoWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            imageInfo.UpdAssemblyId1    = imageInfoWork.UpdAssemblyId1;         // �X�V�A�Z���u��ID1
            imageInfo.UpdAssemblyId2    = imageInfoWork.UpdAssemblyId2;         // �X�V�A�Z���u��ID2
            imageInfo.LogicalDeleteCode = imageInfoWork.LogicalDeleteCode;      // �_���폜�敪
            imageInfo.ImageInfoDiv      = imageInfoWork.ImageInfoDiv;           // �摜���敪
            imageInfo.ImageInfoCode     = imageInfoWork.ImageInfoCode;          // �摜���R�[�h
            imageInfo.ImageInfoName     = imageInfoWork.ImageInfoName;          // �摜���\������
            imageInfo.ImageInfoFlType   = imageInfoWork.ImageInfoFlType;        // �摜���t�@�C���^�C�v
            imageInfo.ImageInfoData     = imageInfoWork.ImageInfoData;          // �摜���f�[�^

            // �e�[�u���X�V
            _imageInfoDic[imageInfoWork.FileHeaderGuid] = imageInfoWork;

            return imageInfo;
        }

        /// <summary>
        /// �摜���}�X�^�I�u�W�F�N�g���C��DataSet�W�J����
        /// </summary>
        /// <param name="imageInfoWork">�摜���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �摜���}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoWorkToDataSet(ImageInfoWork imageInfoWork)
        {
            bool newFlg = false;    // �V�K�E�����t���O
            DataRow dr = null;
            ImageInfo imageInfo = new ImageInfo();

            // �X�V�Ώۍs�̎擾
            // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� >>>>>>START
            //string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
            //                        COL_IMAGEINFOCODE_TITLE + " = '" + imageInfoWork.ImageInfoCode + "'";
            string selectCommand1 = COL_IMAGEINFODIVCODE_TITLE + " = '" + imageInfoWork.ImageInfoDiv + "' and " +
                                    COL_IMAGEINFOCODE_TITLE + " = " + imageInfoWork.ImageInfoCode;
            // 2009.03.25 30413 ���� �t�B���^�̐ݒ���C�� <<<<<<END
            string sortCommand1 = COL_IMAGEINFODIVCODE_TITLE + " ASC , " + COL_IMAGEINFOCODE_TITLE + " ASC";
            DataRow[] dr2 = this._imageInfoTable.Select(selectCommand1, sortCommand1);

            if (dr2.Length <= 0)
            {
                // �V�K�ɍs���쐬
                dr = this._imageInfoTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }
            else
            {
                dr = dr2[0];
            }

            // �폜��
            if (imageInfoWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", imageInfoWork.UpdateDateTime);
            }
            dr[COL_IMAGEINFODIVCODE_TITLE]  = imageInfoWork.ImageInfoDiv;                                           // �摜���敪�R�[�h
            dr[COL_IMAGEINFODIVNAME_TITLE]  = (string)imageInfo.GetImageInfoDivName(imageInfoWork.ImageInfoDiv);    // �摜���敪����
            //dr[COL_IMAGEINFOCODE_TITLE]     = imageInfoWork.ImageInfoCode;                                          // �摜���R�[�h         //DEL 2008/10/29 0�l�߂̈�
            dr[COL_IMAGEINFOCODE_TITLE]     = imageInfoWork.ImageInfoCode.ToString("000000000");                    // �摜���R�[�h
            dr[COL_IMAGEINFONAME_TITLE]     = imageInfoWork.ImageInfoName;                                          // �摜���\������
            dr[COL_IMAGEINFOFLTYPE_TITLE]   = imageInfoWork.ImageInfoFlType;                                        // �摜���t�@�C���^�C�v
            dr[COL_IMAGEINFODATA_TITLE]     = imageInfoWork.ImageInfoData;                                          // �摜���f�[�^
            dr[COL_GUID_TITLE]              = imageInfoWork.FileHeaderGuid;                                         // GUID

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._imageInfoTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._imageInfoDic.ContainsKey(imageInfoWork.FileHeaderGuid) == true)
            {
                this._imageInfoDic.Remove(imageInfoWork.FileHeaderGuid);
            }
            this._imageInfoDic.Add(imageInfoWork.FileHeaderGuid, imageInfoWork);
        }
        
		#endregion

		// --------------------------------------------------
		#region ��r�p�N���X

        /// <summary>
        ///�摜���}�X�^��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �摜���}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public class ImageInfoCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>
            /// ��r�p���\�b�h
            /// </summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : �摜���}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 22022 �i�� �m�q</br>
            /// <br>Date       : 2007.05.16</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                ImageInfo obj1 = x as ImageInfo;
                ImageInfo obj2 = y as ImageInfo;

                // �摜���敪�Ŕ�r
                if (obj1.ImageInfoDiv.CompareTo(obj2.ImageInfoDiv) == 0)
                {
                    // �摜���R�[�h�Ŕ�r
                    return obj1.ImageInfoCode.CompareTo(obj2.ImageInfoCode);
                }
                else
                {
                    // �摜���R�[�h�Ŕ�r
                    return obj1.ImageInfoCode.CompareTo(obj2.ImageInfoCode);
                }
            }

            #endregion
        }

		#endregion

	}
}

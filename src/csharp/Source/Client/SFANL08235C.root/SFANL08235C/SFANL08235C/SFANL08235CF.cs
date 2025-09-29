using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���R���[���ʓ������摜����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�Ŏg�p���铧�����摜�֘A�̐�����s�����ʕ��i�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.11.21</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class SFANL08235CF
	{
		#region Const
		// �V�X�e���敪�R�[�h
		private const int ctSystemDivCd			= 0;
		// �摜�g�p�V�X�e���R�[�h
		private const int ctImageUseSystemCode	= 100;
		#endregion

		#region PrivateMember
        //// �摜�A�N�Z�X�N���X
        //ImageImgAcs				_imageImgAcs;
        //// �摜�_�E�����[�h��
        //private bool			_isImageAccess;
		// �摜�Ǘ��f�[�^LIST
		private ImgManage		_imgManage;
        //// �摜�O���[�v�f�[�^�N���X
        //private ImageGroup		_imageGroup;
        //// �G���[���b�Z�[�W
        //private string			_errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08235CF()
		{
            //_imageImgAcs = new ImageImgAcs();
            //// �摜�t�@�C����M�����C�x���g�̐ݒ�
            //_imageImgAcs.FileReceived += new EventHandler( ImageImgAcs_FileReceived );
            //// �摜�t�@�C�����M�����C�x���g�̐ݒ�
            //_imageImgAcs.FileSended += new EventHandler( ImageImgAcs_FileSended );
		}
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public string ErrorMessage
		{
            //get { return _errorStr; }
            get { return string.Empty; }
		}

        ///// <summary>
        ///// �摜�O���[�v�}�X�^
        ///// </summary>
        ///// <remarks>�ǂݎ���p</remarks>
        //public ImageGroup ImageGroup
        //{
        //    get
        //    {
        //        // �_�E�����[�h���I���܂Ń��[�v
        //        while (_isImageAccess)
        //        {
        //            Monitor.Enter(this);
        //            try
        //            {
        //                Thread.Sleep(100);
        //            }
        //            finally
        //            {
        //                Monitor.Exit(this);
        //            }
        //        }

        //        return _imageGroup;
        //    }
        //}

        ///// <summary>
        ///// �摜�Ǘ��}�X�^
        ///// </summary>
        ///// <remarks>�ǂݎ���p</remarks>
        //public ImgManage ImgManage
        //{
        //    get
        //    {
        //        // �_�E�����[�h���I���܂Ń��[�v
        //        while (_isImageAccess)
        //        {
        //            Monitor.Enter(this);
        //            try
        //            {
        //                Thread.Sleep(100);
        //            }
        //            finally
        //            {
        //                Monitor.Exit(this);
        //            }
        //        }

        //        return _imgManage;
        //    }
        //}

        ///// <summary>
        ///// �w�i�摜
        ///// </summary>
        //public Image BgImage
        //{
        //    get
        //    {
        //        if (ImgManage != null)
        //            return ImgManage.TakeInImage;
        //        else
        //            return null;
        //    }
        //}

		#endregion

		#region PublicMethod
        ///// <summary>
        ///// �������摜�擾����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note		: �w�肳�ꂽ�摜���摜�T�[�o�[���擾���܂��B</br>
        ///// <br>Programmer	: 22024 ����@�_�u</br>
        ///// <br>Date		: 2007.11.21</br>
        ///// </remarks>
        //public int GetWatermarkImage(string enterpriseCode, Guid takeInImageGroupCd)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    if (takeInImageGroupCd != Guid.Empty)
        //    {
        //        // �摜�Ǘ��f�[�^LIST
        //        _imgManage	= new ImgManage();
        //        // �摜�O���[�v�f�[�^�N���X
        //        _imageGroup	= new ImageGroup();

        //        try
        //        {
        //            // �摜�O���[�v�}�X�^���摜�Ǘ��}�X�^��������
        //            ImageGroup[] imageGroupArray;
        //            ImgManage[] imgManageArray;

        //            _isImageAccess = true;
        //            status = _imageImgAcs.Search(out imageGroupArray, out imgManageArray, enterpriseCode, takeInImageGroupCd, ctSystemDivCd, ctImageUseSystemCode, true);
        //            switch (status)
        //            {
        //                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    if ((imageGroupArray != null) && (imageGroupArray.Length > 0))
        //                        _imageGroup = imageGroupArray[0];

        //                    if ((imgManageArray != null) && (imgManageArray.Length > 0))
        //                        _imgManage	= imgManageArray[0];
        //                    break;
        //                }
        //                default:
        //                {
        //                    _isImageAccess = false;
        //                    break;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _isImageAccess = false;
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            _errorStr = "�������摜�擾�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// �������摜�폜����
        ///// </summary>
        ///// <param name="imageGroup">�摜�O���[�v�}�X�^</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note		: �������摜���폜���܂��B</br>
        ///// <br>Programmer	: 22024 ����@�_�u</br>
        ///// <br>Date		: 2007.11.21</br>
        ///// </remarks>
        //public int DeleteWatermark(ImageGroup imageGroup)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    try
        //    {
        //        status = _imageImgAcs.Delete(imageGroup);
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        _errorStr = "�������摜�폜�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// �������摜�o�^����
        ///// </summary>
        ///// <param name="imageGroup">�摜�O���[�v�}�X�^</param>
        ///// <param name="imgManage">�摜�Ǘ��}�X�^</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note		: �������摜��o�^���܂��B</br>
        ///// <br>Programmer	: 22024 ����@�_�u</br>
        ///// <br>Date		: 2007.11.21</br>
        ///// </remarks>
        //public int WriteWatermarkImage(ref ImageGroup imageGroup, ref ImgManage imgManage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    try
        //    {
        //        if (imageGroup != null && imgManage != null)
        //        {
        //            ImageGroup[] imageGroupArray	= new ImageGroup[] { imageGroup };
        //            ImgManage[] imgManageArray		= new ImgManage[] { imgManage };

        //            status = _imageImgAcs.Write(ref imageGroupArray, ref imgManageArray, imageGroup.EnterpriseCode, true);
        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                // �񓯊���������������܂�Wait����
        //                while (_isImageAccess) Thread.Sleep(100);

        //                imageGroup	= imageGroupArray[0];
        //                imgManage	= imgManageArray[0];
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _isImageAccess = false;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        _errorStr = "�������摜�o�^�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// �V�K�摜�f�[�^�Z�b�g����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="image">�摜�f�[�^</param>
        ///// <param name="imageGroup">�摜�O���[�v�}�X�^</param>
        ///// <param name="imgManage">�摜�Ǘ��}�X�^</param>
        ///// <remarks>
        ///// <br>Note		: �V�K�ɉ摜�Ǘ��}�X�^���쐬���܂��B</br>
        ///// <br>Programmer	: 22024 ����@�_�u</br>
        ///// <br>Date		: 2007.11.21</br>
        ///// </remarks>
        //public void CreateNewWatermarkImgManage(string enterpriseCode, Image image, out ImageGroup imageGroup, out ImgManage imgManage)
        //{
        //    imageGroup	= new ImageGroup();
        //    imgManage	= new ImgManage();

        //    Guid takeInImageGroupCd	= Guid.NewGuid();
        //    Guid takeInImageCode	= Guid.NewGuid();

        //    imageGroup.EnterpriseCode		= enterpriseCode;
        //    imageGroup.TakeInImageGroupCd	= takeInImageGroupCd;
        //    imageGroup.TakeInImageCode		= takeInImageCode;
        //    imageGroup.SystemDivCd			= ctSystemDivCd;
        //    imageGroup.ImageUseSystemCode	= ctImageUseSystemCode;

        //    imgManage.EnterpriseCode		= enterpriseCode;
        //    imgManage.TakeInImageCode		= takeInImageCode;
        //    imgManage.TakeInImageDispName	= "���R���[�������摜";
        //    imgManage.TakeInImageFileType	= ImageImgAcs.ImageFormatToString(ImageFormat.Png);
        //    imgManage.TakeInImageColorCnt	= ImageImgAcs.PixelFormatToInt32(image.PixelFormat);
        //    imgManage.TakeInImageWidth		= image.Width;
        //    imgManage.TakeInImageHeight		= image.Height;
        //    imgManage.TakeInImageFileSize	= ImageImgAcs.ImageToBinary(image, ImageFormat.Png).Length;
        //    imgManage.TakeInImageFileUrl	= imgManage.TakeInImageCode.ToString() + "." + imgManage.TakeInImageFileType;
        //    imgManage.TakeInImageDispOrder	= 1;
        //    imgManage.TakeInImage			= image;
        //    imgManage.TakeInImageDateTime	= DateTime.Now;

        //    imgManage.ThmnailImageFileType	= string.Empty;
        //    imgManage.ThmnailImageColorCnt	= 0;
        //    imgManage.ThmnailImageWidth		= 0;
        //    imgManage.ThmnailImageHeight	= 0;
        //    imgManage.ThmnailImageFileSize	= 0;
        //    imgManage.ThmnailImage			= null;
        //    imgManage.ThmnailImageFileUrl	= string.Empty;
        //    imgManage.FreeMemoCmpDtSavePlc	= string.Empty;
        //    imgManage.FreeMemoData			= null;
        //}
		#endregion

		#region Event
		/// <summary>
		/// �摜��M��������
		/// </summary>
		/// <param name="sender">�摜�Ǘ��}�X�^�z��(ImgManage[])</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note		: �摜�̎�M�����������^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void ImageImgAcs_FileReceived(object sender, EventArgs e)
		{
			Monitor.Enter(this);
			try
			{
				ImgManage[] imgManageArray = sender as ImgManage[];

				if ((imgManageArray == null) || (imgManageArray.Length == 0))
				{
					return;
				}

				// �摜�Ǘ��}�X�^�����擾����i�P���R�[�h�̂݁j
				_imgManage = imgManageArray[0];
			}
			finally
			{
				Monitor.Exit(this);
                //// �摜���������Ή�
                //_isImageAccess = false;
			}
		}

		/// <summary>
		/// ImageImgAcs_FileSended�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �摜�T�[�o�[�Ƀt�@�C���̑��M�����������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void ImageImgAcs_FileSended(object sender, EventArgs e)
		{
            //_isImageAccess = false;
		}
		#endregion
	}
}

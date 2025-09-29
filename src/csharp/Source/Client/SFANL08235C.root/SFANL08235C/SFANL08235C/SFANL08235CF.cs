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
	/// 自由帳票共通透かし画像制御クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票で使用する透かし画像関連の制御を行う共通部品です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.11.21</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class SFANL08235CF
	{
		#region Const
		// システム区分コード
		private const int ctSystemDivCd			= 0;
		// 画像使用システムコード
		private const int ctImageUseSystemCode	= 100;
		#endregion

		#region PrivateMember
        //// 画像アクセスクラス
        //ImageImgAcs				_imageImgAcs;
        //// 画像ダウンロード中
        //private bool			_isImageAccess;
		// 画像管理データLIST
		private ImgManage		_imgManage;
        //// 画像グループデータクラス
        //private ImageGroup		_imageGroup;
        //// エラーメッセージ
        //private string			_errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08235CF()
		{
            //_imageImgAcs = new ImageImgAcs();
            //// 画像ファイル受信完了イベントの設定
            //_imageImgAcs.FileReceived += new EventHandler( ImageImgAcs_FileReceived );
            //// 画像ファイル送信完了イベントの設定
            //_imageImgAcs.FileSended += new EventHandler( ImageImgAcs_FileSended );
		}
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
            //get { return _errorStr; }
            get { return string.Empty; }
		}

        ///// <summary>
        ///// 画像グループマスタ
        ///// </summary>
        ///// <remarks>読み取り専用</remarks>
        //public ImageGroup ImageGroup
        //{
        //    get
        //    {
        //        // ダウンロードが終わるまでループ
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
        ///// 画像管理マスタ
        ///// </summary>
        ///// <remarks>読み取り専用</remarks>
        //public ImgManage ImgManage
        //{
        //    get
        //    {
        //        // ダウンロードが終わるまでループ
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
        ///// 背景画像
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
        ///// 透かし画像取得処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="takeInImageGroupCd">取込画像グループコード</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note		: 指定された画像を画像サーバーより取得します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
        ///// <br>Date		: 2007.11.21</br>
        ///// </remarks>
        //public int GetWatermarkImage(string enterpriseCode, Guid takeInImageGroupCd)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    if (takeInImageGroupCd != Guid.Empty)
        //    {
        //        // 画像管理データLIST
        //        _imgManage	= new ImgManage();
        //        // 画像グループデータクラス
        //        _imageGroup	= new ImageGroup();

        //        try
        //        {
        //            // 画像グループマスタ＆画像管理マスタ検索処理
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
        //            _errorStr = "透かし画像取得処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 透かし画像削除処理
        ///// </summary>
        ///// <param name="imageGroup">画像グループマスタ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note		: 透かし画像を削除します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
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
        //        _errorStr = "透かし画像削除処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 透かし画像登録処理
        ///// </summary>
        ///// <param name="imageGroup">画像グループマスタ</param>
        ///// <param name="imgManage">画像管理マスタ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note		: 透かし画像を登録します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
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
        //                // 非同期処理が完了するまでWait処理
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
        //        _errorStr = "透かし画像登録処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 新規画像データセット処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="image">画像データ</param>
        ///// <param name="imageGroup">画像グループマスタ</param>
        ///// <param name="imgManage">画像管理マスタ</param>
        ///// <remarks>
        ///// <br>Note		: 新規に画像管理マスタを作成します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
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
        //    imgManage.TakeInImageDispName	= "自由帳票透かし画像";
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
		/// 画像受信完了処理
		/// </summary>
		/// <param name="sender">画像管理マスタ配列(ImgManage[])</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note		: 画像の受信が完了したタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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

				// 画像管理マスタ情報を取得する（１レコードのみ）
				_imgManage = imgManageArray[0];
			}
			finally
			{
				Monitor.Exit(this);
                //// 画像強制同期対応
                //_isImageAccess = false;
			}
		}

		/// <summary>
		/// ImageImgAcs_FileSendedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 画像サーバーにファイルの送信完了した時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void ImageImgAcs_FileSended(object sender, EventArgs e)
		{
            //_isImageAccess = false;
		}
		#endregion
	}
}

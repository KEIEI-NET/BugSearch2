
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車種名称マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種名称マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.12</br>
    /// <br></br>
    /// <br>Update Note : 2009/12/08 張凱 保守依頼③対応</br>
    /// <br>             車種選択ガイドでメーカーのみの指定を可能にする</br>
    /// <br></br>
    /// <br>Update Note : 2010/06/29 30517 夏野 駿希</br>
    /// <br>             Mantis.15676　カーメーカーのみ選択時、メイン画面にメーカーコードが表示されない不具合の修正</br>
    /// </remarks>
    public class ModelNameUAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // 車種名称マスタ（ユーザー）
        private IModelNameUDB _iModelNameUDB = null;
        // 車種名称マスタ（提供）
        private IModelNameDB _iModelNameDB = null;
        
        #endregion

        #region Constructor

        /// <summary>
        /// 車種名称マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 車種名称マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public ModelNameUAcs()
		{

            // メーカーOPの判定
            //this._optMaker = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

			try
			{
				// リモートオブジェクト取得
                this._iModelNameUDB = (IModelNameUDB)MediationModelNameUDB.GetModelNameUDB();
                this._iModelNameDB = (IModelNameDB)MediationModelNameDB.GetModelNameDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iModelNameUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 車種名称読み込み処理
        /// </summary>
        /// <param name="modelNameU">車種名称オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード）</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 車種名称情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Read(out ModelNameU modelNameU, string enterpriseCode, Int32 makerCode, Int32 modelCode, Int32 modelSubCode)
        {
            try
            {
                // キー情報の設定
                modelNameU = null;
                ModelNameUWork modelNameUWork = new ModelNameUWork();
                modelNameUWork.EnterpriseCode = enterpriseCode;
                modelNameUWork.MakerCode = makerCode;
                modelNameUWork.ModelCode = modelCode;
                modelNameUWork.ModelSubCode = modelSubCode;
                
                // 車種名称ワーカークラスをオブジェクトに設定
                object paraObj = (object)modelNameUWork;

                //車種名称読み込み
                int status = this._iModelNameUDB.Read(ref paraObj, 0);
                
                if (status == 0)
                {
                    // 読み込み結果を車種名称ワーカークラスに設定
                    ModelNameUWork wkModelNameUWork = (ModelNameUWork)paraObj;
                    // 車種名称ワーカークラスから車種名称クラスにコピー
                    modelNameU = CopyToModelNameUFromModelNameUWork(wkModelNameUWork);
                }
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //通信エラーは-1を戻す
                modelNameU = null;
                return -1;
            }
        }

        /// <summary>
        /// 車種名称シリアライズ処理
        /// </summary>
        /// <param name="modelNameU">シリアライズ対象車種名称クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 車種名称のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void Serialize(ModelNameU modelNameU, string fileName)
        {
            // 車種名称クラスから車種名称ワーカークラスにメンバコピー
            ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

            // 車種名称ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(modelNameUWork, fileName);
        }

        /// <summary>
        /// 車種名称Listシリアライズ処理
        /// </summary>
        /// <param name="arrModelNameU">シリアライズ対象車種名称Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 車種名称List情報のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrModelNameU, string fileName)
        {
            ModelNameUWork[] modelNameUWorks = new ModelNameUWork[arrModelNameU.Count];

            for (int i = 0; i < arrModelNameU.Count; i++)
            {
                modelNameUWorks[i] = CopyToModelNameUWorkFromModelNameU((ModelNameU)arrModelNameU[i]);
            }

            // 車種名称ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(modelNameUWorks, fileName);
        }

        /// <summary>
        /// 車種名称クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>車種名称クラス</returns>
        /// <remarks>
        /// <br>Note       : 車種名称クラスをデシリアライズします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public ModelNameU Deserialize(string fileName)
        {
            ModelNameU modelNameU = null;

            // ファイル名を渡して車種名称ワーククラスをデシリアライズする
            ModelNameUWork modelNameUWork = (ModelNameUWork)XmlByteSerializer.Deserialize(fileName, typeof(ModelNameUWork));

            // デシリアライズ結果を車種名称クラスへコピー
            if (modelNameUWork != null) modelNameU = CopyToModelNameUFromModelNameUWork(modelNameUWork);

            return modelNameU;
        }

        /// <summary>
        /// 車種名称登録・更新処理
        /// </summary>
        /// <param name="modelNameU">車種名称クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車種名称の登録・更新を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Write(ref ModelNameU modelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            // 車種名称クラスから車種名称ワーククラスにメンバコピー
            modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);
            
            // 車種名称の登録・更新情報を設定
            ArrayList paraList = new ArrayList();
            paraList.Add(modelNameUWork);
            object paraObj = paraList;

            int status = 0;
            try
            {
                // 車種名称書き込み
                status = this._iModelNameUDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // 車種名称クラスから車種名称ワーククラスにメンバコピー
                    modelNameU = this.CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);                    
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 車種名称論理削除処理
        /// </summary>
        /// <param name="modelNameU">車種名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 車種名称情報の論理削除を行います。<br />
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int LogicalDelete(ref ModelNameU modelNameU)
        {
            int status = 0;

            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraObj = paraList;

                // 車種名称クラス論理削除
                status = this._iModelNameUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // クラス内メンバコピー
                    modelNameU = CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 車種名称物理削除処理
        /// </summary>
        /// <param name="modelNameU">車種名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 車種名称情報の物理削除を行います。<br />
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int Delete(ModelNameU modelNameU)
        {
            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraObj = paraList;

                // 車種名称物理削除
                int status = this._iModelNameUDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 車種名称論理削除復活処理
        /// </summary>
        /// <param name="modelNameU">車種名称名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 車種名称情報の復活を行います。<br />
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int Revival(ref ModelNameU modelNameU)
        {
            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);
                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraobj = paraList;

                // 復活処理
                int status = this._iModelNameUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // クラス内メンバコピー
                    modelNameU = CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 車種名称マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="belongMakerCode">メーカーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.12</br>
        /// </remarks>
        public int Search(ref DataSet ds, int belongMakerCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // 車種名称マスタサーチ
            status = SearchAll(belongMakerCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();


            foreach (ModelNameU wkModelNameU in wkList)
            {
                if (wkModelNameU.LogicalDeleteCode == 0)
                {
                    if (belongMakerCode == 0)
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());
                    }
                    else if (belongMakerCode.Equals(wkModelNameU.MakerCode))
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);  // iitani a 2007.05.29


            //// --- [全て] --- //
            //// そのまま全件返す
            //foreach (ModelNameU wkModelNameU in wkList)
            //{
            //    if (wkModelNameU.LogicalDeleteCode == 0)
            //    {
            //        wkSort.Add(wkModelNameU.ModelUniqueCode, wkModelNameU);
            //    }
            //}

            ModelNameU[] modelNameUs = new ModelNameU[ar.Count];

            // データを元に戻す
            for (int i = 0; i < ar.Count; i++)
            {
                //modelNameUs[i] = (ModelNameU)wkSort.GetByIndex(i);
                modelNameUs[i] = (ModelNameU)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(modelNameUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// 車種名称マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="belongMakerCode">メーカーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: 取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.12.08</br>
        /// </remarks>
        public int Search2(ref DataSet ds, int belongMakerCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // 車種名称マスタサーチ
            status = SearchAll(belongMakerCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();

            if (wkList.Count > 0)
            {
                ModelNameU modelNameU = new ModelNameU();
                ModelNameU modelNameUnew = (ModelNameU)wkList[0];
                modelNameU.ModelUniqueCode = modelNameUnew.MakerCode * 1000000;
                modelNameU.MakerCode = modelNameUnew.MakerCode;
                wkSort.Add(modelNameU.ModelUniqueCode, modelNameU.Clone());
            }

            foreach (ModelNameU wkModelNameU in wkList)
            {
                if (wkModelNameU.LogicalDeleteCode == 0)
                {
                    if (belongMakerCode == 0)
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());
                    }
                    else if (belongMakerCode.Equals(wkModelNameU.MakerCode))
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);

            ModelNameU[] modelNameUs = new ModelNameU[ar.Count];

            // データを元に戻す
            for (int i = 0; i < ar.Count; i++)
            {
                modelNameUs[i] = (ModelNameU)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(modelNameUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// メーカーコード指定 車種名称検索処理（論理削除含む）
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車種名称の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int SearchAll(Int32 makerCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ユーザー
            status = SearchModelNameUProc(makerCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:

                    return status;
            }

            // 提供
            //status = SearchModelNameOfrProc(makerCode, ref list, out retTotalCnt, out nextData,enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            // 検索結果件数が0件以外であればステータスを0(正常)に設定
            if (retTotalCnt != 0)
            {
                status = 0;
            }
            
            retList = list;
            
            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（車種名称ワーククラス⇒車種名称クラス）
        /// </summary>
        /// <param name="modelNameUWork">車種名称ワーククラス</param>
        /// <returns>車種名称クラス</returns>
        /// <remarks>
        /// <br>Note       : 車種名称ワーククラスから車種名称クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private ModelNameU CopyToModelNameUFromModelNameUWork(ModelNameUWork modelNameUWork)
        {
            ModelNameU modelNameU = new ModelNameU();

            modelNameU.CreateDateTime = modelNameUWork.CreateDateTime;
            modelNameU.UpdateDateTime = modelNameUWork.UpdateDateTime;
            modelNameU.EnterpriseCode = modelNameUWork.EnterpriseCode;
            modelNameU.FileHeaderGuid = modelNameUWork.FileHeaderGuid;
            modelNameU.UpdEmployeeCode = modelNameUWork.UpdEmployeeCode;
            modelNameU.UpdAssemblyId1 = modelNameUWork.UpdAssemblyId1;
            modelNameU.UpdAssemblyId2 = modelNameUWork.UpdAssemblyId2;
            modelNameU.LogicalDeleteCode = modelNameUWork.LogicalDeleteCode;

            modelNameU.ModelUniqueCode = modelNameUWork.ModelUniqueCode;        // 車種コード（ユニーク）
            modelNameU.MakerCode = modelNameUWork.MakerCode;                    // メーカーコード
            modelNameU.ModelCode = modelNameUWork.ModelCode;                    // 車種コード
            modelNameU.ModelSubCode = modelNameUWork.ModelSubCode;              // 呼称コード
            modelNameU.ModelFullName = modelNameUWork.ModelFullName;            // 車種名称
            modelNameU.ModelHalfName = modelNameUWork.ModelHalfName;            // 車種名称（カナ）
            modelNameU.ModelAliasName = modelNameUWork.ModelAliasName;          // 呼称
            modelNameU.OfferDate = modelNameUWork.OfferDate;                    // 提供日付
            modelNameU.OfferDataDiv = modelNameUWork.OfferDataDiv;              // 提供データ区分
            if (modelNameU.OfferDate == DateTime.MinValue)
            {
                modelNameU.Division = 0;
                modelNameU.DivisionName = "ユーザー";
            }
            else
            {
                modelNameU.Division = 1;
                modelNameU.DivisionName = "提供";
            }
            return modelNameU;
        }

        /// <summary>
        /// クラスメンバーコピー処理（車種名称クラス⇒車種名称ワーククラス）
        /// </summary>
        /// <param name="modelNameU">車種名称ワーククラス</param>
        /// <returns>車種名称クラス</returns>
        /// <remarks>
        /// <br>Note       : 車種名称クラスから車種名称ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private ModelNameUWork CopyToModelNameUWorkFromModelNameU(ModelNameU modelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            modelNameUWork.CreateDateTime = modelNameU.CreateDateTime;
            modelNameUWork.UpdateDateTime = modelNameU.UpdateDateTime;
            modelNameUWork.EnterpriseCode = modelNameU.EnterpriseCode;
            modelNameUWork.FileHeaderGuid = modelNameU.FileHeaderGuid;
            modelNameUWork.UpdEmployeeCode = modelNameU.UpdEmployeeCode;
            modelNameUWork.UpdAssemblyId1 = modelNameU.UpdAssemblyId1;
            modelNameUWork.UpdAssemblyId2 = modelNameU.UpdAssemblyId2;
            modelNameUWork.LogicalDeleteCode = modelNameU.LogicalDeleteCode;

            modelNameUWork.ModelUniqueCode = modelNameU.ModelUniqueCode;        // 車種コード（ユニーク）
            modelNameUWork.MakerCode = modelNameU.MakerCode;                    // メーカーコード
            modelNameUWork.ModelCode = modelNameU.ModelCode;                    // 車種コード
            modelNameUWork.ModelSubCode = modelNameU.ModelSubCode;              // 呼称コード
            modelNameUWork.ModelFullName = modelNameU.ModelFullName;            // 車種名称
            modelNameUWork.ModelHalfName = modelNameU.ModelHalfName;            // 車種名称（カナ）
            modelNameUWork.ModelAliasName = modelNameU.ModelAliasName;          // 呼称
            modelNameUWork.OfferDate = modelNameU.OfferDate;                    // 提供日付
            modelNameUWork.OfferDataDiv = modelNameU.OfferDataDiv;              // 提供データ区

            return modelNameUWork;
        }

        ///// <summary>
        ///// クラスメンバーコピー処理（車種名称（提供）ワーククラス⇒車種名称クラス）
        ///// </summary>
        ///// <param name="modelNameWork">車種名称（提供）ワーククラス</param>
        ///// <returns>車種名称クラス</returns>
        ///// <remarks>
        ///// <br>Note       : 車種名称（提供）ワーククラスから車種名称クラスへメンバーのコピーを行います。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private ModelNameU CopyToModelNameUFromModelNameWork(ModelNameWork modelNameWork)
        //{
        //    ModelNameU modelNameU = new ModelNameU();

        //    modelNameU.ModelUniqueCode = modelNameWork.ModelUniqueCode;         // 車種コード（ユニーク）
        //    modelNameU.MakerCode = modelNameWork.MakerCode;                     // メーカーコード
        //    modelNameU.ModelCode = modelNameWork.ModelCode;                     // 車種コード
        //    modelNameU.ModelSubCode = modelNameWork.ModelSubCode;               // 呼称コード
        //    modelNameU.ModelFullName = modelNameWork.ModelFullName;             // 車種名称
        //    modelNameU.ModelHalfName = modelNameWork.ModelHalfName;             // 車種名称（カナ）
        //    modelNameU.ModelAliasName = modelNameWork.ModelAliasName;           // 呼称
        //    modelNameU.Division = 1;
        //    modelNameU.DivisionName = "提供";

        //    return modelNameU;
        //}

        ///// <summary>
        ///// クラスメンバーコピー処理（車種名称クラス⇒車種名称（提供）ワーククラス）
        ///// </summary>
        ///// <param name="modelNameU">車種名称ワーククラス</param>
        ///// <returns>車種名称（提供）クラス</returns>
        ///// <remarks>
        ///// <br>Note       : 車種名称クラスから車種名称（提供）ワーククラスへメンバーのコピーを行います。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private ModelNameWork CopyToModelNameWorkFromModelNameU(ModelNameU modelNameU)
        //{
        //    ModelNameWork modelNameWork = new ModelNameWork();

        //    modelNameWork.ModelUniqueCode = modelNameU.ModelUniqueCode;         // 車種コード（ユニーク）
        //    modelNameWork.MakerCode = modelNameU.MakerCode;                     // メーカーコード
        //    modelNameWork.ModelCode = modelNameU.ModelCode;                     // 車種コード
        //    modelNameWork.ModelSubCode = modelNameU.ModelSubCode;               // 呼称コード
        //    modelNameWork.ModelFullName = modelNameU.ModelFullName;             // 車種名称
        //    modelNameWork.ModelHalfName = modelNameU.ModelHalfName;             // 車種名称（カナ）
        //    modelNameWork.ModelAliasName = modelNameU.ModelAliasName;           // 呼称

        //    return modelNameWork;
        //}

        /// <summary>
        /// 車種名称検索処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevModelNameU">前回最終車種名称データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車種名称の検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private int SearchModelNameUProc(Int32 makerCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNameU prevModelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;
            
            if (retList.Count == 0)
            {
                // セキュリティレベルキー指定
                modelNameUWork.MakerCode = makerCode;
                modelNameUWork.EnterpriseCode = enterpriseCode;

                // 車種名称ワーカークラスをオブジェクトに設定
                object paraObj = (object)modelNameUWork;

                // メーカーコード指定全件読込
                status = this._iModelNameUDB.Search(ref retObj, paraObj, 0, logicalMode);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (ModelNameUWork wkModelNameUWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                ModelNameU wkModelNameU = CopyToModelNameUFromModelNameUWork(wkModelNameUWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkModelNameU);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        ///// <summary>
        ///// 車種名称マスタ（提供）検索処理
        ///// </summary>
        ///// <param name="makerCode">メーカーコード</param>
        ///// <param name="retList">読込結果コレクション</param>
        ///// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        ///// <param name="nextData">次データ有無</param>
        ///// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        ///// <param name="readCnt">読込件数</param>
        ///// <param name="prevModelNameU">前回最終車種名称マスタ（提供）データオブジェクト（初回はnull指定必須）</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 車種名称マスタ（提供）の検索処理を行います。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private int SearchModelNameOfrProc(Int32 makerCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode,  ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNameU prevModelNameU)
        //{
        //    ModelNameWork modelNameWork = new ModelNameWork();

        //    // 次データ有無初期化
        //    nextData = false;
        //    // 読込対象データ総件数0で初期化
        //    retTotalCnt = 0;

        //    int status = 0;

        //    ArrayList workList = new ArrayList();
        //    object retObj = workList;
        //    SortedList sortWk = new SortedList();

        //    // セキュリティレベルキー指定
        //    modelNameWork.MakerCode = makerCode;

        //    // 車種名称（提供）ワーカークラスをオブジェクトに設定
        //    object paraObj = (object)modelNameWork;

        //    // メーカーコード指定全件読込
        //    status = this._iModelNameDB.Search(ref retObj, paraObj);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            workList = retObj as ArrayList;
        //            if (workList != null)
        //            {
        //                foreach (ModelNameWork wkModelNameWork in workList)
        //                {
        //                    // リモートパラメータデータ ⇒ データクラス
        //                    ModelNameU wkModelNameU = CopyToModelNameUFromModelNameWork(wkModelNameWork);
        //                    // データクラスを読込結果へコピー
        //                    retList.Add(wkModelNameU);
        //                }
        //            }
        //            break;
        //        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            break;
        //        default:
        //            return status;
        //    }

        //    // 全件リードの場合は戻り値の件数をセット
        //    if (readCnt == 0) retTotalCnt = retList.Count;

        //    return status;
        //}
        #endregion

        #region Guid Methods

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.12</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            int makerCode = 0;

            //企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode") )
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            //企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }
            //メーカーコード
            if (inParm.ContainsKey("GoodsMakerCd"))
            {
                makerCode = Int32.Parse((inParm["GoodsMakerCd"] as string));
            }
            else if (inParm.ContainsKey("MakerCode"))
            {
                makerCode = Int32.Parse((inParm["MakerCode"].ToString()));
            }                        
            // 車種名称マスタテーブル読込み
            // -------UPD 2009/12/08------->>>>>
            //status = Search(ref guideList, makerCode, enterpriseCode);
            status = Search2(ref guideList, makerCode, enterpriseCode);
            // -------UPD 2009/12/08------->>>>>
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }
            return status;
        }

        /// <summary>
        /// 車種名称マスタガイド起動処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maker">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 車種名称マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.13</br>
        /// </remarks>
        public int ExecuteGuid(Int32 makerCode, string enterpriseCode, out ModelNameU modelNameU)
        {
            int status = -1;
            modelNameU = new ModelNameU();

            string xmlName = "";
            if (makerCode == 0)
            {
                xmlName = "MODELNAMEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "MODELNAMEGUIDEPARENT.XML";
            }

            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();


            // メーカーコード
            inObj.Add("MakerCode",makerCode);
            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            // 部品メーカー抽出フラグ
            inObj.Add("MakerCdExtraFlg", 1);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = string.Empty;
                // メーカーコード
                if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                {
                    strCode = retObj["GoodsMakerCd"].ToString();
                }
                else
                {
                    strCode = retObj["MakerCode"].ToString();
                }

                modelNameU.MakerCode = int.Parse(strCode);

                // 車種コード
                strCode = retObj["ModelCode"].ToString();
                modelNameU.ModelCode = int.Parse(strCode);

                // 呼称コード
                strCode = retObj["ModelSubCode"].ToString();
                modelNameU.ModelSubCode = int.Parse(strCode);

                // 車種名称
                modelNameU.ModelFullName = retObj["ModelFullName"].ToString();
                // 車種名称（カナ）
                modelNameU.ModelHalfName = retObj["ModelHalfName"].ToString();
                // 呼称
                modelNameU.ModelAliasName = retObj["ModelAliasName"].ToString();
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// 車種名称マスタガイド起動処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">呼称コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maker">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 車種名称マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.12.08</br>
        /// </remarks>
        public int ExecuteGuid2(Int32 makerCode, Int32 modelCode,Int32 modelSubCode,string enterpriseCode, out ModelNameU modelNameU)
        {
            int status = -1;
            modelNameU = new ModelNameU();

            string xmlName = "";
            xmlName = "MODELNAMEKTNGUIDEPARENT.XML";
            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();


            // メーカーコード
            inObj.Add("MakerCode", makerCode);
            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            // 部品メーカー抽出フラグ
            inObj.Add("MakerCdExtraFlg", 1);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = string.Empty;
                // メーカーコード
                if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                {
                    strCode = retObj["GoodsMakerCd"].ToString();
                }
                else
                {
                    strCode = retObj["MakerCode"].ToString();
                }

                modelNameU.MakerCode = int.Parse(strCode);

                // 車種コード
                strCode = retObj["ModelCode"].ToString();
                modelNameU.ModelCode = int.Parse(strCode);

                // 呼称コード
                strCode = retObj["ModelSubCode"].ToString();
                modelNameU.ModelSubCode = int.Parse(strCode);

                // 車種名称
                modelNameU.ModelFullName = retObj["ModelFullName"].ToString();
                // 車種名称（カナ）
                modelNameU.ModelHalfName = retObj["ModelHalfName"].ToString();
                // 呼称
                modelNameU.ModelAliasName = retObj["ModelAliasName"].ToString();
                status = 0;
            }
            // キャンセル
            else
            {
                // 2010/06/29 Add >>>
                if (retObj != null && retObj.Count != 0)
                {
                    string strCode = string.Empty;
                    // メーカーコード
                    if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                    {
                        strCode = retObj["GoodsMakerCd"].ToString();
                    }
                    else
                    {
                        strCode = retObj["MakerCode"].ToString();
                    }

                    if (!string.IsNullOrEmpty(strCode))
                    {
                        modelNameU.MakerCode = int.Parse(strCode);
                        status = 0;
                    }
                    else
                        status = 1;
                }
                else
                // 2010/06/29 Add <<<
                status = 1;
            }

            return status;
        }

        #endregion
    }
}

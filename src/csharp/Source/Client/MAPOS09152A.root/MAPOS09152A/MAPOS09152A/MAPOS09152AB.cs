using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>端末管理設定マスタXML保存情報クラス用アクセスクラス</summary>
    /// <remarks>
    /// <br>Note       : 端末管理設定マスタXML保存情報クラスを制御するクラスです。</br>
    /// <br>Programmer : 20031 古賀　小百合</br>
    /// <br>Date       : 2007.07.03</br>
    /// <br></br>
    /// </remarks>
    public class PosTerminalMgXMLDataAcs
    {
        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region Public Const
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private List<PosTerminalMgXMLData> _posTerminalMgXMLDataList;
        //private PosTerminalMgXMLDataAcs _posTerminalMgXMLDataAcs;
        private const string XML_FILE_NAME = "PosTerminalMg_Data.XML";
        //private bool isDeserialize = false;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>端末管理設定マスタXML保存情報クラス用アクセスクラスコンストラクタ</summary>
        public PosTerminalMgXMLDataAcs()
        {
            this._posTerminalMgXMLDataList = new List<PosTerminalMgXMLData>();
        }

        ///// <summary>端末管理設定マスタXML保存情報クラス用アクセスクラス インスタンス取得処理</summary>
        ///// <returns>端末管理設定マスタXML保存情報クラス用アクセスクラス インスタンス</returns>
        //public PosTerminalMgXMLDataAcs GetInstance()
        //{
        //    if (_posTerminalMgXMLDataAcs == null)
        //    {
        //        _posTerminalMgXMLDataAcs = new PosTerminalMgXMLDataAcs();
        //    }

        //    return _posTerminalMgXMLDataAcs;
        //}
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>キャッシュ処理</summary>
        /// <param name="posTerminalMgXMLData">端末管理設定マスタ</param>
        public void Cache(PosTerminalMgXMLData posTerminalMgXMLData)
        {
            PosTerminalMgXMLData data = new PosTerminalMgXMLData();
            data.EnterpriseCode = posTerminalMgXMLData.EnterpriseCode;
            //data.SectionCode = posTerminalMgXMLData.SectionCode;
            data.CashRegisterNo = posTerminalMgXMLData.CashRegisterNo;

            if (this._posTerminalMgXMLDataList.Count > 0)
                this._posTerminalMgXMLDataList.Clear();
            this._posTerminalMgXMLDataList.Add(data);
        }

        /// <summary>端末管理設定マスタXML保存情報クラス取得処理</summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <returns>端末管理設定マスタXML保存情報クラス</returns>
        public PosTerminalMgXMLData GetData()
        {
            PosTerminalMgXMLData posTerminalMgXMLData = null;

            foreach (PosTerminalMgXMLData data in this._posTerminalMgXMLDataList)
            {
                posTerminalMgXMLData = data.Clone();
                break;
            }

            return posTerminalMgXMLData;
        }

        /// <summary>端末管理設定マスタXML保存情報クラスシリアライズ処理</summary>
        /// <remarks>
        /// <br>端末管理設定マスタXML保存情報クラスのシリアライズを行います。</br>
        /// </remarks>
        public void Serialize()
        {
            string filepath = Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData, XML_FILE_NAME);
            UserSettingController.SerializeUserSetting(this._posTerminalMgXMLDataList, filepath);
        }

        /// <summary>端末管理設定マスタXML保存情報クラスデシリアライズ処理</summary>
        /// <remarks>
        /// <br>Note       : 端末管理設定マスタXML取得情報クラスをデシリアライズします。</br>
        /// </remarks>
        public void Deserialize()
        {
            // 既にデシリアライズが完了している場合は処理しない
            //if (isDeserialize) return;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData, XML_FILE_NAME)))
            {
                this._posTerminalMgXMLDataList = UserSettingController.DeserializeUserSetting<List<PosTerminalMgXMLData>>(Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData, XML_FILE_NAME));
                //isDeserialize = true;
            }
        }
        # endregion
    }
}

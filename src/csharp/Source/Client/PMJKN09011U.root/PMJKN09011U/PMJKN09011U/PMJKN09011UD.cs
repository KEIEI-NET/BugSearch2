using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��\����ԃN���X�R���N�V�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��\����ԃN���X�̃R���N�V�����N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2010.04.26 �я��� �V�K�쐬</br>
    /// <br>2010.05.20 ���R RedMine#8049</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {

        #region Constructor
        /// <summary>
        /// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public ColDisplayStatusList()
        {
            // �e��C���X�^���X��
            this._colDisplayStatusList = new List<ColDisplayStatusExp>();
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusKeyList = new List<string>();
            PMJKN09011UC detailTable = new PMJKN09011UC();
            // ������\����ԃ��X�g����
            List<ColDisplayStatusExp> initStatusList = new List<ColDisplayStatusExp>();

            int visiblePosition = 0;

            // �㉺�P�i
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_NO_TITLE, visiblePosition++, true, 84, 2, 0, 0, 44, 4, "", "", false, false, false));
            //-------START MODIFY 2010.05.20 GEJUN FOR Redmine 8049--------------->>>>>>>
            // ��i
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_GOODSNO_TITLE, visiblePosition++, true, 540, 2, 44, 0, 100, 2, "GoodsNo", "GoodsNo", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_MAKER_TITLE, visiblePosition++, true, 260, 2, 144, 0, 40, 2, "Maker", "Maker", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_BLCODE_TITLE, visiblePosition++, true, 200, 2, 184, 0, 50, 2, "BlCode", "BlCode", true, false, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_GOODSNM_TITLE, visiblePosition++, true, 520, 2, 234, 0, 100, 2, "GoodsNm", "GoodsNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_PARTSQTY_TITLE, visiblePosition++, true, 80, 2, 334, 0, 30, 2, "PartsQty", "PartsQty", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_COSTRATE_TITLE, visiblePosition++, true, 280, 2, 364, 0, 60, 2, "CostRate", "CostRate", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_CREATEYEAR_TITLE, visiblePosition++, true, 580, 2, 424, 0, 90, 2, "CreateYear", "CreateYear", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_CREATECARNO_TITLE, visiblePosition++, true, 600, 2, 514, 0, 100, 2, "CreateCarNo", "CreateCarNo", true, true, true));

            // ���i
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_MODELGRADENM_TITLE, visiblePosition++, true, 340, 2, 44, 2, 40, 2, "ModelGradeNm", "ModelGradeNm", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_BODYNAME_TITLE, visiblePosition++, true, 200, 2, 84, 2, 30, 2, "BodyName", "BodyName", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_DOORCOUNT_TITLE, visiblePosition++, true, 100, 2, 114, 2, 30, 2, "DoorCount", "DoorCount", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ENGINEMODELNM_TITLE, visiblePosition++, true, 160, 2, 144, 2, 50, 2, "EngineModelNm", "EngineModelNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE, visiblePosition++, true, 200, 2, 194, 2, 35, 2, "EngineDisplaceNm", "EngineDisplaceNm", true, false, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_EDIVNM_TITLE, visiblePosition++, true, 160, 2, 229, 2, 35, 2, "EdivNm", "EdivNm", true, true, true));
			initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_TRANSMISSIONNM_TITLE, visiblePosition++, true, 260, 2, 264, 2, 50, 2, "TransmissionNm", "TransmissionNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE, visiblePosition++, true, 240, 2, 314, 2, 50, 2, "WheelDriveMethodNm", "WheelDriveMethodNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_SHIFTNM_TITLE, visiblePosition++, true, 280, 2, 364, 2, 40, 2, "ShiftNm", "ShiftNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ADDICARSPEC_TITLE, visiblePosition++, true, 850, 2, 404, 2, 210, 2, "AddiCarSpec", "AddiCarSpec", true, true, true));
            //-------END MODIFY 2010.05.20 GEJUN FOR Redmine 8049---------------<<<<<<<<
            // ������\����ԃ��X�g�i�[����
            foreach (ColDisplayStatusExp initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatusExp colDisplayStatus = null;

                    try
                    {
                        colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
                    }
                    catch (KeyNotFoundException)
                    {
                        //
                    }

                    if (colDisplayStatus != null)
                    {
                        this._colDisplayStatusList.Add(colDisplayStatus);
                    }
                }

                // ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            //else
            //{
            //    // ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
            //    this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

            //    // ������\����ԃ��X�g�Ɨ�\����ԃN���X�i�[Dictionary�̒l���r���A�s�������[����
            //    foreach (string colKey in this._colDisplayStatusKeyList)
            //    {
            //        if (!this.ContainsKey(colKey))
            //        {
            //            // ���݂��Ȃ���Βǉ�
            //            ColDisplayStatusExp colDisplayStatus = null;

            //            try
            //            {
            //                colDisplayStatus = this._colDisplayStatusInitDictionary[colKey]; // ������\����ԃN���X�i�[Dic���擾
            //            }
            //            catch (KeyNotFoundException)
            //            {
            //                //
            //            }

            //            if (colDisplayStatus != null)
            //            {
            //                colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
            //                this.Add(colDisplayStatus);
            //            }
            //        }
            //        else
            //        {
            //            // ���݂��Ă���Ώ�����\����ԃ��X�g�̓��e�ōX�V
            //            ColDisplayStatusExp colDisplayStatusInit = null;
            //            ColDisplayStatusExp colDisplayStatus = null;
            //            try
            //            {
            //                colDisplayStatus = this._colDisplayStatusDictionary[colKey]; // ��\����ԃN���X�i�[Dic���擾
            //                colDisplayStatusInit = this._colDisplayStatusInitDictionary[colKey]; // ������\����ԃN���X�i�[Dic���擾
            //            }
            //            catch (KeyNotFoundException)
            //            {
            //                //
            //            }

            //            if (colDisplayStatus != null)
            //            {
            //                colDisplayStatus.OriginX = colDisplayStatusInit.OriginX;
            //                colDisplayStatus.OriginY = colDisplayStatusInit.OriginY;
            //                colDisplayStatus.SpanX = colDisplayStatusInit.SpanX;
            //                colDisplayStatus.SpanY = colDisplayStatusInit.SpanY;
            //                colDisplayStatus.Width = colDisplayStatusInit.Width;
            //            }

            //        }
            //    }
            //}

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }
        #endregion

        #region Private Members
        /// <summary>��\����ԃN���X���X�g</summary>
        private List<ColDisplayStatusExp> _colDisplayStatusList = null;

        /// <summary>��\����ԃN���X�i�[Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

        /// <summary>������\����ԃN���X�i�[Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

        /// <summary>��\����ԃL�[���X�g</summary>
        private List<string> _colDisplayStatusKeyList = null;

        /// <summary>���׃f�[�^�e�[�u��</summary>
        //PMJKN09011UC _detailDataTable;
        #endregion

        #region Public Methods
        /// <summary>
        /// ��\����ԃL�[�i�[���f����
        /// </summary>
        /// <param name="key">�Ώۗ�\����ԃL�[</param>
        /// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        /// <summary>
        /// ���בւ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�擾����
        /// </summary>
        /// <returns>ColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // �\���ʒu�ɂ��\�[�g����
            this.Sort();

            return this._colDisplayStatusList;
        }

        /// <summary>
        /// ������\����ԃN���X�i�[Dictionary�擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������\����ԃN���X�i�[Dictionary���擾���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public Dictionary<string, ColDisplayStatusExp> GetColDisplayInitDictionary()
        {
            return this._colDisplayStatusInitDictionary;
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�ݒ菈��
        /// </summary>
        /// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
        /// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <param name="fileName">�V���A���C�Y��t�@�C������</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatusExp> colDisplayStatusList, string fileName)
        {
            ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
        /// <returns>�f�V���A���C�Y���ꂽColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public static List<ColDisplayStatusExp> Deserialize(string fileName)
        {
            List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatusExp colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// ��\����ԃN���X�ǉ�����
        /// </summary>
        /// <param name="colDisplayStatus">�ǉ�����ColDisplayStatus�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void Add(ColDisplayStatusExp colDisplayStatus)
        {
            // ���ɓ���L�[�����݂���ꍇ�͏������Ȃ�
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X�폜����
        /// </summary>
        /// <param name="colDisplayStatus">�폜����ColDisplayStatus�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void Remove(ColDisplayStatusExp colDisplayStatus)
        {
            // ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
            if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
            {
                return;
            }

            ColDisplayStatusExp status = null;

            try
            {
                status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
            }
            catch (KeyNotFoundException)
            {
                //
            }

            if (status == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(status);
            this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g��Dictionary�i�[����
        /// </summary>
        /// <param name="colDisplayStatusList">�i�[����ColDisplayStatus�N���X�̃��X�g�̃C���X�^���X</param>
        /// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

            foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M���O��\����ԃR���N�V�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M���O��\����ԃN���X�̃R���N�V�����ł��B</br>
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// </remarks>
    internal class SAndESalSndLogListResultColDisplayStatusCollection : ColDisplayStatusCollectionBase
    {
        #region << Constructor >>

        /// <summary>
        /// ���M���O��\����ԃR���N�V�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <remarks>
        /// <br>Note       : ���M���O��\����ԃR���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public SAndESalSndLogListResultColDisplayStatusCollection(List<ColDisplayStatus> colDisplayStatusList)
            : base(colDisplayStatusList)
        {
        }

        #endregion

        #region << Protected Methods >>

        /// <summary>
        /// ��\����ԃ��X�g�����ݒ�ǉ�����
        /// </summary>
        /// <param name="initStatusList">��\����ԃ��X�g</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃ��X�g�ɏ����ݒ��ǉ����܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        protected override void SetInitColDisplayStatusList(List<ColDisplayStatus> initStatusList)
        {
            int colVisiblePos = 0;

            /// <summary>���_�R�[�h</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SECTIONCODE, colVisiblePos++, true, 0));
            /// <summary>���_����</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SECTIONNAME, colVisiblePos++, true, 105));
            /// <summary>�������M�敪�R�[�h</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SANDEAUTOSENDDIV, colVisiblePos++, true, 0));
            /// <summary>�������M�敪����</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SANDEAUTOSENDDIVNAME, colVisiblePos++, true, 122));
            /// <summary>���M�����i�J�n�j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDDATETIMESTART, colVisiblePos++, true, 175));
            /// <summary>���M�����i�I���j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDDATETIMEEND, colVisiblePos++, true, 175));
            /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDATESTART, colVisiblePos++, true, 122));
            /// <summary>���M�Ώۓ��t�i�I���j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDATEEND, colVisiblePos++, true, 122));
            /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJCUSTSTART, colVisiblePos++, true, 107));
            /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJCUSTEND, colVisiblePos++, true, 107));
            /// <summary>���M�Ώۋ敪�R�[�h</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDIV, colVisiblePos++, true, 0));
            /// <summary>���M�Ώۋ敪����</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDIVNAME, colVisiblePos++, true, 122));
            /// <summary>���M���ʃR�[�h</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDRESULTS, colVisiblePos++, true, 0));
            /// <summary>���M���ʖ���</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDRESULTSNAME, colVisiblePos++, true, 91));
            /// <summary>���M�`�[����</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipCount, colVisiblePos++, true, 91));
            /// <summary>���M�`�[���א�</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipDtlCnt, colVisiblePos++, true, 91));
            /// <summary>���M�`�[���v���z</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipTotalMny, colVisiblePos++, true, 128));
            /// <summary>���M�G���[���e</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendErrorContents, colVisiblePos++, true, 205));
        }

        #endregion
    }

    /// <summary>
    /// ��\����ԃR���N�V�������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��\����ԃN���X�̃R���N�V�����̊��N���X�ł��B</br>
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// </remarks>
    internal class ColDisplayStatusCollectionBase
    {
        #region << Constructor >>

        /// <summary>
        /// ��\����ԃR���N�V�������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃR���N�V�������N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        public ColDisplayStatusCollectionBase(List<ColDisplayStatus> colDisplayStatusList)
        {
            // �C���X�^���X������
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusKeyList = new List<string>();

            // ��\����ԃN���X���X�g�쐬
            List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

            // ��\����ԃN���X���X�g�ɒǉ�
            this.SetInitColDisplayStatusList(initStatusList);

            foreach (ColDisplayStatus initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // ��\����ԃN���X���X�g�������̏ꍇ�́A�����l��ݒ�
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string key in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatus colStatus = null;

                    try
                    {
                        colStatus = this._colDisplayStatusInitDictionary[key];
                    }
                    catch (KeyNotFoundException)
                    {
                        // 
                    }

                    if (colStatus != null)
                    {
                        this._colDisplayStatusList.Add(colStatus);
                    }
                }

                // ��\����ԃN���X�i�[Dictionary���ŐV�̏��ɂčĐ���
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            else
            {
                // ��\����ԃN���X�i�[Dictionary���ŐV�̏��ɂčĐ���
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

                // �f�t�H���g�l�ƈ����̒l���r���A�s�������[����
                foreach (string key in this._colDisplayStatusKeyList)
                {
                    if (this.ContainsKey(key) == false)
                    {
                        ColDisplayStatus colStatus = null;

                        try
                        {
                            colStatus = this._colDisplayStatusInitDictionary[key];
                        }
                        catch (KeyNotFoundException)
                        {
                            // 
                        }

                        if (colStatus != null)
                        {
                            colStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colStatus);
                        }
                    }
                }
            }

            // �\���ʒu�ɂ��\�[�g
            this.Sort();
        }

        #endregion

        #region << Constant >>

        #endregion

        #region << Private Members >>

        /// <summary>��\����ԃN���X���X�g</summary>
        private List<ColDisplayStatus> _colDisplayStatusList = null;
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;
        private List<string> _colDisplayStatusKeyList = null;

        #endregion

        #region << Protected Methods >>

        /// <summary>
        /// ��\����ԃ��X�g�����ݒ�ǉ�����
        /// </summary>
        /// <param name="initStatusList">��\����ԃ��X�g</param>
        /// <remarks>
        /// <br>Note       : ���z���\�b�h�B��\����ԃ��X�g�ɏ����ݒ��ǉ����܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        protected virtual void SetInitColDisplayStatusList(List<ColDisplayStatus> initStatusList)
        {
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// ��\����ԃN���X���X�g��\����ԃN���X�i�[Dictionary�R�s�[����
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <returns>��\����ԃN���X�i�[Dictionary</returns>
        private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            // �C���X�^���X���쐬
            Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

            // ���X�g�̓��e��o�^
            foreach (ColDisplayStatus colStatus in colDisplayStatusList)
            {
                retDictionary.Add(colStatus.Key, colStatus);
            }

            return retDictionary;
        }

        /// <summary>
        /// ��\����ԃN���X�ǉ�����
        /// </summary>
        /// <param name="colDisplayStatus">�ǉ��Ώۗ�\����ԃN���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���R���N�V�����ɒǉ����܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void Add(ColDisplayStatus colDisplayStatus)
        {
            // ���ɓ���L�[�����݂���ꍇ�͏������Ȃ�
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) == true)
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X�폜����
        /// </summary>
        /// <param name="colDisplayStatus">�폜�Ώۗ�\����ԃN���X</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�I�u�W�F�N�g�ƈ�v����I�u�W�F�N�g���R���N�V��������폜���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void Remove(ColDisplayStatus colDisplayStatus)
        {
            // ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) == false)
            {
                return;
            }

            ColDisplayStatus colStatus = this._colDisplayStatusDictionary[colDisplayStatus.Key];

            if (colStatus == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(colStatus);
            this._colDisplayStatusDictionary.Remove(colStatus.Key);

            this.Sort();
        }

        #endregion

        #region << Public Methods >>

        /// <summary>
        /// ��\����ԃN���X�R���N�V�����\�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�R���N�V�����̃\�[�g���s���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�擾����
        /// </summary>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̎擾���s���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public List<ColDisplayStatus> GetColDisplayStatusList()
        {
            return this._colDisplayStatusList;
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�ݒ菈��
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̐ݒ���s���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// �L�[���݃`�F�b�N����
        /// </summary>
        /// <param name="key">�R���N�V�������Ō��������L�[</param>
        /// <returns>�`�F�b�N����(true:���݂���, false:���݂��Ȃ�)</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�L�[���R���N�V�������ɑ��݂��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        #endregion

        #region << Public Static Methods >>

        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̃V���A���C�Y�������s���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̃f�V���A���C�Y�������s���܂��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public static List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
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
    }
}

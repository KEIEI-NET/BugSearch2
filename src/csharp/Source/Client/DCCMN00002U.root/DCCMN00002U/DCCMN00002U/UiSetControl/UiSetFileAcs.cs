using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;

using Broadleaf.Xml;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.Windows.Forms;
using System.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    # region �� DD�ɑ΂���ݒ���Ǘ�����N���X(Acs) ��
    /// <summary>
    /// �t�h���͍��ڐݒ�t�@�C���A�N�Z�X�N���X
    /// </summary>
    public class UiSetFileAcs
    {
        # region [static private fields]
        /// <summary>(static)���ʐݒ�XML�ݒ�</summary>
        static private UiSetCommon stc_UiSetCommon = null;
        /// <summary>(static)�A�Z���u���ʐݒ�XML�ݒ�f�B�N�V���i��</summary>
        static private Dictionary<string, UiSetByAssembly> stc_UiSetByAssemblyDic = null;
        # endregion

        # region [private fields]
        // ���ږ��ɑ΂���DD�̃f�B�N�V���i��
        private Dictionary<DDDicKey, string> _ddDic;
        // DD�ɑ΂���UI�ݒ�̃f�B�N�V���i��
        private Dictionary<string, UiSet> _uiSetDic;

        // �A�Z���u���ʂw�l�k�t�@�C����
        private string _uiSetFile;

        // ���ʐݒ�w�l�k�t�@�C����
        private string _uiSetFileCommon;
        # endregion

        # region [Constructor]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public UiSetFileAcs()
        {
            _ddDic = new Dictionary<DDDicKey, string>();
            _uiSetDic = new Dictionary<string, UiSet>();

            _uiSetFile = string.Empty;
            _uiSetFileCommon = GetXMLName( "Common" );
        }
        # endregion

        # region [public Methods]

        # region �� �t�h�ݒ�R���|�[�l���g�p ��
        /// <summary>
        /// �ݒ�w�l�k�t�@�C���ǂݍ��ݏ���
        /// </summary>
        /// <param name="assemblyName"></param>
        public void ReadXML( string assemblyName )
        {
            // �A�Z���u���ʐݒ�t�@�C���ǂݍ���
            ReadXMLByAssembly( assemblyName );

            // ���ʐݒ�t�@�C���ǂݍ���
            ReadXMLCommon();

            //--------------------------------------------------------
            // ������
            //   ��{����Ƃ��āA�A�Z���u���ʐݒ��D�悵�܂��B
            //   ����ReadXML�ɂ�萶�������Q�̃f�B�N�V���i����
            //   ���p����ۂɁA�ȉ��Q�_���l�����܂��B
            //   
            //   �@_ddDic�̓t�H�[���ʂŌ������āA�Ȃ����
            //     ���ʂ̐ݒ���g�p���܂��B
            //   �A_uiSetDic�͈ӎ������ɍ��ږ����L�[�ɂ��ė��p���܂��B
            //     �����ReadXML���Ő�ɃA�Z���u���ʐݒ肪����΁A
            //     ���ʐݒ肪�����Ă�Key�d���`�F�b�N�ɂ��
            //     _uiSetDic�ɒǉ�����Ă��Ȃ��ׂł��B
            //--------------------------------------------------------
        }

        /// <summary>
        /// ���ڕʐݒ���e�擾����
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public UiSet GetUiSet( string formName, string itemName )
        {
            string itemDDName = string.Empty;

            // �c�c�擾�i�t�H�[���ʁj
            DDDicKey key = new DDDicKey( formName, itemName );
            if ( _ddDic.ContainsKey( key ) )
            {
                itemDDName = _ddDic[key];
            }
            else
            {
                // �t�H�[���ʂ�������΁A���ʐݒ�
                DDDicKey cmnKey = new DDDicKey(string.Empty,itemName);
                if ( _ddDic.ContainsKey( cmnKey ) )
                {
                    itemDDName = _ddDic[cmnKey];
                }
            }

            // �i�c�c��������Ȃ��j
            if ( itemDDName == string.Empty )
            {
                return null;
            }


            // �t�h�ݒ�擾
            if ( _uiSetDic.ContainsKey( itemDDName ) )
            {
                return _uiSetDic[itemDDName];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ���ڕʐݒ���e�擾�����i�����Ή��F���X�g�j
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemNames"></param>
        /// <returns></returns>
        public List<UiSet> GetUiSetList( string formName, List<string> itemNames )
        {
            List<UiSet> uiSetList = new List<UiSet>();

            foreach ( string itemName in itemNames )
            {
                // �P���ڎ擾
                UiSet uiSet = GetUiSet( formName, itemName );
                if ( uiSet != null )
                {
                    // ���X�g�ɒǉ�
                    uiSetList.Add( uiSet );
                }
            }

            return uiSetList;
        }
        /// <summary>
        /// ���ڕʐݒ���e�擾�����i�����Ή��F�f�B�N�V���i���j
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemNames"></param>
        /// <returns></returns>
        public Dictionary<string, UiSet> GetUiSetDictionary( string formName, List<string> itemNames )
        {
            Dictionary<string, UiSet> uiSetDic = new Dictionary<string, UiSet>();

            foreach ( string itemName in itemNames )
            {
                // �P���ڎ擾
                UiSet uiSet = GetUiSet( formName, itemName );
                if ( uiSet != null )
                {
                    // ���X�g�ɒǉ�
                    uiSetDic.Add( itemName, uiSet );
                }
            }

            return uiSetDic;
        }
        # endregion �� �t�h�ݒ�R���|�[�l���g�p ��

        # region �� �ݒ�c�[���p ��
        /// <summary>
        /// �A�Z���u���ʐݒ�t�@�C���L�����菈��
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public bool ExistsUiSetByAssembly(string assemblyName)
        {
            string fileName = GetXMLName( assemblyName );
            return File.Exists( fileName );
        }
        /// <summary>
        /// ���ʐݒ�ǂݍ��ݏ����i���C�A�E�g�̂܂܎擾����j
        /// </summary>
        public UiSetCommon ReadUiSetCommon()
        {
            return this.GetUiSetCommon();
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�ǂݍ��ݏ����i���C�A�E�g�̂܂܎擾����j
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public UiSetByAssembly ReadUiSetByAssembly( string assemblyName )
        {
            return this.GetUiSetByAssembly( assemblyName );
        }
        /// <summary>
        /// ���ʐݒ�w�l�k�t�@�C����������
        /// </summary>
        /// <param name="uiSetCommon">�������ݑΏۂ̋��ʐݒ�</param>
        /// <returns></returns>
        public bool WriteXMLCommon( UiSetCommon uiSetCommon )
        {
            bool result = true;
            try
            {
                // �w��C���X�^���X���V���A���C�Y����
                XmlByteSerializer.Serialize( uiSetCommon, _uiSetFileCommon );
                // �L���b�V���X�V
                stc_UiSetCommon = uiSetCommon;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�w�l�k�t�@�C����������
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="uiSetByAssembly"></param>
        /// <returns></returns>
        public bool WriteXMLByAssembly( string assemblyName, UiSetByAssembly uiSetByAssembly )
        {
            bool result = true;
            string fileName = GetXMLName( assemblyName ); 
            try
            {
                // �w��C���X�^���X���V���A���C�Y����
                XmlByteSerializer.Serialize( uiSetByAssembly, fileName );
                // �L���b�V���X�V
                if ( stc_UiSetByAssemblyDic == null )
                {
                    stc_UiSetByAssemblyDic = new Dictionary<string, UiSetByAssembly>();
                }
                if ( stc_UiSetByAssemblyDic.ContainsKey( assemblyName ) )
                {
                    stc_UiSetByAssemblyDic[assemblyName] = uiSetByAssembly;
                }
                else
                {
                    stc_UiSetByAssemblyDic.Add( assemblyName, uiSetByAssembly );
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        # endregion �� �ݒ�c�[���p ��

        # endregion

        # region [private Methods]

        # region [�ݒ�ǂݍ���]
        /// <summary>
        /// �w�l�k�ǂݍ��ݏ���
        /// </summary>
        private void ReadXMLByAssembly( string assemblyName )
        {
            // �A�Z���u���ʐݒ�擾
            UiSetByAssembly uiSetByAssembly = GetUiSetByAssembly( assemblyName );

            // �擾�Ɏ��s���Ă�����I��
            if ( uiSetByAssembly == null )
            {
                return;
            }

            // ���ږ����c�c���@�̃f�B�N�V���i���𐶐�
            foreach ( UiSetByForm uiSetByForm in uiSetByAssembly.UISetByForms )
            {
                string formName = uiSetByForm.FormName;

                foreach ( UiSetItem uiSetItem in uiSetByForm.UISetItems )
                {
                    DDDicKey dicKey = new DDDicKey( formName, uiSetItem.ItemName );

                    if ( !_ddDic.ContainsKey( dicKey ) )
                    {
                        // �ǉ�
                        _ddDic.Add( dicKey, uiSetItem.ItemDDName );
                    }
                }
            }

            // �c�c�����t�h�ݒ�@�̃f�B�N�V���i���𐶐�
            foreach ( UiSet uiSet in uiSetByAssembly.UISetDD )
            {
                if ( !_uiSetDic.ContainsKey( uiSet.ItemDDName ) )
                {
                    // �ǉ�
                    _uiSetDic.Add( uiSet.ItemDDName, uiSet );
                }
            }
        }

        /// <summary>
        /// ���ʂw�l�k�ǂݍ��ݏ���
        /// </summary>
        private void ReadXMLCommon()
        {
            // ���ʐݒ�擾
            UiSetCommon uiSetCommon = GetUiSetCommon();

            // �擾���s���Ă�����I��
            if ( uiSetCommon == null )
            {
                return;
            }

            // ���ږ����c�c���@�̃f�B�N�V���i���𐶐�
            foreach ( UiSetItem uiSetItem in uiSetCommon.UISetItems )
            {
                DDDicKey dicKey = new DDDicKey( string.Empty, uiSetItem.ItemName );

                if ( !_ddDic.ContainsKey( dicKey ) )
                {
                    // �ǉ�
                    _ddDic.Add( dicKey, uiSetItem.ItemDDName );
                }
            }

            // �c�c�����t�h�ݒ�@�̃f�B�N�V���i���𐶐�
            foreach ( UiSet uiSet in uiSetCommon.UISetDD )
            {
                if ( !_uiSetDic.ContainsKey( uiSet.ItemDDName ) )
                {
                    // �ǉ�
                    _uiSetDic.Add( uiSet.ItemDDName, uiSet );
                }
            }
        }
        # endregion

        # region [���ʏ������i]
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <typeparam name="T">�Ώی^</typeparam>
        /// <param name="fileName">�擾���t�@�C����</param>
        /// <returns>�f�V���A���C�Y����</returns>
        private T Deserialize<T>( string fileName )
        {
            //----------------------------------------------------------------------
            // ��XmlByteSerializer.Deserialize����ReadOnly���ɓǂݍ��߂��A
            //   UserSettingController.DeserializeUserSetting�̓t�H���_�Ȃ�����
            //   �t�H���_�쐬���Ă��܂��A�ح���݂��i�[����J�����ɕs�v��UISetting�t�H���_��
            //   �쐬����Ă��܂��̂ŁA�ȉ��̂悤�Ɏ����B
            //----------------------------------------------------------------------

            T retObject;

            FileStream fs = new FileStream( fileName, FileMode.Open, FileAccess.Read );
            try
            {
                XmlSerializer xs = new XmlSerializer( typeof( T ) );
                retObject = (T)xs.Deserialize( fs );
            }
            finally
            {
                fs.Close();
            }

            return retObject;
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�t�@�C�����̎擾����
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private string GetXMLName( string assemblyName )
        {
            return string.Format( "{0}\\UISetting_{1}.xml", ConstantManagement_ClientDirectory.UISettings, assemblyName );
        }
        /// <summary>
        /// ���ʐݒ�ǂݍ��݁i�L���b�V���l���j
        /// </summary>
        /// <returns></returns>
        private UiSetCommon GetUiSetCommon()
        {
            UiSetCommon uiSetCommon = null;

            if ( stc_UiSetCommon == null )
            {
                try
                {
                    // �f�V���A���C�Y��XML����ݒ���擾
                    uiSetCommon = Deserialize<UiSetCommon>( _uiSetFileCommon );
                    // �L���b�V���ɑޔ�
                    stc_UiSetCommon = uiSetCommon;
                }
                catch
                {
                }
            }
            else
            {
                // �L���b�V������擾
                uiSetCommon = stc_UiSetCommon;
            }

            // �ԋp
            return uiSetCommon;
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�擾�����i�L���b�V���l���j
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private UiSetByAssembly GetUiSetByAssembly( string assemblyName )
        {
            UiSetByAssembly uiSetByAssembly = null;

            //------------------------------------------------
            // �L���b�V���Ƃ���f�B�N�V���i�����̂�������ΐ���
            //------------------------------------------------
            if ( stc_UiSetByAssemblyDic == null )
            {
                stc_UiSetByAssemblyDic = new Dictionary<string, UiSetByAssembly>();
            }

            //------------------------------------------------
            // �ޔ��ς݂Ȃ�΃L���b�V������擾
            //------------------------------------------------
            if ( stc_UiSetByAssemblyDic.ContainsKey( assemblyName ) )
            {
                // �L���b�V������ݒ���擾
                uiSetByAssembly = stc_UiSetByAssemblyDic[assemblyName];
            }
            else
            {
                try
                {
                    // XML����f�V���A���C�Y���Đݒ���擾
                    string fileName = GetXMLName( assemblyName );
                    uiSetByAssembly = Deserialize<UiSetByAssembly>( fileName );
                    // �L���b�V���ޔ�
                    stc_UiSetByAssemblyDic.Add( assemblyName, uiSetByAssembly );
                }
                catch
                {
                }
            }

            // �ԋp
            return uiSetByAssembly;
        }
        # endregion

        # endregion

        # region [DD Dic Key]
        /// <summary>
        /// DD�f�B�N�V���i���L�[�\����
        /// </summary>
        /// <remarks>
        /// <br>���ږ����c�c���̃f�B�N�V���i���̃L�[�p</br>
        /// </remarks>
        private struct DDDicKey
        {
            private string _formName;
            private string _itemName;

            public string FormName
            {
                get { return _formName; }
                set { _formName = value; }
            }
            public string  ItemName
            {
                get { return _itemName; }
                set { _itemName = value; }
            }
            public DDDicKey( string formName, string itemName )
            {
                _formName = formName;
                _itemName = itemName;
            }
        }
        # endregion

    }
    # endregion �� DD�ɑ΂���ݒ���Ǘ�����N���X(Acs) ��

    # region �� DD�ɑΉ�����ݒ�N���X ��
    # region [UI�ݒ�N���X�i�c�c�ʁj]
    /// <summary>
    /// UI�ݒ�N���X�i�c�c�ʁj
    /// </summary>
    [Serializable]
    public class UiSet : IComparable<UiSet>
    {
        # region [private Fields]
        /// <summary>���l</summary>
        private string _remarks;
        /// <summary>���ڂc�c��</summary>
        private string _itemDDName;
        /// <summary>����</summary>
        private int _column;
        /// <summary>�p������</summary>
        private bool _allowAlpha;
        /// <summary>�J�i����</summary>
        private bool _allowKana;
        /// <summary>��������</summary>
        private bool _allowNum;
        /// <summary>���l�L������</summary>
        private bool _allowNumSign;
        /// <summary>�L������</summary>
        private bool _allowSign;
        /// <summary>�X�y�[�X����</summary>
        private bool _allowSpace;
        /// <summary>�S�p��������</summary>
        private bool _allowWord;
        /// <summary>�����ʒu����</summary>
        private Infragistics.Win.HAlign _hAlign;
        /// <summary>�[���l�ߗL��</summary>
        private bool _padZero;
        /// <summary>�h�l�d���[�h</summary>
        private ImeMode _imeMode;
        /// <summary>�[���R�[�h���͋���</summary>
        private bool _allowZeroCode;
        # endregion

        # region [public propaty]
        /// <summary>�i�ݒ胊�}�[�N�j</summary>
        /// <remarks>���̍��ڂ�PG����ݒ�ɂ͎g�p���܂���B�ݒ�t�@�C���p�̃������ڂł��B</remarks>
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        /// <summary>���ڂc�c��</summary>
        public string ItemDDName
        {
            get { return _itemDDName; }
            set { _itemDDName = value; }
        }
        /// <summary>����</summary>
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }
        /// <summary>�p������</summary>
        public bool AllowAlpha
        {
            get { return _allowAlpha; }
            set { _allowAlpha = value; }
        }
        /// <summary>�J�i����</summary>
        public bool AllowKana
        {
            get { return _allowKana; }
            set { _allowKana = value; }
        }
        /// <summary>��������</summary>
        public bool AllowNum
        {
            get { return _allowNum; }
            set { _allowNum = value; }
        }
        /// <summary>���l�L������</summary>
        public bool AllowNumSign
        {
            get { return _allowNumSign; }
            set { _allowNumSign = value; }
        }
        /// <summary>�L������</summary>
        public bool AllowSign
        {
            get { return _allowSign; }
            set { _allowSign = value; }
        }
        /// <summary>�X�y�[�X����</summary>
        public bool AllowSpace
        {
            get { return _allowSpace; }
            set { _allowSpace = value; }
        }
        /// <summary>�S�p��������</summary>
        public bool AllowWord
        {
            get { return _allowWord; }
            set { _allowWord = value; }
        }
        /// <summary>�����ʒu����</summary>
        public Infragistics.Win.HAlign HAlign
        {
            get { return _hAlign; }
            set { _hAlign = value; }
        }
        /// <summary>�[���l�ߗL��</summary>
        public bool PadZero
        {
            get { return _padZero; }
            set { _padZero = value; }
        }
        /// <summary>�h�l�d���[�h</summary>
        public ImeMode ImeMode
        {
            get { return _imeMode; }
            set { _imeMode = value; }
        }
        /// <summary>�[���R�[�h���͋���</summary>
        public bool AllowZeroCode
        {
            get { return _allowZeroCode; }
            set { _allowZeroCode = value; }
        }
        # endregion

        # region [Constructor]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public UiSet()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="itemDDName">���ڂc�c��</param>
        /// <param name="column">����</param>
        /// <param name="allowKana">�J�i����</param>
        /// <param name="allowNum">��������</param>
        /// <param name="allowNumSign">���l�L������</param>
        /// <param name="allowSign">�L������</param>
        /// <param name="allowSpace">�X�y�[�X����</param>
        /// <param name="allowWord">�S�p��������</param>
        /// <param name="hAlign">�����ʒu����</param>
        /// <param name="padZero">�[���l�ߗL��</param>
        /// <param name="allowZeroCode">�[���R�[�h���͋���</param>
        public UiSet( string itemDDName, int column, bool allowKana, bool allowNum, bool allowNumSign, bool allowSign, bool allowSpace, bool allowWord, Infragistics.Win.HAlign hAlign, bool padZero, bool allowZeroCode )
        {
            _itemDDName = itemDDName;
            _column = column;
            _allowKana = allowKana;
            _allowNum = allowNum;
            _allowNumSign = allowNumSign;
            _allowSign = allowSign;
            _allowSpace = allowSpace;
            _allowWord = allowWord;
            _hAlign = hAlign;
            _padZero = padZero;
            _allowZeroCode = allowZeroCode;
        }
        # endregion

        # region [CompareTo]
        /// <summary>
        /// UiSet�N���X������r����
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( UiSet other )
        {
            // ���l�Ŕ�r
            int result = this.Remarks.CompareTo( other.Remarks );
            if ( result == 0 )
            {
                // �c�c���Ŕ�r
                result = this.ItemDDName.CompareTo( other.ItemDDName );
            }
            return result;
        }
        # endregion
    }
    # endregion

    # region [DD�ݒ�N���X�i���ڕʁj]
    /// <summary>
    /// DD�ݒ�N���X�i���ڕʁj
    /// </summary>
    [Serializable]
    public class UiSetItem : IComparable<UiSetItem>
    {
        # region [private Fields]
        /// <summary>���ږ�</summary>
        private string _itemName;
        /// <summary>���ڂc�c��</summary>
        private string _itemDDName;
        # endregion

        # region [public propaty]
        /// <summary>
        /// ���ږ�
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        /// <summary>
        /// ���ڂc�c��
        /// </summary>
        public string ItemDDName
        {
            get { return _itemDDName; }
            set { _itemDDName = value; }
        }
        # endregion

        # region [CompareTo]
        /// <summary>
        /// UiSetItem������r����
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( UiSetItem other )
        {
            // �c�c���Ŕ�r
            int result = this.ItemDDName.CompareTo( other.ItemDDName );
            if ( result == 0 )
            {
                // ���ږ��Ŕ�r
                result = this.ItemName.CompareTo( other.ItemName );
            }
            return result;
        }
        # endregion
    }
    # endregion

    # region [UI�ݒ�N���X�i�t�H�[���ʁj]
    /// <summary>
    /// UI�ݒ�N���X�i�t�H�[���ʁj
    /// </summary>
    [Serializable]
    public class UiSetByForm
    {
        private string _formName;
        private List<UiSetItem> _uiSetItems;

        /// <summary>
        /// �t�H�[����
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// �t�h�ݒ�A�C�e�����X�g
        /// </summary>
        public List<UiSetItem> UISetItems
        {
            get { return _uiSetItems; }
            set { _uiSetItems = value; }
        }
    }
    # endregion

    # region [UI�ݒ�N���X�i�A�Z���u���ʁj]
    /// <summary>
    /// UI�ݒ�N���X�i�A�Z���u���ʁj
    /// </summary>
    [Serializable]
    public class UiSetByAssembly
    {
        private List<UiSetByForm> _uiSetByForm;
        private List<UiSet> _uiSetDD;

        /// <summary>
        /// �t�H�[���ʐݒ胊�X�g
        /// </summary>
        public List<UiSetByForm> UISetByForms
        {
            get { return _uiSetByForm; }
            set { _uiSetByForm = value; }
        }
        /// <summary>
        /// �c�c�ݒ胊�X�g
        /// </summary>
        public List<UiSet> UISetDD
        {
            get { return _uiSetDD; }
            set { _uiSetDD = value; }
        }
    }
    # endregion

    # region [UI�ݒ�N���X�i���ʃt�@�C���p�j]
    /// <summary>
    /// UI�ݒ�N���X�i���ʃt�@�C���p�j
    /// </summary>
    [Serializable]
    public class UiSetCommon
    {
        private List<UiSetItem> _uiSetItems;
        private List<UiSet> _uiSetDD;

        /// <summary>
        /// �t�h�ݒ�A�C�e�����X�g
        /// </summary>
        public List<UiSetItem> UISetItems
        {
            get { return _uiSetItems; }
            set { _uiSetItems = value; }
        }
        /// <summary>
        /// �c�c�ݒ胊�X�g
        /// </summary>
        public List<UiSet> UISetDD
        {
            get { return _uiSetDD; }
            set { _uiSetDD = value; }
        }
    }
    # endregion
    # endregion �� DD�ɑΉ�����ݒ�N���X ��

}

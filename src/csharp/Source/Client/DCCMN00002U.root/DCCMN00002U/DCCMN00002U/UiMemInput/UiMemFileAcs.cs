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
    public class UiMemFileAcs
    {
        # region [static private fields]
        /// <summary>(static)�L�[���X�g�̃f�B�N�V���i���i�A�Z���u���P�ʁj</summary>
        static private Dictionary<string, List<UiMemInputDataKey>> stc_uiMemInputDataKeysDic;
        /// <summary>(static)���͕ۑ��f�B�N�V���i���i�A�Z���u���E�t�H�[���E�I�v�V�����P�ʁj</summary>
        static private Dictionary<UiMemInputDataKey, UiMemInputDataForm> stc_uiMemInputDataFormDic;
        # endregion

        # region [private fields]
        # endregion

        # region [Constructor]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public UiMemFileAcs()
        {
        }
        # endregion

        # region [public Methods]
        /// <summary>
        /// ���͕ۑ��t�@�C���ǂݍ���
        /// </summary>
        /// <param name="uiMemInputDataForm"></param>
        /// <param name="assemblyName"></param>
        /// <param name="formName"></param>
        /// <param name="optionCode"></param>
        /// <returns></returns>
        public int ReadMemInput( out UiMemInputDataForm uiMemInputDataForm,string assemblyName, string formName, string optionCode )
        {
            //-------------------------------------------------------------------
            // ����
            //-------------------------------------------------------------------
            // �ԋp�l�E�����l�Z�b�g
            int result = 4;
            // �o�̓p�����[�^�E�����l�Z�b�g
            uiMemInputDataForm = null;

            // �f�B�N�V���i����������ΐV�K�쐬
            if ( stc_uiMemInputDataFormDic == null )
            {
                stc_uiMemInputDataFormDic = new Dictionary<UiMemInputDataKey, UiMemInputDataForm>();
            }
            if ( stc_uiMemInputDataKeysDic == null )
            {
                stc_uiMemInputDataKeysDic = new Dictionary<string, List<UiMemInputDataKey>>();
            }

            //-------------------------------------------------------------------
            // �ǂݍ���
            //-------------------------------------------------------------------

            // �ǂݍ��݃L�[����
            UiMemInputDataKey key = new UiMemInputDataKey( assemblyName, formName, optionCode );


            if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
            {
                //------------------------------------------------------
                // �f�B�N�V���i���ɑ��݂���Ȃ�f�B�N�V���i������擾
                //------------------------------------------------------
                uiMemInputDataForm = stc_uiMemInputDataFormDic[key];

                // --- ADD 2011/08/02 by LDNS�����---------->>>>>
                // ����I��
                result = 0;
                // --- ADD 2011/08/02 by LDNS�����----------<<<<<
            }
            else
            {
                //------------------------------------------------------
                // �f�B�N�V���i���ɑ��݂��Ȃ��Ȃ�A�t�@�C������f�V���A���C�Y
                //------------------------------------------------------
                string xmlName = GetXMLName( key.AssemblyName );
                if ( File.Exists( xmlName ) )
                {
                    try
                    {
                        //-----------------------------------------------
                        // �w�l�k�t�@�C�����f�V���A���C�Y
                        //-----------------------------------------------
                        List<UiMemInputDataForm> uiMemAsm = Deserialize<List<UiMemInputDataForm>>( xmlName );

                        //-----------------------------------------------
                        // �f�B�N�V���i���ɑޔ�
                        //-----------------------------------------------
                        List<UiMemInputDataKey> keyList = new List<UiMemInputDataKey>();
                        foreach ( UiMemInputDataForm uiMemForm in uiMemAsm )
                        {
                            // �������݃L�[����
                            UiMemInputDataKey newKey = new UiMemInputDataKey( key.AssemblyName, uiMemForm.FormName, uiMemForm.OptionCode );

                            // �ݒ�f�B�N�V���i���ɒǉ�
                            stc_uiMemInputDataFormDic.Add( newKey, uiMemForm );

                            // �L�[���X�g�ɒǉ�
                            keyList.Add( newKey );
                        }
                        // �A�Z���u���ʃL�[�f�B�N�V���i���ɒǉ�
                        stc_uiMemInputDataKeysDic.Add( key.AssemblyName, keyList );

                        //-----------------------------------------------
                        // �f�B�N�V���i������Ď擾
                        //-----------------------------------------------
                        if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
                        {
                            uiMemInputDataForm = stc_uiMemInputDataFormDic[key];

                            // ����I��
                            result = 0;
                        }
                        else
                        {
                            // �ݒ�Ȃ�
                        }
                    }
                    catch
                    { 
                        // ��O�����i�f�V���A���C�Y���s�Ȃǁj
                    }
                }
                else
                {
                    // �ۑ��t�@�C���Ȃ�
                }
            }

            return result;
        }
        /// <summary>
        /// ���͕ۑ��t�@�C����������
        /// </summary>
        /// <param name="uiMemInputDataForm"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public void WriteMemInput( UiMemInputDataForm uiMemInputDataForm, string assemblyName )
        {
            //----------------------------------------------------------------
            // �f�B�N�V���i���X�V
            //----------------------------------------------------------------
            
            // �������݃L�[����
            UiMemInputDataKey key = new UiMemInputDataKey( assemblyName, uiMemInputDataForm.FormName, uiMemInputDataForm.OptionCode );

            if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
            {
                // ���͕ۑ��������Ȃ�X�V
                stc_uiMemInputDataFormDic[key] = uiMemInputDataForm;
            }
            else
            {
                // ���͕ۑ��������Ȃ�ǉ�
                stc_uiMemInputDataFormDic.Add( key, uiMemInputDataForm );

                // �L�[���X�g�ɒǉ�
                if ( !stc_uiMemInputDataKeysDic.ContainsKey( assemblyName ) )
                {
                    // �A�Z���u���ʂj�������X�g�������Ȃ�A
                    // �A�Z���u���ʂj�������X�g���ǉ��B
                    stc_uiMemInputDataKeysDic.Add( assemblyName, new List<UiMemInputDataKey>() );
                }
                stc_uiMemInputDataKeysDic[assemblyName].Add( key );
            }
            //----------------------------------------------------------------
            // �w�l�k�������݁i�V���A���C�Y�j
            //----------------------------------------------------------------
            string xmlName = GetXMLName( assemblyName );

            List<UiMemInputDataForm> writeData = new List<UiMemInputDataForm>();
            foreach ( UiMemInputDataKey keyInAsm in stc_uiMemInputDataKeysDic[assemblyName])
            {
                if ( stc_uiMemInputDataFormDic.ContainsKey( keyInAsm ) )
                {
                    writeData.Add( stc_uiMemInputDataFormDic[keyInAsm] );
                }
            }
            // �V���A���C�Y
            Serialize( xmlName, writeData );
        }
        # endregion

        # region [private Methods]

        # region [���ʏ������i]
        /// <summary>
        /// �V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�擾���t�@�C����</param>
        /// <param name="writeObject">�V���A���C�Y�ΏۃI�u�W�F�N�g</param>
        private void Serialize( string fileName, object writeObject )
        {
            FileStream fs = new FileStream( fileName, FileMode.Create );
            try
            {
                XmlSerializer xs = new XmlSerializer( writeObject.GetType() );

                xs.Serialize( fs, writeObject );
            }
            catch 
            {
            }
            finally
            {
                fs.Close();
            }
        }
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
            return string.Format( "{0}\\{1}.mem", ConstantManagement_ClientDirectory.UISettings_FormPos, assemblyName );
        }
        # endregion

        # endregion

        # region [���͕ۑ��f�[�^�j�d�x]
        /// <summary>
        /// ���͕ۑ��f�[�^�j�d�x
        /// </summary>
        private struct UiMemInputDataKey
        {
            /// <summary>�A�Z���u����</summary>
            private string _assemblyName;
            /// <summary>�t�H�[����</summary>
            private string _formName;
            /// <summary>�I�v�V�����R�[�h</summary>
            private string _optionCode;
            /// <summary>
            /// �A�Z���u����
            /// </summary>
            public string AssemblyName
            {
                get { return _assemblyName; }
                set { _assemblyName = value; }
            }
            /// <summary>
            /// �t�H�[����
            /// </summary>
            public string FormName
            {
                get { return _formName; }
                set { _formName = value; }
            }
            /// <summary>
            /// �I�v�V�����R�[�h
            /// </summary>
            /// <remarks>����t�H�[���Őݒ�𕡐����ꍇ�Ɏg�p���܂��B</remarks>
            public string OptionCode
            {
                get { return _optionCode; }
                set { _optionCode = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="assemblyName">�A�Z���u����</param>
            /// <param name="formName">�t�H�[����</param>
            /// <param name="optionCode">�I�v�V�����R�[�h</param>
            public UiMemInputDataKey (string assemblyName, string formName, string optionCode)
            {
                _assemblyName = assemblyName;
                _formName = formName;
                _optionCode = optionCode;
            }
        }
        # endregion
    }
    # endregion �� DD�ɑ΂���ݒ���Ǘ�����N���X(Acs) ��

    # region [���͓��e�ێ��N���X]
    /// <summary>
    /// �t�h���͕ۑ��f�[�^�E�t�H�[���N���X
    /// </summary>
    [Serializable]
    public class UiMemInputDataForm
    {
        /// <summary>�t�H�[����</summary>
        private string _formName;
        /// <summary>�I�v�V�����R�[�h</summary>
        private string _optionCode;
        /// <summary>���͕ۑ��f�[�^���X�g</summary>
        private List<UiMemInputData> _uiMemInputDatas;
        /// <summary>�J�X�^�}�C�Y�f�[�^</summary>
        private List<string> _customizeData;

        /// <summary>
        /// �t�H�[����
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// �I�v�V�����R�[�h
        /// </summary>
        public string OptionCode
        {
            get { return _optionCode; }
            set { _optionCode = value; }
        }
        /// <summary>
        /// ���͕ۑ��f�[�^���X�g
        /// </summary>
        public List<UiMemInputData> UiMemInputDatas
        {
            get { return _uiMemInputDatas; }
            set { _uiMemInputDatas = value; }
        }
        /// <summary>
        /// �J�X�^�}�C�Y�f�[�^
        /// </summary>
        public List<string> CustomizeData
        {
            get { return _customizeData; }
            set { _customizeData = value; }
        }
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UiMemInputDataForm()
        {
            FormName = string.Empty;
            OptionCode = string.Empty;
            UiMemInputDatas = new List<UiMemInputData>();
            CustomizeData = new List<string>();
        }
    }
    /// <summary>
    /// �t�h���͕ۑ��f�[�^�N���X
    /// </summary>
    [Serializable]
    public class UiMemInputData
    {
        /// <summary>�Ώۖ���</summary>
        private string _targetName;
        /// <summary>���̓f�[�^</summary>
        private string _inputData;

        /// <summary>
        /// �Ώۖ���
        /// </summary>
        public string TargetName
        {
            get { return _targetName; }
            set { _targetName = value; }
        }
        /// <summary>
        /// ���̓f�[�^
        /// </summary>
        public string InputData
        {
            get { return _inputData; }
            set { _inputData = value; }
        }
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UiMemInputData()
        {
            TargetName = string.Empty;
            InputData = string.Empty;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="targetName">�ΏۃR���g���[������</param>
        /// <param name="inputData">���͓��e</param>
        public UiMemInputData( string targetName, string inputData)
        {
            TargetName = targetName;
            InputData = inputData;
        }
    }    
    # endregion
}

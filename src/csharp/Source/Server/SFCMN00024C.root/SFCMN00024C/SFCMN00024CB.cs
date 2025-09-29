using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using System.IO;
using Broadleaf.Library.Collections;
using System.Security.Cryptography;

namespace Broadleaf.Library.Runtime.Serialization
{
    /// <summary>
    /// �I�t���C���f�[�^�V���A���C�U�̃��b�p�[
    /// 2008.07.18 23011 noguchi
    /// 2012.11.14 23011 noguchi ��O������ǉ�
    /// </summary>
    public class OfflineDataSerializer
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public OfflineDataSerializer()
        {

        }

        private _OfflineDataSerializer _serializer = new _OfflineDataSerializer();

        private OfflineDataSerializer2 _serializer2 = new OfflineDataSerializer2();

        #region public Method CustomSerializer Object Serialize�֘A
        
        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <param name="serializedData">�V���A���C�Y���ʃf�[�^</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data, out byte[] serializedData)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��
            serializedData = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data, out serializedData);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data, string targetDir)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data, targetDir);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="deserializeData">�f�V���A���C�Y�Ώۃf�[�^</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public object DeSerialize(string classId, string[] keyList, byte[] deserializeData)
        {
            //2008.08.12 23011 noguchi del >>
            ////�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            ////�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            //object retObj = null;

            //if (_serializer2.Exists(classId, keyList))
            //{
            //    retObj = _serializer2.Deserialize(classId, keyList);
            //}
            //else
            //{
            //    retObj = _serializer.DeSerialize(classId, keyList);
            //}

            //return retObj;
            //>> 2008.08.12 23011 noguchi del

            //�f�V���A���C�Y�Ɏ��s�����狌�����Ńf�V���A���C�Y���Ă݂�
            object retObj = null;

            try
            {
                //2010.05.07 noguchi del
                //retObj = _serializer2.Deserialize(classId, keyList);
                retObj = _serializer2.Deserialize(classId, keyList, deserializeData);
            }
            catch (Exception ex)
            {
            }

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                //�V���A���C�U�Q�Ńf�V���A���C�Y���Ă��f�[�^���擾�ł��Ȃ������ꍇ�ɂ͋������Ńf�V���A���C�Y���Ă݂�
                if (retObj == null)
                {
                    //2010.05.07 noguchi del
                    //retObj = _serializer.DeSerialize(classId, keyList);
                    retObj = _serializer.DeSerialize(classId, keyList, deserializeData);
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O�̏ꍇ�ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retObj;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public object DeSerialize(string classId, string[] keyList)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            object retObj = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�
                if (_serializer2.Exists(classId, keyList))
                {
                    retObj = _serializer2.Deserialize(classId, keyList);
                }
                else
                {
                    retObj = _serializer.DeSerialize(classId, keyList);
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retObj;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public object DeSerialize(string classId, string[] keyList, string targetDir)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            object retObj = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                //2008.08.12 23011 noguchi �t�@�C�����݊m�F�������f�B���N�g���w��ł���悤�ɏC��
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retObj = _serializer2.Deserialize(classId, keyList, targetDir);
                }
                else
                {
                    retObj = _serializer.DeSerialize(classId, keyList, targetDir);
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retObj;
        }
        #endregion

        #region public Method String[] Serialize�֘A
        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        public int SerializeString(string classId, string[] keyList, string[] data)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || data.Length == 0) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>STATUS</returns>
        public int SerializeString(string classId, string[] keyList, string[] data, string targetDir)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || data.Length == 0) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data, targetDir);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public string[] DeSerializeString(string classId, string[] keyList)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            string[] retStr = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                if (_serializer2.Exists(classId, keyList))
                {
                    retStr = _serializer2.Deserialize(classId, keyList) as string[];
                }
                else
                {
                    retStr = _serializer.DeSerializeString(classId, keyList) as string[];
                }

                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retStr;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public string[] DeSerializeString(string classId, string[] keyList, string targetDir)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            string[] retStr = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                //2008.08.12 23011 noguchi �t�@�C���̑��݃`�F�b�N���f�B���N�g���w��ōs���悤�ɏC��
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retStr = _serializer2.Deserialize(classId, keyList, targetDir) as string[];
                }
                else
                {
                    retStr = _serializer.DeSerializeString(classId, keyList, targetDir) as string[];
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retStr;
        }
        #endregion

        #region public Method byte[] Serialize �֘A
        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        public int SerializeByte(string classId, string[] keyList, byte[] data)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || data.Length == 0) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi
            try
            {
                _serializer2.Serialize(classId, keyList, data);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>STATUS</returns>
        public int SerializeByte(string classId, string[] keyList, byte[] data, string targetDir)
        {
            //�V���A���C�Y�͐V�I�t���C���ۑ����i�݂̂ōs��

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi �ȑO�̃V���A���C�Y���i�Ɠ�������ɂ��� >>
            if (data == null || data.Length == 0) return status;
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //>>2008.09.11 23011 noguchi

            try
            {
                _serializer2.Serialize(classId, keyList, data, targetDir);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public byte[] DeSerializeByte(string classId, string[] keyList)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�
            byte[] retByte = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                if (_serializer2.Exists(classId, keyList))
                {
                    retByte = _serializer2.Deserialize(classId, keyList) as byte[];
                }
                else
                {
                    retByte = _serializer.DeSerializeByte(classId, keyList) as byte[];
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retByte;
        }

        /// <summary>
        /// �f�V���A���C�Y
        /// </summary>
        /// <param name="classId">�N���XID</param>
        /// <param name="keyList">�L�[List</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>�f�V���A���C�Y����</returns>
        public byte[] DeSerializeByte(string classId, string[] keyList, string targetDir)
        {
            //�V�����t�@�C��������ΐV�����t�@�C����ǂݏo���B
            //�V�����t�@�C�����Ȃ���΋������ɐ�����ڂ�

            byte[] retByte = null;

            //2012.11.14 23011 noguchi ��O�����ǉ� >>
            try
            {
                //>> 2012.11.14 23011 noguchi ��O�����ǉ�

                //2008.08.12 23011 noguchi �t�@�C���̑��݃`�F�b�N���f�B���N�g���w�肵�čs���悤�ɏC��
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retByte = _serializer2.Deserialize(classId, keyList, targetDir) as byte[];
                }
                else
                {
                    retByte = _serializer.DeSerializeByte(classId, keyList, targetDir) as byte[];
                }
                //2012.11.14 23011 noguchi ��O�����ǉ� >>
            }
            catch
            {
                //��O���ɂ̓f�[�^�Ȃ��Ƃ���
            }
            //>> 2012.11.14 23011 noguchi ��O�����ǉ�

            return retByte;
        }
        #endregion

        #region public Method ���ʃ��\�b�h
        /// <summary>
        /// �V���A���C�Y�t�@�C���폜
        /// </summary>
        /// <param name="classId">�N���X��</param>
        /// <param name="keyList">KEY���X�g</param>
        /// <returns>STATUS</returns>
        public int Delete(string classId, string[] keyList)
        {
            //�V�A���t�@�C���������폜����
            _serializer.Delete(classId, keyList);
            _serializer2.Delete(classId, keyList);

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �V���A���C�Y�t�@�C���폜
        /// </summary>
        /// <param name="classId">�N���X��</param>
        /// <param name="keyList">KEY���X�g</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>STATUS</returns>
        public int Delete(string classId, string[] keyList, string targetDir)
        {
            //�V�A���t�@�C���������폜����
            _serializer.Delete(classId, keyList, targetDir);
            _serializer2.Delete(classId, keyList, targetDir);

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �V���A���C�Y�t�@�C�����݃`�F�b�N
        /// </summary>
        /// <param name="classId">�N���X��</param>
        /// <param name="keyList">KEY���X�g</param>
        /// <returns>T:�L�� F:����</returns>
        public bool Exists(string classId, string[] keyList)
        {
            return _serializer.Exists(classId, keyList) || _serializer2.Exists(classId, keyList);
        }

        /// <summary>
        /// �V���A���C�Y�t�@�C�����݃`�F�b�N
        /// </summary>
        /// <param name="classId">�N���X��</param>
        /// <param name="keyList">KEY���X�g</param>
        /// <param name="targetDir">�����Ώۃf�B���N�g��</param>
        /// <returns>T:�L�� F:����</returns>
        public bool Exists(string classId, string[] keyList, string targetDir)
        {
            return _serializer.Exists(classId, keyList, targetDir) || _serializer2.Exists(classId, keyList, targetDir);
        }

        #endregion

    }

}
